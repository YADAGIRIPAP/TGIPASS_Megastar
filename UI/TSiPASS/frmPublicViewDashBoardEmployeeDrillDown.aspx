<%@ Page Title="" Language="C#" MasterPageFile="~/UI/TSiPASS/CCMaster.master" AutoEventWireup="true" CodeFile="frmPublicViewDashBoardEmployeeDrillDown.aspx.cs" Inherits="UI_TSiPASS_frmPublicViewDashBoardEmployeeDrillDown" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script src="../../Resource/Scripts/js/validations.js" type="text/javascript"></script>

    <style type="text/css">
        .overlay {
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

        .style8 {
            color: #FF0000;
            font-weight: bold;
        }

        .algnRight {
            text-align: center;
            padding-right: 5px;
        }
    </style>

    <script type="text/javascript" language="javascript">

        function OpenPopup() {

            window.open("Lookups/LookupBDC.aspx", "List", "scrollbars=yes,resizable=yes,width=1000,height=650;display = block;position=absolute");

            return false;
        }
    </script>

    <script type="text/javascript" language="javascript">
        var win = new Object();
        function Popup(intval) {

            win = window.open("CFEPopup.aspx?UID=" + intval, "List", "scrollbars=yes,resizable=yes,width=780,height=400,left=" + ((window.screen.width / 2) - 320) + ",top=" + ((window.screen.height / 2) - 200) + ";display : block;position:absolute");
            //win = window.open("RptVillageOraganisationNameClickDetails.aspx?id="+intval, "List", "scrollbars=yes,resizable=yes,width=600,height=400,left=" + ((window.screen.width / 2) - 320) + ",top=" + ((window.screen.height / 2) - 200) + ";display : block;position:absolute");

        }
    </script>

    <script type="text/javascript">
        $(function () {

            $('#MstLftMenu').remove();

        });

    </script>

    <div align="center">
        <div class="row" align="center">
            <div class="col-lg-12">
                <div class="panel panel-default">
                    <div class="panel-heading" align="center">
                        <h3 class="panel-title" style="font-weight: bold;">
                            <asp:Label ID="lblHeading" runat="server"></asp:Label>&nbsp; <a id="A1" href="#"
                                onserverclick="BtnPDF_Click" runat="server">
                                <img src="../../Resource/Images/pdf-icon.png" width="20px;" height="20px;" style="float: right;"
                                    alt="PDF" /></a> <a id="A2" href="#" onserverclick="BtnSave2_Click1" runat="server">
                                        <img src="../../Resource/Images/Excel-icon.png" width="20px;" height="20px;" style="float: right;"
                                            alt="Excel" /></a></h3>
                    </div>
                    <div class="panel-body">
                        <table align="center" cellpadding="10" cellspacing="5" style="width: 100%">
                            <tr align="center">
                                <td style="padding: 5px; margin: 5px" valign="top" align="center">
                                    <table width="80%">
                                       
                                        <tr>
                                            <td style="text-align: left">
                                                <asp:HyperLink CssClass="btn btn-link" ID="HyperLink1" runat="server" NavigateUrl="~/UI/TSiPASS/frmPublicViewDashBoardEmployee.aspx" Text="<< Back">
                                                </asp:HyperLink>
                                            </td>
                                        </tr>

                                        <tr>
                                            <td class="col-xs-3" style="padding: 5px; margin: 5px">&nbsp;</td>
                                            <td style="padding: 5px; margin: 5px" align="center">&nbsp;</td>
                                            <td style="padding: 5px; margin: 5px">&nbsp;</td>
                                            <td style="padding: 5px; margin: 5px" align="right">&nbsp;</td>
                                            <td class="col-xs-5" style="padding: 5px; text-align: right; margin: 5px">&nbsp;</td>
                                        </tr>
                                        <tr align="center">
                                            <td style="padding: 5px; margin: 5px" align="center">
                                                <div class="input-group">
                                                    <div class="input-group-addon">
                                                        District
                                                    </div>

                                                    <asp:DropDownList ID="ddldistrict" Style="width: 239px; height: 28px;" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddldistrict_SelectedIndexChanged"
                                                        TabIndex="1">
                                                        <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                    </asp:DropDownList>

                                                </div>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">

                                                <div class="input-group" runat="server" visible="false">
                                                    <div class="input-group-addon">
                                                        Line Of Activity
                                                    </div>
                                                    <asp:DropDownList ID="ddllineofactivity" Style="width: 239px; height: 28px;" runat="server"
                                                        TabIndex="1">
                                                        <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                    </asp:DropDownList>
                                                </div>
                                            </td>
                                            <td style="padding: 5px; margin: 5px" align="right">
                                                <asp:Button ID="Button3" runat="server" Visible="false" CssClass="btn btn-default" TabIndex="10"
                                                    Text="Submit" OnClick="BtnSave2_Click" />
                                            </td>
                                            <td class="col-xs-5" style="padding: 5px; text-align: right; margin: 5px" colspan="5">
                                                <asp:Label ID="Label1" runat="server" Visible="false" CssClass="LBLBLACK">Report as on date</asp:Label>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr id="divPrint" runat="server" style="width: 50%">
                                <td align="center" style="padding: 5px; margin: 5px;" valign="top">
                                    <asp:GridView ID="grdDetails" runat="server" AutoGenerateColumns="true" CellPadding="5"
                                        ShowFooter="True" PageSize="20" OnPageIndexChanging="grdDetails_PageIndexChanging" Width="50%" OnRowDataBound="grdDetails_RowDataBound">
                                        <HeaderStyle Height="40px" CssClass="GridviewScrollC1HeaderWrap" Font-Bold="true" BackColor="#6666ff" />
                                        <RowStyle CssClass="GridviewScrollC1Item" BorderWidth="2PX" />
                                        <PagerStyle CssClass="GridviewScrollC1Pager" />
                                        <FooterStyle Height="40px" CssClass="GridviewScrollC1Header" BackColor="#6666ff" />
                                        <AlternatingRowStyle CssClass="GridviewScrollC1Item2" />
                                        <Columns>
                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S No">
                                                <ItemTemplate>
                                                    <%# Container.DataItemIndex + 1%>
                                                    <asp:HiddenField ID="HdfQueid" runat="server" />
                                                    <asp:HiddenField ID="HdfApprovalid" runat="server" />
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Center" />
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </td>
                            </tr>
                            <tr id="divExport" visible="false" runat="server">
                                <td align="center" style="text-align: center;" valign="top">
                                    <asp:GridView ID="grdExport" runat="server" AutoGenerateColumns="true" ShowFooter="true">
                                        <Columns>
                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center"
                                                HeaderText="S.No">
                                                <ItemTemplate>
                                                    <%# Container.DataItemIndex + 1%>
                                                </ItemTemplate>
                                                <ItemStyle CssClass="text-center" HorizontalAlign="Center" />
                                            </asp:TemplateField>
                                        </Columns>
                                        <RowStyle Wrap="true" />
                                    </asp:GridView>
                                </td>
                            </tr>
                            <tr>
                                <td align="center" style="padding: 5px; margin: 5px; text-align: center;" valign="top">&nbsp;
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



