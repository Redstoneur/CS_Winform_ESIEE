using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CS_Winform_ESIEE.Business;
using CS_Winform_ESIEE.Modele;
using CS_Winform_ESIEE.Vue;

namespace CS_Winform_ESIEE
{
    public partial class GestionStock : Form
    {
        private ArticleController articleController;
        private List<Article> articles; // Stocke les articles récupérés

        private CategorieController categorieController;
        private List<Categorie> categories;

         private Article selectedArticle; // Article actuellement sélectionné
        public GestionStock()
        {
            InitializeComponent();
            articleController = new ArticleController();
            categorieController = new CategorieController();
        }
        /**
 * Méthode pour charger les catégories dans la ListBox Categories
 */
private void ChargerCategories()
{
    try
    {
        // Récupérer toutes les catégories
        categories = categorieController.GetAllCategories();

        // Charger les noms des catégories dans la ListBox
        Categories.Items.Clear(); // Supposons que le ListBox s'appelle "Categories"
        foreach (var categorie in categories)
        {
            Categories.Items.Add(categorie.Nom); // Ajoute uniquement les noms
        }
    }
    catch (Exception ex)
    {
        MessageBox.Show($"Erreur lors du chargement des catégories : {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }
}

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                // Récupérer tous les articles
                articles = articleController.GetAllArticles();

                // Charger les noms des articles dans la ListBox
                Articles.Items.Clear();
                foreach (var article in articles)
                {
                    Articles.Items.Add(article.Nom); // Ajoute uniquement les noms
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors du chargement des articles : {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            ChargerCategories();

            

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        /**
         * Bouton de passage en mode réapprovisionnement
         */
        private void button1_Click(object sender, EventArgs e)
        {
        }

        /**
         * Champ de text du nom de l'article
         */
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }


        /**
         * Bouton d'application/suppression de la remise
         */
        private void button4_Click(object sender, EventArgs e)
        {
           if (selectedArticle != null)
            {
                try
                {
                    if (button4.Text == "Appliquer")
                    {
                        MessageBox.Show($"Promotion de {selectedArticle.Promotion} appliquée à {selectedArticle.Nom}.", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        button4.Text = "Supprimer";
                    }
                    else if (button4.Text == "Supprimer")
                    {
                        selectedArticle.Promotion = 0;
                        textBox5.Text = "0";
                        MessageBox.Show($"Promotion supprimée pour {selectedArticle.Nom}.", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        button4.Text = "Appliquer";
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erreur lors de la gestion de la promotion : {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Aucun article sélectionné. Veuillez sélectionner un article avant de continuer.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }


        }

        /**
         * Label "Articles"
         */

        private void label2_Click(object sender, EventArgs e)
        {

        }

        /**
         * Label prix 
         */
        private void label4_Click(object sender, EventArgs e)
        {

        }

        /**
         * Groupe de détails d'articles 
         */
        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        /**
         * Boutton d'historique 
         */
        private void button5_Click(object sender, EventArgs e)
        {

        }
        /**
         * Liste d'articles
         */
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Articles.SelectedIndex >= 0) // Vérifie qu'un élément est sélectionné
            {
                try
                {
                    // Récupérer l'article correspondant
                     selectedArticle = articles[Articles.SelectedIndex];
                    

                    // Afficher les informations dans les champs texte
                    textBox1.Text = selectedArticle.Nom; // Affiche le nom
                    textBox3.Text = selectedArticle.PrixUnitaire.ToString(); // Affiche le nom
                    textBox2.Text = selectedArticle.Quantite.ToString(); // Affiche la quantité
                    textBox5.Text = selectedArticle.Promotion.ToString(); // affiche la remise
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erreur lors de la sélection de l'article : {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void gfsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        /**
         * Barre de Navigation File -> Exit 
         */
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }


        /**
         * Liste de catégories
         */
        private void Categories_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        /**
         * Champ de text de la remise
         */
        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        /**
         * Champ de text de la quantité
         */
        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        /**
         * Label Quantités 
         */

        private void label5_Click(object sender, EventArgs e)
        {

        }

        /**
         * Bouton modifier l'article 
         */
        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        /**
         * Bouton ajouter un article 
         */
        private void button6_Click(object sender, EventArgs e)
        {

        }


        /**
         * Bouton supprimer un article
         */
        private void button7_Click(object sender, EventArgs e)
        {

        }

        /**
         * Textbox Remise 
         */
        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            if (selectedArticle != null)
            {
                try
                {
                    if (decimal.TryParse(textBox5.Text, out decimal promotionValue))
                    {
                        selectedArticle.Promotion = (int)promotionValue; // Met à jour la promotion
                    }
                    else
                    {
                        MessageBox.Show("Veuillez entrer une valeur numérique valide pour la promotion.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erreur lors de la mise à jour de la promotion : {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        

        }

        private void Categories_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            try
        {
        // Vérifie si une catégorie est sélectionnée
        if (Categories.SelectedIndex >= 0)
        {
            // Récupère la categorie a partir de son index
            Categorie  selectedCategoryByIndex =categories[Categories.SelectedIndex];

            if (selectedCategoryByIndex != null)
            {
                // Filtrer les articles pour afficher uniquement ceux qui ont le même IdCategorie que la catégorie sélectionnée
                List<Article> filteredArticles = articles.Where(article => article.IdCategorie == selectedCategoryByIndex.IdCategorie).ToList();

                // Mettre à jour la ListBox des articles
                Articles.Items.Clear();
                foreach (var article in filteredArticles)
                {
                    Articles.Items.Add(article.Nom); // Ajoute uniquement le nom de l'article
                }
            }
            else
            {
                // Si la catégorie n'est pas trouvée, afficher un message ou réinitialiser la liste des articles
                MessageBox.Show("Catégorie non trouvée.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        
    }
    catch (Exception ex)
    {
        MessageBox.Show($"Erreur lors de la sélection de la catégorie : {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }
                
     }
    }
}
