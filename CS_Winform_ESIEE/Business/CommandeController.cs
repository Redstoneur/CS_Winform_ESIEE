using CS_Winform_ESIEE.Modele;
using CS_Winform_ESIEE.Data;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_Winform_ESIEE.Business
{
    public class CommandeController
    {
        private DatabaseConnector dbConnector;

        public CommandeController()
        {
            dbConnector = new DatabaseConnector();
        }

        public void AjouterCommande(Commande commande)
        {
            dbConnector.OuvrirConnexion();

            string query = "INSERT INTO COMMANDE (DateCommande, Statut) VALUES (@IdClient, @DateCommande, @Statut)";
            MySqlCommand cmd = new MySqlCommand(query, dbConnector.Connexion);
            cmd.Parameters.AddWithValue("@Statut", commande.Etat);

            cmd.ExecuteNonQuery();

            dbConnector.FermerConnexion();
        }

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