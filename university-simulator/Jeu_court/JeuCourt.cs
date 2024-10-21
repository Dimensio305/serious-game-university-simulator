using Godot;
using System;

public partial class JeuCourt : Node2D
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}
	
	int barre= 100;
	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		var leLabel = GetNodeOrNull<Label>("JaugeValeur");
		var Laboite = GetNodeOrNull<TextureRect>("JaugeTexture");
		var BoiteBarre = Laboite.GetNodeOrNull<BoxContainer>("ConteneurJauge");
		var Barre1 = BoiteBarre.GetNodeOrNull<ProgressBar>("JaugeProg");
		leLabel.Text = Barre1.Value.ToString();
	if (Input.IsActionPressed("AnswerRight"))
	{
		Barre1.Value++;
	}else if(Input.IsActionPressed("AnswerLeft")){
		Barre1.Value--;
	}
	}
}
