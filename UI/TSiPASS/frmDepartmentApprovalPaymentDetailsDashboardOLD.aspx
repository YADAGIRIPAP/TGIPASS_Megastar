<%@ Page Title=":: TS-iPASS ::  " Language="C#" MasterPageFile="~/UI/TSiPASS/CCMaster.master" AutoEventWireup="true" CodeFile="frmDepartmentApprovalPaymentDetailsDashboardOLD.aspx.cs" Inherits="TSTBDCReg1" %>

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
    .style7
    {
        color: #FF3300;
    }
    .style8
    {
        color: #FF0000;
        font-weight: bold;
    }
    
    
    
.GRD
{
	width:800px;
	height:auto;
	border-color:#013161;
	border-style:solid;
	border-width:1px;
text-transform:capitalize;
padding:5px;
}

.GRDHEADER	
{
	    border: 1px solid #ffffff;
            color:#0E2A46;
	        vertical-align:middle;
	        text-align:center;
	        height:25px;
	        width:50px;
	        padding:10px;
	        font-size:	12px;
	        font-weight: bold;
	        text-transform:capitalize;
	        font-family: Verdana;	
	BACKGROUND-IMAGE: url('../../Resource/Styles/images/bg_blue_grd.gif');
	}
.GRDITEM
	{
	/*background-color: WHITE;*/
	color:black;	
	font-size:	12px;
	font-weight: normal;
	font-family:Verdana;
	padding:10px;
	/*text-decoration:none;*/
	/*border-color:#013161;*/
	/*border-style:solid;*/
	text-transform:uppercase;
	/*border-width:1px;*/
	/*height:23px;*/
	/*text-indent:5px;*/
	
	/*BACKGROUND-IMAGE: url(../images/grid_bg_.gif);*/
	}

    </style>

<script type="text/javascript" language="javascript">

function OpenPopup() 
 
   {

    window.open("Lookups/LookupBDC.aspx","List","scrollbars=yes,resizable=yes,width=1000,height=650;display = block;position=absolute");

    return false;
    }
    </script>
 <script type="text/javascript">
    function txtDOB()
{
var trdat=document.getElementById("ctl00_ContentPlaceHolder1_txtDOB").value;
if(trdat !="" || trdat != null || trdat != '')
{
var tranDate = isValidDate(document.getElementById("ctl00_ContentPlaceHolder1_txtDOB").value,'Date of Formation ');
if(tranDate == false)
{
document.getElementById("ctl00_ContentPlaceHolder1_txtDOB").focus();
document.getElementById("ctl00_ContentPlaceHolder1_txtDOB").value='';
return false;
}
}
}
</script>

    <%--<asp:UpdatePanel ID="upd1" runat="server">
<ContentTemplate>
--%><div align="left">
    <ol class="breadcrumb">You are here
        &nbsp;!&nbsp; &nbsp; &nbsp; 
                            <li>
                                <i class="fa fa-dashboard"></i>  <a href="Home.aspx"></a>
                            </li>
                            <li class="">
                                <i class="fa fa-fw fa-edit">CAF</i> 
                            </li>
                            <li class="active">
                                <i class="fa fa-edit"></i> <a href="#">Departments Payments</a>
                            </li>
                        </ol>
     </div>
    
<div align="left">
<div class="row" align="left">
                    <div class="col-lg-11" >
                        <div class="panel panel-primary">
                            <div class="panel-heading" align="center">
                                <h3 class="panel-title">Department Payments</h3>
                            </div>
    <%--                         <asp:UpdatePanel ID="UpdatePanel1" runat="server">
