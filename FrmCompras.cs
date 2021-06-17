
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;




namespace Pantallas_proyecto
{
    public partial class FrmCompras : Form
    {
        public FrmCompras()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }



        ClsConexionBD conect = new ClsConexionBD();
        Productos producto = new Productos();


        SqlDataAdapter da;
        DataTable dt;

        public void cargarDatosProductos(DataGridView dgv, string nombreTabla)//homonimia-este metodo solo muestra los habilitados
        {
            try
            {
                da = new SqlDataAdapter("Select codigo_producto Codigo,Categoria_Producto.descripcion_categoria Categoria, descripcion_producto Descripcion, cantidad_existente Cantidad,precio_actual , descuento_producto Descuento " +
                    "From " + nombreTabla + ", Categoria_Producto Where Categoria_Producto.codigo_categoria = Productos.codigo_categoria ", conect.conexion);
                dt = new DataTable();
                da.Fill(dt);
                dgv.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los datos", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }




        private void FrmCompras_Load(object sender, EventArgs e)
        {

            conect.abrir();
            cargarDatosProductos(dataGridView1, "Productos");



            try
            {
                SqlCommand comando = new SqlCommand("SELECT descripcion_categoria FROM Categoria_Producto", conect.conexion);
                conect.abrir();
                SqlDataReader registro = comando.ExecuteReader();
                while (registro.Read())
                {
                    comboBox1.Items.Add(registro["descripcion_categoria"].ToString());
                }
                conect.cerrar();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los datos", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }







        }


private void button2_Click(object sender, EventArgs e)
        {


        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmMenuPrincipalGerente acceso = new FrmMenuPrincipalGerente();
            acceso.Show();
            this.Hide();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}


