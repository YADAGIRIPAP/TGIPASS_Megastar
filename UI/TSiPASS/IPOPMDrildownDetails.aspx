<%@ Page Title=":: TS-iPASS :: " Language="C#" MasterPageFile="~/UI/TSiPASS/CCMaster.master"
    AutoEventWireup="true" CodeFile="IPOPMDrildownDetails.aspx.cs" Inherits="TSTBDCReg1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

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
        function sumPropBulk() {
            var txtFirstNumberValue = document.getElementById('txtProsPetorlClassA').value;
            var txtSecondNumberValue = document.getElementById('txtPropPetolClassB').value;
            var txtThirdNumberValue = document.getElementById('txtPropPetolClassB').value;
            var result = parseInt(txtFirstNumberValue) + parseInt(txtSecondNumberValue) + parseInt(txtThirdNumberValue);
            if (!isNaN(result)) {
                document.getElementById('txtPropPetrolTotal').value = result;
            }
        }
    </script>

    <asp:UpdatePanel ID="upd1" runat="server">
        <ContentTemplate>
            <div align="left">
                <ol class="breadcrumb">
                    You are here &nbsp;!&nbsp; &nbsp; &nbsp;
                    <li><i class="fa fa-dashboard"></i><a href="Home.aspx"></a></li>
                    <li class=""><i class="fa fa-fw fa-edit">IPO PMS</i> </li>
                    <li class="active"><i class="fa fa-edit"></i><a href="#">View Bank Visit -I Details</a> </li>
                </ol>
            </div>
            <div align="left">
                <div class="row" align="left">
                    <div class="col-lg-11">
                        <div class="panel panel-primary">
                            <div class="panel-heading" align="center">
                                <h3 class="panel-title">
                                IPO Performance Monitoring System - Bank Visit-I Details
                                </h3>
                            </div>
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>
                                    <div class="panel-body">
                                        <table align="center" cellpadding="10" cellspacing="5" style="width: 99%">
                                            <tr>
                                                <td align="left" style="padding: 5px; margin: 5px" valign="top">
                                                    <table cellpadding="4" cellspacing="5" style="width: 100%">
                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px; text-align: center;" align="center">
                                                                <asp:Label ID="lblMsg" runat="server" Font-Bold="True" Font-Names="verdana" 
                                                                    Font-Size="13px" ForeColor="#006600"></asp:Label>
                                                                <tr>
                                                                    <td align="center" style="padding: 5px; margin: 5px">
                                                                        <asp:GridView ID="grdDetails" runat="server" AllowPaging="True" CellPadding="4" 
                                                                            CssClass="GRD" ForeColor="#333333" GridLines="None" Height="62px" 
                                                                            OnPageIndexChanging="grdDetails_PageIndexChanging" 
                                                                            OnRowDataBound="grdDetails_RowDataBound" PageSize="20" Width="100%">
                                                                            <FooterStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                                                            <RowStyle BackColor="#EBF2FE" CssClass="GRDITEM" HorizontalAlign="Left" 
                                                                                VerticalAlign="Middle" />
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
                                                                                <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Uploaded Document">
                                                                                    <ItemTemplate>
                                                                                        <asp:HyperLink ID="hypLetter" Target="_blank" runat="server">Download</asp:HyperLink>
                                                                                    </ItemTemplate>
                                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                                    <ItemStyle Width="50px" />
                                                                                </asp:TemplateField>
                                                                               
                                                                            </Columns>
                                                                            <PagerStyle BackColor="#013161" ForeColor="White" HorizontalAlign="Center" />
                                                                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                                                            <HeaderStyle BackColor="#013161" CssClass="GRDHEADER" Font-Bold="True" 
                                                                                ForeColor="White" />
                                                                            <EditRowStyle BackColor="#B9D684" />
                                                                            <AlternatingRowStyle BackColor="White" />
                                                                        </asp:GridView>
                                                                        <tr>
                                                                            <td align="center" style="padding: 5px; margin: 5px">
                                                                                &nbsp;
                                                                                <asp:Label ID="lblresult" runat="server" Font-Bold="True" Font-Names="verdana" 
                                                                                    Font-Size="13px" ForeColor="#006600"></asp:Label>
                                                                            </td>
                                                                        </tr>
                                                                        <caption>
                                                                            &nbsp;</caption>
                                                                    </td>
                                                                </tr>
                                                            </td>
                                                        </tr>
                                                    </table>
                                    </div>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                    </div>
                </div>
            </div>
            <asp:UpdateProgress ID="UpdateProgress" runat="server" AssociatedUpdatePanelID="updatepanel1">
                <ProgressTemplate>
                    <div class="overlay">
                        <%--<div style=" z-index: 1000; margin-left: 350px;margin-top:200px;opacity: 1;-moz-opacity: 1;">--%>
                        <div style="z-index: 1000; margin-left: -210px; margin-top: 100px; opacity: 1; -moz-opacity: 1;">
                            <img alt="" src="../../Resource/Images/Processing.gif" />
                        </div>
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
    <%--</div>
       </td>
        </tr>
    </table>--%>
</asp:Content>
