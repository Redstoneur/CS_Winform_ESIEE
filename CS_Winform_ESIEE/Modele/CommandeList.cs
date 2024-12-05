using CS_Winform_ESIEE.Modele;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_Winform_ESIEE.Modele
{
    public class CommandeList : Commande
    {
        public List<LigneCommande> LignesCommandes { get; set; }

        public CommandeList(
            int idCommande, string etat, DateTime date,
            DateTime dateEnvoi, DateTime dateLivraison,
            List<LigneCommande> lignesCommandes
        )
        {
            IdCommande = idCommande;
            Etat = etat;
            Date = date;
            DateEnvoi = dateEnvoi;
            DateLivraison = dateLivraison;
            LignesCommandes = lignesCommandes;
        }
    }
}