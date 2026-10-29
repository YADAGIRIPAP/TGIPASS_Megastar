<%@ Page Title="" Language="C#" MasterPageFile="~/UI/TSiPASS/EmptyMaster.master" AutoEventWireup="true" CodeFile="FrmDecriminalisationList.aspx.cs" Inherits="UI_TSiPASS_FrmDecriminalisationList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript">
        
    </script>
    <script language="javascript" type="text/javascript">
        function Panel1() {
            document.getElementById('<%=ddlDepartment.ClientID %>').style.display = "none"; 
            document.getElementById('<%=btnGet.ClientID %>').style.display = "none"; 
            document.getElementById('<%=ExportPannel.ClientID %>').style.display = "none";
            document.getElementById('<%=HyperLink1.ClientID %>').style.display = "none";
            document.getElementById('<%=divDept.ClientID %>').style.display = "none";
            var panel = document.getElementById("<%=divPrint.ClientID %>");
            var printWindow = window.open('', '', 'height=400,width=800');
            printWindow.document.write('<html><head><title>newTable</title>');

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
  
    <link href="../../css/ui-lightness/jquery-ui-1.8.19.custom.css" rel="stylesheet" />
   
    <style>
        .algnCenter {
            text-align: center;
        }

        span#ctl00_ContentPlaceHolder1_lblDept {
            min-width: 37.5% !important;
            width: 100% !important;
            max-width: 100% !important;
            display: flex;
            background: #1d9a5b;
            padding: 9px;
            color: #fff;
            border-radius: 9px;
            font-size: 16px;
            font-weight: 700;
            font-family: system-ui;
            text-align: center;
            flex-direction: row;
            flex-wrap: nowrap;
            justify-content: center;
        }
    </style>
    <script type="text/javascript">
        
       
    </script>
    <div class="col-lg-12">
        <div class="panel panel-default">
            <table id="divPrint" runat="server" border="0" cellpadding="0" cellspacing="0" style="width: 100%">
                <tr>
                    <td style="padding-top: 10px; padding-bottom: 20px; padding-left: 9px;" valign="top"
                        align="center">
                        <div class="panel panel-default">
                            <div class="panel-heading" style="text-align: center" runat="server" id="ExportPannel">
                                <h3 class="panel-title" style="font-weight: bold;">
                                    <asp:Label ID="lblHeading" runat="server">Decriminalisation List</asp:Label>&nbsp;
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
                                        alt="Excel" /></a></h3>
                            </div>
                            <div class="panel-body">
                                <table align="center" cellpadding="10" cellspacing="5" style="width: 100%; font-family: 'Trebuchet MS'">
                                    <tr>
                                        <td style="text-align: left">
                                            <asp:HyperLink CssClass="btn btn-link" ID="HyperLink1" runat="server" NavigateUrl="~/UI/TSiPASS/ReportsDashboardNew.aspx"
                                                Text="<< Back">
                                            </asp:HyperLink>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="6" align="left">
                                            <table width="100%">
                                                <tr>
                                                    <td class="col-xs-3" style="padding: 5px; margin: 5px">
                                                        <div class="input-group" id="divDept" runat="server">
                                                            <div class="input-group-addon">
                                                                Department
                                                            </div>
                                                            <asp:DropDownList ID="ddlDepartment" runat="server" class="form-control txtbox" Height="33px"
                                                                Width="180px" OnSelectedIndexChanged="ddlDepartment_SelectedIndexChanged" AutoPostBack="true">
                                                                <asp:ListItem>--Select--</asp:ListItem>
                                                            </asp:DropDownList>
                                                        </div>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px" colspan="4">
                                                        <asp:Button ID="btnGet" runat="server" CssClass="btn btn-default" TabIndex="10"
                                                            Text="Get Data" OnClick="btnGet_Click" />
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px;text-align:center" colspan="4"><span style="color:red">Note:</span></br>i. High - Results to risk in human life, safety, or death, impacts public interest, damages the environment, financial fraud, or willful negligence.
</br>ii. Medium – Offences which require subjective determination or analysis by the administering department; and
</br>iii. Low – Inadvertent in nature, technical, involve no public interest.</td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2" class="" style="padding: 5px; text-align: center; margin: 5px">
                                                        <asp:Label ID="lblDept" runat="server" CssClass="LBLBLACK"></asp:Label>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>

                                    <tr id="div_Print" runat="server">
                                        <td align="center" colspan="6" style="padding: 5px; margin: 5px">
                                            <asp:GridView ID="grdDetails" CssClass="floatingTable" runat="server" AutoGenerateColumns="False"
                                                CellPadding="4" Width="100%"
                                                ShowFooter="false">
                                                <HeaderStyle ForeColor="#FFFFFF" BackColor="#009688" Height="40px" CssClass="GridviewScrollC1HeaderWrap" />
                                                <RowStyle Height="40px" CssClass="GridviewScrollC1Item" />
                                                <PagerStyle CssClass="GridviewScrollC1Pager" />
                                                <FooterStyle ForeColor="#FFFFFF" BackColor="#009688" Height="40px" CssClass="GridviewScrollC1Footer" />
                                                <AlternatingRowStyle Height="40px" CssClass="GridviewScrollC1Item2" />
                                                <Columns>
                                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S No">
                                                        <ItemTemplate>
                                                            <%# Container.DataItemIndex +1 %>
                                                        </ItemTemplate>
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                        <ItemStyle Width="20px" />
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="DEPT_NAME" HeaderText="State Department" />
                                                    <asp:BoundField DataField="ACT_RULE_ORDER" HeaderText="Applicable Act/Rule/Order" />
                                                    <asp:BoundField DataField="PROVISION_OF_LAW" HeaderText="Provision of Law-Relevant Section/Rule/Clause/Form" />
                                                    <asp:BoundField DataField="POINT_OF_TRIGGER" HeaderText="Point of Trigger" />
                                                    <asp:BoundField DataField="FINE_IMPRISONMENT" HeaderText="Fine/Imprisonment" />
                                                    <asp:BoundField DataField="FINE_IMPRSIONMENT_PERIOD" HeaderText="Penalty and Imprisonment Period" />
                                                    <asp:BoundField DataField="LevelofSeverity" HeaderText="Level of Severity" />
                                                </Columns>
                                            </asp:GridView>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="6" align="center" style="padding: 5px; margin: 5px">
                                            <div id="success" runat="server" class="alert alert-success" visible="false">
                                                <a aria-label="close" class="close" data-dismiss="alert" href="AddQualification.aspx">×</a> <strong>Success!</strong><asp:Label ID="Label2" runat="server"></asp:Label>
                                            </div>
                                            <div id="Failure" runat="server" class="alert alert-danger" visible="false">
                                                <a aria-label="close" class="close" data-dismiss="alert" href="#">×</a> <strong>Warning!</strong>
                                                <asp:Label ID="lblmsg0" runat="server"></asp:Label>
                                            </div>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </div>
                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>


