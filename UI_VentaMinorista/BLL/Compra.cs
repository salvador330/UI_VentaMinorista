using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    public  class Compra
    {       
        private List<Producto> _listadeProductos = new List<Producto>() ;
        private double _total;
        private bool _iva;
        private bool _descuectoEspecial;
        private Pago _pago;

        public Compra()
        {

        }

        public Compra(Pago tipodedepago, List<Producto> listadeproductos, bool iva, bool descuentoespecial)
        {
            this.Pago = tipodedepago;
            this.ListaDeProductos = listadeproductos;
            this.IVA = iva;
            this.DescuentoEspecial = descuentoespecial;

        }

        /// <summary>
        /// Suma el precio de todos los productos, teninedo encuenta su tipo de pago, si aplica IVA, si tiene descuento especial
        /// </summary>
        /// <returns>Total en double</returns>
        public double RealizarCompra()
        {
            double recargoIva, DescuentoEspecial;

            foreach (Producto item in this.ListaDeProductos)
            {

                if (this.IVA==true)
                {
                    recargoIva = this.Pago.ValorDePago(item) * .21;
                }
                else
                {
                    recargoIva = 0;
                }

                this.Total = this.Total + this.Pago.ValorDePago(item)+ recargoIva;
            }

            if (this.DescuentoEspecial==true && Total>1000)
            {
                DescuentoEspecial = 50;
            }
            else { DescuentoEspecial = 0; }

            return this.Total - DescuentoEspecial;

        }

        public bool DescuentoEspecial
        {
            get { return _descuectoEspecial; }
            set { _descuectoEspecial = value; }
        }

        public Pago Pago
        {
            get { return _pago; }
            set { _pago = value; }
        }

        public bool IVA
        {
            get { return _iva; }
            set { _iva = value; }
        }


        public double Total
        {
            get { return _total; }
            set { _total = value; }
        }

        public List<Producto> ListaDeProductos
        {
            get { return _listadeProductos; }
            set { value = _listadeProductos; }
        }




    }
}
