using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GameEngine;

namespace MillionWebForm
{
    public partial class MainWForm : System.Web.UI.Page
    {
        //static string _file = "111.xml";
        //private Game _game = new Game();

        protected void Page_Load(object sender, EventArgs e)
        {
            lblMoney.Text = Game.OwnMoney().ToString();
            //_game = new Game();
            //InitQuestion();
            
        }

        private void InitQuestion ()
        {
            //btnA1.Text = _game.CurrentQuestion.Answers.ElementAt(0).Key;
            //btnA2.Text = _game.CurrentQuestion.Answers.ElementAt(1).Key;
            //btnA3.Text = _game.CurrentQuestion.Answers.ElementAt(2).Key;
            //btnA4.Text = _game.CurrentQuestion.Answers.ElementAt(3).Key;

            //btnA1.Text = GlobalApp.Game.CurrentQuestion.Answers[0].Name;
            //btnA2.Text = _game.CurrentQuestion.Answers[1].Name;
            //btnA3.Text = _game.CurrentQuestion.Answers[2].Name;
            //btnA4.Text = _game.CurrentQuestion.Answers[3].Name;
            //lblQuestion.Text = _game.CurrentQuestion.Name;

            //if (Game != null)
            //{
                btnA1.Text = Game.CurrentQuestion.Answers[0].Name;
                btnA2.Text = Game.CurrentQuestion.Answers[1].Name;
                btnA3.Text = Game.CurrentQuestion.Answers[2].Name;
                btnA4.Text = Game.CurrentQuestion.Answers[3].Name;
                lblQuestion.Text = Game.CurrentQuestion.Name;

                lblMoney.Text = string.Format("Your Own Money = {0}", Game.OwnMoney().ToString());
                lblCurrentMoney.Text = string.Format("Your Current Money = {0}", Game.WinMoney.ToString()); 

            //}
            //AnswersPanel.Controls.Add(btnA1);
        }

        protected void btnA1_Click(object sender, EventArgs e)
        {
            Game.RunGame(btnA1.Text);
            if (Game.CurrentQuestion != null)
            {
                InitQuestion();
            }
            else
            {
                lblQuestion.Text = String.Format("Wrong answer. You won {0}", Game.WinMoney.ToString());
            }
        }

        protected void btnA2_Click(object sender, EventArgs e)
        {
            Game.RunGame(btnA2.Text);
            if (Game.CurrentQuestion != null)
            {
                InitQuestion();
            }
            else
            {
                lblQuestion.Text = String.Format("Wrong answer. You won {0}", Game.WinMoney.ToString());
            }
        }

        protected void btnA3_Click(object sender, EventArgs e)
        {
            Game.RunGame(btnA3.Text);
            if (Game.CurrentQuestion != null)
            {
                InitQuestion();
            }
            else
            {
                lblQuestion.Text = String.Format("Wrong answer. You won {0}", Game.WinMoney.ToString());
            }
        }

        protected void btnA4_Click(object sender, EventArgs e)
        {
            Game.RunGame(btnA4.Text);
            if (Game.CurrentQuestion != null)
            {
                InitQuestion();
            }
            else
            {
                lblQuestion.Text = String.Format("Wrong answer. You won {0}", Game.WinMoney.ToString());
            }
        }

        protected void btnFifty_Click(object sender, EventArgs e)
        {
            Game.FifityFifty();
            InitQuestion();
            btnFifty.Enabled = false;
        }

        protected void btnStart_Click(object sender, EventArgs e)
        {
            Game.StartGame();

            btnA1.Enabled = true;
            btnA2.Enabled = true;
            btnA3.Enabled = true;
            btnA4.Enabled = true;
            btnAksHall.Enabled = true;
            btnAskFriend.Enabled = true;
            btnFifty.Enabled = true;

            InitQuestion();
        }

        protected void btnAskFriend_Click(object sender, EventArgs e)
        {
            btnAskFriend.Enabled = false;
            string question = Game.CurrentQuestion.Name;
            string request = String.Format("http://www.google.com/search?q=" + question);
            Response.Redirect(request);
        }


    }
}