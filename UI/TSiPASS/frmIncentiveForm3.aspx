<%@ page title="" language="C#" masterpagefile="~/UI/TSiPASS/CCMaster.master" autoeventwireup="true" codefile="frmIncentiveForm3.aspx.cs" inherits="UI_TSiPASS_frmIncentiveForm3" %>

<asp:content id="Content1" contentplaceholderid="ContentPlaceHolder1" runat="Server">
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
            background-image: url("../../Images/ajax-loaderblack.gif");
            /*background-image: url("Images/spinner_60.gif");*/
            background-position: center center;
            background-repeat: no-repeat;
            /*background-color: #e4e4e6;*/
            background-color: #535252;
            z-index: 500 !important;
            opacity: 0.6;
            overflow: hidden;
        }

        .style6 {
            width: 300px;
        }

        .style7 {
            color: #FF3300;
        }

        .style8 {
        }
    </style>

    <script type="text/javascript" language="javascript">

        function OpenPopup() {

            window.open("Lookups/LookupBDC.aspx", "List", "scrollbars=yes,resizable=yes,width=1000,height=650;display = block;position=absolute");

            return false;
        }
    </script>


    <script type="text/javascript">
        function inputOnlyNumbers(evt) {
            var e = window.event || evt; // for trans-browser compatibility  
            var charCode = e.which || e.keyCode;
            if ((charCode > 45 && charCode < 58) || charCode == 8 || charCode == 9) {
                return true;
            }
            return false;
        }
        function pageLoad() {
            var date = new Date();
            var currentMonth = date.getMonth();
            var currentDate = date.getDate();
            var currentYear = date.getFullYear();

            $("input[id$='txtNewPowerDate']").datepicker(
                {
                    dateFormat: "dd-mm-yy",
                    maxDate: 0
                    //  maxDate: new Date(currentYear, currentMonth, currentDate)
                });
        }
    </script>


    <div align="left">
        <div class="row" align="left">
            <div class="col-lg-11">
                <div class="panel panel-primary">


                    <div class="panel-heading" style="background-color: #339966">
                        <table style="width: 100%">
                            <tr>
                                <td>
                                    <asp:label id="lblheadTPRIDE" runat="server" visible="false" text="APPLICATION CUM VERIFICATION FOR CLAIMING INVESTMENT SUBSIDY UNDER T-PRIDE—TELANGANA STATE PROGRAM FOR 
                                        RAPID INCUBATION OF DALIT ENTREPRENEURS INCENTIVE SCHEME.(G.O.Ms.No.29 Industries and Commerce (IP & INF) Department. dated.29/11/2014)
                                        PART - A CLAIM"></asp:label>
                                    <asp:label id="lblheadTIDEA" runat="server" visible="false" text="APPLICATION CUM VERIFICATION FOR CLAIMING REIMBURSEMENT OF STAMP DUTY
                                        / TRANSFER DUTY / MORTGAGE DUTY / LAND CONVESERSION CHARGES /
                                        REIMBURSEMENT OF LAND COST PURCHASED IN IE/IDA/IP’s UNDER T-IDEA
                                        (TELANGANA STATE INDUSTRIAL DEVELOPMENT AND ENTREPRENEUR
                                        ADVANCEMENT) INCENTIVE SCHEME 2014"></asp:label>
                                    <asp:label id="lblMSMEPolicy" runat="server" visible="false" text="Reimbursement of 
                                        Power Tariff Under MSME Policy"
                                        forecolor="White" font-bold="true" font-size="20px"></asp:label>
                                    <asp:hiddenfield id="hdnMSMEApplied" runat="server" />
                                </td>
                            </tr>
                        </table>
                    </div>


                    <%--  <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>--%>
                    <div class="panel-body">
                        <table align="center" cellpadding="10" cellspacing="5" style="width: 100%">
                            <tr id="trMSME1hps" runat="server" visible="false">
                                <td style="padding: 5px; margin: 5px" valign="top">
                                    <table style="width: 100%; font-weight: bold;">
                                        <tr id="TRExistingHP" runat="server" visible="false">
                                            <td style="padding: 5px; margin: 5px; text-align: left;">1</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:label id="Label17" runat="server">Exisitng Power Connection in HP<font color="red">*</font></asp:label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:textbox id="txtExistingHP" runat="server" class="form-control txtbox" height="33px" width="180px" onkeypress="return inputOnlyNumbers(event)" />
                                            </td>
                                            <td style="padding: 5px; margin: 5px"></td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;"></td>
                                        </tr>
                                        <tr  id="TRNewHP" runat="server" visible="false">
                                            <td style="padding: 5px; margin: 5px; text-align: left;">2</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:label id="Label18" runat="server">New Power Connection in HP<font color="red">*</font></asp:label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:textbox id="txtNewHP" runat="server" class="form-control txtbox" height="33px" width="180px" onkeypress="return inputOnlyNumbers(event)" />
                                            </td>
                                            <td style="padding: 5px; margin: 5px"></td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;"></td>
                                        </tr>
                                        <tr  id="TRNewPowerDate" runat="server" visible="false">
                                            <td style="padding: 5px; margin: 5px; text-align: left;">3</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:label id="Label21" runat="server">Date of New Power Connection Released(DD-MM-YYYY)<font color="red">*</font></asp:label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px"></td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:textbox id="txtNewPowerDate" runat="server" class="form-control txtbox" height="33px" width="180px" />
                                            </td>
                                            <td style="padding: 5px; margin: 5px"></td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;"></td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td style="padding: 5px; margin: 5px; text-align: left; font-weight: bold" colspan="8">1. Energy consumption details from DCP</td>
                            </tr>
                            <tr>
                                <td style="padding: 5px; margin: 5px; text-align: left; font-weight: bold" colspan="8">
                                    <asp:label id="Label2" runat="server" font-bold="True" font-names="Verdana" font-size="13px"
                                        forecolor="Green" style="position: static"></asp:label>
                                </td>
                            </tr>
                            <tr id="trEnergy1" runat="server">
                                <td style="padding: 5px; margin: 5px" valign="top">
                                    <table style="width: 100%; font-weight: bold;">
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">1.1</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:label id="Label11" runat="server">Financial Year<font color="red">*</font></asp:label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:dropdownlist id="ddlFinYearEnergy" runat="server" class="form-control txtbox" height="33px" width="180px">
                                                    <asp:listitem>--Select--</asp:listitem>
                                                </asp:dropdownlist>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">1.2</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:label id="Label16" runat="server">1st/2nd half Year<font color="red">*</font></asp:label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:dropdownlist id="ddlFin1stOr2ndHalfyear" runat="server" class="form-control txtbox" height="33px" width="180px" autopostback="True" onselectedindexchanged="ddlFin1stOr2ndHalfyear_SelectedIndexChanged">
                                                    <asp:listitem value="--Select--" text="--Select--"></asp:listitem>
                                                    <asp:listitem value="1" text="1st"></asp:listitem>
                                                    <asp:listitem value="2" text="2nd"></asp:listitem>
                                                </asp:dropdownlist>
                                            </td>
                                        </tr>
                                        <tr id="trFin1stHalfYear" runat="server" visible="false">
                                            <td style="padding: 5px; margin: 5px; text-align: left;">1.3</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:label id="Label12" runat="server">1st half Year Units Consumed<font color="red">*</font></asp:label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:textbox id="txt1stHalfUnitConsumed" runat="server" class="form-control txtbox" onkeypress="return inputOnlyNumbers(event)"
                                                    height="28px" maxlength="40" tabindex="36" width="180px">
                                                </asp:textbox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">1.4</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:label id="Label14" runat="server">1st half Year Amount Paid
                                                    <br />
                                                    (in Rs)<font color="red">*</font></asp:label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:textbox id="txt1stHalfAmountPaid" runat="server" class="form-control txtbox" onkeypress="return inputOnlyNumbers(event)"
                                                    height="28px" maxlength="40" tabindex="36" width="180px">
                                                </asp:textbox>
                                            </td>
                                        </tr>
                                        <tr id="trFin2ndHalfYear" runat="server" visible="false">
                                            <td style="padding: 5px; margin: 5px; text-align: left;">1.5</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:label id="Label13" runat="server">2nd half Year Units Consumed<font color="red">*</font></asp:label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:textbox id="txt2ndHalfUnitConsumed" runat="server" class="form-control txtbox" onkeypress="return inputOnlyNumbers(event)"
                                                    height="28px" maxlength="40" tabindex="36" width="180px">
                                                </asp:textbox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">1.6</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:label id="Label15" runat="server">2nd half Year Amount Paid (in Rs)<font color="red">*</font></asp:label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:textbox id="txt2ndHalfAmountPaid" runat="server" class="form-control txtbox" onkeypress="return inputOnlyNumbers(event)"
                                                    height="28px" maxlength="40" tabindex="36" width="180px">
                                                </asp:textbox>
                                            </td>
                                        </tr>
                                        <tr id="tr1" runat="server">
                                            <td align="center" colspan="4"></td>
                                            <td align="center" colspan="4" style="height: 50px">
                                                <asp:button id="btnEnergyAdd" runat="server" cssclass="btn btn-xs btn-warning" height="28px" tabindex="39" text="Add New" width="72px" onclick="btnEnergyAdd_Click" />
                                                &nbsp;&nbsp;&nbsp;
                                                <asp:button id="btnEnergyClear" runat="server" causesvalidation="False" cssclass="btn btn-xs btn-danger" height="28px" tabindex="40" text="Clear" tooltip="To Clear the Screen" width="73px" />
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr id="trEnergy2" runat="server">
                                <td style="padding: 5px; margin: 5px" valign="top" align="center" colspan="3">
                                    <asp:gridview id="gvEnergy" runat="server" autogeneratecolumns="False"
                                        bordercolor="#003399" borderstyle="Solid" borderwidth="1px" cellpadding="4"
                                        cssclass="GRD" forecolor="#333333" gridlines="Both" visible="false"
                                        width="95%" datakeynames="intLineofActivityMid" onrowdatabound="gvEnergy_RowDataBound" onrowdeleting="gvEnergy_RowDeleting">
                                        <rowstyle backcolor="#ffffff" />
                                        <columns>
                                            <asp:templatefield headertext="Sl.No">
                                                <itemtemplate>
                                                    <asp:label id="Slno" runat="server" text="<%# Container.DataItemIndex + 1 %>"></asp:label>
                                                </itemtemplate>
                                            </asp:templatefield>
                                            <asp:boundfield datafield="FinancialYearId" headertext="Financial YearId" visible="false" />
                                            <asp:boundfield datafield="FinancialYear" headertext="Financial Year" />
                                            <asp:boundfield datafield="Fin1stOr2ndHalfYear" headertext="1st or 2nd Half Financial Year" />
                                            <asp:boundfield datafield="1stUnitsConsumed" headertext="1st half Year Units Consumed" />
                                            <asp:boundfield datafield="1stAmountPaid" headertext="1st half Year Amount Paid (in Rs)" />
                                            <asp:boundfield datafield="2ndUnitsConsumed" headertext="2nd half Year Units Consumed" />
                                            <asp:boundfield datafield="2ndAmountPaid" headertext="2nd half Year Amount Paid (in Rs)" />
                                            <asp:boundfield datafield="Created_by" headertext="Created By" visible="False" />
                                            <asp:boundfield datafield="IncentiveId" headertext="Incentive Id" visible="False" />
                                            <asp:commandfield headertext="Delete" showdeletebutton="True" />
                                            <asp:commandfield headertext="Edit" showselectbutton="True" visible="False" />
                                        </columns>
                                        <headerstyle backcolor="#013161" font-bold="True" forecolor="White" />
                                        <pagerstyle backcolor="#013161" forecolor="White" horizontalalign="Center" />
                                        <alternatingrowstyle backcolor="#D5E6F9" forecolor="#284775" />
                                        <rowstyle backcolor="#F7F6F3" forecolor="#333333" font-names="Arial" font-size="12px" horizontalalign="Center" />
                                        <selectedrowstyle backcolor="#E2DED6" font-bold="True" forecolor="#333333" />
                                        <footerstyle horizontalalign="Center" backcolor="#5D7B9D" font-bold="True" forecolor="White" font-names="Arial" font-size="9px" />
                                    </asp:gridview>
                                </td>
                            </tr>

                            <tr id="trenergyview" runat="server" visible="false">
                                <td style="padding: 5px; margin: 5px" valign="top" align="center" colspan="3">
                                    <asp:gridview id="gvenergyview" runat="server" autogeneratecolumns="False"
                                        bordercolor="#003399" borderstyle="Solid" borderwidth="1px" cellpadding="4"
                                        cssclass="GRD" forecolor="#333333" gridlines="Both" width="95%">
                                        <rowstyle backcolor="#ffffff" />
                                        <columns>
                                            <asp:templatefield headertext="Sl.No">
                                                <itemtemplate>
                                                    <asp:label id="Slno" runat="server" text="<%# Container.DataItemIndex + 1 %>"></asp:label>
                                                </itemtemplate>
                                            </asp:templatefield>
                                            <asp:boundfield datafield="FinancialYearNew" headertext="Financial Year" />
                                            <asp:boundfield datafield="Fin1stOr2ndHalfYear" headertext="1st or 2nd Half Financial Year" />
                                            <asp:boundfield datafield="F_UnitsConsumed" headertext="1st half Year Units Consumed" />
                                            <asp:boundfield datafield="F_Amount" headertext="1st half Year Amount Paid (in Rs)" />
                                            <asp:boundfield datafield="S_UnitsConsumed" headertext="2nd half Year Units Consumed" />
                                            <asp:boundfield datafield="S_Amount" headertext="2nd half Year Amount Paid (in Rs)" />
                                        </columns>
                                        <headerstyle backcolor="#013161" font-bold="True" forecolor="White" />
                                        <pagerstyle backcolor="#013161" forecolor="White" horizontalalign="Center" />
                                        <alternatingrowstyle backcolor="#D5E6F9" forecolor="#284775" />
                                        <rowstyle backcolor="#F7F6F3" forecolor="#333333" font-names="Arial" font-size="12px" horizontalalign="Center" />
                                        <selectedrowstyle backcolor="#E2DED6" font-bold="True" forecolor="#333333" />
                                        <footerstyle horizontalalign="Center" backcolor="#5D7B9D" font-bold="True" forecolor="White" font-names="Arial" font-size="9px" />
                                    </asp:gridview>
                                </td>
                            </tr>

                            <tr>
                                <td style="padding: 5px; margin: 5px; text-align: left; font-weight: bold" colspan="8"></td>

                            </tr>
                            <tr>
                                <td colspan="8">
                                    <table style="width: 55%">
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left; font-weight: bold">2. Amount claimed :                                                      
                                            </td>
                                            <td>
                                                <asp:textbox id="txtClaimedAmount" runat="server" width="150px" class="form-control txtbox" onkeypress="return inputOnlyNumbers(event)"></asp:textbox>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr id="tr2" runat="server">
                                <td style="padding: 5px; margin: 5px" valign="top">
                                    <table id="tblExpansionDivers" runat="server" visible="false" style="width: 100%; font-weight: bold;">
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left; font-weight: bold" colspan="8">3.Power utilised during previous 3 years before this Expansion / Diversification Project.</td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left; font-weight: bold" colspan="8">
                                                <%--<asp:Label ID="Label1" runat="server"></asp:Label>--%>
                                                <asp:label id="Label1" runat="server" font-bold="True" font-names="Verdana" font-size="13px"
                                                    forecolor="Green" style="position: static"></asp:label>
                                            </td>

                                        </tr>

                                        <tr id="trpower1" runat="server">
                                            <td style="padding: 5px; margin: 5px" valign="top">
                                                <table style="width: 100%; font-weight: bold;">
                                                    <tr>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">3.1</td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:label id="Label3" runat="server">Financial year<font color="red">*</font></asp:label>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">:</td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:dropdownlist id="ddlFinYearPower" runat="server" class="form-control txtbox" height="33px" width="180px">
                                                                <asp:listitem>--Select--</asp:listitem>
                                                            </asp:dropdownlist>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">3.2</td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:label id="Label9" runat="server">Units Consumed<font color="red">*</font></asp:label>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">:</td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:textbox id="txtUnitsConsumed" runat="server" class="form-control txtbox" onkeypress="return inputOnlyNumbers(event)"
                                                                height="28px" maxlength="40" tabindex="36" width="180px">
                                                            </asp:textbox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="padding: 5px; margin: 5px">3.3</td>
                                                        <td>
                                                            <asp:label id="Label10" runat="server" cssclass="LBLBLACK" width="165px">Amount Paid (in Rs)<font color="red">*</font></asp:label>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">:</td>
                                                        <td style="padding: 5px; margin: 5px">
                                                            <asp:textbox id="txtAmountPaid" runat="server" class="form-control txtbox" onkeypress="return inputOnlyNumbers(event)"
                                                                height="28px" maxlength="40" tabindex="37" validationgroup="group" width="180px">
                                                            </asp:textbox>
                                                        </td>
                                                        <td style="height: 50px"></td>
                                                        <td align="center">
                                                            <asp:button id="btnPowerAdd" runat="server" cssclass="btn btn-xs btn-warning" height="28px" tabindex="39" text="Add New" width="72px" onclick="btnPowerAdd_Click" />
                                                        </td>
                                                        <td align="right">&nbsp;</td>
                                                        <td>
                                                            <asp:button id="btnPowerClear" runat="server" causesvalidation="False" cssclass="btn btn-xs btn-danger" height="28px" tabindex="40" text="Clear" tooltip="To Clear the Screen" width="73px" />
                                                        </td>
                                                        <td align="left">&nbsp;</td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr id="trpower2" runat="server">
                                <td style="padding: 5px; margin: 5px" valign="top" align="center" colspan="3">
                                    <asp:gridview id="gvpower" runat="server" autogeneratecolumns="False"
                                        bordercolor="#003399" borderstyle="Solid" borderwidth="1px" cellpadding="4"
                                        cssclass="GRD" forecolor="#333333" gridlines="Both" visible="false"
                                        width="65%" datakeynames="intLineofActivityMid" onrowdatabound="gvpower_RowDataBound" onrowdeleting="gvpower_RowDeleting">
                                        <rowstyle backcolor="#ffffff" />
                                        <columns>
                                            <asp:templatefield headertext="Sl.No">
                                                <itemtemplate>
                                                    <asp:label id="Slno" runat="server" text="<%# Container.DataItemIndex + 1 %>"></asp:label>
                                                </itemtemplate>
                                            </asp:templatefield>
                                            <asp:boundfield datafield="FinancialYearId" headertext="Financial YearId" visible="false" />
                                            <asp:boundfield datafield="FinancialYear" headertext="Financial Year" />
                                            <asp:boundfield datafield="UnitsConsumed" headertext="Units Consumed" />
                                            <asp:boundfield datafield="AmountPaid" headertext="Amount Paid (in Rs)" />
                                            <asp:boundfield datafield="Created_by" headertext="Created By" visible="False" />
                                            <asp:boundfield datafield="IncentiveId" headertext="Incentive Id" visible="False" />
                                            <asp:commandfield headertext="Delete" showdeletebutton="True" />
                                            <asp:commandfield headertext="Edit" showselectbutton="True" visible="False" />
                                        </columns>
                                        <headerstyle backcolor="#013161" font-bold="True" forecolor="White" />
                                        <pagerstyle backcolor="#013161" forecolor="White" horizontalalign="Center" />
                                        <alternatingrowstyle backcolor="#D5E6F9" forecolor="#284775" />
                                        <rowstyle backcolor="#F7F6F3" forecolor="#333333" font-names="Arial" font-size="12px" horizontalalign="Center" />
                                        <selectedrowstyle backcolor="#E2DED6" font-bold="True" forecolor="#333333" />
                                        <footerstyle horizontalalign="Center" backcolor="#5D7B9D" font-bold="True" forecolor="White" font-names="Arial" font-size="9px" />
                                    </asp:gridview>
                                </td>
                            </tr>

                            <tr id="trpowerview" runat="server" visible="false">
                                <td style="padding: 5px; margin: 5px" valign="top" align="center" colspan="3">
                                    <asp:gridview id="gvpowerview" runat="server" autogeneratecolumns="False"
                                        bordercolor="#003399" borderstyle="Solid" borderwidth="1px" cellpadding="4"
                                        cssclass="GRD" forecolor="#333333" gridlines="Both" width="65%">
                                        <rowstyle backcolor="#ffffff" />
                                        <columns>
                                            <asp:templatefield headertext="Sl.No">
                                                <itemtemplate>
                                                    <asp:label id="Slno" runat="server" text="<%# Container.DataItemIndex + 1 %>"></asp:label>
                                                </itemtemplate>
                                            </asp:templatefield>
                                            <asp:boundfield datafield="FinancialYearNew" headertext="Financial Year" />
                                            <asp:boundfield datafield="UnitsConsumed" headertext="Units Consumed" />
                                            <asp:boundfield datafield="Amount" headertext="Amount Paid (in Rs)" />
                                        </columns>
                                        <headerstyle backcolor="#013161" font-bold="True" forecolor="White" />
                                        <pagerstyle backcolor="#013161" forecolor="White" horizontalalign="Center" />
                                        <alternatingrowstyle backcolor="#D5E6F9" forecolor="#284775" />
                                        <rowstyle backcolor="#F7F6F3" forecolor="#333333" font-names="Arial" font-size="12px" horizontalalign="Center" />
                                        <selectedrowstyle backcolor="#E2DED6" font-bold="True" forecolor="#333333" />
                                        <footerstyle horizontalalign="Center" backcolor="#5D7B9D" font-bold="True" forecolor="White" font-names="Arial" font-size="9px" />
                                    </asp:gridview>
                                </td>
                            </tr>

                            <tr id="TRELECTRICITYDUTY" runat="server" visible="false">
                                <td style="padding: 5px; margin: 5px" valign="top">
                                    <table style="width: 100%; font-weight: bold;">

                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;"></td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:label id="Label19" runat="server">Electricity Duty Units Consumed<font color="red">*</font></asp:label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:textbox id="txtelectricitydutyunitsconsumed" runat="server" class="form-control txtbox" oncopy="return false" onpaste="return false" oncut="return false" onkeypress="return inputOnlyNumbers(event)" ontextchanged="txtelectricitydutyunitsconsumed_TextChanged" autopostback="true"
                                                    height="28px" maxlength="40" tabindex="36" width="180px">
                                                </asp:textbox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;"></td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" class="auto-style1">
                                                <asp:label id="Label20" runat="server">Electricity Duty Amount<br />
                                                    (in Rs)<font color="red">*</font></asp:label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:textbox id="txtelectricitydutyamount" runat="server" class="form-control txtbox" onkeypress="return inputOnlyNumbers(event)"
                                                    height="28px" maxlength="40" tabindex="36" width="180px" enabled="false">
                                                </asp:textbox>
                                            </td>
                                        </tr>

                                    </table>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <table style="width: 100%">
                        <tr>
                            <td style="padding: 5px; margin: 5px; text-align: left; font-weight: bold;" colspan="8">Enclosures</td>
                        </tr>
                        <tr>
                            <td colspan="10">
                                <table style="width: 100%">
                                    <tr id="trallreqCheckSlipdocs" runat="server" visible="false">
                                        <td style="padding: 3px; margin: 3px; text-align: left;">1. All required documents as per check slip during 1st claim</td>
                                        <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                            <asp:fileupload id="FileUpload1" runat="server" cssclass="CS"
                                                height="28px" />

                                            <asp:hyperlink id="lblFileName" runat="server" cssclass="LBLBLACK" width="165px" visible="false"
                                                target="_blank">
                                            </asp:hyperlink>
                                            <br />
                                            <asp:label id="Label444" runat="server" visible="False"></asp:label>
                                        </td>
                                        <td style="padding: 5px; margin: 5px; width: 100px;" valign="top">
                                            <asp:button id="BtnSave3" runat="server" cssclass="btn btn-xs btn-warning"
                                                height="28px" tabindex="10" text="Upload"
                                                width="72px" onclick="BtnSave3_Click" />
                                        </td>
                                    </tr>


                                    <tr>
                                        <td colspan="3" style="padding: 3px; margin: 3px; text-align: left; font-weight: bold">During all subsequent claims</td>
                                    </tr>
                                    <tr>
                                        <td style="padding: 3px; margin: 3px; text-align: left;">1. Attested copy of power bills</td>
                                        <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                            <asp:fileupload id="FileUpload3" runat="server" cssclass="CS"
                                                height="28px" />

                                            <asp:hyperlink id="HyperLink2" runat="server" cssclass="LBLBLACK" width="165px" visible="false"
                                                target="_blank">
                                            </asp:hyperlink>
                                            <br />
                                            <asp:label id="Label5" runat="server" visible="False"></asp:label>
                                        </td>
                                        <td style="padding: 5px; margin: 5px; width: 10px;" valign="top">
                                            <asp:button id="Button2" runat="server" cssclass="btn btn-xs btn-warning"
                                                height="28px" tabindex="10" text="Upload"
                                                width="72px" onclick="Button2_Click" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="padding: 3px; margin: 3px; text-align: left;">2. Attested copy of receipts from DISCOM</td>
                                        <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                            <asp:fileupload id="FileUpload4" runat="server" cssclass="CS"
                                                height="28px" />

                                            <asp:hyperlink id="HyperLink3" runat="server" cssclass="LBLBLACK" width="165px" visible="false"
                                                target="_blank">
                                            </asp:hyperlink>
                                            <br />
                                            <asp:label id="Label6" runat="server" visible="False"></asp:label>
                                        </td>
                                        <td style="padding: 5px; margin: 5px; width: 10px;" valign="top">
                                            <asp:button id="Button3" runat="server" cssclass="btn btn-xs btn-warning"
                                                height="28px" tabindex="10" text="Upload"
                                                width="72px" onclick="Button3_Click" />
                                        </td>
                                    </tr>

                                    <tr>
                                        <td style="padding: 3px; margin: 3px; text-align: left;">3. Attested copy of Valid CFO</td>
                                        <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                            <asp:fileupload id="FileUpload6" runat="server" class="form-control txtbox" cssclass="CS"
                                                height="28px" />

                                            <asp:hyperlink id="HyperLink5" runat="server" cssclass="LBLBLACK" width="165px" visible="false"
                                                target="_blank">
                                            </asp:hyperlink>
                                            <br />
                                            <asp:label id="Label8" runat="server" visible="False"></asp:label>
                                        </td>
                                        <td style="padding: 5px; margin: 5px; width: 10px;" valign="top">
                                            <asp:button id="Button5" runat="server" cssclass="btn btn-xs btn-warning"
                                                height="28px" tabindex="10" text="Upload"
                                                width="72px" onclick="Button5_Click" />
                                        </td>
                                    </tr>

                                    <tr id="lblSelcertificate" runat="server">
                                        <td style="padding: 3px; margin: 3px; text-align: left;">4. Self certification as per format<br />
                                            <asp:hyperlink id="HypLnkSelfCertificationFormat" runat="server" visible="true" cssclass="LBLBLACK" width="300px" target="_blank" navigateurl="viewpdf.aspx?filepathnew=D:/TS-iPASSFinal/docs/Self Certification Format.pdf">Click here for Prescribed Format</asp:hyperlink>
                                        </td>
                                        <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                            <asp:fileupload id="FileUpload5" runat="server" cssclass="CS"
                                                height="28px" />

                                            <asp:hyperlink id="HyperLink4" runat="server" cssclass="LBLBLACK" width="165px" visible="false"
                                                target="_blank">
                                            </asp:hyperlink>
                                            <br />
                                            <asp:label id="Label7" runat="server" visible="False"></asp:label>
                                        </td>
                                        <td style="padding: 5px; margin: 5px; width: 10px;" valign="top">
                                            <asp:button id="Button4" runat="server" cssclass="btn btn-xs btn-warning"
                                                height="28px" tabindex="10" text="Upload"
                                                width="72px" onclick="Button4_Click" />
                                        </td>
                                    </tr>

                                    <tr id="trExpanDiversPower" runat="server" visible="false">
                                        <td style="padding: 3px; margin: 3px; text-align: left;">5. Power utilisation particulars of previous 3 years certified by CA i.r.o expansion / diversification
                                            <br />
                                            (Rar or Pdf Files) 
                                        </td>
                                        <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                            <asp:fileupload id="FileUpload2" runat="server" cssclass="CS"
                                                height="28px" />

                                            <asp:hyperlink id="HyperLink1" runat="server" cssclass="LBLBLACK" width="165px" visible="false"
                                                target="_blank">
                                            </asp:hyperlink>
                                            <br />
                                            <asp:label id="Label4" runat="server" visible="False"></asp:label>
                                        </td>
                                        <td style="padding: 5px; margin: 5px; width: 10px;" valign="top">
                                            <asp:button id="Button1" runat="server" cssclass="btn btn-xs btn-warning"
                                                height="28px" tabindex="10" text="Upload"
                                                width="72px" onclick="Button1_Click" />
                                        </td>
                                    </tr>
                                    <tr id="trMSME2DiscomCert" runat="server" visible="false">
                                        <td style="padding: 3px; margin: 3px; text-align: left;">6. Power release certificate issued by DISCOM concerned for the first time of claim
       
                                        </td>
                                        <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                            <asp:fileupload id="fupDiscomCert" runat="server" cssclass="CS"
                                                height="28px" />

                                            <asp:hyperlink id="hplDiscomCert" runat="server" cssclass="LBLBLACK" width="165px" visible="false"
                                                target="_blank">
                                            </asp:hyperlink>
                                            <br />
                                            <asp:label id="lblDiscomCert" runat="server" visible="False"></asp:label>
                                        </td>
                                        <td style="padding: 5px; margin: 5px; width: 10px;" valign="top">
                                            <asp:button id="btnDiscomCert" runat="server" cssclass="btn btn-xs btn-warning"
                                                height="28px" tabindex="10" text="Upload"
                                                width="72px" onclick="btnDiscomCert_Click" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="8" style="padding: 5px; margin: 5px; text-align: center;"></td>
                        </tr>
                        <tr>
                            <td colspan="8" style="padding: 5px; margin: 5px; text-align: left;">
                                <b>DECLARATION :  </b>
                                <br />
                                I / We hereby confirm that to the best of our knowledge and belief, information given herein and other
