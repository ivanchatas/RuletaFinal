using RuletaFinal.Transversal.Entities;
using System.Collections.Generic;

namespace RuletaFinal.DAL.Interfaces
{
    public interface IRepositoryRuleta : IRepository<Ruleta>
    {
        string Create();
        bool Apertura(string id);
        long Cierre(string id);
        Ruleta Get(string id);
        List<Ruleta> Get();
        string Apuesta(Usuario usuario, Apuesta apuesta);
    }
}
