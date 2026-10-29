<%@ Page Title="" Language="C#" MasterPageFile="~/UI/TSiPASS/CCMaster.master" AutoEventWireup="true" CodeFile="frmapplicationForLicenceRenewal.aspx.cs" Inherits="UI_TSiPASS_frmapplicationForLicenceRenewal" %>

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

        .style7 {
            color: #FF3300;
        }

        .style8 {
            width: 263px;
        }

        .style9 {
            width: 19px;
        }

        .style10 {
            width: 15px;
        }

        .style11 {
            width: 103px;
        }
    </style>
    <script type="text/javascript" language="javascript">

        function OpenPopup() {

            window.open("frmViewAttachmentDetails.aspx?intApplicationid=" + document.getElementById("ctl00_ContentPlaceHolder1_hdfFlagID0").value, "List", "scrollbars=yes,resizable=yes,width=1000,height=650;display = block;position=absolute");

            return false;
        }
    </script>
    <%-----------------11------------------------------------------------------%>
    <%----------------12-------------------------------------------------------%>
    <div align="left">
        <ol class="breadcrumb">
            You are here &nbsp;!&nbsp; &nbsp; &nbsp;
            <li><i class="fa fa-dashboard"></i><a href="Home.aspx"></a></li>
            <li class=""><i class="fa fa-fw fa-edit">CAF</i> </li>
            <li class="active"><i class="fa fa-edit"></i><a href="#">APPLICATION FOR AUTO RENEWAL OF LICENCE (FORM-VII)</a>
            </li>
        </ol>
    </div>
    <div align="left">
        <div class="row" align="left">
            <div class="col-lg-11">
                <div class="panel panel-primary">
                    <div class="panel-heading" align="center">
                        <h3 class="panel-title">APPLICATION FOR AUTO RENEWAL OF LICENCE (FORM-VII)</h3>
                    </div>
                    <div class="panel-heading" align="center">
                        <h4 class="panel-title">[ Vide Rule 29(2) of A.P. Contract Labour (R&A) Rules , 1971 ]</h4>
                    </div>
                    <%-----------------12------------------------------------------------------%>
                    <div class="panel-body">
                        <table align="center" cellpadding="10" cellspacing="5" style="width: 90%">
                            <tr>
                                <td style="padding: 5px; margin: 5px" valign="top">
                                    <table cellpadding="4" cellspacing="5" style="width: 100%; text-align: left;">
                                        <tr>
                                            <td align="left" style="padding: 5px; margin: 5px" valign="top">
                                                <table cellpadding="4" cellspacing="5" style="width: 83%">
                                                    <tr>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">1.
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:Label ID="Label423" runat="server" CssClass="LBLBLACK" Width="210px">Existing Licence Number<font 
                                                            color="red">*</font></asp:Label>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">:
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                            <asp:TextBox ID="txtfactregno" runat="server" class="form-control txtbox" Height="28px"
                                                                MaxLength="100" TabIndex="1" ValidationGroup="group" Width="200px" OnTextChanged="txtfactregno_TextChanged" AutoPostBack="true"></asp:TextBox>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; width: 10px;">
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="txtfactregno"
                                                                ErrorMessage="Please enter  Factory Registation Number" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>

                                                    <tr>
                                                        <td colspan="4">
                                                            <table cellpadding="4" cellspacing="5" style="width: 90%" id="trvisibleregno" runat="server"
                                                                visible="false">
                                                                <tr>
                                                                    <td style="padding: 5px; margin: 5px; text-align: left;">2
                                                                    </td>
                                                                    <td style="padding: 5px; margin: 5px; text-align: left;">Existing registration validity date
                                                                    </td>
                                                                    <td style="padding: 5px; margin: 5px">&nbsp;
                                                                    </td>
                                                                    <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                                        <asp:TextBox ID="txtexistingregvaliditydate" runat="server" class="form-control txtbox" Height="28px"
                                                                            MaxLength="10" TabIndex="1" ValidationGroup="group" Width="180px"></asp:TextBox>
                                                                    </td>
                                                                    <td style="padding: 5px; margin: 5px; width: 10px;">&nbsp;
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="padding: 5px; margin: 5px; text-align: left;">3
                                                                    </td>
                                                                    <td style="padding: 5px; margin: 5px; text-align: left;">Nature of activity:
                                                                    </td>
                                                                    <td style="padding: 5px; margin: 5px">&nbsp;
                                                                    </td>
                                                                    <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                        <asp:TextBox ID="txtfactname" runat="server" class="form-control txtbox" Height="28px"
                                                                            MaxLength="1" TabIndex="1" ValidationGroup="group" Width="250px"></asp:TextBox>
                                                                    </td>
                                                                    <td style="padding: 5px; margin: 5px">&nbsp;
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="padding: 5px; margin: 5px; text-align: left;">4
                                                                    </td>
                                                                    <td style="padding: 5px; margin: 5px; text-align: left;">Name of Contractor/Firm 
                                                                    </td>
                                                                    <td style="padding: 5px; margin: 5px">&nbsp;
                                                                    </td>
                                                                    <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                        <asp:TextBox ID="txtfactaddress" runat="server" class="form-control txtbox" Height="28px"
                                                                            MaxLength="1" TabIndex="1" ValidationGroup="group"></asp:TextBox>
                                                                    </td>
                                                                    <td style="padding: 5px; margin: 5px">&nbsp;
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="padding: 5px; margin: 5px; text-align: left;">&nbsp;</td>
                                                                    <td style="padding: 5px; margin: 5px; text-align: left;" colspan="3">
                                                                        <span style="color: rgb(51, 51, 51); font-size: 14.3px; font-style: normal; font-variant-ligatures: normal; font-variant-caps: normal; font-weight: 700; letter-spacing: normal; orphans: 2; text-align: left; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-stroke-width: 0px; background-color: rgb(255, 255, 255); text-decoration-style: initial; text-decoration-color: initial; display: inline !important; float: none;">Present Details of Principal Employer<span>&nbsp;</span></span><font color="red" size="3" style="box-sizing: border-box; font-style: normal; font-variant-ligatures: normal; font-variant-caps: normal; font-weight: 700; letter-spacing: normal; orphans: 2; text-align: left; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-stroke-width: 0px; background-color: rgb(255, 255, 255); text-decoration-style: initial; text-decoration-color: initial;">*</font></td>
                                                                    <td style="padding: 5px; margin: 5px">&nbsp;</td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="padding: 5px; margin: 5px; text-align: left;">5.
                                                                    </td>
                                                                    <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                        <asp:Label ID="Label424" runat="server" CssClass="LBLBLACK" Width="165px">Name of the Principal Employer<font color="red">*</font></asp:Label>
                                                                    </td>
                                                                    <td style="padding: 5px; margin: 5px">:
                                                                    </td>
                                                                    <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                        <asp:TextBox ID="txtfactlicno" runat="server" class="form-control txtbox" Height="28px"
                                                                            MaxLength="1" TabIndex="1" ValidationGroup="group" Width="180px"></asp:TextBox>
                                                                    </td>
                                                                    <td style="padding: 5px; margin: 5px">
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="txtfactlicno"
                                                                            ErrorMessage="Please enter Factory License Number" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="padding: 5px; margin: 5px; text-align: left;">6.
                                                                    </td>
                                                                    <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                        <asp:Label ID="Label431" runat="server" CssClass="LBLBLACK" Width="165px">Door No<font 
                                                            color="red">*</font></asp:Label>
                                                                    </td>
                                                                    <td style="padding: 5px; margin: 5px">:
                                                                    </td>
                                                                    <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                                        <asp:TextBox ID="txtcircle" runat="server" class="form-control txtbox" Height="28px"
                                                                            MaxLength="10" TabIndex="1" ValidationGroup="group" Width="180px"></asp:TextBox>
                                                                    </td>
                                                                    <td style="padding: 5px; margin: 5px; width: 10px;">
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="txtcircle"
                                                                            ErrorMessage="Please enter Factory Circle" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="padding: 5px; margin: 5px; text-align: left;">7.
                                                                    </td>
                                                                    <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                        <asp:Label ID="Label432" runat="server" CssClass="LBLBLACK" Width="165px">Locality<font 
                                                            color="red">*</font></asp:Label>
                                                                    </td>
                                                                    <td style="padding: 5px; margin: 5px">:
                                                                    </td>
                                                                    <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                        <asp:TextBox ID="txtfacthorsepower" runat="server" class="form-control txtbox" Height="28px"
                                                                            MaxLength="10" onkeypress="return inputOnlyNumbers(event)" TabIndex="1" ValidationGroup="group"
                                                                            Width="180px"></asp:TextBox>
                                                                    </td>
                                                                    <td style="padding: 5px; margin: 5px">
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="txtfacthorsepower"
                                                                            ErrorMessage="Please enter Factory Horse Power" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="padding: 5px; margin: 5px; text-align: left;">8.
                                                                    </td>
                                                                    <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                        <asp:Label ID="Label31" runat="server" CssClass="LBLBLACK" Width="210px">District.<font 
                                                            color="red">*</font></asp:Label>
                                                                    </td>
                                                                    <td style="padding: 5px; margin: 5px">:
                                                                    </td>
                                                                    <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                        <asp:DropDownList ID="ddlShopDistrict" runat="server" AutoPostBack="True" class="form-control txtbox"
                                                                            Height="33px" Width="180px" OnSelectedIndexChanged="ddlShopDistrict_SelectedIndexChanged">
                                                                            <asp:ListItem>--District--</asp:ListItem>
                                                                        </asp:DropDownList>
                                                                    </td>
                                                                    <td style="padding: 5px; margin: 5px">
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="ddlShopDistrict"
                                                                            ErrorMessage="Please Select District of Shop/Establishment" InitialValue="--District--"
                                                                            ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="padding: 5px; margin: 5px; text-align: left;">9.
                                                                    </td>
                                                                    <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                        <asp:Label ID="Label2" runat="server" CssClass="LBLBLACK" Width="165px">Mandal<font 
                                                            color="red">*</font></asp:Label>
                                                                    </td>
                                                                    <td style="padding: 5px; margin: 5px">:
                                                                    </td>
                                                                    <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                        <asp:DropDownList ID="ddlShopMandal" runat="server" AutoPostBack="True" class="form-control txtbox"
                                                                            Height="33px" Width="180px" OnSelectedIndexChanged="ddlShopMandal_SelectedIndexChanged">
                                                                            <asp:ListItem>--Mandal--</asp:ListItem>
                                                                        </asp:DropDownList>
                                                                    </td>
                                                                    <td style="padding: 5px; margin: 5px">
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="ddlShopMandal"
                                                                            ErrorMessage="Please Select Mandal of Shop/Establishment" InitialValue="--Mandal--"
                                                                            ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="padding: 5px; margin: 5px; text-align: left;">10.
                                                                    </td>
                                                                    <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                        <asp:Label ID="Label3" runat="server" CssClass="LBLBLACK" Width="165px">Village<font 
                                                            color="red">*</font></asp:Label>
                                                                    </td>
                                                                    <td style="padding: 5px; margin: 5px">:
                                                                    </td>
                                                                    <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                        <asp:DropDownList ID="ddlShopVillage" runat="server" class="form-control txtbox"
                                                                            Height="33px" Width="180px">
                                                                            <asp:ListItem>--Village--</asp:ListItem>
                                                                        </asp:DropDownList>
                                                                    </td>
                                                                    <td style="padding: 5px; margin: 5px">
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="ddlShopVillage"
                                                                            ErrorMessage="Please Slect Village of Shop/Establishment (Village)" InitialValue="--Village--"
                                                                            ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="padding: 5px; margin: 5px; text-align: left;">11.
                                                                    </td>
                                                                    <td style="padding: 5px; margin: 5px; text-align: left;">Pincode
                                                                    </td>
                                                                    <td style="padding: 5px; margin: 5px">:
                                                                    </td>
                                                                    <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                        <asp:TextBox ID="txtpincode" runat="server" class="form-control txtbox" Height="28px"
                                                                            MaxLength="10" onkeypress="return inputOnlyNumbers(event)" TabIndex="1" ValidationGroup="group"
                                                                            Width="180px"></asp:TextBox>
                                                                    </td>
                                                                    <td style="padding: 5px; margin: 5px"></td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="padding: 5px; margin: 5px; text-align: left;">12.
                                                                    </td>
                                                                    <td style="padding: 5px; margin: 5px; text-align: left;">Total No. of Employees 
                                                                    </td>
                                                                    <td style="padding: 5px; margin: 5px">:
                                                                    </td>
                                                                    <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                        <asp:TextBox ID="txtempno" runat="server" class="form-control txtbox" Height="28px"
                                                                            MaxLength="10" onkeypress="return inputOnlyNumbers(event)" TabIndex="1" ValidationGroup="group"
                                                                            Width="180px"></asp:TextBox>
                                                                    </td>
                                                                    <td style="padding: 5px; margin: 5px"></td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left" style="padding: 5px; margin: 5px" valign="top">&nbsp;
                                            </td>
                                            <td style="width: 27px">&nbsp;
                                            </td>
                                            <td valign="top">&nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left" style="padding: 5px; margin: 5px" valign="top">&nbsp;
                                            </td>
                                            <td style="width: 27px">&nbsp;
                                            </td>
                                            <td valign="top">&nbsp;
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
                                            <td style="padding: 5px; margin: 5px">:<td style="padding: 5px; margin: 5px" valign="top">&nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px" align="center" class="style7">&nbsp;<tr>
                                                <td style="padding: 5px; margin: 5px; text-align: center;" align="center">&nbsp;
                                                </td>
                                            </tr>
                                                <caption>
                                                    &nbsp;</caption>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center" style="padding: 5px; margin: 5px; text-align: center;">
                                                <asp:Button ID="btnsave" runat="server" CssClass="btn btn-primary" Height="32px"
                                                    TabIndex="10" Text="Save" ValidationGroup="group" Width="90px" Visible="true"
                                                    OnClick="btnsave_Click" />
                                                &nbsp;&nbsp;<asp:Button ID="btnnext" runat="server" CausesValidation="False" CssClass="btn btn-danger"
                                                    Height="32px" TabIndex="10" Text="Next" Width="90px" OnClick="btnnext_Click" />
                                                &nbsp;<asp:Button ID="btnprevious" runat="server" CausesValidation="False" CssClass="btn btn-danger"
                                                    Height="32px" TabIndex="10" Text="Previous" Width="90px" OnClick="btnprevious_Click" />
                                                &nbsp;<asp:Button ID="BtnClear" runat="server" CausesValidation="False" CssClass="btn btn-warning"
                                                    Height="32px" OnClick="BtnClear_Click" TabIndex="10" Text="ClearAll" ToolTip="To Clear  the Screen"
                                                    Width="90px" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center" style="padding: 5px; margin: 5px">
                                                <div id="success" runat="server" visible="false" class="alert alert-success">
                                                    <a href="AddQualification.aspx" class="close" data-dismiss="alert" aria-label="close">×times;</a> <strong>Success!</strong><asp:Label ID="lblmsg" runat="server"></asp:Label>
                                                </div>
                                                <div id="Failure" runat="server" visible="false" class="alert alert-danger">
                                                    <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a> <strong>Warning!</strong>
                                                    <asp:Label ID="lblmsg0" runat="server"></asp:Label>
                                                </div>
                                            </td>
                                        </tr>
                                    </table>
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

