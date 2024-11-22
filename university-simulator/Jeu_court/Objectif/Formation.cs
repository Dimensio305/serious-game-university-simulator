using System;
using System.Collections.Generic;
using Godot;

public class Formation
{
	public string Nom { get; private set; }
	public string Option { get; private set; }
	public int Effectif { get; private set; }
	public int Eleve { get; private set; }
	public int Budget { get; private set; }
	public static int index =1 ; 
	
	public Formation ( string nom , int effectif , int eleve , int budget , string option){
		Nom = nom ;
		Effectif = effectif;
		Eleve = eleve;
		Budget = budget ;
		Option = option ;
	}

	private static int getindex(){
		return index;
	}

	private static void setindex(int value){
		index = value;
	}

	static public Formation genereformation(){
		int index = getindex();
		GD.Print("entrer dans genere forma");
		string n = GestionDb.Instance.ExecuteRequete("select nom from Formation where idformation = " + index.ToString() +";" ) ;
		GD.Print(n);
		int e = Convert.ToInt32(GestionDb.Instance.ExecuteRequete("select effectif from Formation where idformation  = " + index.ToString() +";" )) ;
		GD.Print(e);
		int el =Convert.ToInt32(GestionDb.Instance.ExecuteRequete("select eleve from Formation where idformation  = " +  index.ToString() + ";" )) ;
		GD.Print(el);
		int b = Convert.ToInt32(GestionDb.Instance.ExecuteRequete("select budget from Formation where idformation = " + index.ToString() +";" )) ;
		GD.Print(b);
		string o = GestionDb.Instance.ExecuteRequete("select Opt from Formation where idformation = " + index.ToString() +";" ) ;
		GD.Print(o);
		setindex(index+1);
		return new Formation (n , e , el , b , o ) ;
	}

	public override string ToString()
	{
	return $"Formation : {Nom}\n" +
		   $"Option : {Option}\n" +
		   $"Effectif : {Effectif}\n" +
		   $"Élèves : {Eleve}\n" +
		   $"Budget : {Budget:C}"; // Format monétaire pour le budget
	}
	


}
