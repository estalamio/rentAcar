using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat_1
{
    public class Kupac:Korisnik
    {
        private string idKupca;
        private int jmbg;
        private DateTime datRodjenja = new DateTime();
        private int telefon;

        public Kupac()
        {
            this.idKupca = "";
            this.jmbg = 0;
            this.datRodjenja = new DateTime();
            this.telefon = 0;
        }
        public Kupac(string idKupca,int jmbg,DateTime datRodjenja,int telefon)
        {
            this.idKupca = idKupca;
            this.jmbg = jmbg;
            this.datRodjenja = new DateTime();
            this.telefon = telefon;
        }

        public string IdKupca
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
        public int JMBG
        {
            get
            {
                return this.jmbg;
            }
            set
            {
                this.jmbg = value;
            }
        }
        public DateTime DatRodjenja
        {
            get
            {
                return this.datRodjenja;
            }
            set
            {
                this.datRodjenja = value;
            }
        }
    }
}
