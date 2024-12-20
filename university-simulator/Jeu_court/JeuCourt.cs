using Godot;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

/// <summary>
/// Classe JeuCourt : Gère le déroulement du jeu court.
/// </summary>
public partial class JeuCourt : Node2D
{
	// gestion des questions 
	private TextEdit _textEdit;
	private bool inQuestion = false;
	private Question question = new Question();
	private TextureRect recQuestion;

	//gestion des formation 
	private List<Formation> formations;
	private TextEdit textEditFormations;

	// gestion des agenda
	private Agenda agenda;

	//private TextEdit texteditagenda;
	private RichTextLabel TextLabelordi;
	int nbRdv = 0;

	// gestion de srdv physique 
	private bool inrdv = false;
	private int aquellequestion = 0;

	//gestion des projets 
	private bool projetvisible = false;
	private List<Projet> projets;
	private TextEdit proj;

	//gestion de l'heure 
	private TextEdit horloge;
	private int heure = 08;
	private int minute = 00;

	// a verifier 
	private Panel panel;
	private int nbquestion = 0;

	// personnage
	private TextureRect textureRectpersonnage;


	// message
	private RichTextLabel textLabelmessage;
	private Jauge Jauge1;
	private Jauge Jauge2;
	private Jauge Jauge3;
	private Jauge Jauge4;
	private Image img;
	private RichTextLabel messagefin;
	private Button buttonLeft;
	private Button buttonRight;

	/// <summary>
	/// Appelée lorsque le nœud est prêt.
	/// </summary>
	public override void _Ready()
	{
		_textEdit = GetNode<TextEdit>("rectquestion/TextEdit");
		_textEdit.Visible = false;

		panel = GetNode<Panel>("panel");

		textEditFormations = GetNode<TextEdit>("panel/TextEdit3");
		proj = GetNode<TextEdit>("proj");

		textureRectpersonnage = GetNode<TextureRect>("personnage");
		// Générer des projets et rendez-vous aléatoires
		projets = Projet.GenererProjetsAleatoires();
		agenda = new Agenda();
		formations = new List<Formation>();
		GenererFormation();

		// Gestion de l'heure
		horloge = GetNode<TextEdit>("Horloge/horloge");

		textLabelmessage = GetNode<RichTextLabel>("TextLabelmessage");

		recQuestion = GetNodeOrNull<TextureRect>("rectquestion");
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
		int _Jauge2 = JaugeManager.GetJaugeValue("Jauge2");
		int _Jauge3 = JaugeManager.GetJaugeValue("Jauge3");
		int _Jauge4 = JaugeManager.GetJaugeValue("Jauge4");
		Jauge1.SetValeur(_Jauge1);
		Jauge2.SetValeur(_Jauge2);
		Jauge3.SetValeur(_Jauge3);
		Jauge4.SetValeur(_Jauge4);

		messagefin = GetNodeOrNull<RichTextLabel>("RichTextLabel");

		Affichage.ChangeImage("res://asset/acteurs/t3_character" + agenda.GetRendezVous()[nbRdv].GetComposante() + ".png", textureRectpersonnage);
		JaugeManager.UpdateJour();

		Attente();
	}

	/// <summary>
	/// Gerer les evenements
	/// </summary>
	/// <param name="delta"></param>
	public override void _Process(double delta)
	{
		recQuestion.Visible = _textEdit.Visible;
		if (inQuestion)
		{
			GereQuestionAsync();
			GereReponse(Jauge1, Jauge2, Jauge3, Jauge4);

		}

		if (Input.IsActionJustPressed("agenda"))
		{
			RendreVisibleAgenda();
		}

		if (Input.IsActionJustPressed("formation"))
		{
			RendreVisibleFormation();
		}
		//if (Input.IsActionJustPressed("projet"))
		//{
		//	rendrevisibleprojet();
		//}
		if (Input.IsActionJustPressed("Etat"))
		{
			RendreEtatVisible();
		}

		if (Input.IsActionPressed("fermer"))
		{
			CacherElements();
		}

		Affichage.FinDuJeu(Jauge1, Jauge2, Jauge3, Jauge4, this);
	}

