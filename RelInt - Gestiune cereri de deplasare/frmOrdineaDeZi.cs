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
using System.Diagnostics;
using MigraDoc.Rendering;
using MigraDoc;
using MigraDoc.DocumentObjectModel;
using MigraDoc.Rendering.Forms;

namespace RelInt___Gestiune_cereri_de_deplasare
{
    public partial class frmOrdineaDeZi : Form
    {
        DataTable dt_dgvAfisare;
        public frmOrdineaDeZi() // Metoda LOAD
        {
            InitializeComponent();

            //DataTable dt_dgvAfisare;

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
            // Create a MigraDoc document
            Document document = new Document();
            document.Info.Author = "Rolf Baxter";
            document.Info.Keywords = "MigraDoc, Examples, C#";
            Unit width, height;
            PageSetup.GetPageSize(PageFormat.A4, out width, out height);

            Section section = document.AddSection();
            section.PageSetup.PageHeight = height;
            section.PageSetup.PageWidth = width;
            section.PageSetup.LeftMargin = 60;
            section.PageSetup.RightMargin = 50;
            section.PageSetup.TopMargin = 20;
            section.PageSetup.BottomMargin = 15;

            // Paragraf 1
            Paragraph paragraf1 = section.AddParagraph();
            paragraf1.Format.Alignment = ParagraphAlignment.Right;
            paragraf1.Format.Font.Size = 8;
            paragraf1.Format.Font.Name = "Times New Roman";
            paragraf1.AddText("Sedinta Biroului Executiv al Consiliului de Administratie din data de " + DateTime.Today.ToString().Substring(0, DateTime.Today.ToString().IndexOf("00:")));

            // Paragraf 2
            Paragraph paragraf2 = section.AddParagraph();
            paragraf2.Format.Alignment = ParagraphAlignment.Left;
            paragraf2.Format.Font.Size = 12;
            paragraf2.Format.Font.Name = "Times New Roman";
            paragraf2.AddText("UNIVERSITATEA \"Alexandru Ioan Cuza\" Iasi");

            // Paragraf 3
            Paragraph paragraf3 = section.AddParagraph();
            paragraf3.Format.Alignment = ParagraphAlignment.Center;
            paragraf3.Format.Font.Size = 14;
            paragraf3.Format.Font.Bold = true;
            paragraf3.Format.Font.Name = "Times New Roman";
            paragraf3.Format.SpaceBefore = "1.5cm";
            paragraf3.AddText("BIROUL EXECUTIV AL CONSILIULUI DE ADMINISTRATIE");

            // Paragraf 4
            Paragraph paragraf4 = section.AddParagraph();
            paragraf4.Format.Alignment = ParagraphAlignment.Center;
            paragraf4.Format.Font.Size = 11;
            paragraf4.Format.Font.Bold = true;
            paragraf4.Format.Font.Name = "Times New Roman";
            paragraf4.Format.SpaceBefore = "0.5cm";
            paragraf4.AddText("Sectiunea Relatii Internationale (RI)");

            // Paragraf 5
            Paragraph paragraf5 = section.AddParagraph();
            paragraf5.Format.Alignment = ParagraphAlignment.Center;
            paragraf5.Format.Font.Size = 11;
            paragraf5.Format.Font.Name = "Times New Roman";
            paragraf5.Format.SpaceBefore = "0.3cm";
            paragraf5.AddText("din data de " + DateTime.Today.ToString().Substring(0, DateTime.Today.ToString().IndexOf("00:")));

            string formularCerere = string.Empty;
            int numaratoare = 0;
            

            for(int i=0; i<dt_dgvAfisare.Rows.Count; i++)
            {
                string dataInceput = dt_dgvAfisare.Rows[i].ItemArray[10].ToString().Substring(0, dt_dgvAfisare.Rows[i].ItemArray[10].ToString().IndexOf("00:"));
                dataInceput = dataInceput.Substring(0, dataInceput.IndexOf(" "));

                string dataSfarsit = dt_dgvAfisare.Rows[i].ItemArray[11].ToString().Substring(0, dt_dgvAfisare.Rows[i].ItemArray[11].ToString().IndexOf("00:"));
                dataSfarsit = dataSfarsit.Substring(0, dataSfarsit.IndexOf(" "));

                numaratoare++;

                formularCerere += numaratoare.ToString() + ". Cererea d-lui/d-nei " + dt_dgvAfisare.Rows[i].ItemArray[2] + " " + 
                    dt_dgvAfisare.Rows[i].ItemArray[3] + " la " + dt_dgvAfisare.Rows[i].ItemArray[4] + 
                    ", prin care se solicita aprobare pentru a participa la " + dt_dgvAfisare.Rows[i].ItemArray[8] + 
                    " organizata de " + dt_dgvAfisare.Rows[i].ItemArray[9] + ", " + dt_dgvAfisare.Rows[i].ItemArray[7] +
                    ", intre " + dataInceput + " si " + dataSfarsit +
                    ". Cheltuielile de transport: 5555555 sunt suporttate de " + dt_dgvAfisare.Rows[i].ItemArray[14] +
                    "si de sejur: 55555555 sunt suportate" + Environment.NewLine + Environment.NewLine + "Rezolutie: "
                    + Environment.NewLine + Environment.NewLine + Environment.NewLine + Environment.NewLine + "Transmis la: "
                    + Environment.NewLine + Environment.NewLine + Environment.NewLine;
            }

            // Paragraf 6
            Paragraph paragraf6 = section.AddParagraph();
            paragraf6.Format.Alignment = ParagraphAlignment.Justify;
            paragraf6.Format.Font.Size = 12;
            paragraf6.Format.Font.Name = "Times New Roman";
            paragraf6.Format.SpaceBefore = "2cm";

            paragraf6.AddText(formularCerere);

            PdfDocumentRenderer pdfRenderer = new PdfDocumentRenderer();
            pdfRenderer.Document = document;
            pdfRenderer.RenderDocument();

            string NumeFisierPDF = string.Empty;

            SaveFileDialog dlgPDFSalvat = new SaveFileDialog();
            dlgPDFSalvat.FileName = "Document";
            dlgPDFSalvat.DefaultExt = ".pdf";
            dlgPDFSalvat.Filter = "PDF documents (.pdf)|*.pdf";


            if (dlgPDFSalvat.ShowDialog() == DialogResult.OK)
            {
                NumeFisierPDF = dlgPDFSalvat.FileName;
            }
            pdfRenderer.PdfDocument.Save(NumeFisierPDF);
            Process.Start(NumeFisierPDF);
        }
        /* --------------------------------------------------------------------------------------------------------------- */








    }
}
