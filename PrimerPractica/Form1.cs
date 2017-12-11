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

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            Usuario usuario = new Usuario("renatosierra","12345");
            lista.Add(usuario);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Usuario u = lista.SerachUser(textBox1.Text);
            if(u != null)
            {
                MessageBox.Show($"User {0} found!",u.UserName);
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
    }
}
