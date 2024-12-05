using DotNetEnv;
using MySql.Data.MySqlClient;

namespace CS_Winform_ESIEE.Data
{
    /// <summary>
    /// Classe responsable de la gestion de la connexion à une base de données MySQL.
    /// </summary>
    public class DatabaseConnector
    {
        private MySqlConnection connection;

        /// <summary>
        /// Initialise une nouvelle instance de la classe <see cref="DatabaseConnector"/>.
        /// Charge les variables d'environnement à partir du fichier .env et établit la chaîne de connexion.
        /// </summary>
        public DatabaseConnector()
        {
            // Charger les variables d'environnement à partir du fichier .env
            Env.Load("../../.env");

            // Récupérer les informations de connexion à la base de données à partir des variables d'environnement
            string server = Env.GetString("DATABASE_HOST");
            string database = Env.GetString("DATABASE_NAME");
            string user = Env.GetString("DATABASE_USER");
            string password = Env.GetString("DATABASE_PASSWORD");

            // Construire la chaîne de connexion MySQL
            string connectionString = $"SERVER={server}; DATABASE={database}; UID={user}; PASSWORD={password};";

            // Initialiser la connexion MySQL
            connection = new MySqlConnection(connectionString);
        }

        /// <summary>
        /// Obtient la connexion MySQL.
        /// </summary>
        public MySqlConnection Connexion
        {
            get { return connection; }
        }

        /// <summary>
        /// Ouvre la connexion MySQL.
        /// </summary>
        public void OuvrirConnexion()
        {
            connection.Open();
        }

        /// <summary>
        /// Ferme la connexion MySQL.
        /// </summary>
        public void FermerConnexion()
        {
            connection.Close();
        }
    }
}