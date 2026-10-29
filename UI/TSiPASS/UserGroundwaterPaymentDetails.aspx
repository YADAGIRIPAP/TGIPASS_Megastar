<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UserGroundwaterPaymentDetails.aspx.cs" Inherits="UI_TSiPASS_UserGroundwaterPaymentDetails" %>

<!DOCTYPE html>


<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>::TS-IPASS::</title>
    <script type="text/javascript">
        function CallPrint(strid) {
            var prtContent = document.getElementById(strid);
            var WinPrint = window.open('', '', 'left=0,top=0,width=0,height=0,toolbar=0,scrollbars=1,status=0');
            var strOldOne = prtContent.innerHTML;
            WinPrint.document.write(prtContent.innerHTML);
            WinPrint.document.close();
            WinPrint.focus();
            WinPrint.print();
            WinPrint.close();
            prtContent.innerHTML = strOldOne;
        }
    </script>
    <style type="text/css">
        .auto-style1 {
            height: 150px;
        }

        .auto-style2 {
            width: 326px;
        }

        .auto-style4 {
            height: 139px;
        }

        .auto-style5 {
            height: 110px;
        }

        .auto-style6 {
            height: 34px;
        }

        .auto-style7 {
            height: 35px;
        }

        .auto-style8 {
            height: 36px;
        }

        .auto-style9 {
            height: 26px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
       <div>
            <table align="center">
                <tr>
                    <td>
                        <div id="Receipt" runat="server" style="width: 630px;">
                            <table style="width: 630px;">
                                <tr>
                                    <td class="auto-style9">
                                        <table border="1" align="center" cellpadding="1" cellspacing="2" style="border-color: Black; width: 630px;" id="divPrint">
                                            <tr>
                                                <td colspan="4" align="center" class="auto-style4">
                                                    <img src="../../Resource/Images/telanganalogo.png" height="60px" width="60px" />
                                                    <br />
                                                    <div>
                                                        <font size="2"><strong style="font-family: Arial"> <h3>Telangana State Industrial Project Approval
                            <br />
                            & Self Certification System ( TSiPASS )
                        <br /><br />
                            GOVERNMENT OF TELANGANA</h3> </strong></font>
                                                    </div>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="4" align="center" class="auto-style8">
                                                    <strong style="font-weight: bold" class="tdStyle">
                                                        <h3>ACKNOWLEDGEMENT</h3>
                                                    </strong></td>
                                            </tr>
                                            <tr>
                                                <td colspan="2" align="left" class="auto-style9">&nbsp;&nbsp;UID No :&nbsp;<asp:Label ID="lbluidno" runat="server" Font-Bold="true"></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td colspan="2" class="auto-style6">&nbsp;&nbsp;&nbsp;&nbsp;This is to acknowledge the receipt of application of M/s.
                        <asp:Label ID="lblunitname" Font-Bold="true" runat="server"></asp:Label>, 
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2" class="auto-style7">&nbsp;&nbsp;&nbsp;&nbsp;Sy.No.
                        <asp:Label ID="lbladdress" runat="server" Font-Bold="true"></asp:Label>, (v),
                        <asp:Label ID="lblvillage" runat="server" Font-Bold="true"></asp:Label>, (m),
                        <asp:Label ID="lblmandal" runat="server" Font-Bold="true"></asp:Label>, district for following approvals.</td>
                                            </tr>
                                            <tr style="height:20px">
                                                <td>

                                                </td>
                                            </tr>
                                            <tr>
                                                <td valign="middle" class="auto-style1" align="center">

                                                    <asp:GridView ID="gvdata" runat="server" AutoGenerateColumns="false">
                                                     <Columns>
                                                                <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S.No">
                                                                    <ItemTemplate>
                                                                        <%# Container.DataItemIndex + 1%>
                                                                        <asp:HiddenField ID="HdfQueid" runat="server" />
                                                                        <asp:HiddenField ID="HdfApprovalid" runat="server" />
                                                                    </ItemTemplate>
                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                </asp:TemplateField>
                                                                <asp:BoundField DataField="Approval Name" ItemStyle-HorizontalAlign="left" HeaderText="Name of Approval"></asp:BoundField>
                                                               
                                                                <asp:BoundField DataField="Approval_Fee" ItemStyle-HorizontalAlign="Right" HeaderText="Fee Paid">
                                                                      <ItemStyle HorizontalAlign="Right"></ItemStyle>
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="Transaction No" ItemStyle-HorizontalAlign="left" HeaderText="Transaction No"></asp:BoundField>
                                                                <asp:BoundField DataField="Date of Payment" ItemStyle-HorizontalAlign="left" HeaderText="Transaction Date"></asp:BoundField>
                                                            </Columns>
                                                    </asp:GridView>

                                                </td>
                                            </tr>
                                            <tr style="height:30px">
                                                <td>

                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="4" align="left" class="auto-style5">
                                                    <table style="width: 100%">
                                                        <tr>
                                                            <td class="auto-style2">Date : &nbsp;&nbsp;&nbsp; 
                                                                <asp:Label ID="lblnum2wrds" Font-Bold="true" runat="server" Visible="true" Text=""></asp:Label>
                                                            </td>
                                                            <td align="center">Commissioner of Industries
                                                                <br />
                                                                Hyderbad
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr style="height:20px">
                                                <td style="font-weight:bold">
                                                    Note : Please Contact 040-23441636 For Any Clarifications.
                                                </td>
                                            </tr>

                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </td>
                </tr>
            </table>
            <br />
            <table border="0" align="center" cellpadding="1" cellspacing="2" style="width: 595px">
                <tr>
                    <td align="center" colspan="4">
                        <asp:Button ID="btnclose" runat="server" CssClass="NoPrint" PostBackUrl="~/UI/TSiPASS/HomeDashboard.aspx" Visible="false"
                            Text="Close" OnClick="btnclose_Click" />
                        &nbsp;&nbsp;
                    <asp:Button ID="btnprint" runat="server" CssClass="NoPrint" Text=" Print " OnClientClick="javascript:CallPrint('divPrint')" />
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
