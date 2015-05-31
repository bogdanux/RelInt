namespace RelInt___Gestiune_cereri_de_deplasare
{
    partial class frmRapoarte
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRapoarte));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.btnIesire = new System.Windows.Forms.ToolStripMenuItem();
            this.lblRPDataInceput = new System.Windows.Forms.Label();
            this.dpRPDataInceput = new System.Windows.Forms.DateTimePicker();
            this.dpRPDataSfarsit = new System.Windows.Forms.DateTimePicker();
            this.lblRPDataSfarsit = new System.Windows.Forms.Label();
            this.btnRPGenerare = new System.Windows.Forms.Button();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tcRapoarte = new System.Windows.Forms.TabControl();
            this.tpRP = new System.Windows.Forms.TabPage();
            this.cmbRPScop = new System.Windows.Forms.ComboBox();
            this.lblRPScop = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.tcRapoarte.SuspendLayout();
            this.tpRP.SuspendLayout();
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
            this.lblRPDataInceput.Location = new System.Drawing.Point(6, 12);
            this.lblRPDataInceput.Name = "lblRPDataInceput";
            this.lblRPDataInceput.Size = new System.Drawing.Size(150, 13);
            this.lblRPDataInceput.TabIndex = 1;
            this.lblRPDataInceput.Text = "Selectați perioada, între data: ";
            // 
            // dpRPDataInceput
            // 
            this.dpRPDataInceput.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dpRPDataInceput.Location = new System.Drawing.Point(162, 9);
            this.dpRPDataInceput.Name = "dpRPDataInceput";
            this.dpRPDataInceput.Size = new System.Drawing.Size(91, 20);
            this.dpRPDataInceput.TabIndex = 2;
            // 
            // dpRPDataSfarsit
            // 
            this.dpRPDataSfarsit.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dpRPDataSfarsit.Location = new System.Drawing.Point(309, 9);
            this.dpRPDataSfarsit.Name = "dpRPDataSfarsit";
            this.dpRPDataSfarsit.Size = new System.Drawing.Size(91, 20);
            this.dpRPDataSfarsit.TabIndex = 4;
            // 
            // lblRPDataSfarsit
            // 
            this.lblRPDataSfarsit.AutoSize = true;
            this.lblRPDataSfarsit.Location = new System.Drawing.Point(259, 12);
            this.lblRPDataSfarsit.Name = "lblRPDataSfarsit";
            this.lblRPDataSfarsit.Size = new System.Drawing.Size(44, 13);
            this.lblRPDataSfarsit.TabIndex = 3;
            this.lblRPDataSfarsit.Text = "și data: ";
            // 
            // btnRPGenerare
            // 
            this.btnRPGenerare.Enabled = false;
            this.btnRPGenerare.Location = new System.Drawing.Point(411, 36);
            this.btnRPGenerare.Name = "btnRPGenerare";
            this.btnRPGenerare.Size = new System.Drawing.Size(157, 23);
            this.btnRPGenerare.TabIndex = 5;
            this.btnRPGenerare.Text = "Generare raport anual";
            this.btnRPGenerare.UseVisualStyleBackColor = true;
            this.btnRPGenerare.Click += new System.EventHandler(this.btnRPGenerare_Click);
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(9, 65);
            this.chart1.Name = "chart1";
            this.chart1.Size = new System.Drawing.Size(668, 349);
            this.chart1.TabIndex = 6;
            this.chart1.Text = "chart1";
            // 
            // tcRapoarte
            // 
            this.tcRapoarte.Controls.Add(this.tpRP);
            this.tcRapoarte.Controls.Add(this.tabPage2);
            this.tcRapoarte.Location = new System.Drawing.Point(3, 27);
            this.tcRapoarte.Name = "tcRapoarte";
            this.tcRapoarte.SelectedIndex = 0;
            this.tcRapoarte.Size = new System.Drawing.Size(695, 632);
            this.tcRapoarte.TabIndex = 3;
            // 
            // tpRP
            // 
            this.tpRP.Controls.Add(this.cmbRPScop);
            this.tpRP.Controls.Add(this.lblRPScop);
            this.tpRP.Controls.Add(this.chart1);
            this.tpRP.Controls.Add(this.btnRPGenerare);
            this.tpRP.Controls.Add(this.lblRPDataInceput);
            this.tpRP.Controls.Add(this.dpRPDataSfarsit);
            this.tpRP.Controls.Add(this.dpRPDataInceput);
            this.tpRP.Controls.Add(this.lblRPDataSfarsit);
            this.tpRP.Location = new System.Drawing.Point(4, 22);
            this.tpRP.Name = "tpRP";
            this.tpRP.Padding = new System.Windows.Forms.Padding(3);
            this.tpRP.Size = new System.Drawing.Size(687, 606);
            this.tpRP.TabIndex = 0;
            this.tpRP.Text = "Rapoarte periodice";
            this.tpRP.UseVisualStyleBackColor = true;
            // 
            // cmbRPScop
            // 
            this.cmbRPScop.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRPScop.FormattingEnabled = true;
            this.cmbRPScop.Location = new System.Drawing.Point(162, 37);
            this.cmbRPScop.Name = "cmbRPScop";
            this.cmbRPScop.Size = new System.Drawing.Size(238, 21);
            this.cmbRPScop.TabIndex = 8;
            this.cmbRPScop.SelectedIndexChanged += new System.EventHandler(this.cmbRPScop_SelectedIndexChanged);
            // 
            // lblRPScop
            // 
            this.lblRPScop.AutoSize = true;
            this.lblRPScop.Location = new System.Drawing.Point(70, 40);
            this.lblRPScop.Name = "lblRPScop";
            this.lblRPScop.Size = new System.Drawing.Size(86, 13);
            this.lblRPScop.TabIndex = 7;
            this.lblRPScop.Text = "selectați scopul: ";
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(687, 606);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // frmRapoarte
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(699, 661);
            this.Controls.Add(this.tcRapoarte);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "frmRapoarte";
            this.Text = "Rapoarte";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.tcRapoarte.ResumeLayout(false);
            this.tpRP.ResumeLayout(false);
            this.tpRP.PerformLayout();
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
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.TabControl tcRapoarte;
        private System.Windows.Forms.TabPage tpRP;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label lblRPScop;
        private System.Windows.Forms.ComboBox cmbRPScop;
    }
}