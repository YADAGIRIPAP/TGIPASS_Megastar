<%@ Page Title="" Language="C#" MasterPageFile="~/UI/TSiPASS/CCMaster.master" AutoEventWireup="true" CodeFile="ReportOnPMEGPSuccessStories.aspx.cs" Inherits="UI_TSiPASS_ReportOnPMEGPSuccessStories" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript">
        //function pageLoad() {
        //    var date = new Date();
        //    var yrRange = "1990:" + (date.getFullYear() + 1);
        //    var currentMonth = date.getMonth();
        //    var currentDate = date.getDate();
        //    var currentYear = date.getFullYear();
            //$("input[id$='txtfrmdate']").datepicker(
            //    {
            //        dateFormat: "dd/mm/yy",
            //        changeMonth: true,
            //        changeYear: true,
            //        yearRange: yrRange,
            //        maxDate: 0
            //    })
            //$("input[id$='txttodate']").datepicker(
            //    {
            //        dateFormat: "yy-mm-dd",
            //        changeMonth: true,
            //        changeYear: true,
            //        yearRange: yrRange,
            //        maxDate: 0
            //    })    
        //}
    </script>
     <script language="javascript" type="text/javascript">
         $(function () {

             $('#MstLftMenu').remove();

         });
     </script>
    <style type="text/css">
    .col-lg-10 {
        width: 1050px;
    }
