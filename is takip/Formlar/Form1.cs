using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using is_takip.Entity;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace is_takip.Formlar
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {

        }

        // crud ---> create read update delete
        DbisTakipEntities db = new DbisTakipEntities();
        void Listele()
        {
            
            var deyerler = (from x in db.TblDepartmanlar
                           select new
                           {
                               x.ID,
                               x.Ad 
                           }).ToList();

            gridControl1.DataSource = deyerler;
        }

        private void BtnListele_Click(object sender, EventArgs e)
        {
            Listele(); 
        }

        private void BtnEkle_Click(object sender, EventArgs e)
        {
            TblDepartmanlar t = new TblDepartmanlar();
            t.Ad = TxtAd.Text;
            db.TblDepartmanlar .Add(t);
            db.SaveChanges();
            XtraMessageBox.Show("Şöbə uğurlu şəkildə əlavə edildi" , "Məlumat", MessageBoxButtons.OK, MessageBoxIcon.Information ); 
            Listele();
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            int x = int.Parse(TxtID.Text);
            var deger = db.TblDepartmanlar .Find(x);
            db.TblDepartmanlar.Remove(deger);
            db.SaveChanges();
            XtraMessageBox.Show("Şöbə silmə uğurla tamamlandı", "Məlumat", MessageBoxButtons.OK, MessageBoxIcon.Stop );
            Listele ();
        }

        private void gridControl1_FocusedViewChanged(object sender, DevExpress.XtraGrid.ViewFocusEventArgs e)
        {       
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            TxtID.Text = gridView1.GetFocusedRowCellDisplayText("ID").ToString();
            TxtAd.Text = gridView1.GetFocusedRowCellValue("Ad").ToString();
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            int x = int.Parse(TxtID.Text);
            TblDepartmanlar deger = db.TblDepartmanlar.Find(x);
            deger.Ad = TxtAd.Text; 
            db.SaveChanges();
            XtraMessageBox.Show("Şöbə yeniləmə uğurla tamamlandı", "Məlumat", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Listele();
        }
    }
}
