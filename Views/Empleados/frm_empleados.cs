using _06Publicaciones.config;
using _06Publicaciones.Controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _06Publicaciones.Views.Empleados
{
    public partial class frm_empleados : Form
    {
        private EmpleadoController _empleadoController;
        public frm_empleados()
        {
            InitializeComponent();
            _empleadoController = new EmpleadoController();
        }
        private void frm_empleados_Load(object sender, EventArgs e)
        {
            CargaEmpleados();
        }
        private void CargaEmpleados()
        {
            var listaEmpleados = Empleado.ObtenerTodos();
            lst_Empleados.DataSource = null;
            lst_Empleados.DataSource = listaEmpleados;
            lst_Empleados.DisplayMember = "NombreCompleto";
            lst_Empleados.ValueMember = "IdEmpleado";
        }
        private void LimpiarFormulario()
        {
            textBoxIdEmpleado.Clear();
            textBoxNombre.Clear();
            textBoxMinit.Clear();
            textBoxApellido.Clear();
            textBoxIdTrabajo.Clear();
            textBoxNivelTrabajo.Clear();
            textBoxIdPub.Clear();
            textBoxFechaContrato.Clear();
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
            try
            {
                if (!ValidarCampos(textBoxIdEmpleado, textBoxNombre, textBoxMinit, textBoxApellido, textBoxIdTrabajo, textBoxNivelTrabajo, textBoxIdPub, textBoxFechaContrato))
                {
                    return;
                }

                var empleado = new Empleado
                {
                    IdEmpleado = textBoxIdEmpleado.Text,
                    Nombre = textBoxNombre.Text,
                    MInit = textBoxMinit.Text,
                    Apellido = textBoxApellido.Text,
                    IdTrabajo = textBoxIdTrabajo.Text,
                    NivelTrabajo = textBoxNivelTrabajo.Text,
                    IdPub = textBoxIdPub.Text,
                    HireDate = DateTime.Parse(textBoxFechaContrato.Text)
                };

                var resultado = _empleadoController.InsertarEmpleado(empleado);
                if (resultado != null)
                {
                    CargaEmpleados();
                    ErrorHandler.ManejarInsertar();
                }
                else
                {
                    return;
                }
            }
            catch (Exception ex)
            {
                ErrorHandler.ManejarErrorGeneral(ex, "Error al insertar el empleado");
            }
        }
        private void buttonLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
        }
        private void buttonEditar_Click(object sender, EventArgs e)
        {
            if (lst_Empleados.SelectedItem != null)
            {
                var empleadoSeleccionado = (Empleado)lst_Empleados.SelectedItem;

                empleadoSeleccionado.IdEmpleado = textBoxIdEmpleado.Text;
                empleadoSeleccionado.Nombre = textBoxNombre.Text;
                empleadoSeleccionado.MInit = textBoxMinit.Text;
                empleadoSeleccionado.Apellido = textBoxApellido.Text;
                empleadoSeleccionado.IdTrabajo = textBoxIdTrabajo.Text;
                empleadoSeleccionado.IdPub = textBoxIdPub.Text;
                empleadoSeleccionado.HireDate = DateTime.Parse(textBoxFechaContrato.Text);

                _empleadoController.ActualizarEmpleado(empleadoSeleccionado);

                CargaEmpleados();
                LimpiarFormulario();
                ErrorHandler.ManejarActualizar();
            }
            else
            {
                MessageBox.Show("Seleccione un empleado para editar");
            }
        }
        private void buttonEliminar_Click(object sender, EventArgs e)
        {
            if (lst_Empleados.SelectedItem != null)
            {
                var empleadoSeleccionado = (Empleado)lst_Empleados.SelectedItem;

                _empleadoController.EliminarEmpleado(empleadoSeleccionado.IdEmpleado);

                CargaEmpleados();
                LimpiarFormulario();
                ErrorHandler.ManejarEliminar();
            }
            else
            {
                MessageBox.Show("Seleccione un empleado para eliminar");
            }
        }
        private void buttonSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void lst_Empleados_DoubleClick(object sender, EventArgs e)
        {
            if (lst_Empleados.SelectedValue != null)
            {
                var empleado = Empleado.ObtenerPorId(lst_Empleados.SelectedValue.ToString());
                textBoxIdEmpleado.Text = empleado.IdEmpleado;
                textBoxNombre.Text = empleado.Nombre;
                textBoxMinit.Text = empleado.MInit;
                textBoxApellido.Text = empleado.Apellido;
                textBoxIdTrabajo.Text = empleado.IdTrabajo;
                textBoxNivelTrabajo.Text = empleado.NivelTrabajo;
                textBoxIdPub.Text = empleado.IdPub;
                textBoxFechaContrato.Text = empleado.HireDate.ToShortDateString();
            }
            else
            {
                ErrorHandler.ManejarErrorGeneral(null, "Seleccione un item de la lista");
            }
        }
        private void lst_Empleados_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
