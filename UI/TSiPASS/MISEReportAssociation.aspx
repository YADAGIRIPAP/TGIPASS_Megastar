<%@ Page Title=":: TS-iPASS :: MSME Catalogue  " Language="C#" MasterPageFile="~/UI/TSiPASS/EmptyMaster.master"
    AutoEventWireup="true" CodeFile="MISEReportAssociation.aspx.cs" Inherits="TSTBDCReg1" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
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
        .style5
        {
            width: 100%;
        }
        .style6
        {
            width: 2px;
        }
    </style>

    <script type="text/javascript" language="javascript">

        function OpenPopup() {

            window.open("Lookups/LookupBDC.aspx", "List", "scrollbars=yes,resizable=yes,width=1000,height=650;display = block;position=absolute");

            return false;
        }
    </script>

    <script type="text/javascript">
        function showProgress() {
            var updateProgress = $get("<%= UpdateProgress.ClientID %>");
            updateProgress.style.display = "block";
        }
    </script>
    
    <script type="text/javascript" src="../../js/jquery.min.js"></script>

    <script type="text/javascript" src="../../js/jquery-ui.min.js"></script>

    <script type="text/javascript" src="../../js/gridviewScroll.min.js"></script>

    <script type="text/javascript">

        function pageLoad() {
            $('#<%=grdDetails.ClientID%>').gridviewScroll({
                width: "1200",
                height: "100%",
                arrowsize: 30,
                varrowtopimg: "../../images/arrowvt.png",
                varrowbottomimg: "../../images/arrowvb.png",
                harrowleftimg: "../../images/arrowhl.png",
                harrowrightimg: "../../images/arrowhr.png"
            });
        } 
           
    </script>

    <asp:UpdatePanel ID="upd1" runat="server">
        <ContentTemplate>
            <div align="left">
                <ol class="breadcrumb">
                    You are here &nbsp;!&nbsp; &nbsp; &nbsp;
                    <li><i class="fa fa-dashboard"></i><a href="Home.aspx"></a></li>
                    <li class=""><i class="fa fa-fw fa-edit"></i></li>
                    <li class="active"><i class="fa fa-edit"></i><a href="#">TSI Catalogue Report(IAs)</a>
                    </li>
                </ol>
            </div>
            <div align="left">
                <div class="row" align="left">
                    <div class="col-lg-11">
                        <div class="panel panel-primary">
                            <div class="panel-heading" align="center">
                                <h3 class="panel-title">
                                    TSI Catalogue Report(IAs)</h3>
                            </div>
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>
                                    <div class="panel-body">
                                        <table align="center" cellpadding="10" cellspacing="5" style="width: 98%">
                                            <tr>
                                                <td align="left" style="padding: 5px; margin: 5px" valign="top">
                                                    <table class="style5">
                                                        <tr>
                                                            <td>
                                                                &nbsp;
                                                            </td>
                                                            <td>
                                                                <table class="style5" cellpadding="7" cellspacing="7">
                                                                    <tr>
                                                                        <td height="40px">
                                                                            <asp:Label ID="Label456" runat="server" CssClass="LBLBLACK" Width="200px">Name 
                                                                    of Unit</asp:Label>
                                                                        </td>
                                                                        <td class="style6">
                                                                            :
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="txtNameofUnit" runat="server" class="form-control txtbox" Height="28px"
                                                                                MaxLength="100" TabIndex="1" ValidationGroup="group" Width="180px"></asp:TextBox>
                                                                        </td>
                                                                        <td>
                                                                            &nbsp;
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td height="40px">
                                                                            <asp:Label ID="Label450" runat="server" CssClass="LBLBLACK" Width="200px">Category</asp:Label>
                                                                        </td>
                                                                        <td class="style6">
                                                                            :
                                                                        </td>
                                                                        <td>
                                                                            <asp:DropDownList ID="ddlCategory" runat="server" class="form-control txtbox" Height="33px"
                                                                                TabIndex="1" Width="180px">
                                                                                <asp:ListItem>--Select--</asp:ListItem>
                                                                                <asp:ListItem Value="Micro">Micro</asp:ListItem>
                                                                                <asp:ListItem Value="Small">Small</asp:ListItem>
                                                                                <asp:ListItem Value="Medium">Medium</asp:ListItem>
                                                                                <%--<asp:ListItem>INVESTMENT SUBSIDY</asp:ListItem>
