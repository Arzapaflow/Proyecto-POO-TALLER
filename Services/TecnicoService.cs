using Proyecto1.Models;
using Proyecto1.Models.Enums;
using Proyecto1.Repositorios;
using Proyecto1.Repositorios.Interfaces;
using Proyecto1.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Proyecto1.Services
{
    public class TecnicoService : ITecnicoService
    {
        private readonly IEmpleadoRepository _empleadoRepository;
        private readonly ITecnicoRepository _tecnicoRepository;
        private readonly IUsuarioRepository _usuarioRepository;

        public TecnicoService()
        {
            _empleadoRepository = new EmpleadoRepository();
            _tecnicoRepository = new TecnicoRepository();
            _usuarioRepository = new UsuarioRepository();
        }

        public bool Registrar(Tecnico tecnico, Usuario usuario)
        {
            if (tecnico == null)
                throw new Exception("No se recibieron los datos del técnico.");

            if (usuario == null)
                throw new Exception("No se recibieron los datos del usuario.");

            if (string.IsNullOrWhiteSpace(tecnico.Nombre))
                throw new Exception("Ingrese el nombre.");

            if (string.IsNullOrWhiteSpace(tecnico.Telefono))
                throw new Exception("Ingrese el teléfono.");

            if (string.IsNullOrWhiteSpace(tecnico.Correo))
                throw new Exception("Ingrese el correo.");

            if (string.IsNullOrWhiteSpace(usuario.NombreUsuario))
                throw new Exception("Ingrese el nombre de usuario.");

            if (string.IsNullOrWhiteSpace(usuario.Contrasena))
                throw new Exception("Ingrese la contraseña.");

            if (_usuarioRepository.ObtenerPorNombreUsuario(usuario.NombreUsuario) != null)
                throw new Exception("Ese nombre de usuario ya existe.");

            if (!_empleadoRepository.Insertar(tecnico))
                throw new Exception("No se pudo registrar el empleado.");

            if (!_tecnicoRepository.Insertar(tecnico))
                throw new Exception("No se pudo registrar el técnico.");

            usuario.IdEmpleado = tecnico.Id;
            usuario.IdRol = 3;
            usuario.Activo = true;

            if (!_usuarioRepository.Insertar(usuario))
                throw new Exception("No se pudo crear el usuario.");

            return true;
        }

        public bool Actualizar(Tecnico tecnico, Usuario usuario)
        {
            if (_idVacio(tecnico.Id))
                throw new Exception("Seleccione un técnico.");

            if (string.IsNullOrWhiteSpace(tecnico.Nombre))
                throw new Exception("Ingrese el nombre.");

            if (string.IsNullOrWhiteSpace(tecnico.Telefono))
                throw new Exception("Ingrese el teléfono.");

            if (string.IsNullOrWhiteSpace(tecnico.Correo))
                throw new Exception("Ingrese el correo.");

            if (string.IsNullOrWhiteSpace(usuario.NombreUsuario))
                throw new Exception("Ingrese el usuario.");

            if (string.IsNullOrWhiteSpace(usuario.Contrasena))
                throw new Exception("Ingrese la contraseña.");

            Usuario existente =
                _usuarioRepository.ObtenerPorNombreUsuario(usuario.NombreUsuario);

            if (existente != null &&
                existente.IdEmpleado != tecnico.Id)
            {
                throw new Exception("Ese nombre de usuario ya pertenece a otro empleado.");
            }

            _empleadoRepository.Actualizar(tecnico);

            _tecnicoRepository.Actualizar(tecnico);

            if (existente != null)
            {
                usuario.IdUsuario = existente.IdUsuario;
                usuario.IdEmpleado = tecnico.Id;
                usuario.IdRol = 3;
                usuario.Activo = true;

                _usuarioRepository.Actualizar(usuario);
            }

            return true;
        }

        public bool Eliminar(int idEmpleado)
        {
            Usuario usuario = null;

            foreach (Usuario u in _usuarioRepository.ObtenerTodos())
            {
                if (u.IdEmpleado == idEmpleado)
                {
                    usuario = u;
                    break;
                }
            }
            if (usuario != null)
                _usuarioRepository.Eliminar(usuario.IdUsuario);

            _tecnicoRepository.Eliminar(idEmpleado);

            _empleadoRepository.Eliminar(idEmpleado);

            return true;
        }
        public Tecnico ObtenerPorId(int idEmpleado)
        {
            return _tecnicoRepository.ObtenerPorId(idEmpleado);
        }
        public List<Tecnico> ObtenerTodos()
        {
            return _tecnicoRepository.ObtenerTodos();
        }
        private bool _idVacio(int id)
        {
            return id <= 0;
        }
        public List<Tecnico> ObtenerPorEspecialidad(Especialidad especialidad)
        {
            return _tecnicoRepository
                .ObtenerTodos()
                .Where(t => t.Especialidad == especialidad)
                .ToList();
        }
        
        
    }

}