</style>
    <div align="left">
        <div class="row" align="left">
            <div class="col-lg-8">
                <div class="panel-heading" style="text-align: center">
                            <h3 visible="false" id="Government" runat="server" class="panel-title" style="font-weight: bold;">Government of Telangana</h3>
                            <h2 id="H1" runat="server" class="panel-title" style="font-weight: bold;"><asp:Label ID="lblHeading" runat="server" Visible="false">ReportOnPMEGPSuccessStories Details</asp:Label>
                                <a id="Button2" href="#" onserverclick="Button2_ServerClick"
                                runat="server">
                                <img src="viewpdf.aspx?filepathnew=D:/TS-iPASSFinal/Resource/Images/pdf-icon.png" width="20px;" height="20px;" style="float: right;"
                                    alt="PDF" /></a> <a id="Button1" href="#" onserverclick="Button1_ServerClick" runat="server">
                                        <img src="viewpdf.aspx?filepathnew=D:/TS-iPASSFinal/Resource/Images/Excel-icon.png" width="20px;" height="20px;" style="float: right;"
                                            alt="Excel" /></a></h2>
                        </div>
                  <div>
                      <tr>
                                <td colspan="8" style="width: 883px; height: 25px;">
                                    <asp:HyperLink CssClass="btn btn-link" ID="HyperLink2" runat="server" NavigateUrl="~/UI/TSiPASS/InteractionsReportsDashBoard.aspx"
                                                        Text="<< Back">
                                                    </asp:HyperLink>

                                </td>
                            </tr>
                </div>
                <div class="panel panel-primary">
                    <div class="panel-heading" align="center">
                        <h3 class="panel-title">
                            <asp:Label ID="lblHead2" runat="server" CssClass="LBLBLACK" Font-Bold="True"
                                Width="500px">PMEGP</asp:Label>
                        </h3>
                    </div>
                    <div class="panel-body">
                        <table align="center" cellpadding="10" cellspacing="5" style="width: 90%">
                            <tr>
                                <td colspan="6" align="center" style="text-decoration: underline; padding-bottom:30px">
                                    <asp:Label ID="lblhdng" runat="server" Font-Bold="true" Font-Size="25px"> Report on PMEGP Success Stories</asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <table align="center" cellpadding="10" cellspacing="5">
                                
                                <tr>
                                    <td>
                                        <table align="center" cellpadding="4" cellspacing="5" style="width: 100%;">
                                            <tr>
                                                <td align="right" style="width: 178px; padding-left: 0px">
                                                    <asp:Label ID="lblfromdt" runat="server">FromDate</asp:Label>
                                                </td>
                                                <td style="width: 10px">:</td>
                                                <td style="width: 80px">
                                                    <asp:TextBox ID="txtfrmdate" runat="server" class="form-control" Width="200px" TabIndex="1"></asp:TextBox>
                                                    <cc1:CalendarExtender ID="txtfrmdate_CalendarExtender" runat="server"
                                                        Format="dd-MM-yyyy" PopupButtonID="txtfrmdate" TargetControlID="txtfrmdate">
                                                    </cc1:CalendarExtender>
                                                </td>
                                                <td class="style3" align="right" style="width: 100px">
                                                    <asp:Label ID="lbltodate" runat="server">ToDate</asp:Label>
                                                </td>
                                                <td style="width: 11px">:</td>
                                                <td>

                                                    <asp:TextBox ID="txttodate" runat="server" class="form-control" Width="200px"></asp:TextBox>
                                                    <cc1:CalendarExtender ID="txttodate_CalendarExtender" runat="server"
                                                        Format="dd-MM-yyyy" PopupButtonID="txttodate" TargetControlID="txttodate">
                                                    </cc1:CalendarExtender>
                                                </td>

                                            </tr>
                                            <tr>
                                                <td align="center" style="padding: 5px; padding-left: 100px; margin: 5px; text-align: center; height: 50px" colspan="10">&nbsp;&nbsp;
                                                <asp:Button ID="BtnGetData" runat="server" CssClass="btn btn-primary"
                                                    Height="32px" TabIndex="10" Text="Get Report" ValidationGroup="group"
                                                    Width="120px" OnClick="BtnGetData_Click" />
                                                    &nbsp;
                                            <asp:Button ID="BtnClear" runat="server" CausesValidation="False"
                                                CssClass="btn btn-warning" Height="32px" OnClick="BtnClear_Click" TabIndex="10"
                                                Text="Cancel" ToolTip="To Clear  the Screen" Width="90px" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td><asp:Label ID="Label1" runat="server"></asp:Label></td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="10"></td>
                                </tr>
                            </table>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="10"></td>
                            </tr>
                        </table>
                        <table align="center" cellpadding="10" cellspacing="5" style="width: 70%">
                            <tr>
                                <td colspan="8" style="width: 883px">
                                    <asp:Label ID="lblForGrid" Text="District wise PMEGP Succes Stories" Visible="false" runat="server" Font-Bold="true"></asp:Label>

                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:GridView ID="grdsupport" runat="server" AutoGenerateColumns="false" Width="100%"
                                        BorderColor="#003399" BorderStyle="Solid" BorderWidth="1px" ForeColor="#333333"
                                        CssClass="HeaderFloat" OnRowDataBound="grdsupport_RowDataBound" >
                                        <HeaderStyle ForeColor="#FFFFFF" BackColor="#009688" Height="40px" CssClass="GridviewScrollC1HeaderWrap" />
                                        <RowStyle HorizontalAlign="Center" />
                                          <RowStyle Height="30px" />
                                            <AlternatingRowStyle Height="30px" BackColor="LightGray" />
                                        <Columns>
                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Sl.No">
                                                <ItemTemplate>
                                                    <%# Container.DataItemIndex +1 %>
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <ItemStyle Width="20px" />
                                                <%--Districtid--%>
                                            </asp:TemplateField>
                                            <asp:BoundField HeaderText="District" DataField="District_Name"  />                                            
                                               <asp:HyperLinkField HeaderText="No.of Stories" DataTextField="Storiescount" />
                                            <asp:BoundField HeaderText="District ID" DataField="Districtid" Visible="false" />
                                        </Columns>
                                    </asp:GridView>
                                </td>
                            </tr>
                        </table>

                    </div>

                </div>

            </div>
        </div>

    </div>
</asp:Content>


