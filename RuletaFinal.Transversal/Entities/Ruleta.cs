using System;
using System.Collections.Generic;
using System.Text;

namespace RuletaFinal.Transversal.Entities
{
    public class Ruleta
    {
        public Guid Id { get; set; }
        public bool Estado { get; set; }
        public List<Apuesta> Apuestas { get; set; }
    }
}
