using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Proyecto1.Models;

namespace Proyecto1.Repositorios.Interfaces
{
    public interface IUsuarioRepository
    {
        bool Insertar(Usuario usuario);

        bool Actualizar(Usuario usuario);

        bool Eliminar(int idUsuario);

        Usuario ObtenerPorId(int idUsuario);

        Usuario ObtenerPorNombreUsuario(string nombreUsuario);

        List<Usuario> ObtenerTodos();
    }
}
