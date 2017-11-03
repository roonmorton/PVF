using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entity
{
    class Usuario
    {
        private string idUsuario;
        private string user;
        private string pass;

        private int estado;


        public int Estado
        {
            get
            {
                return estado;
            }

            set
            {
                estado = value;
            }
        }

        public string IdUsuario
        {
            get
            {
                return idUsuario;
            }

            set
            {
                idUsuario = value;
            }
        }

        public string User
        {
            get
            {
                return user;
            }

            set
            {
                user = value;
            }
        }

        public string Pass
        {
            get
            {
                return pass;
            }

            set
            {
                pass = value;
            }
        }

        public Usuario(string idUsuario, string user, string pass)
        {
            this.idUsuario = idUsuario;
            this.user = user;
            this.pass = pass;
        }

        public Usuario(string idUsuario)
        {
            this.idUsuario = idUsuario;
            
        }


        public Usuario()
        {

        }

    }
}
