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
using UserMaintenance.Entities;

namespace UserMaintenance
{
    public partial class Form1 : Form
    {
        BindingList<User> users = new BindingList<User>();

        public Form1()
        {
            InitializeComponent();
            label1.Text = Resource1.FullName;
            
            button1.Text = Resource1.Add;
            button2.Text = Resource1.ToFile;
            listBox1.DataSource = users;
            listBox1.ValueMember = "ID";
            listBox1.DisplayMember = "FullName";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var u = new User()
            {
                Fullname = textBox1.Text
                

            };
            users.Add(u);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfiledialog = new SaveFileDialog();
            sfiledialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            if (sfiledialog.ShowDialog()==DialogResult.OK)
            {
                var path = sfiledialog.FileName;
                StreamWriter writer = new StreamWriter(path);
                foreach (var item in users)
                {
                    writer.WriteLine(item);
                }
                writer.Close();
            }
        }
    }
}
