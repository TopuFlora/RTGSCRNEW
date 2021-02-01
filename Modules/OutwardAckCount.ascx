<%@ Control Language="C#"AutoEventWireup="true" EnableViewState="false" CodeBehind="OutwardAckCount.ascx.cs" Inherits="FloraSoft.modules.OutwardAckCount" %>
<table width="100%" border="0" cellpadding="1" cellspacing="0" bgcolor="#dee9fc">
   <tr>
        <td>
            <asp:GridView ID="AckGrid" runat="server"
                Width="100%" BorderWidth="0px" GridLines="None" BackColor="#dddddd"
                AutoGenerateColumns="False"  CellPadding="3" ShowHeader="true" ShowFooter="false" 
                CellSpacing="1" AlternatingRowStyle-BackColor="#ffffff"
                RowStyle-BackColor="#dee9fc" RowStyle-CssClass="NormalSmall" 
                HeaderStyle-CssClass="GrayBackWhiteFontFixedHeader" AllowPaging="True">
               <Columns>
                   <asp:TemplateField HeaderText="OCE"  ItemStyle-Wrap="false">
                        <ItemTemplate>
                           <a href='OCEAck.aspx?AckStatus=<%#DataBinder.Eval(Container.DataItem, "AckStatus")%>'><%#DataBinder.Eval(Container.DataItem, "Files")%></a>
                        </ItemTemplate>
                   </asp:TemplateField>                  
                   <asp:BoundField  DataField = "SettlementDate"  HeaderText="Settlement"   ItemStyle-Wrap ="false" ItemStyle-HorizontalAlign="Right" />
                   <asp:BoundField  DataField = "SettlementTime"  HeaderText="Time"   ItemStyle-Wrap ="false" ItemStyle-HorizontalAlign="Right" />
                </Columns>	
           </asp:GridView>
        </td>
    </tr>
 </table>
