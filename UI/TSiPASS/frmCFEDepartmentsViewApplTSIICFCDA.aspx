<%@ Page Title="" Language="C#" MasterPageFile="~/UI/TSiPASS/CCMaster.master" AutoEventWireup="true" CodeFile="frmCFEDepartmentsViewApplTSIICFCDA.aspx.cs" Inherits="UI_TSiPASS_frmCFEDepartmentsViewApplTSIICFCDA" %>
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

        function inputOnlyNumbers(evt) {
            var e = window.event || evt; // for trans-browser compatibility 
            var charCode = e.which || e.keyCode;

            if (((charCode > 45 && charCode < 58) || charCode == 8 || charCode == 9) && charCode != 46 && charCode != 47) {
                return true;
            }
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

    <asp:updatepanel id="upd1" runat="server" updatemode="Conditional">
        <contenttemplate>
            <div align="left">
                <ol class="breadcrumb">
                    You are here &nbsp;!&nbsp; &nbsp; &nbsp;
                    <li><i class="fa fa-dashboard"></i><a href="Home.aspx"></a></li>
                    <li class=""><i class="fa fa-fw fa-edit">CFE</i> </li>
                    <li class="active"><i class="fa fa-edit"></i><a href="#">View Applications</a>
                    </li>
                </ol>
            </div>
            <div align="left">
                <div class="row" align="left">
                    <div class="col-lg-11">
                        <div class="panel panel-primary">
                            <div class="panel-heading" align="center">
                                <h3 class="panel-title">View Applications</h3>
                            </div>
                            <asp:updatepanel id="UpdatePanel1" updatemode="Conditional" runat="server">
                                <contenttemplate>
                                    <div class="panel-body">
                                        <table align="center" cellpadding="10" cellspacing="5" style="width: 90%">
                                            <tr>
                                                <td align="left" style="padding: 5px; margin: 5px" valign="top">
                                                    <asp:gridview id="grdDetails" runat="server" autogeneratecolumns="False"
                                                        cellpadding="5" forecolor="#333333" height="62px" onrowdatabound="grdDetails_RowDataBound"
                                                        showfooter="True" width="100%" onrowcommand="grdDetails_RowCommand">
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
                                                            <asp:boundfield datafield="NameofthePromoter" headertext="Name of Industry" visible="false"></asp:boundfield>
                                                            <asp:boundfield datafield="Sec_EnterpriseName" headertext="Activity Proposed" />
                                                            <asp:boundfield datafield="ApprovalName" headertext="Approval name" />
                                                            <asp:boundfield datafield="DateofSubmittion" headertext="Date of Submittion"></asp:boundfield>
                                                            <asp:boundfield datafield="LastDateofPreScrutiy" headertext="Last Date of Pre-Scrutiny" />
                                                            <asp:hyperlinkfield headertext="CFE/CFO" text="View" />
                                                            <asp:hyperlinkfield headertext="Attachments" text="Attachments" />
                                                            <asp:hyperlinkfield headertext="Query / Response" text="Query / Response" />
                                                            <asp:templatefield headertext="Status">
                                                                <itemtemplate>
                                                                    <asp:label id="Label377" runat="server" cssclass="LBLBLACK" width="180px">Status</asp:label>
                                                                    <br />
                                                                    <asp:dropdownlist id="ddlStatus" runat="server" class="form-control txtbox" height="33px"
                                                                        width="180px" autopostback="True" onselectedindexchanged="ddlStatus_SelectedIndexChanged">
                                                                        <asp:listitem>--Select--</asp:listitem>
                                                                        <asp:listitem value="12">Completed</asp:listitem>
                                                                        <asp:listitem value="11">Completed with Payment Request</asp:listitem>
                                                                        <asp:listitem value="5">Query Raised</asp:listitem>
                                                                        <asp:listitem value="16">Rejected</asp:listitem>

                                                                    </asp:dropdownlist>
                                                                    <br />
                                                                    <asp:label id="Label378" runat="server" cssclass="LBLBLACK" width="180px" visible="False" text="Query Description"></asp:label>
                                                                    <br />
                                                                    <asp:textbox id="txtPromotor" runat="server" class="form-control txtbox"
                                                                        height="40px" tabindex="1" textmode="MultiLine"
                                                                        validationgroup="group" visible="False" width="180px">
                                                                    </asp:textbox>
                                                                    <asp:requiredfieldvalidator id="RequiredFieldValidator8" runat="server" controltovalidate="txtPromotor"
                                                                        errormessage="Please Enter Description" tabindex="1" validationgroup="group">
                                                                        *</asp:requiredfieldvalidator>
                                                                    <asp:label id="Label379" runat="server" cssclass="LBLBLACK" visible="False" width="180px">Amount</asp:label>
                                                                    <br />
                                                                    <asp:textbox id="txtAmount" runat="server" class="form-control txtbox" height="27px"
                                                                        maxlength="40" tabindex="1" validationgroup="group" visible="False" width="180px"
                                                                        onkeypress="return inputOnlyNumbers(event)">
                                                                    </asp:textbox>
                                                                    <br />
                                                                    <asp:hiddenfield id="hdfApplID" runat="server" />

                                                                    <asp:label id="lblIntcfeenterpid" text='<%# Eval("intCFEEnterpid") %>' visible="false" runat="server"></asp:label>
                                                                    <asp:label id="lblQueryRej" text="Select the documents for Query/Rejection" visible="false" runat="server"></asp:label>
                                                                    <asp:checkboxlist id="chkQueryRej" visible="false" runat="server" autopostback="true">
                                                                        <asp:listitem value="1" selected="True">Registration deed</asp:listitem>
                                                                        <asp:listitem value="2">Process Flow Chart</asp:listitem>
                                                                        <asp:listitem value="3">PAN / AADHAAR</asp:listitem>
                                                                        <asp:listitem value="4">Self-Certification Form</asp:listitem>
                                                                        <asp:listitem value="5">Partnership Deed (or) Articles of Association (AOA)</asp:listitem>
                                                                        <asp:listitem value="6">Mutation order</asp:listitem>
                                                                        <asp:listitem value="7">Common Affidavit</asp:listitem>
                                                                        <asp:listitem value="9">Structural Engineering Certificate </asp:listitem>
                                                                        <asp:listitem value="10">Combined building plan including all floor plans </asp:listitem>
                                                                    </asp:checkboxlist>

                                                                </itemtemplate>



                                                            </asp:templatefield>
                                                            <asp:templatefield controlstyle-width="300px" headertext="Upload DC Letter">
                                                                <itemtemplate>
                                                                    <asp:updatepanel runat="server" updatemode="Conditional" id="updFU">
                                                                        <contenttemplate>
                                                                            <b>
                                                                                <asp:label id="lbluploadDCLetter" text="Upload DC Letter" visible="false" runat="server"></asp:label>
                                                                            </b>
                                                                            <br />
                                                                            <asp:fileupload id="fuDCLUpload" visible="false" autopostback="true" runat="server" />
                                                                            <asp:button id="btnUploadDC" visible="false" commandname="Click" runat="server" causesvalidation="False" cssclass="btn-success" height="32px" tabindex="10" text="Upload DC Letter" validationgroup="group" width="150px" onclick="btnUploadDC_Click" />
                                                                            <br />
                                                                            <asp:label id="lblAttachedFileName1" runat="server" font-bold="true" forecolor="Green" visible="false" />
                                                                            <br />
                                                                            <asp:checkboxlist id="CheckBoxList1" visible="false" runat="server" autopostback="true" onselectedindexchanged="CheckBoxList1_SelectedIndexChanged">
                                                                                <asp:listitem value="12" selected="True">Mortgage</asp:listitem>
                                                                                <asp:listitem value="11">NALA</asp:listitem>
                                                                                <asp:listitem value="13">Gift deed</asp:listitem>
                                                                                <asp:listitem value="14">BT Formation/CC Road</asp:listitem>
                                                                                <asp:listitem value="15">Photographs of Demolished Structures</asp:listitem>
                                                                                <asp:listitem value="17">Additional Mortgage</asp:listitem>
                                                                                <asp:listitem value="18">Others</asp:listitem>
                                                                            </asp:checkboxlist>
                                                                            <br />
                                                                            <asp:textbox id="txtOthersDocument" class="form-control txtbox" visible="false" runat="server"></asp:textbox>
                                                                        </contenttemplate>
                                                                        <triggers>
                                                                            <asp:postbacktrigger controlid="btnUploadDC" />
                                                                            <%--    <asp:AsyncPostBackTrigger ControlID="btnUploadDC" />--%>
                                                                        </triggers>
                                                                    </asp:updatepanel>
                                                                </itemtemplate>
                                                                <controlstyle width="300px" />
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
                                                            <asp:boundfield datafield="UPDATEDFLAG" headertext="Process" />
                                                            <asp:templatefield headertext="Appeal Action" visible="false">
                                                                <itemtemplate>
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
                                                                    <asp:textbox runat="server" class="form-control txtbox" height="50px" width="180px"
                                                                        autocomplete="false" id="TxtReject" visible="false" placeholder="Remarks" textmode="MultiLine" />
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

