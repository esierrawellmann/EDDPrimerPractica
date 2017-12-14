using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimerPractica
{

    class Lista<T> where T : Nodo, new()
    {
       
        internal T primero = null;
        internal T ultimo = null;
        public Lista(){
        }
        public Lista(int x, int y)
        {
        }
        public bool IsEmpty()
        {
            return primero == null ? true : false ;
        }
        public T Add(T item) {
            if (IsEmpty())
            {
                primero = ultimo  = item;
                primero.Siguiente = primero;
                primero.Anterior = primero;
                return primero;
            }
            else
            {
                //Nodo i = primero;
                //do
                //{
                //    i = i.Siguiente;
                //} while (i.Siguiente != primero);


                item.Anterior = ultimo;
                item.Siguiente = primero;

                ultimo.Siguiente = item;
                primero.Anterior = item;

                ultimo = item;
                return (T)item;
                
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

                } while (i != primero);
            }
            
            return null;
        }
       

    }
   
}
