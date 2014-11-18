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
    public partial class InicioConsultor : Form
    {
        public InicioConsultor()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Identificacion Nuevo = new Identificacion(); Nuevo.Show(); this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FarmaciaXMedicamentos Nuevo = new FarmaciaXMedicamentos(); Nuevo.Show(); this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }
    }
}
