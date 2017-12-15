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

        public int SizeX =0;
        public int SizeY=0;
        public MatrizDispersa() { }
        public MatrizDispersa(Matriz matriz)
        {
            SizeX = Int32.Parse(matriz.size_x);
            SizeY = Int32.Parse(matriz.size_y);

            for (int j = 0; j < SizeX; j++)
            {
                PosicionMatriz posx = new PosicionMatriz(j);
                PosicionMatriz col = (PosicionMatriz)columna.Add(posx);
                for (int i = 0; i < SizeY; i++)
                {
                    PosicionMatriz posy = new PosicionMatriz(j, i, "0");
                    foreach (var dato in matriz.valores.valor)
                    {
                        if (Int32.Parse(dato.pos_x) == j && Int32.Parse(dato.pos_y) == i)
                        {
                            posy = new PosicionMatriz(j, i, dato.dato);
                        }
                    }

                    col.filas.Add(posy);
                }
            }
            
        }

        public int GetAllSumValues()
        {
            int total =0;
            for (int c = 0; c < this.SizeX; c++)
            {
                for (int j = 0; j < this.SizeY; j++)
                {
                    total += GetValueAt(this,c,j);
                }
            }
            return total;
        }
        public int GetValueAt(MatrizDispersa matriz,int x ,int y) {

            PosicionMatriz colMz = (PosicionMatriz)matriz.columna.primero;
            do
            {
                if(colMz.posx == x)
                {
                    PosicionMatriz filaMz = (PosicionMatriz)colMz.filas.primero;
                    do
                    {
                        if (filaMz.posy == y) {
                            return Int32.Parse(filaMz.valor);
                        }
                        
                        filaMz = (PosicionMatriz)filaMz.Siguiente;
                    } while (filaMz != colMz.filas.primero);

                }
                colMz = (PosicionMatriz)colMz.Siguiente;
            } while (colMz != matriz.columna.primero);
            return 0;
        }
        public MatrizDispersa MuliplyBy(MatrizDispersa matriz) {

            MatrizDispersa resultado = new MatrizDispersa();
            for(int c =0; c< this.SizeX; c++)
            {
                PosicionMatriz posx = new PosicionMatriz(c);
                PosicionMatriz col = (PosicionMatriz)resultado.columna.Add(posx);
                
                
              
                for(int f= 0; f < matriz.SizeY; f++)
                {
                    int total = 0;
                    for (int j = 0; j < this.SizeY; j++)
                    {
                        int res1 = GetValueAt(matriz, j, c);
                        int res2 = GetValueAt(this, c, j);
                        total += res1 * res2;
                    }
                    col.filas.Add(new PosicionMatriz(c, f, total.ToString()));
                }
            }
            return resultado;
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
