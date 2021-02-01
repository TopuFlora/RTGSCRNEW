<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WaivedCharge.aspx.cs" MasterPageFile="~/CR/Site.Master" Inherits="FloraSoft.CR.WaivedCharge" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h4> Wavied Charge</h4>
    <hr />  
   
   <table>
        <tr>
            <td>
                Account Number:
            </td>
            <td>
                <asp:TextBox ID="txtAccountNo" runat="server"></asp:TextBox>
                &nbsp;<asp:Button ID="btnSearch" runat="server"  CssClass="btn btn-success" OnClick="btnSearch_Click" Text="Search" />
            </td>
        </tr>
        <tr>
            <td>
                Status:
            </td>
            <td>
                <asp:DropDownList ID="ddlStatus" runat="server" OnSelectedIndexChanged="ddlStatus_SelectedIndexChanged"
                    AutoPostBack="True">
                    <asp:ListItem Text="ALL" Value="0"></asp:ListItem>
                    <asp:ListItem Text="Approved" Value="5"></asp:ListItem>
                    <asp:ListItem Text="Unapproved" Value="1"></asp:ListItem>
                    <asp:ListItem Text="Edit Waiting" Value="3"></asp:ListItem>
                    <asp:ListItem Text="Delete Waiting" Value="2"></asp:ListItem>
                    <asp:ListItem Text="Disaprroved" Value="6"></asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
    </table>
    <br />   
   <div>
        <asp:Button ID="btnAdd" runat="server" Text="Add Waived Charge"  CssClass="btn btn-success" OnClick="btnAdd_Click" />     
    </div>
    <asp:Panel ID="panAdd" runat="server" Visible="False">
    
    <fieldset>
    <legend>Wavied Charge </legend>
        <div class="row-fluid">
            <div>
                <asp:Label ID="Label1" runat="server" Text="Account Number:"></asp:Label>
            </div>
            <div>
                <asp:TextBox ID="txtAccountNumber" runat="server"></asp:TextBox>
            </div>
        </div>
        <div class="row-fluid">
            <div>
                <asp:Label ID="Label2" runat="server" Text="Clearing Type"></asp:Label>
            </div>
            <div>
                <!--<asp:TextBox ID="txtClearingType" runat="server"></asp:TextBox>-->
                <asp:DropDownList ID="ddlClearingType" runat="server">
                    <asp:ListItem Value="1">HV</asp:ListItem>
                    <asp:ListItem Value="2">RV</asp:ListItem>
                       <asp:ListItem Value="3">RVH</asp:ListItem>
                </asp:DropDownList>
            </div>
        </div>
        <div class="row-fluid">
            <div>
                <asp:Label ID="Label4" runat="server" Text="Special Commission"></asp:Label></div>
            <div>
                <asp:TextBox ID="txtSCommission" runat="server">0</asp:TextBox>
            </div>
        </div>
        <div class="row-fluid">
            <div>
                <asp:Label ID="Label3" runat="server" Text="Special VAT"></asp:Label></div>
            <div>
                <asp:TextBox ID="txtSVAT" runat="server">0</asp:TextBox>
            </div>
        </div>
        <div class="row-fluid">
            <div>
                <asp:Label ID="Label5" runat="server" Text="Bank Commission Contribution"></asp:Label></div>
            <div>
                <asp:TextBox ID="txtBankComCont" runat="server"></asp:TextBox>
            </div>
        </div>
        <div class="row-fluid">
            <div>
                <asp:Label ID="Label6" runat="server" Text="Bank Comission Contribution A/C No"></asp:Label></div>
            <div>
                <asp:TextBox ID="txtBankComContACNo" runat="server"></asp:TextBox>
            </div>
        </div>
        
        <div class="row-fluid">
            <div>
                <asp:Label ID="Label8" runat="server" Text="Bank VAT Contribution"></asp:Label></div>
            <div>
                <asp:TextBox ID="txtBankVATCont" runat="server"></asp:TextBox>
            </div>
        </div>
        <div class="row-fluid">
            <div>
                <asp:Label ID="Label9" runat="server" Text="Bank VAT Cont. A/CNo"></asp:Label></div>
            <div>
                <asp:TextBox ID="txtBankVATContACNo" runat="server"></asp:TextBox>
            </div>
        </div>
        <div class="row-fluid">
            <div>
                <asp:Label ID="Label10" runat="server" Text="Bulk Entry"></asp:Label></div>
            <div>
                <asp:CheckBox ID="chkBulkEntry" runat="server" />
            </div>
        </div>
        <div>
                <asp:HiddenField ID="hdfChargeID" runat="server" />
                </div> 
        <div>
            <asp:Button ID="btnInsert" runat="server" Text="Insert" CssClass="btn btn-success" OnClick="btnInsert_Click" />
            <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="btn btn-success" OnClick="btnCancel_Click" />
        </div>
   </fieldset>
    </asp:Panel>
  
    <asp:GridView ID="gvWaivedCharge" runat="server" AlternatingRowStyle-BackColor="#FFFFFF"
        AutoGenerateColumns="false" BorderWidth="0px" Height="0px" CellPadding="5" CellSpacing="1"
        GridLines="None" RowStyle-BackColor="#EEEEEE" HeaderStyle-BackColor="#F2DEDE"
        Width="993px" DataKeyNames="ChargeID" 
        onrowcommand="gvWaivedCharge_RowCommand" AllowPaging="True" PageSize="20">
        <Columns>
            <asp:BoundField DataField="ChargeID" HeaderText="ChargeID" Visible="false" />
            <asp:BoundField DataField="AccountNumber" HeaderText="Account Number" />
            <asp:TemplateField HeaderText="Clearing Type">
                <ItemTemplate>
                    <asp:DropDownList ID="ddlClearingTypeItem" runat="server" Enabled="False" SelectedValue='<%# Bind("ClearingType") %>'>
                        <asp:ListItem Value="1">HV</asp:ListItem>
                        <asp:ListItem Value="2">RV</asp:ListItem>
                       <asp:ListItem Value="3">RVH</asp:ListItem>
                    </asp:DropDownList>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="SCommission" HeaderText="SCommission" />
            <asp:BoundField DataField="BankComCont" HeaderText="Bank Com. Cont." />
            <asp:BoundField DataField="BankComContACNo" HeaderText="BankCom Cont ACNo" />
            <asp:BoundField DataField="SVAT" HeaderText="SVAT" />
            <asp:BoundField DataField="BankVATCont" HeaderText="Bank VAT Cont." />
            <asp:BoundField DataField="BankVATContACNo" HeaderText="BankV AT Cont. ACNo" />
            <asp:BoundField DataField="BulkEntry" HeaderText="BulkEntry" />
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
                    <asp:ImageButton ID="ImageButton2" runat="server" Height="20px"   CommandName="ChargeDelete"  ImageUrl="~/CR/Images/delete.jpg"
                        Width="25px" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
   </asp:Content>