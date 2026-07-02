using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Proyecto1.Models
{
    public class Problema
    {
        
        // ATRIBUTOS
        

        private int _id;
        private string _nombre;
        private string _descripcion;
        private string _posiblesCausas;
        private decimal _costoEstimado;
        private bool _activo;

        
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
                    throw new ArgumentException("El nombre del problema no puede estar vacío.");

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

        public string PosiblesCausas
        {
            get { return _posiblesCausas; }
            set
            {
                _posiblesCausas = value?.Trim();
            }
        }

        public decimal CostoEstimado
        {
            get { return _costoEstimado; }
            set
            {
                if (value < 0)
                    throw new ArgumentException("El costo estimado no puede ser negativo.");

                _costoEstimado = value;
            }
        }

        public bool Activo
        {
            get { return _activo; }
            set { _activo = value; }
        }

        
        // CONSTRUCTORES
        

        public Problema()
        {
            Activo = true;
            CostoEstimado = 0;
        }

        public Problema(
            string nombre,
            string descripcion,
            string posiblesCausas,
            decimal costoEstimado,
            bool activo = true)
        {
            Nombre = nombre;
            Descripcion = descripcion;
            PosiblesCausas = posiblesCausas;
            CostoEstimado = costoEstimado;
            Activo = activo;
        }

        
        // MÉTODOS
        

        public override string ToString()
        {
            return Nombre;
        }
    }
}