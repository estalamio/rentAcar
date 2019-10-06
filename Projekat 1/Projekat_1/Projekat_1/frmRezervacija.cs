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
using System.Reflection;

namespace Projekat_1
{
    public partial class frmRezervacija : Form
    {
        List<Automobil> automobili;
        List<Automobil> lista = new List<Automobil>();
        List<Automobil> listaDostupnihPonuda = new List<Automobil>();
        List<Automobil> noviAutomobili = new List<Automobil>();

        List<Ponuda> ponudeRadna = new List<Ponuda>();

        List<Automobil> autaObrada = new List<Automobil>();

   /*     public delegate void provera(bool f);
        provera zaPonude;*/

        int idKupca = frmLoginKupca.idKupca;
        string imeKupca = frmLoginKupca.imeAdmina;
        string prezimeKupca = frmLoginKupca.prezimeAdmina;
        string vremePristupa = frmLoginKupca.datumPristupa;


        string kupciFajl = "nalozi/kupci.mrso";
        string adminiFajl = "nalozi/admini.mrso";
        string ponudeFajl = "ponude/ponude.mrso";
        string automobiliFajl = "automobili/automobili.mrso";
        string rezervacijeFajl = "rezervacije/sveRezervacije.mrso";
        string statistikeFajl = "statistika/statistika.mrso";


        List<Ponuda> listaPonuda = new List<Ponuda>();
        List<Ponuda> nadjenePonude = new List<Ponuda>();
        List<Rezervacija> listaRezervacija = new List<Rezervacija>();
        Ponuda p;
        FileStream fs;
        BinaryFormatter bf;

        Rezervacija r = new Rezervacija();


        DateTime pocetniDatum;
        DateTime krajniDatum;
        TimeSpan t;
        int brDana;

        public frmRezervacija()
        {
        //    zaPonude += ispisPonuda;
            InitializeComponent();
        }

        private void frmRezervacija_Load(object sender, EventArgs e)
        {

            txtCenaRezervacije.Enabled = false;

            lblImeAdmina.Text = imeKupca;
            lblPrezimeAdmina.Text = prezimeKupca;
            lblVremePristupaAdmina.Text = vremePristupa;
            cbMarka.Items.Clear();



            if (File.Exists(rezervacijeFajl))
            {

                bf = new BinaryFormatter();
                fs = new FileStream(rezervacijeFajl, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);

                if (fs.Length != -1)
                    listaRezervacija = bf.Deserialize(fs) as List<Rezervacija>;

                fs.Flush();
                fs.Dispose();
                fs.Close();

            }

            /*     if (File.Exists(automobiliFajl))
                 {

                     bf = new BinaryFormatter();
                     fs = new FileStream(automobiliFajl, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                     //fs = File.OpenRead(automobiliFajl);
                     lista = bf.Deserialize(fs) as List<Automobil>;
                     // cbMarka.DataSource = lista;
                     /* for (int i = 0; i < lista.Count; i++)
                      {

                          cbMarka.Items.Add(lista[i].Marka);
                      }*/
            /*
           Boolean flagNadjen = false;
           for (int i = 0; i < lista.Count; i++)
           {
               for (int j = i + 1; j < lista.Count; j++)
               {
                   if (lista[i].Marka == lista[j].Marka) { flagNadjen = true; }
               }
               if (flagNadjen == false) { cbMarka.Items.Add(lista[i].Marka); }
               else { flagNadjen = false; }

           }*/
            //  cbModel.DataSource = null;
            //     cbKubikaza.DataSource = null;
            /*     fs.Dispose();
                 fs.Close();*/
            /*
            if (lstMarka.Size.Equals(lista.Count))
            {
                lstMarka.SetSelected(0, false);
                if (lstMarka.SelectedIndex > -1)
                    lstModel.DataSource = (lista[lstMarka.SelectedIndex].Model);
            }
        }*/


            

            Boolean flagMarka = false;
            if (File.Exists(automobiliFajl))
            {

                bf = new BinaryFormatter();
                fs = new FileStream(automobiliFajl, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);

                lista = bf.Deserialize(fs) as List<Automobil>;

                fs.Flush();
                fs.Dispose();
                fs.Close();

                cbMarka.Items.Clear();

            }

            if (File.Exists(ponudeFajl))
            {
                bf = new BinaryFormatter();
                fs = new FileStream(ponudeFajl, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);

                listaPonuda = bf.Deserialize(fs) as List<Ponuda>;

                fs.Flush();
                fs.Dispose();
                fs.Close();
            }

            if (listaPonuda.Count != -1 && lista.Count!=-1)
            {
                foreach (Ponuda p in listaPonuda)
                {
                    foreach (Automobil a in lista)
                    {
                        if (a.IdAuta == p.IdAuta)
                        {
                            listaDostupnihPonuda.Add(a);
                        }
                    }
                }

                for (int i = 0; i < listaDostupnihPonuda.Count; i++)
                {
                    for (int j = i + 1; j < listaDostupnihPonuda.Count; j++)
                    {
                        if (listaDostupnihPonuda[i].Marka == listaDostupnihPonuda[j].Marka)
                        {
                            flagMarka = true;
                        }
                    }
                    if (flagMarka == false)
                    {
                        cbMarka.Items.Add(listaDostupnihPonuda[i].Marka);
                    }
                    else { flagMarka = false; }
                }
            }
            cbMarka.SelectedIndexChanged += Marke;
            cbModel.SelectedIndexChanged += Modeli;
            cbGodiste.SelectedValueChanged += Godiste;

            //  cbGodiste.SelectedIndexChanged += prikazModela;
            //  cbGodiste.SelectedIndexChanged += prikazModela;
            //         cbGodiste.SelectedIndexChanged += prikazGodista;
            //      cbModel.SelectedIndexChanged += PrikazModela;
            cbKubikaza.SelectedIndexChanged += Kubikaza;
            //   cbKubikaza.SelectedIndexChanged += prikazKubikaza;
            cbKaroserija.SelectedIndexChanged += Karoserija;
            cbBrVrata.SelectedIndexChanged += Vrata;
            cbGorivo.SelectedIndexChanged += Gorivo;
            cbPogon.SelectedIndexChanged += Pogon;
            cbMenjac.SelectedIndexChanged += Menjac;
        }

