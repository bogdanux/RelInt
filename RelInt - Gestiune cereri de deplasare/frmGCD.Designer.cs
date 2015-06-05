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
            this.btnGCDIntroducereODD = new System.Windows.Forms.ToolStripMenuItem();
            this.btnGCDModificareODD = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.btnGCDODZ = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.btnGCDListaCereriExistente = new System.Windows.Forms.ToolStripMenuItem();
            this.btnGCDListaOrdineDeDeplasare = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuRapoarte = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSetari = new System.Windows.Forms.ToolStripMenuItem();
            this.btnGCDTipIntrari = new System.Windows.Forms.ToolStripMenuItem();
            this.btnGCDEditareRectori = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuAjutor = new System.Windows.Forms.ToolStripMenuItem();
            this.btnManualUtilizare = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnGCDRealizatori = new System.Windows.Forms.ToolStripMenuItem();
            this.btnGCDDespreApp = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.btnGCDAsistenta = new System.Windows.Forms.ToolStripMenuItem();
            this.btnResetare = new System.Windows.Forms.ToolStripMenuItem();
            this.btnCopieSiguranta = new System.Windows.Forms.ToolStripMenuItem();
            this.StatusGCD = new System.Windows.Forms.StatusStrip();
            this.tsStatusRectorCurent = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsStatusDFCCurent = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsStatusUltimaInregistrare = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsStatusDeCeGD = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsStatusDeCeF = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsStatusDeCeM = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsStatusDeCeT = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsStatusDeCeS = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsStatusDeCeR = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsStatusDeCePR = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsStatusDeCeD = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsStatusDeCeC = new System.Windows.Forms.ToolStripStatusLabel();
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
            this.mnuRapoarte,
            this.mnuSetari,
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
            this.btnGCDIntroducereFormular.Size = new System.Drawing.Size(237, 22);
            this.btnGCDIntroducereFormular.Text = "&Introducere Cerere";
            this.btnGCDIntroducereFormular.Click += new System.EventHandler(this.btnGCDIntroducereFormular_Click);
            // 
            // btnGCDCautareCerere
            // 
            this.btnGCDCautareCerere.Name = "btnGCDCautareCerere";
            this.btnGCDCautareCerere.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F)));
            this.btnGCDCautareCerere.Size = new System.Drawing.Size(237, 22);
            this.btnGCDCautareCerere.Text = "&Căutare Cerere";
            this.btnGCDCautareCerere.Click += new System.EventHandler(this.btnGCDcăutareCerere_Click);
            // 
            // btnGCDModificareFormular
            // 
            this.btnGCDModificareFormular.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnGCDModificareFormular.Name = "btnGCDModificareFormular";
            this.btnGCDModificareFormular.ShortcutKeyDisplayString = "";
            this.btnGCDModificareFormular.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.I)));
            this.btnGCDModificareFormular.Size = new System.Drawing.Size(237, 22);
            this.btnGCDModificareFormular.Text = "&Modificare Cerere";
            this.btnGCDModificareFormular.Click += new System.EventHandler(this.btnGCDModificareFormular_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(234, 6);
            // 
            // btnGCDIesire
            // 
            this.btnGCDIesire.Name = "btnGCDIesire";
            this.btnGCDIesire.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Q)));
            this.btnGCDIesire.Size = new System.Drawing.Size(237, 22);
            this.btnGCDIesire.Text = "I&esire";
            this.btnGCDIesire.Click += new System.EventHandler(this.mnuIesire_Click);
            // 
            // mnuOperatiuniEvidentaActivitate
            // 
            this.mnuOperatiuniEvidentaActivitate.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnGCDIntroducereODD,
            this.btnGCDModificareODD,
            this.toolStripSeparator4,
            this.btnGCDODZ,
            this.toolStripSeparator3,
            this.btnGCDListaCereriExistente,
            this.btnGCDListaOrdineDeDeplasare});
            this.mnuOperatiuniEvidentaActivitate.Name = "mnuOperatiuniEvidentaActivitate";
            this.mnuOperatiuniEvidentaActivitate.Size = new System.Drawing.Size(126, 26);
            this.mnuOperatiuniEvidentaActivitate.Text = "Evidența &activităților";
            // 
            // btnGCDIntroducereODD
            // 
            this.btnGCDIntroducereODD.Name = "btnGCDIntroducereODD";
            this.btnGCDIntroducereODD.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.B)));
            this.btnGCDIntroducereODD.Size = new System.Drawing.Size(325, 22);
            this.btnGCDIntroducereODD.Text = "Introducere Ordine de Deplasare";
            this.btnGCDIntroducereODD.Click += new System.EventHandler(this.btnGCDIntroducereODD_Click);
            // 
            // btnGCDModificareODD
            // 
            this.btnGCDModificareODD.Name = "btnGCDModificareODD";
            this.btnGCDModificareODD.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.B)));
            this.btnGCDModificareODD.Size = new System.Drawing.Size(325, 22);
            this.btnGCDModificareODD.Text = "Modificare Ordine de Deplasare";
            this.btnGCDModificareODD.Click += new System.EventHandler(this.btnGCDModificareODD_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(322, 6);
            // 
            // btnGCDODZ
            // 
            this.btnGCDODZ.Name = "btnGCDODZ";
            this.btnGCDODZ.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.E)));
            this.btnGCDODZ.Size = new System.Drawing.Size(325, 22);
            this.btnGCDODZ.Text = "Ordin&ea de zi";
            this.btnGCDODZ.Click += new System.EventHandler(this.btnGCDOrdineaDeZi_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(322, 6);
            // 
            // btnGCDListaCereriExistente
            // 
            this.btnGCDListaCereriExistente.Name = "btnGCDListaCereriExistente";
            this.btnGCDListaCereriExistente.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.L)));
            this.btnGCDListaCereriExistente.Size = new System.Drawing.Size(325, 22);
            this.btnGCDListaCereriExistente.Text = "&Lista cereri existente";
            this.btnGCDListaCereriExistente.Click += new System.EventHandler(this.btnGCDListaCereriExistente_Click);
            // 
            // btnGCDListaOrdineDeDeplasare
            // 
            this.btnGCDListaOrdineDeDeplasare.Name = "btnGCDListaOrdineDeDeplasare";
            this.btnGCDListaOrdineDeDeplasare.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.L)));
            this.btnGCDListaOrdineDeDeplasare.Size = new System.Drawing.Size(325, 22);
            this.btnGCDListaOrdineDeDeplasare.Text = "L&istă ordine de deplasare existente";
            this.btnGCDListaOrdineDeDeplasare.Click += new System.EventHandler(this.btnGCDListaOrdineDeDeplasare_Click);
            // 
            // mnuRapoarte
            // 
            this.mnuRapoarte.Name = "mnuRapoarte";
            this.mnuRapoarte.Size = new System.Drawing.Size(108, 26);
            this.mnuRapoarte.Text = "&Situație deplasări";
            this.mnuRapoarte.Click += new System.EventHandler(this.mnuRapoarte_Click);
            // 
            // mnuSetari
            // 
            this.mnuSetari.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnGCDTipIntrari,
            this.btnGCDEditareRectori});
            this.mnuSetari.Name = "mnuSetari";
            this.mnuSetari.Size = new System.Drawing.Size(79, 26);
            this.mnuSetari.Text = "&Configurări";
            // 
            // btnGCDTipIntrari
            // 
            this.btnGCDTipIntrari.Name = "btnGCDTipIntrari";
            this.btnGCDTipIntrari.ShortcutKeys = System.Windows.Forms.Keys.F4;
            this.btnGCDTipIntrari.Size = new System.Drawing.Size(229, 22);
            this.btnGCDTipIntrari.Text = "Editare tipuri de intrări";
            this.btnGCDTipIntrari.Click += new System.EventHandler(this.btnGCDTipIntrari_Click);
            // 
            // btnGCDEditareRectori
            // 
            this.btnGCDEditareRectori.Name = "btnGCDEditareRectori";
            this.btnGCDEditareRectori.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.btnGCDEditareRectori.Size = new System.Drawing.Size(229, 22);
            this.btnGCDEditareRectori.Text = "Editare rectori / prorectori";
            this.btnGCDEditareRectori.Click += new System.EventHandler(this.btnGCDEditareRectori_Click);
            // 
            // mnuAjutor
            // 
            this.mnuAjutor.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnManualUtilizare,
            this.toolStripSeparator2,
            this.btnGCDRealizatori,
            this.btnGCDDespreApp,
            this.toolStripSeparator5,
            this.btnGCDAsistenta});
            this.mnuAjutor.Name = "mnuAjutor";
            this.mnuAjutor.Size = new System.Drawing.Size(52, 26);
            this.mnuAjutor.Text = "Ajut&or";
            // 
            // btnManualUtilizare
            // 
            this.btnManualUtilizare.Name = "btnManualUtilizare";
            this.btnManualUtilizare.ShortcutKeys = System.Windows.Forms.Keys.F1;
            this.btnManualUtilizare.Size = new System.Drawing.Size(178, 22);
            this.btnManualUtilizare.Text = "Manual Utilizare";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(175, 6);
            // 
            // btnGCDRealizatori
            // 
            this.btnGCDRealizatori.Name = "btnGCDRealizatori";
            this.btnGCDRealizatori.ShortcutKeys = System.Windows.Forms.Keys.F2;
            this.btnGCDRealizatori.Size = new System.Drawing.Size(178, 22);
            this.btnGCDRealizatori.Text = "&Realizatori";
            this.btnGCDRealizatori.Click += new System.EventHandler(this.btnGCDRealizatori_Click);
            // 
            // btnGCDDespreApp
            // 
            this.btnGCDDespreApp.Name = "btnGCDDespreApp";
            this.btnGCDDespreApp.ShortcutKeys = System.Windows.Forms.Keys.F3;
            this.btnGCDDespreApp.Size = new System.Drawing.Size(178, 22);
            this.btnGCDDespreApp.Text = "&Despre";
            this.btnGCDDespreApp.Click += new System.EventHandler(this.btnGCDDespreApp_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(175, 6);
            // 
            // btnGCDAsistenta
            // 
            this.btnGCDAsistenta.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnResetare,
            this.btnCopieSiguranta});
            this.btnGCDAsistenta.Name = "btnGCDAsistenta";
            this.btnGCDAsistenta.Size = new System.Drawing.Size(178, 22);
            this.btnGCDAsistenta.Text = "&Asistență";
            // 
            // btnResetare
            // 
            this.btnResetare.Name = "btnResetare";
            this.btnResetare.ShortcutKeys = ((System.Windows.Forms.Keys)((((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Alt) 
            | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.Delete)));
            this.btnResetare.Size = new System.Drawing.Size(293, 22);
            this.btnResetare.Text = "Resetare bază de date";
            this.btnResetare.Click += new System.EventHandler(this.btnResetare_Click);
            // 
            // btnCopieSiguranta
            // 
            this.btnCopieSiguranta.Name = "btnCopieSiguranta";
            this.btnCopieSiguranta.ShortcutKeys = ((System.Windows.Forms.Keys)((((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Alt) 
            | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.C)));
            this.btnCopieSiguranta.Size = new System.Drawing.Size(293, 22);
            this.btnCopieSiguranta.Text = "Copie de siguranță";
            this.btnCopieSiguranta.Click += new System.EventHandler(this.btnCopieSiguranta_Click);
            // 
            // StatusGCD
            // 
            this.StatusGCD.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsStatusRectorCurent,
            this.tsStatusDFCCurent,
            this.tsStatusUltimaInregistrare,
            this.tsStatusDeCeGD,
            this.tsStatusDeCeF,
            this.tsStatusDeCeM,
            this.tsStatusDeCeT,
            this.tsStatusDeCeS,
            this.tsStatusDeCeR,
            this.tsStatusDeCePR,
            this.tsStatusDeCeC,
            this.tsStatusDeCeD});
            this.StatusGCD.Location = new System.Drawing.Point(0, 437);
            this.StatusGCD.Name = "StatusGCD";
            this.StatusGCD.Size = new System.Drawing.Size(784, 24);
            this.StatusGCD.TabIndex = 5;
            this.StatusGCD.Text = "statusStrip1";
            // 
            // tsStatusRectorCurent
            // 
            this.tsStatusRectorCurent.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.tsStatusRectorCurent.ForeColor = System.Drawing.Color.RoyalBlue;
            this.tsStatusRectorCurent.Name = "tsStatusRectorCurent";
            this.tsStatusRectorCurent.Size = new System.Drawing.Size(27, 19);
            this.tsStatusRectorCurent.Text = "RC";
            // 
            // tsStatusDFCCurent
            // 
            this.tsStatusDFCCurent.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.tsStatusDFCCurent.ForeColor = System.Drawing.Color.SaddleBrown;
            this.tsStatusDFCCurent.Name = "tsStatusDFCCurent";
            this.tsStatusDFCCurent.Size = new System.Drawing.Size(44, 19);
            this.tsStatusDFCCurent.Text = "DFCC";
            // 
            // tsStatusUltimaInregistrare
            // 
            this.tsStatusUltimaInregistrare.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.tsStatusUltimaInregistrare.ForeColor = System.Drawing.Color.Green;
            this.tsStatusUltimaInregistrare.Name = "tsStatusUltimaInregistrare";
            this.tsStatusUltimaInregistrare.Size = new System.Drawing.Size(23, 19);
            this.tsStatusUltimaInregistrare.Text = "UI";
            // 
            // tsStatusDeCeGD
            // 
            this.tsStatusDeCeGD.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.tsStatusDeCeGD.ForeColor = System.Drawing.Color.Purple;
            this.tsStatusDeCeGD.Name = "tsStatusDeCeGD";
            this.tsStatusDeCeGD.Size = new System.Drawing.Size(25, 19);
            this.tsStatusDeCeGD.Text = "GD";
            // 
            // tsStatusDeCeF
            // 
            this.tsStatusDeCeF.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.tsStatusDeCeF.ForeColor = System.Drawing.Color.Purple;
            this.tsStatusDeCeF.Name = "tsStatusDeCeF";
            this.tsStatusDeCeF.Size = new System.Drawing.Size(27, 19);
            this.tsStatusDeCeF.Text = "FAC";
            // 
            // tsStatusDeCeM
            // 
            this.tsStatusDeCeM.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.tsStatusDeCeM.ForeColor = System.Drawing.Color.Purple;
            this.tsStatusDeCeM.Name = "tsStatusDeCeM";
            this.tsStatusDeCeM.Size = new System.Drawing.Size(36, 19);
            this.tsStatusDeCeM.Text = "MON";
            // 
            // tsStatusDeCeT
            // 
            this.tsStatusDeCeT.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.tsStatusDeCeT.ForeColor = System.Drawing.Color.Purple;
            this.tsStatusDeCeT.Name = "tsStatusDeCeT";
            this.tsStatusDeCeT.Size = new System.Drawing.Size(33, 19);
            this.tsStatusDeCeT.Text = "TARI";
            // 
            // tsStatusDeCeS
            // 
            this.tsStatusDeCeS.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.tsStatusDeCeS.ForeColor = System.Drawing.Color.Purple;
            this.tsStatusDeCeS.Name = "tsStatusDeCeS";
            this.tsStatusDeCeS.Size = new System.Drawing.Size(37, 19);
            this.tsStatusDeCeS.Text = "SCOP";
            // 
            // tsStatusDeCeR
            // 
            this.tsStatusDeCeR.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.tsStatusDeCeR.ForeColor = System.Drawing.Color.Purple;
            this.tsStatusDeCeR.Name = "tsStatusDeCeR";
            this.tsStatusDeCeR.Size = new System.Drawing.Size(28, 19);
            this.tsStatusDeCeR.Text = "REC";
            // 
            // tsStatusDeCePR
            // 
            this.tsStatusDeCePR.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.tsStatusDeCePR.ForeColor = System.Drawing.Color.Purple;
            this.tsStatusDeCePR.Name = "tsStatusDeCePR";
            this.tsStatusDeCePR.Size = new System.Drawing.Size(52, 19);
            this.tsStatusDeCePR.Text = "PROREC";
            // 
            // tsStatusDeCeD
            // 
            this.tsStatusDeCeD.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.tsStatusDeCeD.ForeColor = System.Drawing.Color.Purple;
            this.tsStatusDeCeD.Name = "tsStatusDeCeD";
            this.tsStatusDeCeD.Size = new System.Drawing.Size(29, 19);
            this.tsStatusDeCeD.Text = "DFC";
            // 
            // tsStatusDeCeC
            // 
            this.tsStatusDeCeC.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.tsStatusDeCeC.ForeColor = System.Drawing.Color.Purple;
            this.tsStatusDeCeC.Name = "tsStatusDeCeC";
            this.tsStatusDeCeC.Size = new System.Drawing.Size(30, 19);
            this.tsStatusDeCeC.Text = "COS";
            // 
            // frmGCD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FloralWhite;
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
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmGCD_FormClosing);
            this.Load += new System.EventHandler(this.frmGCD_Load);
            this.mnuBaraMeniu.ResumeLayout(false);
            this.mnuBaraMeniu.PerformLayout();
            this.StatusGCD.ResumeLayout(false);
            this.StatusGCD.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStripMenuItem mnuOperatiuniFormulare;
        private System.Windows.Forms.MenuStrip mnuBaraMeniu;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem btnGCDIesire;
        private System.Windows.Forms.ToolStripMenuItem btnGCDCautareCerere;
        private System.Windows.Forms.StatusStrip StatusGCD;
        private System.Windows.Forms.ToolStripMenuItem mnuOperatiuniEvidentaActivitate;
        private System.Windows.Forms.ToolStripMenuItem btnGCDODZ;
        private System.Windows.Forms.ToolStripMenuItem mnuAjutor;
        private System.Windows.Forms.ToolStripMenuItem btnGCDDespreApp;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem btnGCDRealizatori;
        public System.Windows.Forms.ToolStripStatusLabel tsStatusUltimaInregistrare;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem btnGCDListaCereriExistente;
        private System.Windows.Forms.ToolStripMenuItem mnuRapoarte;
        private System.Windows.Forms.ToolStripMenuItem btnGCDIntroducereODD;
        private System.Windows.Forms.ToolStripMenuItem mnuSetari;
        private System.Windows.Forms.ToolStripMenuItem btnGCDTipIntrari;
        private System.Windows.Forms.ToolStripMenuItem btnManualUtilizare;
        public System.Windows.Forms.ToolStripMenuItem btnGCDIntroducereFormular;
        public System.Windows.Forms.ToolStripMenuItem btnGCDModificareFormular;
        private System.Windows.Forms.ToolStripMenuItem btnGCDModificareODD;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem btnGCDEditareRectori;
        private System.Windows.Forms.ToolStripMenuItem btnGCDAsistenta;
        private System.Windows.Forms.ToolStripMenuItem btnResetare;
        private System.Windows.Forms.ToolStripMenuItem btnCopieSiguranta;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem btnGCDListaOrdineDeDeplasare;
        private System.Windows.Forms.ToolStripStatusLabel tsStatusDeCeGD;
        private System.Windows.Forms.ToolStripStatusLabel tsStatusDeCeF;
        private System.Windows.Forms.ToolStripStatusLabel tsStatusDeCeM;
        private System.Windows.Forms.ToolStripStatusLabel tsStatusDeCeT;
        private System.Windows.Forms.ToolStripStatusLabel tsStatusDeCeS;
        private System.Windows.Forms.ToolStripStatusLabel tsStatusDeCeR;
        private System.Windows.Forms.ToolStripStatusLabel tsStatusDeCePR;
        public System.Windows.Forms.ToolStripStatusLabel tsStatusRectorCurent;
        private System.Windows.Forms.ToolStripStatusLabel tsStatusDeCeD;
        public System.Windows.Forms.ToolStripStatusLabel tsStatusDFCCurent;
        private System.Windows.Forms.ToolStripStatusLabel tsStatusDeCeC;
    }
}

