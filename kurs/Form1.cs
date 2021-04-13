using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
namespace kurs
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        List<Kurs> lista = new List<Kurs>();
        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            Kurs temp = new Kurs();
            int gotovo=1;
            while (gotovo!=0)
            {
                gotovo = 0;

                for (int i = 0; i < lista.Count - 1; i++)
                {
                    if (lista[i].SkupljiOd(lista[i + 1]))
                    {                       
                        temp = lista[i];
                        lista[i] = lista[i + 1];
                        lista[i + 1] = temp;
                        gotovo += 1;
                    }

                }
            }

            for (int i = 0; i < lista.Count; i++)
            {
                listBox1.Items.Add(lista[i]);
            }


        }

        private void Form1_Load(object sender, EventArgs e)
        {
            StreamReader f = new StreamReader("kursevi.txt");
            while (!f.EndOfStream)
            {               
                string naziv = f.ReadLine();
                int cena = int.Parse(f.ReadLine());
                Kurs k = new Kurs(naziv,cena);
                listBox1.Items.Add(k);
                lista.Add(k);
            }
            
        }
    }
}
