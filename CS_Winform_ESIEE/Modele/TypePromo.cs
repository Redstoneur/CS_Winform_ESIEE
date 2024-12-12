namespace CS_Winform_ESIEE.Modele
{
    /// <summary>
    /// Représente le type de promotion appliquée à un article.
    /// </summary>
    public enum TypePromo
    {
        /// <summary>
        /// La promotion est un pourcentage.
        /// </summary>
        Pourcentage,
        
        /// <summary>
        /// La promotion est un montant.
        /// </summary>
        Montant
    }
    
    /// <summary>
    /// Fournit des méthodes d'extension pour l'énumération TypePromo.
    /// </summary>
    public static class TypePromoExtensions
    {
        /// <summary>
        /// Convertit la valeur TypePromo en sa représentation sous forme de chaîne.
        /// </summary>
        /// <param name="typePromo">La valeur TypePromo.</param>
        /// <returns>La représentation sous forme de chaîne de la valeur TypePromo.</returns>
        public static string to_string(this TypePromo typePromo)
        {
            switch (typePromo)
            {
                case TypePromo.Pourcentage:
                    return "Pourcentage";
                case TypePromo.Montant:
                    return "Montant";
                default:
                    return null;
            }
        }

        /// <summary>
        /// Convertit une représentation sous forme de chaîne d'un type de promotion en sa valeur TypePromo.
        /// </summary>
        /// <param name="typePromo">La représentation sous forme de chaîne du type de promotion.</param>
        /// <returns>La valeur TypePromo correspondante.</returns>
        public static TypePromo from_string(string typePromo)
        {
            switch (typePromo)
            {
                case "Pourcentage":
                    return TypePromo.Pourcentage;
                case "Montant":
                    return TypePromo.Montant;
                default:
                    return default;
            }
        }
        
        /// <summary>
        /// Donne le symbole associé à un type de promotion.
        /// </summary>
        /// <param name="typePromo">Le type de promotion.</param>
        /// <returns>Le symbole associé au type de promotion.</returns>
        public static string get_symbol(this TypePromo typePromo)
        {
            switch (typePromo)
            {
                case TypePromo.Pourcentage:
                    return "%";
                case TypePromo.Montant:
                    return "€";
                default:
                    return null;
            }
        }
    }
}