	/// <summary>
	/// Gère les questions de manière asynchrone.
	/// </summary>
	private async void GereQuestionAsync()
	{
		if (Input.IsActionJustPressed("Question") && !projetvisible && !textEditFormations.Visible && !TextLabelordi.Visible)
		{
			// on a message deux fois sinon on change le message que apres l'arriver de la question
			//donc decalage entre le message et la question etrange sinon 
			textureRectpersonnage.Visible = true;
			Message();
			await ToSignal(GetTree().CreateTimer(1f), "timeout");
			Affichage.EcrireTexte(_textEdit, question.getquestion(agenda.GetRendezVous()[nbRdv].GetComposante()));
			buttonLeft.Text = question.reponse1();
			buttonLeft.Visible = true;
			buttonRight.Text = question.reponse2();
			buttonRight.Visible = true;
			Message();
		}
	}

	/// <summary>
	/// Met à jour les jauges en fonction des valeurs obtenues.
	/// </summary>
	/// <param name="Jauge1"></param>
	/// <param name="Jauge2"></param>
	/// <param name="Jauge3"></param>
	/// <param name="Jauge4"></param>
	/// <param name="getValeur"></param>
	private void UpdateJauges(Jauge Jauge1, Jauge Jauge2, Jauge Jauge3, Jauge Jauge4, Func<string, int> getValeur)
	{
		Jauge1.Modif(getValeur("j1"));
		JaugeManager.SetJaugeValue("Jauge1", (int)Jauge1.GetValeur());
		Jauge2.Modif(getValeur("j2"));
		JaugeManager.SetJaugeValue("Jauge2", (int)Jauge2.GetValeur());
		Jauge3.Modif(getValeur("j3"));
		JaugeManager.SetJaugeValue("Jauge3", (int)Jauge3.GetValeur());
		Jauge4.Modif(getValeur("j4"));
		JaugeManager.SetJaugeValue("Jauge4", (int)Jauge4.GetValeur());

	}

	/// <summary>
	/// Cache tous les TextEdit.
	/// </summary>
	private void CacherTousLesTextEdits()
	{
		_textEdit.Visible = false;
		TextLabelordi.Visible = false;
		textEditFormations.Visible = false;
		buttonLeft.Visible = false;
		buttonRight.Visible = false;
		proj.Visible = false;
		panel.Visible = false;
		projetvisible = false;
	}

