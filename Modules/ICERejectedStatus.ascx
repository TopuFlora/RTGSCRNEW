<%@ Control Language="C#" AutoEventWireup="true" EnableViewState="false" CodeBehind="ICERejectedStatus.ascx.cs" Inherits="FloraSoft.modules.ICERejectedStatus" %>
    <table border="0" cellpadding="0" cellspacing="0" bgcolor="#dee9fc">
     <tr>
        <td>
            <!------------------------------------------------->
             <table width="500px" border="0" class="GrayBackWhiteFont" cellpadding="3" cellspacing="1">
                <tr>
                    <td width="110px" class="NormalBoldSmall" align="center">Branch</td>
                    <td width="61px" class="NormalBoldSmall" align="right">Maker</td>
                    <td width="61px" class="NormalBoldSmall" align="right">Chckr</td>
                    <td width="61px" class="NormalBoldSmall" align="right">Total</td>
                    <td width="10px"></td>
               </tr>
            </table>
            <!------------------------------------------------->
        </td>
    </tr>
    <tr>
        <td>
            <div id="ICEBranchViewDiv" runat="server" style="position:relative;OVERFLOW: auto;WIDTH: 500px; height:100px; TEXT-ALIGN: left">
            <asp:GridView ID="BranchGrid" runat="server" Height="0px" 
                Width="480px" BorderWidth="0px" GridLines="None" BackColor="#dddddd"
                AutoGenerateColumns="False"  CellPadding="5" ShowFooter="false" ShowHeader="false" 
                CellSpacing="1" AlternatingRowStyle-BackColor="#ffffff"
                RowStyle-BackColor="#dee9fc" RowStyle-CssClass="NormalSmall" 
                FooterStyle-CssClass="GrayBackWhiteFont"
                HeaderStyle-CssClass="GrayBackWhiteFont" FooterStyle-HorizontalAlign="Right">
               <Columns>
                   <asp:TemplateField HeaderText="Branch" ItemStyle-Wrap="false" ItemStyle-Width="80px">
                        <ItemTemplate>
                            <a href='InwardList.aspx?RoutingNo=<%#DataBinder.Eval(Container.DataItem, "CheckRoutingNo")%>&ClearingType=<%= sECEType%>'><%#DataBinder.Eval(Container.DataItem, "BranchName")%></a>
                        </ItemTemplate>
                   </asp:TemplateField>                   
                   <asp:BoundField  DataField = "C0"    ItemStyle-Width = "61px"   ItemStyle-Wrap ="false" ItemStyle-HorizontalAlign="Right" />
                   <asp:BoundField  DataField = "C1"    ItemStyle-Width = "61px"   ItemStyle-Wrap ="false" ItemStyle-HorizontalAlign="Right" />
                   <asp:BoundField  DataField = "T"     ItemStyle-Width = "61px"   ItemStyle-Wrap ="false" ItemStyle-HorizontalAlign="Right" />
                </Columns>	
           </asp:GridView>
           </div>
        </td>
    </tr>
    <tr>
        <td>
            <!------------------------------------------------->
             <table width="500px" class="GrayBackWhiteFont" border="0" cellpadding="3" cellspacing="1">
                <tr>
                    <td width="80px" class="NormalBoldSmall"><asp:Label ID="LblTotal" runat="server" /></td>
                    <td width="67px" class="NormalBoldSmall" align="Right"><asp:Label ID="Maker"    runat="server" /></td>
                    <td width="67px" class="NormalBoldSmall" align="Right"><asp:Label ID="Checker"  runat="server" /></td>
                    <td width="67px" class="NormalBoldSmall" align="Right"><asp:Label ID="Total"    runat="server" /></td>
                    <td width="10px"></td>
               </tr>
            </table>
            <!------------------------------------------------->
        </td>
    </tr>
</table>
