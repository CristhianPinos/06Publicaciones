using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using _06Publicaciones.Controllers;
using _06Publicaciones.Models;

namespace _06Publicaciones.Views.Ciudades
{
    public partial class frm_Ciudades: Form
    {
        private string id;
        public frm_Ciudades(string id)
        {
            InitializeComponent();
            this.id = id;
            CiudadesModel _ciudadesModel = new CiudadesModel();
        }

        private void frm_Ciudades_Load(object sender, EventArgs e)
        {
            //MessageBox.Show(this.id);
            PaisesController _paises = new PaisesController();
            comboBox1.DataSource = _paises.todos();
            comboBox1.DisplayMember = "Detalle";
            comboBox1.ValueMember = "IdPais";
            if (!string.IsNullOrEmpty(this.id))
            {
                CiudadesModel ciudadModel = new CiudadesModel();
                var ciudad = ciudadModel.ObtenerPorId(Convert.ToInt32(this.id));
                if (ciudad != null)
                {
                    textBox1.Text = ciudad.Detalle;
                    comboBox1.SelectedValue = ciudad.idPais;
                }
            }
        }

        private void btn_Guardar_Click(object sender, EventArgs e)
        {
            CiudadesModel ciudadModel = new CiudadesModel
            {
                Detalle = textBox1.Text,
                idPais = Convert.ToInt32(comboBox1.SelectedValue)
            };

            CiudadesController _ciudadesController = new CiudadesController();

            if (!string.IsNullOrEmpty(this.id))
            {
                ciudadModel.IdCiudad = Convert.ToInt32(this.id);
                _ciudadesController.ActualizarCiudad(ciudadModel);
                MessageBox.Show("Ciudad actualizada correctamente");
            }
            else
            {
                _ciudadesController.InsertarCiudad(ciudadModel);
                MessageBox.Show("Ciudad agregada correctamente");
            }

            this.Close();
        }

        private void btn_Cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
