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


        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            BuscarFarmacia NuevoBuscar = new BuscarFarmacia(Lista);
            NuevoBuscar.Show();
            this.Hide();
        }
    }
}
