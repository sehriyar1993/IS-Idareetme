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

namespace is_takip.PersonelGorev
{
    public partial class Frmpassivvv : Form
    {
        public Frmpassivvv()
        {
            InitializeComponent();
        }
        DbisTakipEntities db = new DbisTakipEntities();
        public string mail2;

        private void Frmpassivvv_Load(object sender, EventArgs e)
        {
            var personId = db.TblPersonel.Where(x => x.Mail == mail2).Select(y => y.ID).FirstOrDefault();
            var degerler = (from x in db.TblGorevler
                            select new
                            {
                                x.ID,
                                x.Aciklama,
                                x.Tarih,
                                x.TblPersonel.Ad,
                                x.GorevAlan,
                                x.Durum
                            }).Where(x => x.GorevAlan == personId && x.Durum == "0").ToList();
            if (degerler.Count == 0)
            {
                MessageBox.Show("Passiv Müraciət Tapılmadı", "Məlumat", MessageBoxButtons.OK, MessageBoxIcon.Exclamation).ToString();
            }

            gridControl1.DataSource = degerler;
            gridView1.Columns["GorevAlan"].Visible = false;
            gridView1.Columns["Durum"].Visible = false;
        }
    }
}
