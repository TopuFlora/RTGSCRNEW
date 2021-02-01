<%@ Page Title="" Language="C#" MasterPageFile="~/CR/Site.Master" AutoEventWireup="true" CodeBehind="GenerateFlatFile.aspx.cs" Inherits="FloraSoft.CR.WebForm2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h4>Generate Flat File</h4>
    <hr />
    <br />

    <div class="NormalBold" style="margin: 5px; float: left">Date From</div>
    <div style="margin: 2px; float: left">
        <asp:TextBox ID="txtFromDate" Width="80px" Height="25px" runat="server" />
        <asp:RequiredFieldValidator ErrorMessage="*" ControlToValidate="txtFromDate" ID="dateValidate" runat="server"></asp:RequiredFieldValidator>

    </div>
    <div class="NormalBold" style="margin: 5px; float: left">To</div>
    <div style="margin: 2px; float: left">
        <asp:TextBox ID="txtToDate" Width="80px" Height="25px" runat="server" />
        <asp:RequiredFieldValidator ErrorMessage="*" ControlToValidate="txtToDate" ID="RequiredFieldValidator1" runat="server"></asp:RequiredFieldValidator>
    </div>
    <td>
        <asp:DropDownList ID="ddlCategory" runat="server" OnSelectedIndexChanged="ddlStatus_SelectedIndexChanged" AutoPostBack="True">
            <asp:ListItem Text="ALL" Value="ALL"></asp:ListItem>
            <asp:ListItem Text="Charge" Value="Charge"></asp:ListItem>
            <asp:ListItem Text="VAT" Value="VAT"></asp:ListItem>
        </asp:DropDownList>
    </td>
    <br />
    <br />
    <div>
        <asp:Button ID="btnAdd" runat="server" Text="Search" CssClass="btn btn-success" OnClick="btnAdd_Click" />
    </div>
    <hr />

    <div class="table-responsive">
    <asp:GridView ID="gvGenerateFlatFile" runat="server" AlternatingRowStyle-BackColor="#FFFFFF"
        BorderWidth="0px" Height="0px" CellPadding="5" CellSpacing="1" AutoGenerateColumns="true"
        GridLines="None" RowStyle-BackColor="#EEEEEE" HeaderStyle-BackColor="#F2DEDE"
        Width="993px">
        <Columns>
            <asp:TemplateField Visible="false">
                <ItemTemplate>
                    <asp:Label Text='<%#DataBinder.Eval(Container.DataItem,"ID") %>' ID="lblID" runat="server" />
                    </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:CheckBox ID="chkID" runat="server" />
                </ItemTemplate>
            </asp:TemplateField>
<%--            <asp:BoundField DataField="Date" HeaderText="Date" />
            <asp:BoundField DataField="Type" HeaderText="Type" />
            <asp:BoundField DataField="AccountNo" HeaderText="Account No" />--%>
        </Columns>
    </asp:GridView>
    </div>
    <div style="float: left; margin-top: 20px; margin-left: 5px">
        <asp:CheckBox ID="CheckSelectAll" runat="server" Text="&nbsp;&nbsp;Select All" AutoPostBack="true" />
    </div>
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <div>
        <asp:Button ID="btnGenerate" runat="server" Text="Generate Flat File" CssClass="btn btn-success" OnClick="btnGenerate_Click" />
    </div>

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
