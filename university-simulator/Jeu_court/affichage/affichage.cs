using Godot;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;

/// <summary>
/// Classe gerant l'affichage du contenue du jeu
/// </summary>
public static class affichage
{
    /// <summary>
    /// Methode statique permettant d'écrire dans une texteedit et de la rendre visible en meme tempd
    /// </summary>
    /// <param name="textEdit"></param>
    /// <param name="texte"></param>
    public static void EcrireTexte(TextEdit textEdit, string texte)
    {

        if (textEdit != null)
        {
        
            textEdit.Text = texte;
            textEdit.Visible = true;
        }
    }


    /// <summary>
    ///  Methode statique permettant d'écrire dans une texteedit et de la rendre visible en meme temps sous forme
    /// d'agenda journalier
    /// </summary>
    /// <param name="rendezVousList"></param>
    /// <param name="textEdit"></param>
    public static void AfficherAgenda(List<Rendezvous> rendezVousList, TextEdit textEdit )
    {
    textEdit.Text = ""; 

        
        string nomJour = Jour.Instance.GetNom();

        
        textEdit.Text += $"Agenda de {nomJour}\n";
        textEdit.Text += "=====================\n\n";

        
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
            else // s'il n'y a pas de rdv
            {
                TimeSpan debut = debutCreneaux[i];
                TimeSpan fin = debut + dureeCreneau;

                
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

    /// <summary>
    ///  Méthode AfficherFormations : statique elle affiche les rendez-vous dans un TextEdit
    /// </summary>
    /// <param name="formations"> Liste de formations</param>
    /// <param name="textEditFormations"> TextEdit dans lequel afficher les formations</param>
    /// <param name="pan"></param> panel contenant le textedit <summary>
    /// </summary>
    
    public static void AfficherFormations(List<Formation> formations, TextEdit textEditFormations, Panel pan)
    {
      
        textEditFormations.Clear();
        textEditFormations.Editable = false;

        
        if (formations.Count == 0)
        {
            textEditFormations.Text = "Aucune formation disponible pour le moment.";
        }
        else
        {
            
            for (int i = 0; i < formations.Count; i++)
            {
                textEditFormations.Text += $"Formation #{i + 1} :\n";
                textEditFormations.Text += $"{formations[i]}\n\n";
            }
        }

        
        pan.Visible = true;
        textEditFormations.Visible = true;
    }

    public static void FinDuJeu(Jauge j1 , Jauge j2 , Jauge j3 , Jauge j4 , int jour ,Node context){
        if (j1.GetValeur() >=100 || j2.GetValeur() >= 100 || j3.GetValeur() >= 100 || j4.GetValeur() >= 100 
            ||j1.GetValeur() <=0 || j2.GetValeur() <=0 || j3.GetValeur() <=0 || j4.GetValeur() <=0 || jour ==5){
            context.GetTree().ChangeSceneToFile("res://Jeu_court/finduJeu.tscn");
        }
    }

}
