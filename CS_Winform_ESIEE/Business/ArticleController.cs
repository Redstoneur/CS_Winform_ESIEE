﻿using CS_Winform_ESIEE.Modele;
using CS_Winform_ESIEE.Data;

using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
