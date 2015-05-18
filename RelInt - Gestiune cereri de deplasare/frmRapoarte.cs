using System;
using System.Data;
using System.Data.Odbc;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace RelInt___Gestiune_cereri_de_deplasare
{
    public partial class frmRapoarte : Form
    {
        public frmRapoarte() // Metoda de LOAD
        {
            InitializeComponent();
        }
        /* --------------------------------------------------------------------------------------------------------------- */






        /* ----------- Obiecte de lucru cu RelIntDB ---------------------------------------------------------------------- */
        // Sir de conectare al RelIntDB
        string sircon_RelIntDB = "DSN=PostgreSQL35W;database=RelIntDB;server=localhost;port=5432;UID=postgres;PWD=12345;sslmode=disable;readonly=0;protocol=7.4;fakeoidindex=0;showoidcolumn=0;rowversioning=0;showsystemtables=0;fetch=100;socket=4096;unknownsizes=0;maxvarcharsize=255;maxlongvarcharsize=8190;debug=0;commlog=0;optimizer=0;ksqo=1;usedeclarefetch=0;textaslongvarchar=1;unknownsaslongvarchar=0;boolsaschar=1;parse=0;cancelasfreestmt=0;extrasystableprefixes=dd_;lfconversion=1;updatablecursors=1;disallowpremature=0;trueisminus1=0;bi=0;byteaaslongvarbinary=0;useserversideprepare=1;lowercaseidentifier=0;gssauthusegss=0;xaopt=1;";
        /* --------------------------------------------------------------------------------------------------------------- */







        /* --------------------------------------------------------------------------------------------------------------- */
        private void btnIesire_Click(object sender, EventArgs e)
        {
            Close();
        }
        /* --------------------------------------------------------------------------------------------------------------- */







        /* ----------------- Metoda de incarcare a cmbRCConditie --------------------------------------------------------- */
        private void MetodaIncarcareConditieRC(string ce, string deunde, Int32 an)
        {
            // Definim vector pentru ani
            Int32[] vectorAni = new Int32[16] { 2015, 2016, 2017, 2018, 2019, 2020, 2021, 2022, 2023, 2024, 2025, 2026, 2027, 2028, 2029, 2030 };

            if (ce == string.Empty && deunde == string.Empty && an != 0)
            {
                foreach (var element in vectorAni)
                {
                    cmbRCConditia.Enabled = true;
                    cmbRCConditia.Items.Add(element);
                }
            }

            else if (ce != string.Empty && deunde != string.Empty && an == 0)
            {

                using (OdbcConnection conexiune_cmbRCConditie = new OdbcConnection(sircon_RelIntDB))
                {
                    // Comanda
                    using (OdbcCommand comanda_cmbRCConditie = new OdbcCommand())
                    {
                        comanda_cmbRCConditie.Connection = conexiune_cmbRCConditie;
                        comanda_cmbRCConditie.CommandType = CommandType.Text;
                        comanda_cmbRCConditie.CommandText = "SELECT " + ce + " FROM " + deunde;

                        OdbcDataReader cititor_cmbRCConditia;

                        try
                        {
                            conexiune_cmbRCConditie.Open();
                            cititor_cmbRCConditia = comanda_cmbRCConditie.ExecuteReader();

                            if (cititor_cmbRCConditia.HasRows)
                            {
                                // Activam
                                cmbRCConditia.Enabled = true;

                                // Afisam
                                while (cititor_cmbRCConditia.Read())
                                {
                                    string str_cmbRCConditia = cititor_cmbRCConditia.GetString(0);

                                    switch (ce)
                                    {
                                        case "facultatif":
                                            cmbRCConditia.Items.Add(str_cmbRCConditia);
                                            break;

                                        case "graddidacticgd":
                                            cmbRCConditia.Items.Add(str_cmbRCConditia);
                                            break;

                                        case "tarit":
                                            cmbRCConditia.Items.Add(str_cmbRCConditia);
                                            break;

                                        case "scopuris":
                                            cmbRCConditia.Items.Add(str_cmbRCConditia);
                                            break;

                                        default:
                                            cmbRCConditia.Items.Clear();
                                            break;
                                    }
                                }
                            }
                        }
                        catch (Exception excmbRCConditie)
                        {
                            MessageBox.Show(excmbRCConditie.Message);
                        } // Ne deconectam
                        finally
                        {
                            conexiune_cmbRCConditie.Close();
                        }
                    }
                }
            }
        }
        /* --------------------------------------------------------------------------------------------------------------- */
        /* --------------- Eveniment al cmbRCAsupra ---------------------------------------------------------------------- */
        private void cmbRCAsupra_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cmbRCAsupra.SelectedItem.ToString())
            {
                case "Facultate":
                    cmbRCConditia.Items.Clear();
                    MetodaIncarcareConditieRC("facultatif", "facultati", 0);
                    break;

                case "Grad didactic":
                    cmbRCConditia.Items.Clear();
                    MetodaIncarcareConditieRC("graddidacticgd", "gradedidactice", 0);
                    break;

                case "Țară":
                    cmbRCConditia.Items.Clear();
                    MetodaIncarcareConditieRC("tarit", "tari", 0);
                    break;

                case "Scop":
                    cmbRCConditia.Items.Clear();
                    MetodaIncarcareConditieRC("scopuris", "scopuri", 0);
                    break;

                case "An":
                    cmbRCConditia.Items.Clear();
                    MetodaIncarcareConditieRC(string.Empty, string.Empty, 1);
                    break;
            }
        }
        /* --------------------------------------------------------------------------------------------------------------- */
        /* --------------- Eveniment al cmbRCConditia -------------------------------------------------------------------- */
        private void cmbRCConditia_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbRCConditia.SelectedIndex != -1)
            {
                btnRCAfiseaza.Enabled = true;
            }
        }
        /* --------------------------------------------------------------------------------------------------------------- */







        /* ----------------- Metoda de incarcare a cmbRCConditie --------------------------------------------------------- */
        private void MetodaIncarcareConditieRODD(string ce, string deunde, Int32 an)
        {
            // Definim vector pentru ani
            Int32[] vectorAni = new Int32[16] { 2015, 2016, 2017, 2018, 2019, 2020, 2021, 2022, 2023, 2024, 2025, 2026, 2027, 2028, 2029, 2030 };

            if (ce == string.Empty && deunde == string.Empty && an != 0)
            {
                foreach (var element in vectorAni)
                {
                    cmbRODDConditia.Enabled = true;
                    cmbRODDConditia.Items.Add(element);
                }
            }

            else if (ce != string.Empty && deunde != string.Empty && an == 0)
            {

                using (OdbcConnection conexiune_cmbRODDConditie = new OdbcConnection(sircon_RelIntDB))
                {
                    // Comanda
                    using (OdbcCommand comanda_cmbRODDConditie = new OdbcCommand())
                    {
                        comanda_cmbRODDConditie.Connection = conexiune_cmbRODDConditie;
                        comanda_cmbRODDConditie.CommandType = CommandType.Text;
                        comanda_cmbRODDConditie.CommandText = "SELECT " + ce + " FROM " + deunde;

                        OdbcDataReader cititor_cmbRODDConditia;

                        try
                        {
                            conexiune_cmbRODDConditie.Open();
                            cititor_cmbRODDConditia = comanda_cmbRODDConditie.ExecuteReader();

                            if (cititor_cmbRODDConditia.HasRows)
                            {
                                // Activam
                                cmbRODDConditia.Enabled = true;

                                // Afisam
                                while (cititor_cmbRODDConditia.Read())
                                {
                                    string str_cmbRODDConditia = cititor_cmbRODDConditia.GetString(0);

                                    switch (ce)
                                    {
                                        case "facultatif":
                                            cmbRODDConditia.Items.Add(str_cmbRODDConditia);
                                            break;

                                        case "graddidacticgd":
                                            cmbRODDConditia.Items.Add(str_cmbRODDConditia);
                                            break;

                                        case "tarit":
                                            cmbRODDConditia.Items.Add(str_cmbRODDConditia);
                                            break;

                                        case "scopuris":
                                            cmbRODDConditia.Items.Add(str_cmbRODDConditia);
                                            break;

                                        default:
                                            cmbRODDConditia.Items.Clear();
                                            break;
                                    }
                                }
                            }
                        }
                        catch (Exception excmbRODDConditie)
                        {
                            MessageBox.Show(excmbRODDConditie.Message);
                        } // Ne deconectam
                        finally
                        {
                            conexiune_cmbRODDConditie.Close();
                        }
                    }
                }
            }
        }
        /* --------------------------------------------------------------------------------------------------------------- */
        /* --------------- Eveniment al cmbRCAsupra ---------------------------------------------------------------------- */
        private void cmbRODDAsupra_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cmbRODDAsupra.SelectedItem.ToString())
            {
                case "Facultate":
                    cmbRODDConditia.Items.Clear();
                    MetodaIncarcareConditieRODD("facultatif", "facultati", 0);
                    break;

                case "Grad didactic":
                    cmbRODDConditia.Items.Clear();
                    MetodaIncarcareConditieRODD("graddidacticgd", "gradedidactice", 0);
                    break;

                case "Țară":
                    cmbRODDConditia.Items.Clear();
                    MetodaIncarcareConditieRODD("tarit", "tari", 0);
                    break;

                case "Scop":
                    cmbRODDConditia.Items.Clear();
                    MetodaIncarcareConditieRODD("scopuris", "scopuri", 0);
                    break;

                case "An":
                    cmbRODDConditia.Items.Clear();
                    MetodaIncarcareConditieRODD(string.Empty, string.Empty, 1);
                    break;
            }
        }
        /* --------------------------------------------------------------------------------------------------------------- */
        /* --------------- Eveniment al cmbRCConditia -------------------------------------------------------------------- */
        private void cmbRODDConditia_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbRODDConditia.SelectedIndex != -1)
            {
                btnRODDAfiseaza.Enabled = true;
            }
        }
        /* --------------------------------------------------------------------------------------------------------------- */




    }
}
