using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Odbc;
using System.Diagnostics;
using System.Globalization;
using System.Windows.Forms;
using MigraDoc.DocumentObjectModel;
using MigraDoc.Rendering;

namespace RelInt___Gestiune_cereri_de_deplasare
{
    public partial class frmODDModificare : Form
    {
        public frmODDModificare() // Metoda de LOAD
        {
            InitializeComponent();

            // Incarcam ComboBox-urile urmatoare
            UmplereGradDidactic();
            cmbGradDidactic.DropDownWidth = LatimeDropDown(cmbGradDidactic);
            UmplereFacultate();
            cmbFacultatea.DropDownWidth = LatimeDropDown(cmbFacultatea);
            UmplereMonezi();
            cmbMoneda1.DropDownWidth = LatimeDropDown(cmbMoneda1);
            cmbMoneda2.DropDownWidth = LatimeDropDown(cmbMoneda2);
            cmbMoneda3.DropDownWidth = LatimeDropDown(cmbMoneda3);
            cmbMoneda4.DropDownWidth = LatimeDropDown(cmbMoneda4);
            UmplereTari();
            cmbTara.DropDownWidth = LatimeDropDown(cmbTara);
            UmplereScop();
            cmbScop.DropDownWidth = LatimeDropDown(cmbScop);
            UmplereDFC();
            cmbDFC.DropDownWidth = LatimeDropDown(cmbDFC);
            cmbDFC.SelectedIndex = 0;
            UmplereCOS();
            UmplereODP();

            // Pregatim formularul
            PregatireFormular();

            MetodaNegareControale();
        }
        /* --------------------------------------------------------------------------------------------------------------- */










        /* ----------- Obiecte de lucru cu RelIntDB ---------------------------------------------------------------------- */
        // Sir de conectare al RelIntDB
        string sircon_RelIntDB = "DSN=PostgreSQL35W;database=RelIntDB;server=localhost;port=5432;UID=postgres;PWD=12345;sslmode=disable;readonly=0;protocol=7.4;fakeoidindex=0;showoidcolumn=0;rowversioning=0;showsystemtables=0;fetch=100;socket=4096;unknownsizes=0;maxvarcharsize=255;maxlongvarcharsize=8190;debug=0;commlog=0;optimizer=0;ksqo=1;usedeclarefetch=0;textaslongvarchar=1;unknownsaslongvarchar=0;boolsaschar=1;parse=0;cancelasfreestmt=0;extrasystableprefixes=dd_;lfconversion=1;updatablecursors=1;disallowpremature=0;trueisminus1=0;bi=0;byteaaslongvarbinary=0;useserversideprepare=1;lowercaseidentifier=0;gssauthusegss=0;xaopt=1;";

        /* --------------------------------------------------------------------------------------------------------------- */







        /* ----------------- Eveniment de tip click pentru btnIesire ----------------------------------------------------- */
        private void btnIesire_Click(object sender, EventArgs e)
        {
            Close();
        }
        /* --------------------------------------------------------------------------------------------------------------- */






