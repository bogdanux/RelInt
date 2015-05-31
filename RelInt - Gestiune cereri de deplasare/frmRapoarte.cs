using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Odbc;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Windows.Forms.VisualStyles;
using MigraDoc.DocumentObjectModel.Shapes.Charts;

namespace RelInt___Gestiune_cereri_de_deplasare
{
    public partial class frmRapoarte : Form
    {
        public frmRapoarte() // Metoda de LOAD
        {
            InitializeComponent();

            // Umplem urmatoarele combobox-uri
            UmplereScop();
            cmbRPScop.DropDownWidth = LatimeDropDown(cmbRPScop);
        }
        /* --------------------------------------------------------------------------------------------------------------- */






        /* ----------- Obiecte de lucru cu RelIntDB ---------------------------------------------------------------------- */
        // Sir de conectare al RelIntDB
        string sircon_RelIntDB = "DSN=PostgreSQL35W;database=RelIntDB;server=localhost;port=5432;UID=postgres;PWD=12345;sslmode=disable;readonly=0;protocol=7.4;fakeoidindex=0;showoidcolumn=0;rowversioning=0;showsystemtables=0;fetch=100;socket=4096;unknownsizes=0;maxvarcharsize=255;maxlongvarcharsize=8190;debug=0;commlog=0;optimizer=0;ksqo=1;usedeclarefetch=0;textaslongvarchar=1;unknownsaslongvarchar=0;boolsaschar=1;parse=0;cancelasfreestmt=0;extrasystableprefixes=dd_;lfconversion=1;updatablecursors=1;disallowpremature=0;trueisminus1=0;bi=0;byteaaslongvarbinary=0;useserversideprepare=1;lowercaseidentifier=0;gssauthusegss=0;xaopt=1;";
        /* --------------------------------------------------------------------------------------------------------------- */






