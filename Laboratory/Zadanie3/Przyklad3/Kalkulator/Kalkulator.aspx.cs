using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Kalkulator
{
    public partial class Kalkulator : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        /*public interface ILiczydlo
        {
            int dodaj(int l1, int l2);
            int odejmij(int l1, int l2);
            int mnoz(int l1, int l2);
            float dziel(float l1, float l2);
        } */

        public class kalkulator//: ILiczydlo
        {

            public static int dodaj(int l1, int l2)
            {return l1 + l2;}

            public static int odejmij(int l1, int l2)
            { return l1 - l2; }

            public static int mnoz(int l1, int l2)
            { return l1 * l2; }

            public static float dziel(float l1, float l2)
            {
               
                    float wynik = l1 / l2;
                    if (l2 == 0)
                        throw new DzielZero();
                    return wynik; 
               
                
            }

           public kalkulator() {
               //konstruktor klasy
           }
            }

        protected void Button1_Click(object sender, EventArgs e)
        {
            int wynik = kalkulator.dodaj(
            Int32.Parse(TextBox1.Text), Int32.Parse(TextBox2.Text));
            Label1.Text = "Wynik " + wynik;
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            
            int wynik = kalkulator.odejmij(
            Int32.Parse(TextBox1.Text), Int32.Parse(TextBox2.Text));
            Label1.Text = "Wynik " + wynik;
        }

        public class DzielZero : ApplicationException
        {
            public int errorCode;
            public DzielZero()
            { errorCode = 10; }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            int wynik = kalkulator.mnoz(
            Int32.Parse(TextBox1.Text), Int32.Parse(TextBox2.Text));
            Label1.Text = "Wynik " + wynik;
        }


        protected void Button4_Click(object sender, EventArgs e)
        {
            try
            {
                float wynik = kalkulator.dziel(
                Int32.Parse(TextBox1.Text), Int32.Parse(TextBox2.Text));
                Label1.Text = "Wynik " + wynik;
            }

            catch (DzielZero)
            {
                Label1.Text = "Wynik " + "Dzielenie przez zero!";
            }
            
            //catch(DivideByZeroException) { 
            //    Label1.Text = "Wynik " + "Dzielenie przez zero!";
            //}
            
            catch (FormatException)
            {
                Label1.Text = "Wynik " + "Podaj liczbe!";
            }
            catch (OverflowException)
            {
                Label1.Text = "Wynik " + "Przekroczono!";
            }
        }
    }
}