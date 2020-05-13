using RuletaFinal.Business.Interfaces;
using RuletaFinal.DAL.Interfaces;
using RuletaFinal.Transversal.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace RuletaFinal.Business.Implementations
{
    public class BusinnesUsuario : IBusinnesUsuario
    {
        private readonly IRepositoryUsuario repo;
        public BusinnesUsuario(IRepositoryUsuario repositorio)
            => repo = repositorio;

        public string Create(Usuario usuario)
        {
            return repo.Create(usuario);
        }

        public Usuario Get(string usuarioId)
        {
            return repo.Get(usuarioId);
        }
    }
}
