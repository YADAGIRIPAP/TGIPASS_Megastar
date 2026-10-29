<%@ page title="" language="C#" masterpagefile="~/UI/TSIPASS/CCMaster.master" autoeventwireup="true" codefile="DistrictWiseUpdateabstarctDrill.aspx.cs" inherits="UI_TSIPASS_DistrictWiseUpdateabstarctDrill" enableeventvalidation="false" %>

<%@ register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<%@ register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="ajaxtoolkit" %>
<asp:content id="Content1" contentplaceholderid="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript">
        function GetRowValue(val) {
            if (val != '&nbsp;') {
                val1 = 0;
                window.opener.document.getElementById('ctl00_ContentPlaceHolder1_hdfID').value = val;
                window.opener.document.getElementById('ctl00_ContentPlaceHolder1_hdfFlagID').value = val1;

            }
            window.opener.document.forms[0].submit();
            self.close();

        }
        $(function () {

            $('#MstLftMenu').remove();

        });
    </script>
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
    <script type="text/javascript">
        function pageLoad() {
            var date = new Date();
            var yrRange = "2015:" + (date.getFullYear() + 1);

            var currentMonth = date.getMonth();
            var currentDate = date.getDate();
            var currentYear = date.getFullYear();

            $("input[id$='TXTINTERACTIONDATE']").datepicker(
                {
                    dateFormat: "dd-mm-yy",
                    changeMonth: true,
                    changeYear: true,
                    yearRange: yrRange

                    //  maxDate: new Date(currentYear, currentMonth, currentDate)
                }); // Will run at every postback/AsyncPostback
            $("input[id$='TXTDCP']").datepicker(
                {
                    dateFormat: "dd-mm-yy",
                    changeMonth: true,
                    changeYear: true,
                    yearRange: yrRange

                    //  maxDate: new Date(currentYear, currentMonth, currentDate)
                });
        }
        $(function () {
            var date = new Date();
            var yrRange = "2015:" + (date.getFullYear() + 1);
            var currentMonth = date.getMonth();
            var currentDate = date.getDate();
            var currentYear = date.getFullYear();
            $("input[id$='TXTINTERACTIONDATE']").datepicker(
                {
                    //dateFormat: "dd/mm/yy",
                    dateFormat: "dd-mm-yy",
                    //maxDate: new Date(currentYear, currentMonth, currentDate)
                    changeMonth: true,
                    changeYear: true,
                    yearRange: yrRange
                });
            $("input[id$='TXTDCP']").datepicker(
                {
                    dateFormat: "dd-mm-yy",
                    changeMonth: true,
                    changeYear: true,
                    yearRange: yrRange

                    //  maxDate: new Date(currentYear, currentMonth, currentDate)
                });
        });
    </script>
    <style type="text/css" media="print">
        @page {
            size: landscape;
        }
    </style>
    <style type="text/css">
        blink, .blink {
            animation: blinker 1s linear infinite;
        }

        @keyframes blinker {
            50% {
                opacity: 0;
            }
        }


        .update {
            position: fixed;
            top: 0px;
            left: 0px;
            min-height: 100%;
            min-width: 100%;
            background-image: url("../../Images/ajax-loaderblack.gif"); /*background-image: url("Images/spinner_60.gif");*/
            background-position: center center;
            background-repeat: no-repeat; /*background-color: #e4e4e6;*/
            background-color: #535252;
            z-index: 500 !important;
            opacity: 0.6;
            overflow: hidden;
        }
    </style>
    <asp:updateprogress id="UpdateProgress" runat="server" associatedupdatepanelid="updatepanel1">
        <progresstemplate>
            <div class="update">
            </div>
        </progresstemplate>
    </asp:updateprogress>

    <asp:updatepanel id="UpdatePanel1" runat="server" updatemode="Always">

        <contenttemplate>
            <asp:panel id="Panel_1" runat="server">

                <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
                    <tr>
                        <td style="padding-top: 10px; padding-bottom: 20px; padding-left: 9px; height: 675px;"
                            valign="top" align="center">



                            <div class="panel panel-primary">
                                <div class="panel-heading">
                                    <h3 class="panel-title">
                                        <asp:label id="Label1" runat="server" font-bold="True" font-names="verdana" font-size="15px"></asp:label>
                                        <%--<a id="A2" href="#" onserverclick="BtnSave2_Click1" runat="server">
                    <img src="../../Resource/Images/Excel-icon.png" width="20px;" height="20px;" style="float: right;"
                        alt="Excel" /></a>--%>
                                        <asp:imagebutton imageurl="~/Resource/Images/Excel-icon.png" id="excel_button" onclick="BtnSave2_Click1" width="20px" height="20px" style="float: right;" runat="server" />
                                    </h3>
                                </div>
                                <div class="panel-body">
                                    <table align="center" cellpadding="10" cellspacing="5" style="width: 80%">
                                        <tr>
                                            <td align="center" style="padding: 5px; margin: 5px">
                                                <asp:label id="lblMsg" runat="server" font-bold="True" font-names="verdana" font-size="13px"
                                                    forecolor="#006600"></asp:label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="text-align: left">
                                                <asp:hyperlink cssclass="btn btn-link" id="HyperLink1" runat="server" navigateurl="~/UI/TSiPASS/DistrictWiseUpdateabstarct.aspx" text="<< Back"></asp:hyperlink>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center" style="padding: 5px; margin: 5px">
                                                <table style="width: 100%">
                                                    <tr>
                                                        <td align="center" style="text-align: right" valign="middle">
                                                            <asp:label id="Label450" runat="server" cssclass="LBLBLACK" width="200px">District</asp:label>
                                                        </td>
                                                        <td>:
                                                        </td>
                                                        <td>
                                                            <asp:dropdownlist id="ddlConnectLoad" runat="server" class="form-control txtbox"
                                                                height="33px" width="180px" tabindex="1">
                                                                <asp:listitem>--Select--</asp:listitem>
                                                            </asp:dropdownlist>
                                                        </td>
                                                        <td>&nbsp;&nbsp; &nbsp;
                                                        </td>
                                                        <td>
                                                            <asp:label id="Label451" runat="server" cssclass="LBLBLACK" width="200px">Unit name</asp:label>
                                                        </td>
                                                        <td>&nbsp;
                                                        </td>
                                                        <td>
                                                            <asp:textbox id="txtUnitname" runat="server" class="form-control txtbox" height="28px"
                                                                maxlength="80" tabindex="2" validationgroup="Save" width="180px">
                                                            </asp:textbox>
                                                        </td>
                                                        <td>&nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="8" align="center">
                                                            <asp:label id="lblMsg0" runat="server" font-bold="True" font-names="verdana" font-size="13px"
                                                                forecolor="#006600"></asp:label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center" style="padding: 5px; margin: 5px; text-align: center;">
                                                <asp:button id="BtnSave1" runat="server" cssclass="btn btn-primary" height="32px"
                                                    onclick="BtnSave1_Click" tabindex="10" text="Search" validationgroup="group"
                                                    width="90px" />
                                                &nbsp;
                                    <asp:button id="BtnClear" runat="server" causesvalidation="False" cssclass="btn btn-warning"
                                        height="32px" tabindex="10" text="Cancel" tooltip="To Clear  the Screen" width="90px"
                                        onclick="BtnClear_Click" />



                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left" style="padding: 5px; margin: 5px; text-align: left;">
                                                <b>Note :1) DIC has to upload Undertaking form from the unit holder, describe that they
                                        have dropped the project</b>
                                                <br />
                                                <div align="right">
                                                    <blink><b style="color: red;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;2) The Uploaded file size should be less than 2MB</b></blink>
                                                </div>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center" style="padding: 5px; margin: 5px" id="Panel1" runat="server">
                                                <%--<asp:Panel ID="Panel1" runat="server" ScrollBars="Both" Style="width: 1000px" Height="600px">--%>
                                                <asp:gridview id="grdDetails" runat="server" autogeneratecolumns="False" cellpadding="4"
                                                    forecolor="#333333" height="62px" onrowdatabound="grdDetails_RowDataBound"
                                                    width="100%" onpageindexchanging="grdDetails_PageIndexChanging"
                                                    showfooter="True" onrowcreated="grdDetails_RowCreated">
                                                    <headerstyle forecolor="#FFFFFF" backcolor="#009688" height="40px" cssclass="GridviewScrollC1HeaderWrap" />
                                                    <rowstyle height="40px" cssclass="GridviewScrollC1Item" />
                                                    <pagerstyle cssclass="GridviewScrollC1Pager" />
                                                    <footerstyle forecolor="#FFFFFF" backcolor="#009688" height="40px" cssclass="GridviewScrollC1Footer" />
                                                    <alternatingrowstyle height="40px" cssclass="GridviewScrollC1Item2" />
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
                                                        <asp:templatefield headertext="Unit Name">
                                                            <itemtemplate>
                                                                <asp:hyperlink id="HyperLink2" target="_blank" runat="server" navigateurl='<%# Eval("intQuessionaireid", "ApplicationTrakerDetailed.aspx?ID={0}") %>'
                                                                    text='<%# Eval("UnitName") %>' />
                                                            </itemtemplate>
                                                        </asp:templatefield>

                                                        <%-- <asp:BoundField DataField="UnitName" HeaderText="Unit Name" />--%>
                                                        <asp:templatefield headertext="UID No">
                                                            <itemtemplate>
                                                                <asp:hyperlink id="HyperLink1" target="_blank" runat="server" navigateurl='<%# Eval("intCFEEnterpidnew", "ViewCFEPrint.aspx?Id={0}") %>'
                                                                    text='<%# Eval("UID_No") %>' />
                                                            </itemtemplate>
                                                        </asp:templatefield>
                                                        <%--<asp:BoundField DataField="UID_No" HeaderText="UID No" />--%>
                                                        <asp:boundfield datafield="Mno" headertext="Mobile Number" />
                                                        <asp:boundfield datafield="lineofActivity" headertext="line of Activity" />
                                                        <asp:boundfield datafield="District" headertext="District" />
                                                        <asp:boundfield datafield="Manda_lName" headertext="Mandal" />
                                                        <asp:boundfield datafield="Investment" headertext="Investment(Rs. in Crs)" />
                                                        <asp:boundfield datafield="NoofEmployee" headertext="No of Employee" />
                                                        <asp:boundfield datafield="ApplicationDate" headertext="Application Date" dataformatstring="{0:dd/MM/yyyy}" />
                                                        <asp:boundfield datafield="ApprovalDate" headertext="Approval Date" dataformatstring="{0:dd/MM/yyyy}" />
                                                        <asp:boundfield datafield="Progress" headertext="Progress" />
                                                        <%--<asp:BoundField DataField="Status" HeaderText="Status" />--%>
                                                        <asp:templatefield headertext="Update The Status">
                                                            <itemtemplate>
                                                                <table style="width: 100%" cellpadding="4" cellspacing="5">
                                                                    <tr>
                                                                        <td style="width: 132px; height: 29px">
                                                                            <asp:dropdownlist id="ddlStatus" runat="server" width="220px" cssclass="DROPDOWN"
                                                                                autopostback="True" onselectedindexchanged="ddlStatus_SelectedIndexChanged">
                                                                                <asp:listitem>--Select--</asp:listitem>
                                                                                <asp:listitem>COMMENCED OPERATIONS</asp:listitem>
                                                                                <asp:listitem>YET TO START CONSTRUCTION</asp:listitem>
                                                                                <asp:listitem>ADVANCED STAGE</asp:listitem>
                                                                                <asp:listitem>INITIAL STAGE</asp:listitem>
                                                                                <asp:listitem>DROPPED</asp:listitem>
                                                                            </asp:dropdownlist>
                                                                        </td>
                                                                    </tr>
                                                                    <tr id="TRRBTINTERACTED" runat="server" visible="false">
                                                                        <td style="width: 132px; height: 29px">
                                                                            <b>Whether interacted :</b>
                                                                            <asp:radiobuttonlist id="rbtinteracted" repeatdirection="Horizontal" autopostback="true" runat="server" onselectedindexchanged="rbtinteracted_SelectedIndexChanged">
                                                                                <asp:listitem value="1">YES</asp:listitem>
                                                                                <asp:listitem value="0">NO</asp:listitem>
                                                                            </asp:radiobuttonlist>
                                                                        </td>
                                                                    </tr>
                                                                    <tr id="TRRBTINTERACTIONDATE" runat="server" visible="false">
                                                                        <td style="width: 132px; height: 29px">
                                                                            <b>Date of Interaction :</b>
                                                                            <asp:textbox id="TXTINTERACTIONDATE" height="30PX" width="220px"
                                                                                runat="server">
                                                                            </asp:textbox>
                                                                        </td>
                                                                    </tr>
                                                                    <tr id="TRWORKINGSTATUS" runat="server" visible="false">
                                                                        <td style="width: 132px; height: 29px">
                                                                            <b>Present Working Status :</b>
                                                                            <asp:textbox id="TXTPRESENTWORKINGSTATUS" height="30px" width="220px"
                                                                                runat="server">
                                                                            </asp:textbox>
                                                                            <br>
                                                                                <b>DCP Date :</b>
                                                                                <asp:textbox id="TXTDCP" height="30px" width="220px"
                                                                                    runat="server">
                                                                                </asp:textbox>
                                                                            </br>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="width: 132px; height: 29px">
                                                                            <b>Remarks For Status Change :</b>
                                                                            <asp:textbox id="txtreasonschange" textmode="MultiLine" height="80px" width="250px"
                                                                                text='<%# Eval("RemarksStatus") %>' runat="server">
                                                                            </asp:textbox>
                                                                        </td>
                                                                    </tr>
                                                                    <tr id="dropupload" runat="server" visible="false">
                                                                        <td><b>Upload Document : </b>
                                                                            <div style="float: left">
                                                                                <asp:fileupload id="fluPrincipalEmployersRegistrationCertificate" width="220px" runat="server"
                                                                                    height="28px" />
                                                                                <asp:label forecolor="Blue" runat="server" id="Label6new"></asp:label>
                                                                            </div>
                                                                        </td>
                                                                    </tr>

                                                                    <tr id="Truploadpicture" runat="server">
                                                                        <td><b>Upload Picture : </b>
                                                                            <div style="float: left">
                                                                                <asp:fileupload id="FileUpload1" width="220px" runat="server"
                                                                                    height="28px" />
                                                                                <asp:label forecolor="Blue" runat="server" id="Label2"></asp:label>
                                                                            </div>
                                                                        </td>
                                                                    </tr>

                                                                    <tr>
                                                                        <td align="center">
                                                                            <asp:button id="BtnSaveg" runat="server" cssclass="btn btn-primary" height="30px" tabindex="10"
                                                                                text="Submit" validationgroup="group" width="80px" onclick="BtnSaveg_Click" />
                                                                            <asp:hiddenfield id="HdfintApplicationid" runat="server" />
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </itemtemplate>
                                                        </asp:templatefield>
                                                        <asp:boundfield datafield="LastUpdateddate" itemstyle-font-bold="true" headertext="Last Updated Date" />
                                                    </columns>

                                                </asp:gridview>
                                                <%--</asp:Panel>--%>
                                                <asp:label id="lblresult" runat="server" cssclass="LBLBLACK" width="200px"></asp:label>
                                            </td>
                                        </tr>
                                        <%--<tr id="divExport" visible="false" runat="server">
                                <td align="center" style="text-align: center;" valign="top">
                                    <asp:GridView ID="grdExport1" runat="server" AutoGenerateColumns="true" ShowFooter="true">
                                        <Columns>
                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center"
                                                HeaderText="S.No">
                                                <ItemTemplate>
                                                    <%# Container.DataItemIndex + 1%>
                                                </ItemTemplate>
                                                <ItemStyle CssClass="text-center" HorizontalAlign="Center" />
                                            </asp:TemplateField>
                                        </Columns>
                                        <RowStyle Wrap="true" />
                                    </asp:GridView>
                                </td>
                            </tr>--%>
                                        <tr id="Tr1" runat="server" visible="false">
                                            <td align="center" style="padding: 5px; margin: 5px">
                                                <asp:panel id="Panel2" runat="server" scrollbars="Both" style="width: 1000px" height="600px">
                                                    <asp:gridview id="GridExport" runat="server" autogeneratecolumns="False">
                                                        <columns>
                                                            <asp:templatefield headerstyle-horizontalalign="Center" headertext="S No">
                                                                <itemtemplate>
                                                                    <%# Container.DataItemIndex + 1%>
                                                                </itemtemplate>
                                                                <headerstyle horizontalalign="Center" />
                                                                <itemstyle width="50px" />
                                                            </asp:templatefield>
                                                            <asp:boundfield datafield="UnitName" headertext="Unit Name" />
                                                            <asp:boundfield datafield="UID_No" headertext="UID No" />
                                                            <asp:boundfield datafield="Address" headertext="Address" />
                                                            <asp:boundfield datafield="lineofActivity" headertext="line of Activity" />
                                                            <asp:boundfield datafield="District" headertext="District" />
                                                            <asp:boundfield datafield="Manda_lName" headertext="Mandal" />
                                                            <asp:boundfield datafield="MobileNumber" headertext="Mobile No" />
                                                            <asp:boundfield datafield="Sector" headertext="Sector" />
                                                            <asp:boundfield datafield="Investment" headertext="Investment(Rs. in Crs)" />
                                                            <asp:boundfield datafield="NoofEmployee" headertext="No of Employee" />
                                                            <asp:boundfield datafield="ApplicationDate" headertext="Application Date" dataformatstring="{0:dd/MM/yyyy}" />
                                                            <asp:boundfield datafield="ApprovalDate" headertext="Approval Date" dataformatstring="{0:dd/MM/yyyy}" />
                                                            <asp:boundfield datafield="Progress" headertext="Progress" />
                                                            <asp:boundfield datafield="Status" headertext="Status" />
                                                        </columns>
                                                    </asp:gridview>
                                                </asp:panel>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="text-align: left">
                                                <asp:hyperlink cssclass="btn btn-link" id="HyperLink2" runat="server" navigateurl="~/UI/TSiPASS/DistrictWiseUpdateabstarct.aspx" text="<< Back"></asp:hyperlink>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </div>
                        </td>
                    </tr>
                </table>

            </asp:panel>
        </contenttemplate>
        <triggers>
            <asp:postbacktrigger controlid="excel_button" />
        </triggers>
    </asp:updatepanel>
</asp:content>
