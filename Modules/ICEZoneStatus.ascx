<%@ Control Language="C#" AutoEventWireup="true" EnableViewState="false" CodeBehind="ICEZoneStatus.ascx.cs" Inherits="FloraSoft.modules.ICEZoneStatus" %>
    <table border="0" cellpadding="2" cellspacing="0" width="100%">
    <tr>
          <td>
            <asp:GridView ID="BranchGrid" runat="server"  Width="250px" BorderWidth="0px" GridLines="None"
                    AutoGenerateColumns="False"  CellPadding="2" ShowFooter="true" 
                    CellSpacing="1" AlternatingRowStyle-BackColor="#ffffff" 
                    FooterStyle-CssClass="GrayBackWhiteFont"
                    RowStyle-BackColor="#dee9fc" RowStyle-CssClass="Normal" 
                    HeaderStyle-CssClass="GrayBackWhiteFont">
               <Columns>
                   <asp:BoundField  DataField = "BranchName" HeaderText="Branch"   ItemStyle-Width = "140px"   ItemStyle-Wrap ="false" ItemStyle-HorizontalAlign="Left" />
                   <asp:BoundField  DataField = "Maker"      HeaderText="Maker"    ItemStyle-Width = "50px"   ItemStyle-Wrap ="false" ItemStyle-HorizontalAlign="Left" />
                   <asp:BoundField  DataField = "Checker"    HeaderText="Checker"  ItemStyle-Width = "50px"   ItemStyle-Wrap ="false" ItemStyle-HorizontalAlign="Left" />
                </Columns>	
           </asp:GridView>
        </td>
    </tr>
</table>
