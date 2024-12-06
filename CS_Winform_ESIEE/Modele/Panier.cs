using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            articles.Add(article);
        }

        /// <summary>
        /// Supprime un article du panier.
        /// </summary>
        /// <param name="article">L'article à supprimer.</param>
        public void SupprimerArticle(Article article)
        {
            articles.Remove(article);
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
    }
}