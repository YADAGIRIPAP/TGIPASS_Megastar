<%@ Page Title=":: TS-iPASS ::  " Language="C#" MasterPageFile="~/UI/TSiPASS/CCMaster.master"
    AutoEventWireup="true" CodeFile="frmCAFAttachmentDetails.aspx.cs" Inherits="TSTBDCReg1" %>

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
                                                    <asp:Label ID="Label422" runat="server" CssClass="LBLBLACK" Font-Bold="True" Width="210px">Common Attachments<font 
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
                                                        <tr id="trfire" runat="server" visible="false">
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                1
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:Label ID="Label434" runat="server" CssClass="LBLBLACK" Width="165px">Fire Occupancy Certificate</asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                :
                                                            </td>
                                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:FileUpload ID="FileUpload4" runat="server" class="form-control txtbox" Height="48px" />
                                                                <asp:HyperLink ID="Label3" runat="server" CssClass="LBLBLACK" Width="165px"></asp:HyperLink>
                                                                <br />
                                                                <asp:Label ID="Label456" runat="server" Visible="False"></asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                                <asp:Button ID="BtnFileCert" runat="server" CssClass="btn btn-xs btn-warning" Height="28px"
                                                                    OnClick="BtnFileCert_Click" TabIndex="10" Text="Upload" ValidationGroup="group"
                                                                    Width="72px" />
                                                            </td>
                                                        </tr>
                                                        <tr id="trlistofdirectors" runat="server" visible="false">
                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="middle">
                                                                2
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:Label ID="Label446" runat="server" CssClass="LBLBLACK" Width="165px">List Of Directors</asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                :
                                                            </td>
                                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:FileUpload ID="FileUpload11" runat="server" class="form-control txtbox" Height="48px" />
                                                                <asp:HyperLink ID="Label450" runat="server" CssClass="LBLBLACK" Width="165px"></asp:HyperLink>
                                                                <br />
                                                                <asp:Label ID="Label461" runat="server" Visible="False"></asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                                <asp:Button ID="BtnListofDir" runat="server" CssClass="btn btn-xs btn-warning" Height="28px"
                                                                    OnClick="BtnListofDir_Click" TabIndex="10" Text="Upload" ValidationGroup="group"
                                                                    Width="72px" />
                                                            </td>
                                                        </tr>
                                                         <tr runat="server" id="trProcessFlowChart">
                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="middle">
                                                                1
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:Label ID="Label465" runat="server" CssClass="LBLBLACK" Width="165px">Process Flow Chart</asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                :
                                                            </td>
                                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:FileUpload ID="FileUpload14" runat="server" class="form-control txtbox" Height="48px" />
                                                                <asp:HyperLink ID="Label466" runat="server" CssClass="LBLBLACK" Width="165px"></asp:HyperLink>
                                                                <br />
                                                                <asp:Label ID="Label467" runat="server" Visible="False"></asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                                <asp:Button ID="BtnListofDir0" runat="server" CssClass="btn btn-xs btn-warning" Height="28px"
                                                                    OnClick="BtnListofDir0_Click" TabIndex="10" Text="Upload" ValidationGroup="group"
                                                                    Width="72px" />
                                                            </td>
                                                        </tr>
                                                        <tr id="trPlanLayout" runat="server" visible="false">
                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="middle">
                                                                4
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:Label ID="Label468" runat="server" CssClass="LBLBLACK" Width="165px">Plant layout</asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                &nbsp;
                                                            </td>
                                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:FileUpload ID="FileUpload15" runat="server" class="form-control txtbox" Height="48px" />
                                                                <asp:HyperLink ID="Label469" runat="server" CssClass="LBLBLACK" Width="165px"></asp:HyperLink>
                                                                <br />
                                                                <asp:Label ID="Label470" runat="server" Visible="False"></asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                                <asp:Button ID="BtnListofDir1" runat="server" CssClass="btn btn-xs btn-warning" Height="28px"
                                                                    OnClick="BtnListofDir1_Click" TabIndex="10" Text="Upload" ValidationGroup="group"
                                                                    Width="72px" />
                                                            </td>
                                                        </tr>
                                                        <tr id="trpartnershipdeed" runat="server" visible="false">
                                                            <td class="style8" style="padding: 5px; margin: 5px; text-align: left;">
                                                                5
                                                            </td>
                                                            <td class="style8" style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:Label ID="Label445" runat="server" CssClass="LBLBLACK" Width="165px">Partnership deed</asp:Label>
                                                            </td>
                                                            <td class="style8" style="padding: 5px; margin: 5px">
                                                                :
                                                            </td>
                                                            <td class="style9" style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:FileUpload ID="FileUpload10" runat="server" class="form-control txtbox" Height="48px" />
                                                                <asp:HyperLink ID="Label449" runat="server" CssClass="LBLBLACK" Width="165px"></asp:HyperLink>
                                                                <br />
                                                                <asp:Label ID="Label460" runat="server" Visible="False"></asp:Label>
                                                                <br />
                                                            </td>
                                                            <td class="style10" style="padding: 5px; margin: 5px;">
                                                                <asp:Button ID="BtnPartDeed" runat="server" CssClass="btn btn-xs btn-warning" Height="28px"
                                                                    TabIndex="10" Text="Upload" ValidationGroup="group" Width="72px" OnClick="BtnPartDeed_Click" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                   <asp:Label ID="lblNumber2" runat="server" Text="2"></asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:Label ID="Label447" runat="server" CssClass="LBLBLACK" Width="165px">PAN/AADHAR Card</asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                :
                                                            </td>
                                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:FileUpload ID="FileUpload12" runat="server" class="form-control txtbox" Height="48px" />
                                                                <asp:HyperLink ID="Label451" runat="server" CssClass="LBLBLACK" Width="165px"></asp:HyperLink>
                                                                <br />
                                                                <asp:Label ID="Label462" runat="server" Visible="False"></asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                                <asp:Button ID="BtnPan" runat="server" CssClass="btn btn-xs btn-warning" Height="28px"
                                                                    TabIndex="10" Text="Upload" ValidationGroup="group" Width="72px" OnClick="BtnPan_Click" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                   <asp:Label ID="Label1" runat="server" Text="3"></asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:Label ID="Label2" runat="server" CssClass="LBLBLACK" Width="165px">DEET Registration Acknowledgement</asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                :
                                                            </td>
                                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:FileUpload ID="fupdeetregack" runat="server" class="form-control txtbox" Height="48px" />
                                                                <asp:HyperLink ID="hypdeetregack" runat="server" CssClass="LBLBLACK" Width="165px"></asp:HyperLink>
                                                                <br />
                                                                <asp:Label ID="lbldeetregack" runat="server" Visible="False"></asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                                <asp:Button ID="btndeetregack" runat="server" CssClass="btn btn-xs btn-warning" Height="28px"
                                                                    TabIndex="10" Text="Upload" ValidationGroup="group" Width="72px" OnClick="btndeetregack_Click" />
                                                            </td>
                                                        </tr>
                                                        <tr id="trlandowner" runat="server" visible="false">
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                3
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:Label ID="Label448" runat="server" CssClass="LBLBLACK" Width="165px">Land OwnerShip Deed</asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                :
                                                            </td>
                                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:FileUpload ID="FileUpload13" runat="server" class="form-control txtbox" Height="48px" />
                                                                <asp:HyperLink ID="Label452" runat="server" CssClass="LBLBLACK" Width="165px"></asp:HyperLink>
                                                                <br />
                                                                <asp:Label ID="Label463" runat="server" Visible="False"></asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                                <asp:Button ID="BtnLandDeed" runat="server" CssClass="btn btn-xs btn-warning" Height="28px"
                                                                    TabIndex="10" Text="Upload" ValidationGroup="group" Width="72px" OnClick="BtnLandDeed_Click" />
                                                            </td>
                                                        </tr>
                                                         <tr>
                                                            <td colspan="6" style="width:100%"><asp:hyperlink id="Hyperlink1" runat="server" visible="true"
