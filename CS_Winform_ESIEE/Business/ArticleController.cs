using CS_Winform_ESIEE.Modele;
using CS_Winform_ESIEE.Data;
using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace CS_Winform_ESIEE.Business
{
    /// <summary>
    /// Classe contrôleur pour gérer les articles.
    /// </summary>
    public class ArticleController
    {
        /// <summary>
        /// Le connecteur de base de données.
        /// </summary>
        private DatabaseConnector dbConnector;

        /// <summary>
        /// Initialise une nouvelle instance de la classe <see cref="ArticleController"/>.
        /// </summary>
        public ArticleController()
        {
            dbConnector = new DatabaseConnector();
        }

        /// <summary>
        /// Ajoute un nouvel article à la base de données.
        /// </summary>
        /// <param name="idCategorie">L'ID de la catégorie de l'article.</param>
        /// <param name="nom">Le nom de l'article.</param>
        /// <param name="prixUnitaire">Le prix unitaire de l'article.</param>
        /// <param name="quantite">La quantité de l'article.</param>
        /// <param name="promotion">La valeur de la promotion de l'article (par défaut 0).</param>
        /// <param name="estActif">Indique si l'article est actif (par défaut true).</param>
        /// <exception cref="System.Exception">Lancée lorsque la catégorie n'existe pas.</exception>
        public void AjouterArticle(int idCategorie, string nom, decimal prixUnitaire, int quantite, int promotion = 0,
            bool estActif = true)
        {
            // Vérifie que la catégorie existe
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

        /// <summary>
        /// Marque un article comme inactif.
        /// </summary>
        /// <param name="article">L'article à marquer comme inactif.</param>
        public void SupprimerArticle(Article article)
        {
            UpdateEstActif(article, false);
        }

        /// <summary>
        /// Met à jour la valeur de la promotion d'un article.
        /// </summary>
        /// <param name="article">L'article à mettre à jour.</param>
        /// <param name="promotion">La nouvelle valeur de la promotion.</param>
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

        /// <summary>
        /// Met à jour le statut actif d'un article.
        /// </summary>
        /// <param name="article">L'article à mettre à jour.</param>
        /// <param name="estActif">Le nouveau statut actif.</param>
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

        /// <summary>
        /// Met à jour les champs spécifiés d'un article.
        /// </summary>
        /// <param name="article">L'article à mettre à jour.</param>
        /// <param name="data">Un dictionnaire contenant les champs à mettre à jour et leurs nouvelles valeurs.</param>
        /// <exception cref="System.ArgumentException">Lancée lorsqu'une clé invalide est fournie dans le dictionnaire de données.</exception>
        /// <exception cref="System.Exception">Lancée lorsqu'une erreur se produit lors de la mise à jour.</exception>
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

        /// <summary>
        /// Récupère un article par son ID.
        /// </summary>
        /// <param name="id">L'ID de l'article.</param>
        /// <returns>L'article avec l'ID spécifié, ou null si non trouvé.</returns>
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

        /// <summary>
        /// Récupère tous les articles de la base de données.
        /// </summary>
        /// <returns>Une liste de tous les articles.</returns>
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

        /// <summary>
        /// Récupère tous les articles actifs de la base de données.
        /// </summary>
        /// <returns>Une liste de tous les articles actifs.</returns>
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