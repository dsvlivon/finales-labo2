using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class PersonajeDAO
    {
        static SqlConnection conexion;
        
        static PersonajeDAO()
        {
            conexion = new SqlConnection("Data Source=.; Initial Catalog=COMBATE_DB; Integrated Security=True;");
        }
                                
        public static Personaje ObtenerUnPersonajePorId(decimal ID)
        {            
            SqlCommand comando = new SqlCommand();
            comando.Connection = conexion;//solo p versiones viejardas
            comando.CommandText = "SELECT * FROM dbo.PERSONAJES WHERE id = @id";
            try
            {
                PersonajeDAO.conexion.Open();
                comando.Parameters.Clear();
                comando.Parameters.AddWithValue("@id",ID);
                SqlDataReader reader = comando.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        //public Hechicero(decimal id, string nom, short nivel) : base(id, nom, nivel)
                        if(Convert.ToInt32(reader["clase"]) == 1)
                        {
                            Personaje x = new Guerrero(
                            Convert.ToDecimal(reader["id"]),
                            reader["nombre"].ToString(),
                            (short)Convert.ToInt32(reader["nivel"]));
                            return x;
                        } 
                        else if(Convert.ToInt32(reader["clase"]) == 2)
                        {
                            Personaje x = new Hechicero(
                            Convert.ToDecimal(reader["id"]),
                            reader["nombre"].ToString(),
                            (short)Convert.ToInt32(reader["nivel"]));
                            return x;
                        } else { return null; }
                    }
                } else { return null; }
            }
            catch (Exception e)
            {
                throw new Exception($"ERROR EN  ObtenerProductos() - {e.Message} - {e.GetBaseException()}");
            }
            finally
            {
                if (PersonajeDAO.conexion.State == System.Data.ConnectionState.Open) { PersonajeDAO.conexion.Close(); }
            }
            return null;
        }
    }
}
