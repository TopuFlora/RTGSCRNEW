<%@ Control Language="C#" AutoEventWireup="false" EnableViewState="false" CodeBehind="AdminHeader.ascx.cs" Inherits="FloraSoft.AdminHeader" %>
<a href="Default.aspx"><img src="images/BACPSHeader.gif" border="0" width="1240" height="65"></a><br />
<script>
    function ShowPBM()
    {
    	window.open('ShowPBMFolder.aspx','PBMFiles','scrollbars=yes,width=500,height=600,left=20,top=20');
    }
</script>
<table width="1240" cellpadding="0" cellspacing="0" border="0">
    <tr>
        <td></td>
        <td width="300"></td>
        <td align="right"><asp:Label ID="WelcomeMsg" runat="server" CssClass="NormalBold"></asp:Label></td>
   </tr>
</table>