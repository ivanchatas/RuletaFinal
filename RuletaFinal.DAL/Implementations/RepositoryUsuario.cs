using Microsoft.Extensions.Caching.Distributed;
using RuletaFinal.DAL.Interfaces;
using RuletaFinal.Transversal.Entities;
using System;
using System.Collections.Generic;

namespace RuletaFinal.DAL.Implementations
{
    public class RepositoryUsuario : Repository<Usuario>, IRepositoryUsuario
    {
        public RepositoryUsuario(IDistributedCache cache)
            : base(cache, "usuario")
        { }

        public string Create(Usuario usuario) 
        {
            usuario.Id = Guid.NewGuid();
            SetObjectAsync(usuario.Id.ToString(), usuario);
            return usuario.Id.ToString();
        }

        public Usuario Get(string usuarioId)
        {
            return GetObjectAsync(usuarioId);
        }

        public List<Usuario> Get()
        {
            return null;
        }

    }
}
