<%@ page title="" language="C#" masterpagefile="~/UI/TSIPASS/CCMaster.master" autoeventwireup="true" MaintainScrollPositionOnPostback="true" 
    codefile="frmHelpdescrptDrill.aspx.cs" inherits="UI_TSIPASS_frmHelpdescrptDrill"
    enableeventvalidation="false" %>

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

        .style8 {
            color: #FF0000;
            font-weight: bold;
        }

        .algnRight {
            text-align: center;
            padding-right: 5px;
        }
    </style>
    <script type="text/javascript" language="javascript">

        function OpenPopup() {

            window.open("Lookups/LookupBDC.aspx", "List", "scrollbars=yes,resizable=yes,width=1000,height=650;display = block;position=absolute");

            return false;
        }
    </script>
    <script type="text/javascript" language="javascript">
        var win = new Object();
        function Popup(intval) {

            win = window.open("CFEPopup.aspx?UID=" + intval, "List", "scrollbars=yes,resizable=yes,width=780,height=400,left=" + ((window.screen.width / 2) - 320) + ",top=" + ((window.screen.height / 2) - 200) + ";display : block;position:absolute");
            //win = window.open("RptVillageOraganisationNameClickDetails.aspx?id="+intval, "List", "scrollbars=yes,resizable=yes,width=600,height=400,left=" + ((window.screen.width / 2) - 320) + ",top=" + ((window.screen.height / 2) - 200) + ";display : block;position:absolute");

        }
    </script>

    <script type="text/javascript">

        //        function pageLoad() {

        //            $('#<%=grdDetails.ClientID%>').gridviewScroll({
        //                width: "100%",
        //                height: "100%",
        //                arrowsize: 30,
        //                varrowtopimg: "../../images/arrowvt.png",
        //                varrowbottomimg: "../../images/arrowvb.png",
        //                harrowleftimg: "../../images/arrowhl.png",
        //                harrowrightimg: "../../images/arrowhr.png"
        //            });
        //        }

        $(function () {

            $('#MstLftMenu').remove();

        });

    </script>
    <style>
        .GridviewScrollC1Item TD {
            border-bottom: none !important;
        }
    </style>
    <asp:updatepanel id="upnl_newRegistration" runat="server" updatemode="Conditional">
        <contenttemplate>
            <asp:panel id="pnl_Data" runat="server">
                <div align="left">
                    <ol class="breadcrumb">
                        You are here &nbsp;!&nbsp; &nbsp; &nbsp;
                        <li><i class="fa fa-dashboard"></i><a href="Home.aspx"></a></li>
                        <li class=""><i class="fa fa-fw fa-edit"></i></li>
                        <li class="active"><i class="fa fa-edit"></i><a href="#">VIEW DETAILS</a> </li>
                    </ol>
                </div>
                <div align="left">
                    <div class="row" align="left">
                        <div class="col-lg-12">
                            <div class="panel panel-default">
                                <div class="panel-heading" align="center">
                                    <h3 class="panel-title" style="font-weight: bold;">
                                        <asp:label id="lblHeading" runat="server"></asp:label>
                                    </h3>
                                </div>
                                <div class="panel-body">
                                    <table align="center" cellpadding="10" cellspacing="5" style="width: 100%">
                                        <tr align="center">
                                            <td style="padding: 5px; margin: 5px" valign="top" align="center">
                                                <table width="80%">
                                                    <tr>
                                                        <td style="padding: 5px; margin: 5px" align="left">
                                                            <asp:hyperlink cssclass="btn btn-link" id="HyperLink1" runat="server" text="<< Back">
                                                            </asp:hyperlink>
                                                        </td>
                                                        <td class="col-xs-3" style="padding: 5px; margin: 5px">&nbsp;
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px" align="center">&nbsp;
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">&nbsp;
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px" align="right">&nbsp;
                                                        </td>
                                                        <td class="col-xs-5" style="padding: 5px; text-align: right; margin: 5px">&nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr align="center">
                                                        <td style="padding: 5px; margin: 5px" align="center">
                                                            <div class="input-group">
                                                                <div class="input-group-addon">
                                                                    From Date
                                                                </div>
                                                                <asp:textbox id="txtFromDate" runat="server" enabled="false" class="form-control txtbox"
                                                                    height="28px" maxlength="40" onkeypress="NumberOnly()" tabindex="1" validationgroup="group"
                                                                    width="125px">
                                                                </asp:textbox>
                                                                <%--<cc1:CalendarExtender ID="CalendarExtender2" runat="server" Format="dd-MM-yyyy" TargetControlID="txtFromDate">
                                                                </cc1:CalendarExtender>--%>
                                                            </div>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">
                                                            <div class="input-group">
                                                                <div class="input-group-addon">
                                                                    To Date
                                                                </div>
                                                                <asp:textbox id="txtTodate" runat="server" enabled="false" class="form-control txtbox"
                                                                    height="28px" maxlength="40" onkeypress="NumberOnly()" tabindex="1" validationgroup="group"
                                                                    width="125px">
                                                                </asp:textbox>
                                                                <%-- <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd-MM-yyyy" TargetControlID="txtTodate">
                                                                </cc1:CalendarExtender>--%>
                                                            </div>
                                                        </td>
                                                        <td class="col-xs-5" style="padding: 5px; text-align: right; margin: 5px" colspan="5">
                                                            <asp:label id="Label1" runat="server" cssclass="LBLBLACK">Report as on date</asp:label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="Left" style="border: none;">
                                                <asp:button id="btn_export" runat="server" onclientclick="exportData();" cssclass="btn btn-success btn-sm"
                                                    text="&#xf019; Exports To Excel" style="float: right; font-family: FontAwesome;"
                                                    onclick="btn_export_Click" />
                                            </td>
                                        </tr>
                                        <tr id="divPrint" runat="server" style="width: 100%">
                                            <td align="center" style="padding: 5px; margin: 5px; text-align: center;" valign="top">
                                                <asp:gridview id="grdDetails" cssclass="floatingTable" runat="server" autogeneratecolumns="false"
                                                    cellpadding="5" showfooter="True" width="100%" onrowdatabound="grdDetails_RowDataBound">
                                                    <headerstyle height="40px" cssclass="GridviewScrollC1HeaderWrap" />
                                                    <rowstyle cssclass="GridviewScrollC1Item" />
                                                    <pagerstyle cssclass="GridviewScrollC1Pager" />
                                                    <footerstyle height="40px" cssclass="GridviewScrollC1Header" />
                                                    <alternatingrowstyle cssclass="GridviewScrollC1Item2" />
                                                    <columns>
                                                        <asp:templatefield headerstyle-horizontalalign="Center" headertext="S No">
                                                            <itemtemplate>
                                                                <%# Container.DataItemIndex + 1%>
                                                                <asp:HiddenField ID="HdfEncryflag" Value='<%# Eval("PwdEncryflag") %>'  runat="server" />
                                                                <asp:hiddenfield id="Hdfpswd" runat="server" value='<%# Eval("Password") %>' />
                                                                <asp:hiddenfield id="HdfApprovalid" runat="server" />
                                                            </itemtemplate>
                                                            <headerstyle horizontalalign="Center" />
                                                        </asp:templatefield>
                                                        <asp:boundfield datafield="int_fbid" headertext="Helpdesk ID" />
                                                        <asp:templatefield headertext="Reference No">
                                                            <itemtemplate>
                                                                <asp:label id="lblRefNo" target="_blank" text='<%# Eval("hd_Code") %>' runat="server"></asp:label>
                                                                <asp:label visible="false" id="lblpswd"  runat="server"></asp:label>
                                                            </itemtemplate>
                                                            <headerstyle horizontalalign="Left" />
                                                        </asp:templatefield>
                                                        <asp:templatefield headertext="Uid NO/UserID">
                                                            <itemtemplate>
                                                                <asp:hyperlink id="HyperLink2" target="_blank" text='<%# Eval("UID_No") %>' runat="server"
                                                                    navigateurl='<%# Eval("TrackerUrl") %>'>
                                                                </asp:hyperlink>
                                                                <asp:hyperlink id="HyperLink3" target="_blank" text='<%# Eval("CFOUIDNO") %>' runat="server"
                                                                    navigateurl='<%# Eval("CFOTracker") %>'>
                                                                </asp:hyperlink>
                                                                <asp:label id="lblCreatedby" runat="server" text='<%#Eval("Created_by")%>'></asp:label>
                                                            </itemtemplate>
                                                            <headerstyle horizontalalign="Left" />
                                                        </asp:templatefield>
                                                        <asp:boundfield datafield="NameofIndustrialUnder" headertext="Unit Name" />
                                                        <asp:boundfield datafield="Fb_Type" headertext="Feedback Type"></asp:boundfield>
                                                        <asp:boundfield datafield="hd_desc" headertext="User change Request/ Comments">
                                                            <headerstyle horizontalalign="Left" width="300px"></headerstyle>
                                                            <itemstyle horizontalalign="Left" width="300px"></itemstyle>
                                                            <controlstyle width="450px" />
                                                        </asp:boundfield>
                                                        <asp:templatefield headertext="Uploaded Document">
                                                            <itemtemplate>
                                                                <asp:hyperlink id="hypLetter" runat="server" navigateurl='<%#Eval("industriesFilePath") %>' target="_blank"></asp:hyperlink>
                                                                <asp:hyperlink id="hprlink" runat="server" navigateurl='<%#Eval("FilePath") %>' target="_blank"></asp:hyperlink>
                                                            </itemtemplate>
                                                        </asp:templatefield>
                                                        <asp:boundfield datafield="Status" headertext="Status">
                                                            <headerstyle horizontalalign="Left" verticalalign="Middle"></headerstyle>
                                                            <itemstyle horizontalalign="Left" verticalalign="Middle" width="100px"></itemstyle>
                                                        </asp:boundfield>
                                                        <asp:boundfield datafield="Remarks" headertext="Remarks"></asp:boundfield>
                                                        <asp:boundfield datafield="regdate" headertext="Date of Submition">
                                                            <headerstyle horizontalalign="Left" verticalalign="Middle"></headerstyle>
                                                            <itemstyle horizontalalign="Left" verticalalign="Middle" width="150px"></itemstyle>
                                                        </asp:boundfield>
                                                        <asp:boundfield datafield="respdate" headertext="Date of Closure" />
                                                        <asp:boundfield datafield="Up_Date" headertext="Date of Under Proccess" />
                                                        <asp:templatefield headertext="Change Status">
                                                            <itemtemplate>
                                                                <table style="width: 100%" cellspacing="0" cellpadding="2" border="0">
                                                                    <tbody>
                                                                        <tr>
                                                                            <td style="text-align: left" align="left">
                                                                                <asp:dropdownlist id="ddlchStatus" runat="server" width="152px" cssclass="DROPDOWN"
                                                                                    validationgroup="group">
                                                                                    <asp:listitem>Closed</asp:listitem>
                                                                                    <asp:listitem>Rejected</asp:listitem>
                                                                                </asp:dropdownlist>
                                                                            </td>
                                                                        </tr>
                                                                        <tr id="Pending" runat="server">
                                                                            <td style="text-align: left" align="left">
                                                                                <asp:textbox id="txtremarks" tabindex="1" runat="server" width="300px" cssclass="TXTBOX"
                                                                                    validationgroup="group" height="80px" textmode="MultiLine">
                                                                                </asp:textbox>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td style="text-align: left" align="left">
                                                                                <asp:dropdownlist id="ddltypeprob" runat="server" width="152px" cssclass="DROPDOWN"
                                                                                    validationgroup="group">
                                                                                    <asp:listitem>Select</asp:listitem>
                                                                                    <asp:listitem>Application Problem</asp:listitem>
                                                                                    <asp:listitem>General Enquiry</asp:listitem>
                                                                                    <asp:listitem>Data Correction</asp:listitem>
                                                                                    <asp:listitem>Other</asp:listitem>
                                                                                </asp:dropdownlist>
                                                                                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator68" runat="server" ControlToValidate="ddltypeprob"
                                                                        ErrorMessage="Please Select Type of Problem" InitialValue="Select" ValidationGroup="group">*</asp:RequiredFieldValidator>--%>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                <asp:fileupload runat="server" id="fupReply" />
                                                                            </td>

                                                                        </tr>
                                                                        <tr id="Close" runat="server">
                                                                            <td style="padding-bottom: 5px; padding-top: 5px; text-align: center">&nbsp;<asp:button id="BtnSave" tabindex="10" onclick="BtnSave_Click" runat="server"
                                                                                width="122px" text="Change Status" cssclass="BUTTONLONG" validationgroup="group"
                                                                                tooltip="To Save  the data" height="30px"></asp:button>
                                                                            </td>
                                                                        </tr>
                                                                    </tbody>
                                                                </table>
                                                            </itemtemplate>
                                                            <headerstyle horizontalalign="Left"></headerstyle>
                                                            <itemstyle horizontalalign="Left" verticalalign="Top" width="300px"></itemstyle>
                                                        </asp:templatefield>
                                                        <asp:boundfield datafield="anothermailid" visible="False" />
                                                        <%-- <asp:BoundField DataField="intDepartmentApprovalid" HeaderText="Department Approval ID" />--%>
                                                        <asp:templatefield headertext="Attachment" visible="false">
                                                            <itemtemplate>
                                                                <asp:label id="lblFileName" runat="server" text='<%#Eval("LINKNEW") %>'></asp:label>
                                                            </itemtemplate>
                                                        </asp:templatefield>
                                                    </columns>
                                                </asp:gridview>
                                            </td>
                                        </tr>
                                        <tr id="divExport" visible="false" runat="server">
                                            <td align="center" style="text-align: center;" valign="top">
                                                <asp:gridview id="grdExport" runat="server" autogeneratecolumns="true" showfooter="true">
                                                    <columns>
                                                        <asp:templatefield headerstyle-horizontalalign="Center" itemstyle-horizontalalign="Center"
                                                            headertext="S.No">
                                                            <itemtemplate>
                                                                <%# Container.DataItemIndex + 1%>
                                                            </itemtemplate>
                                                            <itemstyle cssclass="text-center" horizontalalign="Center" />
                                                        </asp:templatefield>
                                                    </columns>
                                                    <rowstyle wrap="true" />
                                                </asp:gridview>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left" style="padding: 5px; margin: 5px; text-align: left;" valign="top">&nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center" style="padding: 5px; margin: 5px">
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
                            </div>
                        </div>
                    </div>
                </div>
            </asp:panel>
        </contenttemplate>
        <triggers>
            <asp:postbacktrigger controlid="btn_export" />
            <asp:postbacktrigger controlid="grdDetails" />
        </triggers>
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
