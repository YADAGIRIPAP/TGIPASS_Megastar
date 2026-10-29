<%@ Page Title="" Language="C#" MasterPageFile="~/UI/TSiPASS/CCMaster.master" AutoEventWireup="true" CodeFile="Tourismevent_ApproveDetails.aspx.cs" Inherits="UI_TSiPASS_Tourismevent_ApproveDetails" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
    <script src="../../Resource/Scripts/js/validations.js" type="text/javascript"></script>
    
<style type="text/css">
.overlay
{
position: fixed;
z-index: 999;
height: 100%;
width: 100%;
top: 112px;
background-color:Gray;
filter: alpha(opacity=60);
opacity: 0.9;
-moz-opacity: 0.9;
}
    .style6
    {
        width: 192px;
    }
        .auto-style1 {
        width: 238px;
    }
    .auto-style2 {
        width: 37px;
    }
    .auto-style3 {
        width: 13px;
    }
    .auto-style4 {
        width: 488px;
    }
    .auto-style5 {
        width: 4px;
    }
    </style>

<script type="text/javascript" language="javascript">

function OpenPopup() 
 
   {

    window.open("Lookups/LookupBDC.aspx","List","scrollbars=yes,resizable=yes,width=1000,height=650;display = block;position=absolute");

    return false;
    }
    </script>

    <div align="left">
    <ol class="breadcrumb">You are here
        &nbsp;!&nbsp; &nbsp; &nbsp; 
                            <li>
                                <i class="fa fa-dashboard"></i>  <a href="Home.aspx"></a>
                            </li>
                            <li class="">
                                <i class="fa fa-fw fa-edit">CAF</i> 
                            </li>
                            <li class="active">
                                <i class="fa fa-edit"></i> <a href="#">Attachment Details</a>
                            
            
            </li>
        </ol>
    </div>
    <div align="left">
        <div class="row" align="left">
            <div class="col-lg-11">
                <div class="panel panel-primary">
                    <div class="panel-heading" align="center">
                        <h3 class="panel-title">
                            Approval Process</h3>
                    </div>
                    <%--   <asp:UpdatePanel ID="UpdatePanel1" runat="server">
