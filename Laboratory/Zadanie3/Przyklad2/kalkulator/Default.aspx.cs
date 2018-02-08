using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace kalkulator
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
         /*   public float dzielenie(int liczba1, int liczba2)
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
          */
        }
            
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Kalkulator k = new Kalkulator();

            int wynik = k.dodawanie(Int32.Parse(TextBox1.Text),
                                      Int32.Parse(TextBox2.Text));
            Label2.Text = "" + wynik;

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

        protected void Button5_Click(object sender, EventArgs e) // Potega
        {
            Kalkulator k = new Kalkulator();
            
            int wynik;
            Label6.Text = "1";   

            for (int i = 0; i < Int32.Parse(TextBox4.Text); i++)
            {

                wynik = k.mnozenie(Int32.Parse(TextBox3.Text),
                                          Int32.Parse(Label6.Text));
                
                
                Label6.Text = "" + wynik;        
            }

        }

        protected void Button6_Click(object sender, EventArgs e)
        {
            
            int wynik = Int32.Parse(TextBox5.Text);


            Label7.Text = "" + Math.Sqrt(wynik);
        }

        protected void Button7_Click(object sender, EventArgs e)
        {
            int wynik = Int32.Parse(TextBox6.Text);


            Label13.Text = "" + Math.Abs(wynik);
        }

        protected void Button8_Click(object sender, EventArgs e)
        {

            int M = Int32.Parse(TextBox7.Text);
            int O = Int32.Parse(TextBox8.Text);
            int K = Int32.Parse(TextBox9.Text);
            int W = Int32.Parse(TextBox10.Text);
            int wynik;
           // TextBox11.Text = ""; 
            for (int i = 0; i < M; i++)
            {
                wynik = 1+i;
                //Label14.Text = " " +text +", " + i + " "+ wynik;
                //TextBox11.Text += ", " + i + " = " + wynik; 
                //TextBox11.Text("i"); 
            }
            

            
        }


    }
}