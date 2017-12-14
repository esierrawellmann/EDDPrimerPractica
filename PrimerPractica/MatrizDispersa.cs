using PrimerPractica.DTO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimerPractica
{
    class MatrizDispersa
    {

        Lista<Nodo> columna = new Lista<Nodo>();
        public MatrizDispersa() { }
        public MatrizDispersa(Matriz matriz)
        {
           
            for (int j = 0; j < Int32.Parse(matriz.size_x); j++)
            {
                PosicionMatriz posx = new PosicionMatriz(j);
                PosicionMatriz col = (PosicionMatriz)columna.Add(posx);
                for (int i = 0; i < Int32.Parse(matriz.size_y); i++) {
                    PosicionMatriz posy = new PosicionMatriz(j, i,"0");
                    foreach (var dato in matriz.valores.valor) {
                        if (Int32.Parse(dato.pos_x) == j  && Int32.Parse(dato.pos_y) == i) {
                            posy = new PosicionMatriz(j, i, dato.dato);
                        }
                    }
                    
                    col.filas.Add(posy);
                }
            }
            
        }
        public void Print(MatrizDispersa matriz)
        {
            string nodes = "";
            
            PosicionMatriz it = (PosicionMatriz)matriz.columna.primero;
            do {
                nodes += $" subgraph col{it.posx}" + "{ \n rank=UD; \n";

                PosicionMatriz fila = (PosicionMatriz)it.filas.primero;

                do
                {
                    nodes += $"\n col{((PosicionMatriz)fila).posx}fil{((PosicionMatriz)fila).posy}[label={fila.valor}]";
                    nodes += $"\n col{((PosicionMatriz)fila).posx}fil{((PosicionMatriz)fila).posy}->col{((PosicionMatriz)fila.Siguiente).posx}fil{((PosicionMatriz)fila.Siguiente).posy}; ";
                    
                    fila = (PosicionMatriz)fila.Siguiente;
                }
                while (fila != it.filas.primero);
                nodes += " } ";

                it = (PosicionMatriz)it.Siguiente;
            }
            while (it != matriz.columna.primero);
            string output = @"digraph dibujo{node[shape=box width=1];rank=LR; "+nodes+" }";

            Random random = new Random();
            int i = random.Next();

            string newstr = i.ToString();
            string path = $@"C:\EDD\PrimeraPractica\output\";
            string combinedPath = Path.Combine(path,$"graph{newstr}.dot");

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
