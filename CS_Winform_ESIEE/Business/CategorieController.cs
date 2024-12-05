using CS_Winform_ESIEE.Modele;
using CS_Winform_ESIEE.Data;

using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_Winform_ESIEE.Business
{
    public class CategorieController
    {
        private DatabaseConnector dbConnector;

        public CategorieController()
        {
            dbConnector = new DatabaseConnector();
        }

        public void AjouterCategorie(Categorie categorie)
        {
            dbConnector.OuvrirConnexion();

            string query = "INSERT INTO CATEGORY (Nom, EstActif) VALUES (@Nom, @EstActif)";
            MySqlCommand cmd = new MySqlCommand(query, dbConnector.Connexion);
            cmd.Parameters.AddWithValue("@Nom", categorie.Nom);
            cmd.Parameters.AddWithValue("@EstActif", categorie.EstActif);

            cmd.ExecuteNonQuery();

            dbConnector.FermerConnexion();
        }
        
        public Categorie GetCategorieById(int id)
        {
            dbConnector.OuvrirConnexion();

            string query = "SELECT * FROM CATEGORY WHERE IdCategorie = @IdCategorie";
            MySqlCommand cmd = new MySqlCommand(query, dbConnector.Connexion);
            cmd.Parameters.AddWithValue("@IdCategorie", id);

            MySqlDataReader reader = cmd.ExecuteReader();
            Categorie categorie = null;
            if (reader.Read())
            {
                categorie = new Categorie
                {
                    IdCategorie = reader.GetInt32("IdCategorie"),
                    Nom = reader.GetString("Nom"),
                    EstActif = reader.GetBoolean("EstActif")
                };
            }

            reader.Close();
            dbConnector.FermerConnexion();

            return categorie;
        }

        public List<Categorie> GetAllCategories()
        {
            dbConnector.OuvrirConnexion();

            string query = "SELECT * FROM CATEGORY";
            MySqlCommand cmd = new MySqlCommand(query, dbConnector.Connexion);

            MySqlDataReader reader = cmd.ExecuteReader();
            List<Categorie> categories = new List<Categorie>();
            while (reader.Read())
            {
                categories.Add(new Categorie
                {
                    IdCategorie = reader.GetInt32("IdCategorie"),
                    Nom = reader.GetString("Nom"),
                    EstActif = reader.GetBoolean("EstActif")
                });
            }

            reader.Close();
            dbConnector.FermerConnexion();

            return categories;
        }
    }
}
