using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_Winform_ESIEE.Modele
{
    /// <summary>
    /// Représente une catégorie avec un ID, un nom et un statut actif.
    /// </summary>
    public class Categorie
    {
        /// <summary>
        /// Obtient ou définit l'ID de la catégorie.
        /// </summary>
        public int IdCategorie { get; set; }

        /// <summary>
        /// Obtient ou définit le nom de la catégorie.
        /// </summary>
        public string Nom { get; set; }

        /// <summary>
        /// Obtient ou définit une valeur indiquant si la catégorie est active.
        /// </summary>
        public bool EstActif { get; set; }
    }
}