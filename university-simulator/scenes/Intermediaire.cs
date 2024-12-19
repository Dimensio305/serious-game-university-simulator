using Godot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Threading.Tasks;

/// <summary>
/// Classe intermedaire : représentant un intermédiaire pour gérer les rendez-vous.
/// Elle permet de déplacer des rendez-vous entre deux cibles et de vérifier si l'utilisateur a bien pris ses rendez-vous.
/// </summary>
public partial class Intermediaire : Node2D
{
	private TextureRect _target1;
	private TextureRect _target2;
	private TextEdit message;

	// Liste statique pour stocker les rendez-vous finalisés
	private static List<Rendezvous> rdvfin = new List<Rendezvous>();

	// Liste pour stocker les rendez-vous de début
	private List<Rendezvous> rdvdebut = new List<Rendezvous>();

	private List<Rendezvous> vide = new List<Rendezvous>();
		
	/// <summary>
	/// Méthode ready : appelée lors de l'initialisation du nœud. 
	/// Elle configure les cibles et les messages et génère les rendez-vous aléatoires.
	/// </summary>
	public override void _Ready()
	{
		rdvfin = vide;
		// Récupération des cibles
		_target1 = GetNode<TextureRect>("case_gauche");
		_target2 = GetNode<TextureRect>("case_droite");
		message = GetNode<TextEdit>("message");

		// Connecte les événements d'input aux enfants des cibles
		ConnectGuiInputToChildren(_target1);
		ConnectGuiInputToChildren(_target2);

		// Génère des rendez-vous aléatoires et les ajoute à la liste de départ
		for (int nbrdv = 0; nbrdv < 6; nbrdv++)
		{
			Rendezvous nouveauRdv = Rendezvous.GenererRendezVousAleatoire(nbrdv);

			// Vérifie si un rendez-vous similaire existe déjà, sinon l'ajoute à la liste
			while (rdvdebut.Any(rdv => rdv.composante == nouveauRdv.composante))
			{
				nouveauRdv = Rendezvous.GenererRendezVousAleatoire(nbrdv);
			}

			rdvdebut.Add(nouveauRdv);
		}

		// Remplie les TextEdit des cibles avec les rendez-vous de début
		int i = 0;
		foreach (Node child in _target1.GetChildren())
		{
			if (child is RichTextLabel textEdit)
			{
				textEdit.BbcodeEnabled = true; // Active le mode BBCode

				// Exemple de rendez-vous
				string rdv = rdvdebut[i].ToString();
				string lien = affichage.creationlien(rdvdebut[i].getComposante());

				// Ajouter des bordures et des styles
				textEdit.Text = $"[b]{rdv}[/b]\n";
				textEdit.Text += $"{lien}\n";
				textEdit.Text = $"[center]{textEdit.Text}[/center]";


				i++;
			}
		}
	}

	/// <summary>
	/// Methode statique GetRdvFin : Récupère la liste des rendez-vous finalisés.
	/// </summary>
	/// <returns>Liste des rendez-vous finalisés.</returns>
	public static List<Rendezvous> GetRdvFin()
	{
		return rdvfin;
	}

	/// <summary>
	/// Methode ConnectGuiInputToChildren : Connecte l'événement d'input GUI aux enfants de la cible donnée.
	/// </summary>
	/// <param name="target">Retourne : La cible à laquelle connecter les événements d'input.</param>
	private void ConnectGuiInputToChildren(TextureRect target)
	{
		foreach (Node child in target.GetChildren())
		{
			if (child is RichTextLabel textEdit)
			{
				textEdit.Connect("gui_input", Callable.From((InputEvent inputEvent) => OnGuiInput(inputEvent, textEdit)));
			}
		}
	}

