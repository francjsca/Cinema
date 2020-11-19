using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cinema.Web.Models {
    public class ProiezioneView {
        public int Id { get; set; }
        public int IdSala { get; set; }
        public int IdFilm { get; set; }
        public DateTime Data { get; set; }

        public ProiezioneView()
        {

        }

        public ProiezioneView(Proiezione proiezione)
        {
            Id = proiezione.Id;
            IdFilm = proiezione.IdFilm;
            IdSala = proiezione.IdSala;
            Data = proiezione.Data;
        }

        public Proiezione ToProiezione()
        {
            return new Proiezione(Id, IdSala, IdFilm, Data);
            
        }

   
    }
}