using CS_Winform_ESIEE.Modele;

namespace CS_Winform_ESIEE.Business
{
    public class PanierController
    {
        public void Commander(Panier panier)
        {
            // Ajouter la commande
            CommandeController commandeController = new CommandeController();
            long idCommande = commandeController.AjouterCommande();

            // transformer la liste d'articles en lignes de commande et les ajouter
            LigneCommandeController ligneCommandeController = new LigneCommandeController();
            foreach (Article article in panier.GetArticles())
            {
                ligneCommandeController.AjouterLigneCommande(idCommande, article);
            }
        }
    }
}