using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PrimerPractica.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PrimerPractica
{
    public partial class Form1 : Form
    {
        Lista<Usuario> lista = new Lista<Usuario>();

        Usuario _usuarioActual = null;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            Usuario usuario = new Usuario("renatosierra","12345");
            lista.Add(usuario);
            button2.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Usuario u = lista.SerachUser(textBox1.Text);
            if(u != null)
            {
                _usuarioActual = u;
                MessageBox.Show($"User {u.UserName} found!");
                button3.Enabled = true;
            }
            else
            {
                MessageBox.Show("User Not Found!");
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Stream myStream = null;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if ((myStream = openFileDialog1.OpenFile()) != null)
                    {
                        StreamReader reader = new StreamReader(myStream);
                        string text = reader.ReadToEnd();
                        FileDTO fileDTO = JsonConvert.DeserializeObject<FileDTO>(text);

                        foreach (var x in fileDTO.archivo.pila.matrices.matriz)
                        {
                            _usuarioActual.pila.Push(x);
                        }

                        foreach (var x in fileDTO.archivo.cola.matrices.matriz)
                        {
                            _usuarioActual.cola.Enqueue(x);
                        }

                        //MatrizDispersa ma = new MatrizDispersa(fileDTO.archivo.pila.matrices.matriz.First<Matriz>());
                        //ma.Print(ma);
                    }


                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            MatrizDispersa peekCola = new  MatrizDispersa(_usuarioActual.cola.Peek());
            peekCola.Print(peekCola);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            MatrizDispersa cola = new MatrizDispersa(_usuarioActual.cola.Dequeue());
            MatrizDispersa pila = new MatrizDispersa(_usuarioActual.pila.Pop());

            if (cola.SizeY == pila.SizeX)
            {
                MatrizDispersa result = cola.MuliplyBy(pila);
                result.Print(result);
            }
            else
            {
                MessageBox.Show("Dimensiones de Matriz Invalidas!");
            }

            


        }

        private void button6_Click(object sender, EventArgs e)
        {
            MatrizDispersa ma = new MatrizDispersa(_usuarioActual.pila.Peek());
            ma.Print(ma);
        }
    }
}
