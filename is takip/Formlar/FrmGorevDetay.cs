using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using is_takip.Entity;
using is_takip.Formlar;

namespace is_takip.Formlar
{
    public partial class FrmGorevDetay : Form
    {
        public FrmGorevDetay()
        {
            InitializeComponent();
        }
        DbisTakipEntities db = new DbisTakipEntities();

        private void FrmGorevDetay_Load(object sender, EventArgs e)
        {
            db.TblGorevDetay.Load();
            bindingSource2.DataSource = db.TblGorevDetay.Local;
        }

        private void dataGridView1_NewRowNeeded(object sender, DataGridViewRowEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            db.SaveChanges();
        }

        private void tapşırıqSilToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bindingSource2.RemoveCurrent();
            db.SaveChanges();
        }

        private void bağlaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
