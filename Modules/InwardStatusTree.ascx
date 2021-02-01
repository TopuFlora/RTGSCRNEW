<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="InwardStatusTree.ascx.cs" Inherits="FloraSoft.InwardStatusTree" %>
<asp:TreeView ID="StatusTreeView" Runat="server" ImageSet="WindowsHelp" ShowLines="True">
     <ParentNodeStyle Font-Bold="False" />
     <HoverNodeStyle Font-Underline="True" ForeColor="#6666AA" />
     <SelectedNodeStyle BackColor="#B5B5B5" Font-Underline="False" HorizontalPadding="0px" VerticalPadding="0px" />
     <NodeStyle Font-Names="Tahoma" Font-Size="8pt" ForeColor="Black" HorizontalPadding="5px" NodeSpacing="0px" VerticalPadding="1px" />
     <RootNodeStyle Font-Bold="True" />
    <DataBindings>
         <asp:TreeNodeBinding DataMember="ReturnReason" TextField="ReturnReason" NavigateUrlField="ReturnCD" />
     </DataBindings>
 </asp:TreeView>