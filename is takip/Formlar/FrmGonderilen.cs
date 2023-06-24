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
    public partial class FrmGonderilen : Form
    {
        public FrmGonderilen()
        {
            InitializeComponent();
        }
        DbisTakipEntities db=new DbisTakipEntities();
        private void FrmGonderilen_Load(object sender, EventArgs e)
        {
            var degerler = (from x in db.TblMesajlar
                            select new
                            {
                                x.ID,
                                x.TblFirma.Ad,
                                x.Alan,
                                Cavabdeh = x.TblPersonel.Ad,
                                x.Gonderen,
                                x.Basliq,
                                x.mesaj,
                                x.Tatix,
                                x.Durum
                            }).Where(x => x.Durum == true).ToList();
            gridControl1.DataSource = degerler;
        }
    }
}
