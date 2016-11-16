using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
    }
}
