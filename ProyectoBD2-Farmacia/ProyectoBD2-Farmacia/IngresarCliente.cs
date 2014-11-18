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
    public partial class IngresarCliente : Form
    {
        public IngresarCliente()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "") { MessageBox.Show("Ingrese el nombre del cliente"); }
            else if (textBox2.Text == "") { MessageBox.Show("Ingrese los apellidos"); }
            else if (textBox3.Text == "") { MessageBox.Show("Ingrese la cedula del cliente"); }
            else if (textBox4.Text == "") { MessageBox.Show("Ingrese el email"); }

            else
            {
                int resultado = ConexionMetodos.IngresarClientes(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text);
                if (resultado == -1){ MessageBox.Show("Error al ingresar el cliente al sistema");}
                else{
                    MessageBox.Show("Cliente registrado con exito");
                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";
                    textBox4.Text = "";
                }
            }
                   
        }

        private void button2_Click(object sender, EventArgs e)
        {
            BuscarCliente NuevoBuscar = new BuscarCliente();
            NuevoBuscar.Show();
            this.Hide();
        }

        private void IngresarCliente_Load(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
