using RuletaFinal.Transversal.Entities;
using System.Collections.Generic;

namespace RuletaFinal.DAL.Interfaces
{
    public interface IRepositoryUsuario : IRepository<Usuario>
    {
        string Create(Usuario usuario);

        Usuario Get(string usuarioId);
        List<Usuario> Get();
    }
}
