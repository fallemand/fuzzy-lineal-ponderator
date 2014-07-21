using Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos
{
    public class DAOAlternativa
    {
        public string cadenaDeConexion = System.Configuration.ConfigurationManager.ConnectionStrings["localhost"].ConnectionString;

        public int registrarAlternativa(Alternativa alternativa)
        {
            SqlConnection con = new SqlConnection(cadenaDeConexion);
            SqlCommand cmd = new SqlCommand();
            SqlTransaction trans = null;
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                    trans = con.BeginTransaction();
                    cmd.Connection = con;
                    cmd.Transaction = trans;
                }
                string sql = @"INSERT INTO Alternativas(idProyecto, nombre, abreviacion, color)
                              VALUES (@idProyecto, @nombre, @abreviacion, @color) SELECT SCOPE_IDENTITY()";
                cmd.Parameters.Clear();
                cmd.Parameters.Add(new SqlParameter("@idProyecto", alternativa.idProyecto));
                cmd.Parameters.Add(new SqlParameter("@nombre", alternativa.nombre));
                cmd.Parameters.Add(new SqlParameter("@abreviacion", alternativa.abreviacion));
                cmd.Parameters.Add(new SqlParameter("@color", alternativa.color));
                cmd.CommandText = sql;
                int idAlternativa = int.Parse(cmd.ExecuteScalar().ToString());
                foreach (DetalleAlternativa valoracion in alternativa.listaDetallesAlternativa)
                {
                    sql = @"INSERT INTO DetallesAlternativa(idAlternativa, idCriterio, idVariable)
                              VALUES (@idAlternativa, @idCriterio, @idVariable)";
                    cmd.Parameters.Clear();
                    cmd.Parameters.Add(new SqlParameter("@idAlternativa", idAlternativa));
                    cmd.Parameters.Add(new SqlParameter("@idCriterio", valoracion.criterio.idCriterio));
                    cmd.Parameters.Add(new SqlParameter("@idVariable", valoracion.variable.idVariable));
                    cmd.CommandText = sql;
                    cmd.ExecuteNonQuery();
                }
                trans.Commit();
                return idAlternativa;
            }
            catch (SqlException sqlExc)
            {
                trans.Rollback();
                if (sqlExc.Class == 14)
                    throw new Exception("Ya existe valoración para ese criterio");
                else
                    throw;
            }
            finally
            {
                if (con != null && con.State == ConnectionState.Open)
                    con.Close();
            }
        }

        public List<Alternativa> obtenerAlternativasPorProyecto(int idProyecto)
        {
            SqlConnection con = new SqlConnection(cadenaDeConexion);
            SqlCommand cmd = new SqlCommand();
            List<Alternativa> alternativas = new List<Alternativa>(); ;
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                    cmd.Connection = con;
                }
                string sql = @"SELECT * FROM Alternativas WHERE idProyecto = @idProyecto";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@idProyecto", idProyecto);
                cmd.CommandText = sql;
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    Alternativa alternativa = new Alternativa()
                    {
                        idAlternativa = Int32.Parse(dr["idAlternativa"].ToString()),
                        idProyecto = Int32.Parse(dr["idProyecto"].ToString()),
                        nombre = dr["nombre"].ToString(),
                        abreviacion = dr["abreviacion"].ToString(),
                        color = dr["color"].ToString()
                    };
                    alternativas.Add(alternativa);
                }
                return alternativas;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al intentar recuperar las alternativas del proyecto: " + ex.Message);
            }
            finally
            {
                if (con != null && con.State == ConnectionState.Open)
                    con.Close();
            }
        }

        public Alternativa obtenerAlternativaPorId(int idAlternativa)
        {
            SqlConnection con = new SqlConnection(cadenaDeConexion);
            SqlCommand cmd = new SqlCommand();
            Alternativa alternativa = new Alternativa();
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                    cmd.Connection = con;
                }
                string sql = @"SELECT * FROM Alternativas WHERE idAlternativa = @idAlternativa";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@idAlternativa", idAlternativa);
                cmd.CommandText = sql;
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    alternativa = new Alternativa()
                    {
                        idAlternativa = Int32.Parse(dr["idAlternativa"].ToString()),
                        idProyecto = Int32.Parse(dr["idProyecto"].ToString()),
                        nombre = dr["nombre"].ToString(),
                        abreviacion = dr["abreviacion"].ToString(),
                        color = dr["color"].ToString()
                    };
                }
                return alternativa;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al intentar recuperar la alternativa: " + ex.Message);
            }
            finally
            {
                if (con != null && con.State == ConnectionState.Open)
                    con.Close();
            }
        }

        public List<DetalleAlternativa> obtenerDetallesAlternativa(int idAlternativa)
        {
            SqlConnection con = new SqlConnection(cadenaDeConexion);
            SqlCommand cmd = new SqlCommand();
            List<DetalleAlternativa> valoraciones = new List<DetalleAlternativa>(); ;
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                    cmd.Connection = con;
                }
                string sql = @"SELECT * FROM DetallesAlternativa WHERE idAlternativa = @idAlternativa";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@idAlternativa", idAlternativa);
                cmd.CommandText = sql;
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    DetalleAlternativa detalleAlternativa = new DetalleAlternativa();
                    detalleAlternativa.criterio.idCriterio = Int32.Parse(dr["idCriterio"].ToString());
                    detalleAlternativa.variable.idVariable = Int32.Parse(dr["idVariable"].ToString());
                    valoraciones.Add(detalleAlternativa);
                }
                return valoraciones;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al intentar el detalle de la alternaitva: " + ex.Message);
            }
            finally
            {
                if (con != null && con.State == ConnectionState.Open)
                    con.Close();
            }
        }

        public void modificarAlternativa(Alternativa alternativaNueva, int idAlternativa)
        {
            SqlConnection con = new SqlConnection(cadenaDeConexion);
            SqlCommand cmd = new SqlCommand();
            SqlTransaction trans = null;
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                    trans = con.BeginTransaction();
                    cmd.Connection = con;
                    cmd.Transaction = trans;
                }
                string sql = @"UPDATE Alternativas SET idProyecto=@idProyecto, nombre=@nombre, abreviacion=@abreviacion, color=@color WHERE idAlternativa=@idAlternativa";
                cmd.Parameters.Clear();
                cmd.Parameters.Add(new SqlParameter("@idProyecto", alternativaNueva.idProyecto));
                cmd.Parameters.Add(new SqlParameter("@nombre", alternativaNueva.nombre));
                cmd.Parameters.Add(new SqlParameter("@abreviacion", alternativaNueva.abreviacion));
                cmd.Parameters.Add(new SqlParameter("@color", alternativaNueva.color));
                cmd.Parameters.Add(new SqlParameter("@idAlternativa", idAlternativa));
                cmd.CommandText = sql;
                cmd.ExecuteNonQuery().ToString();
                foreach (DetalleAlternativa detalleAlternativa in alternativaNueva.listaDetallesAlternativa)
                {
                    sql = @"UPDATE DetallesAlternativa SET idVariable=@idVariable WHERE idCriterio=@idCriterio AND idAlternativa=@idAlternativa";
                    cmd.Parameters.Clear();
                    cmd.Parameters.Add(new SqlParameter("@idCriterio", detalleAlternativa.criterio.idCriterio));
                    cmd.Parameters.Add(new SqlParameter("@idVariable", detalleAlternativa.variable.idVariable));
                    cmd.Parameters.Add(new SqlParameter("@idAlternativa", idAlternativa));
                    cmd.CommandText = sql;
                    int filasAfectadas = cmd.ExecuteNonQuery();
                    if (filasAfectadas == 0)
                    {
                        sql = @"INSERT INTO DetallesAlternativa(idVariable, idCriterio, idAlternativa) VALUES(@idVariable, @idCriterio, @idAlternativa)";
                        cmd.Parameters.Clear();
                        cmd.Parameters.Add(new SqlParameter("@idCriterio", detalleAlternativa.criterio.idCriterio));
                        cmd.Parameters.Add(new SqlParameter("@idVariable", detalleAlternativa.variable.idVariable));
                        cmd.Parameters.Add(new SqlParameter("@idAlternativa", idAlternativa));
                        cmd.CommandText = sql;
                        cmd.ExecuteNonQuery();
                    }
                }
                trans.Commit();
            }
            catch (SqlException sqlExc)
            {
                trans.Rollback();
                if (sqlExc.Class == 14)
                    throw new Exception("Ya existe valoración para ese criterio");
                else
                    throw;
            }
            finally
            {
                if (con != null && con.State == ConnectionState.Open)
                    con.Close();
            }
        }

        public void eliminarAlternativaPorId(int idAlternativa)
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
                string sql = @"DELETE FROM Alternativas WHERE idAlternativa = @idAlternativa";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@idAlternativa", idAlternativa);
                cmd.CommandText = sql;
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al intentar eliminar la Alternativa: " + ex.Message);
            }
            finally
            {
                if (con != null && con.State == ConnectionState.Open)
                    con.Close();
            }
        }

        public int obtenerCantAlternativasPorProyecto(int idProyecto)
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
                string sql = @"SELECT COUNT(idAlternativa) FROM Alternativas WHERE idProyecto=@idProyecto ";
                cmd.Parameters.Clear();
                cmd.Parameters.Add(new SqlParameter("@idProyecto", idProyecto));
                cmd.CommandText = sql;
                return int.Parse(cmd.ExecuteScalar().ToString());
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo obtener la cantidad de alternativas del proyecto");
            }
            finally
            {
                if (con != null && con.State == ConnectionState.Open)
                    con.Close();
            }
        }

        public List<string> obtenerValoracionesCriteriosPorProyecto(int idProyecto, int idAlternativa)
        {
            SqlConnection con = new SqlConnection(cadenaDeConexion);
            SqlCommand cmd = new SqlCommand();
            List<string> lista = new List<string>(); ;
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                    cmd.Connection = con;
                }
                string sql = @"SELECT v.abreviacion FROM Criterios c 
	                            LEFT OUTER JOIN DetallesAlternativa da ON c.idCriterio=da.idCriterio and idAlternativa=@idAlternativa 
	                            LEFT OUTER JOIN Variables v ON da.idVariable=v.idVariable
	                            WHERE c.idProyecto=@idProyecto
                                ORDER BY c.idCriterio";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@idProyecto", idProyecto);
                cmd.Parameters.AddWithValue("@idAlternativa", idAlternativa);
                cmd.CommandText = sql;
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    if (dr["abreviacion"].ToString().Equals(""))
                        lista.Add("-");
                    else
                        lista.Add(dr["abreviacion"].ToString());
                }
                return lista;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al intentar recuperar el detalle de la alternativa: " + ex.Message);
            }
            finally
            {
                if (con != null && con.State == ConnectionState.Open)
                    con.Close();
            }
        }
    }
}
