namespace RelInt___Gestiune_cereri_de_deplasare
{
    partial class frmCerereModificare
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
            this.mnuCM = new System.Windows.Forms.MenuStrip();
            this.btnCMFormular = new System.Windows.Forms.ToolStripMenuItem();
            this.btnCMSalvareFormular = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnCMIesire = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCM.SuspendLayout();
            this.SuspendLayout();
            // 
            // mnuCM
            // 
            this.mnuCM.AutoSize = false;
            this.mnuCM.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnCMFormular});
            this.mnuCM.Location = new System.Drawing.Point(0, 0);
            this.mnuCM.Name = "mnuCM";
            this.mnuCM.Size = new System.Drawing.Size(643, 30);
            this.mnuCM.TabIndex = 0;
            this.mnuCM.Text = "mnuCM";
            // 
            // btnCMFormular
            // 
            this.btnCMFormular.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnCMSalvareFormular,
            this.toolStripSeparator1,
            this.btnCMIesire});
            this.btnCMFormular.Name = "btnCMFormular";
            this.btnCMFormular.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.F)));
            this.btnCMFormular.Size = new System.Drawing.Size(67, 26);
            this.btnCMFormular.Text = "&Formular";
            // 
            // btnCMSalvareFormular
            // 
            this.btnCMSalvareFormular.Name = "btnCMSalvareFormular";
            this.btnCMSalvareFormular.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.btnCMSalvareFormular.Size = new System.Drawing.Size(202, 22);
            this.btnCMSalvareFormular.Text = "&Salvare Formular";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(199, 6);
            // 
            // btnCMIesire
            // 
            this.btnCMIesire.Name = "btnCMIesire";
            this.btnCMIesire.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.W)));
            this.btnCMIesire.Size = new System.Drawing.Size(202, 22);
            this.btnCMIesire.Text = "I&esire";
            this.btnCMIesire.Click += new System.EventHandler(this.btnCMIesire_Click);
            // 
            // frmCerereModificare
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(643, 234);
            this.Controls.Add(this.mnuCM);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.mnuCM;
            this.Name = "frmCerereModificare";
            this.Text = "Modificare Cerere de Deplasare";
            this.mnuCM.ResumeLayout(false);
            this.mnuCM.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.MenuStrip mnuCM;
        private System.Windows.Forms.ToolStripMenuItem btnCMFormular;
        private System.Windows.Forms.ToolStripMenuItem btnCMSalvareFormular;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem btnCMIesire;


    }
}