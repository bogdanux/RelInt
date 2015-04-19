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
using PdfSharp;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using System.Diagnostics;

namespace RelInt___Gestiune_cereri_de_deplasare
{
    public partial class frmOrdineaDeZi : Form
    {
        public frmOrdineaDeZi() // Metoda LOAD
        {
            InitializeComponent();

            DataTable dt_dgvAfisare;

            /* ------------------------- Evenimente pentru casetele de text folosite la afisare ------------------------------ */
            using (OdbcConnection conexiune_dgvAfisare = new OdbcConnection(sircon_RelIntDB))
            {           // Comanda
                using (OdbcCommand comanda_dgvAfisare = new OdbcCommand())
                {
                    comanda_dgvAfisare.Connection = conexiune_dgvAfisare;
                    comanda_dgvAfisare.CommandType = CommandType.Text;
                    comanda_dgvAfisare.CommandText = "SELECT nrinregistrarec AS \"Nr. Inregistrare\", datac AS \"Data Cerere\", subsemnatulc AS \"Subsemnatul\", graddidacticc AS \"Grad didactic\", facultateac AS \"Facultatea\", departamentulc \"Departamentul\", localitateac AS \"Localitatea\", tarac AS \"Tara\", scopc AS \"Scop\", institutiac AS \"Institutia\", datainceputc AS \"Data Inceput\", datasfarsitc AS \"Data Sfarsit\", rutac AS \"Ruta\", mijtransc AS \"Mij. Trans.\", platitortranspc AS \"Platitor Transport\", platitorintretinerec AS \"Platitor Intretinere\", diurnac AS \"Diurna\", cazarec AS \"Cazare\", taxadeparticiparec AS \"Taxa de participare\", taxadevizaetcc AS \"Taxa De Viza\", totalc AS \"Total\", ambasadac AS \"Ambasada\", nedeterminatac AS \"Nedeterminata\", determinatac AS \"Determinata\", decanc AS \"Decan\", vizacontac AS \"Viza Conta\", admsefbirouc AS \"Adm. Sef Birou\", sefdepartamentdirc AS \"Sef Departament\", vizaruc AS \"Viza RU\" FROM cereri WHERE tiozc = ?";
                    comanda_dgvAfisare.Parameters.AddWithValue("@tiozc", OdbcType.Bit).Value = false;

                    try
                    {
                        conexiune_dgvAfisare.Open();
                        OdbcDataAdapter da_dgvAfisare = new OdbcDataAdapter();
                        da_dgvAfisare.SelectCommand = comanda_dgvAfisare;

                        dt_dgvAfisare = new DataTable();
                        da_dgvAfisare.Fill(dt_dgvAfisare);

                        BindingSource bs_dgvAfisare = new BindingSource();
                        bs_dgvAfisare.DataSource = dt_dgvAfisare;

                        dgvObiecteOrdineZi.DataSource = bs_dgvAfisare;

                        da_dgvAfisare.Update(dt_dgvAfisare);
                    }
                    catch (Exception exdgvAfisare)
                    {
                        MessageBox.Show(exdgvAfisare.Message);
                    } // Ne deconectam
                    finally
                    {
                        conexiune_dgvAfisare.Close();
                    }
                }
            }
            /* --------------------------------------------------------------------------------------------------------------- */

        }
        /* --------------------------------------------------------------------------------------------------------------- */






        /* ----------- Obiecte de lucru cu RelIntDB ---------------------------------------------------------------------- */
        // Sir de conectare al RelIntDB
        string sircon_RelIntDB = "DSN=PostgreSQL35W;database=RelIntDB;server=localhost;port=5432;UID=postgres;PWD=12345;sslmode=disable;readonly=0;protocol=7.4;fakeoidindex=0;showoidcolumn=0;rowversioning=0;showsystemtables=0;fetch=100;socket=4096;unknownsizes=0;maxvarcharsize=255;maxlongvarcharsize=8190;debug=0;commlog=0;optimizer=0;ksqo=1;usedeclarefetch=0;textaslongvarchar=1;unknownsaslongvarchar=0;boolsaschar=1;parse=0;cancelasfreestmt=0;extrasystableprefixes=dd_;lfconversion=1;updatablecursors=1;disallowpremature=0;trueisminus1=0;bi=0;byteaaslongvarbinary=0;useserversideprepare=1;lowercaseidentifier=0;gssauthusegss=0;xaopt=1;";
        /* --------------------------------------------------------------------------------------------------------------- */





        /* ----------------- Eveniment de tip "click" pentru btnIesire --------------------------------------------------- */
        private void btnIesire_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /* --------------------------------------------------------------------------------------------------------------- */
        








        /* --------------------- Eveniment click pentru butonul "btnGenerarePDF" ----------------------------------------- */
        private void btnGenerarePDF_Click(object sender, EventArgs e)
        {
            PdfDocument pdfGenerat = new PdfDocument();
            pdfGenerat.Info.Title = "Ordinea de Zi";
            PdfPage pdfPagina = pdfGenerat.AddPage();
            XGraphics pdfGraf = XGraphics.FromPdfPage(pdfPagina);
            XFont pdfFont = new XFont("Verdana", 20, XFontStyle.Regular);
            pdfGraf.DrawString("Cererea d-lui/d-nei", pdfFont, XBrushes.Black, new XRect(0, 0, pdfPagina.Width.Point, pdfPagina.Height.Point), XStringFormats.Center);

            string NumeFisierPDF = string.Empty;

            SaveFileDialog dlgPDFSalvat = new SaveFileDialog();
            dlgPDFSalvat.FileName = "Document";
            dlgPDFSalvat.DefaultExt = ".pdf";
            dlgPDFSalvat.Filter = "PDF documents (.pdf)|*.pdf";

            if (dlgPDFSalvat.ShowDialog() == DialogResult.OK)
            {

                NumeFisierPDF = dlgPDFSalvat.FileName;
            }
            pdfGenerat.Save(NumeFisierPDF);
        }
        /* --------------------------------------------------------------------------------------------------------------- */








    }
}
