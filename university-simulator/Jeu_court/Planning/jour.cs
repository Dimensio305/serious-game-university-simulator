using System;
using Godot;

public class Jour
{
    // Champ privé statique pour stocker l'instance unique
    private static Jour _instance;

    // Propriétés privées
  
    private int nb = 0;
    private string nom = "Lundi";

    // Constructeur privé pour empêcher la création d'instances externes
    private Jour() {}

    // Propriété statique pour accéder à l'instance unique
    public static Jour Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new Jour();
            }
            return _instance;
        }
    }

    
    private void setjour(int j)
    {
         
    
        this.nb = j;

        
        switch (j)
        {
            case 0:
                nom = "Lundi";
                break;
            case 1:
                nom = "Mardi";
                break;
            case 2:
                nom = "Mercredi";
                break;
            case 3:
                nom = "Jeudi";
                break;
            case 4:
                nom = "Vendredi";
                break;
            default:
                nom = "Invalide";
                break;
        }
    }

    public void Joursuivant(){
        if (nb == 5){
            setjour(0);
        }
        else{
            setjour(nb + 1);
        }
    }


    

    public int GetJour()
    {
        return this.nb;
    }

    public string GetNom(){
        return this.nom;
    }
}