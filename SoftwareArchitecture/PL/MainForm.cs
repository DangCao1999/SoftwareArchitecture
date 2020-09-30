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
            List<Smartphone> smartPhones = new SmartPhoneBUS().getAllList();
            dataGridView1.DataSource = smartPhones;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Smartphone smartphone = new Smartphone()
            {
                Brand = textBoxBrand.Text,
                Name = textBoxName.Text,
                Color = textBoxColor.Text,
                Price = Convert.ToInt32(textBoxPrice.Text)
            };

            bool rs = new SmartPhoneBUS().addSmartPhone(smartphone);

            if(rs)
            {
                List<Smartphone> smartPhones = new SmartPhoneBUS().getAllList();
                dataGridView1.DataSource = smartPhones;
            }
            else
            {
                MessageBox.Show("Somgthing Wrong!!!");
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

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            int code = int.Parse(textBoxCode.Text.Trim());
            DialogResult dialog = MessageBox.Show("Are You Sure?", "CONFIRMATION", MessageBoxButtons.YesNo);
            if (dialog == DialogResult.Yes)
            {
                bool result = new SmartPhoneBUS().deleteSmartPhoneByCode(code);
                if (result)
                {
                    List<Smartphone> smartPhones = new SmartPhoneBUS().getAllList();
                    dataGridView1.DataSource = smartPhones;
                }
                else
                {
                    MessageBox.Show("Something Wrong!!!");
                }
            }
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            string keyword = textBoxSearch.Text;
            List<Smartphone> smartPhones = new SmartPhoneBUS().searchByName(keyword);
            dataGridView1.DataSource = smartPhones;
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            if(textBoxCode.Text == null)
            {
                MessageBox.Show("Code is null!!!");
            }
            else
            {
                SmartPhone smartPhone = new SmartPhone()
                {
                    Code = Convert.ToInt16(textBoxCode.Text),
                    Brand = textBoxBrand.Text,
                    Name = textBoxName.Text,
                    Color = textBoxColor.Text,
                    Price = Convert.ToInt32(textBoxPrice.Text)
                };
                bool rs = new SmartPhoneBUS().updateSmartPhone(smartPhone);
                if (rs)
                {
                    MessageBox.Show("Edit Sucess ^.^");
                    List<Smartphone> smartPhones = new SmartPhoneBUS().getAllList();
                    dataGridView1.DataSource = smartPhones;
                }
                else MessageBox.Show("Something Wrong!!!");
            }
        }
    }
}
