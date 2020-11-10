using AppShared;
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
    public partial class Form1 : Form
    {
        //ISmartPhoneBUS smartPhoneBUS;
        host.gear.cao2246soap.SOAPService SOAPservice;
        public Form1()
        {
            InitializeComponent();
            //string uri = "tcp://127.0.0.1:6868/abc";
            //smartPhoneBUS = (ISmartPhoneBUS)Activator.GetObject(typeof(ISmartPhoneBUS), uri);

            SOAPservice = new host.gear.cao2246soap.SOAPService();

        }

        private void Form1_Load(object sender, EventArgs e)
        {

            //List<Smartphone> smartphones = smartPhoneBUS.getAllList();
            //dataGridView1.DataSource = smartphones;

            
            List<host.gear.cao2246soap.Smartphone> smartphones = SOAPservice.getAllList().ToList();
            dataGridView1.DataSource = smartphones;
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {

           host.gear.cao2246soap.Smartphone smartphone = new host.gear.cao2246soap.Smartphone()
            {
                Brand = textBoxBrand.Text,
                Name = textBoxName.Text,
                Color = textBoxColor.Text,
                Price = Convert.ToInt32(textBoxPrice.Text)
            };

            bool rs = SOAPservice.addSmartPhone(smartphone);

            if (rs)
            {
                List<host.gear.cao2246soap.Smartphone> smartPhones = SOAPservice.getAllList().ToList();
                dataGridView1.DataSource = smartPhones;
            }
            else
            {
                MessageBox.Show("Something Wrong!!!");
            }
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            if (textBoxCode.Text == null)
            {
                MessageBox.Show("Code is null!!!");
            }
            else
            {
                host.gear.cao2246soap.Smartphone smartPhone = new host.gear.cao2246soap.Smartphone()
                {
                    Code = Convert.ToInt16(textBoxCode.Text),
                    Brand = textBoxBrand.Text,
                    Name = textBoxName.Text,
                    Color = textBoxColor.Text,
                    Price = Convert.ToInt32(textBoxPrice.Text)
                };
                bool rs = SOAPservice.updateSmartPhone(smartPhone);
                if (rs)
                {
                    MessageBox.Show("Edit Sucess ^.^");
                    List<host.gear.cao2246soap.Smartphone> smartPhones = SOAPservice.getAllList().ToList();
                    dataGridView1.DataSource = smartPhones;
                }
                else MessageBox.Show("Something Wrong!!!");
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            int code = int.Parse(textBoxCode.Text.Trim());
            DialogResult dialog = MessageBox.Show("Are You Sure?", "CONFIRMATION", MessageBoxButtons.YesNo);
            if (dialog == DialogResult.Yes)
            {
                bool result = SOAPservice.deleteSmartPhoneByCode(code);
                if (result)
                {
                    List<host.gear.cao2246soap.Smartphone> smartPhones = SOAPservice.getAllList().ToList();
                    dataGridView1.DataSource = smartPhones;
                }
                else
                {
                    MessageBox.Show("Something Wrong!!!");
                }
            }

        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                textBoxCode.Text = dataGridView1.SelectedRows[0].Cells["Code"].Value.ToString();
                textBoxName.Text = dataGridView1.SelectedRows[0].Cells["Name"].Value.ToString();
                textBoxBrand.Text = dataGridView1.SelectedRows[0].Cells["Brand"].Value.ToString();
                textBoxPrice.Text = dataGridView1.SelectedRows[0].Cells["Price"].Value.ToString();
                textBoxColor.Text = dataGridView1.SelectedRows[0].Cells["Color"].Value.ToString();
            }
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            string keyword = textBoxSearch.Text;
            List<host.gear.cao2246soap.Smartphone> smartPhones = SOAPservice.searchByName(keyword).ToList();
            dataGridView1.DataSource = smartPhones;
        }
    }
}