        /* --------------------- Evenimentul butonului btnSalvare -------------------------------------------------------- */
        private void btnSalvare_Click(object sender, EventArgs e)
        {
            SalvareFormular();
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
        public void UmplereGradDidactic()
        {
            cmbGradDidactic.Items.Clear();
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
                            cmbCPGDDecan.Items.Add(str_cmbGradDidactic);
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
        public void UmplereFacultate()
        {
            cmbFacultatea.Items.Clear();
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
        /* ---------- Metoda de umplere a cmbMonezi cu date din RelIntDB ------------------------------------------------- */
        public void UmplereMonezi()
        {
            cmbMoneda1.Items.Clear();
            cmbMoneda2.Items.Clear();
            cmbMoneda3.Items.Clear();
            cmbMoneda4.Items.Clear();
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
        /* ---------- Metoda de umplere a cmbTari cu date din RelIntDB --------------------------------------------------- */
        public void UmplereTari()
        {
            cmbTara.Items.Clear();
            using (OdbcConnection conexiune_cmbTari = new OdbcConnection(sircon_RelIntDB))
            {           // Comanda
                using (OdbcCommand comanda_cmbTari = new OdbcCommand())
                {
                    comanda_cmbTari.Connection = conexiune_cmbTari;
                    comanda_cmbTari.CommandType = CommandType.Text;
                    comanda_cmbTari.CommandText = "SELECT * FROM tari ORDER BY tarit ASC";

                    OdbcDataReader cititor_cmbTari;

                    try
                    {
                        conexiune_cmbTari.Open();
                        cititor_cmbTari = comanda_cmbTari.ExecuteReader();
                        while (cititor_cmbTari.Read())
                        {
                            string str_cmbTari = cititor_cmbTari.GetString(0);
                            cmbTara.Items.Add(str_cmbTari);
                        }
                    }
                    catch (Exception excmbTari)
                    {
                        MessageBox.Show(excmbTari.Message);
                    } // Ne deconectam
                    finally
                    {
                        conexiune_cmbTari.Close();
                    }
                }
            }
        }
        /* --------------------------------------------------------------------------------------------------------------- */
        /* ---------- Metoda de umplere a cmbScop cu date din RelIntDB --------------------------------------------------- */
        public void UmplereScop()
        {
            cmbScop.Items.Clear();
            using (OdbcConnection conexiune_cmbScop = new OdbcConnection(sircon_RelIntDB))
            {           // Comanda
                using (OdbcCommand comanda_cmbScop = new OdbcCommand())
                {
                    comanda_cmbScop.Connection = conexiune_cmbScop;
                    comanda_cmbScop.CommandType = CommandType.Text;
                    comanda_cmbScop.CommandText = "SELECT * FROM scopuri ORDER BY scopuris ASC";

                    OdbcDataReader cititor_cmbScop;

                    try
                    {
                        conexiune_cmbScop.Open();
                        cititor_cmbScop = comanda_cmbScop.ExecuteReader();
                        while (cititor_cmbScop.Read())
                        {
                            string str_cmbScop = cititor_cmbScop.GetString(0);
                            cmbScop.Items.Add(str_cmbScop);
                        }
                    }
                    catch (Exception excmbScop)
                    {
                        MessageBox.Show(excmbScop.Message);
                    } // Ne deconectam
                    finally
                    {
                        conexiune_cmbScop.Close();
                    }
                }
            }
        }
        /* --------------------------------------------------------------------------------------------------------------- */
        /* ---------- Metoda de umplere a cmbDFC cu date din RelIntDB ---------------------------------------------------- */
        public void UmplereDFC()
        {
            cmbDFC.Items.Clear();
            using (OdbcConnection conexiune_cmbDFC = new OdbcConnection(sircon_RelIntDB))
            {           // Comanda
                using (OdbcCommand comanda_cmbDFC = new OdbcCommand())
                {
                    comanda_cmbDFC.Connection = conexiune_cmbDFC;
                    comanda_cmbDFC.CommandType = CommandType.Text;
                    comanda_cmbDFC.CommandText = "SELECT * FROM dfc";

                    OdbcDataReader cititor_cmbDFC;

                    try
                    {
                        conexiune_cmbDFC.Open();
                        cititor_cmbDFC = comanda_cmbDFC.ExecuteReader();
                        while (cititor_cmbDFC.Read())
                        {
                            string str_cmbDFC = cititor_cmbDFC.GetString(0);
                            cmbDFC.Items.Add(str_cmbDFC);
                        }
                    }
                    catch (Exception excmbDFC)
                    {
                        MessageBox.Show(excmbDFC.Message);
                    } // Ne deconectam
                    finally
                    {
                        conexiune_cmbDFC.Close();
                    }
                }
            }
        }
        /* --------------------------------------------------------------------------------------------------------------- */
        /* ----------- Metoda de setare a latimii dropdown-ului pentru combobox-uri -------------------------------------- */
        int LatimeDropDown(ComboBox myCombo)
        {
            int maxWidth = 0;
            int temp = 0;
            Label label1 = new Label();

            foreach (var obj in myCombo.Items)
            {
                label1.Text = obj.ToString();
                temp = label1.PreferredWidth;
                if (temp > maxWidth)
                {
                    maxWidth = temp;
                }
            }
            label1.Dispose();
            return maxWidth;
        }
        /* --------------------------------------------------------------------------------------------------------------- */
        /* ---------- Metoda de umplere a txtCOS cu date din RelIntDB ---------------------------------------------------- */
        public void UmplereCOS()
        {
            txtCOS.Clear();
            using (OdbcConnection conexiune_txtCOS = new OdbcConnection(sircon_RelIntDB))
            {           // Comanda
                using (OdbcCommand comanda_txtCOS = new OdbcCommand())
                {
                    comanda_txtCOS.Connection = conexiune_txtCOS;
                    comanda_txtCOS.CommandType = CommandType.Text;
                    comanda_txtCOS.CommandText = "SELECT * FROM cos";

                    OdbcDataReader cititor_txtCOS;

                    try
                    {
                        conexiune_txtCOS.Open();
                        cititor_txtCOS = comanda_txtCOS.ExecuteReader();
                        while (cititor_txtCOS.Read())
                        {
                            txtCOS.Text = cititor_txtCOS.GetString(0);
                        }
                    }
                    catch (Exception extxtCOS)
                    {
                        MessageBox.Show(extxtCOS.Message);
                    } // Ne deconectam
                    finally
                    {
                        conexiune_txtCOS.Close();
                    }
                }
            }
        }
        /* --------------------------------------------------------------------------------------------------------------- */
        /* ---------- Metoda de umplere a txtODP cu date din RelIntDB ---------------------------------------------------- */
        public void UmplereODP()
        {
            txtODP.Clear();
            using (OdbcConnection conexiune_txtODP = new OdbcConnection(sircon_RelIntDB))
            {           // Comanda
                using (OdbcCommand comanda_txtODP = new OdbcCommand())
                {
                    comanda_txtODP.Connection = conexiune_txtODP;
                    comanda_txtODP.CommandType = CommandType.Text;
                    comanda_txtODP.CommandText = "SELECT * FROM odp";

                    OdbcDataReader cititor_txtODP;

                    try
                    {
                        conexiune_txtODP.Open();
                        cititor_txtODP = comanda_txtODP.ExecuteReader();
                        while (cititor_txtODP.Read())
                        {
                            txtODP.Text = cititor_txtODP.GetString(0);
                        }
                    }
                    catch (Exception extxtODP)
                    {
                        MessageBox.Show(extxtODP.Message);
                    } // Ne deconectam
                    finally
                    {
                        conexiune_txtODP.Close();
                    }
                }
            }
        }
        /* --------------------------------------------------------------------------------------------------------------- */






        bool rdoRectorSchimbat;
        bool rdoProRectorSchimbat;
        /* ------------------ Metoda de incarcare a cmbRectorProrector --------------------------------------------------- */
        public void IncarcarecmbRectorProrector()
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
            rdoRectorSchimbat = true;
        }
        /* --------------------------------------------------------------------------------------------------------------- */
        /* ------------------- Eveniement pentru rdoProRector ------------------------------------------------------------ */
        private void rdoProRector_CheckedChanged(object sender, EventArgs e)
        {
            IncarcarecmbRectorProrector();
            rdoProRectorSchimbat = true;
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
        Double vartxtNrZileDiurna;
        /* ------------------------- Eveniment pentru txtNrZileDiurna ---------------------------------------------------- */
        private void txtNrZileDiurna_TextChanged(object sender, EventArgs e)
        {
            if (txtNrZileDiurna.Text.Contains(","))
            {
                MessageBox.Show("Caracterul \"(,) virgula\" nu este permis!");
                txtNrZileDiurna.Clear();
            }
            else
            {
                // Verificam daca valoarea din "txtDiurna" este de tip int si daca da, o inregistram in "vartxtDiurna"
                bool vartxtNrZileDiurnaEsteNumar = double.TryParse(txtNrZileDiurna.Text, out vartxtNrZileDiurna);
                if (vartxtNrZileDiurnaEsteNumar != false)
                {
                    vartxtNrZileDiurna = double.Parse(txtNrZileDiurna.Text, CultureInfo.InvariantCulture);
                }

                // Judecam si "sanctionam" la nevoie
                switch (vartxtNrZileDiurnaEsteNumar || txtNrZileDiurna.Text == string.Empty)
                {
                    case false:
                        // Golim casuta si afisam mesaj de eroare
                        txtNrZileDiurna.Clear();
                        MessageBox.Show("        Vă rugăm introduceți doar numere în această casetă de text.");
                        break;
                }
            }

            // Calculam
            MetodaCalculSubtotalDiurna();
        }
        /* --------------------------------------------------------------------------------------------------------------- */
        /* --------------------- variabile de lucru pentru eveniment txtNrZileCazare ------------------------------------- */
        Double vartxtNrZileCazare;
        /* ------------------------- Eveniment pentru txtNrZileCazare ---------------------------------------------------- */
        private void txtNrZileCazare_TextChanged(object sender, EventArgs e)
        {
            if (txtNrZileCazare.Text.Contains(","))
            {
                MessageBox.Show("Caracterul \"(,) virgula\" nu este permis!");
                txtNrZileCazare.Clear();
            }
            else
            {
                // Verificam daca valoarea din "txtCazare" este de tip int si daca da, o inregistram in "vartxtCazare"
                bool vartxtNrZileCazareEsteNumar = Double.TryParse(txtNrZileCazare.Text, out vartxtNrZileCazare);
                if (vartxtNrZileCazareEsteNumar != false)
                {
                    vartxtNrZileCazare = double.Parse(txtNrZileCazare.Text, CultureInfo.InvariantCulture);
                }


                // Judecam si "sanctionam" la nevoie
                switch (vartxtNrZileCazareEsteNumar || txtNrZileCazare.Text == string.Empty)
                {
                    case false:
                        // Golim casuta si afisam mesaj de eroare
                        txtNrZileCazare.Clear();
                        MessageBox.Show("        Vă rugăm introduceți doar numere în această casetă de text.");
                        break;
                }
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








        bool chkDiurnaSchimbat;
        bool chkCazareSchimbat;
        bool chkTaxaDeParticipareSchimbat;
        bool chkTaxaDeVizaSchimbat;
        /* ----------------------- Eveniment chkDiurna ------------------------------------------------------------------- */
        private void chkDiurna_CheckedChanged(object sender, EventArgs e)
        {
            if (chkDiurna.Checked)
            {
                // Activam
                lblDiurna.Enabled = true;
                txtNrZileDiurna.Enabled = true;
                lblX1.Enabled = true;
                txtDiurna.Enabled = true;
                cmbMoneda1.Enabled = true;
            }
            else
            {
                // Efectuam
                txtNrZileDiurna.Clear();
                txtDiurna.Clear();
                cmbMoneda1.SelectedIndex = -1;
                txtSubtotalDiurna.Clear();

                // Dezactivam
                lblDiurna.Enabled = false;
                txtNrZileDiurna.Enabled = false;
                lblX1.Enabled = false;
                txtDiurna.Enabled = false;
                cmbMoneda1.Enabled = false;
            }

            // Setam
            chkDiurnaSchimbat = true;
        }
        /* --------------------------------------------------------------------------------------------------------------- */
        /* ----------------------- Eveniment chkCazare ------------------------------------------------------------------- */
        private void chkCazare_CheckedChanged(object sender, EventArgs e)
        {
            if (chkCazare.Checked)
            {
                // Activam
                lblCazare.Enabled = true;
                txtNrZileCazare.Enabled = true;
                lblX2.Enabled = true;
                txtCazare.Enabled = true;
                cmbMoneda2.Enabled = true;
            }
            else
            {
                // Efectuam
                txtNrZileCazare.Clear();
                txtCazare.Clear();
                cmbMoneda2.SelectedIndex = -1;
                txtSubtotalCazare.Clear();

                // Dezactivam
                lblCazare.Enabled = false;
                txtNrZileCazare.Enabled = false;
                lblX2.Enabled = false;
                txtCazare.Enabled = false;
                cmbMoneda2.Enabled = false;
            }

            // Setam
            chkCazareSchimbat = true;
        }
        /* --------------------------------------------------------------------------------------------------------------- */
        /* ----------------------- Eveniment chkTaxaDeParticipare -------------------------------------------------------- */
        private void chkTaxaDeParticipare_CheckedChanged(object sender, EventArgs e)
        {
            if (chkTaxaDeParticipare.Checked)
            {
                // Activam
                lblTaxaDeParticipare.Enabled = true;
                txtTaxaDeParticipare.Enabled = true;
                cmbMoneda3.Enabled = true;
            }
            else
            {
                // Efectuam
                txtTaxaDeParticipare.Clear();
                cmbMoneda3.SelectedIndex = -1;

                // Dezactivam
                lblTaxaDeParticipare.Enabled = false;
                txtTaxaDeParticipare.Enabled = false;
                cmbMoneda3.Enabled = false;
            }

            // Setam
            chkTaxaDeParticipareSchimbat = true;
        }
        /* --------------------------------------------------------------------------------------------------------------- */
        /* ----------------------- Eveniment chkTaxaDeViza --------------------------------------------------------------- */
        private void chkTaxaDeViza_CheckedChanged(object sender, EventArgs e)
        {
            if (chkTaxaDeViza.Checked)
            {
                // Activam
                lblTaxaDeVizaEtc.Enabled = true;
                txtTaxaDeViza.Enabled = true;
                cmbMoneda4.Enabled = true;
            }
            else
            {
                // Efectuam
                txtTaxaDeViza.Clear();
                cmbMoneda4.SelectedIndex = -1;

                // Dezactivam
                lblTaxaDeVizaEtc.Enabled = false;
                txtTaxaDeViza.Enabled = false;
                cmbMoneda4.Enabled = false;
            }

            // Setam
            chkTaxaDeVizaSchimbat = true;
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
                                cmbTara.SelectedItem = cititor_populareDinBD.GetString(8);
                                txtLocalitatea.Text = cititor_populareDinBD.GetString(9);
                                cmbScop.SelectedItem = cititor_populareDinBD.GetString(10);
                                txtPrecizariScop.Text = cititor_populareDinBD.GetString(11);
                                txtInstitutia.Text = cititor_populareDinBD.GetString(12);
                                dpDataInceput.Value = cititor_populareDinBD.GetDateTime(13);
                                dpDataSfarsit.Value = cititor_populareDinBD.GetDateTime(14);
                                txtRuta.Text = cititor_populareDinBD.GetString(15);
                                txtPlatitorTransport.Text = cititor_populareDinBD.GetString(16);
                                txtPlatitorIntretinere.Text = cititor_populareDinBD.GetString(17);
                                chkDiurna.Checked = cititor_populareDinBD.GetBoolean(18);
                                txtNrZileDiurna.Text = cititor_populareDinBD.GetString(19);
                                txtDiurna.Text = cititor_populareDinBD.GetString(20);
                                cmbMoneda1.SelectedItem = cititor_populareDinBD.IsDBNull(21) ? string.Empty : cititor_populareDinBD.GetString(21);
                                chkCazare.Checked = cititor_populareDinBD.GetBoolean(22);
                                txtNrZileCazare.Text = cititor_populareDinBD.GetString(23);
                                txtCazare.Text = cititor_populareDinBD.GetString(24);
                                cmbMoneda2.SelectedItem = cititor_populareDinBD.IsDBNull(25) ? string.Empty : cititor_populareDinBD.GetString(25);
                                chkTaxaDeParticipare.Checked = cititor_populareDinBD.GetBoolean(26);
                                txtTaxaDeParticipare.Text = cititor_populareDinBD.GetString(27);
                                cmbMoneda3.SelectedItem = cititor_populareDinBD.IsDBNull(28) ? string.Empty : cititor_populareDinBD.GetString(28);
                                chkTaxaDeViza.Checked = cititor_populareDinBD.GetBoolean(29);
                                txtTaxaDeViza.Text = cititor_populareDinBD.GetString(30);
                                cmbMoneda4.SelectedItem = cititor_populareDinBD.IsDBNull(31) ? string.Empty : cititor_populareDinBD.GetString(31);
                                txtTotalDePlata.Text = cititor_populareDinBD.GetString(32);
                                txtCOS.Text = cititor_populareDinBD.GetString(33);
                                txtODP.Text = cititor_populareDinBD.GetString(34);
                                txtDispunere1.Text = cititor_populareDinBD.GetString(35);
                                txtDispunere2.Text = cititor_populareDinBD.GetString(36);
                                txtDispunere3.Text = cititor_populareDinBD.GetString(37);
                                txtDispunere4.Text = cititor_populareDinBD.GetString(38);
                                rdoRector.Checked = cititor_populareDinBD.GetBoolean(39);
                                rdoProRector.Checked = cititor_populareDinBD.GetBoolean(40);
                                cmbRectorProrector.SelectedItem = cititor_populareDinBD.GetString(41);
                                chkDFC.Checked = cititor_populareDinBD.GetBoolean(42);
                                cmbDFC.SelectedItem = cititor_populareDinBD.IsDBNull(43) ? string.Empty : cititor_populareDinBD.GetString(43);
                                chkCP.Checked = cititor_populareDinBD.GetBoolean(44);
                                rdoCPTip1.Checked = cititor_populareDinBD.GetBoolean(45);
                                txtCPNumeProj.Text = cititor_populareDinBD.GetString(46);
                                cmbCPGradDidactic.SelectedItem = cititor_populareDinBD.IsDBNull(47) ? string.Empty : cititor_populareDinBD.GetString(47);
                                txtCPNumeCoord.Text = cititor_populareDinBD.GetString(48);
                                rdoCPTip2.Checked = cititor_populareDinBD.GetBoolean(49);
                                cmbCPGDDecan.SelectedItem = cititor_populareDinBD.IsDBNull(50) ? string.Empty : cititor_populareDinBD.GetString(50);
                                txtCPNumeDecan.Text = cititor_populareDinBD.GetString(51);

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

                                MetodaNegareControale();
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
                    comanda_inserareRelInt.CommandText = "UPDATE ordinedeplasare SET nrinregistrareod = ?, nrinregistrareodnou = ?, dataOD = ?, dataODNoua = ?, subsemnatulOD = ?, graddidacticOD = ?, facultateaOD = ?, taraOD = ?, localitateaOD = ?, scopod = ?, precizariscopOD = ?, institutiaOD = ?, datainceputOD = ?, datasfarsitOD = ?, rutaOD = ?, platitortranspOD = ?, platitorintretinereOD = ?, bifadiurnaOD = ?, nrzilediurnaOD = ?, diurnaOD = ?, monedadiurnaOD = ?, bifacazareOD = ?, nrzilecazareOD = ?, cazareOD = ?, monedacazareOD = ?, bifataxadeparticipareOD = ?, taxadeparticipareOD = ?, monedataxadeparticipareOD = ?, bifataxadevizaetcOD =?, taxadevizaetcOD = ?, monedataxadevizaetcOD = ?, totalOD = ?, cosOD = ?, odpOD = ?, altedispuneri1OD = ?, altedispuneri2OD = ?, altedispuneri3OD = ?, altedispuneri4OD = ?, rectorOD = ?, prorectorOD = ?, numerpOD = ?, bifadfcOD = ?, dfcOD = ?, bifacpOD = ?, bifacptip1OD = ?, cpnumeprojOD = ?, cpgraddidacticOD = ?, cpnumecoordOD = ?, bifacptip2OD = ?, cpgddecanOD = ?, cpnumedecanOD = ?, oddi = ? WHERE nrinregistrareodc = ?";
                    comanda_inserareRelInt.Parameters.AddWithValue("@nrinregistrareod", OdbcType.Int).Value = vartxtNrUAICVechi;
                    comanda_inserareRelInt.Parameters.AddWithValue("@nrinregistrareodnou", OdbcType.Int).Value = vartxtNrUAICNou;
                    comanda_inserareRelInt.Parameters.AddWithValue("@dataOD", OdbcType.DateTime).Value = dpDataODDVeche.Value;
                    comanda_inserareRelInt.Parameters.AddWithValue("@dataODNoua", OdbcType.DateTime).Value = dpDataODDNoua.Value;
                    comanda_inserareRelInt.Parameters.AddWithValue("@subsemnatulOD", OdbcType.NVarChar).Value = txtSubsemnatul.Text;
                    comanda_inserareRelInt.Parameters.AddWithValue("@graddidacticOD", OdbcType.NVarChar).Value = cmbGradDidactic.SelectedItem;
                    comanda_inserareRelInt.Parameters.AddWithValue("@facultateaOD", OdbcType.NVarChar).Value = cmbFacultatea.SelectedItem;
                    comanda_inserareRelInt.Parameters.AddWithValue("@taraOD", OdbcType.NVarChar).Value = cmbTara.SelectedItem;
                    comanda_inserareRelInt.Parameters.AddWithValue("@localitateaOD", OdbcType.NVarChar).Value = txtLocalitatea.Text;
                    comanda_inserareRelInt.Parameters.AddWithValue("@scopOD", OdbcType.NVarChar).Value = cmbScop.SelectedItem;
                    comanda_inserareRelInt.Parameters.AddWithValue("@precizariscopOD", OdbcType.NVarChar).Value = txtPrecizariScop.Text;
                    comanda_inserareRelInt.Parameters.AddWithValue("@institutiaOD", OdbcType.NVarChar).Value = txtInstitutia.Text;
                    comanda_inserareRelInt.Parameters.AddWithValue("@datainceputOD", OdbcType.DateTime).Value = dpDataInceput.Value;
                    comanda_inserareRelInt.Parameters.AddWithValue("@datasfarsitOD", OdbcType.DateTime).Value = dpDataSfarsit.Value;
                    comanda_inserareRelInt.Parameters.AddWithValue("@rutaOD", OdbcType.NVarChar).Value = txtRuta.Text;
                    comanda_inserareRelInt.Parameters.AddWithValue("@platitortranspOD", OdbcType.NVarChar).Value = txtPlatitorTransport.Text;
                    comanda_inserareRelInt.Parameters.AddWithValue("@platitorintretinereOD", OdbcType.NVarChar).Value = txtPlatitorIntretinere.Text;
                    comanda_inserareRelInt.Parameters.AddWithValue("@bifadiurnaOD", OdbcType.Bit).Value = chkDiurna.Checked;
                    comanda_inserareRelInt.Parameters.AddWithValue("@nrzilediurnaOD", OdbcType.Int).Value = vartxtNrZileDiurna;
                    comanda_inserareRelInt.Parameters.AddWithValue("@diurnaOD", OdbcType.Double).Value = vartxtDiurna;
                    comanda_inserareRelInt.Parameters.AddWithValue("@monedadiurnaOD", OdbcType.NVarChar).Value = cmbMoneda1.SelectedItem;
                    comanda_inserareRelInt.Parameters.AddWithValue("@bifacazareOD", OdbcType.Bit).Value = chkCazare.Checked;
                    comanda_inserareRelInt.Parameters.AddWithValue("@nrzilecazareOD", OdbcType.Int).Value = vartxtNrZileCazare;
                    comanda_inserareRelInt.Parameters.AddWithValue("@cazareOD", OdbcType.Double).Value = vartxtCazare;
                    comanda_inserareRelInt.Parameters.AddWithValue("@monedacazareOD", OdbcType.NVarChar).Value = cmbMoneda2.SelectedItem;
                    comanda_inserareRelInt.Parameters.AddWithValue("@bifataxadeparticipareOD", OdbcType.Bit).Value = chkTaxaDeParticipare.Checked;
                    comanda_inserareRelInt.Parameters.AddWithValue("@taxadeparticipareOD", OdbcType.Double).Value = vartxtTaxaDeParticipare;
                    comanda_inserareRelInt.Parameters.AddWithValue("@monedataxadeparticipareOD", OdbcType.NVarChar).Value = cmbMoneda3.SelectedItem;
                    comanda_inserareRelInt.Parameters.AddWithValue("@bifataxadevizaetcOD", OdbcType.Bit).Value = chkTaxaDeViza.Checked;
                    comanda_inserareRelInt.Parameters.AddWithValue("@taxadevizaetcOD", OdbcType.Double).Value = vartxtTaxaDeViza;
                    comanda_inserareRelInt.Parameters.AddWithValue("@monedataxadevizaetcOD", OdbcType.NVarChar).Value = cmbMoneda4.SelectedItem;
                    comanda_inserareRelInt.Parameters.AddWithValue("@totalOD", OdbcType.NVarChar).Value = CalculTotal();
                    comanda_inserareRelInt.Parameters.AddWithValue("@cosOD", OdbcType.NVarChar).Value = txtCOS.Text;
                    comanda_inserareRelInt.Parameters.AddWithValue("@odpOD", OdbcType.NVarChar).Value = txtODP.Text;
                    comanda_inserareRelInt.Parameters.AddWithValue("@altedispuneri1OD", OdbcType.NVarChar).Value = txtDispunere1.Text;
                    comanda_inserareRelInt.Parameters.AddWithValue("@altedispuneri2OD", OdbcType.NVarChar).Value = txtDispunere2.Text;
                    comanda_inserareRelInt.Parameters.AddWithValue("@altedispuneri3OD", OdbcType.NVarChar).Value = txtDispunere3.Text;
                    comanda_inserareRelInt.Parameters.AddWithValue("@altedispuneri4OD", OdbcType.NVarChar).Value = txtDispunere4.Text;
                    comanda_inserareRelInt.Parameters.AddWithValue("@rectorOD", OdbcType.Bit).Value = rdoRector.Checked;
                    comanda_inserareRelInt.Parameters.AddWithValue("@prorectorOD", OdbcType.Bit).Value = rdoProRector.Checked;
                    comanda_inserareRelInt.Parameters.AddWithValue("@numerpOD", OdbcType.NVarChar).Value = cmbRectorProrector.SelectedItem;
                    comanda_inserareRelInt.Parameters.AddWithValue("@bifadfcOD", OdbcType.Bit).Value = chkDFC.Checked;
                    comanda_inserareRelInt.Parameters.AddWithValue("@dfcOD", OdbcType.NVarChar).Value = cmbDFC.SelectedItem;
                    comanda_inserareRelInt.Parameters.AddWithValue("@bifacpOD", OdbcType.Bit).Value = chkCP.Checked;
                    comanda_inserareRelInt.Parameters.AddWithValue("@bifacptip1OD", OdbcType.Bit).Value = rdoCPTip1.Checked;
                    comanda_inserareRelInt.Parameters.AddWithValue("@cpnumeprojOD", OdbcType.NVarChar).Value = txtCPNumeProj.Text;
                    comanda_inserareRelInt.Parameters.AddWithValue("@cpgraddidacticOD", OdbcType.NVarChar).Value = cmbCPGradDidactic.SelectedItem;
                    comanda_inserareRelInt.Parameters.AddWithValue("@cpnumecoordOD", OdbcType.NVarChar).Value = txtCPNumeCoord.Text;
                    comanda_inserareRelInt.Parameters.AddWithValue("@bifacptip2OD", OdbcType.Bit).Value = rdoCPTip2.Checked;
                    comanda_inserareRelInt.Parameters.AddWithValue("@cpgddecanOD", OdbcType.NVarChar).Value = cmbCPGDDecan.SelectedItem;
                    comanda_inserareRelInt.Parameters.AddWithValue("@cpnumedecanOD", OdbcType.NVarChar).Value = txtCPNumeDecan.Text;
                    comanda_inserareRelInt.Parameters.AddWithValue("@oddi", OdbcType.Bit).Value = true;

                    comanda_inserareRelInt.Parameters.AddWithValue("@nrinregistrareodc", OdbcType.Int).Value = vartxtNrInregistrare;

                    // Incercam conexiunea si query-ul
                    try
                    {
                        conexiune_InserareCerereRelInt.Open();
                        comanda_inserareRelInt.ExecuteNonQuery();
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
            bool cazareEsteNumar = double.TryParse(txtCazare.Text, out cazare);
            if (cazareEsteNumar != false)
            {
                cazare = double.Parse(txtCazare.Text, CultureInfo.InvariantCulture);
            }

            double taxaParticipare;
            bool taxaParticipareEsteNumar = double.TryParse(txtTaxaDeParticipare.Text, out taxaParticipare);
            if (taxaParticipareEsteNumar != false)
            {
                taxaParticipare = double.Parse(txtTaxaDeParticipare.Text, CultureInfo.InvariantCulture);
            }

            double taxaDeViza;
            bool taxaDeVizaEsteNumar = double.TryParse(txtTaxaDeViza.Text, out taxaDeViza);
            if (taxaDeVizaEsteNumar != false)
            {
                taxaDeViza = double.Parse(txtTaxaDeViza.Text, CultureInfo.InvariantCulture);
            }

            string total = string.Empty;

            Dictionary<string, double> valoriIntroduse = new Dictionary<string, double>();
            if (cmbMoneda1.SelectedIndex != -1)
            {
                valoriIntroduse.Add(cmbMoneda1.SelectedItem.ToString(), diurna * vartxtNrZileDiurna);
            }

            if (cmbMoneda2.SelectedIndex != -1 && valoriIntroduse.ContainsKey(cmbMoneda2.SelectedItem.ToString()))
            {
                valoriIntroduse[cmbMoneda2.SelectedItem.ToString()] = valoriIntroduse[cmbMoneda2.SelectedItem.ToString()] + cazare * vartxtNrZileCazare;
            }
            else if (cmbMoneda2.SelectedIndex != -1)
            {
                valoriIntroduse.Add(cmbMoneda2.SelectedItem.ToString(), cazare * vartxtNrZileCazare);
            }

            if (cmbMoneda3.SelectedIndex != -1 && valoriIntroduse.ContainsKey(cmbMoneda3.SelectedItem.ToString()))
            {
                valoriIntroduse[cmbMoneda3.SelectedItem.ToString()] = valoriIntroduse[cmbMoneda3.SelectedItem.ToString()] + taxaParticipare;
            }
            else if (cmbMoneda3.SelectedIndex != -1)
            {
                valoriIntroduse.Add(cmbMoneda3.SelectedItem.ToString(), taxaParticipare);
            }

            if (cmbMoneda4.SelectedIndex != -1 && valoriIntroduse.ContainsKey(cmbMoneda4.SelectedItem.ToString()))
            {
                valoriIntroduse[cmbMoneda4.SelectedItem.ToString()] = valoriIntroduse[cmbMoneda4.SelectedItem.ToString()] + taxaDeViza;
            }
            else if (cmbMoneda4.SelectedIndex != -1)
            {
                valoriIntroduse.Add(cmbMoneda4.SelectedItem.ToString(), taxaDeViza);
            }

            foreach (var pereche in valoriIntroduse)
            {
                total += pereche.Value + pereche.Key + " ";
            }
            return total;
        }
        /* --------------------------------------------------------------------------------------------------------------- */








        /* --------------------------------------------------------------------------------------------------------------- */
        private bool VerifMoneziCheltuieli()
        {
            bool ok = true;
            if (cmbMoneda1.SelectedIndex == -1 && chkDiurna.Checked)
            {
                // Setam
                ok = false;

                // Afisam
                MessageBox.Show("               Nu ați selectat nici o monedă (-- Diurnă --) ! \n                       Vă rugăm selectați o valoare.");
            }
            if (cmbMoneda2.SelectedIndex == -1 && chkCazare.Checked)
            {
                // Setam
                ok = false;

                // Afisam
                MessageBox.Show("               Nu ați selectat nici o monedă (-- Cazare --) ! \n                       Vă rugăm selectați o valoare.");
            }
            if (cmbMoneda3.SelectedIndex == -1 && chkTaxaDeParticipare.Checked)
            {
                // Setam
                ok = false;

                // Afisam
                MessageBox.Show("               Nu ați selectat nici o monedă (-- Taxă de participare --) ! \n                             Vă rugăm selectați o valoare.");
            }
            if (cmbMoneda4.SelectedIndex == -1 && chkTaxaDeViza.Checked)
            {
                // Setam
                ok = false;

                // Afisam
                MessageBox.Show("               Nu ați selectat nici o monedă (-- Taxă de Viză --) ! \n                           Vă rugăm selectați o valoare.");
            }
            return ok;
        }
        /* --------------------------------------------------------------------------------------------------------------- */





        bool SuccesSalvareFormular;
        /* -------------- Actiunile ce iau loc la salvare ---------------------------------------------------------------- */
        private void SalvareFormular()
        {
            if (chkDFC.Checked)
            {
                if (chkCP.Checked)
                {
                    if (rdoCPTip1.Checked)
                    {
                        if (txtNrUAICNou.Text != string.Empty
                        && cmbGradDidactic.SelectedIndex != -1
                        && cmbFacultatea.SelectedIndex != -1
                        && cmbTara.SelectedIndex != -1
                        && cmbScop.SelectedIndex != -1
                        && VerifMoneziCheltuieli()
                        && cmbRectorProrector.SelectedIndex != -1
                        && cmbDFC.SelectedIndex != -1
                        && txtCPNumeProj.Text != string.Empty
                        && cmbCPGradDidactic.SelectedIndex != -1
                        && txtCPNumeCoord.Text != string.Empty)
                        {
                            SalvareFormularEfectiva();
                        }
                        else
                        {
                            if (txtNrUAICNou.Text == string.Empty)
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
                            else if (cmbTara.SelectedIndex == -1)
                            {
                                // Afiseaza eroarea
                                MessageBox.Show(
                                    "               Nu ați selectat nici o țară (-- Țara --) ! \n                 Vă rugăm selectați o valoare.");
                            }
                            else if (cmbScop.SelectedIndex == -1)
                            {
                                // Afiseaza eroarea
                                MessageBox.Show(
                                    "               Nu ați selectat nici un scop (-- Scop --) ! \n                 Vă rugăm selectați o valoare.");
                            }
                            else if (cmbRectorProrector.SelectedIndex == -1)
                            {
                                // Afiseaza eroarea
                                MessageBox.Show(
                                    "               Nu ați selectat nici un Rector / ProRector (-- Rector/ProRector --) ! \n                 Vă rugăm selectați o valoare.");
                            }
                            else if (cmbDFC.SelectedIndex == -1)
                            {
                                // Afiseaza eroarea
                                MessageBox.Show(
                                    "               Nu ați introdus nici un Director Financiar Contabil (-- Director Financiar-Contabil --) ! \n                 Vă rugăm introduceți o valoare.");
                            }
                            else if (txtCPNumeProj.Text == string.Empty)
                            {
                                // Afiseaza eroarea
                                MessageBox.Show(
                                    "               Nu ați introdus numele proiectului (-- Denumire Proiect --) ! \n                 Vă rugăm introduceți o valoare.");
                            }
                            else if (cmbCPGradDidactic.SelectedIndex == -1)
                            {
                                // Afiseaza eroarea
                                MessageBox.Show(
                                    "   Nu ați selectat nici un grad didactic (-- Coordonator proiect - Grad didactic --) ! \n                         Vă rugăm selectați o valoare.");
                            }
                            else if (txtCPNumeCoord.Text == string.Empty)
                            {
                                // Afiseaza eroarea
                                MessageBox.Show(
                                    "        Nu ați introdus numele coordonatorului (-- Nume Prenume Coordonator --) ! \n                      Vă rugăm introduceți o valoare.");
                            }
                        }
                    }
                    else if (rdoCPTip2.Checked)
                    {
                        if (txtNrUAICNou.Text != string.Empty
                        && cmbGradDidactic.SelectedIndex != -1
                        && cmbFacultatea.SelectedIndex != -1
                        && cmbTara.SelectedIndex != -1
                        && cmbScop.SelectedIndex != -1
                        && VerifMoneziCheltuieli()
                        && cmbRectorProrector.SelectedIndex != -1
                        && cmbDFC.SelectedIndex != -1
                        && cmbCPGDDecan.SelectedIndex != -1
                        && txtCPNumeDecan.Text != string.Empty)
                        {
                            SalvareFormularEfectiva();
                        }
                        else
                        {
                            if (txtNrUAICNou.Text == string.Empty)
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
                            else if (cmbTara.SelectedIndex == -1)
                            {
                                // Afiseaza eroarea
                                MessageBox.Show(
                                    "               Nu ați selectat nici o țară (-- Țara --) ! \n                 Vă rugăm selectați o valoare.");
                            }
                            else if (cmbScop.SelectedIndex == -1)
                            {
                                // Afiseaza eroarea
                                MessageBox.Show(
                                    "               Nu ați selectat nici un scop (-- Scop --) ! \n                 Vă rugăm selectați o valoare.");
                            }
                            else if (cmbRectorProrector.SelectedIndex == -1)
                            {
                                // Afiseaza eroarea
                                MessageBox.Show(
                                    "               Nu ați selectat nici un Rector / ProRector (-- Rector/ProRector --) ! \n                 Vă rugăm selectați o valoare.");
                            }
                            else if (cmbDFC.SelectedIndex == -1)
                            {
                                // Afiseaza eroarea
                                MessageBox.Show(
                                    "               Nu ați introdus nici un Director Financiar Contabil (-- Director Financiar-Contabil --) ! \n                 Vă rugăm introduceți o valoare.");
                            }
                            else if (cmbCPGDDecan.SelectedIndex == -1)
                            {
                                // Afiseaza eroarea
                                MessageBox.Show(
                                    "   Nu ați selectat nici un grad didactic (-- Decan proiect - Grad didactic --) ! \n                         Vă rugăm selectați o valoare.");
                            }
                            else if (txtCPNumeDecan.Text == string.Empty)
                            {
                                // Afiseaza eroarea
                                MessageBox.Show(
                                    "        Nu ați introdus numele Decanului (-- Nume Prenume Decan --) ! \n                      Vă rugăm introduceți o valoare.");
                            }
                        }
                    }
                    else if (!rdoCPTip1.Checked && !rdoCPTip2.Checked)
                    {
                        MessageBox.Show("Vă rugăm selectați un tip de coordonator pe proiect.");
                    }
                }
                else
                {
                    if (txtNrUAICNou.Text != string.Empty
                        && cmbGradDidactic.SelectedIndex != -1
                        && cmbFacultatea.SelectedIndex != -1
                        && cmbTara.SelectedIndex != -1
                        && cmbScop.SelectedIndex != -1
                        && VerifMoneziCheltuieli()
                        && cmbRectorProrector.SelectedIndex != -1
                        && cmbDFC.SelectedIndex != -1)
                    {
                        SalvareFormularEfectiva();
                    }
                    else
                    {
                        if (txtNrUAICNou.Text == string.Empty)
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
                        else if (cmbTara.SelectedIndex == -1)
                        {
                            // Afiseaza eroarea
                            MessageBox.Show(
                                "               Nu ați selectat nici o țară (-- Țara --) ! \n                 Vă rugăm selectați o valoare.");
                        }
                        else if (cmbScop.SelectedIndex == -1)
                        {
                            // Afiseaza eroarea
                            MessageBox.Show(
                                "               Nu ați selectat nici un scop (-- Scop --) ! \n                 Vă rugăm selectați o valoare.");
                        }
                        else if (cmbRectorProrector.SelectedIndex == -1)
                        {
                            // Afiseaza eroarea
                            MessageBox.Show(
                                "               Nu ați selectat nici un Rector / ProRector (-- Rector/ProRector --) ! \n                 Vă rugăm selectați o valoare.");
                        }
                        else if (cmbDFC.SelectedIndex == -1)
                        {
                            // Afiseaza eroarea
                            MessageBox.Show(
                                "               Nu ați introdus nici un Director Financiar Contabil (-- Director Financiar-Contabil --) ! \n                 Vă rugăm introduceți o valoare.");
                        }
                    }
                }
            }
            else
            {
                if (chkCP.Checked)
                {
                    if (rdoCPTip1.Checked)
                    {
                        if (txtNrUAICNou.Text != string.Empty
                        && cmbGradDidactic.SelectedIndex != -1
                        && cmbFacultatea.SelectedIndex != -1
                        && cmbTara.SelectedIndex != -1
                        && cmbScop.SelectedIndex != -1
                        && VerifMoneziCheltuieli()
                        && cmbRectorProrector.SelectedIndex != -1
                        && txtCPNumeProj.Text != string.Empty
                        && cmbCPGradDidactic.SelectedIndex != -1
                        && txtCPNumeCoord.Text != string.Empty)
                        {
                            SalvareFormularEfectiva();
                        }
                        else
                        {
                            if (txtNrUAICNou.Text == string.Empty)
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
                            else if (cmbTara.SelectedIndex == -1)
                            {
                                // Afiseaza eroarea
                                MessageBox.Show(
                                    "               Nu ați selectat nici o țară (-- Țara --) ! \n                 Vă rugăm selectați o valoare.");
                            }
                            else if (cmbScop.SelectedIndex == -1)
                            {
                                // Afiseaza eroarea
                                MessageBox.Show(
                                    "               Nu ați selectat nici un scop (-- Scop --) ! \n                 Vă rugăm selectați o valoare.");
                            }
                            else if (cmbRectorProrector.SelectedIndex == -1)
                            {
                                // Afiseaza eroarea
                                MessageBox.Show(
                                    "               Nu ați selectat nici un Rector / ProRector (-- Rector/ProRector --) ! \n                 Vă rugăm selectați o valoare.");
                            }
                            else if (cmbDFC.SelectedIndex == -1)
                            {
                                // Afiseaza eroarea
                                MessageBox.Show(
                                    "               Nu ați introdus nici un Director Financiar Contabil (-- Director Financiar-Contabil --) ! \n                 Vă rugăm introduceți o valoare.");
                            }
                            else if (txtCPNumeProj.Text == string.Empty)
                            {
                                // Afiseaza eroarea
                                MessageBox.Show(
                                    "               Nu ați introdus numele proiectului (-- Denumire Proiect --) ! \n                 Vă rugăm introduceți o valoare.");
                            }
                            else if (cmbCPGradDidactic.SelectedIndex == -1)
                            {
                                // Afiseaza eroarea
                                MessageBox.Show(
                                    "   Nu ați selectat nici un grad didactic (-- Coordonator proiect - Grad didactic --) ! \n                         Vă rugăm selectați o valoare.");
                            }
                            else if (txtCPNumeCoord.Text == string.Empty)
                            {
                                // Afiseaza eroarea
                                MessageBox.Show(
                                    "        Nu ați introdus numele coordonatorului (-- Nume Prenume Coordonator --) ! \n                      Vă rugăm introduceți o valoare.");
                            }
                        }
                    }
                    else if (rdoCPTip2.Checked)
                    {
                        if (txtNrUAICNou.Text != string.Empty
                        && cmbGradDidactic.SelectedIndex != -1
                        && cmbFacultatea.SelectedIndex != -1
                        && cmbTara.SelectedIndex != -1
                        && cmbScop.SelectedIndex != -1
                        && VerifMoneziCheltuieli()
                        && cmbRectorProrector.SelectedIndex != -1
                        && cmbCPGDDecan.SelectedIndex != -1
                        && txtCPNumeDecan.Text != string.Empty)
                        {
                            SalvareFormularEfectiva();
                        }
                        else
                        {
                            if (txtNrUAICNou.Text == string.Empty)
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
                            else if (cmbTara.SelectedIndex == -1)
                            {
                                // Afiseaza eroarea
                                MessageBox.Show(
                                    "               Nu ați selectat nici o țară (-- Țara --) ! \n                 Vă rugăm selectați o valoare.");
                            }
                            else if (cmbScop.SelectedIndex == -1)
                            {
                                // Afiseaza eroarea
                                MessageBox.Show(
                                    "               Nu ați selectat nici un scop (-- Scop --) ! \n                 Vă rugăm selectați o valoare.");
                            }
                            else if (cmbRectorProrector.SelectedIndex == -1)
                            {
                                // Afiseaza eroarea
                                MessageBox.Show(
                                    "               Nu ați selectat nici un Rector / ProRector (-- Rector/ProRector --) ! \n                 Vă rugăm selectați o valoare.");
                            }
                            else if (cmbDFC.SelectedIndex == -1)
                            {
                                // Afiseaza eroarea
                                MessageBox.Show(
                                    "               Nu ați introdus nici un Director Financiar Contabil (-- Director Financiar-Contabil --) ! \n                 Vă rugăm introduceți o valoare.");
                            }
                            else if (cmbCPGDDecan.SelectedIndex == -1)
                            {
                                // Afiseaza eroarea
                                MessageBox.Show(
                                    "   Nu ați selectat nici un grad didactic (-- Decan proiect - Grad didactic --) ! \n                         Vă rugăm selectați o valoare.");
                            }
                            else if (txtCPNumeDecan.Text == string.Empty)
                            {
                                // Afiseaza eroarea
                                MessageBox.Show(
                                    "        Nu ați introdus numele Decanului (-- Nume Prenume Decan --) ! \n                      Vă rugăm introduceți o valoare.");
                            }
                        }
                    }
                    else if (!rdoCPTip1.Checked && !rdoCPTip2.Checked)
                    {
                        MessageBox.Show("Vă rugăm selectați un tip de coordonator pe proiect.");
                    }
                }
                else
                {
                    if (txtNrUAICNou.Text != string.Empty
                        && cmbGradDidactic.SelectedIndex != -1
                        && cmbFacultatea.SelectedIndex != -1
                        && cmbTara.SelectedIndex != -1
                        && cmbScop.SelectedIndex != -1
                        && VerifMoneziCheltuieli()
                        && cmbRectorProrector.SelectedIndex != -1)
                    {
                        SalvareFormularEfectiva();
                    }
                    else
                    {
                        if (txtNrUAICNou.Text == string.Empty)
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
                        else if (cmbTara.SelectedIndex == -1)
                        {
                            // Afiseaza eroarea
                            MessageBox.Show(
                                "               Nu ați selectat nici o țară (-- Țara --) ! \n                 Vă rugăm selectați o valoare.");
                        }
                        else if (cmbScop.SelectedIndex == -1)
                        {
                            // Afiseaza eroarea
                            MessageBox.Show(
                                "               Nu ați selectat nici un scop (-- Scop --) ! \n                 Vă rugăm selectați o valoare.");
                        }
                        else if (cmbRectorProrector.SelectedIndex == -1)
                        {
                            // Afiseaza eroarea
                            MessageBox.Show(
                                "               Nu ați selectat nici un Rector / ProRector (-- Rector/ProRector --) ! \n                 Vă rugăm selectați o valoare.");
                        }
                    }
                }
            }
        }
        /* --------------------------------------------------------------------------------------------------------------- */
        /* -------------- Metoda efectiva de salvare a formularului ------------------------------------------------------ */
        private void SalvareFormularEfectiva()
        {
            // Lucreaza asta
            txtTotalDePlata.Text = CalculTotal();

            // Lucreaza asta
            MetodaInserareDB();

            // Daca variabila "MetodaInserareSucces" este adevarata
            if (MetodaInserareSucces)
            {
                // Dezactivam urmatoarele
                panouIdentificareODD.Enabled = false;
                panouContinutODD.Enabled = false;
                panouCheltuieliODD.Enabled = false;
                panouAlteDispuneriODD.Enabled = false;
                panouSemnatariODD.Enabled = false;

                // Notifica
                SuccesSalvareFormular = true;

                // Dezactivam
                btnSalvare.Enabled = false;

                // Negam modificarile
                MetodaNegareControale();

                // Generam PDF
                GenerarePDF();
            }
            else
            {
                // Notifica
                SuccesSalvareFormular = false;

                // Dezactivam
                btnSalvare.Enabled = true;
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
            paragraf5.AddText("Nr. " + txtNrUAICVechi.Text + " și " + txtNrUAICNou.Text + " / " + txtNrInregistrare.Text + " din " + dpDataODDNoua.Value.ToString("dd.MM.yyyy") + "*");

            // Paragraf 6
            Paragraph paragraf6 = section1.AddParagraph();
            paragraf6.Format.Alignment = ParagraphAlignment.Center;
            paragraf6.Format.Font.Size = 13;
            paragraf6.Format.Font.Name = "Times New Roman";
            paragraf6.Format.SpaceBefore = "1.0cm";
            paragraf6.Format.Alignment = ParagraphAlignment.Justify;
            paragraf6.AddText("În temeiul Ordinului M.Ed.C. nr. 4975/30.04.1992 și al Hotărârii Biroului Executiv al Consiliului de Administrație din data de ");
            paragraf6.AddFormattedText(dpDataODDVeche.Value.ToString("dd.MM.yyyy"), TextFormat.Bold);
            paragraf6.AddText(" și ");
            paragraf6.AddFormattedText(dpDataODDNoua.Value.ToString("dd.MM.yyyy"), TextFormat.Bold);
            paragraf6.AddText(".");

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
            paragraf9.AddFormattedText(cmbTara.SelectedItem.ToString(), TextFormat.Bold);
            paragraf9.AddFormattedText(".");

            // Paragraf 10
            Paragraph paragraf10 = section1.AddParagraph();
            paragraf10.Format.Alignment = ParagraphAlignment.Justify;
            paragraf10.Format.Font.Size = 13;
            paragraf10.Format.SpaceBefore = "0.5cm";
            paragraf10.Format.Font.Name = "Times New Roman";
            paragraf10.AddText("Scopul: ");
            paragraf10.AddFormattedText(cmbScop.SelectedItem.ToString(), TextFormat.Bold);

            // Paragraf 11
            Paragraph paragraf11 = section1.AddParagraph();
            paragraf11.Format.Alignment = ParagraphAlignment.Justify;
            paragraf11.Format.Font.Size = 13;
            paragraf11.Format.SpaceBefore = "0.3cm";
            paragraf11.Format.Font.Name = "Times New Roman";
            paragraf11.AddText("deplasarea are loc între ");
            paragraf11.AddFormattedText(dpDataInceput.Value.ToString("dd.MM.yyyy"), TextFormat.Bold);
            paragraf11.AddText(" și ");
            paragraf11.AddFormattedText(dpDataSfarsit.Value.ToString("dd.MM.yyyy"), TextFormat.Bold);

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
            paragraf20.Format.Font.Size = 12;
            paragraf20.Format.SpaceBefore = "0.3cm";
            paragraf20.Format.Font.Name = "Times New Roman";
            if (chkCOS.Checked)
            {
                paragraf20.AddText(txtCOS.Text);
            }

            // Paragraf 21
            Paragraph paragraf21 = section1.AddParagraph();
            paragraf21.Format.Alignment = ParagraphAlignment.Justify;
            paragraf21.Format.Font.Size = 12;
            paragraf21.Format.Font.Name = "Times New Roman";
            if (chkODP.Checked)
            {
                paragraf21.AddText(txtODP.Text);
            }

            // Paragraf 21a
            Paragraph paragraf21a = section1.AddParagraph();
            paragraf21a.Format.Alignment = ParagraphAlignment.Justify;
            paragraf21a.Format.Font.Size = 12;
            paragraf21a.Format.Font.Name = "Times New Roman";
            if (txtDispunere1.Text != string.Empty)
            {
                paragraf21a.AddText(txtDispunere1.Text);
            }

            // Paragraf 21b
            Paragraph paragraf21b = section1.AddParagraph();
            paragraf21b.Format.Alignment = ParagraphAlignment.Justify;
            paragraf21b.Format.Font.Size = 12;
            paragraf21b.Format.Font.Name = "Times New Roman";
            if (txtDispunere2.Text != string.Empty)
            {
                paragraf21b.AddText(txtDispunere2.Text);
            }

            // Paragraf 21c
            Paragraph paragraf21c = section1.AddParagraph();
            paragraf21c.Format.Alignment = ParagraphAlignment.Justify;
            paragraf21c.Format.Font.Size = 12;
            paragraf21c.Format.Font.Name = "Times New Roman";
            if (txtDispunere3.Text != string.Empty)
            {
                paragraf21c.AddText(txtDispunere3.Text);
            }

            // Paragraf 21d
            Paragraph paragraf21d = section1.AddParagraph();
            paragraf21d.Format.Alignment = ParagraphAlignment.Justify;
            paragraf21d.Format.Font.Size = 12;
            paragraf21d.Format.Font.Name = "Times New Roman";
            if (txtDispunere4.Text != string.Empty)
            {
                paragraf21d.AddText(txtDispunere4.Text);
            }

            // Tabel paragraf22
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
            if (cmbDFC.SelectedIndex != -1)
            {
                row1.Cells[1].AddParagraph("DIRECTOR FINANCIAR CONTABIL,");
            }
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
            if (cmbDFC.SelectedIndex != -1)
            {
                row2.Cells[1].AddParagraph(cmbDFC.SelectedItem.ToString());
            }
            table2.Borders.Width = 0;

            if (rdoCPTip1.Checked)
            {
                // Paragraf 22
                Paragraph paragraf22 = section1.AddParagraph();
                paragraf22.Format.Alignment = ParagraphAlignment.Center;
                paragraf22.Format.Font.Size = 12;
                paragraf22.Format.SpaceBefore = "1cm";
                paragraf22.Format.Font.Name = "Times New Roman";
                paragraf22.AddText("Denumire proiect: " + txtCPNumeProj.Text);

                // Paragraf 23
                Paragraph paragraf23 = section1.AddParagraph();
                paragraf23.Format.Alignment = ParagraphAlignment.Center;
                paragraf23.Format.Font.Size = 12;
                paragraf23.Format.SpaceBefore = "0.3cm";
                paragraf23.Format.Font.Name = "Times New Roman";
                paragraf23.AddText("" + cmbCPGradDidactic.SelectedItem);
                paragraf23.AddFormattedText(" " + txtCPNumeCoord.Text, TextFormat.Bold);
            }

            if (rdoCPTip2.Checked)
            {
                // Paragraf 24
                Paragraph paragraf24 = section1.AddParagraph();
                paragraf24.Format.Alignment = ParagraphAlignment.Center;
                paragraf24.Format.Font.Size = 12;
                paragraf24.Format.SpaceBefore = "1cm";
                paragraf24.Format.Font.Name = "Times New Roman";
                paragraf24.AddText("" + cmbCPGDDecan.SelectedItem);
                paragraf24.AddFormattedText(" " + txtCPNumeDecan.Text, TextFormat.Bold);
            }

            // Paragraf 25
            Paragraph paragraf25 = section1.AddParagraph();
            paragraf25.Format.Alignment = ParagraphAlignment.Left;
            paragraf25.Format.Font.Size = 13;
            paragraf25.Format.SpaceBefore = "1cm";
            paragraf25.Format.Font.Name = "Times New Roman";
            paragraf25.Format.Borders.Top.Visible = true;
            paragraf25.Format.Borders.Top.Width = 0.1;
            paragraf25.AddFormattedText("* Înlocuiește și anulează Dispoziția nr. " + txtNrUAICVechi.Text + " / " + txtNrInregistrare.Text + " din " + dpDataODDVeche.Value.ToString("dd.MM.yyyy"), TextFormat.Bold);


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
                Close();
            }
        }
        /* --------------------------------------------------------------------------------------------------------------- */








        /* ----------------- Variabila de lucru pentru metoda "CevaSchimbat" --------------------------------------------- */
        bool DacaCevaSchimbat;
        /* ------------------ Metoda ce verifica daca s-a schimbat ceva la vreunul din campurile formularului ------------ */
        private void CevaSchimbat()
        {
            // Daca
            if (txtNrUAICNouSchimbat
                || txtSubsemnatulSchimbat
                || cmbGradDidacticSchimbat
                || cmbFacultateaSchimbat
                || cmbTaraSchimbat
                || txtLocalitateaSchimbat
                || cmbScopSchimbat
                || txtPrecizariScopSchimbat
                || txtInstitutiaSchimbat
                || txtRutaSchimbat
                || txtPlatitorTransportSchimbat
                || txtPlatitorIntretinereSchimbat
                || chkDiurnaSchimbat
                || chkCazareSchimbat
                || chkTaxaDeParticipareSchimbat
                || chkTaxaDeVizaSchimbat
                || chkCOSSchimbat
                || chkODPSchimbat
                || txtDispunere1Schimbat
                || txtDispunere2Schimbat
                || txtDispunere3Schimbat
                || txtDispunere4Schimbat
                || rdoRectorSchimbat
                || rdoProRectorSchimbat
                || cmbRectorProrectorSchimbat
                || cmbDFCSchimbat
                || txtCPNumeProjSchimbat
                || cmbCPGradDidacticSchimbat
                || txtCPNumeCoordSchimbat
                || cmbCPGDDecanSchimbat
                || txtCPNumeDecanSchimbat)
            {
                DacaCevaSchimbat = true;
            }

            // Daca
            else
            {
                DacaCevaSchimbat = false;
            }
        }
        /* --------------------------------------------------------------------------------------------------------------- */
        /* ------------------- Metoda de "negare" a controalelor --------------------------------------------------------- */
        private void MetodaNegareControale()
        {
            txtNrUAICNouSchimbat = false;
            txtSubsemnatulSchimbat = false;
            cmbGradDidacticSchimbat = false;
            cmbFacultateaSchimbat = false;
            cmbTaraSchimbat = false;
            txtLocalitateaSchimbat = false;
            cmbScopSchimbat = false;
            txtPrecizariScopSchimbat = false;
            txtInstitutiaSchimbat = false;
            txtRutaSchimbat = false;
            txtPlatitorTransportSchimbat = false;
            txtPlatitorIntretinereSchimbat = false;
            chkDiurnaSchimbat = false;
            chkCazareSchimbat = false;
            chkTaxaDeParticipareSchimbat = false;
            chkTaxaDeVizaSchimbat = false;
            chkCOSSchimbat = false;
            chkODPSchimbat = false;
            txtDispunere1Schimbat = false;
            txtDispunere2Schimbat = false;
            txtDispunere3Schimbat = false;
            txtDispunere4Schimbat = false;
            rdoRectorSchimbat = false;
            rdoProRectorSchimbat = false;
            cmbRectorProrectorSchimbat = false;
            cmbDFCSchimbat = false;
            txtCPNumeProjSchimbat = false;
            cmbCPGradDidacticSchimbat = false;
            txtCPNumeCoordSchimbat = false;
            cmbCPGDDecanSchimbat = false;
            txtCPNumeDecanSchimbat = false;
        }
        /* --------------------------------------------------------------------------------------------------------------- */








        /* ----------------------------- Variabile publice pentru "CevaSchimbat()" --------------------------------------- */
        bool cmbScopSchimbat;
        bool txtSubsemnatulSchimbat;
        bool cmbGradDidacticSchimbat;
        bool cmbFacultateaSchimbat;
        bool cmbTaraSchimbat;
        bool txtLocalitateaSchimbat;
        bool txtPrecizariScopSchimbat;
        bool txtInstitutiaSchimbat;
        bool txtRutaSchimbat;
        bool txtPlatitorTransportSchimbat;
        bool txtPlatitorIntretinereSchimbat;
        bool txtDispunere1Schimbat;
        bool txtDispunere2Schimbat;
        bool txtDispunere3Schimbat;
        bool txtDispunere4Schimbat;
        bool cmbRectorProrectorSchimbat;
        bool cmbDFCSchimbat;
        bool txtCPNumeProjSchimbat;
        bool cmbCPGradDidacticSchimbat;
        bool txtCPNumeCoordSchimbat;
        bool cmbCPGDDecanSchimbat;
        bool txtCPNumeDecanSchimbat;
        /* --------------------------------------------------------------------------------------------------------------- */
        private void txtSubsemnatul_TextChanged(object sender, EventArgs e)
        {
            txtSubsemnatulSchimbat = true;
        }

        private void cmbGradDidactic_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbGradDidacticSchimbat = true;
        }

        private void cmbFacultatea_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbFacultateaSchimbat = true;
        }

        private void cmbTara_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbTaraSchimbat = true;
        }

        private void txtLocalitatea_TextChanged(object sender, EventArgs e)
        {
            txtLocalitateaSchimbat = true;
        }

        private void cmbScop_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbScop.SelectedIndex != -1)
            {
                // Setam
                cmbScopSchimbat = true;
                txtPrecizariScop.Enabled = true;
            }
            else
            {
                // Setam
                cmbScopSchimbat = false;
                txtPrecizariScop.Enabled = false;
            }
        }

        private void txtPrecizariScop_TextChanged(object sender, EventArgs e)
        {
            txtPrecizariScopSchimbat = true;
        }

        private void txtInstitutia_TextChanged(object sender, EventArgs e)
        {
            txtInstitutiaSchimbat = true;
        }

        private void txtRuta_TextChanged(object sender, EventArgs e)
        {
            txtRutaSchimbat = true;
        }

        private void txtPlatitorTransport_TextChanged(object sender, EventArgs e)
        {
            txtPlatitorTransportSchimbat = true;
        }

        private void txtPlatitorIntretinere_TextChanged(object sender, EventArgs e)
        {
            txtPlatitorIntretinereSchimbat = true;
        }

        private void txtDispunere1_TextChanged(object sender, EventArgs e)
        {
            txtDispunere1Schimbat = true;
        }

        private void txtDispunere2_TextChanged(object sender, EventArgs e)
        {
            txtDispunere2Schimbat = true;
        }

        private void txtDispunere3_TextChanged(object sender, EventArgs e)
        {
            txtDispunere3Schimbat = true;
        }

        private void txtDispunere4_TextChanged(object sender, EventArgs e)
        {
            txtDispunere4Schimbat = true;
        }

        private void cmbRectorProrector_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbRectorProrectorSchimbat = true;
        }

        private void cmbDFC_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbDFCSchimbat = true;
        }

