using Godot;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Threading.Tasks;

public partial class JeuCourt : Node2D
{
	private TextEdit _textEdit;
	private bool inQuestion = false;
	private bool formationvisible = false;
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
	private TextEdit horloge ;
	private AnimatedSprite2D anim;

	private Panel panel;
	private Question q = new Question();
	int nbrdv=0;
	int nbquestion = 0;

	int nombrequestion = 0;
	int heure = 08;
	int minute = 00;


	// personnage 3d
	private Viewport viewport; // Le viewport pour rendre la scène 3D
    private TextureRect textureRectpersonnage; // Le rectangle pour afficher la texture du Viewport
    private Camera3D camera3D; // La caméra de la scène 3D


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

		// Gestion de l'heure
		horloge = GetNode<TextEdit>("Horloge/horloge");



		// personnage 
		// Récupérer les nœuds
        viewport = GetNode<Viewport>("Viewport");
        textureRectpersonnage = GetNode<TextureRect>("TextureRect");

        // Créer un ViewportTexture et le lier au TextureRect
        ViewportTexture viewportTexture = new ViewportTexture();
        textureRectpersonnage.Texture = viewportTexture;

        // Récupérer la caméra de la scène 3D
        camera3D = GetNode<Camera3D>("Camera3D");

        // Configurer le Viewport pour utiliser la caméra de la scène 3D
        // Lier le viewport au monde 3D (cela nécessite un World3D)
        viewport.World3D = camera3D.GetWorld3D();
        
		

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
			GérerQuestionAsync();
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

	private async void GérerQuestionAsync()
	{
		
		
		

		if (Input.IsActionJustPressed("Question") && !projetvisible && !formationvisible && !agendavisible)
		{
			
				
				anim.Visible = true;
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

		formationvisible = false;
		agendavisible = false;
		projetvisible = false;
		anim.Visible=false;
	}


	private void verifieravantdefermer()
	{
		if (_textEdit.Visible)
		{
			_textEdit.Visible = false;

			r1.Visible = false;
			r2.Visible = false;
			anim.Visible=false;
			((PlayerAnim)anim).ResetAnimation();
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
	
	
		if (Input.IsActionJustPressed("AnswerLeft") && !projetvisible && !formationvisible && !agendavisible &&_textEdit.Visible)
		{
			MettreÀJourJauges(J1, J2, J3, J4, q.getvaleur1); // Mettre à jour les jauges
			inQuestion = false;
			q.question_suivante(agenda.GetRendezVous()[nbrdv].getcomposante()); // Passer à la question suivante
			nombrequestion+=1;
			suiv();
			faireavancerletemps();
		}
		else if (Input.IsActionJustPressed("AnswerRight") && !projetvisible && !formationvisible && !agendavisible &&_textEdit.Visible)
		{
			MettreÀJourJauges(J1, J2, J3, J4, q.getvaleur2); // Mettre à jour les jauges
			inQuestion = false;
			q.question_suivante(agenda.GetRendezVous()[nbrdv].getcomposante()); // Passer à la question suivante
			nombrequestion+=1;
			suiv();
			faireavancerletemps();
		}
	
	}

	private void suiv(){
		if (nbquestion == 3){
			nbquestion = 0;
			if(nbrdv == 3){
				nbrdv = 0;
				
			}
			else{
				nbrdv++;
			}
		}
		else{
			nbquestion++;
		}

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


}
