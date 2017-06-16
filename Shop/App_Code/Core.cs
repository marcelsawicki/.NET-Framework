using System;
using System.Data.OleDb;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections;
using System.Data;

namespace Core
{
    /// <summary>
    /// Summary description for Core
    /// </summary>
    public class PolaczDB
    {
        public static Produkt ZnajdzProdukt(int productID)
        {
            OleDbConnection Polaczenie = new OleDbConnection();
            Polaczenie.ConnectionString = "Provider=Microsoft.JET.OLEDB.4.0;data source=|DataDirectory|\\sklep.mdb";
            Polaczenie.Open();
            OleDbCommand polecenieSQL = new OleDbCommand("SELECT nazwa, produktID, cena FROM produkt WHERE produktID=" +productID, Polaczenie);
            OleDbDataReader DostepDoDanych = polecenieSQL.ExecuteReader();
            if (DostepDoDanych.HasRows == true) //HasRows
                {
                Core.Produkt p = new Produkt();
                DostepDoDanych.Read();
                p.nazwa = DostepDoDanych["nazwa"].ToString();
                p.productID = Int32.Parse(DostepDoDanych["produktID"].ToString());
                p.cena = Double.Parse(DostepDoDanych["cena"].ToString());
                DostepDoDanych.Close();
                Polaczenie.Close();
                return p;
                }
            else return null;
            
        }

    }
  
        public class Produkt
        {
            public int productID;
            public String nazwa;
            public double cena;
        }
    public class PozycjaZamowienia
        {
            public int productID;
            public int ilosc;
            public String nazwa;
            public double cena;
            

            public PozycjaZamowienia(Produkt p) 
            {
                this.productID = p.productID;
                this.nazwa = p.nazwa;
                this.cena = p.cena;
                this.ilosc = 1;
            }

            public double WartoscPozycji() 
            {
                return (this.cena * this.ilosc);
            }
        }

    /// <summary>
    /// Summary description for class Bucket
    /// Klasa korzysta z kolekcji HashTable
    /// Klasa Bucket zawiera informacje o koszyku zamowien
    /// </summary>

    public class Bucket
    {
        private Hashtable Orders = new Hashtable(); //tworzę kolekcję Hashtable
        private double VAT = 0.23; //wartość podatku VAT w Polsce


        // metody 

        public double CalkowitaWartosc()
        {
            if (Orders.Count==0) return 0.0;
            double suma=0;
            //nie rozumiem co to jest
            //IEnumertor - StringDictionary - wszystkie kolekcje związane są z tym interfejsem
            //W przestrzeni nazw System.Collection znajdują się kolekcje:
            //ArrayList, BitArray, HashTable, Hybrid-StringCollection, StringDictionary
            //Wszystkie kolekcje związane są z następującymi interfejsami
            //IList
            //IDictionary
            //ICollection
            //IEnumerable

            IEnumerator pozycja = Orders.Values.GetEnumerator(); 
            //metody i właściwośći interfejsu IEnumerable
            //metoda IEnumerator GetEnumerator() j. w.
            //
            //Enumeratory są to małe klasy, których zadaniem jest niejawna implementacja
            //specjalnego wskaźnika (kursora) w celu iteracji i odczytania kolejnych
            //elementów kolekcji za pomocą wskaźnika while lub foreach.
            //Użycie pozostałych instrukcji pętli jest kłopotliwe i zalecane tylko
            //w wyjątkowych przypadkach.
            //
            //  Enumeratory dostarczane są przez interfejs IEnumerator, który jako
            //bazowy, pozwala na dostęp do wszystkich elementów wybranej kolekcji.
            //Zawiera dwie metody: Reset - ustawia wskaźnik przed pierwszym elementem
            //kolekcji, MoveNext - przesuwa kursor do następnego elementu kolekcji oraz
            // właściwość tylko do odczytu oraz Current() - zwraca bieżący element
            //kolekcji. Dopóki wskaźnik trafia na kolejne elementy kolekcji, metoda
            //MoveNext zwraca true. Wartość false oznacza koniec kolekcji
            //(wskaźnik jest poza elementem).

            while (pozycja.MoveNext())
            {
                suma += ((PozycjaZamowienia)pozycja.Current).WartoscPozycji();
            }
            return suma;

            //korzystając z metody Current i MoveNext odczytuję i dodaję
            //wartości zamówienia 
            //- sprawdzić co to jest VALUES
            //w przypadku kolekcji HashTable:
            //Values - jest kolekcją wartości kluczy, czyli drugą podkolekcją kolekcji
            //HashTable
            //

        }//koniec metody CalkowitaWartosc()

