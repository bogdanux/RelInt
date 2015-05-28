using System;
using System.Data;
using System.Data.Odbc;
using System.IO;
using System.Windows.Forms;

namespace RelInt___Gestiune_cereri_de_deplasare
{
    public partial class frmResetareAplicatie : Form
    {
        public frmResetareAplicatie() // Metoda de LOAD
        {
            InitializeComponent();

            // Dezactivam
            panouActiuni.Enabled = false;
        }

        /* --------------------------------------------------------------------------------------------------------------- */






        /* ----------- Obiecte de lucru cu RelIntDB ---------------------------------------------------------------------- */
        // Sir de conectare al RelIntDB
        private string sircon_RelIntDB =
            "DSN=PostgreSQL35W;database=RelIntDB;server=localhost;port=5432;UID=postgres;PWD=12345;sslmode=disable;readonly=0;protocol=7.4;fakeoidindex=0;showoidcolumn=0;rowversioning=0;showsystemtables=0;fetch=100;socket=4096;unknownsizes=0;maxvarcharsize=255;maxlongvarcharsize=8190;debug=0;commlog=0;optimizer=0;ksqo=1;usedeclarefetch=0;textaslongvarchar=1;unknownsaslongvarchar=0;boolsaschar=1;parse=0;cancelasfreestmt=0;extrasystableprefixes=dd_;lfconversion=1;updatablecursors=1;disallowpremature=0;trueisminus1=0;bi=0;byteaaslongvarbinary=0;useserversideprepare=1;lowercaseidentifier=0;gssauthusegss=0;xaopt=1;";

        /* --------------------------------------------------------------------------------------------------------------- */






        private string parola = "AcademiaMihăileană1835";
        /* --------------------------------------------------------------------------------------------------------------- */

        private void btnIesire_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void chkDeAcord_CheckedChanged(object sender, EventArgs e)
        {
            if (chkDeAcord.Checked)
            {
                panouActiuni.Enabled = true;
                btnResetare.Enabled = false;
            }
            else
            {
                panouActiuni.Enabled = false;
            }
        }

        /* --------------------------------------------------------------------------------------------------------------- */





        /* --------------------------------------------------------------------------------------------------------------- */

        private void txtParola_TextChanged(object sender, EventArgs e)
        {
            if (txtParola.Text == parola)
            {
                btnResetare.Enabled = true;
            }
            else
            {
                btnResetare.Enabled = false;
            }
        }

        /* --------------------------------------------------------------------------------------------------------------- */





        /* --------------------------------------------------------------------------------------------------------------- */

