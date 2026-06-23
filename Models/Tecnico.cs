using Proyecto1.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto1.Models
{
    // Hereda de empleado que a su vez hereda de persona
    public class Tecnico : Empleado
    {

        // ATRIBUTOS


        private Especialidad _especialidad;
        private decimal _pagoPorHora;
        //luego para calcular el costo de mano de obra (pago x Tiempo)

        // PROPIEDADES


        public Especialidad Especialidad
        {
            get { return _especialidad; }
            set { _especialidad = value; }
        }

        public decimal PagoPorHora
        {
            get { return _pagoPorHora; }
            internal set
            {
                if (value < 0)
                    throw new ArgumentException("El pago por hora no puede ser negativo.");

                _pagoPorHora = value;
            }
        }


        // CONSTRUCTORES


        public Tecnico()
        {
            Rol = Rol.Tecnico;
            PagoPorHora = 0;
        }

        public Tecnico(
            string nombre,
            string telefono,
            string correo,
            string usuario,
            string contraseña,
            Especialidad especialidad)
          : base(nombre, telefono, correo, usuario, contraseña, Proyecto1.Models.Enums.Rol.Tecnico)
            //Constructor que recibe de empleado Y ASIGNA EL ROL TECNICO
        {
            Rol = Rol.Tecnico;
            Especialidad = especialidad;
            PagoPorHora = 0;
        }


        // MÉTODOS


        public override string ToString()
        {
            return $"{Nombre} - {Especialidad}";
        }
    }
} 
