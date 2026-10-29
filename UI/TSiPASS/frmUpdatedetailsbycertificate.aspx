<%@ Page Title=":: TS-iPASS ::  " Language="C#" MasterPageFile="~/UI/TSiPASS/CCMaster.master" AutoEventWireup="true" CodeFile="frmUpdatedetailsbycertificate.aspx.cs" Inherits="TSTBDCReg1" %>

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
    <%--   <asp:UpdatePanel ID="UpdatePanel1" runat="server">
<ContentTemplate>--%>   <%--       </ContentTemplate>
</asp:UpdatePanel>--%>
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
                                <h3 class="panel-title">Update Certificate Details</h3>
                            </div>
                            <%-- <asp:UpdateProgress ID="UpdateProgress" runat="server" AssociatedUpdatePanelID="updatepanel1">
<ProgressTemplate>--%>
                            <div class="panel-body" >
                                <table align="center" cellpadding="10" cellspacing="5" style="width: 90%">
                                    
                                    <tr>
                                        <td style="padding: 5px; margin: 5px" valign="top">
                                            <asp:Label ID="Label422" runat="server" CssClass="LBLBLACK" Font-Bold="True" 
                                                Width="210px">Upload Certificate</asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="padding: 5px; margin: 5px" valign="top">
                                            <table cellpadding="4" cellspacing="5" style="width: 80%">
                                                <tr>
                                                    <td style="padding: 5px; margin: 5px; text-align: left; width: 10px;">
                                                        1</td>
                                                    <td style="padding: 5px; margin: 5px; text-align: left; width: 250px;">
                                                        <asp:Label ID="Label457" runat="server" CssClass="LBLBLACK" Width="210px">Name of Unit<font 
                                                            color="red">*</font></asp:Label>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px; width: 10px;">
                                                        :</td>
                                                    <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                        <asp:TextBox ID="txtnameofUnit" runat="server" class="form-control txtbox" 
                                                            Height="44px" MaxLength="100" TabIndex="1" 
                                                            ValidationGroup="group" Width="190px" TextMode="MultiLine"></asp:TextBox>
                                                   </td>
                                                    <td style="padding: 5px; margin: 5px; width: 10px;">
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                                            ControlToValidate="txtnameofUnit" ErrorMessage="Please ente Name of Unit" 
                                                            ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="padding: 5px; margin: 5px; text-align: left; width: 10px;">
                                                        2&nbsp;</td>
                                                    <td style="padding: 5px; margin: 5px; text-align: left; width: 250px;">
                                                        <asp:Label ID="Label387" runat="server" CssClass="LBLBLACK" Width="210px">UID Number<font 
                                                            color="red">*</font></asp:Label>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px; width: 10px;">
                                                        :</td>
                                                    <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                        <asp:TextBox ID="txtUID" runat="server" class="form-control txtbox" 
                                                            Height="28px" MaxLength="30" TabIndex="1" 
                                                            ValidationGroup="group" Width="190px"></asp:TextBox>
                                                   </td>
                                                    <td style="padding: 5px; margin: 5px; width: 10px;">
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                                                            ControlToValidate="txtUID" ErrorMessage="Please enter UID number" 
                                                            ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="padding: 5px; margin: 5px; text-align: left; width: 10px;">
                                                        3</td>
                                                    <td style="padding: 5px; margin: 5px; text-align: left; width: 250px;">
                                                        <asp:Label ID="Label458" runat="server" CssClass="LBLBLACK" Width="210px">Location of Unit<font 
                                                            color="red">*</font></asp:Label>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px; width: 10px;">
                                                        :</td>
                                                    <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                        <asp:DropDownList ID="ddlLand_intDistrictid" runat="server" 
                                                            class="form-control txtbox" Height="33px" Width="190px" TabIndex="1">
                                                            <asp:ListItem>--Select--</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px; width: 10px;">
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                                                            ControlToValidate="ddlLand_intDistrictid" ErrorMessage="Please Select District" 
                                                            InitialValue="--Select--" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="padding: 5px; margin: 5px; text-align: left; width: 10px;">
                                                        4</td>
                                                    <td style="padding: 5px; margin: 5px; text-align: left; width: 250px;">
                                                        <asp:Label ID="Label8" runat="server" CssClass="LBLBLACK" Width="280px">Pollution Category of Enterprise<font 
                                                            color="red">*</font></asp:Label>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px; width: 10px;">
                                                        :</td>
                                                    <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                        <asp:DropDownList ID="ddlLand_intDistrictid0" runat="server" 
                                                            class="form-control txtbox" Height="33px" Width="190px" TabIndex="1">
                                                            <asp:ListItem>--Select--</asp:ListItem>
                                                            <asp:ListItem Value="Orange">Orange</asp:ListItem>
                                                            <asp:ListItem Value="Red">Red</asp:ListItem>
                                                            <asp:ListItem>Green</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px; width: 10px;">
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                                                            ControlToValidate="ddlLand_intDistrictid0" 
                                                            ErrorMessage="Please Select Pollution Category" InitialValue="--Select--" 
                                                            ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="padding: 5px; margin: 5px; text-align: left; width: 10px;">
                                                        5&nbsp;</td>
                                                    <td style="padding: 5px; margin: 5px; text-align: left; width: 250px;">
                                                        <asp:Label ID="Label396" runat="server" CssClass="LBLBLACK" Width="165px">Address<font 
                                                            color="red">*</font></asp:Label>
                                                    </td>
                                                   <td style="padding: 5px; margin: 5px; width: 10px;">
                                                        :</td>
                                                    <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                        <asp:TextBox ID="txtaddress" runat="server" class="form-control txtbox" 
                                                            Height="40px" MaxLength="200" TabIndex="1" 
                                                            ValidationGroup="group" Width="190px" TextMode="MultiLine"></asp:TextBox>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px; width: 10px;">
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
                                                            ControlToValidate="txtaddress" ErrorMessage="Please enter Address" 
                                                            ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                    </td>
                                                </tr>
                                               
                                                <tr>
                                                    <td style="padding: 5px; margin: 5px; text-align: left; width: 10px;" 
                                                        valign="middle">
                                                        6</td>
                                                    <td style="padding: 5px; margin: 5px; text-align: left; width: 250px;">
                                                        <asp:Label ID="Label459" runat="server" CssClass="LBLBLACK" Width="332px">Upload Certificate<font 
                                                            color="red">*</font></asp:Label>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px; width: 10px;">
                                                        :</td>
                                                    <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                         <asp:FileUpload ID="fupWork1" runat="server" CssClass="TXTBOX" Height="28px" 
                                                             onchange="this.form.submit();" tabIndex="1" Width="180px" />
                                                         <br />
                                                         <asp:Label ID="lbl1" runat="server" CssClass="LBLBLACK" Width="145px"></asp:Label>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px; width: 10px;">
                                                        &nbsp;</td>
                                                </tr>
                                                
                                                </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="padding: 5px; margin: 5px" valign="top" align="left">
                                            &nbsp;</td>
                                    </tr>
                                            <caption>
                                                &nbsp;</caption>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center" 
                                            style="padding: 5px; margin: 5px; text-align: center;">
                                            &nbsp;&nbsp;<asp:Button ID="BtnSave1" runat="server" CssClass="btn btn-primary" 
                                                Height="32px" onclick="BtnSave_Click" TabIndex="10" Text="Submit" 
                                                ValidationGroup="group" Width="90px" />
                                            &nbsp;&nbsp;<asp:Button ID="BtnClear" runat="server" CausesValidation="False" 
                                                CssClass="btn btn-warning" Height="32px" onclick="BtnClear_Click1" TabIndex="10" 
                                                Text="Cancel" ToolTip="To Clear  the Screen" Width="90px" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center" 
                                            style="padding: 5px; margin: 5px; text-align: center;">
                                            &nbsp;</td>
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
                                <asp:HiddenField ID="hdfUploadFile1" runat="server" />
                            </div>
                            <%--<div class="overlay">--%>
                        </div>
                    </div>
                </div>

    </div>
    <%--<div style=" z-index: 1000; margin-left: 350px;margin-top:200px;opacity: 1;-moz-opacity: 1;">--%> <%--<div style=" z-index: 1000; margin-left: -210px;margin-top:100px;opacity: 1; -moz-opacity: 1;">--%> <%--<img alt="" src="../../Resource/Images/Processing.gif" />
--%> <%--</ProgressTemplate>
</asp:UpdateProgress> --%> <%--</ContentTemplate>
  </asp:UpdatePanel>--%>
</div>
    
</div>
    <%-- </div>
       </td>
        </tr>
    </table>--%>
                 
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