	/// <summary>
	/// Methode OnGuiInput: Gère l'événement d'input GUI pour déplacer un TextEdit entre les cibles.
	/// </summary>
	/// <param name="inputEvent">Parametre 1:L'événement d'input reçu.</param>
	/// <param name="clickedTextEdit">Parametre 2: Le TextEdit cliqué.</param>
	private void OnGuiInput(InputEvent inputEvent, RichTextLabel clickedTextEdit)
	{
		
		int textEditCount = 0;
		foreach (Node child in _target2.GetChildren())
		{
			if (child is RichTextLabel)
			{
				textEditCount++;
			}
		}
		// Si un clic gauche est effectué, déplace le TextEdit vers la cible opposée
		if (inputEvent is InputEventMouseButton mouseEvent && mouseEvent.Pressed && mouseEvent.ButtonIndex == MouseButton.Left)
		{
			TextureRect destination = clickedTextEdit.GetParent() == _target1 ? _target2 : _target1;
			if(destination ==_target2){
				if(textEditCount<4){
					MoveTextEditToTarget(clickedTextEdit, destination);
				}
			}
			else{
				MoveTextEditToTarget(clickedTextEdit, destination);
			}
		}
	}

	/// <summary>
	/// Methode MoveTextEditToTarget : Déplace un TextEdit d'une cible à l'autre et réorganise les enfants dans la colonne.
	/// </summary>
	/// <param name="textEdit">Parametre 1 : Le TextEdit à déplacer.</param>
	/// <param name="target">Parametre 2 : La cible où déplacer le TextEdit.</param>
	private void MoveTextEditToTarget(RichTextLabel textEdit, TextureRect target)
	{
		List<Rendezvous> sourceList = textEdit.GetParent() == _target1 ? rdvdebut : rdvfin;
		List<Rendezvous> targetList = target == _target1 ? rdvdebut : rdvfin;

		int id;
		// Vérifie si l'ID du rendez-vous peut être extrait et récupère le rendez-vous correspondant
		if (int.TryParse(textEdit.Name, out id))
		{
			Rendezvous rendezvous = sourceList.Find(rdv => rdv.getId() == id);
			if (rendezvous != null)
			{
				// Déplace le rendez-vous dans la liste cible
				sourceList.Remove(rendezvous);
				targetList.Add(rendezvous);
			}
		}

		// Déplace le TextEdit dans la cible et réorganise les enfants
		textEdit.GetParent().RemoveChild(textEdit);
		target.AddChild(textEdit);
		ReorganizeChildrenInColumn(target);
	}

	/// <summary>
	/// Methode ReorganizeChildrenInColumn :Réorganise les enfants d'une cible en colonne pour un affichage ordonné.
	/// </summary>
	/// <param name="target">Parametre 1 : La cible à réorganiser.</param>
	private void ReorganizeChildrenInColumn(TextureRect target)
	{
		float yOffset = 10;
		float currentY = 80;

		// Ajuste la position verticale de chaque enfant dans la cible
		foreach (Node child in target.GetChildren())
		{
			if (child is Control control)
			{
				control.Position = new Vector2(45, currentY);
				currentY += control.Size.Y + yOffset;
			}
		}
	}

	/// <summary>
	/// Methode  _on_valider_pressed: ère l'action lorsque le bouton "Valider" est pressé. Vérifie si 4 rendez-vous ont été choisis.
	/// </summary>
	public async void _on_valider_pressed()
	{
		int textEditCount = 0;
		foreach (Node child in _target2.GetChildren())
		{
			if (child is RichTextLabel)
			{
				textEditCount++;
			}
		}

		// Si 4 rendez-vous ont été choisis, change de scène, sinon affiche un message d'erreur
		if (textEditCount == 4)
		{
			message.Text = "Les rendez-vous sont bien pris en compte.";
			message.Visible = true;

			await Task.Delay(1500);

			GetTree().ChangeSceneToFile("res://Jeu_court/jeu_court.tscn");
		}
		else
		{
			message.Visible = true;
			message.Text = "Il faut choisir 4 rendez-vous.";
			await Task.Delay(1500);
			message.Visible = false;
		}
	}

	/// <summary>
	/// Methode _on_reset_pressed :Réinitialise l'état en déplaçant tous les TextEdit de la cible 2 vers la cible 1.
	/// </summary>
	public void _on_reset_pressed()
	{
		
		foreach (Node child in _target2.GetChildren())
		{
			if (child is RichTextLabel textedit)
			{
				MoveTextEditToTarget(textedit, _target1);
			}
		}
	}
}
