<%@ Page Title="" Language="C#" MasterPageFile="~/UI/TSiPASS/CCMaster.master" AutoEventWireup="true" CodeFile="frmEODBUserData.aspx.cs" Inherits="UI_TSiPASS_frmEODBUserData" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script language="javascript" type="text/javascript">
        function Panel1() {
            var panel = document.getElementById("<%=GridPrint.ClientID %>");
            var printWindow = window.open('', '', 'height=400,width=1000');
            printWindow.document.write('<html><head><title></title>');

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

    <script language="javascript" type="text/javascript">
        function Panel2() {

            document.getElementById('<%=tblselection.ClientID %>').style.display = "none";
            document.getElementById('<%=GridPrint.ClientID %>').style.display = "none";
            document.getElementById('<%=HyperLink1.ClientID %>').style.display = "none";

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
    </script>
    <link href="../../css/ui-lightness/jquery-ui-1.8.19.custom.css" rel="stylesheet" />
    <style type="text/css">
        .ui-datepicker {
            font-size: 8pt !important;
            padding: 0.2em 0.2em 0;
            width: 250px;
            color: Black;
            z-index: 9999 !important;
        }

        select {
            color: Black !important;
        }
    </style>

    <style>
        .algnCenter {
            text-align: center;
        }
    </style>
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

    <table id="divPrint" runat="server" border="0" cellpadding="0" cellspacing="0" style="width: 100%">
        <tr>
            <td style="padding-top: 10px; padding-bottom: 20px; padding-left: 9px; height: 675px;"
                valign="top" align="center">
                <div class="col-lg-12">
                    <div class="panel panel-default">
                        <div class="panel-heading" style="text-align: center">
                            <h3 visible="false" id="Government" runat="server" class="panel-title" style="font-weight: bold;">Government of Telangana</h3>
                            <h2 id="H1" runat="server" class="panel-title" style="font-weight: bold;">
                                <asp:Label ID="lblHeading" runat="server">EODB User Data </asp:Label>
                                <a id="Button2" href="#" onserverclick="BtnPDF_Click"
                                    runat="server">
                                    <img src="viewpdf.aspx?filepathnew=D:/TS-iPASSFinal/Resource/Images/pdf-icon.png" width="20px;" height="20px;" style="float: right;"
                                        alt="PDF" /></a>
                                <a id="pdfPrint" href="#" onclick="javascript:return Panel1();"
                                    runat="server">
                                    <img src="viewpdf.aspx?filepathnew=D:/TS-iPASSFinal/Resource/Images/pdf-printer-icon.jpg" alt="PDF" width="30px;" height="30px;"
                                        style="float: right;" /></a>
                                <a id="Button1" href="#" onserverclick="BtnSave2_Click" runat="server">
                                    <img src="viewpdf.aspx?filepathnew=D:/TS-iPASSFinal/Resource/Images/Excel-icon.png" width="20px;" height="20px;" style="float: right;"
                                        alt="Excel" /></a></h2>
                        </div>
                        <div class="panel-body">
                            <table align="center" cellpadding="10" cellspacing="5" style="width: 80%; font-family: 'Trebuchet MS'">
                                <tr>
                                    <td>
                                        <table runat="server" id="tblselection" cellpadding="4" cellspacing="5" style="width: 80%">
                                            <tr>
                                                <td class="col-xs-3" style="padding: 5px; margin: 5px">
                                                    <div class="input-group">
                                                        <div class="input-group-addon">
                                                            Department
                                                        </div>
                                                        <asp:DropDownList ID="ddlDepartment" runat="server" class="form-control txtbox" Height="33px"
                                                            Width="180px" OnTextChanged="ddlDepartment_TextChanged" AutoPostBack="true">
                                                            <asp:ListItem>--Select--</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>
                                                </td>
                                                <td class="col-xs-3" style="padding: 5px; margin: 5px">
                                                    <div class="input-group">
                                                        <div class="input-group-addon">
                                                            Approval Name
                                                        </div>
                                                        <asp:DropDownList ID="ddlapprovalname" runat="server" class="form-control txtbox" Height="33px"
                                                            Width="180px">
                                                            <asp:ListItem>--Select--</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>
                                                </td>
                                                <td class="col-xs-3" style="padding: 5px; margin: 5px">
                                                    <div class="input-group">
                                                        <div class="input-group-addon">
                                                            Approval Type
                                                        </div>
                                                        <asp:DropDownList ID="ddlType" runat="server" class="form-control txtbox" Width="180px">
                                                            <asp:ListItem>--Select--</asp:ListItem>
                                                            <asp:ListItem Value="CFE">CFE</asp:ListItem>
                                                            <asp:ListItem Value="CFO">CFO</asp:ListItem>
                                                            <asp:ListItem Value="REN">Renewal</asp:ListItem>
                                                              <asp:ListItem Value="BMW">BMW</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="col-xs-3" style="padding: 5px; margin: 5px" runat="server" visible="false">
                                                    <asp:HyperLink CssClass="btn btn-link" ID="HyperLink1" runat="server" NavigateUrl="~/UI/TSiPASS/ReportsDashboardNew.aspx"
                                                        Text="<< Back">
                                                    </asp:HyperLink>
                                                </td>

                                                <td style="padding: 5px; margin: 5px" align="center" runat="server" id="tdFromDate">
                                                    <div class="input-group">
                                                        <div class="input-group-addon">
                                                            From Date
                                                        </div>

                                                        <asp:TextBox ID="txtFromDate" runat="server" class="form-control txtbox" Height="28px" MaxLength="40" onkeypress="NumberOnly()" TabIndex="1" ValidationGroup="group" Width="125px"></asp:TextBox>

                                                    </div>
                                                </td>
                                                <td style="padding: 5px; margin: 5px" runat="server" id="tdToDate">

                                                    <div class="input-group">
                                                        <div class="input-group-addon">
                                                            To Date
                                                        </div>
                                                        <asp:TextBox ID="txtTodate" runat="server" class="form-control txtbox" Height="28px" MaxLength="40" onkeypress="NumberOnly()" TabIndex="1" ValidationGroup="group" Width="125px"></asp:TextBox>

                                                    </div>
                                                </td>
                                                <td style="padding: 5px; margin: 5px" align="right">
                                                    <asp:Button ID="btnSubmit" runat="server" CssClass="btn btn-default" TabIndex="10"
                                                        Text="Submit" OnClick="btnSubmit_Click" />
                                                </td>
                                            </tr>

                                        </table>
                                    </td>

                                </tr>
                                <tr runat="server" id="rptdate" visible="false">
                                    <td colspan="2" class="col-xs-5" style="padding: 5px; text-align: right; margin: 5px">
                                        <asp:Label ID="Label2" runat="server" CssClass="LBLBLACK"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" class="col-xs-5" style="padding: 5px; text-align: center; margin: 5px; font-size: larger;">
                                        <asp:Label ID="Label1" runat="server" CssClass="LBLBLACK">Report as on date</asp:Label>
                                    </td>
                                </tr>
                                <tr id="GridPrint" runat="server">
                                    <td colspan="5" align="center" style="padding: 5px; margin: 5px" id="divPrint1" runat="server">
                                        <asp:GridView ID="grdDetails" runat="server" AutoGenerateColumns="False"
                                            Width="90%"
                                            ShowFooter="False">
                                            <HeaderStyle ForeColor="#FFFFFF" BackColor="#009688" Height="40px" />
                                            <RowStyle Height="40px" CssClass="GridviewScrollC1Item" />
                                            <PagerStyle CssClass="" />
                                            <AlternatingRowStyle Height="40px" CssClass="GridviewScrollC1Item2" />
                                            <Columns>
                                                <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S.No">
                                                    <ItemTemplate>
                                                        <%# Container.DataItemIndex +1 %>
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="ReferenceID" HeaderText="Reference ID"></asp:BoundField>
                                                <asp:BoundField DataField="Unit Name" HeaderText="Unit Name"></asp:BoundField>
                                                <asp:BoundField DataField="Promoter Name" HeaderText="Promoter Name"></asp:BoundField>
                                                <asp:BoundField DataField="Contact No" HeaderText="Contact No"></asp:BoundField>
                                                <asp:BoundField DataField="Application Date" HeaderText="Application Date"></asp:BoundField>
                                                <%--<asp:TemplateField HeaderText="Application Date">
                                                    <ItemTemplate>
                                                        <asp:Label runat="server" ID="lblApplicationDate" Text='<%#(Convert.ToDateTime(Eval("Application Date")).ToString("dd-MM-yyyy"))%>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>--%>
                                                <asp:BoundField DataField="Approval Date" HeaderText="Approval Date"></asp:BoundField>
                                                <asp:BoundField DataField="Email" HeaderText="Email"></asp:BoundField>
                                                <asp:BoundField DataField="Unit Address" HeaderText="Address"></asp:BoundField>
                                                <%--<asp:TemplateField HeaderText="Unit Address">
                                                    <ItemTemplate>
                                                        <asp:Label runat="server" ID="lbladdress" Text='<%#Eval("Unit Address")%>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Center" Width="40px" />
                                                    <HeaderStyle Width="50%" />
                                                </asp:TemplateField>--%>
                                            </Columns>
                                        </asp:GridView>
                                    </td>
                                </tr>

                                <tr>
                                    <td align="center" style="padding: 5px; margin: 5px">
                                        <div id="success" runat="server" visible="false" class="alert alert-success">
                                            <a href="AddQualification.aspx" class="close" data-dismiss="alert" aria-label="close">&times;</a> <strong>Success!</strong><asp:Label ID="lblmsg" runat="server"></asp:Label>
                                        </div>
                                        <div id="Failure" runat="server" visible="false" class="alert alert-danger">
                                            <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a> <strong>Warning!</strong>
                                            <asp:Label ID="lblmsg0" runat="server"></asp:Label>
                                        </div>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </div>
                </div>
            </td>
        </tr>
    </table>
</asp:Content>
