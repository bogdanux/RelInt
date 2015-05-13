using System;
using System.Data;
using System.Data.Odbc;
using System.Windows.Forms;

namespace RelInt___Gestiune_cereri_de_deplasare
{
    public partial class frmEditTipuriIntrari : Form
    {
        public frmEditTipuriIntrari() // Metoda de LOAD
        {
            InitializeComponent();

            // Incarcam
            IncarcaredgvGradDidactic();
            IncarcaredgvFacultati();
            IncarcaredgvMonezi();
            IncarcaredgvTari();
            IncarcaredgvScopuri();
            IncarcaredgvSC();
            IncarcaredgvSA();
        }
        /* --------------------------------------------------------------------------------------------------------------- */










        /* ----------- Obiecte de lucru cu RelIntDB ---------------------------------------------------------------------- */
        // Sir de conectare al RelIntDB
        string sircon_RelIntDB = "DSN=PostgreSQL35W;database=RelIntDB;server=localhost;port=5432;UID=postgres;PWD=12345;sslmode=disable;readonly=0;protocol=7.4;fakeoidindex=0;showoidcolumn=0;rowversioning=0;showsystemtables=0;fetch=100;socket=4096;unknownsizes=0;maxvarcharsize=255;maxlongvarcharsize=8190;debug=0;commlog=0;optimizer=0;ksqo=1;usedeclarefetch=0;textaslongvarchar=1;unknownsaslongvarchar=0;boolsaschar=1;parse=0;cancelasfreestmt=0;extrasystableprefixes=dd_;lfconversion=1;updatablecursors=1;disallowpremature=0;trueisminus1=0;bi=0;byteaaslongvarbinary=0;useserversideprepare=1;lowercaseidentifier=0;gssauthusegss=0;xaopt=1;";

        /* --------------------------------------------------------------------------------------------------------------- */








