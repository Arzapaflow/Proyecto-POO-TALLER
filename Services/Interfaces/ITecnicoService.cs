using System.Collections.Generic;
using Proyecto1.Models;

namespace Proyecto1.Services.Interfaces
{
    public interface ITecnicoService
    {
        bool Registrar(Tecnico tecnico);

        bool Actualizar(Tecnico tecnico);

        bool Eliminar(int idEmpleado);

        Tecnico ObtenerPorId(int idEmpleado);

        List<Tecnico> ObtenerTodos();
    }
}