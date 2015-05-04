using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Odbc;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MigraDoc.DocumentObjectModel;
using MigraDoc.Rendering;
using TabAlignment = System.Windows.Forms.TabAlignment;

namespace RelInt___Gestiune_cereri_de_deplasare
{
    public partial class frmODDModificare : Form
    {
        public frmODDModificare() // Metoda de LOAD
        {
            InitializeComponent();

            // Incarcam ComboBox-urile urmatoare
            UmplereGradDidactic();
            UmplereFacultate();
            UmplereMonezi();

            // Pregatim formularul
            PregatireFormular();
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






        /* ----------------------- Metoda de pregatire layout-ului formularului ------------------------------------------ */
        private void PregatireFormular()
        {
            // Dezactivam urmatoarele
            btnAcceseaza.Enabled = false;
            txtNrUAICVechi.Enabled = false;
            txtNrUAICNou.Enabled = false;
            dpDataODDNoua.Enabled = false;

            // dezactivam panourile urmatoare
            panouContinutODD.Enabled = false;
            panouCheltuieliODD.Enabled = false;
            panouAlteDispuneriODD.Enabled = false;
            panouSemnatariODD.Enabled = false;
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
                            cmbCPGradDidactic.Items.Add(str_cmbGradDidactic);
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
                            cmbCPGradDidactic.Items.Add(str_cmbFacultate);
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
        /* ---------- Metoda de umplere a cmbFacultate cu date din RelIntDB ---------------------------------------------- */
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







        /* ------------------ Metoda de incarcare a cmbRectorProrector --------------------------------------------------- */
        private void IncarcarecmbRectorProrector()
        {
            cmbRectorProrector.Items.Clear();
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
                cmbRectorProrector.Items.Clear();
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
        int vartxtNrUAICVechi;
        /* --------------------- Eveniment pentru txtNrUAIC -------------------------------------------------------------- */
        private void txtNrUAICVechi_TextChanged(object sender, EventArgs e)
        {
            // Verificam daca valoarea din "txtNrUAIC" este de tip int si daca da, o inregistram in "vartxtNrUAIC"
            bool vartxtNrInregistrareEsteNumar = Int32.TryParse(txtNrUAICVechi.Text, out vartxtNrUAICVechi);

            // Judecam si "sanctionam" la nevoie
            switch (vartxtNrInregistrareEsteNumar || txtNrUAICVechi.Text == string.Empty)
            {
                case false:
                    // Golim casuta si afisam mesaj de eroare
                    txtNrUAICVechi.Clear();
                    MessageBox.Show("        Vă rugăm introduceți doar numere în această casetă de text.");
                    break;
            }

            // Efectuam
            if (txtNrUAICVechi.Text != string.Empty)
            {
                // Activam
                btnAcceseaza.Enabled = true;
            }
            else
            {
                // Dezactivam
                btnAcceseaza.Enabled = false;
            }
        }
        /* --------------------------------------------------------------------------------------------------------------- */
        /* --------------------------------------------------------------------------------------------------------------- */
        int vartxtNrUAICNou;
        bool txtNrUAICNouSchimbat = false;
        /* --------------------------------------------------------------------------------------------------------------- */
        private void txtNrUAICNou_TextChanged(object sender, EventArgs e)
        {
            // Verificam daca valoarea din "txtNrUAICNou" este de tip int si daca da, o inregistram in "vartxtNrUAICNou"
            bool vartxtNrUAICNouEsteNumar = Int32.TryParse(txtNrUAICNou.Text, out vartxtNrUAICNou);

            // Judecam si "sanctionam" la nevoie
            switch (vartxtNrUAICNouEsteNumar || txtNrUAICNou.Text == string.Empty)
            {
                case false:
                    // Golim casuta si afisam mesaj de eroare
                    txtNrUAICNou.Clear();
                    MessageBox.Show("        Vă rugăm introduceți doar numere în această casetă de text.");
                    break;
            }

            // Setam
            txtNrUAICNouSchimbat = true;
        }
        /* --------------------------------------------------------------------------------------------------------------- */
        /* --------------------- variabile de lucru pentru eveniment txtNrZileDiurna ------------------------------------- */
        int vartxtNrZileDiurna;
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
        }
        /* --------------------------------------------------------------------------------------------------------------- */
        /* --------------------- variabile de lucru pentru eveniment txtNrZileCazare ------------------------------------- */
        int vartxtNrZileCazare;
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
        }
        /* --------------------------------------------------------------------------------------------------------------- */
        /* --------------------- variabile de lucru pentru eveniment txtDiurna ------------------------------------------- */
        double vartxtDiurna;
        /* ------------------------- Eveniment pentru txtDiurna ---------------------------------------------------------- */
        private void txtDiurna_TextChanged(object sender, EventArgs e)
        {
            if (txtDiurna.Text.Contains(","))
            {
                MessageBox.Show("Caracterul \"(,) virgula\" nu este permis!");
                txtDiurna.Clear();
            }
            else
            {
                // Verificam daca valoarea din "txtDiurna" este de tip int si daca da, o inregistram in "vartxtDiurna"
                bool vartxtDiurnaEsteNumar = double.TryParse(txtDiurna.Text, out vartxtDiurna);
                if (vartxtDiurnaEsteNumar != false)
                {
                    vartxtDiurna = double.Parse(txtDiurna.Text, CultureInfo.InvariantCulture);
                }

                // Judecam si "sanctionam" la nevoie
                switch (vartxtDiurnaEsteNumar || txtDiurna.Text == string.Empty)
                {
                    case false:
                        // Golim casuta si afisam mesaj de eroare
                        txtDiurna.Clear();
                        MessageBox.Show("        Vă rugăm introduceți doar numere în această casetă de text.");
                        break;
                }
            }

            // Calculam
            MetodaCalculSubtotalDiurna();
        }
        /* --------------------------------------------------------------------------------------------------------------- */
        /* ------------------------- Variabile de lucru pentru txtCazare ------------------------------------------------- */
        double vartxtCazare;
        /* ------------------------- Eveniment pentru txtCazare ---------------------------------------------------------- */
        private void txtCazare_TextChanged(object sender, EventArgs e)
        {
            if (txtCazare.Text.Contains(","))
            {
                MessageBox.Show("Caracterul \"(,) virgula\" nu este permis!");
                txtCazare.Clear();
            }
            else
            {
                // Verificam daca valoarea din "txtCazare" este de tip int si daca da, o inregistram in "vartxtCazare"
                bool vartxtCazareEsteNumar = Double.TryParse(txtCazare.Text, out vartxtCazare);
                if (vartxtCazareEsteNumar != false)
                {
                    vartxtCazare = double.Parse(txtCazare.Text, CultureInfo.InvariantCulture);
                }


                // Judecam si "sanctionam" la nevoie
                switch (vartxtCazareEsteNumar || txtCazare.Text == string.Empty)
                {
                    case false:
                        // Golim casuta si afisam mesaj de eroare
                        txtCazare.Clear();
                        MessageBox.Show("        Vă rugăm introduceți doar numere în această casetă de text.");
                        break;
                }
            }

            // Calculam
            MetodaCalculSubtotalCazare();
        }
        /* --------------------------------------------------------------------------------------------------------------- */
        /* ------------------------ Variabile de lucru pentru txtTaxaDeParticipare --------------------------------------- */
        double vartxtTaxaDeParticipare;
        /* ------------------------- Eveniment pentru txtTaxaDeParticipare ----------------------------------------------- */
        private void txtTaxaDeParticipare_TextChanged(object sender, EventArgs e)
        {
            if (txtTaxaDeParticipare.Text.Contains(","))
            {
                MessageBox.Show("Caracterul \"(,) virgula\" nu este permis!");
                txtTaxaDeParticipare.Clear();
            }
            else
            {
                // Verificam daca valoarea din "txtTaxaDeParticipare" este de tip int si daca da, o inregistram in "vartxtTaxaDeParticipare"
                bool vartxtTaxaDeParticipareEsteNumar = Double.TryParse(txtTaxaDeParticipare.Text, out vartxtTaxaDeParticipare);
                if (vartxtTaxaDeParticipareEsteNumar != false)
                {
                    vartxtTaxaDeParticipare = double.Parse(txtTaxaDeParticipare.Text, CultureInfo.InvariantCulture);
                }

                // Judecam si "sanctionam" la nevoie
                switch (vartxtTaxaDeParticipareEsteNumar || txtTaxaDeParticipare.Text == string.Empty)
                {
                    case false:
                        // Golim casuta si afisam mesaj de eroare
                        txtTaxaDeParticipare.Clear();
                        MessageBox.Show("        Vă rugăm introduceți doar numere în această casetă de text.");
                        break;
                }
            }
        }
        /* --------------------------------------------------------------------------------------------------------------- */
        /* -------------------------- Variabile de lucru pentru txtTaxaDeViza -------------------------------------------- */
        double vartxtTaxaDeViza;
        /* ------------------------- Eveniment pentru txtTaxaDeViza ------------------------------------------------------ */
        private void txtTaxaDeViza_TextChanged(object sender, EventArgs e)
        {
            if (txtTaxaDeViza.Text.Contains(","))
            {
                MessageBox.Show("Caracterul \"(,) virgula\" nu este permis!");
                txtTaxaDeViza.Clear();
            }
            else
            {
                // Verificam daca valoarea din "txtTaxaDeViza" este de tip int si daca da, o inregistram in "vartxtTaxaDeViza"
                bool vartxtTaxaDeVizaEsteNumar = Double.TryParse(txtTaxaDeViza.Text, out vartxtTaxaDeViza);
                if (vartxtTaxaDeVizaEsteNumar != false)
                {
                    vartxtTaxaDeViza = double.Parse(txtTaxaDeViza.Text, CultureInfo.InvariantCulture);
                }
                // Judecam si "sanctionam" la nevoie
                switch (vartxtTaxaDeVizaEsteNumar || txtTaxaDeViza.Text == string.Empty)
                {
                    case false:
                        // Golim casuta si afisam mesaj de eroare
                        txtTaxaDeViza.Clear();
                        MessageBox.Show("        Vă rugăm introduceți doar numere în această casetă de text.");
                        break;
                }
            }
        }
        /* --------------------------------------------------------------------------------------------------------------- */
        /* -------------------------- Variabile de lucru pentru txtTaxaDeViza -------------------------------------------- */
        int vartxtNrInregistrare;
        /* --------------------------------------------------------------------------------------------------------------- */
        private void txtNrInregistrare_TextChanged(object sender, EventArgs e)
        {
            // Verificam daca valoarea din "txtNrInregistrare" este de tip int si daca da, o inregistram in "vartxtNrInregistrare"
            bool vartxtNrInregistrareEsteNumar = Int32.TryParse(txtNrInregistrare.Text, out vartxtNrInregistrare);

            // Judecam si "sanctionam" la nevoie
            switch (vartxtNrInregistrareEsteNumar || txtNrInregistrare.Text == string.Empty)
            {
                case false:
                    // Golim casuta si afisam mesaj de eroare
                    txtNrInregistrare.Clear();
                    MessageBox.Show("        Vă rugăm introduceți doar numere în această casetă de text.");
                    break;
            }

            // Efectuam
            if (txtNrInregistrare.Text != string.Empty)
            {
                // Activam
                lblNrUAICVechi.Enabled = true;
                txtNrUAICVechi.Enabled = true;
                lblNrVechi.Enabled = true;
            }
            else
            {
                // Dezactivam
                lblNrUAICVechi.Enabled = false;
                txtNrUAICVechi.Enabled = false;
                lblNrVechi.Enabled = false;
            }
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
            txtSubtotalDiurna.Text = varSubtotal.ToString() + " " + cmbMoneda1.SelectedItem;
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
            txtSubtotalCazare.Text = varSubtotal.ToString() + " " + cmbMoneda2.SelectedItem;
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








        /* ---------------- Evenimentul butonului btnAcceseaza ----------------------------------------------------------- */
        private void btnAcceseaza_Click(object sender, EventArgs e)
        {
            // Efectuam
            VerifExistentaODD();
        }
        /* --------------------------------------------------------------------------------------------------------------- */






        /* ---------------- Populam campurile cu datele corespunzatoare din BD ------------------------------------------- */
        private void PopulareFormular()
        {
            // Populam campurile cu date din BD
            using (OdbcConnection conexiune_populareDinBD = new OdbcConnection(sircon_RelIntDB))
            {           // Comanda
                using (OdbcCommand comanda_populareDinBD = new OdbcCommand())
                {
                    comanda_populareDinBD.Connection = conexiune_populareDinBD;
                    comanda_populareDinBD.CommandType = CommandType.Text;
                    comanda_populareDinBD.CommandText = "SELECT * FROM ordinedeplasare WHERE nrinregistrareodc = ? AND nrinregistrareod = ?";
                    comanda_populareDinBD.Parameters.AddWithValue("@nrinregistrareodc", OdbcType.Int).Value = vartxtNrInregistrare;
                    comanda_populareDinBD.Parameters.AddWithValue("@nrinregistrareod", OdbcType.Int).Value = vartxtNrUAICVechi;

                    try
                    {
                        conexiune_populareDinBD.Open();

                        OdbcDataReader cititor_populareDinBD = comanda_populareDinBD.ExecuteReader();

                        if (cititor_populareDinBD.HasRows)
                        {
                            while (cititor_populareDinBD.Read())
                            {
                                dpDataODDVeche.Value = cititor_populareDinBD.GetDateTime(3);
                                txtSubsemnatul.Text = cititor_populareDinBD.GetString(5);
                                cmbGradDidactic.SelectedItem = cititor_populareDinBD.GetString(6);
                                cmbFacultatea.SelectedItem = cititor_populareDinBD.GetString(7);
                                txtLocalitatea.Text = cititor_populareDinBD.GetString(8);
                                txtTara.Text = cititor_populareDinBD.GetString(9);
                                txtScop.Text = cititor_populareDinBD.GetString(10);
                                txtInstitutia.Text = cititor_populareDinBD.GetString(11);
                                dpDataInceput.Value = cititor_populareDinBD.GetDateTime(12);
                                dpDataSfarsit.Value = cititor_populareDinBD.GetDateTime(13);
                                txtRuta.Text = cititor_populareDinBD.GetString(14);
                                txtPlatitorTransport.Text = cititor_populareDinBD.GetString(15);
                                txtPlatitorIntretinere.Text = cititor_populareDinBD.GetString(16);
                                txtNrZileDiurna.Text = cititor_populareDinBD.GetString(17);
                                txtDiurna.Text = cititor_populareDinBD.GetString(18);
                                cmbMoneda1.SelectedItem = cititor_populareDinBD.GetString(19);
                                txtNrZileCazare.Text = cititor_populareDinBD.GetString(20);
                                txtCazare.Text = cititor_populareDinBD.GetString(21);
                                cmbMoneda2.SelectedItem = cititor_populareDinBD.GetString(22);
                                txtTaxaDeParticipare.Text = cititor_populareDinBD.GetString(23);
                                cmbMoneda3.SelectedItem = cititor_populareDinBD.GetString(24);
                                txtTaxaDeViza.Text = cititor_populareDinBD.GetString(25);
                                cmbMoneda4.SelectedItem = cititor_populareDinBD.GetString(26);
                                txtTotalDePlata.Text = cititor_populareDinBD.GetString(27);
                                txtDispunere1.Text = cititor_populareDinBD.GetString(28);
                                txtDispunere2.Text = cititor_populareDinBD.GetString(29);
                                txtDispunere3.Text = cititor_populareDinBD.GetString(30);
                                txtDispunere4.Text = cititor_populareDinBD.GetString(31);
                                rdoRector.Checked = cititor_populareDinBD.GetBoolean(32);
                                rdoProRector.Checked = cititor_populareDinBD.GetBoolean(33);
                                cmbRectorProrector.SelectedItem = cititor_populareDinBD.GetString(34);
                                txtDFC.Text = cititor_populareDinBD.GetString(35);
                                txtCPNumeProj.Text = cititor_populareDinBD.GetString(36);
                                cmbCPGradDidactic.SelectedItem = cititor_populareDinBD.GetString(37);
                                txtCPNumeCoord.Text = cititor_populareDinBD.GetString(38);

                                // Activam
                                txtNrUAICNou.Enabled = true;
                                dpDataODDNoua.Enabled = true;

                                panouContinutODD.Enabled = true;
                                panouCheltuieliODD.Enabled = true;
                                panouAlteDispuneriODD.Enabled = true;
                                panouSemnatariODD.Enabled = true;

                                    // Dezactivam
                                    txtNrInregistrare.Enabled = false;
                                    btnAcceseaza.Enabled = false;
                                    txtNrUAICVechi.Enabled = false;
                                    btnAcceseaza.Enabled = false;
                                    dpDataODDVeche.Enabled = false;
                            }
                        }

                        cititor_populareDinBD.Close();
                    }
                    catch (Exception expopulareDinBD)
                    {
                        MessageBox.Show(expopulareDinBD.Message);
                    } // Ne deconectam
                    finally
                    {
                        conexiune_populareDinBD.Close();
                    }
                }
            }
        }
        /* --------------------------------------------------------------------------------------------------------------- */







        /* ----------------- Verificam daca a mai fost introdus un ODD pentru o anumita cerere de deplasare -------------- */
        private void VerifExistentaODD()
        {
            using (OdbcConnection conexiune_VerifExistentaODD = new OdbcConnection(sircon_RelIntDB))
            {
                // Comanda
                using (OdbcCommand comanda_VerifExistentaODD = new OdbcCommand())
                {
                    comanda_VerifExistentaODD.Connection = conexiune_VerifExistentaODD;
                    comanda_VerifExistentaODD.CommandType = CommandType.Text;
                    comanda_VerifExistentaODD.CommandText = "SELECT nrinregistrareodc, nrinregistrareod FROM ordinedeplasare WHERE nrinregistrareodc = ? AND nrinregistrareod = ?";
                    comanda_VerifExistentaODD.Parameters.AddWithValue("@nrinregistrareodc", OdbcType.Int).Value = vartxtNrInregistrare;
                    comanda_VerifExistentaODD.Parameters.AddWithValue("@nrinregistrareod", OdbcType.Int).Value = vartxtNrUAICVechi;

                    OdbcDataReader cititor_VerifExistentaODD;

                    try
                    {
                        conexiune_VerifExistentaODD.Open();
                        cititor_VerifExistentaODD = comanda_VerifExistentaODD.ExecuteReader();

                        if (cititor_VerifExistentaODD.HasRows)
                        {
                            // Efectuam
                            PopulareFormular();
                        }
                        else
                        {
                            // Efectuam
                            MessageBox.Show("Nu există ordinul de deplasare solicitat! Vă rugăm reluați completarea.");
                            txtNrUAICVechi.Clear();
                            txtNrInregistrare.Clear();
                            txtNrInregistrare.Focus();
                        }
                    }
                    catch (Exception exVerifExistentaODD)
                    {
                        MessageBox.Show(exVerifExistentaODD.Message);
                    }
                    finally
                    {
                        conexiune_VerifExistentaODD.Close();
                    }
                }
            }
        }
        /* --------------------------------------------------------------------------------------------------------------- */








        bool MetodaInserareSucces = false;
        /* ------------ Metoda de inserare a datelor in RelIntDB --------------------------------------------------------- */
        private void MetodaInserareDB()
        {
            // Metoda de inserare a datelor
            // Conexiunea
            using (OdbcConnection conexiune_InserareCerereRelInt = new OdbcConnection(sircon_RelIntDB))
            {           // Comanda
                using (OdbcCommand comanda_inserareRelInt = new OdbcCommand())
                {
                    comanda_inserareRelInt.Connection = conexiune_InserareCerereRelInt;
                    comanda_inserareRelInt.CommandType = CommandType.Text;
                    comanda_inserareRelInt.CommandText = "UPDATE ordinedeplasare SET nrinregistrareod = ?, nrinregistrareodnou = ?, dataOD = ?, dataODNoua = ?, subsemnatulOD = ?, graddidacticOD = ?, facultateaOD = ?, localitateaOD = ?, taraOD = ?, scopod = ?, institutiaOD = ?, datainceputOD = ?, datasfarsitOD = ?, rutaOD = ?, platitortranspOD = ?, platitorintretinereOD = ?, nrzilediurnaOD = ?, diurnaOD = ?, monedadiurnaOD = ?, nrzilecazareOD = ?, cazareOD = ?, monedacazareOD = ?, taxadeparticipareOD = ?, monedataxadeparticipareOD = ?, taxadevizaetcOD = ?, monedataxadevizaetcOD = ?, totalOD = ?, altedispuneri1OD = ?, altedispuneri2OD = ?, altedispuneri3OD = ?, altedispuneri4OD = ?, rectorOD = ?, prorectorOD = ?, numerpOD = ?, dfcOD = ?, cpnumeprojOD = ?, cpgraddidacticOD = ?, cpnumecoordOD = ?, oddi = ? WHERE nrinregistrareodc = ?";
                    comanda_inserareRelInt.Parameters.AddWithValue("@nrinregistrareod", OdbcType.Int).Value = vartxtNrUAICVechi;
                    comanda_inserareRelInt.Parameters.AddWithValue("@nrinregistrareodnou", OdbcType.Int).Value = vartxtNrUAICNou;
                    comanda_inserareRelInt.Parameters.AddWithValue("@dataOD", OdbcType.DateTime).Value = dpDataODDVeche.Value;
                    comanda_inserareRelInt.Parameters.AddWithValue("@dataODNoua", OdbcType.DateTime).Value = dpDataODDNoua.Value;
                    comanda_inserareRelInt.Parameters.AddWithValue("@subsemnatulOD", OdbcType.NVarChar).Value = txtSubsemnatul.Text;
                    comanda_inserareRelInt.Parameters.AddWithValue("@graddidacticOD", OdbcType.NVarChar).Value = cmbGradDidactic.SelectedItem;
                    comanda_inserareRelInt.Parameters.AddWithValue("@facultateaOD", OdbcType.NVarChar).Value = cmbFacultatea.SelectedItem;
                    comanda_inserareRelInt.Parameters.AddWithValue("@localitateaOD", OdbcType.NVarChar).Value = txtLocalitatea.Text;
                    comanda_inserareRelInt.Parameters.AddWithValue("@taraOD", OdbcType.NVarChar).Value = txtTara.Text;
                    comanda_inserareRelInt.Parameters.AddWithValue("@scopOD", OdbcType.NVarChar).Value = txtScop.Text;
                    comanda_inserareRelInt.Parameters.AddWithValue("@institutiaOD", OdbcType.NVarChar).Value = txtInstitutia.Text;
                    comanda_inserareRelInt.Parameters.AddWithValue("@datainceputOD", OdbcType.DateTime).Value = dpDataInceput.Value;
                    comanda_inserareRelInt.Parameters.AddWithValue("@datasfarsitOD", OdbcType.DateTime).Value = dpDataSfarsit.Value;
                    comanda_inserareRelInt.Parameters.AddWithValue("@rutaOD", OdbcType.NVarChar).Value = txtRuta.Text;
                    comanda_inserareRelInt.Parameters.AddWithValue("@platitortranspOD", OdbcType.NVarChar).Value = txtPlatitorTransport.Text;
                    comanda_inserareRelInt.Parameters.AddWithValue("@platitorintretinereOD", OdbcType.NVarChar).Value = txtPlatitorIntretinere.Text;
                    comanda_inserareRelInt.Parameters.AddWithValue("@nrzilediurnaOD", OdbcType.Int).Value = vartxtNrZileDiurna;
                    comanda_inserareRelInt.Parameters.AddWithValue("@diurnaOD", OdbcType.Double).Value = vartxtDiurna;
                    comanda_inserareRelInt.Parameters.AddWithValue("@monedadiurnaOD", OdbcType.NVarChar).Value = cmbMoneda1.SelectedItem;
                    comanda_inserareRelInt.Parameters.AddWithValue("@nrzilecazareOD", OdbcType.Int).Value = vartxtNrZileCazare;
                    comanda_inserareRelInt.Parameters.AddWithValue("@cazareOD", OdbcType.Double).Value = vartxtCazare;
                    comanda_inserareRelInt.Parameters.AddWithValue("@monedacazareOD", OdbcType.NVarChar).Value = cmbMoneda2.SelectedItem;
                    comanda_inserareRelInt.Parameters.AddWithValue("@taxadeparticipareOD", OdbcType.Double).Value = vartxtTaxaDeParticipare;
                    comanda_inserareRelInt.Parameters.AddWithValue("@monedataxadeparticipareOD", OdbcType.NVarChar).Value = cmbMoneda3.SelectedItem;
                    comanda_inserareRelInt.Parameters.AddWithValue("@taxadevizaetcOD", OdbcType.Double).Value = vartxtTaxaDeViza;
                    comanda_inserareRelInt.Parameters.AddWithValue("@monedataxadevizaetcOD", OdbcType.NVarChar).Value = cmbMoneda4.SelectedItem;
                    comanda_inserareRelInt.Parameters.AddWithValue("@totalOD", OdbcType.NVarChar).Value = CalculTotal();
                    comanda_inserareRelInt.Parameters.AddWithValue("@altedispuneri1OD", OdbcType.NVarChar).Value = txtDispunere1.Text;
                    comanda_inserareRelInt.Parameters.AddWithValue("@altedispuneri2OD", OdbcType.NVarChar).Value = txtDispunere2.Text;
                    comanda_inserareRelInt.Parameters.AddWithValue("@altedispuneri3OD", OdbcType.NVarChar).Value = txtDispunere3.Text;
                    comanda_inserareRelInt.Parameters.AddWithValue("@altedispuneri4OD", OdbcType.NVarChar).Value = txtDispunere4.Text;
                    comanda_inserareRelInt.Parameters.AddWithValue("@rectorOD", OdbcType.Bit).Value = rdoRector.Checked;
                    comanda_inserareRelInt.Parameters.AddWithValue("@prorectorOD", OdbcType.Bit).Value = rdoProRector.Checked;
                    comanda_inserareRelInt.Parameters.AddWithValue("@numerpOD", OdbcType.NVarChar).Value = cmbRectorProrector.SelectedItem;
                    comanda_inserareRelInt.Parameters.AddWithValue("@dfcOD", OdbcType.NVarChar).Value = txtDFC.Text;
                    comanda_inserareRelInt.Parameters.AddWithValue("@cpnumeprojOD", OdbcType.NVarChar).Value = txtCPNumeProj.Text;
                    comanda_inserareRelInt.Parameters.AddWithValue("@cpgraddidacticOD", OdbcType.NVarChar).Value = cmbCPGradDidactic.SelectedItem;
                    comanda_inserareRelInt.Parameters.AddWithValue("@cpnumecoordOD", OdbcType.NVarChar).Value = txtCPNumeCoord.Text;
                    comanda_inserareRelInt.Parameters.AddWithValue("@oddi", OdbcType.Bit).Value = true;

                    comanda_inserareRelInt.Parameters.AddWithValue("@nrinregistrareodc", OdbcType.Int).Value = vartxtNrInregistrare;

                    // Incercam conexiunea si query-ul
                    try
                    {
                        conexiune_InserareCerereRelInt.Open();
                        int recordsAffected = comanda_inserareRelInt.ExecuteNonQuery();
                        MetodaInserareSucces = true;
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
        }
        /* --------------------------------------------------------------------------------------------------------------- */









        /* ----------------- Metoda calcularii totalului din textbox-ul "txtTotalDePlata" -------------------------------- */
        private string CalculTotal()
        {
            double diurna;
            bool diurnaEsteNumar = double.TryParse(txtDiurna.Text, out diurna);
            if (diurnaEsteNumar != false)
            {
                diurna = double.Parse(txtDiurna.Text, CultureInfo.InvariantCulture);
            }

            double cazare;
            bool cazareEsteNumar = double.TryParse(txtDiurna.Text, out cazare);
            if (cazareEsteNumar != false)
            {
                cazare = double.Parse(txtCazare.Text, CultureInfo.InvariantCulture);
            }

            double taxaParticipare;
            bool taxaParticipareEsteNumar = double.TryParse(txtDiurna.Text, out taxaParticipare);
            if (taxaParticipareEsteNumar != false)
            {
                taxaParticipare = double.Parse(txtTaxaDeParticipare.Text, CultureInfo.InvariantCulture);
            }

            double taxaDeViza;
            bool taxaDeVizaEsteNumar = double.TryParse(txtDiurna.Text, out taxaDeViza);
            if (taxaDeVizaEsteNumar != false)
            {
                taxaDeViza = double.Parse(txtTaxaDeViza.Text, CultureInfo.InvariantCulture);
            }


            string total = string.Empty;

            string moneda1 = cmbMoneda1.SelectedItem.ToString();
            string moneda2 = cmbMoneda2.SelectedItem.ToString();
            string moneda3 = cmbMoneda3.SelectedItem.ToString();
            string moneda4 = cmbMoneda4.SelectedItem.ToString();

            Dictionary<string, double> valoriIntroduse = new Dictionary<string, double>();
            valoriIntroduse.Add(moneda1, diurna * vartxtNrZileDiurna);
            if (valoriIntroduse.ContainsKey(moneda2))
            {
                valoriIntroduse[moneda2] = valoriIntroduse[moneda2] + cazare * vartxtNrZileCazare;
            }
            else
            {
                valoriIntroduse.Add(moneda2, cazare * vartxtNrZileCazare);
            }

            if (valoriIntroduse.ContainsKey(moneda3))
            {
                valoriIntroduse[moneda3] = valoriIntroduse[moneda3] + taxaParticipare;
            }
            else
            {
                valoriIntroduse.Add(moneda3, taxaParticipare);
            }

            if (valoriIntroduse.ContainsKey(moneda4))
            {
                valoriIntroduse[moneda4] = valoriIntroduse[moneda4] + taxaDeViza;
            }
            else
            {
                valoriIntroduse.Add(moneda4, taxaDeViza);
            }

            foreach (var pereche in valoriIntroduse)
            {
                total += pereche.Value + pereche.Key + " ";
            }
            return total;
        }
        /* --------------------------------------------------------------------------------------------------------------- */





        bool SuccesSalvareFormular = false;
        /* -------------- Actiunile ce iau loc la salvare ---------------------------------------------------------------- */
        private void SalvareFormular()
        {
            // Daca casetele urmatoare nu sunt goale
            if (txtNrUAICVechi.Text != string.Empty && cmbGradDidactic.SelectedIndex != -1 && cmbFacultatea.SelectedIndex != -1 && cmbMoneda1.SelectedIndex != -1 && cmbMoneda2.SelectedIndex != -1 && cmbMoneda3.SelectedIndex != -1 && cmbMoneda4.SelectedIndex != -1 && cmbRectorProrector.SelectedIndex != -1 && txtDFC.Text != string.Empty)
            {
                // Lucreaza asta
                txtTotalDePlata.Text = CalculTotal();

                // Lucreaza asta
                MetodaInserareDB();

                // Daca variabila "MetodaInserareSucces" este adevarata
                if (MetodaInserareSucces == true)
                {
                    // Dezactivam urmatoarele
                    panouIdentificareODD.Enabled = false;
                    panouContinutODD.Enabled = false;
                    panouCheltuieliODD.Enabled = false;
                    panouAlteDispuneriODD.Enabled = false;
                    panouSemnatariODD.Enabled = false;

                    // Generam PDF
                    GenerarePDF();

                    // Notifica
                    SuccesSalvareFormular = true;

                    // Dezactivam
                    btnSalvare.Enabled = false;

                    // Negam modificarile
                    MetodaNegareControale();
                }
                else
                {
                    // Notifica
                    SuccesSalvareFormular = false;

                    // Dezactivam
                    btnSalvare.Enabled = true;
                }
            }
            // Daca urmatoarele
            else
            {
                if (txtNrUAICVechi.Text == string.Empty)
                {
                    // Afiseaza eroarea
                    MessageBox.Show(
                        "               Nu ați completat caseta \"Număr UAIC\"! \n                              Vă rugăm să o completați.");
                }
                else if (cmbGradDidactic.SelectedIndex == -1)
                {
                    // Afiseaza eroarea
                    MessageBox.Show(
                        "               Nu ați selectat nici un grad didactic (-- Grad didactic --) ! \n                 Vă rugăm selectați o valoare.");
                }
                else if (cmbFacultatea.SelectedIndex == -1)
                {
                    // Afiseaza eroarea
                    MessageBox.Show(
                        "               Nu ați selectat nici o facultate (-- Facultatea --) ! \n                 Vă rugăm selectați o valoare.");
                }
                else if (cmbMoneda1.SelectedIndex == -1)
                {
                    // Afiseaza eroarea
                    MessageBox.Show(
                        "               Nu ați selectat nici o moneda (-- Diurnă --) ! \n                 Vă rugăm selectați o valoare.");
                }
                else if (cmbMoneda2.SelectedIndex == -1)
                {
                    // Afiseaza eroarea
                    MessageBox.Show(
                        "               Nu ați selectat nici o moneda (-- Cazare --) ! \n                 Vă rugăm selectați o valoare.");
                }
                else if (cmbMoneda3.SelectedIndex == -1)
                {
                    // Afiseaza eroarea
                    MessageBox.Show(
                        "               Nu ați selectat nici o moneda (-- Taxă de participare --) ! \n                 Vă rugăm selectați o valoare.");
                }
                else if (cmbMoneda4.SelectedIndex == -1)
                {
                    // Afiseaza eroarea
                    MessageBox.Show(
                        "               Nu ați selectat nici o moneda (-- Taxă de Viza + Asigurare Medicală --) ! \n                 Vă rugăm selectați o valoare.");
                }
                else if (cmbRectorProrector.SelectedIndex == -1)
                {
                    // Afiseaza eroarea
                    MessageBox.Show(
                        "               Nu ați selectat nici un Rector / ProRector (-- Rector/ProRector --) ! \n                 Vă rugăm selectați o valoare.");
                }
                else if (txtDFC.Text == string.Empty)
                {
                    // Afiseaza eroarea
                    MessageBox.Show(
                        "               Nu ați introdus nici un Director Financiar Contabil (-- Director Financiar-Contabil --) ! \n                 Vă rugăm introduceți o valoare.");
                }
            }
        }
        /* --------------------------------------------------------------------------------------------------------------- */





        /* --------------------- Eveniment click pentru butonul "Salvare" ------------------------------------------------ */
        private void GenerarePDF()
        {
            // Create a MigraDoc document
            Document documentPDF = new Document();
            documentPDF.Info.Author = "Departamentul Relatii Internationale";
            documentPDF.Info.Keywords = "Generare, PDF";
            Unit width, height;
            PageSetup.GetPageSize(PageFormat.A4, out width, out height);

            Section section1 = documentPDF.AddSection();
            section1.PageSetup.PageHeight = height;
            section1.PageSetup.PageWidth = width;
            section1.PageSetup.LeftMargin = 60;
            section1.PageSetup.RightMargin = 60;
            section1.PageSetup.TopMargin = 40;
            section1.PageSetup.BottomMargin = 40;
            section1.PageSetup.OddAndEvenPagesHeaderFooter = true;
            section1.PageSetup.StartingNumber = 1;

            // Paragraf 1
            Paragraph paragraf1 = section1.AddParagraph();
            paragraf1.Format.Alignment = ParagraphAlignment.Center;
            paragraf1.Format.Font.Size = 14;
            paragraf1.Format.Font.Name = "Times New Roman";
            paragraf1.AddText("ROMÂNIA");

            // Paragraf 2
            Paragraph paragraf2 = section1.AddParagraph();
            paragraf2.Format.Alignment = ParagraphAlignment.Center;
            paragraf2.Format.Font.Size = 14;
            paragraf2.Format.Font.Name = "Times New Roman";
            paragraf2.AddText("MINISTERUL EDUCAȚIEI ȘI CERCETĂRII ȘTIINȚIFICE");

            // Paragraf 3
            Paragraph paragraf3 = section1.AddParagraph();
            paragraf3.Format.Alignment = ParagraphAlignment.Center;
            paragraf3.Format.Font.Size = 14;
            paragraf3.Format.Font.Name = "Times New Roman";
            paragraf3.AddText("UNIVERSITATEA \"ALEXANDRU IOAN CUZA\" DIN IAȘI");

            // Paragraf 4
            Paragraph paragraf4 = section1.AddParagraph();
            paragraf4.Format.Alignment = ParagraphAlignment.Center;
            paragraf4.Format.Font.Size = 14;
            paragraf4.Format.Font.Name = "Times New Roman";
            paragraf4.AddText("DISPOZIȚIA");

            // Paragraf 5
            Paragraph paragraf5 = section1.AddParagraph();
            paragraf5.Format.Alignment = ParagraphAlignment.Center;
            paragraf5.Format.Font.Size = 13;
            paragraf5.Format.Font.Name = "Times New Roman";
            paragraf5.Format.Font.Bold = true;
            paragraf5.AddText("Nr. " + txtNrUAICVechi.Text + " și " + txtNrUAICNou.Text + " / " + txtNrInregistrare.Text + " din " + dpDataODDNoua.Value.ToString().Substring(0, DateTime.Today.ToString().IndexOf("00:")) + "*");

            // Paragraf 6
            Paragraph paragraf6 = section1.AddParagraph();
            paragraf6.Format.Alignment = ParagraphAlignment.Center;
            paragraf6.Format.Font.Size = 13;
            paragraf6.Format.Font.Name = "Times New Roman";
            paragraf6.Format.SpaceBefore = "1.0cm";
            paragraf6.Format.Alignment = ParagraphAlignment.Justify;
            paragraf6.AddText("În temeiul Ordinului M.Ed.C. nr. 4975/30.04.1992 și al Hotărârii Biroului Executiv al Consiliului de Administrație din data de ");
            paragraf6.AddFormattedText(dpDataODDVeche.Value.ToString().Substring(0, DateTime.Today.ToString().IndexOf("00:")), TextFormat.Bold);
            paragraf6.AddText(" și ");
            paragraf6.AddFormattedText(dpDataODDNoua.Value.ToString().Substring(0, DateTime.Today.ToString().IndexOf("00:")) + ".", TextFormat.Bold);

            // Paragraf 7
            Paragraph paragraf7 = section1.AddParagraph();
            paragraf7.Format.Alignment = ParagraphAlignment.Center;
            paragraf7.Format.Font.Size = 13;
            paragraf7.Format.Font.Name = "Times New Roman";
            paragraf7.Format.SpaceBefore = "1.0cm";
            paragraf7.AddText("RECTORUL dispune:");

            // Paragraf 8
            Paragraph paragraf8 = section1.AddParagraph();
            paragraf8.Format.Font.Size = 13;
            paragraf8.Format.Font.Name = "Times New Roman";
            paragraf8.Format.Alignment = ParagraphAlignment.Justify;
            paragraf8.Format.SpaceBefore = "1.0cm";
            paragraf8.AddText("1. Deplasarea D-lui/ D-nei ");
            paragraf8.AddFormattedText(txtSubsemnatul.Text, TextFormat.Bold);
            paragraf8.AddFormattedText(", " + cmbGradDidactic.SelectedItem + " la " + cmbFacultatea.SelectedItem + ",");


            // Paragraf 9
            Paragraph paragraf9 = section1.AddParagraph();
            paragraf9.Format.Alignment = ParagraphAlignment.Justify;
            paragraf9.Format.Font.Size = 13;
            paragraf9.Format.SpaceBefore = "0.5cm";
            paragraf9.Format.Font.Name = "Times New Roman";
            paragraf9.AddText("în localitatea: ");
            paragraf9.AddFormattedText(txtLocalitatea.Text, TextFormat.Bold);
            paragraf9.AddFormattedText(", țara: ");
            paragraf9.AddFormattedText(txtTara.Text, TextFormat.Bold);
            paragraf9.AddFormattedText(".");

            // Paragraf 10
            Paragraph paragraf10 = section1.AddParagraph();
            paragraf10.Format.Alignment = ParagraphAlignment.Justify;
            paragraf10.Format.Font.Size = 13;
            paragraf10.Format.SpaceBefore = "0.5cm";
            paragraf10.Format.Font.Name = "Times New Roman";
            paragraf10.AddText("Scopul: ");
            paragraf10.AddFormattedText(txtScop.Text, TextFormat.Bold);

            // Paragraf 11
            Paragraph paragraf11 = section1.AddParagraph();
            paragraf11.Format.Alignment = ParagraphAlignment.Justify;
            paragraf11.Format.Font.Size = 13;
            paragraf11.Format.SpaceBefore = "0.3cm";
            paragraf11.Format.Font.Name = "Times New Roman";
            paragraf11.AddText("deplasarea are loc între ");
            paragraf11.AddFormattedText(dpDataInceput.Value.ToString().Substring(0, DateTime.Today.ToString().IndexOf("00:")), TextFormat.Bold);
            paragraf11.AddText(" și ");
            paragraf11.AddFormattedText(dpDataSfarsit.Value.ToString().Substring(0, DateTime.Today.ToString().IndexOf("00:")), TextFormat.Bold);

            // Paragraf 12
            Paragraph paragraf12 = section1.AddParagraph();
            paragraf12.Format.Alignment = ParagraphAlignment.Justify;
            paragraf12.Format.Font.Size = 13;
            paragraf12.Format.SpaceBefore = "0.3cm";
            paragraf12.Format.Font.Name = "Times New Roman";
            paragraf12.AddText("2. Cheltuielile de transport internațional pe ruta: ");
            paragraf12.AddFormattedText(txtRuta.Text, TextFormat.Bold);

            // Paragraf 13
            Paragraph paragraf13 = section1.AddParagraph();
            paragraf13.Format.Alignment = ParagraphAlignment.Justify;
            paragraf13.Format.Font.Size = 13;
            paragraf13.Format.SpaceBefore = "0.3cm";
            paragraf13.Format.Font.Name = "Times New Roman";
            paragraf13.AddText("sunt suportate: ");
            paragraf13.AddFormattedText(txtPlatitorTransport.Text, TextFormat.Bold);

            // Paragraf 14
            Paragraph paragraf14 = section1.AddParagraph();
            paragraf14.Format.Alignment = ParagraphAlignment.Justify;
            paragraf14.Format.Font.Size = 13;
            paragraf14.Format.SpaceBefore = "0.3cm";
            paragraf14.Format.Font.Name = "Times New Roman";
            paragraf14.AddText("și cheltuielile de întreținere în străinătate sunt suportate de la: ");
            paragraf14.AddFormattedText(txtPlatitorIntretinere.Text, TextFormat.Bold);

            // Paragraf 15
            Paragraph paragraf15 = section1.AddParagraph();
            paragraf15.Format.Alignment = ParagraphAlignment.Justify;
            paragraf15.Format.Font.Size = 13;
            paragraf15.Format.SpaceBefore = "0.3cm";
            paragraf15.Format.Font.Name = "Times New Roman";
            paragraf15.AddText("Diurna: ");
            paragraf15.AddFormattedText(txtNrZileDiurna.Text + " x " + txtDiurna.Text + " " + cmbMoneda1.SelectedItem + " = " + txtSubtotalDiurna.Text, TextFormat.Bold);

            // Paragraf 16
            Paragraph paragraf16 = section1.AddParagraph();
            paragraf16.Format.Alignment = ParagraphAlignment.Justify;
            paragraf16.Format.Font.Size = 13;
            paragraf16.Format.Font.Name = "Times New Roman";
            paragraf16.AddText("Cazare: ");
            paragraf16.AddFormattedText(txtNrZileCazare.Text + " x " + txtCazare.Text + " " + cmbMoneda2.SelectedItem + " = " + txtSubtotalCazare.Text, TextFormat.Bold);

            // Paragraf 17
            Paragraph paragraf17 = section1.AddParagraph();
            paragraf17.Format.Alignment = ParagraphAlignment.Justify;
            paragraf17.Format.Font.Size = 13;
            paragraf17.Format.Font.Name = "Times New Roman";
            paragraf17.AddText("Taxă de participare: ");
            paragraf17.AddFormattedText(txtTaxaDeParticipare.Text + " " + cmbMoneda3.SelectedItem, TextFormat.Bold);

            // Paragraf 18
            Paragraph paragraf18 = section1.AddParagraph();
            paragraf18.Format.Alignment = ParagraphAlignment.Justify;
            paragraf18.Format.Font.Size = 13;
            paragraf18.Format.Font.Name = "Times New Roman";
            paragraf18.AddText("Asigurare medicală și taxe consulare: ");
            paragraf18.AddFormattedText(txtTaxaDeViza.Text + " " + cmbMoneda4.SelectedItem, TextFormat.Bold);

            // Paragraf 19
            Paragraph paragraf19 = section1.AddParagraph();
            paragraf19.Format.Alignment = ParagraphAlignment.Justify;
            paragraf19.Format.Font.Size = 13;
            paragraf19.Format.Font.Underline = Underline.Single;
            paragraf19.Format.SpaceBefore = "0.5cm";
            paragraf19.Format.SpaceAfter = "0.5cm";
            paragraf19.Format.Font.Name = "Times New Roman";
            paragraf19.Format.Font.Bold = true;
            paragraf19.AddFormattedText("Total: în limita sumei de " + txtTotalDePlata.Text, TextFormat.Bold);

            // Paragraf 20
            Paragraph paragraf20 = section1.AddParagraph();
            paragraf20.Format.Alignment = ParagraphAlignment.Justify;
            paragraf20.Format.Font.Size = 13;
            paragraf20.Format.SpaceBefore = "0.3cm";
            paragraf20.Format.Font.Name = "Times New Roman";
            paragraf20.AddText("3. Pe perioada deplasării, se asigură salariul în țară conform normelor în vigoare.");

            // Paragraf 21
            Paragraph paragraf21 = section1.AddParagraph();
            paragraf21.Format.Alignment = ParagraphAlignment.Justify;
            paragraf21.Format.Font.Size = 13;
            paragraf21.Format.Font.Name = "Times New Roman";
            paragraf21.AddText("4. Serviciile CONTABILITATE și ORGANIZARE - SALARIZARE vor duce la îndeplinire prevederile prezentei dispoziții.");


            var table1 = section1.AddTable();
            table1.Format.SpaceBefore = "1.0cm";
            table1.AddColumn("11cm");
            table1.AddColumn("8cm");

            var row1 = table1.AddRow();
            var paragraph22 = row1.Cells[0].AddParagraph("RECTOR,");
            paragraph22.AddTab();
            paragraph22.Format.ClearAll();
            // TabStop at column width minus inner margins and borders:
            paragraph22.Format.AddTabStop("7.7cm", MigraDoc.DocumentObjectModel.TabAlignment.Right);
            row1.Cells[1].AddParagraph("DIRECTOR FINANCIAR CONTABIL,");
            table1.Borders.Width = 0;

            var table2 = section1.AddTable();
            table2.Format.SpaceBefore = "1.0cm";
            table2.AddColumn("11cm");
            table2.AddColumn("8cm");

            var row2 = table2.AddRow();
            var paragraph23 = row2.Cells[0].AddParagraph(cmbRectorProrector.Text + "");
            paragraph23.AddTab();
            paragraph23.Format.ClearAll();
            // TabStop at column width minus inner margins and borders:
            paragraph23.Format.AddTabStop("7.7cm", MigraDoc.DocumentObjectModel.TabAlignment.Right);
            row2.Cells[1].AddParagraph(txtDFC.Text);
            table2.Borders.Width = 0;

            // Paragraf 22
            Paragraph paragraf22 = section1.AddParagraph();
            paragraf22.Format.Alignment = ParagraphAlignment.Center;
            paragraf22.Format.Font.Size = 13;
            paragraf22.Format.SpaceBefore = "1cm";
            paragraf22.Format.Font.Name = "Times New Roman";
            paragraf22.AddText("Coordonator " + txtCPNumeProj.Text);

            // Paragraf 23
            Paragraph paragraf23 = section1.AddParagraph();
            paragraf23.Format.Alignment = ParagraphAlignment.Center;
            paragraf23.Format.Font.Size = 13;
            paragraf23.Format.SpaceBefore = "0.3cm";
            paragraf23.Format.Font.Name = "Times New Roman";
            paragraf23.AddText("" + cmbCPGradDidactic.SelectedItem);
            paragraf23.AddFormattedText(" " + txtCPNumeCoord.Text, TextFormat.Bold);

            // Paragraf 24
            Paragraph paragraf24 = section1.AddParagraph();
            paragraf24.Format.Alignment = ParagraphAlignment.Left;
            paragraf24.Format.Font.Size = 13;
            paragraf24.Format.SpaceBefore = "1cm";
            paragraf24.Format.Font.Name = "Times New Roman";
            paragraf24.Format.Borders.Top.Visible = true;
            paragraf24.Format.Borders.Top.Width = 0.1;
            paragraf24.AddFormattedText("* Înlocuiește și anulează Dispoziția nr. " + txtNrUAICVechi.Text + " / " + txtNrInregistrare.Text + " din " + dpDataODDVeche.Value.ToString().Substring(0, DateTime.Today.ToString().IndexOf("00:")), TextFormat.Bold);


            PdfDocumentRenderer pdfRenderer = new PdfDocumentRenderer(true);
            pdfRenderer.Document = documentPDF;
            pdfRenderer.RenderDocument();

            string NumeFisierPDF = string.Empty;

            SaveFileDialog dlgPDFSalvat = new SaveFileDialog();
            dlgPDFSalvat.FileName = "Document";
            dlgPDFSalvat.DefaultExt = ".pdf";
            dlgPDFSalvat.Filter = "PDF documents (.pdf)|*.pdf";


            if (dlgPDFSalvat.ShowDialog() == DialogResult.OK)
            {
                // Atribuim numele standard
                NumeFisierPDF = dlgPDFSalvat.FileName;

                // Salvam fisierul PDF
                pdfRenderer.PdfDocument.Save(NumeFisierPDF);

                // Deschidem fisierul dupa ce l-am salvat
                Process.Start(NumeFisierPDF);
            }
            else
            {
                // Inchidem formularul curent
                this.Close();
            }
        }
        /* --------------------------------------------------------------------------------------------------------------- */







        /* -------------------- Negam controalele urmatoare -------------------------------------------------------------- */
        private void MetodaNegareControale()
        {
            txtNrUAICNouSchimbat = false;
        }
        /* --------------------------------------------------------------------------------------------------------------- */








        /* ----------------- Variabila de lucru pentru metoda "CevaSchimbat" --------------------------------------------- */
        bool DacaCevaSchimbat;
        /* ------------------ Metoda ce verifica daca s-a schimbat ceva la vreunul din campurile formularului ------------ */
        private void CevaSchimbat()
        {
            // Daca vreuna din variabilele urmatoare este adevarata atunci
            if (txtNrUAICNouSchimbat)
            {
                DacaCevaSchimbat = true;
            }

            // Daca niciuna din variabilele urmatoare nu este adevarata atunci
            else
            {
                DacaCevaSchimbat = false;
            }
        }
        /* --------------------------------------------------------------------------------------------------------------- */





        /* ----------------------- Evenimentul inchiderii formularului --------------------------------------------------- */
        private void frmOrdinDeDeplasare_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Executam verificarea starii de modificare a campurilor din formular
            CevaSchimbat();

            // Verificam daca a fost modificat vreun camp
            if (DacaCevaSchimbat == true)
            {
                // Verificam daca formularul a fost salvat deja

                // Daca formularul nu a fost salvat
                if (SuccesSalvareFormular == false)
                {

                    // Intrebam utilizatorul daca doreste sa-l salveze
                    DialogResult DialogSalvare = MessageBox.Show("Doriți sa salvați formularul curent?", "Salvare formular", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                    // Daca DORESTE sa salveze
                    if (DialogSalvare == DialogResult.Yes)
                    {
                        // Salvam formularul
                        SalvareFormular();

                        // Daca S-A salvat
                        if (SuccesSalvareFormular == true)
                        {
                            // Apelam "MetodaNegareControale" si inchidem formularul
                            MetodaNegareControale();
                        }

                        // Daca NU s-a salvat
                        else if (SuccesSalvareFormular == false)
                        {
                            // Anulam inchiderea
                            e.Cancel = true;
                        }
                    }

                    // Daca NU DORESTE sa salveze
                    else if (DialogSalvare == DialogResult.No)
                    {
                        // Apelam "MetodaNegareControale" si inchidem formularul
                        MetodaNegareControale();
                    }

                    // Daca utilizatorul apasa cancel
                    else if (DialogSalvare == DialogResult.Cancel)
                    {
                        // Anulam inchiderea
                        e.Cancel = true;
                    }
                }

                // Daca formularul a fost salvat
                else if (SuccesSalvareFormular == true)
                {
                    // Apelam "MetodaNegareControale" si inchidem formularul
                    MetodaNegareControale();
                }
            }

            // Daca nu a fost modificat nici un camp, inchidem formularul
            else if (DacaCevaSchimbat == false)
            {
                // Apelam "MetodaNegareControale" si inchidem formularul
                MetodaNegareControale();
            }
        }
        /* --------------------------------------------------------------------------------------------------------------- */






        /* --------------------- Evenimentul butonului btnSalvare -------------------------------------------------------- */
        private void btnSalvare_Click(object sender, EventArgs e)
        {
            SalvareFormular();
        }
        /* --------------------------------------------------------------------------------------------------------------- */






    }
}