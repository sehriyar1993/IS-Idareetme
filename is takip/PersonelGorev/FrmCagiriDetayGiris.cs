using DevExpress.XtraEditors;
using is_takip.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace is_takip.PersonelGorev
{
    public partial class FrmCagiriDetayGiris : Form
    {
        internal int id;

        public FrmCagiriDetayGiris()
        {
            InitializeComponent();
        }

        private void TxtTarix_EditValueChanged(object sender, EventArgs e)
        {

        }
        DbisTakipEntities db = new DbisTakipEntities();
        private void BtnVazgec_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmCagiriDetayGiris_Load(object sender, EventArgs e)
        {
            Txtid.Enabled = false;
            Txtid.Text =id.ToString();
            string saat, tarih;
            tarih = DateTime.Now.ToShortDateString();
            saat = DateTime.Now.ToShortTimeString();
            TxtTarix.Text = tarih;
            txtSaat.Text = saat;
             

        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            TblCAgriDetay t = new TblCAgriDetay();
            t.Cagri = int.Parse(Txtid.Text);
            t.Saat = txtSaat.Text;
            t.Tarih = DateTime.Parse(TxtTarix.Text);
            t.Aciklama = TxtAciqlama.Text;    
            db.TblCAgriDetay.Add(t);
            db.SaveChanges();
            XtraMessageBox.Show("Müraciətinizin detalları uğurlu şəkildə qeyd edildi","Məlumat", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
