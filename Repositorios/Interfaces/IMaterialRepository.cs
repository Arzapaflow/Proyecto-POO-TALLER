using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Proyecto1.Models;


namespace Proyecto1.Repositorios.Interfaces
{
    public interface IMaterialRepository
    {
        bool Insertar(Material material);

        bool Actualizar(Material material);

        bool Eliminar(int idMaterial);

        Material ObtenerPorId(int idMaterial);

        List<Material> ObtenerTodos();
    }
}
