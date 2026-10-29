<%@ Page Title="" Language="C#" MasterPageFile="~/UI/TSiPASS/CCMaster.master" AutoEventWireup="true"
    CodeFile="frmDrugInfo.aspx.cs" Inherits="UI_TSiPASS_frmDrugInfo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script src="../../Resource/Scripts/js/validations.js" type="text/javascript"></script>
    <style type="text/css">
        .ui-datepicker
        {
            font-size: 8pt !important;
            height: 250px;
            padding: 0.2em 0.2em 0;
        }
        
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
            background-image: url("../../Images/ajax-loaderblack.gif"); /*background-image: url("Images/spinner_60.gif");*/
            background-position: center center;
            background-repeat: no-repeat; /*background-color: #e4e4e6;*/
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
        .auto-style1 {
            position: relative;
            min-height: 1px;
            top: 0px;
            left: 0px;
            float: left;
            width: 16.66666667%;
            padding-left: 15px;
            padding-right: 15px;
        }
    </style>
    <script type="text/javascript" language="javascript">

        function OpenPopup() {

            window.open("Lookups/LookupBDC.aspx", "List", "scrollbars=yes,resizable=yes,width=1000,height=650;display = block;position=absolute");

            return false;
        }
    </script>
    <%--<script type="text/javascript">
        function showProgress() {
            var updateProgress = $get("<%= UpdateProgress.ClientID %>");
            updateProgress.style.display = "block";
        }
    </script>--%>
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
    <%-- <asp:UpdatePanel ID="upd1" runat="server">
        <ContentTemplate>--%>
    <div align="left">
        <ol class="breadcrumb">
            You are here &nbsp;!&nbsp; &nbsp; &nbsp;
            <li><i class="fa fa-dashboard"></i><a href="Home.aspx"></a></li>
            <li class=""><i class="fa fa-fw fa-edit">CAF</i> </li>
            <li class="active"><i class="fa fa-edit"></i><a href="#">PCB Details</a> </li>
        </ol>
    </div>
    <div align="left">
        <div class="row" align="left">
            <div class="col-lg-11">
                <div class="panel panel-primary">
                    <div class="panel-heading" align="center">
                        <h3 class="panel-title">
                            Drug control Authority Details</h3>
                    </div>
                    <%-- <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>--%>
                    <div class="panel-body">
                        <div class="col-sm-4" style="text-align: center">
                            <asp:Label ID="Label4" runat="server" CssClass="LBLBLACK" Width="200px">Select License Type<font 
                                                            color="red">*</font></asp:Label>
                        </div>
                         <div class="col-sm-4">
                            <asp:DropDownList ID="ddltypeoflicense" runat="server" class="form-control txtbox"
                                Height="33px" AutoPostBack="True" Width="180px" TabIndex="1" OnSelectedIndexChanged="ddltypeoflicense_SelectedIndexChanged">
                                <asp:ListItem Text="Select the License Type" Value="0"></asp:ListItem>
                                <asp:ListItem Text="Manufacturing License" Value="1"></asp:ListItem>
                                <asp:ListItem Text="Sales License" Value="2"></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div id="divSalesfields" runat="server" visible="false">
                            <div class="row">
                                <div class="col-sm-2" style="text-align: center">
                                    <asp:Label ID="Label3" runat="server" CssClass="LBLBLACK" Width="200px">Category of license<font 
                                                            color="red">*</font></asp:Label>
                                </div>
                                <div class="col-sm-2">
                                    <asp:DropDownList ID="ddlcatogorylicensen" runat="server" class="form-control txtbox"
                                        Height="33px" AutoPostBack="True" Width="180px" TabIndex="1" OnSelectedIndexChanged="ddlcatogorylicensen_SelectedIndexChanged" OnTextChanged="ddlcatogorylicensen_TextChanged">
                                        <asp:ListItem Text="Select the catogory License" Value="0"></asp:ListItem>
                                        <asp:ListItem Text="Wholesale" Value="1"></asp:ListItem>
                                        <asp:ListItem Text="Retail" Value="2"></asp:ListItem>
                                        <asp:ListItem Text="Wholesale and retail" Value="4"></asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <div class="auto-style1">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="ddlcatogorylicensen"
                                        ErrorMessage="Please Select the Catogory license" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                </div>
                                <br />
                                <div class="col-sm-2" style="text-align: center">
                                    <asp:Label ID="Label2" runat="server" CssClass="LBLBLACK" Width="200px">Type of License<font 
                                                            color="red">*</font></asp:Label>
                                </div>
                                <div class="col-sm-2">
                                    <asp:DropDownList ID="ddlLincensetype" runat="server" class="form-control txtbox"
                                        Height="33px" AutoPostBack="True" Width="180px" TabIndex="1" OnSelectedIndexChanged="ddlLincensetype_SelectedIndexChanged">
                                        <asp:ListItem Text="Select License Type" Value="0"></asp:ListItem>
                                        <asp:ListItem Text="Grant" Value="1"></asp:ListItem>
                                        <asp:ListItem Text="License Retention" Value="2"></asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <div class="col-sm-2">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddlLincensetype"
                                        ErrorMessage="Please Select " ValidationGroup="group">*</asp:RequiredFieldValidator>
                                </div>
                                <div class="col-sm-2" style="text-align: center">
                                    <asp:Label ID="Label7" runat="server" CssClass="LBLBLACK" Width="200px">Type of Firm<font 
                                                            color="red">*</font></asp:Label>
                                </div>
                                <div class="col-sm-2">
                                    <asp:DropDownList ID="ddltypeform" runat="server" class="form-control txtbox" Height="33px"
                                        AutoPostBack="True" Width="180px" TabIndex="1">
                                        <asp:ListItem Text="Select type of forms" Value="0"></asp:ListItem>
                                        <asp:ListItem Text="Proprietary" Value="1"></asp:ListItem>
                                        <asp:ListItem Text="Partnership" Value="2"></asp:ListItem>
                                        <asp:ListItem Text="Pvt Ltd" Value="3"></asp:ListItem>
                                        <asp:ListItem Text="Public Limited" Value="4"></asp:ListItem>
                                        <asp:ListItem Text="Co-Operative" Value="5"></asp:ListItem>
                                        <asp:ListItem Text="LLP" Value="6"></asp:ListItem>
                                        <asp:ListItem Text="Trust" Value="7"></asp:ListItem>
                                        <asp:ListItem Text="PPP" Value="8"></asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <div class="col-sm-2">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="ddltypeform"
                                        ErrorMessage="Please Select type of form" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                </div>
                            </div>
                        </div>
                        <br />
                        <div id="divtypeform" runat="server" visible="false">
                            <div id="Div1" class="row" runat="server">
                                <div class="col-sm-2" style="text-align: left">
                                </div>
                                <div class="col-sm-2">
                                </div>
                                <div class="col-sm-2">
                                </div>
                            </div>
                        </div>
                        <br />
                        <table align="center" cellpadding="10" cellspacing="5" style="width: 90%">
                            <%-- <tr>
                                                <td style="padding: 5px; margin: 5px" valign="top">
                                                    <asp:Label ID="Label422" runat="server" CssClass="LBLBLACK" Font-Bold="True"
                                                        Width="510px">Constitution Details of the firm  <font 
                                                            color="red">*</font></asp:Label>
                                                </td>
                                            </tr>--%>
                            <tr id="trconheading" runat="server" visible="false">
                                <td style="padding: 5px; margin: 5px; text-align: left; font-weight: bold">
                                    Constitution Details of the firm&nbsp;
                                </td>
                            </tr>
                            <tr id="trconstitutiongrid" runat="server" visible="false">
                                <td style="padding: 5px; margin: 5px; text-align: left; font-weight: bold">
                                    <asp:GridView ID="gvProprietor" runat="server" AutoGenerateColumns="False" border="3"
                                        CellPadding="1" CellSpacing="1" OnRowCommand="gvProprietor_RowCommand" OnRowDataBound="gvProprietor_RowDataBound">
                                        <FooterStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                        <RowStyle BackColor="#EBF2FE" CssClass="GRDITEM" HorizontalAlign="Left" VerticalAlign="Middle" />
                                        <Columns>
                                            <asp:TemplateField HeaderText="Sl No.">
                                                <ItemTemplate>
                                                    <asp:Label ID="Label1" runat="server" Text="<%#Container.DataItemIndex+1 %>"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Name of the proprietor/partners / directors">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtPropName" runat="server" class="form-control txtbox"></asp:TextBox>
                                                </ItemTemplate>
                                                <ItemStyle CssClass="scroll_td" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Designation">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtDesignation" runat="server" class="form-control txtbox"></asp:TextBox>
                                                </ItemTemplate>
                                                <ItemStyle CssClass="scroll_td" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Permanent Address">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtPermAddr" runat="server" class="form-control txtbox"></asp:TextBox>
                                                </ItemTemplate>
                                                <ItemStyle CssClass="scroll_td" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="ID Proof Ref. No. (Aadhaar Card/ Passport No.)">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtIDProof" runat="server" class="form-control txtbox"></asp:TextBox>
                                                </ItemTemplate>
                                                <ItemStyle CssClass="scroll_td" />
                                            </asp:TemplateField>
                                            <asp:TemplateField Visible="true">
                                                <ItemTemplate>
                                                    <asp:FileUpload ID="fileloadupload" runat="server" CssClass="form-control txtbox"
                                                        Height="28px" />
                                                    <asp:Label ID="LoadUpload" runat="server"></asp:Label>
                                                </ItemTemplate>
                                                <HeaderTemplate>
                                                    Photo
                                                </HeaderTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Effective Date">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtSelectDate" runat="server" TextMode="Date"></asp:TextBox>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Gender" ItemStyle-Width="100px">
                                                <ItemTemplate>
                                                              <asp:DropDownList ID="ddlgender" runat="server" class="form-control txtbox" TabIndex="1"
                                                                        >
                                                                        <asp:ListItem Value="0">--Gender--</asp:ListItem>
                                                                        <asp:ListItem Value="M">Male</asp:ListItem>
                                                                        <asp:ListItem Value="F">Female</asp:ListItem>
                                                                        <asp:ListItem Value="T">Transgender</asp:ListItem>
                                                                    </asp:DropDownList>
                                                </ItemTemplate>
                                     
                                            </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Mobile Number" ItemStyle-Width="100px">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtMobileNumber" MaxLength="10" runat="server" class="form-control txtbox"></asp:TextBox>
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
                                <td style="padding: 5px; margin: 5px; text-align: left; font-weight: bold; height: 20px">
                                </td>
                            </tr>
                            <tr id="trtechnicalstaff" runat="server" visible="false">
                                <td style="padding: 5px; margin: 5px; text-align: left; font-weight: bold">
                                    
                                    <asp:Label ID="lblTechnicalStaff" runat="server" Text="Label"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="padding: 5px; margin: 5px; text-align: left; font-weight: bold">
                                </td>
                            </tr>
                            <tr id="trtechnicalstaffgrid" runat="server" visible="false">
                                <td style="padding: 5px; margin: 5px; text-align: left; font-weight: bold">
                                    <asp:GridView ID="gvTechStaff" runat="server" AutoGenerateColumns="False" border="3"
                                        CellPadding="1" CellSpacing="1" OnRowCommand="gvTechStaff_RowCommand" OnRowDataBound="gvTechStaff_RowDataBound">
                                        <FooterStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                        <RowStyle BackColor="#EBF2FE" CssClass="GRDITEM" HorizontalAlign="Left" VerticalAlign="Middle" />
                                        <Columns>
                                            <asp:TemplateField HeaderText="Sl No.">
                                                <ItemTemplate>
                                                    <asp:Label ID="Label1" runat="server" Text="<%#Container.DataItemIndex+1 %>"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Name of the Staff member">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtStaffName" runat="server" class="form-control txtbox"></asp:TextBox>
                                                </ItemTemplate>
                                                <ItemStyle CssClass="scroll_td" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Qualification">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtQualification" runat="server" class="form-control txtbox"></asp:TextBox>
                                                </ItemTemplate>
                                                <ItemStyle CssClass="scroll_td" />
                                            </asp:TemplateField>
                                          
                                            <asp:TemplateField HeaderText="RP Number">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtDesignation" runat="server" class="form-control txtbox"></asp:TextBox>
                                                </ItemTemplate>
                                                <ItemStyle CssClass="scroll_td" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Experience">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtExperience" runat="server" class="form-control txtbox" onkeypress="return inputOnlyNumbers(event)"></asp:TextBox>
                                                </ItemTemplate>
                                                <ItemStyle CssClass="scroll_td" />
                                            </asp:TemplateField>
                                           <asp:TemplateField HeaderText="RP Certificate issued Date">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtcertificateDate" runat="server" TextMode="Date"></asp:TextBox>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                               <asp:TemplateField HeaderText="Date of Joining">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtDateofJoin" runat="server" TextMode="Date"></asp:TextBox>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                             <asp:TemplateField Visible="true">
                                                <ItemTemplate>
                                                    <asp:FileUpload ID="fileloaduploadRP" runat="server" CssClass="form-control txtbox"
                                                        Height="28px" />
                                                    <asp:Label ID="RPUpload" runat="server"></asp:Label>
                                                </ItemTemplate>
                                                <HeaderTemplate>
                                                    RP Photo                                               
                                                </HeaderTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Section for which approval is sought" Visible="false">
                                                <ItemTemplate>
                                                    <asp:DropDownList ID="ddlSection" runat="server" class="form-control txtbox" Height="33px" Width="180px">
                                                        <asp:ListItem>--Select--</asp:ListItem>
                                                    </asp:DropDownList>
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
                                
                            <tr id="trRPDetails" runat="server" visible="false">       
                                <td style="padding: 5px; margin: 5px; text-align: left; font-weight: bold">
                                    <asp:GridView ID="grdRPDetails" runat="server" AutoGenerateColumns="False" border="3"
                                        CellPadding="1" CellSpacing="1" OnRowCommand="grdRPDetails_RowCommand" OnRowDataBound="grdRPDetails_RowDataBound" >
                                        <FooterStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                        <RowStyle BackColor="#EBF2FE" CssClass="GRDITEM" HorizontalAlign="Left" VerticalAlign="Middle" />
                                        <Columns>
                                            <asp:TemplateField HeaderText="Sl No.">
                                                <ItemTemplate>
                                                    <asp:Label ID="Label1" runat="server" Text="<%#Container.DataItemIndex+1 %>"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Name">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtStaffName" runat="server" class="form-control txtbox"></asp:TextBox>
                                                </ItemTemplate>
                                                <ItemStyle CssClass="scroll_td" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Qualification">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtQualification" runat="server" class="form-control txtbox"></asp:TextBox>
                                                </ItemTemplate>
                                                <ItemStyle CssClass="scroll_td" />
                                            </asp:TemplateField>
                                          
                                             <asp:TemplateField HeaderText="ID Proof Ref.No.">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtIDProof" runat="server" class="form-control txtbox" ></asp:TextBox>
                                                </ItemTemplate>
                                                <ItemStyle CssClass="scroll_td" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Experience">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtExperience" runat="server" class="form-control txtbox" onkeypress="return inputOnlyNumbers(event)"></asp:TextBox>
                                                </ItemTemplate>
                                                <ItemStyle CssClass="scroll_td" />
                                            </asp:TemplateField>
                                            
                                               <asp:TemplateField HeaderText="Approval Sought">
                                                <ItemTemplate>
                                                    <asp:DropDownList ID="ddlApprovalSought" runat="server" class="form-control txtbox" TabIndex="1"
                                                                        >
                                                                        <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                                        <asp:ListItem Value="1">Manufacturing chemist</asp:ListItem>
                                                                        <asp:ListItem Value="2">Analytical chemist(Instrumentation)</asp:ListItem>
                                                                        <asp:ListItem Value="3">Analytical chemist(Wet Analysis)</asp:ListItem>
                                                        <asp:ListItem Value="4">Analytical chemist(Microbiology)</asp:ListItem>
                                                                    </asp:DropDownList>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                             <asp:TemplateField Visible="true">
                                                <ItemTemplate>
                                                    <asp:FileUpload ID="fileloaduploadRP" runat="server" CssClass="form-control txtbox"
                                                        Height="28px" />
                                                    <asp:Label ID="RPUpload" runat="server"></asp:Label>
                                                </ItemTemplate>
                                                <HeaderTemplate>
                                                    Photo                                               
                                                </HeaderTemplate>
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
                                <td style="padding: 5px; margin: 5px; text-align: left; font-weight: bold">
                                </td>
                            </tr>
                            <tr>
                                <td style="padding: 5px; margin: 5px; text-align: left; font-weight: bold; height: 20px">
                                </td>
                            </tr>
                            <tr id="trdrugproduct" runat="server" visible="false">
                                <td style="padding: 5px; margin: 5px; text-align: left; font-weight: bold">
                                    <%--LIST OF APPLIED DRUG PRODUCTS--%>
                                    PRODUCT DETAILS
                                </td>
                            </tr>
                            <tr id="trdrugproductgrid" runat="server" visible="false">
                                <td style="padding: 5px; margin: 5px; text-align: left; font-weight: bold">
                                    <asp:GridView ID="gvDrugProducts" runat="server" AutoGenerateColumns="False" border="3"
                                        CellPadding="1" CellSpacing="1" OnRowCommand="gvDrugProducts_RowCommand" OnRowDataBound="gvDrugProducts_RowDataBound">
                                        <FooterStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                        <RowStyle BackColor="#EBF2FE" CssClass="GRDITEM" HorizontalAlign="Left" VerticalAlign="Middle" />
                                        <Columns>
                                            <asp:TemplateField HeaderText="Sl No.">
                                                <ItemTemplate>
                                                    <asp:Label ID="Label1" runat="server" Text="<%#Container.DataItemIndex+1 %>"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Name of the product (along with the strength and pharmacopoeial specifications)
