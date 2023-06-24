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
    public partial class FrmCagiriAtama : Form
    {
        internal int id;

        public FrmCagiriAtama()
        {
            InitializeComponent();
        }

        private void TxtAciqlama_EditValueChanged(object sender, EventArgs e)
        {

        }
        DbisTakipEntities db = new DbisTakipEntities();
        private void FrmCagiriAtama_Load(object sender, EventArgs e)
        {
            var degerler = (from x in db.TblPersonel select new { x.ID, x.Ad, x.Soyad }).ToList();
            txtGorevAlan.Properties.DataSource = degerler;
            txtGorevAlan.Properties.ValueMember = "ID";
            txtGorevAlan.Properties.DisplayMember = "Ad";
            txtGorevAlan.Properties.DisplayMember = "Soyad";


            TxtAtamaId.Text =id.ToString();
            var gelenveri = db.TblCagrilar.Find(id);
            TxtAciqlama.Text = gelenveri.Aciklama;
            TxtKonu.Text =gelenveri.Konu;
            TxtTarix.Text= gelenveri.Tarih.ToString();
            checkEdit1.EditValue = gelenveri.Durum;
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            var gelenveri = db.TblCagrilar.Find(id);
            gelenveri.Konu = TxtKonu.Text;
            gelenveri.Aciklama = TxtAciqlama.Text;
            gelenveri.Tarih = Convert.ToDateTime(TxtTarix.Text);
            gelenveri.CagriPersonel =int.Parse( txtGorevAlan.EditValue.ToString());
            gelenveri.Durum = (bool?)checkEdit1.EditValue;
            db.SaveChanges();
            
            this.Close();
            XtraMessageBox.Show("Səhifəni yenilədikdən sonra dəyişiklikləri sisteminizdə gorecəksiniz");
        }

        private void BtnVazgec_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
