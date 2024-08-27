using loginWhitSql.BLL;
using loginWhitSql.BLL_logica_;
using loginWhitSql.DAL_acceso_a_datos_;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace loginWhitSql.PL
{
    public partial class frmStock : Form
    {

        byte[] imgStock;
        StockDAL oStock;

        public frmStock()
        {
            oStock = new StockDAL();
            InitializeComponent();
            this.Text = "Stock";
            llenarGrilla();
            btnInicio();
        }

        public void btnInicio()
        {
            btnFiltrar.Enabled = true;
            btnAgregar.Enabled = true;
            btnBorrar.Enabled = false;
            btnModificar.Enabled = false;
            btnCancelar.Enabled = false;
        }

        public void btnTrabajo()
        {
            btnFiltrar.Enabled = false;
            btnAgregar.Enabled = false;
            btnBorrar.Enabled = true;
            btnModificar.Enabled = true;
            btnCancelar.Enabled = true;
        }



        // Recuperamo datos y lo gurdamos en obj oStock
        private stockBLL guardarDatos()
        {
            stockBLL oStock = new stockBLL();

            int codigoStock = 1;
            //si tiene codigo lo usa, sino le pone 1 
            int.TryParse(txtId.Text, out codigoStock);

            oStock.Id = codigoStock;
            oStock.Descripcion = txtDescr.Text;
            oStock.Cantidad = int.Parse(txtCant.Text);
            oStock.Precio = int.Parse(txtPrecio.Text);
            oStock.FotoStock = imgStock;
           
            return oStock;

        }


        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Limpiar(); 
            llenarGrilla();
            btnInicio();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            oStock.Agregar(guardarDatos());
            llenarGrilla();
            Limpiar(); 
        }

        private void btnExaminar_Click(object sender, EventArgs e)
        {
            OpenFileDialog selectorImagen = new OpenFileDialog();

            selectorImagen.Title = "seleccionar Imagen";

            //Verifica si ya selecciono una foto 
            if (selectorImagen.ShowDialog() == DialogResult.OK)
            {
                fotoStock.Image = Image.FromStream(selectorImagen.OpenFile());
                MemoryStream memoria = new MemoryStream();

                fotoStock.Image.Save(memoria, System.Drawing.Imaging.ImageFormat.Png);
                imgStock = memoria.ToArray();

            }

        }
        public void Limpiar()
        {
            txtId.Clear();
            txtDescr.Clear();
            txtCant.Clear();
            txtPrecio.Clear();
            fotoStock.Image = null;
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            oStock.ModificarStock(guardarDatos());
            llenarGrilla();
            Limpiar();
            btnInicio();    
        }

        public void llenarGrilla()
        {
            dgvStock.DataSource = oStock.MostrarStock().Tables[0];

            dgvStock.Columns[0].HeaderText = "Id";
            dgvStock.Columns[1].HeaderText = "Descripcion";
            dgvStock.Columns[2].HeaderText = "Precio";
            dgvStock.Columns[3].HeaderText = "Cantidad";
            dgvStock.Columns[4].HeaderText = "Foto";

        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            oStock.Eliminar(guardarDatos());
            llenarGrilla();
            Limpiar();
        }

        public void btnFiltrar_Click(object sender, EventArgs e)
        {
            int valor;
            if (int.TryParse(txtId.Text, out valor))
            {
                stockBLL oStockBll = new stockBLL();
                oStockBll.Id = valor;

                DataSet ds = oStock.Filtrar(oStockBll);
                txtDescr.Text = oStockBll.Descripcion;


                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    // Asignar los valores del DataSet a las propiedades del objeto oStockBll
                    oStockBll.Descripcion = ds.Tables[0].Rows[0]["Descripcion"].ToString();
                    oStockBll.Cantidad = Convert.ToInt32(ds.Tables[0].Rows[0]["Cantidad"]);
                    oStockBll.Precio = Convert.ToInt32(ds.Tables[0].Rows[0]["Precio"]);
                    oStockBll.FotoStock = ds.Tables[0].Rows[0]["Foto"] as byte[];

                    // Mostrar los valores en los controles del formulario
                    txtDescr.Text = oStockBll.Descripcion;
                    txtCant.Text = oStockBll.Cantidad.ToString();
                    txtPrecio.Text = oStockBll.Precio.ToString();

                    dgvStock.DataSource = ds.Tables[0];

                    dgvStock.Columns[0].HeaderText = "Id";
                    dgvStock.Columns[1].HeaderText = "Descripcion";
                    dgvStock.Columns[2].HeaderText = "Cantidad";
                    dgvStock.Columns[3].HeaderText = "Precio";
                    dgvStock.Columns[4].HeaderText = "Foto";

                    try
                    {
                        byte[] imageBytes = ds.Tables[0].Rows[0]["Foto"] as byte[];
                        if (imageBytes != null && imageBytes.Length > 0)
                        {
                            fotoStock.Image = ConvertirByteAImagen(imageBytes);
                            fotoStock.SizeMode = PictureBoxSizeMode.Zoom; // Ajusta el modo de tamaño de la imagen
                            txtDescr.Text = oStockBll.Descripcion;

                        }
                        else
                        {
                            fotoStock.Image = null;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error al convertir bytes a imagen: {ex.Message}");
                        fotoStock.Image = null;
                    }
                }
                else
                {
                    MessageBox.Show("No se encontraron registros.");
                }
            }
            else
            {
                MessageBox.Show("Por favor, ingresa un ID válido.");
            }

            btnTrabajo();

        }

        //El método toma un arreglo de bytes que representa una imagen, lo convierte en un objeto Image, y lo devuelve.
        private Image ConvertirByteAImagen(byte[] imageBytes)
        {
            using (MemoryStream ms = new MemoryStream(imageBytes))
            {
                return Image.FromStream(ms);
            }
        }

        private void seleccionar1(object sender, DataGridViewCellMouseEventArgs e)
        {
            int indice1 = e.RowIndex;
            dgvStock.ClearSelection();

            if (indice1 >= 0)
            {
                txtId.Text = dgvStock.Rows[indice1].Cells[0].Value.ToString();
                txtDescr.Text = dgvStock.Rows[indice1].Cells[1].Value.ToString();
                txtPrecio.Text = dgvStock.Rows[indice1].Cells[2].Value.ToString();
                txtCant.Text = dgvStock.Rows[indice1].Cells[3].Value.ToString();

                byte[] imgBytes = (byte[])dgvStock.Rows[indice1].Cells[4].Value;

                if (imgBytes != null)
                {
                    using (MemoryStream ms = new MemoryStream(imgBytes))
                    {
                        fotoStock.Image = Image.FromStream(ms);
                    }
                }
                else
                {
                    fotoStock.Image = null; // Si no hay imagen, limpia el PictureBox
                }

            }

            btnModificar.Enabled = true;
            btnBorrar.Enabled = true;

            }
        

        private void frmStock_Load(object sender, EventArgs e)
        {

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
