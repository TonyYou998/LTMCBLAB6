using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LTMCBLAB6
{
    public partial class Form1 : Form
    {
        private FTPServer ftpClient;
        private bool createdDir = false;
        public Form1()
        {
            InitializeComponent();
           
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string IPAddress = textBox1.Text;
            string username = textBox2.Text;
            string password = textBox3.Text;
            OpenFileDialog oFD = new OpenFileDialog();
            oFD.ShowDialog();
            string fileName = oFD.SafeFileName;
            ftpClient = new FTPServer(@IPAddress, username, password);
            if (createdDir == false)
            {
                ftpClient.createDirectory($"lab6/files");
                createdDir = true;
            }
           
             ftpClient.upload($"lab6/files/{fileName}", @"C:\Users\tanvu\Documents\a.txt");
            //ftpClient.upload("C:\ftpserver\boss", @oFD.FileName);
            MessageBox.Show("upload complete");

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string IPAddress = textBox1.Text;
            string username = textBox2.Text;
            string password = textBox3.Text;

            listdowload ld = new listdowload(IPAddress,username,password);
            ld.Show();
            
        }
    }
}
