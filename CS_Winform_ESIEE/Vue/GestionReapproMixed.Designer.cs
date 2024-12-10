using System.Windows.Forms;

namespace CS_Winform_ESIEE.Vue
{
    partial class GestionReapproMixed
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.Categories = new System.Windows.Forms.ListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.Articles = new System.Windows.Forms.ListBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.ListCommande = new System.Windows.Forms.ListBox();
            this.button4 = new System.Windows.Forms.Button();
            this.GestionQuantite = new System.Windows.Forms.GroupBox();
            this.supprPanier = new System.Windows.Forms.Button();
            this.NomArticleSuppr = new System.Windows.Forms.Label();
            this.AnnulerQuantite = new System.Windows.Forms.Button();
            this.ValiderQuantite = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.Quantites = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.PanierList = new System.Windows.Forms.ListView();
            this.button6 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.button5 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.ArticlesCommande = new System.Windows.Forms.ListView();
            this.label1 = new System.Windows.Forms.Label();
            this.TotalCommande = new System.Windows.Forms.TextBox();
            this.Devise = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.EtatCommande = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.GestionQuantite.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(712, 43);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(85, 45);
            this.button3.TabIndex = 23;
            this.button3.Text = "stock";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(624, 42);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(85, 45);
            this.button2.TabIndex = 22;
            this.button2.Text = "panier";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Categories
            // 
            this.Categories.FormattingEnabled = true;
            this.Categories.Location = new System.Drawing.Point(14, 38);
            this.Categories.Name = "Categories";
            this.Categories.Size = new System.Drawing.Size(604, 56);
            this.Categories.TabIndex = 21;
            this.Categories.SelectedIndexChanged += new System.EventHandler(this.listBox2_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Location = new System.Drawing.Point(545, 122);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(222, 318);
            this.groupBox1.TabIndex = 20;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(124, 148);
            this.label15.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(18, 15);
            this.label15.TabIndex = 12;
            this.label15.Text = "%";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(79, 89);
            this.label14.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(14, 15);
            this.label14.TabIndex = 11;
            this.label14.Text = "€";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(87, 148);
            this.label13.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(41, 13);
            this.label13.TabIndex = 10;
            this.label13.Text = "label13";
            this.label13.Visible = false;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(141, 90);
            this.label12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(41, 13);
            this.label12.TabIndex = 9;
            this.label12.Text = "label12";
            this.label12.Visible = false;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(39, 90);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(41, 13);
            this.label11.TabIndex = 8;
            this.label11.Text = "label11";
            this.label11.Visible = false;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(89, 48);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(41, 13);
            this.label10.TabIndex = 7;
            this.label10.Text = "label10";
            this.label10.Visible = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(86, 133);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(42, 13);
            this.label9.TabIndex = 6;
            this.label9.Text = "Remise";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(139, 74);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(52, 13);
            this.label8.TabIndex = 5;
            this.label8.Text = "Quantités";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(37, 74);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(24, 13);
            this.label7.TabIndex = 4;
            this.label7.Text = "Prix";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(86, 32);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 13);
            this.label6.TabIndex = 3;
            this.label6.Text = "Nom";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(154, 290);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(60, 20);
            this.textBox1.TabIndex = 2;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(158, 269);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "quantités";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(5, 273);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(115, 36);
            this.button1.TabIndex = 0;
            this.button1.Text = "ajouter";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Articles
            // 
            this.Articles.FormattingEnabled = true;
            this.Articles.Location = new System.Drawing.Point(15, 109);
            this.Articles.Name = "Articles";
            this.Articles.Size = new System.Drawing.Size(500, 329);
            this.Articles.TabIndex = 18;
            this.Articles.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 1, 0, 1);
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 17;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 22);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(93, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 22);
            this.editToolStripMenuItem.Text = "Edit";
            this.editToolStripMenuItem.Click += new System.EventHandler(this.editToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(52, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.SystemColors.ControlDark;
            this.groupBox2.Controls.Add(this.EtatCommande);
            this.groupBox2.Controls.Add(this.label16);
            this.groupBox2.Controls.Add(this.Devise);
            this.groupBox2.Controls.Add(this.TotalCommande);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.ArticlesCommande);
            this.groupBox2.Controls.Add(this.ListCommande);
            this.groupBox2.Controls.Add(this.button4);
            this.groupBox2.Location = new System.Drawing.Point(33, 32);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(725, 405);
            this.groupBox2.TabIndex = 25;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Commandes";
            this.groupBox2.Visible = false;
            this.groupBox2.Enter += new System.EventHandler(this.groupBox2_Enter);
            // 
            // ListCommande
            // 
            this.ListCommande.FormattingEnabled = true;
            this.ListCommande.Location = new System.Drawing.Point(16, 40);
            this.ListCommande.Name = "ListCommande";
            this.ListCommande.Size = new System.Drawing.Size(128, 342);
            this.ListCommande.TabIndex = 6;
            this.ListCommande.SelectedIndexChanged += new System.EventHandler(this.listBox3_SelectedIndexChanged);
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.Red;
            this.button4.Location = new System.Drawing.Point(702, 11);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(17, 23);
            this.button4.TabIndex = 5;
            this.button4.Text = "X";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // GestionQuantite
            // 
            this.GestionQuantite.Controls.Add(this.supprPanier);
            this.GestionQuantite.Controls.Add(this.NomArticleSuppr);
            this.GestionQuantite.Controls.Add(this.AnnulerQuantite);
            this.GestionQuantite.Controls.Add(this.ValiderQuantite);
            this.GestionQuantite.Controls.Add(this.button8);
            this.GestionQuantite.Controls.Add(this.Quantites);
            this.GestionQuantite.Location = new System.Drawing.Point(73, 123);
            this.GestionQuantite.Name = "GestionQuantite";
            this.GestionQuantite.Size = new System.Drawing.Size(245, 137);
            this.GestionQuantite.TabIndex = 7;
            this.GestionQuantite.TabStop = false;
            this.GestionQuantite.Text = "Quantites";
            this.GestionQuantite.Visible = false;
            this.GestionQuantite.Enter += new System.EventHandler(this.groupBox4_Enter);
            // 
            // supprPanier
            // 
            this.supprPanier.Location = new System.Drawing.Point(118, 38);
            this.supprPanier.Name = "supprPanier";
            this.supprPanier.Size = new System.Drawing.Size(75, 23);
            this.supprPanier.TabIndex = 9;
            this.supprPanier.Text = "Supprimer";
            this.supprPanier.UseVisualStyleBackColor = true;
            this.supprPanier.Click += new System.EventHandler(this.button11_Click);
            // 
            // NomArticleSuppr
            // 
            this.NomArticleSuppr.AutoSize = true;
            this.NomArticleSuppr.Location = new System.Drawing.Point(28, 16);
            this.NomArticleSuppr.Name = "NomArticleSuppr";
            this.NomArticleSuppr.Size = new System.Drawing.Size(35, 13);
            this.NomArticleSuppr.TabIndex = 8;
            this.NomArticleSuppr.Text = "label1";
            this.NomArticleSuppr.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.NomArticleSuppr.Click += new System.EventHandler(this.label1_Click);
            // 
            // AnnulerQuantite
            // 
            this.AnnulerQuantite.Location = new System.Drawing.Point(161, 92);
            this.AnnulerQuantite.Name = "AnnulerQuantite";
            this.AnnulerQuantite.Size = new System.Drawing.Size(58, 28);
            this.AnnulerQuantite.TabIndex = 7;
            this.AnnulerQuantite.Text = "Annuler";
            this.AnnulerQuantite.UseVisualStyleBackColor = true;
            this.AnnulerQuantite.Click += new System.EventHandler(this.button10_Click);
            // 
            // ValiderQuantite
            // 
            this.ValiderQuantite.Location = new System.Drawing.Point(25, 92);
            this.ValiderQuantite.Name = "ValiderQuantite";
            this.ValiderQuantite.Size = new System.Drawing.Size(62, 28);
            this.ValiderQuantite.TabIndex = 6;
            this.ValiderQuantite.Text = "Valider";
            this.ValiderQuantite.UseVisualStyleBackColor = true;
            this.ValiderQuantite.Click += new System.EventHandler(this.button9_Click);
            // 
            // button8
            // 
            this.button8.BackColor = System.Drawing.Color.Red;
            this.button8.Location = new System.Drawing.Point(211, 6);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(17, 23);
            this.button8.TabIndex = 5;
            this.button8.Text = "X";
            this.button8.UseVisualStyleBackColor = false;
            this.button8.Click += new System.EventHandler(this.BoutonExit);
            // 
            // Quantites
            // 
            this.Quantites.Location = new System.Drawing.Point(58, 41);
            this.Quantites.Name = "Quantites";
            this.Quantites.Size = new System.Drawing.Size(54, 20);
            this.Quantites.TabIndex = 1;
            this.Quantites.TextChanged += new System.EventHandler(this.textBox4_TextChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.SystemColors.ControlDark;
            this.groupBox3.Controls.Add(this.GestionQuantite);
            this.groupBox3.Controls.Add(this.PanierList);
            this.groupBox3.Controls.Add(this.button6);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.checkBox1);
            this.groupBox3.Controls.Add(this.textBox2);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.button5);
            this.groupBox3.Location = new System.Drawing.Point(420, 0);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(380, 445);
            this.groupBox3.TabIndex = 26;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Panier";
            this.groupBox3.Visible = false;
            // 
            // PanierList
            // 
            this.PanierList.FullRowSelect = true;
            this.PanierList.HideSelection = false;
            this.PanierList.Location = new System.Drawing.Point(19, 72);
            this.PanierList.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.PanierList.Name = "PanierList";
            this.PanierList.Size = new System.Drawing.Size(350, 319);
            this.PanierList.TabIndex = 0;
            this.PanierList.UseCompatibleStateImageBehavior = false;
            this.PanierList.View = System.Windows.Forms.View.Details;
            // 
            // button6
            // 
            this.button6.BackColor = System.Drawing.Color.Red;
            this.button6.Location = new System.Drawing.Point(352, 12);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(17, 23);
            this.button6.TabIndex = 4;
            this.button6.Text = "X";
            this.button6.UseVisualStyleBackColor = false;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(217, 44);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "prix/Unité";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(131, 45);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "prix/quantité";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(203, 44);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(15, 14);
            this.checkBox1.TabIndex = 1;
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(21, 407);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(98, 20);
            this.textBox2.TabIndex = 7;
            this.textBox2.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(121, 411);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(13, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "€";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(165, 404);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(115, 32);
            this.button5.TabIndex = 5;
            this.button5.Text = "Valider";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(558, 98);
            this.button7.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(189, 20);
            this.button7.TabIndex = 26;
            this.button7.Text = "commandes en cours";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // ArticlesCommande
            // 
            this.ArticlesCommande.HideSelection = false;
            this.ArticlesCommande.Location = new System.Drawing.Point(180, 40);
            this.ArticlesCommande.Name = "ArticlesCommande";
            this.ArticlesCommande.Size = new System.Drawing.Size(499, 302);
            this.ArticlesCommande.TabIndex = 7;
            this.ArticlesCommande.UseCompatibleStateImageBehavior = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(180, 359);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Total :";
            // 
            // TotalCommande
            // 
            this.TotalCommande.Location = new System.Drawing.Point(223, 356);
            this.TotalCommande.Name = "TotalCommande";
            this.TotalCommande.Size = new System.Drawing.Size(100, 20);
            this.TotalCommande.TabIndex = 9;
            // 
            // Devise
            // 
            this.Devise.AutoSize = true;
            this.Devise.Location = new System.Drawing.Point(329, 359);
            this.Devise.Name = "Devise";
            this.Devise.Size = new System.Drawing.Size(13, 13);
            this.Devise.TabIndex = 10;
            this.Devise.Text = "€";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(431, 359);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(116, 13);
            this.label16.TabIndex = 11;
            this.label16.Text = "Etat de la commande : ";
            // 
            // EtatCommande
            // 
            this.EtatCommande.FormattingEnabled = true;
            this.EtatCommande.Location = new System.Drawing.Point(545, 356);
            this.EtatCommande.Name = "EtatCommande";
            this.EtatCommande.Size = new System.Drawing.Size(121, 21);
            this.EtatCommande.TabIndex = 12;
            // 
            // GestionReapproMixed
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.Articles);
            this.Controls.Add(this.Categories);
            this.Controls.Add(this.button7);
            this.MaximizeBox = false;
            this.Name = "GestionReapproMixed";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "GestionReapproMixed";
            this.Load += new System.EventHandler(this.GestionReapproMixed_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.GestionQuantite.ResumeLayout(false);
            this.GestionQuantite.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ListBox Categories;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListBox Articles;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListBox ListCommande;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.ListView PanierList;
        private GroupBox GestionQuantite;
        private Button AnnulerQuantite;
        private Button ValiderQuantite;
        private Button button8;
        private TextBox Quantites;
        private Label NomArticleSuppr;
        private Button supprPanier;
        private ComboBox EtatCommande;
        private Label label16;
        private Label Devise;
        private TextBox TotalCommande;
        private Label label1;
        private ListView ArticlesCommande;
    }
}