<%@ Page Title="" Language="C#" MasterPageFile="~/UI/TSiPASS/CCMaster.master" AutoEventWireup="true" CodeFile="FRMMOBILETOWERTSROWATTACHMENTS.aspx.cs" Inherits="UI_TSiPASS_FRMMOBILETOWERTSROWATTACHMENTS" %>

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
        .LBLBLACK {}
        .auto-style1 {
            width: 212px;
        }
        .auto-style2 {
            width: 516px;
        }
        .auto-style3 {
            width: 48px;
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
    <%--<div align="left">
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
    </div>--%>

    <div align="left">
        <div class="row" align="left">
            <div class="col-lg-11">
                <div class="panel panel-primary">
                    <div class="panel-heading" align="center">
                        <h3 class="panel-title">Application for Issue of Permission for Establishment of Mobile Tower</h3>
                    </div>

                    <div class="panel-body">
                        <table align="center" cellpadding="10" cellspacing="5" style="width: 86%">

                            <tr >
                                <td style="padding: 5px; margin: 5px" valign="top">
                                    <asp:Label ID="Label22" runat="server" CssClass="LBLBLACK" Font-Bold="True"
                                        Width="521px">F. Upload Documents<font 
                                                            color="red">*</font></asp:Label>
                                </td>
                            </tr>
                            <asp:HiddenField ID="HDNMOBILETOWERID" runat="server" visible="true" />
                        <tr >
                            <td align="center"
                                style="padding: 5px; margin: 5px; text-align: center;">
                                    <table>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="middle">1&nbsp;</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label5" runat="server" CssClass="LBLBLACK" Width="410px">Agency Network/Infrastructure Provider Agreement<font 
                                color="red">*</font> </asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:FileUpload ID="fupagencynetwork" Width="300px" runat="server" class="form-control txtbox"
                                                    Height="28px" />
                                                <asp:HyperLink ID="Hypagencynetwork" runat="server" CssClass="LBLBLACK"
                                                    Target="_blank"></asp:HyperLink>
                                                <br />
                                                <asp:Label ID="lblagencynetwork" runat="server" visible="true"></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;" valign="top">
                                                <asp:Button ID="btnagencynetwork" runat="server" CssClass="btn btn-xs btn-warning"
                                                    Height="28px" TabIndex="10" Text="Upload"
                                                    Width="72px" OnClick="btnagencynetwork_Click" />
                                            </td>

                                            <%--//Added by sridhar--%>
                                            <tr>
                                                <td style="padding: 5px; margin: 5px; text-align: left;" valign="middle">2&nbsp;</td>
                                                <td style="padding: 5px; margin: 5px; text-align: left;">
                                                    <asp:Label ID="Label7" runat="server" CssClass="LBLBLACK" Width="410px">Property Tax Receipt<font 
                                color="red">*</font>
                                                
                                                    </asp:Label>

                                                </td>
                                                <td style="padding: 5px; margin: 5px">:</td>
                                                <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                    <asp:FileUpload ID="fuppropertytaxreceipt" Width="300px" runat="server" class="form-control txtbox"
                                                        Height="28px" />
                                                    <asp:HyperLink ID="Hyppropertytaxreceipt" runat="server" CssClass="LBLBLACK"
                                                        Target="_blank"></asp:HyperLink>
                                                    <br />
                                                    <asp:Label ID="lblpropertytaxreceipt" runat="server" visible="true"></asp:Label>
                                                </td>
                                                <td style="padding: 5px; margin: 5px; width: 10px;" valign="top">
                                                    <asp:Button ID="btnpropertytaxreceipt" runat="server" CssClass="btn btn-xs btn-warning"
                                                        Height="28px" TabIndex="10" Text="Upload" OnClick="btnpropertytaxreceipt_Click"
                                                        Width="72px" />
                                                </td>
                                            </tr>

                                            <tr id="trNOC" runat="server" visible="true">
                                                <td style="padding: 5px; margin: 5px; text-align: left;" valign="middle">3&nbsp;</td>
                                                <td style="padding: 5px; margin: 5px; text-align: left;">
                                                    <asp:Label ID="Label9" runat="server" CssClass="LBLBLACK" Width="410px">Structural Stability Certificate (SSC)<font 
                                color="red">*</font></asp:Label>
                                                </td>
                                                <td style="padding: 5px; margin: 5px">:</td>
                                                <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                    <asp:FileUpload ID="fupssccertificate" Width="300px" runat="server" class="form-control txtbox"
                                                        Height="28px" />
                                                    <asp:HyperLink ID="Hypssccertificate" runat="server" CssClass="LBLBLACK"
                                                        Target="_blank"></asp:HyperLink>
                                                    <br />
                                                    <asp:Label ID="lblssccertificate" runat="server" visible="true"></asp:Label>
                                                </td>
                                                <td style="padding: 5px; margin: 5px; width: 10px;" valign="top">
                                                    <asp:Button ID="btnssccertificate" runat="server" CssClass="btn btn-xs btn-warning"
                                                        Height="28px" TabIndex="10" Text="Upload" OnClick="btnssccertificate_Click"                                                        Width="72px" />
                                                </td>
                                            </tr>

                                        </tr>
                                    </table>

                            </td>
                        </tr>
                        <tr>
                            <td align="center"
                                style="padding: 5px; margin: 5px; text-align: center;">
                                    <table>
                                        <tr id="CLUTable" runat="server" visible="true">
                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="middle">4</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label11" runat="server" CssClass="LBLBLACK" Width="410px">Elevation Plan and Sections<font 
                                color="red">*</font></asp:Label>
                                                <br />
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:FileUpload ID="fupelevationplanandsections" Width="300px" runat="server" class="form-control txtbox"
                                                    Height="28px" />
                                                <asp:HyperLink ID="Hypelevationplanandsections" runat="server" CssClass="LBLBLACK"
                                                    Target="_blank"></asp:HyperLink>
                                                <br />
                                                <asp:Label ID="lblelevationplanandsections" runat="server" visible="true"></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;" valign="top">
                                                <asp:Button ID="btnelevationplanandsections" runat="server" CssClass="btn btn-xs btn-warning"
                                                    Height="28px" TabIndex="10" Text="Upload" OnClick="btnelevationplanandsections_Click"
                                                    Width="72px" />
                                            </td>
                                        </tr>
                                        <tr id="Tr21" runat="server" visible="true">
                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="middle">5&nbsp;</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label6" runat="server" CssClass="LBLBLACK" Width="410px">Acknowledgment ID<font 
                                color="red">*</font></asp:Label>
                                                <br />
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:TextBox ID="txtacknowledgeid" runat="server" class="form-control txtbox" Height="28px" MaxLength="10" TabIndex="1" ValidationGroup="group" Width="180px"></asp:TextBox>
                                                
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;" valign="top">
                                                &nbsp;</td>
                                        </tr>
                                        <tr id="Tr22" runat="server" visible="true">
                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="middle">&nbsp;</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label10" runat="server" CssClass="LBLBLACK" Width="410px">Permission based on SACFA<font 
                                color="red">*</font></asp:Label>
                                                <br />
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:FileUpload ID="fupSACFA" Width="300px" runat="server" class="form-control txtbox"
                                                    Height="28px" />
                                                <asp:HyperLink ID="HypSACFA" runat="server" CssClass="LBLBLACK"
                                                    Target="_blank"></asp:HyperLink>
                                                <br />
                                                <asp:Label ID="lblSACFA" runat="server" visible="true"></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;" valign="top">
                                                <asp:Button ID="btnSACFA" runat="server" CssClass="btn btn-xs btn-warning"
                                                    Height="28px" TabIndex="10" Text="Upload" OnClick="btnSACFA_Click"
                                                    Width="72px" />
                                            </td>
                                        </tr>
                                    </table>

                            </td>
                        </tr>
                            <tr>
                            <td align="center"
                                style="padding: 5px; margin: 5px; text-align: center;">
                                    <table>
                                        
                                        
                                        <tr>
                            <td align="center" colspan="3"
                                style="padding: 5px; margin: 5px; text-align: center;">
                                    <table>
                                        <tr id="Tr13" runat="server" visible="true">
                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="middle">6&nbsp;</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label25" runat="server" CssClass="LBLBLACK" Width="410px">Location/Site Plan<font 
                                color="red">*</font></asp:Label>
                                                <br />
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:FileUpload ID="fuplocationorsiteplan" Width="300px" runat="server" class="form-control txtbox"
                                                    Height="28px" />
                                                <asp:HyperLink ID="Hyplocationorsiteplan" runat="server" CssClass="LBLBLACK"
                                                    Target="_blank"></asp:HyperLink>
                                                <br />
                                                <asp:Label ID="lbllocationorsiteplan" runat="server" visible="true"></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;" valign="top">
                                                <asp:Button ID="btnlocationorsiteplan" runat="server" CssClass="btn btn-xs btn-warning"
                                                    Height="28px" TabIndex="10" Text="Upload" OnClick="btnlocationorsiteplan_Click"
                                                    Width="72px" />
                                            </td>
                                        </tr>
                                    </table>

                            </td>
                        </tr>
                                        <tr>
                            <td align="center" colspan="3"
                                style="padding: 5px; margin: 5px; text-align: center;">
                                    <table>
                                        <tr id="Tr14" runat="server" visible="true">
                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="middle">7</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label27" runat="server" CssClass="LBLBLACK" Width="410px">Ownership Doc with Attestation<font 
                                color="red">*</font></asp:Label>
                                                <br />
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:FileUpload ID="fupownershipdocument" Width="300px" runat="server" class="form-control txtbox"
                                                    Height="28px" />
                                                <asp:HyperLink ID="Hypownershipdocument" runat="server" CssClass="LBLBLACK"
                                                    Target="_blank"></asp:HyperLink>
                                                <br />
                                                <asp:Label ID="lblownershipdocument" runat="server" visible="true"></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;" valign="top">
                                                <asp:Button ID="btnownershipdocument" runat="server" CssClass="btn btn-xs btn-warning"
                                                    Height="28px" TabIndex="10" Text="Upload" OnClick="btnownershipdocument_Click"
                                                    Width="72px" />
                                            </td>
                                        </tr>
                                    </table>

                            </td>
                        </tr>
                                        <tr>
                            <td align="center" colspan="3"
                                style="padding: 5px; margin: 5px; text-align: center;">
                                    <table>
                                        <tr id="Tr15" runat="server" visible="true">
                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="middle">8</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label29" runat="server" CssClass="LBLBLACK" Width="410px">Lease Agreement Between Building/Site Owner and Applicant<font 
                                color="red">*</font></asp:Label>
                                                <br />
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:FileUpload ID="fupleaseagreement" Width="300px" runat="server" class="form-control txtbox"
                                                    Height="28px" />
                                                <asp:HyperLink ID="Hypleaseagreement" runat="server" CssClass="LBLBLACK"
                                                    Target="_blank"></asp:HyperLink>
                                                <br />
                                                <asp:Label ID="lblleaseagreement" runat="server" visible="true"></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;" valign="top">
                                                <asp:Button ID="btnleaseagreement" runat="server" CssClass="btn btn-xs btn-warning"
                                                    Height="28px" TabIndex="10" Text="Upload" OnClick="btnleaseagreement_Click"
                                                    Width="72px" />
                                            </td>
                                        </tr>
                                    </table>

                            </td>
                        </tr>
                                        <tr>
                            <td align="center" colspan="3"
                                style="padding: 5px; margin: 5px; text-align: center;">
                                    <table>
                                        <tr id="Tr16" runat="server" visible="true">
                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="middle">9</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label31" runat="server" CssClass="LBLBLACK" Width="410px">Vicinity Certificate<font 
                                color="red">*</font></asp:Label>
                                                <br />
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:FileUpload ID="fupvicinitycertificate" Width="300px" runat="server" class="form-control txtbox"
                                                    Height="28px" />
                                                <asp:HyperLink ID="Hypvicinitycertificate" runat="server" CssClass="LBLBLACK"
                                                    Target="_blank"></asp:HyperLink>
                                                <br />
                                                <asp:Label ID="lblvicinitycertificate" runat="server" visible="true"></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;" valign="top">
                                                <asp:Button ID="btnvicinitycertificate" runat="server" CssClass="btn btn-xs btn-warning"
                                                    Height="28px" TabIndex="10" Text="Upload" OnClick="btnvicinitycertificate_Click"
                                                    Width="72px" />
                                            </td>
                                        </tr>
                                    </table>

                            </td>
                        </tr>
                                        <tr>
                            <td align="center" colspan="3"
                                style="padding: 5px; margin: 5px; text-align: center;">
                                    <table>
                                        <tr id="Tr17" runat="server" visible="true">
                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="middle">10</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label33" runat="server" CssClass="LBLBLACK" Width="410px">Indemnity Bond<font 
                                color="red">*</font></asp:Label>
                                                <br />
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:FileUpload ID="fupindemnitybond" Width="300px" runat="server" class="form-control txtbox"
                                                    Height="28px" />
                                                <asp:HyperLink ID="Hypindemnitybond" runat="server" CssClass="LBLBLACK"
                                                    Target="_blank"></asp:HyperLink>
                                                <br />
                                                <asp:Label ID="lblindemnitybond" runat="server" visible="true"></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;" valign="top">
                                                <asp:Button ID="btnindemnitybond" runat="server" CssClass="btn btn-xs btn-warning"
                                                    Height="28px" TabIndex="10" Text="Upload" OnClick="btnindemnitybond_Click"
                                                    Width="72px" />
                                            </td>
                                        </tr>
                                    </table>

                            </td>
                        </tr>
                                        <tr>
                            <td align="center" colspan="3"
                                style="padding: 5px; margin: 5px; text-align: center;">
                                    <table>
                                        <tr id="Tr18" runat="server" visible="true">
                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="middle">11</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label35" runat="server" CssClass="LBLBLACK" Width="410px">NOC from House/Site Owner<font 
                                color="red">*</font></asp:Label>
                                                <br />
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:FileUpload ID="fupownernoc" Width="300px" runat="server" class="form-control txtbox"
                                                    Height="28px" />
                                                <asp:HyperLink ID="Hypownernoc" runat="server" CssClass="LBLBLACK"
                                                    Target="_blank"></asp:HyperLink>
                                                <br />
                                                <asp:Label ID="lblownernoc" runat="server" visible="true"></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;" valign="top">
                                                <asp:Button ID="btnownernoc" runat="server" CssClass="btn btn-xs btn-warning"
                                                    Height="28px" TabIndex="10" Text="Upload" OnClick="btnownernoc_Click"
                                                    Width="72px" />
                                            </td>
                                        </tr>
                                    </table>

                            </td>
                        </tr>
                                        <tr>
                            <td align="center" colspan="3"
                                style="padding: 5px; margin: 5px; text-align: center;">
                                    <table>
                                        <tr id="Tr19" runat="server" visible="true">
                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="middle">12</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label37" runat="server" CssClass="LBLBLACK" Width="410px">Building Permission<font 
                                color="red">*</font></asp:Label>
                                                <br />
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:FileUpload ID="fupbuildingpermission" Width="300px" runat="server" class="form-control txtbox"
                                                    Height="28px" />
                                                <asp:HyperLink ID="Hypbuildingpermission" runat="server" CssClass="LBLBLACK"
                                                    Target="_blank"></asp:HyperLink>
                                                <br />
                                                <asp:Label ID="lblbuildingpermission" runat="server" visible="true"></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;" valign="top">
                                                <asp:Button ID="btnbuildingpermission" runat="server" CssClass="btn btn-xs btn-warning"
                                                    Height="28px" TabIndex="10" Text="Upload" OnClick="btnbuildingpermission_Click"
                                                    Width="72px" />
                                            </td>
                                        </tr>
                                    </table>

                            </td>
                        </tr>
                                        <tr>
                            <td align="center" colspan="3"
                                style="padding: 5px; margin: 5px; text-align: center;">
                                    <table>
                                        <tr id="Tr20" runat="server" >
                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="middle">13</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label39" runat="server" CssClass="LBLBLACK" Width="410px">Occupancy Certificate<font 
                                color="red">*</font></asp:Label>
                                                <br />
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:FileUpload ID="fupoccupancy" Width="300px" runat="server" class="form-control txtbox"
                                                    Height="28px" />
                                                <asp:HyperLink ID="Hypoccupancy" runat="server" CssClass="LBLBLACK"
                                                    Target="_blank"></asp:HyperLink>
                                                <br />
                                                <asp:Label ID="lbloccupancy" runat="server" visible="true"></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;" valign="top">
                                                <asp:Button ID="btnoccupancy" runat="server" CssClass="btn btn-xs btn-warning"
                                                    Height="28px" TabIndex="10" Text="Upload" OnClick="btnoccupancy_Click"
                                                    Width="72px" />
                                            </td>
                                        </tr>
                                    </table>

                            </td>
                        </tr>

                                    </table>

                            </td>
                        </tr>
                        <tr>
                            <td align="center"
                                style="padding: 5px; margin: 5px; text-align: center;">&nbsp;</td>
                        </tr>

                        <tr>
                            <td align="center"
                                style="padding: 5px; margin: 5px; text-align: center;">
                                <%--<asp:Button ID="BtnClear" runat="server" CausesValidation="False"
                                    CssClass="btn btn-warning" Height="32px" OnClick="BtnClear_Click" TabIndex="10"
                                    Text="ClearAll" ToolTip="To Clear  the Screen" Width="90px" />--%>
                                &nbsp;
                                    <%--<asp:Button ID="BtnSave1" runat="server" CssClass="btn btn-primary"
                                        Height="32px" OnClick="BtnSave_Click" TabIndex="10" Text="Save"
                                        ValidationGroup="group" Width="90px" />--%>
                                &nbsp;<%--<asp:Button ID="BtnDelete0" runat="server"
                                    CssClass="btn btn-danger" Height="32px" OnClick="BtnDelete0_Click" TabIndex="10"
                                    Text="previous" Width="90px" />--%>
                                &nbsp;&nbsp;<asp:Button ID="btnpayment" runat="server"
                                    CssClass="btn btn-danger" Height="32px" OnClick="btnpayment_Click" TabIndex="10"
                                    Text="Payment" Width="90px" ValidationGroup="group" />


                            </td>
                        </tr>
                        <tr>
                            <td align="center" style="padding: 5px; margin: 5px">


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

                </div>
            </div>
        </div>

    </div>

</asp:Content>
