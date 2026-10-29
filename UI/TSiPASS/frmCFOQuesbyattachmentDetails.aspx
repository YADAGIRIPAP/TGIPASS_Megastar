<%@ Page Title=":: TS-iPASS ::  " Language="C#" MasterPageFile="~/UI/TSiPASS/CCMaster.master"
    AutoEventWireup="true" CodeFile="frmCFOQuesbyattachmentDetails.aspx.cs" Inherits="TSTBDCReg1" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

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
            width: 192px;
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
    <asp:UpdatePanel ID="upd1" runat="server">
        <ContentTemplate>
            <div align="left">
                <ol class="breadcrumb">
                    You are here &nbsp;!&nbsp; &nbsp; &nbsp;
                    <li><i class="fa fa-dashboard"></i><a href="Home.aspx"></a></li>
                    <li class=""><i class="fa fa-fw fa-edit">CAF</i> </li>
                    <li class="active"><i class="fa fa-edit"></i><a href="#">Attachment Details</a>
                    </li>
                </ol>
            </div>
            <div align="left">
                <div class="row" align="left">
                    <div class="col-lg-11">
                        <div class="panel panel-primary">
                            <div class="panel-heading" align="center">
                                <h3 class="panel-title">Upload CFE</h3>
                            </div>
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>
                                    <div class="panel-body">
                                        <table align="center" cellpadding="10" cellspacing="5" style="width: 90%">
                                            <tr>
                                                <td style="padding: 5px; margin: 5px" valign="top">
                                                    <asp:Label ID="Label422" runat="server" CssClass="LBLBLACK" Font-Bold="True"
                                                        Width="210px" Visible="False">Update CFE</asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="padding: 5px; margin: 5px" valign="top">
                                                    <table cellpadding="4" cellspacing="5" style="width: 100%">
                                                        <tr id="CFOPCBref" runat="server" visible="false">
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">&nbsp;</td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:Label ID="Label464" runat="server" CssClass="LBLBLACK" Width="165px">Reference 
                                                        Number<font 
                                                            color="red">*</font></asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">:</td>
                                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:TextBox ID="txtPCBRefNo" runat="server" class="form-control txtbox"
                                                                    Height="28px" MaxLength="40"
                                                                    TabIndex="1" ValidationGroup="groupnew" Width="180px"></asp:TextBox>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                                                                    ControlToValidate="txtPCBRefNo"
                                                                    ErrorMessage="Please enter Reference Number for PCB Approval Document"
                                                                    ValidationGroup="groupnew" Visible="False">*</asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                        <tr id="CFOPCB" runat="server" visible="false">
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">&nbsp;</td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:Label ID="Label465" runat="server" CssClass="LBLBLACK" Width="349px"
                                                                    Font-Bold="True">Upload 
                                                        CFE Issued by PCB<font 
                                                            color="red">*</font></asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">:</td>
                                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:FileUpload ID="FileUpload10" runat="server" class="form-control txtbox"
                                                                    Height="48px" />
                                                                <asp:HyperLink ID="Label453" runat="server" CssClass="LBLBLACK" Target="_blank"
                                                                    Width="165px"></asp:HyperLink>
                                                                <br />
                                                                <asp:Label ID="Label454" runat="server" Visible="False"></asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                                <asp:Button ID="Button8" runat="server" CssClass="btn btn-xs btn-warning"
                                                                    Height="28px" OnClick="Button8_Click" TabIndex="10" Text="Upload"
                                                                    ValidationGroup="groupnew" Width="72px" />
                                                            </td>
                                                        </tr>
                                                        <tr id="CFOFactoryref" runat="server" visible="false">
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">&nbsp;</td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:Label ID="Label6" runat="server" CssClass="LBLBLACK" Width="165px">Reference 
                                                        Number<font 
                                                            color="red">*</font></asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">:</td>
                                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:TextBox ID="txtTSCTRefNo" runat="server" class="form-control txtbox"
                                                                    Height="28px" MaxLength="40"
                                                                    TabIndex="1" ValidationGroup="groupnew1" Width="180px"></asp:TextBox>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                                                                    ControlToValidate="txtTSCTRefNo"
                                                                    ErrorMessage="Please enter Reference Number for  Commercial Taxes Approval Document"
                                                                    ValidationGroup="groupnew1" Visible="False">*</asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                        <tr id="CFOFactory" runat="server" visible="false">
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">&nbsp;</td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:Label ID="Label7" runat="server" CssClass="LBLBLACK" Width="360px"
                                                                    Font-Bold="True">Upload Plan Approval from Factory Department</asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">:</td>
                                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:FileUpload ID="FileUpload11" runat="server" class="form-control txtbox"
                                                                    Height="48px" />
                                                                <asp:HyperLink ID="HyperLink1" runat="server" CssClass="LBLBLACK"
                                                                    Target="_blank" Width="165px">[HyperLink1]</asp:HyperLink>
                                                                <br />
                                                                <asp:Label ID="Label8" runat="server" Visible="False"></asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                                <asp:Button ID="Button9" runat="server" CssClass="btn btn-xs btn-warning"
                                                                    Height="28px" OnClick="Button9_Click" TabIndex="10" Text="Upload"
                                                                    ValidationGroup="groupnew1" Width="72px" />
                                                            </td>
                                                        </tr>
                                                        <tr id="CFOFireref" runat="server" visible="false">
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">&nbsp;</td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:Label ID="Label9" runat="server" CssClass="LBLBLACK" Width="165px">Reference 
                                                        Number<font 
                                                            color="red">*</font></asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">:</td>
                                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:TextBox ID="TextBox2" runat="server" class="form-control txtbox"
                                                                    Height="28px" MaxLength="40"
                                                                    TabIndex="1" ValidationGroup="groupnew2" Width="180px"></asp:TextBox>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server"
                                                                    ControlToValidate="TextBox2"
                                                                    ErrorMessage="Please enter Reference Number for TSIIC Approval Document"
                                                                    ValidationGroup="groupnew2" Visible="False">*</asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                        <tr id="CFOFire" runat="server" visible="false">
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">&nbsp;</td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:Label ID="Label10" runat="server" CssClass="LBLBLACK" Width="331px"
                                                                    Font-Bold="True">Provisional NOC from Fire Service Department</asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">:</td>
                                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:FileUpload ID="FileUpload12" runat="server" class="form-control txtbox"
                                                                    Height="48px" />
                                                                <asp:HyperLink ID="HyperLink2" runat="server" CssClass="LBLBLACK"
                                                                    Target="_blank" Width="165px">[HyperLink2]</asp:HyperLink>
                                                                <br />
                                                                <asp:Label ID="Label11" runat="server" Visible="False"></asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                                <asp:Button ID="Button10" runat="server" CssClass="btn btn-xs btn-warning"
                                                                    Height="28px" OnClick="Button10_Click" TabIndex="10" Text="Upload"
                                                                    ValidationGroup="groupnew2" Width="72px" />
                                                            </td>
                                                        </tr>
                                                        <tr id="CFOCEIGref" runat="server" visible="false">
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">&nbsp;</td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:Label ID="Label12" runat="server" CssClass="LBLBLACK" Width="165px">Reference 
                                                        Number<font 
                                                            color="red">*</font></asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">:</td>
                                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:TextBox ID="TextBox3" runat="server" class="form-control txtbox"
                                                                    Height="28px" MaxLength="40"
                                                                    TabIndex="1" ValidationGroup="groupnew3" Width="180px"></asp:TextBox>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server"
                                                                    ControlToValidate="TextBox3"
                                                                    ErrorMessage="Please enter Reference Number for Panchayat Raj Approval Document"
                                                                    ValidationGroup="groupnew3" Visible="False">*</asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                        <tr id="CFOCEIG" runat="server" visible="false">
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">&nbsp;</td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:Label ID="Label13" runat="server" CssClass="LBLBLACK" Width="352px"
                                                                    Font-Bold="True">Electrial Drawing Approval</asp:Label>
                                                            </td>
                                                            <td>&nbsp;:&nbsp;</td>
                                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:FileUpload ID="FileUpload13" runat="server" class="form-control txtbox"
                                                                    Height="48px" />
                                                                <asp:HyperLink ID="HyperLink3" runat="server" CssClass="LBLBLACK"
                                                                    Target="_blank" Width="165px">[HyperLink3]</asp:HyperLink>
                                                                <br />
                                                                <asp:Label ID="Label14" runat="server" Visible="False"></asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                                <asp:Button ID="Button11" runat="server" CssClass="btn btn-xs btn-warning"
                                                                    Height="28px" OnClick="Button11_Click" TabIndex="10" Text="Upload"
                                                                    ValidationGroup="groupnew3" Width="72px" />
                                                            </td>
                                                        </tr>
                                                        <tr id="CFODRUGref" runat="server" visible="false">
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">&nbsp;</td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:Label ID="Label15" runat="server" CssClass="LBLBLACK" Width="165px">Reference 
                                                        Number<font 
                                                            color="red">*</font></asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">:</td>
                                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:TextBox ID="TextBox4" runat="server" class="form-control txtbox"
                                                                    Height="28px" MaxLength="40"
                                                                    TabIndex="1" ValidationGroup="groupnew4" Width="180px"></asp:TextBox>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server"
                                                                    ControlToValidate="TextBox4"
                                                                    ErrorMessage="Please enter Reference Number for DISCOM Approval Document"
                                                                    ValidationGroup="groupnew4" Visible="False">*</asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                        <tr id="CFODRUG" runat="server" visible="false">
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">&nbsp;</td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:Label ID="Label16" runat="server" CssClass="LBLBLACK" Width="264px"
                                                                    Font-Bold="True">Approval from  Drugs Department</asp:Label>
                                                            </td>
                                                            <td>:</td>
                                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:FileUpload ID="FileUpload14" runat="server" class="form-control txtbox"
                                                                    Height="48px" />
                                                                <asp:HyperLink ID="HyperLink4" runat="server" CssClass="LBLBLACK"
                                                                    Target="_blank" Width="165px">[HyperLink4]</asp:HyperLink>
                                                                <br />
                                                                <asp:Label ID="Label17" runat="server" Visible="False"></asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                                <asp:Button ID="Button12" runat="server" CssClass="btn btn-xs btn-warning"
                                                                    Height="28px" OnClick="Button12_Click" TabIndex="10" Text="Upload"
                                                                    ValidationGroup="groupnew4" Width="72px" />
                                                            </td>
                                                        </tr>
                                                        <tr id="CFOBoilerref" runat="server" visible="false">
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">&nbsp;</td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:Label ID="Label468" runat="server" CssClass="LBLBLACK" Width="165px">Reference 
                                                        Number<font 
                                                            color="red">*</font></asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">:</td>
                                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:TextBox ID="TextBox5" runat="server" class="form-control txtbox"
                                                                    Height="28px" MaxLength="40"
                                                                    TabIndex="1" ValidationGroup="groupnew5" Width="180px"></asp:TextBox>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server"
                                                                    ControlToValidate="TextBox4"
                                                                    ErrorMessage="Please enter Reference Number for DISCOM Approval Document"
                                                                    ValidationGroup="groupnew5">*</asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                        <tr id="CFOBoiler" runat="server" visible="false">
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">&nbsp;</td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:Label ID="Label469" runat="server" CssClass="LBLBLACK" Width="398px"
                                                                    Font-Bold="True">Registration and Erection Permission from Boilers department</asp:Label>
                                                            </td>
                                                            <td>:</td>
                                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:FileUpload ID="FileUpload15" runat="server" class="form-control txtbox"
                                                                    Height="48px" />
                                                                <asp:HyperLink ID="HyperLink6" runat="server" CssClass="LBLBLACK"
                                                                    Target="_blank" Width="165px">[HyperLink5]</asp:HyperLink>
                                                                <br />
                                                                <asp:Label ID="Label20" runat="server" Visible="False"></asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                                <asp:Button ID="Button13" runat="server" CssClass="btn btn-xs btn-warning"
                                                                    Height="28px" OnClick="Button13_Click" TabIndex="10" Text="Upload"
                                                                    ValidationGroup="groupnew5" Width="72px" />
                                                            </td>
                                                        </tr>
                                                        <tr id="SerTSSPDCLRef" runat="server" visible="false">
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">&nbsp;</td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:Label ID="Label470" runat="server" CssClass="LBLBLACK" Width="165px">Reference 
                                                        Number<font color="red">*</font></asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">:</td>
                                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:TextBox ID="TextBox6" runat="server" class="form-control txtbox"
                                                                    Height="28px" MaxLength="40" TabIndex="1" ValidationGroup="groupnew6"
                                                                    Width="180px"></asp:TextBox>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server"
                                                                    ControlToValidate="TextBox6"
                                                                    ErrorMessage="Please enter Reference number of TSSPDCL"
                                                                    ValidationGroup="groupnew6">*</asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                        <tr id="SerTSSPDCL" runat="server" visible="false">
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">&nbsp;</td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:Label ID="Label471" runat="server" CssClass="LBLBLACK" Font-Bold="True"
                                                                    Width="352px">Upload feasibility report</asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">:</td>
                                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:FileUpload ID="FileUpload16" runat="server" class="form-control txtbox"
                                                                    Height="48px" />
                                                                <asp:HyperLink ID="HyperLink7" runat="server" CssClass="LBLBLACK"
                                                                    Target="_blank" Width="165px">[HyperLink5]</asp:HyperLink>
                                                                <br />
                                                                <asp:Label ID="Label472" runat="server" Visible="False"></asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                                <asp:Button ID="Button15" runat="server" CssClass="btn btn-xs btn-warning"
                                                                    Height="28px" OnClick="Button14_Click" TabIndex="10" Text="Upload"
                                                                    ValidationGroup="groupnew6" Width="72px" />
                                                            </td>
                                                        </tr>
                                                        <tr id="SerTSNPDCLRef" runat="server" visible="false">
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">&nbsp;</td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:Label ID="Label473" runat="server" CssClass="LBLBLACK" Width="165px">Reference 
                                                        Number<font color="red">*</font></asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">&nbsp;</td>
                                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:TextBox ID="TextBox7" runat="server" class="form-control txtbox"
                                                                    Height="28px" MaxLength="40" TabIndex="1" ValidationGroup="groupnew7"
                                                                    Width="180px"></asp:TextBox>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server"
                                                                    ControlToValidate="TextBox7"
                                                                    ErrorMessage="Please enter Reference Number for TSNPDCL "
                                                                    ValidationGroup="groupnew7">*</asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                        <tr id="SerTSNPDCL" runat="server" visible="false">
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">&nbsp;</td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:Label ID="Label474" runat="server" CssClass="LBLBLACK" Font-Bold="True"
                                                                    Width="352px">Upload feasibility report</asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">&nbsp;</td>
                                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:FileUpload ID="FileUpload17" runat="server" class="form-control txtbox"
                                                                    Height="48px" />
                                                                <asp:HyperLink ID="HyperLink8" runat="server" CssClass="LBLBLACK"
                                                                    Target="_blank" Width="165px">[HyperLink5]</asp:HyperLink>
                                                                <br />
                                                                <asp:Label ID="Label475" runat="server" Visible="False"></asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                                <asp:Button ID="Button16" runat="server" CssClass="btn btn-xs btn-warning"
                                                                    Height="28px" OnClick="Button15_Click" TabIndex="10" Text="Upload"
                                                                    ValidationGroup="groupnew7" Width="72px" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <caption>
                                                &nbsp;</caption>
                                            <tr>
                                                <td align="center" style="padding: 5px; margin: 5px; text-align: center;">
                                                    <asp:Button ID="BtnSave1" runat="server" CssClass="btn btn-primary" Height="32px"
                                                        OnClick="BtnSave_Click" TabIndex="10" Text="Save" ValidationGroup="group"
                                                        Width="90px" Visible="False" />
                                                    &nbsp;&nbsp;<asp:Button ID="BtnDelete" runat="server" CssClass="btn btn-danger"
                                                        Height="32px" OnClick="BtnDelete_Click" TabIndex="10" Text="Next" Width="90px"
                                                        ValidationGroup="group" />
                                                    &nbsp;<asp:Button ID="BtnDelete0" runat="server" CausesValidation="False"
                                                        CssClass="btn btn-danger" Height="32px" OnClick="BtnDelete0_Click"
                                                        TabIndex="10" Text="Previous" Width="90px" />
                                                    &nbsp;<asp:Button ID="BtnClear" runat="server" CausesValidation="False" CssClass="btn btn-warning"
                                                        Height="32px" OnClick="BtnClear_Click" TabIndex="10" Text="ClearAll" ToolTip="To Clear  the Screen"
                                                        Width="90px" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center" style="padding: 5px; margin: 5px">
                                                    <div id="success" runat="server" visible="false" class="alert alert-success">
                                                        <a href="AddQualification.aspx" class="close" data-dismiss="alert" aria-label="close">&times;</a> <strong>Success!</strong><asp:Label ID="lblmsg" runat="server"></asp:Label>
                                                    </div>
                                                    <div id="Failure" runat="server" visible="false" class="alert alert-danger">
                                                        <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a> <strong>Warning!</strong>
                                                        <asp:Label ID="lblmsg0" runat="server"></asp:Label>
                                                    </div>
                                                </td>
                                            </tr>
                                        </table>
                                        <asp:HiddenField ID="hdfID" runat="server" />
                                        <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
                                            ShowSummary="False" ValidationGroup="group" />
                                        <asp:ValidationSummary ID="VGnew" runat="server" ShowMessageBox="True"
                                            ShowSummary="False" ValidationGroup="groupnew" />
                                        <asp:ValidationSummary ID="VGnew1" runat="server" ShowMessageBox="True"
                                            ShowSummary="False" ValidationGroup="groupnew1" />
                                        <asp:ValidationSummary ID="VGnew2" runat="server" ShowMessageBox="True"
                                            ShowSummary="False" ValidationGroup="groupnew2" />
                                        <asp:ValidationSummary ID="VGnew3" runat="server" ShowMessageBox="True"
                                            ShowSummary="False" ValidationGroup="groupnew3" />

                                        <asp:ValidationSummary ID="VGnew4" runat="server" ShowMessageBox="True"
                                            ShowSummary="False" ValidationGroup="groupnew4" />
                                        <asp:ValidationSummary ID="VGnew5" runat="server" ShowMessageBox="True"
                                            ShowSummary="False" ValidationGroup="groupnew5" />

                                        <asp:ValidationSummary ID="VGnew6" runat="server" ShowMessageBox="True"
                                            ShowSummary="False" ValidationGroup="groupnew6" />
                                        <asp:ValidationSummary ID="VGnew7" runat="server" ShowMessageBox="True"
                                            ShowSummary="False" ValidationGroup="groupnew7" />

                                        <asp:ValidationSummary ID="ValidationSummary2" runat="server" ShowMessageBox="True"
                                            ShowSummary="False" ValidationGroup="child" />
                                        <asp:HiddenField ID="hdfFlagID" runat="server" />
                                        <br />
                                        <asp:HiddenField ID="hdfFlagID0" runat="server" />
                                    </div>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                    </div>
                </div>
            </div>
            <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="updatepanel1">
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

            <asp:PostBackTrigger ControlID="Button8"></asp:PostBackTrigger>
            <asp:PostBackTrigger ControlID="Button9"></asp:PostBackTrigger>
            <asp:PostBackTrigger ControlID="Button10"></asp:PostBackTrigger>
            <asp:PostBackTrigger ControlID="Button11"></asp:PostBackTrigger>
            <asp:PostBackTrigger ControlID="Button12"></asp:PostBackTrigger>
            <asp:PostBackTrigger ControlID="Button13"></asp:PostBackTrigger>
            <asp:PostBackTrigger ControlID="Button8"></asp:PostBackTrigger>
            <asp:PostBackTrigger ControlID="Button9"></asp:PostBackTrigger>
            <asp:PostBackTrigger ControlID="Button10"></asp:PostBackTrigger>
            <asp:PostBackTrigger ControlID="Button11"></asp:PostBackTrigger>
            <asp:PostBackTrigger ControlID="Button12"></asp:PostBackTrigger>
            <asp:PostBackTrigger ControlID="Button13"></asp:PostBackTrigger>
            <asp:PostBackTrigger ControlID="Button8"></asp:PostBackTrigger>
            <asp:PostBackTrigger ControlID="Button9"></asp:PostBackTrigger>
            <asp:PostBackTrigger ControlID="Button10"></asp:PostBackTrigger>
            <asp:PostBackTrigger ControlID="Button11"></asp:PostBackTrigger>
            <asp:PostBackTrigger ControlID="Button12"></asp:PostBackTrigger>
            <asp:PostBackTrigger ControlID="Button13"></asp:PostBackTrigger>
            <asp:PostBackTrigger ControlID="Button8"></asp:PostBackTrigger>
            <asp:PostBackTrigger ControlID="Button9"></asp:PostBackTrigger>
            <asp:PostBackTrigger ControlID="Button10"></asp:PostBackTrigger>
            <asp:PostBackTrigger ControlID="Button11"></asp:PostBackTrigger>
            <asp:PostBackTrigger ControlID="Button12"></asp:PostBackTrigger>
            <asp:PostBackTrigger ControlID="Button13"></asp:PostBackTrigger>
            <asp:PostBackTrigger ControlID="Button8"></asp:PostBackTrigger>
            <asp:PostBackTrigger ControlID="Button9"></asp:PostBackTrigger>
            <asp:PostBackTrigger ControlID="Button10"></asp:PostBackTrigger>
            <asp:PostBackTrigger ControlID="Button11"></asp:PostBackTrigger>
            <asp:PostBackTrigger ControlID="Button12"></asp:PostBackTrigger>
            <asp:PostBackTrigger ControlID="Button13"></asp:PostBackTrigger>
            <asp:PostBackTrigger ControlID="Button8"></asp:PostBackTrigger>
            <asp:PostBackTrigger ControlID="Button9"></asp:PostBackTrigger>
            <asp:PostBackTrigger ControlID="Button10"></asp:PostBackTrigger>
            <asp:PostBackTrigger ControlID="Button11"></asp:PostBackTrigger>
            <asp:PostBackTrigger ControlID="Button12"></asp:PostBackTrigger>
            <asp:PostBackTrigger ControlID="Button13"></asp:PostBackTrigger>
            <asp:PostBackTrigger ControlID="Button15"></asp:PostBackTrigger>
            <asp:PostBackTrigger ControlID="Button16"></asp:PostBackTrigger>
        </Triggers>
        <Triggers>
            <asp:PostBackTrigger ControlID="Button8" />
            <asp:PostBackTrigger ControlID="Button9" />
            <asp:PostBackTrigger ControlID="Button10" />
            <asp:PostBackTrigger ControlID="Button11" />
            <asp:PostBackTrigger ControlID="Button12" />
            <asp:PostBackTrigger ControlID="Button13" />
            <asp:PostBackTrigger ControlID="Button15" />
            <asp:PostBackTrigger ControlID="Button16" />

        </Triggers>
    </asp:UpdatePanel>
    <%--</div>
       </td>
        </tr>
    </table>--%>
</asp:Content>
