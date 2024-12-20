using Godot;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Net.Http;

/// <summary>
/// Classe Affichage : elle gere l'affichage dans different element du jeu
/// </summary>
public static class Affichage
{
	/// <summary>
	/// Méthode EcrireTexte : permet d'écrire un texte dans un TextEdit et de le rendre visible.
	/// </summary>
	/// <param name="textEdit">Paramètre 1 : Le TextEdit ciblé</param>
	/// <param name="texte">Paramètre 2 : Le message à écrire</param>
	public static void EcrireTexte(TextEdit textEdit, string texte)
	{

		if (textEdit != null)
		{
			textEdit.Clear();
			textEdit.Text = texte;
			textEdit.Visible = true;
		}
	}


	/// <summary>
	///  Methode AfficherAgenda : statique elle permet d'afficher les rdv 
	/// de la journée dans un texedit de maniere jolie </summary>
	/// <param name="rendezVousList"> Parametre 1 : La liste des rendez vous</param>
	/// <param name="textEdit"> Parametre 2 : La textedit visé</param>
	public static void AfficherAgenda(List<Rendezvous> rendezVousList, RichTextLabel textEdit)
	{
		textEdit.Text = "";
		textEdit.BbcodeEnabled = true; // Active le mode BBCode

		string nomJour = Jour.Instance.GetNom();

		textEdit.Text += $"[center][b][color=orange]Agenda de {nomJour}[/color][/b][/center]\n";
		textEdit.Text += "[center]=====================[/center]\n\n";

		TimeSpan[] debutCreneaux = {
		new TimeSpan(8, 0, 0),  // 8h à 10h
		new TimeSpan(10, 0, 0), // 10h à 12h
		new TimeSpan(14, 0, 0), // 14h à 16h
		new TimeSpan(16, 0, 0)  // 16h à 18h
	};

		TimeSpan dureeCreneau = new TimeSpan(2, 0, 0); // Chaque créneau dure 2 heures

		// Afficher les rendez-vous pour chaque créneau
		for (int i = 0; i < debutCreneaux.Length; i++)
		{
			if (i < rendezVousList.Count)
			{
				Rendezvous rdv = rendezVousList[i];
				TimeSpan debut = debutCreneaux[i];
				TimeSpan fin = debut + dureeCreneau;

				textEdit.Text += $"[color=orange][b]  - {debut:hh\\:mm} - {fin:hh\\:mm}:[/b][/color] {rdv.Description}\n";
			}
			else // s'il n'y a pas de rdv
			{
				TimeSpan debut = debutCreneaux[i];
				TimeSpan fin = debut + dureeCreneau;

				textEdit.Text += $"[color=red][b]  - {debut:hh\\:mm} - {fin:hh\\:mm}:[/b][/color] Aucun rendez-vous\n";
			}
		}

		textEdit.Visible = true;
	}

	/// <summary>
	/// Méthode AfficherProjets : statique elle permet d'afficher les projets dans un TextEdit
	/// </summary>
	/// <param name="projets"> Parametre 1: Liste de projets</param>
	/// <param name="textEditProjets"> Parametre 2 :TextEdit dans lequel afficher les projets</param>
	public static void AfficherProjets(List<Projet> projets, TextEdit textEditProjets)
	{
		textEditProjets.Clear();

		textEditProjets.Editable = false;

		for (int i = 0; i < projets.Count; i++)
		{
			textEditProjets.Text += $"{i + 1}. {projets[i]}\n\n";
		}

		textEditProjets.Visible = true;
	}

	/// <summary>
	///  Méthode AfficherFormations : statique elle affiche les rendez-vous dans un TextEdit
	/// </summary>
	/// <param name="formations"> Parametre 1 : Liste de formations</param>
	/// <param name="textEditFormations"> Parametre 2 : TextEdit dans lequel afficher les formations</param>
	/// <param name="panel"></param> Parametre 3 : panel contenant le textedit <summary>
	/// </summary>
	public static void AfficherFormations(List<Formation> formations, TextEdit textEditFormations, Panel panel)
	{

		textEditFormations.Clear();
		textEditFormations.Editable = false;


		if (formations.Count == 0)
		{
			textEditFormations.Text = "Aucune formation disponible pour le moment.";
		}
		else
		{

			for (int i = 0; i < formations.Count; i++)
			{
				textEditFormations.Text += $"Formation #{i + 1} :\n";
				textEditFormations.Text += $"{formations[i]}\n\n";
			}
		}


		panel.Visible = true;
		textEditFormations.Visible = true;
	}

