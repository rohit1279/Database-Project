using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using Oracle.DataAccess.Client; // ODP.NET Oracle managed provider
using Oracle.DataAccess.Types;

namespace Sports_Website.Users
{
    /// <summary>
    /// Summary description for Images
    /// </summary>
    public class Images : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            Int32 id = Convert.ToInt32(context.Request.QueryString["id"]);
            context.Response.ContentType = "image/jpeg";
            Stream strm = ShowImg(id);
            byte[] buffer = new byte[4096];
            int byteSeq = strm.Read(buffer, 0, 4096);

       while (byteSeq > 0)
       {
           context.Response.OutputStream.Write(buffer, 0, byteSeq);
           byteSeq = strm.Read(buffer, 0, 4096);
       }       
       context.Response.BinaryWrite(buffer);
    }

        public Stream ShowImg(int id)
    {
         OracleConnection conn = new OracleConnection("Data Source=MyDB;User Id=DB626;Password=infra@2017;");
            conn.Open();
         string sql = "SELECT PICTURE FROM PICTURES WHERE ID = " + id;
         OracleCommand cmd = new OracleCommand(sql,conn);
         object img = cmd.ExecuteScalar();
         try
        {
            return new MemoryStream((byte[])img);
        }
        catch
        {
            return null;
        }
        finally
       {
            conn.Close();
       }
    }
        public bool IsReusable
    {
        get
        {
             return false;
        }
    }
   }
}