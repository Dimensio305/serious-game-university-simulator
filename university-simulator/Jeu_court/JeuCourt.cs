using Godot;
using System;
using System.Collections.Generic;

public partial class JeuCourt : Node2D
{
    private TextEdit _textEdit;
    private bool inQuestion = false;
    private bool projetvisible = false; 
    private bool agendavisible = false; 

    private List<Projet> projets;
    private List<Formation> forma;
    private Agenda agenda;

    private TextEdit textEdit2; // Affichage de l'agenda
    private TextEdit textEdit3; // Affichage des     private TextEdit r1; 
    private TextEdit r2; 
    private TextEdit r1; 

    private Panel panel;
    private Question q = new Question();

    public override void _Ready()
    {    
        _textEdit = GetNode<TextEdit>("TextEdit");
        _textEdit.Visible = false; 

        panel = GetNode<Panel>("panel");
        textEdit2 = GetNode<TextEdit>("TextEdit2"); 
        textEdit3 = GetNode<TextEdit>("panel/TextEdit3"); 
        r1 = GetNode<TextEdit>("r1");
        r2 = GetNode<TextEdit>("r2");

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

        if (Input.IsActionJustPressed("temp") && !projetvisible && !agendavisible) {
            inQuestion = true;
        }

        if (inQuestion) {
            GérerQuestion(Jauge1, Jauge2, Jauge3, Jauge4);
        }

        if (Input.IsActionJustPressed("agenda")) {
            rendrevisibleagenda();
        }

        if (Input.IsActionJustPressed("projet")) {
            rendrevisibleprojet();
        }

        if (Input.IsActionPressed("fermer")) {
            verifieravantdefermer();
        }
    }

    private void GérerQuestion(Jauge Jauge1, Jauge Jauge2, Jauge Jauge3, Jauge Jauge4)
    {
        if (Input.IsActionJustPressed("Question")) {
            affichage.EcrireTexte(_textEdit, q.getquestion());
            affichage.EcrireTexte(r1, q.reponse1());
            affichage.EcrireTexte(r2, q.reponse2());
        }

        if (q.getnumquestion() % 5 == 0 && q.getnumquestion() != 0 && Input.IsActionJustPressed("Question")) {
           
            Rendezvous rdv = nouveaurdv();
            affichage.EcrireTexte(_textEdit, rdv.ToString());
            affichage.EcrireTexte(r1, "accepter le rdv");
            affichage.EcrireTexte(r2, "refuser le rdv");

            if (Input.IsActionJustPressed("AnswerRight")) {
                
                // refuser le rdv 
            } 
            else if (Input.IsActionJustPressed("AnswerLeft")) {
               if(agenda.PeutAjouterRendezVous(rdv)){
                agenda.ajtrdv(rdv);
                GD.Print("Rendez-vous ajouté");
               }
               else{
                GD.Print("rdv pas ajouter");
               }
            }
        }
        
        if (Input.IsActionJustPressed("AnswerRight")) {
            MettreÀJourJauges(Jauge1, Jauge2, Jauge3, Jauge4, q.getvaleur2);
            inQuestion = false;
            q.question_suivante();
        } 
        else if (Input.IsActionJustPressed("AnswerLeft")) {
            MettreÀJourJauges(Jauge1, Jauge2, Jauge3, Jauge4, q.getvaleur1);
            inQuestion = false;
            q.question_suivante();
        }
    }

    private void MettreÀJourJauges(Jauge Jauge1, Jauge Jauge2, Jauge Jauge3, Jauge Jauge4, Func<string, int> getValeur)
    {
        Jauge1.Modif(getValeur("j1"));
        Jauge2.Modif(getValeur("j2"));
        Jauge3.Modif(getValeur("j3"));
        Jauge4.Modif(getValeur("j4"));
    }


    private Rendezvous nouveaurdv()
    {
        Random rand = new Random();
        return Rendezvous.GenererRendezVousAleatoire(rand.Next(1, 6));
    }





    // Méthode pour cacher tous les TextEdit
    private void CacherTousLesTextEdits() {
        _textEdit.Visible = false;
        textEdit2.Visible = false;
        textEdit3.Visible = false;
        r1.Visible = false;
        r2.Visible=false;

        projetvisible = false;
        agendavisible = false;
    }


    private void verifieravantdefermer(){
        if ( _textEdit.Visible) {
                _textEdit.Visible = false;
         
                r1.Visible=false;
                r2.Visible=false;
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

    private void rendrevisibleprojet(){
        if (! _textEdit.Visible && !agendavisible) {
                CacherTousLesTextEdits(); // Cacher tous les TextEdit
                //affichage.AfficherProjets(projets, textEdit3,panel);

                affichage.AfficherFormations(forma,textEdit3,panel);
				panel.Visible=true;
                textEdit3.Visible = true; // Afficher les projets
                projetvisible = true;
            }
    }

    private void rendrevisibleagenda(){
         if (! _textEdit.Visible && !projetvisible) {
                CacherTousLesTextEdits(); // Cacher tous les TextEdit
                affichage.AfficherAgenda(agenda.GetRendezVous(), textEdit2);
                textEdit2.Visible = true; // Afficher l'agenda
                agendavisible = true;
            }
    }

    private void GenererForma(){
        for (int i =0 ; i < 5 ;i ++){
            forma.Add(Formation.genereformation());
        }
    }
}