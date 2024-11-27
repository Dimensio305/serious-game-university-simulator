using Godot;
using System;

public partial class Intermediaire : Node2D
{
    private TextureRect _target1;
    private TextureRect _target2;

    public override void _Ready()
    {
        _target1 = GetNode<TextureRect>("case_gauche");
        _target2 = GetNode<TextureRect>("case_droite");

        // Connecter les événements `gui_input` pour chaque `TextEdit` dans `_target1` et `_target2`.
        ConnectGuiInputToChildren(_target1);
        ConnectGuiInputToChildren(_target2);
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
        // Retirer de l'ancien parent.
        textEdit.GetParent().RemoveChild(textEdit);

        // Ajouter au nouveau parent.
        target.AddChild(textEdit);

        // Réorganiser les enfants pour les aligner en colonne.
        ReorganizeChildrenInColumn(target);
    }

    private void ReorganizeChildrenInColumn(TextureRect target)
    {
        float yOffset = 10; // Espacement vertical entre les `TextEdit`.
        float currentY = 0;

        foreach (Node child in target.GetChildren())
        {
            if (child is Control control)
            {
                control.Position = new Vector2(0, currentY);
                currentY += control.Size.Y + yOffset;
            }
        }
    }
}
