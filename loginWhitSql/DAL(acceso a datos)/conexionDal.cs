using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace loginWhitSql.DAL_acceso_a_datos_
{
    class conexionDal
    {
        // cadena de mysql para conectarse
        private string CadenaConexion = "Server=localhost;Port=3306;Database=dbsistema;User Id=root;Password=;";

        //crea un objeto para manejar la conexión a la base de datos.
        MySqlConnection conexion;



        //Inicializa el objeto de conexión (conexion) 
        //usando la cadena de conexión (CadenaConexion) y lo retorna.
        public MySqlConnection EstablecerConexion() {

            //ya lo tenes declarado al objeto asique ponemos This
            //crear una conexion con sql conexion
            //asiganmos la instancia al objeto

            this.conexion = new MySqlConnection(this.CadenaConexion);

            return this.conexion;

        }




        //Metodo INSERT, DELET, UPDATE
        public bool ejecutarComandosSinRetornos(string strComando)
        {
            try
            {

                // Comando para poder hacer consultas 
                MySqlCommand comando = new MySqlCommand();

                comando.CommandText = strComando;
                comando.Connection = this.EstablecerConexion();


                conexion.Open();
                comando.ExecuteNonQuery();
                conexion.Close();

                return true;
            }
            catch
            {
                return false;
            }

        }

        //sobreCarga para pasarle argumento diferente 

        public bool ejecutarComandosSinRetornos(MySqlCommand SqlComando)
        {
            try
            {

                // Comando para poder hacer consultas 
                MySqlCommand comando = SqlComando;

                
                comando.Connection = this.EstablecerConexion();


                conexion.Open();
                comando.ExecuteNonQuery();
                conexion.Close();

                return true;
            }
            catch
            {
                return false;
            }

        }



        //Retornos de datos SELECT
        public DataSet EjecutarSentencia(MySqlCommand mySqlComando)
        {
            //Ver que significa cada uno 
            DataSet ds = new DataSet();
            MySqlDataAdapter Adaptador = new MySqlDataAdapter();

            try
            {
                MySqlCommand Comando = new MySqlCommand();
                Comando = mySqlComando;
                Comando.Connection = EstablecerConexion();
                Adaptador.SelectCommand = Comando;
                conexion.Open();
                Adaptador.Fill(ds);
                conexion.Close();

                return ds;
            }
            catch 
            {
                return ds;
                
            }


        }

    }



}
