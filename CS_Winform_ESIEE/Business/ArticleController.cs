using CS_Winform_ESIEE.Modele;
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

        public void AjouterArticle(int idCategorie, string nom, decimal prixUnitaire, int quantite, int promotion = 0,
            bool estActif = true)
        {
            // verifier que la categorie existe
            CategorieController categorieController = new CategorieController();
            if (categorieController.GetCategorieById(idCategorie) == null)
            {
                throw new System.Exception("La catégorie n'existe pas");
            }

            dbConnector.OuvrirConnexion();

            string query =
                "INSERT INTO ARTICLE (IdCategorie, Nom, PrixUnitaire, Quantite, Promotion, EstActif) VALUES (@IdCategorie, @Nom, @PrixUnitaire, @Quantite, @Promotion, @EstActif);";

            MySqlCommand cmd = new MySqlCommand(query, dbConnector.Connexion);
            cmd.Parameters.AddWithValue("@IdCategorie", idCategorie);
            cmd.Parameters.AddWithValue("@Nom", nom);
            cmd.Parameters.AddWithValue("@PrixUnitaire", prixUnitaire);
            cmd.Parameters.AddWithValue("@Quantite", quantite);
            cmd.Parameters.AddWithValue("@Promotion", promotion);
            cmd.Parameters.AddWithValue("@EstActif", estActif);

            cmd.ExecuteNonQuery();

            dbConnector.FermerConnexion();
        }

        public void SupprimerArticle(Article article)
        {
            UpdateEstActif(article, false);
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

        public void UpdateArticle(Article article, Dictionary<string, object> data)
        {
            // Vérification des clés valides
            var validKeys = new HashSet<string> { "Nom", "PrixUnitaire", "Quantite", "EstActif" };
            foreach (string key in data.Keys)
            {
                if (!validKeys.Contains(key))
                {
                    throw new System.ArgumentException($"La clé '{key}' n'est pas valide.");
                }
            }

            // Construction de la requête SQL
            string query = "UPDATE ARTICLE SET ";
            var setClauses = new List<string>();
            var parameters = new Dictionary<string, object>();

            foreach (var entry in data)
            {
                string paramName = $"@{entry.Key}";
                setClauses.Add($"{entry.Key} = {paramName}");
                parameters[paramName] = entry.Value;
            }

            query += string.Join(", ", setClauses);
            query += " WHERE IdArticle = @IdArticle";

            // Ajout de l'identifiant de l'article comme paramètre
            parameters["@IdArticle"] = article.IdArticle;

            try
            {
                // Ouverture de la connexion
                dbConnector.OuvrirConnexion();

                using (MySqlCommand cmd = new MySqlCommand(query, dbConnector.Connexion))
                {
                    // Ajout des paramètres à la commande
                    foreach (var param in parameters)
                    {
                        cmd.Parameters.AddWithValue(param.Key, param.Value ?? System.DBNull.Value);
                    }

                    // Exécution de la commande
                    cmd.ExecuteNonQuery();
                }
            }
            catch (System.Exception ex)
            {
                // Gérer l'exception (log ou remontée)
                throw new System.Exception($"Erreur lors de la mise à jour de l'article : {ex.Message}", ex);
            }
            finally
            {
                // Fermeture de la connexion
                dbConnector.FermerConnexion();
            }
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

        public List<Article> GetAllArticlesEstActive()
        {
            dbConnector.OuvrirConnexion();

            string query = "SELECT * FROM ARTICLE WHERE EstActif = 1";
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