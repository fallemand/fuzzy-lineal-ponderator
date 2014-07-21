using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using System.Data.SqlClient;
using System.Data;

namespace AccesoDatos
{
    public class DAOCriterio
    {
        public string cadenaDeConexion = System.Configuration.ConfigurationManager.ConnectionStrings["localhost"].ConnectionString;

        public int registrarCriterio(Criterio criterio, Proyecto proyecto)
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
                string sql = @"INSERT INTO Criterios(idProyecto, nombre, abreviacion, peso, color, esTipoMax)
                              VALUES (@idProyecto, @nombre, @abreviacion, @peso, @color, @esTipoMax) SELECT SCOPE_IDENTITY()";
                cmd.Parameters.Clear();
                cmd.Parameters.Add(new SqlParameter("@idProyecto", proyecto.idProyecto));
                cmd.Parameters.Add(new SqlParameter("@nombre", criterio.nombre));
                cmd.Parameters.Add(new SqlParameter("@abreviacion", criterio.abreviacion));
                cmd.Parameters.Add(new SqlParameter("@peso", criterio.peso));
                cmd.Parameters.Add(new SqlParameter("@color", criterio.color));
                cmd.Parameters.Add(new SqlParameter("@esTipoMax", criterio.esTipoMax));
                cmd.CommandText = sql;
                return int.Parse(cmd.ExecuteScalar().ToString());
            }
            catch (SqlException sqlExc)
            {
                if (sqlExc.Class == 14)
                    throw new Exception("Ya existe un criterio con ese nombre o abreviación");
                else
                    throw;
            }
            finally
            {
                if (con != null && con.State == ConnectionState.Open)
                    con.Close();
            }
        }

        public void modificarCriterio(Criterio criterio)
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
                string sql = @"UPDATE Criterios SET idProyecto=@idProyecto, nombre=@nombre, abreviacion=@abreviacion, peso=@peso, color=@color, esTipoMax=@esTipoMax WHERE idCriterio=@idCriterio";
                cmd.Parameters.Clear();
                cmd.Parameters.Add(new SqlParameter("@idProyecto", criterio.idProyecto));
                cmd.Parameters.Add(new SqlParameter("@nombre", criterio.nombre));
                cmd.Parameters.Add(new SqlParameter("@abreviacion", criterio.abreviacion));
                cmd.Parameters.Add(new SqlParameter("@peso", criterio.peso));
                cmd.Parameters.Add(new SqlParameter("@color", criterio.color));
                cmd.Parameters.Add(new SqlParameter("@idCriterio", criterio.idCriterio));
                cmd.Parameters.Add(new SqlParameter("@esTipoMax", criterio.esTipoMax));
                cmd.CommandText = sql;
                cmd.ExecuteNonQuery();
            }
            catch (SqlException sqlExc)
            {
                if (sqlExc.Class == 14)
                    throw new Exception("Ya existe un criterio con ese nombre o abreviación");
                else
                    throw;
            }
            finally
            {
                if (con != null && con.State == ConnectionState.Open)
                    con.Close();
            }
        }

        public DataTable obtenerCriteriosPorProyectoTable(Proyecto proyecto)
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
                string sql = @"DECLARE @pesoTotal float
                             SET @pesoTotal = (SELECT SUM(peso) FROM Criterios WHERE idProyecto=@idProyecto)
                             SELECT idCriterio, nombre, abreviacion, color, peso, esTipoMax, CONVERT(FLOAT, ROUND(peso/@pesoTotal, 2, 1)) as pesoRelativo FROM Criterios WHERE idProyecto=@idProyecto";
                cmd.Parameters.Clear();
                cmd.Parameters.Add(new SqlParameter("@idProyecto", proyecto.idProyecto));
                cmd.CommandText = sql;

                tabla.Load(cmd.ExecuteReader());
                return tabla;
            }
            catch (Exception)
            {
                throw new Exception("Error al obtener los Criterios del Proyecto");
            }
            finally
            {
                if (con != null && con.State == ConnectionState.Open)
                    con.Close();
            }
        }

        public Criterio obtenerCriterioPorId(int idCriterio)
        {
            SqlConnection con = new SqlConnection(cadenaDeConexion);
            SqlCommand cmd = new SqlCommand();
            Criterio criterio = null;
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                    cmd.Connection = con;
                }
                string sql = @"SELECT * FROM Criterios WHERE idCriterio = @idCriterio";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@idCriterio", idCriterio);
                cmd.CommandText = sql;
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    criterio = new Criterio();
                    criterio.idCriterio = Int32.Parse(dr["idCriterio"].ToString());
                    criterio.nombre = dr["nombre"].ToString();
                    criterio.abreviacion = dr["abreviacion"].ToString();
                    criterio.peso = Int32.Parse(dr["peso"].ToString());
                    criterio.color = dr["color"].ToString();
                    criterio.esTipoMax = bool.Parse(dr["esTipoMax"].ToString());
                    criterio.idProyecto = Int32.Parse(dr["idProyecto"].ToString());
                }
                return criterio;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al intentar recuperar el criterio: " + ex.Message);
            }
            finally
            {
                if (con != null && con.State == ConnectionState.Open)
                    con.Close();
            }
        }

        public List<Criterio> obtenerCriteriosPorProyectoList(int idProyecto)
        {
            SqlConnection con = new SqlConnection(cadenaDeConexion);
            SqlCommand cmd = new SqlCommand();
            List<Criterio> criterios = new List<Criterio>(); ;
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                    cmd.Connection = con;
                }
                string sql = @"SELECT * FROM Criterios WHERE idProyecto = @idProyecto";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@idProyecto", idProyecto);
                cmd.CommandText = sql;
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    Criterio criterio = new Criterio();
                    criterio.idCriterio = Int32.Parse(dr["idCriterio"].ToString());
                    criterio.nombre = dr["nombre"].ToString();
                    criterio.abreviacion = dr["abreviacion"].ToString();
                    criterio.peso = Int32.Parse(dr["peso"].ToString());
                    criterio.color = dr["color"].ToString();
                    criterio.esTipoMax = bool.Parse(dr["esTipoMax"].ToString());
                    criterio.idProyecto = Int32.Parse(dr["idProyecto"].ToString());
                    criterios.Add(criterio);
                }
                return criterios;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al intentar recuperar los criterios del proyecto: " + ex.Message);
            }
            finally
            {
                if (con != null && con.State == ConnectionState.Open)
                    con.Close();
            }
        }

        public void eliminarCriterioPorId(int idCriterio)
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
                string sql = @"DELETE FROM Criterios WHERE idCriterio = @idCriterio";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@idCriterio", idCriterio);
                cmd.CommandText = sql;
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al intentar eliminar el Criterio: " + ex.Message);
            }
            finally
            {
                if (con != null && con.State == ConnectionState.Open)
                    con.Close();
            }
        }

        public void eliminarCriterioPorProyecto(int idProyecto)
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
                string sql = @"DELETE FROM Criterios WHERE idProyecto = @idProyecto";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@idProyecto", idProyecto);
                cmd.CommandText = sql;
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al intentar eliminar el Criterio: " + ex.Message);
            }
            finally
            {
                if (con != null && con.State == ConnectionState.Open)
                    con.Close();
            }
        }

        public int obtenerCantCriteriosPorProyecto(int idProyecto)
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
                string sql = @"SELECT COUNT(idCriterio) FROM Criterios WHERE idProyecto=@idProyecto ";
                cmd.Parameters.Clear();
                cmd.Parameters.Add(new SqlParameter("@idProyecto", idProyecto));
                cmd.CommandText = sql;
                return int.Parse(cmd.ExecuteScalar().ToString());
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo obtener la cantidad de criterios del proyecto");
            }
            finally
            {
                if (con != null && con.State == ConnectionState.Open)
                    con.Close();
            }
        }
    }
}