cssclass="LBLRED" width="100%" target="_blank" navigateurl="https://deet.telangana.gov.in/">
Please click here to register in DEET (It is mandatory to register in DEET portal and upload registerred acknowledgement in attachment check slip) <span class="detail-gif" data-balloon-length="large"
             data-balloon-pos="right">&nbsp;&nbsp;&nbsp;
        <img alt="" width="40px" height="20px" src="../../images/animated-hand-image-0117.gif" /></span></asp:hyperlink><span style="color:red">(For Technical Assistance, Please call: +91 9281423576 (Dr. M.Chandrashekar, Additional Program Director))</span></td>
                                                           
                                                        </tr>
                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="middle">
                                                                &nbsp;
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:Label ID="Label464" runat="server" CssClass="LBLBLACK" Font-Bold="True" Width="451px">Additional Attachments(If Required not mandatory)<font 
                                                            color="red"></font></asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                &nbsp;
                                                            </td>
                                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                                &nbsp;
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                                &nbsp;
                                                            </td>
                                                        </tr>
                                                       <tr runat="server" id="trBoilerRegistration">
                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="middle">
                                                                8
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:Label ID="Label436" runat="server" CssClass="LBLBLACK" Width="410px">Boiler Registration</asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                :
                                                            </td>
                                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:FileUpload ID="FileUpload6" runat="server" class="form-control txtbox" Height="48px" />
                                                                <asp:HyperLink ID="lblFileName0" runat="server" CssClass="LBLBLACK" Width="165px"></asp:HyperLink>
                                                                <br />
                                                                <asp:Label ID="Label457" runat="server" Visible="False"></asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                                <asp:Button ID="BtnBoilerReg" runat="server" CssClass="btn btn-xs btn-warning" Height="28px"
                                                                    OnClick="BtnBoilerReg_Click" TabIndex="10" Text="Upload" ValidationGroup="group"
                                                                    Width="72px" />
                                                            </td>
                                                        </tr>
                                                        <tr runat="server" id="trDrugsLicense">
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                9
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:Label ID="Label437" runat="server" CssClass="LBLBLACK" Width="210px">Drugs License</asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                :
                                                            </td>
                                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:FileUpload ID="FileUpload7" runat="server" class="form-control txtbox" Height="48px" />
                                                                <asp:HyperLink ID="Label438" runat="server" CssClass="LBLBLACK" Width="165px"></asp:HyperLink>
                                                                <br />
                                                                <asp:Label ID="Label458" runat="server" Visible="False"></asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                                <asp:Button ID="BtnDrug" runat="server" CssClass="btn btn-xs btn-warning" Height="28px"
                                                                    TabIndex="10" Text="Upload" ValidationGroup="group" Width="72px" OnClick="BtnDrug_Click" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                10
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:Label ID="Label439" runat="server" CssClass="LBLBLACK" Width="165px">Electrical Drawing Approvals</asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                :
                                                            </td>
                                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:FileUpload ID="FileUpload8" runat="server" class="form-control txtbox" Height="48px" />
                                                                <asp:HyperLink ID="Label440" runat="server" CssClass="LBLBLACK" Width="165px"></asp:HyperLink>
                                                                <br />
                                                                <asp:Label ID="Label459" runat="server" Visible="False"></asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                                <asp:Button ID="BtnElecDraw" runat="server" CssClass="btn btn-xs btn-warning" Height="28px"
                                                                    TabIndex="10" Text="Upload" ValidationGroup="group" Width="72px" OnClick="BtnElecDraw_Click" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <caption>
                                                &nbsp;</caption>
                                            <tr>
                                                <td align="center" style="padding: 5px; margin: 5px; text-align: center;">
                                                    <asp:Button ID="BtnSave1" runat="server" CssClass="btn btn-primary" Height="32px"
                                                        OnClick="BtnSave_Click" TabIndex="10" Text="Save" ValidationGroup="group" Width="90px" />
                                                    &nbsp;&nbsp;<asp:Button ID="BtnDelete" runat="server" CausesValidation="False" CssClass="btn btn-danger"
                                                        Height="32px" OnClick="BtnDelete_Click" TabIndex="10" Text="Next" Width="90px" />
                                                    &nbsp;<asp:Button ID="BtnDelete0" runat="server" CausesValidation="False" CssClass="btn btn-danger"
                                                        Height="32px" OnClick="BtnDelete0_Click" TabIndex="10" Text="Previous" Width="90px" />
                                                    &nbsp;<asp:Button ID="BtnClear" runat="server" CausesValidation="False" CssClass="btn btn-warning"
                                                        Height="32px" OnClick="BtnClear_Click" TabIndex="10" Text="ClearAll" ToolTip="To Clear  the Screen"
                                                        Width="90px" />
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
            <%-- <asp:PostBackTrigger ControlID="BtnSave3" />
