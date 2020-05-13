using Microsoft.Extensions.Caching.Distributed;
using RuletaFinal.DAL.Interfaces;
using RuletaFinal.Transversal.Common;
using RuletaFinal.Transversal.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RuletaFinal.DAL.Implementations
{
    public class RepositoryRuleta : Repository<Ruleta>, IRepositoryRuleta
    {
        public RepositoryRuleta(IDistributedCache cache) 
            : base(cache, "ruleta")
        { }

        public string Create()
        {
            Ruleta ruleta = new Ruleta()
            {
                Id = Guid.NewGuid(),
                Estado = true,
                Apuestas = new List<Apuesta>()
            };

            SetObjectAsync(ruleta.Id.ToString(), ruleta);
            return ruleta.Id.ToString();
        }

        public bool Apertura(string id)
        {
            Ruleta ruleta = GetObjectAsync(id);
            ruleta.Estado = true;
            ruleta.Apuestas = new List<Apuesta>();
            SetObjectAsync(ruleta.Id.ToString(), ruleta);
            return true;
        }

        public long Cierre(string id)
        {
            var ruleta = GetObjectAsync(id);
            ruleta.Estado = false;
            SetObjectAsync(ruleta.Id.ToString(), ruleta);
            var result = ruleta.Apuestas.Sum(x => x.Valor);
            return result;
        }

        public List<Ruleta> Get()
        {
            return GetList();
        }

        public Ruleta Get(string id)
        {
            Ruleta ruleta = GetObjectAsync(id);
            return ruleta;
        }

        /// <summary>
        /// Endpoint de apuesta a un número (los números válidos para apostar son del 0 al 36) o color (negro o rojo) 
        /// de la ruleta una cantidad determinada de dinero (máximo 10.000 dólares) a una ruleta abierta. 
        /// (nota: este enpoint recibe además de los parámetros de la apuesta, un id de usuario en los HEADERS asumiendo 
        /// que el servicio que haga la petición ya realizo una autenticación y validación de que el cliente tiene el crédito 
        /// necesario para realizar la apuesta)
        /// </summary>
        /// <param name="apuesta"></param>
        /// <returns></returns>
        public string Apuesta(Usuario usuario, Apuesta apuesta)
        {
            if (apuesta.TipoApuesta.Equals(TipoApuesta.Numero))
            {
                if (apuesta.Numero.Value < 0 || apuesta.Numero.Value > 36)
                    throw new Exception("El número con el que quiere apostar no es valido.");
            }
            else
            {
                if (apuesta.Color.Value < 0 || apuesta.Color.Value > 1)
                    throw new Exception("El color con el que quiere apostar no es valido.");
            }

            if (usuario.Saldo < apuesta.Valor)
                throw new Exception("Su saldo insuficiente.");

            Ruleta ruleta = GetObjectAsync(apuesta.IdRuleta.ToString());
            apuesta.Id = Guid.NewGuid();
            ruleta.Apuestas.Add(apuesta);

            SetObjectAsync(ruleta.Id.ToString(), ruleta);

            return apuesta.Id.ToString();
        }
    }
}
