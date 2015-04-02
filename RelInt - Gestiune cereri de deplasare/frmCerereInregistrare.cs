using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Odbc;

namespace RelInt___Gestiune_cereri_de_deplasare
{
    public partial class frmCerereInregistrare: Form
    {
        public frmCerereInregistrare()
        {
            InitializeComponent();

            /* ------------ Initializam Combobox-urile cu primele lor valori din colectii ------------------------------------ */
            //cmbGradDidactic.SelectedIndex = 0;
            //cmbFacultatea.SelectedIndex = 0;
            cmbMoneda1.SelectedIndex = 0;
            cmbMoneda2.SelectedIndex = 0;
            cmbMoneda3.SelectedIndex = 0;
            /* --------------------------------------------------------------------------------------------------------------- */

            // Dezactivam checkbox-ul "chkORCDP"
            chkORCDP.Enabled = false;

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
                txtORData.Enabled = false;
                txtOROra.Enabled = false;
                txtORSala.Enabled = false;
                btnORInserare.Enabled = false;

                // Dezctivam campurile si butonul pentru stergerea datelor (OR)
                txtORNrCrtStergere.Enabled = false;
                btnORStergere.Enabled = false;

                    // Dezactivam campurile si butonul pentru introducerea datelor (CDP)
                    txtCDPNrCrtOR.Enabled = false;
                    txtCDPNrCrt.Enabled = false;
                    txtCDPNumePrenProf.Enabled = false;
                    txtCDPDenDisciplina.Enabled = false;
                    txtCDPCondDePlata.Enabled = false;
                    btnCDPIntroducere.Enabled = false;
        }


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
        bool CalculTotalSucces = false;

        /* --------------------------------------------------------------------------------------------------------------- */









        /* ---------- Inchidere formular cand actiunam "iesire" din meniul formularului ---------------------------------- */
        private void btnCIIesire_Click(object sender, EventArgs e)
        {
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

            // Activam/Dezactivam caseta "chkORCDP"
            activarecheckORCDP();
        }
        /* --------------------------------------------------------------------------------------------------------------- */










        /* ----------- Metoda activate/dezactivare a "chkORCDP" in functie de txtNrInregistrare -------------------------- */
        public void activarecheckORCDP()
        {
            if (txtNrInregistrare.Text == string.Empty)
            {
                chkORCDP.Enabled = false;
            }
            else
            {
                chkORCDP.Enabled = true;
            }
            return;
        }
        /* --------------------------------------------------------------------------------------------------------------- */




        




