using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto1.Models
{

    public class Cliente : Persona
    {
      
        // CONSTRUCTORES
   

        public Cliente()
            : base()
        {

        }

        public Cliente(
            string nombre,
            string telefono,
            string correo)
            : base(nombre, telefono, correo)
        {

        }
    }
}
//comentario de prueba