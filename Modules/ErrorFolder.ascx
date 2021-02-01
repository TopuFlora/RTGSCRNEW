<%@ Control Language="C#" AutoEventWireup="true" EnableViewState="false" CodeBehind="ErrorFolder.ascx.cs" Inherits="FloraSoft.ErrorFolder" %>
 <table width="180px" class="GrayBackWhiteFont" cellpadding="3" cellspacing="1">
    <tr>
        <td width="10%"class="NormalBold" align="center"></td>
        <td width="90%" class="NormalBold" align="center">PBM Error Files</td>
   </tr>
</table>
<DIV id="ErrorTreeDiv" runat="server" style="position:relative;background-color:white;OVERFLOW: auto;WIDTH: 100%;TEXT-ALIGN: left">
<asp:TreeView ID="ErrorTreeView" Runat="server" ImageSet="XPFileExplorer" NodeIndent="15" CssClass="NormalSmall" ShowLines="True" >
    <DataBindings>
        <asp:TreeNodeBinding DataMember="AiDPS"  Text="AiDPS" Value="AiDPS"/>
        <asp:TreeNodeBinding DataMember="Folder" TextField="Path" />
        <asp:TreeNodeBinding DataMember="Folder" TextField="Count" />
    </DataBindings>
    <LeafNodeStyle ImageUrl="~/Images/Folder.gif" />
</asp:TreeView>
</DIV>