        private void Pogon(object sender,EventArgs e)
        {
            ComboBox cb = sender as ComboBox;
            cb.Enabled = false;
            ukloniSveEnabled();
            for (int i = 0; i < autaObrada.Count; i++)
            {
                if (!cb.SelectedItem.Equals(autaObrada[i].Pogon))
                {
                    autaObrada.RemoveAt(i);
                    i = -1;
                }
            }
            dodajSveEnabled();
            ukloniIsteSve();
            popuni();
        }
        private void Menjac(object sender,EventArgs e)
        {
            ComboBox cb = sender as ComboBox;
            cb.Enabled = false;
            ukloniSveEnabled();
            for (int i = 0; i < autaObrada.Count; i++)
            {
                if (!cb.SelectedItem.Equals(autaObrada[i].VrstaMenjaca))
                {
                    autaObrada.RemoveAt(i);
                    i = -1;
                }
            }
            dodajSveEnabled();
            ukloniIsteSve();
            popuni();
        }
        private void Karoserija(object sender,EventArgs e)
        {
            ComboBox cb = sender as ComboBox;
            cb.Enabled = false;
            ukloniSveEnabled();
            for (int i = 0; i < autaObrada.Count; i++)
            {
                if (!cb.SelectedItem.Equals(autaObrada[i].Karoserija))
                {
                    autaObrada.RemoveAt(i);
                    i = -1;
                }
            }
            dodajSveEnabled();
            ukloniIsteSve();
            popuni();
        }
        private void Gorivo(object sender,EventArgs e)
        {
            ComboBox cb = sender as ComboBox;
            cb.Enabled = false;
            ukloniSveEnabled();
            for (int i = 0; i < autaObrada.Count; i++)
            {
                if (!cb.SelectedItem.Equals(autaObrada[i].Gorivo))
                {
                    autaObrada.RemoveAt(i);
                    i = -1;
                }
            }
            dodajSveEnabled();
            ukloniIsteSve();
            popuni();
        }
      private void Vrata(object sender,EventArgs e)
        {
            ComboBox cb = sender as ComboBox;
            cb.Enabled = false;
            ukloniSveEnabled();
            for (int i = 0; i < autaObrada.Count; i++)
            {
                if (!cb.SelectedItem.Equals(autaObrada[i].BrojVrata))
                {
                    autaObrada.RemoveAt(i);
                    i = -1;
                }
            }
            dodajSveEnabled();
            ukloniIsteSve();
            popuni();
        }
        private void Kubikaza(object sender,EventArgs e)
        {
            cbKubikaza.Enabled = false;
            ukloniSveEnabled();
            for (int i = 0; i < autaObrada.Count; i++)
            {
                if (!cbKubikaza.SelectedItem.Equals(autaObrada[i].Kubikaza))
                {
                    autaObrada.RemoveAt(i);
                    i = -1;
                }
            }
            dodajSveEnabled();
            ukloniIsteSve();
            popuni();
        }
      /*  private void ispisPonuda(bool f)
        {
            lstNarudzbine.Items.Clear();
            ponudeRadna.Clear();
            foreach (Ponuda p in listaPonuda)
            {
                if (autaObrada[0].IdAuta == p.IdAuta && f)
                {
                    ponudeRadna.Add(p);
                    lstNarudzbine.Items.Add(p.IspisPonude());
                }
            }
        }*/
        private void ukloniEnabled(ComboBox cb)
        {
            if (cb.Enabled)
            {
                cb.Items.Clear();
            }

        }
        private void ukloniSveEnabled()
        {
            ukloniEnabled(cbModel);
            ukloniEnabled(cbGodiste);
            ukloniEnabled(cbKubikaza);
            ukloniEnabled(cbGorivo);
            ukloniEnabled(cbPogon);
            ukloniEnabled(cbKaroserija);
            ukloniEnabled(cbGodiste);
            ukloniEnabled(cbMenjac);
            ukloniEnabled(cbBrVrata);
        }
        private void Godiste(object sender, EventArgs e)
        {
            cbGodiste.Enabled = false;
            ukloniSveEnabled();
            for (int i = 0; i < autaObrada.Count; i++)
            {
                if (!cbGodiste.SelectedItem.Equals(autaObrada[i].Godiste))
                {
                    autaObrada.RemoveAt(i);
                    i = -1;
                }
            }
            dodajSveEnabled();
            ukloniIsteSve();
            popuni();
        }
        private void dodajEnabled(ComboBox cb, int add)
        {
            if (cb.Enabled)
            {

                cb.Items.Add(add);

            }

        }
        private void dodajEnabled(ComboBox cb, string add)
        {
            if (cb.Enabled)
            {

                cb.Items.Add(add);

            }

        }
        private void dodajSveEnabled()
        {
            for (int i = 0; i < autaObrada.Count; i++)
            {
                dodajEnabled(cbModel, autaObrada[i].Model);
                dodajEnabled(cbGodiste, autaObrada[i].Godiste);
                dodajEnabled(cbKubikaza, autaObrada[i].Kubikaza);
                dodajEnabled(cbGorivo, autaObrada[i].Gorivo);
                dodajEnabled(cbPogon, autaObrada[i].Pogon);
                dodajEnabled(cbKaroserija, autaObrada[i].Karoserija);
                dodajEnabled(cbMenjac, autaObrada[i].VrstaMenjaca);
                dodajEnabled(cbBrVrata, autaObrada[i].BrojVrata);
            }
        }
        private void ukloniIste(ComboBox cb)
        {
            if (cb.Enabled)
            {
                for(int i=0; i<cb.Items.Count; i++)
                {
                    for(int j=0; j<cb.Items.Count; j++)
                    {
                        if(j!=i && cb.Items[i].ToString() == cb.Items[j].ToString())
                        {
                            cb.Items.RemoveAt(i);
                            i = -1;
                            break;
                        }
                    }
                }
            }
        }
        private void ukloniIsteSve()
        {
            ukloniIste(cbModel);
            ukloniIste(cbGodiste);
            ukloniIste(cbKubikaza);
            ukloniIste(cbKaroserija);
            ukloniIste(cbGorivo);
            ukloniIste(cbPogon);
            ukloniIste(cbMenjac);
            ukloniIste(cbBrVrata);
        }
        private void popuni()
        {
            bool flag = false;
            for(int i=0; i<Controls.Count; i++)
            {
                if(Controls[i] is ComboBox && Controls[i] != cbMarka)
                {
                    if(((ComboBox)Controls[i]).Enabled && ((ComboBox)Controls[i]).Items.Count == 1){
                        ((ComboBox)Controls[i]).SelectedIndex = 0;
                    }
                }
            }

            int popunjeno = 0;
          /*  for (int i = 0; i < Controls.Count; i++)
            {
                if (Controls[i] is ComboBox)
                {
                    if (((ComboBox)Controls[i]).SelectedIndex > -1)
                    {
                        popunjeno++;
                    }
                }
            }
            if (popunjeno == 9)
            {
                flag = true;
                zaPonude(flag);
                flag = false;
            }*/
        }
        private void ocistiPolja()
        {
            cbModel.Items.Clear();
            cbGodiste.Items.Clear();
            cbKubikaza.Items.Clear();
            cbKaroserija.Items.Clear();
            cbGorivo.Items.Clear();
            cbPogon.Items.Clear();
            cbMenjac.Items.Clear();
            cbBrVrata.Items.Clear();
        }
        private void Marke(object sender,EventArgs e)
        {
            ocistiPolja();
            autaObrada.Clear();
            foreach (Automobil a in lista)
            {
                if (a.Marka.Equals(cbMarka.SelectedItem))
                {
                    autaObrada.Add(a);
                }
            }
            dodajSveEnabled();
            ukloniIsteSve();
            popuni();

        }
        private void Modeli(object sender,EventArgs e)
        {
            for (int i = 0; i < autaObrada.Count; i++)
            {
                if (!cbModel.SelectedItem.Equals(autaObrada[i].Model))
                {
                    autaObrada.RemoveAt(i);
                    i = -1;
                }
            }
            //dodajSveEnabled();
            ukloniIsteSve();
            popuni();
        }

