namespace RelInt___Gestiune_cereri_de_deplasare
{
    partial class frmEditareRector
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEditareRector));
            this.mnuEditareRector = new System.Windows.Forms.MenuStrip();
            this.btnIesire = new System.Windows.Forms.ToolStripMenuItem();
            this.tabProrector = new System.Windows.Forms.TabControl();
            this.ptRector = new System.Windows.Forms.TabPage();
            this.btnStergeR = new System.Windows.Forms.Button();
            this.btnAdaugaR = new System.Windows.Forms.Button();
            this.txtRector = new System.Windows.Forms.TextBox();
            this.dgvRector = new System.Windows.Forms.DataGridView();
            this.ptProrector = new System.Windows.Forms.TabPage();
            this.btnStergePR = new System.Windows.Forms.Button();
            this.btnAdaugaPR = new System.Windows.Forms.Button();
            this.txtProRector = new System.Windows.Forms.TextBox();
            this.dgvProRector = new System.Windows.Forms.DataGridView();
            this.lblRector = new System.Windows.Forms.Label();
            this.lblEmailR = new System.Windows.Forms.Label();
            this.txtEmailR = new System.Windows.Forms.TextBox();
            this.lblTelefonR = new System.Windows.Forms.Label();
            this.txtTelefonR = new System.Windows.Forms.TextBox();
            this.lblTelefonPR1 = new System.Windows.Forms.Label();
            this.txtTelefonPR1 = new System.Windows.Forms.TextBox();
            this.lblEMailPR = new System.Windows.Forms.Label();
            this.txtEMailPR = new System.Windows.Forms.TextBox();
            this.lblNumePR = new System.Windows.Forms.Label();
            this.lblTelefonPR2 = new System.Windows.Forms.Label();
            this.txtTelefonPR2 = new System.Windows.Forms.TextBox();
            this.mnuEditareRector.SuspendLayout();
            this.tabProrector.SuspendLayout();
            this.ptRector.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRector)).BeginInit();
            this.ptProrector.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProRector)).BeginInit();
            this.SuspendLayout();
            // 
            // mnuEditareRector
            // 
            this.mnuEditareRector.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.mnuEditareRector.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnIesire});
            this.mnuEditareRector.Location = new System.Drawing.Point(0, 0);
            this.mnuEditareRector.Name = "mnuEditareRector";
            this.mnuEditareRector.Size = new System.Drawing.Size(411, 24);
            this.mnuEditareRector.TabIndex = 0;
            this.mnuEditareRector.Text = "menuStrip1";
            // 
            // btnIesire
            // 
            this.btnIesire.Name = "btnIesire";
            this.btnIesire.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.W)));
            this.btnIesire.Size = new System.Drawing.Size(46, 20);
            this.btnIesire.Text = "I&eșire";
            this.btnIesire.Click += new System.EventHandler(this.btnIesire_Click);
            // 
            // tabProrector
            // 
            this.tabProrector.Controls.Add(this.ptRector);
            this.tabProrector.Controls.Add(this.ptProrector);
            this.tabProrector.Location = new System.Drawing.Point(4, 28);
            this.tabProrector.Name = "tabProrector";
            this.tabProrector.SelectedIndex = 0;
            this.tabProrector.Size = new System.Drawing.Size(407, 388);
            this.tabProrector.TabIndex = 1;
            // 
            // ptRector
            // 
            this.ptRector.Controls.Add(this.lblTelefonR);
            this.ptRector.Controls.Add(this.txtTelefonR);
            this.ptRector.Controls.Add(this.lblEmailR);
            this.ptRector.Controls.Add(this.txtEmailR);
            this.ptRector.Controls.Add(this.lblRector);
            this.ptRector.Controls.Add(this.btnStergeR);
            this.ptRector.Controls.Add(this.btnAdaugaR);
            this.ptRector.Controls.Add(this.txtRector);
            this.ptRector.Controls.Add(this.dgvRector);
            this.ptRector.Location = new System.Drawing.Point(4, 22);
            this.ptRector.Name = "ptRector";
            this.ptRector.Padding = new System.Windows.Forms.Padding(3);
            this.ptRector.Size = new System.Drawing.Size(399, 362);
            this.ptRector.TabIndex = 0;
            this.ptRector.Text = "Rector";
            this.ptRector.UseVisualStyleBackColor = true;
            // 
            // btnStergeR
            // 
            this.btnStergeR.Location = new System.Drawing.Point(331, 258);
            this.btnStergeR.Name = "btnStergeR";
            this.btnStergeR.Size = new System.Drawing.Size(55, 73);
            this.btnStergeR.TabIndex = 3;
            this.btnStergeR.Text = "Șterge";
            this.btnStergeR.UseVisualStyleBackColor = true;
            this.btnStergeR.Click += new System.EventHandler(this.btnStergeR_Click);
            // 
            // btnAdaugaR
            // 
            this.btnAdaugaR.Location = new System.Drawing.Point(270, 258);
            this.btnAdaugaR.Name = "btnAdaugaR";
            this.btnAdaugaR.Size = new System.Drawing.Size(55, 73);
            this.btnAdaugaR.TabIndex = 2;
            this.btnAdaugaR.Text = "Adaugă";
            this.btnAdaugaR.UseVisualStyleBackColor = true;
            this.btnAdaugaR.Click += new System.EventHandler(this.btnAdaugaR_Click);
            // 
            // txtRector
            // 
            this.txtRector.Location = new System.Drawing.Point(77, 259);
            this.txtRector.Name = "txtRector";
            this.txtRector.Size = new System.Drawing.Size(187, 20);
            this.txtRector.TabIndex = 1;
            this.txtRector.TextChanged += new System.EventHandler(this.txtRector_TextChanged);
            // 
            // dgvRector
            // 
            this.dgvRector.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRector.Location = new System.Drawing.Point(3, 3);
            this.dgvRector.Name = "dgvRector";
            this.dgvRector.ReadOnly = true;
            this.dgvRector.Size = new System.Drawing.Size(393, 251);
            this.dgvRector.TabIndex = 0;
            // 
            // ptProrector
            // 
            this.ptProrector.Controls.Add(this.lblTelefonPR2);
            this.ptProrector.Controls.Add(this.txtTelefonPR2);
            this.ptProrector.Controls.Add(this.lblTelefonPR1);
            this.ptProrector.Controls.Add(this.txtTelefonPR1);
            this.ptProrector.Controls.Add(this.lblEMailPR);
            this.ptProrector.Controls.Add(this.txtEMailPR);
            this.ptProrector.Controls.Add(this.lblNumePR);
            this.ptProrector.Controls.Add(this.btnStergePR);
            this.ptProrector.Controls.Add(this.btnAdaugaPR);
            this.ptProrector.Controls.Add(this.txtProRector);
            this.ptProrector.Controls.Add(this.dgvProRector);
            this.ptProrector.Location = new System.Drawing.Point(4, 22);
            this.ptProrector.Name = "ptProrector";
            this.ptProrector.Padding = new System.Windows.Forms.Padding(3);
            this.ptProrector.Size = new System.Drawing.Size(399, 362);
            this.ptProrector.TabIndex = 1;
            this.ptProrector.Text = "ProRector";
            this.ptProrector.UseVisualStyleBackColor = true;
            // 
            // btnStergePR
            // 
            this.btnStergePR.Location = new System.Drawing.Point(331, 258);
            this.btnStergePR.Name = "btnStergePR";
            this.btnStergePR.Size = new System.Drawing.Size(55, 99);
            this.btnStergePR.TabIndex = 6;
            this.btnStergePR.Text = "Șterge";
            this.btnStergePR.UseVisualStyleBackColor = true;
            this.btnStergePR.Click += new System.EventHandler(this.btnStergePR_Click);
            // 
            // btnAdaugaPR
            // 
            this.btnAdaugaPR.Location = new System.Drawing.Point(270, 258);
            this.btnAdaugaPR.Name = "btnAdaugaPR";
            this.btnAdaugaPR.Size = new System.Drawing.Size(55, 99);
            this.btnAdaugaPR.TabIndex = 5;
            this.btnAdaugaPR.Text = "Adaugă";
            this.btnAdaugaPR.UseVisualStyleBackColor = true;
            this.btnAdaugaPR.Click += new System.EventHandler(this.btnAdaugaPR_Click);
            // 
            // txtProRector
            // 
            this.txtProRector.Location = new System.Drawing.Point(92, 259);
            this.txtProRector.Name = "txtProRector";
            this.txtProRector.Size = new System.Drawing.Size(172, 20);
            this.txtProRector.TabIndex = 4;
            this.txtProRector.TextChanged += new System.EventHandler(this.txtProRector_TextChanged);
            // 
            // dgvProRector
            // 
            this.dgvProRector.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProRector.Location = new System.Drawing.Point(3, 3);
            this.dgvProRector.Name = "dgvProRector";
            this.dgvProRector.ReadOnly = true;
            this.dgvProRector.Size = new System.Drawing.Size(393, 251);
            this.dgvProRector.TabIndex = 0;
            // 
            // lblRector
            // 
            this.lblRector.AutoSize = true;
            this.lblRector.Location = new System.Drawing.Point(6, 262);
            this.lblRector.Name = "lblRector";
            this.lblRector.Size = new System.Drawing.Size(65, 13);
            this.lblRector.TabIndex = 4;
            this.lblRector.Text = "Nume rector";
            // 
            // lblEmailR
            // 
            this.lblEmailR.AutoSize = true;
            this.lblEmailR.Location = new System.Drawing.Point(35, 288);
            this.lblEmailR.Name = "lblEmailR";
            this.lblEmailR.Size = new System.Drawing.Size(36, 13);
            this.lblEmailR.TabIndex = 6;
            this.lblEmailR.Text = "E-Mail";
            // 
            // txtEmailR
            // 
            this.txtEmailR.Location = new System.Drawing.Point(77, 285);
            this.txtEmailR.Name = "txtEmailR";
            this.txtEmailR.Size = new System.Drawing.Size(187, 20);
            this.txtEmailR.TabIndex = 5;
            // 
            // lblTelefonR
            // 
            this.lblTelefonR.AutoSize = true;
            this.lblTelefonR.Location = new System.Drawing.Point(28, 314);
            this.lblTelefonR.Name = "lblTelefonR";
            this.lblTelefonR.Size = new System.Drawing.Size(43, 13);
            this.lblTelefonR.TabIndex = 8;
            this.lblTelefonR.Text = "Telefon";
            // 
            // txtTelefonR
            // 
            this.txtTelefonR.Location = new System.Drawing.Point(77, 311);
            this.txtTelefonR.Name = "txtTelefonR";
            this.txtTelefonR.Size = new System.Drawing.Size(187, 20);
            this.txtTelefonR.TabIndex = 7;
            this.txtTelefonR.TextChanged += new System.EventHandler(this.txtTelefonR_TextChanged);
            // 
            // lblTelefonPR1
            // 
            this.lblTelefonPR1.AutoSize = true;
            this.lblTelefonPR1.Location = new System.Drawing.Point(28, 314);
            this.lblTelefonPR1.Name = "lblTelefonPR1";
            this.lblTelefonPR1.Size = new System.Drawing.Size(43, 13);
            this.lblTelefonPR1.TabIndex = 16;
            this.lblTelefonPR1.Text = "Telefon";
            // 
            // txtTelefonPR1
            // 
            this.txtTelefonPR1.Location = new System.Drawing.Point(77, 311);
            this.txtTelefonPR1.Name = "txtTelefonPR1";
            this.txtTelefonPR1.Size = new System.Drawing.Size(187, 20);
            this.txtTelefonPR1.TabIndex = 15;
            this.txtTelefonPR1.TextChanged += new System.EventHandler(this.txtTelefonPR1_TextChanged);
            // 
            // lblEMailPR
            // 
            this.lblEMailPR.AutoSize = true;
            this.lblEMailPR.Location = new System.Drawing.Point(35, 288);
            this.lblEMailPR.Name = "lblEMailPR";
            this.lblEMailPR.Size = new System.Drawing.Size(36, 13);
            this.lblEMailPR.TabIndex = 14;
            this.lblEMailPR.Text = "E-Mail";
            // 
            // txtEMailPR
            // 
            this.txtEMailPR.Location = new System.Drawing.Point(77, 285);
            this.txtEMailPR.Name = "txtEMailPR";
            this.txtEMailPR.Size = new System.Drawing.Size(187, 20);
            this.txtEMailPR.TabIndex = 13;
            // 
            // lblNumePR
            // 
            this.lblNumePR.AutoSize = true;
            this.lblNumePR.Location = new System.Drawing.Point(6, 262);
            this.lblNumePR.Name = "lblNumePR";
            this.lblNumePR.Size = new System.Drawing.Size(80, 13);
            this.lblNumePR.TabIndex = 12;
            this.lblNumePR.Text = "Nume prorector";
            // 
            // lblTelefonPR2
            // 
            this.lblTelefonPR2.AutoSize = true;
            this.lblTelefonPR2.Location = new System.Drawing.Point(28, 340);
            this.lblTelefonPR2.Name = "lblTelefonPR2";
            this.lblTelefonPR2.Size = new System.Drawing.Size(43, 13);
            this.lblTelefonPR2.TabIndex = 18;
            this.lblTelefonPR2.Text = "Telefon";
            // 
            // txtTelefonPR2
            // 
            this.txtTelefonPR2.Location = new System.Drawing.Point(77, 337);
            this.txtTelefonPR2.Name = "txtTelefonPR2";
            this.txtTelefonPR2.Size = new System.Drawing.Size(187, 20);
            this.txtTelefonPR2.TabIndex = 17;
            this.txtTelefonPR2.TextChanged += new System.EventHandler(this.txtTelefonPR2_TextChanged);
            // 
            // frmEditareRector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(411, 417);
            this.Controls.Add(this.tabProrector);
            this.Controls.Add(this.mnuEditareRector);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.mnuEditareRector;
            this.Name = "frmEditareRector";
            this.Text = "Editare Rectori - ProRectori";
            this.mnuEditareRector.ResumeLayout(false);
            this.mnuEditareRector.PerformLayout();
            this.tabProrector.ResumeLayout(false);
            this.ptRector.ResumeLayout(false);
            this.ptRector.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRector)).EndInit();
            this.ptProrector.ResumeLayout(false);
            this.ptProrector.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProRector)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mnuEditareRector;
        private System.Windows.Forms.ToolStripMenuItem btnIesire;
        private System.Windows.Forms.TabControl tabProrector;
        private System.Windows.Forms.TabPage ptRector;
        private System.Windows.Forms.DataGridView dgvRector;
        private System.Windows.Forms.TextBox txtRector;
        private System.Windows.Forms.Button btnStergeR;
        private System.Windows.Forms.Button btnAdaugaR;
        private System.Windows.Forms.TabPage ptProrector;
        private System.Windows.Forms.Button btnStergePR;
        private System.Windows.Forms.Button btnAdaugaPR;
        private System.Windows.Forms.TextBox txtProRector;
        private System.Windows.Forms.DataGridView dgvProRector;
        private System.Windows.Forms.Label lblRector;
        private System.Windows.Forms.Label lblTelefonR;
        private System.Windows.Forms.TextBox txtTelefonR;
        private System.Windows.Forms.Label lblEmailR;
        private System.Windows.Forms.TextBox txtEmailR;
        private System.Windows.Forms.Label lblTelefonPR1;
        private System.Windows.Forms.TextBox txtTelefonPR1;
        private System.Windows.Forms.Label lblEMailPR;
        private System.Windows.Forms.TextBox txtEMailPR;
        private System.Windows.Forms.Label lblNumePR;
        private System.Windows.Forms.Label lblTelefonPR2;
        private System.Windows.Forms.TextBox txtTelefonPR2;
    }
}