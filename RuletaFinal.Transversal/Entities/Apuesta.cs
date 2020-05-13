using RuletaFinal.Transversal.Common;
using System;

namespace RuletaFinal.Transversal.Entities
{
    public class Apuesta
    {
        public Guid Id { get; set; }

        public TipoApuesta TipoApuesta { get; set; }
        
        public int? Numero { get; set; }
        
        /// <summary>
        /// 1: negro,
        /// 0: rojo 
        /// </summary>
        public short? Color { get; set; }

        public long Valor { get; set; }

        public Guid IdRuleta { get; set; }
        public Ruleta Ruleta { get; set; }

        public Guid IdUsuario { get; set; }
        public Usuario Usuario { get; set; }
    }
}
