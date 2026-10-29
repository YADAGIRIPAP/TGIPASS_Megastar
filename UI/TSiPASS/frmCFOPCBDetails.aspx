<%@ Page Title=":: TS-iPASS ::  " Language="C#" MasterPageFile="~/UI/TSiPASS/CCMaster.master"AutoEventWireup="true" CodeFile="frmCFOPCBDetails.aspx.cs" Inherits="TSTBDCReg1" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>


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
background-color:Gray;
filter: alpha(opacity=60);
opacity: 0.9;
-moz-opacity: 0.9;
}
    .style6
    {
        width: 192px;
    }
    .style7
    {
        color: #FF3300;
    }
    .style8
    {
        width: 263px;
    }
    .style9
    {
        width: 19px;
    }
    .style10
    {
        width: 15px;
    }
    .style11
    {
        width: 103px;
    }
</style>

<script type="text/javascript" language="javascript">

function OpenPopup() 
 
   {

       window.open("frmViewAttachmentDetails.aspx?intApplicationid=" + document.getElementById("ctl00_ContentPlaceHolder1_hdfFlagID0").value, "List", "scrollbars=yes,resizable=yes,width=1000,height=650;display = block;position=absolute");

    return false;
    }
    </script>
    <%-----------------11------------------------------------------------------%>   <%----------------12-------------------------------------------------------%>
