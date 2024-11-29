using Godot;
using System;
using System.Collections.Generic;
using System.Runtime.ExceptionServices;
using System.Threading.Tasks;

public partial class Intermediaire : Node2D
{
    private TextureRect _target1;
    private TextureRect _target2;
     private TextEdit message; 

    List<Rendezvous> rdvdebut = new List<Rendezvous>() ;
    List<Rendezvous> rdvfin = new List<Rendezvous>();
    public override void _Ready()
    {
        _target1 = GetNode<TextureRect>("case_gauche");
        _target2 = GetNode<TextureRect>("case_droite");
        message = GetNode<TextEdit>("message");

        // Connecter les événements `gui_input` pour chaque `TextEdit` dans `_target1` et `_target2`.
        ConnectGuiInputToChildren(_target1);
        ConnectGuiInputToChildren(_target2);
        
        for(int nbrdv = 0 ; nbrdv <6 ; nbrdv++){
            rdvdebut.Add(Rendezvous.GenererRendezVousAleatoire(1,nbrdv));
        }

        int i = 0;
        foreach (Node child in _target1.GetChildren())
        {
        if (child is TextEdit textEdit)
        {
            // Faire quelque chose avec textEdit
            textEdit.Text=rdvdebut[i].ToString();
            i++;
        }
        }
    }

    private void ConnectGuiInputToChildren(TextureRect target)
    {
        foreach (Node child in target.GetChildren())
        {
            if (child is TextEdit textEdit)
            {
                // Passer la référence au nœud cliqué via un Callable personnalisé.
                textEdit.Connect("gui_input", Callable.From((InputEvent inputEvent) => OnGuiInput(inputEvent, textEdit)));
            }
        }
    }

    private void OnGuiInput(InputEvent inputEvent, TextEdit clickedTextEdit)
    {
        if (inputEvent is InputEventMouseButton mouseEvent && mouseEvent.Pressed && mouseEvent.ButtonIndex == MouseButton.Left)
        {
            // Déterminer la destination (autre `TextureRect`).
            TextureRect destination = clickedTextEdit.GetParent() == _target1 ? _target2 : _target1;

            // Déplacer la `TextEdit` vers la nouvelle `TextureRect`.
            MoveTextEditToTarget(clickedTextEdit, destination);
        }
    }

   private void MoveTextEditToTarget(TextEdit textEdit, TextureRect target)
{
    // Déterminer la liste source et la liste cible.
    List<Rendezvous> sourceList = textEdit.GetParent() == _target1 ? rdvdebut : rdvfin;
    List<Rendezvous> targetList = target == _target1 ? rdvdebut : rdvfin;

    // Récupérer l'ID du rendez-vous depuis le texte de la `TextEdit`.
    int id;
    if (int.TryParse(textEdit.Name, out id)) // Le texte est censé correspondre à l'ID.
    {
        // Rechercher le rendez-vous dans la liste source par ID.
        Rendezvous rendezvous = sourceList.Find(rdv => rdv.getid() == id);
        if (rendezvous != null)
        {
            // Déplacer le rendez-vous entre les listes.
            sourceList.Remove(rendezvous);
            targetList.Add(rendezvous);
        }
    }

    // Retirer de l'ancien parent.
    textEdit.GetParent().RemoveChild(textEdit);

    // Ajouter au nouveau parent.
    target.AddChild(textEdit);

    // Réorganiser les enfants pour les aligner en colonne.
    ReorganizeChildrenInColumn(target);

    // (Optionnel) Afficher les listes dans la console pour vérifier.
    GD.Print("rdvdebut: ", string.Join(", ", rdvdebut));
    GD.Print("rdvfin: ", string.Join(", ", rdvfin));
}

    private void ReorganizeChildrenInColumn(TextureRect target)
    {
        float yOffset = 10; // Espacement vertical entre les `TextEdit`.
        float currentY = 60;

        foreach (Node child in target.GetChildren())
        {
            if (child is Control control)
            {
                control.Position = new Vector2(80, currentY);
                currentY += control.Size.Y + yOffset;
            }
        }
    }

   public async void _on_valider_pressed()
    {
        // Vérifie le nombre d'enfants de type TextEdit dans case_droite
        int textEditCount = 0;
        foreach (Node child in _target2.GetChildren())
        {
            if (child is TextEdit)
            {
                textEditCount++;
            }
        }

        // Si le nombre est correct, afficher un message et attendre 3s avant de changer de scène
        if (textEditCount == 4)
        {
            message.Text = "Les rendez-vous sont bien pris en compte.";
            message.Visible=true;
            
            // Attendre 3 secondes
            await Task.Delay(3000);

            
            GetTree().ChangeSceneToFile("res://Jeu_court/jeu_court.tscn");
        }
        else
        {
            // Afficher un message d'erreur
            message.Visible=true;
            message.Text = "Il faut choisir 4 rendez-vous.";
            await Task.Delay(3000);
            message.Visible = false;

        }
    }
}
