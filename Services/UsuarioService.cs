using System;
using System.Collections.Generic;
using Proyecto1.Models;
using Proyecto1.Repositorios;
using Proyecto1.Repositorios.Interfaces;
using Proyecto1.Services.Interfaces;

namespace Proyecto1.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioService()
        {
            _usuarioRepository = new UsuarioRepository();
        }

        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            if (usuarioRepository == null)
                throw new ArgumentNullException(nameof(usuarioRepository));

            _usuarioRepository = usuarioRepository;
        }

        public Usuario Autenticar(
            string nombreUsuario,
            string contrasena)
        {
            if (string.IsNullOrWhiteSpace(nombreUsuario))
                throw new ArgumentException(
                    "Debe ingresar el nombre de usuario."
                );

            if (string.IsNullOrWhiteSpace(contrasena))
                throw new ArgumentException(
                    "Debe ingresar la contraseña."
                );

            Usuario usuario =
                _usuarioRepository.ObtenerPorNombreUsuario(
                    nombreUsuario.Trim()
                );

            if (usuario == null)
                return null;

            if (!usuario.Activo)
                return null;

            if (usuario.Contrasena != contrasena)
                return null;

            return usuario;
        }

        public bool Registrar(Usuario usuario)
        {
            if (usuario == null)
                throw new ArgumentNullException(nameof(usuario));

            if (usuario.IdEmpleado <= 0)
                throw new ArgumentException(
                    "Debe asignarse un empleado al usuario."
                );

            if (usuario.IdRol <= 0)
                throw new ArgumentException(
                    "Debe asignarse un rol al usuario."
                );

            if (string.IsNullOrWhiteSpace(usuario.NombreUsuario))
                throw new ArgumentException(
                    "El nombre de usuario no puede estar vacío."
                );

            if (string.IsNullOrWhiteSpace(usuario.Contrasena))
                throw new ArgumentException(
                    "La contraseña no puede estar vacía."
                );

            Usuario usuarioExistente =
                _usuarioRepository.ObtenerPorNombreUsuario(
                    usuario.NombreUsuario.Trim()
                );

            if (usuarioExistente != null)
                throw new InvalidOperationException(
                    "El nombre de usuario ya está registrado."
                );

            usuario.NombreUsuario =
                usuario.NombreUsuario.Trim();

            return _usuarioRepository.Insertar(usuario);
        }

        public bool Actualizar(Usuario usuario)
        {
            if (usuario == null)
                throw new ArgumentNullException(nameof(usuario));

            if (usuario.IdUsuario <= 0)
                throw new ArgumentException(
                    "El identificador del usuario no es válido."
                );

            if (string.IsNullOrWhiteSpace(usuario.NombreUsuario))
                throw new ArgumentException(
                    "El nombre de usuario no puede estar vacío."
                );

            if (string.IsNullOrWhiteSpace(usuario.Contrasena))
                throw new ArgumentException(
                    "La contraseña no puede estar vacía."
                );

            Usuario usuarioExistente =
                _usuarioRepository.ObtenerPorNombreUsuario(
                    usuario.NombreUsuario.Trim()
                );

            if (usuarioExistente != null &&
                usuarioExistente.IdUsuario != usuario.IdUsuario)
            {
                throw new InvalidOperationException(
                    "El nombre de usuario ya pertenece a otro usuario."
                );
            }

            usuario.NombreUsuario =
                usuario.NombreUsuario.Trim();

            return _usuarioRepository.Actualizar(usuario);
        }

        public bool Eliminar(int idUsuario)
        {
            if (idUsuario <= 0)
                throw new ArgumentException(
                    "El identificador del usuario no es válido."
                );

            Usuario usuario =
                _usuarioRepository.ObtenerPorId(idUsuario);

            if (usuario == null)
                return false;

            return _usuarioRepository.Eliminar(idUsuario);
        }

        public Usuario ObtenerPorId(int idUsuario)
        {
            if (idUsuario <= 0)
                throw new ArgumentException(
                    "El identificador del usuario no es válido."
                );

            return _usuarioRepository.ObtenerPorId(idUsuario);
        }

        public List<Usuario> ObtenerTodos()
        {
            return _usuarioRepository.ObtenerTodos();
        }
    }
}
