using System;
using Godot;

/// <summary>
/// classe gerant ce qui se passe autour des formation (creation, etc ...)
/// </summary>
public class Formation
{
	/// <summary>
	/// Attribut nom 
	/// </summary>
	/// <value>Le nom de la formation.</value>
	public string Nom { get; private set; }

	/// <summary>
	/// Attribut Option 
	/// </summary>
	/// <value>Parcours associé a la formation</value>
	public string Option { get; private set; }

	/// <summary>
	/// Attribut effectif 
	/// </summary>
	/// <value>Le nombre d'enseignant dans la formation.</value>
	public int Effectif { get; private set; }

	/// <summary>
	/// Attribut Eleve
	/// </summary>
	/// <value>Le nombre d'élèves inscrits.</value>
	public int Eleve { get; private set; }

	/// <summary>
	/// Attribut Budget
	/// </summary>
	/// <value>Le montant du budget en euros.</value>
	public int Budget { get; private set; }

	/// <summary>
	/// Indice static index : utilisé pour générer les formations séquentiellement.
	/// </summary>
	private static int index = 1;

	/// <summary>
	/// Constructeur de la classe Formation.
	/// </summary>
	/// <param name="nom">Parametre 1 : Nom de la formation.</param>
	/// <param name="effectif">Parametre 2 : Effectif total de la formation.</param>
	/// <param name="eleve">Parametre 3 : Nombre d'élèves inscrits dans la formation.</param>
	/// <param name="budget">Parametre 4 : Budget alloué à la formation.</param>
	/// <param name="option">Parametre 5 : Option associée à la formation.</param>
	public Formation(string nom, int effectif, int eleve, int budget, string option)
	{
		Nom = nom;
		Effectif = effectif;
		Eleve = eleve;
		Budget = budget;
		Option = option;
	}

	/// <summary>
	/// Methode statique getindex : Obtient l'indice actuel utilisé pour générer les formations.
	/// </summary>
	/// <returns>L'indice actuel.</returns>
	private static int getIndex()
	{
		return index;
	}

	/// <summary>
	/// Methode statique setindex : Définit une nouvelle valeur pour l'indice utilisé dans la génération des formations.
	/// </summary>
	/// <param name="value">La nouvelle valeur de l'indice.</param>
	private static void setIndex(int value)
	{
		index = value;
	}

	/// <summary>
	/// Methode GenereFormation : Génère une nouvelle formation à partir des données de la base de données.
	/// </summary>
	/// <returns>Retourne : Une instance de la classe Formation remplie avec les données de la base de données.</returns>
	static public Formation GenereFormation()
	{
		int index = getIndex();
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
		setIndex(index + 1);
		return new Formation(n, e, el, b, o);
	}

	/// <summary>
	/// Methode ToString : Retourne une chaîne de caractères représentant la formation.
	/// </summary>
	/// <returns> Retourne : Une chaîne de caractères représentant la formation.</returns>
	public override string ToString()
	{
		return $"Formation : {Nom}\n" +
			   $"Option : {Option}\n" +
			   $"Effectif : {Effectif}\n" +
			   $"Élèves : {Eleve}\n" +
			   $"Budget : {Budget:C}"; // Format monétaire pour le budget
	}
}
