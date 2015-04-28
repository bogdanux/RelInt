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
    public partial class frmEditTipuriIntrari : Form
    {
        public frmEditTipuriIntrari() // Metoda de LOAD
        {
            InitializeComponent();

            // Incarcare dgvGradDidactic
            IncarcaredgvGradDidactic();

            // Incarcare dgvFacultati
            IncarcaredgvFacultati();

            // Incarcare dgvMoneda
            IncarcaredgvMonezi();

            // Dezactivam urmatoarele (GD)
            lblIntroducereGD.Enabled = false;
            txtIntroducereGD.Enabled = false;
            lblGDVechi.Enabled = false;
            lblGDNou.Enabled = false;
            txtGDVechi.Enabled = false;
            txtGDNou.Enabled = false;
            btnIntroducereGD.Enabled = false;
            btnModificareGD.Enabled = false;

            // Dezactivam urmatoarele (F)
            lblIntroducereF.Enabled = false;
            txtIntroducereF.Enabled = false;
            lblFVeche.Enabled = false;
            lblFNoua.Enabled = false;
            txtFVeche.Enabled = false;
            txtFNoua.Enabled = false;
            btnIntroducereF.Enabled = false;
            btnModificareF.Enabled = false;

            // Dezactivam urmatoarele (M)
            lblIntroducereM.Enabled = false;
            txtIntroducereM.Enabled = false;
            lblMVeche.Enabled = false;
            lblMNoua.Enabled = false;
            txtMVeche.Enabled = false;
            txtMNoua.Enabled = false;
            btnIntroducereM.Enabled = false;
            btnModificareM.Enabled = false;
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









        /* ------------------- Activam Campurile prin rdoIntroducereGD --------------------------------------------------- */
        private void rdoIntroducereGD_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoIntroducereGD.Checked)
            {
                // Activam
                lblIntroducereGD.Enabled = true;
                txtIntroducereGD.Enabled = true;

                // Dezactivam
                lblGDVechi.Enabled = false;
                lblGDNou.Enabled = false;
                txtGDVechi.Enabled = false;
                txtGDNou.Enabled = false;
                btnModificareGD.Enabled = false;
            }
            else
            {
                // Dezactivam
                lblIntroducereGD.Enabled = false;
                txtIntroducereGD.Enabled = false;
                btnIntroducereGD.Enabled = false;
            }
        }
        /* --------------------------------------------------------------------------------------------------------------- */
        /* ---------------------- Activam campurile prin rdoModificareGD ------------------------------------------------- */
        private void rdoModificareGD_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoModificareGD.Checked)
            {
                // Activam
                lblGDVechi.Enabled = true;
                lblGDNou.Enabled = true;
                txtGDVechi.Enabled = true;
                txtGDNou.Enabled = true;

                // Dezactivam
                lblIntroducereGD.Enabled = false;
                txtIntroducereGD.Enabled = false;
                btnIntroducereGD.Enabled = false;
            }
            else
            {
                // Dezactivam
                lblGDVechi.Enabled = false;
                lblGDNou.Enabled = false;
                txtGDVechi.Enabled = false;
                txtGDNou.Enabled = false;
                btnModificareGD.Enabled = false;
            }
        }
        /* --------------------------------------------------------------------------------------------------------------- */
        /* -------------------- Functii pentru dgvGradDidactic ----------------------------------------------------------- */
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

            // Efectuam metoda:
            if (System.Windows.Forms.Application.OpenForms["frmGCD"] != null)
            {
                (System.Windows.Forms.Application.OpenForms["frmGCD"] as frmGCD).VerificareGradeDidactice();
            }

            // Apoi metoda:
            if (System.Windows.Forms.Application.OpenForms["frmGCD"] != null)
            {
                (System.Windows.Forms.Application.OpenForms["frmGCD"] as frmGCD).AprobareVerifDGFM();
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
                    comanda_dgvGradDidactic.Parameters.AddWithValue("@graddidacticgd", OdbcType.NVarChar).Value = txtIntroducereGD.Text;

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
            txtIntroducereGD.Clear();
        }
        /* --------------------------------------------------------------------------------------------------------------- */
        /* ----------------- Eveniment de tip click pentru btnStergereGD ------------------------------------------------- */
        private void btnModificareGD_Click(object sender, EventArgs e)
        {
            using (OdbcConnection conexiune_dgvGradDidactic = new OdbcConnection(sircon_RelIntDB))
            {
                // Comanda
                using (OdbcCommand comanda_dgvGradDidactic = new OdbcCommand())
                {
                    comanda_dgvGradDidactic.Connection = conexiune_dgvGradDidactic;
                    comanda_dgvGradDidactic.CommandType = CommandType.Text;
                    comanda_dgvGradDidactic.CommandText = "UPDATE gradedidactice SET graddidacticgd = ? WHERE graddidacticgd = ?";
                    comanda_dgvGradDidactic.Parameters.AddWithValue("@graddidacticgd", OdbcType.NVarChar).Value = txtGDNou.Text;
                    comanda_dgvGradDidactic.Parameters.AddWithValue("@graddidacticgd", OdbcType.NVarChar).Value = txtGDVechi.Text;

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

            // Actualizam
            IncarcaredgvGradDidactic();

            // Golim campurile
            txtGDVechi.Clear();
            txtGDNou.Clear();

            // Actualizam statusul de pe "frmGCD"
            if (System.Windows.Forms.Application.OpenForms["frmGCD"] != null)
            {
                (System.Windows.Forms.Application.OpenForms["frmGCD"] as frmGCD).VerificareGradeDidactice();
            }
        }
        /* --------------------------------------------------------------------------------------------------------------- */
        /* ----------------- Eveniment de tip TextChanged pentru caseta txtGradDidactic ---------------------------------- */
        private void txtIntroducereGD_TextChanged(object sender, EventArgs e)
        {
            if (txtIntroducereGD.Text != string.Empty)
            {
                // Activam
                btnIntroducereGD.Enabled = true;
            }
            else
            {
                // Dezactivam
                btnIntroducereGD.Enabled = false;
            }
        }
        /* --------------------------------------------------------------------------------------------------------------- */
        /* --------------------- Evenimentul casetei txtGDNou ------------------------------------------------------------ */
        private void txtGDNou_TextChanged(object sender, EventArgs e)
        {
            if (txtGDNou.Text != string.Empty)
            {
                btnModificareGD.Enabled = true;
            }
            else
            {
                btnModificareGD.Enabled = false;
            }
        }
        /* --------------------------------------------------------------------------------------------------------------- */










        /* ------------------- Activam Campurile prin rdoIntroducereGD --------------------------------------------------- */
        private void rdoIntroducereF_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoIntroducereF.Checked)
            {
                // Activam
                lblIntroducereF.Enabled = true;
                txtIntroducereF.Enabled = true;

                // Dezactivam
                lblFVeche.Enabled = false;
                lblFNoua.Enabled = false;
                txtFVeche.Enabled = false;
                txtFNoua.Enabled = false;
                btnModificareF.Enabled = false;
            }
            else
            {
                // Dezactivam
                lblIntroducereF.Enabled = false;
                txtIntroducereF.Enabled = false;
                btnIntroducereF.Enabled = false;
            }
        }
        /* --------------------------------------------------------------------------------------------------------------- */
        /* ---------------------- Activam campurile prin rdoModificareGD ------------------------------------------------- */
        private void rdoModificareF_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoModificareF.Checked)
            {
                // Activam
                lblFVeche.Enabled = true;
                lblFNoua.Enabled = true;
                txtFVeche.Enabled = true;
                txtFNoua.Enabled = true;

                // Dezactivam
                lblIntroducereF.Enabled = false;
                txtIntroducereF.Enabled = false;
                btnIntroducereF.Enabled = false;
            }
            else
            {
                // Dezactivam
                lblFVeche.Enabled = false;
                lblFNoua.Enabled = false;
                txtFVeche.Enabled = false;
                txtFNoua.Enabled = false;
                btnModificareF.Enabled = false;
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

            // Efectuam metoda:
            if (System.Windows.Forms.Application.OpenForms["frmGCD"] != null)
            {
                (System.Windows.Forms.Application.OpenForms["frmGCD"] as frmGCD).VerificareFacultati();
            }

            // Apoi metoda:
            if (System.Windows.Forms.Application.OpenForms["frmGCD"] != null)
            {
                (System.Windows.Forms.Application.OpenForms["frmGCD"] as frmGCD).AprobareVerifDGFM();
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
                    comanda_dgvFacultate.Parameters.AddWithValue("@facultatif", OdbcType.NVarChar).Value = txtIntroducereF.Text;

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

            // Actualizam
            IncarcaredgvFacultati();

            // Golim campul
            txtIntroducereF.Clear();
        }
        /* ----------------- Eveniment de tip click pentru btnStergereF -------------------------------------------------- */
        private void btnModificareF_Click(object sender, EventArgs e)
        {
            using (OdbcConnection conexiune_dgvFacultate = new OdbcConnection(sircon_RelIntDB))
            {
                // Comanda
                using (OdbcCommand comanda_dgvFacultate = new OdbcCommand())
                {
                    comanda_dgvFacultate.Connection = conexiune_dgvFacultate;
                    comanda_dgvFacultate.CommandType = CommandType.Text;
                    //comanda_dgvFacultate.CommandText = "DELETE FROM facultati WHERE facultatif = ?";
                    comanda_dgvFacultate.CommandText = "UPDATE facultati SET facultatif = ? WHERE facultatif = ?";
                    comanda_dgvFacultate.Parameters.AddWithValue("@facultatif", OdbcType.NVarChar).Value = txtFNoua.Text;
                    comanda_dgvFacultate.Parameters.AddWithValue("@facultatif", OdbcType.NVarChar).Value = txtFVeche.Text;

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

            // Actualizam
            IncarcaredgvFacultati();

            // Golim campurile
            txtFVeche.Clear();
            txtFNoua.Clear();
        }
        /* --------------------------------------------------------------------------------------------------------------- */
        /* ----------------- Eveniment de tip TextChanged pentru caseta txtFacultate ------------------------------------- */
        private void txtIntroducereF_TextChanged(object sender, EventArgs e)
        {
            if (txtIntroducereF.Text != string.Empty)
            {
                // Activam
                btnIntroducereF.Enabled = true;
            }
            else
            {
                // Dezactivam
                btnIntroducereF.Enabled = false;
            }
        }
        /* --------------------------------------------------------------------------------------------------------------- */
        /* --------------------- Evenimentul casetei txtFNoua ------------------------------------------------------------ */
        private void txtFNoua_TextChanged(object sender, EventArgs e)
        {
            if (txtFNoua.Text != string.Empty)
            {
                btnModificareF.Enabled = true;
            }
            else
            {
                btnModificareF.Enabled = false;
            }
        }
        /* --------------------------------------------------------------------------------------------------------------- */









        /* ------------------- Activam Campurile prin rdoIntroducereGD --------------------------------------------------- */
        private void rdoIntroducereM_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoIntroducereM.Checked)
            {
                // Activam
                lblIntroducereM.Enabled = true;
                txtIntroducereM.Enabled = true;

                // Dezactivam
                lblMVeche.Enabled = false;
                lblMNoua.Enabled = false;
                txtMVeche.Enabled = false;
                txtMNoua.Enabled = false;
                btnModificareM.Enabled = false;
            }
            else
            {
                // Dezactivam
                lblIntroducereM.Enabled = false;
                txtIntroducereM.Enabled = false;
                btnIntroducereM.Enabled = false;
            }
        }
        /* --------------------------------------------------------------------------------------------------------------- */
        /* ---------------------- Activam campurile prin rdoModificareGD ------------------------------------------------- */
        private void rdoModificareM_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoModificareM.Checked)
            {
                // Activam
                lblMVeche.Enabled = true;
                lblMNoua.Enabled = true;
                txtMVeche.Enabled = true;
                txtMNoua.Enabled = true;

                // Dezactivam
                lblIntroducereM.Enabled = false;
                txtIntroducereM.Enabled = false;
                btnIntroducereM.Enabled = false;
            }
            else
            {
                // Dezactivam
                lblMVeche.Enabled = false;
                lblMNoua.Enabled = false;
                txtMVeche.Enabled = false;
                txtMNoua.Enabled = false;
                btnModificareM.Enabled = false;
            }
        }
        /* --------------------------------------------------------------------------------------------------------------- */
        /* -------------------- Functii pentru dgvMonezi ----------------------------------------------------------------- */
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

            // Efectuam metoda:
            if (System.Windows.Forms.Application.OpenForms["frmGCD"] != null)
            {
                (System.Windows.Forms.Application.OpenForms["frmGCD"] as frmGCD).VerificareMonezi();
            }

            // Apoi metoda:
            if (System.Windows.Forms.Application.OpenForms["frmGCD"] != null)
            {
                (System.Windows.Forms.Application.OpenForms["frmGCD"] as frmGCD).AprobareVerifDGFM();
            }
        }
        /* --------------------------------------------------------------------------------------------------------------- */
        /* ----------------- Eveniment de tip click pentru btnIntroducereM ----------------------------------------------- */
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
                    comanda_dgvMoneda.Parameters.AddWithValue("@monezim", OdbcType.NVarChar).Value = txtIntroducereM.Text;

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
            txtIntroducereM.Clear();
        }
        /* ----------------- Eveniment de tip click pentru btnStergereM -------------------------------------------------- */
        private void btnModificareM_Click(object sender, EventArgs e)
        {
            using (OdbcConnection conexiune_dgvMoneda = new OdbcConnection(sircon_RelIntDB))
            {
                // Comanda
                using (OdbcCommand comanda_dgvMoneda = new OdbcCommand())
                {
                    comanda_dgvMoneda.Connection = conexiune_dgvMoneda;
                    comanda_dgvMoneda.CommandType = CommandType.Text;
                    comanda_dgvMoneda.CommandText = "UPDATE monezi SET monezim = ? WHERE monezim = ?";
                    comanda_dgvMoneda.Parameters.AddWithValue("@monezim", OdbcType.NVarChar).Value = txtMNoua.Text;
                    comanda_dgvMoneda.Parameters.AddWithValue("@monezim", OdbcType.NVarChar).Value = txtMVeche.Text;

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

            // Actualizam
            IncarcaredgvMonezi();

            // Golim campurile
            txtMVeche.Clear();
            txtMNoua.Clear();
        }
        /* --------------------------------------------------------------------------------------------------------------- */
        /* ----------------- Eveniment de tip TextChanged pentru caseta txtMonezi ---------------------------------------- */
        private void txtIntroducereM_TextChanged(object sender, EventArgs e)
        {
            if (txtIntroducereM.Text != string.Empty)
            {
                // Activam
                btnIntroducereM.Enabled = true;
            }
            else
            {
                // Dezactivam
                btnIntroducereM.Enabled = false;
            }
        }
        /* --------------------------------------------------------------------------------------------------------------- */
        /* ----------------- Eveniment de tip TextChanged pentru caseta txtMonezi ---------------------------------------- */
        private void txtMNoua_TextChanged(object sender, EventArgs e)
        {
            if (txtMNoua.Text != string.Empty)
            {
                // Activam
                btnModificareM.Enabled = true;
            }
            else
            {
                // Dezactivam
                btnModificareM.Enabled = false;
            }
        }
        /* --------------------------------------------------------------------------------------------------------------- */






    }
}
