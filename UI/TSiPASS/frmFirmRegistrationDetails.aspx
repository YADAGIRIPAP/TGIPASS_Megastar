<%@ Page Title="" Language="C#" MasterPageFile="~/UI/TSiPASS/CCMaster.master" AutoEventWireup="true" CodeFile="frmFirmRegistrationDetails.aspx.cs" Inherits="UI_TSiPASS_frmFirmRegistrationDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript" language="javascript">    </script>
    <script src="../../Resource/Scripts/js/validations.js" type="text/javascript"></script>
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
  
    <asp:UpdatePanel ID="updatepanel1" runat="server">
        <ContentTemplate>
            <div align="left">
                <ol class="breadcrumb">
                    You are here &nbsp;!&nbsp; &nbsp; &nbsp;
                    <li><i class="fa fa-dashboard"></i><a href="#">Registration of Partnership</a> </li>
                </ol>
            </div>
            <div align="center">
                <div class="row" align="center">
                    <div class="col-lg-11">
                        <div class="panel panel-primary">
                            <div class="panel-heading">
                                <h3 class="panel-title">Registration of Partnership Firms and Societies</h3>
                            </div>
                            <div class="panel-body">
                                <div class="col-md-12 mt-3" style="margin-top: 20px;">
                                    <div class="col-md-4">
                                        <div class="input-group">
                                            <div class="input-group-addon">
                                                From Date
                                            </div>
                                            <asp:TextBox ID="txtFromDate" runat="server" class="form-control txtbox" Height="28px" MaxLength="40" onkeypress="NumberOnly()" TabIndex="1" ValidationGroup="group" Width="125px"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-md-4">
                                        <div class="input-group">
                                            <div class="input-group-addon">
                                                To Date
                                            </div>
                                            <asp:TextBox ID="txtTodate" runat="server" class="form-control txtbox" Height="28px" MaxLength="40" onkeypress="NumberOnly()" TabIndex="1" ValidationGroup="group" Width="125px"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-md-4">
                                        <div class="input-group">
                                            <div class="input-group-addon">
                                                <%-- AutoPostBack="true" OnSelectedIndexChanged="ddlFirms_SelectedIndexChanged"--%>
                                                                         Firms 
                                            </div>
                                            <asp:DropDownList ID="ddlFirms" runat="server" class="form-control txtbox">
                                                <asp:ListItem Text="--Select--" Value="Select"></asp:ListItem>
                                                <asp:ListItem Text=" &nbsp; Firm Name Change  &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" Value="Name"></asp:ListItem>
                                                <asp:ListItem Text="&nbsp; Firm Address Change &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" Value="Address"></asp:ListItem>
                                                <asp:ListItem Text=" &nbsp; Firm Partner Change &nbsp;&nbsp;&nbsp;&nbsp;" Value="Partner"></asp:ListItem>
                                                <asp:ListItem Text=" &nbsp; Firm Partner Address Change &nbsp;&nbsp;&nbsp;&nbsp;" Value="PartnerAddress"></asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                </div>

                                <div class="col-md-12" style="padding-top: 20px; display: flex; justify-content: center; align-items: center;">
                                    <asp:Button ID="btnsave" runat="server" Text="Get Search" CssClass="btn btn-rounded  btn-info btn-lg" OnClick="btnsave_Click"
                                        Width="150px" Style="background-color: #007bff; color: white;" />
                                </div>
                                <div runat="server" visible="false" id="trgrid">
                                    <div class="col-md-12" style="margin-top: 20px;">
                                        <asp:GridView ID="grdfirmnamechange" runat="server" AutoGenerateColumns="false"
                                            CellPadding="5" ForeColor="#333333" Height="62px" OnRowCommand="grdfirmnamechange_RowCommand"
                                            ShowFooter="True" Width="100%" EmptyDataText="No records found for the selected date..!">
                                            <FooterStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                            <RowStyle BackColor="#EBF2FE" HorizontalAlign="Left" VerticalAlign="Middle" />
                                            <Columns>
                                                <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S No">
                                                    <ItemTemplate>
                                                        <%# Container.DataItemIndex + 1%>
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle Width="50px" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="firmRegistrationNo">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblRegister" runat="server" Text='<%# Eval("firmRegistrationNo") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="firmRegistrationYear">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblFirmYear" runat="server" Text='<%# Eval("firmRegistrationYear") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="firmPreviousName">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblFirmPrevious" runat="server" Text='<%# Eval("firmPreviousName") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="firmNewName">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblFirmNew" runat="server" Text='<%# Eval("firmNewName") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="approvedBy">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblApproveBy" runat="server" Text='<%# Eval("approvedBy") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="approvedDate">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblApproveDate" runat="server" Text='<%# Eval("approvedDate") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="applicationNo">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblApplicationNo" runat="server" Text='<%# Eval("applicationNo") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="registrationDist">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblRegDist" runat="server" Text='<%# Eval("registrationDist") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Action">
                                                    <ItemTemplate>
                                                        <asp:Button ID="btnAction" runat="server" Text="View"  CommandName="Action"
                                                            CommandArgument="<%# Container.DataItemIndex %>"  />
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:TemplateField>
                                            </Columns>
                                            <PagerStyle BackColor="#013161" ForeColor="White" HorizontalAlign="Center" />
                                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                            <HeaderStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                            <EditRowStyle BackColor="#B9D684" />
                                            <AlternatingRowStyle BackColor="White" />
                                        </asp:GridView>
                                    </div>
                                </div>

                                <div id="trfirmAddresschange" runat="server" visible="false">
                                    <div class="col-md-12" style="margin-top: 20px;">
                                        <asp:GridView ID="grdfirmAddresschange" runat="server" AutoGenerateColumns="false" CellPadding="5" EmptyDataText="No records found for the selected date..!" ForeColor="#333333" Height="62px" OnRowCommand="grdfirmnamechange_RowCommand" ShowFooter="True" Width="100%">
                                            <FooterStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                            <RowStyle BackColor="#EBF2FE" HorizontalAlign="Left" VerticalAlign="Middle" />
                                            <Columns>
                                                <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S No">
                                                    <ItemTemplate>
                                                        <%# Container.DataItemIndex + 1%>
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle Width="50px" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="firmName">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblfirmName" runat="server" Text='<%# Eval("firmName") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="firmRegistrationNo">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblfirmRegistrationNo" runat="server" Text='<%# Eval("firmRegistrationNo") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="firmRegistrationYear">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblfirmRegistrationYear" runat="server" Text='<%# Eval("firmRegistrationYear") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="firmNewAddress">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblfirmNewAddress" runat="server" Text='<%# Eval("firmNewAddress") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="applicationNo">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblApplicationNo" runat="server" Text='<%# Eval("applicationNo") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="registrationDist">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblregistrationDist" runat="server" Text='<%# Eval("registrationDist") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Action">
                                                    <ItemTemplate>
                                                        <asp:Button ID="btnAction" runat="server" CommandArgument="<%# Container.DataItemIndex %>" CommandName="Action" Text="View" />
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:TemplateField>
                                            </Columns>
                                            <PagerStyle BackColor="#013161" ForeColor="White" HorizontalAlign="Center" />
                                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                            <HeaderStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                            <EditRowStyle BackColor="#B9D684" />
                                            <AlternatingRowStyle BackColor="White" />
                                        </asp:GridView>
                                    </div>
                                </div>

                                <div id="trfirmPartnerchange" runat="server" visible="false">
                                    <div class="col-md-12" style="margin-top: 20px;">
                                        <asp:GridView ID="grdfirmPartnerchange" runat="server" AutoGenerateColumns="False" CellPadding="5" EmptyDataText="No records found for the selected date..!" ForeColor="#333333" Height="62px" OnRowCommand="grdfirmnamechange_RowCommand" ShowFooter="False" Width="100%">
                                            <FooterStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                            <RowStyle BackColor="#EBF2FE" HorizontalAlign="Left" VerticalAlign="Middle" />
                                            <Columns>
                                                <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S No">
                                                    <ItemTemplate>
                                                        <%# Container.DataItemIndex + 1%>
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle Width="50px" />
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="FirmName" HeaderText="Firm Name" />
                                                <asp:BoundField DataField="FirmRegistrationNo" HeaderText="Registration No" />
                                                <asp:BoundField DataField="FirmRegistrationYear" HeaderText="Registration Year" />
                                                <%--  <asp:BoundField DataField="ApplicationNo" HeaderText="Application No" />--%>
                                                <asp:TemplateField HeaderText="Application No">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblApplicationNo" runat="server" Text='<%# Eval("ApplicationNo") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="RegistrationDist" HeaderText="Registration District" />
                                                <asp:BoundField DataField="ExistingPartners" HeaderText="Existing Partners" />
                                                <asp:BoundField DataField="OutgoingPartners" HeaderText="Outgoing Partners" />
                                                <asp:BoundField DataField="IncomingPartners" HeaderText="Incoming Partners" />
                                                <asp:TemplateField HeaderText="Action">
                                                    <ItemTemplate>
                                                        <asp:Button ID="btnAction" runat="server" CommandArgument="<%# Container.DataItemIndex %>" CommandName="Action" Text="View" />
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:TemplateField>
                                            </Columns>
                                            <PagerStyle BackColor="#013161" ForeColor="White" HorizontalAlign="Center" />
                                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                            <HeaderStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                            <EditRowStyle BackColor="#B9D684" />
                                            <AlternatingRowStyle BackColor="White" />
                                        </asp:GridView>
                                    </div>
                                </div>

                                <div id="trfirmPartneraddresschange" runat="server" visible="false">
                                    <div class="col-md-12" style="margin-top: 20px;">
                                        <asp:GridView ID="grdfirmPartneraddresschange" runat="server" AutoGenerateColumns="false" CellPadding="5" EmptyDataText="No records found for the selected date..!" ForeColor="#333333" Height="62px" OnRowCommand="grdfirmnamechange_RowCommand" ShowFooter="True" Width="100%">
                                            <FooterStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                            <RowStyle BackColor="#EBF2FE" HorizontalAlign="Left" VerticalAlign="Middle" />
                                            <Columns>
                                                <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S No">
                                                    <ItemTemplate>
                                                        <%# Container.DataItemIndex + 1%>
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle Width="50px" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="firmName">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblName" runat="server" Text='<%# Eval("firmName") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="firmRegistrationNo">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblRegistrationNo" runat="server" Text='<%# Eval("firmRegistrationNo") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="firmRegistrationYear">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblRegistrationYear" runat="server" Text='<%# Eval("firmRegistrationYear") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="partnerAddressDetailsList">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblpartnerAddressDetailsList" runat="server" Text='<%# Eval("partnerAddressDetailsList") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="applicationNo">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblApplicationNo" runat="server" Text='<%# Eval("applicationNo") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="registrationDist">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblregistrationDist" runat="server" Text='<%# Eval("registrationDist") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Action">
                                                    <ItemTemplate>
                                                        <asp:Button ID="btnAction" runat="server" CommandArgument="<%# Container.DataItemIndex %>" CommandName="Action" Text="View" />
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:TemplateField>
                                            </Columns>
                                            <PagerStyle BackColor="#013161" ForeColor="White" HorizontalAlign="Center" />
                                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                            <HeaderStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                            <EditRowStyle BackColor="#B9D684" />
                                            <AlternatingRowStyle BackColor="White" />
                                        </asp:GridView>
                                    </div>
                                </div>


                                <div class="col-md-12" style="margin-top: 20px;">
                                    <div id="success" runat="server" class="alert alert-success" visible="false">
                                        <a aria-label="close" class="close" data-dismiss="alert" href="AddQualification.aspx">×</a> <strong>Success!</strong><asp:Label ID="lblmsg" runat="server"></asp:Label>
                                    </div>
                                    <div id="Failure" runat="server" class="alert alert-danger" visible="false">
                                        <a aria-label="close" class="close" data-dismiss="alert" href="#">×</a> <strong>Warning!</strong>
                                        <asp:Label ID="lblmsg0" runat="server"></asp:Label>
                                    </div>
                                </div>


                            </div>
                            <%--  <tr>
                            <td align="center" style="padding: 5px; margin: 5px">
                                <table cellpadding="2" style="width: 100%">
                                    <tr>
                                        <td style="width: 417px">&nbsp;
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>--%>
                            <tr>
                                <td align="center" style="padding: 5px; margin: 5px"></td>
                            </tr>
                            <asp:HiddenField ID="hdfID" runat="server" />
                            <asp:HiddenField ID="hdfFlagID" runat="server" />
                        </div>
                    </div>
                </div>
            </div>
            <asp:UpdateProgress ID="UpdateProgress" runat="server" AssociatedUpdatePanelID="updatepanel1">
                <ProgressTemplate>
                    <div class="overlay">
                        <div style="z-index: 1000; margin-left: 465px; margin-top: 170px; opacity: 1; -moz-opacity: 1;">
                            <img alt="" src="../../Resource/Images/Processing.gif" />
                        </div>
                    </div>
                </ProgressTemplate>
            </asp:UpdateProgress>
        </ContentTemplate>
    </asp:UpdatePanel>
    <%--</div>
       </td>
        </tr>
    </table>--%>
</asp:Content>

