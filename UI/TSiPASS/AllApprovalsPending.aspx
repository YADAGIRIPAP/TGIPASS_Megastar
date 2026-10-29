<%@ Page Title="" Language="C#" MasterPageFile="~/UI/TSIPASS/CCMaster.master" AutoEventWireup="true" CodeFile="AllApprovalsPending.aspx.cs" 
    Inherits="UI_TSIPASS_AllApprovalsPending" EnableEventValidation="false"  %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script language="javascript" type="text/javascript">
        function Panel1() {

            var panel = document.getElementById("<%=divPrint.ClientID %>");
            var printWindow = window.open('', '', 'height=400,width=800');
            printWindow.document.write('<html><head><h3 style="width: 100%;text-align: center;">Government of Telangana</h3>');

            printWindow.document.write('</head><body style="width: 100%;text-align: center;">');
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
        .width {
            width: 100%;
        }
    </style>
    <table id="divPrint" runat="server" border="0" cellpadding="0" cellspacing="0" style="width: 100%;">
        <tr>
            <td style="padding-top: 10px; padding-bottom: 20px; padding-left: 9px; height: 675px;"
                valign="top" align="center">
                <div class="panel panel-default" style="font-family: Helvetica Neue, Helvetica, Arial, sans-serif; font-size: 16px; line-height: 1.42857143;">
                    <div class="panel-heading" style="text-align: center">
                        <h3 visible="false" id="Government" runat="server" class="panel-title" style="font-weight: bold;">Government of Telangana</h3>
                        <h2 class="panel-title" style="font-weight: bold;">
                            <asp:Label ID="lblHeading" runat="server"> TSiPASS PENDENCY REPORT</asp:Label>
                            &nbsp;<%--<a id="Button1" href="#" onserverclick="BtnSave2_Click" runat="server">
                                        <img src="../../Resource/Images/Excel-icon.png" width="20px;" height="20px;" style="float: right;"
                                            alt="Excel" /></a>--%><a id="A2" href="#" onserverclick="BtnSave2_Click" runat="server"><img src="../../Resource/Images/Excel-icon.png" width="20px;" height="20px;" style="float: right;"
                                                alt="Excel" /></a>
                        </h2>
                    </div>
                    <div class="panel-body">
                        <table align="center" class="width" cellspacing="5" style="font-family: 'Trebuchet MS';">


                            <tr runat="server" id="div_Print">
                                <td colspan="2" style="padding: 5px;" valign="top">
                                    <table style="width: 100%;">
                                        <tr>
                                            <td colspan="2" style="padding: 10px; margin: 5px; text-align: center; font-weight: bold;">
                                                <asp:Label ID="Label12" Font-Size="Large" runat="server">PENDENCY REPORT</asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2" style="padding: 10px; margin: 5px; text-align: right; font-weight: bold;">
                                                <asp:Button ID="btnbdf" runat="server" CssClass="btn btn-primary" Height="32px" TabIndex="10" Text="Generate Pdf" OnClick="btnbdf_Click" />
                                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2" style="padding: 10px; margin: 5px; text-align: center; font-weight: bold;">
                                                <asp:Label ID="Label1" runat="server" CssClass="LBLBLACK"></asp:Label>
                                            </td>
                                        </tr>

                                        <tr>
                                            <td colspan="2" style="padding: 5px;" valign="top">
                                           

                                                <asp:GridView ID="grdDetails" CssClass="floatingTable" runat="server" AutoGenerateColumns="false" CellPadding="5"
                                                    ShowFooter="false" Width="100%">
                                                    <HeaderStyle ForeColor="#FFFFFF" BackColor="#009688" Height="50px" CssClass="GridviewScrollC1HeaderWrap" Font-Bold="true" />
                                                    <RowStyle Height="40px" CssClass="GridviewScrollC1Item" />
                                                    <PagerStyle CssClass="GridviewScrollC1Pager" />
                                                    <FooterStyle ForeColor="#FFFFFF" BackColor="#009688" Height="40px" CssClass="GridviewScrollC1Footer" />
                                                    <AlternatingRowStyle Height="40px" CssClass="GridviewScrollC1Item2" />

                                                    <RowStyle Wrap="true" />
                                                    <Columns>
                                                        <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S.No">
                                                            <ItemTemplate>
                                                                <%# Container.DataItemIndex +1 %>
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                        </asp:TemplateField>
                                                        <asp:BoundField DataField="Name of the Industry" HeaderText="Name of the Industry">
                                                            <ItemStyle HorizontalAlign="Left" Width="20%" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="Name of Department" HeaderText="Name of Department">
                                                            <ItemStyle HorizontalAlign="Left" Width="20%" />
                                                        </asp:BoundField>
                                                          <asp:BoundField DataField="Type of Approval" HeaderText="Type of Approval">
                                                              <ItemStyle HorizontalAlign="Left" Width="20%" />
                                                          </asp:BoundField>
                                                        <asp:BoundField DataField="Date of application" HeaderText="Date of application">
                                                            <ItemStyle HorizontalAlign="Left" Width="6%" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="Date of Query" HeaderText="Date of Query">
                                                             <ItemStyle HorizontalAlign="Left" Width="6%" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="Date of Response" HeaderText="Date of Response">
                                                             <ItemStyle HorizontalAlign="Left" Width="6%" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="Date of Pre-scrutiny" HeaderText="Date of Pre-scrutiny">
                                                             <ItemStyle HorizontalAlign="Left" Width="6%" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="Target Date" HeaderText="Target Date">
                                                             <ItemStyle HorizontalAlign="Left" Width="6%" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="STATUS" HeaderText="STATUS">
                                                             <ItemStyle HorizontalAlign="Left" Width="6%" />
                                                        </asp:BoundField>
                                                    </Columns>
                                                </asp:GridView>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr id="Tr1" runat="server">
                                <td colspan="2" class="col-xs-5" style="padding: 5px; text-align: right; margin: 5px">
                                    <asp:Label ID="Label2" runat="server" CssClass="LBLBLACK"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2" class="col-xs-5" style="padding: 5px; text-align: right; margin: 5px">

                                    <div id="success" runat="server" visible="false" class="alert alert-success">
                                        <a href="AddQualification.aspx" class="close" data-dismiss="alert" aria-label="close">&times;</a>
                                        <strong>Success!</strong><asp:Label ID="lblmsg" runat="server"></asp:Label>
                                    </div>


                                    <div id="Failure" runat="server" visible="false" class="alert alert-danger">
                                        <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a>
                                        <strong>Warning!</strong>
                                        <asp:Label ID="lblError" runat="server"></asp:Label>
                                    </div>
                                </td>

                            </tr>
                            <%--<tr>
                                <td align="center" style="padding: 5px; margin: 5px">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td class="col-xs-5" style="padding: 5px; text-align: center; margin: 5px">
                                   
 <asp:Label ID="Label2" Font-Bold="true" runat="server" CssClass="LBLBLACK">IMPLEMENTATION STATUS</asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="center" style="padding: 5px; margin: 5px">
                                    <asp:GridView ID="grdDetails" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                        Width="100%" ShowFooter="false">
                                        <HeaderStyle ForeColor="#FFFFFF" BackColor="#009688" Height="40px" CssClass="GridviewScrollC1HeaderWrap" />
                                        <RowStyle Height="40px" CssClass="GridviewScrollC1Item" />
                                        <PagerStyle CssClass="GridviewScrollC1Pager" />
                                        <FooterStyle ForeColor="#FFFFFF" BackColor="#009688" Height="40px" CssClass="GridviewScrollC1Footer" />
                                        <AlternatingRowStyle Height="40px" CssClass="GridviewScrollC1Item2" />
                                        <Columns>
                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S.No">
                                                <ItemTemplate>
                                                    <%# Container.DataItemIndex +1 %>
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Center" />
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="Progress" HeaderText="Stages of Implementation"></asp:BoundField>
                                            <asp:BoundField DataField="Number" HeaderText="Number of Industries">
                                                <ItemStyle Font-Bold="true" HorizontalAlign="Center" CssClass="text-right" />
                                            </asp:BoundField>
                                        </Columns>
                                    </asp:GridView>
                                </td>
                            </tr>--%>
                            <%--<tr>
                                <td align="center" style="padding: 5px; margin: 5px">
                                    <div>

                                        <script type="text/javascript" src="../../js/googleapi.js"></script>

                                        <asp:Literal ID="ltrPie" runat="server"></asp:Literal>
                                        <div id="piechart_3d" style="border-style: solid; border-width: 1px; width: 100%;
                                            height: 500px;">
                                        </div>
                                    </div>
                                </td>
                            </tr>--%>
                            <tr>
                                <td align="center" style="padding: 5px; margin: 5px">&nbsp;
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
            </td>
        </tr>
    </table>
</asp:Content>

