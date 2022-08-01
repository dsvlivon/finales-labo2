using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public abstract class DatabaseConnection
    {
        private static SqlConnection conexion;
        private static SqlCommand comando;

        #region Constructores
        static DatabaseConnection()
        {
            conexion = new SqlConnection("Data Source=.; Initial Catalog=master; Integrated Security=True;");
            //conexion = new SqlConnection("Server=.\\SQLEXPRESS;Database=master;Trusted_Connection=True;");
            comando = new SqlCommand();
            comando.Connection = DatabaseConnection.conexion;
        }
        #endregion

        #region Propiedades
        protected static SqlConnection Conexion
        {
            get
            {
                return DatabaseConnection.conexion;
            }
        }

        protected static SqlCommand Comando
        {
            get
            {
                return DatabaseConnection.comando;
            }
        }
        protected static SqlDataReader Reader
        {
            get
            {
                return DatabaseConnection.Reader;
            }
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Metodo para establecer y finalizar la conexion con la base de datos, con orden try/catch/finally
        /// </summary>
        protected static bool Ejecutar()
        {
            bool ret = false;
            try
            {
                DatabaseConnection.Conexion.Open();
                if (DatabaseConnection.Comando.ExecuteNonQuery() > 0)
                {
                    ret = true;
                }                
                return ret;
            }
            catch (Exception e)
            {
                throw new Exception($"ERROR EN Ejecutar(): {e.Message} - {e.GetBaseException()}");
            }
            finally
            {
                if (DatabaseConnection.Conexion.State == System.Data.ConnectionState.Open)
                {
                    DatabaseConnection.Conexion.Close();
                }                
            }
        }
        #endregion
    }
}