        //dodalem ten kod, nie rozumiem go do końca

        public PozycjaZamowienia this[String produktID]
        {
            get
            {
                return (PozycjaZamowienia)Orders[produktID];
            }
        }
        //koniec metody Pozycja Zamowienie

        public void dodaj(PozycjaZamowienia p)
        {
            if (Orders[p.productID] == null) //productID - jest to ID obiektu Produkt
            {
                Orders.Add(p.productID, p); //Metoda Add jest metodą kolekcji HashTable
                //Add - dopisuje kolejne pary wartości (rekordów) do kolekcji (obiektu) HashTable;
            }
            else
            {
                PozycjaZamowienia oI = (PozycjaZamowienia)Orders[p.productID];
                oI.ilosc = oI.ilosc + 1;
            }
        }//koniec metody dodaj

        public void usun(PozycjaZamowienia p)
        {
            if (Orders[p.productID] != null) //productID - jest to ID obiektu Produkt
            {
                Orders.Remove(p.productID);
            }
        }//koniec metody usun

        public void zdejmij(PozycjaZamowienia p)
        {
            if (Orders[p.productID] != null) //productID - jest to ID obiektu Produkt
            {
                PozycjaZamowienia oI = (PozycjaZamowienia)Orders[p.productID];
                if (oI.ilosc > 1) oI.ilosc = oI.ilosc - 1;
                else Orders.Remove(p.productID);
                
                //Orders.Remove(p.productID); //Metoda Add jest metodą kolekcji HashTable
                //Add - dopisuje kolejne pary wartości (rekordów) do kolekcji (obiektu) HashTable;
            }
        }//koniec metody zdejmij

        public int ShowBucket(Table T)
        {
        //korzystam z kontrolki Table
            if(this.IlePozycji()==0) return 0;

            //HEADER
            TableRow row1 = new TableRow(); //korzystam z kontrolki Table
            TableCell c1 = new TableCell(); c1.Text = "&nbsp; nazwa "; row1.Cells.Add(c1);
            TableCell c2 = new TableCell(); c2.Text = "&nbsp; ilosc "; row1.Cells.Add(c2);
            TableCell c3 = new TableCell(); c3.Text = "&nbsp; cena "; row1.Cells.Add(c3);
            TableCell c4 = new TableCell(); c4.Text = "&nbsp; akcja "; row1.Cells.Add(c4);
            T.Rows.Add(row1);

            IEnumerator pozycja = Orders.Values.GetEnumerator(); //kolekcja
            
            //TREŚC
            
            while (pozycja.MoveNext()) //metoda kolekcji
            //MoveNext - przesuwa kursor do następnego elementu kolekcji oraz właściwości
            //tylko do odczytu
            {
                PozycjaZamowienia p = ((PozycjaZamowienia)pozycja.Current); //metoda kolekcji
            //Current - zwraca bieżący element kolekcji.

            TableRow row2 = new TableRow(); //dopisujemy kolejny wiersz
            TableCell c5 = new TableCell(); c5.Text = "&nbsp; " + p.nazwa + "&nbsp; "; row2.Cells.Add(c5);
            TableCell c6 = new TableCell(); c6.Text = "&nbsp; " + p.ilosc + "&nbsp; "; row2.Cells.Add(c6);
            TableCell c7 = new TableCell(); c7.Text = "&nbsp; " + p.cena + "&nbsp; PLN &nbsp;"; row2.Cells.Add(c7);
            //TableCell c8 = new TableCell(); c8.Text = "&nbsp; " + p.nazwa + "&nbsp; "; row2.Cells.Add(c8);
            TableCell c8 = new TableCell(); c8.Text = "&nbsp; <a href=Koszyk.aspx?action=del&product=" + p.productID + "> - </a> <a href=Koszyk.aspx?action=add&product=" + p.productID + "> + </a> <a href=Koszyk.aspx?action=remove&product=" + p.productID + "> x </a>";
            row2.Cells.Add(c8);
            T.Rows.Add(row2);//dodajem wiersz do tabeli
            }

            //FOOTER
            //Stopka
            TableRow r3 = new TableRow();
            TableCell c81 = new TableCell(); c81.Text = "Suma &nbsp;" + this.CalkowitaWartosc()+"&nbsp; PLN"; r3.Cells.Add(c81);
            TableCell c82 = new TableCell(); c82.Text = "<a href=Koszyk.aspx?action=clear_all> WYCZYSC KOSZYK </a>"; r3.Cells.Add(c82);
            T.Rows.Add(r3);
            return 0;
         
        }//koniec metody ShowBucket

