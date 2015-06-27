using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Million.GameEngine;

namespace Million.WebForm
{
    public partial class Start : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnStart_Click(object sender, EventArgs e)
        {
            Game.Name = tbxName.Text.ToString();
            if (Game.Name != null)
            {
                Response.Redirect("Main.aspx");
            }
        }
    }
}