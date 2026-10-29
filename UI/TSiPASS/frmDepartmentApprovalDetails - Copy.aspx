<%@ Page Title=":: TS-iPASS ::  " Language="C#" MasterPageFile="~/UI/TSiPASS/CCMaster.master"
    AutoEventWireup="true" CodeFile="frmDepartmentApprovalDetails.aspx.cs" Inherits="TSTBDCReg1" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script src="../../Resource/Scripts/js/validations.js" type="text/javascript"></script>
    <style type="text/css">
        .overlay
        {
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
        
        .CS
        {
            background-color: #abcdef;
            color: Yellow;
            border: 1px solid #1d9a5b;
            font: Verdana 10px;
            padding: 1px 4px;
            font-family: Palatino Linotype, Arial, Helvetica, sans-serif;
        }
        
        .update
        {
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
        
        .style7
        {
            color: #FF3300;
        }
        
        .style8
        {
            color: #FF0000;
            font-weight: bold;
        }
        
        .GRD
        {
            width: 800px;
            height: auto;
            border-color: #013161;
            border-style: solid;
            border-width: 1px;
            text-transform: capitalize;
            padding: 5px;
        }
        
        .GRDHEADER
        {
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
        
        .GRDITEM
        {
            /*background-color: WHITE;*/
            color: black;
            font-size: 12px;
            font-weight: normal;
            font-family: Verdana;
            padding: 10px; /*text-decoration:none;*/ /*border-color:#013161;*/ /*border-style:solid;*/
            text-transform: uppercase; /*border-width:1px;*/ /*height:23px;*/ /*text-indent:5px;*/ /*BACKGROUND-IMAGE: url(../images/grid_bg_.gif);*/
        }
        
        .LBLBLACK
        {
        }
    </style>
    <script type="text/javascript" language="javascript">

        function OpenPopup() {

            window.open("Lookups/LookupBDC.aspx", "List", "scrollbars=yes,resizable=yes,width=1000,height=650;display = block;position=absolute");

            return false;
        }
    </script>
    <script type="text/javascript">
        function showModal() {
            $("#ctl00_ContentPlaceHolder1_txtmarketvalue").val('');
            $("#myModal").modal({ backdrop: 'static', keyboard: false });
        }
      
    </script>
    <script language="javascript" type="text/javascript">
        var hexvalues
            = Array("A", "B", "C", "D", "E", "F", "0", "1", "2", "3", "4", "5", "6", "7", "8", "9");

        function flashtext() {

            var colour = '#';
            for (var counter = 1; counter <= 6; counter++) {
                var hexvalue = hexvalues[Math.floor(hexvalues.length * Math.random())];

                colour = colour + hexvalue;

            }
            document.getElementById("flashingtext").style.color = colour;
        }

        setInterval("flashtext()", 500);
        function flashtext1() {

            var colour = '#';
            for (var counter = 1; counter <= 6; counter++) {
                var hexvalue = hexvalues[Math.floor(hexvalues.length * Math.random())];

                colour = colour + hexvalue;

            }
            document.getElementById("flashingtext1").style.color = colour;
        }

        setInterval("flashtext1()", 500);
        function flashtext2() {

            var colour = '#';
            for (var counter = 1; counter <= 6; counter++) {
                var hexvalue = hexvalues[Math.floor(hexvalues.length * Math.random())];

                colour = colour + hexvalue;

            }
            document.getElementById("flashingtext2").style.color = colour;
        }

        setInterval("flashtext2()", 500);


    </script>
    <%-- <script type="text/javascript">
        function showProgress() {
            var updateProgress = $get("<%= UpdateProgress.ClientID %>");
            updateProgress.style.display = "block";
        }
    </script>--%>
    <link href="assets/css/basic.css" rel="stylesheet" />
    <%--  <asp:UpdatePanel ID="upd1" runat="server">
        <ContentTemplate>--%>
    <div align="left">
        <ol class="breadcrumb">
            You are here &nbsp;!&nbsp; &nbsp; &nbsp;
            <li><i class="fa fa-dashboard"></i><a href="Home.aspx"></a></li>
            <li class=""><i class="fa fa-fw fa-edit">CAF</i> </li>
            <li class="active"><i class="fa fa-edit"></i>&nbsp; &nbsp;<a href="#">Departments</a>
            </li>
        </ol>
    </div>
    <div align="left">
        <div class="row" align="left">
            <div class="col-lg-12">
                <%--<div class="panel panel-primary">
                            <div class="panel-heading" align="center">
                                <h3 class="panel-title">Departments</h3>
                            </div>--%>
                <table>
                    <tr>
                        <td>
                            <div class="col-md-12">
                                <h1 class="page-head-line" align="left" style="font-size: x-large">
                                    Departments</h1>
                            </div>
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>
                                    <div class="panel-body">
                                        <table align="left" cellpadding="10" cellspacing="5" style="width: 100%">
                                            <tr>
                                                <td style="padding: 5px; margin: 5px; font-size: 13pt" valign="top" class="style8">
                                                    The following are the Approvals required for Establishment of your Unit. Please
                                                    select the Approvals for which you intend to apply for.
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="padding: 5px; margin: 5px" valign="top">
                                                    <div style="width: 100%">
                                                        <asp:GridView ID="grdDetails" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                                            CssClass="GRD" ForeColor="#333333" Height="62px" OnRowDataBound="grdDetails_RowDataBound"
                                                            PageSize="15" ShowFooter="True" Width="100%" CellSpacing="4">
                                                            <FooterStyle BackColor="#be8c2f" HorizontalAlign="Center" Font-Bold="True" ForeColor="White" />
                                                            <RowStyle BackColor="#EBF2FE" CssClass="GRDITEM" HorizontalAlign="Left" VerticalAlign="Middle" />
                                                            <Columns>
                                                                <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S No">
                                                                    <ItemTemplate>
                                                                        <%# Container.DataItemIndex + 1%>
                                                                        <asp:HiddenField ID="HdfQueid" runat="server" />
                                                                        <asp:HiddenField ID="HdfApprovalid" runat="server" />
                                                                        <asp:HiddenField ID="HdfDeptid" runat="server" />
                                                                    </ItemTemplate>
                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                    <ItemStyle Width="50px" />
                                                                </asp:TemplateField>
                                                                <asp:BoundField DataField="ApprovalName" HeaderText="Approval Required for">
                                                                    <ItemStyle Width="450px" />
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="Dept_Full_name" HeaderText="Department Name">
                                                                    <ItemStyle Width="180px" />
                                                                </asp:BoundField>
                                                                <asp:TemplateField HeaderText="Whether approval already obtained">
                                                                    <ItemTemplate>
                                                                        <asp:RadioButtonList ID="RdWhetherAlreadyApproved" runat="server" AutoPostBack="True"
                                                                            OnSelectedIndexChanged="RdWhetherAlreadyApproved_SelectedIndexChanged" RepeatDirection="Horizontal">
                                                                            <asp:ListItem Value="Y">Yes</asp:ListItem>
                                                                            <asp:ListItem Selected="True" Value="N">No</asp:ListItem>
                                                                        </asp:RadioButtonList>
                                                                        <asp:HiddenField ID="HdfAmount" runat="server" OnValueChanged="HdfAmount_ValueChanged" />
                                                                        <itemstyle horizontalalign="Center" width="140px" />
                                                                    </ItemTemplate>
                                                                    <ItemStyle HorizontalAlign="Center" Width="140px" />
                                                                </asp:TemplateField>
                                                                <asp:BoundField DataField="Fees" DataFormatString="{0:0}" ItemStyle-HorizontalAlign="Right"
                                                                    FooterStyle-HorizontalAlign="Right" HeaderText="Fee(Rs.)">
                                                                    <ControlStyle CssClass="col-md-6" />
                                                                    <FooterStyle HorizontalAlign="Right" />
                                                                    <HeaderStyle HorizontalAlign="Right" />
                                                                    <ItemStyle CssClass="GRDITEM2" HorizontalAlign="Right" />
                                                                </asp:BoundField>
                                                                <asp:TemplateField HeaderText="Apply for Approval">
                                                                    <ItemTemplate>
                                                                        <asp:CheckBox ID="ChkApproval" runat="server" AutoPostBack="True" OnCheckedChanged="ChkApproval_CheckedChanged" />
                                                                    </ItemTemplate>
                                                                    <ItemStyle HorizontalAlign="Center" Width="140px" />
                                                                </asp:TemplateField>
                                                        <%--        <asp:BoundField HeaderText="Amount(Rs.)">
                                                                    <FooterStyle CssClass="GRDITEM2" ForeColor="White" HorizontalAlign="Right" />
                                                                    <HeaderStyle HorizontalAlign="Right" />
                                                                    <ItemStyle CssClass="GRDITEM2" HorizontalAlign="Right" Width="100px" />
                                                                </asp:BoundField>--%>

                                                                      <asp:TemplateField HeaderText="Amount">
                                                                    <ItemTemplate >
                                                                        <asp:Label ID="lblAmounts" runat="server" Text="Label"></asp:Label>
                                                                       
                                                                        <itemstyle horizontalalign="Center" width="140px" />
                                                                    </ItemTemplate>
                                                                    <ItemStyle HorizontalAlign="Center" Width="140px" />
                                                                </asp:TemplateField>

                                                            </Columns>
                                                            <PagerStyle BackColor="#013161" ForeColor="White" HorizontalAlign="Center" />
                                                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                                            <HeaderStyle BackColor="#1d9a5b" CssClass="GRDHEADER" Font-Bold="True" ForeColor="White" />
                                                            <EditRowStyle BackColor="#B9D684" />
                                                            <AlternatingRowStyle BackColor="White" />
                                                        </asp:GridView>
                                                    </div>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="padding: 5px; margin: 5px" align="center" class="style7">
                                                    &nbsp;
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:HiddenField ID="hdfID" runat="server" />
                                                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
                                                        ShowSummary="False" ValidationGroup="group" />
                                                    <asp:ValidationSummary ID="ValidationSummary2" runat="server" ShowMessageBox="True"
                                                        ShowSummary="False" ValidationGroup="child" />
                                                    <asp:HiddenField ID="hdfFlagID" runat="server" />
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                            <%--   </div>--%>
                        </td>
                    </tr>
                    <tr>
                        <td align="center" style="padding: 5px; margin: 5px; text-align: left;">
                            <div class="panel panel-primary">
                                <div class="panel-heading" align="center">
                                    <h4 class="panel-title">
                                        Note</h4>
                                </div>
                                <div class="panel-body">
                                    <div id="flashingtext" style="font-size: 15px;">
                                        <b>
                                            <h4>
                                            1. Initial Department fee has to be paid through TS-iPASS online system.</b>
                                        <br />
                                        <br />
                                        <b>2. Any Additional payment raised by the department has to be paid through TS-iPASS
                                            online system.</b>
                                        <br />
                                        <br />
                                        <b>3. If any payment done through the respective department will not be considered and
                                            stage of the application will not be escalated.</b></h4>
                                    </div>
                                </div>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td align="center" style="padding: 5px; margin: 5px; text-align: center;">
                            <asp:Button ID="BtnClear" runat="server" CausesValidation="False" CssClass="btn btn-warning"
                                Height="32px" OnClick="BtnClear_Click" TabIndex="10" Text="ClearAll" ToolTip="To Clear  the Screen"
                                Width="90px" />&nbsp;&nbsp;
                            <asp:Button ID="BtnSave1" runat="server" CssClass="btn btn-primary" Height="32px"
                                OnClick="BtnSave_Click" TabIndex="10" Text="Save" ValidationGroup="group" Width="90px"
                                Visible="False" />
                            &nbsp;&nbsp;<asp:Button ID="BtnDelete" runat="server" CausesValidation="False" CssClass="btn btn-danger"
                                Height="32px" OnClick="BtnClear0_Click" TabIndex="10" Text="Submit" Width="90px" />
                        </td>
                    </tr>
                    <tr>
                        <td style="padding: 5px; margin: 5px" align="center" class="style7">
                        </td>
                    </tr>
                    <tr>
                        <td align="center" style="padding: 5px; margin: 5px">
                            <div id="success" runat="server" visible="false" class="alert alert-success">
                                <a href="AddQualification.aspx" class="close" data-dismiss="alert" aria-label="close">
                                    &times;</a> <strong>Success!</strong><asp:Label ID="lblmsg" runat="server"></asp:Label>
                            </div>
                            <div id="Failure" runat="server" visible="false" class="alert alert-danger">
                                <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a> <strong>
                                    Warning!</strong>
                                <asp:Label ID="lblmsg0" runat="server"></asp:Label>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td align="center">
                            <div id="attachmentsdiv" runat="server" visible="false">
                                <div class="panel panel-primary">
                                    <div class="panel-heading" align="center">
                                        <h3 class="panel-title">
                                            Department Approval taken offline</h3>
                                    </div>
                                    <div class="panel-body">
                                        <table style="width: 90%; border: 2px; border-collapse: separate;">
                                            <%-- <tr id="Panelpcb2" runat="server">
                                                <td style="padding: 5px; margin: 5px; text-align: center;" colspan="5" align="center">
                                                    <asp:Label ID="Label458" runat="server" Font-Size="Large" CssClass="LBLBLACK" Font-Bold="True"
                                                        Width="350px">Department Approval taken offline</asp:Label>
                                                </td>
                                            </tr>--%>
                                            <tr id="Panelpcb" runat="server" visible="false">
                                                <td style="padding: 5px; margin: 5px; text-align: left;">
                                                    <asp:Label ID="Label455" runat="server" CssClass="LBLBLACK" Width="165px">Reference 
                                                        Number<font 
                                                            color="red">*</font></asp:Label>
                                                </td>
                                                <td style="padding: 5px; margin: 5px">
                                                    :
                                                </td>
                                                <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                    <asp:TextBox ID="txtPCBRefNo" runat="server" class="form-control txtbox" Height="28px"
                                                        MaxLength="40" TabIndex="1" ValidationGroup="group" Width="180px" OnTextChanged="txtcontact6_TextChanged"></asp:TextBox>
                                                </td>
                                                <td style="padding: 5px; margin: 5px;">
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtPCBRefNo"
                                                        ErrorMessage="Please enter Reference Number for PCB Approval Document" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr id="Panelpcb1" runat="server" visible="false">
                                                <td style="padding: 5px; margin: 5px; text-align: left; border-bottom: 2px solid #00CA79;">
                                                    <asp:Label ID="Label452" runat="server" CssClass="LBLBLACK" Width="350px">Upload 
                                                        Polution Control Board Approval Document<font 
                                                            color="red">*</font></asp:Label>
                                                </td>
                                                <td style="padding: 5px; margin: 5px; border-bottom: 2px solid #00CA79;">
                                                    :
                                                </td>
                                                <td class="style6" style="padding: 5px; margin: 5px; text-align: left; border-bottom: 2px solid #00CA79;">
                                                    <asp:FileUpload ID="FileUpload10" runat="server" CssClass="CS" Height="28px" />
                                                    <asp:HyperLink ID="Label453" runat="server" CssClass="LBLBLACK" Width="165px" Target="_blank"></asp:HyperLink>
                                                    <br />
                                                    <asp:Label ID="Label454" runat="server" Visible="False"></asp:Label>
                                                </td>
                                                <td style="padding: 5px; margin: 5px; border-bottom: 2px solid #00CA79;">
                                                    <asp:Button ID="Button8" runat="server" CssClass="btn btn-xs btn-warning" Height="28px"
                                                        TabIndex="10" Text="Upload" ValidationGroup="gg" Width="72px" OnClick="Button8_Click" />
                                                </td>
                                            </tr>
                                            <tr id="panelTSCT" runat="server" visible="false">
                                                <td style="padding: 5px; margin: 5px; text-align: left;">
                                                    <asp:Label ID="Label6" runat="server" CssClass="LBLBLACK" Width="165px">Reference 
                                                        Number<font 
                                                            color="red">*</font></asp:Label>
                                                </td>
                                                <td style="padding: 5px; margin: 5px">
                                                    :
                                                </td>
                                                <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                    <asp:TextBox ID="txtTSCTRefNo" runat="server" class="form-control txtbox" Height="28px"
                                                        MaxLength="40" TabIndex="1" ValidationGroup="group" Width="180px" OnTextChanged="txtcontact6_TextChanged"></asp:TextBox>
                                                </td>
                                                <td style="padding: 5px; margin: 5px;">
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtTSCTRefNo"
                                                        ErrorMessage="Please enter Reference Number for  Commercial Taxes Approval Document"
                                                        ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr id="panelTSCT1" runat="server" visible="false">
                                                <td style="padding: 5px; margin: 5px; text-align: left; border-bottom: 2px solid #00CA79;">
                                                    <asp:Label ID="Label7" runat="server" CssClass="LBLBLACK" Width="350px">Upload 
                                                        Commercial Taxes Approval Document<font 
                                                            color="red">*</font></asp:Label>
                                                </td>
                                                <td style="padding: 5px; margin: 5px; border-bottom: 2px solid #00CA79;">
                                                    :
                                                </td>
                                                <td class="style6" style="padding: 5px; margin: 5px; text-align: left; border-bottom: 2px solid #00CA79;">
                                                    <asp:FileUpload ID="FileUpload11" runat="server" CssClass="CS" Height="28px" />
                                                    <asp:HyperLink ID="HyperLink1" runat="server" CssClass="LBLBLACK" Width="165px" Target="_blank"></asp:HyperLink>
                                                    <br />
                                                    <asp:Label ID="Label8" runat="server" Visible="False"></asp:Label>
                                                </td>
                                                <td style="padding: 5px; margin: 5px; border-bottom: 2px solid #00CA79;">
                                                    <asp:Button ID="Button9" runat="server" CssClass="btn btn-xs btn-warning" Height="28px"
                                                        TabIndex="10" Text="Upload" ValidationGroup="gg" Width="72px" OnClick="Button9_Click" />
                                                </td>
                                            </tr>
                                            <tr id="panelTSIIC" runat="server" visible="false">
                                                <td style="padding: 5px; margin: 5px; text-align: left;">
                                                    <asp:Label ID="Label9" runat="server" CssClass="LBLBLACK" Width="165px">Reference 
                                                        Number<font 
                                                            color="red">*</font></asp:Label>
                                                </td>
                                                <td style="padding: 5px; margin: 5px">
                                                    :
                                                </td>
                                                <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                    <asp:TextBox ID="TextBox2" runat="server" CssClass="CS" Height="28px" MaxLength="40"
                                                        TabIndex="1" ValidationGroup="group" Width="180px" OnTextChanged="txtcontact6_TextChanged"></asp:TextBox>
                                                </td>
                                                <td style="padding: 5px; margin: 5px;">
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TextBox2"
                                                        ErrorMessage="Please enter Reference Number for TSIIC Approval Document" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr id="panelTSIIC1" runat="server" visible="false">
                                                <td style="padding: 5px; margin: 5px; text-align: left; border-bottom: 2px solid #00CA79;">
                                                    <asp:Label ID="Label10" runat="server" CssClass="LBLBLACK" Width="350px">Upload 
                                                        TSIIC Approval Document<font 
                                                            color="red">*</font></asp:Label>
                                                </td>
                                                <td style="padding: 5px; margin: 5px; text-align: left; border-bottom: 2px solid #00CA79;">
                                                    :
                                                </td>
                                                <td class="style6" style="padding: 5px; margin: 5px; text-align: left; border-bottom: 2px solid #00CA79;">
                                                    <asp:FileUpload ID="FileUpload12" runat="server" class="form-control txtbox" Height="28px" />
                                                    <asp:HyperLink ID="HyperLink2" runat="server" CssClass="LBLBLACK" Width="165px" Target="_blank"></asp:HyperLink>
                                                    <br />
                                                    <asp:Label ID="Label11" runat="server" Visible="False"></asp:Label>
                                                </td>
                                                <td style="padding: 5px; margin: 5px; border-bottom: 2px solid #00CA79;">
                                                    <asp:Button ID="Button10" runat="server" CssClass="btn btn-xs btn-warning" Height="28px"
                                                        TabIndex="10" Text="Upload" ValidationGroup="gg" Width="72px" OnClick="Button10_Click" />
                                                </td>
                                            </tr>
                                            <tr id="panelPRD" runat="server" visible="false">
                                                <td style="padding: 5px; margin: 5px; text-align: left;">
                                                    <asp:Label ID="Label12" runat="server" CssClass="LBLBLACK" Width="165px">Reference 
                                                        Number<font 
                                                            color="red">*</font></asp:Label>
                                                </td>
                                                <td style="padding: 5px; margin: 5px;">
                                                    :
                                                </td>
                                                <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                    <asp:TextBox ID="TextBox3" runat="server" class="form-control txtbox" Height="28px"
                                                        MaxLength="40" TabIndex="1" ValidationGroup="group" Width="180px" OnTextChanged="txtcontact6_TextChanged"></asp:TextBox>
                                                </td>
                                                <td style="padding: 5px; margin: 5px;">
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="TextBox3"
                                                        ErrorMessage="Please enter Reference Number for Panchayat Raj Approval Document"
                                                        ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr id="panelPRD1" runat="server" visible="false">
                                                <td style="padding: 5px; margin: 5px; text-align: left; border-bottom: 2px solid #00CA79;">
                                                    <asp:Label ID="Label13" runat="server" CssClass="LBLBLACK" Width="303px">Upload 
                                                        Panchayat Raj Approval Document<font 
                                                            color="red">*</font></asp:Label>
                                                </td>
                                                <td style="padding: 5px; margin: 5px; border-bottom: 2px solid #00CA79;">
                                                    &nbsp;:&nbsp;
                                                </td>
                                                <td class="style6" style="padding: 5px; margin: 5px; text-align: left; border-bottom: 2px solid #00CA79;">
                                                    <asp:FileUpload ID="FileUpload13" runat="server" CssClass="CS" Height="28px" />
                                                    <asp:HyperLink ID="HyperLink3" runat="server" CssClass="LBLBLACK" Width="165px" Target="_blank"></asp:HyperLink>
                                                    <br />
                                                    <asp:Label ID="Label14" runat="server" Visible="False"></asp:Label>
                                                </td>
                                                <td style="padding: 5px; margin: 5px; border-bottom: 2px solid #00CA79;">
                                                    <asp:Button ID="Button11" runat="server" CssClass="btn btn-xs btn-warning" Height="28px"
                                                        TabIndex="10" Text="Upload" ValidationGroup="gg" Width="72px" OnClick="Button11_Click" />
                                                </td>
                                            </tr>
                                            <tr id="panelDISCOM" runat="server" visible="false">
                                                <td style="padding: 5px; margin: 5px; text-align: left;">
                                                    <asp:Label ID="Label15" runat="server" CssClass="LBLBLACK" Width="165px">Reference 
                                                        Number<font 
                                                            color="red">*</font></asp:Label>
                                                </td>
                                                <td style="padding: 5px; margin: 5px">
                                                    :
                                                </td>
                                                <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                    <asp:TextBox ID="TextBox4" runat="server" class="form-control txtbox" Height="28px"
                                                        MaxLength="40" TabIndex="1" ValidationGroup="group" Width="180px" OnTextChanged="txtcontact6_TextChanged"></asp:TextBox>
                                                </td>
                                                <td style="padding: 5px; margin: 5px;">
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="TextBox4"
                                                        ErrorMessage="Please enter Reference Number for DISCOM Approval Document" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr id="panelDISCOM1" runat="server" visible="false">
                                                <td style="padding: 5px; margin: 5px; text-align: left; border-bottom: 2px solid #00CA79;">
                                                    <asp:Label ID="Label16" runat="server" CssClass="LBLBLACK" Width="272px">Upload 
                                                        DISCOM Approval Document<font 
                                                            color="red">*</font></asp:Label>
                                                </td>
                                                <td style="border-bottom: 2px solid #00CA79;">
                                                    :
                                                </td>
                                                <td class="style6" style="padding: 5px; margin: 5px; text-align: left; border-bottom: 2px solid #00CA79;">
                                                    <asp:FileUpload ID="FileUpload14" runat="server" class="form-control txtbox" Height="28px"
                                                        CssClass="CS" />
                                                    <asp:HyperLink ID="HyperLink4" runat="server" CssClass="LBLBLACK" Width="165px" Target="_blank"></asp:HyperLink>
                                                    <br />
                                                    <asp:Label ID="Label17" runat="server" Visible="False"></asp:Label>
                                                </td>
                                                <td style="padding: 5px; margin: 5px; border-bottom: 2px solid #00CA79;">
                                                    <asp:Button ID="Button12" runat="server" CssClass="btn btn-xs btn-warning" Height="28px"
                                                        TabIndex="10" Text="Upload" ValidationGroup="gg" Width="72px" OnClick="Button12_Click" />
                                                </td>
                                            </tr>
                                            <tr id="panelCEIG" runat="server" visible="false">
                                                <td style="padding: 5px; margin: 5px; text-align: left;">
                                                    <asp:Label ID="Label18" runat="server" CssClass="LBLBLACK" Width="165px">Reference 
                                                        Number<font 
                                                            color="red">*</font></asp:Label>
                                                </td>
                                                <td style="padding: 5px; margin: 5px">
                                                    :
                                                </td>
                                                <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                    <asp:TextBox ID="TextBox5" runat="server" class="form-control txtbox" Height="28px"
                                                        MaxLength="40" TabIndex="1" ValidationGroup="group" Width="180px" OnTextChanged="txtcontact6_TextChanged"></asp:TextBox>
                                                </td>
                                                <td style="padding: 5px; margin: 5px;">
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="TextBox5"
                                                        ErrorMessage="Please enter Reference Number for Electrical Inspectorate Approval Document"
                                                        ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr id="panelCEIG1" runat="server" visible="false">
                                                <td style="padding: 5px; margin: 5px; text-align: left; border-bottom: 2px solid #00CA79;">
                                                    <asp:Label ID="Label19" runat="server" CssClass="LBLBLACK" Width="350px">Upload 
                                                        Electrical Inspectorate Approval Document<font 
                                                            color="red">*</font></asp:Label>
                                                </td>
                                                <td style="border-bottom: 2px solid #00CA79;">
                                                    :
                                                </td>
                                                <td class="style6" style="padding: 5px; margin: 5px; text-align: left; border-bottom: 2px solid #00CA79;">
                                                    <asp:FileUpload ID="FileUpload15" runat="server" class="form-control txtbox" Height="28px"
                                                        CssClass="CS" />
                                                    <asp:HyperLink ID="HyperLink5" runat="server" CssClass="LBLBLACK" Width="165px" Target="_blank"></asp:HyperLink>
                                                    <br />
                                                    <asp:Label ID="Label20" runat="server" Visible="False"></asp:Label>
                                                </td>
                                                <td style="padding: 5px; margin: 5px; border-bottom: 2px solid #00CA79;">
                                                    <asp:Button ID="Button13" runat="server" CssClass="btn btn-xs btn-warning" Height="28px"
                                                        TabIndex="10" Text="Upload" ValidationGroup="gg" Width="72px" OnClick="Button13_Click" />
                                                </td>
                                            </tr>
                                            <%----------------13-------------------------------------------------------%>
                                            <tr id="panelTSNPDCL" runat="server" visible="false">
                                                <td style="padding: 5px; margin: 5px; text-align: left;">
                                                    <asp:Label ID="Label21" runat="server" CssClass="LBLBLACK" Width="165px">Reference 
                                                        Number<font 
                                                            color="red">*</font></asp:Label>
                                                </td>
                                                <td style="padding: 5px; margin: 5px">
                                                    :
                                                </td>
                                                <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                    <asp:TextBox ID="TextBox6" runat="server" class="form-control txtbox" Height="28px"
                                                        MaxLength="40" TabIndex="1" ValidationGroup="group" Width="180px" OnTextChanged="txtcontact6_TextChanged"></asp:TextBox>
                                                </td>
                                                <td style="padding: 5px; margin: 5px;">
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="TextBox6"
                                                        ErrorMessage="Please enter Reference Number for TSNPDCL Approval Document" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr id="panelTSNPDCL1" runat="server" visible="false">
                                                <td style="padding: 5px; margin: 5px; text-align: left; border-bottom: 2px solid #00CA79;">
                                                    <asp:Label ID="Label22" runat="server" CssClass="LBLBLACK" Width="300px">Upload 
                                                        TSNPDCL Approval Document<font 
                                                            color="red"*</font></asp:Label>
                                                </td>
                                                <td style="border-bottom: 2px solid #00CA79;">
                                                    :
                                                </td>
                                                <td class="style6" style="padding: 5px; margin: 5px; text-align: left; border-bottom: 2px solid #00CA79;">
                                                    <asp:FileUpload ID="FileUpload16" runat="server" class="form-control txtbox" Height="28px"
                                                        CssClass="CS" />
                                                    <asp:HyperLink ID="HyperLink6" runat="server" CssClass="LBLBLACK" Width="165px" Target="_blank"></asp:HyperLink>
                                                    <br />
                                                    <asp:Label ID="Label23" runat="server" Visible="False"></asp:Label>
                                                </td>
                                                <td style="padding: 5px; margin: 5px; border-bottom: 2px solid #00CA79;">
                                                    <asp:Button ID="Button14" runat="server" CssClass="btn btn-xs btn-warning" Height="28px"
                                                        TabIndex="10" Text="Upload" ValidationGroup="gg" Width="72px" OnClick="Button14_Click" />
                                                </td>
                                            </tr>
                                            <%-----------------13------------------------------------------------------%>
                                            <%----------------14-------------------------------------------------------%>
                                            <tr id="panelTSSPDCL" runat="server" visible="false">
                                                <td style="padding: 5px; margin: 5px; text-align: left;">
                                                    <asp:Label ID="Label24" runat="server" CssClass="LBLBLACK" Width="165px">Reference 
                                                        Number<font 
                                                            color="red">*</font></asp:Label>
                                                </td>
                                                <td style="padding: 5px; margin: 5px">
                                                    :
                                                </td>
                                                <td style="padding: 5px; margin: 5px">
                                                    <asp:TextBox ID="TextBox7" runat="server" class="form-control txtbox" Height="28px"
                                                        MaxLength="40" TabIndex="1" ValidationGroup="group" Width="180px" OnTextChanged="txtcontact6_TextChanged"></asp:TextBox>
                                                </td>
                                                <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="TextBox7"
                                                        ErrorMessage="Please enter Reference Number for TSSPDCL Approval Document " ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr id="panelTSSPDCL1" runat="server" visible="false">
                                                <td style="padding: 5px; margin: 5px; text-align: left; border-bottom: 2px solid #00CA79;">
                                                    <asp:Label ID="Label25" runat="server" CssClass="LBLBLACK" Width="300px">Upload 
                                                        TSSPDCL Approval Document :</asp:Label>
                                                </td>
                                                <td style="border-bottom: 2px solid #00CA79;">
                                                    :
                                                </td>
                                                <td class="style6" style="padding: 5px; margin: 5px; text-align: left; border-bottom: 2px solid #00CA79;">
                                                    <asp:FileUpload ID="FileUpload17" runat="server" class="form-control txtbox" Height="28px"
                                                        CssClass="CS" />
                                                    <asp:HyperLink ID="HyperLink7" runat="server" CssClass="LBLBLACK" Width="165px" Target="_blank"></asp:HyperLink>
                                                    <br />
                                                    <asp:Label ID="Label26" runat="server" Visible="False"></asp:Label>
                                                </td>
                                                <td style="padding: 5px; margin: 5px; border-bottom: 2px solid #00CA79;">
                                                    <asp:Button ID="Button15" runat="server" CssClass="btn btn-xs btn-warning" Height="28px"
                                                        TabIndex="10" Text="Upload" ValidationGroup="gg" Width="72px" OnClick="Button15_Click" />
                                                </td>
                                            </tr>
                                            <%-----------------14------------------------------------------------------%>
                                            <%----------------15-------------------------------------------------------%>
                                            <tr id="panelFACT" runat="server" visible="false">
                                                <td style="padding: 5px; margin: 5px; text-align: left;">
                                                    <asp:Label ID="Label27" runat="server" CssClass="LBLBLACK" Width="165px">Reference 
                                                        Number<font 
                                                            color="red">*</font></asp:Label>
                                                </td>
                                                <td style="padding: 5px; margin: 5px">
                                                    :
                                                </td>
                                                <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                    <asp:TextBox ID="TextBox8" runat="server" class="form-control txtbox" Height="28px"
                                                        MaxLength="40" TabIndex="1" ValidationGroup="group" Width="180px" OnTextChanged="txtcontact6_TextChanged"></asp:TextBox>
                                                </td>
                                                <td style="padding: 5px; margin: 5px;">
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="TextBox8"
                                                        ErrorMessage="Please enter Reference Number for Factories Approval Document"
                                                        ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr id="panelFACT1" runat="server" visible="false">
                                                <td style="padding: 5px; margin: 5px; text-align: left; border-bottom: 2px solid #00CA79;">
                                                    <asp:Label ID="Label28" runat="server" CssClass="LBLBLACK" Width="318px">Upload 
                                                        Factories Approval Document</asp:Label>
                                                </td>
                                                <td style="border-bottom: 2px solid #00CA79;">
                                                    :
                                                </td>
                                                <td class="style6" style="padding: 5px; margin: 5px; text-align: left; border-bottom: 2px solid #00CA79;">
                                                    <asp:FileUpload ID="FileUpload18" runat="server" class="form-control txtbox" Height="28px"
                                                        CssClass="CS" />
                                                    <asp:HyperLink ID="HyperLink8" runat="server" CssClass="LBLBLACK" Width="165px" Target="_blank"></asp:HyperLink>
                                                    <br />
                                                    <asp:Label ID="Label29" runat="server" Visible="False"></asp:Label>
                                                </td>
                                                <td style="padding: 5px; margin: 5px; border-bottom: 2px solid #00CA79;">
                                                    <asp:Button ID="Button16" runat="server" CssClass="btn btn-xs btn-warning" Height="28px"
                                                        TabIndex="10" Text="Upload" ValidationGroup="gg" Width="72px" OnClick="Button16_Click" />
                                                </td>
                                            </tr>
                                            <%-----------------15------------------------------------------------------%>
                                            <%----------------16-------------------------------------------------------%>
                                            <tr id="panelINDUS" runat="server" visible="false">
                                                <td style="padding: 5px; margin: 5px; text-align: left;">
                                                    <asp:Label ID="Label30" runat="server" CssClass="LBLBLACK" Width="165px">Reference 
                                                        Number<font 
                                                            color="red">*</font></asp:Label>
                                                </td>
                                                <td style="padding: 5px; margin: 5px">
                                                    :
                                                </td>
                                                <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                    <asp:TextBox ID="TextBox9" runat="server" class="form-control txtbox" Height="28px"
                                                        MaxLength="40" TabIndex="1" ValidationGroup="group" Width="180px" OnTextChanged="txtcontact6_TextChanged"></asp:TextBox>
                                                </td>
                                                <td style="padding: 5px; margin: 5px;">
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="TextBox9"
                                                        ErrorMessage="Please enter Reference Number for Industries" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr id="panelINDUS1" runat="server" visible="false">
                                                <td style="padding: 5px; margin: 5px; text-align: left; border-bottom: 2px solid #00CA79;">
                                                    <asp:Label ID="Label456" runat="server" CssClass="LBLBLACK" Width="165px">Industries</asp:Label>
                                                </td>
                                                <td style="border-bottom: 2px solid #00CA79;">
                                                    :
                                                </td>
                                                <td class="style6" style="padding: 5px; margin: 5px; text-align: left; border-bottom: 2px solid #00CA79;">
                                                    <asp:FileUpload ID="FileUpload19" runat="server" class="form-control txtbox" Height="28px"
                                                        CssClass="CS" />
                                                    <asp:HyperLink ID="HyperLink9" runat="server" CssClass="LBLBLACK" Width="165px" Target="_blank"></asp:HyperLink>
                                                    <br />
                                                    <asp:Label ID="Label32" runat="server" Visible="False"></asp:Label>
                                                </td>
                                                <td style="padding: 5px; margin: 5px; border-bottom: 2px solid #00CA79;">
                                                    <asp:Button ID="Button17" runat="server" CssClass="btn btn-xs btn-warning" Height="28px"
                                                        TabIndex="10" Text="Upload" ValidationGroup="gg" Width="72px" OnClick="Button17_Click" />
                                                </td>
                                            </tr>
                                            <%-----------------16------------------------------------------------------%>
                                            <%----------------17-------------------------------------------------------%>
                                            <tr id="panelHMDA" runat="server" visible="false">
                                                <td style="padding: 5px; margin: 5px; text-align: left;">
                                                    <asp:Label ID="Label33" runat="server" CssClass="LBLBLACK" Width="165px">Reference 
                                                        Number<font 
                                                            color="red">*</font></asp:Label>
                                                </td>
                                                <td style="padding: 5px; margin: 5px">
                                                    :
                                                </td>
                                                <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                    <asp:TextBox ID="TextBox10" runat="server" class="form-control txtbox" Height="28px"
                                                        MaxLength="40" TabIndex="1" ValidationGroup="group" Width="180px" OnTextChanged="txtcontact6_TextChanged"></asp:TextBox>
                                                </td>
                                                <td style="padding: 5px; margin: 5px;">
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="TextBox10"
                                                        ErrorMessage="Please enter Reference Number for HMDA Approval Document" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr id="panelHMDA1" runat="server" visible="false">
                                                <td style="padding: 5px; margin: 5px; text-align: left; border-bottom: 2px solid #00CA79;">
                                                    <asp:Label ID="Label457" runat="server" CssClass="LBLBLACK" Width="302px">Upload 
                                                        HMDA Approval Document</asp:Label>
                                                </td>
                                                <td style="border-bottom: 2px solid #00CA79;">
                                                    :
                                                </td>
                                                <td class="style6" style="padding: 5px; margin: 5px; text-align: left; border-bottom: 2px solid #00CA79;">
                                                    <asp:FileUpload ID="FileUpload20" runat="server" class="form-control txtbox" Height="28px"
                                                        CssClass="CS" />
                                                    <asp:HyperLink ID="HyperLink10" runat="server" CssClass="LBLBLACK" Width="165px"
                                                        Target="_blank"></asp:HyperLink>
                                                    <br />
                                                    <asp:Label ID="Label35" runat="server" Visible="False"></asp:Label>
                                                </td>
                                                <td style="padding: 5px; margin: 5px; border-bottom: 2px solid #00CA79;">
                                                    <asp:Button ID="Button18" runat="server" CssClass="btn btn-xs btn-warning" Height="28px"
                                                        TabIndex="10" Text="Upload" ValidationGroup="gg" Width="72px" OnClick="Button18_Click" />
                                                </td>
                                            </tr>
                                            <%-----------------17------------------------------------------------------%>
                                            <%----------------18-------------------------------------------------------%>
                                            <tr id="panelCCLA" runat="server" visible="false">
                                                <td style="padding: 5px; margin: 5px; text-align: left;">
                                                    <asp:Label ID="Label36" runat="server" CssClass="LBLBLACK" Width="165px">Reference 
                                                        Number<font 
                                                            color="red">*</font></asp:Label>
                                                </td>
                                                <td style="padding: 5px; margin: 5px">
                                                    :
                                                </td>
                                                <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                    <asp:TextBox ID="TextBox11" runat="server" class="form-control txtbox" Height="28px"
                                                        MaxLength="40" TabIndex="1" ValidationGroup="group" Width="180px" OnTextChanged="txtcontact6_TextChanged"></asp:TextBox>
                                                </td>
                                                <td style="padding: 5px; margin: 5px;">
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="TextBox11"
                                                        ErrorMessage="Please enter Reference Number for CCLA Approval Document" ValidationGroup="group"
                                                        EnableViewState="False">*</asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr id="panelCCLA1" runat="server" visible="false">
                                                <td style="padding: 5px; margin: 5px; text-align: left; border-bottom: 2px solid #00CA79;">
                                                    <asp:Label ID="Label31" runat="server" CssClass="LBLBLACK" Width="310px">Upload 
                                                        CCLA Approval Document</asp:Label>
                                                </td>
                                                <td style="border-bottom: 2px solid #00CA79;">
                                                    :
                                                </td>
                                                <td class="style6" style="padding: 5px; margin: 5px; text-align: left; border-bottom: 2px solid #00CA79;">
                                                    <asp:FileUpload ID="FileUpload21" runat="server" class="form-control txtbox" Height="28px"
                                                        CssClass="CS" />
                                                    <asp:HyperLink ID="HyperLink11" runat="server" CssClass="LBLBLACK" Width="165px"
                                                        Target="_blank"></asp:HyperLink>
                                                    <br />
                                                    <asp:Label ID="Label38" runat="server" Visible="False"></asp:Label>
                                                </td>
                                                <td style="padding: 5px; margin: 5px; border-bottom: 2px solid #00CA79;">
                                                    <asp:Button ID="Button19" runat="server" CssClass="btn btn-xs btn-warning" Height="28px"
                                                        TabIndex="10" Text="Upload" ValidationGroup="gg" Width="72px" OnClick="Button19_Click" />
                                                </td>
                                            </tr>
                                            <%-----------------18------------------------------------------------------%>
                                            <%----------------19-------------------------------------------------------%>
                                            <tr id="panelDTCP" runat="server" visible="false">
                                                <td style="padding: 5px; margin: 5px; text-align: left;">
                                                    <asp:Label ID="Label39" runat="server" CssClass="LBLBLACK" Width="165px">Reference 
                                                        Number<font 
                                                            color="red">*</font></asp:Label>
                                                </td>
                                                <td style="padding: 5px; margin: 5px">
                                                    :
                                                </td>
                                                <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                    <asp:TextBox ID="TextBox12" runat="server" class="form-control txtbox" Height="28px"
                                                        MaxLength="40" TabIndex="1" ValidationGroup="group" Width="180px" OnTextChanged="txtcontact6_TextChanged"></asp:TextBox>
                                                </td>
                                                <td style="padding: 5px; margin: 5px;">
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="TextBox12"
                                                        ErrorMessage="Please enter Reference Number for District Town and Country Planning Approval Document"
                                                        ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr id="panelDTCP1" runat="server" visible="false">
                                                <td style="padding: 5px; margin: 5px; text-align: left; border-bottom: 2px solid #00CA79;">
                                                    <asp:Label ID="Label34" runat="server" CssClass="LBLBLACK" Width="350px">Upload 
                                                        District Town and Country Planning Approval Document</asp:Label>
                                                </td>
                                                <td style="border-bottom: 2px solid #00CA79;">
                                                    :
                                                </td>
                                                <td class="style6" style="padding: 5px; margin: 5px; text-align: left; border-bottom: 2px solid #00CA79;">
                                                    <asp:FileUpload ID="FileUpload22" runat="server" class="form-control txtbox" Height="28px"
                                                        CssClass="CS" />
                                                    <asp:HyperLink ID="HyperLink12" runat="server" CssClass="LBLBLACK" Width="165px"
                                                        Target="_blank"></asp:HyperLink>
                                                    <br />
                                                    <asp:Label ID="Label41" runat="server" Visible="False"></asp:Label>
                                                </td>
                                                <td style="padding: 5px; margin: 5px; border-bottom: 2px solid #00CA79;">
                                                    <asp:Button ID="Button20" runat="server" CssClass="btn btn-xs btn-warning" Height="28px"
                                                        TabIndex="10" Text="Upload" ValidationGroup="gg" Width="72px" OnClick="Button20_Click" />
                                                </td>
                                            </tr>
                                            <%-----------------19------------------------------------------------------%>
                                            <%----------------20-------------------------------------------------------%>
                                            <tr id="panelFIRE" runat="server" visible="false">
                                                <td style="padding: 5px; margin: 5px; text-align: left;">
                                                    <asp:Label ID="Label42" runat="server" CssClass="LBLBLACK" Width="165px">Reference 
                                                        Number<font 
                                                            color="red">*</font></asp:Label>
                                                </td>
                                                <td style="padding: 5px; margin: 5px">
                                                    :
                                                </td>
                                                <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                    <asp:TextBox ID="TextBox13" runat="server" class="form-control txtbox" Height="28px"
                                                        MaxLength="40" TabIndex="1" ValidationGroup="group" Width="180px" OnTextChanged="txtcontact6_TextChanged"></asp:TextBox>
                                                </td>
                                                <td style="padding: 5px; margin: 5px;">
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ControlToValidate="TextBox13"
                                                        ErrorMessage="Please enter Reference Number for Fire Approval Document" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr id="panelFIRE1" runat="server" visible="false">
                                                <td style="padding: 5px; margin: 5px; text-align: left; border-bottom: 2px solid #00CA79;">
                                                    <asp:Label ID="Label37" runat="server" CssClass="LBLBLACK" Width="306px">Upload 
                                                        Fire Approval Document</asp:Label>
                                                </td>
                                                <td style="border-bottom: 2px solid #00CA79;">
                                                    :
                                                </td>
                                                <td class="style6" style="padding: 5px; margin: 5px; text-align: left; border-bottom: 2px solid #00CA79;">
                                                    <asp:FileUpload ID="FileUpload23" runat="server" class="form-control txtbox" Height="28px"
                                                        CssClass="CS" />
                                                    <asp:HyperLink ID="HyperLink13" runat="server" CssClass="LBLBLACK" Width="165px"
                                                        Target="_blank"></asp:HyperLink>
                                                    <br />
                                                    <asp:Label ID="Label44" runat="server" Visible="False"></asp:Label>
                                                </td>
                                                <td style="padding: 5px; margin: 5px; border-bottom: 2px solid #00CA79;">
                                                    <asp:Button ID="Button21" runat="server" CssClass="btn btn-xs btn-warning" Height="28px"
                                                        TabIndex="10" Text="Upload" ValidationGroup="gg" Width="72px" OnClick="Button21_Click" />
                                                </td>
                                            </tr>
                                            <%-----------------20------------------------------------------------------%>
                                            <%-- <asp:CommandField HeaderText="Delete" ShowDeleteButton="True" />
                                            --%>
                                            <tr id="panelGW" runat="server" visible="false">
                                                <td style="padding: 5px; margin: 5px; text-align: left;">
                                                    <asp:Label ID="Label45" runat="server" CssClass="LBLBLACK" Width="165px">Reference 
                                                        Number<font 
                                                            color="red">*</font></asp:Label>
                                                </td>
                                                <td style="padding: 5px; margin: 5px">
                                                    : &nbsp;
                                                </td>
                                                <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                    <asp:TextBox ID="TextBox14" runat="server" class="form-control txtbox" Height="28px"
                                                        MaxLength="40" TabIndex="1" ValidationGroup="group" Width="180px" OnTextChanged="txtcontact6_TextChanged"></asp:TextBox>
                                                </td>
                                                <td style="padding: 5px; margin: 5px;">
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" ControlToValidate="TextBox14"
                                                        ErrorMessage="Please enter Reference Number for Ground Water Approval Document"
                                                        ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr id="panelGW1" runat="server" visible="false">
                                                <td style="padding: 5px; margin: 5px; text-align: left; border-bottom: 2px solid #00CA79;">
                                                    <asp:Label ID="Label40" runat="server" CssClass="LBLBLACK" Width="282px">Upload 
                                                        Ground Water Approval Document</asp:Label>
                                                </td>
                                                <td style="border-bottom: 2px solid #00CA79;">
                                                    :
                                                </td>
                                                <td class="style6" style="padding: 5px; margin: 5px; text-align: left; border-bottom: 2px solid #00CA79;">
                                                    <asp:FileUpload ID="FileUpload24" runat="server" class="form-control txtbox" Height="28px"
                                                        CssClass="CS" />
                                                    <asp:HyperLink ID="HyperLink14" runat="server" CssClass="LBLBLACK" Width="165px"
                                                        Target="_blank"></asp:HyperLink>
                                                    <br />
                                                    <asp:Label ID="Label47" runat="server" Visible="False"></asp:Label>
                                                </td>
                                                <td style="padding: 5px; margin: 5px; border-bottom: 2px solid #00CA79;">
                                                    <asp:Button ID="Button22" runat="server" CssClass="btn btn-xs btn-warning" Height="28px"
                                                        TabIndex="10" Text="Upload" ValidationGroup="gg" Width="72px" OnClick="Button22_Click" />
                                                </td>
                                            </tr>
                                            <%--       </ContentTemplate>
</asp:UpdatePanel>--%>
                                            <%-- <asp:UpdateProgress ID="UpdateProgress" runat="server" AssociatedUpdatePanelID="updatepanel1">
<ProgressTemplate>--%>
                                            <tr id="panelHMWSSB" runat="server" visible="false">
                                                <td style="padding: 5px; margin: 5px; text-align: left;">
                                                    <asp:Label ID="Label48" runat="server" CssClass="LBLBLACK" Width="165px">Reference 
                                                        Number<font 
                                                            color="red">*</font></asp:Label>
                                                </td>
                                                <td style="padding: 5px; margin: 5px">
                                                    :
                                                </td>
                                                <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                    <asp:TextBox ID="TextBox15" runat="server" class="form-control txtbox" Height="28px"
                                                        MaxLength="40" TabIndex="1" ValidationGroup="group" Width="180px" OnTextChanged="txtcontact6_TextChanged"></asp:TextBox>
                                                </td>
                                                <td style="padding: 5px; margin: 5px;">
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server" ControlToValidate="TextBox15"
                                                        ErrorMessage="Please enter Reference Number for HMWSSB Approval Document" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr id="panelHMWSSB1" runat="server" visible="false">
                                                <td style="padding: 5px; margin: 5px; text-align: left; border-bottom: 2px solid #00CA79;">
                                                    <asp:Label ID="Label43" runat="server" CssClass="LBLBLACK" Width="294px">Upload 
                                                        HMWSSB Approval Document</asp:Label>
                                                </td>
                                                <td style="border-bottom: 2px solid #00CA79;">
                                                    :
                                                </td>
                                                <td class="style6" style="padding: 5px; margin: 5px; text-align: left; border-bottom: 2px solid #00CA79;">
                                                    <asp:FileUpload ID="FileUpload25" runat="server" class="form-control txtbox" Height="28px"
                                                        CssClass="CS" />
                                                    <asp:HyperLink ID="HyperLink15" runat="server" CssClass="LBLBLACK" Width="165px"
                                                        Target="_blank"></asp:HyperLink>
                                                    <br />
                                                    <asp:Label ID="Label50" runat="server" Visible="False"></asp:Label>
                                                </td>
                                                <td style="padding: 5px; margin: 5px; border-bottom: 2px solid #00CA79;">
                                                    <asp:Button ID="Button23" runat="server" CssClass="btn btn-xs btn-warning" Height="28px"
                                                        TabIndex="10" Text="Upload" ValidationGroup="gg" Width="72px" OnClick="Button23_Click" />
                                                </td>
                                            </tr>
                                            <%--<div class="overlay">--%>
                                            <%--<div style=" z-index: 1000; margin-left: 350px;margin-top:200px;opacity: 1;-moz-opacity: 1;">--%>
                                            <tr id="panelEXCISE" runat="server" visible="false">
                                                <td style="padding: 5px; margin: 5px; text-align: left;">
                                                    <asp:Label ID="Label51" runat="server" CssClass="LBLBLACK" Width="165px">Reference 
                                                        Number<font 
                                                            color="red">*</font></asp:Label>
                                                </td>
                                                <td style="padding: 5px; margin: 5px">
                                                    :
                                                </td>
                                                <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                    <asp:TextBox ID="TextBox16" runat="server" class="form-control txtbox" Height="28px"
                                                        MaxLength="40" TabIndex="1" ValidationGroup="group" Width="180px" OnTextChanged="txtcontact6_TextChanged"></asp:TextBox>
                                                </td>
                                                <td style="padding: 5px; margin: 5px;">
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator17" runat="server" ControlToValidate="TextBox16"
                                                        ErrorMessage="Please enter Reference Number for Excise Department Approval Document"
                                                        ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr id="panelEXCISE1" runat="server" visible="false">
                                                <td style="padding: 5px; margin: 5px; text-align: left; border-bottom: 2px solid #00CA79;">
                                                    <asp:Label ID="Label46" runat="server" CssClass="LBLBLACK" Width="350px">Upload 
                                                        Excise Department Approval Document</asp:Label>
                                                </td>
                                                <td style="border-bottom: 2px solid #00CA79;">
                                                    :
                                                </td>
                                                <td class="style6" style="padding: 5px; margin: 5px; text-align: left; border-bottom: 2px solid #00CA79;">
                                                    <asp:FileUpload ID="FileUpload26" runat="server" class="form-control txtbox" Height="28px"
                                                        CssClass="CS" />
                                                    <asp:HyperLink ID="HyperLink16" runat="server" CssClass="LBLBLACK" Width="165px"
                                                        Target="_blank"></asp:HyperLink>
                                                    <br />
                                                    <asp:Label ID="Label53" runat="server" Visible="False"></asp:Label>
                                                </td>
                                                <td style="padding: 5px; margin: 5px; border-bottom: 2px solid #00CA79;">
                                                    <asp:Button ID="Button24" runat="server" CssClass="btn btn-xs btn-warning" Height="28px"
                                                        TabIndex="10" Text="Upload" ValidationGroup="gg" Width="72px" OnClick="Button24_Click" />
                                                </td>
                                            </tr>
                                            <%--<div style=" z-index: 1000; margin-left: -210px;margin-top:100px;opacity: 1; -moz-opacity: 1;">--%>
                                            <%--<img alt="" src="../../Resource/Images/Processing.gif" />
                                            --%>
                                            <tr id="panelREGSTAMP" runat="server" visible="false">
                                                <td style="padding: 5px; margin: 5px; text-align: left;">
                                                    <asp:Label ID="Label54" runat="server" CssClass="LBLBLACK" Width="165px">Reference 
                                                        Number<font 
                                                            color="red">*</font></asp:Label>
                                                </td>
                                                <td style="padding: 5px; margin: 5px">
                                                    :
                                                </td>
                                                <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                    <asp:TextBox ID="TextBox17" runat="server" class="form-control txtbox" Height="28px"
                                                        MaxLength="40" TabIndex="1" ValidationGroup="group" Width="180px" OnTextChanged="txtcontact6_TextChanged"></asp:TextBox>
                                                </td>
                                                <td style="padding: 5px; margin: 5px;">
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator18" runat="server" ControlToValidate="TextBox17"
                                                        ErrorMessage="Please enter Reference Number for Registrations and Stamps Approval Document"
                                                        ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr id="panelREGSTAMP1" runat="server" visible="false">
                                                <td style="padding: 5px; margin: 5px; text-align: left; border-bottom: 2px solid #00CA79;">
                                                    <asp:Label ID="Label49" runat="server" CssClass="LBLBLACK" Width="350px">Upload 
                                                        Registrations and Stamps Approval Document</asp:Label>
                                                </td>
                                                <td style="border-bottom: 2px solid #00CA79;">
                                                    :
                                                </td>
                                                <td class="style6" style="padding: 5px; margin: 5px; text-align: left; border-bottom: 2px solid #00CA79;">
                                                    <asp:FileUpload ID="FileUpload27" runat="server" class="form-control txtbox" Height="28px"
                                                        CssClass="CS" />
                                                    <asp:HyperLink ID="HyperLink17" runat="server" CssClass="LBLBLACK" Width="165px"
                                                        Target="_blank"></asp:HyperLink>
                                                    <br />
                                                    <asp:Label ID="Label56" runat="server" Visible="False"></asp:Label>
                                                </td>
                                                <td style="padding: 5px; margin: 5px; border-bottom: 2px solid #00CA79;">
                                                    <asp:Button ID="Button25" runat="server" CssClass="btn btn-xs btn-warning" Height="28px"
                                                        TabIndex="10" Text="Upload" ValidationGroup="gg" Width="72px" OnClick="Button25_Click" />
                                                </td>
                                            </tr>
                                            <%--</ProgressTemplate>
</asp:UpdateProgress> --%>
                                            <%--</ContentTemplate>
  </asp:UpdatePanel>--%>
                                            <tr id="panelDCA" runat="server" visible="false">
                                                <td style="padding: 5px; margin: 5px; text-align: left;">
                                                    <asp:Label ID="Label57" runat="server" CssClass="LBLBLACK" Width="165px">Reference 
                                                        Number<font 
                                                            color="red">*</font></asp:Label>
                                                </td>
                                                <td style="padding: 5px; margin: 5px">
                                                    :
                                                </td>
                                                <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                    <asp:TextBox ID="TextBox18" runat="server" class="form-control txtbox" Height="28px"
                                                        MaxLength="40" TabIndex="1" ValidationGroup="group" Width="180px" OnTextChanged="txtcontact6_TextChanged"></asp:TextBox>
                                                </td>
                                                <td style="padding: 5px; margin: 5px;">
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator19" runat="server" ControlToValidate="TextBox18"
                                                        ErrorMessage="Please enter Reference Number for Drugs Control Administration Approval Document"
                                                        ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr id="panelDCA1" runat="server" visible="false">
                                                <td style="padding: 5px; margin: 5px; text-align: left; border-bottom: 2px solid #00CA79;">
                                                    <asp:Label ID="Label52" runat="server" CssClass="LBLBLACK" Width="350px">Upload 
                                                        Drugs Control Administration Approval Document</asp:Label>
                                                </td>
                                                <td style="border-bottom: 2px solid #00CA79;">
                                                    :
                                                </td>
                                                <td class="style6" style="padding: 5px; margin: 5px; text-align: left; border-bottom: 2px solid #00CA79;">
                                                    <asp:FileUpload ID="FileUpload28" runat="server" class="form-control txtbox" Height="28px"
                                                        CssClass="CS" />
                                                    <asp:HyperLink ID="HyperLink18" runat="server" CssClass="LBLBLACK" Width="165px"
                                                        Target="_blank"></asp:HyperLink>
                                                    <br />
                                                    <asp:Label ID="Label59" runat="server" Visible="False"></asp:Label>
                                                </td>
                                                <td style="padding: 5px; margin: 5px; border-bottom: 2px solid #00CA79;">
                                                    <asp:Button ID="Button26" runat="server" CssClass="btn btn-xs btn-warning" Height="28px"
                                                        TabIndex="10" Text="Upload" ValidationGroup="gg" Width="72px" OnClick="Button26_Click" />
                                                </td>
                                            </tr>
                                            <%-- </div>
       </td>
        </tr>
    </table>--%>
                                            <%----------------20-------------------------------------------------------%>
                                            <tr id="panelIRRIGATION" runat="server" visible="false">
                                                <td style="padding: 5px; margin: 5px; text-align: left;">
                                                    <asp:Label ID="Label60" runat="server" CssClass="LBLBLACK" Width="165px">Reference 
                                                        Number<font 
                                                            color="red">*</font></asp:Label>
                                                </td>
                                                <td style="padding: 5px; margin: 5px">
                                                    : &nbsp;
                                                </td>
                                                <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                    <asp:TextBox ID="TextBox19" runat="server" class="form-control txtbox" Height="28px"
                                                        MaxLength="40" TabIndex="1" ValidationGroup="group" Width="180px" OnTextChanged="txtcontact6_TextChanged"></asp:TextBox>
                                                </td>
                                                <td style="padding: 5px; margin: 5px;">
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator20" runat="server" ControlToValidate="TextBox19"
                                                        ErrorMessage="Please enter Reference Number for Irrigation Approval Document"
                                                        ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr id="panelIRRIGATION1" runat="server" visible="false">
                                                <td style="padding: 5px; margin: 5px; text-align: left;">
                                                    <asp:Label ID="Label55" runat="server" CssClass="LBLBLACK" Width="315px">Upload 
                                                        Irrigation Approval Document</asp:Label>
                                                </td>
                                                <td>
                                                    :
                                                </td>
                                                <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                    <asp:FileUpload ID="FileUpload29" runat="server" class="form-control txtbox" Height="28px"
                                                        CssClass="CS" />
                                                    <asp:HyperLink ID="HyperLink19" runat="server" CssClass="LBLBLACK" Width="165px"
                                                        Target="_blank"></asp:HyperLink>
                                                    <br />
                                                    <asp:Label ID="Label62" runat="server" Visible="False"></asp:Label>
                                                </td>
                                                <td style="padding: 5px; margin: 5px;">
                                                    <asp:Button ID="Button27" runat="server" CssClass="btn btn-xs btn-warning" Height="28px"
                                                        TabIndex="10" Text="Upload" ValidationGroup="gg" Width="72px" OnClick="Button27_Click" />
                                                </td>
                                            </tr>
                                            <tr id="trLegalMetrologyDepartmentref" runat="server" visible="false">
                                                <td style="padding: 5px; margin: 5px; text-align: left;">
                                                    <asp:Label ID="Label1" runat="server" CssClass="LBLBLACK" Width="165px">Reference 
                                                        Number<font 
                                                            color="red">*</font></asp:Label>
                                                </td>
                                                <td style="padding: 5px; margin: 5px">
                                                    :
                                                </td>
                                                <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                    <asp:TextBox ID="txtLegalMetrologyDepartment" runat="server" class="form-control txtbox"
                                                        Height="28px" MaxLength="40" TabIndex="1" ValidationGroup="group" Width="180px"
                                                        OnTextChanged="txtcontact6_TextChanged"></asp:TextBox>
                                                </td>
                                                <td style="padding: 5px; margin: 5px;">
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator21" runat="server" ControlToValidate="txtLegalMetrologyDepartment"
                                                        ErrorMessage="Please Enter Reference Number for Legal Metrology Document" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr id="trLegalMetrologyDepartment" runat="server" visible="false">
                                                <td style="padding: 5px; margin: 5px; text-align: left; border-bottom: 2px solid #00CA79;">
                                                    <asp:Label ID="Label2" runat="server" CssClass="LBLBLACK" Width="350px">Upload 
                                                        Legal Metrology Approval Document<font 
                                                            color="red">*</font></asp:Label>
                                                </td>
                                                <td style="padding: 5px; margin: 5px; border-bottom: 2px solid #00CA79;">
                                                    :
                                                </td>
                                                <td class="style6" style="padding: 5px; margin: 5px; text-align: left; border-bottom: 2px solid #00CA79;">
                                                    <asp:FileUpload ID="FUtrLegalMetrologyDepartment" runat="server" CssClass="CS" Height="28px" />
                                                    <asp:HyperLink ID="HlptrLegalMetrologyDepartment" runat="server" CssClass="LBLBLACK"
                                                        Width="165px" Target="_blank"></asp:HyperLink>
                                                    <br />
                                                    <asp:Label ID="lbltrLegalMetrologyDepartment" runat="server" Visible="False"></asp:Label>
                                                </td>
                                                <td style="padding: 5px; margin: 5px; border-bottom: 2px solid #00CA79;">
                                                    <asp:Button ID="btnLegalMetrologyDepartment" runat="server" CssClass="btn btn-xs btn-warning"
                                                        Height="28px" TabIndex="10" Text="Upload" ValidationGroup="gg" Width="72px" OnClick="btnLegalMetrologyDepartment_Click" />
                                                </td>
                                            </tr>
                                            <tr id="trLabourDepartmentref" runat="server" visible="false">
                                                <td style="padding: 5px; margin: 5px; text-align: left;">
                                                    <asp:Label ID="Label3" runat="server" CssClass="LBLBLACK" Width="165px">Reference 
                                                        Number<font 
                                                            color="red">*</font></asp:Label>
                                                </td>
                                                <td style="padding: 5px; margin: 5px">
                                                    :
                                                </td>
                                                <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                    <asp:TextBox ID="txtLabourDepartment" runat="server" class="form-control txtbox"
                                                        Height="28px" MaxLength="40" TabIndex="1" ValidationGroup="group" Width="180px"
                                                        OnTextChanged="txtcontact6_TextChanged"></asp:TextBox>
                                                </td>
                                                <td style="padding: 5px; margin: 5px;">
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator22" runat="server" ControlToValidate="txtLabourDepartment"
                                                        ErrorMessage="Please Enter Reference Number for Registration Under Buildings & Other Construction Workers Document"
                                                        ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr id="trLabourDepartment" runat="server" visible="false">
                                                <td style="padding: 5px; margin: 5px; text-align: left; border-bottom: 2px solid #00CA79;">
                                                    <asp:Label ID="Label4" runat="server" CssClass="LBLBLACK" Width="350px">Upload 
                                                        Registration Under Buildings & Other Construction Workers Approval Document<font 
                                                            color="red">*</font></asp:Label>
                                                </td>
                                                <td style="padding: 5px; margin: 5px; border-bottom: 2px solid #00CA79;">
                                                    :
                                                </td>
                                                <td class="style6" style="padding: 5px; margin: 5px; text-align: left; border-bottom: 2px solid #00CA79;">
                                                    <asp:FileUpload ID="FUptrLabourDepartment" runat="server" CssClass="CS" Height="28px" />
                                                    <asp:HyperLink ID="HpLabourDepartment" runat="server" CssClass="LBLBLACK" Width="165px"
                                                        Target="_blank"></asp:HyperLink>
                                                    <br />
                                                    <asp:Label ID="lblLabourDepartment" runat="server" Visible="False"></asp:Label>
                                                </td>
                                                <td style="padding: 5px; margin: 5px; border-bottom: 2px solid #00CA79;">
                                                    <asp:Button ID="btnLabourDepartment" runat="server" CssClass="btn btn-xs btn-warning"
                                                        Height="28px" TabIndex="10" Text="Upload" ValidationGroup="gg" Width="72px" OnClick="btnLabourDepartment_Click" />
                                                </td>
                                            </tr>
                                            <tr id="trLabourDepartmentref48" runat="server" visible="false">
                                                <td style="padding: 5px; margin: 5px; text-align: left;">
                                                    <asp:Label ID="Label70" runat="server" CssClass="LBLBLACK" Width="165px">Reference 
                                                        Number<font 
                                                            color="red">*</font></asp:Label>
                                                </td>
                                                <td style="padding: 5px; margin: 5px">
                                                    :
                                                </td>
                                                <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                    <asp:TextBox ID="txtLabourDepartment48" runat="server" class="form-control txtbox"
                                                        Height="28px" MaxLength="40" TabIndex="1" ValidationGroup="group" Width="180px"></asp:TextBox>
                                                </td>
                                                <td style="padding: 5px; margin: 5px;">
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator28" runat="server" ControlToValidate="txtLabourDepartment48"
                                                        ErrorMessage="Please Enter Reference Number for Legal Labour Document" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr id="trLabourDepartment48" runat="server" visible="false">
                                                <td style="padding: 5px; margin: 5px; text-align: left; border-bottom: 2px solid #00CA79;">
                                                    <asp:Label ID="Label71" runat="server" CssClass="LBLBLACK" Width="350px">Upload 
                                                        Registration Under Contract Labour Approval Document<font 
                                                            color="red">*</font></asp:Label>
                                                </td>
                                                <td style="padding: 5px; margin: 5px; border-bottom: 2px solid #00CA79;">
                                                    :
                                                </td>
                                                <td class="style6" style="padding: 5px; margin: 5px; text-align: left; border-bottom: 2px solid #00CA79;">
                                                    <asp:FileUpload ID="FUptrLabourDepartment48" runat="server" CssClass="CS" Height="28px" />
                                                    <asp:HyperLink ID="HpLabourDepartment48" runat="server" CssClass="LBLBLACK" Width="165px"
                                                        Target="_blank"></asp:HyperLink>
                                                    <br />
                                                    <asp:Label ID="lblLabourDepartment48" runat="server" Visible="False"></asp:Label>
                                                </td>
                                                <td style="padding: 5px; margin: 5px; border-bottom: 2px solid #00CA79;">
                                                    <asp:Button ID="btnLabourDepartment48" runat="server" CssClass="btn btn-xs btn-warning"
                                                        Height="28px" TabIndex="10" Text="Upload" ValidationGroup="gg" Width="72px" OnClick="btnLabourDepartment48_Click" />
                                                </td>
                                            </tr>
                                            <tr id="trLabourDepartmentref49" runat="server" visible="false">
                                                <td style="padding: 5px; margin: 5px; text-align: left;">
                                                    <asp:Label ID="Label72" runat="server" CssClass="LBLBLACK" Width="165px">Reference 
                                                        Number<font 
                                                            color="red">*</font></asp:Label>
                                                </td>
                                                <td style="padding: 5px; margin: 5px">
                                                    :
                                                </td>
                                                <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                    <asp:TextBox ID="txtLabourDepartment49" runat="server" class="form-control txtbox"
                                                        Height="28px" MaxLength="40" TabIndex="1" ValidationGroup="group" Width="180px"></asp:TextBox>
                                                </td>
                                                <td style="padding: 5px; margin: 5px;">
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator29" runat="server" ControlToValidate="txtLabourDepartment49"
                                                        ErrorMessage="Please Enter Reference Number for Registration Under Inter State Migrant Workman Document"
                                                        ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr id="trLabourDepartment49" runat="server" visible="false">
                                                <td style="padding: 5px; margin: 5px; text-align: left; border-bottom: 2px solid #00CA79;">
                                                    <asp:Label ID="Label73" runat="server" CssClass="LBLBLACK" Width="350px">Upload 
                                                        Registration Under Inter State Migrant Workman Approval Document<font 
                                                            color="red">*</font></asp:Label>
                                                </td>
                                                <td style="padding: 5px; margin: 5px; border-bottom: 2px solid #00CA79;">
                                                    :
                                                </td>
                                                <td class="style6" style="padding: 5px; margin: 5px; text-align: left; border-bottom: 2px solid #00CA79;">
                                                    <asp:FileUpload ID="FUptrLabourDepartment49" runat="server" CssClass="CS" Height="28px" />
                                                    <asp:HyperLink ID="HpLabourDepartment49" runat="server" CssClass="LBLBLACK" Width="165px"
                                                        Target="_blank"></asp:HyperLink>
                                                    <br />
                                                    <asp:Label ID="lblLabourDepartment49" runat="server" Visible="False"></asp:Label>
                                                </td>
                                                <td style="padding: 5px; margin: 5px; border-bottom: 2px solid #00CA79;">
                                                    <asp:Button ID="btnLabourDepartment49" runat="server" CssClass="btn btn-xs btn-warning"
                                                        Height="28px" TabIndex="10" Text="Upload" ValidationGroup="gg" Width="72px" OnClick="btnLabourDepartment49_Click" />
                                                </td>
                                            </tr>
                                            <tr id="trforestref" runat="server" visible="false">
                                                <td style="padding: 5px; margin: 5px; text-align: left;">
                                                    <asp:Label ID="Label5" runat="server" CssClass="LBLBLACK" Width="165px">Reference 
                                                        Number<font 
                                                            color="red">*</font></asp:Label>
                                                </td>
                                                <td style="padding: 5px; margin: 5px">
                                                    :
                                                </td>
                                                <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                    <asp:TextBox ID="txttrforestref" runat="server" class="form-control txtbox" Height="28px"
                                                        MaxLength="40" TabIndex="1" ValidationGroup="group" Width="180px"></asp:TextBox>
                                                </td>
                                                <td style="padding: 5px; margin: 5px;">
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator23" runat="server" ControlToValidate="txttrforestref"
                                                        ErrorMessage="Please Enter Noc Reference Number " ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr id="trforestdept" runat="server" visible="false">
                                                <td style="padding: 5px; margin: 5px; text-align: left; border-bottom: 2px solid #00CA79;">
                                                    <asp:Label ID="Label58" runat="server" CssClass="LBLBLACK" Width="350px">Upload 
                                                        NOC from Forest Department Approval Document<font 
                                                            color="red">*</font></asp:Label>
                                                </td>
                                                <td style="padding: 5px; margin: 5px; border-bottom: 2px solid #00CA79;">
                                                    :
                                                </td>
                                                <td class="style6" style="padding: 5px; margin: 5px; text-align: left; border-bottom: 2px solid #00CA79;">
                                                    <asp:FileUpload ID="futrforestdept" runat="server" CssClass="CS" Height="28px" />
                                                    <asp:HyperLink ID="hpltrforestdept" runat="server" CssClass="LBLBLACK" Width="165px"
                                                        Target="_blank"></asp:HyperLink>
                                                    <br />
                                                    <asp:Label ID="lbltrforestdept" runat="server" Visible="False"></asp:Label>
                                                </td>
                                                <td style="padding: 5px; margin: 5px; border-bottom: 2px solid #00CA79;">
                                                    <asp:Button ID="btntrforestdept" runat="server" CssClass="btn btn-xs btn-warning"
                                                        Height="28px" TabIndex="10" Text="Upload" ValidationGroup="gg" Width="72px" OnClick="btntrforestdept_Click" />
                                                </td>
                                            </tr>
                                            <tr id="trKUDAref" runat="server" visible="false">
                                                <td style="padding: 5px; margin: 5px; text-align: left;">
                                                    <asp:Label ID="Label61" runat="server" CssClass="LBLBLACK" Width="165px">Reference 
                                                        Number<font 
                                                            color="red">*</font></asp:Label>
                                                </td>
                                                <td style="padding: 5px; margin: 5px">
                                                    :
                                                </td>
                                                <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                    <asp:TextBox ID="txttrKUDAref" runat="server" class="form-control txtbox" Height="28px"
                                                        MaxLength="40" TabIndex="1" ValidationGroup="group" Width="180px"></asp:TextBox>
                                                </td>
                                                <td style="padding: 5px; margin: 5px;">
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator24" runat="server" ControlToValidate="txttrKUDAref"
                                                        ErrorMessage="Please Enter Reference Number for Kuda approval Document " ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr id="trkuda" runat="server" visible="false">
                                                <td style="padding: 5px; margin: 5px; text-align: left; border-bottom: 2px solid #00CA79;">
                                                    <asp:Label ID="Label63" runat="server" CssClass="LBLBLACK" Width="350px">Upload 
                                                        Industrial Plan Approval from KUDA Approval Document<font 
                                                            color="red">*</font></asp:Label>
                                                </td>
                                                <td style="padding: 5px; margin: 5px; border-bottom: 2px solid #00CA79;">
                                                    :
                                                </td>
                                                <td class="style6" style="padding: 5px; margin: 5px; text-align: left; border-bottom: 2px solid #00CA79;">
                                                    <asp:FileUpload ID="futrkuda" runat="server" CssClass="CS" Height="28px" />
                                                    <asp:HyperLink ID="hlptrkuda" runat="server" CssClass="LBLBLACK" Width="165px" Target="_blank"></asp:HyperLink>
                                                    <br />
                                                    <asp:Label ID="lbltrkuda" runat="server" Visible="False"></asp:Label>
                                                </td>
                                                <td style="padding: 5px; margin: 5px; border-bottom: 2px solid #00CA79;">
                                                    <asp:Button ID="btntrkuda" runat="server" CssClass="btn btn-xs btn-warning" Height="28px"
                                                        TabIndex="10" Text="Upload" ValidationGroup="gg" Width="72px" OnClick="btntrkuda_Click" />
                                                </td>
                                            </tr>
                                            <tr id="trcessref" runat="server" visible="false">
                                                <td style="padding: 5px; margin: 5px; text-align: left;">
                                                    <asp:Label ID="Label64" runat="server" CssClass="LBLBLACK" Width="165px">Reference 
                                                        Number<font 
                                                            color="red">*</font></asp:Label>
                                                </td>
                                                <td style="padding: 5px; margin: 5px">
                                                    :
                                                </td>
                                                <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                    <asp:TextBox ID="txttrcess" runat="server" class="form-control txtbox" Height="28px"
                                                        MaxLength="40" TabIndex="1" ValidationGroup="group" Width="180px"></asp:TextBox>
                                                </td>
                                                <td style="padding: 5px; margin: 5px;">
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator25" runat="server" ControlToValidate="txttrcess"
                                                        ErrorMessage="Please Enter Reference Number for CESS approval Document " ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr id="trcess" runat="server" visible="false">
                                                <td style="padding: 5px; margin: 5px; text-align: left; border-bottom: 2px solid #00CA79;">
                                                    <asp:Label ID="Label65" runat="server" CssClass="LBLBLACK" Width="350px">Upload 
                                                        Power Feasibility and estimate (If Less than 100 HP) from CESS ,Sircilla Approval Document<font 
                                                            color="red">*</font></asp:Label>
                                                </td>
                                                <td style="padding: 5px; margin: 5px; border-bottom: 2px solid #00CA79;">
                                                    :
                                                </td>
                                                <td class="style6" style="padding: 5px; margin: 5px; text-align: left; border-bottom: 2px solid #00CA79;">
                                                    <asp:FileUpload ID="futrcess" runat="server" CssClass="CS" Height="28px" />
                                                    <asp:HyperLink ID="hpltrcess" runat="server" CssClass="LBLBLACK" Width="165px" Target="_blank"></asp:HyperLink>
                                                    <br />
                                                    <asp:Label ID="lbltrcess" runat="server" Visible="False"></asp:Label>
                                                </td>
                                                <td style="padding: 5px; margin: 5px; border-bottom: 2px solid #00CA79;">
                                                    <asp:Button ID="btntrcess" runat="server" CssClass="btn btn-xs btn-warning" Height="28px"
                                                        TabIndex="10" Text="Upload" ValidationGroup="gg" Width="72px" OnClick="btntrcess_Click" />
                                                </td>
                                            </tr>
                                            <tr id="TrExplosiveLicenseref" runat="server" visible="false">
                                                <td style="padding: 5px; margin: 5px; text-align: left;">
                                                    <asp:Label ID="Label66" runat="server" CssClass="LBLBLACK" Width="165px">Reference 
                                                        Number<font 
                                                            color="red">*</font></asp:Label>
                                                </td>
                                                <td style="padding: 5px; margin: 5px">
                                                    :
                                                </td>
                                                <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                    <asp:TextBox ID="txtTrExplosiveLicense" runat="server" class="form-control txtbox"
                                                        Height="28px" MaxLength="40" TabIndex="1" ValidationGroup="group" Width="180px"></asp:TextBox>
                                                </td>
                                                <td style="padding: 5px; margin: 5px;">
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator26" runat="server" ControlToValidate="txtTrExplosiveLicense"
                                                        ErrorMessage="Please enter Reference Number for NOC for Explosive License Approval Document"
                                                        ValidationGroup="group" EnableViewState="False">*</asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr id="TrExplosiveLicenser" runat="server" visible="false">
                                                <td style="padding: 5px; margin: 5px; text-align: left; border-bottom: 2px solid #00CA79;">
                                                    <asp:Label ID="Label67" runat="server" CssClass="LBLBLACK" Width="310px">Upload 
                                                        NOC for Explosive License Approval Document</asp:Label>
                                                </td>
                                                <td style="border-bottom: 2px solid #00CA79;">
                                                    :
                                                </td>
                                                <td class="style6" style="padding: 5px; margin: 5px; text-align: left; border-bottom: 2px solid #00CA79;">
                                                    <asp:FileUpload ID="fuTrExplosiveLicenser" runat="server" class="form-control txtbox"
                                                        Height="28px" CssClass="CS" />
                                                    <asp:HyperLink ID="hlpTrExplosiveLicenser" runat="server" CssClass="LBLBLACK" Width="165px"
                                                        Target="_blank"></asp:HyperLink>
                                                    <br />
                                                    <asp:Label ID="lblTrExplosiveLicenser" runat="server" Visible="False"></asp:Label>
                                                </td>
                                                <td style="padding: 5px; margin: 5px; border-bottom: 2px solid #00CA79;">
                                                    <asp:Button ID="btnTrExplosiveLicenser" runat="server" CssClass="btn btn-xs btn-warning"
                                                        Height="28px" TabIndex="10" Text="Upload" ValidationGroup="gg" Width="72px" OnClick="btnTrExplosiveLicenser_Click" />
                                                </td>
                                            </tr>
                                            <tr id="trtrFTLRevenueref" runat="server" visible="false">
                                                <td style="padding: 5px; margin: 5px; text-align: left;">
                                                    <asp:Label ID="Label68" runat="server" CssClass="LBLBLACK" Width="165px">Reference 
                                                        Number<font 
                                                            color="red">*</font></asp:Label>
                                                </td>
                                                <td style="padding: 5px; margin: 5px">
                                                    :
                                                </td>
                                                <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                    <asp:TextBox ID="txttrFTLRevenue" runat="server" class="form-control txtbox" Height="28px"
                                                        MaxLength="40" TabIndex="1" ValidationGroup="group" Width="180px"></asp:TextBox>
                                                </td>
                                                <td style="padding: 5px; margin: 5px;">
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator27" runat="server" ControlToValidate="txttrFTLRevenue"
                                                        ErrorMessage="Please enter Reference Number for FTL Noc for Change of Land Use (Revenue) Approval Document"
                                                        ValidationGroup="group" EnableViewState="False">*</asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr id="trFTLRevenue" runat="server" visible="false">
                                                <td style="padding: 5px; margin: 5px; text-align: left; border-bottom: 2px solid #00CA79;">
                                                    <asp:Label ID="Label69" runat="server" CssClass="LBLBLACK" Width="310px">Upload 
                                                        FTL Noc for Change of Land Use (Revenue) Approval Document</asp:Label>
                                                </td>
                                                <td style="border-bottom: 2px solid #00CA79;">
                                                    :
                                                </td>
                                                <td class="style6" style="padding: 5px; margin: 5px; text-align: left; border-bottom: 2px solid #00CA79;">
                                                    <asp:FileUpload ID="futrFTLRevenue" runat="server" class="form-control txtbox" Height="28px"
                                                        CssClass="CS" />
                                                    <asp:HyperLink ID="hptrFTLRevenue" runat="server" CssClass="LBLBLACK" Width="165px"
                                                        Target="_blank"></asp:HyperLink>
                                                    <br />
                                                    <asp:Label ID="lbltrFTLRevenue" runat="server" Visible="False"></asp:Label>
                                                </td>
                                                <td style="padding: 5px; margin: 5px; border-bottom: 2px solid #00CA79;">
                                                    <asp:Button ID="btntrFTLRevenue" runat="server" CssClass="btn btn-xs btn-warning"
                                                        Height="28px" TabIndex="10" Text="Upload" ValidationGroup="gg" Width="72px" OnClick="btntrFTLRevenue_Click" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="padding: 5px; margin: 5px" align="center" class="style7">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center" colspan="5" style="padding: 5px; margin: 5px; text-align: center;">
                                                    <asp:Button ID="btnnext" runat="server" CssClass="btn btn-danger" Height="32px" TabIndex="10"
                                                        Text="Next" Width="90px" OnClick="btnnext_Click" />
                                                </td>
                                            </tr>
                                            <%-----------------20------------------------------------------------------%>
                                        </table>
                                    </div>
                                </div>
                            </div>
                        </td>
                    </tr>
                </table>
            </div>
        </div>
        <asp:UpdatePanel ID="UpdatePanel4" runat="server">
            <ContentTemplate>
                <div class="row">
                    <div class="col-md-12">
                        <div>
                            <div class="panel-body">
                                <div class="modal fade" id="myModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel"
                                    aria-hidden="true">
                                    <div class="modal-dialog">
                                        <div class="modal-content">
                                            <div class="modal-header">
                                                <button type="button" class="close" data-dismiss="modal" aria-hidden="true">
                                                    ×</button>
                                                <h4 class="modal-title" id="myModalLabel">
                                                    Land Market Value</h4>
                                            </div>
                                            <div class="modal-body">
                                                <table align="left" cellpadding="10" cellspacing="5" style="width: 100%" id="trmarketvalue"
                                                    runat="server" visible="false">
                                                    <tr>
                                                        <td style="padding: 5px; margin: 5px;">
                                                            &nbsp;
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">
                                                            Land Market Value as Per SRO
                                                            <asp:Label ID="lblnalavalue" Visible="false" runat="server"></asp:Label>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">
                                                            &nbsp;
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">
                                                            <asp:TextBox ID="txtmarketvalue" runat="server" class="form-control txtbox" Height="28px"
                                                                MaxLength="20" ValidationGroup="group" onkeypress="return inputOnlyNumbers(event)"
                                                                Width="180px"></asp:TextBox>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px;">
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator30" runat="server" ControlToValidate="txtmarketvalue"
                                                                ErrorMessage="Please Enter Land Market Value" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                                    <tr style="height">
                                                        <td style="padding: 5px; margin: 5px" colspan="4">
                                                            <asp:HyperLink ID="HyperLinkmarketvalue0" ForeColor="Red" runat="server" NavigateUrl="http://registration.telangana.gov.in/ts/UnitRateMV.do?method=getDistrictList&amp;uType=U"
                                                                Target="_blank" CssClass="blink" Text="Click Here to Calculate Market Value as Per SRO"></asp:HyperLink>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px;">
                                                            &nbsp;
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                            <div class="modal-footer" style="margin-top: 60px;">
                                                <button type="button" class="btn btn-default" data-dismiss="modal">
                                                    Close</button>
                                                <asp:Button ID="Button1" runat="server" CssClass="btn btn-primary" Height="32px"
                                                    TabIndex="10" Text="Submit" ValidationGroup="group" Width="90px" OnClick="Button1_Click" />
                                            </div>
                                            <div style="padding-left: 30px; margin-top: 2px; border-top: 1px solid #e5e5e5;">
                                                <h4>
                                                    <u>Sample Calculation for NALA Fee</u></h4>
                                                <p>
                                                    Total land for Conversion = 2 Acr.Zero gts</p>
                                                <p>
                                                    Agriculture Rate in Proposed location = Rs 1000 / Acre</p>
                                                <p>
                                                    Total Conversion Value (2 x 1000) = R.s 2,000
                                                </p>
                                                <p>
                                                    <b>Note : Please Enter Total Conversion Value in Textbox</b></p>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    <asp:UpdateProgress ID="UpdateProgress" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
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
    <%-- </ContentTemplate>
    </asp:UpdatePanel>--%>
    <%--</div>
       </td>
        </tr>
    </table>--%>
</asp:Content>
