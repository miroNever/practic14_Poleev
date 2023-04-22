using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace prfcnic_14_3_5_Poleev
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void zad3_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
            panel2.Visible = false;
        }
        Queue<int> queue3 = new Queue<int>();
        private void writingButton_Click(object sender, EventArgs e)
        {
            try
            {
                int n = 1;
                while (true)
                {
                    n = int.Parse(textBox1.Text);
                    if (n > 1)
                        break;
                    else
                    {
                        textBox1.Text ="введи число больше 1";
                    }
                }
                for (int i = 1; i <= n; i++)
                {
                    queue3.Enqueue(i);
                }
                MessageBox.Show($"добавленно {n} чисел в очередь");
            }
            catch
            {
                MessageBox.Show("введи число");
            }
        }

        private void vivodButton(object sender, EventArgs e)
        {
            while (queue3.Count > 0)
            {
                int num = queue3.Dequeue();
                listBox1.Items.Add(num);
            }
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }
        Queue<string[]> peopleQueue;
        private void Display()
        {
            DataTable datatable = new DataTable();
            datatable.Columns.Add("Фамилия");
            datatable.Columns.Add("Имя");
            datatable.Columns.Add("Отчество");
            datatable.Columns.Add("Возраст");
            datatable.Columns.Add("Вес");
            foreach (var person in peopleQueue)
            {
                datatable.Rows.Add(person[0], person[1], person[2], person[3], person[4]);
            }
            dataGridView1.DataSource = datatable;
        }
        private void zad4_Click(object sender, EventArgs e)
        {
            panel2.Visible = true;
            label1.Visible = false;
            peopleQueue = new Queue<string[]>();
            using (var sr = new StreamReader("text.txt")) 
            {
                while (!sr.EndOfStream)
                {
                    var line = sr.ReadLine();
                    if (line.Length == 0)
                    {
                        MessageBox.Show("Файл пуст");
                    }
                    else 
                    {
                        var parts = line.Split(' ');
                        peopleQueue.Enqueue(parts);
                    }
                }
            }
            Display();
        }

        private void SortYoungButton_Click(object sender, EventArgs e)
        {
            var youngPerson = new Queue<string[]>();
            var oldPerson = new Queue<string[]>();
            foreach (var person in peopleQueue)
            {
                var age = int.Parse(person[3]);
                if (age < numericUpDown1.Value)
                {
                    youngPerson.Enqueue(person);
                }
                else
                {
                    oldPerson.Enqueue(person);
                }
                peopleQueue = new Queue<string[]>(youngPerson.Concat(oldPerson));
                Display();
            }
        }
        private void SortAgeButton_Click(object sender, EventArgs e)
        {
            var list = peopleQueue.ToList();
            list.Sort((a, b) => int.Parse(a[3]).CompareTo(int.Parse(b[3])));
            peopleQueue = new Queue<string[]>(list);
            Display();
        }

    }
}
