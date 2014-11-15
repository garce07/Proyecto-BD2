using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;


namespace ProyectoBD2_Farmacia
{
    class ConexionMetodos
    {

        public static List<int> Autentificar(String pUsuario, String pContraseña)
        {
            List<int> Lista = new List<int>();
            int resultado = -1;
            int id = 0;
            SqlConnection Conn = Conexion.ObtenerConexion();
            if (Conn != null)
            {
                SqlCommand Comando = new SqlCommand("autentificacion", Conn);
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.Parameters.AddWithValue("@usuario", pUsuario);
                Comando.Parameters.AddWithValue("@contraseña", pContraseña);
                SqlDataReader lector = Comando.ExecuteReader();
                while (lector.Read())
                {
                    id = lector.GetInt32(0);
                    resultado = lector.GetInt32(1);
                    Lista.Add(id);
                    Lista.Add(resultado);
                }
                Conn.Close();
                return Lista;
            }
            else
            {
                Console.WriteLine("No se puede conectar a la base de datos");
                return null;
            }
        }
    }
}
