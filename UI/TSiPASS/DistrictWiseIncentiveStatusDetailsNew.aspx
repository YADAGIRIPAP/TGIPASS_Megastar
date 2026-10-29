<%@ Page Title="" Language="C#" MasterPageFile="~/UI/TSiPASS/CCMaster.master" AutoEventWireup="true" CodeFile="DistrictWiseIncentiveStatusDetailsNew.aspx.cs" Inherits="UI_TSiPASS_DistrictWiseIncentiveStatusDetailsNew" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script src="../../Resource/Scripts/js/validations.js" type="text/javascript"></script>

    <style type="text/css">
        .overlay
        {
            position: fixed;
            z-index: 999;
            height: 100%;
            width: 100%;
            background-color: Gray;
            filter: alpha(opacity=60);
            opacity: 0.9;
            -moz-opacity: 0.9;
        }
        .style10
        {
            width: 9px;
            height: 28px;
        }
        .style11
        {
            width: 210px;
            height: 28px;
        }
        .style12
        {
            width: 212px;
            height: 28px;
        }
        .style13
        {
            width: 210px;
            height: 21px;
        }
        .style14
        {
            width: 9px;
            height: 21px;
        }
        .style15
        {
            height: 21px;
        }
        .style16
        {
            width: 212px;
            height: 21px;
        }
        .style17
        {
            height: 28px;
        }
    </style>

    <script type="text/javascript" language="javascript">

        function OpenPopup() {

            window.open("Lookups/LookupBDC.aspx", "List", "scrollbars=yes,resizable=yes,width=1000,height=650;display = block;position=absolute");

            return false;
        }
    </script>

    <script type="text/javascript">
        function sumPropBulk() {
            var txtFirstNumberValue = document.getElementById('txtProsPetorlClassA').value;
            var txtSecondNumberValue = document.getElementById('txtPropPetolClassB').value;
            var txtThirdNumberValue = document.getElementById('txtPropPetolClassB').value;
            var result = parseInt(txtFirstNumberValue) + parseInt(txtSecondNumberValue) + parseInt(txtThirdNumberValue);
            if (!isNaN(result)) {
                document.getElementById('txtPropPetrolTotal').value = result;
            }
        }
    </script>

    <div align="left">
        <ol class="breadcrumb">
            You are here &nbsp;!&nbsp; &nbsp; &nbsp;
            <li><i class="fa fa-dashboard"></i><a href="Home.aspx"></a></li>
            <li class=""><i class="fa fa-fw fa-edit">Incentive</i> </li>
            <li class="active"></li>
        </ol>
    </div>
    <div align="left">
        <div class="row" align="left">
            <div class="col-lg-12">
                <div class="panel panel-primary">
                    <div class="panel-heading" align="center">
                        <h3 class="panel-title" style="font-weight: bold;">
                            <asp:Label ID="lblHeading" runat="server"></asp:Label><a id="A2" href="#" onserverclick="BtnSave2_Click1"
                                runat="server">
                                <img src="../../Resource/Images/Excel-icon.png" width="20px;" height="20px;" style="float: right;"
                                    alt="Excel" /></a></h3>
                    </div>
                    <div class="panel-body">
                        <table align="center" cellpadding="10" cellspacing="5" style="width: 99%">
                            <tr>
                                <td align="left" style="padding: 5px; margin: 5px" valign="top">
                                    <table cellpadding="4" cellspacing="5" style="width: 100%">
                                        <tr>
                                            <td align="left" style="padding: 5px; margin: 5px" valign="top">
                                                <table cellpadding="4" cellspacing="5" style="width: 100%">
                                                    <tr>
                                                        <td style="padding: 5px; margin: 5px" class="style11">
                                                            <asp:Label ID="Label438" runat="server" CssClass="LBLBLACK" Width="108px">Status</asp:Label>
                                                        </td>
                                                        <td class="style10" style="padding: 5px; margin: 5px">
                                                            :
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px" class="style17">
                                                            <asp:DropDownList ID="ddlstatus" runat="server" class="form-control txtbox" Height="33px"
                                                                Width="180px" AutoPostBack="True" TabIndex="1">
                                                                <asp:ListItem>All</asp:ListItem>
                                                                <asp:ListItem>Pending</asp:ListItem>
                                                                <asp:ListItem>Reject</asp:ListItem>
                                                                <asp:ListItem>Forwarded</asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px" class="style17">
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px" class="style17">
                                                            <asp:Label ID="Label437" runat="server" CssClass="LBLBLACK" Width="108px">Industry Name</asp:Label>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px" class="style17">
                                                            :
                                                        </td>
                                                        <td class="style12" style="padding: 5px; margin: 5px">
                                                            <asp:TextBox ID="TxtIndname" runat="server" class="form-control txtbox" Height="28px"
                                                                MaxLength="80" TabIndex="1" ValidationGroup="group" Width="180px"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="padding: 5px; margin: 5px" class="style13">
                                                            <asp:Label ID="Label439" runat="server" CssClass="LBLBLACK" Width="108px">District</asp:Label>
                                                        </td>
                                                        <td class="style14" style="padding: 5px; margin: 5px">
                                                            :
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px" class="style15">
                                                            <asp:DropDownList ID="ddlDistrict" runat="server" class="form-control txtbox" Height="33px"
                                                                Width="180px" AutoPostBack="True" TabIndex="1">
                                                                <asp:ListItem>--Select--</asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td class="style15" style="padding: 5px; margin: 5px">
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px" class="style15">
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px" class="style15">
                                                        </td>
                                                        <td class="style16" style="padding: 5px; margin: 5px">
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td valign="middle" align="center" colspan="3" style="text-align: center">
                                                <asp:Button ID="BtnSearch" runat="server" CssClass="btn btn-primary" Height="32px"
                                                    TabIndex="10" Text="Search" Width="90px" OnClick="BtnSearch_Click" />
                                                &nbsp;
                                                <asp:Button ID="BtnClear" runat="server" CausesValidation="False" CssClass="btn btn-warning"
                                                    Height="32px" OnClick="BtnClear_Click" TabIndex="10" Text="Clear" ToolTip="To Clear  the Screen"
                                                    Width="90px" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px" valign="top">
                                                &nbsp;
                                            </td>
                                            <td style="width: 27px">
                                                &nbsp;
                                            </td>
                                            <td valign="top">
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: center;" colspan="3" align="center">
                                                <asp:Label ID="lblMsg" runat="server" Font-Bold="True" Font-Names="verdana" Font-Size="13px"
                                                    ForeColor="#006600"></asp:Label>
                                                <tr>
                                                    <td style="padding: 5px; margin: 5px" colspan="3" align="center">
                                                        <asp:GridView ID="grdDetails" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                                            CellPadding="4" CssClass="GRD" ForeColor="#333333" GridLines="None" Height="62px"
                                                            OnPageIndexChanging="grdDetails_PageIndexChanging" OnRowDataBound="grdDetails_RowDataBound"
                                                            PageSize="20" Width="100%">
                                                            <HeaderStyle VerticalAlign="Middle" Height="40px" CssClass="GridviewScrollC1HeaderWrap" />
                                                            <RowStyle CssClass="GridviewScrollC1Item" />
                                                            <PagerStyle CssClass="GridviewScrollC1Pager" />
                                                            <FooterStyle BackColor="#013161" Height="40px" CssClass="GridviewScrollC1Header" />
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
                                                                <asp:BoundField DataField="EMiUdyogAadhar" HeaderText="EMI Udyog Aadhaar" />
                                                                <asp:BoundField DataField="UnitName" HeaderText="Unit Name" />
                                                                <asp:BoundField DataField="ApplciantName" HeaderText="Applciant Name" />
                                                                <asp:BoundField DataField="Gender" HeaderText="Gender" />
                                                                <asp:BoundField DataField="Caste" HeaderText="Caste" />
                                                                <asp:BoundField DataField="Category" HeaderText="Category" />
                                                                <asp:BoundField DataField="District" HeaderText="District" />
                                                                <asp:BoundField DataField="TypeofOrg" HeaderText="Type of Organization" Visible="false" />
                                                                <asp:BoundField DataField="EnterperIncentiveID" HeaderText="Enterper Incentive ID"
                                                                    Visible="false" />
                                                                <asp:BoundField DataField="UnitEmail" HeaderText="Email" />
                                                                <asp:BoundField DataField="MobileNo" HeaderText="Mobile" />
                                                                <asp:TemplateField HeaderText="View Incentives">
                                                                    <ItemTemplate>
                                                                        <a id="View" target="_blank" href="IncetivesNewFormDeptView.aspx?EntrpId=<%# Eval("EnterperIncentiveID") %>">
                                                                            View</a>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="View Attachments">
                                                                    <ItemTemplate>
                                                                        <a id="View" target="_blank" href="Show_Attachments.aspx?EntrpId=<%# Eval("EnterperIncentiveID") %>">
                                                                            View</a>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Update Status">
                                                                    <ItemTemplate>
                                                                        <table style="width: 100%" cellpadding="4" cellspacing="5">
                                                                            <tr>
                                                                                <asp:Label ID="lbl123" Text="Inspecting Officer" runat="server"></asp:Label>
                                                                            </tr>
                                                                            <tr>
                                                                                <td style="width: 150px; height: 29px">
                                                                                    <asp:DropDownList ID="ddlDeptname" runat="server" Width="180px" CssClass="DROPDOWN">
                                                                                        <asp:ListItem>--Select--</asp:ListItem>
                                                                                    </asp:DropDownList>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td colspan="4" align="center">
                                                                                    <asp:Button ID="BtnSaveg" runat="server" CssClass="BUTTON" Height="20px" TabIndex="10"
                                                                                        Text="Submit" ValidationGroup="group" Width="61px" OnClick="BtnSaveg_Click" />
                                                                                    <asp:HiddenField ID="HdfintApplicationid" runat="server" />
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:BoundField DataField="Manda_lName" HeaderText="Mandal Name" />
                                                                <asp:TemplateField HeaderText="Inspection Date">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblInspectionDate" Text='<%#Eval("InspectionDate") %>' runat="server" />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:BoundField DataField="SubmittedDate" HeaderText="Submitted Date" />
                                                                <asp:BoundField DataField="sectorname" HeaderText="Type" />
                                                                <%--<asp:HyperLinkField HeaderText="Forward" />--%>
                                                            </Columns>
                                                        </asp:GridView>
                                                        <tr>
                                                            <td align="center" colspan="3" style="padding: 5px; margin: 5px">
                                                                &nbsp;
                                                                <asp:Label ID="lblresult" runat="server" Font-Bold="True" Font-Names="verdana" Font-Size="13px"
                                                                    ForeColor="#006600"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <caption>
                                                            &nbsp;</caption>
                                                    </td>
                                                </tr>
                                            </td>
                                        </tr>
                                        <tr visible="false">
                                            <td style="padding: 5px; margin: 5px; text-align: center;" colspan="3" align="center">
                                                <tr>
                                                    <td style="padding: 5px; margin: 5px" colspan="3" align="center">
                                                        <asp:GridView ID="GridExport" runat="server" AutoGenerateColumns="false">
                                                            <Columns>
                                                                <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S.No">
                                                                    <ItemTemplate>
                                                                        <%# Container.DataItemIndex + 1%>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                </asp:TemplateField>
                                                                <asp:BoundField DataField="EMiUdyogAadhar" HeaderText="EMI Udyog Aadhaar" />
                                                                <asp:BoundField DataField="UnitName" HeaderText="Unit Name" />
                                                                <asp:BoundField DataField="ApplciantName" HeaderText="Applciant Name" />
                                                                <asp:BoundField DataField="Gender" HeaderText="Gender" />
                                                                <asp:BoundField DataField="Caste" HeaderText="Caste" />
                                                                <asp:BoundField DataField="Category" HeaderText="Category" />
                                                                 <asp:BoundField DataField="Manda_lName" HeaderText="Mandal Name" />
                                                                <asp:BoundField DataField="District" HeaderText="District" />
                                                                <asp:BoundField DataField="EmailID" HeaderText="Email" />
                                                                <asp:BoundField DataField="MobileNo" HeaderText="Mobile" />
                                                                <asp:TemplateField HeaderText="Inspection Date">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblInspectionDate" Text='<%#Eval("InspectionDate") %>' runat="server" />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:BoundField DataField="SubmittedDate" HeaderText="Submitted Date" />
                                                                <asp:BoundField DataField="sectorname" HeaderText="Type" />
                                                                <%--<asp:HyperLinkField HeaderText="Forward" />--%>
                                                            </Columns>
                                                        </asp:GridView>
                                                    </td>
                                                </tr>
                                            </td>
                                        </tr>
                                    </table>
                    </div>
                    </ContentTemplate> </asp:UpdatePanel>
                </div>
            </div>
        </div>
    </div>
</asp:Content>


