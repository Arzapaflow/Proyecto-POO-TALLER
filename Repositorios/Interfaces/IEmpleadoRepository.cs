using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Proyecto1.Models;

namespace Proyecto1.Repositorios.Interfaces
{
    public interface IEmpleadoRepository
    {
        bool Insertar(Empleado empleado);

        bool Actualizar(Empleado empleado);

        bool Eliminar(int idEmpleado);

        Empleado ObtenerPorId(int idEmpleado);

        List<Empleado> ObtenerTodos();
    }
}
