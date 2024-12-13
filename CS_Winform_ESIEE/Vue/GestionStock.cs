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
    public partial class GestionStock : Form
    {
        private JsonEditorController jsonEditorController = new JsonEditorController();

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
                    Categories.Items.Add(categorie.Nom);
                    CategorieSelect.Items.Add(categorie.Nom); // Ajoute uniquement les noms
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors du chargement des catégories : {ex.Message}", "Erreur",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void LoadArticle()
        {
            try
            {
                // Récupérer tous les articles
                articles = articleController.GetAllArticlesEstActive();

                // Charger les noms des articles dans la ListBox
                Articles.Items.Clear();
                foreach (var article in articles)
                {
                    Articles.Items.Add(article.Nom); // Ajoute uniquement les noms
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors du chargement des articles : {ex.Message}", "Erreur",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadArticle();
            ChargerCategories();
            button3.Enabled = false;
            button4.Enabled = false;
            TypePromotionBox.Enabled = false;
        }

        // Bouton de passage en mode réapprovisionnement
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

        // Bouton d'application/suppression de la remise
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
                            selectedArticle.Promotion = (int)promotionValue; // Met à jour la promotion
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

        // Liste d'articles
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Articles.SelectedIndex >= 0) // Vérifie qu'un élément est sélectionné
            {
                textBox5.Enabled = true;
                try
                {
                    // Récupérer l'article correspondant
                    selectedArticle = articles[Articles.SelectedIndex];

                    // Afficher les informations dans les champs texte
                    textBox1.Text = selectedArticle.Nom; // Affiche le nom
                    textBox3.Text = selectedArticle.PrixUnitaire.ToString(); // Affiche le nom
                    textBox2.Text = selectedArticle.Quantite.ToString(); // Affiche la quantité
                    textBox5.Text = selectedArticle.Promotion.ToString(); // affiche la remise
                    DelArticleName.Text = selectedArticle.Nom.ToString(); // affiche larticle a supprimer

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

        // Barre de Navigation File -> Exit
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        // Bouton modifier l'article
        private void button3_Click(object sender, EventArgs e)
        {
            groupBox4.Visible = true;
            ModifNom.Text = selectedArticle.Nom;
            ModifPrix.Text = selectedArticle.PrixUnitaire.ToString();
            ModifQuantite.Text = selectedArticle.Quantite.ToString();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(@"Application de gestion de stock pour ESIEE Paris", @"A propos", MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        //Bouton ajouter un article
        private void button6_Click(object sender, EventArgs e)
        {
            groupBox2.Visible = true;
        }

        // Bouton supprimer un article
        private void button7_Click(object sender, EventArgs e)
        {
            groupBox3.Visible = true;
        }

        private void Categories_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            try
            {
                // Vérifie si une catégorie est sélectionnée
                if (Categories.SelectedIndex >= 0)
                {
                    // Récupère la catégorie à partir de son index
                    Categorie selectedCategoryByIndex = categories[Categories.SelectedIndex];

                    if (selectedCategoryByIndex != null)
                    {
                        // Filtrer les articles pour afficher uniquement ceux qui ont le même IdCategorie que la catégorie sélectionnée
                        var filteredArticles = articleController.GetAllArticlesEstActive()
                            .Where(article => article.IdCategorie == selectedCategoryByIndex.IdCategorie)
                            .ToList();

                        // Mettre à jour la liste sous-jacente et la ListBox des articles
                        articles = filteredArticles; // Mettez à jour la liste sous-jacente
                        Articles.Items.Clear();
                        foreach (var article in articles)
                        {
                            Articles.Items.Add(article.Nom); // Ajoute uniquement le nom de l'article
                        }

                        // Effacer la sélection actuelle dans la ListBox
                        Articles.ClearSelected();
                        // Réinitialiser les champs d'affichage des détails d'article
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
                        // Si la catégorie n'est pas trouvée, afficher un message ou réinitialiser la liste des articles
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

        private void button2_Click_1(object sender, EventArgs e)
        {
            groupBox2.Visible = false;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            groupBox3.Visible = false;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            groupBox4.Visible = false;
        }

        private void Annuler_Click(object sender, EventArgs e)
        {
            groupBox2.Visible = false;
        }

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

                // Récupération des données modifiées depuis l'interface utilisateur
                var data = new Dictionary<string, object>();

                if (!string.IsNullOrWhiteSpace(ModifNom.Text))
                    data["Nom"] = ModifNom.Text;


                if (decimal.TryParse(ModifPrix.Text, out decimal prixUnitaire))
                    data["PrixUnitaire"] = prixUnitaire;

                if (int.TryParse(ModifQuantite.Text, out int quantite))
                    data["Quantite"] = quantite;

                // Vérification si des données ont été fournies pour la mise à jour
                if (data.Count == 0)
                {
                    MessageBox.Show("Aucune modification détectée.", "Information", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    return;
                }

                // Mise à jour de l'article via le contrôleur
                articleController.UpdateArticle(selectedArticle, data);

                // Confirmation de la mise à jour
                MessageBox.Show("L'article a été mis à jour avec succès !", "Succès", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                // Rechargez les articles pour mettre à jour l'interface
                LoadArticle();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors de la mise à jour de l'article : {ex.Message}", "Erreur",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AnnulerSuppr_Click(object sender, EventArgs e)
        {
            groupBox3.Visible = false;
        }

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

        private void ModifAnnuler_Click(object sender, EventArgs e)
        {
            groupBox4.Visible = false;
        }

        private void Valider_Click(object sender, EventArgs e)
        {
            groupBox2.Visible = false;
            try
            {
                // Récupération des données entrées par l'utilisateur
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


                // Vérification et récupération de la catégorie sélectionnée
                if (CategorieSelect.SelectedIndex < 0)
                {
                    MessageBox.Show("Veuillez sélectionner une catégorie.", "Erreur", MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return;
                }

                var selectedCategory = categories[CategorieSelect.SelectedIndex];
                int idCategorie = selectedCategory.IdCategorie;

                // Appel au contrôleur pour ajouter l'article
                articleController.AjouterArticle(
                    idCategorie: idCategorie,
                    nom: nom,
                    prixUnitaire: prixUnitaire,
                    quantite: quantite
                );

                MessageBox.Show("L'article a été ajouté avec succès !", "Succès", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                // Rechargez les articles pour mettre à jour l'interface
                LoadArticle();
                groupBox2.Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors de l'ajout de l'article : {ex.Message}", "Erreur", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void jSONToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Title = @"Exporter les données vers un fichier JSON";
            saveFileDialog.Filter = @"Fichiers JSON (*.json)|*.json";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string fileName = saveFileDialog.FileName;

                // Si le fichier n'est pas un fichier JSON, afficher un message d'erreur et quitter
                if (!fileName.EndsWith(".json"))
                {
                    MessageBox.Show(
                        @"Le fichier spécifié n'est pas un fichier JSON. Veuillez choisir un fichier JSON.",
                        @"Erreur",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Importer les données depuis le fichier JSON
                OperationResult result = jsonEditorController.CreerJson(fileName);

                // Afficher le résultat de l'opération
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

        private void jSONToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = @"Importer les données depuis un fichier JSON";
            openFileDialog.Filter = @"Fichiers JSON (*.json)|*.json";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string fileName = openFileDialog.FileName;

                // Si le fichier n'est pas un fichier JSON, afficher un message d'erreur et quitter
                if (!fileName.EndsWith(".json"))
                {
                    MessageBox.Show(
                        @"Le fichier spécifié n'est pas un fichier JSON. Veuillez choisir un fichier JSON.",
                        @"Erreur",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Importer les données depuis le fichier JSON
                OperationResult result = jsonEditorController.MettreAJourBaseDeDonnees(fileName);

                // Afficher le résultat de l'opération
                if (result.Success)
                {
                    MessageBox.Show(result.Message, @"Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Rechargez les articles pour mettre à jour l'interface
                    ChargerCategories();
                    LoadArticle();
                }
                else
                {
                    MessageBox.Show(result.Message, @"Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void exitToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void TypePromotionBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            label1.Text = TypePromoExtensions.from_string((string)TypePromotionBox.SelectedItem).get_symbol();
        }
    }
}