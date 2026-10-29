<%@ Page Title="" Language="C#" MasterPageFile="~/UI/TSiPASS/CCMaster.master" AutoEventWireup="true" CodeFile="PmegpPendingApplicationAnalysis.aspx.cs" Inherits="UI_TSiPASS_PmegpPendingApplicationAnalysis" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <style type="text/css">
        html {
            scroll-behavior: smooth;
        }

        .col-lg-10 {
            width: 1050px;
        }

        .radiobtn {
            display: flex;
            justify-content: left;
            align-items: center;
            margin-top: 5px;
        }

            .radiobtn input[type="radio"] {
                margin-right: 3px;
            }

        .Checkbox input[type="checkbox"] {
            margin-right: 5px;
        }

        .grid-scroll {
            width: 1000px;
            height: auto;
            max-height: 400px;
            overflow-y: auto;
            overflow: auto;
        }

        .gridview th {
            position: sticky;
            top: 0;
            background-color: #009688;
            color: #FFFFFF;
            z-index: 1;
        }

        .hidden-row {
            display: none;
        }

        .ajax__calendar_container {
            z-index: 2;
        }

        .error-border {
            /*border: 2px solid red;*/
            box-shadow: 0 0 5px red;
            width: 100%;
            padding: 8px 12px;
            border: 1px solid red;
            border-radius: 4px;
            background-color: #fff;
            color: #333;
            font-size: 14px;
            line-height: 1.4;
        }
    </style>
    <div align="left">
        <div class="row" align="left">
            <div class="col-lg-10">
                <div class="panel panel-primary">
                    <div class="panel-heading" align="center">
                        <h3 class="panel-title" style="text-align: center;">
                            <asp:Label ID="lblHead2" runat="server" CssClass="LBLBLACK" Font-Bold="True"
                                Width="500px">PMEGP Pending Application Analysis</asp:Label>
                        </h3>
                    </div>
                    <div class="panel-body">
                        <table align="center" cellpadding="10" cellspacing="5" style="width: 90%">
                            <tr>
                                <td>
                                    <table cellpadding="4" cellspacing="5" style="width: 100%">
                                        <tr>
                                            <%--<td class="style3" align="center" style="width: 178px">
                                                <asp:Label ID="lblfromdt" runat="server">From Date :</asp:Label>
                                            </td>
                                            <td style="width: 170px">
                                                <asp:TextBox ID="txtfrmdate" runat="server" class="form-control" Width="150px" TabIndex="1"></asp:TextBox>
                                                <cc1:CalendarExtender ID="txtfrmdate_CalendarExtender" runat="server"
                                                    Format="dd-MM-yyyy" PopupButtonID="txtfrmdate" TargetControlID="txtfrmdate">
                                                </cc1:CalendarExtender>
                                            </td>
                                            <td class="style3" align="center" style="width: 128px">
                                                <asp:Label ID="lbltodate" runat="server">To Date :</asp:Label>
                                            </td>
                                            <td>
                                                <div>
                                                    <asp:TextBox ID="txttodate" runat="server" Width="150px" class="form-control txtbox"></asp:TextBox>
                                                    <cc1:CalendarExtender ID="txttodate_CalendarExtender" runat="server"
                                                        Format="dd-MM-yyyy" PopupButtonID="txttodate" TargetControlID="txttodate">
                                                    </cc1:CalendarExtender>
                                                </div>
                                            </td>--%>
                                            <td class="style3" align="center" style="width: 178px">
                                                <asp:Label ID="lblfromdt" runat="server">Financial Year :</asp:Label>
                                            </td>
                                            <td style="width: 170px">
                                                <asp:DropDownList ID="ddlFinYear" runat="server" class="form-control" Width="150px">
                                                    <asp:ListItem Text="--Select--" Value="0" />
                                                    <asp:ListItem Text="2021 - 2022" Value="22" />
                                                    <asp:ListItem Text="2022 - 2023" Value="23" />
                                                    <asp:ListItem Text="2023 - 2024" Value="24" />
                                                </asp:DropDownList>
                                            </td>
                                            <td class="style3" align="center" style="width: 110px">
                                                <asp:Label ID="Label1" runat="server">Search :</asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="Grid_Search" runat="server" class="form-control" Width="280px" autocomplete="off" placeholder="Search By Applicant ID or Name" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center" style="padding: 5px; margin: 5px; text-align: center; height: 50px" colspan="10">&nbsp;&nbsp;
                                                 <asp:Button ID="BtnGetData" runat="server" CssClass="btn btn-primary"
                                                     Height="32px" TabIndex="10" Text="Get Report" ValidationGroup="group"
                                                     Width="120px" OnClick="BtnGetData_Click" />
                                                &nbsp;
                                             <asp:Button ID="BtnClear" runat="server" CausesValidation="False"
                                                 CssClass="btn btn-warning" Height="32px" OnClick="BtnClear_Click" TabIndex="10"
                                                 Text="Cancel" ToolTip="To Clear  the Screen" Width="90px" />
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <div class="grid-scroll" id="GridViewBlock" runat="server" visible="false">
                                        <asp:GridView ID="grdsupport" runat="server" AutoGenerateColumns="false" Width="100%"
                                            BorderColor="#000000" BorderStyle="Solid" BorderWidth="1px" AutoPostBack="true" ForeColor="#333333"
                                            CssClass="gridview">
                                            <HeaderStyle ForeColor="#FFFFFF" BackColor="#009688" Height="60px" CssClass="GridviewScrollC1HeaderWrap" />
                                            <Columns>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        <div style="text-align: center;">Select</div>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <div style="text-align: center;">
                                                            <asp:CheckBox ID="SelectCheckBox" runat="server" OnCheckedChanged="SelectCheckBox_CheckedChanged" AutoPostBack="true" />
                                                        </div>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <%--<asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Sl.No">
                                                    <ItemTemplate>
                                                        <%# Container.DataItemIndex +1 %>
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle Width="20px" />
                                                </asp:TemplateField>--%>
                                                <asp:TemplateField Visible="true">
                                                    <HeaderTemplate>
                                                        <div style="text-align: center;">Applicant ID</div>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <div style="text-align: center;">
                                                            <asp:Label ID="LabelApplicantID" runat="server" Text='<%#Eval("ApplicantID") %>'></asp:Label>
                                                        </div>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Applicant Name">
                                                    <ItemTemplate>
                                                        <asp:Label ID="LabelApplicantName" runat="server" Text='<%# Eval("ApplicantName") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Applicant Address">
                                                    <ItemTemplate>
                                                        <asp:Label ID="LabelApplicantAddress" runat="server" Text='<%# Eval("ApplicantAddress") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Unit Address">
                                                    <ItemTemplate>
                                                        <asp:Label ID="LabelUnitAddress" runat="server" Text='<%# Eval("UnitAddress") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Financing Branch Address">
                                                    <ItemTemplate>
                                                        <asp:Label ID="LabelFinancingBranchAddress" runat="server" Text='<%# Eval("FinancingBranchAddress") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Online Submission Date">
                                                    <ItemTemplate>
                                                        <asp:Label ID="LabelOnlineSubmissionDate" runat="server" Text='<%# Eval("OnlineSubmissionDate") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Forwarding Date to Bank">
                                                    <ItemTemplate>
                                                        <asp:Label ID="LabelForwardingDatetoBank" runat="server" Text='<%# Eval("ForwardingDatetoBank") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Under Progress/Rejection Reason by Agency">
                                                    <ItemTemplate>
                                                        <asp:Label ID="LabelUnderProcess_Rejection" runat="server" Text='<%# Eval("UnderProcess_RejectionbyAgencyreason") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Bank Remarks">
                                                    <ItemTemplate>
                                                        <asp:Label ID="LabelBankRemarks" runat="server" Text='<%# Eval("BankRemarks") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                            </Columns>
                                            <EmptyDataTemplate>
                                                <div style="text-align: center;">No Records Found</div>
                                            </EmptyDataTemplate>
                                        </asp:GridView>
                                    </div>
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
                <div style="padding-left: 15px; padding-top: 5px;">
                    <div class="column" style="display: flex; align-items: center;" id="Rejectedat" runat="server" visible="false">
                        <asp:Label runat="server" Text="1. Rejected at :" Style="padding-right: 10px;" />
                        <div class="radiobtn">
                            <asp:RadioButtonList ID="RBTREJECTIONAT" runat="server" RepeatDirection="Horizontal">
                                <asp:ListItem Text="DIC" Value="0" style="padding-right: 10px;" />
                                <asp:ListItem Text="Bank" Value="1" />
                            </asp:RadioButtonList>
                        </div>
                    </div>
                    <div class="column" style="display: flex; align-items: center;" id="Readdply_No_Remarks" runat="server" visible="false">
                        <asp:Label runat="server" Text="2. General Reason for Rejection :" Style="padding-right: 20px;" />
                        <asp:DropDownList ID="ddlRejectionReason" runat="server" class="form-control" Width="500px">
                            <asp:ListItem Text="--Select--" Value="0" />
                           
                        </asp:DropDownList>
                    </div>
                    <div class="column" style="display: flex; align-items: center; padding-top: 15px;" id="Readdply_Officer_Remarks" runat="server" visible="false">
                        <asp:Label runat="server" Text="3. Officer Remarks :" Style="padding-right: 20px;" />
                        <asp:TextBox ID="NO_Reapply_Remarks" runat="server" class="form-control" Width="450px" TextMode="MultiLine" />
                    </div>
                    <div class="column" style="display: flex; align-items: center;" id="CandidateReapply_Block" runat="server" visible="false">
                        <asp:Label runat="server" Text="4. Is Candidate eligible to re-apply :" Style="padding-right: 10px;" />
                        <div class="radiobtn">
                            <asp:RadioButtonList ID="CandidateReapply" runat="server" RepeatDirection="Horizontal" AutoPostBack="true" OnSelectedIndexChanged="Candidate_Reapply_SelectedIndexChanged">
                                <asp:ListItem Text="Yes" Value="0" style="padding-right: 10px;" />
                                <asp:ListItem Text="No" Value="1" />
                            </asp:RadioButtonList>
                        </div>
                    </div>

                    <div class="column" style="display: flex; align-items: center; padding-top: 15px;" id="Guidance_Block" runat="server" visible="false">
                        <asp:Label runat="server" Text="5. Guidance Provided : " Style="padding-right: 20px;" />
                        <asp:DropDownList ID="ddlGuidance" runat="server" class="form-control" Width="300px" AutoPostBack="true" OnSelectedIndexChanged="ddlGuidance_SelectedIndexChanged">
                            <asp:ListItem Text="--Select--" Value="0" />
                            <asp:ListItem Text="Shortfall Documents to be Submitted" Value="1" />
                            <asp:ListItem Text="Guided to pursue with Bank" Value="2" />
                            <asp:ListItem Text="Guided to change the Bank" Value="3" />
                            <asp:ListItem Text="Others" Value="4" />
                        </asp:DropDownList>
                    </div>
                    <div id="Documents_Block" runat="server" visible="false">
                        <table>
                            <tr>
                                <td style="padding-top: 15px;">
                                    <asp:Label ID="SelectedDocuments" runat="server" Text="5a. Please Select Documents to be Submitted : " AssociatedControlID="ShortFallDocuments" />
                                </td>
                                <td style="padding-top: 15px;">
                                    <div class="Checkbox" style="padding-left: 30px;">
                                        <asp:CheckBoxList ID="ShortFallDocuments" runat="server" RepeatDirection="Vertical">
                                            <asp:ListItem Text="Project Report" Value="0" />
                                            <asp:ListItem Text="Caste Certificate" Value="1" />
                                            <asp:ListItem Text="Qualification Certificate" Value="2" />
                                            <asp:ListItem Text="Rural Area Certificate" Value="3" />
                                            <asp:ListItem Text="Aadhar Card" Value="4" />
                                        </asp:CheckBoxList>
                                    </div>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div class="column" style="display: flex; align-items: center; padding-top: 15px;" id="Guidance_Others" runat="server" visible="false">
                        <asp:Label runat="server" Text="5a. Other Remarks :" Style="padding-right: 20px;" />
                        <asp:TextBox ID="Others_Remarks" runat="server" class="form-control" Width="450px" TextMode="MultiLine" />
                    </div>
                </div>
                <div id="SUBMIT_CLEAR_BTNS" runat="server" class="row" align="center" style="padding-top: 20px;" visible="false">
                    <asp:Button ID="SubmitBtn" runat="server" Text="SUBMIT" Style="background-color: forestgreen; color: ghostwhite; border-radius: 5px;" Height="35px" Width="150px" OnClick="SubmitBtn_Click" />
                    <asp:Button ID="ClearBtn" runat="server" Text="CLEAR" Style="background-color: red; color: ghostwhite; border-radius: 5px;" Height="35px" Width="150px" OnClick="ClearBtn_Click" />
                </div>
            </div>
        </div>
    </div>

    <script type="text/javascript">
        $(document).ready(function () {
            $("#<%=grdsupport.ClientID%> input[type='checkbox']").change(function () {
                var selectedCheckbox = $(this);
                if (selectedCheckbox.prop('checked')) {
                    var selectedApplicantID = selectedCheckbox.closest('tr').find('[id$=LabelApplicantID]').text();
                    alert("Selected Applicant Id: " + selectedApplicantID);

                    $("#<%=grdsupport.ClientID%> input[type='checkbox']").not(selectedCheckbox).closest('tr').addClass('hidden-row');
                } else {
                    $("#<%=grdsupport.ClientID%> tr.hidden-row").removeClass('hidden-row');
                }
                adjustContainerHeight();
            });
        });

        function adjustContainerHeight() {
            var container = $(".gridview-container");
            var visibleRows = $("#<%=grdsupport.ClientID%> tr:not(.hidden-row)");
            var newHeight = 0;
            visibleRows.each(function () {
                newHeight += $(this).height();
            });
            container.height(newHeight);
        }

    </script>
</asp:Content>
