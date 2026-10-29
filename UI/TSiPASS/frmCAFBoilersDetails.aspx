<%@ Page Title=":: TS-iPASS ::  " Language="C#" MasterPageFile="~/UI/TSiPASS/CCMaster.master" AutoEventWireup="true" CodeFile="frmCAFBoilersDetails.aspx.cs" Inherits="TSTBDCReg1" %>

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

        .style12 {
        }

        .style13 {
            width: 13px;
        }
    </style>

    <script type="text/javascript" language="javascript">

        function OpenPopup() {

            window.open("Lookups/LookupBDC.aspx", "List", "scrollbars=yes,resizable=yes,width=1000,height=650;display = block;position=absolute");

            return false;
        }
    </script>
    <%--<script type="text/javascript">
    function showProgress() {
        var updateProgress = $get("<%= UpdateProgress.ClientID %>");
        updateProgress.style.display = "block";
    }
</script>
    --%>
    <%--  <asp:UpdatePanel ID="upd1" runat="server">
        <ContentTemplate>--%>
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
                <i class="fa fa-edit"></i><a href="#">Entrepreneur Details</a>
            </li>
        </ol>
    </div>

    <div align="left">
        <div class="row" align="left">
            <div class="col-lg-11">
                <div class="panel panel-primary">
                    <div class="panel-heading" align="center">
                        <h3 class="panel-title">Boilers Details</h3>
                    </div>
                    <%-- <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>--%>
                    <div class="panel-body">
                        <table align="center" cellpadding="10" cellspacing="5" style="width: 90%">

                            <tr>
                                <td style="padding: 5px; margin: 5px" valign="top" align="left">
                                    <asp:Label ID="Label461" runat="server" CssClass="LBLBLACK" Font-Bold="True"
                                        Width="450px">Please fill this part if Registration of Boilers is required</asp:Label>
                                </td>
                                <td style="width: 27px">&nbsp;</td>
                                <td valign="top">&nbsp;</td>
                            </tr>
                            <tr>
                                <td align="left" style="padding: 5px; margin: 5px" valign="top">
                                    <table cellpadding="4" cellspacing="5" style="width: 83%">

                                        <tr id="trName" runat="server" visible="false">
                                            <td style="padding: 5px; margin: 5px">1</td>
                                            <td class="style12" style="padding: 5px; margin: 5px">
                                                <asp:Label ID="Label440" runat="server" CssClass="LBLBLACK" Width="200px">Name of the Owner/Agent</asp:Label>
                                            </td>
                                            <td class="style13" style="padding: 5px; margin: 5px">:</td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:TextBox ID="txtNameOfOwner" runat="server" class="form-control txtbox"
                                                    Height="28px" MaxLength="40" TabIndex="1"
                                                    ValidationGroup="group" Width="180px"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                                                    ControlToValidate="txtNameOfOwner"
                                                    ErrorMessage="Please Enter Name of The Owner/Agent" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr id="trsituated" runat="server" visible="false">
                                            <td style="padding: 5px; margin: 5px">2&nbsp;</td>
                                            <td class="style12" style="padding: 5px; margin: 5px">
                                                <asp:Label ID="Label441" runat="server" CssClass="LBLBLACK" Width="200px">Where situated</asp:Label>
                                            </td>
                                            <td class="style13" style="padding: 5px; margin: 5px">:</td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:TextBox ID="txtWhereStudied" runat="server" class="form-control txtbox"
                                                    Height="28px" MaxLength="40" TabIndex="1"
                                                    ValidationGroup="group" Width="180px"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server"
                                                    ControlToValidate="txtWhereStudied" ErrorMessage="Please Enter Where Studied"
                                                    ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px">1</td>
                                            <td class="style12" style="padding: 5px; margin: 5px">
                                                <asp:Label ID="Label446" runat="server" CssClass="LBLBLACK" Width="200px">Maker&#39;s Name</asp:Label>
                                            </td>
                                            <td class="style13" style="padding: 5px; margin: 5px">:</td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:TextBox ID="txtMakersName" runat="server" class="form-control txtbox"
                                                    Height="28px" MaxLength="40" TabIndex="1"
                                                    ValidationGroup="group" Width="180px"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server"
                                                    ControlToValidate="txtMakersName" ErrorMessage="Please Enter Maker's Name"
                                                    ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px">2</td>
                                            <td class="style12" style="padding: 5px; margin: 5px">
                                                <asp:Label ID="Label447" runat="server" CssClass="LBLBLACK" Width="200px">Maker&#39;s Number</asp:Label>
                                            </td>
                                            <td class="style13" style="padding: 5px; margin: 5px">:</td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:TextBox ID="txtMakersNumber" runat="server" class="form-control txtbox"
                                                    Height="28px" MaxLength="40" TabIndex="1"
                                                    ValidationGroup="group" Width="180px"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server"
                                                    ControlToValidate="txtMakersNumber" ErrorMessage="Please Enter Maker's Number"
                                                    ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px">3</td>
                                            <td class="style12" style="padding: 5px; margin: 5px">
                                                <asp:Label ID="Label448" runat="server" CssClass="LBLBLACK" Width="200px">Type Of Boiler & Risk criteria</asp:Label>
                                            </td>
                                            <td class="style13" style="padding: 5px; margin: 5px">:</td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:DropDownList ID="ddlTypeofBoiler" runat="server" class="form-control txtbox"
                                                    Height="33px" Width="280px" TabIndex="1">
                                                    <asp:ListItem>--Select--</asp:ListItem>
                                                    <asp:ListItem Value="1">SIB Boiler - Low Risk</asp:ListItem>
                                                    <asp:ListItem Value="4">Lancashire and VCT Boiler - Medium Risk</asp:ListItem>
                                                    <asp:ListItem Value="2">Package Boiler - High Risk</asp:ListItem>
                                                    <asp:ListItem Value="3">Assembled Boiler - High Risk</asp:ListItem>
                                                    
                                                </asp:DropDownList>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server"
                                                    ControlToValidate="ddlTypeofBoiler" ErrorMessage="Please Select Type Of Boiler"
                                                    InitialValue="--Select--" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px">4</td>
                                            <td class="style12" style="padding: 5px; margin: 5px">
                                                <asp:Label ID="Label449" runat="server" CssClass="LBLBLACK" Width="200px">Boiler Used for</asp:Label>
                                            </td>
                                            <td class="style13" style="padding: 5px; margin: 5px">:</td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:DropDownList ID="ddlBoilersUsedfor" runat="server" class="form-control txtbox" Height="33px" TabIndex="1" Width="180px">
                                                    <asp:ListItem>--Select--</asp:ListItem>
                                                    <asp:ListItem Value="1">Process</asp:ListItem>
                                                    <asp:ListItem Value="2">Cogeneration</asp:ListItem>
                                                    <asp:ListItem Value="3">Power</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server"
                                                    ControlToValidate="ddlBoilersUsedfor"
                                                    ErrorMessage="Please Select Boiler Used For" InitialValue="--Select--"
                                                    ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px">5</td>
                                            <td class="style12" style="padding: 5px; margin: 5px">
                                                <asp:Label ID="Label450" runat="server" CssClass="LBLBLACK" Width="200px">Boiler Rating/Heating Surface</asp:Label>
                                            </td>
                                            <td class="style13" style="padding: 5px; margin: 5px">:</td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:TextBox ID="txtBoilerRatingSurface" runat="server" class="form-control txtbox"
                                                    Height="28px" MaxLength="40" TabIndex="1"
                                                    ValidationGroup="group" Width="180px"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">sqm<asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server"
                                                ControlToValidate="txtBoilerRatingSurface"
                                                ErrorMessage="Please Enter Boilers Rating/Heating Surface"
                                                ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px">6</td>
                                            <td class="style12" style="padding: 5px; margin: 5px">
                                                <asp:Label ID="Label451" runat="server" CssClass="LBLBLACK" Width="200px"
                                                    Font-Bold="True">Place &amp; Year of Manufature</asp:Label>
                                            </td>
                                            <td class="style13" style="padding: 5px; margin: 5px">:</td>
                                            <td style="padding: 5px; margin: 5px">&nbsp;</td>
                                            <td style="padding: 5px; margin: 5px">&nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px">&nbsp;</td>
                                            <td class="style12" style="padding: 5px; margin: 5px">
                                                <asp:Label ID="Label482" runat="server" CssClass="LBLBLACK" Width="200px">Place</asp:Label>
                                            </td>
                                            <td class="style13" style="padding: 5px; margin: 5px">:</td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:TextBox ID="txtPlace" runat="server" class="form-control txtbox"
                                                    Height="28px" MaxLength="40" TabIndex="1"
                                                    ValidationGroup="group" Width="180px"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server"
                                                    ControlToValidate="txtPlace" ErrorMessage="Please Enter Place of Manifacture"
                                                    ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px">&nbsp;</td>
                                            <td class="style12" style="padding: 5px; margin: 5px">
                                                <asp:Label ID="Label483" runat="server" CssClass="LBLBLACK" Width="200px">Year</asp:Label>
                                            </td>
                                            <td class="style13" style="padding: 5px; margin: 5px">:</td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:TextBox ID="txtYear" runat="server" class="form-control txtbox"
                                                    Height="28px" MaxLength="40" onkeypress="NumberOnly()" TabIndex="1"
                                                    ValidationGroup="group" Width="180px"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server"
                                                    ControlToValidate="txtYear" ErrorMessage="Please Enter Year Of Manufacture"
                                                    ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr id="trinspectiondate" runat="server" visible="false">
                                            <td style="padding: 5px; margin: 5px">3</td>
                                            <td class="style12" style="padding: 5px; margin: 5px">
                                                <asp:Label ID="Label442" runat="server" CssClass="LBLBLACK" Width="200px">Date of Inspection desirable(dd-mm-yyyy)</asp:Label>
                                            </td>
                                            <td class="style13" style="padding: 5px; margin: 5px">:</td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:TextBox ID="txtDateOfInspection" runat="server" class="form-control txtbox"
                                                    Height="28px" MaxLength="40" onkeypress="NumberOnly()" TabIndex="1"
                                                    ValidationGroup="group" Width="180px"></asp:TextBox>
                                                <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd-MM-yyyy" TargetControlID="txtDateOfInspection" PopupButtonID="txtDateOfInspection"></cc1:CalendarExtender>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server"
                                                    ControlToValidate="txtDateOfInspection"
                                                    ErrorMessage="Please Enter Date Of Inspection desirable"
                                                    ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr id="trBoilerage" runat="server" visible="false">
                                            <td style="padding: 5px; margin: 5px">3</td>
                                            <td class="style12" style="padding: 5px; margin: 5px">
                                                <asp:Label ID="Label445" runat="server" CssClass="LBLBLACK" Width="200px">Description of Boiler and Age</asp:Label>
                                            </td>
                                            <td class="style13" style="padding: 5px; margin: 5px">:</td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:TextBox ID="txtDescriptionofboilersAge" runat="server" class="form-control txtbox"
                                                    Height="28px" MaxLength="40" TabIndex="1"
                                                    ValidationGroup="group" Width="180px"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server"
                                                    ControlToValidate="txtDateOfInspection"
                                                    ErrorMessage="Please Enter Date Of Inspection desirable"
                                                    ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                                <td style="width: 27px">&nbsp;</td>
                                <td valign="top">
                                    <table cellpadding="4" cellspacing="5" style="width: 83%">
                                        <tr>
                                            <td style="padding: 5px; margin: 5px">7</td>
                                            <td class="style12" style="padding: 5px; margin: 5px">
                                                <asp:Label ID="Label500" runat="server" CssClass="LBLBLACK" Width="200px">Allowed Maximum Pressure</asp:Label>
                                            </td>
                                            <td class="style13" style="padding: 5px; margin: 5px">:</td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:TextBox ID="txtAllowedMaximumPresure" runat="server" class="form-control txtbox"
                                                    Height="28px" MaxLength="40" TabIndex="1"
                                                    ValidationGroup="group" Width="180px"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">Kg/Cm2<asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server"
                                                ControlToValidate="txtAllowedMaximumPresure"
                                                ErrorMessage="Please Enter Allowed Maximum Pressure" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>

                                        <tr>
                                            <td style="padding: 5px; margin: 5px">8</td>
                                            <td class="style12" style="padding: 5px; margin: 5px">
                                                <asp:Label ID="Label502" runat="server" CssClass="LBLBLACK" Width="200px">Maximum Continous Evaporation</asp:Label>
                                            </td>
                                            <td class="style13" style="padding: 5px; margin: 5px">:</td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:TextBox ID="txtMaximumContinousEvapration" runat="server" class="form-control txtbox"
                                                    Height="28px" MaxLength="40" TabIndex="1" onkeypress="NumberOnly()"
                                                    ValidationGroup="group" Width="180px"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server"
                                                    ControlToValidate="txtMaximumContinousEvapration"
                                                    ErrorMessage="Please Enter Maximum Continous Evo" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px">9</td>
                                            <td class="style12" style="padding: 5px; margin: 5px">
                                                <asp:Label ID="Label503" runat="server" CssClass="LBLBLACK" Font-Bold="True"
                                                    Width="200px">Details of Boiler Erector</asp:Label>
                                            </td>
                                            <td class="style13" style="padding: 5px; margin: 5px">&nbsp;</td>
                                            <td style="padding: 5px; margin: 5px">&nbsp;</td>
                                            <td style="padding: 5px; margin: 5px">&nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px">&nbsp;</td>
                                            <td class="style12" style="padding: 5px; margin: 5px">
                                                <asp:Label ID="Label2" runat="server" CssClass="LBLBLACK" Width="200px">Class of Erector</asp:Label>
                                            </td>
                                            <td class="style13" style="padding: 5px; margin: 5px">:</td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:DropDownList ID="ddlerectorclass" runat="server" class="form-control txtbox"
                                                    Height="33px" Width="180px" TabIndex="1">
                                                    <asp:ListItem>--Select--</asp:ListItem>
                                                    <asp:ListItem Value="1">SPECIAL CLASS</asp:ListItem>
                                                    <asp:ListItem Value="2">CLASS I</asp:ListItem>
                                                    <asp:ListItem Value="3">CLASS II</asp:ListItem>
                                                    <asp:ListItem Value="4">CLASS III</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                                                    ControlToValidate="ddlerectorclass" ErrorMessage="Please Select Class of Erector"
                                                    InitialValue="--Select--" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px">&nbsp;</td>
                                            <td class="style12" style="padding: 5px; margin: 5px">
                                                <asp:Label ID="Label505" runat="server" CssClass="LBLBLACK" Width="200px">Name of Erector</asp:Label>
                                            </td>
                                            <td class="style13" style="padding: 5px; margin: 5px">:</td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:TextBox ID="txtNameOfErector" runat="server" class="form-control txtbox"
                                                    Height="28px" MaxLength="200" TabIndex="1"
                                                    ValidationGroup="group" Width="180px"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator17" runat="server"
                                                    ControlToValidate="txtNameOfErector"
                                                    ErrorMessage="Please Enter Name of Erector" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px">&nbsp;</td>
                                            <td class="style12" style="padding: 5px; margin: 5px">
                                                <asp:Label ID="Label506" runat="server" CssClass="LBLBLACK" Width="200px">State</asp:Label>
                                            </td>
                                            <td class="style13" style="padding: 5px; margin: 5px">:</td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:DropDownList ID="ddlState" runat="server" class="form-control txtbox"
                                                    Height="33px" OnSelectedIndexChanged="ddlstatus28_SelectedIndexChanged"
                                                    Width="180px" TabIndex="1">
                                                    <asp:ListItem>--Select--</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator18" runat="server"
                                                    ControlToValidate="ddlState" ErrorMessage="Please Select District"
                                                    InitialValue="--Select--" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>

                                        <tr id="trsteampipeline" runat="server" visible="false">
                                            <td style="padding: 5px; margin: 5px">12</td>
                                            <td class="style12" style="padding: 5px; margin: 5px">
                                                <asp:Label ID="Label508" runat="server" CssClass="LBLBLACK" Width="200px">Total Length of Steam PipeLine</asp:Label>
                                            </td>
                                            <td class="style13" style="padding: 5px; margin: 5px">&nbsp;</td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:TextBox ID="txtTotalLengthOfStreamPipeLine" runat="server" class="form-control txtbox"
                                                    Height="28px" MaxLength="40" onkeypress="NumberOnly()" TabIndex="1"
                                                    ValidationGroup="group" Width="180px"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator20" runat="server"
                                                    ControlToValidate="txtTotalLengthOfStreamPipeLine"
                                                    ErrorMessage="Please Enter Total Length Of Stream PipeLine"
                                                    ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px">10</td>
                                            <td class="style12" style="padding: 5px; margin: 5px">Inspector Authority Type</td>
                                            <td class="style13" style="padding: 5px; margin: 5px">&nbsp;</td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:DropDownList ID="ddlinspector" runat="server" AutoPostBack="True" class="form-control txtbox" Height="33px" OnSelectedIndexChanged="ddlinspector_SelectedIndexChanged" TabIndex="1" Width="180px">
                                                    <asp:ListItem>--Select--</asp:ListItem>
                                                    <asp:ListItem Value="1">State Boiler Department</asp:ListItem>
                                                    <asp:ListItem Value="2">Third Party Certificate</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator21" runat="server" ControlToValidate="txtTotalLengthOfStreamPipeLine" ErrorMessage="Please Enter Total Length Of Stream PipeLine" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr runat="server" id="trthirdpraty" visible="false">
                                            <td style="padding: 5px; margin: 5px">19</td>
                                            <td class="style12" style="padding: 5px; margin: 5px">Component Person Details</td>
                                            <td class="style13" style="padding: 5px; margin: 5px">&nbsp;</td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:TextBox ID="txtcomponentperson" runat="server" class="form-control txtbox" Height="28px" MaxLength="40" TabIndex="1" ValidationGroup="group" Width="180px"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">&nbsp;</td>
                                        </tr>
                                        <tr id="trregno" runat="server" visible="false">
                                            <td style="padding: 5px; margin: 5px">1</td>
                                            <td class="style12" style="padding: 5px; margin: 5px">
                                                <asp:Label ID="Label429" runat="server" CssClass="LBLBLACK" Width="200px">Registration Number of the Boiler</asp:Label>
                                            </td>
                                            <td class="style13" style="padding: 5px; margin: 5px">:</td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:TextBox ID="txtRegistrationNumber" runat="server" class="form-control txtbox"
                                                    Height="28px" MaxLength="30" TabIndex="1"
                                                    ValidationGroup="group" Width="180px"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                                                    ControlToValidate="txtRegistrationNumber"
                                                    ErrorMessage="Please Enter Registration Number of Boiler"
                                                    ValidationGroup="group">*</asp:RequiredFieldValidator>--%>
                                            </td>
                                        </tr>
                                        <tr id="trEconomiser" runat="server" visible="false">
                                            <td style="padding: 5px; margin: 5px">13</td>
                                            <td class="style12" style="padding: 5px; margin: 5px">
                                                <asp:Label ID="Label501" runat="server" CssClass="LBLBLACK" Width="200px">Economiser Maker&#39;s Number</asp:Label>
                                            </td>
                                            <td class="style13" style="padding: 5px; margin: 5px">:</td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:TextBox ID="txtEconomiserMarker" runat="server" class="form-control txtbox"
                                                    Height="28px" MaxLength="40" onkeypress="NumberOnly()" TabIndex="1"
                                                    ValidationGroup="group" Width="180px"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server"
                                                    ControlToValidate="txtEconomiserMarker"
                                                    ErrorMessage="Please Enter Economiser Markers Number" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr id="trEconomiserPressure" runat="server" visible="false">
                                            <td style="padding: 5px; margin: 5px">16</td>
                                            <td class="style12" style="padding: 5px; margin: 5px">
                                                <asp:Label ID="Label507" runat="server" CssClass="LBLBLACK" Width="200px">Maximum Pressure of Economiser</asp:Label>
                                            </td>
                                            <td class="style13" style="padding: 5px; margin: 5px">&nbsp;</td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:TextBox ID="txtMaximumPresureofEconomiser" runat="server" class="form-control txtbox"
                                                    Height="28px" MaxLength="40" onkeypress="NumberOnly()" TabIndex="1"
                                                    ValidationGroup="group" Width="180px"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator19" runat="server"
                                                    ControlToValidate="txtMaximumPresureofEconomiser"
                                                    ErrorMessage="Please Enter Maximum Presure of Economiser"
                                                    ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr id="trerectorclass" runat="server" visible="false">
                                            <td style="padding: 5px; margin: 5px">&nbsp;</td>
                                            <td class="style12" style="padding: 5px; margin: 5px">
                                                <asp:Label ID="Label504" runat="server" CssClass="LBLBLACK" Width="200px">Class of Erector</asp:Label>
                                            </td>
                                            <td class="style13" style="padding: 5px; margin: 5px">:</td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:TextBox ID="txtClassofErector" runat="server" class="form-control txtbox"
                                                    Height="28px" MaxLength="40" TabIndex="1" onkeypress="NumberOnly()"
                                                    ValidationGroup="group" Width="180px"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server"
                                                    ControlToValidate="txtClassofErector"
                                                    ErrorMessage="Please Enter Class of Erector" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td style="padding: 5px; margin: 5px" colspan="3" align="center">
                                    <tr>
                                        <td style="padding: 5px; margin: 5px" colspan="3" align="center">&nbsp;</td>
                                    </tr>
                                    <caption>
                                        &nbsp;</caption>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="3">
                                    <table style="width: 50%">
                                        <tr runat="server" id="trerector" visible="true">
                                            <td style="padding: 5px; margin: 5px; text-align: left;">1</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label387" runat="server" CssClass="LBLBLACK" Width="210px">Upload Erector License Copy<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:FileUpload ID="FileUploadErector" runat="server" class="form-control txtbox"
                                                    Height="28px" />

                                                <asp:HyperLink ID="lblFileNameErector" runat="server" CssClass="LBLBLACK" Width="165px"
                                                    Target="_blank">[lblFileNameErector]</asp:HyperLink>
                                                <br />
                                                <asp:Label ID="LabelErector" runat="server" Visible="False"></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                <asp:Button ID="BtnErector" runat="server" CssClass="btn btn-xs btn-warning"
                                                    Height="28px" TabIndex="10" Text="Upload"
                                                    Width="72px" OnClick="BtnErector_Click" />
                                            </td>
                                        </tr>
                                        <tr runat="server" id="trreqdoc" visible="true">
                                            <td style="padding: 5px; margin: 5px; text-align: left;">2</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label7" runat="server" CssClass="LBLBLACK" Width="210px">Required Documents(Form II/XVII/Release Note)<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:FileUpload ID="FileUploadRequiredDoc" runat="server" class="form-control txtbox"
                                                    Height="28px" />

                                                <asp:HyperLink ID="HyperLinkRequiredDoc" runat="server" CssClass="LBLBLACK" Width="165px"
                                                    Target="_blank">[lblFileNameRequiredDoc]</asp:HyperLink>
                                                <br />
                                                <asp:Label ID="LabelRequiredDoc" runat="server" Visible="False"></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                <asp:Button ID="btnreqdoc" runat="server" CssClass="btn btn-xs btn-warning"
                                                    Height="28px" TabIndex="10" Text="Upload"
                                                    Width="72px" OnClick="btnreqdoc_Click" />
                                            </td>
                                        </tr>
                                        <tr runat="server" id="trotherdoc" visible="true">
                                            <td style="padding: 5px; margin: 5px; text-align: left;">3</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label9" runat="server" CssClass="LBLBLACK" Width="210px">Upload Any Other Document<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:FileUpload ID="FileUploadOtherDoc" runat="server" class="form-control txtbox"
                                                    Height="28px" />

                                                <asp:HyperLink ID="HyperLinkOtherDoc" runat="server" CssClass="LBLBLACK" Width="165px"
                                                    Target="_blank">[lblFileNameOtherDoc]</asp:HyperLink>
                                                <br />
                                                <asp:Label ID="LabelOtherDoc" runat="server" Visible="False"></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                <asp:Button ID="btnanyotherdoc" runat="server" CssClass="btn btn-xs btn-warning"
                                                    Height="28px" TabIndex="10" Text="Upload"
                                                    Width="72px" OnClick="btnanyotherdoc_Click" />
                                            </td>
                                        </tr>
                                        <tr runat="server" id="trformvi" visible="false">
                                            <td style="padding: 5px; margin: 5px; text-align: left;">4</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label1" runat="server" CssClass="LBLBLACK" Width="210px">Upload Form VI<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:FileUpload ID="FileUploadFormVI" runat="server" class="form-control txtbox"
                                                    Height="28px" />

                                                <asp:HyperLink ID="HyperLinkFormVI" runat="server" CssClass="LBLBLACK" Width="165px"
                                                    Target="_blank">[lblFileNameFormVI]</asp:HyperLink>
                                                <br />
                                                <asp:Label ID="LabelFormVI" runat="server" Visible="False"></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                <asp:Button ID="btnformvi" runat="server" CssClass="btn btn-xs btn-warning"
                                                    Height="28px" TabIndex="10" Text="Upload"
                                                    Width="72px" OnClick="btnformvi_Click" />
                                            </td>
                                        </tr>
                                        <tr runat="server" id="trformv" visible="false">
                                            <td style="padding: 5px; margin: 5px; text-align: left;">5</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label3" runat="server" CssClass="LBLBLACK" Width="210px">Upload Form V<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:FileUpload ID="FileUploadFormV" runat="server" class="form-control txtbox"
                                                    Height="28px" />

                                                <asp:HyperLink ID="HyperLinkFormV" runat="server" CssClass="LBLBLACK" Width="165px"
                                                    Target="_blank">[lblFileNameFormV]</asp:HyperLink>
                                                <br />
                                                <asp:Label ID="LabelFormV" runat="server" Visible="False"></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                <asp:Button ID="btnformv" runat="server" CssClass="btn btn-xs btn-warning"
                                                    Height="28px" TabIndex="10" Text="Upload"
                                                    Width="72px" OnClick="btnformv_Click" />
                                            </td>
                                        </tr>
                                        <tr runat="server" id="trdrawing" visible="false">
                                            <td style="padding: 5px; margin: 5px; text-align: left;">6</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label5" runat="server" CssClass="LBLBLACK" Width="210px">Upload Drawing Design<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:FileUpload ID="FileUploadDrawing" runat="server" class="form-control txtbox"
                                                    Height="28px" />

                                                <asp:HyperLink ID="HyperLinkDrawing" runat="server" CssClass="LBLBLACK" Width="165px"
                                                    Target="_blank">[lblFileNameDrawing]</asp:HyperLink>
                                                <br />
                                                <asp:Label ID="LabelDrawing" runat="server" Visible="False"></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                <asp:Button ID="btndrawing" runat="server" CssClass="btn btn-xs btn-warning"
                                                    Height="28px" TabIndex="10" Text="Upload"
                                                    Width="72px" OnClick="btndrawing_Click" />
                                            </td>
                                        </tr>
                                        <tr runat="server" id="trcbb" visible="false">
                                            <td style="padding: 5px; margin: 5px; text-align: left;">7</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label11" runat="server" CssClass="LBLBLACK" Width="210px">Upload CBB authority certification letter<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:FileUpload ID="FileUploadCBB" runat="server" class="form-control txtbox"
                                                    Height="28px" />

                                                <asp:HyperLink ID="HyperLinkCBB" runat="server" CssClass="LBLBLACK" Width="165px"
                                                    Target="_blank">[lblFileNameCBB]</asp:HyperLink>
                                                <br />
                                                <asp:Label ID="LabelCBB" runat="server" Visible="False"></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                <asp:Button ID="btnuploadcbb" runat="server" CssClass="btn btn-xs btn-warning"
                                                    Height="28px" TabIndex="10" Text="Upload"
                                                    Width="72px" OnClick="btnuploadcbb_Click" />
                                            </td>
                                        </tr>
                                        <tr runat="server" id="trAnnexure" visible="false">
                                            <td style="padding: 5px; margin: 5px; text-align: left;">8</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label13" runat="server" CssClass="LBLBLACK" Width="210px">Upload Anexure<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:FileUpload ID="FileUploadAnexure" runat="server" class="form-control txtbox"
                                                    Height="28px" />

                                                <asp:HyperLink ID="HyperLinkAnexure" runat="server" CssClass="LBLBLACK" Width="165px"
                                                    Target="_blank">[lblFileNameAnexure]</asp:HyperLink>
                                                <br />
                                                <asp:Label ID="LabelAnexure" runat="server" Visible="False"></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                <asp:Button ID="Btnanexure" runat="server" CssClass="btn btn-xs btn-warning"
                                                    Height="28px" TabIndex="10" Text="Upload"
                                                    Width="72px" OnClick="Btnanexure_Click" />
                                            </td>
                                        </tr>
                                    </table>
                                </td>

                            </tr>
                            <tr>
                                <td align="center" colspan="3"
                                    style="padding: 5px; margin: 5px; text-align: center;">
                                    <asp:Button ID="BtnSave1" runat="server" CssClass="btn btn-primary"
                                        Height="32px" OnClick="BtnSave_Click" TabIndex="10" Text="Save"
                                        ValidationGroup="group" Width="90px" />
                                    &nbsp;&nbsp;<asp:Button ID="BtnDelete" runat="server"
                                        CssClass="btn btn-danger" Height="32px" OnClick="BtnClear0_Click" TabIndex="10"
                                        Text="Next" Width="90px"
                                        ValidationGroup="group" />
                                    &nbsp;<asp:Button ID="BtnDelete0" runat="server" CausesValidation="False"
                                        CssClass="btn btn-danger" Height="32px" OnClick="BtnDelete0_Click"
                                        TabIndex="10" Text="Previous" Width="90px" />
                                    &nbsp;&nbsp;<asp:Button ID="BtnClear" runat="server" CausesValidation="False"
                                        CssClass="btn btn-warning" Height="32px" OnClick="BtnClear_Click" TabIndex="10"
                                        Text="ClearAll" ToolTip="To Clear  the Screen" Width="90px" />
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
                    </div>
                    <%--</ContentTemplate>
                    </asp:UpdatePanel>--%>
                </div>
            </div>
        </div>

    </div>
    <%-- <asp:UpdateProgress ID="UpdateProgress" runat="server" AssociatedUpdatePanelID="updatepanel1">
        <ProgressTemplate>
        </ProgressTemplate>
    </asp:UpdateProgress>--%>

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

