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
    public partial class frmCerereBECA : Form
    {
        public frmCerereBECA() // Metoda de LOAD
        {
            InitializeComponent();
        }
        /* --------------------------------------------------------------------------------------------------------------- */






        /* ----------------- Eveniment de tip click pentru btnIesire ----------------------------------------------------- */
        private void btnIesire_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /* --------------------------------------------------------------------------------------------------------------- */









        /* ----------------- Eveniment de tip click pentru btnGenerare --------------------------------------------------- */
        private void btnGenerare_Click(object sender, EventArgs e)
        {

        }
        /* --------------------------------------------------------------------------------------------------------------- */






    }
}