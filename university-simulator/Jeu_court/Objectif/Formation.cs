using System;
using System.Collections.Generic;
using Godot;

/// <summary>
/// classe gerant ce qui se passe autour des formation (creation, etc ...)
/// </summary>
public class Formation
{
	/// <summary>
	/// Nom de la formation.
	/// </summary>
	/// <value>Le nom de la formation.</value>
	public string Nom { get; private set; }

	/// <summary>
	/// Option associée à la formation.
	/// </summary>
	/// <value>Le nom de l'option.</value>
	public string Option { get; private set; }

	/// <summary>
	/// Effectif total de la formation.
	/// </summary>
	/// <value>Le nombre d'étudiants dans la formation.</value>
	public int Effectif { get; private set; }

	/// <summary>
	/// Nombre d'élèves réellement inscrits dans la formation.
	/// </summary>
	/// <value>Le nombre d'élèves inscrits.</value>
	public int Eleve { get; private set; }

	/// <summary>
	/// Budget alloué à la formation.
	/// </summary>
	/// <value>Le montant du budget en unités monétaires.</value>
	public int Budget { get; private set; }

	/// <summary>
	/// Indice statique utilisé pour générer les formations séquentiellement.
	/// </summary>
	public static int index = 1;

	/// <summary>
	/// Constructeur de la classe Formation.
	/// </summary>
	/// <param name="nom">Nom de la formation.</param>
	/// <param name="effectif">Effectif total de la formation.</param>
	/// <param name="eleve">Nombre d'élèves inscrits dans la formation.</param>
	/// <param name="budget">Budget alloué à la formation.</param>
	/// <param name="option">Option associée à la formation.</param>
	public Formation(string nom, int effectif, int eleve, int budget, string option)
	{
		Nom = nom;
		Effectif = effectif;
		Eleve = eleve;
		Budget = budget;
		Option = option;
	}

	/// <summary>
	/// Obtient l'indice actuel utilisé pour générer les formations.
	/// </summary>
	/// <returns>L'indice actuel.</returns>
	private static int getindex()
	{
		return index;
	}

	/// <summary>
	/// Définit une nouvelle valeur pour l'indice utilisé dans la génération des formations.
	/// </summary>
	/// <param name="value">La nouvelle valeur de l'indice.</param>
	private static void setindex(int value)
	{
		index = value;
	}

	/// <summary>
	/// Génère une nouvelle instance de la classe Formation à partir de la base de données.
	/// </summary>
	/// <returns>Une instance de la classe Formation remplie avec les données de la base de données.</returns>
	static public Formation genereformation()
	{
		int index = getindex();
		GD.Print("Entrer dans genereformation");
		string n = GestionDb.Instance.ExecuteRequete("select nom from Formation where idformation = " + index.ToString() + ";");
		GD.Print(n);
		int e = Convert.ToInt32(GestionDb.Instance.ExecuteRequete("select effectif from Formation where idformation = " + index.ToString() + ";"));
		GD.Print(e);
		int el = Convert.ToInt32(GestionDb.Instance.ExecuteRequete("select eleve from Formation where idformation = " + index.ToString() + ";"));
		GD.Print(el);
		int b = Convert.ToInt32(GestionDb.Instance.ExecuteRequete("select budget from Formation where idformation = " + index.ToString() + ";"));
		GD.Print(b);
		string o = GestionDb.Instance.ExecuteRequete("select Opt from Formation where idformation = " + index.ToString() + ";");
		GD.Print(o);
		setindex(index + 1);
		return new Formation(n, e, el, b, o);
	}

	/// <summary>
	/// Renvoie une chaîne représentant les informations de la formation.
	/// </summary>
	/// <returns>Les détails de la formation sous forme de chaîne.</returns>
	public override string ToString()
	{
		return $"Formation : {Nom}\n" +
			   $"Option : {Option}\n" +
			   $"Effectif : {Effectif}\n" +
			   $"Élèves : {Eleve}\n" +
			   $"Budget : {Budget:C}"; // Format monétaire pour le budget
	}
}
