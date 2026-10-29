<%@ Page Title=":: TS-iPASS ::  " Language="C#" MasterPageFile="~/UI/TSiPASS/CCMaster.master" AutoEventWireup="true" CodeFile="frmProformaeReport1.aspx.cs" Inherits="TSTBDCReg1" %>

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

    <script type="text/javascript">
        function checkLength(el) {
            if (el.value.length != 10) {
                alert("Mobile number length must be exactly 10 characters")
            }
        }
    </script>
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
                                <h3 class="panel-title">Report 1:Stressed asset bank wise report</h3>
                            </div>
                             <asp:UpdatePanel ID="UpdatePanel1" runat="server">
<ContentTemplate>
                            <div class="panel-body" >
                                <table align="center" cellpadding="10" cellspacing="5" style="width: 90%">
                                    
                                    <tr runat="server" visible="false">
                                         <td style="padding: 5px; margin: 5px; text-align: center;" valign="top" 
                                                    colspan="3">
                                                                <asp:Label ID="Label4" runat="server" CssClass="LBLBLACK" Font-Bold="True" 
                                                                    Width="136px">Targets Completed</asp:Label>
                                                            :<asp:Label ID="lblmsg1" runat="server"></asp:Label>
                                                    /<asp:Label ID="lblmsg2" runat="server"></asp:Label>
                                                </td>
                                    </tr>
                                    <tr runat="server" visible="false">
                                        <td colspan="3" style="padding: 5px; margin: 5px; text-align: center;" 
                                            valign="top">
                                            <asp:Button ID="btnOrgLookup0" runat="server" CausesValidation="False" 
                                                CssClass="btn btn-primary" Font-Size="12px" Height="32px" 
                                                onclick="btnOrgLookup_Click" Style="position: static" Text="Look Up" 
                                                ToolTip="Rate Lookup" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="padding: 5px; margin: 5px" valign="top">
                                            <table cellpadding="4" cellspacing="5" style="width: 83%">

                                                <tr>
                                                    <td style="padding: 5px; margin: 5px; text-align: left;">
                                                        1</td>
                                                    <td style="padding: 5px; margin: 5px; text-align: left;">
                                                        <asp:Label ID="Label5" runat="server" CssClass="LBLBLACK" Width="165px">District</asp:Label>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        :</td>
                                                    <td style="padding: 5px; margin: 5px; text-align: left;">
                                                        <asp:DropDownList ID="ddlUnitDIst" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlUnitDIst_SelectedIndexChanged" class="form-control txtbox" 
                                                            Height="33px" TabIndex="1" Width="180px">
                                                            <asp:ListItem>--Select--</asp:ListItem>
                                                            
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        &nbsp;</td>
                                                </tr>

                                                <tr runat="server" visible="false">
                                                    <td style="padding: 5px; margin: 5px; text-align: left;">
                                                        2</td>
                                                    <td style="padding: 5px; margin: 5px; text-align: left;">
                                                        <asp:Label ID="Label7" runat="server" CssClass="LBLBLACK" Width="165px">Mandal</asp:Label>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        :</td>
                                                    <td style="padding: 5px; margin: 5px; text-align: left;">
                                                        <asp:DropDownList ID="ddlUnitMandal" runat="server" class="form-control txtbox" 
                                                            Height="33px" TabIndex="1" Width="180px">
                                                            <asp:ListItem>--Select--</asp:ListItem>
                                                            
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        &nbsp;</td>
                                                </tr>

                                                <tr>
                                                    <td style="padding: 5px; margin: 5px; text-align: left;">
                                                        2</td>
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

                                                <tr runat="server" id="trnoofmandals" visible="false">
                                                    <td style="padding: 5px; margin: 5px; text-align: left; vertical-align: top;">
                                                        3</td>
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
                                                <tr runat="server" id="trnoofbanks" visible="false">
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
                                                        3</td>
                                                    <td style="padding: 5px; margin: 5px; text-align: left;">
                                                        <asp:Label ID="Label34" runat="server" CssClass="LBLBLACK" Width="165px">No.of 
                                                        Branches Visited<font color="red">*</font></asp:Label>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        :</td>
                                                    <td style="padding: 5px; margin: 5px; text-align: left;">
                                                        <asp:TextBox ID="TxtBranchs" autoComplete="off" runat="server" class="form-control txtbox" 
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
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="padding: 5px; margin: 5px" valign="top">
                                            <asp:Label ID="Label424" runat="server" CssClass="LBLBLACK" Font-Bold="True" 
                                                Width="210px">Details<font 
                                                            color="red">*</font></asp:Label>
                                        </td>
                                        <td style="width: 27px">
                                            &nbsp;</td>
                                        <td valign="top" class="style6">
                                            &nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td style="padding: 5px; margin: 5px" valign="top">
                                            <table cellpadding="4" cellspacing="5" style="width: 83%">
                                                    <tr>
                                                    <td style="padding: 5px; margin: 5px; text-align: left;">
                                                        1&nbsp;</td>
                                                    <td style="padding: 5px; margin: 5px; text-align: left;">
                                                        <asp:Label ID="Label435" runat="server" CssClass="LBLBLACK" Width="200px">Bank Name<font id="lbl1" runat="server" 
                                                            color="red">*</font></asp:Label>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        :</td>
                                                    <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                        <asp:DropDownList ID="ddlBankName" runat="server" class="form-control txtbox" 
                                                            Height="33px" TabIndex="1" Width="180px">
                                                            <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                   
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px; width: 10px;">
                                                       <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" 
                                                            ControlToValidate="ddlBankName" ErrorMessage="Please select Bank Name" 
                                                            InitialValue="--Select--" ValidationGroup="child">*</asp:RequiredFieldValidator>--%>
                                                    </td>
                                                </tr>
                                                    
                                                   <tr>
                                                    <td style="padding: 5px; margin: 5px; text-align: left;">
                                                        </td>
                                                    <td style="padding: 5px; margin: 5px; text-align: left;">
                                                        <asp:Label ID="Label8" runat="server" CssClass="LBLBLACK" Width="165px"><b>Whether any Cases registered or Not </b>
                                                        <font id="lbl" runat="server" color="red">*</font></asp:Label>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        :</td>
                                                    <td style="padding: 5px; margin: 5px; text-align: left;">
                                                        <asp:RadioButtonList ID="rdIaLa_Lst" runat="server" AutoPostBack="true" RepeatDirection="Horizontal" OnSelectedIndexChanged="rdIaLa_Lst_SelectedIndexChanged"
                                                >
                                                <asp:ListItem Value="Y" Selected="True">Yes</asp:ListItem>
                                                <asp:ListItem Value="N" >No</asp:ListItem>
                                            </asp:RadioButtonList>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px">
                                                       <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" 
                                                            ControlToValidate="txtUnitName" ErrorMessage="Please select Unit Name" 
                                                            ValidationGroup="child">*</asp:RequiredFieldValidator>--%>
                                                    </td>
                                                </tr>
                                           
                                                <tr>
                                                    <td style="padding: 5px; margin: 5px; text-align: left;">
                                                        3</td>
                                                    <td style="padding: 5px; margin: 5px; text-align: left;">
                                                        <asp:Label ID="Label434" runat="server" CssClass="LBLBLACK" Width="165px">Name 
                                                        of the Unit<font id="lbl2" runat="server" color="red">*</font></asp:Label>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        :</td>
                                                    <td style="padding: 5px; margin: 5px; text-align: left;">
                                                        <asp:TextBox ID="txtUnitName" runat="server" class="form-control txtbox" autoComplete="off"
                                                            Height="28px" MaxLength="200" TabIndex="1" ValidationGroup="group" 
                                                            Width="180px"></asp:TextBox>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" 
                                                            ControlToValidate="txtUnitName" ErrorMessage="Please select Unit Name" 
                                                            ValidationGroup="child">*</asp:RequiredFieldValidator>--%>
                                                    </td>
                                                </tr>
                                           
                                                   <tr>
                                                            <td style="padding: 5px; margin: 5px">
                                                                5&nbsp;</td>
                                                            <td style="width: 200px;">
                                                                <asp:Label ID="Label9" runat="server" CssClass="LBLBLACK" Width="180px">District<font id="lb3" runat="server"
                                                            color="red">*</font></asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                :
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                  <asp:DropDownList ID="ddlUnitDIst1" runat="server" class="form-control txtbox" Visible="true"
                                                                        TabIndex="3" Height="33px" Width="180px" OnSelectedIndexChanged="ddlUnitDIst1_SelectedIndexChanged" AutoPostBack="true">
                                                                        <asp:ListItem  Value="0">--Select--</asp:ListItem>
                                                                    </asp:DropDownList>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                &nbsp;
                                                               <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" 
                                                                    ControlToValidate="ddlUnitDIst1" ErrorMessage="Please select District" 
                                                                    InitialValue="--Select--" ValidationGroup="child">*</asp:RequiredFieldValidator>--%>
                                                                </td>
                                                        </tr>
                                                
                                                   <tr>
                                                            <td style="padding: 5px; margin: 5px">
                                                                7</td>
                                                            <td style="width: 200px;">
                                                                <asp:Label ID="Label13" runat="server" CssClass="LBLBLACK" Width="180px">Village<font 
                                                            color="red" id="lbl4" runat="server">*</font></asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                :
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                  <asp:DropDownList ID="ddlVillageunit" runat="server" class="form-control txtbox"
                                                                        TabIndex="3" Height="33px" Width="180px">
                                                                        <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                                    </asp:DropDownList>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                &nbsp;
                                                                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" 
                                                                    ControlToValidate="ddlVillageunit" ErrorMessage="Please select Village" 
                                                                    InitialValue="--Select--" ValidationGroup="child">*</asp:RequiredFieldValidator>--%>
                                                                </td>
                                                        </tr>
                                                   <tr id="Tr1" runat="server" visible="true">
                                                    <td style="padding: 5px; margin: 5px">
                                                        9&nbsp;</td>
                                                    <td style="width: 200px;">
                                                        <asp:Label ID="Label6" runat="server" CssClass="LBLBLACK" Width="165px">Contact Number of Entrepreneur(if any)</asp:Label>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        :</td>
                                                       <td style="padding: 5px; margin: 5px; text-align: left;">
                                                        <asp:TextBox ID="txtContactNumber" runat="server" class="form-control txtbox" onkeypress="return inputOnlyNumbers(event)"
                                                            Height="28px" MaxLength="10" TabIndex="1" ValidationGroup="child" autoComplete="off" ValidationExpression ="^[\s\S]{5,8}$"
                                                            Width="180px" onblur="return checkLength(el)"></asp:TextBox>
                                                    </td>
                                                  
                                                    <td style="padding: 5px; margin: 5px">
                                                       <asp:RegularExpressionValidator ID="regularexpressionvalidator6" runat="server" ControlToValidate="txtContactNumber"
                                                                    ErrorMessage="Mobile number length must be exactly 10 characters" ValidationExpression="[0-9]{10}"
                                                                    ValidationGroup="group">*</asp:RegularExpressionValidator>
                                                    </td>
                                                </tr>
                                                      <tr>
                                                    <td style="padding: 5px; margin: 5px; text-align: left;">
                                                        11&nbsp;</td>
                                                    <td style="padding: 5px; margin: 5px; text-align: left;">
                                                        <asp:Label ID="Label445" runat="server" CssClass="LBLBLACK" Width="165px">Upload 
                                                        Document(pdf only) if any like SARFAESI etc</asp:Label>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        :</td>
                                                    <td style="padding: 5px; margin: 5px; text-align: left;">
                                                        <asp:FileUpload ID="FileUpload1" runat="server" class="form-control txtbox" 
                                                            Height="28px" />
                                                        <asp:HyperLink ID="lblFileName" runat="server" CssClass="LBLBLACK" Visible="false"
                                                            Width="165px"></asp:HyperLink>
                                                        <br />
                                                        <asp:Label ID="Label444" runat="server" Visible="False"></asp:Label>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        &nbsp;</td>
                                                </tr>
                                     <tr id="Tr3" runat="server" visible="true">
                                                    <td style="padding: 5px; margin: 5px">
                                                        12</td>
                                                    <td style="width: 200px;">
                                                        <asp:Label ID="Label11" runat="server" CssClass="LBLBLACK" Width="165px">Whether send to TIHCL</asp:Label>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        :</td>
                                                       <td style="padding: 5px; margin: 5px; text-align: left;">
                                                           <asp:RadioButtonList ID="rbtTIHCL" runat="server" AutoPostBack="true" OnSelectedIndexChanged="rbtTIHCL_SelectedIndexChanged" RepeatDirection="Horizontal">
                                                               <asp:ListItem  Value="Y">Yes</asp:ListItem>
                                                               <asp:ListItem Value="N">No</asp:ListItem>
                                                           </asp:RadioButtonList>
                                                    </td>
                                                  
                                                    <td style="padding: 5px; margin: 5px">
                                                       <asp:RegularExpressionValidator ID="regularexpressionvalidator1" runat="server" ControlToValidate="txtContactNumber"
                                                                    ErrorMessage="Mobile number length must be exactly 10 characters" ValidationExpression="[0-9]{10}"
                                                                    ValidationGroup="group">*</asp:RegularExpressionValidator>
                                                    </td>
                                                </tr>
                                            <tr id="Trreason" runat="server" visible="false">
                                                    <td style="padding: 5px; margin: 5px">
                                                        &nbsp;</td>
                                                    <td style="width: 200px;">
                                                        <asp:Label ID="Label14" runat="server" CssClass="LBLBLACK" Width="165px">Reason </asp:Label>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        :</td>
                                                       <td style="padding: 5px; margin: 5px; text-align: left;">
                                                        <asp:TextBox ID="Txtreason" runat="server" class="form-control txtbox" 
                                                            Height="28px" MaxLength="10" TabIndex="1" ValidationGroup="child" autoComplete="off" 
                                                            Width="180px" ></asp:TextBox>
                                                    </td>
                                                  
                                                    <td style="padding: 5px; margin: 5px">
                                                      
                                                    </td>
                                                </tr>
                                            
                                            </table>
                                        </td>
                                        <td style="width: 27px">
                                            <asp:Label ID="Label348" runat="server" CssClass="LBLBLACK" Width="50px"></asp:Label>
                                        </td>
                                        <td valign="top" class="style6">
                                            <table cellpadding="4" cellspacing="5" style="width: 100%">
                                                     <tr>
                                                    <td style="padding: 5px; margin: 5px; text-align: left;">
                                                        2</td>
                                                    <td style="padding: 5px; margin: 5px; text-align: left;">
                                                        <asp:Label ID="Label437" runat="server" CssClass="LBLBLACK" Width="200px">Bank Brach Name<font id="lb5" runat="server" 
                                                            color="red">*</font></asp:Label>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        :</td>
                                                    <td style="padding: 5px; margin: 5px; text-align: left;">
                                                        <asp:TextBox ID="txtBankBranch" runat="server" autoComplete="off"
                                                            class="form-control txtbox" Height="28px" onkeypress="Names()" 
                                                            TabIndex="1" ValidationGroup="group" Width="180px" MaxLength="150"></asp:TextBox>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px">
                                                      <%--  <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" 
                                                            ControlToValidate="txtBankBranch" ErrorMessage="Please Enter Branch Name" 
                                                            ValidationGroup="child">*</asp:RequiredFieldValidator>--%>
                                                    </td>
                                                </tr>
                                                  <tr>
                                                    <td style="padding: 5px; margin: 5px; text-align: left;">
                                                        </td>
                                                    <td style="padding: 5px; margin: 5px; text-align: left;">
                                                        <asp:Label ID="Label10" runat="server" CssClass="LBLBLACK" Width="165px"><font 
                                                            color="red"></font></asp:Label>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        :</td>
                                                    <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                       
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px; width: 10px;">
                                                        
                                                    </td>
                                                </tr>
                                                     <tr>
                                                    <td style="padding: 5px; margin: 5px; text-align: left;">
                                                        4</td>
                                                    <td style="padding: 5px; margin: 5px; text-align: left;">
                                                        <asp:Label ID="Label1" runat="server" CssClass="LBLBLACK" Width="165px">Type<font id="lbl6" runat="server"
                                                            color="red">*</font></asp:Label>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        :</td>
                                                    <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                        <asp:DropDownList ID="ddlType" runat="server" 
                                                            class="form-control txtbox" Height="33px" TabIndex="1" Width="180px">
                                                            <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                            <asp:ListItem value="1">Incipient Sick</asp:ListItem>
                                                            <asp:ListItem value="2">Sick</asp:ListItem>
                                                            <asp:ListItem value="3">Willful Defaulters</asp:ListItem>
                                                            <asp:ListItem value="4">TEV Study Done</asp:ListItem>
                                                            <asp:ListItem value="5">Restructuring under taken</asp:ListItem>
                                                            <asp:ListItem value="6">SARFAESI</asp:ListItem>
                                                            <asp:ListItem value="7">Account Closed</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px; width: 10px;">
                                                        <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
                                                            ControlToValidate="ddlType" ErrorMessage="Please select Type" 
                                                            InitialValue="--Select--" ValidationGroup="child">*</asp:RequiredFieldValidator>--%>
                                                    </td>
                                                </tr>
                                                   <tr>
                                                            <td style="padding: 5px; margin: 5px">
                                                                6</td>
                                                            <td style="width: 200px;">
                                                                <asp:Label ID="Label12" runat="server" CssClass="LBLBLACK" Width="180px">Mandal<font id="lbl7" runat="server" 
                                                            color="red">*</font></asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                :
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                 
                                                                 <asp:DropDownList ID="ddlUnitMandal1" runat="server" class="form-control txtbox" Visible="true"
                                                                        TabIndex="3" Height="33px" Width="180px" AutoPostBack="true" OnSelectedIndexChanged="ddlUnitMandal1_SelectedIndexChanged">
                                                                        <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                                    </asp:DropDownList>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                &nbsp;
                                                                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                                                    ControlToValidate="ddlUnitMandal1" ErrorMessage="Please select Mandal " 
                                                                    InitialValue="--Select--" ValidationGroup="child">*</asp:RequiredFieldValidator>--%>
                                                                </td>
                                                        </tr>
                                              
                                                    <tr id="qty" runat="server" visible="true">
                                                    <td style="padding: 5px; margin: 5px">
                                                        8</td>
                                                    <td style="width: 200px;">
                                                        <asp:Label ID="Label2" runat="server" CssClass="LBLBLACK" Width="165px">Address of the Unit<font id="lbl8" runat="server" 
                                                            color="red">*</font></asp:Label>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        :</td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        <asp:TextBox ID="txtAddress" runat="server" class="form-control txtbox"
                                                            Height="43px" MaxLength="200" TabIndex="1" ValidationGroup="group" autoComplete="off" 
                                                            Width="180px" TextMode="MultiLine"></asp:TextBox>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px">
                                                       <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" 
                                                            ControlToValidate="txtAddress" ErrorMessage="Please Enter Address of the Unit" 
                                                            ValidationGroup="child">*</asp:RequiredFieldValidator>--%>
                                                    </td>
                                                </tr>
                                                
                                                <tr >
                                                    <td style="padding: 5px; margin: 5px">
                                                        10</td>
                                                    <td style="width: 200px;">
                                                        <asp:Label ID="Label3" runat="server" CssClass="LBLBLACK" Width="165px">Remarks<font id="lbl9" runat="server"
                                                            color="red">*</font></asp:Label>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        :</td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        <asp:TextBox ID="TxtRemarks" runat="server" class="form-control txtbox" 
                                                            Height="43px" MaxLength="200" TabIndex="1" ValidationGroup="group" 
                                                            Width="180px" TextMode="MultiLine"></asp:TextBox>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px">
                                                       <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                                            ControlToValidate="TxtRemarks" ErrorMessage="Please Enter Remarks" 
                                                            ValidationGroup="child">*</asp:RequiredFieldValidator>--%>
                                                    </td>
                                                </tr>
                                          

                                                
                                                
                                                <tr ID="tr2" runat="server">
                                                    <td style="padding: 5px; margin: 5px">
                                                        &nbsp;</td>
                                                    <td style="width: 200px;">
                                                        &nbsp; </td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        &nbsp;</td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        &nbsp; 
                                                        <asp:Button ID="BtnSave2" runat="server" CssClass="btn btn-xs btn-warning" 
                                                            Height="28px" onclick="BtnSave2_Click1" TabIndex="10" Text="Add New" 
                                                            ValidationGroup="child" Width="72px" />
                                                        &nbsp;
                                                        <asp:Button ID="BtnClear0" runat="server" CausesValidation="False" 
                                                            CssClass="btn btn-xs btn-danger" Height="28px" onclick="BtnClear0_Click2" 
                                                            TabIndex="10" Text="Cancel" ToolTip="To Clear  the Screen" Width="73px" />
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
                                                    <asp:CommandField HeaderText="Edit" ShowSelectButton="True" Visible="false" />
                                                    <asp:CommandField HeaderText="Delete" ShowDeleteButton="True" />
                                                    
                                                    <asp:BoundField DataField="TypeName" HeaderText="Type" />
                                                    
                                                    <asp:BoundField DataField="BankName" HeaderText="Bank Name" />
                                                    <asp:BoundField DataField="BranchName" HeaderText="Branch Name" />
                                                    <asp:BoundField DataField="NameofUnit" HeaderText="Name of Unit" />
                                                      <asp:BoundField DataField="DistricName" HeaderText="DistricName"/>
                                                      <asp:BoundField DataField="MandalName" HeaderText="MandalName"/>
                                                      <asp:BoundField DataField="VillageName" HeaderText="VillageName"/>
                                                    <asp:BoundField DataField="AddressofUnit" HeaderText="Address" />
                                                    <asp:BoundField DataField="ContactNumber" HeaderText="Contact Number" />
                                                      <asp:BoundField DataField="Remarks" HeaderText="Remarks" />
                                                    <asp:TemplateField HeaderText="Uploaded Doc" ItemStyle-Width="30">
                                                            <ItemTemplate>
                                                                <asp:HyperLink ID="hprlink" runat="server" NavigateUrl='<%# Eval("FilePath") %>'
                                                                    Text='View' Visible="false" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    <asp:BoundField DataField="DistrictId" HeaderText="DistrictId" Visible="false"/>
                                                      <asp:BoundField DataField="MandalId" HeaderText="MandalId" Visible="false"/>
                                                      <asp:BoundField DataField="VillageId" HeaderText="VillageId" Visible="false"/>
                                                     <asp:BoundField DataField="WhetherYorN" HeaderText="WhetherYorN" Visible="false"/>
                                                   <asp:BoundField DataField="TIHCL" HeaderText="TIHCL"/>
                                                     <asp:BoundField DataField="reason" HeaderText="reason"/>

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
                                        <td align="center" colspan="3" 
                                            style="padding: 5px; margin: 5px; text-align: center;">
                                            <asp:Button ID="BtnSave1" runat="server" CssClass="btn btn-primary"
                                                Height="32px" onclick="BtnSave_Click" TabIndex="10" Text="Save" 
                                                Width="90px" ValidationGroup="group" />
                                            &nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="BtnClear" runat="server" CausesValidation="False" 
                                                CssClass="btn btn-warning" Height="32px" onclick="BtnClear_Click" TabIndex="10" 
                                                Text="ClearAll" ToolTip="To Clear  the Screen" Width="90px" />
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
  <Triggers>
           <asp:PostBackTrigger ControlID="BtnSave1" />
<asp:PostBackTrigger ControlID="BtnSave2"></asp:PostBackTrigger>

           </Triggers>
  </asp:UpdatePanel>
 <%--</div>
       </td>
        </tr>
    </table>--%>
</asp:Content>

