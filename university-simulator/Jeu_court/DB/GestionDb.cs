using Godot;
using System;
using System.Text;
using System.Data.SQLite;
using System.Data.Entity.Spatial;
using System.IO;


/// <summary>
/// Classe GestionDb : utiliser pour cree une base de donnée , ajouter, accéder, supprimer le contenue de la base de donnée 
/// </summary>
public class GestionDb
{
	// Instance unique
	private static GestionDb _instance;

	// Connexion à la base de données
	private SQLiteConnection _connection;
	private string filePath = ProjectSettings.GlobalizePath("res://Jeu_court/DB/");
	/// <summary>
	/// Constructeur privé GestionDb : pour empêcher la création d'instances directes
	/// </summary>
	private GestionDb()
	{
		Connect(); // Connexion ouverte lors de la création de l'instance
	}

	/// <summary>
	/// Methode statique Instance : pour obteneir l'instance unique
	/// </summary>
	public static GestionDb Instance
	{
		get
		{
			if (_instance == null)
			{
				_instance = new GestionDb();
			}
			return _instance;
		}
	}

	/// <summary>
	/// Methode Connect : Pour ouvrir la connection a la base de données
	/// </summary>
	private void Connect()
	{
		try
		{

			string dbPath = Path.Combine(filePath, "basedonnee.db");

			GD.Print(dbPath);

			// Créer la chaîne de connexion avec le chemin complet
			string connectionString = $"Data Source={dbPath};Version=3;";

			_connection = new SQLiteConnection(connectionString);
			_connection.Open();
			GD.Print("Connexion réussie à la base de données.");
			Supprimer();
		}
		catch (Exception e)
		{
			GD.Print($"Erreur lors de la connexion : {e.Message}");
		}
	}


	/// <summary>
	/// Methode Supprimer : pour supprimer et vider les tables
	/// </summary>
	public void Supprimer()
	{
		if (_connection != null && _connection.State == System.Data.ConnectionState.Open)
		{
			try
			{
				// Construire le chemin vers le fichier SQL
				string sqlFilePath = Path.Combine(filePath, "supprimer.sql");

				// Exécuter le script SQL pour supprimer les données
				using (SQLiteCommand command = new(System.IO.File.ReadAllText(sqlFilePath), _connection))
				{
					command.ExecuteNonQuery();
					GD.Print("Base de données vidée.");
				}
			}
			catch (Exception e)
			{
				GD.Print($"Erreur lors du vidage de la base de données : {e.Message}");
			}
		}
		else
		{
			GD.Print("La connexion à la base de données n'est pas ouverte.");
		}
	}



	/// <summary>
	/// Méthode ExecuteRequete : pour exécuter une requête dans la base de donée et retourner le résultat
	/// </summary>
	/// <param name="requete">Parametre 1 : Requête SQL à exécuter</param>
	/// <returns>Retourne : le resultat de la requete sous forme de string</returns>
	public string ExecuteRequete(string requete)
	{
		if (_connection == null || _connection.State != System.Data.ConnectionState.Open)
		{
			GD.Print("La connexion à la base de données n'est pas ouverte.");
			return "La connexion n'est pas ouverte.";
		}

		StringBuilder result = new StringBuilder();

		try
		{
			using (SQLiteCommand command = new SQLiteCommand(requete, _connection))
			{
				using (SQLiteDataReader reader = command.ExecuteReader())
				{
					// Vérifie si le lecteur a des résultats
					if (!reader.HasRows)
					{
						GD.Print("Aucune valeur trouvée.");
						GD.Print(requete);
						return "";
					}

					// Lire toutes les lignes du résultat
					while (reader.Read())
					{
						// Parcourir toutes les colonnes de la ligne
						for (int i = 0; i < reader.FieldCount; i++)
						{
							string columnValue = reader[i].ToString(); // Valeur de la colonne
							result.Append(columnValue); // Ajouter uniquement la valeur au résultat
							GD.Print(columnValue); // Afficher la valeur dans le terminal
						}
						result.AppendLine(); // Saut de ligne pour la prochaine ligne de résultats
					}
				}
			}
		}
		catch (Exception e)
		{
			GD.Print($"Erreur lors de l'exécution de la requête : {e.Message}");
			return $"Erreur : {e.Message}";
		}

		return result.ToString();
	}

	/// <summary>
	/// Methode Contenue : crée les tables et les remplits 
	/// </summary>
	public void Contenue()
	{
		if (_connection != null && _connection.State == System.Data.ConnectionState.Open)
		{
			try
			{
				// Construire le chemin vers le fichier SQL
				string sqlFilePath1 = Path.Combine(filePath, "table.sql");

				// Lire le contenu du fichier SQL
				string sqlScript1 = System.IO.File.ReadAllText(sqlFilePath1);

				// Exécuter le script SQL pour charger le contenu
				using (SQLiteCommand command = new SQLiteCommand(sqlScript1, _connection))
				{
					command.ExecuteNonQuery();
					GD.Print("table crée dans la base de données.");
				}
			}
			catch (Exception e)
			{
				GD.Print($"Erreur lors de la création des tables : {e.Message}");
			}
		}
		else
		{
			GD.Print("La connexion à la base de données n'est pas ouverte.");
		}

		if (_connection != null && _connection.State == System.Data.ConnectionState.Open)
		{
			try
			{
				// Construire le chemin vers le fichier SQL
				string sqlFilePath1 = Path.Combine(filePath, "contenue.sql");

				// Lire le contenu du fichier SQL
				string sqlScript1 = File.ReadAllText(sqlFilePath1);

				// Exécuter le script SQL pour charger le contenu
				using (SQLiteCommand command = new SQLiteCommand(sqlScript1, _connection))
				{
					command.ExecuteNonQuery(); // Exécute le script
					GD.Print("table remplis dans la base de données.");
				}
			}
			catch (Exception e)
			{
				GD.Print($"Erreur lors du remplissage des tables : {e.Message}");
			}
		}
		else
		{
			GD.Print("Les tables n'ont pas été remplis.");
		}
	}
}
