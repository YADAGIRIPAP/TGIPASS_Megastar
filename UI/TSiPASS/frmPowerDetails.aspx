<%@ Page Title=":: TS-iPASS ::  " Language="C#" MasterPageFile="~/UI/TSiPASS/CCMaster.master" AutoEventWireup="true" CodeFile="frmPowerDetails.aspx.cs" Inherits="TSTBDCReg1" %>

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

        .style7 {
            color: #FF3300;
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

        <script type="text/javascript">

            function onlyNumbers(chr) {
                return !(chr > 31 && (chr < 48 || chr > 57))
            }

    </script>

    <asp:UpdatePanel ID="upd1" runat="server">
        <ContentTemplate>
            <div align="left">
                <ol class="breadcrumb">
                    You are here
        &nbsp;!&nbsp; &nbsp; &nbsp; 
                            <li>
                                <i class="fa fa-dashboard"></i><a href="Home.aspx"></a>
                            </li>
                    <li class="">
                        <i class="fa fa-fw fa-edit">CAF</i>
                    </li>
                    <li class="active">
                        <i class="fa fa-edit"></i><a href="#">Power Details</a>
                    </li>
                </ol>
            </div>

            <div align="left">
                <div class="row" align="left">
                    <div class="col-lg-11">
                        <div class="panel panel-primary">
                            <div class="panel-heading" align="center">
                                <h3 class="panel-title">Power Details</h3>
                            </div>
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>
                                    <div class="panel-body">
                                        <table align="center" cellpadding="10" cellspacing="5" style="width: 90%">

                                            <tr>
                                                <td style="padding: 5px; margin: 5px" valign="top" colspan="3">
                                                    <asp:Label ID="Label422" runat="server" CssClass="LBLBLACK" Font-Bold="True"
                                                        Width="210px">Power<font 
                                                            color="red">*</font></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="padding: 5px; margin: 5px" valign="top">
                                                    <table cellpadding="4" cellspacing="5" style="width: 83%">
                                                         <tr>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">1</td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left; vertical-align:top">
                                                                <asp:Label ID="Label396" runat="server" CssClass="LBLBLACK" Width="200px">Connected Load in HP<font 
                                                            color="red">*</font></asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">:</td>
                                                              <td class="style6" style="padding: 5px; margin: 5px; text-align: left; vertical-align:top">
                                                                <asp:TextBox ID="txtConnectedLoadHP" runat="server" class="form-control txtbox" MinimumValue="1"
                                                                    Height="28px" MaxLength="40" onkeypress="return onlyNumbers(event.charCode || event.keyCode);" TabIndex="1"
                                                                    ValidationGroup="group"  Width="180px" AutoPostBack="True" OnTextChanged="txtConnectedLoadHP_TextChanged"></asp:TextBox>
                                                                     <asp:Label ID="lblChcekHP" runat="server"  Text="Label" Visible="false" ForeColor="Red"></asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; vertical-align:top">HP<asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server"
                                                                ControlToValidate="txtConnectedLoadHP"
                                                                ErrorMessage="Please Enter Connected Load in HP" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                               
                                                            </td>
                                                                                                                   <asp:HiddenField ID="hdnlineofactivity" runat="server" />

                                                            
                                                        </tr>
                                                        <tr runat="server" visible="false"> 
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">&nbsp;</td>
                                                            <td style="padding: 5px; margin: 5px; text-align: right;">&nbsp;</td>
                                                            <td style="padding: 5px; margin: 5px">&nbsp;</td>
                                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:TextBox ID="txtConnectedLoadKW" runat="server" class="form-control txtbox"
                                                                    Height="28px" MaxLength="40" onkeypress="NumberOnly()" TabIndex="1" Text="0"
                                                                    ValidationGroup="group" Width="180px" Enabled="False"></asp:TextBox>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">KW<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                                                                ControlToValidate="txtConnectedLoadKW"
                                                                ErrorMessage="Please Enter Connected Load in KW" ValidationGroup="group">*</asp:RequiredFieldValidator></td>
                                                        </tr>
                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">2</td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:Label ID="Label387" runat="server" CssClass="LBLBLACK" Width="210px">Contracted Maximum Demand in KVA <font 
                                                            color="red">*</font></asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">:</td>
                                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:TextBox ID="txtContractedMaximumDemandinKVA" runat="server" class="form-control txtbox"
                                                                    Height="28px" MaxLength="40" onkeypress="return inputOnlyNumbers(event)" TabIndex="1"
                                                                    ValidationGroup="group" Width="180px" Enabled="False"></asp:TextBox>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                                                                    ControlToValidate="txtContractedMaximumDemandinKVA"
                                                                    ErrorMessage="Please Enter Contracted Maximum Demand in KVA"
                                                                    ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                       
                                                        
                                                        <tr runat="server" visible="false">
                                                            <td style="padding: 5px; margin: 5px" valign="top">3</td>
                                                            <td style="width: 200px;">
                                                                <asp:Label ID="Label433" runat="server" CssClass="LBLBLACK" Width="165px">Aggregate Installed Capacity of the Transformer to be Installed by the Entreprenuer<font 
                                                            color="red">*</font></asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">:</td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                <asp:TextBox ID="txtAggregateInstalledCapacityoftheTransformertobeInstalledbytheEntreprenuer"
                                                                    runat="server" class="form-control txtbox" Text="0"
                                                                    Height="28px" MaxLength="40" onkeypress="return inputOnlyNumbers(event)" TabIndex="1"
                                                                    ValidationGroup="group" Width="180px"></asp:TextBox>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                               <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server"
                                                                    ControlToValidate="txtAggregateInstalledCapacityoftheTransformertobeInstalledbytheEntreprenuer"
                                                                    ErrorMessage="Please Enter Aggregate Installed Capacity of the Transformer to be Installed by the Entreprenuer"
                                                                    ValidationGroup="group" Visible="False">*</asp:RequiredFieldValidator>--%>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td style="width: 27px">
                                                    <asp:Label ID="Label348" runat="server" CssClass="LBLBLACK" Width="50px"></asp:Label>
                                                </td>
                                                <td valign="top">
                                                    <table cellpadding="4" cellspacing="5" style="width: 100%">

                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px" valign="top">3&nbsp;</td>
                                                            <td style="width: 200px;" valign="top">
                                                                <asp:Label ID="Label434" runat="server" CssClass="LBLBLACK" Width="165px">Required Voltage Level<font 
                                                            color="red">*</font></asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">:</td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                <asp:DropDownList ID="ddlRequiredVoltageLevel" runat="server" class="form-control txtbox" TabIndex="1"
                                                                    Height="33px" Width="180px">
                                                                    <asp:ListItem>--Select--</asp:ListItem>
                                                                    <asp:ListItem Value="33">33 KV</asp:ListItem>
                                                                    <asp:ListItem Value="11">11 KV</asp:ListItem>
                                                                    <asp:ListItem Value="133">133 KV</asp:ListItem>
                                                                    <asp:ListItem Value="100">LT</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server"
                                                                    ControlToValidate="ddlRequiredVoltageLevel"
                                                                    ErrorMessage="Please Select Required Voltage Level" InitialValue="--Select--"
                                                                    ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px" valign="top">4</td>
                                                            <td style="width: 200px;">
                                                                <asp:Label ID="Label435" runat="server" CssClass="LBLBLACK" Width="165px">Any Other Services Existing in the Same Premises<font 
                                                            color="red">*</font></asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">:</td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                <asp:DropDownList ID="ddlAnyOtherServicesExistingintheSamePremises"
                                                                    runat="server" class="form-control txtbox"
                                                                    Height="33px" Width="180px" AutoPostBack="True" TabIndex="1"
                                                                    OnSelectedIndexChanged="ddlAnyOtherServicesExistingintheSamePremises_SelectedIndexChanged">
                                                                    <asp:ListItem>--Select--</asp:ListItem>
                                                                    <asp:ListItem Value="n">No</asp:ListItem>
                                                                    <asp:ListItem Value="y">Yes</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server"
                                                                    ControlToValidate="ddlAnyOtherServicesExistingintheSamePremises"
                                                                    ErrorMessage="Please Select Any Other Services Existingin the Same Premises"
                                                                    InitialValue="--Select--" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                        <tr id="meter" runat="server" visible="false">
                                                            <td style="padding: 5px; margin: 5px" valign="top">&nbsp;</td>
                                                            <td style="width: 200px;">
                                                                <asp:Label ID="Label436" runat="server" CssClass="LBLBLACK" Width="165px">Service Number<font 
                                                            color="red">*</font></asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">:</td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                <asp:TextBox ID="txtContractedMaximumDemandinKVA0" runat="server"
                                                                    class="form-control txtbox" Height="28px" MaxLength="10"
                                                                    onkeypress="NumberOnly()" TabIndex="1" ValidationGroup="group"
                                                                    Width="180px"></asp:TextBox>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">&nbsp;</td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="padding: 5px; margin: 5px" valign="top" align="left">
                                                    <asp:Label ID="Label378" runat="server" CssClass="LBLBLACK" Width="280px"
                                                        Font-Bold="True">Proposed Maximum Working Hours</asp:Label>
                                                </td>
                                                <td style="width: 27px">&nbsp;</td>
                                                <td valign="top">&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td style="padding: 5px; margin: 5px" valign="top">
                                                    <table cellpadding="4" cellspacing="5" style="width: 83%">
                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">1</td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:Label ID="Label401" runat="server" CssClass="LBLBLACK" Width="200px">Per Day<font 
                                                            color="red">*</font></asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">:</td>
                                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                                <asp:TextBox ID="txtPerDay" runat="server" class="form-control txtbox"
                                                                    Height="28px" MaxLength="40" onkeypress="return inputOnlyNumbers(event)" TabIndex="1"
                                                                    ValidationGroup="group" Width="180px"></asp:TextBox>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server"
                                                                    ControlToValidate="txtPerDay"
                                                                    ErrorMessage="Please Enter Maximum Working hours per day"
                                                                    ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">2</td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:Label ID="Label402" runat="server" CssClass="LBLBLACK" Width="165px">Per Month<font 
                                                            color="red">*</font></asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">:</td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:TextBox ID="txtPerMonth" runat="server" class="form-control txtbox"
                                                                    Height="28px" MaxLength="40" onkeypress="return inputOnlyNumbers(event)" TabIndex="1"
                                                                    ValidationGroup="group" Width="180px"></asp:TextBox>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server"
                                                                    ControlToValidate="txtPerMonth"
                                                                    ErrorMessage="Please enter maximum working hours per month"
                                                                    ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td style="width: 27px">&nbsp;</td>
                                                <td valign="top">
                                                    <table cellpadding="4" cellspacing="5" style="width: 83%">
                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">3</td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                  <asp:Label ID="lblProductionMonth" runat="server" CssClass="LBLBLACK" Width="165px">Expected Month and Year of Trial Production(DD/MM/YYYY)<font 
                                                            color="red">*</font></asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">:</td>
                                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                                <asp:TextBox ID="txtExpectedMonthandYearofTrialProduction" runat="server" class="form-control txtbox"
                                                                    Height="28px" MaxLength="40" onkeypress="NumberOnly()" TabIndex="1"
                                                                    ValidationGroup="group" Width="180px"></asp:TextBox>
                                                               <%-- <cc1:CalendarExtender ID="CalendarExtender2" runat="server"
                                                                    OnClientDateSelectionChanged="dateSelectionChanged"
                                                                    TargetControlID="txtExpectedMonthandYearofTrialProduction" PopupButtonID="imgCalendar" Format="yyyy-MM-dd">
                                                                </cc1:CalendarExtender>--%>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server"
                                                                    ControlToValidate="txtExpectedMonthandYearofTrialProduction"
                                                                    ErrorMessage="Please enter Expected Month and Year of Trial Production"
                                                                    ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">4</td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:Label ID="Label417" runat="server" CssClass="LBLBLACK" Width="165px">Probable Date of Requirement of Power Supply(DD/MM/YYYY)<font 
                                                            color="red">*</font></asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">:</td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:TextBox ID="txtProbableDateofRequirementofPowerSupply" runat="server" class="form-control txtbox"
                                                                    Height="28px" MaxLength="40" TabIndex="1"
                                                                    ValidationGroup="group" Width="180px"></asp:TextBox>
                                                                <%--<cc1:CalendarExtender ID="CalendarExtender1" runat="server"
                                                                    OnClientDateSelectionChanged="dateSelectionChanged"
                                                                    TargetControlID="txtProbableDateofRequirementofPowerSupply" PopupButtonID="imgCalendar" Format="yyyy-MM-dd">
                                                                </cc1:CalendarExtender>--%>

                                                                <script type="text/javascript">
                                                                    function dateSelectionChanged(sender, args) {
                                                                        selectedDate = sender.get_selectedDate();
                                                                        /* replace this next line with your JS code to get the Sunday date */
                                                                        sundayDate = getSundayDateUsingYourAlgorithm(selectedDate);
                                                                        /* this sets the date on both the calendar and textbox */
                                                                        sender.set_SelectedDate(sundayDate);
                                                                    }
                                                                </script>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server"
                                                                    ControlToValidate="txtProbableDateofRequirementofPowerSupply"
                                                                    ErrorMessage="Please enter Probable Date of Requirement of Power Supply"
                                                                    ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="padding: 5px; margin: 5px" colspan="3" align="center" class="style7">&nbsp;<tr>
                                                    <td style="padding: 5px; margin: 5px" colspan="3" align="center">&nbsp;</td>
                                                </tr>
                                                    <caption>
                                                        &nbsp;</caption>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center" colspan="3"
                                                    style="padding: 5px; margin: 5px; text-align: center;">
                                                     <asp:Button ID="BtnClear" runat="server" CausesValidation="False"
                                                        CssClass="btn btn-warning" Height="32px" OnClick="BtnClear_Click" TabIndex="10"
                                                        Text="ClearAll" ToolTip="To Clear  the Screen" Width="90px"
                                                        ValidationGroup="group" />&nbsp;

                                                    <asp:Button ID="BtnSave1" runat="server" CssClass="btn btn-primary"
                                                        Height="32px" OnClick="BtnSave_Click" TabIndex="10" Text="Save"
                                                        ValidationGroup="ggg" Width="90px" CausesValidation="False" />
                                                     &nbsp;
                                            <asp:Button ID="btnNext0" runat="server"
                                                CssClass="btn btn-danger" Height="32px" OnClick="btnNext0_Click" TabIndex="10"
                                                Text="Previous" Width="90px" CausesValidation="False" />
                                                    &nbsp;&nbsp;<asp:Button ID="btnNext" runat="server"
                                                        CssClass="btn btn-danger" Height="32px" OnClick="btnNext_Click" TabIndex="10"
                                                        Text="Next" Width="90px" ValidationGroup="group" />
                                                   
                                                   
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center" colspan="3" style="padding: 5px; margin: 5px">


                                                    <div id="success" runat="server" visible="false" class="alert alert-success">
                                                        <a href="AddQualification.aspx" class="close" data-dismiss="alert" aria-label="close">&times;</a>
                                                        <strong>Success!</strong><asp:Label ID="lblmsg" runat="server"></asp:Label>
                                                    </div>


                                                    <div id="Failure" runat="server" visible="false" class="alert alert-danger">
                                                        <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a>
                                                        <strong>Warning!</strong>
                                                        <asp:Label ID="lblmsg0" runat="server"></asp:Label>
                                                    </div>
                                                </td>
                                            </tr>
                                        </table>
                                        <asp:HiddenField ID="hdfID" runat="server" />
                                        <asp:ValidationSummary ID="ValidationSummary1" runat="server"
                                            ShowMessageBox="True" ShowSummary="False" ValidationGroup="group" />
                                        <asp:ValidationSummary ID="ValidationSummary2" runat="server"
                                            ShowMessageBox="True" ShowSummary="False" ValidationGroup="child" />
                                        <asp:HiddenField ID="hdfFlagID" runat="server" />
                                        <asp:HiddenField ID="hdfFlagID0" runat="server" />
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
    <link href="../../css/ui-lightness/jquery-ui-1.8.19.custom.css" rel="stylesheet" />
    <script src="../../js/jquery-1.7.2.min.js"></script>
    <script src="../../js/jquery-ui-1.8.19.custom.min.js"></script>

    <link href="<%= ResolveUrl("css/ui-lightness/jquery-ui-1.8.19.custom.css") %>" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="<%= ResolveUrl("js/jquery-1.7.2.min.js") %>"></script>
    <script src="<%= ResolveUrl("js/jquery-ui-1.8.19.custom.min.js") %>" type="text/javascript"></script>
  
      <script type="text/javascript">
          function pageLoad() {
              var date = new Date();
              var currentMonth = date.getMonth();
              var currentDate = date.getDate();
              var currentYear = date.getFullYear();

              $("input[id$='txtExpectedMonthandYearofTrialProduction']").datepicker(
                 {
                     dateFormat: "dd/mm/yy",
                     // maxDate: new Date(currentYear, currentMonth, currentDate)
                 }); // Will run at every postback/AsyncPostback

              $("input[id$='txtProbableDateofRequirementofPowerSupply']").datepicker(
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
              $("input[id$='txtExpectedMonthandYearofTrialProduction']").datepicker(
                  {
                      //dateFormat: "dd/mm/yy",
                      dateFormat: "dd/mm/yy",
                     
                      //maxDate: new Date(currentYear, currentMonth, currentDate)
                  });
              $("input[id$='txtProbableDateofRequirementofPowerSupply']").datepicker(
                {
                    dateFormat: "dd/mm/yy",
                    //  maxDate: new Date(currentYear, currentMonth, currentDate)
                }); // Will run at every postback/AsyncPostback
          });
    </script>
    <style type="text/css">
        .ui-datepicker {
            font-size: 8pt !important;
            height: 250px;
            padding: 0.2em 0.2em 0;
            width: 250px;
        }
    </style>
</asp:Content>

