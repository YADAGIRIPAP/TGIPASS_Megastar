<%@ Page Title=":: TS-iPASS :: MSME Catalogue  " Language="C#" MasterPageFile="~/UI/TSiPASS/EmptyMaster.master"AutoEventWireup="true" CodeFile="LoanReport.aspx.cs" Inherits="TSTBDCReg1" %>

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
    .style5
    {
        width: 100%;
    }
    .style6
    {
        width: 2px;
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
    function showProgress() {
        var updateProgress = $get("<%= UpdateProgress.ClientID %>");
        updateProgress.style.display = "block";
    }
</script>

    <asp:UpdatePanel ID="upd1" runat="server">
<ContentTemplate>
<div align="left">
    <ol class="breadcrumb">You are here
        &nbsp;!&nbsp; &nbsp; &nbsp; 
                            <li>
                                <i class="fa fa-dashboard"></i>  <a href="Home.aspx"></a>
                            </li>
                            <li class="">
                                <i class="fa fa-fw fa-edit"></i> 
                            </li>
                            <li class="active">
                                <i class="fa fa-edit"></i> <a href="#">Bank Loans Report</a>
                            </li>
                        </ol>
     </div>
    
<div align="left">
<div class="row" align="left">
                    <div class="col-lg-11" >
                        <div class="panel panel-primary">
                            <div class="panel-heading" align="center">
                                <h3 class="panel-title">Bank Loans Report</h3>
                            </div>
                             <asp:UpdatePanel ID="UpdatePanel1" runat="server">
<ContentTemplate>
                            <div class="panel-body" >
                                <table align="center" cellpadding="10" cellspacing="5" style="width: 98%">
                                    
                                    <tr>
                                        <td align="left" style="padding: 5px; margin: 5px" valign="top">
                                            <table class="style5">
                                                <tr>
                                                    <td>
                                                        &nbsp;</td>
                                                    <td>
                                                        <table class="style5" cellpadding="7" cellspacing="7">
                                                            <tr>
                                                                <td height="40px">
                                                                    <asp:Label ID="Label456" runat="server" CssClass="LBLBLACK" Width="200px">Name 
 of the Applicant</asp:Label>
                                                                </td>
                                                                <td class="style6">
                                                                    :</td>
                                                                <td>
                                                                     <asp:TextBox ID="txtNameofUnit" runat="server" class="form-control txtbox" 
                                                                         Height="28px" MaxLength="100" TabIndex="1" ValidationGroup="group" 
                                                                         Width="180px"></asp:TextBox>
                                                                        
                                                                </td>
                                                                <td>
                                                                    &nbsp;</td>
                                                            </tr>
                                                            <tr>
                                                                <td height="40px">
                                                                    &nbsp;</td>
                                                                <td class="style6">
                                                                    &nbsp;</td>
                                                                <td>
                                                                    &nbsp;</td>
                                                                <td>
                                                                    &nbsp;</td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                    <td valign="top">
                                                        
                                                        <table cellpadding="7" cellspacing="7" class="style5">
                                                            <tr>
                                                                <td height="40px">
                                                                    <asp:Label ID="Label565" runat="server" CssClass="LBLBLACK" 
                                                                        Width="100px">District Name:</asp:Label>
                                                                </td>
                                                                <td>
                                                                    :</td>
                                                                <td>
                                                                    <asp:DropDownList ID="ddldist" runat="server" class="form-control txtbox" 
                                                                        Height="33px" TabIndex="1" Width="170px">
                                                                        <asp:ListItem>--Select--</asp:ListItem>
                                                                    </asp:DropDownList>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td height="40px">
                                                                    &nbsp;</td>
                                                                <td>
                                                                    &nbsp;</td>
                                                                <td>
                                                                    &nbsp;</td>
                                                            </tr>
                                                        </table>
                                                        
                                                    </td>
                                                    <td>
                                                        &nbsp;</td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        &nbsp;&nbsp;</td>
                                                    <td align="right" style="text-align: right">
                                                        <asp:Button ID="BtnSave1" runat="server" CssClass="btn btn-primary" 
                                                            Height="32px" OnClick="BtnSave1_Click" TabIndex="10" Text="Search" 
                                                            ValidationGroup="group" Width="90px" />
                                                        &nbsp;</td>
                                                    <td>
                                                        &nbsp;
                                                        <asp:Button ID="BtnClear" runat="server" CausesValidation="False" 
                                                            CssClass="btn btn-warning" Height="32px" onclick="BtnClear_Click" TabIndex="10" 
                                                            Text="Cancel" ToolTip="To Clear  the Screen" Width="90px" />
                                                    </td>
                                                    <td>
                                                        &nbsp;</td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        &nbsp;</td>
                                                    <td align="right" style="text-align: right">
                                                        &nbsp;</td>
                                                    <td>
                                                        <asp:Label ID="lblstate11" runat="server" CssClass="LBLBLACK" Font-Bold="True" 
                                                            Font-Size="14px" ForeColor="Black" Width="200px"></asp:Label>
                                                    </td>
                                                    <td>
                                                        &nbsp;</td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left" style="padding: 5px; margin: 5px" valign="top">
                                        <asp:Panel ID="Panel1" runat="server"  ScrollBars="Both"  style="width:1200px" Height="600px">
                                            <asp:GridView ID="grdDetails" runat="server"
                                                CellPadding="5" CssClass="GRD" ForeColor="#333333" Height="62px" 
                                                onrowdatabound="grdDetails_RowDataBound" ShowFooter="True" Width="100%">
                                                <footerstyle backcolor="#013161" font-bold="True" forecolor="White" />
                                                <rowstyle backcolor="#EBF2FE" horizontalalign="Left" verticalalign="Middle"  />
                                                <columns>
                                                <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S No">
                                                                <ItemTemplate>
                                                                    <%# Container.DataItemIndex + 1%>
                                                                    <asp:HiddenField ID="HdfQueid" runat="server" />
                                                                    <asp:HiddenField ID="HdfApprovalid" runat="server" />
                                                                </ItemTemplate>
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                <ItemStyle Width="50px" />
                                                            </asp:TemplateField>
                                                           
                                                            
                                                </columns>
                                                <pagerstyle backcolor="#013161" forecolor="White" horizontalalign="Center" />
                                                <selectedrowstyle backcolor="#D1DDF1" font-bold="True" forecolor="#333333" />
                                                <headerstyle backcolor="#013161" font-bold="True" forecolor="White" />
                                                <editrowstyle backcolor="#B9D684" />
                                                <alternatingrowstyle backcolor="White" />
                                            </asp:GridView>
                                            </asp:Panel> 
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="padding: 5px; margin: 5px" align="center">
                                            &nbsp;<tr>
                                                <td align="center" style="padding: 5px; margin: 5px">
                                                    &nbsp;</td>
                                            </tr>
                                            <caption>
                                                &nbsp;</caption>
                                            </td>
                                    </tr>
                                    <tr>
                                        <td style="padding: 5px; margin: 5px" align="center">
                                            <div ID="success" runat="server" class="alert alert-success" visible="false">
                                                <a aria-label="close" class="close" data-dismiss="alert" 
                                                    href="AddQualification.aspx">×</a> <strong>Success!</strong><asp:Label 
                                                    ID="lblmsg" runat="server"></asp:Label>
                                            </div>
                                            <div ID="Failure" runat="server" class="alert alert-danger" visible="false">
                                                <a aria-label="close" class="close" data-dismiss="alert" href="#">×</a> <strong>
                                                Warning!</strong>
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
<%--<div style=" z-index: 1000; margin-left: 350px;margin-top:200px;opacity: 1;-moz-opacity: 1;">--%>
<div style=" z-index: 1000; margin-left: 250px;margin-top:100px;opacity: 1; -moz-opacity: 1;">
<img alt="" src="../../Resource/Images/Processing.gif" />

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
  </asp:UpdatePanel>
 <%--</div>
       </td>
        </tr>
    </table>--%>
</asp:Content>

