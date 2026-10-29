<%@ Page Title="" Language="C#" MasterPageFile="~/UI/TSiPASS/CCMaster.master" AutoEventWireup="true"
    CodeFile="IncentiveFromVIII.aspx.cs" Inherits="UI_TSiPASS_IncentiveFromVIII" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script src="../../Resource/Scripts/js/validations.js" type="text/javascript"></script>
    <link href="assets/css/basic.css" rel="stylesheet" />
    <style type="text/css">
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
        .CS {
            background-color: #abcdef;
            color: Yellow;
            border: 1px solid #1d9a5b;
            font: Verdana 10px;
            padding: 1px 4px;
            font-family: Palatino Linotype, Arial, Helvetica, sans-serif;
        }
        .style5 {
            color: #FF0000;
        }
    </style>
    <%--<script type="text/javascript">
        function showProgress() {
            var updateProgress = $get("<%= UpdateProgress.ClientID %>");
            updateProgress.style.display = "block";
        }
    </script>--%>
    <script type="text/javascript">
        function inputOnlyNumbers(evt) {
            var e = window.event || evt; // for trans-browser compatibility  
            var charCode = e.which || e.keyCode;
            if ((charCode > 45 && charCode < 58) || charCode == 8) {
                return true;
            }
            return false;
        }
    </script>
    <script type="text/javascript">
        function alpha(e) {
            var k;
            document.all ? k = e.keyCode : k = e.which;
            return ((k > 64 && k < 91) || (k > 96 && k < 123) || k == 8 || k == 32 || (k >= 48 && k <= 57));
        }
    </script>
    <script type="text/javascript">
        function Names() {
            var AsciiValue = event.keyCode
            if ((AsciiValue >= 65 && AsciiValue <= 90) || (AsciiValue >= 97 && AsciiValue <= 122) || (AsciiValue == 46) || (AsciiValue == 32))
                event.returnValue = true;
            else {
                event.returnValue = false;

                alert("Enter Alphabets, '.' and Space Only");
            }
        }
    </script>
    <script type="text/javascript">
        function checkLength(el) {
            if (el.value.length != 6) {
                alert("Pin number length must be exactly 6 characters")
            }
        }
    </script>
    <script type="text/javascript">
        function checkLength1(el) {
            if (el.value.length != 10) {
                alert("Mobile number length must be exactly 10 characters")
            }
        }
    </script>
    <%--  <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <h1 class="page-head-line" align="left" style="font-size: x-large">
                        APPLICATION CUM VERIFICATION FOR REIMBURSEMENT ON EQUIPMENT PURCHASED FOR CLEANER
                        PRODUCTION MEASURES UNDER T-PRIDE— TELANGANA STATE PROGRAM FOR RAPID INCUBATION
                        OF DALIT ENTREPRENEURS INCENTIVE SCHEME. (G.O.Ms.No.29 Industries and Commerce (IP
                        & INF) Department. dated.29/11/2014)</h1>
        <ContentTemplate>--%>
    <div align="left">
        <div class="row" align="left">
            <div class="col-lg-11">
                <div class="panel panel-primary">
                    <div class="panel panel-primary" align="center">
                       <div class="panel-heading" style="background-color: #339966">
                         <table style="width: 100%">
                                <tr>
                                    <td>
                                          <asp:Label ID="lblheadTPRIDE" runat="server" Visible="false" >
                                        </asp:Label>
                                         <asp:Label ID="lblheadTIDEA" runat="server" Visible="false">
                                        </asp:Label>
                                        <asp:label id="lblMSMEPolicy" runat="server" visible="false" text="Application for claiming Subsidy for Cleaner Production Measures"
    forecolor="White" font-bold="true" font-size="20px"></asp:label>
