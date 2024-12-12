using Godot;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Threading.Tasks;

public partial class JeuCourt : Node2D
{

	// gestion des questions 
	private TextEdit _textEdit;
	private bool inQuestion = false;
	private TextEdit r2;
	private TextEdit r1;
	private Question q = new Question();

	//gestion des formation 
	private List<Formation> forma;
	private TextEdit texteditforma;

	// gestion des agenda
	private Agenda agenda;
	private TextEdit texteditagenda;
	int nbrdv=0;

	// gestion de srdv physique 

	private bool inrdv = false; 
	private int aquellequestion = 0;

	//gestion des projets 
	private bool projetvisible = false;
	private List<Projet> projets;
	private TextEdit proj;

	//gestion de l'heure 

	private TextEdit horloge ;
	int heure = 08;
	int minute = 00;

	// a verifier 
	private Panel panel;
	int nbquestion = 0;
	
	
	// personnage 3d
	private SubViewport subViewport; // Le viewport pour rendre la scène 3D
    private AnimationPlayer animationPlayer;
	private TextureRect textureRectpersonnage;

	private TextEdit temporaire;
	private Jauge Jauge1 ; 
	private Jauge Jauge2 ;
	private Jauge Jauge3 ;
	private Jauge Jauge4 ;   



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
			

		// Générer des projets et rendez-vous aléatoires
		projets = Projet.GenererProjetsAleatoires();
		agenda = new Agenda();
		forma = new List<Formation>();
		GenererForma();

		// Gestion de l'heure
		horloge = GetNode<TextEdit>("Horloge/horloge");



		// personnage 
		// Récupérer les nœuds
        subViewport = GetNode<SubViewport>("SubViewport");
		Node scene3D = subViewport.GetChild(0);

        // Trouver l'AnimationPlayer dans la scène 3D
        animationPlayer = scene3D.GetNode<AnimationPlayer>("AnimationPlayer");
		textureRectpersonnage = GetNode<TextureRect>("personnage");

		temporaire = GetNode<TextEdit>("temp");

		Jauge1 = GetNodeOrNull<Jauge>("Jauge1");
		Jauge2 = GetNodeOrNull<Jauge>("Jauge2");
		Jauge3 = GetNodeOrNull<Jauge>("Jauge3");
		Jauge4 = GetNodeOrNull<Jauge>("Jauge4");


