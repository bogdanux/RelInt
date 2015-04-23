using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Odbc;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RelInt___Gestiune_cereri_de_deplasare
{
    public partial class frmEditareRector : Form
    {
        public frmEditareRector() // Metoda de LOAD
        {
            InitializeComponent();

            // Incarcam urmatoarele
            IncarcaredgvRector();
            IncarcaredgvProRector();

            // Dezactivam urmatoarele
            btnAdaugaR.Enabled = false;
            btnStergeR.Enabled = false;
            btnAdaugaPR.Enabled = false;
            btnStergePR.Enabled = false;
        }
        /* --------------------------------------------------------------------------------------------------------------- */










        /* ----------- Obiecte de lucru cu RelIntDB ---------------------------------------------------------------------- */
        // Sir de conectare al RelIntDB
        string sircon_RelIntDB = "DSN=PostgreSQL35W;database=RelIntDB;server=localhost;port=5432;UID=postgres;PWD=12345;sslmode=disable;readonly=0;protocol=7.4;fakeoidindex=0;showoidcolumn=0;rowversioning=0;showsystemtables=0;fetch=100;socket=4096;unknownsizes=0;maxvarcharsize=255;maxlongvarcharsize=8190;debug=0;commlog=0;optimizer=0;ksqo=1;usedeclarefetch=0;textaslongvarchar=1;unknownsaslongvarchar=0;boolsaschar=1;parse=0;cancelasfreestmt=0;extrasystableprefixes=dd_;lfconversion=1;updatablecursors=1;disallowpremature=0;trueisminus1=0;bi=0;byteaaslongvarbinary=0;useserversideprepare=1;lowercaseidentifier=0;gssauthusegss=0;xaopt=1;";

        /* --------------------------------------------------------------------------------------------------------------- */









        /* --------------------------------------------------------------------------------------------------------------- */
        private void btnIesire_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /* --------------------------------------------------------------------------------------------------------------- */








        /* --------------- Metoda de incarcare a dgvRector --------------------------------------------------------------- */
        private void IncarcaredgvRector()
        {
            using (OdbcConnection conexiune_dgvRector = new OdbcConnection(sircon_RelIntDB))
            {
                // Comanda
                using (OdbcCommand comanda_dgvRector = new OdbcCommand())
                {
                    comanda_dgvRector.Connection = conexiune_dgvRector;
                    comanda_dgvRector.CommandType = CommandType.Text;
                    comanda_dgvRector.CommandText = "SELECT rector AS \"Rector\", emailr AS \"E-mail\", telefonr AS \"Telefon\" FROM rectori";

                    try
                    {
                        conexiune_dgvRector.Open();
                        OdbcDataAdapter da_dgvRector = new OdbcDataAdapter();
                        da_dgvRector.SelectCommand = comanda_dgvRector;

                        DataTable dt_dgvRector = new DataTable();
                        da_dgvRector.Fill(dt_dgvRector);

                        BindingSource bs_dgvRector = new BindingSource();
                        bs_dgvRector.DataSource = dt_dgvRector;

                        dgvRector.DataSource = bs_dgvRector;

                        da_dgvRector.Update(dt_dgvRector);
                    }
                    catch (Exception exdgvRector)
                    {
                        MessageBox.Show(exdgvRector.Message);
                    } // Ne deconectam
                    finally
                    {
                        conexiune_dgvRector.Close();
                    }
                }
            }
        }
        /* --------------------------------------------------------------------------------------------------------------- */

        /* --------------------------------------------------------------------------------------------------------------- */
        private void btnAdaugaR_Click(object sender, EventArgs e)
        {
            using (OdbcConnection conexiune_dgvRector = new OdbcConnection(sircon_RelIntDB))
            {
                // Comanda
                using (OdbcCommand comanda_dgvRector = new OdbcCommand())
                {
                    comanda_dgvRector.Connection = conexiune_dgvRector;
                    comanda_dgvRector.CommandType = CommandType.Text;
                    comanda_dgvRector.CommandText = "INSERT INTO rectori VALUES (?, ?, ?)";
                    comanda_dgvRector.Parameters.AddWithValue("@rector", OdbcType.NVarChar).Value = txtRector.Text;
                    comanda_dgvRector.Parameters.AddWithValue("@emailr", OdbcType.NVarChar).Value = txtEmailR.Text;
                    comanda_dgvRector.Parameters.AddWithValue("@telefonr", OdbcType.Int).Value = txtTelefonR.Text;

                    try
                    {
                        conexiune_dgvRector.Open();
                        int recordsAffected = comanda_dgvRector.ExecuteNonQuery();
                    }
                    catch (Exception exdgvRector)
                    {
                        MessageBox.Show(exdgvRector.Message);
                    } // Ne deconectam
                    finally
                    {
                        conexiune_dgvRector.Close();
                    }
                }
            }

            // Actualizam "dgvGradDidactic"
            IncarcaredgvRector();

            // Golim campul "txtGradDidactic"
            txtRector.Clear();
            txtEmailR.Clear();
            txtTelefonR.Clear();
        }
        /* --------------------------------------------------------------------------------------------------------------- */

        /* --------------------------------------------------------------------------------------------------------------- */
        private void btnStergeR_Click(object sender, EventArgs e)
        {
            using (OdbcConnection conexiune_dgvRector = new OdbcConnection(sircon_RelIntDB))
            {
                // Comanda
                using (OdbcCommand comanda_dgvRector = new OdbcCommand())
                {
                    comanda_dgvRector.Connection = conexiune_dgvRector;
                    comanda_dgvRector.CommandType = CommandType.Text;
                    comanda_dgvRector.CommandText = "DELETE FROM rectori WHERE rector = ?";
                    comanda_dgvRector.Parameters.AddWithValue("@rector", OdbcType.NVarChar).Value = txtRector.Text;

                    try
                    {
                        conexiune_dgvRector.Open();
                        int recordsAffected = comanda_dgvRector.ExecuteNonQuery();
                    }
                    catch (Exception exdgvRector)
                    {
                        MessageBox.Show(exdgvRector.Message);
                    } // Ne deconectam
                    finally
                    {
                        conexiune_dgvRector.Close();
                    }
                }
            }

            // Actualizam "dgvGradDidactic"
            IncarcaredgvRector();

            // Golim campul "txtGradDidactic"
            txtRector.Clear();
            txtEmailR.Clear();
            txtTelefonR.Clear();
        }
        /* --------------------------------------------------------------------------------------------------------------- */

        /* --------------------------------------------------------------------------------------------------------------- */
        private void txtRector_TextChanged(object sender, EventArgs e)
        {
            if (txtRector.Text == string.Empty)
            {
                // Dezactivam urmatoarele
                btnAdaugaR.Enabled = false;
                btnStergeR.Enabled = false;
            }
            else
            {
                // Activam urmatoarele
                btnAdaugaR.Enabled = true;
                btnStergeR.Enabled = true;
            }
        }

        int vartxtTelefonR;
        private void txtTelefonR_TextChanged(object sender, EventArgs e)
        {
            // Verificam daca valoarea din "txtNrInregistrare" este de tip int si daca da, o inregistram in "vartxtNrInregistrare"
            bool vartxtTelefonREsteNumar = Int32.TryParse(txtTelefonR.Text, out vartxtTelefonR);

            // Judecam si "sanctionam" la nevoie
            switch (vartxtTelefonREsteNumar || txtTelefonR.Text == string.Empty)
            {
                case false:
                    // Golim casuta si afisam mesaj de eroare
                    txtTelefonR.Clear();
                    MessageBox.Show("        Vă rugăm introduceți doar numere în această casetă de text.");
                    break;
            }
        }
        /* --------------------------------------------------------------------------------------------------------------- */








        /* --------------- Metoda de incarcare a dgvRector --------------------------------------------------------------- */
        private void IncarcaredgvProRector()
        {
            using (OdbcConnection conexiune_dgvProRector = new OdbcConnection(sircon_RelIntDB))
            {
                // Comanda
                using (OdbcCommand comanda_dgvProRector = new OdbcCommand())
                {
                    comanda_dgvProRector.Connection = conexiune_dgvProRector;
                    comanda_dgvProRector.CommandType = CommandType.Text;
                    comanda_dgvProRector.CommandText = "SELECT prorector AS \"ProRectori\", emailp AS \"E-Mail\", telefonp1 AS \"Telefon 1\", telefonp2 AS \"Telefon 2\" FROM prorectori";

                    try
                    {
                        conexiune_dgvProRector.Open();
                        OdbcDataAdapter da_dgvProRector = new OdbcDataAdapter();
                        da_dgvProRector.SelectCommand = comanda_dgvProRector;

                        DataTable dt_dgvProRector = new DataTable();
                        da_dgvProRector.Fill(dt_dgvProRector);

                        BindingSource bs_dgvProRector = new BindingSource();
                        bs_dgvProRector.DataSource = dt_dgvProRector;

                        dgvProRector.DataSource = bs_dgvProRector;

                        da_dgvProRector.Update(dt_dgvProRector);
                    }
                    catch (Exception exdgvRector)
                    {
                        MessageBox.Show(exdgvRector.Message);
                    } // Ne deconectam
                    finally
                    {
                        conexiune_dgvProRector.Close();
                    }
                }
            }
        }
        /* --------------------------------------------------------------------------------------------------------------- */

        /* --------------------------------------------------------------------------------------------------------------- */
        private void btnAdaugaPR_Click(object sender, EventArgs e)
        {
            using (OdbcConnection conexiune_dgvProRector = new OdbcConnection(sircon_RelIntDB))
            {
                // Comanda
                using (OdbcCommand comanda_dgvProRector = new OdbcCommand())
                {
                    comanda_dgvProRector.Connection = conexiune_dgvProRector;
                    comanda_dgvProRector.CommandType = CommandType.Text;
                    comanda_dgvProRector.CommandText = "INSERT INTO prorectori VALUES (?, ?, ?, ?)";
                    comanda_dgvProRector.Parameters.AddWithValue("@prorector", OdbcType.NVarChar).Value = txtProRector.Text;
                    comanda_dgvProRector.Parameters.AddWithValue("@emailp", OdbcType.NVarChar).Value = txtEMailPR.Text;
                    comanda_dgvProRector.Parameters.AddWithValue("@telefonp1", OdbcType.Int).Value = txtTelefonPR1.Text;
                    comanda_dgvProRector.Parameters.AddWithValue("@telefonp2", OdbcType.Int).Value = txtTelefonPR2.Text;

                    try
                    {
                        conexiune_dgvProRector.Open();
                        int recordsAffected = comanda_dgvProRector.ExecuteNonQuery();
                    }
                    catch (Exception exdgvRector)
                    {
                        MessageBox.Show(exdgvRector.Message);
                    } // Ne deconectam
                    finally
                    {
                        conexiune_dgvProRector.Close();
                    }
                }
            }

            // Actualizam "dgvGradDidactic"
            IncarcaredgvProRector();

            // Golim campul "txtGradDidactic"
            txtProRector.Clear();
            txtEMailPR.Clear();
            txtTelefonPR1.Clear();
            txtTelefonPR2.Clear();
        }
        /* --------------------------------------------------------------------------------------------------------------- */

        /* --------------------------------------------------------------------------------------------------------------- */
        private void btnStergePR_Click(object sender, EventArgs e)
        {
            using (OdbcConnection conexiune_dgvRector = new OdbcConnection(sircon_RelIntDB))
            {
                // Comanda
                using (OdbcCommand comanda_dgvRector = new OdbcCommand())
                {
                    comanda_dgvRector.Connection = conexiune_dgvRector;
                    comanda_dgvRector.CommandType = CommandType.Text;
                    comanda_dgvRector.CommandText = "DELETE FROM prorectori WHERE prorector = ?";
                    comanda_dgvRector.Parameters.AddWithValue("@prorector", OdbcType.NVarChar).Value = txtProRector.Text;

                    try
                    {
                        conexiune_dgvRector.Open();
                        int recordsAffected = comanda_dgvRector.ExecuteNonQuery();
                    }
                    catch (Exception exdgvRector)
                    {
                        MessageBox.Show(exdgvRector.Message);
                    } // Ne deconectam
                    finally
                    {
                        conexiune_dgvRector.Close();
                    }
                }
            }

            // Actualizam "dgvGradDidactic"
            IncarcaredgvProRector();

            // Golim campul "txtGradDidactic"
            txtProRector.Clear();
            txtEMailPR.Clear();
            txtTelefonPR1.Clear();
            txtTelefonPR2.Clear();
        }
        /* --------------------------------------------------------------------------------------------------------------- */

        /* --------------------------------------------------------------------------------------------------------------- */
        private void txtProRector_TextChanged(object sender, EventArgs e)
        {
            if (txtProRector.Text == string.Empty)
            {
                // Dezactivam urmatoarele
                btnAdaugaPR.Enabled = false;
                btnStergePR.Enabled = false;
            }
            else
            {
                // Activam urmatoarele
                btnAdaugaPR.Enabled = true;
                btnStergePR.Enabled = true;
            }
        }

        int vartxtTelefonPR1;
        private void txtTelefonPR1_TextChanged(object sender, EventArgs e)
        {
            // Verificam daca valoarea din "txtNrInregistrare" este de tip int si daca da, o inregistram in "vartxtNrInregistrare"
            bool vartxtTelefonPR1EsteNumar = Int32.TryParse(txtTelefonPR1.Text, out vartxtTelefonPR1);

            // Judecam si "sanctionam" la nevoie
            switch (vartxtTelefonPR1EsteNumar || txtTelefonPR1.Text == string.Empty)
            {
                case false:
                    // Golim casuta si afisam mesaj de eroare
                    txtTelefonPR1.Clear();
                    MessageBox.Show("        Vă rugăm introduceți doar numere în această casetă de text.");
                    break;
            }
        }

        int vartxtTelefonPR2;
        private void txtTelefonPR2_TextChanged(object sender, EventArgs e)
        {
            // Verificam daca valoarea din "txtNrInregistrare" este de tip int si daca da, o inregistram in "vartxtNrInregistrare"
            bool vartxtTelefonPR2EsteNumar = Int32.TryParse(txtTelefonPR2.Text, out vartxtTelefonPR2);

            // Judecam si "sanctionam" la nevoie
            switch (vartxtTelefonPR2EsteNumar || txtTelefonPR2.Text == string.Empty)
            {
                case false:
                    // Golim casuta si afisam mesaj de eroare
                    txtTelefonPR2.Clear();
                    MessageBox.Show("        Vă rugăm introduceți doar numere în această casetă de text.");
                    break;
            }
        }
        /* --------------------------------------------------------------------------------------------------------------- */
    }
}
