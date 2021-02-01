<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StandardCharge.aspx.cs" MasterPageFile="~/CR/Site.Master"
    Inherits="FloraSoft.CR.StandardCharge" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h4> Standard Charge</h4>
    <hr />    
   <%-- Search By GHO:
    <asp:DropDownList ID="ddlGHOEditSearch" runat="server" SelectedValue='<%# Bind("GHO") %>'
        AutoPostBack="True" OnSelectedIndexChanged="ddlGHOEditSearch_SelectedIndexChanged">
        <asp:ListItem>All</asp:ListItem>
        <asp:ListItem>DEFAULT</asp:ListItem>
        <asp:ListItem>ABO</asp:ListItem>
        <asp:ListItem>BNK</asp:ListItem>
        <asp:ListItem>BRL</asp:ListItem>
        <asp:ListItem>BRO</asp:ListItem>
        <asp:ListItem>C11</asp:ListItem>
        <asp:ListItem>C12</asp:ListItem>
        <asp:ListItem>C13</asp:ListItem>
        <asp:ListItem>C16</asp:ListItem>
        <asp:ListItem>C17</asp:ListItem>
        <asp:ListItem>C21</asp:ListItem>
        <asp:ListItem>C22</asp:ListItem>
        <asp:ListItem>CFI</asp:ListItem>
        <asp:ListItem>CFS</asp:ListItem>
        <asp:ListItem>CLR</asp:ListItem>
        <asp:ListItem>CLT</asp:ListItem>
        <asp:ListItem>FNB</asp:ListItem>
        <asp:ListItem>FNI</asp:ListItem>
        <asp:ListItem>FPO</asp:ListItem>
        <asp:ListItem>GVM</asp:ListItem>
        <asp:ListItem>IFS</asp:ListItem>
        <asp:ListItem>ILT</asp:ListItem>
        <asp:ListItem>IOO</asp:ListItem>
        <asp:ListItem>LTD</asp:ListItem>
        <asp:ListItem>LTR</asp:ListItem>
        <asp:ListItem>MFB</asp:ListItem>
        <asp:ListItem>MFI</asp:ListItem>
        <asp:ListItem>MFS</asp:ListItem>
        <asp:ListItem>MFT</asp:ListItem>
        <asp:ListItem>MLR</asp:ListItem>
        <asp:ListItem>MLT</asp:ListItem>
        <asp:ListItem>NIO</asp:ListItem>
        <asp:ListItem>OTH</asp:ListItem>
        <asp:ListItem>PRP</asp:ListItem>
        <asp:ListItem>SEC</asp:ListItem>
        <asp:ListItem>SNL</asp:ListItem>
        <asp:ListItem>SSL</asp:ListItem>
        <asp:ListItem>STS</asp:ListItem>
        <asp:ListItem>STF</asp:ListItem>
        <asp:ListItem>STJ</asp:ListItem>
        <asp:ListItem>PRS</asp:ListItem>
        <asp:ListItem>PRJ</asp:ListItem>
    </asp:DropDownList>--%>
    <br />
    <div>
        <asp:Button ID="btnAdd" runat="server" Text="Add Standard Charge" CssClass="btn btn-success" OnClick="btnAdd_Click" />
    </div>
    <div>
        <asp:Panel ID="panAdd" runat="server" Visible="False">
            <fieldset>
                <legend>Standard Charge Data</legend>
                <%-- <div class="row-fluid">
                    <div>
                        <asp:Label ID="Label2" runat="server" Text="Clearing Type"></asp:Label>
                    </div>
                    <div>
                        <asp:DropDownList ID="ddlClearingType" runat="server">
                            <asp:ListItem Value="1">HV</asp:ListItem>
                            <asp:ListItem Value="2">RV</asp:ListItem>
                            <asp:ListItem Value="4">RVH</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>--%>
                <div class="row-fluid">
                    <div>
                        <asp:Label ID="Label4" runat="server" Text="Bank Commission"></asp:Label></div>
                    <div>
                        <asp:TextBox ID="txtCommission" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="row-fluid">
                    <div>
                        <asp:Label ID="Label7" runat="server" Text="Bank Commission VAT"></asp:Label></div>
                    <div>
                        <asp:TextBox ID="txtVAT" runat="server"></asp:TextBox>
                    </div>
                </div>
               
                <%--<div class="row-fluid">
                    <div>
                        <asp:Label ID="Label3" runat="server" Text="GHO Type:"></asp:Label>
                    </div>
                    <div>
                        <asp:DropDownList ID="ddlGHO" runat="server">
                            <asp:ListItem>DEF</asp:ListItem>
                            <asp:ListItem>ABO</asp:ListItem>
                            <asp:ListItem>BNK</asp:ListItem>
                            <asp:ListItem>BRL</asp:ListItem>
                            <asp:ListItem>BRO</asp:ListItem>
                            <asp:ListItem>C11</asp:ListItem>
                            <asp:ListItem>C12</asp:ListItem>
                            <asp:ListItem>C13</asp:ListItem>
                            <asp:ListItem>C16</asp:ListItem>
                            <asp:ListItem>C17</asp:ListItem>
                            <asp:ListItem>C21</asp:ListItem>
                            <asp:ListItem>C22</asp:ListItem>
                            <asp:ListItem>CFI</asp:ListItem>
                            <asp:ListItem>CFS</asp:ListItem>
                            <asp:ListItem>CLR</asp:ListItem>
                            <asp:ListItem>CLT</asp:ListItem>
                            <asp:ListItem>FNB</asp:ListItem>
                            <asp:ListItem>FNI</asp:ListItem>
                            <asp:ListItem>FPO</asp:ListItem>
                            <asp:ListItem>GVM</asp:ListItem>
                            <asp:ListItem>IFS</asp:ListItem>
                            <asp:ListItem>ILT</asp:ListItem>
                            <asp:ListItem>IOO</asp:ListItem>
                            <asp:ListItem>LTD</asp:ListItem>
                            <asp:ListItem>LTR</asp:ListItem>
                            <asp:ListItem>MFB</asp:ListItem>
                            <asp:ListItem>MFI</asp:ListItem>
                            <asp:ListItem>MFS</asp:ListItem>
                            <asp:ListItem>MFT</asp:ListItem>
                            <asp:ListItem>MLR</asp:ListItem>
                            <asp:ListItem>MLT</asp:ListItem>
                            <asp:ListItem>NIO</asp:ListItem>
                            <asp:ListItem>OTH</asp:ListItem>
                            <asp:ListItem>PRP</asp:ListItem>
                            <asp:ListItem>SEC</asp:ListItem>
                            <asp:ListItem>SNL</asp:ListItem>
                            <asp:ListItem>SSL</asp:ListItem>
                            <asp:ListItem>STS</asp:ListItem>
                            <asp:ListItem>STF</asp:ListItem>
                            <asp:ListItem>STJ</asp:ListItem>
                            <asp:ListItem>PRS</asp:ListItem>
                            <asp:ListItem>PRJ</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>--%>
                
