<%@ Page Title="" Language="C#" MasterPageFile="~/UI/TSiPASS/CCMaster.master" AutoEventWireup="true" CodeFile="UserSearch.aspx.cs" Inherits="UI_TSiPASS_UserSearch" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <style type="text/css">
        .overlay {
            position: fixed;
            z-index: 999;
            height: 100%;
            width: 100%;
            top: 1px;
            background-color: Gray;
            filter: alpha(opacity=60);
            opacity: 0.9;
            -moz-opacity: 0.9;
        }

        .textboxPge {
            border: 1px solid #c4c4c4;
            height: 30px;
            width: 140px;
            font-size: 13px;
            padding: 4px 4px 4px 4px;
            border-radius: 4px;
            -moz-border-radius: 4px;
            -webkit-border-radius: 4px;
            box-shadow: 0px 0px 8px #d9d9d9;
            -moz-box-shadow: 0px 0px 8px #d9d9d9;
            -webkit-box-shadow: 0px 0px 8px #d9d9d9;
        }

            .textboxPge:focus {
                outline: none;
                border: 1px solid #7bc1f7;
                box-shadow: 0px 0px 8px #7bc1f7;
                -moz-box-shadow: 0px 0px 8px #7bc1f7;
                -webkit-box-shadow: 0px 0px 8px #7bc1f7;
            }
    </style>
    <asp:UpdatePanel ID="upd1" runat="server">
        <ContentTemplate>

            <div align="left">
                <ol class="breadcrumb">
                    You are here
        &nbsp;!&nbsp; &nbsp; &nbsp; 
                            <li>
                                <i class="fa fa-dashboard"></i><a href="index.html">ADMIN</a>
                            </li>
                    <li class="">
                        <i class="fa fa-fw fa-table"></i>User Search
                    </li>

                </ol>
            </div>
            <%--<div class="alert alert-warning fade in" id="warning" runat="server" visible="false">
    <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a>
    <strong>Warning!</strong> <asp:Label ID="lbluserid0" runat="server" 
        CssClass="" ></asp:Label>
    &nbsp;
  </div>--%>
            <div align="center">
                <div class="row" align="center">
                    <div class="col-lg-11">
                        <div class="panel panel-primary">
                            <div class="panel-heading">
                                <h3 class="panel-title">USER SEARCH</h3>
                            </div>
                            <div class="panel-body">
                                <table align="center" cellpadding="10" cellspacing="5" style="width: 80%">

                                    <tr>
                                        <td align="center" valign="middle" width="30%">Input : 
                                               <asp:DropDownList ID="ddlFinancialYear" runat="server" class="textboxPge" Height="33px" Width="200px">
                                                   <asp:ListItem Value="1">UID NO</asp:ListItem>
                                                   <asp:ListItem Value="2">User ID</asp:ListItem>
                                                   <asp:ListItem Value="3">Entrepreneur Id</asp:ListItem>
                                                   <asp:ListItem Value="5">Unit Name</asp:ListItem>
                                                     <asp:ListItem Value="6">CreatedBy</asp:ListItem>
                                                    <asp:ListItem Value="7">Incentive ID</asp:ListItem>
                                                   <asp:ListItem Value="8">RM ID</asp:ListItem>
                                                   <asp:ListItem Value="9">DIC LOGINS</asp:ListItem>
                                               </asp:DropDownList>
                                        </td>
                                        <td align="left" valign="middle" width="30%">Enter Input:              
                                            <asp:TextBox ID="txtUserName" runat="server" MaxLength="50" class="textboxPge"></asp:TextBox></td>
                                    </tr>
                                    <tr>
                                        <td align="center" colspan="3" style="padding: 5px; margin: 5px">&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td align="center" colspan="2"
                                            style="padding: 5px; margin: 5px; text-align: center;">
                                            <asp:Button ID="BtnSave1" runat="server" CssClass="btn btn-primary"
                                                Height="32px" TabIndex="2" Text="Search"
                                                ValidationGroup="group" Width="90px" OnClick="BtnSave1_Click" />
                                            <asp:Button ID="BtnClear" runat="server" CausesValidation="False"
                                                CssClass="btn btn-warning" Height="32px" OnClick="BtnClear_Click" TabIndex="10"
                                                Text="ClearAll" ToolTip="To Clear  the Screen" Width="90px" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left" style="padding: 5px; margin: 5px" valign="top" colspan="2">
                                            <asp:GridView ID="grdDetails" runat="server" AutoGenerateColumns="False"
                                                CellPadding="5" ForeColor="#333333" Height="62px"
                                                ShowFooter="True" Width="100%" Visible="false" OnRowDataBound="grdDetails_RowDataBound">
                                                <FooterStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                                <RowStyle BackColor="#EBF2FE" HorizontalAlign="Left" VerticalAlign="Middle" />
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
                                                    <asp:BoundField DataField="User_name" HeaderText="User Name" />
                                                    <asp:BoundField DataField="User_id" HeaderText="User ID" />
                                                    <asp:BoundField DataField="Password" HeaderText="Password" />
                                                    <asp:BoundField DataField="nameofunit" HeaderText="Name of Unit" />
                                                    <asp:BoundField DataField="intUserid" HeaderText="intUserid" />
                                                    <asp:BoundField DataField="CFEUID" HeaderText="CFE UID" />
                                                    <asp:BoundField DataField="CFOUID" HeaderText="CFO UID" />
                                                    <asp:BoundField DataField="RENUID" HeaderText="REN UID" />
                                                    <asp:BoundField DataField="PLOTUID" HeaderText="PLOT UID" />
                                                    <asp:BoundField DataField="BMWUID" HeaderText="BMW UID" />
                                                     <asp:BoundField DataField="INCID" HeaderText="Incentive IDs" />
                                                     <asp:BoundField DataField="RMID" HeaderText="RM IDs" />
                                                </Columns>
                                                <PagerStyle BackColor="#013161" ForeColor="White" HorizontalAlign="Center" />
                                                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                                <HeaderStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                                <EditRowStyle BackColor="#B9D684" />
                                                <AlternatingRowStyle BackColor="White" />
                                            </asp:GridView>
                                        </td>
                                    </tr>
                                    <tr runat="server" id="TRMULTIPLELOGINDETAILSBYINTUSERIDS" visible="false">
                                        <td align="left" style="padding: 5px; margin: 5px" valign="top" colspan="2">
                                            <asp:GridView ID="GRDMULTIPLELOGINDETAILS" runat="server" AutoGenerateColumns="False"
                                                CellPadding="5" ForeColor="#333333" Height="62px"
                                                ShowFooter="True" Width="100%" Visible="false" OnRowDataBound="GRDMULTIPLELOGINDETAILS_RowDataBound">
                                                <FooterStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                                <RowStyle BackColor="#EBF2FE" HorizontalAlign="Left" VerticalAlign="Middle" />
                                                <Columns>
                                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S No">
                                                        <ItemTemplate>
                                                            <%# Container.DataItemIndex + 1%>
                                                            <asp:HiddenField ID="HiddenField1" runat="server" />
                                                            <asp:HiddenField ID="HiddenField2" runat="server" />
                                                        </ItemTemplate>
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                        <ItemStyle Width="50px" />
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="User_name" HeaderText="User Name" />
                                                    <asp:BoundField DataField="User_id" HeaderText="User ID" />
                                                    <asp:BoundField DataField="Password" HeaderText="Password" />
                                                    <asp:BoundField DataField="intUserid" HeaderText="intUserid" />
                                                     <asp:BoundField DataField="Emp_Name" HeaderText="Name" />
                                                    <asp:BoundField DataField="MobileNumber" HeaderText="MobileNumber" />
                                                    <asp:BoundField DataField="Dist_Name" HeaderText="District" />
                                                </Columns>
                                                <PagerStyle BackColor="#013161" ForeColor="White" HorizontalAlign="Center" />
                                                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                                <HeaderStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                                <EditRowStyle BackColor="#B9D684" />
                                                <AlternatingRowStyle BackColor="White" />
                                            </asp:GridView>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center" colspan="2" style="padding: 5px; margin: 5px">
                                            <div id="success" runat="server" visible="false" class="alert alert-success">
                                                <a href="AddQualification.aspx" class="close" data-dismiss="alert" aria-label="close">&times;</a>
                                                <strong>Success!</strong><asp:Label ID="lblmsg" runat="server"></asp:Label>
                                            </div>
                                            <div id="Failure" runat="server" visible="false" class="alert alert-danger">
                                                <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a>
                                                <strong>Warning!</strong> No Records available.
                                            </div>
                                        </td>
                                    </tr>
                                </table>
                                <asp:HiddenField ID="hdfID" runat="server" />
                                <asp:ValidationSummary ID="ValidationSummary1" runat="server"
                                    ShowMessageBox="True" ShowSummary="False" ValidationGroup="group" />
                                <asp:HiddenField ID="hdfFlagID" runat="server" />
                            </div>
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

            <br />


        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

