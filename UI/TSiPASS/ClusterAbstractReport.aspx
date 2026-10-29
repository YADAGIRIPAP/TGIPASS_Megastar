<%@ Page Title="" Language="C#" MasterPageFile="~/UI/TSiPASS/CCMaster.master" AutoEventWireup="true" CodeFile="ClusterAbstractReport.aspx.cs" Inherits="UI_TSiPASS_ClusterAbstractReport" %>

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
                        <h3 class="panel-title">CLUSTER REPORT</h3>
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
                                                        <td style="padding: 5px; margin: 5px; text-align: left;" class="auto-style1"><strong>District : </strong></td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;" class="auto-style1">
                                                            <asp:DropDownList ID="ddlDistrict" runat="server" class="form-control txtbox" Height="33px" Width="180px">
                                                                <asp:ListItem>--Select--</asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td style="width: 100px">&nbsp;</td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;" class="auto-style1">&nbsp;</td>
                                                    </tr>
                                                    <tr style="height: 35px">
                                                        <td style="padding: 5px; margin: 5px; text-align: left;" class="auto-style1">
                                                            <strong>From Date : </strong></td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;" class="auto-style1">
                                                            <%--   <asp:TextBox Style="position: static" ID="txtFMDD" runat="server" MaxLength="2" Width="30px" onkeypress="return inputOnlyNumbers(event)"></asp:TextBox>
                                                            <asp:TextBox Style="position: static" ID="txtFMMM" runat="server" MaxLength="2" Width="30px" onkeypress="return inputOnlyNumbers(event)"></asp:TextBox>
                                                            <asp:TextBox Style="position: static" ID="txtFMYYYY" runat="server" MaxLength="4" onkeypress="return inputOnlyNumbers(event)"
                                                                Width="50px"></asp:TextBox>--%>
                                                            <asp:TextBox ID="txtFromDate" runat="server" class="form-control txtbox" Height="28px" MaxLength="40" onkeypress="NumberOnly()" TabIndex="1" ValidationGroup="group" Width="180px"></asp:TextBox>
                                                            <cc1:CalendarExtender ID="CalendarExtender2" runat="server" Format="yyyy-MM-dd" TargetControlID="txtFromDate">
                                                            </cc1:CalendarExtender>
                                                        </td>
                                                        <td style="width: 100px">
                                                            <strong>To Date : </strong></td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;" class="auto-style1">
                                                            <%--  <asp:TextBox Style="position: static" ID="txtTODD" runat="server" MaxLength="2" Width="30px" onkeypress="return inputOnlyNumbers(event)"></asp:TextBox>
                                                            <asp:TextBox Style="position: static" ID="txtTOMM" runat="server" MaxLength="2" Width="30px" onkeypress="return inputOnlyNumbers(event)"></asp:TextBox>
                                                            <asp:TextBox Style="position: static" ID="txtTOYYYY" runat="server" MaxLength="4" onkeypress="return inputOnlyNumbers(event)"
                                                                Width="50px"></asp:TextBox>--%>
                                                            <asp:TextBox ID="txtTodate" runat="server" class="form-control txtbox" Height="28px" MaxLength="40" onkeypress="NumberOnly()" TabIndex="1" ValidationGroup="group" Width="180px"></asp:TextBox>
                                                            <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="yyyy-MM-dd" TargetControlID="txtTodate">
                                                            </cc1:CalendarExtender>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr style="height: 35px">
                                            <td style="padding: 5px; margin: 5px; text-align: center;" class="auto-style1" colspan="4">
                                                <asp:Button ID="btnGet" runat="server" CssClass="btn btn-primary" Height="32px" TabIndex="10" Text="SUBMIT" Width="90px" OnClick="btnGet_Click" />


                                                &nbsp;&nbsp;&nbsp;
                                                <asp:Button ID="BTNbACK" runat="server" CssClass="btn btn-primary" Height="32px" TabIndex="10" Text="BACK" Width="90px" OnClick="BTNbACK_Click" />

                                            </td>

                                        </tr>
                                        <tr style="height: 35px">
                                            <td style="padding: 5px; margin: 5px; text-align: center;" class="auto-style1" colspan="4">&nbsp;</td>

                                        </tr>
                                        <tr>
                                            <td>
                                                <table style="vertical-align: top; text-align: center;" cellpadding="0" cellspacing="0" width="90%">
                                                    <tr runat="server" id="trDistrictData" visible="false">
                                                        <td align="center" style="padding: 5px; vertical-align: top; text-align: center">
                                                            <asp:GridView ID="gvDistrictData" runat="server" AutoGenerateColumns="False" border="3" CellPadding="1" CellSpacing="1" OnRowCommand="gvDistrictData_RowCommand" Width="90%">
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
                                                                    <asp:TemplateField HeaderText="District Name">
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="LinkButton1" runat="server" CommandArgument='<%# Eval("District_Cd") %>'
                                                                                CommandName="DISTRICT" Text='<%# Eval("District_Name") %>'></asp:LinkButton>
                                                                            <asp:Label ID="Label5" Text='<%# Eval("District_Name") %>' Visible="false" runat="server"></asp:Label>
                                                                        </ItemTemplate>
                                                                        <ItemStyle HorizontalAlign="Left" />
                                                                    </asp:TemplateField>
                                                                    <asp:BoundField DataField="CLUSTERCOUNT" HeaderText="No. of Clusters">
                                                                        <HeaderStyle HorizontalAlign="Center" />
                                                                        <ItemStyle HorizontalAlign="left" />
                                                                    </asp:BoundField>
                                                                    <asp:BoundField DataField="No_Units" HeaderText="Total Units">
                                                                        <HeaderStyle HorizontalAlign="Center" />
                                                                        <ItemStyle HorizontalAlign="left" />
                                                                    </asp:BoundField>
                                                                    <asp:BoundField DataField="Investment" HeaderText="Total Investment(Rs. in Lakhs)">
                                                                        <HeaderStyle HorizontalAlign="Center" />
                                                                        <ItemStyle HorizontalAlign="left" />
                                                                    </asp:BoundField>
                                                                    <asp:BoundField DataField="Employment" HeaderText="Total Employment">
                                                                        <HeaderStyle HorizontalAlign="Center" />
                                                                        <ItemStyle HorizontalAlign="left" />
                                                                    </asp:BoundField>
                                                                    <asp:BoundField DataField="TurnOver" HeaderText="Total Turnover(Rs. in Lakhs)">
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
                                                    <tr runat="server" id="trClusterInfo" visible="false">
                                                        <td align="center" style="padding: 5px; vertical-align: top; text-align: center">
                                                            <asp:GridView ID="gvCluster" runat="server" AutoGenerateColumns="False" border="3" CellPadding="1" CellSpacing="1" OnRowCommand="gvCluster_RowCommand" Width="100%">
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

                                                                    <asp:BoundField DataField="LineofActivity" HeaderText="Line of Activity">
                                                                        <HeaderStyle HorizontalAlign="Center" />
                                                                        <ItemStyle HorizontalAlign="left" />
                                                                    </asp:BoundField>
                                                                    <asp:BoundField DataField="Infra_SubStation" HeaderText="SubStation Name">
                                                                        <HeaderStyle HorizontalAlign="Center" />
                                                                        <ItemStyle HorizontalAlign="left" />
                                                                    </asp:BoundField>
                                                                    <asp:BoundField DataField="Infra_Training_Facility" HeaderText="Training Facility">
                                                                        <HeaderStyle HorizontalAlign="Center" />
                                                                        <ItemStyle HorizontalAlign="left" />
                                                                    </asp:BoundField>
                                                                    <asp:BoundField DataField="Raw_Material_Source" HeaderText="Raw Material Source">
                                                                        <HeaderStyle HorizontalAlign="Center" />
                                                                        <ItemStyle HorizontalAlign="left" />
                                                                    </asp:BoundField>
                                                                    <asp:BoundField DataField="Major_Markets" HeaderText="Major Markets">
                                                                        <HeaderStyle HorizontalAlign="Center" />
                                                                        <ItemStyle HorizontalAlign="left" />
                                                                    </asp:BoundField>
                                                                    <asp:TemplateField HeaderText="View">
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lbtnView" runat="server" CommandArgument='<%# Eval("Cluster_Id") %>'
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


