<%@ Page Title="" Language="C#" MasterPageFile="~/UI/TSiPASS/CCMaster.master" AutoEventWireup="true" CodeFile="frmApproveDetailsbyquery_DWGOgroundwater.aspx.cs" Inherits="UI_TSiPASS_frmApproveDetailsbyquery_DWGOgroundwater" %>


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

        .style6 {
            width: 192px;
        }

        .auto-style1 {
            width: 238px;
        }

        .auto-style2 {
            width: 37px;
        }

        .auto-style3 {
            width: 13px;
        }

        .auto-style4 {
            width: 488px;
        }

        .auto-style5 {
            width: 4px;
        }
    </style>

    <script type="text/javascript" language="javascript">
        function OpenPopup() {
            window.open("Lookups/LookupBDC.aspx", "List", "scrollbars=yes,resizable=yes,width=1000,height=650;display = block;position=absolute");
            return false;
        }
    </script>

    <div align="left">
        <ol class="breadcrumb">
            You are here
        &nbsp;!&nbsp; &nbsp; &nbsp; 
                            <li>
                                <i class="fa fa-dashboard"></i><a href="Home.aspx"></a>
                            </li>
            <li class="">
                <i class="fa fa-fw fa-edit">Groundwater</i>
            </li>
            <li class="active">
                <i class="fa fa-edit"></i><a href="#">Attachment Details</a>
            </li>
        </ol>
    </div>
    <div align="left">
        <div class="row" align="left">
            <div class="col-lg-11">
                <div class="panel panel-primary">
                    <div class="panel-heading" align="center">
                        <h3 class="panel-title">Approval Process</h3>
                    </div>
                    <div class="panel-body">
                        <table align="center" cellpadding="10" cellspacing="5" style="width: 90%">
                            <tr>
                                <td style="padding: 5px; margin: 5px" valign="top">
                                    <asp:Label ID="Label422" runat="server" CssClass="LBLBLACK" Font-Bold="True" Width="210px">Approval Process</asp:Label>
                                </td>
                                <td align="right">
                                    <%--<asp:Label ID="Label58" runat="server" CssClass="LBLBLACK" ForeColor="Red" Font-Bold="True">If you want to Upload DWG file. make is as ZIP or RAR folder and upload it.</asp:Label>--%>

                                </td>
                            </tr>
                            <tr>
                                <td colspan="2" style="padding: 5px; margin: 5px" valign="top">
                                    <table cellpadding="4" cellspacing="5" class="nav-justified">
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" class="auto-style2"></td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" class="auto-style1">
                                                <asp:Label ID="label_head1" runat="server" CssClass="LBLBLACK" Width="210px">UID Number<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px" class="auto-style3">:
                                            </td>
                                            <td class="auto-style4" style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="lbl_UIDNumber" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" class="auto-style2"></td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" class="auto-style1">
                                                <asp:Label ID="label_head2" runat="server" CssClass="LBLBLACK" Width="210px">Name of Applicant<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px" class="auto-style3">:
                                            </td>
                                            <td class="auto-style4" style="padding: 5px; margin: 10px; text-align: left;">
                                                <asp:Label ID="lbl_nameofapplicant" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" class="auto-style2"></td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" class="auto-style1">
                                                <asp:Label ID="label_head3" runat="server" CssClass="LBLBLACK" Width="165px">Type of Applicant<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px" class="auto-style3">:
                                            </td>
                                            <td class="auto-style4" style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="lbl_typeofapplicant" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top" class="auto-style2"></td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" class="auto-style1">
                                                <asp:Label ID="label_head7" runat="server" CssClass="LBLBLACK" Width="334px">Status<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px" class="auto-style3">:
                                            </td>
                                            <td class="auto-style4" style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:DropDownList ID="ddlStatus" runat="server" class="form-control txtbox" Height="33px"
                                                    AutoPostBack="True" Width="180px" OnSelectedIndexChanged="ddlStatus_SelectedIndexChanged">
                                                    <asp:ListItem>--Select--</asp:ListItem>
                                                    <asp:ListItem Value="5">Query Raise</asp:ListItem>
                                                    <asp:ListItem Value="13">Application Recommened to MRO by Ground Water Department</asp:ListItem>
                                                    <asp:ListItem Value="16">Application Not Recommened by Ground Water Department</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td style="padding: 5px; margin: 5px;" class="auto-style5">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="ddlStatus"
                                                    ErrorMessage="Please Select Status" InitialValue="--Select--" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr id="tr_Remarks" visible="false" runat="server">
                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top" class="auto-style2"></td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" class="auto-style1">
                                                <asp:Label ID="label_head9" runat="server" CssClass="LBLBLACK" Width="334px">Reason Remarks</asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px" class="auto-style3">:
                                            </td>
                                            <td class="auto-style4" style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:TextBox ID="txtremarks" TextMode="MultiLine" runat="server" class="form-control txtbox"
                                                    TabIndex="1" ValidationGroup="group" Width="180px"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px;" class="auto-style5">&nbsp;
                                            </td>
                                        </tr>
                                        <tr runat="server" id="tr_filereferece" visible="false">
                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="middle" class="auto-style2"></td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" class="auto-style1">
                                                <asp:Label ID="label_head4" runat="server" CssClass="LBLBLACK" Width="313px">File Reference No<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px" class="auto-style3">:
                                            </td>
                                            <td class="auto-style4" style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:TextBox ID="txt_FileReferenceNo" runat="server" class="form-control txtbox"
                                                    Height="28px" MaxLength="30" TabIndex="1" ValidationGroup="group" Width="180px"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px;" class="auto-style5">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txt_FileReferenceNo"
                                                    ErrorMessage="Please Enter Reference Number" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr runat="server" id="tr_upload" visible="false">
                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="middle" class="auto-style2"></td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" class="auto-style1">
                                                <asp:Label ID="label_head5" runat="server" CssClass="LBLBLACK" Width="332px">Upload Certificate( .pdf Format Only)<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px" class="auto-style3">:
                                            </td>
                                            <td class="auto-style4" style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:FileUpload ID="file_uploadcert" runat="server" class="form-control txtbox" Height="28px" />
                                                <asp:HyperLink ID="lblFileName" runat="server" CssClass="LBLBLACK" Width="165px"
                                                    Target="_blank"></asp:HyperLink>
                                            </td>
                                            <td style="padding: 5px; margin: 5px;" class="auto-style5">
                                                <asp:Button ID="BtnSave3" runat="server" CssClass="btn btn-xs btn-warning" Height="28px"
                                                    TabIndex="10" Text="Upload" Width="72px" OnClick="BtnSave3_Click" />
                                            </td>
                                        </tr>


                                    </table>
                                </td>
                            </tr>

                            <tr>
                                <td colspan="2" style="padding: 5px; margin: 5px" valign="top" align="left">&nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2" align="center" style="padding: 5px; margin: 5px; text-align: center;">&nbsp;&nbsp;<asp:Button ID="BtnSave1" runat="server" CssClass="btn btn-primary" Height="32px"
                                    OnClick="BtnSave_Click" TabIndex="10" Text="Submit" ValidationGroup="group" Width="90px" />
                                    &nbsp;&nbsp;<asp:Button ID="BtnClear" Visible="false" runat="server" CausesValidation="False" CssClass="btn btn-warning"
                                        Height="32px" TabIndex="10" Text="Cancel" ToolTip="To Clear  the Screen"
                                        Width="90px" />
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2" align="center" style="padding: 5px; margin: 5px; text-align: center;">
                                    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/UI/TSiPASS/MRO_GroundwaterDashboard.aspx">Back</asp:HyperLink>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2" align="center" style="padding: 5px; margin: 5px">
                                    <div id="success" runat="server" visible="false" class="alert alert-success">
                                        <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a> <strong>Success!</strong><asp:Label ID="lblmsg" runat="server"></asp:Label>
                                    </div>
                                    <div id="Failure" runat="server" visible="false" class="alert alert-danger">
                                        <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a> <strong>Warning!</strong>
                                        <asp:Label ID="lblmsg0" runat="server"></asp:Label>
                                    </div>
                                </td>
                            </tr>
                        </table>

                        <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
                            ShowSummary="False" ValidationGroup="group" />
                        <asp:ValidationSummary ID="ValidationSummary2" runat="server" ShowMessageBox="True"
                            ShowSummary="False" ValidationGroup="child" />

                        <asp:HiddenField ID="hdfFlagID_applicantno" runat="server" />
                        <asp:HiddenField ID="hf_intApprovalid" runat="server" />
                        <asp:HiddenField ID="hf_intDeptid" runat="server" />
                        <asp:HiddenField ID="hf_intQuessionaireid" runat="server" />
                    </div>

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






</asp:Content>

