using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using _06Publicaciones.config;

namespace _06Publicaciones.Models
{
    internal class CiudadesModel
    {
        public int IdCiudad { get; set; }
        public string Detalle { get; set; }
        public int idPais { get; set; }

        public DataTable todosconrelacion()
        {
            var cadena = "SELECT Ciudades.IdCiudad, Ciudades.Detalle as Ciudad, Paises.IdPais, Paises.Detalle AS 'Pais' FROM Ciudades INNER JOIN Paises ON Ciudades.idPais = Paises.IdPais";
            using (var cn = Conexion.GetConnection()) {
                try
                {
                    SqlDataAdapter adaptador = new SqlDataAdapter(cadena, cn);
                    DataTable tabla = new DataTable();
                    adaptador.Fill(tabla);
                    return tabla;
                }
                catch (SqlException ex)
                {
                    ErrorHandler.ManejarErrorSql(ex, "Error");
                }
                catch (Exception ex)
                {
                    ErrorHandler.ManejarErrorGeneral(ex, "Error general");
                }
                return null;
            }
        }
        public CiudadesModel ObtenerPorId(int id)
        {
            using (var cn = Conexion.GetConnection())
            {
                try
                {
                    string query = "SELECT IdCiudad, Detalle, IdPais FROM Ciudades WHERE IdCiudad = @IdCiudad";
                    using (SqlCommand cmd = new SqlCommand(query, cn))
                    {
                        cmd.Parameters.AddWithValue("@IdCiudad", id);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return new CiudadesModel
                                {
                                    IdCiudad = Convert.ToInt32(reader["IdCiudad"]),
                                    Detalle = reader["Detalle"].ToString(),
                                    idPais = Convert.ToInt32(reader["IdPais"])
                                };
                            }
                        }
                    }
                }
                catch (SqlException ex)
                {
                    ErrorHandler.ManejarErrorSql(ex, "Error al obtener la ciudad por ID");
                }
                catch (Exception ex)
                {
                    ErrorHandler.ManejarErrorGeneral(ex, "Error general al obtener la ciudad por ID");
                }
            }
            return null;
        }
        public void Actualizar(CiudadesModel ciudad)
        {
            using (var cn = Conexion.GetConnection())
            {
                try
                {
                    string query = "UPDATE Ciudades SET Detalle = @Detalle, idPais = @idPais WHERE IdCiudad = @IdCiudad";
                    using (SqlCommand cmd = new SqlCommand(query, cn))
                    {
                        cmd.Parameters.AddWithValue("@Detalle", ciudad.Detalle);
                        cmd.Parameters.AddWithValue("@idPais", ciudad.idPais);
                        cmd.Parameters.AddWithValue("@IdCiudad", ciudad.IdCiudad);

                        cmd.ExecuteNonQuery();
                    }
                }
                catch (SqlException ex)
                {
                    ErrorHandler.ManejarErrorSql(ex, "Error al actualizar la ciudad");
                }
                catch (Exception ex)
                {
                    ErrorHandler.ManejarErrorGeneral(ex, "Error general al actualizar la ciudad");
                }
            }
        }
        public void Eliminar(int idCiudad)
        {
            using (var cn = Conexion.GetConnection())
            {
                try
                {
                    string query = "DELETE FROM Ciudades WHERE IdCiudad = @IdCiudad";
                    using (SqlCommand cmd = new SqlCommand(query, cn))
                    {
                        cmd.Parameters.AddWithValue("@IdCiudad", idCiudad);
                        cmd.ExecuteNonQuery();
                    }
                }
                catch (SqlException ex)
                {
                    ErrorHandler.ManejarErrorSql(ex, "Error al eliminar la ciudad");
                }
                catch (Exception ex)
                {
                    ErrorHandler.ManejarErrorGeneral(ex, "Error general al eliminar la ciudad");
                }
            }
        }
        public void Insertar(CiudadesModel ciudad)
        {
            using (var cn = Conexion.GetConnection())
            {
                try
                {
                    string query = "INSERT INTO Ciudades (Detalle, idPais) VALUES (@Detalle, @idPais)";
                    using (SqlCommand cmd = new SqlCommand(query, cn))
                    {
                        cmd.Parameters.AddWithValue("@Detalle", ciudad.Detalle);
                        cmd.Parameters.AddWithValue("@idPais", ciudad.idPais);
                        cmd.ExecuteNonQuery();
                    }
                }
                catch (SqlException ex)
                {
                    ErrorHandler.ManejarErrorSql(ex, "Error al insertar la ciudad");
                }
                catch (Exception ex)
                {
                    ErrorHandler.ManejarErrorGeneral(ex, "Error general al insertar la ciudad");
                }
            }
        }
    }
}

