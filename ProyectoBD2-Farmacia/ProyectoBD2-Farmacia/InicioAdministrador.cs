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
    public partial class InicioAdministrador : Form
    {
        public InicioAdministrador()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Identificacion Nuevo = new Identificacion();
            Nuevo.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            IngresarMedicamento Nuevo = new IngresarMedicamento();
            Nuevo.Show();
            this.Hide();
        }
    }
}
