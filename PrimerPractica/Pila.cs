using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimerPractica
{
    class Pila<T> where  T: Nodo, new()
    {
        internal T top = null;

        int index = 0;
        public bool IsEmpty()
        {
            return top == null ? true : false;
        }

        public void Push(T item) {
            if (IsEmpty())
            {
                top = item;
            }
            else
            {
                item.Siguiente = top;
                top = item;
            }
            index++;
        }

        public T Pop()
        {
            if (top != null) {
                T t = top;
                top = (T)top.Siguiente;
                index--;
                return t;
            }
            return null;

        }
    }
}
