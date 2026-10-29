<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FilmShootingPrint.aspx.cs" Inherits="UI_TSiPASS_FilmShootingPrint" %>

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
                                                                                        ForeColor="White">FILMSHOOTING DEVELOPMENT CORPORATION</asp:Label>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td style="padding: 5px; margin: 5px" valign="top">
                                                                                    <table border="2" style="font-family: Verdana; font-size: small;" width="100%">
                                                                                        
                                                                                       
                                                                                        <tr>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left; font-weight: bold" valign="top">1.
                                                                                            </td>
                                                                                            <td colspan="8" style="font: bold; background-color: cornflowerblue; font-weight: bold" valign="top"><b>Production Details</b></td>
                                                                                        </tr>
                                                                                         <tr>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">&nbsp;</td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                                                                Name of the Production Agency / Company
                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px; vertical-align: text-top;" valign="top">:
                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;" valign="top">
                                                                                                <asp:Label ID="lblproductionagencname" runat="server"></asp:Label>
                                                                                            </td>
                                                                                        </tr>
                                                                                         <tr>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">&nbsp;</td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                                                                Company GSTN
                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px; vertical-align: text-top;" valign="top">:
                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;" valign="top">
                                                                                                <asp:Label ID="lblcompGSTN" runat="server"></asp:Label>
                                                                                            </td>
                                                                                        </tr>

                                                                                        <tr>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top"></td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                                                                District

                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px" valign="top">:
                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                                                                <asp:Label ID="lblAgency_district" runat="server"></asp:Label>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top"></td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                                                                Mandal

                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px" valign="top">:
                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                                                                <asp:Label ID="lblAgency_mandal" runat="server"></asp:Label>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top"></td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                                                                Village

                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px" valign="top">:
                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                                                                <asp:Label ID="lblAgency_village" runat="server"></asp:Label>
                                                                                            </td>
                                                                                        </tr>
                                                                                        
                                                                                        <tr>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top"></td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                                                                Plot Number

                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px" valign="top">:
                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                                                                <asp:Label ID="lblAgency_plotno" runat="server"></asp:Label>
                                                                                            </td>
                                                                                        </tr>
                                                                                         <tr>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top"></td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                                                                PINCODE

                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px" valign="top">:
                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                                                                <asp:Label ID="lblAgency_pincode" runat="server"></asp:Label>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left; font-weight: bold" valign="top">&nbsp;</td>
                                                                                            <td colspan="8" style="background-color: cornflowerblue;" valign="top"><b>TemporaryAddressDetails</b></td>
                                                                                        </tr>
                                                                                                                                                                                 <tr>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top"></td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                                                                District

                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px" valign="top">:
                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                                                                <asp:Label ID="lbltempdist" runat="server"></asp:Label>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top"></td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                                                                Mandal

                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px" valign="top">:
                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                                                                <asp:Label ID="lbltempmandal" runat="server"></asp:Label>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top"></td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                                                                Village

                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px" valign="top">:
                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                                                                <asp:Label ID="lbltempvillage" runat="server"></asp:Label>
                                                                                            </td>
                                                                                        </tr>
                                                                                        
                                                                                        <tr>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top"></td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                                                                Plot Number

                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px" valign="top">:
                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                                                                <asp:Label ID="lbltempplotno" runat="server"></asp:Label>
                                                                                            </td>
                                                                                        </tr>
                                                                                         <tr>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top"></td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                                                                PINCODE

                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px" valign="top">:
                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                                                                <asp:Label ID="lbltemppincode" runat="server"></asp:Label>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top"></td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                                                                Agency Phone No 1

                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px" valign="top">:
                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                                                                <asp:Label ID="lblagencyphoneno1" runat="server"></asp:Label>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top"></td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                                                                Agency Phone No 2

                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px" valign="top">:
                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                                                                <asp:Label ID="lblagencyphoneno2" runat="server"></asp:Label>
                                                                                            </td>
                                                                                        </tr>
                                                                                                                                                                                <tr>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left; font-weight: bold" valign="top">2.
                                                                                            </td>
                                                                                            <td colspan="8" style="font: bold; background-color: cornflowerblue; font-weight: bold" valign="top"><b>Producer Details</b></td>
                                                                                        </tr>
                                                                                         <tr>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">&nbsp;</td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                                                                Name of the Producer
                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px; vertical-align: text-top;" valign="top">:
                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;" valign="top">
                                                                                                <asp:Label ID="lblproducername" runat="server"></asp:Label>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top"></td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                                                                District

                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px" valign="top">:
                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                                                                <asp:Label ID="lbldistrict_producer" runat="server"></asp:Label>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top"></td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                                                                Mandal

                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px" valign="top">:
                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                                                                <asp:Label ID="lblmandal_producer" runat="server"></asp:Label>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top"></td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                                                                Village

                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px" valign="top">:
                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                                                                <asp:Label ID="lblvillage_producer" runat="server"></asp:Label>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top"></td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                                                                Plot Number

                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px" valign="top">:
                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                                                                <asp:Label ID="lblplotno_producer" runat="server"></asp:Label>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top"></td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                                                                PINCODE

                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px" valign="top">:
                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                                                                <asp:Label ID="lblpincode_producer" runat="server"></asp:Label>
                                                                                            </td>
                                                                                        </tr>
                                                                                         <tr>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top"></td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                                                                Producer Phone No 1

                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px" valign="top">:
                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                                                                <asp:Label ID="lblproducerphno1" runat="server"></asp:Label>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top"></td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                                                                Producer Phone No 2

                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px" valign="top">:
                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                                                                <asp:Label ID="lblprodcerphno2" runat="server"></asp:Label>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top"></td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                                                                Producer Email Id

                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px" valign="top">:
                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                                                                <asp:Label ID="lblemailid" runat="server"></asp:Label>
                                                                                            </td>
                                                                                        </tr>
                                                                                         <tr>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">&nbsp;</td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                                                                Whether a member of any Trade-body</td>
                                                                                            <td style="padding: 5px; margin: 5px" valign="top">:
                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                                                                <asp:Label ID="lbltradebody" runat="server"></asp:Label>
                                                                                            </td>
                                                                                        </tr>
                                                                                         <tr id="trtradebodydetails" runat="server" visible="false">
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">&nbsp;</td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                                                                Trade Body Details</td>
                                                                                            <td style="padding: 5px; margin: 5px" valign="top">:
                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                                                                <asp:Label ID="lbltradebodydetails" runat="server"></asp:Label>
                                                                                            </td>
                                                                                        </tr>
                                                                                         <tr>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">&nbsp;</td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                                                                Title of the Film</td>
                                                                                            <td style="padding: 5px; margin: 5px" valign="top">:
                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                                                                <asp:Label ID="lblfilmtitle" runat="server"></asp:Label>
                                                                                            </td>
                                                                                        </tr>
                                                                                         <tr>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">&nbsp;</td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                                                                Language</td>
                                                                                            <td style="padding: 5px; margin: 5px" valign="top">:
                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                                                                <asp:Label ID="lbllanguage" runat="server"></asp:Label>
                                                                                            </td>
                                                                                        </tr>
                                                                                         <tr id="trotherlangage" runat="server" visible="false">
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">&nbsp;</td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                                                                OtherLanguage</td>
                                                                                            <td style="padding: 5px; margin: 5px" valign="top">:
                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                                                                <asp:Label ID="lblotherlanage" runat="server"></asp:Label>
                                                                                            </td>
                                                                                        </tr>
                                                                                         <tr>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">&nbsp;</td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                                                                Type of Film</td>
                                                                                            <td style="padding: 5px; margin: 5px" valign="top">:
                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                                                                <asp:Label ID="lblfilmtype" runat="server"></asp:Label>
                                                                                            </td>
                                                                                        </tr>
                                                                                         <tr id="trotherfilmtype" runat="server" visible="false">
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">&nbsp;</td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                                                                Other Type of Film</td>
                                                                                            <td style="padding: 5px; margin: 5px" valign="top">:
                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                                                                <asp:Label ID="lblothertype" runat="server"></asp:Label>
                                                                                            </td>
                                                                                        </tr>
                                                                                         <tr>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">&nbsp;</td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                                                                Shooting Time

                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px" valign="top">:
                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                                                                <asp:Label ID="lblshootingggTime" runat="server"></asp:Label>
                                                                                            </td>
                                                                                        </tr>
                                                                                         <tr>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">&nbsp;</td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                                                                Director</td>
                                                                                            <td style="padding: 5px; margin: 5px" valign="top">:
                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                                                                <asp:Label ID="lbldirector" runat="server"></asp:Label>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">&nbsp;</td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">Cameraman</td>
                                                                                            <td style="padding: 5px; margin: 5px" valign="top">: </td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                                                                <asp:Label ID="lblcameraman" runat="server"></asp:Label>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">&nbsp;</td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">Main Artists</td>
                                                                                            <td style="padding: 5px; margin: 5px" valign="top">: </td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                                                                <asp:Label ID="lblmainartists" runat="server"></asp:Label>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">&nbsp;</td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">Total Crew Number</td>
                                                                                            <td style="padding: 5px; margin: 5px" valign="top">: </td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                                                                <asp:Label ID="lblcrewno" runat="server"></asp:Label>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">&nbsp;</td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">Proposed shooting Schedule in detail</td>
                                                                                            <td style="padding: 5px; margin: 5px" valign="top">: </td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                                                                <asp:Label ID="lblscheduledetails" runat="server"></asp:Label>
                                                                                            </td>
                                                                                        </tr>
                                                                                         <tr>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">&nbsp;</td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">Applicant Name</td>
                                                                                            <td style="padding: 5px; margin: 5px" valign="top">: </td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                                                                <asp:Label ID="lblapplicantname" runat="server"></asp:Label>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">&nbsp;</td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">Application Mobile Number</td>
                                                                                            <td style="padding: 5px; margin: 5px" valign="top">: </td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                                                                <asp:Label ID="lblapplicantmobileno" runat="server"></asp:Label>
                                                                                            </td>
                                                                                        </tr>
                                                                                         <tr>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">&nbsp;</td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                                                                Location Name</td>
                                                                                            <td style="padding: 5px; margin: 5px; vertical-align: text-top;" valign="top">:
                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;" valign="top">
                                                                                                <asp:Label ID="lbllocationname" runat="server"></asp:Label>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top"></td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                                                                From Date

                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px" valign="top">:
                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                                                                <asp:Label ID="lblfromdate" runat="server"></asp:Label>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top"></td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                                                                To Date</td>
                                                                                            <td style="padding: 5px; margin: 5px" valign="top">:
                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                                                                <asp:Label ID="lbltodate" runat="server"></asp:Label>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top"></td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                                                                Blocking Days</td>
                                                                                            <td style="padding: 5px; margin: 5px" valign="top">:
                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                                                                <asp:Label ID="lblblockingdays" runat="server"></asp:Label>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top"></td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                                                                Shooting Days</td>
                                                                                            <td style="padding: 5px; margin: 5px" valign="top">:
                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                                                                <asp:Label ID="lblshootingdays" runat="server"></asp:Label>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top"></td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                                                                No of Police Persions Reqired</td>
                                                                                            <td style="padding: 5px; margin: 5px" valign="top">:
                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                                                                <asp:Label ID="lblnoofpolicepersions" runat="server"></asp:Label>
                                                                                            </td>
                                                                                        </tr>
                                                                                         <tr>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top"></td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                                                                Price Per Location</td>
                                                                                            <td style="padding: 5px; margin: 5px" valign="top">:
                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                                                                <asp:Label ID="lblpriceperlocation" runat="server"></asp:Label>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top"></td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                                                                Shooting Fee</td>
                                                                                            <td style="padding: 5px; margin: 5px" valign="top">:
                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                                                                <asp:Label ID="lblshootingfee" runat="server"></asp:Label>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top"></td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                                                                Caution Deposit</td>
                                                                                            <td style="padding: 5px; margin: 5px" valign="top">:
                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                                                                <asp:Label ID="lblcationdeposit" runat="server"></asp:Label>
                                                                                            </td>
                                                                                        </tr>
                                                                                         <tr>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">&nbsp;</td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                                                                Service Fee</td>
                                                                                            <td style="padding: 5px; margin: 5px" valign="top">:
                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                                                                <asp:Label ID="lblservicefee" runat="server"></asp:Label>
                                                                                            </td>
                                                                                        </tr>
                                                                                         <tr id="tr1" runat="server" visible="false">
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">&nbsp;</td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                                                                Police Fee</td>
                                                                                            <td style="padding: 5px; margin: 5px" valign="top">:
                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                                                                <asp:Label ID="lblpolicefee" runat="server"></asp:Label>
                                                                                            </td>
                                                                                        </tr>
                                                                                         <tr>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">&nbsp;</td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                                                                GST</td>
                                                                                            <td style="padding: 5px; margin: 5px" valign="top">:
                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                                                                <asp:Label ID="lblgst" runat="server"></asp:Label>
                                                                                            </td>
                                                                                        </tr>
                                                                                         <tr>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">&nbsp;</td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                                                                Extra Hours Amount</td>
                                                                                            <td style="padding: 5px; margin: 5px" valign="top">:
                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                                                                <asp:Label ID="lblextrahorsamount" runat="server"></asp:Label>
                                                                                            </td>
                                                                                        </tr>
                                                                                         <tr id="tr2" runat="server" visible="false">
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">&nbsp;</td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                                                                Total Amont</td>
                                                                                            <td style="padding: 5px; margin: 5px" valign="top">:
                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                                                                <asp:Label ID="lbltotalamont" runat="server"></asp:Label>
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


