using System;
using Godot;
using System.Collections.Generic;

/// <summary>
/// Classe Agenda: représentant un agenda contenant une liste de rendez-vous.
/// </summary>
public class Agenda
{
	/// <summary>
	/// Liste des rendez-vous de l'agenda.
	/// </summary>
	private List<Rendezvous> rendezVousList = new List<Rendezvous>();

	/// <summary>
	/// Constructeur de la classe Agenda.
	/// Initialise la liste des rendez-vous en récupérant les données par classe intermédiaire.
	/// </summary>
	public Agenda()
	{
		rendezVousList = Intermediaire.GetRdvFin();
	}

	/// <summary>
	/// Methode GetRendezVous : Retourne la liste des rendez-vous de l'agenda.
	/// </summary>
	/// <returns>Retourne : Liste des Rendezvous présents dans l'agenda.</returns>
	public List<Rendezvous> GetRendezVous() => rendezVousList;
}
