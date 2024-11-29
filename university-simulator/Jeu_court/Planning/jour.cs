using System;
using Godot;

public class Jour
{
    // Champ privé statique pour stocker l'instance unique
    private static Jour _instance;

    // Propriétés privées
    private string nom;
    private int nb = 1;

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

    // Méthodes pour accéder et modifier les propriétés
    public void SetNom(string nom)
    {
        this.nom = nom;
    }

    public void SetJour(int j)
    {
        this.nb = j;
    }

    public string GetNom()
    {
        return this.nom;
    }

    public int GetJour()
    {
        return this.nb;
    }
}