<%@ Page Language="C#" AutoEventWireup="true" CodeFile="frmPoliceAttachments.aspx.cs" MasterPageFile="~/UI/TSiPASS/CCMaster.master" Inherits="UI_TSIPASS_frmPoliceAttachments" %>

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
        .style6
        {
            width: 192px;
        }
        .style8
        {
            height: 53px;
        }
        .style9
        {
            width: 192px;
            height: 53px;
        }
        .style10
        {
            width: 10px;
            height: 53px;
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
                                <h3 class="panel-title">
                                    Attachment Details</h3>
                            </div>
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>
                                    <div class="panel-body">
                                        <table align="center" cellpadding="10" cellspacing="5" style="width: 90%">
                                            <tr>
                                                <td style="padding: 5px; margin: 5px" valign="top">
                                                    <asp:Label ID="Label422" runat="server" CssClass="LBLBLACK" Font-Bold="True" Width="210px">Attachments<font 
                                                            color="red">*</font></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="padding: 5px; margin: 5px" valign="top">
                                                    <table cellpadding="4" cellspacing="5" style="width: 100%">
                                                        <%-- <tr>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                1
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                
                                                                <asp:Label ID="Label387" runat="server" CssClass="LBLBLACK" Width="210px">B1 Form</asp:Label> <a href="../../docs/New/Consent for Emissin (Air) Form II - Part B1.pdf" target="_blank">Click here for download format</a>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                :
                                                            </td>
                                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:FileUpload ID="FileUpload1" runat="server" class="form-control txtbox" Height="28px" />
                                                                <asp:HyperLink ID="lblFileName" runat="server" CssClass="LBLBLACK" Width="165px"></asp:HyperLink>
                                                                <br />
                                                                <asp:Label ID="Label444" runat="server" Visible="False"></asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                                <asp:Button ID="BtnSave3" runat="server" CssClass="btn btn-xs btn-warning" Height="28px"
                                                                    TabIndex="10" Text="Upload" ValidationGroup="group" Width="72px" OnClick="BtnSave3_Click" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                2
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:Label ID="Label433" runat="server" CssClass="LBLBLACK" Width="210px">B2 Form</asp:Label><a href="../../docs/New/Consent for Discharge (Water) Form II - Part B2.pdf" target="_blank">Click here for download format</a>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                :
                                                            </td>
                                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:FileUpload ID="FileUpload2" runat="server" class="form-control txtbox" Height="28px" />
                                                                <asp:HyperLink ID="Label1" runat="server" CssClass="LBLBLACK" Width="165px"></asp:HyperLink>
                                                                <br />
                                                                <asp:Label ID="Label453" runat="server" Visible="False"></asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                                <asp:Button ID="BtnB2Form" runat="server" CssClass="btn btn-xs btn-warning" Height="28px"
                                                                    TabIndex="10" Text="Upload" ValidationGroup="group" Width="72px" OnClick="BtnB2Form_Click" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                3
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:Label ID="Label396" runat="server" CssClass="LBLBLACK" Width="165px">Hazardous Form</asp:Label><a href="../../docs/New/form-I for hazardous waste authorisation (1).doc" target="_blank">Click here for download format</a>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                :
                                                            </td>
                                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:FileUpload ID="FileUpload3" runat="server" class="form-control txtbox" Height="28px" />
                                                                <asp:HyperLink ID="Label2" runat="server" CssClass="LBLBLACK" Width="165px"></asp:HyperLink>
                                                                <br />
                                                                <asp:Label ID="Label454" runat="server" Visible="False"></asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                                <asp:Button ID="BtnHazForm" runat="server" CssClass="btn btn-xs btn-warning" Height="28px"
                                                                    TabIndex="10" Text="Upload" ValidationGroup="group" Width="72px" OnClick="BtnHazForm_Click" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="middle">
                                                                4
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:Label ID="Label435" runat="server" CssClass="LBLBLACK" Width="410px">Compliance Report</asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                :
                                                            </td>
                                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:FileUpload ID="FileUpload5" runat="server" class="form-control txtbox" Height="28px" />
                                                                <asp:HyperLink ID="Label4" runat="server" CssClass="LBLBLACK" Width="165px"></asp:HyperLink>
                                                                <br />
                                                                <asp:Label ID="Label455" runat="server" Visible="False"></asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                                <asp:Button ID="BtnCompRep" runat="server" CssClass="btn btn-xs btn-warning" Height="28px"
                                                                    TabIndex="10" Text="Upload" ValidationGroup="group" Width="72px" OnClick="BtnCompRep_Click" />
                                                            </td>
                                                        </tr>--%>
                                                        <tr id="trRentalDeed" runat="server">
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                1
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:Label ID="Label434" runat="server" CssClass="LBLBLACK" Width="207px">Ownership/Lease/Rental Deed</asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                :
                                                            </td>
                                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:FileUpload ID="fupRentalDeed" runat="server" class="form-control txtbox" Height="48px" />
                                                                <asp:HyperLink ID="hplRental" runat="server" CssClass="LBLBLACK" Width="165px"></asp:HyperLink>
                                                                <br />
                                                                <asp:Label ID="LblRental" runat="server" Visible="False"></asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                                <asp:Button ID="BtnSaleDeed" runat="server" CssClass="btn btn-xs btn-warning" Height="28px"
                                                                    TabIndex="10" Text="Upload" ValidationGroup="group"
                                                                    Width="72px" OnClick="BtnSaleDeed_Click" />
                                                            </td>
                                                        </tr>
                                                        <tr id="trSiteplan" runat="server">
                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="middle">
                                                                2
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:Label ID="Label471" runat="server" CssClass="LBLBLACK" Width="207px">Site plan (Blue print)</asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                :
                                                            </td>
                                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:FileUpload ID="fupsiteplan" runat="server" class="form-control txtbox" Height="48px" />
                                                                <asp:HyperLink ID="hplSiteplan" runat="server" CssClass="LBLBLACK" Width="165px"></asp:HyperLink>
                                                                <br />
                                                                <asp:Label ID="lblSiteplan" runat="server" Visible="False"></asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                                <asp:Button ID="BtnSitePlan" runat="server" CssClass="btn btn-xs btn-warning" Height="28px"
                                                                     TabIndex="10" Text="Upload" ValidationGroup="group"
                                                                    Width="72px" OnClick="BtnSitePlan_Click" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="middle">
                                                                3&nbsp;</td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:Label ID="Label465" runat="server" CssClass="LBLBLACK" Width="165px">Trade license from MCH</asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                :
                                                            </td>
                                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:FileUpload ID="fupTradeLic" runat="server" class="form-control txtbox" Height="48px" />
                                                                <asp:HyperLink ID="hpllblTradeLic" runat="server" CssClass="LBLBLACK" Width="165px"></asp:HyperLink>
                                                                <br />
                                                                <asp:Label ID="lblTradeLic" runat="server" Visible="False"></asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                                <asp:Button ID="BtnTradeLic" runat="server" CssClass="btn btn-xs btn-warning" Height="28px"
                                                                     TabIndex="10" Text="Upload" ValidationGroup="group"
                                                                    Width="72px" OnClick="BtnTradeLic_Click" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="middle">
                                                                4
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:Label ID="Label468" runat="server" CssClass="LBLBLACK" Width="195px">NOC from District Fire Officer</asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                &nbsp;
                                                            </td>
                                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:FileUpload ID="fupDfo" runat="server" class="form-control txtbox" Height="48px" />
                                                                <asp:HyperLink ID="hplDFO" runat="server" CssClass="LBLBLACK" Width="165px"></asp:HyperLink>
                                                                <br />
                                                                <asp:Label ID="lblDFO" runat="server" Visible="False"></asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                                <asp:Button ID="BtnFire" runat="server" CssClass="btn btn-xs btn-warning" Height="28px"
                                                                   TabIndex="10" Text="Upload" ValidationGroup="group"
                                                                    Width="72px" OnClick="BtnFire_Click" />
                                                            </td>
                                                        </tr>
                                                        <tr id="trpartnershipdeed">
                                                            <td class="style8" style="padding: 5px; margin: 5px; text-align: left;">
                                                                5</td>
                                                            <td class="style8" style="padding: 5px; margin: 5px; text-align: left;">
                                                                Whether your Establishment has Bar/Restaurant
                                                            </td>
                                                            <td class="style8" style="padding: 5px; margin: 5px">
                                                                :
                                                            </td>
                                                            <td class="style9" colspan="2" style="padding: 5px; margin: 5px; text-align: left;">
                                                                <br />
                                                                <asp:RadioButtonList ID="rdbBarRest" runat="server" RepeatDirection="Horizontal" AutoPostBack="true" OnSelectedIndexChanged="rdbBarRest_SelectedIndexChanged">
                                                                    <asp:ListItem Value="Y">Yes</asp:ListItem>
                                                                    <asp:ListItem Value="N">No</asp:ListItem>
                                                                </asp:RadioButtonList>
                                                                <br />
                                                            </td>
                                                            
                                                        </tr>
                                                        <tr id="trExciseLicense" runat="server" visible="false">
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                5(a)</td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:Label ID="Label447" runat="server" CssClass="LBLBLACK" Width="165px">Excise License</asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                :
                                                            </td>
                                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:FileUpload ID="fupExcise" runat="server" class="form-control txtbox" Height="48px" />
                                                                <asp:HyperLink ID="hplExciseLic" runat="server" CssClass="LBLBLACK" Width="165px"></asp:HyperLink>
                                                                <br />
                                                                <asp:Label ID="lblExciseLic" runat="server" Visible="False"></asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                                <asp:Button ID="btnExcise" runat="server" CssClass="btn btn-xs btn-warning" Height="28px"
                                                                    TabIndex="10" Text="Upload" ValidationGroup="group" Width="72px" OnClick="btnExcise_Click"  />
                                                            </td>
                                                        </tr>
                                                        <tr id="trlandowner">
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                6
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:Label ID="Label448" runat="server" CssClass="LBLBLACK" Width="475px">Whether all the Documents/NOC/License are in the name of the applicant</asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                :
                                                            </td>
                                                            <td class="style6" colspan="2" style="padding: 5px; margin: 5px; text-align: left;">
                                                                <br />
                                                                <asp:RadioButtonList ID="rdbWhetherAll" runat="server"  RepeatDirection="Horizontal">
                                                                    <asp:ListItem Value="Y">Yes</asp:ListItem>
                                                                    <asp:ListItem Value="N">No</asp:ListItem>
                                                                </asp:RadioButtonList>
                                                            </td>
                                                         
                                                        </tr>
                                                        
                                                    </table>
                                                </td>
                                            </tr>
                                            <caption>
                                                &nbsp;</caption>
                                            <tr>
                                                <td align="center" style="padding: 5px; margin: 5px; text-align: center;">
                                                    <asp:Button ID="BtnSave" runat="server" CssClass="btn btn-primary" Height="32px"
                                                         TabIndex="10" Text="Save" ValidationGroup="group" Width="90px" OnClick="BtnSave_Click" />
                                                    &nbsp;&nbsp;<asp:Button ID="BtnDelete0" runat="server" CausesValidation="False" CssClass="btn btn-danger"
                                                        Height="32px" TabIndex="10" Text="Previous" Width="90px" OnClick="BtnDelete0_Click" />
                                                    &nbsp;&nbsp;<asp:Button ID="BtnDelete" runat="server" CausesValidation="False" CssClass="btn btn-danger"
                                                        Height="32px" TabIndex="10" Text="Next" Width="90px" OnClick="BtnDelete_Click" />
                                                   &nbsp;&nbsp; 
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
                                        </table>
                                        <asp:HiddenField ID="hdfID" runat="server" />
                                        <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
                                            ShowSummary="False" ValidationGroup="group" />
                                        <asp:ValidationSummary ID="ValidationSummary2" runat="server" ShowMessageBox="True"
                                            ShowSummary="False" ValidationGroup="child" />
                                        <asp:HiddenField ID="hdfFlagID" runat="server" />
                                        <br />
                                        <asp:HiddenField ID="hdfFlagID0" runat="server" />
                                          <asp:ValidationSummary ID="ValidationSummary3" runat="server" ShowMessageBox="True"
                                            ShowSummary="False" ValidationGroup="group" />
                                    </div>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                    </div>
                </div>
            </div>
            <asp:UpdateProgress ID="UpdateProgress" runat="server" AssociatedUpdatePanelID="updatepanel1">
                <ProgressTemplate>
                    <div class="overlay">
                        <%--<div style=" z-index: 1000; margin-left: 350px;margin-top:200px;opacity: 1;-moz-opacity: 1;">
                        <div style="z-index: 1000; margin-left: -210px; margin-top: 100px; opacity: 1; -moz-opacity: 1;">
                            <img alt="" src="../../Resource/Images/Processing.gif" />--%>
                    </div>
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
          
            <asp:PostBackTrigger ControlID="BtnSaleDeed"></asp:PostBackTrigger>
            <asp:PostBackTrigger ControlID="BtnSitePlan"></asp:PostBackTrigger>
            <asp:PostBackTrigger ControlID="BtnTradeLic"></asp:PostBackTrigger>
            <asp:PostBackTrigger ControlID="BtnFire"></asp:PostBackTrigger>
            <asp:PostBackTrigger ControlID="btnExcise"></asp:PostBackTrigger>
            
        </Triggers>
    </asp:UpdatePanel>
    <%--</div>
       </td>
        </tr>
    </table>--%>

    </asp:Content>
 