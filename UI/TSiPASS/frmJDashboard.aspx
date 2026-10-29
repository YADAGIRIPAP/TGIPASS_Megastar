<%@ page title="" language="C#" masterpagefile="~/UI/TSiPASS/CCMaster.master" autoeventwireup="true"
    codefile="frmJDashboard.aspx.cs" inherits="UI_TSiPASS_frmJDashboard" %>

<asp:content id="Content1" contentplaceholderid="ContentPlaceHolder1" runat="Server">
    <script src="../../Resource/Scripts/js/validations.js" type="text/javascript"></script>
    <style type="text/css">
        .overlay {
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

        .style10 {
            width: 9px;
            height: 28px;
        }

        .page-head-linenew {
            font-size: 2px;
            text-transform: uppercase;
            color: #000;
            font-weight: 800;
            padding-bottom: 2px;
            border-bottom: 4px solid #00CA79;
            margin-bottom: 35px;
        }

        .style11 {
            width: 210px;
            height: 28px;
        }

        .style12 {
            width: 212px;
            height: 28px;
        }

        .style13 {
            width: 210px;
            height: 21px;
        }

        .style14 {
            width: 9px;
            height: 21px;
        }

        .style15 {
            height: 21px;
        }

        .style16 {
            width: 212px;
            height: 21px;
        }

        .style17 {
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
            <div class="col-lg-12">
                <div class="panel panel-primary">
                    <div class="panel-heading">
                        <h3 class="panel-title">Joint Director&#39;s Dashboard</h3>
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
                                                            <a href="IncentiveStatusInspectionUploadDetailsnew.aspx?Stg=1" class="list-group-item">
                                                                <span class="badge">
                                                                    <asp:label id="lblAppl" runat="server"></asp:label>
                                                                </span><i class="fa fa-fw fa-calendar"></i><b>No of Applications Received from G.M</b> </a><a class="list-group-item"><i
                                                                    class="fa fa-fw fa-check"></i>Scrutiny Pending </a><a class="list-group-item" href="IncentiveStatusInspectionUploadDetailsnew.aspx?Stg=50">
                                                                        <span class="badge">
                                                                            <asp:label id="Label1" runat="server"></asp:label>
                                                                        </span><i class="fa fa-fw fa-calendar"></i>Within 7 Days </a><a class="list-group-item"
                                                                            href="IncentiveStatusInspectionUploadDetailsnew.aspx?Stg=51"><span class="badge"
                                                                                style="background-color: #d9534f;">
                                                                                <asp:label id="Label2" runat="server"></asp:label>
                                                                            </span><i class="fa fa-fw fa-calendar"></i>Beyond 7 Days </a>
                                                            <a class="list-group-item" href="IncentiveStatusInspectionUploadDetailsnew.aspx?Stg=80">
                                                                <span class="badge">
                                                                    <asp:label id="Label8" runat="server"></asp:label>
                                                                </span><i class="fa fa-fw fa-calendar"></i>Total </a><a class="list-group-item"><i
                                                                    class="fa fa-fw fa-check"></i><b>Application forwarded from AD/DD</b></a><a class="list-group-item"
                                                                        href="IncentiveStatusInspectionUploadDetailsnew.aspx?Stg=600"> <span class="badge">
                                                                            <asp:label id="lbladddforwardedwithin" runat="server"></asp:label>
                                                                        </span><i class="fa fa-fw fa-calendar"></i>Within 7 Days </a><a class="list-group-item"
                                                                            href="IncentiveStatusInspectionUploadDetailsnew.aspx?Stg=601"><span class="badge"
                                                                                style="background-color: #d9534f;">
                                                                                <asp:label id="lbladdforwardedbeyond" runat="server"></asp:label>
                                                                            </span><i class="fa fa-fw fa-calendar"></i>Beyond 7 Days </a><a class="list-group-item"
                                                                                href="IncentiveStatusInspectionUploadDetailsnew.aspx?Stg=603"><span class="badge">
                                                                                    <asp:label id="lbladdforwardedtotal" runat="server"></asp:label>
                                                                                </span><i class="fa fa-fw fa-calendar"></i>Total </a>
                                                            <a class="list-group-item"
                                                                href="IncentiveStatusInspectionUploadDetailsnew.aspx?Stg=1000"><span class="badge">
                                                                    <asp:label id="lblsvcreturned" runat="server"></asp:label>
                                                                </span><i class="fa fa-fw fa-calendar"></i>Departments Returned Applications-svc </a>
                                                            <a href="Departmentwiseapprovalstatus.aspx" class="list-group-item">
                                                                <span class="badge" style="background-color: green;">
                                                                    <%--<asp:label id="lblDeptprocessed" runat="server"></asp:label>--%>
                                                                </span>
                                                                <i class="fa fa-fw fa-calendar"></i><b>Departments Processed Applications (SVC)</b> </a>
                                                        </div>
                                                        <a class="list-group-item"><i class="fa fa-fw fa-check"></i><b>Scrutiny Completed &
                                                            Forwarded to Additional Director</b></a> <a class="list-group-item" href="IncentiveStatusInspectionUploadDetailsnew.aspx?Stg=52">
                                                                <span class="badge">
                                                                    <asp:label id="Label3" runat="server"></asp:label>
                                                                </span><i class="fa fa-fw fa-calendar"></i>Within 7 Days </a><a class="list-group-item"
                                                                    href="IncentiveStatusInspectionUploadDetailsnew.aspx?Stg=53"><span class="badge"
                                                                        style="background-color: #d9534f;">
                                                                        <asp:label id="Label4" runat="server"></asp:label>
                                                                    </span><i class="fa fa-fw fa-calendar"></i>Beyond 7 Days </a><a class="list-group-item"
                                                                        href="IncentiveStatusInspectionUploadDetailsnew.aspx?Stg=81"><span class="badge">
                                                                            <asp:label id="Label9" runat="server"></asp:label>
                                                                        </span><i class="fa fa-fw fa-calendar"></i>Total </a><a href="IncentiveStatusInspectionUploadDetailsnew.aspx?Stg=82"
                                                                            class="list-group-item"><span class="badge">
                                                                                <asp:label id="lblrej" runat="server"></asp:label>
                                                                            </span><i class="fa fa-fw fa-calendar"></i>Rejected Applications </a>
                                        </div>
                                </td>
                                <td style="width: 30px">&nbsp;
                                </td>
                                <td style="width: 395px" valign="top">
                                    <div class="list-group" style="vertical-align: top">
                                        <a class="list-group-item"><i class="fa fa-fw fa-check"></i><b>Queries</b></a> <a
                                            href="IncentiveStatusInspectionUploadDetailsnew.aspx?Stg=54" class="list-group-item">
                                            <span class="badge">
                                                <asp:label id="Label5" runat="server"></asp:label>
                                            </span><i class="fa fa-fw fa-calendar"></i>Queries Yet to Respond </a><a href="IncentiveStatusInspectionUploadDetailsnew.aspx?Stg=83"
                                                class="list-group-item"><span class="badge">
                                                    <asp:label id="Label10" runat="server"></asp:label>
                                                </span><i class="fa fa-fw fa-calendar"></i>Queries Responded - Within</a> <a href="IncentiveStatusInspectionUploadDetailsnew.aspx?Stg=84"
                                                    class="list-group-item"><span class="badge" style="background-color: #d9534f;">
                                                        <asp:label id="Label11" runat="server"></asp:label>
                                                    </span><i class="fa fa-fw fa-calendar"></i>Queries Responded - Beyond</a> <a href="IncentiveStatusInspectionUploadDetailsnew.aspx?Stg=55"
                                                        class="list-group-item"><span class="badge">
                                                            <asp:label id="Label6" runat="server"></asp:label>
                                                        </span><i class="fa fa-fw fa-calendar"></i>Total Queries Responded </a>
                                        <a href="IncentiveStatusInspectionUploadDetailsnew.aspx?Stg=91"
                                                            class="list-group-item"><span class="badge">
                                                                <asp:label id="lblAutorejected" runat="server"></asp:label>
                                                            </span><i class="fa fa-fw fa-calendar"></i>Total Auto Rejected</a>
                                        <a href="IncentiveStatusInspectionUploadDetailsnew.aspx?Stg=911"  runat="server" visible="false"
                                                                            class="list-group-item"><span class="badge">
                                                                                <asp:Label ID="LBLAUTOREJECTEDGENERAL" runat="server"></asp:Label></span> <i class="fa fa-fw fa-calendar">
                                                                                </i>Total Auto Rejected_General</a>
                                        <%-- <a href="IncentiveStatusInspectionUploadDetailsnew.aspx?Stg=56"
                                                                                class="list-group-item"><span class="badge">
                                                                                    <asp:Label ID="Label7" runat="server"></asp:Label></span> <i class="fa fa-fw fa-calendar">
                                                                                    </i>Total Queries Raised </a>--%>
                                        <a href="IncentiveStatusInspectionUploadDetailsnew.aspx?Stg=604" class="list-group-item">
                                            <span class="badge">
                                                <asp:label id="lblqueryadddforwardedwithin" runat="server"></asp:label>
                                            </span>
                                            <i class="fa fa-fw fa-calendar"></i>Queries Responded - Within</a> <a href="IncentiveStatusInspectionUploadDetailsnew.aspx?Stg=605"
                                                class="list-group-item"><span class="badge" style="background-color: #d9534f;">
                                                    <asp:label id="lblqueryadddforwardedbeyond" runat="server"></asp:label>
                                                </span>
                                                <i class="fa fa-fw fa-calendar"></i>Queries Responded - Beyond</a> <a href="IncentiveStatusInspectionUploadDetailsnew.aspx?Stg=606"
                                                    class="list-group-item"><span class="badge">
                                                        <asp:label id="lblqueryadddforwardedtotal" runat="server"></asp:label>
                                                    </span>
                                                    <i class="fa fa-fw fa-calendar"></i>Total Queries Responded </a>
                                    </div>
                                    <div class="list-group" style="vertical-align: top">
                                        <a class="list-group-item"><i class="fa fa-fw fa-check"></i><b>Applications kept Abeyance
                                            at Superintendent</b></a> <a href="IncentiveStatusInspectionUploadDetailsnew.aspx?Stg=85"
                                                class="list-group-item"><span class="badge">
                                                    <asp:label id="Label7" runat="server"></asp:label>
                                                </span><i class="fa fa-fw fa-calendar"></i>Total Abeyance Applications </a>
                                    </div>
                                    <div class="list-group" style="vertical-align: top">
                                        <a class="list-group-item"><i class="fa fa-fw fa-check"></i><b>Status of Applications
                                            at Additional Director</b></a> <a href="IncentiveStatusInspectionUploadDetailsnew.aspx?Stg=201"
                                                class="list-group-item"><span class="badge">
                                                    <asp:label id="Label23" runat="server"></asp:label>
                                                </span><i class="fa fa-fw fa-calendar"></i>Total Abeyance Applications </a><a href="IncentiveStatusInspectionUploadDetailsnew.aspx?Stg=202"
                                                    class="list-group-item"><span class="badge">
                                                        <asp:label id="lblrejadditional" runat="server"></asp:label>
                                                    </span><i class="fa fa-fw fa-calendar"></i>Rejected at Pre-SVC </a><a class="list-group-item" href="IncentiveStatusInspectionUploadDetailsnew.aspx?Stg=203">
                                                        <span class="badge" style="background-color: #d9534f;">
                                                            <asp:label id="Label15" runat="server"></asp:label>
                                                        </span><i class="fa fa-fw fa-calendar"></i>Rejected at SVC</a>
                                        <a class="list-group-item" href="IncentiveStatusInspectionUploadDetailsnew.aspx?Stg=204">
                                            <span class="badge" style="background-color: #d9534f;">
                                                <asp:label id="slcrejected" runat="server"></asp:label>
                                            </span><i class="fa fa-fw fa-calendar"></i>Rejected at SLC</a>
                                    </div>
                                </td>
                            </tr>
                            <tr id="ad1" runat="server" visible="false">
                                <td colspan="3" style="height: 5px">
                                    <div>
                                        <h1 class="page-head-linenew" align="left" style="font-size: smaller"></h1>
                                    </div>
                                </td>
                            </tr>
                            <tr id="ad2" runat="server" visible="false">
                                <td valign="top" style="width: 395px">
                                    <div class="list-group">
                                        <a href="IncentiveStatusInspectionUploadDetailsnew.aspx?Stg=100" class="list-group-item">
                                            <span class="badge">
                                                <asp:label id="LabelForwarded" runat="server"></asp:label>
                                            </span><i class="fa fa-fw fa-calendar"></i><b>No of Applications Forwarded from AD</b> </a><a class="list-group-item"><i
                                                class="fa fa-fw fa-check"></i>Forwarded to JD</a><a class="list-group-item" href="IncentiveStatusInspectionUploadDetailsnew.aspx?Stg=101">
                                                    <span class="badge">
                                                        <asp:label id="lbladrecommended" runat="server"></asp:label>
                                                    </span><i class="fa fa-fw fa-calendar"></i>Recommended from AD</a><a class="list-group-item"
                                                        href="IncentiveStatusInspectionUploadDetailsnew.aspx?Stg=102"> <span class="badge">
                                                            <asp:label id="LabelQueryAD" runat="server"></asp:label>
                                                        </span><i class="fa fa-fw fa-calendar"></i>Query Raised from AD</a><a class="list-group-item"
                                                            href="IncentiveStatusInspectionUploadDetailsnew.aspx?Stg=103"> <span class="badge">
                                                                <asp:label id="LabelJDReturned" runat="server"></asp:label>
                                                            </span><i class="fa fa-fw fa-calendar"></i>Returned to AD</a><a class="list-group-item"
                                                                href="IncentiveStatusInspectionUploadDetailsnew.aspx?Stg=109"></a>
                                    </div>
                                </td>
                                <td style="width: 30px">&nbsp;
                                </td>
                                <td style="width: 395px" valign="top">
                                    <div class="list-group" style="vertical-align: top">
                                        <a class="list-group-item"><i class="fa fa-fw fa-check"></i><b>Queries Responded/Forwarded
                                            to JD</b></a> <a href="IncentiveStatusInspectionUploadDetailsnew.aspx?Stg=104" class="list-group-item">
                                                <span class="badge">
                                                    <asp:label id="lblqueryforwardedtojd" runat="server"></asp:label>
                                                </span><i class="fa fa-fw fa-calendar"></i>Queries Responded - Forwarded from AD</a> <a href="IncentiveStatusInspectionUploadDetailsnew.aspx?Stg=105"
                                                    class="list-group-item"><span class="badge" style="background-color: #d9534f;">
                                                        <asp:label id="lblqueryraisedbyforqiery" runat="server"></asp:label>
                                                    </span>
                                                    <i class="fa fa-fw fa-calendar"></i>Queries Responded - Query Raised by AD</a>
                                    </div>
                                </td>
                            </tr>
                            <tr id="ad3" runat="server" visible="false">
                                <td colspan="3" style="height: 5px">
                                    <div>
                                        <h1 class="page-head-linenew" align="left" style="font-size: smaller"></h1>
                                    </div>
                                </td>
                            </tr>
                            <tr id="dd1" runat="server" visible="false">
                                <td colspan="3" style="height: 5px">
                                    <div>
                                        <h1 class="page-head-linenew" align="left" style="font-size: smaller"></h1>
                                    </div>
                                </td>
                            </tr>
                            <tr id="dd2" runat="server" visible="false">
                                <td valign="top" style="width: 395px">
                                    <div class="list-group">
                                        <a href="IncentiveStatusInspectionUploadDetailsnew.aspx?Stg=500" class="list-group-item">
                                            <span class="badge">
                                                <asp:label id="LabelForwardedDD" runat="server"></asp:label>
                                            </span><i class="fa fa-fw fa-calendar"></i><b>No of Applications Forwarded from DD</b> </a><a class="list-group-item"><i
                                                class="fa fa-fw fa-check"></i>Forwarded to JD</a><a class="list-group-item" href="IncentiveStatusInspectionUploadDetailsnew.aspx?Stg=501">
                                                    <span class="badge">
                                                        <asp:label id="lblDDrecommended" runat="server"></asp:label>
                                                    </span><i class="fa fa-fw fa-calendar"></i>Recommended from DD</a><a class="list-group-item"
                                                        href="IncentiveStatusInspectionUploadDetailsnew.aspx?Stg=502"> <span class="badge">
                                                            <asp:label id="LabelQueryDD" runat="server"></asp:label>
                                                        </span><i class="fa fa-fw fa-calendar"></i>Query Raised from DD</a><a class="list-group-item"
                                                            href="IncentiveStatusInspectionUploadDetailsnew.aspx?Stg=503"> <span class="badge">
                                                                <asp:label id="LabelJDReturnedDD" runat="server"></asp:label>
                                                            </span><i class="fa fa-fw fa-calendar"></i>Returned to DD</a><a class="list-group-item"
                                                                href="IncentiveStatusInspectionUploadDetailsnew.aspx?Stg=504">
                                    </div>
                                </td>
                                <td style="width: 30px">&nbsp;
                                </td>
                                <td style="width: 395px" valign="top">
                                    <div class="list-group" style="vertical-align: top">
                                        <a class="list-group-item"><i class="fa fa-fw fa-check"></i><b>Queries Responded/Forwarded
                                            to JD from DD</b></a> <a href="IncentiveStatusInspectionUploadDetailsnew.aspx?Stg=506"
                                                class="list-group-item"><span class="badge">
                                                    <asp:label id="lblqueryforwardedtodd" runat="server"></asp:label>
                                                </span><i class="fa fa-fw fa-calendar"></i>Queries Responded - Forwarded from DD</a> <a href="IncentiveStatusInspectionUploadDetailsnew.aspx?Stg=507"
                                                    class="list-group-item"><span class="badge" style="background-color: #d9534f;">
                                                        <asp:label id="lblqueryraisedbyforqierydd" runat="server"></asp:label>
                                                    </span>
                                                    <i class="fa fa-fw fa-calendar"></i>Queries Responded - Query Raised by DD</a>
                                    </div>
                                </td>
                            </tr>
                            <tr id="dd3" runat="server" visible="false">
                                <td colspan="3" style="height: 5px">
                                    <div>
                                        <h1 class="page-head-linenew" align="left" style="font-size: smaller"></h1>
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="3" style="height: 5px">
                                    <div>
                                        <h1 class="page-head-linenew" align="left" style="font-size: smaller"></h1>
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td valign="top" style="width: 395px">
                                    <div class="list-group">
                                        <a class="list-group-item" href="#"><i class="fa fa-fw fa-check"></i><b>Queries From
                                            Additional Director</b> </a><a class="list-group-item" href="IncentiveStatusInspectionUploadDetailsnew.aspx?Stg=206">
                                                <span class="badge">
                                                    <asp:label id="lbladdlquerypendinggm" runat="server"></asp:label>
                                                </span><i class="fa fa-fw fa-calendar"></i>Queries Not Yet Responded by GM</a>
                                        <a class="list-group-item" href="IncentiveStatusInspectionUploadDetailsnew.aspx?Stg=207">
                                            <span class="badge">
                                                <asp:label id="lblQueriesRespondedbyGM" runat="server"></asp:label>
                                            </span><i class="fa fa-fw fa-calendar"></i>Queries Responded by GM</a>
                                    </div>
                                </td>
                                <td style="width: 30px">&nbsp;
                                </td>
                                <td style="width: 395px" valign="top">
                                    <div class="list-group" style="vertical-align: top">
                                        <a class="list-group-item" href="IncentiveStatusInspectionUploadDetailsnew.aspx?Stg=208">
                                            <span class="badge">
                                                <asp:label id="lblQueriesRespondedbyJD" runat="server"></asp:label>
                                            </span><i class="fa fa-fw fa-calendar"></i>Total -Queries Responded by JD</a>
                                        <a class="list-group-item" href="IncentiveStatusInspectionUploadDetailsnew.aspx?Stg=209">
                                            <span class="badge">
                                                <asp:label id="lbltotalqueryraisedaddl" runat="server"></asp:label>
                                            </span><i class="fa fa-fw fa-calendar"></i>Total - Query Raised by Additional Director</a>
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="3" style="height: 5px">
                                    <div>
                                        <h1 class="page-head-linenew" align="left" style="font-size: smaller"></h1>
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td valign="top" style="width: 395px">
                                    <div class="list-group">
                                        <%-- <a href="ListofSCLS.aspx?Stg=4" class="list-group-item">--%>
                                        <a href="IncentiveWiseSLClist.aspx?Stg=4" class="list-group-item"><span class="badge">
                                            <asp:label id="Label12" runat="server"></asp:label>
                                        </span><i class="fa fa-fw fa-calendar"></i>Approved by SLC </a>
                                    </div>
                                    <div class="list-group">
                                        <%-- <a href="ListofSCLS.aspx?Stg=5" class="list-group-item">--%>
                                        <a class="list-group-item"><i class="fa fa-fw fa-check"></i><b>Releases</b></a>
                                        <a href="ReleaseProcedingsStep2CompletedListPrint.aspx?Stg=5" class="list-group-item">
                                            <span class="badge">
                                                <asp:label id="lblReleaseProceedingsCmpltdList" runat="server"></asp:label>
                                            </span>
                                            <i class="fa fa-fw fa-calendar"></i>Print SLC Release Proceedings Completed List
                                        </a>
                                    </div>
                                    <div class="list-group">
                                        <a class="list-group-item"><i class="fa fa-fw fa-check"></i><b>Working Status</b></a>
                                        <a href="frmCheckDetailsprintReprint.aspx?Stg=5&Status=UC" class="list-group-item"><span
                                            class="badge">
                                            <asp:label id="Label16" runat="server"></asp:label>
                                        </span><i class="fa fa-fw fa-calendar"></i>Working Status Updated by Gm's </a><a href="frmCheckDetailsprintReprint.aspx?Stg=6&Status=NUC"
                                            class="list-group-item"><span class="badge">
                                                <asp:label id="Label24" runat="server"></asp:label>
                                            </span><i class="fa fa-fw fa-calendar"></i>Working Status Not Updated by Gm's</a>
                                    </div>
                                    <div class="list-group">
                                        <a class="list-group-item"><i class="fa fa-fw fa-check"></i><b>Cheque Preparation</b></a>
                                        <a href="frmCheckDetailsprint.aspx?Stg=5&Status=Pending" class="list-group-item"><span
                                            class="badge">
                                            <asp:label id="Label13" runat="server"></asp:label>
                                        </span><i class="fa fa-fw fa-calendar"></i>Pending for generating Cheque</a> <a href="frmCheckDetailsprintGenerated.aspx?Stg=5&Status=Generated"
                                            class="list-group-item"><span class="badge">
                                                <asp:label id="Label25" runat="server"></asp:label>
                                            </span><i class="fa fa-fw fa-calendar"></i>Generated Cheque Preparation</a>
                                    </div>
                                    <div class="list-group">
                                        <a class="list-group-item"><i class="fa fa-fw fa-check"></i><b>Update Cheque Details</b></a>
                                        <a href="UpdateCheckList.aspx?Stg=5" class="list-group-item"><span class="badge">
                                            <asp:label id="Label14" runat="server"></asp:label>
                                        </span><i class="fa fa-fw fa-calendar"></i>Upload Cheque Details for SLC </a><a href="UpdateCheckClearence.aspx?Stg=5" class="list-group-item">
                                            <span class="badge">
                                                <asp:label id="Label19" runat="server"></asp:label>
                                            </span><i class="fa fa-fw fa-calendar"></i>Upload Cheque Clearence Details</a>
                                    </div>
                                    <div class="list-group">
                                        <a class="list-group-item"><i class="fa fa-fw fa-check"></i><b>Update Cheque Details
                                            New</b></a> <a href="UpdateCheckListALL.aspx?Stg=50" class="list-group-item"><span
                                                class="badge">
                                                <asp:label id="Label36" runat="server"></asp:label>
                                            </span><i class="fa fa-fw fa-calendar"></i>Cheque Details Not Uploaded</a><a href="UpdateCheckNumberListALL.aspx?Stg=51"
                                                class="list-group-item"><span class="badge">
                                                    <asp:label id="Label37" runat="server"></asp:label>
                                                </span><i class="fa fa-fw fa-calendar"></i>Cheque Details Cheque Number</a><a href="UpdateUTRNumberListALL.aspx?Stg=52"
                                                    class="list-group-item"><span class="badge">
                                                        <asp:label id="Label38" runat="server"></asp:label>
                                                    </span><i class="fa fa-fw fa-calendar"></i>Cheque Details with UTR Number</a>
                                    </div>
                                </td>
                                <td style="width: 30px"></td>
                                <td valign="top" style="width: 395px">
                                    <div class="list-group">
                                        <%-- <a href="ListofSCLS.aspx?Stg=4" class="list-group-item">--%>
                                        <%-- <a href="IncentiveWiseDIPClist.aspx?Stg=4" class="list-group-item"><span class="badge">--%>
                                        <a href="DIPCApprovedlist.aspx?Stg=4" class="list-group-item"><span class="badge">
                                            <asp:label id="lblDIPCReleasePendings" runat="server"></asp:label>
                                        </span><i class="fa fa-fw fa-calendar"></i>Approved by DIPC </a>
                                    </div>
                                    <%--<div class="list-group">
                                                            <a href="IncentiveWiseDIPClist.aspx?Stg=2&offlineflag=Y" class="list-group-item"><span
                                                                class="badge">
                                                                <asp:Label ID="Label33" runat="server"></asp:Label>
                                                            </span><i class="fa fa-fw fa-calendar"></i>Approved by DLC (Legacy Data) </a>
                                                        </div>--%>
                                    <div class="list-group">
                                        <%-- <a href="ListofSCLS.aspx?Stg=5" class="list-group-item">--%>
                                        <a class="list-group-item"><i class="fa fa-fw fa-check"></i><b>Releases</b></a>
                                        <a href="ReleaseProcedingsStep2CompletedListPrintDIPC.aspx?stg=5" class="list-group-item">
                                            <span class="badge">
                                                <asp:label id="Label17" runat="server"></asp:label>
                                            </span><i class="fa fa-fw fa-calendar"></i>Print DIPC Release Proceedings Completed List </a>
                                    </div>
                                    <div class="list-group">
                                        <a class="list-group-item"><i class="fa fa-fw fa-check"></i><b>UC List</b></a> <a
                                            href="frmCheckDetailsprintReprint.aspx?Stg=5&Status=UC&DIPCFlag=Y" class="list-group-item">
                                            <span class="badge">
                                                <asp:label id="Label26" runat="server"></asp:label>
                                            </span><i class="fa fa-fw fa-calendar"></i>Working Status Updated by Gm's</a><a href="frmCheckDetailsprintReprint.aspx?Stg=6&Status=NUC&DIPCFlag=Y"
                                                class="list-group-item"><span class="badge">
                                                    <asp:label id="Label27" runat="server"></asp:label>
                                                </span><i class="fa fa-fw fa-calendar"></i>Working Status Not Updated by Gm's</a>
                                    </div>
                                    <div class="list-group">
                                        <a class="list-group-item"><i class="fa fa-fw fa-check"></i><b>Cheque Preparation</b></a>
                                        <a href="frmCheckDetailsprint.aspx?Stg=5&DIPCFlag=Y" class="list-group-item"><span
                                            class="badge">
                                            <asp:label id="lblGenCHeckListforDIPC" runat="server"></asp:label>
                                        </span><i class="fa fa-fw fa-calendar"></i>Pending for generating Cheque for DIPC </a><a href="frmCheckDetailsprintGenerated.aspx?Stg=5&DIPCFlag=Y"
                                            class="list-group-item"><span class="badge">
                                                <asp:label id="Label18" runat="server"></asp:label>
                                            </span><i class="fa fa-fw fa-calendar"></i>Generated Cheque Preparation </a>
                                    </div>
                                    <div class="list-group">
                                        <a class="list-group-item"><i class="fa fa-fw fa-check"></i><b>Update Cheque Details</b></a>
                                        <a href="UpdateCheckList.aspx?Stg=5&DIPCFlag=Y" class="list-group-item"><span class="badge">
                                            <asp:label id="Label20" runat="server"></asp:label>
                                        </span><i class="fa fa-fw fa-calendar"></i>Upload Cheque Details for DIPC </a><a href="UpdateCheckClearence.aspx?Stg=5&DIPCFlag=Y"
                                            class="list-group-item"><span class="badge">
                                                <asp:label id="Label21" runat="server"></asp:label>
                                            </span><i class="fa fa-fw fa-calendar"></i>Upload Cheque Clearence Details for DIPC </a>
                                    </div>
                                    <div class="list-group">
                                        <a class="list-group-item"><i class="fa fa-fw fa-check"></i><b>Update Cheque Details
                                                                New</b></a> <a href="UpdateCheckClearenceNew.aspx?Stg=53" class="list-group-item"><span
                                                                    class="badge">
                                                                    <asp:label id="Label33" runat="server"></asp:label>
                                                                </span><i class="fa fa-fw fa-calendar"></i>Enter UTR Details with Cheque No</a><a href="ChequeStatusNew.aspx?Stg=54" class="list-group-item"><span
                                                                    class="badge">
                                                                    <asp:label id="Label34" runat="server"></asp:label>
                                                                </span><i class="fa fa-fw fa-calendar"></i>Cheque Status </a>
                                        <%--<a href="UpdateUTRNumberListALL.aspx?Stg=52"
                                                                                class="list-group-item"><span class="badge">
                                                                                    <asp:Label ID="Label35" runat="server"></asp:Label></span> <i class="fa fa-fw fa-calendar">
                                                                                    </i>Cheque Details with UTR Number</a>--%>
                                    </div>
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
                </td> </tr>
                <tr>
                    <td align="center" style="padding: 5px; margin: 5px">
                        <table cellpadding="2" style="width: 100%">
                            <tr>
                                <td style="width: 417px">
                                    <a href="IPO Login.doc" target="_blank">User Manual of IPO/DD/AD</a>
                                </td>
                            </tr>
                    </td>
                </tr>
                </table> </td> </tr> </table>
                <asp:hiddenfield id="hdfID" runat="server" />
                <asp:hiddenfield id="hdfFlagID" runat="server" />
            </div>
        </div>
    </div>
    </div> </div>
</asp:content>
