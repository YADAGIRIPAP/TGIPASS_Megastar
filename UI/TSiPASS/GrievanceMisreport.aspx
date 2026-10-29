<%@ page language="C#" autoeventwireup="true" codefile="GrievanceMisreport.aspx.cs" inherits="UI_TSiPASS_GrievanceMisreport" masterpagefile="~/UI/TSiPASS/EmptyMaster.master" %>

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

        .style21 {
            height: 35px;
        }

        .style26 {
            height: 21px;
        }

        .style27 {
            height: 21px;
        }

        .style34 {
            height: 21px;
            width: 261px;
        }

        .style35 {
            height: 35px;
            width: 261px;
        }

        .style36 {
            width: 261px;
        }

        .style41 {
            height: 29px;
        }

        .style42 {
            width: 261px;
            height: 29px;
        }

        .style46 {
            height: 44px;
        }

        .style47 {
            height: 44px;
            width: 261px;
        }

        .style48 {
            width: 10px;
            height: 44px;
        }

        .style49 {
            width: 206px;
            height: 44px;
        }
    </style>

    <script type="text/javascript" language="javascript">

        function OpenPopup() {

            window.open("Lookups/LookupBDC.aspx", "List", "scrollbars=yes,resizable=yes,width=1000,height=650;display = block;position=absolute");

            return false;
        }
    </script>

    <script language="javascript" type="text/javascript">
        function confirmMAUD() {
            if (confirm("Are you sure you want to send the record to MA & UD"))
                return true;
            return false;
        }
    </script>

    <div align="left">
        <ol class="breadcrumb">
            You are here &nbsp;!&nbsp; &nbsp; &nbsp;
                                    <li><i></i><a href="Home.aspx">Home</a></li>
            &nbsp; /
                                    <%--<li class=""><i class="fa fa-fw fa-edit">CFE</i> </li>--%>
            <i></i><a href="MisreportDashboard.aspx">Mis Reports </a>&nbsp;/
                                    <li class="active"><i></i>Grievance/Feedback/General query</li>
        </ol>
    </div>

    <div align="left">
        <div class="row" align="left">
            <div class="col-lg-11">
                <div class="panel panel-primary">
                    <div class="panel-heading" align="center">
                        <h3 class="panel-title">
                            <asp:label id="lblHead2" runat="server" cssclass="LBLBLACK" font-bold="True"
                                width="199px"></asp:label>
                        </h3>
                    </div>

                    <div class="panel-body">
                        <table align="center" cellpadding="10" cellspacing="5" style="width: 90%">

                            <tr>
                                <td align="center" class="style21" style="padding: 5px; margin: 2px">
                                    <table cellpadding="4" cellspacing="5" style="width: 100%">
                                        <tr>
                                            <td class="style26" colspan="5"
                                                style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:label id="Label558" runat="server" cssclass="LBLBLACK" font-bold="True"
                                                    width="199px"></asp:label>
                                            </td>
                                            <td class="style27" colspan="5" style="padding: 5px; margin: 5px;">&nbsp;</td>
                                        </tr>
                                        <tr id="trgrivenance" runat="server" visible="true">
                                            <td class="style46" style="padding: 5px; margin: 5px; text-align: left;"></td>
                                            <td class="style47" style="padding: 5px; margin: 5px; padding-left:50px">
                                                <asp:label id="Label1" runat="server" cssclass="LBLBLACK" >Type of Report :</asp:label>
                                            </td>
                                            <td class="style46" style="padding: 5px; margin: 5px">:</td>
                                            <td class="style46" style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:dropdownlist id="ddlRegisterAs" runat="server" class="form-control txtbox"
                                                    height="33px" tabindex="1" width="270px" autopostback="True" onselectedindexchanged="ddlRegisterAs_SelectedIndexChanged">
                                                    <asp:listitem>--Select--</asp:listitem>
                                                    <asp:listitem value="G" selected="True">Grievance</asp:listitem>
                                                    <asp:listitem value="F">Feedback</asp:listitem>
                                                    <asp:listitem value="Q">General Query</asp:listitem>
                                                </asp:dropdownlist>
                                            </td>
                                            <td class="style46" style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:requiredfieldvalidator id="RequiredFieldValidator2" runat="server"
                                                    controltovalidate="ddlRegisterAs" errormessage="Please Select Register Your"
                                                    validationgroup="group" initialvalue="--Select--">
                                                    *</asp:requiredfieldvalidator>
                                            </td>
                                            <td class="style48" style="padding: 5px; margin: 5px; vertical-align: middle;"
                                                valign="middle"></td>
                                            <td class="style49" style="padding: 5px; margin: 5px; text-align: left;">
                                                <%--<asp:Label ID="Label2" runat="server" CssClass="LBLBLACK" Width="100px">District Name:</asp:Label>--%>
                                            </td>
                                            <td class="style46" style="padding: 5px; margin: 5px"></td>
                                            <td class="style46" style="padding: 5px; margin: 5px; text-align: left;"></td>
                                            <td style="padding: 5px; margin: 5px"></td>
                                        </tr>

                                    </table>
                                </td>
                            </tr>
                            <tr id="trgrievancereport" runat="server" visible="true">
                                <td>
                                    <div class="panel-body">
                                        <table align="center" cellpadding="10" cellspacing="5" style="width: 90%">
                                            <tr>
                                                <td><strong>Grievance Report</strong></td>
                                            </tr>
                                            <tr>
                                                <td align="left" style="padding: 5px; margin: 5px" valign="top">
                                                    <table cellpadding="4" cellspacing="5" style="width: 83%">

                                                        <tr>
                                                            <td style=" margin: 5px;" align="center">
                                                                <asp:gridview id="grdDetails" runat="server"
                                                                    autogeneratecolumns="False" cellpadding="4" cssclass="GRD"
                                                                    forecolor="#333333" height="62px"
                                                                    pagesize="40" width="100%" showfooter="True" onrowdatabound="grdDetails_RowDataBound">
                                                                    <footerstyle backcolor="#013161" font-bold="True" forecolor="White" HorizontalAlign="Center" />
                                                                    <rowstyle backcolor="#EBF2FE" cssclass="GRDITEM" horizontalalign="Center"
                                                                        verticalalign="Middle" />
                                                                    <columns>

                                                                        <asp:templatefield headerstyle-horizontalalign="Center" headertext="S No">
                                                                            <itemtemplate>
                                                                                <%# Container.DataItemIndex + 1%>
                                                                                <asp:hiddenfield id="HdfQueid" runat="server" />
                                                                                <asp:hiddenfield id="HdfApprovalid" runat="server" />
                                                                            </itemtemplate>
                                                                            <headerstyle horizontalalign="Center" />
                                                                            <itemstyle width="50px" />
                                                                        </asp:templatefield>
                                                                        <asp:boundfield datafield="Dept_Name" headertext="Department" ItemStyle-HorizontalAlign="Left" />
                                                                        <asp:hyperlinkfield datatextfield="total" headertext="Total Grievances" navigateurl="GrievanceMisReportDrilldown.aspx?Status=All" />
                                                                        <asp:hyperlinkfield datatextfield="pending" headertext="Pending Grievances" navigateurl="GrievanceMisReportDrilldown.aspx?Status=Pending" />
                                                                        <asp:hyperlinkfield datatextfield="redress" headertext="Redressed Grievances" navigateurl="GrievanceMisReportDrilldown.aspx?Status=Redress" />
                                                                        <asp:hyperlinkfield datatextfield="reject" headertext="Rejected Grievances" navigateurl="GrievanceMisReportDrilldown.aspx?Status=Reject" />

                                                                        <%-- <asp:BoundField DataField="total" HeaderText="Total" ItemStyle-HorizontalAlign="Right" />
                                                                        <asp:BoundField DataField="pending" HeaderText="Pending" ItemStyle-HorizontalAlign="Right" />
                                                                        <asp:BoundField DataField="redress" HeaderText="Redress" ItemStyle-HorizontalAlign="Right" />
                                                                        <asp:BoundField DataField="reject" HeaderText="Reject" ItemStyle-HorizontalAlign="Right" />--%>
                                                                        <%-- <asp:HyperLinkField DataTextField="total" HeaderText="Total Grievances"
                                                                    NavigateUrl="GreivanceStatusDetails.aspx?Status=All" />
                                                                <asp:HyperLinkField DataTextField="pending" HeaderText="Pending Grievances"
                                                                    NavigateUrl="GreivanceStatusDetails.aspx?Status=Pending" />
                                                                <asp:HyperLinkField DataTextField="redress" HeaderText="Redressed Grievances"
                                                                    NavigateUrl="GreivanceStatusDetails.aspx?Status=Redress" />
                                                                <asp:HyperLinkField DataTextField="reject" HeaderText="Rejected Grievances"
                                                                    NavigateUrl="GreivanceStatusDetails.aspx?Status=Reject" />--%>
                                                                    </columns>
                                                                    <pagerstyle backcolor="#013161" forecolor="White" horizontalalign="Center" />
                                                                    <selectedrowstyle backcolor="#D1DDF1" font-bold="True" forecolor="#333333" />
                                                                    <headerstyle backcolor="#013161" cssclass="GRDHEADER" font-bold="True"
                                                                        forecolor="White" />
                                                                    <editrowstyle backcolor="#B9D684" />
                                                                    <alternatingrowstyle backcolor="White" />
                                                                </asp:gridview>
                                                                <tr>
                                                                    <td align="center" style="padding: 5px; margin: 5px">&nbsp;</td>
                                                                </tr>
                                                                <caption>
                                                                    &nbsp;</caption>
                                                            </td>
                                                        </tr>

                                                    </table>
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                </td>
                            </tr>
                            <tr id="trfeedbackreport" runat="server" visible="false">
                                <td>
                                    <div class="panel-body">
                                        <table align="center" cellpadding="10" cellspacing="5" style="width: 90%">
                                            <tr>
                                                <td><strong>Feedback Report</strong>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left" style="padding: 5px; margin: 5px" valign="top">
                                                    <table cellpadding="4" cellspacing="5" style="width: 83%">

                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px;" align="center">
                                                                <asp:gridview id="grdfeedback" runat="server" allowpaging="True"
                                                                    autogeneratecolumns="False" cellpadding="4" cssclass="GRD"
                                                                    forecolor="#333333" height="62px"
                                                                    pagesize="40" width="100%" showfooter="True" onrowdatabound="grdfeedback_RowDataBound">
                                                                    <footerstyle backcolor="#013161" font-bold="True" forecolor="White" />
                                                                    <rowstyle backcolor="#EBF2FE" cssclass="GRDITEM" horizontalalign="Left"
                                                                        verticalalign="Middle" />
                                                                    <columns>

                                                                        <asp:templatefield headerstyle-horizontalalign="Center" headertext="S No">
                                                                            <itemtemplate>
                                                                                <%# Container.DataItemIndex + 1%>
                                                                                <asp:hiddenfield id="HdfQueid" runat="server" />
                                                                                <asp:hiddenfield id="HdfApprovalid" runat="server" />
                                                                            </itemtemplate>
                                                                            <headerstyle horizontalalign="Center" />
                                                                            <itemstyle width="50px" />
                                                                        </asp:templatefield>
                                                                        <asp:boundfield datafield="Dept_Name" headertext="Department" />
                                                                        <asp:boundfield datafield="total" headertext="Total" itemstyle-horizontalalign="Right" />
                                                                        <asp:boundfield datafield="pending" headertext="Pending" itemstyle-horizontalalign="Right" />
                                                                        <asp:boundfield datafield="redress" headertext="Closed with reply" itemstyle-horizontalalign="Right" />
                                                                        <asp:boundfield datafield="reject" headertext="Closed without reply" itemstyle-horizontalalign="Right" />
                                                                        <%--<asp:HyperLinkField DataTextField="total" HeaderText="Total Feedbacks"
                                                                    NavigateUrl="FeedBackStatusDetails.aspx?Status=All" />--%>
                                                                    </columns>
                                                                    <pagerstyle backcolor="#013161" forecolor="White" horizontalalign="Center" />
                                                                    <selectedrowstyle backcolor="#D1DDF1" font-bold="True" forecolor="#333333" />
                                                                    <headerstyle backcolor="#013161" cssclass="GRDHEADER" font-bold="True"
                                                                        forecolor="White" />
                                                                    <editrowstyle backcolor="#B9D684" />
                                                                    <alternatingrowstyle backcolor="White" />
                                                                </asp:gridview>
                                                                <tr>
                                                                    <td align="center" style="padding: 5px; margin: 5px">&nbsp;</td>
                                                                </tr>
                                                                <caption>
                                                                    &nbsp;</caption>
                                                            </td>
                                                        </tr>

                                                    </table>
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                </td>
                            </tr>
                            <tr id="trquerydetailsreport" runat="server" visible="false">
                                <td>
                                    <div class="panel-body">
                                        <table align="center" cellpadding="10" cellspacing="5" style="width: 90%">
                                            <tr>
                                                <td><strong>General Query Details Report</strong>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left" style="padding: 5px; margin: 5px" valign="top">
                                                    <table cellpadding="4" cellspacing="5" style="width: 83%">
                                                        <tr>
                                                            <td><strong>Total General Query Received : &nbsp
                                                                <asp:label id="lblquerytotal" font-size="14px" runat="server" cssclass="LBLBLACK"></asp:label>
                                                            </strong>

                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>&nbsp;
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>&nbsp;
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px;" align="center">
                                                                <asp:gridview id="grdquerydetails" runat="server" allowpaging="True"
                                                                    autogeneratecolumns="False" cellpadding="4" cssclass="GRD"
                                                                    forecolor="#333333" height="62px"
                                                                    pagesize="40" width="100%" showfooter="True">
                                                                    <footerstyle backcolor="#013161" font-bold="True" forecolor="White" />
                                                                    <rowstyle backcolor="#EBF2FE" cssclass="GRDITEM" horizontalalign="Left"
                                                                        verticalalign="Middle" height="50px" font-size="14px" />
                                                                    <columns>

                                                                        <asp:templatefield headerstyle-horizontalalign="Center" headertext="S No">
                                                                            <itemtemplate>
                                                                                <%# Container.DataItemIndex + 1%>
                                                                                <asp:hiddenfield id="HdfQueid" runat="server" />
                                                                                <asp:hiddenfield id="HdfApprovalid" runat="server" />
                                                                            </itemtemplate>
                                                                            <headerstyle horizontalalign="Center" />
                                                                            <itemstyle width="50px" />
                                                                        </asp:templatefield>
                                                                        <asp:boundfield datafield="Description" headertext="Description" />
                                                                        <asp:boundfield datafield="Total" headertext="Total" itemstyle-horizontalalign="Right" />
                                                                        <asp:boundfield datafield="Within Time Lines" headertext="Within Time Limit" itemstyle-horizontalalign="Right" />
                                                                        <asp:boundfield datafield="Beyond Time Lines" headertext="Beyond Time Limit" itemstyle-horizontalalign="Right" />
                                                                        <asp:boundfield datafield="About to Breach (90% of Within Time Lines)" headertext="About to Breach (90% of Within Time Lines)" itemstyle-horizontalalign="Right" />
                                                                        <%--<asp:BoundField DataField="Dept_Name" HeaderText="Department" />--%>
                                                                        <%-- <asp:HyperLinkField DataTextField="total" HeaderText="Total Queries"
                                                                            NavigateUrl="QueryStatusDetails.aspx?Status=All" />
                                                                        <asp:HyperLinkField DataTextField="pending" HeaderText="Pending Queries"
                                                                            NavigateUrl="QueryStatusDetails.aspx?Status=Pending" />
                                                                        <asp:HyperLinkField DataTextField="Attended" HeaderText="Attended Queries"
                                                                            NavigateUrl="QueryStatusDetails.aspx?Status=Attended" />--%>
                                                                        <%-- <asp:HyperLinkField DataTextField="reject" HeaderText="Rejected Queries"
                                                                            NavigateUrl="QueryStatusDetails.aspx?Status=Reject" />--%>
                                                                    </columns>
                                                                    <pagerstyle backcolor="#013161" forecolor="White" horizontalalign="Center" />
                                                                    <selectedrowstyle backcolor="#D1DDF1" font-bold="True" forecolor="#333333" />
                                                                    <headerstyle backcolor="#013161" cssclass="GRDHEADER" font-bold="True"
                                                                        forecolor="White" />
                                                                    <editrowstyle backcolor="#B9D684" />
                                                                    <alternatingrowstyle backcolor="White" />
                                                                </asp:gridview>
                                                                <tr>
                                                                    <td align="center" style="padding: 5px; margin: 5px">&nbsp;</td>
                                                                </tr>
                                                                <caption>
                                                                    &nbsp;</caption>
                                                            </td>
                                                        </tr>

                                                    </table>
                                                </td>
                                            </tr>
                                        </table>
                                    </div>

                                </td>
                            </tr>
                            <tr>
                                <td colspan="4" align="center" style="padding: 5px; margin: 5px">
                                    <div id="DIVUPDATEDDATE" runat="server" class="alert alert-success">
                                        <b>
                                            <asp:label id="LBLDATETEXT" runat="server" text="The data in the dashboard is updated on a real time basis. Last update:"></asp:label>
                                            <asp:label id="LBLDATETIME" runat="server"></asp:label>
                                        </b>
                                    </div>

                                </td>
                            </tr>
                            <tr>
                                <td align="center" style="padding: 5px; margin: 5px; text-align: center;">&nbsp;</td>
                            </tr>
                            <%--   <tr>
                                <td align="center" colspan="2" style="padding: 5px; margin: 5px">
                                    <div id="success" runat="server" class="alert alert-success">
                                        <a aria-label="close" class="close" data-dismiss="alert"
                                            href="AddQualification.aspx">×</a> <strong></strong>
                                        <asp:Label
                                            ID="lblmsg" runat="server"></asp:Label>
                                    </div>
                                    <div id="Failure" runat="server" class="alert alert-danger">
                                        <a aria-label="close" class="close" data-dismiss="alert" href="#">×</a> <strong>Warning!</strong>
                                        <asp:Label ID="lblmsg0" runat="server"></asp:Label>
                                    </div>

                                    <asp:HiddenField ID="hdfID" runat="server" />
                                    <asp:ValidationSummary ID="ValidationSummary1" runat="server"
                                        ShowMessageBox="True" ShowSummary="False" ValidationGroup="group" />
                                    <asp:ValidationSummary ID="ValidationSummary2" runat="server"
                                        ShowMessageBox="True" ShowSummary="False" ValidationGroup="child" />
                                    <asp:HiddenField ID="hdfFlagID" runat="server" />
                                </td>
                            </tr>--%>
                        </table>



                    </div>

                </div>
            </div>
        </div>

    </div>




</asp:content>
