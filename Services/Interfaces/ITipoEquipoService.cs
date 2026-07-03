using System.Collections.Generic;
using Proyecto1.Models;

namespace Proyecto1.Services.Interfaces
{
    public interface ITipoEquipoService
    {
        bool Registrar(TipoEquipo tipoEquipo);

        bool Actualizar(TipoEquipo tipoEquipo);

        bool Eliminar(int idTipoEquipo);

        TipoEquipo ObtenerPorId(int idTipoEquipo);

        List<TipoEquipo> ObtenerTodos();
    }
}