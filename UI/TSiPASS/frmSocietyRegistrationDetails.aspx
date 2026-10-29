<%@ Page Title="" Language="C#" MasterPageFile="~/UI/TSiPASS/CCMaster.master" AutoEventWireup="true" CodeFile="frmSocietyRegistrationDetails.aspx.cs" Inherits="UI_TSiPASS_frmSocietyRegistrationDetails" %>

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
                    <li><i class="fa fa-dashboard"></i><a href="#">Society Registration Details </a></li>
                </ol>
            </div>
            <div align="center">
                <div class="row" align="center">
                    <div class="col-lg-11">
                        <div class="panel panel-primary">
                            <div class="panel-heading">
                                <h3 class="panel-title">Society Registration Details</h3>
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
                                                Society 
                                            </div>
                                            <asp:DropDownList ID="rdbSociety" runat="server" class="form-control txtbox">
                                                <asp:ListItem Text="--Select--" Value="Select"></asp:ListItem>
                                                <asp:ListItem Text="Society Name Change" Value="Name"></asp:ListItem>
                                                <asp:ListItem Text="Society Address Change" Value="Address"></asp:ListItem>
                                                <asp:ListItem Text="Society Dissolution" Value="Dissolution"></asp:ListItem>
                                                <asp:ListItem Text="Society Partner Change" Value="PartnerChange"></asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-12" style="padding-top: 20px; display: flex; justify-content: center; align-items: center;">
                                    <asp:Button ID="btnsave" runat="server" Text="Get Search" CssClass="btn btn-rounded  btn-info btn-lg" OnClick="btnsave_Click"
                                        Width="150px" Style="background-color: #007bff; color: white;" />
                                </div>
                                <div runat="server" visible="false" id="trsocietynamechange">
                                    <div class="col-md-12" style="margin-top: 20px;">
                                        <asp:GridView ID="grdsocietynamechange" runat="server" AutoGenerateColumns="false"
                                            CellPadding="5" ForeColor="#333333" Height="62px"
                                            ShowFooter="false" Width="100%" EmptyDataText="No records found for the selected date..!" OnRowCommand="grdsocietynamechange_RowCommand">
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
                                                <asp:TemplateField HeaderText="Society Registration No">
                                                    <ItemTemplate>
                                                        <asp:Label runat="server" ID="lblsocietyRegistrationNo" Text='<%# Bind("societyRegistrationNo") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Society Registration Year">
                                                    <ItemTemplate>
                                                        <asp:Label runat="server" ID="lblsocietyRegistrationYear" Text='<%# Bind("societyRegistrationYear") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Society Previous Name">
                                                    <ItemTemplate>
                                                        <asp:Label runat="server" ID="lblsocietyPreviousName" Text='<%# Bind("societyPreviousName") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Society New Name">
                                                    <ItemTemplate>
                                                        <asp:Label runat="server" ID="lblsocietyNewName" Text='<%# Bind("societyNewName") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Approved By">
                                                    <ItemTemplate>
                                                        <asp:Label runat="server" ID="lblapprovedBy" Text='<%# Bind("approvedBy") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Approved Date">
                                                    <ItemTemplate>
                                                        <asp:Label runat="server" ID="lblapprovedDate" Text='<%# Bind("approvedDate") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Application No">
                                                    <ItemTemplate>
                                                        <asp:Label runat="server" ID="lblapplicationNo" Text='<%# Bind("applicationNo") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Registration Dist">
                                                    <ItemTemplate>
                                                        <asp:Label runat="server" ID="lblregistrationDist" Text='<%# Bind("registrationDist") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Action">
                                                    <ItemTemplate>
                                                        <asp:Button ID="btnAction" runat="server" Text="View" CommandName="Action"
                                                            CommandArgument="<%# Container.DataItemIndex %>" />
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

                                <div runat="server" visible="false" id="trsocietyAddresschange">
                                    <div class="col-md-12" style="margin-top: 20px;">
                                        <asp:GridView ID="grdsocietyAddresschange" runat="server" AutoGenerateColumns="False"
                                            CellPadding="5" ForeColor="#333333" Height="62px"
                                            ShowFooter="False" Width="100%" EmptyDataText="No records ound for the selected date..!" OnRowCommand="grdsocietynamechange_RowCommand">
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
                                                <asp:TemplateField HeaderText="Society Name">
                                                    <ItemTemplate>
                                                        <asp:Label runat="server" ID="lblsocietyName" Text='<%# Bind("societyName") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Society Registration No.">
                                                    <ItemTemplate>
                                                        <asp:Label runat="server" ID="lblsocietyRegistrationNo" Text='<%# Bind("societyRegistrationNo") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Society Registration Year">
                                                    <ItemTemplate>
                                                        <asp:Label runat="server" ID="lblsocietyRegistrationYear" Text='<%# Bind("societyRegistrationYear") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Society New Address">
                                                    <ItemTemplate>
                                                        <asp:Label runat="server" ID="lblsocietyNewAddress" Text='<%# Bind("societyNewAddress") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Application No">
                                                    <ItemTemplate>
                                                        <asp:Label runat="server" ID="lblapplicationNo" Text='<%# Bind("applicationNo") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Registration Dist">
                                                    <ItemTemplate>
                                                        <asp:Label runat="server" ID="lblregistrationDist" Text='<%# Bind("registrationDist") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Action">
                                                    <ItemTemplate>
                                                        <asp:Button ID="btnAction" runat="server" Text="View" CommandName="Action"
                                                            CommandArgument="<%# Container.DataItemIndex %>" />
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

                                <div runat="server" visible="false" id="trsocietydisslotion">
                                    <div class="col-md-12" style="margin-top: 20px;">
                                        <asp:GridView ID="grdsocietydisslotion" runat="server" AutoGenerateColumns="False"
                                            CellPadding="5" ForeColor="#333333" Height="62px"
                                            ShowFooter="False" Width="100%" EmptyDataText="No records found for the selected date..!" OnRowCommand="grdsocietynamechange_RowCommand">
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
                                                <asp:TemplateField HeaderText="Society Name">
                                                    <ItemTemplate>
                                                        <asp:Label runat="server" ID="lblsocietyName" Text='<%# Bind("societyName") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Society Registration No.">
                                                    <ItemTemplate>
                                                        <asp:Label runat="server" ID="lblsocietyRegistrationNo" Text='<%# Bind("societyRegistrationNo") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Society Registration Year">
                                                    <ItemTemplate>
                                                        <asp:Label runat="server" ID="lblsocietyRegistrationYear" Text='<%# Bind("societyRegistrationYear") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Society Dissolution Date">
                                                    <ItemTemplate>
                                                        <asp:Label runat="server" ID="lblsocietyDissolutionDate" Text='<%# Bind("societyDissolutionDate") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Application No">
                                                    <ItemTemplate>
                                                        <asp:Label runat="server" ID="lblapplicationNo" Text='<%# Bind("applicationNo") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Registration Dist">
                                                    <ItemTemplate>
                                                        <asp:Label runat="server" ID="lblregistrationDist" Text='<%# Bind("registrationDist") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Action">
                                                    <ItemTemplate>
                                                        <asp:Button ID="btnAction" runat="server" Text="View" CommandName="Action"
                                                            CommandArgument="<%# Container.DataItemIndex %>" />
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

                                <div runat="server" visible="false" id="trsocietyPartnerchange">
                                    <div class="col-md-12" style="margin-top: 20px;">
                                        <asp:GridView ID="grdsocietyPartnerchange" runat="server" AutoGenerateColumns="False"
                                            CellPadding="5" ForeColor="#333333" Height="62px"
                                            ShowFooter="False" Width="100%" EmptyDataText="No records found for the selected date..!" OnRowCommand="grdsocietynamechange_RowCommand">
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
                                                <asp:BoundField DataField="SocietyName" HeaderText="Society Name" />
                                                <asp:BoundField DataField="SocietyRegistrationNo" HeaderText="Registration No" />
                                                <asp:BoundField DataField="SocietyRegistrationYear" HeaderText="Registration Year" />
                                                <asp:TemplateField HeaderText="Application No">
                                                    <ItemTemplate>
                                                        <asp:Label runat="server" ID="lblapplicationNo" Text='<%# Bind("ApplicationNo") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="RegistrationDist" HeaderText="Registration District" />
                                                <asp:BoundField DataField="ExistingPartners" HeaderText="Existing Partners" />
                                                <asp:BoundField DataField="OutgoingPartners" HeaderText="Outgoing Partners" />
                                                <asp:BoundField DataField="IncomingPartners" HeaderText="Incoming Partners" />
                                                <asp:TemplateField HeaderText="Action">
                                                    <ItemTemplate>
                                                        <asp:Button ID="btnAction" runat="server" Text="View" CommandName="Action"
                                                            CommandArgument="<%# Container.DataItemIndex %>" />
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

                                <tr>
                                    <td align="center" style="padding: 5px; margin: 5px"></td>
                                </tr>
                                <asp:HiddenField ID="hdfID" runat="server" />
                                <asp:HiddenField ID="hdfFlagID" runat="server" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <asp:UpdateProgress ID="UpdateProgress" runat="server" AssociatedUpdatePanelID="updatepanel1">
                <ProgressTemplate>
                    <div class="overlay">
                        <%--<div style=" z-index: 1000; margin-left: 350px;margin-top:200px;opacity: 1;-moz-opacity: 1;">--%>
                        <div style="z-index: 1000; margin-left: 465px; margin-top: 170px; opacity: 1; -moz-opacity: 1;">
                            <img alt="" src="../../Resource/Images/Processing.gif" />
                        </div>
                    </div>
                </ProgressTemplate>
            </asp:UpdateProgress>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
