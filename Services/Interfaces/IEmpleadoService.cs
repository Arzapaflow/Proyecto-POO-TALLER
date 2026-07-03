using System.Collections.Generic;
using Proyecto1.Models;

namespace Proyecto1.Services.Interfaces
{
    public interface IEmpleadoService
    {
        bool Registrar(Empleado empleado);

        bool Actualizar(Empleado empleado);

        bool Eliminar(int idEmpleado);

        Empleado ObtenerPorId(int idEmpleado);

        List<Empleado> ObtenerTodos();
    }
}
