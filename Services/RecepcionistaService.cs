using System;
using System.Collections.Generic;
using System.Linq;
using Proyecto1.Models;
using Proyecto1.Repositorios;
using Proyecto1.Repositorios.Interfaces;
using Proyecto1.Services.Interfaces;

namespace Proyecto1.Services
{
    public class RecepcionistaService : IRecepcionistaService
    {
        private readonly IRecepcionistaRepository
            _recepcionistaRepository;

        public RecepcionistaService()
        {
            _recepcionistaRepository =
                new RecepcionistaRepository();
        }

        public RecepcionistaService(
            IRecepcionistaRepository recepcionistaRepository)
        {
            if (recepcionistaRepository == null)
            {
                throw new ArgumentNullException(
                    nameof(recepcionistaRepository)
                );
            }

            _recepcionistaRepository =
                recepcionistaRepository;
        }

        public bool Registrar(
            Recepcionista recepcionista)
        {
            ValidarRecepcionista(recepcionista);

            List<Recepcionista> recepcionistas =
                _recepcionistaRepository.ObtenerTodos();

            bool correoRegistrado =
                recepcionistas.Any(
                    r => r.Correo.Equals(
                        recepcionista.Correo,
                        StringComparison.OrdinalIgnoreCase
                    )
                );

            if (correoRegistrado)
            {
                throw new InvalidOperationException(
                    "Ya existe un recepcionista registrado " +
                    "con ese correo."
                );
            }

            return _recepcionistaRepository.Insertar(
                recepcionista
            );
        }

        public bool Actualizar(
            Recepcionista recepcionista)
        {
            ValidarRecepcionista(recepcionista);

            if (recepcionista.Id <= 0)
            {
                throw new ArgumentException(
                    "El identificador del recepcionista " +
                    "no es válido."
                );
            }

            Recepcionista recepcionistaExistente =
                _recepcionistaRepository.ObtenerPorId(
                    recepcionista.Id
                );

            if (recepcionistaExistente == null)
                return false;

            List<Recepcionista> recepcionistas =
                _recepcionistaRepository.ObtenerTodos();

            bool correoRegistrado =
                recepcionistas.Any(
                    r => r.Id != recepcionista.Id &&
                         r.Correo.Equals(
                             recepcionista.Correo,
                             StringComparison.OrdinalIgnoreCase
                         )
                );

            if (correoRegistrado)
            {
                throw new InvalidOperationException(
                    "El correo ya pertenece a otro " +
                    "recepcionista."
                );
            }

            return _recepcionistaRepository.Actualizar(
                recepcionista
            );
        }

        public bool Eliminar(int idEmpleado)
        {
            if (idEmpleado <= 0)
            {
                throw new ArgumentException(
                    "El identificador del recepcionista " +
                    "no es válido."
                );
            }

            Recepcionista recepcionista =
                _recepcionistaRepository.ObtenerPorId(
                    idEmpleado
                );

            if (recepcionista == null)
                return false;

            return _recepcionistaRepository.Eliminar(
                idEmpleado
            );
        }

        public Recepcionista ObtenerPorId(
            int idEmpleado)
        {
            if (idEmpleado <= 0)
            {
                throw new ArgumentException(
                    "El identificador del recepcionista " +
                    "no es válido."
                );
            }

            return _recepcionistaRepository.ObtenerPorId(
                idEmpleado
            );
        }

        public List<Recepcionista> ObtenerTodos()
        {
            return _recepcionistaRepository.ObtenerTodos();
        }

        private void ValidarRecepcionista(
            Recepcionista recepcionista)
        {
            if (recepcionista == null)
            {
                throw new ArgumentNullException(
                    nameof(recepcionista)
                );
            }

            if (string.IsNullOrWhiteSpace(
                recepcionista.Nombre))
            {
                throw new ArgumentException(
                    "El nombre del recepcionista " +
                    "no puede estar vacío."
                );
            }

            if (string.IsNullOrWhiteSpace(
                recepcionista.Telefono))
            {
                throw new ArgumentException(
                    "El teléfono del recepcionista " +
                    "no puede estar vacío."
                );
            }

            if (string.IsNullOrWhiteSpace(
                recepcionista.Correo))
            {
                throw new ArgumentException(
                    "El correo del recepcionista " +
                    "no puede estar vacío."
                );
            }

            recepcionista.Nombre =
                recepcionista.Nombre.Trim();

            recepcionista.Telefono =
                recepcionista.Telefono.Trim();

            recepcionista.Correo =
                recepcionista.Correo.Trim();
        }
    }
}
