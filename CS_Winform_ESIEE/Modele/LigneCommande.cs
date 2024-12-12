using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_Winform_ESIEE.Modele
{
    /// <summary>
    /// Représente un élément de ligne dans une commande.
    /// </summary>
    public class LigneCommande
    {
        /// <summary>
        /// Obtient ou définit l'identifiant unique de l'élément de ligne.
        /// </summary>
        public int IdLigneCommande { get; set; }

        /// <summary>
        /// Obtient ou définit l'identifiant unique de la commande.
        /// </summary>
        public int IdCommande { get; set; }

        /// <summary>
        /// Obtient ou définit l'identifiant unique de l'article.
        /// </summary>
        public int IdArticle { get; set; }

        /// <summary>
        /// Obtient ou définit le prix unitaire de l'article.
        /// </summary>
        public decimal PrixUnitaire { get; set; }

        /// <summary>
        /// Obtient ou définit la quantité de l'article.
        /// </summary>
        public int Quantite { get; set; }

        /// <summary>
        /// Obtient ou définit la promotion appliquée à l'article.
        /// </summary>
        public int Promotion { get; set; }

        /// <summary>
        /// Obtient ou définit le type de promotion de l'article.
        /// </summary>
        public string TypePromotion { get; set; }
        
        /// <summary>
        /// Obtient le prix unitaire de l'article après application de la promotion.
        /// </summary>
        public decimal PrixUnitairePromotion
        {
            get
            {
                if (TypePromotion == TypePromo.Pourcentage.to_string())
                {
                    return PrixUnitaire * (1 - (decimal)Promotion / 100);
                }
                else if (TypePromotion == TypePromo.Montant.to_string())
                {
                    return PrixUnitaire - Promotion;
                }
                else
                {
                    return PrixUnitaire;
                }
            }
        }

        /// <summary>
        /// Obtient le prix total pour la quantité d'articles commandés après application de la promotion.
        /// </summary>
        public decimal PrixTotal => PrixUnitairePromotion * Quantite;
    }
}