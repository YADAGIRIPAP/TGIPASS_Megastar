<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/UI/TSiPASS/CCMaster.master" CodeFile="frmlanddetails_buildnow.aspx.cs" Inherits="UI_TSiPASS_frmlanddetails_buildnow" Async="true" %>

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

        .style8 {
            height: 59px;
        }

        .style9 {
            width: 192px;
            height: 59px;
        }

        .style10 {
            width: 27px;
        }
        .auto-style1 {
            height: 340px;
        }
        .auto-style2 {
            width: 27px;
            height: 340px;
        }
    </style>

    <script type="text/javascript" language="javascript">

        function OpenPopup() {

            window.open("Lookups/LookupBDC.aspx", "List", "scrollbars=yes,resizable=yes,width=1000,height=650;display = block;position=absolute");

            return false;
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
        function checkLength(el) {
            if (el.value.length != 6) {
                alert("length must be exactly 6 characters")
            }
        }
    </script>
    <script type="text/javascript">

    </script>

    <%--<div style=" z-index: 1000; margin-left: -210px;margin-top:100px;opacity: 1; -moz-opacity: 1;">
<img alt="" src="../../Resource/Images/Processing.gif" />--%>
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
                <i class="fa fa-edit"></i><a href="#">Land Details</a>
            </li>
        </ol>
    </div>

    <div align="left">
        <div class="row" align="left">
            <div class="col-lg-11">
                <div class="panel panel-primary">
                    <div class="panel-heading" align="center">
                        <h3 class="panel-title">Enterprise Location Details</h3>
                    </div>

                    <div class="panel-body">
                        <table align="center" cellpadding="10" cellspacing="5" style="width: 86%">

                            <tr id="Tr1" runat="server" visible="false">
                                <td style="padding: 5px; margin: 5px" valign="top" colspan="3">
                                    <asp:Label ID="Label422" runat="server" CssClass="LBLBLACK" Font-Bold="True"
                                        Width="210px">Location<font 
                                                            color="red">*</font></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="padding: 5px; margin: 5px" valign="top">
                                    <table cellpadding="4" cellspacing="5" style="width: 83%">
                                        <tr id="Tr2" runat="server" visible="false">
                                            <td style="padding: 5px; margin: 5px; text-align: left;">1</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label387" runat="server" CssClass="LBLBLACK" Width="210px">Proposed Location of Factory<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:DropDownList ID="ddlintProposedCateogryid" runat="server" class="form-control txtbox" TabIndex="1"
                                                    Height="33px" Width="180px">
                                                    <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                    <asp:ListItem Value="1">IE (Industrial Estate)</asp:ListItem>
                                                    <asp:ListItem Value="2">IDA (Industrial Development Area)</asp:ListItem>
                                                    <asp:ListItem Value="3">SEZ (Special Economic Zone)</asp:ListItem>
                                                    <asp:ListItem Value="4">Others</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server"
                                                    ControlToValidate="ddlintProposedCateogryid" ErrorMessage="Please Select Location of Factory"
                                                    InitialValue="--Select--" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                                                            <asp:Label ID="lblResult" runat="server"></asp:Label>

                                            </td>
                                        </tr>
                                        <tr id="Tr3" runat="server" visible="false">
                                            <td style="padding: 5px; margin: 5px; text-align: left;">2</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label396" runat="server" CssClass="LBLBLACK" Width="165px">Application Type<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:DropDownList ID="ddlintApplicationTypeid" runat="server" class="form-control txtbox" TabIndex="1"
                                                    Height="33px" Width="180px"
                                                    OnSelectedIndexChanged="ddlintApplicationTypeid_SelectedIndexChanged">
                                                    <asp:ListItem>--Select--</asp:ListItem>
                                                    <asp:ListItem Value="1">Change of Land Use</asp:ListItem>
                                                    <asp:ListItem Value="2">Industrial Building Approval</asp:ListItem>
                                                    <asp:ListItem Value="3">Both</asp:ListItem>
                                                    <asp:ListItem Value="4">None</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server"
                                                    ControlToValidate="ddlintApplicationTypeid" ErrorMessage="Please Select ApplicationType"
                                                    InitialValue="--Select--" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                                <td style="width: 27px">
                                    <asp:Label ID="Label348" runat="server" CssClass="LBLBLACK" Width="50px"></asp:Label>
                                </td>

                            </tr>
                            <tr>
                                <td style="padding: 5px; margin: 5px" valign="top">
                                    <%--</ProgressTemplate>
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
  </asp:UpdatePanel>--%>
                                    <table id="tblGeoDetailsforHotel" runat="server" visible="false" cellpadding="4" cellspacing="5" style="width: 83%">
                                        <tr>
                                            <td class="style8" style="padding: 5px; margin: 5px; text-align: left;">1</td>
                                            <td class="style8" style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label14" runat="server" CssClass="LBLBLACK" Width="165px">Upload Area Sketch<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td class="style8" style="padding: 5px; margin: 5px">:</td>
                                            <td class="style9" style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:FileUpload ID="FileUpload4" runat="server" class="form-control txtbox" TabIndex="1"
                                                    Height="28px" />


                                                <asp:HyperLink ID="HyperLink5" runat="server" CssClass="LBLBLACK"
                                                    Width="165px" Target="_blank">[lblFileName]</asp:HyperLink>
                                                <br />
                                                <asp:Label ID="Label144" runat="server" Visible="False"></asp:Label>
                                            </td>
                                            <td class="style8" style="padding: 5px; margin: 5px">
                                                <asp:Button ID="Button2" runat="server" CssClass="btn btn-xs btn-warning"
                                                    Height="28px" TabIndex="10" Text="Upload"
                                                    Width="72px" OnClick="BtnSave3_Click" CausesValidation="False" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">2</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label16" runat="server" CssClass="LBLBLACK" Width="210px">Latitude<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:TextBox ID="TextBox1" runat="server" class="form-control txtbox"
                                                    Height="28px" MaxLength="40" onkeypress="return inputOnlyNumbers(event)" TabIndex="1"
                                                    ValidationGroup="group" Width="180px"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">&nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">3</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label17" runat="server" CssClass="LBLBLACK" Width="210px">Longitude<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:TextBox ID="TextBox2" runat="server" class="form-control txtbox"
                                                    Height="28px" MaxLength="40" onkeypress="return inputOnlyNumbers(event)" TabIndex="1"
                                                    ValidationGroup="group" Width="180px"
                                                    OnTextChanged="txtcontact36_TextChanged"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">&nbsp;</td>
                                        </tr>
                                        <tr runat="server" id="trExcavation" visible="false">
                                            <td style="padding: 5px; margin: 5px; text-align: left;">4</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label18" runat="server" CssClass="LBLBLACK" Width="210px">Proposed depth of excavation (meters)<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:TextBox ID="txtExcavationDepth" runat="server" class="form-control txtbox"
                                                    Height="28px" MaxLength="40" onkeypress="return inputOnlyNumbers(event)" TabIndex="1"
                                                    ValidationGroup="group" Width="180px"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">&nbsp;</td>
                                        </tr>
                                    </table>
                                    <table id="ChangeofLandUse" runat="server" visible="false" cellpadding="4" cellspacing="5" style="width: 83%">
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">1</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label433" runat="server" CssClass="LBLBLACK" Width="210px">From Zone<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:DropDownList ID="ddlFromZone" runat="server" class="form-control txtbox" TabIndex="1"
                                                    Height="33px" Width="180px"
                                                    OnSelectedIndexChanged="ddlstatus27_SelectedIndexChanged">
                                                    <asp:ListItem>--Select--</asp:ListItem>
                                                    <asp:ListItem Value="1">Amenities</asp:ListItem>
                                                    <asp:ListItem Value="2">Bio Conservation</asp:ListItem>
                                                    <asp:ListItem Value="3">Commercial</asp:ListItem>
                                                    <asp:ListItem Value="4">Conservation</asp:ListItem>
                                                    <asp:ListItem Value="5">Forest</asp:ListItem>
                                                    <asp:ListItem Value="6">Green Belt</asp:ListItem>
                                                    <asp:ListItem Value="7">Multiple Use</asp:ListItem>
                                                    <asp:ListItem Value="8">open Space</asp:ListItem>
                                                    <asp:ListItem Value="9">public and Semi Public</asp:ListItem>
                                                    <asp:ListItem Value="10">Public Utilities</asp:ListItem>
                                                    <asp:ListItem Value="11">ReCreation</asp:ListItem>
                                                    <asp:ListItem Value="12">Residencial</asp:ListItem>
                                                    <asp:ListItem Value="13">S1</asp:ListItem>
                                                    <asp:ListItem Value="14">S2</asp:ListItem>
                                                    <asp:ListItem Value="15">Multipurpose use</asp:ListItem>
                                                    <asp:ListItem Value="16">Transportation</asp:ListItem>
                                                    <asp:ListItem Value="17">Water body</asp:ListItem>
                                                    <asp:ListItem Value="18">Other_S2</asp:ListItem>
                                                    <asp:ListItem Value="19">General Development Promotion Zone</asp:ListItem>

                                                    <asp:ListItem Value="20">Institutional & Special Reservation Zone</asp:ListItem>
                                                    <asp:ListItem Value="21">Central Square</asp:ListItem>
                                                    <asp:ListItem Value="22">Transportational Zone</asp:ListItem>
                                                    <asp:ListItem Value="23">Recreational Zone</asp:ListItem>
                                                    <asp:ListItem Value="24">Special Reservation Zone(Freight Container Complex)</asp:ListItem>
                                                    <asp:ListItem Value="25">Conservation Agriculture</asp:ListItem>

                                                    <asp:ListItem Value="26">Traffic & Transportation</asp:ListItem>


                                                </asp:DropDownList>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">&nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">2</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label434" runat="server" CssClass="LBLBLACK" Width="165px">To Zone<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:DropDownList ID="ddlToZone" runat="server" class="form-control txtbox" TabIndex="1"
                                                    Height="33px" Width="180px">
                                                    <asp:ListItem>--Select--</asp:ListItem>
                                                    <asp:ListItem Value="1">INDUSTRIAL</asp:ListItem>
                                                    <asp:ListItem Value="2">MANUFACTURE</asp:ListItem>

                                                </asp:DropDownList>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">&nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td class="style8" style="padding: 5px; margin: 5px; text-align: left;">3</td>
                                            <td class="style8" style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label437" runat="server" CssClass="LBLBLACK" Width="165px">Google Map to Upload<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td class="style8" style="padding: 5px; margin: 5px">:</td>
                                            <td class="style9" style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:FileUpload ID="fupGoogleMaptoUploadFile" runat="server" class="form-control txtbox" TabIndex="1"
                                                    Height="28px" />


                                                <asp:HyperLink ID="lblFileName" runat="server" CssClass="LBLBLACK"
                                                    Width="165px" Target="_blank">[lblFileName]</asp:HyperLink>
                                                <br />
                                                <asp:Label ID="Label455" runat="server" Visible="False"></asp:Label>
                                            </td>
                                            <td class="style8" style="padding: 5px; margin: 5px">
                                                <asp:Button ID="BtnSave3" runat="server" CssClass="btn btn-xs btn-warning"
                                                    Height="28px" TabIndex="10" Text="Upload"
                                                    Width="72px" OnClick="BtnSave3_Click" CausesValidation="False" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">4</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label435" runat="server" CssClass="LBLBLACK" Width="210px">Latitude<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:TextBox ID="txtGeo_Cordinate_Latitude" runat="server" class="form-control txtbox"
                                                    Height="28px" MaxLength="40" onkeypress="return inputOnlyNumbers(event)" TabIndex="1"
                                                    ValidationGroup="group" Width="180px"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">&nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">5</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label450" runat="server" CssClass="LBLBLACK" Width="210px">Longitude<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:TextBox ID="txtGeo_Cordinate_Langitude" runat="server" class="form-control txtbox"
                                                    Height="28px" MaxLength="40" onkeypress="return inputOnlyNumbers(event)" TabIndex="1"
                                                    ValidationGroup="group" Width="180px"
                                                    OnTextChanged="txtcontact36_TextChanged"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">&nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">6</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label436" runat="server" CssClass="LBLBLACK" Width="165px">KML File<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:FileUpload ID="fupKMLFileName" runat="server" class="form-control txtbox" TabIndex="1"
                                                    Height="28px" />
                                                <asp:HyperLink ID="lblFileName2" runat="server" CssClass="LBLBLACK"
                                                    Width="165px" Target="_blank">[lblFileName2]</asp:HyperLink>
                                                <br />
                                                <asp:Label ID="Label456" runat="server" Visible="False"></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:Button ID="BtnSave6" runat="server" CssClass="btn btn-xs btn-warning"
                                                    Height="28px" TabIndex="10" Text="Upload"
                                                    Width="72px" OnClick="BtnSave6_Click" CausesValidation="False" />
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                                <td style="width: 27px">&nbsp;</td>
                                <td valign="top" rowspan="2">
                                    <%--</div>
       </td>
        </tr>
    </table>--%>
                                    <table id="Acceptance" runat="server" visible="false" cellpadding="4" cellspacing="5" style="width: 83%">
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">7</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label438" runat="server" CssClass="LBLBLACK" Width="165px">If the site mentioned is covered in part survey number,Revenue sketch by showing the site under reference with in the survey number is MANDATORY<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:RadioButtonList ID="rblCovered_revenueSketch" runat="server" TabIndex="1"
                                                    RepeatDirection="Horizontal">
                                                    <asp:ListItem Value="Y">Yes</asp:ListItem>
                                                    <asp:ListItem Value="N">No</asp:ListItem>
                                                </asp:RadioButtonList>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">&nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">8</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label439" runat="server" CssClass="LBLBLACK" Width="165px">If the site is covered adjoining to Water body/Tanks/Streams/NOC &amp; Revenue sketch issued by Irrigation EE &amp; Joint Collector from Revenue Department is MANDATORY<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:RadioButtonList ID="rblCovered_Adjoining" runat="server" TabIndex="1"
                                                    RepeatDirection="Horizontal">
                                                    <asp:ListItem Value="Y">Yes</asp:ListItem>
                                                    <asp:ListItem Value="N">No</asp:ListItem>
                                                </asp:RadioButtonList>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">&nbsp;</td>
                                        </tr>
                                    </table>
                                    <%--------------------------Visible False-------------------%>
                                </td>
                            </tr>
                            <tr>
                                <td style="padding: 5px; margin: 5px" valign="top">

                                    <%--  ******************************************************--%>
                                    <table id="IndustrialBuildingApproval" runat="server" visible="false" cellpadding="4" cellspacing="5" style="width: 83%">
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">1</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label440" runat="server" CssClass="LBLBLACK" Width="210px">Plot Number(s)<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:TextBox ID="txtPlot_Number" runat="server" class="form-control txtbox"
                                                    Height="28px" MaxLength="8" TabIndex="1"
                                                    ValidationGroup="group" Width="180px"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">&nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">2</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label441" runat="server" CssClass="LBLBLACK" Width="165px">Sanctioned Layout No(If Any)<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:TextBox ID="txtSanction_LayoutNo" runat="server" class="form-control txtbox"
                                                    Height="28px" MaxLength="20" TabIndex="1"
                                                    ValidationGroup="group" Width="180px"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">&nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">3</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label442" runat="server" CssClass="LBLBLACK" Width="165px">Land Use as per Master Plan<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:TextBox ID="txtLand_User_MasterPlan" runat="server" class="form-control txtbox"
                                                    Height="28px" MaxLength="20" TabIndex="1"
                                                    ValidationGroup="group" Width="180px"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">&nbsp;</td>
                                        </tr>

                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">5</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label444" runat="server" CssClass="LBLBLACK" Width="210px">Affected in Road Widening<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:RadioButtonList ID="rblAffected_roadwinding1" runat="server"
                                                    RepeatDirection="Horizontal" TabIndex="1"
                                                    OnSelectedIndexChanged="RadioButtonList9_SelectedIndexChanged">
                                                    <asp:ListItem Value="Y">Yes</asp:ListItem>
                                                    <asp:ListItem Value="N">No</asp:ListItem>
                                                </asp:RadioButtonList>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">&nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">6</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label451" runat="server" CssClass="LBLBLACK" Width="210px">Latitude<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:TextBox ID="txtGeo_Cordinate_Latitude1" runat="server" class="form-control txtbox"
                                                    Height="28px" MaxLength="40" TabIndex="1" onkeypress="return inputOnlyNumbers(event)"
                                                    ValidationGroup="group" Width="180px"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">&nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">7</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label452" runat="server" CssClass="LBLBLACK" Width="210px">Longitude<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:TextBox ID="txtGeo_Cordinate_Langitude1" runat="server" class="form-control txtbox"
                                                    Height="28px" MaxLength="40" TabIndex="1" onkeypress="return inputOnlyNumbers(event)"
                                                    ValidationGroup="group" Width="180px"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">&nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">8</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label447" runat="server" CssClass="LBLBLACK" Width="165px">KML File<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:FileUpload ID="fupKMLFileName1" runat="server" class="form-control txtbox" TabIndex="1"
                                                    Height="28px" />
                                                <asp:HyperLink ID="lblFileName1" runat="server" CssClass="LBLBLACK"
                                                    Width="165px" Target="_blank">[lblFileName1]</asp:HyperLink>
                                                <br />
                                                <asp:Label ID="Label457" runat="server" Visible="False"></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:Button ID="BtnSave5" runat="server" CssClass="btn btn-xs btn-warning"
                                                    Height="28px" TabIndex="10" Text="Upload"
                                                    Width="72px" OnClick="BtnSave5_Click" CausesValidation="False" />
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                                <td style="width: 27px">&nbsp;</td>
                            </tr>
                            <%--<tr>
                                <td style="padding: 5px; margin: 5px" valign="top">
                                    <table cellpadding="4" cellspacing="5" style="width: 83%">
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">1</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label454" runat="server" CssClass="LBLBLACK" Width="210px">Are Site Plan/Building Plan/Section &amp; Elevation etc submitted as per G.O.Ms No.168, MA &amp; UD.,dt 7-4-2012?<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:RadioButtonList ID="rblIsSitePlanning" runat="server" TabIndex="1"
                                                    RepeatDirection="Horizontal">
                                                    <asp:ListItem Value="Y">Yes</asp:ListItem>
                                                    <asp:ListItem Value="N">No</asp:ListItem>
                                                </asp:RadioButtonList>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">&nbsp;</td>
                                        </tr>
                                    </table>
                                </td>
                                <td style="width: 27px">&nbsp;</td>
                                <td valign="top">&nbsp;</td>
                            </tr>--%>
                            <tr>
                                <td style="padding: 5px; margin: 5px" valign="top" align="left">
                                    <asp:Label ID="Label378" runat="server" CssClass="LBLBLACK" Width="280px"
                                        Font-Bold="True">Location of the Unit</asp:Label>
                                </td>
                                <td class="style10"></td>
                                <td valign="top"></td>
                            </tr>



                            <tr>
                                <td style="padding: 5px; margin: 5px" valign="top">
                                    <table cellpadding="4" cellspacing="5" style="width: 83%">

                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">1.</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label401" runat="server" CssClass="LBLBLACK" Width="200px">Survey No/Plot Number(s)<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                <asp:TextBox ID="txtSurveyNo" runat="server" class="form-control txtbox"
                                                    Height="28px" MaxLength="220" TabIndex="1"
                                                    ValidationGroup="group" Width="180px"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server"
                                                    ControlToValidate="txtSurveyNo" ErrorMessage="Please Enter Survey Number"
                                                    ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">2.</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label424" runat="server" CssClass="LBLBLACK" Width="165px">District<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:DropDownList ID="ddlLand_intDistrictid" runat="server"
                                                    class="form-control txtbox" Height="33px" Width="180px" TabIndex="1"
                                                    OnSelectedIndexChanged="ddlLand_intDistrictid_SelectedIndexChanged"
                                                    AutoPostBack="True">
                                                    <asp:ListItem>--Select--</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server"
                                                    ControlToValidate="ddlLand_intDistrictid" ErrorMessage="Please select District"
                                                    InitialValue="--Select--" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px">3.</td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:Label ID="Label412" runat="server" CssClass="LBLBLACK" Width="165px">Mandal<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:DropDownList ID="ddlLand_intMandalid" runat="server" class="form-control txtbox"
                                                    Height="33px" Width="180px" TabIndex="1"
                                                    OnSelectedIndexChanged="ddlLand_intMandalid_SelectedIndexChanged"
                                                    AutoPostBack="True">
                                                    <asp:ListItem>--Select--</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server"
                                                    ControlToValidate="ddlLand_intMandalid" ErrorMessage="Please select Mandal"
                                                    InitialValue="--Select--" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px">4.</td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:Label ID="Label402" runat="server" CssClass="LBLBLACK" Width="165px">Village/Town<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:DropDownList ID="ddlLand_intVillageid" runat="server" class="form-control txtbox" TabIndex="1"
                                                    Height="33px" Width="180px">
                                                    <asp:ListItem>--Select--</asp:ListItem>

                                                </asp:DropDownList>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server"
                                                    ControlToValidate="ddlLand_intVillageid" ErrorMessage="Please select Village"
                                                    InitialValue="--Select--" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px">5.</td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:Label ID="Label411" runat="server" CssClass="LBLBLACK" Width="165px">Name of Grampanchayat<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:TextBox ID="txtName_Gramapachayat" runat="server"
                                                    class="form-control txtbox" Height="28px" MaxLength="40"
                                                    TabIndex="1" ValidationGroup="group" Width="180px"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server"
                                                    ControlToValidate="txtName_Gramapachayat" ErrorMessage="Please Enter GP"
                                                    ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px">6.</td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:Label ID="Label425" runat="server" CssClass="LBLBLACK" Width="165px">PinCode<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:TextBox ID="txtLand_Pincode" runat="server" class="form-control txtbox"
                                                    Height="28px" MaxLength="6" TabIndex="1" onkeypress="NumberOnly()" onblur="checkLength(this)" oncopy="return false" onpaste="return false" oncut="return false"
                                                    ValidationGroup="group" Width="180px"
                                                    OnTextChanged="txtcontact20_TextChanged"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server"
                                                    ControlToValidate="txtLand_Pincode" ErrorMessage="Please Enter Pincode"
                                                    ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr id="Tr4" runat="server" visible="false">
                                            <td style="padding: 5px; margin: 5px">7.</td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:Label ID="Label426" runat="server" CssClass="LBLBLACK" Width="165px">EMail<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:TextBox ID="txtLand_Email" runat="server" class="form-control txtbox"
                                                    Height="28px" MaxLength="40" TabIndex="1"
                                                    ValidationGroup="group" Width="180px"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <%-- <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server"
                                                    ControlToValidate="txtLand_Email" ErrorMessage="Please Enter Correct Email"
                                                    ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                                    ValidationGroup="group">*</asp:RegularExpressionValidator>--%>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px">8.</td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:Label ID="Label427" runat="server" CssClass="LBLBLACK" Width="200px">Tel No(Landline)(If available)</asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:TextBox ID="txtLand_TelephoneNumber" runat="server" class="form-control txtbox"
                                                    Height="28px" MaxLength="18" onkeypress="NumberOnly()" TabIndex="1"
                                                    ValidationGroup="group" Width="180px"
                                                    OnTextChanged="txtLand_TelephoneNumber_TextChanged"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">&nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px" valign="top">9.</td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:Label ID="Label428" runat="server" CssClass="LBLBLACK" Width="200px">Total Extent of Site Area as Per Documents(in Sq. mts)</asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px" valign="top">:</td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:TextBox ID="txtLand_TotExtent" runat="server" class="form-control txtbox"
                                                    Height="28px" MaxLength="10" TabIndex="1" onkeypress="return inputOnlyNumbers(event)"
                                                    ValidationGroup="group" Width="180px"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">&nbsp;</td>
                                        </tr>
                                        <tr id="trexistingbuildup" runat="server" visible="false">
                                            <td style="padding: 5px; margin: 5px" valign="top">9.a</td>
                                            <td style="padding: 5px; margin: 5px">Existing build up area</td>
                                            <td style="padding: 5px; margin: 5px" valign="top">&nbsp;</td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:TextBox ID="txtexistingbuildup" runat="server" class="form-control txtbox"
                                                    Height="28px" MaxLength="10" TabIndex="1" onkeypress="return inputOnlyNumbers(event)"
                                                    ValidationGroup="group" Width="180px"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server"
                                                    ControlToValidate="txtexistingbuildup" ErrorMessage="Please Enter Existing Buildup Area"
                                                    ValidationGroup="group">*</asp:RequiredFieldValidator></td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px">10.</td>
                                            <td style="padding: 5px; margin: 5px">Type of Building</td>
                                            <td style="padding: 5px; margin: 5px">&nbsp;</td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:DropDownList ID="ddltypeofbuilding" runat="server" class="form-control txtbox"
                                                    Height="33px" Width="180px" TabIndex="1" OnSelectedIndexChanged="ddltypeofbuilding_SelectedIndexChanged" AutoPostBack="True">
                                                    <asp:ListItem>--Select--</asp:ListItem>
                                                    <asp:ListItem Value="1">Industrial</asp:ListItem>
                                                    <asp:ListItem Value="2">Commercial</asp:ListItem>
                                                    <%--<asp:ListItem Value="3">Residential</asp:ListItem>
                                                    <asp:ListItem Value="4">Other</asp:ListItem>--%>
                                                </asp:DropDownList></td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server"
                                                    ControlToValidate="ddltypeofbuilding" ErrorMessage="Please Select Type of Building"
                                                    InitialValue="--Select--" ValidationGroup="group">*</asp:RequiredFieldValidator></td>
                                        </tr>
                                        <tr id="trtypeofbuildingother" runat="server" visible="false">
                                            <td style="padding: 5px; margin: 5px">10.a</td>
                                            <td style="padding: 5px; margin: 5px">&nbsp;</td>
                                            <td style="padding: 5px; margin: 5px">&nbsp;</td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:TextBox ID="txttypeofbuildingother" runat="server" class="form-control txtbox"
                                                    Height="28px" MaxLength="10" TabIndex="1"
                                                    ValidationGroup="group" Width="180px"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">&nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px">11.</td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:Label ID="Label458" runat="server" CssClass="LBLBLACK" Width="165px">Land Use as per Master Plan<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">&nbsp;</td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:DropDownList ID="ddllandaspermasterplan" runat="server" class="form-control txtbox"
                                                    Height="33px" Width="180px" TabIndex="1" OnSelectedIndexChanged="ddllandaspermasterplan_SelectedIndexChanged" AutoPostBack="True">
                                                    <asp:ListItem>--Select--</asp:ListItem>
                                                    <asp:ListItem Value="1">Industrial</asp:ListItem>
                                                    <asp:ListItem Value="2">Manufacturing</asp:ListItem>
                                                    <asp:ListItem Value="3">Work Center</asp:ListItem>
                                                    <asp:ListItem Value="4">Commercial</asp:ListItem>
                                                    <asp:ListItem Value="5">Residential</asp:ListItem>
                                                    <asp:ListItem Value="6">Conservation</asp:ListItem>
                                                    <asp:ListItem Value="7">Peri-urban</asp:ListItem>
                                                    <asp:ListItem Value="8">Other</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator17" runat="server"
                                                    ControlToValidate="ddllandaspermasterplan" ErrorMessage="Please Select Land Master Plan"
                                                    InitialValue="--Select--" ValidationGroup="group">*</asp:RequiredFieldValidator></td>
                                        </tr>
                                        <tr id="trlandmasterplanother" runat="server" visible="false">
                                            <td style="padding: 5px; margin: 5px">11.a</td>
                                            <td style="padding: 5px; margin: 5px">&nbsp;</td>
                                            <td style="padding: 5px; margin: 5px">&nbsp;</td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:TextBox ID="txtlandmasterplan" runat="server" class="form-control txtbox"
                                                    Height="28px" MaxLength="10" TabIndex="1"
                                                    ValidationGroup="group" Width="180px"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator24" runat="server"
                                                    ControlToValidate="txtlandmasterplan" ErrorMessage="Please Enter Land as per master plan"
                                                    ValidationGroup="group">*</asp:RequiredFieldValidator></td>
                                        </tr>
                                    </table>
                                </td>
                                <td style="width: 27px">&nbsp;</td>
                                <td valign="top">
                                    <table cellpadding="4" cellspacing="5" style="width: 83%">
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">12.</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label416" runat="server" CssClass="LBLBLACK" Width="165px">Proposed Area for Development(in Sq. mts)<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                <asp:TextBox ID="txtLand_ProposedArea" runat="server" class="form-control txtbox"
                                                    Height="28px" MaxLength="10" TabIndex="1" onkeypress="return inputOnlyNumbers(event)"
                                                    ValidationGroup="group" Width="180px"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator18" runat="server"
                                                    ControlToValidate="txtLand_ProposedArea"
                                                    ErrorMessage="Please Enter Proposed Area" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">13.</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label417" runat="server" CssClass="LBLBLACK" Width="165px">Total Built up Area(in Sq. mts)<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:TextBox ID="txtLand_BuiltupArea" runat="server" class="form-control txtbox"
                                                    Height="28px" MaxLength="10" TabIndex="1" onkeypress="return inputOnlyNumbers(event)"
                                                    ValidationGroup="group" Width="180px"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">&nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">14.</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label443" runat="server" CssClass="LBLBLACK" Width="165px">Height of the Building(In mtrs)<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:TextBox ID="txtHight_Building" runat="server" class="form-control txtbox"
                                                    Height="28px" MaxLength="10" onkeypress="return inputOnlyNumbers(event)" TabIndex="1"
                                                    ValidationGroup="group" Width="180px"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">&nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">15.</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label420" runat="server" CssClass="LBLBLACK" Width="165px">Existing Width of Approach Road(in feet)<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:TextBox ID="txtLand_Existingwidth" runat="server" class="form-control txtbox"
                                                    Height="28px" MaxLength="10" onkeypress="return inputOnlyNumbers(event)" TabIndex="1"
                                                    ValidationGroup="group" Width="180px"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator19" runat="server"
                                                    ControlToValidate="txtLand_Existingwidth"
                                                    ErrorMessage="Please Enter Esisting Width" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px">16.</td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:Label ID="Label421" runat="server" CssClass="LBLBLACK" Width="165px">Type of Approach Road<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:DropDownList ID="ddlintTypeofApprochid" runat="server" class="form-control txtbox"
                                                    Height="33px" Width="180px" TabIndex="1"
                                                    OnSelectedIndexChanged="ddlstatus17_SelectedIndexChanged">
                                                    <asp:ListItem>--Select--</asp:ListItem>
                                                    <asp:ListItem Value="1">WBM</asp:ListItem>
                                                    <asp:ListItem Value="2">Gravel</asp:ListItem>
                                                    <asp:ListItem Value="3">CC</asp:ListItem>
                                                    <asp:ListItem Value="4">Black Top</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator20" runat="server"
                                                    ControlToValidate="ddlintTypeofApprochid" ErrorMessage="Please Select Type of Road"
                                                    InitialValue="--Select--" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px" valign="top">17.</td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:Label ID="Label429" runat="server" CssClass="LBLBLACK" Width="165px">Land Location falls under<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:DropDownList ID="ddlintLocationFalls" runat="server" class="form-control txtbox"
                                                    Height="33px" Width="180px" TabIndex="1"
                                                    OnSelectedIndexChanged="ddlstatus23_SelectedIndexChanged">
                                                    <asp:ListItem>--Select--</asp:ListItem>
                                                    <asp:ListItem Value="4">IALA</asp:ListItem>
                                                    <asp:ListItem Value="2">DTCP</asp:ListItem>
                                                    <asp:ListItem Value="3">KUDA</asp:ListItem>
                                                    <asp:ListItem Value="1">HMDA</asp:ListItem>
                                                    <asp:ListItem Value="5">GHMC</asp:ListItem>
                                                    <asp:ListItem Value="6">GWMC</asp:ListItem>
                                                    <%--<asp:ListItem Value="9">SUDA</asp:ListItem>--%>
                                                    <asp:ListItem Value="9">SUDA_KARIMNAGAR</asp:ListItem>
                                                    <asp:ListItem Value="10">NUDA</asp:ListItem>
                                                    <asp:ListItem Value="11">SUDA_KHAMMAM</asp:ListItem>
                                                    <asp:ListItem Value="12">SUDA_SIDDIPET</asp:ListItem>

                                                </asp:DropDownList>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator21" runat="server"
                                                    ControlToValidate="ddlintLocationFalls" ErrorMessage="Please Select Location "
                                                    InitialValue="--Select--" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px">18.</td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:Label ID="Label430" runat="server" CssClass="LBLBLACK" Width="165px">Building Approval<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:DropDownList ID="ddlintBuildingApproval" runat="server" class="form-control txtbox"
                                                    Height="33px" Width="180px" TabIndex="1"
                                                    OnSelectedIndexChanged="ddlstatus24_SelectedIndexChanged">
                                                    <asp:ListItem>--Select--</asp:ListItem>
                                                    <asp:ListItem Value="1">Revised</asp:ListItem>
                                                    <asp:ListItem Value="2">New</asp:ListItem>
                                                    <asp:ListItem Value="3">Alteration</asp:ListItem>
                                                    <asp:ListItem Value="4">Addition</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator22" runat="server"
                                                    ControlToValidate="ddlintBuildingApproval" ErrorMessage="Please Select Buliding Approval"
                                                    InitialValue="--Select--" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px" valign="top">19.</td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:Label ID="lblIndusProdActivity" runat="server" CssClass="LBLBLACK" Width="165px">Please Enter Industry/Product/Activity<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:DropDownList ID="ddlintIndustryProduct" runat="server" class="form-control txtbox"
                                                    Height="33px" Width="180px" TabIndex="1"
                                                    OnSelectedIndexChanged="ddlstatus25_SelectedIndexChanged">
                                                    <%-- <asp:ListItem>--Select--</asp:ListItem>
                                                    <asp:ListItem Value="1">Proprietary</asp:ListItem>
                                                    <asp:ListItem Value="2">Partnership</asp:ListItem>
                                                    <asp:ListItem Value="3">Pvt Ltd</asp:ListItem>
                                                    <asp:ListItem Value="4">Public Limited</asp:ListItem>
                                                    <asp:ListItem Value="5">Co-Operative</asp:ListItem>
                                                    <asp:ListItem Value="6">LLP</asp:ListItem>
                                                    <asp:ListItem Value="7">Trust</asp:ListItem>--%>
                                                </asp:DropDownList>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">&nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px">20.</td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:Label ID="lblCategoryofIndus" runat="server" CssClass="LBLBLACK" Width="165px">Category of Industry<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:DropDownList ID="ddlintCategoryid" runat="server" class="form-control txtbox"
                                                    Height="33px" Width="180px" TabIndex="1"
                                                    OnSelectedIndexChanged="ddlstatus26_SelectedIndexChanged">
                                                    <asp:ListItem>--Select--</asp:ListItem>
                                                    <asp:ListItem Value="1">Orange</asp:ListItem>
                                                    <asp:ListItem Value="2">Red</asp:ListItem>
                                                    <asp:ListItem Value="3">Green</asp:ListItem>
                                                    <asp:ListItem Value="4">White</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator23" runat="server"
                                                    ControlToValidate="ddlintCategoryid" ErrorMessage="Please Select Category of Industry"
                                                    InitialValue="--Select--" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr id="trsez" runat="server">
                                            <td style="padding: 5px; margin: 5px">21.</td>
                                            <td style="width: 200px;">
                                                <asp:Label ID="Label423" runat="server" CssClass="LBLBLACK" Width="200px"> Location Name of IE/IDA/SEZ</asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:TextBox ID="txtLocationNameIEIDA" runat="server" class="form-control txtbox"
                                                    Height="28px" MaxLength="20" TabIndex="1"
                                                    ValidationGroup="group" Width="180px"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">&nbsp;</td>
                                        </tr>


                                        <tr id="trroad" runat="server" visible="true">
                                            <td style="padding: 5px; margin: 5px">22.</td>
                                            <td style="width: 200px;">
                                                <asp:Label ID="Label4" runat="server" CssClass="LBLBLACK" Width="210px">Affected in Road Widening<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">&nbsp;</td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:RadioButtonList ID="rblAffected_roadwinding" runat="server"
                                                    RepeatDirection="Horizontal" TabIndex="1" OnSelectedIndexChanged="rblAffected_roadwinding_SelectedIndexChanged" AutoPostBack="True">
                                                    <asp:ListItem Value="Y">Yes</asp:ListItem>
                                                    <asp:ListItem Value="N" Selected="True">No</asp:ListItem>
                                                </asp:RadioButtonList>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator28" runat="server"
                                                    ControlToValidate="rblAffected_roadwinding" ErrorMessage="Please Select Affected in Road Widening"
                                                    ValidationGroup="group">*</asp:RequiredFieldValidator></td>
                                        </tr>

                                        <tr id="trraodwidening" runat="server" visible="false">
                                            <td style="padding: 5px; margin: 5px">22.a</td>
                                            <td style="width: 200px;">Extend of affected area in sq.mts</td>
                                            <td style="padding: 5px; margin: 5px">&nbsp;</td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:TextBox ID="txtroadwidening" runat="server" class="form-control txtbox"
                                                    Height="28px" MaxLength="20" TabIndex="1"
                                                    ValidationGroup="group" Width="180px"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator29" runat="server"
                                                    ControlToValidate="txtroadwidening" ErrorMessage="Please Select Extend of affected area in sq.mts"
                                                    ValidationGroup="group">*</asp:RequiredFieldValidator></td>
                                        </tr>

                                        <tr>
                                            <td style="padding: 5px; margin: 5px">23.</td>
                                            <td style="width: 200px;">Is land part of<font
                                                color="red">*</font></td>
                                            <td style="padding: 5px; margin: 5px">&nbsp;</td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:DropDownList ID="ddlislandpartof" runat="server" class="form-control txtbox"
                                                    Height="33px" Width="180px" TabIndex="1">
                                                    <asp:ListItem>--Select--</asp:ListItem>
                                                    <asp:ListItem Value="1">Approved layout</asp:ListItem>
                                                    <asp:ListItem Value="2">Piece of land</asp:ListItem>
                                                </asp:DropDownList></td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator25" runat="server"
                                                    ControlToValidate="ddlislandpartof" ErrorMessage="Please Select Is Land Part of"
                                                    ValidationGroup="group" InitialValue="--Select--">*</asp:RequiredFieldValidator></td>
                                            <%--</td>--%>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr id="TRHEADING" runat="server" visible="false" >
                                <td style="font-size: 15px; color:red" colspan="4">
                                    <div class="panel-body">
                                        <div id="flashingtext" style="font-size: 15px; color:red">
                                            <b>
                                                <h4>
                                            <asp:HyperLink CssClass="btn btn-link" ID="HyperLink6" Target="_blank" Font-Bold="true" Font-Size="20px" ForeColor="Red" runat="server" NavigateUrl="https://dcrportal.telangana.gov.in/BPAMSClient/Default.aspx" Text="Click here to get Drawing Reference No and Secret Key."> </asp:HyperLink>
                                                      </h4>
                                            </b>
                                        </div>
                                    </div>

                                </td>
                            </tr>
                            <tr id="trarchitec" runat="server" visible="false">
                                <td style="padding: 5px; margin: 5px" valign="top" class="auto-style1">
                                    <table cellpadding="4" cellspacing="5" style="width: 83%">

                                        <tr id="drawingno" runat="server" visible="true">
                                            <td style="padding: 5px; margin: 5px; text-align: left;">1.</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label15" runat="server" CssClass="LBLBLACK" Width="200px">Drawing Reference No.<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                <%-- <asp:TextBox ID="txtArchitectLicenseno" runat="server" class="form-control txtbox"
                                                    Height="28px" MaxLength="100" TabIndex="1"
                                                    ValidationGroup="group" Width="180px"></asp:TextBox>--%>
                                                <asp:TextBox ID="txtdrrefno1" runat="server" class="textboxPge"
                                                    TabIndex="1"
                                                    ValidationGroup="group" Width="30px" Text="TS" ReadOnly="true"></asp:TextBox>
                                                <asp:TextBox ID="txtdrrefno2" runat="server" class="textboxPge"
                                                    TabIndex="1"
                                                    ValidationGroup="group" Width="70px" onkeypress="NumberOnly()"></asp:TextBox>
                                                <asp:TextBox ID="txtdrrefno3" runat="server" class="textboxPge"
                                                    TabIndex="1"
                                                    ValidationGroup="group" Width="60px" MaxLength="4" onkeypress="NumberOnly()"></asp:TextBox>
                                                (Ex : TS/000026/2024)
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator30" runat="server"
                                                    ControlToValidate="txtalic3" ErrorMessage="Please Enter Drawing Refefence No"
                                                    ValidationGroup="group">*</asp:RequiredFieldValidator>--%>
                                            </td>
                                        </tr>
                                        <tr id="TRARCHLICNO" runat="server" visible="false" >
                                            <td style="padding: 5px; margin: 5px; text-align: left;">1.</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label2" runat="server" CssClass="LBLBLACK" Width="200px">Architect License No.<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                <%-- <asp:TextBox ID="txtArchitectLicenseno" runat="server" class="form-control txtbox"
                                                    Height="28px" MaxLength="100" TabIndex="1"
                                                    ValidationGroup="group" Width="180px"></asp:TextBox>--%>
                                                <asp:TextBox ID="txtalic1" runat="server" class="textboxPge"
                                                    TabIndex="1"
                                                    ValidationGroup="group" Width="40px" Text="CA" ReadOnly="true"></asp:TextBox>
                                                <asp:TextBox ID="txtalic2" runat="server" class="textboxPge"
                                                    TabIndex="1"
                                                    ValidationGroup="group" Width="50px" OnTextChanged="txtalic2_TextChanged" AutoPostBack="true" MaxLength="4" onkeypress="NumberOnly()"></asp:TextBox>
                                                <asp:TextBox ID="txtalic3" runat="server" class="textboxPge"
                                                    TabIndex="1"
                                                    ValidationGroup="group" Width="60px" MaxLength="6" onkeypress="NumberOnly()" OnTextChanged="txtalic3_TextChanged" AutoPostBack="true"></asp:TextBox>
                                                (Ex : CA-Year-5 digits.)
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                                                    ControlToValidate="txtalic3" ErrorMessage="Please Enter Architect License No"
                                                    ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr  id="TRARCHLICNAME" runat="server"  visible="false" >
                                            <td style="padding: 5px; margin: 5px; text-align: left;">2.</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label1" runat="server" CssClass="LBLBLACK" Width="200px">Architect Name<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                <asp:TextBox ID="txtArchitectName" runat="server" class="form-control txtbox"
                                                    Height="28px" MaxLength="100" TabIndex="1"
                                                    ValidationGroup="group" Width="180px"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                                                    ControlToValidate="txtArchitectName" ErrorMessage="Please Enter Architect Name"
                                                    ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>


                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">&nbsp;</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">&nbsp;</td>
                                            <td style="padding: 5px; margin: 5px">&nbsp;</td>
                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">&nbsp;</td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">&nbsp;</td>
                                        </tr>
                                        <tr id="trstructuralengname" runat="server" visible="false">
                                            <td style="padding: 5px; margin: 5px; text-align: left;">1.</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">Structural Engineer Name</td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                <asp:TextBox ID="txtstructuralengname" runat="server" class="form-control txtbox"
                                                    Height="28px" MaxLength="100" TabIndex="1"
                                                    ValidationGroup="group" Width="180px"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server"
                                                    ControlToValidate="txtstructuralengname" ErrorMessage="Please Enter Structural Name"
                                                    ValidationGroup="group">*</asp:RequiredFieldValidator></td>
                                        </tr>
                                        <tr id="trstructuralenglicno" runat="server" visible="false">
                                            <td style="padding: 5px; margin: 5px; text-align: left;">3.</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">Structural License No.</td>
                                            <td style="padding: 5px; margin: 5px">&nbsp;</td>
                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                <asp:TextBox ID="txtstructuralenglicno" runat="server" class="form-control txtbox"
                                                    Height="28px" MaxLength="100" TabIndex="1"
                                                    ValidationGroup="group" Width="180px"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server"
                                                    ControlToValidate="txtstructuralenglicno" ErrorMessage="Please Enter Structural License No"
                                                    ValidationGroup="group">*</asp:RequiredFieldValidator></td>
                                        </tr>

                                    </table>
                                </td>
                                <td class="auto-style2"></td>
                                <td style="padding: 5px; margin: 5px" valign="top" class="auto-style1">
                                    <table>
                                        <tr id="drawing2" runat="server" visible="true">
                                            <td style="padding: 5px; margin: 5px; text-align: left;">2.</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label19" runat="server" CssClass="LBLBLACK" Width="200px">SecretKey.<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                <asp:TextBox ID="txtSecretKey" runat="server" class="form-control txtbox"
                                                    Height="28px" TabIndex="1"
                                                    ValidationGroup="group" Width="180px" OnTextChanged="txtSecretKey_TextChanged" AutoPostBack="true"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator31" runat="server"
                                                    ControlToValidate="txtSecretKey" ErrorMessage="Please Enter SecretKey"
                                                    ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">&nbsp;</td>
                                        </tr>
                                        <tr  id="TRARCHLICMOBILENO" runat="server"  visible="false" >
                                            <td style="padding: 5px; margin: 5px; text-align: left;">3.</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label3" runat="server" CssClass="LBLBLACK" Width="200px">Architect Mobile No.<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                <asp:TextBox ID="txtArchitectMobileno" runat="server" class="form-control txtbox"
                                                    Height="28px" MaxLength="10" TabIndex="1"
                                                    ValidationGroup="group" Width="180px" onkeypress="NumberOnly()"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server"
                                                    ControlToValidate="txtArchitectMobileno" ErrorMessage="Please Enter Architect Mobile No"
                                                    ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr id="trcorportaion" runat="server" visible="false">
                                            <td style="padding: 5px; margin: 5px; text-align: left;">4.</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">Corportaion Name:</td>
                                            <td style="padding: 5px; margin: 5px">&nbsp;</td>
                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                <asp:DropDownList ID="ddlcorporationname" runat="server" OnSelectedIndexChanged="ddlcorporationname_SelectedIndexChanged">
                                                </asp:DropDownList>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator26" runat="server"
                                                    ControlToValidate="ddlcorporationname" ErrorMessage="Please Select Corporation Name"
                                                    ValidationGroup="group" InitialValue="--Select--">*</asp:RequiredFieldValidator></td>
                                        </tr>
                                        <tr id="trwardno" runat="server" visible="false">
                                            <td style="padding: 5px; margin: 5px; text-align: left;">5.</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">Ward Number:</td>
                                            <td style="padding: 5px; margin: 5px">&nbsp;</td>
                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                <asp:DropDownList ID="ddlwardno" runat="server">
                                                </asp:DropDownList>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator27" runat="server"
                                                    ControlToValidate="ddlwardno" ErrorMessage="Please Select Ward Number"
                                                    ValidationGroup="group" InitialValue="--Select--">*</asp:RequiredFieldValidator></td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px">&nbsp;</td>
                                            <td style="padding: 5px; margin: 5px">&nbsp;</td>
                                            <td style="padding: 5px; margin: 5px">&nbsp;</td>
                                            <td style="padding: 5px; margin: 5px">&nbsp;</td>
                                            <td style="padding: 5px; margin: 5px">&nbsp;</td>
                                        </tr>

                                        <tr id="trstructuralengmobileno" runat="server" visible="false">
                                            <td style="padding: 5px; margin: 5px">2</td>
                                            <td style="padding: 5px; margin: 5px">Structural Mobile No</td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:TextBox ID="txtstructuralmobileno" runat="server" class="form-control txtbox"
                                                    Height="28px" MaxLength="10" TabIndex="1"
                                                    ValidationGroup="group" Width="180px" onkeypress="NumberOnly()"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server"
                                                    ControlToValidate="txtstructuralmobileno" ErrorMessage="Please Enter Structural Mobile No"
                                                    ValidationGroup="group">*</asp:RequiredFieldValidator></td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>

                            <tr id="trarchitecdwg" runat="server" visible="false">
                                <td align="center" colspan="3"
                                    style="padding: 5px; margin: 5px; text-align: center;">&nbsp;
                                    <table>
                                        <tr  id="TRPLANPDF" runat="server"  visible="false" >
                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="middle">&nbsp;</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">Plan PDF</td>
                                            <td style="padding: 5px; margin: 5px">&nbsp;</td>
                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:HyperLink ID="HypPlan" runat="server" CssClass="LBLBLACK"
                                                    Target="_blank" Text="Plan PDF"></asp:HyperLink>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;" valign="top">&nbsp;</td>
                                        </tr>
                                        <tr  id="TRSECURITYREPORT" runat="server" visible="false">
                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="middle">&nbsp;</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">Scrutiny Report</td>
                                            <td style="padding: 5px; margin: 5px">&nbsp;</td>
                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:HyperLink ID="HypScrutiny" runat="server" CssClass="LBLBLACK"
                                                    Target="_blank" Text="Scrutiny Report"></asp:HyperLink>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;" valign="top">&nbsp;</td>
                                        </tr>
                                          <tr  id="TRDWG" runat="server" visible="false">
                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="middle">&nbsp;</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">Architectural dwg. in Pre-DCR</td>
                                            <td style="padding: 5px; margin: 5px">&nbsp;</td>
                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:HyperLink ID="HypDWG" runat="server" CssClass="LBLBLACK"
                                                    Target="_blank" Text="Architectural dwg. in Pre-DCR"></asp:HyperLink>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;" valign="top">&nbsp;</td>
                                        </tr>
                                        <tr  id="TRPREDCR" runat="server" >
                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="middle">1&nbsp;</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label5" runat="server" CssClass="LBLBLACK" Width="410px">Architectural dwg. in Pre-DCR</asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:FileUpload ID="FileUpload5" Width="300px" runat="server" class="form-control txtbox"
                                                    Height="28px" />
                                                <asp:HyperLink ID="HyperLink1" runat="server" CssClass="LBLBLACK"
                                                    Target="_blank"></asp:HyperLink>
                                                <br />
                                                <asp:Label ID="Label6" runat="server" Visible="False"></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;" valign="top">
                                                <asp:Button ID="Button4" runat="server" CssClass="btn btn-xs btn-warning"
                                                    Height="28px" TabIndex="10" Text="Upload"
                                                    Width="72px" OnClick="Button4_Click" />
                                            </td>
                                            </tr>
                                            <%--//Added by sridhar--%>
                                            <tr>
                                                <td style="padding: 5px; margin: 5px; text-align: left;" valign="middle">2&nbsp;</td>
                                                <td style="padding: 5px; margin: 5px; text-align: left;">
                                                    <asp:Label ID="Label7" runat="server" CssClass="LBLBLACK" Width="410px">Common Affidavit
                                                <a href="viewpdf.aspx?filepathnew=D:/TS-iPASSFinal/UI/TSiPASS/DisplayDocs/CommonAffidavitUndertaking.pdf" target="_blank">Common Affidavit Form</a>
                                                    </asp:Label>

                                                </td>
                                                <td style="padding: 5px; margin: 5px">:</td>
                                                <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                    <asp:FileUpload ID="FileUpload1" Width="300px" runat="server" class="form-control txtbox"
                                                        Height="28px" />
                                                    <asp:HyperLink ID="HyperLink2" runat="server" CssClass="LBLBLACK"
                                                        Target="_blank"></asp:HyperLink>
                                                    <br />
                                                    <asp:Label ID="Label8" runat="server" Visible="False"></asp:Label>
                                                </td>
                                                <td style="padding: 5px; margin: 5px; width: 10px;" valign="top">
                                                    <asp:Button ID="btnCommonAffidavit" runat="server" CssClass="btn btn-xs btn-warning"
                                                        Height="28px" TabIndex="10" Text="Upload" OnClick="btnCommonAffidavit_Click"
                                                        Width="72px" />
                                                </td>
                                            </tr>

                                            <tr id="trNOC" runat="server" visible="false">
                                                <td style="padding: 5px; margin: 5px; text-align: left;" valign="middle">3&nbsp;</td>
                                                <td style="padding: 5px; margin: 5px; text-align: left;">
                                                    <asp:Label ID="Label9" runat="server" CssClass="LBLBLACK" Width="410px">Fire NOC</asp:Label>
                                                </td>
                                                <td style="padding: 5px; margin: 5px">:</td>
                                                <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                    <asp:FileUpload ID="FileUpload2" Width="300px" runat="server" class="form-control txtbox"
                                                        Height="28px" />
                                                    <asp:HyperLink ID="HyperLink3" runat="server" CssClass="LBLBLACK"
                                                        Target="_blank"></asp:HyperLink>
                                                    <br />
                                                    <asp:Label ID="Label10" runat="server" Visible="False"></asp:Label>
                                                </td>
                                                <td style="padding: 5px; margin: 5px; width: 10px;" valign="top">
                                                    <asp:Button ID="btnNOC" runat="server" CssClass="btn btn-xs btn-warning"
                                                        Height="28px" TabIndex="10" Text="Upload" OnClick="btnNOC_Click"
                                                        Width="72px" />
                                                </td>
                                            </tr>

                                        </tr>
                                    </table>

                                </td>
                            </tr>
                            <tr>
                                <td align="center" colspan="3"
                                    style="padding: 5px; margin: 5px; text-align: center;">&nbsp;
                                    <table>
                                        <tr id="CLUTable" runat="server" visible="false">
                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="middle">&nbsp;</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label11" runat="server" CssClass="LBLBLACK" Width="410px">SELF CERTIFICATION FOR CHANGE OF LAND USE<font 
                                color="red">*</font></asp:Label>
                                                <br />
                                                <asp:Label ID="Label13" runat="server" CssClass="LBLBLACK" Width="410px">
                                                <a href="DisplayDocs/clu proforma.docx" target="_blank">Proforma</a>
                                                </asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:FileUpload ID="FileUpload3" Width="300px" runat="server" class="form-control txtbox"
                                                    Height="28px" />
                                                <asp:HyperLink ID="HyperLink4" runat="server" CssClass="LBLBLACK"
                                                    Target="_blank"></asp:HyperLink>
                                                <br />
                                                <asp:Label ID="Label12" runat="server" Visible="False"></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;" valign="top">
                                                <asp:Button ID="Button1" runat="server" CssClass="btn btn-xs btn-warning"
                                                    Height="28px" TabIndex="10" Text="Upload" OnClick="Button1_Click"
                                                    Width="72px" />
                                            </td>
                                        </tr>
                                    </table>

                                </td>
                            </tr>
                            <%--<tr>
                                <td align="center" colspan="3"
                                    style="padding: 5px; margin: 5px; text-align: center;">&nbsp;</td>
                            </tr>--%>

                            <tr>
                                <td align="center" colspan="3"
                                    style="padding: 5px; margin: 5px; text-align: center;">
                                    <asp:Button ID="BtnClear" runat="server" CausesValidation="False"
                                        CssClass="btn btn-warning" Height="32px" OnClick="BtnClear_Click" TabIndex="10"
                                        Text="ClearAll" ToolTip="To Clear  the Screen" Width="90px" />
                                    &nbsp;
                                    <asp:Button ID="BtnSave1" runat="server" CssClass="btn btn-primary"
                                        Height="32px" OnClick="BtnSave_Click" TabIndex="10" Text="Save"
                                        ValidationGroup="group" Width="90px" />
                                    &nbsp;<asp:Button ID="BtnDelete0" runat="server"
                                        CssClass="btn btn-danger" Height="32px" OnClick="BtnDelete0_Click" TabIndex="10"
                                        Text="previous" Width="90px" />
                                    &nbsp;&nbsp;<asp:Button ID="BtnDelete" runat="server"
                                        CssClass="btn btn-danger" Height="32px" OnClick="BtnClear0_Click" TabIndex="10"
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
                                                <asp:HiddenField ID="HDNAPPRVALID2" runat="server" />
                                                <asp:HiddenField ID="HDNAPPROVALID" runat="server" />
                                                <asp:HiddenField ID="HDNAPPLSTATUS" runat="server" />
                        <asp:HiddenField ID="HDNDTCP_MUNCIPALFLAG" runat="server" />
                        <asp:HiddenField ID="HDNISPAYMENT" runat="server" />
                        <asp:HiddenField ID="HDNISOFLINE" runat="server" />
                        <asp:HiddenField ID="hdnstageid" runat="server" />

                    </div>

                </div>
            </div>
        </div>

    </div>

</asp:Content>
