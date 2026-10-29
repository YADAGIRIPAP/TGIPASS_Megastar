<%@ Page Title="" Language="C#" MasterPageFile="~/UI/TSiPASS/CCMaster.master" AutoEventWireup="true" CodeFile="frmUserMultiplexDashboard.aspx.cs" Inherits="UI_TSiPASS_frmUserMultiplexDashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
    <script language="javascript">
        function OpenPopup() {

            window.open("Lookups/frmcjfslookup.aspx", "List", "scrollbars=yes,resizable=yes,width=550,height=320");

            return false;
        }

        function Names() {
            var AsciiValue = event.keyCode
            if ((AsciiValue >= 65 && AsciiValue <= 90) || (AsciiValue >= 97 && AsciiValue <= 122) || (AsciiValue == 46) || (AsciiValue == 32))
                event.returnValue = true;
            else {
                event.returnValue = false;

                alert("Enter Alphabets, '.' and Space Only");
            }
        }

        function DecimalOnly() {
            var AsciiValue = event.keyCode
            if ((AsciiValue >= 48 && AsciiValue <= 57) || (AsciiValue == 8 || AsciiValue == 127) || AsciiValue == 46)
                event.returnValue = true;
            else {
                event.returnValue = false;

                alert("Enter DecimalValues Only");
            }
        }


        function AlphaNumericOnly() {
            var AsciiValue = event.keyCode
            if ((AsciiValue >= 65 && AsciiValue <= 90) || (AsciiValue >= 97 && AsciiValue <= 122) || (AsciiValue >= 48 && AsciiValue <= 57))
                event.returnValue = true;
            else {
                event.returnValue = false;

                alert("Enter Alphabets,  and Characters  Only");
            }
        }

    </script>

    <script type="text/javascript">
        $(function () {
            $('input[id$=txtration1]').bind('cut copy paste', function (e) {
                e.preventDefault();
                alert('You cannot ' + e.type + ' text!');
            });
        });
    </script>

    <script type="text/javascript">
        $(function () {
            $('input[id$=txtration2]').bind('cut copy paste', function (e) {
                e.preventDefault();
                alert('You cannot ' + e.type + ' text!');
            });
        });
    </script>

    <script type="text/javascript">
        $(function () {
            $('input[id$=txtsurveynum]').bind('cut copy paste', function (e) {
                e.preventDefault();
                alert('You cannot ' + e.type + ' text!');
            });
        });
    </script>
    <script type="text/javascript">
        $(function () {
            $('input[id$=txtExtent]').bind('cut copy paste', function (e) {
                e.preventDefault();
                alert('You cannot ' + e.type + ' text!');
            });
        });
    </script>
    <script type="text/javascript">
        $(function () {
            $('input[id$=txtCJFSBeneficiery]').bind('cut copy paste', function (e) {
                e.preventDefault();
                alert('You cannot ' + e.type + ' text!');
            });
        });
    </script>
  
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/balloon-css/0.4.0/balloon.min.css">
    <div class="clearfix"></div>
    <div class="panel-group" id="accordion">
        <div class="clearfix"></div>
        <table style="width: 100%">
            <tr>
 
                <td>
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            <h4 class="panel-title">
                                <a data-toggle="collapse" data-parent="#accordion" href="#collapseTwo"> Multiplex Dashboard</a>
                            </h4>
                        </div>
                        <div id="collapseTwo" class="panel-collapse in" style="height: auto;">
                            <div class="panel-body">
                                <table cellpadding="3" cellspacing="5" style="width: 100%">
                                    <tr style="height: 40px">
                                        <td style="width: 395px; font-size: 16px;" colspan="3" valign="top">
                                            <u><b>Multiplex Dashboard</b> </u>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 395px">
                                            <div class="list-group">
                                                <a href="ApplyAdvertisement.aspx" class="list-group-item"><span class="badge">
                                                    <asp:label id="Label4" runat="server"></asp:label>
                                                </span><i class="fa fa-fw fa-calendar"></i>Application Status </a>
                                            </div>
                                        </td>
                                        <td style="width: 30px">&nbsp;
                                        </td>
                                        <td style="width: 395px" valign="top">
                                            <div class="list-group">
                                                <a class="list-group-item" href="ApplyAdvertisement.aspx?status=B"><span class="badge">
                                                    <asp:label id="Label6" runat="server"></asp:label>
                                                </span><i class="fa fa-fw fa-check"></i>Common Application Form Status</a>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 395px">
                                            <div class="list-group">
                                                <a class="list-group-item"
                                                    href='frmDashboardRedirect_UserMutiplex.aspx?id=<%= Request.QueryString[0].ToString()%>&status=Approvals Required as per TS-iPASS'>
                                                    <span class="badge">
                                                        <asp:label id="Label7" runat="server"></asp:label>
                                                    </span><i class="fa fa-fw fa-calendar"></i>Approvals Required as per TS-iPASS</a>
                                            </div>
                                        </td>
                                        <td style="width: 30px">&nbsp;
                                        </td>
                                        <td style="width: 395px">
                                            <div class="list-group">
                                                <a class="list-group-item" href='frmDashboardRedirect_UserMutiplex.aspx?id=<%= Request.QueryString[0].ToString()%>&status=Approvals already Obtained'>
                                                    <span class="badge">
                                                        <asp:label id="Label8" runat="server"></asp:label>
                                                    </span><i class="fa fa-fw fa-calendar"></i>Approvals already obtained</a>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr style="height: 40px" valign="top">
                                        <td style="width: 395px; font-size: 16px;" colspan="3">
                                            <u><b>Application Status</b></u>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 395px; font-size: 16px;">
                                            <div class="list-group">
                                                <a class="list-group-item" href='frmDashboardRedirect_UserMutiplex.aspx?id=<%= Request.QueryString[0].ToString()%>&status=Approvals - Applied now'>

                                                    <span class="badge">
                                                        <asp:label id="Label10" runat="server"></asp:label>
                                                    </span><i class="fa fa-fw fa-calendar"></i>Applied Approvals </a>
                                            </div>
                                        </td>
                                        <td style="width: 30px">&nbsp;
                                        </td>
                                        <td style="width: 395px" valign="top">
                                            <div class="list-group">
                                                <a class="list-group-item" href='frmDashboardRedirect_UserMutiplex.aspx?id=<%= Request.QueryString[0].ToString()%>&status=Approvals - Yet to be applied'>
                                                    <span class="badge" style="background-color: #d9534f;">
                                                        <asp:label id="Label11" runat="server"></asp:label>
                                                    </span><i class="fa fa-fw fa-calendar"></i>Yet to be applied</a>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr style="height: 40px" valign="top">
                                        <td style="width: 395px; font-size: 16px;" colspan="3">
                                            <u><b>Pre-Scrutiny Status</b> </u>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 395px; font-size: 16px;">
                                            <div class="list-group">
                                                <a class="list-group-item" href='frmDashboardRedirect_UserMutiplex.aspx?id=<%= Request.QueryString[0].ToString()%>&status=Queries Raised'>
                                                   
                                                    <span class="badge" style="background-color: #d9534f;">
                                                        <asp:label id="Label3" runat="server"></asp:label>
                                                    </span><i class="fa fa-fw fa-calendar"></i>Query Raised </a>
                                            </div>
                                        </td>
                                        <td style="width: 30px">&nbsp;
                                        </td>
                                        <td style="width: 395px" valign="top">
                                            <div class="list-group">
                                                <a class="list-group-item"
                                                    href='frmDashboardRedirect_UserMutiplex.aspx?id=<%= Request.QueryString[0].ToString()%>&status=Queries Responded'>
                                                    <span class="badge">
                                                        <asp:label id="Label13" runat="server"></asp:label>
                                                    </span><i class="fa fa-fw fa-calendar"></i>Query Responded </a>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 395px; font-size: 16px;">
                                            <div class="list-group">
                                                <a class="list-group-item"
                                                    href="frmDashboardRedirect_UserMutiplex.aspx?id=<%= Request.QueryString[0].ToString()%>&status=Queries -Yet to Respond"><span class="badge" style="background-color: #d9534f;">
                                                        <asp:label id="Label14" runat="server"></asp:label>
                                                    </span><i class="fa fa-fw fa-calendar"></i>Yet to Respond</a>
                                            </div>
                                        </td>
                                        <td style="width: 30px">&nbsp;
                                        </td>
                                        <td style="width: 395px" valign="top">
                                            <div class="list-group">
                                                <a class="list-group-item" href='frmDashboardRedirect_UserMutiplex.aspx?id=<%= Request.QueryString[0].ToString()%>&status=Pre-Scrutiny - Rejected'>
                                                  
                                                    <span class="badge" style="background-color: #d9534f;">
                                                        <asp:label id="lblpreRejected" runat="server"></asp:label>
                                                    </span><i class="fa fa-fw fa-calendar"></i>Pre-Scrutiny - Rejected</a>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 395px; font-size: 16px;">
                                            <div class="list-group">
                                                <a class="list-group-item"
                                                    href="frmDashboardRedirect_UserMutiplex.aspx?id=<%= Request.QueryString[0].ToString()%>&status=Pre-Scrutiny - Completed">
                                                    <span class="badge">
                                                        <asp:label id="lblPreScrutinyCompleted" runat="server"></asp:label>
                                                    </span><i class="fa fa-fw fa-calendar"></i>Pre-Scrutiny - Completed</a>
                                            </div>
                                        </td>
                                        <td style="width: 30px">&nbsp;
                                        </td>
                                    </tr>

                                    <tr style="height: 40px" valign="top">
                                        <td style="width: 395px; font-size: 16px;" colspan="3">
                                            <u><b>Payment Status</b> </u>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 395px; font-size: 16px;">
                                            <div class="list-group">
                                                <a class="list-group-item"
                                                    href="frmPaymentAdvertisement.aspx?AdditionalPayment=Yes"><span class="badge">
                                                        <asp:label id="Label15" runat="server"></asp:label>
                                                    </span><i class="fa fa-fw fa-calendar"></i>Additional Payment required</a>
                                            </div>
                                        </td>
                                        <td style="width: 30px">&nbsp;
                                        </td>
                                        <td style="width: 395px" valign="top">
                                            <div class="list-group">
                                                <a
                                                    class="list-group-item" href='frmDashboardRedirect_UserMutiplex.aspx?id=<%= Request.QueryString[0].ToString()%>&status=Approval - Paid for'><span
                                                        class="badge">
                                                        <asp:label id="Label16" runat="server"></asp:label>
                                                    </span><i class="fa fa-fw fa-calendar"></i>Payment Paid
                                                </a>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr id="trnotrequired" runat="server" visible="false">
                                        <td style="width: 395px; font-size: 16px;">
                                            <div class="list-group">
                                                <a class="list-group-item" href='frmDashboardRedirect_UserMutiplex.aspx?id=<%= Request.QueryString[0].ToString()%>&status=Approvals - Payment not required'>
                                                    <span class="badge">
                                                        <asp:label id="Label12" runat="server"></asp:label>
                                                    </span><i class="fa fa-fw fa-calendar"></i>Payment not required </a>
                                            </div>
                                        </td>
                                        <td style="width: 30px">&nbsp;
                                        </td>
                                        <td style="width: 395px" valign="top">
                                            <div class="list-group">
                                                <a class="list-group-item" href="frmPaymentAdvertisement.aspx">
                                                    <span class="badge" style="background-color: #d9534f;">
                                                        <asp:label id="Label17" runat="server"></asp:label>
                                                    </span><i class="fa fa-fw fa-calendar"></i>Pre-Scrutiny Completed - Awaiting Payment</a>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr style="height: 40px" valign="top">
                                        <td style="width: 395px; font-size: 16px;" colspan="3">
                                            <u><b>Approval Status</b> </u>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 395px; font-size: 16px;">
                                            <div class="list-group">
                                                <a class="list-group-item"
                                                    href='frmDashboardRedirect_UserMutiplex.aspx?id=<%= Request.QueryString[0].ToString()%>&status=Approval - Issued'>
                                                    <span class="badge">
                                                        <asp:label id="Label1" runat="server"></asp:label>
                                                    </span><i class="fa fa-fw fa-calendar"></i>Approval - Issued</a>
                                            </div>
                                        </td>
                                        <td style="width: 30px">&nbsp;
                                        </td>
                                        <td style="width: 395px" valign="top">
                                            <div class="list-group">
                                                <a class="list-group-item"
                                                    href='frmDashboardRedirect_UserMutiplex.aspx?id=<%= Session["Applid"]%>&status=Approval - Pending'>
                                                    <span class="badge" style="background-color: #d9534f;">
                                                        <asp:label id="Label2" runat="server"></asp:label>
                                                    </span><i class="fa fa-fw fa-calendar"></i>Approval - Pending</a>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 395px; font-size: 16px;">
                                            <div class="list-group">
                                                <a class="list-group-item"
                                                    href='frmDashboardRedirect_UserMutiplex.aspx?id=<%= Request.QueryString[0].ToString()%>&status=Approval - Rejected'>
                                                    <span class="badge" style="background-color: #d9534f;">
                                                        <asp:label id="lblaprRejected" runat="server"></asp:label>
                                                    </span><i class="fa fa-fw fa-calendar"></i>Approval - Rejected</a>
                                            </div>
                                        </td>
                                        <td style="width: 30px">&nbsp;
                                        </td>
                                        <td style="width: 395px" valign="top">
                                            <div class="list-group">
                                            </div>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                            <div class="panel-body">
                                <table cellpadding="3" cellspacing="5" style="width: 100%">

                                    <tr>
                                        <td style="width: 395px" valign="top">
                                            <div class="list-group">
                                            </div>
                                        </td>
                                        <td style="width: 30px">&nbsp;
                                        </td>
                                        <td valign="top" style="width: 395px" id="trackappl" runat="server" visible="true">

                                            <div class="text-right">
                                                <img src="../../gif-new.gif" />
                                                <a href="RptApplicationWiseDetailedTrakerAdvertisment.aspx?id=<%= Request.QueryString[0].ToString()%>" style="font-size: 16px">Track your application
                                                                        <i class="fa fa-arrow-circle-right"></i><i class="fa fa-arrow-circle-right"></i>
                                                    <i class="fa fa-arrow-circle-right"></i></a>
                                            </div>
                                            <br />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 395px">&nbsp;
                                        </td>
                                        <td style="width: 30px">&nbsp;
                                        </td>
                                        <td>&nbsp;
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </div>
                    </div>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>

