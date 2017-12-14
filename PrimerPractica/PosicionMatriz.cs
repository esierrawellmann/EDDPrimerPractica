using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimerPractica
{
    class PosicionMatriz : Nodo
    {
       
        public int posx;
        public int posy;
        public string valor;

        public Lista<Nodo> filas = new Lista<Nodo>();

        public PosicionMatriz(int x)
        {
            posx = x;
            posy = 0;
        }
        public PosicionMatriz(int x, int y, string val)
        {
            posx = x;
            posy = y;
            valor = val;
        }
     

    }

    
}
