using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Proyecto1.Models
{
    public class Material
    {
        //siempre háganlo en ese orden, está más fácil de hacer debug así, primero los atributos, luego las propiedades, luego los constructores y finalmente los métodos
        // ATRIBUTOS

        private int _idMaterial;
        private string _codigo;
        private string _nombre;
        private string _descripcion;
        private decimal _stock;
        private decimal _stockMinimo;
        private decimal _costoUnitario;
        private bool _activo;

        // PROPIEDADES

        public int IdMaterial
        {
            get { return _idMaterial; }
            set { _idMaterial = value; }
        }

        public string Codigo
        {
            get { return _codigo; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("El código no puede estar vacío.");

                _codigo = value.Trim();
            }
        }

        public string Nombre
        {
            get { return _nombre; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("El nombre no puede estar vacío.");

                _nombre = value.Trim();
            }
        }

        public string Descripcion
        {
            get { return _descripcion; }
            set { _descripcion = value?.Trim(); }
        }

        public decimal Stock
        {
            get { return _stock; }
            set
            {
                if (value < 0)
                    throw new ArgumentException("El stock no puede ser negativo.");

                _stock = value;
            }
        }

        public decimal StockMinimo
        {
            get { return _stockMinimo; }
            set
            {
                if (value < 0)
                    throw new ArgumentException("El stock mínimo no puede ser negativo.");

                _stockMinimo = value;
            }
        }

        public decimal CostoUnitario
        {
            get { return _costoUnitario; }
            set
            {
                if (value < 0)
                    throw new ArgumentException("El costo unitario no puede ser negativo.");

                _costoUnitario = value;
            }
        }

        public bool Activo
        {
            get { return _activo; }
            set { _activo = value; }
        }

        // CONSTRUCTORES

        public Material()
        {
        }

        public Material(string codigo, string nombre, string descripcion,
                        decimal stock, decimal stockMinimo,
                        decimal costoUnitario, bool activo = true)
        {
            Codigo = codigo;
            Nombre = nombre;
            Descripcion = descripcion;
            Stock = stock;
            StockMinimo = stockMinimo;
            CostoUnitario = costoUnitario;
            Activo = activo;
        }

        // MÉTODOS

        public override string ToString()
        {
            return $"{Codigo} - {Nombre}";
        }
    }
}