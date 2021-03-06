﻿using System;
using System.Data;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Windows.Forms;
using System.Data.Odbc;

namespace RelInt___Gestiune_cereri_de_deplasare
{
    public partial class frmGCD : Form
    {
        public frmGCD() // Metoda de LOAD
        {
            InitializeComponent();

            // Necesare pentru Cereri
            VerificareGradeDidactice();
            VerificareFacultati();
            VerificareMonezi();
            VerificareTari();
            VerificareScopuri();

            AprobareVerifGDFMTSCA();

            MetodaScriereInStatusUC();

            // Necesare pentru ODD
            VerificareRector();
            VerificareProrector();
            VerificareCOS();
            VerificareODP();
            VerificareDFC();

            AprobareVerifRPCOD();

            MetodaScriereInStatusR();
            MetodaScriereInStatusD();
        }
        /* --------------------------------------------------------------------------------------------------------------- */










        /* ----------- Obiecte de lucru cu RelIntDB ---------------------------------------------------------------------- */
        // Sir de conectare al RelIntDB
        string sircon_RelIntDB = "DSN=PostgreSQL35W;database=RelIntDB;server=localhost;port=5432;UID=postgres;PWD=12345;sslmode=disable;readonly=0;protocol=7.4;fakeoidindex=0;showoidcolumn=0;rowversioning=0;showsystemtables=0;fetch=100;socket=4096;unknownsizes=0;maxvarcharsize=255;maxlongvarcharsize=8190;debug=0;commlog=0;optimizer=0;ksqo=1;usedeclarefetch=0;textaslongvarchar=1;unknownsaslongvarchar=0;boolsaschar=1;parse=0;cancelasfreestmt=0;extrasystableprefixes=dd_;lfconversion=1;updatablecursors=1;disallowpremature=0;trueisminus1=0;bi=0;byteaaslongvarbinary=0;useserversideprepare=1;lowercaseidentifier=0;gssauthusegss=0;xaopt=1;";

        /* --------------------------------------------------------------------------------------------------------------- */










