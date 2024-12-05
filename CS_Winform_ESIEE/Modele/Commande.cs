using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_Winform_ESIEE.Modele
{
    public class Commande
    {
        public int IdCommande { get; set; }
        public string Etat { get; set; }
        public DateTime Date { get; set; }
        public DateTime? DateEnvoi { get; set; }
        public DateTime? DateLivraison { get; set; }
    }
}