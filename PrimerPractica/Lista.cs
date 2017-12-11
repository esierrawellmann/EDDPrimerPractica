using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimerPractica
{
    
    class Lista<T> where T : Nodo,  new()
    {
        internal T primero = null;
        public bool IsEmpty()
        {
            return primero == null ? true : false ;
        }
        public void Add(T item) {
            if (IsEmpty())
            {
                primero = item;
                primero.Siguiente = primero;
                primero.Anterior = primero;
            }
            else
            {
                Nodo i = primero;
                while(i.Siguiente != primero)
                {
                    i = i.Siguiente;
                }

                item.Anterior = i;
                item.Siguiente = primero;
                i.Siguiente = item;
                
            }
        }

        public Usuario SerachUser(string userName)
        {
           
            if (IsEmpty()) { return null; }
            else
            {
                Nodo i = primero;
                do
                {
                    Usuario u = (Usuario)i;
                    if (u.UserName == userName)
                    {
                        return u;
                    }
                    i = i.Siguiente;

                } while (i.Siguiente != primero);
            }
            
            return null;
        }
       

    }
   
}