<div align="left">
    <ol class="breadcrumb">You are here
        &nbsp;!&nbsp; &nbsp; &nbsp; 
                            <li>
                                <i class="fa fa-dashboard"></i>  <a href="Home.aspx"></a>
                            </li>
                            <li class="">
                                <i class="fa fa-fw fa-edit">CAF</i> 
                            </li>
                            <li class="active">
                                <i class="fa fa-edit"></i> <a href="#">Attachment Details</a>
                            
            </li>
        </ol>
    </div>
    <div align="left">
        <div class="row" align="left">
            <div class="col-lg-11">
                <div class="panel panel-primary">
                    <div class="panel-heading" align="center">
                        <h3 class="panel-title">
                            PCB Details</h3>
                    </div>
                    <%-----------------12------------------------------------------------------%>
                    <div class="panel-body">
                        <table align="center" cellpadding="10" cellspacing="5" style="width: 90%">
                            <tr>
                                <td style="padding: 5px; margin: 5px" valign="top">
                                    <asp:Label ID="Label422" runat="server" CssClass="LBLBLACK" Font-Bold="True" Width="210px">Common Attachments<font 
                                                            color="red">*</font></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="padding: 5px; margin: 5px" valign="top">
                                    <table cellpadding="4" cellspacing="5" style="width: 100%; text-align: left;">
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" class="style9">
                                                1
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" class="style8">
                                                <asp:Label ID="Label387" runat="server" CssClass="LBLBLACK" Width="210px">B1 
                                                        Form<font 
                                                            color="red">*</font></asp:Label><a href="../../docs/New/Consent for Emissin (Air) Form II - Part B1.pdf"
                                                                target="_blank">Click here for download format</a>
                                            </td>
                                            <td style="padding: 5px; margin: 5px" class="style10">
                                                :
                                            </td>
                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:FileUpload ID="FileUpload1" runat="server" class="form-control txtbox" Height="28px"
                                                    Width="200px" />
                                                <asp:HyperLink ID="lblFileName" runat="server" CssClass="LBLBLACK" Width="165px"
                                                    Target="_blank"></asp:HyperLink>
                                                <br />
                                                <asp:Label ID="Label444" runat="server" Visible="False"></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                <asp:Button ID="BtnSave3" runat="server" CssClass="btn btn-xs btn-warning" Height="28px"
                                                    TabIndex="10" Text="Upload" ValidationGroup="group" Width="72px" OnClick="BtnSave3_Click" />
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                <asp:Label ID="Label448" runat="server" Text="Label" Visible="False" Width="160px"></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                &nbsp;
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                &nbsp;
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" class="style9">
                                                2
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" class="style8">
                                                <asp:Label ID="Label433" runat="server" CssClass="LBLBLACK" Width="210px">B2 
                                                        Form<font 
                                                            color="red">*</font></asp:Label><a href="../../docs/New/Consent for Discharge (Water) Form II - Part B2.pdf"
                                                                target="_blank">Click here for download format</a>
                                            </td>
                                            <td style="padding: 5px; margin: 5px" class="style10">
                                                :
                                            </td>
                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:FileUpload ID="FileUpload2" runat="server" class="form-control txtbox" Height="28px" />
                                                <asp:HyperLink ID="Label1" runat="server" CssClass="LBLBLACK" Width="165px" Target="_blank"></asp:HyperLink>
                                                <br />
                                                <asp:Label ID="Label445" runat="server" Visible="False"></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                <asp:Button ID="Button1" runat="server" CssClass="btn btn-xs btn-warning" Height="28px"
                                                    TabIndex="10" Text="Upload" ValidationGroup="group" Width="72px" OnClick="Button1_Click" />
                                            </td>
                                            <td style="padding: 5px; margin: 5px;" class="style11">
                                                &nbsp;
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                &nbsp;
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                &nbsp;
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" class="style9">
                                                3
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" class="style8">
                                                <asp:Label ID="Label396" runat="server" CssClass="LBLBLACK" Width="165px">Hazardous 
                                                        Form<font 
                                                            color="red">*</font></asp:Label><a href="../../docs/New/form-I for hazardous waste authorisation (1).doc"
                                                                target="_blank">Click here for download format</a>
                                            </td>
                                            <td style="padding: 5px; margin: 5px" class="style10">
                                                :
                                            </td>
                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:FileUpload ID="FileUpload3" runat="server" class="form-control txtbox" Height="28px" />
                                                <asp:HyperLink ID="Label2" runat="server" CssClass="LBLBLACK" Width="165px" Target="_blank"></asp:HyperLink>
                                                <br />
                                                <asp:Label ID="Label446" runat="server" Visible="False"></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                <asp:Button ID="Button2" runat="server" CssClass="btn btn-xs btn-warning" Height="28px"
                                                    TabIndex="10" Text="Upload" ValidationGroup="group" Width="72px" OnClick="Button2_Click" />
                                            </td>
                                            <td style="padding: 5px; margin: 5px;" class="style11">
                                                &nbsp;
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                &nbsp;
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                &nbsp;
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="middle" class="style9">
                                                4
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" class="style8">
                                                <asp:Label ID="Label435" runat="server" CssClass="LBLBLACK" Width="410px">Compliance 
                                                        Report<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px" class="style10">
                                                :
                                            </td>
                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:FileUpload ID="FileUpload5" runat="server" class="form-control txtbox" Height="28px" />
                                                <asp:HyperLink ID="Label4" runat="server" CssClass="LBLBLACK" Width="165px" Target="_blank"></asp:HyperLink>
                                                <br />
                                                <asp:Label ID="Label447" runat="server" Visible="False"></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                <asp:Button ID="Button4" runat="server" CssClass="btn btn-xs btn-warning" Height="28px"
                                                    TabIndex="10" Text="Upload" ValidationGroup="group" Width="72px" OnClick="Button4_Click" />
                                            </td>
                                            <td style="padding: 5px; margin: 5px;" class="style11">
                                                &nbsp;
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                &nbsp;
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                &nbsp;
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <%----------------13-------------------------------------------------------%>
                                        <%-----------------13------------------------------------------------------%>
                                        <%----------------14-------------------------------------------------------%>
                                        <%-----------------14------------------------------------------------------%>
                                        <%----------------15-------------------------------------------------------%>
                                        <%-----------------15------------------------------------------------------%>
                                        <%----------------16-------------------------------------------------------%>
                                        <%-----------------16------------------------------------------------------%>
                                        <%----------------17-------------------------------------------------------%>
                                        <%-----------------17------------------------------------------------------%>
                                        <%----------------18-------------------------------------------------------%>
                                        <%-----------------18------------------------------------------------------%>
                                        <%----------------19-------------------------------------------------------%>
                                        <%-----------------19------------------------------------------------------%>
                                        <%----------------20-------------------------------------------------------%>
                                        <%-----------------20------------------------------------------------------%>
                                        <%-- <asp:CommandField HeaderText="Delete" ShowDeleteButton="True" />
--%>
                                        <%--       </ContentTemplate>
</asp:UpdatePanel>--%>
                                        <%-- <asp:UpdateProgress ID="UpdateProgress" runat="server" AssociatedUpdatePanelID="updatepanel1">
