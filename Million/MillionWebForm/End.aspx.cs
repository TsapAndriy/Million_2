using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Million.GameEngine;

namespace Million.WebForm
{
    public partial class End : System.Web.UI.Page
    {
        private Game _game;
        protected void Page_Load(object sender, EventArgs e)
        {
            _game = (Game)Session["_game"];
            lbl_Name.Text = Game.Name + "! ";
            lbl_result.Text = String.Format(_game.OwnMoney().ToString() + "$");
        }

        protected void btnGotostart_Click(object sender, EventArgs e)
        {
            //Response.Redirect("Start.aspx");
        }
    }
}