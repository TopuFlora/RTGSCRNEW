<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AdminReportViewer.ascx.cs" Inherits="FloraSoft.AdminReportViewer" %>
<a href="Default.aspx"><img src="images/BACPSHeader.gif" border="0" width="1070" height="65"></a><br />
<script>
    function ShowPBM()
    {
    	window.open('ShowPBMFolder.aspx','PBMFiles','scrollbars=yes,width=500,height=600,left=20,top=20');
    }
</script>
<table width="1000" cellpadding="0" cellspacing="0" border="0">
    <tr>
        <td width="300"></td>
        <td></td>
        <td align="right"><asp:Label ID="WelcomeMsg" runat="server" CssClass="NormalBold"></asp:Label></td>
   </tr>
</table>



