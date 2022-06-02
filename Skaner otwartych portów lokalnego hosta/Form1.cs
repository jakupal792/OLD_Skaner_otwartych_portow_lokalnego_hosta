using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Skaner_otwartych_portów_lokalnego_hosta
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            listBox2.Items.Clear();

            label4.Text = "Liczba otwartych portów: " + 0;
            label5.Text = "Liczba zamkniętych portów: " + 0;

            if (numericUpDown1.Value > numericUpDown2.Value)
            {
                MessageBox.Show("Błędny zakres portów.");
                return;
            }

            int otw_port = 0;
            int zamk_port = 0;
            int port = (int)numericUpDown1.Value;

            for (int i = (int)numericUpDown1.Value; i <= (int)numericUpDown2.Value; i++)
            {
                this.Refresh();
                label1.Text = "Aktualnie skanowany port: " + i;
                try
                {
                    TcpListener serwer = new TcpListener(IPAddress.Loopback, i);
                    serwer.Start();
                    serwer.Stop();
                }
                catch
                {
                    listBox1.Items.Add("Port " + i + " jest zajęty"); 
                    port = i; 
                    zamk_port++;
                    label5.Text = "Liczba zajętych portów: " + zamk_port;
                }

                if (port != i)
                {
                    listBox2.Items.Add("Port " + i + " jest otwarty"); 
                    otw_port++;
                    label4.Text = "Liczba otwartych portów: " + otw_port;
                }
            }
            listBox1.Items.Add("Zakończenie skanowania");
        }     
    }
}
