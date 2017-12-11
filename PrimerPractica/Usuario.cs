using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimerPractica
{
    class Usuario : Nodo
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public Usuario()
        {
        }

        public Usuario(string username,string password)
        {
            UserName = username;
            Password = password;
        }
    }
}
