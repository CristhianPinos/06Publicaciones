using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using _06Publicaciones.config;
using _06Publicaciones.Controllers;

namespace _06Publicaciones.Views.Trabajos
{
    public partial class frm_trabajo : Form
    {
        private readonly TrabajoController _trabajoController;
        public frm_trabajo()
        {
            InitializeComponent();
            _trabajoController = new TrabajoController();
        }
        private void frm_trabajo_Load(object sender, EventArgs e)
        {
            CargarTrabajos();
        }
        private void CargarTrabajos()
        {
            var listaTrabajos = _trabajoController.ObtenerTodosLosTrabajos();
            lst_Trabajos.DataSource = null;
            lst_Trabajos.DataSource = listaTrabajos;
            lst_Trabajos.DisplayMember = "Descripcion";
            lst_Trabajos.ValueMember = "IdTrabajo";
        }
        private void LimpiarFormulario()
        {
            txt_IdTrabajo.Clear();
            txt_Descripcion.Clear();
            txt_NivelMinimo.Clear();
            txt_NivelMaximo.Clear();
        }
        private bool ValidarCampos(params TextBox[] cajasTexto)
        {
            foreach (var caja in cajasTexto)
            {
                if (string.IsNullOrWhiteSpace(caja.Text))
                {
                    ErrorHandler.ManejarErrorGeneral(null, "Complete la informacion");
                    return false;
                }
            }
            return true;
        }
        private void buttonInsertar_Click(object sender, EventArgs e)
        {
            Trabajo nuevoTrabajo = new Trabajo
            {
                Descripcion = txt_Descripcion.Text,
                NivelMinimo = txt_NivelMinimo.Text,
                NivelMaximo = txt_NivelMaximo.Text
            };

            Trabajo.Insertar(nuevoTrabajo);

            CargarTrabajos();
            LimpiarFormulario();
            ErrorHandler.ManejarInsertar();
        }
        private void buttonLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
        }
        private void buttonEditar_Click(object sender, EventArgs e)
        {
            if (lst_Trabajos.SelectedItem != null)
            {
                Trabajo trabajoSeleccionado = (Trabajo)lst_Trabajos.SelectedItem;

                trabajoSeleccionado.Descripcion = txt_Descripcion.Text;
                trabajoSeleccionado.NivelMinimo = txt_NivelMinimo.Text;
                trabajoSeleccionado.NivelMaximo = txt_NivelMaximo.Text;

                Trabajo.Actualizar(trabajoSeleccionado);

                CargarTrabajos();
                LimpiarFormulario();
                ErrorHandler.ManejarActualizar();
            }
            else
            {
                MessageBox.Show("Seleccione un trabajo para editar");
            }
        }
        private void buttonEliminar_Click(object sender, EventArgs e)
        {
            if (lst_Trabajos.SelectedItem != null)
            {
                Trabajo trabajoSeleccionado = (Trabajo)lst_Trabajos.SelectedItem;

                Trabajo.Eliminar(trabajoSeleccionado.IdTrabajo);

                CargarTrabajos();
                LimpiarFormulario();
                ErrorHandler.ManejarEliminar();
            }
            else
            {
                MessageBox.Show("Seleccione un trabajo para eliminar");
            }
        }
        private void buttonSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void lst_Trabajos_DoubleClick(object sender, EventArgs e)
        {
            if (lst_Trabajos.SelectedValue != null)
            {
                var trabajo = _trabajoController.ObtenerTrabajoPorId(Convert.ToInt32(lst_Trabajos.SelectedValue));
                txt_IdTrabajo.Text = trabajo.IdTrabajo.ToString();
                txt_Descripcion.Text = trabajo.Descripcion;
                txt_NivelMinimo.Text = trabajo.NivelMinimo;
                txt_NivelMaximo.Text = trabajo.NivelMaximo;
            }
            else
            {
                ErrorHandler.ManejarErrorGeneral(null, "Seleccione un item de la lista");
            }
        }
        private void lst_Trabajos_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
