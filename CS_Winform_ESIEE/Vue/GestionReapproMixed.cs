using CS_Winform_ESIEE.Business;
using CS_Winform_ESIEE.Modele;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Button = System.Windows.Forms.Button;

namespace CS_Winform_ESIEE.Vue
{
    /// <summary>
    /// Classe de formulaire pour la gestion des stocks et des commandes dans l'application.
    /// </summary>
    public partial class GestionReapproMixed : Form
    {
        /// <summary>
        /// Contrôleur pour les opérations JSON.
        /// </summary>
        private JsonEditorController jsonEditorController = new JsonEditorController();

        /// <summary>
        /// Contrôleur pour la gestion des commandes.
        /// </summary>
        private CommandeController CommandeController = new CommandeController();

        /// <summary>
        /// Contrôleur pour la gestion des lignes de commande.
        /// </summary>
        private LigneCommandeController LigneCommandeController = new LigneCommandeController();

        /// <summary>
        /// Contrôleur pour la gestion des articles.
        /// </summary>
        private ArticleController articleController;

        /// <summary>
        /// Contrôleur pour la gestion des catégories.
        /// </summary>
        private CategorieController categorieController;

        /// <summary>
        /// Contrôleur pour la gestion du panier.
        /// </summary>
        private PanierController panierController;

        /// <summary>
        /// Liste des articles.
        /// </summary>
        private List<Article> articles;

        /// <summary>
        /// Liste des catégories.
        /// </summary>
        private List<Categorie> categories;

        /// <summary>
        /// Instance du panier.
        /// </summary>
        private Panier panier = new Panier();

        /// <summary>
        /// Initialise une nouvelle instance de la classe <see cref="GestionReapproMixed"/>.
        /// </summary>
        public GestionReapproMixed()
        {
            InitializeComponent();
            articleController = new ArticleController();
            categorieController = new CategorieController();
            panierController = new PanierController();
        }

