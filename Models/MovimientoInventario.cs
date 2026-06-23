using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto1.Models
{

    public class MovimientoInventario
    {
     
        // ATRIBUTOS
  

        private int _id;
        private Material _material;
        private int _cantidad;
        private DateTime _fecha;
        private Ticket _ticket;
        private Tecnico _tecnico;
        private decimal _costoUnitario;

 
        // PROPIEDADES
   

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public Material Material
        {
            get { return _material; }
            set
            {
                if (value == null)
                    throw new ArgumentNullException(nameof(Material));

                _material = value;
            }
        }

        public int Cantidad
        {
            get { return _cantidad; }
            set
            {
                if (value <= 0)
                    throw new ArgumentException("La cantidad debe ser mayor a cero.");

                _cantidad = value;
            }
        }

        public DateTime Fecha
        {
            get { return _fecha; }
            private set { _fecha = value; }
        }

        public Ticket Ticket
        {
            get { return _ticket; }
            set
            {
                if (value == null)
                    throw new ArgumentNullException(nameof(Ticket));

                _ticket = value;
            }
        }

        public Tecnico Tecnico
        {
            get { return _tecnico; }
            set
            {
                if (value == null)
                    throw new ArgumentNullException(nameof(Tecnico));

                _tecnico = value;
            }
        }

        public decimal CostoUnitario
        {
            get { return _costoUnitario; }
            set
            {
                if (value < 0)
                    throw new ArgumentException("El costo unitario no puede ser negativo.");

                _costoUnitario = value;
            }
        }

   
        // Operación costo
    

        public decimal CostoTotal
        {
            get { return Cantidad * CostoUnitario; }
        }

      
        // CONSTRUCTORES
        

        public MovimientoInventario()
        {
            Fecha = DateTime.Now; //Para que se vea cuando se hizo el movimiento
        }

        public MovimientoInventario(
            Material material,
            int cantidad,
            Ticket ticket,
            Tecnico tecnico,
            decimal costoUnitario)
        {
            Material = material;
            Cantidad = cantidad;
            Ticket = ticket;
            Tecnico = tecnico;
            CostoUnitario = costoUnitario;

            Fecha = DateTime.Now;  
        }

       
        // MÉTODOS
        

        public override string ToString()
        {
            return $"{Material.Nombre} - {Cantidad} unidades";
        }
    }
}
