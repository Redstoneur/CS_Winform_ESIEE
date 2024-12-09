namespace CS_Winform_ESIEE.Modele
{
    /// <summary>
    /// Représente l'état d'une commande.
    /// </summary>
    public enum EtatCommande
    {
        /// <summary>
        /// La commande a été passée.
        /// </summary>
        Commande,

        /// <summary>
        /// La commande a été envoyée.
        /// </summary>
        Envoyee,

        /// <summary>
        /// La commande a été livrée.
        /// </summary>
        Livree
    }

    /// <summary>
    /// Fournit des méthodes d'extension pour l'énumération EtatCommande.
    /// </summary>
    public static class EtatCommandeExtensions
    {
        /// <summary>
        /// Convertit la valeur EtatCommande en sa représentation sous forme de chaîne.
        /// </summary>
        /// <param name="etat">La valeur EtatCommande.</param>
        /// <returns>La représentation sous forme de chaîne de la valeur EtatCommande.</returns>
        public static string to_string(this EtatCommande etat)
        {
            switch (etat)
            {
                case EtatCommande.Commande:
                    return "Commande";
                case EtatCommande.Envoyee:
                    return "Envoyée";
                case EtatCommande.Livree:
                    return "Livrée";
                default:
                    return null;
            }
        }

        /// <summary>
        /// Convertit une représentation sous forme de chaîne d'un état de commande en sa valeur EtatCommande.
        /// </summary>
        /// <param name="etat">La représentation sous forme de chaîne de l'état de commande.</param>
        /// <returns>La valeur EtatCommande correspondante.</returns>
        public static EtatCommande from_string(string etat)
        {
            switch (etat)
            {
                case "Commande":
                    return EtatCommande.Commande;
                case "Envoyée":
                    return EtatCommande.Envoyee;
                case "Livrée":
                    return EtatCommande.Livree;
                default:
                    return EtatCommande.Commande;
            }
        }
    }
}