<asp:ListItem>IS</asp:ListItem>
<asp:ListItem>LC</asp:ListItem>
<asp:ListItem>Pavala  Vaddi</asp:ListItem>
<asp:ListItem>Power Tariff</asp:ListItem>
<asp:ListItem>PT</asp:ListItem>
<asp:ListItem>PV</asp:ListItem>
<asp:ListItem>REIMBURSEMENT OF INTEREST SUBSIDY </asp:ListItem>
<asp:ListItem>REIMBURSEMENT OF POWER TARIFF</asp:ListItem>
<asp:ListItem>REIMBURSEMENT OF SALES TAX</asp:ListItem>
<asp:ListItem>Sales Tax</asp:ListItem>
<asp:ListItem>Sales Tax Reimbursement </asp:ListItem>
<asp:ListItem>SD</asp:ListItem>
<asp:ListItem>ST</asp:ListItem>
<asp:ListItem>Stamp Duty</asp:ListItem>
--%>
                                                                            </asp:DropDownList>
                                                                        </td>
                                                                        <td>
                                                                            &nbsp;
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td height="40px">
                                                                            <asp:Label ID="Label453" runat="server" CssClass="LBLBLACK" Width="200px">Women 
                                                                    Enterprenuer</asp:Label>
                                                                        </td>
                                                                        <td class="style6">
                                                                            :
                                                                        </td>
                                                                        <td>
                                                                            <asp:DropDownList ID="ddltypeofncentive" runat="server" class="form-control txtbox"
                                                                                Height="33px" TabIndex="1" Width="180px">
                                                                                <asp:ListItem>--Select--</asp:ListItem>
                                                                                <asp:ListItem Value="Y">Yes</asp:ListItem>
                                                                                <asp:ListItem Value="N">No</asp:ListItem>
                                                                                <%--<asp:ListItem>INVESTMENT SUBSIDY</asp:ListItem>
<asp:ListItem>IS</asp:ListItem>
<asp:ListItem>LC</asp:ListItem>
<asp:ListItem>Pavala  Vaddi</asp:ListItem>
<asp:ListItem>Power Tariff</asp:ListItem>
<asp:ListItem>PT</asp:ListItem>
<asp:ListItem>PV</asp:ListItem>
<asp:ListItem>REIMBURSEMENT OF INTEREST SUBSIDY </asp:ListItem>
<asp:ListItem>REIMBURSEMENT OF POWER TARIFF</asp:ListItem>
<asp:ListItem>REIMBURSEMENT OF SALES TAX</asp:ListItem>
<asp:ListItem>Sales Tax</asp:ListItem>
<asp:ListItem>Sales Tax Reimbursement </asp:ListItem>
<asp:ListItem>SD</asp:ListItem>
<asp:ListItem>ST</asp:ListItem>
<asp:ListItem>Stamp Duty</asp:ListItem>
--%>
                                                                            </asp:DropDownList>
                                                                        </td>
                                                                        <td>
                                                                            &nbsp;
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td height="40px">
                                                                            &nbsp;
                                                                        </td>
                                                                        <td class="style6">
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
                                                            </td>
                                                            <td valign="top">
                                                                <table cellpadding="7" cellspacing="7" class="style5">
                                                                    <tr>
                                                                        <td height="40px">
                                                                            <asp:Label ID="Label454" runat="server" CssClass="LBLBLACK" Width="200px">SSI Reg./EM/Udyog Aadhar/IEM/SIA/IEC No.</asp:Label>
                                                                        </td>
                                                                        <td>
                                                                            :
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="txtEMpartnumber" runat="server" class="form-control txtbox" Height="28px"
                                                                                MaxLength="100" TabIndex="1" ValidationGroup="group" Width="180px"></asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td height="40px">
                                                                            <asp:Label ID="Label457" runat="server" CssClass="LBLBLACK" Width="200px">Caste</asp:Label>
                                                                        </td>
                                                                        <td>
                                                                            :
                                                                        </td>
                                                                        <td>
                                                                            <asp:DropDownList ID="ddlCategory0" runat="server" class="form-control txtbox" Height="33px"
                                                                                TabIndex="1" Width="180px">
                                                                                <asp:ListItem>--Select--</asp:ListItem>
                                                                                <asp:ListItem>SC</asp:ListItem>
                                                                                <asp:ListItem>ST</asp:ListItem>
                                                                                <asp:ListItem>BC</asp:ListItem>
                                                                                <asp:ListItem>OBC</asp:ListItem>
                                                                                <asp:ListItem>Minority</asp:ListItem>
                                                                                <%-- <asp:ListItem>ST(W)</asp:ListItem>
