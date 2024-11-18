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
    
    public Formation ( string nom , int effectif , int eleve , int budget , string option){
        Nom = nom ;
        Effectif = effectif;
        Eleve = eleve;
        Budget = budget ;
        Option = option ;
    }

    static public Formation genereformation(){
        int index = 1 ;
        string n = GestionDb.Instance.ExecuteRequete("select nom from Formation where idformation = " + index.ToString() +";" ) ;
        int e = Convert.ToInt32(GestionDb.Instance.ExecuteRequete("select effectif from Formation where idformation  = " + index.ToString() +";" )) ;
        int el =Convert.ToInt32(GestionDb.Instance.ExecuteRequete("select eleve from Formation where idformation  = " +  index.ToString() + ";" )) ;
        int b = Convert.ToInt32(GestionDb.Instance.ExecuteRequete("select budget from Formation where idformation = " + index.ToString() +";" )) ;
        string o = GestionDb.Instance.ExecuteRequete("select opt from Formation where idformation = " + index.ToString() +";" ) ;
        index ++;
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
