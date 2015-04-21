using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Odbc;

namespace RelInt___Gestiune_cereri_de_deplasare
{
    public partial class frmCerereInregistrare: Form
    {
        public frmCerereInregistrare() // Metoda de LOAD
        {
            InitializeComponent();

            /* ------------ Initializam Combobox-urile cu primele lor valori din colectii ------------------------------------ */
            //cmbGradDidactic.SelectedIndex = 0;
            //cmbFacultatea.SelectedIndex = 0;
            cmbMoneda1.SelectedIndex = 0;
            cmbMoneda2.SelectedIndex = 0;
            cmbMoneda3.SelectedIndex = 0;
            cmbMoneda4.SelectedIndex = 0;
            /* --------------------------------------------------------------------------------------------------------------- */
            
            // Dezactivam checkbox-ul "chkORCDP"
            // chkORCDP.Enabled = false;

            // Dezactivam caseta "dgvOreRecuperate"
            dgvOreRecuperate.Enabled = false;

            // Dezactivam caseta "dgvCondiiDePlata"
            dgvConditiiDePlata.Enabled = false;

            // Dezactivam selectiile pentru tipul de inserare al Orelor Recuperate
            rdoORInserare.Enabled = false;
            rdoORStergere.Enabled = false;

            // Dezactivam selectiile pentru tipul de inserare al Conditiilor De Plata
            rdoCDPInserare.Enabled = false;
            rdoCDPStergere.Enabled = false;

                // Dezactivam campurile si butonul pentru introducerea datelor (OR)
                txtORNrCrt.Enabled = false;
                txtORDenDisciplina.Enabled = false;
                dpORData.Enabled = false;
                dpOROra.Enabled = false;
                txtORSala.Enabled = false;
                btnORInserare.Enabled = false;

                // Dezctivam campurile si butonul pentru stergerea datelor (OR)
                txtORNrCrtStergere.Enabled = false;
                btnORStergere.Enabled = false;

                    // Dezactivam campurile si butonul pentru introducerea datelor (CDP)
                    txtCDPNrCrt.Enabled = false;
                    txtCDPNumePrenProf.Enabled = false;
                    txtCDPDenDisciplina.Enabled = false;
                    txtCDPCondDePlata.Enabled = false;
                    btnCDPIntroducere.Enabled = false;

                    // Dezctivam campurile si butonul pentru stergerea datelor (CDP)
                    txtCDPNrCrtStergere.Enabled = false;
                    btnCDPStergere.Enabled = false;

                        // Dezactivam panoul OR & CDP
                        panouORCDP.Enabled = false;

                            // Resetam controalele
                        MetodaNegareControale();
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
        bool diurnaEsteNumar;
        bool cazareEsteNumar;
        bool TaxaDeParticipareEsteNumar;
        bool TaxaDeVizaEtceEsteNumar;
        double varTotalDePlata;

        // Variabile pentru alte porti logice
        bool CalculTotalSucces = false;
        bool MetodaInserareSucces = false;

        // Variabile de lucru pentru CevaSchimbat()
        bool txtNrInregistrareSchimbat = false;
        bool txtSubsemnatulSchimbat = false;
        bool cmbGradDidacticSchimbat = false;
        bool cmbFacultateaSchimbat = false;
        bool txtDepartamentSchimbat = false;
        bool txtLocalitateaSchimbat = false;
        bool txtTaraSchimbat = false;
        bool txtScopSchimbat = false;
        bool txtInstitutiaSchimbat = false;
        bool txtRutaSchimbat = false;
        bool txtMijTransSchimbat = false;
        bool txtSuportatDeSchimbat = false;
        bool txtCheltuieliSuportateSchimbat = false;
        bool txtDiurnaSchimbat = false;
        bool txtCazareSchimbat = false;
        bool txtTaxaDeParticipareSchimbat = false;
        bool txtTaxaDeVizaSchimbat = false;
        bool txtAmbasadaSchimbat = false;
        bool rdoPerNedeterminataBifat = false;
        bool rdoPerDeterminataBifat = false;
        bool txtDecanSchimbat = false;
        bool txtVizaContaSchimbat = false;
        bool txtAdministratorSefSchimbat = false;
        bool txtSefDepartamentSchimbat = false;
        bool txtVizaRUSchimbat = false;

        // Variabile pentru iesirea din program
        bool IesireDinProgram = false;
        bool PanouriDezactivate = false;
        bool DacaCevaSchimbat = false;

        /* --------------------------------------------------------------------------------------------------------------- */









        /* ---------- Inchidere formular cand actiunam "iesire" din meniul formularului ---------------------------------- */
        private void btnCIIesire_Click(object sender, EventArgs e)
        {
            // Inchidem formularul
            this.Close();
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

            // Inregistram modificarea campului
            txtNrInregistrareSchimbat = true;
        }
        /* --------------------------------------------------------------------------------------------------------------- */










        /* ------ Metoda activare/dezactivare a panoului 5 in functie de txtNrInregistrare si MetodaInserareSucces ------- */
        public void ActivarePanouORCDP()
        {
            if (txtNrInregistrare.Text == string.Empty && MetodaInserareSucces == false)
            {
                //chkORCDP.Enabled = false;
                panouORCDP.Enabled = false;
            }
            else if (txtNrInregistrare.Text != string.Empty && MetodaInserareSucces == true)
            {
                //chkORCDP.Enabled = true;
                panouORCDP.Enabled = true;
            }
        }
        /* --------------------------------------------------------------------------------------------------------------- */




        




        /* ----------------- Metoda calcularii totalului din textbox-ul "txtTotalDePlata" -------------------------------- */
        private void CalculTotal()
        {
            // Verificam daca formularul a fost completat cu o valuta unica
            if (cmbMoneda1.SelectedItem == cmbMoneda2.SelectedItem && cmbMoneda2.SelectedItem == cmbMoneda3.SelectedItem && cmbMoneda3.SelectedItem == cmbMoneda4.SelectedItem)
            {
                // Verificam daca campurile obligatorii sunt completate
                if (txtDiurna.Text != string.Empty && txtCazare.Text != string.Empty && txtTaxaDeViza.Text != string.Empty)
                {
                    // Verificam daca valoarea din "txtDiurna" este de tip double
                    diurnaEsteNumar = double.TryParse(txtDiurna.Text, out varDiurna);

                        // Verificam daca valoarea din "txtCazare" este de tip double
                        cazareEsteNumar = double.TryParse(txtCazare.Text, out varCazare);

                            // Verificam daca valoarea din "txtTaxaDeViza" este de tip double
                            TaxaDeVizaEtceEsteNumar = double.TryParse(txtTaxaDeViza.Text, out varTaxaDeVizaEtc);

                                // Daca valorile din toate textbox-urile de mai sus sunt cifre (de tip double), efectueaza Totalul
                                if (diurnaEsteNumar == true && cazareEsteNumar == true && TaxaDeVizaEtceEsteNumar == true)
                    {
                        // Verificam daca valoarea din "txtTaxaDeParticipare" este de tip double
                        TaxaDeParticipareEsteNumar = double.TryParse(txtTaxaDeParticipare.Text, out varTaxaDeParticipare);

                            // Daca da, verificam daca s-a introdus ceva in campul "txtTaxaDeParticipare"
                            if (txtTaxaDeParticipare.Text == string.Empty)
                        {
                            // Daca nu, setam valoarea campului "zero"
                            varTaxaDeParticipare = 0;
                                // Si punem bool-ul "TaxaDeParticipareEsteNumar" ca fiind adevarat
                                TaxaDeParticipareEsteNumar = true;
                        }

                        // Iar daca bool-ul de mai sus este adevarat, calculam si afisam efectiv valoarea in campul "txtTotalDePlata"
                        if (TaxaDeParticipareEsteNumar == true)
                        {
                            varTotalDePlata = 0;

                            // Calculam total de plata
                            varTotalDePlata = varDiurna + varCazare + varTaxaDeParticipare + varTaxaDeVizaEtc;
                                // Afisare in textboxul "txtTotalDePlata"
                                txtTotalDePlata.Text = varTotalDePlata.ToString();
                                    // Setam bool CalculTotalSucces = true
                                    CalculTotalSucces = true;
                        }
                        else
                        {
                            // Eroare taxa de participare nu este numar
                            MessageBox.Show("              ! Taxa de participare nu este număr ! \n     Vă rugăm introduceți un NUMĂR în acest câmp.");
                        }

                    }
                    // Daca nu sunt toate cifre, afiseaza mesaj
                    else
                    {
                        MessageBox.Show("              ! Vă rugăm introduceți cifre nu litere în acest câmp !");
                    }
                }
                // Daca nu sunt completate cele de mai sus, alerteaza
                else
                {

                    // Alerteaza daca "txtDiurna" nu este completat
                    if (txtDiurna.Text == string.Empty)
                    {
                        MessageBox.Show("              Caseta diurnă nu conține nimic ! \n              Vă rugăm completați câmpul.");
                        return;
                    }

                        // Alerteaza daca "txtCazare" nu este completat
                        if (txtCazare.Text == string.Empty)
                        {
                            MessageBox.Show("              Caseta cazare nu conține nimic ! \n              Vă rugăm completați câmpul.");
                            return;
                        }

                            // Alerteaza daca "txtTaxaDeViza" nu este completat
                            if (txtTaxaDeViza.Text == string.Empty)
                            {
                                MessageBox.Show("              Caseta taxa de viză + asigurarea medicală nu conține nimic ! \n                                   Vă rugăm completați câmpul.");
                                return;
                            }
                }
            } // daca nu
            else
            {
                // Alertam corespunzator
                MessageBox.Show("              Nu se poate înregistra / calcula totalul cu valute diferite !");
            }
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
                    comanda_inserareRelInt.CommandText = "INSERT into Cereri VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)";
                    comanda_inserareRelInt.Parameters.AddWithValue("@nrinregistrarec", OdbcType.Int).Value = vartxtNrInregistrare;
                    comanda_inserareRelInt.Parameters.AddWithValue("@datac", OdbcType.DateTime).Value = dpDataFormular.Value;
                    comanda_inserareRelInt.Parameters.AddWithValue("@subsemnatulc", OdbcType.NVarChar).Value = txtSubsemnatul.Text;
                    comanda_inserareRelInt.Parameters.AddWithValue("@graddidacticc", OdbcType.NVarChar).Value = cmbGradDidactic.SelectedItem;
                    comanda_inserareRelInt.Parameters.AddWithValue("@facultateac", OdbcType.NVarChar).Value = cmbFacultatea.SelectedItem;
                    comanda_inserareRelInt.Parameters.AddWithValue("@departamentulc", OdbcType.NVarChar).Value = txtDepartament.Text;
                    comanda_inserareRelInt.Parameters.AddWithValue("@localitateac", OdbcType.NVarChar).Value = txtLocalitatea.Text;
                    comanda_inserareRelInt.Parameters.AddWithValue("@tarac", OdbcType.NVarChar).Value = txtTara.Text;
                    comanda_inserareRelInt.Parameters.AddWithValue("@scopc", OdbcType.NVarChar).Value = txtScop.Text;
                    comanda_inserareRelInt.Parameters.AddWithValue("@institutiac", OdbcType.NVarChar).Value = txtInstitutia.Text;
                    comanda_inserareRelInt.Parameters.AddWithValue("@datainceputc", OdbcType.DateTime).Value = dpDataInceput.Value;
                    comanda_inserareRelInt.Parameters.AddWithValue("@datasfarsitc", OdbcType.DateTime).Value = dpDataSfarsit.Value;
                    comanda_inserareRelInt.Parameters.AddWithValue("@rutac", OdbcType.NVarChar).Value = txtRuta.Text;
                    comanda_inserareRelInt.Parameters.AddWithValue("@mijtransc", OdbcType.NVarChar).Value = txtMijTrans.Text;
                    comanda_inserareRelInt.Parameters.AddWithValue("@platitortranspc", OdbcType.NVarChar).Value = txtSuportatDe.Text;
                    comanda_inserareRelInt.Parameters.AddWithValue("@platitorintretinerec", OdbcType.NVarChar).Value = txtCheltuieliSuportate.Text;
                    comanda_inserareRelInt.Parameters.AddWithValue("@diurnac", OdbcType.Double).Value = varDiurna;
                    comanda_inserareRelInt.Parameters.AddWithValue("@cazarecc", OdbcType.Double).Value = varCazare;
                    comanda_inserareRelInt.Parameters.AddWithValue("@taxadeparticiparec", OdbcType.Double).Value = varTaxaDeParticipare;
                    comanda_inserareRelInt.Parameters.AddWithValue("@taxadevizaetcc", OdbcType.Double).Value = varTaxaDeVizaEtc;
                    comanda_inserareRelInt.Parameters.AddWithValue("@totalc", OdbcType.Double).Value = varTotalDePlata;
                    comanda_inserareRelInt.Parameters.AddWithValue("@ambasadac", OdbcType.NVarChar).Value = txtAmbasada.Text;
                    comanda_inserareRelInt.Parameters.AddWithValue("@nedeterminatac", OdbcType.Bit).Value = rdoPerNedeterminata.Checked;
                    comanda_inserareRelInt.Parameters.AddWithValue("@determinatac", OdbcType.Bit).Value = rdoPerDeterminata.Checked;
                    comanda_inserareRelInt.Parameters.AddWithValue("@decanc", OdbcType.NVarChar).Value = txtDecan.Text;
                    comanda_inserareRelInt.Parameters.AddWithValue("@vizacontac", OdbcType.NVarChar).Value = txtVizaConta.Text;
                    comanda_inserareRelInt.Parameters.AddWithValue("@admsebirouc", OdbcType.NVarChar).Value = txtAdministratorSef.Text;
                    comanda_inserareRelInt.Parameters.AddWithValue("@sefdepartamentdirc", OdbcType.NVarChar).Value = txtSefDepartament.Text;
                    comanda_inserareRelInt.Parameters.AddWithValue("@vizaruc", OdbcType.NVarChar).Value = txtVizaRU.Text;
                    comanda_inserareRelInt.Parameters.AddWithValue("@tioz", OdbcType.Bit).Value = false;



                    // Incercam conexiunea si query-ul
                    try
                    {
                        conexiune_InserareCerereRelInt.Open();
                        int recordsAffected = comanda_inserareRelInt.ExecuteNonQuery();
                            MetodaInserareSucces = true;
                    } // Captam eventualele erori
                    catch (OdbcException exInserare)
                    {
                        // Afisam eroarea driverului Odbc
                        MessageBox.Show(exInserare.Message);
                    } // Ne deconectam
                    finally
                    {
                        conexiune_InserareCerereRelInt.Close();
                    }
                }
            }
        }
        /* --------------------------------------------------------------------------------------------------------------- */










