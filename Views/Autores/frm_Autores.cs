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

namespace _06Publicaciones.Views.Autores
{
    public partial class frm_Autores : Form
    {
        public frm_Autores()
        {
            InitializeComponent();
        }

        private void frm_Autores_Load(object sender, EventArgs e)
        {
            CargaAutores();
        }

        public void CargaAutores() {
            var listaAutores = Autor.ObtenerTodos();
            lst_Autores.DataSource = null;
            lst_Autores.DataSource = listaAutores;
            lst_Autores.DisplayMember = "NombreCompleto";
            lst_Autores.ValueMember = "IdAutor";
        }
        private void LimpiarFormulario()
        {
            textBoxIdAutor.Clear();
            textBoxApellido.Clear();
            textBoxNombre.Clear();
            textBoxTelefono.Clear();
            textBoxDireccion.Clear();
            textBoxCiudad.Clear();
            textBoxEstado.Clear();
            textBoxCodigoPostal.Clear();
        }

        private bool validarcampos(params TextBox[] cajadetexto) {
            foreach (var caja in cajadetexto) {
                if (string.IsNullOrWhiteSpace(caja.Text))
                {
                    ErrorHandler.ManejarErrorGeneral(null, "Complete la informacion");
                    return false;
                }
            }
            return true;
        }
        private void ButtonInsertar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!validarcampos(textBoxApellido, textBoxCiudad, textBoxCodigoPostal, textBoxDireccion, textBoxEstado, textBoxIdAutor, textBoxNombre, textBoxTelefono)) {
                    return;
                }
                var autor = new Autor
                {
                    IdAutor = textBoxIdAutor.Text,
                    Apellido = textBoxApellido.Text,
                    Nombre = textBoxNombre.Text,
                    Telefono = textBoxTelefono.Text,
                    Direccion = textBoxDireccion.Text,
                    Ciudad = textBoxCiudad.Text,
                    Estado = textBoxEstado.Text,
                    CodigoPostal = textBoxCodigoPostal.Text
                };

                var Insertado = Autor.Insertar(autor);
                if (Insertado != null) {
                    CargaAutores();
                    ErrorHandler.ManejarInsertar();
                }
                else {
                    return;
                }
            }
            catch (Exception ex)
            {
                ErrorHandler.ManejarErrorGeneral(ex, "");
            }
        }
        private void ButtonLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
        }
        private void buttonEditar_Click(object sender, EventArgs e)
        {
            if (lst_Autores.SelectedItem != null)
            {
                Autor autorSeleccionado = (Autor)lst_Autores.SelectedItem;

                autorSeleccionado.IdAutor = textBoxIdAutor.Text;
                autorSeleccionado.Apellido = textBoxApellido.Text;
                autorSeleccionado.Nombre = textBoxNombre.Text;
                autorSeleccionado.Telefono = textBoxTelefono.Text;
                autorSeleccionado.Direccion = textBoxDireccion.Text;
                autorSeleccionado.Ciudad = textBoxCiudad.Text;
                autorSeleccionado.Estado = textBoxEstado.Text;
                autorSeleccionado.CodigoPostal = textBoxCodigoPostal.Text;

                Autor.Actualizar(autorSeleccionado);

                CargaAutores();
                LimpiarFormulario();
                ErrorHandler.ManejarActualizar();
            }
            else
            {
                MessageBox.Show("Seleccione un autor para editar");
            }
        }

        private void buttonEliminar_Click(object sender, EventArgs e)
        {
            if (lst_Autores.SelectedItem != null)
            {
                Autor autorSeleccionado = (Autor)lst_Autores.SelectedItem;

                Autor.Eliminar(autorSeleccionado.IdAutor);

                CargaAutores();
                LimpiarFormulario();
                ErrorHandler.ManejarEliminar();
            }
        }

        private void buttonSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lst_Autores_DoubleClick(object sender, EventArgs e)
        {
            if (lst_Autores.SelectedValue != null)
            {
                var autor = Autor.ObtenerPorId(lst_Autores.SelectedValue.ToString());
                textBoxIdAutor.Text = autor.IdAutor;
                textBoxApellido.Text = autor.Apellido;
                textBoxNombre.Text = autor.Nombre;
                textBoxTelefono.Text = autor.Telefono;
                textBoxDireccion.Text = autor.Direccion;
                textBoxCiudad.Text = autor.Ciudad;
                textBoxEstado.Text = autor.Estado;
                textBoxCodigoPostal.Text = autor.CodigoPostal;
            }
            else
            {
                ErrorHandler.ManejarErrorGeneral(null, "Seleccione un item de la lista");
            }
        }

        private void lst_Autores_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBoxCodigoPostal_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxEstado_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxCiudad_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxDireccion_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxTelefono_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxNombre_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxApellido_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxIdAutor_TextChanged(object sender, EventArgs e)
        {

        }

        private void labelCodigoPostal_Click(object sender, EventArgs e)
        {

        }

        private void labelEstado_Click(object sender, EventArgs e)
        {

        }

        private void labelCiudad_Click(object sender, EventArgs e)
        {

        }

        private void labelDireccion_Click(object sender, EventArgs e)
        {

        }

        private void labelTelefono_Click(object sender, EventArgs e)
        {

        }

        private void labelNombre_Click(object sender, EventArgs e)
        {

        }

        private void labelApellido_Click(object sender, EventArgs e)
        {

        }

        private void labelIdAutor_Click(object sender, EventArgs e)
        {

        }
    }
}