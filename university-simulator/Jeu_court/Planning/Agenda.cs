using System;
using Godot;
using System.Collections.Generic;

public class Agenda
{
	private List<Rendezvous> rendezVousList = new List<Rendezvous>();

	
	public Agenda()
	{
		rendezVousList = Intermediaire.GetRdvFin();
	}

	public List<Rendezvous> GetRendezVous() => rendezVousList;

	

}
