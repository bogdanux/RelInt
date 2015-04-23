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
    public partial class frmTipuriIntrari : Form
    {
        public frmTipuriIntrari() // Metoda de LOAD
        {
            InitializeComponent();

            // Incarcare dgvGradDidactic
            IncarcaredgvGradDidactic();

            // Incarcare dgvFacultati
            IncarcaredgvFacultati();

            // Incarcare dgvMoneda
            IncarcaredgvMonezi();

            // Dezactivam urmatoarele
            btnIntroducereGD.Enabled = false;
            btnStergereGD.Enabled = false;
            btnIntroducereF.Enabled = false;
            btnStergereF.Enabled = false;
            btnIntroducereM.Enabled = false;
            btnStergereM.Enabled = false;
        }
        /* --------------------------------------------------------------------------------------------------------------- */










        /* ----------- Obiecte de lucru cu RelIntDB ---------------------------------------------------------------------- */
        // Sir de conectare al RelIntDB
        string sircon_RelIntDB = "DSN=PostgreSQL35W;database=RelIntDB;server=localhost;port=5432;UID=postgres;PWD=12345;sslmode=disable;readonly=0;protocol=7.4;fakeoidindex=0;showoidcolumn=0;rowversioning=0;showsystemtables=0;fetch=100;socket=4096;unknownsizes=0;maxvarcharsize=255;maxlongvarcharsize=8190;debug=0;commlog=0;optimizer=0;ksqo=1;usedeclarefetch=0;textaslongvarchar=1;unknownsaslongvarchar=0;boolsaschar=1;parse=0;cancelasfreestmt=0;extrasystableprefixes=dd_;lfconversion=1;updatablecursors=1;disallowpremature=0;trueisminus1=0;bi=0;byteaaslongvarbinary=0;useserversideprepare=1;lowercaseidentifier=0;gssauthusegss=0;xaopt=1;";

        /* --------------------------------------------------------------------------------------------------------------- */








        /* --------------- Eveniment de tip click pentru btnIesire ------------------------------------------------------- */
        private void btnIesire_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /* --------------------------------------------------------------------------------------------------------------- */










        /* -------------------- Functii pentru dgvGradDidactic ---------------------------------------------------------- */
        public void IncarcaredgvGradDidactic()
        {
            using (OdbcConnection conexiune_dgvGradDidactic = new OdbcConnection(sircon_RelIntDB))
            {
                // Comanda
                using (OdbcCommand comanda_dgvGradDidactic = new OdbcCommand())
                {
                    comanda_dgvGradDidactic.Connection = conexiune_dgvGradDidactic;
                    comanda_dgvGradDidactic.CommandType = CommandType.Text;
                    comanda_dgvGradDidactic.CommandText = "SELECT graddidacticgd AS \"Grade Didactice\" FROM gradedidactice";

                    try
                    {
                        conexiune_dgvGradDidactic.Open();
                        OdbcDataAdapter da_dgvOreRecuperate = new OdbcDataAdapter();
                        da_dgvOreRecuperate.SelectCommand = comanda_dgvGradDidactic;

                        DataTable dt_dgvOreRecuperate = new DataTable();
                        da_dgvOreRecuperate.Fill(dt_dgvOreRecuperate);

                        BindingSource bs_dgvOreRecuperate = new BindingSource();
                        bs_dgvOreRecuperate.DataSource = dt_dgvOreRecuperate;

                        dgvGradDidactic.DataSource = bs_dgvOreRecuperate;

                        da_dgvOreRecuperate.Update(dt_dgvOreRecuperate);
                    }
                    catch (Exception exdgvOreRecuperate)
                    {
                        MessageBox.Show(exdgvOreRecuperate.Message);
                    } // Ne deconectam
                    finally
                    {
                        conexiune_dgvGradDidactic.Close();
                    }
                }
            }
        }
        /* --------------------------------------------------------------------------------------------------------------- */

        /* ----------------- Eveniment de tip click pentru btnIntroducereGD ---------------------------------------------- */
        private void btnIntroducereGD_Click(object sender, EventArgs e)
        {
            using (OdbcConnection conexiune_dgvGradDidactic = new OdbcConnection(sircon_RelIntDB))
            {
                // Comanda
                using (OdbcCommand comanda_dgvGradDidactic = new OdbcCommand())
                {
                    comanda_dgvGradDidactic.Connection = conexiune_dgvGradDidactic;
                    comanda_dgvGradDidactic.CommandType = CommandType.Text;
                    comanda_dgvGradDidactic.CommandText = "INSERT INTO gradedidactice VALUES (?)";
                    comanda_dgvGradDidactic.Parameters.AddWithValue("@graddidacticgd", OdbcType.NVarChar).Value = txtGradDidactic.Text;

                    try
                    {
                        conexiune_dgvGradDidactic.Open();
                        int recordsAffected = comanda_dgvGradDidactic.ExecuteNonQuery();
                    }
                    catch (Exception dgvGradDidactic)
                    {
                        MessageBox.Show(dgvGradDidactic.Message);
                    } // Ne deconectam
                    finally
                    {
                        conexiune_dgvGradDidactic.Close();
                    }
                }
            }

            // Actualizam "dgvGradDidactic"
            IncarcaredgvGradDidactic();

            // Golim campul "txtGradDidactic"
            txtGradDidactic.Clear();
        }
        /* --------------------------------------------------------------------------------------------------------------- */

        /* ----------------- Eveniment de tip click pentru btnStergereGD ------------------------------------------------- */
        private void btnStergereGD_Click(object sender, EventArgs e)
        {
            using (OdbcConnection conexiune_dgvGradDidactic = new OdbcConnection(sircon_RelIntDB))
            {
                // Comanda
                using (OdbcCommand comanda_dgvGradDidactic = new OdbcCommand())
                {
                    comanda_dgvGradDidactic.Connection = conexiune_dgvGradDidactic;
                    comanda_dgvGradDidactic.CommandType = CommandType.Text;
                    comanda_dgvGradDidactic.CommandText = "DELETE FROM gradedidactice WHERE graddidacticgd = ?";
                    comanda_dgvGradDidactic.Parameters.AddWithValue("@graddidacticgd", OdbcType.NVarChar).Value = txtGradDidactic.Text;

                    try
                    {
                        conexiune_dgvGradDidactic.Open();
                        int recordsAffected = comanda_dgvGradDidactic.ExecuteNonQuery();
                    }
                    catch (Exception exdgvGradDidactic)
                    {
                        MessageBox.Show(exdgvGradDidactic.Message);
                    } // Ne deconectam
                    finally
                    {
                        conexiune_dgvGradDidactic.Close();
                    }
                }
            }

            // Actualizam "dgvGradDidactic"
            IncarcaredgvGradDidactic();

            // Golim campul "txtGradDidactic"
            txtGradDidactic.Clear();
        }
        /* --------------------------------------------------------------------------------------------------------------- */

        /* ----------------- Eveniment de tip TextChanged pentru caseta txtGradDidactic ---------------------------------- */
        private void txtGradDidactic_TextChanged(object sender, EventArgs e)
        {
            if (txtGradDidactic.Text == string.Empty)
            {
                // Dezactivam urmatoarele
                btnIntroducereGD.Enabled = false;
                btnStergereGD.Enabled = false;
            }
            else
            {
                // Activam urmatoarele
                btnIntroducereGD.Enabled = true;
                btnStergereGD.Enabled = true;
            }
        }
        /* --------------------------------------------------------------------------------------------------------------- */










        /* -------------------- Functii pentru dgvFacultati -------------------------------------------------------------- */
        public void IncarcaredgvFacultati()
        {
            using (OdbcConnection conexiune_dgvFacultati = new OdbcConnection(sircon_RelIntDB))
            {
                // Comanda
                using (OdbcCommand comanda_dgvFacultati = new OdbcCommand())
                {
                    comanda_dgvFacultati.Connection = conexiune_dgvFacultati;
                    comanda_dgvFacultati.CommandType = CommandType.Text;
                    comanda_dgvFacultati.CommandText = "SELECT facultatif AS \"Facultati\" FROM facultati";

                    try
                    {
                        conexiune_dgvFacultati.Open();
                        OdbcDataAdapter da_dgvFacultati = new OdbcDataAdapter();
                        da_dgvFacultati.SelectCommand = comanda_dgvFacultati;

                        DataTable dt_dgvFacultati = new DataTable();
                        da_dgvFacultati.Fill(dt_dgvFacultati);

                        BindingSource bs_dgvFacultati = new BindingSource();
                        bs_dgvFacultati.DataSource = dt_dgvFacultati;

                        dgvFacultate.DataSource = bs_dgvFacultati;

                        da_dgvFacultati.Update(dt_dgvFacultati);
                    }
                    catch (Exception exdgvFacultati)
                    {
                        MessageBox.Show(exdgvFacultati.Message);
                    } // Ne deconectam
                    finally
                    {
                        conexiune_dgvFacultati.Close();
                    }
                }
            }
        }
        /* --------------------------------------------------------------------------------------------------------------- */

        /* ----------------- Eveniment de tip click pentru btnIntroducereF ----------------------------------------------- */
        private void btnIntroducereF_Click(object sender, EventArgs e)
        {
            using (OdbcConnection conexiune_dgvFacultate = new OdbcConnection(sircon_RelIntDB))
            {
                // Comanda
                using (OdbcCommand comanda_dgvFacultate = new OdbcCommand())
                {
                    comanda_dgvFacultate.Connection = conexiune_dgvFacultate;
                    comanda_dgvFacultate.CommandType = CommandType.Text;
                    comanda_dgvFacultate.CommandText = "INSERT INTO facultati VALUES (?)";
                    comanda_dgvFacultate.Parameters.AddWithValue("@facultatif", OdbcType.NVarChar).Value = txtFacultate.Text;

                    try
                    {
                        conexiune_dgvFacultate.Open();
                        int recordsAffected = comanda_dgvFacultate.ExecuteNonQuery();
                    }
                    catch (Exception dgvFacultati)
                    {
                        MessageBox.Show(dgvFacultati.Message);
                    } // Ne deconectam
                    finally
                    {
                        conexiune_dgvFacultate.Close();
                    }
                }
            }

            // Actualizam "IncarcaredgvFacultati"
            IncarcaredgvFacultati();

            // Golim campul "IncarcaredgvFacultati"
            txtFacultate.Clear();
        }

        /* ----------------- Eveniment de tip click pentru btnStergereF -------------------------------------------------- */
        private void btnStergereF_Click(object sender, EventArgs e)
        {
            using (OdbcConnection conexiune_dgvFacultate = new OdbcConnection(sircon_RelIntDB))
            {
                // Comanda
                using (OdbcCommand comanda_dgvFacultate = new OdbcCommand())
                {
                    comanda_dgvFacultate.Connection = conexiune_dgvFacultate;
                    comanda_dgvFacultate.CommandType = CommandType.Text;
                    comanda_dgvFacultate.CommandText = "DELETE FROM facultati WHERE facultatif = ?";
                    comanda_dgvFacultate.Parameters.AddWithValue("@facultatif", OdbcType.NVarChar).Value = txtFacultate.Text;

                    try
                    {
                        conexiune_dgvFacultate.Open();
                        int recordsAffected = comanda_dgvFacultate.ExecuteNonQuery();
                    }
                    catch (Exception dgvFacultati)
                    {
                        MessageBox.Show(dgvFacultati.Message);
                    } // Ne deconectam
                    finally
                    {
                        conexiune_dgvFacultate.Close();
                    }
                }
            }

            // Actualizam "dgvGradDidactic"
            IncarcaredgvFacultati();

            // Golim campul "txtGradDidactic"
            txtFacultate.Clear();
        }
        /* --------------------------------------------------------------------------------------------------------------- */

        /* ----------------- Eveniment de tip TextChanged pentru caseta txtFacultate ------------------------------------- */
        private void txtFacultate_TextChanged(object sender, EventArgs e)
        {
            if (txtFacultate.Text == string.Empty)
            {
                // Dezactivam urmatoarele
                btnIntroducereF.Enabled = false;
                btnStergereF.Enabled = false;
            }
            else
            {
                // Activam urmatoarele
                btnIntroducereF.Enabled = true;
                btnStergereF.Enabled = true;
            }
        }
        /* --------------------------------------------------------------------------------------------------------------- */










        /* -------------------- Functii pentru dgvFacultati -------------------------------------------------------------- */
        public void IncarcaredgvMonezi()
        {
            using (OdbcConnection conexiune_dgvMoneda = new OdbcConnection(sircon_RelIntDB))
            {
                // Comanda
                using (OdbcCommand comanda_dgvMoneda = new OdbcCommand())
                {
                    comanda_dgvMoneda.Connection = conexiune_dgvMoneda;
                    comanda_dgvMoneda.CommandType = CommandType.Text;
                    comanda_dgvMoneda.CommandText = "SELECT monezim AS \"Monezi\" FROM monezi";

                    try
                    {
                        conexiune_dgvMoneda.Open();
                        OdbcDataAdapter da_dgvMoneda = new OdbcDataAdapter();
                        da_dgvMoneda.SelectCommand = comanda_dgvMoneda;

                        DataTable dt_dgvMoneda = new DataTable();
                        da_dgvMoneda.Fill(dt_dgvMoneda);

                        BindingSource bs_dgvMoneda = new BindingSource();
                        bs_dgvMoneda.DataSource = dt_dgvMoneda;

                        dgvMoneda.DataSource = bs_dgvMoneda;

                        da_dgvMoneda.Update(dt_dgvMoneda);
                    }
                    catch (Exception exdgvMoneda)
                    {
                        MessageBox.Show(exdgvMoneda.Message);
                    } // Ne deconectam
                    finally
                    {
                        conexiune_dgvMoneda.Close();
                    }
                }
            }
        }
        /* --------------------------------------------------------------------------------------------------------------- */

        /* ----------------- Eveniment de tip click pentru btnIntroducereF ----------------------------------------------- */
        private void btnIntroducereM_Click(object sender, EventArgs e)
        {
            using (OdbcConnection conexiune_dgvMoneda = new OdbcConnection(sircon_RelIntDB))
            {
                // Comanda
                using (OdbcCommand comanda_dgvMoneda = new OdbcCommand())
                {
                    comanda_dgvMoneda.Connection = conexiune_dgvMoneda;
                    comanda_dgvMoneda.CommandType = CommandType.Text;
                    comanda_dgvMoneda.CommandText = "INSERT INTO monezi VALUES (?)";
                    comanda_dgvMoneda.Parameters.AddWithValue("@monezim", OdbcType.NVarChar).Value = txtMoneda.Text;

                    try
                    {
                        conexiune_dgvMoneda.Open();
                        int recordsAffected = comanda_dgvMoneda.ExecuteNonQuery();
                    }
                    catch (Exception dgvMoneda)
                    {
                        MessageBox.Show(dgvMoneda.Message);
                    } // Ne deconectam
                    finally
                    {
                        conexiune_dgvMoneda.Close();
                    }
                }
            }

            // Actualizam "dgvGradDidactic"
            IncarcaredgvMonezi();

            // Golim campul "txtGradDidactic"
            txtMoneda.Clear();
        }

        /* ----------------- Eveniment de tip click pentru btnStergereF -------------------------------------------------- */
        private void btnStergereM_Click(object sender, EventArgs e)
        {
            using (OdbcConnection conexiune_dgvMoneda = new OdbcConnection(sircon_RelIntDB))
            {
                // Comanda
                using (OdbcCommand comanda_dgvMoneda = new OdbcCommand())
                {
                    comanda_dgvMoneda.Connection = conexiune_dgvMoneda;
                    comanda_dgvMoneda.CommandType = CommandType.Text;
                    comanda_dgvMoneda.CommandText = "DELETE FROM monezi WHERE monezim = ?";
                    comanda_dgvMoneda.Parameters.AddWithValue("@monezim", OdbcType.NVarChar).Value = txtMoneda.Text;

                    try
                    {
                        conexiune_dgvMoneda.Open();
                        int recordsAffected = comanda_dgvMoneda.ExecuteNonQuery();
                    }
                    catch (Exception dgvMoneda)
                    {
                        MessageBox.Show(dgvMoneda.Message);
                    } // Ne deconectam
                    finally
                    {
                        conexiune_dgvMoneda.Close();
                    }
                }
            }

            // Actualizam "dgvGradDidactic"
            IncarcaredgvMonezi();

            // Golim campul "txtGradDidactic"
            txtMoneda.Clear();
        }
        /* --------------------------------------------------------------------------------------------------------------- */

        /* ----------------- Eveniment de tip TextChanged pentru caseta txtFacultate ------------------------------------- */
        private void txtMoneda_TextChanged(object sender, EventArgs e)
        {
            if (txtMoneda.Text == string.Empty)
            {
                // Dezactivam urmatoarele
                btnIntroducereM.Enabled = false;
                btnStergereM.Enabled = false;
            }
            else
            {
                // Activam urmatoarele
                btnIntroducereM.Enabled = true;
                btnStergereM.Enabled = true;
            }
        }
        /* --------------------------------------------------------------------------------------------------------------- */
    }
}
