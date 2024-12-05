using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotNetEnv;
using MySql.Data.MySqlClient;

namespace CS_Winform_ESIEE.Data
{
    public class DatabaseConnector
    {
        private MySqlConnection connection;

        public DatabaseConnector()
        {
            // Charger les variables d'environnement depuis le fichier .env
            Env.Load();

            string server = Env.GetString("DATABASE_HOST");
            string database = Env.GetString("DATABASE_NAME");
            string user = Env.GetString("DATABASE_USER");
            string password = Env.GetString("DATABASE_PASSWORD");

            string connectionString = $"SERVER={server}; DATABASE={database}; UID={user}; PASSWORD={password};";
            connection = new MySqlConnection(connectionString);
        }

        public MySqlConnection Connexion
        {
            get { return connection; }
        }

        public void OuvrirConnexion()
        {
            connection.Open();
        }

        public void FermerConnexion()
        {
            connection.Close();
        }
    }
}