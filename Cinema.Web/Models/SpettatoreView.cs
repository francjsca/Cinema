using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cinema.Web.Models {
    public class SpettatoreView {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cognome { get; set; }
        public DateTime DataNascita { get; set; }

        public SpettatoreView()
        {
                
        }

        public SpettatoreView(Spettatore spettatore)
        {
            Id = spettatore.Id;
            Nome = spettatore.Nome;
            Cognome = spettatore.Cognome;
            DataNascita = spettatore.DataNascita;
        }

        public Spettatore ToSpettatore()
            {
                var spettatore = new Spettatore(Id, Nome, Cognome, DataNascita);
                return spettatore;
            }        
    }
}