using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.IO;

namespace PruebaApp
{
    public class ConexionSQL
    {
        private string server;
        private string dataBase;
        private string userId;
        private string password;

        public ConexionSQL(string s, string d, string u, string p)
        {
            this.server = "localhost";//"192.168.100.9, 6060";
            this.dataBase = "SISTEMA";
            this.userId = "";//"casa";
            this.password = "";//"admin";
        }

        private string ConnectionString
        {
            get
            {
                if (string.IsNullOrEmpty(userId) || userId.Trim().Equals(string.Empty))
                {
                    return string.Format("Data Source={0};Initial Catalog={1};Integrated Security=yes", server, dataBase);
                }
                else
                {
                    return string.Format("Data Source={0};Initial Catalog={1};User ID={2};Pwd={3}", server, dataBase, userId, password);
                }

            }
        }

        public bool realizarConsultaSQL(string cedula, ref List<Dictionary<int, object>> filas)
        {
            
            string expresion = string.Format(
            "SELECT P.Nombre,Apellido1,Apellido2, Pr.Nombre,C.Nombre,D.Nombre, Sexo, FechaCaducidad,CodigoJunta FROM  PERSONA P " +
            "INNER JOIN DISTRITO D ON D.IdDistrito = P.IdDistrito AND D.IdCanton = P.IdCanton AND D.IdProvincia = P.IdProvincia " +
            "INNER JOIN CANTON C ON C.IdCanton = P.IdCanton AND C.IdProvincia = P.IdProvincia " +
            "INNER JOIN PROVINCIA Pr ON Pr.IdProvincia = P.IdProvincia " +
            "WHERE P.Cedula = {0}", cedula);


            List<string> columnas = null;

            filas = ExecuteCommand(expresion, ref columnas);
            
            if (filas != null)
            {
                return true;
            }
            return false;
        }

        public void ActualizarDistrito(string provincia, string canton, ref List<Dictionary<int, object>> filas)
        {
            string expresion = string.Format(
            "SELECT D.Nombre FROM DISTRITO D " +
            "INNER JOIN PROVINCIA PR ON PR.Nombre = '{0}' " +
            "INNER JOIN CANTON C ON C.Nombre = '{1}' AND PR.IdProvincia = C.IdProvincia " +
            "WHERE PR.IdProvincia = D.IdProvincia AND C.IdCanton = D.IdCanton;", provincia, canton);

            List<string> columnas = null;

            filas = ExecuteCommand(expresion, ref columnas);
        }

        public void ActualizarCanton(string provincia, ref List<Dictionary<int, object>> filas)
        {
            string expresion = string.Format(
            "SELECT C.Nombre FROM CANTON C " +
            "inner join PROVINCIA PR ON PR.Nombre = '{0}' " +
            "WHERE PR.IdProvincia = C.IdProvincia;", provincia);

            List<string> columnas = null;

            filas = ExecuteCommand(expresion, ref columnas);
        }

        public void ActualizarPersona(String cedula, String Nombre, String Apellido1, String Apellido2,
          String IdProvicia, String IdCanton, String IdDistrito, String Sexo, String FechaCaducidad, string Junta)
        {
            string statement = string.Format("SELECT D.IDPROVINCIA, D.IDCANTON, D.IDDISTRITO " +
                "FROM PROVINCIA PR " +
                "INNER JOIN CANTON C ON PR.IdProvincia = C.IdProvincia " +
                "INNER JOIN DISTRITO D ON D.IdProvincia = C.IdProvincia AND D.IdCanton = C.IdCanton " +
                "WHERE PR.Nombre = '{0}' AND C.Nombre = '{1}' AND D.Nombre = '{2}'", IdProvicia, IdCanton, IdDistrito);
            List<Dictionary<int, object>> filas = null;
            List<string> columnas = null;
            filas = ExecuteCommand(statement, ref columnas);
            try
            {
                if (filas != null)
                {
                    var fila = filas[0];
                    IdProvicia = fila[0].ToString();
                    IdCanton = fila[1].ToString();
                    IdDistrito = fila[2].ToString();
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }

            SqlConnection cn = new SqlConnection(ConnectionString);
            string expresion = string.Format(
            "update Persona  SET nombre = '{0}', Apellido1 = '{1}', Apellido2 = '{2}', IdProvincia = {3}, IdCanton = {4}, IdDistrito = {5}, Sexo = {6},  " +
            "FechaCaducidad = '{7}'" +
            "Where Cedula = {8}", Nombre, Apellido1, Apellido2, IdProvicia, IdCanton, IdDistrito, Sexo, FechaCaducidad, cedula);


            try
            {
                cn.Open();
                SqlCommand cm = new SqlCommand(expresion);
                cm.CommandType = System.Data.CommandType.Text;
                cm.Connection = cn;
                cm.CommandTimeout = 0;
                cm.ExecuteNonQuery();
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (cn.State == System.Data.ConnectionState.Open)
                {
                    cn.Close();
                }
                
            }


        }
        public List<Dictionary<int, object>> ExecuteCommand(string statement, ref List<string> nombreColumnas)
        {

            List<Dictionary<int, object>> resultado = new List<Dictionary<int, object>>();
            nombreColumnas = new List<string>();

            SqlConnection cn = new SqlConnection(ConnectionString);
            try
            {
                cn.Open();
                SqlCommand cm = new SqlCommand(statement);
                cm.CommandType = System.Data.CommandType.Text;
                cm.Connection = cn;

                SqlDataReader dr = cm.ExecuteReader();
                while (dr.Read())
                {

                    if (nombreColumnas.Count == 0)
                    {
                        for (int i = 0; i < dr.FieldCount; i++)
                        {
                            nombreColumnas.Add(dr.GetName(i));
                        }
                    }

                    Dictionary<int, object> fila = new Dictionary<int, object>();

                    for (int i = 0; i < dr.FieldCount; i++)
                    {
                        fila.Add(i, dr[i]);
                    }

                    resultado.Add(fila);
                }
                dr.Close();

                return resultado;
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                if (cn.State == System.Data.ConnectionState.Open)
                {
                    cn.Close();
                }
            }
        }

        public bool TestConnection()
        {
            SqlConnection cn;
            cn = new SqlConnection(ConnectionString);
            try
            {
                cn.Open();
                if (cn != null)
                {
                    cn.Close();
                    return true;
                }
                else
                {
                    cn.Close();
                    return false;
                }
            }
            catch
            {
                cn.Close();
                return false;
            }
        }
    }
}
