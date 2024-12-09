using CS_Winform_ESIEE.Modele;

namespace CS_Winform_ESIEE.Business
{
    /// <summary>
    /// La classe PanierController gère les opérations liées au panier d'achat (Panier).
    /// </summary>
    public class PanierController
    {
        /// <summary>
        /// Passe une commande basée sur les articles dans le panier d'achat fourni (Panier).
        /// </summary>
        /// <param name="panier">Le panier d'achat contenant les articles à commander.</param>
        public void Commander(Panier panier)
        {
            // Créer une nouvelle commande
            CommandeController commandeController = new CommandeController();
            long idCommande = commandeController.AjouterCommande();

            // Convertir la liste des articles en lignes de commande et les ajouter
            LigneCommandeController ligneCommandeController = new LigneCommandeController();
            foreach (Article article in panier.GetArticles())
            {
                ligneCommandeController.AjouterLigneCommande(idCommande, article);
            }
        }
    }
}