using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cinema.Web.Models {
    public class SalaView {
        public int Id { get; set; }
        public int Capacita { get; set; }
        public int Nome{get;set;}

        public SalaView()
        {

        }

        public SalaView(Sala sala)
        {
            Id = sala.Id;
            Capacita = sala.Capacita;
            Nome = sala.Nome;
        }

        public Sala ToSala (Sala sala)
        {
            return new Sala(Id, Capacita, Nome);
        }

        public bool IsPiena()
        {
            return true; /*da implementare*/
        }

        public void SvuotaSala()
        {
            /* da implementare*/
        }
    }
}