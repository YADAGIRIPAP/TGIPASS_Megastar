<%@ Page Title="" Language="C#" MasterPageFile="~/UI/TSiPASS/CCMaster.master" MaintainScrollPositionOnPostback="true" AutoEventWireup="true" CodeFile="pallavaddi_RINew.aspx.cs" Inherits="UI_TSiPASS_pallavaddi_RINew" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
       <script src="../../Resource/Scripts/js/validations.js" type="text/javascript"></script>
    <script src="../../js/jquery-latest.min.js" type="text/javascript"></script>
    <script src="../../js/jquery-ui.min.js" type="text/javascript"></script>

        <script language="javascript">
            function Names() {
                var AsciiValue = event.keyCode
                if ((AsciiValue >= 65 && AsciiValue <= 90) || (AsciiValue >= 97 && AsciiValue <= 122) || (AsciiValue == 46) || (AsciiValue == 32))
                    event.returnValue = true;
                else {
                    event.returnValue = false;

                    alert("Enter Alphabets, '.' and Space Only");
                }
            }
            function DecimalOnly() {
                var AsciiValue = event.keyCode
                if ((AsciiValue >= 48 && AsciiValue <= 57) || (AsciiValue == 8 || AsciiValue == 127) || AsciiValue == 46)
                    event.returnValue = true;
                else {
                    event.returnValue = false;

                    alert("Enter DecimalValues Only");
                }
            }
            function AlphaNumericOnly() {
                var AsciiValue = event.keyCode
                if ((AsciiValue >= 65 && AsciiValue <= 90) || (AsciiValue >= 97 && AsciiValue <= 122) || (AsciiValue >= 48 && AsciiValue <= 57))
                    event.returnValue = true;
                else {
                    event.returnValue = false;

                    alert("Enter Alphabets,  and Characters  Only");
                }
            }

    </script>

    <style type="text/css">
        .overlay {
            position: fixed;
            z-index: 999;
            height: 31%;
            width: 67%;
            top: -112px;
            background-color: Gray;
            filter: alpha(opacity=60);
            opacity: 0.9;
            -moz-opacity: 0.9;
            left: 386px;
        }

        .style5 {
            width: 300px;
        }
    </style>
    <script type="text/javascript" language="javascript">

        function OpenPopup() {

            window.open("Lookups/LookupTSiPASSReport4.aspx", "List", "scrollbars=yes,resizable=yes,width=1000,height=650;display = block;position=absolute");

        }

    </script>

    <script type="text/javascript">
        function inputOnlyNumbers(evt) {
            var charCode = (evt.which) ? evt.which : evt.keyCode;
            if (charCode > 31 && (charCode < 48 || charCode > 57))
                return false;
            return true;
        }
        function inputOnlyDecimals(evt) {
            var charCode = (evt.which) ? evt.which : evt.keyCode;
            if (charCode > 31 && (charCode < 46 || charCode > 57) || charCode == 47)
                return false;
            return true;
        }
    </script>
     <script type="text/javascript">
         function showProgress() {
             var updateProgress = $get("<%= UpdateProgress.ClientID %>");
             updateProgress.style.display = "block";
         }
    </script>
     <asp:UpdatePanel ID="upd1" runat="server">
        <ContentTemplate>
    <div align="left">
        <div class="row" align="left">
            <div class="panel panel-primary">
                <div class="panel-heading" align="center" style="text-align: center">
                    <h3 class="panel-title" style="text-align: center">Telangana State Industrial Development and Entrepreneur Advancement - G.O M.S. NO 28, Industries &amp; Commerce (IP &amp; INF) Department,<br />
                        Dated : 29/11/2014<br />
                        Sanction of Palla vaddi - Appraisal Note
                    </h3>
                </div>
                <div class="panel-body">
                    <table align="center" cellpadding="10" cellspacing="5" style="width: 90%">
                        <tr>
                            <td style="padding: 5px; margin: 5px" valign="top">
                                <table cellpadding="4" cellspacing="5" style="width: 83%">
                                      <asp:HiddenField ID="lblAllwomen" runat="server" />
                                    <tr>
                                        <td style="width: 250px;">
                                            <b>Enter Incentive Application no</b><font
                                                color="red">*</font>
                                        </td>
                                        <td style="padding: 5px; margin: 5px">
                                            <asp:TextBox ID="txtINCNoEntry" runat="server" class="form-control txtbox" Height="28px" 
                                                TabIndex="2" ValidationGroup="group" Width="180px"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server" ControlToValidate="txtINCNoEntry"
                                                ErrorMessage="Please Enter Incentive Application no" Display="Dynamic" ValidationGroup="group"></asp:RequiredFieldValidator>
                                            <asp:Button ID="btnINCSearch" CssClass="btn btn-xs btn-warning" runat="server" Text="Search" OnClick="btnINCSearch_Click" Height="30px" />

                                        </td>
                                        <td style="width: 250px;">Print Application no<font
                                            color="red">*</font>
                                        </td>
                                        <td style="padding: 5px; margin: 5px">
                                            <asp:TextBox ID="txtPrintINCID" runat="server" Visible="false" class="form-control txtbox" Height="28px"  
                                                TabIndex="2" ValidationGroup="group" Width="180px"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" ControlToValidate="txtPrintINCID"
                                                ErrorMessage="Please Print Application no" Display="Dynamic" ValidationGroup="group"></asp:RequiredFieldValidator>
                                            <asp:Button ID="btnPrint" runat="server" CssClass="btn btn-xs btn-warning" Height="30px" OnClick="btnPrint_Click" Text="Print" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 250px;"></td>
                                        <td style="padding: 5px; margin: 5px"></td>
                                          <td style="padding: 5px; margin: 5px"></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 200px;">1.Application no<font
                                            color="red">*</font>
                                        </td>
                                        <td style="padding: 5px; margin: 5px">
                                            <asp:Label ID="lblApplicationno" class="form-control txtbox" Height="28px" Width="180px" runat="server" TabIndex="1"></asp:Label>
                                        </td>
                                        <td style="width: 200px;">2.Name of Industrial Concern<font
                                            color="red">*</font>
                                        </td>
                                        <td style="padding: 5px; margin: 5px">
                                            <asp:TextBox ID="txtunitnames" runat="server" class="form-control txtbox" Height="28px" 
                                                TabIndex="2" ValidationGroup="group" Width="180px"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtunitnames"
                                                ErrorMessage="Please Enter Name of Industrial Concern" Display="Dynamic" ValidationGroup="group"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="padding: 5px; margin: 5px"></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 200px;">3.Location of the Industrial concern<font
                                            color="red">*</font>
                                        </td>
                                        <td style="padding: 5px; margin: 5px">
                                            <asp:TextBox ID="txtLocofUnit" runat="server" class="form-control txtbox" Height="28px"  TextMode="MultiLine"
                                                TabIndex="2" ValidationGroup="group" Width="180px"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator17" runat="server" ControlToValidate="txtLocofUnit"
                                                ErrorMessage="Please Enter Location of the Industrial concern" Display="Dynamic" ValidationGroup="group"></asp:RequiredFieldValidator>
                                        </td>
                                        <td style="padding: 5px; margin: 5px"></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 200px;">4.Constitution of the Industrial Concern<font
                                            color="red">*</font>
                                        </td>
                                        <td style="padding: 5px; margin: 5px">
                                            <asp:DropDownList ID="ddlOrddlorgtypes" runat="server"  class="form-control txtbox"
                                                Height="33px" TabIndex="3" Visible="true" Width="180px">
                                                <asp:ListItem Value="0">--Select--</asp:ListItem>
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator18" runat="server" ControlToValidate="ddlOrddlorgtypes"
                                                ErrorMessage="Please select  Constitution of the Industrial Concern" Display="Dynamic" ValidationGroup="group" InitialValue="0"></asp:RequiredFieldValidator>
                                        </td>
                                       <td style="width: 200px;">5.Whether the SSI Prov. regn. or any other regn/ approval in terms of IEM, ackngmnt LI/IL etc., has the continuity in validity of commercial production.<span style="font-weight: bold; color: Red;">*</span>
                                        </td>
                                        <td style="padding: 5px; margin: 5px">
                                            <asp:DropDownList ID="ddlUdyogAadharType" runat="server"  class="form-control txtbox"
                                                Height="33px" TabIndex="3" Visible="true" Width="180px">
                                                <asp:ListItem Value="0">--Select--</asp:ListItem>
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator19" runat="server" ControlToValidate="ddlUdyogAadharType"
                                                ErrorMessage="Please select  Whether the SSI Prov. regn. or any other regn/ approval in terms of IEM, ackngmnt LI/IL" Display="Dynamic" ValidationGroup="group" InitialValue="0"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="padding: 5px; margin: 5px"></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 200px;">6.PMT/SSI/IEM acknowledgement, LI/IL No &amp; Dt:<font
                                            color="red">*</font>
                                        </td>
                                        <td style="padding: 5px; margin: 5px">
                                            <asp:TextBox ID="txtPersonIndustry" runat="server" class="form-control txtbox" Height="28px"
                                                TabIndex="10" ValidationGroup="group" Width="180px"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator20" runat="server" ControlToValidate="txtPersonIndustry"
                                                ErrorMessage="Please Enter PMT/SSI/IEM acknowledgement, LI/IL No &Dt" Display="Dynamic" ValidationGroup="group"></asp:RequiredFieldValidator>
                                        </td>
                                       <td style="width: 200px;">SCHEME<span style="font-weight: bold; color: Red;">*</span>
                                        </td>
                                        <td style="padding: 5px; margin: 5px">
                                            <asp:Label ID="lbl_schemetide" class="form-control txtbox"   runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 300px;"><b>7.PRODUCTS MANUFACTURED</b>
                                        </td>
                                    </tr>
                                    <tr>
                                         <td style="width: 200px;">Line of Acitvity<span style="font-weight: bold; color: Red;">*</span>
                                               <asp:TextBox ID="txtLOActivity" runat="server" class="form-control txtbox" Height="28px"
                                                TabIndex="10" ValidationGroup="group" Width="180px"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator21" runat="server" ControlToValidate="txtLOActivity"
                                                ErrorMessage="Please Enter Line of Acitvity" Display="Dynamic" ValidationGroup="group1"></asp:RequiredFieldValidator>
                                       <br />
                                             </td>
                                         <td style="width: 200px;">Installed Capacity<span style="font-weight: bold; color: Red;">*</span>
                                             <asp:TextBox ID="txtinstalledccap" runat="server" class="form-control txtbox" Height="28px"
                                                TabIndex="10" ValidationGroup="group" Width="180px"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator22" runat="server" ControlToValidate="txtinstalledccap"
                                                ErrorMessage="Please Enter Installed Capacity" Display="Dynamic" ValidationGroup="group1"></asp:RequiredFieldValidator>
                                         <br />
                                             </td>
                                        <td style="width: 200px;">Units<span style="font-weight: bold; color: Red;">*</span>
                                              <asp:DropDownList ID="ddlquantityin" runat="server" class="form-control txtbox" AutoPostBack="true" OnSelectedIndexChanged="ddlquantityin_SelectedIndexChanged"
                                                Height="33px" TabIndex="3" Visible="true" Width="180px">
                                                <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                <asp:ListItem Value="KG">KG</asp:ListItem>
                                                <asp:ListItem Value="Tone">Tonnes</asp:ListItem>
                                                <asp:ListItem Value="Liters">Litres</asp:ListItem>
                                                <asp:ListItem Value="Others">Others</asp:ListItem>
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator251" runat="server" ControlToValidate="ddlquantityin"
                                                ErrorMessage="Please select  Units" Display="Dynamic" ValidationGroup="group1" InitialValue="0"></asp:RequiredFieldValidator>

                                            <asp:TextBox ID="txtunit" runat="server" class="form-control txtbox" Height="28px" Visible="false"
                                                TabIndex="10" ValidationGroup="group" Width="180px"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator23" runat="server" ControlToValidate="txtunit"
                                                ErrorMessage="Please Enter Units others" Display="Dynamic" ValidationGroup="group1"></asp:RequiredFieldValidator>
                                     <br />
                                        </td>
                                        <td style="width: 200px;">Value in Rs.<span style="font-weight: bold; color: Red;">*</span>
                                            <asp:TextBox ID="txtvalue" runat="server" class="form-control txtbox" Height="28px"
                                                TabIndex="10" ValidationGroup="group" Width="180px"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator24" runat="server" ControlToValidate="txtvalue"
                                                ErrorMessage="Please Enter Value in Rs." Display="Dynamic" ValidationGroup="group1"></asp:RequiredFieldValidator>
                                         <br />
                                        </td>
                                         <td  style="width: 200px;">

                                            <asp:Button ID="btnInstalledcap" runat="server" CssClass="btn btn-xs btn-warning" OnClick="btnInstalledcap_Click" ValidationGroup="group1"
                                                Height="28px" TabIndex="5" Text="Add" Width="72px" />
                                            &nbsp; &nbsp; &nbsp;
                                                       <asp:Button ID="btn_cancelproductactivity" runat="server" CausesValidation="False" CssClass="btn btn-xs btn-danger"
                                                           Height="28px" TabIndex="5" Text="Cancel" ToolTip="To Clear  the Screen" Width="73px" OnClick="btn_cancelproductactivity_Click" />

                                        </td>
                                         </tr>
                                    <tr>
                                        <td></td>
                                        <td colspan="4">
                                            <asp:GridView ID="gvInstalledCap" runat="server" AutoGenerateColumns="False"
                                                BorderColor="#003399" BorderStyle="Solid" BorderWidth="1px" CellPadding="4"
                                                CssClass="GRD" ForeColor="#333333" GridLines="Both" Visible="false" OnRowDeleting="gvInstalledCap_RowDeleting" Width="90%">
                                                <RowStyle BackColor="#ffffff"  />
                                                <Columns>
                                                    <asp:TemplateField HeaderText="Sl.No">
                                                        <ItemTemplate>
                                                            <asp:Label ID="Slno" runat="server" Text="<%# Container.DataItemIndex + 1 %>"></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="Column1" HeaderText="Line Of Activity" />
                                                    <asp:BoundField DataField="Column3" HeaderText="Installed Capacity" />
                                                    <asp:BoundField DataField="Column2" HeaderText="Unit" />
                                                    <asp:BoundField DataField="Column4" HeaderText="Value (in Rs.)" />
                                                    <asp:BoundField DataField="Created_by" HeaderText="Created By" Visible="false" />
                                                    <asp:BoundField DataField="IncentiveId" HeaderText="Incentive Id" Visible="false" />
                                                    <asp:CommandField HeaderText="Delete" ShowDeleteButton="True" />
                                                    <asp:CommandField HeaderText="Edit" ShowSelectButton="True" Visible="False" />
                                                </Columns>
                                                <HeaderStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                                <PagerStyle BackColor="#013161" ForeColor="White" HorizontalAlign="Center" />
                                                <AlternatingRowStyle BackColor="#D5E6F9" ForeColor="#284775" />
                                                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" Font-Names="Arial" Font-Size="12px"
                                                    HorizontalAlign="Center" />
                                                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                                <FooterStyle HorizontalAlign="Center" BackColor="#5D7B9D" Font-Bold="True" ForeColor="White"
                                                    Font-Names="Arial" Font-Size="9px" />
                                            </asp:GridView>
                                        </td>


                                    </tr>
                                    <tr>
                                        <td style="width: 200px;"><b>INITIAL STEPS TAKEN FOR IMPLEMENTATION</b>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 200px;">8.Date of filing of application with the lead financial Institution for term loan/Date of openings of first Public issue is financed through public issues. <span style="font-weight: bold; color: Red;">*</span>
                                        </td>
                                        <td style="padding: 5px; margin: 5px">
                                            <asp:TextBox ID="txtDateOfapplnFile" runat="server" class="form-control txtbox" Height="40px"
                                                TabIndex="6" ValidationGroup="group" Width="180px"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator26" runat="server" ControlToValidate="txtDateOfapplnFile"
                                                ErrorMessage="Please Enter Date of filing of application with the lead financial Institution for term loan/Date of openings of first Public issue is financed through public issues." Display="Dynamic" ValidationGroup="group"></asp:RequiredFieldValidator>
                                        </td>
                                        <td style="padding: 5px; margin: 5px"></td>
                                    </tr>
                                    <tr>
                                        <td style="padding: 5px; margin: 5px; text-align: left;" class="style5">9.In case term loan obtained from the Financial Institution/Bank Term loan sanction letter No. and date.<font
                                            color="red">*</font>
                                        </td>
                                        <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                            <asp:TextBox ID="txtLoanApplnNo" runat="server" class="form-control txtbox" Height="40px"
                                                TabIndex="6" ValidationGroup="group" Width="180px"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator27" runat="server" ControlToValidate="txtLoanApplnNo"
                                                ErrorMessage="Please Enter In case term loan obtained from the Financial Institution/Bank Term loan sanction letter No. and date." Display="Dynamic" ValidationGroup="group"></asp:RequiredFieldValidator>
                                            <br />
                                            <asp:TextBox ID="txtDate_Loan" runat="server" class="form-control txtbox" Height="40px"
                                                TabIndex="6" ValidationGroup="group" Width="180px"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator28" runat="server" ControlToValidate="txtDate_Loan"
                                                ErrorMessage="Please Enter In case term loan obtained from the Financial Institution/Bank Term loan sanction date." Display="Dynamic" ValidationGroup="group"></asp:RequiredFieldValidator>
                                        </td>
                                        <td style="padding: 5px; margin: 5px; width: 10px;"></td>
                                    </tr>
                                    <tr>
                                        <td style="padding: 5px; margin: 5px; text-align: left;" class="style5">10.Name of the Financing Institution. Lead Instn. in case of Joint finance.<font
                                            color="red">*</font>
                                        </td>
                                        <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                            <asp:TextBox ID="txtNameofFinIns" runat="server" class="form-control txtbox" Height="40px"
                                                TabIndex="6" ValidationGroup="group" Width="180px"></asp:TextBox>
                                           <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator31" runat="server" ControlToValidate="txtNameofFinIns"
                                                ErrorMessage="Please Enter Name of the Financing Institution. Lead Instn. in case of Joint finance" Display="Dynamic" ValidationGroup="group"></asp:RequiredFieldValidator>
