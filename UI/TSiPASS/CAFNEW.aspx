<%@ Page Language="C#" AutoEventWireup="true"  MasterPageFile="~/UI/TSiPASS/EmptyMaster.master" CodeFile="CAFNEW.aspx.cs" Inherits="UI_TSiPASS_CAFNEW" %>


<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script src="../../Resource/Scripts/js/validations.js" type="text/javascript"></script>
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

        .update {
            position: fixed;
            top: 0px;
            left: 0px;
            min-height: 100%;
            min-width: 100%;
            background-image: url("../../Images/ajax-loaderblack.gif"); /*background-image: url("Images/spinner_60.gif");*/
            background-position: center center;
            background-repeat: no-repeat; /*background-color: #e4e4e6;*/
            background-color: #535252;
            z-index: 500 !important;
            opacity: 0.6;
            overflow: hidden;
        }

        .style5 {
            color: #FF0000;
        }
    </style>
    <script type="text/javascript" language="javascript">

        function OpenPopup() {

            window.open("Lookups/LookupBDC.aspx", "List", "scrollbars=yes,resizable=yes,width=1000,height=650;display = block;position=absolute");

            return false;
        }
    </script>
    <link href="assets/css/basic.css" rel="stylesheet" />
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
        function alpha(e) {
            var k;
            document.all ? k = e.keyCode : k = e.which;
            return ((k > 64 && k < 91) || (k > 96 && k < 123) || k == 8 || k == 32 || (k >= 48 && k <= 57));
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
                <ol class="breadcrumb">
                    You are here &nbsp;!&nbsp; &nbsp; &nbsp;
                    <li><i class="fa fa-dashboard"></i><a href="Home.aspx"></a></li>
                    <li class=""><i class="fa fa-fw fa-edit">CAF</i> </li>
                    <li class="active"><i class="fa fa-edit"></i><a href="#">Entrepreneur Details</a>
                    </li>
                </ol>
            </div>
            <div align="left">
                <div class="row" align="left">
                    <div class="col-lg-11">
                        <%--<div class="panel panel-primary">
                           <div class="panel-heading" align="center">
                                <h3 class="panel-title">
                                    Entrepreneur Details</h3>
                            </div>--%>
                        <div class="col-md-12">
                            <h1 class="page-head-line" align="left" style="font-size: x-large">
                                Common Application Form </h1>
                        </div>
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>
                                <div class="panel-body" align="left">
                                    <table align="left" cellpadding="10" cellspacing="5" style="width: 90%">
                                        
                                       
                                        <tr>
                                           <td style="padding: 5px; margin: 5px" valign="top" align="left">
                                               <span style="font-weight: bold">CGD Entity Name (or) Firm / Company Name</span>
                                           </td>
                                           <td style="width: 27px">
                                               &nbsp;
                                           </td>
                                           <td valign="top">
                                               &nbsp;
                                           </td>
                                       </tr>
                               
                                       <tr>
                                           <td align="left" style="padding: 5px; margin: 5px" valign="top">
                                               <table cellpadding="4" cellspacing="5" style="width: 83%">
                                                     <tr>
     <td style="padding: 5px; margin: 5px; text-align: left;">
         1.
     </td>
     <td style="padding: 5px; margin: 5px; text-align: left;">
         <asp:Label ID="Label1" runat="server" CssClass="LBLBLACK" Width="165px">CGD Entity Name<font 
         color="red">*</font></asp:Label>
     </td>
     <td style="padding: 5px; margin: 5px">
         :
     </td>
     <td style="padding: 5px; margin: 5px; text-align: left;">
         <asp:TextBox ID="TextBox60" runat="server" class="form-control txtbox" onkeypress="Names()"
             Height="28px" MaxLength="40" TabIndex="1" ValidationGroup="group" Width="180px"></asp:TextBox>
     </td>
     <td style="padding: 5px; margin: 5px">
         
     </td>
                                </tr 
                                                   <tr>
     <td style="padding: 5px; margin: 5px; text-align: left;">
         2.
     </td>
     <td style="padding: 5px; margin: 5px; text-align: left;">
         <asp:Label ID="Label10" runat="server" CssClass="LBLBLACK" Width="165px">AuthorizedPerson Name<font 
         color="red">*</font></asp:Label>
     </td>
     <td style="padding: 5px; margin: 5px">
         :
     </td>
     <td style="padding: 5px; margin: 5px; text-align: left;">
         <asp:TextBox ID="TextBox61" runat="server" class="form-control txtbox" onkeypress="Names()"
             Height="28px" MaxLength="40" TabIndex="1" ValidationGroup="group" Width="180px"></asp:TextBox>
     </td>
     <td style="padding: 5px; margin: 5px">
         
     </td>
 </tr>
                                                  
                                               </table>
                                           </td>
                                           <td style="width: 27px">
                                               &nbsp;
                                           </td>
                                           <td valign="top">
                                               <table cellpadding="4" cellspacing="5" style="width: 83%">
                                                                                                       <tr>
    <td style="padding: 5px; margin: 5px; text-align: left;">
        3.
    </td>
    <td style="padding: 5px; margin: 5px; text-align: left;">
        <asp:Label ID="Label78" runat="server" CssClass="LBLBLACK" Width="165px">Designation <font 
        color="red">*</font></asp:Label>
    </td>
    <td style="padding: 5px; margin: 5px">
        :
    </td>
    <td style="padding: 5px; margin: 5px; text-align: left;">
        <asp:TextBox ID="TextBox62" runat="server" class="form-control txtbox" onkeypress="Names()"
            Height="28px" MaxLength="40" TabIndex="1" ValidationGroup="group" Width="180px"></asp:TextBox>
    </td>
    <td style="padding: 5px; margin: 5px">
  
    </td>
</tr 
                                                                                                           <tr runat="server" id="tr1">
   <%-- <td style="padding: 5px; margin: 5px">
        4.
    </td>
    <td style="width: 200px;">
        Designation<span class="style5">*</span>
    </td>
    <td style="padding: 5px; margin: 5px">
        :
    </td>
    <td style="padding: 5px; margin: 5px; text-align: left;">
    <asp:TextBox ID="TextBox5" runat="server" class="form-control txtbox" onkeypress="Names()"
        Height="28px" MaxLength="40" TabIndex="1" ValidationGroup="group" Width="180px"></asp:TextBox>
    </td>
    <td style="padding: 5px; margin: 5px">
      
    </td>--%>
</tr>
                                                 
                                               </table>
                                           </td>
                                       </tr>
                                       <tr id="Tr2" runat="server" visible="false">
                                           <td style="padding: 5px; margin: 5px" valign="top" align="left">
                                               &nbsp;&nbsp;&nbsp; <span style="font-weight: bold"><u>B). Expansion Investment</u></span>
                                           </td>
                                           <td style="width: 27px">
                                               &nbsp;
                                           </td>
                                           <td valign="top">
                                               &nbsp;
                                           </td>
                                       </tr>
                                       <tr id="Tr27" runat="server" visible="false">
                                           <td align="left" style="padding: 5px; margin: 5px" valign="top">
                                               <table cellpadding="4" cellspacing="5" style="width: 83%">
                                                   <tr>
                                                       <td style="padding: 5px; margin: 5px; text-align: left;">
                                                           1.
                                                       </td>
                                                       <td style="padding: 5px; margin: 5px; text-align: left;">
                                                           <asp:Label ID="Label79" runat="server" CssClass="LBLBLACK" Width="210px">Land Value(in Lakhs)<font 
                                                           color="red">*</font></asp:Label>
                                                       </td>
                                                       <td style="padding: 5px; margin: 5px">
                                                           :
                                                       </td>
                                                       <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                           <asp:TextBox ID="TextBox81" runat="server" class="form-control txtbox" Height="28px"
                                                               MaxLength="10" onkeypress="return inputOnlyNumbers(event)" TabIndex="1" ValidationGroup="group"
                                                               Width="180px" AutoPostBack="True"></asp:TextBox>
                                                       </td>
                                                       <td style="padding: 5px; margin: 5px; width: 10px;">
                                                           <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator29" runat="server" ControlToValidate="txtlandValue"
                                                                   ErrorMessage="Please enter  Land Values" ValidationGroup="group">*</asp:RequiredFieldValidator>--%>
                                                       </td>
                                                   </tr>
                                                   <tr>
                                                       <td style="padding: 5px; margin: 5px; text-align: left;">
                                                           2.
                                                       </td>
                                                       <td style="padding: 5px; margin: 5px; text-align: left;">
                                                           <asp:Label ID="Label86" runat="server" CssClass="LBLBLACK" Width="165px">Building Value(in Lakhs)<font 
                                                           color="red">*</font></asp:Label>
                                                       </td>
                                                       <td style="padding: 5px; margin: 5px">
                                                           :
                                                       </td>
                                                       <td style="padding: 5px; margin: 5px; text-align: left;">
                                                           <asp:TextBox ID="TextBox82" runat="server" class="form-control txtbox" Height="28px"
                                                               MaxLength="1" onkeypress="return inputOnlyNumbers(event)" TabIndex="1" ValidationGroup="group"
                                                               Width="180px" AutoPostBack="True"></asp:TextBox>
                                                       </td>
                                                       <td style="padding: 5px; margin: 5px">
                                                           <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator30" runat="server" ControlToValidate="txtbuilding"
                                                                   ErrorMessage="Please enter  Building Values" ValidationGroup="group">*</asp:RequiredFieldValidator>--%>
                                                       </td>
                                                   </tr>
                                               </table>
                                           </td>
                                           <td style="width: 27px">
                                               &nbsp;
                                           </td>
                                           <td valign="top">
                                               <table cellpadding="4" cellspacing="5" style="width: 83%">
                                                   <tr>
                                                       <td style="padding: 5px; margin: 5px; text-align: left;">
                                                           3.
                                                       </td>
                                                       <td style="padding: 5px; margin: 5px; text-align: left;">
                                                           <asp:Label ID="Label87" runat="server" CssClass="LBLBLACK" Width="165px">Plant and Machinery Value(in Lakhs) <font 
                                                           color="red">*</font></asp:Label>
                                                       </td>
                                                       <td style="padding: 5px; margin: 5px">
                                                           :
                                                       </td>
                                                       <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                           <asp:TextBox ID="TextBox87" runat="server" class="form-control txtbox" Height="28px"
                                                               MaxLength="10" onkeypress="return inputOnlyNumbers(event)" TabIndex="1" ValidationGroup="group"
                                                               Width="180px" AutoPostBack="True"></asp:TextBox>
                                                       </td>
                                                       <td style="padding: 5px; margin: 5px; width: 10px;">
                                                           <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator31" runat="server" ControlToValidate="txtPlant"
                                                                   ErrorMessage="Please enter  Plant and Machinery" ValidationGroup="group">*</asp:RequiredFieldValidator>--%>
                                                       </td>
                                                   </tr>
                                                   <tr>
                                                       <td style="padding: 5px; margin: 5px; text-align: left;">
                                                           4.
                                                       </td>
                                                       <td style="padding: 5px; margin: 5px; text-align: left;">
                                                           <asp:Label ID="Label88" runat="server" CssClass="LBLBLACK" Width="165px">Total Value(in Lakhs)<font 
                                                           color="red">*</font></asp:Label>
                                                       </td>
                                                       <td style="padding: 5px; margin: 5px">
                                                           :
                                                       </td>
                                                       <td style="padding: 5px; margin: 5px; text-align: left;">
                                                           <asp:TextBox ID="TextBox88" runat="server" class="form-control txtbox" Height="28px"
                                                               MaxLength="10" onkeypress="return inputOnlyNumbers(event)" TabIndex="1" ValidationGroup="group"
                                                               Width="180px"></asp:TextBox>
                                                       </td>
                                                       <td style="padding: 5px; margin: 5px">
                                                           <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator32" runat="server" ControlToValidate="txttotal"
                                                                   ErrorMessage="Please enter  Total Values" ValidationGroup="group">*</asp:RequiredFieldValidator>--%>
                                                       </td>
                                                   </tr>
                                               </table>
                                           </td>
                                       </tr>    
                                        <tr>
                                                                                                                           <tr>
                                           <td style="padding: 5px; margin: 5px" valign="top" align="left">
                                               <span style="font-weight: bold">Registered Office Address</span>
                                           </td>
                                           <td style="width: 27px">
                                               &nbsp;
                                           </td>
                                           <td valign="top">
                                               &nbsp;
                                           </td>
                                       </tr>
                                       
                                       <tr>
                                           <td align="left" style="padding: 5px; margin: 5px" valign="top">
                                               <table cellpadding="4" cellspacing="5" style="width: 83%">
                                                     <tr>
      <td style="padding: 5px; margin: 5px">
          1.
      </td>
      <td style="padding: 5px; margin: 5px">
          <asp:Label ID="Label32" runat="server" CssClass="LBLBLACK" Width="165px">State<font 
          color="red">*</font></asp:Label>
      </td>
      <td style="padding: 5px; margin: 5px">
          :
      </td>
      <td style="padding: 5px; margin: 5px">
          <asp:DropDownList ID="DropDownList5" runat="server" class="form-control txtbox" Height="33px"
              Width="180px" AutoPostBack="True" 
              TabIndex="1">
              <asp:ListItem>--Select--</asp:ListItem>
          </asp:DropDownList>
      </td>
      <td style="padding: 5px; margin: 5px">
         
      </td>
  </tr>
                                                     <tr>
    <td style="padding: 5px; margin: 5px">
        2.
    </td>
    <td style="padding: 5px; margin: 5px">
        <asp:Label ID="Label11" runat="server" CssClass="LBLBLACK" Width="165px">District<font 
        color="red">*</font></asp:Label>
    </td>
    <td style="padding: 5px; margin: 5px">
        :
    </td>
    <td style="padding: 5px; margin: 5px">
        <asp:DropDownList ID="DropDownList6" runat="server" class="form-control txtbox" Height="33px"
            Width="180px" AutoPostBack="True" 
            TabIndex="1">
            <asp:ListItem>--Select--</asp:ListItem>
        </asp:DropDownList>
    </td>
    <td style="padding: 5px; margin: 5px">
        
    </td>
</tr>
                                                                                                        <tr>
    <td style="padding: 5px; margin: 5px">
        3.
    </td>
    <td style="padding: 5px; margin: 5px">
        <asp:Label ID="Label12" runat="server" CssClass="LBLBLACK" Width="165px">Mandal<font 
        color="red">*</font></asp:Label>
    </td>
    <td style="padding: 5px; margin: 5px">
        :
    </td>
    <td style="padding: 5px; margin: 5px">
        <asp:DropDownList ID="DropDownList7" runat="server" class="form-control txtbox" Height="33px"
            Width="180px" AutoPostBack="True" 
            TabIndex="1">
            <asp:ListItem>--Select--</asp:ListItem>
        </asp:DropDownList>
    </td>
    <td style="padding: 5px; margin: 5px">
    
    </td>
