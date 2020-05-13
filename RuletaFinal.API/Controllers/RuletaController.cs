using Microsoft.AspNetCore.Mvc;
using RuletaFinal.Business.Interfaces;
using RuletaFinal.Transversal.Entities;
using System;
using System.Collections.Generic;

namespace RuletaFinal.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RuletaController : ControllerBase
    {
        private readonly IBusinnesRuleta ruletabl;
        private readonly IBusinnesUsuario usuariobl;

        public RuletaController(IBusinnesRuleta ruletabl, IBusinnesUsuario usuariobl)
        { 
            this.ruletabl = ruletabl;
            this.usuariobl = usuariobl;
        }

        // GET: api/Ruleta
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                List<Ruleta> ruletas = ruletabl.Get();
                return Ok(ruletas);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/Ruleta/5
        [HttpGet("Get/{id}")]
        public IActionResult Get(string id)
        {
            try
            {
                Ruleta ruleta = ruletabl.Get(id);
                if (ruleta == null) 
                    return NotFound();
                return Ok(ruleta);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// 1. Endpoint de creación de nuevas ruletas que devuelva el id de la nueva ruleta creada
        /// </summary>
        /// <returns></returns>
        [HttpPost("Create")]
        public IActionResult Create()
        {
            try 
            {
                string id = ruletabl.Create();
                return Ok(id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// 2. Endpoint de apertura de ruleta(el input es un id de ruleta) que permita las posteriores 
        /// peticiones de apuestas, este debe devolver simplemente un estado que confirme que la operación 
        /// fue exitosa o denegada
        /// </summary>
        /// <returns></returns>
        [HttpGet("Apertura/{id}")]
        public IActionResult Apertura(string id)
        {
            try 
            {
                var ruleta = ruletabl.Get(id);
                if (ruleta == null) 
                    return NotFound();
                bool result = ruletabl.Apertura(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// 3. Endpoint de apuesta a un número(los números válidos para apostar son del 0 al 36) o color(negro o rojo) 
        /// de la ruleta una cantidad determinada de dinero(máximo 10.000 dólares) a una ruleta abierta. (nota: este 
        /// enpoint recibe además de los parámetros de la apuesta, un id de usuario en los HEADERS asumiendo que el 
        /// servicio que haga la petición ya realizo una autenticación y validación de que el cliente tiene el crédito 
        /// necesario para realizar la apuesta)
        /// </summary>
        /// <returns></returns>
        [HttpPost("Apuesta/{usuarioId}")]
        public IActionResult Apuesta(string usuarioId, Apuesta apuesta)
        {
            try 
            {
                var usuario = usuariobl.Get(usuarioId);
                if (usuario == null)
                    return NotFound();
                string id = ruletabl.Apuesta(usuario, apuesta);
                return Ok(id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// 4. Endpoint de cierre apuestas dado un id de ruleta, este endpoint debe devolver el 
        /// resultado de las apuestas hechas desde su apertura hasta el cierre.
        /// </summary>
        /// <returns></returns>
        [HttpGet("Cierre/{id}")]
        public IActionResult Cierre(string id)
        {
            try 
            {
                var ruleta = ruletabl.Get(id);
                if (ruleta == null) return NotFound();
                decimal result = ruletabl.Cierre(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok();
        }
    }
}