        private void prikazOstalih(object sender, EventArgs e)
        {
            object m = cbMarka.SelectedItem;
            string marka = m as string;

            Boolean flagGodiste = false;
            Boolean flagKubikaza = false;
            Boolean flagKaroserija = false;
            Boolean flagBrojVrata = false;
            Boolean flagGorivo = false;
            Boolean flagPogon = false;
            Boolean flagMenjac = false;
            Boolean flagModel = false;

            cbModel.Items.Clear();
            cbGodiste.Items.Clear();
            cbKubikaza.Items.Clear();
            cbKaroserija.Items.Clear();
            cbBrVrata.Items.Clear();
            cbGorivo.Items.Clear();
            cbPogon.Items.Clear();
            cbMenjac.Items.Clear();
            for (int i = 0; i < listaDostupnihPonuda.Count; i++)
            {
                if (listaDostupnihPonuda[i].Marka == marka)
                {
                    for (int j = i + 1; j < listaDostupnihPonuda.Count; j++)
                    {
                        if (listaDostupnihPonuda[i].Marka == listaDostupnihPonuda[j].Marka)
                        {
                            if (listaDostupnihPonuda[i].Model == listaDostupnihPonuda[j].Model) { flagModel = true; }
                            if (listaDostupnihPonuda[i].Godiste == listaDostupnihPonuda[j].Godiste) { flagGodiste = true; }
                            if (listaDostupnihPonuda[i].Kubikaza == listaDostupnihPonuda[j].Kubikaza) { flagKubikaza = true; }
                            if (listaDostupnihPonuda[i].Karoserija == listaDostupnihPonuda[j].Karoserija) { flagKaroserija = true; }
                            if (listaDostupnihPonuda[i].BrojVrata == listaDostupnihPonuda[j].BrojVrata) { flagBrojVrata = true; }
                            if (listaDostupnihPonuda[i].Gorivo == listaDostupnihPonuda[j].Gorivo) { flagGorivo = true; }
                            if (listaDostupnihPonuda[i].Pogon == listaDostupnihPonuda[j].Pogon) { flagPogon = true; }
                            if (listaDostupnihPonuda[i].VrstaMenjaca == listaDostupnihPonuda[j].VrstaMenjaca) { flagMenjac = true; }
                        }
                    }
                    if (flagModel == false) { cbModel.Items.Add(listaDostupnihPonuda[i].Model); }
                    if (flagGodiste == false) { cbGodiste.Items.Add(listaDostupnihPonuda[i].Godiste); }
                    if (flagKubikaza == false) { cbKubikaza.Items.Add(listaDostupnihPonuda[i].Kubikaza); }
                    if (flagKaroserija == false) { cbKaroserija.Items.Add(listaDostupnihPonuda[i].Karoserija); }
                    if (flagBrojVrata == false) { cbBrVrata.Items.Add(listaDostupnihPonuda[i].BrojVrata); }
                    if (flagGorivo == false) { cbGorivo.Items.Add(listaDostupnihPonuda[i].Gorivo); }
                    if (flagPogon == false) { cbPogon.Items.Add(listaDostupnihPonuda[i].Pogon); }
                    if (flagMenjac == false) { cbMenjac.Items.Add(listaDostupnihPonuda[i].VrstaMenjaca); }
                    flagModel = flagGodiste = flagKubikaza = flagKaroserija = flagBrojVrata = flagGorivo = flagPogon = flagMenjac = false;
                }
            }
        }
        public void PrikazModela(object sender, EventArgs e)
        {
            Boolean uslov = true;
            object m = cbMarka.SelectedItem;
            string marka = m as string;

            object mo = cbModel.SelectedItem;
            string model = mo as string;

            int modelIndex = cbModel.SelectedIndex;

            Boolean flagBrVrata = false;
            Boolean flagGodiste = false;
            Boolean flagKubikaza = false;
            Boolean flagKaroserija = false;
            Boolean flagGorivo = false;
            Boolean flagPogon = false;
            Boolean flagMenjac = false;

            cbGodiste.Items.Clear();
            cbKubikaza.Items.Clear();
            cbKaroserija.Items.Clear();
            cbBrVrata.Items.Clear();
            cbGorivo.Items.Clear();
            cbPogon.Items.Clear();
            cbMenjac.Items.Clear();



            for (int i = 0; i < listaDostupnihPonuda.Count; i++)
            {

                if (listaDostupnihPonuda[i].Marka == marka && listaDostupnihPonuda[i].Model.Equals(model))
                {
                    for (int j = i + 1; j < listaDostupnihPonuda.Count; j++)
                    {
                        /*   if (lista[i].Model == lista[j].Model && lista[i].Marka == lista[j].Marka)
                           {
                               flagNadjen = true;
                           }*/
                        if (listaDostupnihPonuda[i].Model == listaDostupnihPonuda[j].Model)
                        {
                            if (listaDostupnihPonuda[i].Godiste == listaDostupnihPonuda[j].Godiste)
                            {


                                flagGodiste = true;
                            }
                            else
                            {
                                flagGodiste = false;

                            }
                            //if (lista[i].Kubikaza == lista[j].Kubikaza) { flagKubikaza = true; }
                            // if (lista[i].Karoserija == lista[j].Karoserija) { flagKaroserija = true; }
                            //  if (lista[i].BrojVrata == lista[j].BrojVrata) { flagBrVrata = true; }
                            //  if (lista[i].Gorivo == lista[j].Gorivo) { flagGorivo = true; }
                            //  if (lista[i].Pogon == lista[j].Pogon) { flagPogon = true; }
                            //  if (lista[i].VrstaMenjaca == lista[j].VrstaMenjaca) { flagMenjac = true; }
                        }
                    }
                    if (flagGodiste == false)
                    {
                        cbGodiste.Items.Add(listaDostupnihPonuda[i].Godiste);
                    }



                    /*   if (flagKubikaza == false) {
                          // cbKubikaza.Items.Clear();
                           cbKubikaza.Items.Add(lista[i].Kubikaza);

                       }
                       if (flagKaroserija == false) {
                         //  cbKaroserija.Items.Clear();
                           cbKaroserija.Items.Add(lista[i].Karoserija);

                       }
                       if (flagBrVrata == false) {
                          // cbBrVrata.Items.Clear();
                           cbBrVrata.Items.Add(lista[i].BrojVrata);

                       }

                       if (flagGorivo == false) {
                         //  cbGorivo.Items.Clear();
                           cbGorivo.Items.Add(lista[i].Gorivo);

                       }
                       if (flagPogon == false) {
                          // cbPogon.Items.Clear();
                           cbPogon.Items.Add(lista[i].Pogon);

                       }
                       if (flagMenjac == false) {
                          // cbMenjac.Items.Clear();
                           cbMenjac.Items.Add(lista[i].VrstaMenjaca);

                       }
                       */
                }



            }
            cbModel.Enabled = false;


            flagGodiste = flagKubikaza = flagKaroserija = flagBrVrata = flagGorivo = flagPogon = flagMenjac = false;
        }
        public void prikazKubikaza(object sender, EventArgs e)
        {
            Boolean flagGodiste = false;
            Boolean flagKubikaza = false;
            Boolean flagKaroserija = false;
            Boolean flagBrojVrata = false;
            Boolean flagGorivo = false;
            Boolean flagPogon = false;
            Boolean flagMenjac = false;

            object k = cbKubikaza.SelectedItem;
            int kubikaza = Convert.ToInt32(k);
            object m = cbMarka.SelectedItem;
            string marka = m as string;

            for (int i = 0; i < listaDostupnihPonuda.Count; i++)
            {
                if (listaDostupnihPonuda[i].Marka == marka && listaDostupnihPonuda[i].Kubikaza.Equals(kubikaza))
                {
                    for (int j = i + 1; j < listaDostupnihPonuda.Count; j++)
                    {
                        if (listaDostupnihPonuda[i].Model == listaDostupnihPonuda[j].Model)
                        {
                            if (listaDostupnihPonuda[i].Karoserija == listaDostupnihPonuda[j].Karoserija) { flagKaroserija = true; }

                        }

                    }
                    if (flagKaroserija == false)
                    {
                        cbKaroserija.Items.Clear();
                        cbKaroserija.Items.Add(listaDostupnihPonuda[i].Karoserija.ToString());
                    }
                }
            }
            cbKubikaza.Enabled = false;
            flagKaroserija = false;
        }
        public void prikazMenjac(object sender, EventArgs e)
        {

            /*   Boolean flagGodiste = false;
               Boolean flagKubikaza = false;
               Boolean flagKaroserija = false;
               Boolean flagBrojVrata = false;
               Boolean flagGorivo = false;
               Boolean flagPogon = false;
               Boolean flagMenjac = false;

               object me = cbMenjac.SelectedItem;
               string menjac = me as string;

               object m = cbMarka.SelectedItem;
               string marka = m as string;

               for (int i = 0; i < lista.Count; i++)
               {
                   if (lista[i].Marka == marka && lista[i].VrstaMenjaca.Equals(menjac))
                   {
                       for (int j = i + 1; j < lista.Count; j++)
                       {
                           if (lista[i].Marka == lista[j].Marka)
                           {
                               if (lista[i].VrstaMenjaca == lista[j].VrstaMenjaca)
                               {
                                   flagMenjac = true;
                               }
                           }

                       }
                       if (flagMenjac == false)
                       {
                           cbKubikaza.Items.Clear();
                           cbKubikaza.Items.Add(lista[i].Kubikaza.ToString());
                       }
                   }
               }
               flagMenjac = false;*/
            cbMenjac.Enabled = false;
        }
        public void prikazGodista(object sender, EventArgs e)
        {
            Boolean flagGodiste = false;
            Boolean flagKubikaza = false;
            Boolean flagKaroserija = false;
            Boolean flagBrojVrata = false;
            Boolean flagGorivo = false;
            Boolean flagPogon = false;
            Boolean flagMenjac = false;
            Boolean flagModel = false;

            object g = cbGodiste.SelectedItem;
            int godiste = Convert.ToInt32(g);
            object m = cbMarka.SelectedItem;
            string marka = m as string;
            object mo = cbModel.SelectedItem;
            string model = mo as string;

            cbModel.Items.Clear();
            cbKubikaza.Items.Clear();
            cbKaroserija.Items.Clear();
            cbBrVrata.Items.Clear();
            cbGorivo.Items.Clear();
            cbPogon.Items.Clear();
            cbMenjac.Items.Clear();


            for (int i = 0; i < listaDostupnihPonuda.Count; i++)
            {
                if (listaDostupnihPonuda[i].Marka == marka && listaDostupnihPonuda[i].Godiste.Equals(godiste))
                {
                    for (int j = i + 1; j < listaDostupnihPonuda.Count; j++)
                    {
                        if (listaDostupnihPonuda[i].Godiste == listaDostupnihPonuda[j].Godiste)
                        {
                            // if (lista[i].Model == lista[j].Model) {flagModel = true;}
                            if (listaDostupnihPonuda[i].Kubikaza == listaDostupnihPonuda[j].Kubikaza) { flagKubikaza = true; }
                            // if (lista[i].Karoserija == lista[j].Karoserija) { flagKaroserija = true; }
                            // if (lista[i].BrojVrata == lista[j].BrojVrata) { flagBrojVrata = true; }
                            // if (lista[i].Gorivo == lista[j].Gorivo) { flagGorivo = true; }
                            //  if (lista[i].Pogon == lista[j].Pogon) { flagPogon = true; }
                            //if (lista[i].VrstaMenjaca == lista[j].VrstaMenjaca) { flagMenjac = true; }

                        }

                    }
                    //     if (flagModel == false) { cbModel.Items.Add(lista[i].Model); }
                    if (flagKubikaza == false) { cbKubikaza.Items.Add(listaDostupnihPonuda[i].Kubikaza.ToString()); }
                    /*  if (flagKaroserija == false) { cbKaroserija.Items.Add(lista[i].Karoserija); }
                      if (flagBrojVrata == false) { cbBrVrata.Items.Add(lista[i].BrojVrata); }
                      if (flagGorivo == false) { cbGorivo.Items.Add(lista[i].Gorivo); }
                      if (flagPogon == false) { cbPogon.Items.Add(lista[i].Pogon); }
                      if (flagMenjac == false) { cbMenjac.Items.Add(lista[i].VrstaMenjaca); }*/

                }
            }
            cbGodiste.Enabled = false;
            flagModel = flagKubikaza = flagKaroserija = flagBrojVrata = flagGorivo = flagPogon = flagMenjac = false;
        }

