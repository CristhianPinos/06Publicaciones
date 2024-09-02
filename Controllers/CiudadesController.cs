using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _06Publicaciones.Models;
using System.Data;

namespace _06Publicaciones.Controllers
{
    internal class CiudadesController
    {
        CiudadesModel _ciudadesModel = new CiudadesModel();
        public DataTable todosconrelacion() {
        return _ciudadesModel.todosconrelacion();
        }
        public CiudadesModel ObtenerCiudadPorId(int id)
        {
            return _ciudadesModel.ObtenerPorId(id);
        }
        public void ActualizarCiudad(CiudadesModel ciudad)
        {
            _ciudadesModel.Actualizar(ciudad);
        }
        public void EliminarCiudad(int idCiudad)
        {
            _ciudadesModel.Eliminar(idCiudad);
        }
        public void InsertarCiudad(CiudadesModel ciudad)
        {
            _ciudadesModel.Insertar(ciudad);
        }
    }
}
