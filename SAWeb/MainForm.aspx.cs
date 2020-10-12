using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SAWeb
{
    public partial class MainForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

    

        protected void btSubmit_Click1(object sender, EventArgs e)
        {
            TextBox1.Text = "hello world";
        }
    }
}