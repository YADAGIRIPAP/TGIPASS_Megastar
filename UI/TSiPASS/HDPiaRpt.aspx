<%@ page language="C#" masterpagefile="~/UI/TSiPASS/CCMaster.master" autoeventwireup="true" codefile="HDPiaRpt.aspx.cs" inherits="HDPiaRpt" title=":: TSiPASS TSiPASS  :: Help Desk" %>

<%--<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>--%>

<asp:content id="Content1" contentplaceholderid="ContentPlaceHolder1" runat="Server">


    <asp:updatepanel id="upd1" runat="server">
        <contenttemplate>
            <div align="left">
                <ol class="breadcrumb">
                    You are here
        &nbsp;!&nbsp; &nbsp; &nbsp; 
                           
                    <li>
                        <i class="fa fa-dashboard"></i><a href="Home.aspx">Dashboard</a>
                    </li>
                    <li class="">
                        <i class="fa fa-fw fa-table"></i>Helpdesk
                            </li>
                    <li class="active">
                        <i class="fa fa-edit"></i><a href="#">Status</a>
                    </li>
                </ol>
            </div>

            <div align="center">
                <div class="row" align="center">
                    <div class="col-lg-11">
                        <div class="panel panel-primary">
                            <div class="panel-heading">
                                <h3 class="panel-title">Helpdesk Abstract Report</h3>
                            </div>
                            <div class="panel-body">
                                <table style="vertical-align: top; text-align: center;" cellpadding="0" cellspacing="0"
                                    width="100%">
                                    <tr>
                                        <td align="center"
                                            style="padding: 5px; vertical-align: middle; height: 35px; text-align: left; margin-left: 40px;"
                                            valign="middle">
                                            <table style="width: 96%; height: 53px" width="80%">
                                                <tr>
                                                    <td style="width: 50%; height: 51px;" valign="top">
                                                        <table cellpadding="0" cellspacing="0" style="width: 50%">
                                                            <tr>
                                                                <td align="right" style="padding-right: 5px; padding-left: 5px; padding-bottom: 5px; vertical-align: top; width: 22%; padding-top: 5px; text-align: left">
                                                                    <asp:label id="lblFromDate" runat="server" cssclass="LBLBLACK" text="From date  (DD-MM-YYYY)"
                                                                        width="200px"></asp:label>
                                                                </td>
                                                                <td align="right" style="padding-right: 5px; padding-left: 5px; padding-bottom: 5px; vertical-align: top; width: 3%; padding-top: 5px; text-align: left">
                                                                    <asp:label id="Label3" runat="server" cssclass="LBLBLACK" text=":" width="2px"></asp:label>
                                                                </td>
                                                                <td align="left" style="padding-right: 5px; padding-left: 5px; padding-bottom: 5px; vertical-align: top; width: 22%; padding-top: 5px; text-align: left">
                                                                    <asp:textbox id="txtFromdate" runat="server" class="form-control txtbox" maxlength="11" tabindex="1"
                                                                        width="180px">
                                                                    </asp:textbox>
                                                                    <%-- <cc1:CalendarExtender ID="txtFromdate_CalendarExtender" runat="server"
                                                                        Format="dd-MMM-yyyy" PopupButtonID="txtFromdate" TargetControlID="txtFromdate">
                                                                    </cc1:CalendarExtender>--%>
                                                                </td>
                                                                <%--<td align="left" style="padding-right: 5px; padding-left: 5px; padding-bottom: 5px;
                                                                                        vertical-align: top; width: 22%; padding-top: 5px; text-align: left">
                                                                                        <asp:Image id="imgCalendarStartDate" runat="server" alt="" height="100%" src="Images/CAL.GIF"
                                                                                            style="width: 16px" tabIndex="1">
                                                                                        </asp:Image>&nbsp;</td>--%>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                    <td style="width: 50%; height: 51px;" valign="top">
                                                        <table cellpadding="0" cellspacing="0" style="width: 50%; height: 40px">
                                                            <tr>
                                                                <td align="right"
                                                                    style="padding: 5px; vertical-align: top; width: 2%; text-align: left; height: 26px;">
                                                                    <asp:label id="lblToDate" runat="server" cssclass="LBLBLACK" text="To date  (DD-MM-YYYY)"
                                                                        width="200px"></asp:label>
                                                                </td>
                                                                <td align="right"
                                                                    style="padding: 5px; vertical-align: top; width: 2%; text-align: left; height: 26px;">
                                                                    <asp:label id="Label4" runat="server" cssclass="LBLBLACK" text=":" width="2px"></asp:label>
                                                                </td>
                                                                <td align="left"
                                                                    style="padding: 5px; vertical-align: top; width: 2%; text-align: left; height: 26px;">
                                                                    <asp:textbox id="txtTodate" runat="server" class="form-control txtbox" maxlength="11" tabindex="1"
                                                                        width="180px">
                                                                    </asp:textbox>
                                                                    <%--<cc1:CalendarExtender ID="txtTodate_CalendarExtender" runat="server"
                                                                        Format="dd-MMM-yyyy" PopupButtonID="txtTodate" TargetControlID="txtTodate">
                                                                    </cc1:CalendarExtender>--%>
                                                                </td>
                                                                <%--<td align="left" 
                                                                                        style="padding: 5px; vertical-align: top; width: 22%; text-align: left; height: 26px;">
                                                                                        <asp:Image id="imgCalendarEndDate" runat="server" alt="" height="57%" src="Images/CAL.GIF"
                                                                                            style="width: 16px" tabIndex="1">
                                                                                        </asp:Image></td>--%>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center"
                                            style="padding: 5px; vertical-align: middle; height: 35px; text-align: center"
                                            valign="middle">&nbsp;<asp:label id="Label5" runat="server"></asp:label>
                                            <asp:button id="Btnsearch" runat="server" cssclass="btn btn-primary" height="32px" tabindex="10"
                                                text="Search" tooltip="To Search  the data" validationgroup="group"
                                                onclick="Btnsearch_Click" />
                                            <asp:label id="LblStatus" runat="server" cssclass="LBLBLACK" font-bold="True"
                                                font-size="12px" forecolor="Red"></asp:label>
                                        </td>
                                    </tr>
                                    <%--<tr>
                                                            <td align="center" 
                                                                style="padding: 5px; vertical-align: middle; text-align: left; height: 22px;" 
                                                                valign="middle"> style="position: static"
                                                            </td>
                                                        </tr>--%>
                                    <tr style="width: 100%">
                                        <td align="center"
                                            valign="middle">

                                            <asp:gridview id="grdHelpdesk" runat="server" autogeneratecolumns="False" cellpadding="4"
                                                cssclass="GRD" forecolor="#333333" gridlines="None" 
                                                pagesize="15" showfooter="True"  width="100%"
                                                onrowdatabound="grdHelpdesk_RowDataBound" visible="False">
                                                <rowstyle backcolor="#EFF3FB" cssclass="GRDITEM" horizontalalign="Left" height="100px"
                                                    verticalalign="Middle" Font-Size="Medium" />
                                                <columns>
                                                    <asp:boundfield headertext="Sno" />
                                                    <asp:boundfield headertext="FeedBack Type" datafield="fb_type" />
                                                    <asp:hyperlinkfield headertext="Total No Of Issues" datatextfield="Total">

                                                        <headerstyle horizontalalign="Left" />
                                                        <itemstyle horizontalalign="Left" />
                                                    </asp:hyperlinkfield> 
                                                    <asp:hyperlinkfield headertext="Open Issues" datatextfield="Open1">

                                                        <headerstyle horizontalalign="Left" />
                                                        <itemstyle horizontalalign="Left" />
                                                    </asp:hyperlinkfield>
                                                    <asp:hyperlinkfield headertext="Close Issues" datatextfield="Close1">

                                                        <headerstyle horizontalalign="Left" />
                                                        <itemstyle horizontalalign="Left" />
                                                    </asp:hyperlinkfield>
                                                    <asp:hyperlinkfield headertext="Rejected Issues" datatextfield="Reject">

                                                        <headerstyle horizontalalign="Left" />
                                                        <itemstyle horizontalalign="Left" />
                                                    </asp:hyperlinkfield>
                                                    <asp:boundfield datafield="intfb_id" headertext="FBID" visible="False" />
                                                </columns>
                                                <footerstyle backcolor="#093461" font-bold="True" forecolor="White" />
                                                <pagerstyle backcolor="#05693b" forecolor="White" horizontalalign="Center" />
                                                <emptydatatemplate>
                                                    <table align="center">
                                                        <asp:label id="Label2" runat="server" font-bold="True" font-names="Verdana"
                                                            font-size="11px" forecolor="Red" text="No Issues Found"></asp:label>
                                                    </table>
                                                </emptydatatemplate>
                                                <selectedrowstyle backcolor="#D1DDF1" font-bold="True" forecolor="#333333" />
                                                <headerstyle backcolor="#093461" cssclass="GRDHEADER" font-bold="True"
                                                    forecolor="White" />
                                                <editrowstyle backcolor="#05693b" />
                                                <alternatingrowstyle backcolor="White" />
                                            </asp:gridview>
                                        </td>
                                    </tr>
                                    <%--<tr>
                                                            <td align="center" 
                                                                style="padding-right: 5px; padding-left: 5px; padding-bottom: 5px;
                                                                vertical-align: middle; padding-top: 5px; height: 35px; text-align: center" 
                                                                valign="middle">
                                                                &nbsp;&nbsp;&nbsp;</td>
                                                        </tr>--%>
                                </table>
                                <table id="tbl1" runat="server" border="1" bordercolor="#54503A"
                                    style="color: black; font-size: 12px;">
                                </table>
                            </div>
                        </div>
                    </div>
                </div>

            </div>
        </contenttemplate>
    </asp:updatepanel>
    <link href="../../css/ui-lightness/jquery-ui-1.8.19.custom.css" rel="stylesheet" />
    <script src="../../js/jquery-1.7.2.min.js"></script>
    <script src="../../js/jquery-ui-1.8.19.custom.min.js"></script>
    <link href="<%= ResolveUrl("css/ui-lightness/jquery-ui-1.8.19.custom.css") %>" rel="stylesheet"
        type="text/css" />
    <script type="text/javascript" src="<%= ResolveUrl("js/jquery-1.7.2.min.js") %>"></script>
    <script src="<%= ResolveUrl("js/jquery-ui-1.8.19.custom.min.js") %>" type="text/javascript"></script>
    <script type="text/javascript">
        function pageLoad() {
            var date = new Date();
            var currentMonth = date.getMonth();
            var currentDate = date.getDate();
            var currentYear = date.getFullYear();

            $("input[id$='txtFromDate']").datepicker(
                {
                    dateFormat: "dd/mm/yy",
                    //  maxDate: new Date(currentYear, currentMonth, currentDate)
                }); // Will run at every postback/AsyncPostback
            $("input[id$='txtTodate']").datepicker(
                {
                    dateFormat: "dd/mm/yy",
                    //  maxDate: new Date(currentYear, currentMonth, currentDate)
                }); // Will run at every postback/AsyncPostback
        }
        $(function () {
            var date = new Date();
            var currentMonth = date.getMonth();
            var currentDate = date.getDate();
            var currentYear = date.getFullYear();
            $("input[id$='txtFromDate']").datepicker(
                {
                    //dateFormat: "dd/mm/yy",
                    dateFormat: "dd/mm/yy",
                    //maxDate: new Date(currentYear, currentMonth, currentDate)
                });
            $("input[id$='txtTodate']").datepicker(
                {
                    //dateFormat: "dd/mm/yy",
                    dateFormat: "dd/mm/yy",
                    //maxDate: new Date(currentYear, currentMonth, currentDate)
                });
        });
    </script>
    <style type="text/css">
        .ui-datepicker {
            font-size: 8pt !important;
            height: 250px;
            padding: 0.2em 0.2em 0;
            width: 250px;
        }
    </style>
</asp:content>

