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
    public partial class FacturarCompra : Form
    {
        List<String> Lista;
        public FacturarCompra(List<String> ListaTemp, int IDFarmacia)
        {
            InitializeComponent();
            Lista = ListaTemp;
             
            DataSet Data = ConexionMetodos.Cargar_Medicamentos(IDFarmacia);
            comboBox1.DataSource = Data.Tables[0].DefaultView;
            comboBox1.ValueMember = "Nombre";
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "") { MessageBox.Show("Ingrese una cantidad"); }
            else
            {
                String LineaCompra = comboBox1.Text + " " + textBox1.Text;

                listBox1.Items.Add(LineaCompra);
                

                int Precio = ConexionMetodos.ObtenerPrecioMedicamento(comboBox1.Text);
                int Cantidad = Convert.ToInt32(textBox1.Text);
                

                int Monto = Cantidad * Precio;

                int Monto_actual = Convert.ToInt32(textBox3.Text);

                int Monto_Final = Monto + Monto_actual;

                textBox3.Text = Monto_Final.ToString();




            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            BuscarFarmacia NuevoBuscar = new BuscarFarmacia(Lista);
            NuevoBuscar.Show();
            this.Hide();
        }
    }
}
