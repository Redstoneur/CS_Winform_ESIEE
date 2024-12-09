using System;
using CS_Winform_ESIEE.Data;
using CS_Winform_ESIEE.Modele;

namespace CS_Winform_ESIEE.Business
{
    /// <summary>
    /// Classe contrôleur pour gérer les opérations JSON.
    /// </summary>
    public class JsonEditorController
    {
        /// <summary>
        /// Crée un fichier JSON au chemin spécifié.
        /// </summary>
        /// <param name="cheminJson">Le chemin où le fichier JSON sera créé.</param>
        /// <returns>Un résultat d'opération indiquant le succès ou l'échec de l'opération.</returns>
        public OperationResult CreerJson(string cheminJson)
        {
            try
            {
                JsonEditor.CreerJson(cheminJson);
                return new OperationResult(true, "Le fichier JSON a été créé avec succès.");
            }
            catch (Exception ex)
            {
                return new OperationResult(false,
                    $"Une erreur s'est produite lors de la création du fichier JSON : {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Met à jour la base de données en utilisant le fichier JSON au chemin spécifié.
        /// </summary>
        /// <param name="cheminJson">Le chemin du fichier JSON utilisé pour mettre à jour la base de données.</param>
        /// <returns>Un résultat d'opération indiquant le succès ou l'échec de l'opération.</returns>
        public OperationResult MettreAJourBaseDeDonnees(string cheminJson)
        {
            try
            {
                JsonEditor.MettreAJourBaseDeDonnees(cheminJson);
                return new OperationResult(true, "La base de données a été mise à jour avec succès.");
            }
            catch (Exception ex)
            {
                return new OperationResult(false,
                    $"Une erreur s'est produite lors de la mise à jour de la base de données : {ex.Message}", ex);
            }
        }
    }
}