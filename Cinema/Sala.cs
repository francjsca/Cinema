using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema
{
    public class Sala
    {
        public readonly int Id;
        public readonly int Capacita;
        public readonly int Nome;

        public Sala(int id, int capacita, int nome)
        {
            Id = id;
            Capacita = capacita;
            Nome = nome;
        }
    }
}
