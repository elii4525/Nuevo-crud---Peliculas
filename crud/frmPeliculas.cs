using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Modelos;

namespace crud
{
    public partial class frmPeliculas : Form
    {
        public frmPeliculas()
        {
            InitializeComponent();
        }

        private void frmPeliculas_Load_1(object sender, EventArgs e)
        {
            MostrarPeliculas();
        }
        private void MostrarPeliculas()
        {
            // Cargar las peliculas al DataGridView
            dgvPeliculas.DataSource = null;
            dgvPeliculas.DataSource = Peliculas.CargarPeliculas();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(txtNombre.Text) || string.IsNullOrEmpty(txtDirector.Text))
            {
                if (string.IsNullOrEmpty(txtNombre.Text) && string.IsNullOrEmpty(txtDirector.Text))
                {
                    lblErrorD.Visible = true;
                    lblErrorD.ForeColor = Color.Red;
                    lblErrorD.Text = "Campo vacío";
                    lblError.Visible = true;
                    lblError.ForeColor = Color.Red;
                    lblError.Text = "Campo vacío";
                }
                else
                {
                    if (string.IsNullOrEmpty(txtNombre.Text))
                    {
                        lblErrorD.Visible = false;
                        lblError.Visible = true;
                        lblError.ForeColor = Color.Red;
                        lblError.Text = "Campo vacío";
                    }
                    else
                    {
                        lblError.Visible = false;
                        lblErrorD.Visible = true;
                        lblErrorD.ForeColor = Color.Red;
                        lblErrorD.Text = "Campo vacío";
                    }
                }
               
            }
            else
            {
                lblError.Visible = false;
                lblErrorD.Visible = false;
                Peliculas p = new Peliculas();
                p.Nombre = txtNombre.Text;
                p.FechaLanzamiento = dtpFecha.Value;
                p.Director = txtDirector.Text;

                p.InsertarPeliculas();
                MostrarPeliculas();
            } 


        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            Peliculas p = new Peliculas();
            p.Nombre = txtNombre.Text;
            p.Director = txtDirector.Text;
            p.FechaLanzamiento = dtpFecha.Value;
            p.Id = int.Parse(dgvPeliculas.CurrentRow.Cells[0].Value.ToString());

            if (p.ActualizarPeliculas() == true)
            {
                MostrarPeliculas();
            }
            else
            {
                MessageBox.Show("Hubo un error", "Error");
            }
        }
     

        private void dgvPeliculas_DoubleClick(object sender, EventArgs e)
        {
            txtNombre.Text = dgvPeliculas.CurrentRow.Cells[1].Value.ToString();
            txtDirector.Text = dgvPeliculas.CurrentRow.Cells[2].Value.ToString();
            dtpFecha.Value = DateTime.Parse(dgvPeliculas.CurrentRow.Cells[3].Value.ToString());
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            txtNombre.Clear();
            txtDirector.Clear();
            lblErrorD.Visible = false;
            lblError.Visible = false;
            int id = int.Parse(dgvPeliculas.CurrentRow.Cells[0].Value.ToString());
            Peliculas p = new Peliculas();
            if (p.EliminarPelicula(id) == true)
            {
                MessageBox.Show("Registro elimiando satisfactoriamente", "Éxito");
                MostrarPeliculas();
            }
            else
            {
                MessageBox.Show("Se produjo un error", "Advertencia");
            }
                
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                dgvPeliculas.DataSource = null;
                dgvPeliculas.DataSource = Peliculas.Buscar(txtBuscar.Text);
            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
