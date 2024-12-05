using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using CS_Winform_ESIEE.Modele;
using MySql.Data.MySqlClient;

namespace CS_Winform_ESIEE.Data
{
    /// <summary>
    /// Fournit des méthodes pour créer et mettre à jour des fichiers JSON à partir d'une base de données MySQL.
    /// </summary>
    public static class JsonEditor
    {
        /// <summary>
        /// Crée un fichier JSON à partir des données de la base de données MySQL.
        /// </summary>
        /// <param name="cheminJson">Le chemin où le fichier JSON sera créé.</param>
        public static void CreerJson(string cheminJson)
        {
            var dbConnector = new DatabaseConnector();
            dbConnector.OuvrirConnexion();

            var categories = new List<Categorie>();
            var articles = new List<Article>();
            var commandes = new List<Commande>();
            var lignesCommandes = new List<LigneCommande>();

            // Récupérer les catégories
            var cmd = new MySqlCommand("SELECT * FROM CATEGORY", dbConnector.Connexion);
            var reader = cmd.ExecuteReader();
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

            // Récupérer les articles
            cmd = new MySqlCommand("SELECT * FROM ARTICLE", dbConnector.Connexion);
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                articles.Add(new Article
                {
                    IdArticle = reader.GetInt32("IdArticle"),
                    IdCategorie = reader.GetInt32("IdCategorie"),
                    Nom = reader.GetString("Nom"),
                    PrixUnitaire = reader.GetDecimal("PrixUnitaire"),
                    Quantite = reader.GetInt32("Quantite"),
                    Promotion = reader.GetInt32("Promotion"),
                    EstActif = reader.GetBoolean("EstActif")
                });
            }

            reader.Close();

            // Récupérer les commandes
            cmd = new MySqlCommand("SELECT * FROM COMMANDE", dbConnector.Connexion);
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                commandes.Add(new Commande
                {
                    IdCommande = reader.GetInt32("IdCommande"),
                    Etat = reader.GetString("Etat"),
                    Date = reader.GetDateTime("Date"),
                    DateEnvoi = reader.IsDBNull(reader.GetOrdinal("DateEnvoi"))
                        ? (DateTime?)null
                        : reader.GetDateTime("DateEnvoi"),
                    DateLivraison = reader.IsDBNull(reader.GetOrdinal("DateLivraison"))
                        ? (DateTime?)null
                        : reader.GetDateTime("DateLivraison")
                });
            }

            reader.Close();

            // Récupérer les lignes de commande
            cmd = new MySqlCommand("SELECT * FROM LIGNE_COMMANDE", dbConnector.Connexion);
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                lignesCommandes.Add(new LigneCommande
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

            var data = new
            {
                Categories = categories,
                Articles = articles,
                Commandes = commandes,
                LignesCommandes = lignesCommandes
            };

            var options = new JsonSerializerOptions { WriteIndented = true };
            var json = JsonSerializer.Serialize(data, options);
            File.WriteAllText(cheminJson, json);
        }

        /// <summary>
        /// Met à jour la base de données MySQL avec les données d'un fichier JSON.
        /// </summary>
        /// <param name="cheminJson">Le chemin du fichier JSON à partir duquel lire les données.</param>
        public static void MettreAJourBaseDeDonnees(string cheminJson)
        {
            var json = File.ReadAllText(cheminJson);
            var data = JsonSerializer.Deserialize<dynamic>(json);

            var dbConnector = new DatabaseConnector();
            dbConnector.OuvrirConnexion();

            // Mettre à jour les catégories
            foreach (var categorie in data.Categories)
            {
                var cmd = new MySqlCommand(
                    "REPLACE INTO CATEGORY (IdCategorie, Nom, EstActif) VALUES (@IdCategorie, @Nom, @EstActif)",
                    dbConnector.Connexion);
                cmd.Parameters.AddWithValue("@IdCategorie", (int)categorie.IdCategorie);
                cmd.Parameters.AddWithValue("@Nom", (string)categorie.Nom);
                cmd.Parameters.AddWithValue("@EstActif", (bool)categorie.EstActif);
                cmd.ExecuteNonQuery();
            }

            // Mettre à jour les articles
            foreach (var article in data.Articles)
            {
                var cmd = new MySqlCommand(
                    "REPLACE INTO ARTICLE (IdArticle, IdCategorie, Nom, PrixUnitaire, Quantite, Promotion, EstActif) VALUES (@IdArticle, @IdCategorie, @Nom, @PrixUnitaire, @Quantite, @Promotion, @EstActif)",
                    dbConnector.Connexion);
                cmd.Parameters.AddWithValue("@IdArticle", (int)article.IdArticle);
                cmd.Parameters.AddWithValue("@IdCategorie", (int)article.IdCategorie);
                cmd.Parameters.AddWithValue("@Nom", (string)article.Nom);
                cmd.Parameters.AddWithValue("@PrixUnitaire", (decimal)article.PrixUnitaire);
                cmd.Parameters.AddWithValue("@Quantite", (int)article.Quantite);
                cmd.Parameters.AddWithValue("@Promotion", (int)article.Promotion);
                cmd.Parameters.AddWithValue("@EstActif", (bool)article.EstActif);
                cmd.ExecuteNonQuery();
            }

            // Mettre à jour les commandes
            foreach (var commande in data.Commandes)
            {
                var cmd = new MySqlCommand(
                    "REPLACE INTO COMMANDE (IdCommande, Etat, Date, DateEnvoi, DateLivraison) VALUES (@IdCommande, @Etat, @Date, @DateEnvoi, @DateLivraison)",
                    dbConnector.Connexion);
                cmd.Parameters.AddWithValue("@IdCommande", (int)commande.IdCommande);
                cmd.Parameters.AddWithValue("@Etat", (string)commande.Etat);
                cmd.Parameters.AddWithValue("@Date", (DateTime)commande.Date);
                cmd.Parameters.AddWithValue("@DateEnvoi", (object)(DateTime?)commande.DateEnvoi ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@DateLivraison",
                    (object)(DateTime?)commande.DateLivraison ?? DBNull.Value);
                cmd.ExecuteNonQuery();
            }

            // Mettre à jour les lignes de commande
            foreach (var ligneCommande in data.LignesCommandes)
            {
                var cmd = new MySqlCommand(
                    "REPLACE INTO LIGNE_COMMANDE (IdLigneCommande, IdCommande, IdArticle, PrixUnitaire, Quantite, Promotion) VALUES (@IdLigneCommande, @IdCommande, @IdArticle, @PrixUnitaire, @Quantite, @Promotion)",
                    dbConnector.Connexion);
                cmd.Parameters.AddWithValue("@IdLigneCommande", (int)ligneCommande.IdLigneCommande);
                cmd.Parameters.AddWithValue("@IdCommande", (int)ligneCommande.IdCommande);
                cmd.Parameters.AddWithValue("@IdArticle", (int)ligneCommande.IdArticle);
                cmd.Parameters.AddWithValue("@PrixUnitaire", (decimal)ligneCommande.PrixUnitaire);
                cmd.Parameters.AddWithValue("@Quantite", (int)ligneCommande.Quantite);
                cmd.Parameters.AddWithValue("@Promotion", (int)ligneCommande.Promotion);
                cmd.ExecuteNonQuery();
            }

            dbConnector.FermerConnexion();
        }
    }
}