	/// <summary>
	/// Méthode FinDuJeu : Méthode statique qui permet de passer à la scène de fin
	/// lorsqu'une condition de fin de jeu est atteinte.
	/// </summary>
	/// <param name="j1">Paramètre 1 : Première jauge à surveiller.</param>
	/// <param name="j2">Paramètre 2 : Deuxième jauge à surveiller.</param>
	/// <param name="j3">Paramètre 3 : Troisième jauge à surveiller.</param>
	/// <param name="j4">Paramètre 4 : Quatrième jauge à surveiller.</param>
	/// <param name="context">Paramètre 6 : Nœud appelant la fonction, utilisé pour changer la scène.</param>
	public static void FinDuJeu(Jauge j1, Jauge j2, Jauge j3, Jauge j4, Node context)
	{
		if (j1.GetValeur() == 0 || j2.GetValeur() == 0 || j3.GetValeur() == 0 || j4.GetValeur() == 0)
		{
			context.GetTree().ChangeSceneToFile("res://Jeu_court/finduJeu.tscn");
		}
	}

	/// <summary>
	/// Méthode statique ChangeImage : change l'image affichée dans un TextureRect.
	/// </summary>
	/// <param name="imagePath">Paramètre 1 : Le chemin de l'image à charger</param>
	/// <param name="textureRect">Paramètre 2 : Le TextureRect dans lequel afficher l'image</param>
	public static void ChangeImage(string imagePath, TextureRect textureRect)
	{
		if (textureRect != null)
		{
			// Charge la nouvelle texture à partir du fichier
			var newTexture = (Texture)ResourceLoader.Load(imagePath);
			if (newTexture != null)
			{
				textureRect.Texture = (Texture2D)newTexture;
			}
			else
			{
				GD.PrintErr($"Failed to load texture from path: {imagePath}");
			}
		}
	}

	/// <summary>
	/// Méthode creationlien : calcule une moyenne basée sur les valeurs des jauges 
	/// et retourne un message en fonction de la valeur calculée.
	/// </summary>
	/// <param name="composanteID">Paramètre 1 : L'identifiant de la composante à traiter</param>
	/// <returns> Retourne : Un message décrivant l'état de la relation basé sur la valeur calculée</returns>
	public static string Creationlien(int composanteID)
	{
		int val = 0;
		string message;

		switch (composanteID)
		{
			case 1:
				val = JaugeManager.GetJaugeValue("Jauge1") + JaugeManager.GetJaugeValue("Jauge2") + JaugeManager.GetJaugeValue("Jauge3");
				val /= 3;
				break;
			case 2:
				val = JaugeManager.GetJaugeValue("Jauge2") + JaugeManager.GetJaugeValue("Jauge4");
				val /= 2;
				break;
			case 3:
				val = JaugeManager.GetJaugeValue("Jauge1");
				break;
			case 4:
				val = JaugeManager.GetJaugeValue("Jauge2") + JaugeManager.GetJaugeValue("Jauge4");
				val /= 2;
				break;
			case 5:
				val = JaugeManager.GetJaugeValue("Jauge2") + JaugeManager.GetJaugeValue("Jauge3");
				val /= 2;
				break;
			case 6:
				val = JaugeManager.GetJaugeValue("Jauge2") + JaugeManager.GetJaugeValue("Jauge4");
				val /= 2;
				break;
			case 7:
				val = JaugeManager.GetJaugeValue("Jauge1") + JaugeManager.GetJaugeValue("Jauge3");
				val /= 2;
				break;
			case 8:
				val = JaugeManager.GetJaugeValue("Jauge1") + JaugeManager.GetJaugeValue("Jauge4");
				val /= 2;
				break;
			case 9:
				val = JaugeManager.GetJaugeValue("Jauge2") + JaugeManager.GetJaugeValue("Jauge4");
				val /= 2;
				break;
			case 10:
				val = JaugeManager.GetJaugeValue("Jauge2") + JaugeManager.GetJaugeValue("Jauge4") + JaugeManager.GetJaugeValue("Jauge3");
				val /= 3;
				break;
			case 11:
				val = JaugeManager.GetJaugeValue("Jauge2") + JaugeManager.GetJaugeValue("Jauge4");
				val /= 2;
				break;
		}

		if (val >= 80)
		{
			message = "Vous etes un peu trop proche";
		}
		else if (val <= 30)
		{
			message = "Vous devriez reprendre contact";
		}
		else
		{
			message = "Bonne relation continuez ainsi";
		}

		return message;
	}

