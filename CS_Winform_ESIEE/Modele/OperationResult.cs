using System;

namespace CS_Winform_ESIEE.Modele
{
    /// <summary>
    /// Classe représentant le résultat d'une opération du contrôleur JsonEditor.
    /// </summary>
    public class OperationResult
    {
        /// <summary>
        /// Indique si l'opération a réussi.
        /// </summary>
        public bool Success { get; set; }

        /// <summary>
        /// Message associé au résultat de l'opération.
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Exception associée à l'opération, si une erreur s'est produite.
        /// </summary>
        public Exception Exception { get; set; }

        /// <summary>
        /// Initialise une nouvelle instance de la classe <see cref="OperationResult"/>.
        /// </summary>
        /// <param name="success">Indique si l'opération a réussi.</param>
        /// <param name="message">Message associé au résultat de l'opération.</param>
        /// <param name="exception">Exception associée à l'opération, si une erreur s'est produite.</param>
        public OperationResult(bool success, string message, Exception exception = null)
        {
            Success = success;
            Message = message;
            Exception = exception;
        }
    }
}