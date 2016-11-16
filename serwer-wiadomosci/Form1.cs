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

namespace serwer_wiadomosci
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox2.Text != string.Empty && textBox2.Text.Trim().Length>0)
            {
                listBox1.Items.Add(textBox2.Text);
                textBox2.Text = String.Empty;
            }
        }


        private void button2_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItems.Count > 0)
            {
                for (int i = listBox1.Items.Count - 1; i >= 0; i--)
                    if (listBox1.GetSelected(i))
                        listBox1.Items.RemoveAt(i);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int indeks = listBox1.SelectedIndex;
            if (indeks > -1)
            {
                string pozycja = listBox1.Items[indeks].ToString();
                listBox1.Items.RemoveAt(indeks);
                if (pozycja.StartsWith("(Block) "))
                    listBox1.Items.Insert(indeks, pozycja.Remove(0,
                    "(Block) ".Length));
                else
                    listBox1.Items.Insert(indeks, "(Block) " + pozycja);
            }
        }

        private void otworzListęKontaktówToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listBox1.Items.Count > 0)
                if (MessageBox.Show("Nastąpi usunięcie listy", "Uwaga", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.Cancel)
                    return;
            openFileDialog1.FileName = "";
            openFileDialog1.Filter = "Text File | *.txt";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                using (StreamReader sr = new StreamReader(openFileDialog1.FileName))
                {
                    string linia;
                    listBox1.Items.Clear();
                    while ((linia = sr.ReadLine()) != null)
                        listBox1.Items.Add(linia);
                }
            }
        }

        private void zapiszListęKontaktówToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (listBox1.Items.Count > 0)
            {
                saveFileDialog1.Filter = "Text File | *.txt";
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    using (StreamWriter sw = new StreamWriter(saveFileDialog1.FileName))
                    {
                        foreach (string linia in listBox1.Items)
                            sw.WriteLine(linia);
                    }
                }
            }
            else
                MessageBox.Show("Nie można zapisać pustego pliku", "Uwaga", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void koniecToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
