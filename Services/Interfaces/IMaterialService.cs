using System.Collections.Generic;
using Proyecto1.Models;

namespace Proyecto1.Services.Interfaces
{
    public interface IMaterialService
    {
        bool Registrar(Material material);

        bool Actualizar(Material material);

        bool Eliminar(int idMaterial);

        Material ObtenerPorId(int idMaterial);

        List<Material> ObtenerTodos();

        List<Material> ObtenerConStockBajo();
    }
}
