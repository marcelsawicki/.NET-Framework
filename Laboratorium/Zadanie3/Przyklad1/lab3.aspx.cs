using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace lab3_1
{
    public partial class _Default : System.Web.UI.Page
    {
    public class Kalkulator 
    {   
        public float dzielenie(int liczba1, int liczba2)
            {
                if (liczba2 == 0) return 0;
                else
                {
                    float wynik = liczba1 / liczba2;
                    return wynik;
                }
            }

            public int mnozenie(int liczba1, int liczba2)
            {
                    int wynik = liczba1 * liczba2;
                    return wynik;
            }

            public int dodawanie(int liczba1, int liczba2)
            {
                int wynik = liczba1 + liczba2;
                return wynik;
            }

            public int odejmowanie(int liczba1, int liczba2)
            {
                int wynik = liczba1 - liczba2;
                return wynik;
            }
        }

    public class kalkulatorZaawansowany : Kalkulator
    {
        public float dzielenie(int liczba1, int liczba2)
        {
            if (liczba2 == 0) return 0;
            else
            {
                float wynik = liczba1 / liczba2;
                return wynik;
            }
        }

        public int mnozenie(int liczba1, int liczba2)
        {
            int wynik = liczba1 * liczba2;
            return wynik;
        }

        public int dodawanie(int liczba1, int liczba2)
        {
            int wynik = liczba1 + liczba2;
            return wynik;
        }

        public int odejmowanie(int liczba1, int liczba2)
        {
            int wynik = liczba1 - liczba2;
            return wynik;
        }
    }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Kalkulator k = new Kalkulator();

            int wynik = k.dodawanie(Int32.Parse(TextBox1.Text),
                                      Int32.Parse(TextBox2.Text));
            Label2.Text = ""+wynik;

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Kalkulator k = new Kalkulator();

            int wynik = k.odejmowanie(Int32.Parse(TextBox1.Text),
                                      Int32.Parse(TextBox2.Text));
            Label2.Text = "" + wynik;
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Kalkulator k = new Kalkulator();

            int wynik = k.mnozenie(Int32.Parse(TextBox1.Text),
                                      Int32.Parse(TextBox2.Text));
            Label2.Text = "" + wynik;

        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            Kalkulator k = new Kalkulator();

            float wynik = k.dzielenie(Int32.Parse(TextBox1.Text),
                                      Int32.Parse(TextBox2.Text));
            Label2.Text = "" + wynik;

        }

       
    }
}