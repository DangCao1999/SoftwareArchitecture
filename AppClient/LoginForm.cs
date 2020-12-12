using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppClient
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text.Trim();
            string password = textBox2.Text.Trim();
            int code = Convert.ToInt32(textBox3.Text);

            User userRe = new User()
            {
                code = code,
                username = username,
                password = password
            };
            bool rs = await new UserBUS().register(userRe);
            
            if(rs)
            {
                MessageBox.Show("OK Done");
            }   
            else
            {
                MessageBox.Show("Sr SomeThingWrong");
            }    
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text.Trim();
            string password = textBox2.Text.Trim();
            User userRe = new User()
            {
                username = username,
                password = password
            };
            bool rs = await new UserBUS().login(userRe);
            if (rs)
            {
                this.Hide();
                Form1 form = new Form1();
                form.Show();
            }
            else
            {
                MessageBox.Show("Sr SomeThingWrong");
            }
        }
    }
}