<asp:hiddenfield id="hdnMSMEApplied" runat="server" />
                                    </td>
                                </tr>
                            </table>
                    </div>
                        <div class="panel-body">
                            <table align="center" cellpadding="10" cellspacing="5">
                                <tr style="text-align: left;">
                                    <td colspan="11" style="padding: 5px; margin: 5px; text-align: left; font-weight: bold; font-size: 12pt"
                                        valign="top">Details of equipment purchased for cleaner production measures:
                                    </td>
                                </tr>
                            </table>

                            <table align="center" cellpadding="10" cellspacing="5" id="tblmain" runat="server" >
                                <tr>
                                    <td style="padding: 5px; margin: 5px; text-align: left;">1
                                    </td>
                                    <td style="padding: 5px; margin: 5px; text-align: left;">
                                        <asp:Label ID="Label387" runat="server" CssClass="LBLBLACK" Width="210px">Name of the Equipment<font 
                                                            color="red">*</font></asp:Label>
                                    </td>
                                    <td style="padding: 5px; margin: 5px">:
                                    </td>
                                    <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                        <asp:TextBox ID="txtEquipmentName" runat="server" class="form-control txtbox" Height="28px"
                                            MaxLength="40" TabIndex="1" ValidationGroup="group" Width="180px"></asp:TextBox>
                                    </td>
                                    <td style="padding: 5px; margin: 5px; width: 10px;">
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtEquipmentName"
                                            ErrorMessage="Please Enter Name of the Equipment" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                    </td>
                                    <td style="padding: 5px; margin: 5px; text-align: left;">2
                                    </td>
                                    <td style="padding: 5px; margin: 5px; text-align: left;">
                                        <asp:Label ID="Label396" runat="server" CssClass="LBLBLACK" Width="200px">Name & Address of Supplier<font 
                                                            color="red">*</font></asp:Label>
                                    </td>
                                    <td style="padding: 5px; margin: 5px">:
                                    </td>
                                    <td style="padding: 5px; margin: 5px; text-align: left;">
                                        <asp:TextBox ID="txtSupplierAddress" runat="server" class="form-control txtbox" onkeypress="Names()"
                                            Height="28px" MaxLength="40" TabIndex="1" ValidationGroup="group" Width="180px"></asp:TextBox>
                                    </td>
                                    <td style="padding: 5px; margin: 5px">
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtSupplierAddress"
                                            ErrorMessage="Please Enter txtCertificat Number" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="padding: 5px; margin: 5px; text-align: left;">3
                                    </td>
                                    <td style="padding: 5px; margin: 5px; text-align: left;">
                                        <asp:Label ID="Label1" runat="server" CssClass="LBLBLACK" Width="210px">Bill No<font 
                                                            color="red">*</font></asp:Label>
                                    </td>
                                    <td style="padding: 5px; margin: 5px">:
                                    </td>
                                    <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                        <asp:TextBox ID="txtbillno" runat="server" class="form-control txtbox" Height="28px"
                                            MaxLength="40" TabIndex="1" ValidationGroup="group" Width="180px"></asp:TextBox>
                                    </td>
                                    <td style="padding: 5px; margin: 5px; width: 10px;">
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtbillno"
                                            ErrorMessage="Please Enter Bill No." ValidationGroup="group">*</asp:RequiredFieldValidator>
                                    </td>
                                    <td style="padding: 5px; margin: 5px; text-align: left;">4
                                    </td>
                                    <td style="padding: 5px; margin: 5px; text-align: left;">
                                        <asp:Label ID="Label2" runat="server" CssClass="LBLBLACK" Width="165px">Bill Date<font 
                                                            color="red">*</font></asp:Label>
                                    </td>
                                    <td style="padding: 5px; margin: 5px">:
                                    </td>
                                    <td style="padding: 5px; margin: 5px; text-align: left;">
                                        <asp:TextBox ID="txtBillDate" runat="server" class="form-control txtbox" Height="28px"
                                            MaxLength="40" TabIndex="1" ValidationGroup="group" Width="180px"></asp:TextBox>
                                    </td>
                                    <td style="padding: 5px; margin: 5px">
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtBillDate"
                                            ErrorMessage="Please Enter Bill Date" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="padding: 5px; margin: 5px; text-align: left;">5
                                    </td>
                                    <td style="padding: 5px; margin: 5px; text-align: left;">
                                        <asp:Label ID="Label3" runat="server" CssClass="LBLBLACK" Width="210px">Cost of the equipment in Rs.<font 
                                                            color="red">*</font></asp:Label>
                                    </td>
                                    <td style="padding: 5px; margin: 5px">:
                                    </td>
                                    <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                        <asp:TextBox ID="txtCostoftheequipment" runat="server" class="form-control txtbox"
                                            Height="28px" MaxLength="40" TabIndex="1" ValidationGroup="group" Width="180px"></asp:TextBox>
                                    </td>
                                    <td style="padding: 5px; margin: 5px; width: 10px;">
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtCostoftheequipment"
                                            ErrorMessage="Please Enter Cost of the equipment in Rs" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                    </td>
                                    <td style="padding: 5px; margin: 5px; text-align: left;">6
                                    </td>
                                    <td style="padding: 5px; margin: 5px; text-align: left;">
                                        <asp:Label ID="Label4" runat="server" CssClass="LBLBLACK" Width="165px">VAT/ CST/ GST in Rs.<font 
                                                            color="red">*</font></asp:Label>
                                    </td>
                                    <td style="padding: 5px; margin: 5px">:
                                    </td>
                                    <td style="padding: 5px; margin: 5px; text-align: left;">
                                        <asp:TextBox ID="txtVAtCSTinRs" runat="server" class="form-control txtbox" Height="28px"
                                            MaxLength="40" TabIndex="1" ValidationGroup="group" Width="180px"></asp:TextBox>
                                    </td>
                                    <td style="padding: 5px; margin: 5px">
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtVAtCSTinRs"
                                            ErrorMessage="Please Enter VAT/CST in Rs" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="padding: 5px; margin: 5px; text-align: left;">7
                                    </td>
                                    <td style="padding: 5px; margin: 5px; text-align: left;">
                                        <asp:Label ID="Label5" runat="server" CssClass="LBLBLACK" Width="210px">Excise Duty in Rs.<font 
                                                            color="red">*</font></asp:Label>
                                    </td>
                                    <td style="padding: 5px; margin: 5px">:
                                    </td>
                                    <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                        <asp:TextBox ID="txtExciseDuty" runat="server" class="form-control txtbox" Height="28px"
                                            MaxLength="40" TabIndex="1" ValidationGroup="group" Width="180px"></asp:TextBox>
                                    </td>
                                    <td style="padding: 5px; margin: 5px; width: 10px;">
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtExciseDuty"
                                            ErrorMessage="Please Enter Excise Duty in Rs" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                    </td>
                                    <td style="padding: 5px; margin: 5px; text-align: left;">8
                                    </td>
                                    <td style="padding: 5px; margin: 5px; text-align: left;">
                                        <asp:Label ID="Label6" runat="server" CssClass="LBLBLACK" Width="165px">Freight Charge in Rs.<font 
                                                            color="red">*</font></asp:Label>
                                    </td>
                                    <td style="padding: 5px; margin: 5px">:
                                    </td>
                                    <td style="padding: 5px; margin: 5px; text-align: left;">
                                        <asp:TextBox ID="txtFreight" runat="server" class="form-control txtbox" Height="28px"
                                            MaxLength="40" TabIndex="1" ValidationGroup="group" Width="180px"></asp:TextBox>
                                    </td>
                                    <td style="padding: 5px; margin: 5px">
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtFreight"
                                            ErrorMessage="Please Enter Freight Charge in Rs" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="padding: 5px; margin: 5px; text-align: left;">9
                                    </td>
                                    <td style="padding: 5px; margin: 5px; text-align: left;">
                                        <asp:Label ID="Label7" runat="server" CssClass="LBLBLACK" Width="210px">Other charges in Rs.<font 
                                                            color="red">*</font></asp:Label>
                                    </td>
                                    <td style="padding: 5px; margin: 5px">:
                                    </td>
                                    <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                        <asp:TextBox ID="txtOthercharges" runat="server" class="form-control txtbox" Height="28px"
                                            MaxLength="40" TabIndex="1" ValidationGroup="group" Width="180px"></asp:TextBox>
                                    </td>
                                    <td style="padding: 5px; margin: 5px; width: 10px;">
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txtOthercharges"
                                            ErrorMessage="Please Enter Other charges in Rs." ValidationGroup="group">*</asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr id="tr2" runat="server">
                                    <td style="padding: 5px; margin: 5px" colspan="10" align="center">
                                        <asp:Button ID="BtnSave2" runat="server" CssClass="btn btn-xs btn-warning" Height="28px"
                                            TabIndex="10" Text="Add New" ValidationGroup="group" Width="72px" OnClick="BtnSave2_Click1" />
                                        &nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="BtnClear0" runat="server" CausesValidation="False"
                                            CssClass="btn btn-xs btn-danger" Height="28px" TabIndex="10" Text="Cancel" ToolTip="To Clear  the Screen"
                                            Width="73px" OnClick="BtnClear0_Click2" />
                                    </td>
                                    <td style="padding: 5px; margin: 5px">&nbsp;
                                    </td>
                                </tr>
                            </table>
                            <table align="center" cellpadding="10" cellspacing="5">
                                <tr>
                                    <td style="padding: 5px; margin: 5px; text-align: left;" colspan="11">
                                        <asp:GridView ID="gvCertificate" runat="server" AutoGenerateColumns="False" BorderColor="#003399"
                                            BorderStyle="Solid" BorderWidth="1px" CellPadding="4" CssClass="GRD" ForeColor="#333333"
                                            GridLines="Both" OnRowDataBound="gvCertificate_RowDataBound" OnRowDeleting="gvCertificate_RowDeleting"
                                            Width="100%">
                                            <RowStyle BackColor="#ffffff" />
                                            <Columns>
                                                <%-- <asp:CommandField HeaderText="Edit" ShowSelectButton="True" Visible="False" />--%>
                                                <asp:CommandField HeaderText="Delete" ShowDeleteButton="True" />
                                                <asp:BoundField DataField="Nameoftheequipment" HeaderText="Name of the equipment" />
                                                <asp:BoundField DataField="Nameaddressofsupplier" HeaderText="Name & address of supplier" />
                                                <asp:BoundField DataField="BillNo" HeaderText="Bill No" />
                                                <asp:BoundField DataField="BillDate" HeaderText="Bill Date" />
                                                <asp:BoundField DataField="Costoftheequipment" HeaderText="Cost of the equipment in Rs." />
                                                <asp:BoundField DataField="VATCST" HeaderText="VAT/CST in Rs." />
                                                <asp:BoundField DataField="ExciseDuty" HeaderText="Excise Duty in Rs." />
                                                <asp:BoundField DataField="FreightCharge" HeaderText="Freight Charge in Rs." />
                                                <asp:BoundField DataField="Othercharges" HeaderText="Other charges in Rs." />
                                                <asp:BoundField DataField="TotalinRs" HeaderText="Total in Rs." />
                                                <asp:TemplateField Visible="false">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblid" runat="server" Text='<%# Bind("id") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                            <FooterStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                            <PagerStyle BackColor="#013161" ForeColor="White" HorizontalAlign="Center" />
                                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                            <HeaderStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                            <EditRowStyle BackColor="#013161" />
                                            <AlternatingRowStyle BackColor="White" />
                                        </asp:GridView>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="padding: 5px; margin: 5px" colspan="10" align="center"></td>
                                </tr>
                                <tr>
                                    <td style="padding: 5px; margin: 5px">10
                                    </td>
                                    <td style="padding: 5px; margin: 5px; text-align: left;" colspan="2">Amount of subsidy claimed in Rs. &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    </td>
                                    <td colspan="5">
                                        <asp:TextBox ID="txtsubsidyclaimed" Width="150px" runat="server" class="form-control txtbox"></asp:TextBox>
                                    </td>
                                </tr>
                                 <tr id="Tr1" runat="server">
                                    <td style="padding: 5px; margin: 5px">
                                    </td>
                                    <td colspan="8" style="padding: 5px; margin: 5px; text-align: left;"><b>Enclosures: </b>
                                    </td>
                                    
                                </tr>
                                <tr id="Panelpcb1" runat="server">
                                    <td style="padding: 5px; margin: 5px">1
                                    </td>
                                    <td colspan="3" style="padding: 5px; margin: 5px; text-align: left;">Original Purchase bills & Payment Proofs duly certified by the Financial Institution in case of aided unit (or) C.A. in case of self finance.<br/>
                                    <asp:HyperLink ID="HyperLinkCivilEngineersFormat" runat="server" Visible="true" CssClass="LBLBLACK" Width="300px" Target="_blank" NavigateUrl="~/docs/Cleaner Production CA Format.pdf">Click here for C.A. Prescribed Format</asp:HyperLink>
                                    </td>
                                    <td style="padding: 5px; margin: 5px;">:
                                    </td>
                                    <td class="style6" style="padding: 5px; margin: 5px; text-align: left;" colspan="3">
                                        <asp:FileUpload ID="FileUpload10" runat="server" CssClass="CS" Height="28px" />
                                        <asp:HyperLink ID="Label453" runat="server" CssClass="LBLBLACK"  Target="_blank"></asp:HyperLink>
                                        <br />
                                        <asp:Label ID="Label454" runat="server" Visible="False"></asp:Label>
                                    </td>
                                    <td style="padding: 5px; margin: 5px;">
                                        <asp:Button ID="Button8" runat="server" CssClass="btn btn-xs btn-warning" Height="28px"
                                            TabIndex="10" Text="Upload" ValidationGroup="gg" Width="72px" OnClick="Button8_Click" />
                                    </td>
                                </tr>
                                <tr id="panelTSCT1" runat="server">
                                    <td style="padding: 5px; margin: 5px">2
                                    </td>
                                    <td style="padding: 5px; margin: 5px; text-align: left;"
                                        colspan="3">Valid CFO  
                                    </td>
                                    <td style="padding: 5px; margin: 5px;">:
                                    </td>
                                    <td class="style6" style="padding: 5px; margin: 5px;" colspan="3">
                                        <asp:FileUpload ID="FileUpload11" runat="server" CssClass="CS" Height="28px" />
                                        <asp:HyperLink ID="HyperLink1" runat="server" CssClass="LBLBLACK" Target="_blank"></asp:HyperLink>
                                        <br />
                                        <asp:Label ID="Label8" runat="server" Visible="False"></asp:Label>
                                    </td>
                                    <td style="padding: 5px; margin: 5px;">
                                        <asp:Button ID="Button9" runat="server" CssClass="btn btn-xs btn-warning" Height="28px"
                                            TabIndex="10" Text="Upload" ValidationGroup="gg" Width="72px" OnClick="Button9_Click" />
                                    </td>
                                </tr>
                                <tr id="panelPRD1" runat="server">
                                    <td style="padding: 5px; margin: 5px">3
                                    </td>
                                    <td style="padding: 5px; margin: 5px; text-align: left;"
                                        colspan="3">Certificate from TSPCB on the Specific Cleaner Production Measures adopter and the cost of the equipment involved therein.
                                    </td>
                                    <td style="padding: 5px; margin: 5px;">&nbsp;:&nbsp;
                                    </td>
                                    <td class="style6" style="padding: 5px; margin: 5px; text-align: left;"
                                        colspan="3">
                                        <asp:FileUpload ID="FileUpload13" runat="server" CssClass="CS" Height="28px" />
                                        <asp:HyperLink ID="HyperLink3" runat="server" CssClass="LBLBLACK"  Target="_blank"></asp:HyperLink>
                                        <br />
                                        <asp:Label ID="Label14" runat="server" Visible="False"></asp:Label>
                                    </td>
                                    <td style="padding: 5px; margin: 5px;">
                                        <asp:Button ID="Button11" runat="server" CssClass="btn btn-xs btn-warning" Height="28px"
                                            TabIndex="10" Text="Upload" ValidationGroup="gg" Width="72px" OnClick="Button11_Click" />
                                    </td>
                                </tr>
                                  <tr>
                                            <td colspan="8" style="padding: 5px; margin: 5px; text-align: center;">
                                            </td>
                                        </tr>
                                         <tr>
                                <td colspan="8" style="padding: 5px; margin: 5px; text-align: left;">
                                    <b>DECLARATION :  </b>
                                    <br />
                                   I / We hereby confirm that to the best of my / our knowledge and belief, information given herein before
