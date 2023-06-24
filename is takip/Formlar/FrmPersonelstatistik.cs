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
    public partial class FrmPersonelstatistik : Form
    {
        public FrmPersonelstatistik()
        {
            InitializeComponent();
        }

        private void labelControl1_Click(object sender, EventArgs e)
        {

        }
        DbisTakipEntities db = new DbisTakipEntities();
        private void FrmPersonelstatistik_Load(object sender, EventArgs e)
        {
            LblToplamDepartman.Text = db.TblDepartmanlar.Count().ToString();
            LblToplamFirma.Text = db.TblFirma.Count().ToString();   
            LblTomlamPer.Text = db.TblPersonel.Count().ToString();
            LblAktivİs.Text = db.TblGorevler.Count(x=>x.Durum == "1").ToString();
            LblPassivIs.Text = db.TblGorevler.Count(x=>x.Durum =="0").ToString();
            LblSonIs.Text = db.TblGorevler.OrderByDescending(x=>x.ID ).Select(x=>x.Aciklama).FirstOrDefault();
            LblSehir.Text = db.TblFirma.Select(x=>x.Il).Distinct().Count().ToString();
            LblSektor.Text = db.TblFirma.Select(x => x.Sektor).Distinct().Count().ToString();
            DateTime bugun = DateTime.Today;
            lblbugunacilan.Text = db.TblGorevler.Count(x => x.Tarih == bugun).ToString();
            var d1 = db.TblGorevler.GroupBy(x => x.GorevAlan).OrderByDescending(z => z.Count()).Select(y => y.Key).FirstOrDefault();
            LblAyinIscisi.Text = db.TblPersonel.Where(x=>x.ID==d1).Select(y=>y.Ad +" "+ y.Soyad).FirstOrDefault().ToString();
            LblDepartman.Text = db.TblDepartmanlar.Where(x=>x.ID==7).Select(y=>y.Ad).FirstOrDefault().ToString();
            lblAyIsDep.Text = db.TblDepartmanlar.Where(x=>x.ID == db.TblPersonel.Where(t=>t.ID==d1).Select(z=>z.Departman).FirstOrDefault()).Select(y => y.Ad).FirstOrDefault().ToString();
        }

        private void labelControl30_Click(object sender, EventArgs e)
        {

        }
    }
}
