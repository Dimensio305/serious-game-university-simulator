using Godot;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Threading.Tasks;

/// <summary>
/// 
/// </summary>
public partial class JeuCourt : Node2D
{

	// gestion des questions 
	private TextEdit _textEdit;
	private bool inQuestion = false;
	private TextEdit r2;
	private TextEdit r1;
	private Question q = new Question();
	private TextureRect recQuestion;

	//gestion des formation 
	private List<Formation> forma;
	private TextEdit texteditforma;

	// gestion des agenda
	private Agenda agenda;
	//private TextEdit texteditagenda;

	private RichTextLabel TextLabelordi;
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
	
	
	// personnage
	private TextureRect textureRectpersonnage;


	// message
	private RichTextLabel textLabelmessage;
	private Jauge Jauge1 ; 
	private Jauge Jauge2 ;
	private Jauge Jauge3 ;
	private Jauge Jauge4 ;   

	private Image img;

	private RichTextLabel messagefin; 
	
/// <summary>
/// 
/// </summary>
	public override void _Ready()
	{
		_textEdit = GetNode<TextEdit>("rectquestion/TextEdit");
		_textEdit.Visible = false;

		panel = GetNode<Panel>("panel");
		

		texteditforma = GetNode<TextEdit>("panel/TextEdit3");
		proj = GetNode<TextEdit>("proj");
		r1 = GetNode<TextEdit>("r1");
		r2 = GetNode<TextEdit>("r2");
			
		textureRectpersonnage = GetNode<TextureRect>("personnage");
		// Générer des projets et rendez-vous aléatoires
		projets = Projet.GenererProjetsAleatoires();
		agenda = new Agenda();
		forma = new List<Formation>();
		GenererForma();

		// Gestion de l'heure
		horloge = GetNode<TextEdit>("Horloge/horloge");

		
		textLabelmessage =GetNode<RichTextLabel>("TextLabelmessage");

		recQuestion=GetNodeOrNull<TextureRect>("rectquestion");
		TextLabelordi = GetNode<RichTextLabel>("TextLabelordi");

		Jauge1 = GetNodeOrNull<Jauge>("Jauge1");
		Jauge2 = GetNodeOrNull<Jauge>("Jauge2");
		Jauge3 = GetNodeOrNull<Jauge>("Jauge3");
		Jauge4 = GetNodeOrNull<Jauge>("Jauge4");
		int _Jauge1 = JaugeManager.GetJaugeValue("Jauge1");
		int  _Jauge2 = JaugeManager.GetJaugeValue("Jauge2");
		int _Jauge3 = JaugeManager.GetJaugeValue("Jauge3");
		int _Jauge4 = JaugeManager.GetJaugeValue("Jauge4");
		Jauge1.SetValeur(_Jauge1);
		Jauge2.SetValeur(_Jauge2);
		Jauge3.SetValeur(_Jauge3);
		Jauge4.SetValeur(_Jauge4);

		messagefin=GetNodeOrNull<RichTextLabel>("RichTextLabel");
	
		affichage.ChangeImage("res://asset/acteurs/t3_character"+agenda.GetRendezVous()[nbrdv].getcomposante()+".png",textureRectpersonnage);
 

		

		attente();
		

	}

/// <summary>
/// 
/// </summary>
/// <param name="delta"></param>
	public override void _Process(double delta)
	{
		
		recQuestion.Visible=_textEdit.Visible;
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
		//if (Input.IsActionJustPressed("projet"))
		//{
		//	rendrevisibleprojet();
		//}
		if (Input.IsActionJustPressed("Etat"))
		{
			rendrevisibleetat();
		}

		if (Input.IsActionPressed("fermer"))
		{
			verifieravantdefermer();
		}
		
		affichage.FinDuJeu(Jauge1, Jauge2, Jauge3, Jauge4, Jour.Instance.GetJour(), this);
		


	}


	/// <summary>
	/// 
	/// </summary>
	private async void GérerQuestionAsync()
	{
		
		
		

		if (Input.IsActionJustPressed("Question") && !projetvisible && !texteditforma.Visible && !TextLabelordi.Visible)
		{
				// on a message deux fois sinon on change le message que apres l'arriver de la question
				//donc decalage entre le message et la question etrange sinon 
				textureRectpersonnage.Visible=true;
				message();
				await ToSignal(GetTree().CreateTimer(1f), "timeout");
				affichage.EcrireTexte(_textEdit, q.getquestion(agenda.GetRendezVous()[nbrdv].getcomposante()));
				affichage.EcrireTexte(r1, q.reponse1());
				affichage.EcrireTexte(r2, q.reponse2());
				message();
		}

	// Sup fuckers <3

	}

	private void MettreÀJourJauges(Jauge Jauge1, Jauge Jauge2, Jauge Jauge3, Jauge Jauge4, Func<string, int> getValeur)
	{
		Jauge1.Modif(getValeur("j1"));
		JaugeManager.SetJaugeValue("Jauge1",(int)Jauge1.GetValeur());
		Jauge2.Modif(getValeur("j2"));
		JaugeManager.SetJaugeValue("Jauge2",(int)Jauge2.GetValeur());
		Jauge3.Modif(getValeur("j3"));
		JaugeManager.SetJaugeValue("Jauge3",(int)Jauge3.GetValeur());
		Jauge4.Modif(getValeur("j4"));
		JaugeManager.SetJaugeValue("Jauge4",(int)Jauge4.GetValeur());

	}





