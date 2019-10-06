using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat_1
{
    class Stats
    {
        private DateTime datumOd;
        private DateTime datumDo;
        private string auto;
        private int brDana;

        public DateTime DatumOd
        {
            get
            {
                return datumOd;
            }

            set
            {
                datumOd = value;
            }
        }

        public DateTime DatumDo
        {
            get
            {
                return datumDo;
            }

            set
            {
                datumDo = value;
            }
        }

        public string Auto
        {
            get
            {
                return auto;
            }

            set
            {
                auto = value;
            }
        }

        public int BrDana
        {
            get
            {
                return brDana;
            }

            set
            {
                brDana = value;
            }
        }

        public Stats(DateTime datumOd, DateTime datumDo, string auto, int brDana)
        {
            this.datumOd = datumOd;
            this.datumDo = datumDo;
            this.auto = auto;
            this.brDana = brDana;

        }
        public Stats()
        {
            this.datumOd = DateTime.Now;
            this.datumDo = DateTime.Now;
            this.auto = "nema";
            brDana = 0;
        }
        public override string ToString()
        {
            return auto;
        }
    }
}
