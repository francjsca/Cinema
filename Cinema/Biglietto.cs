using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema {
    public class Biglietto {

        public readonly int Id;
        public int IdProiezione { get; set; }
        public int IdSpettatore { get; set; }
        public readonly int Fila;
        public readonly int NumeroPosto;
        public float Prezzo { get; set; }

        public Biglietto(int id, int idProiezione, int idSpettatore, int fila, int numeroPosto, float prezzo)
        {
            Id = id;
            IdProiezione = idProiezione;
            IdSpettatore = idSpettatore;
            Fila = fila;
            NumeroPosto = numeroPosto;
            Prezzo = prezzo;
        }
    }
}