</tr>

                                                                                                                                                         <tr>
    <td style="padding: 5px; margin: 5px">
        4.
    </td>
    <td style="padding: 5px; margin: 5px">
        <asp:Label ID="Label33" runat="server" CssClass="LBLBLACK" Width="165px">Village<font 
        color="red">*</font></asp:Label>
    </td>
    <td style="padding: 5px; margin: 5px">
        :
    </td>
    <td style="padding: 5px; margin: 5px">
        <asp:DropDownList ID="DropDownList8" runat="server" class="form-control txtbox" Height="33px"
            Width="180px" AutoPostBack="True" 
            TabIndex="1">
            <asp:ListItem>--Select--</asp:ListItem>
        </asp:DropDownList>
    </td>
    <td style="padding: 5px; margin: 5px">
       
    </td>
</tr>

                                               </table>
                                           </td>
                                           <td style="width: 27px">
                                               &nbsp;
                                           </td>
                                           <td valign="top">
                                               <table cellpadding="4" cellspacing="5" style="width: 83%">
                                                                                                       <tr>
    <td style="padding: 5px; margin: 5px; text-align: left;">
        5.
    </td>
    <td style="padding: 5px; margin: 5px; text-align: left;">
        <asp:Label ID="Label13" runat="server" CssClass="LBLBLACK" Width="165px">Street Name<font 
        color="red">*</font></asp:Label>
    </td>
    <td style="padding: 5px; margin: 5px">
        :
    </td>
    <td style="padding: 5px; margin: 5px; text-align: left;">
        <asp:TextBox ID="TextBox3" runat="server" class="form-control txtbox" onkeypress="Names()"
            Height="28px" MaxLength="40" TabIndex="1" ValidationGroup="group" Width="180px"></asp:TextBox>
    </td>
    <td style="padding: 5px; margin: 5px">
        
    </td>
</tr 
                                                                                                           
                                                   
                                                                                                                                                          <tr>
    <td style="padding: 5px; margin: 5px; text-align: left;">
        6.
    </td>
    <td style="padding: 5px; margin: 5px; text-align: left;">
        <asp:Label ID="Label34" runat="server" CssClass="LBLBLACK" Width="165px">Door No<font 
        color="red">*</font></asp:Label>
    </td>
    <td style="padding: 5px; margin: 5px">
        :
    </td>
    <td style="padding: 5px; margin: 5px; text-align: left;">
        <asp:TextBox ID="TextBox1" runat="server" class="form-control txtbox" onkeypress="Names()"
            Height="28px" MaxLength="40" TabIndex="1" ValidationGroup="group" Width="180px"></asp:TextBox>
    </td>
    <td style="padding: 5px; margin: 5px">
        
    </td>
</tr 
                                                                                                           
                                                   
                                                                                                                                                                                                                                                                     <tr>
    <tr>
     <td style="padding: 5px; margin: 5px">
         7.
     </td>
     <td style="width: 200px;">
         Pincode<span class="style5">*</span>
     </td>
     <td style="padding: 5px; margin: 5px">
         :
     </td>
     <td style="padding: 5px; margin: 5px">
         <asp:TextBox ID="TextBox2" runat="server" class="form-control txtbox" Height="28px"
             MaxLength="6" TabIndex="1" onkeypress="NumberOnly()" onblur="checkLength(this)"
             ValidationGroup="group" Width="180px"></asp:TextBox>
     </td>
     <td style="padding: 5px; margin: 5px">
         
     </td>
 </tr>
                                                                                                           
                                                   
                                                
                                               </table>
                                           </td>
                                       </tr>
                                       <tr id="Tr8" runat="server" visible="false">
                                           <td style="padding: 5px; margin: 5px" valign="top" align="left">
                                               &nbsp;&nbsp;&nbsp; <span style="font-weight: bold"><u>B). Expansion Investment</u></span>
                                           </td>
                                           <td style="width: 27px">
                                               &nbsp;
                                           </td>
                                           <td valign="top">
                                               &nbsp;
                                           </td>
                                       </tr>
                                       <tr id="Tr9" runat="server" visible="false">
                                           <td align="left" style="padding: 5px; margin: 5px" valign="top">
                                               <table cellpadding="4" cellspacing="5" style="width: 83%">
                                                   <tr>
                                                       <td style="padding: 5px; margin: 5px; text-align: left;">
                                                           1.
                                                       </td>
                                                       <td style="padding: 5px; margin: 5px; text-align: left;">
                                                           <asp:Label ID="Label14" runat="server" CssClass="LBLBLACK" Width="210px">Land Value(in Lakhs)<font 
                                                           color="red">*</font></asp:Label>
                                                       </td>
                                                       <td style="padding: 5px; margin: 5px">
                                                           :
                                                       </td>
                                                       <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                           <asp:TextBox ID="TextBox4" runat="server" class="form-control txtbox" Height="28px"
                                                               MaxLength="10" onkeypress="return inputOnlyNumbers(event)" TabIndex="1" ValidationGroup="group"
                                                               Width="180px" AutoPostBack="True"></asp:TextBox>
                                                       </td>
                                                       <td style="padding: 5px; margin: 5px; width: 10px;">
                                                           <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator29" runat="server" ControlToValidate="txtlandValue"
                                                                   ErrorMessage="Please enter  Land Values" ValidationGroup="group">*</asp:RequiredFieldValidator>--%>
                                                       </td>
                                                   </tr>
                                                   <tr>
                                                       <td style="padding: 5px; margin: 5px; text-align: left;">
                                                           2.
                                                       </td>
                                                       <td style="padding: 5px; margin: 5px; text-align: left;">
                                                           <asp:Label ID="Label22" runat="server" CssClass="LBLBLACK" Width="165px">Building Value(in Lakhs)<font 
                                                           color="red">*</font></asp:Label>
                                                       </td>
                                                       <td style="padding: 5px; margin: 5px">
                                                           :
                                                       </td>
                                                       <td style="padding: 5px; margin: 5px; text-align: left;">
                                                           <asp:TextBox ID="TextBox12" runat="server" class="form-control txtbox" Height="28px"
                                                               MaxLength="1" onkeypress="return inputOnlyNumbers(event)" TabIndex="1" ValidationGroup="group"
                                                               Width="180px" AutoPostBack="True"></asp:TextBox>
                                                       </td>
                                                       <td style="padding: 5px; margin: 5px">
                                                           <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator30" runat="server" ControlToValidate="txtbuilding"
                                                                   ErrorMessage="Please enter  Building Values" ValidationGroup="group">*</asp:RequiredFieldValidator>--%>
                                                       </td>
                                                   </tr>
                                               </table>
                                           </td>
                                           <td style="width: 27px">
                                               &nbsp;
                                           </td>
                                           <td valign="top">
                                               <table cellpadding="4" cellspacing="5" style="width: 83%">
                                                   <tr>
                                                       <td style="padding: 5px; margin: 5px; text-align: left;">
                                                           3.
                                                       </td>
                                                       <td style="padding: 5px; margin: 5px; text-align: left;">
                                                           <asp:Label ID="Label23" runat="server" CssClass="LBLBLACK" Width="165px">Plant and Machinery Value(in Lakhs) <font 
                                                           color="red">*</font></asp:Label>
                                                       </td>
                                                       <td style="padding: 5px; margin: 5px">
                                                           :
                                                       </td>
                                                       <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                           <asp:TextBox ID="TextBox13" runat="server" class="form-control txtbox" Height="28px"
                                                               MaxLength="10" onkeypress="return inputOnlyNumbers(event)" TabIndex="1" ValidationGroup="group"
                                                               Width="180px" AutoPostBack="True"></asp:TextBox>
                                                       </td>
                                                       <td style="padding: 5px; margin: 5px; width: 10px;">
                                                           <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator31" runat="server" ControlToValidate="txtPlant"
                                                                   ErrorMessage="Please enter  Plant and Machinery" ValidationGroup="group">*</asp:RequiredFieldValidator>--%>
                                                       </td>
                                                   </tr>
                                                   <tr>
                                                       <td style="padding: 5px; margin: 5px; text-align: left;">
                                                           4.
                                                       </td>
                                                       <td style="padding: 5px; margin: 5px; text-align: left;">
                                                           <asp:Label ID="Label24" runat="server" CssClass="LBLBLACK" Width="165px">Total Value(in Lakhs)<font 
                                                           color="red">*</font></asp:Label>
                                                       </td>
                                                       <td style="padding: 5px; margin: 5px">
                                                           :
                                                       </td>
                                                       <td style="padding: 5px; margin: 5px; text-align: left;">
                                                           <asp:TextBox ID="TextBox14" runat="server" class="form-control txtbox" Height="28px"
                                                               MaxLength="10" onkeypress="return inputOnlyNumbers(event)" TabIndex="1" ValidationGroup="group"
                                                               Width="180px"></asp:TextBox>
                                                       </td>
                                                       <td style="padding: 5px; margin: 5px">
                                                           <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator32" runat="server" ControlToValidate="txttotal"
                                                                   ErrorMessage="Please enter  Total Values" ValidationGroup="group">*</asp:RequiredFieldValidator>--%>
                                                       </td>
                                                   </tr>
                                               </table>
                                           </td>
                                       </tr>
                                        <tr>
                                        


                                                                                                                           <tr>
                                           <td style="padding: 5px; margin: 5px" valign="top" align="left">
                                               <span style="font-weight: bold">Contact Details</span>
                                           </td>
                                           <td style="width: 27px">
                                               &nbsp;
                                           </td>
                                           <td valign="top">
                                               &nbsp;
                                           </td>
                                       </tr>
                                     
                                       <tr>
                                           <td align="left" style="padding: 5px; margin: 5px" valign="top">
                                               <table cellpadding="4" cellspacing="5" style="width: 83%">
                                                    <tr>
     <td style="padding: 5px; margin: 5px">
         1.
     </td>
     <%--<td style="width: 200px;">
         Mobile No<span class="style5">*</span>
     </td>--%>
      <td style="padding: 5px; margin: 5px; text-align: left;">
     <asp:Label ID="Label16" runat="server" CssClass="LBLBLACK" Width="165px"> Mobile No<font 
     color="red">*</font></asp:Label>
 </td>
     <td style="padding: 5px; margin: 5px">
         :
     </td>
     <td style="padding: 5px; margin: 5px">
         <asp:TextBox ID="TextBox22" runat="server" class="form-control txtbox" Height="28px"
             MaxLength="10" TabIndex="1" onkeypress="NumberOnly()" onblur="checkLength1(this)" Onpaste="return false"
             ValidationGroup="group" Width="180px"></asp:TextBox>
     </td>
     <td style="padding: 5px; margin: 5px">
  
     </td>
 </tr>
 <tr>
     <td style="padding: 5px; margin: 5px">
         2.
     </td>
     <td style="width: 200px;">
         Alternative Mobile No<span class="style5">*</span>
     </td>
     <td style="padding: 5px; margin: 5px">
         :
     </td>
     <td style="padding: 5px; margin: 5px">
         <asp:TextBox ID="TextBox23" runat="server" class="form-control txtbox" Height="28px"
             MaxLength="10" TabIndex="1" onkeypress="NumberOnly()" onblur="checkLength1(this)"
             ValidationGroup="group" Width="180px"></asp:TextBox>
     </td>
     <td style="padding: 5px; margin: 5px">
      
     </td>
 </tr>

                                                    
                                               </table>
                                           </td>
                                           <td style="width: 27px">
                                               &nbsp;
                                           </td>
                                           <td valign="top">
                                               <table cellpadding="4" cellspacing="5" style="width: 83%">
                                                    <tr>
     <td style="padding: 5px; margin: 5px">
         3.
     </td>
    <%-- <td style="width: 200px;">
         Email<span class="style5">*</span>
     </td>--%>
     <td style="padding: 5px; margin: 5px; text-align: left;">
    <asp:Label ID="Label18" runat="server" CssClass="LBLBLACK" Width="165px"> Email<font 
    color="red">*</font></asp:Label>
