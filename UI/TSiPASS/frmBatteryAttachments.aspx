<%@ Page Title="" Language="C#" MasterPageFile="~/UI/TSiPASS/CCMaster.master" AutoEventWireup="true" CodeFile="frmBatteryAttachments.aspx.cs" Inherits="UI_TSiPASS_frmBatteryAttachments" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script src="../../Resource/Scripts/js/validations.js" type="text/javascript"></script>
    <script src="../../Resource/Styles/SideMenu/script.js" type="text/javascript"></script>
    <link href="../../Resource/Styles/SideMenu/styles.css" rel="stylesheet" type="text/css" />
    <link href="../../Masterfiles/css/StyleSheetMaster.css" rel="stylesheet" />
    <script src="../../Resource/Scripts/js/jquery.js" type="text/javascript"></script>
    <script src="../../Resource/Scripts/js/bootstrap.min.js" type="text/javascript"></script>
    <script type="text/javascript" src="../../Resource/Scripts/js/plugins/morris/raphael.min.js"></script>
    <script src="../../Resource/Scripts/js/plugins/morris/morris.min.js" type="text/javascript"></script>
    <script src="../../Resource/Scripts/js/plugins/morris/morris-data.js" type="text/javascript"></script>
    <%--<script src="../../Resource/js/bootstrap.min.js"></script>   
    <script src="../../Resource/js/plugins/morris/raphael.min.js"></script>
    <script src="../../Resource/js/plugins/morris/morris.min.js"></script>
    <script src="../../Resource/js/plugins/morris/morris-data.js"></script>--%>
    <link href="../../Resource/Styles/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="../../Resource/Styles/css/sb-admin.css" rel="stylesheet" type="text/css" />
    <link href="../../Resource/Styles/css/plugins/morris.css" rel="stylesheet" type="text/css" />
    <link href="../../Resource/Styles/font-awesome/css/font-awesome.css" rel="stylesheet"
        type="text/css" />
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/balloon-css/0.4.0/balloon.min.css">
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
    </style>

    <table>
        <tr>
            <td style="padding: 5px; margin: 5px" valign="top">
                <asp:Label ID="Label10" runat="server" CssClass="LBLBLACK" Font-Bold="True" Width="210px">Documents to be upload<font 
                                                            color="red">*</font></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="center" colspan="3" style="padding: 5px; margin: 5px; text-align: center;">
                <table cellpadding="4" cellspacing="5" style="width: 100%; text-align: left;">
                    <tr>
                        <td style="padding: 5px; margin: 5px; text-align: left;">1. </td>
                        <td style="padding: 5px; margin: 5px; text-align: left;">
                            <asp:Label ID="Label7" runat="server" CssClass="LBLBLACK" data-balloon="Self Certification Form" data-balloon-length="large" data-balloon-pos="down" Width="210px">GST Registration Certificate<font 
                                                            color="red">*</font></asp:Label>
                        </td>
                        <td style="padding: 5px; margin: 5px">: </td>
                        <td class="style6" style="padding: 5px; margin: 5px; text-align: left; width: 350px">
                            <asp:FileUpload ID="gstupload" runat="server" class="form-control txtbox" Height="33px" Width="300px" />
                            <asp:HyperLink ID="lblgstcert" runat="server" CssClass="LBLBLACK" Target="_blank"></asp:HyperLink>
                            <br />
                            <asp:Label ID="gstcertificate" runat="server" Visible="False"></asp:Label>
                            <asp:HiddenField ID="hdngst" runat="server" />
                        </td>
                        <td style="padding: 5px; margin: 5px; width: 10px;" valign="top">
                            <asp:Button ID="btngst" runat="server" CssClass="btn btn-xs btn-warning" Height="28px" OnClick="btngst_Click1" TabIndex="10" Text="Upload" Width="72px" />
                        </td>
                    </tr>
                    <tr>
                        <td style="padding: 5px; margin: 5px; text-align: left;">2. </td>
                        <td style="padding: 5px; margin: 5px; text-align: left;">Copy of Battery Dealer Registration</td>
                        <td style="padding: 5px; margin: 5px">: </td>
                        <td class="style6" style="padding: 5px; margin: 5px; text-align: left; width: 350px">
                            <asp:FileUpload ID="batdealupload" runat="server" class="form-control txtbox" Height="33px" Width="300px" />
                            <asp:HyperLink ID="lblbatdeareg" runat="server" CssClass="LBLBLACK" Target="_blank"></asp:HyperLink>
                            <br />
                            <asp:Label ID="batterydealercertificate" runat="server" Visible="False"></asp:Label>
                            <asp:HiddenField ID="HiddenField1" runat="server" />
                        </td>
                        <td style="padding: 5px; margin: 5px; width: 10px;" valign="top">
                            <asp:Button ID="btnbatdeal" runat="server" CssClass="btn btn-xs btn-warning" Height="28px" OnClick="btnbatdeal_Click1" TabIndex="10" Text="Upload" Width="72px" />
                        </td>
                    </tr>

                    <tr>
                        <td align="center" style="padding: 5px; margin: 5px; text-align: center;">
                            <asp:Button ID="btnsave" runat="server" CssClass="btn btn-primary" Height="32px"
                                OnClick="btnsave_Click" TabIndex="10" Text="Save" ValidationGroup="group" Width="90px"
                                Visible="true" />
                            &nbsp;&nbsp;<asp:Button ID="btnclear" runat="server" CausesValidation="False" CssClass="btn btn-danger"
                                Height="32px" OnClick="btnclear_Click" TabIndex="10" Text="Clear" Width="90px" />

                            &nbsp;<asp:Button ID="btnprevious" runat="server" CausesValidation="False" CssClass="btn btn-danger"
                                Height="32px" OnClick="btnprevious_Click" TabIndex="10" Text="Previous" Width="90px"
                                OnClientClick="return confirm('Do you want to Save the record ? ');" />
                            <%-- &nbsp;<asp:Button ID="Button2" runat="server" CausesValidation="False" CssClass="btn btn-warning"
                                Height="32px" OnClick="BtnClear_Click" TabIndex="10" Text="ClearAll" ToolTip="To Clear  the Screen"
                                Width="90px" />--%>
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
</asp:Content>

