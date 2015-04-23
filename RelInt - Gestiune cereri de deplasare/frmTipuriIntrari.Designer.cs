namespace RelInt___Gestiune_cereri_de_deplasare
{
    partial class frmTipuriIntrari
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTipuriIntrari));
            this.mnuTipuriIntrari = new System.Windows.Forms.MenuStrip();
            this.btnIesire = new System.Windows.Forms.ToolStripMenuItem();
            this.tabGradDidactic = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.dgvGradDidactic = new System.Windows.Forms.DataGridView();
            this.btnStergereGD = new System.Windows.Forms.Button();
            this.btnIntroducereGD = new System.Windows.Forms.Button();
            this.txtGradDidactic = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnStergereF = new System.Windows.Forms.Button();
            this.btnIntroducereF = new System.Windows.Forms.Button();
            this.txtFacultate = new System.Windows.Forms.TextBox();
            this.dgvFacultate = new System.Windows.Forms.DataGridView();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.btnStergereM = new System.Windows.Forms.Button();
            this.btnIntroducereM = new System.Windows.Forms.Button();
            this.txtMoneda = new System.Windows.Forms.TextBox();
            this.dgvMoneda = new System.Windows.Forms.DataGridView();
            this.mnuTipuriIntrari.SuspendLayout();
            this.tabGradDidactic.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGradDidactic)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFacultate)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMoneda)).BeginInit();
            this.SuspendLayout();
            // 
            // mnuTipuriIntrari
            // 
            this.mnuTipuriIntrari.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.mnuTipuriIntrari.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnIesire});
            this.mnuTipuriIntrari.Location = new System.Drawing.Point(0, 0);
            this.mnuTipuriIntrari.Name = "mnuTipuriIntrari";
            this.mnuTipuriIntrari.Size = new System.Drawing.Size(398, 24);
            this.mnuTipuriIntrari.TabIndex = 0;
            this.mnuTipuriIntrari.Text = "menuStrip1";
            // 
            // btnIesire
            // 
            this.btnIesire.Name = "btnIesire";
            this.btnIesire.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.W)));
            this.btnIesire.Size = new System.Drawing.Size(46, 20);
            this.btnIesire.Text = "I&eșire";
            this.btnIesire.Click += new System.EventHandler(this.btnIesire_Click);
            // 
            // tabGradDidactic
            // 
            this.tabGradDidactic.Controls.Add(this.tabPage1);
            this.tabGradDidactic.Controls.Add(this.tabPage2);
            this.tabGradDidactic.Controls.Add(this.tabPage3);
            this.tabGradDidactic.Location = new System.Drawing.Point(3, 27);
            this.tabGradDidactic.Name = "tabGradDidactic";
            this.tabGradDidactic.SelectedIndex = 0;
            this.tabGradDidactic.Size = new System.Drawing.Size(394, 480);
            this.tabGradDidactic.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dgvGradDidactic);
            this.tabPage1.Controls.Add(this.btnStergereGD);
            this.tabPage1.Controls.Add(this.btnIntroducereGD);
            this.tabPage1.Controls.Add(this.txtGradDidactic);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(386, 454);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Grade didactice";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // dgvGradDidactic
            // 
            this.dgvGradDidactic.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGradDidactic.Location = new System.Drawing.Point(3, 3);
            this.dgvGradDidactic.Name = "dgvGradDidactic";
            this.dgvGradDidactic.ReadOnly = true;
            this.dgvGradDidactic.Size = new System.Drawing.Size(380, 415);
            this.dgvGradDidactic.TabIndex = 3;
            // 
            // btnStergereGD
            // 
            this.btnStergereGD.Location = new System.Drawing.Point(193, 424);
            this.btnStergereGD.Name = "btnStergereGD";
            this.btnStergereGD.Size = new System.Drawing.Size(75, 23);
            this.btnStergereGD.TabIndex = 2;
            this.btnStergereGD.Text = "Ștergere";
            this.btnStergereGD.UseVisualStyleBackColor = true;
            this.btnStergereGD.Click += new System.EventHandler(this.btnStergereGD_Click);
            // 
            // btnIntroducereGD
            // 
            this.btnIntroducereGD.Location = new System.Drawing.Point(112, 424);
            this.btnIntroducereGD.Name = "btnIntroducereGD";
            this.btnIntroducereGD.Size = new System.Drawing.Size(75, 23);
            this.btnIntroducereGD.TabIndex = 1;
            this.btnIntroducereGD.Text = "Introducere";
            this.btnIntroducereGD.UseVisualStyleBackColor = true;
            this.btnIntroducereGD.Click += new System.EventHandler(this.btnIntroducereGD_Click);
            // 
            // txtGradDidactic
            // 
            this.txtGradDidactic.Location = new System.Drawing.Point(3, 426);
            this.txtGradDidactic.Name = "txtGradDidactic";
            this.txtGradDidactic.Size = new System.Drawing.Size(100, 20);
            this.txtGradDidactic.TabIndex = 0;
            this.txtGradDidactic.TextChanged += new System.EventHandler(this.txtGradDidactic_TextChanged);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.btnStergereF);
            this.tabPage2.Controls.Add(this.btnIntroducereF);
            this.tabPage2.Controls.Add(this.txtFacultate);
            this.tabPage2.Controls.Add(this.dgvFacultate);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(386, 454);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Facultăți";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btnStergereF
            // 
            this.btnStergereF.Location = new System.Drawing.Point(193, 424);
            this.btnStergereF.Name = "btnStergereF";
            this.btnStergereF.Size = new System.Drawing.Size(75, 23);
            this.btnStergereF.TabIndex = 5;
            this.btnStergereF.Text = "Ștergere";
            this.btnStergereF.UseVisualStyleBackColor = true;
            this.btnStergereF.Click += new System.EventHandler(this.btnStergereF_Click);
            // 
            // btnIntroducereF
            // 
            this.btnIntroducereF.Location = new System.Drawing.Point(112, 424);
            this.btnIntroducereF.Name = "btnIntroducereF";
            this.btnIntroducereF.Size = new System.Drawing.Size(75, 23);
            this.btnIntroducereF.TabIndex = 4;
            this.btnIntroducereF.Text = "Introducere";
            this.btnIntroducereF.UseVisualStyleBackColor = true;
            this.btnIntroducereF.Click += new System.EventHandler(this.btnIntroducereF_Click);
            // 
            // txtFacultate
            // 
            this.txtFacultate.Location = new System.Drawing.Point(3, 426);
            this.txtFacultate.Name = "txtFacultate";
            this.txtFacultate.Size = new System.Drawing.Size(100, 20);
            this.txtFacultate.TabIndex = 3;
            this.txtFacultate.TextChanged += new System.EventHandler(this.txtFacultate_TextChanged);
            // 
            // dgvFacultate
            // 
            this.dgvFacultate.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFacultate.Location = new System.Drawing.Point(3, 3);
            this.dgvFacultate.Name = "dgvFacultate";
            this.dgvFacultate.ReadOnly = true;
            this.dgvFacultate.Size = new System.Drawing.Size(380, 415);
            this.dgvFacultate.TabIndex = 0;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.btnStergereM);
            this.tabPage3.Controls.Add(this.btnIntroducereM);
            this.tabPage3.Controls.Add(this.txtMoneda);
            this.tabPage3.Controls.Add(this.dgvMoneda);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(386, 454);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Monezi";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // btnStergereM
            // 
            this.btnStergereM.Location = new System.Drawing.Point(193, 424);
            this.btnStergereM.Name = "btnStergereM";
            this.btnStergereM.Size = new System.Drawing.Size(75, 23);
            this.btnStergereM.TabIndex = 8;
            this.btnStergereM.Text = "Ștergere";
            this.btnStergereM.UseVisualStyleBackColor = true;
            this.btnStergereM.Click += new System.EventHandler(this.btnStergereM_Click);
            // 
            // btnIntroducereM
            // 
            this.btnIntroducereM.Location = new System.Drawing.Point(112, 424);
            this.btnIntroducereM.Name = "btnIntroducereM";
            this.btnIntroducereM.Size = new System.Drawing.Size(75, 23);
            this.btnIntroducereM.TabIndex = 7;
            this.btnIntroducereM.Text = "Introducere";
            this.btnIntroducereM.UseVisualStyleBackColor = true;
            this.btnIntroducereM.Click += new System.EventHandler(this.btnIntroducereM_Click);
            // 
            // txtMoneda
            // 
            this.txtMoneda.Location = new System.Drawing.Point(3, 426);
            this.txtMoneda.Name = "txtMoneda";
            this.txtMoneda.Size = new System.Drawing.Size(100, 20);
            this.txtMoneda.TabIndex = 6;
            this.txtMoneda.TextChanged += new System.EventHandler(this.txtMoneda_TextChanged);
            // 
            // dgvMoneda
            // 
            this.dgvMoneda.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMoneda.Location = new System.Drawing.Point(3, 3);
            this.dgvMoneda.Name = "dgvMoneda";
            this.dgvMoneda.ReadOnly = true;
            this.dgvMoneda.Size = new System.Drawing.Size(380, 415);
            this.dgvMoneda.TabIndex = 0;
            // 
            // frmTipuriIntrari
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(398, 508);
            this.Controls.Add(this.tabGradDidactic);
            this.Controls.Add(this.mnuTipuriIntrari);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.mnuTipuriIntrari;
            this.Name = "frmTipuriIntrari";
            this.Text = "Tipuri Intrări";
            this.mnuTipuriIntrari.ResumeLayout(false);
            this.mnuTipuriIntrari.PerformLayout();
            this.tabGradDidactic.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGradDidactic)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFacultate)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMoneda)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mnuTipuriIntrari;
        private System.Windows.Forms.ToolStripMenuItem btnIesire;
        private System.Windows.Forms.TabControl tabGradDidactic;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Button btnIntroducereGD;
        private System.Windows.Forms.TextBox txtGradDidactic;
        private System.Windows.Forms.Button btnStergereGD;
        private System.Windows.Forms.DataGridView dgvGradDidactic;
        private System.Windows.Forms.DataGridView dgvFacultate;
        private System.Windows.Forms.Button btnStergereF;
        private System.Windows.Forms.Button btnIntroducereF;
        private System.Windows.Forms.TextBox txtFacultate;
        private System.Windows.Forms.Button btnStergereM;
        private System.Windows.Forms.Button btnIntroducereM;
        private System.Windows.Forms.TextBox txtMoneda;
        private System.Windows.Forms.DataGridView dgvMoneda;
    }
}