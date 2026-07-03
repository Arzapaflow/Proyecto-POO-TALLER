using System.Collections.Generic;
using Proyecto1.Models;

namespace Proyecto1.Services.Interfaces
{
    public interface IEquipoService
    {
        bool Registrar(Equipo equipo);

        bool Actualizar(Equipo equipo);

        bool Eliminar(int idEquipo);

        Equipo ObtenerPorId(int idEquipo);

        List<Equipo> ObtenerTodos();
    }
}
