using PrimerPractica.DTO;
using System;
using System.Collections.Generic;
using System.IO;
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

        public T Peek()
        {
            return inicio;
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
        public void Print()
        {
            string nodes = "";

            Nodo t = inicio;
            int index = 0;
            while (t != null)
            {
                
                Matriz ma = (Matriz)t;
                MatrizDispersa mat = new MatrizDispersa(ma);
                nodes += $"\n rank=LR; col{index++}[label={mat.GetAllSumValues()}]; ";

                t = t.Siguiente;
            }
            string output = @"digraph dibujo{node[shape=box width=1]; " + nodes + " }";

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
