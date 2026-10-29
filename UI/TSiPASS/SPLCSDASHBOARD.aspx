<%@ Page Language="C#" AutoEventWireup="true"  MasterPageFile="~/UI/TSiPASS/CCMaster.master"  CodeFile="SPLCSDASHBOARD.aspx.cs" Inherits="UI_TSiPASS_SPLCSDASHBOARD" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <style>
        .modern-btn {
    background: linear-gradient(135deg, #f4b04f, #f59e0b);
    color: #ffffff;
    font-size: 18px;
    font-weight: 600;
    padding: 18px 40px;
    border-radius: 10px;
    border: none;
    cursor: pointer;
    letter-spacing: 0.5px;
    box-shadow: 0 8px 20px rgba(0, 0, 0, 0.15);
    transition: all 0.3s ease;
}

/* Hover effect */
.modern-btn:hover {
    transform: translateY(-4px);
    box-shadow: 0 14px 30px rgba(0, 0, 0, 0.25);
    background: linear-gradient(135deg, #f59e0b, #f4b04f);
}

/* Optional spacing if both buttons are in same row */
.modern-btn + .modern-btn {
    margin-left: 80px;
}
    </style>
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
                        <td align="center" style="text-align: center">&nbsp;</td>
                        <td align="center" style="text-align: center">&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
                   
                   
                    <tr id="trinc" runat="server" visible="true">
                        
                        <td align="center" style="text-align: center" colspan="1">
                            <asp:Button ID="btnINC" runat="server"
                                CssClass="modern-btn" Height="91px" TabIndex="10" Width="280px"
                                Text="INCENTIVES REPORTS" Font-Bold="True"
                                ValidationGroup="group" Font-Names="Verdana" Font-Size="18px" OnClick="btnINC_Click" />

                        </td>
                        <td align="center" style="text-align: left" colspan="1">
                             <asp:Button ID="btnTTAP" runat="server"
                                    CssClass="modern-btn" Height="91px" TabIndex="10" Width="280px"
                                    Text="TTAP INCENTIVES" Font-Bold="True"
                                      ValidationGroup="group" Font-Names="Verdana" Font-Size="18px" OnClick="btnTTAP_Click" />

                        </td>
                    </tr>
                               
                                
                    
                    
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
