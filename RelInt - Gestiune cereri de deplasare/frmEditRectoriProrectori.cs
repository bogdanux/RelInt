﻿using System;
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
    public partial class frmEditRectoriProrectori : Form
    {
        public frmEditRectoriProrectori() // Metoda de LOAD
        {
            InitializeComponent();

            // Incarcam urmatoarele
            IncarcaredgvRector();
            IncarcaredgvProRector();
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

            // Efectuam metoda:
            if (System.Windows.Forms.Application.OpenForms["frmGCD"] != null)
            {
                (System.Windows.Forms.Application.OpenForms["frmGCD"] as frmGCD).VerificareRector();
            }

            // Apoi metoda:
            if (System.Windows.Forms.Application.OpenForms["frmGCD"] != null)
            {
                (System.Windows.Forms.Application.OpenForms["frmGCD"] as frmGCD).AprobareVerifRP();
            }
        }
        /* --------------------------------------------------------------------------------------------------------------- */
        /* --------------------------------------------------------------------------------------------------------------- */
        private void rdoAdaugaR_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoAdaugaR.Checked == true)
            {
                // Activam
                lblNumeR.Enabled = true;
                txtNumeR.Enabled = true;
            }
            else
            {
                // Dezactivam
                lblNumeR.Enabled = false;
                txtNumeR.Enabled = false;
            }
        }
        /* --------------------------------------------------------------------------------------------------------------- */
        /* --------------------------------------------------------------------------------------------------------------- */
        private void rdoModificaR_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoModificaR.Checked == true)
            {
                // Activam
                lblNumeR.Enabled = true;
                txtNumeR.Enabled = true;
            }
            else
            {
                // Dezactivam
                lblNumeR.Enabled = false;
                txtNumeR.Enabled = false;
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
                    comanda_dgvRector.CommandText = "UPDATE rectori SET rectorcurent = ?";
                    comanda_dgvRector.Parameters.AddWithValue("@rectorcurent", OdbcType.Bit).Value = false;

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

            using (OdbcConnection conexiune_dgvRector = new OdbcConnection(sircon_RelIntDB))
            {
                // Comanda
                using (OdbcCommand comanda_dgvRector = new OdbcCommand())
                {
                    comanda_dgvRector.Connection = conexiune_dgvRector;
                    comanda_dgvRector.CommandType = CommandType.Text;
                    comanda_dgvRector.CommandText = "INSERT INTO rectori VALUES (?, ?, ?, ?)";
                    comanda_dgvRector.Parameters.AddWithValue("@rector", OdbcType.NVarChar).Value = txtNumeR.Text;
                    comanda_dgvRector.Parameters.AddWithValue("@emailr", OdbcType.NVarChar).Value = txtEmailR.Text;
                    comanda_dgvRector.Parameters.AddWithValue("@telefonr", OdbcType.Int).Value = vartxtTelefonR;
                    comanda_dgvRector.Parameters.AddWithValue("@rectorcurent", OdbcType.Bit).Value = true;

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

            // Actualizam
            IncarcaredgvRector();

            // Golim
            txtTelefonR.Clear();
            txtEmailR.Clear();
            txtNumeR.Clear();
            rdoAdaugaR.Checked = false;
        }
        /* --------------------------------------------------------------------------------------------------------------- */
        /* --------------------------------------------------------------------------------------------------------------- */
        private void btnModificaR_Click(object sender, EventArgs e)
        {
            using (OdbcConnection conexiune_dgvRector = new OdbcConnection(sircon_RelIntDB))
            {
                // Comanda
                using (OdbcCommand comanda_dgvRector = new OdbcCommand())
                {
                    comanda_dgvRector.Connection = conexiune_dgvRector;
                    comanda_dgvRector.CommandType = CommandType.Text;
                    comanda_dgvRector.CommandText = "UPDATE rectori SET rector = ?, emailr = ?, telefonr = ? WHERE rector = ?";
                    comanda_dgvRector.Parameters.AddWithValue("@rector", OdbcType.NVarChar).Value = txtNumeRNou.Text;
                    comanda_dgvRector.Parameters.AddWithValue("@emailr", OdbcType.NVarChar).Value = txtEMailRNou.Text;
                    comanda_dgvRector.Parameters.AddWithValue("@telefonr", OdbcType.NVarChar).Value = vartxtTelefonRNou;

                    comanda_dgvRector.Parameters.AddWithValue("@rector", OdbcType.NVarChar).Value = txtNumeR.Text;

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

            // Actualizam
            IncarcaredgvRector();

            // Efectuam
            txtTelefonRNou.Clear();
            txtEMailRNou.Clear();
            txtNumeRNou.Clear();
            txtNumeR.Clear();
            rdoModificaR.Checked = false;
        }
        /* --------------------------------------------------------------------------------------------------------------- */
        /* --------------------------------------------------------------------------------------------------------------- */
        private void txtNumeR_TextChanged(object sender, EventArgs e)
        {
            if (txtNumeR.Text != string.Empty && rdoModificaR.Checked == false)
            {
                // Activam urmatoarele
                lblEmailR.Enabled = true;
                txtEmailR.Enabled = true;
            }
            else
            {
                // Dezactivam urmatoarele
                lblEmailR.Enabled = false;
                txtEmailR.Enabled = false;
            }

            if (rdoModificaR.Checked && txtNumeR.Text != string.Empty)
            {
                // Activam
                lblNumeRNou.Enabled = true;
                txtNumeRNou.Enabled = true;
            }
            else
            {
                // Dezactivam
                lblNumeRNou.Enabled = false;
                txtNumeRNou.Enabled = false;
            }
        }
        /* --------------------------------------------------------------------------------------------------------------- */
        /* --------------------------------------------------------------------------------------------------------------- */
        private void txtEmailR_TextChanged(object sender, EventArgs e)
        {
            if (txtEmailR.Text != string.Empty)
            {
                // Activeaza
                lblTelefonR.Enabled = true;
                txtTelefonR.Enabled = true;
            }
            else
            {
                // Dezactiveaza
                lblTelefonR.Enabled = false;
                txtTelefonR.Enabled = false;
            }
        }
        /* --------------------------------------------------------------------------------------------------------------- */
        /* --------------------------------------------------------------------------------------------------------------- */
        int vartxtTelefonR;
        /* --------------------------------------------------------------------------------------------------------------- */
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

            if (txtTelefonR.Text != string.Empty)
            {
                // Activam
                btnAdaugaR.Enabled = true;
            }
            else
            {
                // Dezactivam
                btnAdaugaR.Enabled = false;
            }
        }
        /* --------------------------------------------------------------------------------------------------------------- */
        /* --------------------------------------------------------------------------------------------------------------- */
        private void txtNumeRNou_TextChanged(object sender, EventArgs e)
        {
            if (txtNumeRNou.Text != string.Empty)
            {
                // Activam
                lblEMailRNou.Enabled = true;
                txtEMailRNou.Enabled = true;
            }
            else
            {
                // Dezactivam
                lblEMailRNou.Enabled = false;
                txtEMailRNou.Enabled = false;
            }
        }
        /* --------------------------------------------------------------------------------------------------------------- */
        /* --------------------------------------------------------------------------------------------------------------- */
        private void txtEMailRNou_TextChanged(object sender, EventArgs e)
        {
            if (txtEMailRNou.Text != string.Empty)
            {
                // Activam
                lblTelefonRNou.Enabled = true;
                txtTelefonRNou.Enabled = true;
            }
            else
            {
                // Dezactivam
                lblTelefonRNou.Enabled = false;
                txtTelefonRNou.Enabled = false;
            }
        }
        /* --------------------------------------------------------------------------------------------------------------- */
        /* --------------------------------------------------------------------------------------------------------------- */
        int vartxtTelefonRNou;
        /* --------------------------------------------------------------------------------------------------------------- */
        private void txtTelefonRNou_TextChanged(object sender, EventArgs e)
        {
            // Verificam daca valoarea din "txtTelefonRNou" este de tip int si daca da, o inregistram in "vartxtTelefonRNou"
            bool vartxtTelefonRNouEsteNumar = Int32.TryParse(txtTelefonRNou.Text, out vartxtTelefonRNou);

            // Judecam si "sanctionam" la nevoie
            switch (vartxtTelefonRNouEsteNumar || txtTelefonRNou.Text == string.Empty)
            {
                case false:
                    // Golim casuta si afisam mesaj de eroare
                    txtTelefonRNou.Clear();
                    MessageBox.Show("        Vă rugăm introduceți doar numere în această casetă de text.");
                    break;
            }

            if (txtTelefonRNou.Text != string.Empty)
            {
                // Activam
                btnModificaR.Enabled = true;
            }
            else
            {
                // Dezactivam
                btnModificaR.Enabled = false;
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

            // Efectuam metoda:
            if (System.Windows.Forms.Application.OpenForms["frmGCD"] != null)
            {
                (System.Windows.Forms.Application.OpenForms["frmGCD"] as frmGCD).VerificareProrector();
            }

            // Apoi metoda:
            if (System.Windows.Forms.Application.OpenForms["frmGCD"] != null)
            {
                (System.Windows.Forms.Application.OpenForms["frmGCD"] as frmGCD).AprobareVerifRP();
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
                    comanda_dgvProRector.Parameters.AddWithValue("@prorector", OdbcType.NVarChar).Value = txtNumePR.Text;
                    comanda_dgvProRector.Parameters.AddWithValue("@emailp", OdbcType.NVarChar).Value = txtEMailPR.Text;
                    comanda_dgvProRector.Parameters.AddWithValue("@telefonp1", OdbcType.Int).Value = vartxtTelefonPR1;
                    comanda_dgvProRector.Parameters.AddWithValue("@telefonp2", OdbcType.Int).Value = vartxtTelefonPR2;

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

            // Actualizam
            IncarcaredgvProRector();

            // Golim
            txtTelefonPR2.Clear();
            txtTelefonPR1.Clear();
            txtEMailPR.Clear();
            txtNumePR.Clear();
            rdoAdaugaPR.Checked = false;
        }
        /* --------------------------------------------------------------------------------------------------------------- */
        /* --------------------------------------------------------------------------------------------------------------- */
        private void btnModificaPR_Click(object sender, EventArgs e)
        {
            using (OdbcConnection conexiune_dgvRector = new OdbcConnection(sircon_RelIntDB))
            {
                // Comanda
                using (OdbcCommand comanda_dgvRector = new OdbcCommand())
                {
                    comanda_dgvRector.Connection = conexiune_dgvRector;
                    comanda_dgvRector.CommandType = CommandType.Text;
                    comanda_dgvRector.CommandText = "UPDATE prorectori SET prorector = ?, emailp = ?, telefonp1 = ?, telefonp2 = ? WHERE prorector = ?";
                    comanda_dgvRector.Parameters.AddWithValue("@prorector", OdbcType.NVarChar).Value = txtNumePRNou.Text;
                    comanda_dgvRector.Parameters.AddWithValue("@emailp", OdbcType.NVarChar).Value = txtEMailPRNou.Text;
                    comanda_dgvRector.Parameters.AddWithValue("@telefonp1", OdbcType.Int).Value = vartxtTelefonPR1Nou;
                    comanda_dgvRector.Parameters.AddWithValue("@telefonp2", OdbcType.Int).Value = vartxtTelefonPR2Nou;

                    comanda_dgvRector.Parameters.AddWithValue("@prorector", OdbcType.NVarChar).Value = txtNumePR.Text;

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

            // Actualizam
            IncarcaredgvProRector();

            // Golim
            txtTelefonPR2Nou.Clear();
            txtTelefonPR1Nou.Clear();
            txtEMailPRNou.Clear();
            txtNumePRNou.Clear();
            rdoModificaPR.Checked = false;
        }
        /* --------------------------------------------------------------------------------------------------------------- */
        /* --------------------------------------------------------------------------------------------------------------- */
        private void txtNumePR_TextChanged(object sender, EventArgs e)
        {
            if (txtNumePR.Text != string.Empty && rdoModificaPR.Checked == false)
            {
                // Activam urmatoarele
                lblEMailPR.Enabled = true;
                txtEMailPR.Enabled = true;
            }
            else
            {
                // Dezactivam urmatoarele
                lblEMailPR.Enabled = false;
                txtEMailPR.Enabled = false;
            }

            if (txtNumePR.Text != string.Empty && rdoModificaPR.Checked)
            {
                // Activam
                lblNumePRNou.Enabled = true;
                txtNumePRNou.Enabled = true;
            }
            else
            {
                // Dezactivam
                lblNumePRNou.Enabled = false;
                txtNumePRNou.Enabled = false;
            }
        }
        /* --------------------------------------------------------------------------------------------------------------- */
        /* --------------------------------------------------------------------------------------------------------------- */
        int vartxtTelefonPR1;
        /* --------------------------------------------------------------------------------------------------------------- */
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

            if (txtTelefonPR1.Text != string.Empty)
            {
                // Activam
                lblTelefonPR2.Enabled = true;
                txtTelefonPR2.Enabled = true;

                btnAdaugaPR.Enabled = true;
            }
            else
            {
                // Dezactivam
                lblTelefonPR2.Enabled = false;
                txtTelefonPR2.Enabled = false;

                btnAdaugaPR.Enabled = false;
            }
        }
        /* --------------------------------------------------------------------------------------------------------------- */
        /* --------------------------------------------------------------------------------------------------------------- */
        int vartxtTelefonPR2;
        /* --------------------------------------------------------------------------------------------------------------- */
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
        /* --------------------------------------------------------------------------------------------------------------- */
        private void rdoAdaugaPR_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoAdaugaPR.Checked == true)
            {
                // Activeaza
                lblNumePR.Enabled = true;
                txtNumePR.Enabled = true;
            }
            else
            {
                // Dezactiveaza
                txtNumePR.Clear();

                lblEMailPR.Enabled = false;
                txtEMailPR.Clear();
                txtEMailPR.Enabled = false;

                lblTelefonPR1.Enabled = false;
                txtTelefonPR1.Clear();
                txtTelefonPR1.Enabled = false;

                lblTelefonPR2.Enabled = false;
                txtTelefonPR2.Clear();
                txtTelefonPR2.Enabled = false;
            }
        }
        /* --------------------------------------------------------------------------------------------------------------- */
        /* --------------------------------------------------------------------------------------------------------------- */
        private void rdoModificaPR_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoModificaPR.Checked == true)
            {
                // Activeaza
                lblNumePR.Enabled = true;
                txtNumePR.Enabled = true;
            }
            else
            {
                // Dezactiveaza
                lblNumePRNou.Enabled = false;
                txtNumePRNou.Clear();
                txtNumePRNou.Enabled = false;

                lblEMailPRNou.Enabled = false;
                txtEMailPRNou.Clear();
                txtEMailPRNou.Enabled = false;

                lblTelefonPR1Nou.Enabled = false;
                txtTelefonPR1Nou.Clear();
                txtTelefonPR1Nou.Enabled = false;

                lblTelefonPR2Nou.Enabled = false;
                txtTelefonPR2Nou.Clear();
                txtTelefonPR2Nou.Enabled = false;
            }
        }
        /* --------------------------------------------------------------------------------------------------------------- */
        /* --------------------------------------------------------------------------------------------------------------- */
        private void txtEMailPR_TextChanged(object sender, EventArgs e)
        {
            if (txtEMailPR.Text != string.Empty)
            {
                // Activeaza
                lblTelefonPR1.Enabled = true;
                txtTelefonPR1.Enabled = true;
            }
            else
            {
                // Dezactiveaza
                lblTelefonPR1.Enabled = false;
                txtTelefonPR1.Enabled = false;
            }
        }
        /* --------------------------------------------------------------------------------------------------------------- */
        /* --------------------------------------------------------------------------------------------------------------- */
        private void txtNumePRNou_TextChanged(object sender, EventArgs e)
        {
            if (txtNumePRNou.Text != string.Empty)
            {
                // Activeaza
                lblEMailPRNou.Enabled = true;
                txtEMailPRNou.Enabled = true;
            }
            else
            {
                // Dezactiveaza
                lblEMailPRNou.Enabled = false;
                txtEMailPRNou.Enabled = false;
            }
        }
        /* --------------------------------------------------------------------------------------------------------------- */
        /* --------------------------------------------------------------------------------------------------------------- */
        private void txtEMailPRNou_TextChanged(object sender, EventArgs e)
        {
            if (txtEMailPRNou.Text != string.Empty)
            {
                // Activeaza
                lblTelefonPR1Nou.Enabled = true;
                txtTelefonPR1Nou.Enabled = true;
            }
            else
            {
                // Dezactiveaza
                lblTelefonPR1Nou.Enabled = false;
                txtTelefonPR1Nou.Enabled = false;
            }
        }
        /* --------------------------------------------------------------------------------------------------------------- */
        /* --------------------------------------------------------------------------------------------------------------- */
        int vartxtTelefonPR1Nou;
        /* --------------------------------------------------------------------------------------------------------------- */
        private void txtTelefonPR1Nou_TextChanged(object sender, EventArgs e)
        {
            // Verificam daca valoarea din "txtTelefonPR1Nou" este de tip int si daca da, o inregistram in "vartxtTelefonPR1Nou"
            bool vartxtTelefonPR1NouEsteNumar = Int32.TryParse(txtTelefonPR1Nou.Text, out vartxtTelefonPR1Nou);

            // Judecam si "sanctionam" la nevoie
            switch (vartxtTelefonPR1NouEsteNumar || txtTelefonPR1Nou.Text == string.Empty)
            {
                case false:
                    // Golim casuta si afisam mesaj de eroare
                    txtTelefonPR1Nou.Clear();
                    MessageBox.Show("        Vă rugăm introduceți doar numere în această casetă de text.");
                    break;
            }

            if (txtTelefonPR1Nou.Text != string.Empty)
            {
                // Activam
                lblTelefonPR2Nou.Enabled = true;
                txtTelefonPR2Nou.Enabled = true;

                btnModificaPR.Enabled = true;
            }
            else
            {
                // Dezactivam
                lblTelefonPR2Nou.Enabled = false;
                txtTelefonPR2Nou.Enabled = false;

                btnModificaPR.Enabled = false;
            }
        }
        /* --------------------------------------------------------------------------------------------------------------- */
        /* --------------------------------------------------------------------------------------------------------------- */
        int vartxtTelefonPR2Nou;
        /* --------------------------------------------------------------------------------------------------------------- */
        private void txtTelefonPR2Nou_TextChanged(object sender, EventArgs e)
        {
            // Verificam daca valoarea din "txtTelefonPR1Nou" este de tip int si daca da, o inregistram in "vartxtTelefonPR2Nou"
            bool vartxtTelefonPR2NouEsteNumar = Int32.TryParse(txtTelefonPR2Nou.Text, out vartxtTelefonPR2Nou);

            // Judecam si "sanctionam" la nevoie
            switch (vartxtTelefonPR2NouEsteNumar || txtTelefonPR2Nou.Text == string.Empty)
            {
                case false:
                    // Golim casuta si afisam mesaj de eroare
                    txtTelefonPR2Nou.Clear();
                    MessageBox.Show("        Vă rugăm introduceți doar numere în această casetă de text.");
                    break;
            }
        }
        /* --------------------------------------------------------------------------------------------------------------- */







    }
}
