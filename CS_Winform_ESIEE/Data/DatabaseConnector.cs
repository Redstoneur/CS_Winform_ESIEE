using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MySql.Data.MySqlClient;

namespace CS_Winform_ESIEE.Data
{
    public class DatabaseConnector
    {
        private MySqlConnection connection;

        public DatabaseConnector()
        {
            string connectionString = "SERVER=bramarstudio.com ; PORT=3306; DATABASE=MilkyMarket; UID=MilkyMarket; PASSWORD=milkymarketuw";
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
