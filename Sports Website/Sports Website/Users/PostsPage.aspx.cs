using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.IO;
using System.Web.UI.WebControls;
using Oracle.DataAccess.Client; // ODP.NET Oracle managed provider
using Oracle.DataAccess.Types;

namespace Sports_Website.Users
{
    class required{
        public static Stream fs1, fs2, fs3;
        public static BinaryReader br1, br2, br3;
        public static Byte[] bytes1 = null;
        public static Byte[] bytes2 = null;
        public static Byte[] bytes3 = null;
    }
    public partial class PostsPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                OracleConnection conn = new OracleConnection("Data Source=MyDB;User Id=DB626;Password=infra@2017;");
                conn.Open();

                string sql = "SELECT NAME FROM SPORTS WHERE ID IN (SELECT SPORT_ID FROM USERS_SPORTS WHERE USER_ID IN (SELECT USERID FROM LOGIN_PROFILE WHERE UPPER(USERNAME) = UPPER('" + Session["Username"].ToString() + "'))) ORDER BY 1";
                //string sql = "SELECT NAME FROM SPORTS WHERE ID IN (SELECT SPORT_ID FROM USERS_SPORTS WHERE USER_ID IN (SELECT USERID FROM LOGIN_PROFILE WHERE UPPER(USERNAME) = UPPER('movvar1279'))) ORDER BY 1";
                OracleCommand cmd = new OracleCommand(sql, conn);
                OracleDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    Sport.Items.Add(dr["NAME"].ToString());
                }
                dr.Dispose();
                conn.Dispose();
            }
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
        protected void Add1_Click(object sender, EventArgs e)
        {
            try
            {
                if (ListBox1.Items.Count < 1)
                {
                    if (FileUpload1.HasFile)
                    {
                        string ext = Path.GetExtension(Path.GetFileName(FileUpload1.PostedFile.FileName));
                        if (ext == ".jpg" || ext == ".png" || ext == ".bmp" || ext == ".jpeg" || ext == ".jpe" || ext == ".jfif" || ext == ".dib" || ext == ".gif" || ext == ".tif" || ext == ".tiff" || ext == ".ico" || ext == ".ps" || ext == ".svg" || ext == ".psd")
                        {
                            if (FileUpload1.PostedFile.ContentLength > 0)
                            {
                                if (ListBox1.Items.Contains(new ListItem(Path.GetFileName(FileUpload1.PostedFile.FileName))))
                                {
                                    Label1.ForeColor = System.Drawing.Color.Red;
                                    Label1.Text = "File already in the ListBox";
                                }
                                else
                                {
                                    Label1.ForeColor = System.Drawing.Color.Green;
                                    ListBox1.Items.Add(Path.GetFileName(FileUpload1.PostedFile.FileName));
                                    Label1.Text = "File has been added successfully";
                                    required.fs1 = FileUpload1.PostedFile.InputStream;
                                    required.br1 = new BinaryReader(required.fs1);
                                    required.bytes1 = required.br1.ReadBytes((Int32)required.fs1.Length);
                                }
                            }
                            else
                            {
                                Label1.ForeColor = System.Drawing.Color.Red;
                                Label1.Text = "File size cannot be 0";
                            }
                        }
                        else
                        {
                            Label1.ForeColor = System.Drawing.Color.Red;
                            Label1.Text = "Please select an Image format file";
                        }
                    }
                    else
                    {
                        Label1.ForeColor = System.Drawing.Color.Red;
                        Label1.Text = "Please select an Image format file";
                    }
                }
                else
                {
                    Label1.ForeColor = System.Drawing.Color.Red;
                    Label1.Text = "Only one Image file can be added";
                }
            }
            catch (Exception ex)
            {
                Label1.ForeColor = System.Drawing.Color.Red;
                Label1.Text = "Error: " + ex.Message.ToString();
            }
        }
        protected void Remove1_Click(object sender, EventArgs e)
        {
            if (ListBox1.Items.Count > 0)
            {
                if (ListBox1.SelectedIndex < 0)
                {
                    Label1.ForeColor = System.Drawing.Color.Red;
                    Label1.Text = "Please select a file to remove";
                }
                else
                {
                    Label2.ForeColor = System.Drawing.Color.Green;
                    ListBox1.Items.Remove(ListBox1.SelectedItem.Text);
                    Label1.Text = "File removed";
                }
            }
        }
        protected void Add2_Click(object sender, EventArgs e)
        {
            try
            {
                if (ListBox2.Items.Count < 2)
                {
                    if (FileUpload2.HasFile)
                    {
                        string ext = Path.GetExtension(Path.GetFileName(FileUpload2.PostedFile.FileName));
                        if (ext == ".jpg" || ext == ".png" || ext == ".bmp" || ext == ".jpeg" || ext == ".jpe" || ext == ".jfif" || ext == ".dib" || ext == ".gif" || ext == ".tif" || ext == ".tiff" || ext == ".ico" || ext == ".ps" || ext == ".svg" || ext == ".psd" || ext == ".doc" || ext == ".docx" || ext == ".ods" || ext == ".csv" || ext == ".ppt" || ext == ".pptx" || ext == ".xls" || ext == ".xlsx" || ext == ".txt" || ext == ".pdf" || ext == ".dat" || ext == ".odp" || ext == ".pps" || ext == ".rtf" || ext == ".odt" || ext == ".wks" || ext == ".wps")
                        {
                            if (FileUpload2.PostedFile.ContentLength > 0)
                            {
                                if (ListBox2.Items.Contains(new ListItem(Path.GetFileName(FileUpload2.PostedFile.FileName))))
                                {
                                    Label2.ForeColor = System.Drawing.Color.Red;
                                    Label2.Text = "File already in the ListBox";
                                }
                                else
                                {
                                    Label2.ForeColor = System.Drawing.Color.Green;
                                    ListBox2.Items.Add(Path.GetFileName(FileUpload2.PostedFile.FileName));
                                    Label2.Text = "Add another file or click Post to save them all";
                                    if (ListBox2.Items.Count == 1)
                                    {
                                        required.fs2 = FileUpload2.PostedFile.InputStream;
                                        required.br2 = new BinaryReader(required.fs2);
                                        required.bytes2 = required.br2.ReadBytes((Int32)required.fs2.Length);
                                    }
                                    if (ListBox2.Items.Count == 2)
                                    {
                                        required.fs3 = FileUpload2.PostedFile.InputStream;
                                        required.br3 = new BinaryReader(required.fs3);
                                        required.bytes3 = required.br3.ReadBytes((Int32)required.fs3.Length);
                                    }
                                }
                            }
                            else
                            {
                                Label2.ForeColor = System.Drawing.Color.Red;
                                Label2.Text = "File size cannot be 0";
                            }
                        }
                        else
                        {
                            Label2.ForeColor = System.Drawing.Color.Red;
                            Label2.Text = "File should be with following extensions .jpg, .png, .bmp, .jpeg, .jpe, .jfif, .dib, .gif, .tif, .tiff, .ico, .ps, .svg, .psd, .doc, .docx, .ods, .csv, .ppt, .pptx, .xls, .xlsx, .txt, .pdf, .dat, .odp, .pps, .rtf, .odt, .wks, .wps";
                        }
                    }
                    else
                    {
                        Label2.ForeColor = System.Drawing.Color.Red;
                        Label2.Text = "Please select a file to add";
                    }
                }
                else
                {
                    Label2.ForeColor = System.Drawing.Color.Red;
                    Label2.Text = "Only 2 files can be added";
                }
            }
            catch (Exception ex)
            {
                Label2.ForeColor = System.Drawing.Color.Red;
                Label2.Text = "Error: " + ex.Message.ToString();
            }
        }
        protected void Remove2_Click(object sender, EventArgs e)
        {
            if (ListBox2.Items.Count > 0)
            {
                if (ListBox2.SelectedIndex < 0)
                {
                    Label2.ForeColor = System.Drawing.Color.Red;
                    Label2.Text = "Please select a file to remove";
                }
                else
                {
                    Label2.ForeColor = System.Drawing.Color.Green;
                    ListBox2.Items.Remove(ListBox2.SelectedItem.Text);
                    Label2.Text = "File removed";
                }
            }
        }
        protected void Post_Click(object sender, EventArgs e)
        {
            string sport = Sport.Text;
            string title = Article_Title.Text;
            string description = Description.Text;
            string description1 = string.Empty;
            string description2 = string.Empty;
            OracleConnection conn = new OracleConnection("Data Source=MyDB;User Id=DB626;Password=infra@2017;");
            conn.Open();
            if (description.Length > 4000)
            {
                description1 = description.Substring(1, 4000);
                description2 = description.Substring(4001, description.Length);
            }
            else
            {
                description1 = description;
                description2 = string.Empty;
            }
            string sql = "INSERT INTO USER_ARTICLES VALUES (USER_ARTICLES_ID_SEQ.NEXTVAL,(SELECT ID FROM SPORTS WHERE UPPER(NAME)=UPPER('" + sport + "')),'" + title + "','" + description1 + "','" + description2 + "',:iDocument1,:iDocument2,:iImage,(SELECT USERID FROM LOGIN_PROFILE WHERE UPPER(USERNAME) = UPPER('" + Session["Username"].ToString() + "')),SYSDATE,'N',null,null)";
            OracleCommand cmd = new OracleCommand(sql, conn);
            cmd.Parameters.Add(":iDocument1", OracleDbType.Blob, required.bytes2.Length).Value = required.bytes2;
            cmd.Parameters.Add(":iDocument2", OracleDbType.Blob, required.bytes2.Length).Value = required.bytes3;
            cmd.Parameters.Add(":iImage", OracleDbType.Blob, required.bytes2.Length).Value = required.bytes1;
            cmd.ExecuteNonQuery();
            conn.Dispose();

            Response.Write("<script LANGUAGE='JavaScript' >alert('Article Posted successfully')</script>");
            Response.Redirect("HomePage.aspx");
        }
        protected void Cancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("HomePage.aspx");
        }
}
}
