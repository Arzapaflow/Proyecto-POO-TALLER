using System;
using System.Collections.Generic;
using Proyecto1.Models;
using Proyecto1.Repositorios;
using Proyecto1.Repositorios.Interfaces;
using Proyecto1.Services.Interfaces;

namespace Proyecto1.Services
{
    public class EquipoService : IEquipoService
    {
        private readonly IEquipoRepository _equipoRepository;
        private readonly IClienteRepository _clienteRepository;
        private readonly ITipoEquipoRepository _tipoEquipoRepository;

        public EquipoService()
        {
            _equipoRepository = new EquipoRepository();
            _clienteRepository = new ClienteRepository();
            _tipoEquipoRepository = new TipoEquipoRepository();
        }

        public EquipoService(
            IEquipoRepository equipoRepository,
            IClienteRepository clienteRepository,
            ITipoEquipoRepository tipoEquipoRepository)
        {
            if (equipoRepository == null)
                throw new ArgumentNullException(nameof(equipoRepository));

            if (clienteRepository == null)
                throw new ArgumentNullException(nameof(clienteRepository));

            if (tipoEquipoRepository == null)
                throw new ArgumentNullException(nameof(tipoEquipoRepository));

            _equipoRepository = equipoRepository;
            _clienteRepository = clienteRepository;
            _tipoEquipoRepository = tipoEquipoRepository;
        }

        public bool Registrar(Equipo equipo)
        {
            ValidarEquipo(equipo);

            Cliente cliente =
                _clienteRepository.ObtenerPorId(equipo.Cliente.Id);

            if (cliente == null)
            {
                throw new InvalidOperationException(
                    "El cliente asignado al equipo no existe."
                );
            }

            TipoEquipo tipoEquipo =
                _tipoEquipoRepository.ObtenerPorId(
                    equipo.TipoEquipo.Id
                );

            if (tipoEquipo == null)
            {
                throw new InvalidOperationException(
                    "El tipo de equipo seleccionado no existe."
                );
            }

            return _equipoRepository.Insertar(equipo);
        }

        public bool Actualizar(Equipo equipo)
        {
            ValidarEquipo(equipo);

            if (equipo.Id <= 0)
            {
                throw new ArgumentException(
                    "El identificador del equipo no es válido."
                );
            }

            Equipo equipoExistente =
                _equipoRepository.ObtenerPorId(equipo.Id);

            if (equipoExistente == null)
                return false;

            Cliente cliente =
                _clienteRepository.ObtenerPorId(equipo.Cliente.Id);

            if (cliente == null)
            {
                throw new InvalidOperationException(
                    "El cliente asignado al equipo no existe."
                );
            }

            TipoEquipo tipoEquipo =
                _tipoEquipoRepository.ObtenerPorId(
                    equipo.TipoEquipo.Id
                );

            if (tipoEquipo == null)
            {
                throw new InvalidOperationException(
                    "El tipo de equipo seleccionado no existe."
                );
            }

            return _equipoRepository.Actualizar(equipo);
        }

        public bool Eliminar(int idEquipo)
        {
            if (idEquipo <= 0)
            {
                throw new ArgumentException(
                    "El identificador del equipo no es válido."
                );
            }

            Equipo equipo =
                _equipoRepository.ObtenerPorId(idEquipo);

            if (equipo == null)
                return false;

            return _equipoRepository.Eliminar(idEquipo);
        }

        public Equipo ObtenerPorId(int idEquipo)
        {
            if (idEquipo <= 0)
            {
                throw new ArgumentException(
                    "El identificador del equipo no es válido."
                );
            }

            Equipo equipo =
                _equipoRepository.ObtenerPorId(idEquipo);

            if (equipo == null)
                return null;

            equipo.Cliente =
                _clienteRepository.ObtenerPorId(
                    equipo.Cliente.Id
                );

            equipo.TipoEquipo =
                _tipoEquipoRepository.ObtenerPorId(
                    equipo.TipoEquipo.Id
                );

            return equipo;
        }

        public List<Equipo> ObtenerTodos()
        {
            List<Equipo> equipos =
                _equipoRepository.ObtenerTodos();

            foreach (Equipo equipo in equipos)
            {
                equipo.Cliente =
                    _clienteRepository.ObtenerPorId(
                        equipo.Cliente.Id
                    );

                equipo.TipoEquipo =
                    _tipoEquipoRepository.ObtenerPorId(
                        equipo.TipoEquipo.Id
                    );
            }

            return equipos;
        }

        private void ValidarEquipo(Equipo equipo)
        {
            if (equipo == null)
                throw new ArgumentNullException(nameof(equipo));

            if (equipo.Cliente == null ||
                equipo.Cliente.Id <= 0)
            {
                throw new ArgumentException(
                    "Debe asignarse un cliente válido al equipo."
                );
            }

            if (equipo.TipoEquipo == null ||
                equipo.TipoEquipo.Id <= 0)
            {
                throw new ArgumentException(
                    "Debe asignarse un tipo de equipo válido."
                );
            }

            if (string.IsNullOrWhiteSpace(equipo.Marca))
            {
                throw new ArgumentException(
                    "La marca del equipo no puede estar vacía."
                );
            }

            if (string.IsNullOrWhiteSpace(equipo.Modelo))
            {
                throw new ArgumentException(
                    "El modelo del equipo no puede estar vacío."
                );
            }

            if (string.IsNullOrWhiteSpace(equipo.Color))
            {
                throw new ArgumentException(
                    "El color del equipo no puede estar vacío."
                );
            }

            equipo.Marca = equipo.Marca.Trim();
            equipo.Modelo = equipo.Modelo.Trim();
            equipo.Color = equipo.Color.Trim();

            if (equipo.NumeroSerie != null)
                equipo.NumeroSerie = equipo.NumeroSerie.Trim();

            if (equipo.Accesorios != null)
                equipo.Accesorios = equipo.Accesorios.Trim();

            if (equipo.Observaciones != null)
                equipo.Observaciones =
                    equipo.Observaciones.Trim();
        }
    }
}
