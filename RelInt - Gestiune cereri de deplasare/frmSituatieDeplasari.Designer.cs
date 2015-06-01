namespace RelInt___Gestiune_cereri_de_deplasare
{
    partial class frmSituatieDeplasari
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSituatieDeplasari));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.btnIesire = new System.Windows.Forms.ToolStripMenuItem();
            this.lblRPDataInceput = new System.Windows.Forms.Label();
            this.dpRPDataInceput = new System.Windows.Forms.DateTimePicker();
            this.dpRPDataSfarsit = new System.Windows.Forms.DateTimePicker();
            this.lblRPDataSfarsit = new System.Windows.Forms.Label();
            this.btnRPGenerare = new System.Windows.Forms.Button();
            this.cmbRPScop = new System.Windows.Forms.ComboBox();
            this.lblRPScop = new System.Windows.Forms.Label();
            this.panouSDSituatie = new System.Windows.Forms.Panel();
            this.lblSDSituatie = new System.Windows.Forms.Label();
            this.lblAtenționare = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.panouSDSituatie.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnIesire});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(699, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // btnIesire
            // 
            this.btnIesire.Name = "btnIesire";
            this.btnIesire.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.W)));
            this.btnIesire.Size = new System.Drawing.Size(46, 20);
            this.btnIesire.Text = "I&eșire";
            this.btnIesire.Click += new System.EventHandler(this.btnIesire_Click);
            // 
            // lblRPDataInceput
            // 
            this.lblRPDataInceput.AutoSize = true;
            this.lblRPDataInceput.Location = new System.Drawing.Point(19, 42);
            this.lblRPDataInceput.Name = "lblRPDataInceput";
            this.lblRPDataInceput.Size = new System.Drawing.Size(150, 13);
            this.lblRPDataInceput.TabIndex = 1;
            this.lblRPDataInceput.Text = "Selectați perioada, între data: ";
            // 
            // dpRPDataInceput
            // 
            this.dpRPDataInceput.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dpRPDataInceput.Location = new System.Drawing.Point(175, 39);
            this.dpRPDataInceput.Name = "dpRPDataInceput";
            this.dpRPDataInceput.Size = new System.Drawing.Size(91, 20);
            this.dpRPDataInceput.TabIndex = 2;
            this.dpRPDataInceput.ValueChanged += new System.EventHandler(this.dpRPDataInceput_ValueChanged);
            // 
            // dpRPDataSfarsit
            // 
            this.dpRPDataSfarsit.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dpRPDataSfarsit.Location = new System.Drawing.Point(322, 39);
            this.dpRPDataSfarsit.Name = "dpRPDataSfarsit";
            this.dpRPDataSfarsit.Size = new System.Drawing.Size(91, 20);
            this.dpRPDataSfarsit.TabIndex = 4;
            this.dpRPDataSfarsit.ValueChanged += new System.EventHandler(this.dpRPDataSfarsit_ValueChanged);
            // 
            // lblRPDataSfarsit
            // 
            this.lblRPDataSfarsit.AutoSize = true;
            this.lblRPDataSfarsit.Location = new System.Drawing.Point(272, 42);
            this.lblRPDataSfarsit.Name = "lblRPDataSfarsit";
            this.lblRPDataSfarsit.Size = new System.Drawing.Size(44, 13);
            this.lblRPDataSfarsit.TabIndex = 3;
            this.lblRPDataSfarsit.Text = "și data: ";
            // 
            // btnRPGenerare
            // 
            this.btnRPGenerare.Enabled = false;
            this.btnRPGenerare.Location = new System.Drawing.Point(424, 66);
            this.btnRPGenerare.Name = "btnRPGenerare";
            this.btnRPGenerare.Size = new System.Drawing.Size(157, 23);
            this.btnRPGenerare.TabIndex = 5;
            this.btnRPGenerare.Text = "Generare raport anual";
            this.btnRPGenerare.UseVisualStyleBackColor = true;
            this.btnRPGenerare.Click += new System.EventHandler(this.btnRPGenerare_Click);
            // 
            // cmbRPScop
            // 
            this.cmbRPScop.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRPScop.FormattingEnabled = true;
            this.cmbRPScop.Location = new System.Drawing.Point(175, 67);
            this.cmbRPScop.Name = "cmbRPScop";
            this.cmbRPScop.Size = new System.Drawing.Size(238, 21);
            this.cmbRPScop.TabIndex = 8;
            this.cmbRPScop.SelectedIndexChanged += new System.EventHandler(this.cmbRPScop_SelectedIndexChanged);
            // 
            // lblRPScop
            // 
            this.lblRPScop.AutoSize = true;
            this.lblRPScop.Location = new System.Drawing.Point(83, 70);
            this.lblRPScop.Name = "lblRPScop";
            this.lblRPScop.Size = new System.Drawing.Size(86, 13);
            this.lblRPScop.TabIndex = 7;
            this.lblRPScop.Text = "selectați scopul: ";
            // 
            // panouSDSituatie
            // 
            this.panouSDSituatie.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panouSDSituatie.Controls.Add(this.lblAtenționare);
            this.panouSDSituatie.Controls.Add(this.lblSDSituatie);
            this.panouSDSituatie.Controls.Add(this.lblRPDataInceput);
            this.panouSDSituatie.Controls.Add(this.cmbRPScop);
            this.panouSDSituatie.Controls.Add(this.dpRPDataInceput);
            this.panouSDSituatie.Controls.Add(this.lblRPScop);
            this.panouSDSituatie.Controls.Add(this.dpRPDataSfarsit);
            this.panouSDSituatie.Controls.Add(this.lblRPDataSfarsit);
            this.panouSDSituatie.Controls.Add(this.btnRPGenerare);
            this.panouSDSituatie.Location = new System.Drawing.Point(12, 37);
            this.panouSDSituatie.Name = "panouSDSituatie";
            this.panouSDSituatie.Size = new System.Drawing.Size(675, 100);
            this.panouSDSituatie.TabIndex = 9;
            // 
            // lblSDSituatie
            // 
            this.lblSDSituatie.AutoSize = true;
            this.lblSDSituatie.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSDSituatie.Location = new System.Drawing.Point(19, 10);
            this.lblSDSituatie.Name = "lblSDSituatie";
            this.lblSDSituatie.Size = new System.Drawing.Size(154, 17);
            this.lblSDSituatie.TabIndex = 9;
            this.lblSDSituatie.Text = "Situația deplasărilor";
            // 
            // lblAtenționare
            // 
            this.lblAtenționare.AutoSize = true;
            this.lblAtenționare.ForeColor = System.Drawing.Color.Red;
            this.lblAtenționare.Location = new System.Drawing.Point(322, 18);
            this.lblAtenționare.Name = "lblAtenționare";
            this.lblAtenționare.Size = new System.Drawing.Size(298, 13);
            this.lblAtenționare.TabIndex = 10;
            this.lblAtenționare.Text = "Data de început nu poate fi mai recentă decât data de sfârșit!";
            this.lblAtenționare.Visible = false;
            // 
            // frmSituatieDeplasari
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(699, 147);
            this.Controls.Add(this.panouSDSituatie);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "frmSituatieDeplasari";
            this.Text = "Situație deplasări";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panouSDSituatie.ResumeLayout(false);
            this.panouSDSituatie.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem btnIesire;
        private System.Windows.Forms.Label lblRPDataInceput;
        private System.Windows.Forms.DateTimePicker dpRPDataInceput;
        private System.Windows.Forms.DateTimePicker dpRPDataSfarsit;
        private System.Windows.Forms.Label lblRPDataSfarsit;
        private System.Windows.Forms.Button btnRPGenerare;
        private System.Windows.Forms.Label lblRPScop;
        private System.Windows.Forms.ComboBox cmbRPScop;
        private System.Windows.Forms.Panel panouSDSituatie;
        private System.Windows.Forms.Label lblSDSituatie;
        private System.Windows.Forms.Label lblAtenționare;
    }
}