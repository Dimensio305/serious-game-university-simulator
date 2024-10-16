using Godot;
using System;
using System.Text;
using System.Data.SQLite;
using System.Data.Entity.Spatial;

public static class GestionDb 
{
	

	// ce connecte a la base de donnee envoie un message si bien connecter ou pas s
	private static SQLiteConnection _connection;

		// Méthode statique pour ouvrir la connexion à la base de données
		public static void Connect()
		{
			try
			{
				string connectionString = "Data Source=res://Jeu_court/DB/basedonnee.db;Version=3;";
				_connection = new SQLiteConnection(connectionString);
				_connection.Open();
				GD.Print("Connexion réussie à la base de données.");
			}
			catch (Exception e)
			{
				GD.Print($"Erreur lors de la connexion : {e.Message}");
			}
		}
	
	
		// met la commande en parametre pour l'exe dans la db
		public static string ExecuterRequete(string query)
		{
			// Vérifier que la connexion est ouverte
			if (_connection == null || _connection.State != System.Data.ConnectionState.Open)
			{
				return "La connexion à la base de données n'est pas ouverte.";
			}

			StringBuilder result = new StringBuilder();

			try
			{
				SQLiteCommand command = new SQLiteCommand(query, _connection);
				using (SQLiteDataReader reader = command.ExecuteReader())
				{
					// Vérifie si le lecteur a des résultats
					if (!reader.HasRows)
					{
						GD.Print("aucun valeur trouver");
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

						}
						result.AppendLine(); // Saut de ligne pour la prochaine ligne de résultats
					}
				}
			}
			catch (Exception e)
			{
				return $"Erreur lors de l'exécution de la requête : {e.Message}";
			}

			return result.ToString(); // Renvoie toutes les valeurs sous forme de string
		}

	
	//supprimer la db
	public static void Supprimer()
	{
			if (_connection != null)
			{
				try
				{
					// Suppression des données de toutes les tables
					SQLiteCommand command = new SQLiteCommand("DELETE FROM ma_table1; DELETE FROM ma_table2; DELETE FROM ma_table3;", _connection);
					command.ExecuteNonQuery();
					GD.Print("Base de données vidée.");
				}
				catch (Exception e)
				{
					GD.Print($"Erreur lors du vidage de la base de données : {e.Message}");
				}
				finally
				{
					// Fermer la connexion
					_connection.Close();
					GD.Print("Connexion fermée.");
				}
			}
		}
	
	
}
