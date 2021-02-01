<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FileUpload.aspx.cs" Inherits="FloraSoft.CR.FileUpload" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

&nbsp;&nbsp;&nbsp;<asp:Panel ID="Panel1" runat="server" BackColor="#669999" Font-Bold="True" 
    Font-Size="Larger" ForeColor="White" Height="36px" HorizontalAlign="Center" 
    style="margin-top: 0px">
        Relization Status Update</asp:Panel>
     <br />
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <fieldset >
<legend >Excel File Upload</legend>
    <br />
    <br />
    <asp:Label ID="Label1" runat="server" Text="File Path:"></asp:Label>
    <asp:FileUpload ID="FileUpload1" runat="server" />
    <br />
    <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Button ID="btnUpload" runat="server" onclick="btnUpload_Click" 
        Text="Upload" />
    <br />
</fieldset>
</asp:Content>
