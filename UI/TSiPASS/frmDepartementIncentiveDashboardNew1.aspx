<%@ Page Title="" Language="C#" MasterPageFile="~/UI/TSiPASS/CCMaster.master" AutoEventWireup="true"
    CodeFile="frmDepartementIncentiveDashboardNew1.aspx.cs" Inherits="UI_TSiPASS_frmDepartementIncentiveDashboardNew1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script src="../../Resource/Scripts/js/validations.js" type="text/javascript"></script>
    <link href="assets/css/basic.css" rel="stylesheet" />
    <style>
        .page-head-linenew {
            font-size: 2px;
            text-transform: uppercase;
            color: #000;
            font-weight: 800;
            padding-bottom: 2px;
            border-bottom: 4px solid #00CA79;
            margin-bottom: 35px;
        }

        .page-subhead-linenew {
            font-size: 14px;
            padding-top: 5px;
            padding-bottom: 20px;
            font-style: italic;
            margin-bottom: 30px;
            border-bottom: 1px dashed #00CA79;
        }
    </style>
    <asp:UpdatePanel ID="updatepanel1" runat="server">
        <ContentTemplate>
            <div align="left">
                <ol class="breadcrumb">
                    You are here &nbsp;!&nbsp; &nbsp; &nbsp;
                    <li><i class="fa fa-dashboard"></i><a href="Home.aspx">Dashboard</a> </li>
                </ol>
            </div>
            <div align="center">
                <div class="row" align="center">
                    <div class="col-lg-12">
                        <div class="panel panel-primary">
                            <div class="panel-heading">
                                <h3 class="panel-title">
                                    Incentive Dashboard</h3>
                            </div>
                            <div class="panel-body">
                                <table align="center" cellpadding="10" cellspacing="5" style="width: 100%">
                                    <tr>
                                        <td style="padding: 5px; margin: 5px">
                                            <div class="panel panel-default">
                                                <div class="panel-body" align="center">
                                                    <table cellpadding="3" cellspacing="5" style="width: 100%">
                                                        <tr>
                                                            <td style="font-size: 16px; text-align: center;" colspan="3">
                                                                <asp:HyperLink ID="HyperLink1" runat="server" Font-Size="Small" NavigateUrl="~/UI/TSiPASS/frmDepartementIncentiveDashboardNew.aspx">Back</asp:HyperLink>
                                                            </td>
                                                        </tr>
                                                        <tr id="trsection1" runat="server">
                                                            <td style="width: 395px" valign="top">
                                                                <div class="list-group">
                                                                    <%--  <a class="list-group-item"><i class="fa fa-fw fa-check"></i><b>Incentive (Application
                                                                        Stage)</b> </a>--%>
                                                                    <a href="IncentiveStatusDetailsNew.aspx?Stg=1" class="list-group-item"><span class="badge">
                                                                        <asp:Label ID="lblAppl" runat="server"></asp:Label></span> <i class="fa fa-fw fa-calendar">
                                                                        </i>Total Applications received </a><a class="list-group-item" href="#"><i class="fa fa-fw fa-check">
                                                                        </i><b>Yet to be Assigned</b> </a><a class="list-group-item" href="IncentiveStatusDetailsNew.aspx?Stg=2">
                                                                            <span class="badge">
                                                                                <asp:Label ID="lblPendingWithin" runat="server"></asp:Label>
                                                                            </span><i class="fa fa-fw fa-calendar"></i>Within 7 Days</a> <a class="list-group-item"
                                                                                href="IncentiveStatusDetailsNew.aspx?Stg=3"><span class="badge" style="background-color: #d9534f;">
                                                                                    <asp:Label ID="lblPendingBeyond" runat="server"></asp:Label>
                                                                                </span><i class="fa fa-fw fa-calendar"></i>Beyond 7 Days</a> <a class="list-group-item"
                                                                                    href="IncentiveStatusDetailsNew.aspx?Stg=3T"><span class="badge" style="background-color: #d9534f;">
                                                                                        <asp:Label ID="lblPendingBeyondTomorrow" runat="server"></asp:Label>
                                                                                    </span><i class="fa fa-fw fa-calendar"></i><b><span class="badge" style="background-color: #d9534f;">
                                                                                        Applications - that cross timeline tomorrow</span></b></a> <a class="list-group-item"
                                                                                            href="#"><i class="fa fa-fw fa-check"></i><b>Scrutiny Completed - Assigned to Inspecting
                                                                                                Officer</b> </a><a class="list-group-item" href="IncentiveStatusDetailsNew.aspx?Stg=42">
                                                                                                    <span class="badge">
                                                                                                        <asp:Label ID="lblcomWithin" runat="server"></asp:Label>
                                                                                                    </span><i class="fa fa-fw fa-calendar"></i>Completed - Within 7 Days</a>
                                                                    <a class="list-group-item" href="IncentiveStatusDetailsNew.aspx?Stg=43"><span class="badge"
                                                                        style="background-color: #d9534f;">
                                                                        <asp:Label ID="lblcombeyond" runat="server"></asp:Label>
                                                                    </span><i class="fa fa-fw fa-calendar"></i>Completed - Beyond 7 Days</a> <a class="list-group-item"
                                                                        href="IncentiveStatusDetailsNew.aspx?Stg=3T"><span class="badge" style="background-color: #d9534f;">
                                                                            <asp:Label ID="lbltotalinspectionsbeyond" runat="server"></asp:Label>
                                                                        </span><i class="fa fa-fw fa-check"></i>Inspection not done beyond 7days</a>
                                                                    <a class="list-group-item" href="IncentiveStatusDetailsNew.aspx?Stg=3IM"><span class="badge"
                                                                        style="background-color: #008000;">
                                                                        <asp:Label ID="lblinspectionnotdoneManufacturing" runat="server"></asp:Label>
                                                                    </span><i class="fa fa-fw fa-calendar"></i><b><span class="badge" style="background-color: #008000;">
                                                                        Manufacturing</span></b></a> <a class="list-group-item"><i class="fa fa-fw fa-check">
                                                                        </i><b><span class="badge" style="background-color: #d9534f;">Service</span></b></a>
                                                                    <a class="list-group-item" href="IncentiveStatusDetailsNew.aspx?Stg=3IT"><span class="badge"
                                                                        style="background-color: #008000;">
                                                                        <asp:Label ID="lblinspectionnotdoneTransport" runat="server"></asp:Label>
                                                                    </span><i class="fa fa-fw fa-calendar"></i><b><span class="badge" style="background-color: #008000;">
                                                                        Transport</span></b></a> <a class="list-group-item" href="IncentiveStatusDetailsNew.aspx?Stg=3IO">
                                                                            <span class="badge" style="background-color: #008000;">
                                                                                <asp:Label ID="lblinspectionnotdoneOther" runat="server"></asp:Label>
                                                                            </span><i class="fa fa-fw fa-calendar"></i><b><span class="badge" style="background-color: #008000;">
                                                                                OtherService</span></b></a> <a href="IncentiveStatusDetailsNew.aspx?Stg=17" class="list-group-item">
                                                                                    <span class="badge">
                                                                                        <asp:Label ID="Label1" runat="server"></asp:Label></span> <i class="fa fa-fw fa-calendar">
                                                                                        </i>GM Rejected Incentives </a>
                                                                </div>
                                                            </td>
                                                            <td style="width: 30px">
                                                                &nbsp;
                                                            </td>
                                                            <td valign="top" style="width: 395px">
                                                                <div class="list-group">
                                                                    <a class="list-group-item" href="#"><i class="fa fa-fw fa-check"></i><b>Query Details
                                                                        - Before Assigned to Inspecting Officer</b> </a>
                                                                    <%-- <a class="list-group-item" href="IncentiveStatusDetailsNew.aspx?Stg=4"><span class="badge">
                                                                        <asp:Label ID="Label7" runat="server"></asp:Label>
                                                                    </span><i class="fa fa-fw fa-calendar"></i>Total - Query Raised</a>--%>
                                                                    <a class="list-group-item" href="IncentiveStatusDetailsNew.aspx?Stg=44"><span class="badge">
                                                                        <asp:Label ID="lblQueryRespondedwithin" runat="server"></asp:Label>
                                                                    </span><i class="fa fa-fw fa-calendar"></i>Within 7 Days</a> <a class="list-group-item"
                                                                        href="IncentiveStatusDetailsNew.aspx?Stg=45"><span class="badge" style="background-color: #d9534f;">
                                                                            <asp:Label ID="lblQueryRespondedbeyond" runat="server"></asp:Label>
                                                                        </span><i class="fa fa-fw fa-calendar"></i>Beyond 7 Days</a> <a class="list-group-item"
                                                                            href="IncentiveStatusDetailsNew.aspx?Stg=35"><span class="badge">
                                                                                <asp:Label ID="Label26" runat="server"></asp:Label>
                                                                            </span><i class="fa fa-fw fa-check"></i>Total - Query Responded</a> <a class="list-group-item"
                                                                                href="IncentiveStatusDetailsNew.aspx?Stg=36"><span class="badge">
                                                                                    <asp:Label ID="Label27" runat="server"></asp:Label>
                                                                                </span><i class="fa fa-fw fa-calendar"></i>No of Applications Awaiting Query Response</a>
                                                                    <a class="list-group-item" href="IncentiveStatusDetailsNew.aspx?Stg=91"><span class="badge">
                                                                        <asp:Label ID="lblAutorejected" runat="server"></asp:Label>
                                                                    </span><i class="fa fa-fw fa-calendar"></i>Auto Rejected Applications</a> <a class="list-group-item"
                                                                        href="#"><i class="fa fa-fw fa-check"></i><b>Showcause Issued</b> </a><a class="list-group-item"
                                                                            href="frmshowcausedetails.aspx?Stg=SC1"><span class="badge">
                                                                                <asp:Label ID="LBLReplied" runat="server"></asp:Label>
                                                                            </span><i class="fa fa-fw fa-calendar"></i>Showcause Replied</a> <a class="list-group-item"
                                                                                href="frmshowcausedetails.aspx?Stg=SC2"><span class="badge" style="background-color: #d9534f;">
                                                                                    <asp:Label ID="LBLNotReplied" runat="server"></asp:Label>
                                                                                </span><i class="fa fa-fw fa-calendar"></i>Showcause Not Replied</a>
                                                                    <a class="list-group-item" href="frmshowcausedetails.aspx?Stg=SC3"><span class="badge">
                                                                        <asp:Label ID="LBLTOTALSHOWCAUSE" runat="server"></asp:Label>
                                                                    </span><i class="fa fa-fw fa-check"></i>Total - Showcause Issued</a>
                                                                </div>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="3" style="height: 5px">
                                                                <div>
                                                                    <h1 class="page-head-linenew" align="left" style="font-size: smaller">
                                                                    </h1>
                                                                </div>
                                                            </td>
                                                        </tr>
                                                        <tr id="trsection2" runat="server">
                                                            <td style="width: 395px" valign="top">
                                                                <div class="list-group">
                                                                    <a class="list-group-item" href="#"><i class="fa fa-fw fa-check"></i><b>Queries From
                                                                        Inspecting Officer</b> </a><a class="list-group-item" href="IncentiveStatusDetailsNew.aspx?Stg=80">
                                                                            <span class="badge">
                                                                                <asp:Label ID="Label7" runat="server"></asp:Label>
                                                                            </span><i class="fa fa-fw fa-calendar"></i>Total - Query Raised</a> <a class="list-group-item"
                                                                                href="IncentiveStatusDetailsNew.aspx?Stg=81"><span class="badge">
                                                                                    <asp:Label ID="Label8" runat="server"></asp:Label>
                                                                                </span><i class="fa fa-fw fa-calendar"></i>Forwarded To applicant</a>
                                                                    <a class="list-group-item" href="IncentiveStatusDetailsNew.aspx?Stg=82"><span class="badge">
                                                                        <asp:Label ID="Label29" runat="server"></asp:Label>
                                                                    </span><i class="fa fa-fw fa-calendar"></i>Query Response from the applicant</a>
                                                                </div>
                                                            </td>
                                                            <td style="width: 30px">
                                                                &nbsp;
                                                            </td>
                                                            <td valign="top" style="width: 395px">
                                                                <div class="list-group">
                                                                    <a class="list-group-item" href="#"><i class="fa fa-fw fa-check"></i><b>Queries From
                                                                        COI</b> </a><a class="list-group-item" href="IncentiveStatusDetailsNew.aspx?Stg=83">
                                                                            <span class="badge">
                                                                                <asp:Label ID="lblqueriesrespondedcoi" runat="server"></asp:Label>
                                                                            </span><i class="fa fa-fw fa-calendar"></i>Queries Responded by GM to COI</a>
                                                                    <a class="list-group-item" href="IncentiveStatusDetailsNew.aspx?Stg=60"><span class="badge">
                                                                        <asp:Label ID="Label42" runat="server"></asp:Label>
                                                                    </span><i class="fa fa-fw fa-calendar"></i>Queries Raised by GM (after applicant Response)</a>
                                                                    <a class="list-group-item" href="IncentiveStatusDetailsNew.aspx?Stg=32"><span class="badge">
                                                                        <asp:Label ID="Label31" runat="server"></asp:Label>
                                                                    </span><i class="fa fa-fw fa-calendar"></i>Queries Responded by Applicant (GM Yet to
                                                                        Respond)</a> <a class="list-group-item" href="IncentiveStatusDetailsNew.aspx?Stg=20">
                                                                            <span class="badge">
                                                                                <asp:Label ID="lblQueriesfromcoi" runat="server"></asp:Label>
                                                                            </span><i class="fa fa-fw fa-calendar"></i>Queries Yet to Respond</a> <a class="list-group-item"
                                                                                href="IncentiveStatusDetailsNew.aspx?Stg=84"><span class="badge">
                                                                                    <asp:Label ID="lblqueriestotalcoi" runat="server"></asp:Label>
                                                                                </span><i class="fa fa-fw fa-calendar"></i>Total - Query Raised</a>
                                                                    <a class="list-group-item" runat="server" visible="false" href="IncentiveStatusDetailsNew.aspx?Stg=121">
                                                                        <span class="badge">
                                                                            <asp:Label ID="lblGMQueryRespond" runat="server" Visible="false"></asp:Label>
                                                                        </span><i class="fa fa-fw fa-calendar"></i>Queries Raised to GM(GM Yet to Respond)</a>
                                                                    <a class="list-group-item" href="IncentiveStatusDetailsNew.aspx?Stg=122"><span class="badge">
                                                                        <asp:Label ID="lblssccompleted" runat="server"></asp:Label>
                                                                    </span><i class="fa fa-fw fa-calendar"></i>SSC Inspection Completed (GM Yet to Forward)</a>
                                                                </div>
                                                            </td>
                                                        </tr>
                                                        <tr id="trsection3" runat="server">
                                                            <td colspan="3" style="height: 5px">
                                                                <div>
                                                                    <h1 class="page-head-linenew" align="left" style="font-size: smaller">
                                                                    </h1>
                                                                </div>
                                                            </td>
                                                        </tr>
                                                        <tr id="trsection4" runat="server">
                                                            <td style="width: 395px" valign="top">
                                                                <div class="list-group">
                                                                    <a class="list-group-item" href="#"><i class="fa fa-fw fa-check"></i><b>Pending to be
                                                                        Reffered (COI/DIPC)</b> </a><a class="list-group-item" href="IncentiveStatusDetailsNew.aspx?Stg=40">
                                                                            <span class="badge">
                                                                                <asp:Label ID="lblpendingtoberefferdW" runat="server"></asp:Label>
                                                                            </span><i class="fa fa-fw fa-calendar"></i>Within 3 Days</a> <a class="list-group-item"
                                                                                href="IncentiveStatusDetailsNew.aspx?Stg=41"><span class="badge" style="background-color: #d9534f;">
                                                                                    <asp:Label ID="lblpendingtoberefferdB" runat="server"></asp:Label>
                                                                                </span><i class="fa fa-fw fa-calendar"></i>Beyond 3 Days</a> <a href="IncentiveStatusDetailsNew.aspx?Stg=101"
                                                                                    class="list-group-item"><span class="badge">
                                                                                        <asp:Label ID="lblrejectedafterinsp" runat="server"></asp:Label></span> <i class="fa fa-fw fa-calendar">
                                                                                        </i>Rejected Applications </a>
                                                                </div>
                                                            </td>
                                                            <td style="width: 30px">
                                                                &nbsp;
                                                            </td>
                                                            <td valign="top" style="width: 395px">
                                                                <div class="list-group">
                                                                    <a class="list-group-item" href="#"><i class="fa fa-fw fa-check"></i><b>Query Details
                                                                        - After Inspection</b> </a><a class="list-group-item" href="IncentiveStatusDetailsNew.aspx?Stg=49">
                                                                            <span class="badge">
                                                                                <asp:Label ID="lblAfrerInspection" runat="server"></asp:Label>
                                                                            </span><i class="fa fa-fw fa-check"></i>Total - Query Responded</a> <a class="list-group-item"
                                                                                href="IncentiveStatusDetailsNew.aspx?Stg=50"><span class="badge">
                                                                                    <asp:Label ID="lblAfrerInspectionwithin" runat="server"></asp:Label>
                                                                                </span><i class="fa fa-fw fa-calendar"></i>Within 7 Days</a> <a class="list-group-item"
                                                                                    href="IncentiveStatusDetailsNew.aspx?Stg=51"><span class="badge" style="background-color: #d9534f;">
                                                                                        <asp:Label ID="lblAfrerInspectionbeyond" runat="server"></asp:Label>
                                                                                    </span><i class="fa fa-fw fa-calendar"></i>Beyond 7 Days</a> <a class="list-group-item"
                                                                                        href="IncentiveStatusDetailsNew.aspx?Stg=52"><span class="badge">
                                                                                            <asp:Label ID="lblAfrerInspectionawaiting" runat="server"></asp:Label>
                                                                                        </span><i class="fa fa-fw fa-calendar"></i>No of Applications Awaiting Query Response</a>
                                                                </div>
                                                            </td>
                                                        </tr>
                                                        <tr id="trsection5" runat="server">
                                                            <td colspan="3" style="height: 5px">
                                                                <div>
                                                                    <h1 class="page-head-linenew" align="left" style="font-size: smaller">
                                                                    </h1>
                                                                </div>
                                                            </td>
                                                        </tr>
                                                        <tr id="trsection6" runat="server">
                                                            <td style="width: 395px" valign="top">
                                                                <div class="list-group">
                                                                    <a class="list-group-item"><i class="fa fa-fw fa-check"></i><b>Recommended to COI</b>
                                                                    </a><a class="list-group-item" href="IncentiveStatusDetailsNew.aspx?Stg=15"><span
                                                                        class="badge">
                                                                        <asp:Label ID="Label19" runat="server"></asp:Label>
                                                                    </span><i class="fa fa-fw fa-calendar"></i>Within 3 Days </a><a class="list-group-item"
                                                                        href="IncentiveStatusDetailsNew.aspx?Stg=16"><span class="badge" style="background-color: #d9534f;">
                                                                            <asp:Label ID="Label22" runat="server"></asp:Label>
                                                                        </span><i class="fa fa-fw fa-calendar"></i>Beyond 3 Days </a>
                                                                </div>
                                                                <div class="list-group">
                                                                    <a class="list-group-item"><i class="fa fa-fw fa-check"></i><b>Rejected Applications
                                                                        at COI</b> </a><a class="list-group-item" href="IncentiveStatusDetailsNew.aspx?Stg=85">
                                                                            <span class="badge">
                                                                                <asp:Label ID="Label35" runat="server"></asp:Label>
                                                                            </span><i class="fa fa-fw fa-calendar"></i>Rejected by J.D </a><a class="list-group-item"
                                                                                href="IncentiveStatusDetailsNew.aspx?Stg=302"><span class="badge">
                                                                                    <asp:Label ID="Label36" runat="server"></asp:Label>
                                                                                </span><i class="fa fa-fw fa-calendar"></i>Rejected by Additional Director</a>
                                                                    <a class="list-group-item" href="IncentiveStatusDetailsNew.aspx?Stg=303"><span class="badge">
                                                                        <asp:Label ID="Label37" runat="server"></asp:Label>
                                                                    </span><i class="fa fa-fw fa-calendar"></i>Rejected at SVC</a> <a class="list-group-item"
                                                                        href="IncentiveStatusDetailsNew.aspx?Stg=304"><span class="badge">
                                                                            <asp:Label ID="Label38" runat="server"></asp:Label>
                                                                        </span><i class="fa fa-fw fa-calendar"></i>Rejected at SLC</a>
                                                                </div>
                                                                <div class="list-group">
                                                                    <a class="list-group-item"><i class="fa fa-fw fa-check"></i><b>Abeyanced Applications
                                                                        at COI</b> </a><a class="list-group-item" href="IncentiveStatusDetailsNew.aspx?Stg=305">
                                                                            <span class="badge">
                                                                                <asp:Label ID="Label39" runat="server"></asp:Label>
                                                                            </span><i class="fa fa-fw fa-calendar"></i>Abeyanced Applications at J.D Level
                                                                    </a><a class="list-group-item" href="IncentiveStatusDetailsNew.aspx?Stg=306"><span
                                                                        class="badge">
                                                                        <asp:Label ID="Label40" runat="server"></asp:Label>
                                                                    </span><i class="fa fa-fw fa-calendar"></i>Abeyanced Applications at Additional Director
                                                                    </a>
                                                                </div>
                                                            </td>
                                                            <td style="width: 30px">
                                                                &nbsp;
                                                            </td>
                                                            <td valign="top" style="width: 395px">
                                                                <div class="list-group">
                                                                    <a class="list-group-item"><i class="fa fa-fw fa-check"></i><b>Recommended to DIPC </b>
                                                                    </a>
                                                                    <%-- <a class="list-group-item" href="CommissionerIncentiveUpdation.aspx?Stg=10">--%>
                                                                    <a href="IncentiveStatusDetailsNew.aspx?Stg=13" class="list-group-item"><span class="badge">
                                                                        <asp:Label ID="Label18" runat="server"></asp:Label>
                                                                    </span><i class="fa fa-fw fa-calendar"></i>Within 3 Days </a><a href="IncentiveStatusDetailsNew.aspx?Stg=14"
                                                                        class="list-group-item"><span class="badge" style="background-color: #d9534f;">
                                                                            <asp:Label ID="Label9" runat="server"></asp:Label>
                                                                        </span><i class="fa fa-fw fa-calendar"></i>Beyond 3 Days </a>
                                                                </div>
                                                            </td>
                                                        </tr>
                                                        <tr id="trsection7" runat="server">
                                                            <td colspan="3" style="height: 5px">
                                                                <div>
                                                                    <h1 class="page-head-linenew" align="left" style="font-size: smaller">
                                                                    </h1>
                                                                </div>
                                                            </td>
                                                        </tr>
                                                        <tr id="trsection8" runat="server">
                                                            <td style="width: 395px" valign="top">
                                                                <div class="list-group">
                                                                    <a class="list-group-item"><i class="fa fa-fw fa-check"></i><b>Fund Released Stage</b>
                                                                    </a><a href="#" class="list-group-item"><span class="badge">
                                                                        <asp:Label ID="Label5" runat="server"></asp:Label></span> <i class="fa fa-fw fa-calendar">
                                                                        </i>Sanctioned Within 30 Days </a><a href="#" class="list-group-item"><span class="badge">
                                                                            <asp:Label ID="Label23" runat="server"></asp:Label></span> <i class="fa fa-fw fa-calendar">
                                                                            </i>Sanctioned Beyond 30 Days </a><a href="#" class="list-group-item"><span class="badge">
                                                                                <asp:Label ID="Label2" runat="server"></asp:Label></span> <i class="fa fa-fw fa-calendar">
                                                                                </i>Sanctioned Incentives </a><a href="IncentiveStatusDetailsNew.aspx?Stg=85" class="list-group-item"
                                                                                    style="display: block"><span class="badge">
                                                                                        <asp:Label ID="Label30" runat="server"></asp:Label></span> <i class="fa fa-fw fa-calendar">
                                                                                        </i>JD Rejected Incentives </a><a href="#" class="list-group-item"><span class="badge">
                                                                                            <asp:Label ID="Label3" runat="server"></asp:Label></span> <i class="fa fa-fw fa-calendar">
                                                                                            </i>Not having Power Connection Applications </a>
                                                                </div>
                                                            </td>
                                                            <td style="width: 30px">
                                                                &nbsp;
                                                            </td>
                                                            <td valign="top" style="width: 395px">
                                                                <div class="list-group">
                                                                    <a href="#" class="list-group-item"><span class="badge">
                                                                        <asp:Label ID="Label24" runat="server"></asp:Label></span> <i class="fa fa-fw fa-calendar">
                                                                        </i>Released Within 180 Days </a><a href="#" class="list-group-item"><span class="badge">
                                                                            <asp:Label ID="Label25" runat="server"></asp:Label></span> <i class="fa fa-fw fa-calendar">
                                                                            </i>Released Beyond 180 Days </a>
                                                                </div>
                                                            </td>
                                                        </tr>
                                                        <tr id="trsection9" runat="server">
                                                            <td colspan="3" style="height: 5px">
                                                                <div>
                                                                    <h1 class="page-head-linenew" align="left" style="font-size: smaller">
                                                                    </h1>
                                                                </div>
                                                            </td>
                                                        </tr>
                                                        <tr id="trsection10" runat="server">
                                                            <td colspan="3">
                                                                <a class="list-group-item" href="#"><i class="fa fa-fw fa-check"></i><b>Inspecting officer
                                                                    - Dashboard</b> </a>
                                                            </td>
                                                        </tr>
                                                        <tr id="trsection13" runat="server">
                                                            <td colspan="3">
                                                                <div class="list-group">
                                                                    <asp:GridView ID="gvqueryresponse" runat="server" AutoGenerateColumns="False" Width="100%"
                                                                        HorizontalAlign="Left" ShowHeader="true">
                                                                        <Columns>
                                                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S No">
                                                                                <ItemTemplate>
                                                                                    <%# Container.DataItemIndex + 1%>
                                                                                </ItemTemplate>
                                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                                <ItemStyle Width="20px" />
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Inspecting officer" HeaderStyle-VerticalAlign="Middle">
                                                                                <ItemTemplate>
                                                                                    <asp:Label ID="lblname" runat="server" Text='<%#Eval("Dept_Name")%>'></asp:Label>
                                                                                </ItemTemplate>
                                                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="100px" />
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="View Dashboard" HeaderStyle-VerticalAlign="Middle">
                                                                                <ItemTemplate>
                                                                                    <asp:HyperLink ID="HyperLinkSubsidy" Text="View" NavigateUrl='<%#Eval("Path")%>'
                                                                                        Target="_blank" runat="server" />
                                                                                </ItemTemplate>
                                                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="100px" />
                                                                            </asp:TemplateField>
                                                                        </Columns>
                                                                    </asp:GridView>
                                                                </div>
                                                            </td>
                                                        </tr>
                                                        <tr id="trsection11" runat="server">
                                                            <td style="width: 395px" valign="top">
                                                                <div class="list-group">
                                                                    <%-- <a class="list-group-item" href="#"><i class="fa fa-fw fa-check"></i><b>Assigned to inspecting officer</b> </a>--%>
                                                                    <a class="list-group-item" href="#"><i class="fa fa-fw fa-check"></i><b>Assigned to
                                                                        inspecting officer - Not Yet Scheduled</b> </a><a href="IncentiveStatusDetailsNew.aspx?Stg=5"
                                                                            class="list-group-item"><span class="badge">
                                                                                <asp:Label ID="lblApproved" runat="server"></asp:Label></span> <i class="fa fa-fw fa-calendar">
                                                                                </i>Within 7 Days </a><a href="IncentiveStatusDetailsNew.aspx?Stg=6" class="list-group-item">
                                                                                    <span class="badge" style="background-color: #d9534f;">
                                                                                        <asp:Label ID="lblApprovedByndSvn" runat="server"></asp:Label></span> <i class="fa fa-fw fa-calendar">
                                                                                        </i>Beyond 7 Days </a><a href="IncentiveStatusDetailsNew.aspx?Stg=7" class="list-group-item">
                                                                                            <span class="badge">
                                                                                                <asp:Label ID="lblAssigned" runat="server"></asp:Label></span> <i class="fa fa-fw fa-calendar">
                                                                                                </i>Total Not Yet Scheduled </a>
                                                                     <a href="IncentiveStatusDetailsNew.aspx?Stg=71" class="list-group-item">
     <span class="badge">
         <asp:Label ID="lblOfficertochange" runat="server"></asp:Label></span> <i class="fa fa-fw fa-calendar"></i>Change Assigned Officer </a>
 <a href="IncentiveStatusDetailsNew.aspx?Stg=72" class="list-group-item">
     <span class="badge">
         <asp:Label ID="lblOfficerchanged" runat="server"></asp:Label></span> <i class="fa fa-fw fa-calendar"></i>Assigned Officer changed application </a>
                                                                    
                                                                    <a class="list-group-item" href="#"><i class="fa fa-fw fa-check">
                                                                                                </i><b>Assigned to inspecting officer -Total Scheduled</b>
                                                                    </a><a href="IncentiveStatusDetailsNew.aspx?Stg=46" class="list-group-item"><span
                                                                        class="badge">
                                                                        <asp:Label ID="lblScheduledW" runat="server"></asp:Label></span> <i class="fa fa-fw fa-calendar">
                                                                        </i>Within 7 Days </a><a href="IncentiveStatusDetailsNew.aspx?Stg=47" class="list-group-item">
                                                                            <span class="badge" style="background-color: #d9534f;">
                                                                                <asp:Label ID="lblScheduledB" runat="server"></asp:Label></span> <i class="fa fa-fw fa-calendar">
                                                                                </i>Beyond 7 Days </a><a href="IncentiveStatusDetailsNew.aspx?Stg=48" class="list-group-item">
                                                                                    <span class="badge">
                                                                                        <asp:Label ID="lblScheduledTotal" runat="server"></asp:Label></span> <i class="fa fa-fw fa-calendar">
                                                                                        </i>Total Scheduled </a><a href="#" class="list-group-item"><span class="badge" style="background-color: #d9534f;">
                                                                                            <asp:Label ID="LblReptiveApplications" runat="server"></asp:Label></span> <i class="fa fa-fw fa-calendar">
                                                                                            </i>Repetitive Applications </a>
                                                                    <%-- <a class="list-group-item" href="IncentiveStatusDetailsNew.aspx?Stg=8"><span class="badge">
                                                                        <asp:Label ID="Label8" runat="server"></asp:Label>
                                                                    </span><i class="fa fa-fw fa-calendar"></i>Inspection scheduled </a>--%>
                                                                </div>
                                                            </td>
                                                            <td style="width: 30px">
                                                                &nbsp;
                                                            </td>
                                                            <td valign="top" style="width: 395px">
                                                                <div class="list-group">
                                                                    <a class="list-group-item"><i class="fa fa-fw fa-check"></i><b>Inspection Report Uploaded
                                                                        - Total</b></a> <a class="list-group-item" href="IncentiveStatusDetailsNew.aspx?Stg=9">
                                                                            <span class="badge">
                                                                                <asp:Label ID="Label15" runat="server"></asp:Label>
                                                                            </span><i class="fa fa-fw fa-calendar"></i>With in 48 hrs </a><a class="list-group-item"
                                                                                href="IncentiveStatusDetailsNew.aspx?Stg=10"><span class="badge" style="background-color: #d9534f;">
                                                                                    <asp:Label ID="Label16" runat="server"></asp:Label>
                                                                                </span><i class="fa fa-fw fa-calendar"></i>Beyond 48 hrs </a><a class="list-group-item">
                                                                                    <i class="fa fa-fw fa-check"></i><b>Inspection Report Not Yet Uploaded</b>
                                                                    </a><a class="list-group-item" href="IncentiveStatusDetailsNew.aspx?Stg=11"><span
                                                                        class="badge">
                                                                        <asp:Label ID="Label11" runat="server"></asp:Label>
                                                                    </span><i class="fa fa-fw fa-calendar"></i>With in 48 hrs </a><a class="list-group-item"
                                                                        href="IncentiveStatusDetailsNew.aspx?Stg=12"><span class="badge" style="background-color: #d9534f;">
                                                                            <asp:Label ID="Label12" runat="server"></asp:Label>
                                                                        </span><i class="fa fa-fw fa-calendar"></i>Beyond 48 hrs </a>
                                                                    
                                                                     <a class="list-group-item" href="IncentiveStatusDetailsNew.aspx?Stg=11"><span
     class="badge">
     <asp:Label ID="lblTotRptNotUpld" runat="server"></asp:Label>
 </span><i class="fa fa-fw fa-calendar"></i>Total </a>
 <a class="list-group-item" href="IncentiveStatusDetailsNew.aspx?Stg=1171"><span
     class="badge">
     <asp:Label ID="lblTotRptNotUpldNeedtoRollback" runat="server"></asp:Label>
 </span><i class="fa fa-fw fa-calendar"></i>Rollback and change Assigned Officer </a>
                                                                    
                                                                    <a class="list-group-item"
                                                                            href="#"><span class="badge">
                                                                                <asp:Label ID="Label17" runat="server"></asp:Label>
                                                                            </span><i class="fa fa-fw fa-calendar"></i>GM certificate uploaded </a>
                                                                    <%-- <a class="list-group-item" href="frmCFEDepartmentsViewAppl.aspx?Stg=1"><span class="badge" >
                                                <asp:Label ID="Label6" runat="server"></asp:Label>
                                                </span><i class="fa fa-fw fa-calendar"></i>Assigned Incentives to inspecting officer</a>
                                                
                                                 <a href="IncentiveStatusDetails.aspx?Stg=1" class="list-group-item">
                                        <span class="badge" style=" background-color:#d9534f;">
                                            <asp:Label ID="Label4" runat="server"></asp:Label></span>
                                        <i class="fa fa-fw fa-calendar"></i> Yet to be assigned Appl
                                    </a>
                                           
                                           <a href="IncentiveStatusDetails.aspx?Stg=1" class="list-group-item">
                                        <span class="badge" style=" background-color:#d9534f;">
                                            <asp:Label ID="Label20" runat="server"></asp:Label></span>
                                        <i class="fa fa-fw fa-calendar"></i> Yet to be assigned Incentives
                                    </a>
                                           
                                             <a class="list-group-item" href="IncentiveStatusDetails.aspx?Stg=1"><span class="badge" >
                                                <asp:Label ID="Label21" runat="server"></asp:Label>
                                                </span><i class="fa fa-fw fa-calendar"></i>Inspection scheduled </a>
                                                
                                                <a class="list-group-item"> <i class="fa fa-fw fa-check"></i>Inspection report uploaded </a>
                                                
                                                <a class="list-group-item" href="IncentiveStatusDetails.aspx?Stg=1"><span class="badge" >
                                                <asp:Label ID="Label23" runat="server"></asp:Label>
                                                </span><i class="fa fa-fw fa-calendar"></i>With in 48 hrs </a>
                                                
                                                
                                                <a class="list-group-item" href="IncentiveStatusDetails.aspx?Stg=1"><span class="badge" style=" background-color:#d9534f;">
                                                <asp:Label ID="Label24" runat="server"></asp:Label>
                                                </span><i class="fa fa-fw fa-calendar"></i>Beyond in 48 hrs </a>
                                                
                                                <a class="list-group-item" ><i class="fa fa-fw fa-check"></i>Inspection report not uploaded</a>
                                                
                                                   <a class="list-group-item" href="IncentiveStatusDetails.aspx?Stg=1"><span class="badge" >
                                                <asp:Label ID="Label26" runat="server"></asp:Label>
                                                </span><i class="fa fa-fw fa-calendar"></i>With in 48 hrs </a>
                                                
                                                
                                                <a class="list-group-item" href="IncentiveStatusDetails.aspx?Stg=1"><span class="badge" style=" background-color:#d9534f;">
                                                <asp:Label ID="Label27" runat="server"></asp:Label>
                                                </span><i class="fa fa-fw fa-calendar"></i>Beyond in 48 hrs </a>
                                                
                                                
                                                  <a class="list-group-item" href="IncentiveStatusDetails.aspx?Stg=1"><span class="badge" style=" background-color:#d9534f;">
                                                <asp:Label ID="Label28" runat="server"></asp:Label>
                                                </span><i class="fa fa-fw fa-calendar"></i>GM certificate attached </a>
                                                
                                                  <a class="list-group-item" href="IncentiveStatusDetails.aspx?Stg=1"><span class="badge" style=" background-color:#d9534f;">
                                                <asp:Label ID="Label29" runat="server"></asp:Label>
                                                </span><i class="fa fa-fw fa-calendar"></i>Recommanded Incentives for Fund Released to DIPC </a>
                                                
                                                
                                                   <a class="list-group-item" href="IncentiveStatusDetails.aspx?Stg=1"><span class="badge" style=" background-color:#d9534f;">
                                                <asp:Label ID="Label30" runat="server"></asp:Label>
                                                </span><i class="fa fa-fw fa-calendar"></i>Recommanded Incentives for Fund Released to COI</a>--%>
                                                                </div>
                                                            </td>
                                                        </tr>
                                                        <tr id="trsection12" runat="server">
                                                            <td colspan="3" style="height: 5px">
                                                                <div>
                                                                    <h1 class="page-head-linenew" align="left" style="font-size: smaller">
                                                                    </h1>
                                                                </div>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                    <br />
                                                    <table runat="server" id="trGmDashboard" cellpadding="3" cellspacing="5" style="width: 100%"
                                                        visible="false">
                                                        <tr>
                                                            <td style="width: 395px" valign="top">
                                                                <a class="list-group-item"><i class="fa fa-fw fa-check"></i><b>GM Inspection Process</b>
                                                                </a>
                                                            </td>
                                                            <td style="width: 30px">
                                                                &nbsp;
                                                            </td>
                                                            <td valign="top" style="width: 395px">
                                                                &nbsp;
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="width: 395px" valign="top">
                                                                <div class="list-group">
                                                                    <a class="list-group-item" href="IncentiveStatusInspectionDateDetailsNew.aspx?Stg=1">
                                                                        <span class="badge">
                                                                            <asp:Label ID="Label6" runat="server"></asp:Label>
                                                                        </span><i class="fa fa-fw fa-calendar"></i>Assigned to GM</a> <a class="list-group-item"
                                                                            href="IncentiveStatusInspectionDateDetailsNew.aspx?Stg=3"><span class="badge">
                                                                                <asp:Label ID="Label4" runat="server"></asp:Label>
                                                                            </span><i class="fa fa-fw fa-calendar"></i>Inspection yet to be scheduled
                                                                    </a><a class="list-group-item" href="IncentiveStatusInspectionDateDetailsNew.aspx?Stg=4">
                                                                        <span class="badge">
                                                                            <asp:Label ID="Label10" runat="server"></asp:Label>
                                                                        </span><i class="fa fa-fw fa-calendar"></i>Inspection scheduled </a><a class="list-group-item">
                                                                            <i class="fa fa-fw fa-check"></i>Inspection report uploaded</a> <a class="list-group-item"
                                                                                href="IncentiveStatusInspectionDateDetailsNew.aspx?Stg=4"><span class="badge">
                                                                                    <asp:Label ID="Label13" runat="server"></asp:Label>
                                                                                </span><i class="fa fa-fw fa-calendar"></i>With in 48 hrs </a><a class="list-group-item"
                                                                                    href="IncentiveStatusInspectionDateDetailsNew.aspx?Stg=5"><span class="badge" style="background-color: #d9534f;">
                                                                                        <asp:Label ID="Label14" runat="server"></asp:Label>
                                                                                    </span><i class="fa fa-fw fa-calendar"></i>Beyond 48 hrs </a>
                                                                </div>
                                                            </td>
                                                            <td style="width: 30px">
                                                                &nbsp;
                                                            </td>
                                                            <td style="width: 395px" valign="top">
                                                                <div class="list-group">
                                                                    <a class="list-group-item"><i class="fa fa-fw fa-check"></i>Inspection report not uploaded
                                                                    </a><a class="list-group-item" href="IncentiveStatusInspectionUploadDetailsNew.aspx?Stg=6">
                                                                        <span class="badge">
                                                                            <asp:Label ID="Label20" runat="server"></asp:Label>
                                                                        </span><i class="fa fa-fw fa-calendar"></i>With in 48 hrs </a><a class="list-group-item"
                                                                            href="IncentiveStatusInspectionUploadDetailsNew.aspx?Stg=7"><span class="badge" style="background-color: #d9534f;">
                                                                                <asp:Label ID="Label21" runat="server"></asp:Label>
                                                                            </span><i class="fa fa-fw fa-calendar"></i>Beyond 48 hrs </a>
                                                                </div>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                    <table runat="server" id="Table1" cellpadding="3" cellspacing="5" style="width: 100%">
                                                        <tr>
                                                            <td style="width: 395px" valign="top">
                                                                <%-- <div class="list-group">
                                                                    <a href="ListOfSLCGm.aspx?Stg=1" class="list-group-item">
                                                                        <i class="fa fa-fw fa-calendar"></i>Post DIPC
                                                                    </a>
                                                                </div>--%>
                                                                <div class="list-group">
                                                                    <%--<a href="ListOfSLCGm.aspx?Stg=2" class="list-group-item">--%>
                                                                    <a href="IncentiveWiseListGM.aspx?Stg=2" class="list-group-item"><span class="badge">
                                                                        <asp:Label ID="lblworkingstatus" runat="server"></asp:Label>
                                                                    </span><i class="fa fa-fw fa-calendar"></i>Confirm Working Status For Release (SLC)
                                                                    </a>
                                                                </div>
                                                            </td>
                                                            <td style="width: 30px">
                                                                &nbsp;
                                                            </td>
                                                            <td valign="top" style="width: 395px">
                                                                <div class="list-group">
                                                                    <%--<a href="ListOfSLCGm.aspx?Stg=2" class="list-group-item">--%>
                                                                    <%--<a href="IncentiveWiseSLClistGM.aspx?Stg=2" class="list-group-item"><span class="badge">--%>
                                                                    <a href="IncentiveWiseSLClist.aspx?Stg=4" class="list-group-item"><span class="badge">
                                                                        <asp:Label ID="lblslcapproved" runat="server"></asp:Label>
                                                                    </span><i class="fa fa-fw fa-calendar"></i>Approved by SLC </a>
                                                                </div>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="width: 395px" valign="top">
                                                                <%-- <div class="list-group">
                                                                    <a href="ListOfSLCGm.aspx?Stg=1" class="list-group-item">
                                                                        <i class="fa fa-fw fa-calendar"></i>Post DIPC
                                                                    </a>
                                                                </div>--%>
                                                                <div class="list-group">
                                                                    <%--<a href="ListOfSLCGm.aspx?Stg=2" class="list-group-item">--%>
                                                                    <a href="IncentiveWiseListGMDIPC.aspx?Stg=2" class="list-group-item"><span class="badge">
                                                                        <asp:Label ID="lblworkingstatusDLC" runat="server"></asp:Label>
                                                                    </span><i class="fa fa-fw fa-calendar"></i>Confirm Working Status For Release (DLC)
                                                                    </a>
                                                                </div>
                                                            </td>
                                                            <td style="width: 30px">
                                                                &nbsp;
                                                            </td>
                                                            <td valign="top" style="width: 395px">
                                                                <div class="list-group">
                                                                    <%--<a href="ListOfSLCGm.aspx?Stg=2" class="list-group-item">--%>
                                                                    <a href="DIPCApprovedlist.aspx?Stg=4" class="list-group-item"><span class="badge">
                                                                        <asp:Label ID="lbldlcapproved" runat="server"></asp:Label>
                                                                    </span><i class="fa fa-fw fa-calendar"></i>Approved by DLC </a>
                                                                </div>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="width: 395px" valign="top">
                                                                <div class="list-group">
                                                                    <a href="frmCheckDetailsprintReprint.aspx?Stg=5&Status=UC" class="list-group-item"><span
                                                                        class="badge">
                                                                        <asp:Label ID="Label32" runat="server"></asp:Label>
                                                                    </span><i class="fa fa-fw fa-calendar"></i>Print Working Status Updated List (SLC)
                                                                    </a>
                                                                </div>
                                                            </td>
                                                            <td style="width: 30px">
                                                                &nbsp;
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="width: 395px" valign="top">
                                                                <div class="list-group">
                                                                    <a href="frmCheckDetailsprintReprint.aspx?Stg=5&Status=UC&WorkingStatus=Abeyance"
                                                                        class="list-group-item"><span class="badge">
                                                                            <asp:Label ID="Label44" runat="server"></asp:Label>
                                                                        </span><i class="fa fa-fw fa-calendar"></i>Print Abeyanced Units List (SLC)
                                                                    </a>
                                                                </div>
                                                            </td>
                                                            <td style="width: 30px">
                                                                &nbsp;
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td valign="top" style="width: 395px;">
                                                                <div class="list-group">
                                                                    <a href="frmCheckDetailsprintReprint.aspx?Stg=5&Status=UC&DIPCFlag=Y" class="list-group-item">
                                                                        <span class="badge">
                                                                            <asp:Label ID="Label34" runat="server"></asp:Label>
                                                                        </span><i class="fa fa-fw fa-calendar"></i>Print Working Status Updated List (DLC)
                                                                    </a>
                                                                </div>
                                                            </td>
                                                            <td style="width: 30px">
                                                                &nbsp;
                                                            </td>
                                                            <td valign="top" style="width: 395px">
                                                                <div class="list-group">
                                                                    <a href="IncentiveWiseDIPClist.aspx?Stg=2&offlineflag=Y" class="list-group-item"><span
                                                                        class="badge">
                                                                        <asp:Label ID="Label33" runat="server"></asp:Label>
                                                                    </span><i class="fa fa-fw fa-calendar"></i>Approved by DLC (Legacy Data) </a>
                                                                </div>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="width: 395px" valign="top">
                                                                <div class="list-group">
                                                                    <a href="frmCheckDetailsprintReprint.aspx?Stg=5&Status=UC&WorkingStatus=Abeyance&DIPCFlag=Y"
                                                                        class="list-group-item"><span class="badge">
                                                                            <asp:Label ID="Label46" runat="server"></asp:Label>
                                                                        </span><i class="fa fa-fw fa-calendar"></i>Print Abeyanced Units List (DLC)
                                                                    </a>
                                                                </div>
                                                            </td>
                                                            <td style="width: 30px">
                                                                &nbsp;
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="3" style="height: 5px">
                                                                <div>
                                                                    <h1 class="page-head-linenew" align="left" style="font-size: smaller">
                                                                    </h1>
                                                                </div>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                    <table runat="server" id="tblAggrementBond" cellpadding="3" cellspacing="5" style="width: 100%">
                                                        <tr runat="server" visible="false">
                                                            <td style="width: 395px" valign="top">
                                                                <a class="list-group-item"><i class="fa fa-fw fa-check"></i><b>Aggrement bond uploaded</b>
                                                                </a>
                                                            </td>
                                                            <td style="width: 30px">
                                                                &nbsp;
                                                            </td>
                                                            <td valign="top" style="width: 395px">
                                                                <a class="list-group-item"><i class="fa fa-fw fa-check"></i><b>Aggrement bond uploaded</b>
                                                                </a>
                                                            </td>
                                                        </tr>
                                                        <tr runat="server" visible="false">
                                                            <td style="width: 395px" valign="top">
                                                                <div class="list-group">
                                                                    <a href="IncentiveWiseListGM.aspx?Stg=2&code=AgreemntBond" class="list-group-item"><span
                                                                        class="badge">
                                                                        <asp:Label ID="lblAgreementSLC" runat="server"></asp:Label>
                                                                    </span><i class="fa fa-fw fa-calendar"></i>Confirm Working Status For Release (SLC)
                                                                    </a>
                                                                </div>
                                                            </td>
                                                            <td style="width: 30px">
                                                                &nbsp;
                                                            </td>
                                                            <td style="width: 395px" valign="top">
                                                                <div class="list-group">
                                                                    <a class="list-group-item" href="IncentiveWiseListGMDIPC.aspx?Stg=2&code=AgreemntBond">
                                                                        <span class="badge">
                                                                            <asp:Label ID="lblAgreementSLC0" runat="server"></asp:Label>
                                                                        </span><i class="fa fa-fw fa-calendar"></i>Confirm Working Status For Release (DIPC)
                                                                    </a>
                                                                </div>
                                                            </td>
                                                        </tr>
                                                        <tr runat="server" visible="false">
                                                            <td colspan="3" style="height: 5px">
                                                                <div>
                                                                    <h1 class="page-head-linenew" align="left" style="font-size: smaller">
                                                                    </h1>
                                                                </div>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                    <table runat="server" id="Table2" cellpadding="3" cellspacing="5" style="width: 100%">
                                                        <tr>
                                                            <td style="width: 395px" valign="top">
                                                                <div class="list-group">
                                                                    <%-- <a href="IncentiveStatusInspectionUploadDetailsAddlView.aspx?Stg=4&SVCStatus=POSTSLC" class="list-group-item">--%>
                                                                    <a class="list-group-item" href="#"><i class="fa fa-fw fa-check"></i><b>Referred to
                                                                        DIPC (DIPC Dashboard) (Time Limit - 5 Days )</b> </a>
                                                                    <%--<a href="IncentiveWiseDIPClist.aspx?Stg=8"--%>
                                                                    <a href="DIPCApprovedlistOnline.aspx?Stg=9&ALLAPPSTATUS=ALL" class="list-group-item">
                                                                        <span class="badge">
                                                                            <asp:Label ID="lblslcrecved" runat="server"></asp:Label></span> <i class="fa fa-fw fa-calendar">
                                                                            </i><b>No of Applications Received</b> </a>
                                                                    <%-- <a href="frmDIPCDashBoardfinal.aspx" class="list-group-item">
                                                                        <span class="badge">
                                                                            <asp:Label ID="lblDIPCAgenda" runat="server"></asp:Label>
                                                                        </span>
                                                                        <i class="fa fa-fw fa-calendar"></i>Generate DIPC Agenda
                                                                    </a>--%>
                                                                    <a class="list-group-item"><i class="fa fa-fw fa-check"></i><b>Generate Agenda</b></a>
                                                                    <a href="frmDIPCDashBoardfinal.aspx?Stage=1" class="list-group-item"><span class="badge">
                                                                        <asp:Label ID="lblDIPCAgenda" runat="server"></asp:Label></span> <i class="fa fa-fw fa-calendar">
                                                                        </i>Within time limits </a><a href="frmDIPCDashBoardfinal.aspx?Stage=2" class="list-group-item">
                                                                            <span class="badge" style="background-color: #d9534f;">
                                                                                <asp:Label ID="lblDIPCAgenda2" runat="server"></asp:Label></span> <i class="fa fa-fw fa-calendar">
                                                                                </i>Beyond time limits </a><a href="frmDIPCDashBoardfinalSactionprint.aspx?Stage=3"
                                                                                    class="list-group-item"><span class="badge">
                                                                                        <asp:Label ID="Label28" runat="server"></asp:Label>
                                                                                    </span><i class="fa fa-fw fa-calendar"></i>Print Generated DIPC Agenda
                                                                    </a>
                                                                    <%--   <a class="list-group-item" href="frmDIPCDashBoardfinalSaction.aspx"><span class="badge">
                                                                        <asp:Label ID="lblDIPCUploadProc" runat="server"></asp:Label>
                                                                    </span><i class="fa fa-fw fa-calendar"></i>Upload DIPC Proceedings</a>--%>
                                                                    <a class="list-group-item"><i class="fa fa-fw fa-check"></i><b>Upload Proceedings</b></a>
                                                                    <a class="list-group-item" href="frmDIPCDashBoardfinalSaction.aspx?Stage=1"><span
                                                                        class="badge">
                                                                        <asp:Label ID="lblDIPCUploadProc" runat="server"></asp:Label></span> <i class="fa fa-fw fa-calendar">
                                                                        </i>Within time limits</a> <a class="list-group-item" href="frmDIPCDashBoardfinalSaction.aspx?Stage=2">
                                                                            <span class="badge" style="background-color: #d9534f;">
                                                                                <asp:Label ID="lblDIPCUploadProc2" runat="server"></asp:Label></span> <i class="fa fa-fw fa-calendar">
                                                                                </i>Beyond time limits</a>
                                                                </div>
                                                                <%-- <div class="list-group">
                                                                    <a href="IncentiveWiseDIPClist.aspx?Stg=4" class="list-group-item">
                                                                        <span class="badge">
                                                                            <asp:Label ID="lblDIPCReleasePendings" runat="server"></asp:Label></span>
                                                                        <i class="fa fa-fw fa-calendar"></i>Approved by DIPC
                                                                    </a>
                                                                </div>--%>
                                                            </td>
                                                            <td style="width: 30px">
                                                                &nbsp;
                                                            </td>
                                                            <td valign="top" style="width: 395px">
                                                                <div class="list-group">
                                                                    <a class="list-group-item"><i class="fa fa-fw fa-check"></i><b>Uploaded DIPC Proceedings
                                                                        (Completed)</b></a>
                                                                    <%--<a class="list-group-item" href="IncentiveWiseDIPClist.aspx?Stg=5">--%>
                                                                    <a class="list-group-item" href="DIPCApprovedlistOnline.aspx?Stg=5"><span class="badge">
                                                                        <asp:Label ID="lblDIPCReleasePendings" runat="server"></asp:Label>
                                                                    </span><i class="fa fa-fw fa-calendar"></i>Within 5 Days</a> <a class="list-group-item"
                                                                        href="DIPCApprovedlistOnline.aspx?Stg=6"><span class="badge" style="background-color: #d9534f;">
                                                                            <asp:Label ID="lblDIPCReleasePendings2" runat="server"></asp:Label>
                                                                        </span><i class="fa fa-fw fa-calendar"></i>Beyond 5 Days</a> <a class="list-group-item"
                                                                            href="DIPCApprovedlistOnline.aspx?Stg=7"><span class="badge" style="background-color: #d9534f;">
                                                                                <asp:Label ID="slcrejected" runat="server"></asp:Label>
                                                                            </span><i class="fa fa-fw fa-calendar"></i>Rejected</a>
                                                                </div>
                                                                <div class="list-group">
                                                                    <a class="list-group-item"><i class="fa fa-fw fa-check"></i><b>Abeyance Applications</b></a>
                                                                    <a class="list-group-item" href="frmDIPCDashBoardfinalSaction.aspx?Stage=4"><span
                                                                        class="badge" style="background-color: #d9534f;">
                                                                        <asp:Label ID="Label41" runat="server"></asp:Label>
                                                                    </span><i class="fa fa-fw fa-calendar"></i>Total Abeyance Applications</a>
                                                                </div>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </div>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr id="tr1" runat="server">
                                        <td colspan="3">
                                            <a class="list-group-item"><i class="fa fa-fw fa-check"></i><b>Cheque Details and Status
                                            </b></a><a href="UpdateCheckNumberListALL.aspx?Stg=51" class="list-group-item"><span
                                                class="badge">
                                                <asp:Label ID="Label43" runat="server"></asp:Label></span> <i class="fa fa-fw fa-calendar">
                                                </i>Cheque Details Cheque Number</a><a href="UpdateUTRNumberListALL.aspx?Stg=52"
                                                    class="list-group-item"><span class="badge">
                                                        <asp:Label ID="Label45" runat="server"></asp:Label></span> <i class="fa fa-fw fa-calendar">
                                                        </i>Cheque Details with UTR Number</a>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center" style="padding: 5px; margin: 5px">
                                            <table cellpadding="2" style="width: 100%">
                                                <tr>
                                                    <td style="width: 417px">
                                                        <%--<a href="DIC Login Incentive.doc" target="_blank">User Manual of DIC</a> --%>
                                                        <a href="DisplayDocs/IncentivesDepartmentFlowNew.PDF" target="_blank">User Manual of
                                                            DIC</a>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                                <asp:HiddenField ID="hdfID" runat="server" />
                                <asp:HiddenField ID="hdfFlagID" runat="server" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <br />
            <br />
            <br />
        </ContentTemplate>
    </asp:UpdatePanel>
  
</asp:Content>
