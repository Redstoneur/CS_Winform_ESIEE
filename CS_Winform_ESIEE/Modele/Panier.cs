using System.Collections.Generic;

namespace CS_Winform_ESIEE.Modele
{
    /// <summary>
    /// Représente un panier contenant une liste d'articles.
    /// </summary>
    public class Panier
    {
        /// <summary>
        /// Liste des articles dans le panier.
        /// </summary>
        private List<Article> articles;

        /// <summary>
        /// Initialise une nouvelle instance de la classe <see cref="Panier"/> avec une liste vide d'articles.
        /// </summary>
        public Panier()
        {
            articles = new List<Article>();
        }

        /// <summary>
        /// Initialise une nouvelle instance de la classe <see cref="Panier"/> avec une liste spécifiée d'articles.
        /// </summary>
        /// <param name="articles">La liste d'articles pour initialiser le panier.</param>
        public Panier(List<Article> articles)
        {
            this.articles = articles;
        }

        /// <summary>
        /// Ajoute un article au panier.
        /// </summary>
        /// <param name="article">L'article à ajouter.</param>
        public void AjouterArticle(Article article)
        {
            // Si l'article est déjà dans le panier, on incrémente sa quantité.
            foreach (Article a in articles)
            {
                if (a.IdArticle == article.IdArticle)
                {
                    a.Quantite += article.Quantite;
                    return;
                }
            }

            articles.Add(article);
        }

        /// <summary>
        /// Obtient la liste des articles dans le panier.
        /// </summary>
        /// <returns>Une liste d'articles.</returns>
        public List<Article> GetArticles()
        {
            return articles;
        }

        /// <summary>
        /// Calcule le prix total de tous les articles dans le panier, en tenant compte de leur quantité et de la promotion.
        /// </summary>
        /// <returns>Le prix total de tous les articles.</returns>
        public decimal GetTotal()
        {
            decimal total = 0;
            foreach (Article article in articles)
            {
                decimal prix = article.PrixUnitaire * article.Quantite;
                total += prix - (prix * article.Promotion / 100);
            }

            return total;
        }

        /// <summary>
        /// Vide tous les articles du panier.
        /// </summary>
        public void Vider()
        {
            articles.Clear();
        }

        /// <summary>
        /// Supprime un article du panier par son identifiant.
        /// </summary>
        /// <param name="idArticle">L'identifiant de l'article à supprimer.</param>
        public void SupprimerArticleById(int idArticle)
        {
            foreach (Article a in articles)
            {
                if (a.IdArticle == idArticle)
                {
                    articles.Remove(a);
                    return;
                }
            }
        }

        /// <summary>
        /// Retire un nombre spécifié d'exemplaires d'un article du panier par son identifiant.
        /// </summary>
        /// <param name="idArticle">L'identifiant de l'article.</param>
        /// <param name="nbExemplaire">Le nombre d'exemplaires à retirer.</param>
        public void RetirerNbExemplaireArticleById(int idArticle, int nbExemplaire)
        {
            foreach (Article a in articles)
            {
                if (a.IdArticle == idArticle)
                {
                    a.Quantite -= nbExemplaire;
                    if (a.Quantite <= 0)
                    {
                        SupprimerArticleById(idArticle);
                    }

                    return;
                }
            }
        }

        /// <summary>
        /// Redéfinit le nombre d'exemplaires d'un article dans le panier par son identifiant.
        /// </summary>
        /// <param name="idArticle">L'identifiant de l'article.</param>
        /// <param name="nbExemplaire">Le nouveau nombre d'exemplaires.</param>
        public void RedefineNbExemplaireArticleById(int idArticle, int nbExemplaire)
        {
            if (nbExemplaire <= 0)
            {
                SupprimerArticleById(idArticle);
                return;
            }

            foreach (Article a in articles)
            {
                if (a.IdArticle == idArticle)
                {
                    a.Quantite = nbExemplaire;
                    return;
                }
            }
        }
    }
}