using System;
using Godot;
using System.Collections.Generic;

public class Agenda
{
    private List<Rendezvous> rendezVousList = new List<Rendezvous>();

    
    public Agenda()
    {
        GenererRendezVousSemaine();
    }

    public List<Rendezvous> GetRendezVous() => rendezVousList;

    public void GenererRendezVousSemaine()
    {
    int nombreRendezVous = 5; // Nombre de rendez-vous souhaité
    int jour = 1; // Commence au lundi (1 = lundi, 5 = vendredi)

    for (int i = 0; i < nombreRendezVous; i++)
    {
        Rendezvous nouveauRendezVous;
        do
        {
            nouveauRendezVous = Rendezvous.GenererRendezVousAleatoire(jour);
        } while (!PeutAjouterRendezVous(nouveauRendezVous));

        rendezVousList.Add(nouveauRendezVous);
        jour = (jour % 5) + 1; // Revenir au lundi après le vendredi
    }
    }

    private bool PeutAjouterRendezVous(Rendezvous nouveauRendezVous)
    {
    foreach (var rdv in rendezVousList)
    {
        if (nouveauRendezVous.Date.Date == rdv.Date.Date &&
            ((nouveauRendezVous.Date.TimeOfDay >= rdv.Date.TimeOfDay && nouveauRendezVous.Date.TimeOfDay < rdv.HeureFin().TimeOfDay) ||
             (nouveauRendezVous.HeureFin().TimeOfDay > rdv.Date.TimeOfDay && nouveauRendezVous.HeureFin().TimeOfDay <= rdv.HeureFin().TimeOfDay)))
        {
            GD.Print("Conflit détecté pour : " + nouveauRendezVous);
            return false; // Conflit détecté
        }
    }
    GD.Print("Aucun conflit pour : " + nouveauRendezVous);
    return true; // Pas de conflit
    }
}
