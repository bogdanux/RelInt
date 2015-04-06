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
            this.mnuCerereCautare = new System.Windows.Forms.MenuStrip();
            this.btnIesire = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.txtNrInregistrare = new System.Windows.Forms.TextBox();
            this.txtNumePren = new System.Windows.Forms.TextBox();
            this.txtGradDidactic = new System.Windows.Forms.TextBox();
            this.lblNrInregistrare = new System.Windows.Forms.Label();
            this.lblNumePren = new System.Windows.Forms.Label();
            this.lblGradDidactic = new System.Windows.Forms.Label();
            this.txtTara = new System.Windows.Forms.TextBox();
            this.lblTara = new System.Windows.Forms.Label();
            this.txtLocalitatea = new System.Windows.Forms.TextBox();
            this.lblLocalitatea = new System.Windows.Forms.Label();
            this.mnuCerereCautare.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
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
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(13, 93);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(859, 338);
            this.dataGridView1.TabIndex = 1;
            // 
            // txtNrInregistrare
            // 
            this.txtNrInregistrare.Enabled = false;
            this.txtNrInregistrare.Location = new System.Drawing.Point(13, 56);
            this.txtNrInregistrare.Name = "txtNrInregistrare";
            this.txtNrInregistrare.Size = new System.Drawing.Size(100, 20);
            this.txtNrInregistrare.TabIndex = 2;
            // 
            // txtNumePren
            // 
            this.txtNumePren.Location = new System.Drawing.Point(119, 56);
            this.txtNumePren.Name = "txtNumePren";
            this.txtNumePren.Size = new System.Drawing.Size(180, 20);
            this.txtNumePren.TabIndex = 2;
            // 
            // txtGradDidactic
            // 
            this.txtGradDidactic.Location = new System.Drawing.Point(305, 56);
            this.txtGradDidactic.Name = "txtGradDidactic";
            this.txtGradDidactic.Size = new System.Drawing.Size(100, 20);
            this.txtGradDidactic.TabIndex = 2;
            // 
            // lblNrInregistrare
            // 
            this.lblNrInregistrare.AutoSize = true;
            this.lblNrInregistrare.Enabled = false;
            this.lblNrInregistrare.Location = new System.Drawing.Point(11, 40);
            this.lblNrInregistrare.Name = "lblNrInregistrare";
            this.lblNrInregistrare.Size = new System.Drawing.Size(93, 13);
            this.lblNrInregistrare.TabIndex = 3;
            this.lblNrInregistrare.Text = "Număr Înregistrare";
            // 
            // lblNumePren
            // 
            this.lblNumePren.AutoSize = true;
            this.lblNumePren.Location = new System.Drawing.Point(117, 40);
            this.lblNumePren.Name = "lblNumePren";
            this.lblNumePren.Size = new System.Drawing.Size(80, 13);
            this.lblNumePren.TabIndex = 3;
            this.lblNumePren.Text = "Nume Prenume";
            // 
            // lblGradDidactic
            // 
            this.lblGradDidactic.AutoSize = true;
            this.lblGradDidactic.Location = new System.Drawing.Point(304, 40);
            this.lblGradDidactic.Name = "lblGradDidactic";
            this.lblGradDidactic.Size = new System.Drawing.Size(72, 13);
            this.lblGradDidactic.TabIndex = 3;
            this.lblGradDidactic.Text = "Grad Didactic";
            // 
            // txtTara
            // 
            this.txtTara.Location = new System.Drawing.Point(411, 56);
            this.txtTara.Name = "txtTara";
            this.txtTara.Size = new System.Drawing.Size(100, 20);
            this.txtTara.TabIndex = 2;
            // 
            // lblTara
            // 
            this.lblTara.AutoSize = true;
            this.lblTara.Location = new System.Drawing.Point(410, 40);
            this.lblTara.Name = "lblTara";
            this.lblTara.Size = new System.Drawing.Size(29, 13);
            this.lblTara.TabIndex = 3;
            this.lblTara.Text = "Țara";
            // 
            // txtLocalitatea
            // 
            this.txtLocalitatea.Location = new System.Drawing.Point(517, 56);
            this.txtLocalitatea.Name = "txtLocalitatea";
            this.txtLocalitatea.Size = new System.Drawing.Size(100, 20);
            this.txtLocalitatea.TabIndex = 2;
            // 
            // lblLocalitatea
            // 
            this.lblLocalitatea.AutoSize = true;
            this.lblLocalitatea.Location = new System.Drawing.Point(516, 40);
            this.lblLocalitatea.Name = "lblLocalitatea";
            this.lblLocalitatea.Size = new System.Drawing.Size(59, 13);
            this.lblLocalitatea.TabIndex = 3;
            this.lblLocalitatea.Text = "Localitatea";
            // 
            // frmCautareCerere
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 445);
            this.Controls.Add(this.lblLocalitatea);
            this.Controls.Add(this.lblTara);
            this.Controls.Add(this.lblGradDidactic);
            this.Controls.Add(this.lblNumePren);
            this.Controls.Add(this.lblNrInregistrare);
            this.Controls.Add(this.txtLocalitatea);
            this.Controls.Add(this.txtTara);
            this.Controls.Add(this.txtGradDidactic);
            this.Controls.Add(this.txtNumePren);
            this.Controls.Add(this.txtNrInregistrare);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.mnuCerereCautare);
            this.MainMenuStrip = this.mnuCerereCautare;
            this.Name = "frmCautareCerere";
            this.Text = "frmCautareCerere";
            this.mnuCerereCautare.ResumeLayout(false);
            this.mnuCerereCautare.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mnuCerereCautare;
        private System.Windows.Forms.ToolStripMenuItem btnIesire;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox txtNrInregistrare;
        private System.Windows.Forms.TextBox txtNumePren;
        private System.Windows.Forms.TextBox txtGradDidactic;
        private System.Windows.Forms.Label lblNrInregistrare;
        private System.Windows.Forms.Label lblNumePren;
        private System.Windows.Forms.Label lblGradDidactic;
        private System.Windows.Forms.TextBox txtTara;
        private System.Windows.Forms.Label lblTara;
        private System.Windows.Forms.TextBox txtLocalitatea;
        private System.Windows.Forms.Label lblLocalitatea;
    }
}