">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtProductName" runat="server" class="form-control txtbox"></asp:TextBox>
                                                </ItemTemplate>
                                                <ItemStyle CssClass="scroll_td" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Composition of the product">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtComposition" runat="server" class="form-control txtbox"></asp:TextBox>
                                                </ItemTemplate>
                                                <ItemStyle CssClass="scroll_td" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Export/ domestic">
                                                <ItemTemplate>
                                                    <asp:DropDownList ID="ddlExportorDomestic" runat="server" class="form-control txtbox"
                                                        Height="33px" Width="100px">
                                                        <asp:ListItem>--Select--</asp:ListItem>
                                                        <asp:ListItem Value="E">Export</asp:ListItem>
                                                        <asp:ListItem Value="D">Domestic</asp:ListItem>
                                                    </asp:DropDownList>
                                                </ItemTemplate>
                                                <ItemStyle CssClass="scroll_td" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Product Category">
                                                <ItemTemplate>
                                                    <asp:DropDownList ID="ddlProductCategory" runat="server" class="form-control txtbox"
                                                        Height="33px" Width="100px">
                                                        <asp:ListItem>--Select--</asp:ListItem>
                                                        <asp:ListItem Value="P1">Form 25</asp:ListItem>
                                                        <asp:ListItem Value="P2">Form 28</asp:ListItem>
                                                        <asp:ListItem Value="P3">Form 25F</asp:ListItem>
                                                        <asp:ListItem Value="P4">Form 25D</asp:ListItem>
                                                    </asp:DropDownList>
                                                </ItemTemplate>
                                                <ItemStyle CssClass="scroll_td" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Brand name (if applicable in case of export only drugs)
