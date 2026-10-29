<%@ Page Title="" Language="C#" MasterPageFile="~/UI/TSiPASS/CCMaster.master" AutoEventWireup="true" CodeFile="HMDAAttachmentsToMAUD.aspx.cs" Inherits="UI_TSiPASS_HMDAAttachmentsToMAUD" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>


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

<%--   <script language="javascript" type="text/javascript">
       function confirmMAUD() {
           if (confirm("Application Has been sent to MA & UD Successfully"))
               return true;
           return false;
       }
    </script>--%>
    <%-----------------11------------------------------------------------------%>   <%----------------12-------------------------------------------------------%>
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
                <i class="fa fa-edit"></i><a href="#">Attachment Details</a>
            </li>
        </ol>
    </div>

    <div align="left">
        <div class="row" align="left">
            <div class="col-lg-11">
                <div class="panel panel-primary">
                    <div class="panel-heading" align="center">
                        <h3 class="panel-title">Attachment Details</h3>
                    </div>
                    <%-----------------12------------------------------------------------------%>
                    <div class="panel-body">
                        <table align="center" cellpadding="10" cellspacing="5" style="width: 90%">

                            <tr>
                                <td style="padding: 5px; margin: 5px" valign="top">
                                    <asp:Label ID="Label422" runat="server" CssClass="LBLBLACK" Font-Bold="True"
                                        Width="210px">Attachments<font 
                                                            color="red">*</font></asp:Label>
                                </td>
                                <td align="right">
                                    </td>
                                    
                            </tr>
                            <tr>
                                <td colspan="2" style="padding: 5px; margin: 5px" valign="top">
                                    <table cellpadding="4" cellspacing="5" style="width: 100%; text-align: left;">
                                         <tr runat="server" id="trerector" visible="true">
                                            <td style="padding: 5px; margin: 5px; text-align: left;">1.</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label19" runat="server" CssClass="LBLBLACK" Width="210px">Detailed/Factual Report<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td class="style6" style="padding: 5px; margin: 5px; width:300px ; text-align: left;" >
                                                <asp:FileUpload ID="FileDetailed" runat="server" class="form-control txtbox"
                                                    Height="28px" />

                                                <asp:HyperLink ID="lblDetailed" runat="server" CssClass="LBLBLACK" Width="165px"
                                                    Target="_blank"></asp:HyperLink>
                                                <br />
                                                <asp:Label ID="LabelDetailed" runat="server" Visible="False"></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                <asp:Button ID="BtnDetailed" runat="server" CssClass="btn btn-xs btn-warning"
                                                    Height="28px" TabIndex="10" Text="Upload"
                                                    Width="72px" OnClick="BtnDetailed_Click" />
                                            </td>
                                        </tr>
                                       
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">2</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label433" runat="server" CssClass="LBLBLACK" Width="210px">Extract of Master Plan<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:FileUpload ID="FileUploadMaster" runat="server" class="form-control txtbox"
                                                    Height="28px" />
                                                <asp:HyperLink ID="LblMaster" runat="server" CssClass="LBLBLACK" Width="165px"
                                                    Target="_blank"></asp:HyperLink>
                                                <br />
                                                <asp:Label ID="LabelMaster" runat="server" Visible="False"></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                <asp:Button ID="ButtonMaster" runat="server" CssClass="btn btn-xs btn-warning"
                                                    Height="28px" TabIndex="10" Text="Upload"
                                                    Width="72px" OnClick="ButtonMaster_Click" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">3</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label396" runat="server" CssClass="LBLBLACK" Width="165px">Google Map<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:FileUpload ID="FileUploadGoogle" runat="server" class="form-control txtbox"
                                                    Height="28px" />
                                                <asp:HyperLink ID="LblGoogle" runat="server" CssClass="LBLBLACK" Width="165px"
                                                    Target="_blank"></asp:HyperLink>
                                                <br />
                                                <asp:Label ID="LabelGoogle" runat="server" Visible="False"></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                <asp:Button ID="ButtonGoogle" runat="server" CssClass="btn btn-xs btn-warning"
                                                    Height="28px" TabIndex="10" Text="Upload"
                                                    Width="72px" OnClick="ButtonGoogle_Click"  />
                                            </td>
                                        </tr>   
                                        <%-----------------20------------------------------------------------------%>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2" style="padding: 5px; margin: 5px" valign="top" align="left">&nbsp;</td>
                            </tr>
                            <tr>
                                <td colspan="2" align="left" style="padding: 5px; margin: 5px" valign="top">
                                    <asp:Label ID="Label378" runat="server" CssClass="LBLBLACK" Font-Bold="True"
                                        Width="280px">Other Attachments :</asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2" style="padding: 5px; margin: 5px" valign="top">
                                    <table cellpadding="4" cellspacing="5" style="width: 100%">
                                        <tr>
                                            
                                            <table cellpadding="4" cellspacing="5" style="width: 100%">
                                                <tr>
                                                    <td style="padding: 5px; margin: 5px; text-align: left;">
                                                        <asp:Label ID="Label442" runat="server" CssClass="LBLBLACK" Width="210px">Attachment Type<font 
                                                            color="red">*</font></asp:Label>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px">:</td>
                                                    <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                        <asp:DropDownList ID="ddlAttachmentType" runat="server" class="form-control txtbox"
                                                            Height="33px" Width="180px"
                                                            OnSelectedIndexChanged="ddlAttachmentType_SelectedIndexChanged"
                                                            AutoPostBack="True">
                                                            <asp:ListItem>--Select--</asp:ListItem>
                                                          <%--  <asp:ListItem Value="1">Google Map (HMDA)</asp:ListItem>
                                                            <asp:ListItem Value="2">Nodal Agency attachments(Industries Dept)</asp:ListItem>
                                                            <asp:ListItem Value="3">TSPCB Attachments</asp:ListItem>
                                                            <asp:ListItem Value="4">TSSPDCL/NPDCL Attachments</asp:ListItem>
                                                            <asp:ListItem Value="5">DTCP/HMDA/KUDA/IALA Attachments</asp:ListItem>
                                                            <asp:ListItem Value="6">NOC from Gram Panchayat</asp:ListItem>
                                                            <asp:ListItem Value="7">Ground Water Dept Attachments</asp:ListItem>
                                                            <asp:ListItem Value="8">Fire Dept Attachments</asp:ListItem>
                                                            <asp:ListItem Value="9">TSIIC Land/Plot Allotment</asp:ListItem>
                                                            <asp:ListItem Value="10">Factories Dept Attachments</asp:ListItem>--%>
                                                            <asp:ListItem Value="11">Other Documents</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px; width: 10px;">&nbsp;</td>
                                                </tr>
                                                <tr>
                                                    <td style="padding: 5px; margin: 5px; text-align: left;">&nbsp;</td>
                                                    <td style="padding: 5px; margin: 5px">&nbsp;</td>
                                                    <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                        <asp:TextBox ID="txtOthers" runat="server" class="form-control txtbox"
                                                            Height="28px" MaxLength="40" TabIndex="1"
                                                            ValidationGroup="group" Width="180px"
                                                            OnTextChanged="txtcontact6_TextChanged" Visible="False"></asp:TextBox>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px; width: 10px;">&nbsp;</td>
                                                </tr>


                                                <tr>
                                                    <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                        <asp:Label ID="Label443" runat="server" CssClass="LBLBLACK" Width="210px">Document <font 
                                                            color="red">*</font></asp:Label>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px">:</td>
                                                    <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                        <asp:FileUpload ID="FileUpload9" runat="server" class="form-control txtbox"
                                                            Height="28px" />
                                                        <asp:HyperLink ID="Label5" runat="server" CssClass="LBLBLACK" Width="165px"
                                                            Target="_blank">[Label5]</asp:HyperLink>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px; width: 10px;">
                                                        <asp:Button ID="Button7" runat="server" CssClass="btn btn-xs btn-warning"
                                                            Height="28px" TabIndex="10" Text="Upload" ValidationGroup="group"
                                                            Width="80px" OnClick="Button7_Click" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 200px;">&nbsp;</td>
                                                    <td style="padding: 5px; margin: 5px">&nbsp;</td>
                                                    <td style="padding: 5px; margin: 5px">&nbsp;</td>
                                                    <td style="padding: 5px; margin: 5px">&nbsp;</td>
                                                </tr>
                                                <tr>
                                                    <td colspan="4">
                                                        <asp:GridView ID="gvCertificate" runat="server" AutoGenerateColumns="False"
                                                            BorderColor="#003399" BorderStyle="Solid" BorderWidth="1px" CellPadding="4"
                                                            CssClass="GRD" ForeColor="#333333" GridLines="None"
                                                            OnRowDataBound="gvCertificate_RowDataBound"
                                                            OnRowDeleting="gvCertificate_RowDeleting" Width="100%"
                                                            OnSelectedIndexChanged="gvCertificate_SelectedIndexChanged">
                                                            <RowStyle BackColor="#ffffff" />
                                                            <Columns>
                                                                <asp:CommandField HeaderText="Edit" ShowSelectButton="True" Visible="False" />
                                                                <%-- <asp:CommandField HeaderText="Delete" ShowDeleteButton="True" />
                                                                --%>
                                                                <asp:BoundField DataField="Manf_ItemName" HeaderText="Attachment Type" />

                                                                <asp:BoundField DataField="Manf_Item_Quantity_In" HeaderText="Document" />

                                                            </Columns>
                                                            <FooterStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                                            <PagerStyle BackColor="#013161" ForeColor="White" HorizontalAlign="Center" />
                                                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                                            <HeaderStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                                            <EditRowStyle BackColor="#013161" />
                                                            <AlternatingRowStyle BackColor="White" />
                                                        </asp:GridView>
                                                    </td>
                                                </tr>
                                            </table>
                                                <td style="padding: 5px; margin: 5px" valign="top">&nbsp;</td>
                                              
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px" align="center" class="style7">&nbsp;<tr>
                                                <td style="padding: 5px; margin: 5px; text-align: center;" align="center">
                                                    &nbsp;</td>
                                            </tr>
                                                <caption>
                                                    &nbsp;</caption>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center"
                                                style="padding: 5px; margin: 5px; text-align: center;">
                                                <asp:Button ID="BtnSave1" runat="server" CssClass="btn btn-primary"
                                                    Height="32px" OnClick="BtnSave_Click" TabIndex="10" Text="Sent to MA & UD for Approval"
                                                    ValidationGroup="group" Width="250px" Visible="true" />                                             
                                                &nbsp;<asp:Button ID="BtnClear" runat="server" CausesValidation="False"
                                                    CssClass="btn btn-warning" Height="32px" OnClick="BtnClear_Click" TabIndex="10"
                                                    Text="ClearAll" ToolTip="To Clear  the Screen" Width="90px" />
                                                 &nbsp;  &nbsp;<asp:Button ID="btnback" runat="server" CausesValidation="False"
                                                    CssClass="btn btn-warning" Height="32px" TabIndex="10"
                                                    Text="Back" ToolTip="Back" Width="90px" OnClick="btnback_Click" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center" style="padding: 5px; margin: 5px">


                                                <div id="success" runat="server" visible="false" class="alert alert-success">
                                                    <a href="AddQualification.aspx" class="close" data-dismiss="alert" aria-label="close">×times;</a>
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