--%>
                                        </td>
                                        <td style="padding: 5px; margin: 5px; width: 10px;"></td>
                                    </tr>
                                    <tr>
                                        <td style="padding: 5px; margin: 5px; text-align: left;" class="style5">11.Date of Power connection with connected load<font
                                            color="red">*</font>
                                        </td>
                                        <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                            <asp:TextBox ID="txtPowerConn_date" runat="server" class="form-control txtbox" Height="40px"
                                                TabIndex="6" ValidationGroup="group" Width="180px"></asp:TextBox>
                                          <%--  <asp:RequiredFieldValidator ID="RequiredFieldValidator29" runat="server" ControlToValidate="txtPowerConn_date"
                                                ErrorMessage="Please Enter Date of Power connection with connected load Date" Display="Dynamic" ValidationGroup="group"></asp:RequiredFieldValidator>--%>
                                            <br />
                                            <asp:TextBox ID="txtPowerConn_load" runat="server" class="form-control txtbox" Height="40px"
                                                TabIndex="6" ValidationGroup="group" Width="180px"></asp:TextBox>
                                      <%--      <asp:RequiredFieldValidator ID="RequiredFieldValidator30" runat="server" ControlToValidate="txtPowerConn_load"
                                                ErrorMessage="Please Enter Date of Power connection with connected load" Display="Dynamic" ValidationGroup="group"></asp:RequiredFieldValidator>--%>
                                        </td>
                                        <td style="padding: 5px; margin: 5px; width: 10px;"></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 200px;">12. Date of Commencement of Commercial production<font
                                            color="red">*</font>
                                        </td>
                                        <td style="padding: 5px; margin: 5px">
                                            <asp:TextBox ID="txtDCP_unit" runat="server" class="form-control txtbox" Height="28px"
                                                TabIndex="10" ValidationGroup="group" Width="180px"></asp:TextBox>
                                           <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator32" runat="server" ControlToValidate="txtDCP_unit"
                                                ErrorMessage="Please Enter Date of Commencement of Commercial production" Display="Dynamic" ValidationGroup="group"></asp:RequiredFieldValidator>--%>
                                        </td>
                                        <td style="padding: 5px; margin: 5px"></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 200px;"><b>13.DIC</b>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 200px;">a) Date of receipt of claim application(in DIC)<font
                                            color="red">*</font>
                                        </td>
                                        <td style="padding: 5px; margin: 5px">
                                            <asp:TextBox ID="txtrc_dic" runat="server" class="form-control txtbox" Height="28px"
                                                TabIndex="10" ValidationGroup="group" Width="180px"></asp:TextBox>
                                        <%--    <asp:RequiredFieldValidator ID="RequiredFieldValidator33" runat="server" ControlToValidate="txtrc_dic"
                                                ErrorMessage="Please Enter Date of receipt of claim application(in DIC)" Display="Dynamic" ValidationGroup="group"></asp:RequiredFieldValidator>--%>
                                        </td>
                                         <td style="width: 200px;">b) Date of communication of shortfalls to the party(in DIC)<font
                                            color="red">*</font>
                                        </td>
                                        <td style="padding: 5px; margin: 5px">
                                            <asp:TextBox ID="txtquery_dic" runat="server" class="form-control txtbox" Height="28px"
                                                TabIndex="10" ValidationGroup="group" Width="180px"></asp:TextBox>
                                           <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator34" runat="server" ControlToValidate="txtquery_dic"
                                                ErrorMessage="Please Enter Date of communication of shortfalls to the party(in DIC)" Display="Dynamic" ValidationGroup="group"></asp:RequiredFieldValidator>--%>
                                        </td>
                                    </tr>
                                    <tr>
                                       
                                        <td style="padding: 5px; margin: 5px"></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 200px;">C) Date of receipt of complete information from the party(in DIC)<font
                                            color="red">*</font>
                                        </td>
                                        <td style="padding: 5px; margin: 5px">
                                            <asp:TextBox ID="txtcompdate_dic" runat="server" class="form-control txtbox" Height="28px"
                                                TabIndex="10" ValidationGroup="group" Width="180px"></asp:TextBox>
                                          <%--  <asp:RequiredFieldValidator ID="RequiredFieldValidator35" runat="server" ControlToValidate="txtcompdate_dic"
                                                ErrorMessage="Please Enter Date of receipt of complete information from the party(in DIC)" Display="Dynamic" ValidationGroup="group"></asp:RequiredFieldValidator>--%>
                                        </td>
                                        <td style="padding: 5px; margin: 5px"></td>
                                    </tr>

                                    <tr>
                                        <td style="width: 200px;"><b>14.COI</b>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 200px;">a) Date of receipt of claim application(in COI)<font
                                            color="red">*</font>
                                        </td>
                                        <td style="padding: 5px; margin: 5px">
                                            <asp:TextBox ID="txtcompdate_coi" runat="server" class="form-control txtbox" Height="28px"
                                                TabIndex="10" ValidationGroup="group" Width="180px"></asp:TextBox>
                                          <%--  <asp:RequiredFieldValidator ID="RequiredFieldValidator36" runat="server" ControlToValidate="txtcompdate_coi"
                                                ErrorMessage="Please Enter Date of receipt of claim application(in COI)" Display="Dynamic" ValidationGroup="group"></asp:RequiredFieldValidator>--%>
                                        </td>
                                         <td style="width: 200px;">b) Date of communication of shortfalls to the party(in COI)<font
                                            color="red">*</font>
                                        </td>
                                        <td style="padding: 5px; margin: 5px">
                                            <asp:TextBox ID="txtquery_coi" runat="server" class="form-control txtbox" Height="28px"
                                                TabIndex="10" ValidationGroup="group" Width="180px"></asp:TextBox>
                                           <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator37" runat="server" ControlToValidate="txtquery_coi"
                                                ErrorMessage="Please Enter Date of communication of shortfalls to the party(in COI)" Display="Dynamic" ValidationGroup="group"></asp:RequiredFieldValidator>--%>
                                        </td>
                                    </tr>
                                    <tr>
                                      
                                        <td style="padding: 5px; margin: 5px"></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 200px;">c) Date of receipt of complete information from the party<font
                                            color="red">*</font>
                                        </td>
                                        <td style="padding: 5px; margin: 5px">
                                            <asp:TextBox ID="txtcompdate_coi1" runat="server" class="form-control txtbox" Height="28px"
                                                TabIndex="10" ValidationGroup="group" Width="180px"></asp:TextBox>
                                           <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator38" runat="server" ControlToValidate="txtcompdate_coi1"
                                                ErrorMessage="Please Enter Date of receipt of complete information from the party" Display="Dynamic" ValidationGroup="group"></asp:RequiredFieldValidator>--%>
                                        </td>
                                        <td style="padding: 5px; margin: 5px"></td>
                                    </tr>
                                    <tr>

                                        <td colspan="5">
                                            <table id="tbl_212approvedcostmeanoffinance" runat="server" style="width: 100%">
                                                <tr>
                                                    <td colspan="4">
                                                        <b>15. Approved Project Cost As Per Guidelines (Rs. in Lakhs)
                                                        </b>

                                                    </td>
                                                    <td></td>
                                                    <td></td>
                                                    <td colspan="4">
                                                        <b>Means of finance(Rs in Lakhs) 
                                                        </b>

                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="auto-style58"></td>
                                                    <td class="auto-style58">a. Land 
                                                    </td>
                                                    <td class="auto-style58"></td>
                                                    <td class="auto-style58">
                                                        <asp:TextBox ID="TextBox60" onkeypress="DecimalOnly()" Text="0" runat="server" class="form-control txtbox" Height="28px" MaxLength="100" TabIndex="6" Width="150px"></asp:TextBox>
                                                    </td>
                                                    <td class="auto-style58"></td>
                                                    <td class="auto-style58"></td>
                                                    <td class="auto-style58">1. Own share capital</td>
                                                    <td class="auto-style58"></td>
                                                    <td class="auto-style58">
                                                        <asp:TextBox ID="TextBox61" runat="server" Text="0" class="form-control txtbox" Height="28px" MaxLength="100" onkeypress="DecimalOnly()" TabIndex="6" Width="150px"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="auto-style59"></td>
                                                    <td class="auto-style59">b. Building 
                                                    </td>
                                                    <td class="auto-style59"></td>
                                                    <td class="auto-style59">
                                                        <asp:TextBox ID="TextBox5" runat="server" onkeypress="DecimalOnly()" Text="0" class="form-control txtbox" Height="28px" MaxLength="100" TabIndex="6" Width="150px"></asp:TextBox>
                                                    </td>
                                                    <td class="auto-style59"></td>
                                                    <td class="auto-style59"></td>
                                                    <td class="auto-style59">2. State Subsidy </td>
                                                    <td class="auto-style59"></td>
                                                    <td class="auto-style59">
                                                        <asp:TextBox ID="TextBox6" Text="0" runat="server" class="form-control txtbox" onkeypress="DecimalOnly()" Height="28px" MaxLength="100" TabIndex="6" Width="150px"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="auto-style59"></td>
                                                    <td class="auto-style59">c. Plant &amp; M/C 
                                                    </td>
                                                    <td class="auto-style59"></td>
                                                    <td class="auto-style59">
                                                        <asp:TextBox ID="TextBox7" runat="server" onkeypress="DecimalOnly()" class="form-control txtbox" Height="28px" MaxLength="100" TabIndex="6" Width="150px"></asp:TextBox>
                                                    </td>
                                                    <td class="auto-style59"></td>
                                                    <td class="auto-style59"></td>
                                                    <td class="auto-style59">3. Funds through public issues </td>
                                                    <td class="auto-style59"></td>
                                                    <td class="auto-style59">
                                                        <asp:TextBox ID="TextBox8" runat="server" Text="0" class="form-control txtbox" onkeypress="DecimalOnly()" Height="28px" MaxLength="100" TabIndex="6" Width="150px"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="auto-style60"></td>
                                                    <td class="auto-style60">d. Preliminery/Preoperative expenditure 
                                                    </td>
                                                    <td class="auto-style60"></td>
                                                    <td class="auto-style60">
                                                        <asp:TextBox ID="TextBox9" runat="server" onkeypress="DecimalOnly()" Text="0" class="form-control txtbox" Height="28px" MaxLength="100" TabIndex="6" Width="150px"></asp:TextBox>
                                                    </td>
                                                    <td class="auto-style60"></td>
                                                    <td class="auto-style60"></td>
                                                    <td class="auto-style60">4. Soft,loan/capital </td>
                                                    <td class="auto-style60"></td>
                                                    <td class="auto-style60">
                                                        <asp:TextBox ID="TextBox10" runat="server" Text="0" class="form-control txtbox" Height="28px" MaxLength="100" onkeypress="DecimalOnly()" TabIndex="6" Width="150px"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td></td>
                                                    <td>e. (i). Tech-know how feasibility study
                            <br />
                                                        and turn key charges 
                                                    </td>
                                                    <td></td>
                                                    <td>
                                                        <asp:TextBox ID="TextBox11" runat="server" onkeypress="DecimalOnly()" Text="0" class="form-control txtbox" Height="28px" MaxLength="100" TabIndex="6" Width="150px"></asp:TextBox>
                                                    </td>
                                                    <td></td>
                                                    <td></td>
                                                    <td>5. Term loan </td>
                                                    <td></td>
                                                    <td>
                                                        <asp:TextBox ID="TextBox12" runat="server" class="form-control txtbox" Height="28px" onkeypress="DecimalOnly()" MaxLength="100" TabIndex="6" Width="150px"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="auto-style54"></td>
                                                    <td class="auto-style54">(ii). Vehicles </td>
                                                    <td class="auto-style54"></td>
                                                    <td class="auto-style54">
                                                        <asp:TextBox ID="TextBox13" runat="server" Text="0" onkeypress="DecimalOnly()" class="form-control txtbox" Height="28px" MaxLength="100" TabIndex="6" Width="150px"></asp:TextBox>
                                                    </td>
                                                    <td class="auto-style54"></td>
                                                    <td class="auto-style54"></td>
                                                    <td class="auto-style54">6. Unsecured loans </td>
                                                    <td class="auto-style54"></td>
                                                    <td class="auto-style54">
                                                        <asp:TextBox ID="TextBox14" runat="server" Text="0" class="form-control txtbox" Height="28px" MaxLength="100" onkeypress="DecimalOnly()" TabIndex="6" Width="150px"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="auto-style61"></td>
                                                    <td class="auto-style61">(iii). Others </td>
                                                    <td class="auto-style61"></td>
                                                    <td class="auto-style61">
                                                        <asp:TextBox ID="TextBox15" runat="server" Text="0" onkeypress="DecimalOnly()" class="form-control txtbox" Height="28px" MaxLength="100" TabIndex="6" Width="150px"></asp:TextBox>
                                                    </td>
                                                    <td class="auto-style61"></td>
                                                    <td class="auto-style61"></td>
                                                    <td class="auto-style61">7. Working capital loan&nbsp; </td>
                                                    <td class="auto-style61"></td>
                                                    <td class="auto-style61">
                                                        <asp:TextBox ID="TextBox16" runat="server" Text="0" class="form-control txtbox" Height="28px" MaxLength="100" onkeypress="DecimalOnly()" TabIndex="6" Width="150px"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="auto-style62"></td>
                                                    <td class="auto-style62">f. Others </td>
                                                    <td class="auto-style62"></td>
                                                    <td class="auto-style62">
                                                        <asp:TextBox ID="TextBox17" runat="server" Text="0" onkeypress="DecimalOnly()" class="form-control txtbox" Height="28px" MaxLength="100" TabIndex="6" Width="150px"></asp:TextBox>
                                                    </td>

                                                </tr>
                                                <tr>
                                                    <td class="auto-style58"></td>
                                                    <td class="auto-style58">g. Working Capital </td>
                                                    <td class="auto-style58"></td>
                                                    <td class="auto-style58">
                                                        <asp:TextBox ID="TextBox18" runat="server" Text="0" onkeypress="DecimalOnly()" class="form-control txtbox" Height="28px" MaxLength="100" TabIndex="6" Width="150px"></asp:TextBox>
                                                    </td>

                                                </tr>
                                                <tr>
                                                    <td></td>
                                                    <td><b>Total: Rs.</b> </td>
                                                    <td></td>
                                                    <td>
                                                        <asp:TextBox ID="TextBox19" runat="server" onkeypress="DecimalOnly()" class="form-control txtbox" Height="28px" MaxLength="100" TabIndex="6" Width="150px"></asp:TextBox>
                                                    </td>
                                                    <td></td>
                                                    <td></td>
                                                    <td><b>Total: Rs.</b> </td>
                                                    <td></td>
                                                    <td>
                                                        <asp:TextBox ID="TextBox20" runat="server" class="form-control txtbox" Height="28px" MaxLength="100" onkeypress="DecimalOnly()" TabIndex="6" Width="150px"></asp:TextBox>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>

                                        <td colspan="5">
                                            <table style="width: 100%; font-weight: bold;">
                                                <tr>
                                                    <td colspan="5">
                                                        <b>16. Details of Investment on fixed Capital assets as on:</b>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="center" style="border: solid thin white; background: #013161; color: white">&nbsp;&nbsp;&nbsp;Name of Asset&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                    </td>
                                                    <td align="center" style="border: solid thin white; background: #013161; color: white">Project Cost as Approved<br />
                                                        (In Rs.)
                                                    </td>
                                                    <td align="center" style="border: solid thin white; background: #013161; color: white">Loan Sanctioned
                                                                                            <br />
                                                        (In Rs.)
                                                    </td>
                                                    <td align="center" style="border: solid thin white; background: #013161; color: white">Loan Disbursed<br />
                                                        (In Rs.)
                                                    </td>
                                                    <td align="center" style="border: solid thin white; background: #013161; color: white">Assets Certified by<br />
                                                        Banks/ Fin Instn. as on<br />
                                                        (in Rs.)</td>
                                                    <td align="center" style="border: solid thin white; background: #013161; color: white">Assets expr incurred<br />
                                                        as per C.A (In Rs.)</td>
                                                    <td align="center" style="border: solid thin white; background: #013161; color: white">Value Recommended<br />
                                                        by G.M (In Rs.)</td>
                                                </tr>
                                                <tr>
                                                    <td align="center" style="border: solid thin white; background: #013161; color: white">1
                                                    </td>
                                                    <td align="center" style="border: solid thin white; background: #013161; color: white">2&nbsp;
                                                    </td>
                                                    <td align="center" style="border: solid thin white; background: #013161; color: white">3
                                                    </td>
                                                    <td align="center" style="border: solid thin white; background: #013161; color: white">4
                                                    </td>
                                                    <td align="center" style="border: solid thin white; background: #013161; color: white">5
                                                    </td>
                                                    <td align="center" style="border: solid thin white; background: #013161; color: white">6
                                                    </td>
                                                    <td align="center" style="border: solid thin white; background: #013161; color: white">7
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="border: solid thin black; background: white; color: black">a. Land-Purchased</td>
                                                    <td style="padding-top: 5px; border: solid thin black; background: white; color: black;">
                                                        <asp:TextBox ID="txtLand2" runat="server" class="form-control txtbox" Height="28px"
                                                            TabIndex="5" onkeypress="DecimalOnly()"></asp:TextBox>
                                                    </td>
                                                    <td style="padding-top: 5px; border: solid thin black; background: white; color: black">
                                                        <asp:TextBox ID="txtLand3" runat="server" class="form-control txtbox" Height="28px"
                                                            TabIndex="5" onkeypress="DecimalOnly()"></asp:TextBox>
                                                    </td>
                                                    <td style="padding-top: 5px; border: solid thin black; background: white; color: black">
                                                        <asp:TextBox ID="txtLand4" runat="server" class="form-control txtbox" Height="28px"
                                                            MaxLength="40" onkeypress="DecimalOnly()" TabIndex="5"></asp:TextBox>
                                                    </td>
                                                    <td style="padding-top: 5px; border: solid thin black; background: white; color: black">
                                                        <asp:TextBox ID="txtLand5" runat="server" class="form-control txtbox" Height="28px"
                                                            MaxLength="40" onkeypress="DecimalOnly()" TabIndex="5"></asp:TextBox>
                                                    </td>
                                                    <td style="padding-top: 5px; border: solid thin black; background: white; color: black">
                                                        <asp:TextBox ID="txtLand6" runat="server" class="form-control txtbox" Height="28px"
                                                            MaxLength="40" onkeypress="DecimalOnly()" TabIndex="5"></asp:TextBox>
                                                    </td>
                                                    <td style="padding-top: 5px; border: solid thin black; background: white; color: black">
                                                        <asp:TextBox ID="txtLand7" runat="server" class="form-control txtbox" Height="28px"
                                                            AutoPostBack="false" onkeypress="DecimalOnly()" MaxLength="40" TabIndex="5"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="border: solid thin black; background: white; color: black">b. Building-Constructed
                                                    </td>
                                                    <td style="border: solid thin black; background: white; color: black">
                                                        <asp:TextBox ID="txtBuilding2" runat="server" class="form-control txtbox" Height="28px"
                                                            MaxLength="40" onkeypress="DecimalOnly()" TabIndex="5"></asp:TextBox>
                                                    </td>
                                                    <td style="border: solid thin black; background: white; color: black">
                                                        <asp:TextBox ID="txtBuilding3" runat="server" class="form-control txtbox" Height="28px"
                                                            MaxLength="40" onkeypress="DecimalOnly()" TabIndex="5"></asp:TextBox>
                                                    </td>
                                                    <td style="border: solid thin black; background: white; color: black">
                                                        <asp:TextBox ID="txtBuilding4" runat="server" class="form-control txtbox" Height="28px"
                                                            MaxLength="40" onkeypress="DecimalOnly()" TabIndex="5"></asp:TextBox>
                                                    </td>
                                                    <td style="border: solid thin black; background: white; color: black">
                                                        <asp:TextBox ID="txtBuilding5" runat="server" class="form-control txtbox" Height="28px"
                                                            MaxLength="40" onkeypress="DecimalOnly()" TabIndex="5"></asp:TextBox>
                                                    </td>
                                                    <td style="border: solid thin black; background: white; color: black">
                                                        <asp:TextBox ID="txtBuilding6" runat="server" class="form-control txtbox" Height="28px"
                                                            MaxLength="40" onkeypress="DecimalOnly()" TabIndex="5"></asp:TextBox>
                                                    </td>
                                                    <td style="border: solid thin black; background: white; color: black">
                                                        <asp:TextBox ID="txtBuilding7" runat="server" class="form-control txtbox" Height="28px"
                                                            MaxLength="40" onkeypress="DecimalOnly()" TabIndex="5"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="border: solid thin black; background: white; color: black">c. Plant &amp; M/C</td>
                                                    <td style="border: solid thin black; background: white; color: black">
                                                        <asp:TextBox ID="txtPM2" runat="server" class="form-control txtbox" Height="28px"
                                                            MaxLength="40" onkeypress="DecimalOnly()" TabIndex="5"></asp:TextBox>
                                                    </td>
                                                    <td style="border: solid thin black; background: white; color: black">
                                                        <asp:TextBox ID="txtPM3" runat="server" class="form-control txtbox" Height="28px"
                                                            MaxLength="40" onkeypress="DecimalOnly()" TabIndex="5"></asp:TextBox>
                                                    </td>
                                                    <td style="border: solid thin black; background: white; color: black">
                                                        <asp:TextBox ID="txtPM4" runat="server" class="form-control txtbox" Height="28px"
                                                            MaxLength="40" onkeypress="DecimalOnly()" TabIndex="5"></asp:TextBox>
                                                    </td>
                                                    <td style="border: solid thin black; background: white; color: black">
                                                        <asp:TextBox ID="txtPM5" runat="server" class="form-control txtbox" Height="28px"
                                                            MaxLength="40" onkeypress="DecimalOnly()" TabIndex="5"></asp:TextBox>
                                                    </td>
                                                    <td style="border: solid thin black; background: white; color: black">
                                                        <asp:TextBox ID="txtPM6" runat="server" class="form-control txtbox" Height="28px"
                                                            MaxLength="40" onkeypress="DecimalOnly()" TabIndex="5"></asp:TextBox>
                                                    </td>
                                                    <td style="border: solid thin black; background: white; color: black">
                                                        <asp:TextBox ID="txtPM7" runat="server" class="form-control txtbox" Height="28px"
                                                            MaxLength="40" onkeypress="DecimalOnly()" TabIndex="5"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="border: solid thin black; background: white; color: black">d.Tech.Knows -how feasibility<br />
                                                        study &amp; turn key charges</td>
                                                    <td style="border: solid thin black; background: white; color: black">
                                                        <asp:TextBox ID="txtMCont2" runat="server" class="form-control txtbox" Height="28px"
                                                            MaxLength="40" onkeypress="DecimalOnly()" TabIndex="5"></asp:TextBox>
                                                    </td>
                                                    <td style="border: solid thin black; background: white; color: black">
                                                        <asp:TextBox ID="txtMCont3" runat="server" class="form-control txtbox" Height="28px"
                                                            MaxLength="40" onkeypress="DecimalOnly()" TabIndex="5"></asp:TextBox>
                                                    </td>
                                                    <td style="border: solid thin black; background: white; color: black">
                                                        <asp:TextBox ID="txtMCont4" runat="server" class="form-control txtbox" Height="28px"
                                                            MaxLength="40" onkeypress="DecimalOnly()" TabIndex="5"></asp:TextBox>
                                                    </td>
                                                    <td style="border: solid thin black; background: white; color: black">
                                                        <asp:TextBox ID="txtMCont5" runat="server" class="form-control txtbox" Height="28px"
                                                            MaxLength="40" onkeypress="DecimalOnly()" TabIndex="5"></asp:TextBox>
                                                    </td>
                                                    <td style="border: solid thin black; background: white; color: black">
                                                        <asp:TextBox ID="txtMCont6" runat="server" class="form-control txtbox" Height="28px"
                                                            MaxLength="40" onkeypress="DecimalOnly()" TabIndex="5"></asp:TextBox>
                                                    </td>
                                                    <td style="border: solid thin black; background: white; color: black">
                                                        <asp:TextBox ID="txtMCont7" runat="server" class="form-control txtbox" Height="28px"
                                                            MaxLength="40" onkeypress="DecimalOnly()" TabIndex="5"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="border: solid thin black; background: white; color: black">e.Vechicles</td>
                                                    <td style="border: solid thin black; background: white; color: black">
                                                        <asp:TextBox ID="txtErec2" runat="server" class="form-control txtbox" Height="28px"
                                                            MaxLength="40" onkeypress="DecimalOnly()" TabIndex="5"></asp:TextBox>
                                                    </td>
                                                    <td style="border: solid thin black; background: white; color: black">
                                                        <asp:TextBox ID="txtErec3" runat="server" class="form-control txtbox" Height="28px"
                                                            MaxLength="40" onkeypress="DecimalOnly()" TabIndex="5"></asp:TextBox>
                                                    </td>
                                                    <td style="border: solid thin black; background: white; color: black">
                                                        <asp:TextBox ID="txtErec4" runat="server" class="form-control txtbox" Height="28px"
                                                            MaxLength="40" onkeypress="DecimalOnly()" TabIndex="5"></asp:TextBox>
                                                    </td>
                                                    <td style="border: solid thin black; background: white; color: black">
                                                        <asp:TextBox ID="txtErec5" runat="server" class="form-control txtbox" Height="28px"
                                                            MaxLength="40" onkeypress="DecimalOnly()" TabIndex="5"></asp:TextBox>
                                                    </td>
                                                    <td style="border: solid thin black; background: white; color: black">
                                                        <asp:TextBox ID="txtErec6" runat="server" class="form-control txtbox" Height="28px"
                                                            MaxLength="40" onkeypress="DecimalOnly()" TabIndex="5"></asp:TextBox>
                                                    </td>
                                                    <td style="border: solid thin black; background: white; color: black">
                                                        <asp:TextBox ID="txtErec7" runat="server" class="form-control txtbox" Height="28px"
                                                            MaxLength="40" onkeypress="DecimalOnly()" TabIndex="5"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="border: solid thin black; background: white; color: black">f.Other eligible</td>
                                                    <td style="border: solid thin black; background: white; color: black">
                                                        <asp:TextBox ID="txtTFS2" runat="server" class="form-control txtbox" Height="40px"
                                                            MaxLength="40" onkeypress="DecimalOnly()" TabIndex="5"></asp:TextBox>
                                                    </td>
                                                    <td style="border: solid thin black; background: white; color: black">
                                                        <asp:TextBox ID="txtTFS3" runat="server" class="form-control txtbox" Height="40px"
                                                            MaxLength="40" onkeypress="DecimalOnly()" TabIndex="5"></asp:TextBox>
                                                    </td>
                                                    <td style="border: solid thin black; background: white; color: black">
                                                        <asp:TextBox ID="txtTFS4" runat="server" class="form-control txtbox" Height="40px"
                                                            MaxLength="40" onkeypress="DecimalOnly()" TabIndex="5"></asp:TextBox>
                                                    </td>
                                                    <td style="border: solid thin black; background: white; color: black">
                                                        <asp:TextBox ID="txtTFS5" runat="server" class="form-control txtbox" Height="40px"
                                                            MaxLength="40" onkeypress="DecimalOnly()" TabIndex="5"></asp:TextBox>
                                                    </td>
                                                    <td style="border: solid thin black; background: white; color: black">
                                                        <asp:TextBox ID="txtTFS6" runat="server" class="form-control txtbox" Height="40px"
                                                            MaxLength="40" onkeypress="DecimalOnly()" TabIndex="5"></asp:TextBox>
                                                    </td>
                                                    <td style="border: solid thin black; background: white; color: black">
                                                        <asp:TextBox ID="txtTFS7" runat="server" class="form-control txtbox" Height="40px"
                                                            MaxLength="40" onkeypress="DecimalOnly()" TabIndex="5"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="border: solid thin black; background: white; color: black">Total</td>
                                                    <td style="border: solid thin black; background: white; color: black">
                                                        <asp:TextBox ID="txtWC2" runat="server" class="form-control txtbox" Height="28px"
                                                            MaxLength="40" onkeypress="DecimalOnly()" TabIndex="5"></asp:TextBox>
                                                    </td>
                                                    <td style="border: solid thin black; background: white; color: black">
                                                        <asp:TextBox ID="txtWC3" runat="server" class="form-control txtbox" Height="28px"
                                                            MaxLength="40" onkeypress="DecimalOnly()" TabIndex="5"></asp:TextBox>
                                                    </td>
                                                    <td style="border: solid thin black; background: white; color: black">
                                                        <asp:TextBox ID="txtWC4" runat="server" class="form-control txtbox" Height="28px"
                                                            MaxLength="40" onkeypress="DecimalOnly()" TabIndex="5"></asp:TextBox>
                                                    </td>
                                                    <td style="border: solid thin black; background: white; color: black">
                                                        <asp:TextBox ID="txtWC5" runat="server" class="form-control txtbox" Height="28px"
                                                            MaxLength="40" onkeypress="DecimalOnly()" TabIndex="5"></asp:TextBox>
                                                    </td>
                                                    <td style="border: solid thin black; background: white; color: black">
                                                        <asp:TextBox ID="txtWC6" runat="server" class="form-control txtbox" Height="28px"
                                                            MaxLength="40" onkeypress="DecimalOnly()" TabIndex="5"></asp:TextBox>
                                                    </td>
                                                    <td style="border: solid thin black; background: white; color: black">
                                                        <asp:TextBox ID="txtWC7" runat="server" class="form-control txtbox" Height="28px"
                                                            MaxLength="40" onkeypress="DecimalOnly()" TabIndex="5"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <%--<tr>
                                                                    <td style="border:solid thin black; background: white; color:black">Total</td>
                                                                    <td style="border:solid thin black; background: white; color:black">
                                                                        <asp:Label ID="lbltotal2" runat="server"></asp:Label></td>
                                                                    <td style="border:solid thin black; background: white; color:black">
                                                                        <asp:Label ID="lbltotal3" runat="server"></asp:Label></td>
                                                                    <td style="border:solid thin black; background: white; color:black">
                                                                        <asp:Label ID="lbltotal4" runat="server"></asp:Label></td>
                                                                    <td style="border:solid thin black; background: white; color:black">
                                                                        <asp:Label ID="lbltotal5" runat="server"></asp:Label></td>
                                                                    <td style="border:solid thin black; background: white; color:black">
                                                                        <asp:Label ID="lbltotal6" runat="server"></asp:Label></td>
                                                                    <td style="border:solid thin black; background: white; color:black">
                                                                        <asp:Label ID="lbltotal7" runat="server"></asp:Label></td>                                                                                    
                                                                </tr>--%>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="5">
                                            <table style="width: 100%">
                                                <tr style="height: 30px">
                                                    <td colspan="10" style="padding: 5px; margin: 5px; font-weight: bold; font-size: medium">&nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="padding: 5px; margin: 5px; font-weight: bold;" valign="top">
                                                        <b>17.</b>
                                                    </td>
                                                    <td colspan="4" style="padding: 5px; margin: 5px;">
                                                        <b>Computation of Capital Cost</b> </td>
                                                    <td>&nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="padding: 5px; margin: 5px; font-weight: bold;" valign="top">
                                                        <b>&nbsp;A.</b></td>
                                                    <td colspan="4" style="padding: 5px; margin: 5px;">
                                                        <b>LAND</b></td>
                                                    <td>
                                                        <b>B.</b></td>
                                                    <td colspan="3" style="padding: 5px; margin: 5px;">
                                                        <b>FACTORY BUILDINGS</b></td>
                                                </tr>
                                                <tr>
                                                    <td style="padding: 5px; margin: 5px;" valign="top" class="auto-style63">i)&nbsp;</td>
                                                    <td style="padding: 5px; margin: 5px;" class="auto-style64">As per approved project cost.</td>
                                                    <td style="margin: 5px;" class="auto-style59">:</td>
                                                    <td style="margin: 5px;" class="auto-style59">
                                                        <asp:TextBox ID="txtLandcostCompc" runat="server" class="form-control txtbox" onkeypress="DecimalOnly()" Height="28px" MaxLength="100" TabIndex="6" Width="150px"></asp:TextBox>
                                                    </td>
                                                    <td style="margin: 5px;" class="auto-style59">&nbsp;
                                                    </td>
                                                    <td style="margin: 5px; font-weight: bold;" valign="top" class="auto-style59">i).</td>
                                                    <td style="margin: 5px;" class="auto-style65">As per Approved Project cost in Rs.</td>
                                                    <td style="margin: 5px;" class="auto-style59">:</td>
                                                    <td style="margin: 5px;" class="auto-style59">
                                                        <asp:TextBox ID="txtfacCostCompc" runat="server" class="form-control txtbox" onkeypress="DecimalOnly()" Height="28px" MaxLength="100" TabIndex="6" Width="150px"></asp:TextBox>
                                                    </td>
                                                    <td class="auto-style59">&nbsp;
                                                    </td>
                                                </tr>

                                                <tr>
                                                    <td style="padding: 5px; margin: 5px;" valign="top" class="auto-style66">ii).</td>
                                                    <td style="padding: 5px; margin: 5px;" class="auto-style67">Land measuring in Sq.mts.</td>
                                                    <td style="margin: 5px;" class="auto-style61">:</td>
                                                    <td style="margin: 5px;" class="auto-style61">
                                                        <asp:TextBox ID="txtLandAreaCompc" runat="server" class="form-control txtbox" onkeypress="DecimalOnly()" Height="28px" MaxLength="100" TabIndex="6" Width="150px"></asp:TextBox>
                                                    </td>
                                                    <td style="margin: 5px;" class="auto-style61">&nbsp;
                                                    </td>
                                                    <td style="margin: 5px;" valign="top" class="auto-style66">ii).</td>
                                                    <td style="margin: 5px;" class="auto-style69">Factory building's plinth area/item wise<br />
                                                        total value assessed by G.M,DIC.in Rs</td>
                                                    <td style="margin: 5px;" class="auto-style61">:</td>
                                                    <td style="margin: 5px;" class="auto-style61">
                                                        <asp:TextBox ID="txtfacBldgCompc" runat="server" Text="0" class="form-control txtbox" Height="28px" MaxLength="100" onkeypress="DecimalOnly()" TabIndex="6" Width="150px"></asp:TextBox>
                                                    </td>
                                                    <td class="auto-style61">&nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="padding: 5px; margin: 5px;" valign="top" class="auto-style70">iii).</td>
                                                    <td style="padding: 5px; margin: 5px;" class="auto-style71">Purchase value as per in document.</td>
                                                    <td style="margin: 5px;" class="auto-style55">:</td>
                                                    <td style="margin: 5px;" class="auto-style55">
                                                        <asp:TextBox ID="txtPurchaCompc" runat="server" class="form-control txtbox" onkeypress="DecimalOnly()" Height="28px" MaxLength="100" TabIndex="6" Width="150px"></asp:TextBox>
                                                    </td>
                                                    <td style="margin: 5px;" class="auto-style55">&nbsp;
                                                    </td>
                                                    <td style="margin: 5px;" valign="top" class="auto-style70">iii).</td>
                                                    <td style="margin: 5px;" class="auto-style72">As per Civil Engineer&#39;s Certificate in Rs.</td>
                                                    <td style="margin: 5px;" class="auto-style55">:</td>
                                                    <td style="margin: 5px;" class="auto-style55">
                                                        <asp:TextBox ID="txtcivilEngCompc" Text="0" runat="server" class="form-control txtbox" Height="28px" MaxLength="100" onkeypress="DecimalOnly()" TabIndex="6" Width="150px"></asp:TextBox>
                                                    </td>
                                                    <td class="auto-style55">&nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="padding: 5px; margin: 5px;" valign="top" class="auto-style73">iv).</td>
                                                    <td style="padding: 5px; margin: 5px;" class="auto-style74">Stamp Duty in Rs.</td>
                                                    <td style="margin: 5px;" class="auto-style60">:</td>
                                                    <td style="margin: 5px;" class="auto-style60">
                                                        <asp:TextBox ID="txtStmpDutyCompc" runat="server" class="form-control txtbox" onkeypress="DecimalOnly()" Height="28px" MaxLength="100" TabIndex="6" Width="150px"></asp:TextBox>
                                                    </td>
                                                    <td style="margin: 5px;" class="auto-style60">&nbsp;
                                                    </td>
                                                    <td style="margin: 5px;" valign="top" class="auto-style73">iv).</td>
                                                    <td style="margin: 5px;" class="auto-style75">Value assesses as per TSSSFC rates<br />
                                                        in Rs.</td>
                                                    <td style="margin: 5px;" class="auto-style60">:</td>
                                                    <td style="margin: 5px;" class="auto-style60">
                                                        <asp:TextBox ID="txtsfcCompc" runat="server" Text="0" class="form-control txtbox" Height="28px" MaxLength="100" onkeypress="DecimalOnly()" TabIndex="6" Width="150px"></asp:TextBox>
                                                    </td>
                                                    <td class="auto-style60">&nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="padding: 5px; margin: 5px; font-weight: bold;" valign="top" class="auto-style58">v).</td>
                                                    <td style="padding: 5px; margin: 5px;" class="auto-style76">Registration fee in Rs.</td>
                                                    <td style="margin: 5px;" class="auto-style58">:</td>
                                                    <td style="margin: 5px;" class="auto-style58">
                                                        <asp:TextBox ID="txtRegnfeeCompc" runat="server" class="form-control txtbox" onkeypress="DecimalOnly()" Height="28px" MaxLength="100" TabIndex="6" Width="150px"></asp:TextBox>
                                                    </td>
                                                    <td style="margin: 5px;" class="auto-style58">&nbsp;
                                                    </td>
                                                    <td style="margin: 5px;" valign="top" class="auto-style77">v).</td>
                                                    <td style="margin: 5px;" class="auto-style78">Expenditure as per C.A Certificate<br />
                                                        in Rs.</td>
                                                    <td style="margin: 5px;" class="auto-style58">:</td>
                                                    <td style="margin: 5px;" class="auto-style58">
                                                        <asp:TextBox ID="txtCAExpCompc" runat="server" Text="0" class="form-control txtbox" Height="28px" MaxLength="100" onkeypress="DecimalOnly()" TabIndex="6" Width="150px"></asp:TextBox>
                                                    </td>
                                                    <td class="auto-style58">&nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="padding: 5px; margin: 5px;" valign="top" class="auto-style79">vi)</td>
                                                    <td style="padding: 5px; margin: 5px;" class="auto-style80">Total</td>
                                                    <td style="margin: 5px;" class="auto-style54">:</td>
                                                    <td style="margin: 5px;" class="auto-style54">
                                                        <asp:TextBox ID="txtTotalCompc" runat="server" class="form-control txtbox" onkeypress="DecimalOnly()" Height="28px" MaxLength="100" TabIndex="6" Width="150px"></asp:TextBox>
                                                    </td>
                                                    <td style="margin: 5px;" class="auto-style54">&nbsp;
                                                    </td>
                                                    <td style="margin: 5px;" valign="top" class="auto-style79">vi).</td>
                                                    <td style="margin: 5px;" class="auto-style82">Computed Value</td>
                                                    <td style="margin: 5px;" class="auto-style54">:</td>
                                                    <td style="margin: 5px;" class="auto-style54">
                                                        <asp:TextBox ID="txtCompvalCompc" runat="server" Text="0" class="form-control txtbox" Height="28px" MaxLength="100" onkeypress="DecimalOnly()" TabIndex="6" Width="150px"></asp:TextBox>
                                                    </td>
                                                    <td class="auto-style54">&nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="padding: 5px; margin: 5px;" valign="top" class="ui-priority-primary">vii)</td>
                                                    <td style="padding: 5px; margin: 5px;" class="auto-style33">Building plinth area in Sq.Mts.</td>
                                                    <td style="margin: 5px;">:</td>
                                                    <td style="margin: 5px;">
                                                        <asp:TextBox ID="txtBuildingAreCompc" runat="server" class="form-control txtbox" onkeypress="DecimalOnly()" Height="28px" MaxLength="100" TabIndex="6" Width="150px"></asp:TextBox>
                                                    </td>
                                                    <td style="margin: 5px;">&nbsp;
                                                    </td>
                                                    <td style="margin: 5px;" valign="top" class="ui-priority-primary">vii).</td>
                                                    <td style="margin: 5px;" class="auto-style31">Reasons of variations with that of G.M.'s recommendation.</td>
                                                    <td style="margin: 5px;">:</td>
                                                    <td style="margin: 5px;">
                                                        <asp:TextBox ID="txtrsnCompc" runat="server" class="form-control txtbox" Text="NA" TabIndex="6" Height="80px" TextMode="MultiLine"></asp:TextBox>
                                                    </td>
                                                    <td>&nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="padding: 5px; margin: 5px;" valign="top" class="auto-style83">viii)</td>
                                                    <td style="padding: 5px; margin: 5px;" class="auto-style84">Value recommended by G.M DIC. in Rs.</td>
                                                    <td style="margin: 5px;" class="auto-style62">:</td>
                                                    <td style="margin: 5px;" class="auto-style62">
                                                        <asp:TextBox ID="txtvalDICCompc" runat="server" class="form-control txtbox" onkeypress="DecimalOnly()" Height="28px" MaxLength="100" TabIndex="6" Width="150px"></asp:TextBox>
                                                    </td>
                                                    <td style="margin: 5px;" class="auto-style62">&nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="padding: 5px; margin: 5px; font-weight: bold;" valign="top">ix)
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px;" valign="top" class="auto-style33">Value Computed in Rs.</td>
                                                    <td style="padding: 5px; margin: 5px;">:
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px;">
                                                        <asp:TextBox ID="txtvalCompc1" runat="server" onkeypress="DecimalOnly()" class="form-control txtbox" Height="30px"
                                                            MaxLength="80" TabIndex="10"
                                                            Width="150px"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="padding: 5px; margin: 5px; font-weight: bold;" valign="top">x)
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px; text-align: left;" valign="top" class="auto-style33">Reasons of variations with
                                                        <br />
                                                        that of G.M.&#39;s recommendation.
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">:
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                        <asp:TextBox ID="txtresonsCompc" Text="NA" runat="server" class="form-control txtbox" TabIndex="11"
                                                            Height="80px" TextMode="MultiLine"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <br />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="padding: 5px; margin: 5px; font-weight: bold;" valign="top">
                                                        <b>C.</b></td>
                                                    <td colspan="4" style="padding: 5px; margin: 5px;">
                                                        <b>PLANT AND MACHINERY</b></td>
                                                    <td>&nbsp;</td>
                                                    <td colspan="3" style="padding: 5px; margin: 5px;">&nbsp;</td>
                                                </tr>
                                                <tr>
                                                    <td style="padding: 5px; margin: 5px;" valign="top" class="auto-style2">i)&nbsp;</td>
                                                    <td style="padding: 5px; margin: 5px;" class="auto-style32">As per approved project cost.</td>
                                                    <td style="margin: 5px;" class="auto-style1">:</td>
                                                    <td style="margin: 5px;" class="auto-style1">
                                                        <asp:TextBox ID="TextBox30" runat="server" class="form-control txtbox" onkeypress="DecimalOnly()" Height="28px" MaxLength="100" TabIndex="6" Width="150px"></asp:TextBox>
                                                    </td>
                                                    <td style="margin: 5px;" class="auto-style1">&nbsp;
                                                    </td>
                                                    <td style="margin: 5px; font-weight: bold;" valign="top" class="auto-style1">&nbsp;</td>
                                                    <td style="margin: 5px;" class="auto-style30">&nbsp;</td>
                                                    <td style="margin: 5px;" class="auto-style1"></td>
                                                    <td style="margin: 5px;" class="auto-style1">&nbsp;</td>
                                                    <td class="auto-style1">&nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="padding: 5px; margin: 5px;" valign="top" class="ui-priority-primary">ii).</td>
                                                    <td style="padding: 5px; margin: 5px;" class="auto-style33">Technical know-how &amp; feasibility study and turnkey charges as per approved project cost.</td>
                                                    <td style="margin: 5px;">:</td>
                                                    <td style="margin: 5px;">
                                                        <asp:TextBox ID="TextBox32" runat="server" class="form-control txtbox" onkeypress="DecimalOnly()" Height="28px" MaxLength="100" TabIndex="6" Width="150px"></asp:TextBox>
                                                    </td>
                                                    <td style="margin: 5px;">&nbsp;
                                                    </td>
                                                    <td style="margin: 5px;" valign="top" class="ui-priority-primary">&nbsp;</td>
                                                    <td style="margin: 5px;" class="auto-style31">&nbsp;</td>
                                                    <td style="margin: 5px;"></td>
                                                    <td style="margin: 5px;">&nbsp;</td>
                                                    <td>&nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="padding: 5px; margin: 5px;" valign="top" class="auto-style66"></td>
                                                    <td style="padding: 5px; text-align: center; margin: 5px;" class="auto-style67">
                                                        <b>Sub Total Rs.</b></td>
                                                    <td style="margin: 5px;" class="auto-style61">:</td>
                                                    <td style="margin: 5px;" class="auto-style61">
                                                        <asp:TextBox ID="TextBox31" runat="server" class="form-control txtbox" onkeypress="DecimalOnly()" Height="28px" MaxLength="100" TabIndex="6" Width="150px"></asp:TextBox>
                                                    </td>
                                                    <td style="margin: 5px;" class="auto-style61">&nbsp;
                                                    </td>
                                                    <td style="margin: 5px;" valign="top" class="auto-style66"></td>
                                                    <td style="margin: 5px;" class="auto-style69"></td>
                                                    <td style="margin: 5px;" class="auto-style61"></td>
                                                    <td style="margin: 5px;" class="auto-style61"></td>
                                                    <td class="auto-style61">&nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="padding: 5px; margin: 5px;" valign="top" class="ui-priority-primary">iii).</td>
                                                    <td style="padding: 5px; margin: 5px;" class="auto-style33">As recommended by G.M.,DIC</td>
                                                    <td style="margin: 5px;">:</td>
                                                    <td style="margin: 5px;">
                                                        <asp:TextBox ID="TextBox34" runat="server" class="form-control txtbox" onkeypress="DecimalOnly()" Height="28px" MaxLength="100" TabIndex="6" Width="150px"></asp:TextBox>
                                                    </td>
                                                    <td style="margin: 5px;">&nbsp;
                                                    </td>
                                                    <td style="margin: 5px;" valign="top" class="ui-priority-primary">&nbsp;</td>
                                                    <td style="margin: 5px;" class="auto-style31">&nbsp;</td>
                                                    <td style="margin: 5px;"></td>
                                                    <td style="margin: 5px;">&nbsp;</td>
                                                    <td>&nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="padding: 5px; margin: 5px;" valign="top" class="ui-priority-primary">iv).</td>
                                                    <td style="padding: 5px; margin: 5px;" class="auto-style33">As per the M/C Statement(s) certified by fin.Instn in case aided units. As per M/C statement supported by copies of purchase invoices and certified by G.M (in case of financed/financed through public issues without any loan).</td>
                                                    <td style="margin: 5px;">:</td>
                                                    <td style="margin: 5px;">
                                                        <asp:TextBox ID="TextBox36" runat="server" onkeypress="DecimalOnly()" class="form-control txtbox" Height="28px" MaxLength="100" TabIndex="6" Width="150px"></asp:TextBox>
                                                    </td>
                                                    <td style="margin: 5px;">&nbsp;
                                                    </td>
                                                    <td style="margin: 5px;" valign="top" class="ui-priority-primary">&nbsp;</td>
                                                    <td style="margin: 5px;" class="auto-style31">
                                                        <br />
                                                    </td>
                                                    <td style="margin: 5px;"></td>
                                                    <td style="margin: 5px;">&nbsp;</td>
                                                    <td>&nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="padding: 5px; margin: 5px; font-weight: bold;" valign="top">v).</td>
                                                    <td style="padding: 5px; margin: 5px;" class="auto-style33">As per C.A. Certificate</td>
                                                    <td style="margin: 5px;">:</td>
                                                    <td style="margin: 5px;">
                                                        <asp:TextBox ID="TextBox38" runat="server" class="form-control txtbox" onkeypress="DecimalOnly()" Height="28px" MaxLength="100" TabIndex="6" Width="150px"></asp:TextBox>
                                                    </td>
                                                    <td style="margin: 5px;">&nbsp;
                                                    </td>
                                                    <td style="margin: 5px;" valign="top" class="ui-priority-primary">&nbsp;</td>
                                                    <td style="margin: 5px;" class="auto-style31">&nbsp;</td>
                                                    <td style="margin: 5px;"></td>
                                                    <td style="margin: 5px;">&nbsp;</td>
                                                    <td>&nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="padding: 5px; margin: 5px;" valign="top" class="ui-priority-primary">vi)</td>
                                                    <td style="padding: 5px; margin: 5px;" class="auto-style33">Whether technical know-how &amp; feasibility &amp; turnkey charges capitilised and Certificate to this effect produced from C.A.</td>
                                                    <td style="margin: 5px;">:</td>
                                                    <td style="margin: 5px;">
                                                        <asp:TextBox ID="TextBox40" Text="0" runat="server" class="form-control txtbox" onkeypress="DecimalOnly()" Height="28px" MaxLength="100" TabIndex="6" Width="150px"></asp:TextBox>
                                                    </td>
                                                    <td style="margin: 5px;">&nbsp;
                                                    </td>
                                                    <td style="margin: 5px;" valign="top" class="ui-priority-primary">&nbsp;</td>
                                                    <td style="margin: 5px;" class="auto-style31">&nbsp;</td>
                                                    <td style="margin: 5px;"></td>
                                                    <td style="margin: 5px;">&nbsp;</td>
                                                    <td>&nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="padding: 5px; margin: 5px;" valign="top" class="auto-style63">vii)</td>
                                                    <td style="padding: 5px; margin: 5px;" class="auto-style64">Computed value in Rs.</td>
                                                    <td style="margin: 5px;" class="auto-style59">:</td>
                                                    <td style="margin: 5px;" class="auto-style59">
                                                        <asp:TextBox ID="TextBox42" runat="server" class="form-control txtbox" onkeypress="DecimalOnly()" Height="28px" MaxLength="100" TabIndex="6" Width="150px"></asp:TextBox>
                                                    </td>
                                                    <td style="margin: 5px;" class="auto-style59">&nbsp;
                                                    </td>
                                                    <td style="margin: 5px;" valign="top" class="auto-style63"></td>
                                                    <td style="margin: 5px;" class="auto-style65"></td>
                                                    <td style="margin: 5px;" class="auto-style59"></td>
                                                    <td style="margin: 5px;" class="auto-style59"></td>
                                                    <td class="auto-style59">&nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="padding: 5px; margin: 5px;" valign="top" class="auto-style2">viii)</td>
                                                    <td style="padding: 5px; margin: 5px;" class="auto-style32">Reasons of Variations with that of G.M. recommendation.</td>
                                                    <td style="margin: 5px;" class="auto-style1">:</td>
                                                    <td style="margin: 5px;" class="auto-style1">
                                                        <asp:TextBox ID="TextBox47" runat="server" Text="NA" class="form-control txtbox" Height="80px" TabIndex="11" TextMode="MultiLine"></asp:TextBox>
                                                    </td>
                                                    <td style="margin: 5px;" class="auto-style1">&nbsp;
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="5">
                                            <table style="width: 100%">
                                                <tr style="height: 30px">
                                                    <td colspan="10" style="padding: 5px; margin: 5px; font-weight: bold; font-size: medium">&nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="padding: 5px; margin: 5px; font-weight: bold;" valign="top" class="auto-style12">18<b>. </b>
                                                    </td>
                                                    <td colspan="4" style="padding: 5px; margin: 5px;">
                                                        <b>ABSTRACT</b> </td>
                                                    <td class="auto-style25">&nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="padding: 5px; margin: 5px; font-weight: bold;" valign="top" class="auto-style12">&nbsp;</td>
                                                    <td style="padding: 5px; margin: 5px;" class="auto-style10">&nbsp;</td>
                                                    <td class="auto-style18">&nbsp;</td>
                                                    <td style="padding: 5px; margin: 5px;" class="auto-style5">
                                                        <b>As per approved costs</b></td>
                                                    <td class="auto-style15"></td>
                                                    <td class="auto-style25">
                                                        <b>Computed as eligible Investment</b>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="padding: 5px; margin: 5px;" valign="top" class="auto-style13">i)&nbsp;</td>
                                                    <td style="padding: 5px; margin: 5px;" class="auto-style11">Land</td>
                                                    <td style="margin: 5px;" class="auto-style19"></td>
                                                    <td style="margin: 5px;" class="auto-style6">
                                                        <asp:TextBox ID="TextBox33" runat="server" AutoPostBack="true" onkeypress="DecimalOnly()" class="form-control txtbox" Height="28px" MaxLength="100" TabIndex="6" Width="150px" OnTextChanged="TextBox33_TextChanged"></asp:TextBox>
                                                    </td>
                                                    <td style="margin: 5px; font-weight: bold;" valign="top" class="auto-style16">&nbsp;</td>
                                                    <td style="margin: 5px;" class="auto-style23">
                                                        <asp:TextBox ID="TextBox56" AutoPostBack="true" runat="server" class="form-control txtbox" Height="28px" MaxLength="100" onkeypress="DecimalOnly()" OnTextChanged="TextBox56_TextChanged" TabIndex="6" Width="150px"></asp:TextBox>
                                                    </td>
                                                    <td style="margin: 5px;" class="auto-style1"></td>
                                                    <td style="margin: 5px;" class="auto-style1">&nbsp;</td>
                                                    <td class="auto-style1">&nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="padding: 5px; margin: 5px;" valign="top" class="auto-style49">ii).</td>
                                                    <td style="padding: 5px; margin: 5px;" class="auto-style50">Building</td>
                                                    <td style="margin: 5px;" class="auto-style51"></td>
                                                    <td style="margin: 5px;" class="auto-style52">
                                                        <asp:TextBox ID="TextBox37" runat="server" AutoPostBack="true" class="form-control txtbox" Height="28px" MaxLength="100" TabIndex="6" onkeypress="DecimalOnly()" Width="150px" OnTextChanged="TextBox37_TextChanged"></asp:TextBox>
                                                    </td>
                                                    <td style="margin: 5px;" class="auto-style53">&nbsp;
                                                    </td>
                                                    <td style="margin: 5px;" class="auto-style39">
                                                        <asp:TextBox ID="TextBox57" runat="server" AutoPostBack="true" class="form-control txtbox" Height="28px" MaxLength="100" onkeypress="DecimalOnly()" OnTextChanged="TextBox57_TextChanged" TabIndex="6" Width="150px"></asp:TextBox>
                                                    </td>
                                                    <td style="margin: 5px;" class="auto-style54"></td>
                                                    <td style="margin: 5px;" class="auto-style54"></td>
                                                    <td class="auto-style54">&nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="padding: 5px; margin: 5px;" valign="top" class="auto-style43">iii).</td>
                                                    <td style="padding: 5px; margin: 5px;" class="auto-style44">Plant and Machinery</td>
                                                    <td style="margin: 5px;" class="auto-style45"></td>
                                                    <td style="margin: 5px;" class="auto-style46">
                                                        <asp:TextBox ID="TextBox41" runat="server" AutoPostBack="true" class="form-control txtbox" Height="28px" MaxLength="100" TabIndex="6" onkeypress="DecimalOnly()" Width="150px" OnTextChanged="TextBox41_TextChanged"></asp:TextBox>
                                                    </td>
                                                    <td style="margin: 5px;" class="auto-style47">&nbsp;
                                                    </td>
                                                    <td style="margin: 5px;" class="auto-style41">
                                                        <asp:TextBox ID="TextBox58" AutoPostBack="true" runat="server" class="form-control txtbox" Height="28px" MaxLength="100" TabIndex="6" onkeypress="DecimalOnly()" Width="150px" OnTextChanged="TextBox58_TextChanged"></asp:TextBox>
                                                    </td>
                                                    <td style="margin: 5px;" class="auto-style42"></td>
                                                    <td style="margin: 5px;" class="auto-style48"></td>
                                                    <td style="margin: 5px;" class="auto-style48"></td>
                                                    <td class="auto-style48">&nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="padding: 5px; margin: 5px;" valign="top" class="auto-style14">iv).</td>
                                                    <td style="padding: 5px; margin: 5px;" class="auto-style10">Technical Know-how feasibility study and turn Key Charges</td>
                                                    <td style="margin: 5px;" class="auto-style18"></td>
                                                    <td style="margin: 5px;" class="auto-style5">
                                                        <asp:TextBox ID="TextBox44" AutoPostBack="true" runat="server" class="form-control txtbox" Height="28px" MaxLength="100" TabIndex="6" onkeypress="DecimalOnly()" Width="150px" OnTextChanged="TextBox44_TextChanged"></asp:TextBox>
                                                    </td>
                                                    <td style="margin: 5px;" class="auto-style20">&nbsp;
                                                    </td>
                                                    <td style="margin: 5px;" class="auto-style24">
                                                        <asp:TextBox ID="TextBox45" Text="0" AutoPostBack="true" runat="server" class="form-control txtbox" Height="28px" MaxLength="100" TabIndex="6" onkeypress="DecimalOnly()" Width="150px" OnTextChanged="TextBox45_TextChanged"></asp:TextBox>
                                                    </td>
                                                    <td style="margin: 5px;" class="auto-style4">&nbsp;</td>
                                                    <td style="margin: 5px;"></td>
                                                    <td style="margin: 5px;">&nbsp;</td>
                                                    <td>&nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="padding: 5px; margin: 5px;" valign="top" class="auto-style14">&nbsp;</td>
                                                    <td style="padding: 5px; margin: 5px;" class="auto-style10">
                                                        <b>Total</b></td>
                                                    <td style="margin: 5px;" class="auto-style18"></td>
                                                    <td style="margin: 5px;" class="auto-style5">
                                                        <asp:TextBox ID="TextBox1" runat="server" Enabled="false" class="form-control txtbox" Height="28px" MaxLength="100" TabIndex="6" onkeypress="DecimalOnly()" Width="150px"></asp:TextBox>
                                                    </td>
                                                    <td style="margin: 5px;" class="auto-style20">&nbsp;
                                                    </td>
                                                    <td style="margin: 5px;" valign="top" class="auto-style24">
                                                        <asp:TextBox ID="TextBox2" runat="server" Enabled="false" class="form-control txtbox" onkeypress="DecimalOnly()" Height="28px" MaxLength="100" TabIndex="6" Width="150px"></asp:TextBox>
                                                    </td>
                                                    <td style="margin: 5px;" class="auto-style4">&nbsp;</td>
                                                    <td style="margin: 5px;"></td>
                                                    <td style="margin: 5px;">&nbsp;</td>
                                                    <td>&nbsp;
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="5">
                                            <table>
                                                <tr>
                                                    <td>
                                                        <br />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="padding: 5px; margin: 5px; font-weight: bold;" valign="top">
                                                        <b>19.</b></td>
                                                    <td colspan="4" style="padding: 5px; margin: 5px;">
                                                        <b>REMARKS</b></td>
                                                    <td>&nbsp;</td>
                                                    <td colspan="3" style="padding: 5px; margin: 5px;">&nbsp;</td>
                                                </tr>
                                                <tr>
                                                    <td style="padding: 5px; margin: 5px;" valign="top" class="auto-style73">3.1</td>
                                                    <td style="padding: 5px; margin: 5px;" class="auto-style26">Second Hand Machinery (Value in Rs.)</td>
                                                    <td style="margin: 5px;" class="auto-style86">:</td>
                                                    <td style="margin: 5px;" class="auto-style60">
                                                        <asp:TextBox ID="TextBox35" Text="0" runat="server" onkeypress="DecimalOnly()" class="form-control txtbox" Height="28px" MaxLength="100" TabIndex="6" Width="150px"></asp:TextBox>
                                                    </td>
                                                    <td style="margin: 5px;" class="auto-style60">&nbsp;
                                                    </td>
                                                    <td style="margin: 5px; font-weight: bold;" valign="top" class="auto-style60"></td>
                                                    <td style="margin: 5px;" class="auto-style3"></td>
                                                    <td style="margin: 5px;" class="auto-style60"></td>
                                                    <td style="margin: 5px;" class="auto-style60"></td>
                                                    <td class="auto-style60">&nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="padding: 5px; margin: 5px;" valign="top" class="auto-style87">3.2</td>
                                                    <td style="padding: 5px; margin: 5px;" class="auto-style88">Social Status</td>
                                                    <td style="margin: 5px;" class="auto-style48">:</td>
                                                    <td style="margin: 5px;" class="auto-style48">
                                                        <asp:TextBox ID="TextBox39" Text="NA" runat="server" class="form-control txtbox" Height="28px" MaxLength="100" TabIndex="6" Width="150px"></asp:TextBox>
                                                    </td>
                                                    <td style="margin: 5px;" class="auto-style48">&nbsp;
                                                    </td>
                                                    <td style="margin: 5px;" valign="top" class="auto-style87"></td>
                                                    <td style="margin: 5px;" class="auto-style42"></td>
                                                    <td style="margin: 5px;" class="auto-style48"></td>
                                                    <td style="margin: 5px;" class="auto-style48"></td>
                                                    <td class="auto-style48">&nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="padding: 5px; margin: 5px;" valign="top" class="auto-style83">3.3</td>
                                                    <td style="padding: 5px; margin: 5px;" class="auto-style90">Belated Claim(%Reduction)</td>
                                                    <td style="margin: 5px;" class="auto-style62">:</td>
                                                    <td style="margin: 5px;" class="auto-style62">
                                                        <asp:TextBox ID="TextBox43" Text="0" onkeypress="DecimalOnly()" runat="server" class="form-control txtbox" Height="28px" MaxLength="100" TabIndex="6" Width="150px"></asp:TextBox>
                                                    </td>
                                                    <td style="margin: 5px;" class="auto-style62">&nbsp;
                                                    </td>
                                                    <td style="margin: 5px;" valign="top" class="auto-style83"></td>
                                                    <td style="margin: 5px;" class="auto-style92"></td>
                                                    <td style="margin: 5px;" class="auto-style62"></td>
                                                    <td style="margin: 5px;" class="auto-style62"></td>
                                                    <td class="auto-style62">&nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="padding: 5px; margin: 5px;" valign="top" class="auto-style87">3.4</td>
                                                    <td style="padding: 5px; margin: 5px;" class="auto-style88">Amt of Subsidy already availed/ availing in Rs.</td>
                                                    <td style="margin: 5px;" class="auto-style48">:</td>
                                                    <td style="margin: 5px;" class="auto-style48">
                                                        <asp:TextBox ID="TextBox46" runat="server" Text="0" class="form-control txtbox" onkeypress="DecimalOnly()" Height="28px" MaxLength="100" TabIndex="6" Width="150px"></asp:TextBox>
                                                    </td>
                                                    <td style="margin: 5px;" class="auto-style48">&nbsp;
                                                    </td>
                                                    <td style="margin: 5px;" valign="top" class="auto-style87"></td>
                                                    <td style="margin: 5px;" class="auto-style42"></td>
                                                    <td style="margin: 5px;" class="auto-style48"></td>
                                                    <td style="margin: 5px;" class="auto-style48"></td>
                                                    <td class="auto-style48">&nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="padding: 5px; margin: 5px;" valign="top" class="ui-priority-primary">3.5</td>
                                                    <td style="padding: 5px; margin: 5px;" class="auto-style27">Conditions to be fulfilled</td>
                                                    <td style="margin: 5px;">:</td>
                                                    <td style="margin: 5px;">
                                                        <asp:TextBox ID="TextBox48" runat="server" Text="NA" class="form-control txtbox" Height="80px" TabIndex="6" Width="150px" TextMode="MultiLine"></asp:TextBox>
                                                    </td>
                                                    <td style="margin: 5px;">&nbsp;
                                                    </td>
                                                    <td style="margin: 5px;" valign="top" class="ui-priority-primary">&nbsp;</td>
                                                    <td style="margin: 5px;" class="auto-style4">
                                                        <br />
                                                    </td>
                                                    <td style="margin: 5px;"></td>
                                                    <td style="margin: 5px;">&nbsp;</td>
                                                    <td>&nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="padding: 5px; margin: 5px;" valign="top" class="ui-priority-primary">&nbsp;</td>
                                                    <td style="padding: 5px; margin: 5px;" class="auto-style27">Date upto Which unit shall be in<br />
                                                        Continous production and shall not change Management..</td>
                                                    <td style="margin: 5px;">:
                                                    </td>
                                                    <td style="margin: 5px;">
                                                        <asp:TextBox ID="txtContProdMgm" Text="0" placeholder="Please enter date" runat="server" class="form-control txtbox" Height="28px" MaxLength="100" TabIndex="6" Width="150px"></asp:TextBox>
                                                    </td>
                                                    <td style="margin: 5px;">&nbsp;
                                                    </td>
                                                    <td style="margin: 5px;" valign="top" class="ui-priority-primary">&nbsp;</td>
                                                    <td style="margin: 5px;" class="auto-style4">&nbsp;</td>
                                                    <td style="margin: 5px;"></td>
                                                    <td style="margin: 5px;">&nbsp;</td>
                                                    <td>&nbsp;
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="5">
                                            <table style="width: 100%">
                                                <tr style="height: 30px">
                                                    <td colspan="10" style="padding: 5px; margin: 5px; font-weight: bold; vertical-align: middle;"></td>
                                                </tr>
                                                <tr>
                                                    <td style="padding: 5px; margin: 5px; font-weight: bold; width: 20px">20
                                                    </td>
                                                    <td colspan="4" style="padding: 5px; margin: 5px;">
                                                        <b>EXPANSION/DIVERSIFICATION CASES</b></td>
                                                </tr>
                                                <tr>
                                                    <td style="padding: 5px; margin: 5px;" class="ui-priority-primary">a).&nbsp;</td>
                                                    <td style="padding: 5px; margin: 5px;">Investment prior to E/D in Rs.</td>
                                                    <td style="padding: 5px; margin: 5px;">:
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px;" class="auto-style28">
                                                        <asp:TextBox ID="txt25BldgCvl" Text="0" runat="server" class="form-control txtbox txtcomn"
                                                            Height="30px" MaxLength="80" TabIndex="26" Width="150px"
                                                            onkeypress="DecimalOnly()"></asp:TextBox>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px;" class="auto-style20">
                                                        <strong>d).</strong></td>
                                                    <td style="padding: 5px; margin: 5px;" class="auto-style29">Production Capacity
                                                        <br />
                                                        prior to E/D</td>
                                                    <td style="padding: 5px; margin: 5px;">:</td>
                                                    <td style="padding: 5px; margin: 5px;">&nbsp; 
                            <asp:TextBox ID="txtPlintharea424" Text="0" onkeypress="DecimalOnly()" runat="server" class="form-control txtbox txtcomn" Height="30px" MaxLength="80" TabIndex="28" Width="150px"></asp:TextBox>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px;">&nbsp;
                                                    </td>
                                                </tr>
                                                <tr id="tr4221" runat="server" visible="true">
                                                    <td style="padding: 5px; margin: 5px;" class="ui-priority-primary">b).</td>
                                                    <td style="padding: 5px; margin: 5px; width: 220px">Investment under to E/D in Rs.
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px;">:
                                                    </td>    
                                                    <td style="padding: 5px; margin: 5px;" class="auto-style28">
                                                        <asp:TextBox ID="txt822guideline422" Text="0" runat="server" onkeypress="DecimalOnly()" class="form-control txtbox txtcomn"
                                                            Height="30px" MaxLength="80" TabIndex="27" Width="150px"></asp:TextBox>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px;" class="auto-style20">
                                                        <strong>&nbsp;e)</strong>.</td>
                                                    <td style="padding: 5px; margin: 5px;" class="auto-style29">Additional Capacity proposed under E/D</td>
                                                    <td style="padding: 5px; margin: 5px;">:
                                                    </td>                          
                                                    <td style="padding: 5px; margin: 5px;">
                                                        <asp:TextBox ID="txtPlintharea422" Text="0" onkeypress="DecimalOnly()" runat="server" class="form-control txtbox txtcomn"
                                                            Height="30px" MaxLength="80" TabIndex="28" Width="150px"></asp:TextBox>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px;">&nbsp;
                                                    </td>
                                                </tr>
                                                <tr id="tr4222" runat="server" visible="true">
                                                    <td style="padding: 5px; margin: 5px; font-weight: bold;">c).</td>
                                                    <td style="padding: 5px; margin: 5px;">% Increase in Investment under
                                                        <br />
                                                        E/D</td>
                                                    <td style="padding: 5px; margin: 5px;">:
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px;" class="auto-style28">
                                                        <asp:TextBox ID="txtTSSFCnorms422" Text="0" runat="server" class="form-control txtbox txtcomn"
                                                            Height="30px" onkeypress="DecimalOnly()" MaxLength="80" TabIndex="29"
                                                            Width="150px" AutoPostBack="true"></asp:TextBox>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px;" class="auto-style20">
                                                        <strong>&nbsp;f).</strong></td>
                                                    <td style="padding: 5px; margin: 5px;" class="auto-style29">% Increase in Capacity under E/D</td>
                                                    <td style="padding: 5px; margin: 5px;">:
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px;">
                                                        <asp:TextBox ID="txtvalue422" Text="0" onkeypress="DecimalOnly()" runat="server"
                                                            class="form-control txtbox txtcomn" Height="30px" MaxLength="80" TabIndex="30"
                                                            Width="150px"></asp:TextBox>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px;">&nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="padding: 5px; margin: 5px; font-weight: bold;">&nbsp;</td>
                                                    <td colspan="9" style="padding: 5px; margin: 5px; font-weight: bold;">
                                                        <br />
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>

                          <tr>
                               <td colspan="5">
                      
                                <table style="width: 100%">
                                     <tr style="height: 30px">
                                                    <td colspan="10" style="padding: 5px; margin: 5px; font-weight: bold; vertical-align: middle;"></td>
                                                </tr>
                                                <tr>
                                                    <td style="padding: 5px; margin: 5px; font-weight: bold; width: 20px">21
                                                    </td>
                                                    <td colspan="4" style="padding: 5px; margin: 5px;">
                                                        <b>ELEGIBLE INCENTIVES</b></td>
                                                </tr>
                            <tr>
                                        <td></td>
                                        <td colspan="4">
                                        <asp:GridView ID="grd_claimperiodofloanadd" runat="server" CssClass="table table-small-font table-bordered table-striped" AutoGenerateColumns="false"
                                            AllowPaging="true" ShowHeaderWhenEmpty="true" ShowFooter="true" EmptyDataText="&lt;b&gt;No Data Available&lt;/b&gt;" PageSize="50">
                                            <Columns>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        Sr.#
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <%#Container.DataItemIndex+1 %>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                   <asp:TemplateField>
                                                    <HeaderTemplate>
                                                       Claim Period
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                         <asp:HiddenField ID="hf_claimperiodofloanaddIncentiveId" Value='<%# Eval("IncentiveId") %>' runat="server" />
                                                         <asp:HiddenField ID="hf_claimperiodofloanaddFinancialYear" Value='<%# Eval("FinancialYear") %>' runat="server" />
                                                        <asp:HiddenField ID="hf_claimperiodofloanadd_ID" Value='<%# Eval("FinancialYearID") %>' runat="server" />
                                                        <asp:Label ID="lbl_claimperiodofloanaddname" Text='<%# Eval("FinancialYearName") %>' runat="server"></asp:Label>
                                                    </ItemTemplate>                                            
                                                </asp:TemplateField>                                             
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                       No of Loans Applied for this Claim
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                           <asp:TextBox ID="txt_claimperiodofloanaddNumber" runat="server" class="form-control txtbox" Height="28px" onkeypress="DecimalOnly()"
                                                TabIndex="10"  Width="180px"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator101" runat="server" ControlToValidate="txt_claimperiodofloanaddNumber"
                                                ErrorMessage="Please Enter No of Loans Applied for this Claim " Display="Dynamic" ></asp:RequiredFieldValidator>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                            <PagerStyle CssClass="gridview"></PagerStyle>
                                        </asp:GridView>
                                            
                                            &nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp; &nbsp;  &nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp; &nbsp;
                                              &nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp; &nbsp;
                                              &nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp; &nbsp;
                                             <asp:Button ID="btn_savegrdclaimperiodofloanadd" runat="server" CssClass="btn btn-primary"   Height="32px" 
                                              OnClick="btn_savegrdclaimperiodofloanadd_Click"    Text="Submit to Add More Details"  Width="180px" />
                                            </td>
                                </tr>
                                </table>
                            </td>
                        </tr>

                      
                          <tr>
                               <td colspan="5">
                      
                                <table style="width: 100%">
                                    
                            <tr>
                                        <td></td>
                                        <td colspan="4">
                                        <asp:GridView ID="grd_eglibilepallavaddi" runat="server" CssClass="table table-small-font table-bordered table-striped" AutoGenerateColumns="false"
                                           
                                            AllowPaging="false" ShowHeaderWhenEmpty="true" ShowFooter="true"  EmptyDataText="&lt;b&gt;No Data Available&lt;/b&gt;" >
                                            <Columns>
                                                
                                                   <asp:TemplateField>
                                                  
                                                    <ItemTemplate>
                                                     <asp:HiddenField ID="hf_grdeglibilepallavaddiIncentiveId" Value='<%# Eval("IncentiveId") %>' runat="server" />
                                                         <asp:HiddenField ID="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" Value='<%# Eval("FinancialYear") %>' runat="server" />
                                                        <asp:HiddenField ID="hf_grdeglibilepallavaddiFY_ID" Value='<%# Eval("FinancialYearID") %>' runat="server" />
                                                        <table>
                                                            <tr>
                                                                <th style="font-family: Calibri"><%#Container.DataItemIndex+1 %> Claim Period:   
                                                                     <asp:Label ID="lbl_grdeglibilepallavaddiFYname" Text='<%# Eval("FinancialYearName") %>' runat="server"></asp:Label>
                                                                </th>
                                                                <th style="font-family: Calibri"></th>
                                                                <th style="font-family: Calibri">&nbsp;&nbsp;&nbsp; &nbsp;  Loan-
                                                                     <asp:Label ID="lbl_claimeglibleincentivesloanwiseLoanID" Text='<%# Eval("LoanNumber") %>' runat="server"></asp:Label></th>
                                                                <th style="font-family: Calibri"></th>
                                                            </tr>
                                                            <tr>
                                                                <td style="font-family: Calibri"></td>
                                                                <td style="font-family: Calibri"></td>
                                                                <td style="font-family: Calibri"></td>
                                                                <td style="font-family: Calibri"></td>
                                                            </tr>
                                                            <tr>
                                                                <td style="font-family: Calibri"><b>Date of Commencement of activity:</b></td>
                                                                <td style="font-family: Calibri">
                                                                    <asp:TextBox ID="txt_claimeglibleincentivesloanwiseDateofCommencementofactivity"  Text='<%# Eval("DCPDATE") %>' runat="server" class="form-control txtbox" Height="28px" AutoPostBack="true" OnTextChanged="txt_claimeglibleincentivesloanwiseDateofCommencementofactivity_TextChanged"
                                                                        TabIndex="10" Width="180px"></asp:TextBox>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator102" runat="server" ControlToValidate="txt_claimeglibleincentivesloanwiseDateofCommencementofactivity"
                                                                        ErrorMessage="Please Enter Date of Commencement of activity" Display="Dynamic"></asp:RequiredFieldValidator>
                                                                    <br />
                                                                </td>
                                                                <td style="font-family: Calibri">&nbsp;&nbsp;&nbsp; &nbsp;<b>Loan installment start Date</b></td>
                                                                <td style="font-family: Calibri">
                                                                    <asp:TextBox ID="txt_claimeglibleincentivesloanwiseinstallmentstartdate" runat="server" class="form-control txtbox" Height="28px" AutoPostBack="true" OnTextChanged="txt_claimeglibleincentivesloanwiseinstallmentstartdate_TextChanged"
                                                                        TabIndex="10" Width="180px"></asp:TextBox>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator103" runat="server" ControlToValidate="txt_claimeglibleincentivesloanwiseinstallmentstartdate"
                                                                        ErrorMessage="Please Enter Month from which installment starts" Display="Dynamic"></asp:RequiredFieldValidator>
                                                                    <br />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="font-family: Calibri"><b>Total Term Loan Availed(In Rs.)</b></td>
                                                                <td style="font-family: Calibri">
                                                                    <asp:TextBox ID="txt_claimeglibleincentivesloanwiseeglsacamountinterestreimbursement" runat="server" class="form-control txtbox" Height="28px"
                                                                        onkeypress="DecimalOnly()" AutoPostBack="true" OnTextChanged="txt_claimeglibleincentivesloanwiseeglsacamountinterestreimbursement_TextChanged"
                                                                        TabIndex="10" Width="180px"></asp:TextBox>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator104" runat="server" ControlToValidate="txt_claimeglibleincentivesloanwiseeglsacamountinterestreimbursement"
                                                                        ErrorMessage="Please Enter Total Term Loan Availed(Value in Rs.)" Display="Dynamic"></asp:RequiredFieldValidator>
                                                                    <br />
                                                                </td>
                                                                <td style="font-family: Calibri">&nbsp;&nbsp;&nbsp; &nbsp;<b>Period of installment</b></td>
                                                                <td style="font-family: Calibri">
                                                                    <asp:DropDownList ID="ddl_claimeglibleincentivesloanwiseperiodofinstallment" runat="server" class="form-control txtbox" AutoPostBack="true" OnSelectedIndexChanged="ddl_claimeglibleincentivesloanwiseperiodofinstallment_SelectedIndexChanged"
                                                                        TabIndex="4" Height="33px" Width="180px">
                                                                        <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                                        <asp:ListItem Value="1">Yearly</asp:ListItem>
                                                                        <asp:ListItem Value="2">Halfyearly</asp:ListItem>
                                                                        <asp:ListItem Value="3">Quartely</asp:ListItem>
                                                                        <asp:ListItem Value="4">Monthly</asp:ListItem>
                                                                    </asp:DropDownList>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator105" runat="server" ControlToValidate="ddl_claimeglibleincentivesloanwiseperiodofinstallment"
                                                                        ErrorMessage="Please select Period of installment" Display="Dynamic" InitialValue="0"></asp:RequiredFieldValidator>
                                                                    <br />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="font-family: Calibri"><b>No of installment</b></td>
                                                                <td style="font-family: Calibri">
                                                                    <asp:TextBox ID="txt_claimeglibleincentivesloanwisenoofinstallment" runat="server" class="form-control txtbox" Height="28px" AutoPostBack="true" OnTextChanged="txt_claimeglibleincentivesloanwisenoofinstallment_TextChanged"
                                                                        TabIndex="10" Width="180px"></asp:TextBox>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator106" runat="server" ControlToValidate="txt_claimeglibleincentivesloanwisenoofinstallment"
                                                                        ErrorMessage="Please Enter No of installment" Display="Dynamic"></asp:RequiredFieldValidator>
                                                                    <br />
                                                                </td>
                                                                <td style="font-family: Calibri">&nbsp;&nbsp;&nbsp; &nbsp;<b>Installment amount</b></td>
                                                                <td style="font-family: Calibri">
                                                                    <asp:TextBox ID="txt_claimeglibleincentivesloanwiseInstallmentamount" runat="server" class="form-control txtbox" Height="28px" AutoPostBack="true" OnTextChanged="txt_claimeglibleincentivesloanwiseInstallmentamount_TextChanged"
                                                                      Enabled="false"  TabIndex="10" Width="180px"></asp:TextBox>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator109" runat="server" ControlToValidate="txt_claimeglibleincentivesloanwiseInstallmentamount"
                                                                        ErrorMessage="Please Enter Installment amount" Display="Dynamic"></asp:RequiredFieldValidator>
                                                                    <br />
                                                                </td>

                                                            </tr>
                                                           
                                                            <tr>
                                                                <td style="font-family: Calibri"><b>No of installments completed</b></td>
                                                                <td style="font-family: Calibri">
                                                                    <asp:TextBox ID="txt_claimeglibleincentivesloanwiseNoofinstallmentscompleted" runat="server" class="form-control txtbox" Height="28px" AutoPostBack="true" OnTextChanged="txt_claimeglibleincentivesloanwiseNoofinstallmentscompleted_TextChanged"
                                                                      Enabled="false"  TabIndex="10" Width="180px"></asp:TextBox>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator110" runat="server" ControlToValidate="txt_claimeglibleincentivesloanwiseNoofinstallmentscompleted"
                                                                        ErrorMessage="Please Enter No of installments completed" Display="Dynamic"></asp:RequiredFieldValidator>
                                                                    <br />
                                                                </td>
                                                                <td style="font-family: Calibri">&nbsp;&nbsp;&nbsp; &nbsp;<b>PrincipalAmount become DUE before this HALFYEAR</b></td>
                                                                <td style="font-family: Calibri">
                                                                    <asp:TextBox ID="txt_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR" runat="server" AutoPostBack="true" OnTextChanged="txt_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR_TextChanged"
                                                                      Enabled="false"  class="form-control txtbox" Height="28px"
                                                                        TabIndex="10" Width="180px"></asp:TextBox>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator111" runat="server" ControlToValidate="txt_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR"
                                                                        ErrorMessage="Please Enter Principal amount become DUE before this HALF YEAR" Display="Dynamic"></asp:RequiredFieldValidator>
                                                                    <br />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="4">
                                                                    <table border="1" width="100%" align="center" cellpadding="10" cellspacing="5">
                                                                        <tr style="column-rule-style: solid">
                                                                            <th style="font-family: Calibri">Sr.#	</th>
                                                                            <th style="font-family: Calibri">Period of Claim</th>
                                                                            <th style="font-family: Calibri">Principal amounnt due</th>

                                                                            <th style="font-family: Calibri">No of Installment</th>
                                                                            <th style="font-family: Calibri">Rate of Interest</th>
                                                                            <th style="font-family: Calibri">Interest due</th>

                                                                            <th style="font-family: Calibri">Unit Holder  Contribution</th>
                                                                            <th style="font-family: Calibri">Eligible Rate of interest</th>
                                                                            <th style="font-family: Calibri">Eligible Interest Amount</th>
                                                                        </tr>
                                                                        <tr>
                                                                            <td style="font-family: Calibri">1</td>
                                                                            <td style="font-family: Calibri">
                                                                                <asp:HiddenField ID="hfgrd_monthoneid" runat="server" />
                                                                                <asp:Label ID="lbl_grd_monthonename" runat="server"></asp:Label>

                                                                            </td>
                                                                            <td style="font-family: Calibri">
                                                                                <asp:Label ID="lbl_grd_monthnonePrincipalamounntdue" runat="server"></asp:Label>
                                                                            </td>
                                                                            <td style="font-family: Calibri">
                                                                                <asp:Label ID="lbl_grd_monthoneNoofInstallment" runat="server"></asp:Label>
                                                                            </td>
                                                                            <td style="font-family: Calibri">
                                                                                <asp:TextBox ID="lbl_grd_monthoneRateofinterest" runat="server" AutoPostBack="true" OnTextChanged="lbl_grd_monthoneRateofinterest_TextChanged"
                                                                                    class="form-control txtbox" Height="28px" TabIndex="10" Width="180px"></asp:TextBox>
                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="lbl_grd_monthoneRateofinterest"
                                                                                    ErrorMessage="Please Enter Rate of interest Month1" Display="Dynamic"></asp:RequiredFieldValidator>

                                                                                <%-- <asp:Label ID="lbl_grd_monthoneRateofinterest"  runat="server"></asp:Label>--%>
                                                                            </td>
                                                                            <td style="font-family: Calibri">
                                                                                <asp:Label ID="lbl_grd_monthoneInterestamount" runat="server"></asp:Label>
                                                                            </td>
                                                                            <td style="font-family: Calibri">
                                                                                <asp:Label ID="lbl_grd_monthoneUnitHolderContribution" runat="server"></asp:Label>
                                                                            </td>
                                                                            <td style="font-family: Calibri">
                                                                                <asp:Label ID="lbl_grd_monthoneEligibleRateofinterest" runat="server"></asp:Label>
                                                                            </td>
                                                                            <td style="font-family: Calibri">
                                                                                <asp:Label ID="lbl_grd_monthoneEligibleInterestAmount" runat="server"></asp:Label>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td style="font-family: Calibri">2</td>
                                                                            <td style="font-family: Calibri">
                                                                                <asp:HiddenField ID="hfgrd_monthtwoid" runat="server" />
                                                                                <asp:Label ID="lbl_grd_monthtwoname" runat="server"></asp:Label>

                                                                            </td>
                                                                            <td style="font-family: Calibri">
                                                                                <asp:Label ID="lbl_grd_monthtwoPrincipalamounntdue" runat="server"></asp:Label>
                                                                            </td>
                                                                            <td style="font-family: Calibri">
                                                                                <asp:Label ID="lbl_grd_monthtwoNoofInstallment" runat="server"></asp:Label>
                                                                            </td>
                                                                            <td style="font-family: Calibri">
                                                                                <%--   <asp:Label ID="lbl_grd_monthtwoRateofinterest"  runat="server"></asp:Label>--%>
                                                                                <asp:TextBox ID="lbl_grd_monthtwoRateofinterest" runat="server" AutoPostBack="true" OnTextChanged="lbl_grd_monthtwoRateofinterest_TextChanged"
                                                                                    class="form-control txtbox" Height="28px" TabIndex="10" Width="180px"></asp:TextBox>
                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="lbl_grd_monthtwoRateofinterest"
                                                                                    ErrorMessage="Please Enter Rate of interest Month2" Display="Dynamic"></asp:RequiredFieldValidator>

                                                                            </td>
                                                                            <td style="font-family: Calibri">
                                                                                <asp:Label ID="lbl_grd_monthtwoInterestamount" runat="server"></asp:Label>
                                                                            </td>
                                                                            <td style="font-family: Calibri">
                                                                                <asp:Label ID="lbl_grd_monthtwoUnitHolderContribution" runat="server"></asp:Label>
                                                                            </td>
                                                                            <td style="font-family: Calibri">
                                                                                <asp:Label ID="lbl_grd_monthtwoEligibleRateofinterest" runat="server"></asp:Label>
                                                                            </td>
                                                                            <td style="font-family: Calibri">
                                                                                <asp:Label ID="lbl_grd_monthtwoEligibleInterestAmount" runat="server"></asp:Label>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td style="font-family: Calibri">3</td>
                                                                            <td style="font-family: Calibri">
                                                                                <asp:HiddenField ID="hfgrd_monththreeid" runat="server" />
                                                                                <asp:Label ID="lbl_grd_monththreename" runat="server"></asp:Label>

                                                                            </td>
                                                                            <td style="font-family: Calibri">
                                                                                <asp:Label ID="lbl_grd_monththreePrincipalamounntdue" runat="server"></asp:Label>
                                                                            </td>
                                                                            <td style="font-family: Calibri">
                                                                                <asp:Label ID="lbl_grd_monththreeNoofInstallment" runat="server"></asp:Label>
                                                                            </td>
                                                                            <td style="font-family: Calibri">
                                                                                <%-- <asp:Label ID="lbl_grd_monththreeRateofinterest"  runat="server"></asp:Label>--%>
                                                                                <asp:TextBox ID="lbl_grd_monththreeRateofinterest" runat="server" AutoPostBack="true" OnTextChanged="lbl_grd_monththreeRateofinterest_TextChanged"
                                                                                    class="form-control txtbox" Height="28px" TabIndex="10" Width="180px"></asp:TextBox>
                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="lbl_grd_monththreeRateofinterest"
                                                                                    ErrorMessage="Please Enter Rate of interest Month3" Display="Dynamic"></asp:RequiredFieldValidator>
                                                                            </td>
                                                                            <td style="font-family: Calibri">
                                                                                <asp:Label ID="lbl_grd_monththreeInterestamount" runat="server"></asp:Label>
                                                                            </td>
                                                                            <td style="font-family: Calibri">
                                                                                <asp:Label ID="lbl_grd_monththreeUnitHolderContribution" runat="server"></asp:Label>
                                                                            </td>
                                                                            <td style="font-family: Calibri">
                                                                                <asp:Label ID="lbl_grd_monththreeEligibleRateofinterest" runat="server"></asp:Label>
                                                                            </td>
                                                                            <td style="font-family: Calibri">
                                                                                <asp:Label ID="lbl_grd_monththreeEligibleInterestAmount" runat="server"></asp:Label>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td style="font-family: Calibri">4</td>
                                                                            <td style="font-family: Calibri">
                                                                                <asp:HiddenField ID="hfgrd_monthfourid" runat="server" />
                                                                                <asp:Label ID="lbl_grd_monthfourname" runat="server"></asp:Label>

                                                                            </td>
                                                                            <td style="font-family: Calibri">
                                                                                <asp:Label ID="lbl_grd_monthfourPrincipalamounntdue" runat="server"></asp:Label>
                                                                            </td>
                                                                            <td style="font-family: Calibri">
                                                                                <asp:Label ID="lbl_grd_monthfourNoofInstallment" runat="server"></asp:Label>
                                                                            </td>
                                                                            <td style="font-family: Calibri">
                                                                                <%-- <asp:Label ID="lbl_grd_monthfourRateofinterest"  runat="server"></asp:Label>--%>
                                                                                <asp:TextBox ID="lbl_grd_monthfourRateofinterest" runat="server" AutoPostBack="true" OnTextChanged="lbl_grd_monthfourRateofinterest_TextChanged"
                                                                                    class="form-control txtbox" Height="28px" TabIndex="10" Width="180px"></asp:TextBox>
                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="lbl_grd_monthfourRateofinterest"
                                                                                    ErrorMessage="Please Enter Rate of interest Month4" Display="Dynamic"></asp:RequiredFieldValidator>
                                                                            </td>
                                                                            <td style="font-family: Calibri">
                                                                                <asp:Label ID="lbl_grd_monthfourInterestamount" runat="server"></asp:Label>
                                                                            </td>
                                                                            <td style="font-family: Calibri">
                                                                                <asp:Label ID="lbl_grd_monthfourUnitHolderContribution" runat="server"></asp:Label>
                                                                            </td>
                                                                            <td style="font-family: Calibri">
                                                                                <asp:Label ID="lbl_grd_monthfourEligibleRateofinterest" runat="server"></asp:Label>
                                                                            </td>
                                                                            <td style="font-family: Calibri">
                                                                                <asp:Label ID="lbl_grd_monthfourEligibleInterestAmount" runat="server"></asp:Label>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td style="font-family: Calibri">5</td>
                                                                            <td style="font-family: Calibri">
                                                                                <asp:HiddenField ID="hfgrd_monthfiveid" runat="server" />
                                                                                <asp:Label ID="lbl_grd_monthfivename" runat="server"></asp:Label>

                                                                            </td>
                                                                            <td style="font-family: Calibri">
                                                                                <asp:Label ID="lbl_grd_monthfivePrincipalamounntdue" runat="server"></asp:Label>
                                                                            </td>
                                                                            <td style="font-family: Calibri">
                                                                                <asp:Label ID="lbl_grd_monthfiveNoofInstallment" runat="server"></asp:Label>
                                                                            </td>
                                                                            <td style="font-family: Calibri">
                                                                                <%-- <asp:Label ID="lbl_grd_monthfiveRateofinterest"  runat="server"></asp:Label>--%>
                                                                                <asp:TextBox ID="lbl_grd_monthfiveRateofinterest" runat="server" AutoPostBack="true" OnTextChanged="lbl_grd_monthfiveRateofinterest_TextChanged"
                                                                                    class="form-control txtbox" Height="28px" TabIndex="10" Width="180px"></asp:TextBox>
                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="lbl_grd_monthfiveRateofinterest"
                                                                                    ErrorMessage="Please Enter Rate of interest Month5" Display="Dynamic"></asp:RequiredFieldValidator>
                                                                            </td>
                                                                            <td style="font-family: Calibri">
                                                                                <asp:Label ID="lbl_grd_monthfiveInterestamount" runat="server"></asp:Label>
                                                                            </td>
                                                                            <td style="font-family: Calibri">
                                                                                <asp:Label ID="lbl_grd_monthfiveUnitHolderContribution" runat="server"></asp:Label>
                                                                            </td>
                                                                            <td style="font-family: Calibri">
                                                                                <asp:Label ID="lbl_grd_monthfiveEligibleRateofinterest" runat="server"></asp:Label>
                                                                            </td>
                                                                            <td style="font-family: Calibri">
                                                                                <asp:Label ID="lbl_grd_monthfiveEligibleInterestAmount" runat="server"></asp:Label>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td style="font-family: Calibri">6</td>
                                                                            <td style="font-family: Calibri">
                                                                                <asp:HiddenField ID="hfgrd_monthsixid" runat="server" />
                                                                                <asp:Label ID="lbl_grd_monthsixname" runat="server"></asp:Label>

                                                                            </td>
                                                                            <td style="font-family: Calibri">
                                                                                <asp:Label ID="lbl_grd_monthsixPrincipalamounntdue" runat="server"></asp:Label>
                                                                            </td>
                                                                            <td style="font-family: Calibri">
                                                                                <asp:Label ID="lbl_grd_monthsixNoofInstallment" runat="server"></asp:Label>
                                                                            </td>
                                                                            <td style="font-family: Calibri">
                                                                                <%--  <asp:Label ID="lbl_grd_monthsixRateofinterest"  runat="server"></asp:Label>--%>
                                                                                <asp:TextBox ID="lbl_grd_monthsixRateofinterest" runat="server" AutoPostBack="true" OnTextChanged="lbl_grd_monthsixRateofinterest_TextChanged"
                                                                                    class="form-control txtbox" Height="28px" TabIndex="10" Width="180px"></asp:TextBox>
                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="lbl_grd_monthsixRateofinterest"
                                                                                    ErrorMessage="Please Enter Rate of interest Month5" Display="Dynamic"></asp:RequiredFieldValidator>
                                                                            </td>
                                                                            <td style="font-family: Calibri">
                                                                                <asp:Label ID="lbl_grd_monthsixInterestamount" runat="server"></asp:Label>
                                                                            </td>
                                                                            <td style="font-family: Calibri">
                                                                                <asp:Label ID="lbl_grd_monthsixUnitHolderContribution" runat="server"></asp:Label>
                                                                            </td>
                                                                            <td style="font-family: Calibri">
                                                                                <asp:Label ID="lbl_grd_monthsixEligibleRateofinterest" runat="server"></asp:Label>
                                                                            </td>
                                                                            <td style="font-family: Calibri">
                                                                                <asp:Label ID="lbl_grd_monthsixEligibleInterestAmount" runat="server"></asp:Label>
                                                                            </td>
                                                                        </tr>
                                                                          <tr>
                                                                            <td style="font-family: Calibri">6</td>
                                                                            <td style="font-family: Calibri">
                                                                            </td>
                                                                            <td style="font-family: Calibri">
                                                                            </td>
                                                                            <td style="font-family: Calibri">
                                                                            </td>
                                                                            <td style="font-family: Calibri">
                                                                                Total Interest Amount:
                                                                            </td>
                                                                            <td style="font-family: Calibri">
                                                                                <asp:Label ID="lbl_grd_totmonthsInterestamount" runat="server"></asp:Label>
                                                                            </td>
                                                                            <td style="font-family: Calibri"></td>
                                                                            <td style="font-family: Calibri">Total Eligible Interest Amount:</td>
                                                                            <td style="font-family: Calibri">
                                                                                <asp:Label ID="lbl_grd_totmonthsEligibleInterestAmount" runat="server"></asp:Label>
                                                                            </td>
                                                                        </tr>

                                                                    </table>
                                                                </td>
                                                            </tr>
                                                            <tr>

                                                                <td style="font-family: Calibri"><b>Eligible period in months</b>
                                                                    <br />
                                                                </td>
                                                                <td style="font-family: Calibri">
                                                                    <br />
                                                                    <asp:TextBox ID="txt_grdeglibilepallavaddiEligibleperiodinmonths" runat="server" class="form-control txtbox" Height="28px" AutoPostBack="true" OnTextChanged="txt_grdeglibilepallavaddiEligibleperiodinmonths_TextChanged"
                                                                     Enabled="false"   TabIndex="10" Width="180px"></asp:TextBox>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator122" runat="server" ControlToValidate="txt_grdeglibilepallavaddiEligibleperiodinmonths"
                                                                        ErrorMessage="Please Enter Eligible period in months" Display="Dynamic"></asp:RequiredFieldValidator>
                                                                    <br />
                                                                </td>
                                                                <td style="font-family: Calibri"></td>
                                                                <td style="font-family: Calibri"></td>
                                                            </tr>
                                                            <tr>
                                                                <td style="font-family: Calibri"><b>Insert amount to be paid as per calculations</b></td>
                                                                <td style="font-family: Calibri">
                                                                    <asp:TextBox ID="txt_grdeglibilepallavaddiInsertamounttobepaidaspercalculations" runat="server" class="form-control txtbox" Height="28px" AutoPostBack="true" OnTextChanged="txt_grdeglibilepallavaddiInsertamounttobepaidaspercalculations_TextChanged"
                                                                  Enabled="false"      TabIndex="10" Width="180px"></asp:TextBox>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator123" runat="server" ControlToValidate="txt_grdeglibilepallavaddiInsertamounttobepaidaspercalculations"
                                                                        ErrorMessage="Please Enter Insert amount to be paid as per calculations" Display="Dynamic"></asp:RequiredFieldValidator>
                                                                    <br />
                                                                </td>
                                                                <td style="font-family: Calibri"></td>
                                                                <td style="font-family: Calibri"></td>
                                                            </tr>
                                                            <tr>
                                                                <td style="font-family: Calibri"><b>Actual interest amount paid</b></td>
                                                                <td style="font-family: Calibri">
                                                                    <asp:TextBox ID="txt_grdeglibilepallavaddiActualinterestamountpaid" runat="server" class="form-control txtbox" Height="28px" AutoPostBack="true" OnTextChanged="txt_grdeglibilepallavaddiActualinterestamountpaid_TextChanged"
                                                                        TabIndex="10" Width="180px"></asp:TextBox>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator124" runat="server" ControlToValidate="txt_grdeglibilepallavaddiActualinterestamountpaid"
                                                                        ErrorMessage="Please Enter Actual interest amount paid" Display="Dynamic"></asp:RequiredFieldValidator>
                                                                    <br />
                                                                </td>
                                                                <td style="font-family: Calibri"></td>
                                                                <td style="font-family: Calibri"></td>
                                                            </tr>
                                                             <tr>
                                                                <td style="font-family: Calibri"><b>Rate of Interest</b></td>
                                                                <td style="font-family: Calibri">
                                                                    <asp:TextBox ID="txt_claimeglibleincentivesloanwiseRateofInterest" runat="server" class="form-control txtbox" Height="28px" AutoPostBack="true" OnTextChanged="txt_claimeglibleincentivesloanwiseRateofInterest_TextChanged"
                                                                        TabIndex="10" Width="180px"></asp:TextBox>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator107" runat="server" ControlToValidate="txt_claimeglibleincentivesloanwiseRateofInterest"
                                                                        ErrorMessage="Please Enter Rate of Interest" Display="Dynamic"></asp:RequiredFieldValidator>
                                                                    <br />
                                                                </td>
                                                                <td style="font-family: Calibri">&nbsp;&nbsp;&nbsp; &nbsp;<b>Eligible rate of reimbursement</b></td>
                                                                <td style="font-family: Calibri">
                                                                    <asp:TextBox ID="txt_claimeglibleincentivesloanwiseEligiblerateofreimbursement" runat="server" class="form-control txtbox" Height="28px" AutoPostBack="true" OnTextChanged="txt_claimeglibleincentivesloanwiseEligiblerateofreimbursement_TextChanged"
                                                                     Enabled="false"   TabIndex="10" Width="180px"></asp:TextBox>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator108" runat="server" ControlToValidate="txt_claimeglibleincentivesloanwiseEligiblerateofreimbursement"
                                                                        ErrorMessage="Please Enter Eligible rate of reimbursement" Display="Dynamic"></asp:RequiredFieldValidator>
                                                                    <br />
                                                                </td>

                                                            </tr>
                                                             <tr>
                                                                <td style="font-family: Calibri"><b>Considered Amount for Interest</b></td>
                                                                <td style="font-family: Calibri">
                                                                    <asp:TextBox ID="txt_claimeglibleincentivesloanwiseConsideredAmountforInterest" runat="server" class="form-control txtbox" Height="28px" AutoPostBack="true"  OnTextChanged="txt_claimeglibleincentivesloanwiseConsideredAmountforInterest_TextChanged"
                                                                     Enabled="false"   TabIndex="10" Width="180px"></asp:TextBox>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator10111" runat="server" ControlToValidate="txt_claimeglibleincentivesloanwiseConsideredAmountforInterest"
                                                                        ErrorMessage="Please Enter Considered Amount for Interest" Display="Dynamic"></asp:RequiredFieldValidator>
                                                                    <br />
                                                                </td>
                                                                <td style="font-family: Calibri"></td>
                                                                <td style="font-family: Calibri"></td>
                                                            </tr>
                                                            <tr>
                                                                <td style="font-family: Calibri"><b>Interst reimbursement calculated</b></td>
                                                                <td style="font-family: Calibri">
                                                                    <asp:TextBox ID="txt_grdeglibilepallavaddiInsertreimbursementcalculated" runat="server" class="form-control txtbox" Height="28px" AutoPostBack="true" OnTextChanged="txt_grdeglibilepallavaddiInsertreimbursementcalculated_TextChanged"
                                                                    Enabled="false"    TabIndex="10" Width="180px"></asp:TextBox>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator125" runat="server" ControlToValidate="txt_grdeglibilepallavaddiInsertreimbursementcalculated"
                                                                        ErrorMessage="Please Enter Interst reimbursement calculated" Display="Dynamic"></asp:RequiredFieldValidator>
                                                                    <br />
                                                                </td>
                                                                <td style="font-family: Calibri"></td>
                                                                <td style="font-family: Calibri"></td>
                                                            </tr>
                                                            <tr>
                                                                <td style="font-family: Calibri"><b>Eligible Type</b></td>
                                                                <td style="font-family: Calibri">
                                                                    <asp:RadioButtonList ID="rbtgrdeglibilepallavaddi_isbelated" runat="server" RepeatDirection="Horizontal" AutoPostBack="true" Height="33px" OnSelectedIndexChanged="rbtgrdeglibilepallavaddi_isbelated_SelectedIndexChanged"
                                                                        TabIndex="1" Width="200px">
                                                                        <asp:ListItem Value="0">>1 Year</asp:ListItem>
                                                                        <asp:ListItem Value="Y">Regular</asp:ListItem>
                                                                        <asp:ListItem Value="N">Belated</asp:ListItem>

                                                                    </asp:RadioButtonList>
                                                                    <br />
                                                                </td>
                                                                <td style="font-family: Calibri"></td>
                                                                <td style="font-family: Calibri"></td>
                                                            </tr>
                                                            <tr>
                                                                <td style="font-family: Calibri"><b>Interst reimbursement(After selecting the eglible Type)</b></td>
                                                                <td style="font-family: Calibri">
                                                                    <asp:TextBox ID="txt_grdeglibilepallavaddieglibleamountofreimbursementbyeglibletype" runat="server" class="form-control txtbox" Height="28px" AutoPostBack="true" OnTextChanged="txt_grdeglibilepallavaddieglibleamountofreimbursementbyeglibletype_TextChanged"
                                                                     Enabled="false"   TabIndex="10" Width="180px"></asp:TextBox>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator126" runat="server" ControlToValidate="txt_grdeglibilepallavaddieglibleamountofreimbursementbyeglibletype"
                                                                        ErrorMessage="Please Enter Interst reimbursement(After selecting the eglible Type)" Display="Dynamic"></asp:RequiredFieldValidator>
                                                                    <br />
                                                                </td>
                                                                <td style="font-family: Calibri"></td>
                                                                <td style="font-family: Calibri"></td>
                                                            </tr>
                                                            <tr>
                                                                <td style="font-family: Calibri"><b>GM recommended amount</b></td>
                                                                <td style="font-family: Calibri">
                                                                    <asp:TextBox ID="txt_grdeglibilepallavaddiGMrecommendedamount"  Text='<%# Eval("GM_Rcon_Amount") %>'
                                                                        Enabled="false" runat="server" class="form-control txtbox" Height="28px" AutoPostBack="true" OnTextChanged="txt_grdeglibilepallavaddiGMrecommendedamount_TextChanged"
                                                                        TabIndex="10" Width="180px"></asp:TextBox>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator127" runat="server" ControlToValidate="txt_grdeglibilepallavaddiGMrecommendedamount"
                                                                        ErrorMessage="Please Enter GM recommended amount" Display="Dynamic"></asp:RequiredFieldValidator>
                                                                    <br />
                                                                </td>
                                                                <td style="font-family: Calibri"></td>
                                                                <td style="font-family: Calibri"></td>
                                                            </tr>
                                                            <tr>
                                                                <td style="font-family: Calibri"><b>Eligible amount</b></td>
                                                                <td style="font-family: Calibri">
                                                                    <asp:TextBox ID="txt_grdeglibilepallavaddiEligibleamount" runat="server" class="form-control txtbox" Height="28px" Enabled="false"
                                                                        TabIndex="10" Width="180px"></asp:TextBox>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator128" runat="server" ControlToValidate="txt_grdeglibilepallavaddiEligibleamount"
                                                                        ErrorMessage="Please Enter Eligible amount" Display="Dynamic"></asp:RequiredFieldValidator>
                                                                    <br />
                                                                </td>
                                                                <td style="font-family: Calibri"></td>
                                                                <td style="font-family: Calibri"></td>
                                                            </tr>
                                                          
                                                            <tr>
                                                                <td style="font-family: Calibri"></td>
                                                                <td style="font-family: Calibri"></td>
                                                                <td style="font-family: Calibri"></td>
                                                                <td style="font-family: Calibri"></td>
                                                            </tr>
                                                        </table>
                                                      

                                                    </ItemTemplate>                                            
                                                </asp:TemplateField>    
                                              
                                            </Columns>
                                            <PagerStyle CssClass="gridview"></PagerStyle>
                                        </asp:GridView>
                                           
                                            </td>
                                </tr>
                                </table>
                            </td>
                        </tr>


                         <tr>
                            <td colspan="5">
                                <table style="width: 100%">
                                    <tr>
                                        <td style="padding: 5px; margin: 5px;" class="ui-priority-primary"></td>
                                        <td style="padding: 5px; margin: 5px;">Insert amount to be paid as per calculations</td>
                                        <td style="padding: 5px; margin: 5px;">:
                                        </td>
                                        <td style="padding: 5px; margin: 5px;" class="auto-style28">
                                            <asp:TextBox ID="txt_Insertamounttobepaidaspercalculations" runat="server" class="form-control txtbox" Height="28px" Enabled="false"
                                                TabIndex="10" ValidationGroup="group" Width="180px"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txt_Insertamounttobepaidaspercalculations"
                                                ErrorMessage="Please Enter Insert amount to be paid as per calculations" Display="Dynamic" ValidationGroup="group"></asp:RequiredFieldValidator>
                                        </td>
                                        <td style="padding: 5px; margin: 5px;" class="auto-style20"><strong></strong></td>
                                        <td style="padding: 5px; margin: 5px;" class="auto-style29"></td>
                                        <td style="padding: 5px; margin: 5px;"></td>
                                        <td style="padding: 5px; margin: 5px;">&nbsp; 
                                        </td>
                                        <td style="padding: 5px; margin: 5px;">&nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="padding: 5px; margin: 5px;" class="ui-priority-primary"></td>
                                        <td style="padding: 5px; margin: 5px;">Actual interest amount paid<font
                                            color="red">*</font></td>
                                        <td style="padding: 5px; margin: 5px;">:
                                        </td>
                                        <td style="padding: 5px; margin: 5px;" class="auto-style28">
                                            <asp:TextBox ID="txt_Actualinterestamountpaid" runat="server" class="form-control txtbox" Height="28px" Enabled="false" 
                                                TabIndex="10" ValidationGroup="group" Width="180px"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator49" runat="server" ControlToValidate="txt_Actualinterestamountpaid"
                                                ErrorMessage="Please Enter Actual interest amount paid" Display="Dynamic" ValidationGroup="group"></asp:RequiredFieldValidator>
                                        </td>
                                        <td style="padding: 5px; margin: 5px;" class="auto-style20"><strong></strong></td>
                                        <td style="padding: 5px; margin: 5px;" class="auto-style29"></td>
                                        <td style="padding: 5px; margin: 5px;"></td>
                                        <td style="padding: 5px; margin: 5px;">&nbsp; 
                                        </td>
                                        <td style="padding: 5px; margin: 5px;">&nbsp;
                                        </td>
                                    </tr>
                                      <tr>
                                        <td style="padding: 5px; margin: 5px;" class="ui-priority-primary"></td>
                                        <td style="padding: 5px; margin: 5px;">Considered Amount of Interest<font color="red">*</font></td>
                                        <td style="padding: 5px; margin: 5px;">:
                                        </td>
                                        <td style="padding: 5px; margin: 5px;" class="auto-style28">
                                            <asp:TextBox ID="txt_ConsideredAmountofInterest" runat="server" class="form-control txtbox" Height="28px"  Enabled="false"
                                                TabIndex="10" ValidationGroup="group" Width="180px"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="txt_ConsideredAmountofInterest"
                                                ErrorMessage="Please Enter Considered Amount of Interest" Display="Dynamic" ValidationGroup="group"></asp:RequiredFieldValidator>
                                        </td>
                                        <td style="padding: 5px; margin: 5px;" class="auto-style20"><strong></strong></td>
                                        <td style="padding: 5px; margin: 5px;" class="auto-style29"></td>
                                        <td style="padding: 5px; margin: 5px;"></td>
                                        <td style="padding: 5px; margin: 5px;">&nbsp; 
                                        </td>
                                        <td style="padding: 5px; margin: 5px;">&nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="padding: 5px; margin: 5px;" class="ui-priority-primary"></td>
                                        <td style="padding: 5px; margin: 5px;">Interst reimbursement calculated<font color="red">*</font></td>
                                        <td style="padding: 5px; margin: 5px;">:
                                        </td>
                                        <td style="padding: 5px; margin: 5px;" class="auto-style28">
                                            <asp:TextBox ID="txt_Insertreimbursementcalculated" runat="server" class="form-control txtbox" Height="28px" Enabled="false"
                                                TabIndex="10" ValidationGroup="group" Width="180px"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator50" runat="server" ControlToValidate="txt_Insertreimbursementcalculated"
                                                ErrorMessage="Please Enter Interst reimbursement calculated" Display="Dynamic" ValidationGroup="group"></asp:RequiredFieldValidator>
                                        </td>
                                        <td style="padding: 5px; margin: 5px;" class="auto-style20"><strong></strong></td>
                                        <td style="padding: 5px; margin: 5px;" class="auto-style29"></td>
                                        <td style="padding: 5px; margin: 5px;"></td>
                                        <td style="padding: 5px; margin: 5px;">&nbsp; 
                                        </td>
                                        <td style="padding: 5px; margin: 5px;">&nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="padding: 5px; margin: 5px;" class="ui-priority-primary"></td>
                                        <td style="padding: 5px; margin: 5px;">Interst reimbursement(After selecting the eglible Type)<font color="red">*</font></td>
                                        <td style="padding: 5px; margin: 5px;">:
                                        </td>
                                        <td style="padding: 5px; margin: 5px;" class="auto-style28">
                                            <asp:TextBox ID="txt_eglibleamountofreimbursementbyeglibletype" runat="server" class="form-control txtbox" Height="28px" Enabled="false"
                                                TabIndex="10" ValidationGroup="group" Width="180px"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txt_eglibleamountofreimbursementbyeglibletype"
                                                ErrorMessage="Please Enter Interst reimbursement(After selecting the eglible Type)" Display="Dynamic" ValidationGroup="group"></asp:RequiredFieldValidator>
                                        </td>
                                        <td style="padding: 5px; margin: 5px;" class="auto-style20"><strong></strong></td>
                                        <td style="padding: 5px; margin: 5px;" class="auto-style29"></td>
                                        <td style="padding: 5px; margin: 5px;"></td>
                                        <td style="padding: 5px; margin: 5px;">&nbsp; 
                                        </td>
                                        <td style="padding: 5px; margin: 5px;">&nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="padding: 5px; margin: 5px;" class="ui-priority-primary"></td>
                                        <td style="padding: 5px; margin: 5px;">GM recommended amount<font color="red">*</font></td>
                                        <td style="padding: 5px; margin: 5px;">:
                                        </td>
                                        <td style="padding: 5px; margin: 5px;" class="auto-style28">
                                            <asp:TextBox ID="txt_GMrecommendedamount" runat="server" class="form-control txtbox" Enabled="false" Height="28px" AutoPostBack="true" OnTextChanged="txt_GMrecommendedamount_TextChanged"
                                                TabIndex="10" ValidationGroup="group" Width="180px"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator51" runat="server" ControlToValidate="txt_GMrecommendedamount"
                                                ErrorMessage="Please Enter GM recommended amount" Display="Dynamic" ValidationGroup="group"></asp:RequiredFieldValidator>
                                        </td>
                                        <td style="padding: 5px; margin: 5px;" class="auto-style20"><strong></strong></td>
                                        <td style="padding: 5px; margin: 5px;" class="auto-style29"></td>
                                        <td style="padding: 5px; margin: 5px;"></td>
                                        <td style="padding: 5px; margin: 5px;">&nbsp; 
                                        </td>
                                        <td style="padding: 5px; margin: 5px;">&nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="padding: 5px; margin: 5px;" class="ui-priority-primary"></td>
                                        <td style="padding: 5px; margin: 5px;">Eligible amount</td>
                                        <td style="padding: 5px; margin: 5px;">:
                                        </td>
                                        <td style="padding: 5px; margin: 5px;" class="auto-style28">
                                            <asp:TextBox ID="txt_Eligibleamount" runat="server" class="form-control txtbox" Height="28px" Enabled="false"
                                                TabIndex="10" ValidationGroup="group" Width="180px"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator52" runat="server" ControlToValidate="txt_Eligibleamount"
                                                ErrorMessage="Please Enter Eligible amount" Display="Dynamic" ValidationGroup="group"></asp:RequiredFieldValidator>
                                        </td>
                                        <td style="padding: 5px; margin: 5px;" class="auto-style20"><strong></strong></td>
                                        <td style="padding: 5px; margin: 5px;" class="auto-style29"></td>
                                        <td style="padding: 5px; margin: 5px;"></td>
                                        <td style="padding: 5px; margin: 5px;">&nbsp; 
                                        </td>
                                        <td style="padding: 5px; margin: 5px;">&nbsp;
                                        </td>
                                    </tr>
                                      <tr>
                                                                <td style="font-family: Calibri"><b>Remarks</b></td>
                                                                <td style="font-family: Calibri">
                                                                    <asp:TextBox ID="txt_TotalRemarks" runat="server" class="form-control txtbox" Height="28px" 
                                                                   ValidationGroup="group"     TabIndex="10" Width="300px"></asp:TextBox>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="txt_TotalRemarks"
                                                                        ErrorMessage="Please Enter Remarks" ValidationGroup="group" Display="Dynamic"></asp:RequiredFieldValidator>
                                                                    <br />
                                                                </td>
                                                                <td style="font-family: Calibri"></td>
                                                                <td style="font-family: Calibri"></td>
                                                            </tr>
                                </table>
                            </td>
                        </tr>


                    
                        <tr>
                            <td align="center" colspan="3" style="padding: 5px; margin: 5px; text-align: center;">
                                <asp:Button ID="BtnSave" runat="server" CssClass="btn btn-primary" Height="32px" OnClick="BtnSave_Click" TabIndex="24" Text="Save" ValidationGroup="group" Width="90px" />
                                &nbsp;&nbsp;&nbsp; &nbsp;<asp:Button ID="BtnClearall" runat="server" CausesValidation="False" CssClass="btn btn-warning" OnClick="BtnClearall_Click" Height="32px" Text="Clear" ToolTip="To Clear  the Screen" Width="90px" />
                                &nbsp;&nbsp;&nbsp; &nbsp;<asp:Button ID="btm_previous" runat="server" CausesValidation="False" CssClass="btn btn-primary" OnClick="btm_previous_Click" Height="32px" TabIndex="25"  Text="Previous" ToolTip="Payment" Width="90px" />
                            </td>
                        </tr>
                        <tr>
                            <td align="center" colspan="3" style="padding: 5px; margin: 5px">
                                <div id="success" runat="server" class="alert alert-success" visible="false">
                                    <a aria-label="close" class="close" data-dismiss="alert" href="#">×</a> <strong>Success!</strong><asp:Label ID="lblmsg" runat="server"></asp:Label>
                                </div>
                                <div id="Failure" runat="server" class="alert alert-danger" visible="false">
                                    <a aria-label="close" class="close" data-dismiss="alert" href="#">×</a> <strong>Warning!</strong>
                                    <asp:Label ID="lblmsg0" runat="server"></asp:Label>
                                </div>
                            </td>
                        </tr>
                    </table>
                    <table align="center" cellpadding="10" cellspacing="5" style="width: 90%">
                    </table>
                    <asp:HiddenField ID="hdfID" runat="server" />
                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
                        ShowSummary="False" ValidationGroup="group" />
                    <asp:ValidationSummary ID="ValidationSummary3" runat="server" ShowMessageBox="True"
                        ShowSummary="False" ValidationGroup="group1" />
                    <asp:ValidationSummary ID="ValidationSummary2" runat="server" ShowMessageBox="True"
                        ShowSummary="False" ValidationGroup="child" />
                </div>
            </div>
        </div>
    </div>
