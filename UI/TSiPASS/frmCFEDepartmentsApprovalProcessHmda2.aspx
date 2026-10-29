<%@ page title=":: TS-iPASS ::  " language="C#" masterpagefile="~/UI/TSiPASS/CCMaster.master"
    autoeventwireup="true" codefile="frmCFEDepartmentsApprovalProcessHmda2.aspx.cs" inherits="TSTBDCReg1" %>

<%--<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>--%>
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

        .style7 {
            width: 42px;
        }

        .style8 {
            height: 30px;
        }

        .style9 {
            width: 27px;
            height: 30px;
        }
    </style>

    <script type="text/javascript" language="javascript">

        function OpenPopup() {

            window.open("Lookups/LookupBDC.aspx", "List", "scrollbars=yes,resizable=yes,width=1000,height=650;display = block;position=absolute");

            return false;
        }
    </script>

    <script type="text/javascript">
        function showProgress() {
            var updateProgress = $get("<%= UpdateProgress.ClientID %>");
            updateProgress.style.display = "block";
        }
    </script>

    <script type="text/javascript" language="javascript">
        var win = new Object();
        function Popup(intval) {

            win = window.open("CFEPopup.aspx?UID=" + intval, "List", "scrollbars=yes,resizable=yes,width=780,height=400,left=" + ((window.screen.width / 2) - 320) + ",top=" + ((window.screen.height / 2) - 200) + ";display : block;position:absolute");
            //win = window.open("RptVillageOraganisationNameClickDetails.aspx?id="+intval, "List", "scrollbars=yes,resizable=yes,width=600,height=400,left=" + ((window.screen.width / 2) - 320) + ",top=" + ((window.screen.height / 2) - 200) + ";display : block;position:absolute");

        }
    </script>

    <asp:updatepanel id="upd1" runat="server">
        <contenttemplate>
            <div align="left">
                <ol class="breadcrumb">
                    You are here &nbsp;!&nbsp; &nbsp; &nbsp;
                    <li><i class="fa fa-dashboard"></i><a href="Home.aspx"></a></li>
                    <li class=""><i class="fa fa-fw fa-edit">CFE</i> </li>
                    <li class="active"><i class="fa fa-edit"></i><a href="#">
                        <asp:label id="lblHeaderlink" runat="server"></asp:label>
                    </a>
                    </li>
                </ol>
            </div>
            <div align="left">
                <div class="row" align="left">
                    <div class="col-lg-11">
                        <div class="panel panel-primary">
                            <div class="panel-heading" align="center">
                                <h3 class="panel-title">
                                    <asp:label id="lblHeading" runat="server"></asp:label>
                                </h3>
                            </div>
                            <asp:updatepanel id="UpdatePanel1" runat="server">
                                <contenttemplate>
                                    <div class="panel-body">
                                        <table align="center" cellpadding="10" cellspacing="5" style="width: 90%">
                                            <tr>
                                                <td style="padding: 5px; margin: 5px" valign="top">
                                                    <table cellpadding="4" cellspacing="5" style="width: 83%">
                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">1
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:label id="Label387" runat="server" cssclass="LBLBLACK" width="210px">From Date</asp:label>
                                                            </td>
                                                            <td class="style7" style="padding: 5px; margin: 5px">:
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                                <asp:textbox id="txtFromDate" runat="server" class="form-control txtbox" height="28px"
                                                                    maxlength="40" tabindex="1" validationgroup="group" width="180px">
                                                                </asp:textbox>
                                                                <%--<cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd-MM-yyyy" PopupButtonID="txtFromDate"
                                                                    TargetControlID="txtFromDate">
                                                                </cc1:CalendarExtender>--%>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">&nbsp;
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td style="width: 27px">
                                                    <asp:label id="Label348" runat="server" cssclass="LBLBLACK" width="50px"></asp:label>
                                                </td>
                                                <td valign="top">
                                                    <table cellpadding="4" cellspacing="5" style="width: 100%">
                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px">2&nbsp;
                                                            </td>
                                                            <td style="width: 200px;">
                                                                <asp:label id="Label423" runat="server" cssclass="LBLBLACK" width="150px">To Date</asp:label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">:
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                <asp:textbox id="txtToDate" runat="server" class="form-control txtbox" height="28px"
                                                                    maxlength="40" tabindex="1" validationgroup="group" width="180px">
                                                                </asp:textbox>
                                                                <%--<cc1:CalendarExtender ID="txtRegDate0_CalendarExtender" runat="server" Format="dd-MM-yyyy"
                                                                    PopupButtonID="txtToDate" TargetControlID="txtToDate">
                                                                </cc1:CalendarExtender>--%>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">&nbsp;
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px">&nbsp;
                                                            </td>
                                                            <td style="text-align: center;" align="center" colspan="3">
                                                                <asp:button id="BtnSearch" runat="server" cssclass="btn btn-primary" height="32px"
                                                                    onclick="BtnSave_Click" tabindex="10" text="Search" validationgroup="group" width="90px" />
                                                                &nbsp;
                                                                <asp:button id="BtnCancel" runat="server" causesvalidation="False" cssclass="btn btn-warning"
                                                                    height="32px" onclick="BtnClear_Click" tabindex="10" text="Cancel" tooltip="To Clear  the Screen"
                                                                    width="90px" />
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">&nbsp;
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="padding: 5px; margin: 5px" valign="top" align="left" class="style8"></td>
                                                <td class="style9"></td>
                                                <td valign="top" class="style8"></td>
                                            </tr>
                                            <tr>
                                                <td align="left" style="padding: 5px; margin: 5px" valign="top" colspan="3">
                                                    <asp:gridview id="grdDetails" runat="server" autogeneratecolumns="False"
                                                        cellpadding="5" forecolor="#333333" height="62px" onrowdatabound="grdDetails_RowDataBound"
                                                        showfooter="True" width="100%">
                                                        <footerstyle backcolor="#013161" font-bold="True" forecolor="White" />
                                                        <rowstyle backcolor="#EBF2FE" horizontalalign="Left" verticalalign="Middle" />
                                                        <columns>
                                                            <asp:templatefield headerstyle-horizontalalign="Center" headertext="S No">
                                                                <itemtemplate>
                                                                    <%# Container.DataItemIndex + 1%>
                                                                    <asp:hiddenfield id="HdfQueid" runat="server" />
                                                                    <asp:hiddenfield id="HdfApprovalid" runat="server" />
                                                                     <asp:hiddenfield id="intCFEEnterpid" Value='<%# Eval("intCFEEnterpid") %>'  runat="server" />
                                                                </itemtemplate>
                                                                <headerstyle horizontalalign="Center" />
                                                                <itemstyle width="50px" />
                                                            </asp:templatefield>
                                                            <asp:templatefield headertext="UID Number">
                                                                <itemtemplate>
                                                                    <asp:linkbutton id="LinkButton1" runat="server"></asp:linkbutton>
                                                                </itemtemplate>
                                                                <headerstyle horizontalalign="Left" />

                                                            </asp:templatefield>

                                                            <asp:boundfield datafield="NameofIndustrialUnder" headertext="Name of Industry"></asp:boundfield>
                                                            <asp:boundfield datafield="LastDateofPreScrutiy" visible="false" headertext="Last date of Prescrutiny" />
                                                            <%-- <asp:HyperLinkField HeaderText="Respond to Query"  DataNavigateUrlFields="Keyword,State,City"
                    DataNavigateUrlFormatString="KeywordSrchSumDtl.aspx?Keyword={0}&State={1}&City={2}"/>--%>
                                                            <asp:hyperlinkfield headertext="Approval" text="Approval" />
                                                            <asp:boundfield datafield="Village_Name" headertext="Village" />
                                                            <asp:boundfield datafield="Manda_lName" headertext="Mandal" />
                                                            <asp:boundfield datafield="District_Name" headertext="District" />
                                                            <asp:boundfield datafield="TargetApprovalDate" headertext="Target Approval Date" />
                                                            <asp:boundfield datafield="UPDATEDFLAG" headertext="Process" />
                                                            <asp:Templatefield headertext="DCR DRAWING NO">
                                                                <itemtemplate>
                                                                    <asp:Label id="lblDCRDrawingNo" Text='<%# Eval("DCRDrawingNo") %>' runat="server"></asp:Label>
                                                                </itemtemplate>
                                                                <headerstyle horizontalalign="Left" />
                                                            </asp:Templatefield>
                                                        </columns>
                                                        <pagerstyle backcolor="#013161" forecolor="White" horizontalalign="Center" />
                                                        <selectedrowstyle backcolor="#D1DDF1" font-bold="True" forecolor="#333333" />
                                                        <headerstyle backcolor="#013161" font-bold="True" forecolor="White" />
                                                        <editrowstyle backcolor="#B9D684" />
                                                        <alternatingrowstyle backcolor="White" />
                                                    </asp:gridview>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="padding: 5px; margin: 5px" colspan="3" align="center">&nbsp;<tr>
                                                    <td style="padding: 5px; margin: 5px" colspan="3" align="center">&nbsp;
                                                    </td>
                                                </tr>
                                                    <caption>
                                                        &nbsp;</caption>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center" colspan="3" style="padding: 5px; margin: 5px">
                                                    <div id="success" runat="server" visible="false" class="alert alert-success">
                                                        <a href="AddQualification.aspx" class="close" data-dismiss="alert" aria-label="close">&times;</a> <strong>Success!</strong><asp:label id="lblmsg" runat="server"></asp:label>
                                                    </div>
                                                    <div id="Failure" runat="server" visible="false" class="alert alert-danger">
                                                        <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a> <strong>Warning!</strong>
                                                        <asp:label id="lblmsg0" runat="server"></asp:label>
                                                    </div>
                                                </td>
                                            </tr>
                                        </table>
                                        <asp:hiddenfield id="hdfID" runat="server" />
                                        <asp:validationsummary id="ValidationSummary1" runat="server" showmessagebox="True"
                                            showsummary="False" validationgroup="group" />
                                        <asp:validationsummary id="ValidationSummary2" runat="server" showmessagebox="True"
                                            showsummary="False" validationgroup="child" />
                                        <asp:hiddenfield id="hdfFlagID" runat="server" />
                                    </div>
                                </contenttemplate>
                            </asp:updatepanel>
                        </div>
                    </div>
                </div>
            </div>
            <asp:updateprogress id="UpdateProgress" runat="server" associatedupdatepanelid="updatepanel1">
                <progresstemplate>
                    <div class="overlay">
                        <%--<div style=" z-index: 1000; margin-left: 350px;margin-top:200px;opacity: 1;-moz-opacity: 1;">--%>
                        <div style="z-index: 1000; margin-left: -210px; margin-top: 100px; opacity: 1; -moz-opacity: 1;">
                            <img alt="" src="../../Resource/Images/Processing.gif" />
                        </div>
                    </div>
                </progresstemplate>
            </asp:updateprogress>
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
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
                    dateFormat: "dd-mm-yy",
                    //  maxDate: new Date(currentYear, currentMonth, currentDate)
                }); // Will run at every postback/AsyncPostback
            $("input[id$='txtTodate']").datepicker(
                {
                    dateFormat: "dd-mm-yy",
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
                    //dateFormat: "dd-mm-yy",
                    dateFormat: "dd-mm-yy",
                    //maxDate: new Date(currentYear, currentMonth, currentDate)
                });
            $("input[id$='txtTodate']").datepicker(
                {
                    //dateFormat: "dd-mm-yy",
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
