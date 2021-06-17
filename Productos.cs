using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Data;

namespace Pantallas_proyecto
{
    class Productos
    {
        private String descripcion;
        private int cantidad;
        private int categoria;
        private long precio_actual;
        private long descuento;
        private long talla;
        // encapsulamiento 
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public int Cantidad { get => cantidad; set => cantidad = value; }
        public int Categoria { get => categoria; set => categoria = value; }
        public long Precio_actual { get => precio_actual; set => precio_actual = value; }


        ClsConexionBD conect = new ClsConexionBD();
        SqlCommand cmd; // comandos de sql


        public void agregar()
        {
            conect.abrir();
            cmd = new SqlCommand("Insert into Productos values('" + categoria + "', '" + descripcion + "','" + cantidad + "','" + precio_actual + "','" + descuento + "','" + talla + ")", conect.conexion); //Asignacion de valores en la bd
            cmd.ExecuteNonQuery();
            MessageBox.Show("Los datos han sido insertados", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            conect.cerrar();
        }


    }
}
