using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Windows.Forms;
using System.Data.Odbc;

namespace RelInt___Gestiune_cereri_de_deplasare
{
    public partial class frmCerereModificare: Form
    {
        public frmCerereModificare() // Metoda de LOAD
        {
            InitializeComponent();

            /* ------------ Initializam Combobox-urile cu primele lor valori din colectii ------------------------------------ */
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
            /* --------------------------------------------------------------------------------------------------------------- */
            
            // Pregatim formularul
            PregatireFormular();

            // Resetam controalele
            MetodaNegareControale();
        }
        /* --------------------------------------------------------------------------------------------------------------- */







        /* --------------------------------------------------------------------------------------------------------------- */
        private void PregatireFormular()
        {
            // Dezactivam urmatoarele
            lblDataFormular.Enabled = false;
            dpDataFormular.Enabled = false;
            panouContinut.Enabled = false;
            panouCheltuieliPlecare.Enabled = false;
        }
        /* --------------------------------------------------------------------------------------------------------------- */
        






        /* ----------- Obiecte de lucru cu RelIntDB ---------------------------------------------------------------------- */
        // Sir de conectare al RelIntDB
        string sircon_RelIntDB = "DSN=PostgreSQL35W;database=RelIntDB;server=localhost;port=5432;UID=postgres;PWD=12345;sslmode=disable;readonly=0;protocol=7.4;fakeoidindex=0;showoidcolumn=0;rowversioning=0;showsystemtables=0;fetch=100;socket=4096;unknownsizes=0;maxvarcharsize=255;maxlongvarcharsize=8190;debug=0;commlog=0;optimizer=0;ksqo=1;usedeclarefetch=0;textaslongvarchar=1;unknownsaslongvarchar=0;boolsaschar=1;parse=0;cancelasfreestmt=0;extrasystableprefixes=dd_;lfconversion=1;updatablecursors=1;disallowpremature=0;trueisminus1=0;bi=0;byteaaslongvarbinary=0;useserversideprepare=1;lowercaseidentifier=0;gssauthusegss=0;xaopt=1;";
        
        /* --------------------------------------------------------------------------------------------------------------- */









        /* ----------- Variabile de lucru in acest form ------------------------------------------------------------------ */

        // Variabila pentru textbox "txtNrInregistrare"
        int vartxtNrInregistrare;

        // Variabile pentru metoda CalculTotal()
        double varDiurna;
        double varCazare;
        double varTaxaDeParticipare;
        double varTaxaDeVizaEtc;

        // Variabile pentru alte porti logice
        bool MetodaInserareSucces;

        // Variabile de lucru pentru CevaSchimbat()
        bool txtSubsemnatulSchimbat;
        bool cmbGradDidacticSchimbat;
        bool cmbFacultateaSchimbat;
        bool txtDepartamentSchimbat;
        bool txtLocalitateaSchimbat;
        bool cmbTaraSchimbat;
        bool cmbScopSchimbat;
        bool txtPrecizariScopSchimbat;
        bool txtInstitutiaSchimbat;
        bool txtRutaSchimbat;
        bool txtMijTransSchimbat;
        bool txtPlatitorTransportSchimbat;
        bool txtPlatitorIntretinereSchimbat;

        // Variabile pentru iesirea din program
        bool IesireDinProgram;
        bool DacaCevaSchimbat;

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









        /* ---------- Inchidere formular cand actiunam "iesire" din meniul formularului ---------------------------------- */
        private void btnCIIesire_Click(object sender, EventArgs e)
        {
            // Inchidem formularul
            Close();
        }
        /* --------------------------------------------------------------------------------------------------------------- */










        /* ----------------- Validarea casetei de text "txtNrInregistrare" ----------------------------------------------- */
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
        }
        /* --------------------------------------------------------------------------------------------------------------- */









