﻿using System;
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
            IncarcaredgvDFC();
            IncarcaredgvCOS();
            IncarcaredgvODP();
        }

        /* --------------------------------------------------------------------------------------------------------------- */










        /* ----------- Obiecte de lucru cu RelIntDB ---------------------------------------------------------------------- */
        // Sir de conectare al RelIntDB
        private string sircon_RelIntDB =
            "DSN=PostgreSQL35W;database=RelIntDB;server=localhost;port=5432;UID=postgres;PWD=12345;sslmode=disable;readonly=0;protocol=7.4;fakeoidindex=0;showoidcolumn=0;rowversioning=0;showsystemtables=0;fetch=100;socket=4096;unknownsizes=0;maxvarcharsize=255;maxlongvarcharsize=8190;debug=0;commlog=0;optimizer=0;ksqo=1;usedeclarefetch=0;textaslongvarchar=1;unknownsaslongvarchar=0;boolsaschar=1;parse=0;cancelasfreestmt=0;extrasystableprefixes=dd_;lfconversion=1;updatablecursors=1;disallowpremature=0;trueisminus1=0;bi=0;byteaaslongvarbinary=0;useserversideprepare=1;lowercaseidentifier=0;gssauthusegss=0;xaopt=1;";

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
                    comanda_dgvGradDidactic.CommandText =
                        "SELECT graddidacticgd AS \"Grade Didactice\" FROM gradedidactice";

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
                (System.Windows.Forms.Application.OpenForms["frmCerereInregistrare"] as frmCerereInregistrare)
                    .UmplereGradDidactic();
            }

            if (System.Windows.Forms.Application.OpenForms["frmCerereModificare"] != null)
            {
                (System.Windows.Forms.Application.OpenForms["frmCerereModificare"] as frmCerereModificare)
                    .UmplereGradDidactic();
            }

            if (System.Windows.Forms.Application.OpenForms["frmODDIntroducere"] != null)
            {
                (System.Windows.Forms.Application.OpenForms["frmODDIntroducere"] as frmODDIntroducere)
                    .UmplereGradDidactic();
            }

            if (System.Windows.Forms.Application.OpenForms["frmODDModificare"] != null)
            {
                (System.Windows.Forms.Application.OpenForms["frmODDModificare"] as frmODDModificare).UmplereGradDidactic
                    ();
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
                    comanda_dgvGradDidactic.Parameters.AddWithValue("@graddidacticgd", OdbcType.NVarChar).Value =
                        txtIntroducereGD.Text;

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
                    comanda_dgvGradDidactic.CommandText =
                        "UPDATE gradedidactice SET graddidacticgd = ? WHERE graddidacticgd = ?";
                    comanda_dgvGradDidactic.Parameters.AddWithValue("@graddidacticgd", OdbcType.NVarChar).Value =
                        txtGDNou.Text;
                    comanda_dgvGradDidactic.Parameters.AddWithValue("@graddidacticgd", OdbcType.NVarChar).Value =
                        txtGDVechi.Text;

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
                (System.Windows.Forms.Application.OpenForms["frmCerereInregistrare"] as frmCerereInregistrare)
                    .UmplereFacultate();
            }

            if (System.Windows.Forms.Application.OpenForms["frmCerereModificare"] != null)
            {
                (System.Windows.Forms.Application.OpenForms["frmCerereModificare"] as frmCerereModificare)
                    .UmplereFacultate();
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
                    comanda_dgvFacultate.Parameters.AddWithValue("@facultatif", OdbcType.NVarChar).Value =
                        txtIntroducereF.Text;

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
                    comanda_dgvFacultate.Parameters.AddWithValue("@facultatif", OdbcType.NVarChar).Value =
                        txtFVeche.Text;

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
                (System.Windows.Forms.Application.OpenForms["frmCerereInregistrare"] as frmCerereInregistrare)
                    .UmplereMonezi();
            }

            if (System.Windows.Forms.Application.OpenForms["frmCerereModificare"] != null)
            {
                (System.Windows.Forms.Application.OpenForms["frmCerereModificare"] as frmCerereModificare).UmplereMonezi
                    ();
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
                    comanda_dgvMoneda.Parameters.AddWithValue("@monezim", OdbcType.NVarChar).Value =
                        txtIntroducereM.Text;

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
                lblSVechi.Enabled = false;
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

            if (Application.OpenForms["frmGCD"] != null)
            {
                (Application.OpenForms["frmGCD"] as frmGCD).VerificareScopuri();
            }

            if (Application.OpenForms["frmGCD"] != null)
            {
                (Application.OpenForms["frmGCD"] as frmGCD).AprobareVerifGDFMTSCA();
            }

            if (Application.OpenForms["frmCerereInregistrare"] != null)
            {
                (Application.OpenForms["frmCerereInregistrare"] as frmCerereInregistrare).UmplereScop();
            }

            if (Application.OpenForms["frmCerereModificare"] != null)
            {
                (Application.OpenForms["frmCerereModificare"] as frmCerereModificare).UmplereScop();
            }

            if (Application.OpenForms["frmODDIntroducere"] != null)
            {
                (Application.OpenForms["frmODDIntroducere"] as frmODDIntroducere).UmplereScop();
            }

            if (Application.OpenForms["frmODDModificare"] != null)
            {
                (Application.OpenForms["frmODDModificare"] as frmODDModificare).UmplereScop();
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
                    comanda_dgvScopuri.Parameters.AddWithValue("@scopuris", OdbcType.NVarChar).Value =
                        txtIntroducereS.Text;

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









        /* ------------------ Functii pentru dgvDFC ---------------------------------------------------------------------- */
        public void IncarcaredgvDFC()
        {
            using (OdbcConnection conexiune_dgvDFC = new OdbcConnection(sircon_RelIntDB))
            {
                // Comanda
                using (OdbcCommand comanda_dgvDFC = new OdbcCommand())
                {
                    comanda_dgvDFC.Connection = conexiune_dgvDFC;
                    comanda_dgvDFC.CommandType = CommandType.Text;
                    comanda_dgvDFC.CommandText = "SELECT dfcd AS \"Director Financiar Contabil\" FROM dfc";

                    try
                    {
                        conexiune_dgvDFC.Open();
                        OdbcDataAdapter da_dgvDFC = new OdbcDataAdapter();
                        da_dgvDFC.SelectCommand = comanda_dgvDFC;

                        DataTable dt_dgvDFC = new DataTable();
                        da_dgvDFC.Fill(dt_dgvDFC);

                        BindingSource bs_dgvDFC = new BindingSource();
                        bs_dgvDFC.DataSource = dt_dgvDFC;

                        dgvDFC.DataSource = bs_dgvDFC;

                        da_dgvDFC.Update(dt_dgvDFC);
                    }
                    catch (Exception exdgvDFC)
                    {
                        MessageBox.Show(exdgvDFC.Message);
                    } // Ne deconectam
                    finally
                    {
                        conexiune_dgvDFC.Close();
                    }
                }
            }

            if (Application.OpenForms["frmGCD"] != null)
            {
                (Application.OpenForms["frmGCD"] as frmGCD).VerificareDFC();
            }

            if (Application.OpenForms["frmGCD"] != null)
            {
                (Application.OpenForms["frmGCD"] as frmGCD).AprobareVerifRPCOD();
            }

            if (Application.OpenForms["frmGCD"] != null)
            {
                (Application.OpenForms["frmGCD"] as frmGCD).MetodaScriereInStatusD();
            }

            if (Application.OpenForms["frmODDIntroducere"] != null)
            {
                (Application.OpenForms["frmODDIntroducere"] as frmODDIntroducere).UmplereDFC();
            }

            if (Application.OpenForms["frmODDModificare"] != null)
            {
                (Application.OpenForms["frmODDModificare"] as frmODDModificare).UmplereDFC();
            }
        }
        /* --------------------------------------------------------------------------------------------------------------- */
        /* ------------------ Eveniment de tip TextChanged pentru caseta txtDFCIntroducere ------------------------------- */
        private void txtDFCIntroducere_TextChanged(object sender, EventArgs e)
        {
            if (txtDFCIntroducere.Text != string.Empty)
            {
                // Activam
                btnDFCActualizare.Enabled = true;
            }
            else
            {
                // Dezactivam
                btnDFCActualizare.Enabled = false;
            }
        }
        /* --------------------------------------------------------------------------------------------------------------- */
        /* ------------------ Eveniment de tip click pentru btnDFCActualizare -------------------------------------------- */
        private void btnDFCActualizare_Click(object sender, EventArgs e)
        {
            using (OdbcConnection conexiune_dgvDFC = new OdbcConnection(sircon_RelIntDB))
            {
                // Comanda
                using (OdbcCommand comanda_dgvDFC = new OdbcCommand())
                {
                    comanda_dgvDFC.Connection = conexiune_dgvDFC;
                    comanda_dgvDFC.CommandType = CommandType.Text;
                    comanda_dgvDFC.CommandText = "UPDATE dfc SET dfcd = ?";
                    comanda_dgvDFC.Parameters.AddWithValue("@dfcd", OdbcType.NVarChar).Value = txtDFCIntroducere.Text;

                    try
                    {
                        conexiune_dgvDFC.Open();
                        comanda_dgvDFC.ExecuteNonQuery();
                    }
                    catch (Exception exdgvDFC)
                    {
                        MessageBox.Show(exdgvDFC.Message);
                    } // Ne deconectam
                    finally
                    {
                        conexiune_dgvDFC.Close();
                    }
                }
            }

            // Actualizam
            IncarcaredgvDFC();

            // Golim
            txtDFCIntroducere.Clear();
            txtDFCIntroducere.Focus();
        }
        /* --------------------------------------------------------------------------------------------------------------- */









        /* ------------------ Functii pentru dgvDFC ---------------------------------------------------------------------- */
        public void IncarcaredgvCOS()
        {
            using (OdbcConnection conexiune_dgvCOS = new OdbcConnection(sircon_RelIntDB))
            {
                // Comanda
                using (OdbcCommand comanda_dgvCOS = new OdbcCommand())
                {
                    comanda_dgvCOS.Connection = conexiune_dgvCOS;
                    comanda_dgvCOS.CommandType = CommandType.Text;
                    comanda_dgvCOS.CommandText = "SELECT cosc AS \"Specificația nr. 3\" FROM cos";

                    try
                    {
                        conexiune_dgvCOS.Open();
                        OdbcDataAdapter da_dgvCOS = new OdbcDataAdapter();
                        da_dgvCOS.SelectCommand = comanda_dgvCOS;

                        DataTable dt_dgvCOS = new DataTable();
                        da_dgvCOS.Fill(dt_dgvCOS);

                        BindingSource bs_dgvCOS = new BindingSource();
                        bs_dgvCOS.DataSource = dt_dgvCOS;

                        dgvCOS.DataSource = bs_dgvCOS;

                        da_dgvCOS.Update(dt_dgvCOS);
                    }
                    catch (Exception exdgvCOS)
                    {
                        MessageBox.Show(exdgvCOS.Message);
                    } // Ne deconectam
                    finally
                    {
                        conexiune_dgvCOS.Close();
                    }
                }
            }

            if (Application.OpenForms["frmGCD"] != null)
            {
                (Application.OpenForms["frmGCD"] as frmGCD).VerificareCOS();
            }

            if (Application.OpenForms["frmGCD"] != null)
            {
                (Application.OpenForms["frmGCD"] as frmGCD).AprobareVerifRPCOD();
            }

            if (Application.OpenForms["frmODDIntroducere"] != null)
            {
                (Application.OpenForms["frmODDIntroducere"] as frmODDIntroducere).UmplereCOS();
            }

            if (Application.OpenForms["frmODDModificare"] != null)
            {
                (Application.OpenForms["frmODDModificare"] as frmODDModificare).UmplereCOS();
            }
        }
        /* --------------------------------------------------------------------------------------------------------------- */
        /* ------------------ Eveniment de tip TextChanged pentru caseta txtDFCIntroducere ------------------------------- */
        private void txtCOSPropozitie_TextChanged(object sender, EventArgs e)
        {
            if (txtCOSPropozitie.Text != string.Empty)
            {
                // Activam
                btnCOSActualizeaza.Enabled = true;
            }
            else
            {
                // Dezactivam
                btnCOSActualizeaza.Enabled = false;
            }
        }
        /* --------------------------------------------------------------------------------------------------------------- */
        /* ------------------ Eveniment de tip click pentru btnDFCActualizare -------------------------------------------- */
        private void btnCOSActualizeaza_Click(object sender, EventArgs e)
        {
            using (OdbcConnection conexiune_dgvCOS = new OdbcConnection(sircon_RelIntDB))
            {
                // Comanda
                using (OdbcCommand comanda_dgvCOS = new OdbcCommand())
                {
                    comanda_dgvCOS.Connection = conexiune_dgvCOS;
                    comanda_dgvCOS.CommandType = CommandType.Text;
                    comanda_dgvCOS.CommandText = "UPDATE cos SET cosc = ?";
                    comanda_dgvCOS.Parameters.AddWithValue("@cosc", OdbcType.NVarChar).Value = txtCOSPropozitie.Text;

                    try
                    {
                        conexiune_dgvCOS.Open();
                        comanda_dgvCOS.ExecuteNonQuery();
                    }
                    catch (Exception exdgvCOS)
                    {
                        MessageBox.Show(exdgvCOS.Message);
                    } // Ne deconectam
                    finally
                    {
                        conexiune_dgvCOS.Close();
                    }
                }
            }

            // Actualizam
            IncarcaredgvCOS();

            // Golim
            txtCOSPropozitie.Clear();
            txtCOSPropozitie.Focus();
        }
        /* --------------------------------------------------------------------------------------------------------------- */









        /* ------------------ Functii pentru dgvDFC ---------------------------------------------------------------------- */
        public void IncarcaredgvODP()
        {
            using (OdbcConnection conexiune_dgvODP = new OdbcConnection(sircon_RelIntDB))
            {
                // Comanda
                using (OdbcCommand comanda_dgvODP = new OdbcCommand())
                {
                    comanda_dgvODP.Connection = conexiune_dgvODP;
                    comanda_dgvODP.CommandType = CommandType.Text;
                    comanda_dgvODP.CommandText = "SELECT odpo AS \"Specificația nr. 4\" FROM odp";

                    try
                    {
                        conexiune_dgvODP.Open();
                        OdbcDataAdapter da_dgvODP = new OdbcDataAdapter();
                        da_dgvODP.SelectCommand = comanda_dgvODP;

                        DataTable dt_dgvODP = new DataTable();
                        da_dgvODP.Fill(dt_dgvODP);

                        BindingSource bs_dgvODP = new BindingSource();
                        bs_dgvODP.DataSource = dt_dgvODP;

                        dgvODP.DataSource = bs_dgvODP;

                        da_dgvODP.Update(dt_dgvODP);
                    }
                    catch (Exception exdgvODP)
                    {
                        MessageBox.Show(exdgvODP.Message);
                    } // Ne deconectam
                    finally
                    {
                        conexiune_dgvODP.Close();
                    }
                }
            }

            if (Application.OpenForms["frmGCD"] != null)
            {
                (Application.OpenForms["frmGCD"] as frmGCD).VerificareODP();
            }

            if (Application.OpenForms["frmGCD"] != null)
            {
                (Application.OpenForms["frmGCD"] as frmGCD).AprobareVerifRPCOD();
            }

            if (Application.OpenForms["frmODDIntroducere"] != null)
            {
                (Application.OpenForms["frmODDIntroducere"] as frmODDIntroducere).UmplereODP();
            }

            if (Application.OpenForms["frmODDModificare"] != null)
            {
                (Application.OpenForms["frmODDModificare"] as frmODDModificare).UmplereODP();
            }
        }
        /* --------------------------------------------------------------------------------------------------------------- */
        /* ------------------ Eveniment de tip TextChanged pentru caseta txtDFCIntroducere ------------------------------- */
        private void txtODPPropozitie_TextChanged(object sender, EventArgs e)
        {
            if (txtODPPropozitie.Text != string.Empty)
            {
                // Activam
                btnODPActualizeaza.Enabled = true;
            }
            else
            {
                // Dezactivam
                btnODPActualizeaza.Enabled = false;
            }
        }
        /* --------------------------------------------------------------------------------------------------------------- */
        /* ------------------ Eveniment de tip click pentru btnDFCActualizare -------------------------------------------- */
        private void btnODPActualizeaza_Click(object sender, EventArgs e)
        {
            using (OdbcConnection conexiune_dgvODP = new OdbcConnection(sircon_RelIntDB))
            {
                // Comanda
                using (OdbcCommand dgvCOS = new OdbcCommand())
                {
                    dgvCOS.Connection = conexiune_dgvODP;
                    dgvCOS.CommandType = CommandType.Text;
                    dgvCOS.CommandText = "UPDATE odp SET odpo = ?";
                    dgvCOS.Parameters.AddWithValue("@odpo", OdbcType.NVarChar).Value = txtODPPropozitie.Text;

                    try
                    {
                        conexiune_dgvODP.Open();
                        dgvCOS.ExecuteNonQuery();
                    }
                    catch (Exception exdgvODP)
                    {
                        MessageBox.Show(exdgvODP.Message);
                    } // Ne deconectam
                    finally
                    {
                        conexiune_dgvODP.Close();
                    }
                }
            }

            // Actualizam
            IncarcaredgvODP();

            // Golim
            txtODPPropozitie.Clear();
            txtODPPropozitie.Focus();
        }
        /* --------------------------------------------------------------------------------------------------------------- */









    }
}
