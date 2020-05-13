using Microsoft.Extensions.Caching.Distributed;
using RuletaFinal.DAL.Interfaces;
using RuletaFinal.Transversal.Entities;

namespace RuletaFinal.DAL.Implementations
{
    public class RepositoryApuesta : Repository<Apuesta>, IRepositoryApuesta
    {
        public RepositoryApuesta(IDistributedCache cache) 
            : base(cache, "apuesta")
        {
        }

        public string Create(Usuario usuario, Apuesta apuesta)
        {
            throw new System.NotImplementedException();
        }
    }
}
