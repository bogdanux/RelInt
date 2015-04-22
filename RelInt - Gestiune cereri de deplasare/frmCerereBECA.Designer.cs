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
            this.menuStrip1.SuspendLayout();
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
            // frmCerereBECA
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(699, 661);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmCerereBECA";
            this.Text = "Cerere BECA";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem btnIesire;
        private System.Windows.Forms.ToolStripMenuItem btnGenerare;
    }
}