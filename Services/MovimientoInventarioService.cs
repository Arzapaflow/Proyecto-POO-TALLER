using System;
using System.Collections.Generic;
using Proyecto1.Models;
using Proyecto1.Repositorios;
using Proyecto1.Repositorios.Interfaces;
using Proyecto1.Services.Interfaces;

namespace Proyecto1.Services
{
    public class MovimientoInventarioService
        : IMovimientoInventarioService
    {
        private readonly IMovimientoInventarioRepository
            _movimientoRepository;

        private readonly IMaterialRepository
            _materialRepository;

        public MovimientoInventarioService()
        {
            _movimientoRepository =
                new MovimientoInventarioRepository();

            _materialRepository =
                new MaterialRepository();
        }

        public MovimientoInventarioService(
            IMovimientoInventarioRepository movimientoRepository,
            IMaterialRepository materialRepository)
        {
            if (movimientoRepository == null)
            {
                throw new ArgumentNullException(
                    nameof(movimientoRepository)
                );
            }

            if (materialRepository == null)
            {
                throw new ArgumentNullException(
                    nameof(materialRepository)
                );
            }

            _movimientoRepository = movimientoRepository;
            _materialRepository = materialRepository;
        }

        public bool Registrar(MovimientoInventario movimiento)
        {
            ValidarMovimiento(movimiento);

            Material material =
                _materialRepository.ObtenerPorId(
                    movimiento.Material.IdMaterial
                );

            if (material == null)
            {
                throw new InvalidOperationException(
                    "El material seleccionado no existe."
                );
            }

            if (!material.Activo)
            {
                throw new InvalidOperationException(
                    "No se pueden registrar movimientos " +
                    "para un material inactivo."
                );
            }

            string tipoMovimiento =
                NormalizarTipoMovimiento(
                    movimiento.TipoMovimiento
                );

            movimiento.TipoMovimiento = tipoMovimiento;

            if (tipoMovimiento == "Salida")
            {
                if (material.Stock < movimiento.Cantidad)
                {
                    throw new InvalidOperationException(
                        "No hay suficiente stock para realizar la salida."
                    );
                }

                material.Stock -= movimiento.Cantidad;
            }
            else
            {
                material.Stock += movimiento.Cantidad;
            }

            movimiento.Material = material;

            if (movimiento.Fecha == DateTime.MinValue)
            {
                movimiento.Fecha = DateTime.Now;
            }

            bool movimientoRegistrado =
                _movimientoRepository.Insertar(movimiento);

            if (!movimientoRegistrado)
                return false;

            bool stockActualizado =
                _materialRepository.Actualizar(material);

            if (!stockActualizado)
            {
                throw new InvalidOperationException(
                    "El movimiento fue registrado, pero no se pudo " +
                    "actualizar el stock del material."
                );
            }

            return true;
        }

        public MovimientoInventario ObtenerPorId(
            int idMovimiento)
        {
            if (idMovimiento <= 0)
            {
                throw new ArgumentException(
                    "El identificador del movimiento no es válido."
                );
            }

            return _movimientoRepository.ObtenerPorId(
                idMovimiento
            );
        }

        public List<MovimientoInventario> ObtenerTodos()
        {
            return _movimientoRepository.ObtenerTodos();
        }

        private void ValidarMovimiento(
            MovimientoInventario movimiento)
        {
            if (movimiento == null)
            {
                throw new ArgumentNullException(
                    nameof(movimiento)
                );
            }

            if (movimiento.Material == null ||
                movimiento.Material.IdMaterial <= 0)
            {
                throw new ArgumentException(
                    "Debe seleccionarse un material válido."
                );
            }

            if (movimiento.Cantidad <= 0)
            {
                throw new ArgumentException(
                    "La cantidad debe ser mayor que cero."
                );
            }

            if (movimiento.CostoUnitario < 0)
            {
                throw new ArgumentException(
                    "El costo unitario no puede ser negativo."
                );
            }

            if (string.IsNullOrWhiteSpace(
                movimiento.TipoMovimiento))
            {
                throw new ArgumentException(
                    "Debe indicarse el tipo de movimiento."
                );
            }

            if (movimiento.Observaciones != null)
            {
                movimiento.Observaciones =
                    movimiento.Observaciones.Trim();
            }
        }

        private string NormalizarTipoMovimiento(
            string tipoMovimiento)
        {
            string tipo =
                tipoMovimiento.Trim().ToLowerInvariant();

            if (tipo == "entrada")
                return "Entrada";

            if (tipo == "salida")
                return "Salida";

            throw new ArgumentException(
                "El tipo de movimiento debe ser Entrada o Salida."
            );
        }
    }
}
