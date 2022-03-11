using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    public class Producto
    {
        private int _idcodigo;
        private string _nombre;
        private double _precio;


        public Producto()
        {

        }

        public Producto (int idcodigo,string nombre,double precio)
        {
            this.IDCodigo = idcodigo;
            this.Nombre = nombre;
            this.Precio = precio;
            
        }

        public double Precio
        {
            get { return _precio; }
            set { _precio = value; }
        }


        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }


        public int IDCodigo
        {
            get { return _idcodigo; }
            set { _idcodigo = value; }
        }

       

    }
}
