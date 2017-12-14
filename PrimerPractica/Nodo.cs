using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimerPractica
{
    public class Nodo
    {
        public Nodo Siguiente { get; set; }
        public Nodo Anterior { get; set; }

        public Nodo()
        {
            Anterior = null;
            Siguiente = null;
        }


    }
}
