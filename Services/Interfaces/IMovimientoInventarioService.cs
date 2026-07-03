using System.Collections.Generic;
using Proyecto1.Models;

namespace Proyecto1.Services.Interfaces
{
    public interface IMovimientoInventarioService
    {
        bool Registrar(MovimientoInventario movimiento);

        MovimientoInventario ObtenerPorId(int idMovimiento);

        List<MovimientoInventario> ObtenerTodos();
    }
}