        /* ------------------- Metoda de dezactivare a primelor 4 panouri ------------------------------------------------ */
        private void DezactivarePanouriPP()
        {
            // Dezactiveaza panourile urmatoare
            panouIdentificareCerere.Enabled = false;
            panouContinut.Enabled = false;
            panouCheltuieliPlecare.Enabled = false;
            panouMentiuniLegale.Enabled = false;

            // Seteaza adevarata variabila "PanouriDezactivate"
            PanouriDezactivate = true;
        }
        /* --------------------------------------------------------------------------------------------------------------- */









        


        /* ----------- Actiunea de salvare a formularului ---------------------------------------------------------------- */
        private void btnCISalvareFormular_Click(object sender, EventArgs e)
        {
            SalvareFormular();
        }
        /* --------------------------------------------------------------------------------------------------------------- */







        // Metoda MetodaNegareControale
        private void MetodaNegareControale()
        {
            // Variabile de negat (resetat)
            txtSubsemnatulSchimbat = false;
            cmbGradDidacticSchimbat = false;
            cmbFacultateaSchimbat = false;
            txtDepartamentSchimbat = false;
            txtLocalitateaSchimbat = false;
            txtTaraSchimbat = false;
            txtScopSchimbat = false;
            txtInstitutiaSchimbat = false;
            txtRutaSchimbat = false;
            txtMijTransSchimbat = false;
            txtSuportatDeSchimbat = false;
            txtCheltuieliSuportateSchimbat = false;
            txtDiurnaSchimbat = false;
            txtCazareSchimbat = false;
            txtTaxaDeParticipareSchimbat = false;
            txtTaxaDeVizaSchimbat = false;
            txtAmbasadaSchimbat = false;
            txtDecanSchimbat = false;
            txtVizaContaSchimbat = false;
            txtAdministratorSefSchimbat = false;
            txtSefDepartamentSchimbat = false;
            txtVizaRUSchimbat = false;
        }








