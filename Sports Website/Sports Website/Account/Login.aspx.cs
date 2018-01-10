using System;
using System.Web;
using System.Web.UI;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Owin;
using Sports_Website.Models;
using Oracle.DataAccess.Client; // ODP.NET Oracle managed provider
using Oracle.DataAccess.Types;
using System.Web.Security;

namespace Sports_Website.Account
{
    public partial class Login : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            RegisterHyperLink.NavigateUrl = "Register";
            // Enable this once you have account confirmation enabled for password reset functionality
            //ForgotPasswordHyperLink.NavigateUrl = "Forgot";
            var returnUrl = HttpUtility.UrlEncode(Request.QueryString["ReturnUrl"]);
            if (!String.IsNullOrEmpty(returnUrl))
            {
                RegisterHyperLink.NavigateUrl += "?ReturnUrl=" + returnUrl;
            }
        }

        protected void LogIn(object sender, EventArgs e)
        {
            string username = Username.Text;
            string password = Password.Text;

            ErrorTextBox1.Visible = false;
            ErrorTextBox2.Visible = false;
            OracleConnection conn = new OracleConnection("Data Source=MyDB;User Id=DB626;Password=infra@2017;"); //Database details
            conn.Open();
            string sql = "SELECT COUNT(DISTINCT USERNAME) AS COUNT FROM LOGIN_PROFILE WHERE UPPER(USERNAME)=UPPER('" + username + "')";
            OracleCommand cmd = new OracleCommand(sql, conn);
            OracleDataReader dr = cmd.ExecuteReader();
            dr.Read();
            int count = Convert.ToInt32(dr["COUNT"].ToString());
            if(count==0)
            {
                ErrorTextBox1.Visible = true;
            }
            else
            {
                string sql1 = "SELECT USERNAME,PASSWORD,ROLE_ID FROM LOGIN_PROFILE WHERE UPPER(USERNAME)=UPPER('" + username + "')";
                OracleCommand cmd1 = new OracleCommand(sql1, conn);
                OracleDataReader dr1 = cmd1.ExecuteReader();
                dr1.Read();
                string password_db = dr1["PASSWORD"].ToString();
                if(password==password_db)
                {
                    string sql2 = "UPDATE LOGIN_PROFILE SET NO_OF_LOGINS=NO_OF_LOGINS+1,LASTLOGINDATE=SYSDATE,LOGINSTATUS='LoggedIn Successfully' WHERE UPPER(USERNAME)=UPPER('" + username + "')";
                    OracleCommand cmd2 = new OracleCommand(sql2, conn);
                    cmd2.ExecuteNonQuery();
                    Session["UserName"] = Username.Text;
                    /*FormsAuthentication.RedirectFromLoginPage(Username.Text, false);*/
                    
                    FormsAuthentication.SetAuthCookie(Username.Text, false);

                    if (dr1["ROLE_ID"].ToString() == "3")
                    {
                        Response.Redirect("~/Users/HomePage.aspx");
                    }
                    else if(dr1["ROLE_ID"].ToString() == "2")
                    {
                        Response.Redirect("~/Agents/HomePage.aspx");
                    }
                }
                else
                {
                    ErrorTextBox2.Visible = true;
                }
            }
            
            /*if (IsValid)
            {
                // Validate the user password
                var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
                var signinManager = Context.GetOwinContext().GetUserManager<ApplicationSignInManager>();

                // This doen't count login failures towards account lockout
                // To enable password failures to trigger lockout, change to shouldLockout: true
                var result = signinManager.PasswordSignIn(Username.Text, Password.Text, RememberMe.Checked, shouldLockout: false);

                switch (result)
                {
                    case SignInStatus.Success:
                        IdentityHelper.RedirectToReturnUrl(Request.QueryString["ReturnUrl"], Response);
                        break;
                    case SignInStatus.LockedOut:
                        Response.Redirect("/Account/Lockout");
                        break;
                    case SignInStatus.RequiresVerification:
                        Response.Redirect(String.Format("/Account/TwoFactorAuthenticationSignIn?ReturnUrl={0}&RememberMe={1}", 
                                                        Request.QueryString["ReturnUrl"],
                                                        RememberMe.Checked),
                                          true);
                        break;
                    case SignInStatus.Failure:
                    default:
                        FailureText.Text = "Invalid login attempt";
                        ErrorMessage.Visible = true;
                        break;
                }
            }*/
        }
    }
}