        public void prikazVrata(object sender, EventArgs e)
        {
            Boolean flagGodiste = false;
            Boolean flagKubikaza = false;
            Boolean flagKaroserija = false;
            Boolean flagBrojVrata = false;
            Boolean flagGorivo = false;
            Boolean flagPogon = false;
            Boolean flagMenjac = false;

            object v = cbBrVrata.SelectedItem;
            int vrata = Convert.ToInt32(v);
            object k = cbKaroserija.SelectedItem;
            string karoserija = k as string;

            for (int i = 0; i < listaDostupnihPonuda.Count; i++)
            {
                if (listaDostupnihPonuda[i].Karoserija == karoserija && listaDostupnihPonuda[i].BrojVrata.Equals(vrata))
                {
                    for (int j = i + 1; j < listaDostupnihPonuda.Count; j++)
                    {
                        if (listaDostupnihPonuda[i].Model == listaDostupnihPonuda[j].Model)
                        {
                            if (listaDostupnihPonuda[i].BrojVrata == listaDostupnihPonuda[j].BrojVrata)
                            {
                                flagGorivo = true;
                            }
                        }

                    }
                    if (flagGorivo == false)
                    {
                        cbGorivo.Items.Clear();
                        cbGorivo.Items.Add(listaDostupnihPonuda[i].Gorivo.ToString());
                    }
                }
            }
            cbBrVrata.Enabled = false;
            flagBrojVrata = false;
        }

