using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema {
    public class Film {
        public readonly int Id;
        public readonly string Titolo;
        public string Regista {get;set;}
        public string Produttore { get; set; }
        public int MinutiDurata { get; set; }
        public string Genere { get; set; }

        public Film(int id, string titolo, string regista, string produttore, int minutiDurata, string genere)
        {
            Id = id;
            Titolo = titolo;
            Regista = regista;
            Produttore = produttore;
            MinutiDurata = minutiDurata;
            Genere = genere;
        }

        public Film(int id, string titolo)
        {
            Id = id;
            Titolo = titolo;
        }
    }
}
