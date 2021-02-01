<%@ Control Language="C#" AutoEventWireup="true" EnableViewState="false" CodeBehind="BranchApproval.ascx.cs" Inherits="FloraSoft.modules.BranchApproval" %>
<table border="0" cellpadding="1" cellspacing="0" bgcolor="#dee9fc">
   <tr>
        <td>
               <asp:DataGrid ID="SettlementGrid" runat="server"  
                    AlternatingItemStyle-BackColor="lightyellow"
                    AutoGenerateColumns="false" BorderWidth="0px" 
                    CellPadding="6" CellSpacing="1" Width="770px"
                    FooterStyle-CssClass="GrayBackWhiteFont" GridLines="None"
                    HeaderStyle-CssClass="GrayBackWhiteFont" Height="0px" 
                    ItemStyle-BackColor="White"
                    ItemStyle-CssClass="NormalSmall" FooterStyle-HorizontalAlign="Right"  
                    ShowFooter="true">
                   <Columns>
                       <asp:BoundColumn  DataField = "Name"   HeaderText="Name"      ItemStyle-Width = "150px"   ItemStyle-Wrap ="false" HeaderStyle-HorizontalAlign="Center"  />
                       <asp:BoundColumn  DataField = "iOCE"   HeaderText=""          ItemStyle-Width = "50px"   ItemStyle-Wrap ="false" HeaderStyle-HorizontalAlign="Center"  ItemStyle-HorizontalAlign="Right" />
                       <asp:BoundColumn  DataField = "OCE"    HeaderText="OCE"       ItemStyle-Width = "100px"   ItemStyle-Wrap ="false" HeaderStyle-HorizontalAlign="Center"  ItemStyle-HorizontalAlign="Right" />
                       <asp:BoundColumn  DataField = "iICE"   HeaderText=""          ItemStyle-Width = "50px"   ItemStyle-Wrap ="false" HeaderStyle-HorizontalAlign="Center"  ItemStyle-HorizontalAlign="Right" />
                       <asp:BoundColumn  DataField = "ICE"    HeaderText="ICE"       ItemStyle-Width = "100px"   ItemStyle-Wrap ="false" HeaderStyle-HorizontalAlign="Center"  ItemStyle-HorizontalAlign="Right" />
                       <asp:BoundColumn  DataField = "iORE"   HeaderText=""          ItemStyle-Width = "50px"   ItemStyle-Wrap ="false" HeaderStyle-HorizontalAlign="Center"  ItemStyle-HorizontalAlign="Right" />
                       <asp:BoundColumn  DataField = "ORE"    HeaderText="ORE"       ItemStyle-Width = "100px"   ItemStyle-Wrap ="false" HeaderStyle-HorizontalAlign="Center"  ItemStyle-HorizontalAlign="Right" />
                       <asp:BoundColumn  DataField = "iIRE"   HeaderText=""          ItemStyle-Width = "50px"   ItemStyle-Wrap ="false" HeaderStyle-HorizontalAlign="Center"  ItemStyle-HorizontalAlign="Right" />
                       <asp:BoundColumn  DataField = "IRE"    HeaderText="IRE"       ItemStyle-Width = "100px"   ItemStyle-Wrap ="false" HeaderStyle-HorizontalAlign="Center"  ItemStyle-HorizontalAlign="Right" />
                       <asp:BoundColumn  DataField = "OCEApr" HeaderText="OCEApr"    ItemStyle-Width = "100px"   ItemStyle-Wrap ="false" HeaderStyle-HorizontalAlign="Center"  ItemStyle-HorizontalAlign="Right" />
                       <asp:BoundColumn  DataField = "ICEApr" HeaderText="ICEApr"    ItemStyle-Width = "100px"   ItemStyle-Wrap ="false" HeaderStyle-HorizontalAlign="Center"  ItemStyle-HorizontalAlign="Right" />
                       <asp:BoundColumn  DataField = "Net"    HeaderText="Net"       ItemStyle-Width = "100px"   ItemStyle-Wrap ="false" HeaderStyle-HorizontalAlign="Center"  ItemStyle-HorizontalAlign="Right" />
                   </Columns>
                 </asp:DataGrid>
        </td>
    </tr>
/table>
