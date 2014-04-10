using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;
using System.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using Dotnet = System.Drawing.Image;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing.Imaging;
using System.Text.RegularExpressions;
using System.Drawing;
using System.Data.SqlClient;
using System.Configuration;

namespace WebApplication1
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            if (FileUpload1.HasFile)
            {
                try
                {
                    sb.AppendFormat(" Uploading file: {0}",
                                                FileUpload1.FileName);
                    //saving the file
                    FileUpload1.SaveAs(Server.MapPath("\\uploads\\" + FileUpload1.FileName));
                    //Showing the file information
                    sb.AppendFormat("<br/> Save As: {0}",
                                       FileUpload1.PostedFile.FileName);
                    sb.AppendFormat("<br/> File type: {0}",
                                       FileUpload1.PostedFile.ContentType);
                    sb.AppendFormat("<br/> File length: {0}",
                                       FileUpload1.PostedFile.ContentLength);
                    sb.AppendFormat("<br/> File name: {0}",
                                       FileUpload1.PostedFile.FileName);
                }
                catch (Exception ex)
                {
                    sb.Append("<br/> Error <br/>");
                    sb.AppendFormat("Unable to save file <br/> {0}",
                                       ex.Message);
                }
            }
            else
            {
                
            }

            Label1.Text = "Uploaded Successfully";

            StringBuilder text = new StringBuilder();

            if (FileUpload1.HasFile)

            {
                PdfReader pdfReader = new PdfReader(Server.MapPath("\\uploads\\" +FileUpload1.FileName));

                for (int page = 1; page <= pdfReader.NumberOfPages; page++)
                {
                    ITextExtractionStrategy strategy = new SimpleTextExtractionStrategy();
                    string currentText = PdfTextExtractor.GetTextFromPage(pdfReader, page, strategy);

                    currentText = Encoding.UTF8.GetString(ASCIIEncoding.Convert(Encoding.Default, Encoding.UTF8, Encoding.Default.GetBytes(currentText)));
                    string data = getBetween(currentText.ToString(), "Proviso ", " ");

                   
                    string abc = Regex.Replace(data, @"\s+", " ");

                    int reg = Int32.Parse(abc);
                    string company = getBetween(currentText.ToString(), "as ", " \n");
                    string classs = getBetween(currentText.ToString(), "Class ", " \n");
                    int cl = Int32.Parse(classs);
                    string com = Regex.Replace(company, @"\s+", " ");
                    string logotext = getBetween(currentText.ToString(), "Class " + classs, "Advertised");
                    if (com=="")
                    {

                        company = GetLine(currentText.ToString(), 5, reg, "company");
                        //company = getBetween(currentText.ToString(), "2013 \n"  , " \n");
                        
                    }
                    string address = getBetween(currentText.ToString(), company + " \n", " \n");
                    if (address == "")
                    {

                        address = GetLine(currentText.ToString(), 6, reg, "address");
                        //company = getBetween(currentText.ToString(), "2013 \n"  , " \n");

                    }

                    try
                    {
                        SqlConnection con = new SqlConnection();
                        con.ConnectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
                        con.Open();

                        SqlCommand cmd = new SqlCommand("INSERT INTO [dbo].[Table4] ( [RegNo], [class], [company], [address], [logotext]) VALUES (N'" + reg + "', N'" + cl + "', N'" + company + "', N'" + address + "', N'" + logotext + "')", con);

                        cmd.ExecuteNonQuery();



















                        //
                        string testFile = Server.MapPath("\\uploads\\" + FileUpload1.FileName);
                        //       string outputPath = "h:\\root\\home\\goksgreat-001\\www\\";
                        int pageNum = page;
                        {

                            PdfReader pdf = new PdfReader(testFile);
                            PdfDictionary pg = pdf.GetPageN(pageNum);
                            PdfDictionary res = (PdfDictionary)PdfReader.GetPdfObject(pg.Get(PdfName.RESOURCES));
                            PdfDictionary xobj = (PdfDictionary)PdfReader.GetPdfObject(res.Get(PdfName.XOBJECT));
                            if (xobj == null) { return; }
                            foreach (PdfName name in xobj.Keys)
                            {
                                PdfObject obj = xobj.Get(name);
                                if (!obj.IsIndirect()) { continue; }
                                PdfDictionary tg = (PdfDictionary)PdfReader.GetPdfObject(obj);
                                PdfName type = (PdfName)PdfReader.GetPdfObject(tg.Get(PdfName.SUBTYPE));
                                if (!type.Equals(PdfName.IMAGE)) { continue; }
                                int XrefIndex = Convert.ToInt32(((PRIndirectReference)obj).Number.ToString(System.Globalization.CultureInfo.InvariantCulture));
                                PdfObject pdfObj = pdf.GetPdfObject(XrefIndex);
                                PdfStream pdfStrem = (PdfStream)pdfObj;
                                byte[] bytes = PdfReader.GetStreamBytesRaw((PRStream)pdfStrem);
                                if (bytes == null) { break; }

                                // hi plz update krdo
                                SqlCommand cmda = new SqlCommand("UPDATE [dbo].[Table4] SET logo = @Image where RegNo = '" + reg + "'", con);
                                cmda.Parameters.AddWithValue("@Image", bytes);
                                cmda.ExecuteNonQuery();
                                con.Close();



                            }
                        }//


                    }
                    catch
                    {

                    }
                    

                }
                pdfReader.Close();
            }
            else
            {
                
            }
           


            



























            //
            //
            



















        }
















        string GetLine(string text, int lineNo, int reg, string type)
        {
            string[] lines = text.Replace("\r", "").Split('\n');
            
            for (int i = 1; i <= lines.Length-2;i++)
            {
                if (lines[i].Contains(reg.ToString()))
                {
                    lineNo = i+2;
                }
            }
            if (type == "company")
            {
                return lines.Length >= lineNo ? lines[lineNo - 1] : null;
            }
            else
            {
                return lines.Length >= lineNo ? lines[lineNo] : null;
            }
        }







        private static string getBetween(string strSource, string strStart, string strEnd)
        {
            int Start, End;
            if (strSource.Contains(strStart) && strSource.Contains(strEnd))
            {
                Start = strSource.IndexOf(strStart, 0) + strStart.Length;
                End = strSource.IndexOf(strEnd, Start);
                return strSource.Substring(Start, End - Start);
            }
            else
            {
                return "";
            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
            con.Open();
            SqlCommand cmd = new SqlCommand("delete from [dbo].[Table4] where class<20", con);
            cmd.ExecuteNonQuery();
            con.Close();
            Label1.Text = "Deleted Successfully";
        }


    }
    
}