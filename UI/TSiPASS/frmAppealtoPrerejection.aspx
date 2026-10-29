<%@ Page Title=":: TS-iPASS ::  " Language="C#" MasterPageFile="~/UI/TSiPASS/CCMaster.master"
    AutoEventWireup="true" CodeFile="frmAppealtoPrerejection.aspx.cs" Inherits="TSTBDCReg1" %>

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
    </style>
    <script type="text/javascript" language="javascript">

        function OpenPopup() {

            window.open("Lookups/LookupBDC.aspx", "List", "scrollbars=yes,resizable=yes,width=1000,height=650;display = block;position=absolute");

            return false;
        }
    </script>
    <%--</ContentTemplate>
  </asp:UpdatePanel>--%>
    <%-- </div>
       </td>
        </tr>
    </table>--%>
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
                            Rejection Details</h3>
                    </div>
                    <%--   <asp:UpdatePanel ID="UpdatePanel1" runat="server">
<ContentTemplate>--%>
                    <div class="panel-body">
                        <table align="center" cellpadding="10" cellspacing="5" style="width: 90%;">
                            <tr>
                                <td style="padding: 5px; margin: 5px" valign="top">
                                    <asp:Label ID="Label422" runat="server" CssClass="LBLBLACK" Font-Bold="True" Width="210px">Appeal for Rejection</asp:Label>
                                </td>
                            </tr>
                            <tr style="height: 20px; color: #ff4615;">
                                <td>
                                    <div class="panel panel-primary">
                                        <div class="panel-heading" align="center">
                                            <h4 class="panel-title">
                                                Note</h4>
                                        </div>
                                        <div class="panel-body">
                                            <div>
                                                <span style="font-weight: bold; text-decoration: underline; color: red"><span style="font-weight: bold;
                                                    text-decoration: underline; color: red"><b>Note : "Please check the documents you are
                                                        uploading as against rejection reasons mentioned by the department. If it is not
                                                        complied there is no second chance for appealing." </b></span>
                                            </div>
                                        </div>
                                    </div>
                                </td>
                            </tr>
                            <tr id="trdeptremarks" runat="server" visible="false">
                                <td>
                                    <span style="font-weight: bold; text-decoration: underline; color: Blue">Deapartment Comments:
                                        <asp:Label ID="lbldeptremarks" runat="server"></asp:Label></span>
                                </td>
                            </tr>
                            <tr>
                                <td style="padding: 5px; margin: 5px" valign="top">
                                    <table cellpadding="4" cellspacing="5" style="width: 100%">
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                1
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label387" runat="server" CssClass="LBLBLACK" Width="210px">UID Number<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                :
                                            </td>
                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label447" runat="server"></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                2
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label433" runat="server" CssClass="LBLBLACK" Width="210px">Name of Industry<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                :
                                            </td>
                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label448" runat="server"></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                3
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label396" runat="server" CssClass="LBLBLACK" Width="165px">Enterprise Type<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                :
                                            </td>
                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label449" runat="server"></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                4
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label435" runat="server" CssClass="LBLBLACK" Width="410px">Polution Category<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                :
                                            </td>
                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label450" runat="server"></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                5
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label434" runat="server" CssClass="LBLBLACK" Width="165px">Department Name<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                :
                                            </td>
                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label451" runat="server"></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                6
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label436" runat="server" CssClass="LBLBLACK" Width="410px">Department Approval<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                :
                                            </td>
                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label452" runat="server"></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                7
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label445" runat="server" CssClass="LBLBLACK" Width="410px">Rejected Date<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                :
                                            </td>
                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label453" runat="server"></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                8
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label446" runat="server" CssClass="LBLBLACK" Width="410px">Rejection Description<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                :
                                            </td>
                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label454" runat="server"></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr runat="server" id="TrCOIRemarks" visible="false">
                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                8(a)
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label7" runat="server" CssClass="LBLBLACK" Width="410px">COI Rejection Remarks<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                :
                                            </td>
                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="lblcoiremarks" runat="server"></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr id="trdescription" runat="server">
                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                9
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label1" runat="server" CssClass="LBLBLACK" Width="410px">Appeal Description<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                :
                                            </td>
                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:TextBox ID="txtdiscription" runat="server" class="form-control txtbox" Height="40px"
                                                    TextMode="MultiLine" ValidationGroup="group" Width="180px"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                <asp:RequiredFieldValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="txtdiscription"
                                                    ErrorMessage="Enter Description" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr id="tr1" runat="server" visible="false">
                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                9
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label2" runat="server" CssClass="LBLBLACK" Width="410px">Status</asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                :
                                            </td>
                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label3" runat="server" CssClass="LBLBLACK" Width="410px">Appealed Against Rejection</asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                            </td>
                                        </tr>
                                        <tr id="trrejectiondoc" runat="server" visible="false">
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                &nbsp;
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                RejectionLetter
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                &nbsp;
                                            </td>
                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:HyperLink ID="HyperLink1" runat="server" ForeColor="#FF6600" Target="_blank">[HyperLink1]</asp:HyperLink>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr id="trattachment" runat="server" visible="false">
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                10
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label439" runat="server" CssClass="LBLBLACK" Width="165px">Appeal Attachment<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                :
                                            </td>
                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:FileUpload ID="FileUpload1" runat="server" class="form-control txtbox" />
                                                <asp:Label ID="Label440" runat="server" CssClass="LBLBLACK" Width="165px"></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                <asp:Button ID="Button6" runat="server" CssClass="btn btn-xs btn-warning" Height="28px"
                                                    TabIndex="10" Text="Upload" ValidationGroup="group" Width="72px" OnClick="Button6_Click" />
                                            </td>
                                        </tr>
                                        <tr id="trresponseattachmentgrid" runat="server" visible="true">
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                &nbsp;
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                &nbsp;
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                &nbsp;
                                            </td>
                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:GridView ID="gvUpload4" runat="server" AutoGenerateColumns="False" CellPadding="3"
                                                    EnableModelValidation="True" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None"
                                                    BorderWidth="1px">
                                                    <FooterStyle BackColor="White" ForeColor="#000066" />
                                                    <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                                                    <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                                                    <RowStyle ForeColor="#000066" />
                                                    <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="Sl.No">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblslno" runat="server" Text="<%#Container.DataItemIndex + 1 %>"></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="File Name">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblFileName" runat="server" Text='<%#Eval("FileName") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Attachment">
                                                            <ItemTemplate>
                                                                <asp:HyperLink ID="hprlink" runat="server" Text="View" NavigateUrl='<%#Eval("link") %>'
                                                                    Target="_blank"></asp:HyperLink>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                </asp:GridView>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr id="trregistrationdeed" runat="server" visible="false">
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="lblregistrationdeed" runat="server" CssClass="LBLBLACK" Width="165px">Registration Deed  Attachment<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                :
                                            </td>
                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:FileUpload ID="FileUploadregistrationdeed" runat="server" class="form-control txtbox" />
                                                <asp:Label ID="Label4" runat="server" CssClass="LBLBLACK" Width="165px"></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                <asp:Button ID="btnregistrationdeed" runat="server" CssClass="btn btn-xs btn-warning"
                                                    Height="28px" TabIndex="10" Text="Upload" ValidationGroup="group" Width="72px"
                                                    OnClick="btnregistrationdeed_Click" />
                                            </td>
                                        </tr>
                                        <tr id="trProcessFlow" runat="server" visible="false">
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="LabelProcessFlow" runat="server" CssClass="LBLBLACK" Width="165px">Process Flow Chart  Attachment<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                :
                                            </td>
                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:FileUpload ID="FileUploadProcessFlow" runat="server" class="form-control txtbox" />
                                                <asp:Label ID="Label5" runat="server" CssClass="LBLBLACK" Width="165px"></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                <asp:Button ID="btnProcessFlow" runat="server" CssClass="btn btn-xs btn-warning"
                                                    Height="28px" TabIndex="10" Text="Upload" ValidationGroup="group" Width="72px"
                                                    OnClick="btnProcessFlow_Click" />
                                            </td>
                                        </tr>
                                        <tr id="trPANAADHAAR" runat="server" visible="false">
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="LabelPANAADHAAR" runat="server" CssClass="LBLBLACK" Width="165px">PAN / AADHAAR  Attachment<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                :
                                            </td>
                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:FileUpload ID="FileUploadPANAADHAAR" runat="server" class="form-control txtbox" />
                                                <asp:Label ID="Label6" runat="server" CssClass="LBLBLACK" Width="165px"></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                <asp:Button ID="btnPANAADHAAR" runat="server" CssClass="btn btn-xs btn-warning" Height="28px"
                                                    TabIndex="10" Text="Upload" ValidationGroup="group" Width="72px" OnClick="btnPANAADHAAR_Click" />
                                            </td>
                                        </tr>
                                        <tr id="trSelfCertification" runat="server" visible="false">
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="LabelSelfCertification" runat="server" CssClass="LBLBLACK" Width="165px">Self-Certification Form  Attachment<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                :
                                            </td>
                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:FileUpload ID="FileUploadSelfCertification" runat="server" class="form-control txtbox" />
                                                <asp:Label ID="Label8" runat="server" CssClass="LBLBLACK" Width="165px"></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                <asp:Button ID="btnSelfCertification" runat="server" CssClass="btn btn-xs btn-warning"
                                                    Height="28px" TabIndex="10" Text="Upload" ValidationGroup="group" Width="72px"
                                                    OnClick="btnSelfCertification_Click" />
                                            </td>
                                        </tr>
                                        <tr id="trPartnershipDeed" runat="server" visible="false">
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="LabelPartnershipDeed" runat="server" CssClass="LBLBLACK" Width="165px">Partnership Deed (or) Articles of Association (AOA)  Attachment<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                :
                                            </td>
                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:FileUpload ID="FileUploadPartnershipDeed" runat="server" class="form-control txtbox" />
                                                <asp:Label ID="Label10" runat="server" CssClass="LBLBLACK" Width="165px"></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                <asp:Button ID="btnPartnershipDeed" runat="server" CssClass="btn btn-xs btn-warning"
                                                    Height="28px" TabIndex="10" Text="Upload" ValidationGroup="group" Width="72px"
                                                    OnClick="btnPartnershipDeed_Click" />
                                            </td>
                                        </tr>
                                        <tr id="trMutationorder" runat="server" visible="false">
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="LabelMutationorder" runat="server" CssClass="LBLBLACK" Width="165px">Mutation order Attachment<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                :
                                            </td>
                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:FileUpload ID="FileUploadMutationorder" runat="server" class="form-control txtbox" />
                                                <asp:Label ID="Label12" runat="server" CssClass="LBLBLACK" Width="165px"></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                <asp:Button ID="btnMutationorder" runat="server" CssClass="btn btn-xs btn-warning"
                                                    Height="28px" TabIndex="10" Text="Upload" ValidationGroup="group" Width="72px"
                                                    OnClick="btnMutationorder_Click" />
                                            </td>
                                        </tr>
                                        <tr id="trCommonAffidavit" runat="server" visible="false">
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="LabelCommonAffidavit" runat="server" CssClass="LBLBLACK" Width="165px">Common Affidavit  Attachment<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                :
                                            </td>
                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:FileUpload ID="FileUploadCommonAffidavit" runat="server" class="form-control txtbox" />
                                                <asp:Label ID="Label14" runat="server" CssClass="LBLBLACK" Width="165px"></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                <asp:Button ID="btnCommonAffidavit" runat="server" CssClass="btn btn-xs btn-warning"
                                                    Height="28px" TabIndex="10" Text="Upload" ValidationGroup="group" Width="72px"
                                                    OnClick="btnCommonAffidavit_Click" />
                                            </td>
                                        </tr>
                                        <tr id="trStructuralEng" runat="server" visible="false">
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="LabelStructuralEng" runat="server" CssClass="LBLBLACK" Width="165px">Structural Engineering Certificate Attachment<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                :
                                            </td>
                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:FileUpload ID="FileUploadStructuralEng" runat="server" class="form-control txtbox" />
                                                <asp:Label ID="Label16" runat="server" CssClass="LBLBLACK" Width="165px"></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                <asp:Button ID="btnStructuralEng" runat="server" CssClass="btn btn-xs btn-warning"
                                                    Height="28px" TabIndex="10" Text="Upload" ValidationGroup="group" Width="72px"
                                                    OnClick="btnStructuralEng_Click" />
                                            </td>
                                        </tr>
                                        <tr id="trCombinedbuilding" runat="server" visible="false">
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label17" runat="server" CssClass="LBLBLACK" Width="165px">Architectural dwg. in Pre-DCR<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                :
                                            </td>
                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:FileUpload ID="FileUploadCombinedbuilding" runat="server" class="form-control txtbox" />
                                                <asp:Label ID="Label18" runat="server" CssClass="LBLBLACK" Width="165px"></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                <asp:Button ID="btnCombinedbuilding" runat="server" CssClass="btn btn-xs btn-warning"
                                                    Height="28px" TabIndex="10" Text="Upload" ValidationGroup="group" Width="72px"
                                                    OnClick="btnCombinedbuilding_Click" />
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td style="padding: 5px; margin: 5px" valign="top" align="left">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr runat="server" visible="false">
                                <td style="padding: 5px; margin: 5px" valign="top" align="left">
                                    <span style="font-weight: bold; text-decoration: underline; color: red">After appealing,
                                        please inform us through Helpdesk for revoking the application so that it can reach
                                        to concerned dept.</span>
                                </td>
                                <td>
                                    <caption>
                                        &nbsp;</caption>
                                </td>
                            </tr>
                            <tr id="trbtn" runat="server">
                                <td align="center" style="padding: 5px; margin: 5px; text-align: center;">
                                    &nbsp;&nbsp;<asp:Button ID="BtnSubmit" runat="server" ValidationGroup="group" CssClass="btn btn-danger"
                                        Height="32px" TabIndex="10" Text="Submit" Width="90px" OnClientClick="return confirm('Do you want to Submit the record ? ');"
                                        OnClick="BtnSubmit_Click" />
                                    &nbsp;&nbsp;
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
                        <asp:HiddenField ID="hdfFlagID0" runat="server" />
                        <asp:HiddenField ID="hdfFlagID1" runat="server" />
                        <asp:HiddenField ID="hdfFlagID2" runat="server" />
                        <br />
                        <asp:HiddenField ID="hdfFlagID3" runat="server" />
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
