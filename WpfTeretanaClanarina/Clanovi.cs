using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfTeretanaClanarina
{
    class Clanovi
    {
        public int ClanoviId { get; set; }
        public  int AktivnaClanarinaId { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public DateTime VremeOd { get; set; }
        public DateTime VremeDo { get; set; }

        public override string ToString()
        {
            return string.Format("{0} {1}", Ime, Prezime);
        }
    }
}
