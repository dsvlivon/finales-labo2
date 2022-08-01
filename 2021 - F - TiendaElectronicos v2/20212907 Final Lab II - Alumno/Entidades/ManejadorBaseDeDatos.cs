using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class ManejadorBaseDeDatos
    {
        static SqlConnection conexion;
        static ManejadorBaseDeDatos()
        {
            conexion = new SqlConnection("Data Source=.; Initial Catalog=Final_1erafecha_2021; Integrated Security=True;");
        }

        public static List<Producto> ObtenerProductos()
        {
            List<Producto> l = new List<Producto>();
            SqlCommand comando = new SqlCommand();
            comando.Connection = conexion;//solo p versiones viejardas
            comando.CommandText = "SELECT * FROM dbo.Televisor";
            try
            {
                ManejadorBaseDeDatos.conexion.Open();
                SqlDataReader reader = comando.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Producto x = new Televisor(
                            reader["marca"].ToString(),
                            reader["modelo"].ToString(),
                            Convert.ToInt32(reader["pulgadas"]),
                            float.Parse(reader["precio"].ToString())
                            );
                        l.Add(x);
                    }
                }
            } catch (Exception e){
                throw new Exception($"ERROR EN  ObtenerProductos() - {e.Message} - {e.GetBaseException()}");
            } finally {
                if(ManejadorBaseDeDatos.conexion.State == System.Data.ConnectionState.Open) { ManejadorBaseDeDatos.conexion.Close(); }
            }
            return l;
        }
    }
}
