using System;
using System.Collections.Generic;

namespace RuletaFinal.Transversal.Entities
{
    public class Usuario
    {
        public Guid Id { get; set; }
        public string Nombre { get; set; }
        public long Saldo { get; set; }
        public List<Apuesta> Apuestas { get; set; }
    }
}