        /* -------------- Actiunile ce iau loc la salvare ---------------------------------------------------------------- */
        private void SalvareFormular()
        {
            // Daca caseta "txtNrInregistrare" nu este goala
            if (txtNrInregistrare.Text != string.Empty)
            {
                // Lucreaza asta
                CalculTotal();

                    // Daca variabila "CalculTotalSucces" este adevarata
                    if (CalculTotalSucces == true)
                    {
                        // Lucreaza asta
                        MetodaInserareDB();

                            // Daca variabila "MetodaInserareSucces" este adevarata
                            if (MetodaInserareSucces == true)
                            {
                                // Dezactiveaza primele 4 panouri
                                DezactivarePanouriPP();

                                // Activeaza panoul 5
                                ActivarePanouORCDP();

                                // Actualizam statusul de pe frmGCD
                                frmGCD frmGCD = new frmGCD();
                                frmGCD.MetodaScriereInStatus();

                                // Daca panoul "panouORCDP" este activ si "chkORCDP" nebifat
                                if (panouORCDP.Enabled == true && PanouriDezactivate == true && chkORCDP.Checked == false)
                                {
                                    // Notifica bool iesire din program (true)
                                    IesireDinProgram = true;

                                        // Dezactivam butonul de salvare
                                        btnCISalvareFormular.Enabled = false;

                                            // Negam modificarile controalelor (le resetam pe false)
                                            MetodaNegareControale();
                                }
                                // Daca panoul "panouORCDP" este activ si "chkORCDP" bifat
                                else if (panouORCDP.Enabled == true && PanouriDezactivate == true && chkORCDP.Checked == true)
                                {
                                    // Notifica bool iesire din program (true)
                                    IesireDinProgram = true;

                                        // Dezactivam butonul de salvare
                                        btnCISalvareFormular.Enabled = false;

                                            // Negam modificarile controalelor (le resetam pe false)
                                            MetodaNegareControale();
                                }
                            }
                        // Daca variabila "MetodaInserareSucces" nu este adevarata
                        else 
                        { 
                            // Nu fa nimic

                        }
                    }
                    // Daca variabila "CalculTotalSucces" nu este adevarata
                    else
                    {
                        // Nu fa nimic

                    }
            }
            // Daca caseta "txtNrInregistrare" este goala
            else 
            {
                // Afiseaza eroarea
                MessageBox.Show("               Nu ați completat caseta \"Număr Înregistrare\"! \n                              Vă rugăm să o completați.");
            }
        }
        /* --------------------------------------------------------------------------------------------------------------- */









        /* - Metoda de detectare daca un anumit camp a fost modificat din formular dupa ce acesta din urma este incarcat - */
        private void CevaSchimbat()
        {
            // Daca vreuna din variabilele urmatoare este adevarata atunci
            if (txtNrInregistrareSchimbat == true 
                || txtSubsemnatulSchimbat == true 
                || cmbGradDidacticSchimbat == true 
                || cmbFacultateaSchimbat == true 
                || txtDepartamentSchimbat == true 
                || txtLocalitateaSchimbat == true 
                || txtTaraSchimbat == true 
                || txtScopSchimbat == true 
                || txtInstitutiaSchimbat == true 
                || txtRutaSchimbat == true 
                || txtMijTransSchimbat == true 
                || txtSuportatDeSchimbat == true 
                || txtCheltuieliSuportateSchimbat == true 
                || txtDiurnaSchimbat == true 
                || txtCazareSchimbat == true 
                || txtTaxaDeParticipareSchimbat == true 
                || txtTaxaDeVizaSchimbat == true 
                || txtAmbasadaSchimbat == true 
                || rdoPerNedeterminataBifat == true
                || rdoPerDeterminataBifat == true
                || txtDecanSchimbat == true 
                || txtVizaContaSchimbat == true 
                || txtAdministratorSefSchimbat == true 
                || txtSefDepartamentSchimbat == true 
                || txtVizaRUSchimbat == true)
                {
                    DacaCevaSchimbat = true;
                } 
                // Daca niciuna din variabilele urmatoare nu este adevarata atunci
                else {
                DacaCevaSchimbat = false;
                }
        }
        /* --------------------------------------------------------------------------------------------------------------- */


        








