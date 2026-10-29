<%@ Page Title="" Language="C#" MasterPageFile="~/UI/TSIPASS/CCMaster.master" AutoEventWireup="true" CodeFile="frmdipcmeetings.aspx.cs" Inherits="UI_TSIPASS_frmdipcmeetings" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
         <script language="javascript" type="text/javascript">
             function Panel1() {
                 document.getElementById('<%=btnGet.ClientID %>').style.display = "none";


             var panel = document.getElementById("<%=divPrint.ClientID %>");
             var printWindow = window.open('', '', 'height=400,width=800');
             printWindow.document.write('<html><head><h3 style="width: 100%;text-align: center;">Government of Telangana</h3>');

             printWindow.document.write('</head><body >');
             printWindow.document.write(panel.innerHTML);
             printWindow.document.write('</body></html>');
             printWindow.document.close();

             setTimeout(function () {
                 printWindow.print();
                 location.reload(true);
                 printWindow.close();
             }, 1000);
             return false;

         }

         $(function () {

             $('#MstLftMenu').remove();

         });

    </script>

    <style>
        .algnCenter {
            text-align: right;

        }
        
        .yellow {
            background-color:yellow !important;
        }

        .green {
            background-color:#ceffee !important;
        }
    </style>
    <div class="col-lg-12">
        <div class="panel panel-default">
            <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
                <tr>
                    <td colspan="4">
                        <div class="panel-heading" align="center">
                            <h2 class="panel-title" style="font-weight: bold;"> DIPC Meetings
                                <a id="A2" href="#" onserverclick="BtnSave2_Click" runat="server">
                                    <img src="../../Resource/Images/Excel-icon.png" width="20px;" height="20px;" style="float: right;"
                                        alt="Excel" /></a> </h2>
                        </div>

                    </td>
                </tr>
                <tr>
                    <td style="text-align: left">
                        <asp:HyperLink CssClass="btn btn-link" ID="HyperLink1" runat="server" Visible="false" NavigateUrl="~/UI/TSiPASS/IncentiveReportsDashboard.aspx" Text="<<  VI">
                        </asp:HyperLink>
                    </td>
                </tr>
                <tr align="center">
                    <td colspan="3">
                         <table style="width: 80%">
                                       <tr id="Tr1" runat="server" >
                                <td align="center" style="padding: 5px; margin: 5px">
                                    <table style="width: 50%">
                                        <tr id="trappstype" runat="server" visible="true">
                                             <td align="center" style="text-align: left ; width:100px" valign="middle">
                                                Financial Year
                                            </td>
                                            <td>
                                                :
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="ddlConnectLoad" runat="server" class="form-control txtbox"
                                                    Height="33px" Width="180px" TabIndex="1">
                                                    <asp:ListItem  value="2017" Text="2017-2018"></asp:ListItem>
                                                    <asp:ListItem  value="2018" Text="2018-2019"></asp:ListItem>
                                                    <asp:ListItem  value="2019" Text="2019-2020"></asp:ListItem>
                                                    <asp:ListItem  value="2020" Text="2020-2021"></asp:ListItem>
                                                    <asp:ListItem  value="2021" Text="2021-2022"></asp:ListItem>
                                                    <asp:ListItem  value="2022" Text="2022-2023"></asp:ListItem>
                                                    <asp:ListItem  value="2023" Text="2023-2024"></asp:ListItem>
                                                     <asp:ListItem  value="2024" Text="2024-2025" ></asp:ListItem>
                                                     <asp:ListItem  value="2025" Text="2025-2026" Selected="True"></asp:ListItem>
                                                </asp:DropDownList>
                                            </td>

                                        </tr>
                                     
                                        <tr style="height:60px">
                                            <td colspan="10" align="center" valign="bottom">
                                                <asp:Button ID="btnGet" runat="server" CssClass="btn btn-primary" Height="32px" TabIndex="10" Text="Generate Report" Width="180px" OnClick="btnGet_Click" />
                                            </td>
                                        </tr>
                                           <tr>
                                            <td colspan="10" align="center">
                                                <asp:Label ID="lblMsg0" runat="server" Font-Bold="True" Font-Names="verdana" Font-Size="13px"
                                                    ForeColor="#006600"></asp:Label>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </td>


                </tr>
                <tr style="height: 30px">

                    <td align="right">
                        <asp:Button ID="btnbdf" runat="server" CssClass="btn btn-primary" Height="32px" TabIndex="10" Text="Generate Pdf" OnClick="btnbdf_Click" />
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    </td>

                </tr>
                <tr>
                    <td colspan="2" align="center" style="padding: 5px; margin: 5px" id="divPrint" runat="server">
                        <asp:GridView ID="grdDetails" runat="server" AutoGenerateColumns="False" CellPadding="4"
                            OnRowDataBound="grdDetails_RowDataBound" Width="40%" CssClass="floatingTable"
                            ShowFooter="True" >
                            <HeaderStyle ForeColor="#FFFFFF" BackColor="#009688" Height="40px" CssClass="GridviewScrollC1HeaderWrap" />
                            <RowStyle Height="40px" CssClass="GridviewScrollC1Item" />
                            <PagerStyle CssClass="GridviewScrollC1Pager" />
                            <FooterStyle ForeColor="#FFFFFF" BackColor="#009688" Height="40px" CssClass="GridviewScrollC1Footer" />
                            <AlternatingRowStyle Height="40px" CssClass="GridviewScrollC1Item2" />
                            <Columns>
                                <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S.No">
                                    <ItemTemplate>
                                        <%# Container.DataItemIndex +1 %>
                                        <asp:Label ID="lblDISTID" runat="server" Text='<%# Eval("DISTID") %>' Visible="false"></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                 <asp:BoundField DataField="DISTNAME" HeaderText="District Name"></asp:BoundField>
                                <asp:HyperLinkField ItemStyle-HorizontalAlign="Center" HeaderText="No. of Meetings"
                                    DataTextField="NOofMeetings">
                                    <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
                                    <ItemStyle Font-Underline="false" HorizontalAlign="Center" CssClass="text-center" />
                                </asp:HyperLinkField>
                                <asp:BoundField DataField="DIPCPendingList" HeaderText="DIPC Pending"></asp:BoundField>
                            </Columns>
                        </asp:GridView>
                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>

