using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RuletaFinal.Business.Interfaces;
using RuletaFinal.Transversal.Entities;
using System;
using System.Collections.Generic;

namespace RuletaFinal.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {

        private readonly IBusinnesUsuario usuariobl;

        public UsuarioController(IBusinnesUsuario usuariobl)
            => this.usuariobl = usuariobl;


        // GET: api/Usuario
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Usuario/5
        [HttpGet("Get/{id}")]
        public IActionResult Get(string id)
        {
            try 
            {
                Usuario usuario = usuariobl.Get(id);
                if (usuario == null) return NotFound();
                return Ok(usuario);
            }
            catch (Exception ex) 
            {
                return BadRequest(ex.Message);
            }
        }

        // POST: api/Usuario
        [HttpPost]
        public IActionResult Post([FromBody] string value)
        {
            try
            {
                Usuario usuario = JsonConvert.DeserializeObject<Usuario>(value);
                usuario.Id = Guid.Parse(usuariobl.Create(usuario));
                return Ok(usuario.Id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT: api/Usuario/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
