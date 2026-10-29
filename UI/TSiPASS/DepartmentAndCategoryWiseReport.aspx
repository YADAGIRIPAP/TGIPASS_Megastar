<%@ Page Language="C#" MasterPageFile="~/UI/TSiPASS/CCMaster.master" AutoEventWireup="true"
    CodeFile="DepartmentAndCategoryWiseReport.aspx.cs" Inherits="DepartmentAndCategoryWiseReport"
    Title=":: TS-iPASS :: DEPARTMENT WISE REPORT" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <br />
     <div class="panel panel-primary">
                    <div class="panel-heading">
                        <h3 class="panel-title">
                           R2.1 STATUS OF PRESCRUTINY - DISTRICT WISE</h3>
                    </div>
                    <div class="panel-body">
    <table cellpadding="0" cellspacing="0" width="100%" align="center" style="border: 1px solid #013161">
       <tr>
            <td>
          
            </td>
            
        </tr>
        <tr>
            <%--<td style="padding-right: 30px; padding-bottom: 0px; vertical-align: top; text-align: right">             
                                        <asp:ImageButton ID="imgprint" runat="server" 
                     ImageUrl="~/Images/printimage.jpg" Width="25px" 
                     onclientclick="window.print();return false;" ToolTip="Print Page" onclick="imgprint_Click" /></td>--%>
        </tr>
        <tr>
            <td align="center" style="padding-bottom: 5px; padding-top: 5px">
                <asp:Label ID="lblmsg" runat="server" Font-Bold="True" Font-Names="Verdana" Font-Size="12px"
                    ForeColor="#004000"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <table width="70%" style="text-align: left; font-family: Verdana; font-size: 12px;"
                    align="center" runat="server" id="tbldet">
                    <tr>
                        <td width="15%" colspan="5" style="width: 50%">
                            <table width="20%">
                                <tr>
                                    <td style="width: 22%; padding-right: 5px; padding-left: 5px; padding-bottom: 5px;
                                        vertical-align: top; padding-top: 5px; text-align: left;" __designer:mapid="133"
                                        align="right">
                                        <asp:Label ID="lblSector0" runat="server" CssClass="LBLBLACK" Text="Category" Width="110px"
                                            Height="16px"></asp:Label>
                                    </td>
                                    <td width="20%" style="width: 3%; padding-right: 5px; padding-left: 5px; padding-bottom: 5px;
                                        vertical-align: top; padding-top: 5px; text-align: left;" __designer:mapid="135"
                                        align="left">
                                        <asp:Label ID="Label91" runat="server" CssClass="LBLBLACK" Text=":"></asp:Label>
                                    </td>
                                    <td align="left" style="padding-right: 5px; padding-left: 5px; padding-bottom: 5px;
                                        vertical-align: top; width: 22%; padding-top: 5px; text-align: left">
                                        <asp:DropDownList ID="ddlCategory" runat="server" class="form-control txtbox" Height="33px"
                                            Width="180px">
                                            <asp:ListItem>ALL</asp:ListItem>
                                            <asp:ListItem Value="1">MEGA</asp:ListItem>
                                            <asp:ListItem Value="2">LARGE</asp:ListItem>
                                            <asp:ListItem Value="3">MEDIUM</asp:ListItem>
                                            <asp:ListItem Value="4">SMALL</asp:ListItem>
                                            <asp:ListItem Value="5">MICRO</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td align="left" style="padding: 5px; vertical-align: top; width: 10%; text-align: left">
                                        &nbsp;
                                    </td>
                                    <td align="left" __designer:mapid="139">
                                        <asp:Label ID="lblbatch0" runat="server" CssClass="LBLBLACK" Text="Department"
                                            Width="150px"></asp:Label>
                                    </td>
                                    <td width="20%" style="width: 0%" __designer:mapid="13b">
                                        <asp:Label ID="Label93" runat="server" CssClass="LBLBLACK" Text=":"></asp:Label>
                                    </td>
                                    <td align="left" style="padding-right: 5px; padding-left: 5px; padding-bottom: 5px;
                                        vertical-align: top; width: 22%; padding-top: 5px; text-align: left">
                                        <asp:DropDownList ID="ddlDepartment" runat="server" class="form-control txtbox" Height="33px"
                                            Width="180px" AutoPostBack="True">
                                            <asp:ListItem>ALL</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr __designer:mapid="9cf">
                                    <td style="padding: 5px; margin: 5px; text-align: left;" __designer:mapid="9d1">
                                        <asp:Label ID="Label387" runat="server" CssClass="LBLBLACK" Width="210px">From Date</asp:Label>
                                    </td>
                                    <td class="style7" style="padding: 5px; margin: 5px" __designer:mapid="9d3">
                                        :
                                    </td>
                                    <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;" __designer:mapid="9d4">
                                        <asp:TextBox ID="txtFromDate" runat="server" class="form-control txtbox" Height="28px"
                                            MaxLength="40" TabIndex="1" ValidationGroup="group" Width="180px"></asp:TextBox>
                                        <cc1:CalendarExtender ID="CalendarExtender2" runat="server" Format="dd-MM-yyyy" PopupButtonID="txtFromDate"
                                            TargetControlID="txtFromDate">
                                        </cc1:CalendarExtender>
                                    </td>
                                    <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;" __designer:mapid="9d7">
                                        &nbsp;
                                    </td>
                                
                                                <td style="width: 200px;" __designer:mapid="9de">
                                                    <asp:Label ID="Label1" runat="server" CssClass="LBLBLACK" Width="150px">To Date</asp:Label>
                                                </td>
                                                <td style="padding: 5px; margin: 5px" __designer:mapid="9e0">
                                                   <asp:Label ID="Label2" runat="server" CssClass="LBLBLACK" >:</asp:Label>
                                                </td>
                                                <td style="padding: 5px; margin: 5px" __designer:mapid="9e1">
                                                    <asp:TextBox ID="txtToDate" runat="server" class="form-control txtbox" Height="28px"
                                                        MaxLength="40" TabIndex="1" ValidationGroup="group" Width="180px"></asp:TextBox>
                                                    <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd-MM-yyyy"
                                                        PopupButtonID="txtToDate" TargetControlID="txtToDate">
                                                    </cc1:CalendarExtender>
                                                </td>
                                                <td style="padding: 5px; margin: 5px" __designer:mapid="9e4">
                                                    &nbsp;
                                                </td>
                                            </tr>
                            </table>
                            
                        </td>
                    </tr>
                    <tr>
                        <td align="center" colspan="5" style="text-align: center">
                            <asp:Button ID="BtnBatchsave0" runat="server" CssClass="btn btn-primary" Height="32px"
                                TabIndex="10" Text="Search" Width="90px" OnClick="BtnBatchsave0_Click" ValidationGroup="group" />
                            &nbsp;
                            <asp:Button ID="Button2" runat="server" CausesValidation="False" CssClass="btn btn-warning"
                                Height="32px" OnClick="Button2_Click" ValidationGroup="group" TabIndex="10" Text="Cancel"
                                ToolTip="To Clear  the Screen" Width="90px" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            <asp:ValidationSummary ID="vg" runat="server" ForeColor="Green" ShowMessageBox="True"
                                ShowSummary="False" Style="position: static" ValidationGroup="group" />
                        </td>
                        <td style="width: 15%">
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td align="center" style="text-align: center">
                <asp:GridView ID="grdtraineedetails" runat="server" AutoGenerateColumns="False" Width="100%"
                    BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" CssClass="GRD"
                    Font-Names="Verdana" Font-Size="13px" ForeColor="#333333" AllowPaging="True" ShowFooter="True" 
                    OnPageIndexChanging="grdtraineedetails_PageIndexChanging" OnSorting="grdtraineedetails_Sorting"
                    OnRowDataBound="grdtraineedetails_RowDataBound" PageSize="20" OnRowCreated="grdtraineedetails_RowCreated"
                    OnSelectedIndexChanged="grdtraineedetails_SelectedIndexChanged">
                    <RowStyle BackColor="#FFFFFF" />
                    <footerstyle backcolor="#013161" font-bold="True" forecolor="White" />
                    <Columns>
                        <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Sl.No">
                            <ItemTemplate>
                                <%# Container.DataItemIndex +1 %>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle Width="20px" />
                        </asp:TemplateField>
                        <%--<asp:TemplateField Visible="false">
                            <ItemTemplate>
                                <asp:Label ID="lbldistritid" runat="server" Text='<%#Eval("District_Id") %>'
                            </ItemTemplate>
                        </asp:TemplateField>--%>
                        <asp:HyperLinkField HeaderText="District Name" DataTextField="DistrictName">
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:HyperLinkField>
                        <asp:HyperLinkField HeaderText="Approvals Received" DataTextField="NumberofApplicationsReceived">
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:HyperLinkField>
                        <asp:HyperLinkField HeaderText="Completed" DataTextField="Completed">
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:HyperLinkField>
                        <asp:HyperLinkField HeaderText="Query Raised" DataTextField="QueryRaised">
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:HyperLinkField>
                        <asp:HyperLinkField HeaderText="Pending less than 3 days" DataTextField="Pendinglessthan3days">
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:HyperLinkField>
                        <asp:HyperLinkField HeaderText="Pending more than 3 days" DataTextField="Pendingmorethan3days">
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:HyperLinkField>
                    </Columns>
                    <PagerStyle BackColor="#013161" ForeColor="White" />
                    <SelectedRowStyle BackColor="#D1DDF1" ForeColor="#333333" />
                    <HeaderStyle BackColor="#013161"  ForeColor="White" />
                    <EditRowStyle BackColor="#013161" />
                    <AlternatingRowStyle BackColor="White" />
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td align="center">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td align="center">
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
                    ShowSummary="False" ValidationGroup="pia" />
                <asp:HiddenField ID="hdfpiaid" runat="server" />
                <asp:HiddenField ID="hdfstatus" runat="server" />
                <asp:HiddenField ID="hdfblock" runat="server" />
            </td>
        </tr>
    </table>
     </div>
                </div>
</asp:Content>
