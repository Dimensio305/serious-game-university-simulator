using Godot;
using System;

public partial class JeuCourt : Node2D
{
	bool inQuestion = false;
	string stringQuestion;
	int idQuestion=0;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{	
		GestionDb.Instance.Contenue();
		GestionDb.Instance.ExecuteRequete("select * from Catpersonne;");
	}
		// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		var Jauge1 = GetNodeOrNull<Jauge>("Jauge1");
		var Jauge2 = GetNodeOrNull<Jauge>("Jauge2");
		var Jauge3 = GetNodeOrNull<Jauge>("Jauge3");
		var Jauge4 = GetNodeOrNull<Jauge>("Jauge4");

		if(inQuestion) {
			if (Input.IsActionPressed("AnswerRight")) {
				Jauge1.Modif(Int32.Parse(GestionDb.Instance.ExecuteRequete("select j1 from Reponse where idquestion ="+idQuestion+" and idreponse=2;")));
				Jauge2.Modif(Int32.Parse(GestionDb.Instance.ExecuteRequete("select j2 from Reponse where idquestion ="+idQuestion+" and idreponse=2;")));
				Jauge3.Modif(Int32.Parse(GestionDb.Instance.ExecuteRequete("select j3 from Reponse where idquestion ="+idQuestion+" and idreponse=2;")));
				Jauge4.Modif(Int32.Parse(GestionDb.Instance.ExecuteRequete("select j4 from Reponse where idquestion ="+idQuestion+" and idreponse=2;")));
				inQuestion=false;
		
			} else if(Input.IsActionPressed("AnswerLeft")) {
				Jauge1.Modif(Int32.Parse(GestionDb.Instance.ExecuteRequete("select j1 from Reponse where idquestion ="+idQuestion+" and idreponse=1;")));
				Jauge2.Modif(Int32.Parse(GestionDb.Instance.ExecuteRequete("select j2 from Reponse where idquestion ="+idQuestion+" and idreponse=1;")));
				Jauge3.Modif(Int32.Parse(GestionDb.Instance.ExecuteRequete("select j3 from Reponse where idquestion ="+idQuestion+" and idreponse=1;")));
				Jauge 4.Modif(Int32.Parse(GestionDb.Instance.ExecuteRequete("select j4 from Reponse where idquestion ="+idQuestion+" and idreponse=1;")));
				inQuestion=false;
			}
		}
		if (Input.IsActionPressed("Question"))
		{
			inQuestion= true;
			Random rdm = new Random();
			idQuestion = rdm.Next(1, 2); // crée un nombre aléatoire entre x et y-1
			stringQuestion = GestionDb.Instance.ExecuteRequete("select question from Question where id="+idQuestion+";");
		}
	}
}
