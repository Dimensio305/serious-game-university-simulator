using Godot;
using System;

/// <summary>
/// Classe Tuto : Gère le tutoriel du jeu.
/// </summary>
public partial class Tuto : Node2D
{
	private TextureRect fonddirective;
	private TextureRect fondquestion;
	private TextureRect fondreponsegauche;
	private TextureRect fondreponsedroite;
	private TextureRect personnage;

	private RichTextLabel labelordi;
	private RichTextLabel labelquestion;
	private RichTextLabel labelreponsegauche;
	private RichTextLabel labelreponsedroite;
	private RichTextLabel labeldirective;

	private Button buttonRight;
	private Button buttonLeft;

	bool decouvrequestion = false;
	bool decouvreetat = false;
	bool decouvreagenda = false;
	bool decouvrereponsegauche = false;
	bool decouvrereponsedroite = false;

	bool inQuestion = false;

	int idmessage = 0;
	bool waitAction = false;

	private Jauge j1;
	private Jauge j2;
	private Jauge j3;
	private Jauge j4;

	/// <summary>
	/// Methode _Ready : Appelée lorsque le nœud est prêt.
	/// </summary>
	public override void _Ready()
	{
		fonddirective = GetNodeOrNull<TextureRect>("imagedirective");
		fondquestion = GetNodeOrNull<TextureRect>("fondquestion");
		fondreponsegauche = GetNodeOrNull<TextureRect>("Imagerepgauche");
		fondreponsedroite = GetNodeOrNull<TextureRect>("Imagerepdroite");
		personnage = GetNodeOrNull<TextureRect>("personnage");
		labelordi = GetNodeOrNull<RichTextLabel>("textlabelordi");
		labelquestion = GetNodeOrNull<RichTextLabel>("fondquestion/textquestion");
		labelreponsegauche = GetNodeOrNull<RichTextLabel>("Imagerepgauche/reponsegauche");
		labelreponsedroite = GetNodeOrNull<RichTextLabel>("Imagerepdroite/reponsedroite");
		labeldirective = GetNodeOrNull<RichTextLabel>("imagedirective/textlabedirective");
		j1 = GetNodeOrNull<Jauge>("Jauge1");
		j2 = GetNodeOrNull<Jauge>("Jauge2");
		j3 = GetNodeOrNull<Jauge>("Jauge3");
		j4 = GetNodeOrNull<Jauge>("Jauge4");

		buttonLeft = GetNode<Button>("Button1");
		buttonRight = GetNode<Button>("Button2");

		buttonLeft.Connect("pressed", Callable.From(boutonTuto));
		buttonRight.Connect("pressed", Callable.From(boutonTuto));

		fonddirective.Visible = true;
		labeldirective.Visible = true;
		//messadedepart();
	}

	/// <summary>
	/// Methode _Process : Appelée à chaque frame. 'delta' est le temps écoulé depuis le dernier frame.
	/// </summary>
	/// <param name="delta"></param>
	public override void _Process(double delta)
	{
		messageUpdate();
		if (!waitAction)
		{
			if (Input.IsActionJustPressed("LeftClick"))
			{
				idmessage++;
			}
		}
		else if (idmessage == 6)
		{
			if (Input.IsActionJustPressed("Question"))
			{
				waitAction = false;
				idmessage++;
			}
		}
		else if (idmessage == 9)
		{
			if (Input.IsActionJustPressed("AnswerLeft") || Input.IsActionJustPressed("AnswerRight"))
			{
				buttonLeft.Visible = false;
				buttonRight.Visible = false;
				fondquestion.Visible = false;
				j1.Modif(24);
				j2.Modif(-23);
				idmessage++;
				waitAction = false;
			}
		}
		else if (idmessage == 11)
		{
			if (Input.IsActionJustPressed("Etat"))
			{
				idmessage++;
			}
		}
		else if (idmessage == 12)
		{
			if (Input.IsActionJustPressed("agenda"))
			{
				waitAction = false;
				idmessage++;
			}
		}
	}


	private void afficherquestion()
	{
		fonddirective.Visible = false;
		string message = " Ici vont s'afficher les diffrente question des composante que vous aller rencontrer";
		labeldirective.Text = $"[center][b][color = black]{message}[/color][/b][/center]";

	}

