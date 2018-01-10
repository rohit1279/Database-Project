<%@ Page Title="Posts Article" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PostsPage.aspx.cs" Inherits="Sports_Website.Agents.PostsPage" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        .Buttons:hover
        {
            background-color: blue;
        }
        .PostButton
        {
            color: black;
            background-color: blue;
        }
    </style>
<%--  <div style="background-image:url('Background_Img.jpg'); filter:alpha(opacity=.90); filter:progid:DXImageTransform.Microsoft.Alpha(opacity=0.5); background-size:100%;">--%>
    <div>
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
            <asp:Button ID="Posts" runat="server" Text="Posts" Height="100px" Width="200px" Font-Size="25px" BorderColor="#000000" Enabled="false" CssClass="PostButton"/>
        </div>
    </div>
    <div class="row" style="text-align:center; margin-top:5%">
          <asp:Button ID="Validate" runat="server" Height="100px" Width="200px" Font-Size="23px" BorderColor="#000000" CssClass="PostButton"/>
          &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
          <asp:Button ID="Add" runat="server" Text="Add Posts" Height="100px" Width="200px" Font-Size="25px" BorderColor="#000000" CssClass="Buttons" />
    </div>
    <div class="row" style="text-align:center; margin-top:5%; margin-left:5%">
        <%--<asp:Table ID="Table1" runat="server">
            <asp:TableRow>
                <asp:TableCell RowSpan="3">
                    <asp:Image ID="Image1" runat="server" Height="150px" Width="150px" Visible = "true"/>
                </asp:TableCell>
                <asp:TableCell HorizontalAlign="Left">
                    <span style="font-weight:bold">Title: </span>
                    <asp:HyperLink ID="Article_Title" runat="server" Font-Size="Larger"></asp:HyperLink>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>            
                <asp:TableCell ID="Description" HorizontalAlign="Left"><span style="font-weight:bold">Description: </span></asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                 <asp:TableCell>
                     <div style='float: left; text-align: left'><span style="font-weight:bold">Posted_by: </span>
                         <asp:Label ID="Posted_by" runat="server"></asp:Label>
                     </div>
                     <div style='float: right; text-align: right'>
                         <asp:HyperLink ID="Document1" runat="server" Font-Size="Larger">Document 1</asp:HyperLink>
                         &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                         <asp:HyperLink ID="Document2" runat="server" Font-Size="Larger">Document 2</asp:HyperLink>
                         &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                         <asp:Button ID="Publish" runat="server" Text="Publish"  BackColor="#0066ff"/>
                         &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                         <asp:Button ID="Delete" runat="server" Text="Delete" />
                     </div>
                 </asp:TableCell>
            </asp:TableRow>
        </asp:Table>--%>
        <%--<asp:Table ID="Table1" runat="server">
            <asp:TableRow>
                <asp:TableCell>
                    <asp:PlaceHolder ID="DBDataPlaceHolder" runat="server"></asp:PlaceHolder>
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>--%>
        <table style="text-align: center;">  
            <tr>  
                <td style="text-align: center;">  
                    <asp:PlaceHolder ID="DBDataPlaceHolder" runat="server"></asp:PlaceHolder>  
                </td>  
            </tr>  
        </table>  
       <%-- <table style="text-align: center;">  
            <tr>  
                <td rowspan="3">  
                     <img src="Sports1.jpg" Height="150" Width="150" Visible = "true" />
                </td> 
                <td style="text-align:left">
                    <span style="font-weight:bold">Title: </span>
                     <a href="http://www.yahoo.com">Rohith</a>
                </td> 
            </tr>  
            <tr>
                <td style="text-align:left">
                    <span style="font-weight:bold">Description: </span>
                    <p>The highest run scorer of all time in International cricket, Tendulkar took up cricket at the age of eleven, made his Test debut on 15 November 1989 against Pakistan in Karachi at the age of sixteen, and went on to represent Mumbai domestically and India internationally for close to twenty-four years. He is the only player to have scored one hundred international centuries, the first batsman to score a double century in a One Day International, the holder of the record for the most number of runs in both ODI and Test cricket, and the only player to complete more than 30,000 runs in international cricket. </p>
                </td>
            </tr>
            <tr>
                <td>
                    <div style='float: left; text-align: left'>
                        <span style="font-weight:bold">Posted_by: </span>
                         <span>Rohith Movva</span>
                     </div>
                    <div style='float: right; text-align: right'>
                        <a href="http://www.yahoo.com">Document 1</a>
                         &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                         <a href="http://www.yahoo.com">Document 2</a>
                         &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                         <button type="button">Publish</button>
                         &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                         <button type="button">Cancel</button>
                     </div>
                </td>
            </tr>
        </table> --%> 
    </div>
        <div class="row" style="margin-right:5%; text-align:center">
          <asp:Button ID="Save_Button" runat="server" Text="Save" Width="98px" BackColor="#0066ff" OnClick="Save_Click" />
          &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
          <asp:Button ID="Cancel_Button" runat="server" Text="Cancel" Width="98px" CausesValidation="false" OnClick="Cancel_Click"/>
      </div>
</div>
</asp:Content>