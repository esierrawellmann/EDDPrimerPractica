using System;
using System.Collections.Generic;
using System.IO;
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
        public void Delete(T item)
        {
            if (item == primero) {
                primero = null;
            }
            else
            {
                item.Anterior.Siguiente = item.Siguiente;
                item.Siguiente.Anterior = item.Anterior;
                item = null;
            }

        }
        public T Add(T item) {
            if (IsEmpty())
            {
                primero = ultimo  = item;
                primero.Siguiente = primero;
                primero.Anterior = primero;
                primero.Index = 1;
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
                item.Index = ultimo.Index + 1 ;

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

        public void Print() {

            string nodes = "";

            Nodo p = (Nodo)primero;
            Usuario u = (Usuario)p;
            int index = 0;
            nodes += $" subgraph col{index}" + "{ \n rank=UD; \n";
            do
            {
                index++;
               

                
                nodes += $"\n user{u.Index}[label={u.UserName}]";
                nodes += $"\n user{u.Index} -> user{u.Siguiente.Index}";
                nodes += $"\n user{u.Index} ->  user{u.Anterior.Index}";


                u = (Usuario)u.Siguiente;
            }
            while (u != primero);
            nodes += " } ";

            string output = @"digraph dibujo{node[shape=box width=1];rank=LR; " + nodes + " }";

            Random random = new Random();
            int i = random.Next();

            string newstr = i.ToString();
            string path = $@"C:\EDD\PrimeraPractica\output\";
            string combinedPath = Path.Combine(path, $"graph{newstr}.dot");

            // This text is added only once to the file.
            if (!File.Exists(combinedPath))
            {
                // Create a file to write to.
                File.WriteAllText(combinedPath, output);
            }

            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo("dot.exe");
            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            startInfo.Arguments = $@"-Tbmp {combinedPath} -o { Path.Combine(path, $"outfile{newstr}.bmp")}";
            startInfo.UseShellExecute = false;
            process.StartInfo = startInfo;
            process.Start();
            process.WaitForExit();


            System.Diagnostics.Process.Start(Path.Combine(path, $"outfile{newstr}.bmp"));

        }


    }
   
}
