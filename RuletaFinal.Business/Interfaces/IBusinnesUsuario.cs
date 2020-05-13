using RuletaFinal.Transversal.Entities;

namespace RuletaFinal.Business.Interfaces
{
    public interface IBusinnesUsuario
    {
        string Create(Usuario usuario);

        Usuario Get(string usuarioId);
    }
}
