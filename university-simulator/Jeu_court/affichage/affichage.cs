using Godot;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;

/// <summary>
/// Classe Affichage : elle gere l'affichage dans different element du jeu
/// </summary>
public static class affichage
{
    /// <summary>
    /// Methode EcrireTexte : statique elle permet d'écrire dans un texteedit et de la rendre visible en meme tempd
    /// </summary>
    /// <param name="textEdit"> parametre 1 :La textedit visé</param>
    /// <param name="texte"> Prametre 2 : Le message a ecrire</param>
    public static void EcrireTexte(TextEdit textEdit, string texte)
    {

        if (textEdit != null)
        {
        
            textEdit.Text = texte;
            textEdit.Visible = true;
        }
    }


    /// <summary>
    ///  Methode AfficherAgenda : statique elle permet d'afficher les rdv 
    /// de la journée dans un texedit de maniere jolie </summary>
    /// <param name="rendezVousList"> Parametre 1 : La liste des rendez vous</param>
    /// <param name="textEdit"> Parametre 2 : La textedit visé</param>
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
    /// Méthode AfficherProjets : statique elle permet d'afficher les projets dans un TextEdit
    /// </summary>
    /// <param name="projets"> Parametre 1: Liste de projets</param>
    /// <param name="textEditProjets"> Parametre 2 :TextEdit dans lequel afficher les projets</param>
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
    /// <param name="formations"> Parametre 1 : Liste de formations</param>
    /// <param name="textEditFormations"> Parametre 2 : TextEdit dans lequel afficher les formations</param>
    /// <param name="pan"></param> Parametre 3 : panel contenant le textedit <summary>
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

    /// <summary>
    /// Methode FinDuJeu : statique elle permet de changer vers la scene fin
    /// quand une condition de fin de jeu est atteinte
    /// </summary>
    /// <param name="j1"> Parametre 1 : Jauge1 </param>
    /// <param name="j2">Parametre 2 : Jauge2 </param>
    /// <param name="j3">Parametre 3 :Jauge3 </param>
    /// <param name="j4">Parametre 4 : Jauge4 </param>
    /// <param name="jour"> Parametre 5 :Jour actuelle </param>
    /// <param name="context">Parametre 6 :noed qui qui appel la fonction </param>
    public static void FinDuJeu(Jauge j1 , Jauge j2 , Jauge j3 , Jauge j4 , int jour ,Node context){
        if (j1.GetValeur() >=100 || j2.GetValeur() >= 100 || j3.GetValeur() >= 100 || j4.GetValeur() >= 100 
            ||j1.GetValeur() <=0 || j2.GetValeur() <=0 || j3.GetValeur() <=0 || j4.GetValeur() <=0 || jour ==5){
            context.GetTree().ChangeSceneToFile("res://Jeu_court/finduJeu.tscn");
        }
    }

}
