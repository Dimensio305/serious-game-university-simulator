using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Godot;

public class JeuFacade
{
    private TextEdit _textEdit;
    private Button buttonLeft;
    private Button buttonRight;
    private Agenda agenda;
    private int nbRdv;
    private TextureRect textureRectpersonnage;
    private RichTextLabel textLabelmessage;
    private Jauge Jauge1;
    private Jauge Jauge2;
    private Jauge Jauge3;
    private Jauge Jauge4;
    private RichTextLabel TextLabelordi;
    private TextEdit horloge;
    private int heure;
    private int minute;
    private Panel panel;
    private TextEdit proj;
    private bool projetvisible;
    private List<Projet> projets;
    private Image img;
    private RichTextLabel messagefin;
    private TextureRect recQuestion;
    private Question question;
    private int nbquestion;

    public JeuFacade(TextEdit textEdit, Button leftButton, Button rightButton, Agenda agenda, int nbRdv, TextureRect textureRectpersonnage,
                     RichTextLabel textLabelmessage, Jauge jauge1, Jauge jauge2, Jauge jauge3, Jauge jauge4, RichTextLabel textLabelordi,
                     TextEdit horloge, int heure, int minute, Panel panel, TextEdit proj, bool projetvisible, List<Projet> projets,
                     Image img, RichTextLabel messagefin, TextureRect recQuestion, Question question, int nbquestion)
    {
        _textEdit = textEdit;
        buttonLeft = leftButton;
        buttonRight = rightButton;
        this.agenda = agenda;
        this.nbRdv = nbRdv;
        this.textureRectpersonnage = textureRectpersonnage;
        this.textLabelmessage = textLabelmessage;
        Jauge1 = jauge1;
        Jauge2 = jauge2;
        Jauge3 = jauge3;
        Jauge4 = jauge4;
        TextLabelordi = textLabelordi;
        this.horloge = horloge;
        this.heure = heure;
        this.minute = minute;
        this.panel = panel;
        this.proj = proj;
        this.projetvisible = projetvisible;
        this.projets = projets;
        this.img = img;
        this.messagefin = messagefin;
        this.recQuestion = recQuestion;
        this.question = question;
        this.nbquestion = nbquestion;
    }

    public async void AfficherQuestion(Question question)
    {
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

    public void MettreAJourJauges(Jauge Jauge1, Jauge Jauge2, Jauge Jauge3, Jauge Jauge4, Func<string, int> getValeur)
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

    public void CacherTousLesTextEdits()
    {
        _textEdit.Visible = false;
        TextLabelordi.Visible = false;
        buttonLeft.Visible = false;
        buttonRight.Visible = false;
        proj.Visible = false;
        panel.Visible = false;
        projetvisible = false;
    }

    public void CacherElements()
    {
        if (_textEdit.Visible)
        {
            _textEdit.Visible = false;
            buttonLeft.Visible = false;
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
        Message();
    }

    public void RendreVisibleAgenda()
    {
        Affichage.AfficherAgenda(agenda.GetRendezVous(), TextLabelordi);
        TextLabelordi.Visible = true; // Afficher l'agenda
        Message();
    }

    public void RendreEtatVisible()
    {
        Affichage.AffichageEtat(TextLabelordi);
        TextLabelordi.Visible = true; // Afficher l'agenda
        Message();
    }

    public void GereReponse(Jauge J1, Jauge J2, Jauge J3, Jauge J4)
    {
        if (Input.IsActionJustPressed("AnswerLeft") && !projetvisible && _textEdit.Visible)
        {
            MettreAJourJauges(J1, J2, J3, J4, question.getvaleur1); // Mettre à jour les jauges
            inQuestion = false;
            Message();
            question.question_suivante(agenda.GetRendezVous()[nbRdv].GetComposante()); // Passer à la question suivante
            QuestionSuivante();
            FaireAvancerTemps();
            Attente();
        }
        else if (Input.IsActionJustPressed("AnswerRight") && !projetvisible && _textEdit.Visible)
        {
            MettreAJourJauges(J1, J2, J3, J4, question.getvaleur2); // Mettre à jour les jauges
            inQuestion = false;
            Message();
            question.question_suivante(agenda.GetRendezVous()[nbRdv].GetComposante()); // Passer à la question suivante
            QuestionSuivante();
            FaireAvancerTemps();
            Attente();
        }
    }

    public async void QuestionSuivante()
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

    public async void AfficherQuestionSuivante()
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

    public async Task AfficherMessageIntermediaire()
    {
        Affichage.EcrireTexte(_textEdit, question.GetRandomPhrase());
        buttonLeft.Visible = false;
        buttonRight.Visible = false;
        await ToSignal(GetTree().CreateTimer(1.5f), "timeout"); // Pause avant la question suivante
    }

    public async void FaireAvancerTemps()
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

    public async void Attente()
    {
        await ToSignal(GetTree().CreateTimer(2), "timeout");
        inQuestion = true;
        Message();
    }

    public void Message()
    {
        if (inQuestion && !textureRectpersonnage.Visible && !TextLabelordi.Visible)
        {
            textLabelmessage.Clear();
            textLabelmessage.BbcodeEnabled = true; // Active le mode BBCode
            textLabelmessage.Text = "\n\n";
            textLabelmessage.Text += $"[center][b][color=orange]Un rendez-vous vous attend avec {agenda.GetRendezVous()[nbRdv].ToString()}[/color][/b][/center]";
            textLabelmessage.Visible = true;
        }
        else if (inQuestion && textureRectpersonnage.Visible && !TextLabelordi.Visible)
        {
            textLabelmessage.Clear();
            textLabelmessage.BbcodeEnabled = true; // Active le mode BBCode
            textLabelmessage.Text = "\n";
            textLabelmessage.Text += $"[center][b][color=orange]Vous êtes en rendez-vous avec {agenda.GetRendezVous()[nbRdv].ToString()}[/color][/b][/center]";
            textLabelmessage.Text += $"[center][color=orange]\nEtat de la relation : {Affichage.Creationlien(agenda.GetRendezVous()[nbRdv].GetComposante())}[/color][/center]";
        }
        else
        {
            textLabelmessage.Clear();
            textLabelmessage.Visible = false;
        }
    }

    public void HandleResponse(Jauge J1, Jauge J2, Jauge J3, Jauge J4, bool isLeft)
    {
        if (isLeft)
        {
            MettreAJourJauges(J1, J2, J3, J4, question.getvaleur1); // Mettre à jour les jauges pour la réponse gauche
            Message();
        }
        else
        {
            MettreAJourJauges(J1, J2, J3, J4, question.getvaleur2); // Mettre à jour les jauges pour la réponse droite
            Message();
        }

        inQuestion = false;
        Message();
        question.question_suivante(agenda.GetRendezVous()[nbRdv].GetComposante()); // Passer à la question suivante
        QuestionSuivante();
        FaireAvancerTemps();
        Attente();
    }
}