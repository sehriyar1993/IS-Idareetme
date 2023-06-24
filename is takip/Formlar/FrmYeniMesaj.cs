using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using is_takip.Entity;

namespace is_takip.Formlar
{
    public partial class FrmYeniMesaj : Form
    {
        internal int id1;
        public FrmYeniMesaj()
        {
            InitializeComponent();
        }
        DbisTakipEntities db = new DbisTakipEntities();
        private void FrmYeniMesaj_Load(object sender, EventArgs e)
        {
            var degerler = (from x in db.TblFirma select new { x.ID, x.Ad, x.Yetkili}).ToList();
            txtGorevAlan.Properties.DataSource = degerler;
            txtGorevAlan.Properties.ValueMember = "ID";
            txtGorevAlan.Properties.DisplayMember = "Ad";
            txtGorevAlan.Properties.DisplayMember = "Yetkili";

            var degerler1 = (from y in db.TblFirma select new { y.ID, y.Ad, y.Yetkili}).ToList();
            lookUpEdit1.Properties.DataSource = degerler1;
            lookUpEdit1.Properties.ValueMember = "ID";
            lookUpEdit1.Properties.DisplayMember = "Ad";
            lookUpEdit1.Properties.DisplayMember = "Yetkili";

           // var gelenveri = db.TblMesajlar.Find(id1);
           // lookUpEdit1.Text = gelenveri.Gonderen.ToString();
            //txtGorevAlan.Text = gelenveri.Alan.ToString();
            //TxtAciqlama.Text = gelenveri.mesaj;
           // TxtKonu.Text = gelenveri.Basliq;
           // TxtTarix.Text = gelenveri.Tatix.ToString();
           // checkEdit1.EditValue = gelenveri.Durum;

        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {

            TblMesajlar t = new TblMesajlar();
            t.Gonderen = int.Parse(lookUpEdit1.EditValue.ToString());
            t.Alan = int.Parse(txtGorevAlan.EditValue.ToString());
            t.Tatix = Convert.ToDateTime(TxtTarix.Text); 
            t.Durum = (bool?)checkEdit1.EditValue;
            t.Basliq = TxtKonu.Text;
            t.mesaj = TxtAciqlama.Text;
            db.TblMesajlar.Add(t);
            db.SaveChanges();
            XtraMessageBox.Show(" Səhifəni yenilədikdən sonra mesajınızı sisteminizdə gorecəksiniz", "Məlumat", MessageBoxButtons.OK, MessageBoxIcon.Information);
            
        }

        private void BtnVazgec_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