        bool AprobareVerifGD;
        bool AprobareVerifF;
        bool AprobareVerifM;
        bool AprobareVerifT;
        bool AprobareVerifS;
        bool ExistaCereri;
        /* ------------------- Metoda verificare gradedidactice ---------------------------------------------------------- */
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
        /* ---------- Metoda verificare facultati ------------------------------------------------------------------------ */
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
        /* ---------- Metoda verificare monezi --------------------------------------------------------------------------- */
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
        /* ------------ Metoda de verificare daca sunt introduse tari ---------------------------------------------------- */
        public void VerificareTari()
        {
            using (OdbcConnection conexiune_Tari = new OdbcConnection(sircon_RelIntDB))
            {           // Comanda
                using (OdbcCommand comanda_Tari = new OdbcCommand())
                {
                    comanda_Tari.Connection = conexiune_Tari;
                    comanda_Tari.CommandType = CommandType.Text;
                    comanda_Tari.CommandText = "SELECT * FROM tari";

                    OdbcDataReader cititor_Tari;

                    try
                    {
                        conexiune_Tari.Open();
                        cititor_Tari = comanda_Tari.ExecuteReader();

                        // Daca cititorul
                        if (cititor_Tari.HasRows == false)
                        {
                            // Afisam de ce
                            tsStatusDeCeT.Text = " Nu sunt ȚĂRI introduse în baza de date. Introduceți-le! ";

                            // Setam
                            AprobareVerifT = false;
                        }
                        else
                        {
                            // Stergem afisarea
                            tsStatusDeCeT.Text = string.Empty;

                            // Setam
                            AprobareVerifT = true;
                        }
                    }
                    catch (Exception exTari)
                    {
                        MessageBox.Show(exTari.Message);
                    } // Ne deconectam
                    finally
                    {
                        conexiune_Tari.Close();
                    }
                }
            }
        }
        /* --------------------------------------------------------------------------------------------------------------- */
        /* ------------ Metoda de verificare daca sunt introduse scopuri ------------------------------------------------- */
        public void VerificareScopuri()
        {
            using (OdbcConnection conexiune_Scopuri = new OdbcConnection(sircon_RelIntDB))
            {           // Comanda
                using (OdbcCommand comanda_Scopuri = new OdbcCommand())
                {
                    comanda_Scopuri.Connection = conexiune_Scopuri;
                    comanda_Scopuri.CommandType = CommandType.Text;
                    comanda_Scopuri.CommandText = "SELECT * FROM scopuri";

                    OdbcDataReader cititor_Scopuri;

                    try
                    {
                        conexiune_Scopuri.Open();
                        cititor_Scopuri = comanda_Scopuri.ExecuteReader();

                        // Daca cititorul
                        if (cititor_Scopuri.HasRows == false)
                        {
                            // Afisam de ce
                            tsStatusDeCeS.Text = " Nu sunt SCOPURI introduse în baza de date. Introduceți-le! ";

                            // Setam
                            AprobareVerifS = false;
                        }
                        else
                        {
                            // Stergem afisarea
                            tsStatusDeCeS.Text = string.Empty;

                            // Setam
                            AprobareVerifS = true;
                        }
                    }
                    catch (Exception exScopuri)
                    {
                        MessageBox.Show(exScopuri.Message);
                    } // Ne deconectam
                    finally
                    {
                        conexiune_Scopuri.Close();
                    }
                }
            }
        }
        /* --------------------------------------------------------------------------------------------------------------- */
        /* ---------- Metoda verificare cereri --------------------------------------------------------------------------- */
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
                    catch (Exception exCereri)
                    {
                        MessageBox.Show(exCereri.Message);
                    } // Ne deconectam
                    finally
                    {
                        conexiune_cereri.Close();
                    }
                }
            }
        }
        /* --------------------------------------------------------------------------------------------------------------- */
        /* --------------------------------------------------------------------------------------------------------------- */
        public void AprobareVerifGDFMTSCA()
        {
            if (AprobareVerifGD
                && AprobareVerifF
                && AprobareVerifM
                && AprobareVerifT
                && AprobareVerifS)
            {
                AprobareVerifRPCOD();
                VerificareCereri();

                if (ExistaCereri)
                {
                    // Activam
                    btnGCDCautareCerere.Enabled = true;
                    btnGCDModificareFormular.Enabled = true;

                    btnGCDODZ.Enabled = true;

                    btnGCDListaCereriExistente.Enabled = true;

                    // Stergem afisarea
                    tsStatusUltimaInregistrare.Text = string.Empty;
                }
                else
                {
                    // Activam
                    btnGCDIntroducereFormular.Enabled = true;

                    // Dezactivam
                    btnGCDCautareCerere.Enabled = false;
                    btnGCDModificareFormular.Enabled = false;

                    btnGCDODZ.Enabled = false;

                    btnGCDListaCereriExistente.Enabled = false;

                    // Afisam de ce
                    tsStatusUltimaInregistrare.Text =
                        " Nu sunt CERERI introduse în baza de date. Introduceți măcar una! ";
                }
            }
            else
            {
                // Dezactivam
                btnGCDIntroducereFormular.Enabled = false;
                btnGCDCautareCerere.Enabled = false;
                btnGCDModificareFormular.Enabled = false;

                btnGCDODZ.Enabled = false;

                btnGCDListaCereriExistente.Enabled = false;

                btnGCDIntroducereODD.Enabled = false;
                btnGCDModificareODD.Enabled = false;
                btnGCDListaOrdineDeDeplasare.Enabled = false;

                tsStatusRectorCurent.Text = string.Empty;
                tsStatusUltimaInregistrare.Text = string.Empty;
            }
        }
        /* --------------------------------------------------------------------------------------------------------------- */
        /* -------------------- MetodaScriereInStatus -------------------------------------------------------------------- */
        public void MetodaScriereInStatusUC()
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


        bool AprobareVerifR;
        bool AprobareVerifPR;
        bool AprobareVerifD;
        bool AprobareVerifC;
        bool AprobareVerifO;
        /* ------------ Metoda de verificare daca sunt introdusi Rectori ------------------------------------------------- */
        public void VerificareRector()
        {
            using (OdbcConnection conexiune_Rectori = new OdbcConnection(sircon_RelIntDB))
            {           // Comanda
                using (OdbcCommand comanda_Rectori = new OdbcCommand())
                {
                    comanda_Rectori.Connection = conexiune_Rectori;
                    comanda_Rectori.CommandType = CommandType.Text;
                    comanda_Rectori.CommandText = "SELECT * FROM rectori";

                    OdbcDataReader cititor_Rectori;

                    try
                    {
                        conexiune_Rectori.Open();
                        cititor_Rectori = comanda_Rectori.ExecuteReader();

                        // Daca cititorul
                        if (cititor_Rectori.HasRows == false)
                        {
                            // Afisam de ce
                            tsStatusDeCeR.Text = " Nu sunt RECTORI introduși în baza de date. Introduceți-i! ";

                            // Setam
                            AprobareVerifR = false;
                        }
                        else
                        {
                            // Stergem afisarea
                            tsStatusDeCeR.Text = string.Empty;

                            // Setam
                            AprobareVerifR = true;
                        }
                    }
                    catch (Exception exRectori)
                    {
                        MessageBox.Show(exRectori.Message);
                    } // Ne deconectam
                    finally
                    {
                        conexiune_Rectori.Close();
                    }
                }
            }
        }
        /* --------------------------------------------------------------------------------------------------------------- */
        /* ------------ Metoda de verificare daca sunt introdusi Prorectori ---------------------------------------------- */
        public void VerificareProrector()
        {
            using (OdbcConnection conexiune_Prorectori = new OdbcConnection(sircon_RelIntDB))
            {           // Comanda
                using (OdbcCommand comanda_Prorectori = new OdbcCommand())
                {
                    comanda_Prorectori.Connection = conexiune_Prorectori;
                    comanda_Prorectori.CommandType = CommandType.Text;
                    comanda_Prorectori.CommandText = "SELECT * FROM prorectori";

                    OdbcDataReader cititor_Prorectori;

                    try
                    {
                        conexiune_Prorectori.Open();
                        cititor_Prorectori = comanda_Prorectori.ExecuteReader();

                        // Daca cititorul
                        if (cititor_Prorectori.HasRows == false)
                        {
                            // Afisam de ce
                            tsStatusDeCePR.Text = " Nu sunt PRORECTORI introduși în baza de date. Introduceți-i! ";

                            // Setam
                            AprobareVerifPR = false;
                        }
                        else
                        {
                            // Stergem afisarea
                            tsStatusDeCePR.Text = string.Empty;

                            // Setam
                            AprobareVerifPR = true;
                        }
                    }
                    catch (Exception exProrectori)
                    {
                        MessageBox.Show(exProrectori.Message);
                    } // Ne deconectam
                    finally
                    {
                        conexiune_Prorectori.Close();
                    }
                }
            }
        }
        /* --------------------------------------------------------------------------------------------------------------- */
        /* ------------ Metoda de verificare daca sunt introduse scopuri ------------------------------------------------- */
        public void VerificareCOS()
        {
            using (OdbcConnection conexiune_COS = new OdbcConnection(sircon_RelIntDB))
            {           // Comanda
                using (OdbcCommand comanda_COS = new OdbcCommand())
                {
                    comanda_COS.Connection = conexiune_COS;
                    comanda_COS.CommandType = CommandType.Text;
                    comanda_COS.CommandText = "SELECT * FROM cos";

                    OdbcDataReader cititor_COS;

                    try
                    {
                        conexiune_COS.Open();
                        cititor_COS = comanda_COS.ExecuteReader();

                        // Daca cititorul
                        if (cititor_COS.HasRows == false)
                        {
                            // Afisam de ce
                            tsStatusDeCeC.Text = " Nu este introdusă \"specificația nr. 3\" pentru Ordinele de deplasare! ";

                            // Setam
                            AprobareVerifC = false;
                        }
                        else
                        {
                            // Stergem afisarea
                            tsStatusDeCeC.Text = string.Empty;

                            // Setam
                            AprobareVerifC = true;
                        }
                    }
                    catch (Exception exCOS)
                    {
                        MessageBox.Show(exCOS.Message);
                    } // Ne deconectam
                    finally
                    {
                        conexiune_COS.Close();
                    }
                }
            }
        }
        /* --------------------------------------------------------------------------------------------------------------- */
        /* ------------ Metoda de verificare daca sunt introduse scopuri ------------------------------------------------- */
        public void VerificareODP()
        {
            using (OdbcConnection conexiune_ODP = new OdbcConnection(sircon_RelIntDB))
            {           // Comanda
                using (OdbcCommand comanda_ODP = new OdbcCommand())
                {
                    comanda_ODP.Connection = conexiune_ODP;
                    comanda_ODP.CommandType = CommandType.Text;
                    comanda_ODP.CommandText = "SELECT * FROM odp";

                    OdbcDataReader cititor_ODP;

                    try
                    {
                        conexiune_ODP.Open();
                        cititor_ODP = comanda_ODP.ExecuteReader();

                        // Daca cititorul
                        if (cititor_ODP.HasRows == false)
                        {
                            // Afisam de ce
                            tsStatusDeCeO.Text = " Nu este introdusă \"specificația nr. 4\" pentru Ordinele de deplasare! ";

                            // Setam
                            AprobareVerifO = false;
                        }
                        else
                        {
                            // Stergem afisarea
                            tsStatusDeCeO.Text = string.Empty;

                            // Setam
                            AprobareVerifO = true;
                        }
                    }
                    catch (Exception exODP)
                    {
                        MessageBox.Show(exODP.Message);
                    } // Ne deconectam
                    finally
                    {
                        conexiune_ODP.Close();
                    }
                }
            }
        }
        /* --------------------------------------------------------------------------------------------------------------- */
        /* ------------ Metoda de verificare daca sunt introduse scopuri ------------------------------------------------- */
        public void VerificareDFC()
        {
            using (OdbcConnection conexiune_DFC = new OdbcConnection(sircon_RelIntDB))
            {           // Comanda
                using (OdbcCommand comanda_DFC = new OdbcCommand())
                {
                    comanda_DFC.Connection = conexiune_DFC;
                    comanda_DFC.CommandType = CommandType.Text;
                    comanda_DFC.CommandText = "SELECT * FROM dfc";

                    OdbcDataReader cititor_DFC;

                    try
                    {
                        conexiune_DFC.Open();
                        cititor_DFC = comanda_DFC.ExecuteReader();

                        // Daca cititorul
                        if (cititor_DFC.HasRows == false)
                        {
                            // Afisam de ce
                            tsStatusDeCeD.Text = " Nu sunt DFC introduși în baza de date. Introduceți-i! ";

                            // Setam
                            AprobareVerifD = false;
                        }
                        else
                        {
                            // Stergem afisarea
                            tsStatusDeCeD.Text = string.Empty;

                            // Setam
                            AprobareVerifD = true;
                        }
                    }
                    catch (Exception exDFC)
                    {
                        MessageBox.Show(exDFC.Message);
                    } // Ne deconectam
                    finally
                    {
                        conexiune_DFC.Close();
                    }
                }
            }
        }
        /* --------------------------------------------------------------------------------------------------------------- */
        /* --------------------------------------------------------------------------------------------------------------- */
        public void AprobareVerifRPCOD()
        {
            if (AprobareVerifR && AprobareVerifPR && AprobareVerifD && AprobareVerifC && AprobareVerifO)
            {
                // Activam
                btnGCDIntroducereODD.Enabled = true;
                btnGCDModificareODD.Enabled = true;

                btnGCDListaOrdineDeDeplasare.Enabled = true;
            }
            else
            {
                // Dezactivam
                btnGCDIntroducereODD.Enabled = false;
                btnGCDModificareODD.Enabled = false;

                btnGCDListaOrdineDeDeplasare.Enabled = false;
            }
        }
        /* --------------------------------------------------------------------------------------------------------------- */
        /* -------------------- Scriem in status numele rectorului curent in functie ------------------------------------- */
        public void MetodaScriereInStatusR()
        {
            using (OdbcConnection conexiune_ScriereStatusR = new OdbcConnection(sircon_RelIntDB))
            {           // Comanda
                using (OdbcCommand comanda_ScriereStatusR = new OdbcCommand())
                {
                    comanda_ScriereStatusR.Connection = conexiune_ScriereStatusR;
                    comanda_ScriereStatusR.CommandType = CommandType.Text;
                    comanda_ScriereStatusR.CommandText = "SELECT rector FROM rectori WHERE rectorcurent = ?";
                    comanda_ScriereStatusR.Parameters.AddWithValue("@rectorcurent", OdbcType.Bit).Value = true;

                    OdbcDataReader cititor_ScriereStatusR;

                    try
                    {
                        conexiune_ScriereStatusR.Open();
                        cititor_ScriereStatusR = comanda_ScriereStatusR.ExecuteReader();

                        while (cititor_ScriereStatusR.Read())
                        {
                            tsStatusRectorCurent.Text = "Rector curent: " + cititor_ScriereStatusR.GetString(0);
                        }
                    }
                    catch (Exception exR)
                    {
                        MessageBox.Show(exR.Message);
                    } // Ne deconectam
                    finally
                    {
                        conexiune_ScriereStatusR.Close();
                    }
                }
            }
        }
        /* --------------------------------------------------------------------------------------------------------------- */
        /* -------------------- Scriem in status numele rectorului curent in functie ------------------------------------- */
        public void MetodaScriereInStatusD()
        {
            using (OdbcConnection conexiune_ScriereStatusD = new OdbcConnection(sircon_RelIntDB))
            {           // Comanda
                using (OdbcCommand comanda_ScriereStatusD = new OdbcCommand())
                {
                    comanda_ScriereStatusD.Connection = conexiune_ScriereStatusD;
                    comanda_ScriereStatusD.CommandType = CommandType.Text;
                    comanda_ScriereStatusD.CommandText = "SELECT dfcd FROM dfc";

                    OdbcDataReader cititor_ScriereStatusD;

                    try
                    {
                        conexiune_ScriereStatusD.Open();
                        cititor_ScriereStatusD = comanda_ScriereStatusD.ExecuteReader();

                        while (cititor_ScriereStatusD.Read())
                        {
                            tsStatusDFCCurent.Text = "DFC curent: " + cititor_ScriereStatusD.GetString(0);
                        }
                    }
                    catch (Exception exD)
                    {
                        MessageBox.Show(exD.Message);
                    } // Ne deconectam
                    finally
                    {
                        conexiune_ScriereStatusD.Close();
                    }
                }
            }
        }
        /* --------------------------------------------------------------------------------------------------------------- */





        


        /* ------------------- Evenimentul click al butonului "mnuIesire" ------------------------------------------------ */
        private void mnuIesire_Click(object sender, EventArgs e)
        {
            Close();
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
        /* ------------------------ Deschiderea formularului frmListaCereriExistente ------------------------------------- */
        private void btnGCDListaCereriExistente_Click(object sender, EventArgs e)
        {
            // Apelam formularul "frmVizualizareTot"
            Form frmListaCereriExistente = new frmListaCereriExistente();

            // Facem "frmVizualizareTot" copil al "frmGCD"
            frmListaCereriExistente.MdiParent = this;

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
            frmListaCereriExistente.Show();
        }
        /* --------------------------------------------------------------------------------------------------------------- */
        /* ------------------------ Deschiderea formularului frmListaODDExistente ---------------------------------------- */
        private void btnGCDListaOrdineDeDeplasare_Click(object sender, EventArgs e)
        {
            // Apelam formularul "frmVizualizareTot"
            Form frmListaODDExistente = new frmListaODDExistente();

            // Facem "frmVizualizareTot" copil al "frmGCD"
            frmListaODDExistente.MdiParent = this;

            foreach (Form form in Application.OpenForms)
            {
                if (form.GetType() == typeof(frmListaODDExistente))
                {
                    form.WindowState = FormWindowState.Normal;
                    form.Activate();
                    return;
                }
            }

            // Afisam "frmVizualizareTot"
            frmListaODDExistente.Show();
        }
        /* --------------------------------------------------------------------------------------------------------------- */
        /* --------------------- Deschiderea formularului frmRapoarte ---------------------------------------------------- */
        private void mnuRapoarte_Click(object sender, EventArgs e)
        {
            // Apelam formularul "frmRaportCereri"
            Form frmRapoarte = new frmSituatieDeplasari();

            // Facem "frmRaportCereri" copil al "frmGCD"
            frmRapoarte.MdiParent = this;

            foreach (Form form in Application.OpenForms)
            {
                if (form.GetType() == typeof(frmSituatieDeplasari))
                {
                    form.WindowState = FormWindowState.Normal;
                    form.Activate();
                    return;
                }
            }

            // Afisam "frmRaportCereri"
            frmRapoarte.Show();
        }
        /* --------------------------------------------------------------------------------------------------------------- */
        /* ---------------------- Deschiderea formularului frmCerereBECA ------------------------------------------------- */
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
        /* ------------------- Deschiderea formularului frmResetareAplicatie --------------------------------------------- */
        private void btnResetare_Click(object sender, EventArgs e)
        {
            // Apelam formularul "frmResetareAplicatie"
            Form frmResetareAplicatie = new frmResetareAplicatie();

            // Facem "frmResetareAplicatie" copil al "frmGCD"
            frmResetareAplicatie.MdiParent = this;

            foreach (Form form in Application.OpenForms)
            {
                if (form.GetType() == typeof(frmResetareAplicatie))
                {
                    form.WindowState = FormWindowState.Normal;
                    form.Activate();
                    return;
                }
            }

            // Afisam "frmEditareRector"
            frmResetareAplicatie.Show();
        }
        /* --------------------------------------------------------------------------------------------------------------- */
        /* -------------------- Deschiderea formularului frmCopieDeSiguranta --------------------------------------------- */
        private void btnCopieSiguranta_Click(object sender, EventArgs e)
        {
            // Apelam formularul "frmCopieDeSiguranta"
            Form frmCopieDeSiguranta = new frmCopieDeSiguranta();

            // Facem "frmResetareAplicatie" copil al "frmGCD"
            frmCopieDeSiguranta.MdiParent = this;

            foreach (Form form in Application.OpenForms)
            {
                if (form.GetType() == typeof(frmCopieDeSiguranta))
                {
                    form.WindowState = FormWindowState.Normal;
                    form.Activate();
                    return;
                }
            }

            // Afisam "frmEditareRector"
            frmCopieDeSiguranta.Show();
        }
        /* --------------------------------------------------------------------------------------------------------------- */
        /* ------------------- Deschiderea formularului frmManualUtilizare ----------------------------------------------- */
        private void btnManualUtilizare_Click(object sender, EventArgs e)
        {

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