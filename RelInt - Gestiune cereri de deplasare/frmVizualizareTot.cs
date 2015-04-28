using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Odbc;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RelInt___Gestiune_cereri_de_deplasare
{
    public partial class frmVizualizareTot : Form
    {
        public frmVizualizareTot() // Metoda de LOAD
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
                    comanda_dgvAfisareVT.CommandText = "SELECT nrinregistrarec as \"Nr. înregistrare\", datac AS \"Data înregistrare\", subsemnatulc AS \"Subsemnatul\", graddidacticc AS \"Grad Didactic\", facultateac AS \"Facultatea\", departamentulc AS \"Departamentul\", localitateac AS \"Localitatea\", tarac AS \"Țara\", scopc AS \"Acțiunea\", institutiac AS \"Instituția\", datainceputc AS \"Între data\", datasfarsitc AS \"și data\", rutac AS \"Ruta\", mijtransc AS \"Mijloc de transport\", platitortranspc AS \"Plătitor transport\", platitorintretinerec AS \"Plătitor întreținere\", diurnac AS \"Diurnă\", cazarec AS \"Cazare\", taxadeparticiparec AS \"Taxă de participare\", taxadevizaetcc AS \"Taxă de viză\", totalc AS \"Total\", ambasadac AS \"Ambasadă\", nedeterminatac AS \"Perioadă nedeterminată?\", determinatac AS \"Perioadă determinată?\", decanc AS \"Decan\", vizacontac AS \"Viza Contabilitate\", admsefbirouc AS \"Administrator șef\", sefdepartamentdirc AS \"Șef departament\", vizaruc AS \"Viza RU\", tiozc AS \"Trecut în ordinea de zi?\" FROM cereri";

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
