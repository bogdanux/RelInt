namespace RelInt___Gestiune_cereri_de_deplasare
{
    partial class frmCopieDeSiguranta
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCopieDeSiguranta));
            this.mnuResetare = new System.Windows.Forms.MenuStrip();
            this.btnIesire = new System.Windows.Forms.ToolStripMenuItem();
            this.panouInformatie = new System.Windows.Forms.Panel();
            this.llblInformatie4 = new System.Windows.Forms.LinkLabel();
            this.lblInformatie3 = new System.Windows.Forms.Label();
            this.lblInformatie2 = new System.Windows.Forms.Label();
            this.lblInformatie1 = new System.Windows.Forms.Label();
            this.panouActiuni = new System.Windows.Forms.Panel();
            this.btnSalvare = new System.Windows.Forms.Button();
            this.lblInformatie5 = new System.Windows.Forms.Label();
            this.mnuResetare.SuspendLayout();
            this.panouInformatie.SuspendLayout();
            this.panouActiuni.SuspendLayout();
            this.SuspendLayout();
            // 
            // mnuResetare
            // 
            this.mnuResetare.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.mnuResetare.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnIesire});
            this.mnuResetare.Location = new System.Drawing.Point(0, 0);
            this.mnuResetare.Name = "mnuResetare";
            this.mnuResetare.Size = new System.Drawing.Size(484, 24);
            this.mnuResetare.TabIndex = 0;
            this.mnuResetare.Text = "menuStrip1";
            // 
            // btnIesire
            // 
            this.btnIesire.Name = "btnIesire";
            this.btnIesire.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.W)));
            this.btnIesire.Size = new System.Drawing.Size(46, 20);
            this.btnIesire.Text = "I&eșire";
            this.btnIesire.Click += new System.EventHandler(this.btnIesire_Click);
            // 
            // panouInformatie
            // 
            this.panouInformatie.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panouInformatie.Controls.Add(this.lblInformatie5);
            this.panouInformatie.Controls.Add(this.llblInformatie4);
            this.panouInformatie.Controls.Add(this.lblInformatie3);
            this.panouInformatie.Controls.Add(this.lblInformatie2);
            this.panouInformatie.Controls.Add(this.lblInformatie1);
            this.panouInformatie.Location = new System.Drawing.Point(12, 38);
            this.panouInformatie.Name = "panouInformatie";
            this.panouInformatie.Size = new System.Drawing.Size(460, 197);
            this.panouInformatie.TabIndex = 1;
            // 
            // llblInformatie4
            // 
            this.llblInformatie4.AutoSize = true;
            this.llblInformatie4.Location = new System.Drawing.Point(49, 97);
            this.llblInformatie4.Name = "llblInformatie4";
            this.llblInformatie4.Size = new System.Drawing.Size(250, 13);
            this.llblInformatie4.TabIndex = 3;
            this.llblInformatie4.TabStop = true;
            this.llblInformatie4.Text = "Deschide dosarul în care se află copia de siguranță";
            this.llblInformatie4.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llblInformatie4_LinkClicked);
            // 
            // lblInformatie3
            // 
            this.lblInformatie3.AutoSize = true;
            this.lblInformatie3.Location = new System.Drawing.Point(52, 71);
            this.lblInformatie3.Name = "lblInformatie3";
            this.lblInformatie3.Size = new System.Drawing.Size(208, 13);
            this.lblInformatie3.TabIndex = 2;
            this.lblInformatie3.Text = "a tuturor datelor introduse până în prezent.";
            // 
            // lblInformatie2
            // 
            this.lblInformatie2.AutoSize = true;
            this.lblInformatie2.Location = new System.Drawing.Point(52, 46);
            this.lblInformatie2.Name = "lblInformatie2";
            this.lblInformatie2.Size = new System.Drawing.Size(353, 13);
            this.lblInformatie2.TabIndex = 1;
            this.lblInformatie2.Text = "Acest meniu are ca scop efectuarea unei copii de siguranță, cu o imagine";
            // 
            // lblInformatie1
            // 
            this.lblInformatie1.AutoSize = true;
            this.lblInformatie1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInformatie1.Location = new System.Drawing.Point(36, 10);
            this.lblInformatie1.Name = "lblInformatie1";
            this.lblInformatie1.Size = new System.Drawing.Size(80, 17);
            this.lblInformatie1.TabIndex = 0;
            this.lblInformatie1.Text = "Informație";
            // 
            // panouActiuni
            // 
            this.panouActiuni.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panouActiuni.Controls.Add(this.btnSalvare);
            this.panouActiuni.Location = new System.Drawing.Point(12, 241);
            this.panouActiuni.Name = "panouActiuni";
            this.panouActiuni.Size = new System.Drawing.Size(460, 83);
            this.panouActiuni.TabIndex = 2;
            // 
            // btnSalvare
            // 
            this.btnSalvare.Location = new System.Drawing.Point(52, 3);
            this.btnSalvare.Name = "btnSalvare";
            this.btnSalvare.Size = new System.Drawing.Size(365, 75);
            this.btnSalvare.TabIndex = 0;
            this.btnSalvare.Text = "Salvează";
            this.btnSalvare.UseVisualStyleBackColor = true;
            this.btnSalvare.Click += new System.EventHandler(this.button1_Click);
            // 
            // lblInformatie5
            // 
            this.lblInformatie5.AutoSize = true;
            this.lblInformatie5.Location = new System.Drawing.Point(52, 127);
            this.lblInformatie5.Name = "lblInformatie5";
            this.lblInformatie5.Size = new System.Drawing.Size(326, 13);
            this.lblInformatie5.TabIndex = 4;
            this.lblInformatie5.Text = "Pentru a efectua o copie de siguranță, apăsați pe butonul salvează.";
            // 
            // frmCopieDeSiguranta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(484, 333);
            this.Controls.Add(this.panouActiuni);
            this.Controls.Add(this.panouInformatie);
            this.Controls.Add(this.mnuResetare);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.mnuResetare;
            this.Name = "frmCopieDeSiguranta";
            this.Text = "Copie de Siguranță";
            this.mnuResetare.ResumeLayout(false);
            this.mnuResetare.PerformLayout();
            this.panouInformatie.ResumeLayout(false);
            this.panouInformatie.PerformLayout();
            this.panouActiuni.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mnuResetare;
        private System.Windows.Forms.ToolStripMenuItem btnIesire;
        private System.Windows.Forms.Panel panouInformatie;
        private System.Windows.Forms.Panel panouActiuni;
        private System.Windows.Forms.Label lblInformatie1;
        private System.Windows.Forms.Button btnSalvare;
        private System.Windows.Forms.Label lblInformatie2;
        private System.Windows.Forms.Label lblInformatie3;
        private System.Windows.Forms.LinkLabel llblInformatie4;
        private System.Windows.Forms.Label lblInformatie5;
    }
}