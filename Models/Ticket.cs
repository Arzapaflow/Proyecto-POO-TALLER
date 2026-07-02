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
        private Problema _problema;
        private Recepcionista _recepcionista;
        private Tecnico _tecnicoAsignado;

        private string _descripcionFalla;
        private string _diagnostico;
        private string _solucionAplicada;
        private string _prioridad;
        private string _observaciones;

        private DateTime _fechaIngreso;
        private DateTime? _fechaAsignacionTecnico;
        private DateTime? _fechaEntrega;

        private EstadoTicket _estado;

        private decimal _costoEstimado;
        private decimal _costoFinal;
        private int _garantiaDias;

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

        public Problema Problema
        {
            get { return _problema; }
            set
            {
                if (value == null)
                    throw new ArgumentNullException(nameof(Problema));

                _problema = value;
            }
        }

        public Recepcionista Recepcionista
        {
            get { return _recepcionista; }
            set
            {
                if (value == null)
                    throw new ArgumentNullException(nameof(Recepcionista));

                _recepcionista = value;
            }
        }

        public Tecnico TecnicoAsignado
        {
            get { return _tecnicoAsignado; }
            set { _tecnicoAsignado = value; }
        }

        public string DescripcionFalla
        {
            get { return _descripcionFalla; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("La descripción de la falla no puede estar vacía.");

                _descripcionFalla = value.Trim();
            }
        }

        public string Diagnostico
        {
            get { return _diagnostico; }
            set { _diagnostico = value?.Trim(); }
        }

        public string SolucionAplicada
        {
            get { return _solucionAplicada; }
            set { _solucionAplicada = value?.Trim(); }
        }

        public string Prioridad
        {
            get { return _prioridad; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Debe indicar la prioridad.");

                _prioridad = value.Trim();
            }
        }

        public string Observaciones
        {
            get { return _observaciones; }
            set { _observaciones = value?.Trim(); }
        }

        public DateTime FechaIngreso
        {
            get { return _fechaIngreso; }
            set { _fechaIngreso = value; }
        }

        public DateTime? FechaAsignacionTecnico
        {
            get { return _fechaAsignacionTecnico; }
            set { _fechaAsignacionTecnico = value; }
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

        public decimal CostoEstimado
        {
            get { return _costoEstimado; }
            set
            {
                if (value < 0)
                    throw new ArgumentException("El costo estimado no puede ser negativo.");

                _costoEstimado = value;
            }
        }

        public decimal CostoFinal
        {
            get { return _costoFinal; }
            set
            {
                if (value < 0)
                    throw new ArgumentException("El costo final no puede ser negativo.");

                _costoFinal = value;
            }
        }

        public int GarantiaDias
        {
            get { return _garantiaDias; }
            set
            {
                if (value < 0)
                    throw new ArgumentException("La garantía no puede ser negativa.");

                _garantiaDias = value;
            }
        }

        // ==========================
        // CONSTRUCTORES
        // ==========================

        public Ticket()
        {
            FechaIngreso = DateTime.Now;
            Estado = EstadoTicket.EnEspera;
            Prioridad = "Normal";
            CostoEstimado = 0;
            CostoFinal = 0;
            GarantiaDias = 0;
        }

        public Ticket(
            string folio,
            Equipo equipo,
            Problema problema,
            Recepcionista recepcionista,
            string descripcionFalla)
        {
            Folio = folio;
            Equipo = equipo;
            Problema = problema;
            Recepcionista = recepcionista;
            DescripcionFalla = descripcionFalla;

            FechaIngreso = DateTime.Now;

            Estado = EstadoTicket.EnEspera;
            Prioridad = "Normal";

            CostoEstimado = 0;
            CostoFinal = 0;
            GarantiaDias = 0;
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