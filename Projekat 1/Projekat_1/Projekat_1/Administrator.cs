using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat_1
{
    [Serializable()]
    public class Administrator:Korisnik
    {
     
            
        public Administrator()
        {
            base.IdbrAdmina = 0;
            base.titula = "";
            base.ime = "";
            base.prezime = "";
            base.datumRodjenja = "";
            base.korisnickoIme = "";
            base.lozinka = "";

        }
        public Administrator(int IdbrAdmina,string titula,string ime,string prezime,string datumRodjenja,string korisnickoIme,string lozinka)
        {
            base.IdbrAdmina = IdbrAdmina;
            base.titula = titula;
            base.ime = ime;
            base.prezime = prezime;
            base.datumRodjenja = datumRodjenja;
            base.korisnickoIme = korisnickoIme;
            base.lozinka = lozinka;
        }
        public int IDBRadmina
        {
            get
            {
                return base.IdbrAdmina;
            }
            set
            {
                base.IdbrAdmina = value;
            }
        }
        public string Titula
        {
            get
            {
                return base.titula;
            }
            set
            {
                base.titula = value;
            }
        }
        public string Ime {
            get
            {
                return base.ime;
            }
            set
            {
                base.ime = value;
            }
            }
        public string Prezime {

            get
            {
                return base.prezime;
            }

            set
            {
                base.prezime = value;
            }
        }
        public string DatumRodjenja
        {
            get
            {
                return base.datumRodjenja;
            }
            set
            {
                base.datumRodjenja = value;
            }
        }
        public string KorisnickoIme {
            get
            {
                return base.korisnickoIme;
            }

            set
            {
                base.korisnickoIme = value;
            }
            }
        public string Lozinka {
            get
            {
                return base.lozinka;
            }
            set
            {
                base.lozinka = value;
            }
                }
        public override string ToString()
        {
            return this.Ime + " " + this.Prezime;
        }

    }
}
