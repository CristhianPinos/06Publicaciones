using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using _06Publicaciones.config;

namespace _06Publicaciones
{
    public class Trabajo
    {
        public int IdTrabajo { get; set; }
        public string Descripcion { get; set; }
        public string NivelMinimo { get; set; }
        public string NivelMaximo { get; set; }

        public Trabajo() { }

        public static Trabajo Insertar(Trabajo trabajo)
        {
            try
            {
                using (var conexion = Conexion.GetConnection())
                {
                    var consulta = "INSERT INTO jobs (job_desc, min_lvl, max_lvl) " +
                                   "OUTPUT INSERTED.job_id, INSERTED.job_desc, INSERTED.min_lvl, INSERTED.max_lvl " +
                                   "VALUES (@Descripcion, @NivelMinimo, @NivelMaximo)";

                    using (var comando = new SqlCommand(consulta, conexion))
                    {
                        comando.Parameters.AddWithValue("@Descripcion", trabajo.Descripcion);
                        comando.Parameters.AddWithValue("@NivelMinimo", trabajo.NivelMinimo);
                        comando.Parameters.AddWithValue("@NivelMaximo", trabajo.NivelMaximo);

                        using (var lector = comando.ExecuteReader())
                        {
                            if (lector.Read())
                            {
                                return new Trabajo
                                {
                                    IdTrabajo = Convert.ToInt32(lector["job_id"]),
                                    Descripcion = lector["job_desc"].ToString(),
                                    NivelMinimo = lector["min_lvl"].ToString(),
                                    NivelMaximo = lector["max_lvl"].ToString()
                                };
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                ErrorHandler.ManejarErrorSql(ex, "Error al insertar el trabajo.");
            }
            catch (Exception ex)
            {
                ErrorHandler.ManejarErrorGeneral(ex, "Error al insertar el trabajo.");
            }
            return null;
        }
        public static string Actualizar(Trabajo trabajo)
        {
            try
            {
                using (var conexion = Conexion.GetConnection())
                {
                    var consulta = "UPDATE jobs SET job_desc = @Descripcion, min_lvl = @NivelMinimo, max_lvl = @NivelMaximo " +
                                   "WHERE job_id = @IdTrabajo";

                    using (var comando = new SqlCommand(consulta, conexion))
                    {
                        comando.Parameters.AddWithValue("@IdTrabajo", trabajo.IdTrabajo);
                        comando.Parameters.AddWithValue("@Descripcion", trabajo.Descripcion);
                        comando.Parameters.AddWithValue("@NivelMinimo", trabajo.NivelMinimo);
                        comando.Parameters.AddWithValue("@NivelMaximo", trabajo.NivelMaximo);

                        comando.ExecuteNonQuery();
                    }
                }
                return "OK";
            }
            catch (SqlException ex)
            {
                ErrorHandler.ManejarErrorSql(ex, "Error al actualizar el trabajo.");
                return "Error SQL";
            }
            catch (Exception ex)
            {
                ErrorHandler.ManejarErrorGeneral(ex, "Error al actualizar el trabajo.");
                return "Error";
            }
        }
        public static string Eliminar(int idTrabajo)
        {
            try
            {
                using (var conexion = Conexion.GetConnection())
                {
                    var eliminarEmpleados = "DELETE FROM employee WHERE job_id = @IdTrabajo";
                    using (var comandoEmpleados = new SqlCommand(eliminarEmpleados, conexion))
                    {
                        comandoEmpleados.Parameters.AddWithValue("@IdTrabajo", idTrabajo);
                        comandoEmpleados.ExecuteNonQuery();
                    }

                    var consulta = "DELETE FROM jobs WHERE job_id = @IdTrabajo";
                    using (var comando = new SqlCommand(consulta, conexion))
                    {
                        comando.Parameters.AddWithValue("@IdTrabajo", idTrabajo);
                        comando.ExecuteNonQuery();
                    }
                }
                return "OK";
            }
            catch (SqlException ex)
            {
                ErrorHandler.ManejarErrorSql(ex, "Error al eliminar el trabajo.");
                return "Error SQL";
            }
            catch (Exception ex)
            {
                ErrorHandler.ManejarErrorGeneral(ex, "Error al eliminar el trabajo.");
                return "Error";
            }
        }
        public static Trabajo ObtenerPorId(int idTrabajo)
        {
            try
            {
                using (var conexion = Conexion.GetConnection())
                {
                    var consulta = "SELECT * FROM jobs WHERE job_id = @IdTrabajo";

                    using (var comando = new SqlCommand(consulta, conexion))
                    {
                        comando.Parameters.AddWithValue("@IdTrabajo", idTrabajo);

                        using (var lector = comando.ExecuteReader())
                        {
                            if (lector.Read())
                            {
                                return new Trabajo
                                {
                                    IdTrabajo = Convert.ToInt32(lector["job_id"]),
                                    Descripcion = lector["job_desc"].ToString(),
                                    NivelMinimo = lector["min_lvl"].ToString(),
                                    NivelMaximo = lector["max_lvl"].ToString()
                                };
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                ErrorHandler.ManejarErrorSql(ex, "Error al obtener el trabajo.");
            }
            catch (Exception ex)
            {
                ErrorHandler.ManejarErrorGeneral(ex, "Error al obtener el trabajo.");
            }
            return null;
        }
        public static List<Trabajo> ObtenerTodos()
        {
            var trabajos = new List<Trabajo>();

            try
            {
                using (var conexion = Conexion.GetConnection())
                {
                    var consulta = "SELECT * FROM jobs";

                    using (var comando = new SqlCommand(consulta, conexion))
                    {
                        using (var lector = comando.ExecuteReader())
                        {
                            while (lector.Read())
                            {
                                trabajos.Add(new Trabajo
                                {
                                    IdTrabajo = Convert.ToInt32(lector["job_id"]),
                                    Descripcion = lector["job_desc"].ToString(),
                                    NivelMinimo = lector["min_lvl"].ToString(),
                                    NivelMaximo = lector["max_lvl"].ToString()
                                });
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                ErrorHandler.ManejarErrorSql(ex, "Error al obtener la lista de trabajos.");
            }
            catch (Exception ex)
            {
                ErrorHandler.ManejarErrorGeneral(ex, "Error al obtener la lista de trabajos.");
            }

            return trabajos;
        }
    }
}
