using System;
using System.Collections.Generic;
using System.Linq;
using Proyecto1.Models;
using Proyecto1.Repositorios;
using Proyecto1.Repositorios.Interfaces;
using Proyecto1.Services.Interfaces;

namespace Proyecto1.Services
{
    public class AdministradorService : IAdministradorService
    {
        private readonly IAdministradorRepository
            _administradorRepository;

        public AdministradorService()
        {
            _administradorRepository =
                new AdministradorRepository();
        }

        public AdministradorService(
            IAdministradorRepository administradorRepository)
        {
            if (administradorRepository == null)
            {
                throw new ArgumentNullException(
                    nameof(administradorRepository)
                );
            }

            _administradorRepository =
                administradorRepository;
        }

        public bool Registrar(
            Administrador administrador)
        {
            ValidarAdministrador(administrador);

            List<Administrador> administradores =
                _administradorRepository.ObtenerTodos();

            bool correoRegistrado =
                administradores.Any(
                    a => a.Correo.Equals(
                        administrador.Correo,
                        StringComparison.OrdinalIgnoreCase
                    )
                );

            if (correoRegistrado)
            {
                throw new InvalidOperationException(
                    "Ya existe un administrador registrado " +
                    "con ese correo."
                );
            }

            return _administradorRepository.Insertar(
                administrador
            );
        }

        public bool Actualizar(
            Administrador administrador)
        {
            ValidarAdministrador(administrador);

            if (administrador.Id <= 0)
            {
                throw new ArgumentException(
                    "El identificador del administrador " +
                    "no es válido."
                );
            }

            Administrador administradorExistente =
                _administradorRepository.ObtenerPorId(
                    administrador.Id
                );

            if (administradorExistente == null)
                return false;

            List<Administrador> administradores =
                _administradorRepository.ObtenerTodos();

            bool correoRegistrado =
                administradores.Any(
                    a => a.Id != administrador.Id &&
                         a.Correo.Equals(
                             administrador.Correo,
                             StringComparison.OrdinalIgnoreCase
                         )
                );

            if (correoRegistrado)
            {
                throw new InvalidOperationException(
                    "El correo ya pertenece a otro administrador."
                );
            }

            return _administradorRepository.Actualizar(
                administrador
            );
        }

        public bool Eliminar(int idEmpleado)
        {
            if (idEmpleado <= 0)
            {
                throw new ArgumentException(
                    "El identificador del administrador " +
                    "no es válido."
                );
            }

            Administrador administrador =
                _administradorRepository.ObtenerPorId(
                    idEmpleado
                );

            if (administrador == null)
                return false;

            return _administradorRepository.Eliminar(
                idEmpleado
            );
        }

        public Administrador ObtenerPorId(
            int idEmpleado)
        {
            if (idEmpleado <= 0)
            {
                throw new ArgumentException(
                    "El identificador del administrador " +
                    "no es válido."
                );
            }

            return _administradorRepository.ObtenerPorId(
                idEmpleado
            );
        }

        public List<Administrador> ObtenerTodos()
        {
            return _administradorRepository.ObtenerTodos();
        }

        private void ValidarAdministrador(
            Administrador administrador)
        {
            if (administrador == null)
            {
                throw new ArgumentNullException(
                    nameof(administrador)
                );
            }

            if (string.IsNullOrWhiteSpace(
                administrador.Nombre))
            {
                throw new ArgumentException(
                    "El nombre del administrador " +
                    "no puede estar vacío."
                );
            }

            if (string.IsNullOrWhiteSpace(
                administrador.Telefono))
            {
                throw new ArgumentException(
                    "El teléfono del administrador " +
                    "no puede estar vacío."
                );
            }

            if (string.IsNullOrWhiteSpace(
                administrador.Correo))
            {
                throw new ArgumentException(
                    "El correo del administrador " +
                    "no puede estar vacío."
                );
            }

            administrador.Nombre =
                administrador.Nombre.Trim();

            administrador.Telefono =
                administrador.Telefono.Trim();

            administrador.Correo =
                administrador.Correo.Trim();
        }
    }
}