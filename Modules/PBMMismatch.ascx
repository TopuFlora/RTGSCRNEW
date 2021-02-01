<%@ Control Language="C#" AutoEventWireup="true" EnableViewState="false" CodeBehind="PBMMismatch.ascx.cs" Inherits="FloraSoft.modules.PBMMismatch" %>
<table width="100%" border="0" cellpadding="1" cellspacing="0" bgcolor="#dee9fc">
     <tr>
        <td>
            <!------------------------------------------------->
             <table width="100%" class="GrayBackWhiteFont" cellpadding="1" cellspacing="1">
                <tr>
                    <td width="50px" height="20px" align="center"></td>
                    <td align="Right">Mismatch</td>
               </tr>
            </table>
            <!------------------------------------------------->
        </td>
    </tr>
    <tr>
        <td height="25px" bgcolor="dee9fc">
            <asp:GridView ID="BranchGrid" runat="server"
                Width="100%" BorderWidth="0px" GridLines="None" BackColor="#dddddd"
                AutoGenerateColumns="False"  CellPadding="3" ShowHeader="false" ShowFooter="false" 
                CellSpacing="1" AlternatingRowStyle-BackColor="#ffffff"
                RowStyle-BackColor="#dee9fc" RowStyle-CssClass="NormalSmall" 
                HeaderStyle-CssClass="GrayBackWhiteFontFixedHeader">
               <Columns>
                   <asp:TemplateField HeaderText="Count"  ItemStyle-Wrap="false">
                        <ItemTemplate>
                           <a href="PBMMismatch.aspx"><%#DataBinder.Eval(Container.DataItem, "CNT")%></a>
                        </ItemTemplate>
                   </asp:TemplateField>                  
                   <asp:BoundField  DataField = "Mismatch" HeaderText="Mismatch"    ItemStyle-Wrap ="false" ItemStyle-HorizontalAlign="Right" />
                </Columns>	
           </asp:GridView>
        </td>
    </tr>
 </table>
