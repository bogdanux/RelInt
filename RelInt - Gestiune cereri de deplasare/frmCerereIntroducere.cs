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
        }


        /* ----------- Obiecte de lucru cu RelIntDB ---------------------------------------------------------------------- */
        // Sir de conectare al RelIntDB
        string sircon_RelIntDB = "DSN=PostgreSQL35W;database=RelIntDB;server=localhost;port=5432;UID=postgres;PWD=12345;sslmode=disable;readonly=0;protocol=7.4;fakeoidindex=0;showoidcolumn=0;rowversioning=0;showsystemtables=0;fetch=100;socket=4096;unknownsizes=0;maxvarcharsize=255;maxlongvarcharsize=8190;debug=0;commlog=0;optimizer=0;ksqo=1;usedeclarefetch=0;textaslongvarchar=1;unknownsaslongvarchar=0;boolsaschar=1;parse=0;cancelasfreestmt=0;extrasystableprefixes=dd_;lfconversion=1;updatablecursors=1;disallowpremature=0;trueisminus1=0;bi=0;byteaaslongvarbinary=0;useserversideprepare=1;lowercaseidentifier=0;gssauthusegss=0;xaopt=1;";
        // Conexiune la RelIntDB

        
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
            using (OdbcConnection conexiune_RelInt = new OdbcConnection(sircon_RelIntDB))
            {           // Comanda
                using (OdbcCommand comanda_inserareRelInt = new OdbcCommand())
                {
                    comanda_inserareRelInt.Connection = conexiune_RelInt;
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
                        conexiune_RelInt.Open();
                        int recordsAffected = comanda_inserareRelInt.ExecuteNonQuery();
                    } // Captam eventualele erori
                    catch (OdbcException exInserare)
                    {
                        // Afisam eroarea driverului Odbc
                        MessageBox.Show(exInserare.Message);
                    } // Ne deconectam
                    /*finally
                    {
                        conexiune_RelInt.Close();
                    }*/
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
                    // Apelam formularul "frmCerereModificare"
                    Form frmCerereModificare = new frmCerereModificare();

                    // Facem "frmCerereModificare "copil al "frmGCD"
                    frmCerereModificare.MdiParent = this.MdiParent;

                    foreach (Form form in Application.OpenForms)
                    {
                        if (form.GetType() == typeof(frmCerereModificare))
                        {
                            form.WindowState = FormWindowState.Normal;
                            form.Activate();
                            return;
                        }
                    }

                    // Afisam "frmCerereModificare"
                    frmCerereModificare.Show();
                }
        }
        /* --------------------------------------------------------------------------------------------------------------- */









        /* ---------- Intrebam utilizatorul daca vrea sa salveze formularul cand actionam butonul "X" -------------------- */
        private void frmCerereIntroducere_Load(object sender, EventArgs e)
        {
            // Prompt salvare
        }
        /* --------------------------------------------------------------------------------------------------------------- */











        /* ---------- Inchidere formular cand actiunam "iesire" din meniul formularului ---------------------------------- */
        private void btnCIIesire_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /* --------------------------------------------------------------------------------------------------------------- */








        /* ------------ Metoda pentru checkbox "chkORCDP" ---------------------------------------------------------------- */
        private void chkORCDP_CheckedChanged(object sender, EventArgs e)
        {
            // Apelam validarea chkORCDP
            if (chkORCDP.Checked == true)
            {
                txtNrInregistrare.Enabled = false;
            }
            else
            {
                txtNrInregistrare.Enabled = true;
            }
        }
        /* --------------------------------------------------------------------------------------------------------------- */







    }
}


// EOF si notite
// double varTaxaDeParticipare = txtTaxaDeParticipare.Text != string.Empty ? Double.Parse(txtTaxaDeParticipare.Text) : 0;