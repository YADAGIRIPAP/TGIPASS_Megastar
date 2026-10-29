<%@ Page Title=":: TS-iPASS ::  " Language="C#" MasterPageFile="~/UI/TSiPASS/CCMaster.master"AutoEventWireup="true" CodeFile="frmUploadProductDescription.aspx.cs" Inherits="TSTBDCReg1" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>



<%--<script runat="server">

    protected void ddlStatus_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
</script>--%>

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
    </style>

<script type="text/javascript" language="javascript">

function OpenPopup() 
 
   {

    window.open("Lookups/LookupBDC.aspx","List","scrollbars=yes,resizable=yes,width=1000,height=650;display = block;position=absolute");

    return false;
    }
    </script>
    <%-- </div>
       </td>
        </tr>
    </table>--%>
   <%-- </div>
       </td>
        </tr>
    </table>--%>
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
                    <div class="col-lg-11" >
                        <div class="panel panel-primary">
                            <div class="panel-heading" align="center">
                                <h3 class="panel-title">Upload Product Details</h3>
                            </div>
                          <%--   <asp:UpdatePanel ID="UpdatePanel1" runat="server">
<ContentTemplate>--%>
                            <div class="panel-body" >
                                <table align="center" cellpadding="10" cellspacing="5" style="width: 90%">
                                    
                                    <tr>
                                        <td style="padding: 5px; margin: 5px" valign="top">
                                            <asp:Label ID="Label422" runat="server" CssClass="LBLBLACK" Font-Bold="True" 
                                                Width="210px">Upload Product Details</asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="padding: 5px; margin: 5px" valign="top">
                                            <table cellpadding="4" cellspacing="5" style="width: 100%">
                                                <tr>
                                                    <td style="padding: 5px; margin: 5px; text-align: left;">
                                                        1</td>
                                                    <td style="padding: 5px; margin: 5px; text-align: left;">
                                                        <asp:Label ID="Label387" runat="server" CssClass="LBLBLACK" Width="210px">Name 
                                                        of Company</asp:Label>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        :</td>
                                                    <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                        <asp:Label ID="Label447" runat="server"></asp:Label>
                                                   </td>
                                                    <td style="padding: 5px; margin: 5px; width: 10px;">
                                                        &nbsp;</td>
                                                </tr>
                                                <tr>
                                                    <td style="padding: 5px; margin: 5px; text-align: left;">
                                                        2</td>
                                                    <td style="padding: 5px; margin: 5px; text-align: left;">
                                                        <asp:Label ID="Label433" runat="server" CssClass="LBLBLACK" Width="210px">IEC 
                                                        Number</asp:Label>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        :</td>
                                                    <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                         <asp:Label ID="Label448" runat="server"></asp:Label>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px; width: 10px;">
                                                        &nbsp;</td>
                                                </tr>
                                                <tr>
                                                    <td style="padding: 5px; margin: 5px; text-align: left;">
                                                        3</td>
                                                    <td style="padding: 5px; margin: 5px; text-align: left;">
                                                        <asp:Label ID="Label396" runat="server" CssClass="LBLBLACK" Width="165px">Status</asp:Label>
                                                    </td>
                                                   <td style="padding: 5px; margin: 5px">
                                                        :</td>
                                                    <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                         <asp:Label ID="Label449" runat="server"></asp:Label>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px; width: 10px;">
                                                        &nbsp;</td>
                                                </tr>
                                               
                                                <tr>
                                                    <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                        4</td>
                                                    <td style="padding: 5px; margin: 5px; text-align: left;">
                                                        <asp:Label ID="Label435" runat="server" CssClass="LBLBLACK" Width="284px">Commodity</asp:Label>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        :</td>
                                                    <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                         <asp:Label ID="Label450" runat="server"></asp:Label>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px; width: 10px;">
                                                        &nbsp;</td>
                                                </tr>
                                                
                                                <tr>
                                                    <td style="padding: 5px; margin: 5px; text-align: left;" valign="middle">
                                                        5</td>
                                                    <td style="padding: 5px; margin: 5px; text-align: left;">
                                                        <asp:Label ID="Label454" runat="server" CssClass="LBLBLACK" Width="313px">Product 
                                                        Discription</asp:Label>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        :</td>
                                                    <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                        <asp:TextBox ID="txtGeo_Cordinate_Latitude" runat="server" class="form-control txtbox" 
                                                            Height="40px" MaxLength="30"  TabIndex="1" 
                                                            ValidationGroup="group" Width="180px" TextMode="MultiLine"></asp:TextBox>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px; width: 10px;">
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
                                                            ControlToValidate="txtGeo_Cordinate_Latitude" 
                                                            ErrorMessage="Please Enter Reference Number" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                    </td>
                                                </tr>
                                                
                                                <tr>
                                                    <td style="padding: 5px; margin: 5px; text-align: left;" valign="middle">
                                                        6</td>
                                                    <td style="padding: 5px; margin: 5px; text-align: left;">
                                                        <asp:Label ID="Label455" runat="server" CssClass="LBLBLACK" Width="332px">Upload 
                                                        Images<font 
                                                            color="red">*</font></asp:Label>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        :</td>
                                                    <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                         <asp:FileUpload ID="FileUpload1" runat="server" class="form-control txtbox" 
                                                             Height="28px"  />
                                                             
                                                        <asp:HyperLink ID="lblFileName" runat="server" CssClass="LBLBLACK" Width="165px" 
                                                             Target="_blank">[lblFileName]</asp:HyperLink>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px; width: 10px;">
                                                        <asp:Button ID="BtnSave3" runat="server" CssClass="btn btn-xs btn-warning" 
                                                            Height="28px" TabIndex="10" Text="Upload" 
                                                            Width="72px" onclick="BtnSave3_Click" Visible="False" />
                                                    </td>
                                                </tr>
                                                
                                                <tr>
                                                    <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                        7</td>
                                                    <td style="padding: 5px; margin: 5px; text-align: left;">
                                                        <asp:Label ID="Label458" runat="server" CssClass="LBLBLACK" Width="313px">Do you market your product outside state?</asp:Label>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        :</td>
                                                    <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:DropDownList ID="ddlStatus" runat="server" class="form-control txtbox" 
                                                                    Height="33px" TabIndex="1" Width="170px" AutoPostBack="True" 
                                                                    onselectedindexchanged="ddlStatus_SelectedIndexChanged1">
                                                                    <asp:ListItem>--Select--</asp:ListItem>
                                                                    <asp:ListItem>Yes</asp:ListItem>
                                                                    <asp:ListItem>No</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </td>
                                                    <td style="padding: 5px; margin: 5px; width: 10px;">
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" 
                                                            ControlToValidate="ddlStatus" 
                                                            ErrorMessage="Please Select Out side Product" ValidationGroup="group" 
                                                            InitialValue="--Select--">*</asp:RequiredFieldValidator>
                                                                            </td>
                                                </tr>
                                                
                                                <tr id="stateexport" runat="server" visible="false">
                                                    <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                        7</td>
                                                    <td style="padding: 5px; margin: 5px; text-align: left;">
                                                        <asp:Label ID="Label456" runat="server" CssClass="LBLBLACK" Width="313px">State Exported to</asp:Label>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        :</td>
                                                    <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                        <asp:TextBox ID="txtStateName" runat="server" class="form-control txtbox" 
                                                             MaxLength="100"  TabIndex="1" 
                                                            ValidationGroup="group" Width="180px"></asp:TextBox>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px; width: 10px;">
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" 
                                                            ControlToValidate="txtStateName" 
                                                            ErrorMessage="Please Enter StateName" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                    </td>
                                                </tr>
                                                
                                                <tr >
                                                    <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                        8</td>
                                                    <td style="padding: 5px; margin: 5px; text-align: left;">
                                                        <asp:Label ID="Label459" runat="server" CssClass="LBLBLACK" Width="313px">Do you export your product?</asp:Label>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        :</td>
                                                    <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:DropDownList ID="ddlStatus0" runat="server" class="form-control txtbox" 
                                                                    Height="33px" TabIndex="1" Width="170px" AutoPostBack="True" 
                                                            onselectedindexchanged="ddlStatus0_SelectedIndexChanged">
                                                                    <asp:ListItem>--Select--</asp:ListItem>
                                                                    <asp:ListItem>Yes</asp:ListItem>
                                                                    <asp:ListItem>No</asp:ListItem>
                                                                </asp:DropDownList>
                                                                            </td>
                                                    <td style="padding: 5px; margin: 5px; width: 10px;">
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" 
                                                            ControlToValidate="ddlStatus0" 
                                                            ErrorMessage="Please Select export your Product" ValidationGroup="group" 
                                                            InitialValue="--Select--">*</asp:RequiredFieldValidator>
                                                                            </td>
                                                </tr>
                                                
                                                <tr id="CountryExport" runat="server" visible="false" >
                                                    <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                        8</td>
                                                    <td style="padding: 5px; margin: 5px; text-align: left;">
                                                        <asp:Label ID="Label457" runat="server" CssClass="LBLBLACK" Width="313px">Countries Exported to</asp:Label>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        :</td>
                                                    <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                        <asp:TextBox ID="txtCountries" runat="server" class="form-control txtbox" 
                                                            MaxLength="100"  TabIndex="1" 
                                                            ValidationGroup="group" Width="180px"></asp:TextBox>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px; width: 10px;">
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" 
                                                            ControlToValidate="txtCountries" 
                                                            ErrorMessage="Please Enter Countries Name" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                    </td>
                                                </tr>
                                                </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="padding: 5px; margin: 5px" valign="top" align="left">
                                            &nbsp;</td>
                                    </tr>
                                           
                                    <tr>
                                        <td align="center" 
                                            style="padding: 5px; margin: 5px; text-align: center;">
                                            &nbsp;&nbsp;<asp:Button ID="BtnSave1" runat="server" CssClass="btn btn-primary" 
                                                Height="32px" onclick="BtnSave_Click" TabIndex="10" Text="Submit" 
                                                ValidationGroup="group" Width="90px" />
                                            &nbsp;&nbsp;<asp:Button ID="BtnClear" runat="server" CausesValidation="False" 
                                                CssClass="btn btn-warning" Height="32px" onclick="BtnClear_Click1" TabIndex="10" 
                                                Text="Cancel" ToolTip="To Clear  the Screen" Width="90px" 
                                                Visible="False" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center" 
                                            style="padding: 5px; margin: 5px; text-align: center;">
                                            <asp:HyperLink ID="HyperLink1" runat="server" 
                                                NavigateUrl="~/UI/TSiPASS/frmVATExportGM.aspx">Back</asp:HyperLink>
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
         <%-- <asp:UpdateProgress ID="UpdateProgress" runat="server" AssociatedUpdatePanelID="updatepanel1">
<ProgressTemplate>--%>
<%--<div class="overlay">--%>
<%--<div style=" z-index: 1000; margin-left: 350px;margin-top:200px;opacity: 1;-moz-opacity: 1;">--%>  
<%--<div style=" z-index: 1000; margin-left: -210px;margin-top:100px;opacity: 1; -moz-opacity: 1;">--%>
<%--<img alt="" src="../../Resource/Images/Processing.gif" />
--%>
</div>
    
</div>
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

