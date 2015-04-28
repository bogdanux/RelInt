namespace RelInt___Gestiune_cereri_de_deplasare
{
    partial class frmResetareAplicatie
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmResetareAplicatie));
            this.mnuResetare = new System.Windows.Forms.MenuStrip();
            this.btnIesire = new System.Windows.Forms.ToolStripMenuItem();
            this.panouAtentie = new System.Windows.Forms.Panel();
            this.lblAtentionare4 = new System.Windows.Forms.Label();
            this.lblAtentionare3 = new System.Windows.Forms.Label();
            this.lblAtentionare2 = new System.Windows.Forms.Label();
            this.lblAtentionare1 = new System.Windows.Forms.Label();
            this.chkDeAcord = new System.Windows.Forms.CheckBox();
            this.lblAtentie = new System.Windows.Forms.Label();
            this.panouActiuni = new System.Windows.Forms.Panel();
            this.btnResetare = new System.Windows.Forms.Button();
            this.txtParola = new System.Windows.Forms.TextBox();
            this.lblIntroducere = new System.Windows.Forms.Label();
            this.mnuResetare.SuspendLayout();
            this.panouAtentie.SuspendLayout();
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
            // panouAtentie
            // 
            this.panouAtentie.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panouAtentie.Controls.Add(this.lblAtentionare4);
            this.panouAtentie.Controls.Add(this.lblAtentionare3);
            this.panouAtentie.Controls.Add(this.lblAtentionare2);
            this.panouAtentie.Controls.Add(this.lblAtentionare1);
            this.panouAtentie.Controls.Add(this.chkDeAcord);
            this.panouAtentie.Controls.Add(this.lblAtentie);
            this.panouAtentie.Location = new System.Drawing.Point(12, 38);
            this.panouAtentie.Name = "panouAtentie";
            this.panouAtentie.Size = new System.Drawing.Size(460, 197);
            this.panouAtentie.TabIndex = 1;
            // 
            // lblAtentionare4
            // 
            this.lblAtentionare4.AutoSize = true;
            this.lblAtentionare4.Location = new System.Drawing.Point(39, 127);
            this.lblAtentionare4.Name = "lblAtentionare4";
            this.lblAtentionare4.Size = new System.Drawing.Size(281, 13);
            this.lblAtentionare4.TabIndex = 5;
            this.lblAtentionare4.Text = "Dacă doriți să continuați vă rugăm bifați caseta de mai jos.";
            // 
            // lblAtentionare3
            // 
            this.lblAtentionare3.AutoSize = true;
            this.lblAtentionare3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAtentionare3.Location = new System.Drawing.Point(39, 96);
            this.lblAtentionare3.Name = "lblAtentionare3";
            this.lblAtentionare3.Size = new System.Drawing.Size(369, 15);
            this.lblAtentionare3.TabIndex = 4;
            this.lblAtentionare3.Text = "TOATE Cererile și Ordinele de Deplasare vor fi pierdute !";
            // 
            // lblAtentionare2
            // 
            this.lblAtentionare2.AutoSize = true;
            this.lblAtentionare2.Location = new System.Drawing.Point(39, 61);
            this.lblAtentionare2.Name = "lblAtentionare2";
            this.lblAtentionare2.Size = new System.Drawing.Size(392, 13);
            this.lblAtentionare2.TabIndex = 3;
            this.lblAtentionare2.Text = "ACESTUI program. Această acțiune nu poate fi anulată odată ce a fost accesată.";
            // 
            // lblAtentionare1
            // 
            this.lblAtentionare1.AutoSize = true;
            this.lblAtentionare1.Location = new System.Drawing.Point(39, 43);
            this.lblAtentionare1.Name = "lblAtentionare1";
            this.lblAtentionare1.Size = new System.Drawing.Size(397, 13);
            this.lblAtentionare1.TabIndex = 2;
            this.lblAtentionare1.Text = "Acest meniu are scopul de a ȘTERGE TOATE DATELE din baza de date asociată";
            // 
            // chkDeAcord
            // 
            this.chkDeAcord.AutoSize = true;
            this.chkDeAcord.Location = new System.Drawing.Point(39, 159);
            this.chkDeAcord.Name = "chkDeAcord";
            this.chkDeAcord.Size = new System.Drawing.Size(325, 17);
            this.chkDeAcord.TabIndex = 1;
            this.chkDeAcord.Text = "Înțeleg riscurile și doresc să șterg toate datele din baza de date.";
            this.chkDeAcord.UseVisualStyleBackColor = true;
            this.chkDeAcord.CheckedChanged += new System.EventHandler(this.chkDeAcord_CheckedChanged);
            // 
            // lblAtentie
            // 
            this.lblAtentie.AutoSize = true;
            this.lblAtentie.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAtentie.Location = new System.Drawing.Point(36, 10);
            this.lblAtentie.Name = "lblAtentie";
            this.lblAtentie.Size = new System.Drawing.Size(59, 17);
            this.lblAtentie.TabIndex = 0;
            this.lblAtentie.Text = "Atenție";
            // 
            // panouActiuni
            // 
            this.panouActiuni.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panouActiuni.Controls.Add(this.btnResetare);
            this.panouActiuni.Controls.Add(this.txtParola);
            this.panouActiuni.Controls.Add(this.lblIntroducere);
            this.panouActiuni.Location = new System.Drawing.Point(12, 241);
            this.panouActiuni.Name = "panouActiuni";
            this.panouActiuni.Size = new System.Drawing.Size(460, 83);
            this.panouActiuni.TabIndex = 2;
            // 
            // btnResetare
            // 
            this.btnResetare.Location = new System.Drawing.Point(277, 42);
            this.btnResetare.Name = "btnResetare";
            this.btnResetare.Size = new System.Drawing.Size(129, 23);
            this.btnResetare.TabIndex = 2;
            this.btnResetare.Text = "Resetează";
            this.btnResetare.UseVisualStyleBackColor = true;
            this.btnResetare.Click += new System.EventHandler(this.btnResetare_Click);
            // 
            // txtParola
            // 
            this.txtParola.Location = new System.Drawing.Point(39, 44);
            this.txtParola.Name = "txtParola";
            this.txtParola.Size = new System.Drawing.Size(232, 20);
            this.txtParola.TabIndex = 1;
            this.txtParola.TextChanged += new System.EventHandler(this.txtParola_TextChanged);
            // 
            // lblIntroducere
            // 
            this.lblIntroducere.AutoSize = true;
            this.lblIntroducere.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIntroducere.Location = new System.Drawing.Point(36, 10);
            this.lblIntroducere.Name = "lblIntroducere";
            this.lblIntroducere.Size = new System.Drawing.Size(55, 17);
            this.lblIntroducere.TabIndex = 0;
            this.lblIntroducere.Text = "Parola";
            // 
            // frmResetareAplicatie
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(484, 333);
            this.Controls.Add(this.panouActiuni);
            this.Controls.Add(this.panouAtentie);
            this.Controls.Add(this.mnuResetare);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.mnuResetare;
            this.Name = "frmResetareAplicatie";
            this.Text = "Resetare Aplicație";
            this.mnuResetare.ResumeLayout(false);
            this.mnuResetare.PerformLayout();
            this.panouAtentie.ResumeLayout(false);
            this.panouAtentie.PerformLayout();
            this.panouActiuni.ResumeLayout(false);
            this.panouActiuni.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mnuResetare;
        private System.Windows.Forms.ToolStripMenuItem btnIesire;
        private System.Windows.Forms.Panel panouAtentie;
        private System.Windows.Forms.Panel panouActiuni;
        private System.Windows.Forms.Label lblAtentie;
        private System.Windows.Forms.Label lblIntroducere;
        private System.Windows.Forms.TextBox txtParola;
        private System.Windows.Forms.Button btnResetare;
        private System.Windows.Forms.CheckBox chkDeAcord;
        private System.Windows.Forms.Label lblAtentionare1;
        private System.Windows.Forms.Label lblAtentionare2;
        private System.Windows.Forms.Label lblAtentionare3;
        private System.Windows.Forms.Label lblAtentionare4;
    }
}