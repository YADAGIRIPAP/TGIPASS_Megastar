<%@ page title="" language="C#" masterpagefile="CCMaster.master" autoeventwireup="true" codefile="HomeJDDashboard.aspx.cs" inherits="UI_TSiPASS_HomeJDDashboard" %>

<script runat="server">

    protected void Button1_Click(object sender, EventArgs e)
    {

    }
</script>


<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

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
                <%--<asp:Button id="jdbutton" style="text-align: center; font-weight: bold; font-size: medium; 
                   font-family:Verdana;color: Yellow; background-color:Gray; border-style: double">Joint Director's  Dashboard</asp:Button>--%>
                <table>
                    <tr>
                        <td style="text-align: center">
                            <asp:Label ID="Label437" runat="server"
                                CssClass="LBLBLACK" Font-Bold="True"
                                Font-Names="Verdana" Width="350px" Font-Size="20px" Height="40px" BorderStyle="Double" BorderColor="Gray" BackColor="Beige">Joint Director's  Dashboard</asp:Label>
                        </td>
                    </tr>
                </table>
                <table style="width: 100%">
                    <tr>
                        <td></td>

                        <td></td>
                    </tr>
                    <tr>
                        <td align="center" style="text-align: center">&nbsp;</td>
                        <td align="center" style="text-align: center">&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr id="TRCFECFO" runat="server">
                        <td align="center" style="text-align: center" width="470px">
                            <asp:Button ID="BtnSave1" runat="server" CssClass="btn btn-primary"
                                Height="105px" OnClick="BtnSave1_Click" TabIndex="10" Text="CFE DASHBOARD"
                                ValidationGroup="group" Width="268px" Font-Bold="True"
                                Font-Names="Verdana" Font-Size="18px" />
                        </td>
                        <td align="center" style="text-align: center">
                            <asp:Button ID="BtnDelete" runat="server"
                                CssClass="btn btn-danger" Height="105px" OnClick="BtnDelete_Click" TabIndex="10"
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
                    <tr id="trnewinc" runat="server" visible="true">

                        <td align="center" style="text-align: center" width="470px">
                            <asp:Button ID="Renewals" runat="server" CssClass="btn btn-success"
                                Height="105px" OnClick="Renewals_Click" TabIndex="10" Text="RENEWALS"
                                ValidationGroup="group" Width="268px" Font-Bold="True"
                                Font-Names="Verdana" Font-Size="18px" />
                        </td>
                        <td align="center" style="text-align: center">
    <asp:Button ID="btnttap" runat="server"
        CssClass="btn btn-warning" Height="91px" TabIndex="10" Width="268px"
        Text="TTAP-INCENTIVE" Font-Bold="True"
        ValidationGroup="group" Font-Names="Verdana" Font-Size="18px" OnClick="btnttap_Click" />
</td>
                       
                        <td align="center" style="text-align: center">&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td align="center" style="text-align: center" width="470px">&nbsp;</td>
                        <td align="center" style="text-align: center">&nbsp;</td>

                    </tr>

                    <tr>
                         <td align="center" style="text-align: center">
     <asp:Button ID="btnincentivenew" runat="server"
         CssClass="btn btn-warning" Height="91px" TabIndex="10" Width="268px"
         Text="INCENTIVE" Font-Bold="True"
         ValidationGroup="group" Font-Names="Verdana" Font-Size="18px" OnClick="btnincentivenew_Click" />

 </td>
                        <td>&nbsp;</td>

                    </tr>
                    <%--  <tr>
                        <td align="center" style="text-align: center">
                            <asp:Button ID="Incentivesreport" runat="server" CssClass="btn btn-info"
                                Height="91px" TabIndex="10" Text="Incentive Reports"
                                ValidationGroup="group" Width="268px" Font-Bold="True"
                                Font-Names="Verdana" Font-Size="18px" OnClick="Incentivesreport_Click" />

                        </td>
                        <td align="center" style="text-align: center">
                            &nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>--%>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>


