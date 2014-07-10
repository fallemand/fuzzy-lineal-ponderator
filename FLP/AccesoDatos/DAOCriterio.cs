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
                string sql = @"INSERT INTO Criterios(idProyecto, nombre, abreviacion, peso, color)
                              VALUES (@idProyecto, @nombre, @abreviacion, @peso, @color) SELECT SCOPE_IDENTITY()";
                cmd.Parameters.Clear();
                cmd.Parameters.Add(new SqlParameter("@idProyecto", proyecto.idProyecto));
                cmd.Parameters.Add(new SqlParameter("@nombre", criterio.nombre));
                cmd.Parameters.Add(new SqlParameter("@abreviacion", criterio.abreviacion));
                cmd.Parameters.Add(new SqlParameter("@peso", criterio.peso));
                cmd.Parameters.Add(new SqlParameter("@color", criterio.color));
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
        }
    }
}
