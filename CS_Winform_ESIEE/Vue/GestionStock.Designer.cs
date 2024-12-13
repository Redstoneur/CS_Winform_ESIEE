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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GestionStock));
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
            this.exporterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.jSONToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.jSONToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
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
            this.TypePromotionBox = new System.Windows.Forms.ComboBox();
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
            this.Articles.Location = new System.Drawing.Point(25, 91);
            this.Articles.Name = "Articles";
            this.Articles.Size = new System.Drawing.Size(422, 251);
            this.Articles.TabIndex = 0;
            this.Articles.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.TypePromotionBox);
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
            this.groupBox1.Location = new System.Drawing.Point(493, 120);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.groupBox1.Size = new System.Drawing.Size(245, 252);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Details article";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(90, 144);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(50, 15);
            this.label7.TabIndex = 13;
            this.label7.Text = "Remise";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(90, 104);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(18, 20);
            this.label6.TabIndex = 12;
            this.label6.Text = "€";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(130, 85);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 15);
            this.label5.TabIndex = 11;
            this.label5.Text = "Quantités";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(45, 85);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(28, 15);
            this.label4.TabIndex = 10;
            this.label4.Text = "Prix";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(39, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 15);
            this.label3.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(39, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 15);
            this.label2.TabIndex = 8;
            this.label2.Text = "Article";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(136, 168);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(23, 20);
            this.label1.TabIndex = 7;
            this.label1.Text = "%";
            // 
            // textBox5
            // 
            this.textBox5.Enabled = false;
            this.textBox5.Location = new System.Drawing.Point(107, 168);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(32, 20);
            this.textBox5.TabIndex = 6;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(163, 167);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(61, 23);
            this.button4.TabIndex = 5;
            this.button4.Text = "Appliquer";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(87, 203);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(62, 23);
            this.button3.TabIndex = 4;
            this.button3.Text = "Modifier";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // textBox3
            // 
            this.textBox3.Enabled = false;
            this.textBox3.Location = new System.Drawing.Point(34, 103);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(54, 20);
            this.textBox3.TabIndex = 2;
            // 
            // textBox2
            // 
            this.textBox2.Enabled = false;
            this.textBox2.Location = new System.Drawing.Point(126, 103);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(68, 20);
            this.textBox2.TabIndex = 1;
            // 
            // textBox1
            // 
            this.textBox1.Enabled = false;
            this.textBox1.Location = new System.Drawing.Point(32, 44);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(176, 20);
            this.textBox1.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(699, 33);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(89, 45);
            this.button1.TabIndex = 3;
            this.button1.Text = "Réapprovision-nement";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button5
            // 
            this.button5.Enabled = false;
            this.button5.Location = new System.Drawing.Point(525, 91);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(176, 23);
            this.button5.TabIndex = 5;
            this.button5.Text = "Historique de stock";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(34, 349);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(38, 23);
            this.button6.TabIndex = 6;
            this.button6.Text = "+";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(78, 349);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(38, 23);
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
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 1, 0, 1);
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 8;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem,
            this.exporterToolStripMenuItem,
            this.importerToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 22);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(120, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click_1);
            // 
            // exporterToolStripMenuItem
            // 
            this.exporterToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.jSONToolStripMenuItem});
            this.exporterToolStripMenuItem.Name = "exporterToolStripMenuItem";
            this.exporterToolStripMenuItem.Size = new System.Drawing.Size(120, 22);
            this.exporterToolStripMenuItem.Text = "Exporter";
            // 
            // jSONToolStripMenuItem
            // 
            this.jSONToolStripMenuItem.Name = "jSONToolStripMenuItem";
            this.jSONToolStripMenuItem.Size = new System.Drawing.Size(102, 22);
            this.jSONToolStripMenuItem.Text = "JSON";
            this.jSONToolStripMenuItem.Click += new System.EventHandler(this.jSONToolStripMenuItem_Click);
            // 
            // importerToolStripMenuItem
            // 
            this.importerToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.jSONToolStripMenuItem1});
            this.importerToolStripMenuItem.Name = "importerToolStripMenuItem";
            this.importerToolStripMenuItem.Size = new System.Drawing.Size(120, 22);
            this.importerToolStripMenuItem.Text = "Importer";
            // 
            // jSONToolStripMenuItem1
            // 
            this.jSONToolStripMenuItem1.Name = "jSONToolStripMenuItem1";
            this.jSONToolStripMenuItem1.Size = new System.Drawing.Size(102, 22);
            this.jSONToolStripMenuItem1.Text = "JSON";
            this.jSONToolStripMenuItem1.Click += new System.EventHandler(this.jSONToolStripMenuItem1_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(52, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // Categories
            // 
            this.Categories.Location = new System.Drawing.Point(25, 27);
            this.Categories.Name = "Categories";
            this.Categories.Size = new System.Drawing.Size(657, 56);
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
            this.groupBox2.Location = new System.Drawing.Point(175, 81);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.groupBox2.Size = new System.Drawing.Size(455, 229);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Ajouter";
            this.groupBox2.Visible = false;
            // 
            // Annuler
            // 
            this.Annuler.Location = new System.Drawing.Point(272, 174);
            this.Annuler.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.Annuler.Name = "Annuler";
            this.Annuler.Size = new System.Drawing.Size(67, 21);
            this.Annuler.TabIndex = 10;
            this.Annuler.Text = "Annuler";
            this.Annuler.UseVisualStyleBackColor = true;
            this.Annuler.Click += new System.EventHandler(this.Annuler_Click);
            // 
            // CloseButton
            // 
            this.CloseButton.BackColor = System.Drawing.Color.Red;
            this.CloseButton.Location = new System.Drawing.Point(433, 7);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(17, 23);
            this.CloseButton.TabIndex = 9;
            this.CloseButton.Text = "X";
            this.CloseButton.UseVisualStyleBackColor = false;
            this.CloseButton.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // Valider
            // 
            this.Valider.Location = new System.Drawing.Point(126, 174);
            this.Valider.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.Valider.Name = "Valider";
            this.Valider.Size = new System.Drawing.Size(72, 21);
            this.Valider.TabIndex = 8;
            this.Valider.Text = "Valider";
            this.Valider.UseVisualStyleBackColor = true;
            this.Valider.Click += new System.EventHandler(this.Valider_Click);
            // 
            // CategorieSelect
            // 
            this.CategorieSelect.FormattingEnabled = true;
            this.CategorieSelect.Location = new System.Drawing.Point(272, 92);
            this.CategorieSelect.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.CategorieSelect.Name = "CategorieSelect";
            this.CategorieSelect.Size = new System.Drawing.Size(121, 21);
            this.CategorieSelect.TabIndex = 7;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(216, 95);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(58, 13);
            this.label11.TabIndex = 6;
            this.label11.Text = "Catégorie :";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(211, 51);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(58, 13);
            this.label10.TabIndex = 5;
            this.label10.Text = "Quantités :";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(43, 94);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(30, 13);
            this.label9.TabIndex = 4;
            this.label9.Text = "Prix :";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(37, 52);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(35, 13);
            this.label8.TabIndex = 3;
            this.label8.Text = "Nom :";
            // 
            // AddQuantiteArticle
            // 
            this.AddQuantiteArticle.Location = new System.Drawing.Point(272, 48);
            this.AddQuantiteArticle.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.AddQuantiteArticle.Name = "AddQuantiteArticle";
            this.AddQuantiteArticle.Size = new System.Drawing.Size(121, 20);
            this.AddQuantiteArticle.TabIndex = 2;
            // 
            // AddPrixArticle
            // 
            this.AddPrixArticle.Location = new System.Drawing.Point(75, 94);
            this.AddPrixArticle.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.AddPrixArticle.Name = "AddPrixArticle";
            this.AddPrixArticle.Size = new System.Drawing.Size(117, 20);
            this.AddPrixArticle.TabIndex = 1;
            // 
            // AddNomArticle
            // 
            this.AddNomArticle.Location = new System.Drawing.Point(75, 51);
            this.AddNomArticle.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.AddNomArticle.Name = "AddNomArticle";
            this.AddNomArticle.Size = new System.Drawing.Size(117, 20);
            this.AddNomArticle.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.button9);
            this.groupBox3.Controls.Add(this.DelArticleName);
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.Controls.Add(this.AnnulerSuppr);
            this.groupBox3.Controls.Add(this.ConfirmerSuppr);
            this.groupBox3.Location = new System.Drawing.Point(269, 40);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.groupBox3.Size = new System.Drawing.Size(284, 142);
            this.groupBox3.TabIndex = 10;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Supprimer";
            this.groupBox3.Visible = false;
            // 
            // button9
            // 
            this.button9.BackColor = System.Drawing.Color.Red;
            this.button9.Location = new System.Drawing.Point(259, 12);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(17, 23);
            this.button9.TabIndex = 10;
            this.button9.Text = "X";
            this.button9.UseVisualStyleBackColor = false;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // DelArticleName
            // 
            this.DelArticleName.AutoSize = true;
            this.DelArticleName.Location = new System.Drawing.Point(114, 53);
            this.DelArticleName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.DelArticleName.Name = "DelArticleName";
            this.DelArticleName.Size = new System.Drawing.Size(13, 13);
            this.DelArticleName.TabIndex = 3;
            this.DelArticleName.Text = "0";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(43, 32);
            this.label12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(197, 13);
            this.label12.TabIndex = 2;
            this.label12.Text = "Voulez vous vraiment supprimer l\'article :";
            // 
            // AnnulerSuppr
            // 
            this.AnnulerSuppr.Location = new System.Drawing.Point(173, 90);
            this.AnnulerSuppr.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.AnnulerSuppr.Name = "AnnulerSuppr";
            this.AnnulerSuppr.Size = new System.Drawing.Size(65, 18);
            this.AnnulerSuppr.TabIndex = 1;
            this.AnnulerSuppr.Text = "Annuler";
            this.AnnulerSuppr.UseVisualStyleBackColor = true;
            this.AnnulerSuppr.Click += new System.EventHandler(this.AnnulerSuppr_Click);
            // 
            // ConfirmerSuppr
            // 
            this.ConfirmerSuppr.Location = new System.Drawing.Point(46, 92);
            this.ConfirmerSuppr.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.ConfirmerSuppr.Name = "ConfirmerSuppr";
            this.ConfirmerSuppr.Size = new System.Drawing.Size(65, 18);
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
            this.groupBox4.Location = new System.Drawing.Point(194, 66);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.groupBox4.Size = new System.Drawing.Size(425, 240);
            this.groupBox4.TabIndex = 11;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Modifier";
            this.groupBox4.Visible = false;
            // 
            // ModifAnnuler
            // 
            this.ModifAnnuler.Location = new System.Drawing.Point(257, 179);
            this.ModifAnnuler.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.ModifAnnuler.Name = "ModifAnnuler";
            this.ModifAnnuler.Size = new System.Drawing.Size(57, 19);
            this.ModifAnnuler.TabIndex = 21;
            this.ModifAnnuler.Text = "Annuler";
            this.ModifAnnuler.UseVisualStyleBackColor = true;
            this.ModifAnnuler.Click += new System.EventHandler(this.ModifAnnuler_Click);
            // 
            // ValiderModif
            // 
            this.ValiderModif.Location = new System.Drawing.Point(151, 179);
            this.ValiderModif.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.ValiderModif.Name = "ValiderModif";
            this.ValiderModif.Size = new System.Drawing.Size(50, 19);
            this.ValiderModif.TabIndex = 20;
            this.ValiderModif.Text = "Valider";
            this.ValiderModif.UseVisualStyleBackColor = true;
            this.ValiderModif.Click += new System.EventHandler(this.ValiderModif_Click);
            // 
            // Quantités
            // 
            this.Quantités.AutoSize = true;
            this.Quantités.Location = new System.Drawing.Point(257, 79);
            this.Quantités.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Quantités.Name = "Quantités";
            this.Quantités.Size = new System.Drawing.Size(52, 13);
            this.Quantités.TabIndex = 19;
            this.Quantités.Text = "Quantités";
            // 
            // ReduceQuantite
            // 
            this.ReduceQuantite.Location = new System.Drawing.Point(295, 123);
            this.ReduceQuantite.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.ReduceQuantite.Name = "ReduceQuantite";
            this.ReduceQuantite.Size = new System.Drawing.Size(17, 22);
            this.ReduceQuantite.TabIndex = 18;
            this.ReduceQuantite.Text = "-";
            this.ReduceQuantite.UseVisualStyleBackColor = true;
            // 
            // AddQuantite
            // 
            this.AddQuantite.Location = new System.Drawing.Point(257, 124);
            this.AddQuantite.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.AddQuantite.Name = "AddQuantite";
            this.AddQuantite.Size = new System.Drawing.Size(19, 22);
            this.AddQuantite.TabIndex = 17;
            this.AddQuantite.Text = "+";
            this.AddQuantite.UseVisualStyleBackColor = true;
            // 
            // ModifQuantite
            // 
            this.ModifQuantite.Location = new System.Drawing.Point(253, 97);
            this.ModifQuantite.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.ModifQuantite.Name = "ModifQuantite";
            this.ModifQuantite.Size = new System.Drawing.Size(68, 20);
            this.ModifQuantite.TabIndex = 16;
            // 
            // ModifPrix
            // 
            this.ModifPrix.Location = new System.Drawing.Point(121, 109);
            this.ModifPrix.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.ModifPrix.Name = "ModifPrix";
            this.ModifPrix.Size = new System.Drawing.Size(68, 20);
            this.ModifPrix.TabIndex = 15;
            // 
            // ModifNom
            // 
            this.ModifNom.Location = new System.Drawing.Point(121, 64);
            this.ModifNom.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.ModifNom.Name = "ModifNom";
            this.ModifNom.Size = new System.Drawing.Size(68, 20);
            this.ModifNom.TabIndex = 14;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(79, 110);
            this.label14.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(30, 13);
            this.label14.TabIndex = 13;
            this.label14.Text = "Prix :";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(79, 66);
            this.label13.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(35, 13);
            this.label13.TabIndex = 12;
            this.label13.Text = "Nom :";
            // 
            // button10
            // 
            this.button10.BackColor = System.Drawing.Color.Red;
            this.button10.Location = new System.Drawing.Point(393, 14);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(17, 23);
            this.button10.TabIndex = 11;
            this.button10.Text = "X";
            this.button10.UseVisualStyleBackColor = false;
            this.button10.Click += new System.EventHandler(this.button10_Click);
            // 
            // TypePromotionBox
            // 
            this.TypePromotionBox.FormattingEnabled = true;
            this.TypePromotionBox.Location = new System.Drawing.Point(14, 167);
            this.TypePromotionBox.Name = "TypePromotionBox";
            this.TypePromotionBox.Size = new System.Drawing.Size(87, 21);
            this.TypePromotionBox.TabIndex = 14;
            this.TypePromotionBox.SelectedIndexChanged += new System.EventHandler(this.TypePromotionBox_SelectedIndexChanged);
            // 
            // GestionStock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.Categories);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.Articles);
            this.Controls.Add(this.button5);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "GestionStock";
            this.Text = "MilkyMarket";
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
        private System.Windows.Forms.ToolStripMenuItem exporterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem jSONToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem jSONToolStripMenuItem1;
        private System.Windows.Forms.ComboBox TypePromotionBox;
    }
}

