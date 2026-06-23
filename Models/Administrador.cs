using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Proyecto1.Models.Enums;

namespace Proyecto1.Models
{
    public class Administrador : Empleado
    {
       
        // CONSTRUCTOR
        

        public Administrador() : base()
        {

        }

        public Administrador(
            string nombre,
            string telefono,
            string correo,
            string usuario,
            string contraseña)
            : base(
                nombre,
                telefono,
                correo,
                usuario,
                contraseña,
                Proyecto1.Models.Enums.Rol.Administrador)
        {

        }

      // MÉTODOS
       

        public override string ToString()
        {
            return $"{Nombre} - Administrador";
        }
    }
}
