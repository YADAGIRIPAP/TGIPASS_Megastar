<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AwardDetails.aspx.cs" Inherits="AwardDetails" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Best Company Awards 2018</title>

    <link href="UI/TSIPASS/assets/css/basic.css" rel="stylesheet" />

    <meta name="description" content="">
    <meta name="author" content="">
    <link href="css/style.css" rel="stylesheet" type="text/css">
    <link href="css/shortcodes.css" rel="stylesheet" type="text/css">
    <link href="css/responsive.css" rel="stylesheet" type="text/css">
    <link rel="stylesheet" href="css/layerslider.css" type='text/css' media='all' />
    <link href="css/font-awesome.min.css" rel="stylesheet" type="text/css">
    <link href="skins/maroon/style.css" rel="stylesheet" media="all" />

    <link href='http://fonts.googleapis.com/css?family=Merriweather:400,900italic,900,700italic,700,400italic,300italic,300' rel='stylesheet' type='text/css'>
    <link href='http://fonts.googleapis.com/css?family=Domine:400,700' rel='stylesheet' type='text/css'>
    <link href='http://fonts.googleapis.com/css?family=Noto+Serif:400,700,400italic,700italic' rel='stylesheet' type='text/css'>
    <link href='http://fonts.googleapis.com/css?family=Open+Sans:300italic,400italic,600italic,700italic,800italic,400,300,600,700,800' rel='stylesheet' type='text/css'>

    <%-- <script type="text/javascript" src="js/jquery.js"></script>--%>
    <script type="text/javascript" src="js/jquery-1.11.3.min.js"></script>
    <style>
        /*input[id$="chkMicro1"] {
            width: 50px;
            height: 50px;
        }*/

        #chkMicro1 {
            width: 50px;
            height: 50px;
        }

        .btn-primary {
            color: #fff;
            background-color: #337ab7;
            border-color: #2e6da4;
        }

            .btn-primary:hover,
            .btn-primary:focus,
            .btn-primary.focus,
            .btn-primary:active,
            .btn-primary.active,
            .open > .dropdown-toggle.btn-primary {
                color: #fff;
                background-color: #286090;
                border-color: #204d74;
            }

            .btn-primary:active,
            .btn-primary.active,
            .open > .dropdown-toggle.btn-primary {
                background-image: none;
            }

        .CS {
            background-color: #abcdef;
            color: blue;
            border: 1px solid #1d9a5b;
            font: Verdana 10px;
            padding: 1px 4px;
            font-family: Palatino Linotype, Arial, Helvetica, sans-serif;
        }

        th {
            padding: 6px !important;
        }

        td {
            padding: 6px 15px !important;
            color: black !important;
            text-align: left !important;
        }
    </style>
    <script>

        $(function () {
            $('input[type="checkbox"]').on('change', function () {
                $('input[type="checkbox"]').not(this).prop('checked', false);
            });
        });

    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div style="width: 100%" align="center">
            <table style="width: 60%" align="center">
                <tr>
                    <td colspan="5">
                        <div align="left">
                            <div class="row" align="left">
                                <div class="col-lg-11">
                                    <div class="col-md-12">
                                        <h1 class="page-head-line" align="left" style="font-size: x-large">Best Company Awards 2019</h1>
                                    </div>
                                    <div class="dt-sc-hr-invisible-very-small"></div>
                                </div>
                            </div>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td  style="padding: 5px; margin: 5px; text-align: left;">Type of Enterprise :&nbsp;&nbsp;&nbsp;
                            <asp:DropDownList ID="ddlEnterPriseType" ForeColor="Black"   runat="server" Height="30px"  Width="180px">
                                <asp:ListItem Value="All">All</asp:ListItem>
                                <asp:ListItem Value="Micro Enterprises">Micro Enterprises</asp:ListItem>
                                <asp:ListItem Value="Small Enterprises">Small Enterprises</asp:ListItem>
                                <asp:ListItem Value="Medium Enterprises">Medium</asp:ListItem>
                                <asp:ListItem Value="Large Enterprises">Large</asp:ListItem>
                            </asp:DropDownList> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                   
                        <asp:Button ID="Button3" runat="server" CssClass="btn btn-default" TabIndex="1" Height="30px" Width="100px"
                            Text="Submit" OnClick="BtnSave1_Click" />
                    </td>
                </tr>
                <tr>
                    <td style="padding: 5px; margin: 5px; text-align: left; color: black;" colspan="2">
                        <asp:GridView ID="grdDetails" runat="server" AutoGenerateColumns="False" CellPadding="4"
                            Width="100%" ShowFooter="false">
                            <HeaderStyle ForeColor="#FFFFFF" BackColor="#009688" Height="40px" CssClass="GridviewScrollC1HeaderWrap" />
                            <RowStyle Height="40px" CssClass="GridviewScrollC1Item" />
                            <PagerStyle CssClass="GridviewScrollC1Pager" />
                            <FooterStyle ForeColor="#FFFFFF" BackColor="#009688" Height="40px" CssClass="GridviewScrollC1Footer" />
                            <AlternatingRowStyle Height="40px" CssClass="GridviewScrollC1Item2" />
                            <Columns>
                                <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S.No">
                                    <ItemTemplate>
                                        <%# Container.DataItemIndex +1 %>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:BoundField DataField="NameandAddress" HeaderText="Name of the company and contact details">
                                    <ItemStyle Width="800px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="IndustryCategory" HeaderText="Industry Category">
                                    <ItemStyle Width="200px" />
                                </asp:BoundField>
                                <asp:HyperLinkField ItemStyle-HorizontalAlign="Left" HeaderText="Attachments" DataTextField="Attachments"
                                    DataNavigateUrlFields="Filepath" DataNavigateUrlFormatString="{0}" Target="_blank">
                                    <ItemStyle Font-Underline="false" HorizontalAlign="Left" />
                                </asp:HyperLinkField>
                            </Columns>
                        </asp:GridView>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
