<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApplication1._Default" %>

<asp:Content runat="server" ID="FeaturedContent" ContentPlaceHolderID="FeaturedContent">
    <section class="featured">
        <div class="content-wrapper">
            <hgroup class="title">
                <center>
                <h1>Code for Job - PDF Extract</h1>
                    </center>
            </hgroup>
            <p>
                <center>
                <asp:Label ID="Label1" runat="server" ForeColor="#FF6600"></asp:Label>
                    </center>
            </p>
        </div>
    </section>
</asp:Content>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
       
        <div>
            <center> 
            <h3>File Upload:</h3>
            <asp:FileUpload ID="FileUpload1" runat="server" />
            <br />
            <br />
            <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Upload" BackColor="#333333" BorderColor="Red" BorderStyle="Double" ForeColor="White" />
            <br />
                <br />
                <hr />
                Since Reg. No. has to be marked as primary key (as in instructions on site) kindly delete the old data for uniqueness checking
              <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="Delete Already uploaded database" BackColor="#333333" BorderColor="Red" BorderStyle="Double" ForeColor="White" />
            <br />
            <br />
                </center>
            
        </div>
</asp:Content>
 