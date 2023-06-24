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
using DevExpress.XtraGrid;
using is_takip.Entity;

namespace is_takip.Formlar
{
    public partial class FrmFirma : Form
    {
        public FrmFirma()
        {
            InitializeComponent();
        }
        DbisTakipEntities db = new DbisTakipEntities();
        void firmalar()
        {
            var degerler = from x in db.TblFirma
                           select new
                           {
                               x.ID,
                               x.Ad,
                               x.Yetkili,
                               x.Mail,
                               x.Telefon,
                               x.Il,
                               x.Ilce,
                               x.Sektor,
                               x.Adress
                           };
            gridControlFirma.DataSource = degerler.ToList();
        }
        private void FrmFirma_Load(object sender, EventArgs e)
        {
            firmalar();


        }

        private void BtnEkle_Click(object sender, EventArgs e)
        {
            TblFirma t = new TblFirma();
            t.Ad =TxtFirmaAd.Text;
            t.Yetkili = TxtFirmaTemsilci.Text;
            t.Telefon = TxtfirmaTel.Text;
            t.Il = txtil.Text;
            t.Ilce= txtİlce.Text;
            t.Sektor = txtSektor.Text;
            t.Adress = txtAdres.Text;
            db.TblFirma.Add(t);
            db.SaveChanges();
            XtraMessageBox.Show(" Uğurla əlavə edildi", "Məlumat", MessageBoxButtons.OK, MessageBoxIcon.Information);
            firmalar();
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            var x = int.Parse(TxtFirmaID.Text);
            var deger = db.TblFirma.Find(x);
            db.SaveChanges();
            XtraMessageBox.Show(" İşçi uğurlu şəkildə silindi", "Məlumat", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            firmalar();
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            int x = int.Parse(TxtFirmaID.Text);
            var deger = db.TblFirma.Find(x);
            deger.Ad = TxtFirmaAd.Text;
            deger.Yetkili = TxtFirmaTemsilci.Text;
            deger.Telefon = TxtfirmaTel.Text;
            deger.Il = txtil.Text;
            deger.Ilce = txtİlce.Text;
            deger.Sektor = txtSektor.Text;
            deger.Adress = txtAdres.Text;
            db.SaveChanges();
            XtraMessageBox.Show(" Uğurla yeniləndi", "Məlumat", MessageBoxButtons.OK, MessageBoxIcon.Information);
            firmalar();
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            TxtFirmaAd.Text = gridView1.GetFocusedRowCellValue("Ad").ToString();
            TxtFirmaID.Text = gridView1.GetFocusedRowCellValue("ID").ToString();
            TxtFirmaTemsilci.Text = gridView1.GetFocusedRowCellValue("Yetkili").ToString();
            TxtfirmaTel.Text = gridView1.GetFocusedRowCellValue("Telefon").ToString();
            txtil.Text = gridView1.GetFocusedRowCellValue("Il").ToString();
            txtİlce.Text = gridView1.GetFocusedRowCellValue("Ilce").ToString();
            txtSektor.Text = gridView1.GetFocusedRowCellValue("Sektor").ToString();
            txtAdres.Text = gridView1.GetFocusedRowCellValue("Adress").ToString();

        }
    }
}
