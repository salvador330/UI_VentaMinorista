using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    public class TarjetaDeDebito : Pago
    {
        public TarjetaDeDebito()
        {
            this.Nombre = "Tarjeta De Debito";
        }


        /// <summary>
        /// Realiza un descuento del 5% del producto
        /// </summary>
        /// <param name="producto"></param>
        /// <returns>double</returns>
        public override double ValorDePago(Producto producto)
        {
            return producto.Precio - (producto.Precio * 0.05);
        }
    }
}
