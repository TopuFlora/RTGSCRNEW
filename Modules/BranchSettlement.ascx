<%@ Control Language="C#" AutoEventWireup="true" EnableViewState="false" CodeBehind="BranchSettlement.ascx.cs" Inherits="FloraSoft.modules.BranchSettlement" %>
<table border="0" cellpadding="1" cellspacing="0" bgcolor="#dee9fc">
     <tr>
        <td>
            <!------------------------------------------------->
             <table width="500px" class="GrayBackWhiteFont" cellpadding="1" cellspacing="1">
                <tr>
                    <td width="20px"align="center"><asp:ImageButton ID="PrintBtn" runat="server" ImageUrl="~/Images/buttonprint1.gif" OnClick="PrintBtn_Click" /></td>
                    <td width="30px" class="NormalXSmall" align="center">Branch</td>
                    <td width="64px" class="NormalXSmall" align="Right">OCE</td>
                    <td width="64px" class="NormalXSmall" align="Right">ICE</td>
                    <td width="64px" class="NormalXSmall" align="Right">ORE</td>
                    <td width="54px" class="NormalXSmall" align="Right">IRE</td>
                    <td width="30px"></td>
               </tr>
            </table>
            <!------------------------------------------------->
        </td>
    </tr>
   <tr>
        <td>
            <DIV id="SettlementViewDiv" runat="server" style="position:relative;OVERFLOW: auto;WIDTH: 500px; height:100px; TEXT-ALIGN: left">
            <asp:GridView ID="SettlementGrid" runat="server"
                Width="480px" BorderWidth="0px" GridLines="None" BackColor="#dddddd"
                AutoGenerateColumns="False"  CellPadding="5" ShowHeader="false" ShowFooter="false" 
                CellSpacing="1" AlternatingRowStyle-BackColor="#ffffff"
                RowStyle-BackColor="#dee9fc" RowStyle-CssClass="NormalXSmall" 
                HeaderStyle-CssClass="GrayBackWhiteFontFixedHeader">
               <Columns>
                   <asp:BoundField  DataField = "Name"      ItemStyle-Width = "95px"   ItemStyle-Wrap ="false" HeaderStyle-Wrap="False" />
                   <asp:BoundField  DataField = "iOCE"      ItemStyle-Width = "20px"   ItemStyle-Wrap ="false" ItemStyle-HorizontalAlign="Right"  HeaderStyle-Wrap="True" />
                   <asp:BoundField  DataField = "OCE"       ItemStyle-Width = "60px"   ItemStyle-Wrap ="false" ItemStyle-HorizontalAlign="Right"  HeaderStyle-Wrap="True" />
                   <asp:BoundField  DataField = "iICE"      ItemStyle-Width = "20px"   ItemStyle-Wrap ="false" ItemStyle-HorizontalAlign="Right"  HeaderStyle-Wrap="True" />
                   <asp:BoundField  DataField = "ICE"       ItemStyle-Width = "60px"   ItemStyle-Wrap ="false" ItemStyle-HorizontalAlign="Right"  HeaderStyle-Wrap="True" />
                   <asp:BoundField  DataField = "iORE"      ItemStyle-Width = "20px"   ItemStyle-Wrap ="false" ItemStyle-HorizontalAlign="Right"  HeaderStyle-Wrap="True" />
                   <asp:BoundField  DataField = "ORE"       ItemStyle-Width = "60px"   ItemStyle-Wrap ="false" ItemStyle-HorizontalAlign="Right"  HeaderStyle-Wrap="True" />
                   <asp:BoundField  DataField = "iIRE"      ItemStyle-Width = "20px"   ItemStyle-Wrap ="false" ItemStyle-HorizontalAlign="Right"  HeaderStyle-Wrap="True" />
                   <asp:BoundField  DataField = "IRE"       ItemStyle-Width = "60px"   ItemStyle-Wrap ="false" ItemStyle-HorizontalAlign="Right"  HeaderStyle-Wrap="True" />
               </Columns>	
           </asp:GridView>
           </DIV>
        </td>
    </tr>
    <tr>
        <td>
            <!------------------------------------------------->
             <table width="500px" class="GrayBackWhiteFont" cellpadding="3" cellspacing="1">
                <tr>
                    <td width="100px" class="NormalXSmall"><asp:Label ID="LblTotal" runat="server" /></td>
                    <td width="20px" class="NormalXSmall" align="Right"><asp:Label ID="iOCE"  runat="server" /></td>
                    <td width="60px" class="NormalXSmall" align="Right"><asp:Label ID="OCE"   runat="server" /></td>
                    <td width="20px" class="NormalXSmall" align="Right"><asp:Label ID="iICE"  runat="server" /></td>
                    <td width="60px" class="NormalXSmall" align="Right"><asp:Label ID="ICE"   runat="server" /></td>
                    <td width="20px" class="NormalXSmall" align="Right"><asp:Label ID="iORE"  runat="server" /></td>
                    <td width="60px" class="NormalXSmall" align="Right"><asp:Label ID="ORE"   runat="server" /></td>
                    <td width="20px" class="NormalXSmall" align="Right"><asp:Label ID="iIRE"  runat="server" /></td>
                    <td width="60px" class="NormalXSmall" align="Right"><asp:Label ID="IRE"   runat="server" /></td>
                    <td width="10px"></td>
               </tr>
            </table>
            <!------------------------------------------------->
        </td>
    </tr>
</table>
