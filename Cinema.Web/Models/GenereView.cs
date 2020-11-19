using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cinema.Web.Models {
    public class GenereView {
        public  string Nome { get; set; }

        public GenereView()
        {

        }

        public GenereView(Genere genere)
        {
            Nome = genere.Nome;
        }

        public Genere ToGenere(Genere genere)
        {
            return new Genere(Nome);
        }
    }
}