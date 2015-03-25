﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RelInt___Gestiune_cereri_de_deplasare
{
    public partial class frmGCD : Form
    {
        public frmGCD()
        {
            InitializeComponent();
        }

        private void btnGCDIntroducereFormular_Click(object sender, EventArgs e)
        {
            // Apelam formularul "frmCerereIntroducere"
            Form frmCerereInregistrare = new frmCerereInregistrare();

            // Facem "frmCerereIntroducere "copil al "frmGCD"
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

        private void btnGCDModificareFormular_Click(object sender, EventArgs e)
        {
            // Apelam formularul "frmCerereModificare"
            Form frmCerereModificare = new frmCerereModificare();

            // Facem "frmCerereModificare "copil al "frmGCD"
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

        private void mnuIesire_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGCDcăutareCerere_Click(object sender, EventArgs e)
        {
            // Apelam formularul "frmCautareCerere"
            Form frmCautareCerere = new frmCautareCerere();

            // Facem "frmCautareCerere "copil al "frmGCD"
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
       }
    }