using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Kalkulator
{
    public partial class kalkulator2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public class DzielZero : ApplicationException
        {
            public int errorCode;
                public DzielZero()
                {errorCode=10;}
        }
        public class kalkulator
        {
            public int dodaj(int l1, int l2)
            { return l1 + l2; }

            public int odejmij(int l1, int l2)
            { return l1 - l2; }

            public int mnoz(int l1, int l2)
            { return l1 * l2; }

            public float dziel(float l1, float l2)
            {
                float wynik = l1 / l2;
                if (l2 <= 0) throw new DzielZero();
                return wynik;
            
            }

            public kalkulator()
            {
                //konstruktor klasy
            }
        }

        public class kalkulatorZ:kalkulator
        {
            public int potega(int l1, int l2)
            {
                int wynik = 1;
                int i = 0;
                while (i<l2)
                {
                    wynik = wynik * l1;
                    i++;
                }
                return wynik;
             }
            public int wbezwgl(int l1, int l2)
            {   int wynik = l1;
            if (wynik < 0) { wynik = wynik * (-1); }
                return wynik;
            }
            public kalkulatorZ()
            {
                //konstruktor klasy
            }
        }

        protected void Button21_Click(object sender, EventArgs e)
        {
            try
            {
                kalkulatorZ kZ = new kalkulatorZ();
                int wynik = kZ.potega(
                Int32.Parse(TextBox21.Text), Int32.Parse(TextBox22.Text));
                Label21.Text = "Wynik " + wynik;
            }
            catch (DzielZero)
            {
                Label21.Text = "Wynik " + "Dzielenie przez zero!";
            }
        }

        protected void Button22_Click(object sender, EventArgs e)
        {
            kalkulatorZ kZ = new kalkulatorZ();
            int wynik = kZ.wbezwgl(
            Int32.Parse(TextBox21.Text), Int32.Parse(TextBox22.Text));
            Label21.Text = "Wynik " + wynik;
        }
    }
}