        public void prikazGoriva(object sender, EventArgs e)
        {
            Boolean flagGodiste = false;
            Boolean flagKubikaza = false;
            Boolean flagKaroserija = false;
            Boolean flagBrojVrata = false;
            Boolean flagGorivo = false;
            Boolean flagPogon = false;
            Boolean flagMenjac = false;

            object g = cbGorivo.SelectedItem;
            string gorivo = g as string;
            object v = cbBrVrata.SelectedItem;
            int vrata = Convert.ToInt32(v);

            for (int i = 0; i < listaDostupnihPonuda.Count; i++)
            {
                if (listaDostupnihPonuda[i].BrojVrata == vrata && listaDostupnihPonuda[i].Gorivo.Equals(gorivo))
                {
                    for (int j = i + 1; j < listaDostupnihPonuda.Count; j++)
                    {
                        if (listaDostupnihPonuda[i].Gorivo == listaDostupnihPonuda[j].Gorivo)
                        {
                            if (listaDostupnihPonuda[i].Pogon == listaDostupnihPonuda[j].Pogon)
                            {
                                flagPogon = true;
                            }
                        }

                    }
                    if (flagPogon == false)
                    {
                        cbPogon.Items.Clear();
                        cbPogon.Items.Add(listaDostupnihPonuda[i].Pogon.ToString());
                    }
                }
            }
            cbGorivo.Enabled = false;
            flagPogon = false;
        }

