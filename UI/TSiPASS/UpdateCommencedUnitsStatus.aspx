<%@ Page Title="" Language="C#" MasterPageFile="~/UI/TSiPASS/CCMaster.master" AutoEventWireup="true" CodeFile="UpdateCommencedUnitsStatus.aspx.cs" Inherits="UI_TSiPASS_UpdateCommencedUnitsStatus" %>

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
        $(function () {

            $('#MstLftMenu').remove();

        });
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
                                <h3 class="panel-title">Commenced Unit Update Status</h3>
                            </div>
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>
                                    <div class="panel-body">
                                        <table align="center" cellpadding="10" cellspacing="5" style="width: 90%">
                                            <tr>
                                                <%--<td style="padding: 5px; margin: 5px" valign="top" align="left">&nbsp;</td>--%>
                                                <td style="padding: 5px; margin: 5px; text-align: left;" valign="top" colspan="5"><b>Please enter the below details</b>
                                                </td>
                                                <td valign="top">
                                                <asp:HyperLink CssClass="btn btn-link" ID="HyperLink1" runat="server" NavigateUrl="~/UI/TSiPASS/CommencedUnitsStatus.aspx" Text="<< Back"> </asp:HyperLink>
                                                </td>
                                            </tr>
                                            <tr>

                                                <td style="padding: 5px; margin: 5px; text-align: left; width: 30px">1
                                                </td>
                                                <td style="padding: 5px; margin: 5px; text-align: left; width: 350px">
                                                    <asp:Label ID="Label7" runat="server" CssClass="LBLBLACK">Unit Name<font 
                                                            color="red"> *</font></asp:Label>
                                                </td>
                                                <td style="padding: 5px; margin: 5px; width: 35px">:
                                                </td>
                                                <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                    <asp:Label ID="lblUnitName" runat="server" CssClass="LBLBLACK"><font 
                                                            color="red"> </font></asp:Label>
                                                </td>
                                                <td style="padding: 5px; margin: 5px; width: 10px;"></td>
                                            </tr>
                                            <tr>

                                                <td style="padding: 5px; margin: 5px; text-align: left; width: 30px">2&nbsp;</td>
                                                <td style="padding: 5px; margin: 5px; text-align: left; width: 350px">
                                                    <asp:Label ID="Label8" runat="server" CssClass="LBLBLACK">UID no<font 
                                                            color="red"> *</font></asp:Label>
                                                </td>
                                                <td style="padding: 5px; margin: 5px; width: 35px">:
                                                </td>
                                                <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                    <asp:Label ID="lblUIDNo" runat="server" CssClass="LBLBLACK"><font 
                                                            color="red"> </font></asp:Label>
                                                </td>
                                                <td style="padding: 5px; margin: 5px; width: 10px;">
                                                   
                                                </td>
                                            </tr>
                                            <tr>

                                                <td style="padding: 5px; margin: 5px; text-align: left; width: 30px">3</td>
                                                <td style="padding: 5px; margin: 5px; text-align: left; width: 350px">
                                                    <asp:Label ID="Label401" runat="server" CssClass="LBLBLACK">Is unit running properly<font 
                                                            color="red"> *</font></asp:Label>
                                                </td>
                                                <td style="padding: 5px; margin: 5px; width: 35px">:
                                                </td>
                                                <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                    <asp:RadioButtonList runat="server" ID="rblRunning" RepeatDirection="Horizontal">
                                                        <asp:ListItem Text="Yes" Value="Yes"></asp:ListItem>
                                                        <asp:ListItem Text="No" Value="No"></asp:ListItem>
                                                    </asp:RadioButtonList>
                                                </td>
                                                <td style="padding: 5px; margin: 5px; width: 10px;">
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="rblRunning"
                                                        ErrorMessage="Please Select Yes or No" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">4</td>
                                                <td style="padding: 5px; margin: 5px; text-align: left;">
                                                    <asp:Label ID="Label402" runat="server" CssClass="LBLBLACK">Is Raw-Material available<font 
                                                            color="red"> *</font></asp:Label>
                                                </td>
                                                <td style="padding: 5px; margin: 5px">:
                                                </td>
                                                <td style="padding: 5px; margin: 5px; text-align: left;">
                                                    <asp:RadioButtonList runat="server" ID="rblRawMaterial" RepeatDirection="Horizontal">
                                                        <asp:ListItem Text="Yes" Value="Yes"></asp:ListItem>
                                                        <asp:ListItem Text="No" Value="No"></asp:ListItem>
                                                    </asp:RadioButtonList>
                                                </td>
                                                <td style="padding: 5px; margin: 5px">
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="rblRawMaterial"
                                                        ErrorMessage="Please Select Yes or No" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                </td>
                                            </tr>

                                            <tr>
                                                <td style="padding: 5px; margin: 5px; text-align: left;">5</td>
                                                <td style="padding: 5px; margin: 5px; text-align: left;">
                                                    <asp:Label ID="Label424" runat="server" CssClass="LBLBLACK" Width="200px">Financial Status <font 
                                                            color="red"> *</font></asp:Label>
                                                </td>
                                                <td style="padding: 5px; margin: 5px">:
                                                </td>
                                                <td style="padding: 5px; margin: 5px; text-align: left;">
                                                    <asp:RadioButtonList runat="server" ID="rblFinStatus" RepeatDirection="Horizontal">
                                                        <asp:ListItem Text="Profit" Value="Profit"></asp:ListItem>
                                                        <asp:ListItem Text="Loss" Value="Loss"></asp:ListItem>
                                                    </asp:RadioButtonList>
                                                </td>
                                                <td style="padding: 5px; margin: 5px">
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="rblFinStatus"
                                                        ErrorMessage="Please select Profit or loss" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="padding: 5px; margin: 5px; text-align: left;">6
                                                </td>
                                                <td style="padding: 5px; margin: 5px; text-align: left;">
                                                    <asp:Label ID="Label1" runat="server" CssClass="LBLBLACK" Width="200px">Marketing <font 
                                                            color="red"> *</font></asp:Label>
                                                </td>
                                                <td style="padding: 5px; margin: 5px">:
                                                </td>
                                                <td style="padding: 5px; margin: 5px; text-align: left;">
                                                    <asp:RadioButtonList runat="server" ID="rblMarketing" RepeatDirection="Horizontal" Width="300px">
                                                        <asp:ListItem Text="Domestic" Value="Domestic"></asp:ListItem>
                                                        <asp:ListItem Text="OutSide" Value="OutSide"></asp:ListItem>
                                                        <asp:ListItem Text="Export" Value="Export"></asp:ListItem>

                                                    </asp:RadioButtonList>
                                                </td>
                                                <td style="padding: 5px; margin: 5px">
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="rblMarketing"
                                                        ErrorMessage="Please select Marketing type" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="padding: 5px; margin: 5px; text-align: left;" valign="Center">7
                                                </td>
                                                <td style="padding: 5px; margin: 5px; text-align: left;">
                                                    <asp:Label ID="Label2" runat="server" CssClass="LBLBLACK" Width="350px">Above Information Confirmed with - Unit Person Name<font 
                                                            color="red"> *</font></asp:Label>
                                                </td>
                                                <td style="padding: 5px; margin: 5px">:
                                                </td>
                                                <td style="padding: 5px; margin: 5px; text-align: left;">
                                                    <asp:TextBox ID="txtPersonName" runat="server" class="form-control txtbox"
                                                        Height="28px" MaxLength="40" TabIndex="1" ValidationGroup="group" Width="180px"></asp:TextBox>
                                                </td>
                                                <td style="padding: 5px; margin: 5px">
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtPersonName"
                                                        ErrorMessage="Please Enter Person Name" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="padding: 5px; margin: 5px; text-align: left;" valign="Center"></td>
                                                <td style="padding: 5px; margin: 5px; text-align: left;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="Label3" runat="server" CssClass="LBLBLACK"> Unit Person Designation<font 
                                                            color="red"> *</font></asp:Label>
                                                </td>
                                                <td style="padding: 5px; margin: 5px">:
                                                </td>
                                                <td style="padding: 5px; margin: 5px; text-align: left;">
                                                    <asp:TextBox ID="txtPersonDesgn" runat="server" class="form-control txtbox"
                                                        Height="28px" MaxLength="40" TabIndex="1" ValidationGroup="group" Width="180px"></asp:TextBox>
                                                </td>
                                                <td style="padding: 5px; margin: 5px">
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtPersonDesgn"
                                                        ErrorMessage="Please Enter Designation" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="padding: 5px; margin: 5px; text-align: left;" valign="Center"></td>
                                                <td style="padding: 5px; margin: 5px; text-align: left;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                    <asp:Label ID="Label4" runat="server" CssClass="LBLBLACK">Unit Person Mobile no.<font 
                                                            color="red"> *</font></asp:Label>
                                                </td>
                                                <td style="padding: 5px; margin: 5px">:
                                                </td>
                                                <td style="padding: 5px; margin: 5px; text-align: left;">
                                                    <asp:TextBox ID="txtPersonMobile" runat="server" class="form-control txtbox"
                                                        Height="28px" MaxLength="10" onkeypress="return inputOnlyNumbers(event)" TabIndex="1" ValidationGroup="group" Width="180px"></asp:TextBox>
                                                </td>
                                                <td style="padding: 5px; margin: 5px">
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtPersonMobile"
                                                        ErrorMessage="Please Enter Mobile Number" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="padding: 5px; margin: 5px; text-align: left;" valign="Center">8
                                                </td>
                                                <td style="padding: 5px; margin: 5px; text-align: left;">
                                                    <asp:Label ID="Label5" runat="server" CssClass="LBLBLACK">Is Unit facing any issue?<font 
                                                            color="red"> </font></asp:Label>
                                                </td>
                                                <td style="padding: 5px; margin: 5px">:
                                                </td>
                                                <td style="padding: 5px; margin: 5px; text-align: left;">
                                                    <asp:TextBox ID="txtanyIssue" runat="server" class="form-control txtbox"
                                                        Height="28px" MaxLength="40" TabIndex="1" ValidationGroup="group" Width="180px"></asp:TextBox>
                                                </td>
                                                <td style="padding: 5px; margin: 5px"></td>
                                            </tr>
                                            <tr>
                                                <td style="padding: 5px; margin: 5px; text-align: left;" valign="Center">9</td>
                                                <td style="padding: 5px; margin: 5px; text-align: left;">
                                                    <asp:Label ID="Label6" runat="server" CssClass="LBLBLACK">GM Remrks <font 
                                                            color="red"> *</font></asp:Label>
                                                </td>
                                                <td style="padding: 5px; margin: 5px">:
                                                </td>
                                                <td style="padding: 5px; margin: 5px; text-align: left;">
                                                    <asp:TextBox ID="txtGMremarks" runat="server" class="form-control txtbox"
                                                        Height="28px" MaxLength="40" TabIndex="1" ValidationGroup="group" Width="180px"></asp:TextBox>
                                                </td>
                                                <td style="padding: 5px; margin: 5px">
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtGMremarks"
                                                        ErrorMessage="Please Enter remarks" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                        </table>
                                        <table align="center" cellpadding="10" cellspacing="5" style="width: 90%">


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

                                                    <asp:Button ID="btnUpdate" runat="server" CausesValidation="False" CssClass="btn btn-primary"
                                                        Height="32px" TabIndex="10" Text="Update" ValidationGroup="group" Width="90px" OnClick="btnUpdate_Click" />



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
    </asp:UpdatePanel>
    <%--</div>
       </td>
        </tr>
    </table>--%>
</asp:Content>

