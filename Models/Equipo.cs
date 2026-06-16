using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto1.Models
{
    public class Equipo
    {
       
        // ATRIBUTOS
    

        private int _id;
        private Cliente _cliente;
        private TipoEquipo _tipoEquipo;
        private string _marca;
        private string _modelo;
        private string _color;

        // PROPIEDADES
        

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public Cliente Cliente
        {
            get { return _cliente; }
            set
            {
                if (value == null)
                    throw new ArgumentNullException(nameof(Cliente), "Debe asignarse un cliente al equipo.");

                _cliente = value;
            }
        }

        public TipoEquipo TipoEquipo
        {
            get { return _tipoEquipo; }
            set
            {
                if (value == null)
                    throw new ArgumentNullException(nameof(TipoEquipo), "Debe asignarse un tipo de equipo.");

                _tipoEquipo = value;
            }
        }

        public string Marca
        {
            get { return _marca; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("La marca no puede estar vacía.");

                _marca = value.Trim();
            }
        }

        public string Modelo
        {
            get { return _modelo; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("El modelo no puede estar vacío.");

                _modelo = value.Trim();
            }
        }

        public string Color
        {
            get { return _color; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("El color no puede estar vacío.");

                _color = value.Trim();
            }
        }

       
        // CONSTRUCTORES
    

        public Equipo()
        {

        }

        public Equipo(
            Cliente cliente,
            TipoEquipo tipoEquipo,
            string marca,
            string modelo,
            string color)
        {
            Cliente = cliente;
            TipoEquipo = tipoEquipo;
            Marca = marca;
            Modelo = modelo;
            Color = color;
        }

      
        // MÉTODOS
     

        public override string ToString()
        {
            return $"{Marca} {Modelo} ({Color})";
        }
    }
}
