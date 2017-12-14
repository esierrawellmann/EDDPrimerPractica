using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimerPractica
{
    class Cola<T> where  T: Nodo, new()
    {
        T inicio = null;
        T final = null;
        int index = 0;
        public bool isEmpty() {
            return inicio == null ? true : false;   
        }
        public void Enqueue (T item)
        {

            if (isEmpty())
            {
                inicio = final = item;
            }
            else
            {
                final.Siguiente = item;
                final = item;
            }
            index++;
        }

        public T Dequeue()
        {
            if (isEmpty())
            {
                return null;
            }
            else
            {
                T head = inicio;
                inicio = (T)inicio.Siguiente;
                index--;
                return head;
            }
        }
    }
}
