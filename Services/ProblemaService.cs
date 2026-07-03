using System;
using System.Collections.Generic;
using System.Linq;
using Proyecto1.Models;
using Proyecto1.Repositorios;
using Proyecto1.Repositorios.Interfaces;
using Proyecto1.Services.Interfaces;

namespace Proyecto1.Services
{
    public class ProblemaService : IProblemaService
    {
        private readonly IProblemaRepository _problemaRepository;

        public ProblemaService()
        {
            _problemaRepository = new ProblemaRepository();
        }

        public ProblemaService(
            IProblemaRepository problemaRepository)
        {
            if (problemaRepository == null)
            {
                throw new ArgumentNullException(
                    nameof(problemaRepository)
                );
            }

            _problemaRepository = problemaRepository;
        }

        public bool Registrar(Problema problema)
        {
            ValidarProblema(problema);

            List<Problema> problemas =
                _problemaRepository.ObtenerTodos();

            bool nombreRegistrado = problemas.Any(
                p => p.Nombre.Equals(
                    problema.Nombre,
                    StringComparison.OrdinalIgnoreCase
                )
            );

            if (nombreRegistrado)
            {
                throw new InvalidOperationException(
                    "Ya existe un problema registrado con ese nombre."
                );
            }

            return _problemaRepository.Insertar(problema);
        }

        public bool Actualizar(Problema problema)
        {
            ValidarProblema(problema);

            if (problema.Id <= 0)
            {
                throw new ArgumentException(
                    "El identificador del problema no es válido."
                );
            }

            Problema problemaExistente =
                _problemaRepository.ObtenerPorId(problema.Id);

            if (problemaExistente == null)
                return false;

            List<Problema> problemas =
                _problemaRepository.ObtenerTodos();

            bool nombreRegistrado = problemas.Any(
                p => p.Id != problema.Id &&
                     p.Nombre.Equals(
                         problema.Nombre,
                         StringComparison.OrdinalIgnoreCase
                     )
            );

            if (nombreRegistrado)
            {
                throw new InvalidOperationException(
                    "El nombre ya pertenece a otro problema."
                );
            }

            return _problemaRepository.Actualizar(problema);
        }

        public bool Eliminar(int idProblema)
        {
            if (idProblema <= 0)
            {
                throw new ArgumentException(
                    "El identificador del problema no es válido."
                );
            }

            Problema problema =
                _problemaRepository.ObtenerPorId(idProblema);

            if (problema == null)
                return false;

            return _problemaRepository.Eliminar(idProblema);
        }

        public Problema ObtenerPorId(int idProblema)
        {
            if (idProblema <= 0)
            {
                throw new ArgumentException(
                    "El identificador del problema no es válido."
                );
            }

            return _problemaRepository.ObtenerPorId(idProblema);
        }

        public List<Problema> ObtenerTodos()
        {
            return _problemaRepository.ObtenerTodos();
        }

        private void ValidarProblema(Problema problema)
        {
            if (problema == null)
                throw new ArgumentNullException(nameof(problema));

            if (string.IsNullOrWhiteSpace(problema.Nombre))
            {
                throw new ArgumentException(
                    "El nombre del problema no puede estar vacío."
                );
            }

            if (string.IsNullOrWhiteSpace(problema.Descripcion))
            {
                throw new ArgumentException(
                    "La descripción del problema no puede estar vacía."
                );
            }

            if (problema.CostoEstimado < 0)
            {
                throw new ArgumentException(
                    "El costo estimado no puede ser negativo."
                );
            }

            problema.Nombre = problema.Nombre.Trim();
            problema.Descripcion = problema.Descripcion.Trim();

            if (problema.PosiblesCausas != null)
            {
                problema.PosiblesCausas =
                    problema.PosiblesCausas.Trim();
            }
        }
    }
}