using System.Collections.Generic;

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

	// Méthode pour récupérer la valeur d'une jauge
	public static int GetJaugeValue(string jaugeName)
	{
		
		return jauges.ContainsKey(jaugeName) ? jauges[jaugeName] : 0;
	}

	// Méthode pour mettre à jour la valeur d'une jauge
	public static void SetJaugeValue(string jaugeName, int newValue)
	{
		if (jauges.ContainsKey(jaugeName))
		{
			jauges[jaugeName] = newValue;
		}
	}
}
