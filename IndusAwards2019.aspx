<%@ Page Language="C#" AutoEventWireup="true" CodeFile="IndusAwards2019.aspx.cs" Inherits="IndusAwards2019" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Best Company Awards 2019</title>

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
            /*text-align: left !important;
            color: black !important;*/
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
                                    <h6>The Industries Department, Government of Telangana is pleased to invite applications for the 2nd edition of the Best Company Awards. This year, the awards will be given in 4 major categories:  </h6>

                                    <div class="column">
                                        <ul class="dt-sc-fancy-list chocolate check-circle">
                                            <li><span style="color: black">Top Financial Performer.</span></li>
                                            <li><span style="color: black">Most Innovative Company</span></li>
                                            <li><span style="color: black">Best CSR Practices</span></li>
                                            <li><span style="color: black">Best Employee Practices</span></li>
                                        </ul>
                                        <div class="column">
                                            <h6>Companies can apply for any or all of the awards under the following categories </h6>
                                        </div>
                                    </div>
                                    <div class="dt-sc-hr-invisible-very-small"></div>
                                </div>
                            </div>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td style="padding: 5px; margin: 5px; text-align: left; font-size: 16pt; color: black;">1.
                    </td>
                    <td style="padding: 5px; margin: 5px; text-align: left; font-size: 16pt; color: black;">Name of the company and contact details &nbsp;&nbsp;<font color="red">*</font>
                    </td>
                </tr>
                <tr>
                    <td style="padding: 5px; margin: 5px; text-align: left;"></td>
                    <td style="padding: 5px; margin: 5px; text-align: left;">
                        <asp:TextBox ID="txtPromotor" runat="server" class="form-control txtbox" onkeypress="Names()" ForeColor="Black"
                            Height="28px"  TabIndex="1" ValidationGroup="group" Width="650px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="padding: 5px; margin: 5px; text-align: left; font-size: 16pt; color: black;">2.
                    </td>
                    <td style="padding: 5px; margin: 5px; text-align: left; font-size: 16pt; color: black;">Which of the following are you?  (choose only one)&nbsp;&nbsp;<font color="red">*</font>
                    </td>
                </tr>
                <tr>
                    <td style="padding: 5px; margin: 5px; text-align: left;"></td>
                    <td style="padding: 5px; margin: 5px; text-align: left;">
                        <asp:CheckBox ID="chkMicro" CssClass="onecheck" Text="Micro Enterprises" ForeColor="Black" runat="server" Font-Size="14pt" />
                        <br />
                        <br />
                        <asp:CheckBox ID="chkSmall" CssClass="onecheck" Text="Small Enterprises" ForeColor="Black" runat="server" Font-Size="14pt" />
                        <br />
                        <br />
                        <asp:CheckBox ID="chkMedium" CssClass="onecheck" Text="Medium Enterprises" ForeColor="Black" runat="server" Font-Size="14pt" />
                        <br />
                        <br />
                        <asp:CheckBox ID="chkLarge" CssClass="onecheck" Text="Large Enterprises" ForeColor="Black" runat="server" Font-Size="14pt" />
                        <br />
                    </td>
                </tr>

                <tr>
                    <td style="padding: 5px; margin: 5px; text-align: left; font-size: 16pt; color: black;" valign="top">3.
                    </td>
                    <td style="padding: 5px; margin: 5px; text-align: left; font-size: 16pt; color: black;">Top Financial Performer - Please upload financial statements (balance sheets) of the last 3 years. (File can be in word, excel, pdf or ppt format)
                    </td>
                </tr>
                <tr>
                    <td style="padding: 5px; margin: 5px; text-align: left;"></td>
                    <td style="padding: 5px; margin: 5px; text-align: left;">
                        <asp:FileUpload ID="FileUpload10" runat="server" CssClass="CS" Width="350px"
                            Height="28px" />
                        &nbsp; &nbsp;&nbsp;   
                        <asp:Button ID="Button8" runat="server"
                            Height="28px" TabIndex="10" Text="Upload"
                            Width="120px" OnClick="Button8_Click" />
                        <br />
                        <br />

                        <asp:GridView ID="gvCertificate" runat="server" AutoGenerateColumns="False" align="left"
                            CssClass="GRD"
                            Width="50%" EnableModelValidation="True">
                            <Columns>
                                <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S No">
                                    <ItemTemplate>
                                        <%# Container.DataItemIndex + 1%>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle Width="50px" />
                                </asp:TemplateField>
                                <asp:BoundField DataField="FileName" HeaderText="FileName" />
                                <asp:TemplateField Visible="false">
                                    <ItemTemplate>
                                        <asp:Label ID="lblfilepath" runat="server" Text='<%# Bind("filepath") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </td>
                </tr>

                <tr>
                    <td style="padding: 5px; margin: 5px; text-align: left; font-size: 16pt; color: black;" valign="top">4.
                    </td>
                    <td style="padding: 5px; margin: 5px; text-align: left; font-size: 16pt; color: black;">Most Innovative Company - Please upload a small write-up about the technology and machinery utilized in your organization along with recent picture. (File can be in word, pdf or ppt format)
                    </td>
                </tr>
                <tr>
                    <td style="padding: 5px; margin: 5px; text-align: left;"></td>
                    <td style="padding: 5px; margin: 5px; text-align: left;">
                        <asp:FileUpload ID="FileUpload1" runat="server" CssClass="CS" Width="350px"
                            Height="28px" />
                        &nbsp; &nbsp;&nbsp;   
                        <asp:Button ID="Button1" runat="server"
                            Height="28px" TabIndex="10" Text="Upload"
                            Width="120px" OnClick="Button1_Click" />
                        <br />
                        <br />

                        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" align="left"
                            CssClass="GRD"
                            Width="50%" EnableModelValidation="True">
                            <Columns>
                                <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S No">
                                    <ItemTemplate>
                                        <%# Container.DataItemIndex + 1%>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle Width="50px" />
                                </asp:TemplateField>
                                <asp:BoundField DataField="FileName" HeaderText="FileName" />
                                <asp:TemplateField Visible="false">
                                    <ItemTemplate>
                                        <asp:Label ID="lblfilepath" runat="server" Text='<%# Bind("filepath") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </td>
                </tr>

                <tr>
                    <td style="padding: 5px; margin: 5px; text-align: left; font-size: 16pt; color: black;" valign="top">5.
                    </td>
                    <td style="padding: 5px; margin: 5px; text-align: left; font-size: 16pt; color: black;">Best CSR Practices - Please upload a summary of any CSR activities undertaken or events conducted by your organization for public benefit along with pictures.(File can be in word, pdf or ppt format)
                    </td>
                </tr>
                <tr>
                    <td style="padding: 5px; margin: 5px; text-align: left;"></td>
                    <td style="padding: 5px; margin: 5px; text-align: left;">
                        <asp:FileUpload ID="FileUpload2" runat="server" CssClass="CS" Width="350px"
                            Height="28px" />
                        &nbsp; &nbsp;&nbsp;   
                        <asp:Button ID="Button3" runat="server"
                            Height="28px" TabIndex="10" Text="Upload"
                            Width="120px" OnClick="Button3_Click" />
                        <br />
                        <br />

                        <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" align="left"
                            CssClass="GRD"
                            Width="50%" EnableModelValidation="True">
                            <Columns>
                                <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S No">
                                    <ItemTemplate>
                                        <%# Container.DataItemIndex + 1%>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle Width="50px" />
                                </asp:TemplateField>
                                <asp:BoundField DataField="FileName" HeaderText="FileName" />
                                <asp:TemplateField Visible="false">
                                    <ItemTemplate>
                                        <asp:Label ID="lblfilepath" runat="server" Text='<%# Bind("filepath") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </td>
                </tr>

                <tr>
                    <td style="padding: 5px; margin: 5px; text-align: left; font-size: 16pt; color: black;" valign="top">6.
                    </td>
                    <td style="padding: 5px; margin: 5px; text-align: left; font-size: 16pt; color: black;">Best Employee Practices - Please upload an information sheet consisting of total number of employees, number of female employees and number of differently abled employees. (File can be in word, pdf or ppt format)
                    </td>
                </tr>
                <tr>
                    <td style="padding: 5px; margin: 5px; text-align: left;"></td>
                    <td style="padding: 5px; margin: 5px; text-align: left;">
                        <asp:FileUpload ID="FileUpload3" runat="server" CssClass="CS" Width="350px"
                            Height="28px" />
                        &nbsp; &nbsp;&nbsp;   
                        <asp:Button ID="Button2" runat="server"
                            Height="28px" TabIndex="10" Text="Upload"
                            Width="120px" OnClick="Button2_Click" />

                        <br />
                        <br />

                        <asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="False" align="left"
                            Width="50%" EnableModelValidation="True">
                            <Columns>
                                <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S No">
                                    <ItemTemplate>
                                        <%# Container.DataItemIndex + 1%>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle Width="100px" />
                                </asp:TemplateField>
                                <asp:BoundField DataField="FileName" HeaderText="FileName" />
                                <asp:TemplateField Visible="false">
                                    <ItemTemplate>
                                        <asp:Label ID="lblfilepath" runat="server" Text='<%# Bind("filepath") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </td>
                </tr>
                <tr>
                    <td style="height: 15px" align="center" colspan="2">
                        <asp:Button ID="BtnSave1" align="center" CssClass="btn btn-primary" runat="server" Height="32px" TabIndex="10" Text="SUBMIT" Width="120px" OnClick="BtnSave1_Click" />
                    </td>
                </tr>
                <tr>

                    <td align="center" style="padding: 5px; margin: 5px" colspan="5">
                        <div id="success" runat="server" visible="false" class="alert alert-success">
                            <strong style="font-size: 12pt">Success!</strong><asp:Label ID="lblmsg" Font-Bold="true" ForeColor="Green" Font-Size="12pt" runat="server"></asp:Label>
                        </div>
                        <div id="Failure" runat="server" visible="false" class="alert alert-danger">
                            <strong style="font-size: 12pt">Warning!</strong>
                            <asp:Label ID="lblmsg0" Font-Bold="true" ForeColor="Red" Font-Size="12pt" runat="server"></asp:Label>
                        </div>
                    </td>

                </tr>
            </table>
        </div>
    </form>
</body>
</html>
