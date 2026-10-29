<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="IndexOLD.aspx.cs" Inherits="Default3" Title=":: TS-iPASS Govenrnment of Telengana :: Home" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
 
    <script language="javascript">



function OpenPopup() 
 
   {

    window.open("Lookups/frmcjfslookup.aspx","List","scrollbars=yes,resizable=yes,width=550,height=320");

    return false;
    }
    
        
function Names()
    {
       var AsciiValue=event.keyCode
        if((AsciiValue>=65 && AsciiValue<=90) || (AsciiValue>=97 && AsciiValue<=122) || (AsciiValue==46) || (AsciiValue==32))
            event.returnValue=true;
        else
        {
            event.returnValue=false;
            
             alert("Enter Alphabets, '.' and Space Only");
           }
    }
    
    function DecimalOnly()
        {
           var AsciiValue=event.keyCode
            if((AsciiValue>=48 && AsciiValue<=57 ) || (AsciiValue==8 || AsciiValue==127) || AsciiValue==46)
                event.returnValue=true;
            else
            {
                event.returnValue=false;
                
                alert("Enter DecimalValues Only");
               }
        }
        

function AlphaNumericOnly()
{
       var AsciiValue=event.keyCode
        if((AsciiValue>=65 && AsciiValue<=90) || (AsciiValue>=97 && AsciiValue<=122) || (AsciiValue>=48 && AsciiValue<=57 ))
            event.returnValue=true;
        else
        {
            event.returnValue=false;
            
             alert("Enter Alphabets,  and Characters  Only");
           }
    }

</script>

<script type="text/javascript">
        $(function() {
        $('input[id$=txtration1]').bind('cut copy paste', function(e) {
                e.preventDefault();
                alert('You cannot ' + e.type + ' text!');
            });
        });
    </script>
    
     <script type="text/javascript">
        $(function() {
        $('input[id$=txtration2]').bind('cut copy paste', function(e) {
                e.preventDefault();
                alert('You cannot ' + e.type + ' text!');
            });
        });
    </script>
    
     <script type="text/javascript">
        $(function() {
        $('input[id$=txtsurveynum]').bind('cut copy paste', function(e) {
                e.preventDefault();
                alert('You cannot ' + e.type + ' text!');
            });
        });
    </script>
    <script type="text/javascript">
        $(function() {
        $('input[id$=txtExtent]').bind('cut copy paste', function(e) {
                e.preventDefault();
                alert('You cannot ' + e.type + ' text!');
            });
        });
    </script>
     <script type="text/javascript">
        $(function() {
        $('input[id$=txtCJFSBeneficiery]').bind('cut copy paste', function(e) {
                e.preventDefault();
                alert('You cannot ' + e.type + ' text!');
            });
        });


    </script>
    
    
    
    
   
<table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
        <tr>
            <td style="padding-top: 10px; padding-bottom: 20px; padding-left: 9px;" valign="top" align="center">
                <table border="0" cellpadding="0" cellspacing="0" width="900">
                    <tr>
                        <td align="center" valign="top">
                            <table border="0" cellpadding="0" cellspacing="0" width="98%">
                                <tr>
                                    <td width="50%">
                                        <table align="center" border="0" cellpadding="3" cellspacing="3" width="100%">
                                            <tr>
                                                <td align="left" 
                                                    style="font-family: arial, Helvetica, sans-serif; font-size: 13pt; font-weight: bold; color: #00CCFF">
                                                    Welcome to
                                                    <span style="color: #00CCFF; font-family: arial, Helvetica, sans-serif; font-size: 13pt; font-weight: bold">
                                                    TS-iPASS  Government Of Telengana</span></td>
                                            </tr>
                                            <tr>
                                                <td style="font-family: arial, Helvetica, sans-serif; font-size: 13pt; font-weight: bold; color: #3f99f3">
                                                    &nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td style="font-family: arial, Helvetica, sans-serif; font-size: 13pt; font-weight: bold; color: #3f99f3" 
                                                    align="justify">
                        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="#" 
                             Font-Bold="True" ForeColor="#00CCFF" Width="300px" Font-Names="Verdana" Font-Size="14px">Click Here Entrepreneur Registration</asp:HyperLink>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="font-family: arial, Helvetica, sans-serif; font-size: 13pt; font-weight: bold; color: #3f99f3">
                                                   <a href="UI/TSiPASS/AddnewuserRegistration.aspx">
