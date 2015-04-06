using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Odbc;

namespace RelInt___Gestiune_cereri_de_deplasare
{
    public partial class frmCautareCerere : Form
    {
        public frmCautareCerere() // Metoda LOAD
        {
            InitializeComponent();
        }
        /* --------------------------------------------------------------------------------------------------------------- */





        /* ----------- Obiecte de lucru cu RelIntDB ---------------------------------------------------------------------- */
        // Sir de conectare al RelIntDB
        string sircon_RelIntDB = "DSN=PostgreSQL35W;database=RelIntDB;server=localhost;port=5432;UID=postgres;PWD=12345;sslmode=disable;readonly=0;protocol=7.4;fakeoidindex=0;showoidcolumn=0;rowversioning=0;showsystemtables=0;fetch=100;socket=4096;unknownsizes=0;maxvarcharsize=255;maxlongvarcharsize=8190;debug=0;commlog=0;optimizer=0;ksqo=1;usedeclarefetch=0;textaslongvarchar=1;unknownsaslongvarchar=0;boolsaschar=1;parse=0;cancelasfreestmt=0;extrasystableprefixes=dd_;lfconversion=1;updatablecursors=1;disallowpremature=0;trueisminus1=0;bi=0;byteaaslongvarbinary=0;useserversideprepare=1;lowercaseidentifier=0;gssauthusegss=0;xaopt=1;";

        /* --------------------------------------------------------------------------------------------------------------- */







        /* ------------- Eveniment pentru btnIesire ---------------------------------------------------------------------- */
        private void btnIesire_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /* --------------------------------------------------------------------------------------------------------------- */



        /* ------------- Variabile de lucru pentru filtrare -------------------------------------------------------------- */
        DataTable dt_dgvCautare;
        /* --------------------------------------------------------------------------------------------------------------- */


        /* -------------------- Evenimente pentru casetele de text folosite la filtrare ---------------------------------- */
        private void txtNumePren_TextChanged(object sender, EventArgs e)
        {
            //DataView dv_filtrare = new DataView(dt_dgvCautare);
            //dv_filtrare.RowFilter = string.Format("subsemnatulc LIKE '%{0}%'", txtNumePren.Text);
            //dgvCautare.DataSource = dv_filtrare;

            using (OdbcConnection conexiune_dgvCautare = new OdbcConnection(sircon_RelIntDB))
            {           // Comanda
                using (OdbcCommand comanda_dgvCautare = new OdbcCommand())
                {
                    comanda_dgvCautare.Connection = conexiune_dgvCautare;
                    comanda_dgvCautare.CommandType = CommandType.Text;
                    comanda_dgvCautare.CommandText = "SELECT nrinregistrarec as \"Nr. Inregistrare\", subsemnatulc as \"Nume Prenume\", graddidacticc as \"Grad Didactic\", tarac as \"Tara\", localitateac as \"Localitatea\" FROM cereri WHERE subsemnatulc = ?";
                    comanda_dgvCautare.Parameters.AddWithValue("@subsemnatulc", OdbcType.NVarChar).Value = txtNumePren.Text;

                    try
                    {
                        conexiune_dgvCautare.Open();
                        OdbcDataAdapter da_dgvCautare = new OdbcDataAdapter();
                        da_dgvCautare.SelectCommand = comanda_dgvCautare;

                        dt_dgvCautare = new DataTable();
                        da_dgvCautare.Fill(dt_dgvCautare);

                        BindingSource bs_dgvCautare = new BindingSource();
                        bs_dgvCautare.DataSource = dt_dgvCautare;

                        dgvCautare.DataSource = bs_dgvCautare;

                        da_dgvCautare.Update(dt_dgvCautare);
                    }
                    catch (Exception exdgvCautare)
                    {
                        MessageBox.Show(exdgvCautare.Message);
                    } // Ne deconectam
                    finally
                    {
                        conexiune_dgvCautare.Close();
                    }
                }
            }
        }

        private void txtGradDidactic_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtTara_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtLocalitatea_TextChanged(object sender, EventArgs e)
        {

        }
        /* --------------------------------------------------------------------------------------------------------------- */
    }
}
