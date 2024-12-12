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
    /// <summary>
    /// Classe contrôleur pour gérer les opérations de LigneCommande.
    /// </summary>
    public class LigneCommandeController
    {
        /// <summary>
        /// Le connecteur de base de données.
        /// </summary>
        private DatabaseConnector dbConnector;

        /// <summary>
        /// Initialise une nouvelle instance de la classe <see cref="LigneCommandeController"/>.
        /// </summary>
        public LigneCommandeController()
        {
            dbConnector = new DatabaseConnector();
        }

        /// <summary>
        /// Ajoute une nouvelle LigneCommande à la base de données.
        /// </summary>
        /// <param name="idCommande">L'ID de la commande.</param>
        /// <param name="article">L'article à ajouter.</param>
        public void AjouterLigneCommande(long idCommande, Article article)
        {
            dbConnector.OuvrirConnexion();

            string query = "INSERT INTO LIGNE_COMMANDE (IdCommande, IdArticle, PrixUnitaire, Quantite, Promotion, TypePromotion) " +
                           "VALUES (@IdCommande, @IdArticle, @PrixUnitaire, @Quantite, @Promotion, @TypePromotion)";
            MySqlCommand cmd = new MySqlCommand(query, dbConnector.Connexion);
            cmd.Parameters.AddWithValue("@IdCommande", idCommande);
            cmd.Parameters.AddWithValue("@IdArticle", article.IdArticle);
            cmd.Parameters.AddWithValue("@PrixUnitaire", article.PrixUnitaire);
            cmd.Parameters.AddWithValue("@Quantite", article.Quantite);
            cmd.Parameters.AddWithValue("@Promotion", article.Promotion);
            cmd.Parameters.AddWithValue("@TypePromotion", article.TypePromotion);

            cmd.ExecuteNonQuery();

            dbConnector.FermerConnexion();
        }

        /// <summary>
        /// Récupère une LigneCommande par son ID.
        /// </summary>
        /// <param name="id">L'ID de la LigneCommande.</param>
        /// <returns>La LigneCommande avec l'ID spécifié.</returns>
        public LigneCommande GetLigneCommandeById(int id)
        {
            dbConnector.OuvrirConnexion();

            string query = "SELECT * FROM LIGNE_COMMANDE WHERE IdLigneCommande = @IdLigneCommande";
            MySqlCommand cmd = new MySqlCommand(query, dbConnector.Connexion);
            cmd.Parameters.AddWithValue("@IdLigneCommande", id);

            MySqlDataReader reader = cmd.ExecuteReader();
            LigneCommande ligneCommande = null;
            if (reader.Read())
            {
                ligneCommande = new LigneCommande
                {
                    IdLigneCommande = reader.GetInt32("IdLigneCommande"),
                    IdCommande = reader.GetInt32("IdCommande"),
                    IdArticle = reader.GetInt32("IdArticle"),
                    PrixUnitaire = reader.GetDecimal("PrixUnitaire"),
                    Quantite = reader.GetInt32("Quantite"),
                    Promotion = reader.GetInt32("Promotion"),
                    TypePromotion = reader.GetString("TypePromotion")
                };
            }

            reader.Close();
            dbConnector.FermerConnexion();

            return ligneCommande;
        }

        /// <summary>
        /// Récupère toutes les LigneCommandes de la base de données.
        /// </summary>
        /// <returns>Une liste de toutes les LigneCommandes.</returns>
        public List<LigneCommande> GetAllLigneCommandes()
        {
            dbConnector.OuvrirConnexion();

            string query = "SELECT * FROM LIGNE_COMMANDE";
            MySqlCommand cmd = new MySqlCommand(query, dbConnector.Connexion);

            MySqlDataReader reader = cmd.ExecuteReader();
            List<LigneCommande> ligneCommandes = new List<LigneCommande>();
            while (reader.Read())
            {
                ligneCommandes.Add(new LigneCommande
                {
                    IdLigneCommande = reader.GetInt32("IdLigneCommande"),
                    IdCommande = reader.GetInt32("IdCommande"),
                    IdArticle = reader.GetInt32("IdArticle"),
                    PrixUnitaire = reader.GetDecimal("PrixUnitaire"),
                    Quantite = reader.GetInt32("Quantite"),
                    Promotion = reader.GetInt32("Promotion"),
                    TypePromotion = reader.GetString("TypePromotion")
                });
            }

            reader.Close();
            dbConnector.FermerConnexion();

            return ligneCommandes;
        }

        /// <summary>
        /// Récupère toutes les LigneCommandes pour un ID de commande spécifique.
        /// </summary>
        /// <param name="idCommande">L'ID de la commande.</param>
        /// <returns>Une liste de LigneCommandes pour l'ID de commande spécifié.</returns>
        public List<LigneCommande> GetLigneCommandesByCommandeId(int idCommande)
        {
            dbConnector.OuvrirConnexion();

            string query = "SELECT * FROM LIGNE_COMMANDE WHERE IdCommande = @IdCommande";
            MySqlCommand cmd = new MySqlCommand(query, dbConnector.Connexion);
            cmd.Parameters.AddWithValue("@IdCommande", idCommande);

            MySqlDataReader reader = cmd.ExecuteReader();
            List<LigneCommande> ligneCommandes = new List<LigneCommande>();
            while (reader.Read())
            {
                ligneCommandes.Add(new LigneCommande
                {
                    IdLigneCommande = reader.GetInt32("IdLigneCommande"),
                    IdCommande = reader.GetInt32("IdCommande"),
                    IdArticle = reader.GetInt32("IdArticle"),
                    PrixUnitaire = reader.GetDecimal("PrixUnitaire"),
                    Quantite = reader.GetInt32("Quantite"),
                    Promotion = reader.GetInt32("Promotion"),
                    TypePromotion = reader.GetString("TypePromotion")
                });
            }

            reader.Close();
            dbConnector.FermerConnexion();

            return ligneCommandes;
        }
    }
}