using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Projekat_1
{
    public partial class frmLoginAdmina : Form
    {
        FileStream fs;
        BinaryFormatter bf;
        List<Administrator> listaAdmina = new List<Administrator>();

        string kupciFajl = "nalozi/kupci.mrso";
        string adminiFajl = "nalozi/admini.mrso";
        string ponudeFajl = "ponude/ponude.mrso";
        string automobiliFajl = "automobili/automobili.mrso";
        string rezervacijeFajl = "rezervacije/rezervacije.mrso";
        string statistikeFajl = "statistika/statistika.mrso";
       

        public frmLoginAdmina()
        {
            InitializeComponent();
        }
       public static string imeAdmina;
       public static string prezimeAdmina;
       public static string datumPristupa;

        Boolean statusLogina = false;

        private void btnPrijava_Click(object sender, EventArgs e)
        {
            foreach(Administrator a in listaAdmina)
            {
               
                  /*  if (a.Titula.Equals("Glavni") || a.Titula.Equals("Admin"))
                    {*/
                    if (a.KorisnickoIme.Equals(txtKorisnickoIme.Text) && a.Lozinka.Equals(txtLozinka.Text) && (a.Titula.Equals("Glavni")))
                {
                        imeAdmina = a.Ime;
                        prezimeAdmina = a.Prezime;
                        DateTime datum = DateTime.Now;
                        datumPristupa = datum.ToLongDateString() + " " + datum.ToShortTimeString();

                        MessageBox.Show("Uspesno ste ulogovani!");
                        Form adminForma = new frmAdmin();
                    statusLogina = true;
                        adminForma.Show();
                        break;
                    }
                else
                {
                    statusLogina = false;
                }
            }
            if (statusLogina == false)
            {
                MessageBox.Show("Podaci nisu validni!");
            }

        }

        private void frmLoginAdmina_Load(object sender, EventArgs e)
        {
            fs = new FileStream(adminiFajl, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            bf = new BinaryFormatter();

            listaAdmina = bf.Deserialize(fs) as List<Administrator>;

            fs.Flush();
            fs.Dispose();
            fs.Close();


        }
    }
}
