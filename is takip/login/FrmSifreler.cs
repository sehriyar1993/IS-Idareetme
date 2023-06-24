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

namespace is_takip.login
{
    public partial class FrmSifreler : Form
    {
        public FrmSifreler()
        {
            InitializeComponent();
        }
        DbisTakipEntities db = new DbisTakipEntities();
        private void button1_Click(object sender, EventArgs e)
        {
            var degerler = from x in db.TblFirma
                           select new
                           {
                               x.ID,
                               x.Ad,
                               x.Yetkili,
                               x.Mail,
                               x.Telefon,
                               x.Sifre 
                           };
            gridControl1.DataSource = degerler.Where(x=>x.ID !=11 && x.ID!=1).ToList();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var degerler = from y in db.TblPersonel
                           select new
                           {
                               y.ID,
                               y.Ad,
                               y.Soyad,
                               y.Mail,
                               y.Telefon,
                               y.Sifre
                           };
            gridControl2.DataSource = degerler.ToList();
        }

        private void FrmSifreler_Load(object sender, EventArgs e)
        {

        }
    }
}