</td>
     <td style="padding: 5px; margin: 5px">
         :
     </td>
     <td style="padding: 5px; margin: 5px">
         <asp:TextBox ID="TextBox43" runat="server" class="form-control txtbox" Height="28px"
             MaxLength="40" TabIndex="1" ValidationGroup="group" Width="180px"></asp:TextBox>
     </td>
     <td style="padding: 5px; margin: 5px">
         
        
     </td>
 </tr>
                                                                                                      
                                                 
                                               </table>
                                           </td>
                                       </tr>
                                       <tr id="Tr10" runat="server" visible="false">
                                           <td style="padding: 5px; margin: 5px" valign="top" align="left">
                                               &nbsp;&nbsp;&nbsp; <span style="font-weight: bold"><u>B). Expansion Investment</u></span>
                                           </td>
                                           <td style="width: 27px">
                                               &nbsp;
                                           </td>
                                           <td valign="top">
                                               &nbsp;
                                           </td>
                                       </tr>
                                       <tr id="Tr13" runat="server" visible="false">
                                           <td align="left" style="padding: 5px; margin: 5px" valign="top">
                                               <table cellpadding="4" cellspacing="5" style="width: 83%">
                                                   <tr>
                                                       <td style="padding: 5px; margin: 5px; text-align: left;">
                                                           1.
                                                       </td>
                                                       <td style="padding: 5px; margin: 5px; text-align: left;">
                                                           <asp:Label ID="Label41" runat="server" CssClass="LBLBLACK" Width="210px">Land Value(in Lakhs)<font 
                                                           color="red">*</font></asp:Label>
                                                       </td>
                                                       <td style="padding: 5px; margin: 5px">
                                                           :
                                                       </td>
                                                       <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                           <asp:TextBox ID="TextBox25" runat="server" class="form-control txtbox" Height="28px"
                                                               MaxLength="10" onkeypress="return inputOnlyNumbers(event)" TabIndex="1" ValidationGroup="group"
                                                               Width="180px" AutoPostBack="True"></asp:TextBox>
                                                       </td>
                                                       <td style="padding: 5px; margin: 5px; width: 10px;">
                                                           <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator29" runat="server" ControlToValidate="txtlandValue"
                                                                   ErrorMessage="Please enter  Land Values" ValidationGroup="group">*</asp:RequiredFieldValidator>--%>
                                                       </td>
                                                   </tr>
                                                   <tr>
                                                       <td style="padding: 5px; margin: 5px; text-align: left;">
                                                           2.
                                                       </td>
                                                       <td style="padding: 5px; margin: 5px; text-align: left;">
                                                           <asp:Label ID="Label42" runat="server" CssClass="LBLBLACK" Width="165px">Building Value(in Lakhs)<font 
                                                           color="red">*</font></asp:Label>
                                                       </td>
                                                       <td style="padding: 5px; margin: 5px">
                                                           :
                                                       </td>
                                                       <td style="padding: 5px; margin: 5px; text-align: left;">
                                                           <asp:TextBox ID="TextBox26" runat="server" class="form-control txtbox" Height="28px"
                                                               MaxLength="1" onkeypress="return inputOnlyNumbers(event)" TabIndex="1" ValidationGroup="group"
                                                               Width="180px" AutoPostBack="True"></asp:TextBox>
                                                       </td>
                                                       <td style="padding: 5px; margin: 5px">
                                                           <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator30" runat="server" ControlToValidate="txtbuilding"
                                                                   ErrorMessage="Please enter  Building Values" ValidationGroup="group">*</asp:RequiredFieldValidator>--%>
                                                       </td>
                                                   </tr>
                                               </table>
                                           </td>
                                           <td style="width: 27px">
                                               &nbsp;
                                           </td>
                                           <td valign="top">
                                               <table cellpadding="4" cellspacing="5" style="width: 83%">
                                                   <tr>
                                                       <td style="padding: 5px; margin: 5px; text-align: left;">
                                                           3.
                                                       </td>
                                                       <td style="padding: 5px; margin: 5px; text-align: left;">
                                                           <asp:Label ID="Label43" runat="server" CssClass="LBLBLACK" Width="165px">Plant and Machinery Value(in Lakhs) <font 
                                                           color="red">*</font></asp:Label>
                                                       </td>
                                                       <td style="padding: 5px; margin: 5px">
                                                           :
                                                       </td>
                                                       <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                           <asp:TextBox ID="TextBox27" runat="server" class="form-control txtbox" Height="28px"
                                                               MaxLength="10" onkeypress="return inputOnlyNumbers(event)" TabIndex="1" ValidationGroup="group"
                                                               Width="180px" AutoPostBack="True"></asp:TextBox>
                                                       </td>
                                                       <td style="padding: 5px; margin: 5px; width: 10px;">
                                                           <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator31" runat="server" ControlToValidate="txtPlant"
                                                                   ErrorMessage="Please enter  Plant and Machinery" ValidationGroup="group">*</asp:RequiredFieldValidator>--%>
                                                       </td>
                                                   </tr>
                                                   <tr>
                                                       <td style="padding: 5px; margin: 5px; text-align: left;">
                                                           4.
                                                       </td>
                                                       <td style="padding: 5px; margin: 5px; text-align: left;">
                                                           <asp:Label ID="Label44" runat="server" CssClass="LBLBLACK" Width="165px">Total Value(in Lakhs)<font 
                                                           color="red">*</font></asp:Label>
                                                       </td>
                                                       <td style="padding: 5px; margin: 5px">
                                                           :
                                                       </td>
                                                       <td style="padding: 5px; margin: 5px; text-align: left;">
                                                           <asp:TextBox ID="TextBox28" runat="server" class="form-control txtbox" Height="28px"
                                                               MaxLength="10" onkeypress="return inputOnlyNumbers(event)" TabIndex="1" ValidationGroup="group"
                                                               Width="180px"></asp:TextBox>
                                                       </td>
                                                       <td style="padding: 5px; margin: 5px">
                                                           <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator32" runat="server" ControlToValidate="txttotal"
                                                                   ErrorMessage="Please enter  Total Values" ValidationGroup="group">*</asp:RequiredFieldValidator>--%>
                                                       </td>
                                                   </tr>
                                               </table>
                                           </td>
                                       </tr>
                                        <tr>
                                                                                                                           <tr>
                                           <td style="padding: 5px; margin: 5px" valign="top" align="left">
                                               <span style="font-weight: bold"> Communication Address of the Applicant</span>
                                           </td>
                                           <td style="width: 27px">
                                               &nbsp;
                                           </td>
                                           <td valign="top">
                                               &nbsp;
                                           </td>
                                       </tr>
                                       
                                       <tr>
                                           <td align="left" style="padding: 5px; margin: 5px" valign="top">
                                               <table cellpadding="4" cellspacing="5" style="width: 83%">
                                                                                                                                                          <tr>
    <td style="padding: 5px; margin: 5px; text-align: left;">
        1.
    </td>
    <td style="padding: 5px; margin: 5px; text-align: left;">
        <asp:Label ID="Label49" runat="server" CssClass="LBLBLACK" Width="165px">Applicant Name<font 
        color="red">*</font></asp:Label>
    </td>
    <td style="padding: 5px; margin: 5px">
        :
    </td>
    <td style="padding: 5px; margin: 5px; text-align: left;">
        <asp:TextBox ID="TextBox29" runat="server" class="form-control txtbox" onkeypress="Names()"
            Height="28px" MaxLength="40" TabIndex="1" ValidationGroup="group" Width="180px"></asp:TextBox>
    </td>
    <td style="padding: 5px; margin: 5px">

    </td>
</tr 
                                                    <tr>
     <td style="padding: 5px; margin: 5px">
         2.
     </td>
     <td style="width: 200px;">
         Mobile No<span class="style5">*</span>
     </td>
     <td style="padding: 5px; margin: 5px">
         :
     </td>
     <td style="padding: 5px; margin: 5px">
         <asp:TextBox ID="TextBox24" runat="server" class="form-control txtbox" Height="28px"
             MaxLength="10" TabIndex="1" onkeypress="NumberOnly()" onblur="checkLength1(this)" Onpaste="return false"
             ValidationGroup="group" Width="180px"></asp:TextBox>
     </td>
     <td style="padding: 5px; margin: 5px">
         
     </td>
 </tr>
                                                                                                           
                                                   
                                                                                                                                                          
                                                   <tr>
    <td style="padding: 5px; margin: 5px; text-align: left;">
        3.
    </td>
    <td style="padding: 5px; margin: 5px; text-align: left;">
        <asp:Label ID="Label50" runat="server" CssClass="LBLBLACK" Width="165px">House No / Door No<font 
        color="red">*</font></asp:Label>
    </td>
    <td style="padding: 5px; margin: 5px">
        :
    </td>
    <td style="padding: 5px; margin: 5px; text-align: left;">
        <asp:TextBox ID="TextBox30" runat="server" class="form-control txtbox" onkeypress="Names()"
            Height="28px" MaxLength="40" TabIndex="1" ValidationGroup="group" Width="180px"></asp:TextBox>
    </td>
    <td style="padding: 5px; margin: 5px">
   
    </td>
</tr>
                                                                                                           
                                                                                                                                                                                            <tr>
    <td style="padding: 5px; margin: 5px; text-align: left;">
        4.
    </td>
    <td style="padding: 5px; margin: 5px; text-align: left;">
        <asp:Label ID="Label38" runat="server" CssClass="LBLBLACK" Width="165px">Street / Locality<font 
        color="red">*</font></asp:Label>
    </td>
    <td style="padding: 5px; margin: 5px">
        :
    </td>
    <td style="padding: 5px; margin: 5px; text-align: left;">
        <asp:TextBox ID="TextBox44" runat="server" class="form-control txtbox" onkeypress="Names()"
            Height="28px" MaxLength="40" TabIndex="1" ValidationGroup="group" Width="180px"></asp:TextBox>
    </td>
    <td style="padding: 5px; margin: 5px">
        
    </td>
</tr          

                                                                                                                                                                                                                                                                    
                                                     
                                                 

                                                                                                                                                         <tr>
    <td style="padding: 5px; margin: 5px">
        5.
    </td>
    <td style="padding: 5px; margin: 5px">
        <asp:Label ID="Label48" runat="server" CssClass="LBLBLACK" Width="165px">Village<font 
        color="red">*</font></asp:Label>
    </td>
    <td style="padding: 5px; margin: 5px">
        :
    </td>
    <td style="padding: 5px; margin: 5px">
        <asp:DropDownList ID="DropDownList15" runat="server" class="form-control txtbox" Height="33px"
            Width="180px" AutoPostBack="True"
            TabIndex="1">
            <asp:ListItem>--Select--</asp:ListItem>
        </asp:DropDownList>
    </td>
    <td style="padding: 5px; margin: 5px">
        
    </td>
</tr>

                                               </table>
                                           </td>
                                           <td style="width: 27px">
                                               &nbsp;
                                           </td>
                                           <td valign="top">
                                               <table cellpadding="4" cellspacing="5" style="width: 83%">
                                                                                                      <tr>
      <td style="padding: 5px; margin: 5px">
          6.
      </td>
      <td style="padding: 5px; margin: 5px">
          <asp:Label ID="Label45" runat="server" CssClass="LBLBLACK" Width="165px">State<font 
          color="red">*</font></asp:Label>
      </td>
      <td style="padding: 5px; margin: 5px">
          :
      </td>
      <td style="padding: 5px; margin: 5px">
         <asp:DropDownList ID="DropDownList3" runat="server" class="form-control txtbox" Height="33px"
    Width="180px" AutoPostBack="True" 
    TabIndex="1">
    <asp:ListItem>--Select--</asp:ListItem>
</asp:DropDownList>
      </td>
      <td style="padding: 5px; margin: 5px">
         
      </td>
  </tr>
                                                     <tr>
    <td style="padding: 5px; margin: 5px">
        7.
    </td>
    <td style="padding: 5px; margin: 5px">
        <asp:Label ID="Label46" runat="server" CssClass="LBLBLACK" Width="165px">District<font 
        color="red">*</font></asp:Label>
    </td>
    <td style="padding: 5px; margin: 5px">
        :
    </td>
    <td style="padding: 5px; margin: 5px">
        <asp:DropDownList ID="DropDownList13" runat="server" class="form-control txtbox" Height="33px"
            Width="180px" AutoPostBack="True" 
            TabIndex="1">
            <asp:ListItem>--Select--</asp:ListItem>
        </asp:DropDownList>
    </td>
    <td style="padding: 5px; margin: 5px">
        
    </td>
</tr>
                                                                                                        <tr>
    <td style="padding: 5px; margin: 5px">
        8.
    </td>
    <td style="padding: 5px; margin: 5px">
        <asp:Label ID="Label47" runat="server" CssClass="LBLBLACK" Width="165px">Mandal<font 
        color="red">*</font></asp:Label>
    </td>
    <td style="padding: 5px; margin: 5px">
        :
    </td>
    <td style="padding: 5px; margin: 5px">
        <asp:DropDownList ID="DropDownList14" runat="server" class="form-control txtbox" Height="33px"
            Width="180px" AutoPostBack="True" 
            TabIndex="1">
            <asp:ListItem>--Select--</asp:ListItem>
        </asp:DropDownList>
    </td>
    <td style="padding: 5px; margin: 5px">
       
    </td>
</tr>
                                                                                          
                                               
    <tr>
     <td style="padding: 5px; margin: 5px">
         9.
     </td>
     <td style="width: 200px;">
         Pincode<span class="style5">*</span>
     </td>
     <td style="padding: 5px; margin: 5px">
         :
     </td>
     <td style="padding: 5px; margin: 5px">
         <asp:TextBox ID="TextBox31" runat="server" class="form-control txtbox" Height="28px"
             MaxLength="6" TabIndex="1" onkeypress="NumberOnly()" onblur="checkLength(this)"
             ValidationGroup="group" Width="180px"></asp:TextBox>
     </td>
     <td style="padding: 5px; margin: 5px">
        
     </td>
 </tr>          


                                                                                                           
                                                   
                                                                                                         <tr>
    <td style="padding: 5px; margin: 5px; text-align: left;">
        10.
    </td>
    <td style="padding: 5px; margin: 5px; text-align: left;">
        <asp:Label ID="Label39" runat="server" CssClass="LBLBLACK" Width="165px">Landmark<font 
        color="red">*</font></asp:Label>
    </td>
    <td style="padding: 5px; margin: 5px">
        :
    </td>
    <td style="padding: 5px; margin: 5px; text-align: left;">
        <asp:TextBox ID="TextBox45" runat="server" class="form-control txtbox" onkeypress="Names()"
            Height="28px" MaxLength="40" TabIndex="1" ValidationGroup="group" Width="180px"></asp:TextBox>
    </td>
    <td style="padding: 5px; margin: 5px">
    
    </td>
