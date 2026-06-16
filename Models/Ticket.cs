using Proyecto1.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto1.Models
{
    public class Ticket
    {
        // ==========================
        // ATRIBUTOS
        // ==========================

        private int _id;
        private string _folio;
        private Equipo _equipo;
        private Problema _falla;
        private string _observacionesCliente;
        private DateTime _fechaIngreso;
        private DateTime? _fechaEntrega;
        private EstadoTicket _estado;
        private string _diagnostico;

        // Se agregará cuando exista la clase Tecnico
        // private Tecnico _tecnico;

        private double _tiempoInvertido;
        private decimal _costoMateriales;

        // ==========================
        // PROPIEDADES
        // ==========================

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public string Folio
        {
            get { return _folio; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("El folio no puede estar vacío.");

                _folio = value.Trim();
            }
        }

        public Equipo Equipo
        {
            get { return _equipo; }
            set
            {
                if (value == null)
                    throw new ArgumentNullException(nameof(Equipo));

                _equipo = value;
            }
        }

        public Problema Falla
        {
            get { return _falla; }
            set
            {
                if (value == null)
                    throw new ArgumentNullException(nameof(Falla));

                _falla = value;
            }
        }

        public string ObservacionesCliente
        {
            get { return _observacionesCliente; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Las observaciones no pueden estar vacías.");

                _observacionesCliente = value.Trim();
            }
        }

        public DateTime FechaIngreso
        {
            get { return _fechaIngreso; }
            private set { _fechaIngreso = value; }
        }

        public DateTime? FechaEntrega
        {
            get { return _fechaEntrega; }
            set { _fechaEntrega = value; }
        }

        public EstadoTicket Estado
        {
            get { return _estado; }
            set { _estado = value; }
        }

        public string Diagnostico
        {
            get { return _diagnostico; }
            set
            {
                _diagnostico = value;
            }
        }

        public double TiempoInvertido
        {
            get { return _tiempoInvertido; }
            set
            {
                if (value < 0)
                    throw new ArgumentException("El tiempo invertido no puede ser negativo.");

                _tiempoInvertido = value;
            }
        }

        public decimal CostoMateriales
        {
            get { return _costoMateriales; }
            set
            {
                if (value < 0)
                    throw new ArgumentException("El costo de materiales no puede ser negativo.");

                _costoMateriales = value;
            }
        }

        // ==========================
        // CONSTRUCTORES
        // ==========================

        public Ticket()
        {
            FechaIngreso = DateTime.Now;
            Estado = EstadoTicket.EnEspera;
            TiempoInvertido = 0;
            CostoMateriales = 0;
        }

        public Ticket(
            string folio,
            Equipo equipo,
            Problema falla,
            string observacionesCliente)
        {
            Folio = folio;
            Equipo = equipo;
            Falla = falla;
            ObservacionesCliente = observacionesCliente;

            FechaIngreso = DateTime.Now;
            Estado = EstadoTicket.EnEspera;

            TiempoInvertido = 0;
            CostoMateriales = 0;
        }

        // ==========================
        // MÉTODOS
        // ==========================

        public override string ToString()
        {
            return $"{Folio} - {Equipo}";
        }
    }
}