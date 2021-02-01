<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ICEQueueList.ascx.cs" Inherits="FloraSoft.modules.ICEQueueList" %>
    <table border="0" cellpadding="2" cellspacing="0" width="100%">
        <tr>
            <td>
                <asp:GridView ID="BranchGrid" runat="server"
                    Width="100%" BorderWidth="0px" GridLines="None"
                    AutoGenerateColumns="False"  CellPadding="5" ShowFooter="true" 
                    CellSpacing="1" AlternatingRowStyle-BackColor="#ffffff"
                    FooterStyle-CssClass="GrayBackWhiteFont"
                    RowStyle-BackColor="#dee9fc" RowStyle-CssClass="Normal" 
                    HeaderStyle-CssClass="GrayBackWhiteFont">
                   <Columns>
                       <asp:BoundField  DataField = "QueueName"   HeaderText="Queue"     ItemStyle-Wrap ="false" HeaderStyle-Wrap="False" FooterText="Total" />
                       <asp:BoundField  DataField = "CheckCount"  HeaderText="Count"     ItemStyle-Wrap ="false" ItemStyle-HorizontalAlign="Right" FooterStyle-HorizontalAlign="Right" HeaderStyle-Wrap="False" />
                       <asp:BoundField  DataField = "TotalAmount" HeaderText="Amount"    ItemStyle-Wrap ="false" ItemStyle-HorizontalAlign="Right" FooterStyle-HorizontalAlign="Right" HeaderStyle-Wrap="False" DataFormatString="{0:F2}"  HtmlEncode="false" />
                    </Columns>	
               </asp:GridView>
            </td>
        </tr>
    </table>
