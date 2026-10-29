<%@ Page Title="" Language="C#" MasterPageFile="~/UI/TSIPASS/CCMaster.master" AutoEventWireup="true" CodeFile="frmIncentiveGmedit.aspx.cs" Inherits="UI_TSIPASS_frmIncentiveGmedit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script src="../../Resource/Scripts/js/validations.js" type="text/javascript"></script>
    <link href="assets/css/basic.css" rel="stylesheet" />
    <script type="text/javascript">
        function ConfirmDelete() {
            var x = confirm("Are you sure you want to delete?");
            if (x)
                return true;
            else
                return false;
        }
        function ConfirmUpdate() {
            var x = confirm("Are you sure you want to Update?");
            if (x)
                return true;
            else
                return false;
        }
    </script>

    <style>
        .page-head-linenew {
            font-size: 2px;
            text-transform: uppercase;
            color: #000;
            font-weight: 800;
            padding-bottom: 2px;
            border-bottom: 4px solid #00CA79;
            margin-bottom: 5px;
        }

        .page-subhead-linenew {
            font-size: 14px;
            padding-top: 1px;
            padding-bottom: 20px;
            font-style: italic;
            margin-bottom: 30px;
            border-bottom: 1px dashed #00CA79;
        }

        .update {
            position: fixed;
            top: 0px;
            left: 0px;
            min-height: 100%;
            min-width: 100%;
            background-image: url("../../Images/ajax-loaderblack.gif"); /*background-image: url("Images/spinner_60.gif");*/
            background-position: center center;
            background-repeat: no-repeat; /*background-color: #e4e4e6;*/
            background-color: #535252;
            z-index: 500 !important;
            opacity: 0.6;
            overflow: hidden;
        }
    </style>
    <asp:UpdateProgress ID="UpdateProgress" runat="server" AssociatedUpdatePanelID="updatepanel1">
        <ProgressTemplate>
            <div class="update">
            </div>
        </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table bgcolor="White" width="100%" style="font-family: Verdana;">
                <tr>
                    <td align="left" colspan="10" style="padding: 10px; margin: 5px; font-weight: bold;">A.
                                            <asp:Label ID="lblIndustries1" runat="server" Font-Bold="True" Font-Size="15px">COMMON DETAILS OF THE ENTREPRENUER</asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="padding: 10px; margin: 5px; font-weight: bold;">1. </td>
                    <td style="text-align: left; width: 250px; padding: 5px; margin: 5px">Name of the  Managing Director /Managing Partner / Proprietor</td>
                    <td style="padding: 5px; margin: 5px">:
                    </td>
                    <td style="text-align: left; padding: 5px; margin: 5px">
                        <span>
                            <asp:Label ID="txtApplicantName" runat="server"></asp:Label>
                        </span>
                    </td>
                    <td style="padding: 10px; margin: 5px; font-weight: bold;">2. </td>
                    <td style="text-align: left; padding: 5px; margin: 5px">Unit Name</td>

                    <td style="padding: 5px; margin: 5px">:
                    </td>
                    <td style="padding: 5px; margin: 5px">
                        <span>
                            <asp:Label ID="txtUnitname" runat="server"></asp:Label>
                        </span>

                    </td>
                </tr>
                <tr>
                    <td style="padding: 10px; margin: 5px; font-weight: bold;">7. </td>
                    <td style="text-align: left; padding: 10px; margin: 5px;">Type of Organization</td>
                    <td style="padding: 5px; margin: 5px">:
                    </td>
                    <td style="text-align: left; padding: 10px; margin: 5px;">
                        <span>
                            <asp:Label ID="ddltypeofOrg" runat="server"></asp:Label>
                        </span>
                    </td>
                    <td style="padding: 10px; margin: 5px; font-weight: bold;">6. </td>
                    <td style="padding: 5px; margin: 5px">Category</td>
                    <td style="padding: 5px; margin: 5px">:
                    </td>
                    <td style="padding: 5px; margin: 5px">
                        <asp:Label ID="ddlCategory" runat="server"></asp:Label>
                    </td>

                </tr>

                <tr>
                    <td colspan="10">

                        <div>
                            <h1 class="page-head-linenew" align="left" style="font-size: smaller"></h1>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td align="left" colspan="10" style="padding: 10px; margin: 5px; font-weight: bold;">B.
                                            <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="15px">Editable fields</asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="left" colspan="2" style="padding: 10px; margin: 5px;">Please Select Parameter To Edit
                    </td>
                    <td align="left" colspan="2" style="padding: 10px; margin: 5px;">
                        <asp:DropDownList ID="ddlselect" runat="server" repeatdirection="Horizontal" OnSelectedIndexChanged="ddlselect_SelectedIndexChanged"
                            class="form-control txtbox" AutoPostBack="true" TabIndex="1" Height="33px" Width="250px">
                            <asp:ListItem>--Select--</asp:ListItem>
                            <asp:ListItem Value="1">Applicant Social Status</asp:ListItem>
                            <asp:ListItem Value="2">Finacial Years</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr id="trcate" runat="server" visible="false">
                    <td colspan="10">
                        <table bgcolor="White" width="100%" style="font-family: Verdana;">
                            <tr>
                                <td style="text-align: left; padding: 10px; margin: 5px; width: 200px">Old Social Status</td>
                                <td style="padding: 5px; margin: 5px; width: 10px">:
                                </td>
                                <td style="text-align: left; padding: 10px; margin: 5px;">
                                    <span>
                                        <asp:Label ID="rblCastenew" runat="server"></asp:Label>
                                        <asp:Label ID="Label2" runat="server"></asp:Label>
                                    </span>
                                </td>
                            </tr>
                            <tr>
                                <td style="padding: 5px; margin: 5px; text-align: left;">Social Status<span style="font-weight: bold; color: Red;">*</span>
                                </td>
                                <td style="padding: 5px; margin: 5px">:
                                </td>
                                <td style="padding: 5px; margin: 5px; text-align: left;" colspan="6">
                                    <asp:DropDownList ID="rblCaste" runat="server" class="form-control txtbox" RepeatDirection="Horizontal"
                                        TabIndex="1" Height="33px" Width="180px" OnSelectedIndexChanged="rblCaste_SelectedIndexChanged"
                                        AutoPostBack="True">
                                        <asp:ListItem Value="0">SELECT</asp:ListItem>
                                        <asp:ListItem Value="1">General</asp:ListItem>
                                        <asp:ListItem Value="2">OBC</asp:ListItem>
                                        <asp:ListItem Value="3">SC</asp:ListItem>
                                        <asp:ListItem Value="4">ST</asp:ListItem>
                                        <asp:ListItem Value="5">Minority</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr id="trsubcaste" runat="server" visible="false">
                                <td style="padding: 5px; margin: 5px; text-align: left;">Sub Caste<span style="font-weight: bold; color: Red;">*</span>
                                </td>
                                <td style="padding: 5px; margin: 5px">:
                                </td>
                                <td style="padding: 5px; margin: 5px; text-align: left;" colspan="6">
                                    <asp:DropDownList ID="ddlsubcaste" runat="server" Height="33px" Width="180px" RepeatDirection="Horizontal"
                                        TabIndex="1" OnSelectedIndexChanged="rblCaste_SelectedIndexChanged">
                                        <asp:ListItem Value="0">SELECT</asp:ListItem>
                                        <asp:ListItem Value="1">BC-A</asp:ListItem>
                                        <asp:ListItem Value="2">BC-B</asp:ListItem>
                                        <asp:ListItem Value="3">BC-C</asp:ListItem>
                                        <asp:ListItem Value="4">BC-D</asp:ListItem>
                                        <asp:ListItem Value="5">BC-E</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr id="tr1" runat="server" visible="false">
                    <td colspan="10">
                        <table bgcolor="White" width="100%" style="font-family: Verdana;">
                            <tr>
                                <td style="padding: 5px; margin: 5px; text-align: left;">1</td>
                                <td style="padding: 5px; margin: 5px; text-align: left;">
                                    <asp:Label ID="Label11" runat="server">Claimed Financial Year<font color="red">*</font></asp:Label>
                                </td>
                                <td style="padding: 5px; margin: 5px">:</td>
                                <td style="padding: 5px; margin: 5px; text-align: left;">
                                    <asp:DropDownList ID="ddlFinYearEnergy" runat="server" class="form-control txtbox" Height="33px" Width="180px">
                                        <asp:ListItem>--Select--</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td style="padding: 5px; margin: 5px; text-align: left;">2</td>
                                <td style="padding: 5px; margin: 5px; text-align: left;">
                                    <asp:Label ID="Label16" runat="server"> 1st/2nd half Year<font color="red">*</font></asp:Label>
                                </td>
                                <td style="padding: 5px; margin: 5px">:</td>
                                <td style="padding: 5px; margin: 5px; text-align: left;">
                                    <asp:DropDownList ID="ddlFin1stOr2ndHalfyear" runat="server" class="form-control txtbox" Height="33px" Width="180px">
                                        <asp:ListItem Value="--Select--" Text="--Select--"></asp:ListItem>
                                        <asp:ListItem Value="1" Text="1st Half"></asp:ListItem>
                                        <asp:ListItem Value="2" Text="2nd Half"></asp:ListItem>
                                        <asp:ListItem Value="3" Text="Both"></asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr id="tr2" runat="server">
                                <%-- <td align="center" colspan="4"></td>--%>
                                <td align="center" colspan="8" style="height: 50px">
                                    <asp:Button ID="btnEnergyAdd" runat="server" CssClass="btn btn-xs btn-warning" Height="28px" TabIndex="39" Text="Add New"
                                        OnClientClick="ConfirmUpdate()" Width="72px" OnClick="btnEnergyAdd_Click" />
                                    &nbsp;&nbsp;&nbsp;
                                                <asp:Button ID="btnEnergyClear" runat="server" CausesValidation="False" CssClass="btn btn-xs btn-danger" Height="28px" TabIndex="40" Text="Clear" ToolTip="To Clear the Screen" Width="73px" OnClick="btnEnergyClear_Click" />
                                </td>
                            </tr>
                            <tr>
                                <td colspan="10">
                                    <asp:GridView ID="gvinspectionOfficer" runat="server" AutoGenerateColumns="False"
                                        CellPadding="4" Height="62px"
                                        Width="100%" Font-Names="Verdana" Font-Size="12px">
                                        <HeaderStyle VerticalAlign="Middle" Height="40px" CssClass="GridviewScrollC1HeaderWrap" />
                                        <RowStyle CssClass="GridviewScrollC1Item" />
                                        <PagerStyle CssClass="GridviewScrollC1Pager" />
                                        <FooterStyle BackColor="#013161" Height="40px" CssClass="GridviewScrollC1Header" />
                                        <AlternatingRowStyle CssClass="GridviewScrollC1Item2" />
                                        <Columns>
                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S No">
                                                <ItemTemplate>
                                                    <%# Container.DataItemIndex + 1%>
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <ItemStyle Width="50px" />
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="FinancialYear" HeaderText="Financial Year" />
                                            <asp:BoundField DataField="Fin1stOr2ndHalfYearText" HeaderText="1st or 2nd Half Financial Year" />
                                            <asp:TemplateField HeaderText="IncentiveId" Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="txtiIncentiveIdNew" Enabled="false" Text='<%#Eval("IncentiveId") %>' runat="server" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="MstIncentiveId" Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblMstIncentiveId" Text='<%#Eval("MstIncentiveId") %>' runat="server" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="FinancialYearId" Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblFinancialYearId" Text='<%#Eval("FinancialYearId") %>' runat="server" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Fin1stOr2ndHalfYearID" Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblFin1stOr2ndHalfYearID" Text='<%#Eval("Fin1stOr2ndHalfYearID") %>' runat="server" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="finRowid" Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblfinRowid" Text='<%#Eval("finRowid") %>' runat="server" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Edit">
                                                <ItemTemplate>
                                                    <asp:Button ID="Button1" CssClass="btn btn-primary" runat="server" Text="Edit" Width="150px" OnClick="Button1_Click" /><br />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Delete">
                                                <ItemTemplate>
                                                    <asp:Button ID="Button3" CssClass="btn btn-primary" OnClientClick="ConfirmDelete()" runat="server" OnClick="Button3_Click" Text="Delete" Width="150px" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td align="center" colspan="10">
                        <asp:Button ID="Button7" CssClass="btn btn-primary" runat="server" OnClientClick="ConfirmUpdate()" Text="Update" OnClick="Button7_Click" />
                    </td>
                </tr>
                <tr>
                    <td align="center" colspan="10" style="padding: 5px; margin: 5px">
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
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

