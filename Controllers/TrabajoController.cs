using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _06Publicaciones.config;

namespace _06Publicaciones.Controllers
{
    public class TrabajoController
    {
        public Trabajo InsertarTrabajo(Trabajo trabajo)
        {
            return Trabajo.Insertar(trabajo);
        }

        public string ActualizarTrabajo(Trabajo trabajo)
        {
            return Trabajo.Actualizar(trabajo);
        }

        public string EliminarTrabajo(int idTrabajo)
        {
            return Trabajo.Eliminar(idTrabajo);
        }

        public Trabajo ObtenerTrabajoPorId(int idTrabajo)
        {
            return Trabajo.ObtenerPorId(idTrabajo);
        }

        public List<Trabajo> ObtenerTodosLosTrabajos()
        {
            return Trabajo.ObtenerTodos();
        }
    }
}
