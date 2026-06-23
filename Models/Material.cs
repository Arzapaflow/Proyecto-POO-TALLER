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
       

        private int _id;
        private string _nombre;
        private string _descripcion;
        private int _cantidadDisponible;
        private int _stockMinimo;
        private decimal _costoUnitario;

       
        // PROPIEDADES
     

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public string Nombre
        {
            get { return _nombre; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("El nombre del material no puede estar vacío.");

                _nombre = value.Trim();
            }
        }

        public string Descripcion
        {
            get { return _descripcion; }
            set
            {
                _descripcion = value?.Trim();
            }
        }

        public int CantidadDisponible
        {
            get { return _cantidadDisponible; }
            set
            {
                if (value < 0)
                    throw new ArgumentException("La cantidad disponible no puede ser negativa.");

                _cantidadDisponible = value;
            }
        }

        public int StockMinimo
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


        // CONSTRUCTORES
     

        public Material()
        {

        }

        public Material(
            string nombre,
            string descripcion,
            int cantidadDisponible,
            int stockMinimo,
            decimal costoUnitario)
        {
            Nombre = nombre;
            Descripcion = descripcion;
            CantidadDisponible = cantidadDisponible;
            StockMinimo = stockMinimo;
            CostoUnitario = costoUnitario;
        }

       
        // MÉTODOS
       

        public override string ToString()
        {
            return $"{Nombre} ({CantidadDisponible} disponibles)";
        }
    }
}