<%--                <div class="row-fluid">
                    <div>
                        <asp:Label ID="Label10" runat="server" Text="Bulk Entry"></asp:Label></div>
                    <div>
                        <asp:CheckBox ID="chkBulkEntry" runat="server" />
                    </div>
                    
                </div>--%>
                <div>
                <asp:HiddenField ID="hdfChargeID" runat="server" />
                </div> 
               
                <div>
                    <asp:Button ID="btnInsert" runat="server" Text="Insert" CssClass="btn btn-success" OnClick="btnInsert_Click" />
                    <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="btn btn-success" OnClick="btnCancel_Click" />
                </div>
            </fieldset>
        </asp:Panel>
        <asp:GridView ID="gvStandardCharge" runat="server" AlternatingRowStyle-BackColor="White"
            AutoGenerateColumns="False" BorderWidth="0px" Height="0px" CellPadding="5" CellSpacing="1"
            GridLines="None" HeaderStyle-BackColor="#F2DEDE" RowStyle-BackColor="#EEEEEE"
            Width="993px" DataKeyNames="ChargeID" 
            onrowcommand="gvStandardCharge_RowCommand" PageSize="15">
            <Columns>
<%--              <asp:TemplateField HeaderText="Clearing Type">
                    <ItemTemplate>
                        <asp:DropDownList ID="ddlClearingTypeItem" runat="server" Enabled="False" SelectedValue='<%# Bind("ClearingType") %>'>
                            <asp:ListItem Value="1">HV</asp:ListItem>
                            <asp:ListItem Value="2">RV</asp:ListItem>
                            <asp:ListItem Value="4">RVH</asp:ListItem>
                        </asp:DropDownList>
                    </ItemTemplate>
                </asp:TemplateField>--%>
                <asp:BoundField DataField="ChargeID" HeaderText="ChargeID" Visible="false" />
                <asp:BoundField DataField="GHO" HeaderText="GHO" />
                <asp:BoundField DataField="Commission" HeaderText="Commission" />
                <asp:BoundField DataField="VAT" HeaderText="VAT" />
              
              <%--  <asp:BoundField DataField="GHO" HeaderText="GHO" />--%>
                <%--<asp:BoundField DataField="BulkEntry" HeaderText="BulkEntry" />--%>
                <asp:BoundField DataField="StatusName" HeaderText="Status" />
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton ID="btnApprove" runat="server" CommandName="Approve" Text='<%# Bind("StatusName") %>'></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:ImageButton ID="ImageButton1" runat="server" CommandName="ChargeEdit" Height="24px"
                            ImageUrl="~/CR/Images/edit.jpg" Width="25px" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:ImageButton ID="ImageButton2" runat="server" CommandName="ChargeDelete" Height="20px" ImageUrl="~/CR/Images/delete.jpg"
                            Width="25px" />
                    </ItemTemplate>
                </asp:TemplateField>

                  <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton ID="btnDisapprove" runat="server" CommandName="DisApprove" Height="20px" Text="Disapproved" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            
        </asp:GridView>
    </div>
    </asp:Content>