using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartPhoneClient
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //List<SmartPhone> SmartPhones = new SmartPhoneBUS().GetAll();
            //dgvSmartPhone.DataSource = SmartPhones;
            new SmartPhonesBUS2().ListenFirebase(dgvSmartPhone);
           
        }

        private async void dgvSmartPhone_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvSmartPhone.SelectedRows.Count > 0)
            {
                int code = int.Parse(dgvSmartPhone.SelectedRows[0].Cells["Code"].Value.ToString());
                //SmartPhone SmartPhone = new SmartPhoneBUS().GetDetails(code);
                SmartPhone SmartPhone = await new SmartPhonesBUS2().GetDetails(code);
                if (SmartPhone != null)
                {
                    txtCode.Text = SmartPhone.Code.ToString();
                    txtCodeView.Text = SmartPhone.Code.ToString();
                    txtName.Text = SmartPhone.Name;
                    txtBrand.Text = SmartPhone.Brand;
                    txtPrice.Text = SmartPhone.Price.ToString();
                    txtDescription.Text = SmartPhone.Color;
                }
            }
        }

        private async void btnSearch_Click(object sender, EventArgs e)
        {
            String keyword = txtKeyword.Text.Trim();
            if(keyword.Trim().Length == 0)
            {
                MessageBox.Show("PLEASE INSERT KEYWORD");
                //List<SmartPhone> SmartPhones = new SmartPhoneBUS().GetAll();
                //dgvSmartPhone.DataSource = SmartPhones;
                new SmartPhonesBUS2().ListenFirebase(dgvSmartPhone);

            }
            else
            {
                List<SmartPhone> SmartPhones = await new SmartPhonesBUS2().Search(keyword);
                dgvSmartPhone.BeginInvoke(new MethodInvoker(delegate { dgvSmartPhone.DataSource = SmartPhones; }));
            }
            
        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            int code = int.Parse(txtCodeView.Text.Trim());
            String name = txtName.Text.Trim();
            String brand = txtBrand.Text.Trim();
            int price = int.Parse(txtPrice.Text.Trim());
            String description = txtDescription.Text.Trim();

            SmartPhone addSmartPhone = new SmartPhone()
            {
                Code = code,
                Name = name,
                Brand = brand,
                Price = price,
                Color = description
            };
            //bool result = new SmartPhoneBUS().Add(addSmartPhone);
            bool result = await new SmartPhonesBUS2().Add(addSmartPhone);

            if (result)
            {
                //List<SmartPhone> SmartPhones = new SmartPhoneBUS().GetAll();
                //dgvSmartPhone.DataSource = SmartPhones;
                new SmartPhonesBUS2().ListenFirebase(dgvSmartPhone);
            }
            else
            {
                MessageBox.Show("CAN NOT ADD NEW PRODUCT");
            }        
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            int code = int.Parse(txtCode.Text.Trim());
            DialogResult dialogResult = MessageBox.Show("Sure ?", "CONFIRMATION", MessageBoxButtons.OKCancel);
            if (dialogResult == DialogResult.OK)
            {
                bool result = await new SmartPhonesBUS2().Delete(code);
                if (result)
                {
                    new SmartPhonesBUS2().ListenFirebase(dgvSmartPhone);
                }
                else
                {
                    MessageBox.Show("NOT NOW");
                }
            }
        }

        private async void btnUpdate_Click(object sender, EventArgs e)
        {
            int code = int.Parse(txtCodeView.Text.Trim());
            String name = txtName.Text.Trim();
            String brand = txtBrand.Text.Trim();
            int price = int.Parse(txtPrice.Text.Trim());
            String description = txtDescription.Text.Trim();

            SmartPhone newSmartPhone = new SmartPhone()
            {
                Code = code,
                Name = name,
                Brand = brand,
                Price = price,
                Color = description
            };
            bool result = await new SmartPhonesBUS2().Update(newSmartPhone);
            if (result)
            {
                //List<SmartPhone> SmartPhones = new SmartPhoneBUS().GetAll();
                //dgvSmartPhone.DataSource = SmartPhones;

                new SmartPhonesBUS2().ListenFirebase(dgvSmartPhone);
            }
            else
            {
                MessageBox.Show("CAN NOT UPDATE");
            }
        }
    }
}
