<%@ Page Title="" Language="C#" MasterPageFile="~/UI/TSiPASS/CCMaster.master" AutoEventWireup="true"
    CodeFile="frmCoiDashboard.aspx.cs" Inherits="UI_TSiPASS_frmCoiDashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script src="../../Resource/Scripts/js/validations.js" type="text/javascript"></script>
    <style type="text/css">
        .overlay
        {
            position: fixed;
            z-index: 999;
            height: 100%;
            width: 100%;
            top: 112px;
            background-color: Gray;
            filter: alpha(opacity=60);
            opacity: 0.9;
            -moz-opacity: 0.9;
        }
        
        .style10
        {
            width: 9px;
            height: 28px;
        }
        
        .style11
        {
            width: 210px;
            height: 28px;
        }
        
        .style12
        {
            width: 212px;
            height: 28px;
        }
        
        .style13
        {
            width: 210px;
            height: 21px;
        }
        
        .style14
        {
            width: 9px;
            height: 21px;
        }
        
        .style15
        {
            height: 21px;
        }
        
        .style16
        {
            width: 212px;
            height: 21px;
        }
        
        .style17
        {
            height: 28px;
        }
    </style>
    <script type="text/javascript" language="javascript">

        function OpenPopup() {

            window.open("Lookups/LookupBDC.aspx", "List", "scrollbars=yes,resizable=yes,width=1000,height=650;display = block;position=absolute");

            return false;
        }
    </script>
    <script type="text/javascript">
        function sumPropBulk() {
            var txtFirstNumberValue = document.getElementById('txtProsPetorlClassA').value;
            var txtSecondNumberValue = document.getElementById('txtPropPetolClassB').value;
            var txtThirdNumberValue = document.getElementById('txtPropPetolClassB').value;
            var result = parseInt(txtFirstNumberValue) + parseInt(txtSecondNumberValue) + parseInt(txtThirdNumberValue);
            if (!isNaN(result)) {
                document.getElementById('txtPropPetrolTotal').value = result;
            }
        }
    </script>
    <div align="center">
        <div class="row" align="center">
            <div class="col-lg-11">
                <div class="panel panel-primary">
                    <div class="panel-heading">
                        <h3 class="panel-title">
                            <span id="htitle">Joint Director&#39;s Dashboard </span>
                        </h3>
                    </div>
                    <div class="panel-body">
                        <table align="center" cellpadding="10" cellspacing="5" style="width: 100%">
                            <tr>
                                <td style="padding: 5px; margin: 5px">
                                    <div class="panel panel-default">
                                        <div class="panel-body" align="center">
                                            <table cellpadding="3" cellspacing="5" style="width: 100%">
                                                <tr>
                                                    <td style="width: 395px" valign="top">
                                                        <div class="list-group">
                                                            <a href="IncentiveStatusInspectionUploadbyCoi.aspx?Stg=1" class="list-group-item"><span
                                                                class="badge">
                                                                <asp:Label ID="lblAppl" runat="server"></asp:Label></span> <i class="fa fa-fw fa-calendar">
                                                                </i><b>No of Applications Received from G.M</b> </a><a class="list-group-item"><i
                                                                    class="fa fa-fw fa-check"></i>Scrutiny Pending </a><a class="list-group-item" href="IncentiveStatusInspectionUploadbyCoi.aspx?Stg=50">
                                                                        <span class="badge">
                                                                            <asp:Label ID="Label1" runat="server"></asp:Label>
                                                                        </span><i class="fa fa-fw fa-calendar"></i>Within 7 Days </a><a class="list-group-item"
                                                                            href="IncentiveStatusInspectionUploadbyCoi.aspx?Stg=51"><span class="badge" style="background-color: #d9534f;">
                                                                                <asp:Label ID="Label2" runat="server"></asp:Label>
                                                                            </span><i class="fa fa-fw fa-calendar"></i>Beyond 7 Days </a><a class="list-group-item"
                                                                                href="IncentiveStatusInspectionUploadbyCoi.aspx?Stg=80"><span class="badge">
                                                                                    <asp:Label ID="Label8" runat="server"></asp:Label>
                                                                                </span><i class="fa fa-fw fa-calendar"></i>Total </a><a href="IncentiveStatusInspectionUploadbyCoi.aspx?Stg=100"
                                                                                    class="list-group-item"><span class="badge">
                                                                                        <asp:Label ID="LabelForwarded" runat="server"></asp:Label></span> <i class="fa fa-fw fa-calendar">
                                                                                        </i><b>No of Applications Forwarded to JD</b> </a><a class="list-group-item"><i class="fa fa-fw fa-check">
                                                                                        </i>Forwarded to JD</a><a class="list-group-item" href="IncentiveStatusInspectionUploadbyCoi.aspx?Stg=101">
                                                                                            <span class="badge">
                                                                                                <asp:Label ID="lbladrecommended" runat="server"></asp:Label>
                                                                                            </span><i class="fa fa-fw fa-calendar"></i>Recommended to JD</a><a class="list-group-item"
                                                                                                href="IncentiveStatusInspectionUploadbyCoi.aspx?Stg=102"> <span class="badge">
                                                                                                    <asp:Label ID="LabelQueryAD" runat="server"></asp:Label>
                                                                                                </span><i class="fa fa-fw fa-calendar"></i>Query Forwarded to JD</a><a class="list-group-item"
                                                                                                    href="IncentiveStatusInspectionUploadbyCoi.aspx?Stg=103"> <span class="badge">
                                                                                                        <asp:Label ID="LabelJDReturned" runat="server"></asp:Label>
                                                                                                    </span><i class="fa fa-fw fa-calendar"></i>JD Returned</a><a class="list-group-item"
                                                                                                        href="IncentiveStatusInspectionUploadbyCoi.aspx?Stg=51r">
                                                        </div>
                                                    </td>
                                                    <td style="width: 30px">
                                                        &nbsp;
                                                    </td>
                                                    <td style="width: 395px" valign="top">
                                                        <div class="list-group" style="vertical-align: top">
                                                            <a class="list-group-item"><i class="fa fa-fw fa-check"></i><b>Queries</b></a> <a
                                                                href="IncentiveStatusInspectionUploadbyCoi.aspx?Stg=54" class="list-group-item">
                                                                <span class="badge">
                                                                    <asp:Label ID="Label5" runat="server"></asp:Label></span> <i class="fa fa-fw fa-calendar">
                                                                    </i>Queries Yet to Respond </a><a href="IncentiveStatusInspectionUploadbyCoi.aspx?Stg=83"
                                                                        class="list-group-item"><span class="badge">
                                                                            <asp:Label ID="Label10" runat="server"></asp:Label></span> <i class="fa fa-fw fa-calendar">
                                                                            </i>Queries Responded - Within</a> <a href="IncentiveStatusInspectionUploadbyCoi.aspx?Stg=84"
                                                                                class="list-group-item"><span class="badge" style="background-color: #d9534f;">
                                                                                    <asp:Label ID="Label11" runat="server"></asp:Label></span> <i class="fa fa-fw fa-calendar">
                                                                                    </i>Queries Responded - Beyond</a> <a href="IncentiveStatusInspectionUploadbyCoi.aspx?Stg=55"
                                                                                        class="list-group-item"><span class="badge">
                                                                                            <asp:Label ID="Label6" runat="server"></asp:Label></span> <i class="fa fa-fw fa-calendar">
                                                                                            </i>Total Queries Responded </a><a href="IncentiveStatusInspectionUploadDetailsnew.aspx?Stg=91"
                                                                                                class="list-group-item"><span class="badge">
                                                                                                    <asp:Label ID="lblAutorejected" runat="server"></asp:Label></span> <i class="fa fa-fw fa-calendar">
                                                                                                    </i>Total Auto Rejected</a> <a class="list-group-item"><i class="fa fa-fw fa-check">
                                                                                                    </i><b>Queries Responded/Forwarded to JD</b></a>
                                                            <a href="IncentiveStatusInspectionUploadbyCoi.aspx?Stg=104" class="list-group-item">
                                                                <span class="badge">
                                                                    <asp:Label ID="lblqueryforwardedtojd" runat="server"></asp:Label></span> <i class="fa fa-fw fa-calendar">
                                                                    </i>Queries Responded - Forwarded to JD</a> <a href="IncentiveStatusInspectionUploadbyCoi.aspx?Stg=105"
                                                                        class="list-group-item"><span class="badge" style="background-color: #d9534f;">
                                                                            <asp:Label ID="lblqueryraisedbyforqiery" runat="server"></asp:Label></span>
                                                                        <i class="fa fa-fw fa-calendar"></i>Queries Responded - Query Raised by AD</a>
                                                                        <a href="IncentiveStatusInspectionUploadbyCoi.aspx?Stg=205"
                                                                        class="list-group-item"><span class="badge" style="background-color: #d9534f;">
                                                                            <asp:Label ID="Label3" runat="server"></asp:Label></span>
                                                                        <i class="fa fa-fw fa-calendar"></i>Appraisal Note Print</a>
                                                        </div>
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
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
                            <tr>
                                <td valign="top" style="width: 395px">
                                    <div class="list-group">
                                        <a class="list-group-item" href="#"><i class="fa fa-fw fa-check"></i><b>Queries From
                                            Additional Director</b> </a><a class="list-group-item" href="IncentiveStatusInspectionUploadbyCoi.aspx?Stg=207">
                                                <span class="badge">
                                                    <asp:Label ID="lblQueriesRespondedbyGM" runat="server"></asp:Label>
                                                </span><i class="fa fa-fw fa-calendar"></i>Queries Responded by GM</a>
                                    </div>
                                </td>
                            </tr>
                        </table>
                        <table align="center" cellpadding="10" cellspacing="5" style="width: 100%">
                            <tr id="trIncentivesHead" runat="server" visible="false">
                                <td valign="top" style="width: 395px">
                                    <div class="list-group">
                                        <a href="IncentiveWiseSLClistGMADSubPlan.aspx?Stg=4" class="list-group-item"><span
                                            class="badge">
                                            <asp:Label ID="lblReleasePendings" runat="server"></asp:Label></span> <i class="fa fa-fw fa-calendar">
                                            </i>Approved by SLC </a>
                                    </div>
                                    <div class="list-group" style="display: none">
                                        <a href="ReleaseProcedingsStep2CompletedListPrint.aspx?Stg=5" class="list-group-item">
                                            <span class="badge">
                                                <asp:Label ID="lblReleaseProceedingsCmpltdList" runat="server"></asp:Label></span>
                                            <i class="fa fa-fw fa-calendar"></i>Print SLC Release Proceedings Completed List
                                        </a>
                                    </div>
                                    <div class="list-group" style="display: none">
                                        <a href="frmCheckDetailsprintReprint.aspx?Stg=5" class="list-group-item"><span class="badge">
                                            <asp:Label ID="Label16" runat="server"></asp:Label></span> <i class="fa fa-fw fa-calendar">
                                            </i>Reprint-Working Status Updated List </a>
                                    </div>
                                </td>
                                <td style="width: 30px">
                                </td>
                                <td valign="top" style="width: 395px">
                                    <div class="list-group" style="display: none">
                                        <a href="IncentiveWiseDIPClist.aspx?Stg=4" class="list-group-item"><span class="badge">
                                            <asp:Label ID="lblDIPCReleasePendings" runat="server"></asp:Label></span> <i class="fa fa-fw fa-calendar">
                                            </i>Approved by DIPC </a>
                                    </div>
                                    <div class="list-group">
                                        <a href="IncentiveWiseDIPClist.aspx?Stg=2&offlineflag=Y" class="list-group-item"><span
                                            class="badge">
                                            <asp:Label ID="Label33" runat="server"></asp:Label>
                                        </span><i class="fa fa-fw fa-calendar"></i>Approved by DLC (Legacy Data) </a>
                                    </div>
                                    <div class="list-group" style="display: none">
                                        <a href="ReleaseProcedingsStep2CompletedListPrintDIPC.aspx?stg=5" class="list-group-item">
                                            <span class="badge">
                                                <asp:Label ID="Label17" runat="server"></asp:Label></span> <i class="fa fa-fw fa-calendar">
                                                </i>Print DIPC Release Proceedings Completed List </a>
                                    </div>
                                    <div class="list-group" style="display: none">
                                        <a href="#" class="list-group-item"><span class="badge">
                                            <asp:Label ID="Label18" runat="server"></asp:Label></span> <i class="fa fa-fw fa-calendar">
                                            </i>Reprint-Working Status Updated List for DIPC </a>
                                    </div>
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
    <script type="text/javascript">

        var Role = '<%=HttpContext.Current.Session["Role_Code"]%>';

        if (Role == "COI-DD") {
            $('#htitle').html('Deputy Director&#39;s Dashboard');
        }

        if (Role == "COI-AD") {
            $('#htitle').html('Associate  Director&#39;s Dashboard');
        }

    </script>
</asp:Content>
