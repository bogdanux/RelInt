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
    public partial class frmRealizatori : Form
    {
        public frmRealizatori() // Metoda LOAD
        {
            InitializeComponent();
        }
        /* --------------------------------------------------------------------------------------------------------------- */









        /* ------------------- Legaturi Dezvoltatori --------------------------------------------------------------------- */
        private void llblDezvoltator1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // Legatura catre TIMOFTE Bogdan Alexandru
            System.Diagnostics.Process.Start("https://www.facebook.com/tkooficial");

            // Specificam daca legatura URL a fost vizitata
            this.llblDezvoltator1.LinkVisited = true;
        }
        private void llblMailDezv1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("mailto:timofteba@gmail.com");
        }

        private void llblDezvoltator2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // Legatura catre NARE Viorel
            System.Diagnostics.Process.Start("https://www.facebook.com/vioreln5");

            // Specificam daca legatura URL a fost vizitata
            this.llblDezvoltator1.LinkVisited = true;
        }
        private void llblMailDezv2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("mailto:vioreln5@gmail.com");
        }

        private void llblDezvoltator3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // Legatura catre VAZDOAGA Carmen
            System.Diagnostics.Process.Start("https://www.facebook.com/carmen.vazdoaga");

            // Specificam daca legatura URL a fost vizitata
            this.llblDezvoltator1.LinkVisited = true;
        }
        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // System.Diagnostics.Process.Start("mailto:vioreln5@gmail.com");
        }
        /* --------------------------------------------------------------------------------------------------------------- */














    }
}
