﻿namespace RelInt___Gestiune_cereri_de_deplasare
{
    partial class frmGCD
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
            this.mnuBaraMeniu = new System.Windows.Forms.MenuStrip();
            this.mnuOperatiuniFormulare = new System.Windows.Forms.ToolStripMenuItem();
            this.btnGCDIntroducereFormular = new System.Windows.Forms.ToolStripMenuItem();
            this.btnGCDCautareCerere = new System.Windows.Forms.ToolStripMenuItem();
            this.btnGCDModificareFormular = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnGCDIesire = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tsStatusUltimaInregistrare = new System.Windows.Forms.ToolStripStatusLabel();
            this.mnuOperatiuniEvidentaActivitate = new System.Windows.Forms.ToolStripMenuItem();
            this.btnGCDOrdineaDeZi = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuBaraMeniu.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // mnuBaraMeniu
            // 
            this.mnuBaraMeniu.AutoSize = false;
            this.mnuBaraMeniu.BackColor = System.Drawing.SystemColors.Info;
            this.mnuBaraMeniu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuOperatiuniFormulare,
            this.mnuOperatiuniEvidentaActivitate});
            this.mnuBaraMeniu.Location = new System.Drawing.Point(0, 0);
            this.mnuBaraMeniu.Name = "mnuBaraMeniu";
            this.mnuBaraMeniu.Size = new System.Drawing.Size(745, 30);
            this.mnuBaraMeniu.TabIndex = 3;
            this.mnuBaraMeniu.Text = "mnuBaraMeniu";
            // 
            // mnuOperatiuniFormulare
            // 
            this.mnuOperatiuniFormulare.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnGCDIntroducereFormular,
            this.btnGCDCautareCerere,
            this.btnGCDModificareFormular,
            this.toolStripSeparator1,
            this.btnGCDIesire});
            this.mnuOperatiuniFormulare.Name = "mnuOperatiuniFormulare";
            this.mnuOperatiuniFormulare.Size = new System.Drawing.Size(146, 26);
            this.mnuOperatiuniFormulare.Text = "Operațiuni cu &formulare";
            // 
            // btnGCDIntroducereFormular
            // 
            this.btnGCDIntroducereFormular.Name = "btnGCDIntroducereFormular";
            this.btnGCDIntroducereFormular.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.I)));
            this.btnGCDIntroducereFormular.Size = new System.Drawing.Size(223, 22);
            this.btnGCDIntroducereFormular.Text = "Formular &Introducere";
            this.btnGCDIntroducereFormular.Click += new System.EventHandler(this.btnGCDIntroducereFormular_Click);
            // 
            // btnGCDCautareCerere
            // 
            this.btnGCDCautareCerere.Name = "btnGCDCautareCerere";
            this.btnGCDCautareCerere.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F)));
            this.btnGCDCautareCerere.Size = new System.Drawing.Size(223, 22);
            this.btnGCDCautareCerere.Text = "&Căutare Cerere";
            this.btnGCDCautareCerere.Click += new System.EventHandler(this.btnGCDcăutareCerere_Click);
            // 
            // btnGCDModificareFormular
            // 
            this.btnGCDModificareFormular.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnGCDModificareFormular.Name = "btnGCDModificareFormular";
            this.btnGCDModificareFormular.ShortcutKeyDisplayString = "";
            this.btnGCDModificareFormular.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.M)));
            this.btnGCDModificareFormular.Size = new System.Drawing.Size(223, 22);
            this.btnGCDModificareFormular.Text = "&Modificare Cerere";
            this.btnGCDModificareFormular.Click += new System.EventHandler(this.btnGCDModificareFormular_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(220, 6);
            // 
            // btnGCDIesire
            // 
            this.btnGCDIesire.Name = "btnGCDIesire";
            this.btnGCDIesire.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Q)));
            this.btnGCDIesire.Size = new System.Drawing.Size(223, 22);
            this.btnGCDIesire.Text = "I&esire";
            this.btnGCDIesire.Click += new System.EventHandler(this.mnuIesire_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsStatusUltimaInregistrare});
            this.statusStrip1.Location = new System.Drawing.Point(0, 376);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(745, 22);
            this.statusStrip1.TabIndex = 5;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tsStatusUltimaInregistrare
            // 
            this.tsStatusUltimaInregistrare.Enabled = false;
            this.tsStatusUltimaInregistrare.Name = "tsStatusUltimaInregistrare";
            this.tsStatusUltimaInregistrare.Size = new System.Drawing.Size(39, 17);
            this.tsStatusUltimaInregistrare.Text = "blabla";
            // 
            // mnuOperatiuniEvidentaActivitate
            // 
            this.mnuOperatiuniEvidentaActivitate.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnGCDOrdineaDeZi});
            this.mnuOperatiuniEvidentaActivitate.Name = "mnuOperatiuniEvidentaActivitate";
            this.mnuOperatiuniEvidentaActivitate.Size = new System.Drawing.Size(126, 26);
            this.mnuOperatiuniEvidentaActivitate.Text = "Evidența &activităților";
            // 
            // btnGCDOrdineaDeZi
            // 
            this.btnGCDOrdineaDeZi.Name = "btnGCDOrdineaDeZi";
            this.btnGCDOrdineaDeZi.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.E)));
            this.btnGCDOrdineaDeZi.Size = new System.Drawing.Size(183, 22);
            this.btnGCDOrdineaDeZi.Text = "Ordin&ea de zi";
            // 
            // frmGCD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(745, 398);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.mnuBaraMeniu);
            this.IsMdiContainer = true;
            this.Name = "frmGCD";
            this.Text = "Gestiune Cereri de Deplasare";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.mnuBaraMeniu.ResumeLayout(false);
            this.mnuBaraMeniu.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStripMenuItem mnuOperatiuniFormulare;
        private System.Windows.Forms.ToolStripMenuItem btnGCDIntroducereFormular;
        private System.Windows.Forms.ToolStripMenuItem btnGCDModificareFormular;
        private System.Windows.Forms.MenuStrip mnuBaraMeniu;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem btnGCDIesire;
        private System.Windows.Forms.ToolStripMenuItem btnGCDCautareCerere;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tsStatusUltimaInregistrare;
        private System.Windows.Forms.ToolStripMenuItem mnuOperatiuniEvidentaActivitate;
        private System.Windows.Forms.ToolStripMenuItem btnGCDOrdineaDeZi;
    }
}

