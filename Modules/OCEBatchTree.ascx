<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="OCEBatchTree.ascx.cs" Inherits="FloraSoft.OCEBatchTree" %>
<table>
    <tr>
        <td width="20"></td>
        <td><asp:DropDownList ID="ZoneList" runat="server" DataTextField="Zone" DataValueField="ZoneID" OnSelectedIndexChanged="ZoneList_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList></td>
        <td><asp:DropDownList ID="BranchList" runat="server" DataTextField="BranchName" DataValueField="RoutingNo" AutoPostBack="true"></asp:DropDownList></td>
        <td><asp:DropDownList ID="ClearingTypeList" runat="server" AutoPostBack="True">
            <asp:ListItem Text="RV" Value="1"></asp:ListItem>
            <asp:ListItem Text="HV" Value="9"></asp:ListItem>
        </asp:DropDownList></td>
   </tr>
</table>
<asp:TreeView ID="StatusTreeView1" runat="server" ShowLines="True" ImageSet="Inbox">
    <DataBindings>
        <asp:TreeNodeBinding DataMember="batch" TextField="batchname" NavigateUrlField="NavURL" />
    </DataBindings>
    <ParentNodeStyle Font-Bold="False" ForeColor="DarkGreen"  />
    <HoverNodeStyle Font-Underline="True" />
    <SelectedNodeStyle Font-Underline="True" HorizontalPadding="0px" VerticalPadding="0px" />
    <NodeStyle Font-Names="Verdana" Font-Size="8pt" ForeColor="#666666" HorizontalPadding="5px"
        NodeSpacing="0px" VerticalPadding="0px" />
</asp:TreeView>