<asp:ListItem>OC (M)</asp:ListItem>
<asp:ListItem>OC</asp:ListItem>
<asp:ListItem>OC(W)</asp:ListItem>
<asp:ListItem>SCP</asp:ListItem>
<asp:ListItem>BC</asp:ListItem>
<asp:ListItem>ST (W)</asp:ListItem>
<asp:ListItem>ST</asp:ListItem>

<asp:ListItem>SC</asp:ListItem>
<asp:ListItem>SC (W)</asp:ListItem>
<asp:ListItem>SC(W)</asp:ListItem>
<asp:ListItem>TSP</asp:ListItem>
<asp:ListItem>General</asp:ListItem>--%>
                                                                            </asp:DropDownList>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td height="40px">
                                                                            <asp:Label ID="Label451" runat="server" CssClass="LBLBLACK" Width="200px">Type of Power Connection</asp:Label>
                                                                        </td>
                                                                        <td>
                                                                            &nbsp;
                                                                        </td>
                                                                        <td>
                                                                            <asp:DropDownList ID="ddlCategory1" runat="server" class="form-control txtbox" Height="33px"
                                                                                TabIndex="1" Width="180px">
                                                                                <asp:ListItem>--Select--</asp:ListItem>
                                                                                <asp:ListItem Value="LT">Low Tension</asp:ListItem>
                                                                                <asp:ListItem Value="HT">High Tension</asp:ListItem>
                                                                                <%-- <asp:ListItem>ST(W)</asp:ListItem>
<asp:ListItem>OC (M)</asp:ListItem>
<asp:ListItem>OC</asp:ListItem>
<asp:ListItem>OC(W)</asp:ListItem>
<asp:ListItem>SCP</asp:ListItem>
<asp:ListItem>BC</asp:ListItem>
<asp:ListItem>ST (W)</asp:ListItem>
<asp:ListItem>ST</asp:ListItem>