<asp:UpdateProgress ID="UpdateProgress" runat="server" AssociatedUpdatePanelID="upd1">
                <ProgressTemplate>
                    <div class="update">
                    </div>
                </ProgressTemplate>
            </asp:UpdateProgress>
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
        </ContentTemplate>

         <Triggers>
             
             <asp:PostBackTrigger ControlID="grd_eglibilepallavaddi" />
              <asp:PostBackTrigger ControlID="grd_claimperiodofloanadd" />
       <%--   <asp:PostBackTrigger ControlID="txt_eglsacamountinterestreimbursement" />
            <asp:PostBackTrigger ControlID="ddl_ClaimPeriod" />
            <asp:PostBackTrigger ControlID="txt_DateofCommencementofactivity" />
            <asp:PostBackTrigger ControlID="ddl_periodofinstallment" />
            <asp:PostBackTrigger ControlID="txt_noofinstallment" />
            <asp:PostBackTrigger ControlID="txt_Installmentamount" />
            <asp:PostBackTrigger ControlID="txt_installmentstartdate" />
            <asp:PostBackTrigger ControlID="txt_RateofInterest" />
             <asp:PostBackTrigger ControlID="txt_Eligiblerateofreimbursement" />
             <asp:PostBackTrigger ControlID="txt_Noofinstallmentscompleted" />
             <asp:PostBackTrigger ControlID="txt_PrincipalamountbecomeDUEbeforethisHALFYEAR" />--%>
           <%--  <asp:PostBackTrigger ControlID="btnfupLayoutoftheevent" />--%>
        </Triggers>
    </asp:UpdatePanel>

    <script type="text/javascript">
        $('.timepicker').timepicker({
            timeFormat: 'h:mm p',
            interval: 30,
            minTime: '12:00AM',
            maxTime: '11:30pm',
            startTime: '12:00 AM',
            defaultTime: '12:00 AM',
            dynamic: false,
            dropdown: true,
            scrollbar: true
        });
        function pageLoad() {
            var date = new Date();
            var currentMonth = date.getMonth();
            var currentDate = date.getDate();
            var currentYear = date.getFullYear();

            $('txtPerformancetimingsfrm.timepicker').timepicker({});

            $("input[id$='txtStartDate']").datepicker(
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
            $("input[id$='txtEndDate']").datepicker(
                {
                    //dateFormat: "dd/mm/yy",
                    dateFormat: "dd/mm/yy",
                    //maxDate: new Date(currentYear, currentMonth, currentDate)
                });
        });
        <style type="text/css">
            .ui-datepicker
        {
                font - size: 8pt !important;
height: 250px;
padding: 0.2em 0.2em 0;
width: 250px;
}
    </style>
    </script>
    <script type="text/javascript">
        function CallPrint(strid) {
            var prtContent = document.getElementById(strid);
            var WinPrint = window.open('', '', 'letf=0,top=0,width=0,height=0,toolbar=0,scrollbars=1,status=0');
            var strOldOne = prtContent.innerHTML;
            WinPrint.document.write(prtContent.innerHTML);
            WinPrint.document.close();
            WinPrint.focus();
            WinPrint.print();
            WinPrint.close();
            prtContent.innerHTML = strOldOne;
        }
    </script>
    <script type="text/javascript">
        function pageLoad() {
            var date = new Date();
            var currentMonth = date.getMonth();
            var currentDate = date.getDate();
            var currentYear = date.getFullYear();

            $("input[id$='txt_claimeglibleincentivesloanwiseinstallmentstartdate']").datepicker(
                {
                    dateFormat: "dd-mm-yy",
                });

            $("input[id$='txt_claimeglibleincentivesloanwiseDateofCommencementofactivity']").datepicker(
                {
                    dateFormat: "dd-mm-yy",
                });

            $("input[id$='txtCalenderDCP']").datepicker(
                {
                    dateFormat: "dd-mm-yy",
                }); // Will run at every postback/AsyncPostback
            //txtquery_dic
            //
            $("input[id$='txtContProdMgm']").datepicker(
                {
                    dateFormat: "dd-mm-yy",
                });

            $("input[id$='TextBox3']").datepicker(
                {
                    dateFormat: "dd-mm-yy",
                });
            $("input[id$='txtquery_dic']").datepicker(
                {
                    dateFormat: "dd-mm-yy",
                });
            //txtquery_coi
            $("input[id$='txtquery_coi']").datepicker(
                {
                    dateFormat: "dd-mm-yy",
                });
            $("input[id$='txtDateOfapplnFile']").datepicker(
                {
                    dateFormat: "dd-mm-yy",

                });
            //txtPowerConn_date  txtrc_dic
            $("input[id$='txtrc_dic']").datepicker(
                {
                    dateFormat: "dd-mm-yy",

                });
            //txtcompdate_dic
            $("input[id$='txtcompdate_dic']").datepicker(
                {
                    dateFormat: "dd-mm-yy",

                });
            //txtcompdate_coi
            $("input[id$='txtcompdate_coi']").datepicker(
                {
                    dateFormat: "dd-mm-yy",

                });
            //txtcompdate_coi1
            $("input[id$='txtcompdate_coi1']").datepicker(
                {
                    dateFormat: "dd-mm-yy",

                });
            $("input[id$='txtPowerConn_date']").datepicker(
                {
                    dateFormat: "dd-mm-yy",

                });
            $("input[id$='txtDate_Loan']").datepicker(
                {
                    dateFormat: "dd-mm-yy",
                }); // Will run at every postback/AsyncPostback
            $("input[id$='txtDCP_unit']").datepicker(
                {
                    dateFormat: "dd-mm-yy",
                }); // Will run at every postback/AsyncPostback
            $("input[id$='txtApplClm']").datepicker(
                {
                    dateFormat: "dd-mm-yy",
                }); // Will run at every postback/AsyncPostback
            $("input[id$='txtDateShrtfall']").datepicker(
                {
                    dateFormat: "dd-mm-yy",
                }); // Will run at every postback/AsyncPostback
            $("input[id$='txtDtShrtFallRcvd']").datepicker(
                {
                    dateFormat: "dd-mm-yy",
                }); // Will run at every postback/AsyncPostback
        }
        $(function () {
            var date = new Date();
            var currentMonth = date.getMonth();
            var currentDate = date.getDate();
            var currentYear = date.getFullYear();
            $("input[id$='txtCalenderDCP']").datepicker(
                {
                    dateFormat: "dd-mm-yy",
                    //maxDate: new Date(currentYear, currentMonth, currentDate)
                });
            $("input[id$='txt_claimeglibleincentivesloanwiseinstallmentstartdate']").datepicker(
                {
                    dateFormat: "dd-mm-yy",
                    //maxDate: new Date(currentYear, currentMonth, currentDate)
                });

            $("input[id$='txt_claimeglibleincentivesloanwiseDateofCommencementofactivity']").datepicker(
                {
                    dateFormat: "dd-mm-yy",
                    //maxDate: new Date(currentYear, currentMonth, currentDate)
                });

            $("input[id$='txtApplClm']").datepicker(
                {
                    dateFormat: "dd-mm-yy",

                    //maxDate: new Date(currentYear, currentMonth, currentDate)
                });
            $("input[id$='txtDateOfapplnFile']").datepicker(
                {
                    dateFormat: "dd-mm-yy",
                    //maxDate: new Date(currentYear, currentMonth, currentDate)
                });
            $("input[id$='txtDtShrtFallRcvd']").datepicker(
                {
                    dateFormat: "dd-mm-yy",
                    //maxDate: new Date(currentYear, currentMonth, currentDate)
                });
            $("input[id$='TextBox3']").datepicker(
                {
                    dateFormat: "dd-mm-yy",
                    //maxDate: new Date(currentYear, currentMonth, currentDate)
                });
            $("input[id$='TextBox4']").datepicker(
                {
                    dateFormat: "dd-mm-yy",
                    //maxDate: new Date(currentYear, currentMonth, currentDate)
                });
            $("input[id$='txtcompdate_coi']").datepicker(
                {
                    dateFormat: "dd-mm-yy",
                    //maxDate: new Date(currentYear, currentMonth, currentDate)
                });
            console.log($(".txtcomn").length);
            var option_all = '';
            $("input[id$='chkMobileUnit']").change(function () {
                if (this.checked) {

                    option_all = $(".txtcomn").map(function () {
                        if ($.trim($(this).val()) == '') {
                            return "#" + $(this).attr('Id');
                        }
                    }).get().join(',');

                    console.log(option_all);

                    if (option_all) {
                        $(option_all).val('0')
                    }
                }
                else {
                    $(option_all).val('')
                }
            });
        });
    </script>

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
</asp:Content>

