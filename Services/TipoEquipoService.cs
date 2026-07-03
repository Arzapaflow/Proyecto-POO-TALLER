using System;
using System.Collections.Generic;
using System.Linq;
using Proyecto1.Models;
using Proyecto1.Repositorios;
using Proyecto1.Repositorios.Interfaces;
using Proyecto1.Services.Interfaces;

namespace Proyecto1.Services
{
    public class TipoEquipoService : ITipoEquipoService
    {
        private readonly ITipoEquipoRepository _tipoEquipoRepository;

        public TipoEquipoService()
        {
            _tipoEquipoRepository = new TipoEquipoRepository();
        }

        public TipoEquipoService(
            ITipoEquipoRepository tipoEquipoRepository)
        {
            if (tipoEquipoRepository == null)
            {
                throw new ArgumentNullException(
                    nameof(tipoEquipoRepository)
                );
            }

            _tipoEquipoRepository = tipoEquipoRepository;
        }

        public bool Registrar(TipoEquipo tipoEquipo)
        {
            ValidarTipoEquipo(tipoEquipo);

            List<TipoEquipo> tiposEquipo =
                _tipoEquipoRepository.ObtenerTodos();

            bool nombreRegistrado = tiposEquipo.Any(
                t => t.Nombre.Equals(
                    tipoEquipo.Nombre,
                    StringComparison.OrdinalIgnoreCase
                )
            );

            if (nombreRegistrado)
            {
                throw new InvalidOperationException(
                    "Ya existe un tipo de equipo con ese nombre."
                );
            }

            return _tipoEquipoRepository.Insertar(tipoEquipo);
        }

        public bool Actualizar(TipoEquipo tipoEquipo)
        {
            ValidarTipoEquipo(tipoEquipo);

            if (tipoEquipo.Id <= 0)
            {
                throw new ArgumentException(
                    "El identificador del tipo de equipo no es válido."
                );
            }

            TipoEquipo tipoExistente =
                _tipoEquipoRepository.ObtenerPorId(tipoEquipo.Id);

            if (tipoExistente == null)
                return false;

            List<TipoEquipo> tiposEquipo =
                _tipoEquipoRepository.ObtenerTodos();

            bool nombreRegistrado = tiposEquipo.Any(
                t => t.Id != tipoEquipo.Id &&
                     t.Nombre.Equals(
                         tipoEquipo.Nombre,
                         StringComparison.OrdinalIgnoreCase
                     )
            );

            if (nombreRegistrado)
            {
                throw new InvalidOperationException(
                    "El nombre ya pertenece a otro tipo de equipo."
                );
            }

            return _tipoEquipoRepository.Actualizar(tipoEquipo);
        }

        public bool Eliminar(int idTipoEquipo)
        {
            if (idTipoEquipo <= 0)
            {
                throw new ArgumentException(
                    "El identificador del tipo de equipo no es válido."
                );
            }

            TipoEquipo tipoEquipo =
                _tipoEquipoRepository.ObtenerPorId(idTipoEquipo);

            if (tipoEquipo == null)
                return false;

            return _tipoEquipoRepository.Eliminar(idTipoEquipo);
        }

        public TipoEquipo ObtenerPorId(int idTipoEquipo)
        {
            if (idTipoEquipo <= 0)
            {
                throw new ArgumentException(
                    "El identificador del tipo de equipo no es válido."
                );
            }

            return _tipoEquipoRepository.ObtenerPorId(idTipoEquipo);
        }

        public List<TipoEquipo> ObtenerTodos()
        {
            return _tipoEquipoRepository.ObtenerTodos();
        }

        private void ValidarTipoEquipo(TipoEquipo tipoEquipo)
        {
            if (tipoEquipo == null)
                throw new ArgumentNullException(nameof(tipoEquipo));

            if (string.IsNullOrWhiteSpace(tipoEquipo.Nombre))
            {
                throw new ArgumentException(
                    "El nombre del tipo de equipo no puede estar vacío."
                );
            }

            tipoEquipo.Nombre = tipoEquipo.Nombre.Trim();
        }
    }
}
