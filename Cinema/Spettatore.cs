using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema {
   public class Spettatore {

        public readonly int Id;
        public readonly string Nome;
        public readonly string Cognome;
        public readonly DateTime DataNascita;

        public Spettatore(int id, string nome, string cognome, DateTime dataNascita)
        {
            Id = id;
            Nome = nome;
            Cognome = cognome;
            DataNascita = dataNascita;
        }

        public Spettatore(int id)
        {
            Id = id;
        }
    }
}
