using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EF
{
    public partial class Form1 : Form
    {
        public List<Boleta> boletas = new List<Boleta>();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }



        private void txtGrabar_Click(object sender, EventArgs e)
        {
            try
            {
                Boleta boleta = new Boleta();
                boleta.id = Convert.ToUInt32(txtId.Text);
                boleta.alumno = txtAlumno.Text;
                boleta.n1 = Convert.ToDecimal(txtN1.Text);
                boleta.n2 = Convert.ToDecimal(txtN2.Text);
                boleta.n3 = Convert.ToDecimal(txtN3.Text);

                boletas.Add(boleta);
                dgvBoletas.DataSource = null;
                dgvBoletas.DataSource = boletas;

                boleta = Calcular(boleta);

                //txtCalcular.Text = Calcular(dgvBoletas, 2).ToString();
                //txtTotalRegistros.Text = productos.Count.ToString();
                //txtTotalRegistros.Text = dgvProductos.Rows.Count.ToString();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                //throw;
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e){
            Limpiar();
        }
        void Limpiar()
        {
            txtId.Clear();
            txtAlumno.Clear();
            txtN1.Clear();
            txtN2.Clear();
            txtN3.Clear();
        }

        private void txtBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                string id = txtId.Text;
                var boleta = boletas.Where(p => p.id == Convert.ToUInt32(id)).SingleOrDefault();
                if (boleta == null)
                {
                    MessageBox.Show("Producto no encontrado");
                }
                else
                {
                    txtId.Text = Convert.ToString(boleta.id);
                    txtAlumno.Text = Convert.ToString(boleta.alumno);
                    txtN1.Text = Convert.ToString(boleta.n1);
                    txtN2.Text = Convert.ToString(boleta.n2);
                    txtN3.Text = Convert.ToString(boleta.n3);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                string id = txtId.Text;
                var boleta = boletas.Where(p => p.id == Convert.ToUInt32(id)).SingleOrDefault();
                if (boleta == null)
                {
                    MessageBox.Show("Producto no encontrado");
                }
                else
                {
                    boletas.Remove(boleta);
                    dgvBoletas.DataSource = null;
                    dgvBoletas.DataSource = boletas;
                    Limpiar();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        Boleta Calcular(Boleta boleta) {
            decimal promedio = (boleta.n1 + boleta.n2 + boleta.n3) / 3;
            string estado = "desaprobado";
            string nivel = "muy malo";
            if (promedio >= 11) {
                estado = "aprobado";
            }

            if (promedio <= 20) {
                nivel = "muy bueno";
            }
            if (promedio <= 18)
            {
                nivel = "bueno";
            }
            if (promedio <= 15)
            {
                nivel = "regular";
            }
            if (promedio <= 11)
            {
                nivel = "malo";
            }
            if (promedio <= 6)
            {
                nivel = "muy malo";
            }

            boleta.promedio = promedio;
            boleta.nivel = nivel;
            boleta.estado = estado;
            return boleta;
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            Boleta boleta = new Boleta();
            boleta.id = Convert.ToUInt32(txtId.Text);
            boleta.alumno = txtAlumno.Text;
            boleta.n1 = Convert.ToDecimal(txtN1.Text);
            boleta.n2 = Convert.ToDecimal(txtN2.Text);
            boleta.n3 = Convert.ToDecimal(txtN3.Text);
            boleta = Calcular(boleta);

            txtPromedio.Text = Convert.ToString(boleta.promedio);
            txtEstado.Text = boleta.estado;
            txtNivel.Text = boleta.nivel;
        }
    }
}
