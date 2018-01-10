﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Sports_Website.Users
{
    public partial class PlayersPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Timer1_Tick(object sender, EventArgs e)
        {
            Time.Text = DateTime.Now.ToString();
        }
        protected void Tournaments_Click(object sender, EventArgs e)
        {
            Response.Redirect("TournamentsPage.aspx");
        }
        protected void Tickets_Click(object sender, EventArgs e)
        {
            Response.Redirect("TicketsPage.aspx");
        }
        protected void Posts_Click(object sender, EventArgs e)
        {
            Response.Redirect("PostsPage.aspx");
        }
    }
}