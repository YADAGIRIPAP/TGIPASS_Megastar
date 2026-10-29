<%@ Page Title="" Language="C#" MasterPageFile="~/UI/TSIPASS/CCMaster.master" AutoEventWireup="true"
    CodeFile="ApplicationSolution.aspx.cs" Inherits="UI_TSIPASS_ApplicationSolution" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <link href="Styles/GridViewStyles.css" rel="stylesheet" />
    <link href="Styles/StyleSheet.css" rel="stylesheet" />
    <link href="Styles/ui.jqgrid-bootstrap-ui.css" rel="stylesheet" />
    <link href="Styles/ui.jqgrid-bootstrap.css" rel="stylesheet" />
    <link href="Styles/ui.jqgrid.css" rel="stylesheet" />
    <style>
        /* The Modal (background) */
        .modal
        {
            display: none; /* Hidden by default */
            position: fixed; /* Stay in place */
            z-index: 10001; /* Sit on top */
            padding-top: 100px; /* Location of the box */
            left: 0;
            top: 0;
            width: 100%; /* Full width */
            height: 100%; /* Full height */
            overflow: auto; /* Enable scroll if needed */
            background-color: rgb(0,0,0); /* Fallback color */
            background-color: rgba(0,0,0,0.7); /* Black w/ opacity */
        }
        
        .page-head-linenew
        {
            font-size: 2px;
            text-transform: uppercase;
            color: #000;
            font-weight: 800;
            padding-bottom: 2px;
            border-bottom: 4px solid #00CA79;
            margin-bottom: 35px;
        }
        /* Modal Content */
        .modal-content
        {
            background-color: #fefefe;
            margin: auto;
            padding: 20px;
            border: 1px solid #888;
            width: 80%;
            min-height: 450px;
        }
        
        /* The Close Button */
        .close
        {
            color: #aaaaaa;
            float: right;
            font-size: 28px;
            font-weight: bold;
        }
        
        .close:hover, .close:focus
        {
            color: #000;
            text-decoration: none;
            cursor: pointer;
        }
    </style>
    <style>
        .Grid
        {
            background-color: #fff;
            margin: 5px 0 10px 0;
            border: solid 1px #525252;
            border-collapse: collapse;
            font-family: Calibri;
            color: #474747;
        }
        
        .Grid td
        {
            padding: 2px;
            border: solid 1px #c1c1c1;
        }
        
        .Grid th
        {
            padding: 4px 2px;
            color: #fff;
            background: #363670 url(Images/grid-header.png) repeat-x top;
            border-left: solid 1px #525252;
            font-size: 0.9em;
        }
        
        .Grid .alt
        {
            background: #fcfcfc url(Images/grid-alt.png) repeat-x top;
        }
        
        .Grid .pgr
        {
            background: #363670 url(Images/grid-pgr.png) repeat-x top;
        }
        
        .Grid .pgr table
        {
            margin: 3px 0;
        }
        
        .Grid .pgr td
        {
            border-width: 0;
            padding: 0 6px;
            border-left: solid 1px #666;
            font-weight: bold;
            color: #fff;
            line-height: 12px;
        }
        
        .Grid .pgr a
        {
            color: Gray;
            text-decoration: none;
        }
        
        .Grid .pgr a:hover
        {
            color: #000;
            text-decoration: none;
        }
    </style>
    <style type="text/css">
        .update
        {
            position: fixed;
            top: 0px;
            left: 0px;
            min-height: 100%;
            min-width: 100%;
            background-image: url("../../Images/ajax-loaderblack.gif"); /*background-image: url("Images/spinner_60.gif");*/
            background-position: center center;
            background-repeat: no-repeat; /*background-color: #e4e4e6;*/
            background-color: #535252;
            z-index: 500 !important;
            opacity: 0.6;
            overflow: hidden;
        }
        
        .tital
        {
            font-size: 14px;
            font-weight: 500;
        }
        
        .bot-border
        {
            border-bottom: 1px #f8f8f8 solid;
            margin: 5px 0 5px 0;
        }
        
        .table-user-information > tbody > tr
        {
            border-top: 1px solid rgb(221, 221, 221);
        }
        
        .table-user-information > tbody > tr:first-child
        {
            border-top: 0;
        }
        
        
        .table-user-information > tbody > tr > td
        {
            border-top: 0;
        }
    </style>
    <script type="text/javascript">
        $(function () {

            $('#MstLftMenu').remove();

        });
    </script>
    <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
        <ProgressTemplate>
            <div class="update">
            </div>
        </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <Triggers>
            <asp:PostBackTrigger ControlID="BtnSave3" />
            <asp:PostBackTrigger ControlID="btncfeactionclick" />
        </Triggers>
        <ContentTemplate>
            <%--  <table style="width: 100%; margin: auto; text-align: center">
                <tr>
                    <td>
                        <h3>HELP DESK SOLUTION</h3>
                    </td>
                </tr>
                <tr>
                    <td></td>
                </tr>
            </table>--%>
            <div class="container-fluid">
                <div class="row" style="margin-top: 25px; margin-bottom: 0px;">
                    <div class="col-md-offset-4">
                        <div class="form-group form-inline">
                            <label for="selType">
                                <h5>
                                    Application Type:</h5>
                            </label>
                            <asp:DropDownList ID="ddlModule" class="form-control" runat="server" AutoPostBack="True"
                                OnSelectedIndexChanged="ddlModule_SelectedIndexChanged">
                                <asp:ListItem Value="0">Select</asp:ListItem>
                                <asp:ListItem Value="1">Incentives</asp:ListItem>
                                <asp:ListItem Value="2">CFE</asp:ListItem>
                                <asp:ListItem Value="3">CFO</asp:ListItem>
                                <asp:ListItem Value="4">UPdate All Cfe and CFO Payment Dtls</asp:ListItem>
                                <asp:ListItem Value="5">UPdate - Cfe Failed Applications </asp:ListItem>
                                <asp:ListItem Value="6">UPdate - Cfo Failed Applications </asp:ListItem>
                                <asp:ListItem Value="7">UPdate - Ren Failed Applications </asp:ListItem>
                                <asp:ListItem Value="8">UPdate - TSiicplot Failed Applications </asp:ListItem>
                                <asp:ListItem Value="9">UPdate - Failed Payments Update by CCAVENNUE number </asp:ListItem>
                                  <asp:ListItem Value="10">UPdate - BMW Failed Applications </asp:ListItem>
                                <asp:ListItem Value="11">UPdate - Failed Payments Update by Date </asp:ListItem>
                                <asp:ListItem Value="12">Update Failed Attachments </asp:ListItem>

                            </asp:DropDownList>
                        </div>
                    </div>
                </div>
                <div class="row" id="DivInc" runat="server" visible="false">
                    <div class="col-md-12">
                        <h3>
                            Search</h3>
                        <div class="row">
                            <div class="col-md-3">
                                <div class="form-group">
                                    <label for="inputdefault">
                                        IncentiveId</label>
                                    <asp:TextBox ID="inputIncId" runat="server"></asp:TextBox>
                                    <%--<asp:TextBox class="form-control" id="inputIncId" type="text"></asp:TextBox>--%>
                                </div>
                            </div>
                            <div class="col-md-3">
                                <div class="form-group">
                                    <label for="inputdefault">
                                        Unit Name</label>
                                    <asp:TextBox ID="inputUnit" runat="server"></asp:TextBox>
                                    <%--  <input class="form-control" id="inputUnit" type="text">--%>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="form-group">
                                    <label for="selDist">
                                        District</label>
                                    <asp:DropDownList ID="selDist" Style="width: 239px; height: 28px;" runat="server"
                                        TabIndex="1">
                                        <asp:ListItem Value="0">Select</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="col-md-2">
                                <%--<input type="button" id="btnSearch" class="btn btn-success" style="margin-top: 0px;" value="Search" />--%>
                                <asp:Button ID="btnSearch" runat="server" class="btn btn-success" Text="Search" OnClick="btnSearch_Click" />
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-12">
                                <div id="tblinclist" runat="server" visible="false">
                                    <div>
                                        <h1 class="page-head-linenew" align="left" style="font-size: smaller">
                                        </h1>
                                    </div>
                                    <%--  <table id="datatable" class="datatable table-responsive table-hover text-center table table-striped table-bordered hidden">
                                        <thead>
                                            <tr>
                                                <th class="text-center">IncentiveId</th>
                                                <th class="text-center">Unit name</th>
                                                <th class="text-center">District</th>
                                                <th class="text-center">Application Filed Date</th>
                                                <th class="text-center"></th>
                                                <th class="text-center"></th>
                                            </tr>
                                        </thead>
                                    </table>--%>
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
                                                    <asp:Label ID="lblmonth" runat="server" Text='<%# Eval("IncentveID") %>' Visible="false"></asp:Label>
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Center" />
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="UnitName" HeaderText="Unit Name"></asp:BoundField>
                                            <asp:BoundField DataField="District_Name" HeaderText="District Name"></asp:BoundField>
                                            <asp:BoundField DataField="IncentiveName" HeaderText="Name of Claim"></asp:BoundField>
                                            <asp:BoundField DataField="ApplicationFiledDate" HeaderText="Application Filed Date">
                                            </asp:BoundField>
                                            <asp:TemplateField HeaderText="Process" ItemStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <asp:Button ID="btnstatus" runat="server" Text="Process" CssClass="btn btn-primary"
                                                        OnClick="anchortaglink_Click"></asp:Button>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Incentiveid" Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblEnterperIncentiveID" Text='<%#Eval("EnterperIncentiveID") %>' runat="server" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="CLAIMIncentiveidS" Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblMstIncentiveId" Text='<%#Eval("MstIncentiveId") %>' runat="server" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="SLCorDLC" Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblSLCorDLC" Text='<%#Eval("SLCorDLC") %>' runat="server" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="row" id="DivCfe" runat="server" visible="false">
                    <div class="col-md-12">
                        <h3>
                            Search</h3>
                        <div class="row">
                            <div class="col-md-3">
                                <div class="form-group">
                                    <label for="inputdefault">
                                        UID No</label>
                                    <asp:TextBox ID="txtUidNo" runat="server"></asp:TextBox>
                                    <%--<asp:TextBox class="form-control" id="inputIncId" type="text"></asp:TextBox>--%>
                                </div>
                            </div>
                            <div class="col-md-3">
                                <div class="form-group">
                                    <label for="inputdefault">
                                        Unit Name</label>
                                    <asp:TextBox ID="txtunitname" runat="server"></asp:TextBox>
                                    <%--  <input class="form-control" id="inputUnit" type="text">--%>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="form-group">
                                    <label for="selDist">
                                        CFE ID</label>
                                    <asp:TextBox ID="txtcfeid" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-2">
                                <%--<input type="button" id="btnSearch" class="btn btn-success" style="margin-top: 0px;" value="Search" />--%>
                                <asp:Button ID="btncfesearch" runat="server" class="btn btn-success" Text="Search"
                                    OnClick="btncfesearch_Click" />
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-12">
                                <div id="Divserchcfedata" runat="server" visible="false">
                                    <div>
                                        <h1 class="page-head-linenew" align="left" style="font-size: smaller">
                                        </h1>
                                    </div>
                                    <asp:GridView ID="grdDetailsMain" runat="server" AllowPaging="False" AutoGenerateColumns="false"
                                        CellPadding="5" ForeColor="#333333" Height="62px" ShowFooter="false" Width="100%">
                                        <HeaderStyle ForeColor="#FFFFFF" BackColor="#009688" Height="40px" CssClass="GridviewScrollC1HeaderWrap" />
                                        <RowStyle Height="40px" CssClass="GridviewScrollC1Item" />
                                        <PagerStyle CssClass="GridviewScrollC1Pager" />
                                        <FooterStyle ForeColor="#FFFFFF" BackColor="#009688" Height="40px" CssClass="GridviewScrollC1Footer" />
                                        <AlternatingRowStyle Height="40px" CssClass="GridviewScrollC1Item2" />
                                        <Columns>
                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S No">
                                                <ItemTemplate>
                                                    <%# Container.DataItemIndex + 1%>
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <ItemStyle Width="50px" />
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="UID" HeaderText="UID"></asp:BoundField>
                                            <asp:BoundField DataField="Name of the Industry" HeaderText="Name of the Industry">
                                            </asp:BoundField>
                                            <asp:BoundField DataField="Activity Proposed" HeaderText="Activity Proposed"></asp:BoundField>
                                            <asp:BoundField DataField="Line of Activity" HeaderText="Line of Activity"></asp:BoundField>
                                            <asp:BoundField DataField="Total Investment (in Crores)" HeaderText="Total Investment (in Crores)">
                                            </asp:BoundField>
                                            <asp:BoundField DataField="Date of application" HeaderText="Date of application">
                                            </asp:BoundField>
                                            <asp:TemplateField HeaderText="Process">
                                                <ItemTemplate>
                                                    <asp:Button ID="btncfeprocess" runat="server" Text="Process" CssClass="btn btn-primary"
                                                        OnClick="btncfeprocess_Click"></asp:Button>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="intQuessionaireid" Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblintQuessionaireid" Text='<%#Eval("intQuessionaireid") %>' runat="server" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="CREATEDBY" Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblCREATEDBY" Text='<%#Eval("CREATEDBY") %>' runat="server" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                        <PagerStyle BackColor="#013161" ForeColor="White" HorizontalAlign="Center" />
                                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                        <HeaderStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                        <EditRowStyle BackColor="#B9D684" />
                                        <AlternatingRowStyle BackColor="White" />
                                    </asp:GridView>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="row hidden" id="DivCfo" runat="server">
                    <div class="col-md-12">
                    </div>
                </div>
                <div class="row" id="divcfefailedwebservices" runat="server" visible="false">
                    <div class="col-md-12">
                        <div class="form-group">
                            <asp:GridView ID="gvcfefaileddata" runat="server" AutoGenerateColumns="False" CellPadding="4"
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
                                    <asp:TemplateField HeaderText="">
                                        <ItemTemplate>
                                            <asp:CheckBox ID="chkcheckapps" runat="server" Checked="true" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="UIDNO" HeaderText="UIDNO"></asp:BoundField>
                                    <asp:BoundField DataField="NAMEOFUNIT" HeaderText="Unit Name"></asp:BoundField>
                                    <asp:BoundField DataField="DEPARTMENTNAME" HeaderText="Approval Name"></asp:BoundField>
                                    <asp:BoundField DataField="PAYMENTDATE" HeaderText="Date of Payment"></asp:BoundField>
                                    <asp:BoundField DataField="DEPARTMENTUPDATEDATE" HeaderText="Last Run Date"></asp:BoundField>
                                    <asp:BoundField DataField="INTSTAGE" HeaderText="Application Status"></asp:BoundField>
                                    <asp:BoundField DataField="STATUS" HeaderText="Update Status"></asp:BoundField>
                                    <asp:TemplateField HeaderText="INTQUESTIONNAIREID" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblINTQUESTIONNAIREID" Text='<%#Eval("INTQUESTIONNAIREID") %>' runat="server" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="INTAPPROVALID" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lbINTAPPROVALID" Text='<%#Eval("INTAPPROVALID") %>' runat="server" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="UIDNO" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblUIDNO" Text='<%#Eval("UIDNO") %>' runat="server" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </div>
                    </div>
                    <div class="row" runat="server" visible="false" id="divbtnupdatecfe">
                        <div class="col-md-12">
                            <div class="form-group" style="padding-left: 50%">
                                <%--<input type="button" value="Process" id="btnAction" class="btn btn-success" />--%>
                                <asp:Button ID="btnupdate" runat="server" Text="Process" class="btn btn-success"
                                    OnClick="btnupdate_Click" />
                            </div>
                        </div>
                    </div>
                </div>
                <div class="row" id="divcfofailedwebservices" runat="server" visible="false">
                    <div class="col-md-12">
                        <div class="form-group">
                            <asp:GridView ID="gvcfofaileddata" runat="server" AutoGenerateColumns="False" CellPadding="4"
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
                                    <asp:TemplateField HeaderText="">
                                        <ItemTemplate>
                                            <asp:CheckBox ID="chkcheckapps" runat="server" Checked="true" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="UIDNO" HeaderText="UIDNO"></asp:BoundField>
                                    <asp:BoundField DataField="NAMEOFUNIT" HeaderText="Unit Name"></asp:BoundField>
                                    <asp:BoundField DataField="DEPARTMENTNAME" HeaderText="Approval Name"></asp:BoundField>
                                    <asp:BoundField DataField="PAYMENTDATE" HeaderText="Date of Payment"></asp:BoundField>
                                    <asp:BoundField DataField="DEPARTMENTUPDATEDATE" HeaderText="Last Run Date"></asp:BoundField>
                                    <asp:BoundField DataField="INTSTAGE" HeaderText="Application Status"></asp:BoundField>
                                    <asp:BoundField DataField="STATUS" HeaderText="Update Status"></asp:BoundField>
                                    <asp:TemplateField HeaderText="INTQUESTIONNAIREID" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblINTQUESTIONNAIREID" Text='<%#Eval("INTQUESTIONNAIREID") %>' runat="server" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="INTAPPROVALID" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lbINTAPPROVALID" Text='<%#Eval("INTAPPROVALID") %>' runat="server" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="UIDNO" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblUIDNO" Text='<%#Eval("UIDNO") %>' runat="server" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </div>
                    </div>
                    <div class="row" runat="server" visible="false" id="divbtnupdatecfo">
                        <div class="col-md-12">
                            <div class="form-group" style="padding-left: 50%">
                                <%--<input type="button" value="Process" id="btnAction" class="btn btn-success" />--%>
                                <asp:Button ID="btnupdatecfo" runat="server" Text="Process" class="btn btn-success"
                                    OnClick="btnupdatecfo_Click" />
                            </div>
                        </div>
                    </div>
                </div>
                <div class="row" id="divRenfailedwebservices" runat="server" visible="false">
                    <div class="col-md-12">
                        <div class="form-group">
                            <asp:GridView ID="gvrenfaileddata" runat="server" AutoGenerateColumns="False" CellPadding="4"
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
                                    <asp:TemplateField HeaderText="">
                                        <ItemTemplate>
                                            <asp:CheckBox ID="chkcheckapps" runat="server" Checked="true" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="UIDNO" HeaderText="UIDNO"></asp:BoundField>
                                    <asp:BoundField DataField="NAMEOFUNIT" HeaderText="Unit Name"></asp:BoundField>
                                    <asp:BoundField DataField="DEPARTMENTNAME" HeaderText="Approval Name"></asp:BoundField>
                                    <asp:BoundField DataField="PAYMENTDATE" HeaderText="Date of Payment"></asp:BoundField>
                                    <asp:BoundField DataField="DEPARTMENTUPDATEDATE" HeaderText="Last Run Date"></asp:BoundField>
                                    <asp:BoundField DataField="INTSTAGE" HeaderText="Application Status"></asp:BoundField>
                                    <asp:BoundField DataField="STATUS" HeaderText="Update Status"></asp:BoundField>
                                    <asp:TemplateField HeaderText="INTQUESTIONNAIREID" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblINTQUESTIONNAIREID" Text='<%#Eval("INTQUESTIONNAIREID") %>' runat="server" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="INTAPPROVALID" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lbINTAPPROVALID" Text='<%#Eval("INTAPPROVALID") %>' runat="server" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="UIDNO" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblUIDNO" Text='<%#Eval("UIDNO") %>' runat="server" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </div>
                    </div>
                    <div class="row" runat="server" visible="false" id="divbtnupdateren">
                        <div class="col-md-12">
                            <div class="form-group" style="padding-left: 50%">
                                <%--<input type="button" value="Process" id="btnAction" class="btn btn-success" />--%>
                                <asp:Button ID="btnupdateRen" runat="server" Text="Process" class="btn btn-success"
                                    OnClick="btnupdateRen_Click" />
                            </div>
                        </div>
                    </div>
                </div>
                <div class="row" id="divplottsiicfailedservice" runat="server" visible="false">
                    <div class="col-md-12">
                        <div class="form-group">
                            <asp:GridView ID="grdtsiic" runat="server" AutoGenerateColumns="False" CellPadding="4"
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
                                    <asp:TemplateField HeaderText="">
                                        <ItemTemplate>
                                            <asp:CheckBox ID="chkcheckapps" runat="server" Checked="true" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="UIDNO" HeaderText="UIDNO"></asp:BoundField>
                                    <asp:BoundField DataField="NameOftheFirm_Applicant" HeaderText="Unit Name"></asp:BoundField>
                                    <asp:BoundField DataField="ApprovalName" HeaderText="Approval Name"></asp:BoundField>
                                    <asp:BoundField DataField="PAYMENTDATE" HeaderText="Date of Payment"></asp:BoundField>
                                    <asp:BoundField DataField="DEPARTMENTUPDATEDATE" HeaderText="Last Run Date"></asp:BoundField>
                                    <asp:BoundField DataField="ResponseOutput" HeaderText="Application Status"></asp:BoundField>
                                    <asp:BoundField DataField="Updatedflag" HeaderText="Update Status"></asp:BoundField>
                                    <asp:TemplateField HeaderText="INTQUESTIONNAIREID" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblINTQUESTIONNAIREID" Text='<%#Eval("appid") %>' runat="server" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="INTAPPROVALID" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lbINTAPPROVALID" Text='<%#Eval("createdby") %>' runat="server" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="UIDNO" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblUIDNO" Text='<%#Eval("UIDNO") %>' runat="server" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </div>
                    </div>
                    <div class="row" runat="server" visible="false" id="divtsiicupdate">
                        <div class="col-md-12">
                            <div class="form-group" style="padding-left: 50%">
                                <%--<input type="button" value="Process" id="btnAction" class="btn btn-success" />--%>
                                <asp:Button ID="btnupdatetsiic" runat="server" Text="Process" class="btn btn-success"
                                    OnClick="btnupdatetsiic_Click" />
                            </div>
                        </div>
                    </div>

                    
                </div>
                  <div class="row" id="divBMWfailedwebservices" runat="server" visible="false">
                        <div class="col-md-12">
                            <div class="form-group">
                                <asp:GridView ID="gvBMWfaileddata" runat="server" AutoGenerateColumns="False" CellPadding="4"
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
                                        <asp:TemplateField HeaderText="">
                                            <ItemTemplate>
                                                <asp:CheckBox ID="chkcheckapps" runat="server" Checked="true" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="UIDNO" HeaderText="UIDNO"></asp:BoundField>
                                        <asp:BoundField DataField="NAMEOFUNIT" HeaderText="Unit Name"></asp:BoundField>
                                        <asp:BoundField DataField="DEPARTMENTNAME" HeaderText="Approval Name"></asp:BoundField>
                                        <asp:BoundField DataField="PAYMENTDATE" HeaderText="Date of Payment"></asp:BoundField>
                                        <asp:BoundField DataField="DEPARTMENTUPDATEDATE" HeaderText="Last Run Date"></asp:BoundField>
                                        <asp:BoundField DataField="INTSTAGE" HeaderText="Application Status"></asp:BoundField>
                                        <asp:BoundField DataField="STATUS" HeaderText="Update Status"></asp:BoundField>
                                        <asp:TemplateField HeaderText="INTQUESTIONNAIREID" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblINTQUESTIONNAIREID" Text='<%#Eval("INTQUESTIONNAIREID") %>' runat="server" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="INTAPPROVALID" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lbINTAPPROVALID" Text='<%#Eval("INTAPPROVALID") %>' runat="server" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="UIDNO" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblUIDNO" Text='<%#Eval("UIDNO") %>' runat="server" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </div>
                        <div class="row" runat="server" visible="false" id="divbtnupdateBMW">
                            <div class="col-md-12">
                                <div class="form-group" style="padding-left: 50%">
                                    <%--<input type="button" value="Process" id="btnAction" class="btn btn-success" />--%>
                                    <asp:Button ID="btnupdateBMW" runat="server" Text="Process" class="btn btn-success"
                                        OnClick="btnupdateBMW_Click" />
                                </div>
                            </div>
                        </div>
                    </div>
            </div>
            <div class="container-fluid" runat="server" id="viewData" visible="false">
                <div class="row">
                    <div class="col-md-12">
                        <h1 class="page-head-linenew" align="left" style="font-size: smaller">
                        </h1>
                    </div>
                    <div class="col-md-10">
                        <table class="table">
                            <tr>
                                <td>
                                    Application Date :
                                </td>
                                <td id="tdApplicationDate" runat="server">
                                </td>
                                <td>
                                    Application No :
                                </td>
                                <td id="tdApplicationNo" runat="server">
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Unit Name :
                                </td>
                                <td id="tdUnitName" runat="server">
                                </td>
                                <td>
                                    Applicant Name :
                                </td>
                                <td id="tdApplicantName" runat="server">
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Sector :
                                </td>
                                <td id="tdSector" runat="server">
                                </td>
                                <td>
                                    Social Status :
                                </td>
                                <td id="tdSocialStatus" runat="server">
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Category :
                                </td>
                                <td id="tdCategory" runat="server">
                                </td>
                                <td>
                                    DCP :
                                </td>
                                <td id="tdDCP" runat="server">
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    District :
                                </td>
                                <td id="tdUnitDistName" runat="server">
                                </td>
                                <td>
                                    Mandal :
                                </td>
                                <td id="tdMandal" runat="server">
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Village:
                                </td>
                                <td id="tdVillage" runat="server">
                                </td>
                                <td>
                                    Mobile :
                                </td>
                                <td id="tdMobile" runat="server">
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Email :
                                </td>
                                <td runat="server" id="tdEmail">
                                </td>
                                <td>
                                </td>
                                <td>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                </td>
                                <td>
                                </td>
                                <td>
                                </td>
                                <td>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div class="col-md-10">
                        <h4>
                            Applied Incentive</h4>
                        <asp:GridView ID="gvdeatilsincentives" runat="server" AutoGenerateColumns="false"
                            CellPadding="4" Width="100%" ShowFooter="false">
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
                                <asp:BoundField DataField="IncentiveName" HeaderText="Incentive Name"></asp:BoundField>
                                <asp:BoundField DataField="dateperiod" HeaderText="Time peroid"></asp:BoundField>
                                <asp:BoundField DataField="nameofStage" HeaderText="Present status"></asp:BoundField>
                                <asp:BoundField DataField="Amount" HeaderText="Amount Recommended"></asp:BoundField>
                                <asp:TemplateField HeaderText="SLCorDLC" Visible="false">
                                    <ItemTemplate>
                                        <asp:Label ID="lblSLCorDLC" Text='<%#Eval("SLCorDLC") %>' runat="server" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </div>
                    <div class="col-md-12">
                        <h1 class="page-head-linenew" align="left" style="font-size: smaller">
                        </h1>
                    </div>
                </div>
            </div>
            <%--    <div id="myModal" class="modal">
                <div class="modal-content">
                    <span class="close">&times;</span>
                    <div id="ModalBody"></div>
                    <div class="row">
                        <div class="form-group">
                            <input type="button" value="Close" id="btnModelClose" class="btn btn-default btn-warning " style="position: absolute; bottom: 5px; right: 5px;" />
                        </div>
                    </div>
                </div>
            </div>--%>
            <div id="divProcess" runat="server" visible="false">
                <div id="divProc">
                    <div class="row">
                        <div class="col-md-6">
                            <div class="form-group">
                                <div style="font-weight: bold">
                                    <h4>
                                        Perform Actions</h4>
                                </div>
                                <asp:Button ID="btnRollback" runat="server" class="btn btn-success" Text="Roll Back"
                                    OnClick="btnRollback_Click" />
                                &nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:Button ID="btnAmount" Visible="false" runat="server" class="btn btn-success"
                                    Text="Change Recommend Amount" OnClick="btnAmount_Click" />
                                &nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:Button ID="btnCaste" Visible="false" runat="server" class="btn btn-success"
                                    Text="Change Caste" OnClick="btnCaste_Click" />
                                <%--<input type="button" id="btnRollback" class="btn btn-default " value="Roll Back" />
                                <input type="button" id="btnAmount" class="btn btn-default " value="Change Recommend Amount" />
                                <input type="button" id="btnCaste" class="btn btn-default " value="Change Caste" />--%>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-4">
                            <%--<div id="divselIncTypes" class="form-group" runat="server">
                                <label for="">Select Incentive</label>
                                <select class="form-control" id="selIncTypes">
                                    <option value="0">select</option>
                                </select>
                            </div>--%>
                            <div id="divselrollbacklevel" class="form-group" runat="server" visible="false">
                                <label for="">
                                    Select Roll Back level</label>
                                <asp:DropDownList ID="selrollbacklevel" class="form-control" runat="server" AutoPostBack="True"
                                    OnSelectedIndexChanged="selrollbacklevel_SelectedIndexChanged">
                                    <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                </asp:DropDownList>
                                <%--       <select class="form-control" id="selrollbacklevel">
                                    <option value="0">Select</option>
                                    <option value="1">GM->IO</option>
                                    <option value="2">IO->GM</option>
                                    <option value="3">JD->GM</option>
                                    <option value="4">JD->JD</option>
                                    <option value="5">ADDL->JD</option>
                                    <option value="6">GM->GM</option>
                                    <option value="7">IO->IO</option>
                                    <option value="8">COI->GM</option>
                                    <option value="9">DIPC->GM</option>
                                </select>--%>
                            </div>
                            <%--<div id="divselrbtype" class="form-group" runat="server" visible="false">
                                <label for="">Select Type</label>
                                <select class="form-control" disabled="disabled" id="selrbtype">
                                    <option value="0">Select</option>
                                    <option value="1">Application</option>
                                    <option value="2">Query</option>
                                    <option value="3">Inspection Report</option>
                                    <option value="4">Reject</option>
                                </select>
                            </div>--%>
                            <div id="divselroleamt" class="form-group" runat="server" visible="false">
                                <label for="">
                                    Select Role</label>
                                <select class="form-control" id="selroleamt">
                                    <option value="0">Select</option>
                                    <option value="1">GM</option>
                                    <option value="2">JD</option>
                                    <option value="3">ADDL</option>
                                </select>
                            </div>
                            <div id="divselcaste" class="form-group" runat="server" visible="false">
                                <label for="">
                                    Select Caste</label>
                                <select class="form-control" id="selcaste">
                                    <option value="0">Select</option>
                                    <option value="1">General</option>
                                    <option value="2">OBC</option>
                                    <option value="3">SC</option>
                                    <option value="4">ST</option>
                                    <option value="5">Others</option>
                                </select>
                            </div>
                            <div id="divtxtAmt" class="form-group" runat="server" visible="false">
                                <label for="">
                                    Enter Amount</label>
                                <asp:TextBox ID="txtAmt" onkeypress="return inputOnlyNumbers(event)" runat="server"></asp:TextBox>
                                <%-- <input type="text" class="form-control" id="txtAmt" />--%>
                            </div>
                        </div>
                    </div>
                    <div class="row" runat="server" id="divcommoninpts" visible="false">
                        <div class="col-md-4">
                            <label for="">
                                HD Id</label>
                            <asp:TextBox ID="txthdid" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                        <div class="col-md-6">
                            <label for="">
                                HD Remarks</label>
                            <asp:TextBox ID="txtremarks" TextMode="MultiLine" CssClass="form-control" Height="180px"
                                runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="row" runat="server" visible="false" id="btnchange">
                        <div class="col-md-3">
                            <%--<input type="button" value="Process" id="btnAction" class="btn btn-success" />--%>
                            <asp:Button ID="btnAction" runat="server" Text="Process" class="btn btn-success"
                                OnClick="btnAction_Click" />
                        </div>
                    </div>
                </div>
            </div>
            <div class="container-fluid" runat="server" id="divcfeviewdata" visible="false">
                <div class="row">
                    <div class="col-md-12">
                        <h1 class="page-head-linenew" align="left" style="font-size: smaller">
                        </h1>
                    </div>
                    <div class="col-md-12">
                        <table align="center" cellpadding="10" cellspacing="5" style="width: 100%" id="tblcfe"
                            runat="server" visible="false">
                            <tr>
                                <td align="center" style="padding: 5px; font-size: 16pt; font-weight: bold; color: #f7a209;
                                    margin: 5px; text-align: center;" colspan="3" id="tdapplicationstatus" runat="server">
                                </td>
                            </tr>
                            <tr>
                                <td align="center" style="padding: 5px; margin: 5px; text-align: center;" colspan="3">
                                </td>
                            </tr>
                            <tr>
                                <td align="center" style="padding: 5px; margin: 5px; height: 102px;">
                                    <table cellpadding="4" class="table" cellspacing="5" style="width: 100%">
                                        <tr>
                                            <td style="padding: 5px; margin: 5px" align="left">
                                                <asp:Label ID="Label351" runat="server" CssClass="LBLBLACK" Width="165px" Font-Bold="True">1. UID 
                                                        Number</asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                :
                                            </td>
                                            <td style="padding: 5px; margin: 5px" align="left">
                                                <a target="_blank" id="labUidNumber" runat="server">
                                                    <asp:Label ID="lblUID" runat="server" CssClass="LBLBLACK" Font-Bold="true" Width="165px"></asp:Label></a>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px" align="left">
                                                <asp:Label ID="Label353" runat="server" CssClass="LBLBLACK" Width="165px" Font-Bold="True">2. Name of the Industry</asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                :
                                            </td>
                                            <td style="padding: 5px; margin: 5px" align="left">
                                                <asp:Label ID="labNameandAddress" runat="server" CssClass="LBLBLACK" Width="150px"></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px" align="left">
                                                <asp:Label ID="Label355" runat="server" CssClass="LBLBLACK" Width="165px" Font-Bold="True">3. Line of Activity</asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                :
                                            </td>
                                            <td style="padding: 5px; margin: 5px" align="left">
                                                <asp:Label ID="labLineofActivity" runat="server" CssClass="LBLBLACK" Width="165px"></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px" align="left">
                                                <asp:Label ID="Label2" runat="server" CssClass="LBLBLACK" Width="165px" Font-Bold="True">4. Sector</asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                :
                                            </td>
                                            <td style="padding: 5px; margin: 5px" align="left">
                                                <asp:Label ID="lblSector" runat="server" CssClass="LBLBLACK" Width="165px"></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px" align="left">
                                                <asp:Label ID="Label3" runat="server" CssClass="LBLBLACK" Width="165px" Font-Bold="True">5. District / Division	</asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                :
                                            </td>
                                            <td style="padding: 5px; margin: 5px" align="left">
                                                <asp:Label ID="lblDistrict" runat="server" CssClass="LBLBLACK" Width="165px"></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr style="height: 10px">
                                            <td>
                                            </td>
                                            <td>
                                            </td>
                                            <td>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; font-weight: bold;" align="left" colspan="4"
                                                valign="bottom">
                                                <asp:HyperLink ID="hprcoipaynetdtls" Text='Click Here For View Industry Payment Details'
                                                    Target="_blank" runat="server" />
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                                <td align="center" style="padding: 5px; margin: 5px; height: 102px;">
                                </td>
                                <td align="center" style="padding: 5px; margin: 5px; height: 102px; vertical-align: top;">
                                    <table cellpadding="4" cellspacing="5" style="width: 100%; vertical-align: top;"
                                        class="table">
                                        <tr>
                                            <td style="padding: 5px; margin: 5px" align="left">
                                                <asp:Label ID="Label361" runat="server" CssClass="LBLBLACK" Width="224px" Font-Bold="True">6. Date of Industry Application</asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                :
                                            </td>
                                            <td style="padding: 5px; margin: 5px" align="left">
                                                <asp:Label ID="labDOA" runat="server" CssClass="LBLBLACK" Width="165px"></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px" align="left">
                                                <asp:Label ID="Label359" runat="server" CssClass="LBLBLACK" Width="165px" Font-Bold="True">7. Category of Industry</asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                :
                                            </td>
                                            <td style="padding: 5px; margin: 5px" align="left">
                                                <asp:Label ID="labCategoryofIndustry" runat="server" CssClass="LBLBLACK" Width="165px"></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px" align="left">
                                                <asp:Label ID="Label1" runat="server" CssClass="LBLBLACK" Width="233px" Font-Bold="True">8. Pollution Category of Industry</asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                :
                                            </td>
                                            <td style="padding: 5px; margin: 5px" align="left">
                                                <asp:Label ID="lblpolution" runat="server" CssClass="LBLBLACK" Width="150px"></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px" align="left">
                                                <asp:Label ID="Label357" runat="server" CssClass="LBLBLACK" Width="165px" Font-Bold="True">9. Total Investment</asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                :
                                            </td>
                                            <td style="padding: 5px; margin: 5px" align="left">
                                                <asp:Label ID="labTotalInvestment" runat="server" CssClass="LBLBLACK" Width="165px"></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px" align="left">
                                                <asp:Label ID="Label362" runat="server" CssClass="LBLBLACK" Width="233px" Font-Bold="True">10. Employment</asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                :
                                            </td>
                                            <td style="padding: 5px; margin: 5px" align="left">
                                                <asp:Label ID="lblEmploymenttot" runat="server" CssClass="LBLBLACK" Width="150px"></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px" align="left">
                                                <asp:Label ID="Label362123" runat="server" CssClass="LBLBLACK" Width="233px" Font-Bold="True">11. Address of the Industry</asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                :
                                            </td>
                                            <td style="padding: 5px; margin: 5px" align="left">
                                                <asp:Label ID="labNameandAddress0" runat="server" CssClass="LBLBLACK" Width="150px"></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; font-weight: bold; font-size: medium" align="center"
                                                colspan="4">
                                                <asp:HyperLink ID="HyperLinkSubsidy" Text='Click Here For Attachments' Target="_blank"
                                                    runat="server" />
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td align="center" style="padding: 5px; margin: 5px; height: 280px;" colspan="3">
                                    <asp:GridView ID="grdDetailsApprovaldtls" runat="server" AutoGenerateColumns="False"
                                        OnRowDataBound="grdDetailsApprovaldtls_RowDataBound" OnPageIndexChanging="grdDetailsApprovaldtls_PageIndexChanging"
                                        CssClass="Grid" OnRowCreated="grdDetailsApprovaldtls_RowCreated" EnableModelValidation="True"
                                        AlternatingRowStyle-CssClass="alt">
                                        <HeaderStyle Height="40px" BackColor="#363670" ForeColor="White" />
                                        <FooterStyle Height="40px" />
                                        <Columns>
                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S.No">
                                                <ItemTemplate>
                                                    <%# Container.DataItemIndex +1 %>
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Center" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Name of Approval">
                                                <ItemTemplate>
                                                    <asp:HyperLink ID="hplkapprovalsname" Text='<%#Eval("Name of the approval")%>' NavigateUrl='<%#Eval("Approvalnfo")%>'
                                                        Target="_blank" runat="server" />
                                                    <asp:Label ID="lblapprovalname" Text='<%#Eval("Name of the approval")%>' runat="server"
                                                        Visible="false"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <%--<asp:BoundField DataField="Name of the approval" HeaderText="Name of Approval" />--%>
                                            <asp:BoundField DataField="Approval Application Date" HeaderText="Approval Applied Date" />
                                            <asp:BoundField DataField="Appealed" HeaderText="Appealed (Y/N)" />
                                            <%--<asp:BoundField DataField="Payment Date" HeaderText="Date of Payment" />--%>
                                            <asp:TemplateField HeaderText="Date of Payment">
                                                <ItemTemplate>
                                                    <asp:HyperLink ID="hyperPayment" Text='<%#Eval("Payment Date")%>' NavigateUrl='<%#Eval("Paymentlink")%>'
                                                        Target="_blank" runat="server" />
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" Width="100px" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Date of Query">
                                                <ItemTemplate>
                                                    <asp:HyperLink ID="hyperQuery" Text='<%#Eval("Query Date")%>' NavigateUrl='<%#Eval("Querypagelink")%>'
                                                        Target="_blank" runat="server" />
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" Width="100px" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Date of Query Response">
                                                <ItemTemplate>
                                                    <asp:HyperLink ID="hyperQuery1" Text='<%#Eval("Query Response Date")%>' NavigateUrl='<%#Eval("Querypagelink")%>'
                                                        Target="_blank" runat="server" />
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" Width="100px" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Pre-Scrutiny Completion Date">
                                                <ItemTemplate>
                                                    <asp:HyperLink ID="hplpscstataus" Text='<%#Eval("PSC Completion_Rejection Date")%>'
                                                        NavigateUrl='<%#Eval("PSCDOC")%>' Target="_blank" runat="server" />
                                                    <asp:Label ID="lblpscstataus" Text='<%#Eval("PSC Completion_Rejection Date")%>' runat="server"
                                                        Visible="false"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <%--<asp:BoundField DataField="PSC Completion_Rejection Date" HeaderText="Pre-Scrutiny Completion Date" />--%>
                                            <asp:BoundField DataField="No of days taken for PSC excluding holidays" HeaderText="Number of days taken" />
                                            <asp:TemplateField HeaderText="Date of Additional Payment">
                                                <ItemTemplate>
                                                    <asp:HyperLink ID="hyperaddPayment" Text='<%#Eval("AdditionalPayment")%>' NavigateUrl='<%#Eval("AddPaymentlink")%>'
                                                        Target="_blank" runat="server" />
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" Width="100px" />
                                            </asp:TemplateField>
                                            <%--  <asp:BoundField DataField="AdditionalPayment" HeaderText="Date of Additional Payment" />
                                                <asp:BoundField DataField="Payment Type" HeaderText="Payment Type" />
                                            <asp:BoundField DataField="Amount Paid" HeaderText="Amount Paid (Rs)" />--%>
                                            <asp:BoundField DataField="Date of Approval received to Approval Stage Max of payment or PSC date"
                                                HeaderText="Date Received to Approval Stage" />
                                            <asp:BoundField DataField="Actual Date of Approval Rejection" HeaderText="Date of Completion" />
                                            <asp:BoundField DataField="SLA_Approval No of days" HeaderText="SLA" />
                                            <asp:BoundField DataField="No of days taken for Approval excluding holidays" HeaderText="Number of days taken" />
                                            <asp:TemplateField HeaderText="Status">
                                                <ItemTemplate>
                                                    <asp:HyperLink ID="HyperLinkSubsidy" Text='<%#Eval("Status of Approval Approved Rejected")%>'
                                                        NavigateUrl='<%#Eval("ApprovalDoc")%>' Target="_blank" runat="server" />
                                                    <asp:Label ID="lblverified" Text='<%#Eval("Status of Approval Approved Rejected")%>'
                                                        runat="server" Visible="false"></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" Width="100px" />
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                    <br />
                                </td>
                            </tr>
                            <tr id="trcoicertificate" runat="server" visible="false">
                                <td align="center" style="padding: 5px; margin: 5px; text-align: center;" valign="top"
                                    colspan="3">
                                    <asp:HyperLink ID="HyperLinkcoi" runat="server" Font-Bold="true" ForeColor="#FF6600">TS-iPASS consolidated certificate</asp:HyperLink>
                                    <%-- <asp:Button ID="Button1" runat="server" CssClass="btn-primary" Height="32px"
                                                        TabIndex="10" Text="TS-iPASS consolidated certificate" Width="185px" OnClientClick="document.forms[0].target = '_blank';" OnClick="BtnSave2_Click" />--%>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div class="col-md-12">
                        <h1 class="page-head-linenew" align="left" style="font-size: smaller">
                        </h1>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-6">
                        <div class="form-group">
                            <div style="font-weight: bold">
                                <h4>
                                    Perform Actions</h4>
                            </div>
                            <asp:DropDownList ID="ddlcfeactions" class="form-control" runat="server" AutoPostBack="True"
                                OnSelectedIndexChanged="ddlcfeactions_SelectedIndexChanged">
                                <asp:ListItem Value="0">Select</asp:ListItem>
                                <asp:ListItem Value="1">RTGS Payment Update - Kotak</asp:ListItem>
                                <asp:ListItem Value="2">RTGS Payment Update - Billdesk</asp:ListItem>
                                <asp:ListItem Value="3">Online Payment Update - Kotak</asp:ListItem>
                                <asp:ListItem Value="4">Online Payment Update - Billdesk</asp:ListItem>
                                <asp:ListItem Value="5">Payment Done at Department Side</asp:ListItem>
                                <asp:ListItem Value="6">Category Change</asp:ListItem>
                                <asp:ListItem Value="7">Questionnaire Edit </asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="col-md-12" runat="server" visible="false" id="divinitiatrdpaymentdetails">
                        <div class="form-group">
                            <div style="font-weight: bold">
                                <h4>
                                    Initiated Payment Details</h4>
                            </div>
                            <asp:GridView ID="gvInitiated" runat="server" AutoGenerateColumns="false" CellPadding="4"
                                CssClass="GRD" ForeColor="#333333" Height="62px" OnRowDataBound="gvInitiated_RowDataBound"
                                PageSize="15" ShowFooter="True" Width="70%" CellSpacing="4">
                                <FooterStyle BackColor="#be8c2f" Font-Bold="True" ForeColor="White" />
                                <RowStyle BackColor="#EBF2FE" CssClass="GRDITEM" HorizontalAlign="Left" VerticalAlign="Middle" />
                                <PagerStyle BackColor="#013161" ForeColor="White" HorizontalAlign="Center" />
                                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                <HeaderStyle BackColor="#1d9a5b" CssClass="GRDHEADER" Font-Bold="True" ForeColor="White" />
                                <EditRowStyle BackColor="#B9D684" />
                                <AlternatingRowStyle BackColor="White" />
                                <Columns>
                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S.No">
                                        <ItemTemplate>
                                            <%# Container.DataItemIndex + 1%>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="ApprovalName" ItemStyle-HorizontalAlign="left" HeaderText="Name of Approval">
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Online_Amount" ItemStyle-HorizontalAlign="Right" HeaderText="Fee">
                                        <ItemStyle HorizontalAlign="Right"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="paytype" ItemStyle-HorizontalAlign="left" HeaderText="Payment Type">
                                    </asp:BoundField>
                                    <asp:BoundField DataField="OnlineOrderNo" ItemStyle-HorizontalAlign="left" HeaderText="TSiPASS Transaction No">
                                    </asp:BoundField>
                                    <asp:TemplateField HeaderText="AddtionalPaymentflg" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblAddtionalPaymentflg" Text='<%#Eval("AddtionalPaymentflg") %>' runat="server" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </div>
                    </div>
                </div>
                <div class="row" id="divcfertgs" runat="server" visible="false">
                    <div class="col-md-3">
                        <div class="form-group">
                            <label for="">
                                Enter Paid Amount</label>
                            <asp:TextBox ID="txtcfeamount" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-md-3">
                        <div class="form-group">
                            <label for="">
                                Transation/UTI Number</label>
                            <asp:TextBox ID="txttransnor" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-md-3">
                        <div class="form-group">
                            <label for="">
                                Bank Id</label>
                            <asp:TextBox ID="txtbankid" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <div class="row" id="divcfertgsUpload" runat="server" visible="false">
                    <div class="col-md-4">
                        <div class="form-group">
                            <label for="">
                                Upload Payment Proof</label>
                            <asp:FileUpload ID="FileUpload1" runat="server" class="form-control txtbox" Height="28px" />
                            <asp:HyperLink ID="lblFileName" runat="server" CssClass="LBLBLACK" Width="165px"></asp:HyperLink>
                            <br />
                            <asp:Label ID="Label434" runat="server" Visible="False"></asp:Label>
                        </div>
                    </div>
                    <div class="col-md-3">
                        <div class="form-group">
                            <label for="">
                                Cilck Below Button to Upload the Document</label>
                            <asp:Button ID="BtnSave3" runat="server" CssClass="btn btn-xs btn-warning" Height="28px"
                                OnClick="BtnSave3_Click" TabIndex="10" Text="Upload" Width="100px" />
                        </div>
                    </div>
                </div>
                <div class="row" id="divcfertgshdremarks" runat="server" visible="false">
                    <div class="col-md-4">
                        <label for="">
                            HD Id</label>
                        <asp:TextBox ID="txtcfehdid" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>
                    <div class="col-md-6">
                        <label for="">
                            HD Remarks</label>
                        <asp:TextBox ID="txthdRemarks" TextMode="MultiLine" CssClass="form-control" Height="180px"
                            runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-4">
                        <%--<input type="button" value="Process" id="btnAction" class="btn btn-success" />--%>
                        <asp:Button ID="btncfeactionclick" runat="server" Text="Process" class="btn btn-success"
                            OnClick="btncfeactionclick_Click" />
                    </div>
                    <div class="col-md-12" runat="server" visible="false" id="divpaymentsuccess">
                        <div class="form-group">
                            <div style="font-weight: bold">
                                <h4>
                                    Initiated Payment Details</h4>
                            </div>
                            <asp:GridView ID="gvdpaymentsuccess" runat="server" AutoGenerateColumns="false" CellPadding="4"
                                CssClass="GRD" ForeColor="#333333" Height="62px" PageSize="15" ShowFooter="false"
                                Width="70%" CellSpacing="4">
                                <FooterStyle BackColor="#be8c2f" Font-Bold="True" ForeColor="White" />
                                <RowStyle BackColor="#EBF2FE" CssClass="GRDITEM" HorizontalAlign="Left" VerticalAlign="Middle" />
                                <PagerStyle BackColor="#013161" ForeColor="White" HorizontalAlign="Center" />
                                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                <HeaderStyle BackColor="#1d9a5b" CssClass="GRDHEADER" Font-Bold="True" ForeColor="White" />
                                <EditRowStyle BackColor="#B9D684" />
                                <AlternatingRowStyle BackColor="White" />
                                <Columns>
                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S.No">
                                        <ItemTemplate>
                                            <%# Container.DataItemIndex + 1%>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="uidno" ItemStyle-HorizontalAlign="left" HeaderText="UID NO">
                                    </asp:BoundField>
                                    <asp:BoundField DataField="billerid" ItemStyle-HorizontalAlign="left" HeaderText="TSiPASS Transaction No">
                                    </asp:BoundField>
                                    <asp:BoundField DataField="description" ItemStyle-HorizontalAlign="left" HeaderText="Payment Status">
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Dateofresp" ItemStyle-HorizontalAlign="left" HeaderText="Payment response Date">
                                    </asp:BoundField>
                                </Columns>
                            </asp:GridView>
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <script src="Scripts/jquery-3.2.1.min.js"></script>
    <link href="http://cdn.rawgit.com/davidstutz/bootstrap-multiselect/master/dist/css/bootstrap-multiselect.css"
        rel="stylesheet" type="text/css" />
    <script src="http://cdn.rawgit.com/davidstutz/bootstrap-multiselect/master/dist/js/bootstrap-multiselect.js"
        type="text/javascript"></script>
    <script type="text/javascript">

        var GactionType = 0;


        function hideElements() {
            $('#divselIncTypes,#divselrollbacklevel,#divselrbtype,#divselroleamt,#divselcaste,#divtxtAmt,#btnAction').addClass('hidden');
            $('#selIncTypes,#selrollbacklevel,#selrbtype,#selroleamt,#selcaste').val('0');
            $('#txtAmt').val('');
            $('#selrbtype option').prop('disabled', false);
        }

        function disableValuesSelect(ids) {
            $('#selrbtype option').prop('disabled', false)
            var id = ids.split(',');
            if (id.length > 0) {
                for (var i = 0; i < id.length; i++) {
                    $('#selrbtype option').filter(function () {
                        return $(this).val() == id[i];
                    }).prop('disabled', true);
                }
            }
        }


        $(function () {

            $('#selType').change(function () {
                var d = $(this).val();

                if (d == 1) {
                    $('#DivInc').removeClass('hidden');
                    $('#DivCfe').addClass('hidden');
                    $('#DivCfo').addClass('hidden');
                    $('#inputIncId').val('');
                    $('#inputUnit').val('');
                    $('#ctl00_ContentPlaceHolder1_selDist').val('0');

                } else
                    if (d == 2) {
                        $('#DivInc').addClass('hidden');
                        $('#DivCfe').removeClass('hidden');
                        $('#DivCfo').addClass('hidden');
                    } else
                        if (d == 3) {
                            $('#DivInc').addClass('hidden');
                            $('#DivCfe').addClass('hidden');
                            $('#DivCfo').removeClass('hidden');
                        } else {
                            $('#DivInc').addClass('hidden');
                            $('#DivCfe').addClass('hidden');
                            $('#DivCfo').addClass('hidden');
                        }
            });

            $('#btnSearch').click(function () {
                var id, unit, dist, valid;

                id = $.trim($('#inputIncId').val());
                unit = $.trim($('#inputUnit').val());
                dist = $('#ctl00_ContentPlaceHolder1_selDist').val();
                valid = 0;
                if (id == "" && unit == "" && dist == 0) {
                    valid = 0;
                } else {
                    valid = 1;
                }

                if (valid != 0) {

                    var strData = JSON.stringify({ 'Id': id, 'Unitname': unit, 'Dist': dist });

                    $.ajax({
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        url: "Solution.aspx/IncentivesList",
                        data: strData,
                        success: function (response) {
                            console.log(response);
                            var data = JSON.parse(response.d);
                            console.log(data);
                            if (data != '' && data.length > 0) {
                                $('#datatable').removeClass('hidden');
                                $("#datatable tbody").remove();
                                var tbody = $("<tbody/>");
                                $.each(data, function (rowIndex, t) {
                                    var row = $("<tr/>");
                                    row.append($("<td/>").text(t.IncentveID));
                                    row.append($("<td/>").text(t.UnitName));
                                    row.append($("<td/>").text(t.District_Name));
                                    row.append($("<td/>").text((t.ApplicationFiledDate == null) ? "" : t.ApplicationFiledDate));
                                    row.append($("<td/>").html("<input type='button' id='btnIncinfo' class='btn btn-info' onclick='showStatus(" + t.IncentveID + ");' value='Status' />  "));
                                    row.append($("<td/>").html("<input type='button' id='btnIncDetails' class='btn btn-success' onclick='showDetails(" + t.IncentveID + ");' value='Process' /> "));
                                    tbody.append(row);
                                });
                                $('#datatable').append(tbody);
                            }
                            else {
                                $('#datatable').addClass('hidden');
                                $("#datatable tbody").empty();
                                alert('No results found.');
                            }


                        },
                        error: function (e, a, t) {
                            console.log('jqXHR:'), console.log(e), console.log('textStatus:'), console.log(a), console.log('errorThrown:'), console.log(t)
                        }
                    });
                }
                else {
                    alert('Please Enter Fields to Search Incentives');
                }
            });

            $('#ModalBody').on("click", "#btnRollback", function (e) {
                GactionType = 1;
                hideElements();
                $('#divselIncTypes,#divselrollbacklevel,#divselrbtype,#btnAction').removeClass('hidden');
                e.preventDefault();
            });

            $('#ModalBody').on("click", "#btnAmount", function (e) {
                GactionType = 2;
                hideElements();
                $('#divselIncTypes,#divselroleamt,#divtxtAmt,#btnAction').removeClass('hidden');
                e.preventDefault();
            });

            $('#ModalBody').on("click", "#btnCaste", function (e) {
                GactionType = 3;
                hideElements();
                $('#divselcaste,#btnAction').removeClass('hidden');
                e.preventDefault();
            });

            $('#ModalBody').on("change", "#selrollbacklevel", function (e) {
                var d = $(this).val();
                $('#selrbtype').val('0');

                if (d != 0) {
                    var ids;
                    if (d == 1) { ids = "1,4"; }
                    if (d == 2) { ids = "2,3,4"; }
                    if (d == 3) { ids = "2,3,4"; }
                    if (d == 4) { ids = "1,3"; }
                    if (d == 5) { ids = "2,3,4"; }
                    if (d == 6) { ids = "1,3,4"; }
                    if (d == 7) { ids = "1,4"; }
                    if (d == 8) { ids = "2,3,4"; }
                    if (d == 9) { ids = "2,3,4"; }
                    disableValuesSelect(ids);
                    $('#selrbtype').prop('disabled', false);
                } else {
                    $('#selrbtype option').prop('disabled', false);
                    $('#selrbtype').prop('disabled', true);
                }
                e.preventDefault();
            });


            $('#myModal').on("click", "#btnModelClose", function (e) {
                modal.style.display = "none";
                e.preventDefault();
            });


            $('#myModal').on("click", "#btnAction", function (e) {
                if (GactionType == 1) {
                    debugger;
                    var strData = JSON.stringify({ 'EntrpId': $('#lblIncId').html(), 'MstIncid': $('#selIncTypes').val(), 'Rblevel': $('#selrollbacklevel').val(), 'Type': $('#selrbtype').val() });
                    $.ajax({
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        url: "Solution.aspx/ApplicationRollback",
                        data: strData,
                        success: function (response) {
                            var data = JSON.parse(response.d);
                            if (data == 1) {
                                alert('success');
                            } else {
                                alert('Rool back not Updated due to internal server problem.');
                            }
                        },
                        error: function (e, a, t) {
                            alert('Rool back not Updated due to internal server problem.');
                            console.log('jqXHR:'), console.log(e), console.log('textStatus:'), console.log(a), console.log('errorThrown:'), console.log(t)
                        }
                    });

                }
                if (GactionType == 2) {
                    var strData = JSON.stringify({ 'EnrpId': $('#lblIncId').html(), 'MstincId': $('#selIncTypes').val(), 'Role': $('#selroleamt').val(), 'Amount': $('#txtAmt').val() });
                    $.ajax({
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        url: "Solution.aspx/UpdateIncentiveAmount",
                        data: strData,
                        success: function (response) {
                            var data = JSON.parse(response.d);
                            if (data == 1) {
                                alert('Amount Updated Successfully.');
                                $('#selroleamt').val('0');
                                $('#txtAmt').val('');
                                $('#selIncTypes').val('0');
                            } else {
                                alert('Amount not Updated due to internal server problem.');
                            }
                        },
                        error: function (e, a, t) {
                            alert('Amount not Updated due to internal server problem.');
                            console.log('jqXHR:'), console.log(e), console.log('textStatus:'), console.log(a), console.log('errorThrown:'), console.log(t)
                        }
                    });

                }
                if (GactionType == 3) {
                    var strData = JSON.stringify({ 'EnrpId': $('#lblIncId').html(), 'Caste': $('#selcaste').val() });

                    $.ajax({
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        url: "Solution.aspx/UpdateCaste",
                        data: strData,
                        success: function (response) {
                            var data = JSON.parse(response.d);
                            if (data == 1) {
                                alert('Caste Updated Successfully.');
                                $('#selcaste').val('0');
                            } else {
                                alert('Caste not Updated due to internal server problem.');
                            }
                        },
                        error: function (e, a, t) {
                            alert('Caste not Updated due to internal server problem.');
                            console.log('jqXHR:'), console.log(e), console.log('textStatus:'), console.log(a), console.log('errorThrown:'), console.log(t)
                        }
                    });
                }

                e.preventDefault();
            });

        });


        function showStatus(id) {

            var strData = JSON.stringify({ 'Id': id });

            $.ajax({
                type: "POST",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                url: "Solution.aspx/IncentiveStatus",
                data: strData,
                success: function (response) {
                    var data = JSON.parse(response.d);
                    console.log(data);
                    if (data.Table != '' && data.Table.length > 0) {
                        console.log(data.Table[0]);
                        var incentives = '';

                        if (data.Table1.length > 0) {
                            debugger;
                            var table = '<h4>Applied Incentives List</h4><table class="table"><thead><th>Incentive Name</th><th>Time peroid</th><th>Present status</th></thead><tbody>';
                            $.each(data.Table1, function (rowIndex, t) {
                                table = table + "<tr><td>" + t.IncentiveName + "</td><td>" + formatDate(t.FromDate, 1) + " -- " + formatDate(t.ToDate, 1) + "</td><td>" + t.nameofStage + "</td></tr>";
                            });
                            incentives = table + '</tbody></table>'
                        }
                        else {
                            incentives = '<h4>Incentives not applied</h4>';
                        }

                        $('#ModalBody').html('<div class="container-fluid"> <div class="row"> <div class="col-md-10"> <table class="table"> <tr> <td>Application Date :</td> <td>' + formatDate(data.Table[0].ApplicationFiledDate) + '</td> <td>Application No :</td> <td>' + data.Table[0].applicationno + '</td> </tr> <tr> <td>Unit Name :</td> <td>' + data.Table[0].UnitName + '</td> <td>Applicant Name :</td> <td>' + data.Table[0].ApplciantName + '</td> </tr> <tr> <td>Sector :</td> <td>' + data.Table[0].SectorNew + '</td> <td>Social Status :</td> <td>' + data.Table[0].SocialStatus + '</td> </tr> <tr> <td>Category :</td> <td>' + data.Table[0].Category + '</td> <td>DCP :</td> <td>' + formatDate(data.Table[0].DCP) + '</td> </tr> <tr> <td>District :</td> <td>' + data.Table[0].UnitDistName + '</td> <td>Mandal :</td> <td>' + data.Table[0].UNITMANDAL + '</td> </tr> <tr> <td>Village:</td> <td>' + data.Table[0].UNITVILLAGE + '</td> <td>Mobile :</td> <td>' + data.Table[0].UnitMObileNo + '</td> </tr> <tr> <td>Email :</td> <td>' + data.Table[0].UnitEmail + '</td> <td></td> <td></td> </tr> <tr> <td></td> <td></td> <td></td> <td></td> </tr> </table> </div> </div><div class="row"><div class="col-md-12">' + incentives + '</div></div></div>');

                        modal.style.display = "block";

                    }
                    else {
                    }
                },
                error: function (e, a, t) {
                    console.log('jqXHR:'), console.log(e), console.log('textStatus:'), console.log(a), console.log('errorThrown:'), console.log(t)
                }
            });

        }


        function showDetails(id) {
            debugger;
            GactionType = 0;

            modal.style.display = "block";
            $('#ModalBody').html($('#divProcess').html());
            hideElements();

            var strData = JSON.stringify({ 'Id': id });

            $.ajax({
                type: "POST",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                url: "Solution.aspx/GetIncentivesList",
                data: strData,
                success: function (response) {
                    var data = JSON.parse(response.d);
                    console.log(data);
                    if (data.Table != '' && data.Table.length > 0) {
                        console.log('Incentives list');
                        console.log(data.Table[0]);
                        var d = data.Table[0];

                        $('#selIncTypes').empty().append('<option value="0"> Select </option>');
                        $.each(data.Table, function (index, value) {
                            $('#selIncTypes').append('<option value="' + value.MstIncentiveid + '">' + value.IncentiveName + '</option>');
                        });

                        $('#lblUnitname').html('').html(d.UnitName);
                        $('#lblIncId').html('').html(id);
                    }
                    else {
                    }
                },
                error: function (e, a, t) {
                    console.log('jqXHR:'), console.log(e), console.log('textStatus:'), console.log(a), console.log('errorThrown:'), console.log(t)
                }
            });

        }

        var modal = document.getElementById('myModal');

        //var btn = document.getElementById("myBtn");

        var span = document.getElementsByClassName("close")[0];

        //btn.onclick = function () {
        //    modal.style.display = "block";
        //}

        span.onclick = function () {
            modal.style.display = "none";
        }


        window.onclick = function (event) {
            if (event.target == modal) {
                if ($('#ModalBody #divProc').length == 0) {
                    modal.style.display = "none";
                }
                else {
                    modal.style.display = "block";
                }
            }
        }





        ///  date functions


        function ConvertJsonDate(d) {
            if (d != null) {
                var dt = eval(d.replace(/\/Date\((.*?)\)\//gi, "new Date($1)"));
                var month = dt.getMonth() + 1;
                var monthString = month > 9 ? month : '0' + month;
                var day = dt.getDate();
                var dayString = day > 9 ? day : '0' + day;
                var year = dt.getFullYear();
                return dayString + '/' + monthString + '/' + year;
            }
            else { return ""; }
        }

        function formatDate(date, type) {
            if (date != null) {
                var month_names_short = ['Jan', 'Feb', 'Mar', 'Apr', 'May', 'Jun', 'Jul', 'Aug', 'Sep', 'Oct', 'Nov', 'Dec']
                var d = new Date(date),
                    month = '' + (d.getMonth() + 1),
                    day = '' + d.getDate(),
                    year = d.getFullYear();

                if (month.length < 2) month = '0' + month;
                if (day.length < 2) day = '0' + day;

                if (type != undefined) {
                    return month_names_short[d.getMonth()] + " " + year
                } else {
                    return [day, month, year].join('/');
                }
            } else { return ""; }
        }


        function inputOnlyNumbers(evt) {
            var e = window.event || evt; // for trans-browser compatibility 
            var charCode = e.which || e.keyCode;
            if ((charCode > 45 && charCode < 58) || charCode == 8 || charCode == 9) {
                return true;
            }
            return false;
        }
    </script>
</asp:Content>
