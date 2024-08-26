using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using _06Publicaciones.config;

namespace _06Publicaciones
{
    public class Empleado
    {
        public string IdEmpleado { get; set; }
        public string Nombre { get; set; }
        public string MInit { get; set; }
        public string Apellido { get; set; }
        public string IdTrabajo { get; set; }
        public string NivelTrabajo { get; set; }
        public string IdPub { get; set; }
        public DateTime HireDate { get; set; }

        public Empleado() { }

        public static Empleado Insertar(Empleado empleado)
        {
            try
            {
                using (var conexion = Conexion.GetConnection())
                {
                    var consulta = "INSERT INTO employee (emp_id, fname, minit, lname, job_id, job_lvl, pub_id, hire_date) " +
                                   "VALUES (@IdEmpleado, @Nombre, @MInit, @Apellido, @IdTrabajo, @NivelTrabajo, @IdPub, @HireDate); " +
                                   "SELECT * FROM employee WHERE emp_id = @IdEmpleado;";

                    using (var comando = new SqlCommand(consulta, conexion))
                    {
                        comando.Parameters.AddWithValue("@IdEmpleado", empleado.IdEmpleado);
                        comando.Parameters.AddWithValue("@Nombre", empleado.Nombre);
                        comando.Parameters.AddWithValue("@MInit", empleado.MInit);
                        comando.Parameters.AddWithValue("@Apellido", empleado.Apellido);
                        comando.Parameters.AddWithValue("@IdTrabajo", empleado.IdTrabajo);
                        comando.Parameters.AddWithValue("@NivelTrabajo", empleado.NivelTrabajo);
                        comando.Parameters.AddWithValue("@IdPub", empleado.IdPub);
                        comando.Parameters.AddWithValue("@HireDate", empleado.HireDate);

                        using (var lector = comando.ExecuteReader())
                        {
                            if (lector.Read())
                            {
                                return new Empleado
                                {
                                    IdEmpleado = lector["emp_id"].ToString(),
                                    Nombre = lector["fname"].ToString(),
                                    MInit = lector["minit"].ToString(),
                                    Apellido = lector["lname"].ToString(),
                                    IdTrabajo = lector["job_id"].ToString(),
                                    NivelTrabajo = lector["job_lvl"].ToString(),
                                    IdPub = lector["pub_id"].ToString(),
                                    HireDate = Convert.ToDateTime(lector["hire_date"].ToString())
                                };
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                ErrorHandler.ManejarErrorSql(ex, "Error al insertar el empleado.");
            }
            catch (Exception ex)
            {
                ErrorHandler.ManejarErrorGeneral(ex, "Error al insertar el empleado.");
            }
            return null;
        }

        public static string Actualizar(Empleado empleado)
        {
            try
            {
                using (var conexion = Conexion.GetConnection())
                {
                    var consulta = "UPDATE employee SET fname = @Nombre, minit = @MInit, lname = @Apellido, job_id = @IdTrabajo, " +
                                   "job_lvl = @NivelTrabajo, pub_id = @IdPub, hire_date = @HireDate WHERE emp_id = @IdEmpleado";

                    using (var comando = new SqlCommand(consulta, conexion))
                    {
                        comando.Parameters.AddWithValue("@IdEmpleado", empleado.IdEmpleado);
                        comando.Parameters.AddWithValue("@Nombre", empleado.Nombre);
                        comando.Parameters.AddWithValue("@MInit", empleado.MInit);
                        comando.Parameters.AddWithValue("@Apellido", empleado.Apellido);
                        comando.Parameters.AddWithValue("@IdTrabajo", empleado.IdTrabajo);
                        comando.Parameters.AddWithValue("@NivelTrabajo", empleado.NivelTrabajo);
                        comando.Parameters.AddWithValue("@IdPub", empleado.IdPub);
                        comando.Parameters.AddWithValue("@HireDate", empleado.HireDate);

                        comando.ExecuteNonQuery();
                    }
                }
                return "OK";
            }
            catch (SqlException ex)
            {
                ErrorHandler.ManejarErrorSql(ex, "Error al actualizar el empleado.");
                return "Error SQL";
            }
            catch (Exception ex)
            {
                ErrorHandler.ManejarErrorGeneral(ex, "Error al actualizar el empleado.");
                return "Error";
            }
        }
        public static string Eliminar(string idEmpleado)
        {
            try
            {
                using (var conexion = Conexion.GetConnection())
                {
                    var consulta = "DELETE FROM employee WHERE emp_id = @IdEmpleado";

                    using (var comando = new SqlCommand(consulta, conexion))
                    {
                        comando.Parameters.AddWithValue("@IdEmpleado", idEmpleado);
                        comando.ExecuteNonQuery();
                    }
                }
                return "OK";
            }
            catch (SqlException ex)
            {
                ErrorHandler.ManejarErrorSql(ex, "Error al eliminar el empleado.");
                return "Error SQL";
            }
            catch (Exception ex)
            {
                ErrorHandler.ManejarErrorGeneral(ex, "Error al eliminar el empleado.");
                return "Error";
            }
        }
        public static Empleado ObtenerPorId(string idEmpleado)
        {
            try
            {
                using (var conexion = Conexion.GetConnection())
                {
                    var consulta = "SELECT * FROM employee WHERE emp_id = @IdEmpleado";

                    using (var comando = new SqlCommand(consulta, conexion))
                    {
                        comando.Parameters.AddWithValue("@IdEmpleado", idEmpleado);

                        using (var lector = comando.ExecuteReader())
                        {
                            if (lector.Read())
                            {
                                return new Empleado
                                {
                                    IdEmpleado = lector["emp_id"].ToString(),
                                    Nombre = lector["fname"].ToString(),
                                    MInit = lector["minit"].ToString(),
                                    Apellido = lector["lname"].ToString(),
                                    IdTrabajo = lector["job_id"].ToString(),
                                    NivelTrabajo = lector["job_lvl"].ToString(),
                                    IdPub = lector["pub_id"].ToString(),
                                    HireDate = Convert.ToDateTime(lector["hire_date"].ToString())
                                };
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                ErrorHandler.ManejarErrorSql(ex, "Error al obtener el empleado.");
            }
            catch (Exception ex)
            {
                ErrorHandler.ManejarErrorGeneral(ex, "Error al obtener el empleado.");
            }
            return null;
        }
        public static List<Empleado> ObtenerTodos()
        {
            var empleados = new List<Empleado>();

            try
            {
                using (var conexion = Conexion.GetConnection())
                {
                    var consulta = "SELECT * FROM employee";

                    using (var comando = new SqlCommand(consulta, conexion))
                    {
                        using (var lector = comando.ExecuteReader())
                        {
                            while (lector.Read())
                            {
                                empleados.Add(new Empleado
                                {
                                    IdEmpleado = lector["emp_id"].ToString(),
                                    Nombre = lector["fname"].ToString(),
                                    MInit = lector["minit"].ToString(),
                                    Apellido = lector["lname"].ToString(),
                                    IdTrabajo = lector["job_id"].ToString(),
                                    NivelTrabajo = lector["job_lvl"].ToString(),
                                    IdPub = lector["pub_id"].ToString(),
                                    HireDate = Convert.ToDateTime(lector["hire_date"].ToString())
                                });
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                ErrorHandler.ManejarErrorSql(ex, "Error al obtener la lista de empleados.");
            }
            catch (Exception ex)
            {
                ErrorHandler.ManejarErrorGeneral(ex, "Error al obtener la lista de empleados.");
            }

            return empleados;
        }
    }
}