	// Méthode pour cacher tous les TextEdit
	private void CacherTousLesTextEdits()
	{
		_textEdit.Visible = false;
		TextLabelordi.Visible = false;
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
		if (TextLabelordi.Visible)
		{
			TextLabelordi.Visible = false;
		}
		if (projetvisible)
		{
			projetvisible = false;
			proj.Visible = false;
		}
		message();
	}

	private void rendrevisibleformation()
	{
		if (!_textEdit.Visible && !TextLabelordi.Visible && !projetvisible)
		{
		   

			affichage.AfficherFormations(forma, texteditforma, panel);
			panel.Visible = true;
			texteditforma.Visible = true; // Afficher les projets
		}
	}

	private void rendrevisibleprojet()
	{
		if (!_textEdit.Visible && !TextLabelordi.Visible && !texteditforma.Visible)
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
			
			affichage.AfficherAgenda(agenda.GetRendezVous(), TextLabelordi);
			TextLabelordi.Visible = true; // Afficher l'agenda
			message();
		}
	}

	private void rendrevisibleetat()
	{
		if (!_textEdit.Visible && !texteditforma.Visible  && !projetvisible)
		{
			
			affichage.AffichageEtat(TextLabelordi);
			TextLabelordi.Visible = true; // Afficher l'agenda
			message();
		}
	}

	private void GenererForma()
	{
		for (int i = 0; i < 5; i++)
		{
			forma.Add(Formation.genereformation());
		}
	}

/// <summary>
/// 
/// </summary>
/// <param name="J1"></param>
/// <param name="J2"></param>
/// <param name="J3"></param>
/// <param name="J4"></param> <summary>
/// 
/// </summary>
	public void gerereponse(Jauge J1, Jauge J2, Jauge J3, Jauge J4)
	{
	
	
		if (Input.IsActionJustPressed("AnswerLeft") && !projetvisible && !texteditforma.Visible  && !TextLabelordi.Visible &&_textEdit.Visible)
		{
			MettreÀJourJauges(J1, J2, J3, J4, q.getvaleur1); // Mettre à jour les jauges
			inQuestion = false;	
			message();
			q.question_suivante(agenda.GetRendezVous()[nbrdv].getcomposante()); // Passer à la question suivante
			suiv();
			faireavancerletemps();
			attente();
			
			
		}
		else if (Input.IsActionJustPressed("AnswerRight") && !projetvisible && !texteditforma.Visible  && !TextLabelordi.Visible &&_textEdit.Visible)
		{
			MettreÀJourJauges(J1, J2, J3, J4, q.getvaleur2); // Mettre à jour les jauges
			inQuestion = false;
			message();
			q.question_suivante(agenda.GetRendezVous()[nbrdv].getcomposante()); // Passer à la question suivante
			suiv();
			faireavancerletemps();
			attente();
			
		}
	
	}

	private async void suiv()
{
	if (nbquestion == 1) // Fin des questions du rendez-vous
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
			affichage.EcrireTexte(_textEdit, q.GetRandomEndPhrase());
			r1.Visible = false;
			r2.Visible = false;
			textureRectpersonnage.Visible = false; // Fin de l'animation uniquement ici
			affichage.ChangeImage("res://asset/acteurs/t3_character"+agenda.GetRendezVous()[nbrdv].getcomposante()+".png",textureRectpersonnage);
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
	await ToSignal(GetTree().CreateTimer(1f), "timeout"); // Délai avant la prochaine question
	affichage.EcrireTexte(_textEdit, q.getquestion(agenda.GetRendezVous()[nbrdv].getcomposante()));
	affichage.EcrireTexte(r1, q.reponse1());
	affichage.EcrireTexte(r2, q.reponse2());
	gerereponse(Jauge1, Jauge2, Jauge3, Jauge4 );
	r1.Visible = true;
	r2.Visible = true;
	message();
}

private async Task AfficherMessageIntermediaire()
{
	affichage.EcrireTexte(_textEdit, q.GetRandomPhrase());
	r1.Visible = false;
	r2.Visible = false;
	await ToSignal(GetTree().CreateTimer(1.5f), "timeout"); // Pause avant la question suivante
}


	private async void faireavancerletemps(){
		minute += 60;
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
		message();
	}

	private void message()
{
	if (inQuestion && !textureRectpersonnage.Visible && !TextLabelordi.Visible)
	{
		textLabelmessage.Clear();
		textLabelmessage.BbcodeEnabled = true; // Active le mode BBCode
		textLabelmessage.Text = "\n\n";
		textLabelmessage.Text += $"[center][b][color=orange]Un rendez-vous vous attend avec ({agenda.GetRendezVous()[nbrdv].ToString()})[/color][/b][/center]";
		textLabelmessage.Visible = true;

	}
	else if (inQuestion && textureRectpersonnage.Visible && !TextLabelordi.Visible){
		textLabelmessage.Clear();
		textLabelmessage.BbcodeEnabled = true; // Active le mode BBCode
		textLabelmessage.Text = "\n\n";
		textLabelmessage.Text += $"[center][b][color=orange]Vous etes en rendez-vous avec ({agenda.GetRendezVous()[nbrdv].ToString()}) \n Etat de la relation : {affichage.creationlien(agenda.GetRendezVous()[nbrdv].getcomposante())}[/color][/b][/center]";


	}
	else
	{
		textLabelmessage.Clear();
		textLabelmessage.Visible = false;
	}
}




	

}
