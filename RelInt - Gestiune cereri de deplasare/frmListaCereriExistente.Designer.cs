namespace RelInt___Gestiune_cereri_de_deplasare
{
    partial class frmListaCereriExistente
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmListaCereriExistente));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.btnIesire = new System.Windows.Forms.ToolStripMenuItem();
            this.dgvVizualizareTot = new System.Windows.Forms.DataGridView();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVizualizareTot)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnIesire});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1184, 24);
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
            // dgvVizualizareTot
            // 
            this.dgvVizualizareTot.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVizualizareTot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvVizualizareTot.Location = new System.Drawing.Point(0, 24);
            this.dgvVizualizareTot.Name = "dgvVizualizareTot";
            this.dgvVizualizareTot.Size = new System.Drawing.Size(1184, 437);
            this.dgvVizualizareTot.TabIndex = 1;
            // 
            // frmVizualizareTot
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 461);
            this.Controls.Add(this.dgvVizualizareTot);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmVizualizareTot";
            this.Text = "Lista Cereri Existente";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVizualizareTot)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem btnIesire;
        private System.Windows.Forms.DataGridView dgvVizualizareTot;
    }
}