        /* --------------- Metoda de incarcare a "dgvOreRecuperate" ------------------------------------------------------ */
        public void IncarcaredgvOreRecuperate()
        {
            using (OdbcConnection conexiune_dgvOreRecuperate = new OdbcConnection(sircon_RelIntDB))
            {           // Comanda
                using (OdbcCommand comanda_dgvOreRecuperate = new OdbcCommand())
                {
                    comanda_dgvOreRecuperate.Connection = conexiune_dgvOreRecuperate;
                    comanda_dgvOreRecuperate.CommandType = CommandType.Text;
                    comanda_dgvOreRecuperate.CommandText = "SELECT nrcrtor as \"Nr. Crt.\", dendisciplinaor as \"Denumire Disciplina\", dataor as \"Data\", oraor as \"Ora\", salaor as \"Sala\" FROM orerecuperate WHERE nrcerereor = ?";
                    comanda_dgvOreRecuperate.Parameters.AddWithValue("@nrcerereor", OdbcType.Int).Value = vartxtNrInregistrare;

                    try
                    {
                        conexiune_dgvOreRecuperate.Open();
                        OdbcDataAdapter da_dgvOreRecuperate = new OdbcDataAdapter();
                        da_dgvOreRecuperate.SelectCommand = comanda_dgvOreRecuperate;

                        DataTable dt_dgvOreRecuperate = new DataTable();
                        da_dgvOreRecuperate.Fill(dt_dgvOreRecuperate);

                        BindingSource bs_dgvOreRecuperate = new BindingSource();
                        bs_dgvOreRecuperate.DataSource = dt_dgvOreRecuperate;

                        dgvOreRecuperate.DataSource = bs_dgvOreRecuperate;

                        da_dgvOreRecuperate.Update(dt_dgvOreRecuperate);
                    }
                    catch (Exception exdgvOreRecuperate)
                    {
                        MessageBox.Show(exdgvOreRecuperate.Message);
                    } // Ne deconectam
                    finally
                    {
                        conexiune_dgvOreRecuperate.Close();
                    }
                }
            }
        }
        /* --------------------------------------------------------------------------------------------------------------- */
        /* --------------- Metoda de Descarcare a "dgvOreRecuperate" ----------------------------------------------------- */
        public void DescarcaredgvOreRecuperate()
        {
            using (OdbcConnection conexiune_dgvOreRecuperate = new OdbcConnection(sircon_RelIntDB))
            {           // Comanda
                using (OdbcCommand comanda_dgvOreRecuperate = new OdbcCommand())
                {
                    comanda_dgvOreRecuperate.Connection = conexiune_dgvOreRecuperate;
                    comanda_dgvOreRecuperate.CommandType = CommandType.Text;
                    comanda_dgvOreRecuperate.CommandText = "SELECT nrcrtor as \"Nr. Crt.\", dendisciplinaor as \"Denumire Disciplina\", dataor as \"Data\", oraor as \"Ora\", salaor as \"Sala\" FROM orerecuperate WHERE nrcerereor = ?";
                    comanda_dgvOreRecuperate.Parameters.AddWithValue("@nrcerereor", OdbcType.Int).Value = vartxtNrInregistrare;

                    try
                    {
                        conexiune_dgvOreRecuperate.Open();
                        OdbcDataAdapter da_dgvOreRecuperate = new OdbcDataAdapter();
                        da_dgvOreRecuperate.SelectCommand = comanda_dgvOreRecuperate;

                        DataTable dt_dgvOreRecuperate = new DataTable();
                        da_dgvOreRecuperate.Dispose();

                        BindingSource bs_dgvOreRecuperate = new BindingSource();
                        bs_dgvOreRecuperate.DataSource = dt_dgvOreRecuperate;

                        dgvOreRecuperate.DataSource = bs_dgvOreRecuperate;

                        da_dgvOreRecuperate.Update(dt_dgvOreRecuperate);
                    }
                    catch (Exception exdgvOreRecuperate)
                    {
                        MessageBox.Show(exdgvOreRecuperate.Message);
                    } // Ne deconectam
                    finally
                    {
                        conexiune_dgvOreRecuperate.Close();
                    }
                }
            }
        }
        /* --------------------------------------------------------------------------------------------------------------- */












