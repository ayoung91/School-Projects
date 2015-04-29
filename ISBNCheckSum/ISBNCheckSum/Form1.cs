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

namespace ISBNCheckSum
{
    public partial class Form1 : Form
    {
        int total;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int pos, count = 1, val, d, checksum;
            string input, compressed = "";

            StreamReader sr = new StreamReader("isbn9.txt");
            StreamWriter sw = new StreamWriter("isbn10Output.txt");

            sw.WriteLine("10 digit ISNB numbers");
            sw.WriteLine("---------------------");

            while (!sr.EndOfStream)
            {
                input = sr.ReadLine();
                if (input != "")
                {
                    pos = input.IndexOf(".") + 2;
                    input = input.Substring(pos);
                    foreach (char ch in input)
                    {
                        if (ch != '-')
                        {
                            compressed += ch;
                        }
                    }
                    sw.Write(count + ". ");

                    d = 10;
                    foreach (char ch in compressed)
                    {
                        val = (int)Char.GetNumericValue(ch);
                        total += val * d;
                        d--;
                    }

                    checksum = (total % 11);
                    if (checksum != 0)
                        checksum = Math.Abs(11 - checksum);

                    count++;
                    sw.WriteLine(input + "-" + checksum);

                    total = 0;
                    compressed = "";
                }
            }
            sw.Close();

            MessageBox.Show("Data has been written to \nISBNCheckSum/bin/Debug/isbn10Output!");

            this.Close();
        }
    }
}
