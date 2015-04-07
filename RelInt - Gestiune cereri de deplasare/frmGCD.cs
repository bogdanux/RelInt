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
        public frmGCD() // Metoda de LOAD a frmGCD
        {
            InitializeComponent();
            MetodaScriereInStatus();
        }
        /* --------------------------------------------------------------------------------------------------------------- */










        /* ----------- Obiecte de lucru cu RelIntDB ---------------------------------------------------------------------- */
        // Sir de conectare al RelIntDB
        string sircon_RelIntDB = "DSN=PostgreSQL35W;database=RelIntDB;server=localhost;port=5432;UID=postgres;PWD=12345;sslmode=disable;readonly=0;protocol=7.4;fakeoidindex=0;showoidcolumn=0;rowversioning=0;showsystemtables=0;fetch=100;socket=4096;unknownsizes=0;maxvarcharsize=255;maxlongvarcharsize=8190;debug=0;commlog=0;optimizer=0;ksqo=1;usedeclarefetch=0;textaslongvarchar=1;unknownsaslongvarchar=0;boolsaschar=1;parse=0;cancelasfreestmt=0;extrasystableprefixes=dd_;lfconversion=1;updatablecursors=1;disallowpremature=0;trueisminus1=0;bi=0;byteaaslongvarbinary=0;useserversideprepare=1;lowercaseidentifier=0;gssauthusegss=0;xaopt=1;";

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














        /* -------------------- MetodaScriereInStatus -------------------------------------------------------------------- */
        private void MetodaScriereInStatus()
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
                            tsStatusUltimaInregistrare.Text = "Numarul ultimei cereri introduse: " + reader_lblUCI.GetInt32(0).ToString();
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











        /* ------------------- Eveniment de tip Click pentru update al Statusului ---------------------------------------- */
        private void frmGCD_Activated(object sender, EventArgs e)
        {
            MetodaScriereInStatus();
        }
        /* --------------------------------------------------------------------------------------------------------------- */
       }
    }