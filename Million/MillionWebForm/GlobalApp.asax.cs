using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using GameEngine;

namespace MillionWebForm
{
    public class GlobalApp : System.Web.HttpApplication
    {
        //public static Game Game;

        protected void Application_Start(object sender, EventArgs e)
        {
            //Game Game = new Game();
        }

        protected void Session_Start(object sender, EventArgs e)
        {
            //Game Game = new Game();

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}