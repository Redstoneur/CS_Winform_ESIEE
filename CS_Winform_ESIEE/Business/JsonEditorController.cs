using System;
using CS_Winform_ESIEE.Data;
using CS_Winform_ESIEE.Modele;

namespace CS_Winform_ESIEE.Business
{
    public class JsonEditorController
    {
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