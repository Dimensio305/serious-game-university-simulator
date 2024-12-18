using Godot;
using System;
using System.Collections.Generic;

/// <summary>
/// Classe transition : Gère le changement de scène en fonction du jour actuel.
/// </summary>
public partial class transition : Node2D
{
    /// <summary>
    /// Méthode _Ready : Appelée lorsque le nœud est prêt.
    /// Elle charge les textures, gère la transition entre les scènes 
    /// et applique les actions en fonction du jour actuel.
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

        // Récupère le jour actuel via une instance de la classe Jour.
        int jourActuel = Jour.Instance.GetJour();
        
        // Vérifie si le jour actuel est valide et compris dans les limites de la liste.
        if (jourActuel < 0 || jourActuel >= j.Count)
        {
            GD.PrintErr("Jour hors des limites ! Valeur : " + jourActuel);
            return;
        }

        // Charge la texture correspondant au jour actuel et l'applique au nœud TextureRect.
        TextureRect fond = GetNode<TextureRect>("TextureRect");
        fond.Texture = GD.Load<Texture2D>(j[jourActuel]);

        // Attend une seconde avant de procéder à la transition vers la prochaine scène.
        await ToSignal(GetTree().CreateTimer(1), "timeout");

        // Chemin de la prochaine scène.
        string nextScene = "res://scenes/intermediaire.tscn";

        // Vérifie si la scène suivante existe avant d'effectuer la transition.
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
