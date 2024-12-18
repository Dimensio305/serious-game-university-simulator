using Godot;
using System;

public partial class Tuto : Node2D
{
	private TextureRect fonddirective;
	private TextureRect fondquestion;
	private TextureRect fondreponsegauche;
	private TextureRect fondreponsedroite;
	private TextureRect personnage;

	private RichTextLabel labelordi;
	private RichTextLabel labelquestion;
	private RichTextLabel labelreponsegauche;
	private RichTextLabel labelreponsedroite;
	private RichTextLabel labeldirective;
	
	public override void _Ready()
	{

		fonddirective=GetNodeOrNull<TextureRect>("imagedirective");
		fondquestion=GetNodeOrNull<TextureRect>("fondquestion");
		fondreponsegauche=GetNodeOrNull<TextureRect>("Imagerepgauche");
		fondreponsedroite=GetNodeOrNull<TextureRect>("Imagerepdroite");
		personnage=GetNodeOrNull<TextureRect>("TextureRect2");
		labelordi=GetNodeOrNull<RichTextLabel>("textlabelordi");
		labelquestion=GetNodeOrNull<RichTextLabel>("fondquestion/textquestion");
		labelreponsegauche=GetNodeOrNull<RichTextLabel>("Imagerepgauche/reponsegauche");
		labelreponsedroite=GetNodeOrNull<RichTextLabel>("Imagerepdroite/reponsedroite");
		labeldirective=GetNodeOrNull<RichTextLabel>("imagedirective/textlabedirective");

	}

	
	public override void _Process(double delta)
	{
	}
}
