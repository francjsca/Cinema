using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cinema.Web.Models {
    public class DashboardView {
        public List<ProiezioneView> FilmProiettati;
        public List<FilmView> Film;

        public DashboardView()
        {

        }

        public DashboardView(List<ProiezioneView> filmProiettati,List<FilmView> films)
        {
            FilmProiettati = filmProiettati;
            Film = films;
        }
    }
}