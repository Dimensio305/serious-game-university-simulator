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
        
        
    }




	/// <summary>
	/// Modifie la valeur de la jauge en fonction du changement spécifié.
	/// </summary>
	/// <param name="Changement">La valeur à ajouter à la jauge. Peut être positive ou négative.</param>
	public void Modif(int Changement)
	{
		// Modifie la valeur de la barre de progression
		Barre.Value = Barre.Value + Changement;
	}

	public void SetValeur(int val)
	{
		Barre.Value = val;
	}

	public double GetValeur(){
		return Barre.Value;
	}
}
