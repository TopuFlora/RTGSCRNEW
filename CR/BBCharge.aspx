<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/CR/Site.Master" CodeBehind="BBCharge.aspx.cs" Inherits="FloraSoft.CR.BBCharge" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h4> Bangladesh Bank Charge</h4>
    <hr />    
     <asp:Panel ID="panAdd" runat="server" Visible="False">
    <fieldset>
    <legend>BB Charge </legend>
      
        <div class="row-fluid">
            <div>
                <asp:Label ID="Label3" runat="server" Text="HV Bangladesh bank Charge"></asp:Label></div>
            <div>
                <asp:TextBox ID="txtHVBBCharge" runat="server"   ></asp:TextBox>
            </div>
        </div>
        
        
        
        <div class="row-fluid">
            <div>
                <asp:Label ID="Label8" runat="server" Text="RV Bangladesh bank Charge"></asp:Label></div>
            <div>
                <asp:TextBox ID="txtRVBBCharge" runat="server"></asp:TextBox>
            </div>
        </div>
        
        
        <div class="row-fluid">
            <div>
                <asp:Label ID="Label10" runat="server" Text="RVH Bangladesh bank Charge"></asp:Label></div>
            <div>
                <asp:TextBox ID="txtRVHBBCharge" runat="server"></asp:TextBox>
            </div>
        </div>
  <div>
                <asp:HiddenField ID="hdfChargeID" runat="server" />
                </div>
        <div>
            <asp:Button ID="btnUpdate" runat="server" Text="Update" CssClass="btn btn-success"
                onclick="btnUpdate_Click"  />
            <asp:Button ID="btnCancel" runat="server" CssClass="btn btn-success" Text="Cancel" OnClick="btnCancel_Click" />
        </div>
   </fieldset>
    </asp:Panel>
    <div>
    
    <asp:GridView ID="gvBBCharge" runat="server" AlternatingItemStyle-BackColor="#FFFFFF" 
        AutoGenerateColumns="false" ItemStyle-ForeColor="#4E5559" HeaderStyle-BackColor="#F2DEDE" 
        BorderWidth="0px" Height="0px" CellPadding="5" CellSpacing="1"
        GridLines="None" ItemStyle-BackColor="#dee9fc"
        Width="993px" onrowcommand="gvBBCharge_RowCommand" DataKeyNames="ChargeID">
        <Columns>
             <asp:BoundField DataField="ChargeID" HeaderText="ChargeID" Visible="false"   />
            <asp:BoundField DataField="HVBBChrg" HeaderText="HV Bangladesh Bank Charge" />
  
            <asp:BoundField DataField="RVBBChrg" HeaderText="RV Bangladesh Bank Charge" />
       
            <asp:BoundField DataField="RVHBBChrg" HeaderText="RVH Bangladesh Bank BChrg" />
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
            </Columns> 
    </asp:GridView>
    
    </div>
   </asp:Content>