        private void btnResetare_Click(object sender, EventArgs e)
        {
            // Verificam daca computerul este de tip x86 sau x64
            if (Directory.Exists("C:\\Program Files (x86)"))
            {
                // Conexiunea
                using (OdbcConnection conexiune_InserareCerereRelInt = new OdbcConnection(sircon_RelIntDB))
                {
                    // Comanda
                    using (OdbcCommand comanda_inserareRelInt = new OdbcCommand())
                    {
                        string scriptresetare =
                            File.ReadAllText(@"C:\Program Files (x86)\SIA-FEAA\RelInt-GCdD\RelIntBD-CRPO.sql");
                        comanda_inserareRelInt.Connection = conexiune_InserareCerereRelInt;
                        comanda_inserareRelInt.CommandType = CommandType.Text;
                        comanda_inserareRelInt.CommandText = scriptresetare;

                        // Incercam conexiunea si query-ul
                        try
                        {
                            conexiune_InserareCerereRelInt.Open();
                            int recordsAffected = comanda_inserareRelInt.ExecuteNonQuery();

                            // Afisam mesaj informativ
                            MessageBox.Show("Baza de Date \"RelIntDB\" a fost reinițializată cu succes!", "Succes",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);

                            // Dezactivam
                            panouAtentie.Enabled = false;
                            panouActiuni.Enabled = false;
                        }

                            // Captam eventualele erori
                        catch (OdbcException exInserare)
                        {
                            // Afisam eroarea
                            MessageBox.Show(exInserare.Message);
                        }

                            // Ne deconectam
                        finally
                        {
                            conexiune_InserareCerereRelInt.Close();
                        }
                    }
                }
            }
            else
            {
                // Conexiunea
                using (OdbcConnection conexiune_InserareCerereRelInt = new OdbcConnection(sircon_RelIntDB))
                {
                    // Comanda
                    using (OdbcCommand comanda_inserareRelInt = new OdbcCommand())
                    {
                        string scriptresetare =
                            File.ReadAllText(@"C:\Program Files\SIA-FEAA\RelInt-GCdD\RelIntBD-CRPO.sql");
                        comanda_inserareRelInt.Connection = conexiune_InserareCerereRelInt;
                        comanda_inserareRelInt.CommandType = CommandType.Text;
                        comanda_inserareRelInt.CommandText = scriptresetare;

                        // Incercam conexiunea si query-ul
                        try
                        {
                            conexiune_InserareCerereRelInt.Open();
                            int recordsAffected = comanda_inserareRelInt.ExecuteNonQuery();

                            // Afisam mesaj informativ
                            MessageBox.Show("Baza de Date \"RelIntDB\" a fost reinițializată cu succes!", "Succes",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);

                            // Dezactivam
                            panouAtentie.Enabled = false;
                            panouActiuni.Enabled = false;
                        }

                            // Captam eventualele erori
                        catch (OdbcException exInserare)
                        {
                            // Afisam eroarea
                            MessageBox.Show(exInserare.Message);
                        }

                            // Ne deconectam
                        finally
                        {
                            conexiune_InserareCerereRelInt.Close();
                        }
                    }
                }
            }



            // Efectuam (pentru frmGCD)
            if (System.Windows.Forms.Application.OpenForms["frmGCD"] != null)
            {
                (System.Windows.Forms.Application.OpenForms["frmGCD"] as frmGCD).VerificareGradeDidactice();
            }

            if (System.Windows.Forms.Application.OpenForms["frmGCD"] != null)
            {
                (System.Windows.Forms.Application.OpenForms["frmGCD"] as frmGCD).VerificareFacultati();
            }

            if (System.Windows.Forms.Application.OpenForms["frmGCD"] != null)
            {
                (System.Windows.Forms.Application.OpenForms["frmGCD"] as frmGCD).VerificareMonezi();
            }

            if (System.Windows.Forms.Application.OpenForms["frmGCD"] != null)
            {
                (System.Windows.Forms.Application.OpenForms["frmGCD"] as frmGCD).VerificareTari();
            }

            if (System.Windows.Forms.Application.OpenForms["frmGCD"] != null)
            {
                (System.Windows.Forms.Application.OpenForms["frmGCD"] as frmGCD).VerificareScopuri();
            }

            if (System.Windows.Forms.Application.OpenForms["frmGCD"] != null)
            {
                (System.Windows.Forms.Application.OpenForms["frmGCD"] as frmGCD).MetodaScriereInStatusUC();
            }

            if (System.Windows.Forms.Application.OpenForms["frmGCD"] != null)
            {
                (System.Windows.Forms.Application.OpenForms["frmGCD"] as frmGCD).VerificareRector();
            }

            if (System.Windows.Forms.Application.OpenForms["frmGCD"] != null)
            {
                (System.Windows.Forms.Application.OpenForms["frmGCD"] as frmGCD).VerificareProrector();
            }

            if (System.Windows.Forms.Application.OpenForms["frmGCD"] != null)
            {
                (System.Windows.Forms.Application.OpenForms["frmGCD"] as frmGCD).MetodaScriereInStatusR();
            }

            // Efectuam (pentru frmCerereInregistrare)
            if (System.Windows.Forms.Application.OpenForms["frmCerereInregistrare"] != null)
            {
                (System.Windows.Forms.Application.OpenForms["frmCerereInregistrare"] as frmCerereInregistrare)
                    .UmplereGradDidactic();
            }

            if (System.Windows.Forms.Application.OpenForms["frmCerereInregistrare"] != null)
            {
                (System.Windows.Forms.Application.OpenForms["frmCerereInregistrare"] as frmCerereInregistrare)
                    .UmplereFacultate();
            }

            if (System.Windows.Forms.Application.OpenForms["frmCerereInregistrare"] != null)
            {
                (System.Windows.Forms.Application.OpenForms["frmCerereInregistrare"] as frmCerereInregistrare)
                    .UmplereMonezi();
            }

            if (System.Windows.Forms.Application.OpenForms["frmCerereInregistrare"] != null)
            {
                (System.Windows.Forms.Application.OpenForms["frmCerereInregistrare"] as frmCerereInregistrare)
                    .UmplereTari();
            }

            if (System.Windows.Forms.Application.OpenForms["frmCerereInregistrare"] != null)
            {
                (System.Windows.Forms.Application.OpenForms["frmCerereInregistrare"] as frmCerereInregistrare)
                    .UmplereScop();
            }

            // Efectuam (pentru frmCerereModificare)
            if (System.Windows.Forms.Application.OpenForms["frmCerereModificare"] != null)
            {
                (System.Windows.Forms.Application.OpenForms["frmCerereModificare"] as frmCerereModificare)
                    .UmplereGradDidactic();
            }

            if (System.Windows.Forms.Application.OpenForms["frmCerereModificare"] != null)
            {
                (System.Windows.Forms.Application.OpenForms["frmCerereModificare"] as frmCerereModificare)
                    .UmplereFacultate();
            }

            if (System.Windows.Forms.Application.OpenForms["frmCerereModificare"] != null)
            {
                (System.Windows.Forms.Application.OpenForms["frmCerereModificare"] as frmCerereModificare).UmplereMonezi
                    ();
            }

            if (System.Windows.Forms.Application.OpenForms["frmCerereModificare"] != null)
            {
                (System.Windows.Forms.Application.OpenForms["frmCerereModificare"] as frmCerereModificare).UmplereTari();
            }

            if (System.Windows.Forms.Application.OpenForms["frmCerereModificare"] != null)
            {
                (System.Windows.Forms.Application.OpenForms["frmCerereModificare"] as frmCerereModificare).UmplereScop();
            }

            // Efectuam (pentru frmODDIntroducere)
            if (System.Windows.Forms.Application.OpenForms["frmODDIntroducere"] != null)
            {
                (System.Windows.Forms.Application.OpenForms["frmODDIntroducere"] as frmODDIntroducere)
                    .UmplereGradDidactic();
            }

            if (System.Windows.Forms.Application.OpenForms["frmODDIntroducere"] != null)
            {
                (System.Windows.Forms.Application.OpenForms["frmODDIntroducere"] as frmODDIntroducere).UmplereFacultate();
            }

            if (System.Windows.Forms.Application.OpenForms["frmODDIntroducere"] != null)
            {
                (System.Windows.Forms.Application.OpenForms["frmODDIntroducere"] as frmODDIntroducere).UmplereMonezi();
            }

            if (System.Windows.Forms.Application.OpenForms["frmODDIntroducere"] != null)
            {
                (System.Windows.Forms.Application.OpenForms["frmODDIntroducere"] as frmODDIntroducere).UmplereTari();
            }

            if (System.Windows.Forms.Application.OpenForms["frmODDIntroducere"] != null)
            {
                (System.Windows.Forms.Application.OpenForms["frmODDIntroducere"] as frmODDIntroducere).UmplereScop();
            }

            // Efectuam (pentru frmODDModificare)
            if (System.Windows.Forms.Application.OpenForms["frmODDModificare"] != null)
            {
                (System.Windows.Forms.Application.OpenForms["frmODDModificare"] as frmODDModificare).UmplereGradDidactic
                    ();
            }

            if (System.Windows.Forms.Application.OpenForms["frmODDModificare"] != null)
            {
                (System.Windows.Forms.Application.OpenForms["frmODDModificare"] as frmODDModificare).UmplereFacultate();
            }

            if (System.Windows.Forms.Application.OpenForms["frmODDModificare"] != null)
            {
                (System.Windows.Forms.Application.OpenForms["frmODDModificare"] as frmODDModificare).UmplereMonezi();
            }

            if (System.Windows.Forms.Application.OpenForms["frmODDModificare"] != null)
            {
                (System.Windows.Forms.Application.OpenForms["frmODDModificare"] as frmODDModificare).UmplereTari();
            }

            if (System.Windows.Forms.Application.OpenForms["frmODDModificare"] != null)
            {
                (System.Windows.Forms.Application.OpenForms["frmODDModificare"] as frmODDModificare).UmplereScop();
            }
        }

        /* --------------------------------------------------------------------------------------------------------------- */





    }
}