namespace RelInt___Gestiune_cereri_de_deplasare
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGCD));
            this.mnuBaraMeniu = new System.Windows.Forms.MenuStrip();
            this.mnuOperatiuniFormulare = new System.Windows.Forms.ToolStripMenuItem();
            this.btnGCDIntroducereFormular = new System.Windows.Forms.ToolStripMenuItem();
            this.btnGCDCautareCerere = new System.Windows.Forms.ToolStripMenuItem();
            this.btnGCDModificareFormular = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnGCDIesire = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuOperatiuniEvidentaActivitate = new System.Windows.Forms.ToolStripMenuItem();
            this.btnGCDOrdineaDeZi = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuAjutor = new System.Windows.Forms.ToolStripMenuItem();
            this.btnGCDDespreApp = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnGCDRealizatori = new System.Windows.Forms.ToolStripMenuItem();
            this.StatusGCD = new System.Windows.Forms.StatusStrip();
            this.tsStatusUltimaInregistrare = new System.Windows.Forms.ToolStripStatusLabel();
            this.mnuBaraMeniu.SuspendLayout();
            this.StatusGCD.SuspendLayout();
            this.SuspendLayout();
            // 
            // mnuBaraMeniu
            // 
            this.mnuBaraMeniu.AutoSize = false;
            this.mnuBaraMeniu.BackColor = System.Drawing.SystemColors.Info;
            this.mnuBaraMeniu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuOperatiuniFormulare,
            this.mnuOperatiuniEvidentaActivitate,
            this.mnuAjutor});
            this.mnuBaraMeniu.Location = new System.Drawing.Point(0, 0);
            this.mnuBaraMeniu.Name = "mnuBaraMeniu";
            this.mnuBaraMeniu.Size = new System.Drawing.Size(784, 30);
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
            this.btnGCDOrdineaDeZi.Click += new System.EventHandler(this.btnGCDOrdineaDeZi_Click);
            // 
            // mnuAjutor
            // 
            this.mnuAjutor.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnGCDDespreApp,
            this.toolStripSeparator2,
            this.btnGCDRealizatori});
            this.mnuAjutor.Name = "mnuAjutor";
            this.mnuAjutor.Size = new System.Drawing.Size(52, 26);
            this.mnuAjutor.Text = "Ajut&or";
            // 
            // btnGCDDespreApp
            // 
            this.btnGCDDespreApp.Name = "btnGCDDespreApp";
            this.btnGCDDespreApp.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.D)));
            this.btnGCDDespreApp.Size = new System.Drawing.Size(259, 22);
            this.btnGCDDespreApp.Text = "&Despre RelInt - GCdD";
            this.btnGCDDespreApp.Click += new System.EventHandler(this.btnGCDDespreApp_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(256, 6);
            // 
            // btnGCDRealizatori
            // 
            this.btnGCDRealizatori.Name = "btnGCDRealizatori";
            this.btnGCDRealizatori.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.R)));
            this.btnGCDRealizatori.Size = new System.Drawing.Size(259, 22);
            this.btnGCDRealizatori.Text = "&Realizatori";
            this.btnGCDRealizatori.Click += new System.EventHandler(this.btnGCDRealizatori_Click);
            // 
            // StatusGCD
            // 
            this.StatusGCD.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsStatusUltimaInregistrare});
            this.StatusGCD.Location = new System.Drawing.Point(0, 439);
            this.StatusGCD.Name = "StatusGCD";
            this.StatusGCD.Size = new System.Drawing.Size(784, 22);
            this.StatusGCD.TabIndex = 5;
            this.StatusGCD.Text = "statusStrip1";
            // 
            // tsStatusUltimaInregistrare
            // 
            this.tsStatusUltimaInregistrare.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.tsStatusUltimaInregistrare.ForeColor = System.Drawing.Color.Green;
            this.tsStatusUltimaInregistrare.Name = "tsStatusUltimaInregistrare";
            this.tsStatusUltimaInregistrare.Size = new System.Drawing.Size(0, 17);
            // 
            // frmGCD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::RelInt___Gestiune_cereri_de_deplasare.Properties.Resources.UAIC_logo_bw_1024;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(784, 461);
            this.Controls.Add(this.StatusGCD);
            this.Controls.Add(this.mnuBaraMeniu);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.Name = "frmGCD";
            this.Text = "Gestiune Cereri de Deplasare";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Activated += new System.EventHandler(this.frmGCD_Activated);
            this.mnuBaraMeniu.ResumeLayout(false);
            this.mnuBaraMeniu.PerformLayout();
            this.StatusGCD.ResumeLayout(false);
            this.StatusGCD.PerformLayout();
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
        private System.Windows.Forms.StatusStrip StatusGCD;
        private System.Windows.Forms.ToolStripStatusLabel tsStatusUltimaInregistrare;
        private System.Windows.Forms.ToolStripMenuItem mnuOperatiuniEvidentaActivitate;
        private System.Windows.Forms.ToolStripMenuItem btnGCDOrdineaDeZi;
        private System.Windows.Forms.ToolStripMenuItem mnuAjutor;
        private System.Windows.Forms.ToolStripMenuItem btnGCDDespreApp;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem btnGCDRealizatori;
    }
}

