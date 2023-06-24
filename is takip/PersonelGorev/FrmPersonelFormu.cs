using is_takip.Formlar;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace is_takip.PersonelGorev
{
    public partial class FrmPersonelFormu : Form
    {
        public FrmPersonelFormu()
        {
            InitializeComponent();
        }
        public string mail;

        private void BtnAktivGorev_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            PersonelGorev.FrmAktivGorev f = new PersonelGorev.FrmAktivGorev();
            f.MdiParent = this;
            f.mail2 = mail;
            f.Show();
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            PersonelGorev.Frmpassivvv ft = new PersonelGorev.Frmpassivvv();
            ft.MdiParent = this;
            ft.mail2 = mail;
            ft.Show();
        }

        private void btnCagriList_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            PersonelGorev.FrmCagiriListesi fc = new PersonelGorev.FrmCagiriListesi();
            fc.MdiParent = this;
            fc.mail2 = mail;
            fc.Show();
        }

        private void FrmPersonelFormu_Load(object sender, EventArgs e)
        {
            this.Text = mail.ToString();
        }
        Formlar.FrmGonderilen frr;

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frr = new Formlar.FrmGonderilen();
            frr.Show();
        }
        Formlar.FrmGelenMesaj frmG;
        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmG = new Formlar.FrmGelenMesaj();
            frmG.Show();
        }
        PersonelGorev.FrmPmesaj frmYm;
        private void barButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmYm = new PersonelGorev.FrmPmesaj();
            frmYm.Show();
        }
    }
}
