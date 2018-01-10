using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Oracle.DataAccess.Client; // ODP.NET Oracle managed provider
using Oracle.DataAccess.Types;

namespace Sports_Website.Agents
{
    public partial class PlayersPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            OracleConnection conn = new OracleConnection("Data Source=MyDB;User Id=DB626;Password=infra@2017;");
            conn.Open();

            string sql3 = "SELECT COUNT(*) AS COUNT FROM USER_ARTICLES WHERE VALID_FLAG='N'"; // C#
            OracleCommand cmd3 = new OracleCommand(sql3, conn);
            OracleDataReader dr3 = cmd3.ExecuteReader();
            dr3.Read();
            int count = Convert.ToInt32(dr3["COUNT"].ToString());
            if (count == 0)
            {
                Posts.Text = "Posts";
            }
            else
            {
                Posts.Text = "Posts (" + count + ")";
            }
            dr3.Dispose();
            conn.Dispose();
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