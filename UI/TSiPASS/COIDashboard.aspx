<%@ Page Title="" Language="C#" MasterPageFile="~/UI/TSiPASS/CCMaster.master" AutoEventWireup="true" CodeFile="COIDashboard.aspx.cs" Inherits="UI_TSiPASS_COIDashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script language="javascript">



        function OpenPopup() {

            window.open("Lookups/frmcjfslookup.aspx", "List", "scrollbars=yes,resizable=yes,width=550,height=320");

            return false;
        }


        function Names() {
            var AsciiValue = event.keyCode
            if ((AsciiValue >= 65 && AsciiValue <= 90) || (AsciiValue >= 97 && AsciiValue <= 122) || (AsciiValue == 46) || (AsciiValue == 32))
                event.returnValue = true;
            else {
                event.returnValue = false;

                alert("Enter Alphabets, '.' and Space Only");
            }
        }

        function DecimalOnly() {
            var AsciiValue = event.keyCode
            if ((AsciiValue >= 48 && AsciiValue <= 57) || (AsciiValue == 8 || AsciiValue == 127) || AsciiValue == 46)
                event.returnValue = true;
            else {
                event.returnValue = false;

                alert("Enter DecimalValues Only");
            }
        }


        function AlphaNumericOnly() {
            var AsciiValue = event.keyCode
            if ((AsciiValue >= 65 && AsciiValue <= 90) || (AsciiValue >= 97 && AsciiValue <= 122) || (AsciiValue >= 48 && AsciiValue <= 57))
                event.returnValue = true;
            else {
                event.returnValue = false;

                alert("Enter Alphabets,  and Characters  Only");
            }
        }

    </script>

    <script type="text/javascript">
        $(function () {
            $('input[id$=txtration1]').bind('cut copy paste', function (e) {
                e.preventDefault();
                alert('You cannot ' + e.type + ' text!');
            });
        });
    </script>

    <script type="text/javascript">
        $(function () {
            $('input[id$=txtration2]').bind('cut copy paste', function (e) {
                e.preventDefault();
                alert('You cannot ' + e.type + ' text!');
            });
        });
    </script>

    <script type="text/javascript">
        $(function () {
            $('input[id$=txtsurveynum]').bind('cut copy paste', function (e) {
                e.preventDefault();
                alert('You cannot ' + e.type + ' text!');
            });
        });
    </script>
    <script type="text/javascript">
        $(function () {
            $('input[id$=txtExtent]').bind('cut copy paste', function (e) {
                e.preventDefault();
                alert('You cannot ' + e.type + ' text!');
            });
        });
    </script>
    <script type="text/javascript">
        $(function () {
            $('input[id$=txtCJFSBeneficiery]').bind('cut copy paste', function (e) {
                e.preventDefault();
                alert('You cannot ' + e.type + ' text!');
            });
        });


    </script>



    <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
        <tr>
            <td style="padding-top: 10px; padding-bottom: 20px; padding-left: 9px; height: 675px;" valign="top" align="center">
                <table style="width: 100%">
                    <tr>
                        <td colspan="2">
                            <asp:Label ID="Label437" runat="server"
                                CssClass="LBLBLACK" Font-Bold="True"
                                Font-Names="Verdana" Width="350px" Font-Size="20px" Height="40px">Commissioner's Dashboard</asp:Label>
                        </td>
                        
                    </tr>
                    <tr>
                        <td align="center" style="text-align: center">&nbsp;</td>
                        <td align="center" style="text-align: center">&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td align="center" style="text-align: center" width="470px">
                            <asp:Button ID="btnCFE" runat="server" CssClass="btn btn-primary"
                                Height="105px" OnClick="btnCFE_Click"  TabIndex="10" Text="CFE DASHBOARD"
                                ValidationGroup="group" Width="268px" Font-Bold="True"
                                Font-Names="Verdana" Font-Size="18px" />
                        </td>
                        <td align="center" style="text-align: center">
                            <asp:Button ID="btnCFO" runat="server"
                                CssClass="btn btn-danger" Height="105px" OnClick="btnCFO_Click" TabIndex="10"
                                Text="CFO DASHBOARD" Font-Bold="True" Width="268px"
                                ValidationGroup="group" Font-Names="Verdana" Font-Size="18px" />
                        </td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td align="center" style="text-align: center" width="470px">&nbsp;</td>
                        <td align="center" style="text-align: center">&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>                 
                   
                    <tr>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr id="trinc" runat="server" visible="true">
                        
                        <td align="center" style="text-align: center" colspan="1">
                            <asp:Button ID="btnINC" runat="server"
                                CssClass="btn btn-warning" Height="91px" TabIndex="10" Width="268px"
                                Text="INCENTIVES REPORTS" Font-Bold="True"
                                ValidationGroup="group" Font-Names="Verdana" Font-Size="18px" OnClick="btnINC_Click" />

                        </td>
                        <td align="center" style="text-align: center" colspan="1">
                            <asp:Button ID="btnsvc" runat="server"
                                CssClass="btn btn-warning" Height="91px" TabIndex="10" Width="268px"
                                Text="Incentives Applications" Font-Bold="True"
                                ValidationGroup="group" Font-Names="Verdana" Font-Size="18px" OnClick="btnsvc_Click" />

                        </td>
                    </tr>

                  
                    <tr visible="false">
                        <td align="center" style="text-align: center" colspan="1">
                               <asp:Button ID="btnTTAP" runat="server"
                                    CssClass="btn btn-warning" Height="91px" TabIndex="10" Width="268px"
                                    Text="TTAP INCENTIVES" Font-Bold="True"
                                      ValidationGroup="group" Font-Names="Verdana" Font-Size="18px" OnClick="btnTTAP_Click" />
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>                  
                    
                    
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
