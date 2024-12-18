using Godot;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Net.Http;

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
            textEdit.Clear();
            textEdit.Text = texte;
            textEdit.Visible = true;
        }
    }


    /// <summary>
    ///  Methode AfficherAgenda : statique elle permet d'afficher les rdv 
    /// de la journée dans un texedit de maniere jolie </summary>
    /// <param name="rendezVousList"> Parametre 1 : La liste des rendez vous</param>
    /// <param name="textEdit"> Parametre 2 : La textedit visé</param>
   public static void AfficherAgenda(List<Rendezvous> rendezVousList, RichTextLabel textEdit)
{
    textEdit.Text = "";
    textEdit.BbcodeEnabled = true; // Active le mode BBCode

    string nomJour = Jour.Instance.GetNom();

    textEdit.Text += $"[center][b][color=orange]Agenda de {nomJour}[/color][/b][/center]\n";
    textEdit.Text += "[center]=====================[/center]\n\n";

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

            textEdit.Text += $"[color=orange][b]  - {debut:hh\\:mm} - {fin:hh\\:mm}:[/b][/color] {rdv.Description}\n";
        }
        else // s'il n'y a pas de rdv
        {
            TimeSpan debut = debutCreneaux[i];
            TimeSpan fin = debut + dureeCreneau;

            textEdit.Text += $"[color=red][b]  - {debut:hh\\:mm} - {fin:hh\\:mm}:[/b][/color] Aucun rendez-vous\n";
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

    public static void ChangeImage(string imagePath , TextureRect textureRect)
    {
        if (textureRect != null)
        {
            // Charge la nouvelle texture à partir du fichier
            var newTexture = (Texture)ResourceLoader.Load(imagePath);
            if (newTexture != null)
            {
                textureRect.Texture = (Texture2D)newTexture;
            }
            else
            {
                GD.PrintErr($"Failed to load texture from path: {imagePath}");
            }
        }
    }

    public static string creationlien(int composante ){
        int val=0;
        string message ; 

        switch (composante)
        {
                case 1:
                    val = JaugeManager.GetJaugeValue("Jauge1")+JaugeManager.GetJaugeValue("Jauge2")+JaugeManager.GetJaugeValue("Jauge3");
                    val /= 3;
                    break;
                case 2:
                    val = JaugeManager.GetJaugeValue("Jauge2")+JaugeManager.GetJaugeValue("Jauge4");
                    val /= 2;
                    break;
                case 3:
                    val = JaugeManager.GetJaugeValue("Jauge1");
                    break;
                case 4:
                    val = JaugeManager.GetJaugeValue("Jauge2")+JaugeManager.GetJaugeValue("Jauge4");
                    val /= 2;
                    break;
                case 5:
                    val = JaugeManager.GetJaugeValue("Jauge2")+JaugeManager.GetJaugeValue("Jauge3");
                    val /= 2;
                    break;
                case 6:
                    val = JaugeManager.GetJaugeValue("Jauge2")+JaugeManager.GetJaugeValue("Jauge4");
                    val /= 2;
                    break;
                case 7:
                    val = JaugeManager.GetJaugeValue("Jauge1")+JaugeManager.GetJaugeValue("Jauge3");
                    val /= 2;
                    break;
                case 8:
                    val = JaugeManager.GetJaugeValue("Jauge1")+JaugeManager.GetJaugeValue("Jauge4");
                    val /= 2;
                    break;
                case 9:
                    val = JaugeManager.GetJaugeValue("Jauge2")+JaugeManager.GetJaugeValue("Jauge4");
                    val /= 2;
                    break;
                case 10:
                     val = JaugeManager.GetJaugeValue("Jauge2")+JaugeManager.GetJaugeValue("Jauge4")+JaugeManager.GetJaugeValue("Jauge3");
                    val /= 3;
                    break;
                case 11:
                    val = JaugeManager.GetJaugeValue("Jauge2")+JaugeManager.GetJaugeValue("Jauge4");
                    val /= 2;
                    break;
        }

        if( val >=80){
            message = "Vous etes un peu trop proche";
        }
        else if (val <= 30){
            message = "Vous devriez reprendre contact";
        }
        else{
            message = "bonne relation";
        }

        return message;


    }

    public static void AffichageEtat(RichTextLabel richTextLabel)
{
    richTextLabel.Clear(); // Nettoie le contenu actuel
    richTextLabel.BbcodeEnabled = true; // Active le mode BBCode

    string message = "[center][b][color=orange]Statistiques des ressources[/color][/b][/center]\n";
    message += "[center]=====================[/center]\n\n";

    // Trésorerie
    int jauge1 = JaugeManager.GetJaugeValue("Jauge1");
    message += "[b]Trésorerie :[/b] ";
    if (jauge1 < 80 && jauge1 > 30)
    {
        message += "[color=green]correcte[/color]. Elle est actuellement à " + jauge1 + "%.\n";
    }
    else if (jauge1 <= 30)
    {
        message += "[color=red]mauvaise[/color]. Bientôt vous ne pourrez plus entretenir vos formations. Elle est actuellement à " + jauge1 + "%.\n";
    }
    else
    {
        message += "[color=red]trop bonne[/color]. Vous devriez investir dans vos formations. Elle est actuellement à " + jauge1 + "%.\n";
    }

    // Satisfaction des professeurs
    int jauge2 = JaugeManager.GetJaugeValue("Jauge2");
    message += "\n[b]Satisfaction des professeurs :[/b] ";
    if (jauge2 < 80 && jauge2 > 30)
    {
        message += "[color=green]correcte[/color]. Elle est actuellement à " + jauge2 + "%.\n";
    }
    else if (jauge2 <= 30)
    {
        message += "[color=red]mauvaise[/color]. Bientôt ils décideront de faire grève. Elle est actuellement à " + jauge2 + "%.\n";
    }
    else
    {
        message += "[color=red]trop bonne[/color]. Ils seront trop heureux de venir travailler. Elle est actuellement à " + jauge2 + "%.\n";
    }

    // Taux d'insertion professionnelle
    int jauge3 = JaugeManager.GetJaugeValue("Jauge3");
    message += "\n[b]Taux d'insertion professionnelle :[/b] ";
    if (jauge3 < 80 && jauge3 > 30)
    {
        message += "[color=green]correcte[/color]. Il est actuellement à " + jauge3 + "%.\n";
    }
    else if (jauge3 <= 30)
    {
        message += "[color=red]mauvais[/color]. Ils finiront tous au chômage. Il est actuellement à " + jauge3 + "%.\n";
    }
    else
    {
        message += "[color=red]excellent[/color]. Il n'y aura plus de chômeurs. Il est actuellement à " + jauge3 + "%.\n";
    }

    // Taux de réussite
    int jauge4 = JaugeManager.GetJaugeValue("Jauge4");
    message += "\n[b]Taux de réussite :[/b] ";
    if (jauge4 < 80 && jauge4 > 30)
    {
        message += "[color=green]correcte[/color]. Il est actuellement à " + jauge4 + "%.\n";
    }
    else if (jauge4 <= 30)
    {
        message += "[color=red]mauvais[/color]. Ils vont tous redoubler, ce qui coûtera cher. Il est actuellement à " + jauge4 + "%.\n";
    }
    else
    {
        message += "[color=red]trop bon[/color]. Il faudrait quand même des élèves moyens. Il est actuellement à " + jauge4 + "%.\n";
    }

    richTextLabel.Text = message; // Attribue le texte formaté
    richTextLabel.Visible = true;
}

        

}
