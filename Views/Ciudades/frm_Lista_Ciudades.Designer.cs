namespace _06Publicaciones.Views.Ciudades
{
    partial class frm_Lista_Ciudades
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.btn_Eliminar = new System.Windows.Forms.Button();
            this.btn_Agregar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.pubsDataSet = new _06Publicaciones.pubsDataSet();
            this.paisesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.paisesTableAdapter = new _06Publicaciones.pubsDataSetTableAdapters.PaisesTableAdapter();
            this.dgvCiudades = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.pubsDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.paisesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCiudades)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_Eliminar
            // 
            this.btn_Eliminar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Eliminar.Location = new System.Drawing.Point(585, 470);
            this.btn_Eliminar.Name = "btn_Eliminar";
            this.btn_Eliminar.Size = new System.Drawing.Size(171, 36);
            this.btn_Eliminar.TabIndex = 7;
            this.btn_Eliminar.Text = "Eliminar Ciudad";
            this.btn_Eliminar.UseVisualStyleBackColor = true;
            this.btn_Eliminar.Click += new System.EventHandler(this.btn_Eliminar_Click);
            // 
            // btn_Agregar
            // 
            this.btn_Agregar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Agregar.Location = new System.Drawing.Point(33, 470);
            this.btn_Agregar.Name = "btn_Agregar";
            this.btn_Agregar.Size = new System.Drawing.Size(171, 36);
            this.btn_Agregar.TabIndex = 6;
            this.btn_Agregar.Text = "Nueva Ciudad";
            this.btn_Agregar.UseVisualStyleBackColor = true;
            this.btn_Agregar.Click += new System.EventHandler(this.btn_Agregar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(28, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(169, 25);
            this.label1.TabIndex = 4;
            this.label1.Text = "Lista de Ciudades";
            // 
            // pubsDataSet
            // 
            this.pubsDataSet.DataSetName = "pubsDataSet";
            this.pubsDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // paisesBindingSource
            // 
            this.paisesBindingSource.DataMember = "Paises";
            this.paisesBindingSource.DataSource = this.pubsDataSet;
            // 
            // paisesTableAdapter
            // 
            this.paisesTableAdapter.ClearBeforeFill = true;
            // 
            // dgvCiudades
            // 
            this.dgvCiudades.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCiudades.Location = new System.Drawing.Point(33, 62);
            this.dgvCiudades.Name = "dgvCiudades";
            this.dgvCiudades.RowHeadersWidth = 51;
            this.dgvCiudades.RowTemplate.Height = 24;
            this.dgvCiudades.Size = new System.Drawing.Size(723, 377);
            this.dgvCiudades.TabIndex = 8;
            this.dgvCiudades.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCiudades_CellContentClick);
            // 
            // frm_Lista_Ciudades
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(823, 527);
            this.Controls.Add(this.dgvCiudades);
            this.Controls.Add(this.btn_Eliminar);
            this.Controls.Add(this.btn_Agregar);
            this.Controls.Add(this.label1);
            this.Name = "frm_Lista_Ciudades";
            this.Text = "Formulario de Lista de Ciudades";
            this.Load += new System.EventHandler(this.frm_Lista_Ciudades_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pubsDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.paisesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCiudades)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_Eliminar;
        private System.Windows.Forms.Button btn_Agregar;
        private System.Windows.Forms.Label label1;
        private pubsDataSet pubsDataSet;
        private System.Windows.Forms.BindingSource paisesBindingSource;
        private pubsDataSetTableAdapters.PaisesTableAdapter paisesTableAdapter;
        private System.Windows.Forms.DataGridView dgvCiudades;
    }
}