using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Proyecto1.Models;

namespace Proyecto1.Repositorios.Interfaces
{
    public interface IProblemaRepository
    {
        bool Insertar(Problema problema);

        bool Actualizar(Problema problema);

        bool Eliminar(int idProblema);

        Problema ObtenerPorId(int idProblema);

        List<Problema> ObtenerTodos();
    }
}
