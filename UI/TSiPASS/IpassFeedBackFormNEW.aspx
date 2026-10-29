<%@ Page Title="" Language="C#" AutoEventWireup="true" CodeFile="IpassFeedBackFormNEW.aspx.cs" Inherits="UI_TSiPASS_IpassFeedBackFormNEW" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">

        <table align="center"
            style="border: 1px solid #000000; font-family: Verdana; font-size: 12px; text-align: center; width: 800px;">
            <tr>
                <td style="padding-top: 10px; padding-bottom: 20px; padding-left: 9px; height: 675px;"
                    valign="top" align="center">
                    <div class="col-lg-12">
                        <div class="panel panel-default">
                            <div class="panel-heading" style="text-align: center">

                                <img src="viewpdf.aspx?filepathnew=D:/TS-iPASSFinal/telanganalogo.png" width="75px" height="65px" />

                                <h2 id="H1" runat="server" class="panel-title" style="font-weight: bold; text-align: center">
                                    <asp:Label ID="lblHeading" runat="server">TS-iPASS FEEDBACK FORM</asp:Label>
                                </h2>
                            </div>
                            <div class="panel-body">
                                <div class="form-card">
                                    <div class="row">
                                        <div class="col-md-12" style="display: flex">
                                            <div class="form-group col-md-3">
                                                <label for="name">1. Name of Unit</label>
                                                <asp:TextBox ID="TxtnameofUnit" runat="server" class="form-control"
                                                    ToolTip="text" MaxLength="50" TabIndex="0" ValidationGroup="group" Enabled="false"></asp:TextBox>
                                            </div>
                                            <div class="form-group col-md-3">
                                                <label for="name">2. Name of Promoter</label>
                                                <asp:TextBox ID="txtpromotername" runat="server" class="form-control"
                                                    ToolTip="text" MaxLength="50" TabIndex="0" ValidationGroup="group" Enabled="false"></asp:TextBox>
                                            </div>
                                            <div class="form-group col-md-3">
                                                <label for="name">3. Mobile Number</label>
                                                <asp:TextBox ID="txtmobileno" runat="server" class="form-control"
                                                    ToolTip="text" MaxLength="50" TabIndex="0" ValidationGroup="group" Enabled="false"></asp:TextBox>
                                            </div>
                                            <div class="form-group col-md-3">
                                                <label for="name">4. UID Number</label>
                                                <asp:TextBox ID="TXTUIDNO" runat="server" class="form-control"
                                                    ToolTip="text" MaxLength="50" TabIndex="0" ValidationGroup="group" Enabled="false"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <div class="col-lg-12">
                                    <asp:GridView ID="grdDetails" runat="server"
                                        AutoGenerateColumns="False" CellPadding="4" CssClass="GRD" ForeColor="#333333"
                                        Height="62px" PageSize="15" Width="100%" ShowFooter="True">
                                        <FooterStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                        <RowStyle BackColor="#EBF2FE" CssClass="GRDITEM" HorizontalAlign="Left"
                                            VerticalAlign="Middle" />
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
                                            <asp:BoundField DataField="ApprovalName" HeaderText="Approval Required ">
                                                <ItemStyle Width="450px" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="DepartmentName" HeaderText="Department">
                                                <ItemStyle Width="180px" />
                                            </asp:BoundField>
                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Excellent">
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="SelectCheckBoxExcellent" runat="server" OnCheckedChanged="SelectCheckBoxExcellent_CheckedChanged" AutoPostBack="true" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Good">
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="SelectCheckBoxGood" runat="server" OnCheckedChanged="SelectCheckBoxGood_CheckedChanged" AutoPostBack="true" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Satisfied">
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="SelectCheckBoxSatisfied" runat="server" OnCheckedChanged="SelectCheckBoxSatisfied_CheckedChanged" AutoPostBack="true" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Not Satisfied">
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="SelectCheckBoxNotSatisfied" runat="server" OnCheckedChanged="SelectCheckBoxNotSatisfied_CheckedChanged" AutoPostBack="true" />
                                                    <asp:TextBox runat="server" class="form-control txtbox" Height="50px" Width="180px"
                                                        AutoComplete="false" ID="TxtReject" Visible="false" placeholder="Please Enter Reason" TextMode="MultiLine" />
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="ApprovalId" Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblApprovalId" Text='<%# Eval("approvalid") %>' runat="server" Visible="false"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Dept_Id" Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblDept_Id" Text='<%# Eval("deptid") %>' runat="server" Visible="false"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="MobileNumber" Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblMobileNumber" Text='<%# Eval("MobileNumber") %>' runat="server" Visible="false"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                        <PagerStyle BackColor="#013161" ForeColor="White" HorizontalAlign="Center" />
                                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                        <HeaderStyle BackColor="#013161" CssClass="GRDHEADER" Font-Bold="True"
                                            ForeColor="White" />
                                        <EditRowStyle BackColor="#B9D684" />
                                        <AlternatingRowStyle BackColor="White" />
                                    </asp:GridView>
                                </div>
                                
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <div class="col-lg-12">
                                </div>

                                <div class="col-lg-6">
                                    <h2 id="H2" runat="server" class="panel-title" style="font-weight: bold; text-align: center">
                                        <asp:Label ID="Label1" runat="server">Suggestion for improvement , If any(Word Limit 150 characters) </asp:Label>
                                    </h2>
                                </div>
                                <div class="col-lg-6">
                                    <asp:TextBox runat="server" class="form-control txtbox" Height="100px" Width="250px"
                                        AutoComplete="false" ID="txtremarks" placeholder="Please Enter Suggestions" TextMode="MultiLine" MaxLength="150"/>
                                </div>
                                
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <div class="col-lg-12" style="display: inline-flex" >
                                    <div class="col-lg-6">
                                        <asp:Button ID="btnSubmit" runat="server" Height="40px" Text="Submit" Width="120px" OnClick="btnSubmit_Click"></asp:Button>
                                    </div>
                                    <div class="col-lg-6">
                                        <asp:Button ID="btnclear" runat="server" Height="40px" Text="Clear" Width="120px"></asp:Button>
                                    </div>
                                </div>
                                <tr>
                                    <td colspan="2" style="text-align: center">
                                        <table style="text-align: center">
                                            <tr>
                                                <td colspan="2" style="text-align: center" class="auto-style1" align="center">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    

                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>

                            </div>
                        </div>
                    </div>
                </td>
            </tr>

        </table>

    </form>
</body>
</html>


