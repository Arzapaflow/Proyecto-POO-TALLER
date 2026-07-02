using System.Collections.Generic;
using Proyecto1.Models;

namespace Proyecto1.Repositorios.Interfaces
{
    public interface IRecepcionistaRepository
    {
        bool Insertar(Recepcionista recepcionista);

        bool Actualizar(Recepcionista recepcionista);

        bool Eliminar(int idEmpleado);

        Recepcionista ObtenerPorId(int idEmpleado);

        List<Recepcionista> ObtenerTodos();
    }
}