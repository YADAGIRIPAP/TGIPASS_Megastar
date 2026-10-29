<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TourismTravelagentformPrint.aspx.cs" Inherits="UI_TSiPASS_TourismTravelagentformPrint" %>

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

        .auto-style1 {
            height: 37px;
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
                            <div class="col-sm-12 text-blue font-SemiBold text-center" runat="server" style="text-align:center" visible="true">
                               DRAFT APPLICATION FOR REGISTRATION OF TRAVEL AGENT/TOUR OPERATOR
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
                                                                DRAFT QUESTIONNAIRE FOR REGISTRATION OF TRAVEL AGENT/TOUR OPERATOR/TOURIST TRANSPORT OPERATOR
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td width="100%" align="center" style="text-align: center">
                                                                <asp:Label Font-Bold="true" Font-Size="Large" ID="lblheadTPRIDE" runat="server">
                                                     REGISTRATION Application Form
                                                                </asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="center" style="padding: 5px; margin: 5px; text-align: center;" valign="top"></td>
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
                                                                                        ForeColor="White">REGISTRATION  FORM</asp:Label>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td style="padding: 5px; margin: 5px" valign="top">
                                                                                    <table border="2" style="font-family: Verdana; font-size: small;" width="100%">
                                                                                        <tr>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">1
                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                                                                <b>Name of the Agency</b>
                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px; vertical-align: text-top;" valign="top">:
                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;" valign="top">
                                                                                                <asp:Label ID="lbl_nameoftheagency" runat="server"></asp:Label>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">2
                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                                                                <b>Name of the Owner/Director/Partner(Passport Size Photo) (to be verified)</b>
                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px; vertical-align: text-top;" valign="top">:
                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;" valign="top">
                                                                                                <asp:Label ID="lbl_nameofowner" runat="server"></asp:Label>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top"></td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                                                                <b>a.Mobile No.</b>
                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px" valign="top">:
                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                                                                <asp:Label ID="lbl_mobileno" runat="server"></asp:Label>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top"></td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                                                                <b>b.Email ID</b>
                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px" valign="top">:
                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                                                                <asp:Label ID="lbl_emailid" runat="server"></asp:Label>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top"></td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                                                                <b>c.Aadhaar No.</b>
                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px" valign="top">:
                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                                                                <asp:Label ID="lbl_aadhaar" runat="server"></asp:Label>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">3
                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                                                                <b>Applied for</b>

                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px" valign="top">:
                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                                                                <asp:Label ID="lbl_appliedfor" runat="server"></asp:Label>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left; font-weight: bold" valign="top">4.
                                                                                            </td>
                                                                                            <td colspan="8" style="font: bold; background-color: cornflowerblue; font-weight: bold" valign="top">Nature of Operations 
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top"></td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                                                                <b>a.Agency engaged in arrangements of tickets for travel by air, rail, ship, passport, 
                                                visa, etc. It may also arrange accommodation, tours, entertainment and other tourism related services</b>
                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px" valign="top">:
                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                                                                <asp:Label ID="lbl_tickettravel" runat="server"></asp:Label>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top"></td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                                                                <b>b.Agency engaged in arrangements for transport, accommodation, sightseeing, entertainment
                                                     and other tourism related services for tourists</b>
                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px" valign="top">:
                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                                                                <asp:Label ID="lbl_accod" runat="server"></asp:Label>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top"></td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                                                                <b>c.Agency engaged in activities related to Adventure Tourism in India namely, water sports, aero sports,
                                                     mountaineering, trekking and safaries of various kinds, etc. In addition to that he may also make
                                                     arrangements for transport, accommodation, etc.</b>
                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px" valign="top">:
                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                                                                <asp:Label ID="lbl_sports" runat="server"></asp:Label>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top"></td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                                                                <b>d.Agency engaged in providing  tourist transport like cars, coaches, boats etc. to tourists for transfers, sightseeing and journeys to tourist places etc.</asp:Label>
                                                                                                </b>
                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px" valign="top">:
                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                                                                <asp:Label ID="lbl_sightseeing" runat="server"></asp:Label>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">5
                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                                                                <b>Applying for(Head Office/Branch Office)</b>
                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px" valign="top">:
                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                                                                <asp:Label ID="lbl_headbranch" runat="server"></asp:Label>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">6
                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                                                                <b>Date of Commencement of the Business(DD/MM/YYYY )(If applicable enclose relevant Documents)</b>
                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px" valign="top">:
                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                                                                <asp:Label ID="lbl_DOCOB" runat="server"></asp:Label>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">7
                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                                                                <b>Constitution of the Agency(Pvt. Ltd. / Partnership Firm/ Proprietary / Cooperative / Registered trust / Registered company / LLP)
                                                                                                </b>
                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px; vertical-align: text-top;" valign="top">:
                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;" valign="top">
                                                                                                <asp:Label ID="lbl_conofagency" runat="server"></asp:Label>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">8
                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                                                                <b>Whether the premises is (owned / leased)</b>
                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px; vertical-align: text-top;" valign="top">:
                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;" valign="top">
                                                                                                <asp:Label ID="lbl_premises" runat="server"></asp:Label>
                                                                                            </td>
                                                                                        </tr>

                                                                                        <%--<tr>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top"></td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                                                                <b>a.If Owned upload the relevant Documents with self declaration stating that the premises being used for Agency purpose only.</b>
                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px" valign="top">:
                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                                                                <asp:Label ID="lbl_doucmentpremises" runat="server"></asp:Label>
                                                                                            </td>
                                                                                        </tr>--%>
                                                                                       <%-- <tr>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top"></td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                                                                <b>b.If leased upload the lease agreement</b>
                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px" valign="top">:
                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                                                                <asp:Label ID="lbl_leaseagreement" runat="server"></asp:Label>
                                                                                            </td>
                                                                                        </tr>--%>
                                                                                        <tr>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left; font-weight: bold" valign="top">9
                                                                                            </td>
                                                                                            <td colspan="8" style="font: bold; background-color: cornflowerblue; font-weight: bold" valign="top">Office Space Details
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top"></td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                                                                <b>a.Office Space (Min 150 Sft.)</b>
                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px; vertical-align: text-top;" valign="top">:
                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;" valign="top">
                                                                                                <asp:Label ID="lbl_officedetails" runat="server"></asp:Label>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top"></td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                                                                <b>b.Reception Area</b>
                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px; vertical-align: text-top;" valign="top">:
                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;" valign="top">
                                                                                                <asp:Label ID="lbl_receptionarea" runat="server"></asp:Label>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top"></td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                                                                <b>c.Location Area</b>
                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px; vertical-align: text-top;" valign="top"></td>
                                                                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;" valign="top">
                                                                                                <asp:Label ID="lbl_locationarea" runat="server"></asp:Label>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top"></td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                                                                <b>d.Address</b>
                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px; vertical-align: text-top;" valign="top">:
                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;" valign="top">
                                                                                                <asp:Label ID="lbl_officeaddress" runat="server"></asp:Label>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top"></td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                                                                <b>e.District</b>
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
                                                                                                <b>f.PIN Code</b>
                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px; vertical-align: text-top;" valign="top"></td>
                                                                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;" valign="top">
                                                                                                <asp:Label ID="lbl_pincode" runat="server"></asp:Label>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top"></td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                                                                <b>g.Phone No.</b>
                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px; vertical-align: text-top;" valign="top">:
                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;" valign="top">
                                                                                                <asp:Label ID="lbl_officephoneno" runat="server"></asp:Label>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top"></td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                                                                <b>>h.FAX No.</b>
                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px; vertical-align: text-top;" valign="top">:
                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;" valign="top">
                                                                                                <asp:Label ID="lbl_officefaxno" runat="server"></asp:Label>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top"></td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                                                                <b>i.Mobile No.</b>
                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px; vertical-align: text-top;" valign="top"></td>
                                                                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;" valign="top">
                                                                                                <asp:Label ID="lbl_officemobileno" runat="server"></asp:Label>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top"></td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                                                                <b>j.Email ID</b>
                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px; vertical-align: text-top;" valign="top">:
                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;" valign="top">
                                                                                                <asp:Label ID="lbl_officeemailid" runat="server"></asp:Label>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top"></td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                                                                <b>k.Website</b>
                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px; vertical-align: text-top;" valign="top">:
                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;" valign="top">
                                                                                                <asp:Label ID="lbl_officewebsite" runat="server"></asp:Label>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left; font-weight: bold" valign="top">10
                                                                                            </td>
                                                                                            <td colspan="8" style="font: bold; background-color: cornflowerblue; font-weight: bold" valign="top">Staff Details
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top"></td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                                                                <b>a.No. of qualified Staff</b>
                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px; vertical-align: text-top;" valign="top">:
                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;" valign="top">
                                                                                                <asp:Label ID="lbl_qualifiedstaff" runat="server"></asp:Label>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top"></td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                                                                <b>b.No. of experienced Staff</b>
                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px; vertical-align: text-top;" valign="top">:
                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;" valign="top">
                                                                                                <asp:Label ID="lbl_experstaff" runat="server"></asp:Label>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top"></td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                                                                <b>c.Total No. of Staff Employed</b>
                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px; vertical-align: text-top;" valign="top"></td>
                                                                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;" valign="top">
                                                                                                <asp:Label ID="lbl_staffemployed" runat="server"></asp:Label>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left; font-weight: bold" valign="top">11
                                                                                            </td>
                                                                                            <td colspan="8" style="font: bold; background-color: cornflowerblue; font-weight: bold" valign="top">Financial Details
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top"></td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                                                                <b>a.Paid up capital(Enclose Auditors Certificate)</b>
                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px; vertical-align: text-top;" valign="top">:
                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;" valign="top">
                                                                                                <asp:Label ID="lbl_paidcapital" runat="server"></asp:Label>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top"></td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                                                                <b>b.Previous Turnover if any</b>
                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px" valign="top">:
                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                                                                <asp:Label ID="lbl_preturnover" runat="server"></asp:Label>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top"></td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                                                                <b>c.PAN No.</b>

                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px" valign="top">:
                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                                                                <asp:Label ID="lbl_panno" runat="server"></asp:Label>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top"></td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                                                                <b>d.Previous Year IT Returns(If applicable)</b>
                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px; vertical-align: text-top;" valign="top">:
                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;" valign="top">
                                                                                                <asp:Label ID="lbl_preyearitreturns" runat="server"></asp:Label>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top"></td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                                                                <b>e.GST No. (To be verified)</b>
                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px; vertical-align: text-top;" valign="top">:
                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;" valign="top">
                                                                                                <asp:Label ID="lbl_gstno" runat="server"></asp:Label>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top"></td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                                                                <b>f.Bank Account Details (Current Account)</b>
                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px; vertical-align: text-top;" valign="top">:</td>
                                                                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;" valign="top">
                                                                                                <asp:Label ID="lbl_bankaccount" runat="server"></asp:Label>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top"></td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                                                                <b>g.Enclose reference letter from Bank on its original letterhead regarding firm’s bank account and address with 
                                                    telephone numbers</b>
                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px; vertical-align: text-top;" valign="top"></td>
                                                                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;" valign="top">
                                                                                                <asp:Label ID="lbl_bankaddress" runat="server"></asp:Label>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">12
                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                                                                <b>Do you require Trade License?</b>
                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px" valign="top">:
                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                                                                <asp:Label ID="lbl_isavailtradelicense" runat="server"></asp:Label>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">13
                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                                                                <b>Do you require Shops & Establishment License?</b>
                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px" valign="top">:
                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                                                                <asp:Label ID="lbl_isavailestlicense" runat="server"></asp:Label>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">14
                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                                                                <b>Whether registered with any Tourism Department/ Indian Association of Tour Operators (IATO) /Travel Agents Association of India (TAAI). </asp:Label>
                                                                                                </b>
                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px; vertical-align: text-top;" valign="top">:
                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;" valign="top">
                                                                                                <asp:Label ID="lbl_registered" runat="server"></asp:Label>
                                                                                            </td>
                                                                                        </tr>
                                                                                      <%--  <tr>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top"></td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                                                                <b>a.If Yes, enclose the Documents</b>
                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px" valign="top">:
                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                                                                <asp:Label ID="lbl_encolsedoc" runat="server"></asp:Label>
                                                                                            </td>
                                                                                        </tr>--%>
                                                                                        <tr>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">15
                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                                                                <b>No. of Tourist Vehicles (Buses/Taxes/Cabs etc.) owned by the Agency/Firm</b>
                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px" valign="top">:
                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                                                                <asp:Label ID="lbl_noofvehicles" runat="server"></asp:Label>
                                                                                            </td>
                                                                                        </tr>
                                                                                     <%--   <tr>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">16
                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top"><b>Self Declaration</b>
                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px" valign="top">:
                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                                                                <asp:Label ID="lbl_selfdecl" runat="server"></asp:Label>
                                                                                            </td>
                                                                                        </tr>--%>
                                                                                    </table>
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </div>
                                                                </div>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <div class="col-sm-12">
                                                                    <asp:CheckBox ID="chk_dec" runat="server" Checked="true" Enabled="false" />
                                                                    <b>This is to Certify That : </b>
                                                                    <br />
                                                                    I / We hereby certify that the particulars given above and in the appended enclosures are true and correct to the best of my/our knowledge and belief and that no material facts have been concealed or suppressed.
                                                               
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
