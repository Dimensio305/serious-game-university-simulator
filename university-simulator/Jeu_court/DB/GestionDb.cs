using Godot;
using System;
using System.Text;
using System.Data.SQLite;
using System.Data.Entity.Spatial;
using System.IO;


	
public class GestionDb
{
    // Instance unique (Singleton)
    private static GestionDb _instance;

    // Connexion à la base de données
    private SQLiteConnection _connection;

    // Constructeur privé pour empêcher l'instanciation directe
    private GestionDb()
    {
        Connect(); // Connexion ouverte lors de la création de l'instance
    }

    // Méthode pour obtenir l'instance unique
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

    // Méthode pour ouvrir la connexion à la base de données
    private void Connect()
    {
        try
        {
            // Obtenir le chemin du dossier "user://", spécifique à Godot
            string userPath = OS.GetUserDataDir();
            // Combiner le chemin avec le chemin relatif à la base de données
            string dbPath = Path.Combine(userPath, "basedonnee.db");
            // Créer la chaîne de connexion avec le chemin complet
            string connectionString = $"Data Source={dbPath};Version=3;";
            _connection = new SQLiteConnection(connectionString);
            _connection.Open();
            GD.Print("Connexion réussie à la base de données.");
        }
        catch (Exception e)
        {
            GD.Print($"Erreur lors de la connexion : {e.Message}");
        }
    }

    // Méthode pour supprimer les données de toutes les tables
    public void Supprimer()
    {
        if (_connection != null && _connection.State == System.Data.ConnectionState.Open)
        {
            try
            {

                // Construire le chemin vers le fichier SQL
                string sqlFilePath = Path.Combine(OS.GetUserDataDir(), "supprimer.sql");
                
                // Exécuter le script SQL pour supprimer les données
                using (SQLiteCommand command = new SQLiteCommand(System.IO.File.ReadAllText(sqlFilePath), _connection))
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


    // Méthode pour exécuter une requête et retourner le résultat
    public string ExecuteRequete(string query)
    {
        if (_connection == null || _connection.State != System.Data.ConnectionState.Open)
        {
            GD.Print("La connexion à la base de données n'est pas ouverte.");
            return "La connexion n'est pas ouverte.";
        }

        StringBuilder result = new StringBuilder();

        try
        {
            using (SQLiteCommand command = new SQLiteCommand(query, _connection))
            {
                using (SQLiteDataReader reader = command.ExecuteReader())
                {
                    // Vérifie si le lecteur a des résultats
                    if (!reader.HasRows)
                    {
                        GD.Print("Aucune valeur trouvée.");
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

        return result.ToString(); // Renvoie toutes les valeurs sous forme de string
    } // Fin de la méthode ExecuteRequete


    // Méthode pour charger le contenu dans la base de données
    public void Contenue()
    {
        if (_connection != null && _connection.State == System.Data.ConnectionState.Open)
        {
            try
        {
            // Construire le chemin vers le fichier SQL
            string sqlFilePath1 = Path.Combine(OS.GetUserDataDir(), "table.sql");
            
            // Lire le contenu du fichier SQL
            string sqlScript1 = System.IO.File.ReadAllText(sqlFilePath1);

            // Exécuter le script SQL pour charger le contenu
            using (SQLiteCommand command = new SQLiteCommand(sqlScript1, _connection))
            {
                command.ExecuteNonQuery(); // Exécute le script
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
            string sqlFilePath1 = Path.Combine(OS.GetUserDataDir(), "contenue.sql");
            
            // Lire le contenu du fichier SQL
            string sqlScript1 = System.IO.File.ReadAllText(sqlFilePath1);

            // Exécuter le script SQL pour charger le contenu
            using (SQLiteCommand command = new SQLiteCommand(sqlScript1, _connection))
            {
                command.ExecuteNonQuery(); // Exécute le script
                GD.Print("contenue charger dans la base de données.");
            }
        }
            catch (Exception e)
            {
                GD.Print($"Erreur lors du chargement des données: {e.Message}");
            }
        }
        else
        {
            GD.Print("La connexion à la base de données n'est pas ouverte.");
        }
    }
}	

