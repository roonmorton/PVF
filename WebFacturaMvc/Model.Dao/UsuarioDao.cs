using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Model.Entity;
using System.Data.SqlClient;

namespace Model.Dao
{
    public class UsuarioDao:Obligatorio<Usuario>
    {

        private ConexionDB objConexionDB;
        private SqlCommand comando;
        private SqlDataReader reader;
        public UsuarioDao()
        {
            objConexionDB = ConexionDB.saberEstado();
        }
        public void create(Usuario objUsuario)
        {
            string create = "insert into usuario(usuario,pass,idVendedor) values('" + objUsuario.User + "','" + objUsuario.Pass + "')";
            try
            {
                comando = new SqlCommand(create, objConexionDB.getCon());
                objConexionDB.getCon().Open();
                comando.ExecuteNonQuery();
            }
            catch (Exception)
            {
                objUsuario.Estado = 1000;
            }
            finally
            {
                objConexionDB.getCon().Close();
                objConexionDB.closeDB();
            }
        }
        

        public void delete(Usuario objUsuario)
        {
            string delete = "delete from usuario where idUsuario='" + objUsuario.IdUsuario + "'";
            try
            {
                comando = new SqlCommand(delete, objConexionDB.getCon());
                objConexionDB.getCon().Open();
                comando.ExecuteNonQuery();
            }
            catch (Exception)
            {
                objUsuario.Estado = 1000;
            }
            finally
            {
                objConexionDB.getCon().Close();
                objConexionDB.closeDB();
            }
        }

        public bool find(Usuario objUsuario)
        {
            bool hayRegistros;
            string find = "select*from usuario where idUsuario='" + objUsuario.IdUsuario + "'";
            try
            {
                comando = new SqlCommand(find, objConexionDB.getCon());
                objConexionDB.getCon().Open();
                reader = comando.ExecuteReader();
                hayRegistros = reader.Read();
                if (hayRegistros)
                {
                    objUsuario.User = reader[1].ToString();
                    objUsuario.Pass = reader[2].ToString();

                    objUsuario.Estado = 99;
                }
                else
                {
                    objUsuario.Estado = 1;
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

            return hayRegistros;
        }

        public List<Usuario> findAll()
        {
            
            List<Usuario> listaUsuarios = new List<Usuario>();
            string find = "select*from usuario";
            try
            {
                comando = new SqlCommand(find, objConexionDB.getCon());
                objConexionDB.getCon().Open();
                reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    Usuario objUsuario= new Usuario();
                    objUsuario.IdUsuario = reader[0].ToString();
                    objUsuario.User = reader[1].ToString();
                    objUsuario.Pass = reader[2].ToString();

                    listaUsuarios.Add(objUsuario);
                }

            }
            catch (Exception)
            {
                //objCategoria.Estado = 1000;
            }
            finally
            {
                objConexionDB.getCon().Close();
                objConexionDB.closeDB();
            }

            return listaUsuarios;
        }

        public void update(Usuario objUsuario)
        {
            string update = "update usuario set  pass='" + objUsuario.Pass + "' where idCategoria='" + objUsuario.IdUsuario + "'";
            try
            {
                comando = new SqlCommand(update, objConexionDB.getCon());
                objConexionDB.getCon().Open();
                comando.ExecuteNonQuery();
            }
            catch (Exception)
            {
                objUsuario.Estado = 1000;
            }
            finally
            {
                objConexionDB.getCon().Close();
                objConexionDB.closeDB();
            }
        }
    }
}