        /* ---------- Metoda de umplere a cmbScop cu date din RelIntDB --------------------------------------------------- */
        public void UmplereScop()
        {
            cmbRPScop.Items.Clear();
            using (OdbcConnection conexiune_cmbScop = new OdbcConnection(sircon_RelIntDB))
            {           // Comanda
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







        /* --------------------------------------------------------------------------------------------------------------- */
        private void btnIesire_Click(object sender, EventArgs e)
        {
            Close();
        }
        /* --------------------------------------------------------------------------------------------------------------- */







        /* --------------------------------------------------------------------------------------------------------------- */
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





        private Dictionary<string, string> IterarePrecizariScop()
        {
            Dictionary<string, string> nomenclatorDate = new Dictionary<string, string>();
            using (OdbcConnection conexiune = new OdbcConnection(sircon_RelIntDB))
            {           // Comanda
                using (OdbcCommand comanda = new OdbcCommand())
                {
                    comanda.Connection = conexiune;
                    comanda.CommandType = CommandType.Text;
                    comanda.CommandText = "SELECT dataod, dataodnoua, facultateaod, precizariscopod FROM ordinedeplasare WHERE scopod = ?";
                    comanda.Parameters.AddWithValue("@scopod", OdbcType.NVarChar).Value = cmbRPScop.SelectedItem;
                    
                    OdbcDataReader cititor;

                    try
                    {
                        conexiune.Open();
                        cititor = comanda.ExecuteReader();

                        foreach (Object obj in cititor)
                        {
                            if (cititor[1].ToString() == "")
                            {
                                if (cititor.GetDate(0).Date >= dpRPDataInceput.Value.Date && cititor.GetDate(0).Date <= dpRPDataSfarsit.Value.Date)
                                {
                                    if (nomenclatorDate.ContainsKey(cititor.GetValue(2).ToString()))
                                    {
                                        nomenclatorDate[cititor.GetValue(2).ToString()] =
                                            nomenclatorDate[cititor.GetValue(2).ToString()] + "*" +
                                            cititor.GetValue(3).ToString();

                                    }
                                    else
                                    {
                                        nomenclatorDate.Add(cititor.GetValue(2).ToString(), cititor.GetValue(3).ToString());
                                    }
                                }
                            }
                            else
                            {
                                if (cititor.GetDate(1).Date >= dpRPDataInceput.Value.Date && cititor.GetDate(1).Date <= dpRPDataSfarsit.Value.Date)
                                {
                                    if (nomenclatorDate.ContainsKey(cititor.GetValue(2).ToString()))
                                    {
                                        nomenclatorDate[cititor.GetValue(2).ToString()] =
                                            nomenclatorDate[cititor.GetValue(2).ToString()] + "*" +
                                            cititor.GetValue(3).ToString();

                                    }
                                    else
                                    {
                                        nomenclatorDate.Add(cititor.GetValue(2).ToString(), cititor.GetValue(3).ToString());
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

                    return nomenclatorDate;
                }
            }
        }





        private void btnRPGenerare_Click(object sender, EventArgs e)
        {
            Dictionary<string, string> nomenclatorDate = new Dictionary<string, string>();
            nomenclatorDate = IterarePrecizariScop();
            int i = 0;

            Dictionary<string, List<int>> grafic = new Dictionary<string, List<int>>();

            List<string> series = new List<string>();
            series = GenereazaSerii(nomenclatorDate);

            foreach (var s in series)
            {
                chart1.Series.Add(s);
            }

            foreach (var nom in nomenclatorDate)
            {
                if (nom.Value.Contains("*"))
                {
                    Dictionary<string, int> dictionary = new Dictionary<string, int>();
                    dictionary = NumarareAparitiiSerii(nom.Value);
                    
                    List<int> aparitii = new List<int>();
                    aparitii = GenereazaAparitiiValMultiple(series, dictionary);

                    grafic.Add(nom.Key,aparitii);

                }
                else
                {
                    List<int> aparitii = new List<int>();
                    aparitii = GenereazaAparitiiValSingulare(series, nom.Value);
                    
                    grafic.Add(nom.Key, aparitii);
                }
            }

            foreach (var pereche in grafic)
            {
                foreach (var s in series)
                {
                    foreach (var p in pereche.Value)
                    {
                        chart1.Series[s].Points.AddY(p);
                        pereche.Value.Remove(p);
                        break;
                    }
                }
            }

            foreach (var pereche in grafic)
            {
                chart1.Series[series[0]].Points[i].AxisLabel = pereche.Key;
                i++;
            }

            for (int j = 0; j < series.Count(); j++)
            {
                chart1.Series[series[j]].ChartType = SeriesChartType.StackedColumn;
            }
        }


        public List<string> GenereazaSerii(Dictionary<string, string> nomenclatorDate)
        {
            List<string> series = new List<string>();
            foreach (var pereche in nomenclatorDate)
            {
                if (pereche.Value.Contains("*"))
                {
                    string[] words = pereche.Value.Split('*');

                    foreach (var word in words)
                    {
                        if (!series.Contains(word))
                        {
                            series.Add(word);
                        }
                    }
                }
                else
                {
                    if (!series.Contains(pereche.Value))
                    {
                        series.Add(pereche.Value);
                    }
                }
            }

            return series;
        }

        public Dictionary<string, int> NumarareAparitiiSerii(string nomValoare)
        {
            Dictionary<string, int> dictionary = new Dictionary<string, int>();

            string[] words = nomValoare.Split('*');

            foreach (var w in words)
            {
                if (dictionary.ContainsKey(w))
                {
                    dictionary[w] = dictionary[w] + 1;
                }
                else
                {
                    dictionary.Add(w, 1);
                }
            }

            return dictionary;

        }

        public List<int> GenereazaAparitiiValMultiple(List<string> series, Dictionary<string, int> dictionary)
        {
            List<int> aparitii = new List<int>();

            foreach (var s in series)
            {
                bool ok = false;
                foreach (var d in dictionary)
                {
                    if (s == d.Key)
                    {
                        aparitii.Add(d.Value);
                        dictionary.Remove(d.Key);
                        ok = true;
                        break;

                    }
                    else
                    {
                        aparitii.Add(0);
                        break;
                    }
                }
                if (dictionary.Count() == 0 && ok == false)
                {
                    aparitii.Add(0);
                }
            }

            return aparitii;
        }

        public List<int> GenereazaAparitiiValSingulare(List<string> series, string valoare)
        {
            List<int> aparitii = new List<int>();

            foreach (var s in series)
            {
                bool ok = false;

                if (s == valoare)
                {
                    aparitii.Add(1);

                }
                else
                {
                    aparitii.Add(0);
                }
            }

            return aparitii;
        }







    }
}
