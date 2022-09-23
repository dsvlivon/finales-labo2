using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace BibliotecaDeClases
{

    // DESARROLLAR
    public class SqlManejador
    {
        private SqlConnection conexion;
        private SqlCommand comando;

        public SqlManejador()
        {
            conexion = new SqlConnection("Data Source=.; Initial Catalog=ExamenPrimerFecha2022; Integrated Security=True;");//verificar
            comando = new SqlCommand();
            comando.Connection = conexion;
        }

        public int Insertar(EmpleadoFreelance dato)
        {
            if (validarDatos(dato)) { 
                try { 
                    comando.CommandText= "INSERT INTO dbo.Empleados " +
                        "(Dni, Nombre, Posicion, Honorario) VALUES (@Dni, @Nombre, @Posicion, @Honorario);";
                    comando.Parameters.Clear();
                    comando.Parameters.AddWithValue("@Dni", dato.Dni);
                    comando.Parameters.AddWithValue("@Nombre", dato.NombreCompleto);
                    comando.Parameters.AddWithValue("@Posicion", dato.Posicion);
                    comando.Parameters.AddWithValue("@Honorario", dato.CalcularHonorarios);
                    conexion.Open();
                    comando.ExecuteNonQuery();
                } catch (Exception e)
                {

                } finally
                {
                    if (conexion.State == System.Data.ConnectionState.Open)
                    {
                        conexion.Close();
                    }
                }
                return 1;//x ahora lo dejo asi.... no se q devuelve
            } else { return 0; }
        }
        bool validarDatos(EmpleadoFreelance e)
        {
            bool flag = true;
            if (e.Dni < 10000000 && e.Dni > 45000000)
            {
                flag = false;
            } 
            if (e.NombreCompleto == null && e.NombreCompleto == "") {
                flag = false;
            }

            if (!flag)
            {
                throw new DatoErroneoException("nombre o dni mal!");
            }
            return flag;
        }
    }
}