">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtBrandName" runat="server" class="form-control txtbox"></asp:TextBox>
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
                                <td style="padding: 5px; margin: 5px; text-align: left; font-weight: bold; height: 20px">
                                </td>
                            </tr>
                            <tr id="trattachment" runat="server" visible="false">
                                <td colspan="3">
                                    <table style="width: 80%">
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                1
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label387" runat="server" CssClass="LBLBLACK" Width="210px">Statutory form – 19 for licenses in form (20B,21B) along with covering letter<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                :
                                            </td>
                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:FileUpload ID="FileUploadStatutory" runat="server" class="form-control txtbox"
                                                    Height="28px" />
                                                <asp:HyperLink ID="HyperLinkFileNameStatutory" runat="server" Visible="false" CssClass="LBLBLACK"
                                                    Width="165px" Target="_blank">[lblFileNameStatutory]</asp:HyperLink>
                                                <br />
                                                <asp:Label ID="LabelStatutory" runat="server"></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                <asp:Button ID="BtnStatutory" runat="server" CssClass="btn btn-xs btn-warning" Height="28px"
                                                    TabIndex="10" Text="Upload" Width="72px" OnClick="BtnStatutory_Click" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                2
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label5" runat="server" CssClass="LBLBLACK" Width="210px">Declaration by the proprietor / Partner / Director / Competent Persons / Regd. Pharmacist with proof of residential address (Present and Permanent) for proof of residential address – Aadhar Card, Pass Port, Voter ID. In prescribed proforma.<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                :
                                            </td>
                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:FileUpload ID="FileUploadproprietorDeclaration" runat="server" class="form-control txtbox"
                                                    Height="28px" />
                                                <asp:HyperLink ID="HyperLinkproprietorDeclaration" Visible="false"  runat="server" CssClass="LBLBLACK"
                                                    Width="165px" Target="_blank">[lblFileNameproprietorDeclaration]</asp:HyperLink>
                                                <br />
                                                <asp:Label ID="LabelproprietorDeclaration" runat="server"></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                <asp:Button ID="btnproprietorDeclaration" runat="server" CssClass="btn btn-xs btn-warning"
                                                    Height="28px" TabIndex="10" Text="Upload" Width="72px" OnClick="btnproprietorDeclaration_Click" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                3&nbsp;
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label9" runat="server" CssClass="LBLBLACK" Width="210px">Partnership deed in case of partnership firm / List of Directors downloaded from MCA website signed by Company Secretary / Managing Director (In case of company).<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                :
                                            </td>
                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:FileUpload ID="FileUploadPartnershipdeed" runat="server" class="form-control txtbox"
                                                    Height="28px" />
                                                <asp:HyperLink ID="HyperLinkPartnershipdeed" runat="server" Visible="false"  CssClass="LBLBLACK" Width="165px"
                                                    Target="_blank">[lblFileNamePartnershipdeed]</asp:HyperLink>
                                                <br />
                                                <asp:Label ID="LabelPartnershipdeed" runat="server"></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                <asp:Button ID="btnPartnershipdeed" runat="server" CssClass="btn btn-xs btn-warning"
                                                    Height="28px" TabIndex="10" Text="Upload" Width="72px" OnClick="btnPartnershipdeed_Click" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                4
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label1" runat="server" CssClass="LBLBLACK" Width="210px">In case of company an Affidavit under Section 34 of Drugs and Cosmetics Act, 1940 on Rs.20/- stamp paper signed by one of the Directors of the company.. In prescribed proforma.<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                :
                                            </td>
                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:FileUpload ID="FileUploadAffidavitDrug" runat="server" class="form-control txtbox"
                                                    Height="28px" />
                                                <asp:HyperLink ID="HyperLinkAffidavitDrug" runat="server" Visible="false"  CssClass="LBLBLACK" Width="165px"
                                                    Target="_blank">[lblFileNameAffidavitDrug]</asp:HyperLink>
                                                <br />
                                                <asp:Label ID="LabelAffidavitDrug" runat="server"></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                <asp:Button ID="btnAffidavitDrug" runat="server" CssClass="btn btn-xs btn-warning"
                                                    Height="28px" TabIndex="10" Text="Upload" Width="72px" OnClick="btnAffidavitDrug_Click" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                5
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label6" runat="server" CssClass="LBLBLACK" Width="210px">Special declaration by Registered Pharmacist on Rs.20/- Non-Judicial stamp paper (in case of Registered Pharmacist is appointed as C.P). In prescribed proforma.<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                :
                                            </td>
                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:FileUpload ID="FileUploadRegisteredPharmacist" runat="server" class="form-control txtbox"
                                                    Height="28px" />
                                                <asp:HyperLink ID="HyperLinkRegisteredPharmacist" runat="server" Visible="false"  CssClass="LBLBLACK"
                                                    Width="165px" Target="_blank">[lblFileNameRegisteredPharmacist]</asp:HyperLink>
                                                <br />
                                                <asp:Label ID="LabelRegisteredPharmacist" runat="server"></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                <asp:Button ID="btnRegisteredPharmacist" runat="server" CssClass="btn btn-xs btn-warning"
                                                    Height="28px" TabIndex="10" Text="Upload" Width="72px" OnClick="btnRegisteredPharmacist_Click" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                6
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label8" runat="server" CssClass="LBLBLACK" Width="210px">Self attested copy of Registered Pharmacist certificate (renewal up to date) affixed with latest original photograph and signature of the candidate (in case Registered Pharmacist is appointed as C.P) / SSC / degree certificate (in case of candidate other than R.P).<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                :
                                            </td>
                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:FileUpload ID="FileUploadSelfattested" runat="server" class="form-control txtbox"
                                                    Height="28px" />
                                                <asp:HyperLink ID="HyperLinkSelfattested" runat="server" CssClass="LBLBLACK" Visible="false"  Width="165px"
                                                    Target="_blank">[lblFileNameSelfattested]</asp:HyperLink>
                                                <br />
                                                <asp:Label ID="LabelSelfattested" runat="server"></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                <asp:Button ID="btnSelfattested" runat="server" CssClass="btn btn-xs btn-warning"
                                                    Height="28px" TabIndex="10" Text="Upload" Width="72px" OnClick="btnSelfattested_Click" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                7
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label11" runat="server" CssClass="LBLBLACK" Width="210px">Plan of the premises indicating the carpet area (specifying length and breadth in meters and area in Sq.m) with the signature of Building owner and the applicant (Prop/ partners / Authorized signatory / Managing Director, etc,.) in a legal size.<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                :
                                            </td>
                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:FileUpload ID="FileUploadpremisesindicating" runat="server" class="form-control txtbox"
                                                    Height="28px" />
                                                <asp:HyperLink ID="HyperLinkpremisesindicating" runat="server" Visible="false"  CssClass="LBLBLACK"
                                                    Width="165px" Target="_blank">[lblFileNamepremisesindicating]</asp:HyperLink>
                                                <br />
                                                <asp:Label ID="Labelpremisesindicating" runat="server"></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                <asp:Button ID="btnuploadpremisesindicating" runat="server" CssClass="btn btn-xs btn-warning"
                                                    Height="28px" TabIndex="10" Text="Upload" Width="72px" OnClick="btnuploadpremisesindicating_Click" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                8
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label13" runat="server" CssClass="LBLBLACK" Width="210px">Declaration of building owner (Photograph of the building owner with self attestation). In prescribed proforma. Self attested photocopy of the document showing the proof of ownership of the building owner for the premises to be licensed (E.C / any other legal document showing the present ownership.<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                :
                                            </td>
                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:FileUpload ID="FileUploadPhotographowner" runat="server" class="form-control txtbox"
                                                    Height="28px" />
                                                <asp:HyperLink ID="HyperLinkPhotographowner" runat="server"  Visible="false"  CssClass="LBLBLACK" Width="165px"
                                                    Target="_blank">[lblFileNamePhotographowner]</asp:HyperLink>
                                                <br />
                                                <asp:Label ID="LabelPhotographowner" runat="server"></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                <asp:Button ID="BtnPhotographowner" runat="server" CssClass="btn btn-xs btn-warning"
                                                    Height="28px" TabIndex="10" Text="Upload" Width="72px" OnClick="BtnPhotographowner_Click" />
                                            </td>
                                        </tr>
                                        <tr id="trExperience" runat="server" visible="false">
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                9
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label10" runat="server" CssClass="LBLBLACK" Width="210px">Experience certificate of Competent person.<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                :
                                            </td>
                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:FileUpload ID="FileUploadExperiencecertificate" runat="server" class="form-control txtbox"
                                                    Height="28px" />
                                                <asp:HyperLink ID="HyperLinkExperiencecertificate"  Visible="false"  runat="server" CssClass="LBLBLACK"
                                                    Width="165px" Target="_blank">[lblFileNameExperiencecertificate]</asp:HyperLink>
                                                <br />
                                                <asp:Label ID="LabelExperiencecertificate" runat="server"></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                <asp:Button ID="btnExperiencecertificate" runat="server" CssClass="btn btn-xs btn-warning"
                                                    Height="28px" TabIndex="10" Text="Upload" Width="72px" OnClick="btnExperiencecertificate_Click" />
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr id="trmanufacturerdoc" runat="server" visible="false">
                                <td colspan="3">
                                    <table style="width: 80%">
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">1</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label12" runat="server" CssClass="LBLBLACK" Width="210px">Application (statutory) in form-24/ 27/ 27D/ 24F.<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:FileUpload ID="FileUpload1" runat="server" class="form-control txtbox"
                                                    Height="28px" />

                                                <asp:HyperLink ID="HyperLink1" runat="server"  Visible="false"  CssClass="LBLBLACK" Width="165px"
                                                    Target="_blank">[lblFileNameStatutory]</asp:HyperLink>
                                                <br />
                                                <asp:Label ID="Label14" runat="server"></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                <asp:Button ID="Button1" runat="server" CssClass="btn btn-xs btn-warning"
                                                    Height="28px" TabIndex="10" Text="Upload"
                                                    Width="72px" OnClick="Button1_Click" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">2</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label15" runat="server" CssClass="LBLBLACK" Width="210px">Declaration of the Proprietor / Partners / Directors etc. in Affidavit  (as per format) & List of Directors downloaded from MCA website signed by Company Secretary / Managing Director (In case of company).<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:FileUpload ID="FileUpload2" runat="server" class="form-control txtbox"
                                                    Height="28px" />

                                                <asp:HyperLink ID="HyperLink2" runat="server"  Visible="false"  CssClass="LBLBLACK" Width="165px"
                                                    Target="_blank">[lblFileNameStatutory]</asp:HyperLink>
                                                <br />
                                                <asp:Label ID="Label16" runat="server"></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                <asp:Button ID="Button2" runat="server" CssClass="btn btn-xs btn-warning"
                                                    Height="28px" TabIndex="10" Text="Upload"
                                                    Width="72px" OnClick="Button2_Click" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">3</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label17" runat="server" CssClass="LBLBLACK" Width="210px">Partnership deed  in case of Partnership firms.<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:FileUpload ID="FileUpload3" runat="server" class="form-control txtbox"
                                                    Height="28px" />

                                                <asp:HyperLink ID="HyperLink3" runat="server"  Visible="false"  CssClass="LBLBLACK" Width="165px"
                                                    Target="_blank">[lblFileNameStatutory]</asp:HyperLink>
                                                <br />
                                                <asp:Label ID="Label18" runat="server"></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                <asp:Button ID="Button3" runat="server" CssClass="btn btn-xs btn-warning"
                                                    Height="28px" TabIndex="10" Text="Upload"
                                                    Width="72px" OnClick="Button3_Click" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">4</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label19" runat="server" CssClass="LBLBLACK" Width="210px">Self attested Copy of Aadhar card/Passport/Electoral card as proof of residential address of the responsible person as mentioned in the Affidavit at Sl.No. 2.<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:FileUpload ID="FileUpload4" runat="server" class="form-control txtbox"
                                                    Height="28px" />

                                                <asp:HyperLink ID="HyperLink4" runat="server"  Visible="false"  CssClass="LBLBLACK" Width="165px"
                                                    Target="_blank">[lblFileNameStatutory]</asp:HyperLink>
                                                <br />
                                                <asp:Label ID="Label20" runat="server"></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                <asp:Button ID="Button4" runat="server" CssClass="btn btn-xs btn-warning"
                                                    Height="28px" TabIndex="10" Text="Upload"
                                                    Width="72px" OnClick="Button4_Click" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">5</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label21" runat="server" CssClass="LBLBLACK" Width="210px">Rent / Lease deed in case of Rental premises.<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:FileUpload ID="FileUpload5" runat="server" class="form-control txtbox"
                                                    Height="28px" />

                                                <asp:HyperLink ID="HyperLink5" runat="server"  Visible="false"  CssClass="LBLBLACK" Width="165px"
                                                    Target="_blank">[lblFileNameStatutory]</asp:HyperLink>
                                                <br />
                                                <asp:Label ID="Label22" runat="server"></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                <asp:Button ID="Button5" runat="server" CssClass="btn btn-xs btn-warning"
                                                    Height="28px" TabIndex="10" Text="Upload"
                                                    Width="72px" OnClick="Button5_Click" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">6</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label23" runat="server" CssClass="LBLBLACK" Width="210px">Declaration of the ownership of the premises if premises owned by the applicant firm or company, with the documentary evidence of ownership like Registered sale deed and/or proof of allotment of the site along with the latest property tax receipt.<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:FileUpload ID="FileUpload6" runat="server" class="form-control txtbox"
                                                    Height="28px" />

                                                <asp:HyperLink ID="HyperLink6" runat="server"  Visible="false"  CssClass="LBLBLACK" Width="165px"
                                                    Target="_blank">[lblFileNameStatutory]</asp:HyperLink>
                                                <br />
                                                <asp:Label ID="Label24" runat="server"></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                <asp:Button ID="Button6" runat="server" CssClass="btn btn-xs btn-warning"
                                                    Height="28px" TabIndex="10" Text="Upload"
                                                    Width="72px" OnClick="Button6_Click" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">7</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label25" runat="server" CssClass="LBLBLACK" Width="210px">Plan and layout of the premises showing the installation of Machinery and Equipment.   preferably a Blue Print duly signed by the applicant who signed in the statutory form.<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:FileUpload ID="FileUpload7" runat="server" class="form-control txtbox"
                                                    Height="28px" />

                                                <asp:HyperLink ID="HyperLink7" runat="server"  Visible="false"  CssClass="LBLBLACK" Width="165px"
                                                    Target="_blank">[lblFileNameStatutory]</asp:HyperLink>
                                                <br />
                                                <asp:Label ID="Label26" runat="server"></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                <asp:Button ID="Button7" runat="server" CssClass="btn btn-xs btn-warning"
                                                    Height="28px" TabIndex="10" Text="Upload"
                                                    Width="72px" OnClick="Button7_Click" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">8</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label27" runat="server" CssClass="LBLBLACK" Width="210px">Detailed list of Manufacturing and Analytical Equipment.<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:FileUpload ID="FileUpload8" runat="server" class="form-control txtbox"
                                                    Height="28px" />

                                                <asp:HyperLink ID="HyperLink8" runat="server"  Visible="false"  CssClass="LBLBLACK" Width="165px"
                                                    Target="_blank">[lblFileNameStatutory]</asp:HyperLink>
                                                <br />
                                                <asp:Label ID="Label28" runat="server"></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                <asp:Button ID="Button8" runat="server" CssClass="btn btn-xs btn-warning"
                                                    Height="28px" TabIndex="10" Text="Upload"
                                                    Width="72px" OnClick="Button8_Click" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">9</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label29" runat="server" CssClass="LBLBLACK" Width="210px">Application for approval of Technical Staff in the prescribed format with enclosures of consent letter, copies of qualification certificates, experience certificates of proposed technical staff along with earlier approvals, if any, appointment order of the Technical staff.<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:FileUpload ID="FileUpload9" runat="server" class="form-control txtbox"
                                                    Height="28px" />

                                                <asp:HyperLink ID="HyperLink9" runat="server"  Visible="false"  CssClass="LBLBLACK" Width="165px"
                                                    Target="_blank">[lblFileNameStatutory]</asp:HyperLink>
                                                <br />
                                                <asp:Label ID="Label30" runat="server"></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                <asp:Button ID="Button9" runat="server" CssClass="btn btn-xs btn-warning"
                                                    Height="28px" TabIndex="10" Text="Upload"
                                                    Width="72px" OnClick="Button9_Click" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">10</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label31" runat="server" CssClass="LBLBLACK" Width="210px">Permission obtained from the Municipal Authorities/ Panchayat authorities / Certificate in conformity with Factories Act for construction and starting the Unit & Permission from T.S. Pollution Control Board clearance of the area for setting up the manufacturing facility.<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:FileUpload ID="FileUpload10" runat="server" class="form-control txtbox"
                                                    Height="28px" />

                                                <asp:HyperLink ID="HyperLink10" runat="server"  Visible="false"  CssClass="LBLBLACK" Width="165px"
                                                    Target="_blank">[lblFileNameStatutory]</asp:HyperLink>
                                                <br />
                                                <asp:Label ID="Label32" runat="server"></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                <asp:Button ID="Button10" runat="server" CssClass="btn btn-xs btn-warning"
                                                    Height="28px" TabIndex="10" Text="Upload"
                                                    Width="72px" OnClick="Button10_Click" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">11</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label33" runat="server" CssClass="LBLBLACK" Width="210px">Form-46/ Form-46A from Drugs Controller General (India), New Delhi in case of new drugs (Either Bulk drug or Formulation) – New Drugs as defined under Rule 122 E of Drugs and Cosmetics Act and Rules made thereunder.<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:FileUpload ID="FileUpload11" runat="server" class="form-control txtbox"
                                                    Height="28px" />

                                                <asp:HyperLink ID="HyperLink11" runat="server" Visible="false" CssClass="LBLBLACK" Width="165px"
                                                    Target="_blank">[lblFileNameStatutory]</asp:HyperLink>
                                                <br />
                                                <asp:Label ID="Label34" runat="server"></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                <asp:Button ID="Button11" runat="server" CssClass="btn btn-xs btn-warning"
                                                    Height="28px" TabIndex="10" Text="Upload"
                                                    Width="72px" OnClick="Button11_Click" />
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr id="trManufactureCheckList" runat="server" visible="false">
                               

                                <td>
                                
                                    <div class="list-group" style="width:100%">

                                <b>
                                     Manufacture License Check List</b>
                                  <%--        <a href="../../DOCS/DCA/MANUFACTURE/Grant_Formulation, Bulk Drugs, Cosmetics, LVP_rDNA, Repacking Mfg_Licences_DCA.pdf" class="list-group-item" target="_blank" style="background-color: white">
                                    <img src="../../images/pdf.png">
                                    Grant of Manufacturing License</a>

                                <a href="../../DOCS/DCA/MANUFACTURE/Renewal_Formulation, Bulk Drugs, Cosmetics, LVP_rDNA, Repacking Mfg_Licences.pdf" class="list-group-item" target="_blank" style="background-color: white">
                                    <img src="../../images/pdf.png">
                                    Retention Certificate of Manufacturing License</a>

                                        <a href="../../DOCS/DCA/MANUFACTURE/Grant_Loan Licence.pdf" class="list-group-item" target="_blank" style="background-color: white">
                                    <img src="../../images/pdf.png">
                                    Grant of Manufacturing Loan License</a>

                                        
                                        <a href="../../DOCS/DCA/MANUFACTURE/Renewal_Loan Licence.pdf" class="list-group-item" target="_blank" style="background-color: white">
                                    <img src="../../images/pdf.png">
                                    Retention Certificate of Manufacturing Loan License</a>

                                         <a href="../../DOCS/DCA/MANUFACTURE/Grant of Test Licence_Form 29.pdf" class="list-group-item" target="_blank" style="background-color: white">
                                    <img src="../../images/pdf.png">
                                    Grant of Test License</a>

                                            <a href="../../DOCS/DCA/MANUFACTURE/Renewal of Test Licence.pdf" class="list-group-item" target="_blank" style="background-color: white">
                                    <img src="../../images/pdf.png">
                                    Renewal Certificate of Test License</a>

                                               <a href="../../DOCS/DCA/MANUFACTURE/Grant_Approval of Testing Laboratory.pdf" class="list-group-item" target="_blank" style="background-color: white">
                                    <img src="../../images/pdf.png">
                                    Grant of Approval of Testing Laboratory License</a>

                                          <a href="../../DOCS/DCA/MANUFACTURE/RENEWAL_Approval of Testing Laboratory.pdf" class="list-group-item" target="_blank" style="background-color: white">
                                    <img src="../../images/pdf.png">
                                    Renewal of Approval of Testing Laboratory License</a>

                                           <a href="../../DOCS/DCA/MANUFACTURE/Grant of additional product_DCA.pdf" class="list-group-item" target="_blank" style="background-color: white">
                                    <img src="../../images/pdf.png">
                                    Grant of Additional Product License</a>

                                           <a href="../../DOCS/DCA/MANUFACTURE/Issue of Duplicate Licence.pdf" class="list-group-item" target="_blank" style="background-color: white">
                                    <img src="../../images/pdf.png">
                                    Issue of Duplicate License</a>--%>

                                                <a href="../../DOCS/DCA/MANUFACTURE/PROFORMA_Mfg Application Checklist.pdf" class="list-group-item" target="_blank" style="background-color: white">
                                    <img src="../../images/pdf.png">
                                    Manufacturing Application Proforma</a>
 
 

                            </div>
                                </td>
                            </tr>

                            <tr id="trSalesCheckList" runat="server" visible="false">
                               

                                <td>
                                
                                    <div class="list-group" style="width:100%">

                                      <%--  <b >Sales License Checklist</b>
                                          <a href="../../DOCS/DCA/SALES/Grant Retail.pdf" class="list-group-item" target="_blank" style="background-color: white"> <img src="../../images/pdf.png">
                                    Grant of Retail License</a>

                                     <a href="../../DOCS/DCA/SALES/Grant Wholesale.pdf" class="list-group-item" target="_blank" style="background-color: white"> <img src="../../images/pdf.png">
                                    Grant of Whole Sale License</a>

                                 
                                     <a href="../../DOCS/DCA/SALES/Grant_Household remedies.pdf" class="list-group-item" target="_blank" style="background-color: white"> <img src="../../images/pdf.png">
                                    Grant of Restricted License</a>

 
                                            <a href="../../DOCS/DCA/SALES/Change of constitution.pdf" class="list-group-item" target="_blank" style="background-color: white"> <img src="../../images/pdf.png">
                                    Change of Constitution</a>

                                         <a href="../../DOCS/DCA/SALES/Renewal Retail_Wholesale.pdf" class="list-group-item" target="_blank" style="background-color: white">
                                    <img src="../../images/pdf.png">
                                    Retention Certificate of Retail License</a>

                                        <a href="../../DOCS/DCA/SALES/Renewal Retail_Wholesale (1).pdf" class="list-group-item" target="_blank" style="background-color: white">
                                    <img src="../../images/pdf.png">
                                    Retention Certificate of Whole Sale License</a>

                                               <a href="../../DOCS/DCA/SALES/Renewal_Household remedies.pdf" class="list-group-item" target="_blank" style="background-color: white">
                                    <img src="../../images/pdf.png">
                                    Retention Certificate of Restricted License</a>

                                         <a href="../../DOCS/DCA/SALES/Change of Pharmacist.pdf" class="list-group-item" target="_blank" style="background-color: white">
                                    <img src="../../images/pdf.png">
                                    Change of Pharmacist</a>--%>

                                            <a href="../../DOCS/DCA/SALES/PROFORMA_Sales application Checklist.pdf" class="list-group-item" target="_blank" style="background-color: white">
                                    <img src="../../images/pdf.png">
                                    Sales Application Proforma</a>


                                       
                            </div>
                                </td>
                            </tr>

                            <tr>
                                <td align="center" style="padding: 5px; margin: 5px; text-align: center;">
                                    <asp:Button ID="BtnSave1" runat="server" CssClass="btn btn-primary" Height="32px"
                                        OnClick="BtnSave_Click" TabIndex="10" Text="Save" Width="90px" ValidationGroup="group" />
                                    &nbsp;
                                    <asp:Button ID="BtnDelete0" runat="server" CssClass="btn btn-danger" Height="32px"
                                        OnClick="BtnDelete0_Click" TabIndex="10" Text="Previous" Width="90px" CausesValidation="False" />
                                    &nbsp;&nbsp;<asp:Button ID="BtnDelete" runat="server" CssClass="btn btn-danger" Height="32px"
                                        OnClick="BtnClear0_Click" TabIndex="10" Text="Next" Width="90px" ValidationGroup="group" />
                                    &nbsp;<asp:Button ID="BtnClear" runat="server" CausesValidation="False" CssClass="btn btn-warning"
                                        Height="32px" OnClick="BtnClear_Click" TabIndex="10" Text="ClearAll" ToolTip="To Clear  the Screen"
                                        Width="90px" />
                                </td>
                            </tr>
                            <tr>
                                <td align="center" style="padding: 5px; margin: 5px">
                                    <div id="success" runat="server" visible="false" class="alert alert-success">
                                        <a href="AddQualification.aspx" class="close" data-dismiss="alert" aria-label="close">
                                            &times;</a> <strong>Success!</strong><asp:Label ID="lblmsg0" runat="server"></asp:Label>
                                    </div>
                                    <div id="Failure" runat="server" visible="false" class="alert alert-danger">
                                        <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a> <strong>
                                            Warning!</strong>
                                        <asp:Label ID="lblmsg" runat="server"></asp:Label>
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
                        <asp:HiddenField ID="hdfFlagID0" runat="server" />
                        <asp:HiddenField ID="hdfpencode" runat="server" />
                    </div>
                    <%--</ContentTemplate>
                            </asp:UpdatePanel>--%>
                </div>
            </div>
        </div>
    </div>
    <%--<asp:UpdateProgress ID="UpdateProgress" runat="server" AssociatedUpdatePanelID="upd1">
                <ProgressTemplate>
                    <div class="update">
                    </div>
                </ProgressTemplate>
            </asp:UpdateProgress>--%>
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
    <%--</ContentTemplate>
    </asp:UpdatePanel>--%>
</asp:Content>
