using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.Json;

namespace Polygon
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            checkedListBox1.SetItemChecked(0, true);
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (checkedListBox1.CheckedItems.Count > 1)
            {
                for (int i = 0; i < checkedListBox1.Items.Count; i++)
                    checkedListBox1.SetItemChecked(i, false);
                checkedListBox1.SetItemChecked(checkedListBox1.SelectedIndex, true);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ClassLoadAPIPoligon loadAPIPoligon = new ClassLoadAPIPoligon();
            if (checkedListBox1.GetItemChecked(0))
            {
                richTextBox1.Text = loadAPIPoligon.funcPolygon(richTextBox2.Text);
            }
            else
            {
                string tempCoord = loadAPIPoligon.funcPolygon(richTextBox2.Text);
                foreach (int index in checkedListBox1.CheckedIndices)
                {
                    richTextBox1.Text = RazdelFunc(tempCoord, index);
                }

               // richTextBox1.Text = RazdelFunc(tempCoord, )

            }
            if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            // получаем выбранный файл
            string filename = saveFileDialog1.FileName;
            // сохраняем текст в файл
            System.IO.File.WriteAllText(filename, richTextBox1.Text);
            MessageBox.Show("Файл сохранен");

        }

        private string RazdelFunc(String textForSplit, int indexSelectionSplit)
        {
            int counterSplitter = 1;
            if (indexSelectionSplit == 1)
                counterSplitter = 2;
            if (indexSelectionSplit == 2)
                counterSplitter = 5;
            if (indexSelectionSplit == 3)
                counterSplitter = 10;
            string testStringReplace = textForSplit;

            //string[] words = testStringReplace.Split('],[');
            return textForSplit;
        }
    }
}
