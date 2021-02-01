<%@ Control Language="C#" AutoEventWireup="true" EnableViewState="false" CodeBehind="OCEBranchStatus.ascx.cs" Inherits="FloraSoft.modules.OCEBranchStatus" %>
<table border="0" cellpadding="0" cellspacing="0" bgcolor="#dee9fc">
     <tr>
        <td>
            <!------------------------------------------------->
             <table width="500px" border="0" class="GrayBackWhiteFont" cellpadding="3" cellspacing="1">
                <tr>
                    <td width="110px" class="NormalBoldSmall" align="center">Branch</td>
                    <td width="49px" class="NormalBoldSmall" align="Right">Scan</td>
                    <td width="49px" class="NormalBoldSmall" align="Right">Maker</td>
                    <td width="49px" class="NormalBoldSmall" align="Right">Chckr</td>
                    <td width="49px" class="NormalBoldSmall" align="Right">Admn</td>
                    <td width="49px" class="NormalBoldSmall" align="Right">OCE</td>
                    <td width="49px" class="NormalBoldSmall" align="Right">Total</td>
                    <td width="49px" class="NormalBoldSmall" align="Right">IQA</td>
                    <td width="49px" class="NormalBoldSmall" align="Right">IRE</td>
                    <td width="20px"></td>
               </tr>
            </table>
            <!------------------------------------------------->
        </td>
    </tr>
   <tr>
        <td>
            <DIV id="OCEBranchViewDiv" runat="server" style="position:relative;OVERFLOW: auto;WIDTH: 500px; height:100px; TEXT-ALIGN: left">
            <asp:GridView ID="BranchGrid" runat="server"
                Width="480px" BorderWidth="0px" GridLines="None" BackColor="#dddddd"
                AutoGenerateColumns="False"  CellPadding="5" ShowHeader="false" ShowFooter="false" 
                CellSpacing="1" AlternatingRowStyle-BackColor="#ffffff"
                RowStyle-BackColor="#D5FCE0" RowStyle-CssClass="NormalSmall" 
                HeaderStyle-CssClass="GrayBackWhiteFontFixedHeader">
               <Columns>
                   <asp:TemplateField HeaderText="Branch" ItemStyle-Wrap="false" ItemStyle-Width="90px">
                        <ItemTemplate>
                            <a href='BatchChecks.aspx?RoutingNo=<%#DataBinder.Eval(Container.DataItem, "RoutingNo")%>&ClearingType=<%= sClearingType%>'><%#DataBinder.Eval(Container.DataItem, "BranchName")%></a>
                        </ItemTemplate>
                   </asp:TemplateField>                   
                   <asp:BoundField  DataField = "S1"  ItemStyle-Width = "49px"   ItemStyle-Wrap ="false" ItemStyle-HorizontalAlign="Right" />
                   <asp:BoundField  DataField = "S2"  ItemStyle-Width = "49px"   ItemStyle-Wrap ="false" ItemStyle-HorizontalAlign="Right" />
                   <asp:BoundField  DataField = "S4"  ItemStyle-Width = "49px"   ItemStyle-Wrap ="false" ItemStyle-HorizontalAlign="Right" />
                   <asp:BoundField  DataField = "S5"  ItemStyle-Width = "49px"   ItemStyle-Wrap ="false" ItemStyle-HorizontalAlign="Right" />
                   <asp:BoundField  DataField = "S6"  ItemStyle-Width = "49px"   ItemStyle-Wrap ="false" ItemStyle-HorizontalAlign="Right" />
                   <asp:BoundField  DataField = "T"   ItemStyle-Width = "49px"   ItemStyle-Wrap ="false" ItemStyle-HorizontalAlign="Right" />
                   <asp:BoundField  DataField = "S8"  ItemStyle-Width = "49px"   ItemStyle-Wrap ="false" ItemStyle-HorizontalAlign="Right" />
                   <asp:BoundField  DataField = "S9"  ItemStyle-Width = "49px"   ItemStyle-Wrap ="false" ItemStyle-HorizontalAlign="Right" />
                </Columns>	
           </asp:GridView>
           </DIV>
        </td>
    </tr>
    <tr>
        <td>
            <!------------------------------------------------->
             <table width="500px" border="0" class="GrayBackWhiteFont" cellpadding="3" cellspacing="1">
                <tr>
                    <td width="110px" class="NormalBoldSmall"><asp:Label ID="LblTotal" runat="server" /></td>
                    <td width="49px" class="NormalBoldSmall" align="Right"><asp:Label ID="Scanman"  runat="server" /></td>
                    <td width="49px" class="NormalBoldSmall" align="Right"><asp:Label ID="Maker"    runat="server" /></td>
                    <td width="49px" class="NormalBoldSmall" align="Right"><asp:Label ID="Checker"  runat="server" /></td>
                    <td width="49px" class="NormalBoldSmall" align="Right"><a id="Admin" class="HighlightButton" runat="server"></a></td>
                    <td width="49px" class="NormalBoldSmall" align="Right"><asp:Label ID="PBM"      runat="server" /></td>
                    <td width="49px" class="NormalBoldSmall" align="Right"><asp:Label ID="Total"    runat="server" /></td>
                    <td width="49px" class="NormalBoldSmall" align="Right"><asp:Label ID="IQA"      runat="server" /></td>
                    <td width="49px" class="NormalBoldSmall" align="Right"><asp:Label ID="IRE"      runat="server" /></td>
                    <td width="20px"></td>
               </tr>
            </table>
            <!------------------------------------------------->
        </td>
    </tr>
</table>