        public int IlePozycji()
        {

                return (Orders.Count);

            

            //return (Orders.Count); //Metoda Count jest metodą kolekcji Hashtable
            //Count - zwraca liczbę elementów w całej kolekcji Hashtable
        }//koniec metody IlePozycji()



        public int ZlozZamowienie(String User_ID, String CzasZamawiajacego, String imieZamawiajacego)
        {
            int kile = 0;
            if (this.IlePozycji() > 0) //zapisz w bazie danych zamówienie
            {
                OleDbConnection Polaczenie = new OleDbConnection();
                Polaczenie.ConnectionString = "Provider=Microsoft.JET.OLEDB.4.0;data source=|DataDirectory|\\sklep.mdb";
                Polaczenie.Open();
                IEnumerator pozycja = Orders.Values.GetEnumerator();

                //SELECT MAX(Identyfikator) FROM [obsluga]


                OleDbCommand polecenieSQL4 = new OleDbCommand("SELECT TOP 1 Identyfikator FROM obsluga ORDER BY Identyfikator DESC; ", Polaczenie);
                OleDbDataReader DostepDoDanych = polecenieSQL4.ExecuteReader();
                if (DostepDoDanych.HasRows == true) //HasRows
                {

                    DostepDoDanych.Read();
                    String IdentyfikatorMoj = DostepDoDanych["Identyfikator"].ToString();
                }
                //SELECT MAX(Identyfikator) FROM [obsluga]


                while(pozycja.MoveNext())
                {


                    PozycjaZamowienia p = ((PozycjaZamowienia)pozycja.Current);
                    OleDbCommand polecenieSQL = new OleDbCommand("INSERT INTO [zamowienie]([userID],[produktID],[ilosc],[czas],[login]) VALUES (" + User_ID + "," + p.productID + "," + p.ilosc + ", '" + CzasZamawiajacego + "' , '" + imieZamawiajacego + "' )", Polaczenie);
                    polecenieSQL.ExecuteNonQuery();

                    //SELECT MAX(zamowienieID) FROM [zamowienia]


                    OleDbCommand polecenieSQL6 = new OleDbCommand("SELECT TOP 1 zamowienieID FROM zamowienie ORDER BY zamowienieID DESC; ", Polaczenie);
                    OleDbDataReader DostepDoDanych1 = polecenieSQL6.ExecuteReader();
                    if (DostepDoDanych1.HasRows == true) //HasRows
                    {

                        DostepDoDanych1.Read();
                        String zamowienieIDmoje = DostepDoDanych1["zamowienieID"].ToString();
                    }
                    //SELECT MAX(zamowienieID) FROM [obsluga]

                    OleDbCommand polecenieSQL2 = new OleDbCommand("INSERT INTO [obsluga]([nr_zamowienia],[kto],[czas],[elementy],[zaplacono],[wyslano]) VALUES (" + DostepDoDanych["Identyfikator"].ToString() + ", '" + imieZamawiajacego + "' ,'" + CzasZamawiajacego + "'," + p.productID + ",'nie', 'nie'" + ")", Polaczenie);
                    polecenieSQL2.ExecuteNonQuery();

                    
                    
                    kile++;
                }
                Polaczenie.Close();
            }
            return kile;
        }//koniec metody ZlozZamowienie;



    }

    }//koniec


