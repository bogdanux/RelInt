using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Odbc;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RelInt___Gestiune_cereri_de_deplasare
{
    public partial class frmResetareAplicatie : Form
    {
        public frmResetareAplicatie() // Metoda de LOAD
        {
            InitializeComponent();

            // Dezactivam
            panouActiuni.Enabled = false;
        }
        /* --------------------------------------------------------------------------------------------------------------- */






        /* ----------- Obiecte de lucru cu RelIntDB ---------------------------------------------------------------------- */
        // Sir de conectare al RelIntDB
        string sircon_RelIntDB = "DSN=PostgreSQL35W;database=RelIntDB;server=localhost;port=5432;UID=postgres;PWD=12345;sslmode=disable;readonly=0;protocol=7.4;fakeoidindex=0;showoidcolumn=0;rowversioning=0;showsystemtables=0;fetch=100;socket=4096;unknownsizes=0;maxvarcharsize=255;maxlongvarcharsize=8190;debug=0;commlog=0;optimizer=0;ksqo=1;usedeclarefetch=0;textaslongvarchar=1;unknownsaslongvarchar=0;boolsaschar=1;parse=0;cancelasfreestmt=0;extrasystableprefixes=dd_;lfconversion=1;updatablecursors=1;disallowpremature=0;trueisminus1=0;bi=0;byteaaslongvarbinary=0;useserversideprepare=1;lowercaseidentifier=0;gssauthusegss=0;xaopt=1;";

        /* --------------------------------------------------------------------------------------------------------------- */






        private string parola = "AcademiaMihăileană1835";
        /* --------------------------------------------------------------------------------------------------------------- */
        private void btnIesire_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void chkDeAcord_CheckedChanged(object sender, EventArgs e)
        {
            if (chkDeAcord.Checked)
            {
                panouActiuni.Enabled = true;
                btnResetare.Enabled = false;
            }
            else
            {
                panouActiuni.Enabled = false;
            }
        }
        /* --------------------------------------------------------------------------------------------------------------- */





        /* --------------------------------------------------------------------------------------------------------------- */
        private void txtParola_TextChanged(object sender, EventArgs e)
        {
            if (txtParola.Text == parola)
            {
                btnResetare.Enabled = true;
            }
            else
            {
                btnResetare.Enabled = false;
            }
        }
        /* --------------------------------------------------------------------------------------------------------------- */





        /* --------------------------------------------------------------------------------------------------------------- */
        private void btnResetare_Click(object sender, EventArgs e)
        {
            // Conexiunea
            using (OdbcConnection conexiune_InserareCerereRelInt = new OdbcConnection(sircon_RelIntDB))
            {           // Comanda
                using (OdbcCommand comanda_inserareRelInt = new OdbcCommand())
                {
                    string scriptresetare = File.ReadAllText(@"C:\Program Files (x86)\SIA - FEAA\RelInt - GCdD\RelIntBD-CRPO.sql");
                    comanda_inserareRelInt.Connection = conexiune_InserareCerereRelInt;
                    comanda_inserareRelInt.CommandType = CommandType.Text;
                    comanda_inserareRelInt.CommandText = scriptresetare;

                    // Incercam conexiunea si query-ul
                    try
                    {
                        conexiune_InserareCerereRelInt.Open();
                        int recordsAffected = comanda_inserareRelInt.ExecuteNonQuery();

                        // Afisam mesaj informativ
                        MessageBox.Show("Baza de Date \"RelIntDB\" a fost reinițializată cu succes!", "Succes", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Dezactivam
                        panouAtentie.Enabled = false;
                        panouActiuni.Enabled = false;
                    }

                    // Captam eventualele erori
                    catch (OdbcException exInserare)
                    {
                        // Afisam eroarea
                        MessageBox.Show(exInserare.Message);
                    }

                    // Ne deconectam
                    finally
                    {
                        conexiune_InserareCerereRelInt.Close();
                    }
                }
            }
            
            // Efectuam
            if (System.Windows.Forms.Application.OpenForms["frmGCD"] != null)
            {
                (System.Windows.Forms.Application.OpenForms["frmGCD"] as frmGCD).AprobareVerifDGFM();
            }

        }
        /* --------------------------------------------------------------------------------------------------------------- */





    }
}
