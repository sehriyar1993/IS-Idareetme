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
    public partial class FrmCagiriListesi : Form
    {
        public FrmCagiriListesi()
        {
            InitializeComponent();
        }
        DbisTakipEntities db = new DbisTakipEntities();
        public string mail2;

        private void FrmCagiriListesi_Load(object sender, EventArgs e)
        {
            var personId = db.TblPersonel.Where(x => x.Mail == mail2).Select(y => y.ID).FirstOrDefault();

            gridControl2.DataSource = (from x in db.TblCagrilar select new 
            {
                x.ID , x.TblFirma.Ad, x.TblFirma.Telefon, x.TblFirma.Mail, x.Aciklama,x.CagriPersonel, x.Durum 
            }).Where(y => y.Durum == true && y.CagriPersonel== personId).ToList();
            gridView2.Columns["Durum"].Visible = false;
            gridView2.Columns["CagriPersonel"].Visible = false;

        }

        private void gridControl2_DoubleClick(object sender, EventArgs e)
        {
            PersonelGorev.FrmCagiriDetayGiris fr = new FrmCagiriDetayGiris();
            fr.id = int.Parse(gridView2.GetFocusedRowCellValue("ID").ToString());
            fr.Show();
        }
    }
}
