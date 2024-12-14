using Godot;
using System;
using System.Collections.Generic;

/// <summary>
/// Classe gérant la transition entre les scènes en fonction du jour actuel.
/// </summary>
public partial class transition : Node2D
{
    /// <summary>
    /// Méthode appelée lorsque le nœud est prêt. 
    /// Gère le chargement des textures et la transition vers une nouvelle scène.
    /// </summary>
    public override async void _Ready()
    {
        
        // Liste des chemins des textures pour chaque jour.
        List<string> j = new List<string>
        {
            "res://asset/jour/1.png",
            "res://asset/jour/2.png",
            "res://asset/jour/3.png",
            "res://asset/jour/4.jpg",
            "res://asset/jour/5.png"
        };

    
        // Vérifie si le jour est dans les limites de la liste des textures.
        int jourActuel = Jour.Instance.GetJour();
        if (jourActuel < 0 || jourActuel > j.Count)
        {
            GD.PrintErr("Jour hors des limites ! Valeur : " + jourActuel);
            return;
        }

        
        // Charge la texture correspondante au jour actuel et l'applique au nœud TextureRect.
        TextureRect fond = GetNode<TextureRect>("TextureRect");
        fond.Texture = GD.Load<Texture2D>(j[jourActuel]);

       
        // Attend 1 seconde avant de passer à la prochaine scène.
        await ToSignal(GetTree().CreateTimer(1), "timeout");

   
        // Définit le chemin de la prochaine scène et vérifie son existence.
        // Si la scène existe, la transition est effectuée.
        string nextScene = "res://scenes/intermediaire.tscn";
        if (ResourceLoader.Exists(nextScene))
        {
            GetTree().ChangeSceneToFile(nextScene);
        }
        else
        {
            GD.PrintErr("La scène 'intermediaire.tscn' n'existe pas !");
        }
    }
}
