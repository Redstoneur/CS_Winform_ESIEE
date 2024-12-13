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
using CS_Winform_ESIEE.Data;
using CS_Winform_ESIEE.Modele;
using CS_Winform_ESIEE.Vue;
using DotNetEnv;

namespace CS_Winform_ESIEE
{
    /// <summary>
    /// Form for managing stock in the application.
    /// </summary>
    public partial class GestionStock : Form
    {
        private JsonEditorController jsonEditorController = new JsonEditorController();
        private ArticleController articleController;
        private List<Article> articles; // Stores the retrieved articles
        private CategorieController categorieController;
        private List<Categorie> categories; // Stores the retrieved categories
        private Article selectedArticle; // Currently selected article

        /// <summary>
        /// Initializes a new instance of the <see cref="GestionStock"/> class.
        /// </summary>
        public GestionStock()
        {
            InitializeComponent();
            articleController = new ArticleController();
            categorieController = new CategorieController();
        }

        /// <summary>
        /// Loads categories into the ListBox.
        /// </summary>
        private void ChargerCategories()
        {
            try
            {
                // Retrieve all categories
                categories = categorieController.GetAllCategories();

                // Load category names into the ListBox
                Categories.Items.Clear(); // Assuming the ListBox is named "Categories"
                foreach (var categorie in categories)
                {
                    Categories.Items.Add(categorie.Nom);
                    CategorieSelect.Items.Add(categorie.Nom); // Adds only the names
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors du chargement des catégories : {ex.Message}", "Erreur",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Loads articles into the ListBox.
        /// </summary>
        public void LoadArticle()
        {
            try
            {
                // Retrieve all active articles
                articles = articleController.GetAllArticlesEstActive();

                // Load article names into the ListBox
                Articles.Items.Clear();
                foreach (var article in articles)
                {
                    Articles.Items.Add(article.Nom); // Adds only the names
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors du chargement des articles : {ex.Message}", "Erreur",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Event handler for form load event.
        /// </summary>
        private void Form1_Load(object sender, EventArgs e)
        {
            LoadArticle();
            ChargerCategories();
            button3.Enabled = false;
            button4.Enabled = false;
            TypePromotionBox.Enabled = false;
        }

        /// <summary>
        /// Event handler for switching to restocking mode.
        /// </summary>
        private void button1_Click(object sender, EventArgs e)
        {
            ViewController.gestionreappromixed.Location = ViewController.gestionstock.Location;
            ViewController.gestionreappromixed.StartPosition = FormStartPosition.Manual;
            ViewController.gestionreappromixed.FormClosing += delegate
            {
                try
                {
                    if (ViewController.gestionstock.Enabled) ViewController.gestionstock.Show();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("secure for avoid crash");
                }
            };
            if (ViewController.gestionreappromixed.Enabled) ViewController.gestionreappromixed.Show();
            if (ViewController.gestionstock.Enabled) ViewController.gestionstock.Hide();
        }

        /// <summary>
        /// Event handler for applying/removing promotion.
        /// </summary>
        private void button4_Click(object sender, EventArgs e)
        {
            if (selectedArticle != null)
            {
                try
                {
                    try
                    {
                        if (decimal.TryParse(textBox5.Text, out decimal promotionValue))
                        {
                            selectedArticle.Promotion = (int)promotionValue; // Updates the promotion
                            int value = Convert.ToInt16(promotionValue);
                            articleController.UpdatePromotion(selectedArticle, value,
                                TypePromoExtensions.from_string((string)TypePromotionBox.SelectedItem));
                        }
                        else
                        {
                            MessageBox.Show("Veuillez entrer une valeur numérique valide pour la promotion.", "Erreur",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Erreur lors de la mise à jour de la promotion : {ex.Message}", "Erreur",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    if (button4.Text == "Appliquer")
                    {
                        MessageBox.Show($"Promotion de {selectedArticle.Promotion} appliquée à {selectedArticle.Nom}.",
                            "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        button4.Text = "Supprimer";
                    }
                    else if (button4.Text == "Supprimer")
                    {
                        articleController.UpdatePromotion(selectedArticle, 0);
                        selectedArticle.Promotion = 0;
                        textBox5.Text = "0";
                        MessageBox.Show($"Promotion supprimée pour {selectedArticle.Nom}.", "Succès",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        button4.Text = "Appliquer";
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erreur lors de la gestion de la promotion : {ex.Message}", "Erreur",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Aucun article sélectionné. Veuillez sélectionner un article avant de continuer.",
                    "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        /// <summary>
        /// Event handler for article selection change.
        /// </summary>
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Articles.SelectedIndex >= 0) // Checks if an item is selected
            {
                textBox5.Enabled = true;
                try
                {
                    // Retrieve the corresponding article
                    selectedArticle = articles[Articles.SelectedIndex];

                    // Display information in text fields
                    textBox1.Text = selectedArticle.Nom; // Displays the name
                    textBox3.Text = selectedArticle.PrixUnitaire.ToString(); // Displays the unit price
                    textBox2.Text = selectedArticle.Quantite.ToString(); // Displays the quantity
                    textBox5.Text = selectedArticle.Promotion.ToString(); // Displays the promotion
                    DelArticleName.Text = selectedArticle.Nom.ToString(); // Displays the article to be deleted

                    if (selectedArticle.Promotion > 0)
                        button4.Text = "Supprimer";
                    else if (selectedArticle.Promotion <= 0)
                        button4.Text = "Appliquer";

                    button3.Enabled = true;
                    button4.Enabled = true;
                    TypePromotionBox.Enabled = true;
                    TypePromotionBox.Items.Clear();
                    TypePromotionBox.Items.Add(TypePromo.Pourcentage.to_string());
                    TypePromotionBox.Items.Add(TypePromo.Montant.to_string());
                    TypePromotionBox.SelectedItem =
                        TypePromoExtensions.from_string(selectedArticle.TypePromotion).to_string();
                    label1.Text = TypePromoExtensions.from_string(selectedArticle.TypePromotion).get_symbol();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erreur lors de la sélection de l'article : {ex.Message}", "Erreur",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// Event handler for File -> Exit menu item.
        /// </summary>
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Event handler for modifying an article.
        /// </summary>
        private void button3_Click(object sender, EventArgs e)
        {
            groupBox4.Visible = true;
            ModifNom.Text = selectedArticle.Nom;
            ModifPrix.Text = selectedArticle.PrixUnitaire.ToString();
            ModifQuantite.Text = selectedArticle.Quantite.ToString();
        }

        /// <summary>
        /// Event handler for About menu item.
        /// </summary>
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(@"Application de gestion de stock pour ESIEE Paris", @"A propos", MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        /// <summary>
        /// Event handler for adding an article.
        /// </summary>
        private void button6_Click(object sender, EventArgs e)
        {
            groupBox2.Visible = true;
        }

        /// <summary>
        /// Event handler for deleting an article.
        /// </summary>
        private void button7_Click(object sender, EventArgs e)
        {
            groupBox3.Visible = true;
        }

        /// <summary>
        /// Event handler for category selection change.
        /// </summary>
        private void Categories_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            try
            {
                // Checks if a category is selected
                if (Categories.SelectedIndex >= 0)
                {
                    // Retrieve the category by its index
                    Categorie selectedCategoryByIndex = categories[Categories.SelectedIndex];

                    if (selectedCategoryByIndex != null)
                    {
                        // Filter articles to display only those with the same IdCategorie as the selected category
                        var filteredArticles = articleController.GetAllArticlesEstActive()
                            .Where(article => article.IdCategorie == selectedCategoryByIndex.IdCategorie)
                            .ToList();

                        // Update the underlying list and the ListBox of articles
                        articles = filteredArticles; // Update the underlying list
                        Articles.Items.Clear();
                        foreach (var article in articles)
                        {
                            Articles.Items.Add(article.Nom); // Adds only the article name
                        }

                        // Clear the current selection in the ListBox
                        Articles.ClearSelected();
                        // Reset the article detail display fields
                        selectedArticle = null;
                        textBox1.Text = "";
                        textBox2.Text = "";
                        textBox3.Text = "";
                        textBox5.Text = "";
                        DelArticleName.Text = "";
                        button3.Enabled = false;
                        button4.Enabled = false;
                    }
                    else
                    {
                        // If the category is not found, display a message or reset the article list
                        MessageBox.Show("Catégorie non trouvée.", "Erreur", MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors de la sélection de la catégorie : {ex.Message}", "Erreur",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Event handler for canceling the add article operation.
        /// </summary>
        private void button2_Click_1(object sender, EventArgs e)
        {
            groupBox2.Visible = false;
        }

        /// <summary>
        /// Event handler for canceling the delete article operation.
        /// </summary>
        private void button9_Click(object sender, EventArgs e)
        {
            groupBox3.Visible = false;
        }

        /// <summary>
        /// Event handler for canceling the modify article operation.
        /// </summary>
        private void button10_Click(object sender, EventArgs e)
        {
            groupBox4.Visible = false;
        }

        /// <summary>
        /// Event handler for canceling the add article operation.
        /// </summary>
        private void Annuler_Click(object sender, EventArgs e)
        {
            groupBox2.Visible = false;
        }

        /// <summary>
        /// Event handler for validating the modification of an article.
        /// </summary>
        private void ValiderModif_Click(object sender, EventArgs e)
        {
            groupBox4.Visible = false;

            try
            {
                if (selectedArticle == null)
                {
                    MessageBox.Show("Aucun article sélectionné pour la modification.", "Erreur", MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return;
                }

                // Retrieve modified data from the user interface
                var data = new Dictionary<string, object>();

                if (!string.IsNullOrWhiteSpace(ModifNom.Text))
                    data["Nom"] = ModifNom.Text;

                if (decimal.TryParse(ModifPrix.Text, out decimal prixUnitaire))
                    data["PrixUnitaire"] = prixUnitaire;

                if (int.TryParse(ModifQuantite.Text, out int quantite))
                    data["Quantite"] = quantite;

                // Check if any data has been provided for the update
                if (data.Count == 0)
                {
                    MessageBox.Show("Aucune modification détectée.", "Information", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    return;
                }

                // Update the article via the controller
                articleController.UpdateArticle(selectedArticle, data);

                // Confirm the update
                MessageBox.Show("L'article a été mis à jour avec succès !", "Succès", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                // Reload articles to update the interface
                LoadArticle();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors de la mise à jour de l'article : {ex.Message}", "Erreur",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Event handler for canceling the delete article operation.
        /// </summary>
        private void AnnulerSuppr_Click(object sender, EventArgs e)
        {
            groupBox3.Visible = false;
        }

        /// <summary>
        /// Event handler for confirming the deletion of an article.
        /// </summary>
        private void ConfirmerSuppr_Click(object sender, EventArgs e)
        {
            try
            {
                articleController.SupprimerArticle(selectedArticle);
                groupBox3.Visible = false;
                LoadArticle();
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Event handler for canceling the modify article operation.
        /// </summary>
        private void ModifAnnuler_Click(object sender, EventArgs e)
        {
            groupBox4.Visible = false;
        }

        /// <summary>
        /// Event handler for validating the addition of an article.
        /// </summary>
        private void Valider_Click(object sender, EventArgs e)
        {
            groupBox2.Visible = false;
            try
            {
                // Retrieve data entered by the user
                string nom = AddNomArticle.Text;
                if (string.IsNullOrWhiteSpace(nom))
                {
                    MessageBox.Show("Le champ Nom est obligatoire.", "Erreur", MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return;
                }

                if (!decimal.TryParse(AddPrixArticle.Text, out decimal prixUnitaire))
                {
                    MessageBox.Show("Veuillez entrer un prix valide.", "Erreur", MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return;
                }

                if (!int.TryParse(AddQuantiteArticle.Text, out int quantite))
                {
                    MessageBox.Show("Veuillez entrer une quantité valide.", "Erreur", MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return;
                }

                // Check and retrieve the selected category
                if (CategorieSelect.SelectedIndex < 0)
                {
                    MessageBox.Show("Veuillez sélectionner une catégorie.", "Erreur", MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return;
                }

                var selectedCategory = categories[CategorieSelect.SelectedIndex];
                int idCategorie = selectedCategory.IdCategorie;

                // Call the controller to add the article
                articleController.AjouterArticle(
                    idCategorie: idCategorie,
                    nom: nom,
                    prixUnitaire: prixUnitaire,
                    quantite: quantite
                );

                MessageBox.Show("L'article a été ajouté avec succès !", "Succès", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                // Reload articles to update the interface
                LoadArticle();
                groupBox2.Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors de l'ajout de l'article : {ex.Message}", "Erreur", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Event handler for exporting data to a JSON file.
        /// </summary>
        private void jSONToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Title = @"Exporter les données vers un fichier JSON";
            saveFileDialog.Filter = @"Fichiers JSON (*.json)|*.json";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string fileName = saveFileDialog.FileName;

                // If the file is not a JSON file, display an error message and exit
                if (!fileName.EndsWith(".json"))
                {
                    MessageBox.Show(
                        @"Le fichier spécifié n'est pas un fichier JSON. Veuillez choisir un fichier JSON.",
                        @"Erreur",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Import data from the JSON file
                OperationResult result = jsonEditorController.CreerJson(fileName);

                // Display the result of the operation
                if (result.Success)
                {
                    MessageBox.Show(result.Message, @"Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(result.Message, @"Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// Event handler for importing data from a JSON file.
        /// </summary>
        private void jSONToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = @"Importer les données depuis un fichier JSON";
            openFileDialog.Filter = @"Fichiers JSON (*.json)|*.json";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string fileName = openFileDialog.FileName;

                // If the file is not a JSON file, display an error message and exit
                if (!fileName.EndsWith(".json"))
                {
                    MessageBox.Show(
                        @"Le fichier spécifié n'est pas un fichier JSON. Veuillez choisir un fichier JSON.",
                        @"Erreur",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Import data from the JSON file
                OperationResult result = jsonEditorController.MettreAJourBaseDeDonnees(fileName);

                // Display the result of the operation
                if (result.Success)
                {
                    MessageBox.Show(result.Message, @"Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Reload categories and articles to update the interface
                    ChargerCategories();
                    LoadArticle();
                }
                else
                {
                    MessageBox.Show(result.Message, @"Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// Event handler for File -> Exit menu item.
        /// </summary>
        private void exitToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        /// <summary>
        /// Event handler for the promotion type selection change.
        /// </summary>
        private void TypePromotionBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            label1.Text = TypePromoExtensions.from_string((string)TypePromotionBox.SelectedItem).get_symbol();
        }
    }
}