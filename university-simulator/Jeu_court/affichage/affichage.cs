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
            textEdit.Visible = true;
        }
    }


/// <summary>
///  Methode statique permettant d'écrire dans une texteedit et de la rendre visible en meme
/// </summary>
/// <param name="rendezVousList"></param>
/// <param name="textEdit"></param>
public static void AfficherAgenda(List<Rendezvous> rendezVousList, TextEdit textEdit )
{
   textEdit.Text = ""; // Vider l'ancien texte

    // Récupérer le nom du jour via l'instance unique
    string nomJour = Jour.Instance.GetNom();

    // En-tête de l'agenda pour le jour
    textEdit.Text += $"Agenda de {nomJour}\n";
    textEdit.Text += "=====================\n\n";

    // Définir les créneaux horaires fixes
    TimeSpan[] debutCreneaux = {
        new TimeSpan(8, 0, 0),  // 8h à 10h
        new TimeSpan(10, 0, 0), // 10h à 12h
        new TimeSpan(14, 0, 0), // 14h à 16h
        new TimeSpan(16, 0, 0)  // 16h à 18h
    };

    TimeSpan dureeCreneau = new TimeSpan(2, 0, 0); // Chaque créneau dure 2 heures

    // Afficher les rendez-vous pour chaque créneau
    for (int i = 0; i < debutCreneaux.Length; i++)
    {
        if (i < rendezVousList.Count)
        {
            Rendezvous rdv = rendezVousList[i];
            TimeSpan debut = debutCreneaux[i];
            TimeSpan fin = debut + dureeCreneau;

            textEdit.Text += $"  - {debut:hh\\:mm} - {fin:hh\\:mm}: {rdv.Description}\n";
        }
        else
        {
            TimeSpan debut = debutCreneaux[i];
            TimeSpan fin = debut + dureeCreneau;

            // Aucun rendez-vous pour ce créneau
            textEdit.Text += $"  - {debut:hh\\:mm} - {fin:hh\\:mm}: Aucun rendez-vous\n";
        }
    }

    textEdit.Visible = true;
}




    /// <summary>
    /// Méthode statique pour afficher les projets dans un TextEdit
    /// </summary>
    /// <param name="projets"></param>
    /// <param name="textEditProjets"></param>
    public static void AfficherProjets(List<Projet> projets, TextEdit textEditProjets)
    {
        textEditProjets.Clear();

        textEditProjets.Editable = false;

        for (int i = 0; i < projets.Count; i++)
        {
            textEditProjets.Text += $"{i + 1}. {projets[i]}\n\n";
        }

        textEditProjets.Visible = true;
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

    public static void AfficherJour(TextEdit textEdit, Timer timer, string texte, float duree){
        // Configure le TextEdit
        textEdit.Text = texte;
        textEdit.Visible = true;

        // Configure et démarre le Timer
        timer.WaitTime = duree;
        timer.OneShot = true; // S'assure qu'il se déclenche une seule fois
        timer.Start();

        // Connecte le signal Timeout au TextEdit pour cacher l'affichage
        timer.Timeout += () =>
        {
            textEdit.Visible = false;
        };
    }

}
