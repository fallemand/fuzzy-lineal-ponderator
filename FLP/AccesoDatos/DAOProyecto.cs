using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using System.Data;
using System.Globalization;

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
            finally
            {
                if (con != null && con.State == ConnectionState.Open)
                    con.Close();
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
	                            FROM Proyectos p
								LEFT OUTER JOIN Criterios c ON p.idProyecto=c.idProyecto
								LEFT OUTER JOIN Alternativas a ON p.idProyecto=a.idProyecto
								LEFT OUTER JOIN Variables v ON p.idProyecto=v.idProyecto
	                            WHERE  P.idUsuario=@idUsuario
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
            finally
            {
                if (con != null && con.State == ConnectionState.Open)
                    con.Close();
            }
        }

        public Proyecto obtenerProyectoPorId(int idProyecto)
        {
            SqlConnection con = new SqlConnection(cadenaDeConexion);
            SqlCommand cmd = new SqlCommand();
            Proyecto proyecto = null;
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                    cmd.Connection = con;
                }
                string sql = @"SELECT idProyecto, nombre, CONVERT(VARCHAR(10), fecha, 103) as fecha FROM Proyectos WHERE idProyecto = @idProyecto";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@idProyecto", idProyecto);
                cmd.CommandText = sql;
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    proyecto = new Proyecto();
                    proyecto.idProyecto = Int32.Parse(dr["idProyecto"].ToString());
                    proyecto.nombre = dr["nombre"].ToString();
                    proyecto.fecha = DateTime.ParseExact(dr["fecha"].ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
                }
                return proyecto;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al intentar recuperar el Proyecto: " + ex.Message);
            }
            finally
            {
                if (con != null && con.State == ConnectionState.Open)
                    con.Close();
            }
        }

        public void eliminarProyectoPorId(int idProyecto)
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
                string sql = @"DELETE FROM Proyectos WHERE idProyecto = @idProyecto";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@idProyecto", idProyecto);
                cmd.CommandText = sql;
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al intentar eliminar el Proyecto: " + ex.Message);
            }
            finally
            {
                if (con != null && con.State == ConnectionState.Open)
                    con.Close();
            }
        }

        public void ModificarProyecto(Proyecto proyecto)
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
                string sql = @"UPDATE Proyectos SET nombre=@nombre WHERE idProyecto = @idProyecto";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@nombre", proyecto.nombre);
                cmd.Parameters.AddWithValue("@idProyecto", proyecto.idProyecto);
                cmd.CommandText = sql;
                cmd.ExecuteNonQuery();
            }
            catch (SqlException sqlExc)
            {
                if (sqlExc.Class == 14)
                    throw new Exception("Ya existe un proyecto con ese nombre");
                else
                    throw;
            }
            finally
            {
                if (con != null && con.State == ConnectionState.Open)
                    con.Close();
            }
        }
    }
}
