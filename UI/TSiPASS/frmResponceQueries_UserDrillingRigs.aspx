<%@ Page Title="" Language="C#" MasterPageFile="~/UI/TSiPASS/CCMaster.master" AutoEventWireup="true" CodeFile="frmResponceQueries_UserDrillingRigs.aspx.cs" Inherits="UI_TSiPASS_frmResponceQueries_UserDrillingRigs" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
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
        .style6
        {
            width: 192px;
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
                        <h3 class="panel-title">
                            Query Response Details</h3>
                    </div>
                    <div class="panel-body">
                        <table align="center" cellpadding="10" cellspacing="5" style="width: 90%">
                            <tr>
                                <td style="padding: 5px; margin: 5px" valign="top">
                                    <asp:Label ID="Label422" runat="server" CssClass="LBLBLACK" Font-Bold="True" Width="210px">Responce Query</asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="padding: 5px; margin: 5px" valign="top">
                                    <table cellpadding="4" cellspacing="5" style="width: 100%">
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                1
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="lbl_headtitleuidno" runat="server" CssClass="LBLBLACK" Width="210px">UID Number<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                :
                                            </td>
                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="lbl_uidno" runat="server"></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                2
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="lbl_headnameoftheapplicant" runat="server" CssClass="LBLBLACK" Width="210px">Name of Applicant<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                :
                                            </td>
                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="lbl_nameoftheapplicant" runat="server"></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                3
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="lbl_headplaceofrto" runat="server" CssClass="LBLBLACK" Width="165px">Place of RTO Registration<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                :
                                            </td>
                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="lbl_placeofrtoregistration" runat="server"></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                4
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="lbl_headapplicationtype" runat="server" CssClass="LBLBLACK" Width="410px">Application Type<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                :
                                            </td>
                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="lbl_applicationtype" runat="server"></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                5
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="lbl_headdepartmetname" runat="server" CssClass="LBLBLACK" Width="165px">Department Name<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                :
                                            </td>
                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="lbl_departmentname" runat="server"></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                6
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="lbl_headapproval" runat="server" CssClass="LBLBLACK" Width="410px">Department Approval<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                :
                                            </td>
                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="lbl_approvalname" runat="server"></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                7
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="lbl_headqueryraiseddate" runat="server" CssClass="LBLBLACK" Width="410px">Query Raise Date<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                :
                                            </td>
                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="lbl_queryraiseddate" runat="server"></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                8
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="lbl_headquerydescription" runat="server" CssClass="LBLBLACK" Width="410px">Query Description<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                :
                                            </td>
                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="lbl_querydescription" runat="server"></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                9
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                Query Response*
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                :
                                            </td>
                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:TextBox ID="txtdiscription" runat="server" class="form-control txtbox" Height="40px"
                                                    TextMode="MultiLine" ValidationGroup="group" Width="180px"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="txtdiscription"
                                                    ErrorMessage="Please Enter Query Response" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr id="trresponseattachment" runat="server" visible="true">
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                10&nbsp;
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label439" runat="server" CssClass="LBLBLACK" Width="165px">Reponse  Attachment<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                :
                                            </td>
                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:FileUpload ID="FileUpload1" runat="server" class="form-control txtbox" />
                                                <asp:Label ID="Label440" runat="server" CssClass="LBLBLACK" Width="165px"></asp:Label>
                                                <asp:HyperLink ID="hyp_resattach" Text="View" Visible="false" runat="server"></asp:HyperLink>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                <asp:Button ID="Button6" runat="server" CssClass="btn btn-xs btn-warning" Height="28px"
                                                    TabIndex="10" Text="Upload" ValidationGroup="group" Width="72px" OnClick="Button6_Click" />
                                            </td>
                                        </tr>
                                      
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td style="padding: 5px; margin: 5px" valign="top" align="left">
                                    &nbsp;
                                </td>
                            </tr>
                            <caption>
                                &nbsp;</caption>
                           
                            <tr>
                                <td align="center" style="padding: 5px; margin: 5px; text-align: center;">
                                    &nbsp;&nbsp;<asp:Button ID="BtnDelete" runat="server" CausesValidation="False" CssClass="btn btn-danger"
                                        Height="32px" OnClick="BtnClear_Click" TabIndex="10" Text="Submit" Width="90px"
                                        OnClientClick="return confirm('Do you want to Submit the record ? ');" />
                                    &nbsp;&nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td align="center" style="padding: 5px; margin: 5px">
                                    <div id="success" runat="server" visible="false" class="alert alert-success">
                                        <a href="#" class="close" data-dismiss="alert" aria-label="close">
                                            &times;</a> <strong>Success!</strong><asp:Label ID="lblmsg" runat="server"></asp:Label>
                                    </div>
                                    <div id="Failure" runat="server" visible="false" class="alert alert-danger">
                                        <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a> <strong>
                                            Warning!</strong>
                                        <asp:Label ID="lblmsg0" runat="server"></asp:Label>
                                    </div>
                                </td>
                            </tr>
                        </table>
                        <asp:HiddenField ID="hdfID" runat="server" />
                        <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
                            ShowSummary="False" ValidationGroup="group" />
                        <asp:ValidationSummary ID="ValidationSummary2" runat="server" ShowMessageBox="True"
                            ShowSummary="False" ValidationGroup="child" />
                        <asp:HiddenField ID="hdfFlagID" runat="server" />
                        <asp:HiddenField ID="hf_intapplicationid" runat="server" />
                        <asp:HiddenField ID="hf_intdeptid" runat="server" />
                        <asp:HiddenField ID="hf_intapprovalid" runat="server" />
                        <br />
                        <asp:HiddenField ID="hf_intcfeentrpid" runat="server" />
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

