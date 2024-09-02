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

namespace _06Publicaciones.Views.Ciudades
{
    public partial class frm_Lista_Ciudades : Form
    {
        CiudadesController _ciudadesController = new CiudadesController();
        public frm_Lista_Ciudades()
        {
            InitializeComponent();
        }

        private void frm_Lista_Ciudades_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'pubsDataSet.Paises' Puede moverla o quitarla según sea necesario.
            // this.paisesTableAdapter.Fill(this.pubsDataSet.Paises);
            // TODO: esta línea de código carga datos en la tabla 'pubsDataSet.Ciudades' Puede moverla o quitarla según sea necesario.
            // this.ciudadesTableAdapter.Fill(this.pubsDataSet.Ciudades);
            dgvCiudades.DataSource = _ciudadesController.todosconrelacion();
            /*dgvCiudades.Columns["Ciudad"].Visible = true;
            dgvCiudades.Columns["IdCiudad"].Visible = false;
            dgvCiudades.Columns["Pais"].Visible = true;
            dgvCiudades.Columns["IdPais"].Visible = false;*/

            dgvCiudades.Columns[0].Visible = false;
            dgvCiudades.Columns[1].Visible = true;
            dgvCiudades.Columns[2].Visible = false;
            dgvCiudades.Columns[3].Visible = true;

            DataGridViewButtonColumn btnGrid = new DataGridViewButtonColumn();
            btnGrid.HeaderText = "Editar";
            btnGrid.Name = "Editar";
            btnGrid.Text = "Editar";
            btnGrid.UseColumnTextForButtonValue = true;
            dgvCiudades.Columns.Add(btnGrid);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //var id = dataGridView1.Rows[e.RowIndex].Cells["idPais"].Value.ToString();
            //MessageBox.Show(id);
        }

        private void dgvCiudades_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex == dgvCiudades.Columns["Editar"].Index && e.RowIndex >= 0) {
                var id = dgvCiudades.Rows[e.RowIndex].Cells["IdCiudad"].Value.ToString();
                //MessageBox.Show(id);
                frm_Ciudades _Ciudades = new frm_Ciudades(id);
                _Ciudades.FormClosed += new FormClosedEventHandler(frm_Ciudades_FormClosed);
                _Ciudades.Show();
            }
        }
        void frm_Ciudades_FormClosed(object sender, FormClosedEventArgs e)
        {
            dgvCiudades.DataSource = _ciudadesController.todosconrelacion();
        }

        private void btn_Agregar_Click(object sender, EventArgs e)
        {
            frm_Ciudades _Ciudades = new frm_Ciudades(null);
            _Ciudades.FormClosed += new FormClosedEventHandler(frm_Ciudades_FormClosed);
            _Ciudades.Show();
        }

        private void btn_Eliminar_Click(object sender, EventArgs e)
        {
            if (dgvCiudades.SelectedRows.Count > 0)
            {
                var idCiudad = Convert.ToInt32(dgvCiudades.SelectedRows[0].Cells["IdCiudad"].Value);
                var confirmResult = MessageBox.Show("¿Seguro de que deseas eliminar esta ciudad?", "Confirmar eliminacion", MessageBoxButtons.YesNo);

                if (confirmResult == DialogResult.Yes)
                {
                    _ciudadesController.EliminarCiudad(idCiudad);
                    dgvCiudades.DataSource = _ciudadesController.todosconrelacion();
                }
            }
            else
            {
                MessageBox.Show("Selecciona una ciudad para eliminar");
            }
        }
    }
}
