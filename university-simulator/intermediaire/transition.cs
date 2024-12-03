using Godot;
using System;
using System.Collections.Generic;

public partial class transition : Node2D
{
    public override async void _Ready()
    {
        // Liste des chemins de textures
        List<string> j = new List<string>
        {
            "res://asset/jour/1.png",
            "res://asset/jour/2.png",
            "res://asset/jour/3.png",
            "res://asset/jour/4.jpg",
            "res://asset/jour/5.png"
        };

        // Récupérer le jour actuel
        int jourActuel = Jour.Instance.GetJour();
        if (jourActuel < 0 || jourActuel > j.Count)
        {
            GD.PrintErr("Jour hors des limites ! Valeur : " + jourActuel);
            return;
        }

        // Charger et appliquer la texture
        TextureRect fond = GetNode<TextureRect>("TextureRect");
        fond.Texture = GD.Load<Texture2D>(j[jourActuel]);

        // Attendre 1 seconde
        await ToSignal(GetTree().CreateTimer(1), "timeout");

        // Vérifier et changer la scène
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
