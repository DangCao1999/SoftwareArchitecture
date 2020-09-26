using SoftwareArchitecture.BLL;
using SoftwareArchitecture.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SoftwareArchitecture.PL
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

       

        private void MainForm_Load(object sender, EventArgs e)
        {
            List<SmartPhone> smartPhones = new SmartPhoneBUS().getAllList();
            dataGridView1.DataSource = smartPhones;
        }

        
    }
}
