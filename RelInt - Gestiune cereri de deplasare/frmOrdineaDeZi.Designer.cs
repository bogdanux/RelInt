namespace RelInt___Gestiune_cereri_de_deplasare
{
    partial class frmOrdineaDeZi
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmOrdineaDeZi));
            this.mnuODZ = new System.Windows.Forms.MenuStrip();
            this.btnIesire = new System.Windows.Forms.ToolStripMenuItem();
            this.btnGenerarePDF = new System.Windows.Forms.ToolStripMenuItem();
            this.dgvObiecteOrdineZi = new System.Windows.Forms.DataGridView();
            this.mnuODZ.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvObiecteOrdineZi)).BeginInit();
            this.SuspendLayout();
            // 
            // mnuODZ
            // 
            this.mnuODZ.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.mnuODZ.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnIesire,
            this.btnGenerarePDF});
            this.mnuODZ.Location = new System.Drawing.Point(0, 0);
            this.mnuODZ.Name = "mnuODZ";
            this.mnuODZ.Size = new System.Drawing.Size(884, 24);
            this.mnuODZ.TabIndex = 0;
            this.mnuODZ.Text = "menuStrip1";
            // 
            // btnIesire
            // 
            this.btnIesire.Name = "btnIesire";
            this.btnIesire.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.W)));
            this.btnIesire.Size = new System.Drawing.Size(46, 20);
            this.btnIesire.Text = "I&eșire";
            this.btnIesire.Click += new System.EventHandler(this.btnIesire_Click);
            // 
            // btnGenerarePDF
            // 
            this.btnGenerarePDF.Name = "btnGenerarePDF";
            this.btnGenerarePDF.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P)));
            this.btnGenerarePDF.Size = new System.Drawing.Size(90, 20);
            this.btnGenerarePDF.Text = "&Generare PDF";
            this.btnGenerarePDF.Click += new System.EventHandler(this.btnGenerarePDF_Click);
            // 
            // dgvObiecteOrdineZi
            // 
            this.dgvObiecteOrdineZi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvObiecteOrdineZi.Location = new System.Drawing.Point(13, 40);
            this.dgvObiecteOrdineZi.Name = "dgvObiecteOrdineZi";
            this.dgvObiecteOrdineZi.Size = new System.Drawing.Size(859, 358);
            this.dgvObiecteOrdineZi.TabIndex = 2;
            // 
            // frmOrdineaDeZi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 411);
            this.Controls.Add(this.dgvObiecteOrdineZi);
            this.Controls.Add(this.mnuODZ);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.mnuODZ;
            this.Name = "frmOrdineaDeZi";
            this.Text = "frmOrdineaDeZi";
            this.mnuODZ.ResumeLayout(false);
            this.mnuODZ.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvObiecteOrdineZi)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mnuODZ;
        private System.Windows.Forms.ToolStripMenuItem btnIesire;
        private System.Windows.Forms.ToolStripMenuItem btnGenerarePDF;
        private System.Windows.Forms.DataGridView dgvObiecteOrdineZi;
    }
}