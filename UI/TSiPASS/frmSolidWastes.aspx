<%@ Page Title="" Language="C#" AutoEventWireup="true" CodeFile="frmSolidWastes.aspx.cs" Inherits="UI_TSiPASS_frmSolidWastes" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">

    <script src="../../Resource/Scripts/js/validations.js" type="text/javascript"></script>
    <script src="../../Resource/Styles/SideMenu/script.js" type="text/javascript"></script>

    <link href="../../Resource/Styles/SideMenu/styles.css" rel="stylesheet" type="text/css" />


    <link href="../../Masterfiles/css/StyleSheetMaster.css" rel="stylesheet" />
    <script src="../../Resource/Scripts/js/jquery.js" type="text/javascript"></script>

    <script src="../../Resource/Scripts/js/bootstrap.min.js" type="text/javascript"></script>

    <script type="text/javascript" src="../../Resource/Scripts/js/plugins/morris/raphael.min.js"></script>

    <script src="../../Resource/Scripts/js/plugins/morris/morris.min.js" type="text/javascript"></script>

    <script src="../../Resource/Scripts/js/plugins/morris/morris-data.js" type="text/javascript"></script>

    <%--<script src="../../Resource/js/bootstrap.min.js"></script>   
    <script src="../../Resource/js/plugins/morris/raphael.min.js"></script>
    <script src="../../Resource/js/plugins/morris/morris.min.js"></script>
    <script src="../../Resource/js/plugins/morris/morris-data.js"></script>--%>
    <link href="../../Resource/Styles/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="../../Resource/Styles/css/sb-admin.css" rel="stylesheet" type="text/css" />
    <link href="../../Resource/Styles/css/plugins/morris.css" rel="stylesheet" type="text/css" />
    <link href="../../Resource/Styles/font-awesome/css/font-awesome.css" rel="stylesheet"
        type="text/css" />
    <%--<link href="../../Resource/css/bootstrap.min.css"rel="stylesheet" type="text/css" />   
    <link href="../../Resource/css/sb-admin.css" rel="stylesheet" type="text/css" />   
    <link href="../../Resource/css/plugins/morris.css" rel="stylesheet" type="text/css" />--%>
    <%--<link href="../../Resource/font-awesome/css/font-awesome.css" rel="stylesheet" type="text/css" />--%>
    <%--<link href="assets/css/basic.css" rel="stylesheet" />--%>
    <link href="../../Resource/Styles/GridViewStyles.css" rel="stylesheet" />
    <script src="../../Resource/Scripts/js/validations.js" type="text/javascript"></script>

    <style type="text/css">
        .overlay
        {
            position: fixed;
            z-index: 999;
            height: 100%;
            width: 100%;
            top: 112px;
            background-color: Gray;
            filter: alpha(opacity=60);
            opacity: 0.9;
            -moz-opacity: 0.9;
        }

        .update
        {
            position: fixed;
            top: 0px;
            left: 0px;
            min-height: 100%;
            min-width: 100%;
            background-image: url("../../Images/ajax-loaderblack.gif");
            /*background-image: url("Images/spinner_60.gif");*/
            background-position: center center;
            background-repeat: no-repeat;
            /*background-color: #e4e4e6;*/
            background-color: #535252;
            z-index: 500 !important;
            opacity: 0.6;
            overflow: hidden;
        }

        .style6
        {
            width: 192px;
        }

        .style7
        {
            color: #FF3300;
        }

        .style8
        {
        }
    </style>

    <script type="text/javascript" language="javascript">

        function OpenPopup() {

            window.open("Lookups/LookupBDC.aspx", "List", "scrollbars=yes,resizable=yes,width=1000,height=650;display = block;position=absolute");

            return false;
        }
    </script>
    <script type="text/javascript">
        function showProgress() {
            var updateProgress = $get("<%= UpdateProgress.ClientID %>");
            updateProgress.style.display = "block";
        }
    </script>

    <script type="text/javascript">
        function inputOnlyNumbers(evt) {
            var e = window.event || evt; // for trans-browser compatibility  
            var charCode = e.which || e.keyCode;
            if ((charCode > 45 && charCode < 58) || charCode == 8) {
                return true;
            }
            return false;
        }

    </script>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager runat="server" ID="scmRTOPermit">
        </asp:ScriptManager>
        <asp:UpdatePanel ID="upd1" runat="server">
            <ContentTemplate>
               
                <div align="left">
                    <div class="row" align="left">
                        <div class="col-lg-11">
                            <div class="panel panel-primary">
                                <div class="panel-heading" align="center">
                                    <h3 class="panel-title">Activity/Hazardous Waste Generation Details</h3>
                                </div>
                                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                    <ContentTemplate>
                                        <div class="panel-body">
                                            <table align="center" cellpadding="10" cellspacing="5" style="width: 90%">

                                                <tr>
                                                    <td style="padding: 5px; margin: 5px" valign="top" colspan="3">
                                                        <asp:Label ID="Label422" runat="server" CssClass="LBLBLACK" Font-Bold="True"
                                                            Width="510px">Details for Pollution Control Board<font 
                                                            color="red">*</font></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="padding: 5px; margin: 5px; text-align: left; font-weight: bold" colspan="4">Activity/Hazardous Waste Generation Details</td>

                                                </tr>
                                                <tr>
                                                    <td colspan="4" style="padding: 5px; margin: 5px; text-align: left; font-weight: bold">
                                                        <%--<asp:Label ID="Label1" runat="server"></asp:Label>--%>
                                                        <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Names="Verdana" Font-Size="11px"
                                                            ForeColor="Green" Style="position: static"></asp:Label>
                                                    </td>

                                                </tr>
                                                <tr>
                                                    <td style="padding: 5px; margin: 5px; text-align: left; font-weight: bold">Activity For*</td>
                                                    <td style="padding: 5px; margin: 5px; text-align: left">
                                                        <asp:CheckBoxList ID="chkActivity" runat="server" Height="60px" Width="180px" RepeatDirection="Horizontal">
                                                            <asp:ListItem Value="1">Collection</asp:ListItem>
                                                            <asp:ListItem Value="2">Reception</asp:ListItem>
                                                            <asp:ListItem Value="3">Treatment</asp:ListItem>
                                                            <asp:ListItem Value="4">Transport</asp:ListItem>
                                                            <asp:ListItem Value="5">Storage</asp:ListItem>
                                                            <asp:ListItem Value="6">Disposal</asp:ListItem>
                                                        </asp:CheckBoxList>
                                                </tr>
                                                <%--<tr align="center">
                                                <td colspan="4" style="padding: 5px; margin: 5px; text-align: left; font-weight: bold" align="center">
                                                    <asp:RadioButtonList ID="rbtnLstSch" runat="server" RepeatDirection="Horizontal" Height="17px" Width="210px" OnSelectedIndexChanged="rbtnLstSch_SelectedIndexChanged" AutoPostBack="true">
                                                        <asp:ListItem Value="Sch1" Selected="True">Schedule I</asp:ListItem>
                                                        <asp:ListItem Value="Sch2">Schedule II</asp:ListItem>
                                                    </asp:RadioButtonList>
                                            </tr>--%>
                                                <tr>
                                                    <td style="padding: 5px; margin: 5px; text-align: left; font-weight: bold" colspan="4">
                                                        <asp:GridView ID="gvHazardous" runat="server" AutoGenerateColumns="False" border="3" CellPadding="1" CellSpacing="1" OnRowCommand="gvHazardous_RowCommand" OnRowDataBound="gvHazardous_RowDataBound">
                                                            <FooterStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                                            <RowStyle BackColor="#EBF2FE" CssClass="GRDITEM" HorizontalAlign="Left" VerticalAlign="Middle" />
                                                            <Columns>
                                                                <asp:TemplateField HeaderText="Sl No.">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblSl" runat="server" Text="<%#Container.DataItemIndex+1 %>"></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Schedule">
                                                                    <ItemTemplate>
                                                                        <asp:DropDownList ID="ddlSchedule" runat="server" class="form-control txtbox" Height="33px" Width="180px" OnSelectedIndexChanged="ddlSchedule_SelectedIndexChanged" AutoPostBack="true">
                                                                            <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                                            <asp:ListItem Value="1">Schedule 1</asp:ListItem>
                                                                            <asp:ListItem Value="2">Schedule 2</asp:ListItem>
                                                                        </asp:DropDownList>
                                                                    </ItemTemplate>
                                                                    <ItemStyle CssClass="scroll_td" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Process*">
                                                                    <ItemTemplate>
                                                                        <asp:DropDownList ID="ddlProcess" runat="server" class="form-control txtbox" Height="33px" Width="180px" OnSelectedIndexChanged="ddlProcess_SelectedIndexChanged" AutoPostBack="true">
                                                                            <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                                        </asp:DropDownList>
                                                                    </ItemTemplate>
                                                                    <ItemStyle CssClass="scroll_td" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Name of Hazardous Waste">
                                                                    <ItemTemplate>
                                                                        <asp:DropDownList ID="ddlHazardousWaste" runat="server" class="form-control txtbox" Height="33px" Width="180px">
                                                                            <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                                        </asp:DropDownList>
                                                                    </ItemTemplate>
                                                                    <ItemStyle CssClass="scroll_td" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Hazardous Waste Description">
                                                                    <ItemTemplate>
                                                                        <asp:TextBox ID="txtHazardousDesc" runat="server" class="form-control txtbox"></asp:TextBox>
                                                                    </ItemTemplate>
                                                                    <ItemStyle CssClass="scroll_td" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Quantity of Hazardous Waste generated / to be generated per Month (In Units)*">
                                                                    <ItemTemplate>
                                                                        <asp:TextBox ID="txtQuantity" runat="server" class="form-control txtbox" onkeypress="return inputOnlyNumbers(event)"></asp:TextBox>
                                                                    </ItemTemplate>
                                                                    <ItemStyle CssClass="scroll_td" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Unit">
                                                                    <ItemTemplate>
                                                                        <asp:DropDownList ID="ddlUnit" runat="server" class="form-control txtbox" Height="33px" Width="180px">
                                                                            <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                                        </asp:DropDownList>
                                                                    </ItemTemplate>
                                                                    <ItemStyle CssClass="scroll_td" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Storage & treatment/pre treatment">
                                                                    <ItemTemplate>
                                                                        <asp:TextBox ID="txtStorage" runat="server" class="form-control txtbox"></asp:TextBox>
                                                                    </ItemTemplate>
                                                                    <ItemStyle CssClass="scroll_td" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Recycle/recycling">
                                                                    <ItemTemplate>
                                                                        <asp:TextBox ID="txtRecyle" runat="server" class="form-control txtbox"></asp:TextBox>
                                                                    </ItemTemplate>
                                                                    <ItemStyle CssClass="scroll_td" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Disposal">
                                                                    <ItemTemplate>
                                                                        <asp:TextBox ID="txtDisposal" runat="server" class="form-control txtbox"></asp:TextBox>
                                                                    </ItemTemplate>
                                                                    <ItemStyle CssClass="scroll_td" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Existing">
                                                                    <ItemTemplate>
                                                                        <asp:TextBox ID="txtExisting" runat="server" class="form-control txtbox"></asp:TextBox>
                                                                    </ItemTemplate>
                                                                    <ItemStyle CssClass="scroll_td" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Proposed">
                                                                    <ItemTemplate>
                                                                        <asp:TextBox ID="txtProposed" runat="server" class="form-control txtbox"></asp:TextBox>
                                                                    </ItemTemplate>
                                                                    <ItemStyle CssClass="scroll_td" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Total After">
                                                                    <ItemTemplate>
                                                                        <asp:TextBox ID="txtTotalAfter" runat="server" class="form-control txtbox"></asp:TextBox>
                                                                    </ItemTemplate>
                                                                    <ItemStyle CssClass="scroll_td" />
                                                                </asp:TemplateField>
                                                                <asp:ButtonField CommandName="Add" Text="Add">
                                                                    <ItemStyle CssClass="scroll_td" />
                                                                </asp:ButtonField>
                                                                <asp:ButtonField CommandName="Remove" Text="Delete">
                                                                    <ItemStyle CssClass="scroll_td" />
                                                                </asp:ButtonField>
                                                            </Columns>
                                                            <PagerStyle BackColor="#013161" ForeColor="White" HorizontalAlign="Center" />
                                                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                                            <HeaderStyle BackColor="#013161" CssClass="GRDHEADER" Font-Bold="True" ForeColor="White" />
                                                            <EditRowStyle BackColor="#B9D684" />
                                                            <AlternatingRowStyle BackColor="White" />
                                                        </asp:GridView>
                                                    </td>

                                                </tr>

                                                <tr>
                                                    <td colspan="4" style="padding: 5px; margin: 5px; text-align: left; font-weight: bold">
                                                        <asp:Button ID="btnSaveHazardousDtls" runat="server" CssClass="btn btn-primary" Height="32px" Text="Save Hazardous Details" ValidationGroup="group" Width="200px" OnClick="btnSaveHazardousDtls_Click" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="4" style="padding: 5px; margin: 5px; text-align: left; font-weight: bold">
                                                        <%--<asp:Label ID="Label1" runat="server"></asp:Label>--%>
                                                        <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Names="Verdana" Font-Size="11px"
                                                            ForeColor="Green" Style="position: static"></asp:Label>
                                                    </td>

                                                </tr>
                                                <tr>
                                                    <td colspan="4" style="padding: 5px; margin: 5px; text-align: left; font-weight: bold">Non-Hazardous Details</td>
                                                </tr>
                                                <tr>
                                                    <td style="padding: 5px; margin: 5px; text-align: left; font-weight: bold" colspan="4">
                                                        <asp:GridView ID="gvNonHazardous" runat="server" AutoGenerateColumns="False" border="3" CellPadding="1" CellSpacing="1" OnRowCommand="gvNonHazardous_RowCommand" OnRowDataBound="gvNonHazardous_RowDataBound">
                                                            <FooterStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                                            <RowStyle BackColor="#EBF2FE" CssClass="GRDITEM" HorizontalAlign="Left" VerticalAlign="Middle" />
                                                            <Columns>
                                                                <asp:TemplateField HeaderText="Sl No.">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="Label1" runat="server" Text="<%#Container.DataItemIndex+1 %>"></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Description :">
                                                                    <ItemTemplate>
                                                                        <asp:TextBox ID="txtNHDescription" runat="server" class="form-control txtbox"></asp:TextBox>
                                                                    </ItemTemplate>
                                                                    <ItemStyle CssClass="scroll_td" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Quantity :">
                                                                    <ItemTemplate>
                                                                        <asp:TextBox ID="txtNHQuantity" runat="server" class="form-control txtbox" onkeypress="return inputOnlyNumbers(event)"></asp:TextBox>
                                                                    </ItemTemplate>
                                                                    <ItemStyle CssClass="scroll_td" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Unit:">
                                                                    <ItemTemplate>
                                                                        <asp:DropDownList ID="ddlNHUnit" runat="server" class="form-control txtbox" Height="33px" Width="180px">
                                                                            <asp:ListItem>--Select--</asp:ListItem>
                                                                        </asp:DropDownList>
                                                                    </ItemTemplate>
                                                                    <ItemStyle CssClass="scroll_td" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Disposal">
                                                                    <ItemTemplate>
                                                                        <asp:TextBox ID="txtNHDisposal" runat="server" class="form-control txtbox"></asp:TextBox>
                                                                    </ItemTemplate>
                                                                    <ItemStyle CssClass="scroll_td" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Existing">
                                                                    <ItemTemplate>
                                                                        <asp:TextBox ID="txtNHExisting" runat="server" class="form-control txtbox"></asp:TextBox>
                                                                    </ItemTemplate>
                                                                    <ItemStyle CssClass="scroll_td" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Proposed">
                                                                    <ItemTemplate>
                                                                        <asp:TextBox ID="txtNHProposed" runat="server" class="form-control txtbox"></asp:TextBox>
                                                                    </ItemTemplate>
                                                                    <ItemStyle CssClass="scroll_td" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Total After">
                                                                    <ItemTemplate>
                                                                        <asp:TextBox ID="txtNHTotalAfter" runat="server" class="form-control txtbox"></asp:TextBox>
                                                                    </ItemTemplate>
                                                                    <ItemStyle CssClass="scroll_td" />
                                                                </asp:TemplateField>
                                                                <asp:ButtonField CommandName="Add" Text="Add">
                                                                    <ItemStyle CssClass="scroll_td" />
                                                                </asp:ButtonField>
                                                                <asp:ButtonField CommandName="Remove" Text="Delete">
                                                                    <ItemStyle CssClass="scroll_td" />
                                                                </asp:ButtonField>
                                                            </Columns>
                                                            <PagerStyle BackColor="#013161" ForeColor="White" HorizontalAlign="Center" />
                                                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                                            <HeaderStyle BackColor="#013161" CssClass="GRDHEADER" Font-Bold="True" ForeColor="White" />
                                                            <EditRowStyle BackColor="#B9D684" />
                                                            <AlternatingRowStyle BackColor="White" />
                                                        </asp:GridView>
                                                    </td>

                                                </tr>
                                                <tr>
                                                    <td colspan="4" style="padding: 5px; margin: 5px; text-align: left; font-weight: bold">
                                                        <asp:Button ID="btnSaveNonHazardousDtls" runat="server" CssClass="btn btn-primary" Height="32px" Text="Save Non Hazardous Details" ValidationGroup="group" Width="233px" OnClick="btnSaveNonHazardousDtls_Click" />
                                                    </td>
                                                </tr>
                                                <%--  <tr>
                                                <td align="center" colspan="3"
                                                    style="padding: 5px; margin: 5px; text-align: center;">
                                                    <asp:Button ID="BtnSave1" runat="server" CssClass="btn btn-primary"
                                                        Height="32px" OnClick="BtnSave_Click" TabIndex="10" Text="Save"
                                                        Width="90px" ValidationGroup="group" />
                                                    &nbsp;
                                            <asp:Button ID="BtnDelete0" runat="server"
                                                CssClass="btn btn-danger" Height="32px" OnClick="BtnDelete0_Click" TabIndex="10"
                                                Text="Previous" Width="90px" CausesValidation="False" />

                                                    &nbsp;&nbsp;<asp:Button ID="BtnDelete" runat="server"
                                                        CssClass="btn btn-danger" Height="32px" OnClick="BtnClear0_Click" TabIndex="10"
                                                        Text="Next" Width="90px"
                                                        ValidationGroup="group" />

                                                    &nbsp;<asp:Button ID="BtnClear" runat="server" CausesValidation="False"
                                                        CssClass="btn btn-warning" Height="32px" OnClick="BtnClear_Click" TabIndex="10"
                                                        Text="ClearAll" ToolTip="To Clear  the Screen" Width="90px" />
                                                </td>
                                            </tr>--%>
                                                <tr>
                                                    <td align="center" colspan="3" style="padding: 5px; margin: 5px">


                                                        <div id="success" runat="server" visible="false" class="alert alert-success">
                                                            <a href="AddQualification.aspx" class="close" data-dismiss="alert" aria-label="close">&times;</a>
                                                            <strong>Success!</strong><asp:Label ID="lblmsg0" runat="server"></asp:Label>
                                                        </div>


                                                        <div id="Failure" runat="server" visible="false" class="alert alert-danger">
                                                            <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a>
                                                            <strong>Warning!</strong>
                                                            <asp:Label ID="lblmsg" runat="server"></asp:Label>
                                                        </div>
                                                    </td>
                                                </tr>
                                            </table>
                                            <asp:HiddenField ID="hdfID" runat="server" />
                                            <asp:ValidationSummary ID="ValidationSummary1" runat="server"
                                                ShowMessageBox="True" ShowSummary="False" ValidationGroup="group" />
                                            <asp:ValidationSummary ID="ValidationSummary2" runat="server"
                                                ShowMessageBox="True" ShowSummary="False" ValidationGroup="child" />
                                            <asp:HiddenField ID="hdfFlagID" runat="server" />
                                            <asp:HiddenField ID="hdfFlagID0" runat="server" />
                                            <asp:HiddenField ID="hdfpencode" runat="server" />
                                        </div>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                    </div>

                </div>
                <asp:UpdateProgress ID="UpdateProgress" runat="server" AssociatedUpdatePanelID="upd1">
                    <ProgressTemplate>
                        <div class="update">
                        </div>
                    </ProgressTemplate>
                </asp:UpdateProgress>

                <br />
                <br />
                <br />
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
    </form>
</body>
</html>

