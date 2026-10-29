<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DrillingRigsBorewellPrint.aspx.cs" Inherits="UI_TSiPASS_DrillingRigsBorewellPrint" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
       <title>Application for Registration of Drilling Rigs / Hand boring sets</title>
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
                    <div class="col-sm-12 text-blue font-SemiBold text-center" style="text-align: center" runat="server" visible="true">
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
                                                            <td>
                                                                <div align="center" id="divCommonAppli" runat="server">
                                                                    <div align="center">
                                                                        <table bgcolor="White" width="1000px" border="2"
                                                                            style="font-family: Verdana; font-size: small;">
                                                                            <tr>
                                                                                <td align="center" colspan="4"
                                                                                    style="text-align: center; background-color: #0066FF; color: #FFFFFF; font-size: large; font-weight: bold;">
                                                                                    <b>FORM – 15</b>
                                                                                     <br />
                                                                                        <b>(See Rule 17)</b>
                                                                                     <br />
                                                                                    <b>Application for Registration of Drilling Rigs / Hand boring sets</b>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td style="padding: 5px; margin: 5px" valign="top">
                                                                                    <table border="2" style="font-family: Verdana; font-size: small;" width="100%">
                                                                                        <tr>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                                                                <b>Application Type</b>
                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px; vertical-align: text-top;" valign="top">:
                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;" valign="top">
                                                                                                <asp:Label ID="lbl_applicationtype"  runat="server"></asp:Label>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">1
                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                                                                <b>Name of the Applicant:</b>
                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px; vertical-align: text-top;" valign="top">:
                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;" valign="top">
                                                                                                <asp:Label ID="lbl_nameofapplicant" runat="server"></asp:Label>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left; font-weight: bold" valign="top">2.
                                                                                            </td>
                                                                                            <td colspan="8" style="font: bold; background-color: cornflowerblue; font-weight: bold" valign="top">Address 
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top"></td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                                                                <b>a.District </b>
                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px; vertical-align: text-top;" valign="top">:
                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;" valign="top">
                                                                                                <asp:Label ID="lbl_district" runat="server"></asp:Label>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top"></td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                                                                <b>b.Mandal</b>
                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px" valign="top">:
                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                                                                <asp:Label ID="lbl_mandal" runat="server"></asp:Label>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr runat="server" visible="false">
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top"></td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                                                                <b>c.Village</b>
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
                                                                                                <b>e.House No</b>

                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px" valign="top">:
                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                                                                <asp:Label ID="lbl_houseno" runat="server"></asp:Label>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top"></td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                                                                <b>f.Street</b>
                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px" valign="top">:
                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                                                                <asp:Label ID="lbl_streetname" runat="server"></asp:Label>
                                                                                            </td>
                                                                                        </tr>
                                                                                         <tr>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top"></td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                                                                <b>g.Contact Mobile No</b>
                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px" valign="top">:
                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                                                                <asp:Label ID="lbl_contactmobileno" runat="server"></asp:Label>
                                                                                            </td>
                                                                                        </tr>
                                                                                         <tr>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top"></td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                                                                <b>h.Contact EmailID</b>
                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px" valign="top">:
                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                                                                <asp:Label ID="lbl_contactemailId" runat="server"></asp:Label>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">3.</td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                                                                <b>Registration No. of the vehicle</b>
                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px" valign="top">:
                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                                                                <asp:Label ID="lbl_registrationvehicleno" runat="server"></asp:Label>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr id="tr_prto" runat="server" visible="false">
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">4.</td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                                                                <b>Place of registration with RTO</b>
                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px" valign="top">:
                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                                                                <asp:Label ID="lbl_placeregwithrto" runat="server"></asp:Label>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">4.</td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                                                                <b>In which District RTO registration </b>
                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px" valign="top">:
                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                                                                <asp:Label ID="lbl_RTOregistration" runat="server"></asp:Label>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">5.</td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                                                                <b>Description of the drilling rig</b>
                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px" valign="top">:
                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                                                                <asp:Label ID="lbl_Descriptionofthedrillingrig" runat="server"></asp:Label>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left; font-weight: bold" valign="top">
                                                                                            </td>
                                                                                            <td colspan="8" style="font: bold; background-color: cornflowerblue; font-weight: bold" valign="top">Capacity of Drilling 
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">6.</td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                                                                <b>Max Diameter Depth(In inchs)</b>
                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px" valign="top">:
                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                                                                <asp:Label ID="lbl_maxdiameterdepth" runat="server"></asp:Label>
                                                                                            </td>
                                                                                        </tr>

                                                                                         <tr>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">7.</td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                                                                <b>Area of operation</b>
                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px" valign="top">:
                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                                                                <asp:Label ID="lbl_Areaofoperation" runat="server"></asp:Label>
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
