using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using proyecto_dominio;
using proyecto_negocio;

namespace winAppDiscos
{
    public partial class frmAltaDisco : Form
    {
        public frmAltaDisco()
        {
            InitializeComponent();
        }

        private void lblUrl_Click(object sender, EventArgs e)
        {

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            Discos dis = new Discos();
            DiscosNegocio neg =new  DiscosNegocio();
            try
            {
                dis.titulo = txtTitulo.Text;
                dis.canciones = int.Parse(txtCanciones.Text);   
                dis.url = txtUrl.Text;
                dis.Estilo =(elemento) cbEstilo.SelectedItem;
                dis.formato = (elemento) cbFormato.SelectedItem;    

                neg.agregar(dis);
                MessageBox.Show("agregado Exitosamente");
                Close();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private void frmAltaDisco_Load(object sender, EventArgs e)
        {
            ElementoNegocio elem = new ElementoNegocio();
            try
            {
                cbEstilo.DataSource = elem.listar();
                cbFormato.DataSource = elem.listar2();
            }
            catch ( Exception ex)
            {

                throw ex;
            }
        }

        private void txtUrl_Leave(object sender, EventArgs e)
        {
            cargarImagen(txtUrl.Text);
        }
        private void cargarImagen(string imagen)
        {
            try
            {
                pbAltaDisco.Load(imagen);
            }
            catch (Exception)
            {

                pbAltaDisco.Load("https://upload.wikimedia.org/wikipedia/commons/thumb/3/3f/Placeholder_view_vector.svg/681px-Placeholder_view_vector.svg.png");
            }

        }
    }
}
