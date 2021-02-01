<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ICECheckStatus.ascx.cs" Inherits="FloraSoft.modules.ICECheckStatus" %>
    <table border="0" cellpadding="2" cellspacing="0" width="100%">
        <tr>
            <td>
                <asp:GridView ID="StatusGrid" runat="server"
                    Width="250px" BorderWidth="0px" GridLines="None"
                    AutoGenerateColumns="False"  CellPadding="5" ShowFooter="true" 
                    CellSpacing="1" AlternatingRowStyle-BackColor="#ffffff" 
                    FooterStyle-CssClass="GrayBackWhiteFont"
                    RowStyle-BackColor="#dee9fc" RowStyle-CssClass="Normal" 
                    HeaderStyle-CssClass="GrayBackWhiteFont">
                   <Columns>
                       <asp:TemplateField HeaderText="Maker/Checker" ItemStyle-Wrap="false">
                        <ItemTemplate>
                                <%#DataBinder.Eval(Container.DataItem, "ReturnReason")%>
                        </ItemTemplate>
                        <FooterTemplate>
                            <span class="GrayBackWhiteFont">All</span>                            
                        </FooterTemplate>
                       </asp:TemplateField>
                       <asp:BoundField  DataField = "CheckCount"    HeaderText="Count"     ItemStyle-Wrap ="false" ItemStyle-HorizontalAlign="Center" HeaderStyle-Wrap="False" />
                       <asp:BoundField  DataField = "TotalAmount"   HeaderText="Amount"    ItemStyle-Wrap ="false" ItemStyle-HorizontalAlign="Right"  HeaderStyle-Wrap="False" DataFormatString="{0:F2}" HtmlEncode="false" />
                    </Columns>	
               </asp:GridView>
            </td>
        </tr>
    </table>
