using Godot;
using System;

/// <summary>
/// Classe représentant une jauge de progression dans l'interface utilisateur.
/// </summary>
public partial class Jauge : TextureRect 
{

	private BoxContainer BoiteBarre;
	private ProgressBar Barre;

	public override void _Ready()
	{
		// Récupère le conteneur de la jauge
		BoiteBarre = GetNodeOrNull<BoxContainer>("ConteneurJauge");
		// Récupère la barre de progression dans le conteneur
		Barre = BoiteBarre.GetNodeOrNull<ProgressBar>("JaugeProg");
		 UpdateJaugeColor();
		
		
	}




	/// <summary>
	/// Modifie la valeur de la jauge en fonction du changement spécifié.
	/// </summary>
	/// <param name="Changement">La valeur à ajouter à la jauge. Peut être positive ou négative.</param>
	public void Modif(int Changement)
	{
		// Modifie la valeur de la barre de progression
		Barre.Value = Barre.Value + Changement;
		 UpdateJaugeColor();
	}

	public void SetValeur(int val)
	{
		Barre.Value = val;
	}

	public double GetValeur(){
		return Barre.Value;
	}

	private void UpdateJaugeColor()
	{

		// Si la valeur est inférieure à 20 ou supérieure à 80, on la met en rouge
		if (Barre.Value < 40 || Barre.Value > 60)
		{
		   Barre.Modulate = new Color(1, 1, 0);
		}

		else if (Barre.Value < 20 || Barre.Value > 80){
			Barre.Modulate = new Color(1, 0, 0);
		}
		else
		{
			Barre.Modulate = new Color(0, 1, 0);
		}

	}
}