</tr>                                                              
                                               </table>
                                           </td>
                                       </tr>
                                       <tr id="Tr14" runat="server" visible="false">
                                           <td style="padding: 5px; margin: 5px" valign="top" align="left">
                                               &nbsp;&nbsp;&nbsp; <span style="font-weight: bold"><u>B). Expansion Investment</u></span>
                                           </td>
                                           <td style="width: 27px">
                                               &nbsp;
                                           </td>
                                           <td valign="top">
                                               &nbsp;
                                           </td>
                                       </tr>
                                       <tr id="Tr15" runat="server" visible="false">
                                           <td align="left" style="padding: 5px; margin: 5px" valign="top">
                                               <table cellpadding="4" cellspacing="5" style="width: 83%">
                                                   <tr>
                                                       <td style="padding: 5px; margin: 5px; text-align: left;">
                                                           1.
                                                       </td>
                                                       <td style="padding: 5px; margin: 5px; text-align: left;">
                                                           <asp:Label ID="Label51" runat="server" CssClass="LBLBLACK" Width="210px">Land Value(in Lakhs)<font 
                                                           color="red">*</font></asp:Label>
                                                       </td>
                                                       <td style="padding: 5px; margin: 5px">
                                                           :
                                                       </td>
                                                       <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                           <asp:TextBox ID="TextBox32" runat="server" class="form-control txtbox" Height="28px"
                                                               MaxLength="10" onkeypress="return inputOnlyNumbers(event)" TabIndex="1" ValidationGroup="group"
                                                               Width="180px" AutoPostBack="True"></asp:TextBox>
                                                       </td>
                                                       <td style="padding: 5px; margin: 5px; width: 10px;">
                                                           <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator29" runat="server" ControlToValidate="txtlandValue"
                                                                   ErrorMessage="Please enter  Land Values" ValidationGroup="group">*</asp:RequiredFieldValidator>--%>
                                                       </td>
                                                   </tr>
                                                   <tr>
                                                       <td style="padding: 5px; margin: 5px; text-align: left;">
                                                           2.
                                                       </td>
                                                       <td style="padding: 5px; margin: 5px; text-align: left;">
                                                           <asp:Label ID="Label52" runat="server" CssClass="LBLBLACK" Width="165px">Building Value(in Lakhs)<font 
                                                           color="red">*</font></asp:Label>
                                                       </td>
                                                       <td style="padding: 5px; margin: 5px">
                                                           :
                                                       </td>
                                                       <td style="padding: 5px; margin: 5px; text-align: left;">
                                                           <asp:TextBox ID="TextBox33" runat="server" class="form-control txtbox" Height="28px"
                                                               MaxLength="1" onkeypress="return inputOnlyNumbers(event)" TabIndex="1" ValidationGroup="group"
                                                               Width="180px" AutoPostBack="True"></asp:TextBox>
                                                       </td>
                                                       <td style="padding: 5px; margin: 5px">
                                                           <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator30" runat="server" ControlToValidate="txtbuilding"
                                                                   ErrorMessage="Please enter  Building Values" ValidationGroup="group">*</asp:RequiredFieldValidator>--%>
                                                       </td>
                                                   </tr>
                                               </table>
                                           </td>
                                           <td style="width: 27px">
                                               &nbsp;
                                           </td>
                                           <td valign="top">
                                               <table cellpadding="4" cellspacing="5" style="width: 83%">
                                                   <tr>
                                                       <td style="padding: 5px; margin: 5px; text-align: left;">
                                                           3.
                                                       </td>
                                                       <td style="padding: 5px; margin: 5px; text-align: left;">
                                                           <asp:Label ID="Label53" runat="server" CssClass="LBLBLACK" Width="165px">Plant and Machinery Value(in Lakhs) <font 
                                                           color="red">*</font></asp:Label>
                                                       </td>
                                                       <td style="padding: 5px; margin: 5px">
                                                           :
                                                       </td>
                                                       <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                           <asp:TextBox ID="TextBox34" runat="server" class="form-control txtbox" Height="28px"
                                                               MaxLength="10" onkeypress="return inputOnlyNumbers(event)" TabIndex="1" ValidationGroup="group"
                                                               Width="180px" AutoPostBack="True"></asp:TextBox>
                                                       </td>
                                                       <td style="padding: 5px; margin: 5px; width: 10px;">
                                                           <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator31" runat="server" ControlToValidate="txtPlant"
                                                                   ErrorMessage="Please enter  Plant and Machinery" ValidationGroup="group">*</asp:RequiredFieldValidator>--%>
                                                       </td>
                                                   </tr>
                                                   <tr>
                                                       <td style="padding: 5px; margin: 5px; text-align: left;">
                                                           4.
                                                       </td>
                                                       <td style="padding: 5px; margin: 5px; text-align: left;">
                                                           <asp:Label ID="Label54" runat="server" CssClass="LBLBLACK" Width="165px">Total Value(in Lakhs)<font 
                                                           color="red">*</font></asp:Label>
                                                       </td>
                                                       <td style="padding: 5px; margin: 5px">
                                                           :
                                                       </td>
                                                       <td style="padding: 5px; margin: 5px; text-align: left;">
                                                           <asp:TextBox ID="TextBox35" runat="server" class="form-control txtbox" Height="28px"
                                                               MaxLength="10" onkeypress="return inputOnlyNumbers(event)" TabIndex="1" ValidationGroup="group"
                                                               Width="180px"></asp:TextBox>
                                                       </td>
                                                       <td style="padding: 5px; margin: 5px">
                                                           <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator32" runat="server" ControlToValidate="txttotal"
                                                                   ErrorMessage="Please enter  Total Values" ValidationGroup="group">*</asp:RequiredFieldValidator>--%>
                                                       </td>
                                                   </tr>
                                               </table>
                                           </td>
                                       </tr>

                                                                                <tr>
                                            <td style="padding: 5px; margin: 5px" valign="top" align="left">
                                                <span style="font-weight: bold">Select Department / Agency</span>
                                            </td>
                                            <td style="width: 27px">
                                                &nbsp;
                                            </td>
                                            <td valign="top">
                                                &nbsp;
                                            </td>
                                        </tr>
                                  
                                        <tr>
                                            <td align="left" style="padding: 5px; margin: 5px" valign="top">
                                                <table cellpadding="4" cellspacing="5" style="width: 83%">

                                                                                                     
                                                                                                       
                                                     <tr runat="server" id="tr3">
     <td style="padding: 5px; margin: 5px; text-align: left;">
         1.
     </td>

  <td style="padding: 5px; margin: 5px; text-align: left;">
      <asp:Label ID="Label17" runat="server" CssClass="LBLBLACK" Width="165px">Department / Agency<font 
      color="red">*</font></asp:Label>
  </td>
     <td style="padding: 5px; margin: 5px;">
         :
     </td>
     <td style="padding: 5px; margin: 5px">
         <asp:DropDownList ID="DropDownList1" runat="server" 
    CssClass="form-control txtbox" 
    TabIndex="1"
    Height="33px" Width="180px">

    <asp:ListItem Selected="True">--Select--</asp:ListItem>

    <asp:ListItem Value="GHMC">GHMC</asp:ListItem>
    <asp:ListItem Value="HMDA">HMDA</asp:ListItem>
    <asp:ListItem Value="MUNICIPALITIES_MUNICIPAL_CORPORATIONS">
        MUNICIPALITIES, MUNICIPAL CORPORATIONS
    </asp:ListItem>

    <asp:ListItem Value="PANCHAYATH_RAJ_ENGINEERING">
        PANCHAYATH RAJ ENGINEERING
    </asp:ListItem>

    <asp:ListItem Value="TSIIC_IALA">TSIIC IALA</asp:ListItem>

    <asp:ListItem Value="R_AND_B_DEPT">
        R &amp; B Dept
    </asp:ListItem>

    <asp:ListItem Value="IRRIGATION">IRRIGATION</asp:ListItem>
             <asp:ListItem Value="REVENUE_DEPT">REVENUE DEPT</asp:ListItem>

<asp:ListItem Value="LAW_AND_ORDER">
    LAW AND ORDER
</asp:ListItem>

<asp:ListItem Value="DISTRICT_COLLECTOR">
    DISTRICT COLLECTOR
</asp:ListItem>

<asp:ListItem Value="FIRE_DISASTER_RESPONSE_EMERGENCY">
    FIRE DISASTER RESPONSE EMERGENCY
</asp:ListItem>
    <asp:ListItem Value="PANCHAYATH_RAJ_DEPARTMENT">
        PANCHAYATH RAJ DEPARTMENT
    </asp:ListItem>

    <asp:ListItem Value="FOREST">FOREST</asp:ListItem>

    <asp:ListItem Value="CMC">CMC</asp:ListItem>

    <asp:ListItem Value="MMC">MMC</asp:ListItem>

    <asp:ListItem Value="POLICE_TRAFFIC">
        POLICE (Traffic)
    </asp:ListItem>
             <asp:ListItem Value="TG transco">
     TG transco
</asp:ListItem>
             <asp:ListItem Value="HMWSSB ">
    HMWSSB 
</asp:ListItem>

    <asp:ListItem Value="HRDCL">HRDCL</asp:ListItem>


    <asp:ListItem Value="HCL">
        HGCL
    </asp:ListItem>

</asp:DropDownList>
         <%--<asp:DropDownList ID="DropDownList1" runat="server" class="form-control txtbox" TabIndex="1"
             Height="33px" Width="180px">
             <asp:ListItem>--Select--</asp:ListItem>
             <asp:ListItem Value="1">New</asp:ListItem>
             <asp:ListItem Value="2">Expansion</asp:ListItem>
         </asp:DropDownList>--%>
     </td>
     <td style="padding: 5px; margin: 5px">
         
     </td>
 </tr>
                                                                                                         <tr runat="server" id="tr4">
     <td style="padding: 5px; margin: 5px; text-align: left;">
         2.
     </td>

  <td style="padding: 5px; margin: 5px; text-align: left;">
      <asp:Label ID="Label19" runat="server" CssClass="LBLBLACK" Width="165px">District<font 
      color="red">*</font></asp:Label>
  </td>
     <td style="padding: 5px; margin: 5px;">
         :
     </td>
     <td style="padding: 5px; margin: 5px">
         <asp:DropDownList ID="DropDownList2" runat="server" 
    CssClass="form-control txtbox" 
    TabIndex="1"
    Height="33px" Width="180px">

    <asp:ListItem Selected="True">--Select--</asp:ListItem>
    <asp:ListItem Value="1">ADILABAD</asp:ListItem>
<asp:ListItem Value="11">ASIFABAD</asp:ListItem>
<asp:ListItem Value="37">BHADRACHALAM</asp:ListItem>
<asp:ListItem Value="17">BHADRADRI KOTHAGUDEM</asp:ListItem>
<asp:ListItem Value="12">BHUPALPALLY</asp:ListItem>
<asp:ListItem Value="39">CHEVELLA</asp:ListItem>
<asp:ListItem Value="13">GADWAL</asp:ListItem>
<asp:ListItem Value="35">GAJWEL</asp:ListItem>
<asp:ListItem Value="14">JAGTIAL</asp:ListItem>
<asp:ListItem Value="15">JANGAON</asp:ListItem>
<asp:ListItem Value="16">KAMAREDDY</asp:ListItem>
<asp:ListItem Value="3">KARIMNAGAR</asp:ListItem>
<asp:ListItem Value="10">KHAMMAM</asp:ListItem>
<asp:ListItem Value="18">MAHABUBABAD</asp:ListItem>
<asp:ListItem Value="7">MAHBUBNAGAR</asp:ListItem>
<asp:ListItem Value="19">MANCHERIAL</asp:ListItem>
<asp:ListItem Value="4">MEDAK</asp:ListItem>
<asp:ListItem Value="20">MEDCHAL</asp:ListItem>
<asp:ListItem Value="36">MIRYALAGUDA</asp:ListItem>
<asp:ListItem Value="38">MULUGU</asp:ListItem>
<asp:ListItem Value="21">NAGARKURNOOL</asp:ListItem>
<asp:ListItem Value="8">NALGONDA</asp:ListItem>
<asp:ListItem Value="34">NARAYANPET</asp:ListItem>
<asp:ListItem Value="22">NIRMAL</asp:ListItem>
<asp:ListItem Value="2">NIZAMABAD</asp:ListItem>
<asp:ListItem Value="23">PEDDAPALLI</asp:ListItem>
<asp:ListItem Value="33">HYDERABAD</asp:ListItem>
<asp:ListItem Value="6">RANGAREDDY</asp:ListItem>
<asp:ListItem Value="24">SANGAREDDY</asp:ListItem>
<asp:ListItem Value="32">SATHUPALLY - KHAMMAM</asp:ListItem>
<asp:ListItem Value="25">SIDDIPET</asp:ListItem>
<asp:ListItem Value="26">SIRCILLA</asp:ListItem>
<asp:ListItem Value="27">SURYAPET</asp:ListItem>
<asp:ListItem Value="28">VIKARABAD</asp:ListItem>
<asp:ListItem Value="29">WANAPARTHY</asp:ListItem>
<asp:ListItem Value="9">WARANGAL - RURAL</asp:ListItem>
<asp:ListItem Value="30">WARANGAL - URBAN</asp:ListItem>
<asp:ListItem Value="31">YADADRI</asp:ListItem>
    

