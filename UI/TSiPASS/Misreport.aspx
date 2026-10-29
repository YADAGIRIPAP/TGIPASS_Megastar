<%@ Page Title="" Language="C#" MasterPageFile="~/UI/TSiPASS/EmptyMaster.master" AutoEventWireup="true" CodeFile="Misreport.aspx.cs" Inherits="UI_TSiPASS_Misreport" %>

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
            <td style="padding-top: 10px; padding-bottom: 20px; padding-left: 9px; height: 675px;"
                valign="top" align="center">
                <table style="width: 100%" cellpadding="10" cellspacing="10">
                <tr>
                <td colspan="3">
                  <div align="left">
                <ol class="breadcrumb">
                    You are here &nbsp;!&nbsp; &nbsp; &nbsp;
                    <li><i></i><a href="Home.aspx">Home</a></li>
                    <%--<li class=""><i class="fa fa-fw fa-edit">CFE</i> </li>--%>
                    <li class="active"><i ></i>MIS Reports
                    </li>
                </ol>
            </div>
                </td>
                </tr>
                    <tr>
                        <td style="height: 30px" colspan="3">
                            <asp:Label ID="Label437" runat="server" CssClass="LBLBLACK" Font-Bold="True" Font-Names="Verdana"
                                Width="210px">MIS REPORTS</asp:Label>
                        </td>
                       
                    </tr>                    
                    
                    <tr id="trcfe" runat="server" visible="true">
                        <td align="center" style="text-align: center">
                            <asp:Button ID="btncfemis" runat="server" CssClass="btn btn-primary" Height="91px"
                                TabIndex="10" Text="TS-iPASS" ValidationGroup="group" Width="450px"
                                Font-Bold="True" Font-Names="Verdana" Font-Size="18px" OnClick="btncfemis_Click" />
                        </td>
                        <td>
                        </td>
                        <td align="center" style="text-align: center">
                            <asp:Button ID="btnglanceReport" runat="server" CssClass="btn btn-danger" Height="91px"
                                TabIndex="10" Text="Glance Report" Font-Bold="True" Width="450px" ValidationGroup="group"
                                Font-Names="Verdana" Font-Size="18px" OnClick="btnglanceReport_Click" />
                        </td>
                    </tr>   
                    <tr>
                    <td style="height:15px">
                    </td>
                    </tr>                 
                   <tr id="tr1" runat="server" visible="true">
                        <td align="center" style="text-align: center">
                            <asp:Button ID="btnfinancial" runat="server" CssClass="btn btn-primary" Height="91px"
                                TabIndex="10" Text="Financial Year Abstract" ValidationGroup="group" Width="450px"
                                Font-Bold="True" Font-Names="Verdana" Font-Size="18px" OnClick="btnfinancial_Click" />
                        </td>
                        <td>
                        </td>
                        <td align="center" style="text-align: center">
                            <asp:Button ID="btnsector" runat="server" CssClass="btn btn-danger" Height="91px"
                                TabIndex="10" Text="Sector Wise Report" Font-Bold="True" Width="450px" ValidationGroup="group"
                                Font-Names="Verdana" Font-Size="18px" OnClick="btnsector_Click" />
                        </td>
                    </tr> 
                </table>
            </td>
        </tr>
    </table>
</asp:Content>

