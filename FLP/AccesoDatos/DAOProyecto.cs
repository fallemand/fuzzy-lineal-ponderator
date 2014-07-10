using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using System.Data;

namespace AccesoDatos
{
    public class DAOProyecto
    {
        public string cadenaDeConexion = System.Configuration.ConfigurationManager.ConnectionStrings["localhost"].ConnectionString;

        public int registrarProyecto(Proyecto proyecto, Usuario usuario)
        {
            SqlConnection con = new SqlConnection(cadenaDeConexion);
            SqlCommand cmd = new SqlCommand();
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                    cmd.Connection = con;
                }
                string sql = @"INSERT INTO Proyectos(idUsuario, nombre, fecha)
                              VALUES (@idUsuario, @nombre, @fecha) SELECT SCOPE_IDENTITY()";
                cmd.Parameters.Clear();
                cmd.Parameters.Add(new SqlParameter("@idUsuario", usuario.idUsuario));
                cmd.Parameters.Add(new SqlParameter("@nombre", proyecto.nombre));
                cmd.Parameters.Add(new SqlParameter("@fecha", proyecto.fecha));
                cmd.CommandText = sql;
                return int.Parse(cmd.ExecuteScalar().ToString());
            }
            catch (SqlException sqlExc)
            {
                if (sqlExc.Class == 14)
                    throw new Exception("Ya existe un proyecto con ese nombre");
                else
                    throw;
            }
        }

        public DataTable obtenerTodosDataTable(Usuario usuario)
        {
            SqlConnection con = new SqlConnection(cadenaDeConexion);
            SqlCommand cmd = new SqlCommand();
            DataTable tabla = new DataTable();
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                    cmd.Connection = con;
                }
                string sql = @"SELECT p.idProyecto, p.nombre, CONVERT(VARCHAR(10), p.fecha, 103) as fecha, COUNT(DISTINCT c.idCriterio) as cantCriterios, COUNT(DISTINCT a.idAlternativa) as cantAlternativas, COUNT(DISTINCT v.idVariable) as cantVariables
	                            FROM Proyectos p, Criterios c, Alternativas a, Variables v 
	                            WHERE p.idProyecto=c.idProyecto AND p.idProyecto=a.idProyecto AND p.idProyecto=v.idProyecto AND P.idUsuario=@idUsuario
	                            GROUP BY p.idProyecto, p.nombre, fecha";
                cmd.Parameters.Clear();
                cmd.Parameters.Add(new SqlParameter("@idUsuario", usuario.idUsuario));
                cmd.CommandText = sql;

                tabla.Load(cmd.ExecuteReader());
                return tabla;
            }
            catch (Exception)
            {
                throw new Exception("Error al obtener los Proyectos del Usuario");
            }
        }
    }
}
