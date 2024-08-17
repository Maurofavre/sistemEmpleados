using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;
using loginWhitSql.BLL_logica_;
using System.Collections;

namespace loginWhitSql.DAL_acceso_a_datos_
{
    internal class DepartamentosDLL
    {
        conexionDal conexion; 

        //COSNTRUCTOR
        public DepartamentosDLL(){

            conexion = new conexionDal();   

        }
        //recibe el objeto de odepartamentoBll
        public bool Agregar(departamentoBLL odepartamentoBLL)

        {
            //"+odepartamentoBLL.Departamento+" asi se llama a las partes del objeto
            string query = "INSERT INTO departamentos (departamento) VALUES (@departamento)";

            // Crear y configurar el comando MySql
            MySqlCommand SqlComando = new MySqlCommand(query);

            // Añadir el valor del objeto oDepartamentoBLL
            SqlComando.Parameters.Add("@departamento", MySqlDbType.VarChar).Value = odepartamentoBLL.Departamento;

            // Ejecutar el comando y devolver el resultado
            return conexion.ejecutarComandosSinRetornos(SqlComando);
        }


        //traer todo de la tabla de departamentos 
        public DataSet MostrarDepartamentos()
        {
            // Crear el comando SQL
            MySqlCommand sentencia = new MySqlCommand("SELECT * FROM Departamentos");

            // Ejecutar la sentencia y devolver el resultado
            return conexion.EjecutarSentencia(sentencia);
        }



        public bool Eliminar(departamentoBLL odepartamentoBLL)
        {
            string query = "DELETE FROM departamentos where Id = @ID"; 
            MySqlCommand SqlComando = new MySqlCommand(query);


            SqlComando.Parameters.Add("@ID", MySqlDbType.Int32).Value = odepartamentoBLL.ID;
            return conexion.ejecutarComandosSinRetornos(SqlComando);

           
        }

        public int Modificar(departamentoBLL odepartamentoBLL)
        {
            conexion.ejecutarComandosSinRetornos(
                "UPDATE Departamentos" +


                " SET departamento= '" + odepartamentoBLL.Departamento + " '" +



                "WHERE ID=" + odepartamentoBLL.ID); 
                

            return 1;
        }

    }
}
