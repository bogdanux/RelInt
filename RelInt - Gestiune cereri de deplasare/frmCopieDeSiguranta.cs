using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace RelInt___Gestiune_cereri_de_deplasare
{
    public partial class frmCopieDeSiguranta : Form
    {
        public frmCopieDeSiguranta() // Metoda de LOAD
        {
            InitializeComponent();
        }
        /* --------------------------------------------------------------------------------------------------------------- */






        /* ----------- Obiecte de lucru cu RelIntDB ---------------------------------------------------------------------- */
        // Sir de conectare al RelIntDB
        string sircon_RelIntDB = "DSN=PostgreSQL35W;database=RelIntDB;server=localhost;port=5432;UID=postgres;PWD=12345;sslmode=disable;readonly=0;protocol=7.4;fakeoidindex=0;showoidcolumn=0;rowversioning=0;showsystemtables=0;fetch=100;socket=4096;unknownsizes=0;maxvarcharsize=255;maxlongvarcharsize=8190;debug=0;commlog=0;optimizer=0;ksqo=1;usedeclarefetch=0;textaslongvarchar=1;unknownsaslongvarchar=0;boolsaschar=1;parse=0;cancelasfreestmt=0;extrasystableprefixes=dd_;lfconversion=1;updatablecursors=1;disallowpremature=0;trueisminus1=0;bi=0;byteaaslongvarbinary=0;useserversideprepare=1;lowercaseidentifier=0;gssauthusegss=0;xaopt=1;";

        /* --------------------------------------------------------------------------------------------------------------- */






        
        /* --------------------------------------------------------------------------------------------------------------- */
        private void btnIesire_Click(object sender, EventArgs e)
        {
            Close();
        }
        /* --------------------------------------------------------------------------------------------------------------- */






        /* --------------------------------------------------------------------------------------------------------------- */
        private void MetodaCS()
        {
            var locatie = "%USERPROFILE%\\Desktop\\CopieDeSiguranta-RelInt\\";
            var locatie_tradusa = Environment.ExpandEnvironmentVariables(locatie);

            if (!Directory.Exists(locatie_tradusa))
            {
                string comanda_crearedosar = "mkdir %USERPROFILE%\\Desktop\\CopieDeSiguranta-RelInt";
                Process process_crearedosar = new Process();
                ProcessStartInfo startInfo_crearedosar = new ProcessStartInfo();
                startInfo_crearedosar.WindowStyle = ProcessWindowStyle.Hidden;
                startInfo_crearedosar.FileName = "cmd.exe";
                startInfo_crearedosar.Arguments = "/user:Administrator cmd /K" + comanda_crearedosar;
                startInfo_crearedosar.CreateNoWindow = false;
                process_crearedosar.StartInfo = startInfo_crearedosar;
                process_crearedosar.Start();
                Directory.CreateDirectory(locatie_tradusa);

                try
                {
                    // Scriem Fisierul
                    string comanda_CopieDeSiguranta = "\"C:\\Program Files\\PostgreSQL\\9.4\\bin\\pg_dump.exe\" -U postgres RelIntDB > %USERPROFILE%\\Desktop\\CopieDeSiguranta-RelInt\\CopieSiguranta-RelIntDB.sql";
                    Process processCopieDeSiguranta = new Process();
                    ProcessStartInfo startInfo_CopieDeSiguranta = new ProcessStartInfo();
                    startInfo_CopieDeSiguranta.WindowStyle = ProcessWindowStyle.Hidden;
                    startInfo_CopieDeSiguranta.FileName = "cmd.exe";
                    startInfo_CopieDeSiguranta.Arguments = "/user:Administrator cmd /K" + comanda_CopieDeSiguranta;
                    startInfo_CopieDeSiguranta.CreateNoWindow = false;
                    processCopieDeSiguranta.StartInfo = startInfo_CopieDeSiguranta;
                    processCopieDeSiguranta.Start();

                    // Afisam
                    MessageBox.Show("Backup-ul a fost realizat cu succes!", "Succes", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Deschidem
                    Process.Start(locatie_tradusa);
                }
                catch (Exception exCopieDeSiguranta)
                {
                    MessageBox.Show(exCopieDeSiguranta.Message);
                }
            }
        }
        /* --------------------------------------------------------------------------------------------------------------- */







        /* --------------------------------------------------------------------------------------------------------------- */
        private void button1_Click(object sender, EventArgs e)
        {
            MetodaCS();
        }
        /* --------------------------------------------------------------------------------------------------------------- */








        private void llblInformatie4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var locatie = "%USERPROFILE%\\Desktop\\CopieDeSiguranta-RelInt\\";
            var locatie_tradusa = Environment.ExpandEnvironmentVariables(locatie);

            if (Directory.Exists(locatie_tradusa))
            {
                // Deschidem
                Process.Start(locatie_tradusa);
            }
            else
            {
                // Informam ca nu s-a facut nici o copie de siguranta inca
                MessageBox.Show("Nu a fost facută nici o copie de siguranță deocamdată!\n      Efectuați mai întâi o copie de siguranță.", "Informație", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }






    }
}
