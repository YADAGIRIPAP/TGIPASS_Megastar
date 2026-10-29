<%@ Page Title="" Language="C#" MasterPageFile="~/UI/TSiPASS/CCMaster.master" AutoEventWireup="true" CodeFile="frmIncentiveForm4.aspx.cs" Inherits="UI_TSiPASS_frmIncentiveForm4" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
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

        .CS {
            background-color: #abcdef;
            color: Yellow;
            border: 1px solid #1d9a5b;
            font: Verdana 10px;
            padding: 1px 4px;
            font-family: Palatino Linotype, Arial, Helvetica, sans-serif;
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
    <%-- <script type="text/javascript">
        function showProgress() {
            var updateProgress = $get("<%= UpdateProgress.ClientID %>");
            updateProgress.style.display = "block";
        }
    </script>--%>

    <script type="text/javascript">
        function inputOnlyNumbers(evt) {
            var e = window.event || evt; // for trans-browser compatibility  
            var charCode = e.which || e.keyCode;
            if ((charCode > 45 && charCode < 58) || charCode == 8 || charCode == 9) {
                return true;
            }
            return false;
        }

    </script>

    <%--    <asp:UpdatePanel ID="upd1" runat="server">
        <ContentTemplate>--%>
    <div align="left">
        <div class="row" align="left">
            <div class="col-lg-11">
                <div class="panel panel-primary">
                    <div class="panel-heading" style="background-color: #339966">
                        <table style="width: 100%">
                            <tr>
                                <td>
                                    <asp:Label ID="lblheadTPRIDE" runat="server" Visible="false"> </asp:Label>
                                    <asp:Label ID="lblheadTIDEA" runat="server" Visible="false"> </asp:Label>
                                    <asp:Label ID="lblMSMEPolicy" runat="server" ForeColor="White" Font-Bold="true" Font-Size="20px" Visible="false" Text="Reimbursement of 
                                        Pavala Vaddi under MSME Policy">
                                    </asp:Label><asp:HiddenField ID="hdnMSMEApplied" runat="server" />
                                </td>
                            </tr>
                        </table>
                    </div>
                    <%-- <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>--%>
                    <div class="panel-body">
                        <table align="center" cellpadding="10" cellspacing="5" style="width: 90%">

                            <tr>
                                <td style="padding: 5px; margin: 5px; text-align: left; font-weight: bold">1. Interest paid details from DCP</td>
                            </tr>
                            <tr>
                                <td style="padding: 5px; margin: 5px; text-align: left; font-weight: bold">
                                    <%--<asp:Label ID="Label1" runat="server"></asp:Label>--%>
                                    <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Names="Verdana" Font-Size="13px"
                                        ForeColor="Green" Style="position: static"></asp:Label>
                                </td>
                            </tr>
                            <tr id="trenergy1" runat="server">
                                <td style="padding: 5px; margin: 5px" valign="top">
                                    <table style="width: 100%; font-weight: bold;">
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">1</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label11" runat="server">Financial Year</asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:DropDownList ID="ddlFinYearEnergy" runat="server" class="form-control txtbox" Height="33px" Width="180px">
                                                    <asp:ListItem>--Select--</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">2</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label16" runat="server"> 1st / 2nd half Year<font color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:DropDownList ID="ddlFin1stOr2ndHalfyear" runat="server" class="form-control txtbox" Height="33px" Width="180px" OnSelectedIndexChanged="ddlFin1stOr2ndHalfyear_SelectedIndexChanged">
                                                    <asp:ListItem Value="--Select--" Text="--Select--"></asp:ListItem>
                                                    <asp:ListItem Value="1" Text="1st"></asp:ListItem>
                                                    <asp:ListItem Value="2" Text="2nd"></asp:ListItem>
<%--                                                    <asp:ListItem Value="3" Text="Both"></asp:ListItem>--%>
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">3</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label12" runat="server">Interest paid on Term Loan on half yearly basis</asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:TextBox ID="txtInterestpaidonTermLoan" runat="server" class="form-control txtbox" onkeypress="return inputOnlyNumbers(event)"
                                                    Height="28px" MaxLength="40" TabIndex="36" Width="180px"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">4</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label14" runat="server">Rate of interest %</asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:TextBox ID="txtRateofinterest" runat="server" class="form-control txtbox" onkeypress="return inputOnlyNumbers(event)"
                                                    Height="28px" MaxLength="40" TabIndex="36" Width="180px"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">5</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label13" runat="server">Interest paid (in Rs.) excluding penal interest</asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:TextBox ID="txtInterestpaidexcludingpenal" runat="server" class="form-control txtbox" onkeypress="return inputOnlyNumbers(event)"
                                                    Height="28px" MaxLength="40" TabIndex="36" Width="180px"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">6</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label15" runat="server">Eligible % (Max 9%)</asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:TextBox ID="txtEligiblemax" runat="server" class="form-control txtbox" onkeypress="return inputOnlyNumbers(event)"
                                                    Height="28px" MaxLength="1" TabIndex="36" Width="180px"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr id="tr1" runat="server">
                                            <td style="padding: 5px; margin: 5px; text-align: left;">7</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label4" runat="server">Amount claimed (in Rs.)</asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:TextBox ID="txtAmountClaimed" runat="server" class="form-control txtbox" onkeypress="return inputOnlyNumbers(event)"
                                                    Height="28px" MaxLength="40" TabIndex="36" Width="180px"></asp:TextBox>
                                            </td>
                                            <td align="center" colspan="4" style="height: 50px">
                                                <asp:Button ID="btnEnergyAdd" runat="server" CssClass="btn btn-xs btn-warning" Height="28px" TabIndex="39" Text="Add New" Width="72px" OnClick="btnEnergyAdd_Click" />
                                                &nbsp;&nbsp;&nbsp;
                                                <asp:Button ID="btnEnergyClear" runat="server" CausesValidation="False" CssClass="btn btn-xs btn-danger" Height="28px" TabIndex="40" Text="Clear" ToolTip="To Clear the Screen" Width="73px" />
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr id="trenergy2" runat="server">
                                <td style="padding: 5px; margin: 5px" valign="top" align="center" colspan="3">
                                    <asp:GridView ID="gvEnergy" runat="server" AutoGenerateColumns="False"
                                        BorderColor="#003399" BorderStyle="Solid" BorderWidth="1px" CellPadding="4"
                                        CssClass="GRD" ForeColor="#333333" GridLines="Both" Visible="false"
                                        Width="95%" DataKeyNames="intLineofActivityMid" OnRowDataBound="gvEnergy_RowDataBound" OnRowDeleting="gvEnergy_RowDeleting">
                                        <RowStyle BackColor="#ffffff" />
                                        <Columns>
                                            <asp:TemplateField HeaderText="Sl.No">
                                                <ItemTemplate>
                                                    <asp:Label ID="Slno" runat="server" Text="<%# Container.DataItemIndex + 1 %>"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="FinancialYearId" HeaderText="Financial YearId" Visible="false" />
                                            <asp:BoundField DataField="FinancialYear" HeaderText="Financial Year" />
                                            <asp:BoundField DataField="Fin1stOr2ndHalfYear" HeaderText="1st or 2nd Half Financial Year" />
                                            <asp:BoundField DataField="InterestpaidonTermLoan" HeaderText="Interest paid on Term Loan on half yearly basis" />
                                            <asp:BoundField DataField="Rateofinterest" HeaderText="Rate of interest %" />
                                            <asp:BoundField DataField="Interestpaidexcludingpenalinterest" HeaderText="Interest paid (in Rs.) excluding penal interest" />
                                            <asp:BoundField DataField="EligibleMax" HeaderText="Eligible % (Max 9%)" />
                                            <asp:BoundField DataField="Amountclaimed" HeaderText="Amount claimed (in Rs.)" />
                                            <asp:BoundField DataField="Created_by" HeaderText="Created By" Visible="False" />
                                            <asp:BoundField DataField="IncentiveId" HeaderText="Incentive Id" Visible="False" />
                                            <asp:CommandField HeaderText="Delete" ShowDeleteButton="True" />
                                            <asp:CommandField HeaderText="Edit" ShowSelectButton="True" Visible="False" />
                                        </Columns>
                                        <HeaderStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                        <PagerStyle BackColor="#013161" ForeColor="White" HorizontalAlign="Center" />
                                        <AlternatingRowStyle BackColor="#D5E6F9" ForeColor="#284775" />
                                        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" Font-Names="Arial" Font-Size="12px" HorizontalAlign="Center" />
                                        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                        <FooterStyle HorizontalAlign="Center" BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" Font-Names="Arial" Font-Size="9px" />
                                    </asp:GridView>
                                </td>
                            </tr>

                            <tr id="trenergyview" runat="server">
                                <td style="padding: 5px; margin: 5px" valign="top" align="center" colspan="3">
                                    <asp:GridView ID="gvenergyview" runat="server" AutoGenerateColumns="False"
                                        BorderColor="#003399" BorderStyle="Solid" BorderWidth="1px" CellPadding="4"
                                        CssClass="GRD" ForeColor="#333333" GridLines="Both" Width="95%">
                                        <RowStyle BackColor="#ffffff" />
                                        <Columns>
                                            <asp:TemplateField HeaderText="Sl.No">
                                                <ItemTemplate>
                                                    <asp:Label ID="Slno" runat="server" Text="<%# Container.DataItemIndex + 1 %>"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="FinancialYearNew" HeaderText="Financial Year" />
                                            <asp:BoundField DataField="Fin1stOr2ndHalfYear" HeaderText="1st or 2nd Half Financial Year" />
                                            <asp:BoundField DataField="IntrestPaid" HeaderText="Interest paid on Term Loan on half yearly basis" />
                                            <asp:BoundField DataField="RateofIntrest" HeaderText="Rate of interest %" />
                                            <asp:BoundField DataField="IntrestPenaltyPaid" HeaderText="Interest paid (in Rs.) excluding penal interest" />
                                            <asp:BoundField DataField="Eligible" HeaderText="Eligible % (Max 9%)" />
                                            <asp:BoundField DataField="AmountClaimed" HeaderText="Amount claimed (in Rs.)" />
                                        </Columns>
                                        <HeaderStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                        <PagerStyle BackColor="#013161" ForeColor="White" HorizontalAlign="Center" />
                                        <AlternatingRowStyle BackColor="#D5E6F9" ForeColor="#284775" />
                                        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" Font-Names="Arial" Font-Size="12px" HorizontalAlign="Center" />
                                        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                        <FooterStyle HorizontalAlign="Center" BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" Font-Names="Arial" Font-Size="9px" />
                                    </asp:GridView>
                                </td>
                            </tr>

                            <tr>
                                <td
                                    style="padding: 5px; margin: 5px; text-align: left; font-weight: bold;">Enclosures:</td>
                            </tr>
                            <tr>
                                <td>
                                    <table style="width: 80%">
                                        <tr id="trallreqCheckSlipdocs" runat="server" visible="false" valign="top">
                                            <td style="padding: 3px; margin: 3px; text-align: left;">1. All required documents as per check slip during 1st claim</td>
                                            <td class="style6" style="padding: 5px; width margin: 5px; text-align: left;">
                                                <asp:FileUpload ID="FileUpload1" runat="server" CssClass="CS"
                                                    Height="28px" />

                                                <asp:HyperLink ID="lblFileName" runat="server" CssClass="LBLBLACK" Target="_blank"></asp:HyperLink>
                                                <br />
                                                <asp:Label ID="Label444" runat="server" Visible="False"></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;" valign="top">
                                                <asp:Button ID="BtnSave3" runat="server" CssClass="btn btn-xs btn-warning" Height="28px" TabIndex="10" Text="Upload"
                                                    Width="72px" OnClick="BtnSave3_Click" />
                                            </td>
                                        </tr>

                                        <tr>
                                            <td colspan="3" style="padding: 3px; margin: 3px; text-align: left; font-weight: bold" valign="top">During all subsequent claims</td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 3px; margin: 3px; text-align: left;" valign="top">1. Certificate from Financial institution in prscribed format
                                                <br /> 
                                                <asp:HyperLink ID="HypLnkFinancialInstidtutionFormat" runat="server" Visible="true" CssClass="LBLBLACK" Width="300px" Target="_blank" NavigateUrl="~/docs/certificate from financial institution.pdf">Click here for Prescribed Format</asp:HyperLink>
                                            </td>
                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:FileUpload ID="FileUpload2" runat="server" CssClass="CS"
                                                    Height="28px" />

                                                <asp:HyperLink ID="HyperLink1" runat="server" CssClass="LBLBLACK"
                                                    Target="_blank"></asp:HyperLink>
                                                <br />
                                                <asp:Label ID="Label2" runat="server" Visible="False"></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;" valign="top">
                                                <asp:Button ID="Button1" runat="server" CssClass="btn btn-xs btn-warning"
                                                    Height="28px" TabIndex="10" Text="Upload"
                                                    Width="72px" OnClick="Button1_Click" />
                                            </td>
                                        </tr>

                                        <tr>
                                            <td style="padding: 3px; margin: 3px; text-align: left;" valign="top">2. Attested copy of Valid CFO</td>
                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:FileUpload ID="FileUpload3" runat="server" CssClass="CS"
                                                    Height="28px" />

                                                <asp:HyperLink ID="HyperLink2" runat="server" CssClass="LBLBLACK"
                                                    Target="_blank"></asp:HyperLink>
                                                <br />
                                                <asp:Label ID="Label3" runat="server" Visible="False"></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;" valign="top">
                                                <asp:Button ID="Button2" runat="server" CssClass="btn btn-xs btn-warning"
                                                    Height="28px" TabIndex="10" Text="Upload"
                                                    Width="72px" OnClick="Button2_Click" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 3px; margin: 3px; text-align: left;" valign="top">3. C.A. Certificate
                                                <br />
                                                <asp:HyperLink ID="HyperLinkCivilEngineersFormat" runat="server" Visible="true" CssClass="LBLBLACK" Width="300px" Target="_blank" NavigateUrl="~/docs/Pavala Vaddi CA Format.pdf">Click here for Prescribed Format</asp:HyperLink>
                                            </td>
                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:FileUpload ID="FileUpload4" runat="server" CssClass="CS"
                                                    Height="28px" />

                                                <asp:HyperLink ID="HyperLink3" runat="server" CssClass="LBLBLACK"
                                                    Target="_blank"></asp:HyperLink>
                                                <br />
                                                <asp:Label ID="Label5" runat="server" Visible="False"></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;" valign="top">
                                                <asp:Button ID="Button3" runat="server" CssClass="btn btn-xs btn-warning"
                                                    Height="28px" TabIndex="10" Text="Upload"
                                                    Width="72px" OnClick="Button3_Click" />
                                            </td>
                                        </tr>
                                        <tr id="trMSME1" runat="server" visible="false">
    <td style="padding: 3px; margin: 3px; text-align: left;" valign="top">4. Term loan account statement duly covering the loan repayment details of claim period </td>
    <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
        <asp:FileUpload ID="fupLoanstmt" runat="server" CssClass="CS"
            Height="28px" />

        <asp:HyperLink ID="hplLoanstmt" runat="server" CssClass="LBLBLACK"
            Target="_blank"></asp:HyperLink>
        <br />
        <asp:Label ID="lblLoanstmt" runat="server" Visible="False"></asp:Label>
    </td>
    <td style="padding: 5px; margin: 5px; width: 10px;" valign="top">
        <asp:Button ID="btnLoanstmt" runat="server" CssClass="btn btn-xs btn-warning"
            Height="28px" TabIndex="10" Text="Upload"
            Width="72px" OnClick="btnLoanstmt_Click" />
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
                                    I / We hereby confirm that to the best of our knowledge and belief, information given herein before and
other papers enclosed are true and correct in all respects. We further undertake to substantiate the
particulars about promoter(s) and other details with documentary evidence as and when called for.<br />
                                    I/We hereby agree that I/We shall forthwith repay the amount to me/us under &nbsp;
                                    <asp:Label ID="lblscheme" runat="server"></asp:Label>
                                    &nbsp;, if the amount of
Interest Subsidy are found to be disbursed in excess of the amount actually admissible whatsoever the
reason.

                                </td>
                            </tr>
                            <tr>
                                <td colspan="8" style="padding: 5px; margin: 5px; text-align: center;"></td>
                            </tr>
                            <tr>
                                <td align="center" style="padding: 5px; margin: 5px; text-align: center;">
                                    <asp:Button ID="BtnSave1" runat="server" CssClass="btn btn-primary" Height="32px" OnClick="BtnSave_Click" TabIndex="10" Text="Submit" ValidationGroup="group" Width="90px" />
                                    &nbsp;
                                                    <asp:Button ID="BtnDelete0" runat="server" CausesValidation="False" CssClass="btn btn-danger" Height="32px" OnClick="BtnDelete0_Click" TabIndex="10" Text="Previous" Width="90px" />
                                    &nbsp;&nbsp;<asp:Button ID="BtnDelete" runat="server" CssClass="btn btn-danger" Height="32px" OnClick="BtnClear0_Click" TabIndex="10" Text="Next" ValidationGroup="group" Width="90px" Enabled="false" />
                                    &nbsp;<asp:Button ID="BtnClear" runat="server" CausesValidation="False" CssClass="btn btn-warning" Height="32px" OnClick="BtnClear_Click" TabIndex="10" Text="ClearAll" ToolTip="To Clear  the Screen" Width="90px" />
                                </td>
                            </tr>
                            <tr>
                                <td align="center" style="padding: 5px; margin: 5px">


                                    <div id="success" runat="server" visible="false" class="alert alert-success">
                                        <a href="AddQualification.aspx" class="close" data-dismiss="alert" aria-label="close">&times;</a>
                                        <strong></strong>
                                        <asp:Label ID="lblmsg" runat="server"></asp:Label>
                                    </div>


                                    <div id="Failure" runat="server" visible="false" class="alert alert-danger">
                                        <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a>
                                        <strong>Warning!</strong>
                                        <asp:Label ID="lblmsg0" runat="server"></asp:Label>
                                    </div>
                                </td>
                            </tr>
                        </table>
                        <asp:HiddenField ID="hdfID" runat="server" />
                        <asp:ValidationSummary ID="ValidationSummary1" runat="server"
                            ShowMessageBox="True" ShowSummary="False" ValidationGroup="group" />
                        <asp:ValidationSummary ID="ValidationSummary2" runat="server"
                            ShowMessageBox="True" ShowSummary="False" ValidationGroup="child" />
                        <asp:HiddenField ID="hdfFlagID" runat="server" />
                        <asp:HiddenField ID="hdfFlagID0" runat="server" />
                        <asp:HiddenField ID="hdfpencode" runat="server" />
                    </div>
                    <%--</ContentTemplate>
                            </asp:UpdatePanel>--%>
                </div>
            </div>
        </div>

    </div>
    <%--            <asp:UpdateProgress ID="UpdateProgress" runat="server" AssociatedUpdatePanelID="upd1">
                <ProgressTemplate>
                    <div class="update">
                    </div>
                </ProgressTemplate>
            </asp:UpdateProgress>--%>

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
    <%--        </ContentTemplate>
    </asp:UpdatePanel>--%>
</asp:Content>