        public void prikazKaroserija(object sender, EventArgs e)
        {
            Boolean flagGodiste = false;
            Boolean flagKubikaza = false;
            Boolean flagKaroserija = false;
            Boolean flagBrojVrata = false;
            Boolean flagGorivo = false;
            Boolean flagPogon = false;
            Boolean flagMenjac = false;

            object k = cbKaroserija.SelectedItem;
            string karoserija = k as string;
            object ku = cbKubikaza.SelectedItem;
            int kubikaza = Convert.ToInt32(ku);

            for (int i = 0; i < listaDostupnihPonuda.Count; i++)
            {
                if (listaDostupnihPonuda[i].Kubikaza == kubikaza && listaDostupnihPonuda[i].Karoserija.Equals(karoserija))
                {
                    for (int j = i + 1; j < listaDostupnihPonuda.Count; j++)
                    {
                        if (listaDostupnihPonuda[i].Model == listaDostupnihPonuda[j].Model)
                        {
                            if (listaDostupnihPonuda[i].BrojVrata == listaDostupnihPonuda[j].BrojVrata)
                            {
                                flagBrojVrata = true;
                            }
                        }

                    }
                    if (flagBrojVrata == false)
                    {
                        cbBrVrata.Items.Clear();
                        cbBrVrata.Items.Add(listaDostupnihPonuda[i].BrojVrata.ToString());
                    }
                }
            }
            cbKaroserija.Enabled = false;
            flagBrojVrata = false;
        }

