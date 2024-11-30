using Godot;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

public partial class JeuCourt : Node2D
{
	private TextEdit _textEdit;
	private bool inQuestion = false;
	private bool formationvisible = false;
	private bool formaRepondu = true;
	private bool agendavisible = false;
	private bool projetvisible = false;

	private List<Projet> projets;
	private List<Formation> forma;
	private Agenda agenda;

	private TextEdit texteditagenda; // Affichage de l'agenda
	private TextEdit texteditforma; // Affichage des FORMATION
	private TextEdit proj;
	private TextEdit r2;
	private TextEdit r1;
	private AnimatedSprite2D anim;

	private Panel panel;
	private Question q = new Question();

	public override void _Ready()
	{
		_textEdit = GetNode<TextEdit>("TextEdit");
		_textEdit.Visible = false;

		panel = GetNode<Panel>("panel");
		texteditagenda = GetNode<TextEdit>("TextEdit2");

		texteditforma = GetNode<TextEdit>("panel/TextEdit3");
		proj = GetNode<TextEdit>("proj");
		r1 = GetNode<TextEdit>("r1");
		r2 = GetNode<TextEdit>("r2");
		anim = GetNode<AnimatedSprite2D>("AnimatedSprite2D");

		// Générer des projets et rendez-vous aléatoires
		projets = Projet.GenererProjetsAleatoires();
		agenda = new Agenda();
		forma = new List<Formation>();
		GenererForma();

	}

	public override void _Process(double delta)
	{
		var Jauge1 = GetNodeOrNull<Jauge>("Jauge1");
		var Jauge2 = GetNodeOrNull<Jauge>("Jauge2");
		var Jauge3 = GetNodeOrNull<Jauge>("Jauge3");
		var Jauge4 = GetNodeOrNull<Jauge>("Jauge4");

		if (Input.IsActionJustPressed("temp") && !formationvisible && !agendavisible && !projetvisible)
		{
			inQuestion = true;
		}

		if (inQuestion)
		{
			var result = GérerQuestion();
			//gerereponse(Jauge1, Jauge2, Jauge3, Jauge4 , result.RDV);
			gerereponse(Jauge1, Jauge2, Jauge3, Jauge4 );
		}

		if (Input.IsActionJustPressed("agenda"))
		{
			rendrevisibleagenda();
		}

		if (Input.IsActionJustPressed("formation"))
		{
			rendrevisibleformation();
		}
		if (Input.IsActionJustPressed("projet"))
		{
			rendrevisibleprojet();
		}

		if (Input.IsActionPressed("fermer"))
		{
			verifieravantdefermer();
		}
	}

	private async Task<(Formation FORMA, Projet PROJ)> GérerQuestion()
	{
		
		Formation forma2;
		if(formaRepondu){
 			forma2 = Formation.genereformation();
		}else{
			forma2 = null;
		}
		Projet projet = Projet.GenererUnProjet();
		

		if (Input.IsActionJustPressed("Question")&&!projetvisible &&!formationvisible &&!agendavisible)
		{
			anim.Visible=true;
            await ToSignal(GetTree().CreateTimer(2.0f), "timeout");
			affichage.EcrireTexte(_textEdit, q.getquestion());
			affichage.EcrireTexte(r1, q.reponse1());
			affichage.EcrireTexte(r2, q.reponse2());
		}


		if (q.getnumquestion()%3 ==0 && q.getnumquestion() != 0 && Input.IsActionJustPressed("Question")&&!projetvisible &&!formationvisible &&!agendavisible){
			affichage.EcrireTexte(_textEdit,forma2.ToString());
			affichage.EcrireTexte(r1, "accepter la formation");
			affichage.EcrireTexte(r2, "refuser la formation");
		}

		if (q.getnumquestion()%5 ==0 && q.getnumquestion() != 0 && Input.IsActionJustPressed("Question")&&!projetvisible &&!formationvisible &&!agendavisible){
			affichage.EcrireTexte(_textEdit,projet.ToString());
			affichage.EcrireTexte(r1, "accepter le projet");
			affichage.EcrireTexte(r2, "refuser le projet");

		}

		return(forma2,projet) ;
	

	}

