<%@ Page Title="" Language="C#" MasterPageFile="~/UI/TSiPASS/CCMaster.master" AutoEventWireup="true" CodeFile="frmCAFSteamPipeline.aspx.cs" Inherits="UI_TSiPASS_frmCAFSteamPipeline" %>

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
    <script type="text/javascript" language="javascript">
        function DecimalOnly() {
            var AsciiValue = event.keyCode
            if ((AsciiValue >= 48 && AsciiValue <= 57) || (AsciiValue == 8 || AsciiValue == 127) || AsciiValue == 46)
                event.returnValue = true;
            else {
                event.returnValue = false;
                alert("Enter DecimalValues Only");
            }
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
                        <h3 class="panel-title">SteamPipeline Details</h3>
                    </div>
                    <%-- <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>--%>
                    <div class="panel-body">
                        <table align="center" cellpadding="10" cellspacing="5" style="width: 90%">

                            <tr>
                                <td style="padding: 5px; margin: 5px" valign="top" align="left">
                                    <asp:label id="Label461" runat="server" cssclass="LBLBLACK" font-bold="True"
                                        width="450px">Please fill this part if Registration of Boilers is required</asp:label>
                                </td>
                                <td style="width: 27px">&nbsp;</td>
                                <td valign="top">&nbsp;</td>
                            </tr>
                            <tr>
                                <td align="left" style="padding: 5px; margin: 5px" valign="top">
                                    <table cellpadding="4" cellspacing="5" style="width: 83%">

                                        <tr>
                                            <td style="padding: 5px; margin: 5px">1</td>
                                            <td class="style12" style="padding: 5px; margin: 5px">
                                                <asp:label id="Label447" runat="server" cssclass="LBLBLACK" width="200px">Maker&#39;s/Registration Number</asp:label>
                                            </td>
                                            <td class="style13" style="padding: 5px; margin: 5px">:</td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:textbox id="txtMakersNumber" runat="server" class="form-control txtbox"
                                                    height="28px" maxlength="40" tabindex="1"
                                                    validationgroup="group" width="180px"></asp:textbox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:requiredfieldvalidator id="RequiredFieldValidator7" runat="server"
                                                    controltovalidate="txtMakersNumber" errormessage="Please Enter Maker's Number"
                                                    validationgroup="group">*</asp:requiredfieldvalidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px">2</td>
                                            <td class="style12" style="padding: 5px; margin: 5px">
                                                <asp:label id="Label449" runat="server" cssclass="LBLBLACK" width="200px">Boiler Used for</asp:label>
                                            </td>
                                            <td class="style13" style="padding: 5px; margin: 5px">:</td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:dropdownlist id="ddlBoilersUsedfor" runat="server" class="form-control txtbox" height="33px" tabindex="1" width="180px">
                                                    <asp:ListItem>--Select--</asp:ListItem>
                                                    <asp:ListItem Value="1">Process</asp:ListItem>
                                                    <asp:ListItem Value="2">Cogeneration</asp:ListItem>
                                                    <asp:ListItem Value="3">Power</asp:ListItem>
                                                </asp:dropdownlist>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:requiredfieldvalidator id="RequiredFieldValidator9" runat="server"
                                                    controltovalidate="ddlBoilersUsedfor"
                                                    errormessage="Please Select Boiler Used For" initialvalue="--Select--"
                                                    validationgroup="group">*</asp:requiredfieldvalidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px">3</td>
                                            <td class="style12" style="padding: 5px; margin: 5px">
                                                <asp:label id="Label450" runat="server" cssclass="LBLBLACK" width="200px">Boiler Rating/Heating Surface</asp:label>
                                            </td>
                                            <td class="style13" style="padding: 5px; margin: 5px">:</td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:textbox id="txtBoilerRatingSurface" runat="server" class="form-control txtbox"
                                                    height="28px" maxlength="40" onkeypress="NumberOnly()" tabindex="1"
                                                    validationgroup="group" width="180px"></asp:textbox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">sqm<asp:requiredfieldvalidator id="RequiredFieldValidator10" runat="server"
                                                controltovalidate="txtBoilerRatingSurface"
                                                errormessage="Please Enter Boilers Rating/Heating Surface"
                                                validationgroup="group">*</asp:requiredfieldvalidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px">&nbsp;</td>
                                            <td class="style12" style="padding: 5px; margin: 5px">
                                                <asp:label id="Label500" runat="server" cssclass="LBLBLACK" width="200px">Allowed Maximum Pressure</asp:label>
                                            </td>
                                            <td class="style13" style="padding: 5px; margin: 5px">&nbsp;</td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:textbox id="txtAllowedMaximumPresure" runat="server" class="form-control txtbox"
                                                    height="28px" maxlength="40" onkeypress="NumberOnly()" tabindex="1"
                                                    validationgroup="group" width="180px"></asp:textbox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px"><asp:requiredfieldvalidator id="RequiredFieldValidator3" runat="server"
                                                controltovalidate="txtAllowedMaximumPresure"
                                                errormessage="Please Enter Allowed Maximum Pressure"
                                                validationgroup="group">*</asp:requiredfieldvalidator></td>
                                        </tr>
                                        </table>
                                </td>
                                <td style="width: 27px">&nbsp;</td>
                                <td valign="top">
                                    <table cellpadding="4" cellspacing="5" style="width: 83%">
                                        <tr>
                                            <td style="padding: 5px; margin: 5px">4</td>
                                            <td class="style12" style="padding: 5px; margin: 5px">
                                                <asp:label id="Label508" runat="server" cssclass="LBLBLACK" width="200px">Total Length of Steam PipeLine</asp:label>
                                            </td>
                                            <td class="style13" style="padding: 5px; margin: 5px">:</td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:textbox id="txtlenupto" runat="server" class="form-control txtbox" onkeypress="DecimalOnly()"
                                                    height="28px" maxlength="40" tabindex="1"
                                                    validationgroup="group" width="180px" OnTextChanged="txtlenupto_TextChanged" AutoPostBack="true" Text="0"></asp:textbox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">UPTO 100 MM<asp:requiredfieldvalidator id="RequiredFieldValidator13" runat="server"
                                                controltovalidate="txtlenupto"
                                                errormessage="Please Enter Lengthofsteampipeline UPTO 100 MM" validationgroup="group">*</asp:requiredfieldvalidator>
                                            </td>
                                        </tr>

                                        <tr>
                                            <td style="padding: 5px; margin: 5px">&nbsp;</td>
                                            <td class="style12" style="padding: 5px; margin: 5px">
                                                &nbsp;</td>
                                            <td class="style13" style="padding: 5px; margin: 5px">&nbsp;</td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:textbox id="txtlenabove" runat="server" class="form-control txtbox" onkeypress="DecimalOnly()"
                                                    height="28px" maxlength="40" tabindex="1"
                                                    validationgroup="group" width="180px" OnTextChanged="txtlenabove_TextChanged" AutoPostBack="true" Text="0"></asp:textbox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">ABOVE 100 MM<asp:requiredfieldvalidator id="RequiredFieldValidator2" runat="server"
                                                controltovalidate="txtlenabove"
                                                errormessage="Please Enter Lengthofsteampipeline ABOVE 100 MM" validationgroup="group">*</asp:requiredfieldvalidator>
                                            </td>
                                        </tr>

                                        <tr>
                                            <td style="padding: 5px; margin: 5px">&nbsp;</td>
                                            <td class="style12" style="padding: 5px; margin: 5px">
                                                &nbsp;</td>
                                            <td class="style13" style="padding: 5px; margin: 5px">&nbsp;</td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:textbox id="txtTotalLengthOfStreamPipeLine" runat="server" class="form-control txtbox"
                                                    height="28px" maxlength="40" onkeypress="NumberOnly()" tabindex="1"
                                                    validationgroup="group" width="180px"></asp:textbox>
                                            </td>
                                           <%-- <td style="padding: 5px; margin: 5px">Mts<asp:requiredfieldvalidator id="RequiredFieldValidator3" runat="server"
                                                controltovalidate="txtTotalLengthOfStreamPipeLine"
                                                errormessage="Please Enter Lengthofsteampipeline ABOVE 100 MM" validationgroup="group">*</asp:requiredfieldvalidator>
                                            </td>--%>
                                        </tr>

                                        <tr>
                                            <td style="padding: 5px; margin: 5px">5</td>
                                            <td class="style12" style="padding: 5px; margin: 5px">
                                                <asp:label id="Label502" runat="server" cssclass="LBLBLACK" width="200px">Number of Vessels Connected in Steam Pipe Line</asp:label>
                                            </td>
                                            <td class="style13" style="padding: 5px; margin: 5px">:</td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:textbox id="txtnoofvessels" runat="server" class="form-control txtbox"
                                                    height="28px" maxlength="40" tabindex="1" onkeypress="NumberOnly()"
                                                    validationgroup="group" width="180px"></asp:textbox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <%--<asp:requiredfieldvalidator id="RequiredFieldValidator15" runat="server"
                                                    controltovalidate="txtnoofvessels"
                                                    errormessage="Please Enter Number of Vessels" validationgroup="group">*</asp:requiredfieldvalidator>--%>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px">6</td>
                                            <td class="style12" style="padding: 5px; margin: 5px">
                                                <asp:label id="Label503" runat="server" cssclass="LBLBLACK" font-bold="True"
                                                    width="200px">Details of Boiler Erector</asp:label>
                                            </td>
                                            <td class="style13" style="padding: 5px; margin: 5px">&nbsp;</td>
                                            <td style="padding: 5px; margin: 5px">&nbsp;</td>
                                            <td style="padding: 5px; margin: 5px">&nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px">&nbsp;</td>
                                            <td class="style12" style="padding: 5px; margin: 5px">
                                                <asp:label id="Label2" runat="server" cssclass="LBLBLACK" width="200px">Class of Erector</asp:label>
                                            </td>
                                            <td class="style13" style="padding: 5px; margin: 5px">:</td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:dropdownlist id="ddlerectorclass" runat="server" class="form-control txtbox"
                                                    height="33px" width="180px" tabindex="1">
                                                    <asp:ListItem>--Select--</asp:ListItem>
                                                    <asp:ListItem Value="1">SPECIAL CLASS</asp:ListItem>
                                                    <asp:ListItem Value="2">CLASS I</asp:ListItem>
                                                    <asp:ListItem Value="3">CLASS II</asp:ListItem>
                                                    <asp:ListItem Value="4">CLASS III</asp:ListItem>
                                                </asp:dropdownlist>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:requiredfieldvalidator id="RequiredFieldValidator1" runat="server"
                                                    controltovalidate="ddlerectorclass" errormessage="Please Select Class of Erector"
                                                    initialvalue="--Select--" validationgroup="group">*</asp:requiredfieldvalidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px">&nbsp;</td>
                                            <td class="style12" style="padding: 5px; margin: 5px">
                                                <asp:label id="Label505" runat="server" cssclass="LBLBLACK" width="200px">Name of Erector</asp:label>
                                            </td>
                                            <td class="style13" style="padding: 5px; margin: 5px">:</td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:textbox id="txtNameOfErector" runat="server" class="form-control txtbox"
                                                    height="28px" maxlength="200" tabindex="1"
                                                    validationgroup="group" width="180px"></asp:textbox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:requiredfieldvalidator id="RequiredFieldValidator17" runat="server"
                                                    controltovalidate="txtNameOfErector"
                                                    errormessage="Please Enter Name of Erector" validationgroup="group">*</asp:requiredfieldvalidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px">&nbsp;</td>
                                            <td class="style12" style="padding: 5px; margin: 5px">
                                                <asp:label id="Label506" runat="server" cssclass="LBLBLACK" width="200px">State</asp:label>
                                            </td>
                                            <td class="style13" style="padding: 5px; margin: 5px">:</td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:dropdownlist id="ddlState" runat="server" class="form-control txtbox"
                                                    height="33px" onselectedindexchanged="ddlstatus28_SelectedIndexChanged"
                                                    width="180px" tabindex="1">
                                                    <asp:ListItem>--Select--</asp:ListItem>
                                                </asp:dropdownlist>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:requiredfieldvalidator id="RequiredFieldValidator18" runat="server"
                                                    controltovalidate="ddlState" errormessage="Please Select District"
                                                    initialvalue="--Select--" validationgroup="group">*</asp:requiredfieldvalidator>
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
                                                <asp:Label ID="Label1" runat="server" CssClass="LBLBLACK" Width="210px">Upload Erector License Copy<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:FileUpload ID="FileUploadErector" runat="server" class="form-control txtbox"
                                                    Height="28px" />

                                                <asp:HyperLink ID="HyperLinkErector" runat="server" CssClass="LBLBLACK" Width="165px"
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
                                        <tr runat="server" id="trsteampipeline" visible="true">
                                            <td style="padding: 5px; margin: 5px; text-align: left;">2&nbsp;</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:label id="Label387" runat="server" cssclass="LBLBLACK" width="210px">Upload Steam Pipe Line Layout Drawing<font 
                                                            color="red">*</font></asp:label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:fileupload id="FileUploadSteam" runat="server" class="form-control txtbox"
                                                    height="28px" />

                                                <asp:hyperlink id="HyperLinksteamdrawing" runat="server" cssclass="LBLBLACK" width="165px"
                                                    target="_blank">[lblFileNameSteam]</asp:hyperlink>
                                                <br />
                                                <asp:label id="LabelSteam" runat="server" visible="False"></asp:label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                <asp:button id="BtnSteam" runat="server" cssclass="btn btn-xs btn-warning"
                                                    height="28px" tabindex="10" text="Upload"
                                                    width="72px" OnClick="BtnSteam_Click"/>
                                            </td>
                                        </tr>
                                        <tr runat="server" id="trreqdoc" visible="true">
                                            <td style="padding: 5px; margin: 5px; text-align: left;">3</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:label id="Label7" runat="server" cssclass="LBLBLACK" width="210px">Required Documents(Form IIIA/IIIB/IIIC of pipes,values & fittings)<font 
                                                            color="red">*</font></asp:label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:fileupload id="FileUploadRequiredDoc" runat="server" class="form-control txtbox"
                                                    height="28px" />

                                                <asp:hyperlink id="HyperLinkRequiredDoc" runat="server" cssclass="LBLBLACK" width="165px"
                                                    target="_blank">[lblFileNameRequiredDoc]</asp:hyperlink>
                                                <br />
                                                <asp:label id="LabelRequiredDoc" runat="server" visible="False"></asp:label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                <asp:button id="btnreqdoc" runat="server" cssclass="btn btn-xs btn-warning"
                                                    height="28px" tabindex="10" text="Upload"
                                                    width="72px" onclick="btnreqdoc_Click" />
                                            </td>
                                        </tr>
                                        
                                    </table>
                                </td>

                            </tr>
                            <tr>
                                <td align="center" colspan="3"
                                    style="padding: 5px; margin: 5px; text-align: center;">
                                    <asp:button id="BtnSave1" runat="server" cssclass="btn btn-primary"
                                        height="32px" onclick="BtnSave_Click" tabindex="10" text="Save"
                                        validationgroup="group" width="90px" />
                                    &nbsp;&nbsp;<asp:button id="BtnDelete" runat="server"
                                        cssclass="btn btn-danger" height="32px" onclick="BtnClear0_Click" tabindex="10"
                                        text="Next" width="90px"
                                        validationgroup="group" />
                                    &nbsp;<asp:button id="BtnDelete0" runat="server" causesvalidation="False"
                                        cssclass="btn btn-danger" height="32px" onclick="BtnDelete0_Click"
                                        tabindex="10" text="Previous" width="90px" />
                                    &nbsp;&nbsp;<asp:button id="BtnClear" runat="server" causesvalidation="False"
                                        cssclass="btn btn-warning" height="32px" onclick="BtnClear_Click" tabindex="10"
                                        text="ClearAll" tooltip="To Clear  the Screen" width="90px" />
                                </td>
                            </tr>
                            <tr>
                                <td align="center" colspan="3" style="padding: 5px; margin: 5px">


                                    <div id="success" runat="server" visible="false" class="alert alert-success">
                                        <a href="AddQualification.aspx" class="close" data-dismiss="alert" aria-label="close">&times;</a>
                                        <strong>Success!</strong><asp:label id="lblmsg" runat="server"></asp:label>
                                    </div>


                                    <div id="Failure" runat="server" visible="false" class="alert alert-danger">
                                        <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a>
                                        <strong>Warning!</strong>
                                        <asp:label id="lblmsg0" runat="server"></asp:label>
                                    </div>
                                </td>
                            </tr>
                        </table>
                        <asp:hiddenfield id="hdfID" runat="server" />
                        <asp:validationsummary id="ValidationSummary1" runat="server"
                            showmessagebox="True" showsummary="False" validationgroup="group" />
                        <asp:validationsummary id="ValidationSummary2" runat="server"
                            showmessagebox="True" showsummary="False" validationgroup="child" />
                        <asp:hiddenfield id="hdfFlagID" runat="server" />
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

