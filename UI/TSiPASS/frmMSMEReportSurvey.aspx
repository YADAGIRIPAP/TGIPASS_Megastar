<%@ Page Language="C#" AutoEventWireup="true"  MasterPageFile="~/UI/TSiPASS/CCMaster.master"  CodeFile="frmMSMEReportSurvey.aspx.cs" Inherits="UI_TSiPASS_frmMSMEReportSurvey" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script src="../../Resource/Scripts/js/validations.js" type="text/javascript"></script>
    <style type="text/css">
        .overlay
        {
            position: fixed;
            z-index: 999;
            height: 100%;
            width: 100%;
            top: 112px;
            background-color: Gray;
            filter: alpha(opacity=60);
            opacity: 0.9;
            -moz-opacity: 0.9;
        }
        
        .style8
        {
            color: #FF0000;
            font-weight: bold;
        }
        
        .algnRight
        {
            text-align: right;
        }
    </style>
    <style>
        .algnCenter
        {
            text-align: center;
        }
        
        body
        {
            font-family: 'Trebuchet MS';
        }
    </style>
    <script type="text/javascript" language="javascript">
        function OpenPopup() {
            window.open("Lookups/LookupBDC.aspx", "List", "scrollbars=yes,resizable=yes,width=1000,height=650;display = block;position=absolute");
            return false;
        }

    </script>
    <script type="text/javascript">
        function RejectValidate() {
            return confirm('Do you want to reject the record ?');
        }

        function RejectValidate1() {
            return alert('Please enter the Remarks');
        }
        function RejectValidate2() {
            return alert('Record Deleted Sucessfully');
        }

        $(function () {

            $('#MstLftMenu').remove();

        });
    </script>
    <script type="text/javascript" language="javascript">
        var win = new Object();
        function Popup(intval) {
            win = window.open("commsmeprint.aspx?UID=" + intval, "List", "scrollbars=yes,resizable=yes,width=780,height=400,left=" + ((window.screen.width / 2) - 320) + ",top=" + ((window.screen.height / 2) - 200) + ";display : block;position:absolute");
        }
    </script>
    <script type="text/javascript" language="javascript">
        var win = new Object();
        function PopupONE(intval) {

            win = window.open("frmMSME_edit.aspx?UID=" + intval, "List", "scrollbars=yes,resizable=yes,width=780,height=400,left=" + ((window.screen.width / 2) - 320) + ",top=" + ((window.screen.height / 2) - 200) + ";display : block;position:absolute");
        }
    </script>
    <script type="text/javascript">
        $(function () {
            $('#MstLftMenu').remove();
        });

    </script>
    <link href="../../css/ui-lightness/jquery-ui-1.8.19.custom.css" rel="stylesheet" />
    <style type="text/css">
        .ui-datepicker
        {
            font-size: 8pt !important;
            padding: 0.2em 0.2em 0;
            width: 250px;
            color: Black;
            z-index: 9999 !important;
        }
        select
        {
            color: Black !important;
        }
    </style>
    <style>
        .algnCenter
        {
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
    <script language="javascript" type="text/javascript">
        function Panel1() {
            document.getElementById('<%=A1.ClientID %>').style.display = "none";
            document.getElementById('<%=A2.ClientID %>').style.display = "none";
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
    <div align="left">
        <ol class="breadcrumb">
            You are here &nbsp;!&nbsp; &nbsp; &nbsp;
            <li><i class="fa fa-dashboard"></i><a href="Home.aspx"></a></li>
            <li class=""><i class="fa fa-fw fa-edit"></i></li>
            <li class="active"><i class="fa fa-edit"></i><a href="#">List of MSME Applications</a>
            </li>
        </ol>
    </div>
    <div class="col-lg-12">
        <div class="panel panel-default">
            <div class="panel-heading" align="center">
                <h3 class="panel-title" style="font-weight: bold;">
                    <asp:Label ID="lblHeading" runat="server"></asp:Label>&nbsp; <a id="A1" href="#"
                        onserverclick="BtnSave3_Click" runat="server">
                        <img src="../../Resource/Images/pdf-icon.png" width="20px;" height="20px;" style="float: right;"
                            alt="PDF" /></a>&nbsp;&nbsp; <a id="A2" href="#" onserverclick="BtnSave2_Click1"
                                runat="server">
                                <img src="../../Resource/Images/Excel-icon.png" width="20px;" height="20px;" style="float: right;"
                                    alt="Excel" /></a> <a id="pdfPrint" href="#" onclick="javascript:return Panel1();"
                                        runat="server">
                                        <img src="../../Resource/Images/pdf-printer-icon.jpg" alt="PDF" width="30px;" height="30px;"
                                            style="float: right;" /></a>
                </h3>
            </div>
            <div class="panel-body">
                <table align="center" cellpadding="10" cellspacing="5">
                    <tr>
                        <td style="padding: 5px; margin: 5px" align="left">
                            <asp:HyperLink CssClass="btn btn-link" ID="HyperLink1" runat="server" Text="<< Back">
                            </asp:HyperLink>
                        </td>
                        <td class="col-xs-5" style="padding: 5px; text-align: right; margin: 5px">
                            <asp:Label ID="Label1" runat="server" CssClass="LBLBLACK">Report as on date</asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="center" colspan="4" style="padding: 5px; margin: 5px">
                            <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Names="verdana" Font-Size="13px"
                                ForeColor="#006600"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="center" colspan="4" class="style8" style="padding: 5px; margin: 5px; text-align: right;"
                            valign="top">
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4">
                            <table width="100%">
                                <tr runat="server" id="trBetweenDates">
                                    <td style="padding: 5px; margin: 5px">
                                        From Date:
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtFromDate" runat="server" class="form-control txtbox" Height="28px"
                                            MaxLength="40" onkeypress="NumberOnly()" TabIndex="1" ValidationGroup="group"
                                            Width="125px"></asp:TextBox>
                                    </td>
                                    <td style="padding: 5px; margin: 5px">
                                        To Date:
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtTodate" runat="server" class="form-control txtbox" Height="28px"
                                            MaxLength="40" onkeypress="NumberOnly()" TabIndex="1" ValidationGroup="group"
                                            Width="125px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="padding: 5px; margin: 5px" align="left">
                                    </td>
                                    <td style="padding: 5px; margin: 5px" align="left" colspan="3">
                                    </td>
                                    <td>
                                    </td>
                                    <td>
                                    </td>
                                </tr>
                                <tr align="center">
                                    <td id="Td1" style="padding: 5px; margin: 5px" colspan="4" align="center" runat="server"
                                        visible="false">
                                        <asp:Button ID="btnGet" runat="server" CssClass="btn btn-primary" Height="32px" TabIndex="10"
                                            Text="Generate Report" Width="180px" OnClick="btnGet_Click" />
                                    </td>
                                </tr>
                                <tr align="center">
                                    <td id="Td2" style="padding: 5px; margin: 5px" colspan="4" align="center" runat="server">
                                        <asp:Button ID="Button1" runat="server" CssClass="btn btn-default" TabIndex="10"
                                            Text="Submit" OnClick="BtnSave1_Click" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <%--<tr id="gmpen" runat="server" visible="false">
                        <td align="left" colspan="6" style="padding: 5px; margin: 5px">
                            <asp:GridView ID="GridView2" CssClass="floatingTable" runat="server" AutoGenerateColumns="False"
                                CellPadding="4"  Width="25%" 
                                ShowFooter="True">
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
                                    <asp:BoundField DataField="DISTRICTNAME" HeaderText="Date" />

                                    <asp:BoundField DataField="NOOFUNITSMEGA" HeaderText="Mega Units" />
                                    <asp:BoundField DataField="NOOFUNITSLARGE" HeaderText="Large Units" />
                                    <asp:BoundField DataField="NOOFUNITSMEDIUM" HeaderText="Medium Units" />
                                    <asp:BoundField DataField="NOOFUNITSTOTAL" HeaderText="Total Units" />
                                    <asp:BoundField DataField="NOOFUNITSMEGAEMPLOY" HeaderText="Mega Employment Updated" />
                                    <asp:BoundField DataField="NOOFUNITSLARGEEMPLOY" HeaderText="Large Employment Updated" />
                                    <asp:BoundField DataField="NOOFUNITSMEDIUMEMPLOY" HeaderText="Medium Employment Updated" />
                                    <asp:BoundField DataField="NOOFUNITSTOTALEMPLOY" HeaderText="Total Employment Updated" />

                                    <asp:BoundField DataField="NOOFUNITSMEGAEMPLOYBAL" HeaderText="Mega Employment Not Updated" />
                                    <asp:BoundField DataField="NOOFUNITSLARGEEMPLOYBAL" HeaderText="Large Employment Not Updated" />
                                    <asp:BoundField DataField="NOOFUNITSMEDIUMEMPLOYBAL" HeaderText="Small Employment Not Updated" />
                                    <asp:BoundField DataField="NOOFUNITSTOTALEMPLOYBAL" HeaderText="Total Employment Not Updated" />
                                </Columns>
                            </asp:GridView>
                        </td>
                    </tr>--%>

                    <tr id="divPrint" runat="server">
                        <td align="center" colspan="4" style="padding: 5px; margin: 5px; text-align: center;"
                            valign="top">
                            <asp:GridView ID="grdDetails" runat="server" AutoGenerateColumns="false" CellPadding="5"
                                ShowFooter="True" Width="100%" OnRowDataBound="grdDetails_RowDataBound" DataKeyNames="msmeNo">
                                <HeaderStyle Height="40px" CssClass="GridviewScrollC1HeaderWrap" />
                                <RowStyle CssClass="GridviewScrollC1Item" />
                                <PagerStyle CssClass="GridviewScrollC1Pager" />
                                <FooterStyle Height="40px" CssClass="GridviewScrollC1Header" />
                                <AlternatingRowStyle CssClass="GridviewScrollC1Item2" />
                                <Columns>
                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S No">
                                        <ItemTemplate>
                                            <%# Container.DataItemIndex + 1%>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="View & Edit">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnk_grdview" runat="server" Text='<%# Eval("msmeNo") %>'></asp:LinkButton>
                                            <br />
                                            <br />
                                            <%--<asp:LinkButton ID="LinkEDIT" runat="server" Text='<%# Eval("msmeNo") %>' Visible="false"></asp:LinkButton>--%>
                                            <asp:HyperLink ID="LinkEDIT" runat="server" Text='<%# Eval("msmeNo") %>' Target="_blank"
                                                Visible="false"></asp:HyperLink>
                                            </td>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Left" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Delete" Visible="false">
                                        <ItemTemplate>
                                            <%--<asp:Label ID="lbl_deletestatus" runat="server" Text='<%# Eval("DeletedReason") %>' />--%>
                                            <br />
                                            <asp:DropDownList ID="ddl_griddeletedstatus" runat="server" class="form-control txtbox"
                                                Height="33px" TabIndex="1" Width="180px" AutoPostBack="true" OnSelectedIndexChanged="ddl_griddeletedstatus_SelectedIndexChanged">
                                                <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                <asp:ListItem Value="1">Duplicate</asp:ListItem>
                                                <asp:ListItem Value="2">Not Existing</asp:ListItem>
                                                <asp:ListItem Value="3">closed</asp:ListItem>
                                                <asp:ListItem Value="4">others</asp:ListItem>
                                            </asp:DropDownList>
                                            <br />
                                            <asp:TextBox runat="server" class="form-control" Height="50px" Width="230px" AutoComplete="false"
                                                ID="TXTREMARKS" placeholder="Remarks" TextMode="MultiLine" Visible="false" />
                                            <br />
                                            <asp:HiddenField ID="hf_msmeid" runat="server" Value='<%# Eval("msmeNo") %>' />
                                            <asp:LinkButton ID="linkdelete" runat="server" Text="DELETE" OnClick="linkdelete_Click" Visible="false"></asp:LinkButton>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Left" />
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="UNIT_NAME" ItemStyle-HorizontalAlign="Center" HeaderText="Unit Name">
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="UNITS_IE_OR_NOT" ItemStyle-HorizontalAlign="Center" HeaderText="IE or Not">
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="EnterpriseName" ItemStyle-HorizontalAlign="Center" HeaderText="Industry Category">
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="NAME_OF_ENTREPRENEUR" ItemStyle-HorizontalAlign="Center"
                                        HeaderText="Promoter Name">
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="District_Name" ItemStyle-HorizontalAlign="Center" HeaderText="District Name">
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Manda_lName" ItemStyle-HorizontalAlign="Center" HeaderText="Mandal Name">
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="UAM_ID" ItemStyle-HorizontalAlign="Center" HeaderText="UAM ID">
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    
                                    <asp:BoundField DataField="LineofActivity_Name" ItemStyle-HorizontalAlign="Center"
                                        HeaderText="LINE OF ACTIVITY">
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="INVESTMENT" ItemStyle-HorizontalAlign="Center" HeaderText="INVESTMENT">
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="MOBILE_NO" ItemStyle-HorizontalAlign="Center" HeaderText="Mobile Number">
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="EMAIL_ID" ItemStyle-HorizontalAlign="Center" HeaderText="Email ID">
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="PresentStatus" ItemStyle-HorizontalAlign="Center" HeaderText="Present Status">
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="TYPEOFINDUSTRY" ItemStyle-HorizontalAlign="Center" HeaderText="Type of Industry">
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="EXPORT" ItemStyle-HorizontalAlign="Center" HeaderText="Export">
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="TYPEOFCONNECTION" ItemStyle-HorizontalAlign="Center" HeaderText="Type of Connection">
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="PCBCATEGORY" ItemStyle-HorizontalAlign="Center" HeaderText="PCB Category">
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="SOCAILSTATUS" ItemStyle-HorizontalAlign="Center" HeaderText="Socail Status">
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="PROMOTERWOMEN" ItemStyle-HorizontalAlign="Center" HeaderText="Promoter Women">
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="PROMOTERDISABLED" ItemStyle-HorizontalAlign="Center" HeaderText="Promoter Disabled">
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="SECTOR" ItemStyle-HorizontalAlign="Center" HeaderText="Sector">
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="CompleteAddress" ItemStyle-HorizontalAlign="Center" HeaderText="Complete Address">
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    
                                    <asp:BoundField DataField="DATEOFCOMMENCEMENT" ItemStyle-HorizontalAlign="Center"
                                        HeaderText="Date of Commencement">
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="RAWMATERIALPROCURED" ItemStyle-HorizontalAlign="Center"
                                        HeaderText="Raw Material Procured">
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="LocationDetails" ItemStyle-HorizontalAlign="Center" HeaderText="Location Details">
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="HouseNo" ItemStyle-HorizontalAlign="Center" HeaderText="House No">
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Locality" ItemStyle-HorizontalAlign="Center" HeaderText="Locality">
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Street" ItemStyle-HorizontalAlign="Center" HeaderText="Street">
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="LandMark" ItemStyle-HorizontalAlign="Center" HeaderText="LandMark">
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="IndustrialPark" ItemStyle-HorizontalAlign="Center" HeaderText="IndustrialPark">
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Village" ItemStyle-HorizontalAlign="Center" HeaderText="Village">
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Investment" ItemStyle-HorizontalAlign="Center" HeaderText="INVESTMENT">
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="EMPLOYMENT" ItemStyle-HorizontalAlign="Center" HeaderText="EMPLOYMENT">
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="MENEMPLOYMENT" ItemStyle-HorizontalAlign="Center" HeaderText="Men Employment">
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="WOMENEMPLOYMENT" ItemStyle-HorizontalAlign="Center" HeaderText="WoMen Employment">
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="PFEMPLOYMENT" ItemStyle-HorizontalAlign="Center" HeaderText="PF">
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="ESIEMPLOYMENT" ItemStyle-HorizontalAlign="Center" HeaderText="ESI">
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="LOCALEMPLOYMENT" ItemStyle-HorizontalAlign="Center" HeaderText="Local Employment">
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="NONLOCALEMPLOYMENT" ItemStyle-HorizontalAlign="Center"
                                        HeaderText="NonLocal Employment">
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="MIGRANTEMPLOYMENT" ItemStyle-HorizontalAlign="Center"
                                        HeaderText="Migrant Employment">
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="DIRECTEMPLOYMENT" ItemStyle-HorizontalAlign="Center" HeaderText="Direct Employment">
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="INDIRECTEMPLOYMENT" ItemStyle-HorizontalAlign="Center"
                                        HeaderText="InDirect Employment">
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="TOTALEMP" ItemStyle-HorizontalAlign="Center" HeaderText="Total Employment">
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                </Columns>
                            </asp:GridView>
                        </td>
                    </tr>
                    
                    <tr>
                        <td align="center" colspan="4" style="padding: 5px; margin: 5px">
                            <div id="success" runat="server" visible="false" class="alert alert-success">
                                <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a> <strong>
                                    Success!</strong><asp:Label ID="lblmsg" runat="server"></asp:Label>
                            </div>
                            <div id="Failure" runat="server" visible="false" class="alert alert-danger">
                                <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a> <strong>
                                    Warning!</strong>
                                <asp:Label ID="lblmsg0" runat="server"></asp:Label>
                            </div>
                        </td>
                    </tr>
                </table>
                <asp:HiddenField ID="hdfID" runat="server" />
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
                    ShowSummary="False" ValidationGroup="group" />
                <asp:ValidationSummary ID="ValidationSummary2" runat="server" ShowMessageBox="True"
                    ShowSummary="False" ValidationGroup="child" />
                <asp:HiddenField ID="hdfFlagID" runat="server" />
            </div>
        </div>
    </div>
</asp:Content>
