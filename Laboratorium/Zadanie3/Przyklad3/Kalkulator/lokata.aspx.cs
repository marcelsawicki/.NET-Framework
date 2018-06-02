using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Kalkulator
{
    public partial class lokata : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public class lokaty
        {

            public double wylicz(double l1, double l2, double l3, double l4)
            {
                double podstawa = (1 + (l2/100));
                double wykladnikZreszta = (l1 / l3);
                int wykladnik = (int)wykladnikZreszta;
                return l4*Math.Pow(podstawa, wykladnik);
            }

            public void wyliczPetla(double l1, double l2, double l3, double l4)
            {
                for (int n=0;n<=l1;n++ )
                {
                    double[] tablica= new double[(int)l1];

                    double podstawa = (1 + (l2 / 100));
                    double wykladnikZreszta = (n / l3);
                    int wykladnik = (int)wykladnikZreszta;
                    double wyn= l4 * Math.Pow(podstawa, wykladnik);
                    tablica[n] = wyn;
                }
                
            }

            public lokaty()
            {
                //konstruktor klasy
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            lokaty l = new lokaty();
            double wynik = l.wylicz(
            Int32.Parse(TextBox1.Text), Int32.Parse(TextBox2.Text), Int32.Parse(TextBox3.Text), Int32.Parse(TextBox4.Text));

            Label1.Text = "Wynik " + wynik;
            //
            double l1 = Int32.Parse(TextBox1.Text);
            double l2 = Int32.Parse(TextBox2.Text);
            double l3 = Int32.Parse(TextBox3.Text);
            double l4 = Int32.Parse(TextBox4.Text);
            
            ArrayList NaszaLista = new ArrayList();
            double[] tablica = new double[(int)l1];

            for (int n = 0; n < l1; n++)
            {
                double podstawa = (1 + (l2 / 100));
                double wykladnikZreszta = (n /l3);
                int wykladnik = (int)wykladnikZreszta;
                double wyn1 = l4 * Math.Pow(podstawa, wykladnik);
                TextBox5.Text += " miesiąc nr "+n+", kwota: "+wyn1+" PLN \n";
                NaszaLista.Add(wyn1);
                tablica[n] = wyn1;
            }
            for (int k = 0; k < l1; k++ )
            {
                TextBox5.Text += " ---- z listy " + NaszaLista[k] + " PLN \n";
                TextBox5.Text += " ---- z tablicy " + tablica[k] + " PLN \n";
            }
        }
    }
}