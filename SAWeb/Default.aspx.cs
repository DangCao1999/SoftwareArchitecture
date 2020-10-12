using SAWeb.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SAWeb.BLL;
using Antlr.Runtime;

namespace SAWeb
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                getAndBindingList();
            }
        }

        protected void getAndBindingList()
        {
            List<Smartphone> smartphones = new SmartPhoneBUS().getAllList();
            GridView1.DataSource = smartphones;
            GridView1.DataBind();
        }

        protected void btSubmit_Click1(object sender, EventArgs e)
        {
            Smartphone smartphone = new Smartphone()
            {
                Name = TextBoxName.Text.Trim(),
                Brand = TextBoxBrand.Text.Trim(),
                Color = TextBoxColor.Text.Trim(),
                Price = Convert.ToInt32(TextBoxPrice.Text),
            };

            bool rs = new SmartPhoneBUS().addSmartPhone(smartphone);
            if(rs)
            {
                getAndBindingList();
                ClientScript.RegisterStartupScript(this.GetType(), "ToastSucess", "showToastSucess();", true);
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "ToastFail", "showToastFail();", true);
            }
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            TextBoxCode.Text = GridView1.SelectedRow.Cells[1].Text.Trim();
            TextBoxName.Text = GridView1.SelectedRow.Cells[2].Text.Trim();
            TextBoxPrice.Text = GridView1.SelectedRow.Cells[3].Text.Trim();
            TextBoxBrand.Text = GridView1.SelectedRow.Cells[4].Text.Trim();
            TextBoxColor.Text = GridView1.SelectedRow.Cells[5].Text.Trim();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string keyword = TextBoxSearch.Text.Trim();
            List<Smartphone> smartphones = new SmartPhoneBUS().searchByName(keyword);
            GridView1.DataSource = smartphones;
            GridView1.DataBind();
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            Smartphone smartphone = new Smartphone()
            {
                Name = TextBoxName.Text.Trim(),
                Brand = TextBoxBrand.Text.Trim(),
                Color = TextBoxColor.Text.Trim(),
                Price = Convert.ToInt32(TextBoxPrice.Text),
                Code = Convert.ToInt32( TextBoxCode.Text)
            };

            bool rs = new SmartPhoneBUS().updateSmartPhone(smartphone);
            if (rs)
            {
                getAndBindingList();
                ClientScript.RegisterStartupScript(this.GetType(), "ToastSucess", "showToastSucess();", true);
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "ToastFail", "showToastFail();", true);
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {

        }

        protected void btnDeleteConfirm_Click(object sender, EventArgs e)
        {
            int code = Convert.ToInt32(TextBoxCode.Text);
            bool rs = new SmartPhoneBUS().deleteSmartPhoneByCode(code);
            if (rs)
            {
                getAndBindingList();
                ClientScript.RegisterStartupScript(this.GetType(), "ToastSucess", "showToastSucess();", true);
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "ToastFail", "showToastFail();", true);
            }
            TextBoxBrand.Text = "";
            TextBoxCode.Text = "";
            TextBoxColor.Text = "";
            TextBoxName.Text = "";
            TextBoxPrice.Text = "";
        }
    }
}