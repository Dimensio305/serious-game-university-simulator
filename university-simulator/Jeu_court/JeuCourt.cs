using Godot;
using System;
using System.Collections.Generic;

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
            Rendezvous rdv = GérerQuestion();
            gerereponse(Jauge1, Jauge2, Jauge3, Jauge4 , rdv);
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

    private Rendezvous GérerQuestion()
    {
        Rendezvous rdv = nouveaurdv();

        if (Input.IsActionJustPressed("Question")&&!projetvisible &&!formationvisible &&!agendavisible&&( q.getnumquestion() % 2 !=0   || q.getnumquestion() ==0))
        {
            affichage.EcrireTexte(_textEdit, q.getquestion());
            affichage.EcrireTexte(r1, q.reponse1());
            affichage.EcrireTexte(r2, q.reponse2());
        }

        if (q.getnumquestion() % 2 == 0 && q.getnumquestion() != 0 && Input.IsActionJustPressed("Question")&&!projetvisible &&!formationvisible &&!agendavisible)
        {

            affichage.EcrireTexte(_textEdit, rdv.vquestion());
            affichage.EcrireTexte(r1, "accepter le rdv");
            affichage.EcrireTexte(r2, "refuser le rdv");
            
        }

        return rdv;

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

    /*rivate void gerereponse(Jauge J1, Jauge J2 , Jauge J3 , Jauge J4,Rendezvous rdv ){
        if (Input.IsActionJustPressed("AnswerLeft")&&!projetvisible &&!formationvisible &&!agendavisible){
            GD.Print("Numéro de la question : ", q.getnumquestion());
            if(q.getnumquestion() % 2 == 0 && q.getnumquestion() != 0){
                 GD.Print("Condition remplie : Numéro de question pair et non nul");
                if (agenda.PeutAjouterRendezVous(rdv))
                {
                    agenda.ajtrdv(rdv);
                    GD.Print("Rendez-vous ajouté");
                    inQuestion = false;
                    q.question_suivante();
                }
                else{
                    GD.Print("Rendez-vous non ajouté");
                    inQuestion = false;
                    q.question_suivante();
                }
            }
            else{
                MettreÀJourJauges(J1, J2, J3, J4, q.getvaleur1);
                inQuestion = false;
                q.question_suivante();
            }
        }
        if (Input.IsActionJustPressed("AnswerRight")&&!projetvisible &&!formationvisible &&!agendavisible){
            if(q.getnumquestion() % 2 == 0 && q.getnumquestion() != 0){
                GD.Print("rendez vous refuser");
                inQuestion = false;
                q.question_suivante();
            }
            else{
                MettreÀJourJauges(J1, J2, J3, J4, q.getvaleur2);
                inQuestion = false;
                q.question_suivante();
            }
        }
    }*/
    public void gerereponse(Jauge J1, Jauge J2, Jauge J3, Jauge J4, Rendezvous rdv)
{
    if (agenda == null)
    {
        GD.Print("Agenda est null !");
        return;
    }

    // Si la question est liée à un rendez-vous, on ne met pas à jour les jauges.
    if (q.getnumquestion() % 2 == 0 && q.getnumquestion() != 0) // question de rendez-vous
    {  if (rdv == null)
    {
        GD.Print("Le rendez-vous est null !");
        return;
    }
        
         if (Input.IsActionJustPressed("AnswerLeft") && !projetvisible && !formationvisible && !agendavisible)
        {
            if (agenda.PeutAjouterRendezVous(rdv)) // Vérifier si le rendez-vous peut être ajouté
            {
                agenda.ajtrdv(rdv); // Ajouter le rendez-vous à l'agenda
                GD.Print("Rendez-vous ajouté : " + rdv);
                inQuestion = false;
                q.question_suivante(); // Passer à la question suivante
            }
            else
            {
                GD.Print("Rendez-vous non ajouté en raison d'un conflit");
                inQuestion = false;
                q.question_suivante(); // Passer à la question suivante
            }
        }
        else if (Input.IsActionJustPressed("AnswerRight") && !projetvisible && !formationvisible && !agendavisible)
        {
            GD.Print("Rendez-vous refusé");
            inQuestion = false;
            q.question_suivante(); // Passer à la question suivante
        }
    }
    else // Pas une question de rendez-vous
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
}



}