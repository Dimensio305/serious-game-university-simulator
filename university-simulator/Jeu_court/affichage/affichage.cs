using Godot;
using System;
using System.Collections.Generic;

public static class affichage
{   
    /// <summary>
    /// Methode statique permettant d'écrire dans une texteedit et de la rendre visible en meme tempd
    /// </summary>
    /// <param name="textEdit"></param>
    /// <param name="texte"></param>
    public static void EcrireTexte(TextEdit textEdit, string texte)
    {
        // Assure que TextEdit n'est pas null
        if (textEdit != null)
        {
            // Écrit le texte dans le TextEdit
            textEdit.Text = texte;
            textEdit.Visible=true;
        }
    }



    /// <summary>
/// Méthode statique pour afficher l'agenda sous forme de semainier structuré dans un TextEdit
/// </summary>
/// <param name="rendezVousList"></param>
/// <param name="textEdit"></param>
public static void AfficherAgenda(List<Rendezvous> rendezVousList, TextEdit textEdit)
{
    textEdit.Text = ""; // Vider l'ancien texte

    // Dictionnaire pour regrouper les rendez-vous par jour
    Dictionary<DayOfWeek, List<Rendezvous>> agendaParJour = new Dictionary<DayOfWeek, List<Rendezvous>>();

    // Initialiser le dictionnaire avec chaque jour de la semaine
    foreach (DayOfWeek jour in Enum.GetValues(typeof(DayOfWeek)))
    {
        agendaParJour[jour] = new List<Rendezvous>();
    }

    // Remplir le dictionnaire avec les rendez-vous
    foreach (var rdv in rendezVousList)
    {
        agendaParJour[rdv.Date.DayOfWeek].Add(rdv);
    }

    // En-tête de l'agenda
    textEdit.Text += "Agenda de la semaine\n";
    textEdit.Text += "====================\n\n";

    // Afficher les rendez-vous par jour
    foreach (var jour in agendaParJour)
    {
        textEdit.Text += $"{jour.Key}:\n";
        textEdit.Text += "--------------------\n";  // Ligne de séparation pour chaque jour

        if (jour.Value.Count == 0)
        {
            textEdit.Text += "  Aucun rendez-vous\n";
        }
        else
        {
            foreach (var rdv in jour.Value)
            {
                // Affichage formaté : heure et description
                textEdit.Text += $"  - {rdv.Date:HH:mm} : {rdv.Description}\n";
            }
        }
        textEdit.Text += "\n";
    }

    textEdit.Visible = true;
}


    /// <summary>
    /// Méthode statique pour afficher les projets dans un TextEdit
    /// </summary>
    /// <param name="projets"></param>
    /// <param name="textEditProjets"></param>
    public static void AfficherProjets(List<Projet> projets, TextEdit textEditProjets, Panel pan)
    {
        textEditProjets.Clear();
        
        textEditProjets.Editable = false;
        
        for (int i = 0; i < projets.Count; i++)
        {
            textEditProjets.Text += $"{i + 1}. {projets[i]}\n\n";
        }
        pan.Visible=true;
        textEditProjets.Visible=true;
    }

    public static void AfficherFormations(List<Formation> formations, TextEdit textEditFormations, Panel pan)
    {
        // Nettoyage initial du TextEdit
        textEditFormations.Clear();
        textEditFormations.Editable = false;

        // Vérification si la liste est vide
        if (formations.Count == 0)
        {
            textEditFormations.Text = "Aucune formation disponible pour le moment.";
        }
        else
        {
            // Parcours des formations et ajout au TextEdit
            for (int i = 0; i < formations.Count; i++)
            {
                textEditFormations.Text += $"Formation #{i + 1} :\n";
                textEditFormations.Text += $"{formations[i]}\n\n";
            }
        }

        // Affichage du panel et du TextEdit
        pan.Visible = true;
        textEditFormations.Visible = true;
    }

}
