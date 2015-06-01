using System;
using System.Data;
using System.Data.Odbc;
using System.Windows.Forms;

namespace RelInt___Gestiune_cereri_de_deplasare
{
    public partial class frmSituatieDeplasari : Form
    {
        public frmSituatieDeplasari() // Metoda de LOAD
        {
            InitializeComponent();

            // Umplem urmatoarele combobox-uri
            UmplereScop();
            cmbRPScop.DropDownWidth = LatimeDropDown(cmbRPScop);
        }
        /* --------------------------------------------------------------------------------------------------------------- */






        /* ----------- Obiecte de lucru cu RelIntDB ---------------------------------------------------------------------- */
        // Sir de conectare al RelIntDB
        private string sircon_RelIntDB = "DSN=PostgreSQL35W;database=RelIntDB;server=localhost;port=5432;UID=postgres;PWD=12345;sslmode=disable;readonly=0;protocol=7.4;fakeoidindex=0;showoidcolumn=0;rowversioning=0;showsystemtables=0;fetch=100;socket=4096;unknownsizes=0;maxvarcharsize=255;maxlongvarcharsize=8190;debug=0;commlog=0;optimizer=0;ksqo=1;usedeclarefetch=0;textaslongvarchar=1;unknownsaslongvarchar=0;boolsaschar=1;parse=0;cancelasfreestmt=0;extrasystableprefixes=dd_;lfconversion=1;updatablecursors=1;disallowpremature=0;trueisminus1=0;bi=0;byteaaslongvarbinary=0;useserversideprepare=1;lowercaseidentifier=0;gssauthusegss=0;xaopt=1;";

        /* --------------------------------------------------------------------------------------------------------------- */






