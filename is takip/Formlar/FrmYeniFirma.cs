using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using is_takip.Entity;

namespace is_takip.Formlar
{
    public partial class FrmYeniFirma : Form
    {
        public FrmYeniFirma()
        {
            InitializeComponent();
        }
        DbisTakipEntities db = new DbisTakipEntities();
        private void panelControl1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void FrmYeniFirma_Load(object sender, EventArgs e)
        {
            var degerler = (from x in db.TblFirma select new
            {
                x.ID,
                x.Ad,
                x.Yetkili,
                x.Mail,
                x.Telefon,
                x.Il,
                x.Ilce,
                x.Sektor,
                x.Adress,
                x.Sifre
            }).ToList();
           
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            TblFirma t = new TblFirma();
            t.Ad = TxtFirmaAd.Text;
            t.Yetkili = TxtFirmaYetkili.Text;
            t.Telefon = TxtFirmaTelefon.Text;
            t.Il = Txtfirmaİl.Text;
            t.Ilce = TxtFirmaİlce.Text;
            t.Sektor = TxtFirmaSektor.Text;
            t.Adress = TxtfirmaAdress.Text;
            t.Sifre = TxtfirmaSifre.Text;
            t.Mail = TxtFirmaMail.Text;
            db.TblFirma.Add(t);
            db.SaveChanges();
            XtraMessageBox.Show(" Uğurla əlavə edildi", "Məlumat", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnVazgec_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
