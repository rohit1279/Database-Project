<%@ Page Title="Posts Article" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PostsPage.aspx.cs" Inherits="Sports_Website.Users.PostsPage" %>

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
            <asp:Button ID="Players" runat="server" Text="Players" Height="100px" Width="200px" OnClick="Players_Click" Font-Size="25px" BorderColor="#000000" CssClass="Buttons" CausesValidation="false"/>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Tournaments" runat="server" Text="Tournaments" Height="100px" Width="200px" OnClick="Tournaments_Click" Font-Size="25px" BorderColor="#000000" CssClass="Buttons" CausesValidation="false"/>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Tickets" runat="server" Text="Tickets" Height="100px" Width="200px" OnClick="Tickets_Click" Font-Size="25px" BorderColor="#000000" CssClass="Buttons" CausesValidation="false"/>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Posts" runat="server" Text="Posts" Height="100px" Width="200px" Font-Size="25px" BorderColor="#000000" Enabled="false" CssClass="PostButton"/>
        </div>
    </div>
    <div class="row" style="margin-top:5%; margin-left:5%">
        <asp:Label runat="server" AssociatedControlID="Sport"  Font-Bold="true" Font-Size="XX-Large">Sport <span class="smallred" style="color:red;">*</span> : </asp:Label>
            <%--<div class="col-md-2">--%>
                <asp:DropDownList ID="Sport" runat="server" Font-Size="Large"><asp:ListItem Value="">--Select a sport--</asp:ListItem></asp:DropDownList>
                 <asp:RequiredFieldValidator runat="server" ControlToValidate="Sport"
                    CssClass="text-danger" ErrorMessage="The Sport field is required." />
            <%--</div> --%>
    </div>
    <div class="row" style="margin-left:5%">
            <asp:Label runat="server" AssociatedControlID="Article_Title" Font-Size="XX-Large">Title of Article <span class="smallred" style="color:red;">*</span>: </asp:Label>   
        <asp:TextBox runat="server" ID="Article_Title" width="1000px" TextMode="SingleLine" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="Article_Title"
                    CssClass="text-danger" ErrorMessage="The Title field is required." />
     </div>
    <div class="row" style="margin-left:5%">
        <asp:Label runat="server" AssociatedControlID="Description" Font-Size="XX-Large">Description <span class="smallred" style="color:red;">*</span>: </asp:Label>
       <asp:TextBox ID="Description" runat="server" Height="300px" Width="1050px" AutoPostBack="true" BackColor="lightblue" Font-Bold="true" Font-Italic="false" BorderWidth="4" Font-Size="Larger" Columns="80" TextMode="MultiLine" Wrap="true" Visible="true"></asp:TextBox>
        <asp:RequiredFieldValidator runat="server" ControlToValidate="Description"
                    CssClass="text-danger" ErrorMessage="The Description field is required." />
    </div>  
    <div class="row" style="margin-left:5%">  
        <asp:Label runat="server" ID="Image" Font-Size="XX-Large">Upload an Image: </asp:Label> 
        <asp:FileUpload ID="FileUpload1" runat="server" ToolTip="Select an image File" />
        <p>
            <asp:ListBox ID="ListBox1" runat="server" Rows="1" SelectionMode="Single" Width="221px" BackColor="#CCCCFF">
            </asp:ListBox>
            <asp:Label ID="Label1" runat="server"></asp:Label>
        </p>
        <p>
            <asp:Button ID="Button5" runat="server" Text="Add" Width="75px" OnClick="Add1_Click" />
            <asp:Button ID="Button6" runat="server" Text="Remove" Width="98px" OnClick="Remove1_Click" />
        </p>
     </div>
    <div class="row" style="margin-left:5%">   
        <asp:Label runat="server" ID="Documents" Font-Size="XX-Large">Upload Documents: </asp:Label>  
        <asp:FileUpload ID="FileUpload2" runat="server" ToolTip="Select Files" multiple="multiple"/> 
        <p>
            <asp:ListBox ID="ListBox2" runat="server" Rows="2" SelectionMode="Multiple" Width="221px" BackColor="#CCCCFF">
            </asp:ListBox>
            <asp:Label ID="Label2" runat="server"></asp:Label>
        </p>
        <p>
            <asp:Button ID="Button3" runat="server" Text="Add" Width="75px" OnClick="Add2_Click" />
            <asp:Button ID="Button4" runat="server" Text="Remove" Width="98px" OnClick="Remove2_Click" />
        </p>
                    <%--<asp:Button ID="Button1" runat="server" Text="Upload" onclick="Button1_Click"/> 
                    <asp:Button ID="Button2" runat="server" Text="View Files"  />   
        <table>  
            <tr>  
                <td>  
                    <p>  
                        <asp:Label ID="Label3" runat="server" Text="label"></asp:Label>  
                    </p>  
                </td>  
            </tr>  
        </table>  --%>
        <%--<asp:GridView ID="GridView1" runat="server" Caption="Files " CaptionAlign="Top" HorizontalAlign="Justify" DataKeyNames="id"  ToolTip="Excel FIle DownLoad Tool" CellPadding="4" ForeColor="#333333" GridLines="None">  
            <RowStyle BackColor="#E3EAEB" />  
            <Columns>  
                <asp:CommandField ShowSelectButton="True" SelectText="Download" ControlStyle-ForeColor="Blue" /> </Columns>  
            <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />  
            <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />  
            <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />  
            <HeaderStyle BackColor="Gray" Font-Bold="True" ForeColor="White" />  
            <EditRowStyle BackColor="#7C6F57" />  
            <AlternatingRowStyle BackColor="White" /> </asp:GridView>  --%>
    </div> 
      <div class="row" style="margin-right:5%; text-align:center">
          <asp:Button ID="Post_Button" runat="server" Text="Post" Width="98px" BackColor="#0066ff" OnClick="Post_Click" />
          &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
          <asp:Button ID="Cancel_Button" runat="server" Text="Cancel" Width="98px" CausesValidation="false" OnClick="Cancel_Click"/>
      </div>
</div>
</asp:Content>
