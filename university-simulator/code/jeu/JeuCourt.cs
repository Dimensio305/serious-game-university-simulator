using System;
using Godot;

public class JeuCourt : Node
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
    private JeuFacade _jeuFacade;

    public override void _Ready()
    {
        // Initialisation des composants
        _textEdit = GetNode<TextEdit>("rectquestion/TextEdit");
        _textEdit.Visible = false;
        panel = GetNode<Panel>("panel");
        proj = GetNode<TextEdit>("proj");
        textureRectpersonnage = GetNode<TextureRect>("personnage");
        projets = Projet.GenererProjetsAleatoires();
        agenda = new Agenda();
        horloge = GetNode<TextEdit>("Horloge/horloge");
        textLabelmessage = GetNode<RichTextLabel>("TextLabelmessage");
        recQuestion = GetNodeOrNull<TextureRect>("rectquestion");
        TextLabelordi = GetNode<RichTextLabel>("TextLabelordi");
        buttonLeft = GetNode<Button>("_b_reponse_gauche");
        buttonRight = GetNode<Button>("_b_reponse_droite");
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

        // Initialisation de la façade
        _jeuFacade = new JeuFacade(_textEdit, buttonLeft, buttonRight, agenda, nbRdv, textureRectpersonnage,
                                    textLabelmessage, Jauge1, Jauge2, Jauge3, Jauge4, TextLabelordi,
                                    horloge, heure, minute, panel, proj, projetvisible, projets,
                                    img, messagefin, recQuestion, question, nbquestion);

        Attente();
    }

    public override void _Process(double delta)
    {
        recQuestion.Visible = _textEdit.Visible;
        if (inQuestion)
        {
            _jeuFacade.AfficherQuestion(question);
            _jeuFacade.GereReponse(Jauge1, Jauge2, Jauge3, Jauge4);
        }

        if (Input.IsActionJustPressed("agenda"))
        {
            _jeuFacade.RendreVisibleAgenda();
        }

        if (Input.IsActionJustPressed("Etat"))
        {
            _jeuFacade.RendreEtatVisible();
        }

        if (Input.IsActionPressed("fermer"))
        {
            _jeuFacade.CacherElements();
        }

        Affichage.FinDuJeu(Jauge1, Jauge2, Jauge3, Jauge4, this);
    }

    private void OnButtonLeftPressed()
    {
        _jeuFacade.HandleResponse(Jauge1, Jauge2, Jauge3, Jauge4, true);
    }

    private void OnButtonRightPressed()
    {
        _jeuFacade.HandleResponse(Jauge1, Jauge2, Jauge3, Jauge4, false);
    }
}