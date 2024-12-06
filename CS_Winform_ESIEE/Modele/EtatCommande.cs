namespace CS_Winform_ESIEE.Modele
{
    /// <summary>
    /// Represents the state of an order.
    /// </summary>
    public enum EtatCommande
    {
        /// <summary>
        /// The order has been placed.
        /// </summary>
        Commande,

        /// <summary>
        /// The order has been sent.
        /// </summary>
        Envoyee,

        /// <summary>
        /// The order has been delivered.
        /// </summary>
        Livree
    }

    /// <summary>
    /// Provides extension methods for the EtatCommande enum.
    /// </summary>
    public static class EtatCommandeExtensions
    {
        /// <summary>
        /// Converts the EtatCommande value to its string representation.
        /// </summary>
        /// <param name="etat">The EtatCommande value.</param>
        /// <returns>The string representation of the EtatCommande value.</returns>
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
        /// Converts a string representation of an order state to its EtatCommande value.
        /// </summary>
        /// <param name="etat">The string representation of the order state.</param>
        /// <returns>The corresponding EtatCommande value.</returns>
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