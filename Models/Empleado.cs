using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using Proyecto1.Models.Enums;

namespace Proyecto1.Models
{

    public class Empleado : Persona
    {
        // ==========================
        // ATRIBUTOS
        // ==========================

        private string _usuario;
        private string _contraseña;
        private Rol _rol;
        private EstadoEmpleado _estado;
        private DateTime _fechaIngreso;

      
        // PROPIEDADES
      

        public string Usuario
        {
            get { return _usuario; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("El usuario no puede estar vacío.");

                _usuario = value.Trim();
            }
        }

        public string Contraseña
        {
            get { return _contraseña; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("La contraseña no puede estar vacía.");

                _contraseña = value;
            }
        }

        public Rol Rol
        {
            get { return _rol; }
            protected set
                // Solo sus hijas pueden acceder (Por eso técnico daba problemas)
            {
                _rol = value;
            }
        }

        public EstadoEmpleado Estado
        {
            get { return _estado; }
            set
            {
                _estado = value;
            }
        }

        public DateTime FechaIngreso
        {
            get { return _fechaIngreso; }
            private set
            {
                _fechaIngreso = value;
            }
        }

     
        // CONSTRUCTORES
  

        public Empleado()
        {
            Estado = EstadoEmpleado.Activo;
            FechaIngreso = DateTime.Now;
        }

        public Empleado(
            string nombre,
            string telefono,
            string correo,
            string usuario,
            string contraseña,
            Rol rol)
            : base(nombre, telefono, correo)
        {
            Usuario = usuario;
            Contraseña = contraseña;
            Rol = rol;

            Estado = EstadoEmpleado.Activo;
            FechaIngreso = DateTime.Now;
        }

       
        // MÉTODOS
       

        public override string ToString()
        {
            return $"{Nombre} ({Rol})";
        }
    }
}