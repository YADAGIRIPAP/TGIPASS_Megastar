<%@ Page Title="" Language="C#" MasterPageFile="~/UI/TSiPASS/CCMaster.master" AutoEventWireup="true" CodeFile="frmmsmecfeuitsreports.aspx.cs" Inherits="UI_TSiPASS_frmmsmecfeuitsreports" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript">
        function GetRowValue(val) {
            if (val != '&nbsp;') {
                val1 = 0;
                window.opener.document.getElementById('ctl00_ContentPlaceHolder1_hdfID').value = val;
                window.opener.document.getElementById('ctl00_ContentPlaceHolder1_hdfFlagID').value = val1;

            }
            window.opener.document.forms[0].submit();
            self.close();

        }

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
    <%--<script type="text/javascript" src="../../js/jquery.min.js"></script>

    <script type="text/javascript" src="../../js/jquery-ui.min.js"></script>

    <script type="text/javascript" src="../../js/gridviewScroll.min.js"></script>

    <script type="text/javascript">

        function pageLoad() {
            $('#<%=grdDetails.ClientID%>').gridviewScroll({

                height: "100%",
                arrowsize: 30,
                varrowtopimg: "../../images/arrowvt.png",
                varrowbottomimg: "../../images/arrowvb.png",
                harrowleftimg: "../../images/arrowhl.png",
                harrowrightimg: "../../images/arrowhr.png"
            });
        } 
           
    </script>--%>
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
    <div class="col-lg-12">
        <div class="panel panel-default">
            <table id="divPrint" runat="server" border="0" cellpadding="0" cellspacing="0" style="width: 100%">
                <tr>
                    <td style="padding-top: 10px; padding-bottom: 20px; padding-left: 9px;" valign="top"
                        align="center">
                        <div class="panel panel-default">
                            <div class="panel-heading" style="text-align: center">
                                <h3 class="panel-title" style="font-weight: bold;">
                                    <asp:Label ID="lblHeading" runat="server">MSME Units Report Mapped with TS-iPASS Units</asp:Label>&nbsp;
                                    <a id="A1" href="#" onserverclick="BtnPDF_Click" runat="server">
                                        <img src="../../Resource/Images/pdf-icon.png" width="20px;" height="20px;" style="float: right;"
                                            alt="PDF" /></a> <a id="A2" href="#" onserverclick="BtnSave2_Click" runat="server">
                                                <img src="../../Resource/Images/Excel-icon.png" width="20px;" height="20px;" style="float: right;" /></a></h3>
                            </div>
                            <div class="panel-body">
                                <table align="center" cellpadding="10" cellspacing="5" style="width: 50%; font-family: 'Trebuchet MS'">
                                    <tr>
                                        <td style="text-align: left">
                                            <asp:HyperLink CssClass="btn btn-link" ID="HyperLink1" runat="server" NavigateUrl="~/UI/TSiPASS/ReportsDashboardNew.aspx"
                                                Text="<< Back">
                                            </asp:HyperLink>
                                        </td>
                                         <td class="col-xs-5" style="padding: 5px; text-align: right; margin: 5px" colspan="5">
                                            <b>
                                                <asp:Label ID="Label1" runat="server" CssClass="LBLBLACK">Report as on date</asp:Label></b>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="6" align="left">
                                            <table width="80%">
                                                <tr runat="server" id="trBetweenDates" visible="true">
                                                    <td style="padding: 5px; margin: 5px">From Date:
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtFromDate" runat="server" class="form-control txtbox" Height="28px"
                                                            MaxLength="40" onkeypress="NumberOnly()" TabIndex="1" ValidationGroup="group"
                                                            Width="125px"></asp:TextBox>
                                                        <%--<cc1:CalendarExtender ID="CalendarExtender2" runat="server" Format="dd-MM-yyyy" TargetControlID="txtFromDate">
                                                </cc1:CalendarExtender>--%>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px">To Date:
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtTodate" runat="server" class="form-control txtbox" Height="28px"
                                                            MaxLength="40" onkeypress="NumberOnly()" TabIndex="1" ValidationGroup="group"
                                                            Width="125px"></asp:TextBox>
                                                        <%-- <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd-MM-yyyy" TargetControlID="txtTodate">
                                                </cc1:CalendarExtender>--%>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        <asp:Label ID="Label352" runat="server" data-balloon-length="large" data-balloon="Please Select Proposed Location"
                                                            data-balloon-pos="down" CssClass="LBLBLACK">District : </asp:Label>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        <asp:DropDownList ID="ddlProp_intDistrictid" runat="server" class="form-control txtbox"
                                                            Height="33px" Width="180px" AutoPostBack="false">
                                                            <asp:ListItem Value="%">--ALL--</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                                <tr align="center">
                                                    <td style="padding: 5px; margin: 5px" colspan="4" align="center">
                                                        <%--<asp:Button ID="btnGet" runat="server" CssClass="btn btn-primary" Height="32px" TabIndex="10" Text="Generate Report" Width="180px" OnClick="btnGet_Click" />--%>
                                                        <asp:Button ID="Button3" runat="server" CssClass="btn btn-default" TabIndex="10"
                                                            Text="Submit" OnClick="BtnSave1_Click" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>

                                    <tr id="div_Print" runat="server">
                                        <td align="center" colspan="6" style="padding: 5px; margin: 5px">
                                            <asp:GridView ID="grdDetails" CssClass="floatingTable" runat="server" AutoGenerateColumns="False"
                                                CellPadding="4" OnRowDataBound="grdDetails_RowDataBound" Width="100%" OnPageIndexChanging="grdDetails_PageIndexChanging"
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
                                                    <asp:BoundField DataField="DISTRICTNAME" HeaderText="Dristrict Name" />
                                                    
                                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="MSME NO OF UNITS"
                                                        ItemStyle-HorizontalAlign="Center">
                                                        <ItemTemplate>
                                                            <asp:HyperLink ID="HyNoofClaimsFiled" runat="server" Text='<%#Eval("NOOFUNITS") %>'>HyperLink</asp:HyperLink>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>    
                                                    
                                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="MSME UNITS MAPPED WITH TSIPASS"
                                                        ItemStyle-HorizontalAlign="Center">
                                                        <ItemTemplate>
                                                            <asp:HyperLink ID="HyMSMEMAPPEDWITHTSIPASS" runat="server" Text='<%#Eval("MSMEMAPPEDWITHTSIPASS") %>'>HyperLink</asp:HyperLink>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>    
                                                    
                                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="MSME UNITS NOT MAPPED WITH TSIPASS"
                                                        ItemStyle-HorizontalAlign="Center">
                                                        <ItemTemplate>
                                                            <asp:HyperLink ID="HyMSMENOTMAPPEDWITHTSIPASS" runat="server" Text='<%#Eval("MSMENOTMAPPEDWITHTSIPASS") %>'>HyperLink</asp:HyperLink>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>    
                                                    
                                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="TSIPASS NO OF UNITS"
                                                        ItemStyle-HorizontalAlign="Center">
                                                        <ItemTemplate>
                                                            <asp:HyperLink ID="HyTSIPASSUNITS" runat="server" Text='<%#Eval("TSIPASSUNITS") %>'>HyperLink</asp:HyperLink>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>    
                                                    
                                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="TSIPASS UNITS MAPPED WITH MSME"
                                                        ItemStyle-HorizontalAlign="Center">
                                                        <ItemTemplate>
                                                            <asp:HyperLink ID="HyTSIPASSMAPPEDWITHMSME" runat="server" Text='<%#Eval("TSIPASSMAPPEDWITHMSME") %>'>HyperLink</asp:HyperLink>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>    
                                                    
                                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="TSIPASS UNITS NOT ENTERED IN MSME"
                                                        ItemStyle-HorizontalAlign="Center">
                                                        <ItemTemplate>
                                                            <asp:HyperLink ID="HyTsipassnotmapped" runat="server" Text='<%#Eval("TSIPASSNOTMAPPEDWITHMSME") %>'>HyperLink</asp:HyperLink>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>     
                                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Mapped on 24/06/2021"
                                                        ItemStyle-HorizontalAlign="Center">
                                                        <ItemTemplate>
                                                            <asp:HyperLink ID="hypTSIPASSMAPPED240621" runat="server" Text='<%#Eval("TSIPASSMAPPED240621") %>'>HyperLink</asp:HyperLink>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>  
                                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Mapped on 25/06/2021"
                                                        ItemStyle-HorizontalAlign="Center">
                                                        <ItemTemplate>
                                                            <asp:HyperLink ID="hypTSIPASSMAPPED250621" runat="server" Text='<%#Eval("TSIPASSMAPPED250621") %>'>HyperLink</asp:HyperLink>
                                                        </ItemTemplate>
                                                    </asp:TemplateField> 
                                                        <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Mapped on 26/06/2021"
                                                        ItemStyle-HorizontalAlign="Center">
                                                        <ItemTemplate>
                                                            <asp:HyperLink ID="hypTSIPASSMAPPED260621" runat="server" Text='<%#Eval("TSIPASSMAPPED260621") %>'>HyperLink</asp:HyperLink>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                       <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Mapped on 27/06/2021"
                                                        ItemStyle-HorizontalAlign="Center">
                                                        <ItemTemplate>
                                                            <asp:HyperLink ID="hypTSIPASSMAPPED270621" runat="server" Text='<%#Eval("TSIPASSMAPPED270621") %>'>HyperLink</asp:HyperLink>
                                                        </ItemTemplate>
                                                    </asp:TemplateField> 
                                                       <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Mapped on 28/06/2021"
                                                        ItemStyle-HorizontalAlign="Center">
                                                        <ItemTemplate>
                                                            <asp:HyperLink ID="hypTSIPASSMAPPED280621" runat="server" Text='<%#Eval("TSIPASSMAPPED280621") %>'>HyperLink</asp:HyperLink>
                                                        </ItemTemplate>
                                                    </asp:TemplateField> 
                                                       <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Mapped on 29/06/2021"
                                                        ItemStyle-HorizontalAlign="Center">
                                                        <ItemTemplate>
                                                            <asp:HyperLink ID="hypTSIPASSMAPPED290621" runat="server" Text='<%#Eval("TSIPASSMAPPED290621") %>'>HyperLink</asp:HyperLink>
                                                        </ItemTemplate>
                                                    </asp:TemplateField> 
                                                       <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Mapped on 30/06/2021"
                                                        ItemStyle-HorizontalAlign="Center">
                                                        <ItemTemplate>
                                                            <asp:HyperLink ID="hypTSIPASSMAPPED300621" runat="server" Text='<%#Eval("TSIPASSMAPPED300621") %>'>HyperLink</asp:HyperLink>
                                                        </ItemTemplate>
                                                    </asp:TemplateField> 
                                                    <asp:BoundField DataField="DISTRICTID" HeaderText="DistCd" Visible="false" />
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