        /* ----------------- Metoda calcularii totalului din textbox-ul "txtTotalDePlata" -------------------------------- */
        private void CalculTotal()
        {
            // Verificam daca formularul a fost completat cu o valuta unica
            if (cmbMoneda1.SelectedItem == cmbMoneda2.SelectedItem && cmbMoneda2.SelectedItem == cmbMoneda3.SelectedItem)
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
                    comanda_inserareRelInt.CommandText = "INSERT into Cereri VALUES (?, ?, ?, ?, ?, ?, ?, ? ,?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ? ,?, ?, ?, ?, ?, ?, ?, ? ,? ,?)";
                    comanda_inserareRelInt.Parameters.Add("@nrinregistrarec", OdbcType.Int).Value = vartxtNrInregistrare;
                    comanda_inserareRelInt.Parameters.Add("@datac", OdbcType.DateTime).Value = dpDataFormular.Value;
                    comanda_inserareRelInt.Parameters.Add("@subsemnatulc", OdbcType.NVarChar).Value = txtSubsemnatul.Text;
                    comanda_inserareRelInt.Parameters.Add("@graddidacticc", OdbcType.NVarChar).Value = cmbGradDidactic.SelectedItem;
                    comanda_inserareRelInt.Parameters.Add("@facultateac", OdbcType.NVarChar).Value = cmbFacultatea.SelectedItem;
                    comanda_inserareRelInt.Parameters.Add("@departamentulc", OdbcType.NVarChar).Value = txtDepartament.Text;
                    comanda_inserareRelInt.Parameters.Add("@localitateac", OdbcType.NVarChar).Value = txtLocalitatea.Text;
                    comanda_inserareRelInt.Parameters.Add("@tarac", OdbcType.NVarChar).Value = txtTara.Text;
                    comanda_inserareRelInt.Parameters.Add("@scopc", OdbcType.NVarChar).Value = txtScop.Text;
                    comanda_inserareRelInt.Parameters.Add("@institutiac", OdbcType.NVarChar).Value = txtInstitutia.Text;
                    comanda_inserareRelInt.Parameters.Add("@datainceputc", OdbcType.DateTime).Value = dpDataInceput.Value;
                    comanda_inserareRelInt.Parameters.Add("@datasfarsitc", OdbcType.DateTime).Value = dpDataSfarsit.Value;
                    comanda_inserareRelInt.Parameters.Add("@rutac", OdbcType.NVarChar).Value = txtRuta.Text;
                    comanda_inserareRelInt.Parameters.Add("@mijtransc", OdbcType.NVarChar).Value = txtMijTrans.Text;
                    comanda_inserareRelInt.Parameters.Add("@platitortranspc", OdbcType.NVarChar).Value = txtSuportatDe.Text;
                    comanda_inserareRelInt.Parameters.Add("@platitorintretinerec", OdbcType.NVarChar).Value = txtCheltuieliSuportate.Text;
                    comanda_inserareRelInt.Parameters.Add("@diurnac", OdbcType.Double).Value = varDiurna;
                    comanda_inserareRelInt.Parameters.Add("@cazarecc", OdbcType.Double).Value = varCazare;
                    comanda_inserareRelInt.Parameters.Add("@taxadeparticiparec", OdbcType.Double).Value = varTaxaDeParticipare;
                    comanda_inserareRelInt.Parameters.Add("@taxadevizaetcc", OdbcType.Double).Value = varTaxaDeVizaEtc;
                    comanda_inserareRelInt.Parameters.Add("@totalc", OdbcType.Double).Value = varTotalDePlata;
                    comanda_inserareRelInt.Parameters.Add("@ambasadac", OdbcType.NVarChar).Value = txtAmbasada.Text;
                    comanda_inserareRelInt.Parameters.Add("@nedeterminatac", OdbcType.Bit).Value = rdoPerNedeterminata.Checked;
                    comanda_inserareRelInt.Parameters.Add("@determinatac", OdbcType.Bit).Value = rdoPerDeterminata.Checked;
                    comanda_inserareRelInt.Parameters.Add("@decanc", OdbcType.NVarChar).Value = txtDecan.Text;
                    comanda_inserareRelInt.Parameters.Add("@vizacontac", OdbcType.NVarChar).Value = txtVizaConta.Text;
                    comanda_inserareRelInt.Parameters.Add("@admsebirouc", OdbcType.NVarChar).Value = txtAdministratorSef.Text;
                    comanda_inserareRelInt.Parameters.Add("@sefdepartamentdirc", OdbcType.NVarChar).Value = txtSefDepartament.Text;
                    comanda_inserareRelInt.Parameters.Add("@vizaruc", OdbcType.NVarChar).Value = txtVizaRU.Text;


                    // Incercam conexiunea si query-ul
                    try
                    {
                        conexiune_InserareCerereRelInt.Open();
                        int recordsAffected = comanda_inserareRelInt.ExecuteNonQuery();
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









        


        /* ----------- Actiunea de salvare a formularului ---------------------------------------------------------------- */
        private void btnCISalvareFormular_Click(object sender, EventArgs e)
        {
            // Executa urmatoarele
            CalculTotal();

            if (CalculTotalSucces == true)
                {
                    MetodaInserareDB();
                }
        }
        /* --------------------------------------------------------------------------------------------------------------- */









        /* ---------- Intrebam utilizatorul daca vrea sa salveze formularul cand actionam butonul "X" -------------------- */
        private void frmCerereIntroducere_Load(object sender, EventArgs e)
        {
            // Prompt salvare
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
                    comanda_dgvOreRecuperate.CommandText = "SELECT nrcrtor as \"Nr. Crt.\", denumiredisciplinaor as \"Denumire Disciplina\", dataor as \"Data\", oraor as \"Ora\", salaor as \"Sala\" FROM orerecuperate WHERE nrinregistrarecor = ?";
                    comanda_dgvOreRecuperate.Parameters.Add("@nrinregistrarecor", OdbcType.Int).Value = vartxtNrInregistrare;

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
                    comanda_dgvOreRecuperate.CommandText = "SELECT nrcrtor as \"Nr. Crt.\", denumiredisciplinaor as \"Denumire Disciplina\", dataor as \"Data\", oraor as \"Ora\", salaor as \"Sala\" FROM orerecuperate WHERE nrinregistrarecor = ?";
                    comanda_dgvOreRecuperate.Parameters.Add("@nrinregistrarecor", OdbcType.Int).Value = vartxtNrInregistrare;

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
        /* ------------------ Inserare in tabela "orerecuperate" prin "dgvOreRecuperate" --------------------------------- */
        private void dgvOreRecuperate_RowLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvOreRecuperate.IsCurrentRowDirty == true)
            {
                using (OdbcConnection conexiune_InserareOreRecuperate = new OdbcConnection(sircon_RelIntDB))
                {           // Comanda
                    using (OdbcCommand comanda_InserareOreRecuperate = new OdbcCommand())
                    {
                        for (int i = 0; i < dgvOreRecuperate.Rows.Count; i++)
                        {
                            // Dezactivam prima celula din "dgvOreRecuperate"
                            dgvOreRecuperate.Rows[i].Cells[0].ReadOnly = true;

                            comanda_InserareOreRecuperate.Connection = conexiune_InserareOreRecuperate;
                            comanda_InserareOreRecuperate.CommandType = CommandType.Text;
                            comanda_InserareOreRecuperate.CommandText = "INSERT into orerecuperate VALUES (?, ?, ?, ?, ?, ?)";
                            comanda_InserareOreRecuperate.Parameters.Add("@nrinregistrarec", OdbcType.Int).Value = vartxtNrInregistrare;
                            comanda_InserareOreRecuperate.Parameters.Add("@nrcrtor", OdbcType.Int).Value = dgvOreRecuperate.Rows[i].Cells[1].Value;
                            comanda_InserareOreRecuperate.Parameters.Add("@denumiredisciplinaor", OdbcType.NVarChar).Value = dgvOreRecuperate.Rows[i].Cells[2].Value;
                            comanda_InserareOreRecuperate.Parameters.Add("@dataor", OdbcType.DateTime).Value = dgvOreRecuperate.Rows[i].Cells[3].Value;
                            comanda_InserareOreRecuperate.Parameters.Add("@oraor", OdbcType.DateTime).Value = dgvOreRecuperate.Rows[i].Cells[4].Value;
                            comanda_InserareOreRecuperate.Parameters.Add("@salaor", OdbcType.NVarChar).Value = dgvOreRecuperate.Rows[i].Cells[5].Value;
                            // Incercam conexiunea si query-ul
                            try
                            {
                                conexiune_InserareOreRecuperate.Open();
                            } // Captam eventualele erori
                            catch (OdbcException exInserare)
                            {
                                // Afisam eroarea driverului Odbc
                                MessageBox.Show(exInserare.Message);
                            } // Ne deconectam
                            finally
                            {
                                conexiune_InserareOreRecuperate.Close();
                            }
                        }
                    }
                }
            }
            else
            {
                // Nu fa nimic
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
                    comanda_dgvConditiiDePlata.CommandText = "SELECT nrcrtorcdp as \"Nr. Crt. O-R\", nrcrtcdp as \"Nr. Crt.\", numeprenprofcdp as \"Nume Prenume prof.\", denumiredisciplinacdp as \"Denumire Disciplina\", conditiideplatacdp as \"Conditii de plata\" FROM conditiideplata";

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
                    comanda_dgvConditiiDePlata.CommandText = "SELECT nrcrtorcdp as \"Nr. Crt. O-R\", nrcrtcdp as \"Nr. Crt.\", numeprenprofcdp as \"Nume Prenume prof.\", denumiredisciplinacdp as \"Denumire Disciplina\", conditiideplatacdp as \"Conditii de plata\" FROM conditiideplata";

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
        /* ------------------ Inserare in tabela "conditiideplata" prin "dgvConditiiDePlata" ----------------------------- */
        private void dgvConditiiDePlata_RowDirtyStateNeeded(object sender, System.Windows.Forms.QuestionEventArgs e)
        {
            //if (!rowScopeCommit)
            //{
            //    // In cell-level commit scope, indicate whether the value 
            //    // of the current cell has been modified.
            //    e.Response = this.dgvConditiiDePlata.IsCurrentCellDirty;
            //}
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
                                txtORData.Clear();
                                txtOROra.Clear();
                                txtORSala.Clear();

                                // Dezactivam campurile si butonul pentru introducerea datelor (OR)
                                txtORNrCrt.Enabled = false;
                                txtORDenDisciplina.Enabled = false;
                                txtORData.Enabled = false;
                                txtOROra.Enabled = false;
                                txtORSala.Enabled = false;
                                btnORInserare.Enabled = false;

                                // Stergem tot din campurile pentru stergerea datelor (OR)
                                txtORNrCrtStergere.Clear();

                                // Dezactivam campurile si butonul pentru stergerea datelor (OR)
                                txtORNrCrtStergere.Enabled = false;
                                btnORStergere.Enabled = false;

                                    // Stergem tot din campurile pentru introducerea datelor (CDP)
                                    txtCDPNrCrtOR.Clear();
                                    txtCDPNrCrt.Clear();
                                    txtCDPNumePrenProf.Clear();
                                    txtCDPDenDisciplina.Clear();
                                    txtCDPCondDePlata.Clear();

                                    // Dezactivam campurile si butonul pentru introducerea datelor (CDP)
                                    txtCDPNrCrtOR.Enabled = false;
                                    txtCDPNrCrt.Enabled = false;
                                    txtCDPNumePrenProf.Enabled = false;
                                    txtCDPDenDisciplina.Enabled = false;
                                    txtCDPCondDePlata.Enabled = false;
                                    btnCDPIntroducere.Enabled = false;

                                    // Stergem tot din campurile pentru stergerea datelor (CDP)
                                    txtCDPNrCrtOR.Clear();

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
                    txtORData.Enabled = true;
                    txtOROra.Enabled = true;
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
                    txtORData.Clear();
                    txtOROra.Clear();
                    txtORSala.Clear();

                    // Dezactivam campurile si butonul pentru introducerea datelor
                    txtORNrCrt.Enabled = false;
                    txtORDenDisciplina.Enabled = false;
                    txtORData.Enabled = false;
                    txtOROra.Enabled = false;
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
                    txtCDPNrCrtOR.Enabled = true;
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
                    txtCDPNrCrtOR.Clear();
                    txtCDPNrCrt.Clear();
                    txtCDPNumePrenProf.Clear();
                    txtCDPDenDisciplina.Clear();
                    txtCDPCondDePlata.Clear();

                    // Dezactivam campurile si butonul pentru introducerea datelor
                    txtCDPNrCrtOR.Enabled = false;
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
                    txtCDPNrCrtOR.Clear();

                    // Dezactivam campurile si butonul pentru stergerea datelor
                    txtCDPNrCrtStergere.Enabled = false;
                    btnCDPStergere.Enabled = false;
                }
            }
        }
        /* --------------------------------------------------------------------------------------------------------------- */










    }
}


// EOF si notite
// double varTaxaDeParticipare = txtTaxaDeParticipare.Text != string.Empty ? Double.Parse(txtTaxaDeParticipare.Text) : 0;