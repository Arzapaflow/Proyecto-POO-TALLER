namespace Proyecto1.Models
{
    public static class ConfiguracionTaller
    {
        // Porcentaje del costo final que recibe el técnico
        public static decimal PorcentajePagoTecnico = 0.30m;

        // Utilidad para el taller
        public static decimal PorcentajeUtilidad
        {
            get
            {
                return 1 - PorcentajePagoTecnico;
            }
        }
    }
}