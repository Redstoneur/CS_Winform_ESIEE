using System;
using CS_Winform_ESIEE.Modele;
using CS_Winform_ESIEE.Data;
using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace CS_Winform_ESIEE.Business
{
    /// <summary>
    /// Classe contrôleur pour gérer les catégories dans la base de données.
    /// </summary>
    public class CategorieController
    {
        /// <summary>
        /// Le connecteur de base de données.
        /// </summary>
        private DatabaseConnector dbConnector;

        /// <summary>
        /// Initialise une nouvelle instance de la classe <see cref="CategorieController"/>.
        /// </summary>
        public CategorieController()
        {
            dbConnector = new DatabaseConnector();
        }

        /// <summary>
        /// Ajoute une nouvelle catégorie à la base de données.
        /// </summary>
        /// <param name="categorie">La catégorie à ajouter.</param>
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

        /// <summary>
        /// Supprime une catégorie de la base de données.
        /// </summary>
        /// <param name="categorie">La catégorie à supprimer.</param>
        public void SupprimerCategorie(Categorie categorie)
        {
            dbConnector.OuvrirConnexion();

            string query = "DELETE FROM CATEGORY WHERE IdCategorie = @IdCategorie";
            MySqlCommand cmd = new MySqlCommand(query, dbConnector.Connexion);
            cmd.Parameters.AddWithValue("@IdCategorie", categorie.IdCategorie);

            cmd.ExecuteNonQuery();

            dbConnector.FermerConnexion();
        }

        /// <summary>
        /// Met à jour une catégorie existante dans la base de données.
        /// </summary>
        /// <param name="categorie">La catégorie à mettre à jour.</param>
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

        /// <summary>
        /// Récupère une catégorie par son ID.
        /// </summary>
        /// <param name="id">L'ID de la catégorie à récupérer.</param>
        /// <returns>La catégorie avec l'ID spécifié, ou null si non trouvée.</returns>
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

        /// <summary>
        /// Récupère une catégorie par son nom.
        /// </summary>
        /// <param name="name">Le nom de la catégorie à récupérer.</param>
        /// <returns>La catégorie avec le nom spécifié.</returns>
        /// <exception cref="Exception">Lancée lorsque la catégorie avec le nom donné n'existe pas.</exception>
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
                throw new Exception("La catégorie avec le nom donné n'existe pas.");
            }

            reader.Close();
            dbConnector.FermerConnexion();

            return categorie;
        }

        /// <summary>
        /// Récupère toutes les catégories de la base de données.
        /// </summary>
        /// <returns>Une liste de toutes les catégories.</returns>
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