using System.Collections.Generic;
using Proyecto1.Models;

namespace Proyecto1.Repositorios.Interfaces
{
    public interface IAdministradorRepository
    {
        bool Insertar(Administrador administrador);

        bool Actualizar(Administrador administrador);

        bool Eliminar(int idEmpleado);

        Administrador ObtenerPorId(int idEmpleado);

        List<Administrador> ObtenerTodos();
    }
}