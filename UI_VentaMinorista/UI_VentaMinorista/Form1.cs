using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;

namespace UI_VentaMinorista
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

              
        //Hardcodeo los productos 
        Producto Producto1 = new Producto(124, "Reloj", 500);
        Producto Producto2 = new Producto(128, "Calculadora Cientifica", 2500);
        Producto Producto3 = new Producto(133, "Calculadora Basica", 750);

        //variables temporales
        string tempListaCarrito = "";
        List<Producto> TempListaDeProductos = new List<Producto>();

        //cliente temporal para pasar a formulario2
        Cliente TempCliente = new Cliente();

        private void Form1_Load(object sender, EventArgs e)
        {

            comboBox1.Items.Add(Producto1.Nombre + " Precio: " + Producto1.Precio + " $");
            comboBox1.Items.Add(Producto2.Nombre + " Precio: " + Producto2.Precio + " $");
            comboBox1.Items.Add(Producto3.Nombre + " Precio: " + Producto3.Precio + " $");

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }


        private void button1_Click(object sender, EventArgs e)
        {
            //obtengo el item seleccionado del combobox lo muestro y lo cargo ala lista temporal ListaDeProductos

            //soluciono el problema si el usuario no elige un producto
            if (comboBox1.SelectedIndex != -1)
            {
                tempListaCarrito = tempListaCarrito + comboBox1.SelectedItem.ToString() + "\r\n";

                textBox2.Text = tempListaCarrito;

                if (comboBox1.SelectedIndex == 0)
                {
                    TempListaDeProductos.Add(Producto1);
                }
                if (comboBox1.SelectedIndex == 1)
                {
                    TempListaDeProductos.Add(Producto2);
                }
                if (comboBox1.SelectedIndex == 2)
                {
                    TempListaDeProductos.Add(Producto3);
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar un producto por lo menos", "error");
            }
            

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //calcular monto total

            //obtener el radio button precionado para instanciar un tipo de pago
            //cargo el objeto unaCompra con sus propertis
            Compra unaCompra = new Compra();

            if (radioButton1.Checked==true)
            {         
                unaCompra.Pago = new Efectivo();              
                //paso los productos de la lista temporal a la lista de compras
                foreach (Producto item in TempListaDeProductos)
                {
                    unaCompra.ListaDeProductos.Add(item);
                }               
                unaCompra.IVA = checkBox1.Checked;
                unaCompra.DescuentoEspecial = checkBox2.Checked;
            }
            if (radioButton2.Checked == true)
            {              
                unaCompra.Pago = new TarjetaDeCredito();
                //paso los productos de la lista temporal a la lista de compras
                foreach (Producto item in TempListaDeProductos)
                {
                    unaCompra.ListaDeProductos.Add(item);
                }
                unaCompra.IVA = checkBox1.Checked;
                unaCompra.DescuentoEspecial = checkBox2.Checked;

            }
            if (radioButton3.Checked == true)
            {              
                unaCompra.Pago = new TarjetaDeDebito();
                //paso los productos de la lista temporal a la lista de compras
                foreach (Producto item in TempListaDeProductos)
                {
                    unaCompra.ListaDeProductos.Add(item);
                }
                unaCompra.IVA = checkBox1.Checked;
                unaCompra.DescuentoEspecial = checkBox2.Checked;

            }



            try
            {



                Cliente unCliente = new Cliente(TxtNombre.Text, Convert.ToInt32(TxtDni.Text), Convert.ToInt32(TxtCVC.Text), unaCompra);
                TempCliente = unCliente;

                //habilito el boton para poder imprimir la factura
                button3.Enabled = true;

                //muetro el monto              
                MessageBox.Show(unaCompra.RealizarCompra().ToString(),"Monto Total");
                
            }

            catch (FormatException)
            {
                 MessageBox.Show("Debe cargar valores en los campos","Error");
            }

            catch (Exception)
            {

                throw;
            }

            

        
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //abro otro formulario para mostrar factura
            Form2 FormularioFactura = new Form2();
            FormularioFactura.textBox1.Text = TempCliente.Nombre;
            FormularioFactura.textBox2.Text = TempCliente.DNI.ToString();
            FormularioFactura.textBox3.Text = TempCliente.Compra.Pago.Nombre;
            FormularioFactura.textBox4.Text = TempCliente.Compra.Total.ToString();
            FormularioFactura.textBox5.Text = TempCliente.CVC.ToString();
            foreach (Producto item in TempCliente.Compra.ListaDeProductos)
            {
                FormularioFactura.dataGridView1.Rows.Add(item.IDCodigo,item.Nombre,item.Precio);
            }
                   


            FormularioFactura.Show();
        }
    }
}
