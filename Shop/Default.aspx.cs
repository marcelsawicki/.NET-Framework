using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

//using Core;

namespace wwwroot
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["MyBucket"] == null) Session["MyBucket"] = new Core.Bucket();
            if (Session["ZALOGOWANY"] != null) { LabelLogin.Text = "" + Session["ZALOGOWANY"]; }            
        }
    }
}