﻿using ProyectoTaller2.Capa_Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoTaller2.CapaPresentacion.Administrador
{

    
    public partial class Clientes_admin : Form
    {
        public Clientes_admin()
        {
            InitializeComponent();

        }

        private void CargarClientes()
        {
            var negocioCliente = new NegocioCliente();

            var datos = negocioCliente.ListarClientes();

            dataGridView1.DataSource = datos;
            this.formato();
        }


        private void Clientes_admin_Load(object sender, EventArgs e)
        {
            btnEditar.Enabled = false;
            btnEliminar.Enabled = false;

            CargarClientes();

            foreach (DataGridViewColumn columna in dataGridView1.Columns)
            {
                comboBox1.Items.Add(new OpcionCombo() { Valor = columna.Name, Texto = columna.HeaderText });
            }

            comboBox1.DisplayMember = "Texto";
            comboBox1.ValueMember = "Valor";
            comboBox1.SelectedIndex = 0;


        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                btnEditar.Enabled = true;
                btnEliminar.Enabled = true;
            }
            else
            {
                btnEditar.Enabled = false;
                btnEliminar.Enabled = false;
            }
        }

        ErrorProvider errorP = new ErrorProvider();

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string columnaFiltro = ((OpcionCombo)comboBox1.SelectedItem).Valor.ToString();

            if (dataGridView1.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.Cells[columnaFiltro].Value.ToString().Trim().ToUpper().Contains(txtBuscarDni.Text.Trim().ToUpper()))
                        row.Visible = true;
                    else
                        row.Visible = false;
                }
            }
        }

        private void txtBuscarDni_KeyPress(object sender, KeyPressEventArgs e)
        {
            bool valida = Validar.soloNumeros(e);
            if (!valida)
                errorP.SetError(txtBuscarDni, "Solo numeros");
            else
                errorP.Clear();
        }

        private void formato()
        {
            dataGridView1.Columns[0].HeaderText = "ID";
            dataGridView1.Columns[1].HeaderText = "NOMBRE";
            dataGridView1.Columns[2].HeaderText = "APELLIDO";
            dataGridView1.Columns[3].HeaderText = "DNI";
            dataGridView1.Columns[4].HeaderText = "TELEFONO";
            dataGridView1.Columns[5].HeaderText = "DIRECCION";
            dataGridView1.Columns[6].HeaderText = "EMAIL";
            dataGridView1.Columns[7].HeaderText = "ESTADO";
            //dataGridView1.Columns[8].Visible = false;

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int posicion = dataGridView1.CurrentRow.Index;

            var msg = MessageBox.Show("Seguro desea eliminar este usuario?", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (msg == DialogResult.Yes)
            {

                //dataGridUsuarios.Rows.RemoveAt(posicion);
                dataGridView1[7, posicion].Value = "Inactivo";
                dataGridView1.Rows[posicion].DefaultCellStyle.BackColor = Color.Red;

            }
        }

        private void btnLimpiarFiltro_Click(object sender, EventArgs e)
        {
            txtBuscarDni.Text = "";
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                row.Visible = true;
            }
        }
    }
    
}
