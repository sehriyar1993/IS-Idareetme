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
    public partial class Frm_personel : Form
    {
        public Frm_personel()
        {
            InitializeComponent();
        }
        DbisTakipEntities db = new DbisTakipEntities();
        void personeller() 
        {
            var degerler = from x in db.TblPersonel
                           select new
                           {
                               x.ID,
                               x.Ad,
                               x.Soyad,
                               x.Telefon,
                               x.Mail,
                               Departman = x.TblDepartmanlar.Ad,
                               x.Veziyyet,
                               x.Gorsel
                           };
            gridControl1.DataSource = degerler.Where(x=>x.Veziyyet == true).ToList();
        }
        
             
        private void Frm_personel_Load(object sender, EventArgs e)
        {
           personeller();
            
            
            var departmanlar = (from x in db.TblDepartmanlar select new { x.ID, x.Ad }).ToList();
            lookUpEdit1.Properties.DataSource = departmanlar;
            lookUpEdit1.Properties.ValueMember = "ID";
            lookUpEdit1.Properties.DisplayMember = "Ad";
            
        }

        private void BtnListele_Click(object sender, EventArgs e)
        {
            personeller();
        }

        private void BtnEkle_Click(object sender, EventArgs e)
        {
            TblPersonel t = new TblPersonel();
            //t.ID = TxtID.Text;
            t.Ad = TxtAd.Text;
            t.Soyad = TxtSoyad.Text;
            t.Gorsel = txtGorsel.Text;
            t.Mail = TxtMail.Text;
            //t.Gorsel = txtGorsel.Text;
            t.Departman = int.Parse(lookUpEdit1.EditValue.ToString());
            db.TblPersonel.Add(t);
            db.SaveChanges();
            XtraMessageBox.Show(" Uğurla əlavə edildi", "Məlumat", MessageBoxButtons.OK, MessageBoxIcon.Information);
            personeller();
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            var x = int.Parse(TxtID.Text);
            var deger = db.TblPersonel.Find(x);
            deger.Veziyyet = false;
            db.SaveChanges();
            XtraMessageBox.Show(" İşçi uğurlu şəkildə silindi", "Məlumat", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            personeller();
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            TxtAd.Text = gridView1.GetFocusedRowCellValue("Ad").ToString();
            TxtID.Text = gridView1.GetFocusedRowCellValue("ID").ToString();
            TxtSoyad.Text = gridView1.GetFocusedRowCellValue("Soyad").ToString();
            TxtMail.Text = gridView1.GetFocusedRowCellValue("Mail").ToString();
            txtGorsel.Text = gridView1.GetFocusedRowCellValue("Gorsel").ToString();
           lookUpEdit1.Text = gridView1.GetFocusedRowCellValue("Departman").ToString();


        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            int x = int.Parse(TxtID.Text);
            var deger  = db.TblPersonel.Find( x);
            deger.Ad = TxtAd.Text;
            deger.Soyad = TxtSoyad.Text;
            deger.Mail = TxtMail.Text;
            deger.Gorsel = txtGorsel.Text;
            deger.Departman = int.Parse(lookUpEdit1.EditValue.ToString());
            db.SaveChanges();
            XtraMessageBox.Show(" Uğurla yeniləndi", "Məlumat", MessageBoxButtons.OK, MessageBoxIcon.Information);
            personeller();

        }
    }
}
