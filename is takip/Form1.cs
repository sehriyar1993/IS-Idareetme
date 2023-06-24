using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace is_takip
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        Formlar.Form1 frm;
        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (frm == null || frm.IsDisposed)
            {
                frm = new Formlar.Form1();
                frm.MdiParent = this;
                frm.Show();
            }
            

        }
        Formlar.Frm_personel frm2;
        private void barButtonItem6_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (frm2 == null || frm2.IsDisposed)
            {
                frm2 = new Formlar.Frm_personel();
                frm2.MdiParent = this;
                frm2.Show(); 
            }
            
        }
        Formlar.FrmPersonelstatistik frm3;
        private void Btnpersonelİstatistik_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (frm3 == null || frm3.IsDisposed)
            {
               frm3 = new Formlar.FrmPersonelstatistik();
               frm3.MdiParent = this;
               frm3.Show();
            }
           
        }
        Formlar.FrmGorevliste frm4;
        private void BtbGorev_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (frm4 == null || frm4.IsDisposed)
            {
             frm4 = new Formlar.FrmGorevliste();
             frm4.MdiParent = this;
             frm4.Show();

            }
            
        }

        private void barButtonItem13_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
           Formlar.FrmGorev fr = new Formlar.FrmGorev();
            fr.Show();
        }

        private void BtnGorevDetay_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Formlar.FrmGorevDetay f = new Formlar.FrmGorevDetay();
            f.Show();
        }
        Formlar.FrmAnaForm frmAna;
        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if(frmAna == null || frmAna.IsDisposed)
            {
                frmAna = new Formlar.FrmAnaForm();
                frmAna.MdiParent = this;
                frmAna.Show(); 
            }
            
        }
        Formlar.FrmAktivCagiri f1;
        private void btnAktivCagiri_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            // = new Formlar.FrmAktivCagiri();
            if (f1 == null || f1.IsDisposed)
            {
                f1 = new Formlar.FrmAktivCagiri();
                f1.MdiParent = this;
                f1.Show();
            }
        }
        PersonelGorev.Frmpassivvv fp;
        private void btnPassivCagiri_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            fp = new PersonelGorev.Frmpassivvv();
            fp.MdiParent = this;
            fp.Show();
        }
        Formlar.FrmFirma frmF;
        private void barButtonItem9_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (frmF == null || frm2.IsDisposed)
            {
                frmF = new Formlar.FrmFirma();
                frmF.MdiParent = this;
                frmF.Show();
            }
        }
        Formlar.FrmYeniFirma frmY;
        private void barButtonItem10_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmY = new Formlar.FrmYeniFirma();
            frmY.Show();
        }
        login.FrmSifreler frms;
        private void barButtonItem24_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frms = new login.FrmSifreler();
            frms.Show();
        }
        Formlar.FrmYeniMesaj frmYm;
        private void barButtonItem17_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmYm = new Formlar.FrmYeniMesaj();
            frmYm.Show();
        }
        Formlar.FrmGelenMesaj frmGelenMesaj;
        private void barButtonItem12_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmGelenMesaj = new Formlar.FrmGelenMesaj();
            frmGelenMesaj.Show();
        }
        Formlar.FrmGonderilen frr;
        private void barButtonItem5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frr = new Formlar.FrmGonderilen();
            frr.Show();
        }
    }
}
