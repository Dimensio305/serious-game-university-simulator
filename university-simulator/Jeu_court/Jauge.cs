using Godot;
using System;

/// <summary>
/// Classe représentant une jauge de progression dans l'interface utilisateur.
/// </summary>
public partial class Jauge : TextureRect 
{
	/// <summary>
	/// Modifie la valeur de la jauge en fonction du changement spécifié.
	/// </summary>
	/// <param name="Changement">La valeur à ajouter à la jauge. Peut être positive ou négative.</param>
	public void Modif(int Changement)
	{
		// Récupère le conteneur de la jauge
		var BoiteBarre = GetNodeOrNull<BoxContainer>("ConteneurJauge");
		// Récupère la barre de progression dans le conteneur
		var Barre = BoiteBarre.GetNodeOrNull<ProgressBar>("JaugeProg");

		// Modifie la valeur de la barre de progression
		Barre.Value = Barre.Value + Changement;
	}
}
