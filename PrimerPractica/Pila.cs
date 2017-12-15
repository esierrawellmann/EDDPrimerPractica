using PrimerPractica.DTO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimerPractica
{
    class Pila<T> where  T: Nodo, new()
    {
        internal T top = null;

        public int index = 0;
        public bool IsEmpty()
        {
            return top == null ? true : false;
        }
        public T Peek()
        {
            return top;
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

        public void Print()
        {
            string nodes = "";

            Nodo t = top;
            int index = 0;
            while (t != null)
            {
                Matriz ma = (Matriz)t;
                MatrizDispersa mat = new MatrizDispersa(ma);
                nodes += $"\n col{index++}[label={mat.GetAllSumValues()}]; ";

                t = t.Siguiente;
            }
            string output = @"digraph dibujo{ rank=UD; node[shape=box width=1]; " + nodes + " }";

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
