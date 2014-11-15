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
    public partial class BuscarFarmacia : Form
    {
        List<String> Lista;

        public BuscarFarmacia(List<String> ListaTemp)
        {
            InitializeComponent();
            Lista = ListaTemp;

            DataSet Data = ConexionMetodos.Cargar_Farmacias();
            comboBox1.DataSource = Data.Tables[0].DefaultView;
            comboBox1.ValueMember = "Nombre";
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            BuscarCliente NuevoBuscar = new BuscarCliente();
            NuevoBuscar.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int IDFarmacia = comboBox1.SelectedIndex + 1;
            FacturarCompra NuevoFacturar = new FacturarCompra(Lista, IDFarmacia);
            NuevoFacturar.Show();
            this.Hide();
        }

        private void BuscarFarmacia_Load(object sender, EventArgs e)
        {

        }
    }
}
