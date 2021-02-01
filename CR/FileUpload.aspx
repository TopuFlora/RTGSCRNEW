<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FileUpload.aspx.cs" MasterPageFile="~/CR/Site.Master"  Inherits="FloraSoft.CR.FileUpload" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

   <fieldset >
<legend > File Upload</legend>
    <br />
    <br />
    <asp:Label ID="Label1" runat="server" Text="File Path:"></asp:Label>
    <asp:FileUpload ID="FileUpload1" runat="server" />
    <br />
    <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Button ID="btnUpload" runat="server" OnClick="btnUpload_Click"
        Text="Upload" />
        <br />
    </fieldset>

    <div style="width: 100%; overflow-x: auto">
        <asp:GridView ID="UploadList" HeaderStyle-Wrap="false" RowStyle-Wrap="false" CssClass="table  table-bordered table-striped table-hover" runat="server"
            AutoGenerateColumns="true">
        </asp:GridView>
    </div>
</asp:Content>
