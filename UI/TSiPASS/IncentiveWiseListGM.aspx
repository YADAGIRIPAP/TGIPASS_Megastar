<%@ Page Title="" Language="C#" MasterPageFile="~/UI/TSiPASS/CCMaster.master" AutoEventWireup="true" CodeFile="IncentiveWiseListGM.aspx.cs" Inherits="UI_TSiPASS_IncentiveWiseListGM" %>

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

        .CS {
            background-color: #abcdef;
            color: Yellow;
            border: 1px solid #1d9a5b;
            font: Verdana 10px;
            padding: 1px 4px;
            font-family: Palatino Linotype, Arial, Helvetica, sans-serif;
        }

        .update {
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

        .style7 {
            color: #FF3300;
        }

        .style8 {
            color: #FF0000;
            font-weight: bold;
        }

        .GRD {
            width: 800px;
            height: auto;
            border-color: #013161;
            border-style: solid;
            border-width: 1px;
            text-transform: capitalize;
            padding: 5px;
        }

        .GRDHEADER {
            border: 1px solid #1d9a5b;
            color: #1d9a5b;
            vertical-align: middle;
            text-align: center;
            height: 25px;
            width: 50px;
            padding: 10px;
            font-size: 12px;
            font-weight: bold;
            text-transform: capitalize;
            font-family: Verdana;
            background-image: url('../../Resource/Styles/images/bg_blue_grd.gif');
        }

        .GRDITEM {
            /*background-color: WHITE;*/
            color: black;
            font-size: 12px;
            font-weight: normal;
            font-family: Verdana;
            padding: 10px; /*text-decoration:none;*/ /*border-color:#013161;*/ /*border-style:solid;*/
            text-transform: uppercase; /*border-width:1px;*/ /*height:23px;*/ /*text-indent:5px;*/ /*BACKGROUND-IMAGE: url(../images/grid_bg_.gif);*/
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
    <link href="assets/css/basic.css" rel="stylesheet" />
    <%--  <asp:UpdatePanel ID="upd1" runat="server">
        <ContentTemplate>--%>
    <div align="left">
        <ol class="breadcrumb">
            You are here &nbsp;!&nbsp; &nbsp; &nbsp;
                    <li><i class="fa fa-dashboard"></i><a href="Home.aspx"></a></li>
            <li class=""><i class="fa fa-fw fa-edit">CAF</i> </li>
            <li class="active"><i class="fa fa-edit"></i>&nbsp; &nbsp;<a href="#">Departments</a> </li>
        </ol>
    </div>
    <div align="left">
        <div class="row" align="left">
            <div class="col-lg-12">
                <%--<div class="panel panel-primary">
                            <div class="panel-heading" align="center">
                                <h3 class="panel-title">Departments</h3>
                            </div>--%>
                <table style="width: 100%">
                    <tr>
                        <td>
                            <div class="col-md-12">
                                <h1 class="page-head-line" align="left" style="font-size: large">List of cases sanctioned incentives </h1>
                                <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
                                <asp:Label ID="Label4" runat="server" Text="Label"></asp:Label>
                                <asp:Label ID="Label5" runat="server" Text="Label"></asp:Label>
                            </div>

                            <div class="panel-body">
                                <table align="left" cellpadding="10" cellspacing="5" style="width: 100%">
                                    <%--  <tr>
                                        <td style="padding: 15px; margin: 5px; font-weight: bold;">1.
                                        </td>
                                        <td style="padding: 5px; margin: 5px; width: 900px; text-align: left; font-weight: bold; font-size: 14pt">SC Category
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="padding: 15px; margin: 5px;"></td>
                                        <td style="padding: 5px; margin: 5px; width: 900px; font-weight: bold;">A). Pavalla vaddi
                                        </td>
                                    </tr>--%>
                                    <tr>
                                        <td style="padding: 15px; margin: 5px;"></td>
                                        <td style="padding: 5px; margin: 5px; width: 100%" valign="top" colspan="2">
                                            <div id="divprint">
                                                <B>LIST OF APPLICATIONS FOR WHICH AGREEMENT BOND COPIES ARE UPLOADED</B>
                                                <div style="width: 100%">
                                                    <asp:GridView ID="grdDetailsPavallavaddiSC" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                                        CssClass="GRD" ForeColor="#333333" Height="62px" OnRowDataBound="grdDetailsPavallavaddiSC_RowDataBound"
                                                        PageSize="15" ShowFooter="false" Width="80%" CellSpacing="4">
                                                        <FooterStyle BackColor="#be8c2f" Font-Bold="True" ForeColor="White" />
                                                        <RowStyle BackColor="#EBF2FE" CssClass="GRDITEM" HorizontalAlign="Left" VerticalAlign="Middle" />
                                                        <Columns>
                                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S No">
                                                                <ItemTemplate>
                                                                    <%# Container.DataItemIndex + 1%>
                                                                    <asp:HiddenField ID="HdfQueid" runat="server" />
                                                                    <asp:HiddenField ID="HdfApprovalid" runat="server" />
                                                                    <asp:HiddenField ID="HdfDeptid" runat="server" />
                                                                </ItemTemplate>
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                <ItemStyle Width="50px" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="Category">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblCategory" runat="server" Text='<%#Eval("Category") %>'></asp:Label>
                                                                </ItemTemplate>
                                                                <HeaderStyle HorizontalAlign="Left" Width="80px" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="Incentive Name">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblince" runat="server" Text='<%#Eval("IncentiveName") %>'></asp:Label>
                                                                </ItemTemplate>
                                                                <HeaderStyle HorizontalAlign="Left" Width="400px" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="No. of Claims">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="hSLCNumber" runat="server" Text='<%#Eval("Noincentives") %>'></asp:Label>
                                                                </ItemTemplate>
                                                                <HeaderStyle HorizontalAlign="Left" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="Sanctioned Amount">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="txtsanctionedamount" Text='<%#Eval("PendingAmount") %>' runat="server"></asp:Label>
                                                                </ItemTemplate>
                                                                <HeaderStyle HorizontalAlign="Left" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Process">
                                                                <ItemTemplate>
                                                                    <asp:Button ID="agreemnentButton" runat="server" CssClass="btn btn-primary" width="150px" Text="PROCESS" OnClick="agreemnentButton_Click" />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="masterid" Visible="false">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="Label3" runat="server" Text='<%#Eval("IncentiveTypID") %>'></asp:Label>
                                                                </ItemTemplate>
                                                                <HeaderStyle HorizontalAlign="Left" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="Category1" Visible="false">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblCategory1" runat="server" Text='<%#Eval("Category1") %>'></asp:Label>
                                                                </ItemTemplate>
                                                                <HeaderStyle HorizontalAlign="Left" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="" Visible="false">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblSubIncTypeId" runat="server" Text='<%#Eval("SubIncTypeId") %>'></asp:Label>
                                                                </ItemTemplate>
                                                                <HeaderStyle HorizontalAlign="Left" />
                                                            </asp:TemplateField>
                                                        </Columns>
                                                        <PagerStyle BackColor="#013161" ForeColor="White" HorizontalAlign="Center" />
                                                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                                        <HeaderStyle BackColor="#1d9a5b" CssClass="GRDHEADER" Font-Bold="True" ForeColor="White" />
                                                        <EditRowStyle BackColor="#B9D684" />
                                                        <AlternatingRowStyle BackColor="White" />
                                                    </asp:GridView>
                                                </div>
                                                <br />
                                                 <B>LIST OF APPLICATIONS - Legacy Data</B>
                                                <div style="width: 100%">
                                                    <asp:GridView ID="gvOfflineApplications" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                                        CssClass="GRD" ForeColor="#333333" Height="62px"  
                                                        PageSize="15" ShowFooter="false" Width="80%" CellSpacing="4" OnRowDataBound="gvOfflineApplications_RowDataBound"  >
                                                        <FooterStyle BackColor="#be8c2f" Font-Bold="True" ForeColor="White" />
                                                        <RowStyle BackColor="#EBF2FE" CssClass="GRDITEM" HorizontalAlign="Left" VerticalAlign="Middle" />
                                                        <Columns>
                                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S No">
                                                                <ItemTemplate>
                                                                    <%# Container.DataItemIndex + 1%>
                                                                    <asp:HiddenField ID="HdfQueid" runat="server" />
                                                                    <asp:HiddenField ID="HdfApprovalid" runat="server" />
                                                                    <asp:HiddenField ID="HdfDeptid" runat="server" />
                                                                </ItemTemplate>
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                <ItemStyle Width="50px" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="Category">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblCategory" runat="server" Text='<%#Eval("Category") %>'></asp:Label>
                                                                </ItemTemplate>
                                                                <HeaderStyle HorizontalAlign="Left" Width="80px" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="Incentive Name">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblince" runat="server" Text='<%#Eval("IncentiveName") %>'></asp:Label>
                                                                </ItemTemplate>
                                                                <HeaderStyle HorizontalAlign="Left" Width="400px" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="No. of Claims">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="hSLCNumber" runat="server" Text='<%#Eval("Noincentives") %>'></asp:Label>
                                                                </ItemTemplate>
                                                                <HeaderStyle HorizontalAlign="Left" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="Sanctioned Amount">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="txtsanctionedamount" Text='<%#Eval("PendingAmount") %>' runat="server"></asp:Label>
                                                                </ItemTemplate>
                                                                <HeaderStyle HorizontalAlign="Left" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Process">
                                                                <ItemTemplate>
                                                                    <asp:Button ID="btnOfflineapplications" runat="server"    CssClass="btn btn-primary" Width="150px"  Text="PROCESS" OnClick="btnOfflineapplications_Click"   />
                                                                
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="masterid" Visible="false">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="Label3" runat="server" Text='<%#Eval("IncentiveTypID") %>'></asp:Label>
                                                                </ItemTemplate>
                                                                <HeaderStyle HorizontalAlign="Left" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="Category1" Visible="false">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblCategory1" runat="server" Text='<%#Eval("Category1") %>'></asp:Label>
                                                                </ItemTemplate>
                                                                <HeaderStyle HorizontalAlign="Left" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="" Visible="false">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblSubIncTypeId" runat="server" Text='<%#Eval("SubIncTypeId") %>'></asp:Label>
                                                                </ItemTemplate>
                                                                <HeaderStyle HorizontalAlign="Left" />
                                                            </asp:TemplateField>
                                                        </Columns>
                                                        <PagerStyle BackColor="#013161" ForeColor="White" HorizontalAlign="Center" />
                                                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                                        <HeaderStyle BackColor="#1d9a5b" CssClass="GRDHEADER" Font-Bold="True" ForeColor="White" />
                                                        <EditRowStyle BackColor="#B9D684" />
                                                        <AlternatingRowStyle BackColor="White" />
                                                    </asp:GridView>
                                                </div>
                                                <br />
                                                <br />
                                                <%--<B>LIST OF APPLICATIONS WITHOUT AGREEMENT BOND COPY AND ASSIGNMENT LETTER</B>--%>  <%-- COMMENTED ON 06.07.2022--%>
                                                <div style="width: 100%">
                                                    <asp:GridView ID="grdAgreementCases" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                                        CssClass="GRD" ForeColor="#333333" Height="62px"  
                                                        PageSize="15" ShowFooter="false" Width="80%" CellSpacing="4" OnRowDataBound="grdAgreementCases_RowDataBound">
                                                        <FooterStyle BackColor="#be8c2f" Font-Bold="True" ForeColor="White" />
                                                        <RowStyle BackColor="#EBF2FE" CssClass="GRDITEM" HorizontalAlign="Left" VerticalAlign="Middle" />
                                                        <Columns>
                                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S No">
                                                                <ItemTemplate>
                                                                    <%# Container.DataItemIndex + 1%>
                                                                    <asp:HiddenField ID="HdfQueid" runat="server" />
                                                                    <asp:HiddenField ID="HdfApprovalid" runat="server" />
                                                                    <asp:HiddenField ID="HdfDeptid" runat="server" />
                                                                </ItemTemplate>
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                <ItemStyle Width="50px" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="Category">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblCategory" runat="server" Text='<%#Eval("Category") %>'></asp:Label>
                                                                </ItemTemplate>
                                                                <HeaderStyle HorizontalAlign="Left" Width="80px" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="Incentive Name">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblince" runat="server" Text='<%#Eval("IncentiveName") %>'></asp:Label>
                                                                </ItemTemplate>
                                                                <HeaderStyle HorizontalAlign="Left" Width="400px" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="No. of Claims">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="hSLCNumber" runat="server" Text='<%#Eval("Noincentives") %>'></asp:Label>
                                                                </ItemTemplate>
                                                                <HeaderStyle HorizontalAlign="Left" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="Sanctioned Amount">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="txtsanctionedamount" Text='<%#Eval("PendingAmount") %>' runat="server"></asp:Label>
                                                                </ItemTemplate>
                                                                <HeaderStyle HorizontalAlign="Left" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Process">
                                                                <ItemTemplate>
                                                                    <asp:Button ID="agrementNotUpload" runat="server"    CssClass="btn btn-primary" Width="150px"  Text="PROCESS" OnClick="agrementNotUpload_Click" />
                                                                
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="masterid" Visible="false">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="Label3" runat="server" Text='<%#Eval("IncentiveTypID") %>'></asp:Label>
                                                                </ItemTemplate>
                                                                <HeaderStyle HorizontalAlign="Left" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="Category1" Visible="false">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblCategory1" runat="server" Text='<%#Eval("Category1") %>'></asp:Label>
                                                                </ItemTemplate>
                                                                <HeaderStyle HorizontalAlign="Left" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="" Visible="false">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblSubIncTypeId" runat="server" Text='<%#Eval("SubIncTypeId") %>'></asp:Label>
                                                                </ItemTemplate>
                                                                <HeaderStyle HorizontalAlign="Left" />
                                                            </asp:TemplateField>
                                                        </Columns>
                                                        <PagerStyle BackColor="#013161" ForeColor="White" HorizontalAlign="Center" />
                                                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                                        <HeaderStyle BackColor="#1d9a5b" CssClass="GRDHEADER" Font-Bold="True" ForeColor="White" />
                                                        <EditRowStyle BackColor="#B9D684" />
                                                        <AlternatingRowStyle BackColor="White" />
                                                    </asp:GridView>
                                                </div>
                                                <br />
                                                <B>LIST OF APPLICATIONS FOR WHICH AGREEMENT BOND COPIES ARE NOT UPLOADED</B>
                                                <div style="width: 100%">
                                                    <asp:GridView ID="grdUploadPending" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                                        CssClass="GRD" ForeColor="#333333" Height="62px"  
                                                        PageSize="15" ShowFooter="false" Width="80%" CellSpacing="4" OnRowDataBound="grdUploadPending_RowDataBound" >
                                                        <FooterStyle BackColor="#be8c2f" Font-Bold="True" ForeColor="White" />
                                                        <RowStyle BackColor="#EBF2FE" CssClass="GRDITEM" HorizontalAlign="Left" VerticalAlign="Middle" />
                                                        <Columns>
                                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S No">
                                                                <ItemTemplate>
                                                                    <%# Container.DataItemIndex + 1%>
                                                                    <asp:HiddenField ID="HdfQueid" runat="server" />
                                                                    <asp:HiddenField ID="HdfApprovalid" runat="server" />
                                                                    <asp:HiddenField ID="HdfDeptid" runat="server" />
                                                                </ItemTemplate>
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                <ItemStyle Width="50px" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="Category">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblCategory" runat="server" Text='<%#Eval("Category") %>'></asp:Label>
                                                                </ItemTemplate>
                                                                <HeaderStyle HorizontalAlign="Left" Width="80px" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="Incentive Name">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblince" runat="server" Text='<%#Eval("IncentiveName") %>'></asp:Label>
                                                                </ItemTemplate>
                                                                <HeaderStyle HorizontalAlign="Left" Width="400px" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="No. of Claims">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="hSLCNumber" runat="server" Text='<%#Eval("Noincentives") %>'></asp:Label>
                                                                </ItemTemplate>
                                                                <HeaderStyle HorizontalAlign="Left" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="Sanctioned Amount">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="txtsanctionedamount" Text='<%#Eval("PendingAmount") %>' runat="server"></asp:Label>
                                                                </ItemTemplate>
                                                                <HeaderStyle HorizontalAlign="Left" />
                                                            </asp:TemplateField>
                                                            
                                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="masterid" Visible="false">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblIncentiveTypID" runat="server" Text='<%#Eval("IncentiveTypID") %>'></asp:Label>
                                                                </ItemTemplate>
                                                                <HeaderStyle HorizontalAlign="Left" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="Category1" Visible="false">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblCategory1" runat="server" Text='<%#Eval("Category1") %>'></asp:Label>
                                                                </ItemTemplate>
                                                                <HeaderStyle HorizontalAlign="Left" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="" Visible="false">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblSubIncTypeId" runat="server" Text='<%#Eval("SubIncTypeId") %>'></asp:Label>
                                                                </ItemTemplate>
                                                                <HeaderStyle HorizontalAlign="Left" />
                                                            </asp:TemplateField>
                                                             <asp:TemplateField HeaderText="Process">
                                                                <ItemTemplate>
                                                                    <asp:Button ID="agreementaftrNotupload" runat="server"    CssClass="btn btn-primary" Width="150px"  Text="PROCESS" OnClick="agreementaftrNotupload_Click" />
                                                                
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                        </Columns>
                                                        <PagerStyle BackColor="#013161" ForeColor="White" HorizontalAlign="Center" />
                                                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                                        <HeaderStyle BackColor="#1d9a5b" CssClass="GRDHEADER" Font-Bold="True" ForeColor="White" />
                                                        <EditRowStyle BackColor="#B9D684" />
                                                        <AlternatingRowStyle BackColor="White" />
                                                    </asp:GridView>
                                                </div>

                                                 <B>LIST OF APPLICATIONS UNDER ABEYANCE</B>
                                                <div style="width: 100%">
                                                    <asp:GridView ID="grdAbeyance" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                                        CssClass="GRD" ForeColor="#333333" Height="62px"  
                                                        PageSize="15" ShowFooter="false" Width="80%" CellSpacing="4" OnRowDataBound="grdAbeyance_RowDataBound" >
                                                        <FooterStyle BackColor="#be8c2f" Font-Bold="True" ForeColor="White" />
                                                        <RowStyle BackColor="#EBF2FE" CssClass="GRDITEM" HorizontalAlign="Left" VerticalAlign="Middle" />
                                                        <Columns>
                                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S No">
                                                                <ItemTemplate>
                                                                    <%# Container.DataItemIndex + 1%>
                                                                    <asp:HiddenField ID="HdfQueid" runat="server" />
                                                                    <asp:HiddenField ID="HdfApprovalid" runat="server" />
                                                                    <asp:HiddenField ID="HdfDeptid" runat="server" />
                                                                </ItemTemplate>
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                <ItemStyle Width="50px" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="Category">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblCategory" runat="server" Text='<%#Eval("Category") %>'></asp:Label>
                                                                </ItemTemplate>
                                                                <HeaderStyle HorizontalAlign="Left" Width="80px" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="Incentive Name">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblince" runat="server" Text='<%#Eval("IncentiveName") %>'></asp:Label>
                                                                </ItemTemplate>
                                                                <HeaderStyle HorizontalAlign="Left" Width="400px" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="No. of Claims">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="hSLCNumber" runat="server" Text='<%#Eval("Noincentives") %>'></asp:Label>
                                                                </ItemTemplate>
                                                                <HeaderStyle HorizontalAlign="Left" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="Sanctioned Amount">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="txtsanctionedamount" Text='<%#Eval("PendingAmount") %>' runat="server"></asp:Label>
                                                                </ItemTemplate>
                                                                <HeaderStyle HorizontalAlign="Left" />
                                                            </asp:TemplateField>
                                                            
                                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="masterid" Visible="false">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblIncentiveTypID" runat="server" Text='<%#Eval("IncentiveTypID") %>'></asp:Label>
                                                                </ItemTemplate>
                                                                <HeaderStyle HorizontalAlign="Left" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="Category1" Visible="false">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblCategory1" runat="server" Text='<%#Eval("Category1") %>'></asp:Label>
                                                                </ItemTemplate>
                                                                <HeaderStyle HorizontalAlign="Left" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="" Visible="false">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblSubIncTypeId" runat="server" Text='<%#Eval("SubIncTypeId") %>'></asp:Label>
                                                                </ItemTemplate>
                                                                <HeaderStyle HorizontalAlign="Left" />
                                                            </asp:TemplateField>
                                                             <asp:TemplateField HeaderText="Process">
                                                                <ItemTemplate>
                                                                    <asp:Button ID="agreementaftrNotuploadAbeyance" runat="server"    CssClass="btn btn-primary" Width="150px"  Text="PROCESS" OnClick="agreementaftrNotuploadAbeyance_Click" />
                                                                
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                        </Columns>
                                                        <PagerStyle BackColor="#013161" ForeColor="White" HorizontalAlign="Center" />
                                                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                                        <HeaderStyle BackColor="#1d9a5b" CssClass="GRDHEADER" Font-Bold="True" ForeColor="White" />
                                                        <EditRowStyle BackColor="#B9D684" />
                                                        <AlternatingRowStyle BackColor="White" />
                                                    </asp:GridView>
                                                </div>

                                            </div>
                                        </td>
                                    </tr>
                                    <%--  <tr>
                                        <td style="padding: 15px; margin: 5px; font-weight: bold;"></td>
                                        <td style="padding: 5px; margin: 5px; width: 900px; font-weight: bold;">B). Investment Subsidy
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="padding: 15px; margin: 5px;"></td>
                                        <td style="padding: 5px; margin: 5px; width: 100%" valign="top" colspan="2">
                                            <div style="width: 100%">
                                                <asp:GridView ID="gvInvestmentSubsidySC" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                                    CssClass="GRD" ForeColor="#333333" Height="62px"
                                                    PageSize="15" ShowFooter="false" Width="80%" CellSpacing="4">
                                                    <FooterStyle BackColor="#be8c2f" Font-Bold="True" ForeColor="White" />
                                                    <RowStyle BackColor="#EBF2FE" CssClass="GRDITEM" HorizontalAlign="Left" VerticalAlign="Middle" />
                                                    <Columns>
                                                        <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S No">
                                                            <ItemTemplate>
                                                                <%# Container.DataItemIndex + 1%>
                                                                <asp:HiddenField ID="HdfQueid" runat="server" />
                                                                <asp:HiddenField ID="HdfApprovalid" runat="server" />
                                                                <asp:HiddenField ID="HdfDeptid" runat="server" />
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <ItemStyle Width="50px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="Incentive Name">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblince" runat="server" Text='<%#Eval("IncentiveName") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Left" Width="400px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="Count">
                                                            <ItemTemplate>
                                                                <asp:Label ID="hSLCNumber" runat="server" Text='<%#Eval("Noincentives") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Left" />
                                                        </asp:TemplateField>
                                                       
                                                        <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="Sanctioned Amount">
                                                            <ItemTemplate>
                                                                <asp:Label ID="txtsanctionedamount" Text='<%#Eval("valueamount") %>' runat="server"></asp:Label>
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Left" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="View">
                                                            <ItemTemplate>
                                                                <asp:Button ID="Button2" CssClass="btn btn-primary" OnClick="Button2_Click" runat="server" Text="View" Width="150px" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="masterid" Visible="false">
                                                            <ItemTemplate>
                                                                <asp:Label ID="Label3" runat="server" Text='<%#Eval("IncentiveTypID") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Left" />
                                                        </asp:TemplateField>
                                                    </Columns>
                                                    <PagerStyle BackColor="#013161" ForeColor="White" HorizontalAlign="Center" />
                                                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                                    <HeaderStyle BackColor="#1d9a5b" CssClass="GRDHEADER" Font-Bold="True" ForeColor="White" />
                                                    <EditRowStyle BackColor="#B9D684" />
                                                    <AlternatingRowStyle BackColor="White" />
                                                </asp:GridView>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="padding: 15px; margin: 5px; font-weight: bold;"></td>
                                        <td style="padding: 5px; margin: 5px; width: 900px; font-weight: bold;">C). General
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="padding: 15px; margin: 5px;"></td>
                                        <td style="padding: 5px; margin: 5px; width: 100%" valign="top" colspan="2">
                                            <div style="width: 100%">
                                                <asp:GridView ID="gvGeneralSC" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                                    CssClass="GRD" ForeColor="#333333" Height="62px"
                                                    PageSize="15" ShowFooter="false" Width="80%" CellSpacing="4">
                                                    <FooterStyle BackColor="#be8c2f" Font-Bold="True" ForeColor="White" />
                                                    <RowStyle BackColor="#EBF2FE" CssClass="GRDITEM" HorizontalAlign="Left" VerticalAlign="Middle" />
                                                    <Columns>
                                                        <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S No">
                                                            <ItemTemplate>
                                                                <%# Container.DataItemIndex + 1%>
                                                                <asp:HiddenField ID="HdfQueid" runat="server" />
                                                                <asp:HiddenField ID="HdfApprovalid" runat="server" />
                                                                <asp:HiddenField ID="HdfDeptid" runat="server" />
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <ItemStyle Width="50px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="Incentive Name">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblince" runat="server" Text='<%#Eval("IncentiveName") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Left" Width="400px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="Count">
                                                            <ItemTemplate>
                                                                <asp:Label ID="hSLCNumber" runat="server" Text='<%#Eval("Noincentives") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Left" />
                                                        </asp:TemplateField>
                                                      
                                                        <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="Sanctioned Amount">
                                                            <ItemTemplate>
                                                                <asp:Label ID="txtsanctionedamount" Text='<%#Eval("valueamount") %>' runat="server"></asp:Label>
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Left" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="View">
                                                            <ItemTemplate>
                                                                <asp:Button ID="Button3" CssClass="btn btn-primary" OnClick="Button3_Click" runat="server" Text="View" Width="150px" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="masterid" Visible="false">
                                                            <ItemTemplate>
                                                                <asp:Label ID="Label3" runat="server" Text='<%#Eval("IncentiveTypID") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Left" />
                                                        </asp:TemplateField>
                                                    </Columns>
                                                    <PagerStyle BackColor="#013161" ForeColor="White" HorizontalAlign="Center" />
                                                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                                    <HeaderStyle BackColor="#1d9a5b" CssClass="GRDHEADER" Font-Bold="True" ForeColor="White" />
                                                    <EditRowStyle BackColor="#B9D684" />
                                                    <AlternatingRowStyle BackColor="White" />
                                                </asp:GridView>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="padding: 5px; margin: 5px" colspan="2" align="center">&nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="padding: 15px; margin: 5px; font-weight: bold;">2.
                                        </td>
                                        <td style="padding: 5px; margin: 5px; width: 900px; text-align: left; font-weight: bold; font-size: 14pt">ST Category
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="padding: 15px; margin: 5px;"></td>
                                        <td style="padding: 5px; margin: 5px; width: 900px; font-weight: bold;">A). Pavalla vaddi
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="padding: 15px; margin: 5px;"></td>
                                        <td style="padding: 5px; margin: 5px; width: 100%" valign="top" colspan="2">
                                            <div style="width: 100%">
                                                <asp:GridView ID="gvPavallavaddiST" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                                    CssClass="GRD" ForeColor="#333333" Height="62px"
                                                    PageSize="15" ShowFooter="false" Width="80%" CellSpacing="4">
                                                    <FooterStyle BackColor="#be8c2f" Font-Bold="True" ForeColor="White" />
                                                    <RowStyle BackColor="#EBF2FE" CssClass="GRDITEM" HorizontalAlign="Left" VerticalAlign="Middle" />
                                                    <Columns>
                                                        <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S No">
                                                            <ItemTemplate>
                                                                <%# Container.DataItemIndex + 1%>
                                                                <asp:HiddenField ID="HdfQueid" runat="server" />
                                                                <asp:HiddenField ID="HdfApprovalid" runat="server" />
                                                                <asp:HiddenField ID="HdfDeptid" runat="server" />
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <ItemStyle Width="50px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="Incentive Name">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblince" runat="server" Text='<%#Eval("IncentiveName") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Left" Width="400px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="Count">
                                                            <ItemTemplate>
                                                                <asp:Label ID="hSLCNumber" runat="server" Text='<%#Eval("Noincentives") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Left" />
                                                        </asp:TemplateField>
                                                       
                                                        <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="Sanctioned Amount">
                                                            <ItemTemplate>
                                                                <asp:Label ID="txtsanctionedamount" Text='<%#Eval("valueamount") %>' runat="server"></asp:Label>
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Left" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="View">
                                                            <ItemTemplate>
                                                                <asp:Button ID="Button4" CssClass="btn btn-primary" OnClick="Button4_Click" runat="server" Text="View" Width="150px" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="masterid" Visible="false">
                                                            <ItemTemplate>
                                                                <asp:Label ID="Label3" runat="server" Text='<%#Eval("IncentiveTypID") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Left" />
                                                        </asp:TemplateField>
                                                    </Columns>
                                                    <PagerStyle BackColor="#013161" ForeColor="White" HorizontalAlign="Center" />
                                                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                                    <HeaderStyle BackColor="#1d9a5b" CssClass="GRDHEADER" Font-Bold="True" ForeColor="White" />
                                                    <EditRowStyle BackColor="#B9D684" />
                                                    <AlternatingRowStyle BackColor="White" />
                                                </asp:GridView>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="padding: 15px; margin: 5px; font-weight: bold;"></td>
                                        <td style="padding: 5px; margin: 5px; width: 900px; font-weight: bold;">B). Investment Subsidy
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="padding: 15px; margin: 5px;"></td>
                                        <td style="padding: 5px; margin: 5px; width: 100%" valign="top" colspan="2">
                                            <div style="width: 100%">
                                                <asp:GridView ID="gvInvestmentSubsidyST" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                                    CssClass="GRD" ForeColor="#333333" Height="62px"
                                                    PageSize="15" ShowFooter="false" Width="80%" CellSpacing="4">
                                                    <FooterStyle BackColor="#be8c2f" Font-Bold="True" ForeColor="White" />
                                                    <RowStyle BackColor="#EBF2FE" CssClass="GRDITEM" HorizontalAlign="Left" VerticalAlign="Middle" />
                                                    <Columns>
                                                        <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S No">
                                                            <ItemTemplate>
                                                                <%# Container.DataItemIndex + 1%>
                                                                <asp:HiddenField ID="HdfQueid" runat="server" />
                                                                <asp:HiddenField ID="HdfApprovalid" runat="server" />
                                                                <asp:HiddenField ID="HdfDeptid" runat="server" />
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <ItemStyle Width="50px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="Incentive Name">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblince" runat="server" Text='<%#Eval("IncentiveName") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Left" Width="400px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="Count">
                                                            <ItemTemplate>
                                                                <asp:Label ID="hSLCNumber" runat="server" Text='<%#Eval("Noincentives") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Left" />
                                                        </asp:TemplateField>
                                                       
                                                        <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="Sanctioned Amount">
                                                            <ItemTemplate>
                                                                <asp:Label ID="txtsanctionedamount" Text='<%#Eval("valueamount") %>' runat="server"></asp:Label>
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Left" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="View">
                                                            <ItemTemplate>
                                                                <asp:Button ID="Button5" CssClass="btn btn-primary" OnClick="Button5_Click" runat="server" Text="View" Width="150px" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="masterid" Visible="false">
                                                            <ItemTemplate>
                                                                <asp:Label ID="Label3" runat="server" Text='<%#Eval("IncentiveTypID") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Left" />
                                                        </asp:TemplateField>
                                                    </Columns>
                                                    <PagerStyle BackColor="#013161" ForeColor="White" HorizontalAlign="Center" />
                                                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                                    <HeaderStyle BackColor="#1d9a5b" CssClass="GRDHEADER" Font-Bold="True" ForeColor="White" />
                                                    <EditRowStyle BackColor="#B9D684" />
                                                    <AlternatingRowStyle BackColor="White" />
                                                </asp:GridView>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="padding: 15px; margin: 5px; font-weight: bold;"></td>
                                        <td style="padding: 5px; margin: 5px; width: 900px; font-weight: bold;">C). General
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="padding: 15px; margin: 5px;"></td>
                                        <td style="padding: 5px; margin: 5px; width: 100%" valign="top" colspan="2">
                                            <div style="width: 100%">
                                                <asp:GridView ID="gvGeneralST" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                                    CssClass="GRD" ForeColor="#333333" Height="62px"
                                                    PageSize="15" ShowFooter="false" Width="80%" CellSpacing="4">
                                                    <FooterStyle BackColor="#be8c2f" Font-Bold="True" ForeColor="White" />
                                                    <RowStyle BackColor="#EBF2FE" CssClass="GRDITEM" HorizontalAlign="Left" VerticalAlign="Middle" />
                                                    <Columns>
                                                        <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S No">
                                                            <ItemTemplate>
                                                                <%# Container.DataItemIndex + 1%>
                                                                <asp:HiddenField ID="HdfQueid" runat="server" />
                                                                <asp:HiddenField ID="HdfApprovalid" runat="server" />
                                                                <asp:HiddenField ID="HdfDeptid" runat="server" />
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <ItemStyle Width="50px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="Incentive Name">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblince" runat="server" Text='<%#Eval("IncentiveName") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Left" Width="400px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="Count">
                                                            <ItemTemplate>
                                                                <asp:Label ID="hSLCNumber" runat="server" Text='<%#Eval("Noincentives") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Left" />
                                                        </asp:TemplateField>
                                                       
                                                        <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="Sanctioned Amount">
                                                            <ItemTemplate>
                                                                <asp:Label ID="txtsanctionedamount" Text='<%#Eval("valueamount") %>' runat="server"></asp:Label>
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Left" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="View">
                                                            <ItemTemplate>
                                                                <asp:Button ID="Button6" CssClass="btn btn-primary" OnClick="Button6_Click" runat="server" Text="View" Width="150px" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="masterid" Visible="false">
                                                            <ItemTemplate>
                                                                <asp:Label ID="Label3" runat="server" Text='<%#Eval("IncentiveTypID") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Left" />
                                                        </asp:TemplateField>
                                                    </Columns>
                                                    <PagerStyle BackColor="#013161" ForeColor="White" HorizontalAlign="Center" />
                                                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                                    <HeaderStyle BackColor="#1d9a5b" CssClass="GRDHEADER" Font-Bold="True" ForeColor="White" />
                                                    <EditRowStyle BackColor="#B9D684" />
                                                    <AlternatingRowStyle BackColor="White" />
                                                </asp:GridView>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="padding: 15px; margin: 5px; font-weight: bold;">3.
                                        </td>
                                        <td style="padding: 5px; margin: 5px; width: 900px; text-align: left; font-weight: bold; font-size: 14pt">General Category
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="padding: 15px; margin: 5px;"></td>
                                        <td style="padding: 5px; margin: 5px; width: 900px; font-weight: bold;">A). Pavalla vaddi
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="padding: 15px; margin: 5px;"></td>
                                        <td style="padding: 5px; margin: 5px; width: 100%" valign="top" colspan="2">
                                            <div style="width: 100%">
                                                <asp:GridView ID="gvPavallavaddiGeneral" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                                    CssClass="GRD" ForeColor="#333333" Height="62px"
                                                    PageSize="15" ShowFooter="false" Width="80%" CellSpacing="4">
                                                    <FooterStyle BackColor="#be8c2f" Font-Bold="True" ForeColor="White" />
                                                    <RowStyle BackColor="#EBF2FE" CssClass="GRDITEM" HorizontalAlign="Left" VerticalAlign="Middle" />
                                                    <Columns>
                                                        <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S No">
                                                            <ItemTemplate>
                                                                <%# Container.DataItemIndex + 1%>
                                                                <asp:HiddenField ID="HdfQueid" runat="server" />
                                                                <asp:HiddenField ID="HdfApprovalid" runat="server" />
                                                                <asp:HiddenField ID="HdfDeptid" runat="server" />
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <ItemStyle Width="50px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="Incentive Name">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblince" runat="server" Text='<%#Eval("IncentiveName") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Left" Width="400px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="Count">
                                                            <ItemTemplate>
                                                                <asp:Label ID="hSLCNumber" runat="server" Text='<%#Eval("Noincentives") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Left" />
                                                        </asp:TemplateField>
                                                     
                                                        <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="Sanctioned Amount">
                                                            <ItemTemplate>
                                                                <asp:Label ID="txtsanctionedamount" Text='<%#Eval("valueamount") %>' runat="server"></asp:Label>
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Left" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="View">
                                                            <ItemTemplate>
                                                                <asp:Button ID="Button7" CssClass="btn btn-primary" OnClick="Button7_Click" runat="server" Text="View" Width="150px" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="masterid" Visible="false">
                                                            <ItemTemplate>
                                                                <asp:Label ID="Label3" runat="server" Text='<%#Eval("IncentiveTypID") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Left" />
                                                        </asp:TemplateField>
                                                    </Columns>
                                                    <PagerStyle BackColor="#013161" ForeColor="White" HorizontalAlign="Center" />
                                                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                                    <HeaderStyle BackColor="#1d9a5b" CssClass="GRDHEADER" Font-Bold="True" ForeColor="White" />
                                                    <EditRowStyle BackColor="#B9D684" />
                                                    <AlternatingRowStyle BackColor="White" />
                                                </asp:GridView>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="padding: 15px; margin: 5px; font-weight: bold;"></td>
                                        <td style="padding: 5px; margin: 5px; width: 900px; font-weight: bold;">B). Investment Subsidy
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="padding: 15px; margin: 5px;"></td>
                                        <td style="padding: 5px; margin: 5px; width: 100%" valign="top" colspan="2">
                                            <div style="width: 100%">
                                                <asp:GridView ID="gvInvestmentSubsidyGeneral" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                                    CssClass="GRD" ForeColor="#333333" Height="62px"
                                                    PageSize="15" ShowFooter="false" Width="80%" CellSpacing="4">
                                                    <FooterStyle BackColor="#be8c2f" Font-Bold="True" ForeColor="White" />
                                                    <RowStyle BackColor="#EBF2FE" CssClass="GRDITEM" HorizontalAlign="Left" VerticalAlign="Middle" />
                                                    <Columns>
                                                        <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S No">
                                                            <ItemTemplate>
                                                                <%# Container.DataItemIndex + 1%>
                                                                <asp:HiddenField ID="HdfQueid" runat="server" />
                                                                <asp:HiddenField ID="HdfApprovalid" runat="server" />
                                                                <asp:HiddenField ID="HdfDeptid" runat="server" />
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <ItemStyle Width="50px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="Incentive Name">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblince" runat="server" Text='<%#Eval("IncentiveName") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Left" Width="400px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="Count">
                                                            <ItemTemplate>
                                                                <asp:Label ID="hSLCNumber" runat="server" Text='<%#Eval("Noincentives") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Left" />
                                                        </asp:TemplateField>
                                                    
                                                        <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="Sanctioned Amount">
                                                            <ItemTemplate>
                                                                <asp:Label ID="txtsanctionedamount" Text='<%#Eval("valueamount") %>' runat="server"></asp:Label>
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Left" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="View">
                                                            <ItemTemplate>
                                                                <asp:Button ID="Button8" CssClass="btn btn-primary" OnClick="Button8_Click" runat="server" Text="View" Width="150px" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="masterid" Visible="false">
                                                            <ItemTemplate>
                                                                <asp:Label ID="Label3" runat="server" Text='<%#Eval("IncentiveTypID") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Left" />
                                                        </asp:TemplateField>
                                                    </Columns>
                                                    <PagerStyle BackColor="#013161" ForeColor="White" HorizontalAlign="Center" />
                                                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                                    <HeaderStyle BackColor="#1d9a5b" CssClass="GRDHEADER" Font-Bold="True" ForeColor="White" />
                                                    <EditRowStyle BackColor="#B9D684" />
                                                    <AlternatingRowStyle BackColor="White" />
                                                </asp:GridView>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="padding: 15px; margin: 5px; font-weight: bold;"></td>
                                        <td style="padding: 5px; margin: 5px; width: 900px; font-weight: bold;">C). General
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="padding: 15px; margin: 5px;"></td>
                                        <td style="padding: 5px; margin: 5px; width: 100%" valign="top" colspan="2">
                                            <div style="width: 100%">
                                                <asp:GridView ID="gvGeneralGeneral" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                                    CssClass="GRD" ForeColor="#333333" Height="62px"
                                                    PageSize="15" ShowFooter="false" Width="80%" CellSpacing="4">
                                                    <FooterStyle BackColor="#be8c2f" Font-Bold="True" ForeColor="White" />
                                                    <RowStyle BackColor="#EBF2FE" CssClass="GRDITEM" HorizontalAlign="Left" VerticalAlign="Middle" />
                                                    <Columns>
                                                        <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S No">
                                                            <ItemTemplate>
                                                                <%# Container.DataItemIndex + 1%>
                                                                <asp:HiddenField ID="HdfQueid" runat="server" />
                                                                <asp:HiddenField ID="HdfApprovalid" runat="server" />
                                                                <asp:HiddenField ID="HdfDeptid" runat="server" />
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <ItemStyle Width="50px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="Incentive Name">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblince" runat="server" Text='<%#Eval("IncentiveName") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Left" Width="400px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="Count">
                                                            <ItemTemplate>
                                                                <asp:Label ID="hSLCNumber" runat="server" Text='<%#Eval("Noincentives") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Left" />
                                                        </asp:TemplateField>
                                                      
                                                        <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="Sanctioned Amount">
                                                            <ItemTemplate>
                                                                <asp:Label ID="txtsanctionedamount" Text='<%#Eval("valueamount") %>' runat="server"></asp:Label>
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Left" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="View">
                                                            <ItemTemplate>
                                                                <asp:Button ID="Button9" CssClass="btn btn-primary" OnClick="Button9_Click" runat="server" Text="View" Width="150px" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="masterid" Visible="false">
                                                            <ItemTemplate>
                                                                <asp:Label ID="Label3" runat="server" Text='<%#Eval("IncentiveTypID") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Left" />
                                                        </asp:TemplateField>
                                                    </Columns>
                                                    <PagerStyle BackColor="#013161" ForeColor="White" HorizontalAlign="Center" />
                                                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                                    <HeaderStyle BackColor="#1d9a5b" CssClass="GRDHEADER" Font-Bold="True" ForeColor="White" />
                                                    <EditRowStyle BackColor="#B9D684" />
                                                    <AlternatingRowStyle BackColor="White" />
                                                </asp:GridView>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                            <asp:HiddenField ID="hdfID" runat="server" />
                                            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
                                                ShowSummary="False" ValidationGroup="group" />
                                            <asp:ValidationSummary ID="ValidationSummary2" runat="server" ShowMessageBox="True"
                                                ShowSummary="False" ValidationGroup="child" />
                                            <asp:HiddenField ID="hdfFlagID" runat="server" />
                                        </td>
                                    </tr>--%>
                                </table>

                            </div>

                            <%--   </div>--%>
                        </td>
                    </tr>
                    <tr>
                        <td align="center" style="padding: 5px; margin: 5px; text-align: center;">&nbsp;&nbsp;&nbsp;</td>
                    </tr>

                    <tr>
                        <td style="padding: 5px; margin: 5px" align="center" class="style7"></td>
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
            </div>

        </div>
    </div>


    <div style="text-align: center" id="divbtnprint" runat="server">
        <asp:Button ID="btnprint" runat="server" Height="32px" CausesValidation="False" Width="90px"
            CssClass="btn btn-warning" UseSubmitBehavior="False" Text="Print " OnClientClick="javascript:CallPrint('divprint');return false;" />
        <br />
        <br />
    </div>



    <script type="text/javascript">
        function CallPrint(strid) {
            var prtContent = document.getElementById(strid);
            var WinPrint = window.open('', '', 'letf=0,top=0,width=0,height=0,toolbar=0,scrollbars=1,status=0');
            var strOldOne = prtContent.innerHTML;
            WinPrint.document.write(prtContent.innerHTML);
            WinPrint.document.close();
            WinPrint.focus();
            WinPrint.print();
            WinPrint.close();
            prtContent.innerHTML = strOldOne;
        }
    </script>
    <%--<asp:updateprogress id="UpdateProgress" runat="server" associatedupdatepanelid="UpdatePanel1">
        <ProgressTemplate>
            <div class="update">
            </div>
        </ProgressTemplate>
    </asp:updateprogress>--%>
</asp:Content>

