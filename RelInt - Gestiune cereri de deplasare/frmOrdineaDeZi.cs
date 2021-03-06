﻿using System;
using System.Data;
using System.Windows.Forms;
using System.Data.Odbc;
using System.Diagnostics;
using MigraDoc.Rendering;
using MigraDoc.DocumentObjectModel;

namespace RelInt___Gestiune_cereri_de_deplasare
{
    public partial class frmOrdineaDeZi : Form
    {
        public frmOrdineaDeZi() // Metoda LOAD
        {
            InitializeComponent();

            // Apelam
            PopulareDGV();
        }
        /* --------------------------------------------------------------------------------------------------------------- */




        /* ------------------------- Evenimente pentru casetele de text folosite la afisare ------------------------------ */
        public void PopulareDGV()
        {
            using (OdbcConnection conexiune_dgvAfisare = new OdbcConnection(sircon_RelIntDB))
            {           // Comanda
                using (OdbcCommand comanda_dgvAfisare = new OdbcCommand())
                {
                    comanda_dgvAfisare.Connection = conexiune_dgvAfisare;
                    comanda_dgvAfisare.CommandType = CommandType.Text;
                    comanda_dgvAfisare.CommandText = "SELECT nrinregistrarec AS \"Nr. Inregistrare\", datac AS \"Data Cerere\", subsemnatulc AS \"Subsemnatul\", graddidacticc AS \"Grad didactic\", facultateac AS \"Facultatea\", departamentulc \"Departamentul\", localitateac AS \"Localitatea\", tarac AS \"Tara\", scopc AS \"Scop\", institutiac AS \"Institutia\", datainceputc AS \"Data Inceput\", datasfarsitc AS \"Data Sfarsit\", rutac AS \"Ruta\", mijtransc AS \"Mij. Trans.\", platitortranspc AS \"Platitor Transport\", platitorintretinerec AS \"Platitor Intretinere\", diurnac AS \"Diurna\", cazarec AS \"Cazare\", taxadeparticiparec AS \"Taxa de participare\", taxadevizaetcc AS \"Taxa De Viza\", totalc AS \"Total\" FROM cereri WHERE tiozc = ?";
                    comanda_dgvAfisare.Parameters.AddWithValue("@tiozc", OdbcType.Bit).Value = false;

                    try
                    {
                        conexiune_dgvAfisare.Open();
                        OdbcDataAdapter da_dgvAfisare = new OdbcDataAdapter();
                        da_dgvAfisare.SelectCommand = comanda_dgvAfisare;

                        dt_dgvAfisare = new DataTable();

                        BindingSource bs_dgvAfisare = new BindingSource();
                        bs_dgvAfisare.DataSource = dt_dgvAfisare;

                        dgvObiecteOrdineZi.DataSource = bs_dgvAfisare;


                        da_dgvAfisare.Fill(dt_dgvAfisare);
                        da_dgvAfisare.Update(dt_dgvAfisare);

                        if (dt_dgvAfisare.Rows.Count > 0)
                        {
                            // Activam "dgvObiecteOrdineZi"
                            dgvObiecteOrdineZi.Enabled = true;

                            // Activam "btnGenerarePDF"
                            btnGenerarePDF.Enabled = true;
                        }
                        else
                        {
                            // Dezactivam "dgvObiecteOrdineZi"
                            dgvObiecteOrdineZi.Enabled = false;

                            // Dezactivam "btnGenerarePDF"
                            btnGenerarePDF.Enabled = false;
                        }
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
        }
        /* --------------------------------------------------------------------------------------------------------------- */

        



        /* --------------- Varaibile publice de lucru cu diferite obiecte ------------------------------------------------ */
        // Variabila pentru afisare in "dgvAfisare"
        DataTable dt_dgvAfisare;
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
            Document documentPDF = new Document();
            documentPDF.Info.Author = "Departamentul Relatii Internationale";
            documentPDF.Info.Keywords = "Ordinea, de, zi";
            Unit width, height;
            PageSetup.GetPageSize(PageFormat.A4, out width, out height);

            Section section1 = documentPDF.AddSection();
            section1.PageSetup.PageHeight = height;
            section1.PageSetup.PageWidth = width;
            section1.PageSetup.LeftMargin = 60;
            section1.PageSetup.RightMargin = 60;
            section1.PageSetup.TopMargin = 40;
            section1.PageSetup.BottomMargin = 40;
            section1.PageSetup.OddAndEvenPagesHeaderFooter = true;
            section1.PageSetup.StartingNumber = 1;

            // Paragraf 1
            Paragraph paragraf1 = section1.AddParagraph();
            paragraf1.Format.Alignment = ParagraphAlignment.Right;
            paragraf1.Format.Font.Size = 8;
            paragraf1.Format.Font.Name = "Times New Roman";
            paragraf1.AddText("Ședința Biroului Executiv al Consiliului de Administrație din data de " + DateTime.Today.ToString().Substring(0, DateTime.Today.ToString().IndexOf("00:")));

            // Paragraf 2
            Paragraph paragraf2 = section1.AddParagraph();
            paragraf2.Format.Alignment = ParagraphAlignment.Left;
            paragraf2.Format.Font.Size = 12;
            paragraf2.Format.Font.Name = "Times New Roman";
            paragraf2.Format.SpaceBefore = "0,2cm";
            paragraf2.AddText("UNIVERSITATEA \"Alexandru Ioan Cuza\" Iași");

            // Paragraf 3
            Paragraph paragraf3 = section1.AddParagraph();
            paragraf3.Format.Alignment = ParagraphAlignment.Center;
            paragraf3.Format.Font.Size = 14;
            paragraf3.Format.Font.Bold = true;
            paragraf3.Format.Font.Name = "Times New Roman";
            paragraf3.Format.SpaceBefore = "1.5cm";
            paragraf3.AddText("BIROUL EXECUTIV AL CONSILIULUI DE ADMINISTRAȚIE");

            // Paragraf 4
            Paragraph paragraf4 = section1.AddParagraph();
            paragraf4.Format.Alignment = ParagraphAlignment.Center;
            paragraf4.Format.Font.Size = 11;
            paragraf4.Format.Font.Bold = true;
            paragraf4.Format.Font.Name = "Times New Roman";
            paragraf4.Format.SpaceBefore = "0.5cm";
            paragraf4.AddText("Secțiunea Relații Internaționale (RI)");

            // Paragraf 5
            Paragraph paragraf5 = section1.AddParagraph();
            paragraf5.Format.Alignment = ParagraphAlignment.Center;
            paragraf5.Format.Font.Size = 11;
            paragraf5.Format.Font.Name = "Times New Roman";
            paragraf5.Format.SpaceBefore = "0.3cm";
            paragraf5.AddText("din data de " + DateTime.Today.ToString().Substring(0, DateTime.Today.ToString().IndexOf("00:")));

            int numaratoare = 0;

                for(int i=0; i<dt_dgvAfisare.Rows.Count; i++)
                {
                    string TextParagraf1 = string.Empty;
                    string TextParagraf2 = string.Empty;

                    string dataInceput = dt_dgvAfisare.Rows[i].ItemArray[10].ToString().Substring(0, dt_dgvAfisare.Rows[i].ItemArray[10].ToString().IndexOf("00:"));
                    dataInceput = dataInceput.Substring(0, dataInceput.IndexOf(" "));

                    string dataSfarsit = dt_dgvAfisare.Rows[i].ItemArray[11].ToString().Substring(0, dt_dgvAfisare.Rows[i].ItemArray[11].ToString().IndexOf("00:"));
                    dataSfarsit = dataSfarsit.Substring(0, dataSfarsit.IndexOf(" "));

                    numaratoare++;

                    TextParagraf1 = numaratoare.ToString() + ". Cererea d-lui/d-nei " + dt_dgvAfisare.Rows[i].ItemArray[2] + " " + 
                        dt_dgvAfisare.Rows[i].ItemArray[3] + " la " + dt_dgvAfisare.Rows[i].ItemArray[4] + 
                        ", prin care se solicită aprobare pentru a participa la " + dt_dgvAfisare.Rows[i].ItemArray[8] + 
                        " organizată de " + dt_dgvAfisare.Rows[i].ItemArray[9] + ", " + dt_dgvAfisare.Rows[i].ItemArray[7] +
                        ", între " + dataInceput + " și " + dataSfarsit +
                        ". Cheltuielile de transport și de sejur sunt suportate de la: " + dt_dgvAfisare.Rows[i].ItemArray[14] +
                        " și din veniturile proprii ale " + dt_dgvAfisare.Rows[i].ItemArray[15] + Environment.NewLine + Environment.NewLine;

                    Paragraph paragraf6 = section1.AddParagraph();
                    paragraf6.Format.Alignment = ParagraphAlignment.Justify;
                    paragraf6.Format.Font.Size = 12;
                    paragraf6.Format.Font.Name = "Times New Roman";
                    paragraf6.Format.SpaceBefore = "0.7cm";
                    paragraf6.Format.Borders.Bottom.Visible = true;
                    paragraf6.Format.Borders.Bottom.Width = 0.1;
                    paragraf6.AddText(TextParagraf1);

                    TextParagraf2 = "    Rezoluție: "
                        + Environment.NewLine + Environment.NewLine + Environment.NewLine + Environment.NewLine + "    Transmis la: "
                        + Environment.NewLine + Environment.NewLine + Environment.NewLine;

                    Paragraph paragraf7 = section1.AddParagraph();
                    paragraf7.Format.Alignment = ParagraphAlignment.Left;
                    paragraf7.Format.Font.Size = 12;
                    paragraf7.Format.Font.Name = "Times New Roman";
                    paragraf7.Format.Borders.Top.Visible = true;
                    paragraf7.Format.Borders.Top.Width = 0.1;
                    paragraf7.Format.Borders.Bottom.Visible = true;
                    paragraf7.Format.Borders.Bottom.Width = 0.1;
                    paragraf7.Format.Borders.Left.Visible = true;
                    paragraf7.Format.Borders.Left.Width = 0.1;
                    paragraf7.Format.Borders.Right.Visible = true;
                    paragraf7.Format.Borders.Right.Width = 0.1;
                    paragraf7.AddText(TextParagraf2);


                }

            // Cream un paragraf pentru numerotarea paginilor
            Paragraph paragraf8 = new Paragraph();
            paragraf8.AddTab();
            paragraf8.AddPageField();
            paragraf8.Format.Font.Size = 9;
            paragraf8.Format.Font.Name = "Times New Roman";
            paragraf8.Format.Alignment = ParagraphAlignment.Center;
            // Add "paragraf7" in footer-ul paginilor impare
            section1.Footers.Primary.Add(paragraf8);
            // Cloanam "paragraf7" in footer-ul paginilor pare (clonam deoarece o sa ne dea eroare daca-l punem pe acelasi)
            section1.Footers.EvenPage.Add(paragraf8.Clone());


            PdfDocumentRenderer pdfRenderer = new PdfDocumentRenderer(true);
            pdfRenderer.Document = documentPDF;
            pdfRenderer.RenderDocument();

            string NumeFisierPDF = string.Empty;

            SaveFileDialog dlgPDFSalvat = new SaveFileDialog();
            dlgPDFSalvat.FileName = "Document";
            dlgPDFSalvat.DefaultExt = ".pdf";
            dlgPDFSalvat.Filter = "PDF documents (.pdf)|*.pdf";


            if (dlgPDFSalvat.ShowDialog() == DialogResult.OK)
            {
                // Atribuim numele standard
                NumeFisierPDF = dlgPDFSalvat.FileName;

                // Salvam fisierul PDF
                pdfRenderer.PdfDocument.Save(NumeFisierPDF);

                // Deschidem fisierul dupa ce l-am salvat
                Process.Start(NumeFisierPDF);

                // Actualizam campurile exportate in BD
                MetodaUpdateBD();
            }
            else
            {
                // Inchidem formularul curent
                this.Close();
            }
        }
        /* --------------------------------------------------------------------------------------------------------------- */







        /* ------------------- Actualizarea campurilor in BD ------------------------------------------------------------- */
        private void MetodaUpdateBD()
        {
            using (OdbcConnection conexiune_InserareCerereRelInt = new OdbcConnection(sircon_RelIntDB))
            {           // Comanda
                using (OdbcCommand comanda_inserareRelInt = new OdbcCommand())
                {
                    comanda_inserareRelInt.Connection = conexiune_InserareCerereRelInt;
                    comanda_inserareRelInt.CommandType = CommandType.Text;
                    comanda_inserareRelInt.CommandText = "UPDATE cereri SET tiozc = ? WHERE tiozc = ?";
                    comanda_inserareRelInt.Parameters.AddWithValue("@tiozc", OdbcType.Bit).Value = true;
                    comanda_inserareRelInt.Parameters.AddWithValue("@tiozc", OdbcType.Bit).Value = false;



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







        /* --------------------------------------------------------------------------------------------------------------- */
        private void frmOrdineaDeZi_Activated(object sender, EventArgs e)
        {
            if (dgvObiecteOrdineZi.Enabled == false) {
                // Afisam un mesaj informativ
                MessageBox.Show("   Nu există înregistrări ce pot fi exportate către PDF. \n        Vă rugăm accesați această fereastră ulterior.", "Informație", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }   
        /* --------------------------------------------------------------------------------------------------------------- */






    }
}
