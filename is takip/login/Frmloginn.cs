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

namespace is_takip.login
{
    public partial class Frmloginn : DevExpress.XtraBars.FluentDesignSystem.FluentDesignForm
    {
        public Frmloginn()
        {
            InitializeComponent();
        }
        DbisTakipEntities db = new DbisTakipEntities();
        private void button1_Click(object sender, EventArgs e)
        {
            var PerGiris = db.TblPersonel.Where(x=>x.Mail==txtKullnaici.Text && x.Sifre==txtSifre.Text).FirstOrDefault();
            PersonelGorev.FrmPersonelFormu frm = new PersonelGorev.FrmPersonelFormu();
            if (PerGiris != null) 
            {
                frm.mail = txtKullnaici.Text;
                frm.Show();
            }
            else { XtraMessageBox.Show("Xətalı Giriş"); }

        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var admingiris = db.TblAdmin.Where(x=>x.Kullanici==txtKullnaici.Text && x.Sifre==txtSifre.Text).FirstOrDefault();
            Form1 fr = new Form1();
            if (admingiris != null) 
            {   
                fr.Show();
            }
            else { XtraMessageBox.Show("Xətalı Giriş"); }
         
            
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }
    }
}