<ProgressTemplate>--%>
                                        <%--<div class="overlay">--%>
                                        <%--<div style=" z-index: 1000; margin-left: 350px;margin-top:200px;opacity: 1;-moz-opacity: 1;">--%>
                                        <%--<div style=" z-index: 1000; margin-left: -210px;margin-top:100px;opacity: 1; -moz-opacity: 1;">--%>
                                        <%--<img alt="" src="../../Resource/Images/Processing.gif" />
--%>
                                        <%--</ProgressTemplate>
</asp:UpdateProgress> --%>
                                        <%--</ContentTemplate>
  </asp:UpdatePanel>--%>
                                        <%-- </div>
       </td>
        </tr>
    </table>--%>
                                        <%----------------20-------------------------------------------------------%>
                                        <%-----------------20------------------------------------------------------%>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td style="padding: 5px; margin: 5px" valign="top">
                                    <table cellpadding="4" cellspacing="5" style="width: 100%">
                                        <tr>
                                            <td style="padding: 5px; margin: 5px">
                                                :<td style="padding: 5px; margin: 5px" valign="top">
                                                    &nbsp;
                                                </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px" align="center" class="style7">
                                                &nbsp;<tr>
                                                    <td style="padding: 5px; margin: 5px; text-align: center;" align="center">
                                                        <asp:Button ID="BtnClear0" runat="server" CausesValidation="False" CssClass="btn btn-warning"
                                                            Height="32px" OnClick="BtnClear0_Click2" TabIndex="10" Text="View Attachment"
                                                            ToolTip="To Clear  the Screen" Width="140px" Visible="False" />
                                                    </td>
                                                </tr>
                                                <caption>
                                                    &nbsp;</caption>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center" style="padding: 5px; margin: 5px; text-align: center;">
                                                <asp:Button ID="BtnSave1" runat="server" CssClass="btn btn-primary" Height="32px"
                                                    OnClick="BtnSave_Click" TabIndex="10" Text="Save" ValidationGroup="group" Width="90px"
                                                    Visible="False" />
                                                &nbsp;&nbsp;<asp:Button ID="BtnDelete" runat="server" CausesValidation="False" CssClass="btn btn-danger"
                                                    Height="32px" OnClick="BtnClear_Click" TabIndex="10" Text="Next" Width="90px" />
                                                &nbsp;<asp:Button ID="BtnDelete0" runat="server" CausesValidation="False" CssClass="btn btn-danger"
                                                    Height="32px" OnClick="BtnClear0_Click" TabIndex="10" Text="Previous" Width="90px" />
                                                &nbsp;<asp:Button ID="BtnClear" runat="server" CausesValidation="False" CssClass="btn btn-warning"
                                                    Height="32px" OnClick="BtnClear_Click" TabIndex="10" Text="ClearAll" ToolTip="To Clear  the Screen"
                                                    Width="90px" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center" style="padding: 5px; margin: 5px">
                                                <div id="success" runat="server" visible="false" class="alert alert-success">
                                                    <a href="AddQualification.aspx" class="close" data-dismiss="alert" aria-label="close">
                                                        ×times;</a> <strong>Success!</strong><asp:Label ID="lblmsg" runat="server"></asp:Label>
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
                                    <asp:HiddenField ID="hdfFlagID0" runat="server" />
                    </div>
                    <%--       </ContentTemplate>
</asp:UpdatePanel>--%>
                </div>
            </div>
        </div>
    </div>
    <%-- <asp:UpdateProgress ID="UpdateProgress" runat="server" AssociatedUpdatePanelID="updatepanel1">
<ProgressTemplate>--%>
    <%--<div class="overlay">--%>
    <%--<div style=" z-index: 1000; margin-left: 350px;margin-top:200px;opacity: 1;-moz-opacity: 1;">--%>
    <%--<div style=" z-index: 1000; margin-left: -210px;margin-top:100px;opacity: 1; -moz-opacity: 1;">--%>
    <%--<img alt="" src="../../Resource/Images/Processing.gif" />
--%>
    </div> </div>
    <%--</ProgressTemplate>
</asp:UpdateProgress> --%>
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
    <%--</ContentTemplate>
  </asp:UpdatePanel>--%>
    <%-- </div>
       </td>
        </tr>
    </table>--%>
</asp:Content>
