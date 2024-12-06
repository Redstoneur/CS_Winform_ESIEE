namespace CS_Winform_ESIEE
{
    partial class GestionStock
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.Articles = new System.Windows.Forms.ListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.pageSetupDialog1 = new System.Windows.Forms.PageSetupDialog();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Categories = new System.Windows.Forms.ListBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.Annuler = new System.Windows.Forms.Button();
            this.CloseButton = new System.Windows.Forms.Button();
            this.Valider = new System.Windows.Forms.Button();
            this.CategorieSelect = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.AddQuantiteArticle = new System.Windows.Forms.TextBox();
            this.AddPrixArticle = new System.Windows.Forms.TextBox();
            this.AddNomArticle = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.button9 = new System.Windows.Forms.Button();
            this.DelArticleName = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.AnnulerSuppr = new System.Windows.Forms.Button();
            this.ConfirmerSuppr = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.ModifAnnuler = new System.Windows.Forms.Button();
            this.ValiderModif = new System.Windows.Forms.Button();
            this.Quantités = new System.Windows.Forms.Label();
            this.ReduceQuantite = new System.Windows.Forms.Button();
            this.AddQuantite = new System.Windows.Forms.Button();
            this.ModifQuantite = new System.Windows.Forms.TextBox();
            this.ModifPrix = new System.Windows.Forms.TextBox();
            this.ModifNom = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.button10 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // Articles
            // 
            this.Articles.AccessibleName = "articlesBox";
            this.Articles.FormattingEnabled = true;
            this.Articles.ItemHeight = 20;
            this.Articles.Location = new System.Drawing.Point(38, 140);
            this.Articles.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Articles.Name = "Articles";
            this.Articles.Size = new System.Drawing.Size(631, 384);
            this.Articles.TabIndex = 0;
            this.Articles.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.textBox5);
            this.groupBox1.Controls.Add(this.button4);
            this.groupBox1.Controls.Add(this.button3);
            this.groupBox1.Controls.Add(this.textBox3);
            this.groupBox1.Controls.Add(this.textBox2);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Location = new System.Drawing.Point(740, 202);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Size = new System.Drawing.Size(368, 374);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Details article";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(135, 222);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(70, 22);
            this.label7.TabIndex = 13;
            this.label7.Text = "Remise";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(135, 160);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(26, 29);
            this.label6.TabIndex = 12;
            this.label6.Text = "€";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(195, 131);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(87, 22);
            this.label5.TabIndex = 11;
            this.label5.Text = "Quantités";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(68, 131);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 22);
            this.label4.TabIndex = 10;
            this.label4.Text = "Prix";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(58, 92);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 22);
            this.label3.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(58, 35);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 22);
            this.label2.TabIndex = 8;
            this.label2.Text = "Article";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(128, 262);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 29);
            this.label1.TabIndex = 7;
            this.label1.Text = "%";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(70, 260);
            this.textBox5.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(46, 26);
            this.textBox5.TabIndex = 6;
            this.textBox5.TextChanged += new System.EventHandler(this.textBox5_TextChanged);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(174, 260);
            this.button4.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(112, 35);
            this.button4.TabIndex = 5;
            this.button4.Text = "Appliquer";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(117, 305);
            this.button3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(112, 35);
            this.button3.TabIndex = 4;
            this.button3.Text = "Modifier";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // textBox3
            // 
            this.textBox3.Enabled = false;
            this.textBox3.Location = new System.Drawing.Point(51, 158);
            this.textBox3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(79, 26);
            this.textBox3.TabIndex = 2;
            this.textBox3.TextChanged += new System.EventHandler(this.textBox3_TextChanged);
            // 
            // textBox2
            // 
            this.textBox2.Enabled = false;
            this.textBox2.Location = new System.Drawing.Point(189, 158);
            this.textBox2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 26);
            this.textBox2.TabIndex = 1;
            this.textBox2.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // textBox1
            // 
            this.textBox1.Enabled = false;
            this.textBox1.Location = new System.Drawing.Point(48, 68);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(262, 26);
            this.textBox1.TabIndex = 0;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1048, 51);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(134, 69);
            this.button1.TabIndex = 3;
            this.button1.Text = "Réapprovision-nement";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(788, 140);
            this.button5.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(264, 35);
            this.button5.TabIndex = 5;
            this.button5.Text = "Historique de stock";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(38, 551);
            this.button6.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(57, 35);
            this.button6.TabIndex = 6;
            this.button6.Text = "+";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(104, 551);
            this.button7.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(57, 35);
            this.button7.TabIndex = 7;
            this.button7.Text = "-";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Text = "notifyIcon1";
            this.notifyIcon1.Visible = true;
            // 
            // menuStrip1
            // 
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(6, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1200, 33);
            this.menuStrip1.TabIndex = 8;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(54, 29);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(141, 34);
            this.exitToolStripMenuItem.Text = "Exit";
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(58, 29);
            this.editToolStripMenuItem.Text = "Edit";
            this.editToolStripMenuItem.Click += new System.EventHandler(this.editToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(78, 29);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // Categories
            // 
            this.Categories.ItemHeight = 20;
            this.Categories.Location = new System.Drawing.Point(38, 42);
            this.Categories.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Categories.Name = "Categories";
            this.Categories.Size = new System.Drawing.Size(984, 84);
            this.Categories.TabIndex = 9;
            this.Categories.Click += new System.EventHandler(this.Categories_SelectedIndexChanged_1);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.Annuler);
            this.groupBox2.Controls.Add(this.CloseButton);
            this.groupBox2.Controls.Add(this.Valider);
            this.groupBox2.Controls.Add(this.CategorieSelect);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.AddQuantiteArticle);
            this.groupBox2.Controls.Add(this.AddPrixArticle);
            this.groupBox2.Controls.Add(this.AddNomArticle);
            this.groupBox2.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.groupBox2.Location = new System.Drawing.Point(262, 125);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Size = new System.Drawing.Size(683, 352);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Ajouter";
            this.groupBox2.Visible = false;
            this.groupBox2.Enter += new System.EventHandler(this.groupBox2_Enter);
            // 
            // Annuler
            // 
            this.Annuler.Location = new System.Drawing.Point(408, 268);
            this.Annuler.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Annuler.Name = "Annuler";
            this.Annuler.Size = new System.Drawing.Size(100, 32);
            this.Annuler.TabIndex = 10;
            this.Annuler.Text = "Annuler";
            this.Annuler.UseVisualStyleBackColor = true;
            this.Annuler.Click += new System.EventHandler(this.Annuler_Click);
            // 
            // CloseButton
            // 
            this.CloseButton.BackColor = System.Drawing.Color.Red;
            this.CloseButton.Location = new System.Drawing.Point(650, 11);
            this.CloseButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(26, 35);
            this.CloseButton.TabIndex = 9;
            this.CloseButton.Text = "X";
            this.CloseButton.UseVisualStyleBackColor = false;
            this.CloseButton.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // Valider
            // 
            this.Valider.Location = new System.Drawing.Point(189, 268);
            this.Valider.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Valider.Name = "Valider";
            this.Valider.Size = new System.Drawing.Size(108, 32);
            this.Valider.TabIndex = 8;
            this.Valider.Text = "Valider";
            this.Valider.UseVisualStyleBackColor = true;
            this.Valider.Click += new System.EventHandler(this.Valider_Click);
            // 
            // CategorieSelect
            // 
            this.CategorieSelect.FormattingEnabled = true;
            this.CategorieSelect.Location = new System.Drawing.Point(408, 142);
            this.CategorieSelect.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.CategorieSelect.Name = "CategorieSelect";
            this.CategorieSelect.Size = new System.Drawing.Size(180, 28);
            this.CategorieSelect.TabIndex = 7;
            this.CategorieSelect.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(324, 146);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(86, 20);
            this.label11.TabIndex = 6;
            this.label11.Text = "Catégorie :";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(316, 78);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(86, 20);
            this.label10.TabIndex = 5;
            this.label10.Text = "Quantités :";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(64, 145);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(42, 20);
            this.label9.TabIndex = 4;
            this.label9.Text = "Prix :";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(56, 80);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(50, 20);
            this.label8.TabIndex = 3;
            this.label8.Text = "Nom :";
            // 
            // AddQuantiteArticle
            // 
            this.AddQuantiteArticle.Location = new System.Drawing.Point(408, 74);
            this.AddQuantiteArticle.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.AddQuantiteArticle.Name = "AddQuantiteArticle";
            this.AddQuantiteArticle.Size = new System.Drawing.Size(180, 26);
            this.AddQuantiteArticle.TabIndex = 2;
            // 
            // AddPrixArticle
            // 
            this.AddPrixArticle.Location = new System.Drawing.Point(112, 145);
            this.AddPrixArticle.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.AddPrixArticle.Name = "AddPrixArticle";
            this.AddPrixArticle.Size = new System.Drawing.Size(174, 26);
            this.AddPrixArticle.TabIndex = 1;
            this.AddPrixArticle.TextChanged += new System.EventHandler(this.textBox6_TextChanged);
            // 
            // AddNomArticle
            // 
            this.AddNomArticle.Location = new System.Drawing.Point(112, 79);
            this.AddNomArticle.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.AddNomArticle.Name = "AddNomArticle";
            this.AddNomArticle.Size = new System.Drawing.Size(174, 26);
            this.AddNomArticle.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.button9);
            this.groupBox3.Controls.Add(this.DelArticleName);
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.Controls.Add(this.AnnulerSuppr);
            this.groupBox3.Controls.Add(this.ConfirmerSuppr);
            this.groupBox3.Location = new System.Drawing.Point(404, 62);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox3.Size = new System.Drawing.Size(426, 218);
            this.groupBox3.TabIndex = 10;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Supprimer";
            this.groupBox3.Visible = false;
            this.groupBox3.Enter += new System.EventHandler(this.groupBox3_Enter);
            // 
            // button9
            // 
            this.button9.BackColor = System.Drawing.Color.Red;
            this.button9.Location = new System.Drawing.Point(389, 19);
            this.button9.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(26, 35);
            this.button9.TabIndex = 10;
            this.button9.Text = "X";
            this.button9.UseVisualStyleBackColor = false;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // DelArticleName
            // 
            this.DelArticleName.AutoSize = true;
            this.DelArticleName.Location = new System.Drawing.Point(171, 82);
            this.DelArticleName.Name = "DelArticleName";
            this.DelArticleName.Size = new System.Drawing.Size(18, 20);
            this.DelArticleName.TabIndex = 3;
            this.DelArticleName.Text = "0";
            this.DelArticleName.Click += new System.EventHandler(this.label13_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(65, 49);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(293, 20);
            this.label12.TabIndex = 2;
            this.label12.Text = "Voulez vous vraiment supprimer l\'article :";
            // 
            // AnnulerSuppr
            // 
            this.AnnulerSuppr.Location = new System.Drawing.Point(260, 138);
            this.AnnulerSuppr.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.AnnulerSuppr.Name = "AnnulerSuppr";
            this.AnnulerSuppr.Size = new System.Drawing.Size(98, 28);
            this.AnnulerSuppr.TabIndex = 1;
            this.AnnulerSuppr.Text = "Annuler";
            this.AnnulerSuppr.UseVisualStyleBackColor = true;
            this.AnnulerSuppr.Click += new System.EventHandler(this.AnnulerSuppr_Click);
            // 
            // ConfirmerSuppr
            // 
            this.ConfirmerSuppr.Location = new System.Drawing.Point(69, 142);
            this.ConfirmerSuppr.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ConfirmerSuppr.Name = "ConfirmerSuppr";
            this.ConfirmerSuppr.Size = new System.Drawing.Size(98, 28);
            this.ConfirmerSuppr.TabIndex = 0;
            this.ConfirmerSuppr.Text = "Confirmer";
            this.ConfirmerSuppr.UseVisualStyleBackColor = true;
            this.ConfirmerSuppr.Click += new System.EventHandler(this.ConfirmerSuppr_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.ModifAnnuler);
            this.groupBox4.Controls.Add(this.ValiderModif);
            this.groupBox4.Controls.Add(this.Quantités);
            this.groupBox4.Controls.Add(this.ReduceQuantite);
            this.groupBox4.Controls.Add(this.AddQuantite);
            this.groupBox4.Controls.Add(this.ModifQuantite);
            this.groupBox4.Controls.Add(this.ModifPrix);
            this.groupBox4.Controls.Add(this.ModifNom);
            this.groupBox4.Controls.Add(this.label14);
            this.groupBox4.Controls.Add(this.label13);
            this.groupBox4.Controls.Add(this.button10);
            this.groupBox4.Location = new System.Drawing.Point(291, 102);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox4.Size = new System.Drawing.Size(637, 369);
            this.groupBox4.TabIndex = 11;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Modifier";
            this.groupBox4.Visible = false;
            this.groupBox4.Enter += new System.EventHandler(this.groupBox4_Enter);
            // 
            // ModifAnnuler
            // 
            this.ModifAnnuler.Location = new System.Drawing.Point(385, 276);
            this.ModifAnnuler.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ModifAnnuler.Name = "ModifAnnuler";
            this.ModifAnnuler.Size = new System.Drawing.Size(86, 29);
            this.ModifAnnuler.TabIndex = 21;
            this.ModifAnnuler.Text = "Annuler";
            this.ModifAnnuler.UseVisualStyleBackColor = true;
            this.ModifAnnuler.Click += new System.EventHandler(this.ModifAnnuler_Click);
            // 
            // ValiderModif
            // 
            this.ValiderModif.Location = new System.Drawing.Point(227, 276);
            this.ValiderModif.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ValiderModif.Name = "ValiderModif";
            this.ValiderModif.Size = new System.Drawing.Size(75, 29);
            this.ValiderModif.TabIndex = 20;
            this.ValiderModif.Text = "Valider";
            this.ValiderModif.UseVisualStyleBackColor = true;
            this.ValiderModif.Click += new System.EventHandler(this.ValiderModif_Click);
            // 
            // Quantités
            // 
            this.Quantités.AutoSize = true;
            this.Quantités.Location = new System.Drawing.Point(386, 122);
            this.Quantités.Name = "Quantités";
            this.Quantités.Size = new System.Drawing.Size(78, 20);
            this.Quantités.TabIndex = 19;
            this.Quantités.Text = "Quantités";
            // 
            // ReduceQuantite
            // 
            this.ReduceQuantite.Location = new System.Drawing.Point(442, 190);
            this.ReduceQuantite.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ReduceQuantite.Name = "ReduceQuantite";
            this.ReduceQuantite.Size = new System.Drawing.Size(26, 34);
            this.ReduceQuantite.TabIndex = 18;
            this.ReduceQuantite.Text = "-";
            this.ReduceQuantite.UseVisualStyleBackColor = true;
            // 
            // AddQuantite
            // 
            this.AddQuantite.Location = new System.Drawing.Point(385, 191);
            this.AddQuantite.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.AddQuantite.Name = "AddQuantite";
            this.AddQuantite.Size = new System.Drawing.Size(29, 34);
            this.AddQuantite.TabIndex = 17;
            this.AddQuantite.Text = "+";
            this.AddQuantite.UseVisualStyleBackColor = true;
            // 
            // ModifQuantite
            // 
            this.ModifQuantite.Location = new System.Drawing.Point(379, 149);
            this.ModifQuantite.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ModifQuantite.Name = "ModifQuantite";
            this.ModifQuantite.Size = new System.Drawing.Size(100, 26);
            this.ModifQuantite.TabIndex = 16;
            this.ModifQuantite.TextChanged += new System.EventHandler(this.Quantite_TextChanged);
            // 
            // ModifPrix
            // 
            this.ModifPrix.Location = new System.Drawing.Point(182, 168);
            this.ModifPrix.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ModifPrix.Name = "ModifPrix";
            this.ModifPrix.Size = new System.Drawing.Size(100, 26);
            this.ModifPrix.TabIndex = 15;
            this.ModifPrix.TextChanged += new System.EventHandler(this.ModifPrix_TextChanged);
            // 
            // ModifNom
            // 
            this.ModifNom.Location = new System.Drawing.Point(182, 99);
            this.ModifNom.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ModifNom.Name = "ModifNom";
            this.ModifNom.Size = new System.Drawing.Size(100, 26);
            this.ModifNom.TabIndex = 14;
            this.ModifNom.TextChanged += new System.EventHandler(this.ModifNom_TextChanged);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(119, 170);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(42, 20);
            this.label14.TabIndex = 13;
            this.label14.Text = "Prix :";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(119, 102);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(50, 20);
            this.label13.TabIndex = 12;
            this.label13.Text = "Nom :";
            // 
            // button10
            // 
            this.button10.BackColor = System.Drawing.Color.Red;
            this.button10.Location = new System.Drawing.Point(590, 22);
            this.button10.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(26, 35);
            this.button10.TabIndex = 11;
            this.button10.Text = "X";
            this.button10.UseVisualStyleBackColor = false;
            this.button10.Click += new System.EventHandler(this.button10_Click);
            // 
            // GestionStock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 692);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.Categories);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.Articles);
            this.Controls.Add(this.button5);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "GestionStock";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox Articles;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.PageSetupDialog pageSetupDialog1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ListBox Categories;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox AddQuantiteArticle;
        private System.Windows.Forms.TextBox AddPrixArticle;
        private System.Windows.Forms.TextBox AddNomArticle;
        private System.Windows.Forms.ComboBox CategorieSelect;
        private System.Windows.Forms.Button Valider;
        private System.Windows.Forms.Button CloseButton;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button AnnulerSuppr;
        private System.Windows.Forms.Button ConfirmerSuppr;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label DelArticleName;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button ReduceQuantite;
        private System.Windows.Forms.Button AddQuantite;
        private System.Windows.Forms.TextBox ModifQuantite;
        private System.Windows.Forms.TextBox ModifPrix;
        private System.Windows.Forms.TextBox ModifNom;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.Label Quantités;
        private System.Windows.Forms.Button ValiderModif;
        private System.Windows.Forms.Button Annuler;
        private System.Windows.Forms.Button ModifAnnuler;
    }
}

