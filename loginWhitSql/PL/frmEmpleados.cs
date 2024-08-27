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
using loginWhitSql.DAL_acceso_a_datos_;
using loginWhitSql.BLL_logica_; 

namespace loginWhitSql.PL_presentacion__
{
    public partial class frmEmpleados : Form
    {
        byte[] imagenByte;
        EmpleadosDal oEmpleadosDal;

        public frmEmpleados()
        {
            oEmpleadosDal = new EmpleadosDal();
            InitializeComponent();
            this.Text = "Empleados";
            llenarGrilla();
            Limpiar();
            btnInicio();
        }
       
        //Llenamos el combo con los datos 
        private void frmEmpleados_Load(object sender, EventArgs e)
        {

            //IMPORTANTE COMO RECUPERAR INFORMACION DEL USUARIO PARA FILTRAR 
            DepartamentosDLL objDepartamentos = new DepartamentosDLL();
            //DataSource ?
            cmbDepartamento.DataSource = objDepartamentos.MostrarDepartamentos().Tables[0];
            //DisplayMember ??
            cmbDepartamento.DisplayMember = "departamento";
            //ValueMember ? 
            cmbDepartamento.ValueMember = "ID";
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



        private void btnAgregar_Click(object sender, EventArgs e)
        {
            oEmpleadosDal.Agregar(RecolectarDatos());
            llenarGrilla(); 
            
            picFoto.Image = null;
            Limpiar();
        }
      
        private empleadosBLL RecolectarDatos()
        {
            empleadosBLL objEmplados = new empleadosBLL();

            int codigoEmpleado = 1;
            //si tiene codigo lo usa, sino le pone 1 
            int.TryParse(txtId.Text, out codigoEmpleado);

            objEmplados.ID = codigoEmpleado;
            objEmplados.NombreEmpleado= txtNombre.Text;
            objEmplados.PrimerApellido = txtPrimerApellido.Text;
            objEmplados.SegundoApellido = txtSengundoApellid.Text;  
            objEmplados.Correo=txtCorreo.Text;

            int departamentoIDD = 0;

            int.TryParse(cmbDepartamento.SelectedValue.ToString(), out departamentoIDD);
            objEmplados.Departamento = departamentoIDD;
            objEmplados.FotoEmpleado = imagenByte;
            return objEmplados;
           
        }


        private void btnExaminar_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog selectorImagen = new OpenFileDialog();

            selectorImagen.Title = "seleccionar Imagen";

            //Verifica si ya selecciono una foto 
            if (selectorImagen.ShowDialog() == DialogResult.OK)
            {
                picFoto.Image = Image.FromStream(selectorImagen.OpenFile());
                MemoryStream memoria = new MemoryStream();

                picFoto.Image.Save(memoria, System.Drawing.Imaging.ImageFormat.Png);
                imagenByte = memoria.ToArray();

            }
        }


        public void llenarGrilla()
        {
            dgvEmpleados.DataSource = oEmpleadosDal.MostrarEmpleados().Tables[0];

            dgvEmpleados.Columns[0].HeaderText = "Id";
            dgvEmpleados.Columns[1].HeaderText = "Nombre y Apellido";
            dgvEmpleados.Columns[2].HeaderText = "Ingreso";
            dgvEmpleados.Columns[3].HeaderText = "Actividad";
            dgvEmpleados.Columns[4].HeaderText = "Correo";
            dgvEmpleados.Columns[5].HeaderText = "Foto";

        }

        public void btnFiltrar_Click(object sender, EventArgs e)
        {
            int valor;
            if (int.TryParse(txtId.Text, out valor))
            {
                empleadosBLL oEmpleadosBll = new empleadosBLL();
                oEmpleadosBll.ID = valor;

                DataSet ds = oEmpleadosDal.Filtrar(oEmpleadosBll);

                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    dgvEmpleados.DataSource = ds.Tables[0];

                    dgvEmpleados.Columns[0].HeaderText = "Id";
                    dgvEmpleados.Columns[1].HeaderText = "Nombre";
                    dgvEmpleados.Columns[2].HeaderText = "Apellido";
                    dgvEmpleados.Columns[3].HeaderText = "Tarea";
                    dgvEmpleados.Columns[4].HeaderText = "Correo";
                    dgvEmpleados.Columns[5].HeaderText = "Departamento";
                    try
                    {
                        byte[] imageBytes = ds.Tables[0].Rows[0]["Foto"] as byte[];
                        if (imageBytes != null && imageBytes.Length > 0)
                        {
                            picFoto.Image = ConvertirByteAImagen(imageBytes);
                            picFoto.SizeMode = PictureBoxSizeMode.Zoom; // Ajusta el modo de tamaño de la imagen
                        }
                        else
                        {
                            picFoto.Image = null;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error al convertir bytes a imagen: {ex.Message}");
                        picFoto.Image = null;
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
            dgvEmpleados.ClearSelection();

            if (indice1 >= 0)
            {
            txtId.Text = dgvEmpleados.Rows[indice1].Cells[0].Value.ToString();
            txtNombre.Text = dgvEmpleados.Rows[indice1].Cells[1].Value.ToString();
            txtPrimerApellido.Text = dgvEmpleados.Rows[indice1].Cells[2].Value.ToString();
            txtSengundoApellid.Text = dgvEmpleados.Rows[indice1].Cells[3].Value.ToString();
            txtCorreo.Text = dgvEmpleados.Rows[indice1].Cells[4].Value.ToString();

                byte[] imgBytes = (byte[])dgvEmpleados.Rows[indice1].Cells[5].Value;

                if (imgBytes != null)
                {
                    using (MemoryStream ms = new MemoryStream(imgBytes))
                    {
                        picFoto.Image = Image.FromStream(ms);
                    }
                }
                else
                {
                    picFoto.Image = null; // Si no hay imagen, limpia el PictureBox
                }

            }

            btnModificar.Enabled = true;
            btnBorrar.Enabled = true;   
        }

        public void Limpiar()
        {
            txtId.Clear();
            txtCorreo.Clear();
            txtNombre.Clear();
            txtPrimerApellido.Clear();
            txtSengundoApellid.Clear(); picFoto.Image = null;


        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            oEmpleadosDal.Eliminar(RecolectarDatos());
            llenarGrilla();
            Limpiar();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            llenarGrilla();
            Limpiar();
            picFoto.Image = null;
            btnInicio();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            oEmpleadosDal.ModificarEmpl(RecolectarDatos());
            llenarGrilla();
            Limpiar();
            btnInicio();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
