using Godot;
using System;

public partial class JeuCourt : Node2D
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}
		// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		var Jauge1 = GetNodeOrNull<Jauge>("Jauge1");
		var Jauge2 = GetNodeOrNull<Jauge>("Jauge2");

	if (Input.IsActionPressed("AnswerRight"))
	{
		Random rng = new Random();
		Jauge1.Modif(1);
	}else if(Input.IsActionPressed("AnswerLeft")){
		Jauge1.Modif(-1);
	}
	if (Input.IsActionPressed("AnswerA"))
	{
		Random rng = new Random();
		Jauge2.Modif(1);
	}else if(Input.IsActionPressed("AnswerB")){
		Jauge2.Modif(-1);
	}
	}
}
