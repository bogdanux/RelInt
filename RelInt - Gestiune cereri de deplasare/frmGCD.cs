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
    public partial class frmGCD : Form
    {
        public frmGCD() // Metoda de LOAD
        {
            InitializeComponent();

            MetodaScriereInStatus();

            VerificareGradeDidactice();
            VerificareFacultati();
            VerificareMonezi();

            VerificareCereri();
        }
        /* --------------------------------------------------------------------------------------------------------------- */










        /* ----------- Obiecte de lucru cu RelIntDB ---------------------------------------------------------------------- */
        // Sir de conectare al RelIntDB
        string sircon_RelIntDB = "DSN=PostgreSQL35W;database=RelIntDB;server=localhost;port=5432;UID=postgres;PWD=12345;sslmode=disable;readonly=0;protocol=7.4;fakeoidindex=0;showoidcolumn=0;rowversioning=0;showsystemtables=0;fetch=100;socket=4096;unknownsizes=0;maxvarcharsize=255;maxlongvarcharsize=8190;debug=0;commlog=0;optimizer=0;ksqo=1;usedeclarefetch=0;textaslongvarchar=1;unknownsaslongvarchar=0;boolsaschar=1;parse=0;cancelasfreestmt=0;extrasystableprefixes=dd_;lfconversion=1;updatablecursors=1;disallowpremature=0;trueisminus1=0;bi=0;byteaaslongvarbinary=0;useserversideprepare=1;lowercaseidentifier=0;gssauthusegss=0;xaopt=1;";

        /* --------------------------------------------------------------------------------------------------------------- */











        /* ------------------- Evenimentul click al butonului "mnuIesire" ------------------------------------------------ */
        private void VerificareGradeDidactice()
        {
            using (OdbcConnection conexiune_cmbGradDidactic = new OdbcConnection(sircon_RelIntDB))
            {           // Comanda
                using (OdbcCommand comanda_cmbGradDidactic = new OdbcCommand())
                {
                    comanda_cmbGradDidactic.Connection = conexiune_cmbGradDidactic;
                    comanda_cmbGradDidactic.CommandType = CommandType.Text;
                    comanda_cmbGradDidactic.CommandText = "SELECT * FROM gradedidactice ORDER BY graddidacticgd ASC";

                    OdbcDataReader cititor_cmbGradDidactic;

                    try
                    {
                        conexiune_cmbGradDidactic.Open();
                        cititor_cmbGradDidactic = comanda_cmbGradDidactic.ExecuteReader();
                        
                        // Daca cititorul
                        if (cititor_cmbGradDidactic.HasRows == false)
                        {
                            // Dezactivam urmatoarele
                            btnGCDIntroducereFormular.Enabled = false;
                            btnGCDModificareFormular.Enabled = false;

                            // Afisam de ce
                            tsStatusDeCe.Text += " Nu sunt denumiri de GRADE DIDACTICE introduse în baza de date. Introduceți-le! ";
                        }
                        else
                        {
                            // Activam urmatoarele
                            btnGCDIntroducereFormular.Enabled = true;
                            btnGCDModificareFormular.Enabled = true;
                        }
                    }
                    catch (Exception excmbGradDidactic)
                    {
                        MessageBox.Show(excmbGradDidactic.Message);
                    } // Ne deconectam
                    finally
                    {
                        conexiune_cmbGradDidactic.Close();
                    }
                }
            }
        }
        /* --------------------------------------------------------------------------------------------------------------- */
        /* ---------- Metoda de umplere a cmbFacultate cu date din RelIntDB ---------------------------------------------- */
        private void VerificareFacultati()
        {
            using (OdbcConnection conexiune_cmbFacultate = new OdbcConnection(sircon_RelIntDB))
            {           // Comanda
                using (OdbcCommand comanda_cmbFacultate = new OdbcCommand())
                {
                    comanda_cmbFacultate.Connection = conexiune_cmbFacultate;
                    comanda_cmbFacultate.CommandType = CommandType.Text;
                    comanda_cmbFacultate.CommandText = "SELECT * FROM facultati ORDER BY facultati ASC";

                    OdbcDataReader cititor_cmbFacultate;

                    try
                    {
                        conexiune_cmbFacultate.Open();
                        cititor_cmbFacultate = comanda_cmbFacultate.ExecuteReader();

                        // Daca cititorul
                        if (cititor_cmbFacultate.HasRows == false)
                        {
                            // Dezactivam urmatoarele
                            btnGCDIntroducereFormular.Enabled = false;
                            btnGCDModificareFormular.Enabled = false;

                            // Afisam de ce
                            tsStatusDeCe.Text += " Nu sunt denumiri de FACULTĂȚI introduse în baza de date. Introduceți-le! ";
                        }
                        else
                        {
                            // Activam urmatoarele
                            btnGCDIntroducereFormular.Enabled = true;
                            btnGCDModificareFormular.Enabled = true;
                        }
                    }
                    catch (Exception excmbFacultate)
                    {
                        MessageBox.Show(excmbFacultate.Message);
                    } // Ne deconectam
                    finally
                    {
                        conexiune_cmbFacultate.Close();
                    }
                }
            }
        }
        /* --------------------------------------------------------------------------------------------------------------- */
        /* ---------- Metoda de umplere a cmbFacultate cu date din RelIntDB ---------------------------------------------- */
        private void VerificareMonezi()
        {
            using (OdbcConnection conexiune_cmbMonezi = new OdbcConnection(sircon_RelIntDB))
            {           // Comanda
                using (OdbcCommand comanda_cmbMonezi = new OdbcCommand())
                {
                    comanda_cmbMonezi.Connection = conexiune_cmbMonezi;
                    comanda_cmbMonezi.CommandType = CommandType.Text;
                    comanda_cmbMonezi.CommandText = "SELECT * FROM monezi ORDER BY monezim ASC";

                    OdbcDataReader cititor_cmbMonezi;

                    try
                    {
                        conexiune_cmbMonezi.Open();
                        cititor_cmbMonezi = comanda_cmbMonezi.ExecuteReader();

                        // Daca cititorul
                        if (cititor_cmbMonezi.HasRows == false)
                        {
                            // Dezactivam urmatoarele
                            btnGCDIntroducereFormular.Enabled = false;
                            btnGCDModificareFormular.Enabled = false;

                            // Afisam de ce
                            tsStatusDeCe.Text += " Nu sunt denumiri de MONEDE introduse în baza de date. Introduceți-le! ";
                        }
                        else
                        {
                            // Activam urmatoarele
                            btnGCDIntroducereFormular.Enabled = true;
                            btnGCDModificareFormular.Enabled = true;
                        }
                    }
                    catch (Exception excmbMonezi)
                    {
                        MessageBox.Show(excmbMonezi.Message);
                    } // Ne deconectam
                    finally
                    {
                        conexiune_cmbMonezi.Close();
                    }
                }
            }
        }
        /* --------------------------------------------------------------------------------------------------------------- */
        /* ---------- Metoda de umplere a cmbFacultate cu date din RelIntDB ---------------------------------------------- */
        public void VerificareCereri()
        {
            using (OdbcConnection conexiune_cereri = new OdbcConnection(sircon_RelIntDB))
            {           // Comanda
                using (OdbcCommand comanda_cereri = new OdbcCommand())
                {
                    comanda_cereri.Connection = conexiune_cereri;
                    comanda_cereri.CommandType = CommandType.Text;
                    comanda_cereri.CommandText = "SELECT nrinregistrarec FROM cereri";

                    OdbcDataReader cititor_cereri;

                    try
                    {
                        conexiune_cereri.Open();

                        cititor_cereri = comanda_cereri.ExecuteReader();

                        // Daca cititorul
                        if (cititor_cereri.HasRows == false)
                        {
                            // Dezactivam urmatoarele
                            btnGCDModificareFormular.Enabled = false;

                            // Afisam de ce
                            tsStatusDeCe.Text += " Nu sunt CERERI introduse în baza de date. Introduceți măcar una! ";
                        }
                        else
                        {
                            // Activam urmatoarele
                            btnGCDModificareFormular.Enabled = true;
                        }
                    }
                    catch (Exception excmbMonezi)
                    {
                        MessageBox.Show(excmbMonezi.Message);
                    } // Ne deconectam
                    finally
                    {
                        conexiune_cereri.Close();
                    }
                }
            }
        }
        /* --------------------------------------------------------------------------------------------------------------- */
        /* -------------------- MetodaScriereInStatus -------------------------------------------------------------------- */
        public void MetodaScriereInStatus()
        {
            using (OdbcConnection conexiune_lblUCI = new OdbcConnection(sircon_RelIntDB))
            {           // Comanda
                using (OdbcCommand comanda_lblUCI = new OdbcCommand())
                {
                    comanda_lblUCI.Connection = conexiune_lblUCI;
                    comanda_lblUCI.CommandType = CommandType.Text;
                    comanda_lblUCI.CommandText = "SELECT MAX(nrinregistrarec) FROM cereri";

                    try
                    {
                        conexiune_lblUCI.Open();
                        OdbcDataReader reader_lblUCI = comanda_lblUCI.ExecuteReader();

                        while (reader_lblUCI.Read())
                        {
                            if (reader_lblUCI[0].ToString() != "")
                            {
                                tsStatusUltimaInregistrare.Text = "Numărul ultimei cereri introduse: " + reader_lblUCI.GetDecimal(0).ToString();
                            }
                        }
                        reader_lblUCI.Close();
                    }
                    catch (Exception exlblUCI)
                    {
                        MessageBox.Show(exlblUCI.Message);
                    }
                    finally
                    {
                        conexiune_lblUCI.Close();
                    }
                }
            }
        }
        /* --------------------------------------------------------------------------------------------------------------- */











        /* ------------------- Evenimentul click al butonului "mnuIesire" ------------------------------------------------ */
        private void mnuIesire_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /* --------------------------------------------------------------------------------------------------------------- */











        /* ------------------ Deschiderea formularului de introducere ---------------------------------------------------- */
        private void btnGCDIntroducereFormular_Click(object sender, EventArgs e)
        {
            // Apelam formularul "frmCerereIntroducere"
            Form frmCerereInregistrare = new frmCerereInregistrare();

            // Facem "frmCerereIntroducere" copil al "frmGCD"
            frmCerereInregistrare.MdiParent = this;

            foreach (Form form in Application.OpenForms)
            {
                if (form.GetType() == typeof(frmCerereInregistrare))
                {
                    form.WindowState = FormWindowState.Normal;
                    form.Activate();
                    return;
                }
            }

            // Afisam "frmCerereIntroducere"
            frmCerereInregistrare.Show();
        }
        /* --------------------------------------------------------------------------------------------------------------- */










        /* ------------------ Deschiderea formularului de modificare ----------------------------------------------------- */
        private void btnGCDModificareFormular_Click(object sender, EventArgs e)
        {
            // Apelam formularul "frmCerereModificare"
            Form frmCerereModificare = new frmCerereModificare();

            // Facem "frmCerereModificare" copil al "frmGCD"
            frmCerereModificare.MdiParent = this;

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
        /* --------------------------------------------------------------------------------------------------------------- */











        /* ------------------- Deschiderea formularului de cautare ------------------------------------------------------- */
        private void btnGCDcăutareCerere_Click(object sender, EventArgs e)
        {
            // Apelam formularul "frmCautareCerere"
            Form frmCautareCerere = new frmCautareCerere();

            // Facem "frmCautareCerere" copil al "frmGCD"
            frmCautareCerere.MdiParent = this;

            foreach (Form form in Application.OpenForms)
            {
                if (form.GetType() == typeof(frmCautareCerere))
                {
                    form.WindowState = FormWindowState.Normal;
                    form.Activate();
                    return;
                }
            }

            // Afisam "frmCerereModificare"
            frmCautareCerere.Show();
        }
        /* --------------------------------------------------------------------------------------------------------------- */











        /* ------------------- Deschiderea formularului "DespreApp" ------------------------------------------------------- */
        private void btnGCDDespreApp_Click(object sender, EventArgs e)
        {
            // Apelam formularul "frmDespreApp"
            Form frmDespreApp = new frmDespreApp();

            // Facem "frmDespreApp" copil al "frmGCD"
            frmDespreApp.MdiParent = this;

            foreach (Form form in Application.OpenForms)
            {
                if (form.GetType() == typeof(frmDespreApp))
                {
                    form.WindowState = FormWindowState.Normal;
                    form.Activate();
                    return;
                }
            }

            // Afisam "frmCerereModificare"
            frmDespreApp.Show();
        }
        /* --------------------------------------------------------------------------------------------------------------- */











        /* --------------------------------------------------------------------------------------------------------------- */
        private void btnGCDRealizatori_Click(object sender, EventArgs e)
        {
            // Apelam formularul "frmRealizatori"
            Form frmRealizatori = new frmRealizatori();

            // Facem "frmDespreApp" copil al "frmGCD"
            frmRealizatori.MdiParent = this;

            foreach (Form form in Application.OpenForms)
            {
                if (form.GetType() == typeof(frmRealizatori))
                {
                    form.WindowState = FormWindowState.Normal;
                    form.Activate();
                    return;
                }
            }

            // Afisam "frmCerereModificare"
            frmRealizatori.Show();
        }
        /* --------------------------------------------------------------------------------------------------------------- */









        /* ------------------ Deschiderea formularului "frmOrdineaDeZi" ------------------------------------------------------- */
        private void btnGCDOrdineaDeZi_Click(object sender, EventArgs e)
        {
            // Apelam formularul "frmRealizatori"
            Form frmOrdineaDeZi = new frmOrdineaDeZi();

            // Facem "frmDespreApp" copil al "frmGCD"
            frmOrdineaDeZi.MdiParent = this;

            foreach (Form form in Application.OpenForms)
            {
                if (form.GetType() == typeof(frmOrdineaDeZi))
                {
                    form.WindowState = FormWindowState.Normal;
                    form.Activate();
                    return;
                }
            }

            // Afisam "frmCerereModificare"
            frmOrdineaDeZi.Show();
        }
        /* --------------------------------------------------------------------------------------------------------------- */






        /* ------------------------ Deschiderea formularului VizualizareTot ---------------------------------------------- */
        private void btnGCDVizualizareTot_Click(object sender, EventArgs e)
        {
            // Apelam formularul "frmVizualizareTot"
            Form frmVizualizareTot = new frmVizualizareTot();

            // Facem "frmVizualizareTot" copil al "frmGCD"
            frmVizualizareTot.MdiParent = this;

            foreach (Form form in Application.OpenForms)
            {
                if (form.GetType() == typeof(frmVizualizareTot))
                {
                    form.WindowState = FormWindowState.Normal;
                    form.Activate();
                    return;
                }
            }

            // Afisam "frmVizualizareTot"
            frmVizualizareTot.Show();
        }
        /* --------------------------------------------------------------------------------------------------------------- */









        
        
        /* --------------------- Deschiderea formularului frmRaportCereri ------------------------------------------------ */
        private void btnGCDRaportCereri_Click(object sender, EventArgs e)
        {
            // Apelam formularul "frmRaportCereri"
            Form frmRaportCereri = new frmRaportCereri();

            // Facem "frmRaportCereri" copil al "frmGCD"
            frmRaportCereri.MdiParent = this;

            foreach (Form form in Application.OpenForms)
            {
                if (form.GetType() == typeof(frmRaportCereri))
                {
                    form.WindowState = FormWindowState.Normal;
                    form.Activate();
                    return;
                }
            }

            // Afisam "frmRaportCereri"
            frmRaportCereri.Show();
        }
        /* --------------------------------------------------------------------------------------------------------------- */









        /* ---------------------- Deschiderea formularului frmCerereBECA -------------------------------------- */
        private void btnGCDBeca_Click(object sender, EventArgs e)
        {
            // Apelam formularul "frmCerereBECA"
            Form frmCerereBECA = new frmOrdinDeDeplasare();

            // Facem "frmCerereBECA" copil al "frmGCD"
            frmCerereBECA.MdiParent = this;

            foreach (Form form in Application.OpenForms)
            {
                if (form.GetType() == typeof(frmOrdinDeDeplasare))
                {
                    form.WindowState = FormWindowState.Normal;
                    form.Activate();
                    return;
                }
            }

            // Afisam "frmCerereBECA"
            frmCerereBECA.Show();
        }
        /* --------------------------------------------------------------------------------------------------------------- */










        /* ----------------- Deschiderea formularului frmTipuriIntrari ---------------------------------------------- */
        private void btnGCDTipIntrari_Click(object sender, EventArgs e)
        {
            // Apelam formularul "frmTipuriIntrari"
            Form frmTipuriIntrari = new frmTipuriIntrari();

            // Facem "frmTipuriIntrari" copil al "frmGCD"
            frmTipuriIntrari.MdiParent = this;

            foreach (Form form in Application.OpenForms)
            {
                if (form.GetType() == typeof(frmTipuriIntrari))
                {
                    form.WindowState = FormWindowState.Normal;
                    form.Activate();
                    return;
                }
            }

            // Afisam "frmTipuriIntrari"
            frmTipuriIntrari.Show();
        }
        /* --------------------------------------------------------------------------------------------------------------- */








        /* ------------------ Deschiderea formularului frmEditareRector ----------------------------------------- */
        private void btnGCDEditareRectori_Click(object sender, EventArgs e)
        {
            // Apelam formularul "frmEditareRector"
            Form frmEditareRector = new frmEditareRector();

            // Facem "frmEditareRector" copil al "frmGCD"
            frmEditareRector.MdiParent = this;

            foreach (Form form in Application.OpenForms)
            {
                if (form.GetType() == typeof(frmEditareRector))
                {
                    form.WindowState = FormWindowState.Normal;
                    form.Activate();
                    return;
                }
            }

            // Afisam "frmEditareRector"
            frmEditareRector.Show();
        }
        /* --------------------------------------------------------------------------------------------------------------- */
        








        /* ------------------- Eveniment de tip "activated" am formularului curent --------------------------------------- */
        private void frmGCD_Activated(object sender, EventArgs e)
        {
            MetodaScriereInStatus();
        }
        /* --------------------------------------------------------------------------------------------------------------- */









        /* --------------------- Eveniment de tip "load" al formularului curent ------------------------------------------ */
        private void frmGCD_Load(object sender, EventArgs e)
        {
            MdiClient ctlMDI;

            // Cautam printre controale controlul de acest tip
            foreach (Control ctl in this.Controls)
            {
                if (ctl is MdiClient)
                {
                    try
                    {
                        // facem Cast controlului curent la tipul MdiClient
                        ctlMDI = (MdiClient)ctl;

                        // Seteaza culoarea de background pe culoarea setata in proprietati
                        ctlMDI.BackColor = this.BackColor;
                    }
                    catch (InvalidCastException exCuloareBG)
                    {
                        // Arata eroarea
                        MessageBox.Show(exCuloareBG.Message);
                    } 
                }
            }
        }
        /* --------------------------------------------------------------------------------------------------------------- */
    }
}