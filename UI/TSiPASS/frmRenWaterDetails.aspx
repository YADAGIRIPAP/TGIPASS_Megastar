<%@ Page Title="" Language="C#" MasterPageFile="~/UI/TSiPASS/CCMaster.master" AutoEventWireup="true" CodeFile="frmRenWaterDetails.aspx.cs" Inherits="UI_TSiPASS_frmRenWaterDetails" %>

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
    </script>

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

    <asp:UpdatePanel ID="upd1" runat="server">
        <ContentTemplate>
            <div align="left">
                <ol class="breadcrumb">
                    You are here &nbsp;!&nbsp; &nbsp; &nbsp;
                    <li><i class="fa fa-dashboard"></i><a href="Home.aspx"></a></li>
                    <li class=""><i class="fa fa-fw fa-edit">CAF</i> </li>
                    <li class="active"><i class="fa fa-edit"></i><a href="#">Water Details</a> </li>
                </ol>
            </div>
            <div align="left">
                <div class="row" align="left">
                    <div class="col-lg-11">
                        <div class="panel panel-primary">
                            <div class="panel-heading" align="center">
                                <h3 class="panel-title">Water Details</h3>
                            </div>
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>
                                    <div class="panel-body">
                                        <table align="center" cellpadding="10" cellspacing="5" style="width: 90%">
                                            <tr>
                                                <%--<td style="padding: 5px; margin: 5px" valign="top" align="left">&nbsp;</td>--%>
                                                <td style="padding: 5px; margin: 5px; text-align: left;" valign="top" colspan="5"><b>Please enter the below details</b>
                                                </td>
                                                <td valign="top">&nbsp;
                                                </td>
                                            </tr>
                                            <tr>

                                                <td style="padding: 5px; margin: 5px; text-align: left; width: 30px">1
                                                </td>
                                                <td style="padding: 5px; margin: 5px; text-align: left; width: 350px">
                                                    <asp:Label ID="Label401" runat="server" CssClass="LBLBLACK">Installed Capacity at the time of Renewal<font 
                                                            color="red"> *</font></asp:Label>
                                                </td>
                                                <td style="padding: 5px; margin: 5px; width: 35px">:
                                                </td>
                                                <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                    <asp:TextBox ID="txtinstalledCalpacity" runat="server" class="form-control txtbox" Height="28px"
                                                        MaxLength="40" onkeypress="return inputOnlyNumbers(event)" TabIndex="1" ValidationGroup="group"
                                                        Width="180px"></asp:TextBox>
                                                </td>
                                                <td style="padding: 5px; margin: 5px; width: 10px;">
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtinstalledCalpacity"
                                                        ErrorMessage="Please Enter Drinking Water" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">2
                                                </td>
                                                <td style="padding: 5px; margin: 5px; text-align: left;">
                                                    <asp:Label ID="Label402" runat="server" CssClass="LBLBLACK">Quantum of Water withdrawn in mcft<font 
                                                            color="red"> *</font></asp:Label>
                                                </td>
                                                <td style="padding: 5px; margin: 5px">:
                                                </td>
                                                <td style="padding: 5px; margin: 5px; text-align: left;">
                                                    <asp:TextBox ID="txtWaterQuantity" runat="server" class="form-control txtbox"
                                                        Height="28px" MaxLength="40" onkeypress="return inputOnlyNumbers(event)" TabIndex="1"
                                                        ValidationGroup="group" Width="180px"></asp:TextBox>
                                                </td>
                                                <td style="padding: 5px; margin: 5px">
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtWaterQuantity"
                                                        ErrorMessage="Please Enter Water for Processing" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                </td>
                                            </tr>

                                            <tr runat="server" visible="false">
                                                <td style="padding: 5px; margin: 5px; text-align: left;">3
                                                </td>
                                                <td style="padding: 5px; margin: 5px; text-align: left;">
                                                    <asp:Label ID="Label424" runat="server" CssClass="LBLBLACK" Width="200px">Arrear Amount<font 
                                                            color="red"> *</font></asp:Label>
                                                </td>
                                                <td style="padding: 5px; margin: 5px">:
                                                </td>
                                                <td style="padding: 5px; margin: 5px; text-align: left;">
                                                    <asp:TextBox ID="txtRequirement_Water" runat="server" class="form-control txtbox"
                                                        Height="28px" MaxLength="40" onkeypress="return inputOnlyNumbers(event)" TabIndex="1"
                                                        ValidationGroup="group" Width="180px"></asp:TextBox>
                                                </td>
                                                <td style="padding: 5px; margin: 5px">
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtRequirement_Water"
                                                        ErrorMessage="Please Enter Requirement of Water" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                        </table>
                                        <table  align="center" cellpadding="10" cellspacing="5" style="width: 90%">
                                            <tr>
                                                <td colspan="4">
                                                    <table>
                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top" colspan="5"><b>Please Upolad Below Documents</b>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px; text-align: left; width: 30px">1</td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left; width: 400px">EE certification for No change in Capacity of withdrawl</td>
                                                            <td style="padding: 5px; margin: 5px; width: 30px">:</td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:FileUpload ID="fupCapNoChangeCertf" runat="server" class="form-control txtbox"
                                                                    Height="28px" MaxLength="40" TabIndex="1"
                                                                    ValidationGroup="group" Width="180px"></asp:FileUpload>
                                                                <asp:HyperLink ID="hplCapNoChangeCertf" runat="server"></asp:HyperLink>
                                                                   <asp:Label ID="lblOtherPlans" runat="server" Visible="False"></asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="fupCapNoChangeCertf"
                                                                    ErrorMessage="Please Select  Area Name" InitialValue="--Select--" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                                <asp:Button ID="btnCapNoChangeCertf" runat="server" CssClass="btn btn-xs btn-warning"
                                                                    Height="28px" TabIndex="10" Text="Upload"
                                                                    Width="72px" OnClick="btnCapNoChangeCertf_Click" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="center">2</td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">EE certfication for not drawing more than Allocated water</td>
                                                            <td style="padding: 5px; margin: 5px">:</td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:FileUpload ID="fupNoMoreWaterCertf" runat="server" class="form-control txtbox"
                                                                    Height="28px" MaxLength="40" TabIndex="1"
                                                                    ValidationGroup="group" Width="180px"></asp:FileUpload>
                                                                <asp:HyperLink ID="hplNoMoreWaterCertf" runat="server"></asp:HyperLink>
                                                                  <asp:Label ID="lblCellarFloor" runat="server" Visible="False"></asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="fupNoMoreWaterCertf"
                                                                    ErrorMessage="Please Select  Area Name" InitialValue="--Select--" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                                <asp:Button ID="btnNoMoreWaterCertf" runat="server" CssClass="btn btn-xs btn-warning"
                                                                    Height="28px" TabIndex="10" Text="Upload"
                                                                    Width="72px" OnClick="btnNoMoreWaterCertf_Click" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="center">3</td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">I&CAD Dept EE certificate for Flow meter seal</td>
                                                            <td style="padding: 5px; margin: 5px">:</td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:FileUpload ID="fupFlowMeterSealCertf" runat="server" class="form-control txtbox"
                                                                    Height="28px" MaxLength="40" TabIndex="1"
                                                                    ValidationGroup="group" Width="180px"></asp:FileUpload>
                                                                <asp:HyperLink ID="hplFlowMeterSealCertf" runat="server"></asp:HyperLink>
                                                                  <asp:Label ID="lblGroundFloor" runat="server" Visible="False"></asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="fupFlowMeterSealCertf"
                                                                    ErrorMessage="Please Select  Area Name" InitialValue="--Select--" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                                <asp:Button ID="btnFlowMeterSealCertf" runat="server" CssClass="btn btn-xs btn-warning"
                                                                    Height="28px" TabIndex="10" Text="Upload"
                                                                    Width="72px" OnClick="btnFlowMeterSealCertf_Click" />
                                                            </td>
                                                        </tr>

                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">&nbsp;
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">&nbsp;
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">&nbsp;
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">&nbsp;
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">&nbsp;
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>

                                            </tr>
                                          
                                            <tr>
                                                <td style="padding: 5px; margin: 5px" valign="top">&nbsp;
                                                </td>
                                                <td style="width: 27px">&nbsp;
                                                </td>
                                                <td valign="top">&nbsp;
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center" colspan="6" style="padding: 5px; margin: 5px; text-align: center;">
                                                    <asp:Button ID="BtnClear" runat="server" CausesValidation="False" CssClass="btn btn-warning"
                                                        Height="32px" OnClick="BtnClear_Click" TabIndex="10" Text="ClearAll" ToolTip="To Clear  the Screen"
                                                        ValidationGroup="group" Width="90px" />
                                                    &nbsp;
                                                    <asp:Button ID="BtnSave" runat="server" CausesValidation="False" CssClass="btn btn-primary"
                                                        Height="32px" OnClick="BtnSave_Click" TabIndex="10" Text="Save" ValidationGroup="ggg"
                                                        Width="90px" />
                                                    &nbsp;<asp:Button ID="btnPrevious" runat="server" CssClass="btn btn-danger" Height="32px"
                                                        OnClick="btnPrevious_Click" TabIndex="10" Text="Previous" Width="90px" CausesValidation="False" />
                                                    &nbsp;&nbsp;<asp:Button ID="btnNext" runat="server" CssClass="btn btn-danger" Height="32px"
                                                        OnClick="btnNext_Click" TabIndex="10" Text="Next" ValidationGroup="group" Width="90px" />


                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center" colspan="6" style="padding: 5px; margin: 5px">
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
                                        <asp:ValidationSummary ID="ValidationSummary2" runat="server" ShowMessageBox="True"
                                            ShowSummary="False" ValidationGroup="child" />
                                        <asp:HiddenField ID="hdfFlagID" runat="server" />
                                        <asp:HiddenField ID="hdfFlagID0" runat="server" />
                                        <br />
                                        <asp:HiddenField ID="hdfpencode" runat="server" />
                                    </div>
                                </ContentTemplate>
                            </asp:UpdatePanel>
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
            <asp:PostBackTrigger ControlID="btnCapNoChangeCertf" />
            <asp:PostBackTrigger ControlID="btnNoMoreWaterCertf" />
            <asp:PostBackTrigger ControlID="btnFlowMeterSealCertf" />
        </Triggers>
    </asp:UpdatePanel>
    <%--</div>
       </td>
        </tr>
    </table>--%>
</asp:Content>


