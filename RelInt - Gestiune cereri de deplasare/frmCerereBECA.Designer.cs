namespace RelInt___Gestiune_cereri_de_deplasare
{
    partial class frmCerereBECA
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCerereBECA));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.btnIesire = new System.Windows.Forms.ToolStripMenuItem();
            this.btnGenerare = new System.Windows.Forms.ToolStripMenuItem();
            this.panouIdentificare = new System.Windows.Forms.Panel();
            this.lblNrUAIC = new System.Windows.Forms.Label();
            this.txtNrUAIC = new System.Windows.Forms.TextBox();
            this.lblNrInregistrare = new System.Windows.Forms.Label();
            this.txtNrInregistrare = new System.Windows.Forms.TextBox();
            this.lblDin = new System.Windows.Forms.Label();
            this.dpDataBECA = new System.Windows.Forms.DateTimePicker();
            this.lblIdentificareBECA = new System.Windows.Forms.Label();
            this.lblSubsemnatul = new System.Windows.Forms.Label();
            this.txtSubsemnatul = new System.Windows.Forms.TextBox();
            this.cmbGradDidactic = new System.Windows.Forms.ComboBox();
            this.lblFacultatea = new System.Windows.Forms.Label();
            this.cmbFacultatea = new System.Windows.Forms.ComboBox();
            this.menuStrip1.SuspendLayout();
            this.panouIdentificare.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnIesire,
            this.btnGenerare});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(699, 24);
            this.menuStrip1.TabIndex = 0;
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
            // btnGenerare
            // 
            this.btnGenerare.Name = "btnGenerare";
            this.btnGenerare.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P)));
            this.btnGenerare.Size = new System.Drawing.Size(90, 20);
            this.btnGenerare.Text = "Generare &PDF";
            this.btnGenerare.Click += new System.EventHandler(this.btnGenerare_Click);
            // 
            // panouIdentificare
            // 
            this.panouIdentificare.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panouIdentificare.Controls.Add(this.cmbFacultatea);
            this.panouIdentificare.Controls.Add(this.lblFacultatea);
            this.panouIdentificare.Controls.Add(this.cmbGradDidactic);
            this.panouIdentificare.Controls.Add(this.txtSubsemnatul);
            this.panouIdentificare.Controls.Add(this.lblSubsemnatul);
            this.panouIdentificare.Controls.Add(this.lblIdentificareBECA);
            this.panouIdentificare.Controls.Add(this.dpDataBECA);
            this.panouIdentificare.Controls.Add(this.lblDin);
            this.panouIdentificare.Controls.Add(this.txtNrInregistrare);
            this.panouIdentificare.Controls.Add(this.lblNrInregistrare);
            this.panouIdentificare.Controls.Add(this.txtNrUAIC);
            this.panouIdentificare.Controls.Add(this.lblNrUAIC);
            this.panouIdentificare.Location = new System.Drawing.Point(12, 40);
            this.panouIdentificare.Name = "panouIdentificare";
            this.panouIdentificare.Size = new System.Drawing.Size(675, 255);
            this.panouIdentificare.TabIndex = 1;
            // 
            // lblNrUAIC
            // 
            this.lblNrUAIC.AutoSize = true;
            this.lblNrUAIC.Location = new System.Drawing.Point(9, 31);
            this.lblNrUAIC.Name = "lblNrUAIC";
            this.lblNrUAIC.Size = new System.Drawing.Size(66, 13);
            this.lblNrUAIC.TabIndex = 0;
            this.lblNrUAIC.Text = "Numar UAIC";
            // 
            // txtNrUAIC
            // 
            this.txtNrUAIC.Location = new System.Drawing.Point(81, 27);
            this.txtNrUAIC.Name = "txtNrUAIC";
            this.txtNrUAIC.Size = new System.Drawing.Size(100, 20);
            this.txtNrUAIC.TabIndex = 1;
            // 
            // lblNrInregistrare
            // 
            this.lblNrInregistrare.AutoSize = true;
            this.lblNrInregistrare.Location = new System.Drawing.Point(187, 31);
            this.lblNrInregistrare.Name = "lblNrInregistrare";
            this.lblNrInregistrare.Size = new System.Drawing.Size(92, 13);
            this.lblNrInregistrare.TabIndex = 2;
            this.lblNrInregistrare.Text = "număr înregistrare";
            // 
            // txtNrInregistrare
            // 
            this.txtNrInregistrare.Location = new System.Drawing.Point(285, 27);
            this.txtNrInregistrare.Name = "txtNrInregistrare";
            this.txtNrInregistrare.Size = new System.Drawing.Size(100, 20);
            this.txtNrInregistrare.TabIndex = 3;
            // 
            // lblDin
            // 
            this.lblDin.AutoSize = true;
            this.lblDin.Location = new System.Drawing.Point(391, 31);
            this.lblDin.Name = "lblDin";
            this.lblDin.Size = new System.Drawing.Size(21, 13);
            this.lblDin.TabIndex = 4;
            this.lblDin.Text = "din";
            // 
            // dpDataBECA
            // 
            this.dpDataBECA.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dpDataBECA.Location = new System.Drawing.Point(418, 27);
            this.dpDataBECA.Name = "dpDataBECA";
            this.dpDataBECA.Size = new System.Drawing.Size(78, 20);
            this.dpDataBECA.TabIndex = 5;
            // 
            // lblIdentificareBECA
            // 
            this.lblIdentificareBECA.AutoSize = true;
            this.lblIdentificareBECA.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIdentificareBECA.Location = new System.Drawing.Point(9, 5);
            this.lblIdentificareBECA.Name = "lblIdentificareBECA";
            this.lblIdentificareBECA.Size = new System.Drawing.Size(200, 17);
            this.lblIdentificareBECA.TabIndex = 6;
            this.lblIdentificareBECA.Text = "I. Identificare cerere BECA";
            // 
            // lblSubsemnatul
            // 
            this.lblSubsemnatul.AutoSize = true;
            this.lblSubsemnatul.Location = new System.Drawing.Point(9, 55);
            this.lblSubsemnatul.Name = "lblSubsemnatul";
            this.lblSubsemnatul.Size = new System.Drawing.Size(123, 13);
            this.lblSubsemnatul.TabIndex = 7;
            this.lblSubsemnatul.Text = "1. Deplasarea d-lui/d-nei";
            // 
            // txtSubsemnatul
            // 
            this.txtSubsemnatul.Location = new System.Drawing.Point(138, 51);
            this.txtSubsemnatul.Name = "txtSubsemnatul";
            this.txtSubsemnatul.Size = new System.Drawing.Size(187, 20);
            this.txtSubsemnatul.TabIndex = 8;
            // 
            // cmbGradDidactic
            // 
            this.cmbGradDidactic.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbGradDidactic.FormattingEnabled = true;
            this.cmbGradDidactic.Items.AddRange(new object[] {
            "student",
            "asistent",
            "prof. Dr.",
            "lect. Univ.",
            "decan",
            "prodecan"});
            this.cmbGradDidactic.Location = new System.Drawing.Point(331, 50);
            this.cmbGradDidactic.Name = "cmbGradDidactic";
            this.cmbGradDidactic.Size = new System.Drawing.Size(91, 21);
            this.cmbGradDidactic.TabIndex = 9;
            // 
            // lblFacultatea
            // 
            this.lblFacultatea.AutoSize = true;
            this.lblFacultatea.Location = new System.Drawing.Point(428, 54);
            this.lblFacultatea.Name = "lblFacultatea";
            this.lblFacultatea.Size = new System.Drawing.Size(68, 13);
            this.lblFacultatea.TabIndex = 10;
            this.lblFacultatea.Text = "la Facultatea";
            // 
            // cmbFacultatea
            // 
            this.cmbFacultatea.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFacultatea.FormattingEnabled = true;
            this.cmbFacultatea.Items.AddRange(new object[] {
            "FEAA",
            "Litere",
            "Matematica",
            "Informatica"});
            this.cmbFacultatea.Location = new System.Drawing.Point(502, 50);
            this.cmbFacultatea.Name = "cmbFacultatea";
            this.cmbFacultatea.Size = new System.Drawing.Size(121, 21);
            this.cmbFacultatea.TabIndex = 11;
            // 
            // frmCerereBECA
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(699, 661);
            this.Controls.Add(this.panouIdentificare);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmCerereBECA";
            this.Text = "Cerere BECA";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panouIdentificare.ResumeLayout(false);
            this.panouIdentificare.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem btnIesire;
        private System.Windows.Forms.ToolStripMenuItem btnGenerare;
        private System.Windows.Forms.Panel panouIdentificare;
        private System.Windows.Forms.Label lblNrUAIC;
        private System.Windows.Forms.TextBox txtNrUAIC;
        private System.Windows.Forms.Label lblNrInregistrare;
        private System.Windows.Forms.TextBox txtNrInregistrare;
        private System.Windows.Forms.Label lblDin;
        private System.Windows.Forms.DateTimePicker dpDataBECA;
        private System.Windows.Forms.Label lblIdentificareBECA;
        private System.Windows.Forms.Label lblSubsemnatul;
        private System.Windows.Forms.TextBox txtSubsemnatul;
        private System.Windows.Forms.ComboBox cmbGradDidactic;
        private System.Windows.Forms.Label lblFacultatea;
        private System.Windows.Forms.ComboBox cmbFacultatea;
    }
}