        /* --------------- Metoda de incarcare a "dgvConditiiDePlata" ---------------------------------------------------- */
        public void IncarcaredgvConditiiDePlata()
        {
            using (OdbcConnection conexiune_dgvConditiiDePlata = new OdbcConnection(sircon_RelIntDB))
            {           // Comanda
                using (OdbcCommand comanda_dgvConditiiDePlata = new OdbcCommand())
                {
                    comanda_dgvConditiiDePlata.Connection = conexiune_dgvConditiiDePlata;
                    comanda_dgvConditiiDePlata.CommandType = CommandType.Text;
                    comanda_dgvConditiiDePlata.CommandText = "SELECT nrcrtcdp as \"Nr. Crt.\", numeprenprofcdp as \"Nume Prenume prof.\", dendisciplinacdp as \"Denumire Disciplina\", conddeplatacdp as \"Conditii de plata\" FROM conditiideplata";
                    comanda_dgvConditiiDePlata.Parameters.AddWithValue("@nrcererecdp", OdbcType.Int).Value = vartxtNrInregistrare;

                    try
                    {
                        conexiune_dgvConditiiDePlata.Open();
                        OdbcDataAdapter da_dgvConditiiDePlata = new OdbcDataAdapter();
                        da_dgvConditiiDePlata.SelectCommand = comanda_dgvConditiiDePlata;

                        DataTable dt_dgvConditiiDePlata = new DataTable();
                        da_dgvConditiiDePlata.Fill(dt_dgvConditiiDePlata);

                        BindingSource bs_dgvConditiiDePlata = new BindingSource();
                        bs_dgvConditiiDePlata.DataSource = dt_dgvConditiiDePlata;

                        dgvConditiiDePlata.DataSource = bs_dgvConditiiDePlata;

                        da_dgvConditiiDePlata.Update(dt_dgvConditiiDePlata);
                    }
                    catch (Exception exdgvConditiiDePlata)
                    {
                        MessageBox.Show(exdgvConditiiDePlata.Message);
                    } // Ne deconectam
                    finally
                    {
                        conexiune_dgvConditiiDePlata.Close();
                    }
                }
            }
        }
        /* --------------------------------------------------------------------------------------------------------------- */
        /* --------------- Metoda de descarcare a "dgvConditiiDePlata" --------------------------------------------------- */
        public void DescarcaredgvConditiiDePlata()
        {
            using (OdbcConnection conexiune_dgvConditiiDePlata = new OdbcConnection(sircon_RelIntDB))
            {           // Comanda
                using (OdbcCommand comanda_dgvConditiiDePlata = new OdbcCommand())
                {
                    comanda_dgvConditiiDePlata.Connection = conexiune_dgvConditiiDePlata;
                    comanda_dgvConditiiDePlata.CommandType = CommandType.Text;
                    comanda_dgvConditiiDePlata.CommandText = "SELECT nrcrtcdp as \"Nr. Crt.\", numeprenprofcdp as \"Nume Prenume prof.\", dendisciplinacdp as \"Denumire Disciplina\", conddeplatacdp as \"Conditii de plata\" FROM conditiideplata";
                    comanda_dgvConditiiDePlata.Parameters.AddWithValue("@nrcererecdp", OdbcType.Int).Value = vartxtNrInregistrare;

                    try
                    {
                        conexiune_dgvConditiiDePlata.Open();
                        OdbcDataAdapter da_dgvConditiiDePlata = new OdbcDataAdapter();
                        da_dgvConditiiDePlata.SelectCommand = comanda_dgvConditiiDePlata;

                        DataTable dt_dgvConditiiDePlata = new DataTable();
                        da_dgvConditiiDePlata.Dispose();

                        BindingSource bs_dgvConditiiDePlata = new BindingSource();
                        bs_dgvConditiiDePlata.DataSource = dt_dgvConditiiDePlata;

                        dgvConditiiDePlata.DataSource = bs_dgvConditiiDePlata;

                        da_dgvConditiiDePlata.Update(dt_dgvConditiiDePlata);
                    }
                    catch (Exception exdgvConditiiDePlata)
                    {
                        MessageBox.Show(exdgvConditiiDePlata.Message);
                    } // Ne deconectam
                    finally
                    {
                        conexiune_dgvConditiiDePlata.Close();
                    }
                }
            }
        }
        /* --------------------------------------------------------------------------------------------------------------- */








        /* ------------ Metoda pentru checkbox "chkORCDP" ---------------------------------------------------------------- */
        private void chkORCDP_CheckedChanged(object sender, EventArgs e)
        {
            // Apelam validarea chkORCDP
            if (chkORCDP.Checked == true)
            {
                // Dezactivam caseta "txtNrInregistrare"
                txtNrInregistrare.Enabled = false;

                // Metoda dezactivare campuri


                    // Activam selectiile pentru tipul de inserare al Orelor Recuperate
                    rdoORInserare.Enabled = true;
                    rdoORStergere.Enabled = true;
                    // Activam selectiile pentru tipul de inserare al Conditiilor De Plata
                    rdoCDPInserare.Enabled = true;
                    rdoCDPStergere.Enabled = true;
            }
            else
            {
                // Activam caseta "txtNrInregistrare"
                txtNrInregistrare.Enabled = true;

                    // Descarcare "dgvOreRecuperate"
                    DescarcaredgvOreRecuperate();

                    // Descarcare "dgvOreRecuperate"
                    DescarcaredgvConditiiDePlata();

                        // Dezactivam datagridview "dgvOreRecuperate"
                        dgvOreRecuperate.Enabled = false;

                        // Dezactivam datagridview "dgvCondiiDePlata"
                        dgvConditiiDePlata.Enabled = false;

                            // Stergem selectiile pentru tipul de inserare al Orelor Recuperate
                            rdoORInserare.Checked = false;
                            rdoORStergere.Checked = false;
                            // Dezactivam selectiile pentru tipul de inserare al Orelor Recuperate
                            rdoORInserare.Enabled = false;
                            rdoORStergere.Enabled = false;

                            // Stergem selectiile pentru tipul de inserare al Conditiilor De Plata
                            rdoCDPInserare.Checked = false;
                            rdoCDPStergere.Checked = false;
                            // Dezactivam selectiile pentru tipul de inserare al Conditiilor De Plata
                            rdoCDPInserare.Enabled = false;
                            rdoCDPStergere.Enabled = false;

                                // Stergem tot din campurile pentru introducerea datelor (OR)
                                txtORNrCrt.Clear();
                                txtORDenDisciplina.Clear();
                                txtORSala.Clear();

                                // Dezactivam campurile si butonul pentru introducerea datelor (OR)
                                txtORNrCrt.Enabled = false;
                                txtORDenDisciplina.Enabled = false;
                                dpORData.Enabled = false;
                                dpOROra.Enabled = false;
                                txtORSala.Enabled = false;
                                btnORInserare.Enabled = false;

                                // Stergem tot din campurile pentru stergerea datelor (OR)
                                txtORNrCrtStergere.Clear();

                                // Dezactivam campurile si butonul pentru stergerea datelor (OR)
                                txtORNrCrtStergere.Enabled = false;
                                btnORStergere.Enabled = false;

                                    // Stergem tot din campurile pentru introducerea datelor (CDP)
                                    txtCDPNrCrt.Clear();
                                    txtCDPNumePrenProf.Clear();
                                    txtCDPDenDisciplina.Clear();
                                    txtCDPCondDePlata.Clear();

                                    // Dezactivam campurile si butonul pentru introducerea datelor (CDP)
                                    txtCDPNrCrt.Enabled = false;
                                    txtCDPNumePrenProf.Enabled = false;
                                    txtCDPDenDisciplina.Enabled = false;
                                    txtCDPCondDePlata.Enabled = false;
                                    btnCDPIntroducere.Enabled = false;

                                    // Stergem tot din campurile pentru stergerea datelor (CDP)
                                    

                                    // Dezactivam campurile si butonul pentru stergerea datelor (CDP)
                                    txtCDPNrCrtStergere.Enabled = false;
                                    btnCDPStergere.Enabled = false;
            }
        }
        /* --------------------------------------------------------------------------------------------------------------- */






