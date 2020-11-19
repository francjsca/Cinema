using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cinema.Web.Models {
    public class FilmView {
        public int Id { get; set; }
        public  string Titolo { get; set; }
        public string Regista { get; set; }
        public string Produttore { get; set; }
        public int MinutiDurata { get; set; }
        public string Genere { get; set; }

        public FilmView()
        {

        }

        public FilmView(Film film)
        {
            Id = film.Id;
            Titolo = film.Titolo;
            Regista = film.Regista;
            Produttore = film.Produttore;
            MinutiDurata = film.MinutiDurata;
            Genere = film.Genere;
        }

        public Film ToFilm (Film film)
        {
            return new Film(Id, Titolo,Regista,Produttore,MinutiDurata,Genere);
        }
    }
}