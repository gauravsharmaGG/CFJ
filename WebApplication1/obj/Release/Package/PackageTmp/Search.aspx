<%@ Page Title="Search" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Search.aspx.cs" Inherits="WebApplication1.About" %>

<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <hgroup class="title">
        <h1>Search :</h1>
    </hgroup>

    <article>
        <p>        
            &nbsp;</p>
        <p>        
            <hr />
            <asp:Label ID="Label5" runat="server" Text="Registration Number :    "></asp:Label>
            <asp:Label ID="Label2" runat="server"></asp:Label>
        &nbsp;</p>
        <p>        
            Class :
            <asp:Label ID="Label7" runat="server"></asp:Label>
        </p>
        <p>        
            Company Name :<asp:Label ID="Label8" runat="server"></asp:Label>
        </p>
        <p style="width: 621px">        
            Address :
            <asp:Label ID="Label3" runat="server"></asp:Label>
            </p><p>
           <center>
            <asp:Label ID="Label1" runat="server"></asp:Label>
        </p></center>
        <hr />
    </article>

    <aside>
        <p>        
            <asp:TextBox ID="TextBox1" runat="server" Width="153px"></asp:TextBox>
        </p>
        <p>
            <asp:Button ID="Button2" runat="server" Height="37px" OnClick="Button2_Click1" Text="Search" Width="161px" BackColor="#333333" BorderColor="Red" BorderStyle="Double" ForeColor="White" />
        </p>
        <p>
            &nbsp;</p>
    </aside>
</asp:Content>