using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Proyecto1.Models
{
    public class MovimientoInventario
    {
        // ==========================
        // ATRIBUTOS
        // ==========================

        private int _id;
        private Material _material;
        private Ticket _ticket;
        private Tecnico _tecnico;

        private string _tipoMovimiento;
        private int _cantidad;

        private decimal _costoUnitario;

        private DateTime _fecha;

        private string _observaciones;

        // ==========================
        // PROPIEDADES
        // ==========================

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

        public Ticket Ticket
        {
            get { return _ticket; }
            set { _ticket = value; }
        }

        public Tecnico Tecnico
        {
            get { return _tecnico; }
            set { _tecnico = value; }
        }

        public string TipoMovimiento
        {
            get { return _tipoMovimiento; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Debe indicar el tipo de movimiento.");

                _tipoMovimiento = value.Trim();
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

        public DateTime Fecha
        {
            get { return _fecha; }
            set { _fecha = value; }
        }

        public string Observaciones
        {
            get { return _observaciones; }
            set
            {
                _observaciones = value?.Trim();
            }
        }

        public decimal CostoTotal
        {
            get { return Cantidad * CostoUnitario; }
        }

        // ==========================
        // CONSTRUCTORES
        // ==========================

        public MovimientoInventario()
        {
            Fecha = DateTime.Now;
            TipoMovimiento = "Salida";
        }

        public MovimientoInventario(
            Material material,
            int cantidad,
            Ticket ticket,
            Tecnico tecnico,
            decimal costoUnitario,
            string tipoMovimiento,
            string observaciones = "")
        {
            Material = material;
            Cantidad = cantidad;
            Ticket = ticket;
            Tecnico = tecnico;
            CostoUnitario = costoUnitario;
            TipoMovimiento = tipoMovimiento;
            Observaciones = observaciones;

            Fecha = DateTime.Now;
        }

        // ==========================
        // MÉTODOS
        // ==========================

        public override string ToString()
        {
            return $"{TipoMovimiento}: {Material.Nombre} ({Cantidad})";
        }
    }
}
