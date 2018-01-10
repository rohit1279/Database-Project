using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Oracle.DataAccess.Client; // ODP.NET Oracle managed provider
using Oracle.DataAccess.Types;
using System.Text;

namespace Sports_Website.Agents
{
    public partial class PostsPage : System.Web.UI.Page
    {
        StringBuilder htmlTable = new StringBuilder();
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
                Validate.Text = "Validate Posts";
            }
            else
            {
                Posts.Text = "Posts (" + count + ")";
                Validate.Text = "Validate Posts (" + count + ")";
            }

            htmlTable.Append("<table>");

            if (count > 0)
            {
                string sql1 = "SELECT TITLE, DESCRIPTION1, DESCRIPTION2, DOCUMENT1, DOCUMENT2, IMAGE1, POSTED_BY FROM USER_ARTICLES WHERE VALID_FLAG='N' "; // C#
                OracleCommand cmd1 = new OracleCommand(sql1, conn);
                OracleDataReader dr1 = cmd1.ExecuteReader();

                while (dr1.Read())
                {
                    htmlTable.Append("<tr><td rowspan=\"3\">");

                    byte[] bytes = (byte[])dr1["IMAGE1"];
                    string base64String = Convert.ToBase64String(bytes, 0, bytes.Length);
                    string ImageUrl = "data:image/png;base64," + base64String;
                    htmlTable.Append("<img src=\"" + ImageUrl + "\" Height=\"150px\" Width=\"150px\" Visible = \"true\"/></td><td style=\"text-align:left\"><span style=\"font-weight:bold\">Title: </span>");
                    htmlTable.Append("<a>" + dr1["TITLE"].ToString() + " </a> </td></tr><tr>");
                    htmlTable.Append("<td style=\"text-align:left\"><span style=\"font-weight:bold\">Description: </span><p>" + dr1["DESCRIPTION1"].ToString() + " </p></td></tr><tr><td>");
                    string sql2 = "SELECT FIRST_NAME||' '||LAST_NAME AS NAME FROM USERS WHERE ID= '" + dr1["POSTED_BY"].ToString() + "'"; // C#
                    OracleCommand cmd2 = new OracleCommand(sql2, conn);
                    OracleDataReader dr2 = cmd2.ExecuteReader();
                    dr2.Read();
                    htmlTable.Append("<div style='float: left; text-align: left'><span style=\"font-weight:bold\">Posted_by: </span> <span>" + dr2["NAME"].ToString() + "</span></div><div style='float: right; text-align: right'>");
                    
                    if (dr1["DOCUMENT2"].ToString() == null)
                    {
                        htmlTable.Append("<a>Document 1</a>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;");
                    }
                    else
                    {
                        htmlTable.Append("<a>Document 1</a>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<a>Document 2</a>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;");
                    }

                    htmlTable.Append("<button type=\"button\" onclick=\"Publish_click\" >Publish</button>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<button type=\"button\">Delete</button>");
                    dr2.Dispose();
                }
                dr1.Dispose();
                htmlTable.Append("</table>");
                DBDataPlaceHolder.Controls.Add(new Literal { Text = htmlTable.ToString() });
                //byte[] bytes = (byte[])dr1["IMAGE1"];
                //string base64String = Convert.ToBase64String(bytes, 0, bytes.Length);
                //Image1.ImageUrl = "data:image/png;base64," + base64String;
                //Article_Title.Text = Article_Title.Text + dr1["TITLE"].ToString();
                //Description.Text = Description.Text + "\n" + dr1["DESCRIPTION1"].ToString();
                //Posted_by.Text = "Rohith Movva";
                //byte[] bytes2 = (byte[])dr1["DOCUMENT1"];
                //string base64String2 = Convert.ToBase64String(bytes2, 0, bytes2.Length);
                //Document1.ImageUrl = "data:image/png;base64," + base64String2;
                //byte[] bytes3 = (byte[])dr1["DOCUMENT2"];
                //string base64String3 = Convert.ToBase64String(bytes3, 0, bytes3.Length);
                //Document2.ImageUrl = "data:image/png;base64," + base64String3;
            }
            else
            {
                htmlTable.Append(" <tr><td><span style=\"font-weight:bold; text-align:center\">There are no posts to validate </span></td></tr></table>");
            }
            dr3.Dispose();
            conn.Dispose();
        }
        protected void Timer1_Tick(object sender, EventArgs e)
        {
            Time.Text = DateTime.Now.ToString();
        }
        protected void Players_Click(object sender, EventArgs e)
        {
            Response.Redirect("PlayersPage.aspx");
        }
        protected void Tournaments_Click(object sender, EventArgs e)
        {
            Response.Redirect("TournamentsPage.aspx");
        }
        protected void Tickets_Click(object sender, EventArgs e)
        {
            Response.Redirect("TicketsPage.aspx");
        }
        protected void Save_Click(object sender, EventArgs e)
        {
             OracleConnection conn = new OracleConnection("Data Source=MyDB;User Id=DB626;Password=infra@2017;");
            conn.Open();

            string sql = "UPDATE USER_ARTICLES SET VALID_FLAG='Y', VALIDATED_BY=(SELECT USERID FROM LOGIN_PROFILE WHERE ROLE_ID=2 AND UPPER(USERNAME)=UPPER('" + Session["UserName"].ToString() + "')), VALIDATED_DT=SYSDATE WHERE ID=(SELECT MAX(ID) FROM USER_ARTICLES)";
            OracleCommand cmd = new OracleCommand(sql, conn);
            cmd.ExecuteNonQuery();
            conn.Dispose();

            Response.Write("<script LANGUAGE='JavaScript' >alert('Article Posted successfully')</script>");
            Response.Redirect("HomePage.aspx");
        }
        protected void Cancel_Click(object sender, EventArgs e)
        {

        }
    }
}