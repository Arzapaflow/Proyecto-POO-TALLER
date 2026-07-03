using System;
using System.Collections.Generic;
using System.Linq;
using Proyecto1.Models;
using Proyecto1.Repositorios;
using Proyecto1.Repositorios.Interfaces;
using Proyecto1.Services.Interfaces;

namespace Proyecto1.Services
{
    public class MaterialService : IMaterialService
    {
        private readonly IMaterialRepository _materialRepository;

        public MaterialService()
        {
            _materialRepository = new MaterialRepository();
        }

        public MaterialService(
            IMaterialRepository materialRepository)
        {
            if (materialRepository == null)
            {
                throw new ArgumentNullException(
                    nameof(materialRepository)
                );
            }

            _materialRepository = materialRepository;
        }

        public bool Registrar(Material material)
        {
            ValidarMaterial(material);

            List<Material> materiales =
                _materialRepository.ObtenerTodos();

            bool codigoRegistrado = materiales.Any(
                m => m.Codigo.Equals(
                    material.Codigo,
                    StringComparison.OrdinalIgnoreCase
                )
            );

            if (codigoRegistrado)
            {
                throw new InvalidOperationException(
                    "Ya existe un material registrado con ese código."
                );
            }

            return _materialRepository.Insertar(material);
        }

        public bool Actualizar(Material material)
        {
            ValidarMaterial(material);

            if (material.IdMaterial <= 0)
            {
                throw new ArgumentException(
                    "El identificador del material no es válido."
                );
            }

            Material materialExistente =
                _materialRepository.ObtenerPorId(
                    material.IdMaterial
                );

            if (materialExistente == null)
                return false;

            List<Material> materiales =
                _materialRepository.ObtenerTodos();

            bool codigoRegistrado = materiales.Any(
                m => m.IdMaterial != material.IdMaterial &&
                     m.Codigo.Equals(
                         material.Codigo,
                         StringComparison.OrdinalIgnoreCase
                     )
            );

            if (codigoRegistrado)
            {
                throw new InvalidOperationException(
                    "El código ya pertenece a otro material."
                );
            }

            return _materialRepository.Actualizar(material);
        }

        public bool Eliminar(int idMaterial)
        {
            if (idMaterial <= 0)
            {
                throw new ArgumentException(
                    "El identificador del material no es válido."
                );
            }

            Material material =
                _materialRepository.ObtenerPorId(idMaterial);

            if (material == null)
                return false;

            return _materialRepository.Eliminar(idMaterial);
        }

        public Material ObtenerPorId(int idMaterial)
        {
            if (idMaterial <= 0)
            {
                throw new ArgumentException(
                    "El identificador del material no es válido."
                );
            }

            return _materialRepository.ObtenerPorId(idMaterial);
        }

        public List<Material> ObtenerTodos()
        {
            return _materialRepository.ObtenerTodos();
        }

        public List<Material> ObtenerConStockBajo()
        {
            List<Material> materiales =
                _materialRepository.ObtenerTodos();

            return materiales
                .Where(m => m.Activo &&
                            m.Stock <= m.StockMinimo)
                .ToList();
        }

        private void ValidarMaterial(Material material)
        {
            if (material == null)
                throw new ArgumentNullException(nameof(material));

            if (string.IsNullOrWhiteSpace(material.Codigo))
            {
                throw new ArgumentException(
                    "El código del material no puede estar vacío."
                );
            }

            if (string.IsNullOrWhiteSpace(material.Nombre))
            {
                throw new ArgumentException(
                    "El nombre del material no puede estar vacío."
                );
            }

            if (material.Stock < 0)
            {
                throw new ArgumentException(
                    "El stock no puede ser negativo."
                );
            }

            if (material.StockMinimo < 0)
            {
                throw new ArgumentException(
                    "El stock mínimo no puede ser negativo."
                );
            }

            if (material.CostoUnitario < 0)
            {
                throw new ArgumentException(
                    "El costo unitario no puede ser negativo."
                );
            }

            material.Codigo = material.Codigo.Trim();
            material.Nombre = material.Nombre.Trim();

            if (material.Descripcion != null)
            {
                material.Descripcion =
                    material.Descripcion.Trim();
            }
        }
    }
}