        attente();
		

	}

	public override void _Process(double delta)
	{
		



		if (inQuestion)
		{
			GérerQuestionAsync();
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


	/// <summary>
	/// 
	/// </summary>
	private async void GérerQuestionAsync()
	{
		
		
		

		if (Input.IsActionJustPressed("Question") && !projetvisible && !texteditforma.Visible && !texteditagenda.Visible)
		{
			
				textureRectpersonnage.Visible=true;
				animationPlayer.Play("mixamo_com");
				await ToSignal(GetTree().CreateTimer(2.6f), "timeout");
				affichage.EcrireTexte(_textEdit, q.getquestion(agenda.GetRendezVous()[nbrdv].getcomposante()));
				affichage.EcrireTexte(r1, q.reponse1());
				affichage.EcrireTexte(r2, q.reponse2());
			
		}

	// Sup fuckers <3

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
		if (texteditforma.Visible )
		{
			panel.Visible = false;
			texteditforma.Visible = false;
		}
		if (texteditagenda.Visible)
		{
			texteditagenda.Visible = false;
		}
		if (projetvisible)
		{
			projetvisible = false;
			proj.Visible = false;
		}
	}

	private void rendrevisibleformation()
	{
		if (!_textEdit.Visible && !texteditagenda.Visible && !projetvisible)
		{
		   

			affichage.AfficherFormations(forma, texteditforma, panel);
			panel.Visible = true;
			texteditforma.Visible = true; // Afficher les projets
		}
	}

	private void rendrevisibleprojet()
	{
		if (!_textEdit.Visible && !texteditagenda.Visible && !texteditforma.Visible)
		{
			

			affichage.AfficherProjets(projets, proj);
			proj.Visible = true; // Afficher les projets
			projetvisible= true;
		}
	}

	private void rendrevisibleagenda()
	{
		if (!_textEdit.Visible && !texteditforma.Visible  && !projetvisible)
		{
			
			affichage.AfficherAgenda(agenda.GetRendezVous(), texteditagenda);
			texteditagenda.Visible = true; // Afficher l'agenda
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
	
	
		if (Input.IsActionJustPressed("AnswerLeft") && !projetvisible && !texteditforma.Visible  && !texteditagenda.Visible &&_textEdit.Visible)
		{
			MettreÀJourJauges(J1, J2, J3, J4, q.getvaleur1); // Mettre à jour les jauges
			inQuestion = false;
			temporaire.Text="false";
			q.question_suivante(agenda.GetRendezVous()[nbrdv].getcomposante()); // Passer à la question suivante
			suiv();
			faireavancerletemps();
			attente();
			
			
		}
		else if (Input.IsActionJustPressed("AnswerRight") && !projetvisible && !texteditforma.Visible  && !texteditagenda.Visible &&_textEdit.Visible)
		{
			MettreÀJourJauges(J1, J2, J3, J4, q.getvaleur2); // Mettre à jour les jauges
			inQuestion = false;
			temporaire.Text="false";
			q.question_suivante(agenda.GetRendezVous()[nbrdv].getcomposante()); // Passer à la question suivante
			suiv();
			faireavancerletemps();
			attente();
			
		}
	
	}

	private async void suiv()
{
    if (nbquestion == 2) // Fin des questions du rendez-vous
    {
        nbquestion = 0;
        if (nbrdv == 3) // Tous les rendez-vous terminés
        {
            nbrdv = 0;
        }
        else
        {
            nbrdv++;
            await ToSignal(GetTree().CreateTimer(0.5f), "timeout");
            affichage.EcrireTexte(_textEdit, "La biz. Rendez-vous terminé.");
            r1.Visible = false;
            r2.Visible = false;
            textureRectpersonnage.Visible = false; // Fin de l'animation uniquement ici
            await ToSignal(GetTree().CreateTimer(1f), "timeout");
            CacherTousLesTextEdits();
        }
    }
    else
    {
        nbquestion++;
        await AfficherMessageIntermediaire(); // Affiche le message intermédiaire
        AfficherQuestionSuivante();
    }
}

private async void AfficherQuestionSuivante()
{
    await ToSignal(GetTree().CreateTimer(2f), "timeout"); // Délai avant la prochaine question
    affichage.EcrireTexte(_textEdit, q.getquestion(agenda.GetRendezVous()[nbrdv].getcomposante()));
	affichage.EcrireTexte(r1, q.reponse1());
	affichage.EcrireTexte(r2, q.reponse2());
	gerereponse(Jauge1, Jauge2, Jauge3, Jauge4 );
    r1.Visible = true;
    r2.Visible = true;
}

private async Task AfficherMessageIntermediaire()
{
    affichage.EcrireTexte(_textEdit, "Hummm... et je voulais aussi vous demander...");
    r1.Visible = false;
    r2.Visible = false;
    await ToSignal(GetTree().CreateTimer(1.5f), "timeout"); // Pause avant la question suivante
}


	private async void faireavancerletemps(){
		minute += 40;
		if (minute >= 60){
			minute -= 60;
			heure+=1;
		}
		affichage.EcrireTexte(horloge , "   "+heure.ToString("D2")+":"+minute.ToString("D2"));

		if (heure == 12){
			await ToSignal(GetTree().CreateTimer(1), "timeout"); // Pause d'une seconde
        heure = 14;
		affichage.EcrireTexte(horloge , "   "+heure.ToString("D2")+":"+minute.ToString("D2"));
		}

		if (heure >= 18 ){
			await ToSignal(GetTree().CreateTimer(0.5), "timeout");
			Jour.Instance.Joursuivant();
			GetTree().ChangeSceneToFile("res://intermediaire/affichage_jour.tscn");
		}
	}

	private async void attente(){
		await ToSignal(GetTree().CreateTimer(2),"timeout");
		inQuestion=true;
		temporaire.Text="true";
	}
	

}
