<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="WebApplication1.About" %>



<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <hgroup class="title">
        
        <h1>Search</h1>
    </hgroup>

    <article>
        <p>        
            &nbsp;</p>
        <p>        
            <asp:Label ID="Label5" runat="server" Text="Registration Number :    "></asp:Label>
            <asp:Label ID="Label2" runat="server"></asp:Label>
        </p>
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
             &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label1" runat="server"></asp:Label>
        </p>
    </article>

    <aside>
        <p>        
            <asp:TextBox ID="TextBox1" runat="server" Width="153px"></asp:TextBox>
        </p>
        <p>
            <asp:Button ID="Button2" runat="server" Height="34px" OnClick="Button2_Click1" Text="Search" Width="170px" />
        </p>
    </aside>
</asp:Content>