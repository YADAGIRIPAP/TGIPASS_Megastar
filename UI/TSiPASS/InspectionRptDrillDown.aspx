<%@ Page Title=":: TS-iPASS ::  " Language="C#" MasterPageFile="~/UI/TSiPASS/CCMaster.master"
    EnableEventValidation="false" AutoEventWireup="true" CodeFile="InspectionRptDrillDown.aspx.cs"
    Inherits="TSTBDCReg1" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script src="../../Resource/Scripts/js/validations.js" type="text/javascript"></script>

    <script type="text/javascript" language="javascript">

        function OpenPopup() {

            window.open("Lookups/LookupBDC.aspx", "List", "scrollbars=yes,resizable=yes,width=1000,height=650;display = block;position=absolute");

            return false;
        }
    </script>

    <script type="text/javascript" src="../../js/jquery.min.js"></script>

    <script type="text/javascript" src="../../js/jquery-ui.min.js"></script>

    <script type="text/javascript" src="../../js/gridviewScroll.min.js"></script>

    <script type="text/javascript">

        function pageLoad() {
            $('#<%=grdDetails.ClientID%>').gridviewScroll({
                width: "100%",
                height: "100%",
                arrowsize: 30,
                varrowtopimg: "../../images/arrowvt.png",
                varrowbottomimg: "../../images/arrowvb.png",
                harrowleftimg: "../../images/arrowhl.png",
                harrowrightimg: "../../images/arrowhr.png"
            });
        } 
           
    </script>

    <div align="left">
        <ol class="breadcrumb">
            You are here &nbsp;!&nbsp; &nbsp; &nbsp;
            <li><i class="fa fa-dashboard"></i><a href="Home.aspx"></a></li>
            <li class=""><i class="fa fa-fw fa-edit"></i></li>
            <li class="active"><i class="fa fa-edit"></i><a href="#">Inspection Progress Details</a>
            </li>
        </ol>
    </div>
    <div id="divPrint" runat="server" align="left">
        <div class="row" align="left">
            <div class="col-lg-12">
                <div class="panel panel-default">
                    <div class="panel-heading" style="text-align: center">
                        <h3 class="panel-title" style="font-weight: bold">
                            Inspection Progress Details<a id="Button2" href="#" onserverclick="BtnPDF_Click"
                                runat="server">
                                <img src="../../Resource/Images/pdf-icon.png" width="20px;" height="20px;" style="float: right;"
                                    alt="PDF" /></a> <a id="Button1" href="#" onserverclick="BtnSave2_Click1" runat="server">
                                        <img src="../../Resource/Images/Excel-icon.png" width="20px;" height="20px;" style="float: right;"
                                            alt="Excel" /></a></h3>
                    </div>
                    <div class="panel-body">
                        <table align="center" cellpadding="10" cellspacing="5" style="width: 90%">
                            <tr>
                                <td class="col-xs-12" style="padding: 5px; text-align: right; margin: 5px">
                                    <asp:Label ID="Label1" runat="server" CssClass="LBLBLACK">Report as on date</asp:Label>
                                </td>
                               <%-- <td style="padding: 5px; margin: 5px" valign="top">
                                    <table cellpadding="4" cellspacing="5" style="width: 100%">
                                        <tr visible="false">
                                            <td class="col-xs-3" style="padding: 5px; margin: 5px">
                                                <div class="input-group">
                                                    <div class="input-group-addon">
                                                        Date - From</div>
                                                    <asp:TextBox ID="txtFromDate" runat="server" class="form-control txtbox" MaxLength="40"
                                                        TabIndex="1" ValidationGroup="group" Width="100px"></asp:TextBox>
                                                    <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd-MM-yyyy" PopupButtonID="txtFromDate"
                                                        TargetControlID="txtFromDate">
                                                    </cc1:CalendarExtender>
                                                    <div class="input-group-addon">
                                                        To</div>
                                                    <asp:TextBox ID="txtToDate" runat="server" class="form-control txtbox" MaxLength="40"
                                                        TabIndex="1" ValidationGroup="group" Width="100px"></asp:TextBox>
                                                    <cc1:CalendarExtender ID="txtRegDate0_CalendarExtender" runat="server" Format="dd-MM-yyyy"
                                                        PopupButtonID="txtToDate" TargetControlID="txtToDate">
                                                    </cc1:CalendarExtender>
                                                </div>
                                            </td>
                                            <td style="padding: 5px; margin: 5px" align="right">
                                                <asp:Button ID="BtnSearch" runat="server" CssClass="btn btn-default" TabIndex="10"
                                                    Text="Submit" ValidationGroup="group" OnClick="BtnSave_Click" />
                                            </td>
                                        </tr>
                                    </table>
                                </td>--%>
                            </tr>
                            <tr>
                                <td align="center" style="padding: 5px; margin: 5px; text-align: center;" valign="top">
                                    <asp:GridView ID="grdDetails" runat="server" AutoGenerateColumns="False" ShowFooter="True"
                                        Width="100%" OnRowDataBound="grdDetails_RowDataBound">
                                        <HeaderStyle ForeColor="#FFFFFF" BackColor="#009688" Height="40px" CssClass="GridviewScrollC1HeaderWrap" />
                                        <RowStyle Height="40px" CssClass="GridviewScrollC1Item" />
                                        <PagerStyle CssClass="GridviewScrollC1Pager" />
                                        <FooterStyle ForeColor="#FFFFFF" BackColor="#009688" Height="40px" CssClass="GridviewScrollC1Footer" />
                                        <AlternatingRowStyle Height="40px" CssClass="GridviewScrollC1Item2" />
                                        <Columns>
                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S.No">
                                                <ItemTemplate>
                                                    <%# Container.DataItemIndex + 1%>
                                                    <asp:HiddenField ID="HdfQueid" runat="server" />
                                                    <asp:HiddenField ID="HdfApprovalid" runat="server" />
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Center" />
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="UnitName" HeaderText="Unit Name" />
                                            <asp:BoundField DataField="District" HeaderText="District" />
                                            <asp:BoundField DataField="Mandal" HeaderText="Mandal" />
                                            <asp:BoundField DataField="Village" HeaderText="Village" />
                                            <asp:BoundField DataField="Authority Designation" HeaderText="Authority Designation" />
                                            <asp:BoundField DataField="Date Of Inspection" HeaderText="Date Of Inspection" DataFormatString="{0:dd MMM yyyy}" />
                                            <asp:BoundField DataField="Date of Uploading Inspection" HeaderText="Date of Uploading Inspection"
                                                DataFormatString="{0:dd MMM yyyy}" />
                                            <asp:BoundField DataField="Unique_Number" HeaderText="Unique Number" />
                                            <asp:HyperLinkField DataTextField="Web Path" HeaderText="View / Download" />
                                            <%--<asp:BoundField DataField="Transaction_Date" HeaderText="Transaction_Date" DataFormatString="{0:dd/MM/yyyy}" />--%>
                                            <%-- <asp:BoundField DataField="intDepartmentApprovalid" HeaderText="Department Approval ID" />--%>
                                        </Columns>
                                    </asp:GridView>
                                </td>
                            </tr>
                            <tr>
                                <td align="left" style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td align="center" style="padding: 5px; margin: 5px">
                                    <div id="success" runat="server" visible="false" class="alert alert-success">
                                        <a href="AddQualification.aspx" class="close" data-dismiss="alert" aria-label="close">
                                            &times;</a> <strong>Success!</strong><asp:Label ID="lblmsg" runat="server"></asp:Label>
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
        </div>
    </div>
</asp:Content>