	/// <summary>
	/// Méthode AffichageEtat : Affiche les états des jauges sous forme de texte formaté
	/// dans un label, avec un message adapté à la valeur de chaque jauge.
	/// </summary>
	/// <param name="richTextLabel">Paramètre 1 : Le label sur lequel le texte formaté sera affiché.</param>
	public static void AffichageEtat(RichTextLabel richTextLabel)
	{
		richTextLabel.Text = ""; // Nettoie le contenu actuel
		richTextLabel.BbcodeEnabled = true; // Active le mode BBCode

		string message = "[center][b][color=orange]Statistiques des ressources[/color][/b][/center]\n";
		message += "[center]=====================[/center]\n\n";

		// Trésorerie
		int jauge1 = JaugeManager.GetJaugeValue("Jauge1");
		message += "[b]Trésorerie :[/b] ";
		if (jauge1 < 80 && jauge1 > 30)
		{
			message += "[color=#1d7b16]correcte[/color]. Elle est actuellement à " + jauge1 + "%.\n";
		}
		else if (jauge1 <= 30)
		{
			message += "[color=red]mauvaise[/color]. Bientôt vous ne pourrez plus entretenir vos formations. Elle est actuellement à " + jauge1 + "%.\n";
		}
		else
		{
			message += "[color=red]trop bonne[/color]. Vous devriez investir dans vos formations. Elle est actuellement à " + jauge1 + "%.\n";
		}

		// Satisfaction des professeurs
		int jauge2 = JaugeManager.GetJaugeValue("Jauge2");
		message += "\n[b]Satisfaction des professeurs :[/b] ";
		if (jauge2 < 80 && jauge2 > 30)
		{
			message += "[color=#1d7b16]correcte[/color]. Elle est actuellement à " + jauge2 + "%.\n";
		}
		else if (jauge2 <= 30)
		{
			message += "[color=red]mauvaise[/color]. Bientôt ils décideront de faire grève. Elle est actuellement à " + jauge2 + "%.\n";
		}
		else
		{
			message += "[color=red]trop bonne[/color]. Ils seront trop heureux de venir travailler. Elle est actuellement à " + jauge2 + "%.\n";
		}

		// Taux d'insertion professionnelle
		int jauge3 = JaugeManager.GetJaugeValue("Jauge3");
		message += "\n[b]Taux d'insertion professionnelle :[/b] ";
		if (jauge3 < 80 && jauge3 > 30)
		{
			message += "[color=#1d7b16]correcte[/color]. Il est actuellement à " + jauge3 + "%.\n";
		}
		else if (jauge3 <= 30)
		{
			message += "[color=red]mauvais[/color]. Ils finiront tous au chômage. Il est actuellement à " + jauge3 + "%.\n";
		}
		else
		{
			message += "[color=red]excellent[/color]. Il n'y aura plus de chômeurs. Il est actuellement à " + jauge3 + "%.\n";
		}

		// Taux de réussite
		int jauge4 = JaugeManager.GetJaugeValue("Jauge4");
		message += "\n[b]Taux de réussite :[/b] ";
		if (jauge4 < 80 && jauge4 > 30)
		{
			message += "[color=#1d7b16]correcte[/color]. Il est actuellement à " + jauge4 + "%.\n";
		}
		else if (jauge4 <= 30)
		{
			message += "[color=red]mauvais[/color]. Ils vont tous redoubler, ce qui coûtera cher. Il est actuellement à " + jauge4 + "%.\n";
		}
		else
		{
			message += "[color=red]trop bon[/color]. Il faudrait quand même des élèves moyens. Il est actuellement à " + jauge4 + "%.\n";
		}

		richTextLabel.Text = message; // Attribue le texte formaté
		richTextLabel.Visible = true;
	}

