using Godot;
using System;

public partial class coce_i_menu : Control
{
	// variable qui serve pour changer image music
	private Button button;
	private Sprite2D sprite;
	bool etat_son = true;
	
	
	public override void _Ready()
	{
	
		// Récupérer le bouton contenant le Sprite2D
		button = GetNode<Button>("b_son"); // Chemin du bouton dans ta scène
		sprite = button.GetNode<Sprite2D>("Music");
	}
	
	
	public void _on_b_court_pressed(){
		GetTree().ChangeSceneToFile("res://Jeu_court/jeu_court.tscn");
	}

	
	public void _on_b_long_pressed(){
		// pas encore coder
	}
	
	public void _on_b_quittez_pressed(){
		GetTree().Quit();
	}
	
	
		/// <summary>
		/// cette fonction coupe/active le son du jeu.
		/// En fonction de l'etat du son image change.
		/// </summary>
	public void _on_b_son_pressed()
	{
		GD.Print("Button pressed");  // Vérification que la fonction est appelée

		if (etat_son)
		{
			etat_son = false;
			GD.Print("Turning sound off");
		
			var newTexture = (Texture2D)GD.Load("res://asset/icons/PNG/White/1x/musicOff.png");

			sprite.Texture = newTexture;
			GetNode<AudioStreamPlayer>("AudioStreamPlayer").Stop();
		
		}
		else{
			etat_son = true;
			GD.Print("Turning sound on");

			var newTexture = (Texture2D)GD.Load("res://asset/icons/PNG/White/1x/musicOn.png");

			sprite.Texture = newTexture;
			AudioStreamPlayer soundPlayer = GetNode<AudioStreamPlayer>("AudioStreamPlayer");
			soundPlayer.Play();
			
	}
}
	
}
