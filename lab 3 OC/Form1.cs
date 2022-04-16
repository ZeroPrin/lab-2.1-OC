using System;
using System.Threading;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace lab_3_OC
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        static int[] array = new int[10];
        static Thread threadOne = new Thread(sort1);
        static Thread threadTwo = new Thread(sort2);
        static bool flag, flag1 = true;
        static object locker1 = new object();
        static object locker2 = new object();
        static void sort1()
        {
            int per;
            for (int i = 0; i < array.Length; ++i)
            {
                for (int j = i + 1; j < array.Length; ++j)
                {
                    if (array[i] < array[j])
                    {
                        per = array[i];
                        array[i] = array[j];
                        array[j] = per;
                    }
                }
            }
        }
        static void sort2()
        {
            int per;
            for (int i = 0; i < array.Length - 1; i++)
            {
                int min = i;
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (array[j] < array[min])
                    {
                        min = j;
                    }
                }
                per = array[min];
                array[min] = array[i];
                array[i] = per;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            Random rand = new Random();
            for (int i = 0; i < array.Length; ++i)
            {
                array[i] = rand.Next(-100, 100);
                richTextBox1.Text += array[i].ToString() + " ";
            }

        }
        private void button2_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            if (flag == true)
            {
                richTextBox1.Clear();
                threadOne.Start();
                threadTwo.Start();
                for (int i = 0; i < array.Length; ++i)
                    richTextBox1.Text += array[i].ToString() + " ";    
            }
            else
            {
                for (int i = 0; i < array.Length; ++i)
                    richTextBox1.Text += array[i].ToString() + " ";
                sort1();
                richTextBox1.Text += "\n";
                for (int i = 0; i < array.Length; ++i)
                    richTextBox1.Text += array[i].ToString() + " ";
                sort2();
                richTextBox1.Text += "\n";
                for (int i = 0; i < array.Length; ++i)
                    richTextBox1.Text += array[i].ToString() + " ";
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
                flag = true;
            else
                flag = false;
        }
    }
}