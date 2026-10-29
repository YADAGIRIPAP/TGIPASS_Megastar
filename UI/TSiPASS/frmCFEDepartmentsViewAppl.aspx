<%@ page title=":: TS-iPASS ::  " language="C#" masterpagefile="~/UI/TSiPASS/CCMaster.master"
    autoeventwireup="true" codefile="frmCFEDepartmentsViewAppl.aspx.cs" inherits="TSTBDCReg1" %>

<%@ register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
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
    <script type="text/javascript" language="javascript">
        function inputOnlyNumbers(evt) {
            var e = window.event || evt; // for trans-browser compatibility 
            var charCode = e.which || e.keyCode;
            //            if ((charCode > 45 && charCode < 58) || charCode == 8 || charCode == 9) {
            //                return true;
            //            }
            if (((charCode > 45 && charCode < 58) || charCode == 8 || charCode == 9) && charCode != 46 && charCode != 47) {
                return true;
            }
            return false;
        }
    </script>
    <asp:updatepanel id="upd1" runat="server">
        <contenttemplate>
            <div align="left">
                <ol class="breadcrumb">
                    You are here &nbsp;!&nbsp; &nbsp; &nbsp;
                    <li><i class="fa fa-dashboard"></i><a href="Home.aspx"></a></li>
                    <li class=""><i class="fa fa-fw fa-edit">CFE</i> </li>
                    <li class="active"><i class="fa fa-edit"></i><a href="#">View Applications</a> </li>
                </ol>
            </div>
            <div align="left">
                <div class="row" align="left">
                    <div class="col-lg-11">
                        <div class="panel panel-primary">
                            <div class="panel-heading" align="center">
                                <h3 class="panel-title">View Applications</h3>
                            </div>
                            <asp:updatepanel id="UpdatePanel1" runat="server">
                                <contenttemplate>
                                    <div class="panel-body">
                                        <table align="center" cellpadding="10" cellspacing="5" style="width: 90%">
                                            <tr>
                                                <td align="left" style="padding: 5px; margin: 5px" valign="top">
                                                    <table cellpadding="7" cellspacing="7" width="100%">
                                                        <tr>
                                                            <td valign="top"></td>
                                                            <td>&nbsp;
                                                            </td>
                                                            <td>
                                                                <asp:label id="Label10" runat="server" cssclass="LBLBLACK" width="180px">Name of Unit</asp:label>
                                                            </td>
                                                            <td>:
                                                            </td>
                                                            <td>
                                                                <asp:textbox id="TxtnameofUnit" runat="server" class="form-control txtbox"
                                                                    height="28px" maxlength="50" tabindex="0" validationgroup="group" width="180px">
                                                                </asp:textbox>
                                                            </td>
                                                            <td>&nbsp;
                                                            </td>
                                                            <td>
                                                                <asp:label id="Label380" runat="server" cssclass="LBLBLACK" width="180px">UID Number</asp:label>
                                                            </td>
                                                            <td valign="top">:
                                                            </td>
                                                            <td valign="top">
                                                                <asp:textbox id="TxtnameofUnit0" runat="server" class="form-control txtbox"
                                                                    height="28px" maxlength="50" tabindex="0" validationgroup="group" width="180px">
                                                                </asp:textbox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td valign="top">&nbsp;
                                                            </td>
                                                            <td>&nbsp;
                                                            </td>
                                                            <td>&nbsp;
                                                            </td>
                                                            <td>&nbsp;
                                                            </td>
                                                            <td>&nbsp;
                                                            </td>
                                                            <td>&nbsp;
                                                            </td>
                                                            <td>&nbsp;
                                                            </td>
                                                            <td valign="top">&nbsp;
                                                            </td>
                                                            <td valign="top">&nbsp;
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td valign="top">&nbsp;
                                                            </td>
                                                            <td>&nbsp;
                                                            </td>
                                                            <td>
                                                                <asp:label id="Label381" runat="server" cssclass="LBLBLACK" width="180px">District</asp:label>
                                                            </td>
                                                            <td>:
                                                            </td>
                                                            <td>
                                                                <asp:dropdownlist id="ddldistrict" runat="server" class="form-control txtbox"
                                                                    height="33px" tabindex="1" width="180px">
                                                                    <asp:listitem>--Select--</asp:listitem>
                                                                </asp:dropdownlist>
                                                            </td>
                                                            <td>&nbsp;
                                                            </td>
                                                            <td>
                                                                <asp:label id="Label382" runat="server" cssclass="LBLBLACK" width="180px">Level</asp:label>
                                                            </td>
                                                            <td valign="top">:
                                                            </td>
                                                            <td valign="top">
                                                                <asp:dropdownlist id="ddldistrict0" runat="server" class="form-control txtbox" height="33px"
                                                                    tabindex="1" width="180px">
                                                                    <asp:listitem>--Select--</asp:listitem>
                                                                    <asp:listitem value="1">State Level</asp:listitem>
                                                                    <asp:listitem value="2">District Level</asp:listitem>
                                                                </asp:dropdownlist>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td valign="top">&nbsp;
                                                            </td>
                                                            <td>&nbsp;
                                                            </td>
                                                            <td>&nbsp;
                                                            </td>
                                                            <td>&nbsp;
                                                            </td>
                                                            <td align="center" colspan="3">&nbsp;
                                                            </td>
                                                            <td valign="top">&nbsp;
                                                            </td>
                                                            <td valign="top">&nbsp;
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td valign="top">&nbsp;
                                                            </td>
                                                            <td>&nbsp;
                                                            </td>
                                                            <td>&nbsp;
                                                            </td>
                                                            <td>&nbsp;
                                                            </td>
                                                            <td align="center" colspan="3">
                                                                <asp:button id="BtnSave0" runat="server" causesvalidation="False" cssclass="btn-success"
                                                                    height="32px" onclick="BtnClear0_Click" tabindex="10" text="Search" validationgroup="group"
                                                                    width="80px" />
                                                            </td>
                                                            <td valign="top">&nbsp;
                                                            </td>
                                                            <td valign="top">&nbsp;
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left" style="padding: 5px; margin: 5px" valign="top">
                                                    <asp:gridview id="grdDetails" runat="server" autogeneratecolumns="False" cellpadding="5"
                                                        forecolor="#333333" height="62px" onrowdatabound="grdDetails_RowDataBound" showfooter="True"
                                                        width="100%">
                                                        <footerstyle backcolor="#013161" font-bold="True" forecolor="White" />
                                                        <rowstyle backcolor="#EBF2FE" horizontalalign="Left" verticalalign="Middle" />
                                                        <columns>
                                                            <asp:templatefield headerstyle-horizontalalign="Center" headertext="S No">
                                                                <itemtemplate>
                                                                    <%# Container.DataItemIndex + 1%>
                                                                    <asp:hiddenfield id="HdfQueid" runat="server" />
                                                                    <asp:hiddenfield id="HdfApprovalid" runat="server" />
                                                                    <asp:hiddenfield id="hdfGroundedNo" runat="server" />
                                                                    <asp:hiddenfield id="hdfGroundedNo0" runat="server" />
                                                                    <asp:hiddenfield id="hdfGroundedNo1" runat="server" />
                                                                    <asp:hiddenfield id="hdfGroundedNo2" runat="server" />
                                                                    <asp:hiddenfield id="hdfGroundedNo3" runat="server" />
                                                                    <asp:hiddenfield id="hdfApplID" runat="server" />

                                                                </itemtemplate>
                                                                <headerstyle horizontalalign="Center" />
                                                                <itemstyle width="50px" />
                                                            </asp:templatefield>
                                                            <asp:templatefield headertext="View">
                                                                <itemtemplate>
                                                                    <asp:linkbutton id="LinkButton1" runat="server" text='<%# Eval("UID_No") %>'></asp:linkbutton>
                                                                </itemtemplate>
                                                                <headerstyle horizontalalign="Left" />
                                                            </asp:templatefield>
                                                            <asp:boundfield datafield="nameofunit" headertext="Name of Unit" />
                                                            <asp:boundfield datafield="NameofthePromoter" headertext="Name of Industry" visible="false" />
                                                            <asp:boundfield datafield="Sec_EnterpriseName" headertext="Activity Proposed" />
                                                            <asp:boundfield datafield="ApprovalName" headertext="Approval name" />
                                                            <asp:boundfield datafield="DateofSubmittion" headertext="Date of Submission" />
                                                            <asp:boundfield datafield="LastDateofPreScrutiy" headertext="Last Date of Pre-Scrutiny" />
                                                            <asp:hyperlinkfield headertext="CFE/CFO" text="View" />
                                                            <asp:hyperlinkfield headertext="Attachments" text="Attachments" />
                                                            <asp:hyperlinkfield headertext="Query / Response" text="Query / Response" />
                                                            <asp:templatefield headertext="Status">
                                                                <itemtemplate>
                                                                    <asp:label id="Label377" runat="server" cssclass="LBLBLACK" width="180px">Status</asp:label>
                                                                    <br />
                                                                    <asp:dropdownlist id="ddlStatus" runat="server" autopostback="True" class="form-control txtbox"
                                                                        height="33px" onselectedindexchanged="ddlStatus_SelectedIndexChanged" width="180px">
                                                                        <asp:listitem>--Select--</asp:listitem>
                                                                        <asp:listitem value="12">Completed</asp:listitem>
                                                                        <asp:listitem value="11">Completed with Payment Request</asp:listitem>
                                                                        <asp:listitem value="5">Query Raised</asp:listitem>
                                                                        <asp:listitem value="16">Rejected</asp:listitem>

                                                                    </asp:dropdownlist>
                                                                    <%--  <asp:ListItem Value="16">Rejected</asp:ListItem>--%>
                                                                    <br />
                                                                    <asp:label id="LabelDiscription" font-bold="true" forecolor="Red" runat="server"
                                                                        cssclass="LBLBLACK" visible="False" width="180px" text=""></asp:label>
                                                                    <br />
                                                                    <asp:label id="Label378" runat="server" cssclass="LBLBLACK" visible="False" width="180px"
                                                                        text="Query Description"></asp:label>
                                                                    <br />
                                                                    <asp:textbox id="txtPromotor" runat="server" class="form-control txtbox" height="40px"
                                                                        tabindex="1" textmode="MultiLine" validationgroup="group" visible="False" width="180px">
                                                                    </asp:textbox>
                                                                    <asp:requiredfieldvalidator id="RequiredFieldValidator8" runat="server" controltovalidate="txtPromotor"
                                                                        errormessage="Please Enter Discription" tabindex="1" validationgroup="group">
                                                                        *</asp:requiredfieldvalidator>
                                                                    <br />
                                                                    <asp:label id="Label379" runat="server" cssclass="LBLBLACK" visible="False" width="180px">Amount</asp:label>
                                                                    <br />
                                                                    <asp:textbox id="txtAmount" runat="server" class="form-control txtbox" height="27px"
                                                                        maxlength="40" tabindex="1" validationgroup="group" onkeypress="return inputOnlyNumbers(event)"
                                                                        visible="False" width="180px" onpaste="return false">
                                                                    </asp:textbox>
                                                                    <asp:requiredfieldvalidator id="RequiredFieldValidator1" runat="server" controltovalidate="txtAmount"
                                                                        errormessage="Please Enter Amount" tabindex="1" validationgroup="group">
                                                                        *</asp:requiredfieldvalidator>
                                                                    <br />
                                                                    <%--sowjanya--%>
                                                                    <br />
                                                                    <asp:label id="lblIrrgFsbltyRept" runat="server" cssclass="LBLBLACK" visible="False" width="180px" text="Please Upload Feasibility Report"></asp:label>
                                                                    <asp:fileupload id="fupIrrgFsbltyRept" runat="server" visible="false" />
                                                                    <asp:label id="lblFsbltyReptName" runat="server" visible="false"></asp:label>
                                                                    <br></br>
                                                                    <asp:button id="btnIrrgFsbltyRept" runat="server" backcolor="Green" text="Upolad" onclick="btnIrrgFsbltyRept_Click" visible="false" />
                                                                    <%--sowjanya--%>
                                                                </itemtemplate>
                                                            </asp:templatefield>
                                                            <asp:templatefield headertext="Submit">
                                                                <itemtemplate>
                                                                    <asp:button id="BtnSave" runat="server" causesvalidation="False" cssclass="btn-success"
                                                                        height="32px" onclick="BtnSave_Click1" onclientclick="return confirm('Do you want to update the record ? ');"
                                                                        tabindex="10" text="Submit" validationgroup="group" width="80px" />

                                                                </itemtemplate>
                                                            </asp:templatefield>
                                                            <asp:boundfield datafield="District_Name" headertext="District name" />
                                                            <asp:boundfield datafield="Manda_lName" headertext="Mandal_Name" />
                                                            <asp:boundfield datafield="Village_Name" headertext="Village name" />
                                                            <asp:hyperlinkfield headertext="Payment Details" text="Payment Details" />
                                                            <asp:boundfield datafield="RefNo" headertext="Reference Number" />
                                                            <asp:hyperlinkfield headertext="Document" text="View" />
                                                            <asp:hyperlinkfield headertext="Feasbility Details" text="Feasbility Details" />
                                                            <asp:boundfield visible="false" datafield="ReasonForRejection" headertext="Reason For Rejection" />
                                                            <asp:boundfield datafield="Dept_Name" headertext="Transfered From" />
                                                            <asp:boundfield datafield="UPDATEDFLAG" headertext="Process" />
                                                            <asp:boundfield datafield="DTCP_MUNCIPALFLAG" headertext="DTCPFLAG" />
                                                            <asp:boundfield datafield="CAFNUMBER" headertext="CAF NUMBER" />
                                                            <asp:boundfield datafield="NICAPPLICATIONNUMBER" headertext="NIC APPLICATION NUMBER" />
                                                            <asp:boundfield datafield="Questionnaireid" headertext="Questionnaire id" />
                                                            <asp:templatefield headertext="Appeal Action" visible="false">
                                                                <itemtemplate>
                                                                    <asp:textbox runat="server" class="form-control txtbox" height="50px" width="180px"
                                                                        autocomplete="false" id="TxtReject" visible="false" placeholder="Remarks" textmode="MultiLine" />
                                                                    <br />
                                                                    <br />
                                                                    <asp:button id="BtnRevoke" runat="server" causesvalidation="False" cssclass="btn-success"
                                                                        height="32px" onclick="BtnRevoke_Click" onclientclick="return confirm('Do you want to update the record ? ');"
                                                                        tabindex="10" text="Revoke" validationgroup="group" width="100px" />
                                                                    <br />
                                                                    <br />
                                                                    <asp:button id="BtnReject" runat="server" causesvalidation="False" cssclass="btn-danger"
                                                                        height="32px" onclick="BtnReject_Click" tabindex="11" text="Reject" validationgroup="group"
                                                                        width="100px" />
                                                                    <br />
                                                                    <br />

                                                                </itemtemplate>
                                                            </asp:templatefield>
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
                                                <td>
                                                    <asp:repeater id="rptDetails" runat="server" enabletheming="true" onitemdatabound="rptDetails_ItemDataBound">
                                                        <headertemplate>
                                                            <table style="width: 100%; border-collapse: collapse;" class="repeater-container" border="2px">
                                                                <thead>
                                                                    <tr style="background-color: #013161; color: white;">
                                                                        <th>S No</th>
                                                                        <th>View</th>
                                                                        <th>Name of Unit</th>
                                                                        <th>Activity Proposed</th>
                                                                        <th>Approval Name</th>
                                                                        <th>Date of Submission</th>
                                                                        <th>Last Date of Pre-Scrutiny</th>
                                                                        <th>CFE/CFO</th>
                                                                        <th>Attachments</th>
                                                                        <th>Query / Response</th>
                                                                        <%--<th>Status</th>
                                                                        <th>Submit</th>--%>
                                                                        <th>District Name</th>
                                                                        <th>Mandal Name</th>
                                                                        <th>Village Name</th>
                                                                        <th>Payment Details</th>
                                                                        <th id="thRefNO" runat="server" visible="false">Reference Number</th>
                                                                        <th id="thFeasibility" runat="server" visible="false">Feasibility Details</th>
                                                                        <th id="thRejection" runat="server" visible="false">Reason For Rejection</th>
                                                                        <th>Transferred From</th>
                                                                        <th>Process</th>
                                                                    </tr>
                                                                </thead>
                                                                <tbody>
                                                        </headertemplate>

                                                        <itemtemplate>
                                                            <tr style="background-color: #EBF2FE;">
                                                                <td>
                                                                    <%# Container.ItemIndex + 1 %>
                                                                    <asp:hiddenfield id="HiddenField1" runat="server" value='<%# Eval("intQuessionaireid") %>' />
                                                                    <asp:hiddenfield id="HiddenField2" runat="server" value='<%# Eval("intApprovalid") %>' />
                                                                    <asp:hiddenfield id="hdnEntrID" runat="server" value='<%# Eval("intCFEEnterpid") %>' />

                                                                </td>
                                                                <td>
                                                                    <asp:hyperlink
                                                                        id="hplTracker" runat="server"
                                                                        text='<%# Eval("UID_No") %>' target="_blank"
                                                                        navigateurl='<%# " ApplicationTrakerDetailed.aspx?ID=" + Eval("intQuessionaireid") %>'>
                                                                    </asp:hyperlink>
                                                                </td>


                                                                <td><%# Eval("nameofunit") %></td>
                                                                <td><%# Eval("Sec_EnterpriseName") %></td>
                                                                <td><%# Eval("ApprovalName") %></td>
                                                                <td><%# Eval("DateofSubmittion") %></td>
                                                                <td><%# Eval("LastDateofPreScrutiy") %></td>
                                                                <td>
                                                                    <asp:hyperlink
                                                                        id="hplCFEPrint" runat="server"
                                                                        text="View" target="_blank"
                                                                        navigateurl='<%# "CFEPrint.aspx?intApplid=" + Eval("intCFEEnterpid") %>'>
                                                                    </asp:hyperlink>
                                                                </td>
                                                                <td>
                                                                    <asp:hyperlink
                                                                        id="hplAttachments" runat="server"
                                                                        text="Attachments" target="_blank"
                                                                        navigateurl='<%# "frmViewAttachmentDetails.aspx?intApplicationId=" + Eval("intCFEEnterpid") %>'>
                                                                    </asp:hyperlink>
                                                                </td>
                                                                <td>
                                                                    <asp:hyperlink
                                                                        id="HyperLink1" runat="server"
                                                                        text="Query / Response" target="_blank"
                                                                        navigateurl='<%# "frmQurieResponseStatus.aspx?intApplicationId=" + Eval("intCFEEnterpid") %>'>
                                                                    </asp:hyperlink>
                                                                </td>
                                                                <td><%# Eval("District_Name") %></td>
                                                                <td><%# Eval("Manda_lName") %></td>
                                                                <td><%# Eval("Village_Name") %></td>
                                                                <td>
                                                                    <asp:hyperlink
                                                                        id="hplPayment" runat="server"
                                                                        text="Payment Details" target="_blank"
                                                                        navigateurl='<%# "RptPaymentDetails.aspx?intApplicationId=" + Eval("UID_No") %>'>
                                                                    </asp:hyperlink>
                                                                </td>
                                                                <td id="tdRefNO" runat="server" visible="false"><%# Eval("RefNo") %></td>

                                                                <td id="tdFeasibility" runat="server" visible="false">
                                                                    <asp:hyperlink
                                                                        id="hplFeasibility" runat="server"
                                                                        text="Feasibility Details" target="_blank">
                                                                    </asp:hyperlink>
                                                                </td>
                                                                <td id="tdRejection" runat="server" visible="false">
                                                                    <%# Eval("ReasonForRejection") %>                                                                    
                                                                </td>
                                                                <td><%# Eval("Dept_Name") %></td>
                                                                <td>
                                                                    <asp:label runat="server"
                                                                        text='<%# Eval("UPDATEDFLAG").ToString() == "Y" ? "Please process this application in Concerned Department portal" : "Please process this application in TS-iPASS portal" %>'></asp:label>
                                                                </td>
                                                            </tr>
                                                        </itemtemplate>

                                                        <footertemplate>
                                                    </tbody>
                                        </table>
                                        </FooterTemplate>
                                                    </asp:Repeater>
                                                </td>
                                            </tr>

                                            <tr>
                                                <td style="padding: 5px; margin: 5px" align="center">&nbsp;<tr>
                                                    <td align="center" style="padding: 5px; margin: 5px">&nbsp;
                                                    </td>
                                                </tr>
                                                    <caption>
                                                        &nbsp;</caption>
                                                </td>
                                            </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px" align="center">
                                                <div id="success" runat="server" class="alert alert-success" visible="false">
                                                    <a aria-label="close" class="close" data-dismiss="alert" href="AddQualification.aspx">×</a> <strong>Success!</strong><asp:label id="lblmsg" runat="server"></asp:label>
                                                </div>
                                                <div id="Failure" runat="server" class="alert alert-danger" visible="false">
                                                    <a aria-label="close" class="close" data-dismiss="alert" href="#">×</a> <strong>Warning!</strong>
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
                        <div style="z-index: 1000; margin-left: 250px; margin-top: 100px; opacity: 1; -moz-opacity: 1;">
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

</asp:content>
