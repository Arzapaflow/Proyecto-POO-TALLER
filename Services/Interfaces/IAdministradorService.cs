using System.Collections.Generic;
using Proyecto1.Models;

namespace Proyecto1.Services.Interfaces
{
    public interface IAdministradorService
    {
        bool Registrar(Administrador administrador);

        bool Actualizar(Administrador administrador);

        bool Eliminar(int idEmpleado);

        Administrador ObtenerPorId(int idEmpleado);

        List<Administrador> ObtenerTodos();
    }
}