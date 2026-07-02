using System.Collections.Generic;
using Proyecto1.Models;

namespace Proyecto1.Repositorios.Interfaces
{
    public interface ITipoEquipoRepository
    {
        bool Insertar(TipoEquipo tipoEquipo);

        bool Actualizar(TipoEquipo tipoEquipo);

        bool Eliminar(int idTipoEquipo);

        TipoEquipo ObtenerPorId(int idTipoEquipo);

        List<TipoEquipo> ObtenerTodos();
    }
}