<asp:PostBackTrigger ControlID="BtnB2Form"></asp:PostBackTrigger>
<asp:PostBackTrigger ControlID="BtnHazForm"></asp:PostBackTrigger>
<asp:PostBackTrigger ControlID="BtnCompRep"></asp:PostBackTrigger>--%>
            <asp:PostBackTrigger ControlID="BtnFileCert"></asp:PostBackTrigger>
            <asp:PostBackTrigger ControlID="BtnBoilerReg"></asp:PostBackTrigger>
            <asp:PostBackTrigger ControlID="BtnDrug"></asp:PostBackTrigger>
            <asp:PostBackTrigger ControlID="BtnElecDraw"></asp:PostBackTrigger>
            <asp:PostBackTrigger ControlID="BtnPartDeed"></asp:PostBackTrigger>
            <asp:PostBackTrigger ControlID="BtnListofDir"></asp:PostBackTrigger>
            <asp:PostBackTrigger ControlID="BtnListofDir0"></asp:PostBackTrigger>
            <asp:PostBackTrigger ControlID="BtnListofDir1"></asp:PostBackTrigger>
            <asp:PostBackTrigger ControlID="BtnPan"></asp:PostBackTrigger>
            <asp:PostBackTrigger ControlID="BtnLandDeed"></asp:PostBackTrigger>
            <asp:PostBackTrigger ControlID="btndeetregack"></asp:PostBackTrigger>
            <%--<asp:PostBackTrigger ControlID="BtnB2Form"></asp:PostBackTrigger>
