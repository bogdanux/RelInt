﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RelInt___Gestiune_cereri_de_deplasare
{
    public partial class frmCerereModificare : Form
    {
        public frmCerereModificare()
        {
            InitializeComponent();
        }

        private void btnCMIesire_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Form frmintroducere = new frmCerereInregistrare();
            if (frmintroducere != null)
            {
                frmintroducere.Close();
                this.Close();
            }
        }
    }
}
