using System;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Owin;
using Sports_Website.Models;
using Oracle.DataAccess.Client; // ODP.NET Oracle managed provider
using Oracle.DataAccess.Types;

namespace Sports_Website.Account
{
    public partial class Register : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                OracleConnection conn = new OracleConnection("Data Source=MyDB;User Id=DB626;Password=infra@2017;");
                conn.Open();

                string sql = "SELECT COUNTRY FROM COUNTRIES ORDER BY 1"; // C#
                OracleCommand cmd = new OracleCommand(sql, conn);
                OracleDataReader dr = cmd.ExecuteReader();
              
                while (dr.Read())
                {
                    Country.Items.Add(dr["COUNTRY"].ToString());
                }
                dr.Dispose();

                string sql1 = "SELECT NAME FROM SPORTS ORDER BY 1"; // C#
                OracleCommand cmd1 = new OracleCommand(sql1, conn);
                OracleDataReader dr1 = cmd1.ExecuteReader();
                while (dr1.Read())
                {
                    Sports.Items.Add(dr1["NAME"].ToString());
                }
                dr1.Dispose();
                conn.Dispose();
            }
        }
        protected void CreateUser_Click(object sender, EventArgs e)
        {
            string fname = FirstName.Text;
            string mname = MiddleName.Text;
            string lname = LastName.Text;
            string Address1 = AddressLine1.Text;
            string Address2 = AddressLine2.Text;
            string city = City.Text;
            string state = State.Text;
            int zipcode = Convert.ToInt32(ZipCode.Text);
            string country = Country.Text;
            string email = Email.Text;
            string username = Username.Text;
            string password = Password.Text;

            OracleConnection conn = new OracleConnection("Data Source=MyDB;User Id=DB626;Password=infra@2017;");
            conn.Open();

            string sql = "SELECT COUNT(DISTINCT USERNAME) AS COUNT FROM LOGIN_PROFILE WHERE UPPER(USERNAME)=UPPER('"+username+"')";
            OracleCommand cmd = new OracleCommand(sql, conn);
            OracleDataReader dr = cmd.ExecuteReader();

            dr.Read();
            int count = Convert.ToInt32(dr["COUNT"].ToString());
            if(count==0)
            {
                string sql1="INSERT INTO USERS VALUES (USERS_ID_SEQ.NEXTVAL,'"+fname+"','"+mname+"','"+lname+"','"+Address1+"','"+Address2+"','"+city+"','"+state+"',(SELECT ID FROM COUNTRIES WHERE UPPER(COUNTRY)=UPPER('"+country+"')),'"+zipcode+"','','"+email+"',SYSDATE,SYSDATE)";
                OracleCommand cmd1 = new OracleCommand(sql1, conn);
                cmd1.ExecuteNonQuery();

                string sql2 = "INSERT INTO LOGIN_PROFILE VALUES ('" + username + "','" + password + "',USERS_ID_SEQ.CURRVAL,(SELECT ID FROM ROLES WHERE UPPER(ROLE)='USERS'),'LoggedIn Successfully',SYSDATE,0)";
                OracleCommand cmd2 = new OracleCommand(sql2, conn);
                cmd2.ExecuteNonQuery();

                foreach (ListItem item in Sports.Items)
                {
                    if (item.Selected == true)
                    {
                        string sql3 = "INSERT INTO USERS_SPORTS VALUES (USERS_SPORTS_ID_SEQ.NEXTVAL,USERS_ID_SEQ.CURRVAL,(SELECT ID FROM SPORTS WHERE UPPER(NAME)=UPPER('" + item + "')),SYSDATE)";
                        OracleCommand cmd3 = new OracleCommand(sql3, conn);
                        cmd3.ExecuteNonQuery();  
                    }
                }
                ErrorTextBox.Visible = false;
                Response.Redirect("~/Account/Login");
            }
            else
            {
                ErrorTextBox.Visible = true;
                /*UsernameValid.ErrorMessage = "Username already exists";
                Response.Write("<script LANGUAGE='JavaScript' >alert('Username already exists')</script>");*/
            }
            dr.Dispose();
            conn.Dispose();
           /* var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var signInManager = Context.GetOwinContext().Get<ApplicationSignInManager>();
            var user = new ApplicationUser() { UserName = Email.Text, Email = Email.Text };
            IdentityResult result = manager.Create(user, Password.Text);
            if (result.Succeeded)
            {
                // For more information on how to enable account confirmation and password reset please visit http://go.microsoft.com/fwlink/?LinkID=320771
                //string code = manager.GenerateEmailConfirmationToken(user.Id);
                //string callbackUrl = IdentityHelper.GetUserConfirmationRedirectUrl(code, user.Id, Request);
                //manager.SendEmail(user.Id, "Confirm your account", "Please confirm your account by clicking <a href=\"" + callbackUrl + "\">here</a>.");

                signInManager.SignIn( user, isPersistent: false, rememberBrowser: false);
                IdentityHelper.RedirectToReturnUrl(Request.QueryString["ReturnUrl"], Response);
            }
            else 
            {
                ErrorMessage.Text = result.Errors.FirstOrDefault();
            }*/
        }
        protected void Cancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Default");
        }
    }
}