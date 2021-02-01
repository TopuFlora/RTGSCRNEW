<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SelectRole.aspx.cs" Inherits="FloraSoft.SelectUserRole" %>

<%@ Register Src="Modules/CommonHeader.ascx" TagName="CommonHeader" TagPrefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Select Role</title>
    <link href="Includes/sitec.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <img src="images/BACPSHeader.gif" border="0" width="1240" height="65">
        <table align=center>
            <tr>
                <td style="width: 126px">
                </td>
                <td style="width: 148px">
                </td>
                <td style="width: 100px">
                </td>
            </tr>
            <tr>
                <td class="Normal">
                    Please Select:</td>
                <td style="width: 148px">
                    <asp:DropDownList ID="ddluserrole" runat="server" Width="146px" DataTextField="RoleName" DataValueField="RoleCD"></asp:DropDownList></td>
                <td style="width: 100px">
                </td>
            </tr>
            <tr>
                <td style="width: 126px; height: 21px;">
                </td>
                <td style="width: 148px; height: 21px;" align="Right">
                    <asp:LinkButton ID="LoginBtn" runat="server" CssClass="CommandButton" OnClick="Login_Click"
                        Text="Proceed" Width="80"></asp:LinkButton></td>
                <td style="width: 100px; height: 21px;">
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
