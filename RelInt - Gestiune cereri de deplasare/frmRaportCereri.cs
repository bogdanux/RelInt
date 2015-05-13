using System;
using System.Windows.Forms;

namespace RelInt___Gestiune_cereri_de_deplasare
{
    public partial class frmRaportCereri : Form
    {
        public frmRaportCereri() // Metoda de LOAD
        {
            InitializeComponent();
        }
        /* --------------------------------------------------------------------------------------------------------------- */








        /* --------------------------------------------------------------------------------------------------------------- */
        private void frmRaportCereri_Load(object sender, EventArgs e)
        {

            this.rvRaportCereri.RefreshReport();
        }
        /* --------------------------------------------------------------------------------------------------------------- */







        /* --------------------------------------------------------------------------------------------------------------- */
        private void btnIesire_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /* --------------------------------------------------------------------------------------------------------------- */




    }
}
