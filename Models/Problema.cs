using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto1.Models
{
    public class Problema
    {
      
        // ATRIBUTOS
   

        private int _id;
        private string _nombre;
        private string _posiblesCausas;

       
        // PROPIEDADES
    

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
                    throw new ArgumentException("El nombre del problema no puede estar vacío.");

                _nombre = value.Trim();
            }
        }

        public string PosiblesCausas
        {
            get { return _posiblesCausas; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Debe existir al menos una posible causa.");

                _posiblesCausas = value.Trim();
            }
        }

        
        // CONSTRUCTORES
       

        public Problema()
        {

        }

        public Problema(string nombre, string posiblesCausas)
        {
            Nombre = nombre;
            PosiblesCausas = posiblesCausas;
        }

       
        // MÉTODOS
        

        public override string ToString()
        {
            return Nombre;
        }
    }
}