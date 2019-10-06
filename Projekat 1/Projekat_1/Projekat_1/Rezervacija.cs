using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat_1
{
    [Serializable]
    public class Rezervacija
    {
        private int idAuta;
        private int idKupca;
        private DateTime datOd = new DateTime();
        private DateTime datDo = new DateTime();
        private int cena;

        static int brojac = 1;
        private int idRezervacije = brojac++;
        public Rezervacija()
        {
            this.idRezervacije = idRezervacije++;
            this.idAuta = 0;
            this.idKupca = 0;
            this.datOd = new DateTime();
            this.datDo = new DateTime();
            this.cena = 0;
        }
        public Rezervacija(int idAuta,int idKupca,DateTime datOd,DateTime datDo,int cena)
        {
            this.idRezervacije=idRezervacije++;
            this.idAuta = idAuta;
            this.idKupca = idKupca;
            this.datOd = datOd;
            this.datDo = datDo;
            this.cena = cena;
        }
        public int IdRezervacije
        {
            get
            {
                return this.idRezervacije;
            }
            set
            {
                this.idRezervacije = value;
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
        public int IdKupca
        {
            get
            {
                return this.idKupca;
            }
            set
            {
                this.idKupca = value;
            }
        }
        public DateTime DatOd
        {
            get
            {
                return this.datOd;
            }
            set
            {
                this.datOd = value;
            }
        }
        public DateTime DatDo
        {
            get
            {
                return this.datDo;
            }
            set
            {
                this.datDo = value;
            }
        }
        public int Cena
        {
            get
            {
                return this.cena;
            }
            set
            {
                this.cena = cena;
            }
        }

        public override string ToString()
        {
            return DatOd.ToShortDateString() + " - " + DatDo.ToShortDateString() + " cena:" +Cena+"rsd";
        }


    }
}