        public void prikazPogona(object sender, EventArgs e)
        {
            Boolean flagGodiste = false;
            Boolean flagKubikaza = false;
            Boolean flagKaroserija = false;
            Boolean flagBrojVrata = false;
            Boolean flagGorivo = false;
            Boolean flagPogon = false;
            Boolean flagMenjac = false;

            object p = cbPogon.SelectedItem;
            string pogon = p as string;
            object g = cbGorivo.SelectedItem;
            string gorivo = g as string;

            for (int i = 0; i < listaDostupnihPonuda.Count; i++)
            {
                if (listaDostupnihPonuda[i].Gorivo == gorivo && listaDostupnihPonuda[i].Pogon.Equals(pogon))
                {
                    for (int j = i + 1; j < listaDostupnihPonuda.Count; j++)
                    {
                        if (listaDostupnihPonuda[i].Pogon == listaDostupnihPonuda[j].Pogon)
                        {
                            if (listaDostupnihPonuda[i].VrstaMenjaca == listaDostupnihPonuda[j].VrstaMenjaca)
                            {
                                flagMenjac = true;
                            }
                        }

                    }
                    if (flagMenjac == false)
                    {
                        cbMenjac.Items.Clear();
                        cbMenjac.Items.Add(listaDostupnihPonuda[i].VrstaMenjaca.ToString());
                    }
                }
            }
            cbPogon.Enabled = false;
            flagMenjac = false;
        }

        private void cbMarka_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbModel.Enabled = true;
            cbGodiste.Enabled = true;
            cbKubikaza.Enabled = true;
            cbKaroserija.Enabled = true;
            cbBrVrata.Enabled = true;
            cbGorivo.Enabled = true;
            cbPogon.Enabled = true;
            cbMenjac.Enabled = true;


        }

