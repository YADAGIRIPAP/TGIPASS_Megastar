<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/UI/TSiPASS/CCMaster.master" CodeFile="Weaker_Section.aspx.cs" Inherits="UI_TSiPASS_Weaker_Section" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
     <script src="../../Resource/Scripts/js/validations.js" type="text/javascript"></script>
    <script language="javascript" type="text/javascript">
        $(function () {

            $('#MstLftMenu').remove();

        });
    </script>
    <contenttemplate>
        <h3 style="text-align: left; padding-left: 500px; text-decoration: underline;">Support to Weaker Section</h3>
        <table align="center" cellpadding="10" cellspacing="5" style="width: 90%">
            <tr>
                <td>
                    <table>
                        <tr>
                            <td style="padding-left: 0px; padding-top: 10px;">
                                <asp:Label ID="DistrictName" runat="server" Width="180px">1. District<font id="lbl1" runat="server" color="red">*</font> : </asp:Label>

                            </td>
                            <td style="padding-top: 10px;">
                                <asp:DropDownList ID="ddldistrict" runat="server" class="form-control txtbox"
                                    Height="33px" TabIndex="1" Width="180px">
                                    <asp:ListItem Value="0">--Select--</asp:ListItem>
                                </asp:DropDownList>

                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
        <br />
        <div style="max-width: 100%; overflow-x: auto;">
            <asp:GridView ID="grdDetails" runat="server" AutoGenerateColumns="false" OnRowCreated="grdDetails_RowCreated"
                CssClass="GRD" ForeColor="#333333" Height="62px" ShowFooter="false" Style="width: 100%" OnRowDataBound="grdDetails_RowDataBound">
                <FooterStyle BackColor="#be8c2f" Font-Bold="True" ForeColor="White" />
                <RowStyle BackColor="#EBF2FE" CssClass="GRDITEM" HorizontalAlign="Left" VerticalAlign="Middle" />
                <Columns>
                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S.No.">
                        <ItemTemplate>
                            <%# Container.DataItemIndex + 1%>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="Industrial Estate ID" Visible="false">
                        <ItemTemplate>
                            <asp:TextBox ID="LBLINDESTID_GRID" runat="server"></asp:TextBox>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Center" Width="80px" />
                    </asp:TemplateField>

                    <%--<asp:TemplateField HeaderText="" HeaderStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:CheckBox ID="EnableCheckBox" runat="server" AutoPostBack="true" OnCheckedChanged="EnableCheckBox_CheckedChanged" />
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Center" />
                    </asp:TemplateField>--%>

                    <%--<asp:TemplateField HeaderText="District" HeaderStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:TextBox ID="District" Enabled="false" runat="server"></asp:TextBox>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Center" />
                    </asp:TemplateField>--%>

                    <asp:TemplateField HeaderText="IE Name" HeaderStyle-HorizontalAlign="Center" Visible="true">
                        <ItemTemplate>
                            <asp:TextBox ID="IE_NAME" runat="server" Width="100px"></asp:TextBox>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Center" />
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Whether TSIIC Promoted/Private" HeaderStyle-HorizontalAlign="Center" Visible="true">
                        <ItemTemplate>
                            <asp:DropDownList ID="TSIIC_Category" runat="server" CssClass="gridTextBox">
                                <asp:ListItem Value="0">--Select--</asp:ListItem>
                                <asp:ListItem Value="1">TSIIC</asp:ListItem>
                                <asp:ListItem Value="2">Private</asp:ListItem>
                            </asp:DropDownList>

                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Center" />
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Nodal Officer Name" HeaderStyle-HorizontalAlign="Center" Visible="true">
                        <ItemTemplate>
                            <asp:DropDownList ID="ddlOfficerName" Width="100px" runat="server" CssClass="gridTextBox"
                                AutoPostBack="True" OnSelectedIndexChanged="ddlOfficerName_SelectedIndexChanged">
                            </asp:DropDownList>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Center" />
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Designation" HeaderStyle-HorizontalAlign="Center" Visible="true">
                        <ItemTemplate>
                            <asp:TextBox ID="Designation" runat="server" Width="100px"></asp:TextBox>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Center" />
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="available" HeaderStyle-HorizontalAlign="Center" Visible="true">
                        <ItemTemplate>
                            <asp:TextBox ID="TotalPlotAvailable" Width="45px" runat="server" onkeypress="NumberOnly()"></asp:TextBox>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Center" />
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="allotted" HeaderStyle-HorizontalAlign="Center" Visible="true">
                        <ItemTemplate>
                            <asp:TextBox ID="TotalPlotsalloted" Width="45px" runat="server" onkeypress="NumberOnly()"></asp:TextBox>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Center" />
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="vacant" HeaderStyle-HorizontalAlign="Center" Visible="true">
                        <ItemTemplate>
                            <asp:TextBox ID="TotalPlotsvacant" Width="45px" runat="server" onkeypress="NumberOnly()"></asp:TextBox>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Not set up after mandatory period" HeaderStyle-HorizontalAlign="Center" Visible="true">
                        <ItemTemplate>
                            <asp:TextBox ID="Plots_mandatory_period" Width="45px" runat="server" onkeypress="NumberOnly()"></asp:TextBox>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="For reallocation to weaker sections" HeaderStyle-HorizontalAlign="Center" Visible="true">
                        <ItemTemplate>
                            <asp:TextBox ID="reallocation_weaker_sections" Width="45px" runat="server" onkeypress="NumberOnly()"></asp:TextBox>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Center" />
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="SC" HeaderStyle-HorizontalAlign="Center" Visible="true">
                        <ItemTemplate>
                            <asp:TextBox ID="Plots_Mandated_SC" Width="45px" runat="server" onkeypress="NumberOnly()"></asp:TextBox>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Center" />
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="ST" HeaderStyle-HorizontalAlign="Center" Visible="true">
                        <ItemTemplate>
                            <asp:TextBox ID="Plots_Mandated_ST" Width="45px" runat="server" onkeypress="NumberOnly()"></asp:TextBox>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Center" />
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="BC" HeaderStyle-HorizontalAlign="Center" Visible="true">
                        <ItemTemplate>
                            <asp:TextBox ID="Plots_Mandated_BC" Width="45px" runat="server" onkeypress="NumberOnly()"></asp:TextBox>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Center" />
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Minority" HeaderStyle-HorizontalAlign="Center" Visible="true">
                        <ItemTemplate>
                            <asp:TextBox ID="Plots_Mandated_Minority" Width="45px" runat="server" onkeypress="NumberOnly()"></asp:TextBox>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Center" />
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Women" HeaderStyle-HorizontalAlign="Center" Visible="true">
                        <ItemTemplate>
                            <asp:TextBox ID="Plots_Mandated_Women" Width="45px" runat="server" onkeypress="NumberOnly()"></asp:TextBox>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="General" HeaderStyle-HorizontalAlign="Center" Visible="true">
                        <ItemTemplate>
                            <asp:TextBox ID="Plots_Mandated_General" Width="45px" runat="server" onkeypress="NumberOnly()"></asp:TextBox>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Center" />
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="SC" HeaderStyle-HorizontalAlign="Center" Visible="true">
                        <ItemTemplate>
                            <asp:TextBox ID="Plots_Alloted_SC" AutoPostBack="true" OnTextChanged="Plots_Alloted_SC_TextChanged" Width="45px" runat="server" onkeypress="NumberOnly()"></asp:TextBox>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Center" />
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="ST" HeaderStyle-HorizontalAlign="Center" Visible="true">
                        <ItemTemplate>
                            <asp:TextBox ID="Plots_Alloted_ST" AutoPostBack="true" Width="45px" OnTextChanged="Plots_Alloted_ST_TextChanged" runat="server" onkeypress="NumberOnly()"></asp:TextBox>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Center" />
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="BC" HeaderStyle-HorizontalAlign="Center" Visible="true">
                        <ItemTemplate>
                            <asp:TextBox ID="Plots_Alloted_BC" AutoPostBack="true" Width="45px" OnTextChanged="Plots_Alloted_BC_TextChanged" runat="server" onkeypress="NumberOnly()"></asp:TextBox>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Center" />
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Minority" HeaderStyle-HorizontalAlign="Center" Visible="true">
                        <ItemTemplate>
                            <asp:TextBox ID="Plots_Alloted_Minority" AutoPostBack="true" Width="45px" OnTextChanged="Plots_Alloted_Minority_TextChanged" runat="server" onkeypress="NumberOnly()"></asp:TextBox>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Center" />
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Women" HeaderStyle-HorizontalAlign="Center" Visible="true">
                        <ItemTemplate>
                            <asp:TextBox ID="Plots_Alloted_Women" AutoPostBack="true" Width="45px" OnTextChanged="Plots_Alloted_Women_TextChanged" runat="server" onkeypress="NumberOnly()"></asp:TextBox>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="General" HeaderStyle-HorizontalAlign="Center" Visible="true">
                        <ItemTemplate>
                            <asp:TextBox ID="Plots_Alloted_General" AutoPostBack="true" OnTextChanged="Plots_Alloted_General_TextChanged" Width="45px" runat="server" onkeypress="NumberOnly()"></asp:TextBox>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Center" />
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="SC" HeaderStyle-HorizontalAlign="Center" Visible="true">
                        <ItemTemplate>
                            <asp:TextBox ID="Plots_Vacant_SC" Width="45px" runat="server" onkeypress="NumberOnly()"></asp:TextBox>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Center" />
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="ST" HeaderStyle-HorizontalAlign="Center" Visible="true" >
                        <ItemTemplate>
                            <asp:TextBox ID="Plots_Vacant_ST" Width="45px" runat="server" onkeypress="NumberOnly()"></asp:TextBox>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Center" />
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="BC" HeaderStyle-HorizontalAlign="Center" Visible="true">
                        <ItemTemplate>
                            <asp:TextBox ID="Plots_Vacant_BC" Width="45px" runat="server" onkeypress="NumberOnly()"></asp:TextBox>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Center" />
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Minority" HeaderStyle-HorizontalAlign="Center" Visible="true">
                        <ItemTemplate>
                            <asp:TextBox ID="Plots_Vacant_Minority" Width="45px" runat="server" onkeypress="NumberOnly()"></asp:TextBox>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Center" />
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Women" HeaderStyle-HorizontalAlign="Center" Visible="true">
                        <ItemTemplate>
                            <asp:TextBox ID="Plots_Vacant_Women" Width="45px" runat="server" onkeypress="NumberOnly()"></asp:TextBox>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="General" HeaderStyle-HorizontalAlign="Center" Visible="true">
                        <ItemTemplate>
                            <asp:TextBox ID="Plots_Vacant_General" Width="45px" runat="server" onkeypress="NumberOnly()"></asp:TextBox>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Center" />
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="SC" HeaderStyle-HorizontalAlign="Center" Visible="true">
                        <ItemTemplate>
                            <asp:TextBox ID="Plots_Allotable_SC" AutoPostBack="true" Width="45px" runat="server" OnTextChanged="Plots_Allotable_SC_TextChanged" onkeypress="NumberOnly()"></asp:TextBox>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Center" />
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="ST" HeaderStyle-HorizontalAlign="Center" Visible="true">
                        <ItemTemplate>
                            <asp:TextBox ID="Plots_Allotable_ST" AutoPostBack="true" Width="45px" runat="server" OnTextChanged="Plots_Allotable_ST_TextChanged" onkeypress="NumberOnly()"></asp:TextBox>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Center" />
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="BC" HeaderStyle-HorizontalAlign="Center" Visible="true">
                        <ItemTemplate>
                            <asp:TextBox ID="Plots_Allotable_BC" AutoPostBack="true" Width="45px" runat="server" OnTextChanged="Plots_Allotable_BC_TextChanged" onkeypress="NumberOnly()"></asp:TextBox>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Center" />
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Minority" HeaderStyle-HorizontalAlign="Center" Visible="true">
                        <ItemTemplate>
                            <asp:TextBox ID="Plots_Allotable_Minority" AutoPostBack="true" Width="45px" runat="server" OnTextChanged="Plots_Allotable_Minority_TextChanged" onkeypress="NumberOnly()"></asp:TextBox>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Center" />
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Women" HeaderStyle-HorizontalAlign="Center" Visible="true">
                        <ItemTemplate>
                            <asp:TextBox ID="Plots_Allotable_Women" AutoPostBack="true" Width="45px" runat="server" OnTextChanged="Plots_Allotable_Women_TextChanged" onkeypress="NumberOnly()"></asp:TextBox>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="General" HeaderStyle-HorizontalAlign="Center" Visible="true">
                        <ItemTemplate>
                            <asp:TextBox ID="Plots_Allotable_General" Width="45px" runat="server" AutoPostBack="true" OnTextChanged="Plots_Allotable_General_TextChanged" onkeypress="NumberOnly()"></asp:TextBox>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Center" />
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Remarks" HeaderStyle-HorizontalAlign="Center" Visible="true">
                        <ItemTemplate>
                            <asp:TextBox ID="Remarks" runat="server"></asp:TextBox>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Center" />
                    </asp:TemplateField>

                    <%--<asp:TemplateField HeaderText="Remarks to Delete">
                        <ItemTemplate>

                            <asp:TextBox runat="server" class="form-control txtbox" Height="50px" Width="100PX"
                                ID="txtremarks" placeholder="Remarks" TextMode="MultiLine" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Delete">
                        <ItemTemplate>
                            <asp:Button ID="btndelete" runat="server" CausesValidation="False" CssClass="btn-success"
                                Height="32px" OnClick="btndelete_Click" OnClientClick="return confirm('Do you want to update the record ? ');"
                                TabIndex="10" Text="Delete" ValidationGroup="group" />

                            <br />

                        </ItemTemplate>
                    </asp:TemplateField>--%>
                </Columns>
                <PagerStyle BackColor="#013161" ForeColor="White" HorizontalAlign="Center" />
                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                <HeaderStyle BackColor="#1d9a5b" CssClass="GRDHEADER" Font-Bold="True" ForeColor="White" />
                <EditRowStyle BackColor="#B9D684" />
                <AlternatingRowStyle BackColor="White" />
            </asp:GridView>
        </div>
        <br />
        <div style="padding-left: 200px; align-content: center">
            <table>
                <tr>
                    <td id="tdSC" visible="false" runat="server" align="center">
                        <h4>Please Fill SC Plot Details</h4>
                    </td>
                    <td id="tdST" visible="false" runat="server" align="center">
                        <h4>Please Fill ST Plot Details</h4>
                    </td>
                    <td id="tdBC" visible="false" runat="server" align="center">
                        <h4>Please Fill BC Plot Details</h4>
                    </td>
                </tr>
                <tr>
                    <td style="padding: 10px;">
                        <asp:GridView ID="SC_GridDetails" runat="server" AutoGenerateColumns="false"
                            CssClass="GRD" ForeColor="#333333" Height="62px" ShowFooter="false" Style="width: 45%" Visible="false">
                            <FooterStyle BackColor="#be8c2f" Font-Bold="True" ForeColor="White" />
                            <RowStyle BackColor="#EBF2FE" CssClass="GRDITEM" HorizontalAlign="Left" VerticalAlign="Middle" />
                            <Columns>
                                <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S.No.">
                                    <ItemTemplate>
                                        <%# Container.DataItemIndex + 1%>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />

                                </asp:TemplateField>
                                <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="Social Category">
                                    <ItemTemplate>
                                        <asp:Label ID="Caste_Category" Width="100px" Enabled="false" Text="SC" runat="server"></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" Width="80px" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="Plot No">
                                    <ItemTemplate>
                                        <asp:TextBox ID="SC_Allotable_PlotNo" Width="100px" runat="server"></asp:TextBox>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" Width="80px" />
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Plot Area(in Sq.Yards)" HeaderStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:TextBox ID="SC_PlotArea" Width="100px" runat="server"></asp:TextBox>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Plot Cost (In lakhs)" HeaderStyle-HorizontalAlign="Center" Visible="true">
                                    <ItemTemplate>
                                        <asp:TextBox ID="SC_PlotCost" Width="150px" runat="server"></asp:TextBox>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                            </Columns>
                            <PagerStyle BackColor="#013161" ForeColor="White" HorizontalAlign="Center" />
                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                            <HeaderStyle BackColor="#1d9a5b" CssClass="GRDHEADER" Font-Bold="True" ForeColor="White" />
                            <EditRowStyle BackColor="#B9D684" />
                            <AlternatingRowStyle BackColor="White" />
                        </asp:GridView>
                    </td>
                    <td style="padding: 10px;">
                        <asp:GridView ID="ST_GridDetails" runat="server" AutoGenerateColumns="false"
                            CssClass="GRD" ForeColor="#333333" Height="62px" ShowFooter="false" Style="width: 45%" Visible="false">
                            <FooterStyle BackColor="#be8c2f" Font-Bold="True" ForeColor="White" />
                            <RowStyle BackColor="#EBF2FE" CssClass="GRDITEM" HorizontalAlign="Left" VerticalAlign="Middle" />
                            <Columns>
                                <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S.No.">
                                    <ItemTemplate>
                                        <%# Container.DataItemIndex + 1%>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />

                                </asp:TemplateField>
                                <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="Social Category">
                                    <ItemTemplate>
                                        <asp:Label ID="Caste_Category" Width="100px" Text="ST" Enabled="false" runat="server"></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" Width="80px" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="Plot No">
                                    <ItemTemplate>
                                        <asp:TextBox ID="ST_Allotable_PlotNo" Width="100px" runat="server"></asp:TextBox>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" Width="80px" />
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Plot Area(in Sq.Yards)" HeaderStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:TextBox ID="ST_PlotArea" Width="100px" runat="server"></asp:TextBox>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Plot Cost (In lakhs)" HeaderStyle-HorizontalAlign="Center" Visible="true">
                                    <ItemTemplate>
                                        <asp:TextBox ID="ST_PlotCost" Width="150px" runat="server"></asp:TextBox>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                            </Columns>
                            <PagerStyle BackColor="#013161" ForeColor="White" HorizontalAlign="Center" />
                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                            <HeaderStyle BackColor="#1d9a5b" CssClass="GRDHEADER" Font-Bold="True" ForeColor="White" />
                            <EditRowStyle BackColor="#B9D684" />
                            <AlternatingRowStyle BackColor="White" />
                        </asp:GridView>
                    </td>
                    <td style="padding: 10px;">
                        <asp:GridView ID="BC_GridDetails" runat="server" AutoGenerateColumns="false"
                            CssClass="GRD" ForeColor="#333333" Height="62px" ShowFooter="false" Style="width: 45%" Visible="false">
                            <FooterStyle BackColor="#be8c2f" Font-Bold="True" ForeColor="White" />
                            <RowStyle BackColor="#EBF2FE" CssClass="GRDITEM" HorizontalAlign="Left" VerticalAlign="Middle" />
                            <Columns>
                                <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S.No.">
                                    <ItemTemplate>
                                        <%# Container.DataItemIndex + 1%>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />

                                </asp:TemplateField>
                                <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="Social Category">
                                    <ItemTemplate>
                                        <asp:Label ID="Caste_Category" Width="100px" Text="BC" Enabled="false" runat="server"></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" Width="80px" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="Plot No">
                                    <ItemTemplate>
                                        <asp:TextBox ID="BC_Allotable_PlotNo" Width="100px" runat="server"></asp:TextBox>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" Width="80px" />
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Plot Area(in Sq.Yards)" HeaderStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:TextBox ID="BC_PlotArea" Width="100px" runat="server"></asp:TextBox>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Plot Cost (In lakhs)" HeaderStyle-HorizontalAlign="Center" Visible="true">
                                    <ItemTemplate>
                                        <asp:TextBox ID="BC_PlotCost" Width="150px" runat="server"></asp:TextBox>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                            </Columns>
                            <PagerStyle BackColor="#013161" ForeColor="White" HorizontalAlign="Center" />
                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                            <HeaderStyle BackColor="#1d9a5b" CssClass="GRDHEADER" Font-Bold="True" ForeColor="White" />
                            <EditRowStyle BackColor="#B9D684" />
                            <AlternatingRowStyle BackColor="White" />
                        </asp:GridView>
                    </td>
                </tr>
                <tr>

                    <td id="tdMinorty" visible="false" runat="server" align="center">
                        <h4>Please Fill Minority Plot Details</h4>
                    </td>
                    <td id="tdWomen" visible="false" runat="server" align="center">
                        <h4>Please Fill Women Plot Details</h4>
                    </td>
                    <td id="tdGeneral" visible="false" runat="server" align="center">
                        <h4>Please Fill General Plot Details</h4>
                    </td>
                </tr>
                <tr>

                    <td style="padding: 10px;">
                        <asp:GridView ID="Minority_GridDetails" runat="server" AutoGenerateColumns="false"
                            CssClass="GRD" ForeColor="#333333" Height="62px" ShowFooter="false" Style="width: 45%" Visible="false">
                            <FooterStyle BackColor="#be8c2f" Font-Bold="True" ForeColor="White" />
                            <RowStyle BackColor="#EBF2FE" CssClass="GRDITEM" HorizontalAlign="Left" VerticalAlign="Middle" />
                            <Columns>
                                <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S.No.">
                                    <ItemTemplate>
                                        <%# Container.DataItemIndex + 1%>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />

                                </asp:TemplateField>
                                <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="Social Category">
                                    <ItemTemplate>
                                        <asp:Label ID="Caste_Category" Width="100px" Text="Minority" Enabled="false" runat="server"></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" Width="80px" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="Plot No">
                                    <ItemTemplate>
                                        <asp:TextBox ID="Minority_Allotable_PlotNo" Width="100px" runat="server"></asp:TextBox>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" Width="80px" />
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Plot Area(in Sq.Yards)" HeaderStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:TextBox ID="Minority_PlotArea" Width="100px" runat="server"></asp:TextBox>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Plot Cost (In lakhs)" HeaderStyle-HorizontalAlign="Center" Visible="true">
                                    <ItemTemplate>
                                        <asp:TextBox ID="Minority_PlotCost" Width="150px" runat="server"></asp:TextBox>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                            </Columns>
                            <PagerStyle BackColor="#013161" ForeColor="White" HorizontalAlign="Center" />
                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                            <HeaderStyle BackColor="#1d9a5b" CssClass="GRDHEADER" Font-Bold="True" ForeColor="White" />
                            <EditRowStyle BackColor="#B9D684" />
                            <AlternatingRowStyle BackColor="White" />
                        </asp:GridView>
                    </td>
                    <%-- </tr>
            <tr>
               
            </tr>
            <tr>--%>
                    <td style="padding: 10px;">
                        <asp:GridView ID="Women_GridDetails" runat="server" AutoGenerateColumns="false"
                            CssClass="GRD" ForeColor="#333333" Height="62px" ShowFooter="false" Style="width: 45%" Visible="false">
                            <FooterStyle BackColor="#be8c2f" Font-Bold="True" ForeColor="White" />
                            <RowStyle BackColor="#EBF2FE" CssClass="GRDITEM" HorizontalAlign="Left" VerticalAlign="Middle" />
                            <Columns>
                                <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S.No.">
                                    <ItemTemplate>
                                        <%# Container.DataItemIndex + 1%>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />

                                </asp:TemplateField>
                                <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="Social Category">
                                    <ItemTemplate>
                                        <asp:Label ID="Caste_Category" Width="100px" Text="Women" Enabled="false" runat="server"></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" Width="80px" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="Plot No">
                                    <ItemTemplate>
                                        <asp:TextBox ID="Women_Allotable_PlotNo" Width="100px" runat="server"></asp:TextBox>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" Width="80px" />
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Plot Area(in Sq.Yards)" HeaderStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:TextBox ID="Women_PlotArea" Width="100px" runat="server"></asp:TextBox>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Plot Cost (In lakhs)" HeaderStyle-HorizontalAlign="Center" Visible="true">
                                    <ItemTemplate>
                                        <asp:TextBox ID="Women_PlotCost" Width="150px" runat="server"></asp:TextBox>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                            </Columns>
                            <PagerStyle BackColor="#013161" ForeColor="White" HorizontalAlign="Center" />
                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                            <HeaderStyle BackColor="#1d9a5b" CssClass="GRDHEADER" Font-Bold="True" ForeColor="White" />
                            <EditRowStyle BackColor="#B9D684" />
                            <AlternatingRowStyle BackColor="White" />
                        </asp:GridView>
                    </td>
                    <td style="padding: 10px;">
                        <asp:GridView ID="General_GridDetails" runat="server" AutoGenerateColumns="false"
                            CssClass="GRD" ForeColor="#333333" Height="62px" ShowFooter="false" Style="width: 45%" Visible="false">
                            <FooterStyle BackColor="#be8c2f" Font-Bold="True" ForeColor="White" />
                            <RowStyle BackColor="#EBF2FE" CssClass="GRDITEM" HorizontalAlign="Left" VerticalAlign="Middle" />
                            <Columns>
                                <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S.No.">
                                    <ItemTemplate>
                                        <%# Container.DataItemIndex + 1%>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />

                                </asp:TemplateField>
                                <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="Social Category">
                                    <ItemTemplate>
                                        <asp:Label ID="Caste_Category" Width="100px" Text="General" Enabled="false" runat="server"></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" Width="80px" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="Plot No">
                                    <ItemTemplate>
                                        <asp:TextBox ID="General_Allotable_PlotNo" Width="100px" runat="server"></asp:TextBox>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" Width="80px" />
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Plot Area(in Sq.Yards)" HeaderStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:TextBox ID="General_PlotArea" Width="100px" runat="server"></asp:TextBox>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Plot Cost (In lakhs)" HeaderStyle-HorizontalAlign="Center" Visible="true">
                                    <ItemTemplate>
                                        <asp:TextBox ID="General_PlotCost" Width="150px" runat="server"></asp:TextBox>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                            </Columns>
                            <PagerStyle BackColor="#013161" ForeColor="White" HorizontalAlign="Center" />
                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                            <HeaderStyle BackColor="#1d9a5b" CssClass="GRDHEADER" Font-Bold="True" ForeColor="White" />
                            <EditRowStyle BackColor="#B9D684" />
                            <AlternatingRowStyle BackColor="White" />
                        </asp:GridView>
                    </td>
                </tr>
            </table>
        </div>
        <br />
        <div id="ADDRECORD_CLEAR_BTNS" visible="false" runat="server" class="row" align="center">
            <asp:Button ID="AddRecordBtn" runat="server" Text="ADD RECORD" Style="background-color: forestgreen; color: ghostwhite; border-radius: 5px;" Height="35px" Width="150px" OnClick="AddRecordBtn_Click" />
            <asp:Button ID="ClearRecordBtn" runat="server" Text="CLEAR RECORD" Style="background-color: red; color: ghostwhite; border-radius: 5px;" Height="35px" Width="150px" OnClick="ClearRecordBtn_Click" />
        </div>
        <br />
        <div <%--style="max-width: 1200px; overflow-x: auto;"--%>>
            <asp:Label ID="lblIEplots" Visible="false" runat="server" Text="Industrial Estate Plots Details:" Font-Size="20px"> </asp:Label>
            <asp:GridView runat="server" ID="Weaker_Section_TEMPGrid" AutoGenerateColumns="true" OnRowCommand="Weaker_Section_TEMPGrid_RowCommand"
                CssClass="GRD" ForeColor="#333333" Height="62px" ShowFooter="false" Style="width: 100%"
                OnRowCreated="Weaker_Section_TEMPGrid_RowCreated">
                <FooterStyle BackColor="#be8c2f" Font-Bold="True" ForeColor="White" />
                <RowStyle BackColor="#EBF2FE" CssClass="GRDITEM" HorizontalAlign="Left" VerticalAlign="Middle" />
                <Columns>
                    <asp:TemplateField HeaderText="S No.">
                        <ItemTemplate>
                            <asp:Label ID="SNo" runat="server" Text='<%#Container.DataItemIndex + 1 %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <%--<asp:TemplateField HeaderText="IE Name">
                    <ItemTemplate>
                        <asp:Label ID="lblnameofindestate" runat="server" Text='<%#Eval("nameofindestate") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="TSIIC Promoted/Prompted">
                    <ItemTemplate>
                        <asp:Label ID="lblwhethertsiicpromotedorprivate" runat="server" Text='<%#Eval("whethertsiicpromotedorprivate") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Officer Name">
                    <ItemTemplate>
                        <asp:Label ID="lblnodalofficername" runat="server" Text='<%#Eval("nodalofficername") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Designation">
                    <ItemTemplate>
                        <asp:Label ID="lblnodalofficerdesignation" runat="server" Text='<%#Eval("nodalofficerdesignation") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Available">
                    <ItemTemplate>
                        <asp:Label ID="lbltotalnoofplotsavailable" runat="server" Text='<%#Eval("totalnoofplotsavailable") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Allotted">
                    <ItemTemplate>
                        <asp:Label ID="lbltotalnoofplotsalloted" runat="server" Text='<%#Eval("totalnoofplotsalloted") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Vacant">
                    <ItemTemplate>
                        <asp:Label ID="lbltotalnoofplotsvacant" runat="server" Text='<%#Eval("totalnoofplotsvacant") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Not set up after mandatory period">
                    <ItemTemplate>
                        <asp:Label ID="lblnoofplotsunitsnotsetmandatory" runat="server" Text='<%#Eval("noofplotsunitsnotsetmandatory") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="For reallocation to weaker sections">
                    <ItemTemplate>
                        <asp:Label ID="lblnoofplotsforreallocation" runat="server" Text='<%#Eval("noofplotsforreallocation") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="SC">
                    <ItemTemplate>
                        <asp:Label ID="lbltotalplotsmandatedforsc" runat="server" Text='<%#Eval("totalplotsmandatedforsc") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="ST">
                    <ItemTemplate>
                        <asp:Label ID="lbltotalplotsmandatedforst" runat="server" Text='<%#Eval("totalplotsmandatedforst") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="BC">
                    <ItemTemplate>
                        <asp:Label ID="lbltotalplotsmandatedforbc" runat="server" Text='<%#Eval("totalplotsmandatedforbc") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Minority">
                    <ItemTemplate>
                        <asp:Label ID="lbltotalplotsmandatedforminority" runat="server" Text='<%#Eval("totalplotsmandatedforminority") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Women">
                    <ItemTemplate>
                        <asp:Label ID="lbltotalplotsmandatedforwomen" runat="server" Text='<%#Eval("totalplotsmandatedforwomen") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="SC">
                    <ItemTemplate>
                        <asp:Label ID="lbltotalplotsallottedforsc" runat="server" Text='<%#Eval("totalplotsallottedforsc") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="ST">
                    <ItemTemplate>
                        <asp:Label ID="lbltotalplotsallottedforst" runat="server" Text='<%#Eval("totalplotsallottedforst") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="BC">
                    <ItemTemplate>
                        <asp:Label ID="lbltotalplotsallottedforbc" runat="server" Text='<%#Eval("totalplotsallottedforbc") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Minority">
                    <ItemTemplate>
                        <asp:Label ID="lbltotalplotsallottedforminority" runat="server" Text='<%#Eval("totalplotsallottedforminority") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Women">
                    <ItemTemplate>
                        <asp:Label ID="lbltotalplotsallottedforwomen" runat="server" Text='<%#Eval("totalplotsallottedforwomen") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="SC">
                    <ItemTemplate>
                        <asp:Label ID="lbltotalplotsvacantforsc" runat="server" Text='<%#Eval("totalplotsvacantforsc") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="ST">
                    <ItemTemplate>
                        <asp:Label ID="lbltotalplotsvacantforst" runat="server" Text='<%#Eval("totalplotsvacantforst") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="BC">
                    <ItemTemplate>
                        <asp:Label ID="lbltotalplotsvacantforbc" runat="server" Text='<%#Eval("totalplotsvacantforbc") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Minority">
                    <ItemTemplate>
                        <asp:Label ID="lbltotalplotsvacantforminority" runat="server" Text='<%#Eval("totalplotsvacantforminority") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Women">
                    <ItemTemplate>
                        <asp:Label ID="lbltotalplotsvacantforwomen" runat="server" Text='<%#Eval("totalplotsvacantforwomen") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Remarks">
                    <ItemTemplate>
                        <asp:Label ID="lblanyotherremarks" runat="server" Text='<%#Eval("anyotherremarks") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>--%>

                    <asp:TemplateField HeaderStyle-Font-Size="16px" HeaderStyle-Font-Bold="true" HeaderStyle-ForeColor="White"
                        HeaderText="Delete" Visible="false">
                        <ItemStyle Font-Size="Small" CssClass="BorderRight" />
                        <ItemTemplate>
                            <asp:LinkButton ID="lnkRenRemove" runat="server" CommandName="WeakerSectionDELETE"  Font-Bold="true"
                                ForeColor="#ff3300"><u>Delete</u></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <PagerStyle BackColor="#013161" ForeColor="White" HorizontalAlign="Center" />
                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                <HeaderStyle BackColor="#1d9a5b" CssClass="GRDHEADER" Font-Bold="True" ForeColor="White" />
                <EditRowStyle BackColor="#B9D684" />
                <AlternatingRowStyle BackColor="White" />
            </asp:GridView>
        </div>
        <br />
        <div id="SUBMIT_CLEAR_BTNS" runat="server" class="row" align="center">
            <asp:Button ID="SUBMITRECORD" runat="server" Text="SUBMIT" Style="background-color: forestgreen; color: ghostwhite; border-radius: 5px;" Height="35px" Width="150px" OnClick="SUBMITRECORD_Click" />
            <asp:Button ID="CLEARPAGE" runat="server" Text="CLEAR" Style="background-color: red; color: ghostwhite; border-radius: 5px;" Height="35px" Width="150px" OnClick="CLEARPAGE_Click" />
        </div>
        <br />
    </contenttemplate>
</asp:Content>
