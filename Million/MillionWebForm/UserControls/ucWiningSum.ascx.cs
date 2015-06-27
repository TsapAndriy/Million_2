using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Million.GameEngine;

namespace Million.WebForm.UserControls
{
    public partial class ucWiningSum : System.Web.UI.UserControl
    {
        public Game _game { get; set; }

        //private CheckBoxList _cbx;

        public CheckBoxList Cbx
        {
            get
            {
                //return this.cblWinningSums;
                return ChangeCbx();
            }
            private set
            {
                value = this.cblWinningSums;
            }
        }

        public ucWiningSum()
        {

        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        private CheckBoxList ChangeCbx()
        {
            //CheckBoxList tmpCbx = new CheckBoxList();
            for (int i = 0; i < _game.Money.Length; i++)
            {
                this.cblWinningSums.Items.Add(new ListItem(_game.Money[i].ToString(), (i + 1).ToString(), _game.WinMoney == _game.Money[i]));
            }
            //this.cblWinningSums = tmpCbx;

            return this.cblWinningSums;
        }


    }
}