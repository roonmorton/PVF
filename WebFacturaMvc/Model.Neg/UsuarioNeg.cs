using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Model.Dao;
using Model.Entity;

namespace Model.Neg
{
    public class UsuarioNeg
    {
        private UsuarioDao objUsuarioDao;
        //private ProductoDao objProductoDao;

        public UsuarioNeg()
        {
            objUsuarioDao = new Dao.UsuarioDao();
            //objProductoDao = new ProductoDao();
        }

        public void create(Usuario objUsuario)
        {
            bool verificacion = true;

            //inicio verificacion codigo retorna estado=1
            string codigo = objUsuario.IdUsuario;
            if (codigo==null)
            {
                objUsuario.Estado = 10;
                return;
            }else
            {
                codigo = objUsuario.IdUsuario.Trim();
                verificacion = codigo.Length > 0 && codigo.Length <= 5;
                if (!verificacion)
                {
                    objUsuario.Estado = 1;
                    return;
                }
            }
            //fin verificacion de codigo

            //inicio verificacion nombre retorna estado=2
            string nombre = objUsuario.User;
            if (nombre==null)
            {
                objUsuario.Estado = 20;
                return;
            }
            else
            {
                nombre = objUsuario.User.Trim();
                verificacion = nombre.Length > 0 && nombre.Length <= 30;
                if (!verificacion)
                {
                    objUsuario.Estado = 2;
                    return;
                }
            }
            //fin verificacion de nombre

            //inicio verificacion descripcion retorna estado=3
            /*string descripcion = objUsuario.Descripcion;
            if (descripcion == null)
            {
                objCategoria.Estado = 30;
                return;
            }
            else
            {
                descripcion = objCategoria.Descripcion.Trim();
                verificacion = descripcion.Length > 0 && descripcion.Length <= 50;
                if (!verificacion)
                {
                    objCategoria.Estado = 3;
                    return;
                }
            }*/
            //fin verificacion de descripcion

            //verificacion de duplicicdad
            Usuario objUsuarioAux = new Usuario();
            objUsuarioAux.IdUsuario = objUsuario.IdUsuario;
            verificacion = !objUsuarioDao.find(objUsuarioAux);
            if (!verificacion)
            {
                objUsuario.Estado = 4;
                return;
            }

            //todo bien
            objUsuario.Estado = 99;
            objUsuarioDao.create(objUsuario);
            return;

        }

        /*public void update(Categoria objCategoria)
        {
            bool verificacion = true;

            
            //inicio verificacion nombre retorna estado=2
            string nombre = objCategoria.Nombre;
            if (nombre == null)
            {
                objCategoria.Estado = 20;
                return;
            }
            else
            {
                nombre = objCategoria.Nombre.Trim();
                verificacion = nombre.Length > 0 && nombre.Length <= 30;
                if (!verificacion)
                {
                    objCategoria.Estado = 2;
                    return;
                }
            }
            //fin verificacion de nombre

            //inicio verificacion descripcion retorna estado=3
            string descripcion = objCategoria.Descripcion;
            if (descripcion == null)
            {
                objCategoria.Estado = 30;
                return;
            }
            else
            {
                descripcion = objCategoria.Descripcion.Trim();
                verificacion = descripcion.Length > 0 && descripcion.Length <= 50;
                if (!verificacion)
                {
                    objCategoria.Estado = 3;
                    return;
                }
            }
            //fin verificacion de descripcion

            
            //todo bien
            objCategoria.Estado = 99;
            objCategoriaDao.update(objCategoria);
            return;
        }

        public void delete(Categoria objCategoria)
        {
            bool verificacion = true;
            //verificacion de existencia
            Categoria objCategoriaAux = new Categoria();
            objCategoriaAux.IdCategoria = objCategoria.IdCategoria;
            verificacion = objCategoriaDao.find(objCategoriaAux);
            if (!verificacion)
            {
                objCategoria.Estado = 33;
                return;
            }

            //verificaicon de existencia de producto
            Producto objProducto = new Producto();
            objProducto.Categoria = objCategoria.IdCategoria;
            verificacion = !objProductoDao.findProductoPorCategoriaId(objProducto);
            if (!verificacion)
            {
                objCategoria.Estado = 34;
                return;
            }

            //todo bien
            objCategoria.Estado = 99;
            objCategoriaDao.delete(objCategoria);
            return;


        }
        */
        public bool find(Usuario objUsuario)
        {
            return objUsuarioDao.find(objUsuario);
        }

        public List<Usuario> findAll()
        {
            return objUsuarioDao.findAll();
        }
    }
}