<img border="0" alt="W3Schools" src="images/register-now-button.png" />
</a>      </td>
                                            </tr>
                                            <tr>
                                                <td style="font-family: arial, Helvetica, sans-serif; font-size: 13pt; font-weight: bold; color: #3f99f3">
                                                    &nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td style="font-family: arial, Helvetica, sans-serif; font-size: 13pt; font-weight: bold; color: #3f99f3">
                                                    &nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td style="font-family: arial, Helvetica, sans-serif; font-size: 13pt; font-weight: bold; color: #3f99f3">
                                                    &nbsp;</td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td rowspan="2">
                            <img alt="" height="310" src="images/rajsamandMiddle_02.jpg" 
                                width="30" align="left" /></td>
                        <td align="justify" valign="top">
                            
                            <table class="style1">
                                <tr>
                                    <td align="center" valign="middle">
                                        <table id="TABLE1" border="0" cellpadding="5" cellspacing="5" 
                                            onclick="return TABLE1_onclick()" 
                                            style="border: 1px solid #003366; width: 92%; height: 277px;">
                                            
                            
                            
                                                
                                            <tr>
                                                <td align="center" bgcolor="#336699" colspan="2">
                                                        <asp:Label ID="Label384" runat="server" CssClass="LBLBLACK" Width="120px" 
                                                        Font-Bold="True" Font-Names="Verdana" ForeColor="White">Log In</asp:Label>
                                                    </td>
                                            </tr>
                                            <tr>
                                                <td align="center" colspan="2">
                                                        <asp:RadioButtonList ID="RadioButtonList1" runat="server" 
                                                            RepeatDirection="Horizontal" Width="230px" Font-Names="Verdana" 
                                                            Font-Size="12px" Visible="False">
                                                            <asp:ListItem>Department</asp:ListItem>
                                                            <asp:ListItem Value="Enterprenuer">Entrepreneur</asp:ListItem>
                                                        </asp:RadioButtonList>
                                                    </td>
                                            </tr>
                                            <tr>
                                                <td >
                                                        <asp:Label ID="Label385" runat="server" CssClass="LBLBLACK" Width="80px" 
                                                            Font-Names="Verdana" Font-Size="12px">Username</asp:Label>
                                                    </td>
                                                <td>
                                                        <asp:TextBox ID="txtUserId" runat="server" class="form-control txtbox" 
                                                            Height="28px" MaxLength="15"  TabIndex="1" 
                                                            ValidationGroup="group" Width="160px"></asp:TextBox>
                                                    </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                        <asp:Label ID="Label382" runat="server" CssClass="LBLBLACK" Width="80px" 
                                                            Font-Names="Verdana" Font-Size="12px">Password</asp:Label>
                                                    </td>
                                                <td>
                                                        <asp:TextBox ID="txtPwd" runat="server" class="form-control txtbox" 
                                                            Height="28px" MaxLength="15" TabIndex="1" 
                                                            TextMode="Password" ValidationGroup="group" Width="160px"></asp:TextBox>
                                                    </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    &nbsp;&nbsp;<asp:Button ID="btnSignIn" runat="server" CssClass="btn btn-primary" 
                                                Height="28px" onclick="BtnSave_Click" TabIndex="10" Text="Login" 
                                                ValidationGroup="group" Width="70px" Font-Names="Verdana" Font-Bold="True" 
                                                        Font-Size="12px" />
                                                </td>
                                                <td align="justify">
                                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                            <asp:Button ID="BtnSave4" runat="server" CssClass="btn btn-primary" 
                                                Height="28px" onclick="BtnSave4_Click" TabIndex="10" Text="Cancel" 
                                                ValidationGroup="group" Width="70px" Font-Names="Verdana" Font-Bold="True" 
                                                        Font-Size="12px" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center" colspan="2">
                                                    <asp:Label ID="lblmsg" runat="server" CssClass="LBLSTATUS" Font-Size="Small" 
                                                        ForeColor="Red"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center" colspan="2">
                                                    &nbsp;</td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td>
                                                        &nbsp;</td>
                                </tr>
                            </table>
                        </td>
                        <td>
                            <img alt="" height="47" 
                                src="file:///G:/Jeevika%20opts%20on27-06-2013/Jeevika%20opts%20on27-06-2013/images/spacer.gif" 
                                width="1" /></td>
                    </tr>
                    <tr>
                        <td valign="top">
                            &nbsp;</td>
                        <td align="center" valign="top">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>

<asp:Content ID="Content2" runat="server" contentplaceholderid="head">

    <style type="text/css">
        .style1
        {
            width: 100%;
        }
.btn{display:inline-block;padding:6px 12px;margin-bottom:0;font-size:14px;font-weight:400;line-height:1.42857143;text-align:center;white-space:nowrap;vertical-align:middle;-ms-touch-action:manipulation;touch-action:manipulation;cursor:pointer;-webkit-user-select:none;-moz-user-select:none;-ms-user-select:none;user-select:none;background-image:none;border:1px solid transparent;border-radius:4px}
.btn-primary{color:#fff;background-color:#337ab7;border-color:#2e6da4}input{margin:0;font:inherit;color:inherit}input{line-height:normal}input{font-family:inherit;font-size:inherit;line-height:inherit}*{-webkit-box-sizing:border-box;-moz-box-sizing:border-box;box-sizing:border-box}
        </style>

</asp:Content>


