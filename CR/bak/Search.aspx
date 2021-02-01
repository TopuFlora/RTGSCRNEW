<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Search.aspx.cs" MasterPageFile="~/CR/Site.Master"  Inherits="FloraSoft.CR.Search" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h4>Seach Report</h4>
    <hr />  
    <div class="NormalBold" style="margin:5px;float:left">Date From</div>
    <div style="margin:2px;float:left"><asp:TextBox ID="txtFromDate" Width="80px" Height="25px" runat="server" />
        <asp:RequiredFieldValidator ErrorMessage="*" ControlToValidate="txtFromDate" ID="dateValidate" runat="server"></asp:RequiredFieldValidator>
            
    </div>
    <div class="NormalBold" style="margin:5px;float:left">To</div>
    <div style="margin:2px;float:left"><asp:TextBox ID="txtToDate" Width="80px" Height="25px" runat="server" />
            <asp:RequiredFieldValidator ErrorMessage="*" ControlToValidate="txtToDate" ID="RequiredFieldValidator1" runat="server"></asp:RequiredFieldValidator>
</div>
    <div class="NormalBold" style="margin:5px;float:left">Charge Type</div>
    <div style="float:left;margin:5px">
        <asp:DropDownList runat="server" ID="ddlChargeType">
            <asp:ListItem Text="All" Value="All" />
            <asp:ListItem Text="Bangladesh Bank Charge" />
            <asp:ListItem Text="Standard Charge" Value="StandardCharge" />
            <asp:ListItem Text="Special Charge" Value="SpecialCharge" />
        </asp:DropDownList>
    </div>
    <div class="NormalBold" style="margin:5px;float:left">Activity Status</div>
    <div style="float:left;margin:5px">
        <asp:DropDownList runat="server" ID="ddlActivity">
            <asp:ListItem Text="All" Value="All" />
            <asp:ListItem Text="Update" Value="Delete" />
            <asp:ListItem Text="Delete" Value="Delete" />
            <asp:ListItem Text="INSERT" Value="INSERT" />
            <asp:ListItem Text="Edit Approved" Value="Edit Approved" />
            <asp:ListItem Text="Approved" Value="Approved" />
            <asp:ListItem Text="DisApproved" Value="DisApproved" />
        </asp:DropDownList>
    </div>
    <div class="NormalBold" style="margin:5px;float:left">User ID</div>
    <div style="float:left;margin:5px">
        <asp:TextBox runat="server" ID="txtUserID" />    
    </div>
    <div style="float:left;margin:5px">
        <asp:Button ID ="btnShow" runat="server" Text="Search" onclick="btnShowHistory_Click" CssClass="btn btn-danger"  />
    </div>
    <div style="float:left;margin:5px">
        <asp:Label ID="lblErrorMessage" ForeColor="Red" runat="server" />
    </div>
    <%--<div>
        <asp:dropdownlist id="ChkMonth" Runat="server" AutoPostBack="True">
			<asp:ListItem Value="1">Jan</asp:ListItem>
			<asp:ListItem Value="2">Feb</asp:ListItem>
			<asp:ListItem Value="3">Mar</asp:ListItem>
			<asp:ListItem Value="4">Apr</asp:ListItem>
			<asp:ListItem Value="5">May</asp:ListItem>
			<asp:ListItem Value="6">Jun</asp:ListItem>
			<asp:ListItem Value="7">Jul</asp:ListItem>
			<asp:ListItem Value="8">Aug</asp:ListItem>
			<asp:ListItem Value="9">Sep</asp:ListItem>
			<asp:ListItem Value="10">Oct</asp:ListItem>
			<asp:ListItem Value="11">Nov</asp:ListItem>
			<asp:ListItem Value="12">Dec</asp:ListItem>
		</asp:dropdownlist>
        <asp:dropdownlist id="ChkYear" Runat="server" AutoPostBack="True">
			<asp:ListItem Value="2011">2015</asp:ListItem>
			<asp:ListItem Value="2012">2016</asp:ListItem>
			<asp:ListItem Value="2013">2017</asp:ListItem>
			<asp:ListItem Value="2014">2018</asp:ListItem>
			<asp:ListItem Value="2015">2019</asp:ListItem>
		</asp:dropdownlist>
        <asp:Button ID="btnShowHistory" runat="server" Text="Show" 
             />
        
    </div>--%>
    <asp:GridView ID="gvHistory" runat="server" AlternatingRowStyle-BackColor="#FFFFFF"
        BorderWidth="0px" Height="0px" CellPadding="5" CellSpacing="1" AutoGenerateColumns="false"
        GridLines="None" RowStyle-BackColor="#EEEEEE" HeaderStyle-BackColor="#F2DEDE"
        Width="993px">
        <Columns>
         <asp:BoundField DataField="ActivityTime" HeaderText="Log Time" />
            <asp:BoundField DataField="ItemName" HeaderText="Charge Type" />
            <asp:BoundField DataField="ActivityType" HeaderText="Activity Status" />
            <asp:BoundField DataField="UserID" HeaderText="User ID" />
        </Columns>
    </asp:GridView>
    <script type="text/javascript" src="Scripts/DatePicker/bootstrap-datepicker.js"></script>
    <script type="text/javascript">
        // When the document is ready
        $(document).ready(function () {
            $('#<%= txtFromDate.ClientID %>').datepicker({
                format: "dd/mm/yyyy"
            });
            $('#<%= txtToDate.ClientID %>').datepicker({
                format: "dd/mm/yyyy"
            });
        });
        $('#exampleModal').on('show.bs.modal', function (event) {
            var button = $(event.relatedTarget) // Button that triggered the modal
            var recipient = button.data('whatever') // Extract info from data-* attributes
            // If necessary, you could initiate an AJAX request here (and then do the updating in a callback).
            // Update the modal's content. We'll use jQuery here, but you could use a data binding library or other methods instead.
            var modal = $(this)
            //modal.find('.modal-title').text('New message to ' + recipient)
            modal.find('.modal-body form-control').val(recipient)
        })
     </script>
  </asp:Content>