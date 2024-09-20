using Godot;
using System;

public partial class coce_i_menu : Control
{
	
	public void _on_b_court_pressed(){
		GetTree().ChangeSceneToFile("res://Jeu_court/jeu_court.tscn");
	}

	
	public void _on_b_long_pressed(){
		// pas encore coder
	}
	
	public void _on_b_quittez_pressed(){
		GetTree().Quit();
	}
	
	
}
