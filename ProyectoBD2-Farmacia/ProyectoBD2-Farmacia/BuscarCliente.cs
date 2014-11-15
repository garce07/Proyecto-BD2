using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoBD2_Farmacia
{
    public partial class BuscarCliente : Form
    {
        public BuscarCliente()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "") { MessageBox.Show("Ingrese la cedula del cliente para continuar"); }
            else
            {
                List<String> Lista = ConexionMetodos.BuscarCliente(textBox1.Text);
                if (Lista != null)
                {
                    if (Lista.Count() == 0) { MessageBox.Show("No se encontro el cliente"); IngresarCliente NuevoCliente = new IngresarCliente(); NuevoCliente.Show(); this.Hide(); }
                    else
                    {

                        String idCliente = Lista.ElementAt(0);
                        String Nombre = Lista.ElementAt(1);
                        String Apellidos = Lista.ElementAt(0);
                        String Cedula = Lista.ElementAt(1);
                        String Email = Lista.ElementAt(1);


                        MessageBox.Show("El cliente si existe en la base de datos");
                        BuscarFarmacia NuevaCompra = new BuscarFarmacia(Lista); 
                        NuevaCompra.Show(); 
                        this.Hide();

                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("LOG OUT");
            Identificacion NuevaIdentificacion = new Identificacion();
            NuevaIdentificacion.Show();
            this.Hide();
        }
   
    }
}
