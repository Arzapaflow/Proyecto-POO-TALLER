using System.Collections.Generic;
using Proyecto1.Models;

namespace Proyecto1.Repositorios.Interfaces
{
    public interface ITecnicoRepository
    {
        bool Insertar(Tecnico tecnico);

        bool Actualizar(Tecnico tecnico);

        bool Eliminar(int idEmpleado);

        Tecnico ObtenerPorId(int idEmpleado);

        List<Tecnico> ObtenerTodos();
    }
}