using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat_1
{
    [Serializable()]
    public class Ponuda
    {
        private int idAuta;
        private DateTime datumOd = new DateTime();
        private DateTime datumDo = new DateTime();
        private int cena;
        static int brojac = 1;
        private int idPonude = brojac++;


        public Ponuda()
        {
            this.idPonude = idPonude++;
            this.idAuta = 0;
            this.datumOd = new DateTime();
            this.datumDo = new DateTime();
            this.cena = 0;
        }

        public Ponuda(int idAuta,DateTime datumOd,DateTime datumDo,int cena)
        {
            this.idPonude = idPonude++;
            this.idAuta = idAuta;
            this.datumOd = datumOd;
            this.datumDo = datumDo;
            this.cena = cena;
        }

        public int IdPonude
        {
            get
            {
                return this.idPonude;
            }
            set
            {
                this.idPonude = value;
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
        public DateTime DatumOd
        {
            get
            {
                return this.datumOd;
            }
            set
            {
                this.datumOd = value;
            }
        }
        public DateTime DatumDo
        {
            get
            {
                return this.datumDo;
            }
            set
            {
                this.datumDo = value;
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
                this.cena = value;
            }
        }
        public string IspisPonude()
        {
            return datumOd.ToShortDateString() + " - " + datumDo.ToShortDateString() + "  Cena: " + cena.ToString() + " din po danu";
        }
    }
}
