<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Acts_Rules.aspx.cs" Inherits="Acts_Rules" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Acts & Rules</title>

    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/css/bootstrap.min.css" rel="stylesheet" />
    <style>
        body {
            font-family: Arial, Helvetica, sans-serif;
            background-color: #f5f5f5;
        }

        .page-title {
            background: #c7942b;
            color: white;
            padding: 12px;
            text-align: center;
            font-size: 24px;
            font-weight: bold;
            margin-bottom: 20px;
        }

        .search-panel {
            background: #fff;
            border: 1px solid #ddd;
            padding: 20px;
            border-radius: 5px;
            margin-bottom: 20px;
        }

        .search-label {
            font-weight: bold;
            margin-bottom: 5px;
            display: block;
        }

        .search-btn {
            background: #28a745;
            color: white;
            border: none;
            padding: 8px 35px;
            border-radius: 4px;
        }

            .search-btn:hover {
                background: #218838;
            }

        .grid-panel {
            background: white;
            padding: 10px;
            border: 1px solid #ddd;
        }

        .gridview {
            width: 100%;
        }

            .gridview th {
                background: #c7942b;
                color: white;
                text-align: center;
                padding: 10px;
            }

            .gridview td {
                padding: 8px;
            }

        .view-link {
            color: red;
            font-weight: bold;
            text-decoration: none;
        }

            .view-link:hover {
                text-decoration: underline;
            }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="page-title">Centralised Repository of Acts / Rules / Regulations </div>
        <div>
            <table style="width: 100%">
                <tr>
                    <td align="center" colspan="8" style="padding: 5px; margin: 5px">
                        <div id="success" runat="server" visible="false" class="alert alert-success">
                            <a href="AddQualification.aspx" class="close" data-dismiss="alert" aria-label="close" runat="server" visible="false">&times;</a> <strong>Success!</strong><asp:Label ID="lblmsg" runat="server"></asp:Label>
                        </div>
                        <div id="Failure" runat="server" visible="false" class="alert alert-danger">
                            <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a> <strong>Warning!</strong>
                            <asp:Label ID="lblmsg0" runat="server"></asp:Label>
                        </div>
                        <asp:HiddenField ID="hdnUserID" runat="server" />
                    </td>
                </tr>
            </table>
        </div>
        <div class="search-panel">
            <div class="row">
                <div class="col-md-4">
                    <label class="search-label">Department Name </label>
                    <asp:DropDownList ID="ddlDepartment" runat="server" CssClass="form-select" AutoPostBack="true" OnSelectedIndexChanged="ddlDepartment_SelectedIndexChanged">
                            <asp:ListItem Text="--Select--" Value="0" Selected="True"></asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div class="col-md-4">
                    <label class="search-label">Act / Rules / GO No. / Memo No. / Circular No. </label>
                    <asp:DropDownList ID="ddlActs" runat="server" CssClass="form-select" AutoPostBack="true" OnSelectedIndexChanged="ddlActs_SelectedIndexChanged">
                        <asp:ListItem Text="--Select--" Value="0"></asp:ListItem>
                    </asp:DropDownList>
                </div>
               <div class="col-md-4">
                    <label class="search-label">Enter Text. </label>
                    <asp:TextBox ID="txtSearch" runat="server" CssClass="form-control" placeholder="Enter Text" AutoPostBack="true" OnTextChanged="txtSearch_TextChanged"></asp:TextBox>
                </div>
            </div>


            <div class="text-center mt-4">
                <asp:Button ID="btnSubmit" runat="server" Text="Search" CssClass="search-btn" OnClick="btnSubmit_Click" />
            </div>
        </div>
        <div class="grid-panel">
            <asp:GridView ID="GVActsRules" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered table-striped gridview" EmptyDataText="No Records Found" OnRowDataBound="GVActsRules_RowDataBound">
                <Columns>
                    <asp:TemplateField HeaderText="S.No">
                        <ItemTemplate>
                            <%# Container.DataItemIndex + 1 %>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" Width="60px" />
                    </asp:TemplateField>

                    <asp:BoundField DataField="SNo" HeaderText="S.NO" Visible="false" />
                    <asp:BoundField DataField="Dept_id" HeaderText="Departmentid" Visible="false" />
                    <asp:BoundField DataField="DepartmentName" HeaderText="Department Name" Visible="true" />
                    <asp:BoundField DataField="ActRulesGONoMemoNoCircularNo" HeaderText="Act Rules GO No Memo No Circular No" />
                    <asp:BoundField DataField="Date" HeaderText="DATE">
                        <HeaderStyle Width="150px" />
                        <ItemStyle Width="150px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="SubjectName" HeaderText="SUBJECT" />
                    <asp:TemplateField HeaderText="GO">
                        <ItemTemplate>
                            <asp:HyperLink ID="lnkView" runat="server" NavigateUrl='<%# Eval("GOCopy") %>' Text="View" CssClass="view-link-green" Target="_blank"></asp:HyperLink>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>
