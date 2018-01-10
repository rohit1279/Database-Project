using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Sports_Website
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void ImageButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("https://en.wikipedia.org/wiki/Cricket");
        }
        protected void ImageButton2_Click(object sender, EventArgs e)
        {
            Response.Redirect("https://en.wikipedia.org/wiki/Football");
        }
        protected void ImageButton3_Click(object sender, EventArgs e)
        {
            Response.Redirect("https://en.wikipedia.org/wiki/Basketball");
        }
        protected void ImageButton4_Click(object sender, EventArgs e)
        {
            Response.Redirect("https://en.wikipedia.org/wiki/Tennis");
        }
        protected void ImageButton5_Click(object sender, EventArgs e)
        {
            Response.Redirect("https://en.wikipedia.org/wiki/Baseball");
        }
        protected void ImageButton6_Click(object sender, EventArgs e)
        {
            Response.Redirect("https://en.wikipedia.org/wiki/Hockey");
        }
        protected void ImageButton7_Click(object sender, EventArgs e)
        {
            Response.Redirect("https://en.wikipedia.org/wiki/Badminton");
        }
        protected void ImageButton8_Click(object sender, EventArgs e)
        {
            Response.Redirect("https://en.wikipedia.org/wiki/Volleyball");
        }
        protected void ImageButton9_Click(object sender, EventArgs e)
        {
            Response.Redirect("https://en.wikipedia.org/wiki/Golf");
        }
    }
}