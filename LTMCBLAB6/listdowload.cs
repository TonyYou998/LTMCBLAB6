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
    public partial class listdowload : Form
    {
        private string IP;
        private string User;
        private string pass;
        private FTPServer ftpClient;
        public listdowload(string ip, string user, string pass)
        {
            InitializeComponent();
            this.IP = ip;
            this.User = user;
            this.pass = pass;

            ftpClient = new FTPServer(@IP, User, pass);
            string[] detailDirectoryListing = ftpClient.directoryListDetailed("/lab6/files");

            List<string> lst = new List<string>();


            for (int i = 0; i < detailDirectoryListing.Count(); i++)
            {


                var item = detailDirectoryListing[i];
                string[] fileName = item.Split(" ");
                int lenght = fileName.Length;
                string[] row = { fileName[lenght - 1] };
                var lvi = new ListViewItem(row);
                listView1.Items.Add(lvi);
            }
            foreach (string pl in lst)
            {
                listView1.Items.Add(pl);

            }

        }

        private void listdowload_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.ShowDialog();
            ftpClient.download($"lab6/files/{textBox1.Text}",@sfd.FileName);
            MessageBox.Show("dowload completed");
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}