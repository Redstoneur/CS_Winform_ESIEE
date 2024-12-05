using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_Winform_ESIEE.Modele
{
    public class Panier
    {
        List<Article> articles;
        
        public Panier()
        {
            articles = new List<Article>();
        }
        
        public Panier(List<Article> articles)
        {
            this.articles = articles;
        }
        
        public void AjouterArticle(Article article)
        {
            articles.Add(article);
        }
        
        public void SupprimerArticle(Article article)
        {
            articles.Remove(article);
        }
        
        public List<Article> GetArticles()
        {
            return articles;
        }
        
        
        public decimal GetTotal()
        {
            decimal total = 0;
            foreach (Article article in articles)
            {
                decimal prix = article.PrixUnitaire * article.Quantite;
                total += prix - (prix * article.Promotion/100);
            }
            return total;
        }
        
        public void Vider()
        {
            articles.Clear();
        }
    }
}
