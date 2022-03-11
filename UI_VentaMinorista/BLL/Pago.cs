using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    public abstract class Pago
    {
        private string _nombre;

        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }

        public  abstract double ValorDePago(Producto producto);
     
    }
}
