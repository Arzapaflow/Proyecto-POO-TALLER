namespace Proyecto1.Models
{
    public static class SesionActual
    {
        public static Usuario Usuario { get; private set; }

        // NUEVO
        public static Tecnico Tecnico { get; set; }

        public static void IniciarSesion(Usuario usuario)
        {
            Usuario = usuario;
        }

        public static void CerrarSesion()
        {
            Usuario = null;

            // NUEVO
            Tecnico = null;
        }

        public static bool HaySesion
        {
            get
            {
                return Usuario != null;
            }
        }
    }
}