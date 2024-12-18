using System;
using Godot;

/// <summary>
/// Classe représentant un jour. Instance unique .
/// </summary>
public class Jour
{
	/// <summary>
	/// Champ privé statique pour stocker l'instance unique de la classe Jour.
	/// </summary>
	private static Jour _instance;

	/// <summary>
	///Attribut nb: Numéro du jour, initialisé à 0 (Lundi).
	/// </summary>
	private int nb = 0;

	/// <summary>
	///Attribut nom : Nom du jour correspondant, initialisé à "Lundi".
	/// </summary>
	private string nom = "Lundi";

	/// <summary>
	/// Constructeur privé pour empêcher la création d'instances externes.
	/// </summary>
	private Jour() {}

	/// <summary>
	/// Propriété statique permettant d'accéder à l'instance unique de la classe Jour.
	/// Si l'instance n'existe pas encore, elle est créée.
	/// </summary>
	public static Jour Instance
	{
		get
		{
			if (_instance == null)
			{
				_instance = new Jour();
			}
			return _instance;
		}
	}

	/// <summary>
	/// Methode setJour :Définit le jour actuel en fonction de son numéro et met à jour le nom du jour.
	/// </summary>
	/// <param name="j">Prametre 1 : Numéro du jour (0 pour Lundi, 1 pour Mardi, etc.).</param>
	private void setjour(int j)
	{
		this.nb = j;

		switch (j)
		{
			case 0:
				nom = "Lundi";
				break;
			case 1:
				nom = "Mardi";
				break;
			case 2:
				nom = "Mercredi";
				break;
			case 3:
				nom = "Jeudi";
				break;
			case 4:
				nom = "Vendredi";
				break;
			case 5:
				nom = "Samedi";
				break;
			default:
				nom = "Invalide"; // Gestion des valeurs hors plage.
				break;
		}
	}

	/// <summary>
	///Methode Joursuivant: Passe au jour suivant. Si le jour actuel est Vendredi (5), retourne à Lundi (0).
	/// </summary>
	public void Joursuivant()
	{
		if (nb == 5)
		{
			setjour(0);
		}
		else
		{
			setjour(nb + 1);
		}
	}

	/// <summary>
	/// Methode GetJour : Retourne le numéro du jour actuel.
	/// </summary>
	/// <returns>Retourne : Numéro du jour actuel.</returns>
	public int GetJour()
	{
		return this.nb;
	}

	/// <summary>
	///Methode GetNom : Retourne le nom du jour actuel.
	/// </summary>
	/// <returns>Retourne :Nom du jour actuel.</returns>
	public string GetNom()
	{
		return this.nom;
	}
}
