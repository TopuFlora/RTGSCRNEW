<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ChargeReports.aspx.cs" MasterPageFile="~/CR/Site.Master" 
    Inherits="FloraSoft.CR.ChargeReports" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h4>Charge Report</h4>
    <hr />  
        <table style="margin-bottom: 0px">
            <tr>
                <td class="style29">
                    &nbsp;
                </td>
                <td class="style30" align="left">
                    <br />
                    <asp:DropDownList ID="ddlReportList" runat="server" AutoPostBack="True" 
                        Font-Bold="True" Style="margin-top: 0px" 
                        onselectedindexchanged="ddlReportList_SelectedIndexChanged">
                        <asp:ListItem Value="-1">[Select Report]</asp:ListItem>
                        <asp:ListItem Value="0">Collected Charge Report</asp:ListItem>
                        <asp:ListItem Value="1">Uncollected Charge Report</asp:ListItem>
                        <asp:ListItem Value="2">Bank Contribution Report</asp:ListItem>
              
                    </asp:DropDownList>
                    <asp:DropDownList ID="ddlReportCriteria" runat="server" 
                        onselectedindexchanged="ddlReportCriteria_SelectedIndexChanged" 
                        AutoPostBack="True" >
                        <asp:ListItem Value="-1">[Select Report Criteria]</asp:ListItem>
                        <asp:ListItem Value="0">Customer Wise</asp:ListItem>
                        <asp:ListItem Value="1">Day Wise</asp:ListItem>
                    </asp:DropDownList>
                    AC NO:
                    <asp:TextBox ID="txtAcNo"
                     runat="server"></asp:TextBox>
                </td>
                <td class="style30" align="left">
                </td>
                <td class="style34">
                    <asp:Label ID="lblMessage" runat="server" ></asp:Label>
                </td>
                <td class="style33">
                </td>
            </tr>
            <tr>
        <td>
        </td>
        <td class="style16">
            Year
                &nbsp;
                <asp:DropDownList ID="ddlYear" runat="server" Height="21px" Width="56px">
                    <asp:ListItem Value="-1">Year</asp:ListItem>
                    <asp:ListItem Value="2013">2015</asp:ListItem>
                    <asp:ListItem Value="2013">2016</asp:ListItem>
                </asp:DropDownList>
                &nbsp;Moth<asp:DropDownList ID="ddlMonth" runat="server" Height="24px" Width="51px">
                    <asp:ListItem Value="-1">Month</asp:ListItem>
                    <asp:ListItem Value="01">01</asp:ListItem>
                    <asp:ListItem Value="02">02</asp:ListItem>
                    <asp:ListItem Value="03">03</asp:ListItem>
                    <asp:ListItem Value="04">04</asp:ListItem>
                    <asp:ListItem Value="05">05</asp:ListItem>
                    <asp:ListItem Value="06">06</asp:ListItem>
                    <asp:ListItem Value="07">07</asp:ListItem>
                    <asp:ListItem Value="08">08</asp:ListItem>
                    <asp:ListItem Value="09">09</asp:ListItem>
                    <asp:ListItem Value="10">10</asp:ListItem>
                    <asp:ListItem Value="11">11</asp:ListItem>
                    <asp:ListItem Value="12">12</asp:ListItem>
                </asp:DropDownList>
                From<asp:DropDownList ID="ddlDayFrom" runat="server" Height="22px" Width="49px">
                    <asp:ListItem Value="-1">Day</asp:ListItem>
                    <asp:ListItem Value="01">01</asp:ListItem>
                    <asp:ListItem Value="02">02</asp:ListItem>
                    <asp:ListItem Value="03">03</asp:ListItem>
                    <asp:ListItem Value="04">04</asp:ListItem>
                    <asp:ListItem Value="05">05</asp:ListItem>
                    <asp:ListItem Value="06">06</asp:ListItem>
                    <asp:ListItem Value="07">07</asp:ListItem>
                    <asp:ListItem Value="08">08</asp:ListItem>
                    <asp:ListItem Value="09">09</asp:ListItem>
                    <asp:ListItem Value="10">10</asp:ListItem>
                    <asp:ListItem Value="11">11</asp:ListItem>
                    <asp:ListItem Value="12">12</asp:ListItem>
                    <asp:ListItem Value="13">13</asp:ListItem>
                    <asp:ListItem Value="14">14</asp:ListItem>
                    <asp:ListItem Value="15">15</asp:ListItem>
                    <asp:ListItem Value="16">16</asp:ListItem>
                    <asp:ListItem Value="17">17</asp:ListItem>
                    <asp:ListItem Value="18">18</asp:ListItem>
                    <asp:ListItem Value="19">19</asp:ListItem>
                    <asp:ListItem Value="20">20</asp:ListItem>
                    <asp:ListItem Value="21">21</asp:ListItem>
                    <asp:ListItem Value="22">22</asp:ListItem>
                    <asp:ListItem Value="23">23</asp:ListItem>
                    <asp:ListItem Value="24">24</asp:ListItem>
                    <asp:ListItem Value="25">25</asp:ListItem>
                    <asp:ListItem Value="26">26</asp:ListItem>
                    <asp:ListItem Value="27">27</asp:ListItem>
                    <asp:ListItem Value="28">28</asp:ListItem>
                    <asp:ListItem Value="29">29</asp:ListItem>
                    <asp:ListItem Value="30">30</asp:ListItem>
                    <asp:ListItem Value="31">31</asp:ListItem>
                </asp:DropDownList>
                To<asp:DropDownList ID="ddlDayTo" runat="server" Height="21px" Width="51px">
                    <asp:ListItem Value="-1">Day</asp:ListItem>
                    <asp:ListItem Value="01">01</asp:ListItem>
                    <asp:ListItem Value="02">02</asp:ListItem>
                    <asp:ListItem Value="03">03</asp:ListItem>
                    <asp:ListItem Value="04">04</asp:ListItem>
                    <asp:ListItem Value="05">05</asp:ListItem>
                    <asp:ListItem Value="06">06</asp:ListItem>
                    <asp:ListItem Value="07">07</asp:ListItem>
                    <asp:ListItem Value="08">08</asp:ListItem>
                    <asp:ListItem Value="09">09</asp:ListItem>
                    <asp:ListItem Value="10">10</asp:ListItem>
                    <asp:ListItem Value="11">11</asp:ListItem>
                    <asp:ListItem Value="12">12</asp:ListItem>
                    <asp:ListItem Value="13">13</asp:ListItem>
                    <asp:ListItem Value="14">14</asp:ListItem>
                    <asp:ListItem Value="15">15</asp:ListItem>
                    <asp:ListItem Value="16">16</asp:ListItem>
                    <asp:ListItem Value="17">17</asp:ListItem>
                    <asp:ListItem Value="18">18</asp:ListItem>
                    <asp:ListItem Value="19">19</asp:ListItem>
                    <asp:ListItem Value="20">20</asp:ListItem>
                    <asp:ListItem Value="21">21</asp:ListItem>
                    <asp:ListItem Value="22">22</asp:ListItem>
                    <asp:ListItem Value="23">23</asp:ListItem>
                    <asp:ListItem Value="24">24</asp:ListItem>
                    <asp:ListItem Value="25">25</asp:ListItem>
                    <asp:ListItem Value="26">26</asp:ListItem>
                    <asp:ListItem Value="27">27</asp:ListItem>
                    <asp:ListItem Value="28">28</asp:ListItem>
                    <asp:ListItem Value="29">29</asp:ListItem>
                    <asp:ListItem Value="30">30</asp:ListItem>
                    <asp:ListItem Value="31">31</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td class="style19">
                &nbsp;
                <asp:ImageButton ID="imgBtnReportView" runat="server" BorderColor="#006666" BorderStyle="Solid"
                    BorderWidth="0px" ImageUrl="~/CR/Images/reportview.jpg" Style="margin-top: 2px"
                    ToolTip="Report Generate" Width="27px" onclick="imgBtnReportView_Click"/>
                &nbsp;<asp:ImageButton ID="imgBtnPDFReport" runat="server" ImageUrl="~/CR/Images/images.jpg"
                    Style="margin-top: 2px" ToolTip="PDF View" Width="27px" />
                &nbsp;<asp:ImageButton ID="imgBtnExlReport" runat="server" ImageUrl="~/CR/Images/excel.jpg"
                    Style="margin-top: 2px" ToolTip="PDF View" Width="27px" />
            </td>
        </tr>
    </table>

    <div>
    
     <asp:GridView ID="gvReport" runat="server"  AlternatingRowStyle-BackColor="#FFFFFF"
        AutoGenerateColumns="false" BorderWidth="0px" Height="0px" CellPadding="5" CellSpacing="1"
        GridLines="None" RowStyle-BackColor="#EEEEEE" HeaderStyle-BackColor="#F2DEDE"
        Width="993px" ItemStyle-CssClass="NormalSmall" AllowPaging="True" 
            PageSize="50">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
             <asp:BoundField DataField="CHQ-SL" HeaderText="Check SL No"  />
            <asp:BoundField DataField="Bank" HeaderText="Bank Name" />
  
            <asp:BoundField DataField="CHQ-RNo" HeaderText="Check Routing No" />
       
            <asp:BoundField DataField="CLG-Type" HeaderText="Clearing Type" />
            <asp:BoundField DataField="Date" HeaderText="Settlement Date" />
            <asp:BoundField DataField="GHO" HeaderText="GHO" />
            <asp:BoundField DataField="Amount" HeaderText="Check Amount" />
            <asp:BoundField DataField="CollectedC" HeaderText="Realization Charge Amount" />
            <asp:BoundField DataField="UnCollectedC" HeaderText="Unrealized Charge Amount" />
        </Columns>
</asp:GridView>
    
    
    </div>
   </asp:Content>