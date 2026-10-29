<%@ Page Language="C#" MasterPageFile="CCMaster.master" AutoEventWireup="true" CodeFile="renewalsReportsdashboard.aspx.cs" Inherits="Default3" Title=":: TS-iPass Govenrnment of Telengana :: Home" %>
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
            <td style="padding-top: 10px; padding-bottom: 20px; padding-left: 9px; height: 675px;" valign="top" align="center">
                <table style="width: 70%">
                    <tr>
                        <td colspan="4" align="left" style="text-align: left">
                                            <asp:Label ID="Label378" runat="server" CssClass="LBLBLACK" Width="250px" 
                                                Font-Bold="True" Font-Size="18px">Renewals Dashboard</asp:Label>
                                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td align="left" style="text-align: left" >
                                            <asp:HyperLink ID="HyperLink1" runat="server" Font-Size="large"
                                                 NavigateUrl="https://labour.telangana.gov.in/IPASSAbstractReport.do"  Target="_blank">Labour</asp:HyperLink>
                                        </td>
                        <td align="center" 
                            style="text-align: center; font-size: medium; font-family: Verdana; color: #3366CC; font-style: normal;">
                                            &nbsp;</td>
                        <td align="center" 
                            style="text-align: center; font-size: medium; font-family: Verdana; color: #3366CC; font-style: normal;">
                                            &nbsp;</td>

                         <td align="left" style="text-align: left" >
                                            <asp:HyperLink ID="HyperLink4" runat="server" Font-Size="Large"
                                                 
                                                
                                                Target="_blank">Track your status for Labour Department</asp:HyperLink>
                                        </td>

                       
                    </tr>
                    <tr>
                        <td align="center" style="text-align: center" >
                                            &nbsp;</td>
                        <td align="center" 
                            style="text-align: center; font-size: medium; font-family: Verdana; color: #3366CC; font-style: normal;">
                                            &nbsp;</td>
                        <td align="center" 
                            style="text-align: center; font-size: medium; font-family: Verdana; color: #3366CC; font-style: normal;">
                                            &nbsp;</td>
                        <td align="center" 
                            style="text-align: center; font-size: medium; font-family: Verdana; color: #3366CC; font-style: normal;">
                                            &nbsp;</td>
                    </tr>
                    <tr>
                       
                          <td align="left" 
                            style="text-align: left; font-size: medium; font-family: Verdana; color: #3366CC; font-style: normal;">
                                            <asp:HyperLink ID="HyperLink2" runat="server" Font-Size="large" 
                                                NavigateUrl="http://tsboilers.cgg.gov.in/ipassRenewalBoilersReport.do" Target="_blank">Boilers</asp:HyperLink>
                                        </td>
                        <td align="center" 
                            style="text-align: center; font-size: medium; font-family: Verdana; color: #3366CC; font-style: normal;">
                                            &nbsp;</td>
                        <td align="center" 
                            style="text-align: center; font-size: medium; font-family: Verdana; color: #3366CC; font-style: normal;">
                                            &nbsp;</td>
                        <td align="left" 
                            style="text-align: left; font-size: medium; font-family: Verdana; color: #3366CC; font-style: normal;">
                                            <asp:HyperLink ID="HyperLink5" runat="server" Font-Size="Large"
                                                 
                                               
                                                Target="_blank">Track for Boiler Renewal Status</asp:HyperLink>
                                        </td>

                       

                    </tr>
                    <tr>
                        <td align="center" style="text-align: center" >
                                            &nbsp;</td>
                        <td align="center" 
                            style="text-align: center; font-size: medium; font-family: Verdana; color: #3366CC; font-style: normal;">
                                            &nbsp;</td>
                        <td align="center" 
                            style="text-align: center; font-size: medium; font-family: Verdana; color: #3366CC; font-style: normal;">
                                            &nbsp;</td>
                        <td align="center" 
                            style="text-align: center; font-size: medium; font-family: Verdana; color: #3366CC; font-style: normal;">
                                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td align="left" style="text-align: left" >
                                            <asp:HyperLink ID="HyperLink3" runat="server" Font-Size="Large"
                                                 
                                                NavigateUrl="http://tsfactories.cgg.gov.in/VerifyApplicationStatus.do?ipass=T"  
                                                Target="_blank">Factories</asp:HyperLink>
                                        </td>
                        <td align="center" 
                            style="text-align: center; font-size: medium; font-family: Verdana; color: #3366CC; font-style: normal;">
                                            &nbsp;</td>
                        <td align="center" 
                            style="text-align: center; font-size: medium; font-family: Verdana; color: #3366CC; font-style: normal;">
                                            &nbsp;</td>
                        <td align="left" 
                            style="text-align: left; font-size: medium; font-family: Verdana; color: #3366CC; font-style: normal;">
                                            <asp:HyperLink ID="HyperLink6" runat="server" Font-Size="Large"
                                                 NavigateUrl="http://tsfactories.cgg.gov.in/VerifyApplicationStatus.do?ipass=T" 
                                               
                                                Target="_blank">Track for Factories Renewal Status</asp:HyperLink>
                                        </td>
                    </tr>
                </table>
       </td>
        </tr>
    </table>
</asp:Content>

