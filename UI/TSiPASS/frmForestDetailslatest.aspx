<%@ Page Title=":: TS-iPASS ::  " Language="C#" MasterPageFile="~/UI/TSiPASS/CCMaster.master" AutoEventWireup="true" CodeFile="frmForestDetailslatest.aspx.cs" Inherits="TSTBDCReg1" %>

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
    .style7
    {
        color: #FF3300;
    }
    .style8
    {
    }
    .style9
    {
        height: 20px;
    }
    .style10
    {
        width: 192px;
        height: 20px;
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
    <asp:UpdatePanel ID="upd1" runat="server">
<ContentTemplate>
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
                                <i class="fa fa-edit"></i> <a href="#">Forest Details</a>
                            </li>
                        </ol>
     </div>
    
<div align="left">
<div class="row" align="left">
                    <div class="col-lg-11" >
                        <div class="panel panel-primary">
                            <div class="panel-heading" align="center">
                                <h3 class="panel-title">Forest Details</h3>
                            </div>
                             <asp:UpdatePanel ID="UpdatePanel1" runat="server">
<ContentTemplate>
                            <div class="panel-body" >
                                <table align="center" cellpadding="10" cellspacing="5" style="width: 90%">
                                    
                                       <tr>
                                        <td style="padding: 5px; margin: 5px" valign="top">
                                            <asp:Label ID="Label444" runat="server" CssClass="LBLBLACK" Font-Bold="True" 
                                                Width="210px">A) Forest</asp:Label>
                                        </td>
                                        <td style="width: 27px">
                                            &nbsp;</td>
                                        <td valign="top">
                                            &nbsp;</td>
                                    </tr>
                                    
                                    <tr>
                                        <td style="padding: 5px; margin: 5px" valign="top">
                                            <table cellpadding="4" cellspacing="5" style="width: 83%">
                                                <tr>
                                                    <td style="padding: 5px; margin: 5px; text-align: left;">
                                                        1</td>
                                                    <td style="padding: 5px; margin: 5px; text-align: left;">
                                                        <asp:Label ID="Label401" runat="server" CssClass="LBLBLACK" Width="200px">Species<font 
                                                            color="red">*</font></asp:Label>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        :</td>
                                                    <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                        <asp:TextBox ID="txtcontact11" runat="server" class="form-control txtbox" onkeypress="Names()" 
                                                            Height="28px" MaxLength="30"  TabIndex="1" 
                                                            ValidationGroup="group" Width="180px"></asp:TextBox>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px; width: 10px;">
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                                            ControlToValidate="txtcontact11" ErrorMessage="Please enter Species" 
                                                            ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="padding: 5px; margin: 5px; text-align: left;">
                                                        2</td>
                                                    <td style="padding: 5px; margin: 5px; text-align: left;">
                                                        <asp:Label ID="Label402" runat="server" CssClass="LBLBLACK" Width="200px">Estimated Length Of Timber<font 
                                                            color="red">*</font></asp:Label>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        :</td>
                                                    <td style="padding: 5px; margin: 5px; text-align: left;">
                                                        <asp:TextBox ID="txtcontact12" runat="server" class="form-control txtbox" 
                                                            Height="28px" MaxLength="18" onkeypress="return inputOnlyNumbers(event)" TabIndex="1" 
                                                            ValidationGroup="group" Width="180px"></asp:TextBox>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                                                            ControlToValidate="txtcontact12" ErrorMessage="Please Enter Lenght of Timber" 
                                                            ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                        3&nbsp;</td>
                                                    <td style="padding: 5px; margin: 5px; text-align: left;">
                                                        <asp:Label ID="Label448" runat="server" CssClass="LBLBLACK" Width="200px">Estimated Volume Of Timber<font 
                                                            color="red">*</font></asp:Label>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        :</td>
                                                    <td style="padding: 5px; margin: 5px; text-align: left; width: 192px;">
                                                        <asp:TextBox ID="txtcontact24" runat="server" class="form-control txtbox" 
                                                            Height="28px" MaxLength="18" onkeypress="return inputOnlyNumbers(event)" TabIndex="1" 
                                                            ValidationGroup="group" Width="180px"></asp:TextBox>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px; width: 10px;">
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                                                            ControlToValidate="txtcontact24" ErrorMessage="Please Enter Volume of Timber" 
                                                            ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                        <td style="width: 27px">
                                            &nbsp;</td>
                                        <td valign="top">
                                            <table cellpadding="4" cellspacing="5" style="width: 83%">
                                                
                                                <tr>
                                                    <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                        4</td>
                                                    <td style="padding: 5px; margin: 5px; text-align: left;">
                                                        <asp:Label ID="Label416" runat="server" CssClass="LBLBLACK" Width="165px">Girth<font 
                                                            color="red">*</font></asp:Label>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        :</td>
                                                    <td style="padding: 5px; margin: 5px; text-align: left;">
                                                        <asp:TextBox ID="txtcontact18" runat="server" class="form-control txtbox" 
                                                            Height="28px" MaxLength="18" onkeypress="return inputOnlyNumbers(event)" TabIndex="1" 
                                                            ValidationGroup="group" Width="180px"></asp:TextBox>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                                                            ControlToValidate="txtcontact18" ErrorMessage="Please enter Girth" 
                                                            ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="padding: 5px; margin: 5px">
                                                        5</td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        <asp:Label ID="Label445" runat="server" CssClass="LBLBLACK" Width="165px">Estimated Firewood/Rootwood/Faggot<font 
                                                            color="red">*</font></asp:Label>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        :</td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        <asp:TextBox ID="txtcontact31" runat="server" class="form-control txtbox" 
                                                            Height="28px" MaxLength="18" onkeypress="return inputOnlyNumbers(event)" TabIndex="1" 
                                                            ValidationGroup="group" Width="180px"></asp:TextBox>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
                                                            ControlToValidate="txtcontact31" 
                                                            ErrorMessage="Please enter Firewood/Rootwood/Faggot" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="padding: 5px; margin: 5px">
                                                        6</td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        <asp:Label ID="Label446" runat="server" CssClass="LBLBLACK" Width="165px">Pole<font 
                                                            color="red">*</font></asp:Label>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        :</td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        <asp:TextBox ID="txtcontact32" runat="server" class="form-control txtbox" 
                                                            Height="28px" MaxLength="18" onkeypress="return inputOnlyNumbers(event)" TabIndex="1" 
                                                            ValidationGroup="group" Width="180px"></asp:TextBox>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" 
                                                            ControlToValidate="txtcontact32" ErrorMessage="Please enter Forest pole" 
                                                            ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="padding: 5px; margin: 5px">
                                                        &nbsp;</td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        &nbsp;</td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        &nbsp;</td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        <asp:Button ID="BtnSave3" runat="server" CssClass="btn btn-xs btn-warning" 
                                                            Height="28px" TabIndex="10" Text="Add New" 
                                                            Width="72px" onclick="BtnSave3_Click" />
                                                        &nbsp;<asp:Button ID="BtnClear1" runat="server" CausesValidation="False" 
                                                            CssClass="btn btn-xs btn-danger" Height="28px" TabIndex="10" Text="Cancel" 
                                                            ToolTip="To Clear  the Screen" Width="73px" onclick="BtnClear1_Click" />
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        &nbsp;</td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    
                                    <tr>
                                        <td style="padding: 5px; margin: 5px" valign="top" colspan="3">
                                            <asp:GridView ID="gvCertificate" runat="server" AutoGenerateColumns="False" 
                                                BorderColor="#003399" BorderStyle="Solid" BorderWidth="1px" CellPadding="4" 
                                                CssClass="GRD" ForeColor="#333333" GridLines="None" 
                                                OnRowDataBound="gvCertificate_RowDataBound" 
                                                OnRowDeleting="gvCertificate_RowDeleting" Width="100%" 
                                                DataKeyNames="intCFEForestBulkid">
                                                <rowstyle backcolor="#ffffff" />
                                                <columns>
                                                    <asp:CommandField HeaderText="Edit" ShowSelectButton="True" Visible="False" />
                                                    <asp:CommandField HeaderText="Delete" ShowDeleteButton="True" />
                                                    <asp:BoundField DataField="Species" HeaderText="Species" />
                                                    <asp:BoundField DataField="Est_Len_Timber" HeaderText="Timber Length" />
                                                    <asp:BoundField DataField="Est_Vol_Timber" HeaderText="Timber Volume" />
                                                    <asp:BoundField DataField="Girth" HeaderText="Timber Girth" />
                                                    <asp:BoundField DataField="Est_FireWood" HeaderText="Estimated Firewood" />
                                                    <asp:BoundField DataField="Forest_Pole" HeaderText="Pole" />
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
                                           <td style="padding: 5px; margin: 5px" valign="top">
                                               <asp:Label ID="Label447" runat="server" CssClass="LBLBLACK" Font-Bold="True" 
                                                   Width="210px">B) Boundary Description</asp:Label>
                                           </td>
                                           <td style="width: 27px">
                                               &nbsp;</td>
                                           <td valign="top">
                                               &nbsp;</td>
                                       </tr>
                                    
                                    
                                       <tr>
                                           <td style="padding: 5px; margin: 5px" valign="top">
                                               <table cellpadding="4" cellspacing="5" style="width: 83%">
                                                   <tr>
                                                       <td style="padding: 5px; margin: 5px; text-align: left;">
                                                           1</td>
                                                       <td class="style8" style="padding: 5px; margin: 5px; text-align: left;">
                                                           <asp:Label ID="Label387" runat="server" CssClass="LBLBLACK" Width="210px">North<font 
                                                            color="red">*</font></asp:Label>
                                                       </td>
                                                       <td style="padding: 5px; margin: 5px">
                                                           :</td>
                                                       <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                           <asp:TextBox ID="txtcontact25" runat="server" class="form-control txtbox" 
                                                               Height="28px" MaxLength="40"  TabIndex="1" 
                                                               ValidationGroup="child" Width="180px"></asp:TextBox>
                                                       </td>
                                                       <td style="padding: 5px; margin: 5px; width: 10px;">
                                                           <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" 
                                                               ControlToValidate="txtcontact25" ErrorMessage="Please enter North" 
                                                               ValidationGroup="child">*</asp:RequiredFieldValidator>
                                                       </td>
                                                   </tr>
                                                   <tr>
                                                       <td style="padding: 5px; margin: 5px; text-align: left;">
                                                           2</td>
                                                       <td class="style8" style="padding: 5px; margin: 5px; text-align: left;">
                                                           <asp:Label ID="Label396" runat="server" CssClass="LBLBLACK" Width="165px">East<font 
                                                            color="red">*</font></asp:Label>
                                                       </td>
                                                       <td style="padding: 5px; margin: 5px">
                                                           :</td>
                                                       <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                           <asp:TextBox ID="txtcontact26" runat="server" class="form-control txtbox" 
                                                               Height="28px" MaxLength="40"  TabIndex="1" 
                                                               ValidationGroup="child" Width="180px"></asp:TextBox>
                                                       </td>
                                                       <td style="padding: 5px; margin: 5px">
                                                           <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" 
                                                               ControlToValidate="txtcontact26" ErrorMessage="Please enter East" 
                                                               ValidationGroup="child">*</asp:RequiredFieldValidator>
                                                       </td>
                                                   </tr>
                                                   <tr>
                                                       <td style="padding: 5px; margin: 5px; text-align: left;">
                                                           &nbsp;</td>
                                                       <td class="style8" style="padding: 5px; margin: 5px; text-align: left;">
                                                           <asp:Label ID="Label6" runat="server" CssClass="LBLBLACK" Width="180px">Is there any need to Fell trees in Proposed Site<font 
                                                            color="red">*</font></asp:Label>
                                                       </td>
                                                       <td style="padding: 5px; margin: 5px">
                                                           :</td>
                                                       <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                           <asp:RadioButtonList ID="RdProp_Site" runat="server" AutoPostBack="True" 
                                                               RepeatDirection="Horizontal">
                                                               <asp:ListItem Value="Y">Yes</asp:ListItem>
                                                               <asp:ListItem Selected="True" Value="N">No</asp:ListItem>
                                                           </asp:RadioButtonList>
                                                       </td>
                                                       <td style="padding: 5px; margin: 5px">
                                                           &nbsp;</td>
                                                   </tr>
                                                   <tr>
                                                       <td style="padding: 5px; margin: 5px; text-align: left;">
                                                           &nbsp;</td>
                                                       <td class="style8" style="padding: 5px; margin: 5px; text-align: left;">
                                                           <asp:Label ID="Label9" runat="server" CssClass="LBLBLACK" Width="180px">Number of trees to be felled(Girth of tree &gt; 30 centimeters)<font 
                                                            color="red">*</font></asp:Label>
                                                       </td>
                                                       <td style="padding: 5px; margin: 5px">
                                                           :</td>
                                                       <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                           <asp:TextBox ID="Txt_NoofTrees" runat="server" AutoPostBack="True" 
                                                               class="form-control txtbox" Height="28px" MaxLength="4" 
                                                               onkeypress="NumberOnly()"  TabIndex="0" 
                                                               ValidationGroup="group" Width="180px">
                                                               
                                                               </asp:TextBox>
                                                       </td>
                                                       <td style="padding: 5px; margin: 5px">
                                                           &nbsp;</td>
                                                   </tr>
                                                   <tr>
                                                       <td class="style9" style="padding: 5px; margin: 5px; text-align: left;">
                                                       </td>
                                                       <td class="style9" style="padding: 5px; margin: 5px; text-align: left;">
                                                           <asp:Label ID="Label450" runat="server" CssClass="LBLBLACK" Width="165px">Forest Document Upload</asp:Label>
                                                       </td>
                                                       <td class="style9" style="padding: 5px; margin: 5px">
                                                           :</td>
                                                       <td class="style10" style="padding: 5px; margin: 5px; text-align: left;">
                                                           <asp:FileUpload ID="FileUpload1" runat="server" class="form-control txtbox" 
                                                               Height="28px" />
                                                           <asp:HyperLink ID="lblFileName" runat="server" CssClass="LBLBLACK" 
                                                               Width="165px"></asp:HyperLink>
                                                           <br />
                                                           <asp:Label ID="Label449" runat="server" Visible="False"></asp:Label>
                                                       </td>
                                                       <td class="style9" style="padding: 5px; margin: 5px">
                                                       </td>
                                                   </tr>
                                                   <tr>
                                                       <td style="padding: 5px; margin: 5px; text-align: left;">
                                                           &nbsp;</td>
                                                       <td class="style8" style="padding: 5px; margin: 5px; text-align: left;">
                                                           &nbsp;</td>
                                                       <td style="padding: 5px; margin: 5px">
                                                           &nbsp;</td>
                                                       <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                           <asp:Button ID="BtnSave4" runat="server" CssClass="btn btn-xs btn-warning" 
                                                               Height="28px" OnClick="BtnSave4_Click" TabIndex="10" Text="Upload" 
                                                               ValidationGroup="group" Width="72px" />
                                                       </td>
                                                       <td style="padding: 5px; margin: 5px">
                                                           &nbsp;</td>
                                                   </tr>
                                                   <tr>
                                                       <td style="padding: 5px; margin: 5px; text-align: left;">
                                                           &nbsp;</td>
                                                       <td class="style8" style="padding: 5px; margin: 5px; text-align: left;">
                                                           <asp:Label ID="Label451" runat="server" CssClass="LBLBLACK" Width="165px">Forest  Document Upload</asp:Label>
                                                       </td>
                                                       <td style="padding: 5px; margin: 5px">
                                                           :</td>
                                                       <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                           <asp:FileUpload ID="FileUpload2" runat="server" class="form-control txtbox" 
                                                               Height="28px" />
                                                           <asp:HyperLink ID="Label1" runat="server" CssClass="LBLBLACK" Target="_blank" 
                                                               Width="165px">[Label1]</asp:HyperLink>
                                                           <br />
                                                           <asp:Label ID="Label452" runat="server" Visible="False"></asp:Label>
                                                       </td>
                                                       <td style="padding: 5px; margin: 5px">
                                                           &nbsp;</td>
                                                   </tr>
                                                   <tr>
                                                       <td style="padding: 5px; margin: 5px; text-align: left;">
                                                           &nbsp;</td>
                                                       <td class="style8" style="padding: 5px; margin: 5px; text-align: left;">
                                                           &nbsp;</td>
                                                       <td style="padding: 5px; margin: 5px">
                                                           &nbsp;</td>
                                                       <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                           <asp:Button ID="Button1" runat="server" CssClass="btn btn-xs btn-warning" 
                                                               Height="28px" onclick="Button1_Click" TabIndex="10" Text="Upload" 
                                                               Width="72px" />
                                                       </td>
                                                       <td style="padding: 5px; margin: 5px">
                                                           &nbsp;</td>
                                                   </tr>
                                               </table>
                                           </td>
                                           <td style="width: 27px">
                                               <asp:Label ID="Label348" runat="server" CssClass="LBLBLACK" Width="50px"></asp:Label>
                                           </td>
                                           <td valign="top">
                                               <table cellpadding="4" cellspacing="5" style="width: 100%">
                                                   <tr>
                                                       <td style="padding: 5px; margin: 5px; text-align: left;">
                                                           3</td>
                                                       <td class="style8" style="padding: 5px; margin: 5px; text-align: left;">
                                                           <asp:Label ID="Label435" runat="server" CssClass="LBLBLACK" Width="165px">West<font 
                                                            color="red">*</font></asp:Label>
                                                       </td>
                                                       <td style="padding: 5px; margin: 5px">
                                                           :</td>
                                                       <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                           <asp:TextBox ID="txtcontact28" runat="server" class="form-control txtbox" 
                                                               Height="28px" MaxLength="40" TabIndex="1" 
                                                               ValidationGroup="child" Width="180px"></asp:TextBox>
                                                       </td>
                                                       <td style="padding: 5px; margin: 5px">
                                                           <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" 
                                                               ControlToValidate="txtcontact28" ErrorMessage="Please enter west" 
                                                               ValidationGroup="child">*</asp:RequiredFieldValidator>
                                                       </td>
                                                   </tr>
                                                   <tr>
                                                       <td style="padding: 5px; margin: 5px; text-align: left;">
                                                           4&nbsp;</td>
                                                       <td class="style8" style="padding: 5px; margin: 5px; text-align: left;">
                                                           <asp:Label ID="Label436" runat="server" CssClass="LBLBLACK" Width="165px">South<font 
                                                            color="red">*</font></asp:Label>
                                                       </td>
                                                       <td style="padding: 5px; margin: 5px">
                                                           :</td>
                                                       <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                           <asp:TextBox ID="txtcontact29" runat="server" class="form-control txtbox" 
                                                               Height="28px" MaxLength="40"  TabIndex="1" 
                                                               ValidationGroup="child" Width="180px"></asp:TextBox>
                                                       </td>
                                                       <td style="padding: 5px; margin: 5px">
                                                           <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" 
                                                               ControlToValidate="txtcontact29" ErrorMessage="Please enter South" 
                                                               ValidationGroup="child">*</asp:RequiredFieldValidator>
                                                       </td>
                                                   </tr>
                                                   <tr>
                                                       <td style="padding: 5px; margin: 5px; text-align: left;">
                                                           &nbsp;</td>
                                                       <td class="style8" style="padding: 5px; margin: 5px; text-align: left;">
                                                           &nbsp;</td>
                                                       <td style="padding: 5px; margin: 5px">
                                                           &nbsp;</td>
                                                       <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                           &nbsp;</td>
                                                       <td style="padding: 5px; margin: 5px">
                                                           &nbsp;</td>
                                                   </tr>
                                               </table>
                                           </td>
                                       </tr>
                                 
                                    <tr>
                                        <td style="padding: 5px; margin: 5px" colspan="3" align="center" class="style7">
                                            &nbsp;<tr>
                                        <td style="padding: 5px; margin: 5px" colspan="3" align="center">
                                            &nbsp;</td>
                                    </tr> 
                                            <caption>
                                                &nbsp;</caption>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center" colspan="3" 
                                            style="padding: 5px; margin: 5px; text-align: center;">
                                            <asp:Button ID="BtnSave1" runat="server" CssClass="btn btn-primary" 
                                                Height="32px" onclick="BtnSave_Click" TabIndex="10" Text="Save" 
                                                Width="90px" />
                                            &nbsp;&nbsp;<asp:Button ID="BtnDelete" runat="server" 
                                                CssClass="btn btn-danger" Height="32px" onclick="BtnClear0_Click" TabIndex="10" 
                                                Text="Next" Width="90px" 
                                                 />
                                            &nbsp;
                                            <asp:Button ID="BtnDelete0" runat="server" 
                                                CssClass="btn btn-danger" Height="32px" onclick="BtnDelete0_Click" TabIndex="10" 
                                                Text="Previous" Width="90px" CausesValidation="False" />
                                            &nbsp;<asp:Button ID="BtnClear" runat="server" CausesValidation="False" 
                                                CssClass="btn btn-warning" Height="32px" onclick="BtnClear_Click" TabIndex="10" 
                                                Text="ClearAll" ToolTip="To Clear  the Screen" Width="90px" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center" colspan="3" style="padding: 5px; margin: 5px">
                                            
                                            
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
                                <br />
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
            <asp:PostBackTrigger ControlID="BtnSave4" />