        private void cbModel_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnPrikaziTermine_Click(object sender, EventArgs e)
        {
            lstNarudzbine.Items.Clear();
            
            object mar = cbMarka.SelectedItem,
               mod = cbModel.SelectedItem,
                god = cbGodiste.SelectedItem,
                kub = cbKubikaza.SelectedItem,
                kar = cbKaroserija.SelectedItem,
                brV = cbBrVrata.SelectedItem,
                gor = cbGorivo.SelectedItem,
                pog = cbPogon.SelectedItem,
                men = cbMenjac.SelectedItem;

            string marka = mar as string;
            string model = mod as string;
            int godiste = Convert.ToInt32(god);
            int kubikaza = Convert.ToInt32(kub);
            string karoserija = kar as string;
            int brVrata = Convert.ToInt32(brV);
            string gorivo = gor as string;
            string pogon = pog as string;
            string menjac = men as string;
            if (cbMarka.SelectedItem==null || cbModel.SelectedItem==null || cbGodiste.SelectedItem==null || cbKubikaza.SelectedItem==null || cbKaroserija.SelectedItem==null || cbBrVrata.SelectedItem==null || cbGorivo.SelectedItem==null || cbPogon.SelectedItem==null || cbMenjac.SelectedItem==null)
            {
                MessageBox.Show("Odaberite ostale atribute!");
            }
            else
            {
                Automobil autic = new Automobil(marka, model, godiste, kubikaza, pogon, menjac, karoserija, gorivo, brVrata);
                List<Automobil> listaIzabranih = new List<Automobil>();
                listaIzabranih.Add(autic);

                foreach (Automobil bazniAuto in listaDostupnihPonuda)
                {
                    foreach (Ponuda ponuda in listaPonuda)
                    {
                        if (autic.Marka.Equals(bazniAuto.Marka)
                        && autic.Model.Equals(bazniAuto.Model)
                        && autic.Godiste.Equals(bazniAuto.Godiste)
                        && autic.Kubikaza.Equals(bazniAuto.Kubikaza)
                        && autic.Pogon.Equals(bazniAuto.Pogon)
                        && autic.VrstaMenjaca.Equals(bazniAuto.VrstaMenjaca)
                        && autic.Karoserija.Equals(bazniAuto.Karoserija)
                        && autic.Gorivo.Equals(bazniAuto.Gorivo)
                        && autic.BrojVrata.Equals(bazniAuto.BrojVrata))
                        {
                            /*MessageBox.Show(bazniAuto.IdAuta.ToString());*/

                            if (ponuda.IdAuta.Equals(bazniAuto.IdAuta))
                            {
                                nadjenePonude.Add(ponuda);
                            }
                        }

                    }

                }
                foreach (Ponuda ponuda in nadjenePonude)
                {
                    lstNarudzbine.Items.Add(ponuda.DatumOd.ToShortDateString() + " - " + ponuda.DatumDo.ToShortDateString() + " Cena: " + ponuda.Cena + " din" + " po danu");
                }
                listaIzabranih.Clear();
            }
        }
        private void lstNarudzbine_SelectedIndexChanged(object sender, EventArgs e)
        {
          
            dtpDatumPreuzimanja.Value = nadjenePonude[lstNarudzbine.SelectedIndex].DatumOd;
            dtpDatumVracanja.Value = nadjenePonude[lstNarudzbine.SelectedIndex].DatumDo;

            pocetniDatum = dtpDatumPreuzimanja.Value;
            krajniDatum = dtpDatumVracanja.Value;
            t = krajniDatum - pocetniDatum;
            brDana = t.Days;

            int cena = brDana * nadjenePonude[lstNarudzbine.SelectedIndex].Cena;
            txtCenaRezervacije.Text = cena.ToString();
        
            
        }
        private void btnRezervisi_Click(object sender, EventArgs e)
        {
            

            
            if (dtpDatumVracanja.Value > nadjenePonude[lstNarudzbine.SelectedIndex].DatumDo)
            {
                MessageBox.Show("Datum vracanja ne sme da bude veci od nase ponude!");
            }
            if (dtpDatumPreuzimanja.Value < nadjenePonude[lstNarudzbine.SelectedIndex].DatumOd){
                MessageBox.Show("Datum preuzimanja ne sme da bude raniji od nase ponude!");
            }
            int krajnjaCena = brDana * nadjenePonude[lstNarudzbine.SelectedIndex].Cena;
            r = new Rezervacija(nadjenePonude[lstNarudzbine.SelectedIndex].IdAuta, idKupca, dtpDatumPreuzimanja.Value, dtpDatumVracanja.Value,krajnjaCena);





        

            if (File.Exists(rezervacijeFajl))
            {
                bf = new BinaryFormatter();
                fs = new FileStream(rezervacijeFajl, FileMode.Open, FileAccess.Write, FileShare.ReadWrite);

                listaRezervacija.Add(r);
                bf.Serialize(fs,listaRezervacija);

                MessageBox.Show("Uspesno snimljena rezervacija");
                fs.Flush();
                fs.Close();
                fs.Dispose();

                Form rezervisanaAuta = new frmRezervisanaAuta();
                rezervisanaAuta.Show();
            }
            else
            {
                bf = new BinaryFormatter();
                fs = new FileStream(rezervacijeFajl, FileMode.Create, FileAccess.Write, FileShare.ReadWrite);

                listaRezervacija.Add(r);
                bf.Serialize(fs, listaRezervacija);

                MessageBox.Show("Uspesno snimljena rezervacija");
                fs.Flush();
                fs.Close();
                fs.Dispose();

                Form rezervisanaAuta= new frmRezervisanaAuta();
                rezervisanaAuta.Show();
            }
            nadjenePonude.Clear();

        }
        private void dtpDatumPreuzimanja_ValueChanged(object sender, EventArgs e)
        {
            if (dtpDatumPreuzimanja.Value < nadjenePonude[lstNarudzbine.SelectedIndex].DatumOd)
            {
                MessageBox.Show("Datum preuzimanja ne sme da bude manji od nase ponude!");
            }
            else
            {
                pocetniDatum = dtpDatumPreuzimanja.Value;
                krajniDatum = dtpDatumVracanja.Value;
                t = krajniDatum - pocetniDatum;
                brDana = t.Days;
                int cena = brDana * nadjenePonude[lstNarudzbine.SelectedIndex].Cena;
                txtCenaRezervacije.Text = cena.ToString();
            }
        }
        private void dtpDatumVracanja_ValueChanged(object sender, EventArgs e)
        {
            if (dtpDatumVracanja.Value > nadjenePonude[lstNarudzbine.SelectedIndex].DatumDo)
            {
                MessageBox.Show("Datum vracanja ne sme da bude veci od nase ponude!");
            }
            pocetniDatum = dtpDatumPreuzimanja.Value;
            krajniDatum = dtpDatumVracanja.Value;
            t = krajniDatum - pocetniDatum;
            brDana = t.Days;

            int cena= brDana * nadjenePonude[lstNarudzbine.SelectedIndex].Cena;
                txtCenaRezervacije.Text = cena.ToString();
            
        }
        public List<Automobil> PretragaAutomobila(Automobil automobil)
        { 
            PropertyInfo[] properties = listaDostupnihPonuda.GetType().GetProperties();
            List<Automobil> nadjeniAutomobili = new List<Automobil>();
            foreach (Automobil auto in listaDostupnihPonuda)
            {
                int count1 = 0;
                int count2 = 0;
                int countProp = 0;

                foreach (PropertyInfo property in properties)
                {
                    if (countProp < (properties.Count() - 1))
                    {
                        if (property.GetValue(automobil, null) != null)
                        {
                            string propAuto = property.GetValue(automobil, null).ToString();
                            if (propAuto != "" && propAuto != "0")
                            {
                                string name = property.Name;
                                string prop = property.GetValue(auto, null).ToString();
                                if (prop.Equals(automobil[name]))
                                {
                                    count1++;
                                }
                                count2++;
                            }
                        }
                    }
                    countProp++;
                }
                if (count1 == count2)
                {
                    nadjeniAutomobili.Add(auto);
                }
            }
            return nadjeniAutomobili;
        }
    }
}
