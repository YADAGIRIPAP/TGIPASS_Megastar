<%@ Page Title="" Language="C#" MasterPageFile="~/UI/TSiPASS/CCMaster.master" AutoEventWireup="true" CodeFile="CentralInspection.aspx.cs" Inherits="UI_TSiPASS_CentralInspection" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script type="text/javascript">
        function CallPrint(strid) {
            var prtContent = document.getElementById(strid);
            var WinPrint = window.open('', '', 'letf=0,top=0,width=0,height=0,toolbar=0,scrollbars=1,status=0');
            var strOldOne = prtContent.innerHTML;
            WinPrint.document.write(prtContent.innerHTML);
            WinPrint.document.close();
            WinPrint.focus();
            WinPrint.print();
            WinPrint.close();
            prtContent.innerHTML = strOldOne;
        }
    </script>

    <table width="100%">
        <tr>
            <td align="center" colspan="2" style="height: 15px">
                <asp:Label ID="lblmsg" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="center" colspan="2" style="height: 15px">
                <strong>Central Inspection Service</strong></td>
        </tr>
        <tr>
            <td align="center" colspan="2">
                <fieldset>
                    <table>
                        <tr>
                            <td align="center" colspan="2">
                            </td>
                        </tr>
                    </table>
                </fieldset>
            </td>
        </tr>
        <tr>
        </tr>
        <tr>
            <td align="center" colspan="2"></td>
        </tr>
        <tr align="right">
            <td align="right" colspan="2" width="80%">&nbsp;
            </td>
        </tr>
    </table>
    <div>
        <table width="100%">
            <tr align="center">
                <td align="center" colspan="2">
                    <fieldset>
                        <div id="divPrint">
                            &nbsp;
                        </div>
                    </fieldset>
                </td>
            </tr>
        </table>
    </div>

</asp:Content>