        /* ----------------- Metoda calcularii totalului din textbox-ul "txtTotalDePlata" -------------------------------- */
        private string CalculTotal()
        {
            double diurna;
            bool diurnaEsteNumar = double.TryParse(txtDiurna.Text, out diurna);
            if (diurnaEsteNumar)
            {
                diurna = double.Parse(txtDiurna.Text, CultureInfo.InvariantCulture);
            }

            double cazare;
            bool cazareEsteNumar = double.TryParse(txtCazare.Text, out cazare);
            if (cazareEsteNumar)
            {
                cazare = double.Parse(txtCazare.Text, CultureInfo.InvariantCulture);
            }

            double taxaParticipare;
            bool taxaParticipareEsteNumar = double.TryParse(txtTaxaDeParticipare.Text, out taxaParticipare);
            if (taxaParticipareEsteNumar)
            {
                taxaParticipare = double.Parse(txtTaxaDeParticipare.Text, CultureInfo.InvariantCulture);
            }

            double taxaDeViza;
            bool taxaDeVizaEsteNumar = double.TryParse(txtTaxaDeViza.Text, out taxaDeViza);
            if (taxaDeVizaEsteNumar)
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
                    comanda_inserareRelInt.CommandText = "UPDATE cereri SET datac = ?, subsemnatulc = ?, graddidacticc = ?, facultateac = ?, departamentulc = ?, tarac = ?, localitateac = ?, scopc = ?, precizariscopc = ?, institutiac = ?, datainceputc = ?, datasfarsitc = ?, rutac = ?, mijtransc = ?, platitortranspc = ?, platitorintretinerec = ?, bifadiurnac = ?, nrzilediurnac = ?, diurnac = ?, monedadiurnac = ?, bifacazarec = ?, nrzilecazarec = ?, cazarec = ?, monedacazarec = ?, bifataxadeparticiparec = ?, taxadeparticiparec = ?, monedataxadeparticiparec = ?, bifataxadevizaetcc = ?, taxadevizaetcc = ?, monedataxadevizaetcc = ?, totalc = ?, tiozc = ? WHERE nrinregistrarec = ?";
                    comanda_inserareRelInt.Parameters.AddWithValue("@datac", OdbcType.DateTime).Value = dpDataFormular.Value;
                    comanda_inserareRelInt.Parameters.AddWithValue("@subsemnatulc", OdbcType.NVarChar).Value = txtSubsemnatul.Text;
                    comanda_inserareRelInt.Parameters.AddWithValue("@graddidacticc", OdbcType.NVarChar).Value = cmbGradDidactic.SelectedItem;
                    comanda_inserareRelInt.Parameters.AddWithValue("@facultateac", OdbcType.NVarChar).Value = cmbFacultatea.SelectedItem;
                    comanda_inserareRelInt.Parameters.AddWithValue("@departamentulc", OdbcType.NVarChar).Value = txtDepartament.Text;
                    comanda_inserareRelInt.Parameters.AddWithValue("@tarac", OdbcType.NVarChar).Value = cmbTara.SelectedItem;
                    comanda_inserareRelInt.Parameters.AddWithValue("@localitateac", OdbcType.NVarChar).Value = txtLocalitatea.Text;
                    comanda_inserareRelInt.Parameters.AddWithValue("@scopc", OdbcType.NVarChar).Value = cmbScop.SelectedItem;
                    comanda_inserareRelInt.Parameters.AddWithValue("@precizariscopc", OdbcType.NVarChar).Value = txtPrecizariScop.Text;
                    comanda_inserareRelInt.Parameters.AddWithValue("@institutiac", OdbcType.NVarChar).Value = txtInstitutia.Text;
                    comanda_inserareRelInt.Parameters.AddWithValue("@datainceputc", OdbcType.DateTime).Value = dpDataInceput.Value;
                    comanda_inserareRelInt.Parameters.AddWithValue("@datasfarsitc", OdbcType.DateTime).Value = dpDataSfarsit.Value;
                    comanda_inserareRelInt.Parameters.AddWithValue("@rutac", OdbcType.NVarChar).Value = txtRuta.Text;
                    comanda_inserareRelInt.Parameters.AddWithValue("@mijtransc", OdbcType.NVarChar).Value = txtMijTrans.Text;
                    comanda_inserareRelInt.Parameters.AddWithValue("@platitortranspc", OdbcType.NVarChar).Value = txtPlatitorTransport.Text;
                    comanda_inserareRelInt.Parameters.AddWithValue("@platitorintretinerec", OdbcType.NVarChar).Value = txtPlatitorIntretinere.Text;
                    comanda_inserareRelInt.Parameters.AddWithValue("@bifadiurnac", OdbcType.Bit).Value = chkDiurna.Checked;
                    comanda_inserareRelInt.Parameters.AddWithValue("@nrzilediurnac", OdbcType.Int).Value = txtNrZileDiurna.Text;
                    comanda_inserareRelInt.Parameters.AddWithValue("@diurnac", OdbcType.Double).Value = varDiurna;
                    comanda_inserareRelInt.Parameters.AddWithValue("@monedadiurnac", OdbcType.NVarChar).Value = cmbMoneda1.SelectedItem;
                    comanda_inserareRelInt.Parameters.AddWithValue("@bifacazarec", OdbcType.Bit).Value = chkCazare.Checked;
                    comanda_inserareRelInt.Parameters.AddWithValue("@nrzilecazarec", OdbcType.Int).Value = txtNrZileCazare.Text;
                    comanda_inserareRelInt.Parameters.AddWithValue("@cazarec", OdbcType.Double).Value = varCazare;
                    comanda_inserareRelInt.Parameters.AddWithValue("@monedacazarec", OdbcType.NVarChar).Value = cmbMoneda2.SelectedItem;
                    comanda_inserareRelInt.Parameters.AddWithValue("@bifataxadeparticiparec", OdbcType.Bit).Value = chkTaxaDeParticipare.Checked;
                    comanda_inserareRelInt.Parameters.AddWithValue("@taxadeparticiparec", OdbcType.Double).Value = varTaxaDeParticipare;
                    comanda_inserareRelInt.Parameters.AddWithValue("@monedataxadeparticiparec", OdbcType.NVarChar).Value = cmbMoneda3.SelectedItem;
                    comanda_inserareRelInt.Parameters.AddWithValue("@bifataxadevizaetcc", OdbcType.Bit).Value = chkTaxaDeViza.Checked;
                    comanda_inserareRelInt.Parameters.AddWithValue("@taxadevizaetcc", OdbcType.Double).Value = varTaxaDeVizaEtc;
                    comanda_inserareRelInt.Parameters.AddWithValue("@monedataxadevizaetcc", OdbcType.NVarChar).Value = cmbMoneda4.SelectedItem;
                    comanda_inserareRelInt.Parameters.AddWithValue("@totalc", OdbcType.NVarChar).Value = CalculTotal();
                    comanda_inserareRelInt.Parameters.AddWithValue("@tioz", OdbcType.Bit).Value = false;

                    comanda_inserareRelInt.Parameters.AddWithValue("@nrinregistrarec", OdbcType.Int).Value = vartxtNrInregistrare;
                    
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









        


        /* ----------- Actiunea de salvare a formularului ---------------------------------------------------------------- */
        private void btnCISalvareFormular_Click(object sender, EventArgs e)
        {
            SalvareFormular();
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








        /* -------------- Actiunile ce iau loc la salvare ---------------------------------------------------------------- */
        private void SalvareFormular()
        {
            // Daca caseta "txtNrInregistrare" nu este goala
            if (cmbTara.SelectedIndex != -1
                && cmbScop.SelectedIndex != -1
                && cmbGradDidactic.SelectedIndex != -1
                && cmbFacultatea.SelectedIndex != -1
                && VerifMoneziCheltuieli())
            {
                // Lucreaza asta
                txtTotalDePlata.Text = CalculTotal();

                // Lucreaza asta
                MetodaInserareDB();

                    // Daca variabila "MetodaInserareSucces" este adevarata
                    if (MetodaInserareSucces)
                    {
                        // Notifica bool iesire din program (true)
                        IesireDinProgram = true;

                        // Dezactivam butonul de salvare
                        btnCISalvareFormular.Enabled = false;

                        // Negam modificarile controalelor (le resetam pe false)
                        MetodaNegareControale();

                        DialogResult dialogiesire = MessageBox.Show("Cererea a fost modificată cu succes!", "Succes", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        if (dialogiesire == DialogResult.OK)
                        {
                            Close();
                        }
                    }
            }
            // Daca caseta "txtNrInregistrare" este goala
            else 
            {
                if (txtNrInregistrare.Text == string.Empty)
                {
                    // Afiseaza eroarea
                    MessageBox.Show(
                        "               Nu ați completat caseta \"Număr Înregistrare\"! \n                              Vă rugăm să o completați.");
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
            }

            if (Application.OpenForms["frmVizualizareTot"] != null)
            {
                (Application.OpenForms["frmVizualizareTot"] as frmListaCereriExistente).PopularedgvVizualizareTot();
            }

            if (Application.OpenForms["frmOrdineaDeZi"] != null)
            {
                (Application.OpenForms["frmOrdineaDeZi"] as frmOrdineaDeZi).PopulareDGV();
            }
        }
        /* --------------------------------------------------------------------------------------------------------------- */









        /* - Metoda de detectare daca un anumit camp a fost modificat din formular dupa ce acesta din urma este incarcat - */
        private void CevaSchimbat()
        {
            // Daca vreuna din variabilele urmatoare este adevarata atunci
            if (txtSubsemnatulSchimbat
                || cmbGradDidacticSchimbat
                || cmbFacultateaSchimbat
                || txtDepartamentSchimbat
                || cmbTaraSchimbat
                || txtLocalitateaSchimbat
                || cmbScopSchimbat
                || txtPrecizariScopSchimbat
                || txtInstitutiaSchimbat
                || txtRutaSchimbat 
                || txtMijTransSchimbat
                || txtPlatitorTransportSchimbat
                || txtPlatitorIntretinereSchimbat
                || chkDiurnaSchimbat
                || chkCazareSchimbat
                || chkTaxaDeParticipareSchimbat
                || chkTaxaDeVizaSchimbat)

                {
                    DacaCevaSchimbat = true;
                } 

                // Daca niciuna din variabilele urmatoare nu este adevarata atunci
                else {
                DacaCevaSchimbat = false;
                }
        }
        /* --------------------------------------------------------------------------------------------------------------- */
        /* ----------------------- Metoda MetodaNegareControale ---------------------------------------------------------- */
        private void MetodaNegareControale()
        {
            // Variabile de negat (resetat)
            txtSubsemnatulSchimbat = false;
            cmbGradDidacticSchimbat = false;
            cmbFacultateaSchimbat = false;
            txtDepartamentSchimbat = false;
            cmbTaraSchimbat = false;
            txtLocalitateaSchimbat = false;
            cmbScopSchimbat = false;
            txtPrecizariScopSchimbat = false;
            txtInstitutiaSchimbat = false;
            txtRutaSchimbat = false;
            txtMijTransSchimbat = false;
            txtPlatitorTransportSchimbat = false;
            txtPlatitorIntretinereSchimbat = false;
            chkDiurnaSchimbat = false;
            chkCazareSchimbat = false;
            chkTaxaDeParticipareSchimbat = false;
            chkTaxaDeVizaSchimbat = false;
        }
        /* --------------------------------------------------------------------------------------------------------------- */






        
        /* --------------- Eveniment pentru txtSubsemnatul --------------------------------------------------------------- */
        private void txtSubsemnatul_TextChanged(object sender, EventArgs e)
        {
            // Daca textul se schimba atunci
            txtSubsemnatulSchimbat = true;
        }

        private void cmbGradDidactic_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Daca Indexul selectat se schimba atunci
            cmbGradDidacticSchimbat = true;
        }

        private void cmbFacultatea_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Daca Indexul selectat se schimba atunci
            cmbFacultateaSchimbat = true;
        }

        private void txtDepartament_TextChanged(object sender, EventArgs e)
        {
            // Daca textul selectat se schimba atunci
            txtDepartamentSchimbat = true;
        }

        private void txtLocalitatea_TextChanged(object sender, EventArgs e)
        {
            // Daca textul selectat se schimba atunci
            txtLocalitateaSchimbat = true;
        }

        private void cmbTara_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Daca textul selectat se schimba atunci
            cmbTaraSchimbat = true;
        }

        private void cmbScop_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Daca textul selectat se schimba atunci
            cmbScopSchimbat = true;
        }

