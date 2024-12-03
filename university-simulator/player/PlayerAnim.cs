using Godot;
using System;

public partial class PlayerAnim : AnimatedSprite2D
{
    private float speed = 100f; // Vitesse du déplacement
    private bool isMoving = false; // Indicateur de déplacement
    private Vector2 targetPosition = new Vector2(766, 402); // Point cible
    private Vector2 originalScale; // Échelle d'origine
    private float distanceTraveled = 0f; // Distance parcourue par le personnage

    Random rand = new Random();
    public override void _Ready()
    {
        // Sauvegarder l'échelle initiale du personnage
        originalScale = Scale;
    }

    public override void _Process(double delta)
    {
        if (isMoving)
        {
            // Déplacement vers la cible
            float distance = Position.DistanceTo(targetPosition);
            Position = Position.MoveToward(targetPosition, (float)(speed * delta));
            
            // Calculer la distance parcourue depuis le début du mouvement
            distanceTraveled += (float)(speed * delta);
            
            // Calculer le facteur de croissance basé sur la distance parcourue
            float growthFactor = 2 + (distanceTraveled / 400f);  // Ajustez 500f pour augmenter ou diminuer la vitesse de croissance
            Scale = originalScale * growthFactor;

            // Vérifier si le personnage est arrivé à la cible
            if (distance < 1.0f)
            {
                StopMovement();
            }
        }
    }

    public override void _Notification(int what)
    {
        // Vérifier si la visibilité a changé
        if (what == NotificationVisibilityChanged)
        {
            if (Visible)
            {
                StartMovement();
            }
            else
            {
                StopMovement();
            }
        }
    }

    private void StartMovement()
    {
        isMoving = true;

        string nb= rand.Next().ToString();

       
        // Lancer l'animation de marche
        if (SpriteFrames.HasAnimation("walk"))
        {
            Play("walk");  // Assurez-vous que l'animation "walk" existe dans le panneau Frames
        }
        else
        {
            GD.Print("Erreur : L'animation 'walk' n'est pas définie !");
        }
    }

    private void StopMovement()
    {
        isMoving = false;
        Stop();  // Arrêter l'animation
        GD.Print("Le personnage a atteint la position cible !");
    }
}
