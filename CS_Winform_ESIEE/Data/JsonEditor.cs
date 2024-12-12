using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Windows.Forms;
using CS_Winform_ESIEE.Business;
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
                    TypePromotion = reader.GetString("TypePromotion"),
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
                    Promotion = reader.GetInt32("Promotion"),
                    TypePromotion = reader.GetString("TypePromotion")
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
            var data = JsonSerializer.Deserialize<Dictionary<string, object>>(json);

            // vérifier si le fichier JSON est valide
            if (data == null || !data.ContainsKey("Categories") || !data.ContainsKey("Articles") ||
                !data.ContainsKey("Commandes") || !data.ContainsKey("LignesCommandes"))
            {
                throw new Exception("Le fichier JSON est invalide.");
            }

            // vérifier si les données sont valides
            if (((JsonElement)data["Categories"]).ValueKind != JsonValueKind.Array ||
                ((JsonElement)data["Articles"]).ValueKind != JsonValueKind.Array ||
                ((JsonElement)data["Commandes"]).ValueKind != JsonValueKind.Array ||
                ((JsonElement)data["LignesCommandes"]).ValueKind != JsonValueKind.Array)
            {
                throw new Exception("Les données du fichier JSON sont invalides.");
            }

            var dbConnector = new DatabaseConnector();
            dbConnector.OuvrirConnexion();

            string queryUpdate = "";

            // créé les requêtes pour les catégories
            foreach (var categorie in ((JsonElement)data["Categories"]).EnumerateArray())
            {
                // vérifier si la catégorie à des données valides
                if (categorie.ValueKind != JsonValueKind.Object ||
                    !categorie.TryGetProperty("IdCategorie", out JsonElement idCategorie) ||
                    !categorie.TryGetProperty("Nom", out JsonElement nom) ||
                    !categorie.TryGetProperty("EstActif", out JsonElement estActif))
                {
                    throw new Exception("Les données de la catégorie sont invalides.");
                }

                // vérifier les type des données
                if (idCategorie.ValueKind != JsonValueKind.Number ||
                    nom.ValueKind != JsonValueKind.String ||
                    estActif.ValueKind != JsonValueKind.True && estActif.ValueKind != JsonValueKind.False)
                {
                    throw new Exception("Les types des données de la catégorie sont invalides.");
                }

                // vérifier si la catégorie existe déjà
                string query = "SELECT * FROM CATEGORY WHERE IdCategorie = @IdCategorie";
                var cmd = new MySqlCommand(query, dbConnector.Connexion);
                cmd.Parameters.AddWithValue("@IdCategorie", idCategorie.GetInt32());
                var reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    queryUpdate +=
                        $"UPDATE CATEGORY SET Nom = '{nom.GetString()}', EstActif = {estActif.GetBoolean()} WHERE IdCategorie = {idCategorie.GetInt32()};\n";
                }
                else
                {
                    queryUpdate +=
                        $"INSERT INTO CATEGORY (Nom, EstActif) VALUES ('{nom.GetString()}', {estActif.GetBoolean()});\n";
                }

                reader.Close();
            }

            // créé les requêtes pour les articles
            foreach (var article in ((JsonElement)data["Articles"]).EnumerateArray())
            {
                // vérifier si l'article à des données valides
                if (article.ValueKind != JsonValueKind.Object ||
                    !article.TryGetProperty("IdArticle", out JsonElement idArticle) ||
                    !article.TryGetProperty("IdCategorie", out JsonElement idCategorie) ||
                    !article.TryGetProperty("Nom", out JsonElement nom) ||
                    !article.TryGetProperty("PrixUnitaire", out JsonElement prixUnitaire) ||
                    !article.TryGetProperty("Quantite", out JsonElement quantite) ||
                    !article.TryGetProperty("Promotion", out JsonElement promotion) ||
                    !article.TryGetProperty("TypePromotion", out JsonElement typePromotion) ||
                    !article.TryGetProperty("EstActif", out JsonElement estActif))
                {
                    throw new Exception("Les données de l'article sont invalides.");
                }

                // vérifier les type des données
                if (idArticle.ValueKind != JsonValueKind.Number ||
                    idCategorie.ValueKind != JsonValueKind.Number ||
                    nom.ValueKind != JsonValueKind.String ||
                    prixUnitaire.ValueKind != JsonValueKind.Number ||
                    quantite.ValueKind != JsonValueKind.Number ||
                    promotion.ValueKind != JsonValueKind.Number ||
                    typePromotion.ValueKind != JsonValueKind.String ||
                    estActif.ValueKind != JsonValueKind.True && estActif.ValueKind != JsonValueKind.False)
                {
                    throw new Exception("Les types des données de l'article sont invalides.");
                }

                // vérifier si l'article existe déjà
                string query = "SELECT * FROM ARTICLE WHERE IdArticle = @IdArticle";
                var cmd = new MySqlCommand(query, dbConnector.Connexion);
                cmd.Parameters.AddWithValue("@IdArticle", idArticle.GetInt32());
                var reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    queryUpdate +=
                        $"UPDATE ARTICLE SET IdCategorie = {idCategorie.GetInt32()}, Nom = '{nom.GetString()}', PrixUnitaire = {prixUnitaire.GetDecimal().ToString().Replace(',', '.')}, Quantite = {quantite.GetInt32()}, Promotion = {promotion.GetInt32()}, TypePromotion = '{typePromotion.GetString()}', EstActif = {estActif.GetBoolean()} WHERE IdArticle = {idArticle.GetInt32()};\n"
                        ;
                }
                else
                {
                    queryUpdate +=
                        $"INSERT INTO ARTICLE (IdCategorie, Nom, PrixUnitaire, Quantite, Promotion, TypePromotion, EstActif) VALUES ({idCategorie.GetInt32()}, '{nom.GetString()}', {prixUnitaire.GetDecimal().ToString().Replace(',', '.')}, {quantite.GetInt32()}, {promotion.GetInt32()}, '{typePromotion.GetString()}', {estActif.GetBoolean()});\n";
                }

                reader.Close();
            }

            // créé les requêtes pour les commandes
            foreach (var commande in ((JsonElement)data["Commandes"]).EnumerateArray())
            {
                // vérifier si la commande à des données valides
                if (commande.ValueKind != JsonValueKind.Object ||
                    !commande.TryGetProperty("IdCommande", out JsonElement idCommande) ||
                    !commande.TryGetProperty("Etat", out JsonElement etat) ||
                    !commande.TryGetProperty("Date", out JsonElement date) ||
                    !commande.TryGetProperty("DateEnvoi", out JsonElement dateEnvoi) ||
                    !commande.TryGetProperty("DateLivraison", out JsonElement dateLivraison))
                {
                    throw new Exception("Les données de la commande sont invalides.");
                }

                // vérifier les type des données
                if (idCommande.ValueKind != JsonValueKind.Number ||
                    etat.ValueKind != JsonValueKind.String ||
                    date.ValueKind != JsonValueKind.String ||
                    (dateEnvoi.ValueKind != JsonValueKind.String && dateEnvoi.ValueKind != JsonValueKind.Null) ||
                    (dateLivraison.ValueKind != JsonValueKind.String && dateLivraison.ValueKind != JsonValueKind.Null)
                   )
                {
                    throw new Exception("Les types des données de la commande sont invalides.");
                }

                // si etat est bien 'Commandé' ou 'Expédié' ou 'Livré'
                if (etat.GetString() != "Commandé" && etat.GetString() != "Expédié" &&
                    etat.GetString() != "Livré" && etat.GetString() != "Annulé")
                {
                    throw new Exception("L'état de la commande est invalide.");
                }

                // vérifier si la commande existe déjà
                string query = "SELECT * FROM COMMANDE WHERE IdCommande = @IdCommande";
                var cmd = new MySqlCommand(query, dbConnector.Connexion);
                cmd.Parameters.AddWithValue("@IdCommande", idCommande.GetInt32());
                var reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    queryUpdate +=
                        $"UPDATE COMMANDE SET Etat = '{etat.GetString()}', Date = '{date.GetDateTime().ToString("yyyy-MM-dd HH:mm:ss")}', DateEnvoi = {(dateEnvoi.ValueKind == JsonValueKind.Null ? "null" : $"'{dateEnvoi.GetDateTime().ToString("yyyy-MM-dd HH:mm:ss")}'")}, DateLivraison = {(dateLivraison.ValueKind == JsonValueKind.Null ? "null" : $"'{dateLivraison.GetDateTime().ToString("yyyy-MM-dd HH:mm:ss")}'")} WHERE IdCommande = {idCommande.GetInt32()};\n";
                }
                else
                {
                    queryUpdate +=
                        $"INSERT INTO COMMANDE (Etat, Date, DateEnvoi, DateLivraison) VALUES ('{etat.GetString()}', '{date.GetDateTime().ToString("yyyy-MM-dd HH:mm:ss")}', {(dateEnvoi.ValueKind == JsonValueKind.Null ? "null" : $"'{dateEnvoi.GetDateTime().ToString("yyyy-MM-dd HH:mm:ss")}'")}, {(dateLivraison.ValueKind == JsonValueKind.Null ? "null" : $"'{dateLivraison.GetDateTime().ToString("yyyy-MM-dd HH:mm:ss")}'")});\n";
                }

                reader.Close();
            }

            // créé la requête pour les lignes de commande
            // TODO: à compléter

            MySqlCommand command = new MySqlCommand(queryUpdate, dbConnector.Connexion);
            command.ExecuteNonQuery();

            dbConnector.FermerConnexion();
        }
    }
}