	private void messageUpdate()
	{
		switch (idmessage)
		{
			case 0:
				labeldirective.Text = "[center][b][color=black]\nCoucou bienvenue dans university simulator[/color][/b][/center]";
				break;
			case 1:
				labeldirective.Text = "[center][b][color=black]\nLa clé de la réussite est de conserver un équilibre entre tes differentes ressources[/color][/b][/center]";
				break;
			case 2:
				labeldirective.Text = "[center][b][color=black]\nElles sont symbolysé par des jauges visible en bas de l'écran.[/color][/b][/center]";
				j1.Visible = true;
				j2.Visible = true;
				j3.Visible = true;
				j4.Visible = true;
				break;
			case 3:
				labeldirective.Text = "[center][b][color=black]Elles représentent dans l'ordre: Le budget, la Satisfaction du personnel, le taux d’insertion professionnel et le taux de réussite des étudiants[/color][/b][/center]";
				break;
			case 4:
				labeldirective.Text = "[center][b][color=black]\nChaque jour tu pourras constitué ton emplois du temps avec divers rendez-vous[/color][/b][/center]";
				break;
			case 5:
				labeldirective.Text = "[center][b][color=black]\nVous pouvez voir le prochain sur l'ordinateur[/color][/b][/center]";
				labelordi.Text = "[center][b][color=orange]Un rendez-vous vous attend avec (Muriel du Tutoriel)[/color][/b][/center]";
				labelordi.Visible = true;
				break;
			case 6:
				labeldirective.Text = "[center][b][color=black]\nPour faire entrer votre interlocuteur appuyez sur 'Q' ou faîte un clique droit[/color][/b][/center]";
				waitAction = true;
				break;
			case 7:
				labeldirective.Text = "[center][b][color=black]\nL'autre acteur du rendez-vous viendras alors[/color][/b][/center]";
				Affichage.ChangeImage("res://asset/acteurs/t3_character5.png", personnage);
				personnage.Visible = true;
				break;
			case 8:
				fonddirective.Visible = false;
				labelquestion.Text = "[center][b][color=black]Il te posera des questions sur des projets ou des situations[/color][/b][/center]";
				fondquestion.Visible = true;
				break;
			case 9:
				labelquestion.Text = "[center][b][color=black]Vous devrez alors répondre en cliquant sur la réponse souhaité (ou en utilisant les flèches droite et gauche du clavier)[/color][/b][/center]";
				buttonLeft.Visible = true;
				buttonRight.Visible = true;
				waitAction = true;
				break;
			case 10:
				fonddirective.Visible = true;
				labeldirective.Text = "[center][b][color=black]\nComme vous pouvez le voir les jauges de budget et de satisfaction des professeurs[/color][/b][/center]";
				break;
			case 11:
				fonddirective.Visible = true;
				labeldirective.Text = "[center][b][color=black]\nPour plus de détails, appuyer sur 'E' pour voir l'état précis de vos jauges[/color][/b][/center]";
				waitAction = true;
				break;
			case 12:
				labelordi.Text = pressEtatMessage();
				labelordi.Visible = true;
				labeldirective.Text = "[center][b][color=black]Parfait ! La dernière chose a savoir est qu'avec 'A' vous pouvez revoir votre agenda si vous l'avez oublié[/color][/b][/center]";
				break;
			case 13:
				labelordi.Text = pressAgendaMessage();
				labeldirective.Text = "[center][b][color=black]Vous avez désormais toute les connaissance pour vous débrouiller seul, vous aller pouvoir commencer votre semaine dans les meilleurs conditions[/color][/b][/center]";
				break;
			case 14:
				GetTree().ChangeSceneToFile("res://intermediaire/affichage_jour.tscn");
				break;
			default:
				labeldirective.Text = "[center][b][color=red]ERREUR : Message not found[/color][/b][/center]";
				break;
		}
	}
	private void boutonTuto()
	{
		buttonLeft.Visible = false;
		buttonRight.Visible = false;
		fondquestion.Visible = false;
		j1.Modif(24);
		j2.Modif(-23);
		idmessage++;
		waitAction = false;
	}


	private string pressEtatMessage()
	{

		string message = "[center][b][color=orange]Statistiques des ressources[/color][/b][/center]\n";
		message += "[center]=====================[/center]\n\n";
		message += "[b]Trésorerie :[/b] ";
		message += "[color=green]correcte[/color]. Elle est actuellement à 74%.\n";
		message += "\n[b]Satisfaction des professeurs :[/b] ";
		message += "[color=red]mauvaise[/color]. Bientôt ils décideront de faire grève. Elle est actuellement à 27%.\n";
		message += "\n[b]Taux d'insertion professionnelle :[/b] ";
		message += "[color=green]correcte[/color]. Il est actuellement à 50%.\n";
		message += "\n[b]Taux de réussite :[/b] ";
		message += "[color=green]correcte[/color]. Il est actuellement à 50%.\n";
		return message;
	}

	private string pressAgendaMessage()
	{

		string message;
		message = $"[center][b][color=orange]Agenda d'aujourd'hui[/color][/b][/center]\n";
		message += "[center]=====================[/center]\n\n";
		message += $"[color=orange][b]  - 08:00 - 10:00:[/b][/color] Présentation jauges\n";
		message += $"[color=orange][b]  - 10:00 - 12:00:[/b][/color] Tutoriel question\n";
		message += $"[color=orange][b]  - 14:00 - 16:00:[/b][/color] Tutoriel état\n";
		message += $"[color=orange][b]  - 16:00 - 18:00:[/b][/color] Tutoriel agenda\n";
		return message;


	}
}