        /* ------------- Metoda pentru actiunile lui "rdoORInserare" ----------------------------------------------------- */
        private void rdoORInserare_CheckedChanged(object sender, EventArgs e)
        {
            if (chkORCDP.Checked == true) 
            {
                if (rdoORInserare.Checked == true)
                {
                    // Activam "dgvOreRecuperate"
                    dgvOreRecuperate.Enabled = true;

                    // Incarcam "dgvOreRecuperate"
                    IncarcaredgvOreRecuperate();

                    // Activam campurile si butonul pentru introducerea datelor
                    txtORNrCrt.Enabled = true;
                    txtORDenDisciplina.Enabled = true;
                    dpORData.Enabled = true;
                    dpOROra.Enabled = true;
                    txtORSala.Enabled = true;
                        btnORInserare.Enabled = true;
                }
                else
                {
                    // Activam "dgvOreRecuperate"
                    dgvOreRecuperate.Enabled = true;

                    // Stergem tot din campurile pentru introducerea datelor
                    txtORNrCrt.Clear();
                    txtORDenDisciplina.Clear();
                    txtORSala.Clear();

                    // Dezactivam campurile si butonul pentru introducerea datelor
                    txtORNrCrt.Enabled = false;
                    txtORDenDisciplina.Enabled = false;
                    dpORData.Enabled = false;
                    dpOROra.Enabled = false;
                    txtORSala.Enabled = false;
                        btnORInserare.Enabled = false;
                }
            }
        }
        /* --------------------------------------------------------------------------------------------------------------- */
        /* ------------- Metoda pentru actiunile lui "rdoORStergere" ----------------------------------------------------- */
        private void rdoORStergere_CheckedChanged(object sender, EventArgs e)
        {
            if (chkORCDP.Checked == true)
            {
                if (rdoORStergere.Checked == true)
                {
                    // Activam "dgvOreRecuperate"
                    dgvOreRecuperate.Enabled = true;

                    // Incarcam "dgvOreRecuperate"
                    IncarcaredgvOreRecuperate();

                    // Activam campurile si butonul pentru stergerea datelor
                    txtORNrCrtStergere.Enabled = true;
                        btnORStergere.Enabled = true;
                }
                else
                {
                    // Activam "dgvOreRecuperate"
                    dgvOreRecuperate.Enabled = true;

                    // Stergem tot din campurile pentru stergerea datelor
                    txtORNrCrtStergere.Clear();

                    // Dezactivam campurile si butonul pentru stergerea datelor
                    txtORNrCrtStergere.Enabled = false;
                        btnORStergere.Enabled = false;
                }
            }
        }
        /* --------------------------------------------------------------------------------------------------------------- */












        /* -------------------- Metoda pentru actiunile lui "rdoCDPInserare" --------------------------------------------- */
        private void rdoCDPInserare_CheckedChanged(object sender, EventArgs e)
        {
            if (chkORCDP.Checked == true)
            {
                if (rdoCDPInserare.Checked == true)
                {
                    // Activam "dgvOreRecuperate"
                    dgvConditiiDePlata.Enabled = true;

                    // Incarcam "dgvOreRecuperate"
                    IncarcaredgvConditiiDePlata();

                    // Activam campurile si butonul pentru introducerea datelor
                    txtCDPNrCrt.Enabled = true;
                    txtCDPNumePrenProf.Enabled = true;
                    txtCDPDenDisciplina.Enabled = true;
                    txtCDPCondDePlata.Enabled = true;
                    btnCDPIntroducere.Enabled = true;
                }
                else
                {
                    // Activam "dgvOreRecuperate"
                    dgvConditiiDePlata.Enabled = true;

                    // Stergem tot din campurile pentru introducerea datelor
                    txtCDPNrCrt.Clear();
                    txtCDPNumePrenProf.Clear();
                    txtCDPDenDisciplina.Clear();
                    txtCDPCondDePlata.Clear();

                    // Dezactivam campurile si butonul pentru introducerea datelor
                    txtCDPNrCrt.Enabled = false;
                    txtCDPNumePrenProf.Enabled = false;
                    txtCDPDenDisciplina.Enabled = false;
                    txtCDPCondDePlata.Enabled = false;
                        btnCDPIntroducere.Enabled = false;
                }
            }
        }
        /* --------------------------------------------------------------------------------------------------------------- */
        /* -------------------- Metoda pentru actiunile lui "rdoCDPStergere" --------------------------------------------- */
        private void rdoCDPStergere_CheckedChanged(object sender, EventArgs e)
        {
            if (chkORCDP.Checked == true)
            {
                if (rdoCDPStergere.Checked == true)
                {
                    // Activam "dgvOreRecuperate"
                    dgvConditiiDePlata.Enabled = true;

                    // Incarcam "dgvOreRecuperate"
                    IncarcaredgvConditiiDePlata();

                    // Activam campurile si butonul pentru stergerea datelor
                    txtCDPNrCrtStergere.Enabled = true;
                    btnCDPStergere.Enabled = true;
                }
                else
                {
                    // Activam "dgvOreRecuperate"
                    dgvConditiiDePlata.Enabled = true;

                    // Stergem tot din campurile pentru stergerea datelor
                    txtCDPNrCrtStergere.Clear();

                    // Dezactivam campurile si butonul pentru stergerea datelor
                    txtCDPNrCrtStergere.Enabled = false;
                        btnCDPStergere.Enabled = false;
                }
            }
        }
        /* --------------------------------------------------------------------------------------------------------------- */











        /* --------- Variabile de lucru pentru validarile textboxurilor folosite pentru a insera date in tabea OR -------- */
        int vartxtORNrCrt;
        int vartxtORNrCrtStergere;
        /* --------------------------------------------------------------------------------------------------------------- */
        /* --------------------- Validari pentru textbox-urile folosite pentru a insera date in tabela OR ---------------- */
        private void txtORNrCrt_TextChanged(object sender, EventArgs e)
        {
            // Verificam daca valoarea din "txtORNrCrt" este de tip int
            bool vartxtORNrCrtEsteNumar = Int32.TryParse(txtORNrCrt.Text, out vartxtORNrCrt);

            // Judecam si "sanctionam" la nevoie
            switch (vartxtORNrCrtEsteNumar || txtORNrCrt.Text == string.Empty)
            {
                case false:
                    // Golim casuta si afisam mesaj de eroare
                    txtORNrCrt.Clear();
                    MessageBox.Show("        Vă rugăm introduceți doar numere în această casetă de text.");
                    break;
            }
        }