<asp:PostBackTrigger ControlID="BtnSave4"></asp:PostBackTrigger>
<asp:PostBackTrigger ControlID="Button1"></asp:PostBackTrigger>

<asp:PostBackTrigger ControlID="BtnSave4"></asp:PostBackTrigger>
<asp:PostBackTrigger ControlID="Button1"></asp:PostBackTrigger>

<asp:PostBackTrigger ControlID="BtnSave4"></asp:PostBackTrigger>
<asp:PostBackTrigger ControlID="Button1"></asp:PostBackTrigger>

<asp:PostBackTrigger ControlID="BtnSave4"></asp:PostBackTrigger>
<asp:PostBackTrigger ControlID="Button1"></asp:PostBackTrigger>

<asp:PostBackTrigger ControlID="BtnSave4"></asp:PostBackTrigger>
<asp:PostBackTrigger ControlID="Button1"></asp:PostBackTrigger>

<asp:PostBackTrigger ControlID="BtnSave4"></asp:PostBackTrigger>
<asp:PostBackTrigger ControlID="Button1"></asp:PostBackTrigger>

</Triggers>
<Triggers>
            <asp:PostBackTrigger ControlID="BtnSave4" />
            <asp:PostBackTrigger ControlID="Button1" />
            
            </Triggers>
  
  </asp:UpdatePanel>
 <%--</div>
       </td>
        </tr>
    </table>--%>
</asp:Content>

