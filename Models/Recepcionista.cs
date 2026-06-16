using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto1.Models
{
    public class Recepcionista : Empleado
    {
        //==========================
        // CONSTRUCTORES
        //==========================

        public Recepcionista()
            : base(Proyecto1.Models.Enums.Rol.Recepcionista)
        {

        }

        public Recepcionista(
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
                  Proyecto1.Models.Enums.Rol.Recepcionista)
        {

        }
    }
}