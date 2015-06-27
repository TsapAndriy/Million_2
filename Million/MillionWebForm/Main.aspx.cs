using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Million.GameEngine;

namespace Million.WebForm
{
    public partial class Main : System.Web.UI.Page
    {
        private string _questionsFileXML;
        private Game _game;

        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["_game"] == null)
            {
                //_game = new Game();
                //Session["_game"] = _game;

                _game = new Game();
                _questionsFileXML = Server.MapPath("/App_Data/333.xml");
                _game.StartGame(_questionsFileXML);
                HttpContext.Current.Session["_game"] = _game;
                btnA1.Enabled = true;
                btnA2.Enabled = true;
                btnA3.Enabled = true;
                btnA4.Enabled = true;
                btnAksHall.Enabled = true;
                btnAskFriend.Enabled = true;
                btnFifty.Enabled = true;
                InitQuestion();
                ucWiningSum._game = this._game;

                Session["_game"] = _game;
            }
            else
            {
                _game = (Game)Session["_game"];
            }
        }

        private void InitQuestion()
        {
            btnA1.Text = _game.CurrentQuestion.Answers[0].Name;
            btnA2.Text = _game.CurrentQuestion.Answers[1].Name;
            btnA3.Text = _game.CurrentQuestion.Answers[2].Name;
            btnA4.Text = _game.CurrentQuestion.Answers[3].Name;
            lblQuestion.Text = _game.CurrentQuestion.Name;

            lblMoney.Text = string.Format("Your Own Money = {0}", _game.OwnMoney().ToString());
            lblCurrentMoney.Text = string.Format("Your Current Money = {0}", _game.WinMoney.ToString());

            ucWiningSum._game = this._game;

            //this.Controls.Add(ucWiningSum.Cbx);             
        }

        protected void btnA1_Click(object sender, EventArgs e)
        {
            _game.RunGame(btnA1.Text);
            Session["_game"] = _game;
            if (!_game.IsEndGame())
            {
                if (_game.CurrentQuestionAnswer)
                {
                    InitQuestion();
                }
                else
                {
                    //lblQuestion.Text = String.Format("Wrong answer. You won {0}", _game.WinMoney.ToString());
                    Response.Redirect("End.aspx");
                }
            }
            else
            {
                lblQuestion.Text = String.Format("You won !!! Get your {0} !!!", _game.Money[_game.Money.Length - 1].ToString());
            }
        }

        protected void btnA2_Click(object sender, EventArgs e)
        {
            _game.RunGame(btnA2.Text);
            Session["_game"] = _game;
            if (!_game.IsEndGame())
            {
                if (_game.CurrentQuestionAnswer)
                {
                    InitQuestion();
                }
                else
                {
                    //lblQuestion.Text = String.Format("Wrong answer. You won {0}", _game.WinMoney.ToString());
                    Response.Redirect("End.aspx");
                }
            }
            else
            {
                lblQuestion.Text = String.Format("You won !!! Get your {0} !!!", _game.Money[_game.Money.Length - 1].ToString());
            }
        }

        protected void btnA3_Click(object sender, EventArgs e)
        {
            _game.RunGame(btnA3.Text);
            Session["_game"] = _game;
            if (!_game.IsEndGame())
            {
                if (_game.CurrentQuestionAnswer)
                {
                    InitQuestion();
                }
                else
                {
                    //lblQuestion.Text = String.Format("Wrong answer. You won {0}", _game.WinMoney.ToString());
                    Response.Redirect("End.aspx");
                }
            }
            else
            {
                lblQuestion.Text = String.Format("You won !!! Get your {0} !!!", _game.Money[_game.Money.Length - 1].ToString());
            }
        }

        protected void btnA4_Click(object sender, EventArgs e)
        {
            _game.RunGame(btnA4.Text);
            Session["_game"] = _game;
            if (!_game.IsEndGame())
            {
                if (_game.CurrentQuestionAnswer)
                {
                    InitQuestion();
                }
                else
                {
                    //lblQuestion.Text = String.Format("Wrong answer. You won {0}", _game.WinMoney.ToString());
                    Response.Redirect("End.aspx");
                }
            }
            else
            {
                lblQuestion.Text = String.Format("You won !!! Get your {0} !!!", _game.Money[_game.Money.Length - 1].ToString());
            }
        }

        protected void btnFifty_Click(object sender, EventArgs e)
        {
            _game.FifityFifty();
            Session["_game"] = _game;
            InitQuestion();
            btnFifty.Enabled = false;
        }

        protected void btnAskFriend_Click(object sender, EventArgs e)
        {
            btnAskFriend.Enabled = false;
            string question = _game.CurrentQuestion.Name;
            string request = String.Format("http://www.google.com/search?q=" + question);
            Response.Redirect(request);
        }
    }
}