</asp:DropDownList>
         <%--<asp:DropDownList ID="DropDownList1" runat="server" class="form-control txtbox" TabIndex="1"
             Height="33px" Width="180px">
             <asp:ListItem>--Select--</asp:ListItem>
             <asp:ListItem Value="1">New</asp:ListItem>
             <asp:ListItem Value="2">Expansion</asp:ListItem>
         </asp:DropDownList>--%>
     </td>
     <td style="padding: 5px; margin: 5px">
         
     </td>
 </tr>
                                                    <tr runat="server" visible="false">
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            1.
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:Label ID="Label423" runat="server" CssClass="LBLBLACK" Width="210px">Land Value(in Lakhs)<font 
                                                            color="red">*</font></asp:Label>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">
                                                            :
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                            <asp:TextBox ID="txtlandValue" runat="server" class="form-control txtbox" Height="28px"
                                                                MaxLength="10" onkeypress="return inputOnlyNumbers(event)" TabIndex="1" ValidationGroup="group"
                                                                Width="180px" AutoPostBack="True"></asp:TextBox>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; width: 10px;">
                                                           
                                                        </td>
                                                    </tr>
                                              
                                                </table>
                                            </td>
                                            <td style="width: 27px">
                                                &nbsp;
                                            </td>
                                            <td valign="top">
                                                <table cellpadding="4" cellspacing="5" style="width: 83%">
                                                    <tr  runat="server" visible="false">
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            3.
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:Label ID="Label431" runat="server" CssClass="LBLBLACK" Width="165px">Plant and Machinery Value(in Lakhs) <font 
                                                            color="red">*</font></asp:Label>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">
                                                            :
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                            <asp:TextBox ID="txtPlant" runat="server" class="form-control txtbox" Height="28px"
                                                                MaxLength="10" onkeypress="return inputOnlyNumbers(event)" TabIndex="1" ValidationGroup="group"
                                                                Width="180px" AutoPostBack="True"></asp:TextBox>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; width: 10px;">
                                                         
                                                        </td>
                                                    </tr>
                                           
                                                </table>
                                            </td>
                                        </tr>
                                        <tr id="tblexpansionheading" runat="server" visible="false">
                                            <td style="padding: 5px; margin: 5px" valign="top" align="left">
                                                &nbsp;&nbsp;&nbsp; <span style="font-weight: bold"><u>B). Expansion Investment</u></span>
                                            </td>
                                            <td style="width: 27px">
                                                &nbsp;
                                            </td>
                                            <td valign="top">
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr id="tblexpansion" runat="server" visible="false">
                                            <td align="left" style="padding: 5px; margin: 5px" valign="top">
                                                <table cellpadding="4" cellspacing="5" style="width: 83%">
                                                    <tr>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            1.
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:Label ID="Label2" runat="server" CssClass="LBLBLACK" Width="210px">Land Value(in Lakhs)<font 
                                                            color="red">*</font></asp:Label>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">
                                                            :
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                            <asp:TextBox ID="txtlandValueexp" runat="server" class="form-control txtbox" Height="28px"
                                                                MaxLength="10" onkeypress="return inputOnlyNumbers(event)" TabIndex="1" ValidationGroup="group"
                                                                Width="180px" AutoPostBack="True" ></asp:TextBox>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; width: 10px;">
                                                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator29" runat="server" ControlToValidate="txtlandValue"
                                                                    ErrorMessage="Please enter  Land Values" ValidationGroup="group">*</asp:RequiredFieldValidator>--%>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            2.
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:Label ID="Label3" runat="server" CssClass="LBLBLACK" Width="165px">Building Value(in Lakhs)<font 
                                                            color="red">*</font></asp:Label>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">
                                                            :
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:TextBox ID="txtbuildingexp" runat="server" class="form-control txtbox" Height="28px"
                                                                MaxLength="1" onkeypress="return inputOnlyNumbers(event)" TabIndex="1" ValidationGroup="group"
                                                                Width="180px" AutoPostBack="True"></asp:TextBox>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">
                                                            <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator30" runat="server" ControlToValidate="txtbuilding"
                                                                    ErrorMessage="Please enter  Building Values" ValidationGroup="group">*</asp:RequiredFieldValidator>--%>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                            <td style="width: 27px">
                                                &nbsp;
                                            </td>
                                            <td valign="top">
                                                <table cellpadding="4" cellspacing="5" style="width: 83%">
                                                    <tr>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            3.
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:Label ID="Label4" runat="server" CssClass="LBLBLACK" Width="165px">Plant and Machinery Value(in Lakhs) <font 
                                                            color="red">*</font></asp:Label>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">
                                                            :
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                            <asp:TextBox ID="txtPlantexp" runat="server" class="form-control txtbox" Height="28px"
                                                                MaxLength="10" onkeypress="return inputOnlyNumbers(event)" TabIndex="1" ValidationGroup="group"
                                                                Width="180px" AutoPostBack="True"></asp:TextBox>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; width: 10px;">
                                                            <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator31" runat="server" ControlToValidate="txtPlant"
                                                                    ErrorMessage="Please enter  Plant and Machinery" ValidationGroup="group">*</asp:RequiredFieldValidator>--%>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            4.
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:Label ID="Label5" runat="server" CssClass="LBLBLACK" Width="165px">Total Value(in Lakhs)<font 
                                                            color="red">*</font></asp:Label>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">
                                                            :
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:TextBox ID="txttotalexp" runat="server" class="form-control txtbox" Height="28px"
                                                                MaxLength="10" onkeypress="return inputOnlyNumbers(event)" TabIndex="1" ValidationGroup="group"
                                                                Width="180px"></asp:TextBox>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">
                                                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator32" runat="server" ControlToValidate="txttotal"
                                                                    ErrorMessage="Please enter  Total Values" ValidationGroup="group">*</asp:RequiredFieldValidator>--%>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr id="trtotalinv" runat="server" visible="false">
                                            <td style="padding: 5px; margin: 5px" valign="top" align="left">
                                                &nbsp;&nbsp;&nbsp; <span style="font-weight: bold"><u>C). Total Investment</u></span>
                                            </td>
                                            <td style="width: 27px">
                                                &nbsp;
                                            </td>
                                            <td valign="top">
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr id="trtotalinvinv" runat="server" visible="false">
                                            <td align="left" style="padding: 5px; margin: 5px" valign="top">
                                                <table cellpadding="4" cellspacing="5" style="width: 83%">
                                                    <tr>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            1.
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:Label ID="Label6" runat="server" CssClass="LBLBLACK" Width="210px">Land Value(in Lakhs)<font 
                                                            color="red">*</font></asp:Label>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">
                                                            :
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                            <asp:TextBox ID="txtlandValueexptotal" runat="server" class="form-control txtbox"
                                                                Height="28px" MaxLength="10" onkeypress="return inputOnlyNumbers(event)" TabIndex="1"
                                                                ValidationGroup="group" Width="180px" AutoPostBack="True"></asp:TextBox>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; width: 10px;">
                                                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator29" runat="server" ControlToValidate="txtlandValue"
                                                                    ErrorMessage="Please enter  Land Values" ValidationGroup="group">*</asp:RequiredFieldValidator>--%>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            2.
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:Label ID="Label7" runat="server" CssClass="LBLBLACK" Width="165px">Building Value(in Lakhs)<font 
                                                            color="red">*</font></asp:Label>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">
                                                            :
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:TextBox ID="txtbuildingexptotal" runat="server" class="form-control txtbox"
                                                                Height="28px" MaxLength="1" onkeypress="return inputOnlyNumbers(event)" TabIndex="1"
                                                                ValidationGroup="group" Width="180px" AutoPostBack="True"></asp:TextBox>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">
                                                            <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator30" runat="server" ControlToValidate="txtbuilding"
                                                                    ErrorMessage="Please enter  Building Values" ValidationGroup="group">*</asp:RequiredFieldValidator>--%>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                            <td style="width: 27px">
                                                &nbsp;
                                            </td>
                                            <td valign="top">
                                                <table cellpadding="4" cellspacing="5" style="width: 83%">
                                                    <tr>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            3.
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:Label ID="Label8" runat="server" CssClass="LBLBLACK" Width="165px">Plant and Machinery Value(in Lakhs) <font 
                                                            color="red">*</font></asp:Label>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">
                                                            :
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                            <asp:TextBox ID="txtPlantexptotal" runat="server" class="form-control txtbox" Height="28px"
                                                                MaxLength="10" onkeypress="return inputOnlyNumbers(event)" TabIndex="1" ValidationGroup="group"
                                                                Width="180px" AutoPostBack="True"></asp:TextBox>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; width: 10px;">
                                                            <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator31" runat="server" ControlToValidate="txtPlant"
                                                                    ErrorMessage="Please enter  Plant and Machinery" ValidationGroup="group">*</asp:RequiredFieldValidator>--%>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            4.
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:Label ID="Label9" runat="server" CssClass="LBLBLACK" Width="165px">Total Value(in Lakhs)<font 
                                                            color="red">*</font></asp:Label>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">
                                                            :
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:TextBox ID="txttotalexptotal" runat="server" class="form-control txtbox" Height="28px"
                                                                MaxLength="10" onkeypress="return inputOnlyNumbers(event)" TabIndex="1" ValidationGroup="group"
                                                                Width="180px"></asp:TextBox>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">
                                                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator32" runat="server" ControlToValidate="txttotal"
                                                                    ErrorMessage="Please enter  Total Values" ValidationGroup="group">*</asp:RequiredFieldValidator>--%>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                    
                                                                                                                            <tr>
                                            <td style="padding: 5px; margin: 5px" valign="top" align="left">
                                                <span style="font-weight: bold">Type of Permissions</span>
                                            </td>
                                            <td style="width: 27px">
                                                &nbsp;
                                            </td>
                                            <td valign="top">
                                                &nbsp;
                                            </td>
                                        </tr>
                                  
                                        <tr>
                                            <td align="left" style="padding: 5px; margin: 5px" valign="top">
                                                <table cellpadding="4" cellspacing="5" style="width: 83%">

                                                                                                     
                                                                                                       
                                                     <tr runat="server" id="tr5">
     <td style="padding: 5px; margin: 5px; text-align: left;">
         1.
     </td>

  <td style="padding: 5px; margin: 5px; text-align: left;">
      <asp:Label ID="Label20" runat="server" CssClass="LBLBLACK" Width="165px">ROU/Rd Cutting/Station NOC<font 
      color="red">*</font></asp:Label>
  </td>
     <td style="padding: 5px; margin: 5px;">
         :
     </td>
     <td style="padding: 5px; margin: 5px">
         <asp:DropDownList ID="DropDownList4" runat="server" 
    CssClass="form-control txtbox" 
    TabIndex="1"
    Height="33px" Width="180px">

    <asp:ListItem Selected="True">--Select--</asp:ListItem>

    
   
    <asp:ListItem Value="Dig & Pay">Dig & Pay</asp:ListItem>
    <asp:ListItem Value="Dig & Restore">Dig & Restore</asp:ListItem>
    <asp:ListItem Value="NOC">NOC</asp:ListItem>
              <asp:ListItem Value="Lay Out Approval">Lay Out Approval</asp:ListItem>
              <asp:ListItem Value="Building Approval">Building Approval</asp:ListItem>
               <asp:ListItem Value="DM NOC">DM NOC</asp:ListItem>

</asp:DropDownList>
     </td>
     <td style="padding: 5px; margin: 5px">
         
     </td>
 </tr>
                                                                                                       
                                                    <tr runat="server" visible="false">
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            1.
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:Label ID="Label25" runat="server" CssClass="LBLBLACK" Width="210px">Land Value(in Lakhs)<font 
                                                            color="red">*</font></asp:Label>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">
                                                            :
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                            <asp:TextBox ID="TextBox6" runat="server" class="form-control txtbox" Height="28px"
                                                                MaxLength="10" onkeypress="return inputOnlyNumbers(event)" TabIndex="1" ValidationGroup="group"
                                                                Width="180px" AutoPostBack="True"></asp:TextBox>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; width: 10px;">
                                                           
                                                        </td>
                                                    </tr>
                                              
                                                </table>
                                            </td>
                                            <td style="width: 27px">
                                                &nbsp;
                                            </td>
                                            <td valign="top">
                                                <table cellpadding="4" cellspacing="5" style="width: 83%">
                                                    <tr  runat="server" visible="false">
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            3.
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:Label ID="Label26" runat="server" CssClass="LBLBLACK" Width="165px">Plant and Machinery Value(in Lakhs) <font 
                                                            color="red">*</font></asp:Label>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">
                                                            :
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                            <asp:TextBox ID="TextBox7" runat="server" class="form-control txtbox" Height="28px"
                                                                MaxLength="10" onkeypress="return inputOnlyNumbers(event)" TabIndex="1" ValidationGroup="group"
                                                                Width="180px" AutoPostBack="True"></asp:TextBox>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; width: 10px;">
                                                         
                                                        </td>
                                                    </tr>
                                           
                                                </table>
                                            </td>
                                        </tr>
                                        <tr id="Tr7" runat="server" visible="false">
                                            <td style="padding: 5px; margin: 5px" valign="top" align="left">
                                                &nbsp;&nbsp;&nbsp; <span style="font-weight: bold"><u>B). Expansion Investment</u></span>
                                            </td>
                                            <td style="width: 27px">
                                                &nbsp;
                                            </td>
                                            <td valign="top">
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr id="Tr11" runat="server" visible="false">
                                            <td align="left" style="padding: 5px; margin: 5px" valign="top">
                                                <table cellpadding="4" cellspacing="5" style="width: 83%">
                                                    <tr>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            1.
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:Label ID="Label27" runat="server" CssClass="LBLBLACK" Width="210px">Land Value(in Lakhs)<font 
                                                            color="red">*</font></asp:Label>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">
                                                            :
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                            <asp:TextBox ID="TextBox8" runat="server" class="form-control txtbox" Height="28px"
                                                                MaxLength="10" onkeypress="return inputOnlyNumbers(event)" TabIndex="1" ValidationGroup="group"
                                                                Width="180px" AutoPostBack="True" ></asp:TextBox>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; width: 10px;">
                                                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator29" runat="server" ControlToValidate="txtlandValue"
                                                                    ErrorMessage="Please enter  Land Values" ValidationGroup="group">*</asp:RequiredFieldValidator>--%>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            2.
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:Label ID="Label28" runat="server" CssClass="LBLBLACK" Width="165px">Building Value(in Lakhs)<font 
                                                            color="red">*</font></asp:Label>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">
                                                            :
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:TextBox ID="TextBox9" runat="server" class="form-control txtbox" Height="28px"
                                                                MaxLength="1" onkeypress="return inputOnlyNumbers(event)" TabIndex="1" ValidationGroup="group"
                                                                Width="180px" AutoPostBack="True"></asp:TextBox>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">
                                                            <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator30" runat="server" ControlToValidate="txtbuilding"
                                                                    ErrorMessage="Please enter  Building Values" ValidationGroup="group">*</asp:RequiredFieldValidator>--%>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                            <td style="width: 27px">
                                                &nbsp;
                                            </td>
                                            <td valign="top">
                                                <table cellpadding="4" cellspacing="5" style="width: 83%">
                                                    <tr>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            3.
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:Label ID="Label29" runat="server" CssClass="LBLBLACK" Width="165px">Plant and Machinery Value(in Lakhs) <font 
                                                            color="red">*</font></asp:Label>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">
                                                            :
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                            <asp:TextBox ID="TextBox10" runat="server" class="form-control txtbox" Height="28px"
                                                                MaxLength="10" onkeypress="return inputOnlyNumbers(event)" TabIndex="1" ValidationGroup="group"
                                                                Width="180px" AutoPostBack="True"></asp:TextBox>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; width: 10px;">
                                                            <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator31" runat="server" ControlToValidate="txtPlant"
                                                                    ErrorMessage="Please enter  Plant and Machinery" ValidationGroup="group">*</asp:RequiredFieldValidator>--%>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            4.
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:Label ID="Label30" runat="server" CssClass="LBLBLACK" Width="165px">Total Value(in Lakhs)<font 
                                                            color="red">*</font></asp:Label>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">
                                                            :
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:TextBox ID="TextBox11" runat="server" class="form-control txtbox" Height="28px"
                                                                MaxLength="10" onkeypress="return inputOnlyNumbers(event)" TabIndex="1" ValidationGroup="group"
                                                                Width="180px"></asp:TextBox>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">
                                                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator32" runat="server" ControlToValidate="txttotal"
                                                                    ErrorMessage="Please enter  Total Values" ValidationGroup="group">*</asp:RequiredFieldValidator>--%>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr id="tr12" runat="server" visible="false">
                                            <td style="padding: 5px; margin: 5px" valign="top" align="left">
                                                &nbsp;&nbsp;&nbsp; <span style="font-weight: bold"><u>C). Total Investment</u></span>
                                            </td>
                                            <td style="width: 27px">
                                                &nbsp;
                                            </td>
                                            <td valign="top">
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr id="tr16" runat="server" visible="false">
                                            <td align="left" style="padding: 5px; margin: 5px" valign="top">
                                                <table cellpadding="4" cellspacing="5" style="width: 83%">
                                                    <tr>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            1.
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:Label ID="Label31" runat="server" CssClass="LBLBLACK" Width="210px">Land Value(in Lakhs)<font 
                                                            color="red">*</font></asp:Label>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">
                                                            :
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                            <asp:TextBox ID="TextBox15" runat="server" class="form-control txtbox"
                                                                Height="28px" MaxLength="10" onkeypress="return inputOnlyNumbers(event)" TabIndex="1"
                                                                ValidationGroup="group" Width="180px" AutoPostBack="True"></asp:TextBox>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; width: 10px;">
                                                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator29" runat="server" ControlToValidate="txtlandValue"
                                                                    ErrorMessage="Please enter  Land Values" ValidationGroup="group">*</asp:RequiredFieldValidator>--%>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            2.
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:Label ID="Label35" runat="server" CssClass="LBLBLACK" Width="165px">Building Value(in Lakhs)<font 
                                                            color="red">*</font></asp:Label>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">
                                                            :
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:TextBox ID="TextBox16" runat="server" class="form-control txtbox"
                                                                Height="28px" MaxLength="1" onkeypress="return inputOnlyNumbers(event)" TabIndex="1"
                                                                ValidationGroup="group" Width="180px" AutoPostBack="True"></asp:TextBox>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">
                                                            <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator30" runat="server" ControlToValidate="txtbuilding"
                                                                    ErrorMessage="Please enter  Building Values" ValidationGroup="group">*</asp:RequiredFieldValidator>--%>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                            <td style="width: 27px">
                                                &nbsp;
                                            </td>
                                            <td valign="top">
                                                <table cellpadding="4" cellspacing="5" style="width: 83%">
                                                    <tr>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            3.
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:Label ID="Label36" runat="server" CssClass="LBLBLACK" Width="165px">Plant and Machinery Value(in Lakhs) <font 
                                                            color="red">*</font></asp:Label>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">
                                                            :
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                            <asp:TextBox ID="TextBox17" runat="server" class="form-control txtbox" Height="28px"
                                                                MaxLength="10" onkeypress="return inputOnlyNumbers(event)" TabIndex="1" ValidationGroup="group"
                                                                Width="180px" AutoPostBack="True"></asp:TextBox>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; width: 10px;">
                                                            <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator31" runat="server" ControlToValidate="txtPlant"
                                                                    ErrorMessage="Please enter  Plant and Machinery" ValidationGroup="group">*</asp:RequiredFieldValidator>--%>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            4.
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:Label ID="Label37" runat="server" CssClass="LBLBLACK" Width="165px">Total Value(in Lakhs)<font 
                                                            color="red">*</font></asp:Label>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">
                                                            :
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:TextBox ID="TextBox18" runat="server" class="form-control txtbox" Height="28px"
                                                                MaxLength="10" onkeypress="return inputOnlyNumbers(event)" TabIndex="1" ValidationGroup="group"
                                                                Width="180px"></asp:TextBox>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">
                                                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator32" runat="server" ControlToValidate="txttotal"
                                                                    ErrorMessage="Please enter  Total Values" ValidationGroup="group">*</asp:RequiredFieldValidator>--%>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>





                                       <tr>
                                           <td style="padding: 5px; margin: 5px" valign="top" align="left">
                                               <span style="font-weight: bold">Details of the Road</span>
                                           </td>
                                           <td style="width: 27px">
                                               &nbsp;
                                           </td>
                                           <td valign="top">
                                               &nbsp;
                                           </td>
                                       </tr>
                                     
                                       <tr>
                                           <td align="left" style="padding: 5px; margin: 5px" valign="top">
                                               <table cellpadding="4" cellspacing="5" style="width: 83%">


                                                                                                       
                                                   


                                                                                                                                                                                                                                                                                                                                                                               <tr>
    <td style="padding: 5px; margin: 5px; text-align: left;">
        1.
    </td>
    <td style="padding: 5px; margin: 5px; text-align: left;">
        <asp:Label ID="Label98" runat="server" CssClass="LBLBLACK" Width="165px">Existing Road Condition<font 
        color="red">*</font></asp:Label>
    </td>
    <td style="padding: 5px; margin: 5px">
        :
    </td>
    <td style="padding: 5px; margin: 5px; text-align: left;">
        <asp:TextBox ID="TextBox74" runat="server" class="form-control txtbox" onkeypress="Names()"
            Height="28px" MaxLength="40" TabIndex="1" ValidationGroup="group" Width="180px"></asp:TextBox>
    </td>
    <td style="padding: 5px; margin: 5px">

    </td>
