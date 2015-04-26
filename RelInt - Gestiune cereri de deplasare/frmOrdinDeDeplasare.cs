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
    public partial class frmOrdinDeDeplasare : Form
    {
        public frmOrdinDeDeplasare() // Metoda de LOAD
        {
            InitializeComponent();

            // Aducem din BD numarul de inregistrare
            MetodaAducereNrInregistrare();

            // Incarcam ComboBox-urile urmatoare
            UmplereGradDidactic();
            UmplereFacultate();
            UmplereMonezi();
        }
        /* --------------------------------------------------------------------------------------------------------------- */










        /* ----------- Obiecte de lucru cu RelIntDB ---------------------------------------------------------------------- */
        // Sir de conectare al RelIntDB
        string sircon_RelIntDB = "DSN=PostgreSQL35W;database=RelIntDB;server=localhost;port=5432;UID=postgres;PWD=12345;sslmode=disable;readonly=0;protocol=7.4;fakeoidindex=0;showoidcolumn=0;rowversioning=0;showsystemtables=0;fetch=100;socket=4096;unknownsizes=0;maxvarcharsize=255;maxlongvarcharsize=8190;debug=0;commlog=0;optimizer=0;ksqo=1;usedeclarefetch=0;textaslongvarchar=1;unknownsaslongvarchar=0;boolsaschar=1;parse=0;cancelasfreestmt=0;extrasystableprefixes=dd_;lfconversion=1;updatablecursors=1;disallowpremature=0;trueisminus1=0;bi=0;byteaaslongvarbinary=0;useserversideprepare=1;lowercaseidentifier=0;gssauthusegss=0;xaopt=1;";

        /* --------------------------------------------------------------------------------------------------------------- */







        /* ----------------- Eveniment de tip click pentru btnIesire ----------------------------------------------------- */
        private void btnIesire_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /* --------------------------------------------------------------------------------------------------------------- */







        /* --------------- Event KeyDown al formularului ----------------------------------------------------------------- */
        private void frmCerereBECA_KeyDown(object sender, KeyEventArgs e)
        {
            if (txtNrInregistrare.Text != string.Empty && e.KeyCode == Keys.Enter)
            {
                ActivareControaleForm();
            }
        }
        /* --------------------------------------------------------------------------------------------------------------- */








        /* ----------------- Eveniment de tip click pentru btnGenerare --------------------------------------------------- */
        private void btnGenerare_Click(object sender, EventArgs e)
        {
            // nu fa nimic deocamdata
        }
        /* --------------------------------------------------------------------------------------------------------------- */









        /* ---------- Metoda de umplere a cmbGradDidactic cu date din RelIntDB ------------------------------------------- */
        private void UmplereGradDidactic()
        {
            using (OdbcConnection conexiune_cmbGradDidactic = new OdbcConnection(sircon_RelIntDB))
            {           // Comanda
                using (OdbcCommand comanda_cmbGradDidactic = new OdbcCommand())
                {
                    comanda_cmbGradDidactic.Connection = conexiune_cmbGradDidactic;
                    comanda_cmbGradDidactic.CommandType = CommandType.Text;
                    comanda_cmbGradDidactic.CommandText = "SELECT * FROM gradedidactice ORDER BY graddidacticgd ASC";

                    OdbcDataReader cititor_cmbGradDidactic;

                    try
                    {
                        conexiune_cmbGradDidactic.Open();
                        cititor_cmbGradDidactic = comanda_cmbGradDidactic.ExecuteReader();
                        while (cititor_cmbGradDidactic.Read())
                        {
                            string str_cmbGradDidactic = cititor_cmbGradDidactic.GetString(0);
                            cmbGradDidactic.Items.Add(str_cmbGradDidactic);
                        }
                    }
                    catch (Exception excmbGradDidactic)
                    {
                        MessageBox.Show(excmbGradDidactic.Message);
                    } // Ne deconectam
                    finally
                    {
                        conexiune_cmbGradDidactic.Close();
                    }
                }
            }
        }
        /* --------------------------------------------------------------------------------------------------------------- */









        /* ---------- Metoda de umplere a cmbFacultate cu date din RelIntDB ---------------------------------------------- */
        private void UmplereFacultate()
        {
            using (OdbcConnection conexiune_cmbFacultate = new OdbcConnection(sircon_RelIntDB))
            {           // Comanda
                using (OdbcCommand comanda_cmbFacultate = new OdbcCommand())
                {
                    comanda_cmbFacultate.Connection = conexiune_cmbFacultate;
                    comanda_cmbFacultate.CommandType = CommandType.Text;
                    comanda_cmbFacultate.CommandText = "SELECT * FROM facultati ORDER BY facultati ASC";

                    OdbcDataReader cititor_cmbFacultate;

                    try
                    {
                        conexiune_cmbFacultate.Open();
                        cititor_cmbFacultate = comanda_cmbFacultate.ExecuteReader();
                        while (cititor_cmbFacultate.Read())
                        {
                            string str_cmbFacultate = cititor_cmbFacultate.GetString(0);
                            cmbFacultatea.Items.Add(str_cmbFacultate);
                        }
                    }
                    catch (Exception excmbFacultate)
                    {
                        MessageBox.Show(excmbFacultate.Message);
                    } // Ne deconectam
                    finally
                    {
                        conexiune_cmbFacultate.Close();
                    }
                }
            }
        }
        /* --------------------------------------------------------------------------------------------------------------- */









        /* ---------- Metoda de umplere a cmbFacultate cu date din RelIntDB --------------------------------------------- */
        private void UmplereMonezi()
        {
            using (OdbcConnection conexiune_cmbMonezi = new OdbcConnection(sircon_RelIntDB))
            {           // Comanda
                using (OdbcCommand comanda_cmbMonezi = new OdbcCommand())
                {
                    comanda_cmbMonezi.Connection = conexiune_cmbMonezi;
                    comanda_cmbMonezi.CommandType = CommandType.Text;
                    comanda_cmbMonezi.CommandText = "SELECT * FROM monezi ORDER BY monezim ASC";

                    OdbcDataReader cititor_cmbMonezi;

                    try
                    {
                        conexiune_cmbMonezi.Open();
                        cititor_cmbMonezi = comanda_cmbMonezi.ExecuteReader();
                        while (cititor_cmbMonezi.Read())
                        {
                            string str_cmbMonezi = cititor_cmbMonezi.GetString(0);
                            cmbMoneda1.Items.Add(str_cmbMonezi);
                            cmbMoneda2.Items.Add(str_cmbMonezi);
                            cmbMoneda3.Items.Add(str_cmbMonezi);
                            cmbMoneda4.Items.Add(str_cmbMonezi);
                        }
                    }
                    catch (Exception excmbMonezi)
                    {
                        MessageBox.Show(excmbMonezi.Message);
                    } // Ne deconectam
                    finally
                    {
                        conexiune_cmbMonezi.Close();
                    }
                }
            }
        }
        /* --------------------------------------------------------------------------------------------------------------- */








        /* ---------------------- Metoda de verificare a txtNrInregistrare ----------------------------------------------- */
        private void MetodaAducereNrInregistrare()
        {
            using (OdbcConnection conexiune_VerifNrInregistrare = new OdbcConnection(sircon_RelIntDB))
            {           // Comanda
                using (OdbcCommand comanda_VerifNrInregistrare = new OdbcCommand())
                {
                    comanda_VerifNrInregistrare.Connection = conexiune_VerifNrInregistrare;
                    comanda_VerifNrInregistrare.CommandType = CommandType.Text;
                    comanda_VerifNrInregistrare.CommandText = "SELECT max(nrinregistrarec) FROM cereri";

                    OdbcDataReader cititor_VerifNrInregistrare;

                    try
                    {
                        conexiune_VerifNrInregistrare.Open();
                        cititor_VerifNrInregistrare = comanda_VerifNrInregistrare.ExecuteReader();

                        while (cititor_VerifNrInregistrare.Read())
                        {
                            switch (cititor_VerifNrInregistrare.IsDBNull(0))
                            {
                                case true:
                                    // Atribuim valoarea
                                    txtNrInregistrare.Text = "1";

                                    // Dezactivam controlul
                                    txtNrInregistrare.Enabled = false;
                                    break;

                                case false:
                                    // Declaram variabila si calculam
                                    int nrinregistrare = Convert.ToInt32(cititor_VerifNrInregistrare.GetValue(0)) + 1;

                                    // Afisam un textbox
                                    txtNrInregistrare.Text = nrinregistrare.ToString();

                                    // Dezactivam controlul
                                    txtNrInregistrare.Enabled = false;
                                    break;
                            }
                        }
                    }
                    catch (Exception exVerifNrInregistrare)
                    {
                        MessageBox.Show(exVerifNrInregistrare.Message);
                    } // Ne deconectam
                    finally
                    {
                        conexiune_VerifNrInregistrare.Close();
                    }
                }
            }
        }
        /* --------------------------------------------------------------------------------------------------------------- */







        /* ------------ Metoda de activare a tututor controalelor de pe form --------------------------------------------- */
        private void ActivareControaleForm()
        {
            // Dezactivam urmatoarele controale
            lblNrUAIC.Enabled = true;
            txtNrUAIC.Enabled = true;
            dpDataBECA.Enabled = true;
            dpDataBECA.Enabled = true;

            // Dezactivam urmatoarele panouri
            panouContinut.Enabled = true;
            panouCheltuieli.Enabled = true;
            panouAlteDispuneri.Enabled = true;
            panouSemnatari.Enabled = true;
        }
        /* --------------------------------------------------------------------------------------------------------------- */







        /* ------------------ Eveniment al butonului btnAcceseaza -------------------------------------------------------- */
        private void btnAcceseaza_Click(object sender, EventArgs e)
        {
            ActivareControaleForm();
        }
        /* --------------------------------------------------------------------------------------------------------------- */





        /* ------------------ Metoda de incarcare a cmbRectorProrector --------------------------------------------------- */
        private void IncarcarecmbRectorProrector()
        {
            if (rdoRector.Checked == true)
            {
                
                using (OdbcConnection conexiune_cmbRectorProrector1 = new OdbcConnection(sircon_RelIntDB))
                {           // Comanda
                    using (OdbcCommand comanda_cmbRectorProrector1 = new OdbcCommand())
                    {
                        comanda_cmbRectorProrector1.Connection = conexiune_cmbRectorProrector1;
                        comanda_cmbRectorProrector1.CommandType = CommandType.Text;
                        comanda_cmbRectorProrector1.CommandText = "SELECT rector FROM rectori";

                        OdbcDataReader cititor_cmbRectorProrector1;

                        try
                        {
                            conexiune_cmbRectorProrector1.Open();
                            cititor_cmbRectorProrector1 = comanda_cmbRectorProrector1.ExecuteReader();
                            while (cititor_cmbRectorProrector1.Read())
                            {
                                string str_cmbRectorProrector1 = cititor_cmbRectorProrector1.GetString(0);
                                cmbRectorProrector.Items.Clear();
                                cmbRectorProrector.Items.Add(str_cmbRectorProrector1);
                            }
                            cititor_cmbRectorProrector1.Close();
                        }
                        catch (Exception excmbRectorProrector1)
                        {
                            MessageBox.Show(excmbRectorProrector1.Message);
                        } // Ne deconectam
                        finally
                        {
                            conexiune_cmbRectorProrector1.Close();
                        }
                    }
                }
            }

            else if (rdoProRector.Checked == true)
            {
                using (OdbcConnection conexiune_cmbRectorProrector2 = new OdbcConnection(sircon_RelIntDB))
                {           // Comanda
                    using (OdbcCommand comanda_cmbRectorProrector2 = new OdbcCommand())
                    {
                        comanda_cmbRectorProrector2.Connection = conexiune_cmbRectorProrector2;
                        comanda_cmbRectorProrector2.CommandType = CommandType.Text;
                        comanda_cmbRectorProrector2.CommandText = "SELECT prorector FROM prorectori ORDER BY prorector ASC";

                        OdbcDataReader cititor_cmbRectorProrector2;

                        try
                        {
                            conexiune_cmbRectorProrector2.Open();
                            cititor_cmbRectorProrector2 = comanda_cmbRectorProrector2.ExecuteReader();
                            while (cititor_cmbRectorProrector2.Read())
                            {
                                string str_cmbRectorProrector2 = cititor_cmbRectorProrector2.GetString(0);
                                cmbRectorProrector.Items.Clear();
                                cmbRectorProrector.Items.Add(str_cmbRectorProrector2);
                            }
                            cititor_cmbRectorProrector2.Close();
                        }
                        catch (Exception excmbRectorProrector2)
                        {
                            MessageBox.Show(excmbRectorProrector2.Message);
                        } // Ne deconectam
                        finally
                        {
                            conexiune_cmbRectorProrector2.Close();
                        }
                    }
                }
            }
        }
        /* --------------------------------------------------------------------------------------------------------------- */

        /* ------------------- Eveniement pentru rdoRector --------------------------------------------------------------- */
        private void rdoRector_CheckedChanged(object sender, EventArgs e)
        {
            IncarcarecmbRectorProrector();
        }
        /* --------------------------------------------------------------------------------------------------------------- */

        /* ------------------- Eveniement pentru rdoProRector ------------------------------------------------------------ */
        private void rdoProRector_CheckedChanged(object sender, EventArgs e)
        {
            IncarcarecmbRectorProrector();
        }
        /* --------------------------------------------------------------------------------------------------------------- */





        /* --------------------- variabile de lucru pentru eveniment txtNrUAIC ------------------------------------------- */
        int vartxtNrUAIC;
        bool txtNrUAICSchimbat = false;
        /* --------------------- Eveniment pentru txtNrUAIC -------------------------------------------------------------- */
        private void txtNrUAIC_TextChanged(object sender, EventArgs e)
        {
            // Verificam daca valoarea din "txtNrUAIC" este de tip int si daca da, o inregistram in "vartxtNrUAIC"
            bool vartxtNrInregistrareEsteNumar = Int32.TryParse(txtNrUAIC.Text, out vartxtNrUAIC);

            // Judecam si "sanctionam" la nevoie
            switch (vartxtNrInregistrareEsteNumar || txtNrUAIC.Text == string.Empty)
            {
                case false:
                    // Golim casuta si afisam mesaj de eroare
                    txtNrUAIC.Clear();
                    MessageBox.Show("        Vă rugăm introduceți doar numere în această casetă de text.");
                    break;
            }

            // Inregistram modificarea campului
            txtNrUAICSchimbat = true;
        }
        /* --------------------------------------------------------------------------------------------------------------- */







        /* --------------------- variabile de lucru pentru eveniment txtNrZileDiurna ------------------------------------- */
        int vartxtNrZileDiurna;
        bool txtNrZileDiurnaSchimbat = false;
        /* ------------------------- Eveniment pentru txtNrZileDiurna ---------------------------------------------------- */
        private void txtNrZileDiurna_TextChanged(object sender, EventArgs e)
        {
            // Verificam daca valoarea din "txtNrZileDiurna" este de tip int si daca da, o inregistram in "vartxtNrZileDiurna"
            bool vartxtNrZileDiurnaEsteNumar = Int32.TryParse(txtNrZileDiurna.Text, out vartxtNrZileDiurna);

            // Judecam si "sanctionam" la nevoie
            switch (vartxtNrZileDiurnaEsteNumar || txtNrZileDiurna.Text == string.Empty)
            {
                case false:
                    // Golim casuta si afisam mesaj de eroare
                    txtNrZileDiurna.Clear();
                    MessageBox.Show("        Vă rugăm introduceți doar numere în această casetă de text.");
                    break;
            }

            // Calculam
            MetodaCalculSubtotalDiurna();

            // Inregistram modificarea campului
            txtNrZileDiurnaSchimbat = true;
        }
        /* --------------------------------------------------------------------------------------------------------------- */








        /* --------------------- variabile de lucru pentru eveniment txtNrZileCazare ------------------------------------- */
        int vartxtNrZileCazare;
        bool txtNrZileCazareSchimbat = false;
        /* ------------------------- Eveniment pentru txtNrZileCazare ---------------------------------------------------- */
        private void txtNrZileCazare_TextChanged(object sender, EventArgs e)
        {
            // Verificam daca valoarea din "txtNrZileCazare" este de tip int si daca da, o inregistram in "vartxtNrZileCazare"
            bool vartxtNrZileCazareEsteNumar = Int32.TryParse(txtNrZileCazare.Text, out vartxtNrZileCazare);

            // Judecam si "sanctionam" la nevoie
            switch (vartxtNrZileCazareEsteNumar || txtNrZileCazare.Text == string.Empty)
            {
                case false:
                    // Golim casuta si afisam mesaj de eroare
                    txtNrZileCazare.Clear();
                    MessageBox.Show("        Vă rugăm introduceți doar numere în această casetă de text.");
                    break;
            }
            
            // Calculam
            MetodaCalculSubtotalCazare();

            // Inregistram modificarea campului
            txtNrZileCazareSchimbat = true;
        }
        /* --------------------------------------------------------------------------------------------------------------- */






        


        /* --------------------- variabile de lucru pentru eveniment txtDiurna ------------------------------------- */
        double vartxtDiurna;
        bool txtDiurnaSchimbat = false;
        /* ------------------------- Eveniment pentru txtDiurna ---------------------------------------------------------- */
        private void txtDiurna_TextChanged(object sender, EventArgs e)
        {
            // Verificam daca valoarea din "txtDiurna" este de tip int si daca da, o inregistram in "vartxtDiurna"
            bool vartxtDiurnaEsteNumar = double.TryParse(txtDiurna.Text, out vartxtDiurna);

            // Judecam si "sanctionam" la nevoie
            switch (vartxtDiurnaEsteNumar || txtDiurna.Text == string.Empty)
            {
                case false:
                    // Golim casuta si afisam mesaj de eroare
                    txtDiurna.Clear();
                    MessageBox.Show("        Vă rugăm introduceți doar numere în această casetă de text.");
                    break;
            }

            // Calculam
            MetodaCalculSubtotalDiurna();

            // Inregistram modificarea campului
            txtDiurnaSchimbat = true;
        }
        /* --------------------------------------------------------------------------------------------------------------- */







        /* ------------------------- Variabile de lucru pentru txtCazare ------------------------------------------------- */
        double vartxtCazare;
        bool txtCazareSchimbat = false;
        /* ------------------------- Eveniment pentru txtCazare ---------------------------------------------------------- */
        private void txtCazare_TextChanged(object sender, EventArgs e)
        {
            // Verificam daca valoarea din "txtCazare" este de tip int si daca da, o inregistram in "vartxtCazare"
            bool vartxtCazareEsteNumar = Double.TryParse(txtCazare.Text, out vartxtCazare);

            // Judecam si "sanctionam" la nevoie
            switch (vartxtCazareEsteNumar || txtCazare.Text == string.Empty)
            {
                case false:
                    // Golim casuta si afisam mesaj de eroare
                    txtCazare.Clear();
                    MessageBox.Show("        Vă rugăm introduceți doar numere în această casetă de text.");
                    break;
            }

            // Calculam
            MetodaCalculSubtotalCazare();

            // Inregistram modificarea campului
            txtCazareSchimbat = true;
        }
        /* --------------------------------------------------------------------------------------------------------------- */








        /* ------------------------ Variabile de lucru pentru txtTaxaDeParticipare --------------------------------------- */
        int vartxtTaxaDeParticipare;
        bool txtTaxaDeParticipareSchimbat = false;
        /* ------------------------- Eveniment pentru txtTaxaDeParticipare ----------------------------------------------- */
        private void txtTaxaDeParticipare_TextChanged(object sender, EventArgs e)
        {
            // Verificam daca valoarea din "txtTaxaDeParticipare" este de tip int si daca da, o inregistram in "vartxtTaxaDeParticipare"
            bool vartxtTaxaDeParticipareEsteNumar = Int32.TryParse(txtTaxaDeParticipare.Text, out vartxtTaxaDeParticipare);

            // Judecam si "sanctionam" la nevoie
            switch (vartxtTaxaDeParticipareEsteNumar || txtTaxaDeParticipare.Text == string.Empty)
            {
                case false:
                    // Golim casuta si afisam mesaj de eroare
                    txtTaxaDeParticipare.Clear();
                    MessageBox.Show("        Vă rugăm introduceți doar numere în această casetă de text.");
                    break;
            }

            // Inregistram modificarea campului
            txtTaxaDeParticipareSchimbat = true;
        }
        /* --------------------------------------------------------------------------------------------------------------- */









        /* -------------------------- Variabile de lucru pentru txtTaxaDeViza -------------------------------------------- */
        int vartxtTaxaDeViza;
        bool txtTaxaDeVizaSchimbat = false;
        /* ------------------------- Eveniment pentru txtTaxaDeViza ------------------------------------------------------ */
        private void txtTaxaDeViza_TextChanged(object sender, EventArgs e)
        {
            // Verificam daca valoarea din "txtTaxaDeViza" este de tip int si daca da, o inregistram in "vartxtTaxaDeViza"
            bool vartxtTaxaDeVizaEsteNumar = Int32.TryParse(txtTaxaDeViza.Text, out vartxtTaxaDeViza);

            // Judecam si "sanctionam" la nevoie
            switch (vartxtTaxaDeVizaEsteNumar || txtTaxaDeViza.Text == string.Empty)
            {
                case false:
                    // Golim casuta si afisam mesaj de eroare
                    txtTaxaDeViza.Clear();
                    MessageBox.Show("        Vă rugăm introduceți doar numere în această casetă de text.");
                    break;
            }

            // Inregistram modificarea campului
            txtTaxaDeVizaSchimbat = true;
        }
        /* --------------------------------------------------------------------------------------------------------------- */






        /* --------------------------------------------------------------------------------------------------------------- */
        private void MetodaCalculSubtotalDiurna()
        {
            // Declaram o variabila locala
            double varSubtotal = 0;

            // Calculam
            varSubtotal = vartxtNrZileDiurna*vartxtDiurna;

            // Afisam
            txtSubtotalDiurna.Text = varSubtotal.ToString();
        }
        /* --------------------------------------------------------------------------------------------------------------- */






        /* --------------------------------------------------------------------------------------------------------------- */
        private void MetodaCalculSubtotalCazare()
        {
            // Declaram o variabila locala
            double varSubtotal = 0;

            // Calculam
            varSubtotal = vartxtNrZileCazare * vartxtCazare;

            // Afisam
            txtSubtotalCazare.Text = varSubtotal.ToString();
        }
        /* --------------------------------------------------------------------------------------------------------------- */







        /* --------------------------------------------------------------------------------------------------------------- */
        private void cmbMoneda1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Calculam
            MetodaCalculSubtotalDiurna();
        }

        private void cmbMoneda2_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Calculam
            MetodaCalculSubtotalCazare();
        }
        /* --------------------------------------------------------------------------------------------------------------- */







    }
}
