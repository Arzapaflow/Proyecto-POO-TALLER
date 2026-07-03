using System.Collections.Generic;
using Proyecto1.Models;

namespace Proyecto1.Services.Interfaces
{
    public interface IProblemaService
    {
        bool Registrar(Problema problema);

        bool Actualizar(Problema problema);

        bool Eliminar(int idProblema);

        Problema ObtenerPorId(int idProblema);

        List<Problema> ObtenerTodos();
    }
}
