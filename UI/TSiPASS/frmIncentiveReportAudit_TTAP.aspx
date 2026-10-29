<%@ page title="" language="C#" masterpagefile="~/UI/TSiPASS/CCMaster.master" EnableEventValidation="false" autoeventwireup="true" codefile="frmIncentiveReportAudit_TTAP.aspx.cs" inherits="UI_TSiPASS_frmIncentiveReportAudit_TTAP" %>

<%@ register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<asp:content id="Content1" contentplaceholderid="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript">
        function pageLoad() {
            var date = new Date();
            var yrRange = "2015:" + (date.getFullYear() + 1);

            var currentMonth = date.getMonth();
            var currentDate = date.getDate();
            var currentYear = date.getFullYear();

            $("input[id$='txtFromDate']").datepicker(
                {
                    dateFormat: "dd-mm-yy",
                    changeMonth: true,
                    changeYear: true,
                    yearRange: yrRange

                    //  maxDate: new Date(currentYear, currentMonth, currentDate)
                }); // Will run at every postback/AsyncPostback
            $("input[id$='txtTodate']").datepicker(
                {
                    dateFormat: "dd-mm-yy",
                    changeMonth: true,
                    changeYear: true,
                    yearRange: yrRange

                    //  maxDate: new Date(currentYear, currentMonth, currentDate)
                }); // Will run at every postback/AsyncPostback
        }
        $(function () {
            var date = new Date();
            var yrRange = "2015:" + (date.getFullYear() + 1);
            var currentMonth = date.getMonth();
            var currentDate = date.getDate();
            var currentYear = date.getFullYear();
            $("input[id$='txtFromDate']").datepicker(
                {
                    //dateFormat: "dd/mm/yy",
                    dateFormat: "dd-mm-yy",
                    //maxDate: new Date(currentYear, currentMonth, currentDate)
                    changeMonth: true,
                    changeYear: true,
                    yearRange: yrRange
                });
            $("input[id$='txtTodate']").datepicker(
                {
                    dateFormat: "dd-mm-yy",
                    changeMonth: true,
                    changeYear: true,
                    yearRange: yrRange

                    //  maxDate: new Date(currentYear, currentMonth, currentDate)
                }); // Will run at every postback/AsyncPostback
        });
    </script>
   <%-- <script language="javascript" type="text/javascript">
        $(function () {

            $('#MstLftMenu').remove();
        });
    </script>--%>
    <link href="../../css/ui-lightness/jquery-ui-1.8.19.custom.css" rel="stylesheet" />
    <style type="text/css">
        .ui-datepicker {
            font-size: 8pt !important;
            padding: 0.2em 0.2em 0;
            width: 250px;
            color: Black;
            z-index: 9999 !important;
        }

        select {
            color: Black !important;
        }
    </style>
    <style>
        .algnCenter {
            text-align: center;
        }
    </style>
    <script type="text/javascript" language="javascript">

        function OpenPopup() {

            window.open("Lookups/LookupBDC.aspx", "List", "scrollbars=yes,resizable=yes,width=1000,height=650;display = block;position=absolute");

            return false;
        }
    </script>
    <div>
        <table id="divPrint" runat="server" border="0" cellpadding="0" cellspacing="0" style="width: 100%">
            <tr>
                <td style="padding-top: 10px; padding-bottom: 20px; padding-left: 9px; height: 675px;"
                    valign="top" align="center">
                    <div class="col-lg-12">
                        <div class="panel panel-default">
                            <div class="panel-heading" style="text-align: center">
                                <h3 visible="false" id="Government" runat="server" class="panel-title" style="font-weight: bold;">Government of Telangana</h3>
                                <h2 id="H1" runat="server" class="panel-title" style="font-weight: bold;">
                                    <asp:label id="lblHeading" runat="server">Incentive Application Details</asp:label>
                                    <a id="Button2" href="#" onserverclick="Button2_ServerClick"
                                        runat="server">
                                        <img src="viewpdf.aspx?filepathnew=D:/TS-iPASSFinal/Resource/Images/pdf-icon.png" width="20px;" height="20px;" style="float: right;"
                                            alt="PDF" /></a> <a id="Button1" href="#" onserverclick="Button1_ServerClick" runat="server">
                                                <img src="viewpdf.aspx?filepathnew=D:/TS-iPASSFinal/Resource/Images/Excel-icon.png" width="20px;" height="20px;" style="float: right;"
                                                    alt="Excel" /></a></h2>
                            </div>
                        </div>
                    </div>
                    <h1 class="page-head-line" align="left" style="font-size: large" runat="server" id="h1heading"></h1>
                    <div class="panel-body">
                        <table align="center" cellpadding="10" cellspacing="5" style="width: 80%; font-family: 'Trebuchet MS'">
                            <tr>
                                <td>
                                    <table runat="server" id="tblselection" cellpadding="4" cellspacing="5" class="auto-style1">
                                        <tr>
                                            <%-- <td class="col-xs-3" style="padding: 5px; margin: 5px">
                                                    <asp:HyperLink CssClass="btn btn-link" ID="HyperLink1" runat="server" NavigateUrl="~/UI/TSiPASS/ReportsDashboardNew.aspx"
                                                        Text="<< Back">
                                                    </asp:HyperLink>
                                                </td>--%>

                                            <td style="padding: 5px; margin: 5px" align="center" runat="server" id="tdFromDate">
                                                <div class="input-group">
                                                    <div class="input-group-addon">
                                                        From Date
                                                    </div>

                                                    <asp:textbox id="txtFromDate" runat="server" class="form-control txtbox" height="28px" maxlength="40" onkeypress="NumberOnly()" tabindex="1" validationgroup="group" width="125px"></asp:textbox>
                                                    <%-- <cc1:CalendarExtender ID="CalendarExtender2" runat="server" Format="dd-MM-yyyy" TargetControlID="txtFromDate">
                                                    </cc1:CalendarExtender>--%>
                                                </div>
                                            </td>
                                            <td style="padding: 5px; margin: 5px" runat="server" id="tdToDate">

                                                <div class="input-group">
                                                    <div class="input-group-addon">
                                                        To Date
                                                    </div>
                                                    <asp:textbox id="txtTodate" runat="server" class="form-control txtbox" height="28px" maxlength="40" onkeypress="NumberOnly()" tabindex="1" validationgroup="group" width="125px"></asp:textbox>
                                                    <%-- <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd-MM-yyyy" TargetControlID="txtTodate">
                                                    </cc1:CalendarExtender>--%>
                                                </div>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <div class="input-group">
                                                    <div class="input-group-addon">
                                                        Enterprise Type
                                                    </div>
                                                    <asp:dropdownlist id="ddlEntType" runat="server" class="form-control txtbox" height="30px" tabindex="1" validationgroup="group" width="125px">
                                                        <asp:listitem text="--Select--" value="Select"></asp:listitem>
                                                        <asp:listitem text="A1" value="A1"></asp:listitem>
                                                        <asp:listitem text="A2" value="A2"></asp:listitem>
                                                        <asp:listitem text="A3" value="A3"></asp:listitem>
                                                        <asp:listitem text="A4" value="A4"></asp:listitem>
                                                        <asp:listitem text="A5" value="A5"></asp:listitem>
                                                    </asp:dropdownlist>
                                                </div>
                                            </td>
                                            
                                            <td style="padding: 5px; margin: 5px">
                                                <div class="input-group">
                                                    <div class="input-group-addon">
                                                        Incentive Type
                                                    </div>
                                                    <asp:dropdownlist id="ddlIncType" runat="server" class="form-control txtbox" height="30px" tabindex="1" validationgroup="group" width="125px">
                                                        <asp:listitem text="--Select--"></asp:listitem>

                                                    </asp:dropdownlist>
                                                </div>
                                            </td>

                                            <td style="padding: 5px; margin: 5px" align="right">
                                                <asp:button id="Submit" runat="server" cssclass="btn btn-default" tabindex="10"
                                                    text="Submit" onclick="Submit_Click" backcolor="ForestGreen" forecolor="White" />
                                            </td>
                                        </tr>

                                    </table>
                                </td>
                                <td style="padding: 5px; text-align: right; margin: 5px; width: 100%;"></td>


                            </tr>
                            <tr runat="server" id="rptdate">
                                <td colspan="2" class="col-xs-5" style="padding: 5px; text-align: center; margin: 5px">
                                    <asp:label id="Label2" runat="server" cssclass="LBLBLACK"></asp:label>
                                </td>
                            </tr>
                            <tr id="Report" runat="server" visible="false">
                                <td colspan="2" class="col-xs-5" style="padding: 5px; text-align: right; margin: 5px">
                                    <asp:label id="Label1" runat="server" cssclass="LBLBLACK">Report as on date</asp:label>
                                </td>
                            </tr>
                            <%--<tr>
                                    <td colspan="2" class="col-xs-5" style="padding: 5px; text-align: right; margin: 5px">
                                         <asp:Button ID="btnNewPdf" runat="server" CssClass="btn btn-primary" Height="32px" TabIndex="10" Text="Generate Pdf" OnClick="btnNewPdf_Click" />
                                    </td>
                                </tr>--%>
                            <tr id="GridPrint" runat="server">
                                <td colspan="2" align="center" style="padding: 5px; margin: 5px" id="divPrint1" runat="server">
                                    <asp:gridview id="grdDetails" runat="server" autogeneratecolumns="false" cellpadding="4"
                                        width="100%"
                                        showfooter="True" onrowdatabound="grdDetails_RowDataBound" onrowcreated="grdDetails_RowCreated">
                                        <headerstyle forecolor="#FFFFFF" backcolor="#009688" height="40px" cssclass="GridviewScrollC1HeaderWrap" />
                                        <rowstyle height="40px" cssclass="GridviewScrollC1Item" />
                                        <pagerstyle cssclass="GridviewScrollC1Pager" />
                                        <footerstyle forecolor="#FFFFFF" backcolor="#009688" height="40px" cssclass="GridviewScrollC1Footer" />
                                        <alternatingrowstyle height="40px" cssclass="GridviewScrollC1Item2" />
                                        <columns>
                                            <asp:templatefield headerstyle-horizontalalign="Center" headertext="S.No">
                                                <itemtemplate>
                                                    <%# Container.DataItemIndex +1 %>
                                                </itemtemplate>
                                                <headerstyle horizontalalign="Center" />
                                                <itemstyle horizontalalign="Center" cssclass="text-center" />
                                            </asp:templatefield>
                                            <asp:templatefield itemstyle-horizontalalign="left" headertext="Online Application Number">
                                                <itemtemplate>
                                                    <asp:linkbutton runat="server" onclick="Unnamed_Click" text='<%#Eval("ApplicationNo") %>' />
                                                </itemtemplate>
                                            </asp:templatefield>
                                            <asp:boundfield datafield="MasterIncentiveId" headertext="IncentiveID" visible="false" />
                                            <%--<asp:TemplateField HeaderText="Incentiveid" Visible="false">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblEnterperIncentiveID" Text='<%#Eval("EnterperIncentiveID") %>' runat="server" />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>--%>

                                            <asp:boundfield datafield="EMiUdyogAadhar" itemstyle-horizontalalign="left" headertext="EMI Udyog Aadhaar" />
                                            <asp:boundfield datafield="NameofUnit" itemstyle-horizontalalign="left" headertext="Name of Unit" />
                                            <asp:boundfield datafield="District" itemstyle-horizontalalign="left" headertext="District" />
                                            <asp:boundfield datafield="Mandal" itemstyle-horizontalalign="left" headertext="Mandal" />
                                            <asp:boundfield datafield="Village" itemstyle-horizontalalign="left" headertext="Village" />
                                            <asp:boundfield
                                                datafield="DCPDATE"
                                                headertext="DCP Date"
                                                itemstyle-horizontalalign="Left"
                                                itemstyle-width="120px"
                                                headerstyle-width="120px" />

                                            <asp:boundfield
                                                datafield="SLCORDIPC"
                                                headertext="SLC or DIPC"
                                                itemstyle-horizontalalign="Left"
                                                itemstyle-width="150px"
                                                headerstyle-width="150px" />
                                            <asp:boundfield datafield="Scheme" itemstyle-horizontalalign="left" headertext="Scheme" />
                                            <asp:boundfield datafield="ApplciantName" itemstyle-horizontalalign="left" headertext="Applicant Name">
                                                <itemstyle horizontalalign="left"></itemstyle>
                                            </asp:boundfield>
                                            <asp:boundfield datafield="Category" itemstyle-horizontalalign="left" headertext="Enterprise Category">
                                                <itemstyle horizontalalign="left"></itemstyle>
                                            </asp:boundfield>
                                             <asp:BoundField DataField="LineofActivity" ItemStyle-HorizontalAlign="left" HeaderText="Line of Activity">
                                                <ItemStyle HorizontalAlign="left"></ItemStyle>
                                            </asp:BoundField>
                                            <asp:boundfield datafield="IncentiveName" itemstyle-horizontalalign="left" headertext="Incentive Type">
                                                <itemstyle horizontalalign="left"></itemstyle>
                                            </asp:boundfield>
                                            <%-- <asp:BoundField DataField="Noofincentive" ItemStyle-HorizontalAlign="left" HeaderText="No of Incentives">
                                                <ItemStyle HorizontalAlign="left"></ItemStyle>
                                            </asp:BoundField>--%>
                                            <asp:boundfield datafield="Caste" itemstyle-horizontalalign="left" headertext="Social Category">
                                                <itemstyle horizontalalign="left"></itemstyle>
                                            </asp:boundfield>
                                            <asp:boundfield datafield="ApplicationDate" itemstyle-horizontalalign="left" headertext="Date of Application">
                                                <itemstyle horizontalalign="left"></itemstyle>
                                            </asp:boundfield>
                                            <asp:boundfield datafield="DATEOFSANCTION" itemstyle-horizontalalign="left" headertext="Date of Sanction">
                                                <itemstyle horizontalalign="left"></itemstyle>
                                            </asp:boundfield>
                                            <asp:templatefield headertext="Sanctioned Amount (Rs.)">
                                                <itemtemplate>
                                                    <asp:label id="lblRecommendedAmount" text='<%#Eval("SanctionedAmount") %>' runat="server" />
                                                </itemtemplate>
                                            </asp:templatefield>
                                            <asp:boundfield datafield="Applicationstatus" itemstyle-horizontalalign="left" headertext="Application Status">
                                                <itemstyle horizontalalign="left"></itemstyle>
                                            </asp:boundfield>
                                            <asp:boundfield datafield="DATEOFRELEASE" itemstyle-horizontalalign="left" headertext="Date of Release">
                                                <itemstyle horizontalalign="left"></itemstyle>
                                            </asp:boundfield>
                                            <asp:boundfield datafield="SLCORDIPCDATE" itemstyle-horizontalalign="left" headertext="SLC or DIPC Date">
                                                <itemstyle horizontalalign="left"></itemstyle>
                                            </asp:boundfield>
                                            <asp:templatefield headertext="Incentiveid" visible="false">
                                                <itemtemplate>
                                                    <asp:label id="lblIncentiveID" text='<%#Eval("IncentiveId") %>' runat="server" />
                                                </itemtemplate>
                                            </asp:templatefield>
                                            <asp:boundfield datafield="Diffabled" itemstyle-horizontalalign="left" headertext="Differently Abled">
                                                <itemstyle horizontalalign="left"></itemstyle>
                                            </asp:boundfield>
                                            <asp:boundfield datafield="InvestmentPandM" itemstyle-horizontalalign="left" headertext="Investment(In Rs)">
                                                <itemstyle horizontalalign="left"></itemstyle>
                                            </asp:boundfield>
                                            <asp:boundfield datafield="Gender" itemstyle-horizontalalign="left" headertext="Gender">
                                                <itemstyle horizontalalign="left"></itemstyle>
                                            </asp:boundfield>
                                            <asp:boundfield datafield="CLAIMEDAMOUNT" itemstyle-horizontalalign="left" headertext="Claimed Amount(In Rs)">
    <itemstyle horizontalalign="left"></itemstyle>
</asp:boundfield>
                                        </columns>
                                    </asp:gridview>
                                </td>
                            </tr>
                        </table>
                    </div>
                </td>
            </tr>
        </table>
    </div>

</asp:content>

