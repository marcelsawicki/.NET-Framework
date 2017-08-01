using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.SharePoint.Client;
using Microsoft.SharePoint.Client.EventReceivers;
using System.Security;
using System.Configuration;
using Microsoft.SharePoint.Client.Utilities;

namespace SharePointApp2Web.Services
{
    public class RERitemUpdatedPAGESardent : IRemoteEventService
    {
        public SPRemoteEventResult ProcessEvent(SPRemoteEventProperties properties)
        {
            throw new NotImplementedException();
        }

        public void ProcessOneWayEvent(SPRemoteEventProperties properties)
        {
            string pass = ConfigurationManager.AppSettings["pass"];
            SecureString password = new SecureString();

            foreach (char character in pass)
            {
                password.AppendChar(character);
            }

            SharePointOnlineCredentials cred = new SharePointOnlineCredentials("login@email.pl", password);
            using (ClientContext clientContext = new ClientContext(properties.ItemEventProperties.WebUrl))
            {
                clientContext.Credentials = cred;
                if (clientContext != null)
                {
                    int id = properties.ItemEventProperties.ListItemId;
                    var list = clientContext.Web.Lists.GetByTitle("Pages");
                    var item = list.GetItemById(id);
                    var file = item.File;
                    var myContent = item.ContentType;
                    clientContext.Load(item);
                    clientContext.Load(file);
                    clientContext.Load(myContent);

                    // If Approval status has changed
                    if (properties.ItemEventProperties.AfterProperties.ContainsKey("vti_doclibmodstat"))
                    {
                        var conditionalStatusAfter = properties.ItemEventProperties.AfterProperties["vti_doclibmodstat"];

                        var whatStatus = conditionalStatusAfter.ToString();

                        // If Approval status is "Pending" 
                        if (whatStatus == "2")
                        {
                            clientContext.ExecuteQuery();
                            // If page should be autoapproved
                            if (this.PageShouldBeAutoApproved(myContent))
                            {
                                file.Approve(String.Empty);
                            }
                            else
                            {
                                EmailProperties emailProps = new Microsoft.SharePoint.Client.Utilities.EmailProperties();
                                emailProps.To = new string[] { System.Configuration.ConfigurationManager.AppSettings["mailTo"] };
                                emailProps.CC = System.Configuration.ConfigurationManager.AppSettings["mailCC"].Split(';');
                                emailProps.Subject = String.Format("Aktualność \"{0}\" oczekuje na zatwierdzenie", properties.ItemEventProperties.AfterProperties["vti_title"]);
                                emailProps.Body = String.Format("Aktualność \"{0}\" oczekuje na zatwierdzenie, do publikacji na stronie głównej. Przejdź do <a href=\"{1}/_layouts/15/approve.aspx?List={2}&ID={3}\">widoku zatwierdzania</a> i zatwierdź lub odrzuć artykuł.",
                                    properties.ItemEventProperties.AfterProperties["vti_title"],
                                    properties.ItemEventProperties.WebUrl,
                                    properties.ItemEventProperties.ListId,
                                    properties.ItemEventProperties.ListItemId);
                                Utility.SendEmail(clientContext, emailProps);
                                clientContext.ExecuteQuery();
                            }
                        }
                    }

                    clientContext.ExecuteQuery();
                    var whatContent = myContent.Name;
                }
            }
        }

        private bool PageShouldBeAutoApproved(ContentType myContent)
        {
            // return (item.ContentType.Name != "Welcome Page");
            if (myContent.Name != "Welcome Page") { return true; } else { return false; }

        }
    }
}