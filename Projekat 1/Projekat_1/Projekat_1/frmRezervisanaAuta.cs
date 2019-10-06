using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projekat_1
{
    public partial class frmRezervisanaAuta : Form
    {
        FileStream fs;
        BinaryFormatter bf;


        int idKupca = frmLoginKupca.idKupca;
        string imeKupca = frmLoginKupca.imeAdmina;
        string prezimeKupca = frmLoginKupca.prezimeAdmina;
        string vremePristupa = frmLoginKupca.datumPristupa;

        string rezervacijeFajl = "rezervacije/sveRezervacije.mrso";
        string automobiliFajl = "automobili/automobili.mrso";
        List<Automobil> listaAutomobila = new List<Automobil>();

        


        List<Rezervacija> listaRezevacija;

        public frmRezervisanaAuta()
        {
            InitializeComponent();
        }

        private void btnRezervisiAutomobile_Click(object sender, EventArgs e)
        {
            Form frmRezervacija = new frmRezervacija();
            frmRezervacija.Show();
        }

        private void frmRezervisanaAuta_Load(object sender, EventArgs e)
        {
            txtRezervisanoAuto.Enabled = false; 
            lblImeAdmina.Text = frmLoginKupca.imeAdmina;
            lblPrezimeAdmina.Text = frmLoginKupca.prezimeAdmina;
            lblVremePristupaAdmina.Text = frmLoginKupca.datumPristupa;


            if (File.Exists(rezervacijeFajl))
            {
                bf = new BinaryFormatter();
                fs = new FileStream(rezervacijeFajl, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);

                listaRezevacija = bf.Deserialize(fs) as List<Rezervacija>;

                fs.Flush();
                fs.Dispose();
                fs.Close();

                foreach (Rezervacija rezervacija in listaRezevacija)
                {
                    lstRezervisanaAuta.Items.Add(rezervacija);
                }
            }

            if (File.Exists(automobiliFajl))
            {
                bf = new BinaryFormatter();
                fs = new FileStream(automobiliFajl, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);

                listaAutomobila = bf.Deserialize(fs) as List<Automobil>;

                fs.Flush();
                fs.Dispose();
                fs.Close();
            }
        }

        private void lstRezervisanaAuta_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(lstRezervisanaAuta.SelectedIndex!=-1)
            foreach(Automobil a in listaAutomobila)
            {
                if (a.IdAuta == listaRezevacija[lstRezervisanaAuta.SelectedIndex].IdAuta)
                {
                    txtRezervisanoAuto.Text = a.Marka + " " + a.Model + " " + a.Godiste + "god " + a.Kubikaza + " cm3";
                }
            }

        }

        private void btnUkiniRezervaciju_Click(object sender, EventArgs e)
        {
            if (lstRezervisanaAuta.SelectedIndex != -1)
            {
                listaRezevacija.RemoveAt(lstRezervisanaAuta.SelectedIndex);
                lstRezervisanaAuta.Items.RemoveAt(lstRezervisanaAuta.SelectedIndex);
                MessageBox.Show("Izabrana rezervacija je obrisana!");

                lstRezervisanaAuta.Items.Clear();
                txtRezervisanoAuto.Clear();

                if (File.Exists(rezervacijeFajl))
                {
                    bf = new BinaryFormatter();
                    fs = new FileStream(rezervacijeFajl, FileMode.Open, FileAccess.Write, FileShare.ReadWrite);

                    bf.Serialize(fs, listaRezevacija);

                    fs.Flush();
                    fs.Dispose();
                    fs.Close();

                }
                if (File.Exists(rezervacijeFajl))
                {
                    bf = new BinaryFormatter();
                    fs = new FileStream(rezervacijeFajl, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);

                    listaRezevacija = bf.Deserialize(fs) as List<Rezervacija>;

                    fs.Flush();
                    fs.Dispose();
                    fs.Close();

                    foreach (Rezervacija rezervacija in listaRezevacija)
                    {
                        lstRezervisanaAuta.Items.Add(rezervacija);
                    }
                }
            }

          
        }
    }
}
