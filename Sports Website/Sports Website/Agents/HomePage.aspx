<%@ Page Title="HomePage" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="HomePage.aspx.cs" Inherits="Sports_Website.Agents.HomePage" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        .Buttons:hover
        {
            background-color: blue;
        }
    </style>
  <div style="background-image:url('Background_Img.jpg'); filter:alpha(opacity=.50); filter:progid:DXImageTransform.Microsoft.Alpha(opacity=0.5); background-size:100%;">
    <div style="font-size:50px; text-align:center;">
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <asp:Label ID="Time" runat="server" ></asp:Label>
                <asp:Timer ID="Timer1" runat="server" Interval="1000" OnTick="Timer1_Tick"></asp:Timer>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    <div class="row" style="text-align:center;">
        <div class="col-md-15">
            <asp:Button ID="Players" runat="server" Text="Players" Height="100px" Width="200px" OnClick="Players_Click" Font-Size="25px" BorderColor="#000000" CssClass="Buttons"/>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Tournaments" runat="server" Text="Tournaments" Height="100px" Width="200px" OnClick="Tournaments_Click" Font-Size="25px" BorderColor="#000000" CssClass="Buttons"/>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Tickets" runat="server" Text="Tickets" Height="100px" Width="200px" OnClick="Tickets_Click" Font-Size="25px" BorderColor="#000000" CssClass="Buttons"/>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Posts" runat="server" Height="100px" Width="200px" OnClick="Posts_Click" Font-Size="25px" BorderColor="#000000" CssClass="Buttons"/>
        </div>
    </div>
     <div class="row" style="margin-left:5%">
        <h2>Notifications :</h2>
    </div>
    <div class="row" style="height:100px;width:100px; margin-bottom:20%; margin-left:5%">
        <asp:TextBox ID="Notification" runat="server" Height="300px" Width="1050px" AutoPostBack="true" BackColor="lightblue" Font-Bold="true" Font-Italic="false" BorderWidth="4" Font-Size="Larger" Columns="80" TextMode="MultiLine" Wrap="true" Visible="true" ReadOnly="true"></asp:TextBox>
    </div>
    <div class="row" style="margin-left:5%">
        <h2>Articles :</h2>
    </div>
    <div class="row" style="text-align:center; margin-left:5%">
        <table style="text-align: center;">  
            <tr>  
                <td style="text-align: center;">  
                    <asp:PlaceHolder ID="DBDataPlaceHolder" runat="server"></asp:PlaceHolder>  
                </td>  
            </tr>  
        </table>
    </div>
</div>
</asp:Content>
