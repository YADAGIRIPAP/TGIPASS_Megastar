<%@ Page Title=":: TS-iPASS ::  " Language="C#" MasterPageFile="~/UI/TSiPASS/CCMaster.master" EnableEventValidation="false"
    AutoEventWireup="true" CodeFile="SanctionedIncentivesDCIP.aspx.cs" Inherits="TSTBDCReg1" %>

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
    </style>

    <script type="text/javascript" language="javascript">

        function OpenPopup() {

            window.open("Lookups/LookupBDC.aspx", "List", "scrollbars=yes,resizable=yes,width=1000,height=650;display = block;position=absolute");

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
            <li class="active"><i class="fa fa-edit"></i><a href="#">Sanctioned incentives(DIPC)</a>
            </li>
        </ol>
    </div>
    <div align="left">
        <div class="row" align="left">
            <div class="col-lg-11">
                <div class="panel panel-default">
                    <div class="panel-heading" align="center">
                        <h3 class="panel-title" style="font-weight: bold;">
                            Sanctioned incentives(DIPC)&nbsp; <a id="A1" href="#" onserverclick="BtnPDF_Click"
                                runat="server">
                                <img src="../../Resource/Images/pdf-icon.png" width="20px;" height="20px;" style="float: right;"
                                    alt="PDF" /></a> <a id="A2" href="#" onserverclick="BtnSave2_Click1" runat="server">
                                        <img src="../../Resource/Images/Excel-icon.png" width="20px;" height="20px;" style="float: right;"
                                            alt="Excel" /></a></h3>
                    </div>
                    <div class="panel-body">
                        <table align="center" cellpadding="10" cellspacing="5" style="width: 98%">
                            <tr>
                                <td align="left" style="padding: 5px; margin: 5px" valign="top">
                                    <table cellpadding="4" cellspacing="5">
                                        <tr>
                                            <td style="text-align: left">
                                                <asp:HyperLink CssClass="btn btn-link" ID="HyperLink1" runat="server" NavigateUrl="~/UI/TSiPASS/ReportsDashboardNew.aspx"
                                                    Text="<< Back">
                                                </asp:HyperLink>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="col-xs-3" style="padding: 5px; margin: 5px">
                                                <div class="input-group">
                                                    <div style="width: 140px" class="input-group-addon">
                                                        Category</div>
                                                    <asp:DropDownList ID="ddlCategory" runat="server" class="form-control txtbox" Height="33px"
                                                        TabIndex="1" Width="180px">
                                                        <asp:ListItem>--Select--</asp:ListItem>
                                                        <asp:ListItem>ST</asp:ListItem>
                                                        <asp:ListItem>SC</asp:ListItem>
                                                        <asp:ListItem>GENERAL</asp:ListItem>
                                                    </asp:DropDownList>
                                                </div>
                                            </td>
                                            <td class="col-xs-3" style="padding: 5px; margin: 5px">
                                                <div class="input-group">
                                                    <div style="width: 140px" class="input-group-addon">
                                                        District</div>
                                                    <asp:DropDownList ID="ddldistrict" runat="server" class="form-control txtbox" Height="33px"
                                                        TabIndex="1" Width="180px">
                                                        <asp:ListItem>--Select--</asp:ListItem>
                                                        <asp:ListItem>Adilabad</asp:ListItem>
                                                        <asp:ListItem>Hyderabad</asp:ListItem>
                                                        <asp:ListItem>Karimnagar</asp:ListItem>
                                                        <asp:ListItem>Khammam</asp:ListItem>
                                                        <asp:ListItem>mahaboobnagar</asp:ListItem>
                                                        <asp:ListItem>Nizamabad</asp:ListItem>
                                                        <asp:ListItem>Nalgonda</asp:ListItem>
                                                        <asp:ListItem>Rangareddy-1</asp:ListItem>
                                                        <asp:ListItem>Rangareddy-2</asp:ListItem>
                                                        <asp:ListItem>Warangal</asp:ListItem>
                                                    </asp:DropDownList>
                                                </div>
                                            </td>
                                            <td class="col-xs-3" style="padding: 5px; margin: 5px">
                                                <div class="input-group">
                                                    <div style="width: 140px" class="input-group-addon">
                                                        Type of Incentive</div>
                                                    <asp:DropDownList ID="ddltypeofncentive" runat="server" class="form-control txtbox"
                                                        Height="33px" TabIndex="1" Width="180px">
                                                        <asp:ListItem>--Select--</asp:ListItem>
                                                        <asp:ListItem>INVESTMENT SUBSIDY</asp:ListItem>
                                                        <asp:ListItem>Pavala  Vaddi</asp:ListItem>
                                                        <asp:ListItem>Power Tariff</asp:ListItem>
                                                        <asp:ListItem>Sales Tax</asp:ListItem>
                                                        <asp:ListItem>Stamp Duty</asp:ListItem>
                                                        <asp:ListItem Value="LC">Land Cast</asp:ListItem>
                                                        <asp:ListItem Value="LC">Land Conversion</asp:ListItem>
                                                    </asp:DropDownList>
                                                </div>
                                            </td>
                                            <td style="padding: 5px; margin: 5px" align="right">
                                                <asp:Button ID="Button1" runat="server" CssClass="btn btn-default" TabIndex="10"
                                                    Height="33px" Text="Submit" OnClick="BtnSave1_Click" />
                                            </td>
                                           <%-- <td class="col-xs-5" style="padding: 5px; text-align: right; margin: 5px">
                                                <asp:Label ID="lblstate11" runat="server" CssClass="LBLBLACK"></asp:Label>
                                            </td>--%>
                                        </tr>
                                        <tr>
                                            <td class="col-xs-3" style="padding: 5px; margin: 5px">
                                                <div class="input-group">
                                                    <div style="width: 200px" class="input-group-addon">
                                                        Name of Enterprise</div>
                                                    <asp:TextBox ID="txtindustrialName" runat="server" class="form-control txtbox" Height="33px"
                                                        MaxLength="100" TabIndex="1" ValidationGroup="group" Width="180px"></asp:TextBox>
                                                </div>
                                            </td>
                                            <td class="col-xs-3" style="padding: 5px; margin: 5px">
                                                <div class="input-group">
                                                    <div style="width: 200px" class="input-group-addon">
                                                        EM No / Udyog Aadhar No</div>
                                                    <asp:TextBox ID="txtEMpartnumber" runat="server" class="form-control txtbox" Height="33px"
                                                        MaxLength="100" TabIndex="1" ValidationGroup="group" Width="180px"></asp:TextBox>
                                                </div>
                                            </td>
                                           <%-- <td style="padding: 5px; margin: 5px" align="right">
                                                <asp:Button ID="Button2" runat="server" CssClass="btn btn-default" TabIndex="10"
                                                    Height="33px" Text="Submit" OnClick="BtnSave1_Click" />
                                            </td>--%>
                                            <td class="col-xs-5" style="padding: 5px; text-align: right; margin: 5px">
                                                <asp:Label ID="Label1" runat="server" CssClass="LBLBLACK">Report as on date</asp:Label>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td align="left" style="padding: 5px; margin: 5px" valign="top">
                                    <asp:Panel ID="Panel1" runat="server" Style="width: 1200px" ScrollBars=Both>
                                        <asp:GridView ID="grdDetails" CssClass="floatingTable" runat="server" AutoGenerateColumns="true" CellPadding="5"
                                            OnRowDataBound="grdDetails_RowDataBound" ShowFooter="True" Width="100%">
                                            <HeaderStyle Height="40px" CssClass="GridviewScrollC1HeaderWrap" />
                                        <RowStyle CssClass="GridviewScrollC1Item" />
                                        <PagerStyle CssClass="GridviewScrollC1Pager" />
                                        <FooterStyle Height="40px" CssClass="GridviewScrollC1Header" />
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
                                            </Columns>
                                        </asp:GridView>
                                    </asp:Panel>
                                </td>
                            </tr>
                            <tr id="divExport" visible="false" runat="server">
                                <td align="center" style="text-align: center;" valign="top">
                                    <asp:GridView ID="grdExport" runat="server" AutoGenerateColumns="true" ShowFooter="true">
                                        
                                        <Columns>
                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" HeaderText="S.No">
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
                                <td style="padding: 5px; margin: 5px" align="center">
                                    &nbsp;<tr>
                                        <td align="center" style="padding: 5px; margin: 5px">
                                            &nbsp;
                                        </td>
                                    </tr>
                                    
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
                    </ContentTemplate> </asp:UpdatePanel>
                </div>
            </div>
        </div>
    </div>
    
    <%--</div>
       </td>
        </tr>
    </table>--%>
</asp:Content>
