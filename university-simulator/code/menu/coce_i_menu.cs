using Godot;
using System;

/// <summary>
/// Cette class est liée a la scene i_menu
/// Elle gere le changement des scenes
/// </summary>
public partial class coce_i_menu : Control
{
	
	private Button button;
	private Sprite2D sprite;
	bool etat_son = true;
	

	/// <summary>
	/// Methode Ready : Appelée une fois la scene chargée
	/// </summary>
	public override void _Ready()
	{
	
		// Récupérer le bouton contenant le Sprite2D
		button = GetNode<Button>("b_son"); // Chemin du bouton dans ta scène
		sprite = button.GetNode<Sprite2D>("Music");
	}
	
	
	/// <summary>
	///	Methode _on_b_court_pressed : Change la scene pour la version courte du jeu
	/// </summary>
	public void _on_b_court_pressed(){
		
		GetTree().ChangeSceneToFile("res://scenes/tuto.tscn");
	}
	
	/// <summary>
	///Methode _on_b_quittez_pressed Bouton permettant de quitter le jeu 
	/// </summary>
	public void _on_b_quittez_pressed(){
		GestionDb.Instance.Supprimer();
		GetTree().Quit();
	}
	
	
		/// <summary>
		/// Methode _on_b_son_pressed :cette fonction coupe/active le son du jeu.
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