</tr 
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                  <tr>
    <td style="padding: 5px; margin: 5px; text-align: left;">
        2.
    </td>
    <td style="padding: 5px; margin: 5px; text-align: left;">
        <asp:Label ID="Label100" runat="server" CssClass="LBLBLACK" Width="165px">
Width of Road<font 
        color="red">*</font></asp:Label>
    </td>
    <td style="padding: 5px; margin: 5px">
        :
    </td>
    <td style="padding: 5px; margin: 5px; text-align: left;">
        <asp:TextBox ID="TextBox72" runat="server" class="form-control txtbox" onkeypress="Names()"
            Height="28px" MaxLength="40" TabIndex="1" ValidationGroup="group" Width="180px"></asp:TextBox>
    </td>
    <td style="padding: 5px; margin: 5px">
       
    </td>
</tr 
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                               <tr>
    <td style="padding: 5px; margin: 5px; text-align: left;">
        3.
    </td>
    <td style="padding: 5px; margin: 5px; text-align: left;">
        <asp:Label ID="Label99" runat="server" CssClass="LBLBLACK" Width="165px">
Length of Road<font 
        color="red">*</font></asp:Label>
    </td>
    <td style="padding: 5px; margin: 5px">
        :
    </td>
    <td style="padding: 5px; margin: 5px; text-align: left;">
        <asp:TextBox ID="TextBox75" runat="server" class="form-control txtbox" onkeypress="Names()"
            Height="28px" MaxLength="40" TabIndex="1" ValidationGroup="group" Width="180px"></asp:TextBox>
    </td>
    <td style="padding: 5px; margin: 5px">
        
    </td>
</tr> 

                                                     <tr>
    <td style="padding: 5px; margin: 5px">
        4.
    </td>
    <td style="padding: 5px; margin: 5px">
        <asp:Label ID="Label101" runat="server" CssClass="LBLBLACK" Width="165px">From Location<font 
        color="red">*</font></asp:Label>
    </td>
    <td style="padding: 5px; margin: 5px">
        :
    </td>
    <td style="padding: 5px; margin: 5px">
       <asp:TextBox ID="TextBox5" runat="server" class="form-control txtbox" onkeypress="Names()"
    Height="28px" MaxLength="40" TabIndex="1" ValidationGroup="group" Width="180px"></asp:TextBox>
    </td>
    <td style="padding: 5px; margin: 5px">
    
    </td>
</tr>
                                                                                                        <tr>
    <td style="padding: 5px; margin: 5px">
        5.
    </td>
    <td style="padding: 5px; margin: 5px">
        <asp:Label ID="Label97" runat="server" CssClass="LBLBLACK" Width="165px">To Location<font 
        color="red">*</font></asp:Label>
    </td>
    <td style="padding: 5px; margin: 5px">
        :
    </td>
    <td style="padding: 5px; margin: 5px">
       <asp:TextBox ID="TextBox19" runat="server" class="form-control txtbox" onkeypress="Names()"
    Height="28px" MaxLength="40" TabIndex="1" ValidationGroup="group" Width="180px"></asp:TextBox>
    </td>
    <td style="padding: 5px; margin: 5px">
       
    </td>
</tr>
                                                                                                                  <tr>
    <td style="padding: 5px; margin: 5px; text-align: left;">
        6.
    </td>
    <td style="padding: 5px; margin: 5px; text-align: left;">
        <asp:Label ID="Label109" runat="server" CssClass="LBLBLACK" Width="165px">
Latitude<font 
        color="red">*</font></asp:Label>
    </td>
    <td style="padding: 5px; margin: 5px">
        :
    </td>
    <td style="padding: 5px; margin: 5px; text-align: left;">
        <asp:TextBox ID="TextBox73" runat="server" class="form-control txtbox" onkeypress="Names()"
            Height="28px" MaxLength="40" TabIndex="1" ValidationGroup="group" Width="180px"></asp:TextBox>
    </td>
    <td style="padding: 5px; margin: 5px">
      
    </td>
</tr> 
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                  <tr>
    <td style="padding: 5px; margin: 5px; text-align: left;">
        7.
    </td>
    <td style="padding: 5px; margin: 5px; text-align: left;">
        <asp:Label ID="Label110" runat="server" CssClass="LBLBLACK" Width="165px">
Longitude<font 
        color="red">*</font></asp:Label>
    </td>
    <td style="padding: 5px; margin: 5px">
        :
    </td>
    <td style="padding: 5px; margin: 5px; text-align: left;">
        <asp:TextBox ID="TextBox76" runat="server" class="form-control txtbox" onkeypress="Names()"
            Height="28px" MaxLength="40" TabIndex="1" ValidationGroup="group" Width="180px"></asp:TextBox>
    </td>
    <td style="padding: 5px; margin: 5px">
  
    </td>
</tr> 

                                               </table>
                                           </td>
                                           <td style="width: 27px">
                                               &nbsp;
                                           </td>
                                           <td valign="top">
                                               <table cellpadding="4" cellspacing="5" style="width: 83%">
                                                                                                                                                          

                                                                                                                                                           <tr>
    <td style="padding: 5px; margin: 5px">
        8.
    </td>
    <td style="padding: 5px; margin: 5px">
        <asp:Label ID="Label102" runat="server" CssClass="LBLBLACK" Width="165px">Mandal<font 
        color="red">*</font></asp:Label>
    </td>
    <td style="padding: 5px; margin: 5px">
        :
    </td>
    <td style="padding: 5px; margin: 5px">
        <asp:DropDownList ID="DropDownList32" runat="server" class="form-control txtbox" Height="33px"
            Width="180px" AutoPostBack="True" 
            TabIndex="1">
            <asp:ListItem>--Select--</asp:ListItem>
        </asp:DropDownList>
    </td>
    <td style="padding: 5px; margin: 5px">
     
    </td>
</tr>


                                                                                                                                                                                                            <tr>
    <td style="padding: 5px; margin: 5px">
        9.
    </td>
    <td style="padding: 5px; margin: 5px">
        <asp:Label ID="Label103" runat="server" CssClass="LBLBLACK" Width="165px">District<font 
        color="red">*</font></asp:Label>
    </td>
    <td style="padding: 5px; margin: 5px">
        :
    </td>
    <td style="padding: 5px; margin: 5px">
        <asp:DropDownList ID="DropDownList33" runat="server" class="form-control txtbox" Height="33px"
            Width="180px" AutoPostBack="True" 
            TabIndex="1">
            <asp:ListItem>--Select--</asp:ListItem>
        </asp:DropDownList>
    </td>
    <td style="padding: 5px; margin: 5px">
 
    </td>
</tr>
                                                                                                                                                            <tr>
    <td style="padding: 5px; margin: 5px; text-align: left;">
        10.
    </td>
    <td style="padding: 5px; margin: 5px; text-align: left;">
        <asp:Label ID="Label104" runat="server" CssClass="LBLBLACK" Width="165px">Landmark<font 
        color="red">*</font></asp:Label>
    </td>
    <td style="padding: 5px; margin: 5px">
        :
    </td>
    <td style="padding: 5px; margin: 5px; text-align: left;">
        <asp:TextBox ID="TextBox77" runat="server" class="form-control txtbox" onkeypress="Names()"
            Height="28px" MaxLength="40" TabIndex="1" ValidationGroup="group" Width="180px"></asp:TextBox>
    </td>
    <td style="padding: 5px; margin: 5px">
      
    </td>
</tr 
                                                                                                           

                                                                                                           
                                                   
                                                                                                                                                                                                                                                                     <tr>
    <tr>
     <td style="padding: 5px; margin: 5px">
         11.
     </td>
     <td style="width: 200px;">
         Depth of Cutting<span class="style5">*</span>
     </td>
     <td style="padding: 5px; margin: 5px">
         :
     </td>
     <td style="padding: 5px; margin: 5px">
         <asp:TextBox ID="TextBox78" runat="server" class="form-control txtbox" Height="28px"
             MaxLength="6" TabIndex="1" onkeypress="NumberOnly()" onblur="checkLength(this)"
             ValidationGroup="group" Width="180px"></asp:TextBox>
     </td>
     <td style="padding: 5px; margin: 5px">
         
     </td>
 </tr>
                                   <tr>
     <td style="padding: 5px; margin: 5px">
         12.
     </td>
     <td style="width: 200px;">
         
 Width of Cutting<span class="style5">*</span>
     </td>
     <td style="padding: 5px; margin: 5px">
         :
     </td>
     <td style="padding: 5px; margin: 5px">
         <asp:TextBox ID="TextBox79" runat="server" class="form-control txtbox" Height="28px"
             MaxLength="6" TabIndex="1" onkeypress="NumberOnly()" onblur="checkLength(this)"
             ValidationGroup="group" Width="180px"></asp:TextBox>
     </td>
     <td style="padding: 5px; margin: 5px">
       
     </td>
 </tr>
                                   <tr>
     <td style="padding: 5px; margin: 5px">
         13.
     </td>
     <td style="width: 200px;">
         
 land Area (in Sq. Mtrs)<span class="style5">*</span>
     </td>
     <td style="padding: 5px; margin: 5px">
         :
     </td>
     <td style="padding: 5px; margin: 5px">
         <asp:TextBox ID="TextBox20" runat="server" class="form-control txtbox" Height="28px"
             MaxLength="6" TabIndex="1" onkeypress="NumberOnly()" onblur="checkLength(this)"
             ValidationGroup="group" Width="180px"></asp:TextBox>
     </td>
     <td style="padding: 5px; margin: 5px">
       
     </td>
 </tr>
                                        <tr>
    <td style="padding: 5px; margin: 5px">
        14.
    </td>
    <td style="width: 200px;">
        
Rate of Charges<span class="style5">*</span>
    </td>
    <td style="padding: 5px; margin: 5px">
        :
    </td>
    <td style="padding: 5px; margin: 5px">
        <asp:TextBox ID="TextBox21" runat="server" class="form-control txtbox" Height="28px"
            MaxLength="6" TabIndex="1" onkeypress="NumberOnly()" onblur="checkLength(this)"
            ValidationGroup="group" Width="180px"></asp:TextBox>
    </td>
    <td style="padding: 5px; margin: 5px">
      
    </td>
