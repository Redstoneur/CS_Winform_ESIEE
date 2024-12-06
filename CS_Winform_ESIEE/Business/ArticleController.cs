﻿using CS_Winform_ESIEE.Modele;
using CS_Winform_ESIEE.Data;

using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace CS_Winform_ESIEE.Business
{
    public class ArticleController
    {
        private DatabaseConnector dbConnector;

        public ArticleController()
        {
            dbConnector = new DatabaseConnector();
        }

        public void AjouterArticle(Article article)
        {
            dbConnector.OuvrirConnexion();

            string query = "INSERT INTO ARTICLE (IdCategorie, Nom, PrixUnitaire, Quantite, Promotion, EstActif) " +
                           "VALUES (@IdCategorie, @Nom, @PrixUnitaire, @Quantite, @Promotion, @EstActif)";
            MySqlCommand cmd = new MySqlCommand(query, dbConnector.Connexion);
            cmd.Parameters.AddWithValue("@IdCategorie", article.IdCategorie);
            cmd.Parameters.AddWithValue("@Nom", article.Nom);
            cmd.Parameters.AddWithValue("@PrixUnitaire", article.PrixUnitaire);
            cmd.Parameters.AddWithValue("@Quantite", article.Quantite);
            cmd.Parameters.AddWithValue("@Promotion", article.Promotion);
            cmd.Parameters.AddWithValue("@EstActif", article.EstActif);

            cmd.ExecuteNonQuery();

            dbConnector.FermerConnexion();
        }

        public void SupprimerArticle(Article article)
        {
            UpdateEstActif(article, false);
        }
        
        public void UpdateIdCategorie(Article article, int idCategorie)
        {
            dbConnector.OuvrirConnexion();

            string query = "UPDATE ARTICLE SET IdCategorie = @IdCategorie WHERE IdArticle = @IdArticle;";
            MySqlCommand cmd = new MySqlCommand(query, dbConnector.Connexion);
            cmd.Parameters.AddWithValue("@IdArticle", article.IdArticle);
            cmd.Parameters.AddWithValue("@IdCategorie", idCategorie);

            cmd.ExecuteNonQuery();

            dbConnector.FermerConnexion();
        }
        
        public void UpdateNom(Article article, string nom)
        {
            dbConnector.OuvrirConnexion();

            string query = "UPDATE ARTICLE SET Nom = @Nom WHERE IdArticle = @IdArticle;";
            MySqlCommand cmd = new MySqlCommand(query, dbConnector.Connexion);
            cmd.Parameters.AddWithValue("@IdArticle", article.IdArticle);
            cmd.Parameters.AddWithValue("@Nom", nom);

            cmd.ExecuteNonQuery();

            dbConnector.FermerConnexion();
        }
        
        public void UpdatePrixUnitaire(Article article, decimal prixUnitaire)
        {
            dbConnector.OuvrirConnexion();

            string query = "UPDATE ARTICLE SET PrixUnitaire = @PrixUnitaire WHERE IdArticle = @IdArticle;";
            MySqlCommand cmd = new MySqlCommand(query, dbConnector.Connexion);
            cmd.Parameters.AddWithValue("@IdArticle", article.IdArticle);
            cmd.Parameters.AddWithValue("@PrixUnitaire", prixUnitaire);

            cmd.ExecuteNonQuery();

            dbConnector.FermerConnexion();
        }
        
        public void UpdateQuantite(Article article, int quantite)
        {
            dbConnector.OuvrirConnexion();

            string query = "UPDATE ARTICLE SET Quantite = @Quantite WHERE IdArticle = @IdArticle;";
            MySqlCommand cmd = new MySqlCommand(query, dbConnector.Connexion);
            cmd.Parameters.AddWithValue("@IdArticle", article.IdArticle);
            cmd.Parameters.AddWithValue("@Quantite", quantite);

            cmd.ExecuteNonQuery();

            dbConnector.FermerConnexion();
        }
        
        public void UpdatePromotion(Article article, int promotion)
        {
            dbConnector.OuvrirConnexion();

            string query = "UPDATE ARTICLE SET Promotion = @Promotion WHERE IdArticle = @IdArticle;";
            MySqlCommand cmd = new MySqlCommand(query, dbConnector.Connexion);
            cmd.Parameters.AddWithValue("@IdArticle", article.IdArticle);
            cmd.Parameters.AddWithValue("@Promotion", promotion);

            cmd.ExecuteNonQuery();

            dbConnector.FermerConnexion();
        }
        
        public void UpdateEstActif(Article article, bool estActif)
        {
            dbConnector.OuvrirConnexion();

            string query = "UPDATE ARTICLE SET EstActif = @EstActif WHERE IdArticle = @IdArticle;";
            MySqlCommand cmd = new MySqlCommand(query, dbConnector.Connexion);
            cmd.Parameters.AddWithValue("@IdArticle", article.IdArticle);
            cmd.Parameters.AddWithValue("@EstActif", estActif);

            cmd.ExecuteNonQuery();

            dbConnector.FermerConnexion();
        }
        
        

        public void UpdateArticle(Article article, object value, string field)
        {
            switch (field)
            {
                case "IdCategorie":
                    UpdateIdCategorie(article, (int)value);
                    break;
                case "Nom":
                    UpdateNom(article, (string)value);
                    break;
                case "PrixUnitaire":
                    UpdatePrixUnitaire(article, (decimal)value);
                    break;
                case "Quantite":
                    UpdateQuantite(article, (int)value);
                    break;
                case "Promotion":
                    UpdatePromotion(article, (int)value);
                    break;
                case "EstActif":
                    UpdateEstActif(article, (bool)value);
                    break;
                default:
                    break;
            }
        }
        
        public void UpdateArticleFlexible(Article article, List<object> values, List<string> fields)
        {
            for (int i = 0; i < fields.Count; i++)
            {
                UpdateArticle(article, values[i], fields[i]);
            }
        }

        public void UpdateRemise(Article article, int promotion)
        {
            UpdatePromotion(article, promotion);  // todo: delete this method and replace all calls to it with UpdatePromotion
        }

        public Article GetArticleById(int id)
        {
            dbConnector.OuvrirConnexion();

            string query = "SELECT * FROM ARTICLE WHERE IdArticle = @IdArticle";
            MySqlCommand cmd = new MySqlCommand(query, dbConnector.Connexion);
            cmd.Parameters.AddWithValue("@IdArticle", id);

            MySqlDataReader reader = cmd.ExecuteReader();
            Article article = null;
            if (reader.Read())
            {
                article = new Article
                {
                    IdArticle = reader.GetInt32("IdArticle"),
                    IdCategorie = reader.GetInt32("IdCategorie"),
                    Nom = reader.GetString("Nom"),
                    PrixUnitaire = reader.GetDecimal("PrixUnitaire"),
                    Quantite = reader.GetInt32("Quantite"),
                    Promotion = reader.GetInt32("Promotion"),
                    EstActif = reader.GetBoolean("EstActif")
                };
            }

            reader.Close();
            dbConnector.FermerConnexion();

            return article;
        }

        public List<Article> GetAllArticles()
        {
            dbConnector.OuvrirConnexion();

            string query = "SELECT * FROM ARTICLE";
            MySqlCommand cmd = new MySqlCommand(query, dbConnector.Connexion);

            MySqlDataReader reader = cmd.ExecuteReader();
            List<Article> articles = new List<Article>();
            while (reader.Read())
            {
                Article article = new Article
                {
                    IdArticle = reader.GetInt32("IdArticle"),
                    IdCategorie = reader.GetInt32("IdCategorie"),
                    Nom = reader.GetString("Nom"),
                    PrixUnitaire = reader.GetDecimal("PrixUnitaire"),
                    Quantite = reader.GetInt32("Quantite"),
                    Promotion = reader.GetInt32("Promotion"),
                    EstActif = reader.GetBoolean("EstActif")
                };
                articles.Add(article);
            }

            reader.Close();
            dbConnector.FermerConnexion();

            return articles;
        }
    }
}