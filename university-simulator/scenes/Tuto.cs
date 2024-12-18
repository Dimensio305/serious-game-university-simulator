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

	bool decouvrequestion = false;
	bool decouvreetat = false;
	bool decouvreagenda = false;
	bool decouvrereponsegauche = false;
	bool decouvrereponsedroite = false;

	bool etape1 = false;
	bool etape2 = false;
	bool etape3 = false;
	bool etape4 = false;
	bool inQuestion  = false; 


	
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

	private async void messadedepart(){

		string message = "Coucou binvenue dans university simulator";
		fonddirective.Visible=true;
		labeldirective.Text = $"[center][b][color = black]{message}[/color][/b][/center]";
		await ToSignal(GetTree().CreateTimer(0.5),"timeout");
		message += "\n La cle de la reussite est de conserver un equilibre entre tes differentes ressource";
		labeldirective.Text = $"[center][b][color = black]{message}[/color][/b][/center]";
		await ToSignal(GetTree().CreateTimer(1),"timeout");
		message = "Commencons par un tuto rapide pour comprendre les touches";
		labeldirective.Text = $"[center][b][color = black]{message}[/color][/b][/center]";
		etape1=true;
	}

	private void afficherquestion(){
		if (etape1){
			fonddirective.Visible=false;
			string message = " Ici vont s'afficher les diffrente question des composante que vous aller rencontrer"; 
			labeldirective.Text = $"[center][b][color = black]{message}[/color][/b][/center]";
		}
	}


}