</tr>                                             
                                               </table>
                                           </td>
                                       </tr>
                                       <tr id="Tr23" runat="server" visible="false">
                                           <td style="padding: 5px; margin: 5px" valign="top" align="left">
                                               &nbsp;&nbsp;&nbsp; <span style="font-weight: bold"><u>B). Expansion Investment</u></span>
                                           </td>
                                           <td style="width: 27px">
                                               &nbsp;
                                           </td>
                                           <td valign="top">
                                               &nbsp;
                                           </td>
                                       </tr>
                                       <tr id="Tr24" runat="server" visible="false">
                                           <td align="left" style="padding: 5px; margin: 5px" valign="top">
                                               <table cellpadding="4" cellspacing="5" style="width: 83%">
                                                   <tr>
                                                       <td style="padding: 5px; margin: 5px; text-align: left;">
                                                           1.
                                                       </td>
                                                       <td style="padding: 5px; margin: 5px; text-align: left;">
                                                           <asp:Label ID="Label105" runat="server" CssClass="LBLBLACK" Width="210px">Land Value(in Lakhs)<font 
                                                           color="red">*</font></asp:Label>
                                                       </td>
                                                       <td style="padding: 5px; margin: 5px">
                                                           :
                                                       </td>
                                                       <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                           <asp:TextBox ID="TextBox83" runat="server" class="form-control txtbox" Height="28px"
                                                               MaxLength="10" onkeypress="return inputOnlyNumbers(event)" TabIndex="1" ValidationGroup="group"
                                                               Width="180px" AutoPostBack="True"></asp:TextBox>
                                                       </td>
                                                       <td style="padding: 5px; margin: 5px; width: 10px;">
                                                           <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator29" runat="server" ControlToValidate="txtlandValue"
                                                                   ErrorMessage="Please enter  Land Values" ValidationGroup="group">*</asp:RequiredFieldValidator>--%>
                                                       </td>
                                                   </tr>
                                                   <tr>
                                                       <td style="padding: 5px; margin: 5px; text-align: left;">
                                                           2.
                                                       </td>
                                                       <td style="padding: 5px; margin: 5px; text-align: left;">
                                                           <asp:Label ID="Label106" runat="server" CssClass="LBLBLACK" Width="165px">Building Value(in Lakhs)<font 
                                                           color="red">*</font></asp:Label>
                                                       </td>
                                                       <td style="padding: 5px; margin: 5px">
                                                           :
                                                       </td>
                                                       <td style="padding: 5px; margin: 5px; text-align: left;">
                                                           <asp:TextBox ID="TextBox84" runat="server" class="form-control txtbox" Height="28px"
                                                               MaxLength="1" onkeypress="return inputOnlyNumbers(event)" TabIndex="1" ValidationGroup="group"
                                                               Width="180px" AutoPostBack="True"></asp:TextBox>
                                                       </td>
                                                       <td style="padding: 5px; margin: 5px">
                                                           <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator30" runat="server" ControlToValidate="txtbuilding"
                                                                   ErrorMessage="Please enter  Building Values" ValidationGroup="group">*</asp:RequiredFieldValidator>--%>
                                                       </td>
                                                   </tr>
                                               </table>
                                           </td>
                                           <td style="width: 27px">
                                               &nbsp;
                                           </td>
                                           <td valign="top">
                                               <table cellpadding="4" cellspacing="5" style="width: 83%">
                                                   <tr>
                                                       <td style="padding: 5px; margin: 5px; text-align: left;">
                                                           3.
                                                       </td>
                                                       <td style="padding: 5px; margin: 5px; text-align: left;">
                                                           <asp:Label ID="Label107" runat="server" CssClass="LBLBLACK" Width="165px">Plant and Machinery Value(in Lakhs) <font 
                                                           color="red">*</font></asp:Label>
                                                       </td>
                                                       <td style="padding: 5px; margin: 5px">
                                                           :
                                                       </td>
                                                       <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                           <asp:TextBox ID="TextBox85" runat="server" class="form-control txtbox" Height="28px"
                                                               MaxLength="10" onkeypress="return inputOnlyNumbers(event)" TabIndex="1" ValidationGroup="group"
                                                               Width="180px" AutoPostBack="True"></asp:TextBox>
                                                       </td>
                                                       <td style="padding: 5px; margin: 5px; width: 10px;">
                                                           <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator31" runat="server" ControlToValidate="txtPlant"
                                                                   ErrorMessage="Please enter  Plant and Machinery" ValidationGroup="group">*</asp:RequiredFieldValidator>--%>
                                                       </td>
                                                   </tr>
                                                   <tr>
                                                       <td style="padding: 5px; margin: 5px; text-align: left;">
                                                           4.
                                                       </td>
                                                       <td style="padding: 5px; margin: 5px; text-align: left;">
                                                           <asp:Label ID="Label108" runat="server" CssClass="LBLBLACK" Width="165px">Total Value(in Lakhs)<font 
                                                           color="red">*</font></asp:Label>
                                                       </td>
                                                       <td style="padding: 5px; margin: 5px">
                                                           :
                                                       </td>
                                                       <td style="padding: 5px; margin: 5px; text-align: left;">
                                                           <asp:TextBox ID="TextBox86" runat="server" class="form-control txtbox" Height="28px"
                                                               MaxLength="10" onkeypress="return inputOnlyNumbers(event)" TabIndex="1" ValidationGroup="group"
                                                               Width="180px"></asp:TextBox>
                                                       </td>
                                                       <td style="padding: 5px; margin: 5px">
                                                           <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator32" runat="server" ControlToValidate="txttotal"
                                                                   ErrorMessage="Please enter  Total Values" ValidationGroup="group">*</asp:RequiredFieldValidator>--%>
                                                       </td>
                                                   </tr>
                                               </table>
                                           </td>
                                       </tr>      
                                            <tr>
                                          <%-- <td style="padding: 5px; margin: 5px" valign="top" align="left">
                                               <span style="font-weight: bold">Select IALA</span>
                                           </td>--%>
                                           <td style="width: 27px">
                                               &nbsp;
                                           </td>
                                           <td valign="top">
                                               &nbsp;
                                           </td>
                                       </tr>
                                     
                                       <tr>
                                           <td align="left" style="padding: 5px; margin: 5px" valign="top">
                                               <table cellpadding="4" cellspacing="5" style="width: 185%">
                                                    <tbody>
     <tr style="height:40px;">
       <td colspan="4" align="left"
           style="padding:5px; margin:5px; background-color:#a0ff93; font-size:13pt; font-weight:bold;">
         Road Cutting Chainage/Location
       </td>
     </tr>

     <tr>
       <td colspan="4">
         <div class="table-responsive">
           <table cellspacing="0" cellpadding="4" rules="all" border="1"
                  id="ctl00_ContentPlaceHolder1_grdDetails"
                  style="color:#333333; width:100%; border-collapse:collapse;">

             <thead>
               <tr class="GridviewScrollC1HeaderWrap"
                   style="color:white; background-color:#009688; height:40px;">
                   <th>From (Kms)</th>
                                         <th>To (Kms)</th>
                                         <th>(OR)</th>
                                         <th>Landmark</th>
               </tr>
             </thead>

             <tbody>

               <tr class="GridviewScrollC1Item" style="height:40px;">
                 <td><input type="text" class="form-control" id="textto"/></td>
                                         <td><input type="text" class="form-control" id="txtfrom"/></td>
                                         <td>(OR)</td>
                                         <td><input type="text" class="form-control" id="txtlandmark"/></td>
               </tr>

               <%--<tr class="GridviewScrollC1Item2" style="font-weight:bold; height:40px;">
                 <td>Latitude, Longitude</td>
                                         <td>Latitude, Longitude</td>
                                         <td></td>
                                         <td></td>
               </tr>--%>
             </tbody>

           </table>
         </div>
       </td>
     </tr>






   </tbody>                                                       
                                                  
                                               </table>
                                           </td>
                                          
                                          
                                       </tr>
                                       <tr id="Tr19" runat="server" visible="false">
                                           <td style="padding: 5px; margin: 5px" valign="top" align="left">
                                               &nbsp;&nbsp;&nbsp; <span style="font-weight: bold"><u>B). Expansion Investment</u></span>
                                           </td>
                                           <td style="width: 27px">
                                               &nbsp;
                                           </td>
                                           <td valign="top">
                                               &nbsp;
                                           </td>
                                       </tr>
                                       <tr id="Tr20" runat="server" visible="false">
                                           <td align="left" style="padding: 5px; margin: 5px" valign="top">
                                               <table cellpadding="4" cellspacing="5" style="width: 83%">
                                                   <tr>
                                                       <td style="padding: 5px; margin: 5px; text-align: left;">
                                                           1.
                                                       </td>
                                                       <td style="padding: 5px; margin: 5px; text-align: left;">
                                                           <asp:Label ID="Label80" runat="server" CssClass="LBLBLACK" Width="210px">Land Value(in Lakhs)<font 
                                                           color="red">*</font></asp:Label>
                                                       </td>
                                                       <td style="padding: 5px; margin: 5px">
                                                           :
                                                       </td>
                                                       <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                           <asp:TextBox ID="TextBox56" runat="server" class="form-control txtbox" Height="28px"
                                                               MaxLength="10" onkeypress="return inputOnlyNumbers(event)" TabIndex="1" ValidationGroup="group"
                                                               Width="180px" AutoPostBack="True"></asp:TextBox>
                                                       </td>
                                                       <td style="padding: 5px; margin: 5px; width: 10px;">
                                                           <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator29" runat="server" ControlToValidate="txtlandValue"
                                                                   ErrorMessage="Please enter  Land Values" ValidationGroup="group">*</asp:RequiredFieldValidator>--%>
                                                       </td>
                                                   </tr>
                                                   <tr>
                                                       <td style="padding: 5px; margin: 5px; text-align: left;">
                                                           2.
                                                       </td>
                                                       <td style="padding: 5px; margin: 5px; text-align: left;">
                                                           <asp:Label ID="Label81" runat="server" CssClass="LBLBLACK" Width="165px">Building Value(in Lakhs)<font 
                                                           color="red">*</font></asp:Label>
                                                       </td>
                                                       <td style="padding: 5px; margin: 5px">
                                                           :
                                                       </td>
                                                       <td style="padding: 5px; margin: 5px; text-align: left;">
                                                           <asp:TextBox ID="TextBox57" runat="server" class="form-control txtbox" Height="28px"
                                                               MaxLength="1" onkeypress="return inputOnlyNumbers(event)" TabIndex="1" ValidationGroup="group"
                                                               Width="180px" AutoPostBack="True"></asp:TextBox>
                                                       </td>
                                                       <td style="padding: 5px; margin: 5px">
                                                           <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator30" runat="server" ControlToValidate="txtbuilding"
                                                                   ErrorMessage="Please enter  Building Values" ValidationGroup="group">*</asp:RequiredFieldValidator>--%>
                                                       </td>
                                                   </tr>
                                               </table>
                                           </td>
                                           <td style="width: 27px">
                                               &nbsp;
                                           </td>
                                           <td valign="top">
                                               <table cellpadding="4" cellspacing="5" style="width: 83%">
                                                   <tr>
                                                       <td style="padding: 5px; margin: 5px; text-align: left;">
                                                           3.
                                                       </td>
                                                       <td style="padding: 5px; margin: 5px; text-align: left;">
                                                           <asp:Label ID="Label82" runat="server" CssClass="LBLBLACK" Width="165px">Plant and Machinery Value(in Lakhs) <font 
                                                           color="red">*</font></asp:Label>
                                                       </td>
                                                       <td style="padding: 5px; margin: 5px">
                                                           :
                                                       </td>
                                                       <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                           <asp:TextBox ID="TextBox58" runat="server" class="form-control txtbox" Height="28px"
                                                               MaxLength="10" onkeypress="return inputOnlyNumbers(event)" TabIndex="1" ValidationGroup="group"
                                                               Width="180px" AutoPostBack="True"></asp:TextBox>
                                                       </td>
                                                       <td style="padding: 5px; margin: 5px; width: 10px;">
                                                           <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator31" runat="server" ControlToValidate="txtPlant"
                                                                   ErrorMessage="Please enter  Plant and Machinery" ValidationGroup="group">*</asp:RequiredFieldValidator>--%>
                                                       </td>
                                                   </tr>
                                                   <tr>
                                                       <td style="padding: 5px; margin: 5px; text-align: left;">
                                                           4.
                                                       </td>
                                                       <td style="padding: 5px; margin: 5px; text-align: left;">
                                                           <asp:Label ID="Label83" runat="server" CssClass="LBLBLACK" Width="165px">Total Value(in Lakhs)<font 
                                                           color="red">*</font></asp:Label>
                                                       </td>
                                                       <td style="padding: 5px; margin: 5px">
                                                           :
                                                       </td>
                                                       <td style="padding: 5px; margin: 5px; text-align: left;">
                                                           <asp:TextBox ID="TextBox59" runat="server" class="form-control txtbox" Height="28px"
                                                               MaxLength="10" onkeypress="return inputOnlyNumbers(event)" TabIndex="1" ValidationGroup="group"
                                                               Width="180px"></asp:TextBox>
                                                       </td>
                                                       <td style="padding: 5px; margin: 5px">
                                                           <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator32" runat="server" ControlToValidate="txttotal"
                                                                   ErrorMessage="Please enter  Total Values" ValidationGroup="group">*</asp:RequiredFieldValidator>--%>
                                                       </td>
                                                   </tr>
                                               </table>
                                           </td>
                                       </tr>

                                         <tr>
                                           <%--<td style="padding: 5px; margin: 5px" valign="top" align="left">
                                               <span style="font-weight: bold">Contact Details</span>
                                           </td>--%>
                                           <td style="width: 27px">
                                               &nbsp;
                                           </td>
                                           <td valign="top">
                                               &nbsp;
                                           </td>
                                       </tr>
                                     
                                       <tr>
                                           <td align="left" style="padding: 5px; margin: 5px" valign="top">
                                               <table cellpadding="4" cellspacing="5" style="width: 83%">
                                                    <tr>
     <td style="padding: 5px; margin: 5px">
         1.
     </td>
     <%--<td style="width: 200px;">
         Mobile No<span class="style5">*</span>
     </td>--%>
      <td style="padding: 5px; margin: 5px; text-align: left;">
     <asp:Label ID="Label21" runat="server" CssClass="LBLBLACK" Width="165px"> Side of the Road<font 
     color="red">*</font></asp:Label>
 </td>
     <td style="padding: 5px; margin: 5px">
         :
     </td>
     <td style="padding: 5px; margin: 5px">
         <div class="col-md-12 d-flex" style="display: flex; width: 205px;">
               <div class="form-check form-check-inline">
                 <input class="form-check-input" type="radio" name="inlineRadioOptions" id="inlineRadio1" value="option1">
                 <label class="form-check-label" for="inlineRadio1">Left Side</label>
               </div>
               <div class="form-check form-check-inline">
                 <input class="form-check-input" type="radio" name="inlineRadioOptions" id="inlineRadio2" value="option2">
                 <label class="form-check-label" for="inlineRadio2">Right Side</label>
               </div>
             </div>
     </td>
     <td style="padding: 5px; margin: 5px">
  
     </td>
 </tr>


                                                    
                                               </table>
                                           </td>
                                           <td style="width: 27px">
                                               &nbsp;
                                           </td>
                                          
                                       </tr>

                                                                                                                                                                       <tr>
                                         <%--  <td style="padding: 5px; margin: 5px" valign="top" align="left">
                                               <span style="font-weight: bold">Select IALA</span>
                                           </td>--%>
                                           <td style="width: 27px">
                                               &nbsp;
                                           </td>
                                           <td valign="top">
                                               &nbsp;
                                           </td>
                                       </tr>
                                       
                                                                                <tr>
                                        <td align="left" style="padding: 5px; margin: 5px" valign="top">
                                            <table cellpadding="4" cellspacing="5" style="width: 185%">
                                                 <tbody>
  <tr style="height:40px;">
    <td colspan="4" align="left"
        style="padding:5px; margin:5px; background-color:#a0ff93; font-size:13pt; font-weight:bold;">
      Sketch showing the proposed road cutting with chainages
    </td>
  </tr>

  <tr>
    <td colspan="4">
      <div class="table-responsive">
        <table cellspacing="0" cellpadding="4" rules="all" border="1"
               id="ctl00_ContentPlaceHolder1_grdDetails"
               style="color:#333333; width:100%; border-collapse:collapse;">

          <tbody>

            <tr class="GridviewScrollC1Item" style="height:40px;">
               <td>(i)<font color="red">*</font></td>
               <td style="padding: 5px; margin: 5px">
    <input class="form-control" type="file" id="">
</td>
               <td>(ii)</td>
               <td style="padding: 5px; margin: 5px">
    <input class="form-control" type="file" id="">
</td>
               <td>(iii)</td>
               <td style="padding: 5px; margin: 5px">
    <input class="form-control" type="file" id="">
</td>
            </tr>

          </tbody>

        </table>
      </div>
    </td>
  </tr>






</tbody>                                                       
                                               
                                            </table>
                                        </td>
                                       
                                       
                                    </tr>
                                       <tr>
                                           <td align="left" style="padding: 5px; margin: 5px" valign="top">
                                               <table cellpadding="4" cellspacing="5" style="width: 83%">

                                                                                                       
                                                                                                        
                                                                                                       <tr>
    <td style="padding: 5px; margin: 5px">
        1.
    </td>
    <td style="padding: 5px; margin: 5px">
        <asp:Label ID="Label15" runat="server" CssClass="LBLBLACK" Width="165px">Self Decleration<font 
        color="red">*</font></asp:Label>
    </td>
    <td style="padding: 5px; margin: 5px">
        :
    </td>
    <td style="padding: 5px; margin: 5px">
        <input class="form-control" type="file" id="">
    </td>
    <td style="padding: 5px; margin: 5px">
        
    </td>
