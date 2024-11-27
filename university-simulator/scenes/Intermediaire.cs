using Godot;
using System;

public partial class Intermediaire : Node2D
{
    private Control _draggedNode = null;
    private Vector2 _offset;
    private TextureRect _target1;
    private TextureRect _target2;
    private AnimationPlayer _animationPlayer;

    public override void _Ready()
    {
        _target1 = GetNode<TextureRect>("case_gauhe");
        _target2 = GetNode<TextureRect>("case_droite");
        _animationPlayer = GetNode<AnimationPlayer>("AnimationPlayer");

        foreach (TextEdit textEdit in _target1.GetChildren())
        {
            textEdit.Connect("gui_input", this, nameof(OnGuiInput()));
        }
    }

    private void OnGuiInput(InputEvent inputEvent)
    {
        if (inputEvent is InputEventMouseButton mouseEvent)
        {
            if (mouseEvent.Pressed && mouseEvent.ButtonIndex == (int)ButtonList.Left)
            {
                _draggedNode = (Control)GetTree().GetCurrentScene().GetNodeAtPosition(GetViewport().GetMousePosition());
                if (_draggedNode != null)
                {
                    _offset = _draggedNode.GlobalPosition - GetGlobalMousePosition();
                    _draggedNode.SetProcess(true);
                }
            }
            else if (!mouseEvent.Pressed && _draggedNode != null)
            {
                _draggedNode.SetProcess(false);

                if (_target2.GetGlobalRect().HasPoint(GetGlobalMousePosition()))
                {
                    AnimateMove(_draggedNode, _target2);
                }
                else if (_target1.GetGlobalRect().HasPoint(GetGlobalMousePosition()))
                {
                    AnimateMove(_draggedNode, _target1);
                }
                else
                {
                    AnimateMove(_draggedNode, (TextureRect)_draggedNode.GetParent());
                }

                _draggedNode = null;
            }
        }
    }

    private void AnimateMove(Control node, TextureRect newParent)
    {
        Node parentNode = newParent.GetParent();
        if (parentNode is Node2D node2DParent)
        {
            Vector2 finalPosition = node2DParent.ToLocal(GetGlobalMousePosition()) + newParent.GlobalPosition - _offset;

            string animationName = "MoveTextEdit";

            // Créer une nouvelle animation
            Animation animation = new Animation();
            
            // Ajouter une piste à l'animation
            int trackIndex = animation.AddTrack(Animation.TrackType.Value);
            animation.TrackSetPath(trackIndex, $"{node.GetPath()}:global_position");
            animation.TrackInsertKey(trackIndex, 0.0f, node.GlobalPosition);
            animation.TrackInsertKey(trackIndex, 0.5f, finalPosition);

            // Jouer l'animation avec le nom donné
            _animationPlayer.Play(animationName);

            // Déclencher l'animation avec l'appel du signal "animation_finished"
            _animationPlayer.Connect("animation_finished", this, nameof(OnAnimationFinished), new Godot.Collections.Array { node, newParent });
        }
    }





    private void OnAnimationFinished(string animName, Godot.Collections.Array args)
    {
        Control node = (Control)args[0];
        TextureRect newParent = (TextureRect)args[1];

        // Vérifier si le parent de l'élément a changé
        if (node.GetParent() != newParent)
        {
            node.GetParent().RemoveChild(node);
            newParent.AddChild(node);
            node.Position = node.GlobalPosition - newParent.GlobalPosition;
        }

        // Déconnecter le signal une fois l'animation terminée
        _animationPlayer.Disconnect("animation_finished", new Callable(this, nameof(OnAnimationFinished)));
    }

    public void _Process(float delta)
    {
        if (_draggedNode != null)
        {
            _draggedNode.GlobalPosition = GetGlobalMousePosition() + _offset;
        }
    }
}