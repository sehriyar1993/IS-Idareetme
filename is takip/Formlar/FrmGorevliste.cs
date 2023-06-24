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
    public partial class FrmGorevliste : Form
    {
        public FrmGorevliste()
        {
            InitializeComponent();
        }
        DbisTakipEntities db = new DbisTakipEntities();
        private void FrmGorevliste_Load(object sender, EventArgs e)
        {
            gridControl1.DataSource = (from x in db.TblGorevler select new
            {
                x.Aciklama
            }).ToList();
            


            LblTopSobe.Text = db.TblDepartmanlar.Count().ToString();
            LblAktivTap.Text = db.TblGorevler.Count(x=>x.Durum == "1").ToString();
            LblPassivTap.Text = db.TblGorevler.Count(x=>x.Durum == "0").ToString();
            
            
            chartControl1.Series["Series 1"].Points.AddPoint("Passif Gorev", int.Parse(LblPassivTap.Text));
            chartControl1.Series["Series 1"].Points.AddPoint("Aktif Gorev", int.Parse(LblAktivTap.Text));
        }
    }
}
