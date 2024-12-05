using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_Winform_ESIEE.Modele
{
    public class Article
    {
        public int IdArticle { get; set; }
        public int IdCategorie { get; set; }
        public string Nom { get; set; }
        public decimal PrixUnitaire { get; set; }
        public int Quantite { get; set; }
        public int Promotion { get; set; }
        public bool EstActif { get; set; }
    }
}

