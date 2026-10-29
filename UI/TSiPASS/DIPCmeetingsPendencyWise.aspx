<%@ Page Language="C#"MasterPageFile="~/UI/TSIPASS/CCMaster.master"  AutoEventWireup="true" CodeFile="DIPCmeetingsPendencyWise.aspx.cs" Inherits="UI_TSiPASS_DIPCmeetingsPendencyWise" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <%--<script language="javascript" type="text/javascript">
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



            //:nth-child(1)):not(:nth-child(2))
            $("[id$=grdDetails] tbody tr:not(:last)").each(function () {
                $(this).find("td:eq(2)").addClass('green');
                $(this).find("td:eq(3)").addClass('green');
                $(this).find("td:eq(4)").addClass('green');
                $(this).find("td:eq(5)").addClass('green');
                $(this).find("td:eq(6)").addClass('green');
                $(this).find("td:eq(7)").addClass('green');
                //$(this).find("td:eq(8)").addClass('green');
                //$(this).find("td:eq(9)").addClass('green');


                $(this).find("td:eq(17)").addClass('green');
                $(this).find("td:eq(18)").addClass('green');
                $(this).find("td:eq(19)").addClass('green');
                $(this).find("td:eq(14)").addClass('green');
                $(this).find("td:eq(15)").addClass('green');
                $(this).find("td:eq(16)").addClass('green');
                //$(this).find("td:eq(23)").addClass('green');
            });

        });

    </script>--%>
    <style>
        .algnCenter
        {
            text-align: right;
        }
        
        .yellow
        {
            background-color: yellow !important;
        }
        
        .green
        {
            background-color: #ceffee !important;
        }
    </style>
    <div class="col-lg-12">
        <div class="panel panel-default">
            <div class="panel-heading" align="center">
                <h2 class="panel-title" style="font-weight: bold;">
                    <%--Status of Implementation - Pendency--%>
                    <%-- <a id="Button2" href="#" onclick="javascript:return Panel1();"
                                runat="server">--%>
                    <%--<a id="A2" href="#" onserverclick="BtnSave2_Click" runat="server">
                        <img src="../../Resource/Images/Excel-icon.png" width="20px;" height="20px;" style="float: right;"
                            alt="Excel" /></a> <a id="pdfPrint" href="#" onclick="javascript:return Panel1();"
                                runat="server">
                                <img src="../../Resource/Images/pdf-printer-icon.jpg" alt="PDF" width="30px;" height="30px;"
                                    style="float: right;" /></a>--%>
                </h2>
            </div>
            <div class="panel-body">
                <table align="center" cellpadding="10" cellspacing="5" style="width: 50%; font-family: 'Trebuchet MS'">
                                       
                    <tr align="center">
                        <td colspan="3">
                          <asp:Label runat="server">
                              <h3>DIPC MEETINGS CONDUCTED </h3>
                          </asp:Label>  
                        </td>
                    </tr>
                    <tr style="height: 30px" runat="server" visible="true">
                        <td align="center">
                                                                <table style="width: 50%">
                                        <tr id="trappstype" runat="server" visible="true">
                                             <td align="center" style="text-align: left ; width:100px" valign="middle">
                                                Financial Year
                                            </td>
                                            <td>
                                                :
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="ddlfinyear" runat="server" class="form-control txtbox"
                                                    Height="33px" Width="180px" TabIndex="1">
                                                    <asp:ListItem  value="2017" Text="2017-2018"></asp:ListItem>
                                                    <asp:ListItem  value="2018" Text="2018-2019"></asp:ListItem>
                                                    <asp:ListItem  value="2019" Text="2019-2020"></asp:ListItem>
                                                    <asp:ListItem  value="2020" Text="2020-2021"></asp:ListItem>
                                                    <asp:ListItem  value="2021" Text="2021-2022"></asp:ListItem>
                                                    <asp:ListItem  value="2022" Text="2022-2023"></asp:ListItem>
                                                    <asp:ListItem  value="2023" Text="2023-2024"></asp:ListItem>
                                                     <asp:ListItem  value="2024" Text="2024-2025"></asp:ListItem>
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
                                                <%--<asp:Label ID="lblMsg0" runat="server" Font-Bold="True" Font-Names="verdana" Font-Size="13px"
                                                    ForeColor="#006600"></asp:Label>--%>
                                            </td>
                                        </tr>
                                    </table>

                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" align="center" style="padding: 5px; margin: 5px" id="divPrint" runat="server">
                            <asp:GridView ID="grdDetails" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                OnRowDataBound="grdDetails_RowDataBound" Width="100%" ShowFooter="True" OnRowCreated="grdDetails_RowCreated">
                                <HeaderStyle ForeColor="#FFFFFF" BackColor="#009688" Height="40px" CssClass="GridviewScrollC1HeaderWrap" />
                                <RowStyle Height="40px" CssClass="GridviewScrollC1Item" />
                                <PagerStyle CssClass="GridviewScrollC1Pager" />
                                <FooterStyle ForeColor="#FFFFFF" BackColor="#009688" Height="40px" CssClass="GridviewScrollC1Footer" />
                                <AlternatingRowStyle Height="40px" CssClass="GridviewScrollC1Item2" />
                                <Columns>
                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Sl.No">
                                                <ItemTemplate>
                                                    <%# Container.DataItemIndex +1 %>
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <ItemStyle Width="20px" />
                                            </asp:TemplateField> 
                                    <asp:BoundField DataField="DISTRICTNAME" HeaderText="District Name"></asp:BoundField>
                               
                                    <asp:HyperLinkField ItemStyle-HorizontalAlign="Center" HeaderText="No.of Meetings"
                                        DataTextField="NOofMeetings">
                                        <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
                                        <ItemStyle Font-Underline="false" HorizontalAlign="Center" CssClass="text-center" />
                                    </asp:HyperLinkField>
                                    <asp:HyperLinkField ItemStyle-HorizontalAlign="Center" HeaderText="Within Timelines"
                                        DataTextField="WITHIN_SLC">
                                        <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
                                        <ItemStyle Font-Underline="false" HorizontalAlign="Center" CssClass="text-center" />
                                    </asp:HyperLinkField>
                                    <asp:HyperLinkField ItemStyle-HorizontalAlign="Center" HeaderText="Beyond Timelines"
                                        DataTextField="BEYOND_SLC">
                                        <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
                                        <ItemStyle Font-Underline="false" HorizontalAlign="Center" CssClass="text-center" />
                                    </asp:HyperLinkField>
                                    <asp:HyperLinkField ItemStyle-HorizontalAlign="Center" HeaderText="Within Timelines"
                                        DataTextField="WITHIN_DLC">
                                        <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
                                        <ItemStyle Font-Underline="false" HorizontalAlign="Center" CssClass="text-center" />
                                    </asp:HyperLinkField>
                                    <asp:HyperLinkField ItemStyle-HorizontalAlign="Center" HeaderText="Beyond Timelines"
                                        DataTextField="BEYOND_DLC">
                                        <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
                                        <ItemStyle Font-Underline="false" HorizontalAlign="Center" CssClass="text-center" />
                                    </asp:HyperLinkField>
                                    <asp:HyperLinkField ItemStyle-HorizontalAlign="Center" HeaderText="Within Timelines"
                                        DataTextField="WITHINNEW">
                                        <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
                                        <ItemStyle Font-Underline="false" HorizontalAlign="Center" CssClass="text-center" />
                                    </asp:HyperLinkField>
                                    
                                    <asp:HyperLinkField ItemStyle-HorizontalAlign="Center" HeaderText="Beyond Timelines"
                                        DataTextField="BEYOND">
                                        <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
                                        <ItemStyle Font-Underline="false" HorizontalAlign="Center" CssClass="text-center" />
                                    </asp:HyperLinkField>
                                   <asp:TemplateField  Visible="false" HeaderStyle-HorizontalAlign="Center" HeaderText="S.No">
                                    <ItemTemplate>                                       
                                        <asp:Label ID="DISTID" runat="server" Text='<%# Eval("DISTID") %>' Visible="false"></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                    <%--<asp:HyperLinkField ItemStyle-HorizontalAlign="Center" HeaderText="Beyond Timelines"
                                        DataTextField="ZEROTOSIX_INI">
                                        <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
                                        <ItemStyle Font-Underline="false" HorizontalAlign="Center" CssClass="text-center" />
                                    </asp:HyperLinkField>
                                                         --%>            
                                   
                                </Columns>
                            </asp:GridView>
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </div>
</asp:Content>
