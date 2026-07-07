namespace Proyecto1.Models
{
    public static class SesionActual
    {
        public static Usuario Usuario { get; private set; }

        public static void IniciarSesion(Usuario usuario)
        {
            Usuario = usuario;
        }

        public static void CerrarSesion()
        {
            Usuario = null;
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