using Godot;
using System;

/// <summary>
/// Classe représentant une jauge de progression dans l'interface utilisateur.
/// </summary>
public partial class Jauge : TextureRect 
{

	private BoxContainer BoiteBarre;
	private ProgressBar Barre;

	/// <summary>
	/// Methode Ready : liée des element de la scene au code
	/// </summary>
	public override void _Ready()
	{
		// Récupère le conteneur de la jauge
		BoiteBarre = GetNodeOrNull<BoxContainer>("ConteneurJauge");
		// Récupère la barre de progression dans le conteneur
		Barre = BoiteBarre.GetNodeOrNull<ProgressBar>("JaugeProg");
		
		
		
	}




	/// <summary>
	/// Methode Modif : Modifie la valeur de la jauge en fonction du changement spécifié.
	/// </summary>
	/// <param name="Changement">Parametre 1 : La valeur à ajouter à la jauge. Peut être positive ou négative.</param>
	public void Modif(int Changement)
	{
		// Modifie la valeur de la barre de progression
		Barre.Value = Barre.Value + Changement;
		
	}

	/// <summary>
	/// Methode SetValeur : Donne la valeur de la jauge en fonction de la valeur spécifiée.
	/// </summary>
	/// <param name="val">Parametre 1 : La valaur de la jauge</param>
	public void SetValeur(int val)
	{
		Barre.Value = val;
	}

	/// <summary>
	/// Methode GetValeur : retourne la valeur de la jauge.
	/// </summary>
	/// <returns>Retourne : la valeur de la jauge</returns>
	public double GetValeur(){
		return Barre.Value;
	}

}