	/// <summary>
	/// Méthode AffichageEtatJour : Affiche un récapitulatif détaillé des jauges pour la journée,
	/// avec les valeurs du matin, les valeurs actuelles, et les variations entre les deux.
	/// </summary>
	/// <param name="richTextLabel">Paramètre 1 : Le label sur lequel le texte formaté sera affiché.</param>
	public static void AffichageEtatJour(RichTextLabel richTextLabel)
	{
		// Nettoyer et activer le BBCode
		richTextLabel.BbcodeEnabled = true;
		string message = "\n\n\n";

		// Début du message
		message += "[center][b][color=orange]Récapitulatif de la journée[/color][/b][/center]\n";
		message += "[center][color=orange]=====================================[/color][/center]\n\n";

		// Trésorerie
		int jauge1debut = JaugeManager.GetJaugeValueMatin("Jauge1");
		int jauge1 = JaugeManager.GetJaugeValue("Jauge1");
		int difference1 = jauge1 - jauge1debut;
		string variation1 = difference1 > 0
			? $"[color=#1d7b16]+{difference1}%[/color]"
			: $"[color=red]{difference1}%[/color]";
		message += "[b][color=#744116]Trésorerie :[/color][/b] ";
		if (jauge1 < 80 && jauge1 > 30)
		{
			message += "[color=#1d7b16]correcte[/color].\n";
		}
		else if (jauge1 <= 30)
		{
			message += "[color=red]mauvaise[/color]. \n[color=#744116]Bientôt vous ne pourrez plus entretenir vos formations.[/color]\n";
		}
		else
		{
			message += "[color=red]trop bonne[/color]. \n[color=#744116]Vous devriez investir dans vos formations.[/color]\n";
		}
		message += $"[b][color=#744116]Valeur du matin :[/color][/b] {jauge1debut}%, [b][color=#744116]Actuelle :[/color][/b] {jauge1}%, [b][color=#744116]Variation :[/color][/b] {variation1}\n\n";

		// Satisfaction des professeurs
		int jauge2debut = JaugeManager.GetJaugeValueMatin("Jauge2");
		int jauge2 = JaugeManager.GetJaugeValue("Jauge2");
		int difference2 = jauge2 - jauge2debut;
		string variation2 = difference2 > 0
			? $"[color=#1d7b16]+{difference2}%[/color]"
			: $"[color=red]{difference2}%[/color]";
		message += "[b][color=#744116]Satisfaction des professeurs :[/color][/b] ";
		if (jauge2 < 80 && jauge2 > 30)
		{
			message += "[color=#1d7b16]correcte[/color].\n";
		}
		else if (jauge2 <= 30)
		{
			message += "[color=red]mauvaise[/color]. \n[color=#744116]Bientôt ils décideront de faire grève.[/color]\n";
		}
		else
		{
			message += "[color=red]trop bonne[/color]. \n[color=#744116]Ils seront trop heureux de venir travailler.[/color]\n";
		}
		message += $"[b][color=#744116]Valeur du matin :[/color][/b] {jauge2debut}%, [b][color=#744116]Actuelle :[/color][/b] {jauge2}%, [b][color=#744116]Variation :[/color][/b] {variation2}\n\n";

		// Taux d'insertion professionnelle
		int jauge3debut = JaugeManager.GetJaugeValueMatin("Jauge3");
		int jauge3 = JaugeManager.GetJaugeValue("Jauge3");
		int difference3 = jauge3 - jauge3debut;
		string variation3 = difference3 > 0
			? $"[color=#1d7b16]+{difference3}%[/color]"
			: $"[color=red]{difference3}%[/color]";
		message += "[b][color=#744116]Taux d'insertion professionnelle :[/color][/b] ";
		if (jauge3 < 80 && jauge3 > 30)
		{
			message += "[color=#1d7b16]correcte[/color].\n";
		}
		else if (jauge3 <= 30)
		{
			message += "[color=red]mauvais[/color]. \n[color=#744116]Ils finiront tous au chômage.[/color]\n";
		}
		else
		{
			message += "[color=red]excellent[/color]. \n[color=#744116]Il n'y aura plus de chômeurs.[/color]\n";
		}
		message += $"[b][color=#744116]Valeur du matin :[/color][/b] {jauge3debut}%, [b][color=#744116]Actuelle :[/color][/b] {jauge3}%, [b][color=#744116]Variation :[/color][/b] {variation3}\n\n";

		// Taux de réussite
		int jauge4debut = JaugeManager.GetJaugeValueMatin("Jauge4");
		int jauge4 = JaugeManager.GetJaugeValue("Jauge4");
		int difference4 = jauge4 - jauge4debut;
		string variation4 = difference4 > 0
			? $"[color=#1d7b16]+{difference4}%[/color]"
			: $"[color=red]{difference4}%[/color]";
		message += "[b][color=#744116]Taux de réussite :[/color][/b] ";
		if (jauge4 < 80 && jauge4 > 30)
		{
			message += "[color=#1d7b16]correcte[/color].\n";
		}
		else if (jauge4 <= 30)
		{
			message += "[color=red]mauvais[/color]. \n[color=#744116]Ils vont tous redoubler, ce qui coûtera cher.[/color]\n";
		}
		else
		{
			message += "[color=red]trop bon[/color]. \n[color=#744116]Il faudrait quand même des élèves moyens.[/color]\n";
		}
		message += $"[b][color=#744116]Valeur du matin :[/color][/b] {jauge4debut}%, [b][color=#744116]Actuelle :[/color][/b] {jauge4}%, [b][color=#744116]Variation :[/color][/b] {variation4}\n\n";

		// Fin du message
		message += "[center][color=orange]=====================================[/color][/center]\n";
		message = $"[center]{message}[/center]";
		richTextLabel.Text = message; // Attribue le texte formaté
		richTextLabel.Visible = true;
	}
}
