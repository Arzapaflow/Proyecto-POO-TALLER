using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto1.Models
{
    public abstract class Persona
    {
       
        // ATRIBUTOS
        

        private int _id;
        private string _nombre;
        private string _telefono;
        private string _correo;

        
        // Lo que tienen todas las personas por definición (Importante) de aqui se pasan a todas las personas
       

        public int Id
        {
            get { return _id; }
            protected set { _id = value; }
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

        public string Telefono
        {
            get { return _telefono; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("El teléfono no puede estar vacío.");

                _telefono = value.Trim();
            }
        }

        public string Correo
        {
            get { return _correo; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("El correo no puede estar vacío.");

                _correo = value.Trim();
            }
        }


        // CONSTRUCTORES
        // "protected" para que solo puedan ser instanciados a través de clases que salen de esta (Cliente, Empleado)

        protected Persona()
        {

        }

        protected Persona(string nombre, string telefono, string correo)
        {
            Nombre = nombre;
            Telefono = telefono;
            Correo = correo;
        }

      
        // MÉTODOS
     
        public override string ToString()
        {
            return $"{Nombre} - {Telefono}";
        }
    }
}