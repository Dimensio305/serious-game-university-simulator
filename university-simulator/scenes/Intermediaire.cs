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

    // Rendre rdvfin statique pour un accès global
    private static List<Rendezvous> rdvfin = new List<Rendezvous>();

    private List<Rendezvous> rdvdebut = new List<Rendezvous>();

    public override void _Ready()
    {
        _target1 = GetNode<TextureRect>("case_gauche");
        _target2 = GetNode<TextureRect>("case_droite");
        message = GetNode<TextEdit>("message");

        ConnectGuiInputToChildren(_target1);
        ConnectGuiInputToChildren(_target2);

        for (int nbrdv = 0; nbrdv < 6; nbrdv++)
        {
            rdvdebut.Add(Rendezvous.GenererRendezVousAleatoire(nbrdv));
        }

        int i = 0;
        foreach (Node child in _target1.GetChildren())
        {
            if (child is TextEdit textEdit)
            {
                textEdit.Text = rdvdebut[i].ToString();
                i++;
            }
        }
    }

    // Rendre la méthode getlistrdv statique
    public static List<Rendezvous> GetRdvFin()
    {
        return rdvfin;
    }

    private void ConnectGuiInputToChildren(TextureRect target)
    {
        foreach (Node child in target.GetChildren())
        {
            if (child is TextEdit textEdit)
            {
                textEdit.Connect("gui_input", Callable.From((InputEvent inputEvent) => OnGuiInput(inputEvent, textEdit)));
            }
        }
    }

    private void OnGuiInput(InputEvent inputEvent, TextEdit clickedTextEdit)
    {
        if (inputEvent is InputEventMouseButton mouseEvent && mouseEvent.Pressed && mouseEvent.ButtonIndex == MouseButton.Left)
        {
            TextureRect destination = clickedTextEdit.GetParent() == _target1 ? _target2 : _target1;
            MoveTextEditToTarget(clickedTextEdit, destination);
        }
    }

    private void MoveTextEditToTarget(TextEdit textEdit, TextureRect target)
    {
        List<Rendezvous> sourceList = textEdit.GetParent() == _target1 ? rdvdebut : rdvfin;
        List<Rendezvous> targetList = target == _target1 ? rdvdebut : rdvfin;

        int id;
        if (int.TryParse(textEdit.Name, out id))
        {
            Rendezvous rendezvous = sourceList.Find(rdv => rdv.getid() == id);
            if (rendezvous != null)
            {
                sourceList.Remove(rendezvous);
                targetList.Add(rendezvous);
            }
        }

        textEdit.GetParent().RemoveChild(textEdit);
        target.AddChild(textEdit);
        ReorganizeChildrenInColumn(target);
    }

    private void ReorganizeChildrenInColumn(TextureRect target)
    {
        float yOffset = 10;
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
        int textEditCount = 0;
        foreach (Node child in _target2.GetChildren())
        {
            if (child is TextEdit)
            {
                textEditCount++;
            }
        }

        if (textEditCount == 4)
        {
            message.Text = "Les rendez-vous sont bien pris en compte.";
            message.Visible = true;

            await Task.Delay(3000);

            GetTree().ChangeSceneToFile("res://Jeu_court/jeu_court.tscn");
        }
        else
        {
            message.Visible = true;
            message.Text = "Il faut choisir 4 rendez-vous.";
            await Task.Delay(3000);
            message.Visible = false;
        }
    }
}
