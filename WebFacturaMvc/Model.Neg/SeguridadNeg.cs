using Model.Dao;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Model.Neg
{
    public class SeguridadNeg
    {
        private ConexionDB objConexionDB;
        private SqlCommand comando;
        private SqlDataReader reader;

        public SeguridadNeg()
        {
            objConexionDB = ConexionDB.saberEstado();
        }
        public Boolean iniciar(string usuario, string password, HttpSessionStateBase s)
        {
            bool hayRegistros;
            Boolean f = false;
            string find = "select u.usuario, ( v.nombre + ' ' + v.apMaterno), count(1),u.idVendedor  from usuario u  inner join vendedor v on v.idVendedor = u.idVendedor where u.Usuario =  '" + usuario + "' and u.pass = '" + password + "' group by u.usuario, ( v.nombre + ' ' + v.apMaterno), u.idVendedor";
            try
            {
                comando = new SqlCommand(find, objConexionDB.getCon());
                objConexionDB.getCon().Open();
                reader = comando.ExecuteReader();
                hayRegistros = reader.Read();
                if (hayRegistros)
                {
                    if(Convert.ToInt32( reader[2].ToString()) == 1 ){
                        f = true;
                       s["usuario"] = reader[0].ToString();
                       s["nombre"] = reader[1].ToString();
                       s["idVendedor"] = reader[3].ToString();
                    }
                   // objCategoria.Nombre = reader[1].ToString();
                   // objCategoria.Descripcion = reader[2].ToString();

                   // objCategoria.Estado = 99;
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                objConexionDB.getCon().Close();
                objConexionDB.closeDB();
            }
            return f;

        }


        public Boolean comprobar(HttpSessionStateBase s)
        {
            if (s["usuario"] == null)
                return false;
            else
                return true;
        }

        public Boolean salir(HttpSessionStateBase s)
        {
            s["usuario"] = null;
            if (s["usuario"] == null)
                return false;
            else
                return true;
        }
    }
}