<ContentTemplate>--%>
                            <div class="panel-body" >
                                <table align="center" cellpadding="10" cellspacing="5" style="width: 90%">
                                    
                                    <tr>
                                        <td style="padding: 5px; margin: 5px" valign="top" class="style8" colspan="3">
                                            &nbsp;</td>
                                    </tr>
                                    
                                    <tr>
                                        <td style="padding: 5px; margin: 5px" valign="top" class="style8" colspan="3">
                                            <asp:GridView ID="grdDetails0" runat="server" AutoGenerateColumns="False" 
                                                CellPadding="4" CssClass="GRD" ForeColor="#333333" Height="62px" PageSize="15" 
                                                Width="100%" CellSpacing="4">
                                                <footerstyle backcolor="#013161" font-bold="True" forecolor="White" />
                                                <rowstyle backcolor="#EBF2FE" cssclass="GRDITEM" horizontalalign="Left" 
                                                    verticalalign="Middle" />
                                                <columns>
                                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S No">
                                                        <ItemTemplate>
                                                            <%# Container.DataItemIndex + 1%>
                                                            <asp:HiddenField ID="HdfQueid0" runat="server" />
                                                            <asp:HiddenField ID="HdfApprovalid0" runat="server" />
                                                            <asp:HiddenField ID="HdfDeptid0" runat="server" />
                                                        </ItemTemplate>
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                        <ItemStyle Width="50px" />
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="ApprovalName" HeaderText="Approval Required for">
                                                        <ItemStyle Width="450px" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="Dept_Full_name" HeaderText="Department Name">
                                                        <ItemStyle Width="180px" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="Fees" DataFormatString="{0:0}" ControlStyle-CssClass="col-md-6"  ItemStyle-HorizontalAlign="Right" 
                                                        FooterStyle-HorizontalAlign="Right" HeaderText="Fees(Rs.)">
                                                        <ControlStyle CssClass="col-md-6" />
                                                        <FooterStyle HorizontalAlign="Right" />
                                                        <HeaderStyle HorizontalAlign="Right" />
                                                        <ItemStyle HorizontalAlign="Right" Width="150px" />
                                                    </asp:BoundField>
                                                    
                                                    <%--<asp:BoundField HeaderText="Amount(Rs.)" />--%>
                                                </columns>
                                                <pagerstyle backcolor="#013161" forecolor="White" horizontalalign="Center" />
                                                <selectedrowstyle backcolor="#D1DDF1" font-bold="True" forecolor="#333333" />
                                                <headerstyle backcolor="#013161" cssclass="GRDHEADER" font-bold="True" 
                                                    forecolor="White" />
                                                <editrowstyle backcolor="#B9D684" />
                                                <alternatingrowstyle backcolor="White" />
                                            </asp:GridView>
                                        </td>
                                    </tr>
                                    
                                    <tr>
                                        <td style="padding: 5px; margin: 5px" valign="top" class="style8" colspan="3">
                                            Select the approvals for which you wish to make payment now 
                                            <asp:HiddenField ID="Hdfeid" runat="server" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="padding: 5px; margin: 5px" valign="top" colspan="3">
                                        <div class="GRD" style="width: 100%">
                                            <asp:GridView ID="grdDetails" runat="server" AutoGenerateColumns="False" 
                                                CellPadding="4" CssClass="GRD" ForeColor="#333333" Height="62px" 
                                                onrowdatabound="grdDetails_RowDataBound" PageSize="15" 
                                                Width="100%" CellSpacing="4">
                                                <footerstyle backcolor="#013161" font-bold="True" forecolor="White" />
                                                <rowstyle backcolor="#EBF2FE" cssclass="GRDITEM" horizontalalign="Left" 
                                                    verticalalign="Middle" />
                                                <columns>
                                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S No">
                                                        <ItemTemplate>
                                                            <%# Container.DataItemIndex + 1%>
                                                            <asp:HiddenField ID="HdfQueid" runat="server" />
                                                            <asp:HiddenField ID="HdfApprovalid" runat="server" />
                                                            <asp:HiddenField ID="HdfDeptid" runat="server" />
                                                        </ItemTemplate>
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                        <ItemStyle Width="50px" />
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="ApprovalName" HeaderText="Approval Required for">
                                                        <ItemStyle Width="450px" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="Dept_Full_name" HeaderText="Department Name">
                                                        <ItemStyle Width="180px" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="Fees" DataFormatString="{0:0}" ControlStyle-CssClass="col-md-6"  ItemStyle-HorizontalAlign="Right" 
                                                        FooterStyle-HorizontalAlign="Right" HeaderText="Fees(Rs.)">
                                                        <ControlStyle CssClass="col-md-6" />
                                                        <FooterStyle HorizontalAlign="Right" />
                                                        <HeaderStyle HorizontalAlign="Right" />
                                                        <ItemStyle HorizontalAlign="Right" Width="150px" />
                                                    </asp:BoundField>
                                                    <asp:TemplateField HeaderText="Pay for Department">
                                                        <ItemTemplate>
                                                            <asp:CheckBox ID="ChkApproval" runat="server" AutoPostBack="True" 
                                                                oncheckedchanged="ChkApproval_CheckedChanged" />
                                                            <asp:HiddenField ID="HdfAmount" runat="server" 
                                                                onvaluechanged="HdfAmount_ValueChanged" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:BoundField HeaderText="Amount(Rs.)" />
                                                </columns>
                                                <pagerstyle backcolor="#013161" forecolor="White" horizontalalign="Center" />
                                                <selectedrowstyle backcolor="#D1DDF1" font-bold="True" forecolor="#333333" />
                                                <headerstyle backcolor="#013161" cssclass="GRDHEADER" font-bold="True" 
                                                    forecolor="White" />
                                                <editrowstyle backcolor="#B9D684" />
                                                <alternatingrowstyle backcolor="White" />
                                            </asp:GridView>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="padding: 5px; margin: 5px" align="center" class="style7" colspan="3">
                                            <asp:Label ID="Label422" runat="server" CssClass="LBLBLACK" Font-Bold="True" 
                                                Width="210px">Payment Details<font 
                                                            color="red">*</font></asp:Label>
                                            <asp:HiddenField ID="HdfA" runat="server" />
                                            <tr>
                                        <td style="padding: 5px; margin: 5px" align="center">
                                            <asp:RadioButtonList ID="rblPaymentMode" runat="server" AutoPostBack="True" 
                                                Font-Bold="True" Font-Names="Verdana" 
                                                onselectedindexchanged="RadioButtonList1_SelectedIndexChanged" 
                                                RepeatDirection="Horizontal" Width="350px">
                                                <asp:ListItem>Demand Draft</asp:ListItem>
                                                <asp:ListItem>Online</asp:ListItem>
                                            </asp:RadioButtonList>
                                                </td>
                                        <td style="padding: 5px; margin: 5px" align="center">
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                                                            ControlToValidate="rblPaymentMode" ErrorMessage="Please Select Payment Mode" 
                                                            ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                </td>
                                        <td style="padding: 5px; margin: 5px" align="center">
                                            &nbsp;</td>
                                    </tr> 
                                            <caption>
                                                &nbsp;</caption>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center" style="padding: 5px; margin: 5px" colspan="3">
                                            <table cellpadding="4" cellspacing="5" style="width: 83%" runat="server" id="paynot" >
                                                <tr ID="amt" runat="server">
                                                    <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                        &nbsp;</td>
                                                    <td style="padding: 5px; margin: 5px; text-align: left;">
                                                        <asp:Label ID="Label428" runat="server" CssClass="LBLBLACK" Width="200px">Amount<font 
                                                            color="red">*</font></asp:Label>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        :</td>
                                                    <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                        <asp:TextBox ID="txtAmount" runat="server" 
                                                            class="form-control txtbox" Enabled="False" Height="28px" MaxLength="8" 
                                                            onkeypress="NumberOnly()" TabIndex="1" ValidationGroup="group" 
                                                            Width="180px"></asp:TextBox>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px; width: 10px;">
                                                        &nbsp;</td>
                                                </tr>
                                                <tr ID="DD" runat="server" >
                                                    <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                        &nbsp;</td>
                                                    <td style="padding: 5px; margin: 5px; text-align: left;">
                                                        <asp:Label ID="Label426" runat="server" CssClass="LBLBLACK" Width="200px">DD Number<font 
                                                            color="red">*</font></asp:Label>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        :</td>
                                                    <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                        <asp:TextBox ID="txtDDNumber" runat="server" 
                                                            class="form-control txtbox" Height="28px" MaxLength="10" 
                                                            onkeypress="NumberOnly()" TabIndex="1" ValidationGroup="group" 
                                                            Width="180px"></asp:TextBox>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px; width: 10px;">
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                                            ControlToValidate="txtDDNumber" ErrorMessage="Please enter DD Number" 
                                                            ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                                            </td>
                                                </tr>
                                                <tr ID="chq" runat="server" >
                                                    <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                        &nbsp;</td>
                                                    <td style="padding: 5px; margin: 5px; text-align: left;">
                                                        <asp:Label ID="Label432" runat="server" CssClass="LBLBLACK" Width="200px">DD Date<font 
                                                            color="red">*</font></asp:Label>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        :</td>
                                                    <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                        <asp:TextBox ID="txtDDDate" runat="server" class="form-control txtbox" 
                                                            Height="28px" MaxLength="40" TabIndex="1" ValidationGroup="group"  onchange ="return txtDOB();"
                                                            Width="180px"></asp:TextBox>
                                                        <cc1:CalendarExtender ID="txtDDDate_CalendarExtender" runat="server" 
                                                            Format="dd-MM-yyyy" PopupButtonID="txtRegDate" TargetControlID="txtDDDate">
                                                        </cc1:CalendarExtender>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px; width: 10px;">
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                                            ControlToValidate="txtDDDate" ErrorMessage="Please enter DD Date" 
                                                            ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                                            </td>
                                                </tr>
                                                <tr>
                                                    <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                        &nbsp;</td>
                                                    <td style="padding: 5px; margin: 5px; text-align: left;">
                                                        <asp:Label ID="Label427" runat="server" CssClass="LBLBLACK" Width="200px">Bank Name<font 
                                                            color="red">*</font></asp:Label>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        :</td>
                                                    <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                        <asp:TextBox ID="txtBankName" runat="server" 
                                                            class="form-control txtbox" Height="28px" MaxLength="40" 
                                                            TabIndex="1" ValidationGroup="group" 
                                                            Width="180px"></asp:TextBox>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px; width: 10px;">
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                                                            ControlToValidate="txtBankName" ErrorMessage="Please enter Bank Name" 
                                                            ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                                            </td>
                                                </tr>
                                                <tr>
                                                    <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                        &nbsp;</td>
                                                    <td style="padding: 5px; margin: 5px; text-align: left;">
                                                        <asp:Label ID="Label431" runat="server" CssClass="LBLBLACK" Width="200px">Bank Brach Name<font 
                                                            color="red">*</font></asp:Label>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        :</td>
                                                    <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                        <asp:TextBox ID="txtBankBranchName" runat="server" 
                                                            class="form-control txtbox" Height="28px" MaxLength="40" 
                                                            TabIndex="1" ValidationGroup="group" 
                                                            Width="180px"></asp:TextBox>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px; width: 10px;">
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                                                            ControlToValidate="txtBankBranchName" 
                                                            ErrorMessage="Please enter Bank Branch Name" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                                            </td>
                                                </tr>
                                                <tr>
                                                    <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                        &nbsp;</td>
                                                    <td style="padding: 5px; margin: 5px; text-align: left;">
                                                        <asp:Label ID="Label433" runat="server" CssClass="LBLBLACK" Width="200px">Upload 
                                                        DD<font color="red">*</font></asp:Label>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        :</td>
                                                    <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                        <asp:FileUpload ID="FileUpload1" runat="server" class="form-control txtbox" 
                                                            Height="28px" />
                                                            
                                                        <asp:HyperLink ID="lblFileName" runat="server" CssClass="LBLBLACK" Width="165px"></asp:HyperLink>
                                                        <br />
                                                        <asp:Label ID="Label434" runat="server" Visible="False"></asp:Label>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px; width: 10px;">
                                                        <asp:Button ID="BtnSave3" runat="server" CssClass="btn btn-xs btn-warning" 
                                                            Height="28px" onclick="BtnSave3_Click" TabIndex="10" Text="Upload" 
                                                            Width="72px" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                        &nbsp;</td>
                                                    <td style="padding: 5px; margin: 5px; text-align: left;" colspan="4">
                                                        &nbsp;</td>
                                                </tr>
                                            </table>
                                            <table cellpadding="4" cellspacing="5" style="width: 83%" runat="server" 
                                                id="paynotOnline" >
                                                <tr ID="amt0" runat="server">
                                                    <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                        &nbsp;</td>
                                                    <td style="padding: 5px; margin: 5px; text-align: left;">
                                                        <asp:Label ID="Label435" runat="server" CssClass="LBLBLACK" Width="200px">Amount<font 
                                                            color="red">*</font></asp:Label>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        :</td>
                                                    <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                        <asp:TextBox ID="TxtAmountOnline" runat="server" 
                                                            class="form-control txtbox" Enabled="False" Height="28px" MaxLength="8" 
                                                            onkeypress="NumberOnly()" TabIndex="1" ValidationGroup="group" 
                                                            Width="180px"></asp:TextBox>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px; width: 10px;">
                                                        &nbsp;</td>
                                                </tr>
                                                <tr>
                                                    <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                        &nbsp;</td>
                                                    <td style="padding: 5px; margin: 5px; text-align: left;" colspan="4">
                                            <asp:RadioButtonList ID="rdbOnlineBankType" runat="server" 
                                                Font-Bold="True" Font-Names="Verdana" 
                                                onselectedindexchanged="RadioButtonList1_SelectedIndexChanged" 
                                                RepeatDirection="Horizontal" Width="350px">
                                                <asp:ListItem>SBI</asp:ListItem>
                                                <asp:ListItem>ICICI</asp:ListItem>
                                            </asp:RadioButtonList>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center" 
                                            style="padding: 5px; margin: 5px; text-align: center;" colspan="3">
                                            <asp:Button ID="BtnSave1" runat="server" CssClass="btn btn-primary" 
                                                Height="32px" onclick="BtnSave_Click" TabIndex="10" Text="Pay" 
                                                ValidationGroup="group" Width="90px" Visible="False" />
                                            &nbsp;&nbsp;<asp:Button ID="BtnDelete" runat="server" 
                                                CssClass="btn btn-danger" Height="32px" onclick="BtnClear0_Click" TabIndex="10" 
                                                Text="Pay" Width="90px" ValidationGroup="group" 
                                                />
                                            &nbsp;<asp:Button ID="BtnClear" runat="server" CausesValidation="False" 
                                                CssClass="btn btn-warning" Height="32px" onclick="BtnClear_Click" TabIndex="10" 
                                                Text="ClearAll" ToolTip="To Clear  the Screen" Width="90px" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center" style="padding: 5px; margin: 5px" colspan="3">
                                            
                                            
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
                                <asp:HiddenField ID="hdfUIDNumber" runat="server" />
                            </div>
   <%--                          </ContentTemplate>
</asp:UpdatePanel>--%>
                        </div>
                    </div>
                </div>

    </div>
    <%--        <asp:UpdateProgress ID="UpdateProgress" runat="server" AssociatedUpdatePanelID="updatepanel1">
<ProgressTemplate>
<div class="overlay">--%>
<%--<div style=" z-index: 1000; margin-left: 350px;margin-top:200px;opacity: 1;-moz-opacity: 1;">--%>
<%--<div style=" z-index: 1000; margin-left: 250px;margin-top:100px;opacity: 1; -moz-opacity: 1;">
<img alt="" src="../../Resource/Images/Processing.gif" />--%>

<%--</div>
    
</div>
</ProgressTemplate>
</asp:UpdateProgress>   
--%>                 
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
          
<%--                       
  </ContentTemplate>
  </asp:UpdatePanel>--%>
 <%--</div>
       </td>
        </tr>
    </table>--%>
</asp:Content>

