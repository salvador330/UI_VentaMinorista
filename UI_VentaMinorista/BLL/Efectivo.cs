using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    public class Efectivo : Pago
    {
        public Efectivo()
        {
            this.Nombre = "Efectivo";
        }

        /// <summary>
        /// Realiza un descuento del 10% del producto
        /// </summary>
        /// <param name="producto"></param>
        /// <returns>double</returns>
        public override double ValorDePago(Producto producto)
        {
            return producto.Precio - (producto.Precio * 0.10);
        }
    }
}
