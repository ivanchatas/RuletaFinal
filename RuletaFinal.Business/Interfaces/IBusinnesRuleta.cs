using RuletaFinal.Transversal.Entities;
using System.Collections.Generic;

namespace RuletaFinal.Business.Interfaces
{
    public interface IBusinnesRuleta
    {
        /// <summary>
        /// Listado de ruletas creadas con sus estados (abierta o cerrada)
        /// </summary>
        /// <returns></returns>
        List<Ruleta> Get();

        /// <summary>
        /// Ruletas por Id
        /// </summary>
        /// <returns></returns>
        Ruleta Get(string id);

        /// <summary>
        /// Creación de nuevas ruletas
        /// </summary>
        /// <returns>Id de la nueva ruleta creada</returns>
        string Create();

        /// <summary>
        /// Apertura de ruleta que permita las posteriores peticiones de apuestas
        /// </summary>
        /// <param name="id">id de ruleta</param>
        /// <returns>
        /// Estado que confirme que la operación fue exitosa o denegada
        /// </returns>
        bool Apertura(string id);

        /// <summary>
        /// Apuesta a un número(los números válidos para apostar son del 0 al 36) o color(negro o rojo) 
        /// de la ruleta una cantidad determinada de dinero(máximo 10.000 dólares) a una ruleta abierta. (nota: este 
        /// enpoint recibe además de los parámetros de la apuesta, un id de usuario en los HEADERS asumiendo que el 
        /// servicio que haga la petición ya realizo una autenticación y validación de que el cliente tiene el crédito 
        /// necesario para realizar la apuesta)
        /// </summary>
        /// <param name="usuario"></param>
        /// <param name="apuesta"></param>
        /// <returns></returns>
        string Apuesta(Usuario usuario, Apuesta apuesta);

        /// <summary>
        /// Cierre apuestas dado un id de ruleta, este endpoint debe devolver el 
        /// resultado de las apuestas hechas desde su apertura hasta el cierre.
        /// </summary>
        /// <returns></returns>
        long Cierre(string id);
    }
}
