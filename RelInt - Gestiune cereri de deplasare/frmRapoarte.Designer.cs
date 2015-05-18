namespace RelInt___Gestiune_cereri_de_deplasare
{
    partial class frmRapoarte
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRapoarte));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.btnIesire = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tpRapoarteCereri = new System.Windows.Forms.TabPage();
            this.panouRCIdentificare = new System.Windows.Forms.Panel();
            this.btnRCAfiseaza = new System.Windows.Forms.Button();
            this.cmbRCConditia = new System.Windows.Forms.ComboBox();
            this.lblRCConditia = new System.Windows.Forms.Label();
            this.cmbRCAsupra = new System.Windows.Forms.ComboBox();
            this.lblAsupra = new System.Windows.Forms.Label();
            this.lblRCIdentificare = new System.Windows.Forms.Label();
            this.tpRapoarteODD = new System.Windows.Forms.TabPage();
            this.panelRODDIdentificare = new System.Windows.Forms.Panel();
            this.btnRODDAfiseaza = new System.Windows.Forms.Button();
            this.cmbRODDConditia = new System.Windows.Forms.ComboBox();
            this.lblRODDConditia = new System.Windows.Forms.Label();
            this.cmbRODDAsupra = new System.Windows.Forms.ComboBox();
            this.lblRODDAsupra = new System.Windows.Forms.Label();
            this.lblRODDIdentificare = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tpRapoarteCereri.SuspendLayout();
            this.panouRCIdentificare.SuspendLayout();
            this.tpRapoarteODD.SuspendLayout();
            this.panelRODDIdentificare.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnIesire});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(699, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // btnIesire
            // 
            this.btnIesire.Name = "btnIesire";
            this.btnIesire.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.W)));
            this.btnIesire.Size = new System.Drawing.Size(46, 20);
            this.btnIesire.Text = "I&eșire";
            this.btnIesire.Click += new System.EventHandler(this.btnIesire_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tpRapoarteCereri);
            this.tabControl1.Controls.Add(this.tpRapoarteODD);
            this.tabControl1.Location = new System.Drawing.Point(3, 27);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(695, 632);
            this.tabControl1.TabIndex = 2;
            // 
            // tpRapoarteCereri
            // 
            this.tpRapoarteCereri.Controls.Add(this.panouRCIdentificare);
            this.tpRapoarteCereri.Location = new System.Drawing.Point(4, 22);
            this.tpRapoarteCereri.Name = "tpRapoarteCereri";
            this.tpRapoarteCereri.Padding = new System.Windows.Forms.Padding(3);
            this.tpRapoarteCereri.Size = new System.Drawing.Size(687, 606);
            this.tpRapoarteCereri.TabIndex = 0;
            this.tpRapoarteCereri.Text = "Rapoarte Cereri";
            this.tpRapoarteCereri.UseVisualStyleBackColor = true;
            // 
            // panouRCIdentificare
            // 
            this.panouRCIdentificare.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panouRCIdentificare.Controls.Add(this.btnRCAfiseaza);
            this.panouRCIdentificare.Controls.Add(this.cmbRCConditia);
            this.panouRCIdentificare.Controls.Add(this.lblRCConditia);
            this.panouRCIdentificare.Controls.Add(this.cmbRCAsupra);
            this.panouRCIdentificare.Controls.Add(this.lblAsupra);
            this.panouRCIdentificare.Controls.Add(this.lblRCIdentificare);
            this.panouRCIdentificare.Location = new System.Drawing.Point(6, 6);
            this.panouRCIdentificare.Name = "panouRCIdentificare";
            this.panouRCIdentificare.Size = new System.Drawing.Size(674, 68);
            this.panouRCIdentificare.TabIndex = 0;
            // 
            // btnRCAfiseaza
            // 
            this.btnRCAfiseaza.Enabled = false;
            this.btnRCAfiseaza.Location = new System.Drawing.Point(534, 30);
            this.btnRCAfiseaza.Name = "btnRCAfiseaza";
            this.btnRCAfiseaza.Size = new System.Drawing.Size(120, 23);
            this.btnRCAfiseaza.TabIndex = 5;
            this.btnRCAfiseaza.Text = "Afișează raport";
            this.btnRCAfiseaza.UseVisualStyleBackColor = true;
            // 
            // cmbRCConditia
            // 
            this.cmbRCConditia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRCConditia.Enabled = false;
            this.cmbRCConditia.FormattingEnabled = true;
            this.cmbRCConditia.Location = new System.Drawing.Point(278, 31);
            this.cmbRCConditia.Name = "cmbRCConditia";
            this.cmbRCConditia.Size = new System.Drawing.Size(250, 21);
            this.cmbRCConditia.TabIndex = 4;
            this.cmbRCConditia.SelectedIndexChanged += new System.EventHandler(this.cmbRCConditia_SelectedIndexChanged);
            // 
            // lblRCConditia
            // 
            this.lblRCConditia.AutoSize = true;
            this.lblRCConditia.Location = new System.Drawing.Point(225, 34);
            this.lblRCConditia.Name = "lblRCConditia";
            this.lblRCConditia.Size = new System.Drawing.Size(47, 13);
            this.lblRCConditia.TabIndex = 3;
            this.lblRCConditia.Text = "condiția:";
            // 
            // cmbRCAsupra
            // 
            this.cmbRCAsupra.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRCAsupra.FormattingEnabled = true;
            this.cmbRCAsupra.Items.AddRange(new object[] {
            "Facultate",
            "Grad didactic",
            "Țară",
            "An",
            "Scop"});
            this.cmbRCAsupra.Location = new System.Drawing.Point(98, 31);
            this.cmbRCAsupra.Name = "cmbRCAsupra";
            this.cmbRCAsupra.Size = new System.Drawing.Size(121, 21);
            this.cmbRCAsupra.TabIndex = 2;
            this.cmbRCAsupra.SelectedIndexChanged += new System.EventHandler(this.cmbRCAsupra_SelectedIndexChanged);
            // 
            // lblAsupra
            // 
            this.lblAsupra.AutoSize = true;
            this.lblAsupra.Location = new System.Drawing.Point(15, 34);
            this.lblAsupra.Name = "lblAsupra";
            this.lblAsupra.Size = new System.Drawing.Size(77, 13);
            this.lblAsupra.TabIndex = 1;
            this.lblAsupra.Text = "Raport asupra:";
            // 
            // lblRCIdentificare
            // 
            this.lblRCIdentificare.AutoSize = true;
            this.lblRCIdentificare.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRCIdentificare.Location = new System.Drawing.Point(12, 11);
            this.lblRCIdentificare.Name = "lblRCIdentificare";
            this.lblRCIdentificare.Size = new System.Drawing.Size(162, 17);
            this.lblRCIdentificare.TabIndex = 0;
            this.lblRCIdentificare.Text = "1. Identificare Raport";
            // 
            // tpRapoarteODD
            // 
            this.tpRapoarteODD.Controls.Add(this.panelRODDIdentificare);
            this.tpRapoarteODD.Location = new System.Drawing.Point(4, 22);
            this.tpRapoarteODD.Name = "tpRapoarteODD";
            this.tpRapoarteODD.Padding = new System.Windows.Forms.Padding(3);
            this.tpRapoarteODD.Size = new System.Drawing.Size(687, 606);
            this.tpRapoarteODD.TabIndex = 1;
            this.tpRapoarteODD.Text = "Rapoarte Ordine de Deplasare";
            this.tpRapoarteODD.UseVisualStyleBackColor = true;
            // 
            // panelRODDIdentificare
            // 
            this.panelRODDIdentificare.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelRODDIdentificare.Controls.Add(this.btnRODDAfiseaza);
            this.panelRODDIdentificare.Controls.Add(this.cmbRODDConditia);
            this.panelRODDIdentificare.Controls.Add(this.lblRODDConditia);
            this.panelRODDIdentificare.Controls.Add(this.cmbRODDAsupra);
            this.panelRODDIdentificare.Controls.Add(this.lblRODDAsupra);
            this.panelRODDIdentificare.Controls.Add(this.lblRODDIdentificare);
            this.panelRODDIdentificare.Location = new System.Drawing.Point(6, 6);
            this.panelRODDIdentificare.Name = "panelRODDIdentificare";
            this.panelRODDIdentificare.Size = new System.Drawing.Size(674, 68);
            this.panelRODDIdentificare.TabIndex = 1;
            // 
            // btnRODDAfiseaza
            // 
            this.btnRODDAfiseaza.Enabled = false;
            this.btnRODDAfiseaza.Location = new System.Drawing.Point(534, 30);
            this.btnRODDAfiseaza.Name = "btnRODDAfiseaza";
            this.btnRODDAfiseaza.Size = new System.Drawing.Size(120, 23);
            this.btnRODDAfiseaza.TabIndex = 5;
            this.btnRODDAfiseaza.Text = "Afișează raport";
            this.btnRODDAfiseaza.UseVisualStyleBackColor = true;
            // 
            // cmbRODDConditia
            // 
            this.cmbRODDConditia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRODDConditia.Enabled = false;
            this.cmbRODDConditia.FormattingEnabled = true;
            this.cmbRODDConditia.Location = new System.Drawing.Point(278, 31);
            this.cmbRODDConditia.Name = "cmbRODDConditia";
            this.cmbRODDConditia.Size = new System.Drawing.Size(250, 21);
            this.cmbRODDConditia.TabIndex = 4;
            this.cmbRODDConditia.SelectedIndexChanged += new System.EventHandler(this.cmbRODDConditia_SelectedIndexChanged);
            // 
            // lblRODDConditia
            // 
            this.lblRODDConditia.AutoSize = true;
            this.lblRODDConditia.Location = new System.Drawing.Point(225, 34);
            this.lblRODDConditia.Name = "lblRODDConditia";
            this.lblRODDConditia.Size = new System.Drawing.Size(47, 13);
            this.lblRODDConditia.TabIndex = 3;
            this.lblRODDConditia.Text = "condiția:";
            // 
            // cmbRODDAsupra
            // 
            this.cmbRODDAsupra.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRODDAsupra.FormattingEnabled = true;
            this.cmbRODDAsupra.Items.AddRange(new object[] {
            "Facultate",
            "Grad didactic",
            "Țară",
            "An",
            "Scop"});
            this.cmbRODDAsupra.Location = new System.Drawing.Point(98, 31);
            this.cmbRODDAsupra.Name = "cmbRODDAsupra";
            this.cmbRODDAsupra.Size = new System.Drawing.Size(121, 21);
            this.cmbRODDAsupra.TabIndex = 2;
            this.cmbRODDAsupra.SelectedIndexChanged += new System.EventHandler(this.cmbRODDAsupra_SelectedIndexChanged);
            // 
            // lblRODDAsupra
            // 
            this.lblRODDAsupra.AutoSize = true;
            this.lblRODDAsupra.Location = new System.Drawing.Point(15, 34);
            this.lblRODDAsupra.Name = "lblRODDAsupra";
            this.lblRODDAsupra.Size = new System.Drawing.Size(77, 13);
            this.lblRODDAsupra.TabIndex = 1;
            this.lblRODDAsupra.Text = "Raport asupra:";
            // 
            // lblRODDIdentificare
            // 
            this.lblRODDIdentificare.AutoSize = true;
            this.lblRODDIdentificare.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRODDIdentificare.Location = new System.Drawing.Point(12, 11);
            this.lblRODDIdentificare.Name = "lblRODDIdentificare";
            this.lblRODDIdentificare.Size = new System.Drawing.Size(162, 17);
            this.lblRODDIdentificare.TabIndex = 0;
            this.lblRODDIdentificare.Text = "1. Identificare Raport";
            // 
            // frmRapoarte
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(699, 661);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "frmRapoarte";
            this.Text = "Rapoarte";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tpRapoarteCereri.ResumeLayout(false);
            this.panouRCIdentificare.ResumeLayout(false);
            this.panouRCIdentificare.PerformLayout();
            this.tpRapoarteODD.ResumeLayout(false);
            this.panelRODDIdentificare.ResumeLayout(false);
            this.panelRODDIdentificare.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem btnIesire;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tpRapoarteCereri;
        private System.Windows.Forms.TabPage tpRapoarteODD;
        private System.Windows.Forms.Panel panouRCIdentificare;
        private System.Windows.Forms.Label lblRCIdentificare;
        private System.Windows.Forms.Label lblAsupra;
        private System.Windows.Forms.ComboBox cmbRCAsupra;
        private System.Windows.Forms.Label lblRCConditia;
        private System.Windows.Forms.ComboBox cmbRCConditia;
        private System.Windows.Forms.Button btnRCAfiseaza;
        private System.Windows.Forms.Panel panelRODDIdentificare;
        private System.Windows.Forms.Button btnRODDAfiseaza;
        private System.Windows.Forms.ComboBox cmbRODDConditia;
        private System.Windows.Forms.Label lblRODDConditia;
        private System.Windows.Forms.ComboBox cmbRODDAsupra;
        private System.Windows.Forms.Label lblRODDAsupra;
        private System.Windows.Forms.Label lblRODDIdentificare;
    }
}