using RuletaFinal.Transversal.Entities;

namespace RuletaFinal.DAL.Interfaces
{
    public interface IRepositoryApuesta
    {
        string Create(Usuario usuario, Apuesta apuesta);
    }
}
