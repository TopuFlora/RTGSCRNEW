<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="FloraSoft.Login" %>
<%--<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title> Please login</title>
    <link href= "includes/sitec.css" type="text/css" rel="stylesheet"/>
</head>
<body  >
    <form id="form1" method="post"  runat="server" defaultbutton="LoginBtn" defaultfocus="UserName">
            <br>
            <br>
			<br>
			<br>
			<br>
    <center>
     <table cellpadding="0" cellspacing="0" border="0"
            style="BACKGROUND-IMAGE: url(Images/ABCBankLogin.gif);" >
					<tr height="155">
						<td width="170"></td>
						<td width="130"></td>
						<td width="110"></td>
					</tr>
					<tr height="20">
						<td></td>
						<td><asp:TextBox id="UserName"  Text=""  CssClass="inputlt" Columns="9"  width="130"  runat="server" /></td>
						<td>
						    <asp:RequiredFieldValidator id="RequiredFieldValidator1" 
						    runat="server" ControlToValidate="UserName" 
						    CssClass="NormalRed" 
                            ErrorMessage="*" Display="dynamic">
                            </asp:RequiredFieldValidator>
                         </td>
					</tr>
					<tr height="20">
						<td></td>
						<td><asp:TextBox id="Pass" Text="" width="130" Columns="19"  CssClass="inputlt"  textmode="Password" runat="server" /></td>
						<td>
						    <asp:RequiredFieldValidator id="RequiredFieldValidator2" 
						    runat="server" ControlToValidate="Pass" 
						    CssClass="NormalRed"  
                            ErrorMessage="*" Display="dynamic">
                            </asp:RequiredFieldValidator>
                        </td>
					</tr>
					<tr height="33">
						<td></td>
						<td align ="right" valign="bottom"><asp:LinkButton ID="LoginBtn" CssClass="CommandButton" Runat="server" Text="Sign In " Width="80" OnClick="Login_Click" ></asp:LinkButton></td>
						<td></td>
					</tr>
					<tr height="30">
					    <td></td>
                        <td colspan="3"><asp:Label ID="MyMessage" ForeColor="Red" CssClass ="NormalRed" runat="server"></asp:Label></td>
                        <td></td>
                    </tr>
    </table>
    <asp:HiddenField ID="Tried" Value="" runat="server" />
    </center>
    </form>
</body>
</html>--%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login Page</title>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <meta http-equiv="Cache-Control" content="no-cache, no-store, must-revalidate" />
    <meta http-equiv="Refresh" content="60000;url=LogOut.aspx" />
    <meta http-equiv="PRAGMA" content="NO-CACHE"/>
    <link href="Content/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <!-- Style CSS -->
    <link href="Includes/Site.css" rel="stylesheet" />
    <style type="text/css">
        h3 {
            font-size: 18px;
            top: 0px;
            left: 0px;
        }

        h3 {
            letter-spacing: 0px;
            font-weight: normal;
            position: relative;
            padding: 0 0 0px 0;
            font-weight: normal;
            font-family: "Helvetica Neue",Helvetica,Arial,sans-serif;
            line-height: 0% !important;
            color: #01090c;
        }

        h3 {
            margin-top: 20px;
            margin-bottom: 10px;
        }

        .pull-right {
            float: right;
        }

        .input-group .form-control:last-child, .input-group-addon:last-child, .input-group-btn:last-child > .btn, .input-group-btn:last-child > .dropdown-toggle, .input-group-btn:first-child > .btn:not(:first-child) {
            border-bottom-left-radius: 0;
            border-top-left-radius: 0;
        }
        .form-control {}
    </style>
</head>
<body style="background-image: url(Images/bg_2.png); background-color: rgba(255, 255, 255, 0);">
    <form id="form1" method="post" runat="server" defaultbutton="LoginBtn" defaultfocus="UserName">
        <div class="row">
            <div class="col-md-12">
                <div class="login">
                    <div class="main-login col-md-4 col-md-offset-4">
                        <div class="loginback">

                            <!-- start: LOGIN BOX -->
                            <div id="Div1" class="box-login" runat="server">
                                <div style="text-align: center">
                                    <div>
                                        <img alt="logo" src="images/logo.png " style="max-width: 200px" />
                                    </div>
                                    <h3>HSBC RTGS Charge Module</h3>

                                </div>
                                <asp:HiddenField ID="HiddenField1" runat="server" />
                                <fieldset style="height: 120px; width: 1035px; margin-left: 100px; margin-top: 30px;">
                                    <div style="width: 240px; height: 90px; margin-left: 381px">
                                        <div style="float: left; width: 330px; margin-top: 30px;">
                                            <div style="float: left; width: 90px">
                                                <label for="UserName" class="control-label">User Name:</label>
                                            </div>
                                            <div style="float: left">
                                                <asp:TextBox ID="UserName" autocomplete="off" placeholder="Login ID" CssClass="form-control" runat="server" Width="155px" />
                                            </div>
                                            <div style="float: left">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="UserName" CssClass="NormalRed" ErrorMessage="*" Display="dynamic" />
                                            </div>
                                            <div style="clear: both"></div>
                                        </div>
                                        <div style="float: left; margin-top: 15px; margin-bottom: 15px; margin-right: 0px; width: 321px;">
                                            <div style="float: left; width: 90px">
                                                <label for="UserName" class="control-label">Password :</label>
                                            </div>
                                            <div style="float: left">
                                                <asp:TextBox ID="Pass" CssClass="form-control" autocomplete="off" placeholder="Password" TextMode="Password" runat="server" Width="158px" />
                                            </div>
                                            <div style="float: left">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="Pass" CssClass="NormalRed" ErrorMessage="*" Display="dynamic" />
                                            </div>
                                            <div style="float: left">
                                                <asp:LinkButton ID="LoginBtn" CssClass="btn btn-danger marginleft10" runat="server" Text="Sign In " OnClick="Login_Click"></asp:LinkButton>
                                            </div>
                                            <asp:Label ID="MyMessage" ForeColor="Red" CssClass="NormalRed" runat="server"></asp:Label>
                                            <br />
                                            <asp:HiddenField ID="Tried" Value="" runat="server" />
                                        </div>
                                    </div>



                                    <asp:Panel CssClass="errorHandler alert alert-danger no-display" ID="pnlLoginMessage" runat="server">
                                        <span class="glyphicon glyphicon-asterisk" aria-hidden="true"></span>
                                        <asp:Label ID="lblLoginMessage" runat="server"></asp:Label>
                                    </asp:Panel>


                                </fieldset>
                                <div style="text-align: center">
                                    <p>Powered by <span><a href="http://www.floralimited.com" style="color: Red">Flora Limited</a></span></p>
                                </div>

                            </div>
                            <!-- end: LOGIN BOX -->

                        </div>

                    </div>
                </div>
            </div>

        </div>
       <%-- </div>--%>
    </form>
    <script src="Scripts/modernizr-2.6.2.js" type="text/javascript"></script>
    <script src="Scripts/html5.js" type="text/javascript"></script>
    <script src="Scripts/respond.min.js" type="text/javascript"></script>
    <script src="Scripts/jquery-1.4.1.min.js" type="text/javascript"></script>

</body>
</html>
