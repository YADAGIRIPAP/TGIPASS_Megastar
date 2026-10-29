<%@ Page Title="" Language="C#" MasterPageFile="~/EmptyMaster2.master" AutoEventWireup="true" CodeFile="ClusterAbstractReportPublic.aspx.cs" Inherits="ClusterAbstractReportPublic" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
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

        .update {
            position: fixed;
            top: 0px;
            left: 0px;
            min-height: 100%;
            min-width: 100%;
            background-image: url("Images/ajax-loaderblack.gif");
            /*background-image: url("Images/spinner_60.gif");*/
            background-position: center center;
            background-repeat: no-repeat;
            /*background-color: #e4e4e6;*/
            background-color: #535252;
            z-index: 500 !important;
            opacity: 0.6;
            overflow: hidden;
        }

        .style6 {
            width: 192px;
        }

        .style7 {
            color: #FF3300;
        }

        .style8 {
        }

        .LBLBLACK {
        }
    </style>

    <script type="text/javascript" language="javascript">

        function OpenPopup() {

            window.open("Lookups/LookupBDC.aspx", "List", "scrollbars=yes,resizable=yes,width=1000,height=650;display = block;position=absolute");

            return false;
        }
    </script>
    <%-- <script type="text/javascript">
        function showProgress() {
            var updateProgress = $get("<%= UpdateProgress.ClientID %>");
            updateProgress.style.display = "block";
        }
    </script>--%>

    <script type="text/javascript">
        function inputOnlyNumbers(evt) {
            var e = window.event || evt; // for trans-browser compatibility  
            var charCode = e.which || e.keyCode;
            if ((charCode > 45 && charCode < 58) || charCode == 8 || charCode == 9) {
                return true;
            }
            return false;
        }

    </script>

    <div align="left">
        <ol class="breadcrumb">
            You are here &nbsp;!&nbsp; &nbsp; &nbsp;
                    <li><i class="fa fa-dashboard"></i><a href="index.html">Dashboard</a> </li>
            <li class=""><i class="fa fa-fw fa-table"></i>Helpdesk </li>
            <li class="active"><i class="fa fa-edit"></i>View Status </li>
        </ol>
    </div>
    <div align="center">
        <div class="row" align="center">
            <div class="col-lg-12">
                <div class="panel panel-primary">
                    <div class="panel-heading">
                        <h3 class="panel-title">CENTRAL INSPECTION SYSTEM</h3>
                    </div>

                    <div class="panel-body">
                        <table style="vertical-align: top; text-align: center;" cellpadding="0" cellspacing="0"
                            width="90%">
                            <tr>
                                <td>
                                    <table style="vertical-align: top; text-align: center;" cellpadding="0" cellspacing="0"
                                        width="100%">
                                        <tr>
                                            <td>
                                                <table style="vertical-align: top; text-align: center;" cellpadding="0" cellspacing="0"
                                                    width="90%">
                                                    <tr style="height: 35px">
                                                        <td style="padding: 5px; margin: 5px; text-align: left;" class="auto-style1"><strong>YEAR : </strong></td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;" class="auto-style1">
                                                            <asp:DropDownList ID="ddlyear" runat="server" class="form-control txtbox" Height="33px" Width="180px">
                                                                <asp:ListItem>--Select--</asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;" class="auto-style1"><strong>MONTH : </strong></td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;" class="auto-style1">
                                                            <asp:DropDownList ID="ddlmonth" runat="server" class="form-control txtbox" Height="33px" Width="180px">
                                                                <asp:ListItem>--Select--</asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>

                                                </table>
                                            </td>
                                        </tr>
                                        <tr style="height: 35px">
                                            <td style="padding: 5px; margin: 5px; text-align: center;" class="auto-style1" colspan="4">
                                                <asp:Button ID="btnGet" runat="server" CssClass="btn btn-primary" Height="32px" TabIndex="10" Text="SUBMIT" Width="90px" OnClick="btnGet_Click" />


                                                &nbsp;&nbsp;&nbsp;
                                                <asp:Button ID="BTNbACK" runat="server" CssClass="btn btn-primary" Height="32px" TabIndex="10" Text="BACK" Width="90px" OnClick="BTNbACK_Click" Visible="False" />

                                            </td>

                                        </tr>
                                        <tr style="height: 35px">
                                            <td style="padding: 5px; margin: 5px; text-align: center;" class="auto-style1" colspan="4">&nbsp;</td>

                                        </tr>
                                        <tr>
                                            <td>
                                                <table style="vertical-align: top; text-align: center;" cellpadding="0" cellspacing="0" width="90%">
                                                    <tr runat="server" id="trabstract" visible="false">
                                                        <td align="center" style="padding: 5px; vertical-align: top; text-align: center">
                                                            <asp:GridView ID="gvinspection" runat="server" AutoGenerateColumns="False" border="3" CellPadding="1" CellSpacing="1" Width="90%" OnRowCommand="gvinspection_RowCommand">
                                                                <HeaderStyle ForeColor="#FFFFFF" BackColor="#009688" Height="40px" CssClass="GridviewScrollC1HeaderWrap" />
                                                                <FooterStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                                                <RowStyle Height="40px" CssClass="GridviewScrollC1Item" HorizontalAlign="Left" />
                                                                <Columns>
                                                                    <asp:TemplateField HeaderText="Sl. No.">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="Label4" runat="server" Text='<%#Container.DataItemIndex + 1 %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                        <ItemStyle HorizontalAlign="center" />
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="DEPARTMENTNAME">
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="LinkButton1" runat="server" CommandArgument='<%# Eval("DEPARTMENTNAME") %>'
                                                                                CommandName="DISTRICT" Text='<%# Eval("DEPARTMENTNAME") %>'></asp:LinkButton>
                                                                            <asp:Label ID="Label5" Text='<%# Eval("DEPARTMENTNAME") %>' Visible="false" runat="server"></asp:Label>
                                                                        </ItemTemplate>
                                                                        <ItemStyle HorizontalAlign="Left" />
                                                                    </asp:TemplateField>
                                                                    <asp:BoundField DataField="SCHEDULED" HeaderText="SCHEDULED INSPECTIONS">
                                                                        <HeaderStyle HorizontalAlign="Center" />
                                                                        <ItemStyle HorizontalAlign="left" />
                                                                    </asp:BoundField>
                                                                    <asp:BoundField DataField="INSPECTED" HeaderText="INSPECTIONS CONDUCTED">
                                                                        <HeaderStyle HorizontalAlign="Center" />
                                                                        <ItemStyle HorizontalAlign="left" />
                                                                    </asp:BoundField>
                                                                    <asp:BoundField DataField="PENDING" HeaderText="PENDING INSPECTIONS">
                                                                        <HeaderStyle HorizontalAlign="Center" />
                                                                        <ItemStyle HorizontalAlign="left" />
                                                                    </asp:BoundField>
                                                                    <asp:BoundField DataField="WITHIN24HR" HeaderText="REPORT UPLOADED WITHIN 24HOURS">
                                                                        <HeaderStyle HorizontalAlign="Center" />
                                                                        <ItemStyle HorizontalAlign="left" />
                                                                    </asp:BoundField>
                                                                    <asp:BoundField DataField="BEYOND24HR" HeaderText="REPORT UPLOADED BEYOND 24HOURS">
                                                                        <HeaderStyle HorizontalAlign="Center" />
                                                                        <ItemStyle HorizontalAlign="left" />
                                                                    </asp:BoundField>
                                                                </Columns>

                                                            </asp:GridView>


                                                        </td>
                                                    </tr>
                                                    <%--   <tr runat="server" id="trMandalData" visible="false">
                                                        <td align="center" style="padding: 5px; vertical-align: top; text-align: center">
                                                            &nbsp;</td>
                                                    </tr>
                                                    <tr runat="server" id="trVillageData" visible="false">
                                                        <td align="center" style="padding: 5px; vertical-align: top; text-align: center">
                                                            &nbsp;</td>
                                                    </tr>--%>
                                                    <tr runat="server" id="trdistrictwise" visible="false">
                                                        <td align="center" style="padding: 5px; vertical-align: top; text-align: center">
                                                            <asp:GridView ID="gvdist" runat="server" AutoGenerateColumns="False" border="3" CellPadding="1" CellSpacing="1" Width="90%" OnRowCommand="gvdist_RowCommand">
                                                                <HeaderStyle ForeColor="#FFFFFF" BackColor="#009688" Height="40px" CssClass="GridviewScrollC1HeaderWrap" />
                                                                <FooterStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                                                <RowStyle Height="40px" CssClass="GridviewScrollC1Item" HorizontalAlign="Left" />
                                                                <Columns>
                                                                    <asp:TemplateField HeaderText="Sl. No.">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="Label4" runat="server" Text='<%#Container.DataItemIndex + 1 %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                        <ItemStyle HorizontalAlign="center" />
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="DISTRICTNAME">
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="LinkButton1" runat="server" CommandArgument='<%# Eval("DISTID") %>'
                                                                                CommandName="DISTRICT" Text='<%# Eval("DISTRICTNAME") %>'></asp:LinkButton>
                                                                            <asp:Label ID="Label5" Text='<%# Eval("DISTRICTNAME") %>' Visible="false" runat="server"></asp:Label>
                                                                        </ItemTemplate>
                                                                        <ItemStyle HorizontalAlign="Left" />
                                                                    </asp:TemplateField>
                                                                    <asp:BoundField DataField="SCHEDULED" HeaderText="SCHEDULED INSPECTIONS">
                                                                        <HeaderStyle HorizontalAlign="Center" />
                                                                        <ItemStyle HorizontalAlign="left" />
                                                                    </asp:BoundField>
                                                                    <asp:BoundField DataField="INSPECTED" HeaderText="INSPECTIONS CONDUCTED">
                                                                        <HeaderStyle HorizontalAlign="Center" />
                                                                        <ItemStyle HorizontalAlign="left" />
                                                                    </asp:BoundField>
                                                                    <asp:BoundField DataField="PENDING" HeaderText="PENDING INSPECTIONS">
                                                                        <HeaderStyle HorizontalAlign="Center" />
                                                                        <ItemStyle HorizontalAlign="left" />
                                                                    </asp:BoundField>
                                                                    <asp:BoundField DataField="WITHIN24HR" HeaderText="REPORT UPLOADED WITHIN 24HOURS">
                                                                        <HeaderStyle HorizontalAlign="Center" />
                                                                        <ItemStyle HorizontalAlign="left" />
                                                                    </asp:BoundField>
                                                                    <asp:BoundField DataField="BEYOND24HR" HeaderText="REPORT UPLOADED BEYOND 24HOURS">
                                                                        <HeaderStyle HorizontalAlign="Center" />
                                                                        <ItemStyle HorizontalAlign="left" />
                                                                    </asp:BoundField>
                                                                </Columns>

                                                            </asp:GridView>


                                                        </td>
                                                    </tr>
                                                    <tr runat="server" id="trCentralInfo" visible="false">
                                                        <td align="center" style="padding: 5px; vertical-align: top; text-align: center">
                                                            <asp:GridView ID="gvCluster" runat="server" AutoGenerateColumns="False" border="3" CellPadding="1" CellSpacing="1" Width="100%">
                                                                <HeaderStyle ForeColor="#FFFFFF" BackColor="#009688" Height="40px" CssClass="GridviewScrollC1HeaderWrap" />
                                                                <FooterStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                                                <RowStyle Height="40px" CssClass="GridviewScrollC1Item" HorizontalAlign="Left" />


                                                                <Columns>
                                                                    <asp:TemplateField HeaderText="Sl. No.">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="Label3" runat="server" Text='<%#Container.DataItemIndex + 1 %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                        <ItemStyle HorizontalAlign="center" />
                                                                    </asp:TemplateField>

                                                                    <asp:BoundField DataField="NAMEOFESTABLISHMENT" HeaderText="NAME OF ESTABLISHMENT">
                                                                        <HeaderStyle HorizontalAlign="Center" />
                                                                        <ItemStyle HorizontalAlign="left" />
                                                                    </asp:BoundField>
                                                                    <asp:BoundField DataField="SCHEDULEDINSPECTIONDATE" HeaderText="SCHEDULED INSPECTION DATE">
                                                                        <HeaderStyle HorizontalAlign="Center" />
                                                                        <ItemStyle HorizontalAlign="left" />
                                                                    </asp:BoundField>
                                                                    <asp:BoundField DataField="INSPECTIONCONDUCTEDDATE" HeaderText="INSPECTION CONDUCTED DATE">
                                                                        <HeaderStyle HorizontalAlign="Center" />
                                                                        <ItemStyle HorizontalAlign="left" />
                                                                    </asp:BoundField>
                                                                    <asp:BoundField DataField="ALLOCATEDINSPECTOR" HeaderText="ALLOCATED INSPECTOR">
                                                                        <HeaderStyle HorizontalAlign="Center" />
                                                                        <ItemStyle HorizontalAlign="left" />
                                                                    </asp:BoundField>
                                                                    <asp:BoundField DataField="DATEOFUPLOADINGINSPECTIONREPORT" HeaderText="INSPECTION UPLOAD REPORT DATE">
                                                                        <HeaderStyle HorizontalAlign="Center" />
                                                                        <ItemStyle HorizontalAlign="left" />
                                                                    </asp:BoundField>
                                                                    <asp:BoundField DataField="UPLOADWITHIN24HRS" HeaderText="INSPECTION UPLOAD WITHIN24HOURS">
                                                                        <HeaderStyle HorizontalAlign="Center" />
                                                                        <ItemStyle HorizontalAlign="left" />
                                                                    </asp:BoundField>
                                                                    <asp:TemplateField HeaderText="INSPECTIONREPORT">
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lbtnView" runat="server" CommandArgument='<%# Eval("INSPECTIONREPORT") %>'
                                                                                CommandName="VIEW" Text="View"></asp:LinkButton>
                                                                            <%--<a href="ClusterPrint.aspx"  height="32px" tabindex="11" target="_blank">View</a>--%>
                                                                        </ItemTemplate>
                                                                        <ItemStyle HorizontalAlign="Left" />
                                                                    </asp:TemplateField>

                                                                </Columns>

                                                            </asp:GridView>


                                                        </td>
                                                    </tr>
                                                    <tr runat="server" id="Reject">
                                                        <td align="center" style="padding: 5px; vertical-align: middle; text-align: center">
                                                            <asp:Label ID="lblerrMsg" runat="server" Font-Bold="True" ForeColor="Red" Width="270px"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>

                        </table>
                    </div>

                </div>
            </div>
        </div>
    </div>
</asp:Content>

