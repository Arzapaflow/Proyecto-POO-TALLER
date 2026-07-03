using System;
using System.Collections.Generic;
using System.Linq;
using Proyecto1.Models;
using Proyecto1.Models.Enums;
using Proyecto1.Repositorios;
using Proyecto1.Repositorios.Interfaces;
using Proyecto1.Services.Interfaces;

namespace Proyecto1.Services
{
    public class TecnicoService : ITecnicoService
    {
        private readonly ITecnicoRepository _tecnicoRepository;

        public TecnicoService()
        {
            _tecnicoRepository = new TecnicoRepository();
        }

        public TecnicoService(
            ITecnicoRepository tecnicoRepository)
        {
            if (tecnicoRepository == null)
            {
                throw new ArgumentNullException(
                    nameof(tecnicoRepository)
                );
            }

            _tecnicoRepository = tecnicoRepository;
        }

        public bool Registrar(Tecnico tecnico)
        {
            ValidarTecnico(tecnico);

            List<Tecnico> tecnicos =
                _tecnicoRepository.ObtenerTodos();

            bool correoRegistrado = tecnicos.Any(
                t => t.Correo.Equals(
                    tecnico.Correo,
                    StringComparison.OrdinalIgnoreCase
                )
            );

            if (correoRegistrado)
            {
                throw new InvalidOperationException(
                    "Ya existe un técnico registrado con ese correo."
                );
            }

            return _tecnicoRepository.Insertar(tecnico);
        }

        public bool Actualizar(Tecnico tecnico)
        {
            ValidarTecnico(tecnico);

            if (tecnico.Id <= 0)
            {
                throw new ArgumentException(
                    "El identificador del técnico no es válido."
                );
            }

            Tecnico tecnicoExistente =
                _tecnicoRepository.ObtenerPorId(tecnico.Id);

            if (tecnicoExistente == null)
                return false;

            List<Tecnico> tecnicos =
                _tecnicoRepository.ObtenerTodos();

            bool correoRegistrado = tecnicos.Any(
                t => t.Id != tecnico.Id &&
                     t.Correo.Equals(
                         tecnico.Correo,
                         StringComparison.OrdinalIgnoreCase
                     )
            );

            if (correoRegistrado)
            {
                throw new InvalidOperationException(
                    "El correo ya pertenece a otro técnico."
                );
            }

            return _tecnicoRepository.Actualizar(tecnico);
        }

        public bool Eliminar(int idEmpleado)
        {
            if (idEmpleado <= 0)
            {
                throw new ArgumentException(
                    "El identificador del técnico no es válido."
                );
            }

            Tecnico tecnico =
                _tecnicoRepository.ObtenerPorId(idEmpleado);

            if (tecnico == null)
                return false;

            return _tecnicoRepository.Eliminar(idEmpleado);
        }

        public Tecnico ObtenerPorId(int idEmpleado)
        {
            if (idEmpleado <= 0)
            {
                throw new ArgumentException(
                    "El identificador del técnico no es válido."
                );
            }

            return _tecnicoRepository.ObtenerPorId(idEmpleado);
        }

        public List<Tecnico> ObtenerTodos()
        {
            return _tecnicoRepository.ObtenerTodos();
        }

        private void ValidarTecnico(Tecnico tecnico)
        {
            if (tecnico == null)
            {
                throw new ArgumentNullException(
                    nameof(tecnico)
                );
            }

            if (string.IsNullOrWhiteSpace(tecnico.Nombre))
            {
                throw new ArgumentException(
                    "El nombre del técnico no puede estar vacío."
                );
            }

            if (string.IsNullOrWhiteSpace(tecnico.Telefono))
            {
                throw new ArgumentException(
                    "El teléfono del técnico no puede estar vacío."
                );
            }

            if (string.IsNullOrWhiteSpace(tecnico.Correo))
            {
                throw new ArgumentException(
                    "El correo del técnico no puede estar vacío."
                );
            }

            if (!Enum.IsDefined(
                typeof(Especialidad),
                tecnico.Especialidad))
            {
                throw new ArgumentException(
                    "La especialidad seleccionada no es válida."
                );
            }

            if (tecnico.PagoPorHora < 0)
            {
                throw new ArgumentException(
                    "El pago por hora no puede ser negativo."
                );
            }

            tecnico.Nombre = tecnico.Nombre.Trim();
            tecnico.Telefono = tecnico.Telefono.Trim();
            tecnico.Correo = tecnico.Correo.Trim();
        }
    }
}