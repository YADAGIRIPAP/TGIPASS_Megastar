<%@ Page Title="" Language="C#" MasterPageFile="~/UI/TSiPASS/CCMaster.master" AutoEventWireup="true" CodeFile="DistrictWiseApprovedDrillDown.aspx.cs" Inherits="UI_TSiPASS_DistrictWiseApprovedDrillDown" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <style type="text/css">
        .FixedHeader {
            position: absolute;
            font-weight: bold;
        }
    </style>
    <script language="javascript" type="text/javascript">
        $(function () {

            $('#MstLftMenu').remove();

        });
    </script>
    <script type="text/javascript" language="javascript">

        function OpenPopup() {

            window.open("Lookups/LookupBDC.aspx", "List", "scrollbars=yes,resizable=yes,width=1500,height=950;display = block;position=absolute");


            return false;
        }
    </script>
    <script type="text/javascript" language="javascript">
        var win = new Object();
        function Popup(intval) {

            win = window.open("ApplicationTrakerDetailed.aspx?UID=" + intval, "List", "scrollbars=yes,resizable=yes,width=780,height=400,left=" + ((window.screen.width / 2) - 320) + ",top=" + ((window.screen.height / 2) - 200) + ";display : block;position:absolute");
            //win = window.open("RptVillageOraganisationNameClickDetails.aspx?id="+intval, "List", "scrollbars=yes,resizable=yes,width=600,height=400,left=" + ((window.screen.width / 2) - 320) + ",top=" + ((window.screen.height / 2) - 200) + ";display : block;position:absolute");

        }
    </script>
    <div align="left">
        <div class="row" align="left">
            <div class="col-lg-12">
                <div class="panel panel-default">
                    <div class="panel-heading" style="text-align: center">
                        <h3 visible="false" id="Government" runat="server" class="panel-title" style="font-weight: bold;">Government of Telangana</h3>
                        <h2 id="H1" runat="server" class="panel-title" style="font-weight: bold;">
                            <asp:Label ID="lblHeading" runat="server" CssClass="text-center">R6.14:Approval of Industries District Wise Report</asp:Label>
                             <asp:Label ID="LblGet" runat="server" Visible="false"></asp:Label>
                            <a id="Button2" href="#" onserverclick="Button2_ServerClick" runat="server">
                                <img src="viewpdf.aspx?filepathnew=D:/TS-iPASSFinal/Resource/Images/pdf-icon.png" width="20px;" height="20px;" style="float: right;"
                                    alt="PDF" /></a> &nbsp;<a id="Button1" href="#" onserverclick="Button1_ServerClick" runat="server">
                                        <img src="viewpdf.aspx?filepathnew=D:/TS-iPASSFinal/Resource/Images/Excel-icon.png" width="20px;" height="20px;" style="float: right;"
                                            alt="Excel" /></a>&nbsp; <a id="pdfPrint" href="#" onclick="javascript:return Panel1();"
                                                runat="server">
                                                <img src="viewpdf.aspx?filepathnew=D:/TS-iPASSFinal/Resource/Images/pdf-printer-icon.jpg" alt="PDF" width="30px;" height="30px;"
                                                    style="float: right;" /></a>

                        </h2>
                    </div>   
                   <%--  <div class="panel-heading" align="center">--%>
                         <%--   <h3 class="panel-title" style="text-align: center;">
                                <asp:Label ID="lblHead2" runat="server" CssClass="LBLBLACK" Font-Bold="True" Width="500px" Visible="false"></asp:Label>
                                <h3 visible="false" id="lblForGrid" runat="server" class="panel-title" style="font-weight: bold;"></h3>
                            </h3>--%>
                      <%--  </div>--%>
                    <div class="panel panel-primary">
                        <table align="center" cellpadding="10" cellspacing="5" style="width: 80%; font-family: 'Trebuchet MS'">
                             <tr>
                                    <td>
                                        <table runat="server" id="tblselection" cellpadding="4" cellspacing="5" style="width: 100%">
                                            <tr>
                                                <td class="col-xs-3" style="padding: 5px; margin: 5px">
                                                    <asp:HyperLink CssClass="btn btn-link" ID="HyperLink1" runat="server" NavigateUrl="~/UI/TSiPASS/Districtwiseapproved.aspx"
                                                        Text="<< Back">
                                                    </asp:HyperLink>
                                                </td>
                                                </tr>
                                                </table>                       
                        <br />
                        <%-- <div style="overflow-x: auto; width: 950px; max-height: 300px">--%>
                        <div style="margin-left: 30px">
                        </div>
                        <asp:Label ID="lbllabel" runat="server"></asp:Label>
                        <tr id="GridPrint" runat="server">
                            <td colspan="2" align="center" style="padding: 5px; margin: 5px" id="divPrint1" runat="server">
                                <asp:GridView ID="GrdEntpnrdtls" runat="server" AutoGenerateColumns="true" Width="50%" BorderColor="#003399" BorderStyle="Solid" BorderWidth="1px" ForeColor="#333333"
                                    Style="margin-left: 20px; margin-right: 5px;" AllowSorting="true" CssClass="floatingtable" AllowPaging="false"
                                    HeaderStyle-CssClass="FixedHeader" OnRowDataBound="GrdEntpnrdtls_RowDataBound" OnRowCreated="GrdEntpnrdtls_RowCreated">
                                    <HeaderStyle ForeColor="#FFFFFF" BackColor="#009688" CssClass="GridviewScrollC1HeaderWrap" />
                                    <RowStyle HorizontalAlign="Center" CssClass="GridviewScrollC1Item" />
                                    <Columns>
                                        <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Sl.No">
                                            <ItemTemplate>
                                                <%# Container.DataItemIndex +1 %>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle Width="20px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="View">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="LinkButton1" runat="server" Text='<%# Eval("intQuessionaireid") %>'></asp:LinkButton>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Left" />
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </td>
                        </tr>
                                        
                                        </td>
                                 </tr>
</table>
                    </div>
                    <br />
                </div>
            </div>
        </div>
        <asp:Label ID="Label1" runat="server"></asp:Label>
    </div>
</asp:Content>

