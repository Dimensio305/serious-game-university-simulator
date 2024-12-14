using System;
using System.Collections.Generic;
using Godot;

/// <summary>
/// Représente un ensemble de questions associées à différentes composantes.
/// Permet de récupérer les questions et leurs réponses associées à chaque composante.
/// </summary>
public class Question
{
    // Dictionnaire de questions liées aux composantes, avec l'id de la question comme clé.
    private Dictionary<int, int> question = new Dictionary<int, int>();

    // Identifiant de la question courante
    private int idquestion;

    // Nombre de questions
    private int nbquestion = 0;

    /// <summary>
    /// Initialise une nouvelle instance de la classe <see cref="Question"/> avec les questions associées aux composantes.
    /// </summary>
    public Question()
    {
        // Ajout des questions associées aux composantes dans le dictionnaire
        question.Add(1, 1);
        question.Add(2, 11);
        question.Add(3, 21);
        question.Add(4, 31);
        question.Add(5, 41);
        question.Add(6, 51);
        question.Add(7, 61);
        question.Add(8, 71);
        question.Add(9, 81);
        question.Add(10, 91);
        question.Add(11, 101);
    }

    /// <summary>
    /// Récupère la question associée à une composante spécifique.
    /// </summary>
    /// <param name="composante">L'identifiant de la composante pour laquelle on veut obtenir la question.</param>
    /// <returns>La question sous forme de chaîne de caractères.</returns>
    public string getquestion(int composante)
    {
        string requete = GestionDb.Instance.ExecuteRequete("select question from question where id =" + question[composante].ToString() + " and idcat = " + composante.ToString() + ";");
        idquestion = question[composante];
        return requete;
    }

    /// <summary>
    /// Obtient le nombre de questions.
    /// </summary>
    /// <returns>Le nombre de questions.</returns>
    public int getnbquestion()
    {
        return nbquestion;
    }

    /// <summary>
    /// Passe à la question suivante pour une composante spécifique.
    /// </summary>
    /// <param name="composante">L'identifiant de la composante pour laquelle on veut passer à la question suivante.</param>
    public void question_suivante(int composante)
    {
        question[composante] += 1;
    }

    /// <summary>
    /// Récupère l'identifiant de la question actuelle.
    /// </summary>
    /// <returns>L'identifiant de la question courante.</returns>
    public int getnumquestion()
    {
        return idquestion;
    }

    /// <summary>
    /// Récupère la valeur associée à la première réponse pour la question courante et un paramètre donné.
    /// </summary>
    /// <param name="j">Le nom de la colonne à récupérer de la table <c>Reponse</c>.</param>
    /// <returns>La valeur associée à la première réponse.</returns>
    public int getvaleur1(string j)
    {
        return Int32.Parse(GestionDb.Instance.ExecuteRequete("select " + j + " from Reponse where idquestion =" + idquestion.ToString() + " and idreponse=1;"));
    }

    /// <summary>
    /// Récupère la valeur associée à la deuxième réponse pour la question courante et un paramètre donné.
    /// </summary>
    /// <param name="j">Le nom de la colonne à récupérer de la table <c>Reponse</c>.</param>
    /// <returns>La valeur associée à la deuxième réponse.</returns>
    public int getvaleur2(string j)
    {
        return Int32.Parse(GestionDb.Instance.ExecuteRequete("select " + j + " from Reponse where idquestion =" + idquestion.ToString() + " and idreponse=2;"));
    }

    /// <summary>
    /// Récupère la première réponse associée à la question courante.
    /// </summary>
    /// <returns>La première réponse sous forme de chaîne de caractères.</returns>
    public string reponse1()
    {
        return GestionDb.Instance.ExecuteRequete("select reponse from Reponse where idquestion =" + idquestion.ToString() + " and idreponse = 1 ;");
    }

    /// <summary>
    /// Récupère la deuxième réponse associée à la question courante.
    /// </summary>
    /// <returns>La deuxième réponse sous forme de chaîne de caractères.</returns>
    public string reponse2()
    {
        return GestionDb.Instance.ExecuteRequete("select reponse from Reponse where idquestion =" + idquestion.ToString() + " and idreponse = 2 ;");
    }
}