        private void txtPrecizariScop_TextChanged(object sender, EventArgs e)
        {
            txtPrecizariScopSchimbat = true;
        }

        private void txtInstitutia_TextChanged(object sender, EventArgs e)
        {
            // Daca textul selectat se schimba atunci
            txtInstitutiaSchimbat = true;
        }

        private void txtRuta_TextChanged(object sender, EventArgs e)
        {
            // Daca textul selectat se schimba atunci
            txtRutaSchimbat = true;
        }

        private void txtMijTrans_TextChanged(object sender, EventArgs e)
        {
            // Daca textul selectat se schimba atunci
            txtMijTransSchimbat = true;
        }

        private void txtPlatitorTransport_TextChanged(object sender, EventArgs e)
        {
            // Daca textul selectat se schimba atunci
            txtPlatitorTransportSchimbat = true;
        }

        private void txtPlatitorIntretinere_TextChanged(object sender, EventArgs e)
        {
            // Daca textul selectat se schimba atunci
            txtPlatitorIntretinereSchimbat = true;
        }
        /* --------------------------------------------------------------------------------------------------------------- */








        /* --------------------------------------------------------------------------------------------------------------- */
        private void MetodaCalculSubtotalDiurna()
        {
            // Declaram o variabila locala
            double varSubtotal = 0;

            // Calculam
            varSubtotal = vartxtNrZileDiurna * varDiurna;

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
            varSubtotal = vartxtNrZileCazare * varCazare;

            // Afisam
            txtSubtotalCazare.Text = varSubtotal.ToString();
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
        /* --------------------- variabile de lucru pentru eveniment txtDiurna ------------------------------------------- */
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
                bool vartxtDiurnaEsteNumar = double.TryParse(txtDiurna.Text, out varDiurna);
                if (vartxtDiurnaEsteNumar != false)
                {
                    varDiurna = double.Parse(txtDiurna.Text, CultureInfo.InvariantCulture);
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
        /* ------------------------- Variabile de lucru pentru txtCazare ------------------------------------------------- */
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
                bool vartxtCazareEsteNumar = Double.TryParse(txtCazare.Text, out varCazare);
                if (vartxtCazareEsteNumar != false)
                {
                    varCazare = double.Parse(txtCazare.Text, CultureInfo.InvariantCulture);
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
                bool vartxtTaxaDeParticipareEsteNumar = Double.TryParse(txtTaxaDeParticipare.Text, out varTaxaDeParticipare);
                if (vartxtTaxaDeParticipareEsteNumar != false)
                {
                    varTaxaDeParticipare = double.Parse(txtTaxaDeParticipare.Text, CultureInfo.InvariantCulture);
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
                bool vartxtTaxaDeVizaEsteNumar = Double.TryParse(txtTaxaDeViza.Text, out varTaxaDeVizaEtc);
                if (vartxtTaxaDeVizaEsteNumar != false)
                {
                    varTaxaDeVizaEtc = double.Parse(txtTaxaDeViza.Text, CultureInfo.InvariantCulture);
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
        private void PopulareFormular()
        {
            // Variabila locala
            bool SuccesCitire = false;

            // Populam campurile cu date din BD
            using (OdbcConnection conexiune_populareDinBD = new OdbcConnection(sircon_RelIntDB))
            {           // Comanda
                using (OdbcCommand comanda_populareDinBD = new OdbcCommand())
                {
                    comanda_populareDinBD.Connection = conexiune_populareDinBD;
                    comanda_populareDinBD.CommandType = CommandType.Text;
                    comanda_populareDinBD.CommandText = "SELECT * FROM cereri WHERE nrinregistrarec = ?";
                    comanda_populareDinBD.Parameters.AddWithValue("@nrinregistrarec", OdbcType.Int).Value = vartxtNrInregistrare;


                    try
                    {
                        conexiune_populareDinBD.Open();

                        OdbcDataReader cititor_populareDinBD = comanda_populareDinBD.ExecuteReader();

                        if (cititor_populareDinBD.HasRows)
                        {

                            while (cititor_populareDinBD.Read())
                            {
                                dpDataFormular.Value = cititor_populareDinBD.GetDateTime(1);
                                txtSubsemnatul.Text = cititor_populareDinBD.GetString(2);
                                cmbGradDidactic.SelectedItem = cititor_populareDinBD.GetString(3);
                                cmbFacultatea.SelectedItem = cititor_populareDinBD.GetString(4);
                                txtDepartament.Text = cititor_populareDinBD.GetString(5);
                                cmbTara.SelectedItem = cititor_populareDinBD.GetString(6);
                                txtLocalitatea.Text = cititor_populareDinBD.GetString(7);
                                cmbScop.SelectedItem = cititor_populareDinBD.GetString(8);
                                txtPrecizariScop.Text = cititor_populareDinBD.GetString(9);
                                txtInstitutia.Text = cititor_populareDinBD.GetString(10);
                                dpDataInceput.Value = cititor_populareDinBD.GetDateTime(11);
                                dpDataSfarsit.Value = cititor_populareDinBD.GetDateTime(12);
                                txtRuta.Text = cititor_populareDinBD.GetString(13);
                                txtMijTrans.Text = cititor_populareDinBD.GetString(14);
                                txtPlatitorTransport.Text = cititor_populareDinBD.GetString(15);
                                txtPlatitorIntretinere.Text = cititor_populareDinBD.GetString(16);
                                chkDiurna.Checked = cititor_populareDinBD.GetBoolean(17);
                                txtNrZileDiurna.Text = cititor_populareDinBD.GetString(18);
                                txtDiurna.Text = cititor_populareDinBD.GetString(19);
                                cmbMoneda1.SelectedItem = cititor_populareDinBD.IsDBNull(20) ? cmbMoneda1.SelectedItem = string.Empty : cmbMoneda1.SelectedItem = cititor_populareDinBD.GetString(20);
                                chkCazare.Checked = cititor_populareDinBD.GetBoolean(21);
                                txtNrZileCazare.Text = cititor_populareDinBD.GetString(22);
                                txtCazare.Text = cititor_populareDinBD.GetString(23);
                                cmbMoneda2.SelectedItem = cititor_populareDinBD.IsDBNull(24) ? cmbMoneda2.SelectedItem = string.Empty : cmbMoneda2.SelectedItem = cititor_populareDinBD.GetString(24);
                                chkTaxaDeParticipare.Checked = cititor_populareDinBD.GetBoolean(25);
                                txtTaxaDeParticipare.Text = cititor_populareDinBD.GetString(26);
                                cmbMoneda3.SelectedItem = cititor_populareDinBD.IsDBNull(27) ? cmbMoneda3.SelectedItem = string.Empty : cmbMoneda3.SelectedItem = cititor_populareDinBD.GetString(27);
                                chkTaxaDeViza.Checked = cititor_populareDinBD.GetBoolean(28);
                                txtTaxaDeViza.Text = cititor_populareDinBD.GetString(29);
                                cmbMoneda4.SelectedItem = cititor_populareDinBD.IsDBNull(30) ? cmbMoneda4.SelectedItem = string.Empty : cmbMoneda4.SelectedItem = cititor_populareDinBD.GetString(30);
                                txtTotalDePlata.Text = cititor_populareDinBD.GetString(31);

                                SuccesCitire = true;

                                MetodaNegareControale();
                            }

                            // Aranjam Formularul
                            if (txtNrInregistrare.Enabled && SuccesCitire)
                            {
                                // Dezactivam urmatoarele
                                lblNrInregistrare.Enabled = false;
                                txtNrInregistrare.Enabled = false;
                                btnAcceseaza.Enabled = false;

                                // Activam urmatoarele
                                lblDataFormular.Enabled = true;
                                dpDataFormular.Enabled = true;
                                panouContinut.Enabled = true;
                                panouCheltuieliPlecare.Enabled = true;
                            }
                        }
                        else
                        {
                            MessageBox.Show("       Numărul de înregistrare solicitat de dvs. nu exista!\n\n            Vă rugăm verificați lista de cereri existente.");
                            txtNrInregistrare.Clear();
                            txtNrInregistrare.Focus();
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
        /* --------------------------------------------------------------------------------------------------------------- */
        private void btnAcceseaza_Click(object sender, EventArgs e)
        {
            PopulareFormular();
        }
        /* --------------------------------------------------------------------------------------------------------------- */










        /* ---------- Intrebam utilizatorul daca vrea sa salveze formularul cand actionam butonul "X" -------------------- */
        private void frmCerereModificare_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Executam verificarea starii de modificare a campurilor din formular
            CevaSchimbat();

            // Verificam daca a fost modificat vreun camp
            if (DacaCevaSchimbat)
            {
                // Verificam daca formularul a fost salvat deja

                // Daca formularul nu a fost salvat
                if (IesireDinProgram == false)
                {

                    // Intrebam utilizatorul daca doreste sa-l salveze
                    DialogResult DialogSalvare = MessageBox.Show("Doriți sa salvați formularul curent?", "Salvare formular", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                    // Daca DORESTE sa salveze
                    if (DialogSalvare == DialogResult.Yes)
                    {
                        // Salvam formularul
                        SalvareFormular();

                        // Daca S-A salvat
                        if (IesireDinProgram)
                        {
                            // Apelam "MetodaNegareControale" si inchidem formularul
                            MetodaNegareControale();
                        }

                        // Daca NU s-a salvat
                        else if (IesireDinProgram == false)
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
                else if (IesireDinProgram)
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