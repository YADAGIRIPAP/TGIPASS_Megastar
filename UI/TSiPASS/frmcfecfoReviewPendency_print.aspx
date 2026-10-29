<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/UI/TSiPASS/CCMaster.master" CodeFile="frmcfecfoReviewPendency_print.aspx.cs" Inherits="UI_TSiPASS_frmcfecfoReviewPendency_print" %>


<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript">
        function pageLoad() {
            var date = new Date();
            var yrRange = "2015:" + (date.getFullYear() + 1);

            var currentMonth = date.getMonth();
            var currentDate = date.getDate();
            var currentYear = date.getFullYear();

            $("input[id$='txtFromDate']").datepicker(
                {
                    dateFormat: "dd-mm-yy",
                    changeMonth: true,
                    changeYear: true,
                    yearRange: yrRange

                    //  maxDate: new Date(currentYear, currentMonth, currentDate)
                }); // Will run at every postback/AsyncPostback
            $("input[id$='txtTodate']").datepicker(
                {
                    dateFormat: "dd-mm-yy",
                    changeMonth: true,
                    changeYear: true,
                    yearRange: yrRange

                    //  maxDate: new Date(currentYear, currentMonth, currentDate)
                }); // Will run at every postback/AsyncPostback
        }
        $(function () {
            var date = new Date();
            var yrRange = "2015:" + (date.getFullYear() + 1);
            var currentMonth = date.getMonth();
            var currentDate = date.getDate();
            var currentYear = date.getFullYear();
            $("input[id$='txtFromDate']").datepicker(
                {
                    //dateFormat: "dd/mm/yy",
                    dateFormat: "dd-mm-yy",
                    //maxDate: new Date(currentYear, currentMonth, currentDate)
                    changeMonth: true,
                    changeYear: true,
                    yearRange: yrRange
                });
            $("input[id$='txtTodate']").datepicker(
                {
                    dateFormat: "dd-mm-yy",
                    changeMonth: true,
                    changeYear: true,
                    yearRange: yrRange

                    //  maxDate: new Date(currentYear, currentMonth, currentDate)
                }); // Will run at every postback/AsyncPostback
        });
    </script>

    <div>
        <table id="divPrint" runat="server" border="0" cellpadding="0" cellspacing="0" style="width: 100%">
            <tr>
                <td style="padding-top: 10px; padding-bottom: 20px; padding-left: 9px; height: 675px;"
                    valign="top" align="center">
                    <div class="col-lg-12">
                        <div class="panel panel-default">
                            <div class="panel-heading" style="text-align: center">
                                <h3 visible="false" id="Government" runat="server" class="panel-title" style="font-weight: bold;">Government of Telangana</h3>
                                <h2 id="H1" runat="server" class="panel-title" style="font-weight: bold;">
                                    <asp:Label ID="lblHeading" runat="server">R5.2: Department Wise Pendency for Review Meeting </asp:Label>
                                    <a id="Button2" href="#" onserverclick="Button2_ServerClick1"
                                        runat="server">
                                        <img src="viewpdf.aspx?filepathnew=D:/TS-iPASSFinal/Resource/Images/pdf-icon.jpeg" width="20px;" height="20px;" style="float: right;"
                                            alt="PDF" /></a> <a id="Button1" href="#" onserverclick="Button1_ServerClick1" runat="server">
                                                <img src="viewpdf.aspx?filepathnew=D:/TS-iPASSFinal/Resource/Images/Excel-icon.png" width="20px;" height="20px;" style="float: right;"
                                                    alt="Excel" /></a></h2>
                            </div>
                        </div>
                    </div>
                    <div class="panel-body">
                        <table align="center" cellpadding="10" cellspacing="5" style="width: 80%; font-family: 'Trebuchet MS'">
                            <tr>
                                <td>
                                    <table runat="server" id="tblselection" cellpadding="4" cellspacing="5" style="width: 100%">
                                        <tr>
                                            <%-- <td class="col-xs-3" style="padding: 5px; margin: 5px">
                                                    <asp:HyperLink CssClass="btn btn-link" ID="HyperLink1" runat="server" NavigateUrl="~/UI/TSiPASS/ReportsDashboardNew.aspx"
                                                        Text="<< Back">
                                                    </asp:HyperLink>
                                                </td>--%>

                                            <td style="padding: 5px; margin: 5px" align="center" runat="server" id="tdFromDate">
                                                <div class="input-group">
                                                    <div class="input-group-addon">
                                                        From Date
                                                    </div>
                                                    <asp:TextBox ID="txtFromDate" runat="server" class="form-control txtbox" Height="28px"
                                                        MaxLength="40" onkeypress="NumberOnly()" TabIndex="1" ValidationGroup="group"
                                                        Width="125px"></asp:TextBox>
                                                    <%--<asp:TextBox ID="" runat="server" class="form-control txtbox" Height="28px" MaxLength="40" onkeypress="NumberOnly()" TabIndex="1" ValidationGroup="group" Width="125px"></asp:TextBox>
                                                    <cc1:CalendarExtender ID="CalendarExtender2" runat="server" Format="dd-MM-yyyy" TargetControlID="txtFromDate">
                                                    </cc1:CalendarExtender>--%>
                                                </div>
                                            </td>
                                            <td style="padding: 5px; margin: 5px" runat="server" id="tdToDate">

                                                <div class="input-group">
                                                    <div class="input-group-addon">
                                                        To Date
                                                    </div>
                                                    <asp:TextBox ID="txtTodate" runat="server" class="form-control txtbox" Height="28px"
                                                        MaxLength="40" onkeypress="NumberOnly()" TabIndex="1" ValidationGroup="group"
                                                        Width="125px"></asp:TextBox>
                                                    <%-- <asp:TextBox ID="" runat="server" class="form-control txtbox" Height="28px" MaxLength="40" onkeypress="NumberOnly()" TabIndex="1" ValidationGroup="group" Width="125px"></asp:TextBox>
                                                    <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd-MM-yyyy" TargetControlID="txtTodate">
                                                    </cc1:CalendarExtender>--%>
                                                </div>
                                            </td>
                                            <td class="col-xs-3" style="padding: 5px; margin: 5px">
                                                <div class="input-group">
                                                    <div class="input-group-addon">
                                                        Application
                                                    </div>
                                                    <asp:DropDownList ID="CFO_Dropdown" runat="server" AutoPostBack="true" Height="28px" Width="125px" OnSelectedIndexChanged="CFO_Dropdown_SelectedIndexChanged">
                                                        <asp:ListItem Text="--Select--" Value="0"></asp:ListItem>
                                                        <asp:ListItem Text="CFE" Value="1" Selected="true" ></asp:ListItem>
                                                        <asp:ListItem Text="CFO" Value="2"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </div>
                                            </td>
                                            <td style="padding: 5px; margin: 5px" align="right">
                                                <asp:Button ID="Button3" runat="server" CssClass="btn btn-default" TabIndex="10" Visible="false"
                                                    Text="Submit" OnClick="Button3_Click" />
                                            </td>
                                        </tr>

                                    </table>
                                </td>
                                <td style="padding: 5px; text-align: right; margin: 5px; width: 100%;"></td>
                            </tr>
                            <tr runat="server" id="rptdate">
                                <td colspan="2" class="col-xs-5" style="padding: 5px; text-align: right; margin: 5px">
                                    <asp:Label ID="Label2" runat="server" CssClass="LBLBLACK"></asp:Label>
                                </td>
                            </tr>
                            <tr id="Report" runat="server" visible="false">
                                <td colspan="2" class="col-xs-5" style="padding: 5px; text-align: right; margin: 5px">
                                    <asp:Label ID="Label1" runat="server" CssClass="LBLBLACK">Report as on date</asp:Label>
                                </td>
                            </tr>
                            <%--<tr>
                                    <td colspan="2" class="col-xs-5" style="padding: 5px; text-align: right; margin: 5px">
                                         <asp:Button ID="btnNewPdf" runat="server" CssClass="btn btn-primary" Height="32px" TabIndex="10" Text="Generate Pdf" OnClick="btnNewPdf_Click" />
                                    </td>
                                </tr>--%>
                            <tr id="GridPrint" runat="server">
                                <td colspan="2" align="center" style="padding: 5px; margin: 5px" id="divPrint1" runat="server">
                                    <asp:GridView ID="grdDetails" CssClass="floatingTable" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                        OnRowDataBound="grdDetails_RowDataBound" Width="100%"
                                        ShowFooter="True" OnRowCreated="grdDetails_RowCreated">
                                        <HeaderStyle ForeColor="#FFFFFF" BackColor="#009688" Height="40px" CssClass="GridviewScrollC1HeaderWrap" Font-Bold="true" />
                                        <RowStyle Height="40px" CssClass="GridviewScrollC1Item" HorizontalAlign="Center"  />
                                        <PagerStyle CssClass="GridviewScrollC1Pager" />
                                        <FooterStyle ForeColor="#FFFFFF" BackColor="#009688" Height="40px" CssClass="GridviewScrollC1Footer" />
                                        <AlternatingRowStyle Height="40px" CssClass="GridviewScrollC1Item2" />
                                        <Columns>
                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S.No">
                                                <ItemTemplate>
                                                    <%# Container.DataItemIndex +1 %>
                                                    <%-- <asp:Label ID="lblyear" runat="server" Text='<%# Eval("YEAR") %>' Visible="false"></asp:Label>
                                        <asp:Label ID="lblmonth" runat="server" Text='<%# Eval("MonthCode") %>' Visible="false"></asp:Label>--%>
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Center" />
                                            </asp:TemplateField>
                                            <asp:BoundField HeaderText="DepartmentId" DataField="Dept_Id" Visible="false">
                                                <ItemStyle CssClass="text-center" Font-Bold="true" />
                                            </asp:BoundField>
                                            <asp:BoundField HeaderText="Department" DataField="Department Name">
                                                <ItemStyle CssClass="text-center" />
                                            </asp:BoundField>

                                            <asp:BoundField HeaderText="Approval Id" DataField="ApprovalId" Visible="false">
    <ItemStyle CssClass="text-center" Font-Bold="true" />
