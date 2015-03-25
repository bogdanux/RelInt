namespace RelInt___Gestiune_cereri_de_deplasare
{
    partial class frmCautareCerere
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
            this.mnuCerereCautare = new System.Windows.Forms.MenuStrip();
            this.btnIesire = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCerereCautare.SuspendLayout();
            this.SuspendLayout();
            // 
            // mnuCerereCautare
            // 
            this.mnuCerereCautare.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.mnuCerereCautare.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnIesire});
            this.mnuCerereCautare.Location = new System.Drawing.Point(0, 0);
            this.mnuCerereCautare.Name = "mnuCerereCautare";
            this.mnuCerereCautare.Size = new System.Drawing.Size(656, 24);
            this.mnuCerereCautare.TabIndex = 0;
            this.mnuCerereCautare.Text = "menuStrip1";
            // 
            // btnIesire
            // 
            this.btnIesire.Name = "btnIesire";
            this.btnIesire.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.W)));
            this.btnIesire.Size = new System.Drawing.Size(46, 20);
            this.btnIesire.Text = "I&eșire";
            this.btnIesire.Click += new System.EventHandler(this.btnIesire_Click);
            // 
            // frmCautareCerere
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(656, 315);
            this.Controls.Add(this.mnuCerereCautare);
            this.MainMenuStrip = this.mnuCerereCautare;
            this.Name = "frmCautareCerere";
            this.Text = "frmCautareCerere";
            this.mnuCerereCautare.ResumeLayout(false);
            this.mnuCerereCautare.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mnuCerereCautare;
        private System.Windows.Forms.ToolStripMenuItem btnIesire;
    }
}