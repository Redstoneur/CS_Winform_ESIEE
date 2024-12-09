using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_Winform_ESIEE.Modele
{
    /// <summary>
    /// Représente une commande avec ses détails.
    /// </summary>
    public class Commande
    {
        /// <summary>
        /// Obtient ou définit l'ID de la commande.
        /// </summary>
        public int IdCommande { get; set; }

        /// <summary>
        /// Obtient ou définit l'état de la commande.
        /// </summary>
        public string Etat { get; set; }

        /// <summary>
        /// Obtient ou définit la date de la commande.
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// Obtient ou définit la date d'envoi de la commande.
        /// Nullable si la commande n'a pas encore été envoyée.
        /// </summary>
        public DateTime? DateEnvoi { get; set; }

        /// <summary>
        /// Obtient ou définit la date de livraison de la commande.
        /// Nullable si la commande n'a pas encore été livrée.
        /// </summary>
        public DateTime? DateLivraison { get; set; }
    }
}