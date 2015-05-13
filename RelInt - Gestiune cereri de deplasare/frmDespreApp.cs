using System;
using System.Windows.Forms;

namespace RelInt___Gestiune_cereri_de_deplasare
{
    public partial class frmDespreApp : Form
    {
        public frmDespreApp() // Metoda de LOAD
        {
            InitializeComponent();
        }
        /* --------------------------------------------------------------------------------------------------------------- */



        /* ---------------- Eveniment de tip click pentru butonul "btnIesire" -------------------------------------------------------- */
        private void btnIesire_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /* --------------------------------------------------------------------------------------------------------------- */





    }
}
