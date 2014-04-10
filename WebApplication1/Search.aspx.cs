using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class About : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {


            
        }

        
        protected void Button2_Click1(object sender, EventArgs e)
        {
            string abc = TextBox1.Text;
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
            SqlCommand cmd = new SqlCommand("Select * from [dbo].[table4] where RegNo = '"+abc+"'", con);
            con.Open();
            SqlDataReader dr = null;
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                     Label2.Text = (dr["RegNo"].ToString());
                    Label7.Text = (dr["class"].ToString());
                    Label8.Text = (dr["company"].ToString());
                    Label3.Text = (dr["address"].ToString());
                    try
                    {
                        byte[] img = (byte[])dr["logo"];
                        string base64string = Convert.ToBase64String(img, 0, img.Length);

                        if (base64string != null)
                        {
                            
                            Label1.Text = "<img src='data:image/png;base64," + base64string + "' alt='" + (dr["company"].ToString()) +"' width='200px' vspace='5px' hspace='5px' />";
                        }
                        else
                        {
                            
                                Label1.Text = "<font size = '24'><b><u>" + (dr["logotext"].ToString()) + "</u></b></font>";
                            
                        }
                    }
                    catch 
                        {
                            Label1.Text = "<font size = '24'><b><u>" + (dr["logotext"].ToString()) + "</u></b></font>";
                        }
               }
            }
            con.Close();
        }
    }
}