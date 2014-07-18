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
    public class DAOVariable
    {
        public string cadenaDeConexion = System.Configuration.ConfigurationManager.ConnectionStrings["localhost"].ConnectionString;

        public int registrarVariable(Variable variable, Proyecto proyecto)
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
                string sql = @"INSERT INTO Variables(idProyecto, nombre, abreviacion, color, a, b, c)
                              VALUES (@idProyecto, @nombre, @abreviacion, @color, @a, @b, @c) SELECT SCOPE_IDENTITY()";
                cmd.Parameters.Clear();
                cmd.Parameters.Add(new SqlParameter("@idProyecto", proyecto.idProyecto));
                cmd.Parameters.Add(new SqlParameter("@nombre", variable.nombre));
                cmd.Parameters.Add(new SqlParameter("@abreviacion", variable.abreviacion));
                cmd.Parameters.Add(new SqlParameter("@color", variable.color));
                cmd.Parameters.Add(new SqlParameter("@a", variable.a));
                cmd.Parameters.Add(new SqlParameter("@b", variable.b));
                cmd.Parameters.Add(new SqlParameter("@c", variable.c));
                cmd.CommandText = sql;
                return int.Parse(cmd.ExecuteScalar().ToString());
            }
            catch (SqlException sqlExc)
            {
                if (sqlExc.Class == 14)
                    throw new Exception("Ya existe una variable con ese nombre o abreviación");
                else
                    throw;
            }
        }

        public List<Variable> obtenerVariablesPorProyecto(int idProyecto)
        {
            SqlConnection con = new SqlConnection(cadenaDeConexion);
            SqlCommand cmd = new SqlCommand();
            List<Variable> variables = new List<Variable>(); ;
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                    cmd.Connection = con;
                }
                string sql = @"SELECT * FROM Variables WHERE idProyecto = @idProyecto";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@idProyecto", idProyecto);
                cmd.CommandText = sql;
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    Variable variable = new Variable() {
                        idVariable = Int32.Parse(dr["idVariable"].ToString()),
                        idProyecto = Int32.Parse(dr["idProyecto"].ToString()),
                        nombre = dr["nombre"].ToString(),
                        abreviacion = dr["abreviacion"].ToString(),
                        color = dr["color"].ToString(),
                        a = decimal.Parse(dr["a"].ToString()),
                        b = decimal.Parse(dr["b"].ToString()),
                        c = decimal.Parse(dr["c"].ToString())
                    };
                    variables.Add(variable);
                }
                return variables;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al intentar recuperar las variables del proyecto: " + ex.Message);
            }
            finally
            {
                if (con != null && con.State == ConnectionState.Open)
                    con.Close();
            }
        }

        public Variable obtenerVariablePorId(int idVariable)
        {
            SqlConnection con = new SqlConnection(cadenaDeConexion);
            SqlCommand cmd = new SqlCommand();
            Variable variable = null;
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                    cmd.Connection = con;
                }
                string sql = @"SELECT * FROM Variables WHERE idVariable = @idVariable";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@idVariable", idVariable);
                cmd.CommandText = sql;
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    variable = new Variable() { 
                        idVariable = Int32.Parse(dr["idVariable"].ToString()),
                        idProyecto = Int32.Parse(dr["idProyecto"].ToString()),
                        nombre = dr["nombre"].ToString(),
                        abreviacion = dr["abreviacion"].ToString(),
                        color = dr["color"].ToString(),
                        a=decimal.Parse(dr["a"].ToString()),
                        b=decimal.Parse(dr["b"].ToString()),
                        c=decimal.Parse(dr["c"].ToString())
                    };
                }
                return variable;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al intentar recuperar la variable: " + ex.Message);
            }
            finally
            {
                if (con != null && con.State == ConnectionState.Open)
                    con.Close();
            }
        }

        public void modificarVariable(Variable variable)
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
                string sql = @"UPDATE Variables SET idProyecto=@idProyecto, nombre=@nombre, abreviacion=@abreviacion, color=@color, a=@a, b=@b, c=@c WHERE idVariable=@idVariable";
                cmd.Parameters.Clear();
                cmd.Parameters.Add(new SqlParameter("@idProyecto", variable.idProyecto));
                cmd.Parameters.Add(new SqlParameter("@nombre", variable.nombre));
                cmd.Parameters.Add(new SqlParameter("@abreviacion", variable.abreviacion));
                cmd.Parameters.Add(new SqlParameter("@color", variable.color));
                cmd.Parameters.Add(new SqlParameter("@a", variable.a));
                cmd.Parameters.Add(new SqlParameter("@b", variable.b));
                cmd.Parameters.Add(new SqlParameter("@c", variable.c));
                cmd.Parameters.Add(new SqlParameter("@idVariable", variable.idVariable));
                cmd.CommandText = sql;
                cmd.ExecuteNonQuery();
            }
            catch (SqlException sqlExc)
            {
                if (sqlExc.Class == 14)
                    throw new Exception("Ya existe una variablecon ese nombre o abreviación");
                else
                    throw;
            }
        }

        public void eliminarVariablePorId(int idVariable)
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
                string sql = @"DELETE FROM Variables WHERE idVariable = @idVariable";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@idVariable", idVariable);
                cmd.CommandText = sql;
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al intentar eliminar la Variable: " + ex.Message);
            }
            finally
            {
                if (con != null && con.State == ConnectionState.Open)
                    con.Close();
            }
        }
    }
}