<asp:ListItem>SC</asp:ListItem>
<asp:ListItem>SC (W)</asp:ListItem>
<asp:ListItem>SC(W)</asp:ListItem>
<asp:ListItem>TSP</asp:ListItem>
<asp:ListItem>General</asp:ListItem>--%>
                                                                            </asp:DropDownList>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td height="40px">
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
                                                            </td>
                                                            <td>
                                                                &nbsp;
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                &nbsp;&nbsp;
                                                            </td>
                                                            <td align="right" style="text-align: right">
                                                                <asp:Button ID="BtnSave1" runat="server" CssClass="btn btn-primary" Height="32px"
                                                                    OnClick="BtnSave1_Click" TabIndex="10" Text="Search" ValidationGroup="group"
                                                                    Width="90px" />
                                                                &nbsp;
                                                            </td>
                                                            <td>
                                                                &nbsp;
                                                                <asp:Button ID="BtnClear" runat="server" CausesValidation="False" CssClass="btn btn-warning"
                                                                    Height="32px" OnClick="BtnClear_Click" TabIndex="10" Text="Cancel" ToolTip="To Clear  the Screen"
                                                                    Width="90px" />
                                                            </td>
                                                            <td>
                                                                &nbsp;
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                &nbsp;
                                                            </td>
                                                            <td align="right" style="text-align: right">
                                                                &nbsp;
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="lblstate11" runat="server" CssClass="LBLBLACK" Font-Bold="True" Font-Size="14px"
                                                                    ForeColor="Black" Width="200px"></asp:Label>
                                                            </td>
                                                            <td>
                                                                &nbsp;
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left" style="padding: 5px; margin: 5px" valign="top">
                                                        <asp:GridView ID="grdDetails" runat="server" AutoGenerateColumns="False" CellPadding="2"
                                                            OnRowDataBound="grdDetails_RowDataBound" ShowFooter="True" Width="100%">
                                                            <HeaderStyle CssClass="GridviewScrollC1HeaderWrap" />
                                                            <RowStyle CssClass="GridviewScrollC1Item" />
                                                            <PagerStyle CssClass="GridviewScrollC1Pager" />
                                                            <FooterStyle CssClass="GridviewScrollC1Footer" />
                                                            <AlternatingRowStyle CssClass="GridviewScrollC1Item2" />
                                                            <Columns>
                                                                <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S No">
                                                                    <ItemTemplate>
                                                                        <%# Container.DataItemIndex + 1%>
                                                                        <asp:HiddenField ID="HdfQueid" runat="server" />
                                                                        <asp:HiddenField ID="HdfApprovalid" runat="server" />
                                                                    </ItemTemplate>
                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                    <ItemStyle Width="50px" />
                                                                </asp:TemplateField>
                                                                <asp:BoundField DataField="Unit Name" HeaderText="Unit Name" />
                                                                <asp:BoundField DataField="EM/Udyoga aadhar/IEM number" HeaderText="EM/Udyoga aadhar/IEM number" />
                                                                <asp:BoundField DataField="District Name" HeaderText="District Name" />
                                                                <asp:BoundField DataField="LineofActivity" HeaderText="LineofActivity" />
                                                                <asp:BoundField DataField="Product Description" HeaderText="Product Description" />
                                                                <asp:BoundField DataField="Investment in Rs.lakhs" HeaderText="Investment in Rs.lakhs" />
                                                                <asp:BoundField DataField="Employement" HeaderText="Employement" />
                                                                <asp:BoundField DataField="Date of Commencement" HeaderText="Date of Commencement" />
                                                                <asp:BoundField DataField="Category of Enterprise" HeaderText="Category of Enterprise" />
                                                                <asp:BoundField DataField="Pollution Category" HeaderText="Pollution Category" />
                                                                <asp:BoundField DataField="Caste" HeaderText="Caste" />
                                                                <asp:BoundField DataField="Women Enterprenuer" HeaderText="Women Enterprenuer" />
                                                                <asp:BoundField DataField="Do you market your product outside state?" HeaderText="Do you market your product outside state?" />
                                                                <asp:BoundField DataField="Indicatestate" HeaderText="Indicatestate" />
                                                                <asp:BoundField DataField="Do you export your product?" HeaderText="Do you export your product?" />
                                                                <asp:BoundField DataField="Countries exported to" HeaderText="Countries exported to" />
                                                                <asp:HyperLinkField HeaderText="VIEW" Text="View" />
                                                            </Columns>
                                                        </asp:GridView>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="padding: 5px; margin: 5px" align="center">
                                                    &nbsp;<tr>
                                                        <td align="center" style="padding: 5px; margin: 5px">
                                                            &nbsp;
                                                        </td>
                                                    </tr>
                                                    <caption>
                                                        &nbsp;</caption>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="padding: 5px; margin: 5px" align="center">
                                                    <div id="success" runat="server" class="alert alert-success" visible="false">
                                                        <a aria-label="close" class="close" data-dismiss="alert" href="AddQualification.aspx">
                                                            ×</a> <strong>Success!</strong><asp:Label ID="lblmsg" runat="server"></asp:Label>
                                                    </div>
                                                    <div id="Failure" runat="server" class="alert alert-danger" visible="false">
                                                        <a aria-label="close" class="close" data-dismiss="alert" href="#">×</a> <strong>Warning!</strong>
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
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                    </div>
                </div>
            </div>
            <asp:UpdateProgress ID="UpdateProgress" runat="server" AssociatedUpdatePanelID="updatepanel1">
                <ProgressTemplate>
                    <div class="overlay">
                        <%--<div style=" z-index: 1000; margin-left: 350px;margin-top:200px;opacity: 1;-moz-opacity: 1;">--%>
                        <div style="z-index: 1000; margin-left: 250px; margin-top: 100px; opacity: 1; -moz-opacity: 1;">
                            <img alt="" src="../../Resource/Images/Processing.gif" />
                        </div>
                    </div>
                </ProgressTemplate>
            </asp:UpdateProgress>
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
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
