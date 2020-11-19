using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema {
   public class Proiezione {
        public readonly int Id;
        public int IdSala { get; set; }
        public int IdFilm { get; set; }
        public DateTime Data { get; set; }

        public Proiezione(int id, int idSala, int idFilm, DateTime data)
        {
            Id = id;
            IdSala = idSala;
            IdFilm = idFilm;
            Data = data;
        }
    }
}
