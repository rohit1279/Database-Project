<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Sports_Website._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>Sports Aggregator</h1>
        <p class="lead">Browse IT...., We have IT....</p>
        <p><a href="http://www.asp.net" class="btn btn-primary btn-lg">Learn more &raquo;</a></p>
    </div>

    <div class="row">
        <div class="col-md-4">
            <h2>Cricket</h2>
            <asp:ImageButton ID="ImageButton1" runat="server" Height="300px" Width="300px" ImageAlign="Left" ImageUrl="Cricket.jpg" OnMouseOver="this.src='Cricket1.gif'" OnMouseout="this.src='Cricket.jpg'" OnClick="ImageButton1_Click"/>
        </div>
        <div class="col-md-4">
            <h2>Football</h2>
            <asp:ImageButton ID="ImageButton2" runat="server" Height="300px" Width="300px" ImageAlign="Left" ImageUrl="Football2.jpg" OnMouseOver="this.src='Football4.gif'" OnMouseout="this.src='Football2.jpg'" OnClick="ImageButton2_Click"/>
        </div>
        <div class="col-md-4">
            <h2>BasketBall</h2>
            <asp:ImageButton ID="ImageButton3" runat="server" Height="300px" Width="300px" ImageAlign="Left" ImageUrl="Basketball.jpg" OnClick="ImageButton3_Click"/>
        </div>
    </div>

    <div class="row">
        <div class="col-md-4">
            <h2>Tennis</h2>
            <asp:ImageButton ID="ImageButton4" runat="server" Height="300px" Width="300px" ImageAlign="Left" ImageUrl="Tennis2.jpg" OnClick="ImageButton4_Click"/>
        </div>
        <div class="col-md-4">
            <h2>Baseball</h2>
            <asp:ImageButton ID="ImageButton5" runat="server" Height="300px" Width="300px" ImageAlign="Left" ImageUrl="Baseball.jpg" OnClick="ImageButton5_Click"/>
        </div>
        <div class="col-md-4">
            <h2>Hockey</h2>
            <asp:ImageButton ID="ImageButton6" runat="server" Height="300px" Width="300px" ImageAlign="Left" ImageUrl="Hockey.jpg" OnClick="ImageButton6_Click"/>
        </div>
    </div>

    <div class="row">
        <div class="col-md-4">
            <h2>Badminton</h2>
            <asp:ImageButton ID="ImageButton7" runat="server" Height="300px" Width="300px" ImageAlign="Left" ImageUrl="Badminton.jpg" OnClick="ImageButton7_Click"/>
        </div>
        <div class="col-md-4">
            <h2>VolleyBall</h2>
            <asp:ImageButton ID="ImageButton8" runat="server" Height="300px" Width="300px" ImageAlign="Left" ImageUrl="Volleyball2.jpg" OnClick="ImageButton8_Click"/>
        </div>
        <div class="col-md-4">
            <h2>Golf</h2>
            <asp:ImageButton ID="ImageButton9" runat="server" Height="300px" Width="300px" ImageAlign="Left" ImageUrl="golf.jpg" OnClick="ImageButton9_Click"/>
        </div>
    </div>

</asp:Content>
