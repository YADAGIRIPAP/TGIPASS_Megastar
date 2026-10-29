<%@ Page Title=":: TS-iPASS ::  " Language="C#" MasterPageFile="~/UI/TSiPASS/CCMaster.master" AutoEventWireup="true" CodeFile="frmProformaeReport1DrillDownLat.aspx.cs" Inherits="TSTBDCReg1" %>

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
        width: 464px;
    }
    </style>


<script type="text/javascript" language="javascript">

function OpenPopup() 
 
   {

       window.open("Lookups/LookupBankReport.aspx", "List", "scrollbars=yes,resizable=yes,width=1000,height=650;display = block;position=absolute");

    return false;
    }
    </script>

 <script type="text/javascript">
    function showProgress() {
        var updateProgress = $get("<%= UpdateProgress.ClientID %>");
        updateProgress.style.display = "block";
    }
</script>

<script type="text/javascript">
    function Names() {
        var AsciiValue = event.keyCode
        if ((AsciiValue >= 65 && AsciiValue <= 90) || (AsciiValue >= 97 && AsciiValue <= 122) || (AsciiValue == 46) || (AsciiValue == 32))
            event.returnValue = true;
        else {
            event.returnValue = false;

            alert("Enter Alphabets, '.' and Space Only");
        }
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
    <asp:UpdatePanel ID="upd1" runat="server">
<ContentTemplate>
<div align="left">
    <ol class="breadcrumb">You are here
        &nbsp;!&nbsp; &nbsp; &nbsp; 
                            <li>
                                <i class="fa fa-dashboard"></i>  <a href="Home.aspx"></a>
                            </li>
                            <li class="">
                                <i class="fa fa-fw fa-edit">IPO</i> 
                            </li>
                            <li class="active">
                                <i class="fa fa-edit"></i> <a href="#">Bank Wise</a>
                            </li>
                        </ol>
     </div>
    
<div align="left">
<div class="row" align="left">
                    <div class="col-lg-11" >
                        <div class="panel panel-primary">
                            <div class="panel-heading" align="center">
                                <h3 class="panel-title">BANK WISE REGISTRATION</h3>
                            </div>
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
<ContentTemplate>
                            <div class="panel-body" >
                                <table align="center" cellpadding="10" cellspacing="5" style="width: 90%">
                                    
                                    <tr>
                                        <td style="padding: 5px; margin: 5px" valign="top">
                                            <table cellpadding="4" cellspacing="5" style="width: 83%">
                                                <tr>
                                                    <td style="padding: 5px; margin: 5px; text-align: left;">
                                                        1</td>
                                                    <td style="padding: 5px; margin: 5px; text-align: left;">
                                                        <asp:Label ID="Label31" runat="server" CssClass="LBLBLACK" Width="200px">Name of 
                                                        IPO<font color="red">*</font></asp:Label>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        :</td>
                                                    <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                        <asp:Label ID="lblIPOname" runat="server" CssClass="LBLBLACK" Width="165px"></asp:Label>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px; width: 10px;">
                                                        &nbsp;</td>
                                                </tr>
                                                <tr>
                                                    <td style="padding: 5px; margin: 5px; text-align: left; vertical-align: top;">
                                                        2</td>
                                                    <td style="padding: 5px; margin: 5px; text-align: left;">
                                                        <asp:Label ID="Label32" runat="server" CssClass="LBLBLACK" Width="165px">Total 
                                                        No.of Branches in the IPO&#39;s jurisdiction(Mandals Allocated by the GM)<font 
                                                            color="red">*</font></asp:Label>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        :</td>
                                                    <td style="padding: 5px; margin: 5px; text-align: left;">
                                                        <asp:TextBox ID="txtIPO" runat="server" class="form-control txtbox" 
                                                            Height="28px" MaxLength="4" onkeypress="NumberOnly()" TabIndex="1" 
                                                            ValidationGroup="group" Width="180px"></asp:TextBox>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                                                            ControlToValidate="txtIPO" ErrorMessage="Please enter IPO juridiction" 
                                                            ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="padding: 5px; margin: 5px; text-align: left; vertical-align: top;">
                                                        3</td>
                                                    <td style="padding: 5px; margin: 5px; text-align: left;">
                                                        <asp:Label ID="Label33" runat="server" CssClass="LBLBLACK" Width="165px">No.of 
                                                        Branchs in the respective Mandals<font color="red">*</font></asp:Label>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        :</td>
                                                    <td style="padding: 5px; margin: 5px; text-align: left;">
                                                        <asp:TextBox ID="TxtNoofMandals" runat="server" class="form-control txtbox" 
                                                            Height="28px" MaxLength="4" onkeypress="NumberOnly()" TabIndex="1" 
                                                            ValidationGroup="group" Width="180px"></asp:TextBox>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                                                            ControlToValidate="TxtNoofMandals" ErrorMessage="Please enter no of Mandals" 
                                                            ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="padding: 5px; margin: 5px; text-align: left; vertical-align: top;">
                                                        4</td>
                                                    <td style="padding: 5px; margin: 5px; text-align: left;">
                                                        <asp:Label ID="Label34" runat="server" CssClass="LBLBLACK" Width="165px">No.of 
                                                        Branches Visited<font color="red">*</font></asp:Label>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        :</td>
                                                    <td style="padding: 5px; margin: 5px; text-align: left;">
                                                        <asp:TextBox ID="TxtBranchs" runat="server" class="form-control txtbox" 
                                                            Height="28px" MaxLength="10" onkeypress="NumberOnly()" TabIndex="1" 
                                                            ValidationGroup="group" Width="180px"></asp:TextBox>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                                                            ControlToValidate="TxtBranchs" ErrorMessage="Please enter No of Branches" 
                                                            ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                        <td style="width: 27px">
                                            &nbsp;</td>
                                        <td class="style6" valign="top">
                                            <table cellpadding="4" cellspacing="5" style="width: 83%">
                                                <tr>
                                                    <td style="padding: 5px; margin: 5px; text-align: left;">
                                                        5</td>
                                                    <td style="padding: 5px; margin: 5px; text-align: left;">
                                                        <asp:Label ID="Label438" runat="server" CssClass="LBLBLACK" Width="165px">Year</asp:Label>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        :</td>
                                                    <td style="padding: 5px; margin: 5px; text-align: left;">
                                                        <asp:DropDownList ID="ddlYear" runat="server" class="form-control txtbox" 
                                                            Height="33px" TabIndex="1" Width="180px">
                                                            <asp:ListItem>--Select--</asp:ListItem>
                                                            
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        &nbsp;</td>
                                                </tr>
                                                <tr>
                                                    <td style="padding: 5px; margin: 5px; text-align: left;">
                                                        6</td>
                                                    <td style="padding: 5px; margin: 5px; text-align: left;">
                                                        <asp:Label ID="Label439" runat="server" CssClass="LBLBLACK" Width="165px">Month</asp:Label>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        :</td>
                                                    <td style="padding: 5px; margin: 5px; text-align: left;">
                                                        <asp:DropDownList ID="ddlMonth" runat="server" class="form-control txtbox" 
                                                            Height="33px" TabIndex="1" Width="180px">
                                                            <asp:ListItem>--Select--</asp:ListItem>
                                                            <asp:ListItem Value="1">January</asp:ListItem>
                                                            <asp:ListItem Value="2">February</asp:ListItem>
                                                            <asp:ListItem Value="3">March</asp:ListItem>
                                                            <asp:ListItem Value="4">April</asp:ListItem>
                                                            <asp:ListItem Value="5">May</asp:ListItem>
                                                            <asp:ListItem Value="6">June</asp:ListItem>
                                                            <asp:ListItem Value="7">July</asp:ListItem>
                                                            <asp:ListItem Value="8">August</asp:ListItem>
                                                            <asp:ListItem Value="9">Sepetmber</asp:ListItem>
                                                            <asp:ListItem Value="10">October</asp:ListItem>
                                                            <asp:ListItem Value="11">November</asp:ListItem>
                                                            <asp:ListItem Value="12">December</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        &nbsp;</td>
                                                </tr>
                                                <tr>
                                                    <td style="padding: 5px; margin: 5px; text-align: left;">
                                                        7</td>
                                                    <td style="padding: 5px; margin: 5px; text-align: left;">
                                                        <asp:Label ID="Label445" runat="server" CssClass="LBLBLACK" Width="165px">Upload 
                                                        Document<font 
                                                            color="red">*</font></asp:Label>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        :</td>
                                                    <td style="padding: 5px; margin: 5px; text-align: left;">
                                                        <asp:FileUpload ID="FileUpload1" runat="server" class="form-control txtbox" 
                                                            Height="28px" />
                                                        <asp:HyperLink ID="lblFileName" runat="server" CssClass="LBLBLACK" 
                                                            Width="165px"></asp:HyperLink>
                                                        <br />
                                                        <asp:Label ID="Label444" runat="server" Visible="False"></asp:Label>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        &nbsp;</td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="padding: 5px; margin: 5px" valign="top" align="left" colspan="3">
                                            <asp:GridView ID="gvCertificate" runat="server" AutoGenerateColumns="False" 
                                                BorderColor="#003399" BorderStyle="Solid" BorderWidth="1px" CellPadding="4" 
                                                CssClass="GRD" ForeColor="#333333" GridLines="None" 
                                                OnRowDataBound="gvCertificate_RowDataBound" 
                                                OnRowDeleting="gvCertificate_RowDeleting" Width="100%" 
                                                DataKeyNames="intBankReportChildid">
                                                <rowstyle backcolor="#ffffff" />
                                                <columns>
                                                 <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S No">
                                                                    <ItemTemplate >
                                                                        <%# Container.DataItemIndex +1 %>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                    <ItemStyle Width="50px" />
                                                                    
                                                                </asp:TemplateField>
                                                    <asp:CommandField HeaderText="Edit" ShowSelectButton="True" Visible="false" />
                                                    <%--<asp:CommandField HeaderText="Delete" ShowDeleteButton="True" />--%>
                                                    
                                                    <asp:BoundField DataField="TypeName" HeaderText="Type" />
                                                    
                                                    <asp:BoundField DataField="BankName" HeaderText="Bank Name" />
                                                    <asp:BoundField DataField="BranchName" HeaderText="Branch Name" />
                                                    <asp:BoundField DataField="NameofUnit" HeaderText="Name of Unit" />
                                                    <asp:BoundField DataField="AddressofUnit" HeaderText="Address" />
                                                      <asp:BoundField DataField="Remarks" HeaderText="Remarks" />
                                                    
                                                </columns>
                                                <footerstyle backcolor="#013161" font-bold="True" forecolor="White" />
                                                <pagerstyle backcolor="#013161" forecolor="White" horizontalalign="Center" />
                                                <selectedrowstyle backcolor="#D1DDF1" font-bold="True" forecolor="#333333" />
                                                <headerstyle backcolor="#013161" font-bold="True" forecolor="White" />
                                                <editrowstyle backcolor="#013161" />
                                                <alternatingrowstyle backcolor="White" />
                                            </asp:GridView>
                                        </td>
                                    </tr>
                                    
                                    
                                    
                                    
                                    
                                    
                                    
                                    
                                    
                                    
                                    
                                    <tr>
                                        <td align="center" colspan="3" style="padding: 5px; margin: 5px">
                                            
                                            
                                            <div id="success" runat="server" visible="false" class="alert alert-success">
    <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a>
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
<%--  <Triggers>
            <asp:PostBackTrigger ControlID="BtnSave1" />
<asp:PostBackTrigger ControlID="BtnSave1"></asp:PostBackTrigger>
<asp:PostBackTrigger ControlID="BtnSave1"></asp:PostBackTrigger>
<asp:PostBackTrigger ControlID="BtnSave1"></asp:PostBackTrigger>
<asp:PostBackTrigger ControlID="BtnSave1"></asp:PostBackTrigger>
            </Triggers>
            <Triggers>
            <asp:PostBackTrigger ControlID="BtnSave1" />
            </Triggers>--%>
  </asp:UpdatePanel>
 <%--</div>
       </td>
        </tr>
    </table>--%>
</asp:Content>