	/// <summary>
	/// Vérifie si un TextEdit est visible avant de le fermer.
	/// </summary>
	private void CacherElements()
	{
		if (_textEdit.Visible)
		{
			_textEdit.Visible = false;
			buttonLeft.Visible = false;
			buttonRight.Visible = false;

		}
		if (textEditFormations.Visible)
		{
			panel.Visible = false;
			textEditFormations.Visible = false;
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
		Message();
	}

	/// <summary>
	/// Rend visible les formations
	/// </summary>
	private void RendreVisibleFormation()
	{
		if (!_textEdit.Visible && !TextLabelordi.Visible && !projetvisible)
		{
			Affichage.AfficherFormations(formations, textEditFormations, panel);
			panel.Visible = true;
			textEditFormations.Visible = true; // Afficher les projets
		}
	}

	/// <summary>
	/// Rend visible les projets
	/// </summary>
	private void RendreVisibleProjet()
	{
		if (!_textEdit.Visible && !TextLabelordi.Visible && !textEditFormations.Visible)
		{
			Affichage.AfficherProjets(projets, proj);
			proj.Visible = true; // Afficher les projets
			projetvisible = true;
		}
	}

	/// <summary>
	/// Rend visible l'agenda
	/// </summary>
	private void RendreVisibleAgenda()
	{
		if (!_textEdit.Visible && !textEditFormations.Visible && !projetvisible)
		{
			Affichage.AfficherAgenda(agenda.GetRendezVous(), TextLabelordi);
			TextLabelordi.Visible = true; // Afficher l'agenda
			Message();
		}
	}

	/// <summary>
	/// Rend visible l'état de la relation
	/// </summary>
	private void RendreEtatVisible()
	{
		if (!_textEdit.Visible && !textEditFormations.Visible && !projetvisible)
		{

			Affichage.AffichageEtat(TextLabelordi);
			TextLabelordi.Visible = true; // Afficher l'agenda
			Message();
		}
	}

	/// <summary>
	/// Genère 5 formations
	/// </summary>
	private void GenererFormation()
	{
		for (int i = 0; i < 5; i++)
		{
			formations.Add(Formation.GenereFormation());
		}
	}

	/// <summary>
	/// Gère les réponses aux questions et met à jour les jauges en conséquence.
	/// </summary>
	/// <param name="J1"></param>
	/// <param name="J2"></param>
	/// <param name="J3"></param>
	/// <param name="J4"></param> <summary>
	/// 
	/// </summary>
	public void GereReponse(Jauge J1, Jauge J2, Jauge J3, Jauge J4)
	{
		if (Input.IsActionJustPressed("AnswerLeft") && !projetvisible && !textEditFormations.Visible && !TextLabelordi.Visible && _textEdit.Visible)
		{
			UpdateJauges(J1, J2, J3, J4, question.getvaleur1); // Mettre à jour les jauges
			inQuestion = false;
			Message();
			question.question_suivante(agenda.GetRendezVous()[nbRdv].GetComposante()); // Passer à la question suivante
			QuestionSuivante();
			FaireAvancerTemps();
			Attente();
		}
		else if (Input.IsActionJustPressed("AnswerRight") && !projetvisible && !textEditFormations.Visible && !TextLabelordi.Visible && _textEdit.Visible)
		{
			UpdateJauges(J1, J2, J3, J4, question.getvaleur2); // Mettre à jour les jauges
			inQuestion = false;
			Message();
			question.question_suivante(agenda.GetRendezVous()[nbRdv].GetComposante()); // Passer à la question suivante
			QuestionSuivante();
			FaireAvancerTemps();
			Attente();

		}

	}

	/// <summary>
	/// Méthode pour passer à la question suivante.
	/// </summary>
	private async void QuestionSuivante()
	{
		if (nbquestion == 1) // Fin des questions du rendez-vous
		{
			nbquestion = 0;
			if (nbRdv == 3) // Tous les rendez-vous terminés
			{
				nbRdv = 0;
			}
			else
			{
				nbRdv++;

				await ToSignal(GetTree().CreateTimer(0.5f), "timeout");
				Affichage.EcrireTexte(_textEdit, question.GetRandomEndPhrase());
				buttonLeft.Visible = false;
				buttonRight.Visible = false;
				textureRectpersonnage.Visible = false; // Fin de l'animation uniquement ici
				Affichage.ChangeImage("res://asset/acteurs/t3_character" + agenda.GetRendezVous()[nbRdv].GetComposante() + ".png", textureRectpersonnage);
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
		Affichage.EcrireTexte(_textEdit, question.getquestion(agenda.GetRendezVous()[nbRdv].GetComposante()));
		buttonLeft.Text = question.reponse1();
		buttonRight.Text = question.reponse2();
		GereReponse(Jauge1, Jauge2, Jauge3, Jauge4);
		buttonLeft.Visible = true;
		buttonRight.Visible = true;
		Message();
	}

	private async Task AfficherMessageIntermediaire()
	{
		Affichage.EcrireTexte(_textEdit, question.GetRandomPhrase());
		buttonLeft.Visible = false;
		buttonRight.Visible = false;
		await ToSignal(GetTree().CreateTimer(1.5f), "timeout"); // Pause avant la question suivante
	}


	private async void FaireAvancerTemps()
	{
		minute += 60;
		if (minute >= 60)
		{
			minute -= 60;
			heure += 1;
		}
		Affichage.EcrireTexte(horloge, "   " + heure.ToString("D2") + ":" + minute.ToString("D2"));

		if (heure == 12)
		{
			await ToSignal(GetTree().CreateTimer(1), "timeout"); // Pause d'une seconde
			heure = 14;
			Affichage.EcrireTexte(horloge, "   " + heure.ToString("D2") + ":" + minute.ToString("D2"));
		}

		if (heure >= 18)
		{
			await ToSignal(GetTree().CreateTimer(0.5), "timeout");
			Jour.Instance.JourSuivant();
			CacherTousLesTextEdits();
			Affichage.AffichageEtatJour(messagefin);
		}
	}

	private async void Attente()
	{
		await ToSignal(GetTree().CreateTimer(2), "timeout");
		inQuestion = true;
		Message();
	}

	private void Message()
	{
		if (inQuestion && !textureRectpersonnage.Visible && !TextLabelordi.Visible)
		{
			textLabelmessage.Clear();
			textLabelmessage.BbcodeEnabled = true; // Active le mode BBCode
			textLabelmessage.Text = "\n\n";
			textLabelmessage.Text += $"[center][b][color=orange]Un rendez-vous vous attend avec ({agenda.GetRendezVous()[nbRdv].ToString()})[/color][/b][/center]";
			textLabelmessage.Visible = true;

		}
		else if (inQuestion && textureRectpersonnage.Visible && !TextLabelordi.Visible)
		{
			textLabelmessage.Clear();
			textLabelmessage.BbcodeEnabled = true; // Active le mode BBCode
			textLabelmessage.Text = "\n\n";
			textLabelmessage.Text += $"[center][b][color=orange]Vous etes en rendez-vous avec ({agenda.GetRendezVous()[nbRdv].ToString()}) \n Etat de la relation : {Affichage.Creationlien(agenda.GetRendezVous()[nbRdv].GetComposante())}[/color][/b][/center]";


		}
		else
		{
			textLabelmessage.Clear();
			textLabelmessage.Visible = false;
		}
	}

	private void OnButtonPressed()
	{
		if (Jour.Instance.GetJour() == 5)
		{
			GetTree().ChangeSceneToFile("res://Jeu_court/finduJeu.tscn");
		}
		else
		{
			GetTree().ChangeSceneToFile("res://intermediaire/affichage_jour.tscn");
		}
	}

	private void OnButtonLeftPressed()
	{
		HandleResponse(Jauge1, Jauge2, Jauge3, Jauge4, true); // true pour gauche
	}

	private void OnButtonRightPressed()
	{
		HandleResponse(Jauge1, Jauge2, Jauge3, Jauge4, false); // false pour droite
	}

	/// <summary>
	/// Met à jour les jauges en fonction de la réponse donnée.
	/// </summary>
	/// <param name="J1"></param>
	/// <param name="J2"></param>
	/// <param name="J3"></param>
	/// <param name="J4"></param>
	/// <param name="isLeft"></param>
	public void HandleResponse(Jauge J1, Jauge J2, Jauge J3, Jauge J4, bool isLeft)
	{
		if (isLeft)
		{
			UpdateJauges(J1, J2, J3, J4, question.getvaleur1); // Mettre à jour les jauges pour la réponse gauche
		}
		else
		{
			UpdateJauges(J1, J2, J3, J4, question.getvaleur2); // Mettre à jour les jauges pour la réponse droite
		}

		inQuestion = false;
		Message();
		question.question_suivante(agenda.GetRendezVous()[nbRdv].GetComposante()); // Passer à la question suivante
		QuestionSuivante();
		FaireAvancerTemps();
		Attente();
	}
}
