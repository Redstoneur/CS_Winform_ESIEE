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

namespace CS_Winform_ESIEE.Vue
{
    public partial class Form2 : Form
    {
        private ArticleController articleController;
        private List<Article> articles; // Stocke les articles récupérés
        public Form2()
        {
            InitializeComponent();
            articleController = new ArticleController();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        /*
        * ritchtextbox de la liste des articles
        */
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex >= 0) // Vérifie qu'un élément est sélectionné
            {
                try
                {
                    // Récupérer l'article correspondant
                    Article selectedArticle = articles[listBox1.SelectedIndex];

                    // Afficher les informations dans les champs texte
                    textBox4.Text = selectedArticle.Nom; // Affiche le nom
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

        /*
         *richtextbox de la liste des différentes catégories 
        */
        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        /*
         * bouton d'accès au panier
         */
        private void button2_Click(object sender, EventArgs e)
        {

        }

        /*
         * bouton d'accès au stock
         */
        private void button3_Click(object sender, EventArgs e)
        {
            var frm = new GestionStock();
            frm.Location = this.Location;
            frm.StartPosition = FormStartPosition.Manual;
            frm.FormClosing += delegate { this.Show(); };
            frm.Show();
            this.Close();
        }

        /**
        * Boutton d'ajouter 
        */
        private void button1_Click(object sender, EventArgs e)
        {

        }

        /**
        * textbox pour la quantité 
        */
        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form2_Load_1(object sender, EventArgs e)
        {
            try
            {
                // Récupérer tous les articles
                articles = articleController.GetAllArticles();

                // Charger les noms des articles dans la ListBox
                listBox1.Items.Clear();
                foreach (var article in articles)
                {
                    listBox1.Items.Add(article.Nom); // Ajoute uniquement les noms
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors du chargement des articles : {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }
    }
}
