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

            AprobareVerifDGFM();

            VerificareGradeDidactice();
            VerificareFacultati();
            VerificareMonezi();

            MetodaScriereInStatus();
        }
        /* --------------------------------------------------------------------------------------------------------------- */










        /* ----------- Obiecte de lucru cu RelIntDB ---------------------------------------------------------------------- */
        // Sir de conectare al RelIntDB
        string sircon_RelIntDB = "DSN=PostgreSQL35W;database=RelIntDB;server=localhost;port=5432;UID=postgres;PWD=12345;sslmode=disable;readonly=0;protocol=7.4;fakeoidindex=0;showoidcolumn=0;rowversioning=0;showsystemtables=0;fetch=100;socket=4096;unknownsizes=0;maxvarcharsize=255;maxlongvarcharsize=8190;debug=0;commlog=0;optimizer=0;ksqo=1;usedeclarefetch=0;textaslongvarchar=1;unknownsaslongvarchar=0;boolsaschar=1;parse=0;cancelasfreestmt=0;extrasystableprefixes=dd_;lfconversion=1;updatablecursors=1;disallowpremature=0;trueisminus1=0;bi=0;byteaaslongvarbinary=0;useserversideprepare=1;lowercaseidentifier=0;gssauthusegss=0;xaopt=1;";

        /* --------------------------------------------------------------------------------------------------------------- */










        bool AprobareVerifGD = false;
        bool AprobareVerifF = false;
        bool AprobareVerifM = false;
        bool ExistaCereri = false;
        /* ------------------- Evenimentul click al butonului "mnuIesire" ------------------------------------------------ */
        public void VerificareGradeDidactice()
        {
            using (OdbcConnection conexiune_cmbGradDidactic = new OdbcConnection(sircon_RelIntDB))
            {           // Comanda
                using (OdbcCommand comanda_cmbGradDidactic = new OdbcCommand())
                {
                    comanda_cmbGradDidactic.Connection = conexiune_cmbGradDidactic;
                    comanda_cmbGradDidactic.CommandType = CommandType.Text;
                    comanda_cmbGradDidactic.CommandText = "SELECT * FROM gradedidactice";

                    OdbcDataReader cititor_cmbGradDidactic;

                    try
                    {
                        conexiune_cmbGradDidactic.Open();
                        cititor_cmbGradDidactic = comanda_cmbGradDidactic.ExecuteReader();

                        // Daca cititorul
                        if (cititor_cmbGradDidactic.HasRows == false)
                        {
                            // Afisam de ce
                            tsStatusDeCeGD.Text = " Nu sunt denumiri de GRADE DIDACTICE introduse în baza de date. Introduceți-le! ";

                            // Setam
                            AprobareVerifGD = false;
                        }
                        else
                        {
                            // Stergem afisarea
                            tsStatusDeCeGD.Text = string.Empty;

                            // Setam
                            AprobareVerifGD = true;
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
        public void VerificareFacultati()
        {
            using (OdbcConnection conexiune_cmbFacultati = new OdbcConnection(sircon_RelIntDB))
            {           // Comanda
                using (OdbcCommand comanda_cmbFacultati = new OdbcCommand())
                {
                    comanda_cmbFacultati.Connection = conexiune_cmbFacultati;
                    comanda_cmbFacultati.CommandType = CommandType.Text;
                    comanda_cmbFacultati.CommandText = "SELECT * FROM facultati";

                    OdbcDataReader cititor_cmbFacultati;

                    try
                    {
                        conexiune_cmbFacultati.Open();
                        cititor_cmbFacultati = comanda_cmbFacultati.ExecuteReader();

                        // Daca cititorul
                        if (cititor_cmbFacultati.HasRows == false)
                        {
                            // Afisam de ce
                            tsStatusDeCeF.Text = " Nu sunt denumiri de FACULTĂȚI introduse în baza de date. Introduceți-le! ";

                            // Setam
                            AprobareVerifF = false;
                        }
                        else
                        {
                            // Stergem afisarea
                            tsStatusDeCeF.Text = string.Empty;

                            // Setam
                            AprobareVerifF = true;
                        }
                    }
                    catch (Exception excmbFacultati)
                    {
                        MessageBox.Show(excmbFacultati.Message);
                    } // Ne deconectam
                    finally
                    {
                        conexiune_cmbFacultati.Close();
                    }
                }
            }
        }
        /* --------------------------------------------------------------------------------------------------------------- */
        /* ---------- Metoda de umplere a cmbFacultate cu date din RelIntDB ---------------------------------------------- */
        public void VerificareMonezi()
        {
            using (OdbcConnection conexiune_cmbMonezi = new OdbcConnection(sircon_RelIntDB))
            {           // Comanda
                using (OdbcCommand comanda_cmbMonezi = new OdbcCommand())
                {
                    comanda_cmbMonezi.Connection = conexiune_cmbMonezi;
                    comanda_cmbMonezi.CommandType = CommandType.Text;
                    comanda_cmbMonezi.CommandText = "SELECT * FROM monezi";

                    OdbcDataReader cititor_cmbMonezi;

                    try
                    {
                        conexiune_cmbMonezi.Open();
                        cititor_cmbMonezi = comanda_cmbMonezi.ExecuteReader();

                        // Daca cititorul
                        if (cititor_cmbMonezi.HasRows == false)
                        {
                            // Afisam de ce
                            tsStatusDeCeM.Text = " Nu sunt denumiri de MONEDE introduse în baza de date. Introduceți-le! ";

                            // Setam
                            AprobareVerifM = false;
                        }
                        else
                        {
                            // Stergem afisarea
                            tsStatusDeCeM.Text = string.Empty;

                            // Setam
                            AprobareVerifM = true;
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
        /* --------------------------------------------------------------------------------------------------------------- */
        public void AprobareVerifDGFM()
        {
            if (AprobareVerifGD == true && AprobareVerifF == true && AprobareVerifM == true)
            {
                // Efectuam
                VerificareCereri();

                    // Apoi
                    if (ExistaCereri == true)
                    {
                        // Activam
                        btnGCDIntroducereFormular.Enabled = true;
                        btnGCDCautareCerere.Enabled = true;
                        btnGCDModificareFormular.Enabled = true;

                        btnGCDIntroducereODD.Enabled = true;
                        btnGCDModificareODD.Enabled = true;

                        btnGCDODZ.Enabled = true;

                        btnGCDVizualizareTot.Enabled = true;

                        // Stergem afisarea
                        tsStatusUltimaInregistrare.Text = string.Empty;
                    }
                    else
                    {
                        // Afisam de ce
                        tsStatusUltimaInregistrare.Text = " Nu sunt CERERI introduse în baza de date. Introduceți măcar una! ";

                        // Activam
                        btnGCDIntroducereFormular.Enabled = true;

                        // Dezactivam
                        btnGCDCautareCerere.Enabled = false;
                        btnGCDModificareFormular.Enabled = false;

                        btnGCDIntroducereODD.Enabled = false;
                        btnGCDModificareODD.Enabled = false;

                        btnGCDODZ.Enabled = false;

                        btnGCDVizualizareTot.Enabled = false;
                    }
            }
            else
            {
                VerificareGradeDidactice();
                VerificareFacultati();
                VerificareMonezi();

                if (AprobareVerifGD == true && AprobareVerifF == true && AprobareVerifM == true)
                {
                    // Efectuam
                    VerificareCereri();

                    // Apoi
                    if (ExistaCereri == true)
                    {
                        // Activam
                        btnGCDIntroducereFormular.Enabled = true;
                        btnGCDCautareCerere.Enabled = true;
                        btnGCDModificareFormular.Enabled = true;

                        btnGCDIntroducereODD.Enabled = true;
                        btnGCDModificareODD.Enabled = true;

                        btnGCDODZ.Enabled = true;

                        btnGCDVizualizareTot.Enabled = true;

                        // Stergem afisarea
                        tsStatusUltimaInregistrare.Text = string.Empty;
                    }
                    else
                    {
                        // Afisam de ce
                        tsStatusUltimaInregistrare.Text = " Nu sunt CERERI introduse în baza de date. Introduceți măcar una! ";

                        // Activam
                        btnGCDIntroducereFormular.Enabled = true;

                        // Dezactivam
                        btnGCDCautareCerere.Enabled = false;
                        btnGCDModificareFormular.Enabled = false;

                        btnGCDIntroducereODD.Enabled = false;
                        btnGCDModificareODD.Enabled = false;

                        btnGCDODZ.Enabled = false;

                        btnGCDVizualizareTot.Enabled = false;
                    }
                }
                else
                {
                    // Activam
                    btnGCDIntroducereFormular.Enabled = false;
                    btnGCDCautareCerere.Enabled = false;
                    btnGCDModificareFormular.Enabled = false;
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
                            // Setam
                            ExistaCereri = false;
                        }
                        else
                        {
                            // Setam
                            ExistaCereri = true;
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
        /* ------------------- Deschiderea formularului "DespreApp" ------------------------------------------------------ */
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
        /* ------------------ Deschiderea formularului "frmOrdineaDeZi" -------------------------------------------------- */
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
            Form frmVizualizareTot = new frmListaCereriExistente();

            // Facem "frmVizualizareTot" copil al "frmGCD"
            frmVizualizareTot.MdiParent = this;

            foreach (Form form in Application.OpenForms)
            {
                if (form.GetType() == typeof(frmListaCereriExistente))
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
        private void btnGCDIntroducereODD_Click(object sender, EventArgs e)
        {
            // Apelam formularul "frmCerereBECA"
            Form frmODDIntroducere = new frmODDIntroducere();

            // Facem "frmCerereBECA" copil al "frmGCD"
            frmODDIntroducere.MdiParent = this;

            foreach (Form form in Application.OpenForms)
            {
                if (form.GetType() == typeof(frmODDIntroducere))
                {
                    form.WindowState = FormWindowState.Normal;
                    form.Activate();
                    return;
                }
            }

            // Afisam "frmCerereBECA"
            frmODDIntroducere.Show();
        }
        /* --------------------------------------------------------------------------------------------------------------- */
        /* --------------------------------------------------------------------------------------------------------------- */
        private void btnGCDModificareODD_Click(object sender, EventArgs e)
        {
            // Apelam formularul "frmODDModificare"
            Form frmODDModificare = new frmODDModificare();

            // Facem "frmODDModificare" copil al "frmGCD"
            frmODDModificare.MdiParent = this;

            foreach (Form form in Application.OpenForms)
            {
                if (form.GetType() == typeof(frmODDModificare))
                {
                    form.WindowState = FormWindowState.Normal;
                    form.Activate();
                    return;
                }
            }

            // Afisam "frmCerereBECA"
            frmODDModificare.Show();
        }
        /* --------------------------------------------------------------------------------------------------------------- */
        /* ----------------- Deschiderea formularului frmTipuriIntrari --------------------------------------------------- */
        private void btnGCDTipIntrari_Click(object sender, EventArgs e)
        {
            // Apelam formularul "frmTipuriIntrari"
            Form frmTipuriIntrari = new frmEditTipuriIntrari();

            // Facem "frmTipuriIntrari" copil al "frmGCD"
            frmTipuriIntrari.MdiParent = this;

            foreach (Form form in Application.OpenForms)
            {
                if (form.GetType() == typeof(frmEditTipuriIntrari))
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
        /* ------------------ Deschiderea formularului frmEditareRector -------------------------------------------------- */
        private void btnGCDEditareRectori_Click(object sender, EventArgs e)
        {
            // Apelam formularul "frmEditareRector"
            Form frmEditareRector = new frmEditRectoriProrectori();

            // Facem "frmEditareRector" copil al "frmGCD"
            frmEditareRector.MdiParent = this;

            foreach (Form form in Application.OpenForms)
            {
                if (form.GetType() == typeof(frmEditRectoriProrectori))
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