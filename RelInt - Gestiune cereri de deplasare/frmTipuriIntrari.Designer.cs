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
            this.btnIntroducereGD = new System.Windows.Forms.Button();
            this.txtGradDidactic = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.btnStergereGD = new System.Windows.Forms.Button();
            this.mnuTipuriIntrari.SuspendLayout();
            this.tabGradDidactic.SuspendLayout();
            this.tabPage1.SuspendLayout();
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
            this.tabGradDidactic.Size = new System.Drawing.Size(394, 243);
            this.tabGradDidactic.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.btnStergereGD);
            this.tabPage1.Controls.Add(this.btnIntroducereGD);
            this.tabPage1.Controls.Add(this.txtGradDidactic);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(386, 217);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Grade didactice";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // btnIntroducereGD
            // 
            this.btnIntroducereGD.Location = new System.Drawing.Point(134, 110);
            this.btnIntroducereGD.Name = "btnIntroducereGD";
            this.btnIntroducereGD.Size = new System.Drawing.Size(75, 23);
            this.btnIntroducereGD.TabIndex = 1;
            this.btnIntroducereGD.Text = "Introducere";
            this.btnIntroducereGD.UseVisualStyleBackColor = true;
            // 
            // txtGradDidactic
            // 
            this.txtGradDidactic.Location = new System.Drawing.Point(25, 112);
            this.txtGradDidactic.Name = "txtGradDidactic";
            this.txtGradDidactic.Size = new System.Drawing.Size(100, 20);
            this.txtGradDidactic.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(386, 217);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Facultăți";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(386, 217);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Monezi";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // btnStergereGD
            // 
            this.btnStergereGD.Location = new System.Drawing.Point(215, 110);
            this.btnStergereGD.Name = "btnStergereGD";
            this.btnStergereGD.Size = new System.Drawing.Size(75, 23);
            this.btnStergereGD.TabIndex = 2;
            this.btnStergereGD.Text = "Ștergere";
            this.btnStergereGD.UseVisualStyleBackColor = true;
            // 
            // frmTipuriIntrari
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(398, 272);
            this.Controls.Add(this.tabGradDidactic);
            this.Controls.Add(this.mnuTipuriIntrari);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.mnuTipuriIntrari;
            this.Name = "frmTipuriIntrari";
            this.Text = "Tipuri Intrări";
            this.mnuTipuriIntrari.ResumeLayout(false);
            this.mnuTipuriIntrari.PerformLayout();
            this.tabGradDidactic.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
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
    }
}