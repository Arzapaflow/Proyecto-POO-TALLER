using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Proyecto1.Models;

namespace Proyecto1.Repositorios.Interfaces
{
    public interface IMovimientoInventarioRepository
    {
        bool Insertar(MovimientoInventario movimiento);

        bool Actualizar(MovimientoInventario movimiento);

        bool Eliminar(int idMovimiento);

        MovimientoInventario ObtenerPorId(int idMovimiento);

        List<MovimientoInventario> ObtenerTodos();
    }
}