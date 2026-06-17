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
        private string _informacionCliente;

      
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

        public string InformacionCliente
        {
            get { return _informacionCliente; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Debe proporcionar información para el cliente.");

                _informacionCliente = value.Trim();
            }
        }

       
        // CONSTRUCTORES
      
        public Problema()
        {

        }

        public Problema(string nombre, string informacionCliente)
        {
            Nombre = nombre;
            InformacionCliente = informacionCliente;
        }


        // MÉTODOS

        //pa que no imprima todo el objeto, sino solo el nombre del problema
        public override string ToString()
        {
            return Nombre;
        }
    }
}