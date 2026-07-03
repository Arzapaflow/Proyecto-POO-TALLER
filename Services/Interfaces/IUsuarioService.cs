using System.Collections.Generic;
using Proyecto1.Models;

namespace Proyecto1.Services.Interfaces
{
    public interface IUsuarioService
    {
        Usuario Autenticar(string nombreUsuario, string contrasena);

        bool Registrar(Usuario usuario);

        bool Actualizar(Usuario usuario);

        bool Eliminar(int idUsuario);

        Usuario ObtenerPorId(int idUsuario);

        List<Usuario> ObtenerTodos();
    }
}