        /* ---------- Metoda de umplere a cmbScop cu date din RelIntDB --------------------------------------------------- */
        public void UmplereScop()
        {
            cmbRPScop.Items.Clear();
            using (OdbcConnection conexiune_cmbScop = new OdbcConnection(sircon_RelIntDB))
            {
                // Comanda
                using (OdbcCommand comanda_cmbScop = new OdbcCommand())
                {
                    comanda_cmbScop.Connection = conexiune_cmbScop;
                    comanda_cmbScop.CommandType = CommandType.Text;
                    comanda_cmbScop.CommandText = "SELECT * FROM scopuri";

                    OdbcDataReader cititor_cmbScop;

                    try
                    {
                        conexiune_cmbScop.Open();
                        cititor_cmbScop = comanda_cmbScop.ExecuteReader();
                        while (cititor_cmbScop.Read())
                        {
                            string str_cmbScop = cititor_cmbScop.GetString(0);
                            cmbRPScop.Items.Add(str_cmbScop);
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
        private int LatimeDropDown(ComboBox myCombo)
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







        /* ------------- Eveniment btnIesire ----------------------------------------------------------------------------- */
        private void btnIesire_Click(object sender, EventArgs e)
        {
            Close();
        }
        /* --------------------------------------------------------------------------------------------------------------- */







        /* -------------- Eveniment cmbRPScop ---------------------------------------------------------------------------- */
        private void cmbRPScop_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbRPScop.SelectedIndex != -1)
            {
                btnRPGenerare.Enabled = true;
            }
            else
            {
                btnRPGenerare.Enabled = false;
            }
        }
        /* --------------------------------------------------------------------------------------------------------------- */






        /* ------------ Eveniment btnRPGenerare -------------------------------------------------------------------------- */
        private void btnRPGenerare_Click(object sender, EventArgs e)
        {
            ExcelUtlity obj = new ExcelUtlity();
            DataTable dt = new DataTable();
            dt = GenerareTabel();
            if (dt.Rows.Count != 0)
            {
                obj.WriteDataTableToExcel(dt, "Detalii Persoane", "Detalii");
            }
            else
            {
                MessageBox.Show("Nu sunt date disponibile ce pot fi exportate după criteriile selectate.");
            }
        }
        /* --------------------------------------------------------------------------------------------------------------- */






        /* ----------------- DataTable ce foloseste la generarea excel-ului ---------------------------------------------- */
        public DataTable GenerareTabel()
        {
            DataTable dt = new DataTable();
            DataTable auxdt = new DataTable();
            using (OdbcConnection conexiune = new OdbcConnection(sircon_RelIntDB))
            {
                // Comanda
                using (OdbcCommand comanda = new OdbcCommand())
                {
                    comanda.Connection = conexiune;
                    comanda.CommandType = CommandType.Text;
                    comanda.CommandText = "SELECT nrinregistrareodc AS \"Nr. înregistrare (cereri)\", nrinregistrareod AS \"Nr. UAIC\", nrinregistrareodnou AS \"Nr. UAIC Nou\", dataod AS \"Data BECA\", dataodnoua AS \"Data BECA Nouă\", subsemnatulod AS \"Subsemnatul\", graddidacticod AS \"Grad didactic\", facultateaod AS \"Facultatea\", taraod AS \"Țara\", localitateaod AS \"Localitatea\", scopod AS \"Scop\", precizariscopod AS \"Precizări Scop\", institutiaod AS \"Instituția\", datainceputod AS \"Data început\", datasfarsitod AS \"Data sfârșit\", rutaod AS \"Ruta\", platitortranspod AS \"Plătitor transport\", platitorintretinereod AS \"Plătitor întreținere\", nrzilediurnaod AS \"Nr. zile diurnă\", diurnaod AS \"Diurnă\", monedadiurnaod AS \"Monedă diurnă\", nrzilecazareod AS \"Nr. zile cazare\", cazareod AS \"Cazare\", monedacazareod AS \"Monedă cazare\", taxadeparticipareod AS \"Taxă de participare\", monedataxadeparticipareod AS \"Monedă taxă de participare\", totalod AS \"Total\", numerpod AS \"Nume Rector/Prorector\", dfcod AS \"Director Financiar Contabil\", cpnumeprojod AS \"Nume Proiect\", cpgraddidacticod AS \"Grad didactic\", cpnumecoordod AS \"Nume coordonator proiect\" FROM ordinedeplasare WHERE scopod = ?";
                    comanda.Parameters.AddWithValue("@scopod", OdbcType.NVarChar).Value = cmbRPScop.SelectedItem;
                    
                    try
                    {
                        conexiune.Open();
                        dt.Load(comanda.ExecuteReader());

                        foreach (var c in dt.Columns)
                        {
                            auxdt.Columns.Add(c.ToString());
                        }

                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            if (dt.Rows[i].ItemArray[4].ToString() != "")
                            {
                                if (DateTime.Parse(dt.Rows[i].ItemArray[4].ToString()).Date >= dpRPDataInceput.Value.Date &&
                                    DateTime.Parse(dt.Rows[i].ItemArray[4].ToString()).Date <= dpRPDataSfarsit.Value.Date)
                                {
                                    if (auxdt.Rows.Count != 0)
                                    {
                                        for (int j = 0; j < auxdt.Rows.Count; j++)
                                        {
                                            if (auxdt.Rows[0].ItemArray[0] != dt.Rows[i].ItemArray[0])
                                            {
                                                auxdt.Rows.Add(dt.Rows[i].ItemArray);
                                                foreach (DataRow obj in auxdt.Rows)
                                                {
                                                    obj[3] = DateTime.Parse((obj[13].ToString())).ToShortDateString();
                                                    if (obj[4].ToString() != "")
                                                    {
                                                        obj[4] = DateTime.Parse((obj[4].ToString())).ToShortDateString();
                                                    }
                                                    obj[13] = DateTime.Parse((obj[13].ToString())).ToShortDateString();
                                                    obj[14] = DateTime.Parse((obj[14].ToString())).ToShortDateString();
                                                }
                                                break;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        auxdt.Rows.Add(dt.Rows[i].ItemArray);
                                    }
                                }
                            }
                            else
                            {
                                if (DateTime.Parse(dt.Rows[i].ItemArray[3].ToString()).Date >= dpRPDataInceput.Value.Date &&
                                    DateTime.Parse(dt.Rows[i].ItemArray[3].ToString()).Date <= dpRPDataSfarsit.Value.Date)
                                {
                                    if (auxdt.Rows.Count != 0)
                                    {
                                        for (int j = 0; j < auxdt.Rows.Count; j++)
                                        {
                                            if (auxdt.Rows[0].ItemArray[0] != dt.Rows[i].ItemArray[0])
                                            {
                                                auxdt.Rows.Add(dt.Rows[i].ItemArray);
                                                foreach (DataRow obj in auxdt.Rows)
                                                {
                                                    obj[3] = DateTime.Parse((obj[13].ToString())).ToShortDateString();
                                                    if (obj[4].ToString() != "")
                                                    {
                                                        obj[4] = DateTime.Parse((obj[4].ToString())).ToShortDateString();
                                                    }
                                                    obj[13] = DateTime.Parse((obj[13].ToString())).ToShortDateString();
                                                    obj[14] = DateTime.Parse((obj[14].ToString())).ToShortDateString();
                                                }
                                                break;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        auxdt.Rows.Add(dt.Rows[i].ItemArray);
                                    }
                                }
                            }
                        }
                    }
                    catch (Exception exceptie)
                    {
                        MessageBox.Show(exceptie.Message);
                    }
                    finally
                    {
                        conexiune.Close();
                    }
                }
            }
            return auxdt;
        }
        /* --------------------------------------------------------------------------------------------------------------- */






        /* -------------- Evenimentele: ---------------------------------------------------------------------------------- */
        private void dpRPDataInceput_ValueChanged(object sender, EventArgs e)
        {
            if (dpRPDataInceput.Value > dpRPDataSfarsit.Value)
            {
                lblAtenționare.Visible = true;
                btnRPGenerare.Enabled = false;
                cmbRPScop.Enabled = false;
            }
            else
            {
                lblAtenționare.Visible = false;
                btnRPGenerare.Enabled = true;
                cmbRPScop.Enabled = true;
            }
        }
        private void dpRPDataSfarsit_ValueChanged(object sender, EventArgs e)
        {
            if (dpRPDataSfarsit.Value < dpRPDataInceput.Value)
            {
                lblAtenționare.Visible = true;
                btnRPGenerare.Enabled = false;
                cmbRPScop.Enabled = false;
            }
            else
            {
                lblAtenționare.Visible = false;
                btnRPGenerare.Enabled = true;
                cmbRPScop.Enabled = true;
            }
        }
        /* --------------------------------------------------------------------------------------------------------------- */






    }
}
