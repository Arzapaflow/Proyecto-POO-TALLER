using System.Collections.Generic;
using Proyecto1.Models;

namespace Proyecto1.Services.Interfaces
{
    public interface IRecepcionistaService
    {
        bool Registrar(Recepcionista recepcionista);

        bool Actualizar(Recepcionista recepcionista);

        bool Eliminar(int idEmpleado);

        Recepcionista ObtenerPorId(int idEmpleado);

        List<Recepcionista> ObtenerTodos();
    }
}