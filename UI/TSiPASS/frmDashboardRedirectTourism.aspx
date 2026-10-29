<%@ Page Title="" Language="C#" MasterPageFile="~/UI/TSiPASS/CCMaster.master" AutoEventWireup="true" CodeFile="frmDashboardRedirectTourism.aspx.cs" Inherits="UI_TSiPASS_frmDashboardRedirectTourism" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script src="../../Resource/Scripts/js/validations.js" type="text/javascript"></script>

    <style type="text/css">
        .overlay {
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

        .style8 {
            color: #FF0000;
            font-weight: bold;
        }

        .GRD {
            height: auto;
            border-color: #013161;
            border-style: solid;
            border-width: 1px;
            text-transform: capitalize;
            padding: 10px;
        }

        .GRDITEM {
            /*background-color: WHITE;*/
            color: black;
            font-size: 12px;
            font-weight: normal;
            font-family: Verdana;
            padding: 10px; /*text-decoration:none;*/ /*border-color:#013161;*/ /*border-style:solid;*/
            text-transform: uppercase; /*border-width:1px;*/ /*height:23px;*/ /*text-indent:5px;*/
            padding: 10px; /*BACKGROUND-IMAGE: url(../images/grid_bg_.gif);*/
        }

        .GRDHEADER {
            color: #0E2A46;
            vertical-align: middle;
            text-align: center;
            height: 25px;
            width: 50px;
            padding: 10px;
            font-size: 12px;
            font-weight: bold;
            text-transform: capitalize;
            font-family: Verdana;
            background-image: url(../images/bg_blue_grd.gif);
            border-color: #ffffff;
            border-style: solid;
            border-width: 1px;
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

    <asp:UpdatePanel ID="upd1" runat="server">
        <ContentTemplate>
            <div align="left">
                <ol class="breadcrumb">
                    You are here &nbsp;!&nbsp; &nbsp; &nbsp;
                    <li><i class="fa fa-dashboard"></i><a href="Home.aspx"></a></li>
                    <li class=""><i class="fa fa-fw fa-edit"></i></li>
                    <li class="active"><i class="fa fa-edit"></i><a href="#">VIEW DETAILS</a> </li>
                </ol>
            </div>
            <div align="left">
                <div class="row" align="left">
                    <div class="col-lg-11">
                        <div class="panel panel-primary">
                            <div class="panel-heading" align="center">
                                <h3 class="panel-title">VIEW DETAILS</h3>
                            </div>
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>
                                    <div class="panel-body">
                                        <table align="center" cellpadding="10" cellspacing="5" style="width: 90%">
                                            <tr>
                                                <td style="padding: 5px; margin: 5px; text-align: center;" valign="top" class="style8"
                                                    align="center">
                                                    <asp:DropDownList ID="ddlProp_intDistrictid" runat="server" AutoPostBack="True" class="form-control txtbox"
                                                        Height="33px" OnSelectedIndexChanged="ddlProp_intDistrictid_SelectedIndexChanged"
                                                        Width="180px" Visible="False">
                                                        <asp:ListItem>--District--</asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center" class="style8" style="padding: 5px; margin: 5px; text-align: center;"
                                                    valign="top">
                                                    <asp:Label ID="Label1" runat="server" CssClass="LBLBLACK" Width="150px">Approval 
                                            By Status</asp:Label>
                                                </td>
                                            </tr>
                                            <tr id="checkQuery"> 
                                                <td align="center" style="padding: 5px; margin: 5px; text-align: center;" valign="top">

                                                    <asp:GridView ID="grdDetails" runat="server" AutoGenerateColumns="False" CellPadding="5"
                                                        CssClass="GRD" ForeColor="#333333" Height="62px" PageSize="15" ShowFooter="True"
                                                        Width="100%" OnRowDataBound="grdDetails_RowDataBound" BorderColor="Black">
                                                        <FooterStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                                        <RowStyle BackColor="#EBF2FE" CssClass="GRDITEM" HorizontalAlign="Left" VerticalAlign="Middle" />
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
                                                            <asp:BoundField DataField="Const_of_unitA" HeaderText="Constitution of the unit"
                                                                Visible="false" />
                                                            <asp:BoundField DataField="Sector_EntA" HeaderText="Sector of Enterprise" Visible="false" />
                                                            <asp:BoundField DataField="Tot_Extent" HeaderText="Total Extent of Land" Visible="false" />
                                                            <asp:BoundField DataField="Ent_is" HeaderText="Enterprise Type" Visible="false" />
                                                            <asp:BoundField DataField="Val_Land" HeaderText="Land Value" Visible="false" />
                                                            <asp:BoundField DataField="Val_Build" HeaderText="Building Value" Visible="false" />
                                                            <asp:BoundField DataField="Val_Plant" HeaderText="Plant Value" Visible="false" />
                                                            <asp:BoundField DataField="Tot_PrjCost" HeaderText="Total" Visible="false" />
                                                            <asp:BoundField DataField="Dept_Full_name" HeaderText="Department Full Name" />
                                                            <asp:BoundField DataField="ApprovalName" HeaderText="Approval Name" />
                                                            <asp:BoundField DataField="UID_No" HeaderText="UID" Visible="false" />
                                                            <asp:BoundField DataField="NameofthePromoter" HeaderText="Name of the Promoter" Visible="false" />
                                                            <asp:BoundField DataField="PLoutionCategorys" HeaderText="Polution Category" Visible="false" />
                                                            <asp:BoundField DataField="LastDateofPreScrutiy" HeaderText="Last Date of PreScrutiy"
                                                                Visible="false" />
                                                            <asp:HyperLinkField HeaderText="Attachments" Text="Attachments" />

                                                            <%--<asp:TemplateField HeaderText="Rejected Date" Visible="false">
                                                                <ItemTemplate>
                                                                    <asp:Label runat="server" ID="lblRDate" Text='<%# Eval("rejecteddate") %>'>
                                                                    </asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Reason for Rejection" Visible="false">
                                                                <ItemTemplate>
                                                                    <asp:Label runat="server" ID="lblRReason" Text='<%# Eval("rejected_reason") %>'>
                                                                    </label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>--%>
                                                            <asp:HyperLinkField HeaderText="Details" Text="Details" />
                                                            <asp:HyperLinkField HeaderText="Details" Text="Details" />
                                                            <%-- <asp:BoundField DataField="intDepartmentApprovalid" HeaderText="Department Approval ID" />--%>
                                                            <asp:BoundField DataField="APPStatus" HeaderText="Status" />
                                                            <asp:BoundField DataField="CommonDetailsUpdatedFlag" HeaderText="UpdatedFlag" Visible="false" />
                                                            <asp:BoundField DataField="Createdby" HeaderText="Created_by" Visible="false" />
                                                            <%--<asp:HyperLinkField HeaderText="Boiler Status" Text="Please Click here to view Status"/>--%>
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
                                                <td align="center" style="padding: 5px; margin: 5px; text-align: center;" valign="top">

                                                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="5"
                                                        CssClass="GRD" ForeColor="#333333" Height="62px" PageSize="15" ShowFooter="True"
                                                        Width="100%"   BorderColor="Black" OnRowDataBound="GridView1_RowDataBound">
                                                        <FooterStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                                        <RowStyle BackColor="#EBF2FE" CssClass="GRDITEM" HorizontalAlign="Left" VerticalAlign="Middle" />
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
                                                            <asp:BoundField DataField="Const_of_unitA" HeaderText="Constitution of the unit"
                                                                Visible="false" />
                                                            <asp:BoundField DataField="Sector_EntA" HeaderText="Sector of Enterprise" Visible="false" />
                                                            <asp:BoundField DataField="Tot_Extent" HeaderText="Total Extent of Land" Visible="false" />
                                                            <asp:BoundField DataField="Ent_is" HeaderText="Enterprise Type" Visible="false" />
                                                            <asp:BoundField DataField="Val_Land" HeaderText="Land Value" Visible="false" />
                                                            <asp:BoundField DataField="Val_Build" HeaderText="Building Value" Visible="false" />
                                                            <asp:BoundField DataField="Val_Plant" HeaderText="Plant Value" Visible="false" />
                                                            <asp:BoundField DataField="Tot_PrjCost" HeaderText="Total" Visible="false" />
                                                            <asp:BoundField DataField="Dept_Full_name" HeaderText="Department Full Name" />
                                                            <asp:BoundField DataField="ApprovalName" HeaderText="Approval Name" />
                                                            <asp:BoundField DataField="UID_No" HeaderText="UID" Visible="false" />
                                                            <asp:BoundField DataField="NameofthePromoter" HeaderText="Name of the Promoter" Visible="false" />
                                                            <asp:BoundField DataField="PLoutionCategorys" HeaderText="Polution Category" Visible="false" />
                                                            <asp:BoundField DataField="LastDateofPreScrutiy" HeaderText="Last Date of PreScrutiy"
                                                                Visible="false" />
                                                            <asp:HyperLinkField HeaderText="Attachments" Text="Attachments" />

                                                            <%--<asp:TemplateField HeaderText="Rejected Date" Visible="false">
                                                                <ItemTemplate>
                                                                    <asp:Label runat="server" ID="lblRDate" Text='<%# Eval("rejecteddate") %>'>
                                                                    </asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Reason for Rejection" Visible="false">
                                                                <ItemTemplate>
                                                                    <asp:Label runat="server" ID="lblRReason" Text='<%# Eval("rejected_reason") %>'>
                                                                    </label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>--%>
                                                            <asp:HyperLinkField HeaderText="Details" Text="Details" />
                                                            <asp:HyperLinkField HeaderText="Details" Text="Details" />
                                                            <%-- <asp:BoundField DataField="intDepartmentApprovalid" HeaderText="Department Approval ID" />--%>
                                                            <asp:BoundField DataField="APPStatus" HeaderText="Status" />
                                                            <asp:BoundField DataField="CommonDetailsUpdatedFlag" HeaderText="UpdatedFlag" Visible="false" />
                                                            <asp:BoundField DataField="Created_by" HeaderText="Created_by" Visible="false" />
                                                            <asp:HyperLinkField HeaderText="Boiler Status" Text="Please Click here to view Status"/>
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
                                                <td align="left" style="padding: 5px; margin: 5px; text-align: left;" valign="top">&nbsp;
                                                </td>
                                            </tr>
                                            <tr id="trprintack" runat="server" visible="false">
                                                <td align="center" style="padding: 5px; margin: 5px; text-align: center;" valign="top">
                                                    <asp:Button ID="BtnSave1" runat="server" CssClass="btn-primary" Height="32px"
                                                        TabIndex="10" Text="Print Acknowledgment" Width="185px" OnClientClick="document.forms[0].target = '_blank';" OnClick="BtnSave1_Click" />
                                                </td>
                                            </tr>
                                              <tr id="trcoicertificate" runat="server" visible="false">
                                                <td align="center" style="padding: 5px; margin: 5px; text-align: center;" valign="top">
                                                    <asp:HyperLink ID="HyperLinkcoi" runat="server" ForeColor="#FF6600"><h3>Consolidated certificate from Tourism Department</h3></asp:HyperLink>
                                                   <%-- <asp:Button ID="Button1" runat="server" CssClass="btn-primary" Height="32px"
                                                        TabIndex="10" Text="TS-iPASS consolidated certificate" Width="185px" OnClientClick="document.forms[0].target = '_blank';" OnClick="BtnSave2_Click" />--%>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center" style="padding: 5px; margin: 5px">
                                                    <div id="success" runat="server" visible="false" class="alert alert-success">
                                                        <a href="AddQualification.aspx" class="close" data-dismiss="alert" aria-label="close">&times;</a> <strong>Success!</strong><asp:Label ID="lblmsg" runat="server"></asp:Label>
                                                    </div>
                                                    <div id="Failure" runat="server" visible="false" class="alert alert-danger">
                                                        <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a> <strong>Warning!</strong>
                                                        <asp:Label ID="lblmsg0" runat="server"></asp:Label>
                                                    </div>
                                                </td>
                                            </tr>
                                        </table>
                                        <asp:HiddenField ID="hdfID" runat="server" />
                                        <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
                                            ShowSummary="False" ValidationGroup="group" />
                                        <asp:ValidationSummary ID="ValidationSummary2" runat="server" ShowMessageBox="True"
                                            ShowSummary="False" ValidationGroup="child" />
                                        <asp:HiddenField ID="hdfFlagID" runat="server" />
                                    </div>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                    </div>
                </div>
            </div>
            <asp:UpdateProgress ID="UpdateProgress" runat="server" AssociatedUpdatePanelID="updatepanel1">
                <ProgressTemplate>
                    <%--  <div class="overlay">
                     
                        <div style="z-index: 1000; margin-left: -210px; margin-top: 100px; opacity: 1; -moz-opacity: 1;">
                            <img alt="" src="../../Resource/Images/Processing.gif" />
                        </div>
                    </div>--%>
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
    <%--</div>
       </td>
        </tr>
    </table>--%>
</asp:Content>


