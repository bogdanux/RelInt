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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCautareCerere));
            this.mnuCerereCautare = new System.Windows.Forms.MenuStrip();
            this.btnIesire = new System.Windows.Forms.ToolStripMenuItem();
            this.dgvCautare = new System.Windows.Forms.DataGridView();
            this.txtNumePren = new System.Windows.Forms.TextBox();
            this.lblNumePren = new System.Windows.Forms.Label();
            this.mnuCerereCautare.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCautare)).BeginInit();
            this.SuspendLayout();
            // 
            // mnuCerereCautare
            // 
            this.mnuCerereCautare.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.mnuCerereCautare.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnIesire});
            this.mnuCerereCautare.Location = new System.Drawing.Point(0, 0);
            this.mnuCerereCautare.Name = "mnuCerereCautare";
            this.mnuCerereCautare.Size = new System.Drawing.Size(884, 24);
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
            // dgvCautare
            // 
            this.dgvCautare.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCautare.Location = new System.Drawing.Point(13, 93);
            this.dgvCautare.Name = "dgvCautare";
            this.dgvCautare.ReadOnly = true;
            this.dgvCautare.Size = new System.Drawing.Size(859, 338);
            this.dgvCautare.TabIndex = 1;
            // 
            // txtNumePren
            // 
            this.txtNumePren.Location = new System.Drawing.Point(13, 67);
            this.txtNumePren.Name = "txtNumePren";
            this.txtNumePren.Size = new System.Drawing.Size(180, 20);
            this.txtNumePren.TabIndex = 2;
            this.txtNumePren.TextChanged += new System.EventHandler(this.txtNumePren_TextChanged);
            // 
            // lblNumePren
            // 
            this.lblNumePren.AutoSize = true;
            this.lblNumePren.Location = new System.Drawing.Point(11, 51);
            this.lblNumePren.Name = "lblNumePren";
            this.lblNumePren.Size = new System.Drawing.Size(80, 13);
            this.lblNumePren.TabIndex = 3;
            this.lblNumePren.Text = "Nume Prenume";
            // 
            // frmCautareCerere
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 445);
            this.Controls.Add(this.lblNumePren);
            this.Controls.Add(this.txtNumePren);
            this.Controls.Add(this.dgvCautare);
            this.Controls.Add(this.mnuCerereCautare);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.mnuCerereCautare;
            this.Name = "frmCautareCerere";
            this.Text = "Căutare Cerere";
            this.mnuCerereCautare.ResumeLayout(false);
            this.mnuCerereCautare.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCautare)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mnuCerereCautare;
        private System.Windows.Forms.ToolStripMenuItem btnIesire;
        private System.Windows.Forms.DataGridView dgvCautare;
        private System.Windows.Forms.TextBox txtNumePren;
        private System.Windows.Forms.Label lblNumePren;
    }
}