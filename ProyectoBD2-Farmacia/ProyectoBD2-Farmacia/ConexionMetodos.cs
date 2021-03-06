﻿using System;
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
                SqlCommand Comando = new SqlCommand("dbo.SP_Autentificacion", Conn);
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

        
        public static int IngresarClientes(String Nombre, String Apellidos, String Cedula, String Email)
        {
            int resultado = -1;
            using (SqlConnection Conn = Conexion.ObtenerConexion())
            {
                SqlCommand Comando = new SqlCommand("SP_Insertar_Cliente", Conn);
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.Parameters.AddWithValue("@Nombre", Nombre);
                Comando.Parameters.AddWithValue("@Apellidos", Apellidos);
                Comando.Parameters.AddWithValue("@Cedula", Cedula);
                Comando.Parameters.AddWithValue("@Email", Email);
                Comando.ExecuteNonQuery();
                resultado = 1;
                Conn.Close();
                return resultado;
            }
        }

        public static List<String> BuscarCliente(String Cedula)
        {
            List<String> Lista = new List<String>();
            String id = "";
            String Nombre = "";
            String Apellidos = "";
            String Cedula1 = "";
            String Email = "";

            SqlConnection Conn = Conexion.ObtenerConexion();
            if (Conn != null)
            {
                SqlCommand Comando = new SqlCommand("SP_Consultar_Cliente", Conn);
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.Parameters.AddWithValue("@Cedula", Cedula);
                
                SqlDataReader lector = Comando.ExecuteReader();
                while (lector.Read())
                {
                    id = lector.GetInt32(0).ToString();
                    Nombre = lector.GetString(1);
                    Apellidos = lector.GetString(2);
                    Cedula1 = lector.GetString(3);
                    Email = lector.GetString(4);

                    Lista.Add(id);
                    Lista.Add(Nombre);
                    Lista.Add(Apellidos);
                    Lista.Add(Cedula1);
                    Lista.Add(Email);
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

        public static DataSet Cargar_Farmacias()
        {
            DataSet ds1 = new DataSet();
            SqlConnection Conn = Conexion.ObtenerConexion();
            if (Conn != null)
            {
                SqlCommand Comando = new SqlCommand("SP_Consultar_Farmacias", Conn);
                Comando.CommandType = CommandType.StoredProcedure;
                
                SqlDataAdapter da1 = new SqlDataAdapter(Comando);
                da1.Fill(ds1, "dbo.Farmacia");

                Conn.Close();
                
            }

            return ds1;

        }

        public static DataSet Cargar_Inventario(int ID)
        {
            DataSet ds1 = new DataSet();
            SqlConnection Conn = Conexion.ObtenerConexion();
            if (Conn != null)
            {
                SqlCommand Comando = new SqlCommand("SP_Consultar_Inventario_X_Farmacia", Conn);
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.Parameters.AddWithValue("@ID", ID);

                SqlDataAdapter da1 = new SqlDataAdapter(Comando);
                da1.Fill(ds1, "dbo.InventarioXFarmacia");

                Conn.Close();

            }

            return ds1;

        }

        public static DataSet Cargar_Medicamentos()
        {
            DataSet ds1 = new DataSet();
            SqlConnection Conn = Conexion.ObtenerConexion();
            if (Conn != null)
            {
                SqlCommand Comando = new SqlCommand("SP_Consultar_Medicamento", Conn);
                Comando.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter da1 = new SqlDataAdapter(Comando);
                da1.Fill(ds1, "dbo.Medicamento");

                Conn.Close();

            }

            return ds1;

        }

        public static DataSet Cargar_Farmacias_X_Medicamento(String Medicamento)
        {
            DataSet ds1 = new DataSet();
            SqlConnection Conn = Conexion.ObtenerConexion();
            if (Conn != null)
            {
                SqlCommand Comando = new SqlCommand("dbo.SP_Obtener_Farmacias_X_Medicamento", Conn);
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.Parameters.AddWithValue("@Nombre_Medicamento", Medicamento);

                SqlDataAdapter da1 = new SqlDataAdapter(Comando);
                da1.Fill(ds1, "dbo.Farmacia");

                Conn.Close();

            }

            return ds1;

        }


        public static DataSet Cargar_Empleados(int IDFarmacia)
        {
            DataSet ds1 = new DataSet();
            SqlConnection Conn = Conexion.ObtenerConexion();
            if (Conn != null)
            {
                SqlCommand Comando = new SqlCommand("dbo.SP_Consultar_Empleado", Conn);
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.Parameters.AddWithValue("@ID_Farmacia", IDFarmacia);

                SqlDataAdapter da1 = new SqlDataAdapter(Comando);
                da1.Fill(ds1, "dbo.Empleado");

                Conn.Close();

            }

            return ds1;

        }

        public static int ObtenerPrecioMedicamento(String Nombre)
        {
            
            int Precio = 0;

            SqlConnection Conn = Conexion.ObtenerConexion();
            if (Conn != null)
            {
                SqlCommand Comando = new SqlCommand("SP_Consultar_Medicamento", Conn);
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.Parameters.AddWithValue("@Nombre", Nombre);

                SqlDataReader lector = Comando.ExecuteReader();
                while (lector.Read())
                {
                    
                    Precio = lector.GetSqlMoney(4).ToInt32();

                    
                }

                Conn.Close();
                return Precio;
            }
            else
            {
                Console.WriteLine("No se puede conectar a la base de datos");
                return -1;
            }
        }
    }
}