papers enclosed are true and correct in all respects. We further undertake to substantiate the particulars
about promoter(s) and other details with documentary evidence as and when called for.<br />
                                I/We hereby agree that I/We shall forthwith repay the amount to me/us under scheme, if the amount of
Reimbursement of power tariff is found to be disbursed in excess of the amount actually admissible
whatsoever the reason.<br />
                                Certified that this amount has not been claimed earlier. In case of a wrong claim I shall repay the entire
amount of concession(s) availed under
                                <asp:label id="lblscheme" runat="server"></asp:label>
                                &nbsp;in Lump sum with prevailing interest.

                            </td>
                        </tr>
                        <tr>
                            <td colspan="8" style="padding: 5px; margin: 5px; text-align: center;"></td>
                        </tr>
                        <tr>
                            <td align="center" style="padding: 5px; margin: 5px; text-align: center;">
                                <asp:button id="BtnSave" runat="server" cssclass="btn btn-primary" height="32px" tabindex="10" text="Submit" validationgroup="group" width="90px" onclick="BtnSave_Click" />
                                &nbsp;
                                                    <asp:button id="BtnDelete0" runat="server" causesvalidation="False" cssclass="btn btn-danger" height="32px" onclick="BtnDelete0_Click" tabindex="10" text="Previous" width="90px" />
                                &nbsp;&nbsp;<asp:button id="BtnDelete" runat="server" cssclass="btn btn-danger" height="32px" onclick="BtnClear0_Click" tabindex="10" text="Next" validationgroup="group" width="90px" enabled="false" />
                                &nbsp;<asp:button id="BtnClear" runat="server" causesvalidation="False" cssclass="btn btn-warning" height="32px" onclick="BtnClear_Click" tabindex="10" text="ClearAll" tooltip="To Clear  the Screen" width="90px" />
                            </td>
                        </tr>
                        <tr>
                            <td align="center" style="padding: 5px; margin: 5px">


                                <div id="success" runat="server" visible="false" class="alert alert-success">
                                    <a href="AddQualification.aspx" class="close" data-dismiss="alert" aria-label="close">&times;</a>
                                    <asp:label id="lblmsg" runat="server"></asp:label>
                                </div>


                                <div id="Failure" runat="server" visible="false" class="alert alert-danger">
                                    <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a>
                                    <strong>Warning!</strong>
                                    <asp:label id="lblmsg0" runat="server"></asp:label>
                                </div>
                            </td>
                        </tr>
                    </table>
                    <asp:hiddenfield id="hdfID" runat="server" />
                    <asp:validationsummary id="ValidationSummary1" runat="server"
                        showmessagebox="True" showsummary="False" validationgroup="group" />
                    <asp:validationsummary id="ValidationSummary2" runat="server"
                        showmessagebox="True" showsummary="False" validationgroup="child" />
                    <asp:hiddenfield id="hdfFlagID" runat="server" />
                    <asp:hiddenfield id="hdfFlagID0" runat="server" />
                    <asp:hiddenfield id="hdfpencode" runat="server" />
                    <%--</div>--%>
                </div>
            </div>
        </div>

    </div>


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

</asp:content>

