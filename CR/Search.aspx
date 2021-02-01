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
    <div class="NormalBold"  style="margin:5px;float:left" >Type</div>
    <div style="float:left;margin:5px">
        <asp:DropDownList runat="server" ID="ddlType" Visible="false">
            <asp:ListItem Text="All" Value="All" />
             <asp:ListItem Text="Charge" Value="Charge" />
            <asp:ListItem Text="VAT" Value="VAT" />
        </asp:DropDownList>
    </div>
    <div class="NormalBold" style="margin:5px;float:left">Account No</div>
    <div style="float:left;margin:5px">
        <asp:TextBox runat="server" ID="txtAccountNo" />    
    </div>
    <div style="float:left;margin:5px">
        <asp:Button ID ="btnShow" runat="server" Text="Search" onclick="btnShowHistory_Click" CssClass="btn btn-danger"  />
    </div>
    <div style="float:left;margin:5px">
        <asp:Label ID="lblErrorMessage" ForeColor="Red" runat="server" />
    </div>
    <asp:GridView ID="gvHistory" runat="server" AlternatingRowStyle-BackColor="#FFFFFF"
        BorderWidth="0px" Height="0px" CellPadding="5" CellSpacing="1" AutoGenerateColumns="True"
        GridLines="None" RowStyle-BackColor="#EEEEEE" HeaderStyle-BackColor="#F2DEDE"
        Width="993px">
        <Columns>
       <%-- <asp:BoundField DataField="Date" HeaderText="Date" />
            <asp:BoundField DataField="Type" HeaderText="Type" />
            <asp:BoundField DataField="AccountNo" HeaderText="Account No" />--%>
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