using System;
using Godot;

/// <summary>
/// Représente un rendez-vous avec une date, une durée, une description, et un indicateur de caractère fixe.
/// </summary>
public class Rendezvous
{
    /// <summary>
    /// Obtient ou définit la date et l'heure de début du rendez-vous.
    /// </summary>
    public DateTime Date { get; set; }

    /// <summary>
    /// Obtient ou définit la durée du rendez-vous.
    /// </summary>
    public TimeSpan Duree { get; set; }

    /// <summary>
    /// Obtient ou définit la description du rendez-vous.
    /// </summary>
    public string Description { get; set; }

    /// <summary>
    /// Obtient ou définit un indicateur indiquant si le rendez-vous est fixe.
    /// </summary>
    public bool EstFixe { get; set; }

    /// <summary>
    /// Initialise une nouvelle instance de la classe <see cref="Rendezvous"/> avec la date, la durée, la description, et l'indicateur fixe spécifiés.
    /// </summary>
    /// <param name="date">La date et heure de début du rendez-vous.</param>
    /// <param name="duree">La durée du rendez-vous.</param>
    /// <param name="description">La description du rendez-vous.</param>
    /// <param name="estFixe">Indique si le rendez-vous est fixe (facultatif, valeur par défaut est <c>false</c>).</param>
    public Rendezvous(DateTime date, TimeSpan duree, string description, bool estFixe = false)
    {
        Date = date;
        Duree = duree;
        Description = description;
        EstFixe = estFixe;
    }

    /// <summary>
    /// Calcule l'heure de fin du rendez-vous en fonction de sa durée.
    /// </summary>
    /// <returns>Un <see cref="DateTime"/> représentant l'heure de fin du rendez-vous.</returns>
    public DateTime HeureFin()
    {
        return Date.Add(Duree);
    }

    /// <summary>
    /// Retourne une chaîne de caractères représentant le rendez-vous avec son horaire et sa description.
    /// </summary>
    /// <returns>Une chaîne formatée avec l'heure de début, l'heure de fin et la description du rendez-vous.</returns>
    public override string ToString()
    {
        return $"{Date:HH:mm} - {HeureFin():HH:mm} : {Description}";
    }

  /// <summary>
/// Retourne une chaîne de caractères représentant le rendez-vous avec son jour, son horaire et sa description.
/// </summary>
/// <returns>Une chaîne formatée avec le jour, l'heure de début, l'heure de fin, et la description du rendez-vous.</returns>
public string vquestion()
{
    // Conversion du jour en français
    string jourSemaine = Date.ToString("dddd", new System.Globalization.CultureInfo("fr-FR"));

    return $"{jourSemaine}, {Date:HH:mm} - {HeureFin():HH:mm} : {Description}";
}

    /// <summary>
    /// Génère un rendez-vous aléatoire pour un jour de la semaine spécifié.
    /// </summary>
    /// <param name="jourSemaine">Le jour de la semaine (0 pour lundi, 1 pour mardi, etc., jusqu'à 4 pour vendredi).</param>
    /// <returns>Un objet <see cref="Rendezvous"/> aléatoire pour le jour spécifié.</returns>
    public static Rendezvous GenererRendezVousAleatoire(int jourSemaine)
    {
        Random rand = new Random();
        string[] descriptions = { "Meeting", "Cours", "Conférence", "Présentation" };

        // Calcul du nombre de jours pour atteindre le jour de semaine souhaité (de lundi à vendredi).
        DateTime date = DateTime.Today;
        int daysUntilNextWeekday = ((jourSemaine + 1) % 7 - (int)date.DayOfWeek + 7) % 7;
        DateTime jour = date.AddDays(daysUntilNextWeekday);

        // Heure de début entre 8h et 16h
        jour = jour.AddHours(rand.Next(8, 16));
        TimeSpan duree = TimeSpan.FromHours(rand.Next(1, 3)); // Durée de 1 à 2 heures
        string description = descriptions[rand.Next(descriptions.Length)];

        return new Rendezvous(jour, duree, description);
    }
}
