using System;
using System.IO;
using DotNetEnv;
using MySql.Data.MySqlClient;

namespace CS_Winform_ESIEE.Data
{
    /// <summary>
    /// Classe responsable de la gestion de la connexion à une base de données MySQL.
    /// </summary>
    public class DatabaseConnector
    {
        /// <summary>
        /// Gets or sets the MySQL connection.
        /// </summary>
        private MySqlConnection Connection { get; set; }

        /// <summary>
        /// Gets or sets the server name.
        /// </summary>
        private string Server { get; set; }

        /// <summary>
        /// Gets or sets the database name.
        /// </summary>
        private string Database { get; set; }

        /// <summary>
        /// Gets or sets the user name.
        /// </summary>
        private string User { get; set; }

        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        private string Password { get; set; }

        /// <summary>
        /// Initialise une nouvelle instance de la classe <see cref="DatabaseConnector"/>.
        /// Charge les variables d'environnement à partir du fichier .env et établit la chaîne de connexion.
        /// </summary>
        public DatabaseConnector()
        {
            // créer des variables par défaut pour modification dans le workflow
            Server = "@server";
            Database = "@database";
            User = "@user";
            Password = "@password";

            // Charger les variables d'environnement à partir du fichier .env, si n'est pas workflow
            if (Server == "@server" || Database == "@database" || User == "@user" || Password == "@password")
            {
                Server = Environment.GetEnvironmentVariable("DATABASE_HOST") ?? LoadEnvVariable("DATABASE_HOST");
                Database = Environment.GetEnvironmentVariable("DATABASE_NAME") ?? LoadEnvVariable("DATABASE_NAME");
                User = Environment.GetEnvironmentVariable("DATABASE_USER") ?? LoadEnvVariable("DATABASE_USER");
                Password = Environment.GetEnvironmentVariable("DATABASE_PASSWORD") ??
                           LoadEnvVariable("DATABASE_PASSWORD");
            }

            // Vérifier si les variables d'environnement ont été chargées
            if (Server == null || Database == null || User == null || Password == null)
            {
                throw new Exception(
                    "Les variables d'environnement pour la connexion à la base de données n'ont pas été trouvées.");
            }

            // Construire la chaîne de connexion MySQL
            string connectionString = $"SERVER={Server}; DATABASE={Database}; UID={User}; PASSWORD={Password};";

            // Initialiser la connexion MySQL
            Connection = new MySqlConnection(connectionString);
        }

        /// <summary>
        /// Charge une variable d'environnement à partir du fichier .env.
        /// </summary>
        /// <param name="variableName">Le nom de la variable d'environnement à charger.</param>
        /// <returns>La valeur de la variable d'environnement.</returns>
        private string LoadEnvVariable(string variableName)
        {
            // Récupérer le chemin du fichier .env
            string path = Path.Combine(
                Path.GetDirectoryName(Path.GetDirectoryName(Directory.GetCurrentDirectory())) ?? string.Empty,
                ".env"
            );

            // Charger les variables d'environnement depuis le fichier .env si le fichier existe
            if (File.Exists(path))
            {
                Env.Load(path);
                return Env.GetString(variableName);
            }

            // Si la variable n'est pas trouvée, renvoyer null
            return null;
        }

        /// <summary>
        /// Obtient la connexion MySQL.
        /// </summary>
        public MySqlConnection Connexion
        {
            get { return Connection; }
        }

        /// <summary>
        /// Ouvre la connexion MySQL.
        /// </summary>
        public void OuvrirConnexion()
        {
            Connection.Open();
        }

        /// <summary>
        /// Ferme la connexion MySQL.
        /// </summary>
        public void FermerConnexion()
        {
            Connection.Close();
        }
    }
}