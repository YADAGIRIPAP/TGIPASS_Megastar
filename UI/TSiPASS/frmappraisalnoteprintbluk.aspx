<%@ page title="" language="C#" masterpagefile="~/UI/TSiPASS/CCMaster.master" autoeventwireup="true" codefile="frmappraisalnoteprintbluk.aspx.cs" inherits="UI_TSiPASS_frmappraisalnoteprintbluk" %>

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

        .CS {
            background-color: #abcdef;
            color: Yellow;
            border: 1px solid #1d9a5b;
            font: Verdana 10px;
            padding: 1px 4px;
            font-family: Palatino Linotype, Arial, Helvetica, sans-serif;
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

        .style7 {
            color: #FF3300;
        }

        .style8 {
            color: #FF0000;
            font-weight: bold;
        }

        .GRD {
            width: 800px;
            height: auto;
            border-color: #013161;
            border-style: solid;
            border-width: 1px;
            text-transform: capitalize;
            padding: 5px;
        }

        .GRDHEADER {
            border: 1px solid #1d9a5b;
            color: #1d9a5b;
            vertical-align: middle;
            text-align: center;
            height: 25px;
            width: 50px;
            padding: 10px;
            font-size: 12px;
            font-weight: bold;
            text-transform: capitalize;
            font-family: Verdana;
            background-image: url('../../Resource/Styles/images/bg_blue_grd.gif');
        }

        .GRDITEM {
            /*background-color: WHITE;*/
            color: black;
            font-size: 12px;
            font-weight: normal;
            font-family: Verdana;
            padding: 10px; /*text-decoration:none;*/ /*border-color:#013161;*/ /*border-style:solid;*/
            text-transform: uppercase; /*border-width:1px;*/ /*height:23px;*/ /*text-indent:5px;*/ /*BACKGROUND-IMAGE: url(../images/grid_bg_.gif);*/
        }

        .LBLBLACK {
        }
    </style>
    <script type="text/javascript" language="javascript">

        function OpenPopup() {

            window.open("Lookups/LookupBDC.aspx", "List", "scrollbars=yes,resizable=yes,width=1000,height=650;display = block;position=absolute");

            return false;
        }

        function selectGridChkAll(chkAll) {//debugger
            var grdDetails = chkAll.parentElement.parentElement.parentElement.parentElement
            if (grdDetails != null) {
                if (chkAll.checked == true) {
                    for (i = 0; i < grdDetails.rows.length; i++) {
                        if (grdDetails.rows[i].cells[1].children[0] != null) {
                            grdDetails.rows[i].cells[1].children[0].checked = true;
                        }
                    }
                }
                else {
                    for (i = 0; i < grdDetails.rows.length; i++) {
                        if (grdDetails.rows[i].cells[1].children[0] != null) {
                            grdDetails.rows[i].cells[1].children[0].checked = false;
                        }
                    }
                }
            }
        }

        function selectGridChkAlltest() {//debugger
            //alert('test');
            var grdDetails = chkAll.parentElement.parentElement.parentElement.parentElement
            if (grdDetails != null) {
                for (i = 0; i < grdDetails.rows.length; i++) {
                    if (grdDetails.rows[i].cells[1].children[0] != null) {
                        grdDetails.rows[i].cells[1].children[0].checked = true;
                    }
                }
            }
        }

    </script>
    <link href="assets/css/basic.css" rel="stylesheet" />
    <asp:updatepanel id="upd1" runat="server">
        <contenttemplate>
            <div align="left">
                <div class="row" align="left">
                    <div class="col-lg-12">
                        <%--<div class="panel panel-primary">
                            <div class="panel-heading" align="center">
                                <h3 class="panel-title">Departments</h3>
                            </div>--%>
                        <table style="width: 100%" id="divPrint" runat="server">
                            <tr>
                                <td>
                                    <div class="col-md-12">
                                        <h1 class="page-head-line" align="left" style="font-size: large" runat="server" id="h1heading"></h1>
                                    </div>
                                    <div class="panel-body">
                                        <table align="left" cellpadding="10" cellspacing="5" style="width: 100%">
                                            <tr runat="server" id="trBetweenDates" visible="true">
                                                <td style="padding: 5px; margin: 5px"></td>
                                                <td>
                                                    <asp:textbox id="txtFromDate" runat="server" class="form-control txtbox" height="28px" visible="false"
                                                        maxlength="40" onkeypress="NumberOnly()" tabindex="1" validationgroup="group"
                                                        width="125px">
                                                    </asp:textbox>
                                                    <%--<cc1:CalendarExtender ID="CalendarExtender2" runat="server" Format="dd-MM-yyyy" TargetControlID="txtFromDate">
                                                </cc1:CalendarExtender>--%>
                                                </td>
                                                <td style="padding: 5px; margin: 5px">Proposed
                                                    <br />
                                                    SVC Date:
                                                </td>
                                                <td>
                                                    <asp:dropdownlist id="ddlapplicationto" runat="server" width="150px"
                                                        class="form-control txtbox" height="33px">
                                                        <asp:listitem value="0" text="--Select--"></asp:listitem>
                                                    </asp:dropdownlist>
                                                    <asp:textbox id="txtTodate" runat="server" class="form-control txtbox" height="28px"
                                                        maxlength="40" onkeypress="NumberOnly()" tabindex="1" validationgroup="group" visible="false"
                                                        width="125px">
                                                    </asp:textbox>
                                                    <%-- <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd-MM-yyyy" TargetControlID="txtTodate">
                                                </cc1:CalendarExtender>--%>
                                                </td>
                                                <td style="padding: 5px; margin: 5px">Category:
                                                </td>
                                                <td>
                                                    <asp:dropdownlist id="ddlcategory" runat="server" class="form-control txtbox" height="33px"
                                                        tabindex="1" width="180px">
                                                        <asp:listitem value="0">--Select--</asp:listitem>
                                                        <asp:listitem value="1">General</asp:listitem>
                                                        <asp:listitem value="3">SC</asp:listitem>
                                                        <asp:listitem value="4">ST</asp:listitem>
                                                        <asp:listitem value="9">PHC</asp:listitem>
                                                    </asp:dropdownlist>

                                                </td>
                                                <td style="padding: 5px; margin: 5px">Type of Incentive:
                                                </td>
                                                <td>
                                                    <asp:dropdownlist id="ddlincentivetype" runat="server" class="form-control txtbox" height="33px"
                                                        tabindex="1" width="180px">
                                                        <asp:listitem value="1">Pavalla vaddi</asp:listitem>
                                                        <asp:listitem value="3">Power Cost Reimbursement</asp:listitem>
                                                        <asp:listitem value="5">Sales TAX(VAT/GST/SGST) Reimbursement</asp:listitem>
                                                        <asp:listitem value="6">Investment Subsidy</asp:listitem>
                                                        <asp:listitem value="7">Industrial Infrastructure Development Fund(IIDF)</asp:listitem>
                                                        <asp:listitem value="11">Reimbursement of all expenses incurred for Quality Certification/Patent Registration</asp:listitem>
                                                        <asp:listitem value="14">Reimbursement of stamp Duty/Transfer Duty</asp:listitem>
                                                        <asp:listitem value="15">Reimbursement of Mortgage</asp:listitem>
                                                        <asp:listitem value="16">Reimbursement of Land Conversion</asp:listitem>
                                                        <asp:listitem value="17">Reimbursement of Land Cost</asp:listitem>
                                                    </asp:dropdownlist>
                                                </td>
                                                <td>
                                                    <asp:button id="btngetdetails" cssclass="btn btn-primary" runat="server" text="GetDetails"
                                                        onclick="btngetdetails_Click" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="padding: 5px; margin: 5px; width: 100%" valign="top" colspan="12">
                                                    <div style="width: 100%">
                                                        <asp:gridview id="grdDetails" runat="server" autogeneratecolumns="false" cellpadding="4"
                                                            cssclass="GRD" forecolor="#333333" height="62px" pagesize="15" showfooter="false"
                                                            width="100%" cellspacing="4">
                                                            <footerstyle backcolor="#be8c2f" font-bold="True" forecolor="White" />
                                                            <rowstyle backcolor="#EBF2FE" cssclass="GRDITEM" horizontalalign="Left" verticalalign="Middle" />
                                                            <columns>
                                                                <asp:templatefield headerstyle-horizontalalign="Center" headertext="S.No.">
                                                                    <itemtemplate>
                                                                        <%# Container.DataItemIndex + 1%>
                                                                    </itemtemplate>
                                                                    <headerstyle horizontalalign="Center" />
                                                                    <itemstyle width="50px" />
                                                                </asp:templatefield>
                                                                <asp:templatefield headertext="&lt;input id='chkAll' type='checkbox' ONCLICK='selectGridChkAll(this);'text='Select All'&gt;">
                                                                    <itemtemplate>
                                                                        <asp:checkbox id="chkSelect" runat="server" />
                                                                    </itemtemplate>
                                                                </asp:templatefield>
                                                                <%-- <asp:TemplateField>
                                                                    <HeaderTemplate>
                                                                        Select
                                                                        <asp:CheckBox ID="chkAll" OnCheckedChanged="chkAll_CheckedChanged" AutoPostBack="true"
                                                                            runat="server" />
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:CheckBox ID="chkRow" runat="server" Checked="false" />
                                                                    </ItemTemplate>
                                                                    <ItemStyle Width="50px" />
                                                                </asp:TemplateField>--%>
                                                                <asp:boundfield datafield="lblApplicationno" itemstyle-horizontalalign="left" headertext="Online Application Number">
                                                                    <itemstyle horizontalalign="left"></itemstyle>
                                                                </asp:boundfield>
                                                                <asp:boundfield datafield="txtunitnames" itemstyle-horizontalalign="left" headertext="Name of Unit & Address">
                                                                    <itemstyle horizontalalign="left"></itemstyle>
                                                                </asp:boundfield>
                                                                <asp:boundfield datafield="IncentiveName" itemstyle-horizontalalign="left" headertext="Incentive Type">
                                                                    <itemstyle horizontalalign="left"></itemstyle>
                                                                </asp:boundfield>
                                                                <asp:boundfield datafield="Caste_Name" itemstyle-horizontalalign="left" headertext="Category">
                                                                    <itemstyle horizontalalign="left"></itemstyle>
                                                                </asp:boundfield>
                                                                <%--<asp:BoundField DataField="DateofReceipt" ItemStyle-HorizontalAlign="left" HeaderText="Date of Recieved from JD">
                                                                    <ItemStyle HorizontalAlign="left"></ItemStyle>
                                                                </asp:BoundField>--%>

                                                                <asp:boundfield datafield="Remarks" itemstyle-horizontalalign="left" headertext="ADDL_RECON_AMOUNT">
                                                                    <itemstyle horizontalalign="left"></itemstyle>
                                                                </asp:boundfield>

                                                                <asp:boundfield datafield="EnterperIncentiveID" itemstyle-horizontalalign="left" headertext="EnterperIncentiveID">
                                                                    <itemstyle horizontalalign="left"></itemstyle>
                                                                </asp:boundfield>

                                                                <asp:boundfield datafield="IncentiveId" itemstyle-horizontalalign="left" headertext="IncentiveId">
                                                                    <itemstyle horizontalalign="left"></itemstyle>
                                                                </asp:boundfield>
                                                            </columns>
                                                            <pagerstyle backcolor="#013161" forecolor="White" horizontalalign="Center" />
                                                            <selectedrowstyle backcolor="#D1DDF1" font-bold="True" forecolor="#333333" />
                                                            <headerstyle backcolor="#1d9a5b" cssclass="GRDHEADER" font-bold="True" forecolor="White" />
                                                            <editrowstyle backcolor="#B9D684" />
                                                            <alternatingrowstyle backcolor="White" />
                                                        </asp:gridview>
                                                    </div>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="12" style="padding: 5px; margin: 5px" align="center" class="style7"
                                                    id="tblselection" runat="server">
                                                    <asp:button id="Button1" cssclass="btn btn-primary" runat="server" text="Submit" visible="false"
                                                        onclick="Button1_Click" />
                                                    &nbsp;&nbsp;
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="12">
                                                    <asp:hiddenfield id="hdfID" runat="server" />
                                                    <asp:validationsummary id="ValidationSummary1" runat="server" showmessagebox="True"
                                                        showsummary="False" validationgroup="group" />
                                                    <asp:validationsummary id="ValidationSummary2" runat="server" showmessagebox="True"
                                                        showsummary="False" validationgroup="child" />
                                                    <asp:hiddenfield id="hdfFlagID" runat="server" />
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td align="center" style="padding: 5px; margin: 5px; text-align: center;">&nbsp;&nbsp;&nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td style="padding: 5px; margin: 5px" align="center" class="style7"></td>
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
                    </div>
                </div>
            </div>
            <asp:updateprogress id="UpdateProgress" runat="server" associatedupdatepanelid="upd1">
                <progresstemplate>
                    <div class="update">
                    </div>
                </progresstemplate>
            </asp:updateprogress>
        </contenttemplate>
    </asp:updatepanel>
</asp:content>

