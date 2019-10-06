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
    public partial class frmAdmin : Form
    {
        List<Automobil> automobili;
        List<Automobil> lista = new List<Automobil>();

        Automobil auto;
        FileStream fs;
        BinaryFormatter bf;

        Administrator admin;
        List<Administrator> administratori = new List<Administrator>();
        List<Administrator> ucitaniAdmini = new List<Administrator>();
        List<Stats> statistika = new List<Stats>();

        public Ponuda p;
        public List<Ponuda> ponude = new List<Ponuda>();
        public List<Ponuda> listaPonuda = new List<Ponuda>();
        public List<Rezervacija> listaRezervacija = new List<Rezervacija>();
        List<Rezervacija> listaKupacRezervacija = new List<Rezervacija>();

        BindingList<Rezervacija> rezervacije = new BindingList<Rezervacija>();

        string kupciFajl = "nalozi/kupci.mrso";
        string adminiFajl = "nalozi/admini.mrso";
        string ponudeFajl = "ponude/ponude.mrso";
        string automobiliFajl = "automobili/automobili.mrso";
        string rezervacijeFajl = "rezervacije/sveRezervacije.mrso";
        string statistikeFajl = "statistika/statistika.mrso";
        string sveRezervacije = "rezervacije/sveRezervacije.mrso";

        Random rnd = new Random();

        int idKupca = frmLoginKupca.idKupca;
        string imeKupca = frmLoginKupca.imeAdmina;
        string prezimeKupca = frmLoginKupca.prezimeAdmina;
        string vremePristupa = frmLoginKupca.datumPristupa;
        List<Administrator> listaKupaca = new List<Administrator>();

        public frmAdmin()
        {
            InitializeComponent();
            automobili = new List<Automobil>();

            /*  if ((bool)listBox1.SelectedItem)
              {

              }*/
        }

        private void frmAdmin_Load(object sender, EventArgs e)
        {
            cbRezervacijaPregled.Items.Clear();
            lblImeAdmina.Text = frmLoginAdmina.imeAdmina;
            lblPrezimeAdmina.Text = frmLoginAdmina.prezimeAdmina;
            lblVremePristupaAdmina.Text = frmLoginAdmina.datumPristupa;

            txtRezervacijaKupac.Enabled = false;
            txtRezervacijaAutomobil.Enabled = false;
            txtAutomobilOtkazivanje.Enabled = false;
            txtRezervacijaDostupanOd.Enabled = false;
            txtRezervacijaDostupanDo.Enabled = false;
            txtRezervacijaPoCeniOd.Enabled = false;

            txtAutomobilOtkazivanje.Enabled = false;
            txtPocetakPonudeOtkazivanje.Enabled = false;
            txtKrajPonudeOtkazivanje.Enabled = false;
            txtCenaRezervacijeOtkazivanje.Enabled = false;



            //ISCITAVANJE REZEVACIJA
            if (File.Exists(rezervacijeFajl))
            {

                cbRezervacijaPregled.Items.Clear();
                bf = new BinaryFormatter();
                fs = new FileStream(rezervacijeFajl, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);


                listaRezervacija = bf.Deserialize(fs) as List<Rezervacija>;

                fs.Flush();
                fs.Dispose();
                fs.Close();
                for (int i = 0; i < listaRezervacija.Count; i++)
                {
                    listaKupacRezervacija.Add(listaRezervacija[i]);
                    cbRezervacijaPregled.Items.Add("#" + listaRezervacija[i].IdAuta + " " + listaRezervacija[i].DatOd.ToShortDateString() + " - " + listaRezervacija[i].DatDo.ToShortDateString() + " cena:" + listaRezervacija[i].Cena + "rsd");
                }
            }
            


            //ISCITAVANJE PONUDA
            if (File.Exists(ponudeFajl))
            {
                cbPregledPonuda.Items.Clear();
                bf = new BinaryFormatter();
                fs = new FileStream(ponudeFajl, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);

                listaPonuda = bf.Deserialize(fs) as List<Ponuda>;

                fs.Flush();
                fs.Dispose();
                fs.Close();
                for (int i = 0; i < listaPonuda.Count; i++)
                {
                    cbPregledPonuda.Items.Add("#" + listaPonuda[i].IdAuta + " po ceni od: " + listaPonuda[i].Cena + "rsd");
                    cbPonudaIzmena.Items.Add("#" + listaPonuda[i].IdAuta + " po ceni od: " + listaPonuda[i].Cena + "rsd");
                    cbPonudaDodavanje.Items.Add("#" + listaPonuda[i].IdAuta + " po ceni od: " + listaPonuda[i].Cena + "rsd");
                }
            }// KRAJ ISCITAVANJA PONUDA



            //ISCITAVANJE AUTOMOBILA
            cbTrenutniAutomobil.Items.Clear();

            if (File.Exists(automobiliFajl))
            {

                bf = new BinaryFormatter();
                fs = new FileStream(automobiliFajl, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                //fs = File.OpenRead(putanjaAuta);
                lista = bf.Deserialize(fs) as List<Automobil>;
                // cbMarka.DataSource = lista;
                /* for (int i = 0; i < lista.Count; i++)
                 {

                     cbMarka.Items.Add(lista[i].Marka);
                 }*/

                Boolean flagNadjen = false;
                for (int i = 0; i < lista.Count; i++)
                {
                    for (int j = i + 1; j < lista.Count; j++)
                    {
                        if (lista[i].Marka == lista[j].Marka) { flagNadjen = true; }
                    }
                    if (flagNadjen == false)
                    {
                        cbTrenutniAutomobil.Items.Add(lista[i].Marka + " " + lista[i].Model + " " + lista[i].Godiste + "god " + lista[i].Gorivo);

                        // cbMarka.Items.Add(lista[i].Marka);
                    }
                    // else { flagNadjen = false; }
                    cbTrenutniAutomobil.Items.Add(lista[i].Marka + " " + lista[i].Model + " " + lista[i].Godiste + "god " + lista[i].Gorivo);
                    cbPonudaAuta.Items.Add(lista[i].Marka + " " + lista[i].Model + " " + lista[i].Godiste + "god " + lista[i].Gorivo);
                }
                //  cbModel.DataSource = null;
                //     cbKubikaza.DataSource = null;
                fs.Dispose();
                fs.Close();
                /*
                if (lstMarka.Size.Equals(lista.Count))
                {
                    lstMarka.SetSelected(0, false);
                    if (lstMarka.SelectedIndex > -1)
                        lstModel.DataSource = (lista[lstMarka.SelectedIndex].Model);
                }*/
            }//ISCITAVANJE AUTOMOBILA



            // ISCITAVANJE ADMINISTRATORA
            if (File.Exists(adminiFajl))
            {
                bf = new BinaryFormatter();
                fs = new FileStream(adminiFajl, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);

                if (fs.Length == 0)
                {
                    MessageBox.Show("Fajl za admine je prazan trenutno");
                }
                else
                {
                    ucitaniAdmini = bf.Deserialize(fs) as List<Administrator>;

                    for (int i = 0; i < ucitaniAdmini.Count; i++)
                    {
                        cbTrenutniAdministratori.Items.Add(ucitaniAdmini[i].IDBRadmina + " " + ucitaniAdmini[i].Titula + " " + ucitaniAdmini[i].Ime + " " + ucitaniAdmini[i].Prezime + " " + ucitaniAdmini[i].KorisnickoIme);

                    }
                    for (int i = 0; i < ucitaniAdmini.Count; i++)
                    {
                        if (ucitaniAdmini[i].Titula == "Kupac")
                        {
                            listaKupaca.Add(ucitaniAdmini[i]);

                        }
                    }
                }
                fs.Dispose();
                fs.Close();

                if (listaKupaca.Count != 0)
                {
                    foreach (Administrator a in listaKupaca)
                    {
                        cbKupacDodavanje.Items.Add(a);
                        cbKupacOtkazivanje.Items.Add(a);
                    }
                    //ISCITAVANJE ADMINISTRATORA

                    //    cbMarka.SelectedIndexChanged += prikazOstalih;
                    //    //cbModel.SelectedIndexChanged += prikazOstalih;

                    //    //  cbGodiste.SelectedIndexChanged += prikazModela;
                    //  //  cbGodiste.SelectedIndexChanged += prikazModela;
                    //    cbGodiste.SelectedIndexChanged += prikazGodista;
                    //    cbModel.SelectedIndexChanged += prikazModela;
                    //    //cbKubikaza.SelectedIndexChanged += prikazModela;
                    //    cbKubikaza.SelectedIndexChanged += prikazKubikaza;
                    //    cbKaroserija.SelectedIndexChanged += prikazKaroserija;
                    //    cbBrVrata.SelectedIndexChanged += prikazVrata;
                    //    cbGorivo.SelectedIndexChanged += prikazGoriva;
                    //    cbPogon.SelectedIndexChanged += prikazPogona;
                    //    cbMenjac.SelectedIndexChanged += prikazMenjac;
                    //}
                }
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void btnRezervisi_Click(object sender, EventArgs e)
        {
            var daLiJeBroj = int.TryParse(txtGodiste.Text, out int a);
            var daLiJeBrojKubikaza = int.TryParse(txtKubikaza.Text, out int s);
            var daLiJeBrojBrVrata = int.TryParse(txtBrojVrata.Text, out int d);
            if (txtMarka.Text == "" || txtModel.Text == "" || txtGodiste.Text == "" || txtKubikaza.Text == "" || txtKaroserija.Text == "" || txtBrojVrata.Text == "" || txtGorivo.Text == "" || txtPogon.Text == "" || txtMenjac.Text == "")
            {
                MessageBox.Show("Sva polja moraju biti popunjena!");
            }
            if (daLiJeBroj == false)
            {
                MessageBox.Show("Godiste mora biti broj!");
            }
            if (daLiJeBrojBrVrata==false)
            {
                MessageBox.Show("Broj vrata mora biti broj!");
            }
            if (daLiJeBrojKubikaza == false)
            {
                MessageBox.Show("Kubikaza mora da bude broj!");
            }
            else
            {
                auto = new Automobil(txtMarka.Text, txtModel.Text, Int32.Parse(txtGodiste.Text), Int32.Parse(txtKubikaza.Text), txtPogon.Text, txtMenjac.Text, txtKaroserija.Text, txtGorivo.Text, Int32.Parse(txtBrojVrata.Text));
                automobili.Add(auto);




                if (File.Exists(automobiliFajl))
                {
                    bf = new BinaryFormatter();
                    fs = new FileStream(automobiliFajl, FileMode.Open, FileAccess.Write, FileShare.ReadWrite);
                    //fs = File.OpenWrite(putanjaAuta);

                    lista.Add(auto);
                    bf.Serialize(fs, lista);
                    fs.Dispose();
                    fs.Close();
                    MessageBox.Show("Auto je dodat");
                }
                else
                {
                    bf = new BinaryFormatter();
                    fs = new FileStream(automobiliFajl, FileMode.CreateNew, FileAccess.Write, FileShare.ReadWrite);
                    //fs = File.OpenWrite(putanjaAuta);

                    lista.Add(auto);
                    bf.Serialize(fs, lista);
                    fs.Dispose();
                    fs.Close();
                    MessageBox.Show("Auto je dodat");
                }

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button19_Click(object sender, EventArgs e)
        {



            /*
            int j = 0;
            for(int i=0; i<lista.Count; i++)
            {
                
                if (auto.Marka.Equals(lista[i].Marka))
                {
                    MessageBox.Show(automobili[i].Marka+" vec postoji u bazi");
                    lista[i].Model.AddRange(automobili[i].Model);
                    lista[i].Kubikaza.AddRange(automobili[i].Kubikaza);
                    lista[i].Karoserija = automobili[i].Karoserija;
                    lista[i].Gorivo = automobili[i].Gorivo;
                    lista[i].BrojVrata = automobili[i].BrojVrata;
                    lista[i].Godiste = automobili[i].Godiste;
                    lista[i].Pogon = automobili[i].Pogon;
                    lista[i].VrstaMenjaca = automobili[i].VrstaMenjaca;

                    bf.Serialize(fs, lista);
                    fs.Dispose();
                    fs.Close();
                    MessageBox.Show("Autu su dodate ostale karakteristike");
                    break;
                }
                j++;
                */
            /* else
             {
                 lista.Add(automobili[i]);
                 bf.Serialize(fs, lista);
                 fs.Dispose();
                 fs.Close();
                 MessageBox.Show("Auto je unikat i smesten je u bazu");
                 break;
             }*/
            /* }
             if (j.Equals(lista.Count))
             {
                 lista.Add(auto);
                 bf.Serialize(fs, lista);
                 fs.Dispose();
                 fs.Close();
                 MessageBox.Show("Auto je uspesno dodat");

             }
             */
            /*
            int i = 0;
            if (lista.Count.Equals(-1))
            {
                i++;
                lista.Add(auto);
                bf.Serialize(fs, lista);
                fs.Dispose();
                fs.Close();
                MessageBox.Show("Auto je dodat");

            }

            else if (lista.Count > -1)
            {
                i++;
                foreach (Automobil a in lista)
                {
                    i++;
                    if (a.Marka.Equals(auto.Marka))
                    {

                        MessageBox.Show("Postoji ovaj auto:" + a.Marka);
                        a.IdAuta = a.IdAuta + 1;
                        a.Model.AddRange(auto.Model);
                        a.Kubikaza.AddRange(auto.Kubikaza);
                        a.Gorivo += auto.Gorivo;
                        bf.Serialize(fs, lista);
                        fs.Dispose();
                        fs.Close();
                        MessageBox.Show("Iako postoji dodat je");
                        break;

                    }


                    else
                    {
                        if (lista.Count<=i)
                        {
                            lista.Add(auto);
                            bf.Serialize(fs, lista);
                            fs.Dispose();
                            fs.Close();
                            MessageBox.Show("Ceo autic je dodat");
                            break;
                        }
                    }

                    /*    foreach (Automobil c in automobili)
                        {
                            lista.Add(c);
                        }
                        bf.Serialize(fs, lista);
                        MessageBox.Show("Uspesno snimanje u fajl");
                        fs.Dispose();*/

        }




        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cbGorivo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lstModel_SelectedIndexChanged(object sender, EventArgs e)
        {


        }

        private void button20_Click(object sender, EventArgs e)
        {




        }

        //private void prikazOstalih(object sender, EventArgs e)
        //{

        //    object m = cbMarka.SelectedItem;
        //    string marka = m as string;

        //    Boolean flagGodiste = false;
        //    Boolean flagKubikaza = false;
        //    Boolean flagKaroserija = false;
        //    Boolean flagBrojVrata = false;
        //    Boolean flagGorivo = false;
        //    Boolean flagPogon = false;
        //    Boolean flagMenjac = false;
        //    Boolean flagModel = false;

        //    cbModel.Items.Clear();
        //    cbGodiste.Items.Clear();
        //    cbKubikaza.Items.Clear();
        //    cbKaroserija.Items.Clear();
        //    cbBrVrata.Items.Clear();
        //    cbGorivo.Items.Clear();
        //    cbPogon.Items.Clear();
        //    cbMenjac.Items.Clear();
        //    for (int i = 0; i < lista.Count; i++)
        //    {
        //        if (lista[i].Marka == marka)
        //        {
        //            for (int j = i + 1; j < lista.Count; j++)
        //            {
        //                if (lista[i].Marka == lista[j].Marka)
        //                {
        //                    if (lista[i].Model == lista[j].Model) { flagModel = true; }
        //                    if (lista[i].Godiste == lista[j].Godiste) { flagGodiste = true; }
        //                    if (lista[i].Kubikaza == lista[j].Kubikaza) { flagKubikaza = true; }
        //                    if (lista[i].Karoserija == lista[j].Karoserija) { flagKaroserija = true; }
        //                    if (lista[i].BrojVrata == lista[j].BrojVrata) { flagBrojVrata = true; }
        //                    if (lista[i].Gorivo == lista[j].Gorivo) { flagGorivo = true; }
        //                    if (lista[i].Pogon == lista[j].Pogon) { flagPogon = true; }
        //                    if (lista[i].VrstaMenjaca == lista[j].VrstaMenjaca) { flagMenjac = true; }
        //                }
        //            }
        //          if (flagModel == false) { cbModel.Items.Add(lista[i].Model); }
        //            if (flagGodiste == false) { cbGodiste.Items.Add(lista[i].Godiste); }
        //            if (flagKubikaza == false) { cbKubikaza.Items.Add(lista[i].Kubikaza); }
        //            if (flagKaroserija == false) { cbKaroserija.Items.Add(lista[i].Karoserija); }
        //            if (flagBrojVrata == false) { cbBrVrata.Items.Add(lista[i].BrojVrata); }
        //            if (flagGorivo == false) { cbGorivo.Items.Add(lista[i].Gorivo); }
        //            if (flagPogon == false) { cbPogon.Items.Add(lista[i].Pogon); }
        //            if (flagMenjac == false) { cbMenjac.Items.Add(lista[i].VrstaMenjaca); }
        //            flagModel=flagGodiste = flagKubikaza = flagKaroserija = flagBrojVrata = flagGorivo = flagPogon = flagMenjac = false;
        //        }
        //    }
        //}
        //public void prikazModela(object sender, EventArgs e)
        //{
        //    Boolean uslov = true;
        //    object m = cbMarka.SelectedItem;
        //    string marka = m as string;

        //    object mo = cbModel.SelectedItem;
        //    string model = mo as string;

        //    int modelIndex = cbModel.SelectedIndex;

        //    Boolean flagBrVrata = false;
        //    Boolean flagGodiste = false;
        //    Boolean flagKubikaza = false;
        //    Boolean flagKaroserija = false;
        //    Boolean flagGorivo = false;
        //    Boolean flagPogon = false;
        //    Boolean flagMenjac = false;

        //    cbGodiste.Items.Clear();
        //    cbKubikaza.Items.Clear();
        //    cbKaroserija.Items.Clear();
        //    cbBrVrata.Items.Clear();
        //    cbGorivo.Items.Clear();
        //    cbPogon.Items.Clear();
        //    cbMenjac.Items.Clear();

        //    for (int i = 0; i < lista.Count; i++)
        //    {
        //        if (lista[i].Marka == marka && lista[i].Model.Equals(model))
        //        {
        //            for (int j = i + 1; j < lista.Count; j++)
        //            {
        //                /*   if (lista[i].Model == lista[j].Model && lista[i].Marka == lista[j].Marka)
        //                   {
        //                       flagNadjen = true;
        //                   }*/
        //                if (lista[i].Model == lista[j].Model)
        //                {
        //                    if (lista[i].Godiste == lista[j].Godiste) { flagGodiste = true; }
        //                    //if (lista[i].Kubikaza == lista[j].Kubikaza) { flagKubikaza = true; }
        //                   // if (lista[i].Karoserija == lista[j].Karoserija) { flagKaroserija = true; }
        //                  //  if (lista[i].BrojVrata == lista[j].BrojVrata) { flagBrVrata = true; }
        //                  //  if (lista[i].Gorivo == lista[j].Gorivo) { flagGorivo = true; }
        //                  //  if (lista[i].Pogon == lista[j].Pogon) { flagPogon = true; }
        //                  //  if (lista[i].VrstaMenjaca == lista[j].VrstaMenjaca) { flagMenjac = true; }
        //                }
        //            }

        //            if (flagGodiste == false) {

        //                cbGodiste.Items.Add(lista[i].Godiste);


        //            }
        //         /*   if (flagKubikaza == false) {
        //               // cbKubikaza.Items.Clear();
        //                cbKubikaza.Items.Add(lista[i].Kubikaza);

        //            }
        //            if (flagKaroserija == false) {
        //              //  cbKaroserija.Items.Clear();
        //                cbKaroserija.Items.Add(lista[i].Karoserija);

        //            }
        //            if (flagBrVrata == false) {
        //               // cbBrVrata.Items.Clear();
        //                cbBrVrata.Items.Add(lista[i].BrojVrata);

        //            }

        //            if (flagGorivo == false) {
        //              //  cbGorivo.Items.Clear();
        //                cbGorivo.Items.Add(lista[i].Gorivo);

        //            }
        //            if (flagPogon == false) {
        //               // cbPogon.Items.Clear();
        //                cbPogon.Items.Add(lista[i].Pogon);

        //            }
        //            if (flagMenjac == false) {
        //               // cbMenjac.Items.Clear();
        //                cbMenjac.Items.Add(lista[i].VrstaMenjaca);

        //            }
        //            */
        //        }

        //        cbModel.Enabled = false;

        //    }



        //    flagGodiste = flagKubikaza = flagKaroserija = flagBrVrata = flagGorivo = flagPogon = flagMenjac = false;
        //}
        //public void prikazKubikaza(object sender, EventArgs e)
        //{
        //    Boolean flagGodiste = false;
        //    Boolean flagKubikaza = false;
        //    Boolean flagKaroserija = false;
        //    Boolean flagBrojVrata = false;
        //    Boolean flagGorivo = false;
        //    Boolean flagPogon = false;
        //    Boolean flagMenjac = false;

        //    object k = cbKubikaza.SelectedItem;
        //    int kubikaza = Convert.ToInt32(k);
        //    object m = cbMarka.SelectedItem;
        //    string marka = m as string;

        //    for (int i = 0; i < lista.Count; i++)
        //    {
        //        if (lista[i].Marka == marka && lista[i].Kubikaza.Equals(kubikaza))
        //        {
        //            for (int j = i + 1; j < lista.Count; j++)
        //            {
        //                if (lista[i].Model == lista[j].Model)
        //                {
        //                    if (lista[i].Karoserija == lista[j].Karoserija) { flagKaroserija = true; }

        //                }

        //            }
        //            if (flagKaroserija == false)
        //            {
        //                cbKaroserija.Items.Clear();
        //                cbKaroserija.Items.Add(lista[i].Karoserija.ToString());
        //            }
        //        }
        //    }
        //    cbKubikaza.Enabled = false;
        //    flagKaroserija = false;
        //}
        //public void prikazMenjac(object sender,EventArgs e) {

        //    /*   Boolean flagGodiste = false;
        //       Boolean flagKubikaza = false;
        //       Boolean flagKaroserija = false;
        //       Boolean flagBrojVrata = false;
        //       Boolean flagGorivo = false;
        //       Boolean flagPogon = false;
        //       Boolean flagMenjac = false;

        //       object me = cbMenjac.SelectedItem;
        //       string menjac = me as string;

        //       object m = cbMarka.SelectedItem;
        //       string marka = m as string;

        //       for (int i = 0; i < lista.Count; i++)
        //       {
        //           if (lista[i].Marka == marka && lista[i].VrstaMenjaca.Equals(menjac))
        //           {
        //               for (int j = i + 1; j < lista.Count; j++)
        //               {
        //                   if (lista[i].Marka == lista[j].Marka)
        //                   {
        //                       if (lista[i].VrstaMenjaca == lista[j].VrstaMenjaca)
        //                       {
        //                           flagMenjac = true;
        //                       }
        //                   }

        //               }
        //               if (flagMenjac == false)
        //               {
        //                   cbKubikaza.Items.Clear();
        //                   cbKubikaza.Items.Add(lista[i].Kubikaza.ToString());
        //               }
        //           }
        //       }
        //       flagMenjac = false;*/
        //    cbMenjac.Enabled = false;
        //}
        //public void prikazGodista(object sender, EventArgs e)
        //{
        //    Boolean flagGodiste = false;
        //    Boolean flagKubikaza = false;
        //    Boolean flagKaroserija = false;
        //    Boolean flagBrojVrata = false;
        //    Boolean flagGorivo = false;
        //    Boolean flagPogon = false;
        //    Boolean flagMenjac = false;
        //    Boolean flagModel = false;

        //    object g = cbGodiste.SelectedItem;
        //    int godiste = Convert.ToInt32(g);
        //    object m = cbMarka.SelectedItem;
        //    string marka = m as string;
        //    object mo = cbModel.SelectedItem;
        //    string model = mo as string;

        //    cbModel.Items.Clear();
        //    cbKubikaza.Items.Clear();
        //    cbKaroserija.Items.Clear();
        //    cbBrVrata.Items.Clear();
        //    cbGorivo.Items.Clear();
        //    cbPogon.Items.Clear();
        //    cbMenjac.Items.Clear();


        //    for (int i = 0; i < lista.Count; i++)
        //    {
        //        if(lista[i].Marka==marka && lista[i].Godiste.Equals(godiste))
        //        {
        //            for (int j = i + 1; j < lista.Count; j++)
        //            {
        //                if (lista[i].Godiste == lista[j].Godiste)
        //                {
        //                   // if (lista[i].Model == lista[j].Model) {flagModel = true;}
        //                    if (lista[i].Kubikaza == lista[j].Kubikaza) { flagKubikaza = true; }
        //                   // if (lista[i].Karoserija == lista[j].Karoserija) { flagKaroserija = true; }
        //                   // if (lista[i].BrojVrata == lista[j].BrojVrata) { flagBrojVrata = true; }
        //                   // if (lista[i].Gorivo == lista[j].Gorivo) { flagGorivo = true; }
        //                  //  if (lista[i].Pogon == lista[j].Pogon) { flagPogon = true; }
        //                 //if (lista[i].VrstaMenjaca == lista[j].VrstaMenjaca) { flagMenjac = true; }

        //                }

        //            }
        //       //     if (flagModel == false) { cbModel.Items.Add(lista[i].Model); }
        //            if (flagKubikaza == false){cbKubikaza.Items.Add(lista[i].Kubikaza.ToString());}
        //          /*  if (flagKaroserija == false) { cbKaroserija.Items.Add(lista[i].Karoserija); }
        //            if (flagBrojVrata == false) { cbBrVrata.Items.Add(lista[i].BrojVrata); }
        //            if (flagGorivo == false) { cbGorivo.Items.Add(lista[i].Gorivo); }
        //            if (flagPogon == false) { cbPogon.Items.Add(lista[i].Pogon); }
        //            if (flagMenjac == false) { cbMenjac.Items.Add(lista[i].VrstaMenjaca); }*/

        //        }
        //    }
        //    cbGodiste.Enabled = false;
        //    flagModel = flagKubikaza = flagKaroserija = flagBrojVrata = flagGorivo = flagPogon = flagMenjac = false;
        //}

        //public void prikazVrata(object sender, EventArgs e)
        //{
        //    Boolean flagGodiste = false;
        //    Boolean flagKubikaza = false;
        //    Boolean flagKaroserija = false;
        //    Boolean flagBrojVrata = false;
        //    Boolean flagGorivo = false;
        //    Boolean flagPogon = false;
        //    Boolean flagMenjac = false;

        //    object v = cbBrVrata.SelectedItem;
        //    int vrata = Convert.ToInt32(v);
        //    object k = cbKaroserija.SelectedItem;
        //    string karoserija = k as string;

        //    for (int i = 0; i < lista.Count; i++)
        //    {
        //        if (lista[i].Karoserija == karoserija && lista[i].BrojVrata.Equals(vrata))
        //        {
        //            for (int j = i + 1; j < lista.Count; j++)
        //            {
        //                if (lista[i].Model == lista[j].Model)
        //                {
        //                    if (lista[i].BrojVrata == lista[j].BrojVrata)
        //                    {
        //                        flagGorivo = true;
        //                    }
        //                }

        //            }
        //            if (flagGorivo == false)
        //            {
        //                cbGorivo.Items.Clear();
        //                cbGorivo.Items.Add(lista[i].Gorivo.ToString());
        //            }
        //        }
        //    }
        //    cbBrVrata.Enabled = false;
        //    flagBrojVrata = false;
        //}

        //public void prikazGoriva(object sender, EventArgs e)
        //{
        //    Boolean flagGodiste = false;
        //    Boolean flagKubikaza = false;
        //    Boolean flagKaroserija = false;
        //    Boolean flagBrojVrata = false;
        //    Boolean flagGorivo = false;
        //    Boolean flagPogon = false;
        //    Boolean flagMenjac = false;

        //    object g = cbGorivo.SelectedItem;
        //    string gorivo = g as string;
        //    object v = cbBrVrata.SelectedItem;
        //    int vrata=Convert.ToInt32(v);

        //    for (int i = 0; i < lista.Count; i++)
        //    {
        //        if (lista[i].BrojVrata == vrata && lista[i].Gorivo.Equals(gorivo))
        //        {
        //            for (int j = i + 1; j < lista.Count; j++)
        //            {
        //                if (lista[i].Gorivo == lista[j].Gorivo)
        //                {
        //                    if (lista[i].Pogon == lista[j].Pogon)
        //                    {
        //                        flagPogon = true;
        //                    }
        //                }

        //            }
        //            if (flagPogon == false)
        //            {
        //                cbPogon.Items.Clear();
        //                cbPogon.Items.Add(lista[i].Pogon.ToString());
        //            }
        //        }
        //    }
        //    cbGorivo.Enabled = false;
        //    flagPogon = false;
        //}

        //public void prikazKaroserija(object sender,EventArgs e)
        //{
        //    Boolean flagGodiste = false;
        //    Boolean flagKubikaza = false;
        //    Boolean flagKaroserija = false;
        //    Boolean flagBrojVrata = false;
        //    Boolean flagGorivo = false;
        //    Boolean flagPogon = false;
        //    Boolean flagMenjac = false;

        //    object k = cbKaroserija.SelectedItem;
        //    string karoserija = k as string;
        //    object ku = cbKubikaza.SelectedItem;
        //    int kubikaza = Convert.ToInt32(ku);

        //    for (int i = 0; i < lista.Count; i++)
        //    {
        //        if (lista[i].Kubikaza == kubikaza && lista[i].Karoserija.Equals(karoserija) )
        //        {
        //            for (int j = i + 1; j < lista.Count; j++)
        //            {
        //                if (lista[i].Model == lista[j].Model)
        //                {
        //                    if (lista[i].BrojVrata == lista[j].BrojVrata)
        //                    {
        //                        flagBrojVrata = true;
        //                    }
        //                }

        //            }
        //            if (flagBrojVrata == false)
        //            {
        //                cbBrVrata.Items.Clear();
        //                cbBrVrata.Items.Add(lista[i].BrojVrata.ToString());
        //            }
        //        }
        //    }
        //    cbKaroserija.Enabled = false;
        //    flagBrojVrata = false;
        //}

        //public void prikazPogona(object sender, EventArgs e)
        //{
        //    Boolean flagGodiste = false;
        //    Boolean flagKubikaza = false;
        //    Boolean flagKaroserija = false;
        //    Boolean flagBrojVrata = false;
        //    Boolean flagGorivo = false;
        //    Boolean flagPogon = false;
        //    Boolean flagMenjac = false;

        //    object p = cbPogon.SelectedItem;
        //    string pogon = p as string;
        //    object g = cbGorivo.SelectedItem;
        //    string gorivo = g as string;

        //    for (int i = 0; i < lista.Count; i++)
        //    {
        //        if (lista[i].Gorivo == gorivo && lista[i].Pogon.Equals(pogon))
        //        {
        //            for (int j = i + 1; j < lista.Count; j++)
        //            {
        //                if (lista[i].Pogon == lista[j].Pogon)
        //                {
        //                    if (lista[i].VrstaMenjaca == lista[j].VrstaMenjaca)
        //                    {
        //                        flagMenjac = true;
        //                    }
        //                }

        //            }
        //            if (flagMenjac == false)
        //            {
        //                cbMenjac.Items.Clear();
        //                cbMenjac.Items.Add(lista[i].VrstaMenjaca.ToString());
        //            }
        //        }
        //    }
        //    cbPogon.Enabled = false;
        //    flagMenjac = false;
        //}
        private void cbMarka_SelectedIndexChanged(object sender, EventArgs e)
        {



            ///*
            //cbModel.DataSource=lista[cbMarka.SelectedIndex].Model;

            //cbModel.SelectedIndex = -1;
            //cbKubikaza.DataSource = null;
            //*/
            //Boolean uslov = true;
            //object m = cbMarka.SelectedItem;
            //string marka = m as string;
            //Boolean flagNadjen = false;
            //List<Automobil> ListaAutomobila = new List<Automobil>();
            //ListaAutomobila = lista;
            ////       RadSaDatotekama.citanjeAutomobilDatoteke(ref ListaAutomobila);
            //cbModel.Items.Clear();
            ////   GlavnaLista.Clear();
            //for (int i = 0; i < ListaAutomobila.Count; i++)
            //{
            //    if (ListaAutomobila[i].Marka == marka)
            //    {
            //        for (int j = i + 1; j < ListaAutomobila.Count; j++)
            //        {
            //            if (ListaAutomobila[i].Model == ListaAutomobila[j].Model &&
            //                ListaAutomobila[i].Marka == ListaAutomobila[j].Marka)
            //            {
            //                flagNadjen = true;
            //            }
            //        }
            //        if (flagNadjen == false) { cbModel.Items.Add(ListaAutomobila[i].Model); }
            //        else { flagNadjen = false; }
            //    }
            //    if (cbMarka.Text != "")
            //    {
            //        if (ListaAutomobila[i].Marka != cbMarka.Text) { uslov = false; }
            //    }
            //    /*    if (cbModel.Text != "")
            //        {
            //            if (ListaAutomobila[i].Model != cbModel.Text) { uslov = false; }
            //        }*/
            //    if (cbGodiste.Text != "")
            //    {
            //        if (ListaAutomobila[i].Godiste != int.Parse(cbGodiste.Text)) { uslov = false; }
            //    }
            //    /*     if (cbKubikaza.Text != "")
            //         {
            //             if (ListaAutomobila[i].Kubikaza != int.Parse(cbKubikaza.Text)) { uslov = false; }
            //         }*/
            //    if (cbKaroserija.Text != "")
            //    {
            //        if (ListaAutomobila[i].Karoserija != cbKaroserija.Text) { uslov = false; }
            //    }
            //    if (cbBrVrata.Text != "")
            //    {
            //        if (ListaAutomobila[i].BrojVrata != int.Parse(cbBrVrata.Text)) { uslov = false; }
            //    }
            //    if (cbGorivo.Text != "")
            //    {
            //        if (ListaAutomobila[i].Gorivo != cbGorivo.Text) { uslov = false; }
            //    }
            //    if (cbPogon.Text != "")
            //    {
            //        if (ListaAutomobila[i].Pogon != cbPogon.Text) { uslov = false; }
            //    }
            //    if (cbMenjac.Text != "")
            //    {
            //        if (ListaAutomobila[i].VrstaMenjaca != cbMenjac.Text) { uslov = false; }
            //    }
            //    /*   if (uslov == true) { GlavnaLista.Add(ListaAutomobila[i]); }
            //       uslov = true;
            //   }*/
            //    ListaAutomobila.Clear();
            //}
        }

        private void cbKubikaza_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cbModel_SelectedIndexChanged(object sender, EventArgs e)
        {
            /*
            if (cbModel.SelectedIndex > -1)
            {
                cbKubikaza.DataSource = (lista[cbMarka.SelectedIndex].Kubikaza);
                cbKubikaza.SelectedIndex = -1;
            }
            *//*
            if (cbModel.SelectedIndex >= 0)
            {
                /*    foreach (Automobil a in lista)
                    {
                        if (cbMarka.SelectedValue.Equals(a.Marka))
                        {
                            if (cbModel.SelectedValue.Equals(a.Model))
                            {
                                cbKubikaza.DataSource = lista[cbModel.SelectedIndex].Kubikaza;
                            }
                        }*/


            /*

            var q1 = from p in lista where p.Marka.Equals(cbMarka.SelectedValue) && p.Model.Equals(cbModel.SelectedValue) select p;
            cbKubikaza.Items.Add(q1);
            */




        }

        private void txtMarka_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtModel_TextChanged(object sender, EventArgs e)
        {

        }

        private void cbGodiste_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnDodajNovogAdmina_Click(object sender, EventArgs e)
        {
            Boolean flagIDBR = false;
            Boolean flagTitula = false;
            Boolean flagKorisnickoIme = false;
            Boolean flagPrezime = false;
            Boolean flagDatumRodjenja = false;
            Boolean flagIme = false;
            Boolean flagLozinka = false;
            Boolean flagKorisnickoImePopuna = false;

            var daLiJeBroj = int.TryParse(txtIdbrKorisnika.Text, out int n);

            for (int i = 0; i < ucitaniAdmini.Count; i++)
            {
                if (txtKorisnickoImeAdmina.Text.Equals(ucitaniAdmini[i].KorisnickoIme))
                {
                    flagKorisnickoIme = true;
                }

            }



            if (txtIdbrKorisnika.Text == "" || txtTitula.Text == "" || txtImeAdmina.Text == "" || txtPrezimeAdmina.Text == "" || txtDatumRodjenja.Text == "" || txtKorisnickoImeAdmina.Text == "" || txtLozinkaAdmina.Text == "")
            {
                MessageBox.Show("Niste popunili sva polja");
            }
            if (txtTitula.Text != "")
            {
                flagTitula = true;
            }
            if (txtImeAdmina.Text != "")
            {
                flagIme = true;
            }

            if (txtPrezimeAdmina.Text != "")
            {
                flagPrezime = true;
            }
            if (txtDatumRodjenja.Text != "")
            {
                flagDatumRodjenja = true;
            }
            if (txtKorisnickoImeAdmina.Text != "")
            {
                flagKorisnickoImePopuna = true;
            }
            if (txtLozinkaAdmina.Text != "")
            {
                flagLozinka = true;
            }

            if (daLiJeBroj == false)
            {
                MessageBox.Show("IDBR mora da bude broj");
            }
            else if (flagKorisnickoIme == true)
            {
                MessageBox.Show("Korisnicko ime: " + txtKorisnickoImeAdmina.Text + " vec postoji izaberite opet");
            }
            else
            {
                for (int i = 0; i < ucitaniAdmini.Count; i++)
                {
                    if (Int32.Parse(txtIdbrKorisnika.Text) == ucitaniAdmini[i].IDBRadmina)
                    {
                        MessageBox.Show("IDBR: " + txtIdbrKorisnika.Text + " je zauzet molimo Vas izaberite drugi");
                        flagIDBR = true;
                    }
                }

                if (flagIDBR == false && flagTitula == true && flagIme == true && flagPrezime == true && flagDatumRodjenja == true && flagKorisnickoImePopuna == true && flagLozinka == true)
                {

                    admin = new Administrator(Int32.Parse(txtIdbrKorisnika.Text), txtTitula.Text, txtImeAdmina.Text, txtPrezimeAdmina.Text, txtDatumRodjenja.Text, txtKorisnickoImeAdmina.Text, txtLozinkaAdmina.Text);
                    administratori.Add(admin);
                    if (File.Exists(adminiFajl))
                    {
                        bf = new BinaryFormatter();
                        fs = new FileStream(adminiFajl, FileMode.Open, FileAccess.Write, FileShare.ReadWrite);

                        ucitaniAdmini.Add(admin);
                        bf.Serialize(fs, ucitaniAdmini);

                        fs.Dispose();
                        fs.Close();
                        MessageBox.Show("Novi admin " + txtImeAdmina.Text + " je uspesno dodat");
                    }
                    else
                    {
                        bf = new BinaryFormatter();
                        fs = new FileStream(adminiFajl, FileMode.CreateNew, FileAccess.Write, FileShare.ReadWrite);

                        ucitaniAdmini.Add(admin);
                        bf.Serialize(fs, ucitaniAdmini);

                        fs.Dispose();
                        fs.Close();
                    }

                }
            }
        }


        private void btnAzurirajAdmina_Click(object sender, EventArgs e)
        {
            Boolean flagIDBR = false;
            Boolean flagTitula = false;
            Boolean flagIme = false;
            Boolean flagPrezime = false;
            Boolean flagDatumRodjenja = false;
            Boolean flagKorisnickoIme = false;
            Boolean flagLozinka = false;

            var daLiJeBroj = int.TryParse(txtIdbrKorisnika.Text, out int n);
            var daLiJeTitulaText = txtTitula.Text is string;
            var daLiJeImeText = txtImeAdmina.Text is string;
            var daLiJePrezimeText = txtPrezimeAdmina.Text is string;
           

            for (int i = 0; i < ucitaniAdmini.Count; i++)
            {
                if (cbTrenutniAdministratori.SelectedIndex == i)
                {
                    if (Int32.Parse(txtIdbrKorisnika.Text) != ucitaniAdmini[i].IDBRadmina)
                    {
                        ucitaniAdmini[i].IDBRadmina = Int32.Parse(txtIdbrKorisnika.Text);
                        flagIDBR = true;
                        MessageBox.Show("IDBR Admina je promenjen");
                    }

                    if (daLiJeBroj == false)
                    {
                        MessageBox.Show("IDBR mora da bude broj!");
                    }
                    if (daLiJeTitulaText == false)
                    {
                        MessageBox.Show("Titula ne sme da ima broj!");
                    }
                    if (daLiJeImeText == false)
                    {
                        MessageBox.Show("Ime ne sme da ima broj!");
                    }
                    if (daLiJePrezimeText == false)
                    {
                        MessageBox.Show("Prezime ne sme da ima broj!");
                    }

                  



                    if (txtTitula.Text != ucitaniAdmini[i].Titula)
                    {
                        ucitaniAdmini[i].Titula = txtTitula.Text;
                        flagTitula = true;
                        MessageBox.Show("Titula je promenjena");
                    }
                    if (txtImeAdmina.Text != ucitaniAdmini[i].Ime)
                    {
                        ucitaniAdmini[i].Ime = txtImeAdmina.Text;
                        flagIme = true;
                        MessageBox.Show("Ime admina je promenjeno");
                    }
                    if (txtPrezimeAdmina.Text != ucitaniAdmini[i].Prezime)
                    {
                        ucitaniAdmini[i].Prezime = txtPrezimeAdmina.Text;
                        flagPrezime = true;
                        MessageBox.Show("Prezime admina je promenjeno");
                    }
                    if (txtDatumRodjenja.Text != ucitaniAdmini[i].DatumRodjenja)
                    {
                        ucitaniAdmini[i].DatumRodjenja = txtDatumRodjenja.Text;
                        flagDatumRodjenja = true;
                        MessageBox.Show("Datum rodjenja je promenjen");
                    }
                    if (txtKorisnickoImeAdmina.Text != ucitaniAdmini[i].KorisnickoIme)
                    {
                        ucitaniAdmini[i].KorisnickoIme = txtKorisnickoImeAdmina.Text;
                        flagKorisnickoIme = true;
                        MessageBox.Show("Korisnicko ime je promenjeno");
                    }
                    if (txtLozinkaAdmina.Text != ucitaniAdmini[i].Lozinka)
                    {
                        ucitaniAdmini[i].Lozinka = txtLozinkaAdmina.Text;
                        flagLozinka = true;
                        MessageBox.Show("Lozinka je promenjena");
                    }
                }

            }
            if (flagIDBR == true || flagTitula == true || flagIme == true || flagPrezime == true || flagDatumRodjenja == true || flagKorisnickoIme == true || flagLozinka == true)
            {
                bf = new BinaryFormatter();
                fs = new FileStream(adminiFajl, FileMode.Open, FileAccess.Write, FileShare.ReadWrite);

                bf.Serialize(fs, ucitaniAdmini);

                fs.Dispose();
                fs.Close();
                MessageBox.Show("Promena uspesno sacuvana u fajl");
            }

            
        }

        private void btnUkloniAdmina_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < ucitaniAdmini.Count; i++)
            {
                if (cbTrenutniAdministratori.SelectedIndex == i)
                {
                    ucitaniAdmini.RemoveAt(i);

                    bf = new BinaryFormatter();
                    fs = new FileStream(adminiFajl, FileMode.Open, FileAccess.Write, FileShare.ReadWrite);
                    bf.Serialize(fs, ucitaniAdmini);

                    fs.Dispose();
                    fs.Close();

                    MessageBox.Show("Admin je izbrisan");
                }
            }
        }

        private void cbTrenutniAdministratori_SelectedIndexChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < ucitaniAdmini.Count; i++)
            {

                if (cbTrenutniAdministratori.SelectedIndex == i)
                {
                    txtIdbrKorisnika.Text = ucitaniAdmini[i].IDBRadmina.ToString();
                    txtTitula.Text = ucitaniAdmini[i].Titula;
                    txtImeAdmina.Text = ucitaniAdmini[i].Ime;
                    txtPrezimeAdmina.Text = ucitaniAdmini[i].Prezime;
                    txtDatumRodjenja.Text = ucitaniAdmini[i].DatumRodjenja;
                    txtKorisnickoImeAdmina.Text = ucitaniAdmini[i].KorisnickoIme;
                    txtLozinkaAdmina.Text = ucitaniAdmini[i].Lozinka;
                }
            }
        }

        private void btnOcistiPolja_Click(object sender, EventArgs e)
        {
            txtIdbrKorisnika.Clear();
            txtTitula.Clear();
            txtImeAdmina.Clear();
            txtPrezimeAdmina.Clear();
            txtDatumRodjenja.Clear();
            txtKorisnickoImeAdmina.Clear();
            txtLozinkaAdmina.Clear();

            if (File.Exists(adminiFajl))
            {
                bf = new BinaryFormatter();
                fs = new FileStream(adminiFajl, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);

                ucitaniAdmini = bf.Deserialize(fs) as List<Administrator>;
                cbTrenutniAdministratori.Items.Clear();

                for (int i = 0; i < ucitaniAdmini.Count; i++)
                {
                    cbTrenutniAdministratori.Items.Add(ucitaniAdmini[i].IDBRadmina + " " + ucitaniAdmini[i].Titula + " " + ucitaniAdmini[i].Ime + " " + ucitaniAdmini[i].Prezime + " " + ucitaniAdmini[i].KorisnickoIme);

                }

            }
        }

        private void cbTrenutniAutomobil_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtMarka.Clear();
            txtModel.Clear();
            txtGodiste.Clear();
            txtKubikaza.Clear();
            txtKaroserija.Clear();
            txtBrojVrata.Clear();
            txtGorivo.Clear();
            txtPogon.Clear();
            txtMenjac.Clear();
            txtIDBR.Clear();

            for (int i = 0; i < lista.Count; i++)
            {
                if (cbTrenutniAutomobil.SelectedIndex == i)
                {
                    txtMarka.Text = lista[i].Marka;
                    txtModel.Text = lista[i].Model;
                    txtGodiste.Text = lista[i].Godiste.ToString();
                    txtKubikaza.Text = lista[i].Kubikaza.ToString();
                    txtKaroserija.Text = lista[i].Karoserija;
                    txtBrojVrata.Text = lista[i].BrojVrata.ToString();
                    txtGorivo.Text = lista[i].Gorivo;
                    txtPogon.Text = lista[i].Pogon;
                    txtMenjac.Text = lista[i].VrstaMenjaca;
                    txtIDBR.Text = lista[i].IdAuta.ToString();

                }
            }
        }

        private void btnOcistiPolje_Click(object sender, EventArgs e)
        {
            txtMarka.Clear();
            txtModel.Clear();
            txtGodiste.Clear();
            txtKubikaza.Clear();
            txtKaroserija.Clear();
            txtBrojVrata.Clear();
            txtGorivo.Clear();
            txtPogon.Clear();
            txtMenjac.Clear();
            cbTrenutniAutomobil.Items.Clear();


            if (File.Exists(automobiliFajl))
            {
                bf = new BinaryFormatter();
                fs = new FileStream(automobiliFajl, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);

                lista = bf.Deserialize(fs) as List<Automobil>;
                cbTrenutniAutomobil.Items.Clear();
                cbPonudaAuta.Items.Clear();

                for (int i = 0; i < lista.Count; i++)
                {
                    cbTrenutniAutomobil.Items.Add(lista[i].Marka + " " + lista[i].Model + " " + lista[i].Godiste + "god " + lista[i].Gorivo);
                    cbPonudaAuta.Items.Add(lista[i].Marka + " " + lista[i].Model + " " + lista[i].Godiste + "god " + lista[i].Gorivo);

                }
            }

        }



        private void btnAzuzirajAuto_Click(object sender, EventArgs e)
        {
            Boolean flagMarka = false;
            Boolean flagModel = false;
            Boolean flagGodiste = false;
            Boolean flagKubikaza = false;
            Boolean flagKaroserija = false;
            Boolean flagBrVrata = false;
            Boolean flagGorivo = false;
            Boolean flagPogon = false;
            Boolean flagMenjac = false;

            var daLiJeBroj = int.TryParse(txtGodiste.Text, out int a);
            var daLiJeBrojKubikaza = int.TryParse(txtKubikaza.Text, out int s);
            var daLiJeBrojBrVrata = int.TryParse(txtBrojVrata.Text, out int d);
            if (txtMarka.Text == "" || txtModel.Text == "" || txtGodiste.Text == "" || txtKubikaza.Text == "" || txtKaroserija.Text == "" || txtBrojVrata.Text == "" || txtGorivo.Text == "" || txtPogon.Text == "" || txtMenjac.Text == "")
            {
                MessageBox.Show("Sva polja moraju biti popunjena!");
            }
            if (daLiJeBroj == false)
            {
                MessageBox.Show("Godiste mora biti broj!");
            }
            if (daLiJeBrojBrVrata)
            {
                MessageBox.Show("Broj vrata mora biti broj!");
            }
            if (daLiJeBrojKubikaza == false)
            {
                MessageBox.Show("Kubikaza mora da bude broj!");
            }
            else
                auto = new Automobil(txtMarka.Text, txtModel.Text, Int32.Parse(txtGodiste.Text), Int32.Parse(txtKubikaza.Text), txtPogon.Text, txtMenjac.Text, txtKaroserija.Text, txtGorivo.Text, Int32.Parse(txtBrojVrata.Text));
                automobili.Add(auto);




            for (int i = 0; i < lista.Count; i++)
            {

                if (cbTrenutniAutomobil.SelectedIndex == i)
                {
                    if (txtMarka.Text != lista[i].Marka)
                    {
                        lista[i].Marka = txtMarka.Text;
                        flagMarka = true;
                        MessageBox.Show("Marka je promenjena");
                    }

                    if (txtModel.Text != lista[i].Model)
                    {
                        lista[i].Model = txtModel.Text;
                        flagModel = true;
                        MessageBox.Show("Model je promenjen");
                    }

                    if (Int32.Parse(txtGodiste.Text) != lista[i].Godiste)
                    {
                        lista[i].Godiste = Int32.Parse(txtGodiste.Text);
                        flagGodiste = true;
                        MessageBox.Show("Godiste je promenjeno");
                    }

                    if (Int32.Parse(txtKubikaza.Text) != lista[i].Kubikaza)
                    {
                        lista[i].Kubikaza = Int32.Parse(txtKubikaza.Text);
                        flagKubikaza = true;
                        MessageBox.Show("Kubikaza je promenjena");
                    }
                    if (txtKaroserija.Text != lista[i].Karoserija)
                    {
                        lista[i].Karoserija = txtKaroserija.Text;
                        flagKaroserija = true;
                        MessageBox.Show("Karoserija je promenjena");
                    }

                    if (Int32.Parse(txtBrojVrata.Text) != lista[i].BrojVrata)
                    {
                        lista[i].BrojVrata = Int32.Parse(txtBrojVrata.Text);
                        flagBrVrata = true;
                        MessageBox.Show("Broj vrata je promenjen");
                    }

                    if (txtGorivo.Text != lista[i].Gorivo)
                    {
                        lista[i].Gorivo = txtGorivo.Text;
                        flagGorivo = true;
                        MessageBox.Show("Gorivo je promenjeno");
                    }

                    if (txtPogon.Text != lista[i].Pogon)
                    {
                        lista[i].Pogon = txtPogon.Text;
                        flagPogon = true;
                        MessageBox.Show("Pogon je promenjen");
                    }
                    if (txtMenjac.Text != lista[i].VrstaMenjaca)
                    {
                        lista[i].VrstaMenjaca = txtMenjac.Text;
                        flagMenjac = true;
                        MessageBox.Show("Menjac je promenjen");
                    }
                }
            }
        }

        private void btnObrisiAuto_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < lista.Count; i++)
            {
                if (cbTrenutniAutomobil.SelectedIndex == i)
                {
                    lista.RemoveAt(i);

                    bf = new BinaryFormatter();
                    fs = new FileStream(automobiliFajl, FileMode.Open, FileAccess.Write, FileShare.ReadWrite);

                    bf.Serialize(fs, lista);

                    fs.Dispose();
                    fs.Close();

                    MessageBox.Show("Auto je izbrisan");

                }
            }
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void cbPonudaAuta_SelectedIndexChanged(object sender, EventArgs e)
        {

            for (int i = 0; i < lista.Count; i++)
            {
                if (cbPonudaAuta.SelectedIndex == i)
                {
                    /*  txtMarkaPonuda.Text = lista[i].Marka;
                      txtModelPonuda.Text = lista[i].Model;
                      txtGodistePonuda.Text = lista[i].Godiste.ToString();
                      txtKubikazaPonuda.Text = lista[i].Kubikaza.ToString();
                      txtKaroserijaPonuda.Text = lista[i].Karoserija;
                      txtBrVrataPonuda.Text = lista[i].BrojVrata.ToString();
                      txtGorivoPonuda.Text = lista[i].Gorivo;
                      txtPogonPonuda.Text = lista[i].Pogon;
                      txtMenjacPonuda.Text = lista[i].VrstaMenjaca;
                      txtIdbrPonuda.Text = lista[i].IdAuta.ToString();*/

                }
            }
        }

        private void btnSacuvajPonudu_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(dtpPocetakPonude.Value.ToString());
            Ponuda p = new Ponuda(lista[cbPonudaAuta.SelectedIndex].IdAuta, dtpPocetakPonude.Value, dtpKrajPonude.Value, Convert.ToInt32(Math.Round(nupCena.Value, 0)));
            listaPonuda.Add(p);
            if (File.Exists(ponudeFajl))
            {
                bf = new BinaryFormatter();
                fs = new FileStream(ponudeFajl, FileMode.Open, FileAccess.Write, FileShare.ReadWrite);

                bf.Serialize(fs, listaPonuda);

                fs.Flush();
                fs.Dispose();
                fs.Close();
                MessageBox.Show("Ponuda je uspesno sacuvana");
            }
            else
            {
                bf = new BinaryFormatter();
                fs = new FileStream(ponudeFajl, FileMode.CreateNew, FileAccess.Write, FileShare.ReadWrite);

                bf.Serialize(fs, listaPonuda);

                fs.Flush();
                fs.Dispose();
                fs.Close();
                MessageBox.Show("Ponuda je uspesno sacuvana");
            }
            if (File.Exists(ponudeFajl))
            {
                cbPregledPonuda.Items.Clear();
                cbPonudaIzmena.Items.Clear();
                cbPonudaDodavanje.Items.Clear();

                bf = new BinaryFormatter();
                fs = new FileStream(ponudeFajl, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);

                listaPonuda = bf.Deserialize(fs) as List<Ponuda>;

                fs.Flush();
                fs.Dispose();
                fs.Close();
                for (int i = 0; i < listaPonuda.Count; i++)
                {
                    cbPregledPonuda.Items.Add("#" + listaPonuda[i].IdAuta + " po ceni od: " + listaPonuda[i].Cena + "rsd");
                    cbPonudaIzmena.Items.Add("#" + listaPonuda[i].IdAuta + " po ceni od: " + listaPonuda[i].Cena + "rsd");
                    cbPonudaDodavanje.Items.Add("#" + listaPonuda[i].IdAuta + " po ceni od: " + listaPonuda[i].Cena + "rsd");


                }
            }
        }

        private void dtpPocetakPonude_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dtpKrajPonude_ValueChanged(object sender, EventArgs e)
        {

        }

        private void cbPregledPonuda_SelectedIndexChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < listaPonuda.Count; i++)
            {
                if (cbPregledPonuda.SelectedIndex == i)
                    for (int j = 0; j < lista.Count; j++)
                    {
                        if (listaPonuda[i].IdAuta == lista[j].IdAuta)
                        {
                            //MessageBox.Show(lista[j].IdAuta + "\n" + lista[j].Model + "\n" + lista[j].Godiste + "\n" + lista[j].Kubikaza + "\n" + lista[j].Karoserija + "\n" + lista[j].BrojVrata + "\n" + lista[j].Gorivo + "\n" + lista[j].Pogon + "\n" + lista[j].VrstaMenjaca);

                            string autoNaPregled;

                            autoNaPregled = Convert.ToString(cbPonudaAuta.Items[j]);
                            txtAutomobil.Text = autoNaPregled;

                            txtAutomobil.Enabled = false;
                            txtDostupanOd.Enabled = false;
                            txtDostupanDo.Enabled = false;
                            txtPoCeniOd.Enabled = false;

                            txtDostupanOd.Text = listaPonuda[i].DatumOd.ToShortDateString();
                            txtDostupanDo.Text = listaPonuda[i].DatumDo.ToShortDateString();
                            txtPoCeniOd.Text = listaPonuda[i].Cena.ToString();

                            cbPonudaIzmena.SelectedIndex = cbPregledPonuda.SelectedIndex;
                            dtpPocetakPonudeIzmena.Value = listaPonuda[i].DatumOd.Date;
                            dtpKrajPonudeIzmena.Value = listaPonuda[i].DatumDo.Date;
                            nudCenaPoDanuIzmena.Value = listaPonuda[i].Cena;

                        }
                    }


            }

        }

        private void btnIzmenaPonuda_Click(object sender, EventArgs e)
        {
            
            Boolean flagDatumOd = false;
            Boolean flagDatumDo = false;
            Boolean flagCena = false;

            if (dtpPocetakPonudeIzmena.Value > dtpKrajPonudeIzmena.Value)
            {
                MessageBox.Show("Pocetak ponude ne moze da bude veci od kraja ponude!");
            }
            else
            {
                for (int i = 0; i < listaPonuda.Count; i++)
                {
                    if (cbPonudaIzmena.SelectedIndex == i)
                    {
                        if (listaPonuda[i].DatumOd != (dtpPocetakPonudeIzmena.Value))
                        {
                            listaPonuda[i].DatumOd = dtpPocetakPonudeIzmena.Value;
                            flagDatumOd = true;

                        }
                        if (listaPonuda[i].DatumDo != dtpKrajPonudeIzmena.Value)
                        {
                            listaPonuda[i].DatumDo = dtpKrajPonudeIzmena.Value;
                            flagDatumDo = true;

                        }
                        if (listaPonuda[i].Cena != nudCenaPoDanuIzmena.Value)
                        {
                            listaPonuda[i].Cena = Convert.ToInt32(nudCenaPoDanuIzmena.Value);
                            flagCena = true;

                        }
                    }
                }
                //  Ponuda p = new Ponuda(lista[cbPonudaIzmena.SelectedIndex].IdAuta, dtpPocetakPonudeIzmena.Value, dtpKrajPonudeIzmena.Value, Convert.ToInt32(Math.Round(nudCenaPoDanuIzmena.Value, 0)));
                //  listaPonuda.Add(p);
                if (File.Exists(ponudeFajl))
                {
                    bf = new BinaryFormatter();
                    fs = new FileStream(ponudeFajl, FileMode.Open, FileAccess.Write, FileShare.ReadWrite);

                    bf.Serialize(fs, listaPonuda);

                    fs.Flush();
                    fs.Dispose();
                    fs.Close();
                    MessageBox.Show("Ponuda je uspesno sacuvana");
                }

            }

            if (flagDatumOd == true)
            {
                MessageBox.Show("Pocetak ponude je promenjen");
            }
            if (flagDatumDo == true)
            {
                MessageBox.Show("Kraj ponude je promenjen");
            }
            if (flagCena == true)
            {
                MessageBox.Show("Cena ponude po danu je promenjena");
            }
            flagDatumOd = false;
            flagDatumDo = false;
            flagCena = false;

            if (File.Exists(ponudeFajl))
            {
                cbPregledPonuda.Items.Clear();
                cbPonudaIzmena.Items.Clear();
                cbPonudaDodavanje.Items.Clear();

                bf = new BinaryFormatter();
                fs = new FileStream(ponudeFajl, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);

                listaPonuda = bf.Deserialize(fs) as List<Ponuda>;

                fs.Flush();
                fs.Dispose();
                fs.Close();
                for (int i = 0; i < listaPonuda.Count; i++)
                {
                    cbPregledPonuda.Items.Add("#" + listaPonuda[i].IdAuta + " po ceni od: " + listaPonuda[i].Cena + "rsd");
                    cbPonudaIzmena.Items.Add("#" + listaPonuda[i].IdAuta + " po ceni od: " + listaPonuda[i].Cena + "rsd");
                    cbPonudaDodavanje.Items.Add("#" + listaPonuda[i].IdAuta + " po ceni od: " + listaPonuda[i].Cena + "rsd");
                }
            }
        }

        private void cbPonudaIzmena_SelectedIndexChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < listaPonuda.Count; i++)
            {
                if (cbPonudaIzmena.SelectedIndex == i)
                {
                    dtpPocetakPonudeIzmena.Value = listaPonuda[i].DatumOd;
                    dtpKrajPonudeIzmena.Value = listaPonuda[i].DatumDo;
                    nudCenaPoDanuIzmena.Value = listaPonuda[i].Cena;

                    txtDostupanOd.Text = listaPonuda[i].DatumOd.ToShortDateString();
                    txtDostupanDo.Text = listaPonuda[i].DatumDo.ToShortDateString();
                    txtPoCeniOd.Text = listaPonuda[i].Cena.ToString();
                }
            }


            for (int i = 0; i < listaPonuda.Count; i++)
            {
                if (cbPonudaIzmena.SelectedIndex == i)
                    for (int j = 0; j < lista.Count; j++)
                    {
                        if (listaPonuda[i].IdAuta == lista[j].IdAuta)
                        {
                            string autoNaPregled;

                            autoNaPregled = Convert.ToString(cbPonudaAuta.Items[j]);
                            txtAutomobil.Text = autoNaPregled;
                            cbPregledPonuda.SelectedIndex = i;
                        }
                    }
            }
        }

        private void cbRezervacijaPregled_SelectedIndexChanged(object sender, EventArgs e)
        {
          for(int i=0; i<listaKupacRezervacija.Count; i++)
                for(int j=0; j<listaKupaca.Count; j++) {
                    for(int k=0; k<lista.Count; k++) {
                        {
                            if (cbRezervacijaPregled.SelectedIndex == i && listaKupaca[j].IDBRadmina == listaKupacRezervacija[i].IdKupca && listaRezervacija[i].IdAuta==lista[k].IdAuta)
                            {
                                txtRezervacijaKupac.Text = listaKupaca[j].ToString();
                                txtRezervacijaDostupanOd.Text = listaKupacRezervacija[i].DatOd.ToShortDateString();
                                txtRezervacijaDostupanDo.Text = listaKupacRezervacija[i].DatDo.ToShortDateString();
                                txtRezervacijaPoCeniOd.Text = listaKupacRezervacija[i].Cena.ToString();
                                txtRezervacijaAutomobil.Text = lista[k].ToString();

                            }
                        }
                    }
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void cbKupacOtkazivanje_SelectedIndexChanged(object sender, EventArgs e)
        {
            lstOtkazivanje.Items.Clear();

            for (int i = 0; i < listaRezervacija.Count; i++)
            {
                for (int j = 0; j < listaKupaca.Count; j++)
                {
                    if (cbKupacOtkazivanje.SelectedIndex == j)
                    {
                        if (listaRezervacija[i].IdKupca==listaKupaca[j].IDBRadmina)
                        {
                            lstOtkazivanje.Items.Add(listaRezervacija[i]);
                            listaKupacRezervacija.Add(listaRezervacija[i]);
                        }
                    }
                }
            }
        }

        private void lstOtkazivanje_SelectedIndexChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < listaKupacRezervacija.Count; i++)
            {
                for (int j = 0; j < lista.Count; j++)
                {
                    if (lstOtkazivanje.SelectedIndex == i)
                    {
                        if (listaKupacRezervacija[i].IdAuta == lista[j].IdAuta)
                        {
                            txtAutomobilOtkazivanje.Text = lista[j].ToString();
                        }
                        txtPocetakPonudeOtkazivanje.Text = listaKupacRezervacija[i].DatOd.ToShortDateString();
                        txtKrajPonudeOtkazivanje.Text = listaKupacRezervacija[i].DatDo.ToShortDateString();
                        txtCenaRezervacijeOtkazivanje.Text = listaKupacRezervacija[i].Cena.ToString();
                    }
                }
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            for (int i = 0; i < listaKupacRezervacija.Count; i++)
            {
                for (int j = 0; j < listaRezervacija.Count; j++)
                {
                    if (lstOtkazivanje.SelectedIndex == i)
                    {
                        if (listaKupacRezervacija[i].IdRezervacije == listaRezervacija[j].IdRezervacije)
                        {
                            listaRezervacija.RemoveAt(j);
                            MessageBox.Show("Uspesno obrisana rezervacija!");
                        }
                    }
                }

            }
            if (File.Exists(rezervacijeFajl))
            {

                cbRezervacijaPregled.Items.Clear();
                bf = new BinaryFormatter();
                fs = new FileStream(rezervacijeFajl, FileMode.Open, FileAccess.Write, FileShare.ReadWrite);

                bf.Serialize(fs, listaRezervacija);

                fs.Flush();
                fs.Dispose();
                fs.Close();
                
            }

            if (File.Exists(rezervacijeFajl))
            {

                cbRezervacijaPregled.Items.Clear();
                bf = new BinaryFormatter();
                fs = new FileStream(rezervacijeFajl, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);

                listaRezervacija = bf.Deserialize(fs) as List<Rezervacija>;

                fs.Flush();
                fs.Dispose();
                fs.Close();
                for (int i = 0; i < listaRezervacija.Count; i++)
                {
                    cbRezervacijaPregled.Items.Add("#" + listaRezervacija[i].IdAuta + " " + listaRezervacija[i].DatOd.ToShortDateString() + " - " + listaRezervacija[i].DatDo.ToShortDateString() + " cena:" + listaRezervacija[i].Cena + "rsd");
                }
            }
            lstOtkazivanje.Items.Clear();

            for (int i = 0; i < listaRezervacija.Count; i++)
            {
                for (int j = 0; j < listaKupaca.Count; j++)
                {
                    if (cbKupacOtkazivanje.SelectedIndex == j)
                    {
                        if (listaRezervacija[i].IdKupca == listaKupaca[j].IDBRadmina)
                        {
                            lstOtkazivanje.Items.Add(listaRezervacija[i]);
                            listaKupacRezervacija.Add(listaRezervacija[i]);
                        }
                    }
                }
            }

        }

        private void btnDodajRezervaciju_Click(object sender, EventArgs e)
        {
            cbRezervacijaPregled.Items.Clear();
            int idKupca=0;
            int idAuta=0;
           /* for(int i=0; i<listaKupaca.Count; i++)
            {
                if (cbKupacDodavanje.SelectedIndex == i)
                {
                    idKupca = listaKupaca[i].IDBRadmina;
                }
            } 
            */
         /*   for(int i=0; i<listaPonuda.Count; i++)
            {
                if (cbPonudaDodavanje.SelectedIndex == i)
                {
                    idAuta = listaPonuda[i].IdAuta;
                }
            }*/

            Rezervacija r = new Rezervacija(listaPonuda[cbPonudaDodavanje.SelectedIndex].IdAuta, listaKupaca[cbKupacDodavanje.SelectedIndex].IDBRadmina, dtpPocetakPonudeDodavanje.Value, dtpKrajPonudeDodavanje.Value, Int32.Parse(txtCenaRezervacijeDodavanje.Text));
            listaRezervacija.Add(r);


            if (File.Exists(rezervacijeFajl))
            {
                bf = new BinaryFormatter();
                fs = new FileStream(rezervacijeFajl, FileMode.Open, FileAccess.Write, FileShare.ReadWrite);

              
                bf.Serialize(fs, listaRezervacija);

                MessageBox.Show("Uspesno snimljena rezervacija");
                fs.Flush();
                fs.Close();
                fs.Dispose();

            }
            else
            {
                bf = new BinaryFormatter();
                fs = new FileStream(rezervacijeFajl, FileMode.Create, FileAccess.Write, FileShare.ReadWrite);
                
                bf.Serialize(fs, listaRezervacija);

                MessageBox.Show("Uspesno snimljena rezervacija");
                fs.Flush();
                fs.Close();
                fs.Dispose();
            }
          
            if (File.Exists(rezervacijeFajl))
            {
                cbRezervacijaPregled.Items.Clear();
                bf = new BinaryFormatter();
                fs = new FileStream(rezervacijeFajl, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);

                listaRezervacija = bf.Deserialize(fs) as List<Rezervacija>;

                fs.Flush();
                fs.Dispose();
                fs.Close();

                foreach (Rezervacija rezervacija in listaRezervacija)
                {
                    listaKupacRezervacija.Add(rezervacija);
                    cbRezervacijaPregled.Items.Add(rezervacija);
                }
            }


        }

        private void cbPonudaDodavanje_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idPonuda=0;
            int idAuta=0;
            for(int i=0; i<listaPonuda.Count; i++)
            {
                if (cbPonudaDodavanje.SelectedIndex == i)
                {
                    idPonuda = listaPonuda[i].IdPonude;
                    idAuta = listaPonuda[i].IdAuta;
                    dtpPocetakPonudeDodavanje.Value = listaPonuda[i].DatumOd;
                    dtpKrajPonudeDodavanje.Value = listaPonuda[i].DatumDo;
                    txtCenaRezervacijeDodavanje.Text = listaPonuda[i].Cena.ToString();
                }
            }
            
            for(int i=0; i<lista.Count; i++)
            {
                if (lista[i].IdAuta == listaPonuda[cbPonudaDodavanje.SelectedIndex].IdAuta)
                {
                    txtAutomobilDodavanje.Text = lista[i].ToString();
                   
                }
            }

            


        }
        public void crtajPitu(object sender, PaintEventArgs e)
        {
            listView1.Items.Clear();
            float ukupno = 0;
            foreach (Stats s in statistika)
            {
                ukupno += s.BrDana;
            }
            float pocetniUgao = -90;
            foreach (Stats s in statistika)
            {
                Color boja = Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256));
                Brush cetka = new SolidBrush(boja);
                float ugao = (s.BrDana / ukupno) * 360;
                e.Graphics.FillPie(cetka, 0, 0, pictureBox1.Width, pictureBox1.Height, pocetniUgao, ugao);
                pocetniUgao += ugao;
                listView1.Items.Add(s + ": " + s.BrDana.ToString() + " dan(a), " + ((s.BrDana / ukupno) * 100).ToString("F") + "%");
                listView1.Items[listView1.Items.Count - 1].BackColor = boja;
            }
        }
        public int brojDana(DateTime d1, DateTime d2)
        {
            return (int)(d2.Date - d1.Date).TotalDays + 1;
        }

        public bool proveraDatuma(DateTime d1, DateTime d2)
        {
            //obrnuta logika
            if (d1.Date > d2.Date) return true;
            else return false;
        }
        private void button2_Click_2(object sender, EventArgs e)
        {
            statistika.Clear();
            if (proveraDatuma(dateTimePicker1.Value.Date, dateTimePicker2.Value.Date))
            {
                MessageBox.Show("Datumi nisu korektno popunjeni!");
                pictureBox1.Invalidate();
                return;
            }
            foreach (Automobil a in lista)
            {
                Stats s = new Stats();
                int brojdanapoautu = 0;
                foreach (Rezervacija r in listaRezervacija)
                {

                    if (r.IdAuta == a.IdAuta)
                    {
                        s.Auto = a.ToString();
                        if (dateTimePicker1.Value.Date <= r.DatOd &&
                         r.DatOd <= dateTimePicker2.Value.Date &&
                         dateTimePicker2.Value.Date >= r.DatOd &&
                         r.DatDo <= dateTimePicker2.Value.Date)
                        {
                            s.DatumOd = r.DatOd;
                            s.DatumDo = r.DatDo;
                        }
                        else if (dateTimePicker1.Value.Date <= r.DatOd &&
                                r.DatOd <= dateTimePicker2.Value.Date &&
                                r.DatDo > dateTimePicker2.Value.Date)
                        {
                            s.DatumOd = r.DatOd;
                            s.DatumDo = dateTimePicker2.Value.Date;
                        }
                        else if (dateTimePicker1.Value.Date <= r.DatDo &&
                                r.DatDo <= dateTimePicker2.Value.Date &&
                                r.DatOd < dateTimePicker1.Value.Date)
                        {
                            s.DatumOd = dateTimePicker1.Value.Date;
                            s.DatumDo = r.DatDo;
                        }

                        else continue;
                        brojdanapoautu += brojDana(s.DatumOd, s.DatumDo);
                    }

                }
                s.BrDana = brojdanapoautu;
                if (brojdanapoautu > 0) statistika.Add(s);
                brojdanapoautu = 0;


            }
            pictureBox1.Paint += crtajPitu;
            if (statistika.Count == 0)
            {
                pictureBox1.Invalidate();
                MessageBox.Show("Nema iznajmljenih vozila u zadatom intervalu!");
                return;
            }
            pictureBox1.Invalidate();
        }

        private void dtpPocetakPonudeIzmena_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            for(int i=0; i<listaPonuda.Count; i++)
            {
                if (cbPonudaIzmena.SelectedIndex == i)
                {
                    listaPonuda.RemoveAt(i);
                }
              
            }
            MessageBox.Show("Uspesno izbrisana ponuda");

            if (File.Exists(ponudeFajl))
            {
                bf = new BinaryFormatter();
                fs = new FileStream(ponudeFajl, FileMode.Open, FileAccess.Write, FileShare.ReadWrite);

                bf.Serialize(fs, listaPonuda);

                fs.Flush();
                fs.Dispose();
                fs.Close();
                MessageBox.Show("Ponuda je uspesno sacuvana");
            }
            if (File.Exists(ponudeFajl))
            {
                cbPregledPonuda.Items.Clear();
                cbPonudaIzmena.Items.Clear();
                cbPonudaDodavanje.Items.Clear();

                bf = new BinaryFormatter();
                fs = new FileStream(ponudeFajl, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);

                listaPonuda = bf.Deserialize(fs) as List<Ponuda>;

                fs.Flush();
                fs.Dispose();
                fs.Close();
                for (int i = 0; i < listaPonuda.Count; i++)
                {
                    cbPregledPonuda.Items.Add("#" + listaPonuda[i].IdAuta + " po ceni od: " + listaPonuda[i].Cena + "rsd");
                    cbPonudaIzmena.Items.Add("#" + listaPonuda[i].IdAuta + " po ceni od: " + listaPonuda[i].Cena + "rsd");
                    cbPonudaDodavanje.Items.Add("#" + listaPonuda[i].IdAuta + " po ceni od: " + listaPonuda[i].Cena + "rsd");
                }
            }
        }

        private void dtpKrajPonudeIzmena_ValueChanged(object sender, EventArgs e)
        {

        }

        private void nudCenaPoDanuIzmena_ValueChanged(object sender, EventArgs e)
        {

        }

        private void cbKupacDodavanje_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
   


    
   


