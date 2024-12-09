using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_Winform_ESIEE.Modele
{
    /// <summary>
    /// Représente un article avec diverses propriétés telles que l'ID, l'ID de catégorie, le nom, le prix unitaire, la quantité, la promotion et le statut actif.
    /// </summary>
    public class Article
    {
        /// <summary>
        /// Obtient ou définit l'ID de l'article.
        /// </summary>
        public int IdArticle { get; set; }

        /// <summary>
        /// Obtient ou définit l'ID de catégorie de l'article.
        /// </summary>
        public int IdCategorie { get; set; }

        /// <summary>
        /// Obtient ou définit le nom de l'article.
        /// </summary>
        public string Nom { get; set; }

        /// <summary>
        /// Obtient ou définit le prix unitaire de l'article.
        /// </summary>
        public decimal PrixUnitaire { get; set; }

        /// <summary>
        /// Obtient ou définit la quantité de l'article.
        /// </summary>
        public int Quantite { get; set; }

        /// <summary>
        /// Obtient ou définit la valeur de la promotion de l'article.
        /// </summary>
        public int Promotion { get; set; }

        /// <summary>
        /// Obtient ou définit une valeur indiquant si l'article est actif.
        /// </summary>
        public bool EstActif { get; set; }
    }
}