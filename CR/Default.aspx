<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/CR/Site.Master" CodeBehind="Default.aspx.cs" Inherits="FloraSoft.CR.Default" %>
<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<script type="text/javascript">

    function MM_swapImgRestore() { //v3.0
        var i, x, a = document.MM_sr; for (i = 0; a && i < a.length && (x = a[i]) && x.oSrc; i++) x.src = x.oSrc;
    }
    function MM_preloadImages() { //v3.0
        var d = document; if (d.images) {
            if (!d.MM_p) d.MM_p = new Array();
            var i, j = d.MM_p.length, a = MM_preloadImages.arguments; for (i = 0; i < a.length; i++)
                if (a[i].indexOf("#") != 0) { d.MM_p[j] = new Image; d.MM_p[j++].src = a[i]; }
        }
    }

    function MM_findObj(n, d) { //v4.01
        var p, i, x; if (!d) d = document; if ((p = n.indexOf("?")) > 0 && parent.frames.length) {
            d = parent.frames[n.substring(p + 1)].document; n = n.substring(0, p);
        }
        if (!(x = d[n]) && d.all) x = d.all[n]; for (i = 0; !x && i < d.forms.length; i++) x = d.forms[i][n];
        for (i = 0; !x && d.layers && i < d.layers.length; i++) x = MM_findObj(n, d.layers[i].document);
        if (!x && d.getElementById) x = d.getElementById(n); return x;
    }

    function MM_swapImage() { //v3.0
        var i, j = 0, x, a = MM_swapImage.arguments; document.MM_sr = new Array; for (i = 0; i < (a.length - 2); i += 3)
            if ((x = MM_findObj(a[i])) != null) { document.MM_sr[j++] = x; if (!x.oSrc) x.oSrc = x.src; x.src = a[i + 2]; }
    }
    </script>
</asp:Content>
<asp:Content ContentPlaceHolderID="MainContent" runat="server">
    <h2>RTGS CHARGE MODULE DASHBOARD</h2>
    <hr />    
    <div>
        <table cellpadding="20px" cellspacing="15px" style="margin-left: 100px; text-align: center">
            <tr>
                <td>
                    <a href="StandardCharge.aspx" onmouseout="MM_swapImgRestore()" onmouseover="MM_swapImage('Image10','','images/DefaultFMIconHover.gif',1)">
                        <img src="images/DefaultFMIconNormal.gif" alt="Home" name="Image10" width="115" height="104"
                            border="0" id="Image10" /></a>
                    <br />
                    <a class="modulelink" href="StandardCharge.aspx">Standard Charge</a>
                </td>
                <td>
                    <a href="SpecialCharge.aspx" onmouseout="MM_swapImgRestore()" onmouseover="MM_swapImage('Image6','','images/DefaultPSDIIconHover.gif',1)">
                        <img src="../CR/images/DefaultPSDIIconNormal.gif" alt="Home" name="Image6" width="115"
                            height="104" border="0" id="Img7" /></a>
                    <br />
                    <a class="modulelink" href="SpecialCharge.aspx">Special Charge</a>
                </td>
                <td>
                    <a href="WaivedCharge.aspx" onmouseout="MM_swapImgRestore()" onmouseover="MM_swapImage('Image6','','images/DefaultMSIconlHover.gif',1)">
                        <img src="images/DefaultMSIconlNormal.gif" alt="Home" name="Image6" width="115"
                            height="104" border="0" id="Img1" /></a>
                    <br />

                    <a class="modulelink" href="WaivedCharge.aspx">Waived Charge</a>
                </td>

                <td>
                    <a href="GenerateFlatFile.aspx" onmouseout="MM_swapImgRestore()" onmouseover="MM_swapImage('Image6','','images/FlatFile.gif',1)">
                        <img src="images/FlatFile.gif" alt="Home" name="FlatFile" width="115"
                            height="104" border="0" id="Img1" /></a>
                    <br />

                    <a class="modulelink" href="GenerateFlatFile.aspx">Flat File Generate</a>
                </td>
                <td>
                    <a href="Search.aspx" onmouseout="MM_swapImgRestore()" onmouseover="MM_swapImage('Image9','','images/DefaultSMIconlHover.gif',1)">
                        <img src="../CR/images/DefaultSMIconNormal.gif" alt="Home" name="Image9" width="115"
                            height="104" border="0" id="Image9" /></a>
                    <br />
                    <a class="modulelink" href="Search.aspx">Reports</a>
                </td>  
                
                <td>
                    <a href="FileUpload.aspx" onmouseout="MM_swapImgRestore()" onmouseover="MM_swapImage('Image9','','images/DefaultSMIconlHover.gif',1)">
                        <img src="../CR/images/DefaultSMIconNormal.gif" alt="Home" name="Image9" width="115"
                            height="104" border="0" id="Img2" /></a>
                    <br />
                    <a class="modulelink" href="FileUpload.aspx">Response</a>
                </td>              
            </tr>
        </table>
    </div>
    </asp:Content>