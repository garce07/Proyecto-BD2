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
    public partial class FarmaciaXMedicamentos : Form
    {
        DataSet Data = new DataSet();
        DataSet Farmacias = new DataSet();

        public FarmaciaXMedicamentos()
        {
            InitializeComponent();
            
            Data = ConexionMetodos.Cargar_Medicamentos();
            comboBox1.DataSource = Data.Tables[0].DefaultView;
            comboBox1.ValueMember = "Nombre";
            

            pictureBox1.Image = null;
            
            byte[] arregloBytes = (byte[])Data.Tables[0].Rows[0]["Foto"];
            MemoryStream ms = new MemoryStream(arregloBytes);
            Image Foto = Image.FromStream(ms);
            ms.Close();

            pictureBox1.Image = Foto;
            label3.Text = Data.Tables[0].Rows[0]["Precio"].ToString();

            Farmacias = ConexionMetodos.Cargar_Farmacias_X_Medicamento(comboBox1.Text);
            comboBox2.DataSource = Farmacias.Tables[0].DefaultView;
            comboBox2.ValueMember = "Nombre";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            InicioConsultor Nuevo = new InicioConsultor(); Nuevo.Show(); this.Hide();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            pictureBox1.Image = null;
            label3.Text = Data.Tables[0].Rows[comboBox1.SelectedIndex]["Precio"].ToString();
            byte[] arregloBytes = (byte[])Data.Tables[0].Rows[comboBox1.SelectedIndex]["Foto"];
            MemoryStream ms = new MemoryStream(arregloBytes);
            Image Foto = Image.FromStream(ms);
            ms.Close();

            pictureBox1.Image = Foto;

            Farmacias = ConexionMetodos.Cargar_Farmacias_X_Medicamento(comboBox1.Text);
            comboBox2.DataSource = Farmacias.Tables[0].DefaultView;
            comboBox2.ValueMember = "Nombre";

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int ID = (int)Farmacias.Tables[0].Rows[comboBox2.SelectedIndex]["ID"] ;
            String Farmacia = comboBox2.Text;
            String Horario = Farmacias.Tables[0].Rows[comboBox2.SelectedIndex]["Horario"].ToString();
            String Direccion = Farmacias.Tables[0].Rows[comboBox2.SelectedIndex]["Direccion"].ToString();

            ConsultaFarmacias Nuevo = new ConsultaFarmacias(ID, Farmacia, Horario, Direccion); Nuevo.Show(); this.Hide();
        }
    }
}
