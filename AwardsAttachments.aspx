<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AwardsAttachments.aspx.cs" Inherits="AwardsAttachments" %>

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
            text-align: left !important;
            color: black !important;
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
                                        <h1 class="page-head-line" align="left" style="font-size: x-large">Best Company Awards 2018 - Attachments</h1>
                                    </div>
                                    <div class="dt-sc-hr-invisible-very-small"></div>
                                </div>
                            </div>
                        </div>
                    </td>
                </tr>
                <tr id="TRQ3" runat="server" visible="false">
                    <td style="padding: 5px; margin: 5px; text-align: left; font-size: 16pt; color: black;" valign="top">Q3.
                    </td>
                    <td style="padding: 5px; margin: 5px; text-align: left; font-size: 16pt; color: black;">Top Financial Performer - financial statements (balance sheets) of the last 3 years.
                    </td>
                </tr>
                <tr id="TRQ3data" runat="server" visible="false">
                    <td style="padding: 5px; margin: 5px; text-align: left;"></td>
                    <td style="padding: 5px; margin: 5px; text-align: left;">
                        <asp:GridView ID="gvCertificate" runat="server" AutoGenerateColumns="False" align="left"
                            CssClass="GRD"
                            Width="60%" EnableModelValidation="True">
                            <Columns>
                                <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S No">
                                    <ItemTemplate>
                                        <%# Container.DataItemIndex + 1%>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle Width="50px" />
                                </asp:TemplateField>
                                <asp:HyperLinkField ItemStyle-HorizontalAlign="Left" HeaderText="Attachments" DataTextField="Attachments"
                                    DataNavigateUrlFields="Filepath" DataNavigateUrlFormatString="{0}" Target="_blank">
                                    <ItemStyle Font-Underline="false" HorizontalAlign="Left" />
                                </asp:HyperLinkField>
                            </Columns>
                        </asp:GridView>
                    </td>
                </tr>
                <tr id="TRQ4" runat="server" visible="false">
                    <td style="padding: 5px; margin: 5px; text-align: left; font-size: 16pt; color: black;" valign="top">Q4.
                    </td>
                    <td style="padding: 5px; margin: 5px; text-align: left; font-size: 16pt; color: black;">Most Innovative Company - a small write-up about the technology and machinery utilized in your organization along with recent picture.
                    </td>
                </tr>
                <tr id="TRQ4DATA" runat="server" visible="false">
                    <td style="padding: 5px; margin: 5px; text-align: left;"></td>
                    <td style="padding: 5px; margin: 5px; text-align: left;">
                        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" align="left"
                            CssClass="GRD"
                            Width="60%" EnableModelValidation="True">
                            <Columns>
                                <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S No">
                                    <ItemTemplate>
                                        <%# Container.DataItemIndex + 1%>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle Width="50px" />
                                </asp:TemplateField>
                                <asp:HyperLinkField ItemStyle-HorizontalAlign="Left" HeaderText="Attachments" DataTextField="Attachments"
                                    DataNavigateUrlFields="Filepath" DataNavigateUrlFormatString="{0}" Target="_blank">
                                    <ItemStyle Font-Underline="false" HorizontalAlign="Left" />
                                </asp:HyperLinkField>
                            </Columns>
                        </asp:GridView>
                    </td>
                </tr>

                 <tr id="TRQ5" runat="server" visible="false">
                    <td style="padding: 5px; margin: 5px; text-align: left; font-size: 16pt; color: black;" valign="top">Q5.
                    </td>
                    <td style="padding: 5px; margin: 5px; text-align: left; font-size: 16pt; color: black;">Best CSR Practices - a summary of any CSR activities undertaken or events conducted by your organization for public benefit along with pictures.
                    </td>
                </tr>
                 <tr id="TRQ5DATA" runat="server" visible="false">
                    <td style="padding: 5px; margin: 5px; text-align: left;"></td>
                    <td style="padding: 5px; margin: 5px; text-align: left;">
                        
                        <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" align="left"
                            CssClass="GRD"
                            Width="60%" EnableModelValidation="True">
                            <Columns>
                                <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S No">
                                    <ItemTemplate>
                                        <%# Container.DataItemIndex + 1%>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle Width="50px" />
                                </asp:TemplateField>
                                <asp:HyperLinkField ItemStyle-HorizontalAlign="Left" HeaderText="Attachments" DataTextField="Attachments"
                                    DataNavigateUrlFields="Filepath" DataNavigateUrlFormatString="{0}" Target="_blank">
                                    <ItemStyle Font-Underline="false" HorizontalAlign="Left" />
                                </asp:HyperLinkField>
                            </Columns>
                        </asp:GridView>
                    </td>
                </tr>

               <tr id="TRQ6" runat="server" visible="false">
                    <td style="padding: 5px; margin: 5px; text-align: left; font-size: 16pt; color: black;" valign="top">Q6.
                    </td>
                    <td style="padding: 5px; margin: 5px; text-align: left; font-size: 16pt; color: black;">Best Employee Practices - an information sheet consisting of total number of employees, number of female employees and number of differently abled employees.
                    </td>
                </tr>
               <tr id="TRQ6DATA" runat="server" visible="false">
                    <td style="padding: 5px; margin: 5px; text-align: left;"></td>
                    <td style="padding: 5px; margin: 5px; text-align: left;">
                      
                        <asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="False" align="left"
                            Width="60%" EnableModelValidation="True">
                            <Columns>
                                <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S No">
                                    <ItemTemplate>
                                        <%# Container.DataItemIndex + 1%>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle Width="100px" />
                                </asp:TemplateField>
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
