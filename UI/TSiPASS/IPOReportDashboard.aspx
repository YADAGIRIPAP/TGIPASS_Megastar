<%@ Page Title=":: IPO MIS :: Dash Board" Language="C#" MasterPageFile="~/UI/TSiPASS/CCMaster.master"
    AutoEventWireup="true" CodeFile="IPOReportDashboard.aspx.cs" Inherits="Dashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript" language="javascript">
    </script>
    <asp:UpdatePanel ID="updatepanel1" runat="server">
        <ContentTemplate>
            <div align="left">
                <ol class="breadcrumb">
                    You are here &nbsp;!&nbsp; &nbsp; &nbsp;
                    <li><i class="fa fa-dashboard"></i><a href="Home.aspx">Dashboard</a> </li>
                </ol>
            </div>
            <div align="center">
                <div class="row" align="center">
                    <div class="col-lg-11">
                        <div class="panel panel-primary">
                            <div class="panel-heading">
                                <h3 class="panel-title">
                                    IPO Report Dashboard</h3>
                            </div>
                            <div class="panel-body">
                                <table align="center" cellpadding="10" cellspacing="5" style="width: 100%">
                                    <tr>
                                        <td style="padding: 5px; margin: 5px">
                                            <div>
                                                <table>
                                                    <tr>
                                                        <td>
                                                            <b>Month :</b>
                                                        </td>
                                                        <td>
                                                            <asp:DropDownList ID="ddlMonth" runat="server" class="form-control txtbox" Height="33px"
                                                                TabIndex="1" Width="180px">
                                                                <asp:ListItem>--Select--</asp:ListItem>
                                                                <asp:ListItem Value="1">January</asp:ListItem>
                                                                <asp:ListItem Value="2">February</asp:ListItem>
                                                                <asp:ListItem Value="3">March</asp:ListItem>
                                                                <asp:ListItem Value="4">April</asp:ListItem>
                                                                <asp:ListItem Value="5">May</asp:ListItem>
                                                                <asp:ListItem Value="6">June</asp:ListItem>
                                                                <asp:ListItem Value="7">July</asp:ListItem>
                                                                <asp:ListItem Value="8">August</asp:ListItem>
                                                                <asp:ListItem Value="9">September</asp:ListItem>
                                                                <asp:ListItem Value="10">October</asp:ListItem>
                                                                <asp:ListItem Value="11">November</asp:ListItem>
                                                                <asp:ListItem Value="12">December</asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td>
                                                        </td>
                                                        <td>
                                                            <b>Year : </b>
                                                        </td>
                                                        <td>
                                                            <asp:DropDownList ID="ddlYear" runat="server" class="form-control txtbox" Height="33px"
                                                                TabIndex="1" Width="180px">
                                                                <asp:ListItem>--Select--</asp:ListItem>
                                                                <asp:ListItem>2019</asp:ListItem>
                                                                <asp:ListItem>2020</asp:ListItem>
                                                                <asp:ListItem>2021</asp:ListItem>
                                                                <asp:ListItem>2022</asp:ListItem>
                                                                <asp:ListItem>2023</asp:ListItem>
                                                                <asp:ListItem>2024</asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td>
                                                            &nbsp;
                                                        </td>
                                                        <td>
                                                            <asp:Button ID="BtnSave1" runat="server" CssClass="btn btn-primary" Height="32px"
                                                                OnClick="BtnSave1_Click" TabIndex="10" Text="Previous Month" ValidationGroup="group"
                                                                Width="140px" Visible="false" />
                                                        </td>
                                                        <td>
                                                            &nbsp;
                                                        </td>
                                                        <td>
                                                            <asp:Button ID="BtnClear" runat="server" CausesValidation="False" CssClass="btn btn-warning"
                                                                Height="32px" OnClick="BtnClear_Click" TabIndex="10" Text="Current Month" ToolTip="To Clear  the Screen"
                                                                Width="140px" Visible="false" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="5">
                                                            &nbsp;
                                                        </td>
                                                        <td>
                                                            &nbsp;
                                                        </td>
                                                        <td>
                                                            &nbsp;
                                                        </td>
                                                        <td>
                                                            &nbsp;
                                                        </td>
                                                        <td>
                                                            &nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="5">
                                                            <asp:Label ID="Label25" runat="server" Font-Bold="true" Text="Performance Report"></asp:Label>
                                                        </td>
                                                        <td>
                                                            &nbsp;
                                                        </td>
                                                        <td>
                                                            &nbsp;
                                                        </td>
                                                        <td>
                                                            &nbsp;
                                                        </td>
                                                        <td>
                                                            &nbsp;
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                            &nbsp;<div class="panel panel-default">
                                                <div class="panel-body" align="center">
                                                    <table cellpadding="3" cellspacing="5" style="width: 100%">
                                                        <tr>
                                                            <td style="font-size: 16px; text-align: center;" colspan="3">
                                                                <asp:HyperLink ID="HyperLink1" runat="server" Font-Size="Small" NavigateUrl="~/UI/TSiPASS/IPOReportDashboard.aspx">Back</asp:HyperLink>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="width: 395px; font-size: 16px;">
                                                                <b>REPORT 1: STRESSED ASSET BANK WISE REPORT</b>
                                                            </td>
                                                            <td style="width: 30px">
                                                                &nbsp;
                                                            </td>
                                                            <td style="width: 395px; font-size: 16px;">
                                                                <b>REPORT 2: BANK VISIT REPORT(LOAN SANCTIONED REPORT)</b>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="width: 395px" valign="top">
                                                                <div class="list-group">
                                                                    <a class="list-group-item" runat="server" visible="false"><span class="badge">
                                                                        <asp:Label ID="Label4" runat="server"></asp:Label></span> <i class="fa fa-fw fa-calendar">
                                                                        </i>Target </a><a class="list-group-item" href="frmProformaeReport1DrillDown.aspx"
                                                                            runat="server" visible="false"><span class="badge">
                                                                                <asp:Label ID="Label6" runat="server"></asp:Label>
                                                                            </span><i class="fa fa-fw fa-check"></i>Completed </a><a class="list-group-item"
                                                                                href="frmProformaeReport1.aspx"><span class="badge" style="background-color: #d9534f;">
                                                                                    <asp:Label ID="Label7" runat="server"></asp:Label>
                                                                                </span><i class="fa fa-spinner fa-spin"></i>Stressed asset bank wise report</a>
                                                                </div>
                                                            </td>
                                                            <td style="width: 30px">
                                                                &nbsp;
                                                            </td>
                                                            <td valign="top" style="width: 395px">
                                                                <div class="list-group">
                                                                    <a href="#" class="list-group-item" runat="server" visible="false"><span class="badge">
                                                                        <asp:Label ID="Label1" runat="server"></asp:Label></span> <i class="fa fa-fw fa-calendar">
                                                                        </i>Target </a><a runat="server" visible="false" class="list-group-item" href='frmPMEGP213.aspx?id=<%= Session["uid"]%>&Year=<%=Session["VMonth"]%>&Month=<%=Session["VYear"]%>'>
                                                                            <span class="badge">
                                                                                <asp:Label ID="Label2" runat="server"></asp:Label>
                                                                            </span><i class="fa fa-fw fa-check"></i>Completed </a><a class="list-group-item"
                                                                                href="frmbankvistreport.aspx"><span class="badge" style="background-color: #d9534f;">
                                                                                    <asp:Label ID="Label3" runat="server"></asp:Label>
                                                                                </span><i class="fa fa-spinner fa-spin"></i>BANK VISIT REPORT(Loan Sanctioned Report)</a>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="width: 395px; font-size: 16px;">
                                                                <b>REPORT 3: VEHICLE INSPECTION</b>
                                                            </td>
                                                            <td style="width: 30px">
                                                                &nbsp;
                                                            </td>
                                                            <td style="width: 395px; font-size: 16px;">
                                                                <b>REPORT 4: CLOSED UNITS</b>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="width: 395px" valign="top">
                                                                <div class="list-group">
                                                                    <a class="list-group-item" runat="server" visible="false"><span class="badge">
                                                                        <asp:Label ID="Label5" runat="server"></asp:Label></span> <i class="fa fa-fw fa-calendar">
                                                                        </i>Target </a><a runat="server" visible="false" class="list-group-item" href='frmBankVistReport213.aspx?id=<%= Session["uid"]%>&Year=<%=Session["VMonth"]%>&Month=<%=Session["VYear"]%>'>
                                                                            <span class="badge">
                                                                                <asp:Label ID="Label8" runat="server"></asp:Label>
                                                                            </span><i class="fa fa-fw fa-check"></i>Completed </a><a class="list-group-item"
                                                                                href="VehicleInspectionNew.aspx"><span class="badge" style="background-color: #d9534f;">
                                                                                    <asp:Label ID="Label9" runat="server"></asp:Label>
                                                                                </span><i class="fa fa-spinner fa-spin"></i>Vehicle Inspection</a>
                                                                </div>
                                                            </td>
                                                            <td style="width: 30px">
                                                                &nbsp;
                                                            </td>
                                                            <td valign="top" style="width: 395px">
                                                                <div class="list-group">
                                                                    <a runat="server" visible="false" href="#" class="list-group-item"><span class="badge">
                                                                        <asp:Label ID="Label10" runat="server"></asp:Label></span> <i class="fa fa-fw fa-calendar">
                                                                        </i>Target </a><a runat="server" visible="false" class="list-group-item" href='frmadvanceSbsidy213.aspx?id=<%= Session["uid"]%>&Year=<%=Session["VMonth"]%>&Month=<%=Session["VYear"]%>'>
                                                                            <span class="badge">
                                                                                <asp:Label ID="Label11" runat="server"></asp:Label>
                                                                            </span><i class="fa fa-fw fa-check"></i>Completed </a><a runat="server" id="GMPer"
                                                                                class="list-group-item" href="frmclosedunits.aspx"><span class="badge" style="background-color: #d9534f;">
                                                                                    <asp:Label ID="Label12" runat="server"></asp:Label>
                                                                                </span><i class="fa fa-spinner fa-spin"></i>Closedunits</a> <a runat="server" id="IPOPer"
                                                                                    visible="false" class="list-group-item" href="frmclosedunits.aspx"><span class="badge"
                                                                                        style="background-color: #d9534f;">
                                                                                        <asp:Label ID="Label26" runat="server"></asp:Label>
                                                                                    </span><i class="fa fa-spinner fa-spin"></i>Closed Units</a>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="width: 395px; font-size: 16px;">
                                                                <b>REPORT 5: ADVANCE SUBSIDY</b>
                                                            </td>
                                                            <td style="width: 30px">
                                                                &nbsp;
                                                            </td>
                                                            <td style="width: 395px; font-size: 16px;">
                                                                <b>REPORT 6: INDUSTRIAL CATALOGUE</b>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="width: 395px" valign="top">
                                                                <div class="list-group">
                                                                    <a runat="server" visible="false" href="#" class="list-group-item"><span class="badge">
                                                                        <asp:Label ID="Label13" runat="server"></asp:Label></span> <i class="fa fa-fw fa-calendar">
                                                                        </i>Target </a><a runat="server" visible="false" class="list-group-item" href="VehicleInspectiondrilDown.aspx">
                                                                            <span class="badge">
                                                                                <asp:Label ID="Label14" runat="server"></asp:Label>
                                                                            </span> <i class="fa fa-fw fa-check"></i>Completed </a><a class="list-group-item"
                                                                                href="frmadvanceSbsidy.aspx"><span class="badge" style="background-color: #d9534f;">
                                                                                    <asp:Label ID="Label18" runat="server"></asp:Label>
                                                                                </span><i class="fa fa-spinner fa-spin"></i>Advance Subsidy</a>
                                                                </div>
                                                            </td>
                                                            <td style="width: 30px">
                                                                &nbsp;
                                                            </td>
                                                            <td valign="top" style="width: 395px">
                                                                <div class="list-group">
                                                                    <a runat="server" visible="false" href="#" class="list-group-item"><span class="badge">
                                                                        <asp:Label ID="Label16" runat="server"></asp:Label></span> <i class="fa fa-fw fa-calendar">
                                                                        </i>Target </a><a runat="server" visible="false" class="list-group-item" href='frmClosedUnits213.aspx?id=<%= Session["uid"]%>&Year=<%=Session["VMonth"]%>&Month=<%=Session["VYear"]%>'>
                                                                            <span class="badge">
                                                                                <asp:Label ID="Label17" runat="server"></asp:Label>
                                                                            </span><i class="fa fa-fw fa-check"></i>Completed </a><a class="list-group-item"
                                                                                href="IndustrialCataloge1.aspx"><span class="badge" style="background-color: #d9534f;">
                                                                                    <asp:Label ID="Label24" runat="server"></asp:Label>
                                                                                </span><i class="fa fa-spinner fa-spin"></i>Industrial Catalogue</a>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="width: 395px; font-size: 16px;">
                                                                <b>REPORT 7: TS-IPASS</b>
                                                            </td>
                                                            <td style="width: 30px">
                                                                &nbsp;
                                                            </td>
                                                            <td style="width: 395px; font-size: 16px;">
                                                                <b>REPORT 8: PMEGP & MUDRA REGISTRATION</b>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="width: 395px" valign="top">
                                                                <div class="list-group">
                                                                    <a runat="server" visible="false" href="#" class="list-group-item"><span class="badge">
                                                                        <asp:Label ID="Label19" runat="server"></asp:Label></span> <i class="fa fa-fw fa-calendar">
                                                                        </i>Target </a><a runat="server" visible="false" class="list-group-item" href='TSiPASSReport213.aspx?id=<%= Session["uid"]%>&Year=<%=Session["VMonth"]%>&Month=<%=Session["VYear"]%>'>
                                                                            <span class="badge">
                                                                                <asp:Label ID="Label20" runat="server"></asp:Label>
                                                                            </span><i class="fa fa-fw fa-check"></i>Completed </a><a runat="server" id="GMTsipass"
                                                                                class="list-group-item" href="tsipassreport4.aspx"><span class="badge" style="background-color: #d9534f;">
                                                                                    <asp:Label ID="Label21" runat="server"></asp:Label>
                                                                                </span><i class="fa fa-spinner fa-spin"></i>TS-Ipass</a> <a runat="server" id="IPOTsipass"
                                                                                    visible="false" class="list-group-item" href="tsipassreport4.aspx">
                                                                                    <span class="badge" style="background-color: #d9534f;">
                                                                                        <asp:Label ID="Label27" runat="server"></asp:Label>
                                                                                    </span><i class="fa fa-spinner fa-spin"></i>Pending</a>
                                                                </div>
                                                            </td>
                                                            <td style="width: 30px">
                                                                &nbsp;
                                                            </td>
                                                            <td valign="top" style="width: 395px">
                                                                <div class="list-group">
                                                                    <a runat="server" visible="false" href="#" class="list-group-item"><span class="badge">
                                                                        <asp:Label ID="Label22" runat="server"></asp:Label></span> <i class="fa fa-fw fa-calendar">
                                                                        </i>Target </a><a runat="server" visible="false" class="list-group-item" href="IndustrialCataloge1DrillDown.aspx">
                                                                            <span class="badge">
                                                                                <asp:Label ID="Label23" runat="server"></asp:Label>
                                                                            </span>
                                                                            <i class="fa fa-fw fa-check"></i>Completed </a><a class="list-group-item"
                                                                                href="frmpmegpandmudra.aspx"><span class="badge" style="background-color: #d9534f;">
                                                                                    <asp:Label ID="Label15" runat="server"></asp:Label>
                                                                                </span><i class="fa fa-spinner fa-spin"></i>PMEGP & Mudra</a>
                                                                           
                                                            </td>
                                                        </tr>
                                                        <tr id="unitAD" runat="server" visible="false">
                                                            <td style="width: 395px" valign="top">
                                                                &nbsp;
                                                            </td>
                                                            <td style="width: 30px">
                                                                &nbsp;
                                                            </td>
                                                            <td style="width: 395px; font-size: 16px;">
                                                                <b>
                                                                    <asp:Label ID="Label31" Text="Unit Inspection" Visible="false" runat="server"></asp:Label></b>
                                                            </td>
                                                        </tr>
                                                        <tr id="unitDet" runat="server" visible="false">
                                                            <td style="width: 395px" valign="top">
                                                                &nbsp;
                                                            </td>
                                                            <td style="width: 30px">
                                                                &nbsp;
                                                            </td>
                                                            <td valign="top" style="width: 395px">
                                                                <div class="list-group">
                                                                    <a href="#" class="list-group-item" runat="server" id="UnitTarget" visible="false"><span
                                                                        class="badge">
                                                                        <asp:Label ID="Label28" runat="server"></asp:Label></span> <i class="fa fa-fw fa-calendar">
                                                                        </i>Target </a><a class="list-group-item" href="#" runat="server" visible="false"
                                                                            id="UnitCompleted"><span class="badge">
                                                                                <asp:Label ID="Label29" runat="server"></asp:Label>
                                                                            </span><i class="fa fa-fw fa-check"></i>Completed </a><a class="list-group-item"
                                                                                href="UnitInspection.aspx" runat="server" visible="false" id="UnitPending"><span
                                                                                    class="badge" style="background-color: #d9534f;">
                                                                                    <asp:Label ID="Label30" runat="server"></asp:Label>
                                                                                </span><i class="fa fa-spinner fa-spin"></i>Pending</a>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="width: 395px" valign="top">
                                                                &nbsp;
                                                            </td>
                                                            <td style="width: 30px">
                                                                &nbsp;
                                                            </td>
                                                            <td style="width: 395px" valign="top">
                                                                &nbsp;
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="font-size: 16px; text-align: center;" colspan="3">
                                                                <asp:Button ID="btnsubmit" CssClass="btn btn-default" runat="server" Text="Submit Periodical" OnClick="btnsubmit_Click"/>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                    &nbsp;
                                                </div>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center" style="padding: 5px; margin: 5px">
                                            <table cellpadding="2" style="width: 100%">
                                                <tr>
                                                    <td style="width: 417px">
                                                        &nbsp;
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                                <asp:HiddenField ID="hdfID" runat="server" />
                                <asp:HiddenField ID="hdfFlagID" runat="server" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <br />
            <br />
            <br />
        </ContentTemplate>
    </asp:UpdatePanel>
    <%--</div>
       </td>
        </tr>
    </table>--%>
</asp:Content>