        /* --------------- Eveniment de tip click pentru btnIesire ------------------------------------------------------- */
        private void btnIesire_Click(object sender, EventArgs e)
        {
            Close();
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

            // Efectuam
            if (System.Windows.Forms.Application.OpenForms["frmGCD"] != null)
            {
                (System.Windows.Forms.Application.OpenForms["frmGCD"] as frmGCD).VerificareGradeDidactice();
            }

            if (System.Windows.Forms.Application.OpenForms["frmGCD"] != null)
            {
                (System.Windows.Forms.Application.OpenForms["frmGCD"] as frmGCD).AprobareVerifGDFMTSCA();
            }

            if (System.Windows.Forms.Application.OpenForms["frmCerereInregistrare"] != null)
            {
                (System.Windows.Forms.Application.OpenForms["frmCerereInregistrare"] as frmCerereInregistrare).UmplereGradDidactic();
            }

            if (System.Windows.Forms.Application.OpenForms["frmCerereModificare"] != null)
            {
                (System.Windows.Forms.Application.OpenForms["frmCerereModificare"] as frmCerereModificare).UmplereGradDidactic();
            }

            if (System.Windows.Forms.Application.OpenForms["frmODDIntroducere"] != null)
            {
                (System.Windows.Forms.Application.OpenForms["frmODDIntroducere"] as frmODDIntroducere).UmplereGradDidactic();
            }

            if (System.Windows.Forms.Application.OpenForms["frmODDModificare"] != null)
            {
                (System.Windows.Forms.Application.OpenForms["frmODDModificare"] as frmODDModificare).UmplereGradDidactic();
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

            // Actualizam
            IncarcaredgvGradDidactic();

            // Golim
            txtIntroducereGD.Clear();
            txtIntroducereGD.Focus();
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
            txtGDVechi.Focus();

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










        /* ------------------- Activam Campurile prin rdoIntroducereF ---------------------------------------------------- */
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
        /* ---------------------- Activam campurile prin rdoModificareF -------------------------------------------------- */
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
                (System.Windows.Forms.Application.OpenForms["frmGCD"] as frmGCD).AprobareVerifGDFMTSCA();
            }

            if (System.Windows.Forms.Application.OpenForms["frmCerereInregistrare"] != null)
            {
                (System.Windows.Forms.Application.OpenForms["frmCerereInregistrare"] as frmCerereInregistrare).UmplereFacultate();
            }

            if (System.Windows.Forms.Application.OpenForms["frmCerereModificare"] != null)
            {
                (System.Windows.Forms.Application.OpenForms["frmCerereModificare"] as frmCerereModificare).UmplereFacultate();
            }

            if (System.Windows.Forms.Application.OpenForms["frmODDIntroducere"] != null)
            {
                (System.Windows.Forms.Application.OpenForms["frmODDIntroducere"] as frmODDIntroducere).UmplereFacultate();
            }

            if (System.Windows.Forms.Application.OpenForms["frmODDModificare"] != null)
            {
                (System.Windows.Forms.Application.OpenForms["frmODDModificare"] as frmODDModificare).UmplereFacultate();
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
            txtIntroducereF.Focus();
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
            txtFVeche.Focus();
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









        /* ------------------- Activam Campurile prin rdoIntroducereM ---------------------------------------------------- */
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
        /* ---------------------- Activam campurile prin rdoModificareM -------------------------------------------------- */
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
                (System.Windows.Forms.Application.OpenForms["frmGCD"] as frmGCD).AprobareVerifGDFMTSCA();
            }

            if (System.Windows.Forms.Application.OpenForms["frmCerereInregistrare"] != null)
            {
                (System.Windows.Forms.Application.OpenForms["frmCerereInregistrare"] as frmCerereInregistrare).UmplereMonezi();
            }

            if (System.Windows.Forms.Application.OpenForms["frmCerereModificare"] != null)
            {
                (System.Windows.Forms.Application.OpenForms["frmCerereModificare"] as frmCerereModificare).UmplereMonezi();
            }

            if (System.Windows.Forms.Application.OpenForms["frmODDIntroducere"] != null)
            {
                (System.Windows.Forms.Application.OpenForms["frmODDIntroducere"] as frmODDIntroducere).UmplereMonezi();
            }

            if (System.Windows.Forms.Application.OpenForms["frmODDModificare"] != null)
            {
                (System.Windows.Forms.Application.OpenForms["frmODDModificare"] as frmODDModificare).UmplereMonezi();
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

            // Actualizam
            IncarcaredgvMonezi();

            // Golim campul
            txtIntroducereM.Clear();
            txtIntroducereM.Focus();
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
            txtMVeche.Focus();
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









        /* ------------------- Activam Campurile prin rdoIntroducereT ---------------------------------------------------- */
        private void rdoIntroducereT_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoIntroducereT.Checked)
            {
                // Activam
                lblIntroducereT.Enabled = true;
                txtIntroducereT.Enabled = true;

                // Dezactivam
                lblTVeche.Enabled = false;
                lblTNoua.Enabled = false;
                txtTVeche.Enabled = false;
                txtTNoua.Enabled = false;
                btnModificareT.Enabled = false;
            }
            else
            {
                // Dezactivam
                lblIntroducereT.Enabled = false;
                txtIntroducereT.Enabled = false;
                btnIntroducereT.Enabled = false;
            }
        }
        /* --------------------------------------------------------------------------------------------------------------- */
        /* ---------------------- Activam campurile prin rdoModificareT -------------------------------------------------- */
        private void rdoModificareT_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoModificareT.Checked)
            {
                // Activam
                lblTVeche.Enabled = true;
                lblTNoua.Enabled = true;
                txtTVeche.Enabled = true;
                txtTNoua.Enabled = true;

                // Dezactivam
                lblIntroducereT.Enabled = false;
                txtIntroducereT.Enabled = false;
                btnIntroducereT.Enabled = false;
            }
            else
            {
                // Dezactivam
                lblTVeche.Enabled = false;
                lblTNoua.Enabled = false;
                txtTVeche.Enabled = false;
                txtTNoua.Enabled = false;
                btnModificareT.Enabled = false;
            }
        }
        /* --------------------------------------------------------------------------------------------------------------- */
        /* -------------------- Functii pentru dgvTari ------------------------------------------------------------------- */
        public void IncarcaredgvTari()
        {
            using (OdbcConnection conexiune_dgvTari = new OdbcConnection(sircon_RelIntDB))
            {
                // Comanda
                using (OdbcCommand comanda_dgvTari = new OdbcCommand())
                {
                    comanda_dgvTari.Connection = conexiune_dgvTari;
                    comanda_dgvTari.CommandType = CommandType.Text;
                    comanda_dgvTari.CommandText = "SELECT tarit AS \"Țări\" FROM tari";

                    try
                    {
                        conexiune_dgvTari.Open();
                        OdbcDataAdapter da_dgvTari = new OdbcDataAdapter();
                        da_dgvTari.SelectCommand = comanda_dgvTari;

                        DataTable dt_dgvTari = new DataTable();
                        da_dgvTari.Fill(dt_dgvTari);

                        BindingSource bs_dgvTari = new BindingSource();
                        bs_dgvTari.DataSource = dt_dgvTari;

                        dgvTari.DataSource = bs_dgvTari;

                        da_dgvTari.Update(dt_dgvTari);
                    }
                    catch (Exception exdgvTari)
                    {
                        MessageBox.Show(exdgvTari.Message);
                    } // Ne deconectam
                    finally
                    {
                        conexiune_dgvTari.Close();
                    }
                }
            }

            // Efectuam metoda:
            if (System.Windows.Forms.Application.OpenForms["frmGCD"] != null)
            {
                (System.Windows.Forms.Application.OpenForms["frmGCD"] as frmGCD).VerificareTari();
            }

            // Apoi metoda:
            if (System.Windows.Forms.Application.OpenForms["frmGCD"] != null)
            {
                (System.Windows.Forms.Application.OpenForms["frmGCD"] as frmGCD).AprobareVerifGDFMTSCA();
            }

            if (System.Windows.Forms.Application.OpenForms["frmCerereInregistrare"] != null)
            {
                (System.Windows.Forms.Application.OpenForms["frmCerereInregistrare"] as frmCerereInregistrare).UmplereTari();
            }

            if (System.Windows.Forms.Application.OpenForms["frmCerereModificare"] != null)
            {
                (System.Windows.Forms.Application.OpenForms["frmCerereModificare"] as frmCerereModificare).UmplereTari();
            }

            if (System.Windows.Forms.Application.OpenForms["frmODDIntroducere"] != null)
            {
                (System.Windows.Forms.Application.OpenForms["frmODDIntroducere"] as frmODDIntroducere).UmplereTari();
            }

            if (System.Windows.Forms.Application.OpenForms["frmODDModificare"] != null)
            {
                (System.Windows.Forms.Application.OpenForms["frmODDModificare"] as frmODDModificare).UmplereTari();
            }
        }
        /* --------------------------------------------------------------------------------------------------------------- */
        /* ----------------- Eveniment de tip click pentru btnIntroducerT ------------------------------------------------ */
        private void btnIntroducereT_Click(object sender, EventArgs e)
        {
            using (OdbcConnection conexiune_dgvTari = new OdbcConnection(sircon_RelIntDB))
            {
                // Comanda
                using (OdbcCommand comanda_dgvTari = new OdbcCommand())
                {
                    comanda_dgvTari.Connection = conexiune_dgvTari;
                    comanda_dgvTari.CommandType = CommandType.Text;
                    comanda_dgvTari.CommandText = "INSERT INTO tari VALUES (?)";
                    comanda_dgvTari.Parameters.AddWithValue("@tarit", OdbcType.NVarChar).Value = txtIntroducereT.Text;

                    try
                    {
                        conexiune_dgvTari.Open();
                        int recordsAffected = comanda_dgvTari.ExecuteNonQuery();
                    }
                    catch (Exception dgvTari)
                    {
                        MessageBox.Show(dgvTari.Message);
                    } // Ne deconectam
                    finally
                    {
                        conexiune_dgvTari.Close();
                    }
                }
            }

            // Actualizam
            IncarcaredgvTari();

            // Golim
            txtIntroducereT.Clear();
            txtIntroducereT.Focus();
        }
        /* ----------------- Eveniment de tip click pentru btnModificareT ------------------------------------------------ */
        private void btnModificareT_Click(object sender, EventArgs e)
        {
            using (OdbcConnection conexiune_dgvTari = new OdbcConnection(sircon_RelIntDB))
            {
                // Comanda
                using (OdbcCommand comanda_dgvTari = new OdbcCommand())
                {
                    comanda_dgvTari.Connection = conexiune_dgvTari;
                    comanda_dgvTari.CommandType = CommandType.Text;
                    comanda_dgvTari.CommandText = "UPDATE tari SET tarit = ? WHERE tarit = ?";
                    comanda_dgvTari.Parameters.AddWithValue("@tarit", OdbcType.NVarChar).Value = txtTNoua.Text;
                    comanda_dgvTari.Parameters.AddWithValue("@tarit", OdbcType.NVarChar).Value = txtTVeche.Text;

                    try
                    {
                        conexiune_dgvTari.Open();
                        int recordsAffected = comanda_dgvTari.ExecuteNonQuery();
                    }
                    catch (Exception dgvTari)
                    {
                        MessageBox.Show(dgvTari.Message);
                    } // Ne deconectam
                    finally
                    {
                        conexiune_dgvTari.Close();
                    }
                }
            }

            // Actualizam
            IncarcaredgvTari();

            // Golim campurile
            txtTVeche.Clear();
            txtTNoua.Clear();
            txtTVeche.Focus();
        }
        /* --------------------------------------------------------------------------------------------------------------- */
        /* ----------------- Eveniment de tip TextChanged pentru caseta txtTari ------------------------------------------ */
        private void txtIntroducereT_TextChanged(object sender, EventArgs e)
        {
            if (txtIntroducereT.Text != string.Empty)
            {
                // Activam
                btnIntroducereT.Enabled = true;
            }
            else
            {
                // Dezactivam
                btnIntroducereT.Enabled = false;
            }
        }
        /* --------------------------------------------------------------------------------------------------------------- */
        /* ----------------- Eveniment de tip TextChanged pentru caseta txtTari ------------------------------------------ */
        private void txtTNoua_TextChanged(object sender, EventArgs e)
        {
            if (txtTNoua.Text != string.Empty)
            {
                // Activam
                btnModificareT.Enabled = true;
            }
            else
            {
                // Dezactivam
                btnModificareT.Enabled = false;
            }
        }
        /* --------------------------------------------------------------------------------------------------------------- */









        /* ------------------- Activam Campurile prin rdoIntroducereS ---------------------------------------------------- */
        private void rdoIntroducereS_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoIntroducereS.Checked)
            {
                // Activam
                lblIntroducereS.Enabled = true;
                txtIntroducereS.Enabled = true;

                // Dezactivam
                lblSCVechi.Enabled = false;
                lblSNou.Enabled = false;
                txtSVechi.Enabled = false;
                txtSNou.Enabled = false;
                btnModificareS.Enabled = false;
            }
            else
            {
                // Dezactivam
                lblIntroducereS.Enabled = false;
                txtIntroducereS.Enabled = false;
                btnIntroducereS.Enabled = false;
            }
        }
        /* --------------------------------------------------------------------------------------------------------------- */
        /* ---------------------- Activam campurile prin rdoModificareS -------------------------------------------------- */
        private void rdoModificareS_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoModificareS.Checked)
            {
                // Activam
                lblSVechi.Enabled = true;
                lblSNou.Enabled = true;
                txtSVechi.Enabled = true;
                txtSNou.Enabled = true;

                // Dezactivam
                lblIntroducereS.Enabled = false;
                txtIntroducereS.Enabled = false;
                btnIntroducereS.Enabled = false;
            }
            else
            {
                // Dezactivam
                lblSVechi.Enabled = false;
                lblSNou.Enabled = false;
                txtSVechi.Enabled = false;
                txtSNou.Enabled = false;
                btnModificareS.Enabled = false;
            }
        }
        /* --------------------------------------------------------------------------------------------------------------- */
        /* -------------------- Functii pentru dgvScopuri ---------------------------------------------------------------- */
        public void IncarcaredgvScopuri()
        {
            using (OdbcConnection conexiune_dgvScopuri = new OdbcConnection(sircon_RelIntDB))
            {
                // Comanda
                using (OdbcCommand comanda_dgvScopuri = new OdbcCommand())
                {
                    comanda_dgvScopuri.Connection = conexiune_dgvScopuri;
                    comanda_dgvScopuri.CommandType = CommandType.Text;
                    comanda_dgvScopuri.CommandText = "SELECT scopuris AS \"Scopuri\" FROM scopuri";

                    try
                    {
                        conexiune_dgvScopuri.Open();
                        OdbcDataAdapter da_dgvScopuri = new OdbcDataAdapter();
                        da_dgvScopuri.SelectCommand = comanda_dgvScopuri;

                        DataTable dt_dgvScopuri = new DataTable();
                        da_dgvScopuri.Fill(dt_dgvScopuri);

                        BindingSource bs_dgvTari = new BindingSource();
                        bs_dgvTari.DataSource = dt_dgvScopuri;

                        dgvScopuri.DataSource = bs_dgvTari;

                        da_dgvScopuri.Update(dt_dgvScopuri);
                    }
                    catch (Exception exdgvScopuri)
                    {
                        MessageBox.Show(exdgvScopuri.Message);
                    } // Ne deconectam
                    finally
                    {
                        conexiune_dgvScopuri.Close();
                    }
                }
            }

            // Efectuam metoda:
            if (System.Windows.Forms.Application.OpenForms["frmGCD"] != null)
            {
                (System.Windows.Forms.Application.OpenForms["frmGCD"] as frmGCD).VerificareScopuri();
            }

            // Apoi metoda:
            if (System.Windows.Forms.Application.OpenForms["frmGCD"] != null)
            {
                (System.Windows.Forms.Application.OpenForms["frmGCD"] as frmGCD).AprobareVerifGDFMTSCA();
            }

            if (System.Windows.Forms.Application.OpenForms["frmCerereInregistrare"] != null)
            {
                (System.Windows.Forms.Application.OpenForms["frmCerereInregistrare"] as frmCerereInregistrare).UmplereScop();
            }

            if (System.Windows.Forms.Application.OpenForms["frmCerereModificare"] != null)
            {
                (System.Windows.Forms.Application.OpenForms["frmCerereModificare"] as frmCerereModificare).UmplereScop();
            }

            if (System.Windows.Forms.Application.OpenForms["frmODDIntroducere"] != null)
            {
                (System.Windows.Forms.Application.OpenForms["frmODDIntroducere"] as frmODDIntroducere).UmplereScop();
            }

            if (System.Windows.Forms.Application.OpenForms["frmODDModificare"] != null)
            {
                (System.Windows.Forms.Application.OpenForms["frmODDModificare"] as frmODDModificare).UmplereScop();
            }
        }
        /* --------------------------------------------------------------------------------------------------------------- */
        /* ----------------- Eveniment de tip click pentru btnIntroducerS ------------------------------------------------ */
        private void btnIntroducereS_Click(object sender, EventArgs e)
        {
            using (OdbcConnection conexiune_dgvScopuri = new OdbcConnection(sircon_RelIntDB))
            {
                // Comanda
                using (OdbcCommand comanda_dgvScopuri = new OdbcCommand())
                {
                    comanda_dgvScopuri.Connection = conexiune_dgvScopuri;
                    comanda_dgvScopuri.CommandType = CommandType.Text;
                    comanda_dgvScopuri.CommandText = "INSERT INTO scopuri VALUES (?)";
                    comanda_dgvScopuri.Parameters.AddWithValue("@scopuris", OdbcType.NVarChar).Value = txtIntroducereS.Text;

                    try
                    {
                        conexiune_dgvScopuri.Open();
                        int recordsAffected = comanda_dgvScopuri.ExecuteNonQuery();
                    }
                    catch (Exception dgvScopuri)
                    {
                        MessageBox.Show(dgvScopuri.Message);
                    } // Ne deconectam
                    finally
                    {
                        conexiune_dgvScopuri.Close();
                    }
                }
            }

            // Actualizam
            IncarcaredgvScopuri();

            // Golim
            txtIntroducereS.Clear();
            txtIntroducereS.Focus();
        }
        /* ----------------- Eveniment de tip click pentru btnModificareS ------------------------------------------------ */
        private void btnModificareS_Click(object sender, EventArgs e)
        {
            using (OdbcConnection conexiune_dgvScopuri = new OdbcConnection(sircon_RelIntDB))
            {
                // Comanda
                using (OdbcCommand comanda_dgvScopuri = new OdbcCommand())
                {
                    comanda_dgvScopuri.Connection = conexiune_dgvScopuri;
                    comanda_dgvScopuri.CommandType = CommandType.Text;
                    comanda_dgvScopuri.CommandText = "UPDATE scopuri SET scopuris = ? WHERE scopuris = ?";
                    comanda_dgvScopuri.Parameters.AddWithValue("@scopuris", OdbcType.NVarChar).Value = txtSNou.Text;
                    comanda_dgvScopuri.Parameters.AddWithValue("@scopuris", OdbcType.NVarChar).Value = txtSVechi.Text;

                    try
                    {
                        conexiune_dgvScopuri.Open();
                        int recordsAffected = comanda_dgvScopuri.ExecuteNonQuery();
                    }
                    catch (Exception dgvTari)
                    {
                        MessageBox.Show(dgvTari.Message);
                    } // Ne deconectam
                    finally
                    {
                        conexiune_dgvScopuri.Close();
                    }
                }
            }

            // Actualizam
            IncarcaredgvScopuri();

            // Golim campurile
            txtSVechi.Clear();
            txtSNou.Clear();
            txtSVechi.Focus();
        }
        /* --------------------------------------------------------------------------------------------------------------- */
        /* ----------------- Eveniment de tip TextChanged pentru caseta txtScopuri --------------------------------------- */
        private void txtIntroducereS_TextChanged(object sender, EventArgs e)
        {
            if (txtIntroducereS.Text != string.Empty)
            {
                // Activam
                btnIntroducereS.Enabled = true;
            }
            else
            {
                // Dezactivam
                btnIntroducereS.Enabled = false;
            }
        }
        /* --------------------------------------------------------------------------------------------------------------- */
        /* ----------------- Eveniment de tip TextChanged pentru caseta txtScopuri --------------------------------------- */
        private void txtSNou_TextChanged(object sender, EventArgs e)
        {
            if (txtSNou.Text != string.Empty)
            {
                // Activam
                btnModificareS.Enabled = true;
            }
            else
            {
                // Dezactivam
                btnModificareS.Enabled = false;
            }
        }
        /* --------------------------------------------------------------------------------------------------------------- */









        /* ------------------- Activam Campurile prin rdoIntroducereSC --------------------------------------------------- */
        private void rdoIntroducereSC_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoIntroducereSC.Checked)
            {
                // Activam
                lblIntroducereSC.Enabled = true;
                txtIntroducereSC.Enabled = true;

                // Dezactivam
                lblSCVechi.Enabled = false;
                lblSCNou.Enabled = false;
                txtSCVechi.Enabled = false;
                txtSCNou.Enabled = false;
                btnModificareSC.Enabled = false;
            }
            else
            {
                // Dezactivam
                lblIntroducereSC.Enabled = false;
                txtIntroducereSC.Enabled = false;
                btnIntroducereSC.Enabled = false;
            }
        }
        /* --------------------------------------------------------------------------------------------------------------- */
        /* ---------------------- Activam campurile prin rdoModificareSC ------------------------------------------------- */
        private void rdoModificareSC_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoModificareSC.Checked)
            {
                // Activam
                lblSCVechi.Enabled = true;
                lblSCNou.Enabled = true;
                txtSCVechi.Enabled = true;
                txtSCNou.Enabled = true;

                // Dezactivam
                lblIntroducereSC.Enabled = false;
                txtIntroducereSC.Enabled = false;
                btnIntroducereSC.Enabled = false;
            }
            else
            {
                // Dezactivam
                lblSCVechi.Enabled = false;
                lblSCNou.Enabled = false;
                txtSCVechi.Enabled = false;
                txtSCNou.Enabled = false;
                btnModificareSC.Enabled = false;
            }
        }
        /* --------------------------------------------------------------------------------------------------------------- */
        /* -------------------- Functii pentru dgvScopuri-Conferinte ----------------------------------------------------- */
        public void IncarcaredgvSC()
        {
            using (OdbcConnection conexiune_dgvScopuriConferinte = new OdbcConnection(sircon_RelIntDB))
            {
                // Comanda
                using (OdbcCommand comanda_dgvScopuriConferinte = new OdbcCommand())
                {
                    comanda_dgvScopuriConferinte.Connection = conexiune_dgvScopuriConferinte;
                    comanda_dgvScopuriConferinte.CommandType = CommandType.Text;
                    comanda_dgvScopuriConferinte.CommandText = "SELECT scopuriconferintesc AS \"Scop - Conferințe\" FROM scopuriconferinte";

                    try
                    {
                        conexiune_dgvScopuriConferinte.Open();
                        OdbcDataAdapter da_dgvScopuriConferinte = new OdbcDataAdapter();
                        da_dgvScopuriConferinte.SelectCommand = comanda_dgvScopuriConferinte;

                        DataTable dt_dgvScopuriConferinte = new DataTable();
                        da_dgvScopuriConferinte.Fill(dt_dgvScopuriConferinte);

                        BindingSource bs_dgvScopuriConferinte = new BindingSource();
                        bs_dgvScopuriConferinte.DataSource = dt_dgvScopuriConferinte;

                        dgvScopConferinte.DataSource = bs_dgvScopuriConferinte;

                        da_dgvScopuriConferinte.Update(dt_dgvScopuriConferinte);
                    }
                    catch (Exception exdgvScopConferinte)
                    {
                        MessageBox.Show(exdgvScopConferinte.Message);
                    } // Ne deconectam
                    finally
                    {
                        conexiune_dgvScopuriConferinte.Close();
                    }
                }
            }

            // Efectuam metoda:
            if (System.Windows.Forms.Application.OpenForms["frmGCD"] != null)
            {
                (System.Windows.Forms.Application.OpenForms["frmGCD"] as frmGCD).VerificareScopuriConferinte();
            }

            // Apoi metoda:
            if (System.Windows.Forms.Application.OpenForms["frmGCD"] != null)
            {
                (System.Windows.Forms.Application.OpenForms["frmGCD"] as frmGCD).AprobareVerifGDFMTSCA();
            }

            if (System.Windows.Forms.Application.OpenForms["frmCerereInregistrare"] != null)
            {
                (System.Windows.Forms.Application.OpenForms["frmCerereInregistrare"] as frmCerereInregistrare).UmplereScopConferinte();
            }

            if (System.Windows.Forms.Application.OpenForms["frmCerereModificare"] != null)
            {
                (System.Windows.Forms.Application.OpenForms["frmCerereModificare"] as frmCerereModificare).UmplereScopConferinte();
            }

            if (System.Windows.Forms.Application.OpenForms["frmODDIntroducere"] != null)
            {
                (System.Windows.Forms.Application.OpenForms["frmODDIntroducere"] as frmODDIntroducere).UmplereScopConferinte();
            }

            if (System.Windows.Forms.Application.OpenForms["frmODDModificare"] != null)
            {
                (System.Windows.Forms.Application.OpenForms["frmODDModificare"] as frmODDModificare).UmplereScopConferinte();
            }
        }
        /* --------------------------------------------------------------------------------------------------------------- */
        /* ----------------- Eveniment de tip click pentru btnIntroducerSC ----------------------------------------------- */
        private void btnIntroducereSC_Click(object sender, EventArgs e)
        {
            using (OdbcConnection conexiune_dgvScopuriConferinte = new OdbcConnection(sircon_RelIntDB))
            {
                // Comanda
                using (OdbcCommand comanda_dgvScopuriConferinte = new OdbcCommand())
                {
                    comanda_dgvScopuriConferinte.Connection = conexiune_dgvScopuriConferinte;
                    comanda_dgvScopuriConferinte.CommandType = CommandType.Text;
                    comanda_dgvScopuriConferinte.CommandText = "INSERT INTO scopuriconferinte VALUES (?)";
                    comanda_dgvScopuriConferinte.Parameters.AddWithValue("@scopuriconferintesc", OdbcType.NVarChar).Value = txtIntroducereSC.Text;

                    try
                    {
                        conexiune_dgvScopuriConferinte.Open();
                        int recordsAffected = comanda_dgvScopuriConferinte.ExecuteNonQuery();
                    }
                    catch (Exception dgvScopuriConferinte)
                    {
                        MessageBox.Show(dgvScopuriConferinte.Message);
                    } // Ne deconectam
                    finally
                    {
                        conexiune_dgvScopuriConferinte.Close();
                    }
                }
            }

            // Actualizam
            IncarcaredgvSC();

            // Golim
            txtIntroducereSC.Clear();
            txtIntroducereSC.Focus();
        }
        /* ----------------- Eveniment de tip click pentru btnModificareSC ----------------------------------------------- */
        private void btnModificareSC_Click(object sender, EventArgs e)
        {
            using (OdbcConnection conexiune_dgvScopuriConferinte = new OdbcConnection(sircon_RelIntDB))
            {
                // Comanda
                using (OdbcCommand comanda_dgvScopuriConferinte = new OdbcCommand())
                {
                    comanda_dgvScopuriConferinte.Connection = conexiune_dgvScopuriConferinte;
                    comanda_dgvScopuriConferinte.CommandType = CommandType.Text;
                    comanda_dgvScopuriConferinte.CommandText = "UPDATE scopuriconferinte SET scopuriconferintesc = ? WHERE scopuriconferintesc = ?";
                    comanda_dgvScopuriConferinte.Parameters.AddWithValue("@scopuriconferintesc", OdbcType.NVarChar).Value = txtSCNou.Text;
                    comanda_dgvScopuriConferinte.Parameters.AddWithValue("@scopuriconferintesc", OdbcType.NVarChar).Value = txtSCVechi.Text;

                    try
                    {
                        conexiune_dgvScopuriConferinte.Open();
                        int recordsAffected = comanda_dgvScopuriConferinte.ExecuteNonQuery();
                    }
                    catch (Exception dgvScopuriConferinte)
                    {
                        MessageBox.Show(dgvScopuriConferinte.Message);
                    } // Ne deconectam
                    finally
                    {
                        conexiune_dgvScopuriConferinte.Close();
                    }
                }
            }

            // Actualizam
            IncarcaredgvSC();

            // Golim campurile
            txtSCVechi.Clear();
            txtSCNou.Clear();
            txtSCVechi.Focus();
        }
        /* --------------------------------------------------------------------------------------------------------------- */
        /* ----------------- Eveniment de tip TextChanged pentru caseta txtScopuriConferinte ----------------------------- */
        private void txtIntroducereSC_TextChanged(object sender, EventArgs e)
        {
            if (txtIntroducereSC.Text != string.Empty)
            {
                // Activam
                btnIntroducereSC.Enabled = true;
            }
            else
            {
                // Dezactivam
                btnIntroducereSC.Enabled = false;
            }
        }
        /* --------------------------------------------------------------------------------------------------------------- */
        /* ----------------- Eveniment de tip TextChanged pentru caseta txtScopuriConferinte ----------------------------- */
        private void txtSCNou_TextChanged(object sender, EventArgs e)
        {
            if (txtSCNou.Text != string.Empty)
            {
                // Activam
                btnModificareSC.Enabled = true;
            }
            else
            {
                // Dezactivam
                btnModificareSC.Enabled = false;
            }
        }
        /* --------------------------------------------------------------------------------------------------------------- */









        /* ------------------- Activam Campurile prin rdoIntroducereSC --------------------------------------------------- */
        private void rdoIntroducereSA_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoIntroducereSA.Checked)
            {
                // Activam
                lblIntroducereSA.Enabled = true;
                txtIntroducereSA.Enabled = true;

                // Dezactivam
                lblSAVechi.Enabled = false;
                lblSANou.Enabled = false;
                txtSAVechi.Enabled = false;
                txtSANou.Enabled = false;
                btnModificareSA.Enabled = false;
            }
            else
            {
                // Dezactivam
                lblIntroducereSA.Enabled = false;
                txtIntroducereSA.Enabled = false;
                btnIntroducereSA.Enabled = false;
            }
        }
        /* --------------------------------------------------------------------------------------------------------------- */
        /* ---------------------- Activam campurile prin rdoModificareSC ------------------------------------------------- */
        private void rdoModificareSA_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoModificareSA.Checked)
            {
                // Activam
                lblSAVechi.Enabled = true;
                lblSANou.Enabled = true;
                txtSAVechi.Enabled = true;
                txtSANou.Enabled = true;

                // Dezactivam
                lblIntroducereSA.Enabled = false;
                txtIntroducereSA.Enabled = false;
                btnIntroducereSA.Enabled = false;
            }
            else
            {
                // Dezactivam
                lblSAVechi.Enabled = false;
                lblSANou.Enabled = false;
                txtSAVechi.Enabled = false;
                txtSANou.Enabled = false;
                btnModificareSA.Enabled = false;
            }
        }
        /* --------------------------------------------------------------------------------------------------------------- */
        /* -------------------- Functii pentru dgvScopuri-Conferinte ----------------------------------------------------- */
        public void IncarcaredgvSA()
        {
            using (OdbcConnection conexiune_dgvScopuriAltele = new OdbcConnection(sircon_RelIntDB))
            {
                // Comanda
                using (OdbcCommand comanda_dgvScopuriAltele = new OdbcCommand())
                {
                    comanda_dgvScopuriAltele.Connection = conexiune_dgvScopuriAltele;
                    comanda_dgvScopuriAltele.CommandType = CommandType.Text;
                    comanda_dgvScopuriAltele.CommandText = "SELECT scopurialtelesa AS \"Scop - Altele\" FROM scopurialtele";

                    try
                    {
                        conexiune_dgvScopuriAltele.Open();
                        OdbcDataAdapter da_dgvScopuriAltele = new OdbcDataAdapter();
                        da_dgvScopuriAltele.SelectCommand = comanda_dgvScopuriAltele;

                        DataTable dt_dgvScopuriAltele = new DataTable();
                        da_dgvScopuriAltele.Fill(dt_dgvScopuriAltele);

                        BindingSource bs_dgvScopuriAltele = new BindingSource();
                        bs_dgvScopuriAltele.DataSource = dt_dgvScopuriAltele;

                        dgvScopAltele.DataSource = bs_dgvScopuriAltele;

                        da_dgvScopuriAltele.Update(dt_dgvScopuriAltele);
                    }
                    catch (Exception exdgvScopAltele)
                    {
                        MessageBox.Show(exdgvScopAltele.Message);
                    } // Ne deconectam
                    finally
                    {
                        conexiune_dgvScopuriAltele.Close();
                    }
                }
            }

            // Efectuam metoda:
            if (System.Windows.Forms.Application.OpenForms["frmGCD"] != null)
            {
                (System.Windows.Forms.Application.OpenForms["frmGCD"] as frmGCD).VerificareScopuriAltele();
            }

            // Apoi metoda:
            if (System.Windows.Forms.Application.OpenForms["frmGCD"] != null)
            {
                (System.Windows.Forms.Application.OpenForms["frmGCD"] as frmGCD).AprobareVerifGDFMTSCA();
            }

            if (System.Windows.Forms.Application.OpenForms["frmCerereInregistrare"] != null)
            {
                (System.Windows.Forms.Application.OpenForms["frmCerereInregistrare"] as frmCerereInregistrare).UmplereScopAltele();
            }

            if (System.Windows.Forms.Application.OpenForms["frmCerereModificare"] != null)
            {
                (System.Windows.Forms.Application.OpenForms["frmCerereModificare"] as frmCerereModificare).UmplereScopAltele();
            }

            if (System.Windows.Forms.Application.OpenForms["frmODDIntroducere"] != null)
            {
                (System.Windows.Forms.Application.OpenForms["frmODDIntroducere"] as frmODDIntroducere).UmplereScopAltele();
            }

            if (System.Windows.Forms.Application.OpenForms["frmODDModificare"] != null)
            {
                (System.Windows.Forms.Application.OpenForms["frmODDModificare"] as frmODDModificare).UmplereScopAltele();
            }
        }
        /* --------------------------------------------------------------------------------------------------------------- */
        /* ----------------- Eveniment de tip click pentru btnIntroducerSC ----------------------------------------------- */
        private void btnIntroducereSA_Click(object sender, EventArgs e)
        {
            using (OdbcConnection conexiune_dgvScopuriAltele = new OdbcConnection(sircon_RelIntDB))
            {
                // Comanda
                using (OdbcCommand comanda_dgvScopuriAltele = new OdbcCommand())
                {
                    comanda_dgvScopuriAltele.Connection = conexiune_dgvScopuriAltele;
                    comanda_dgvScopuriAltele.CommandType = CommandType.Text;
                    comanda_dgvScopuriAltele.CommandText = "INSERT INTO scopurialtele VALUES (?)";
                    comanda_dgvScopuriAltele.Parameters.AddWithValue("@scopurialtelesa", OdbcType.NVarChar).Value = txtIntroducereSA.Text;

                    try
                    {
                        conexiune_dgvScopuriAltele.Open();
                        int recordsAffected = comanda_dgvScopuriAltele.ExecuteNonQuery();
                    }
                    catch (Exception dgvScopuriAltele)
                    {
                        MessageBox.Show(dgvScopuriAltele.Message);
                    } // Ne deconectam
                    finally
                    {
                        conexiune_dgvScopuriAltele.Close();
                    }
                }
            }

            // Actualizam
            IncarcaredgvSA();

            // Golim
            txtIntroducereSA.Clear();
            txtIntroducereSA.Focus();
        }
        /* ----------------- Eveniment de tip click pentru btnModificareSC ----------------------------------------------- */
        private void btnModificareSA_Click(object sender, EventArgs e)
        {
            using (OdbcConnection conexiune_dgvScopuriAltele = new OdbcConnection(sircon_RelIntDB))
            {
                // Comanda
                using (OdbcCommand comanda_dgvScopuriAltele = new OdbcCommand())
                {
                    comanda_dgvScopuriAltele.Connection = conexiune_dgvScopuriAltele;
                    comanda_dgvScopuriAltele.CommandType = CommandType.Text;
                    comanda_dgvScopuriAltele.CommandText = "UPDATE scopurialtele SET scopurialtelesa = ? WHERE scopurialtelesa = ?";
                    comanda_dgvScopuriAltele.Parameters.AddWithValue("@scopurialtelesa", OdbcType.NVarChar).Value = txtSANou.Text;
                    comanda_dgvScopuriAltele.Parameters.AddWithValue("@scopurialtelesa", OdbcType.NVarChar).Value = txtSAVechi.Text;

                    try
                    {
                        conexiune_dgvScopuriAltele.Open();
                        int recordsAffected = comanda_dgvScopuriAltele.ExecuteNonQuery();
                    }
                    catch (Exception dgvScopuriAltele)
                    {
                        MessageBox.Show(dgvScopuriAltele.Message);
                    } // Ne deconectam
                    finally
                    {
                        conexiune_dgvScopuriAltele.Close();
                    }
                }
            }

            // Actualizam
            IncarcaredgvSA();

            // Golim campurile
            txtSAVechi.Clear();
            txtSANou.Clear();
            txtSAVechi.Focus();
        }
        /* --------------------------------------------------------------------------------------------------------------- */
        /* ----------------- Eveniment de tip TextChanged pentru caseta txtScopuriConferinte ----------------------------- */
        private void txtIntroducereSA_TextChanged(object sender, EventArgs e)
        {
            if (txtIntroducereSA.Text != string.Empty)
            {
                // Activam
                btnIntroducereSA.Enabled = true;
            }
            else
            {
                // Dezactivam
                btnIntroducereSA.Enabled = false;
            }
        }
        /* --------------------------------------------------------------------------------------------------------------- */
        /* ----------------- Eveniment de tip TextChanged pentru caseta txtScopuriConferinte ----------------------------- */
        private void txtSANou_TextChanged(object sender, EventArgs e)
        {
            if (txtSANou.Text != string.Empty)
            {
                // Activam
                btnModificareSA.Enabled = true;
            }
            else
            {
                // Dezactivam
                btnModificareSA.Enabled = false;
            }
        }
        /* --------------------------------------------------------------------------------------------------------------- */
    }
}
