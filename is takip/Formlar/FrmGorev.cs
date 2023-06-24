using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using is_takip.Entity;

namespace is_takip.Formlar
{
    public partial class FrmGorev : Form
    {
        public FrmGorev()
        {
            InitializeComponent();
        }

       

        private void textEdit2_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void BtnVazgec_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        DbisTakipEntities db = new DbisTakipEntities();
        private void BtnKaydet_Click(object sender, EventArgs e)
        {

            TblGorevler t = new TblGorevler();
            t.Aciklama = TxtAciqlama.Text;
            t.Durum = "1";
            t.Tarih = TxtTarix.DateTime;
            t.GorevAlan = int.Parse(lookUpEdit1.EditValue.ToString());
            t.GorevVeren = int.Parse(TxtGorevVeren.Text);
            db.TblGorevler.Add(t);
            db.SaveChanges();
            MessageBox.Show("Uğurlu şəkildə əlavə edildi", "Məlumat", MessageBoxButtons.OK, MessageBoxIcon.Information);
            
        }
        private void FrmGorev_Load(object sender, EventArgs e)
        {
            var degerler = (from x in db.TblPersonel select new { x.ID, x.Ad, x.Soyad }).ToList();
            lookUpEdit1.Properties.DataSource = degerler;
            lookUpEdit1.Properties.ValueMember = "ID";
            lookUpEdit1.Properties.DisplayMember = "Ad";
            lookUpEdit1.Properties.DisplayMember = "Soyad";
        }
    }
}