                private void txtORNrCrtStergere_TextChanged(object sender, EventArgs e)
                {
                    // Verificam daca valoarea din "txtORNrCrtStergere" este de tip int
                    bool vartxtORNrCrtStergereEsteNumar = Int32.TryParse(txtORNrCrtStergere.Text, out vartxtORNrCrtStergere);

                    // Judecam si "sanctionam" la nevoie
                    switch (vartxtORNrCrtStergereEsteNumar || txtORNrCrtStergere.Text == string.Empty)
                    {
                        case false:
                            // Golim casuta si afisam mesaj de eroare
                            txtORNrCrtStergere.Clear();
                            MessageBox.Show("        Vă rugăm introduceți doar numere în această casetă de text.");
                            break;
                    }
                }
        /* --------------------------------------------------------------------------------------------------------------- */
        /* -------------------- Metoda de tip "INSERT" pentru O-R -------------------------------------------------------- */
        private void btnORInserare_Click(object sender, EventArgs e)
        {
            // Metoda de inserare a datelor
            // Conexiunea
            using (OdbcConnection conexiune_InserareOR = new OdbcConnection(sircon_RelIntDB))
            {           // Comanda
                using (OdbcCommand comanda_InserareOR = new OdbcCommand())
                {
                    comanda_InserareOR.Connection = conexiune_InserareOR;
                    comanda_InserareOR.CommandType = CommandType.Text;
                    comanda_InserareOR.CommandText = "INSERT into orerecuperate VALUES (?, ?, ?, ?, ?, ?)";
                    comanda_InserareOR.Parameters.AddWithValue("@nrcerereor", OdbcType.Int).Value = vartxtNrInregistrare;
                    comanda_InserareOR.Parameters.AddWithValue("@nrcrtor", OdbcType.Int).Value = vartxtORNrCrt;
                    comanda_InserareOR.Parameters.AddWithValue("@dendisciplinaor", OdbcType.NVarChar).Value = txtORDenDisciplina.Text;
                    comanda_InserareOR.Parameters.AddWithValue("@dataor", OdbcType.DateTime).Value = dpORData.Value;
                    comanda_InserareOR.Parameters.AddWithValue("@dataor", OdbcType.DateTime).Value = dpOROra.Value;
                    comanda_InserareOR.Parameters.AddWithValue("@dsalaor", OdbcType.NVarChar).Value = txtORSala.Text;
                    
                    // Incercam conexiunea si query-ul
                    try
                    {
                        conexiune_InserareOR.Open();
                        int recordsAffected = comanda_InserareOR.ExecuteNonQuery();
                    } // Captam eventualele erori
                    catch (OdbcException exInserare)
                    {
                        // Afisam eroarea driverului Odbc
                        MessageBox.Show(exInserare.Message);
                    } // Ne deconectam
                    finally
                    {
                        conexiune_InserareOR.Close();
                    }
                }
            }

            // Actualizam "dgvOreRecuprate"
            IncarcaredgvOreRecuperate();

            // Golim campurile pentru introducerea datelor
            txtORNrCrt.Clear();
            txtORDenDisciplina.Clear();
            txtORSala.Clear();
        }
        /* --------------------------------------------------------------------------------------------------------------- */
        /* -------------------- Metoda de tip "DELETE" pentru O-R -------------------------------------------------------- */
        private void btnORStergere_Click(object sender, EventArgs e)
        {
            // Metoda de stergere a datelor
            // Conexiunea
            using (OdbcConnection conexiune_StergereOR = new OdbcConnection(sircon_RelIntDB))
            {           // Comanda
                using (OdbcCommand comanda_StergereOR = new OdbcCommand())
                {
                    comanda_StergereOR.Connection = conexiune_StergereOR;
                    comanda_StergereOR.CommandType = CommandType.Text;
                    comanda_StergereOR.CommandText = "DELETE FROM orerecuperate WHERE nrcerereor = ? AND nrcrtor = ?";
                    comanda_StergereOR.Parameters.AddWithValue("@nrcerereor", OdbcType.Int).Value = vartxtNrInregistrare;
                    comanda_StergereOR.Parameters.AddWithValue("@nrcrtor", OdbcType.Int).Value = vartxtORNrCrtStergere;

                    // Incercam conexiunea si query-ul
                    try
                    {
                        conexiune_StergereOR.Open();
                        int recordsAffected = comanda_StergereOR.ExecuteNonQuery();
                    } // Captam eventualele erori
                    catch (OdbcException exInserare)
                    {
                        // Afisam eroarea driverului Odbc
                        MessageBox.Show(exInserare.Message);
                    } // Ne deconectam
                    finally
                    {
                        conexiune_StergereOR.Close();
                    }
                }
            }

            // Actualizam "dgvOreRecuprate"
            IncarcaredgvOreRecuperate();

            // Golim campul "txtORNrCrtStergere"
            txtORNrCrtStergere.Clear();
        }
        /* --------------------------------------------------------------------------------------------------------------- */











        /* -------- Variabile de lucru pentru validarile textboxurilor folosite pentru a insera date in tabea CDP -------- */
        int vartxtCDPNrCrt;
        int vartxtCDPNrCrtStergere;
        /* --------------------------------------------------------------------------------------------------------------- */
        /* --------------------- Validari pentru textbox-urile folosite pentru a insera date in tabela OR ---------------- */
        private void txtCDPNrCrt_TextChanged(object sender, EventArgs e)
        {
            // Verificam daca valoarea din "txtCDPNrCrt" este de tip int
            bool vartxtCDPNrCrtEsteNumar = Int32.TryParse(txtCDPNrCrt.Text, out vartxtCDPNrCrt);

            // Judecam si "sanctionam" la nevoie
            switch (vartxtCDPNrCrtEsteNumar || txtCDPNrCrt.Text == string.Empty)
            {
                case false:
                    // Golim casuta si afisam mesaj de eroare
                    txtCDPNrCrt.Clear();
                    MessageBox.Show("        Vă rugăm introduceți doar numere în această casetă de text.");
                    break;
            }
        }

