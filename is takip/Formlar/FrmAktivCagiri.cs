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
    public partial class FrmAktivCagiri : Form
    {
        public FrmAktivCagiri()
        {
            InitializeComponent();
        }
        DbisTakipEntities db = new DbisTakipEntities();
        private void FrmAktivCagiri_Load(object sender, EventArgs e)
        {
            var degerler = (from x in db.TblCagrilar
                            select new
                            {
                                x.ID,
                                x.TblFirma.Ad,
                                x.Aciklama,
                               personel = x.TblPersonel.Ad,
                                x.Konu,
                                x.Tarih,
                                x.Durum
                            }).Where(x => x.Durum == true).ToList();
            if (degerler.Count == 0)
            {
                MessageBox.Show("Aktiv Müraciət Tapılmadı", "Məlumat", MessageBoxButtons.OK, MessageBoxIcon.Exclamation).ToString();
            }
            gridControl1.DataSource = degerler;
            
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            FrmCagiriAtama fr = new FrmCagiriAtama(); 
            fr.id =int.Parse(gridView1.GetFocusedRowCellValue("ID").ToString());
            fr.Show();
        }
    }
}
