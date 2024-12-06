﻿using CS_Winform_ESIEE.Business;
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

namespace CS_Winform_ESIEE.Vue
{
    public partial class GestionReapproMixed : Form
    {

        private ArticleController articleController;
        private List<Article> articles; // Stocke les articles récupérés

        private CategorieController categorieController;
        private List<Categorie> categories;

        public GestionReapproMixed()
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

        private void Form5_Load(object sender, EventArgs e)
        {

        }

        //principal

        //bouton stock
        private void button3_Click(object sender, EventArgs e)
        {
            var frm = new GestionStock();
            frm.Location = this.Location;
            frm.StartPosition = FormStartPosition.Manual;
            frm.FormClosing += delegate { this.Show(); };
            frm.Show();
            this.Close();
        }

        //bouton panier
        private void button2_Click(object sender, EventArgs e)
        {
            groupBox3.Visible = true;
        }

        //listbox des categorie
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
                        List<Article> filteredArticles = articles.Where(article => article.IdCategorie == selectedCategory.IdCategorie).ToList();

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
                        MessageBox.Show("Catégorie non trouvée.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors de la sélection de la catégorie : {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //listbox des listes des articles
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            if(label10.Visible == false)
                label10.Visible = true;
            if(label11.Visible == false)
                label11.Visible = true;
            if(label12.Visible == false)
                label12.Visible = true;
            if(label13.Visible == false)
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
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erreur lors de la sélection de l'article : {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        //bouton ajouter
        private void button1_Click(object sender, EventArgs e)
        {

        }

        //textbox quantité
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        //bouton menu about
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        //bouton menu edit
        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        //bouton menu exit
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        //sous-interface panier

        //bouton annuler
        private void button6_Click(object sender, EventArgs e)
        {
            groupBox3.Visible = false;
        }

        //bouton on/off quantité/unité
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        //listbox 
        private void listBox4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        //textbox prix
        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        //bouton valider
        private void button5_Click(object sender, EventArgs e)
        {

        }

        //sous-interface liste commande

        //bouton annuler
        private void button4_Click(object sender, EventArgs e)
        {
            groupBox2.Visible = false;
        }

        //listbox liste de commandes
        private void listBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void GestionReapproMixed_Load(object sender, EventArgs e)
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

        private void groupBox2_Enter(object sender, EventArgs e)
        {
            
        }

        private void button7_Click(object sender, EventArgs e)
        {
            groupBox2.Visible = true;
        }
    }
}