	private void MettreÀJourJauges(Jauge Jauge1, Jauge Jauge2, Jauge Jauge3, Jauge Jauge4, Func<string, int> getValeur)
	{
		Jauge1.Modif(getValeur("j1"));
		Jauge2.Modif(getValeur("j2"));
		Jauge3.Modif(getValeur("j3"));
		Jauge4.Modif(getValeur("j4"));
	}





	// Méthode pour cacher tous les TextEdit
	private void CacherTousLesTextEdits()
	{
		_textEdit.Visible = false;
		texteditagenda.Visible = false;
		texteditforma.Visible = false;
		r1.Visible = false;
		r2.Visible = false;
		proj.Visible = false;
		panel.Visible = false;

		formationvisible = false;
		agendavisible = false;
		projetvisible = false;
	}


	private void verifieravantdefermer()
	{
		if (_textEdit.Visible)
		{
			_textEdit.Visible = false;

			r1.Visible = false;
			r2.Visible = false;
		}
		if (formationvisible)
		{
			panel.Visible = false;
			texteditforma.Visible = false;
			formationvisible = false;
		}
		if (agendavisible)
		{
			texteditagenda.Visible = false;
			agendavisible = false;
		}
		if (projetvisible)
		{
			projetvisible = false;
			proj.Visible = false;
		}
	}

	private void rendrevisibleformation()
	{
		if (!_textEdit.Visible && !agendavisible && !projetvisible)
		{
		   

			affichage.AfficherFormations(forma, texteditforma, panel);
			panel.Visible = true;
			texteditforma.Visible = true; // Afficher les projets
			formationvisible = true;
		}
	}

	private void rendrevisibleprojet()
	{
		if (!_textEdit.Visible && !agendavisible && !formationvisible)
		{
			

			affichage.AfficherProjets(projets, proj);
			proj.Visible = true; // Afficher les projets
			projetvisible= true;
		}
	}

	private void rendrevisibleagenda()
	{
		if (!_textEdit.Visible && !formationvisible && !projetvisible)
		{
			
			affichage.AfficherAgenda(agenda.GetRendezVous(), texteditagenda);
			texteditagenda.Visible = true; // Afficher l'agenda
			agendavisible = true;
		}
	}

	private void GenererForma()
	{
		for (int i = 0; i < 5; i++)
		{
			forma.Add(Formation.genereformation());
		}
	}

	public void gerereponse(Jauge J1, Jauge J2, Jauge J3, Jauge J4)
{
	
	if (q.getnumquestion() % 2 == 0 && q.getnumquestion() != 0) 
	{// question de Formation
		if (Input.IsActionJustPressed("AnswerRight") && !projetvisible && !formationvisible && !agendavisible)
		{
			formaRepondu =true;
			inQuestion = false;
			q.question_suivante(); // Passer à la question suivante
			GD.Print("Action Formation droite");
		}
		else if (Input.IsActionJustPressed("AnswerLeft") && !projetvisible && !formationvisible && !agendavisible)
		{
			formaRepondu =true;
			inQuestion = false;
			q.question_suivante(); // Passer à la question suivante
			GD.Print("Action Formation gauche");
		}
	}


	else // Pas une question de rendez-vous ou de Formation
	{
		if (Input.IsActionJustPressed("AnswerLeft") && !projetvisible && !formationvisible && !agendavisible)
		{
			MettreÀJourJauges(J1, J2, J3, J4, q.getvaleur1); // Mettre à jour les jauges
			inQuestion = false;
			q.question_suivante(); // Passer à la question suivante
		}
		else if (Input.IsActionJustPressed("AnswerRight") && !projetvisible && !formationvisible && !agendavisible)
		{
			MettreÀJourJauges(J1, J2, J3, J4, q.getvaleur2); // Mettre à jour les jauges
			inQuestion = false;
			q.question_suivante(); // Passer à la question suivante
		}
	}
	formaRepondu =false;
}


}
