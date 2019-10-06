using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat_1
{
    [Serializable()]
    public class Automobil:IEnumerable
    {
        static int brojac=1;
        private int idAuta = brojac++;
        private string marka;
        private string model;
        private int godiste;
        private int kubikaza;
        private string pogon;
        private string vrstaMenjaca;
        private string karoserija;
        private string gorivo;
        private int brojVrata;


        public Automobil()
        {
            this.idAuta = idAuta++;
            this.marka = "";
            this.model = "";
            this.godiste = 0;
            this.kubikaza = 0;
            this.vrstaMenjaca = "";
            this.karoserija = "";
            this.gorivo = "";
            this.brojVrata = 0;
        }
        public Automobil(string marka,string model,int godiste,int kubikaza,string pogon,string vrstaMenjaca,string karoserija,string gorivo,int brojVrata)
        {
            this.idAuta = idAuta++;
            this.marka = marka;
            this.model = model;
            this.godiste = godiste;
            this.kubikaza=kubikaza;
            this.pogon = pogon;
            this.vrstaMenjaca = vrstaMenjaca;
            this.karoserija = karoserija;
            this.gorivo = gorivo;
            this.brojVrata = brojVrata;
        }

        public string this[string propertyName]
        {
            get
            {
                switch (propertyName)
                {
                    case "Marka":
                        return marka.ToString();

                    case "Model":
                        return model.ToString();
                    case "IdAuta":
                        return idAuta.ToString();
                    default:
                        return "";
                }
            }
        }

        public int IdAuta
        {
            get
            {
                return this.idAuta;
            }
            set
            {
                this.idAuta = value;
            }
        }
        
        public string Marka
        {
            get
            {
                return this.marka;
            }
            set
            {
                this.marka = value;
            }
        }
        public string Model
        {
            get
            {
                return this.model;
            }
            set
            {
                this.model = value;
            }
        }
        public int Godiste
        {
            get
            {
                return this.godiste;
            }
            set
            {
                this.godiste = value;
            }
        }
        public int Kubikaza
        {
            get
            {
                return this.kubikaza;
            }
            set
            {
                this.kubikaza = value;
            }
        }
        public string VrstaMenjaca
        {
            get
            {
                return this.vrstaMenjaca;
            }
            set
            {
                this.vrstaMenjaca = value;
            }
        }
        public string Karoserija
        {
            get
            {
                return this.karoserija;
            }
            set
            {
                this.karoserija = value;
            }
        }
        public string Pogon
        {
            get
            {
                return this.pogon;
            }
            set
            {
                this.pogon = value;
            }
        }
        public string Gorivo
        {
            get
            {
                return this.gorivo;
            }
            set
            {
                this.gorivo = value;
            }
        }
        public int BrojVrata
        {
            get
            {
                return this.brojVrata;
            }
            set
            {
                this.brojVrata = value;
            }
        }
        public override string ToString()
        {
            return this.marka+" "+this.model+" "+this.godiste+"god "+this.kubikaza+"cm3";
        }

        public IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }
        public string vratiKubikazu()
        {
            return this.Kubikaza.ToString();
        }
    }

}
