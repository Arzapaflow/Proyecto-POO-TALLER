using System.Collections.Generic;
using Proyecto1.Models;

namespace Proyecto1.Repositorios.Interfaces
{
    public interface IEquipoRepository
    {
        bool Insertar(Equipo equipo);

        bool Actualizar(Equipo equipo);

        bool Eliminar(int idEquipo);

        Equipo ObtenerPorId(int idEquipo);

        List<Equipo> ObtenerTodos();
    }
}