and other papers enclosed are true and correct in all respects. I / We further undertake to substantiate the
particulars about promoter(s) and other details with documentary evidence as and when called for.<br />
I/We hereby agree that I/We shall forthwith repay the amount disbursed to me/us under the &nbsp;<asp:Label ID="lblscheme" runat="server"></asp:Label>
                                &nbsp;, if
the amount of Reimbursement is found to be disbursed in excess of the amount actually admissible
whatsoever the reason. 

                                </td>
                            </tr>
                            <tr>
                                <td colspan="8" style="padding: 5px; margin: 5px; text-align: center;"></td>
                            </tr>
                                <tr>
                                    <td align="center" colspan="10" style="padding: 5px; margin: 5px; text-align: center;">
                                        <asp:Button ID="BtnSave1" runat="server" CssClass="btn btn-primary" Height="32px"
                                            OnClick="BtnSave_Click" TabIndex="10" Text="Submit" Width="90px" />
                                        &nbsp;
                                <asp:Button ID="BtnDelete0" runat="server" CssClass="btn btn-danger" Height="32px"
                                    OnClick="BtnDelete0_Click" TabIndex="10" Text="Previous" Width="90px" Visible="true" />
                                        &nbsp; &nbsp;&nbsp;<asp:Button ID="BtnDelete" runat="server" CssClass="btn btn-danger"
                                            Height="32px" OnClick="BtnClear0_Click" TabIndex="10" Text="Next" Width="90px" Enabled="false"   />
                                        &nbsp;<asp:Button ID="BtnClear" runat="server" CausesValidation="False" CssClass="btn btn-warning"
                                            Height="32px" OnClick="BtnClear_Click" TabIndex="10" Text="ClearAll" ToolTip="To Clear  the Screen"
                                            Width="90px" />
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center" colspan="10" style="padding: 5px; margin: 5px">
                                        <div id="success" runat="server" visible="false" class="alert alert-success">
                                            <a href="AddQualification.aspx" class="close" data-dismiss="alert" aria-label="close">&times;</a> <asp:Label ID="lblmsg" runat="server"></asp:Label>
                                        </div>
                                        <div id="Failure" runat="server" visible="false" class="alert alert-danger">
                                            <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a> <strong>Warning!</strong>
                                            <asp:Label ID="lblmsg0" runat="server"></asp:Label>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="10">&nbsp;
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
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

            $("input[id$='txtBillDate']").datepicker(
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
            $("input[id$='txtBillDate']").datepicker(
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

        .LBLBLACK {
        }

        </style>
</asp:Content>
