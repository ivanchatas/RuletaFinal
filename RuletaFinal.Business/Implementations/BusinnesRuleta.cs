using RuletaFinal.Business.Interfaces;
using RuletaFinal.DAL.Interfaces;
using RuletaFinal.Transversal.Entities;
using System.Collections.Generic;

namespace RuletaFinal.Business.Implementations
{
    public class BusinnesRuleta : IBusinnesRuleta
    {
        private readonly IRepositoryRuleta repo;
        public BusinnesRuleta(IRepositoryRuleta repositorio) 
            => repo = repositorio; 

        public string Create()
        {
            return repo.Create();
        }

        public bool Apertura(string id)
        {
            return repo.Apertura(id);
        }

        public string Apuesta(Usuario usuario, Apuesta apuesta)
        {
            return repo.Apuesta(usuario, apuesta);
        }

        public long Cierre(string id)
        {
            return repo.Cierre(id);
        }

        public List<Ruleta> Get()
        {
            return repo.Get();
        }

        public Ruleta Get(string id)
        {
            return repo.Get(id);
        }
    }
}
