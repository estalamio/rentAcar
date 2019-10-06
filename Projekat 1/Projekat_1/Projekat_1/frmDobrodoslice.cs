using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projekat_1
{
    public partial class frmDobrodoslice : Form
    {
        public frmDobrodoslice()
        {
            InitializeComponent();
        }

        private void btnAdmin_Click(object sender, EventArgs e)
        {
            Form frmLoginAdmina = new frmLoginAdmina();
            frmLoginAdmina.Show();
        }

        private void frmDobrodoslice_Load(object sender, EventArgs e)
        {

        }

        private void btnKorisnik_Click(object sender, EventArgs e)
        {
            Form frmLoginKupca = new frmLoginKupca();
            frmLoginKupca.Show();
           
        }
    }
}