        private void txtCPNumeProj_TextChanged(object sender, EventArgs e)
        {
            txtCPNumeProjSchimbat = true;
        }

        private void cmbCPGradDidactic_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbCPGradDidacticSchimbat = true;
        }

        private void txtCPNumeCoord_TextChanged(object sender, EventArgs e)
        {
            txtCPNumeCoordSchimbat = true;
        }

        private void cmbCPGDDecan_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbCPGDDecanSchimbat = true;
        }

        private void txtCPNumeDecan_TextChanged(object sender, EventArgs e)
        {
            txtCPNumeDecanSchimbat = true;
        }
        /* --------------------------------------------------------------------------------------------------------------- */







        /* -------------- Eveniment ptr chkDFC --------------------------------------------------------------------------- */
        private void chkDFC_CheckedChanged(object sender, EventArgs e)
        {
            if (chkDFC.Checked)
            {
                cmbDFC.Enabled = true;
                cmbDFC.SelectedIndex = 0;
            }
            else
            {
                cmbDFC.SelectedIndex = -1;
                cmbDFC.Enabled = false;
            }
        }
        /* --------------------------------------------------------------------------------------------------------------- */






        /* ----------------- Eveniment pentru chkCP ---------------------------------------------------------------------- */
        private void chkCP_CheckedChanged(object sender, EventArgs e)
        {
            if (chkCP.Checked)
            {
                panouCPTip.Enabled = true;
            }
            else
            {
                rdoCPTip1.Checked = false;
                rdoCPTip2.Checked = false;
                panouCPTip.Enabled = false;
            }
        }
        /* --------------------------------------------------------------------------------------------------------------- */





        bool chkCOSSchimbat;
        /* -------------- Eveniment pentru chkCOS ------------------------------------------------------------------------ */
        private void chkCOS_CheckedChanged(object sender, EventArgs e)
        {
            if (chkCOS.Checked)
            {
                UmplereCOS();
            }
            else
            {
                txtCOS.Clear();
            }
            chkCOSSchimbat = true;
        }
        /* --------------------------------------------------------------------------------------------------------------- */







        bool chkODPSchimbat;
        /* -------------- Eveniment pentru chkCOS ------------------------------------------------------------------------ */
        private void chkODP_CheckedChanged(object sender, EventArgs e)
        {
            if (chkODP.Checked)
            {
                UmplereODP();
            }
            else
            {
                txtODP.Clear();
            }
            chkODPSchimbat = true;
        }
        /* --------------------------------------------------------------------------------------------------------------- */


        


        /* --------------------------------------------------------------------------------------------------------------- */
        private void rdoCPTip1_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoCPTip1.Checked)
            {
                panouCPCoord.Enabled = true;
                txtCPNumeProj.Enabled = true;
                cmbCPGradDidactic.Enabled = true;
                txtCPNumeCoord.Enabled = true;
            }
            else
            {
                panouCPCoord.Enabled = false;
                txtCPNumeProj.Enabled = false;
                cmbCPGradDidactic.Enabled = false;
                txtCPNumeCoord.Enabled = false;

                txtCPNumeProj.Clear();
                cmbCPGradDidactic.SelectedIndex = -1;
                txtCPNumeCoord.Clear();
            }
        }
        /* --------------------------------------------------------------------------------------------------------------- */





        /* --------------------------------------------------------------------------------------------------------------- */
        private void rdoCPTip2_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoCPTip2.Checked)
            {
                panouCPDecan.Enabled = true;
                cmbCPGDDecan.Enabled = true;
                txtCPNumeDecan.Enabled = true;
            }
            else
            {
                panouCPDecan.Enabled = false;
                cmbCPGDDecan.Enabled = false;
                txtCPNumeDecan.Enabled = false;

                cmbCPGDDecan.SelectedIndex = -1;
                txtCPNumeDecan.Clear();
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








        
    }
}