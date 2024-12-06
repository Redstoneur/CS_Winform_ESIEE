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
    public class LigneCommandeController
    {
        private DatabaseConnector dbConnector;

        public LigneCommandeController()
        {
            dbConnector = new DatabaseConnector();
        }

        public void AjouterLigneCommande(long idCommande, Article article)
        {
            dbConnector.OuvrirConnexion();

            string query = "INSERT INTO LIGNE_COMMANDE (IdCommande, IdArticle, PrixUnitaire, Quantite, Promotion) " +
                           "VALUES (@IdCommande, @IdArticle, @PrixUnitaire, @Quantite, @Promotion)";
            MySqlCommand cmd = new MySqlCommand(query, dbConnector.Connexion);
            cmd.Parameters.AddWithValue("@IdCommande", idCommande);
            cmd.Parameters.AddWithValue("@IdArticle", article.IdArticle);
            cmd.Parameters.AddWithValue("@PrixUnitaire", article.PrixUnitaire);
            cmd.Parameters.AddWithValue("@Quantite", article.Quantite);
            cmd.Parameters.AddWithValue("@Promotion", article.Promotion);

            cmd.ExecuteNonQuery();

            dbConnector.FermerConnexion();
        }
        
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
                    Promotion = reader.GetInt32("Promotion")
                };
            }

            reader.Close();
            dbConnector.FermerConnexion();

            return ligneCommande;
        }
        
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
                    Promotion = reader.GetInt32("Promotion")
                });
            }

            reader.Close();
            dbConnector.FermerConnexion();

            return ligneCommandes;
        }
        
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
                    Promotion = reader.GetInt32("Promotion")
                });
            }

            reader.Close();
            dbConnector.FermerConnexion();

            return ligneCommandes;
        }
    }
}