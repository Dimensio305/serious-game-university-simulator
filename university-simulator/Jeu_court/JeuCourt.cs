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

	private Question q = new Question();
	private TextureRect recQuestion;

	

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
	private Button buttonLeft;
	private Button buttonRight;

	
/// <summary>
/// 
/// </summary>
	public override void _Ready()
	{
		_textEdit = GetNode<TextEdit>("rectquestion/TextEdit");
		_textEdit.Visible = false;

		panel = GetNode<Panel>("panel");
	
		proj = GetNode<TextEdit>("proj");
		
			
		textureRectpersonnage = GetNode<TextureRect>("personnage");
		// Générer des projets et rendez-vous aléatoires
		projets = Projet.GenererProjetsAleatoires();
		agenda = new Agenda();
		

		// Gestion de l'heure
		horloge = GetNode<TextEdit>("Horloge/horloge");

		
		textLabelmessage =GetNode<RichTextLabel>("TextLabelmessage");

		recQuestion=GetNodeOrNull<TextureRect>("rectquestion");
		TextLabelordi = GetNode<RichTextLabel>("TextLabelordi");
		buttonLeft = GetNode<Button>("_b_reponse_gauche");
		buttonRight = GetNode<Button>("_b_reponse_droite");

		buttonLeft.Connect("pressed", Callable.From(OnButtonLeftPressed));
		buttonRight.Connect("pressed", Callable.From(OnButtonRightPressed));

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
	
		affichage.ChangeImage("res://asset/acteurs/t3_character"+agenda.GetRendezVous()[nbrdv].getComposante()+".png",textureRectpersonnage);
		JaugeManager.majjour();
		



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

		if (Input.IsActionJustPressed("Etat"))
		{
			rendrevisibleetat();
		}

		if (Input.IsActionPressed("fermer"))
		{
			verifieravantdefermer();
		}
		
		affichage.FinDuJeu(Jauge1, Jauge2, Jauge3, Jauge4, this);
		


	}


	/// <summary>
	/// 
	/// </summary>
	private async void GérerQuestionAsync()
	{
		
		
		

		if (Input.IsActionJustPressed("Question") )
		{
				// on a message deux fois sinon on change le message que apres l'arriver de la question
				//donc decalage entre le message et la question etrange sinon 
				textureRectpersonnage.Visible=true;
				message();
				await ToSignal(GetTree().CreateTimer(1f), "timeout");
				affichage.EcrireTexte(_textEdit, q.getquestion(agenda.GetRendezVous()[nbrdv].getComposante()));
				buttonLeft.Text=q.reponse1();
				buttonLeft.Visible=true;
				buttonRight.Text= q.reponse2();
				buttonRight.Visible=true;
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
	
		buttonLeft.Visible = false;
		buttonRight.Visible = false;
		proj.Visible = false;
		panel.Visible = false;
		projetvisible = false;
	}


	private void verifieravantdefermer()
	{
		if (_textEdit.Visible)
		{
			_textEdit.Visible = false;
			buttonLeft.Visible=false;
			buttonRight.Visible = false;
						
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

	private void rendrevisibleagenda()
	{
		
		
			
			affichage.AfficherAgenda(agenda.GetRendezVous(), TextLabelordi);
			TextLabelordi.Visible = true; // Afficher l'agenda
			message();
		
	}

	private void rendrevisibleetat()
	{
		
			
			affichage.AffichageEtat(TextLabelordi);
			TextLabelordi.Visible = true; // Afficher l'agenda
			message();
		
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
	
	
		if (Input.IsActionJustPressed("AnswerLeft") && !projetvisible  && !TextLabelordi.Visible &&_textEdit.Visible)
		{
			MettreÀJourJauges(J1, J2, J3, J4, q.getvaleur1); // Mettre à jour les jauges
			inQuestion = false;	
			message();
			q.question_suivante(agenda.GetRendezVous()[nbrdv].getComposante()); // Passer à la question suivante
			suiv();
			faireavancerletemps();
			attente();
			
			
		}
		else if (Input.IsActionJustPressed("AnswerRight") && !projetvisible  && !TextLabelordi.Visible &&_textEdit.Visible)
		{
			MettreÀJourJauges(J1, J2, J3, J4, q.getvaleur2); // Mettre à jour les jauges
			inQuestion = false;
			message();
			q.question_suivante(agenda.GetRendezVous()[nbrdv].getComposante()); // Passer à la question suivante
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
			buttonLeft.Visible=false;
			buttonRight.Visible = false;
			textureRectpersonnage.Visible = false; // Fin de l'animation uniquement ici
			affichage.ChangeImage("res://asset/acteurs/t3_character"+agenda.GetRendezVous()[nbrdv].getComposante()+".png",textureRectpersonnage);
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
	affichage.EcrireTexte(_textEdit, q.getquestion(agenda.GetRendezVous()[nbrdv].getComposante()));
	buttonLeft.Text=q.reponse1();
	buttonRight.Text= q.reponse2();
	gerereponse(Jauge1, Jauge2, Jauge3, Jauge4 );
	buttonLeft.Visible=true;
	buttonRight.Visible = true;
	message();
}

private async Task AfficherMessageIntermediaire()
{
	affichage.EcrireTexte(_textEdit, q.GetRandomPhrase());
	buttonLeft.Visible=false;
	buttonRight.Visible = false;
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
			CacherTousLesTextEdits();
			affichage.AffichageEtatJour(messagefin);
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
		textLabelmessage.Text += $"[center][b][color=orange]Vous etes en rendez-vous avec ({agenda.GetRendezVous()[nbrdv].ToString()})[/b][/color][/center]";
		textLabelmessage.Text += $"[center][color=orange]\nEtat de la relation : {affichage.creationlien(agenda.GetRendezVous()[nbrdv].getComposante())}[/color][/center]";
	}
	else
	{
		textLabelmessage.Clear();
		textLabelmessage.Visible = false;
	}
	}

	private void _on_button_pressed(){
		if (Jour.Instance.GetJour()== 5){
			GetTree().ChangeSceneToFile("res://Jeu_court/finduJeu.tscn");
		}
		else{
		GetTree().ChangeSceneToFile("res://intermediaire/affichage_jour.tscn");
		}
	}

	private void OnButtonLeftPressed()
	{
		gerereponse(Jauge1, Jauge2, Jauge3, Jauge4, true); // true pour gauche
	}

	private void OnButtonRightPressed()
	{
		gerereponse(Jauge1, Jauge2, Jauge3, Jauge4, false); // false pour droite
	}

	public void gerereponse(Jauge J1, Jauge J2, Jauge J3, Jauge J4, bool isLeft)
	{
		if (isLeft)
		{
			MettreÀJourJauges(J1, J2, J3, J4, q.getvaleur1); // Mettre à jour les jauges pour la réponse gauche
			message();
		}
		else
		{
			MettreÀJourJauges(J1, J2, J3, J4, q.getvaleur2); // Mettre à jour les jauges pour la réponse droite
			message();
		}

		inQuestion = false;
		message();
		q.question_suivante(agenda.GetRendezVous()[nbrdv].getComposante()); // Passer à la question suivante
		suiv();
		faireavancerletemps();
		attente();
	}

	


}
