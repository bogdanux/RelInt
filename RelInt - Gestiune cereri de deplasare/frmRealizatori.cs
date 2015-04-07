using System;
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

        private void llblDezvoltator2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // Legatura catre TIMOFTE Bogdan Alexandru
            System.Diagnostics.Process.Start("https://www.facebook.com/vioreln5");

            // Specificam daca legatura URL a fost vizitata
            this.llblDezvoltator1.LinkVisited = true;
        }

        private void llblDezvoltator3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // Legatura catre TIMOFTE Bogdan Alexandru
            System.Diagnostics.Process.Start("https://www.facebook.com/carmen.vazdoaga");

            // Specificam daca legatura URL a fost vizitata
            this.llblDezvoltator1.LinkVisited = true;
        }
        /* --------------------------------------------------------------------------------------------------------------- */














    }
}