<asp:PostBackTrigger ControlID="BtnHazForm"></asp:PostBackTrigger>
<asp:PostBackTrigger ControlID="BtnCompRep"></asp:PostBackTrigger>--%>
            <asp:PostBackTrigger ControlID="BtnFileCert"></asp:PostBackTrigger>
            <asp:PostBackTrigger ControlID="BtnBoilerReg"></asp:PostBackTrigger>
            <asp:PostBackTrigger ControlID="BtnDrug"></asp:PostBackTrigger>
            <asp:PostBackTrigger ControlID="BtnElecDraw"></asp:PostBackTrigger>
            <asp:PostBackTrigger ControlID="BtnPartDeed"></asp:PostBackTrigger>
            <asp:PostBackTrigger ControlID="BtnListofDir"></asp:PostBackTrigger>
            <asp:PostBackTrigger ControlID="BtnPan"></asp:PostBackTrigger>
            <asp:PostBackTrigger ControlID="BtnLandDeed"></asp:PostBackTrigger>
            <%--<asp:PostBackTrigger ControlID="BtnB2Form"></asp:PostBackTrigger>
<asp:PostBackTrigger ControlID="BtnHazForm"></asp:PostBackTrigger>
<asp:PostBackTrigger ControlID="BtnCompRep"></asp:PostBackTrigger>--%>
            <asp:PostBackTrigger ControlID="BtnFileCert"></asp:PostBackTrigger>
            <asp:PostBackTrigger ControlID="BtnBoilerReg"></asp:PostBackTrigger>
            <asp:PostBackTrigger ControlID="BtnDrug"></asp:PostBackTrigger>
            <asp:PostBackTrigger ControlID="BtnElecDraw"></asp:PostBackTrigger>
            <asp:PostBackTrigger ControlID="BtnPartDeed"></asp:PostBackTrigger>
            <asp:PostBackTrigger ControlID="BtnListofDir"></asp:PostBackTrigger>
            <asp:PostBackTrigger ControlID="BtnPan"></asp:PostBackTrigger>
            <asp:PostBackTrigger ControlID="BtnLandDeed"></asp:PostBackTrigger>
            <%--<asp:PostBackTrigger ControlID="BtnB2Form"></asp:PostBackTrigger>
            <asp:PostBackTrigger ControlID="BtnHazForm"></asp:PostBackTrigger>
            <asp:PostBackTrigger ControlID="BtnCompRep"></asp:PostBackTrigger>--%>
            <asp:PostBackTrigger ControlID="BtnFileCert"></asp:PostBackTrigger>
            <asp:PostBackTrigger ControlID="BtnBoilerReg"></asp:PostBackTrigger>
            <asp:PostBackTrigger ControlID="BtnDrug"></asp:PostBackTrigger>
            <asp:PostBackTrigger ControlID="BtnElecDraw"></asp:PostBackTrigger>
            <asp:PostBackTrigger ControlID="BtnPartDeed"></asp:PostBackTrigger>
            <asp:PostBackTrigger ControlID="BtnListofDir"></asp:PostBackTrigger>
            <asp:PostBackTrigger ControlID="BtnPan"></asp:PostBackTrigger>
            <asp:PostBackTrigger ControlID="BtnLandDeed"></asp:PostBackTrigger>
           <%-- <asp:PostBackTrigger ControlID="BtnB2Form"></asp:PostBackTrigger>
            <asp:PostBackTrigger ControlID="BtnHazForm"></asp:PostBackTrigger>
            <asp:PostBackTrigger ControlID="BtnCompRep"></asp:PostBackTrigger>--%>
            <asp:PostBackTrigger ControlID="BtnFileCert"></asp:PostBackTrigger>
            <asp:PostBackTrigger ControlID="BtnBoilerReg"></asp:PostBackTrigger>
            <asp:PostBackTrigger ControlID="BtnDrug"></asp:PostBackTrigger>
            <asp:PostBackTrigger ControlID="BtnElecDraw"></asp:PostBackTrigger>
            <asp:PostBackTrigger ControlID="BtnPartDeed"></asp:PostBackTrigger>
            <asp:PostBackTrigger ControlID="BtnListofDir"></asp:PostBackTrigger>
            <asp:PostBackTrigger ControlID="BtnPan"></asp:PostBackTrigger>
            <asp:PostBackTrigger ControlID="BtnLandDeed"></asp:PostBackTrigger>
            <%--<asp:PostBackTrigger ControlID="BtnB2Form"></asp:PostBackTrigger>
            <asp:PostBackTrigger ControlID="BtnHazForm"></asp:PostBackTrigger>
            <asp:PostBackTrigger ControlID="BtnCompRep"></asp:PostBackTrigger>--%>
            <asp:PostBackTrigger ControlID="BtnFileCert"></asp:PostBackTrigger>
            <asp:PostBackTrigger ControlID="BtnBoilerReg"></asp:PostBackTrigger>
            <asp:PostBackTrigger ControlID="BtnDrug"></asp:PostBackTrigger>
            <asp:PostBackTrigger ControlID="BtnElecDraw"></asp:PostBackTrigger>
            <asp:PostBackTrigger ControlID="BtnPartDeed"></asp:PostBackTrigger>
            <asp:PostBackTrigger ControlID="BtnListofDir"></asp:PostBackTrigger>
            <asp:PostBackTrigger ControlID="BtnPan"></asp:PostBackTrigger>
            <asp:PostBackTrigger ControlID="BtnLandDeed"></asp:PostBackTrigger>
        </Triggers>
        <Triggers>
            <%--<asp:PostBackTrigger ControlID="BtnB2Form" />
            <asp:PostBackTrigger ControlID="BtnHazForm" />
            <asp:PostBackTrigger ControlID="BtnCompRep" />--%>
            <asp:PostBackTrigger ControlID="BtnFileCert" />
            <asp:PostBackTrigger ControlID="BtnBoilerReg" />
            <asp:PostBackTrigger ControlID="BtnDrug" />
            <asp:PostBackTrigger ControlID="BtnElecDraw" />
            <asp:PostBackTrigger ControlID="BtnPartDeed" />
            <asp:PostBackTrigger ControlID="BtnListofDir" />
            <asp:PostBackTrigger ControlID="BtnListofDir0" />
            <asp:PostBackTrigger ControlID="BtnListofDir1" />
            <asp:PostBackTrigger ControlID="BtnPan" />
            <asp:PostBackTrigger ControlID="BtnLandDeed" />
        </Triggers>
    </asp:UpdatePanel>
    <%--</div>
       </td>
        </tr>
    </table>--%>
</asp:Content>
