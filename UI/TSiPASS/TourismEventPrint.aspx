<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TourismEventPrint.aspx.cs" Inherits="UI_TSiPASS_TourismEventPrint" %>

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
                          TOURISM EVENTS - PERFORMANCE LICENSE  
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
                                                <img src="../../images/TG_logo_v.png" width="75px" height="75px" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="center" class="style8" style="padding: 5px; margin: 5px; text-align: center; font-size: large; font-weight: bold" valign="top">GOVERNMENT OF Telangana
                                                <br />
                                                                DRAFT QUESTIONNAIRE FOR TOURISM EVENTS - PERFORMANCE LICENSE
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td width="100%" align="center" style="text-align: center">
                                                                <asp:Label Font-Bold="true" Font-Size="Large" ID="lblheadTPRIDE" runat="server">
                                                     PERFORMANCE LICENSE
                                                                </asp:Label>
                                                            </td>
                                                        </tr>
                                                       
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
                                                                                        ForeColor="White">PERFORMANCE LICENSE</asp:Label>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td style="padding: 5px; margin: 5px" valign="top">
                                                                                    <table border="2" style="font-family: Verdana; font-size: small;" width="100%">
                                                                                        <tr>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">1
                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                                                                <b>Type of Event</b>
                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px; vertical-align: text-top;" valign="top">:
                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;" valign="top">
                                                                                                <asp:Label ID="lbl_typeofevent" runat="server"></asp:Label>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">2
                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                                                                <b>Classification of the event</b>
                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px; vertical-align: text-top;" valign="top">:
                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;" valign="top">
                                                                                                <asp:Label ID="lbl_classevent" runat="server"></asp:Label>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left; font-weight: bold" valign="top">3.
                                                                                            </td>
                                                                                            <td colspan="8" style="font: bold; background-color: cornflowerblue; font-weight: bold" valign="top">Applicant Details 
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top"></td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                                                                <b>a.Name of the applicant</b>
                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px; vertical-align: text-top;" valign="top">:
                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;" valign="top">
                                                                                                <asp:Label ID="lbl_nameofapplicant" runat="server"></asp:Label>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top"></td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                                                                <b>b.Father’s Name</b>
                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px" valign="top">:
                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                                                                <asp:Label ID="lbl_fathername" runat="server"></asp:Label>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr runat="server" visible="false">
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top"></td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                                                                <b>c.Aadhaar Card</b>
                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px" valign="top">:
                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                                                                <asp:Label ID="lbl_aadhaarcard" runat="server"></asp:Label>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top"></td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                                                                <b>c.PAN Card</b>
                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px" valign="top">:
                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                                                                <asp:Label ID="lbl_pancard" runat="server"></asp:Label>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top"></td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                                                                <b>d.Address of the applicant along with contact number:</b>

                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px" valign="top">:
                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                                                                <asp:Label ID="lbl_addressofapp" runat="server"></asp:Label>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">4.</td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                                                                <b>Name and address of the Event Management Company / Organization on whose behalf the applicant is applying for Performance License </b>
                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px" valign="top">:
                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                                                                <asp:Label ID="lbl_nameofcompany" runat="server"></asp:Label>
                                                                                            </td>
                                                                                        </tr>
                                                                                         <tr>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top"></td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                                                                <b>a.Address of the event management company.</b>
                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px" valign="top">:
                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                                                                <asp:Label ID="lbl_eventmanagementcompaddress" runat="server"></asp:Label>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">5.</td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                                                                <b>GST No.</b>
                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px" valign="top">:
                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                                                                <asp:Label ID="lbl_gstno" runat="server"></asp:Label>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">6.</td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                                                                <b>Name and location of the place where the performance is to be held </b>
                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px" valign="top">:
                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                                                                <asp:Label ID="lbl_namelocplac" runat="server"></asp:Label>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top"></td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                                                                <b>a.Location Area in sq.mts.</b>
                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px" valign="top">:
                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                                                                <asp:Label ID="lbl_locationarea" runat="server"></asp:Label>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">7.</td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                                                                <b>Type of structure planned
                                                                                                </b>
                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px" valign="top">:
                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                                                                <asp:Label ID="lbl_structplan" runat="server"></asp:Label>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top"></td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                                                                <b>a.No. of stalls</b>
                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px" valign="top">:
                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                                                                <asp:Label ID="lbl_noofstalls" runat="server"></asp:Label>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left; font-weight: bold" valign="top">8.
                                                                                            </td>
                                                                                            <td colspan="8" style="font: bold; background-color: cornflowerblue; font-weight: bold" valign="top">Stall Specification
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top"></td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                                                                <b>a.Size(Sq. Meters)</b>
                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px" valign="top">:
                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                                                                <asp:Label ID="lbl_sizesqmts" runat="server"></asp:Label>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top"></td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                                                                <b>b.Fabrication Material details with the detailed plan and drawings
                                                                                                </b>
                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px; vertical-align: text-top;" valign="top">:
                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;" valign="top">
                                                                                                <asp:Label ID="lbl_fabraction" runat="server"></asp:Label>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top"></td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                                                                <b>c.Whether there is proposed to be a clear space of 3 mts. on all sides of the structure and the adjacent buildings or other structures</b>
                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px; vertical-align: text-top;" valign="top">:
                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;" valign="top">
                                                                                                <asp:Label ID="lbl_clearspace" runat="server"></asp:Label>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top"></td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                                                                <b>d.Whether the temporary structure is intended to be constructed near an electric Substation, railway line, chimney or furnace and if so the distance from the same:</b>
                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px; vertical-align: text-top;" valign="top">:
                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;" valign="top">
                                                                                                <asp:Label ID="lbl_tempstruct" runat="server"></asp:Label>
                                                                                            </td>
                                                                                        </tr>
                                                                                       <%-- <tr>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top"><b>9</b></td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                                                                <b>Duration of the event(Event Timings & Dates)</b>
                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px; vertical-align: text-top;" valign="top">:
                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;" valign="top">
                                                                                                <asp:Label ID="lbl_duartion" runat="server"></asp:Label>
                                                                                            </td>
                                                                                        </tr>--%>
                                                                                         <tr>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left; font-weight: bold" valign="top">9.
                                                                                            </td>
                                                                                            <td colspan="8" style="font: bold; background-color: cornflowerblue; font-weight: bold" valign="top"> <b>Duration of the event(Event Timings & Dates)</b>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top"></td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                                                                <b>a.Working timings</b>
                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px; vertical-align: text-top;" valign="top">:
                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;" valign="top">
                                                                                                <asp:Label ID="lbl_workingtimings" runat="server"></asp:Label>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top"></td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                                                                <b>b.Public performance timings</b>
                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px; vertical-align: text-top;" valign="top"></td>
                                                                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;" valign="top">
                                                                                                <asp:Label ID="lbl_pubilcpertimings" runat="server"></asp:Label>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top"></td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                                                                <b>c.Starting Date</b>
                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px; vertical-align: text-top;" valign="top">:
                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;" valign="top">
                                                                                                <asp:Label ID="lbl_startingdate" runat="server"></asp:Label>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top"></td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                                                                <b>d.Ending Date</b>
                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px; vertical-align: text-top;" valign="top">:
                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;" valign="top">
                                                                                                <asp:Label ID="lbl_endingdate" runat="server"></asp:Label>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top"></td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                                                                <b>e.Expected strength of audience</b>
                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px; vertical-align: text-top;" valign="top"></td>
                                                                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;" valign="top">
                                                                                                <asp:Label ID="lbl_expecstreaudience" runat="server"></asp:Label>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <%--<tr>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top"><b>10.</b></td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                                                                <b>Total No. of Stalls that have been planned for</b>
                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px; vertical-align: text-top;" valign="top">:
                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;" valign="top">
                                                                                                <asp:Label ID="lbl_totalplanedstalls" runat="server"></asp:Label>
                                                                                            </td>
                                                                                        </tr>--%>

                                                                                        <tr>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left; font-weight: bold" valign="top">10.
                                                                                            </td>
                                                                                            <td colspan="8" style="font: bold; background-color: cornflowerblue; font-weight: bold" valign="top"> <b>Total No. of Stalls that have been planned for</b>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top"></td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                                                                <b>a.Product Related</b>
                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px; vertical-align: text-top;" valign="top">:
                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;" valign="top">
                                                                                                <asp:Label ID="lbl_prodrelated" runat="server"></asp:Label>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top"></td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                                                                <b>b.Food & Beverages</b>
                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px; vertical-align: text-top;" valign="top">:
                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;" valign="top">
                                                                                                <asp:Label ID="lbl_foodbeveages" runat="server"></asp:Label>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top"></td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                                                                <b>c.Games, Entertainment</b>
                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px; vertical-align: text-top;" valign="top">:
                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;" valign="top">
                                                                                                <asp:Label ID="lbl_gamesenter" runat="server"></asp:Label>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top"></td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                                                                <b>d.Others (specify)</b>
                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px; vertical-align: text-top;" valign="top">:
                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;" valign="top">
                                                                                                <asp:Label ID="lbl_otherspec" runat="server"></asp:Label>
                                                                                            </td>
                                                                                        </tr>

                                                                                        <tr>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left; font-weight: bold" valign="top">11.
                                                                                            </td>
                                                                                            <td colspan="8" style="font: bold; background-color: cornflowerblue; font-weight: bold" valign="top">Visitor Entry Details
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top"></td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                                                                <b>a.Free entry for all based on invitations</b>
                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px; vertical-align: text-top;" valign="top">:
                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;" valign="top">
                                                                                                <asp:Label ID="lbl_freeallinvat" runat="server"></asp:Label>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top"></td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                                                                <b>b.Free entry without invitations</b>
                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px; vertical-align: text-top;" valign="top">:
                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;" valign="top">
                                                                                                <asp:Label ID="lbl_freefreewithoutinvations" runat="server"></asp:Label>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top"></td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                                                                <b>c.Ticketed show</b>
                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px; vertical-align: text-top;" valign="top">:
                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;" valign="top">
                                                                                                <asp:Label ID="lbl_ticketshow" runat="server"></asp:Label>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr runat="server" visible="false">
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top"></td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                                                                <b>d.If yes, give details</b>
                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px; vertical-align: text-top;" valign="top"></td>
                                                                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;" valign="top">
                                                                                                <asp:Label ID="lbl_yesdetails" runat="server"></asp:Label>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top"></td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                                                                <b>d.Adult Ticket each(Rs/-)</b>
                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px; vertical-align: text-top;" valign="top">:
                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;" valign="top">
                                                                                                <asp:Label ID="lbl_adultticket" runat="server"></asp:Label>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top"></td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                                                                <b>e.Children Ticket each (More than 5years below 12 years)(Rs/-)</b>
                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px; vertical-align: text-top;" valign="top">:
                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;" valign="top">
                                                                                                <asp:Label ID="lbl_childticket" runat="server"></asp:Label>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top"></td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                                                                <b>f.Total No. of Ticket Counters</b>
                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px; vertical-align: text-top;" valign="top"></td>
                                                                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;" valign="top">
                                                                                                <asp:Label ID="lbl_totticketcounters" runat="server"></asp:Label>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top"></td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                                                                <b>g.Any VIP expected</b>
                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px; vertical-align: text-top;" valign="top"></td>
                                                                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;" valign="top">
                                                                                                <asp:Label ID="lbl_anyvip" runat="server"></asp:Label>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top"></td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                                                                <b>h.expected VIP name</b>
                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px; vertical-align: text-top;" valign="top"></td>
                                                                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;" valign="top">
                                                                                                <asp:Label ID="lbl_vipname" runat="server"></asp:Label>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top"></td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                                                                <b>i.Any Foreigner Expected</b>
                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px; vertical-align: text-top;" valign="top"></td>
                                                                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;" valign="top">
                                                                                                <asp:Label ID="lbl_anyforeigner" runat="server"></asp:Label>
                                                                                            </td>
                                                                                        </tr>
                                                                                         <tr>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top"></td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                                                                <b>j. Expected Foreigner name</b>
                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px; vertical-align: text-top;" valign="top"></td>
                                                                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;" valign="top">
                                                                                                <asp:Label ID="lbl_foreignername" runat="server"></asp:Label>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left; font-weight: bold" valign="top">12
                                                                                            </td>
                                                                                            <td colspan="8" style="font: bold; background-color: cornflowerblue; font-weight: bold" valign="top">Traffic Management 
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top"></td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                                                                <b>a.Space in Sq. Meters made available for parking at the venue.(In Sq. Mtrs.)</b>
                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px; vertical-align: text-top;" valign="top">:
                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;" valign="top">
                                                                                                <asp:Label ID="lbl_parkingspace" runat="server"></asp:Label>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top"></td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                                                                <b>b.No. of volunteers /security guards proposed to be deployed for vehicle checking along with equipments</b>
                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px; vertical-align: text-top;" valign="top">:
                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;" valign="top">
                                                                                                <asp:Label ID="lbl_noofvolunt" runat="server"></asp:Label>
                                                                                            </td>
                                                                                        </tr>
                                                                                       
                                                                                        <tr>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top"><b>13.</b></td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                                                                <b>Security Arrangements</b>
                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px; vertical-align: text-top;" valign="top">:
                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;" valign="top">
                                                                                                <asp:Label ID="lbl_secarrange" runat="server"></asp:Label>
                                                                                            </td>
                                                                                        </tr>
                                                                                         <tr>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top"></td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                                                                <b>a.<b>Whether required Police NOC</b></b>
                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px; vertical-align: text-top;" valign="top">:
                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;" valign="top">
                                                                                                <asp:Label ID="lbl_policenoc" runat="server"></asp:Label>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top"></td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                                                                <b>b.Proposed No. of CCTV’s</b>
                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px; vertical-align: text-top;" valign="top"></td>
                                                                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;" valign="top">
                                                                                                <asp:Label ID="lbl_pronofcctvs" runat="server"></asp:Label>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top"></td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                                                                <b>c.Proposed No. of DFMD’s and their location</b>
                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px; vertical-align: text-top;" valign="top">:
                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;" valign="top">
                                                                                                <asp:Label ID="lbl_pronoDFMDs" runat="server"></asp:Label>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top"></td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                                                                <b>d.Proposed No. of security guards and volunteers</b>
                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px; vertical-align: text-top;" valign="top">:
                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;" valign="top">
                                                                                                <asp:Label ID="lbl_prosecguarvol" runat="server"></asp:Label>
                                                                                            </td>
                                                                                        </tr>

                                                                                        <tr>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left; font-weight: bold" valign="top">14.
                                                                                            </td>
                                                                                            <td colspan="8" style="font: bold; background-color: cornflowerblue; font-weight: bold" valign="top">Fire Safety Arrangements
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top"></td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                                                                <b>a.No. of exits planned</b>
                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px; vertical-align: text-top;" valign="top">:
                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;" valign="top">
                                                                                                <asp:Label ID="lbl_noofexistsplanwid" runat="server"></asp:Label>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top"></td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                                                                <b>b.   width of exits planned</b>
                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px; vertical-align: text-top;" valign="top">:
                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;" valign="top">
                                                                                                <asp:Label ID="lbl_exitswidth" runat="server"></asp:Label>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top"></td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                                                                <b>c. No Of Gateways</b>
                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px; vertical-align: text-top;" valign="top">:
                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;" valign="top">
                                                                                                <asp:Label ID="lbl_noofgateways" runat="server"></asp:Label>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top"></td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                                                                <b>d.Width of the gangways planned</b>
                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px; vertical-align: text-top;" valign="top">:
                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;" valign="top">
                                                                                                <asp:Label ID="lbl_nowidthgangways" runat="server"></asp:Label>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top"></td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                                                                <b>e.No. of Co2 type Cylinders</b>
                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px; vertical-align: text-top;" valign="top"></td>
                                                                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;" valign="top">
                                                                                                <asp:Label ID="lbl_noofco2typecylinders" runat="server"></asp:Label>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top"></td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                                                                <b>f.No. of Foam Cylinders</b>
                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px; vertical-align: text-top;" valign="top">:
                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;" valign="top">
                                                                                                <asp:Label ID="lbl_nooffoamcylinders" runat="server"></asp:Label>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top"></td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                                                                <b>g.No. of Buckets</b>
                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px; vertical-align: text-top;" valign="top">:
                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;" valign="top">
                                                                                                <asp:Label ID="lbl_nofbuckets" runat="server"></asp:Label>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>

                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top"></td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                                                                <b>h.No. of Water Storage Tanks</b>
                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px; vertical-align: text-top;" valign="top">:
                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;" valign="top">
                                                                                                <asp:Label ID="lbl_noofwaterstorage" runat="server"></asp:Label>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top"></td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                                                                <b>i.No. of Sand Bags</b>
                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px; vertical-align: text-top;" valign="top">:
                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;" valign="top">
                                                                                                <asp:Label ID="lbl_noofsandbags" runat="server"></asp:Label>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top"></td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                                                                <b>j.Whether standby fire service is required</b>
                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px; vertical-align: text-top;" valign="top"></td>
                                                                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;" valign="top">
                                                                                                <asp:Label ID="lbl_standbyfireservice" runat="server"></asp:Label>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left; font-weight: bold" valign="top">15.
                                                                                            </td>
                                                                                            <td colspan="8" style="font: bold; background-color: cornflowerblue; font-weight: bold" valign="top">Medical Arrangements proposed at Venue
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top"></td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                                                                <b>a.First Aid facility</b>
                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px; vertical-align: text-top;" valign="top">:
                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;" valign="top">
                                                                                                <asp:Label ID="lbl_firstaidfacil" runat="server"></asp:Label>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top"></td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                                                                <b>b.Medical Attender/Doctor</b>
                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px" valign="top">:
                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                                                                <asp:Label ID="lbl_medicalattend" runat="server"></asp:Label>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top"></td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                                                                <b>c.Standby ambulance facility</b>

                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px" valign="top">:
                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                                                                <asp:Label ID="lbl_standbyambulance" runat="server"></asp:Label>
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