        /// <summary>
        /// Charge les catégories dans la ListBox.
        /// </summary>
        private void ChargerCategories()
        {
            try
            {
                // Récupérer toutes les catégories
                categories = categorieController.GetAllCategories();

                // Charger les noms des catégories dans la ListBox
                Categories.Items.Clear();
                foreach (var categorie in categories)
                {
                    Categories.Items.Add(categorie.Nom); // Ajoute uniquement les noms
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors du chargement des catégories : {ex.Message}", "Erreur",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Met à jour l'affichage du panier.
        /// </summary>
        private void UpdatePanier()
        {
            PanierList.Items.Clear();
            PanierList.Columns.Clear();

            PanierList.Columns.Add("Nom", 100);
            PanierList.Columns.Add("Prix", 55);
            PanierList.Columns.Add("Quantité", 60);
            if (!checkBox1.Checked)
                PanierList.Columns.Add("Promotion", 65);

            foreach (Article article in panier.GetArticles())
            {
                ListViewItem item = new ListViewItem(article.Nom);
                item.Tag = article.IdArticle;
                if (checkBox1.Checked)
                    item.SubItems.Add(article.PrixTotal.ToString());
                else
                    item.SubItems.Add(article.PrixUnitaire.ToString());
                item.SubItems.Add(article.Quantite.ToString());
                if (!checkBox1.Checked)
                    item.SubItems.Add(article.Promotion.ToString() +
                                      TypePromoExtensions.from_string(article.TypePromotion).get_symbol());
                PanierList.Items.Add(item);
            }

            textBox2.Text = panier.GetTotal().ToString();

            button5.Enabled = panier.GetArticles().Count != 0;
        }

        /// <summary>
        /// Met à jour la liste des commandes.
        /// </summary>
        private void UpdateCommandesList()
        {
            List<Commande> commandes = CommandeController.GetAllCommandes();

            ListCommande.Items.Clear();

            foreach (Commande commande in commandes)
            {
                ListCommande.Items.Add("#" + commande.IdCommande.ToString());
            }

            ArticlesCommande.Enabled = false;
            TotalCommande.Enabled = false;
            EtatCommandeSelect.Enabled = false;
            validerEtat.Enabled = false;
        }

        /// <summary>
        /// Met à jour l'affichage d'une commande spécifique.
        /// </summary>
        /// <param name="commandeId">L'ID de la commande à afficher.</param>
        private void UpdateCommandePrint(int commandeId)
        {
            List<LigneCommande> lignesCommandes = LigneCommandeController.GetLigneCommandesByCommandeId(commandeId);

            ArticlesCommande.Items.Clear();
            ArticlesCommande.Columns.Clear();

            ArticlesCommande.Columns.Add("Nom", 100);
            ArticlesCommande.Columns.Add("Prix Unitaire", 55);
            ArticlesCommande.Columns.Add("Quantité", 60);
            ArticlesCommande.Columns.Add("Promotion", 65);
            ArticlesCommande.Columns.Add("Total", 65);

            foreach (LigneCommande ligneCommande in lignesCommandes)
            {
                Article article = articleController.GetArticleById(ligneCommande.IdArticle);
                ListViewItem item = new ListViewItem(article.Nom);
                item.Tag = article.IdArticle;
                item.SubItems.Add(ligneCommande.PrixUnitaire.ToString());
                item.SubItems.Add(ligneCommande.Quantite.ToString());
                item.SubItems.Add(ligneCommande.Promotion.ToString() +
                                  TypePromoExtensions.from_string(ligneCommande.TypePromotion).get_symbol());
                item.SubItems.Add(ligneCommande.PrixTotal.ToString());
                ArticlesCommande.Items.Add(item);
            }

            TotalCommande.Text = lignesCommandes.Sum(lc => lc.PrixTotal).ToString();

            Commande commande = CommandeController.GetCommandeById(commandeId);

            EtatCommandeSelect.Items.Clear();
            EtatCommandeSelect.Items.Add(EtatCommande.Commande.to_string());
            EtatCommandeSelect.Items.Add(EtatCommande.Envoyee.to_string());
            EtatCommandeSelect.Items.Add(EtatCommande.Livree.to_string());
            EtatCommandeSelect.Items.Add(EtatCommande.Annulee.to_string());
            EtatCommandeSelect.SelectedItem = EtatCommandeExtensions.from_string(commande.Etat).to_string();
            EtatCommandeSelect.Tag = commande.IdCommande;

            ArticlesCommande.Enabled = true;
            validerEtat.Enabled = false;

            EtatCommandeSelect.Enabled = commande.Etat != EtatCommande.Livree.to_string() && commande.Etat != EtatCommande.Annulee.to_string();
        }

        /// <summary>
        /// Extrait l'ID de la commande à partir de l'élément sélectionné dans la liste des commandes.
        /// </summary>
        /// <param name="commandeId">La chaîne de caractères de l'élément sélectionné.</param>
        /// <returns>L'ID de la commande extrait.</returns>
        private int GetCommandeIdWithCommandeListItem(string commandeId)
        {
            return int.Parse(commandeId.Substring(1));
        }

        /// <summary>
        /// Gestionnaire d'événements pour le bouton de gestion des stocks.
        /// </summary>
        /// <param name="sender">La source de l'événement.</param>
        /// <param name="e">Un EventArgs qui contient les données de l'événement.</param>
        private void button3_Click(object sender, EventArgs e)
        {
            ViewController.gestionstock.Location = ViewController.gestionreappromixed.Location;
            ViewController.gestionstock.StartPosition = FormStartPosition.Manual;
            ViewController.gestionstock.FormClosing += delegate
            {
                try
                {
                    if (ViewController.gestionreappromixed.Enabled) ViewController.gestionreappromixed.Show();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("sécurisé pour éviter le crash");
                }
            };
            if (ViewController.gestionstock.Enabled) ViewController.gestionstock.Show();
            if (ViewController.gestionreappromixed.Enabled) ViewController.gestionreappromixed.Hide();
        }

        /// <summary>
        /// Gestionnaire d'événements pour le bouton de gestion des commandes.
        /// </summary>
        /// <param name="sender">La source de l'événement.</param>
        /// <param name="e">Un EventArgs qui contient les données de l'événement.</param>
        private void button2_Click(object sender, EventArgs e)
        {
            groupBox3.Visible = true;
        }

        /// <summary>
        /// Gestionnaire d'événements pour le bouton de suppression d'un article du panier.
        /// </summary>
        /// <param name="sender">La source de l'événement.</param>
        /// <param name="e">Un EventArgs qui contient les données de l'événement.</param>
        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                // Vérifie si une catégorie est sélectionnée
                if (Categories.SelectedIndex >= 0)
                {
                    // Récupère le nom de la catégorie sélectionnée
                    string selectedCategoryName = Categories.SelectedItem.ToString();

                    // Trouve l'ID de la catégorie sélectionnée
                    Categorie selectedCategory = categories.FirstOrDefault(c => c.Nom == selectedCategoryName);

                    if (selectedCategory != null)
                    {
                        // Filtrer les articles pour afficher uniquement ceux qui ont le même IdCategorie que la catégorie sélectionnée
                        List<Article> filteredArticles = articles
                            .Where(article => article.IdCategorie == selectedCategory.IdCategorie).ToList();

                        // Mettre à jour la ListBox des articles
                        Articles.Items.Clear();
                        foreach (var article in filteredArticles)
                        {
                            Articles.Items.Add(article.Nom); // Ajoute uniquement le nom de l'article
                            Console.WriteLine("filtered" + filteredArticles);
                        }
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

        /// <summary>
        /// Gestionnaire d'événements pour le bouton de suppression d'un article du panier.
        /// </summary>
        /// <param name="sender">La source de l'événement.</param>
        /// <param name="e">Un EventArgs qui contient les données de l'événement.</param>
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (label10.Visible == false)
                label10.Visible = true;
            if (label11.Visible == false)
                label11.Visible = true;
            if (label12.Visible == false)
                label12.Visible = true;
            if (label13.Visible == false)
                label13.Visible = true;
            if (Articles.SelectedIndex >= 0) // Vérifie qu'un élément est sélectionné
            {
                try
                {
                    // Récupérer l'article correspondant
                    Article selectedArticle = articles[Articles.SelectedIndex];

                    // Afficher les informations dans les champs texte
                    label10.Text = selectedArticle.Nom; // Affiche le nom
                    label11.Text = selectedArticle.PrixUnitaire.ToString(); // Affiche le nom
                    label12.Text = selectedArticle.Quantite.ToString(); // Affiche la quantité
                    label13.Text = selectedArticle.Promotion.ToString(); // affiche la remise
                    label15.Text = TypePromoExtensions.from_string(selectedArticle.TypePromotion).get_symbol();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erreur lors de la sélection de l'article : {ex.Message}", "Erreur",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// Gestionnaire d'événements pour le bouton de suppression d'un article du panier.
        /// </summary>
        /// <param name="sender">La source de l'événement.</param>
        /// <param name="e">Un EventArgs qui contient les données de l'événement.</param>
        private void button1_Click(object sender, EventArgs e)
        {
            if (Articles.SelectedIndex < 0)
            {
                MessageBox.Show("Veuillez sélectionner un article.", "Erreur", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            int quantite = 1;
            if (textBox1.Text != "")
                quantite = int.Parse(textBox1.Text);
            else
                textBox1.Text = @"1";

            if (quantite <= 0)
            {
                textBox1.Text = @"1";
                MessageBox.Show("La quantité doit être supérieure à 0.", "Erreur", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            Article newArticle = new Article
            {
                IdArticle = articles[Articles.SelectedIndex].IdArticle,
                IdCategorie = articles[Articles.SelectedIndex].IdCategorie,
                Nom = articles[Articles.SelectedIndex].Nom,
                PrixUnitaire = articles[Articles.SelectedIndex].PrixUnitaire,
                Quantite = quantite,
                Promotion = articles[Articles.SelectedIndex].Promotion,
                EstActif = articles[Articles.SelectedIndex].EstActif,
                TypePromotion = articles[Articles.SelectedIndex].TypePromotion
            };

            panier.AjouterArticle(newArticle);

            UpdatePanier();
        }

        /// <summary>
        /// Gestionnaire d'événements pour le bouton de suppression d'un article du panier.
        /// </summary>
        /// <param name="sender">La source de l'événement.</param>
        /// <param name="e">Un EventArgs qui contient les données de l'événement.</param>
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(@"Application de gestion de stock pour ESIEE Paris", @"A propos", MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        /// <summary>
        /// Gestionnaire d'événements pour le bouton de suppression d'un article du panier.
        /// </summary>
        /// <param name="sender">La source de l'événement.</param>
        /// <param name="e">Un EventArgs qui contient les données de l'événement.</param>
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(@"Application de gestion de stock pour ESIEE Paris", @"A propos", MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        /// <summary>
        /// Gestionnaire d'événements pour le bouton de suppression d'un article du panier.
        /// </summary>
        /// <param name="sender">La source de l'événement.</param>
        /// <param name="e">Un EventArgs qui contient les données de l'événement.</param>
        private void button6_Click(object sender, EventArgs e)
        {
            groupBox3.Visible = false;
        }

        /// <summary>
        /// Gestionnaire d'événements pour le bouton de suppression d'un article du panier.
        /// </summary>
        /// <param name="sender">La source de l'événement.</param>
        /// <param name="e">Un EventArgs qui contient les données de l'événement.</param>
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            UpdatePanier();
            label4.Visible = !checkBox1.Checked;
            label3.Visible = checkBox1.Checked;
        }

        /// <summary>
        /// Gestionnaire d'événements pour le bouton de suppression d'un article du panier.
        /// </summary>
        /// <param name="sender">La source de l'événement.</param>
        /// <param name="e">Un EventArgs qui contient les données de l'événement.</param>
        private void button5_Click(object sender, EventArgs e)
        {
            groupBox3.Visible = false;
            panierController.Commander(panier);
            panier.Vider();
            UpdatePanier();
        }

        /// <summary>
        /// Gestionnaire d'événements pour le bouton de suppression d'un article du panier.
        /// </summary>
        /// <param name="sender">La source de l'événement.</param>
        /// <param name="e">Un EventArgs qui contient les données de l'événement.</param>
        private void button4_Click(object sender, EventArgs e)
        {
            groupBox2.Visible = false;
        }

        /// <summary>
        /// Gestionnaire d'événements pour le bouton de suppression d'un article du panier.
        /// </summary>
        /// <param name="sender">La source de l'événement.</param>
        /// <param name="e">Un EventArgs qui contient les données de l'événement.</param>
        private void ListCommande_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ListCommande.SelectedIndex >= 0) // Vérifie qu'un élément est sélectionné
            {
                string selectedItem = ListCommande.SelectedItem.ToString();
                int commandeId = GetCommandeIdWithCommandeListItem(selectedItem);

                UpdateCommandePrint(commandeId);
            }
        }

        /// <summary>
        /// Gestionnaire d'événements pour le chargement du formulaire.
        /// </summary>
        /// <param name="sender">La source de l'événement.</param>
        /// <param name="e">Un EventArgs qui contient les données de l'événement.</param>
        private void GestionReapproMixed_Load(object sender, EventArgs e)
        {
            UpdatePanier();
            UpdateCommandesList();
            ChargerCategories();
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
                MessageBox.Show($"Erreur lors du chargement des articles : {ex.Message}", "Erreur",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            PanierList.MouseDoubleClick += new MouseEventHandler(PanierList_MouseDoubleClick);
            label4.Visible = !checkBox1.Checked;
            label3.Visible = checkBox1.Checked;
        }

        /// <summary>
        /// Gestionnaire d'événements pour le bouton de suppression d'un article du panier.
        /// </summary>
        /// <param name="sender">La source de l'événement.</param>
        /// <param name="e">Un EventArgs qui contient les données de l'événement.</param>
        private void button7_Click(object sender, EventArgs e)
        {
            UpdateCommandesList();
            groupBox2.Visible = true;
        }

        /// <summary>
        /// Gestionnaire d'événements pour le bouton de suppression d'un article du panier.
        /// </summary>
        /// <param name="sender">La source de l'événement.</param>
        /// <param name="e">Un EventArgs qui contient les données de l'événement.</param>
        private void button10_Click(object sender, EventArgs e)
        {
            GestionQuantite.Visible = false;
        }

        /// <summary>
        /// Gestionnaire d'événements pour le bouton de suppression d'un article du panier.
        /// </summary>
        /// <param name="sender">La source de l'événement.</param>
        /// <param name="e">Un EventArgs qui contient les données de l'événement.</param>
        private void button9_Click(object sender, EventArgs e)
        {
            int articleId = (int)Quantites.Tag;
            int newQuantite = int.Parse(Quantites.Text);
            panier.RedefineNbExemplaireArticleById(articleId, newQuantite);
            UpdatePanier();
            GestionQuantite.Visible = false;
        }

        /// <summary>
        /// Gestionnaire d'événements pour le bouton de suppression d'un article du panier.
        /// </summary>
        /// <param name="sender">La source de l'événement.</param>
        /// <param name="e">Un EventArgs qui contient les données de l'événement.</param>
        private void button11_Click(object sender, EventArgs e)
        {
            int articleId = (int)Quantites.Tag;
            int newQuantite = -1;
            panier.RedefineNbExemplaireArticleById(articleId, newQuantite);
            UpdatePanier();
            GestionQuantite.Visible = false;
        }

        /// <summary>
        /// Gestionnaire d'événements pour le bouton de suppression d'un article du panier.
        /// </summary>
        /// <param name="sender">La source de l'événement.</param>
        /// <param name="e">Un EventArgs qui contient les données de l'événement.</param>
        private void BoutonExit(object sender, EventArgs e)
        {
            GestionQuantite.Visible = false;
        }

        /// <summary>
        /// Gestionnaire d'événements pour le double-clic sur un élément de la liste des articles du panier.
        /// </summary>
        /// <param name="sender">La source de l'événement.</param>
        /// <param name="e">Un MouseEventArgs qui contient les données de l'événement.</param>
        private void PanierList_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (PanierList.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = PanierList.SelectedItems[0];
                int articleId = (int)selectedItem.Tag;
                string articleName = selectedItem.Text;
                int quantite = int.Parse(selectedItem.SubItems[2].Text);

                // une messagebox pour demander la quantité

                GestionQuantite.Visible = true;
                NomArticleSuppr.Text = @"Changer la quantité de " + articleName + @" :";
                Quantites.Text = quantite.ToString();
                Quantites.Tag = articleId;
            }
        }

        /// <summary>
        /// Gestionnaire d'événements pour le bouton de suppression d'un article du panier.
        /// </summary>
        /// <param name="sender">La source de l'événement.</param>
        /// <param name="e">Un EventArgs qui contient les données de l'événement.</param>
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

        /// <summary>
        /// Gestionnaire d'événements pour le bouton de suppression d'un article du panier.
        /// </summary>
        /// <param name="sender">La source de l'événement.</param>
        /// <param name="e">Un FormClosingEventArgs qui contient les données de l'événement.</param>
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

                    // Mettre à jour les listes des articles et des catégories
                    ChargerCategories();
                    UpdatePanier();
                    UpdateCommandesList();
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
                        MessageBox.Show($"Erreur lors du chargement des articles : {ex.Message}", "Erreur",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show(result.Message, @"Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// Gestionnaire d'événements pour le bouton de suppression d'un article du panier.
        /// </summary>
        /// <param name="sender">La source de l'événement.</param>
        /// <param name="e">Un FormClosingEventArgs qui contient les données de l'événement.</param>
        private void validerEtat_Click(object sender, EventArgs e)
        {
            if (EtatCommandeSelect.Tag != null)
            {
                int commandeId = (int)EtatCommandeSelect.Tag;
                EtatCommande nouvelEtat =
                    EtatCommandeExtensions.from_string(EtatCommandeSelect.SelectedItem.ToString());

                // Mettre à jour l'état de la commande dans la base de données
                CommandeController.UpdateCommande(CommandeController.GetCommandeById(commandeId), nouvelEtat);

                // Actualiser l'affichage
                UpdateCommandesList();
                UpdateCommandePrint(commandeId);

                validerEtat.Enabled = false;

                if (nouvelEtat == EtatCommande.Livree || nouvelEtat == EtatCommande.Annulee)
                {
                    EtatCommandeSelect.Enabled = false;
                }
                else
                {
                    EtatCommandeSelect.Enabled = true;
                }
            }
        }

        /// <summary>
        /// Gestionnaire d'événements pour le changement de l'élément sélectionné dans la liste des états de commande.
        /// </summary>
        /// <param name="sender">La source de l'événement.</param>
        /// <param name="e">Un EventArgs qui contient les données de l'événement.</param>
        private void EtatCommandeSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (EtatCommandeSelect.Tag != null)
            {
                int commandeId = (int)EtatCommandeSelect.Tag;
                Commande commande = CommandeController.GetCommandeById(commandeId);

                if (commande != null && EtatCommandeSelect.SelectedItem.ToString() != commande.Etat)
                {
                    validerEtat.Enabled = true;
                }
                else
                {
                    validerEtat.Enabled = false;
                }
            }
        }
    }
}