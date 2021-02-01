<%@ Control Language="C#" AutoEventWireup="true" EnableViewState="false" CodeBehind="RunCount.ascx.cs" Inherits="FloraSoft.modules.RunCount" %>
<table width="185" border="0" cellpadding="1" cellspacing="0" bgcolor="#dee9fc">
   <tr>
        <td>
            <asp:GridView ID="BranchGrid" runat="server"
                Width="100%" BorderWidth="0px" GridLines="None" BackColor="#dddddd"
                AutoGenerateColumns="False"  CellPadding="3" ShowHeader="true" ShowFooter="false" 
                CellSpacing="1" AlternatingRowStyle-BackColor="#ffffff"
                RowStyle-BackColor="#dee9fc" RowStyle-CssClass="NormalSmall" 
                HeaderStyle-CssClass="GrayBackWhiteFontFixedHeader">
               <Columns>
                   <asp:BoundField  DataField = "Env"          HeaderText=""    ItemStyle-Wrap ="false" ItemStyle-HorizontalAlign="Right" />
                   <asp:BoundField  DataField = "ClearingType" HeaderText=""    ItemStyle-Wrap ="false" ItemStyle-HorizontalAlign="Right" />
                   <asp:BoundField  DataField = "Run"          HeaderText="Run" ItemStyle-Wrap ="false" ItemStyle-HorizontalAlign="Right" />
                   <asp:BoundField  DataField = "Checks"       HeaderText="Chqs" ItemStyle-Wrap ="false" ItemStyle-HorizontalAlign="Right" />
                </Columns>	
           </asp:GridView>
        </td>
    </tr>
 </table>
