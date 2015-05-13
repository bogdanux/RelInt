using System;
using System.Data;
using System.Data.Odbc;
using System.Windows.Forms;

namespace RelInt___Gestiune_cereri_de_deplasare
{
    public partial class frmListaODDExistente : Form
    {
        public frmListaODDExistente() // Metoda de LOAD
        {
            InitializeComponent();

            // Apelam metoda de populare
            PopularedgvVizualizareTot();
        }
        /* --------------------------------------------------------------------------------------------------------------- */





        /* ----------- Obiecte de lucru cu RelIntDB ---------------------------------------------------------------------- */
        // Sir de conectare al RelIntDB
        string sircon_RelIntDB = "DSN=PostgreSQL35W;database=RelIntDB;server=localhost;port=5432;UID=postgres;PWD=12345;sslmode=disable;readonly=0;protocol=7.4;fakeoidindex=0;showoidcolumn=0;rowversioning=0;showsystemtables=0;fetch=100;socket=4096;unknownsizes=0;maxvarcharsize=255;maxlongvarcharsize=8190;debug=0;commlog=0;optimizer=0;ksqo=1;usedeclarefetch=0;textaslongvarchar=1;unknownsaslongvarchar=0;boolsaschar=1;parse=0;cancelasfreestmt=0;extrasystableprefixes=dd_;lfconversion=1;updatablecursors=1;disallowpremature=0;trueisminus1=0;bi=0;byteaaslongvarbinary=0;useserversideprepare=1;lowercaseidentifier=0;gssauthusegss=0;xaopt=1;";
        /* --------------------------------------------------------------------------------------------------------------- */





        /* -------------- Eveniment de tip click pentru "btnIesire" ------------------------------------------------------ */
        private void btnIesire_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /* --------------------------------------------------------------------------------------------------------------- */




        /* ---------------- Variabile de lucru pentru dgvVizualizareTot -------------------------------------------------- */
        DataTable dt_dgvVizualizareTot;
        /* --------------- Metoda de populare a dgvVizualizareTot -------------------------------------------------------- */
        public void PopularedgvVizualizareTot()
        {
            using (OdbcConnection conexiune_dgvAfisareVT = new OdbcConnection(sircon_RelIntDB))
            {           // Comanda
                using (OdbcCommand comanda_dgvAfisareVT = new OdbcCommand())
                {
                    comanda_dgvAfisareVT.Connection = conexiune_dgvAfisareVT;
                    comanda_dgvAfisareVT.CommandType = CommandType.Text;
                    comanda_dgvAfisareVT.CommandText = "SELECT nrinregistrareod AS \"Nr. înregistrare\", nrinregistrareodnou AS \"Nr. înregistrare (modificat)\", dataod AS \"Data OD\", dataodnoua AS \"Data OD (modificat)\", subsemnatulod AS \"Subsemnatul\", graddidacticod AS \"Grad didactic\", facultateaod AS \"Facultatea\", localitateaod AS \"Localitatea\", taraod AS \"Țara\", scopod AS \"Scop\", institutiaod AS \"Institutia\", datainceputod AS \"Data inceput\", datasfarsitod AS \"Data sfarsit\", rutaod AS \"Ruta\", platitortranspod AS \"Platitor transport\", platitorintretinereod AS \"Platitor întreținere\", nrzilediurnaod AS \"Nr. zile diurnă\", diurnaod AS \"Diurnă\", monedadiurnaod AS \"Monedă diurnă\", nrzilecazareod AS \"Nr. zile cazare\", cazareod AS \"Cazare\", monedacazareod AS \"Monedă cazare\", taxadeparticipareod AS \"Taxă de participare\", monedataxadeparticipareod AS \"Monedă taxă de participare\", taxadevizaetcod AS \"Taxă de viză\", monedataxadevizaetcod AS \"Monedă taxă de viză\", totalod AS \"Total\", altedispuneri1od AS \"Alte dispuneri (câmp 1)\", altedispuneri2od AS \"Alte dispuneri (câmp 2)\", altedispuneri3od AS \"Alte dispuneri (câmp 3)\", altedispuneri4od AS \"Alte dispuneri (câmp 4)\", rectorod AS \"Rector\", prorectorod AS \"Prorector\", numerpod AS \"Nume Rector/Prorector\", dfcod AS \"Director Financiar-Contabil\", cpnumeprojod AS \"Nume proiect\", cpgraddidacticod AS \"Grad didactic\", cpnumecoordod AS \"Nume coordonator proiect\" FROM ordinedeplasare";

                    try
                    {
                        conexiune_dgvAfisareVT.Open();
                        OdbcDataAdapter da_dgvAfisareVT = new OdbcDataAdapter();
                        da_dgvAfisareVT.SelectCommand = comanda_dgvAfisareVT;

                        dt_dgvVizualizareTot = new DataTable();

                        BindingSource bs_dgvAfisareVT = new BindingSource();
                        bs_dgvAfisareVT.DataSource = dt_dgvVizualizareTot;

                        dgvVizualizareTot.DataSource = bs_dgvAfisareVT;


                        da_dgvAfisareVT.Fill(dt_dgvVizualizareTot);
                        da_dgvAfisareVT.Update(dt_dgvVizualizareTot);
                    }
                    catch (Exception exdgvAfisareVT)
                    {
                        MessageBox.Show(exdgvAfisareVT.Message);
                    } // Ne deconectam
                    finally
                    {
                        conexiune_dgvAfisareVT.Close();
                    }
                }
            }
        }
        /* --------------------------------------------------------------------------------------------------------------- */






    }
}
