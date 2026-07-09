using Proyecto1.Models;
using Proyecto1.Models.Enums;
using System.Collections.Generic;

namespace Proyecto1.Services.Interfaces
{
    public interface ITecnicoService
    {
        bool Registrar(Tecnico tecnico, Usuario usuario);

        bool Actualizar(Tecnico tecnico, Usuario usuario);

        bool Eliminar(int idEmpleado);

        Tecnico ObtenerPorId(int idEmpleado);

        List<Tecnico> ObtenerTodos();
        List<Tecnico> ObtenerPorEspecialidad(Especialidad especialidad);
        
    }
}