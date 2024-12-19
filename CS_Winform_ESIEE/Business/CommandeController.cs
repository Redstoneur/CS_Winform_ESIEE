using CS_Winform_ESIEE.Modele;
using CS_Winform_ESIEE.Data;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace CS_Winform_ESIEE.Business
{
    /// <summary>
    /// Classe contrôleur pour gérer les commandes.
    /// </summary>
    public class CommandeController
    {
        /// <summary>
        /// Le connecteur de base de données.
        /// </summary>
        private DatabaseConnector dbConnector;

        /// <summary>
        /// Initialise une nouvelle instance de la classe <see cref="CommandeController"/>.
        /// </summary>
        public CommandeController()
        {
            dbConnector = new DatabaseConnector();
        }

        /// <summary>
        /// Ajoute une nouvelle commande à la base de données.
        /// </summary>
        /// <returns>L'ID de la commande nouvellement ajoutée.</returns>
        public long AjouterCommande()
        {
            dbConnector.OuvrirConnexion();

            EtatCommande etat = EtatCommande.Commande;

            string query = "INSERT INTO COMMANDE (Etat) VALUES (@Statut)";
            MySqlCommand cmd = new MySqlCommand(query, dbConnector.Connexion);
            cmd.Parameters.AddWithValue("@Statut", etat.to_string());

            cmd.ExecuteNonQuery();

            long id = cmd.LastInsertedId;

            dbConnector.FermerConnexion();

            return id;
        }

        /// <summary>
        /// Met à jour l'état d'une commande existante.
        /// </summary>
        /// <param name="commande">La commande à mettre à jour.</param>
        /// <param name="etat">Le nouvel état de la commande.</param>
        /// <exception cref="Exception">Lancée lorsqu'un état de commande invalide est fourni.</exception>
        public void UpdateCommande(Commande commande, EtatCommande etat)
        {
            dbConnector.OuvrirConnexion();

            DateTime date = DateTime.Now;

            string query = "";

            if (etat == EtatCommande.Commande)
            {
                query +=
                    "UPDATE COMMANDE SET Date = @Date, Etat = @Etat, DateEnvoi = NULL, DateLivraison = NULL WHERE IdCommande = @IdCommande";
            }
            else if (etat == EtatCommande.Envoyee)
            {
                query +=
                    "UPDATE COMMANDE SET DateEnvoi = @Date, Etat = @Etat, DateLivraison = NULL WHERE IdCommande = @IdCommande";
            }
            else if (etat == EtatCommande.Livree)
            {
                if (commande.DateEnvoi == null)
                {
                    query +=
                        "UPDATE COMMANDE SET DateEnvoi = @Date, DateLivraison = @Date, Etat = @Etat WHERE IdCommande = @IdCommande";
                }
                else
                {
                    query += "UPDATE COMMANDE SET DateLivraison = @Date, Etat = @Etat WHERE IdCommande = @IdCommande";
                }
            }
            else if (etat == EtatCommande.Annulee)
            {
                query +=
                    "UPDATE COMMANDE SET Etat = @Etat, Date = @Date, DateEnvoi = NULL, DateLivraison = NULL WHERE IdCommande = @IdCommande";
            }
            else
            {
                throw new Exception("État de commande invalide.");
            }

            MySqlCommand cmd = new MySqlCommand(query, dbConnector.Connexion);
            cmd.Parameters.AddWithValue("@Date", date);
            cmd.Parameters.AddWithValue("@Etat", etat.to_string());
            cmd.Parameters.AddWithValue("@IdCommande", commande.IdCommande);
            cmd.ExecuteNonQuery();

            dbConnector.FermerConnexion();
        }

        /// <summary>
        /// Récupère une commande par son ID.
        /// </summary>
        /// <param name="id">L'ID de la commande à récupérer.</param>
        /// <returns>La commande avec l'ID spécifié, ou null si non trouvée.</returns>
        public Commande GetCommandeById(int id)
        {
            dbConnector.OuvrirConnexion();

            string query = "SELECT * FROM COMMANDE WHERE IdCommande = @IdCommande";
            MySqlCommand cmd = new MySqlCommand(query, dbConnector.Connexion);
            cmd.Parameters.AddWithValue("@IdCommande", id);

            MySqlDataReader reader = cmd.ExecuteReader();
            Commande commande = null;
            if (reader.Read())
            {
                commande = new Commande
                {
                    IdCommande = reader.GetInt32("IdCommande"),
                    Etat = reader.GetString("Etat"),
                    Date = reader.GetDateTime("Date"),
                    DateEnvoi = reader.IsDBNull(reader.GetOrdinal("DateEnvoi"))
                        ? null
                        : (DateTime?)reader.GetDateTime("DateEnvoi"),
                    DateLivraison = reader.IsDBNull(reader.GetOrdinal("DateLivraison"))
                        ? null
                        : (DateTime?)reader.GetDateTime("DateLivraison")
                };
            }

            reader.Close();
            dbConnector.FermerConnexion();

            return commande;
        }

        /// <summary>
        /// Récupère toutes les commandes de la base de données.
        /// </summary>
        /// <returns>Une liste de toutes les commandes.</returns>
        public List<Commande> GetAllCommandes()
        {
            dbConnector.OuvrirConnexion();

            string query = "SELECT * FROM COMMANDE";
            MySqlCommand cmd = new MySqlCommand(query, dbConnector.Connexion);

            MySqlDataReader reader = cmd.ExecuteReader();
            List<Commande> commandes = new List<Commande>();
            while (reader.Read())
            {
                Commande commande = new Commande
                {
                    IdCommande = reader.GetInt32("IdCommande"),
                    Etat = reader.GetString("Etat"),
                    Date = reader.GetDateTime("Date"),
                    DateEnvoi = reader.IsDBNull(reader.GetOrdinal("DateEnvoi"))
                        ? null
                        : (DateTime?)reader.GetDateTime("DateEnvoi"),
                    DateLivraison = reader.IsDBNull(reader.GetOrdinal("DateLivraison"))
                        ? null
                        : (DateTime?)reader.GetDateTime("DateLivraison")
                };
                commandes.Add(commande);
            }

            reader.Close();
            dbConnector.FermerConnexion();

            return commandes;
        }
    }
}