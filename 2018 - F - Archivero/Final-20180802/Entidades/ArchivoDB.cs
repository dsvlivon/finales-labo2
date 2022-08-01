using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    class ArchivoDB : DatabaseConnection
    {
        public static bool InsertProducto(Archivo d)
        {
            ArchivoDB.Comando.CommandText = "INSERT INTO dbo.Archivo " +
                //"(id, nombre, contenido) VALUES (@id, @nombre, @contenido);";
                "(nombre, contenido) VALUES (@nombre, @contenido);";
            ArchivoDB.Comando.Parameters.Clear();
            //ArchivoDB.Comando.Parameters.AddWithValue("@marca", d.id);
            ArchivoDB.Comando.Parameters.AddWithValue("@nombre", d.nombre);
            ArchivoDB.Comando.Parameters.AddWithValue("@contenido", d.contenido);
            return ArchivoDB.Ejecutar();
        }


        public static List<Archivo> SelectAll(string tabla)
        {
            List<Archivo> l = new List<Archivo>();

            try
            {
                ArchivoDB.Comando.CommandText = $"SELECT * FROM dbo.{tabla}";

                ArchivoDB.Conexion.Open();
                SqlDataReader sqlReader = ArchivoDB.Comando.ExecuteReader();
                if (sqlReader.HasRows)
                {
                    while (sqlReader.Read())
                    {
                        //int id = Convert.ToInt32(sqlReader["id"]);
                        string nombre = sqlReader["nombre"].ToString();
                        string contenido = sqlReader["contenido"].ToString();

                        Archivo x = new Archivo(nombre, contenido);
                        l.Add(x);
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception($"ERROR EN  SelectAll() - {e.Message} - {e.GetBaseException()}");
            }
            finally
            {
                if (ArchivoDB.Conexion.State == System.Data.ConnectionState.Open)
                {
                    ArchivoDB.Conexion.Close();
                }
            }
            return l;
        }
    }
}
