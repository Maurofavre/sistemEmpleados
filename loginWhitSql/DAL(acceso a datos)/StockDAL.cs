using loginWhitSql.BLL;
using loginWhitSql.BLL_logica_;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace loginWhitSql.DAL_acceso_a_datos_
{
    internal class StockDAL
    {
        conexionDal conexion;

        public StockDAL()
        {
            conexion = new conexionDal();   
        }
        
        public bool Agregar(stockBLL oStock)

        {
            //"+odepartamentoBLL.Departamento+" asi se llama a las partes del objeto
            string query = "INSERT INTO idstock (id, descripcion, cantidad, precio, foto) VALUES (@id, @descripcion, @cantidad, @precio, @foto)";


            // Crear y configurar el comando MySql
            MySqlCommand SqlComando = new MySqlCommand(query);

            // Añadir el valor del objeto oDepartamentoBLL
            SqlComando.Parameters.Add("@id", MySqlDbType.VarChar).Value = oStock.Id;
            SqlComando.Parameters.Add("@descripcion", MySqlDbType.VarChar).Value = oStock.Descripcion;
            SqlComando.Parameters.Add("@cantidad", MySqlDbType.Int32).Value = oStock.Cantidad;
            SqlComando.Parameters.Add("@precio", MySqlDbType.Int32).Value = oStock.Precio;
            SqlComando.Parameters.Add("@foto", MySqlDbType.Blob).Value = oStock.FotoStock;
            // Ejecutar el comando y devolver el resultado
            return conexion.ejecutarComandosSinRetornos(SqlComando);
        }

        public bool Eliminar(stockBLL oStock)
        {
            string query = "DELETE FROM idstock where Id = @id";
            MySqlCommand SqlComando = new MySqlCommand(query);
            SqlComando.Parameters.Add("@ID", MySqlDbType.Int32).Value = oStock.Id;
            return conexion.ejecutarComandosSinRetornos(SqlComando);
        }
        public DataSet MostrarStock()
        {
            // Crear el comando SQL
            MySqlCommand sentencia = new MySqlCommand("SELECT * FROM idstock");

            // Ejecutar la sentencia y devolver el resultado
            return conexion.EjecutarSentencia(sentencia);
        }

        public DataSet Filtrar(stockBLL oStock)
        {
            string query = "SELECT * FROM idstock WHERE Id = @ID";
            MySqlCommand sqlComando = new MySqlCommand(query);

            sqlComando.Parameters.Add("@ID", MySqlDbType.Int32).Value = oStock.Id;

            return conexion.EjecutarSentencia(sqlComando);
        }



        public int ModificarStock(stockBLL oStock)
        {
            conexion.ejecutarComandosSinRetornos(
                         "UPDATE idstock " +
                         "SET descripcion = '" + oStock.Descripcion + "', " +
                         "precio = '" + oStock.Precio + "', " +
                         "cantidad = '" + oStock.Cantidad + "' " + 
                         "WHERE ID = " + oStock.Id);

            return 1;

        }
        public int ModificarEmpl(empleadosBLL oEmpleadosBll)
        {
            string nombre = oEmpleadosBll.NombreEmpleado.Replace("'", "''");
            string primerApellido = oEmpleadosBll.PrimerApellido.Replace("'", "''");
            string segundoApellido = oEmpleadosBll.SegundoApellido.Replace("'", "''");
            string correo = oEmpleadosBll.Correo.Replace("'", "''");

            // Construcción de la consulta SQL con comas y espacios correctamente colocados
            string query = "UPDATE empleados SET " +
                           "nombre = '" + nombre + "', " +
                           "primerapellido = '" + primerApellido + "', " +
                           "segundoapellido = '" + segundoApellido + "', " +
                           "correo = '" + correo + "' " +
                           "WHERE ID = " + oEmpleadosBll.ID;

            // Ejecutar el comando
            conexion.ejecutarComandosSinRetornos(query);

            return 1;
        }

    }
}
