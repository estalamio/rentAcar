using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat_1
{
    [Serializable()]
    public class Korisnik
    {
        protected string ime;
        protected string prezime;
        protected string korisnickoIme;
        protected string lozinka;
        protected int IdbrAdmina;
        protected string titula;
        protected string datumRodjenja;

        public Korisnik()
        {
            this.ime = "";
            this.prezime = "";
            this.korisnickoIme = "";
            this.lozinka = "";
        }
        public Korisnik(string ime,string prezime,string korisnickoIme,string lozinka)
        {
            this.ime = ime;
            this.prezime = prezime;
            this.korisnickoIme = korisnickoIme;
            this.lozinka = lozinka;
        }

        public string Ime
        {
            get
            {
                return this.ime;
            }
            set
            {
                this.ime = value;
            }
        }
        public string Prezime
        {
            get
            {
                return this.prezime;
            }
            set
            {
                this.prezime = value;
            }
        }
        public string KorisnickoIme
        {
            get
            {
                return this.korisnickoIme;
            }
            set
            {
                this.korisnickoIme = value;
            }
        }
        public string Lozinka
        {
            get
            {
                return this.lozinka;
            }
            set
            {
                this.lozinka = value;
            }
        }
    }
}