</asp:BoundField>
<asp:BoundField HeaderText="Approval Name" DataField="ApprovalName">
    <ItemStyle CssClass="text-center" />
</asp:BoundField>

                                            <asp:HyperLinkField ItemStyle-HorizontalAlign="Center" HeaderText="Before Due Date"
                                                DataTextField="Pending Less than 3 Days">
                                                <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
                                                <ItemStyle Font-Underline="false" HorizontalAlign="Center" CssClass="text-center" />
                                            </asp:HyperLinkField>
                                            <asp:HyperLinkField ItemStyle-HorizontalAlign="Center" HeaderText="After Due Date"
                                                DataTextField="Pending More than 3 Days">
                                                <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
                                                <ItemStyle Font-Underline="false" HorizontalAlign="Center" CssClass="text-center" />
                                            </asp:HyperLinkField>
                                             <asp:HyperLinkField ItemStyle-HorizontalAlign="Center" HeaderText="Today Last Day"
     DataTextField="PSCRUTINYTODAYLASTDAY">
     <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
     <ItemStyle Font-Underline="false" HorizontalAlign="Center" CssClass="text-center" />
 </asp:HyperLinkField>
                                            <asp:HyperLinkField ItemStyle-HorizontalAlign="Center" HeaderText="Before_Due Date"
                                                DataTextField="CompletedWithinDays">
                                                <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
                                                <ItemStyle Font-Underline="false" HorizontalAlign="Center" CssClass="text-center" />
                                            </asp:HyperLinkField>
                                            <asp:HyperLinkField ItemStyle-HorizontalAlign="Center" HeaderText="After_Due Date"
                                                DataTextField="CompletedBeyondDays">
                                                <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
                                                <ItemStyle Font-Underline="false" HorizontalAlign="Center" CssClass="text-center" />
                                            </asp:HyperLinkField>
                                             <asp:HyperLinkField ItemStyle-HorizontalAlign="Center" HeaderText="Today Last Day"
     DataTextField="APPROVALTODAYLASTDAY">
     <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
     <ItemStyle Font-Underline="false" HorizontalAlign="Center" CssClass="text-center" />
 </asp:HyperLinkField>
                                        </Columns>
                                    </asp:GridView>


                                </td>
                            </tr>
                        </table>
                    </div>
                </td>
            </tr>
        </table>
    </div>
    <%--  </div>    
                </div>
            </td>
        </tr>
    </table>--%>
</asp:Content>

