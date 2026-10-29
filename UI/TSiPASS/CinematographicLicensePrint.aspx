<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CinematographicLicensePrint.aspx.cs" Inherits="UI_TSiPASS_CinematographicLicensePrint" %>



<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Telangana Tourism</title>
    <meta charset="UTF-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <%--Added by Pramod--%>
    <link rel="stylesheet" href="../../AssetsNew/css/font-awesome.min.css" />
    <link rel="stylesheet" href="../../AssetsNew/css/bootstrap.min.css" />
    <link rel="stylesheet" href="../../AssetsNew/css/style.css" />
    <link rel="stylesheet" href="../../AssetsNew/css/media.css" />

    <style>
        .main {
            min-height: 595px;
            min-height: 75.4vh;
            background: #f3f8ff;
        }

        #collapsibleNavbar .navbar-nav.d-flex.w-50.m-auto {
            margin: 0px !important;
        }
    </style>
    <script src="../../Resource/Scripts/js/validations.js" type="text/javascript"></script>
    <script type="text/javascript">
        function CallPrint(strid) {
            var prtContent = document.getElementById(strid);
            var WinPrint = window.open('', '', 'letf=0,top=0,width=0,height=0,toolbar=0,scrollbars=1,status=0');
            var strOldOne = prtContent.innerHTML;
            WinPrint.document.write(prtContent.innerHTML);
            WinPrint.document.close();
            WinPrint.focus();
            WinPrint.print();
            WinPrint.close();
            prtContent.innerHTML = strOldOne;
        }
    </script>
    <style>
        .div3 {
            /*-webkit-column-count: 3;
    -moz-column-count: 3; 
    column-count: 3; */
            -webkit-column-gap: 40px; /* Chrome, Safari, Opera */
            -moz-column-gap: 40px; /* Firefox */
            column-gap: 40px;
        }

        .w3-code {
            border-left: 5px solid #73AD21 !important;
            font-size: 17px;
            padding: 5px;
            font-weight: bold;
            color: #082ea2;
        }

        .w4-code {
            border-left: 5px solid #73AD21 !important;
            font-size: 14px;
            padding: 5px;
            font-weight: bold;
            color: #082ea2;
        }

        ol.u {
            list-style-type: none;
            ;
            font-size: 13px;
            padding: 10px 10px 10px 10px;
        }

        ol.v {
            list-style-type: inherit;
            font-size: 17px;
            font-weight: bold;
            padding: 10px 10px 10px 10px;
        }

        .table {
            border-collapse: collapse;
            width: 100%;
        }

        th, td {
            text-align: left;
            padding: 8px;
            margin-left: 80px;
        }

        </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="main">
            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
            <div id="content">
                <div class="row" runat="server" id="div_successfully">
                    <div class="col-sm-12 text-blue font-SemiBold text-center" runat="server" visible="true">
                        
                    </div>
                </div>
                <div id="Divdraftdivmain" runat="server">
                    <div class="w-100 px-3 frm-form box-content py-3 font-medium title5">
                        <div class="widget-content nopadding" id="recipet" runat="server">
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>
                                    <table align="center" cellpadding="10" cellspacing="5" style="width: 90%">
                                        <tr>
                                            <td align="left" style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                <div align="center" id="Receipt" runat="server">
                                                    <table style="width: 800px">
                                                        <tr>
                                                            <td align="center" class="style8" style="padding: 5px; margin: 5px; text-align: center;"
                                                                valign="top">&nbsp;
                                                <img src="../../images/karlogo.png" width="75px" height="75px" />
                                                            </td>
                                                        </tr>
                                                        <%--<tr>
                                                            <td align="center" class="style8" style="padding: 5px; margin: 5px; text-align: center; font-size: large; font-weight: bold" valign="top">GOVERNMENT OF Telangana
         
                                                                ADVERTISEMENT
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td width="100%" align="center" style="text-align: center">
                                                                <asp:Label Font-Bold="true" Font-Size="Large" ID="lblheadTPRIDE" runat="server" Visible="false">
                                                     PERFORMANCE LICENSE
                                                                </asp:Label>
                                                            </td>
                                                        </tr>--%>
                                                       
                                                        <tr>
                                                            <td>
                                                                <div align="center" id="divCommonAppli" runat="server">
                                                                    <div align="center">
                                                                        <table bgcolor="White" width="1000px" border="2"
                                                                            style="font-family: Verdana; font-size: small;">
                                                                            <tr>
                                                                                <td align="center" colspan="4"
                                                                                    style="text-align: center; background-color: #0066FF; color: #FFFFFF; font-size: large; font-weight: bold;">
                                                                                    <asp:Label ID="Label8" runat="server" Font-Bold="True" Font-Size="18px"
                                                                                        ForeColor="White">CINEMATOGRAPHIC LICENSE</asp:Label>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td style="padding: 5px; margin: 5px" valign="top">
                                                                                    <table border="2" style="font-family: Verdana; font-size: small;" width="100%">
                                                                                        
                                                                                       
                                                                                        <tr>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left; font-weight: bold" valign="top">1.
                                                                                            </td>
                                                                                            <td colspan="8" style="font: bold; background-color: cornflowerblue; font-weight: bold" valign="top">Applicant Details 
                                                                                            </td>
                                                                                        </tr>
                                                                                         <tr>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">&nbsp;</td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                                                                <b>a.Applicant Full Name</b>
                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px; vertical-align: text-top;" valign="top">:
                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;" valign="top">
                                                                                                <asp:Label ID="lbl_applicantname" runat="server"></asp:Label>
                                                                                            </td>
                                                                                        </tr>
                                                                                        
                                                                                        
                                                                                        <tr>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top"></td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                                                                <b>b.District:</b>

                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px" valign="top">:
                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                                                                <asp:Label ID="lbl_district" runat="server"></asp:Label>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top"></td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                                                                <b>c.Mandal:</b>

                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px" valign="top">:
                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                                                                <asp:Label ID="lbl_mandal" runat="server"></asp:Label>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top"></td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                                                                <b>d.Village:</b>

                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px" valign="top">:
                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                                                                <asp:Label ID="lbl_village" runat="server"></asp:Label>
                                                                                            </td>
                                                                                        </tr>
                                                                                        
                                                                                        <tr>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top"></td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                                                                <b>e.Plot Number:</b>

                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px" valign="top">:
                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                                                                <asp:Label ID="lbl_plotno" runat="server"></asp:Label>
                                                                                            </td>
                                                                                        </tr>
                                                                                         <tr>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top"></td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                                                                <b>f.PINCODE:</b>

                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px" valign="top">:
                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                                                                <asp:Label ID="lblpincode" runat="server"></asp:Label>
                                                                                            </td>
                                                                                        </tr>

                                                                                         
                                                                                         <tr>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">2&nbsp;</td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                                                                Status and previous experience of the Applicant</td>
                                                                                            <td style="padding: 5px; margin: 5px" valign="top">:
                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                                                                <asp:Label ID="lblstatusandexperience" runat="server"></asp:Label>
                                                                                            </td>
                                                                                        </tr>
                                                                                         <tr>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">3</td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                                                                9B File Number of the building granted</td>
                                                                                            <td style="padding: 5px; margin: 5px" valign="top">:
                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                                                                <asp:Label ID="lbl9bfileno" runat="server"></asp:Label>
                                                                                            </td>
                                                                                        </tr>
                                                                                         <tr>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">4</td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                                                                Date of the Reference in which permission for construction of the building granted</td>
                                                                                            <td style="padding: 5px; margin: 5px" valign="top">:
                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                                                                <asp:Label ID="lblbyildingreferancedate" runat="server"></asp:Label>
                                                                                            </td>
                                                                                        </tr>
                                                                                         <tr>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">5</td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                                                                The Date upto which the certificate of longevity of the building issued by the executive engineer (R&amp;B) is valid</td>
                                                                                            <td style="padding: 5px; margin: 5px" valign="top">:
                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                                                                <asp:Label ID="lbllongevitydate" runat="server"></asp:Label>
                                                                                            </td>
                                                                                        </tr>
                                                                                         <tr>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">6</td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                                                                The date upto which the Electrical certificate in form -D is Valid

                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px" valign="top">:
                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                                                                <asp:Label ID="lblelectricalcertificatedate" runat="server"></asp:Label>
                                                                                            </td>
                                                                                        </tr>
                                                                                         <tr>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">7&nbsp;</td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                                                                The period for which the license has to be granted</td>
                                                                                            <td style="padding: 5px; margin: 5px" valign="top">:
                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                                                                <asp:Label ID="lblnocfiredate" runat="server"></asp:Label>
                                                                                            </td>
                                                                                        </tr>
                                                                                         
                                                                                         <tr>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left; font-weight: bold" valign="top">8.
                                                                                            </td>
                                                                                            <td colspan="8" style="font: bold; background-color: cornflowerblue; font-weight: bold" valign="top">Owner Details 
                                                                                            </td>
                                                                                        </tr>
                                                                                                                                                                                 <tr>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">&nbsp;</td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                                                                <b>a.Owner Name</b>
                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px; vertical-align: text-top;" valign="top">:
                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;" valign="top">
                                                                                                <asp:Label ID="lblownername" runat="server"></asp:Label>
                                                                                            </td>
                                                                                        </tr>
                                                                                        
                                                                                        
                                                                                        <tr>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top"></td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                                                                <b>b.District:</b>

                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px" valign="top">:
                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                                                                <asp:Label ID="lbldistrict_owner" runat="server"></asp:Label>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top"></td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                                                                <b>c.Mandal:</b>

                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px" valign="top">:
                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                                                                <asp:Label ID="lblmandal_owner" runat="server"></asp:Label>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top"></td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                                                                <b>d.Village:</b>

                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px" valign="top">:
                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                                                                <asp:Label ID="lblvillage_owner" runat="server"></asp:Label>
                                                                                            </td>
                                                                                        </tr>
                                                                                        
                                                                                        <tr>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top"></td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                                                                <b>e.Plot Number:</b>

                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px" valign="top">:
                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                                                                <asp:Label ID="lblplotno_owner" runat="server"></asp:Label>
                                                                                            </td>
                                                                                        </tr>
                                                                                         <tr>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top"></td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                                                                <b>f.PINCODE:</b>

                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px" valign="top">:
                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                                                                <asp:Label ID="lblpincode_owner" runat="server"></asp:Label>
                                                                                            </td>
                                                                                        </tr>
                                                                                        
                                                                                         <tr>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">9</td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                                                                The period for which the license has to be granted</td>
                                                                                            <td style="padding: 5px; margin: 5px" valign="top">:
                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                                                                <asp:Label ID="lbllicenseperiod" runat="server"></asp:Label>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">10</td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                                                                Type of Cinema Theatre</td>
                                                                                            <td style="padding: 5px; margin: 5px" valign="top">:
                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                                                                <asp:Label ID="lbltheatretype" runat="server"></asp:Label>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">11</td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                                                                Number of Screens in multiplex

                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px" valign="top">:
                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                                                                <asp:Label ID="lblnoofscreens" runat="server"></asp:Label>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">12</td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                                                                Number of shows to be proposed</td>
                                                                                            <td style="padding: 5px; margin: 5px" valign="top">:
                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                                                                <asp:Label ID="lblnoofshows" runat="server"></asp:Label>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">13</td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                                                                Commissionerate</td>
                                                                                            <td style="padding: 5px; margin: 5px" valign="top">:
                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                                                                <asp:Label ID="lblcommissionerate" runat="server"></asp:Label>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">14</td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                                                                Zone</td>
                                                                                            <td style="padding: 5px; margin: 5px" valign="top">:
                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                                                                <asp:Label ID="lblzone" runat="server"></asp:Label>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">15</td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                                                                Division</td>
                                                                                            <td style="padding: 5px; margin: 5px" valign="top">:
                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                                                                <asp:Label ID="lbldivision" runat="server"></asp:Label>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">16</td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                                                                Police Station</td>
                                                                                            <td style="padding: 5px; margin: 5px" valign="top">:
                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                                                                <asp:Label ID="lblpolicestation" runat="server"></asp:Label>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">17</td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                                                                Traffic Zone</td>
                                                                                            <td style="padding: 5px; margin: 5px" valign="top">:
                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                                                                <asp:Label ID="lbltrafficzone" runat="server"></asp:Label>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">18</td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                                                                Traffic Division</td>
                                                                                            <td style="padding: 5px; margin: 5px" valign="top">:
                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                                                                <asp:Label ID="lbltrafficdivision" runat="server"></asp:Label>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">19</td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                                                                Traffic Police Station</td>
                                                                                            <td style="padding: 5px; margin: 5px" valign="top">:
                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                                                                <asp:Label ID="lbltrafficpolicestation" runat="server"></asp:Label>
                                                                                            </td>
                                                                                        </tr>
                                                                                    </table>
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </div>
                                                                </div>
                                                            </td>
                                                        </tr>


                                                    </table>
                                                </div>
                                            </td>
                                        </tr>
                                        <tr align="center" id="trApplyAgainbtn" runat="server">
                                            <td align="center" style="padding: 5px; margin: 5px; text-align: center;" valign="middle">&nbsp;
                                                    <asp:Button ID="btnApplyAgain" runat="server" CssClass="btn btn-primary" Height="32px"
                                                        TabIndex="10" Text="Print" Width="150px" OnClientClick="javascript:CallPrint('Receipt')" />
                                            </td>
                                        </tr>
                                    </table>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                    </div>
                </div>
            </div>
        </div>

    </form>
</body>
</html>


