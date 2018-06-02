using System;

public class Punkt
{
	private double modul;
	private double sinalfa;
	

	//tworze konstruktor
	public Punkt()
	{
		UstawWspolrzedne(800,600);
	}
	
	//tworze konstruktor z dwoma argumentami (przeci¹¿anie konstruktora)
	public Punkt(int x, int y)
	{
		UstawWspolrzedne(x,y);
	}
	

	
	//metody klasy Punkt
	
	//setter
	public void UstawWspolrzedne(int wspX, int wspY)
	{
		modul = Math.Sqrt(wspX*wspX+wspY*wspY);
		sinalfa = wspY/modul;
	}
	
	//getter
	public Punkt PobierzWspolrzedne()
	{
	Punkt punkt = new Punkt();
	punkt.sinalfa = sinalfa;
	punkt.modul = modul;
	return punkt;
	}
	
	//setter
	public void UstawX(int wspX)
	{
	UstawWspolrzedne(wspX, PobierzY());
	}
	
	//setter
	public void UstawY(int wspY)
	{
	UstawWspolrzedne(PobierzX(), wspY);
	}
	
	//getter
	public int PobierzX()
	{
	double x = modul* Math.Sqrt(1-sinalfa*sinalfa);
	return (int)x;
	}
	
	//getter
	public int PobierzY()
	{
	double y = modul * sinalfa;
	return (int) y;
	}
}