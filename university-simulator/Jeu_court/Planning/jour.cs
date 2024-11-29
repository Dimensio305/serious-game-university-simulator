using System;
using System.Data.SqlClient;
using Godot;

public class Jour{
    private String nom ; 
    private int nb;

    public Jour(){

    }

    public void setnom(string nom){
        this.nom = nom;
    }

    public void setjour(int j){
        this.nb = j;
    }
    public string getnom(){
        return this.nom;
    }
    public int getjour(){
        return this.nb;
    }
}