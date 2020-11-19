using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cinema.Web.Models {
    public class BigliettoView {
        public int Id { get; set; }
        public int IdProiezione { get; set; }
        public int IdSpettatore { get; set; }
        public int Fila { get; set; }
        public int NumeroPosto { get; set; }
       public float Prezzo { get; set; }
        public const float prezzoBase = 10;

        public BigliettoView()
        {

        }

        public BigliettoView(Biglietto biglietto)
        {
            Id = biglietto.Id;
            IdProiezione = biglietto.IdProiezione;
            IdSpettatore = biglietto.IdSpettatore;
            Fila = biglietto.Fila;
            NumeroPosto = biglietto.NumeroPosto;
            Prezzo = CalcolaPrezzo(new SpettatoreView(new Spettatore(biglietto.IdSpettatore)));
        }

        public Biglietto ToBiglietto()
        {
            return new Biglietto(Id, IdProiezione, IdSpettatore, Fila, NumeroPosto, Prezzo);
            
        }

        public float CalcolaPrezzo(SpettatoreView spettatore)
        {
            var nascita = spettatore.DataNascita;
            var anni = DateTime.Now.Year - nascita.Year;
            if (anni > 70) {
                return prezzoBase - (prezzoBase * 10 / 100);
            } else if (anni < 5) {
                return prezzoBase / 2;
            } else return prezzoBase;
        }
    }
}