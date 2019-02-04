using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Data;

namespace Programacion
{
    class AccesoDatos
    {
        SqlConnection conexion;
        SqlCommand comando;
        DataTable tabla;
        SqlDataReader lector;
        string cadenadeconexion;

        public AccesoDatos(string cadena)
        {
            conexion = new SqlConnection(cadena);
            comando = new SqlCommand();
            tabla = new DataTable();
            lector = null;
            cadenadeconexion = cadena;
        }

        public void conectar()
        {
            conexion.ConnectionString = cadenadeconexion;
            conexion.Open();
            comando.Connection = conexion;
            comando.CommandType = CommandType.Text;
        }

        public void desconectar()
        {
            conexion.Close();
            conexion.Dispose();
        }

        public DataTable consultartabla(string nombretabla)
        {
            
            conectar();
            comando.CommandText = "select * from " + nombretabla;
            tabla = new DataTable();
            tabla.Load(comando.ExecuteReader());
            desconectar();
            return tabla;
        }

        public void leertabla(string nombretabla)
        {
            conectar();
            comando.CommandText = " select * from " + nombretabla;
            lector = comando.ExecuteReader();
        }

        public void actualizarbd(string consultasql)
        {
            conectar();
            comando.CommandText = consultasql;
            comando.ExecuteNonQuery();
            desconectar();
        }

        public DataTable consultadb2(string consultaSQL)
        {
            conectar();
            DataTable tabla = new DataTable();
            comando.CommandText = consultaSQL;
            tabla.Load(comando.ExecuteReader());
            desconectar();
            return tabla;
        }

        public SqlDataReader Lector { get => lector; set => lector = value; }
        public string Cadenadeconexion { get => cadenadeconexion; set => cadenadeconexion = value; }


    }
    
}
