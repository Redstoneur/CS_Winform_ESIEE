using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_Winform_ESIEE.Modele
{
    public class LigneCommande
    {
        public int IdLigneCommande { get; set; }
        public int IdCommande { get; set; }
        public int IdArticle { get; set; }
        public decimal PrixUnitaire { get; set; }
        public int Quantite { get; set; }
        public int Promotion { get; set; }
    }
}

