using Proyecto1.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto1.Models
{
    public class TipoEquipo
    {
        // ==========================
        // ATRIBUTOS
        // ==========================

        private int _id;
        private string _nombre;
        private Especialidad _especialidadRequerida;

        // ==========================
        // PROPIEDADES
        // ==========================

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
                    throw new ArgumentException("El nombre del tipo de equipo no puede estar vacío.");

                _nombre = value.Trim();
            }
        }

        public Especialidad EspecialidadRequerida
        {
            get { return _especialidadRequerida; }
            set { _especialidadRequerida = value; }
        }

        // ==========================
        // CONSTRUCTORES
        // ==========================

        public TipoEquipo()
        {

        }

        public TipoEquipo(string nombre, Especialidad especialidadRequerida)
        {
            Nombre = nombre;
            EspecialidadRequerida = especialidadRequerida;
        }

       
        // MÉTODOS
       

        public override string ToString()
        {
            return Nombre;
        }
    }
}