<ContentTemplate>--%>
                    <div class="panel-body">
                        <table align="center" cellpadding="10" cellspacing="5" style="width: 90%">
                            <tr>
                                <td style="padding: 5px; margin: 5px" valign="top">
                                    <asp:Label ID="Label422" runat="server" CssClass="LBLBLACK" Font-Bold="True" Width="210px">Approval Process</asp:Label>
                                </td>
                                <td align="right"><asp:Label ID="Label58" runat="server" CssClass="LBLBLACK" ForeColor="Red" Font-Bold="True" 
                                                >If you want to Upload DWG file. make is as ZIP or RAR folder and upload it.</asp:Label></td>
                            </tr>
                            <tr>
                                <td colspan="2" style="padding: 5px; margin: 5px" valign="top">
                                    <table cellpadding="4" cellspacing="5" class="nav-justified">
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" class="auto-style2">
                                                1
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" class="auto-style1">
                                                <asp:Label ID="Label387" runat="server" CssClass="LBLBLACK" Width="210px">UID Number<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px" class="auto-style3">
                                                :
                                            </td>
                                            <td class="auto-style4" style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label447" runat="server"></asp:Label>
                                            </td>
                                            
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" class="auto-style2">
                                                2
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" class="auto-style1">
                                                <asp:Label ID="Label433" runat="server" CssClass="LBLBLACK" Width="210px">Name of Event<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px" class="auto-style3">
                                                :
                                            </td>
                                            <td class="auto-style4" style="padding: 5px; margin: 10px; text-align: left;">
                                                <asp:Label ID="Label448" runat="server"></asp:Label>
                                            </td>
                                            
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" class="auto-style2">
                                                3
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" class="auto-style1">
                                                <asp:Label ID="Label396" runat="server" CssClass="LBLBLACK" Width="165px">Classification Type<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px" class="auto-style3">
                                                :
                                            </td>
                                            <td class="auto-style4" style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label449" runat="server"></asp:Label>
                                            </td>
                                          
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top" class="auto-style2">
                                                4
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" class="auto-style1">
                                                <asp:Label ID="Label435" runat="server" CssClass="LBLBLACK" Width="284px">Event Type <font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px" class="auto-style3">
                                                :
                                            </td>
                                            <td class="auto-style4" style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label450" runat="server"></asp:Label>
                                            </td>
                                            
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="middle" class="auto-style2">
                                                5
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" class="auto-style1">
                                                <asp:Label ID="Label454" runat="server" CssClass="LBLBLACK" Width="313px">File Reference No<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px" class="auto-style3">
                                                :
                                            </td>
                                            <td class="auto-style4" style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:TextBox ID="txtGeo_Cordinate_Latitude" runat="server" class="form-control txtbox"
                                                    Height="28px" MaxLength="30" TabIndex="1" ValidationGroup="group" Width="180px"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; " class="auto-style5">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtGeo_Cordinate_Latitude"
                                                    ErrorMessage="Please Enter Reference Number" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="middle" class="auto-style2">
                                                6
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" class="auto-style1">
                                                <asp:Label ID="Label455" runat="server" CssClass="LBLBLACK" Width="332px">Upload Certificate<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px" class="auto-style3">
                                                :
                                            </td>
                                            <td class="auto-style4" style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:FileUpload ID="FileUpload1" runat="server" class="form-control txtbox" Height="28px" />
                                                <asp:HyperLink ID="lblFileName" runat="server" CssClass="LBLBLACK" Width="165px"
                                                    Target="_blank"></asp:HyperLink>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; " class="auto-style5">
                                                <asp:Button ID="BtnSave3" runat="server" CssClass="btn btn-xs btn-warning" Height="28px"
                                                    TabIndex="10" Text="Upload" Width="72px" OnClick="BtnSave3_Click" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top" class="auto-style2">
                                                7
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" class="auto-style1">
                                                <asp:Label ID="Label453" runat="server" CssClass="LBLBLACK" Width="334px">Status<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px" class="auto-style3">
                                                :
                                            </td>
                                            <td class="auto-style4" style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:DropDownList ID="ddlStatus" runat="server" class="form-control txtbox" Height="33px"
                                                    AutoPostBack="True" Width="180px" OnSelectedIndexChanged="ddlStatus_SelectedIndexChanged">
                                                    <asp:ListItem>--Select--</asp:ListItem>
                                                    <asp:ListItem Value="13">Approved</asp:ListItem>
                                                    <asp:ListItem Value="16">Rejected</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; " class="auto-style5">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="ddlStatus"
                                                    ErrorMessage="Please Select Status" InitialValue="--Select--" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr id="Remarks" visible="false" runat="server">
                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top" class="auto-style2">
                                                8
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" class="auto-style1">
                                                <asp:Label ID="Label456" runat="server" CssClass="LBLBLACK" Width="334px">Reason Remarks</asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px" class="auto-style3">
                                                :
                                            </td>
                                            <td class="auto-style4" style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:TextBox ID="txtremarks" TextMode="MultiLine" runat="server" class="form-control txtbox"
                                                    TabIndex="1" ValidationGroup="group" Width="180px"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; " class="auto-style5">
                                                &nbsp;
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr id="hmdaattachements" runat="server" visible="false">
                                <td style="padding: 10px; margin: 5px;" colspan="8">
                                    <asp:GridView ID="gvlastattachments" runat="server" AutoGenerateColumns="False"
                                        Width="80%" HorizontalAlign="Left" ShowHeader="true">
                                        <Columns>
                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S No">
                                                <ItemTemplate>
                                                    <%# Container.DataItemIndex + 1%>
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <ItemStyle Width="50px" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="HMDA Attachments">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbl" runat="server" Text='<%# Eval("AttachmentName")%>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="View">
                                                <ItemTemplate>
                                                    <asp:HyperLink ID="HyperLinkSubsidy" Text="view" NavigateUrl='<%#Eval("FilePath")%>' Target="_blank" runat="server" />
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" Width="100px" />
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2" style="padding: 5px; margin: 5px" valign="top" align="left">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2" align="center" style="padding: 5px; margin: 5px; text-align: center;">
                                    &nbsp;&nbsp;<asp:Button ID="BtnSave1" runat="server" CssClass="btn btn-primary" Height="32px"
                                        OnClick="BtnSave_Click" TabIndex="10" Text="Submit" ValidationGroup="group" Width="90px" />
                                    &nbsp;&nbsp;<asp:Button ID="BtnClear" runat="server" CausesValidation="False" CssClass="btn btn-warning"
                                        Height="32px"  TabIndex="10" Text="Cancel" ToolTip="To Clear  the Screen"
                                        Width="90px" />
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2" align="center" style="padding: 5px; margin: 5px; text-align: center;">
                                    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/UI/TSiPASS/frmCFEDepartmentsApprovalProcess.aspx">Back</asp:HyperLink>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2" align="center" style="padding: 5px; margin: 5px">
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
                        <asp:HiddenField ID="hdfFlagID3" runat="server" />
                    </div>
                    <%--       </ContentTemplate>
</asp:UpdatePanel>--%>
                </div>
            </div>
        </div>
    </div>


</asp:Content>

