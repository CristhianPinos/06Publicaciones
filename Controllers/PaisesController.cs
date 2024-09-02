using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _06Publicaciones.Models;

namespace _06Publicaciones.Controllers
{
    internal class PaisesController
    {
        PaisModel _PaisModel = new PaisModel();
        public DataTable todos() {
            return _PaisModel.todos();
        }
    }
}
