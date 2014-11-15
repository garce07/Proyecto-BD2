using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;

namespace ProyectoBD2_Farmacia
{
    public class Conexion
    {

        public static SqlConnection ObtenerConexion()
        {
            try
            {
                SqlConnection Connec = new SqlConnection("Data Source=GUILLERMOPC\\SQL_GUILLERMO; Initial Catalog = Farmacias; Integrated Security=True"); //User Id=mono; Password=123"
                // NO BORREN ESTO ES PARA NADA MAS COPIAR Y PEGAR A LA HORA DE HACER PRUEBAS...
                // Data Source=GUILLERMOPC\\SQL_GUILLERMO;
                //Data Source = EQUIPO-ADRIAN\\SQLEXPRESS
                Connec.Open();
                return Connec;
            }
            catch (Exception e)
            {
                Console.WriteLine("No se puede conectar a la base de datos", e);
                return null;
            }
        }

    }
}
