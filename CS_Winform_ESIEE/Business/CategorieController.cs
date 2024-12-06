using System;
using CS_Winform_ESIEE.Modele;
using CS_Winform_ESIEE.Data;

using MySql.Data.MySqlClient;
using System.Collections.Generic;

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

        public void SupprimerCategorie(Categorie categorie)
        {
            dbConnector.OuvrirConnexion();

            string query = "DELETE FROM CATEGORY WHERE IdCategorie = @IdCategorie";
            MySqlCommand cmd = new MySqlCommand(query, dbConnector.Connexion);
            cmd.Parameters.AddWithValue("@IdCategorie", categorie.IdCategorie);

            cmd.ExecuteNonQuery();

            dbConnector.FermerConnexion();
        }

        public void UpdateCategorie(Categorie categorie)
        {
            dbConnector.OuvrirConnexion();

            string query = "UPDATE CATEGORY SET Nom = @Nom, EstActif = @EstActif WHERE IdCategorie = @IdCategorie";
            MySqlCommand cmd = new MySqlCommand(query, dbConnector.Connexion);
            cmd.Parameters.AddWithValue("@IdCategorie", categorie.IdCategorie);
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
        
        public Categorie GetCategorieByName(string name)
        {
            dbConnector.OuvrirConnexion();

            string query = "SELECT * FROM CATEGORY WHERE Nom = @Nom";
            MySqlCommand cmd = new MySqlCommand(query, dbConnector.Connexion);
            cmd.Parameters.AddWithValue("@Nom", name);

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
            else
            {
                throw new Exception("Categorie with the given name does not exist.");
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