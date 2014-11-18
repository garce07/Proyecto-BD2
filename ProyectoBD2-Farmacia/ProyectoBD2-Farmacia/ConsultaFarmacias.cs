using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoBD2_Farmacia
{
    public partial class ConsultaFarmacias : Form
    {

        DataSet Empleados = new DataSet();

        public ConsultaFarmacias(int IDFarmacia,String Farmacia, String Horario, String Direccion)
        {
            InitializeComponent();

            label1.Text = Farmacia;
            label3.Text = Horario;
            label7.Text = Direccion;

            Empleados = ConexionMetodos.Cargar_Empleados(IDFarmacia);
            comboBox1.DataSource = Empleados.Tables[0].DefaultView;
            comboBox1.ValueMember = "Nombre";

        }

        private void button1_Click(object sender, EventArgs e)
        {
            FarmaciaXMedicamentos Nuevo = new FarmaciaXMedicamentos(); Nuevo.Show(); this.Hide();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            

            pictureBox1.Image = null;


            label11.Text = comboBox1.Text + " " + Empleados.Tables[0].Rows[comboBox1.SelectedIndex]["Apellidos"].ToString();
            label12.Text = Empleados.Tables[0].Rows[comboBox1.SelectedIndex]["Cedula"].ToString();
        
            byte[] arregloBytes = (byte[])Empleados.Tables[0].Rows[comboBox1.SelectedIndex]["Foto"];
            MemoryStream ms = new MemoryStream(arregloBytes);
            Image Foto = Image.FromStream(ms);
            ms.Close();

            pictureBox1.Image = Foto;

        }

        private void ConsultaFarmacias_Load(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
