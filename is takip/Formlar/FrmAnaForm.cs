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
    public partial class FrmAnaForm : Form
    {
        public FrmAnaForm()
        {
            InitializeComponent();
        }
        DbisTakipEntities db = new DbisTakipEntities();

        private void FrmAnaForm_Load(object sender, EventArgs e)
        {
            DateTime bugun = DateTime.Parse(DateTime.Now.ToShortDateString());
            gridControl1.DataSource = (from x in db.TblGorevler
                                       select new
                                       {
                                           x.Aciklama,
                                           Isci = x.TblPersonel.Ad + " " + x.TblPersonel.Soyad,
                                           x.Durum

                                       }).Where(y => y.Durum == "1").ToList();
            gridView1.Columns["Durum"].Visible = false;

            gridControl2.DataSource = (from x in db.TblGorevDetay
                                       select new
                                       {
                                           gorev = x.TblGorevler.Aciklama,
                                           x.Aciklama,
                                           x.Tarih
                                       }).Where(x => x.Tarih == bugun).ToList();

            gridControl4.DataSource = (from x in db.TblCagrilar
                                       select new
                                       {
                                           x.TblFirma.Ad,
                                           x.Konu,
                                           x.Aciklama,
                                           x.Tarih,
                                           x.Durum

                                       }).Where(x=>x.Durum == true).ToList();
            gridView4.Columns["Durum"].Visible = false;
            gridControl7.DataSource = (from x in db.TblFirma
                                       select new
                                       {
                                           x.Ad,
                                           x.Telefon
                                       }).ToList();

           int aktif_cagirilar = db.TblCagrilar.Where(x => x.Durum == true).Count();
            int passif_cagirilar = db.TblCagrilar.Where(x => x.Durum == false).Count();
           
            chartControl1.Series["Series 1"].Points.AddPoint("Passif ", passif_cagirilar);
            chartControl1.Series["Series 1"].Points.AddPoint("Aktif ", aktif_cagirilar);

        }

    }
}