</tr>
                                               </table>
                                           </td>
                                           <td style="width: 27px">
                                               &nbsp;
                                           </td>
                                           <td valign="top">
                                               <table cellpadding="4" cellspacing="5" style="width: 83%">
                                                                                                                                                            
                                                   
                                               </table>
                                           </td>
                                       </tr>
                                       <tr id="Tr21" runat="server" visible="false">
                                           <td style="padding: 5px; margin: 5px" valign="top" align="left">
                                               &nbsp;&nbsp;&nbsp; <span style="font-weight: bold"><u>B). Expansion Investment</u></span>
                                           </td>
                                           <td style="width: 27px">
                                               &nbsp;
                                           </td>
                                           <td valign="top">
                                               &nbsp;
                                           </td>
                                       </tr>
                                       <tr id="Tr22" runat="server" visible="false">
                                           <td align="left" style="padding: 5px; margin: 5px" valign="top">
                                               <table cellpadding="4" cellspacing="5" style="width: 83%">
                                                   <tr>
                                                       <td style="padding: 5px; margin: 5px; text-align: left;">
                                                           1.
                                                       </td>
                                                       <td style="padding: 5px; margin: 5px; text-align: left;">
                                                           <asp:Label ID="Label90" runat="server" CssClass="LBLBLACK" Width="210px">Land Value(in Lakhs)<font 
                                                           color="red">*</font></asp:Label>
                                                       </td>
                                                       <td style="padding: 5px; margin: 5px">
                                                           :
                                                       </td>
                                                       <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                           <asp:TextBox ID="TextBox63" runat="server" class="form-control txtbox" Height="28px"
                                                               MaxLength="10" onkeypress="return inputOnlyNumbers(event)" TabIndex="1" ValidationGroup="group"
                                                               Width="180px" AutoPostBack="True"></asp:TextBox>
                                                       </td>
                                                       <td style="padding: 5px; margin: 5px; width: 10px;">
                                                           <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator29" runat="server" ControlToValidate="txtlandValue"
                                                                   ErrorMessage="Please enter  Land Values" ValidationGroup="group">*</asp:RequiredFieldValidator>--%>
                                                       </td>
                                                   </tr>
                                                   <tr>
                                                       <td style="padding: 5px; margin: 5px; text-align: left;">
                                                           2.
                                                       </td>
                                                       <td style="padding: 5px; margin: 5px; text-align: left;">
                                                           <asp:Label ID="Label91" runat="server" CssClass="LBLBLACK" Width="165px">Building Value(in Lakhs)<font 
                                                           color="red">*</font></asp:Label>
                                                       </td>
                                                       <td style="padding: 5px; margin: 5px">
                                                           :
                                                       </td>
                                                       <td style="padding: 5px; margin: 5px; text-align: left;">
                                                           <asp:TextBox ID="TextBox64" runat="server" class="form-control txtbox" Height="28px"
                                                               MaxLength="1" onkeypress="return inputOnlyNumbers(event)" TabIndex="1" ValidationGroup="group"
                                                               Width="180px" AutoPostBack="True"></asp:TextBox>
                                                       </td>
                                                       <td style="padding: 5px; margin: 5px">
                                                           <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator30" runat="server" ControlToValidate="txtbuilding"
                                                                   ErrorMessage="Please enter  Building Values" ValidationGroup="group">*</asp:RequiredFieldValidator>--%>
                                                       </td>
                                                   </tr>
                                               </table>
                                           </td>
                                           <td style="width: 27px">
                                               &nbsp;
                                           </td>
                                           <td valign="top">
                                               <table cellpadding="4" cellspacing="5" style="width: 83%">
                                                   <tr>
                                                       <td style="padding: 5px; margin: 5px; text-align: left;">
                                                           3.
                                                       </td>
                                                       <td style="padding: 5px; margin: 5px; text-align: left;">
                                                           <asp:Label ID="Label92" runat="server" CssClass="LBLBLACK" Width="165px">Plant and Machinery Value(in Lakhs) <font 
                                                           color="red">*</font></asp:Label>
                                                       </td>
                                                       <td style="padding: 5px; margin: 5px">
                                                           :
                                                       </td>
                                                       <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                           <asp:TextBox ID="TextBox65" runat="server" class="form-control txtbox" Height="28px"
                                                               MaxLength="10" onkeypress="return inputOnlyNumbers(event)" TabIndex="1" ValidationGroup="group"
                                                               Width="180px" AutoPostBack="True"></asp:TextBox>
                                                       </td>
                                                       <td style="padding: 5px; margin: 5px; width: 10px;">
                                                           <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator31" runat="server" ControlToValidate="txtPlant"
                                                                   ErrorMessage="Please enter  Plant and Machinery" ValidationGroup="group">*</asp:RequiredFieldValidator>--%>
                                                       </td>
                                                   </tr>
                                                   <tr>
                                                       <td style="padding: 5px; margin: 5px; text-align: left;">
                                                           4.
                                                       </td>
                                                       <td style="padding: 5px; margin: 5px; text-align: left;">
                                                           <asp:Label ID="Label93" runat="server" CssClass="LBLBLACK" Width="165px">Total Value(in Lakhs)<font 
                                                           color="red">*</font></asp:Label>
                                                       </td>
                                                       <td style="padding: 5px; margin: 5px">
                                                           :
                                                       </td>
                                                       <td style="padding: 5px; margin: 5px; text-align: left;">
                                                           <asp:TextBox ID="TextBox66" runat="server" class="form-control txtbox" Height="28px"
                                                               MaxLength="10" onkeypress="return inputOnlyNumbers(event)" TabIndex="1" ValidationGroup="group"
                                                               Width="180px"></asp:TextBox>
                                                       </td>
                                                       <td style="padding: 5px; margin: 5px">
                                                           <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator32" runat="server" ControlToValidate="txttotal"
                                                                   ErrorMessage="Please enter  Total Values" ValidationGroup="group">*</asp:RequiredFieldValidator>--%>
                                                       </td>
                                                   </tr>
                                               </table>
                                           </td>
                                       </tr>
                                                                                     
                                  
                                    <tr>
                                        <td align="left" style="padding: 5px; margin: 5px" valign="top">
                                            <table cellpadding="4" cellspacing="5" style="width: 185%">
                                                 <tbody>
  <tr style="height:40px;">
    <td colspan="4" align="left"
        style="padding:5px; margin:5px; background-color:#a0ff93; font-size:13pt; font-weight:bold;">
       Statement of Charges for Road Cutting / ROW Permissions
    </td>
  </tr>

  <tr>
    <td colspan="4">
      <div class="table-responsive">
        <table cellspacing="0" cellpadding="4" rules="all" border="1"
               id="ctl00_ContentPlaceHolder1_grdDetails"
               style="color:#333333; width:100%; border-collapse:collapse;">

          <thead>
            <tr class="GridviewScrollC1HeaderWrap"
                style="color:white; background-color:#009688; height:40px;">
                 <th>S.No.</th>
                                      <th>Name of road with chainages</th>
                                      <th>Type of surface for cutting</th>
                                      <th>Length/Pit (In Metres)</th>
                                      <th>Rate/RM (₹)</th>
                                      <th>Amount (₹)</th>
                                      <th>+Add</th>
            </tr>
          </thead>

          <tbody>

            <tr class="GridviewScrollC1Item" style="height:40px;">
             <td>1</td>
                                      <td><input type="text" class="form-control" id=""></td>
                                           <td style="padding: 5px; margin: 5px">
         <asp:DropDownList ID="DropDownList9" runat="server" 
    CssClass="form-control txtbox" 
    TabIndex="1"
    Height="33px" Width="180px">

    <asp:ListItem Selected="True">--Select--</asp:ListItem>
    <asp:ListItem Value="CC Road">CC Road</asp:ListItem>
    <asp:ListItem Value="BT Road">BT Road</asp:ListItem>
    <asp:ListItem Value="Foot Paths">Foot Paths</asp:ListItem>
    <asp:ListItem Value="Berm/WBM">Berm/WBM</asp:ListItem>
    <asp:ListItem Value="Beyond Toe of embankment for Urban Areas">Beyond Toe of embankment for Urban Areas</asp:ListItem>
    <asp:ListItem Value="Beyond Toe of embankment for Rural Areas"> Beyond Toe of embankment for Rural Areas </asp:ListItem>
    <asp:ListItem Value="Micro Trenching Technology for depth of 600mm, 50mm width and install 3 to 4">  Micro Trenching Technology for depth of 600mm, 50mm width and install 3 to 4 </asp:ListItem>
    <asp:ListItem Value="On berm & earthern Road formation for each pit of size 2mX1mX2m HDD"> On berm & earthern Road formation for each pit of size 2mX1mX2m HDD </asp:ListItem>
    <asp:ListItem Value="On bituminous/Cement Road each pit of size 2mX1mX2m HDD"> On bituminous/Cement Road each pit of size 2mX1mX2m HDD </asp:ListItem>
</asp:DropDownList>
     </td>
                                      <td><input type="text" class="form-control" id=""></td>
                                      <td>         <asp:DropDownList ID="DropDownList10" runat="server" 
    CssClass="form-control txtbox" 
    TabIndex="1">

    <asp:ListItem Selected="True">--Select--</asp:ListItem>
    <asp:ListItem Value="1">1844/- per RMT</asp:ListItem>
    <asp:ListItem Value="2">2275/- per RMT</asp:ListItem>
    <asp:ListItem Value="3">799/- per RMT</asp:ListItem>
    <asp:ListItem Value="4">285/- per RMT</asp:ListItem>
    <asp:ListItem Value="5">156/- per RMT</asp:ListItem>
    <asp:ListItem Value="6"> 195/- per RMT </asp:ListItem>
    <asp:ListItem Value="7"> 50/- per RMT</asp:ListItem>
    <asp:ListItem Value="8"> 595/- per pit</asp:ListItem>
    <asp:ListItem Value="9"> 11571/- per pit</asp:ListItem>
</asp:DropDownList></td>
                                      <td><input type="number" class="form-control" id=""></td>
                                      <td><input type="Add" name="" value="Add"  class="btn btn-primary" style="height:32px;width:90px;"></td>
            </tr>

          </tbody>

        </table>
      </div>
    </td>
  </tr>






</tbody>                                                       
                                               
                                            </table>
                                        </td>
                                       
                                       
                                    </tr>
                                  
                                                                      
                                        <tr>
                                           <%-- <td align="left" style="padding: 5px; margin: 5px" valign="top">
                                                <asp:Label ID="Label422" runat="server" CssClass="LBLBLACK" Font-Bold="True" Width="280px">Employment Details</asp:Label>
                                            </td>--%>
                                            <td style="width: 27px">
                                                &nbsp;
                                            </td>
                                            <td valign="top">
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px" valign="top">
                                                <table cellpadding="4" cellspacing="5" style="width: 83%">
                                         
                                                    <tr>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:Label ID="Label401" runat="server" CssClass="LBLBLACK" Width="200px">Total<font 
                                                            color="red">*</font></asp:Label>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">
                                                            :
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                            <asp:TextBox ID="txtDirectmale" runat="server" class="form-control txtbox" Height="28px"
                                                                MaxLength="8" onkeypress="NumberOnly()" TabIndex="1" ValidationGroup="group" Onpaste="return false"
                                                                Width="180px" AutoPostBack="True"></asp:TextBox>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; width: 10px;">
                                                     
                                                        </td>
                                                    </tr>
                                                     <tr>
     <td style="padding: 5px; margin: 5px; text-align: left;">
        
     </td>
     <td style="padding: 5px; margin: 5px; text-align: left;">
         <asp:Label ID="Label40" runat="server" CssClass="LBLBLACK" Width="200px">Total Road Cutting/Right of Way Charges<font 
         color="red">*</font></asp:Label>
     </td>
     <td style="padding: 5px; margin: 5px">
         :
     </td>
     <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
         <asp:TextBox ID="TextBox36" runat="server" class="form-control txtbox" Height="28px"
             MaxLength="8" onkeypress="NumberOnly()" TabIndex="1" ValidationGroup="group" Onpaste="return false"
             Width="180px" AutoPostBack="True"></asp:TextBox>
     </td>
     <td style="padding: 5px; margin: 5px; width: 10px;">
  
     </td>
 </tr>
                                                  
                                                    
                                                </table>
                                            </td>
                                            <td style="width: 27px">
                                                &nbsp;
                                            </td>
                                  
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px" colspan="3" align="center">
                                                <tr>
                                                    <td style="padding: 5px; margin: 5px" colspan="3" align="center">
                                                        &nbsp;
                                                    </td>
                                                </tr>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center" colspan="3" style="padding: 5px; margin: 5px; text-align: center;">
                                                <asp:Button ID="BtnClear" runat="server" CausesValidation="False" CssClass="btn btn-warning"
                                                    Height="32px" TabIndex="10" Text="ClearAll" ToolTip="To Clear  the Screen"
                                                    Width="90px" />&nbsp;
                                                <asp:Button ID="BtnSave1" runat="server" CssClass="btn btn-primary" Height="32px"
                                                     TabIndex="10" Text="Save" Width="90px" ValidationGroup="group" />
                                                <asp:Button ID="BtnDelete0" runat="server" CssClass="btn btn-danger" Height="32px"
                                                     TabIndex="10" Text="Privious" Width="90px" Visible="False" />
                                                &nbsp;
                                                <asp:Button ID="BtnDelete" runat="server" CssClass="btn btn-danger" Height="32px"
                                                     TabIndex="10" Text="Next" Width="90px" ValidationGroup="group" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center" colspan="3" style="padding: 5px; margin: 5px">
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
                                        <tr>
                                            <td colspan="10">
                                                <asp:HiddenField ID="hdfID" runat="server" />
                                                <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
                                                    ShowSummary="False" ValidationGroup="group" />
                                                <asp:ValidationSummary ID="ValidationSummary2" runat="server" ShowMessageBox="True"
                                                    ShowSummary="False" ValidationGroup="child" />
                                                <asp:HiddenField ID="hdfFlagID" runat="server" />
                                                <asp:HiddenField ID="hdfFlagID0" runat="server" />
                                                <asp:HiddenField ID="hdfFlagID1" runat="server" />
                                                <asp:HiddenField ID="hdfpencode" runat="server" />

                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                        <%--  </div>--%>
                    </div>
                </div>
            </div>
            <asp:UpdateProgress ID="UpdateProgress" runat="server" AssociatedUpdatePanelID="upd1">
                <ProgressTemplate>
                    <div class="update">
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
    <link href="../../css/ui-lightness/jquery-ui-1.8.19.custom.css" rel="stylesheet" />
    <script src="../../js/jquery-1.7.2.min.js"></script>
    <script src="../../js/jquery-ui-1.8.19.custom.min.js"></script>
    <link href="<%= ResolveUrl("css/ui-lightness/jquery-ui-1.8.19.custom.css") %>" rel="stylesheet"
        type="text/css" />
    <script type="text/javascript" src="<%= ResolveUrl("js/jquery-1.7.2.min.js") %>"></script>
    <script src="<%= ResolveUrl("js/jquery-ui-1.8.19.custom.min.js") %>" type="text/javascript"></script>
    <script type="text/javascript">
        function pageLoad() {
            var date = new Date();
            var currentMonth = date.getMonth();
            var currentDate = date.getDate();
            var currentYear = date.getFullYear();

            $("input[id$='txtRegDate']").datepicker(
                {
                    dateFormat: "dd/mm/yy",
                    //  maxDate: new Date(currentYear, currentMonth, currentDate)
                }); // Will run at every postback/AsyncPostback
        }
        $(function () {
            var date = new Date();
            var currentMonth = date.getMonth();
            var currentDate = date.getDate();
            var currentYear = date.getFullYear();
            $("input[id$='txtRegDate']").datepicker(
                {
                    //dateFormat: "dd/mm/yy",
                    dateFormat: "dd/mm/yy",
                    //maxDate: new Date(currentYear, currentMonth, currentDate)
                });
        });
    </script>
    <style type="text/css">
        .ui-datepicker {
            font-size: 8pt !important;
            height: 250px;
            padding: 0.2em 0.2em 0;
            width: 250px;
        }
    </style>
</asp:Content>