                private void txtCDPNrCrtStergere_TextChanged(object sender, EventArgs e)
                {
                    // Verificam daca valoarea din "txtCDPNrCrtStergere" este de tip int
                    bool vartxtCDPNrCrtStergereEsteNumar = Int32.TryParse(txtCDPNrCrtStergere.Text, out vartxtCDPNrCrtStergere);

                    // Judecam si "sanctionam" la nevoie
                    switch (vartxtCDPNrCrtStergereEsteNumar || txtCDPNrCrtStergere.Text == string.Empty)
                    {
                        case false:
                            // Golim casuta si afisam mesaj de eroare
                            txtCDPNrCrtStergere.Clear();
                            MessageBox.Show("        Vă rugăm introduceți doar numere în această casetă de text.");
                            break;
                    }
                }
        /* --------------------------------------------------------------------------------------------------------------- */
        /* -------------------- Metoda de tip "INSERT" pentru CDP -------------------------------------------------------- */
        private void btnCDPIntroducere_Click(object sender, EventArgs e)
        {
            // Metoda de inserare a datelor
            // Conexiunea
            using (OdbcConnection conexiune_InserareCDP = new OdbcConnection(sircon_RelIntDB))
            {           // Comanda
                using (OdbcCommand comanda_InserareCDP = new OdbcCommand())
                {
                    comanda_InserareCDP.Connection = conexiune_InserareCDP;
                    comanda_InserareCDP.CommandType = CommandType.Text;
                    comanda_InserareCDP.CommandText = "INSERT into conditiideplata VALUES (?, ?, ?, ?, ?)";
                    comanda_InserareCDP.Parameters.AddWithValue("@nrcererecdp", OdbcType.Int).Value = vartxtNrInregistrare;
                    comanda_InserareCDP.Parameters.AddWithValue("@nrcrtcdp", OdbcType.Int).Value = vartxtCDPNrCrt;
                    comanda_InserareCDP.Parameters.AddWithValue("@numeprenprofcdp", OdbcType.NVarChar).Value = txtCDPNumePrenProf.Text;
                    comanda_InserareCDP.Parameters.AddWithValue("@dendisciplinacdp", OdbcType.NVarChar).Value = txtCDPDenDisciplina.Text;
                    comanda_InserareCDP.Parameters.AddWithValue("@conddeplatacdp", OdbcType.NVarChar).Value = txtCDPCondDePlata.Text;

                    // Incercam conexiunea si query-ul
                    try
                    {
                        conexiune_InserareCDP.Open();
                        int recordsAffected = comanda_InserareCDP.ExecuteNonQuery();
                    } // Captam eventualele erori
                    catch (OdbcException exInserare)
                    {
                        // Afisam eroarea driverului Odbc
                        MessageBox.Show(exInserare.Message);
                    } // Ne deconectam
                    finally
                    {
                        conexiune_InserareCDP.Close();
                    }
                }
            }

            // Actualizam "dgvConditiiDePlata"
            IncarcaredgvConditiiDePlata();

            // Golim campurile pentru introducerea datelor
            txtCDPNrCrt.Clear();
            txtCDPNumePrenProf.Clear();
            txtCDPDenDisciplina.Clear();
            txtCDPCondDePlata.Clear();
        }
        /* --------------------------------------------------------------------------------------------------------------- */
        /* -------------------- Metoda de tip "DELETE" pentru CDP -------------------------------------------------------- */
        private void btnCDPStergere_Click(object sender, EventArgs e)
        {
            // Metoda de stergere a datelor
            // Conexiunea
            using (OdbcConnection conexiune_StergereCDP = new OdbcConnection(sircon_RelIntDB))
            {           // Comanda
                using (OdbcCommand comanda_StergereCDP = new OdbcCommand())
                {
                    comanda_StergereCDP.Connection = conexiune_StergereCDP;
                    comanda_StergereCDP.CommandType = CommandType.Text;
                    comanda_StergereCDP.CommandText = "DELETE FROM conditiideplata WHERE nrcererecdp = ? AND nrcrtcdp = ?";
                    comanda_StergereCDP.Parameters.AddWithValue("@nrcererecdp", OdbcType.Int).Value = vartxtNrInregistrare;
                    comanda_StergereCDP.Parameters.AddWithValue("@nrcrtcdp", OdbcType.Int).Value = vartxtCDPNrCrtStergere;

                    // Incercam conexiunea si query-ul
                    try
                    {
                        conexiune_StergereCDP.Open();
                        int recordsAffected = comanda_StergereCDP.ExecuteNonQuery();
                    } // Captam eventualele erori
                    catch (OdbcException exInserare)
                    {
                        // Afisam eroarea driverului Odbc
                        MessageBox.Show(exInserare.Message);
                    } // Ne deconectam
                    finally
                    {
                        conexiune_StergereCDP.Close();
                    }
                }
            }

            // Actualizam "dgvConditiiDePlata"
            IncarcaredgvConditiiDePlata();

            // Golim campul "txtORNrCrtStergere"
            txtCDPNrCrtStergere.Clear();
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

        private void txtTara_TextChanged(object sender, EventArgs e)
        {
            // Daca textul selectat se schimba atunci
            txtTaraSchimbat = true;
        }

        private void txtScop_TextChanged(object sender, EventArgs e)
        {
            // Daca textul selectat se schimba atunci
            txtScopSchimbat = true;
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

        private void txtSuportatDe_TextChanged(object sender, EventArgs e)
        {
            // Daca textul selectat se schimba atunci
            txtSuportatDeSchimbat = true;
        }

        private void txtCheltuieliSuportate_TextChanged(object sender, EventArgs e)
        {
            // Daca textul selectat se schimba atunci
            txtCheltuieliSuportateSchimbat = true;
        }

        private void txtDiurna_TextChanged(object sender, EventArgs e)
        {
            // Daca textul selectat se schimba atunci
            txtDiurnaSchimbat = true;
        }

        private void txtCazare_TextChanged(object sender, EventArgs e)
        {
            // Daca textul selectat se schimba atunci
            txtCazareSchimbat = true;
        }

        private void txtTaxaDeParticipare_TextChanged(object sender, EventArgs e)
        {
            // Daca textul selectat se schimba atunci
            txtTaxaDeParticipareSchimbat = true;
        }

        private void txtTaxaDeViza_TextChanged(object sender, EventArgs e)
        {
            // Daca textul selectat se schimba atunci
            txtTaxaDeVizaSchimbat = true;
        }

        private void txtAmbasada_TextChanged(object sender, EventArgs e)
        {
            // Daca textul selectat se schimba atunci
            txtAmbasadaSchimbat = true;
        }

        private void txtDecan_TextChanged(object sender, EventArgs e)
        {
            // Daca textul selectat se schimba atunci
            txtDecanSchimbat = true;
        }

        private void txtVizaConta_TextChanged(object sender, EventArgs e)
        {
            // Daca textul selectat se schimba atunci
            txtVizaContaSchimbat = true;
        }

        private void txtAdministratorSef_TextChanged(object sender, EventArgs e)
        {
            // Daca textul selectat se schimba atunci
            txtAdministratorSefSchimbat = true;
        }

        private void txtSefDepartament_TextChanged(object sender, EventArgs e)
        {
            // Daca textul selectat se schimba atunci
            txtSefDepartamentSchimbat = true;
        }

        private void txtVizaRU_TextChanged(object sender, EventArgs e)
        {
            // Daca textul selectat se schimba atunci
            txtVizaRUSchimbat = true;
        }

        private void rdoPerNedeterminata_CheckedChanged(object sender, EventArgs e)
        {
            // Daca caseta este bifata atunci
            rdoPerNedeterminataBifat = true;
        }

        private void rdoPerDeterminata_CheckedChanged(object sender, EventArgs e)
        {
            // Daca caseta este bifata atunci
            rdoPerDeterminataBifat = true;
        }
        /* --------------------------------------------------------------------------------------------------------------- */


        







        /* ---------- Intrebam utilizatorul daca vrea sa salveze formularul cand actionam butonul "X" -------------------- */
        private void frmCerereInregistrare_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Executam verificarea starii de modificare a campurilor din formular
            CevaSchimbat();

            // Verificam daca a fost modificat vreun camp
            if (DacaCevaSchimbat == true)
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
                                                if (IesireDinProgram == true)
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
                        else if (IesireDinProgram == true)
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


// EOF si notite
// double varTaxaDeParticipare = txtTaxaDeParticipare.Text != string.Empty ? Double.Parse(txtTaxaDeParticipare.Text) : 0;