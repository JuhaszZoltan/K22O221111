using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BukkMaraton2019
{
    internal class Versenyzo
    {
        public string Rajtszam { get; set; }
        public string Kategoria { get; set; }
        public string Nev { get; set; }
        public string? Egyesulet { get; set; }
        public TimeSpan Ido { get; set; }

        public string Tav => Rajtszam[0] switch
        {
            'M' => "Mini",
            'R' => "Rövid",
            'K' => "Közép",
            'H' => "Hosszú",
            'E' => "Pedelec",
            _ => throw new Exception("hibás rajtszám!")
        };

        public bool Nem => Kategoria[Kategoria.Length - 1] == 'f';

        public Versenyzo(string sor)
        {
            string[] v = sor.Split(';');
            Rajtszam = v[0];
            Kategoria = v[1];
            Nev = v[2];
            Egyesulet = v[3];
            Ido = TimeSpan.Parse(v[4]);
        }
    }
}
