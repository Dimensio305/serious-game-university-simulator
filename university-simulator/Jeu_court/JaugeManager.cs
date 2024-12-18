using System.Collections.Generic;

/// <summary>
/// Classe static JaugeManager : pour stocker les valeur des jauges pour s'en reservir dans plusieur scene
/// </summary>
public static class JaugeManager
{
    // Dictionnaire statique pour stocker les valeurs des jauges
    private static Dictionary<string, int> jauges = new Dictionary<string, int>
    {
        { "Jauge1", 50 }, // Exemple de jauge A initialisée à 50
        { "Jauge2", 50 }, // Exemple de jauge B initialisée à 50
        { "Jauge3", 50 }, // Exemple de jauge C initialisée à 50
        { "Jauge4", 50 }  // Exemple de jauge D initialisée à 50
    };

    private static Dictionary<string, int> jaugesDebutjournée = new Dictionary<string, int>
    {
        { "Jauge1", 50 }, // Exemple de jauge A initialisée à 50
        { "Jauge2", 50 }, // Exemple de jauge B initialisée à 50
        { "Jauge3", 50 }, // Exemple de jauge C initialisée à 50
        { "Jauge4", 50 }  // Exemple de jauge D initialisée à 50
    };

    /// <summary>
    /// Methode GetJaugeValue : permet de récupérer la valeur d'une jauge
    /// </summary>
    /// <param name="jaugeName">Parametre 1 : Le nom de la jauge</param>
    /// <returns>Retourne :la valeur de la jauge</returns>

    public static int GetJaugeValue(string jaugeName)
    {
        
        return jauges.ContainsKey(jaugeName) ? jauges[jaugeName] : 0;
    }

    
    /// <summary>
    /// Methode SetJaugeValue : permet de sauvegarder la valeur d'une jauge
    /// </summary>
    /// <param name="jaugeName">Parametre 1 : le nom de la jauge</param>
    /// <param name="newValue">Parametre 2 : sauvegarde la valeur de la jauge</param> 
    public static void SetJaugeValue(string jaugeName, int newValue)
    {
        if (jauges.ContainsKey(jaugeName))
        {
            jauges[jaugeName] = newValue;
        }
    }

    /// <summary>
    /// Methode majjour : Sauvegarde les valeur du debut de la journee 
    /// </summary> 
    public static void majjour(){
        jaugesDebutjournée["Jauge1"] = JaugeManager.GetJaugeValue("Jauge1");
        jaugesDebutjournée["Jauge2"] = JaugeManager.GetJaugeValue("Jauge2");
        jaugesDebutjournée["Jauge3"] = JaugeManager.GetJaugeValue("Jauge3");
        jaugesDebutjournée["Jauge4"] = JaugeManager.GetJaugeValue("Jauge4");
    }

    /// <summary>
    /// Methode statique GetJaugeValueMatin : permet de récupérer la valeur d'une jauge au debut de la journee
    /// </summary>
    /// <param name="jaugeName">Parametre 1 : Le nom de la jauge</param>
    /// <returns>Retourne : la valeur de cette jauge au debut de la journee</returns>
    public static int GetJaugeValueMatin(string jaugeName)
    {
        return jaugesDebutjournée.ContainsKey(jaugeName) ? jaugesDebutjournée[jaugeName] : 0;
    }
}
