using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    public class Cliente
    {
        private string _nombre;
        private int _dni;
        private int _cvc;
        private Compra _compra;

        public Cliente()
        {

        }

        public Cliente(string nombre,int dni, int cvc,Compra compra)
        {
            this.Nombre = nombre;
            this.DNI = dni;
            this.Compra = compra;
            this.CVC = cvc;
        }

        public Compra Compra
        {
            get { return _compra; }
            set { _compra = value; }
        }


        public int DNI
        {
            get { return _dni; }
            set { _dni = value; }
        }

        public int CVC
        {
            get { return _cvc; }
            set { _cvc = value; }
        }

        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }

    }
}
