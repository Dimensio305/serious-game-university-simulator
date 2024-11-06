using Godot;
using System;
using System.Collections.Generic;

// Pour quand il y aura la classe de lancement du jeu 
/** Supposons que textEdit2 soit l'instance de TextEdit où vous affichez l'agenda
JeuCourt jeuCourt = new JeuCourt();
jeuCourt.AfficherAgendaInitial(textEdit2);**/

public partial class JeuCourt : Node2D
{
	private TextEdit _textEdit;
	bool inQuestion = false;

	bool textvisible = false;

	bool projetvisible = false; 

	bool agendavisible = false; 

	string stringQuestion;
	int idQuestion;


    private List<Projet> projets;
    private Agenda agenda;

    private TextEdit textEdit2; // Affichage de l'agenda
    private TextEdit textEdit3; // Affichage des projets

	private Panel panel;

	


	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{	

		_textEdit = GetNode<TextEdit>("TextEdit");
		_textEdit.Visible=false; 

		panel = GetNode<Panel>("panel");
		textEdit2 = GetNode<TextEdit>("TextEdit2"); // Remplacez par le chemin correct
        textEdit3 = GetNode<TextEdit>("panel/TextEdit3"); // Remplacez par le chemin correct

        // Générer des projets et rendez-vous aléatoires
        projets = Projet.GenererProjetsAleatoires();
        agenda = new Agenda();
		 
	}
		// Called every frame. 'delta' is the elapsed time since the previous frame.

	
	public override void _Process(double delta)
	{
		var Jauge1 = GetNodeOrNull<Jauge>("Jauge1");
		var Jauge2 = GetNodeOrNull<Jauge>("Jauge2");
		var Jauge3 = GetNodeOrNull<Jauge>("Jauge3");
		var Jauge4 = GetNodeOrNull<Jauge>("Jauge4");


		if(inQuestion) {
			if (Input.IsActionPressed("Question")){
				affichage.EcrireTexte(_textEdit,GestionDb.Instance.ExecuteRequete("select question from Question where id="+idQuestion+";"));
				textvisible=true;
			}
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
				Jauge4.Modif(Int32.Parse(GestionDb.Instance.ExecuteRequete("select j4 from Reponse where idquestion ="+idQuestion+" and idreponse=1;")));
				inQuestion=false;
			}
		}
		if (Input.IsActionPressed("temp")) {
            if (!projetvisible && !agendavisible) {
                inQuestion = true;
                Random rdm = new Random();
                idQuestion = rdm.Next(1, 2); // crée un nombre aléatoire entre x et y-1
                stringQuestion = GestionDb.Instance.ExecuteRequete("select question from Question where id=" + idQuestion + ";");
            }
        }

        // Affichage de l'agenda
        if (Input.IsActionJustPressed("agenda")) {
            if (!textvisible && !projetvisible) {
                CacherTousLesTextEdits(); // Cacher tous les TextEdit
                affichage.AfficherAgenda(agenda.GetRendezVous(), textEdit2);
                textEdit2.Visible = true; // Afficher l'agenda
                agendavisible = true;
            }
        }

        // Affichage des projets
        if (Input.IsActionJustPressed("projet")) {
            if (!textvisible && !agendavisible) {
                CacherTousLesTextEdits(); // Cacher tous les TextEdit
                affichage.AfficherProjets(projets, textEdit3,panel);
				panel.Visible=true;
                textEdit3.Visible = true; // Afficher les projets
                projetvisible = true;
            }
        }

        if (Input.IsActionPressed("fermer")) {
            if (textvisible) {
                _textEdit.Visible = false;
                textvisible = false;
            }
            if (projetvisible) {
				panel.Visible=false;
                textEdit3.Visible = false;
                projetvisible = false;
            }
            if (agendavisible) {
                textEdit2.Visible = false;
                agendavisible = false;
            }
        }
    }

    // Méthode pour cacher tous les TextEdit
    private void CacherTousLesTextEdits() {
        _textEdit.Visible = false;
        textEdit2.Visible = false;
        textEdit3.Visible = false;
        textvisible = false;
        projetvisible = false;
        agendavisible = false;
    }
}